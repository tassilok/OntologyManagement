﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_MediaItemList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_MediaItemList))
        Me.Timer_MediaItems = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_CountLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Count = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripProgressBar_MediaItem = New System.Windows.Forms.ToolStripProgressBar()
        Me.DataGridView_MediaItems = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip_Items = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RelateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeOrderIDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IncreasingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DecreasingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToSyncToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenFileDialog_MediaItem = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog_Save = New System.Windows.Forms.FolderBrowserDialog()
        Me.ToolStripButton_Add = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Replace = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Remove = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Relate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Meta = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Play = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Bookmarks = New System.Windows.Forms.ToolStripButton()
        Me.BindingSource_MediaItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStripLabel_MediaItems = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.DataGridView_MediaItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip_Items.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.BindingSource_MediaItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer_MediaItems
        '
        Me.Timer_MediaItems.Interval = 300
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.ToolStrip2)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DataGridView_MediaItems)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(766, 426)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(766, 476)
        Me.ToolStripContainer1.TabIndex = 1
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_CountLBL, Me.ToolStripLabel_Count, Me.ToolStripSeparator2, Me.ToolStripProgressBar_MediaItem})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(186, 25)
        Me.ToolStrip2.TabIndex = 0
        '
        'ToolStripLabel_CountLBL
        '
        Me.ToolStripLabel_CountLBL.Name = "ToolStripLabel_CountLBL"
        Me.ToolStripLabel_CountLBL.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripLabel_CountLBL.Text = "x_Count:"
        '
        'ToolStripLabel_Count
        '
        Me.ToolStripLabel_Count.Name = "ToolStripLabel_Count"
        Me.ToolStripLabel_Count.Size = New System.Drawing.Size(13, 22)
        Me.ToolStripLabel_Count.Text = "0"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripProgressBar_MediaItem
        '
        Me.ToolStripProgressBar_MediaItem.Name = "ToolStripProgressBar_MediaItem"
        Me.ToolStripProgressBar_MediaItem.Size = New System.Drawing.Size(100, 22)
        '
        'DataGridView_MediaItems
        '
        Me.DataGridView_MediaItems.AllowUserToAddRows = False
        Me.DataGridView_MediaItems.AllowUserToDeleteRows = False
        Me.DataGridView_MediaItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_MediaItems.ContextMenuStrip = Me.ContextMenuStrip_Items
        Me.DataGridView_MediaItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_MediaItems.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_MediaItems.Name = "DataGridView_MediaItems"
        Me.DataGridView_MediaItems.ReadOnly = True
        Me.DataGridView_MediaItems.Size = New System.Drawing.Size(766, 426)
        Me.DataGridView_MediaItems.TabIndex = 0
        '
        'ContextMenuStrip_Items
        '
        Me.ContextMenuStrip_Items.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RelateToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ChangeOrderIDToolStripMenuItem, Me.AddToSyncToolStripMenuItem})
        Me.ContextMenuStrip_Items.Name = "ContextMenuStrip_Items"
        Me.ContextMenuStrip_Items.Size = New System.Drawing.Size(175, 92)
        '
        'RelateToolStripMenuItem
        '
        Me.RelateToolStripMenuItem.Name = "RelateToolStripMenuItem"
        Me.RelateToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.RelateToolStripMenuItem.Text = "x_Relate"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.SaveToolStripMenuItem.Text = "x_Save"
        '
        'ChangeOrderIDToolStripMenuItem
        '
        Me.ChangeOrderIDToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IncreasingToolStripMenuItem, Me.DecreasingToolStripMenuItem})
        Me.ChangeOrderIDToolStripMenuItem.Enabled = False
        Me.ChangeOrderIDToolStripMenuItem.Name = "ChangeOrderIDToolStripMenuItem"
        Me.ChangeOrderIDToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.ChangeOrderIDToolStripMenuItem.Text = "x_Change Order-ID"
        '
        'IncreasingToolStripMenuItem
        '
        Me.IncreasingToolStripMenuItem.Name = "IncreasingToolStripMenuItem"
        Me.IncreasingToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.IncreasingToolStripMenuItem.Text = "x_Increasing"
        '
        'DecreasingToolStripMenuItem
        '
        Me.DecreasingToolStripMenuItem.Name = "DecreasingToolStripMenuItem"
        Me.DecreasingToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.DecreasingToolStripMenuItem.Text = "x_Decreasing"
        '
        'AddToSyncToolStripMenuItem
        '
        Me.AddToSyncToolStripMenuItem.Name = "AddToSyncToolStripMenuItem"
        Me.AddToSyncToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.AddToSyncToolStripMenuItem.Text = "x_Add To Sync"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_MediaItems, Me.ToolStripButton_Add, Me.ToolStripButton_Replace, Me.ToolStripButton_Remove, Me.ToolStripSeparator1, Me.ToolStripButton_Relate, Me.ToolStripButton_Meta, Me.ToolStripSeparator3, Me.ToolStripButton_Play, Me.ToolStripSeparator4, Me.ToolStripButton_Bookmarks})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(519, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'OpenFileDialog_MediaItem
        '
        Me.OpenFileDialog_MediaItem.FileName = "OpenFileDialog1"
        '
        'ToolStripButton_Add
        '
        Me.ToolStripButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Add.Image = Global.Media_Viewer_Module.My.Resources.Resources.b_plus_with_Folder
        Me.ToolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Add.Name = "ToolStripButton_Add"
        Me.ToolStripButton_Add.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Add.Text = "ToolStripButton1"
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
        'ToolStripButton_Remove
        '
        Me.ToolStripButton_Remove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Remove.Image = Global.Media_Viewer_Module.My.Resources.Resources.tasto_8_architetto_franc_01
        Me.ToolStripButton_Remove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Remove.Name = "ToolStripButton_Remove"
        Me.ToolStripButton_Remove.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Remove.Text = "ToolStripButton1"
        '
        'ToolStripButton_Relate
        '
        Me.ToolStripButton_Relate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Relate.Image = CType(resources.GetObject("ToolStripButton_Relate.Image"), System.Drawing.Image)
        Me.ToolStripButton_Relate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Relate.Name = "ToolStripButton_Relate"
        Me.ToolStripButton_Relate.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripButton_Relate.Text = "x_Relate"
        '
        'ToolStripButton_Meta
        '
        Me.ToolStripButton_Meta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Meta.Image = CType(resources.GetObject("ToolStripButton_Meta.Image"), System.Drawing.Image)
        Me.ToolStripButton_Meta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Meta.Name = "ToolStripButton_Meta"
        Me.ToolStripButton_Meta.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripButton_Meta.Text = "x_Get Meta"
        '
        'ToolStripButton_Play
        '
        Me.ToolStripButton_Play.CheckOnClick = True
        Me.ToolStripButton_Play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Play.Image = Global.Media_Viewer_Module.My.Resources.Resources._next
        Me.ToolStripButton_Play.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Play.Name = "ToolStripButton_Play"
        Me.ToolStripButton_Play.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Play.Text = "ToolStripButton1"
        '
        'ToolStripButton_Bookmarks
        '
        Me.ToolStripButton_Bookmarks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Bookmarks.Image = CType(resources.GetObject("ToolStripButton_Bookmarks.Image"), System.Drawing.Image)
        Me.ToolStripButton_Bookmarks.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Bookmarks.Name = "ToolStripButton_Bookmarks"
        Me.ToolStripButton_Bookmarks.Size = New System.Drawing.Size(123, 22)
        Me.ToolStripButton_Bookmarks.Text = "x_Bookmarks/Ranges"
        '
        'ToolStripLabel_MediaItems
        '
        Me.ToolStripLabel_MediaItems.Name = "ToolStripLabel_MediaItems"
        Me.ToolStripLabel_MediaItems.Size = New System.Drawing.Size(82, 22)
        Me.ToolStripLabel_MediaItems.Text = "x_MediaItems:"
        '
        'UserControl_MediaItemList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_MediaItemList"
        Me.Size = New System.Drawing.Size(766, 476)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.DataGridView_MediaItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip_Items.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.BindingSource_MediaItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BindingSource_MediaItems As System.Windows.Forms.BindingSource
    Friend WithEvents Timer_MediaItems As System.Windows.Forms.Timer
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_CountLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Count As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripProgressBar_MediaItem As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Add As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Remove As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_Meta As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_Bookmarks As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView_MediaItems As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripButton_Replace As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenFileDialog_MediaItem As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStripButton_Play As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FolderBrowserDialog_Save As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ContextMenuStrip_Items As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RelateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeOrderIDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IncreasingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DecreasingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToSyncToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton_Relate As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel_MediaItems As System.Windows.Forms.ToolStripLabel

End Class
