namespace LiteraturQuellen_Module
{
    partial class UserControl_InternetQuelle
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
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage_Data = new System.Windows.Forms.TabPage();
            this.Panel_Begriffe = new System.Windows.Forms.Panel();
            this.TextBox_URL = new System.Windows.Forms.TextBox();
            this.Label_Partner = new System.Windows.Forms.Label();
            this.Button_AddPartner = new System.Windows.Forms.Button();
            this.TextBox_Partner = new System.Windows.Forms.TextBox();
            this.Label_DownloadTimstamp = new System.Windows.Forms.Label();
            this.DateTimePicker_Download = new System.Windows.Forms.DateTimePicker();
            this.Button_AddURL = new System.Windows.Forms.Button();
            this.Label_URL = new System.Windows.Forms.Label();
            this.TabPage_PDF = new System.Windows.Forms.TabPage();
            this.TabControl1.SuspendLayout();
            this.TabPage_Data.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage_Data);
            this.TabControl1.Controls.Add(this.TabPage_PDF);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(385, 405);
            this.TabControl1.TabIndex = 1;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // TabPage_Data
            // 
            this.TabPage_Data.Controls.Add(this.Panel_Begriffe);
            this.TabPage_Data.Controls.Add(this.TextBox_URL);
            this.TabPage_Data.Controls.Add(this.Label_Partner);
            this.TabPage_Data.Controls.Add(this.Button_AddPartner);
            this.TabPage_Data.Controls.Add(this.TextBox_Partner);
            this.TabPage_Data.Controls.Add(this.Label_DownloadTimstamp);
            this.TabPage_Data.Controls.Add(this.DateTimePicker_Download);
            this.TabPage_Data.Controls.Add(this.Button_AddURL);
            this.TabPage_Data.Controls.Add(this.Label_URL);
            this.TabPage_Data.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Data.Name = "TabPage_Data";
            this.TabPage_Data.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Data.Size = new System.Drawing.Size(377, 379);
            this.TabPage_Data.TabIndex = 0;
            this.TabPage_Data.Text = "x_Quelldaten";
            this.TabPage_Data.UseVisualStyleBackColor = true;
            // 
            // Panel_Begriffe
            // 
            this.Panel_Begriffe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Begriffe.Location = new System.Drawing.Point(82, 87);
            this.Panel_Begriffe.Name = "Panel_Begriffe";
            this.Panel_Begriffe.Size = new System.Drawing.Size(252, 286);
            this.Panel_Begriffe.TabIndex = 10;
            this.Panel_Begriffe.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Begriffe_Paint);
            // 
            // TextBox_URL
            // 
            this.TextBox_URL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_URL.Location = new System.Drawing.Point(82, 5);
            this.TextBox_URL.Name = "TextBox_URL";
            this.TextBox_URL.ReadOnly = true;
            this.TextBox_URL.Size = new System.Drawing.Size(252, 20);
            this.TextBox_URL.TabIndex = 9;
            this.TextBox_URL.DoubleClick += new System.EventHandler(this.TextBox_URL_DoubleClick);
            // 
            // Label_Partner
            // 
            this.Label_Partner.AutoSize = true;
            this.Label_Partner.Location = new System.Drawing.Point(7, 62);
            this.Label_Partner.Name = "Label_Partner";
            this.Label_Partner.Size = new System.Drawing.Size(58, 13);
            this.Label_Partner.TabIndex = 8;
            this.Label_Partner.Text = "x_Ersteller:";
            // 
            // Button_AddPartner
            // 
            this.Button_AddPartner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_AddPartner.Location = new System.Drawing.Point(340, 58);
            this.Button_AddPartner.Name = "Button_AddPartner";
            this.Button_AddPartner.Size = new System.Drawing.Size(31, 23);
            this.Button_AddPartner.TabIndex = 7;
            this.Button_AddPartner.Text = "...";
            this.Button_AddPartner.UseVisualStyleBackColor = true;
            this.Button_AddPartner.Click += new System.EventHandler(this.Button_AddPartner_Click);
            // 
            // TextBox_Partner
            // 
            this.TextBox_Partner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Partner.Location = new System.Drawing.Point(82, 60);
            this.TextBox_Partner.Name = "TextBox_Partner";
            this.TextBox_Partner.ReadOnly = true;
            this.TextBox_Partner.Size = new System.Drawing.Size(252, 20);
            this.TextBox_Partner.TabIndex = 6;
            // 
            // Label_DownloadTimstamp
            // 
            this.Label_DownloadTimstamp.AutoSize = true;
            this.Label_DownloadTimstamp.Location = new System.Drawing.Point(7, 36);
            this.Label_DownloadTimstamp.Name = "Label_DownloadTimstamp";
            this.Label_DownloadTimstamp.Size = new System.Drawing.Size(69, 13);
            this.Label_DownloadTimstamp.TabIndex = 5;
            this.Label_DownloadTimstamp.Text = "x_Download:";
            // 
            // DateTimePicker_Download
            // 
            this.DateTimePicker_Download.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimePicker_Download.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.DateTimePicker_Download.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker_Download.Location = new System.Drawing.Point(82, 33);
            this.DateTimePicker_Download.Name = "DateTimePicker_Download";
            this.DateTimePicker_Download.Size = new System.Drawing.Size(252, 20);
            this.DateTimePicker_Download.TabIndex = 4;
            this.DateTimePicker_Download.ValueChanged += new System.EventHandler(this.DateTimePicker_Download_ValueChanged);
            // 
            // Button_AddURL
            // 
            this.Button_AddURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_AddURL.Location = new System.Drawing.Point(340, 4);
            this.Button_AddURL.Name = "Button_AddURL";
            this.Button_AddURL.Size = new System.Drawing.Size(31, 23);
            this.Button_AddURL.TabIndex = 2;
            this.Button_AddURL.Text = "...";
            this.Button_AddURL.UseVisualStyleBackColor = true;
            this.Button_AddURL.Click += new System.EventHandler(this.Button_AddURL_Click);
            // 
            // Label_URL
            // 
            this.Label_URL.AutoSize = true;
            this.Label_URL.Location = new System.Drawing.Point(7, 8);
            this.Label_URL.Name = "Label_URL";
            this.Label_URL.Size = new System.Drawing.Size(43, 13);
            this.Label_URL.TabIndex = 0;
            this.Label_URL.Text = "x_URL:";
            // 
            // TabPage_PDF
            // 
            this.TabPage_PDF.Location = new System.Drawing.Point(4, 22);
            this.TabPage_PDF.Name = "TabPage_PDF";
            this.TabPage_PDF.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_PDF.Size = new System.Drawing.Size(377, 379);
            this.TabPage_PDF.TabIndex = 1;
            this.TabPage_PDF.Text = "x_PDF";
            this.TabPage_PDF.UseVisualStyleBackColor = true;
            // 
            // UserControl_InternetQuelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TabControl1);
            this.Name = "UserControl_InternetQuelle";
            this.Size = new System.Drawing.Size(385, 405);
            this.TabControl1.ResumeLayout(false);
            this.TabPage_Data.ResumeLayout(false);
            this.TabPage_Data.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage_Data;
        internal System.Windows.Forms.Panel Panel_Begriffe;
        internal System.Windows.Forms.TextBox TextBox_URL;
        internal System.Windows.Forms.Label Label_Partner;
        internal System.Windows.Forms.Button Button_AddPartner;
        internal System.Windows.Forms.TextBox TextBox_Partner;
        internal System.Windows.Forms.Label Label_DownloadTimstamp;
        internal System.Windows.Forms.DateTimePicker DateTimePicker_Download;
        internal System.Windows.Forms.Button Button_AddURL;
        internal System.Windows.Forms.Label Label_URL;
        internal System.Windows.Forms.TabPage TabPage_PDF;
    }
}
