namespace ESMaintenance_Module
{
    partial class UserControl_ElasticSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_ElasticSearch));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_PagesLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_PageFirst = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_PagePrevious = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_PageNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_PageLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_PageCur = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_CountLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Count = new System.Windows.Forms.ToolStripLabel();
            this.dataGridView_IndexView = new System.Windows.Forms.DataGridView();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox_Indexes = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripDropDownButton_IndexWork = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_DeleteIndex = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToJsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_Query = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Query = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_Search = new System.Windows.Forms.ToolStripButton();
            this.bindingSource_Items = new System.Windows.Forms.BindingSource(this.components);
            this.folderBrowserDialog_ExportImport = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStripTextBox_Type = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IndexView)).BeginInit();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Items)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_IndexView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1060, 556);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1060, 606);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip3);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripTextBox1,
            this.toolStripSeparator1,
            this.toolStripLabel_PagesLbl,
            this.toolStripButton_PageFirst,
            this.toolStripButton_PagePrevious,
            this.toolStripButton_PageNext,
            this.toolStripButton_PageLast,
            this.toolStripLabel_PageCur,
            this.toolStripSeparator2,
            this.toolStripLabel_CountLbl,
            this.toolStripLabel_Count});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(555, 25);
            this.toolStrip2.TabIndex = 2;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel2.Text = "x-Index:";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(200, 25);
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_PagesLbl
            // 
            this.toolStripLabel_PagesLbl.Name = "toolStripLabel_PagesLbl";
            this.toolStripLabel_PagesLbl.Size = new System.Drawing.Size(51, 22);
            this.toolStripLabel_PagesLbl.Text = "x-Pages:";
            // 
            // toolStripButton_PageFirst
            // 
            this.toolStripButton_PageFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_PageFirst.Image = global::ESMaintenance_Module.Properties.Resources.pulsante_01_architetto_f_01_First1;
            this.toolStripButton_PageFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_PageFirst.Name = "toolStripButton_PageFirst";
            this.toolStripButton_PageFirst.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_PageFirst.Text = "toolStripButton1";
            this.toolStripButton_PageFirst.Click += new System.EventHandler(this.toolStripButton_PageFirst_Click);
            // 
            // toolStripButton_PagePrevious
            // 
            this.toolStripButton_PagePrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_PagePrevious.Image = global::ESMaintenance_Module.Properties.Resources.pulsante_01_architetto_f_01;
            this.toolStripButton_PagePrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_PagePrevious.Name = "toolStripButton_PagePrevious";
            this.toolStripButton_PagePrevious.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_PagePrevious.Text = "toolStripButton2";
            this.toolStripButton_PagePrevious.Click += new System.EventHandler(this.toolStripButton_PagePrevious_Click);
            // 
            // toolStripButton_PageNext
            // 
            this.toolStripButton_PageNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_PageNext.Image = global::ESMaintenance_Module.Properties.Resources.pulsante_02_architetto_f_01;
            this.toolStripButton_PageNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_PageNext.Name = "toolStripButton_PageNext";
            this.toolStripButton_PageNext.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_PageNext.Text = "toolStripButton3";
            this.toolStripButton_PageNext.Click += new System.EventHandler(this.toolStripButton_PageNext_Click);
            // 
            // toolStripButton_PageLast
            // 
            this.toolStripButton_PageLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_PageLast.Image = global::ESMaintenance_Module.Properties.Resources.pulsante_02_architetto_f_01_Last;
            this.toolStripButton_PageLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_PageLast.Name = "toolStripButton_PageLast";
            this.toolStripButton_PageLast.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_PageLast.Text = "toolStripButton4";
            this.toolStripButton_PageLast.Click += new System.EventHandler(this.toolStripButton_PageLast_Click);
            // 
            // toolStripLabel_PageCur
            // 
            this.toolStripLabel_PageCur.Name = "toolStripLabel_PageCur";
            this.toolStripLabel_PageCur.Size = new System.Drawing.Size(24, 22);
            this.toolStripLabel_PageCur.Text = "0/0";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_CountLbl
            // 
            this.toolStripLabel_CountLbl.Name = "toolStripLabel_CountLbl";
            this.toolStripLabel_CountLbl.Size = new System.Drawing.Size(90, 22);
            this.toolStripLabel_CountLbl.Text = "x_Count (Docs):";
            // 
            // toolStripLabel_Count
            // 
            this.toolStripLabel_Count.Name = "toolStripLabel_Count";
            this.toolStripLabel_Count.Size = new System.Drawing.Size(24, 22);
            this.toolStripLabel_Count.Text = "0/0";
            // 
            // dataGridView_IndexView
            // 
            this.dataGridView_IndexView.AllowUserToAddRows = false;
            this.dataGridView_IndexView.AllowUserToDeleteRows = false;
            this.dataGridView_IndexView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_IndexView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_IndexView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_IndexView.Name = "dataGridView_IndexView";
            this.dataGridView_IndexView.ReadOnly = true;
            this.dataGridView_IndexView.Size = new System.Drawing.Size(1060, 556);
            this.dataGridView_IndexView.TabIndex = 1;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.toolStripComboBox_Indexes,
            this.toolStripLabel1,
            this.toolStripTextBox_Type,
            this.toolStripDropDownButton_IndexWork,
            this.toolStripSeparator3,
            this.toolStripLabel_Query,
            this.toolStripTextBox_Query,
            this.toolStripButton_Search});
            this.toolStrip3.Location = new System.Drawing.Point(3, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(943, 25);
            this.toolStrip3.TabIndex = 1;
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel3.Text = "x_Index:";
            // 
            // toolStripComboBox_Indexes
            // 
            this.toolStripComboBox_Indexes.Name = "toolStripComboBox_Indexes";
            this.toolStripComboBox_Indexes.Size = new System.Drawing.Size(200, 25);
            this.toolStripComboBox_Indexes.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_Indexes_SelectedIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel1.Text = "x_Type:";
            // 
            // toolStripDropDownButton_IndexWork
            // 
            this.toolStripDropDownButton_IndexWork.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton_IndexWork.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DeleteIndex,
            this.saveToJsonToolStripMenuItem});
            this.toolStripDropDownButton_IndexWork.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_IndexWork.Image")));
            this.toolStripDropDownButton_IndexWork.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_IndexWork.Name = "toolStripDropDownButton_IndexWork";
            this.toolStripDropDownButton_IndexWork.Size = new System.Drawing.Size(86, 22);
            this.toolStripDropDownButton_IndexWork.Text = "x_IndexWork";
            // 
            // toolStripMenuItem_DeleteIndex
            // 
            this.toolStripMenuItem_DeleteIndex.Name = "toolStripMenuItem_DeleteIndex";
            this.toolStripMenuItem_DeleteIndex.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_DeleteIndex.Text = "x_Delete Index";
            // 
            // saveToJsonToolStripMenuItem
            // 
            this.saveToJsonToolStripMenuItem.Name = "saveToJsonToolStripMenuItem";
            this.saveToJsonToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToJsonToolStripMenuItem.Text = "x_Save To Json";
            this.saveToJsonToolStripMenuItem.Click += new System.EventHandler(this.saveToJsonToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_Query
            // 
            this.toolStripLabel_Query.Name = "toolStripLabel_Query";
            this.toolStripLabel_Query.Size = new System.Drawing.Size(52, 22);
            this.toolStripLabel_Query.Text = "x_Query:";
            // 
            // toolStripTextBox_Query
            // 
            this.toolStripTextBox_Query.Name = "toolStripTextBox_Query";
            this.toolStripTextBox_Query.Size = new System.Drawing.Size(300, 25);
            // 
            // toolStripButton_Search
            // 
            this.toolStripButton_Search.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Search.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Search.Image")));
            this.toolStripButton_Search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Search.Name = "toolStripButton_Search";
            this.toolStripButton_Search.Size = new System.Drawing.Size(56, 22);
            this.toolStripButton_Search.Text = "x_Search";
            this.toolStripButton_Search.Click += new System.EventHandler(this.toolStripButton_Search_Click);
            // 
            // toolStripTextBox_Type
            // 
            this.toolStripTextBox_Type.Name = "toolStripTextBox_Type";
            this.toolStripTextBox_Type.Size = new System.Drawing.Size(100, 25);
            // 
            // UserControl_ElasticSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_ElasticSearch";
            this.Size = new System.Drawing.Size(1060, 606);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IndexView)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Items)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_Indexes;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_IndexWork;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DeleteIndex;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Query;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Query;
        private System.Windows.Forms.ToolStripButton toolStripButton_Search;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_PagesLbl;
        private System.Windows.Forms.ToolStripButton toolStripButton_PageFirst;
        private System.Windows.Forms.ToolStripButton toolStripButton_PagePrevious;
        private System.Windows.Forms.ToolStripButton toolStripButton_PageNext;
        private System.Windows.Forms.ToolStripButton toolStripButton_PageLast;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_PageCur;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_CountLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Count;
        private System.Windows.Forms.BindingSource bindingSource_Items;
        private System.Windows.Forms.DataGridView dataGridView_IndexView;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripMenuItem saveToJsonToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_ExportImport;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Type;
    }
}
