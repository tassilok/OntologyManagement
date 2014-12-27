namespace NextGenerationOntoEdit
{
    partial class DataItemWidthChanger
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
            this.trackBar_Width = new System.Windows.Forms.TrackBar();
            this.numericUpDown_Width = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Width)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar_Width
            // 
            this.trackBar_Width.Location = new System.Drawing.Point(13, 13);
            this.trackBar_Width.Maximum = 250;
            this.trackBar_Width.Name = "trackBar_Width";
            this.trackBar_Width.Size = new System.Drawing.Size(274, 45);
            this.trackBar_Width.TabIndex = 0;
            this.trackBar_Width.Value = 50;
            this.trackBar_Width.ValueChanged += new System.EventHandler(this.trackBar_Width_ValueChanged);
            // 
            // numericUpDown_Width
            // 
            this.numericUpDown_Width.Location = new System.Drawing.Point(293, 12);
            this.numericUpDown_Width.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDown_Width.Name = "numericUpDown_Width";
            this.numericUpDown_Width.Size = new System.Drawing.Size(64, 20);
            this.numericUpDown_Width.TabIndex = 1;
            this.numericUpDown_Width.ValueChanged += new System.EventHandler(this.numericUpDown_Width_ValueChanged);
            // 
            // DataItemWidthChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 55);
            this.ControlBox = false;
            this.Controls.Add(this.numericUpDown_Width);
            this.Controls.Add(this.trackBar_Width);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "DataItemWidthChanger";
            this.Text = "DataItemWidthChanger";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Width)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar_Width;
        private System.Windows.Forms.NumericUpDown numericUpDown_Width;
    }
}