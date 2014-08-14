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
            this.textBox_CodeParsed = new System.Windows.Forms.TextBox();
            this.label_Code = new System.Windows.Forms.Label();
            this.textBox_Code = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_CMDRL
            // 
            this.label_CMDRL.AutoSize = true;
            this.label_CMDRL.Location = new System.Drawing.Point(4, 4);
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
            this.textBox_CMDRL.Location = new System.Drawing.Point(125, 4);
            this.textBox_CMDRL.Name = "textBox_CMDRL";
            this.textBox_CMDRL.Size = new System.Drawing.Size(819, 20);
            this.textBox_CMDRL.TabIndex = 1;
            // 
            // label_CodeParsed
            // 
            this.label_CodeParsed.AutoSize = true;
            this.label_CodeParsed.Location = new System.Drawing.Point(7, 35);
            this.label_CodeParsed.Name = "label_CodeParsed";
            this.label_CodeParsed.Size = new System.Drawing.Size(88, 13);
            this.label_CodeParsed.TabIndex = 2;
            this.label_CodeParsed.Text = "x_Code (Parsed):";
            // 
            // textBox_CodeParsed
            // 
            this.textBox_CodeParsed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_CodeParsed.Location = new System.Drawing.Point(125, 35);
            this.textBox_CodeParsed.Multiline = true;
            this.textBox_CodeParsed.Name = "textBox_CodeParsed";
            this.textBox_CodeParsed.ReadOnly = true;
            this.textBox_CodeParsed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_CodeParsed.Size = new System.Drawing.Size(819, 469);
            this.textBox_CodeParsed.TabIndex = 3;
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
            // textBox_Code
            // 
            this.textBox_Code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Code.Location = new System.Drawing.Point(125, 509);
            this.textBox_Code.Multiline = true;
            this.textBox_Code.Name = "textBox_Code";
            this.textBox_Code.ReadOnly = true;
            this.textBox_Code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Code.Size = new System.Drawing.Size(819, 109);
            this.textBox_Code.TabIndex = 5;
            // 
            // UserControl_ExecuteCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_Code);
            this.Controls.Add(this.label_Code);
            this.Controls.Add(this.textBox_CodeParsed);
            this.Controls.Add(this.label_CodeParsed);
            this.Controls.Add(this.textBox_CMDRL);
            this.Controls.Add(this.label_CMDRL);
            this.Name = "UserControl_ExecuteCode";
            this.Size = new System.Drawing.Size(947, 621);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_CMDRL;
        private System.Windows.Forms.TextBox textBox_CMDRL;
        private System.Windows.Forms.Label label_CodeParsed;
        private System.Windows.Forms.TextBox textBox_CodeParsed;
        private System.Windows.Forms.Label label_Code;
        private System.Windows.Forms.TextBox textBox_Code;
    }
}
