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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_RegExTester));
            this.contextMenuStrip_Filter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_AddField = new System.Windows.Forms.Button();
            this.textBox_Field = new System.Windows.Forms.TextBox();
            this.label_Field = new System.Windows.Forms.Label();
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
            this.button_Parse = new System.Windows.Forms.Button();
            this.label_Seperator = new System.Windows.Forms.Label();
            this.textBox_Seperator = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_RemoveUnmarked = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_removeMarked = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_CopyMarked = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_DoLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip_Filter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Filter)).BeginInit();
            this.toolStrip1.SuspendLayout();
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
            this.textBox_Field.Location = new System.Drawing.Point(104, 3);
            this.textBox_Field.Name = "textBox_Field";
            this.textBox_Field.ReadOnly = true;
            this.textBox_Field.Size = new System.Drawing.Size(248, 20);
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
            this.textBox_RegExPost.Location = new System.Drawing.Point(104, 82);
            this.textBox_RegExPost.Name = "textBox_RegExPost";
            this.textBox_RegExPost.Size = new System.Drawing.Size(248, 20);
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
            this.textBox_RegExMain.Location = new System.Drawing.Point(104, 57);
            this.textBox_RegExMain.Name = "textBox_RegExMain";
            this.textBox_RegExMain.Size = new System.Drawing.Size(248, 20);
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
            this.textBox_RegexPre.Location = new System.Drawing.Point(104, 33);
            this.textBox_RegexPre.Name = "textBox_RegexPre";
            this.textBox_RegexPre.Size = new System.Drawing.Size(248, 20);
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
            this.richTextBox_Text.Location = new System.Drawing.Point(4, 171);
            this.richTextBox_Text.Name = "richTextBox_Text";
            this.richTextBox_Text.Size = new System.Drawing.Size(894, 315);
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
            this.dataGridView_Filter.Size = new System.Drawing.Size(466, 105);
            this.dataGridView_Filter.TabIndex = 37;
            // 
            // button_Parse
            // 
            this.button_Parse.Location = new System.Drawing.Point(8, 142);
            this.button_Parse.Name = "button_Parse";
            this.button_Parse.Size = new System.Drawing.Size(75, 23);
            this.button_Parse.TabIndex = 38;
            this.button_Parse.Text = "x_Parse";
            this.button_Parse.UseVisualStyleBackColor = true;
            this.button_Parse.Click += new System.EventHandler(this.button_Parse_Click);
            // 
            // label_Seperator
            // 
            this.label_Seperator.AutoSize = true;
            this.label_Seperator.Location = new System.Drawing.Point(8, 110);
            this.label_Seperator.Name = "label_Seperator";
            this.label_Seperator.Size = new System.Drawing.Size(90, 13);
            this.label_Seperator.TabIndex = 39;
            this.label_Seperator.Text = "x_Line-Seperator:";
            // 
            // textBox_Seperator
            // 
            this.textBox_Seperator.Location = new System.Drawing.Point(104, 107);
            this.textBox_Seperator.Name = "textBox_Seperator";
            this.textBox_Seperator.ReadOnly = true;
            this.textBox_Seperator.Size = new System.Drawing.Size(248, 20);
            this.textBox_Seperator.TabIndex = 40;
            this.textBox_Seperator.TextChanged += new System.EventHandler(this.textBox_Seperator_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_RemoveUnmarked,
            this.toolStripButton_removeMarked,
            this.toolStripButton_CopyMarked,
            this.toolStripSeparator1,
            this.toolStripButton_DoLine});
            this.toolStrip1.Location = new System.Drawing.Point(0, 493);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(901, 25);
            this.toolStrip1.TabIndex = 41;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_RemoveUnmarked
            // 
            this.toolStripButton_RemoveUnmarked.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_RemoveUnmarked.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_RemoveUnmarked.Image")));
            this.toolStripButton_RemoveUnmarked.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_RemoveUnmarked.Name = "toolStripButton_RemoveUnmarked";
            this.toolStripButton_RemoveUnmarked.Size = new System.Drawing.Size(121, 22);
            this.toolStripButton_RemoveUnmarked.Text = "x_Remove unmarked";
            this.toolStripButton_RemoveUnmarked.Click += new System.EventHandler(this.button_RemoveUnmarked_Click);
            // 
            // toolStripButton_removeMarked
            // 
            this.toolStripButton_removeMarked.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_removeMarked.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_removeMarked.Image")));
            this.toolStripButton_removeMarked.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_removeMarked.Name = "toolStripButton_removeMarked";
            this.toolStripButton_removeMarked.Size = new System.Drawing.Size(107, 22);
            this.toolStripButton_removeMarked.Text = "x_Remove marked";
            this.toolStripButton_removeMarked.Click += new System.EventHandler(this.button_RemoveMarked_Click);
            // 
            // toolStripButton_CopyMarked
            // 
            this.toolStripButton_CopyMarked.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_CopyMarked.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_CopyMarked.Image")));
            this.toolStripButton_CopyMarked.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_CopyMarked.Name = "toolStripButton_CopyMarked";
            this.toolStripButton_CopyMarked.Size = new System.Drawing.Size(92, 22);
            this.toolStripButton_CopyMarked.Text = "x_Copy Marked";
            this.toolStripButton_CopyMarked.Click += new System.EventHandler(this.button_CopyMarked_Click);
            // 
            // toolStripButton_DoLine
            // 
            this.toolStripButton_DoLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_DoLine.Enabled = false;
            this.toolStripButton_DoLine.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_DoLine.Image")));
            this.toolStripButton_DoLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_DoLine.Name = "toolStripButton_DoLine";
            this.toolStripButton_DoLine.Size = new System.Drawing.Size(61, 22);
            this.toolStripButton_DoLine.Text = "x_Do Line";
            this.toolStripButton_DoLine.Click += new System.EventHandler(this.toolStripButton_DoLine_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // UserControl_RegExTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.textBox_Seperator);
            this.Controls.Add(this.label_Seperator);
            this.Controls.Add(this.button_Parse);
            this.Controls.Add(this.dataGridView_Filter);
            this.Controls.Add(this.richTextBox_Text);
            this.Controls.Add(this.button_AddField);
            this.Controls.Add(this.textBox_Field);
            this.Controls.Add(this.label_Field);
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
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Filter;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Button button_AddField;
        private System.Windows.Forms.TextBox textBox_Field;
        private System.Windows.Forms.Label label_Field;
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
        private System.Windows.Forms.Button button_Parse;
        private System.Windows.Forms.Label label_Seperator;
        private System.Windows.Forms.TextBox textBox_Seperator;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_RemoveUnmarked;
        private System.Windows.Forms.ToolStripButton toolStripButton_removeMarked;
        private System.Windows.Forms.ToolStripButton toolStripButton_CopyMarked;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_DoLine;

    }
}
