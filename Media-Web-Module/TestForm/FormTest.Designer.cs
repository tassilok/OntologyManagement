namespace TestForm
{
    partial class FormTest
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_Test = new System.Windows.Forms.Panel();
            this.button_TestExtensions = new System.Windows.Forms.Button();
            this.button_Files = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel_Test
            // 
            this.panel_Test.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Test.Location = new System.Drawing.Point(2, 32);
            this.panel_Test.Name = "panel_Test";
            this.panel_Test.Size = new System.Drawing.Size(282, 227);
            this.panel_Test.TabIndex = 0;
            // 
            // button_TestExtensions
            // 
            this.button_TestExtensions.Location = new System.Drawing.Point(2, 3);
            this.button_TestExtensions.Name = "button_TestExtensions";
            this.button_TestExtensions.Size = new System.Drawing.Size(75, 23);
            this.button_TestExtensions.TabIndex = 1;
            this.button_TestExtensions.Text = "x_Extensions";
            this.button_TestExtensions.UseVisualStyleBackColor = true;
            this.button_TestExtensions.Click += new System.EventHandler(this.button_TestExtensions_Click);
            // 
            // button_Files
            // 
            this.button_Files.Location = new System.Drawing.Point(84, 3);
            this.button_Files.Name = "button_Files";
            this.button_Files.Size = new System.Drawing.Size(75, 23);
            this.button_Files.TabIndex = 2;
            this.button_Files.Text = "x_Files";
            this.button_Files.UseVisualStyleBackColor = true;
            this.button_Files.Click += new System.EventHandler(this.button_Files_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button_Files);
            this.Controls.Add(this.button_TestExtensions);
            this.Controls.Add(this.panel_Test);
            this.Name = "FormTest";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Test;
        private System.Windows.Forms.Button button_TestExtensions;
        private System.Windows.Forms.Button button_Files;
    }
}

