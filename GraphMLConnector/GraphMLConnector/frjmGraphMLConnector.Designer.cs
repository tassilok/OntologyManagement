namespace GraphMLConnector
{
    partial class frmGraphMLConnector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGraphMLConnector));
            this.contextMenuStrip_Export = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setExportModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_CountLBL = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Count = new System.Windows.Forms.ToolStripLabel();
            this.treeView_Graphs = new System.Windows.Forms.TreeView();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_Mark = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Mark = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.dataGridView_Export = new System.Windows.Forms.DataGridView();
            this.ID_Parent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Export = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton_GlobalExportMode = new System.Windows.Forms.ToolStripSplitButton();
            this.classesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classesWithRelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectsAndClassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectsAndClassesWithRelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource_GraphItems = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip_Export.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripContainer2.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Export)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_GraphItems)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip_Export
            // 
            this.contextMenuStrip_Export.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItemToolStripMenuItem,
            this.removeItemToolStripMenuItem,
            this.setExportModeToolStripMenuItem});
            this.contextMenuStrip_Export.Name = "contextMenuStrip_Export";
            this.contextMenuStrip_Export.Size = new System.Drawing.Size(163, 70);
            this.contextMenuStrip_Export.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Export_Opening);
            // 
            // addItemToolStripMenuItem
            // 
            this.addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
            this.addItemToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.addItemToolStripMenuItem.Text = "Add Item";
            this.addItemToolStripMenuItem.Click += new System.EventHandler(this.addItemToolStripMenuItem_Click);
            // 
            // removeItemToolStripMenuItem
            // 
            this.removeItemToolStripMenuItem.Name = "removeItemToolStripMenuItem";
            this.removeItemToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.removeItemToolStripMenuItem.Text = "Remove Item";
            this.removeItemToolStripMenuItem.Click += new System.EventHandler(this.removeItemToolStripMenuItem_Click);
            // 
            // setExportModeToolStripMenuItem
            // 
            this.setExportModeToolStripMenuItem.Name = "setExportModeToolStripMenuItem";
            this.setExportModeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.setExportModeToolStripMenuItem.Text = "Set Export-Mode";
            this.setExportModeToolStripMenuItem.Click += new System.EventHandler(this.setExportModeToolStripMenuItem_Click);
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
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.toolStripContainer1);
            this.splitContainer1.Size = new System.Drawing.Size(680, 487);
            this.splitContainer1.SplitterDistance = 226;
            this.splitContainer1.TabIndex = 1;
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.BottomToolStripPanel
            // 
            this.toolStripContainer2.BottomToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.treeView_Graphs);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(222, 433);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(222, 483);
            this.toolStripContainer2.TabIndex = 0;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.toolStrip3);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Close,
            this.toolStripSeparator1,
            this.toolStripLabel_CountLBL,
            this.toolStripLabel_Count});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(133, 25);
            this.toolStrip1.TabIndex = 3;
            // 
            // toolStripButton_Close
            // 
            this.toolStripButton_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Close.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Close.Image")));
            this.toolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Close.Name = "toolStripButton_Close";
            this.toolStripButton_Close.Size = new System.Drawing.Size(50, 22);
            this.toolStripButton_Close.Text = "x_Close";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_CountLBL
            // 
            this.toolStripLabel_CountLBL.Name = "toolStripLabel_CountLBL";
            this.toolStripLabel_CountLBL.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel_CountLBL.Text = "x_Count:";
            // 
            // toolStripLabel_Count
            // 
            this.toolStripLabel_Count.Name = "toolStripLabel_Count";
            this.toolStripLabel_Count.Size = new System.Drawing.Size(12, 22);
            this.toolStripLabel_Count.Text = "-";
            // 
            // treeView_Graphs
            // 
            this.treeView_Graphs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Graphs.Location = new System.Drawing.Point(0, 0);
            this.treeView_Graphs.Name = "treeView_Graphs";
            this.treeView_Graphs.Size = new System.Drawing.Size(222, 433);
            this.treeView_Graphs.TabIndex = 0;
            this.treeView_Graphs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Graphs_AfterSelect);
            this.treeView_Graphs.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_Graphs_NodeMouseDoubleClick);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_Mark,
            this.toolStripTextBox_Mark});
            this.toolStrip3.Location = new System.Drawing.Point(3, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(161, 25);
            this.toolStrip3.TabIndex = 0;
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
            this.toolStripTextBox_Mark.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_Export);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(446, 458);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(446, 483);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // dataGridView_Export
            // 
            this.dataGridView_Export.AllowUserToAddRows = false;
            this.dataGridView_Export.AllowUserToDeleteRows = false;
            this.dataGridView_Export.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Export.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Parent});
            this.dataGridView_Export.ContextMenuStrip = this.contextMenuStrip_Export;
            this.dataGridView_Export.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Export.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Export.Name = "dataGridView_Export";
            this.dataGridView_Export.ReadOnly = true;
            this.dataGridView_Export.Size = new System.Drawing.Size(446, 458);
            this.dataGridView_Export.TabIndex = 0;
            this.dataGridView_Export.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Export_ColumnHeaderMouseClick);
            // 
            // ID_Parent
            // 
            this.ID_Parent.DataPropertyName = "ID_Parent";
            this.ID_Parent.HeaderText = "ID_Parent";
            this.ID_Parent.Name = "ID_Parent";
            this.ID_Parent.ReadOnly = true;
            this.ID_Parent.Visible = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Export,
            this.toolStripSplitButton_GlobalExportMode});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(234, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripButton_Export
            // 
            this.toolStripButton_Export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Export.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Export.Image")));
            this.toolStripButton_Export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Export.Name = "toolStripButton_Export";
            this.toolStripButton_Export.Size = new System.Drawing.Size(54, 22);
            this.toolStripButton_Export.Text = "x_Export";
            this.toolStripButton_Export.Click += new System.EventHandler(this.toolStripButton_Export_Click);
            // 
            // toolStripSplitButton_GlobalExportMode
            // 
            this.toolStripSplitButton_GlobalExportMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton_GlobalExportMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classesToolStripMenuItem,
            this.classesWithRelsToolStripMenuItem,
            this.objectsAndClassesToolStripMenuItem,
            this.objectsAndClassesWithRelsToolStripMenuItem,
            this.objectsToolStripMenuItem,
            this.gridToolStripMenuItem});
            this.toolStripSplitButton_GlobalExportMode.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton_GlobalExportMode.Image")));
            this.toolStripSplitButton_GlobalExportMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton_GlobalExportMode.Name = "toolStripSplitButton_GlobalExportMode";
            this.toolStripSplitButton_GlobalExportMode.Size = new System.Drawing.Size(137, 22);
            this.toolStripSplitButton_GlobalExportMode.Text = "x_Global Export Mode";
            // 
            // classesToolStripMenuItem
            // 
            this.classesToolStripMenuItem.Name = "classesToolStripMenuItem";
            this.classesToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.classesToolStripMenuItem.Text = "x_Classes";
            this.classesToolStripMenuItem.Click += new System.EventHandler(this.classesToolStripMenuItem_Click);
            // 
            // classesWithRelsToolStripMenuItem
            // 
            this.classesWithRelsToolStripMenuItem.Name = "classesWithRelsToolStripMenuItem";
            this.classesWithRelsToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.classesWithRelsToolStripMenuItem.Text = "x_Classes with Rels";
            this.classesWithRelsToolStripMenuItem.Click += new System.EventHandler(this.classesWithRelsToolStripMenuItem_Click);
            // 
            // objectsAndClassesToolStripMenuItem
            // 
            this.objectsAndClassesToolStripMenuItem.Name = "objectsAndClassesToolStripMenuItem";
            this.objectsAndClassesToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.objectsAndClassesToolStripMenuItem.Text = "x_Objects and Classes";
            this.objectsAndClassesToolStripMenuItem.Click += new System.EventHandler(this.objectsAndClassesToolStripMenuItem_Click);
            // 
            // objectsAndClassesWithRelsToolStripMenuItem
            // 
            this.objectsAndClassesWithRelsToolStripMenuItem.Name = "objectsAndClassesWithRelsToolStripMenuItem";
            this.objectsAndClassesWithRelsToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.objectsAndClassesWithRelsToolStripMenuItem.Text = "x_Objects and Classes with Rels";
            this.objectsAndClassesWithRelsToolStripMenuItem.Click += new System.EventHandler(this.objectsAndClassesWithRelsToolStripMenuItem_Click);
            // 
            // objectsToolStripMenuItem
            // 
            this.objectsToolStripMenuItem.Name = "objectsToolStripMenuItem";
            this.objectsToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.objectsToolStripMenuItem.Text = "x_Objects";
            this.objectsToolStripMenuItem.Click += new System.EventHandler(this.objectsToolStripMenuItem_Click);
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Checked = true;
            this.gridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.gridToolStripMenuItem.Text = "x_Grid";
            this.gridToolStripMenuItem.Click += new System.EventHandler(this.gridToolStripMenuItem_Click);
            // 
            // frmGraphMLConnector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 487);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmGraphMLConnector";
            this.Text = "Graph-ML Connector";
            this.contextMenuStrip_Export.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripContainer2.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Export)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_GraphItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Export;
        private System.Windows.Forms.ToolStripMenuItem addItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setExportModeToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_CountLBL;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Count;
        private System.Windows.Forms.TreeView treeView_Graphs;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Mark;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Mark;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.DataGridView dataGridView_Export;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Parent;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Export;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton_GlobalExportMode;
        private System.Windows.Forms.ToolStripMenuItem classesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classesWithRelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectsAndClassesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectsAndClassesWithRelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource_GraphItems;
    }
}

