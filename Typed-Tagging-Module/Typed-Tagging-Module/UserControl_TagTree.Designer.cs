namespace Typed_Tagging_Module
{
    partial class UserControl_TagTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_TagTree));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_CountLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Count = new System.Windows.Forms.ToolStripLabel();
            this.treeView_Tags = new System.Windows.Forms.TreeView();
            this.imageList_Tags = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.ToolStripLabel_Mark = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripTextBox_Mark = new System.Windows.Forms.ToolStripTextBox();
            this.ToolStripButton_ClearMark = new System.Windows.Forms.ToolStripButton();
            this.timer_TagMark = new System.Windows.Forms.Timer(this.components);
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.treeView_Tags);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(529, 414);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(529, 464);
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
            this.toolStripLabel_CountLbl,
            this.toolStripLabel_Count});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(78, 25);
            this.toolStrip1.TabIndex = 0;
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
            // treeView_Tags
            // 
            this.treeView_Tags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Tags.ImageIndex = 0;
            this.treeView_Tags.ImageList = this.imageList_Tags;
            this.treeView_Tags.Location = new System.Drawing.Point(0, 0);
            this.treeView_Tags.Name = "treeView_Tags";
            this.treeView_Tags.SelectedImageIndex = 0;
            this.treeView_Tags.Size = new System.Drawing.Size(529, 414);
            this.treeView_Tags.TabIndex = 0;
            this.treeView_Tags.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Tags_AfterSelect);
            // 
            // imageList_Tags
            // 
            this.imageList_Tags.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_Tags.ImageStream")));
            this.imageList_Tags.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_Tags.Images.SetKeyName(0, "bb_home_.png");
            this.imageList_Tags.Images.SetKeyName(1, "Types_Closed.png");
            this.imageList_Tags.Images.SetKeyName(2, "gnome-fs-home.png");
            this.imageList_Tags.Images.SetKeyName(3, "Types_Closed_with_items.png");
            this.imageList_Tags.Images.SetKeyName(4, "gnome-fs-home_with_items.png");
            this.imageList_Tags.Images.SetKeyName(5, "Attributes bamboo_danny_allen_r.png");
            this.imageList_Tags.Images.SetKeyName(6, "Attributes bamboo_danny_allen_r.png");
            this.imageList_Tags.Images.SetKeyName(7, "gpride_jean_victor_balin_.png");
            this.imageList_Tags.Images.SetKeyName(8, "gpride_jean_victor_balin_.png");
            this.imageList_Tags.Images.SetKeyName(9, "Vogelschwarm.png");
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripLabel_Mark,
            this.ToolStripTextBox_Mark,
            this.ToolStripButton_ClearMark});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(315, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // ToolStripLabel_Mark
            // 
            this.ToolStripLabel_Mark.Name = "ToolStripLabel_Mark";
            this.ToolStripLabel_Mark.Size = new System.Drawing.Size(47, 22);
            this.ToolStripLabel_Mark.Text = "x_Mark:";
            // 
            // ToolStripTextBox_Mark
            // 
            this.ToolStripTextBox_Mark.Name = "ToolStripTextBox_Mark";
            this.ToolStripTextBox_Mark.Size = new System.Drawing.Size(200, 25);
            this.ToolStripTextBox_Mark.TextChanged += new System.EventHandler(this.ToolStripTextBox_Mark_TextChanged);
            // 
            // ToolStripButton_ClearMark
            // 
            this.ToolStripButton_ClearMark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton_ClearMark.Image = global::Typed_Tagging_Module.Properties.Resources.tasto_8_architetto_franc_01;
            this.ToolStripButton_ClearMark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_ClearMark.Name = "ToolStripButton_ClearMark";
            this.ToolStripButton_ClearMark.Size = new System.Drawing.Size(23, 22);
            this.ToolStripButton_ClearMark.Text = "ToolStripButton1";
            this.ToolStripButton_ClearMark.Click += new System.EventHandler(this.ToolStripButton_ClearMark_Click);
            // 
            // timer_TagMark
            // 
            this.timer_TagMark.Interval = 300;
            this.timer_TagMark.Tick += new System.EventHandler(this.timer_TagMark_Tick);
            // 
            // UserControl_TagTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_TagTree";
            this.Size = new System.Drawing.Size(529, 464);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_CountLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Count;
        private System.Windows.Forms.TreeView treeView_Tags;
        private System.Windows.Forms.ImageList imageList_Tags;
        private System.Windows.Forms.ToolStrip toolStrip2;
        internal System.Windows.Forms.ToolStripLabel ToolStripLabel_Mark;
        internal System.Windows.Forms.ToolStripTextBox ToolStripTextBox_Mark;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_ClearMark;
        private System.Windows.Forms.Timer timer_TagMark;
    }
}
