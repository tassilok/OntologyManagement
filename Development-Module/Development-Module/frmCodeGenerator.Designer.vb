<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCodeGenerator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCodeGenerator))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComboBox_Languages = New System.Windows.Forms.ToolStripComboBox()
        Me.Scintilla_Code = New ScintillaNET.Scintilla()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.Scintilla_Code, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Scintilla_Code)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(473, 382)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(473, 432)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip2)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Close})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(62, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripButton_Close
        '
        Me.ToolStripButton_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Close.Image = CType(resources.GetObject("ToolStripButton_Close.Image"), System.Drawing.Image)
        Me.ToolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Close.Name = "ToolStripButton_Close"
        Me.ToolStripButton_Close.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripButton_Close.Text = "x_Close"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripComboBox_Languages})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(239, 25)
        Me.ToolStrip2.TabIndex = 0
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(72, 22)
        Me.ToolStripLabel1.Text = "x_Language:"
        '
        'ToolStripComboBox_Languages
        '
        Me.ToolStripComboBox_Languages.Name = "ToolStripComboBox_Languages"
        Me.ToolStripComboBox_Languages.Size = New System.Drawing.Size(120, 25)
        '
        'Scintilla_Code
        '
        Me.Scintilla_Code.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Scintilla_Code.Location = New System.Drawing.Point(0, 0)
        Me.Scintilla_Code.Name = "Scintilla_Code"
        Me.Scintilla_Code.Size = New System.Drawing.Size(473, 382)
        Me.Scintilla_Code.Styles.BraceBad.FontName = "Verdana" & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Scintilla_Code.Styles.BraceLight.FontName = "Verdana" & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Scintilla_Code.Styles.CallTip.FontName = "Segoe UI" & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Scintilla_Code.Styles.ControlChar.FontName = "Verdana" & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Scintilla_Code.Styles.Default.BackColor = System.Drawing.SystemColors.Window
        Me.Scintilla_Code.Styles.Default.FontName = "Verdana" & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Scintilla_Code.Styles.IndentGuide.FontName = "Verdana" & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Scintilla_Code.Styles.LastPredefined.FontName = "Verdana" & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Scintilla_Code.Styles.LineNumber.FontName = "Verdana" & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Scintilla_Code.Styles.Max.FontName = "Verdana" & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0)
        Me.Scintilla_Code.TabIndex = 0
        '
        'frmCodeGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 432)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCodeGenerator"
        Me.Text = "frmCodeGenerator"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.Scintilla_Code, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripComboBox_Languages As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Scintilla_Code As ScintillaNET.Scintilla
End Class
