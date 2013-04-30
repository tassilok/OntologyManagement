<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_Process
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_Process))
        Me.Timer_Process = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip_Process = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectExistingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportHTMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApplyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList_Process = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer_Mark = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip_Process.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer_Process
        '
        Me.Timer_Process.Interval = 300
        '
        'ContextMenuStrip_Process
        '
        Me.ContextMenuStrip_Process.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.EditToolStripMenuItem, Me.RemoveToolStripMenuItem, Me.ApplyToolStripMenuItem})
        Me.ContextMenuStrip_Process.Name = "ContextMenuStrip_Proces"
        Me.ContextMenuStrip_Process.Size = New System.Drawing.Size(128, 92)
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateNewToolStripMenuItem, Me.SelectExistingToolStripMenuItem})
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.NewToolStripMenuItem.Text = "x_New"
        '
        'CreateNewToolStripMenuItem
        '
        Me.CreateNewToolStripMenuItem.Name = "CreateNewToolStripMenuItem"
        Me.CreateNewToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.CreateNewToolStripMenuItem.Text = "x_Create new"
        '
        'SelectExistingToolStripMenuItem
        '
        Me.SelectExistingToolStripMenuItem.Name = "SelectExistingToolStripMenuItem"
        Me.SelectExistingToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.SelectExistingToolStripMenuItem.Text = "x_Select Existing"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportHTMLToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.EditToolStripMenuItem.Text = "x_Edit"
        '
        'ExportHTMLToolStripMenuItem
        '
        Me.ExportHTMLToolStripMenuItem.Name = "ExportHTMLToolStripMenuItem"
        Me.ExportHTMLToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ExportHTMLToolStripMenuItem.Text = "x_Export HTML"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.RemoveToolStripMenuItem.Text = "x_Remove"
        '
        'ApplyToolStripMenuItem
        '
        Me.ApplyToolStripMenuItem.Name = "ApplyToolStripMenuItem"
        Me.ApplyToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.ApplyToolStripMenuItem.Text = "x_Apply"
        Me.ApplyToolStripMenuItem.Visible = False
        '
        'ImageList_Process
        '
        Me.ImageList_Process.ImageStream = CType(resources.GetObject("ImageList_Process.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_Process.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_Process.Images.SetKeyName(0, "bb_home_.png")
        Me.ImageList_Process.Images.SetKeyName(1, "mycomp.png")
        '
        'Timer_Mark
        '
        Me.Timer_Mark.Interval = 500
        '
        'UserControl_Process
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "UserControl_Process"
        Me.Size = New System.Drawing.Size(608, 455)
        Me.ContextMenuStrip_Process.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer_Process As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip_Process As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateNewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectExistingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportHTMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ApplyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList_Process As System.Windows.Forms.ImageList
    Friend WithEvents Timer_Mark As System.Windows.Forms.Timer

End Class
