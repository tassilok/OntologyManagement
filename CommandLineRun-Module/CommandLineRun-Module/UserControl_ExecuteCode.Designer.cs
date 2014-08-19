namespace CommandLineRun_Module
{
    partial class UserControl_ExecuteCode
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_CMDRL = new System.Windows.Forms.Label();
            this.textBox_CMDRL = new System.Windows.Forms.TextBox();
            this.label_CodeParsed = new System.Windows.Forms.Label();
            this.label_Code = new System.Windows.Forms.Label();
            this.scintilla_CodeParsed = new ScintillaNET.Scintilla();
            this.scintilla_Code = new ScintillaNET.Scintilla();
            this.label_ProgrammingLanguage = new System.Windows.Forms.Label();
            this.textBox_ProgrammingLanguage = new System.Windows.Forms.TextBox();
            this.button_Exec = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scintilla_CodeParsed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scintilla_Code)).BeginInit();
            this.SuspendLayout();
            // 
            // label_CMDRL
            // 
            this.label_CMDRL.AutoSize = true;
            this.label_CMDRL.Location = new System.Drawing.Point(10, 4);
            this.label_CMDRL.Name = "label_CMDRL";
            this.label_CMDRL.Size = new System.Drawing.Size(114, 13);
            this.label_CMDRL.TabIndex = 0;
            this.label_CMDRL.Text = "x_Command Line Run:";
            // 
            // textBox_CMDRL
            // 
            this.textBox_CMDRL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_CMDRL.Location = new System.Drawing.Point(145, 4);
            this.textBox_CMDRL.Name = "textBox_CMDRL";
            this.textBox_CMDRL.Size = new System.Drawing.Size(799, 20);
            this.textBox_CMDRL.TabIndex = 1;
            // 
            // label_CodeParsed
            // 
            this.label_CodeParsed.AutoSize = true;
            this.label_CodeParsed.Location = new System.Drawing.Point(10, 60);
            this.label_CodeParsed.Name = "label_CodeParsed";
            this.label_CodeParsed.Size = new System.Drawing.Size(88, 13);
            this.label_CodeParsed.TabIndex = 2;
            this.label_CodeParsed.Text = "x_Code (Parsed):";
            // 
            // label_Code
            // 
            this.label_Code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Code.AutoSize = true;
            this.label_Code.Location = new System.Drawing.Point(10, 509);
            this.label_Code.Name = "label_Code";
            this.label_Code.Size = new System.Drawing.Size(97, 13);
            this.label_Code.TabIndex = 4;
            this.label_Code.Text = "x_Code (with vars):";
            // 
            // scintilla_CodeParsed
            // 
            this.scintilla_CodeParsed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scintilla_CodeParsed.Location = new System.Drawing.Point(145, 60);
            this.scintilla_CodeParsed.Margins.Margin0.Width = 20;
            this.scintilla_CodeParsed.Name = "scintilla_CodeParsed";
            this.scintilla_CodeParsed.Size = new System.Drawing.Size(740, 443);
            this.scintilla_CodeParsed.Styles.BraceBad.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_CodeParsed.Styles.BraceLight.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_CodeParsed.Styles.CallTip.FontName = "Segoe UI\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_CodeParsed.Styles.ControlChar.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_CodeParsed.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.scintilla_CodeParsed.Styles.Default.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_CodeParsed.Styles.IndentGuide.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_CodeParsed.Styles.LastPredefined.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_CodeParsed.Styles.LineNumber.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_CodeParsed.Styles.Max.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_CodeParsed.TabIndex = 6;
            // 
            // scintilla_Code
            // 
            this.scintilla_Code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scintilla_Code.Location = new System.Drawing.Point(145, 510);
            this.scintilla_Code.Margins.Margin0.Width = 20;
            this.scintilla_Code.Name = "scintilla_Code";
            this.scintilla_Code.Size = new System.Drawing.Size(740, 100);
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
            this.scintilla_Code.TabIndex = 7;
            // 
            // label_ProgrammingLanguage
            // 
            this.label_ProgrammingLanguage.AutoSize = true;
            this.label_ProgrammingLanguage.Location = new System.Drawing.Point(10, 31);
            this.label_ProgrammingLanguage.Name = "label_ProgrammingLanguage";
            this.label_ProgrammingLanguage.Size = new System.Drawing.Size(133, 13);
            this.label_ProgrammingLanguage.TabIndex = 8;
            this.label_ProgrammingLanguage.Text = "x_Programming-Language:";
            // 
            // textBox_ProgrammingLanguage
            // 
            this.textBox_ProgrammingLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ProgrammingLanguage.Location = new System.Drawing.Point(145, 31);
            this.textBox_ProgrammingLanguage.Name = "textBox_ProgrammingLanguage";
            this.textBox_ProgrammingLanguage.ReadOnly = true;
            this.textBox_ProgrammingLanguage.Size = new System.Drawing.Size(799, 20);
            this.textBox_ProgrammingLanguage.TabIndex = 9;
            // 
            // button_Exec
            // 
            this.button_Exec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Exec.Location = new System.Drawing.Point(891, 57);
            this.button_Exec.Name = "button_Exec";
            this.button_Exec.Size = new System.Drawing.Size(44, 23);
            this.button_Exec.TabIndex = 10;
            this.button_Exec.Text = "Exec";
            this.button_Exec.UseVisualStyleBackColor = true;
            this.button_Exec.Click += new System.EventHandler(this.button_Exec_Click);
            // 
            // UserControl_ExecuteCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_Exec);
            this.Controls.Add(this.textBox_ProgrammingLanguage);
            this.Controls.Add(this.label_ProgrammingLanguage);
            this.Controls.Add(this.scintilla_Code);
            this.Controls.Add(this.scintilla_CodeParsed);
            this.Controls.Add(this.label_Code);
            this.Controls.Add(this.label_CodeParsed);
            this.Controls.Add(this.textBox_CMDRL);
            this.Controls.Add(this.label_CMDRL);
            this.Name = "UserControl_ExecuteCode";
            this.Size = new System.Drawing.Size(947, 621);
            ((System.ComponentModel.ISupportInitialize)(this.scintilla_CodeParsed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scintilla_Code)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_CMDRL;
        private System.Windows.Forms.TextBox textBox_CMDRL;
        private System.Windows.Forms.Label label_CodeParsed;
        private System.Windows.Forms.Label label_Code;
        private ScintillaNET.Scintilla scintilla_CodeParsed;
        private ScintillaNET.Scintilla scintilla_Code;
        private System.Windows.Forms.Label label_ProgrammingLanguage;
        private System.Windows.Forms.TextBox textBox_ProgrammingLanguage;
        private System.Windows.Forms.Button button_Exec;
    }
}
