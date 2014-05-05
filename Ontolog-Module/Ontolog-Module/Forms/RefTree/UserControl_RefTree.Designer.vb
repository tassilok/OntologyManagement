<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_RefTree
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_RefTree))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_CountCapt = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Count = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripProgressBar_Items = New System.Windows.Forms.ToolStripProgressBar()
        Me.TreeView_Ref = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip_Ref = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imageList_Ref = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_Mark = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripTextBox_Mark = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripButton_ClearMark = New System.Windows.Forms.ToolStripButton()
        Me.Timer_Ref = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Mark = New System.Windows.Forms.Timer(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyGuidToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout
        Me.ToolStripContainer1.ContentPanel.SuspendLayout
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout
        Me.ToolStripContainer1.SuspendLayout
        Me.ToolStrip1.SuspendLayout
        Me.ContextMenuStrip_Ref.SuspendLayout
        Me.ToolStrip2.SuspendLayout
        Me.SuspendLayout
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TreeView_Ref)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(369, 392)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(369, 442)
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_CountCapt, Me.ToolStripLabel_Count, Me.ToolStripProgressBar_Items})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(180, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripLabel_CountCapt
        '
        Me.ToolStripLabel_CountCapt.Name = "ToolStripLabel_CountCapt"
        Me.ToolStripLabel_CountCapt.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripLabel_CountCapt.Text = "x_Count:"
        '
        'ToolStripLabel_Count
        '
        Me.ToolStripLabel_Count.Name = "ToolStripLabel_Count"
        Me.ToolStripLabel_Count.Size = New System.Drawing.Size(13, 22)
        Me.ToolStripLabel_Count.Text = "0"
        '
        'ToolStripProgressBar_Items
        '
        Me.ToolStripProgressBar_Items.Name = "ToolStripProgressBar_Items"
        Me.ToolStripProgressBar_Items.Size = New System.Drawing.Size(100, 22)
        '
        'TreeView_Ref
        '
        Me.TreeView_Ref.ContextMenuStrip = Me.ContextMenuStrip_Ref
        Me.TreeView_Ref.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView_Ref.HideSelection = false
        Me.TreeView_Ref.ImageIndex = 0
        Me.TreeView_Ref.ImageList = Me.imageList_Ref
        Me.TreeView_Ref.Location = New System.Drawing.Point(0, 0)
        Me.TreeView_Ref.Name = "TreeView_Ref"
        Me.TreeView_Ref.SelectedImageIndex = 0
        Me.TreeView_Ref.Size = New System.Drawing.Size(369, 392)
        Me.TreeView_Ref.TabIndex = 0
        '
        'ContextMenuStrip_Ref
        '
        Me.ContextMenuStrip_Ref.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.EditToolStripMenuItem})
        Me.ContextMenuStrip_Ref.Name = "ContextMenuStrip_Ref"
        Me.ContextMenuStrip_Ref.Size = New System.Drawing.Size(153, 70)
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NewToolStripMenuItem.Text = "x_New"
        '
        'imageList_Ref
        '
        Me.imageList_Ref.ImageStream = CType(resources.GetObject("imageList_Ref.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.imageList_Ref.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList_Ref.Images.SetKeyName(0, "bb_home_.png")
        Me.imageList_Ref.Images.SetKeyName(1, "Types_Closed.png")
        Me.imageList_Ref.Images.SetKeyName(2, "gnome-fs-home.png")
        Me.imageList_Ref.Images.SetKeyName(3, "Attributes bamboo_danny_allen_r.png")
        Me.imageList_Ref.Images.SetKeyName(4, "Attributes bamboo_danny_allen_r.png")
        Me.imageList_Ref.Images.SetKeyName(5, "RelationTypes gpride_jean_victor_balin_.png")
        Me.imageList_Ref.Images.SetKeyName(6, "RelationTypes gpride_jean_victor_balin_.png")
        Me.imageList_Ref.Images.SetKeyName(7, "Vogelschwarm.png")
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_Mark, Me.ToolStripTextBox_Mark, Me.ToolStripButton_ClearMark})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(284, 25)
        Me.ToolStrip2.TabIndex = 0
        '
        'ToolStripLabel_Mark
        '
        Me.ToolStripLabel_Mark.Name = "ToolStripLabel_Mark"
        Me.ToolStripLabel_Mark.Size = New System.Drawing.Size(47, 22)
        Me.ToolStripLabel_Mark.Text = "x_Mark:"
        '
        'ToolStripTextBox_Mark
        '
        Me.ToolStripTextBox_Mark.Name = "ToolStripTextBox_Mark"
        Me.ToolStripTextBox_Mark.Size = New System.Drawing.Size(200, 25)
        '
        'ToolStripButton_ClearMark
        '
        Me.ToolStripButton_ClearMark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_ClearMark.Image = Global.Ontology_Module.My.Resources.Resources.tasto_8_architetto_franc_01
        Me.ToolStripButton_ClearMark.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_ClearMark.Name = "ToolStripButton_ClearMark"
        Me.ToolStripButton_ClearMark.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_ClearMark.Text = "ToolStripButton1"
        '
        'Timer_Ref
        '
        Me.Timer_Ref.Interval = 300
        '
        'Timer_Mark
        '
        Me.Timer_Mark.Interval = 300
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyGuidToolStripMenuItem, Me.CopyNameToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EditToolStripMenuItem.Text = "x_Edit"
        '
        'CopyGuidToolStripMenuItem
        '
        Me.CopyGuidToolStripMenuItem.Name = "CopyGuidToolStripMenuItem"
        Me.CopyGuidToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CopyGuidToolStripMenuItem.Text = "x_Copy Guid"
        '
        'CopyNameToolStripMenuItem
        '
        Me.CopyNameToolStripMenuItem.Name = "CopyNameToolStripMenuItem"
        Me.CopyNameToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CopyNameToolStripMenuItem.Text = "x_Copy Name"
        '
        'UserControl_RefTree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_RefTree"
        Me.Size = New System.Drawing.Size(369, 442)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(false)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(false)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(false)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout
        Me.ToolStripContainer1.ResumeLayout(false)
        Me.ToolStripContainer1.PerformLayout
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.ContextMenuStrip_Ref.ResumeLayout(false)
        Me.ToolStrip2.ResumeLayout(false)
        Me.ToolStrip2.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_CountCapt As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Count As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TreeView_Ref As System.Windows.Forms.TreeView
    Private WithEvents imageList_Ref As System.Windows.Forms.ImageList
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_Mark As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox_Mark As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripProgressBar_Items As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Timer_Ref As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip_Ref As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer_Mark As System.Windows.Forms.Timer
    Friend WithEvents ToolStripButton_ClearMark As System.Windows.Forms.ToolStripButton
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyGuidToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
