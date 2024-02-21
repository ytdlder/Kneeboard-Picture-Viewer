namespace Kneeboard_Picture_Viewer
{
    partial class WindowMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowMain));
            this.tableMainWindowLayout = new System.Windows.Forms.TableLayoutPanel();
            this.flowFileNav = new System.Windows.Forms.FlowLayoutPanel();
            this.flowButtonsSettings = new System.Windows.Forms.FlowLayoutPanel();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.flowDirNav = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.tableMainWindowLayout.SuspendLayout();
            this.flowButtonsSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableMainWindowLayout
            // 
            this.tableMainWindowLayout.ColumnCount = 3;
            this.tableMainWindowLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableMainWindowLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableMainWindowLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMainWindowLayout.Controls.Add(this.flowFileNav, 1, 0);
            this.tableMainWindowLayout.Controls.Add(this.flowButtonsSettings, 0, 1);
            this.tableMainWindowLayout.Controls.Add(this.pictureBox, 2, 0);
            this.tableMainWindowLayout.Controls.Add(this.flowDirNav, 0, 0);
            this.tableMainWindowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMainWindowLayout.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableMainWindowLayout.Location = new System.Drawing.Point(0, 0);
            this.tableMainWindowLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tableMainWindowLayout.Name = "tableMainWindowLayout";
            this.tableMainWindowLayout.RowCount = 2;
            this.tableMainWindowLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMainWindowLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableMainWindowLayout.Size = new System.Drawing.Size(784, 561);
            this.tableMainWindowLayout.TabIndex = 0;
            // 
            // flowFileNav
            // 
            this.flowFileNav.AutoScroll = true;
            this.flowFileNav.AutoSize = true;
            this.flowFileNav.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowFileNav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowFileNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowFileNav.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowFileNav.Location = new System.Drawing.Point(30, 0);
            this.flowFileNav.Margin = new System.Windows.Forms.Padding(0);
            this.flowFileNav.MinimumSize = new System.Drawing.Size(30, 0);
            this.flowFileNav.Name = "flowFileNav";
            this.flowFileNav.Size = new System.Drawing.Size(30, 531);
            this.flowFileNav.TabIndex = 9;
            this.flowFileNav.WrapContents = false;
            // 
            // flowButtonsSettings
            // 
            this.flowButtonsSettings.AutoSize = true;
            this.flowButtonsSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableMainWindowLayout.SetColumnSpan(this.flowButtonsSettings, 2);
            this.flowButtonsSettings.Controls.Add(this.btnInfo);
            this.flowButtonsSettings.Controls.Add(this.btnSettings);
            this.flowButtonsSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowButtonsSettings.Location = new System.Drawing.Point(0, 531);
            this.flowButtonsSettings.Margin = new System.Windows.Forms.Padding(0);
            this.flowButtonsSettings.Name = "flowButtonsSettings";
            this.flowButtonsSettings.Size = new System.Drawing.Size(60, 30);
            this.flowButtonsSettings.TabIndex = 7;
            this.flowButtonsSettings.WrapContents = false;
            // 
            // btnInfo
            // 
            this.btnInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInfo.BackgroundImage")));
            this.btnInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInfo.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnInfo.Location = new System.Drawing.Point(0, 0);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(0);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(30, 30);
            this.btnInfo.TabIndex = 0;
            this.btnInfo.TabStop = false;
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.evtWindowMain_Help);
            // 
            // btnSettings
            // 
            this.btnSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSettings.BackgroundImage")));
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnSettings.FlatAppearance.BorderSize = 2;
            this.btnSettings.Location = new System.Drawing.Point(30, 0);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(30, 30);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.TabStop = false;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.evtBtnSettings_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Black;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(60, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.tableMainWindowLayout.SetRowSpan(this.pictureBox, 2);
            this.pictureBox.Size = new System.Drawing.Size(724, 561);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.DoubleClick += new System.EventHandler(this.evtPictureBox_DoubleClick);
            // 
            // flowDirNav
            // 
            this.flowDirNav.AutoSize = true;
            this.flowDirNav.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowDirNav.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowDirNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowDirNav.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowDirNav.Location = new System.Drawing.Point(0, 0);
            this.flowDirNav.Margin = new System.Windows.Forms.Padding(0);
            this.flowDirNav.MinimumSize = new System.Drawing.Size(30, 0);
            this.flowDirNav.Name = "flowDirNav";
            this.flowDirNav.Size = new System.Drawing.Size(30, 531);
            this.flowDirNav.TabIndex = 8;
            this.flowDirNav.WrapContents = false;
            // 
            // WindowMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableMainWindowLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "WindowMain";
            this.Text = "Kneeboard Picture Viewer";
            this.Load += new System.EventHandler(this.evtWindowMain_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.evtWindowMain_Help);
            this.Resize += new System.EventHandler(this.evtWindowMain_Resized);
            this.tableMainWindowLayout.ResumeLayout(false);
            this.tableMainWindowLayout.PerformLayout();
            this.flowButtonsSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableMainWindowLayout;
        public PictureBox pictureBox;
        private FlowLayoutPanel flowButtonsSettings;
        private Button btnInfo;
        private Button btnSettings;
        public FlowLayoutPanel flowDirNav;
        public FlowLayoutPanel flowFileNav;
        private ToolTip toolTipMain;
    }
}