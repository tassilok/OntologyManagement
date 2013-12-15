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
            this.contextMenuStrip_Filter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_RegExPre = new System.Windows.Forms.Timer(this.components);
            this.timer_RegExMain = new System.Windows.Forms.Timer(this.components);
            this.timer_RegExPost = new System.Windows.Forms.Timer(this.components);
            this.timer_RegExParse = new System.Windows.Forms.Timer(this.components);
            this.button_AddField = new System.Windows.Forms.Button();
            this.textBox_Field = new System.Windows.Forms.TextBox();
            this.label_Field = new System.Windows.Forms.Label();
            this.button_CopyMarked = new System.Windows.Forms.Button();
            this.button_RemoveMarked = new System.Windows.Forms.Button();
            this.button_RemoveUnmarked = new System.Windows.Forms.Button();
            this.button_AddRegExPost = new System.Windows.Forms.Button();
            this.button_AdRegexMain = new System.Windows.Forms.Button();
            this.button_AddRegexPre = new System.Windows.Forms.Button();
            this.label_Filter = new System.Windows.Forms.Label();
            this.textBox_RegExPost = new System.Windows.Forms.TextBox();
            this.label_RegExPost = new System.Windows.Forms.Label();
            this.textBox_RegExMain = new System.Windows.Forms.TextBox();
            this.label_RegexMain = new System.Windows.Forms.Label();
            this.textBox_RegexPre = new System.Windows.Forms.TextBox();
            this.label_RegexPre = new System.Windows.Forms.Label();
            this.richTextBox_Text = new System.Windows.Forms.RichTextBox();
            this.dataGridView_Filter = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_Filter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Filter)).BeginInit();
            this.SuspendLayout();
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
            // button_AddField
            // 
            this.button_AddField.Enabled = false;
            this.button_AddField.Location = new System.Drawing.Point(358, 1);
            this.button_AddField.Name = "button_AddField";
            this.button_AddField.Size = new System.Drawing.Size(26, 23);
            this.button_AddField.TabIndex = 33;
            this.button_AddField.Text = "...";
            this.button_AddField.UseVisualStyleBackColor = true;
            this.button_AddField.Click += new System.EventHandler(this.button_AddField_Click);
            // 
            // textBox_Field
            // 
            this.textBox_Field.Location = new System.Drawing.Point(88, 3);
            this.textBox_Field.Name = "textBox_Field";
            this.textBox_Field.ReadOnly = true;
            this.textBox_Field.Size = new System.Drawing.Size(264, 20);
            this.textBox_Field.TabIndex = 32;
            // 
            // label_Field
            // 
            this.label_Field.AutoSize = true;
            this.label_Field.Location = new System.Drawing.Point(5, 6);
            this.label_Field.Name = "label_Field";
            this.label_Field.Size = new System.Drawing.Size(43, 13);
            this.label_Field.TabIndex = 31;
            this.label_Field.Text = "x_Field:";
            // 
            // button_CopyMarked
            // 
            this.button_CopyMarked.Location = new System.Drawing.Point(262, 111);
            this.button_CopyMarked.Name = "button_CopyMarked";
            this.button_CopyMarked.Size = new System.Drawing.Size(122, 23);
            this.button_CopyMarked.TabIndex = 30;
            this.button_CopyMarked.Text = "x_Copy Marked";
            this.button_CopyMarked.UseVisualStyleBackColor = true;
            this.button_CopyMarked.Click += new System.EventHandler(this.button_CopyMarked_Click);
            // 
            // button_RemoveMarked
            // 
            this.button_RemoveMarked.Location = new System.Drawing.Point(134, 111);
            this.button_RemoveMarked.Name = "button_RemoveMarked";
            this.button_RemoveMarked.Size = new System.Drawing.Size(122, 23);
            this.button_RemoveMarked.TabIndex = 29;
            this.button_RemoveMarked.Text = "x_Remove Marked";
            this.button_RemoveMarked.UseVisualStyleBackColor = true;
            this.button_RemoveMarked.Click += new System.EventHandler(this.button_RemoveMarked_Click);
            // 
            // button_RemoveUnmarked
            // 
            this.button_RemoveUnmarked.Location = new System.Drawing.Point(6, 111);
            this.button_RemoveUnmarked.Name = "button_RemoveUnmarked";
            this.button_RemoveUnmarked.Size = new System.Drawing.Size(122, 23);
            this.button_RemoveUnmarked.TabIndex = 28;
            this.button_RemoveUnmarked.Text = "x_Remove Unmarked";
            this.button_RemoveUnmarked.UseVisualStyleBackColor = true;
            this.button_RemoveUnmarked.Click += new System.EventHandler(this.button_RemoveUnmarked_Click);
            // 
            // button_AddRegExPost
            // 
            this.button_AddRegExPost.Enabled = false;
            this.button_AddRegExPost.Location = new System.Drawing.Point(358, 80);
            this.button_AddRegExPost.Name = "button_AddRegExPost";
            this.button_AddRegExPost.Size = new System.Drawing.Size(26, 23);
            this.button_AddRegExPost.TabIndex = 27;
            this.button_AddRegExPost.Text = "...";
            this.button_AddRegExPost.UseVisualStyleBackColor = true;
            // 
            // button_AdRegexMain
            // 
            this.button_AdRegexMain.Enabled = false;
            this.button_AdRegexMain.Location = new System.Drawing.Point(358, 55);
            this.button_AdRegexMain.Name = "button_AdRegexMain";
            this.button_AdRegexMain.Size = new System.Drawing.Size(26, 23);
            this.button_AdRegexMain.TabIndex = 26;
            this.button_AdRegexMain.Text = "...";
            this.button_AdRegexMain.UseVisualStyleBackColor = true;
            // 
            // button_AddRegexPre
            // 
            this.button_AddRegexPre.Enabled = false;
            this.button_AddRegexPre.Location = new System.Drawing.Point(358, 31);
            this.button_AddRegexPre.Name = "button_AddRegexPre";
            this.button_AddRegexPre.Size = new System.Drawing.Size(26, 23);
            this.button_AddRegexPre.TabIndex = 25;
            this.button_AddRegexPre.Text = "...";
            this.button_AddRegexPre.UseVisualStyleBackColor = true;
            // 
            // label_Filter
            // 
            this.label_Filter.AutoSize = true;
            this.label_Filter.Location = new System.Drawing.Point(391, 31);
            this.label_Filter.Name = "label_Filter";
            this.label_Filter.Size = new System.Drawing.Size(43, 13);
            this.label_Filter.TabIndex = 24;
            this.label_Filter.Text = "x_Filter:";
            // 
            // textBox_RegExPost
            // 
            this.textBox_RegExPost.Location = new System.Drawing.Point(88, 82);
            this.textBox_RegExPost.Name = "textBox_RegExPost";
            this.textBox_RegExPost.Size = new System.Drawing.Size(264, 20);
            this.textBox_RegExPost.TabIndex = 22;
            this.textBox_RegExPost.TextChanged += new System.EventHandler(this.textBox_RegExPost_TextChanged);
            // 
            // label_RegExPost
            // 
            this.label_RegExPost.AutoSize = true;
            this.label_RegExPost.Location = new System.Drawing.Point(5, 85);
            this.label_RegExPost.Name = "label_RegExPost";
            this.label_RegExPost.Size = new System.Drawing.Size(82, 13);
            this.label_RegExPost.TabIndex = 21;
            this.label_RegExPost.Text = "x_Regex (Post):";
            // 
            // textBox_RegExMain
            // 
            this.textBox_RegExMain.Location = new System.Drawing.Point(88, 57);
            this.textBox_RegExMain.Name = "textBox_RegExMain";
            this.textBox_RegExMain.Size = new System.Drawing.Size(264, 20);
            this.textBox_RegExMain.TabIndex = 20;
            this.textBox_RegExMain.TextChanged += new System.EventHandler(this.textBox_RegExMain_TextChanged);
            // 
            // label_RegexMain
            // 
            this.label_RegexMain.AutoSize = true;
            this.label_RegexMain.Location = new System.Drawing.Point(5, 60);
            this.label_RegexMain.Name = "label_RegexMain";
            this.label_RegexMain.Size = new System.Drawing.Size(84, 13);
            this.label_RegexMain.TabIndex = 19;
            this.label_RegexMain.Text = "x_Regex (Main):";
            // 
            // textBox_RegexPre
            // 
            this.textBox_RegexPre.Location = new System.Drawing.Point(88, 33);
            this.textBox_RegexPre.Name = "textBox_RegexPre";
            this.textBox_RegexPre.Size = new System.Drawing.Size(264, 20);
            this.textBox_RegexPre.TabIndex = 18;
            this.textBox_RegexPre.TextChanged += new System.EventHandler(this.textBox_RegexPre_TextChanged);
            // 
            // label_RegexPre
            // 
            this.label_RegexPre.AutoSize = true;
            this.label_RegexPre.Location = new System.Drawing.Point(5, 36);
            this.label_RegexPre.Name = "label_RegexPre";
            this.label_RegexPre.Size = new System.Drawing.Size(77, 13);
            this.label_RegexPre.TabIndex = 17;
            this.label_RegexPre.Text = "x_Regex (Pre):";
            // 
            // richTextBox_Text
            // 
            this.richTextBox_Text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_Text.Location = new System.Drawing.Point(4, 141);
            this.richTextBox_Text.Name = "richTextBox_Text";
            this.richTextBox_Text.Size = new System.Drawing.Size(894, 374);
            this.richTextBox_Text.TabIndex = 34;
            this.richTextBox_Text.Text = "";
            this.richTextBox_Text.TextChanged += new System.EventHandler(this.richTextBox_Text_TextChanged);
            // 
            // dataGridView_Filter
            // 
            this.dataGridView_Filter.AllowUserToAddRows = false;
            this.dataGridView_Filter.AllowUserToDeleteRows = false;
            this.dataGridView_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Filter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Filter.ContextMenuStrip = this.contextMenuStrip_Filter;
            this.dataGridView_Filter.Location = new System.Drawing.Point(432, 30);
            this.dataGridView_Filter.Name = "dataGridView_Filter";
            this.dataGridView_Filter.ReadOnly = true;
            this.dataGridView_Filter.Size = new System.Drawing.Size(466, 104);
            this.dataGridView_Filter.TabIndex = 37;
            // 
            // UserControl_RegExTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView_Filter);
            this.Controls.Add(this.richTextBox_Text);
            this.Controls.Add(this.button_AddField);
            this.Controls.Add(this.textBox_Field);
            this.Controls.Add(this.label_Field);
            this.Controls.Add(this.button_CopyMarked);
            this.Controls.Add(this.button_RemoveMarked);
            this.Controls.Add(this.button_RemoveUnmarked);
            this.Controls.Add(this.button_AddRegExPost);
            this.Controls.Add(this.button_AdRegexMain);
            this.Controls.Add(this.button_AddRegexPre);
            this.Controls.Add(this.label_Filter);
            this.Controls.Add(this.textBox_RegExPost);
            this.Controls.Add(this.label_RegExPost);
            this.Controls.Add(this.textBox_RegExMain);
            this.Controls.Add(this.label_RegexMain);
            this.Controls.Add(this.textBox_RegexPre);
            this.Controls.Add(this.label_RegexPre);
            this.Name = "UserControl_RegExTester";
            this.Size = new System.Drawing.Size(901, 518);
            this.contextMenuStrip_Filter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Filter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Filter;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Timer timer_RegExPre;
        private System.Windows.Forms.Timer timer_RegExMain;
        private System.Windows.Forms.Timer timer_RegExPost;
        private System.Windows.Forms.Timer timer_RegExParse;
        private System.Windows.Forms.Button button_AddField;
        private System.Windows.Forms.TextBox textBox_Field;
        private System.Windows.Forms.Label label_Field;
        private System.Windows.Forms.Button button_CopyMarked;
        private System.Windows.Forms.Button button_RemoveMarked;
        private System.Windows.Forms.Button button_RemoveUnmarked;
        private System.Windows.Forms.Button button_AddRegExPost;
        private System.Windows.Forms.Button button_AdRegexMain;
        private System.Windows.Forms.Button button_AddRegexPre;
        private System.Windows.Forms.Label label_Filter;
        private System.Windows.Forms.TextBox textBox_RegExPost;
        private System.Windows.Forms.Label label_RegExPost;
        private System.Windows.Forms.TextBox textBox_RegExMain;
        private System.Windows.Forms.Label label_RegexMain;
        private System.Windows.Forms.TextBox textBox_RegexPre;
        private System.Windows.Forms.Label label_RegexPre;
        private System.Windows.Forms.RichTextBox richTextBox_Text;
        private System.Windows.Forms.DataGridView dataGridView_Filter;

    }
}
