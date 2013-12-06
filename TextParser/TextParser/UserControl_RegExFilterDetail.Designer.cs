namespace TextParser
{
    partial class UserControl_RegExFilterDetail
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
            this.label_Name = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton_Main = new System.Windows.Forms.RadioButton();
            this.radioButton_Pre = new System.Windows.Forms.RadioButton();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(3, 9);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(49, 13);
            this.label_Name.TabIndex = 8;
            this.label_Name.Text = "x_Name:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(96, 59);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(64, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "x_Equal";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton_Main);
            this.groupBox1.Controls.Add(this.radioButton_Pre);
            this.groupBox1.Location = new System.Drawing.Point(2, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(87, 103);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "x_Position";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(10, 66);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(57, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "x_Post";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton_Main
            // 
            this.radioButton_Main.AutoSize = true;
            this.radioButton_Main.Location = new System.Drawing.Point(10, 43);
            this.radioButton_Main.Name = "radioButton_Main";
            this.radioButton_Main.Size = new System.Drawing.Size(59, 17);
            this.radioButton_Main.TabIndex = 1;
            this.radioButton_Main.TabStop = true;
            this.radioButton_Main.Text = "x_Main";
            this.radioButton_Main.UseVisualStyleBackColor = true;
            // 
            // radioButton_Pre
            // 
            this.radioButton_Pre.AutoSize = true;
            this.radioButton_Pre.Location = new System.Drawing.Point(10, 20);
            this.radioButton_Pre.Name = "radioButton_Pre";
            this.radioButton_Pre.Size = new System.Drawing.Size(52, 17);
            this.radioButton_Pre.TabIndex = 0;
            this.radioButton_Pre.TabStop = true;
            this.radioButton_Pre.Text = "x_Pre";
            this.radioButton_Pre.UseVisualStyleBackColor = true;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Name.Location = new System.Drawing.Point(59, 7);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(332, 20);
            this.textBox_Name.TabIndex = 9;
            // 
            // UserControl_RegExFilterDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControl_RegExFilterDetail";
            this.Size = new System.Drawing.Size(394, 376);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton_Main;
        private System.Windows.Forms.RadioButton radioButton_Pre;
        private System.Windows.Forms.TextBox textBox_Name;
    }
}
