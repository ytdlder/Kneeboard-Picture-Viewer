namespace Kneeboard_Picture_Viewer
{
    partial class WindowSettings
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanelSettings = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.btnTry = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTipSettings = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanelSettings.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelSettings
            // 
            this.tableLayoutPanelSettings.ColumnCount = 3;
            this.tableLayoutPanelSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanelSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSettings.Controls.Add(this.btnSave, 0, 1);
            this.tableLayoutPanelSettings.Controls.Add(this.propertyGrid, 0, 0);
            this.tableLayoutPanelSettings.Controls.Add(this.btnCancel, 2, 1);
            this.tableLayoutPanelSettings.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSettings.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelSettings.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelSettings.Name = "tableLayoutPanelSettings";
            this.tableLayoutPanelSettings.RowCount = 2;
            this.tableLayoutPanelSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelSettings.Size = new System.Drawing.Size(484, 361);
            this.tableLayoutPanelSettings.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(43, 334);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // propertyGrid
            // 
            this.tableLayoutPanelSettings.SetColumnSpan(this.propertyGrid, 3);
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.HelpVisible = false;
            this.propertyGrid.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(478, 325);
            this.propertyGrid.TabIndex = 2;
            this.propertyGrid.TabStop = false;
            // 
            // btnTry
            // 
            this.btnTry.Location = new System.Drawing.Point(3, 3);
            this.btnTry.Name = "btnTry";
            this.btnTry.Size = new System.Drawing.Size(75, 24);
            this.btnTry.TabIndex = 2;
            this.btnTry.Text = "&Try";
            this.btnTry.UseVisualStyleBackColor = true;
            this.btnTry.Click += new System.EventHandler(this.btnTry_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(84, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 24);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(366, 334);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.btnTry);
            this.flowLayoutPanel1.Controls.Add(this.btnReset);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(161, 331);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(162, 30);
            this.flowLayoutPanel1.TabIndex = 5;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // WindowSettings
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.tableLayoutPanelSettings);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "WindowSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.WindowSettings_Load);
            this.tableLayoutPanelSettings.ResumeLayout(false);
            this.tableLayoutPanelSettings.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanelSettings;
        private Button btnSave;
        private Button btnCancel;
        private PropertyGrid propertyGrid;
        private ToolTip toolTipSettings;
        private Button btnTry;
        private Button btnReset;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}