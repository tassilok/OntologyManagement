﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClipboard
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.Button_Apply = New System.Windows.Forms.Button()
        Me.Button_Clear = New System.Windows.Forms.Button()
        Me.Button_Cancel = New System.Windows.Forms.Button()
        Me.DataGridView_Items = New System.Windows.Forms.DataGridView()
        Me.BindingSource_Items = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataGridView_Items, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource_Items, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_Apply
        '
        Me.Button_Apply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Apply.Location = New System.Drawing.Point(43, 231)
        Me.Button_Apply.Name = "Button_Apply"
        Me.Button_Apply.Size = New System.Drawing.Size(75, 23)
        Me.Button_Apply.TabIndex = 0
        Me.Button_Apply.Text = "Apply"
        Me.Button_Apply.UseVisualStyleBackColor = True
        '
        'Button_Clear
        '
        Me.Button_Clear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Clear.Location = New System.Drawing.Point(124, 231)
        Me.Button_Clear.Name = "Button_Clear"
        Me.Button_Clear.Size = New System.Drawing.Size(75, 23)
        Me.Button_Clear.TabIndex = 1
        Me.Button_Clear.Text = "Clear List"
        Me.Button_Clear.UseVisualStyleBackColor = True
        '
        'Button_Cancel
        '
        Me.Button_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Cancel.Location = New System.Drawing.Point(205, 231)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Button_Cancel.TabIndex = 2
        Me.Button_Cancel.Text = "Cancel"
        Me.Button_Cancel.UseVisualStyleBackColor = True
        '
        'DataGridView_Items
        '
        Me.DataGridView_Items.AllowUserToAddRows = False
        Me.DataGridView_Items.AllowUserToDeleteRows = False
        Me.DataGridView_Items.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Items.Location = New System.Drawing.Point(5, 6)
        Me.DataGridView_Items.Name = "DataGridView_Items"
        Me.DataGridView_Items.ReadOnly = True
        Me.DataGridView_Items.Size = New System.Drawing.Size(275, 219)
        Me.DataGridView_Items.TabIndex = 3
        '
        'frmClipboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.DataGridView_Items)
        Me.Controls.Add(Me.Button_Cancel)
        Me.Controls.Add(Me.Button_Clear)
        Me.Controls.Add(Me.Button_Apply)
        Me.Name = "frmClipboard"
        Me.Text = "frmClipboard"
        CType(Me.DataGridView_Items, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource_Items, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button_Apply As System.Windows.Forms.Button
    Friend WithEvents Button_Clear As System.Windows.Forms.Button
    Friend WithEvents Button_Cancel As System.Windows.Forms.Button
    Friend WithEvents DataGridView_Items As System.Windows.Forms.DataGridView
    Friend WithEvents BindingSource_Items As System.Windows.Forms.BindingSource
End Class