namespace TestForm
{
    partial class UserControl_MediaFiles
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
            this.dataGridView_Files = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Files)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Files
            // 
            this.dataGridView_Files.AllowUserToAddRows = false;
            this.dataGridView_Files.AllowUserToDeleteRows = false;
            this.dataGridView_Files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Files.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Files.Name = "dataGridView_Files";
            this.dataGridView_Files.ReadOnly = true;
            this.dataGridView_Files.Size = new System.Drawing.Size(481, 354);
            this.dataGridView_Files.TabIndex = 0;
            // 
            // UserControl_MediaFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView_Files);
            this.Name = "UserControl_MediaFiles";
            this.Size = new System.Drawing.Size(481, 354);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Files)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Files;
    }
}
