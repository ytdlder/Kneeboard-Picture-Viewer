using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kneeboard_Picture_Viewer
{
    public partial class WindowSelectFolder : Form
    {
        public WindowSelectFolder()
        {
            InitializeComponent();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog SelectedFolder = new FolderBrowserDialog();
            SelectedFolder.Description = "Select the folder, in which the directories and subsequent images for the kneeboard reside.";
            SelectedFolder.ShowNewFolderButton = false;
            SelectedFolder.UseDescriptionForTitle = true;
            SelectedFolder.InitialDirectory = AppContext.BaseDirectory;

            while (SelectedFolder.SelectedPath == "" || Directory.GetDirectories(SelectedFolder.SelectedPath).Length < 1)
                SelectedFolder.ShowDialog();

            Properties.Settings.Default.Kneeboard_Images_Directory = SelectedFolder.SelectedPath;
            Properties.Settings.Default.Save();

            this.Close();
        }

        private void HelpPicture_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, HelpPicture.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
        }
    }
}
