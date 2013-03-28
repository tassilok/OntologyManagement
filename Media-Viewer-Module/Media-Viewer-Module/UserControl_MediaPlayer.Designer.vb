<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_MediaPlayer
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_MediaPlayer))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.AxWindowsMediaPlayer_MediaItem = New AxWMPLib.AxWindowsMediaPlayer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Open = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_Bookmarks = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel_NameLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Name = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel_CreatedLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Created = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripProgressBar_MediaItem = New System.Windows.Forms.ToolStripProgressBar()
        Me.Timer_MediaItem = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Position = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Play = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        CType(Me.AxWindowsMediaPlayer_MediaItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        Me.ToolStripContainer1.BottomToolStripPanelVisible = False
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.AxWindowsMediaPlayer_MediaItem)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(495, 456)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(495, 481)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'AxWindowsMediaPlayer_MediaItem
        '
        Me.AxWindowsMediaPlayer_MediaItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxWindowsMediaPlayer_MediaItem.Enabled = True
        Me.AxWindowsMediaPlayer_MediaItem.Location = New System.Drawing.Point(0, 0)
        Me.AxWindowsMediaPlayer_MediaItem.Name = "AxWindowsMediaPlayer_MediaItem"
        Me.AxWindowsMediaPlayer_MediaItem.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer_MediaItem.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer_MediaItem.Size = New System.Drawing.Size(495, 456)
        Me.AxWindowsMediaPlayer_MediaItem.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Open, Me.ToolStripSeparator1, Me.ToolStripButton_Bookmarks, Me.ToolStripSeparator2, Me.ToolStripLabel_NameLBL, Me.ToolStripLabel_Name, Me.ToolStripSeparator3, Me.ToolStripLabel_CreatedLBL, Me.ToolStripLabel_Created, Me.ToolStripProgressBar_MediaItem})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(427, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripButton_Open
        '
        Me.ToolStripButton_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Open.Image = CType(resources.GetObject("ToolStripButton_Open.Image"), System.Drawing.Image)
        Me.ToolStripButton_Open.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Open.Name = "ToolStripButton_Open"
        Me.ToolStripButton_Open.Size = New System.Drawing.Size(49, 22)
        Me.ToolStripButton_Open.Text = "x_Open"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_Bookmarks
        '
        Me.ToolStripButton_Bookmarks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Bookmarks.Image = CType(resources.GetObject("ToolStripButton_Bookmarks.Image"), System.Drawing.Image)
        Me.ToolStripButton_Bookmarks.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Bookmarks.Name = "ToolStripButton_Bookmarks"
        Me.ToolStripButton_Bookmarks.Size = New System.Drawing.Size(114, 22)
        Me.ToolStripButton_Bookmarks.Text = "x_Bookmarks/Ranges"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel_NameLBL
        '
        Me.ToolStripLabel_NameLBL.Name = "ToolStripLabel_NameLBL"
        Me.ToolStripLabel_NameLBL.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripLabel_NameLBL.Text = "x_Name:"
        '
        'ToolStripLabel_Name
        '
        Me.ToolStripLabel_Name.Name = "ToolStripLabel_Name"
        Me.ToolStripLabel_Name.Size = New System.Drawing.Size(11, 22)
        Me.ToolStripLabel_Name.Text = "-"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel_CreatedLBL
        '
        Me.ToolStripLabel_CreatedLBL.Name = "ToolStripLabel_CreatedLBL"
        Me.ToolStripLabel_CreatedLBL.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripLabel_CreatedLBL.Text = "x_Created:"
        '
        'ToolStripLabel_Created
        '
        Me.ToolStripLabel_Created.Name = "ToolStripLabel_Created"
        Me.ToolStripLabel_Created.Size = New System.Drawing.Size(11, 22)
        Me.ToolStripLabel_Created.Text = "-"
        '
        'ToolStripProgressBar_MediaItem
        '
        Me.ToolStripProgressBar_MediaItem.Name = "ToolStripProgressBar_MediaItem"
        Me.ToolStripProgressBar_MediaItem.Size = New System.Drawing.Size(100, 22)
        '
        'Timer_MediaItem
        '
        Me.Timer_MediaItem.Interval = 300
        '
        'Timer_Play
        '
        Me.Timer_Play.Interval = 200
        '
        'UserControl_MediaPlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_MediaPlayer"
        Me.Size = New System.Drawing.Size(495, 481)
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        CType(Me.AxWindowsMediaPlayer_MediaItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents AxWindowsMediaPlayer_MediaItem As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Open As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_Bookmarks As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripProgressBar_MediaItem As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Timer_MediaItem As System.Windows.Forms.Timer
    Friend WithEvents ToolStripLabel_NameLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Name As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel_CreatedLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Created As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Timer_Position As System.Windows.Forms.Timer
    Friend WithEvents Timer_Play As System.Windows.Forms.Timer

End Class
