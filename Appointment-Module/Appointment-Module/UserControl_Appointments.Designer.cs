namespace Appointment_Module
{
    partial class UserControl_Appointments
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_Appointments));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Active = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_Count = new System.Windows.Forms.ToolStripLabel();
            this.dataGridView_Apointments = new System.Windows.Forms.DataGridView();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Apointments)).BeginInit();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_Apointments);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(361, 346);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(361, 396);
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
            this.toolStripButton_Active});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(66, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton_Active
            // 
            this.toolStripButton_Active.Checked = true;
            this.toolStripButton_Active.CheckOnClick = true;
            this.toolStripButton_Active.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButton_Active.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Active.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Active.Image")));
            this.toolStripButton_Active.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Active.Name = "toolStripButton_Active";
            this.toolStripButton_Active.Size = new System.Drawing.Size(54, 22);
            this.toolStripButton_Active.Text = "x_Active";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_Count});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(65, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripLabel_Count
            // 
            this.toolStripLabel_Count.Name = "toolStripLabel_Count";
            this.toolStripLabel_Count.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel_Count.Text = "x_Count:";
            // 
            // dataGridView_Apointments
            // 
            this.dataGridView_Apointments.AllowUserToAddRows = false;
            this.dataGridView_Apointments.AllowUserToDeleteRows = false;
            this.dataGridView_Apointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Apointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Apointments.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Apointments.Name = "dataGridView_Apointments";
            this.dataGridView_Apointments.ReadOnly = true;
            this.dataGridView_Apointments.Size = new System.Drawing.Size(361, 346);
            this.dataGridView_Apointments.TabIndex = 0;
            // 
            // UserControl_Appointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_Appointments";
            this.Size = new System.Drawing.Size(361, 396);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Apointments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Active;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Count;
        private System.Windows.Forms.DataGridView dataGridView_Apointments;
    }
}
