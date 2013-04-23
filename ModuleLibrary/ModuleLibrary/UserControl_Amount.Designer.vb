<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_Amount
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
        Me.Label_Amount = New System.Windows.Forms.Label()
        Me.TextBox_Amount = New System.Windows.Forms.TextBox()
        Me.ComboBox_Unit = New System.Windows.Forms.ComboBox()
        Me.Timer_Amount = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label_Amount
        '
        Me.Label_Amount.AutoSize = True
        Me.Label_Amount.Location = New System.Drawing.Point(3, 8)
        Me.Label_Amount.Name = "Label_Amount"
        Me.Label_Amount.Size = New System.Drawing.Size(46, 13)
        Me.Label_Amount.TabIndex = 0
        Me.Label_Amount.Text = "Amount:"
        '
        'TextBox_Amount
        '
        Me.TextBox_Amount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Amount.Location = New System.Drawing.Point(56, 5)
        Me.TextBox_Amount.Name = "TextBox_Amount"
        Me.TextBox_Amount.ReadOnly = True
        Me.TextBox_Amount.Size = New System.Drawing.Size(334, 20)
        Me.TextBox_Amount.TabIndex = 1
        '
        'ComboBox_Unit
        '
        Me.ComboBox_Unit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_Unit.FormattingEnabled = True
        Me.ComboBox_Unit.Location = New System.Drawing.Point(396, 4)
        Me.ComboBox_Unit.Name = "ComboBox_Unit"
        Me.ComboBox_Unit.Size = New System.Drawing.Size(50, 21)
        Me.ComboBox_Unit.TabIndex = 2
        '
        'Timer_Amount
        '
        Me.Timer_Amount.Interval = 300
        '
        'UserControl_Amount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ComboBox_Unit)
        Me.Controls.Add(Me.TextBox_Amount)
        Me.Controls.Add(Me.Label_Amount)
        Me.Name = "UserControl_Amount"
        Me.Size = New System.Drawing.Size(450, 31)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label_Amount As System.Windows.Forms.Label
    Friend WithEvents TextBox_Amount As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox_Unit As System.Windows.Forms.ComboBox
    Friend WithEvents Timer_Amount As System.Windows.Forms.Timer

End Class
