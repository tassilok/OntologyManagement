namespace File_Analyzer_Module
{
    partial class frmFileAnaylzer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileAnaylzer));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_CountLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Count = new System.Windows.Forms.ToolStripLabel();
            this.dataGridView_FileContent = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_Edit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.differentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_Regex = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_OpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_FilePath = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_FilterLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_Filter = new System.Windows.Forms.ToolStripLabel();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.containsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_Contains = new System.Windows.Forms.ToolStripTextBox();
            this.containsNotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_ContainsNot = new System.Windows.Forms.ToolStripTextBox();
            this.regexNotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_RegExNot = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FileContent)).BeginInit();
            this.contextMenuStrip_Edit.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_FileContent);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(786, 482);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(786, 532);
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
            this.toolStripButton_Close,
            this.toolStripSeparator1,
            this.toolStripLabel_CountLbl,
            this.toolStripLabel_Count,
            this.toolStripSeparator2,
            this.toolStripLabel_FilterLbl,
            this.toolStripLabel_Filter});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(198, 25);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // dataGridView_FileContent
            // 
            this.dataGridView_FileContent.AllowUserToAddRows = false;
            this.dataGridView_FileContent.AllowUserToDeleteRows = false;
            this.dataGridView_FileContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_FileContent.ContextMenuStrip = this.contextMenuStrip_Edit;
            this.dataGridView_FileContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_FileContent.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_FileContent.Name = "dataGridView_FileContent";
            this.dataGridView_FileContent.ReadOnly = true;
            this.dataGridView_FileContent.Size = new System.Drawing.Size(786, 482);
            this.dataGridView_FileContent.TabIndex = 0;
            // 
            // contextMenuStrip_Edit
            // 
            this.contextMenuStrip_Edit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterToolStripMenuItem});
            this.contextMenuStrip_Edit.Name = "contextMenuStrip_Edit";
            this.contextMenuStrip_Edit.Size = new System.Drawing.Size(153, 48);
            this.contextMenuStrip_Edit.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Edit_Opening);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.equalToolStripMenuItem,
            this.differentToolStripMenuItem,
            this.regexToolStripMenuItem,
            this.regexNotToolStripMenuItem,
            this.containsToolStripMenuItem,
            this.containsNotToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.filterToolStripMenuItem.Text = "x_Filter";
            // 
            // equalToolStripMenuItem
            // 
            this.equalToolStripMenuItem.Name = "equalToolStripMenuItem";
            this.equalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.equalToolStripMenuItem.Text = "x_equal";
            this.equalToolStripMenuItem.Click += new System.EventHandler(this.equalToolStripMenuItem_Click);
            // 
            // differentToolStripMenuItem
            // 
            this.differentToolStripMenuItem.Name = "differentToolStripMenuItem";
            this.differentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.differentToolStripMenuItem.Text = "x_different";
            this.differentToolStripMenuItem.Click += new System.EventHandler(this.differentToolStripMenuItem_Click);
            // 
            // regexToolStripMenuItem
            // 
            this.regexToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_Regex});
            this.regexToolStripMenuItem.Name = "regexToolStripMenuItem";
            this.regexToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.regexToolStripMenuItem.Text = "x_regex";
            this.regexToolStripMenuItem.Click += new System.EventHandler(this.regexToolStripMenuItem_Click);
            // 
            // toolStripTextBox_Regex
            // 
            this.toolStripTextBox_Regex.Name = "toolStripTextBox_Regex";
            this.toolStripTextBox_Regex.Size = new System.Drawing.Size(200, 23);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_OpenFile,
            this.toolStripLabel1,
            this.toolStripLabel_FilePath});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(133, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripButton_OpenFile
            // 
            this.toolStripButton_OpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_OpenFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_OpenFile.Image")));
            this.toolStripButton_OpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_OpenFile.Name = "toolStripButton_OpenFile";
            this.toolStripButton_OpenFile.Size = new System.Drawing.Size(71, 22);
            this.toolStripButton_OpenFile.Text = "x_Open File";
            this.toolStripButton_OpenFile.Click += new System.EventHandler(this.toolStripButton_OpenFile_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(38, 22);
            this.toolStripLabel1.Text = "x_File:";
            // 
            // toolStripLabel_FilePath
            // 
            this.toolStripLabel_FilePath.Name = "toolStripLabel_FilePath";
            this.toolStripLabel_FilePath.Size = new System.Drawing.Size(12, 22);
            this.toolStripLabel_FilePath.Text = "-";
            // 
            // toolStripLabel_FilterLbl
            // 
            this.toolStripLabel_FilterLbl.Name = "toolStripLabel_FilterLbl";
            this.toolStripLabel_FilterLbl.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel_FilterLbl.Text = "x_Filter:";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_Filter
            // 
            this.toolStripLabel_Filter.Name = "toolStripLabel_Filter";
            this.toolStripLabel_Filter.Size = new System.Drawing.Size(12, 22);
            this.toolStripLabel_Filter.Text = "-";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearToolStripMenuItem.Text = "x_Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // containsToolStripMenuItem
            // 
            this.containsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_Contains});
            this.containsToolStripMenuItem.Name = "containsToolStripMenuItem";
            this.containsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.containsToolStripMenuItem.Text = "x_contains";
            this.containsToolStripMenuItem.Click += new System.EventHandler(this.containsToolStripMenuItem_Click);
            // 
            // toolStripTextBox_Contains
            // 
            this.toolStripTextBox_Contains.Name = "toolStripTextBox_Contains";
            this.toolStripTextBox_Contains.Size = new System.Drawing.Size(200, 23);
            // 
            // containsNotToolStripMenuItem
            // 
            this.containsNotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_ContainsNot});
            this.containsNotToolStripMenuItem.Name = "containsNotToolStripMenuItem";
            this.containsNotToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.containsNotToolStripMenuItem.Text = "x_contains not";
            this.containsNotToolStripMenuItem.Click += new System.EventHandler(this.containsNotToolStripMenuItem_Click);
            // 
            // toolStripTextBox_ContainsNot
            // 
            this.toolStripTextBox_ContainsNot.Name = "toolStripTextBox_ContainsNot";
            this.toolStripTextBox_ContainsNot.Size = new System.Drawing.Size(200, 23);
            // 
            // regexNotToolStripMenuItem
            // 
            this.regexNotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_RegExNot});
            this.regexNotToolStripMenuItem.Name = "regexNotToolStripMenuItem";
            this.regexNotToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.regexNotToolStripMenuItem.Text = "x_regex not";
            this.regexNotToolStripMenuItem.Click += new System.EventHandler(this.regexNotToolStripMenuItem_Click);
            // 
            // toolStripTextBox_RegExNot
            // 
            this.toolStripTextBox_RegExNot.Name = "toolStripTextBox_RegExNot";
            this.toolStripTextBox_RegExNot.Size = new System.Drawing.Size(200, 23);
            // 
            // frmFileAnaylzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 532);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmFileAnaylzer";
            this.Text = "x_File-Analyzer";
            this.Load += new System.EventHandler(this.frmFileAnaylzer_Load);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FileContent)).EndInit();
            this.contextMenuStrip_Edit.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.DataGridView dataGridView_FileContent;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_OpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_CountLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Count;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Edit;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem differentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regexToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Regex;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_FilePath;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_FilterLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Filter;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem containsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Contains;
        private System.Windows.Forms.ToolStripMenuItem containsNotToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_ContainsNot;
        private System.Windows.Forms.ToolStripMenuItem regexNotToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_RegExNot;
    }
}

