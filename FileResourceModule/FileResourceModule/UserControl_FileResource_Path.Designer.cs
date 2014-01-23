namespace FileResourceModule
{
    partial class UserControl_FileResource_Path
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_FileResource_Path));
            this.Timer_LineCount = new System.Windows.Forms.Timer(this.components);
            this.ToolStripButton_Open = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.XCountLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuStrip_Files = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DataGridView_Files = new System.Windows.Forms.DataGridView();
            this.ToolStripProgressBar_LineCount = new System.Windows.Forms.ToolStripProgressBar();
            this.ToolStripLabel_LineCount = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripLabel_LineCountLbl = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Timer_Files = new System.Windows.Forms.Timer(this.components);
            this.ToolStripLabel_Count = new System.Windows.Forms.ToolStripLabel();
            this.ToolStrip2 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButton_CountLbl = new System.Windows.Forms.ToolStripButton();
            this.ProgressBar_Files = new System.Windows.Forms.ProgressBar();
            this.Button_Search = new System.Windows.Forms.Button();
            this.CheckBox_SubItems = new System.Windows.Forms.CheckBox();
            this.TextBox_Pattern = new System.Windows.Forms.TextBox();
            this.Label_Pattern = new System.Windows.Forms.Label();
            this.Button_AddPath = new System.Windows.Forms.Button();
            this.TextBox_Path = new System.Windows.Forms.TextBox();
            this.Label_Path = new System.Windows.Forms.Label();
            this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ToolStrip1.SuspendLayout();
            this.ToolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer1.SuspendLayout();
            this.ContextMenuStrip_Files.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Files)).BeginInit();
            this.ToolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).BeginInit();
            this.SplitContainer2.Panel1.SuspendLayout();
            this.SplitContainer2.Panel2.SuspendLayout();
            this.SplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer_LineCount
            // 
            this.Timer_LineCount.Interval = 300;
            this.Timer_LineCount.Tick += new System.EventHandler(this.Timer_LineCount_Tick);
            // 
            // ToolStripButton_Open
            // 
            this.ToolStripButton_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButton_Open.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Open.Image")));
            this.ToolStripButton_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Open.Name = "ToolStripButton_Open";
            this.ToolStripButton_Open.Size = new System.Drawing.Size(50, 22);
            this.ToolStripButton_Open.Text = "x_Open";
            this.ToolStripButton_Open.Click += new System.EventHandler(this.ToolStripButton_Open_Click);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButton_Open});
            this.ToolStrip1.Location = new System.Drawing.Point(3, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(62, 25);
            this.ToolStrip1.TabIndex = 0;
            // 
            // ToolStripContainer1
            // 
            // 
            // ToolStripContainer1.ContentPanel
            // 
            this.ToolStripContainer1.ContentPanel.Size = new System.Drawing.Size(691, 246);
            this.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer1.Name = "ToolStripContainer1";
            this.ToolStripContainer1.Size = new System.Drawing.Size(691, 271);
            this.ToolStripContainer1.TabIndex = 0;
            this.ToolStripContainer1.Text = "ToolStripContainer1";
            // 
            // ToolStripContainer1.TopToolStripPanel
            // 
            this.ToolStripContainer1.TopToolStripPanel.Controls.Add(this.ToolStrip1);
            // 
            // XCountLineToolStripMenuItem
            // 
            this.XCountLineToolStripMenuItem.Name = "XCountLineToolStripMenuItem";
            this.XCountLineToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.XCountLineToolStripMenuItem.Text = "x_Count Lines";
            // 
            // ContextMenuStrip_Files
            // 
            this.ContextMenuStrip_Files.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.XCountLineToolStripMenuItem});
            this.ContextMenuStrip_Files.Name = "ContextMenuStrip_Files";
            this.ContextMenuStrip_Files.Size = new System.Drawing.Size(148, 26);
            // 
            // DataGridView_Files
            // 
            this.DataGridView_Files.AllowUserToAddRows = false;
            this.DataGridView_Files.AllowUserToDeleteRows = false;
            this.DataGridView_Files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_Files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Files.ContextMenuStrip = this.ContextMenuStrip_Files;
            this.DataGridView_Files.Location = new System.Drawing.Point(0, 0);
            this.DataGridView_Files.Name = "DataGridView_Files";
            this.DataGridView_Files.ReadOnly = true;
            this.DataGridView_Files.Size = new System.Drawing.Size(343, 183);
            this.DataGridView_Files.TabIndex = 0;
            this.DataGridView_Files.SelectionChanged += new System.EventHandler(this.DataGridView_Files_SelectionChanged);
            // 
            // ToolStripProgressBar_LineCount
            // 
            this.ToolStripProgressBar_LineCount.Name = "ToolStripProgressBar_LineCount";
            this.ToolStripProgressBar_LineCount.Size = new System.Drawing.Size(100, 22);
            // 
            // ToolStripLabel_LineCount
            // 
            this.ToolStripLabel_LineCount.Name = "ToolStripLabel_LineCount";
            this.ToolStripLabel_LineCount.Size = new System.Drawing.Size(13, 22);
            this.ToolStripLabel_LineCount.Text = "0";
            // 
            // ToolStripLabel_LineCountLbl
            // 
            this.ToolStripLabel_LineCountLbl.Name = "ToolStripLabel_LineCountLbl";
            this.ToolStripLabel_LineCountLbl.Size = new System.Drawing.Size(47, 22);
            this.ToolStripLabel_LineCountLbl.Text = "x-Lines:";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Timer_Files
            // 
            this.Timer_Files.Interval = 300;
            this.Timer_Files.Tick += new System.EventHandler(this.Timer_Files_Tick);
            // 
            // ToolStripLabel_Count
            // 
            this.ToolStripLabel_Count.Name = "ToolStripLabel_Count";
            this.ToolStripLabel_Count.Size = new System.Drawing.Size(13, 22);
            this.ToolStripLabel_Count.Text = "0";
            // 
            // ToolStrip2
            // 
            this.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButton_CountLbl,
            this.ToolStripLabel_Count,
            this.ToolStripSeparator1,
            this.ToolStripLabel_LineCountLbl,
            this.ToolStripLabel_LineCount,
            this.ToolStripProgressBar_LineCount});
            this.ToolStrip2.Location = new System.Drawing.Point(0, 186);
            this.ToolStrip2.Name = "ToolStrip2";
            this.ToolStrip2.Size = new System.Drawing.Size(343, 25);
            this.ToolStrip2.TabIndex = 1;
            this.ToolStrip2.Text = "ToolStrip2";
            // 
            // ToolStripButton_CountLbl
            // 
            this.ToolStripButton_CountLbl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButton_CountLbl.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_CountLbl.Image")));
            this.ToolStripButton_CountLbl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_CountLbl.Name = "ToolStripButton_CountLbl";
            this.ToolStripButton_CountLbl.Size = new System.Drawing.Size(57, 22);
            this.ToolStripButton_CountLbl.Text = "x_Count:";
            // 
            // ProgressBar_Files
            // 
            this.ProgressBar_Files.Location = new System.Drawing.Point(147, 75);
            this.ProgressBar_Files.Name = "ProgressBar_Files";
            this.ProgressBar_Files.Size = new System.Drawing.Size(91, 23);
            this.ProgressBar_Files.TabIndex = 7;
            // 
            // Button_Search
            // 
            this.Button_Search.Location = new System.Drawing.Point(65, 75);
            this.Button_Search.Name = "Button_Search";
            this.Button_Search.Size = new System.Drawing.Size(75, 23);
            this.Button_Search.TabIndex = 6;
            this.Button_Search.Text = "x_Search";
            this.Button_Search.UseVisualStyleBackColor = true;
            this.Button_Search.Click += new System.EventHandler(this.Button_Search_Click);
            // 
            // CheckBox_SubItems
            // 
            this.CheckBox_SubItems.AutoSize = true;
            this.CheckBox_SubItems.Location = new System.Drawing.Point(65, 52);
            this.CheckBox_SubItems.Name = "CheckBox_SubItems";
            this.CheckBox_SubItems.Size = new System.Drawing.Size(81, 17);
            this.CheckBox_SubItems.TabIndex = 5;
            this.CheckBox_SubItems.Text = "x_SubItems";
            this.CheckBox_SubItems.UseVisualStyleBackColor = true;
            // 
            // TextBox_Pattern
            // 
            this.TextBox_Pattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Pattern.Location = new System.Drawing.Point(65, 25);
            this.TextBox_Pattern.Name = "TextBox_Pattern";
            this.TextBox_Pattern.Size = new System.Drawing.Size(242, 20);
            this.TextBox_Pattern.TabIndex = 4;
            // 
            // Label_Pattern
            // 
            this.Label_Pattern.AutoSize = true;
            this.Label_Pattern.Location = new System.Drawing.Point(4, 28);
            this.Label_Pattern.Name = "Label_Pattern";
            this.Label_Pattern.Size = new System.Drawing.Size(55, 13);
            this.Label_Pattern.TabIndex = 3;
            this.Label_Pattern.Text = "x_Pattern:";
            // 
            // Button_AddPath
            // 
            this.Button_AddPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_AddPath.Location = new System.Drawing.Point(311, 3);
            this.Button_AddPath.Name = "Button_AddPath";
            this.Button_AddPath.Size = new System.Drawing.Size(26, 23);
            this.Button_AddPath.TabIndex = 2;
            this.Button_AddPath.Text = "...+";
            this.Button_AddPath.UseVisualStyleBackColor = true;
            // 
            // TextBox_Path
            // 
            this.TextBox_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Path.Location = new System.Drawing.Point(65, 4);
            this.TextBox_Path.Name = "TextBox_Path";
            this.TextBox_Path.ReadOnly = true;
            this.TextBox_Path.Size = new System.Drawing.Size(242, 20);
            this.TextBox_Path.TabIndex = 1;
            // 
            // Label_Path
            // 
            this.Label_Path.AutoSize = true;
            this.Label_Path.Location = new System.Drawing.Point(4, 7);
            this.Label_Path.Name = "Label_Path";
            this.Label_Path.Size = new System.Drawing.Size(43, 13);
            this.Label_Path.TabIndex = 0;
            this.Label_Path.Text = "x_Path:";
            // 
            // SplitContainer2
            // 
            this.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer2.Name = "SplitContainer2";
            // 
            // SplitContainer2.Panel1
            // 
            this.SplitContainer2.Panel1.Controls.Add(this.ProgressBar_Files);
            this.SplitContainer2.Panel1.Controls.Add(this.Button_Search);
            this.SplitContainer2.Panel1.Controls.Add(this.CheckBox_SubItems);
            this.SplitContainer2.Panel1.Controls.Add(this.TextBox_Pattern);
            this.SplitContainer2.Panel1.Controls.Add(this.Label_Pattern);
            this.SplitContainer2.Panel1.Controls.Add(this.Button_AddPath);
            this.SplitContainer2.Panel1.Controls.Add(this.TextBox_Path);
            this.SplitContainer2.Panel1.Controls.Add(this.Label_Path);
            // 
            // SplitContainer2.Panel2
            // 
            this.SplitContainer2.Panel2.Controls.Add(this.ToolStrip2);
            this.SplitContainer2.Panel2.Controls.Add(this.DataGridView_Files);
            this.SplitContainer2.Size = new System.Drawing.Size(695, 215);
            this.SplitContainer2.SplitterDistance = 344;
            this.SplitContainer2.TabIndex = 0;
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.SplitContainer2);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.ToolStripContainer1);
            this.SplitContainer1.Size = new System.Drawing.Size(695, 494);
            this.SplitContainer1.SplitterDistance = 215;
            this.SplitContainer1.TabIndex = 1;
            // 
            // UserControl_FileResource_Path
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitContainer1);
            this.Name = "UserControl_FileResource_Path";
            this.Size = new System.Drawing.Size(695, 494);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ToolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer1.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer1.ResumeLayout(false);
            this.ToolStripContainer1.PerformLayout();
            this.ContextMenuStrip_Files.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Files)).EndInit();
            this.ToolStrip2.ResumeLayout(false);
            this.ToolStrip2.PerformLayout();
            this.SplitContainer2.Panel1.ResumeLayout(false);
            this.SplitContainer2.Panel1.PerformLayout();
            this.SplitContainer2.Panel2.ResumeLayout(false);
            this.SplitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).EndInit();
            this.SplitContainer2.ResumeLayout(false);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Timer Timer_LineCount;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_Open;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripContainer ToolStripContainer1;
        internal System.Windows.Forms.ToolStripMenuItem XCountLineToolStripMenuItem;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip_Files;
        internal System.Windows.Forms.DataGridView DataGridView_Files;
        internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar_LineCount;
        internal System.Windows.Forms.ToolStripLabel ToolStripLabel_LineCount;
        internal System.Windows.Forms.ToolStripLabel ToolStripLabel_LineCountLbl;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.Timer Timer_Files;
        internal System.Windows.Forms.ToolStripLabel ToolStripLabel_Count;
        internal System.Windows.Forms.ToolStrip ToolStrip2;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_CountLbl;
        internal System.Windows.Forms.ProgressBar ProgressBar_Files;
        internal System.Windows.Forms.Button Button_Search;
        internal System.Windows.Forms.CheckBox CheckBox_SubItems;
        internal System.Windows.Forms.TextBox TextBox_Pattern;
        internal System.Windows.Forms.Label Label_Pattern;
        internal System.Windows.Forms.Button Button_AddPath;
        internal System.Windows.Forms.TextBox TextBox_Path;
        internal System.Windows.Forms.Label Label_Path;
        internal System.Windows.Forms.SplitContainer SplitContainer2;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
    }
}
