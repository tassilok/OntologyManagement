﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Name
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Name))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel_DatabaseLBL = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_Database = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_LengthLBL = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_Length = New System.Windows.Forms.ToolStripStatusLabel()
        Me.NumericUpDown_Additional = New System.Windows.Forms.NumericUpDown()
        Me.CheckBox_Additional = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_List = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button_OK = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label_Name = New System.Windows.Forms.Label()
        Me.TextBox_Name = New System.Windows.Forms.TextBox()
        Me.Label_GUID = New System.Windows.Forms.Label()
        Me.TextBox_GUID = New System.Windows.Forms.TextBox()
        Me.Button_NewGUID = New System.Windows.Forms.Button()
        Me.TextBox_Repeat = New System.Windows.Forms.TextBox()
        Me.Label_Repeat = New System.Windows.Forms.Label()
        Me.CheckBox_Apply = New System.Windows.Forms.CheckBox()
        Me.NumericUpDown_OrderID_Start = New System.Windows.Forms.NumericUpDown()
        Me.CheckBox_OrderID = New System.Windows.Forms.CheckBox()
        Me.SicheresPasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout
        CType(Me.NumericUpDown_Additional,System.ComponentModel.ISupportInitialize).BeginInit
        Me.MenuStrip1.SuspendLayout
        CType(Me.NumericUpDown_OrderID_Start,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel_DatabaseLBL, Me.ToolStripStatusLabel_Database, Me.ToolStripStatusLabel_LengthLBL, Me.ToolStripStatusLabel_Length})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 126)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(542, 24)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel_DatabaseLBL
        '
        Me.ToolStripStatusLabel_DatabaseLBL.Name = "ToolStripStatusLabel_DatabaseLBL"
        Me.ToolStripStatusLabel_DatabaseLBL.Size = New System.Drawing.Size(58, 19)
        Me.ToolStripStatusLabel_DatabaseLBL.Text = "Database:"
        '
        'ToolStripStatusLabel_Database
        '
        Me.ToolStripStatusLabel_Database.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)  _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom),System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel_Database.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.ToolStripStatusLabel_Database.Name = "ToolStripStatusLabel_Database"
        Me.ToolStripStatusLabel_Database.Size = New System.Drawing.Size(16, 19)
        Me.ToolStripStatusLabel_Database.Text = "-"
        '
        'ToolStripStatusLabel_LengthLBL
        '
        Me.ToolStripStatusLabel_LengthLBL.Name = "ToolStripStatusLabel_LengthLBL"
        Me.ToolStripStatusLabel_LengthLBL.Size = New System.Drawing.Size(57, 19)
        Me.ToolStripStatusLabel_LengthLBL.Text = "x_Length:"
        '
        'ToolStripStatusLabel_Length
        '
        Me.ToolStripStatusLabel_Length.Name = "ToolStripStatusLabel_Length"
        Me.ToolStripStatusLabel_Length.Size = New System.Drawing.Size(13, 19)
        Me.ToolStripStatusLabel_Length.Text = "0"
        '
        'NumericUpDown_Additional
        '
        Me.NumericUpDown_Additional.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_Additional.Location = New System.Drawing.Point(328, 129)
        Me.NumericUpDown_Additional.Name = "NumericUpDown_Additional"
        Me.NumericUpDown_Additional.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown_Additional.TabIndex = 1
        Me.NumericUpDown_Additional.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'CheckBox_Additional
        '
        Me.CheckBox_Additional.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.CheckBox_Additional.AutoSize = true
        Me.CheckBox_Additional.Location = New System.Drawing.Point(384, 132)
        Me.CheckBox_Additional.Name = "CheckBox_Additional"
        Me.CheckBox_Additional.Size = New System.Drawing.Size(83, 17)
        Me.CheckBox_Additional.TabIndex = 2
        Me.CheckBox_Additional.Text = "x_Additional"
        Me.CheckBox_Additional.UseVisualStyleBackColor = true
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(542, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_List, Me.SicheresPasswordToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.EditToolStripMenuItem.Text = "x_Edit"
        '
        'ToolStripMenuItem_List
        '
        Me.ToolStripMenuItem_List.Name = "ToolStripMenuItem_List"
        Me.ToolStripMenuItem_List.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem_List.Text = "x_List"
        '
        'Button_OK
        '
        Me.Button_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Button_OK.Location = New System.Drawing.Point(377, 95)
        Me.Button_OK.Name = "Button_OK"
        Me.Button_OK.Size = New System.Drawing.Size(75, 23)
        Me.Button_OK.TabIndex = 4
        Me.Button_OK.Text = "x_OK"
        Me.Button_OK.UseVisualStyleBackColor = true
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(458, 95)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "x_Cancel"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'Label_Name
        '
        Me.Label_Name.AutoSize = true
        Me.Label_Name.Location = New System.Drawing.Point(4, 61)
        Me.Label_Name.Name = "Label_Name"
        Me.Label_Name.Size = New System.Drawing.Size(49, 13)
        Me.Label_Name.TabIndex = 6
        Me.Label_Name.Text = "x_Name:"
        '
        'TextBox_Name
        '
        Me.TextBox_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.TextBox_Name.Location = New System.Drawing.Point(59, 58)
        Me.TextBox_Name.MaxLength = 255
        Me.TextBox_Name.Name = "TextBox_Name"
        Me.TextBox_Name.Size = New System.Drawing.Size(471, 20)
        Me.TextBox_Name.TabIndex = 7
        '
        'Label_GUID
        '
        Me.Label_GUID.AutoSize = true
        Me.Label_GUID.Location = New System.Drawing.Point(5, 33)
        Me.Label_GUID.Name = "Label_GUID"
        Me.Label_GUID.Size = New System.Drawing.Size(48, 13)
        Me.Label_GUID.TabIndex = 8
        Me.Label_GUID.Text = "x_GUID:"
        '
        'TextBox_GUID
        '
        Me.TextBox_GUID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.TextBox_GUID.Location = New System.Drawing.Point(59, 30)
        Me.TextBox_GUID.MaxLength = 255
        Me.TextBox_GUID.Name = "TextBox_GUID"
        Me.TextBox_GUID.ReadOnly = true
        Me.TextBox_GUID.Size = New System.Drawing.Size(410, 20)
        Me.TextBox_GUID.TabIndex = 9
        '
        'Button_NewGUID
        '
        Me.Button_NewGUID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Button_NewGUID.Location = New System.Drawing.Point(472, 28)
        Me.Button_NewGUID.Name = "Button_NewGUID"
        Me.Button_NewGUID.Size = New System.Drawing.Size(58, 23)
        Me.Button_NewGUID.TabIndex = 10
        Me.Button_NewGUID.Text = "x_New"
        Me.Button_NewGUID.UseVisualStyleBackColor = true
        '
        'TextBox_Repeat
        '
        Me.TextBox_Repeat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.TextBox_Repeat.Location = New System.Drawing.Point(59, 84)
        Me.TextBox_Repeat.MaxLength = 255
        Me.TextBox_Repeat.Name = "TextBox_Repeat"
        Me.TextBox_Repeat.Size = New System.Drawing.Size(471, 20)
        Me.TextBox_Repeat.TabIndex = 12
        Me.TextBox_Repeat.Visible = false
        '
        'Label_Repeat
        '
        Me.Label_Repeat.AutoSize = true
        Me.Label_Repeat.Location = New System.Drawing.Point(4, 87)
        Me.Label_Repeat.Name = "Label_Repeat"
        Me.Label_Repeat.Size = New System.Drawing.Size(56, 13)
        Me.Label_Repeat.TabIndex = 11
        Me.Label_Repeat.Text = "x_Repeat:"
        Me.Label_Repeat.Visible = false
        '
        'CheckBox_Apply
        '
        Me.CheckBox_Apply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.CheckBox_Apply.AutoSize = true
        Me.CheckBox_Apply.Location = New System.Drawing.Point(464, 132)
        Me.CheckBox_Apply.Name = "CheckBox_Apply"
        Me.CheckBox_Apply.Size = New System.Drawing.Size(63, 17)
        Me.CheckBox_Apply.TabIndex = 13
        Me.CheckBox_Apply.Text = "x_Apply"
        Me.CheckBox_Apply.UseVisualStyleBackColor = true
        '
        'NumericUpDown_OrderID_Start
        '
        Me.NumericUpDown_OrderID_Start.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_OrderID_Start.Location = New System.Drawing.Point(208, 129)
        Me.NumericUpDown_OrderID_Start.Name = "NumericUpDown_OrderID_Start"
        Me.NumericUpDown_OrderID_Start.Size = New System.Drawing.Size(36, 20)
        Me.NumericUpDown_OrderID_Start.TabIndex = 14
        Me.NumericUpDown_OrderID_Start.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'CheckBox_OrderID
        '
        Me.CheckBox_OrderID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.CheckBox_OrderID.AutoSize = true
        Me.CheckBox_OrderID.Location = New System.Drawing.Point(251, 131)
        Me.CheckBox_OrderID.Name = "CheckBox_OrderID"
        Me.CheckBox_OrderID.Size = New System.Drawing.Size(74, 17)
        Me.CheckBox_OrderID.TabIndex = 15
        Me.CheckBox_OrderID.Text = "x_OrderID"
        Me.CheckBox_OrderID.UseVisualStyleBackColor = true
        '
        'SicheresPasswordToolStripMenuItem
        '
        Me.SicheresPasswordToolStripMenuItem.Name = "SicheresPasswordToolStripMenuItem"
        Me.SicheresPasswordToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SicheresPasswordToolStripMenuItem.Text = "x_Sicheres Password"
        '
        'frm_Name
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 150)
        Me.Controls.Add(Me.CheckBox_OrderID)
        Me.Controls.Add(Me.NumericUpDown_OrderID_Start)
        Me.Controls.Add(Me.CheckBox_Apply)
        Me.Controls.Add(Me.TextBox_Repeat)
        Me.Controls.Add(Me.Label_Repeat)
        Me.Controls.Add(Me.Button_NewGUID)
        Me.Controls.Add(Me.TextBox_GUID)
        Me.Controls.Add(Me.Label_GUID)
        Me.Controls.Add(Me.TextBox_Name)
        Me.Controls.Add(Me.Label_Name)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button_OK)
        Me.Controls.Add(Me.CheckBox_Additional)
        Me.Controls.Add(Me.NumericUpDown_Additional)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frm_Name"
        Me.Text = "frm_Name"
        Me.StatusStrip1.ResumeLayout(false)
        Me.StatusStrip1.PerformLayout
        CType(Me.NumericUpDown_Additional,System.ComponentModel.ISupportInitialize).EndInit
        Me.MenuStrip1.ResumeLayout(false)
        Me.MenuStrip1.PerformLayout
        CType(Me.NumericUpDown_OrderID_Start,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel_DatabaseLBL As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_Database As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_LengthLBL As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_Length As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents NumericUpDown_Additional As System.Windows.Forms.NumericUpDown
    Friend WithEvents CheckBox_Additional As System.Windows.Forms.CheckBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_List As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button_OK As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label_Name As System.Windows.Forms.Label
    Friend WithEvents TextBox_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label_GUID As System.Windows.Forms.Label
    Friend WithEvents TextBox_GUID As System.Windows.Forms.TextBox
    Friend WithEvents Button_NewGUID As System.Windows.Forms.Button
    Friend WithEvents TextBox_Repeat As System.Windows.Forms.TextBox
    Friend WithEvents Label_Repeat As System.Windows.Forms.Label
    Friend WithEvents CheckBox_Apply As System.Windows.Forms.CheckBox
    Friend WithEvents NumericUpDown_OrderID_Start As System.Windows.Forms.NumericUpDown
    Friend WithEvents CheckBox_OrderID As System.Windows.Forms.CheckBox
    Friend WithEvents SicheresPasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
