<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_SingleViewer
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
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_First = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Previous = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Next = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Last = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel_CountLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripTextBox_Curr = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Count = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_Playlist = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripTextBox_Sec = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel_secLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
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
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(521, 410)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(521, 460)
        Me.ToolStripContainer1.TabIndex = 1
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_First, Me.ToolStripButton_Previous, Me.ToolStripButton_Next, Me.ToolStripButton_Last, Me.ToolStripSeparator2, Me.ToolStripLabel_CountLBL, Me.ToolStripTextBox_Curr, Me.ToolStripLabel1, Me.ToolStripLabel_Count, Me.ToolStripSeparator1, Me.ToolStripButton_Playlist, Me.ToolStripTextBox_Sec, Me.ToolStripLabel_secLBL})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(314, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripButton_First
        '
        Me.ToolStripButton_First.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_First.Enabled = False
        Me.ToolStripButton_First.Image = Global.Media_Viewer_Module.My.Resources.Resources.pulsante_01_architetto_f_01_First
        Me.ToolStripButton_First.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_First.Name = "ToolStripButton_First"
        Me.ToolStripButton_First.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_First.Text = "ToolStripButton1"
        '
        'ToolStripButton_Previous
        '
        Me.ToolStripButton_Previous.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Previous.Enabled = False
        Me.ToolStripButton_Previous.Image = Global.Media_Viewer_Module.My.Resources.Resources.pulsante_01_architetto_f_01
        Me.ToolStripButton_Previous.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Previous.Name = "ToolStripButton_Previous"
        Me.ToolStripButton_Previous.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Previous.Text = "ToolStripButton2"
        '
        'ToolStripButton_Next
        '
        Me.ToolStripButton_Next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Next.Enabled = False
        Me.ToolStripButton_Next.Image = Global.Media_Viewer_Module.My.Resources.Resources.pulsante_02_architetto_f_01
        Me.ToolStripButton_Next.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Next.Name = "ToolStripButton_Next"
        Me.ToolStripButton_Next.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Next.Text = "ToolStripButton3"
        '
        'ToolStripButton_Last
        '
        Me.ToolStripButton_Last.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Last.Enabled = False
        Me.ToolStripButton_Last.Image = Global.Media_Viewer_Module.My.Resources.Resources.pulsante_02_architetto_f_01_Last
        Me.ToolStripButton_Last.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Last.Name = "ToolStripButton_Last"
        Me.ToolStripButton_Last.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Last.Text = "ToolStripButton4"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel_CountLBL
        '
        Me.ToolStripLabel_CountLBL.Name = "ToolStripLabel_CountLBL"
        Me.ToolStripLabel_CountLBL.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripLabel_CountLBL.Text = "x_Count:"
        '
        'ToolStripTextBox_Curr
        '
        Me.ToolStripTextBox_Curr.Name = "ToolStripTextBox_Curr"
        Me.ToolStripTextBox_Curr.ReadOnly = True
        Me.ToolStripTextBox_Curr.Size = New System.Drawing.Size(20, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(12, 22)
        Me.ToolStripLabel1.Text = "/"
        '
        'ToolStripLabel_Count
        '
        Me.ToolStripLabel_Count.Name = "ToolStripLabel_Count"
        Me.ToolStripLabel_Count.Size = New System.Drawing.Size(13, 22)
        Me.ToolStripLabel_Count.Text = "0"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_Playlist
        '
        Me.ToolStripButton_Playlist.CheckOnClick = True
        Me.ToolStripButton_Playlist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Playlist.Enabled = False
        Me.ToolStripButton_Playlist.Image = Global.Media_Viewer_Module.My.Resources.Resources.bb_fforward_
        Me.ToolStripButton_Playlist.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Playlist.Name = "ToolStripButton_Playlist"
        Me.ToolStripButton_Playlist.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Playlist.Text = "ToolStripButton5"
        '
        'ToolStripTextBox_Sec
        '
        Me.ToolStripTextBox_Sec.Enabled = False
        Me.ToolStripTextBox_Sec.Name = "ToolStripTextBox_Sec"
        Me.ToolStripTextBox_Sec.Size = New System.Drawing.Size(20, 25)
        Me.ToolStripTextBox_Sec.Text = "5"
        '
        'ToolStripLabel_secLBL
        '
        Me.ToolStripLabel_secLBL.Name = "ToolStripLabel_secLBL"
        Me.ToolStripLabel_secLBL.Size = New System.Drawing.Size(22, 22)
        Me.ToolStripLabel_secLBL.Text = "x_s"
        '
        'UserControl_SingleViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_SingleViewer"
        Me.Size = New System.Drawing.Size(521, 460)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_First As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Previous As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Next As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Last As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_Playlist As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripTextBox_Sec As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel_secLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel_CountLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox_Curr As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Count As System.Windows.Forms.ToolStripLabel

End Class
