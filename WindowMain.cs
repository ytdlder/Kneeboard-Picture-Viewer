// Debug.WriteLine();
// MessageBox.Show("Message", "Title", MessageBoxButtons.OK);
using System.Diagnostics;

namespace Kneeboard_Picture_Viewer
{
    public partial class WindowMain : Form
    {
        // PUBLIC VARIABLES
        // *********************************************************************
        private ValueTuple<Keys, KeyModifiers> hkFolderUp = (Keys.Left, KeyModifiers.Control | KeyModifiers.Alt);
        private ValueTuple<Keys, KeyModifiers> hkFolderDown = (Keys.Right, KeyModifiers.Control | KeyModifiers.Alt);
        private ValueTuple<Keys, KeyModifiers> hkFileUp = (Keys.Up, KeyModifiers.Control | KeyModifiers.Alt);
        private ValueTuple<Keys, KeyModifiers> hkFileDown = (Keys.Down, KeyModifiers.Control | KeyModifiers.Alt);
        private ValueTuple<Keys, KeyModifiers> hkFileTop = (Keys.Up, KeyModifiers.Control | KeyModifiers.Alt | KeyModifiers.Shift);

        // RESIZE NAV
        public System.Windows.Forms.Timer CloseNavTimer = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer OpenNavTimer = new System.Windows.Forms.Timer();


        // MAIN
        // *********************************************************************
        public WindowMain()
        {
            InitializeComponent();

            // Set tooltips
            toolTipMain.SetToolTip(btnInfo, "Info");
            toolTipMain.SetToolTip(btnSettings, "Settings");
            toolTipMain.SetToolTip(flowDirNav, "Folder up = Ctrl+Alt+Left\nFolder dn = Ctrl+Alt+Right");
            toolTipMain.SetToolTip(flowFileNav, "File top = Shift+Ctrl+Alt+Up\nFile up = Ctrl+Alt+Up\nFile dn = Ctrl+Alt+Down");

            // Systemwide global hotkeys
            // folder up/down
            HotKeyManager.RegisterHotKey(hkFolderUp.Item1, hkFolderUp.Item2 | KeyModifiers.NoRepeat);
            HotKeyManager.RegisterHotKey(hkFolderDown.Item1, hkFolderDown.Item2 | KeyModifiers.NoRepeat);

            // file forward/back/home
            HotKeyManager.RegisterHotKey(hkFileUp.Item1, hkFileUp.Item2 | KeyModifiers.NoRepeat);
            HotKeyManager.RegisterHotKey(hkFileDown.Item1, hkFileDown.Item2 | KeyModifiers.NoRepeat);
            HotKeyManager.RegisterHotKey(hkFileTop.Item1, hkFileTop.Item2 | KeyModifiers.NoRepeat);

            HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(HotKeyManager_HotKeyPressed);

            // RESIZE NAV
            // Setup mouse_leave timer
            CloseNavTimer.Tick += new EventHandler(evtCloseNavTimer);
            CloseNavTimer.Interval = 1000;

            // Setup hotkey timer
            OpenNavTimer.Tick += new EventHandler(evtOpenNavTimer);
            OpenNavTimer.Interval = 3000;

            flowDirNav.MouseEnter += new EventHandler(evtNav_MouseEnter);
            flowDirNav.MouseLeave += new EventHandler(evtNav_MouseLeave);
            flowFileNav.MouseEnter += new EventHandler(evtNav_MouseEnter);
            flowFileNav.MouseLeave += new EventHandler(evtNav_MouseLeave);
        }


        // FUNCTIONS
        // *********************************************************************
        public void WindowMain_ApplySettings()
        {
            flowDirNav.BackColor = Properties.Settings.Default.Folder_Background;
            flowDirNav.Font = Properties.Settings.Default.Folder_Button_Font;
            foreach (Control btn in flowDirNav.Controls)
            {
                if (btn is Button)
                {
                    btn.BackColor = Properties.Settings.Default.Folder_Button_Background;
                    btn.ForeColor = MyFunctions.CalcTextColor(btn.BackColor);
                }
            }

            flowFileNav.BackColor = Properties.Settings.Default.File_Background;
            flowFileNav.Font = Properties.Settings.Default.File_Button_Font;
            foreach (Control btn in flowFileNav.Controls)
            {
                if (btn is Button)
                {
                    btn.BackColor = Properties.Settings.Default.File_Button_Background;
                    btn.ForeColor = MyFunctions.CalcTextColor(btn.BackColor);
                }
            }

            btnInfo.BackColor = Properties.Settings.Default.Buttons_Background;
            btnSettings.BackColor = Properties.Settings.Default.Buttons_Background;

            // Reopen navigation pane
            if (Properties.Settings.Default.Close_Navigation)
                CloseNav();
            else
                OpenNav();

            // Check if resize is needed (Font changed)
            ResizeFileNavForScrollBar();

            // open Folder dialog if Folder is not yet set
            string BaseFolder = Properties.Settings.Default.Kneeboard_Images_Directory;

            if (BaseFolder == "" || !Directory.Exists(BaseFolder) || Directory.GetDirectories(BaseFolder).Length<1)
            {
                WindowSelectFolder windowSelectFolder = new WindowSelectFolder();
                windowSelectFolder.ShowDialog();
            }
        }
        
        private void FolderNavigation(bool forward)
        {
            int activeButtonIndex = MyFunctions.activeFolderIndex;
            int numberOfFolders = flowDirNav.Controls.Count;

            if (activeButtonIndex < 0 || activeButtonIndex > numberOfFolders)
                activeButtonIndex = forward ? 0 : numberOfFolders - 1;

            if (forward)
                activeButtonIndex = (activeButtonIndex + 1) % numberOfFolders;   // modulo to wrap around if on the end
            else
                activeButtonIndex = (activeButtonIndex + numberOfFolders - 1) % numberOfFolders;   // modulo to wrap around if on the beginning

            Button selectedButton = (Button)flowDirNav.Controls[activeButtonIndex];
            MyFunctions.activeImageIndex = activeButtonIndex;
            selectedButton.PerformClick();
        }

        private void ImageNavigation(bool forward)
        {
            int activeButtonIndex = MyFunctions.activeImageIndex;
            int numberOfImages = flowFileNav.Controls.Count;

            if (activeButtonIndex < 0 || activeButtonIndex > numberOfImages)
                activeButtonIndex = forward ? 0 : numberOfImages - 1;

            if (forward)
                activeButtonIndex = (activeButtonIndex + 1) % numberOfImages;   // modulo to wrap around if on the end
            else
                activeButtonIndex = (activeButtonIndex + numberOfImages - 1) % numberOfImages;   // modulo to wrap around if on the beginning

            Button selectedButton = (Button)flowFileNav.Controls[activeButtonIndex];
            MyFunctions.activeImageIndex = activeButtonIndex;
            selectedButton.PerformClick();
        }

        public void ResizeFileNavForScrollBar()
        {
            // Reset size
            flowFileNav.Width = 0;
            flowFileNav.Height = 0;
            flowFileNav.AutoSize = true;

            // Disable horizontal scroll (resize width of container to fit vertical scroll bar)
            if (flowFileNav.VerticalScroll.Visible == true)
            {
                flowFileNav.Width += +17;
                flowFileNav.AutoSize = false;
            }
        }


        // EVENTS
        // *********************************************************************
        private void evtWindowMain_Load(object sender, EventArgs e)
        {
            // Apply saved settings on program start
            WindowMain_ApplySettings();

            // Generate Folder Buttons
            string BaseFolder = Properties.Settings.Default.Kneeboard_Images_Directory;
            string[] arrFolders = Directory.GetDirectories(BaseFolder);

            Array.Sort(arrFolders, new AlphanumComparatorFast());

            for (int i = 0; i < arrFolders.Length; i++)
            {
                Button btn = new Button();

                // 'Name' is original, so it can be used later
                string Foldername = Path.GetFileName(arrFolders[i]);
                btn.Name = Foldername;

                // 'Text' is embellished
                Foldername = Foldername.Substring(Foldername.IndexOf(@"_") + 1);
                //btn.Text = Foldername.ToUpper();
                btn.Text = Foldername;

                // Set 'Tag' to be its index for navigation
                btn.Tag = i;

                // Set appearance & add events
                btn.SetFolderButton();  // -> MyFunctions.cs

                // Add to nav pane
                flowDirNav.Controls.Add(btn);

                // Activate first "button" on Program open
                if (i == 0)
                    btn.PerformClick();
            }
        }


        // Maximize-Control Clicked
        // https://www.vesic.org/english/blog-eng/net/full-screen-maximize/
        private void evtWindowMain_Resized(object sender, EventArgs e)
        {
            ResizeFileNavForScrollBar();

            if (this.WindowState == FormWindowState.Maximized)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Padding = new Padding(7, 7, 7, 7);
            }
        }

        private void evtPictureBox_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Padding = new Padding(0);
            }
        }

        // F1 or btnInfo Clicked
        private void evtWindowMain_Help(object sender, EventArgs e)
        {
            WindowAbout windowAbout = new WindowAbout();
            windowAbout.ShowDialog();
        }

        // btnSettings Clicked
        private void evtBtnSettings_Click(object sender, EventArgs e)
        {
            WindowSettings windowSettings = new WindowSettings();
            windowSettings.ShowDialog();
        }

        // Image Navigation
        private void DirUp()
        {
            if (flowFileNav.Controls.Count > 0)
                FolderNavigation(false);
        }
        private void DirDown()
        {
            if (flowFileNav.Controls.Count > 0)
                FolderNavigation(true);
        }
        private void FileUp()
        {
            if (flowFileNav.Controls.Count > 0)
                ImageNavigation(false);
        }
        private void FileTop()
        {
            if (flowFileNav.Controls.Count > 0)
            {
                MyFunctions.activeImageIndex = 0;
                ((Button)flowFileNav.Controls[0]).PerformClick();
            }
        }
        private void FileDown()
        {
            if (flowFileNav.Controls.Count > 0)
                ImageNavigation(true);
        }

        void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            if (e.Key == hkFolderUp.Item1 && e.Modifiers == hkFolderUp.Item2)
            {
                DirUp();
                if (Properties.Settings.Default.Close_Navigation)
                {
                    OpenNav();
                    OpenNavTimer.Start();
                }
            }
            if (e.Key == hkFolderDown.Item1 && e.Modifiers == hkFolderDown.Item2)
            {
                DirDown();
                if (Properties.Settings.Default.Close_Navigation)
                {
                    OpenNav();
                    OpenNavTimer.Start();
                }
            }
            if (e.Key == hkFileUp.Item1 && e.Modifiers == hkFileUp.Item2)
            {
                FileUp();
                if (Properties.Settings.Default.Close_Navigation)
                {
                    OpenNav();
                    OpenNavTimer.Start();
                }
            }
            if (e.Key == hkFileDown.Item1 && e.Modifiers == hkFileDown.Item2)
            {
                FileDown();
                if (Properties.Settings.Default.Close_Navigation)
                {
                    OpenNav();
                    OpenNavTimer.Start();
                }                    
            }
            if (e.Key == hkFileTop.Item1 && e.Modifiers == hkFileTop.Item2)
            {
                FileTop();
                if (Properties.Settings.Default.Close_Navigation)
                {
                    OpenNav();
                    OpenNavTimer.Start();
                }
            }
        }

        // RESIZE NAV
        private void evtCloseNavTimer(Object myObject, EventArgs myEventArgs)
        {
            CloseNavTimer.Stop();

            tableMainWindowLayout.ColumnStyles[0].SizeType = SizeType.Absolute;
            tableMainWindowLayout.ColumnStyles[0].Width = 20F;
            tableMainWindowLayout.ColumnStyles[1].SizeType = SizeType.Absolute;
            tableMainWindowLayout.ColumnStyles[1].Width = 40F;
        }

        private void evtNav_MouseEnter(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Close_Navigation)
                OpenNav();
        }

        private void evtNav_MouseLeave(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Close_Navigation)
                CloseNav();
        }

        public void CloseNav()
        {
            CloseNavTimer.Start();
        }
        public void OpenNav()
        {
            CloseNavTimer.Stop();

            tableMainWindowLayout.ColumnStyles[0].SizeType = SizeType.AutoSize;
            tableMainWindowLayout.ColumnStyles[1].SizeType = SizeType.AutoSize;
        }

        private void evtOpenNavTimer(Object myObject, EventArgs myEventArgs)
        {
            OpenNavTimer.Stop();

            tableMainWindowLayout.ColumnStyles[0].SizeType = SizeType.Absolute;
            tableMainWindowLayout.ColumnStyles[0].Width = 20F;
            tableMainWindowLayout.ColumnStyles[1].SizeType = SizeType.Absolute;
            tableMainWindowLayout.ColumnStyles[1].Width = 40F;
        }
        
    }
}