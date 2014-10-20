<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_GraphFilter
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
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_AddItem = New System.Windows.Forms.ToolStripButton()
        Me.DataGridView_Filter = New System.Windows.Forms.DataGridView()
        Me.ToolStripButton_RemoveItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView_Filter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DataGridView_Filter)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(485, 416)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(485, 466)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_AddItem, Me.ToolStripButton_RemoveItem})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(58, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripButton_AddItem
        '
        Me.ToolStripButton_AddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_AddItem.Image = Global.Ontology_Module.My.Resources.Resources.b_plus
        Me.ToolStripButton_AddItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_AddItem.Name = "ToolStripButton_AddItem"
        Me.ToolStripButton_AddItem.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_AddItem.Text = "ToolStripButton1"
        '
        'DataGridView_Filter
        '
        Me.DataGridView_Filter.AllowUserToAddRows = False
        Me.DataGridView_Filter.AllowUserToDeleteRows = False
        Me.DataGridView_Filter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Filter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_Filter.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_Filter.Name = "DataGridView_Filter"
        Me.DataGridView_Filter.ReadOnly = True
        Me.DataGridView_Filter.Size = New System.Drawing.Size(485, 416)
        Me.DataGridView_Filter.TabIndex = 0
        '
        'ToolStripButton_RemoveItem
        '
        Me.ToolStripButton_RemoveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_RemoveItem.Image = Global.Ontology_Module.My.Resources.Resources.b_minus
        Me.ToolStripButton_RemoveItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_RemoveItem.Name = "ToolStripButton_RemoveItem"
        Me.ToolStripButton_RemoveItem.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_RemoveItem.Text = "ToolStripButton1"
        '
        'UserControl_GraphFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_GraphFilter"
        Me.Size = New System.Drawing.Size(485, 466)
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView_Filter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents DataGridView_Filter As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_AddItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_RemoveItem As System.Windows.Forms.ToolStripButton

End Class
