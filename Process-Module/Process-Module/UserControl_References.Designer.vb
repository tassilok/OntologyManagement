<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_References
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_References))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripProgressBar_Refs = New System.Windows.Forms.ToolStripProgressBar()
        Me.TreeView_Refs = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip_References = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcessItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyGUIDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList_Reference = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer_Process_References = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_ProcessLog_Reference = New System.Windows.Forms.Timer(Me.components)
        Me.ModuleMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenModuleByArgumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenLastModuleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout
        Me.ToolStripContainer1.ContentPanel.SuspendLayout
        Me.ToolStripContainer1.SuspendLayout
        Me.ToolStrip1.SuspendLayout
        Me.ContextMenuStrip_References.SuspendLayout
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TreeView_Refs)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(497, 410)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(497, 460)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar_Refs})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(114, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripProgressBar_Refs
        '
        Me.ToolStripProgressBar_Refs.Name = "ToolStripProgressBar_Refs"
        Me.ToolStripProgressBar_Refs.Size = New System.Drawing.Size(100, 22)
        '
        'TreeView_Refs
        '
        Me.TreeView_Refs.ContextMenuStrip = Me.ContextMenuStrip_References
        Me.TreeView_Refs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView_Refs.ImageIndex = 0
        Me.TreeView_Refs.ImageList = Me.ImageList_Reference
        Me.TreeView_Refs.Location = New System.Drawing.Point(0, 0)
        Me.TreeView_Refs.Name = "TreeView_Refs"
        Me.TreeView_Refs.SelectedImageIndex = 0
        Me.TreeView_Refs.Size = New System.Drawing.Size(497, 410)
        Me.TreeView_Refs.TabIndex = 0
        '
        'ContextMenuStrip_References
        '
        Me.ContextMenuStrip_References.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.RemoveToolStripMenuItem, Me.EditToolStripMenuItem})
        Me.ContextMenuStrip_References.Name = "ContextMenuStrip_References"
        Me.ContextMenuStrip_References.Size = New System.Drawing.Size(153, 92)
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcessItemToolStripMenuItem, Me.LogItemToolStripMenuItem})
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NewToolStripMenuItem.Text = "x_New"
        '
        'ProcessItemToolStripMenuItem
        '
        Me.ProcessItemToolStripMenuItem.Name = "ProcessItemToolStripMenuItem"
        Me.ProcessItemToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ProcessItemToolStripMenuItem.Text = "x_Process-Item"
        '
        'LogItemToolStripMenuItem
        '
        Me.LogItemToolStripMenuItem.Name = "LogItemToolStripMenuItem"
        Me.LogItemToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.LogItemToolStripMenuItem.Text = "x_Log-Item"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RemoveToolStripMenuItem.Text = "x_Remove"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyNameToolStripMenuItem, Me.CopyGUIDToolStripMenuItem, Me.ModuleMenuToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'CopyNameToolStripMenuItem
        '
        Me.CopyNameToolStripMenuItem.Name = "CopyNameToolStripMenuItem"
        Me.CopyNameToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CopyNameToolStripMenuItem.Text = "x_Copy Name"
        '
        'CopyGUIDToolStripMenuItem
        '
        Me.CopyGUIDToolStripMenuItem.Name = "CopyGUIDToolStripMenuItem"
        Me.CopyGUIDToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CopyGUIDToolStripMenuItem.Text = "x_Copy GUID"
        '
        'ImageList_Reference
        '
        Me.ImageList_Reference.ImageStream = CType(resources.GetObject("ImageList_Reference.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageList_Reference.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_Reference.Images.SetKeyName(0, "imgRef")
        Me.ImageList_Reference.Images.SetKeyName(1, "imgClass")
        Me.ImageList_Reference.Images.SetKeyName(2, "imgBat")
        Me.ImageList_Reference.Images.SetKeyName(3, "imgAttrib")
        Me.ImageList_Reference.Images.SetKeyName(4, "imgRelationType")
        Me.ImageList_Reference.Images.SetKeyName(5, "imgManual")
        Me.ImageList_Reference.Images.SetKeyName(6, "imgNeeds")
        Me.ImageList_Reference.Images.SetKeyName(7, "imgNeedsChild")
        Me.ImageList_Reference.Images.SetKeyName(8, "imgVariable")
        Me.ImageList_Reference.Images.SetKeyName(9, "imgResponsibility")
        Me.ImageList_Reference.Images.SetKeyName(10, "imgGroup")
        Me.ImageList_Reference.Images.SetKeyName(11, "imgUser")
        Me.ImageList_Reference.Images.SetKeyName(12, "imgDocument")
        Me.ImageList_Reference.Images.SetKeyName(13, "imgFile")
        Me.ImageList_Reference.Images.SetKeyName(14, "imgFolder")
        Me.ImageList_Reference.Images.SetKeyName(15, "imgRole")
        Me.ImageList_Reference.Images.SetKeyName(16, "imgApplication")
        Me.ImageList_Reference.Images.SetKeyName(17, "imgMedia")
        Me.ImageList_Reference.Images.SetKeyName(18, "imgBelonging")
        Me.ImageList_Reference.Images.SetKeyName(19, "imgRefs")
        Me.ImageList_Reference.Images.SetKeyName(20, "imgClasses")
        Me.ImageList_Reference.Images.SetKeyName(21, "imgBats")
        Me.ImageList_Reference.Images.SetKeyName(22, "imgAttributes")
        Me.ImageList_Reference.Images.SetKeyName(23, "imgRelationTypes")
        Me.ImageList_Reference.Images.SetKeyName(24, "img_Manuals")
        Me.ImageList_Reference.Images.SetKeyName(25, "img_NeedsPar")
        Me.ImageList_Reference.Images.SetKeyName(26, "img_NeedsChildPar")
        Me.ImageList_Reference.Images.SetKeyName(27, "img_Variables")
        Me.ImageList_Reference.Images.SetKeyName(28, "img_Responsibilities")
        Me.ImageList_Reference.Images.SetKeyName(29, "img_Groups")
        Me.ImageList_Reference.Images.SetKeyName(30, "img_Users")
        Me.ImageList_Reference.Images.SetKeyName(31, "img_Documents")
        Me.ImageList_Reference.Images.SetKeyName(32, "img_Files")
        Me.ImageList_Reference.Images.SetKeyName(33, "img_Folders")
        Me.ImageList_Reference.Images.SetKeyName(34, "img_Roles")
        Me.ImageList_Reference.Images.SetKeyName(35, "img_Applications")
        Me.ImageList_Reference.Images.SetKeyName(36, "img_Medias")
        Me.ImageList_Reference.Images.SetKeyName(37, "img_Belongings")
        Me.ImageList_Reference.Images.SetKeyName(38, "img_VarVal")
        Me.ImageList_Reference.Images.SetKeyName(39, "Image 0.png")
        Me.ImageList_Reference.Images.SetKeyName(40, "Image 1.png")
        Me.ImageList_Reference.Images.SetKeyName(41, "Image 2.png")
        Me.ImageList_Reference.Images.SetKeyName(42, "Image 3.png")
        Me.ImageList_Reference.Images.SetKeyName(43, "Image 4.png")
        Me.ImageList_Reference.Images.SetKeyName(44, "Image 5.png")
        Me.ImageList_Reference.Images.SetKeyName(45, "Image 6.png")
        Me.ImageList_Reference.Images.SetKeyName(46, "Image 7.png")
        Me.ImageList_Reference.Images.SetKeyName(47, "Image 8.png")
        Me.ImageList_Reference.Images.SetKeyName(48, "Image 9.png")
        Me.ImageList_Reference.Images.SetKeyName(49, "Image 10.png")
        Me.ImageList_Reference.Images.SetKeyName(50, "Image 11.png")
        Me.ImageList_Reference.Images.SetKeyName(51, "Image 12.png")
        Me.ImageList_Reference.Images.SetKeyName(52, "Image 13.png")
        Me.ImageList_Reference.Images.SetKeyName(53, "Image 14.png")
        Me.ImageList_Reference.Images.SetKeyName(54, "Image 15.png")
        Me.ImageList_Reference.Images.SetKeyName(55, "Image 16.png")
        Me.ImageList_Reference.Images.SetKeyName(56, "Image 17.png")
        Me.ImageList_Reference.Images.SetKeyName(57, "Image 18.png")
        Me.ImageList_Reference.Images.SetKeyName(58, "construction_hammer_jon__01.png")
        Me.ImageList_Reference.Images.SetKeyName(59, "mattone_poroton_architet_01.png")
        Me.ImageList_Reference.Images.SetKeyName(60, "construction_hammer_jon__01.png")
        Me.ImageList_Reference.Images.SetKeyName(61, "mattone_poroton_architet_01.png")
        Me.ImageList_Reference.Images.SetKeyName(62, "construction_hammer_jon__01.png")
        Me.ImageList_Reference.Images.SetKeyName(63, "mattone_poroton_architet_01.png")
        '
        'Timer_Process_References
        '
        Me.Timer_Process_References.Interval = 200
        '
        'Timer_ProcessLog_Reference
        '
        Me.Timer_ProcessLog_Reference.Interval = 200
        '
        'ModuleMenuToolStripMenuItem
        '
        Me.ModuleMenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenModuleByArgumentToolStripMenuItem})
        Me.ModuleMenuToolStripMenuItem.Name = "ModuleMenuToolStripMenuItem"
        Me.ModuleMenuToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ModuleMenuToolStripMenuItem.Text = "x_Module-Menu"
        '
        'OpenModuleByArgumentToolStripMenuItem
        '
        Me.OpenModuleByArgumentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenLastModuleToolStripMenuItem})
        Me.OpenModuleByArgumentToolStripMenuItem.Name = "OpenModuleByArgumentToolStripMenuItem"
        Me.OpenModuleByArgumentToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.OpenModuleByArgumentToolStripMenuItem.Text = "x_Open Module by Argument"
        '
        'OpenLastModuleToolStripMenuItem
        '
        Me.OpenLastModuleToolStripMenuItem.CheckOnClick = true
        Me.OpenLastModuleToolStripMenuItem.Name = "OpenLastModuleToolStripMenuItem"
        Me.OpenLastModuleToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.OpenLastModuleToolStripMenuItem.Text = "x_Open Last Module"
        '
        'UserControl_References
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_References"
        Me.Size = New System.Drawing.Size(497, 460)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(false)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(false)
        Me.ToolStripContainer1.ResumeLayout(false)
        Me.ToolStripContainer1.PerformLayout
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.ContextMenuStrip_References.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripProgressBar_Refs As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ContextMenuStrip_References As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcessItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyGUIDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList_Reference As System.Windows.Forms.ImageList
    Friend WithEvents Timer_Process_References As System.Windows.Forms.Timer
    Friend WithEvents TreeView_Refs As System.Windows.Forms.TreeView
    Friend WithEvents Timer_ProcessLog_Reference As System.Windows.Forms.Timer
    Friend WithEvents ModuleMenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenModuleByArgumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenLastModuleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
