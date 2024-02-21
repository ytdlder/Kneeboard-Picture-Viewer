namespace Kneeboard_Picture_Viewer
{
    public static class MyFunctions
    {
        // PUBLIC VARIABLES
        // *********************************************************************
        private static Button? btnDisableMouseLeaveEventFolder, btnDisableMouseLeaveEventFile;

        // for Hotkey-Navigation
        public static int activeFolderIndex = -1, activeImageIndex = -1;

        // get access to Main-Class elements
        private static WindowMain mainWindow = (WindowMain)Application.OpenForms[0];


        // FUNCTIONS
        // *********************************************************************
        // calculates the needed foreground color
        public static Color CalcTextColor(this Color clr)
        {
            if (clr.GetBrightness() >= 0.5)
            {
                return (Color.Black);
            }
            else
            {
                return (Color.White);
            }
        }

        // calculates the needed hover color
        private static void SetButtonHoverColor(this Button btn)
        {
            Color clr = btn.BackColor;
            double brighter = 1.3;
            double darker = 0.7;
            int minimum = 75;

            // 0.0 = black | 1.0 = white
            if (clr.GetBrightness() >= 0.5)
            {
                btn.BackColor = Color.FromArgb(
                    clr.A,
                    (int)Math.Clamp(clr.R * darker, minimum, 255),
                    (int)Math.Clamp(clr.G * darker, minimum, 255),
                    (int)Math.Clamp(clr.B * darker, minimum, 255)
                );
            }
            else
            {
                btn.BackColor = Color.FromArgb(
                    clr.A,
                    (int)Math.Clamp(clr.R * brighter, minimum, 255),
                    (int)Math.Clamp(clr.G * brighter, minimum, 255),
                    (int)Math.Clamp(clr.B * brighter, minimum, 255)
                );
            }
            btn.ForeColor = CalcTextColor(btn.BackColor);
        }

        // deactivates current and activates all other buttons
        private static void SetButtonAsActive(this Button btn, Color clrDefaultBackground)
        {
            // Enable other buttons
            foreach (Control btnParent in btn.Parent.Controls)
            {
                if (btnParent is Button)
                {
                    btnParent.Cursor = Cursors.Hand;

                    btnParent.BackColor = clrDefaultBackground;
                    btnParent.ForeColor = CalcTextColor(btnParent.BackColor);
                }
            }

            // Disable this button
            btn.Cursor = Cursors.Default;   // -> disabled button foreground color always black! => don't process click-event


            //btn.BackColor = Color.FromArgb((byte)~clrDefaultBackground.R, (byte)~clrDefaultBackground.G, (byte)~clrDefaultBackground.B);
            int Shift = 192;
            btn.BackColor = Color.FromArgb((byte)(clrDefaultBackground.R + Shift), (byte)(clrDefaultBackground.G + Shift), (byte)(clrDefaultBackground.B + Shift));

            btn.ForeColor = CalcTextColor(btn.BackColor);
        }


        // Folder Buttons
        // *********************************************************************
        public static void SetFolderButton(this Button btn)
        {
            SetFolderButtonAppearance(btn, Properties.Settings.Default.Folder_Button_Background);

            btn.MouseEnter += new EventHandler(evtButton_MouseEnter);
            btn.MouseLeave += new EventHandler((sender, e) => evtButton_MouseLeave(sender, e, Properties.Settings.Default.Folder_Button_Background));
            btn.Click += new EventHandler(evtFolderButton_Click);
        }

        private static void SetFolderButtonAppearance(this Button btn, Color clr)
        {
            btn.BackColor = clr;
            btn.ForeColor = CalcTextColor(btn.BackColor);
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            /*
            btn.AutoEllipsis = true;
            btn.Height = (Properties.Settings.Default.Folder_Button_Font.Height + 11);
            */
            btn.AutoSize = true;
            btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn.Dock = DockStyle.Top;

            btn.Margin = new Padding(1, 2, 1, 2);
            btn.Padding = new Padding(1);
            btn.TabStop = false;
        }

        private static void evtFolderButton_Click(object sender, EventArgs e)
        {
            Button btnFolder = sender as Button;

            if (btnDisableMouseLeaveEventFolder == null ||
                 btnDisableMouseLeaveEventFile == null ||
                 (btnFolder != btnDisableMouseLeaveEventFolder &&
                 btnFolder != btnDisableMouseLeaveEventFile)
                 )
            {
                SetButtonAsActive(btnFolder, Properties.Settings.Default.Folder_Button_Background);
                btnDisableMouseLeaveEventFolder = btnFolder;

                // for Hotkey-Navigation
                activeFolderIndex = (int)btnFolder.Tag;

                // Empty nav pane
                mainWindow.flowFileNav.Controls.Clear();

                // LOAD FILE-BUTTONS
                string BaseFolder = Properties.Settings.Default.Kneeboard_Images_Directory;

                string[] arrFiles = Directory.GetFiles(BaseFolder + "\\" + btnFolder.Name);
                //string[] arrFiles = Directory.GetFiles(BaseFolder + "\\" + btnFolder.Name, "*.png" + "*.jpg" + "*.bmp" + "*.gif" + "*.tif");

                if (arrFiles.Length > 0)
                {
                    Array.Sort(arrFiles, new AlphanumComparatorFast());

                    for (int i = 0; i < arrFiles.Length; i++)
                    {
                        Button btnFile = new Button();

                        // 'Name' is original, so it can be used later
                        btnFile.Name = arrFiles[i];

                        // Set 'Tag' to be its index for navigation
                        btnFile.Tag = i;

                        // 'Text' is embellished
                        string Filename = Path.GetFileNameWithoutExtension(arrFiles[i]);
                        Filename = Filename.Substring(Filename.IndexOf(@"_") + 1);
                        btnFile.Text = Filename;

                        // Set appearance & add events
                        btnFile.SetFileButton();

                        // Add to nav pane
                        mainWindow.flowFileNav.Controls.Add(btnFile);

                        // Activate first "button" on Folder open
                        if (i == 0)
                            btnFile.PerformClick();
                    }

                    mainWindow.ResizeFileNavForScrollBar();

                    // RESIZE NAV
                    if (Properties.Settings.Default.Close_Navigation)
                        mainWindow.CloseNav();
                }
            }
        }



        // File Buttons
        // *********************************************************************
        public static void SetFileButton(this Button btn)
        {
            SetFileButtonAppearance(btn, Properties.Settings.Default.File_Button_Background);

            btn.MouseEnter += new EventHandler(evtButton_MouseEnter);
            btn.MouseLeave += new EventHandler((sender, e) => evtButton_MouseLeave(sender, e, Properties.Settings.Default.File_Button_Background));
            btn.Click += new EventHandler(evtFileButton_Click);
        }

        private static void SetFileButtonAppearance(this Button btn, Color clr)
        {
            btn.BackColor = clr;
            btn.ForeColor = CalcTextColor(btn.BackColor);
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.AutoSize = true;
            btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn.Dock = DockStyle.Top;

            btn.Padding = new Padding(0);
            btn.Margin = new Padding(1, 0, 1, 0);
            btn.TabStop = true;
        }

        private static void evtFileButton_Click(object sender, EventArgs e)
        {
            Button btnFile = sender as Button;

            SetButtonAsActive(btnFile, Properties.Settings.Default.File_Button_Background);
            
            btnDisableMouseLeaveEventFile = btnFile;
            
            activeImageIndex = (int)btnFile.Tag;

            try
            {
                mainWindow.pictureBox.Load(btnFile.Name);
            }
            catch
            {
                mainWindow.pictureBox.Image = Properties.Resources.error_image;
            }
        }


        // Both
        // *********************************************************************
        private static void evtButton_MouseLeave(object sender, EventArgs e, Color clr)
        {
            Button btn = sender as Button;

            if (btnDisableMouseLeaveEventFolder == null ||
                btnDisableMouseLeaveEventFile == null ||
                (btn != btnDisableMouseLeaveEventFolder &&
                btn != btnDisableMouseLeaveEventFile)
                )
            {
                btn.BackColor = clr;
                btn.ForeColor = CalcTextColor(btn.BackColor);
            }

            if (Properties.Settings.Default.Close_Navigation)
                mainWindow.CloseNav();
        }

        private static void evtButton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (Properties.Settings.Default.Close_Navigation)
                mainWindow.OpenNav();

            if (btnDisableMouseLeaveEventFolder == null ||
                btnDisableMouseLeaveEventFile == null ||
                (btn != btnDisableMouseLeaveEventFolder &&
                btn != btnDisableMouseLeaveEventFile)
                )
            {
                SetButtonHoverColor(btn);
            }
        }
    }
}