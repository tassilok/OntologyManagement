<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_PDFViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_PDFViewer))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_NameLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Name = New System.Windows.Forms.ToolStripLabel()
        Me.AxFoxitCtl_Main = New AxFOXITREADERLib.AxFoxitCtl()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.AxFoxitCtl_Main, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.AxFoxitCtl_Main)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(511, 428)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(511, 478)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_NameLBL, Me.ToolStripLabel_Name})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(76, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripLabel_NameLBL
        '
        Me.ToolStripLabel_NameLBL.Name = "ToolStripLabel_NameLBL"
        Me.ToolStripLabel_NameLBL.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripLabel_NameLBL.Text = "x_Name:"
        '
        'ToolStripLabel_Name
        '
        Me.ToolStripLabel_Name.Name = "ToolStripLabel_Name"
        Me.ToolStripLabel_Name.Size = New System.Drawing.Size(12, 22)
        Me.ToolStripLabel_Name.Text = "-"
        '
        'AxFoxitCtl_Main
        '
        Me.AxFoxitCtl_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxFoxitCtl_Main.Enabled = True
        Me.AxFoxitCtl_Main.Location = New System.Drawing.Point(0, 0)
        Me.AxFoxitCtl_Main.Name = "AxFoxitCtl_Main"
        Me.AxFoxitCtl_Main.OcxState = CType(resources.GetObject("AxFoxitCtl_Main.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxFoxitCtl_Main.Size = New System.Drawing.Size(511, 428)
        Me.AxFoxitCtl_Main.TabIndex = 0
        '
        'UserControl_PDFViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_PDFViewer"
        Me.Size = New System.Drawing.Size(511, 478)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.AxFoxitCtl_Main, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_NameLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Name As System.Windows.Forms.ToolStripLabel
    Friend WithEvents AxFoxitCtl_Main As AxFOXITREADERLib.AxFoxitCtl

End Class
