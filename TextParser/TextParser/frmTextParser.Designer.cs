namespace TextParser
{
    partial class frmTextParser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTextParser));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton_Test = new System.Windows.Forms.ToolStripDropDownButton();
            this.textParserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fieldParserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regExTesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_ParserDetail = new System.Windows.Forms.TabPage();
            this.tabPage_ParserView = new System.Windows.Forms.TabPage();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabControl1.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(792, 539);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(792, 589);
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
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(62, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(50, 22);
            this.toolStripButton1.Text = "x_Close";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(792, 539);
            this.splitContainer1.SplitterDistance = 179;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(609, 539);
            this.splitContainer2.SplitterDistance = 203;
            this.splitContainer2.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton_Test});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(64, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripDropDownButton_Test
            // 
            this.toolStripDropDownButton_Test.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton_Test.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textParserToolStripMenuItem,
            this.fieldParserToolStripMenuItem,
            this.regExTesterToolStripMenuItem});
            this.toolStripDropDownButton_Test.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_Test.Image")));
            this.toolStripDropDownButton_Test.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_Test.Name = "toolStripDropDownButton_Test";
            this.toolStripDropDownButton_Test.Size = new System.Drawing.Size(52, 22);
            this.toolStripDropDownButton_Test.Text = "x_Test";
            // 
            // textParserToolStripMenuItem
            // 
            this.textParserToolStripMenuItem.Name = "textParserToolStripMenuItem";
            this.textParserToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.textParserToolStripMenuItem.Text = "x_Text-Parser";
            this.textParserToolStripMenuItem.Click += new System.EventHandler(this.textParserToolStripMenuItem_Click);
            // 
            // fieldParserToolStripMenuItem
            // 
            this.fieldParserToolStripMenuItem.Name = "fieldParserToolStripMenuItem";
            this.fieldParserToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fieldParserToolStripMenuItem.Text = "x_Field-Parser";
            this.fieldParserToolStripMenuItem.Click += new System.EventHandler(this.fieldParserToolStripMenuItem_Click);
            // 
            // regExTesterToolStripMenuItem
            // 
            this.regExTesterToolStripMenuItem.Name = "regExTesterToolStripMenuItem";
            this.regExTesterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.regExTesterToolStripMenuItem.Text = "x_RegEx-Tester";
            this.regExTesterToolStripMenuItem.Click += new System.EventHandler(this.regExTesterToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_ParserDetail);
            this.tabControl1.Controls.Add(this.tabPage_ParserView);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(398, 535);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage_ParserDetail
            // 
            this.tabPage_ParserDetail.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ParserDetail.Name = "tabPage_ParserDetail";
            this.tabPage_ParserDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ParserDetail.Size = new System.Drawing.Size(390, 509);
            this.tabPage_ParserDetail.TabIndex = 0;
            this.tabPage_ParserDetail.Text = "x_ParserDetail";
            this.tabPage_ParserDetail.UseVisualStyleBackColor = true;
            // 
            // tabPage_ParserView
            // 
            this.tabPage_ParserView.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ParserView.Name = "tabPage_ParserView";
            this.tabPage_ParserView.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ParserView.Size = new System.Drawing.Size(390, 509);
            this.tabPage_ParserView.TabIndex = 1;
            this.tabPage_ParserView.Text = "x_ParserView";
            this.tabPage_ParserView.UseVisualStyleBackColor = true;
            // 
            // frmTextParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 589);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmTextParser";
            this.Text = "frmTextParser";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_Test;
        private System.Windows.Forms.ToolStripMenuItem textParserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fieldParserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regExTesterToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_ParserDetail;
        private System.Windows.Forms.TabPage tabPage_ParserView;
    }
}