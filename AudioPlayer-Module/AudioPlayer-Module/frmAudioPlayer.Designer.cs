namespace AudioPlayer_Module
{
    partial class frmAudioPlayer
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAudioPlayer));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_CountLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Count = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_FilterLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Filter = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_Clear = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_MediaItems = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_MediaItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xdifferentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.containsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_Contains = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_FilterText = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Filter = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_Refresh = new System.Windows.Forms.ToolStripButton();
            this.timer_Filter = new System.Windows.Forms.Timer(this.components);
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Clipboard = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripContainer2.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MediaItems)).BeginInit();
            this.contextMenuStrip_MediaItems.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(811, 347);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(811, 397);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip4);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Close});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(62, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton_Close
            // 
            this.toolStripButton_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Close.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Close.Image")));
            this.toolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Close.Name = "toolStripButton_Close";
            this.toolStripButton_Close.Size = new System.Drawing.Size(50, 22);
            this.toolStripButton_Close.Text = "x_Close";
            this.toolStripButton_Close.Click += new System.EventHandler(this.toolStripButton_Close_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStripContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(811, 347);
            this.splitContainer1.SplitterDistance = 486;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.BottomToolStripPanel
            // 
            this.toolStripContainer2.BottomToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.dataGridView_MediaItems);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(482, 293);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(482, 343);
            this.toolStripContainer2.TabIndex = 0;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.toolStrip3);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_CountLbl,
            this.toolStripLabel_Count,
            this.toolStripSeparator1,
            this.toolStripLabel_FilterLbl,
            this.toolStripLabel_Filter,
            this.toolStripButton_Clear});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(165, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripLabel_CountLbl
            // 
            this.toolStripLabel_CountLbl.Name = "toolStripLabel_CountLbl";
            this.toolStripLabel_CountLbl.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel_CountLbl.Text = "x_Count:";
            // 
            // toolStripLabel_Count
            // 
            this.toolStripLabel_Count.Name = "toolStripLabel_Count";
            this.toolStripLabel_Count.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel_Count.Text = "0";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_FilterLbl
            // 
            this.toolStripLabel_FilterLbl.Name = "toolStripLabel_FilterLbl";
            this.toolStripLabel_FilterLbl.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel_FilterLbl.Text = "x_Filter:";
            // 
            // toolStripLabel_Filter
            // 
            this.toolStripLabel_Filter.Name = "toolStripLabel_Filter";
            this.toolStripLabel_Filter.Size = new System.Drawing.Size(12, 22);
            this.toolStripLabel_Filter.Text = "-";
            // 
            // toolStripButton_Clear
            // 
            this.toolStripButton_Clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Clear.Image = global::AudioPlayer_Module.Properties.Resources.tasto_8_architetto_franc_01;
            this.toolStripButton_Clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Clear.Name = "toolStripButton_Clear";
            this.toolStripButton_Clear.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Clear.Text = "toolStripButton1";
            this.toolStripButton_Clear.Click += new System.EventHandler(this.toolStripButton_Clear_Click);
            // 
            // dataGridView_MediaItems
            // 
            this.dataGridView_MediaItems.AllowUserToAddRows = false;
            this.dataGridView_MediaItems.AllowUserToDeleteRows = false;
            this.dataGridView_MediaItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_MediaItems.ContextMenuStrip = this.contextMenuStrip_MediaItems;
            this.dataGridView_MediaItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_MediaItems.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_MediaItems.Name = "dataGridView_MediaItems";
            this.dataGridView_MediaItems.ReadOnly = true;
            this.dataGridView_MediaItems.Size = new System.Drawing.Size(482, 293);
            this.dataGridView_MediaItems.TabIndex = 0;
            this.dataGridView_MediaItems.SelectionChanged += new System.EventHandler(this.dataGridView_MediaItems_SelectionChanged);
            // 
            // contextMenuStrip_MediaItems
            // 
            this.contextMenuStrip_MediaItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterToolStripMenuItem});
            this.contextMenuStrip_MediaItems.Name = "contextMenuStrip_MediaItems";
            this.contextMenuStrip_MediaItems.Size = new System.Drawing.Size(111, 26);
            this.contextMenuStrip_MediaItems.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_MediaItems_Opening);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.equalToolStripMenuItem,
            this.xdifferentToolStripMenuItem,
            this.containsToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.filterToolStripMenuItem.Text = "x_Filter";
            // 
            // equalToolStripMenuItem
            // 
            this.equalToolStripMenuItem.Name = "equalToolStripMenuItem";
            this.equalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.equalToolStripMenuItem.Text = "x_equal";
            this.equalToolStripMenuItem.Click += new System.EventHandler(this.equalToolStripMenuItem_Click);
            // 
            // xdifferentToolStripMenuItem
            // 
            this.xdifferentToolStripMenuItem.Name = "xdifferentToolStripMenuItem";
            this.xdifferentToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.xdifferentToolStripMenuItem.Text = "x_different";
            this.xdifferentToolStripMenuItem.Click += new System.EventHandler(this.xdifferentToolStripMenuItem_Click);
            // 
            // containsToolStripMenuItem
            // 
            this.containsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_Contains});
            this.containsToolStripMenuItem.Name = "containsToolStripMenuItem";
            this.containsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.containsToolStripMenuItem.Text = "x_contains";
            // 
            // toolStripTextBox_Contains
            // 
            this.toolStripTextBox_Contains.Name = "toolStripTextBox_Contains";
            this.toolStripTextBox_Contains.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox_Contains.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox_Contains_KeyDown);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_FilterText,
            this.toolStripTextBox_Filter,
            this.toolStripButton_Refresh});
            this.toolStrip3.Location = new System.Drawing.Point(3, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(383, 25);
            this.toolStrip3.TabIndex = 0;
            // 
            // toolStripLabel_FilterText
            // 
            this.toolStripLabel_FilterText.Name = "toolStripLabel_FilterText";
            this.toolStripLabel_FilterText.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel_FilterText.Text = "x_Filter:";
            // 
            // toolStripTextBox_Filter
            // 
            this.toolStripTextBox_Filter.Name = "toolStripTextBox_Filter";
            this.toolStripTextBox_Filter.Size = new System.Drawing.Size(300, 25);
            this.toolStripTextBox_Filter.TextChanged += new System.EventHandler(this.toolStripTextBox_Filter_TextChanged);
            // 
            // toolStripButton_Refresh
            // 
            this.toolStripButton_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Refresh.Image = global::AudioPlayer_Module.Properties.Resources.sync;
            this.toolStripButton_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Refresh.Name = "toolStripButton_Refresh";
            this.toolStripButton_Refresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Refresh.Text = "toolStripButton1";
            this.toolStripButton_Refresh.Click += new System.EventHandler(this.toolStripButton_Refresh_Click);
            // 
            // timer_Filter
            // 
            this.timer_Filter.Interval = 300;
            this.timer_Filter.Tick += new System.EventHandler(this.timer_Filter_Tick);
            // 
            // toolStrip4
            // 
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Clipboard});
            this.toolStrip4.Location = new System.Drawing.Point(3, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(225, 25);
            this.toolStrip4.TabIndex = 0;
            // 
            // toolStripButton_Clipboard
            // 
            this.toolStripButton_Clipboard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Clipboard.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Clipboard.Image")));
            this.toolStripButton_Clipboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Clipboard.Name = "toolStripButton_Clipboard";
            this.toolStripButton_Clipboard.Size = new System.Drawing.Size(182, 22);
            this.toolStripButton_Clipboard.Text = "x_Determine Clipboard Relations";
            this.toolStripButton_Clipboard.Click += new System.EventHandler(this.toolStripButton_Clipboard_Click);
            // 
            // frmAudioPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 397);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmAudioPlayer";
            this.Text = "x_Audio-Player";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripContainer2.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MediaItems)).EndInit();
            this.contextMenuStrip_MediaItems.ResumeLayout(false);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.DataGridView dataGridView_MediaItems;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_CountLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Count;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_FilterLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Filter;
        private System.Windows.Forms.ToolStripButton toolStripButton_Clear;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_MediaItems;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xdifferentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem containsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Contains;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_FilterText;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Filter;
        private System.Windows.Forms.Timer timer_Filter;
        private System.Windows.Forms.ToolStripButton toolStripButton_Refresh;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton toolStripButton_Clipboard;

    }
}

