namespace LiteraturQuellen_Module
{
    partial class frmQuellen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuellen));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Apply = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_Quellen = new System.Windows.Forms.DataGridView();
            this.label_Name = new System.Windows.Forms.Label();
            this.textBox_QuellName = new System.Windows.Forms.TextBox();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Quellen)).BeginInit();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.textBox_QuellName);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label_Name);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_Quellen);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(462, 236);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(462, 261);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Apply,
            this.toolStripButton_Close});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(114, 25);
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
            // toolStripButton_Close
            // 
            this.toolStripButton_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Close.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Close.Image")));
            this.toolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Close.Name = "toolStripButton_Close";
            this.toolStripButton_Close.Size = new System.Drawing.Size(50, 22);
            this.toolStripButton_Close.Text = "x_Close";
            this.toolStripButton_Close.Click += new System.EventHandler(this.toolStripButton_Close_Click);
            // 
            // dataGridView_Quellen
            // 
            this.dataGridView_Quellen.AllowUserToAddRows = false;
            this.dataGridView_Quellen.AllowUserToDeleteRows = false;
            this.dataGridView_Quellen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Quellen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Quellen.Location = new System.Drawing.Point(3, 28);
            this.dataGridView_Quellen.Name = "dataGridView_Quellen";
            this.dataGridView_Quellen.ReadOnly = true;
            this.dataGridView_Quellen.Size = new System.Drawing.Size(456, 205);
            this.dataGridView_Quellen.TabIndex = 0;
            this.dataGridView_Quellen.SelectionChanged += new System.EventHandler(this.dataGridView_Quellen_SelectionChanged);
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(3, 6);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(49, 13);
            this.label_Name.TabIndex = 1;
            this.label_Name.Text = "x_Name:";
            // 
            // textBox_QuellName
            // 
            this.textBox_QuellName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_QuellName.Location = new System.Drawing.Point(58, 3);
            this.textBox_QuellName.Name = "textBox_QuellName";
            this.textBox_QuellName.Size = new System.Drawing.Size(401, 20);
            this.textBox_QuellName.TabIndex = 2;
            // 
            // frmQuellen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 261);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmQuellen";
            this.Text = "frmQuellen";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Quellen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Apply;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.DataGridView dataGridView_Quellen;
        private System.Windows.Forms.TextBox textBox_QuellName;
        private System.Windows.Forms.Label label_Name;
    }
}