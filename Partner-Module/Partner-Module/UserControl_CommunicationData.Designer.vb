<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_CommunicationData
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage_TelFax = New System.Windows.Forms.TabPage()
        Me.SplitContainer_TelFax = New System.Windows.Forms.SplitContainer()
        Me.TabPage_Web = New System.Windows.Forms.TabPage()
        Me.SplitContainer_Email_WebService = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer_Web_Service = New System.Windows.Forms.SplitContainer()
        Me.TabControl1.SuspendLayout()
        Me.TabPage_TelFax.SuspendLayout()
        CType(Me.SplitContainer_TelFax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_TelFax.SuspendLayout()
        Me.TabPage_Web.SuspendLayout()
        CType(Me.SplitContainer_Email_WebService, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_Email_WebService.Panel2.SuspendLayout()
        Me.SplitContainer_Email_WebService.SuspendLayout()
        CType(Me.SplitContainer_Web_Service, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_Web_Service.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage_TelFax)
        Me.TabControl1.Controls.Add(Me.TabPage_Web)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(612, 533)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage_TelFax
        '
        Me.TabPage_TelFax.Controls.Add(Me.SplitContainer_TelFax)
        Me.TabPage_TelFax.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_TelFax.Name = "TabPage_TelFax"
        Me.TabPage_TelFax.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_TelFax.Size = New System.Drawing.Size(604, 507)
        Me.TabPage_TelFax.TabIndex = 0
        Me.TabPage_TelFax.Text = "x_TelFax"
        Me.TabPage_TelFax.UseVisualStyleBackColor = True
        '
        'SplitContainer_TelFax
        '
        Me.SplitContainer_TelFax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer_TelFax.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_TelFax.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer_TelFax.Name = "SplitContainer_TelFax"
        Me.SplitContainer_TelFax.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.SplitContainer_TelFax.Size = New System.Drawing.Size(598, 501)
        Me.SplitContainer_TelFax.SplitterDistance = 232
        Me.SplitContainer_TelFax.TabIndex = 0
        '
        'TabPage_Web
        '
        Me.TabPage_Web.Controls.Add(Me.SplitContainer_Email_WebService)
        Me.TabPage_Web.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Web.Name = "TabPage_Web"
        Me.TabPage_Web.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Web.Size = New System.Drawing.Size(604, 507)
        Me.TabPage_Web.TabIndex = 1
        Me.TabPage_Web.Text = "x_Web"
        Me.TabPage_Web.UseVisualStyleBackColor = True
        '
        'SplitContainer_Email_WebService
        '
        Me.SplitContainer_Email_WebService.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer_Email_WebService.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_Email_WebService.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer_Email_WebService.Name = "SplitContainer_Email_WebService"
        Me.SplitContainer_Email_WebService.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer_Email_WebService.Panel2
        '
        Me.SplitContainer_Email_WebService.Panel2.Controls.Add(Me.SplitContainer_Web_Service)
        Me.SplitContainer_Email_WebService.Size = New System.Drawing.Size(598, 501)
        Me.SplitContainer_Email_WebService.SplitterDistance = 206
        Me.SplitContainer_Email_WebService.TabIndex = 0
        '
        'SplitContainer_Web_Service
        '
        Me.SplitContainer_Web_Service.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer_Web_Service.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_Web_Service.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_Web_Service.Name = "SplitContainer_Web_Service"
        Me.SplitContainer_Web_Service.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.SplitContainer_Web_Service.Size = New System.Drawing.Size(598, 291)
        Me.SplitContainer_Web_Service.SplitterDistance = 142
        Me.SplitContainer_Web_Service.TabIndex = 0
        '
        'UserControl_CommunicationData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "UserControl_CommunicationData"
        Me.Size = New System.Drawing.Size(612, 533)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage_TelFax.ResumeLayout(False)
        CType(Me.SplitContainer_TelFax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_TelFax.ResumeLayout(False)
        Me.TabPage_Web.ResumeLayout(False)
        Me.SplitContainer_Email_WebService.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer_Email_WebService, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_Email_WebService.ResumeLayout(False)
        CType(Me.SplitContainer_Web_Service, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_Web_Service.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_TelFax As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_Web As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer_TelFax As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer_Email_WebService As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer_Web_Service As System.Windows.Forms.SplitContainer

End Class
