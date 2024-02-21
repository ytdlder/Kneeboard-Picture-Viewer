namespace Kneeboard_Picture_Viewer
{
    partial class WindowSelectFolder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowSelectFolder));
            this.HelpPicture = new System.Windows.Forms.PictureBox();
            this.HelpText = new System.Windows.Forms.TextBox();
            this.btnContinue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HelpPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // HelpPicture
            // 
            this.HelpPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.HelpPicture.Cursor = System.Windows.Forms.Cursors.No;
            this.HelpPicture.Image = global::Kneeboard_Picture_Viewer.Properties.Resources.select_folder_help;
            this.HelpPicture.InitialImage = global::Kneeboard_Picture_Viewer.Properties.Resources.select_folder_help;
            this.HelpPicture.Location = new System.Drawing.Point(10, 10);
            this.HelpPicture.Name = "HelpPicture";
            this.HelpPicture.Size = new System.Drawing.Size(652, 400);
            this.HelpPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.HelpPicture.TabIndex = 0;
            this.HelpPicture.TabStop = false;
            this.HelpPicture.WaitOnLoad = true;
            this.HelpPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.HelpPicture_Paint);
            // 
            // HelpText
            // 
            this.HelpText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HelpText.Cursor = System.Windows.Forms.Cursors.Help;
            this.HelpText.Location = new System.Drawing.Point(10, 415);
            this.HelpText.Multiline = true;
            this.HelpText.Name = "HelpText";
            this.HelpText.ReadOnly = true;
            this.HelpText.ShortcutsEnabled = false;
            this.HelpText.Size = new System.Drawing.Size(652, 71);
            this.HelpText.TabIndex = 1;
            this.HelpText.TabStop = false;
            this.HelpText.Text = resources.GetString("HelpText.Text");
            // 
            // btnContinue
            // 
            this.btnContinue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnContinue.Location = new System.Drawing.Point(229, 492);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(214, 25);
            this.btnContinue.TabIndex = 2;
            this.btnContinue.Text = "&Continue to the folder-select dialog...";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // WindowSelectFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 524);
            this.ControlBox = false;
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.HelpText);
            this.Controls.Add(this.HelpPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WindowSelectFolder";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Info";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.HelpPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox HelpPicture;
        private TextBox HelpText;
        private Button btnContinue;
    }
}