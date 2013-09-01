namespace Scenes_Literatur_Module
{
    partial class UserControl_SceneTree
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_SceneTree));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_ScenesCountLBL = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_SceneCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_FoundLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Found = new System.Windows.Forms.ToolStripLabel();
            this.treeView_SceneTree = new System.Windows.Forms.TreeView();
            this.contextMenuStrip_Tree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.winwordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBelongingDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertBookmarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activateBookmarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageList_SceneTree = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox_SearchTemplates = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox_Search = new System.Windows.Forms.ToolStripTextBox();
            this.ToolStripButton_ClearSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_GetRel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Search = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip_Tree.SuspendLayout();
            this.toolStrip2.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.treeView_SceneTree);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(572, 409);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(572, 459);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_ScenesCountLBL,
            this.toolStripLabel_SceneCount,
            this.toolStripSeparator1,
            this.toolStripLabel_FoundLbl,
            this.toolStripLabel_Found});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(198, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel_ScenesCountLBL
            // 
            this.toolStripLabel_ScenesCountLBL.Name = "toolStripLabel_ScenesCountLBL";
            this.toolStripLabel_ScenesCountLBL.Size = new System.Drawing.Size(100, 22);
            this.toolStripLabel_ScenesCountLBL.Text = "x_Scenes (Count):";
            // 
            // toolStripLabel_SceneCount
            // 
            this.toolStripLabel_SceneCount.Name = "toolStripLabel_SceneCount";
            this.toolStripLabel_SceneCount.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel_SceneCount.Text = "0";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_FoundLbl
            // 
            this.toolStripLabel_FoundLbl.Name = "toolStripLabel_FoundLbl";
            this.toolStripLabel_FoundLbl.Size = new System.Drawing.Size(54, 22);
            this.toolStripLabel_FoundLbl.Text = "x_Found:";
            // 
            // toolStripLabel_Found
            // 
            this.toolStripLabel_Found.Name = "toolStripLabel_Found";
            this.toolStripLabel_Found.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel_Found.Text = "0";
            // 
            // treeView_SceneTree
            // 
            this.treeView_SceneTree.ContextMenuStrip = this.contextMenuStrip_Tree;
            this.treeView_SceneTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_SceneTree.HideSelection = false;
            this.treeView_SceneTree.ImageIndex = 0;
            this.treeView_SceneTree.ImageList = this.ImageList_SceneTree;
            this.treeView_SceneTree.Location = new System.Drawing.Point(0, 0);
            this.treeView_SceneTree.Name = "treeView_SceneTree";
            this.treeView_SceneTree.SelectedImageIndex = 0;
            this.treeView_SceneTree.Size = new System.Drawing.Size(572, 409);
            this.treeView_SceneTree.TabIndex = 0;
            this.treeView_SceneTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_SceneTree_AfterSelect);
            // 
            // contextMenuStrip_Tree
            // 
            this.contextMenuStrip_Tree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.winwordToolStripMenuItem,
            this.applyToolStripMenuItem});
            this.contextMenuStrip_Tree.Name = "contextMenuStrip_Tree";
            this.contextMenuStrip_Tree.Size = new System.Drawing.Size(153, 114);
            this.contextMenuStrip_Tree.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Tree_Opening);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "x_New";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeToolStripMenuItem.Text = "x_Remove";
            // 
            // winwordToolStripMenuItem
            // 
            this.winwordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openBelongingDocToolStripMenuItem,
            this.insertBookmarkToolStripMenuItem,
            this.activateBookmarkToolStripMenuItem});
            this.winwordToolStripMenuItem.Name = "winwordToolStripMenuItem";
            this.winwordToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.winwordToolStripMenuItem.Text = "x_Winword";
            // 
            // openBelongingDocToolStripMenuItem
            // 
            this.openBelongingDocToolStripMenuItem.Name = "openBelongingDocToolStripMenuItem";
            this.openBelongingDocToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.openBelongingDocToolStripMenuItem.Text = "x_open belonging Doc";
            this.openBelongingDocToolStripMenuItem.Click += new System.EventHandler(this.openBelongingDocToolStripMenuItem_Click);
            // 
            // insertBookmarkToolStripMenuItem
            // 
            this.insertBookmarkToolStripMenuItem.Name = "insertBookmarkToolStripMenuItem";
            this.insertBookmarkToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.insertBookmarkToolStripMenuItem.Text = "x_insert Bookmark";
            // 
            // activateBookmarkToolStripMenuItem
            // 
            this.activateBookmarkToolStripMenuItem.Name = "activateBookmarkToolStripMenuItem";
            this.activateBookmarkToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.activateBookmarkToolStripMenuItem.Text = "x_activate Bookmark";
            this.activateBookmarkToolStripMenuItem.Click += new System.EventHandler(this.activateBookmarkToolStripMenuItem_Click);
            // 
            // applyToolStripMenuItem
            // 
            this.applyToolStripMenuItem.Name = "applyToolStripMenuItem";
            this.applyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.applyToolStripMenuItem.Text = "x_Apply";
            // 
            // ImageList_SceneTree
            // 
            this.ImageList_SceneTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList_SceneTree.ImageStream")));
            this.ImageList_SceneTree.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList_SceneTree.Images.SetKeyName(0, "bb_home_.png");
            this.ImageList_SceneTree.Images.SetKeyName(1, "Types_Closed.png");
            this.ImageList_SceneTree.Images.SetKeyName(2, "Types_Opened.png");
            this.ImageList_SceneTree.Images.SetKeyName(3, "Types_Closed.png");
            this.ImageList_SceneTree.Images.SetKeyName(4, "Types_Opened.png");
            this.ImageList_SceneTree.Images.SetKeyName(5, "gthumb.ico");
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox_SearchTemplates,
            this.toolStripTextBox_Search,
            this.ToolStripButton_ClearSearch,
            this.toolStripButton_GetRel,
            this.toolStripButton_Search});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(439, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripComboBox_SearchTemplates
            // 
            this.toolStripComboBox_SearchTemplates.Name = "toolStripComboBox_SearchTemplates";
            this.toolStripComboBox_SearchTemplates.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripTextBox_Search
            // 
            this.toolStripTextBox_Search.Name = "toolStripTextBox_Search";
            this.toolStripTextBox_Search.Size = new System.Drawing.Size(200, 25);
            // 
            // ToolStripButton_ClearSearch
            // 
            this.ToolStripButton_ClearSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton_ClearSearch.Enabled = false;
            this.ToolStripButton_ClearSearch.Image = global::Scenes_Literatur_Module.Properties.Resources.tasto_8_architetto_franc_01;
            this.ToolStripButton_ClearSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_ClearSearch.Name = "ToolStripButton_ClearSearch";
            this.ToolStripButton_ClearSearch.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton_ClearSearch.Text = "ToolStripButton1";
            // 
            // toolStripButton_GetRel
            // 
            this.toolStripButton_GetRel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_GetRel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_GetRel.Image")));
            this.toolStripButton_GetRel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_GetRel.Name = "toolStripButton_GetRel";
            this.toolStripButton_GetRel.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_GetRel.Text = "...";
            // 
            // toolStripButton_Search
            // 
            this.toolStripButton_Search.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Search.Enabled = false;
            this.toolStripButton_Search.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Search.Image")));
            this.toolStripButton_Search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Search.Name = "toolStripButton_Search";
            this.toolStripButton_Search.Size = new System.Drawing.Size(56, 22);
            this.toolStripButton_Search.Text = "x_Search";
            // 
            // UserControl_SceneTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_SceneTree";
            this.Size = new System.Drawing.Size(572, 459);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip_Tree.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_ScenesCountLBL;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_SceneCount;
        private System.Windows.Forms.TreeView treeView_SceneTree;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_SearchTemplates;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Search;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_ClearSearch;
        internal System.Windows.Forms.ImageList ImageList_SceneTree;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_FoundLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Found;
        private System.Windows.Forms.ToolStripButton toolStripButton_GetRel;
        private System.Windows.Forms.ToolStripButton toolStripButton_Search;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Tree;
        private System.Windows.Forms.ToolStripMenuItem winwordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBelongingDocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertBookmarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activateBookmarkToolStripMenuItem;
    }
}
