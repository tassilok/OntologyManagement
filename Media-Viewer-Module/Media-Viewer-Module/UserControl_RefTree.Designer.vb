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
        Me.ToolStripLabel_ItemCountLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_ItemCount = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_RelLeft = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Seperator = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_RelRight = New System.Windows.Forms.ToolStripLabel()
        Me.TreeView_Ref = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip_Ref = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList_RelatedItems = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_Mark = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripTextBox_Mark = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ContextMenuStrip_Ref.SuspendLayout()
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TreeView_Ref)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(475, 380)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(475, 430)
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_ItemCountLBL, Me.ToolStripLabel_ItemCount, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.ToolStripLabel_RelLeft, Me.ToolStripLabel_Seperator, Me.ToolStripLabel_RelRight})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(176, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripLabel_ItemCountLBL
        '
        Me.ToolStripLabel_ItemCountLBL.Name = "ToolStripLabel_ItemCountLBL"
        Me.ToolStripLabel_ItemCountLBL.Size = New System.Drawing.Size(46, 22)
        Me.ToolStripLabel_ItemCountLBL.Text = "x_Items"
        '
        'ToolStripLabel_ItemCount
        '
        Me.ToolStripLabel_ItemCount.Name = "ToolStripLabel_ItemCount"
        Me.ToolStripLabel_ItemCount.Size = New System.Drawing.Size(13, 22)
        Me.ToolStripLabel_ItemCount.Text = "0"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripLabel1.Text = "x_Relation:"
        '
        'ToolStripLabel_RelLeft
        '
        Me.ToolStripLabel_RelLeft.Name = "ToolStripLabel_RelLeft"
        Me.ToolStripLabel_RelLeft.Size = New System.Drawing.Size(12, 22)
        Me.ToolStripLabel_RelLeft.Text = "-"
        '
        'ToolStripLabel_Seperator
        '
        Me.ToolStripLabel_Seperator.Name = "ToolStripLabel_Seperator"
        Me.ToolStripLabel_Seperator.Size = New System.Drawing.Size(12, 22)
        Me.ToolStripLabel_Seperator.Text = "/"
        '
        'ToolStripLabel_RelRight
        '
        Me.ToolStripLabel_RelRight.Name = "ToolStripLabel_RelRight"
        Me.ToolStripLabel_RelRight.Size = New System.Drawing.Size(12, 22)
        Me.ToolStripLabel_RelRight.Text = "-"
        '
        'TreeView_Ref
        '
        Me.TreeView_Ref.ContextMenuStrip = Me.ContextMenuStrip_Ref
        Me.TreeView_Ref.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView_Ref.ImageIndex = 0
        Me.TreeView_Ref.ImageList = Me.ImageList_RelatedItems
        Me.TreeView_Ref.Location = New System.Drawing.Point(0, 0)
        Me.TreeView_Ref.Name = "TreeView_Ref"
        Me.TreeView_Ref.SelectedImageIndex = 0
        Me.TreeView_Ref.Size = New System.Drawing.Size(475, 380)
        Me.TreeView_Ref.TabIndex = 0
        '
        'ContextMenuStrip_Ref
        '
        Me.ContextMenuStrip_Ref.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.ContextMenuStrip_Ref.Name = "ContextMenuStrip_Ref"
        Me.ContextMenuStrip_Ref.Size = New System.Drawing.Size(109, 48)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.AddToolStripMenuItem.Text = "x_Add"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.SaveToolStripMenuItem.Text = "x_Save"
        '
        'ImageList_RelatedItems
        '
        Me.ImageList_RelatedItems.ImageStream = CType(resources.GetObject("ImageList_RelatedItems.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_RelatedItems.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_RelatedItems.Images.SetKeyName(0, "bb_home_.png")
        Me.ImageList_RelatedItems.Images.SetKeyName(1, "Types_Closed.png")
        Me.ImageList_RelatedItems.Images.SetKeyName(2, "Types_Closed SubItems.png")
        Me.ImageList_RelatedItems.Images.SetKeyName(3, "Types_Closed Images.png")
        Me.ImageList_RelatedItems.Images.SetKeyName(4, "Types_Closed SubItems Image.png")
        Me.ImageList_RelatedItems.Images.SetKeyName(5, "Types_Opened.png")
        Me.ImageList_RelatedItems.Images.SetKeyName(6, "Types_Opened SubItems.png")
        Me.ImageList_RelatedItems.Images.SetKeyName(7, "Types_Opened Image.png")
        Me.ImageList_RelatedItems.Images.SetKeyName(8, "Types_Opened SubItems Image.png")
        Me.ImageList_RelatedItems.Images.SetKeyName(9, "Attributes bamboo_danny_allen_r.png")
        Me.ImageList_RelatedItems.Images.SetKeyName(10, "RelationTypes gpride_jean_victor_balin_.png")
        Me.ImageList_RelatedItems.Images.SetKeyName(11, "Vogelschwarm klein.png")
        Me.ImageList_RelatedItems.Images.SetKeyName(12, "Attributes bamboo_danny_allen_r.png")
        Me.ImageList_RelatedItems.Images.SetKeyName(13, "RelationTypes gpride_jean_victor_balin_.png")
        Me.ImageList_RelatedItems.Images.SetKeyName(14, "Vogelschwarm%20klein.ico")
        Me.ImageList_RelatedItems.Images.SetKeyName(15, "Types_Closed.png")
        Me.ImageList_RelatedItems.Images.SetKeyName(16, "Types_Opened.png")
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_Mark, Me.ToolStripTextBox_Mark})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(261, 25)
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
        'UserControl_RefTree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_RefTree"
        Me.Size = New System.Drawing.Size(475, 430)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextMenuStrip_Ref.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TreeView_Ref As System.Windows.Forms.TreeView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_Mark As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox_Mark As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel_ItemCountLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_ItemCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_RelLeft As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Seperator As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_RelRight As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ImageList_RelatedItems As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuStrip_Ref As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
