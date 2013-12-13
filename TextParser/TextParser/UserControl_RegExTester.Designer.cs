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
            this.button_CopyMarked = new System.Windows.Forms.Button();
            this.button_RemoveMarked = new System.Windows.Forms.Button();
            this.button_RemoveUnmarked = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button_AdD = new System.Windows.Forms.Button();
            this.button_AddRegexPre = new System.Windows.Forms.Button();
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
            this.timer_RegExPre = new System.Windows.Forms.Timer(this.components);
            this.timer_RegExMain = new System.Windows.Forms.Timer(this.components);
            this.timer_RegExPost = new System.Windows.Forms.Timer(this.components);
            this.timer_RegExParse = new System.Windows.Forms.Timer(this.components);
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
            this.splitContainer1.Panel1.Controls.Add(this.button_CopyMarked);
            this.splitContainer1.Panel1.Controls.Add(this.button_RemoveMarked);
            this.splitContainer1.Panel1.Controls.Add(this.button_RemoveUnmarked);
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
            this.splitContainer1.Size = new System.Drawing.Size(659, 518);
            this.splitContainer1.SplitterDistance = 112;
            this.splitContainer1.TabIndex = 1;
            // 
            // button_CopyMarked
            // 
            this.button_CopyMarked.Location = new System.Drawing.Point(261, 82);
            this.button_CopyMarked.Name = "button_CopyMarked";
            this.button_CopyMarked.Size = new System.Drawing.Size(122, 23);
            this.button_CopyMarked.TabIndex = 13;
            this.button_CopyMarked.Text = "x_Copy Marked";
            this.button_CopyMarked.UseVisualStyleBackColor = true;
            this.button_CopyMarked.Click += new System.EventHandler(this.button_CopyMarked_Click);
            // 
            // button_RemoveMarked
            // 
            this.button_RemoveMarked.Location = new System.Drawing.Point(133, 82);
            this.button_RemoveMarked.Name = "button_RemoveMarked";
            this.button_RemoveMarked.Size = new System.Drawing.Size(122, 23);
            this.button_RemoveMarked.TabIndex = 12;
            this.button_RemoveMarked.Text = "x_Remove Marked";
            this.button_RemoveMarked.UseVisualStyleBackColor = true;
            this.button_RemoveMarked.Click += new System.EventHandler(this.button_RemoveMarked_Click);
            // 
            // button_RemoveUnmarked
            // 
            this.button_RemoveUnmarked.Location = new System.Drawing.Point(5, 82);
            this.button_RemoveUnmarked.Name = "button_RemoveUnmarked";
            this.button_RemoveUnmarked.Size = new System.Drawing.Size(122, 23);
            this.button_RemoveUnmarked.TabIndex = 11;
            this.button_RemoveUnmarked.Text = "x_Remove Unmarked";
            this.button_RemoveUnmarked.UseVisualStyleBackColor = true;
            this.button_RemoveUnmarked.Click += new System.EventHandler(this.button_RemoveUnmarked_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(318, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button_AdD
            // 
            this.button_AdD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AdD.Enabled = false;
            this.button_AdD.Location = new System.Drawing.Point(318, 26);
            this.button_AdD.Name = "button_AdD";
            this.button_AdD.Size = new System.Drawing.Size(26, 23);
            this.button_AdD.TabIndex = 9;
            this.button_AdD.Text = "...";
            this.button_AdD.UseVisualStyleBackColor = true;
            // 
            // button_AddRegexPre
            // 
            this.button_AddRegexPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AddRegexPre.Enabled = false;
            this.button_AddRegexPre.Location = new System.Drawing.Point(318, 2);
            this.button_AddRegexPre.Name = "button_AddRegexPre";
            this.button_AddRegexPre.Size = new System.Drawing.Size(26, 23);
            this.button_AddRegexPre.TabIndex = 8;
            this.button_AddRegexPre.Text = "...";
            this.button_AddRegexPre.UseVisualStyleBackColor = true;
            // 
            // label_Filter
            // 
            this.label_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Filter.AutoSize = true;
            this.label_Filter.Location = new System.Drawing.Point(350, 7);
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
            this.dataGridView_Filter.Location = new System.Drawing.Point(399, 4);
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
            this.textBox_RegExPost.Size = new System.Drawing.Size(225, 20);
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
            this.textBox_RegExMain.Size = new System.Drawing.Size(225, 20);
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
            this.textBox_RegexPre.Size = new System.Drawing.Size(225, 20);
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
            this.richTextBox_Text.Size = new System.Drawing.Size(655, 398);
            this.richTextBox_Text.TabIndex = 0;
            this.richTextBox_Text.Text = "";
            this.richTextBox_Text.TextChanged += new System.EventHandler(this.richTextBox_Text_TextChanged);
            // 
            // timer_RegExPre
            // 
            this.timer_RegExPre.Interval = 300;
            this.timer_RegExPre.Tick += new System.EventHandler(this.timer_RegExPre_Tick);
            // 
            // timer_RegExMain
            // 
            this.timer_RegExMain.Interval = 300;
            this.timer_RegExMain.Tick += new System.EventHandler(this.timer_RegExMain_Tick);
            // 
            // timer_RegExPost
            // 
            this.timer_RegExPost.Interval = 300;
            this.timer_RegExPost.Tick += new System.EventHandler(this.timer_RegExPost_Tick);
            // 
            // timer_RegExParse
            // 
            this.timer_RegExParse.Interval = 300;
            this.timer_RegExParse.Tick += new System.EventHandler(this.timer_RegExParse_Tick);
            // 
            // UserControl_RegExTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControl_RegExTester";
            this.Size = new System.Drawing.Size(659, 518);
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
        private System.Windows.Forms.Timer timer_RegExParse;
        private System.Windows.Forms.Button button_CopyMarked;
        private System.Windows.Forms.Button button_RemoveMarked;
        private System.Windows.Forms.Button button_RemoveUnmarked;

    }
}
