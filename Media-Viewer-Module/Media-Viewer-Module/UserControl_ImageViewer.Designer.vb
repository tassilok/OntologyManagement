<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_ImageViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_ImageViewer))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_SizeLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_SizeX = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_SizeSeperator = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_SizeY = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel_NameLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Name = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel_CreationDateLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_CreationDate = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripProgressBar_Image = New System.Windows.Forms.ToolStripProgressBar()
        Me.PictureBox_Image = New System.Windows.Forms.PictureBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Copy = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Paste = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_Replace = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSplitButton_Scale = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripMenuItem_Stretch = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Original = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Zoom = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton_Edit = New System.Windows.Forms.ToolStripButton()
        Me.Timer_Image = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox_Image, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.PictureBox_Image)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(489, 415)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(489, 465)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip2)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_SizeLBL, Me.ToolStripLabel_SizeX, Me.ToolStripLabel_SizeSeperator, Me.ToolStripLabel_SizeY, Me.ToolStripSeparator1, Me.ToolStripLabel_NameLBL, Me.ToolStripLabel_Name, Me.ToolStripSeparator2, Me.ToolStripLabel_CreationDateLBL, Me.ToolStripLabel_CreationDate, Me.ToolStripSeparator3, Me.ToolStripProgressBar_Image})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(380, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripLabel_SizeLBL
        '
        Me.ToolStripLabel_SizeLBL.Name = "ToolStripLabel_SizeLBL"
        Me.ToolStripLabel_SizeLBL.Size = New System.Drawing.Size(40, 22)
        Me.ToolStripLabel_SizeLBL.Text = "x_Size:"
        '
        'ToolStripLabel_SizeX
        '
        Me.ToolStripLabel_SizeX.Name = "ToolStripLabel_SizeX"
        Me.ToolStripLabel_SizeX.Size = New System.Drawing.Size(13, 22)
        Me.ToolStripLabel_SizeX.Text = "0"
        '
        'ToolStripLabel_SizeSeperator
        '
        Me.ToolStripLabel_SizeSeperator.Name = "ToolStripLabel_SizeSeperator"
        Me.ToolStripLabel_SizeSeperator.Size = New System.Drawing.Size(12, 22)
        Me.ToolStripLabel_SizeSeperator.Text = "/"
        '
        'ToolStripLabel_SizeY
        '
        Me.ToolStripLabel_SizeY.Name = "ToolStripLabel_SizeY"
        Me.ToolStripLabel_SizeY.Size = New System.Drawing.Size(13, 22)
        Me.ToolStripLabel_SizeY.Text = "0"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel_NameLBL
        '
        Me.ToolStripLabel_NameLBL.Name = "ToolStripLabel_NameLBL"
        Me.ToolStripLabel_NameLBL.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripLabel_NameLBL.Text = "x_Name:"
        '
        'ToolStripLabel_Name
        '
        Me.ToolStripLabel_Name.Name = "ToolStripLabel_Name"
        Me.ToolStripLabel_Name.Size = New System.Drawing.Size(12, 22)
        Me.ToolStripLabel_Name.Text = "-"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel_CreationDateLBL
        '
        Me.ToolStripLabel_CreationDateLBL.Name = "ToolStripLabel_CreationDateLBL"
        Me.ToolStripLabel_CreationDateLBL.Size = New System.Drawing.Size(94, 22)
        Me.ToolStripLabel_CreationDateLBL.Text = "x_Creation-Date:"
        '
        'ToolStripLabel_CreationDate
        '
        Me.ToolStripLabel_CreationDate.Name = "ToolStripLabel_CreationDate"
        Me.ToolStripLabel_CreationDate.Size = New System.Drawing.Size(12, 22)
        Me.ToolStripLabel_CreationDate.Text = "-"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripProgressBar_Image
        '
        Me.ToolStripProgressBar_Image.Name = "ToolStripProgressBar_Image"
        Me.ToolStripProgressBar_Image.Size = New System.Drawing.Size(100, 22)
        '
        'PictureBox_Image
        '
        Me.PictureBox_Image.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox_Image.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox_Image.Name = "PictureBox_Image"
        Me.PictureBox_Image.Size = New System.Drawing.Size(489, 415)
        Me.PictureBox_Image.TabIndex = 0
        Me.PictureBox_Image.TabStop = False
        Me.PictureBox_Image.WaitOnLoad = True
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Copy, Me.ToolStripButton_Paste, Me.ToolStripSeparator6, Me.ToolStripButton_Replace, Me.ToolStripSeparator5, Me.ToolStripSplitButton_Scale, Me.ToolStripButton_Edit})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(233, 25)
        Me.ToolStrip2.TabIndex = 0
        '
        'ToolStripButton_Copy
        '
        Me.ToolStripButton_Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Copy.Enabled = False
        Me.ToolStripButton_Copy.Image = Global.Media_Viewer_Module.My.Resources.Resources._1435_ClipBoard
        Me.ToolStripButton_Copy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Copy.Name = "ToolStripButton_Copy"
        Me.ToolStripButton_Copy.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Copy.Text = "ToolStripButton1"
        '
        'ToolStripButton_Paste
        '
        Me.ToolStripButton_Paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Paste.Image = Global.Media_Viewer_Module.My.Resources.Resources.Paste
        Me.ToolStripButton_Paste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Paste.Name = "ToolStripButton_Paste"
        Me.ToolStripButton_Paste.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Paste.Text = "ToolStripButton1"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_Replace
        '
        Me.ToolStripButton_Replace.CheckOnClick = True
        Me.ToolStripButton_Replace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Replace.Image = CType(resources.GetObject("ToolStripButton_Replace.Image"), System.Drawing.Image)
        Me.ToolStripButton_Replace.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Replace.Name = "ToolStripButton_Replace"
        Me.ToolStripButton_Replace.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripButton_Replace.Text = "x_Replace"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSplitButton_Scale
        '
        Me.ToolStripSplitButton_Scale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripSplitButton_Scale.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_Stretch, Me.ToolStripMenuItem_Original, Me.ToolStripMenuItem_Zoom})
        Me.ToolStripSplitButton_Scale.Image = CType(resources.GetObject("ToolStripSplitButton_Scale.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton_Scale.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton_Scale.Name = "ToolStripSplitButton_Scale"
        Me.ToolStripSplitButton_Scale.Size = New System.Drawing.Size(60, 22)
        Me.ToolStripSplitButton_Scale.Text = "x_Scale"
        '
        'ToolStripMenuItem_Stretch
        '
        Me.ToolStripMenuItem_Stretch.Name = "ToolStripMenuItem_Stretch"
        Me.ToolStripMenuItem_Stretch.Size = New System.Drawing.Size(126, 22)
        Me.ToolStripMenuItem_Stretch.Text = "x_Stretch"
        '
        'ToolStripMenuItem_Original
        '
        Me.ToolStripMenuItem_Original.Name = "ToolStripMenuItem_Original"
        Me.ToolStripMenuItem_Original.Size = New System.Drawing.Size(126, 22)
        Me.ToolStripMenuItem_Original.Text = "x_Original"
        '
        'ToolStripMenuItem_Zoom
        '
        Me.ToolStripMenuItem_Zoom.Checked = True
        Me.ToolStripMenuItem_Zoom.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripMenuItem_Zoom.Name = "ToolStripMenuItem_Zoom"
        Me.ToolStripMenuItem_Zoom.Size = New System.Drawing.Size(126, 22)
        Me.ToolStripMenuItem_Zoom.Text = "x_Zoom"
        '
        'ToolStripButton_Edit
        '
        Me.ToolStripButton_Edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Edit.Image = CType(resources.GetObject("ToolStripButton_Edit.Image"), System.Drawing.Image)
        Me.ToolStripButton_Edit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Edit.Name = "ToolStripButton_Edit"
        Me.ToolStripButton_Edit.Size = New System.Drawing.Size(41, 22)
        Me.ToolStripButton_Edit.Text = "x_Edit"
        '
        'Timer_Image
        '
        Me.Timer_Image.Interval = 300
        '
        'UserControl_ImageViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_ImageViewer"
        Me.Size = New System.Drawing.Size(489, 465)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox_Image, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_SizeLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_SizeX As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_SizeSeperator As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_SizeY As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel_NameLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Name As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel_CreationDateLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_CreationDate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripProgressBar_Image As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents PictureBox_Image As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSplitButton_Scale As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripMenuItem_Stretch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Original As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Zoom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer_Image As System.Windows.Forms.Timer
    Friend WithEvents ToolStripButton_Paste As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Copy As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_Replace As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator

End Class
