<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttributeTypeOrRelationType
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAttributeTypeOrRelationType))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label_AttributeTypes = New System.Windows.Forms.Label()
        Me.Label_RelationTypes = New System.Windows.Forms.Label()
        Me.Panel_AttributeTypes = New System.Windows.Forms.Panel()
        Me.Panel_RelationTypes = New System.Windows.Forms.Panel()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout
        Me.ToolStripContainer1.ContentPanel.SuspendLayout
        Me.ToolStripContainer1.SuspendLayout
        Me.ToolStrip1.SuspendLayout
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.SplitContainer1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(768, 528)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(768, 553)
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
        Me.ToolStripButton_Close.Image = CType(resources.GetObject("ToolStripButton_Close.Image"),System.Drawing.Image)
        Me.ToolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Close.Name = "ToolStripButton_Close"
        Me.ToolStripButton_Close.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripButton_Close.Text = "x_Close"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel_AttributeTypes)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label_AttributeTypes)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel_RelationTypes)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label_RelationTypes)
        Me.SplitContainer1.Size = New System.Drawing.Size(768, 528)
        Me.SplitContainer1.SplitterDistance = 382
        Me.SplitContainer1.TabIndex = 0
        '
        'Label_AttributeTypes
        '
        Me.Label_AttributeTypes.AutoSize = true
        Me.Label_AttributeTypes.Location = New System.Drawing.Point(4, 4)
        Me.Label_AttributeTypes.Name = "Label_AttributeTypes"
        Me.Label_AttributeTypes.Size = New System.Drawing.Size(86, 13)
        Me.Label_AttributeTypes.TabIndex = 0
        Me.Label_AttributeTypes.Text = "x_AttributeTypes"
        '
        'Label_RelationTypes
        '
        Me.Label_RelationTypes.AutoSize = true
        Me.Label_RelationTypes.Location = New System.Drawing.Point(4, 2)
        Me.Label_RelationTypes.Name = "Label_RelationTypes"
        Me.Label_RelationTypes.Size = New System.Drawing.Size(86, 13)
        Me.Label_RelationTypes.TabIndex = 0
        Me.Label_RelationTypes.Text = "x_RelationTypes"
        '
        'Panel_AttributeTypes
        '
        Me.Panel_AttributeTypes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Panel_AttributeTypes.Location = New System.Drawing.Point(4, 21)
        Me.Panel_AttributeTypes.Name = "Panel_AttributeTypes"
        Me.Panel_AttributeTypes.Size = New System.Drawing.Size(371, 500)
        Me.Panel_AttributeTypes.TabIndex = 1
        '
        'Panel_RelationTypes
        '
        Me.Panel_RelationTypes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Panel_RelationTypes.Location = New System.Drawing.Point(3, 21)
        Me.Panel_RelationTypes.Name = "Panel_RelationTypes"
        Me.Panel_RelationTypes.Size = New System.Drawing.Size(371, 500)
        Me.Panel_RelationTypes.TabIndex = 2
        '
        'frmAttributeTypeOrRelationType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 553)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "frmAttributeTypeOrRelationType"
        Me.Text = "x_AttributeType or RelationType"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(false)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(false)
        Me.ToolStripContainer1.ResumeLayout(false)
        Me.ToolStripContainer1.PerformLayout
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel1.PerformLayout
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        Me.SplitContainer1.Panel2.PerformLayout
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel_AttributeTypes As System.Windows.Forms.Panel
    Friend WithEvents Label_AttributeTypes As System.Windows.Forms.Label
    Friend WithEvents Panel_RelationTypes As System.Windows.Forms.Panel
    Friend WithEvents Label_RelationTypes As System.Windows.Forms.Label
End Class
