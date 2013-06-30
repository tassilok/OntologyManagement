namespace Change_Module
{
    partial class UserControl_TicketTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_TicketTree));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripProgressBar_Lists = new System.Windows.Forms.ToolStripProgressBar();
            this.treeView_Lists = new System.Windows.Forms.TreeView();
            this.ImageList_Main = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_SelctedRange = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_SelectedRange = new System.Windows.Forms.ToolStripTextBox();
            this.timerRelated = new System.Windows.Forms.Timer(this.components);
            this.ContextMenuStrip_TicketTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ApplyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.ContextMenuStrip_TicketTree.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.treeView_Lists);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(464, 359);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(464, 409);
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
            this.toolStripProgressBar_Lists});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(114, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripProgressBar_Lists
            // 
            this.toolStripProgressBar_Lists.Name = "toolStripProgressBar_Lists";
            this.toolStripProgressBar_Lists.Size = new System.Drawing.Size(100, 22);
            // 
            // treeView_Lists
            // 
            this.treeView_Lists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Lists.ImageIndex = 0;
            this.treeView_Lists.ImageList = this.ImageList_Main;
            this.treeView_Lists.Location = new System.Drawing.Point(0, 0);
            this.treeView_Lists.Name = "treeView_Lists";
            this.treeView_Lists.SelectedImageIndex = 0;
            this.treeView_Lists.Size = new System.Drawing.Size(464, 359);
            this.treeView_Lists.TabIndex = 0;
            this.treeView_Lists.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Lists_AfterSelect);
            // 
            // ImageList_Main
            // 
            this.ImageList_Main.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList_Main.ImageStream")));
            this.ImageList_Main.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList_Main.Images.SetKeyName(0, "bb_home_.png");
            this.ImageList_Main.Images.SetKeyName(1, "gnome-mime-application-vnd.ms-powerpoint.png");
            this.ImageList_Main.Images.SetKeyName(2, "Types_Closed.png");
            this.ImageList_Main.Images.SetKeyName(3, "Types_Opened.png");
            this.ImageList_Main.Images.SetKeyName(4, "Attributes bamboo_danny_allen_r.png");
            this.ImageList_Main.Images.SetKeyName(5, "RelationTypes gpride_jean_victor_balin_.png");
            this.ImageList_Main.Images.SetKeyName(6, "Vogelschwarm klein.png");
            this.ImageList_Main.Images.SetKeyName(7, "Types_Closed SubItems.png");
            this.ImageList_Main.Images.SetKeyName(8, "Types_Opened SubItems.png");
            this.ImageList_Main.Images.SetKeyName(9, "clipboard_01.ico");
            this.ImageList_Main.Images.SetKeyName(10, "bb_pckg_.ico");
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_SelctedRange,
            this.toolStripTextBox_SelectedRange});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(311, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripLabel_SelctedRange
            // 
            this.toolStripLabel_SelctedRange.Name = "toolStripLabel_SelctedRange";
            this.toolStripLabel_SelctedRange.Size = new System.Drawing.Size(97, 22);
            this.toolStripLabel_SelctedRange.Text = "x_SelectedRange:";
            // 
            // toolStripTextBox_SelectedRange
            // 
            this.toolStripTextBox_SelectedRange.Name = "toolStripTextBox_SelectedRange";
            this.toolStripTextBox_SelectedRange.Size = new System.Drawing.Size(200, 25);
            // 
            // timerRelated
            // 
            this.timerRelated.Interval = 300;
            this.timerRelated.Tick += new System.EventHandler(this.timerRelated_Tick);
            // 
            // ContextMenuStrip_TicketTree
            // 
            this.ContextMenuStrip_TicketTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateToolStripMenuItem,
            this.RemoveToolStripMenuItem,
            this.ApplyToolStripMenuItem});
            this.ContextMenuStrip_TicketTree.Name = "ContextMenuStrip_TicketTree";
            this.ContextMenuStrip_TicketTree.Size = new System.Drawing.Size(153, 92);
            this.ContextMenuStrip_TicketTree.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip_TicketTree_Opening);
            // 
            // CreateToolStripMenuItem
            // 
            this.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem";
            this.CreateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.CreateToolStripMenuItem.Text = "x_Create";
            this.CreateToolStripMenuItem.Click += new System.EventHandler(this.CreateToolStripMenuItem_Click);
            // 
            // RemoveToolStripMenuItem
            // 
            this.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem";
            this.RemoveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.RemoveToolStripMenuItem.Text = "x_Remove";
            // 
            // ApplyToolStripMenuItem
            // 
            this.ApplyToolStripMenuItem.Enabled = false;
            this.ApplyToolStripMenuItem.Name = "ApplyToolStripMenuItem";
            this.ApplyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ApplyToolStripMenuItem.Text = "x_Apply";
            // 
            // UserControl_TicketTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_TicketTree";
            this.Size = new System.Drawing.Size(464, 409);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ContextMenuStrip_TicketTree.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar_Lists;
        private System.Windows.Forms.TreeView treeView_Lists;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_SelctedRange;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_SelectedRange;
        internal System.Windows.Forms.ImageList ImageList_Main;
        private System.Windows.Forms.Timer timerRelated;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip_TicketTree;
        internal System.Windows.Forms.ToolStripMenuItem CreateToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem RemoveToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ApplyToolStripMenuItem;
    }
}
