﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_ObjectAtt
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
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_CountLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Count = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripProgressBar_ObjectAtt = New System.Windows.Forms.ToolStripProgressBar()
        Me.DataGridView_ObjectAtt = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip_Items = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyValueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_FilterLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Filter = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton_ClearFilter = New System.Windows.Forms.ToolStripButton()
        Me.BindingSource_ObjectAtt = New System.Windows.Forms.BindingSource(Me.components)
        Me.Timer_ObjectAtt = New System.Windows.Forms.Timer(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout
        Me.ToolStripContainer1.ContentPanel.SuspendLayout
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout
        Me.ToolStripContainer1.SuspendLayout
        Me.ToolStrip1.SuspendLayout
        CType(Me.DataGridView_ObjectAtt,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ContextMenuStrip_Items.SuspendLayout
        Me.ToolStrip2.SuspendLayout
        CType(Me.BindingSource_ObjectAtt,System.ComponentModel.ISupportInitialize).BeginInit
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DataGridView_ObjectAtt)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(521, 429)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(521, 479)
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_CountLBL, Me.ToolStripLabel_Count, Me.ToolStripSeparator1, Me.ToolStripProgressBar_ObjectAtt})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(186, 25)
        Me.ToolStrip1.TabIndex = 0
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripProgressBar_ObjectAtt
        '
        Me.ToolStripProgressBar_ObjectAtt.Name = "ToolStripProgressBar_ObjectAtt"
        Me.ToolStripProgressBar_ObjectAtt.Size = New System.Drawing.Size(100, 22)
        '
        'DataGridView_ObjectAtt
        '
        Me.DataGridView_ObjectAtt.AllowUserToAddRows = false
        Me.DataGridView_ObjectAtt.AllowUserToDeleteRows = false
        Me.DataGridView_ObjectAtt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_ObjectAtt.ContextMenuStrip = Me.ContextMenuStrip_Items
        Me.DataGridView_ObjectAtt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_ObjectAtt.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_ObjectAtt.Name = "DataGridView_ObjectAtt"
        Me.DataGridView_ObjectAtt.ReadOnly = true
        Me.DataGridView_ObjectAtt.Size = New System.Drawing.Size(521, 429)
        Me.DataGridView_ObjectAtt.TabIndex = 0
        '
        'ContextMenuStrip_Items
        '
        Me.ContextMenuStrip_Items.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyValueToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip_Items.Name = "ContextMenuStrip_Items"
        Me.ContextMenuStrip_Items.Size = New System.Drawing.Size(153, 70)
        '
        'CopyValueToolStripMenuItem
        '
        Me.CopyValueToolStripMenuItem.Name = "CopyValueToolStripMenuItem"
        Me.CopyValueToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CopyValueToolStripMenuItem.Text = "x_Copy Value"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_FilterLBL, Me.ToolStripLabel_Filter, Me.ToolStripButton_ClearFilter})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(93, 25)
        Me.ToolStrip2.TabIndex = 0
        '
        'ToolStripLabel_FilterLBL
        '
        Me.ToolStripLabel_FilterLBL.Name = "ToolStripLabel_FilterLBL"
        Me.ToolStripLabel_FilterLBL.Size = New System.Drawing.Size(46, 22)
        Me.ToolStripLabel_FilterLBL.Text = "x_Filter:"
        '
        'ToolStripLabel_Filter
        '
        Me.ToolStripLabel_Filter.Name = "ToolStripLabel_Filter"
        Me.ToolStripLabel_Filter.Size = New System.Drawing.Size(12, 22)
        Me.ToolStripLabel_Filter.Text = "-"
        '
        'ToolStripButton_ClearFilter
        '
        Me.ToolStripButton_ClearFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_ClearFilter.Image = Global.Ontology_Module.My.Resources.Resources.tasto_8_architetto_franc_01
        Me.ToolStripButton_ClearFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_ClearFilter.Name = "ToolStripButton_ClearFilter"
        Me.ToolStripButton_ClearFilter.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_ClearFilter.Text = "ToolStripButton1"
        '
        'Timer_ObjectAtt
        '
        Me.Timer_ObjectAtt.Interval = 300
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteToolStripMenuItem.Text = "x_Delete"
        '
        'UserControl_ObjectAtt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_ObjectAtt"
        Me.Size = New System.Drawing.Size(521, 479)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(false)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(false)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(false)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout
        Me.ToolStripContainer1.ResumeLayout(false)
        Me.ToolStripContainer1.PerformLayout
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        CType(Me.DataGridView_ObjectAtt,System.ComponentModel.ISupportInitialize).EndInit
        Me.ContextMenuStrip_Items.ResumeLayout(false)
        Me.ToolStrip2.ResumeLayout(false)
        Me.ToolStrip2.PerformLayout
        CType(Me.BindingSource_ObjectAtt,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_CountLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Count As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_FilterLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DataGridView_ObjectAtt As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripLabel_Filter As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton_ClearFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingSource_ObjectAtt As System.Windows.Forms.BindingSource
    Friend WithEvents Timer_ObjectAtt As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripProgressBar_ObjectAtt As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ContextMenuStrip_Items As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyValueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
