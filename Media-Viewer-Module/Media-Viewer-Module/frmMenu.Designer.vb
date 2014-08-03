<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Images = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_MediaItems = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_PDF = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.SuspendLayout()
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.SplitContainer1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(684, 387)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(684, 437)
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Close})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(62, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripButton_Close
        '
        Me.ToolStripButton_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Close.Image = CType(resources.GetObject("ToolStripButton_Close.Image"), System.Drawing.Image)
        Me.ToolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Close.Name = "ToolStripButton_Close"
        Me.ToolStripButton_Close.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripButton_Close.Text = "x_Close"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(684, 387)
        Me.SplitContainer1.SplitterDistance = 228
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Size = New System.Drawing.Size(452, 387)
        Me.SplitContainer2.SplitterDistance = 219
        Me.SplitContainer2.TabIndex = 0
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Images, Me.ToolStripButton_MediaItems, Me.ToolStripButton_PDF})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(237, 25)
        Me.ToolStrip2.TabIndex = 0
        '
        'ToolStripButton_Images
        '
        Me.ToolStripButton_Images.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Images.Image = CType(resources.GetObject("ToolStripButton_Images.Image"), System.Drawing.Image)
        Me.ToolStripButton_Images.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Images.Name = "ToolStripButton_Images"
        Me.ToolStripButton_Images.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripButton_Images.Text = "x_Images"
        '
        'ToolStripButton_MediaItems
        '
        Me.ToolStripButton_MediaItems.Checked = True
        Me.ToolStripButton_MediaItems.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripButton_MediaItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_MediaItems.Image = CType(resources.GetObject("ToolStripButton_MediaItems.Image"), System.Drawing.Image)
        Me.ToolStripButton_MediaItems.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_MediaItems.Name = "ToolStripButton_MediaItems"
        Me.ToolStripButton_MediaItems.Size = New System.Drawing.Size(88, 22)
        Me.ToolStripButton_MediaItems.Text = "x_Media-Items"
        '
        'ToolStripButton_PDF
        '
        Me.ToolStripButton_PDF.Checked = True
        Me.ToolStripButton_PDF.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripButton_PDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_PDF.Image = CType(resources.GetObject("ToolStripButton_PDF.Image"), System.Drawing.Image)
        Me.ToolStripButton_PDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_PDF.Name = "ToolStripButton_PDF"
        Me.ToolStripButton_PDF.Size = New System.Drawing.Size(47, 22)
        Me.ToolStripButton_PDF.Text = "x_PDFs"
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 437)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "frmMenu"
        Me.Text = "x_Media-Viewer-Module - Menu"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Images As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_MediaItems As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_PDF As System.Windows.Forms.ToolStripButton
End Class
