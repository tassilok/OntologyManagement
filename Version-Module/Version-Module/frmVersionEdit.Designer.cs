namespace Version_Module
{
    partial class frmVersionEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVersionEdit));
            this.userControl_VersionEdit = new Version_Module.UserControl_VersionEdit();
            this.SuspendLayout();
            // 
            // userControl_VersionEdit
            // 
            this.userControl_VersionEdit.Build = ((long)(0));
            this.userControl_VersionEdit.Location = new System.Drawing.Point(1, 2);
            this.userControl_VersionEdit.Major = ((long)(0));
            this.userControl_VersionEdit.Minor = ((long)(0));
            this.userControl_VersionEdit.Name = "userControl_VersionEdit";
            this.userControl_VersionEdit.Revision = ((long)(0));
            this.userControl_VersionEdit.Size = new System.Drawing.Size(300, 76);
            this.userControl_VersionEdit.TabIndex = 0;
            this.userControl_VersionEdit.applied_Version += new Version_Module.Applied_Version(this.userControl_VersionEdit_applied_Version);
            this.userControl_VersionEdit.Load += new System.EventHandler(this.userControl_VersionEdit_Load);
            // 
            // frmVersionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 83);
            this.Controls.Add(this.userControl_VersionEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmVersionEdit";
            this.Text = "x_Version-Edit";
            this.Load += new System.EventHandler(this.frmVersionEdit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControl_VersionEdit userControl_VersionEdit;
    }
}