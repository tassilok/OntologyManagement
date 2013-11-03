namespace LiteraturQuellen_Module
{
    partial class UserControl_Buchquelle
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_Buchquelle));
            this.Button_DelParent = new System.Windows.Forms.Button();
            this.ImageList_Main = new System.Windows.Forms.ImageList(this.components);
            this.Button_ParentQuelle = new System.Windows.Forms.Button();
            this.TextBox_ParentQuelle = new System.Windows.Forms.TextBox();
            this.Label_ParentQuelle = new System.Windows.Forms.Label();
            this.Button_Literatur = new System.Windows.Forms.Button();
            this.TextBox_Literatur = new System.Windows.Forms.TextBox();
            this.Label_Literatur = new System.Windows.Forms.Label();
            this.Panel_Begriffe = new System.Windows.Forms.Panel();
            this.Label_Begriffe = new System.Windows.Forms.Label();
            this.TextBox_Seite = new System.Windows.Forms.TextBox();
            this.Label_Seite = new System.Windows.Forms.Label();
            this.timer_Seite = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Button_DelParent
            // 
            this.Button_DelParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_DelParent.Enabled = false;
            this.Button_DelParent.ImageIndex = 0;
            this.Button_DelParent.ImageList = this.ImageList_Main;
            this.Button_DelParent.Location = new System.Drawing.Point(464, 382);
            this.Button_DelParent.Name = "Button_DelParent";
            this.Button_DelParent.Size = new System.Drawing.Size(24, 23);
            this.Button_DelParent.TabIndex = 23;
            this.Button_DelParent.UseVisualStyleBackColor = true;
            this.Button_DelParent.Click += new System.EventHandler(this.Button_DelParent_Click);
            // 
            // ImageList_Main
            // 
            this.ImageList_Main.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList_Main.ImageStream")));
            this.ImageList_Main.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList_Main.Images.SetKeyName(0, "tasto_8_architetto_franc_01.png");
            // 
            // Button_ParentQuelle
            // 
            this.Button_ParentQuelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_ParentQuelle.Enabled = false;
            this.Button_ParentQuelle.Location = new System.Drawing.Point(440, 382);
            this.Button_ParentQuelle.Name = "Button_ParentQuelle";
            this.Button_ParentQuelle.Size = new System.Drawing.Size(24, 23);
            this.Button_ParentQuelle.TabIndex = 22;
            this.Button_ParentQuelle.Text = "...";
            this.Button_ParentQuelle.UseVisualStyleBackColor = true;
            this.Button_ParentQuelle.Click += new System.EventHandler(this.Button_ParentQuelle_Click);
            // 
            // TextBox_ParentQuelle
            // 
            this.TextBox_ParentQuelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_ParentQuelle.Enabled = false;
            this.TextBox_ParentQuelle.Location = new System.Drawing.Point(113, 382);
            this.TextBox_ParentQuelle.Name = "TextBox_ParentQuelle";
            this.TextBox_ParentQuelle.Size = new System.Drawing.Size(321, 20);
            this.TextBox_ParentQuelle.TabIndex = 21;
            // 
            // Label_ParentQuelle
            // 
            this.Label_ParentQuelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_ParentQuelle.AutoSize = true;
            this.Label_ParentQuelle.Location = new System.Drawing.Point(5, 385);
            this.Label_ParentQuelle.Name = "Label_ParentQuelle";
            this.Label_ParentQuelle.Size = new System.Drawing.Size(103, 13);
            this.Label_ParentQuelle.TabIndex = 20;
            this.Label_ParentQuelle.Text = "Buchquelle (Parent):";
            // 
            // Button_Literatur
            // 
            this.Button_Literatur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Literatur.Enabled = false;
            this.Button_Literatur.Location = new System.Drawing.Point(466, 30);
            this.Button_Literatur.Name = "Button_Literatur";
            this.Button_Literatur.Size = new System.Drawing.Size(24, 23);
            this.Button_Literatur.TabIndex = 19;
            this.Button_Literatur.Text = "...";
            this.Button_Literatur.UseVisualStyleBackColor = true;
            this.Button_Literatur.Click += new System.EventHandler(this.Button_Literatur_Click);
            // 
            // TextBox_Literatur
            // 
            this.TextBox_Literatur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Literatur.Enabled = false;
            this.TextBox_Literatur.Location = new System.Drawing.Point(114, 32);
            this.TextBox_Literatur.Name = "TextBox_Literatur";
            this.TextBox_Literatur.Size = new System.Drawing.Size(346, 20);
            this.TextBox_Literatur.TabIndex = 18;
            // 
            // Label_Literatur
            // 
            this.Label_Literatur.AutoSize = true;
            this.Label_Literatur.Location = new System.Drawing.Point(3, 35);
            this.Label_Literatur.Name = "Label_Literatur";
            this.Label_Literatur.Size = new System.Drawing.Size(56, 13);
            this.Label_Literatur.TabIndex = 17;
            this.Label_Literatur.Text = "x_Literatur";
            // 
            // Panel_Begriffe
            // 
            this.Panel_Begriffe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Begriffe.Location = new System.Drawing.Point(114, 58);
            this.Panel_Begriffe.Name = "Panel_Begriffe";
            this.Panel_Begriffe.Size = new System.Drawing.Size(376, 318);
            this.Panel_Begriffe.TabIndex = 16;
            // 
            // Label_Begriffe
            // 
            this.Label_Begriffe.AutoSize = true;
            this.Label_Begriffe.Location = new System.Drawing.Point(3, 58);
            this.Label_Begriffe.Name = "Label_Begriffe";
            this.Label_Begriffe.Size = new System.Drawing.Size(57, 13);
            this.Label_Begriffe.TabIndex = 15;
            this.Label_Begriffe.Text = "x_Begriffe:";
            // 
            // TextBox_Seite
            // 
            this.TextBox_Seite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Seite.Enabled = false;
            this.TextBox_Seite.Location = new System.Drawing.Point(114, 7);
            this.TextBox_Seite.Name = "TextBox_Seite";
            this.TextBox_Seite.Size = new System.Drawing.Size(376, 20);
            this.TextBox_Seite.TabIndex = 14;
            this.TextBox_Seite.TextChanged += new System.EventHandler(this.TextBox_Seite_TextChanged);
            // 
            // Label_Seite
            // 
            this.Label_Seite.AutoSize = true;
            this.Label_Seite.Location = new System.Drawing.Point(3, 10);
            this.Label_Seite.Name = "Label_Seite";
            this.Label_Seite.Size = new System.Drawing.Size(45, 13);
            this.Label_Seite.TabIndex = 13;
            this.Label_Seite.Text = "x_Seite:";
            // 
            // timer_Seite
            // 
            this.timer_Seite.Interval = 300;
            this.timer_Seite.Tick += new System.EventHandler(this.timer_Seite_Tick);
            // 
            // UserControl_Buchquelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Button_DelParent);
            this.Controls.Add(this.Button_ParentQuelle);
            this.Controls.Add(this.TextBox_ParentQuelle);
            this.Controls.Add(this.Label_ParentQuelle);
            this.Controls.Add(this.Button_Literatur);
            this.Controls.Add(this.TextBox_Literatur);
            this.Controls.Add(this.Label_Literatur);
            this.Controls.Add(this.Panel_Begriffe);
            this.Controls.Add(this.Label_Begriffe);
            this.Controls.Add(this.TextBox_Seite);
            this.Controls.Add(this.Label_Seite);
            this.Name = "UserControl_Buchquelle";
            this.Size = new System.Drawing.Size(493, 408);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Button_DelParent;
        internal System.Windows.Forms.Button Button_ParentQuelle;
        internal System.Windows.Forms.TextBox TextBox_ParentQuelle;
        internal System.Windows.Forms.Label Label_ParentQuelle;
        internal System.Windows.Forms.Button Button_Literatur;
        internal System.Windows.Forms.TextBox TextBox_Literatur;
        internal System.Windows.Forms.Label Label_Literatur;
        internal System.Windows.Forms.Panel Panel_Begriffe;
        internal System.Windows.Forms.Label Label_Begriffe;
        internal System.Windows.Forms.TextBox TextBox_Seite;
        internal System.Windows.Forms.Label Label_Seite;
        internal System.Windows.Forms.ImageList ImageList_Main;
        private System.Windows.Forms.Timer timer_Seite;
    }
}
