namespace Change_Module
{
    partial class UserControl_ProcessTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_ProcessTree));
            this.treeView_ProcessTree = new System.Windows.Forms.TreeView();
            this.ContextMenuStrip_ProcessTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LoggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ErrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ErrorSolvedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ObsoleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SubProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ExistingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SubIncidentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SubTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageList_Main = new System.Windows.Forms.ImageList(this.components);
            this.ContextMenuStrip_ProcessTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView_ProcessTree
            // 
            this.treeView_ProcessTree.CheckBoxes = true;
            this.treeView_ProcessTree.ContextMenuStrip = this.ContextMenuStrip_ProcessTree;
            this.treeView_ProcessTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_ProcessTree.ImageIndex = 0;
            this.treeView_ProcessTree.ImageList = this.ImageList_Main;
            this.treeView_ProcessTree.Location = new System.Drawing.Point(0, 0);
            this.treeView_ProcessTree.Name = "treeView_ProcessTree";
            this.treeView_ProcessTree.SelectedImageIndex = 0;
            this.treeView_ProcessTree.Size = new System.Drawing.Size(457, 423);
            this.treeView_ProcessTree.TabIndex = 0;
            this.treeView_ProcessTree.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_ProcessTree_BeforeCheck);
            this.treeView_ProcessTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_ProcessTree_AfterSelect);
            this.treeView_ProcessTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView_ProcessTree_MouseDoubleClick);
            // 
            // ContextMenuStrip_ProcessTree
            // 
            this.ContextMenuStrip_ProcessTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoggingToolStripMenuItem,
            this.NewToolStripMenuItem});
            this.ContextMenuStrip_ProcessTree.Name = "ContextMenuStrip_ProcessTree";
            this.ContextMenuStrip_ProcessTree.Size = new System.Drawing.Size(153, 70);
            this.ContextMenuStrip_ProcessTree.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip_ProcessTree_Opening);
            // 
            // LoggingToolStripMenuItem
            // 
            this.LoggingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ErrorToolStripMenuItem,
            this.ErrorSolvedToolStripMenuItem,
            this.InformationToolStripMenuItem,
            this.ObsoleteToolStripMenuItem});
            this.LoggingToolStripMenuItem.Name = "LoggingToolStripMenuItem";
            this.LoggingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.LoggingToolStripMenuItem.Text = "x_Logging";
            // 
            // ErrorToolStripMenuItem
            // 
            this.ErrorToolStripMenuItem.Name = "ErrorToolStripMenuItem";
            this.ErrorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ErrorToolStripMenuItem.Text = "x_Error";
            // 
            // ErrorSolvedToolStripMenuItem
            // 
            this.ErrorSolvedToolStripMenuItem.Name = "ErrorSolvedToolStripMenuItem";
            this.ErrorSolvedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ErrorSolvedToolStripMenuItem.Text = "x_Error solved";
            // 
            // InformationToolStripMenuItem
            // 
            this.InformationToolStripMenuItem.Name = "InformationToolStripMenuItem";
            this.InformationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.InformationToolStripMenuItem.Text = "x_Information";
            this.InformationToolStripMenuItem.Click += new System.EventHandler(this.InformationToolStripMenuItem_Click);
            // 
            // ObsoleteToolStripMenuItem
            // 
            this.ObsoleteToolStripMenuItem.Name = "ObsoleteToolStripMenuItem";
            this.ObsoleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ObsoleteToolStripMenuItem.Text = "x_Obsolete";
            this.ObsoleteToolStripMenuItem.Click += new System.EventHandler(this.ObsoleteToolStripMenuItem_Click);
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubProcessToolStripMenuItem,
            this.SubIncidentToolStripMenuItem,
            this.SubTicketToolStripMenuItem});
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.NewToolStripMenuItem.Text = "x_New";
            // 
            // SubProcessToolStripMenuItem
            // 
            this.SubProcessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem1,
            this.ExistingToolStripMenuItem});
            this.SubProcessToolStripMenuItem.Name = "SubProcessToolStripMenuItem";
            this.SubProcessToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SubProcessToolStripMenuItem.Text = "x_Sub-Process";
            this.SubProcessToolStripMenuItem.Click += new System.EventHandler(this.SubProcessToolStripMenuItem_Click);
            // 
            // NewToolStripMenuItem1
            // 
            this.NewToolStripMenuItem1.Name = "NewToolStripMenuItem1";
            this.NewToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.NewToolStripMenuItem1.Text = "x_New";
            this.NewToolStripMenuItem1.Click += new System.EventHandler(this.NewToolStripMenuItem1_Click);
            // 
            // ExistingToolStripMenuItem
            // 
            this.ExistingToolStripMenuItem.Name = "ExistingToolStripMenuItem";
            this.ExistingToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.ExistingToolStripMenuItem.Text = "x_Existing";
            // 
            // SubIncidentToolStripMenuItem
            // 
            this.SubIncidentToolStripMenuItem.Name = "SubIncidentToolStripMenuItem";
            this.SubIncidentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SubIncidentToolStripMenuItem.Text = "x_Sub-Incident";
            this.SubIncidentToolStripMenuItem.Click += new System.EventHandler(this.SubIncidentToolStripMenuItem_Click);
            // 
            // SubTicketToolStripMenuItem
            // 
            this.SubTicketToolStripMenuItem.Name = "SubTicketToolStripMenuItem";
            this.SubTicketToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SubTicketToolStripMenuItem.Text = "x_Sub-Ticket";
            // 
            // ImageList_Main
            // 
            this.ImageList_Main.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList_Main.ImageStream")));
            this.ImageList_Main.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList_Main.Images.SetKeyName(0, "gnome-mime-application-vnd.ms-powerpoint.png");
            this.ImageList_Main.Images.SetKeyName(1, "cog_01.png");
            this.ImageList_Main.Images.SetKeyName(2, "construction_hammer_jon__01.png");
            this.ImageList_Main.Images.SetKeyName(3, "cog_01_w_doc.png");
            this.ImageList_Main.Images.SetKeyName(4, "construction_hammer_jon__01_w_doc.png");
            this.ImageList_Main.Images.SetKeyName(5, "bb_home_.png");
            // 
            // UserControl_ProcessTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView_ProcessTree);
            this.Name = "UserControl_ProcessTree";
            this.Size = new System.Drawing.Size(457, 423);
            this.ContextMenuStrip_ProcessTree.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_ProcessTree;
        internal System.Windows.Forms.ImageList ImageList_Main;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip_ProcessTree;
        internal System.Windows.Forms.ToolStripMenuItem LoggingToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ErrorToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ErrorSolvedToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem InformationToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ObsoleteToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem SubProcessToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem ExistingToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem SubIncidentToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem SubTicketToolStripMenuItem;
    }
}
