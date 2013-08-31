namespace Scenes_Literatur_Module
{
    partial class UserControl_SceneDetail
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label_Scene = new System.Windows.Forms.Label();
            this.textBox_Scene = new System.Windows.Forms.TextBox();
            this.label_LiteratureDate = new System.Windows.Forms.Label();
            this.label_LiteratureCharacter = new System.Windows.Forms.Label();
            this.label_LateratureLocation = new System.Windows.Forms.Label();
            this.panel_LiteratureDate = new System.Windows.Forms.Panel();
            this.panel_LiteratureCharacter = new System.Windows.Forms.Panel();
            this.panel_LiteratureLocation = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Images = new System.Windows.Forms.TabPage();
            this.tabPage_Media = new System.Windows.Forms.TabPage();
            this.tabPage_PDF = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox_Scene);
            this.splitContainer1.Panel1.Controls.Add(this.label_Scene);
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(630, 498);
            this.splitContainer1.SplitterDistance = 297;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Location = new System.Drawing.Point(3, 32);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel_LiteratureDate);
            this.splitContainer2.Panel1.Controls.Add(this.label_LiteratureDate);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(287, 459);
            this.splitContainer2.SplitterDistance = 146;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.panel_LiteratureCharacter);
            this.splitContainer3.Panel1.Controls.Add(this.label_LiteratureCharacter);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.panel_LiteratureLocation);
            this.splitContainer3.Panel2.Controls.Add(this.label_LateratureLocation);
            this.splitContainer3.Size = new System.Drawing.Size(287, 309);
            this.splitContainer3.SplitterDistance = 156;
            this.splitContainer3.TabIndex = 0;
            // 
            // label_Scene
            // 
            this.label_Scene.AutoSize = true;
            this.label_Scene.Location = new System.Drawing.Point(4, 8);
            this.label_Scene.Name = "label_Scene";
            this.label_Scene.Size = new System.Drawing.Size(52, 13);
            this.label_Scene.TabIndex = 1;
            this.label_Scene.Text = "x_Scene:";
            // 
            // textBox_Scene
            // 
            this.textBox_Scene.Location = new System.Drawing.Point(62, 6);
            this.textBox_Scene.Name = "textBox_Scene";
            this.textBox_Scene.ReadOnly = true;
            this.textBox_Scene.Size = new System.Drawing.Size(228, 20);
            this.textBox_Scene.TabIndex = 2;
            // 
            // label_LiteratureDate
            // 
            this.label_LiteratureDate.AutoSize = true;
            this.label_LiteratureDate.Location = new System.Drawing.Point(4, 4);
            this.label_LiteratureDate.Name = "label_LiteratureDate";
            this.label_LiteratureDate.Size = new System.Drawing.Size(114, 13);
            this.label_LiteratureDate.TabIndex = 0;
            this.label_LiteratureDate.Text = "x_Literarisches Datum:";
            // 
            // label_LiteratureCharacter
            // 
            this.label_LiteratureCharacter.AutoSize = true;
            this.label_LiteratureCharacter.Location = new System.Drawing.Point(4, 4);
            this.label_LiteratureCharacter.Name = "label_LiteratureCharacter";
            this.label_LiteratureCharacter.Size = new System.Drawing.Size(127, 13);
            this.label_LiteratureCharacter.TabIndex = 0;
            this.label_LiteratureCharacter.Text = "x_Literarischer Charakter:";
            // 
            // label_LateratureLocation
            // 
            this.label_LateratureLocation.AutoSize = true;
            this.label_LateratureLocation.Location = new System.Drawing.Point(2, 4);
            this.label_LateratureLocation.Name = "label_LateratureLocation";
            this.label_LateratureLocation.Size = new System.Drawing.Size(95, 13);
            this.label_LateratureLocation.TabIndex = 0;
            this.label_LateratureLocation.Text = "x_Literarischer Ort:";
            // 
            // panel_LiteratureDate
            // 
            this.panel_LiteratureDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_LiteratureDate.Location = new System.Drawing.Point(2, 20);
            this.panel_LiteratureDate.Name = "panel_LiteratureDate";
            this.panel_LiteratureDate.Size = new System.Drawing.Size(278, 119);
            this.panel_LiteratureDate.TabIndex = 1;
            // 
            // panel_LiteratureCharacter
            // 
            this.panel_LiteratureCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_LiteratureCharacter.Location = new System.Drawing.Point(3, 20);
            this.panel_LiteratureCharacter.Name = "panel_LiteratureCharacter";
            this.panel_LiteratureCharacter.Size = new System.Drawing.Size(278, 129);
            this.panel_LiteratureCharacter.TabIndex = 2;
            // 
            // panel_LiteratureLocation
            // 
            this.panel_LiteratureLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_LiteratureLocation.Location = new System.Drawing.Point(2, 20);
            this.panel_LiteratureLocation.Name = "panel_LiteratureLocation";
            this.panel_LiteratureLocation.Size = new System.Drawing.Size(278, 122);
            this.panel_LiteratureLocation.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Images);
            this.tabControl1.Controls.Add(this.tabPage_Media);
            this.tabControl1.Controls.Add(this.tabPage_PDF);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(325, 494);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_Images
            // 
            this.tabPage_Images.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Images.Name = "tabPage_Images";
            this.tabPage_Images.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Images.Size = new System.Drawing.Size(317, 468);
            this.tabPage_Images.TabIndex = 0;
            this.tabPage_Images.Text = "x_Images";
            this.tabPage_Images.UseVisualStyleBackColor = true;
            // 
            // tabPage_Media
            // 
            this.tabPage_Media.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Media.Name = "tabPage_Media";
            this.tabPage_Media.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Media.Size = new System.Drawing.Size(317, 468);
            this.tabPage_Media.TabIndex = 1;
            this.tabPage_Media.Text = "x_Audio/Video";
            this.tabPage_Media.UseVisualStyleBackColor = true;
            // 
            // tabPage_PDF
            // 
            this.tabPage_PDF.Location = new System.Drawing.Point(4, 22);
            this.tabPage_PDF.Name = "tabPage_PDF";
            this.tabPage_PDF.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_PDF.Size = new System.Drawing.Size(317, 468);
            this.tabPage_PDF.TabIndex = 2;
            this.tabPage_PDF.Text = "x_PDF";
            this.tabPage_PDF.UseVisualStyleBackColor = true;
            // 
            // UserControl_SceneDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControl_SceneDetail";
            this.Size = new System.Drawing.Size(630, 498);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label_Scene;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox textBox_Scene;
        private System.Windows.Forms.Panel panel_LiteratureDate;
        private System.Windows.Forms.Label label_LiteratureDate;
        private System.Windows.Forms.Panel panel_LiteratureCharacter;
        private System.Windows.Forms.Label label_LiteratureCharacter;
        private System.Windows.Forms.Panel panel_LiteratureLocation;
        private System.Windows.Forms.Label label_LateratureLocation;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Images;
        private System.Windows.Forms.TabPage tabPage_Media;
        private System.Windows.Forms.TabPage tabPage_PDF;
    }
}
