﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_OntologyTree
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_OntologyTree))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_CountLbl = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Count = New System.Windows.Forms.ToolStripLabel()
        Me.TreeView_Ontologies = New System.Windows.Forms.TreeView()
        Me.ImageList_Ontologies = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_Mark = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripTextBox_Mark = New System.Windows.Forms.ToolStripTextBox()
        Me.ContextMenuStrip_Ontologies = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.ContextMenuStrip_Ontologies.SuspendLayout()
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TreeView_Ontologies)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(495, 413)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(495, 463)
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
        'TreeView_Ontologies
        '
        Me.TreeView_Ontologies.ContextMenuStrip = Me.ContextMenuStrip_Ontologies
        Me.TreeView_Ontologies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView_Ontologies.ImageIndex = 0
        Me.TreeView_Ontologies.ImageList = Me.ImageList_Ontologies
        Me.TreeView_Ontologies.Location = New System.Drawing.Point(0, 0)
        Me.TreeView_Ontologies.Name = "TreeView_Ontologies"
        Me.TreeView_Ontologies.SelectedImageIndex = 0
        Me.TreeView_Ontologies.Size = New System.Drawing.Size(495, 413)
        Me.TreeView_Ontologies.TabIndex = 0
        '
        'ImageList_Ontologies
        '
        Me.ImageList_Ontologies.ImageStream = CType(resources.GetObject("ImageList_Ontologies.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_Ontologies.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_Ontologies.Images.SetKeyName(0, "bb_home_.png")
        Me.ImageList_Ontologies.Images.SetKeyName(1, "Types_Closed.png")
        Me.ImageList_Ontologies.Images.SetKeyName(2, "Types_Opened.png")
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_Mark, Me.ToolStripTextBox_Mark})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(311, 25)
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
        Me.ToolStripTextBox_Mark.Size = New System.Drawing.Size(250, 25)
        '
        'ContextMenuStrip_Ontologies
        '
        Me.ContextMenuStrip_Ontologies.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem})
        Me.ContextMenuStrip_Ontologies.Name = "ContextMenuStrip_Ontologies"
        Me.ContextMenuStrip_Ontologies.Size = New System.Drawing.Size(109, 26)
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.NewToolStripMenuItem.Text = "x_New"
        '
        'UserControl_OntologyTree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_OntologyTree"
        Me.Size = New System.Drawing.Size(495, 463)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ContextMenuStrip_Ontologies.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_CountLbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Count As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TreeView_Ontologies As System.Windows.Forms.TreeView
    Friend WithEvents ImageList_Ontologies As System.Windows.Forms.ImageList
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_Mark As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox_Mark As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ContextMenuStrip_Ontologies As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
