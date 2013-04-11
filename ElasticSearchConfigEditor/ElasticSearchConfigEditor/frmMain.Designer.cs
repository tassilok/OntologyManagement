namespace ElasticSearchConfigEditor
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView_ElasticSearch = new System.Windows.Forms.TreeView();
            this.contextMenuStrip_Tree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem_DocType = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Save = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_Config = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_ConfigItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip_Tree.SuspendLayout();
            this.toolStripContainer2.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Config)).BeginInit();
            this.contextMenuStrip_ConfigItem.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(885, 503);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(885, 553);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Close});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(52, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton_Close
            // 
            this.toolStripButton_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Close.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Close.Image")));
            this.toolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Close.Name = "toolStripButton_Close";
            this.toolStripButton_Close.Size = new System.Drawing.Size(40, 22);
            this.toolStripButton_Close.Text = "Close";
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
            this.splitContainer1.Panel1.Controls.Add(this.treeView_ElasticSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.toolStripContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(885, 503);
            this.splitContainer1.SplitterDistance = 295;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView_ElasticSearch
            // 
            this.treeView_ElasticSearch.ContextMenuStrip = this.contextMenuStrip_Tree;
            this.treeView_ElasticSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_ElasticSearch.Location = new System.Drawing.Point(0, 0);
            this.treeView_ElasticSearch.Name = "treeView_ElasticSearch";
            this.treeView_ElasticSearch.Size = new System.Drawing.Size(291, 499);
            this.treeView_ElasticSearch.TabIndex = 0;
            this.treeView_ElasticSearch.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_ElasticSearch_AfterSelect);
            // 
            // contextMenuStrip_Tree
            // 
            this.contextMenuStrip_Tree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem_DocType});
            this.contextMenuStrip_Tree.Name = "contextMenuStrip_Tree";
            this.contextMenuStrip_Tree.Size = new System.Drawing.Size(99, 26);
            this.contextMenuStrip_Tree.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Tree_Opening);
            // 
            // newToolStripMenuItem_DocType
            // 
            this.newToolStripMenuItem_DocType.Name = "newToolStripMenuItem_DocType";
            this.newToolStripMenuItem_DocType.Size = new System.Drawing.Size(98, 22);
            this.newToolStripMenuItem_DocType.Text = "New";
            this.newToolStripMenuItem_DocType.Click += new System.EventHandler(this.newToolStripMenuItem_DocType_Click);
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
            this.toolStripContainer2.ContentPanel.Controls.Add(this.dataGridView_Config);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(582, 474);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.LeftToolStripPanelVisible = false;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.RightToolStripPanelVisible = false;
            this.toolStripContainer2.Size = new System.Drawing.Size(582, 499);
            this.toolStripContainer2.TabIndex = 0;
            this.toolStripContainer2.Text = "toolStripContainer2";
            this.toolStripContainer2.TopToolStripPanelVisible = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Save});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(66, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripButton_Save
            // 
            this.toolStripButton_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Save.Enabled = false;
            this.toolStripButton_Save.Image = global::ElasticSearchConfigEditor.Properties.Resources.base_floppydisk_32;
            this.toolStripButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Save.Name = "toolStripButton_Save";
            this.toolStripButton_Save.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Save.Text = "toolStripButton1";
            this.toolStripButton_Save.Click += new System.EventHandler(this.toolStripButton_Save_Click);
            // 
            // dataGridView_Config
            // 
            this.dataGridView_Config.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Config.ContextMenuStrip = this.contextMenuStrip_ConfigItem;
            this.dataGridView_Config.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Config.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Config.Name = "dataGridView_Config";
            this.dataGridView_Config.Size = new System.Drawing.Size(582, 474);
            this.dataGridView_Config.TabIndex = 0;
            this.dataGridView_Config.EditModeChanged += new System.EventHandler(this.addColumnsToolStripMenuItem_Click);
            this.dataGridView_Config.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Config_CellValueChanged);
            this.dataGridView_Config.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_Config_RowsAdded);
            this.dataGridView_Config.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_Config_UserAddedRow);
            this.dataGridView_Config.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_Config_UserDeletedRow);
            // 
            // contextMenuStrip_ConfigItem
            // 
            this.contextMenuStrip_ConfigItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addColumnsToolStripMenuItem});
            this.contextMenuStrip_ConfigItem.Name = "contextMenuStrip_ConfigItem";
            this.contextMenuStrip_ConfigItem.Size = new System.Drawing.Size(143, 26);
            this.contextMenuStrip_ConfigItem.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_ConfigItem_Opening);
            // 
            // addColumnsToolStripMenuItem
            // 
            this.addColumnsToolStripMenuItem.Enabled = false;
            this.addColumnsToolStripMenuItem.Name = "addColumnsToolStripMenuItem";
            this.addColumnsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.addColumnsToolStripMenuItem.Text = "Add Column";
            this.addColumnsToolStripMenuItem.Click += new System.EventHandler(this.addColumnsToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 553);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmMain";
            this.Text = "Config-Editor";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip_Tree.ResumeLayout(false);
            this.toolStripContainer2.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Config)).EndInit();
            this.contextMenuStrip_ConfigItem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView_ElasticSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Tree;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem_DocType;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Save;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_ConfigItem;
        private System.Windows.Forms.ToolStripMenuItem addColumnsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView_Config;
    }
}

