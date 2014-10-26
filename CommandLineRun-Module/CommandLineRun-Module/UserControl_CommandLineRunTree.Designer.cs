namespace CommandLineRun_Module
{
    partial class UserControl_CommandLineRunTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_CommandLineRunTree));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_CountLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Count = new System.Windows.Forms.ToolStripLabel();
            this.treeView_CMDLR = new System.Windows.Forms.TreeView();
            this.contextMenuStrip_CMDLR = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ModuleMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenModuleByArgumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenLastModuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_Mark = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Mark = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_SemFilter = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_SemFilter = new System.Windows.Forms.ToolStripTextBox();
            this.timer_Mark = new System.Windows.Forms.Timer(this.components);
            this.toolStripButton_AddSemFilter = new System.Windows.Forms.ToolStripButton();
            this.mapVariablesToValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip_CMDLR.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.treeView_CMDLR);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(599, 465);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(599, 515);
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
            // treeView_CMDLR
            // 
            this.treeView_CMDLR.ContextMenuStrip = this.contextMenuStrip_CMDLR;
            this.treeView_CMDLR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_CMDLR.HideSelection = false;
            this.treeView_CMDLR.Location = new System.Drawing.Point(0, 0);
            this.treeView_CMDLR.Name = "treeView_CMDLR";
            this.treeView_CMDLR.Size = new System.Drawing.Size(599, 465);
            this.treeView_CMDLR.TabIndex = 1;
            this.treeView_CMDLR.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_CMDLR_AfterSelect);
            this.treeView_CMDLR.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_CMDLR_NodeMouseDoubleClick);
            this.treeView_CMDLR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView_CMDLR_KeyDown);
            // 
            // contextMenuStrip_CMDLR
            // 
            this.contextMenuStrip_CMDLR.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModuleMenuToolStripMenuItem,
            this.mapVariablesToValuesToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.applyToolStripMenuItem});
            this.contextMenuStrip_CMDLR.Name = "contextMenuStrip_CMDLR";
            this.contextMenuStrip_CMDLR.Size = new System.Drawing.Size(210, 114);
            this.contextMenuStrip_CMDLR.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_CMDLR_Opening);
            // 
            // ModuleMenuToolStripMenuItem
            // 
            this.ModuleMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenModuleByArgumentToolStripMenuItem});
            this.ModuleMenuToolStripMenuItem.Name = "ModuleMenuToolStripMenuItem";
            this.ModuleMenuToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.ModuleMenuToolStripMenuItem.Text = "x_Module-Menu";
            // 
            // OpenModuleByArgumentToolStripMenuItem
            // 
            this.OpenModuleByArgumentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenLastModuleToolStripMenuItem});
            this.OpenModuleByArgumentToolStripMenuItem.Name = "OpenModuleByArgumentToolStripMenuItem";
            this.OpenModuleByArgumentToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.OpenModuleByArgumentToolStripMenuItem.Text = "x_Open Module by Argument";
            this.OpenModuleByArgumentToolStripMenuItem.Click += new System.EventHandler(this.OpenModuleByArgumentToolStripMenuItem_Click);
            // 
            // OpenLastModuleToolStripMenuItem
            // 
            this.OpenLastModuleToolStripMenuItem.CheckOnClick = true;
            this.OpenLastModuleToolStripMenuItem.Name = "OpenLastModuleToolStripMenuItem";
            this.OpenLastModuleToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.OpenLastModuleToolStripMenuItem.Text = "x_Open Last Module";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.refreshToolStripMenuItem.Text = "x_Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // applyToolStripMenuItem
            // 
            this.applyToolStripMenuItem.Name = "applyToolStripMenuItem";
            this.applyToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.applyToolStripMenuItem.Text = "x_Apply";
            this.applyToolStripMenuItem.Click += new System.EventHandler(this.applyToolStripMenuItem_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_Mark,
            this.toolStripTextBox_Mark,
            this.toolStripSeparator1,
            this.toolStripLabel_SemFilter,
            this.toolStripTextBox_SemFilter,
            this.toolStripButton_AddSemFilter});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(461, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripLabel_Mark
            // 
            this.toolStripLabel_Mark.Name = "toolStripLabel_Mark";
            this.toolStripLabel_Mark.Size = new System.Drawing.Size(47, 22);
            this.toolStripLabel_Mark.Text = "x_Mark:";
            // 
            // toolStripTextBox_Mark
            // 
            this.toolStripTextBox_Mark.Name = "toolStripTextBox_Mark";
            this.toolStripTextBox_Mark.Size = new System.Drawing.Size(150, 25);
            this.toolStripTextBox_Mark.TextChanged += new System.EventHandler(this.toolStripTextBox_Mark_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_SemFilter
            // 
            this.toolStripLabel_SemFilter.Name = "toolStripLabel_SemFilter";
            this.toolStripLabel_SemFilter.Size = new System.Drawing.Size(69, 22);
            this.toolStripLabel_SemFilter.Text = "x_SemFilter:";
            // 
            // toolStripTextBox_SemFilter
            // 
            this.toolStripTextBox_SemFilter.Name = "toolStripTextBox_SemFilter";
            this.toolStripTextBox_SemFilter.ReadOnly = true;
            this.toolStripTextBox_SemFilter.Size = new System.Drawing.Size(150, 25);
            // 
            // timer_Mark
            // 
            this.timer_Mark.Interval = 300;
            this.timer_Mark.Tick += new System.EventHandler(this.timer_Mark_Tick);
            // 
            // toolStripButton_AddSemFilter
            // 
            this.toolStripButton_AddSemFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_AddSemFilter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_AddSemFilter.Image")));
            this.toolStripButton_AddSemFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddSemFilter.Name = "toolStripButton_AddSemFilter";
            this.toolStripButton_AddSemFilter.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_AddSemFilter.Text = "...";
            this.toolStripButton_AddSemFilter.Click += new System.EventHandler(this.toolStripButton_AddSemFilter_Click);
            // 
            // mapVariablesToValuesToolStripMenuItem
            // 
            this.mapVariablesToValuesToolStripMenuItem.Name = "mapVariablesToValuesToolStripMenuItem";
            this.mapVariablesToValuesToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.mapVariablesToValuesToolStripMenuItem.Text = "x_Map Variables to Values";
            this.mapVariablesToValuesToolStripMenuItem.Click += new System.EventHandler(this.mapVariablesToValuesToolStripMenuItem_Click);
            // 
            // UserControl_CommandLineRunTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_CommandLineRunTree";
            this.Size = new System.Drawing.Size(599, 515);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip_CMDLR.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_CountLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Count;
        private System.Windows.Forms.TreeView treeView_CMDLR;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Mark;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Mark;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_SemFilter;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_SemFilter;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddSemFilter;
        private System.Windows.Forms.Timer timer_Mark;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_CMDLR;
        internal System.Windows.Forms.ToolStripMenuItem ModuleMenuToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem OpenModuleByArgumentToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem OpenLastModuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapVariablesToValuesToolStripMenuItem;
    }
}
