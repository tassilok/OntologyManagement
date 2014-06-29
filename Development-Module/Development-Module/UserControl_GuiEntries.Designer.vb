<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_GuiEntries
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_GuiEntries))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_CountLbl = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Count = New System.Windows.Forms.ToolStripLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TreeView_GuiEntries = New System.Windows.Forms.TreeView()
        Me.ImageList_GuiEntries = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip_GuiEntries = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewGuiEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewCaptionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewTooltipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextMenuStrip_GuiEntries.SuspendLayout()
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
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(539, 387)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(539, 437)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_CountLbl, Me.ToolStripLabel_Count})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(78, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripLabel_CountLbl
        '
        Me.ToolStripLabel_CountLbl.Name = "ToolStripLabel_CountLbl"
        Me.ToolStripLabel_CountLbl.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripLabel_CountLbl.Text = "x_Count:"
        '
        'ToolStripLabel_Count
        '
        Me.ToolStripLabel_Count.Name = "ToolStripLabel_Count"
        Me.ToolStripLabel_Count.Size = New System.Drawing.Size(13, 22)
        Me.ToolStripLabel_Count.Text = "0"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeView_GuiEntries)
        Me.SplitContainer1.Size = New System.Drawing.Size(539, 387)
        Me.SplitContainer1.SplitterDistance = 244
        Me.SplitContainer1.TabIndex = 0
        '
        'TreeView_GuiEntries
        '
        Me.TreeView_GuiEntries.ContextMenuStrip = Me.ContextMenuStrip_GuiEntries
        Me.TreeView_GuiEntries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView_GuiEntries.ImageIndex = 0
        Me.TreeView_GuiEntries.ImageList = Me.ImageList_GuiEntries
        Me.TreeView_GuiEntries.Location = New System.Drawing.Point(0, 0)
        Me.TreeView_GuiEntries.Name = "TreeView_GuiEntries"
        Me.TreeView_GuiEntries.SelectedImageIndex = 0
        Me.TreeView_GuiEntries.Size = New System.Drawing.Size(240, 383)
        Me.TreeView_GuiEntries.TabIndex = 0
        '
        'ImageList_GuiEntries
        '
        Me.ImageList_GuiEntries.ImageStream = CType(resources.GetObject("ImageList_GuiEntries.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_GuiEntries.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_GuiEntries.Images.SetKeyName(0, "bb_home_.png")
        Me.ImageList_GuiEntries.Images.SetKeyName(1, "mycomp.ico")
        Me.ImageList_GuiEntries.Images.SetKeyName(2, "Procedures.png")
        Me.ImageList_GuiEntries.Images.SetKeyName(3, "gnome-mime-document.ico")
        Me.ImageList_GuiEntries.Images.SetKeyName(4, "1683_Lightbulb_32x32.png")
        '
        'ContextMenuStrip_GuiEntries
        '
        Me.ContextMenuStrip_GuiEntries.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewGuiEntryToolStripMenuItem, Me.NewCaptionToolStripMenuItem, Me.NewTooltipToolStripMenuItem})
        Me.ContextMenuStrip_GuiEntries.Name = "ContextMenuStrip_GuiEntries"
        Me.ContextMenuStrip_GuiEntries.Size = New System.Drawing.Size(162, 92)
        '
        'NewGuiEntryToolStripMenuItem
        '
        Me.NewGuiEntryToolStripMenuItem.Name = "NewGuiEntryToolStripMenuItem"
        Me.NewGuiEntryToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.NewGuiEntryToolStripMenuItem.Text = "x_New Gui-Entry"
        '
        'NewCaptionToolStripMenuItem
        '
        Me.NewCaptionToolStripMenuItem.Name = "NewCaptionToolStripMenuItem"
        Me.NewCaptionToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.NewCaptionToolStripMenuItem.Text = "x_New Caption"
        '
        'NewTooltipToolStripMenuItem
        '
        Me.NewTooltipToolStripMenuItem.Name = "NewTooltipToolStripMenuItem"
        Me.NewTooltipToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.NewTooltipToolStripMenuItem.Text = "x_New Tooltip"
        '
        'UserControl_GuiEntries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_GuiEntries"
        Me.Size = New System.Drawing.Size(539, 437)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextMenuStrip_GuiEntries.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_CountLbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Count As System.Windows.Forms.ToolStripLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TreeView_GuiEntries As System.Windows.Forms.TreeView
    Friend WithEvents ImageList_GuiEntries As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuStrip_GuiEntries As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewGuiEntryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewCaptionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewTooltipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
