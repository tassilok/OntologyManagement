namespace Office_Module
{
    partial class frmOfficeModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOfficeModule));
            this.ContextMenuStrip_Tree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageList_RelatedItems = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.ToolStrip2 = new System.Windows.Forms.ToolStrip();
            this.ToolStripLabel_ItemCountLBL = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripLabel_ItemCount = new System.Windows.Forms.ToolStripLabel();
            this.treeView_Items = new System.Windows.Forms.TreeView();
            this.ToolStrip3 = new System.Windows.Forms.ToolStrip();
            this.ToolStripComboBox_Filter = new System.Windows.Forms.ToolStripComboBox();
            this.ToolStripTextBox_Filter = new System.Windows.Forms.ToolStripTextBox();
            this.ToolStripButton_Filter = new System.Windows.Forms.ToolStripButton();
            this.ContextMenuStrip_Tree.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripContainer2.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.ToolStrip2.SuspendLayout();
            this.ToolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContextMenuStrip_Tree
            // 
            this.ContextMenuStrip_Tree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem});
            this.ContextMenuStrip_Tree.Name = "ContextMenuStrip_Tree";
            this.ContextMenuStrip_Tree.Size = new System.Drawing.Size(109, 26);
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.NewToolStripMenuItem.Text = "x_New";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // ImageList_RelatedItems
            // 
            this.ImageList_RelatedItems.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList_RelatedItems.ImageStream")));
            this.ImageList_RelatedItems.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList_RelatedItems.Images.SetKeyName(0, "bb_home_.png");
            this.ImageList_RelatedItems.Images.SetKeyName(1, "Types_Closed.png");
            this.ImageList_RelatedItems.Images.SetKeyName(2, "Types_Closed SubItems.png");
            this.ImageList_RelatedItems.Images.SetKeyName(3, "Types_Closed Images.png");
            this.ImageList_RelatedItems.Images.SetKeyName(4, "Types_Closed SubItems Image.png");
            this.ImageList_RelatedItems.Images.SetKeyName(5, "Types_Opened.png");
            this.ImageList_RelatedItems.Images.SetKeyName(6, "Types_Opened SubItems.png");
            this.ImageList_RelatedItems.Images.SetKeyName(7, "Types_Opened Image.png");
            this.ImageList_RelatedItems.Images.SetKeyName(8, "Types_Opened SubItems Image.png");
            this.ImageList_RelatedItems.Images.SetKeyName(9, "Attributes bamboo_danny_allen_r.png");
            this.ImageList_RelatedItems.Images.SetKeyName(10, "RelationTypes gpride_jean_victor_balin_.png");
            this.ImageList_RelatedItems.Images.SetKeyName(11, "Vogelschwarm klein.png");
            this.ImageList_RelatedItems.Images.SetKeyName(12, "Attributes bamboo_danny_allen_r.png");
            this.ImageList_RelatedItems.Images.SetKeyName(13, "RelationTypes gpride_jean_victor_balin_.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(785, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "&Hilfe";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.infoToolStripMenuItem.Text = "&Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(785, 441);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(785, 491);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
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
            this.splitContainer1.Size = new System.Drawing.Size(785, 441);
            this.splitContainer1.SplitterDistance = 485;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.BottomToolStripPanel
            // 
            this.toolStripContainer2.BottomToolStripPanel.Controls.Add(this.ToolStrip2);
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.treeView_Items);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(481, 387);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(481, 437);
            this.toolStripContainer2.TabIndex = 0;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.ToolStrip3);
            // 
            // ToolStrip2
            // 
            this.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripLabel_ItemCountLBL,
            this.ToolStripLabel_ItemCount});
            this.ToolStrip2.Location = new System.Drawing.Point(3, 0);
            this.ToolStrip2.Name = "ToolStrip2";
            this.ToolStrip2.Size = new System.Drawing.Size(78, 25);
            this.ToolStrip2.TabIndex = 1;
            // 
            // ToolStripLabel_ItemCountLBL
            // 
            this.ToolStripLabel_ItemCountLBL.Name = "ToolStripLabel_ItemCountLBL";
            this.ToolStripLabel_ItemCountLBL.Size = new System.Drawing.Size(53, 22);
            this.ToolStripLabel_ItemCountLBL.Text = "x_Count:";
            // 
            // ToolStripLabel_ItemCount
            // 
            this.ToolStripLabel_ItemCount.Name = "ToolStripLabel_ItemCount";
            this.ToolStripLabel_ItemCount.Size = new System.Drawing.Size(13, 22);
            this.ToolStripLabel_ItemCount.Text = "0";
            // 
            // treeView_Items
            // 
            this.treeView_Items.ContextMenuStrip = this.ContextMenuStrip_Tree;
            this.treeView_Items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Items.ImageIndex = 0;
            this.treeView_Items.ImageList = this.ImageList_RelatedItems;
            this.treeView_Items.Location = new System.Drawing.Point(0, 0);
            this.treeView_Items.Name = "treeView_Items";
            this.treeView_Items.SelectedImageIndex = 0;
            this.treeView_Items.Size = new System.Drawing.Size(481, 387);
            this.treeView_Items.TabIndex = 0;
            this.treeView_Items.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Items_AfterSelect);
            // 
            // ToolStrip3
            // 
            this.ToolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripComboBox_Filter,
            this.ToolStripTextBox_Filter,
            this.ToolStripButton_Filter});
            this.ToolStrip3.Location = new System.Drawing.Point(3, 0);
            this.ToolStrip3.Name = "ToolStrip3";
            this.ToolStrip3.Size = new System.Drawing.Size(434, 25);
            this.ToolStrip3.TabIndex = 1;
            // 
            // ToolStripComboBox_Filter
            // 
            this.ToolStripComboBox_Filter.Name = "ToolStripComboBox_Filter";
            this.ToolStripComboBox_Filter.Size = new System.Drawing.Size(121, 25);
            // 
            // ToolStripTextBox_Filter
            // 
            this.ToolStripTextBox_Filter.Name = "ToolStripTextBox_Filter";
            this.ToolStripTextBox_Filter.Size = new System.Drawing.Size(250, 25);
            // 
            // ToolStripButton_Filter
            // 
            this.ToolStripButton_Filter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButton_Filter.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Filter.Image")));
            this.ToolStripButton_Filter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Filter.Name = "ToolStripButton_Filter";
            this.ToolStripButton_Filter.Size = new System.Drawing.Size(47, 22);
            this.ToolStripButton_Filter.Text = "x_Filter";
            // 
            // frmOfficeModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 515);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOfficeModule";
            this.Text = "x_Office Module";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmOfficeModule_MouseMove);
            this.ContextMenuStrip_Tree.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
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
            this.ToolStrip2.ResumeLayout(false);
            this.ToolStrip2.PerformLayout();
            this.ToolStrip3.ResumeLayout(false);
            this.ToolStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip_Tree;
        internal System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        internal System.Windows.Forms.ImageList ImageList_RelatedItems;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        internal System.Windows.Forms.ToolStrip ToolStrip2;
        internal System.Windows.Forms.ToolStripLabel ToolStripLabel_ItemCountLBL;
        internal System.Windows.Forms.ToolStripLabel ToolStripLabel_ItemCount;
        private System.Windows.Forms.TreeView treeView_Items;
        internal System.Windows.Forms.ToolStrip ToolStrip3;
        internal System.Windows.Forms.ToolStripComboBox ToolStripComboBox_Filter;
        internal System.Windows.Forms.ToolStripTextBox ToolStripTextBox_Filter;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_Filter;
    }
}

