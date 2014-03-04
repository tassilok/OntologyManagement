namespace Code_Modeller_module
{
    partial class UserControl_CodeModell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_CodeModell));
            this.imageList_CodeModel = new System.Windows.Forms.ImageList(this.components);
            this.treeView_CodeModel = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // imageList_CodeModel
            // 
            this.imageList_CodeModel.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_CodeModel.ImageStream")));
            this.imageList_CodeModel.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_CodeModel.Images.SetKeyName(0, "Root");
            this.imageList_CodeModel.Images.SetKeyName(1, "Process");
            this.imageList_CodeModel.Images.SetKeyName(2, "Exit");
            this.imageList_CodeModel.Images.SetKeyName(3, "Alternative");
            this.imageList_CodeModel.Images.SetKeyName(4, "Loop");
            this.imageList_CodeModel.Images.SetKeyName(5, "Parameter");
            // 
            // treeView_CodeModel
            // 
            this.treeView_CodeModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_CodeModel.Location = new System.Drawing.Point(0, 0);
            this.treeView_CodeModel.Name = "treeView_CodeModel";
            this.treeView_CodeModel.Size = new System.Drawing.Size(590, 456);
            this.treeView_CodeModel.TabIndex = 0;
            // 
            // UserControl_CodeModell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView_CodeModel);
            this.Name = "UserControl_CodeModell";
            this.Size = new System.Drawing.Size(590, 456);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList_CodeModel;
        private System.Windows.Forms.TreeView treeView_CodeModel;
    }
}
