namespace Typed_Tagging_Module
{
    partial class UserControl_TagReport
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
            this.toolStripLabel_SemFilter = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_SemFilter = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_Filter = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox_Filter = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel_Sort = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Sort = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_ClearFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_CountLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Count = new System.Windows.Forms.ToolStripLabel();
            this.dataGridView_Report = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_Report = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSemanticFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.differentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.containsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_Contains = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.RightToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Report)).BeginInit();
            this.contextMenuStrip_Report.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_Report);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(877, 415);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            this.toolStripContainer1.RightToolStripPanel.Controls.Add(this.toolStrip2);
            this.toolStripContainer1.Size = new System.Drawing.Size(903, 465);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_SemFilter,
            this.toolStripTextBox_SemFilter,
            this.toolStripSeparator1,
            this.toolStripLabel_Filter,
            this.toolStripComboBox_Filter,
            this.toolStripLabel_Sort,
            this.toolStripTextBox_Sort,
            this.toolStripSeparator2,
            this.toolStripButton_ClearFilter,
            this.toolStripSeparator3,
            this.toolStripLabel_CountLbl,
            this.toolStripLabel_Count});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(812, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel_SemFilter
            // 
            this.toolStripLabel_SemFilter.Name = "toolStripLabel_SemFilter";
            this.toolStripLabel_SemFilter.Size = new System.Drawing.Size(100, 22);
            this.toolStripLabel_SemFilter.Text = "x_Semantic-Filter:";
            // 
            // toolStripTextBox_SemFilter
            // 
            this.toolStripTextBox_SemFilter.Name = "toolStripTextBox_SemFilter";
            this.toolStripTextBox_SemFilter.ReadOnly = true;
            this.toolStripTextBox_SemFilter.Size = new System.Drawing.Size(150, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_Filter
            // 
            this.toolStripLabel_Filter.Name = "toolStripLabel_Filter";
            this.toolStripLabel_Filter.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel_Filter.Text = "x_Filter:";
            // 
            // toolStripComboBox_Filter
            // 
            this.toolStripComboBox_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox_Filter.Name = "toolStripComboBox_Filter";
            this.toolStripComboBox_Filter.Size = new System.Drawing.Size(150, 25);
            this.toolStripComboBox_Filter.DropDownClosed += new System.EventHandler(this.toolStripComboBox_Filter_DropDownClosed);
            this.toolStripComboBox_Filter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripComboBox_Filter_MouseDown);
            // 
            // toolStripLabel_Sort
            // 
            this.toolStripLabel_Sort.Name = "toolStripLabel_Sort";
            this.toolStripLabel_Sort.Size = new System.Drawing.Size(41, 22);
            this.toolStripLabel_Sort.Text = "x_Sort:";
            // 
            // toolStripTextBox_Sort
            // 
            this.toolStripTextBox_Sort.Name = "toolStripTextBox_Sort";
            this.toolStripTextBox_Sort.Size = new System.Drawing.Size(200, 25);
            this.toolStripTextBox_Sort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxSort_KeyDown);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_ClearFilter
            // 
            this.toolStripButton_ClearFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ClearFilter.Image = global::Typed_Tagging_Module.Properties.Resources.tasto_8_architetto_franc_01;
            this.toolStripButton_ClearFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ClearFilter.Name = "toolStripButton_ClearFilter";
            this.toolStripButton_ClearFilter.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_ClearFilter.Text = "toolStripButton1";
            this.toolStripButton_ClearFilter.Click += new System.EventHandler(this.toolStripButton_ClearFilter_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            // dataGridView_Report
            // 
            this.dataGridView_Report.AllowUserToAddRows = false;
            this.dataGridView_Report.AllowUserToDeleteRows = false;
            this.dataGridView_Report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Report.ContextMenuStrip = this.contextMenuStrip_Report;
            this.dataGridView_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Report.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Report.Name = "dataGridView_Report";
            this.dataGridView_Report.ReadOnly = true;
            this.dataGridView_Report.Size = new System.Drawing.Size(877, 415);
            this.dataGridView_Report.TabIndex = 0;
            this.dataGridView_Report.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Report_CellContentDoubleClick);
            this.dataGridView_Report.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_Report_DataBindingComplete);
            // 
            // contextMenuStrip_Report
            // 
            this.contextMenuStrip_Report.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterToolStripMenuItem,
            this.openToolStripMenuItem});
            this.contextMenuStrip_Report.Name = "contextMenuStrip_Report";
            this.contextMenuStrip_Report.Size = new System.Drawing.Size(114, 48);
            this.contextMenuStrip_Report.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Report_Opening);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSemanticFilterToolStripMenuItem,
            this.equalToolStripMenuItem,
            this.differentToolStripMenuItem,
            this.containsToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.filterToolStripMenuItem.Text = "x_Filter";
            // 
            // addSemanticFilterToolStripMenuItem
            // 
            this.addSemanticFilterToolStripMenuItem.Name = "addSemanticFilterToolStripMenuItem";
            this.addSemanticFilterToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.addSemanticFilterToolStripMenuItem.Text = "x_Add Semantic-Filter";
            this.addSemanticFilterToolStripMenuItem.Click += new System.EventHandler(this.addSemanticFilterToolStripMenuItem_Click);
            // 
            // equalToolStripMenuItem
            // 
            this.equalToolStripMenuItem.Name = "equalToolStripMenuItem";
            this.equalToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.equalToolStripMenuItem.Text = "equal";
            this.equalToolStripMenuItem.Click += new System.EventHandler(this.equalToolStripMenuItem_Click);
            // 
            // differentToolStripMenuItem
            // 
            this.differentToolStripMenuItem.Name = "differentToolStripMenuItem";
            this.differentToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.differentToolStripMenuItem.Text = "different";
            this.differentToolStripMenuItem.Click += new System.EventHandler(this.differentToolStripMenuItem_Click);
            // 
            // containsToolStripMenuItem
            // 
            this.containsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_Contains});
            this.containsToolStripMenuItem.Name = "containsToolStripMenuItem";
            this.containsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.containsToolStripMenuItem.Text = "contains";
            this.containsToolStripMenuItem.Click += new System.EventHandler(this.containsToolStripMenuItem_Click);
            // 
            // toolStripTextBox_Contains
            // 
            this.toolStripTextBox_Contains.Name = "toolStripTextBox_Contains";
            this.toolStripTextBox_Contains.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Location = new System.Drawing.Point(0, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(26, 111);
            this.toolStrip2.TabIndex = 0;
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "x_Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // UserControl_TagReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_TagReport";
            this.Size = new System.Drawing.Size(903, 465);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.RightToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.RightToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Report)).EndInit();
            this.contextMenuStrip_Report.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dataGridView_Report;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_SemFilter;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_SemFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Filter;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Sort;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Sort;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_ClearFilter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Report;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSemanticFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_CountLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Count;
        private System.Windows.Forms.ToolStripMenuItem equalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem differentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem containsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Contains;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_Filter;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    }
}
