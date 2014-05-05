namespace LiteraturQuellen_Module
{
    partial class UserControl_EmailQuelle
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
            this.tabPage_EmailQuelle = new System.Windows.Forms.TabPage();
            this.tabPage_PDF = new System.Windows.Forms.TabPage();
            this.label_From = new System.Windows.Forms.Label();
            this.textBox_Von = new System.Windows.Forms.TextBox();
            this.button_ChooseMail = new System.Windows.Forms.Button();
            this.label_Sended = new System.Windows.Forms.Label();
            this.textBox_Sended = new System.Windows.Forms.TextBox();
            this.label_An = new System.Windows.Forms.Label();
            this.textBox_An = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage_EmailQuelle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_EmailQuelle);
            this.tabControl1.Controls.Add(this.tabPage_PDF);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(562, 462);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage_EmailQuelle
            // 
            this.tabPage_EmailQuelle.Controls.Add(this.textBox_An);
            this.tabPage_EmailQuelle.Controls.Add(this.label_An);
            this.tabPage_EmailQuelle.Controls.Add(this.textBox_Sended);
            this.tabPage_EmailQuelle.Controls.Add(this.label_Sended);
            this.tabPage_EmailQuelle.Controls.Add(this.button_ChooseMail);
            this.tabPage_EmailQuelle.Controls.Add(this.textBox_Von);
            this.tabPage_EmailQuelle.Controls.Add(this.label_From);
            this.tabPage_EmailQuelle.Location = new System.Drawing.Point(4, 22);
            this.tabPage_EmailQuelle.Name = "tabPage_EmailQuelle";
            this.tabPage_EmailQuelle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_EmailQuelle.Size = new System.Drawing.Size(554, 436);
            this.tabPage_EmailQuelle.TabIndex = 0;
            this.tabPage_EmailQuelle.Text = "x_EmailQuelle";
            this.tabPage_EmailQuelle.UseVisualStyleBackColor = true;
            // 
            // tabPage_PDF
            // 
            this.tabPage_PDF.Location = new System.Drawing.Point(4, 22);
            this.tabPage_PDF.Name = "tabPage_PDF";
            this.tabPage_PDF.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_PDF.Size = new System.Drawing.Size(554, 436);
            this.tabPage_PDF.TabIndex = 1;
            this.tabPage_PDF.Text = "x_PDF";
            this.tabPage_PDF.UseVisualStyleBackColor = true;
            // 
            // label_From
            // 
            this.label_From.AutoSize = true;
            this.label_From.Location = new System.Drawing.Point(7, 60);
            this.label_From.Name = "label_From";
            this.label_From.Size = new System.Drawing.Size(40, 13);
            this.label_From.TabIndex = 0;
            this.label_From.Text = "x_Von:";
            // 
            // textBox_Von
            // 
            this.textBox_Von.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Von.Location = new System.Drawing.Point(69, 57);
            this.textBox_Von.Name = "textBox_Von";
            this.textBox_Von.ReadOnly = true;
            this.textBox_Von.Size = new System.Drawing.Size(479, 20);
            this.textBox_Von.TabIndex = 1;
            // 
            // button_ChooseMail
            // 
            this.button_ChooseMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ChooseMail.Location = new System.Drawing.Point(473, 4);
            this.button_ChooseMail.Name = "button_ChooseMail";
            this.button_ChooseMail.Size = new System.Drawing.Size(75, 23);
            this.button_ChooseMail.TabIndex = 2;
            this.button_ChooseMail.Text = "x_Choose Mail";
            this.button_ChooseMail.UseVisualStyleBackColor = true;
            this.button_ChooseMail.Click += new System.EventHandler(this.button_ChooseMail_Click);
            // 
            // label_Sended
            // 
            this.label_Sended.AutoSize = true;
            this.label_Sended.Location = new System.Drawing.Point(7, 37);
            this.label_Sended.Name = "label_Sended";
            this.label_Sended.Size = new System.Drawing.Size(58, 13);
            this.label_Sended.TabIndex = 3;
            this.label_Sended.Text = "x_Sended:";
            // 
            // textBox_Sended
            // 
            this.textBox_Sended.Location = new System.Drawing.Point(69, 34);
            this.textBox_Sended.Name = "textBox_Sended";
            this.textBox_Sended.ReadOnly = true;
            this.textBox_Sended.Size = new System.Drawing.Size(123, 20);
            this.textBox_Sended.TabIndex = 4;
            // 
            // label_An
            // 
            this.label_An.AutoSize = true;
            this.label_An.Location = new System.Drawing.Point(7, 83);
            this.label_An.Name = "label_An";
            this.label_An.Size = new System.Drawing.Size(34, 13);
            this.label_An.TabIndex = 5;
            this.label_An.Text = "x_An:";
            // 
            // textBox_An
            // 
            this.textBox_An.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_An.Location = new System.Drawing.Point(69, 80);
            this.textBox_An.Name = "textBox_An";
            this.textBox_An.ReadOnly = true;
            this.textBox_An.Size = new System.Drawing.Size(479, 20);
            this.textBox_An.TabIndex = 6;
            // 
            // UserControl_EmailQuelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UserControl_EmailQuelle";
            this.Size = new System.Drawing.Size(562, 462);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_EmailQuelle.ResumeLayout(false);
            this.tabPage_EmailQuelle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_EmailQuelle;
        private System.Windows.Forms.Button button_ChooseMail;
        private System.Windows.Forms.TextBox textBox_Von;
        private System.Windows.Forms.Label label_From;
        private System.Windows.Forms.TabPage tabPage_PDF;
        private System.Windows.Forms.TextBox textBox_Sended;
        private System.Windows.Forms.Label label_Sended;
        private System.Windows.Forms.TextBox textBox_An;
        private System.Windows.Forms.Label label_An;
    }
}
