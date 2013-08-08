<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_DataSource
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
        Me.Label_DataSourceLBL = New System.Windows.Forms.Label()
        Me.Label_DataSource = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label_DataSourceLBL
        '
        Me.Label_DataSourceLBL.AutoSize = True
        Me.Label_DataSourceLBL.Location = New System.Drawing.Point(1, 1)
        Me.Label_DataSourceLBL.Name = "Label_DataSourceLBL"
        Me.Label_DataSourceLBL.Size = New System.Drawing.Size(78, 13)
        Me.Label_DataSourceLBL.TabIndex = 0
        Me.Label_DataSourceLBL.Text = "x_DataSource:"
        '
        'Label_DataSource
        '
        Me.Label_DataSource.AutoSize = True
        Me.Label_DataSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_DataSource.Location = New System.Drawing.Point(76, 1)
        Me.Label_DataSource.Name = "Label_DataSource"
        Me.Label_DataSource.Size = New System.Drawing.Size(12, 15)
        Me.Label_DataSource.TabIndex = 1
        Me.Label_DataSource.Text = "-"
        '
        'UserControl_DataSource
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label_DataSource)
        Me.Controls.Add(Me.Label_DataSourceLBL)
        Me.Name = "UserControl_DataSource"
        Me.Size = New System.Drawing.Size(212, 19)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label_DataSourceLBL As System.Windows.Forms.Label
    Friend WithEvents Label_DataSource As System.Windows.Forms.Label

End Class
