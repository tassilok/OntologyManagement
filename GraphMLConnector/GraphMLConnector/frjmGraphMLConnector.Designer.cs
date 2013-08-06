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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_Export = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_Export = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setExportModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Export = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton_GlobalExportMode = new System.Windows.Forms.ToolStripSplitButton();
            this.classesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classesWithRelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectsAndClassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectsAndClassesWithRelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtblExportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Export = new GraphMLConnector.DataSet_Export();
            this.iDItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Parent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDExportModeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameExportModeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Export)).BeginInit();
            this.contextMenuStrip_Export.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtblExportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Export)).BeginInit();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_Export);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(680, 437);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(680, 487);
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
            // 
            // dataGridView_Export
            // 
            this.dataGridView_Export.AllowUserToAddRows = false;
            this.dataGridView_Export.AllowUserToDeleteRows = false;
            this.dataGridView_Export.AutoGenerateColumns = false;
            this.dataGridView_Export.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Export.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDItemDataGridViewTextBoxColumn,
            this.nameItemDataGridViewTextBoxColumn,
            this.ID_Parent,
            this.typeItemDataGridViewTextBoxColumn,
            this.iDExportModeDataGridViewTextBoxColumn,
            this.nameExportModeDataGridViewTextBoxColumn});
            this.dataGridView_Export.ContextMenuStrip = this.contextMenuStrip_Export;
            this.dataGridView_Export.DataSource = this.dtblExportBindingSource;
            this.dataGridView_Export.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Export.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Export.Name = "dataGridView_Export";
            this.dataGridView_Export.ReadOnly = true;
            this.dataGridView_Export.Size = new System.Drawing.Size(680, 437);
            this.dataGridView_Export.TabIndex = 0;
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
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Export,
            this.toolStripSplitButton_GlobalExportMode});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(203, 25);
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
            // dtblExportBindingSource
            // 
            this.dtblExportBindingSource.DataMember = "dtbl_Export";
            this.dtblExportBindingSource.DataSource = this.dataSet_Export;
            // 
            // dataSet_Export
            // 
            this.dataSet_Export.DataSetName = "DataSet_Export";
            this.dataSet_Export.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // iDItemDataGridViewTextBoxColumn
            // 
            this.iDItemDataGridViewTextBoxColumn.DataPropertyName = "ID_Item";
            this.iDItemDataGridViewTextBoxColumn.HeaderText = "ID_Item";
            this.iDItemDataGridViewTextBoxColumn.Name = "iDItemDataGridViewTextBoxColumn";
            this.iDItemDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDItemDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameItemDataGridViewTextBoxColumn
            // 
            this.nameItemDataGridViewTextBoxColumn.DataPropertyName = "Name_Item";
            this.nameItemDataGridViewTextBoxColumn.HeaderText = "Name_Item";
            this.nameItemDataGridViewTextBoxColumn.Name = "nameItemDataGridViewTextBoxColumn";
            this.nameItemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ID_Parent
            // 
            this.ID_Parent.DataPropertyName = "ID_Parent";
            this.ID_Parent.HeaderText = "ID_Parent";
            this.ID_Parent.Name = "ID_Parent";
            this.ID_Parent.ReadOnly = true;
            this.ID_Parent.Visible = false;
            // 
            // typeItemDataGridViewTextBoxColumn
            // 
            this.typeItemDataGridViewTextBoxColumn.DataPropertyName = "Type_Item";
            this.typeItemDataGridViewTextBoxColumn.HeaderText = "Type_Item";
            this.typeItemDataGridViewTextBoxColumn.Name = "typeItemDataGridViewTextBoxColumn";
            this.typeItemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iDExportModeDataGridViewTextBoxColumn
            // 
            this.iDExportModeDataGridViewTextBoxColumn.DataPropertyName = "ID_ExportMode";
            this.iDExportModeDataGridViewTextBoxColumn.HeaderText = "ID_ExportMode";
            this.iDExportModeDataGridViewTextBoxColumn.Name = "iDExportModeDataGridViewTextBoxColumn";
            this.iDExportModeDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDExportModeDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameExportModeDataGridViewTextBoxColumn
            // 
            this.nameExportModeDataGridViewTextBoxColumn.DataPropertyName = "Name_ExportMode";
            this.nameExportModeDataGridViewTextBoxColumn.HeaderText = "Name_ExportMode";
            this.nameExportModeDataGridViewTextBoxColumn.Name = "nameExportModeDataGridViewTextBoxColumn";
            this.nameExportModeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmGraphMLConnector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 487);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmGraphMLConnector";
            this.Text = "Graph-ML Connector";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Export)).EndInit();
            this.contextMenuStrip_Export.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtblExportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Export)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.DataGridView dataGridView_Export;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Export;
        private System.Windows.Forms.ToolStripMenuItem addItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setExportModeToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Export;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton_GlobalExportMode;
        private System.Windows.Forms.ToolStripMenuItem classesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classesWithRelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectsAndClassesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectsAndClassesWithRelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.BindingSource dtblExportBindingSource;
        private DataSet_Export dataSet_Export;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Parent;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDExportModeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameExportModeDataGridViewTextBoxColumn;
    }
}

