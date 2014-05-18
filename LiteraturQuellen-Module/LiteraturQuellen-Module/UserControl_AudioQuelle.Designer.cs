namespace LiteraturQuellen_Module
{
    partial class UserControl_AudioQuelle
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Audio = new System.Windows.Forms.TabPage();
            this.tabPage_InternetQuelle = new System.Windows.Forms.TabPage();
            this.button_AddQuelle = new System.Windows.Forms.Button();
            this.panel_InternetQuelle = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage_InternetQuelle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Audio);
            this.tabControl1.Controls.Add(this.tabPage_InternetQuelle);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(516, 477);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_Audio
            // 
            this.tabPage_Audio.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Audio.Name = "tabPage_Audio";
            this.tabPage_Audio.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Audio.Size = new System.Drawing.Size(508, 451);
            this.tabPage_Audio.TabIndex = 0;
            this.tabPage_Audio.Text = "x_Audio";
            this.tabPage_Audio.UseVisualStyleBackColor = true;
            // 
            // tabPage_InternetQuelle
            // 
            this.tabPage_InternetQuelle.Controls.Add(this.button_AddQuelle);
            this.tabPage_InternetQuelle.Controls.Add(this.panel_InternetQuelle);
            this.tabPage_InternetQuelle.Location = new System.Drawing.Point(4, 22);
            this.tabPage_InternetQuelle.Name = "tabPage_InternetQuelle";
            this.tabPage_InternetQuelle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_InternetQuelle.Size = new System.Drawing.Size(508, 451);
            this.tabPage_InternetQuelle.TabIndex = 1;
            this.tabPage_InternetQuelle.Text = "x_Internet-Quelle";
            this.tabPage_InternetQuelle.UseVisualStyleBackColor = true;
            // 
            // button_AddQuelle
            // 
            this.button_AddQuelle.Location = new System.Drawing.Point(7, 2);
            this.button_AddQuelle.Name = "button_AddQuelle";
            this.button_AddQuelle.Size = new System.Drawing.Size(119, 23);
            this.button_AddQuelle.TabIndex = 3;
            this.button_AddQuelle.Text = "x_Add Internet-Quelle";
            this.button_AddQuelle.UseVisualStyleBackColor = true;
            // 
            // panel_InternetQuelle
            // 
            this.panel_InternetQuelle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_InternetQuelle.Location = new System.Drawing.Point(0, 27);
            this.panel_InternetQuelle.Name = "panel_InternetQuelle";
            this.panel_InternetQuelle.Size = new System.Drawing.Size(508, 424);
            this.panel_InternetQuelle.TabIndex = 2;
            // 
            // UserControl_AudioQuelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UserControl_AudioQuelle";
            this.Size = new System.Drawing.Size(516, 477);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_InternetQuelle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Audio;
        private System.Windows.Forms.TabPage tabPage_InternetQuelle;
        private System.Windows.Forms.Button button_AddQuelle;
        private System.Windows.Forms.Panel panel_InternetQuelle;
    }
}
