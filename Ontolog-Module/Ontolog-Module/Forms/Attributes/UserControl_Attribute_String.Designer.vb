﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_Attribute_String
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
        Me.TextBox_Val = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TextBox_Val
        '
        Me.TextBox_Val.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_Val.Location = New System.Drawing.Point(0, 0)
        Me.TextBox_Val.Multiline = True
        Me.TextBox_Val.Name = "TextBox_Val"
        Me.TextBox_Val.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox_Val.Size = New System.Drawing.Size(376, 317)
        Me.TextBox_Val.TabIndex = 0
        '
        'UserControl_Attribute_String
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TextBox_Val)
        Me.Name = "UserControl_Attribute_String"
        Me.Size = New System.Drawing.Size(376, 317)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox_Val As System.Windows.Forms.TextBox

End Class
