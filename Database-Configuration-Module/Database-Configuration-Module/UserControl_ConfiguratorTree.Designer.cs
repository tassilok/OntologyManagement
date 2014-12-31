namespace DatabaseConfigurationModule
{
    partial class UserControl_ConfiguratorTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_ConfiguratorTree));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.treeView_Configurator = new System.Windows.Forms.TreeView();
            this.contextMenuStrip_Nodes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resolveDependenciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList_ConfiguratorTree = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.contextMenuStrip_Nodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.treeView_Configurator);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(402, 402);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(402, 427);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // treeView_Configurator
            // 
            this.treeView_Configurator.ContextMenuStrip = this.contextMenuStrip_Nodes;
            this.treeView_Configurator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Configurator.HideSelection = false;
            this.treeView_Configurator.ImageIndex = 0;
            this.treeView_Configurator.ImageList = this.imageList_ConfiguratorTree;
            this.treeView_Configurator.Location = new System.Drawing.Point(0, 0);
            this.treeView_Configurator.Name = "treeView_Configurator";
            this.treeView_Configurator.SelectedImageIndex = 0;
            this.treeView_Configurator.Size = new System.Drawing.Size(402, 402);
            this.treeView_Configurator.TabIndex = 0;
            this.treeView_Configurator.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Configurator_AfterSelect);
            this.treeView_Configurator.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_Configurator_NodeMouseDoubleClick);
            // 
            // contextMenuStrip_Nodes
            // 
            this.contextMenuStrip_Nodes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resolveDependenciesToolStripMenuItem});
            this.contextMenuStrip_Nodes.Name = "contextMenuStrip_Nodes";
            this.contextMenuStrip_Nodes.Size = new System.Drawing.Size(202, 26);
            this.contextMenuStrip_Nodes.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Nodes_Opening);
            // 
            // resolveDependenciesToolStripMenuItem
            // 
            this.resolveDependenciesToolStripMenuItem.Name = "resolveDependenciesToolStripMenuItem";
            this.resolveDependenciesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.resolveDependenciesToolStripMenuItem.Text = "x_Resolve Dependencies";
            this.resolveDependenciesToolStripMenuItem.Click += new System.EventHandler(this.resolveDependenciesToolStripMenuItem_Click);
            // 
            // imageList_ConfiguratorTree
            // 
            this.imageList_ConfiguratorTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_ConfiguratorTree.ImageStream")));
            this.imageList_ConfiguratorTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_ConfiguratorTree.Images.SetKeyName(0, "bb_home_.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(1, "power-management.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(2, "power-management.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(3, "folder_bomb.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(4, "folder_bomb.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(5, "blockdevice.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(6, "folder_binary.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(7, "folder_binary.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(8, "folder_documents.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(9, "folder_documents.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(10, "soffice.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(11, "soffice.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(12, "cache.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(13, "cache.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(14, "folder_grey.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(15, "folder_grey.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(16, "bb_pckg_.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(17, "bb_pckg_.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(18, "70a021.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(19, "bb_forward_.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(20, "information_sign_mo_01.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(21, "wireless_transmitter_bra_01.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(22, "wireless_transmitter_bra_01.png");
            this.imageList_ConfiguratorTree.Images.SetKeyName(23, "server_olivier_boyer_04.png");
            // 
            // UserControl_ConfiguratorTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_ConfiguratorTree";
            this.Size = new System.Drawing.Size(402, 427);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.contextMenuStrip_Nodes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TreeView treeView_Configurator;
        private System.Windows.Forms.ImageList imageList_ConfiguratorTree;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Nodes;
        private System.Windows.Forms.ToolStripMenuItem resolveDependenciesToolStripMenuItem;
    }
}
