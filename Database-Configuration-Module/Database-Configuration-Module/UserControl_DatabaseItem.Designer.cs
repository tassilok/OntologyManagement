namespace DatabaseConfigurationModule
{
    partial class UserControl_DatabaseItem
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
            this.panel_Name = new System.Windows.Forms.Panel();
            this.panel_ItemConfig = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel_Name
            // 
            this.panel_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Name.Location = new System.Drawing.Point(4, 4);
            this.panel_Name.Name = "panel_Name";
            this.panel_Name.Size = new System.Drawing.Size(535, 25);
            this.panel_Name.TabIndex = 0;
            // 
            // panel_ItemConfig
            // 
            this.panel_ItemConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_ItemConfig.Location = new System.Drawing.Point(4, 36);
            this.panel_ItemConfig.Name = "panel_ItemConfig";
            this.panel_ItemConfig.Size = new System.Drawing.Size(535, 417);
            this.panel_ItemConfig.TabIndex = 1;
            // 
            // UserControl_DatabaseItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_ItemConfig);
            this.Controls.Add(this.panel_Name);
            this.Name = "UserControl_DatabaseItem";
            this.Size = new System.Drawing.Size(542, 456);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Name;
        private System.Windows.Forms.Panel panel_ItemConfig;

    }
}
