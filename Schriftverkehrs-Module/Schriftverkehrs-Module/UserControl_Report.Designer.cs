namespace Schriftverkehrs_Module
{
    partial class UserControl_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_Report));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_CountLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Count = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Filter = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_ClearFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_AddFilter = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_Report = new System.Windows.Forms.DataGridView();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_ShowDetails = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_AddSchriftverkehr = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Report)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_Report);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(847, 500);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(847, 550);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip3);
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
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBox_Filter,
            this.toolStripButton_ClearFilter,
            this.toolStripButton_AddFilter});
            this.toolStrip2.Location = new System.Drawing.Point(83, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(354, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(94, 22);
            this.toolStripLabel1.Text = "x_Relation-Filter:";
            // 
            // toolStripTextBox_Filter
            // 
            this.toolStripTextBox_Filter.Name = "toolStripTextBox_Filter";
            this.toolStripTextBox_Filter.ReadOnly = true;
            this.toolStripTextBox_Filter.Size = new System.Drawing.Size(200, 25);
            // 
            // toolStripButton_ClearFilter
            // 
            this.toolStripButton_ClearFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ClearFilter.Image = global::Schriftverkehrs_Module.Properties.Resources.TzeenieWheenie_red_green_OK_not_OK_Icons_1;
            this.toolStripButton_ClearFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ClearFilter.Name = "toolStripButton_ClearFilter";
            this.toolStripButton_ClearFilter.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_ClearFilter.Text = "x_Clear";
            this.toolStripButton_ClearFilter.Click += new System.EventHandler(this.toolStripButton_ClearFilter_Click);
            // 
            // toolStripButton_AddFilter
            // 
            this.toolStripButton_AddFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_AddFilter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_AddFilter.Image")));
            this.toolStripButton_AddFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddFilter.Name = "toolStripButton_AddFilter";
            this.toolStripButton_AddFilter.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_AddFilter.Text = "...";
            this.toolStripButton_AddFilter.Click += new System.EventHandler(this.toolStripButton_AddFilter_Click);
            // 
            // dataGridView_Report
            // 
            this.dataGridView_Report.AllowUserToAddRows = false;
            this.dataGridView_Report.AllowUserToDeleteRows = false;
            this.dataGridView_Report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Report.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Report.Name = "dataGridView_Report";
            this.dataGridView_Report.ReadOnly = true;
            this.dataGridView_Report.Size = new System.Drawing.Size(847, 500);
            this.dataGridView_Report.TabIndex = 0;
            this.dataGridView_Report.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Report_RowHeaderMouseDoubleClick);
            this.dataGridView_Report.SelectionChanged += new System.EventHandler(this.dataGridView_Report_SelectionChanged);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_ShowDetails,
            this.toolStripButton_AddSchriftverkehr});
            this.toolStrip3.Location = new System.Drawing.Point(3, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(58, 25);
            this.toolStrip3.TabIndex = 0;
            // 
            // toolStripButton_ShowDetails
            // 
            this.toolStripButton_ShowDetails.CheckOnClick = true;
            this.toolStripButton_ShowDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ShowDetails.Image = global::Schriftverkehrs_Module.Properties.Resources.appunti_architetto_franc_01;
            this.toolStripButton_ShowDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ShowDetails.Name = "toolStripButton_ShowDetails";
            this.toolStripButton_ShowDetails.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_ShowDetails.Text = "toolStripButton2";
            // 
            // toolStripButton_AddSchriftverkehr
            // 
            this.toolStripButton_AddSchriftverkehr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_AddSchriftverkehr.Image = global::Schriftverkehrs_Module.Properties.Resources.b_plus;
            this.toolStripButton_AddSchriftverkehr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddSchriftverkehr.Name = "toolStripButton_AddSchriftverkehr";
            this.toolStripButton_AddSchriftverkehr.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_AddSchriftverkehr.Text = "toolStripButton2";
            this.toolStripButton_AddSchriftverkehr.Click += new System.EventHandler(this.toolStripButton_AddSchriftverkehr_Click);
            // 
            // UserControl_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_Report";
            this.Size = new System.Drawing.Size(847, 550);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Report)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_CountLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Count;
        private System.Windows.Forms.DataGridView dataGridView_Report;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Filter;
        private System.Windows.Forms.ToolStripButton toolStripButton_ClearFilter;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddFilter;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddSchriftverkehr;
        private System.Windows.Forms.ToolStripButton toolStripButton_ShowDetails;
    }
}
