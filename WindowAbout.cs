using System.Reflection;

namespace Kneeboard_Picture_Viewer
{
    partial class WindowAbout : Form
    {
        public WindowAbout()
        {
            InitializeComponent();
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = "v1.0.2";
            this.labelCopyright.Text = AssemblyCopyright;
            
            Assembly assembly = Assembly.GetExecutingAssembly();

            string resFileName = "Kneeboard_Picture_Viewer.Resources.readme.rtf";
            using (Stream creditStream = assembly.GetManifestResourceStream(resFileName))
            {
                this.richTextBox.LoadFile(creditStream, RichTextBoxStreamType.RichText);
            }
        }

        #region Assembly Attribute Accessors

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", e.LinkText);
        }
    }
}
