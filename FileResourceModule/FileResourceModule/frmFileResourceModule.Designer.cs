namespace FileResourceModule
{
    partial class frmFileResourceModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileResourceModule));
            this.ToolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage_File = new System.Windows.Forms.TabPage();
            this.TabPage_Path = new System.Windows.Forms.TabPage();
            this.TabPage_WebConnection = new System.Windows.Forms.TabPage();
            this.ToolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.ToolStripContainer1.ContentPanel.SuspendLayout();
            this.ToolStripContainer1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStripContainer1
            // 
            // 
            // ToolStripContainer1.BottomToolStripPanel
            // 
            this.ToolStripContainer1.BottomToolStripPanel.Controls.Add(this.ToolStrip1);
            // 
            // ToolStripContainer1.ContentPanel
            // 
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.SplitContainer1);
            this.ToolStripContainer1.ContentPanel.Size = new System.Drawing.Size(651, 366);
            this.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer1.Name = "ToolStripContainer1";
            this.ToolStripContainer1.Size = new System.Drawing.Size(651, 416);
            this.ToolStripContainer1.TabIndex = 1;
            this.ToolStripContainer1.Text = "ToolStripContainer1";
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButton_Close});
            this.ToolStrip1.Location = new System.Drawing.Point(3, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(62, 25);
            this.ToolStrip1.TabIndex = 0;
            // 
            // ToolStripButton_Close
            // 
            this.ToolStripButton_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButton_Close.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Close.Image")));
            this.ToolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Close.Name = "ToolStripButton_Close";
            this.ToolStripButton_Close.Size = new System.Drawing.Size(50, 22);
            this.ToolStripButton_Close.Text = "x_Close";
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.TabControl1);
            this.SplitContainer1.Size = new System.Drawing.Size(651, 366);
            this.SplitContainer1.SplitterDistance = 216;
            this.SplitContainer1.TabIndex = 0;
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage_File);
            this.TabControl1.Controls.Add(this.TabPage_Path);
            this.TabControl1.Controls.Add(this.TabPage_WebConnection);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(427, 362);
            this.TabControl1.TabIndex = 0;
            // 
            // TabPage_File
            // 
            this.TabPage_File.Location = new System.Drawing.Point(4, 22);
            this.TabPage_File.Name = "TabPage_File";
            this.TabPage_File.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_File.Size = new System.Drawing.Size(419, 336);
            this.TabPage_File.TabIndex = 0;
            this.TabPage_File.Text = "x_File";
            this.TabPage_File.UseVisualStyleBackColor = true;
            // 
            // TabPage_Path
            // 
            this.TabPage_Path.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Path.Name = "TabPage_Path";
            this.TabPage_Path.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Path.Size = new System.Drawing.Size(345, 380);
            this.TabPage_Path.TabIndex = 1;
            this.TabPage_Path.Text = "x_Path";
            this.TabPage_Path.UseVisualStyleBackColor = true;
            // 
            // TabPage_WebConnection
            // 
            this.TabPage_WebConnection.Location = new System.Drawing.Point(4, 22);
            this.TabPage_WebConnection.Name = "TabPage_WebConnection";
            this.TabPage_WebConnection.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_WebConnection.Size = new System.Drawing.Size(345, 380);
            this.TabPage_WebConnection.TabIndex = 2;
            this.TabPage_WebConnection.Text = "x_Web-Connection";
            this.TabPage_WebConnection.UseVisualStyleBackColor = true;
            // 
            // frmFileResourceModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 416);
            this.Controls.Add(this.ToolStripContainer1);
            this.Name = "frmFileResourceModule";
            this.Text = "x-FileResources";
            this.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.ToolStripContainer1.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer1.ResumeLayout(false);
            this.ToolStripContainer1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.TabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolStripContainer ToolStripContainer1;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_Close;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage_File;
        internal System.Windows.Forms.TabPage TabPage_Path;
        internal System.Windows.Forms.TabPage TabPage_WebConnection;
    }
}

