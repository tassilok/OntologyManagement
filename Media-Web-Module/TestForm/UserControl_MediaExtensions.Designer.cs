namespace TestForm
{
    partial class UserControl_MediaExtensions
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
            this.dataGridView_Extensions = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Extensions)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Extensions
            // 
            this.dataGridView_Extensions.AllowUserToAddRows = false;
            this.dataGridView_Extensions.AllowUserToDeleteRows = false;
            this.dataGridView_Extensions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Extensions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Extensions.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Extensions.Name = "dataGridView_Extensions";
            this.dataGridView_Extensions.ReadOnly = true;
            this.dataGridView_Extensions.Size = new System.Drawing.Size(472, 370);
            this.dataGridView_Extensions.TabIndex = 0;
            // 
            // UserControl_MediaExtensions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView_Extensions);
            this.Name = "UserControl_MediaExtensions";
            this.Size = new System.Drawing.Size(472, 370);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Extensions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Extensions;
    }
}
