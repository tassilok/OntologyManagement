namespace TextParser
{
    partial class UserControl_RegExFilterDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_RegExFilterDetail));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Apply = new System.Windows.Forms.ToolStripButton();
            this.comboBox_Relation = new System.Windows.Forms.ComboBox();
            this.label_Relation = new System.Windows.Forms.Label();
            this.textBox_Pattern = new System.Windows.Forms.TextBox();
            this.label_Pattern = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.checkBox_Equal = new System.Windows.Forms.CheckBox();
            this.timer_Pattern = new System.Windows.Forms.Timer(this.components);
            this.timer_Name = new System.Windows.Forms.Timer(this.components);
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.comboBox_Relation);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label_Relation);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.textBox_Pattern);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label_Pattern);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.textBox_Name);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label_Name);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.checkBox_Equal);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(394, 326);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(394, 376);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Apply});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(95, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton_Apply
            // 
            this.toolStripButton_Apply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Apply.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Apply.Image")));
            this.toolStripButton_Apply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Apply.Name = "toolStripButton_Apply";
            this.toolStripButton_Apply.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_Apply.Text = "x_Apply";
            this.toolStripButton_Apply.Click += new System.EventHandler(this.toolStripButton_Apply_Click);
            // 
            // comboBox_Relation
            // 
            this.comboBox_Relation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Relation.FormattingEnabled = true;
            this.comboBox_Relation.Location = new System.Drawing.Point(80, 301);
            this.comboBox_Relation.Name = "comboBox_Relation";
            this.comboBox_Relation.Size = new System.Drawing.Size(311, 21);
            this.comboBox_Relation.TabIndex = 18;
            this.comboBox_Relation.SelectedIndexChanged += new System.EventHandler(this.comboBox_Relation_SelectedIndexChanged);
            // 
            // label_Relation
            // 
            this.label_Relation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Relation.AutoSize = true;
            this.label_Relation.Location = new System.Drawing.Point(9, 301);
            this.label_Relation.Name = "label_Relation";
            this.label_Relation.Size = new System.Drawing.Size(60, 13);
            this.label_Relation.TabIndex = 17;
            this.label_Relation.Text = "x_Relation:";
            // 
            // textBox_Pattern
            // 
            this.textBox_Pattern.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Pattern.Location = new System.Drawing.Point(80, 51);
            this.textBox_Pattern.Multiline = true;
            this.textBox_Pattern.Name = "textBox_Pattern";
            this.textBox_Pattern.Size = new System.Drawing.Size(311, 245);
            this.textBox_Pattern.TabIndex = 16;
            this.textBox_Pattern.TextChanged += new System.EventHandler(this.textBox_Pattern_TextChanged);
            // 
            // label_Pattern
            // 
            this.label_Pattern.AutoSize = true;
            this.label_Pattern.Location = new System.Drawing.Point(3, 51);
            this.label_Pattern.Name = "label_Pattern";
            this.label_Pattern.Size = new System.Drawing.Size(55, 13);
            this.label_Pattern.TabIndex = 15;
            this.label_Pattern.Text = "x_Pattern:";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Name.Location = new System.Drawing.Point(80, 3);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(311, 20);
            this.textBox_Name.TabIndex = 14;
            this.textBox_Name.TextChanged += new System.EventHandler(this.textBox_Name_TextChanged);
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(3, 5);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(49, 13);
            this.label_Name.TabIndex = 13;
            this.label_Name.Text = "x_Name:";
            // 
            // checkBox_Equal
            // 
            this.checkBox_Equal.AutoSize = true;
            this.checkBox_Equal.Location = new System.Drawing.Point(80, 28);
            this.checkBox_Equal.Name = "checkBox_Equal";
            this.checkBox_Equal.Size = new System.Drawing.Size(64, 17);
            this.checkBox_Equal.TabIndex = 12;
            this.checkBox_Equal.Text = "x_Equal";
            this.checkBox_Equal.UseVisualStyleBackColor = true;
            this.checkBox_Equal.CheckedChanged += new System.EventHandler(this.checkBox_Equal_CheckedChanged);
            // 
            // timer_Pattern
            // 
            this.timer_Pattern.Interval = 300;
            this.timer_Pattern.Tick += new System.EventHandler(this.timer_Pattern_Tick);
            // 
            // timer_Name
            // 
            this.timer_Name.Interval = 300;
            this.timer_Name.Tick += new System.EventHandler(this.timer_Name_Tick);
            // 
            // UserControl_RegExFilterDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_RegExFilterDetail";
            this.Size = new System.Drawing.Size(394, 376);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Apply;
        private System.Windows.Forms.ComboBox comboBox_Relation;
        private System.Windows.Forms.Label label_Relation;
        private System.Windows.Forms.TextBox textBox_Pattern;
        private System.Windows.Forms.Label label_Pattern;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.CheckBox checkBox_Equal;
        private System.Windows.Forms.Timer timer_Pattern;
        private System.Windows.Forms.Timer timer_Name;

    }
}
