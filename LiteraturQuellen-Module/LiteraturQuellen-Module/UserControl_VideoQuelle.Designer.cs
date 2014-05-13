namespace LiteraturQuellen_Module
{
    partial class UserControl_VideoQuelle
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
            this.tabPage_Video = new System.Windows.Forms.TabPage();
            this.label_Video = new System.Windows.Forms.Label();
            this.panel_Video = new System.Windows.Forms.Panel();
            this.dateTimePicker_Ausstrahlungsdatum = new System.Windows.Forms.DateTimePicker();
            this.button_AddSender = new System.Windows.Forms.Button();
            this.textBox_Sender = new System.Windows.Forms.TextBox();
            this.label_Sender = new System.Windows.Forms.Label();
            this.button_AddSendung = new System.Windows.Forms.Button();
            this.textBox_Sendung = new System.Windows.Forms.TextBox();
            this.label_Sendung = new System.Windows.Forms.Label();
            this.button_AddAutor = new System.Windows.Forms.Button();
            this.textBox_Autor = new System.Windows.Forms.TextBox();
            this.label_Author = new System.Windows.Forms.Label();
            this.tabPage_InternetQuelle = new System.Windows.Forms.TabPage();
            this.button_AddQuelle = new System.Windows.Forms.Button();
            this.panel_InternetQuelle = new System.Windows.Forms.Panel();
            this.checkBox_Ausstrahlung = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage_Video.SuspendLayout();
            this.tabPage_InternetQuelle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Video);
            this.tabControl1.Controls.Add(this.tabPage_InternetQuelle);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(417, 428);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage_Video
            // 
            this.tabPage_Video.Controls.Add(this.checkBox_Ausstrahlung);
            this.tabPage_Video.Controls.Add(this.label_Video);
            this.tabPage_Video.Controls.Add(this.panel_Video);
            this.tabPage_Video.Controls.Add(this.dateTimePicker_Ausstrahlungsdatum);
            this.tabPage_Video.Controls.Add(this.button_AddSender);
            this.tabPage_Video.Controls.Add(this.textBox_Sender);
            this.tabPage_Video.Controls.Add(this.label_Sender);
            this.tabPage_Video.Controls.Add(this.button_AddSendung);
            this.tabPage_Video.Controls.Add(this.textBox_Sendung);
            this.tabPage_Video.Controls.Add(this.label_Sendung);
            this.tabPage_Video.Controls.Add(this.button_AddAutor);
            this.tabPage_Video.Controls.Add(this.textBox_Autor);
            this.tabPage_Video.Controls.Add(this.label_Author);
            this.tabPage_Video.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Video.Name = "tabPage_Video";
            this.tabPage_Video.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Video.Size = new System.Drawing.Size(409, 402);
            this.tabPage_Video.TabIndex = 0;
            this.tabPage_Video.Text = "x_Video";
            this.tabPage_Video.UseVisualStyleBackColor = true;
            // 
            // label_Video
            // 
            this.label_Video.AutoSize = true;
            this.label_Video.Location = new System.Drawing.Point(9, 128);
            this.label_Video.Name = "label_Video";
            this.label_Video.Size = new System.Drawing.Size(48, 13);
            this.label_Video.TabIndex = 23;
            this.label_Video.Text = "x_Video:";
            // 
            // panel_Video
            // 
            this.panel_Video.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Video.Location = new System.Drawing.Point(9, 147);
            this.panel_Video.Name = "panel_Video";
            this.panel_Video.Size = new System.Drawing.Size(394, 249);
            this.panel_Video.TabIndex = 22;
            // 
            // dateTimePicker_Ausstrahlungsdatum
            // 
            this.dateTimePicker_Ausstrahlungsdatum.Enabled = false;
            this.dateTimePicker_Ausstrahlungsdatum.Location = new System.Drawing.Point(113, 9);
            this.dateTimePicker_Ausstrahlungsdatum.Name = "dateTimePicker_Ausstrahlungsdatum";
            this.dateTimePicker_Ausstrahlungsdatum.Size = new System.Drawing.Size(260, 20);
            this.dateTimePicker_Ausstrahlungsdatum.TabIndex = 21;
            this.dateTimePicker_Ausstrahlungsdatum.ValueChanged += new System.EventHandler(this.dateTimePicker_Ausstrahlungsdatum_ValueChanged);
            // 
            // button_AddSender
            // 
            this.button_AddSender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AddSender.Enabled = false;
            this.button_AddSender.Location = new System.Drawing.Point(379, 85);
            this.button_AddSender.Name = "button_AddSender";
            this.button_AddSender.Size = new System.Drawing.Size(26, 23);
            this.button_AddSender.TabIndex = 19;
            this.button_AddSender.Text = "...";
            this.button_AddSender.UseVisualStyleBackColor = true;
            this.button_AddSender.Click += new System.EventHandler(this.button_AddSender_Click);
            // 
            // textBox_Sender
            // 
            this.textBox_Sender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Sender.Location = new System.Drawing.Point(113, 87);
            this.textBox_Sender.Name = "textBox_Sender";
            this.textBox_Sender.ReadOnly = true;
            this.textBox_Sender.Size = new System.Drawing.Size(260, 20);
            this.textBox_Sender.TabIndex = 18;
            // 
            // label_Sender
            // 
            this.label_Sender.AutoSize = true;
            this.label_Sender.Location = new System.Drawing.Point(6, 90);
            this.label_Sender.Name = "label_Sender";
            this.label_Sender.Size = new System.Drawing.Size(55, 13);
            this.label_Sender.TabIndex = 17;
            this.label_Sender.Text = "x_Sender:";
            // 
            // button_AddSendung
            // 
            this.button_AddSendung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AddSendung.Enabled = false;
            this.button_AddSendung.Location = new System.Drawing.Point(379, 59);
            this.button_AddSendung.Name = "button_AddSendung";
            this.button_AddSendung.Size = new System.Drawing.Size(26, 23);
            this.button_AddSendung.TabIndex = 16;
            this.button_AddSendung.Text = "...";
            this.button_AddSendung.UseVisualStyleBackColor = true;
            this.button_AddSendung.Click += new System.EventHandler(this.button_AddSendung_Click);
            // 
            // textBox_Sendung
            // 
            this.textBox_Sendung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Sendung.Location = new System.Drawing.Point(113, 61);
            this.textBox_Sendung.Name = "textBox_Sendung";
            this.textBox_Sendung.ReadOnly = true;
            this.textBox_Sendung.Size = new System.Drawing.Size(260, 20);
            this.textBox_Sendung.TabIndex = 15;
            // 
            // label_Sendung
            // 
            this.label_Sendung.AutoSize = true;
            this.label_Sendung.Location = new System.Drawing.Point(6, 64);
            this.label_Sendung.Name = "label_Sendung";
            this.label_Sendung.Size = new System.Drawing.Size(64, 13);
            this.label_Sendung.TabIndex = 14;
            this.label_Sendung.Text = "x_Sendung:";
            // 
            // button_AddAutor
            // 
            this.button_AddAutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AddAutor.Enabled = false;
            this.button_AddAutor.Location = new System.Drawing.Point(379, 33);
            this.button_AddAutor.Name = "button_AddAutor";
            this.button_AddAutor.Size = new System.Drawing.Size(26, 23);
            this.button_AddAutor.TabIndex = 13;
            this.button_AddAutor.Text = "...";
            this.button_AddAutor.UseVisualStyleBackColor = true;
            this.button_AddAutor.Click += new System.EventHandler(this.button_AddAutor_Click);
            // 
            // textBox_Autor
            // 
            this.textBox_Autor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Autor.Location = new System.Drawing.Point(113, 35);
            this.textBox_Autor.Name = "textBox_Autor";
            this.textBox_Autor.ReadOnly = true;
            this.textBox_Autor.Size = new System.Drawing.Size(260, 20);
            this.textBox_Autor.TabIndex = 12;
            // 
            // label_Author
            // 
            this.label_Author.AutoSize = true;
            this.label_Author.Location = new System.Drawing.Point(6, 37);
            this.label_Author.Name = "label_Author";
            this.label_Author.Size = new System.Drawing.Size(46, 13);
            this.label_Author.TabIndex = 11;
            this.label_Author.Text = "x_Autor:";
            // 
            // tabPage_InternetQuelle
            // 
            this.tabPage_InternetQuelle.Controls.Add(this.button_AddQuelle);
            this.tabPage_InternetQuelle.Controls.Add(this.panel_InternetQuelle);
            this.tabPage_InternetQuelle.Location = new System.Drawing.Point(4, 22);
            this.tabPage_InternetQuelle.Name = "tabPage_InternetQuelle";
            this.tabPage_InternetQuelle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_InternetQuelle.Size = new System.Drawing.Size(409, 402);
            this.tabPage_InternetQuelle.TabIndex = 1;
            this.tabPage_InternetQuelle.Text = "x_Internet-Quelle";
            this.tabPage_InternetQuelle.UseVisualStyleBackColor = true;
            // 
            // button_AddQuelle
            // 
            this.button_AddQuelle.Location = new System.Drawing.Point(7, 3);
            this.button_AddQuelle.Name = "button_AddQuelle";
            this.button_AddQuelle.Size = new System.Drawing.Size(119, 23);
            this.button_AddQuelle.TabIndex = 1;
            this.button_AddQuelle.Text = "x_Add Internet-Quelle";
            this.button_AddQuelle.UseVisualStyleBackColor = true;
            this.button_AddQuelle.Click += new System.EventHandler(this.button_AddQuelle_Click);
            // 
            // panel_InternetQuelle
            // 
            this.panel_InternetQuelle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_InternetQuelle.Location = new System.Drawing.Point(0, 28);
            this.panel_InternetQuelle.Name = "panel_InternetQuelle";
            this.panel_InternetQuelle.Size = new System.Drawing.Size(409, 374);
            this.panel_InternetQuelle.TabIndex = 0;
            // 
            // checkBox_Ausstrahlung
            // 
            this.checkBox_Ausstrahlung.AutoSize = true;
            this.checkBox_Ausstrahlung.Location = new System.Drawing.Point(6, 10);
            this.checkBox_Ausstrahlung.Name = "checkBox_Ausstrahlung";
            this.checkBox_Ausstrahlung.Size = new System.Drawing.Size(101, 17);
            this.checkBox_Ausstrahlung.TabIndex = 24;
            this.checkBox_Ausstrahlung.Text = "x_Ausstrahlung:";
            this.checkBox_Ausstrahlung.UseVisualStyleBackColor = true;
            this.checkBox_Ausstrahlung.CheckStateChanged += new System.EventHandler(this.checkBox_Ausstrahlung_CheckStateChanged);
            // 
            // UserControl_VideoQuelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UserControl_VideoQuelle";
            this.Size = new System.Drawing.Size(417, 428);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Video.ResumeLayout(false);
            this.tabPage_Video.PerformLayout();
            this.tabPage_InternetQuelle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Video;
        private System.Windows.Forms.TabPage tabPage_InternetQuelle;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Ausstrahlungsdatum;
        private System.Windows.Forms.Button button_AddSender;
        private System.Windows.Forms.TextBox textBox_Sender;
        private System.Windows.Forms.Label label_Sender;
        private System.Windows.Forms.Button button_AddSendung;
        private System.Windows.Forms.TextBox textBox_Sendung;
        private System.Windows.Forms.Label label_Sendung;
        private System.Windows.Forms.Button button_AddAutor;
        private System.Windows.Forms.TextBox textBox_Autor;
        private System.Windows.Forms.Label label_Author;
        private System.Windows.Forms.Panel panel_Video;
        private System.Windows.Forms.Label label_Video;
        private System.Windows.Forms.Button button_AddQuelle;
        private System.Windows.Forms.Panel panel_InternetQuelle;
        private System.Windows.Forms.CheckBox checkBox_Ausstrahlung;
    }
}
