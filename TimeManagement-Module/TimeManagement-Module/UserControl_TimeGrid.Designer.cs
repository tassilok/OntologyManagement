namespace TimeManagement_Module
{
    partial class UserControl_TimeGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_TimeGrid));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_FilterCapt = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Filter = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_RemoveFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_SortCapt = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Sort = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_RemoveSort = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripLabel_CalcCapt = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripTextBox_Calculation = new System.Windows.Forms.ToolStripTextBox();
            this.ToolStripDropDownButton_Calc = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItem_AVG = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Calc_Mult = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_CalcAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_RefFilterLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Ref = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_AddRef = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_RemoveFilterRef = new System.Windows.Forms.ToolStripButton();
            this.DataGridView_LogManagement = new System.Windows.Forms.DataGridView();
            this.ContextMenuStrip_TimeManagement = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.ToolStripDropDownButton_Range = new System.Windows.Forms.ToolStripDropDownButton();
            this.TodayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.YesterdayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XThisWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LastTwoWeeksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XThisMonthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource_TimeManagement = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_LogManagement)).BeginInit();
            this.ContextMenuStrip_TimeManagement.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_TimeManagement)).BeginInit();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.DataGridView_LogManagement);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1211, 379);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1211, 429);
            this.toolStripContainer1.TabIndex = 2;
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
            this.toolStripLabel_FilterCapt,
            this.toolStripTextBox_Filter,
            this.toolStripButton_RemoveFilter,
            this.toolStripSeparator1,
            this.toolStripLabel_SortCapt,
            this.toolStripTextBox_Sort,
            this.toolStripButton_RemoveSort,
            this.toolStripSeparator2,
            this.ToolStripLabel_CalcCapt,
            this.ToolStripTextBox_Calculation,
            this.ToolStripDropDownButton_Calc,
            this.toolStripSeparator3,
            this.toolStripLabel_RefFilterLbl,
            this.toolStripTextBox_Ref,
            this.toolStripButton_AddRef,
            this.toolStripButton_RemoveFilterRef});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1183, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel_FilterCapt
            // 
            this.toolStripLabel_FilterCapt.Name = "toolStripLabel_FilterCapt";
            this.toolStripLabel_FilterCapt.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel_FilterCapt.Text = "x_Filter:";
            // 
            // toolStripTextBox_Filter
            // 
            this.toolStripTextBox_Filter.Name = "toolStripTextBox_Filter";
            this.toolStripTextBox_Filter.Size = new System.Drawing.Size(300, 25);
            this.toolStripTextBox_Filter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox_Filter_KeyDown);
            // 
            // toolStripButton_RemoveFilter
            // 
            this.toolStripButton_RemoveFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_RemoveFilter.Image = global::TimeManagement_Module.Properties.Resources.tasto_8_architetto_franc_01;
            this.toolStripButton_RemoveFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_RemoveFilter.Name = "toolStripButton_RemoveFilter";
            this.toolStripButton_RemoveFilter.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_RemoveFilter.Text = "toolStripButton1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_SortCapt
            // 
            this.toolStripLabel_SortCapt.Name = "toolStripLabel_SortCapt";
            this.toolStripLabel_SortCapt.Size = new System.Drawing.Size(41, 22);
            this.toolStripLabel_SortCapt.Text = "x_Sort:";
            // 
            // toolStripTextBox_Sort
            // 
            this.toolStripTextBox_Sort.Name = "toolStripTextBox_Sort";
            this.toolStripTextBox_Sort.Size = new System.Drawing.Size(200, 25);
            // 
            // toolStripButton_RemoveSort
            // 
            this.toolStripButton_RemoveSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_RemoveSort.Image = global::TimeManagement_Module.Properties.Resources.tasto_8_architetto_franc_01;
            this.toolStripButton_RemoveSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_RemoveSort.Name = "toolStripButton_RemoveSort";
            this.toolStripButton_RemoveSort.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_RemoveSort.Text = "toolStripButton1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripLabel_CalcCapt
            // 
            this.ToolStripLabel_CalcCapt.Name = "ToolStripLabel_CalcCapt";
            this.ToolStripLabel_CalcCapt.Size = new System.Drawing.Size(70, 22);
            this.ToolStripLabel_CalcCapt.Text = "Calculation:";
            // 
            // ToolStripTextBox_Calculation
            // 
            this.ToolStripTextBox_Calculation.Name = "ToolStripTextBox_Calculation";
            this.ToolStripTextBox_Calculation.ReadOnly = true;
            this.ToolStripTextBox_Calculation.Size = new System.Drawing.Size(100, 25);
            // 
            // ToolStripDropDownButton_Calc
            // 
            this.ToolStripDropDownButton_Calc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripDropDownButton_Calc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_AVG,
            this.ToolStripMenuItem_Calc_Mult,
            this.ToolStripMenuItem_CalcAdd});
            this.ToolStripDropDownButton_Calc.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripDropDownButton_Calc.Image")));
            this.ToolStripDropDownButton_Calc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripDropDownButton_Calc.Name = "ToolStripDropDownButton_Calc";
            this.ToolStripDropDownButton_Calc.Size = new System.Drawing.Size(28, 22);
            this.ToolStripDropDownButton_Calc.Text = "+";
            // 
            // ToolStripMenuItem_AVG
            // 
            this.ToolStripMenuItem_AVG.Name = "ToolStripMenuItem_AVG";
            this.ToolStripMenuItem_AVG.Size = new System.Drawing.Size(97, 22);
            this.ToolStripMenuItem_AVG.Text = "AVG";
            this.ToolStripMenuItem_AVG.Click += new System.EventHandler(this.ToolStripMenuItem_AVG_Click);
            // 
            // ToolStripMenuItem_Calc_Mult
            // 
            this.ToolStripMenuItem_Calc_Mult.Name = "ToolStripMenuItem_Calc_Mult";
            this.ToolStripMenuItem_Calc_Mult.Size = new System.Drawing.Size(97, 22);
            this.ToolStripMenuItem_Calc_Mult.Text = "*";
            this.ToolStripMenuItem_Calc_Mult.Click += new System.EventHandler(this.ToolStripMenuItem_Calc_Mult_Click);
            // 
            // ToolStripMenuItem_CalcAdd
            // 
            this.ToolStripMenuItem_CalcAdd.Name = "ToolStripMenuItem_CalcAdd";
            this.ToolStripMenuItem_CalcAdd.Size = new System.Drawing.Size(97, 22);
            this.ToolStripMenuItem_CalcAdd.Text = "+";
            this.ToolStripMenuItem_CalcAdd.Click += new System.EventHandler(this.ToolStripMenuItem_CalcAdd_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_RefFilterLbl
            // 
            this.toolStripLabel_RefFilterLbl.Name = "toolStripLabel_RefFilterLbl";
            this.toolStripLabel_RefFilterLbl.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel_RefFilterLbl.Text = "x_Ref-Filter:";
            // 
            // toolStripTextBox_Ref
            // 
            this.toolStripTextBox_Ref.Name = "toolStripTextBox_Ref";
            this.toolStripTextBox_Ref.ReadOnly = true;
            this.toolStripTextBox_Ref.Size = new System.Drawing.Size(200, 25);
            // 
            // toolStripButton_AddRef
            // 
            this.toolStripButton_AddRef.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_AddRef.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_AddRef.Image")));
            this.toolStripButton_AddRef.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddRef.Name = "toolStripButton_AddRef";
            this.toolStripButton_AddRef.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_AddRef.Text = "...";
            this.toolStripButton_AddRef.Click += new System.EventHandler(this.toolStripButton_AddRef_Click);
            // 
            // toolStripButton_RemoveFilterRef
            // 
            this.toolStripButton_RemoveFilterRef.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_RemoveFilterRef.Image = global::TimeManagement_Module.Properties.Resources.tasto_8_architetto_franc_01;
            this.toolStripButton_RemoveFilterRef.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_RemoveFilterRef.Name = "toolStripButton_RemoveFilterRef";
            this.toolStripButton_RemoveFilterRef.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_RemoveFilterRef.Text = "x_RemoveFilter";
            this.toolStripButton_RemoveFilterRef.Click += new System.EventHandler(this.toolStripButton_RemoveFilterRef_Click);
            // 
            // DataGridView_LogManagement
            // 
            this.DataGridView_LogManagement.AllowUserToAddRows = false;
            this.DataGridView_LogManagement.AllowUserToDeleteRows = false;
            this.DataGridView_LogManagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_LogManagement.ContextMenuStrip = this.ContextMenuStrip_TimeManagement;
            this.DataGridView_LogManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView_LogManagement.Location = new System.Drawing.Point(0, 0);
            this.DataGridView_LogManagement.Name = "DataGridView_LogManagement";
            this.DataGridView_LogManagement.ReadOnly = true;
            this.DataGridView_LogManagement.Size = new System.Drawing.Size(1211, 379);
            this.DataGridView_LogManagement.TabIndex = 2;
            this.DataGridView_LogManagement.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_LogManagement_CellClick);
            this.DataGridView_LogManagement.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView_LogManagement_CellFormatting);
            this.DataGridView_LogManagement.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_LogManagement_RowHeaderMouseClick);
            this.DataGridView_LogManagement.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_LogManagement_RowHeaderMouseDoubleClick);
            this.DataGridView_LogManagement.SelectionChanged += new System.EventHandler(this.DataGridView_LogManagement_SelectionChanged);
            this.DataGridView_LogManagement.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridView_LogManagement_KeyDown);
            // 
            // ContextMenuStrip_TimeManagement
            // 
            this.ContextMenuStrip_TimeManagement.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.EditToolStripMenuItem});
            this.ContextMenuStrip_TimeManagement.Name = "ContextMenuStrip_TimeManagement";
            this.ContextMenuStrip_TimeManagement.Size = new System.Drawing.Size(109, 48);
            this.ContextMenuStrip_TimeManagement.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip_TimeManagement_Opening);
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.NewToolStripMenuItem.Text = "x_New";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.EditToolStripMenuItem.Text = "x_Edit";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripDropDownButton_Range});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(121, 25);
            this.toolStrip2.TabIndex = 1;
            // 
            // ToolStripDropDownButton_Range
            // 
            this.ToolStripDropDownButton_Range.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripDropDownButton_Range.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TodayToolStripMenuItem,
            this.YesterdayToolStripMenuItem,
            this.XThisWeekToolStripMenuItem,
            this.LastTwoWeeksToolStripMenuItem,
            this.XThisMonthToolStripMenuItem,
            this.AllToolStripMenuItem});
            this.ToolStripDropDownButton_Range.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripDropDownButton_Range.Image")));
            this.ToolStripDropDownButton_Range.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripDropDownButton_Range.Name = "ToolStripDropDownButton_Range";
            this.ToolStripDropDownButton_Range.Size = new System.Drawing.Size(109, 22);
            this.ToolStripDropDownButton_Range.Text = "x_Last two weeks";
            // 
            // TodayToolStripMenuItem
            // 
            this.TodayToolStripMenuItem.Name = "TodayToolStripMenuItem";
            this.TodayToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.TodayToolStripMenuItem.Text = "x_Today";
            this.TodayToolStripMenuItem.Click += new System.EventHandler(this.TodayToolStripMenuItem_Click);
            // 
            // YesterdayToolStripMenuItem
            // 
            this.YesterdayToolStripMenuItem.Name = "YesterdayToolStripMenuItem";
            this.YesterdayToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.YesterdayToolStripMenuItem.Text = "x_Yesterday";
            this.YesterdayToolStripMenuItem.Click += new System.EventHandler(this.YesterdayToolStripMenuItem_Click);
            // 
            // XThisWeekToolStripMenuItem
            // 
            this.XThisWeekToolStripMenuItem.Name = "XThisWeekToolStripMenuItem";
            this.XThisWeekToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.XThisWeekToolStripMenuItem.Text = "x_This Week";
            this.XThisWeekToolStripMenuItem.Click += new System.EventHandler(this.XThisWeekToolStripMenuItem_Click);
            // 
            // LastTwoWeeksToolStripMenuItem
            // 
            this.LastTwoWeeksToolStripMenuItem.Name = "LastTwoWeeksToolStripMenuItem";
            this.LastTwoWeeksToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.LastTwoWeeksToolStripMenuItem.Text = "x_Last two weeks";
            this.LastTwoWeeksToolStripMenuItem.Click += new System.EventHandler(this.LastTwoWeeksToolStripMenuItem_Click);
            // 
            // XThisMonthToolStripMenuItem
            // 
            this.XThisMonthToolStripMenuItem.Name = "XThisMonthToolStripMenuItem";
            this.XThisMonthToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.XThisMonthToolStripMenuItem.Text = "x_This Month";
            this.XThisMonthToolStripMenuItem.Click += new System.EventHandler(this.XThisMonthToolStripMenuItem_Click);
            // 
            // AllToolStripMenuItem
            // 
            this.AllToolStripMenuItem.Name = "AllToolStripMenuItem";
            this.AllToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.AllToolStripMenuItem.Text = "x_All";
            this.AllToolStripMenuItem.Click += new System.EventHandler(this.AllToolStripMenuItem_Click);
            // 
            // UserControl_TimeGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_TimeGrid";
            this.Size = new System.Drawing.Size(1211, 429);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_LogManagement)).EndInit();
            this.ContextMenuStrip_TimeManagement.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_TimeManagement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_FilterCapt;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Filter;
        private System.Windows.Forms.ToolStripButton toolStripButton_RemoveFilter;
        internal System.Windows.Forms.DataGridView DataGridView_LogManagement;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_SortCapt;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Sort;
        private System.Windows.Forms.ToolStripButton toolStripButton_RemoveSort;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripLabel ToolStripLabel_CalcCapt;
        internal System.Windows.Forms.ToolStripTextBox ToolStripTextBox_Calculation;
        internal System.Windows.Forms.ToolStripDropDownButton ToolStripDropDownButton_Calc;
        internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_AVG;
        internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Calc_Mult;
        internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_CalcAdd;
        private System.Windows.Forms.BindingSource bindingSource_TimeManagement;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip_TimeManagement;
        internal System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip2;
        internal System.Windows.Forms.ToolStripDropDownButton ToolStripDropDownButton_Range;
        internal System.Windows.Forms.ToolStripMenuItem TodayToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem YesterdayToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem XThisWeekToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem LastTwoWeeksToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem XThisMonthToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem AllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_RefFilterLbl;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Ref;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddRef;
        private System.Windows.Forms.ToolStripButton toolStripButton_RemoveFilterRef;

    }
}
