namespace Kneeboard_Picture_Viewer
{
    public partial class WindowSettings : Form
    {
        private WindowMain mainWindow = (WindowMain)Application.OpenForms[0];

        /*
         * save settings in VAR and restore on Close/Cancel
         * 
           private System.Configuration.SettingsBase settingsCache;
           settingsCache = Properties.Settings.Default;
           Properties.Settings.Default = settingsCache;
         * 
         * or save and restore propertyGrid items
            private GridItem gi;
            gi = propertyGrid.SelectedGridItem;
            while (gi.Parent != null)
            {
                gi = gi.Parent;
            }
            foreach (GridItem item in gi.GridItems)
            {
                ParseGridItems(item);
            }
            private void ParseGridItems(GridItem gi)
            {
                if (gi.GridItemType == GridItemType.Category)
                {
                    foreach (GridItem item in gi.GridItems)
                    {
                        ParseGridItems(item);
                    }
                }

                if (gi.Value != null)
                {
                    Debug.WriteLine(gi.Label +": "+ gi.Value.ToString());
                    //save to array
                }
            }
        */

        public WindowSettings()
        {
            InitializeComponent();

            // load current settings from store
            Properties.Settings.Default.Reload();

            // Set tooltips
            toolTipSettings.SetToolTip(btnSave, "Apply & Save settings and close window");
            toolTipSettings.SetToolTip(btnTry, "Preview settings");
            toolTipSettings.SetToolTip(btnReset, "WARNING: Resets all settings to default!");
            toolTipSettings.SetToolTip(btnCancel, "Discard changes and close window");

            btnTry.Visible = false;
        }

        private void WindowSettings_Load(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = Properties.Settings.Default;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();

            // apply settings
            mainWindow.WindowMain_ApplySettings();

            this.Close();
        }

        private void btnTry_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();

            // apply settings
            mainWindow.WindowMain_ApplySettings();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();

            // apply settings
            mainWindow.WindowMain_ApplySettings();

            WindowSettings_Load(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
