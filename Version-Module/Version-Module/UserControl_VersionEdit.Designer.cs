namespace Version_Module
{
    partial class UserControl_VersionEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_VersionEdit));
            this.ToolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButton_Apply = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_Clear = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_Cancel = new System.Windows.Forms.ToolStripButton();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NumericUpDown_Marjor = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown_Minor = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown_Build = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown_Revision = new System.Windows.Forms.NumericUpDown();
            this.Label_Major = new System.Windows.Forms.Label();
            this.Label_Minor = new System.Windows.Forms.Label();
            this.Label_Build = new System.Windows.Forms.Label();
            this.Label_Revision = new System.Windows.Forms.Label();
            this.ToolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.ToolStripContainer1.ContentPanel.SuspendLayout();
            this.ToolStripContainer1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Marjor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Minor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Build)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Revision)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStripContainer1
            // 
            // 
            // ToolStripContainer1.BottomToolStripPanel
            // 
            this.ToolStripContainer1.BottomToolStripPanel.Controls.Add(this.ToolStrip1);
            // 
            // ToolStripContainer1.ContentPanel
            // 
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.TableLayoutPanel1);
            this.ToolStripContainer1.ContentPanel.Size = new System.Drawing.Size(300, 51);
            this.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer1.LeftToolStripPanelVisible = false;
            this.ToolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer1.Name = "ToolStripContainer1";
            this.ToolStripContainer1.RightToolStripPanelVisible = false;
            this.ToolStripContainer1.Size = new System.Drawing.Size(300, 76);
            this.ToolStripContainer1.TabIndex = 2;
            this.ToolStripContainer1.Text = "ToolStripContainer1";
            this.ToolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButton_Apply,
            this.ToolStripButton_Clear,
            this.ToolStripButton_Cancel});
            this.ToolStrip1.Location = new System.Drawing.Point(3, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(197, 25);
            this.ToolStrip1.TabIndex = 0;
            // 
            // ToolStripButton_Apply
            // 
            this.ToolStripButton_Apply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButton_Apply.Enabled = false;
            this.ToolStripButton_Apply.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Apply.Image")));
            this.ToolStripButton_Apply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Apply.Name = "ToolStripButton_Apply";
            this.ToolStripButton_Apply.Size = new System.Drawing.Size(51, 22);
            this.ToolStripButton_Apply.Text = "Apply_f";
            this.ToolStripButton_Apply.Click += new System.EventHandler(this.ToolStripButton_Apply_Click);
            // 
            // ToolStripButton_Clear
            // 
            this.ToolStripButton_Clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButton_Clear.Enabled = false;
            this.ToolStripButton_Clear.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Clear.Image")));
            this.ToolStripButton_Clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Clear.Name = "ToolStripButton_Clear";
            this.ToolStripButton_Clear.Size = new System.Drawing.Size(47, 22);
            this.ToolStripButton_Clear.Text = "Clear_f";
            this.ToolStripButton_Clear.Click += new System.EventHandler(this.ToolStripButton_Clear_Click);
            // 
            // ToolStripButton_Cancel
            // 
            this.ToolStripButton_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButton_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Cancel.Image")));
            this.ToolStripButton_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Cancel.Name = "ToolStripButton_Cancel";
            this.ToolStripButton_Cancel.Size = new System.Drawing.Size(56, 22);
            this.ToolStripButton_Cancel.Text = "Cancel_f";
            this.ToolStripButton_Cancel.Click += new System.EventHandler(this.ToolStripButton_Cancel_Click);
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 4;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanel1.Controls.Add(this.NumericUpDown_Marjor, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.NumericUpDown_Minor, 1, 1);
            this.TableLayoutPanel1.Controls.Add(this.NumericUpDown_Build, 2, 1);
            this.TableLayoutPanel1.Controls.Add(this.NumericUpDown_Revision, 3, 1);
            this.TableLayoutPanel1.Controls.Add(this.Label_Major, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label_Minor, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label_Build, 2, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label_Revision, 3, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 2;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.69231F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.30769F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(300, 51);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // NumericUpDown_Marjor
            // 
            this.NumericUpDown_Marjor.Location = new System.Drawing.Point(3, 19);
            this.NumericUpDown_Marjor.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumericUpDown_Marjor.Name = "NumericUpDown_Marjor";
            this.NumericUpDown_Marjor.Size = new System.Drawing.Size(57, 20);
            this.NumericUpDown_Marjor.TabIndex = 0;
            this.NumericUpDown_Marjor.ValueChanged += new System.EventHandler(this.NumericUpDown_Marjor_ValueChanged);
            // 
            // NumericUpDown_Minor
            // 
            this.NumericUpDown_Minor.Location = new System.Drawing.Point(78, 19);
            this.NumericUpDown_Minor.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumericUpDown_Minor.Name = "NumericUpDown_Minor";
            this.NumericUpDown_Minor.Size = new System.Drawing.Size(57, 20);
            this.NumericUpDown_Minor.TabIndex = 1;
            this.NumericUpDown_Minor.ValueChanged += new System.EventHandler(this.NumericUpDown_Minor_ValueChanged);
            // 
            // NumericUpDown_Build
            // 
            this.NumericUpDown_Build.Location = new System.Drawing.Point(153, 19);
            this.NumericUpDown_Build.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumericUpDown_Build.Name = "NumericUpDown_Build";
            this.NumericUpDown_Build.Size = new System.Drawing.Size(57, 20);
            this.NumericUpDown_Build.TabIndex = 2;
            this.NumericUpDown_Build.ValueChanged += new System.EventHandler(this.NumericUpDown_Build_ValueChanged);
            // 
            // NumericUpDown_Revision
            // 
            this.NumericUpDown_Revision.Location = new System.Drawing.Point(228, 19);
            this.NumericUpDown_Revision.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumericUpDown_Revision.Name = "NumericUpDown_Revision";
            this.NumericUpDown_Revision.Size = new System.Drawing.Size(59, 20);
            this.NumericUpDown_Revision.TabIndex = 3;
            this.NumericUpDown_Revision.ValueChanged += new System.EventHandler(this.NumericUpDown_Revision_ValueChanged);
            // 
            // Label_Major
            // 
            this.Label_Major.AutoSize = true;
            this.Label_Major.Location = new System.Drawing.Point(3, 0);
            this.Label_Major.Name = "Label_Major";
            this.Label_Major.Size = new System.Drawing.Size(45, 13);
            this.Label_Major.TabIndex = 4;
            this.Label_Major.Text = "Marjor_f";
            // 
            // Label_Minor
            // 
            this.Label_Minor.AutoSize = true;
            this.Label_Minor.Location = new System.Drawing.Point(78, 0);
            this.Label_Minor.Name = "Label_Minor";
            this.Label_Minor.Size = new System.Drawing.Size(42, 13);
            this.Label_Minor.TabIndex = 5;
            this.Label_Minor.Text = "Minor_f";
            // 
            // Label_Build
            // 
            this.Label_Build.AutoSize = true;
            this.Label_Build.Location = new System.Drawing.Point(153, 0);
            this.Label_Build.Name = "Label_Build";
            this.Label_Build.Size = new System.Drawing.Size(39, 13);
            this.Label_Build.TabIndex = 6;
            this.Label_Build.Text = "Build_f";
            // 
            // Label_Revision
            // 
            this.Label_Revision.AutoSize = true;
            this.Label_Revision.Location = new System.Drawing.Point(228, 0);
            this.Label_Revision.Name = "Label_Revision";
            this.Label_Revision.Size = new System.Drawing.Size(57, 13);
            this.Label_Revision.TabIndex = 7;
            this.Label_Revision.Text = "Revision_f";
            // 
            // UserControl_VersionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ToolStripContainer1);
            this.Name = "UserControl_VersionEdit";
            this.Size = new System.Drawing.Size(300, 76);
            this.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.ToolStripContainer1.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer1.ResumeLayout(false);
            this.ToolStripContainer1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Marjor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Minor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Build)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Revision)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolStripContainer ToolStripContainer1;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_Apply;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_Clear;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_Cancel;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.NumericUpDown NumericUpDown_Marjor;
        internal System.Windows.Forms.NumericUpDown NumericUpDown_Minor;
        internal System.Windows.Forms.NumericUpDown NumericUpDown_Build;
        internal System.Windows.Forms.NumericUpDown NumericUpDown_Revision;
        internal System.Windows.Forms.Label Label_Major;
        internal System.Windows.Forms.Label Label_Minor;
        internal System.Windows.Forms.Label Label_Build;
        internal System.Windows.Forms.Label Label_Revision;
    }
}
