<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuthenticate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAuthenticate))
        Me.Panel_Authenticate = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'Panel_Authenticate
        '
        Me.Panel_Authenticate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Authenticate.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Authenticate.Name = "Panel_Authenticate"
        Me.Panel_Authenticate.Size = New System.Drawing.Size(646, 481)
        Me.Panel_Authenticate.TabIndex = 0
        '
        'frmAuthenticate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 481)
        Me.Controls.Add(Me.Panel_Authenticate)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAuthenticate"
        Me.Text = "frmAuthenticate"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel_Authenticate As System.Windows.Forms.Panel
End Class
