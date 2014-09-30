namespace AudioPlayer_Module
{
    partial class UserControl_AudioPlayer
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_First = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Previous = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Next = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Last = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_AutoPlay = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_ItemOfCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_Position = new System.Windows.Forms.ToolStripLabel();
            this.volumeSlider = new NAudio.Gui.VolumeSlider();
            this.volumeMeter_Right = new NAudio.Gui.VolumeMeter();
            this.waveformPainter_Right = new NAudio.Gui.WaveformPainter();
            this.waveformPainter_Left = new NAudio.Gui.WaveformPainter();
            this.volumeMeter_Left = new NAudio.Gui.VolumeMeter();
            this.trackBar_Position = new System.Windows.Forms.TrackBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Play = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Pause = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Stop = new System.Windows.Forms.ToolStripButton();
            this.timer_Position = new System.Windows.Forms.Timer(this.components);
            this.toolStripLabel_MediaItem = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Position)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.volumeSlider);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.volumeMeter_Right);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.waveformPainter_Right);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.waveformPainter_Left);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.volumeMeter_Left);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.trackBar_Position);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(734, 154);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(734, 204);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_First,
            this.toolStripButton_Previous,
            this.toolStripButton_Next,
            this.toolStripButton_Last,
            this.toolStripSeparator2,
            this.toolStripButton_AutoPlay,
            this.toolStripLabel_ItemOfCount,
            this.toolStripSeparator1,
            this.toolStripLabel_Position});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(212, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripButton_First
            // 
            this.toolStripButton_First.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_First.Image = global::AudioPlayer_Module.Properties.Resources.pulsante_01_architetto_f_01_First1;
            this.toolStripButton_First.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_First.Name = "toolStripButton_First";
            this.toolStripButton_First.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_First.Text = "toolStripButton1";
            this.toolStripButton_First.Click += new System.EventHandler(this.toolStripButton_First_Click);
            // 
            // toolStripButton_Previous
            // 
            this.toolStripButton_Previous.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Previous.Image = global::AudioPlayer_Module.Properties.Resources.pulsante_01_architetto_f_01;
            this.toolStripButton_Previous.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Previous.Name = "toolStripButton_Previous";
            this.toolStripButton_Previous.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Previous.Text = "toolStripButton2";
            this.toolStripButton_Previous.Click += new System.EventHandler(this.toolStripButton_Previous_Click);
            // 
            // toolStripButton_Next
            // 
            this.toolStripButton_Next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Next.Image = global::AudioPlayer_Module.Properties.Resources.pulsante_02_architetto_f_01;
            this.toolStripButton_Next.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Next.Name = "toolStripButton_Next";
            this.toolStripButton_Next.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Next.Text = "toolStripButton3";
            this.toolStripButton_Next.Click += new System.EventHandler(this.toolStripButton_Next_Click);
            // 
            // toolStripButton_Last
            // 
            this.toolStripButton_Last.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Last.Image = global::AudioPlayer_Module.Properties.Resources.pulsante_02_architetto_f_01_Last;
            this.toolStripButton_Last.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Last.Name = "toolStripButton_Last";
            this.toolStripButton_Last.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Last.Text = "toolStripButton4";
            this.toolStripButton_Last.Click += new System.EventHandler(this.toolStripButton_Last_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_AutoPlay
            // 
            this.toolStripButton_AutoPlay.CheckOnClick = true;
            this.toolStripButton_AutoPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_AutoPlay.Image = global::AudioPlayer_Module.Properties.Resources.bb_reload_;
            this.toolStripButton_AutoPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AutoPlay.Name = "toolStripButton_AutoPlay";
            this.toolStripButton_AutoPlay.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_AutoPlay.Text = "toolStripButton1";
            // 
            // toolStripLabel_ItemOfCount
            // 
            this.toolStripLabel_ItemOfCount.Name = "toolStripLabel_ItemOfCount";
            this.toolStripLabel_ItemOfCount.Size = new System.Drawing.Size(24, 22);
            this.toolStripLabel_ItemOfCount.Text = "0/0";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_Position
            // 
            this.toolStripLabel_Position.Name = "toolStripLabel_Position";
            this.toolStripLabel_Position.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabel_Position.Text = "00:00:00";
            // 
            // volumeSlider
            // 
            this.volumeSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeSlider.Location = new System.Drawing.Point(644, 126);
            this.volumeSlider.Name = "volumeSlider";
            this.volumeSlider.Size = new System.Drawing.Size(87, 16);
            this.volumeSlider.TabIndex = 23;
            this.volumeSlider.VolumeChanged += new System.EventHandler(this.volumeSlider_VolumeChanged);
            // 
            // volumeMeter_Right
            // 
            this.volumeMeter_Right.Amplitude = 0F;
            this.volumeMeter_Right.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeMeter_Right.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.volumeMeter_Right.Location = new System.Drawing.Point(691, 6);
            this.volumeMeter_Right.MaxDb = 3F;
            this.volumeMeter_Right.MinDb = -60F;
            this.volumeMeter_Right.Name = "volumeMeter_Right";
            this.volumeMeter_Right.Size = new System.Drawing.Size(39, 114);
            this.volumeMeter_Right.TabIndex = 22;
            this.volumeMeter_Right.Text = "volumeMeter1";
            // 
            // waveformPainter_Right
            // 
            this.waveformPainter_Right.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.waveformPainter_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.waveformPainter_Right.ForeColor = System.Drawing.Color.SaddleBrown;
            this.waveformPainter_Right.Location = new System.Drawing.Point(12, 51);
            this.waveformPainter_Right.Name = "waveformPainter_Right";
            this.waveformPainter_Right.Size = new System.Drawing.Size(629, 39);
            this.waveformPainter_Right.TabIndex = 21;
            this.waveformPainter_Right.Text = "waveformPainter1";
            // 
            // waveformPainter_Left
            // 
            this.waveformPainter_Left.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.waveformPainter_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.waveformPainter_Left.ForeColor = System.Drawing.Color.SaddleBrown;
            this.waveformPainter_Left.Location = new System.Drawing.Point(12, 6);
            this.waveformPainter_Left.Name = "waveformPainter_Left";
            this.waveformPainter_Left.Size = new System.Drawing.Size(629, 39);
            this.waveformPainter_Left.TabIndex = 20;
            this.waveformPainter_Left.Text = "waveformPainter1";
            // 
            // volumeMeter_Left
            // 
            this.volumeMeter_Left.Amplitude = 0F;
            this.volumeMeter_Left.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeMeter_Left.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.volumeMeter_Left.Location = new System.Drawing.Point(644, 6);
            this.volumeMeter_Left.MaxDb = 3F;
            this.volumeMeter_Left.MinDb = -60F;
            this.volumeMeter_Left.Name = "volumeMeter_Left";
            this.volumeMeter_Left.Size = new System.Drawing.Size(39, 114);
            this.volumeMeter_Left.TabIndex = 19;
            this.volumeMeter_Left.Text = "volumeMeter1";
            // 
            // trackBar_Position
            // 
            this.trackBar_Position.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_Position.LargeChange = 10;
            this.trackBar_Position.Location = new System.Drawing.Point(3, 96);
            this.trackBar_Position.Maximum = 100;
            this.trackBar_Position.Name = "trackBar_Position";
            this.trackBar_Position.Size = new System.Drawing.Size(638, 45);
            this.trackBar_Position.TabIndex = 2;
            this.trackBar_Position.TickFrequency = 5;
            this.trackBar_Position.Scroll += new System.EventHandler(this.trackBar_Position_Scroll);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_MediaItem,
            this.toolStripSeparator3,
            this.toolStripButton_Play,
            this.toolStripButton_Pause,
            this.toolStripButton_Stop});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(130, 25);
            this.toolStrip1.TabIndex = 1;
            // 
            // toolStripButton_Play
            // 
            this.toolStripButton_Play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Play.Image = global::AudioPlayer_Module.Properties.Resources.wm_play;
            this.toolStripButton_Play.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Play.Name = "toolStripButton_Play";
            this.toolStripButton_Play.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Play.Text = "toolStripButton3";
            this.toolStripButton_Play.Click += new System.EventHandler(this.toolStripButton_Play_Click);
            // 
            // toolStripButton_Pause
            // 
            this.toolStripButton_Pause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Pause.Image = global::AudioPlayer_Module.Properties.Resources.wm_pause;
            this.toolStripButton_Pause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Pause.Name = "toolStripButton_Pause";
            this.toolStripButton_Pause.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Pause.Text = "toolStripButton2";
            this.toolStripButton_Pause.Click += new System.EventHandler(this.toolStripButton_Pause_Click);
            // 
            // toolStripButton_Stop
            // 
            this.toolStripButton_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Stop.Image = global::AudioPlayer_Module.Properties.Resources.icon_multimedia_blue_stop;
            this.toolStripButton_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Stop.Name = "toolStripButton_Stop";
            this.toolStripButton_Stop.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Stop.Text = "toolStripButton1";
            this.toolStripButton_Stop.Click += new System.EventHandler(this.toolStripButton_Stop_Click);
            // 
            // timer_Position
            // 
            this.timer_Position.Tick += new System.EventHandler(this.timer_Position_Tick);
            // 
            // toolStripLabel_MediaItem
            // 
            this.toolStripLabel_MediaItem.Name = "toolStripLabel_MediaItem";
            this.toolStripLabel_MediaItem.Size = new System.Drawing.Size(12, 22);
            this.toolStripLabel_MediaItem.Text = "-";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // UserControl_AudioPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_AudioPlayer";
            this.Size = new System.Drawing.Size(734, 204);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Position)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TrackBar trackBar_Position;
        private System.Windows.Forms.Timer timer_Position;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Play;
        private System.Windows.Forms.ToolStripButton toolStripButton_Pause;
        private System.Windows.Forms.ToolStripButton toolStripButton_Stop;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_First;
        private System.Windows.Forms.ToolStripButton toolStripButton_Previous;
        private System.Windows.Forms.ToolStripButton toolStripButton_Next;
        private System.Windows.Forms.ToolStripButton toolStripButton_Last;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_ItemOfCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Position;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_AutoPlay;
        private NAudio.Gui.WaveformPainter waveformPainter_Left;
        private NAudio.Gui.VolumeMeter volumeMeter_Left;
        private NAudio.Gui.VolumeSlider volumeSlider;
        private NAudio.Gui.VolumeMeter volumeMeter_Right;
        private NAudio.Gui.WaveformPainter waveformPainter_Right;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_MediaItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
