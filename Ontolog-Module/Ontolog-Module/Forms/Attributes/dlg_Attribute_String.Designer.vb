﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlg_Attribute_String
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlg_Attribute_String))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.NumericUpDown_ItemCount = New System.Windows.Forms.NumericUpDown()
        Me.ToolStripStatusLabel_DB = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CheckBox_more = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage_Text = New System.Windows.Forms.TabPage()
        Me.TabPage_WebBrowser = New System.Windows.Forms.TabPage()
        Me.WebBrowser_Text = New System.Windows.Forms.WebBrowser()
        Me.Timer_Webbrowser = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.NumericUpDown_ItemCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage_WebBrowser.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 324)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'NumericUpDown_ItemCount
        '
        Me.NumericUpDown_ItemCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_ItemCount.Location = New System.Drawing.Point(9, 325)
        Me.NumericUpDown_ItemCount.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.NumericUpDown_ItemCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown_ItemCount.Name = "NumericUpDown_ItemCount"
        Me.NumericUpDown_ItemCount.Size = New System.Drawing.Size(40, 20)
        Me.NumericUpDown_ItemCount.TabIndex = 19
        Me.NumericUpDown_ItemCount.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown_ItemCount.Visible = False
        '
        'ToolStripStatusLabel_DB
        '
        Me.ToolStripStatusLabel_DB.BackColor = System.Drawing.SystemColors.HighlightText
        Me.ToolStripStatusLabel_DB.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel_DB.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel_DB.Name = "ToolStripStatusLabel_DB"
        Me.ToolStripStatusLabel_DB.Size = New System.Drawing.Size(35, 19)
        Me.ToolStripStatusLabel_DB.Text = "DB_f"
        '
        'CheckBox_more
        '
        Me.CheckBox_more.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_more.AutoSize = True
        Me.CheckBox_more.Location = New System.Drawing.Point(55, 326)
        Me.CheckBox_more.Name = "CheckBox_more"
        Me.CheckBox_more.Size = New System.Drawing.Size(69, 17)
        Me.CheckBox_more.TabIndex = 20
        Me.CheckBox_more.Text = "weitere_f"
        Me.CheckBox_more.UseVisualStyleBackColor = True
        Me.CheckBox_more.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel_DB})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 364)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(434, 24)
        Me.StatusStrip1.TabIndex = 18
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage_Text)
        Me.TabControl1.Controls.Add(Me.TabPage_WebBrowser)
        Me.TabControl1.Location = New System.Drawing.Point(9, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(414, 314)
        Me.TabControl1.TabIndex = 21
        '
        'TabPage_Text
        '
        Me.TabPage_Text.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Text.Name = "TabPage_Text"
        Me.TabPage_Text.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Text.Size = New System.Drawing.Size(406, 288)
        Me.TabPage_Text.TabIndex = 0
        Me.TabPage_Text.Text = "x_Text"
        Me.TabPage_Text.UseVisualStyleBackColor = True
        '
        'TabPage_WebBrowser
        '
        Me.TabPage_WebBrowser.Controls.Add(Me.WebBrowser_Text)
        Me.TabPage_WebBrowser.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_WebBrowser.Name = "TabPage_WebBrowser"
        Me.TabPage_WebBrowser.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_WebBrowser.Size = New System.Drawing.Size(406, 288)
        Me.TabPage_WebBrowser.TabIndex = 2
        Me.TabPage_WebBrowser.Text = "x_WebBrowser"
        Me.TabPage_WebBrowser.UseVisualStyleBackColor = True
        '
        'WebBrowser_Text
        '
        Me.WebBrowser_Text.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser_Text.Location = New System.Drawing.Point(3, 3)
        Me.WebBrowser_Text.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser_Text.Name = "WebBrowser_Text"
        Me.WebBrowser_Text.Size = New System.Drawing.Size(400, 282)
        Me.WebBrowser_Text.TabIndex = 0
        '
        'Timer_Webbrowser
        '
        Me.Timer_Webbrowser.Interval = 300
        '
        'dlg_Attribute_String
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(434, 388)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.NumericUpDown_ItemCount)
        Me.Controls.Add(Me.CheckBox_more)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "dlg_Attribute_String"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dlg_Attribute_String"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.NumericUpDown_ItemCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage_WebBrowser.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown_ItemCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents ToolStripStatusLabel_DB As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CheckBox_more As System.Windows.Forms.CheckBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_Text As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_WebBrowser As System.Windows.Forms.TabPage
    Friend WithEvents WebBrowser_Text As System.Windows.Forms.WebBrowser
    Friend WithEvents Timer_Webbrowser As System.Windows.Forms.Timer

End Class
