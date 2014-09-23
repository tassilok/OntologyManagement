<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_AdvancedFilter
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_AdvancedFilter))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.Button_RemoveRelationType = New System.Windows.Forms.Button()
        Me.ImageList_Main = New System.Windows.Forms.ImageList(Me.components)
        Me.TextBox_RelationType = New System.Windows.Forms.TextBox()
        Me.Label_RelType = New System.Windows.Forms.Label()
        Me.Button_RemoveClass = New System.Windows.Forms.Button()
        Me.TextBox_Class = New System.Windows.Forms.TextBox()
        Me.Label_Class = New System.Windows.Forms.Label()
        Me.Button_RemoveObject = New System.Windows.Forms.Button()
        Me.TextBox_Objects = New System.Windows.Forms.TextBox()
        Me.Label_Object = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_AddRelations = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Null = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Button_RemoveRelationType)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TextBox_RelationType)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Label_RelType)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Button_RemoveClass)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TextBox_Class)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Label_Class)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Button_RemoveObject)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TextBox_Objects)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Label_Object)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(520, 502)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(520, 527)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'Button_RemoveRelationType
        '
        Me.Button_RemoveRelationType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_RemoveRelationType.Enabled = False
        Me.Button_RemoveRelationType.ImageIndex = 0
        Me.Button_RemoveRelationType.ImageList = Me.ImageList_Main
        Me.Button_RemoveRelationType.Location = New System.Drawing.Point(490, 46)
        Me.Button_RemoveRelationType.Name = "Button_RemoveRelationType"
        Me.Button_RemoveRelationType.Size = New System.Drawing.Size(25, 23)
        Me.Button_RemoveRelationType.TabIndex = 8
        Me.Button_RemoveRelationType.UseVisualStyleBackColor = True
        '
        'ImageList_Main
        '
        Me.ImageList_Main.ImageStream = CType(resources.GetObject("ImageList_Main.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_Main.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_Main.Images.SetKeyName(0, "b_minus.png")
        Me.ImageList_Main.Images.SetKeyName(1, "b_plus.png")
        '
        'TextBox_RelationType
        '
        Me.TextBox_RelationType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_RelationType.Location = New System.Drawing.Point(94, 48)
        Me.TextBox_RelationType.Name = "TextBox_RelationType"
        Me.TextBox_RelationType.ReadOnly = True
        Me.TextBox_RelationType.Size = New System.Drawing.Size(392, 20)
        Me.TextBox_RelationType.TabIndex = 7
        '
        'Label_RelType
        '
        Me.Label_RelType.AutoSize = True
        Me.Label_RelType.Location = New System.Drawing.Point(4, 51)
        Me.Label_RelType.Name = "Label_RelType"
        Me.Label_RelType.Size = New System.Drawing.Size(84, 13)
        Me.Label_RelType.TabIndex = 6
        Me.Label_RelType.Text = "x_RelationType:"
        '
        'Button_RemoveClass
        '
        Me.Button_RemoveClass.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_RemoveClass.Enabled = False
        Me.Button_RemoveClass.ImageIndex = 0
        Me.Button_RemoveClass.ImageList = Me.ImageList_Main
        Me.Button_RemoveClass.Location = New System.Drawing.Point(490, 24)
        Me.Button_RemoveClass.Name = "Button_RemoveClass"
        Me.Button_RemoveClass.Size = New System.Drawing.Size(25, 23)
        Me.Button_RemoveClass.TabIndex = 5
        Me.Button_RemoveClass.UseVisualStyleBackColor = True
        '
        'TextBox_Class
        '
        Me.TextBox_Class.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Class.Location = New System.Drawing.Point(94, 26)
        Me.TextBox_Class.Name = "TextBox_Class"
        Me.TextBox_Class.ReadOnly = True
        Me.TextBox_Class.Size = New System.Drawing.Size(392, 20)
        Me.TextBox_Class.TabIndex = 4
        '
        'Label_Class
        '
        Me.Label_Class.AutoSize = True
        Me.Label_Class.Location = New System.Drawing.Point(4, 29)
        Me.Label_Class.Name = "Label_Class"
        Me.Label_Class.Size = New System.Drawing.Size(46, 13)
        Me.Label_Class.TabIndex = 3
        Me.Label_Class.Text = "x_Class:"
        '
        'Button_RemoveObject
        '
        Me.Button_RemoveObject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_RemoveObject.Enabled = False
        Me.Button_RemoveObject.ImageIndex = 0
        Me.Button_RemoveObject.ImageList = Me.ImageList_Main
        Me.Button_RemoveObject.Location = New System.Drawing.Point(490, 2)
        Me.Button_RemoveObject.Name = "Button_RemoveObject"
        Me.Button_RemoveObject.Size = New System.Drawing.Size(25, 23)
        Me.Button_RemoveObject.TabIndex = 2
        Me.Button_RemoveObject.UseVisualStyleBackColor = True
        '
        'TextBox_Objects
        '
        Me.TextBox_Objects.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Objects.Location = New System.Drawing.Point(94, 4)
        Me.TextBox_Objects.Name = "TextBox_Objects"
        Me.TextBox_Objects.ReadOnly = True
        Me.TextBox_Objects.Size = New System.Drawing.Size(392, 20)
        Me.TextBox_Objects.TabIndex = 1
        '
        'Label_Object
        '
        Me.Label_Object.AutoSize = True
        Me.Label_Object.Location = New System.Drawing.Point(4, 7)
        Me.Label_Object.Name = "Label_Object"
        Me.Label_Object.Size = New System.Drawing.Size(52, 13)
        Me.Label_Object.TabIndex = 0
        Me.Label_Object.Text = "x_Object:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_AddRelations, Me.ToolStripButton_Null})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(183, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripButton_AddRelations
        '
        Me.ToolStripButton_AddRelations.Image = Global.Ontology_Module.My.Resources.Resources.b_plus
        Me.ToolStripButton_AddRelations.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_AddRelations.Name = "ToolStripButton_AddRelations"
        Me.ToolStripButton_AddRelations.Size = New System.Drawing.Size(105, 22)
        Me.ToolStripButton_AddRelations.Text = "x_Add Relation"
        '
        'ToolStripButton_Null
        '
        Me.ToolStripButton_Null.CheckOnClick = True
        Me.ToolStripButton_Null.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Null.Image = CType(resources.GetObject("ToolStripButton_Null.Image"), System.Drawing.Image)
        Me.ToolStripButton_Null.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Null.Name = "ToolStripButton_Null"
        Me.ToolStripButton_Null.Size = New System.Drawing.Size(66, 22)
        Me.ToolStripButton_Null.Text = "x_NoItems"
        '
        'UserControl_AdvancedFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_AdvancedFilter"
        Me.Size = New System.Drawing.Size(520, 527)
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(false)
        Me.ToolStripContainer1.ContentPanel.PerformLayout
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(false)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout
        Me.ToolStripContainer1.ResumeLayout(false)
        Me.ToolStripContainer1.PerformLayout
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents TextBox_Objects As System.Windows.Forms.TextBox
    Friend WithEvents Label_Object As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_AddRelations As System.Windows.Forms.ToolStripButton
    Friend WithEvents Button_RemoveObject As System.Windows.Forms.Button
    Friend WithEvents ImageList_Main As System.Windows.Forms.ImageList
    Friend WithEvents TextBox_Class As System.Windows.Forms.TextBox
    Friend WithEvents Label_Class As System.Windows.Forms.Label
    Friend WithEvents Button_RemoveRelationType As System.Windows.Forms.Button
    Friend WithEvents TextBox_RelationType As System.Windows.Forms.TextBox
    Friend WithEvents Label_RelType As System.Windows.Forms.Label
    Friend WithEvents Button_RemoveClass As System.Windows.Forms.Button
    Friend WithEvents ToolStripButton_Null As System.Windows.Forms.ToolStripButton

End Class
