namespace Version_Module
{
    partial class UserControl_VersionDetails
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_CountCapt = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Count = new System.Windows.Forms.ToolStripLabel();
            this.dataGridView_Versions = new System.Windows.Forms.DataGridView();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Versions)).BeginInit();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_Versions);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(519, 397);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(519, 422);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_CountCapt,
            this.toolStripLabel_Count});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(78, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel_CountCapt
            // 
            this.toolStripLabel_CountCapt.Name = "toolStripLabel_CountCapt";
            this.toolStripLabel_CountCapt.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel_CountCapt.Text = "x_Count:";
            // 
            // toolStripLabel_Count
            // 
            this.toolStripLabel_Count.Name = "toolStripLabel_Count";
            this.toolStripLabel_Count.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel_Count.Text = "0";
            // 
            // dataGridView_Versions
            // 
            this.dataGridView_Versions.AllowUserToAddRows = false;
            this.dataGridView_Versions.AllowUserToDeleteRows = false;
            this.dataGridView_Versions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Versions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Versions.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Versions.Name = "dataGridView_Versions";
            this.dataGridView_Versions.ReadOnly = true;
            this.dataGridView_Versions.Size = new System.Drawing.Size(519, 397);
            this.dataGridView_Versions.TabIndex = 0;
            // 
            // UserControl_VersionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_VersionDetails";
            this.Size = new System.Drawing.Size(519, 422);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Versions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_CountCapt;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Count;
        private System.Windows.Forms.DataGridView dataGridView_Versions;
    }
}
