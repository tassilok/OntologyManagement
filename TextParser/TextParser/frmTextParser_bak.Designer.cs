namespace TextParser
{
    partial class frmTextParser_bak
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Parse = new System.Windows.Forms.TabPage();
            this.button_Search = new System.Windows.Forms.Button();
            this.dataGridView_Found = new System.Windows.Forms.DataGridView();
            this.label_Found = new System.Windows.Forms.Label();
            this.dataGridView_SearchParams = new System.Windows.Forms.DataGridView();
            this.label_Search = new System.Windows.Forms.Label();
            this.tabPage_Content = new System.Windows.Forms.TabPage();
            this.textBox_Content = new System.Windows.Forms.TextBox();
            this.button_GetFile = new System.Windows.Forms.Button();
            this.textBox_File = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog_Source = new System.Windows.Forms.OpenFileDialog();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_Parse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Found)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SearchParams)).BeginInit();
            this.tabPage_Content.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.button_GetFile);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.textBox_File);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(748, 467);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(748, 517);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Close});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(52, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton_Close
            // 
            this.toolStripButton_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Close.Name = "toolStripButton_Close";
            this.toolStripButton_Close.Size = new System.Drawing.Size(40, 22);
            this.toolStripButton_Close.Text = "Close";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage_Parse);
            this.tabControl1.Controls.Add(this.tabPage_Content);
            this.tabControl1.Location = new System.Drawing.Point(7, 37);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(738, 427);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage_Parse
            // 
            this.tabPage_Parse.Controls.Add(this.button_Search);
            this.tabPage_Parse.Controls.Add(this.dataGridView_Found);
            this.tabPage_Parse.Controls.Add(this.label_Found);
            this.tabPage_Parse.Controls.Add(this.dataGridView_SearchParams);
            this.tabPage_Parse.Controls.Add(this.label_Search);
            this.tabPage_Parse.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Parse.Name = "tabPage_Parse";
            this.tabPage_Parse.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Parse.Size = new System.Drawing.Size(730, 401);
            this.tabPage_Parse.TabIndex = 0;
            this.tabPage_Parse.Text = "Parse";
            this.tabPage_Parse.UseVisualStyleBackColor = true;
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(6, 140);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(75, 23);
            this.button_Search.TabIndex = 12;
            this.button_Search.Text = "Parse";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // dataGridView_Found
            // 
            this.dataGridView_Found.AllowUserToAddRows = false;
            this.dataGridView_Found.AllowUserToDeleteRows = false;
            this.dataGridView_Found.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Found.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Found.Location = new System.Drawing.Point(6, 183);
            this.dataGridView_Found.Name = "dataGridView_Found";
            this.dataGridView_Found.ReadOnly = true;
            this.dataGridView_Found.Size = new System.Drawing.Size(721, 212);
            this.dataGridView_Found.TabIndex = 11;
            this.dataGridView_Found.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView_Found_KeyUp);
            // 
            // label_Found
            // 
            this.label_Found.AutoSize = true;
            this.label_Found.Location = new System.Drawing.Point(3, 167);
            this.label_Found.Name = "label_Found";
            this.label_Found.Size = new System.Drawing.Size(40, 13);
            this.label_Found.TabIndex = 10;
            this.label_Found.Text = "Found:";
            // 
            // dataGridView_SearchParams
            // 
            this.dataGridView_SearchParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_SearchParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SearchParams.Location = new System.Drawing.Point(6, 23);
            this.dataGridView_SearchParams.Name = "dataGridView_SearchParams";
            this.dataGridView_SearchParams.Size = new System.Drawing.Size(721, 110);
            this.dataGridView_SearchParams.TabIndex = 9;
            this.dataGridView_SearchParams.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView_SearchParams_KeyUp);
            // 
            // label_Search
            // 
            this.label_Search.AutoSize = true;
            this.label_Search.Location = new System.Drawing.Point(3, 6);
            this.label_Search.Name = "label_Search";
            this.label_Search.Size = new System.Drawing.Size(82, 13);
            this.label_Search.TabIndex = 8;
            this.label_Search.Text = "Search-Params:";
            // 
            // tabPage_Content
            // 
            this.tabPage_Content.Controls.Add(this.textBox_Content);
            this.tabPage_Content.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Content.Name = "tabPage_Content";
            this.tabPage_Content.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Content.Size = new System.Drawing.Size(730, 401);
            this.tabPage_Content.TabIndex = 1;
            this.tabPage_Content.Text = "Content";
            this.tabPage_Content.UseVisualStyleBackColor = true;
            // 
            // textBox_Content
            // 
            this.textBox_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Content.Location = new System.Drawing.Point(3, 3);
            this.textBox_Content.MaxLength = 2147483646;
            this.textBox_Content.Multiline = true;
            this.textBox_Content.Name = "textBox_Content";
            this.textBox_Content.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Content.Size = new System.Drawing.Size(724, 395);
            this.textBox_Content.TabIndex = 0;
            // 
            // button_GetFile
            // 
            this.button_GetFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_GetFile.Location = new System.Drawing.Point(716, 2);
            this.button_GetFile.Name = "button_GetFile";
            this.button_GetFile.Size = new System.Drawing.Size(29, 23);
            this.button_GetFile.TabIndex = 2;
            this.button_GetFile.Text = "...";
            this.button_GetFile.UseVisualStyleBackColor = true;
            this.button_GetFile.Click += new System.EventHandler(this.button_GetFile_Click);
            // 
            // textBox_File
            // 
            this.textBox_File.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_File.Location = new System.Drawing.Point(37, 4);
            this.textBox_File.Name = "textBox_File";
            this.textBox_File.Size = new System.Drawing.Size(672, 20);
            this.textBox_File.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            // 
            // openFileDialog_Source
            // 
            this.openFileDialog_Source.FileName = "openFileDialog1";
            // 
            // frmTextParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 517);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmTextParser";
            this.Text = "Text-Parser";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Parse.ResumeLayout(false);
            this.tabPage_Parse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Found)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SearchParams)).EndInit();
            this.tabPage_Content.ResumeLayout(false);
            this.tabPage_Content.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.Button button_GetFile;
        private System.Windows.Forms.TextBox textBox_File;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Source;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Parse;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.DataGridView dataGridView_Found;
        private System.Windows.Forms.Label label_Found;
        private System.Windows.Forms.DataGridView dataGridView_SearchParams;
        private System.Windows.Forms.Label label_Search;
        private System.Windows.Forms.TabPage tabPage_Content;
        private System.Windows.Forms.TextBox textBox_Content;
    }
}

