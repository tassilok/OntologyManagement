namespace CommandLineRun_Module
{
    partial class UserControl_CodeEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_CodeEditor));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_LineCountLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_LineCount = new System.Windows.Forms.ToolStripLabel();
            this.scintilla_Code = new ScintillaNET.Scintilla();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Lock = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_ReplaceVariables = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scintilla_Code)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.scintilla_Code);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(522, 383);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(522, 433);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Save,
            this.toolStripSeparator1,
            this.toolStripLabel_LineCountLbl,
            this.toolStripLabel_LineCount});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(129, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton_Save
            // 
            this.toolStripButton_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Save.Enabled = false;
            this.toolStripButton_Save.Image = global::CommandLineRun_Module.Properties.Resources.saveHS;
            this.toolStripButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Save.Name = "toolStripButton_Save";
            this.toolStripButton_Save.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Save.Text = "toolStripButton1";
            this.toolStripButton_Save.Click += new System.EventHandler(this.toolStripButton_Save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_LineCountLbl
            // 
            this.toolStripLabel_LineCountLbl.Name = "toolStripLabel_LineCountLbl";
            this.toolStripLabel_LineCountLbl.Size = new System.Drawing.Size(75, 22);
            this.toolStripLabel_LineCountLbl.Text = "x_LineCount:";
            // 
            // toolStripLabel_LineCount
            // 
            this.toolStripLabel_LineCount.Name = "toolStripLabel_LineCount";
            this.toolStripLabel_LineCount.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel_LineCount.Text = "0";
            // 
            // scintilla_Code
            // 
            this.scintilla_Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintilla_Code.Location = new System.Drawing.Point(0, 0);
            this.scintilla_Code.Margins.Margin0.Width = 16;
            this.scintilla_Code.Name = "scintilla_Code";
            this.scintilla_Code.Size = new System.Drawing.Size(522, 383);
            this.scintilla_Code.Styles.BraceBad.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Code.Styles.BraceLight.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Code.Styles.CallTip.FontName = "Segoe UI\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Code.Styles.ControlChar.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Code.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.scintilla_Code.Styles.Default.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Code.Styles.IndentGuide.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Code.Styles.LastPredefined.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Code.Styles.LineNumber.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Code.Styles.Max.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Code.TabIndex = 0;
            this.scintilla_Code.TextChanged += new System.EventHandler(this.scintilla_Code_TextChanged);
            this.scintilla_Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.scintilla_Code_KeyDown);
            this.scintilla_Code.Leave += new System.EventHandler(this.scintilla_Code_Leave);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Lock,
            this.toolStripSeparator2,
            this.toolStripButton_ReplaceVariables});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(153, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripButton_Lock
            // 
            this.toolStripButton_Lock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Lock.Image = global::CommandLineRun_Module.Properties.Resources.padlock_aj_ashton_01;
            this.toolStripButton_Lock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Lock.Name = "toolStripButton_Lock";
            this.toolStripButton_Lock.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Lock.Text = "toolStripButton1";
            this.toolStripButton_Lock.Click += new System.EventHandler(this.toolStripButton_Lock_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_ReplaceVariables
            // 
            this.toolStripButton_ReplaceVariables.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_ReplaceVariables.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ReplaceVariables.Image")));
            this.toolStripButton_ReplaceVariables.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ReplaceVariables.Name = "toolStripButton_ReplaceVariables";
            this.toolStripButton_ReplaceVariables.Size = new System.Drawing.Size(112, 22);
            this.toolStripButton_ReplaceVariables.Text = "x_Replace Variables";
            this.toolStripButton_ReplaceVariables.Click += new System.EventHandler(this.toolStripButton_ReplaceVariables_Click);
            // 
            // UserControl_CodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_CodeEditor";
            this.Size = new System.Drawing.Size(522, 433);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scintilla_Code)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_LineCountLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_LineCount;
        private ScintillaNET.Scintilla scintilla_Code;
        private System.Windows.Forms.ToolStripButton toolStripButton_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_ReplaceVariables;
        private System.Windows.Forms.ToolStripButton toolStripButton_Lock;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
