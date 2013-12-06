namespace TextParser
{
    partial class UserControl_RegExTester
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label_Filter = new System.Windows.Forms.Label();
            this.dataGridView_Filter = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_Filter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_RegExPost = new System.Windows.Forms.TextBox();
            this.label_RegExPost = new System.Windows.Forms.Label();
            this.textBox_RegExMain = new System.Windows.Forms.TextBox();
            this.label_RegexMain = new System.Windows.Forms.Label();
            this.textBox_RegexPre = new System.Windows.Forms.TextBox();
            this.label_RegexPre = new System.Windows.Forms.Label();
            this.richTextBox_Text = new System.Windows.Forms.RichTextBox();
            this.button_AddRegexPre = new System.Windows.Forms.Button();
            this.button_AdD = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer_RegExPre = new System.Windows.Forms.Timer(this.components);
            this.timer_RegExMain = new System.Windows.Forms.Timer(this.components);
            this.timer_RegExPost = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Filter)).BeginInit();
            this.contextMenuStrip_Filter.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button_AdD);
            this.splitContainer1.Panel1.Controls.Add(this.button_AddRegexPre);
            this.splitContainer1.Panel1.Controls.Add(this.label_Filter);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView_Filter);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_RegExPost);
            this.splitContainer1.Panel1.Controls.Add(this.label_RegExPost);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_RegExMain);
            this.splitContainer1.Panel1.Controls.Add(this.label_RegexMain);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_RegexPre);
            this.splitContainer1.Panel1.Controls.Add(this.label_RegexPre);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox_Text);
            this.splitContainer1.Size = new System.Drawing.Size(609, 518);
            this.splitContainer1.SplitterDistance = 112;
            this.splitContainer1.TabIndex = 1;
            // 
            // label_Filter
            // 
            this.label_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Filter.AutoSize = true;
            this.label_Filter.Location = new System.Drawing.Point(300, 7);
            this.label_Filter.Name = "label_Filter";
            this.label_Filter.Size = new System.Drawing.Size(43, 13);
            this.label_Filter.TabIndex = 7;
            this.label_Filter.Text = "x_Filter:";
            // 
            // dataGridView_Filter
            // 
            this.dataGridView_Filter.AllowUserToAddRows = false;
            this.dataGridView_Filter.AllowUserToDeleteRows = false;
            this.dataGridView_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Filter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Filter.ContextMenuStrip = this.contextMenuStrip_Filter;
            this.dataGridView_Filter.Location = new System.Drawing.Point(349, 4);
            this.dataGridView_Filter.Name = "dataGridView_Filter";
            this.dataGridView_Filter.Size = new System.Drawing.Size(253, 101);
            this.dataGridView_Filter.TabIndex = 6;
            // 
            // contextMenuStrip_Filter
            // 
            this.contextMenuStrip_Filter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStrip_Filter.Name = "contextMenuStrip_Filter";
            this.contextMenuStrip_Filter.Size = new System.Drawing.Size(128, 48);
            this.contextMenuStrip_Filter.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Filter_Opening);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.addToolStripMenuItem.Text = "x_Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.removeToolStripMenuItem.Text = "x_Remove";
            // 
            // textBox_RegExPost
            // 
            this.textBox_RegExPost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_RegExPost.Location = new System.Drawing.Point(87, 53);
            this.textBox_RegExPost.Name = "textBox_RegExPost";
            this.textBox_RegExPost.Size = new System.Drawing.Size(175, 20);
            this.textBox_RegExPost.TabIndex = 5;
            this.textBox_RegExPost.TextChanged += new System.EventHandler(this.textBox_RegExPost_TextChanged);
            // 
            // label_RegExPost
            // 
            this.label_RegExPost.AutoSize = true;
            this.label_RegExPost.Location = new System.Drawing.Point(4, 56);
            this.label_RegExPost.Name = "label_RegExPost";
            this.label_RegExPost.Size = new System.Drawing.Size(82, 13);
            this.label_RegExPost.TabIndex = 4;
            this.label_RegExPost.Text = "x_Regex (Post):";
            // 
            // textBox_RegExMain
            // 
            this.textBox_RegExMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_RegExMain.Location = new System.Drawing.Point(87, 28);
            this.textBox_RegExMain.Name = "textBox_RegExMain";
            this.textBox_RegExMain.Size = new System.Drawing.Size(175, 20);
            this.textBox_RegExMain.TabIndex = 3;
            this.textBox_RegExMain.TextChanged += new System.EventHandler(this.textBox_RegExMain_TextChanged);
            // 
            // label_RegexMain
            // 
            this.label_RegexMain.AutoSize = true;
            this.label_RegexMain.Location = new System.Drawing.Point(4, 31);
            this.label_RegexMain.Name = "label_RegexMain";
            this.label_RegexMain.Size = new System.Drawing.Size(84, 13);
            this.label_RegexMain.TabIndex = 2;
            this.label_RegexMain.Text = "x_Regex (Main):";
            // 
            // textBox_RegexPre
            // 
            this.textBox_RegexPre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_RegexPre.Location = new System.Drawing.Point(87, 4);
            this.textBox_RegexPre.Name = "textBox_RegexPre";
            this.textBox_RegexPre.Size = new System.Drawing.Size(175, 20);
            this.textBox_RegexPre.TabIndex = 1;
            this.textBox_RegexPre.TextChanged += new System.EventHandler(this.textBox_RegexPre_TextChanged);
            // 
            // label_RegexPre
            // 
            this.label_RegexPre.AutoSize = true;
            this.label_RegexPre.Location = new System.Drawing.Point(4, 7);
            this.label_RegexPre.Name = "label_RegexPre";
            this.label_RegexPre.Size = new System.Drawing.Size(77, 13);
            this.label_RegexPre.TabIndex = 0;
            this.label_RegexPre.Text = "x_Regex (Pre):";
            // 
            // richTextBox_Text
            // 
            this.richTextBox_Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_Text.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_Text.Name = "richTextBox_Text";
            this.richTextBox_Text.Size = new System.Drawing.Size(605, 398);
            this.richTextBox_Text.TabIndex = 0;
            this.richTextBox_Text.Text = "";
            this.richTextBox_Text.TextChanged += new System.EventHandler(this.richTextBox_Text_TextChanged);
            // 
            // button_AddRegexPre
            // 
            this.button_AddRegexPre.Enabled = false;
            this.button_AddRegexPre.Location = new System.Drawing.Point(268, 2);
            this.button_AddRegexPre.Name = "button_AddRegexPre";
            this.button_AddRegexPre.Size = new System.Drawing.Size(26, 23);
            this.button_AddRegexPre.TabIndex = 8;
            this.button_AddRegexPre.Text = "...";
            this.button_AddRegexPre.UseVisualStyleBackColor = true;
            // 
            // button_AdD
            // 
            this.button_AdD.Enabled = false;
            this.button_AdD.Location = new System.Drawing.Point(268, 26);
            this.button_AdD.Name = "button_AdD";
            this.button_AdD.Size = new System.Drawing.Size(26, 23);
            this.button_AdD.TabIndex = 9;
            this.button_AdD.Text = "...";
            this.button_AdD.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(268, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // timer_RegExPre
            // 
            this.timer_RegExPre.Interval = 300;
            this.timer_RegExPre.Tick += new System.EventHandler(this.timer_RegExPre_Tick);
            // 
            // timer_RegExMain
            // 
            this.timer_RegExMain.Interval = 300;
            // 
            // timer_RegExPost
            // 
            this.timer_RegExPost.Interval = 300;
            // 
            // UserControl_RegExTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControl_RegExTester";
            this.Size = new System.Drawing.Size(609, 518);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Filter)).EndInit();
            this.contextMenuStrip_Filter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label_Filter;
        private System.Windows.Forms.DataGridView dataGridView_Filter;
        private System.Windows.Forms.TextBox textBox_RegExPost;
        private System.Windows.Forms.Label label_RegExPost;
        private System.Windows.Forms.TextBox textBox_RegExMain;
        private System.Windows.Forms.Label label_RegexMain;
        private System.Windows.Forms.TextBox textBox_RegexPre;
        private System.Windows.Forms.Label label_RegexPre;
        private System.Windows.Forms.RichTextBox richTextBox_Text;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Filter;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_AdD;
        private System.Windows.Forms.Button button_AddRegexPre;
        private System.Windows.Forms.Timer timer_RegExPre;
        private System.Windows.Forms.Timer timer_RegExMain;
        private System.Windows.Forms.Timer timer_RegExPost;

    }
}
