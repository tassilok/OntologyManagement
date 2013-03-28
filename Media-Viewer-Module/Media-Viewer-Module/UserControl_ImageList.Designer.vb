<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_ImageList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_ImageList))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_CountLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Count = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripProgressBar_Images = New System.Windows.Forms.ToolStripProgressBar()
        Me.DataGridView_Images = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip_Relate = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RelateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RelateAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveImagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Paste = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Relate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Meta = New System.Windows.Forms.ToolStripButton()
        Me.BindingSource_Images = New System.Windows.Forms.BindingSource(Me.components)
        Me.Timer_Images = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripButton_Remove = New System.Windows.Forms.ToolStripButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView_Images, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip_Relate.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.BindingSource_Images, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStripContainer1)
        Me.SplitContainer1.Size = New System.Drawing.Size(637, 467)
        Me.SplitContainer1.SplitterDistance = 206
        Me.SplitContainer1.TabIndex = 0
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DataGridView_Images)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(202, 413)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(202, 463)
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_CountLBL, Me.ToolStripLabel_Count, Me.ToolStripProgressBar_Images})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(177, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripLabel_CountLBL
        '
        Me.ToolStripLabel_CountLBL.Name = "ToolStripLabel_CountLBL"
        Me.ToolStripLabel_CountLBL.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripLabel_CountLBL.Text = "x_Count:"
        '
        'ToolStripLabel_Count
        '
        Me.ToolStripLabel_Count.Name = "ToolStripLabel_Count"
        Me.ToolStripLabel_Count.Size = New System.Drawing.Size(13, 22)
        Me.ToolStripLabel_Count.Text = "0"
        '
        'ToolStripProgressBar_Images
        '
        Me.ToolStripProgressBar_Images.Name = "ToolStripProgressBar_Images"
        Me.ToolStripProgressBar_Images.Size = New System.Drawing.Size(100, 22)
        '
        'DataGridView_Images
        '
        Me.DataGridView_Images.AllowUserToAddRows = False
        Me.DataGridView_Images.AllowUserToDeleteRows = False
        Me.DataGridView_Images.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Images.ContextMenuStrip = Me.ContextMenuStrip_Relate
        Me.DataGridView_Images.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_Images.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_Images.Name = "DataGridView_Images"
        Me.DataGridView_Images.ReadOnly = True
        Me.DataGridView_Images.Size = New System.Drawing.Size(202, 413)
        Me.DataGridView_Images.TabIndex = 0
        '
        'ContextMenuStrip_Relate
        '
        Me.ContextMenuStrip_Relate.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RelateToolStripMenuItem, Me.RelateAllToolStripMenuItem, Me.SaveImagesToolStripMenuItem})
        Me.ContextMenuStrip_Relate.Name = "ContextMenuStrip_Relate"
        Me.ContextMenuStrip_Relate.Size = New System.Drawing.Size(149, 70)
        '
        'RelateToolStripMenuItem
        '
        Me.RelateToolStripMenuItem.Enabled = False
        Me.RelateToolStripMenuItem.Name = "RelateToolStripMenuItem"
        Me.RelateToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.RelateToolStripMenuItem.Text = "x_Relate"
        '
        'RelateAllToolStripMenuItem
        '
        Me.RelateAllToolStripMenuItem.Enabled = False
        Me.RelateAllToolStripMenuItem.Name = "RelateAllToolStripMenuItem"
        Me.RelateAllToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.RelateAllToolStripMenuItem.Text = "x_Relate all"
        '
        'SaveImagesToolStripMenuItem
        '
        Me.SaveImagesToolStripMenuItem.Enabled = False
        Me.SaveImagesToolStripMenuItem.Name = "SaveImagesToolStripMenuItem"
        Me.SaveImagesToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.SaveImagesToolStripMenuItem.Text = "x_Save Images"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Paste, Me.ToolStripButton_Remove, Me.ToolStripButton_Relate, Me.ToolStripButton_Meta})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(199, 25)
        Me.ToolStrip2.TabIndex = 0
        '
        'ToolStripButton_Paste
        '
        Me.ToolStripButton_Paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Paste.Image = Global.Media_Viewer_Module.My.Resources.Resources.b_plus_with_Folder
        Me.ToolStripButton_Paste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Paste.Name = "ToolStripButton_Paste"
        Me.ToolStripButton_Paste.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Paste.Text = "ToolStripButton2"
        '
        'ToolStripButton_Relate
        '
        Me.ToolStripButton_Relate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Relate.Image = CType(resources.GetObject("ToolStripButton_Relate.Image"), System.Drawing.Image)
        Me.ToolStripButton_Relate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Relate.Name = "ToolStripButton_Relate"
        Me.ToolStripButton_Relate.Size = New System.Drawing.Size(54, 22)
        Me.ToolStripButton_Relate.Text = "x_Relate"
        '
        'ToolStripButton_Meta
        '
        Me.ToolStripButton_Meta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Meta.Image = CType(resources.GetObject("ToolStripButton_Meta.Image"), System.Drawing.Image)
        Me.ToolStripButton_Meta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Meta.Name = "ToolStripButton_Meta"
        Me.ToolStripButton_Meta.Size = New System.Drawing.Size(88, 17)
        Me.ToolStripButton_Meta.Text = "x_get Metadata"
        '
        'Timer_Images
        '
        Me.Timer_Images.Interval = 300
        '
        'ToolStripButton_Remove
        '
        Me.ToolStripButton_Remove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Remove.Image = Global.Media_Viewer_Module.My.Resources.Resources.tasto_8_architetto_franc_01
        Me.ToolStripButton_Remove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Remove.Name = "ToolStripButton_Remove"
        Me.ToolStripButton_Remove.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Remove.Text = "ToolStripButton1"
        '
        'UserControl_ImageList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "UserControl_ImageList"
        Me.Size = New System.Drawing.Size(637, 467)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView_Images, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip_Relate.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.BindingSource_Images, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_CountLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Count As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents DataGridView_Images As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripButton_Paste As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Relate As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Meta As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingSource_Images As System.Windows.Forms.BindingSource
    Friend WithEvents Timer_Images As System.Windows.Forms.Timer
    Friend WithEvents ToolStripProgressBar_Images As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ContextMenuStrip_Relate As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RelateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RelateAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveImagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton_Remove As System.Windows.Forms.ToolStripButton

End Class
