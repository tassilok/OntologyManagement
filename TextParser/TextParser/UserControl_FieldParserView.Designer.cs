﻿namespace TextParser
{
    partial class UserControl_FieldParserView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_FieldParserView));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Parser = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_PagesLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_PageCur = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_PageFirst = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_PagePrevious = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_PageNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_PageLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_CountLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Count = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView_Fields = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStripButton_Parse = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Fields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(750, 516);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(750, 566);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBox_Parser,
            this.toolStripButton_Parse});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(446, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(52, 22);
            this.toolStripLabel1.Text = "x_Parser:";
            // 
            // toolStripTextBox_Parser
            // 
            this.toolStripTextBox_Parser.Name = "toolStripTextBox_Parser";
            this.toolStripTextBox_Parser.Size = new System.Drawing.Size(300, 25);
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
            this.toolStrip2.TabIndex = 0;
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
            // toolStripLabel_PageCur
            // 
            this.toolStripLabel_PageCur.Name = "toolStripLabel_PageCur";
            this.toolStripLabel_PageCur.Size = new System.Drawing.Size(24, 22);
            this.toolStripLabel_PageCur.Text = "0/0";
            // 
            // toolStripButton_PageFirst
            // 
            this.toolStripButton_PageFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_PageFirst.Image = global::TextParser.Properties.Resources.pulsante_01_architetto_f_01_First1;
            this.toolStripButton_PageFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_PageFirst.Name = "toolStripButton_PageFirst";
            this.toolStripButton_PageFirst.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_PageFirst.Text = "toolStripButton1";
            // 
            // toolStripButton_PagePrevious
            // 
            this.toolStripButton_PagePrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_PagePrevious.Image = global::TextParser.Properties.Resources.pulsante_01_architetto_f_01;
            this.toolStripButton_PagePrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_PagePrevious.Name = "toolStripButton_PagePrevious";
            this.toolStripButton_PagePrevious.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_PagePrevious.Text = "toolStripButton2";
            // 
            // toolStripButton_PageNext
            // 
            this.toolStripButton_PageNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_PageNext.Image = global::TextParser.Properties.Resources.pulsante_02_architetto_f_01;
            this.toolStripButton_PageNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_PageNext.Name = "toolStripButton_PageNext";
            this.toolStripButton_PageNext.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_PageNext.Text = "toolStripButton3";
            // 
            // toolStripButton_PageLast
            // 
            this.toolStripButton_PageLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_PageLast.Image = global::TextParser.Properties.Resources.pulsante_02_architetto_f_01_Last;
            this.toolStripButton_PageLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_PageLast.Name = "toolStripButton_PageLast";
            this.toolStripButton_PageLast.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_PageLast.Text = "toolStripButton4";
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
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView_Fields);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(750, 516);
            this.splitContainer1.SplitterDistance = 162;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView_Fields
            // 
            this.dataGridView_Fields.AllowUserToAddRows = false;
            this.dataGridView_Fields.AllowUserToDeleteRows = false;
            this.dataGridView_Fields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Fields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Fields.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Fields.Name = "dataGridView_Fields";
            this.dataGridView_Fields.ReadOnly = true;
            this.dataGridView_Fields.Size = new System.Drawing.Size(746, 158);
            this.dataGridView_Fields.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(746, 346);
            this.dataGridView1.TabIndex = 0;
            // 
            // toolStripButton_Parse
            // 
            this.toolStripButton_Parse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Parse.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Parse.Image")));
            this.toolStripButton_Parse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Parse.Name = "toolStripButton_Parse";
            this.toolStripButton_Parse.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton_Parse.Text = "x_Parse";
            this.toolStripButton_Parse.Click += new System.EventHandler(this.toolStripButton_Parse_Click);
            // 
            // UserControl_FieldParserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_FieldParserView";
            this.Size = new System.Drawing.Size(750, 566);
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
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Fields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Parser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_PagesLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_PageCur;
        private System.Windows.Forms.ToolStripButton toolStripButton_PageFirst;
        private System.Windows.Forms.ToolStripButton toolStripButton_PagePrevious;
        private System.Windows.Forms.ToolStripButton toolStripButton_PageNext;
        private System.Windows.Forms.ToolStripButton toolStripButton_PageLast;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_CountLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Count;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView_Fields;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Parse;
    }
}