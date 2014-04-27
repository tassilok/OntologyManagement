namespace ImageList_Module
{
    partial class UserControl_Image
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
            this.checkBox_isRoot = new System.Windows.Forms.CheckBox();
            this.label_KindOfOntology = new System.Windows.Forms.Label();
            this.comboBox_KindOfOntology = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // checkBox_isRoot
            // 
            this.checkBox_isRoot.AutoSize = true;
            this.checkBox_isRoot.Location = new System.Drawing.Point(101, 4);
            this.checkBox_isRoot.Name = "checkBox_isRoot";
            this.checkBox_isRoot.Size = new System.Drawing.Size(70, 17);
            this.checkBox_isRoot.TabIndex = 1;
            this.checkBox_isRoot.Text = "x_is Root";
            this.checkBox_isRoot.UseVisualStyleBackColor = true;
            // 
            // label_KindOfOntology
            // 
            this.label_KindOfOntology.AutoSize = true;
            this.label_KindOfOntology.Location = new System.Drawing.Point(5, 30);
            this.label_KindOfOntology.Name = "label_KindOfOntology";
            this.label_KindOfOntology.Size = new System.Drawing.Size(90, 13);
            this.label_KindOfOntology.TabIndex = 2;
            this.label_KindOfOntology.Text = "x_Ontology-Type:";
            // 
            // comboBox_KindOfOntology
            // 
            this.comboBox_KindOfOntology.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_KindOfOntology.FormattingEnabled = true;
            this.comboBox_KindOfOntology.Location = new System.Drawing.Point(101, 27);
            this.comboBox_KindOfOntology.Name = "comboBox_KindOfOntology";
            this.comboBox_KindOfOntology.Size = new System.Drawing.Size(271, 21);
            this.comboBox_KindOfOntology.TabIndex = 3;
            // 
            // UserControl_Image
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox_KindOfOntology);
            this.Controls.Add(this.label_KindOfOntology);
            this.Controls.Add(this.checkBox_isRoot);
            this.Name = "UserControl_Image";
            this.Size = new System.Drawing.Size(375, 549);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_isRoot;
        private System.Windows.Forms.Label label_KindOfOntology;
        private System.Windows.Forms.ComboBox comboBox_KindOfOntology;
    }
}
