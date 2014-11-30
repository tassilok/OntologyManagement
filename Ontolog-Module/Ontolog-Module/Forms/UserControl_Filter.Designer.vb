<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_Filter
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
        Me.GroupBox_FilterDr = New System.Windows.Forms.GroupBox()
        Me.RadioButton_NoRel = New System.Windows.Forms.RadioButton()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.RadioButton_RightLeft = New System.Windows.Forms.RadioButton()
        Me.RadioButton_LeftRight = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button_SaveFilter = New System.Windows.Forms.Button()
        Me.ComboBox_Filter = New System.Windows.Forms.ComboBox()
        Me.Label_FilterStd = New System.Windows.Forms.Label()
        Me.Button_Filter = New System.Windows.Forms.Button()
        Me.Button_GetData = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TextBox_NameType = New System.Windows.Forms.TextBox()
        Me.TextBox_NameToken = New System.Windows.Forms.TextBox()
        Me.Label_ParentLeftLBL = New System.Windows.Forms.Label()
        Me.Label_LeftLBL = New System.Windows.Forms.Label()
        Me.TextBox_RelationType = New System.Windows.Forms.TextBox()
        Me.Label_RelationLBL = New System.Windows.Forms.Label()
        Me.TextBox_NameTypeOther = New System.Windows.Forms.TextBox()
        Me.TextBox_NameTokenOther = New System.Windows.Forms.TextBox()
        Me.Label_NameTypeOtherLBL = New System.Windows.Forms.Label()
        Me.Label_OtherLBL = New System.Windows.Forms.Label()
        Me.GroupBox_FilterDr.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_FilterDr
        '
        Me.GroupBox_FilterDr.Controls.Add(Me.RadioButton_NoRel)
        Me.GroupBox_FilterDr.Controls.Add(Me.CheckBox1)
        Me.GroupBox_FilterDr.Controls.Add(Me.RadioButton_RightLeft)
        Me.GroupBox_FilterDr.Controls.Add(Me.RadioButton_LeftRight)
        Me.GroupBox_FilterDr.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox_FilterDr.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox_FilterDr.Name = "GroupBox_FilterDr"
        Me.GroupBox_FilterDr.Size = New System.Drawing.Size(92, 130)
        Me.GroupBox_FilterDr.TabIndex = 2
        Me.GroupBox_FilterDr.TabStop = False
        Me.GroupBox_FilterDr.Text = "Filter-Config"
        '
        'RadioButton_NoRel
        '
        Me.RadioButton_NoRel.AutoSize = True
        Me.RadioButton_NoRel.Checked = True
        Me.RadioButton_NoRel.Location = New System.Drawing.Point(7, 20)
        Me.RadioButton_NoRel.Name = "RadioButton_NoRel"
        Me.RadioButton_NoRel.Size = New System.Drawing.Size(58, 17)
        Me.RadioButton_NoRel.TabIndex = 3
        Me.RadioButton_NoRel.TabStop = True
        Me.RadioButton_NoRel.Text = "No Rel"
        Me.RadioButton_NoRel.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(7, 89)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(44, 17)
        Me.CheckBox1.TabIndex = 2
        Me.CheckBox1.Text = "Null"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'RadioButton_RightLeft
        '
        Me.RadioButton_RightLeft.AutoSize = True
        Me.RadioButton_RightLeft.Location = New System.Drawing.Point(7, 66)
        Me.RadioButton_RightLeft.Name = "RadioButton_RightLeft"
        Me.RadioButton_RightLeft.Size = New System.Drawing.Size(77, 17)
        Me.RadioButton_RightLeft.TabIndex = 1
        Me.RadioButton_RightLeft.Text = "Right->Left"
        Me.RadioButton_RightLeft.UseVisualStyleBackColor = True
        '
        'RadioButton_LeftRight
        '
        Me.RadioButton_LeftRight.AutoSize = True
        Me.RadioButton_LeftRight.Location = New System.Drawing.Point(7, 43)
        Me.RadioButton_LeftRight.Name = "RadioButton_LeftRight"
        Me.RadioButton_LeftRight.Size = New System.Drawing.Size(77, 17)
        Me.RadioButton_LeftRight.TabIndex = 0
        Me.RadioButton_LeftRight.Text = "Left->Right"
        Me.RadioButton_LeftRight.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button_SaveFilter)
        Me.Panel1.Controls.Add(Me.ComboBox_Filter)
        Me.Panel1.Controls.Add(Me.Label_FilterStd)
        Me.Panel1.Controls.Add(Me.Button_Filter)
        Me.Panel1.Controls.Add(Me.Button_GetData)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(897, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 130)
        Me.Panel1.TabIndex = 4
        '
        'Button_SaveFilter
        '
        Me.Button_SaveFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_SaveFilter.Location = New System.Drawing.Point(102, 43)
        Me.Button_SaveFilter.Name = "Button_SaveFilter"
        Me.Button_SaveFilter.Size = New System.Drawing.Size(95, 23)
        Me.Button_SaveFilter.TabIndex = 11
        Me.Button_SaveFilter.Text = "Filter speichern"
        Me.Button_SaveFilter.UseVisualStyleBackColor = True
        '
        'ComboBox_Filter
        '
        Me.ComboBox_Filter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_Filter.FormattingEnabled = True
        Me.ComboBox_Filter.Location = New System.Drawing.Point(4, 20)
        Me.ComboBox_Filter.Name = "ComboBox_Filter"
        Me.ComboBox_Filter.Size = New System.Drawing.Size(193, 21)
        Me.ComboBox_Filter.TabIndex = 10
        '
        'Label_FilterStd
        '
        Me.Label_FilterStd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_FilterStd.AutoSize = True
        Me.Label_FilterStd.Location = New System.Drawing.Point(1, 3)
        Me.Label_FilterStd.Name = "Label_FilterStd"
        Me.Label_FilterStd.Size = New System.Drawing.Size(96, 13)
        Me.Label_FilterStd.TabIndex = 9
        Me.Label_FilterStd.Text = "Filter (gespeichert):"
        '
        'Button_Filter
        '
        Me.Button_Filter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Filter.Location = New System.Drawing.Point(101, 104)
        Me.Button_Filter.Name = "Button_Filter"
        Me.Button_Filter.Size = New System.Drawing.Size(95, 23)
        Me.Button_Filter.TabIndex = 8
        Me.Button_Filter.Text = "Filter"
        Me.Button_Filter.UseVisualStyleBackColor = True
        '
        'Button_GetData
        '
        Me.Button_GetData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button_GetData.Location = New System.Drawing.Point(3, 104)
        Me.Button_GetData.Name = "Button_GetData"
        Me.Button_GetData.Size = New System.Drawing.Size(95, 23)
        Me.Button_GetData.TabIndex = 7
        Me.Button_GetData.Text = "Eintrag holen"
        Me.Button_GetData.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(98, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox_NameType)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox_NameToken)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label_ParentLeftLBL)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label_LeftLBL)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox_RelationType)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label_RelationLBL)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox_NameTypeOther)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox_NameTokenOther)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label_NameTypeOtherLBL)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label_OtherLBL)
        Me.SplitContainer1.Size = New System.Drawing.Size(797, 237)
        Me.SplitContainer1.SplitterDistance = 397
        Me.SplitContainer1.TabIndex = 6
        '
        'TextBox_NameType
        '
        Me.TextBox_NameType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_NameType.Location = New System.Drawing.Point(102, 32)
        Me.TextBox_NameType.Name = "TextBox_NameType"
        Me.TextBox_NameType.Size = New System.Drawing.Size(288, 20)
        Me.TextBox_NameType.TabIndex = 25
        '
        'TextBox_NameToken
        '
        Me.TextBox_NameToken.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_NameToken.Location = New System.Drawing.Point(102, 10)
        Me.TextBox_NameToken.Name = "TextBox_NameToken"
        Me.TextBox_NameToken.Size = New System.Drawing.Size(288, 20)
        Me.TextBox_NameToken.TabIndex = 24
        '
        'Label_ParentLeftLBL
        '
        Me.Label_ParentLeftLBL.AutoSize = True
        Me.Label_ParentLeftLBL.Location = New System.Drawing.Point(3, 35)
        Me.Label_ParentLeftLBL.Name = "Label_ParentLeftLBL"
        Me.Label_ParentLeftLBL.Size = New System.Drawing.Size(79, 13)
        Me.Label_ParentLeftLBL.TabIndex = 23
        Me.Label_ParentLeftLBL.Text = "x_Left (Parent):"
        '
        'Label_LeftLBL
        '
        Me.Label_LeftLBL.AutoSize = True
        Me.Label_LeftLBL.Location = New System.Drawing.Point(4, 13)
        Me.Label_LeftLBL.Name = "Label_LeftLBL"
        Me.Label_LeftLBL.Size = New System.Drawing.Size(81, 13)
        Me.Label_LeftLBL.TabIndex = 22
        Me.Label_LeftLBL.Text = "x_Left / Object:"
        '
        'TextBox_RelationType
        '
        Me.TextBox_RelationType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_RelationType.Location = New System.Drawing.Point(102, 54)
        Me.TextBox_RelationType.Name = "TextBox_RelationType"
        Me.TextBox_RelationType.Size = New System.Drawing.Size(287, 20)
        Me.TextBox_RelationType.TabIndex = 31
        '
        'Label_RelationLBL
        '
        Me.Label_RelationLBL.AutoSize = True
        Me.Label_RelationLBL.Location = New System.Drawing.Point(9, 56)
        Me.Label_RelationLBL.Name = "Label_RelationLBL"
        Me.Label_RelationLBL.Size = New System.Drawing.Size(84, 13)
        Me.Label_RelationLBL.TabIndex = 30
        Me.Label_RelationLBL.Text = "x_RelationType:"
        '
        'TextBox_NameTypeOther
        '
        Me.TextBox_NameTypeOther.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_NameTypeOther.Location = New System.Drawing.Point(102, 32)
        Me.TextBox_NameTypeOther.Name = "TextBox_NameTypeOther"
        Me.TextBox_NameTypeOther.Size = New System.Drawing.Size(287, 20)
        Me.TextBox_NameTypeOther.TabIndex = 29
        '
        'TextBox_NameTokenOther
        '
        Me.TextBox_NameTokenOther.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_NameTokenOther.Location = New System.Drawing.Point(102, 10)
        Me.TextBox_NameTokenOther.Name = "TextBox_NameTokenOther"
        Me.TextBox_NameTokenOther.Size = New System.Drawing.Size(287, 20)
        Me.TextBox_NameTokenOther.TabIndex = 28
        '
        'Label_NameTypeOtherLBL
        '
        Me.Label_NameTypeOtherLBL.AutoSize = True
        Me.Label_NameTypeOtherLBL.Location = New System.Drawing.Point(9, 35)
        Me.Label_NameTypeOtherLBL.Name = "Label_NameTypeOtherLBL"
        Me.Label_NameTypeOtherLBL.Size = New System.Drawing.Size(87, 13)
        Me.Label_NameTypeOtherLBL.TabIndex = 27
        Me.Label_NameTypeOtherLBL.Text = "x_Other (Parent):"
        '
        'Label_OtherLBL
        '
        Me.Label_OtherLBL.AutoSize = True
        Me.Label_OtherLBL.Location = New System.Drawing.Point(9, 13)
        Me.Label_OtherLBL.Name = "Label_OtherLBL"
        Me.Label_OtherLBL.Size = New System.Drawing.Size(47, 13)
        Me.Label_OtherLBL.TabIndex = 26
        Me.Label_OtherLBL.Text = "x_Other:"
        '
        'UserControl_Filter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox_FilterDr)
        Me.Name = "UserControl_Filter"
        Me.Size = New System.Drawing.Size(1097, 130)
        Me.GroupBox_FilterDr.ResumeLayout(False)
        Me.GroupBox_FilterDr.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox_FilterDr As System.Windows.Forms.GroupBox
    Friend WithEvents Button_SaveFilter As System.Windows.Forms.Button
    Friend WithEvents ComboBox_Filter As System.Windows.Forms.ComboBox
    Friend WithEvents Label_FilterStd As System.Windows.Forms.Label
    Friend WithEvents Button_Filter As System.Windows.Forms.Button
    Friend WithEvents Button_GetData As System.Windows.Forms.Button
    Friend WithEvents RadioButton_RightLeft As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton_LeftRight As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TextBox_NameType As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_NameToken As System.Windows.Forms.TextBox
    Friend WithEvents Label_ParentLeftLBL As System.Windows.Forms.Label
    Friend WithEvents Label_LeftLBL As System.Windows.Forms.Label
    Friend WithEvents TextBox_NameTypeOther As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_NameTokenOther As System.Windows.Forms.TextBox
    Friend WithEvents Label_NameTypeOtherLBL As System.Windows.Forms.Label
    Friend WithEvents Label_OtherLBL As System.Windows.Forms.Label
    Friend WithEvents RadioButton_NoRel As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox_RelationType As System.Windows.Forms.TextBox
    Friend WithEvents Label_RelationLBL As System.Windows.Forms.Label

End Class
