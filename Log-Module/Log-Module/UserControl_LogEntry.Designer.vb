<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_LogEntry
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
        Me.Label_Relations = New System.Windows.Forms.Label()
        Me.Panel_Relations = New System.Windows.Forms.Panel()
        Me.Button_FromTimestamp = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripProgressBar_Data = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripLabel_UserLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_User = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_LogstateLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_LogState = New System.Windows.Forms.ToolStripLabel()
        Me.ComboBox_User = New System.Windows.Forms.ComboBox()
        Me.ContextMenuStrip_User = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenObjectEditUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer_Data = New System.Windows.Forms.Timer(Me.components)
        Me.Label_User = New System.Windows.Forms.Label()
        Me.ComboBox_Logstate = New System.Windows.Forms.ComboBox()
        Me.ContextMenuStrip_LogState = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StandardLogstateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenObjectEditLogstateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label_Logstate = New System.Windows.Forms.Label()
        Me.TextBox_Message = New System.Windows.Forms.TextBox()
        Me.Label_Message = New System.Windows.Forms.Label()
        Me.DateTimePicker_DateTimeStamp = New System.Windows.Forms.DateTimePicker()
        Me.Label_DateTimeStamp = New System.Windows.Forms.Label()
        Me.TextBox_Caption = New System.Windows.Forms.TextBox()
        Me.Label_Name = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.ContextMenuStrip_User.SuspendLayout()
        Me.ContextMenuStrip_LogState.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label_Relations
        '
        Me.Label_Relations.AutoSize = True
        Me.Label_Relations.Location = New System.Drawing.Point(4, 311)
        Me.Label_Relations.Name = "Label_Relations"
        Me.Label_Relations.Size = New System.Drawing.Size(65, 13)
        Me.Label_Relations.TabIndex = 29
        Me.Label_Relations.Text = "x_Relations:"
        '
        'Panel_Relations
        '
        Me.Panel_Relations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Relations.Location = New System.Drawing.Point(80, 311)
        Me.Panel_Relations.Name = "Panel_Relations"
        Me.Panel_Relations.Size = New System.Drawing.Size(438, 100)
        Me.Panel_Relations.TabIndex = 28
        '
        'Button_FromTimestamp
        '
        Me.Button_FromTimestamp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_FromTimestamp.Location = New System.Drawing.Point(459, 1)
        Me.Button_FromTimestamp.Name = "Button_FromTimestamp"
        Me.Button_FromTimestamp.Size = New System.Drawing.Size(59, 22)
        Me.Button_FromTimestamp.TabIndex = 27
        Me.Button_FromTimestamp.Text = "x_Stamp"
        Me.Button_FromTimestamp.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar_Data, Me.ToolStripLabel_UserLBL, Me.ToolStripLabel_User, Me.ToolStripLabel_LogstateLBL, Me.ToolStripLabel_LogState})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 450)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(527, 25)
        Me.ToolStrip1.TabIndex = 26
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripProgressBar_Data
        '
        Me.ToolStripProgressBar_Data.Name = "ToolStripProgressBar_Data"
        Me.ToolStripProgressBar_Data.Size = New System.Drawing.Size(200, 22)
        '
        'ToolStripLabel_UserLBL
        '
        Me.ToolStripLabel_UserLBL.Name = "ToolStripLabel_UserLBL"
        Me.ToolStripLabel_UserLBL.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel_UserLBL.Text = "x_User:"
        '
        'ToolStripLabel_User
        '
        Me.ToolStripLabel_User.Name = "ToolStripLabel_User"
        Me.ToolStripLabel_User.Size = New System.Drawing.Size(12, 22)
        Me.ToolStripLabel_User.Text = "-"
        '
        'ToolStripLabel_LogstateLBL
        '
        Me.ToolStripLabel_LogstateLBL.Name = "ToolStripLabel_LogstateLBL"
        Me.ToolStripLabel_LogstateLBL.Size = New System.Drawing.Size(65, 22)
        Me.ToolStripLabel_LogstateLBL.Text = "x_Logstate:"
        '
        'ToolStripLabel_LogState
        '
        Me.ToolStripLabel_LogState.Name = "ToolStripLabel_LogState"
        Me.ToolStripLabel_LogState.Size = New System.Drawing.Size(12, 22)
        Me.ToolStripLabel_LogState.Text = "-"
        '
        'ComboBox_User
        '
        Me.ComboBox_User.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_User.ContextMenuStrip = Me.ContextMenuStrip_User
        Me.ComboBox_User.Enabled = False
        Me.ComboBox_User.FormattingEnabled = True
        Me.ComboBox_User.Location = New System.Drawing.Point(80, 283)
        Me.ComboBox_User.Name = "ComboBox_User"
        Me.ComboBox_User.Size = New System.Drawing.Size(438, 21)
        Me.ComboBox_User.TabIndex = 25
        '
        'ContextMenuStrip_User
        '
        Me.ContextMenuStrip_User.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenObjectEditUserToolStripMenuItem})
        Me.ContextMenuStrip_User.Name = "ContextMenuStrip_LogState"
        Me.ContextMenuStrip_User.Size = New System.Drawing.Size(177, 48)
        '
        'OpenObjectEditUserToolStripMenuItem
        '
        Me.OpenObjectEditUserToolStripMenuItem.Name = "OpenObjectEditUserToolStripMenuItem"
        Me.OpenObjectEditUserToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.OpenObjectEditUserToolStripMenuItem.Text = "x_Open Object-Edit"
        '
        'Timer_Data
        '
        Me.Timer_Data.Interval = 300
        '
        'Label_User
        '
        Me.Label_User.AutoSize = True
        Me.Label_User.Location = New System.Drawing.Point(4, 286)
        Me.Label_User.Name = "Label_User"
        Me.Label_User.Size = New System.Drawing.Size(43, 13)
        Me.Label_User.TabIndex = 24
        Me.Label_User.Text = "x_User:"
        '
        'ComboBox_Logstate
        '
        Me.ComboBox_Logstate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_Logstate.ContextMenuStrip = Me.ContextMenuStrip_LogState
        Me.ComboBox_Logstate.Enabled = False
        Me.ComboBox_Logstate.FormattingEnabled = True
        Me.ComboBox_Logstate.Location = New System.Drawing.Point(80, 257)
        Me.ComboBox_Logstate.Name = "ComboBox_Logstate"
        Me.ComboBox_Logstate.Size = New System.Drawing.Size(438, 21)
        Me.ComboBox_Logstate.TabIndex = 23
        '
        'ContextMenuStrip_LogState
        '
        Me.ContextMenuStrip_LogState.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StandardLogstateToolStripMenuItem, Me.OpenObjectEditLogstateToolStripMenuItem})
        Me.ContextMenuStrip_LogState.Name = "ContextMenuStrip_LogState"
        Me.ContextMenuStrip_LogState.Size = New System.Drawing.Size(177, 48)
        '
        'StandardLogstateToolStripMenuItem
        '
        Me.StandardLogstateToolStripMenuItem.Name = "StandardLogstateToolStripMenuItem"
        Me.StandardLogstateToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.StandardLogstateToolStripMenuItem.Text = "x_Standard"
        '
        'OpenObjectEditLogstateToolStripMenuItem
        '
        Me.OpenObjectEditLogstateToolStripMenuItem.Name = "OpenObjectEditLogstateToolStripMenuItem"
        Me.OpenObjectEditLogstateToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.OpenObjectEditLogstateToolStripMenuItem.Text = "x_Open Object-Edit"
        '
        'Label_Logstate
        '
        Me.Label_Logstate.AutoSize = True
        Me.Label_Logstate.Location = New System.Drawing.Point(4, 260)
        Me.Label_Logstate.Name = "Label_Logstate"
        Me.Label_Logstate.Size = New System.Drawing.Size(62, 13)
        Me.Label_Logstate.TabIndex = 22
        Me.Label_Logstate.Text = "x_Logstate:"
        '
        'TextBox_Message
        '
        Me.TextBox_Message.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Message.Location = New System.Drawing.Point(80, 52)
        Me.TextBox_Message.Multiline = True
        Me.TextBox_Message.Name = "TextBox_Message"
        Me.TextBox_Message.ReadOnly = True
        Me.TextBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox_Message.Size = New System.Drawing.Size(438, 199)
        Me.TextBox_Message.TabIndex = 21
        '
        'Label_Message
        '
        Me.Label_Message.AutoSize = True
        Me.Label_Message.Location = New System.Drawing.Point(4, 56)
        Me.Label_Message.Name = "Label_Message"
        Me.Label_Message.Size = New System.Drawing.Size(64, 13)
        Me.Label_Message.TabIndex = 20
        Me.Label_Message.Text = "x_Message:"
        '
        'DateTimePicker_DateTimeStamp
        '
        Me.DateTimePicker_DateTimeStamp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker_DateTimeStamp.CustomFormat = "dd.MM.yyy HH:mm:ss"
        Me.DateTimePicker_DateTimeStamp.Enabled = False
        Me.DateTimePicker_DateTimeStamp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker_DateTimeStamp.Location = New System.Drawing.Point(80, 27)
        Me.DateTimePicker_DateTimeStamp.Name = "DateTimePicker_DateTimeStamp"
        Me.DateTimePicker_DateTimeStamp.Size = New System.Drawing.Size(438, 20)
        Me.DateTimePicker_DateTimeStamp.TabIndex = 19
        '
        'Label_DateTimeStamp
        '
        Me.Label_DateTimeStamp.AutoSize = True
        Me.Label_DateTimeStamp.Location = New System.Drawing.Point(4, 30)
        Me.Label_DateTimeStamp.Name = "Label_DateTimeStamp"
        Me.Label_DateTimeStamp.Size = New System.Drawing.Size(72, 13)
        Me.Label_DateTimeStamp.TabIndex = 18
        Me.Label_DateTimeStamp.Text = "x_Timestamp:"
        '
        'TextBox_Caption
        '
        Me.TextBox_Caption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Caption.Location = New System.Drawing.Point(80, 2)
        Me.TextBox_Caption.Name = "TextBox_Caption"
        Me.TextBox_Caption.ReadOnly = True
        Me.TextBox_Caption.Size = New System.Drawing.Size(373, 20)
        Me.TextBox_Caption.TabIndex = 17
        '
        'Label_Name
        '
        Me.Label_Name.AutoSize = True
        Me.Label_Name.Location = New System.Drawing.Point(4, 3)
        Me.Label_Name.Name = "Label_Name"
        Me.Label_Name.Size = New System.Drawing.Size(57, 13)
        Me.Label_Name.TabIndex = 16
        Me.Label_Name.Text = "x_Caption:"
        '
        'UserControl_LogEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label_Relations)
        Me.Controls.Add(Me.Panel_Relations)
        Me.Controls.Add(Me.Button_FromTimestamp)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ComboBox_User)
        Me.Controls.Add(Me.Label_User)
        Me.Controls.Add(Me.ComboBox_Logstate)
        Me.Controls.Add(Me.Label_Logstate)
        Me.Controls.Add(Me.TextBox_Message)
        Me.Controls.Add(Me.Label_Message)
        Me.Controls.Add(Me.DateTimePicker_DateTimeStamp)
        Me.Controls.Add(Me.Label_DateTimeStamp)
        Me.Controls.Add(Me.TextBox_Caption)
        Me.Controls.Add(Me.Label_Name)
        Me.Name = "UserControl_LogEntry"
        Me.Size = New System.Drawing.Size(527, 475)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextMenuStrip_User.ResumeLayout(False)
        Me.ContextMenuStrip_LogState.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label_Relations As System.Windows.Forms.Label
    Friend WithEvents Panel_Relations As System.Windows.Forms.Panel
    Friend WithEvents Button_FromTimestamp As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripProgressBar_Data As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ComboBox_User As System.Windows.Forms.ComboBox
    Friend WithEvents Timer_Data As System.Windows.Forms.Timer
    Friend WithEvents Label_User As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Logstate As System.Windows.Forms.ComboBox
    Friend WithEvents Label_Logstate As System.Windows.Forms.Label
    Friend WithEvents TextBox_Message As System.Windows.Forms.TextBox
    Friend WithEvents Label_Message As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker_DateTimeStamp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label_DateTimeStamp As System.Windows.Forms.Label
    Friend WithEvents TextBox_Caption As System.Windows.Forms.TextBox
    Friend WithEvents Label_Name As System.Windows.Forms.Label
    Friend WithEvents ToolStripLabel_UserLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_User As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_LogstateLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_LogState As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ContextMenuStrip_User As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OpenObjectEditUserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip_LogState As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents StandardLogstateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenObjectEditLogstateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
