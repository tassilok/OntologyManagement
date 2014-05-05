namespace OutlookConnector_Module
{
    partial class UserControl_OutlookItemList
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_CountCapt = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Count = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_FilterCapt = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Filter = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_ClearFilter = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_OutlookItems = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_OutlookItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.differentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.containsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_contains = new System.Windows.Forms.ToolStripTextBox();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createOntologyItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outlookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OutlookItems)).BeginInit();
            this.contextMenuStrip_OutlookItems.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_OutlookItems);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(567, 447);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(567, 497);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_CountCapt,
            this.toolStripLabel_Count,
            this.toolStripSeparator1,
            this.toolStripLabel_FilterCapt,
            this.toolStripLabel_Filter,
            this.toolStripButton_ClearFilter});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(165, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel_CountCapt
            // 
            this.toolStripLabel_CountCapt.Name = "toolStripLabel_CountCapt";
            this.toolStripLabel_CountCapt.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel_CountCapt.Text = "x_Count:";
            // 
            // toolStripLabel_Count
            // 
            this.toolStripLabel_Count.Name = "toolStripLabel_Count";
            this.toolStripLabel_Count.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel_Count.Text = "0";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_FilterCapt
            // 
            this.toolStripLabel_FilterCapt.Name = "toolStripLabel_FilterCapt";
            this.toolStripLabel_FilterCapt.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel_FilterCapt.Text = "x_Filter:";
            // 
            // toolStripLabel_Filter
            // 
            this.toolStripLabel_Filter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel_Filter.Name = "toolStripLabel_Filter";
            this.toolStripLabel_Filter.Size = new System.Drawing.Size(12, 22);
            this.toolStripLabel_Filter.Text = "-";
            // 
            // toolStripButton_ClearFilter
            // 
            this.toolStripButton_ClearFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ClearFilter.Image = global::OutlookConnector_Module.Properties.Resources.tasto_8_architetto_franc_01;
            this.toolStripButton_ClearFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ClearFilter.Name = "toolStripButton_ClearFilter";
            this.toolStripButton_ClearFilter.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_ClearFilter.Text = "toolStripButton1";
            this.toolStripButton_ClearFilter.Click += new System.EventHandler(this.toolStripButton_ClearFilter_Click);
            // 
            // dataGridView_OutlookItems
            // 
            this.dataGridView_OutlookItems.AllowUserToAddRows = false;
            this.dataGridView_OutlookItems.AllowUserToDeleteRows = false;
            this.dataGridView_OutlookItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_OutlookItems.ContextMenuStrip = this.contextMenuStrip_OutlookItems;
            this.dataGridView_OutlookItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_OutlookItems.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_OutlookItems.Name = "dataGridView_OutlookItems";
            this.dataGridView_OutlookItems.ReadOnly = true;
            this.dataGridView_OutlookItems.Size = new System.Drawing.Size(567, 447);
            this.dataGridView_OutlookItems.TabIndex = 1;
            this.dataGridView_OutlookItems.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_OutlookItems_RowHeaderMouseDoubleClick);
            this.dataGridView_OutlookItems.SelectionChanged += new System.EventHandler(this.dataGridView_OutlookItems_SelectionChanged);
            // 
            // contextMenuStrip_OutlookItems
            // 
            this.contextMenuStrip_OutlookItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterToolStripMenuItem,
            this.editToolStripMenuItem,
            this.outlookToolStripMenuItem,
            this.applyToolStripMenuItem});
            this.contextMenuStrip_OutlookItems.Name = "contextMenuStrip_OutlookItems";
            this.contextMenuStrip_OutlookItems.Size = new System.Drawing.Size(153, 114);
            this.contextMenuStrip_OutlookItems.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_OutlookItems_Opening);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.equalToolStripMenuItem,
            this.differentToolStripMenuItem,
            this.containsToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.filterToolStripMenuItem.Text = "x_Filter";
            // 
            // equalToolStripMenuItem
            // 
            this.equalToolStripMenuItem.Name = "equalToolStripMenuItem";
            this.equalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.equalToolStripMenuItem.Text = "x_equal";
            this.equalToolStripMenuItem.Click += new System.EventHandler(this.equalToolStripMenuItem_Click);
            // 
            // differentToolStripMenuItem
            // 
            this.differentToolStripMenuItem.Name = "differentToolStripMenuItem";
            this.differentToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.differentToolStripMenuItem.Text = "x_different";
            this.differentToolStripMenuItem.Click += new System.EventHandler(this.differentToolStripMenuItem_Click);
            // 
            // containsToolStripMenuItem
            // 
            this.containsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_contains});
            this.containsToolStripMenuItem.Name = "containsToolStripMenuItem";
            this.containsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.containsToolStripMenuItem.Text = "x_contains";
            this.containsToolStripMenuItem.Click += new System.EventHandler(this.containsToolStripMenuItem_Click);
            // 
            // toolStripTextBox_contains
            // 
            this.toolStripTextBox_contains.Name = "toolStripTextBox_contains";
            this.toolStripTextBox_contains.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox_contains.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox_contains_KeyDown);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Image = global::OutlookConnector_Module.Properties.Resources.tasto_8_architetto_franc_01;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.clearToolStripMenuItem.Text = "x_Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createOntologyItemToolStripMenuItem});
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItem.Text = "x_Edit";
            // 
            // createOntologyItemToolStripMenuItem
            // 
            this.createOntologyItemToolStripMenuItem.Name = "createOntologyItemToolStripMenuItem";
            this.createOntologyItemToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.createOntologyItemToolStripMenuItem.Text = "x_Create Ontology-Item";
            this.createOntologyItemToolStripMenuItem.Click += new System.EventHandler(this.createOntologyItemToolStripMenuItem_Click);
            // 
            // outlookToolStripMenuItem
            // 
            this.outlookToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMailToolStripMenuItem});
            this.outlookToolStripMenuItem.Name = "outlookToolStripMenuItem";
            this.outlookToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.outlookToolStripMenuItem.Text = "x_Outlook";
            // 
            // openMailToolStripMenuItem
            // 
            this.openMailToolStripMenuItem.Name = "openMailToolStripMenuItem";
            this.openMailToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openMailToolStripMenuItem.Text = "x_Open Mail";
            this.openMailToolStripMenuItem.Click += new System.EventHandler(this.openMailToolStripMenuItem_Click);
            // 
            // applyToolStripMenuItem
            // 
            this.applyToolStripMenuItem.Enabled = false;
            this.applyToolStripMenuItem.Name = "applyToolStripMenuItem";
            this.applyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.applyToolStripMenuItem.Text = "x_Apply";
            this.applyToolStripMenuItem.Click += new System.EventHandler(this.applyToolStripMenuItem_Click);
            // 
            // UserControl_OutlookItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_OutlookItemList";
            this.Size = new System.Drawing.Size(567, 497);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OutlookItems)).EndInit();
            this.contextMenuStrip_OutlookItems.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dataGridView_OutlookItems;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_CountCapt;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Count;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_FilterCapt;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Filter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_OutlookItems;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem differentToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton_ClearFilter;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createOntologyItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outlookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem containsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_contains;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyToolStripMenuItem;

    }
}
