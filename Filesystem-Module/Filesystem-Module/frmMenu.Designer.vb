﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton()
        Me.DataGridView_FileSystemItems = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip_FileSystemObjects = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DownloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FolderBrowserDialog_Download = New System.Windows.Forms.FolderBrowserDialog()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlobToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog_Add = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView_FileSystemItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip_FileSystemObjects.SuspendLayout()
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DataGridView_FileSystemItems)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(609, 365)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(609, 415)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
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
        'DataGridView_FileSystemItems
        '
        Me.DataGridView_FileSystemItems.AllowUserToAddRows = False
        Me.DataGridView_FileSystemItems.AllowUserToDeleteRows = False
        Me.DataGridView_FileSystemItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_FileSystemItems.ContextMenuStrip = Me.ContextMenuStrip_FileSystemObjects
        Me.DataGridView_FileSystemItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_FileSystemItems.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_FileSystemItems.Name = "DataGridView_FileSystemItems"
        Me.DataGridView_FileSystemItems.ReadOnly = True
        Me.DataGridView_FileSystemItems.Size = New System.Drawing.Size(609, 365)
        Me.DataGridView_FileSystemItems.TabIndex = 1
        '
        'ContextMenuStrip_FileSystemObjects
        '
        Me.ContextMenuStrip_FileSystemObjects.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DownloadToolStripMenuItem, Me.StartToolStripMenuItem, Me.AddToolStripMenuItem})
        Me.ContextMenuStrip_FileSystemObjects.Name = "ContextMenuStrip_FileSystemObjects"
        Me.ContextMenuStrip_FileSystemObjects.Size = New System.Drawing.Size(139, 70)
        '
        'DownloadToolStripMenuItem
        '
        Me.DownloadToolStripMenuItem.Name = "DownloadToolStripMenuItem"
        Me.DownloadToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.DownloadToolStripMenuItem.Text = "x_Download"
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.StartToolStripMenuItem.Text = "x_Start"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BlobToolStripMenuItem})
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.AddToolStripMenuItem.Text = "x_Add"
        '
        'BlobToolStripMenuItem
        '
        Me.BlobToolStripMenuItem.Checked = True
        Me.BlobToolStripMenuItem.CheckOnClick = True
        Me.BlobToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.BlobToolStripMenuItem.Name = "BlobToolStripMenuItem"
        Me.BlobToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BlobToolStripMenuItem.Text = "x_Blob"
        '
        'OpenFileDialog_Add
        '
        Me.OpenFileDialog_Add.FileName = "OpenFileDialog1"
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 415)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "frmMenu"
        Me.Text = "frmMenu"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView_FileSystemItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip_FileSystemObjects.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView_FileSystemItems As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip_FileSystemObjects As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DownloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FolderBrowserDialog_Download As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BlobToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog_Add As System.Windows.Forms.OpenFileDialog
End Class
