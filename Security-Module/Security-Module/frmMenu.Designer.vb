<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton()
        Me.DataGridView_Secured = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip_Passwords = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyPasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer_Copy = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout
        Me.ToolStripContainer1.ContentPanel.SuspendLayout
        Me.ToolStripContainer1.SuspendLayout
        Me.ToolStrip1.SuspendLayout
        CType(Me.DataGridView_Secured,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ContextMenuStrip_Passwords.SuspendLayout
        Me.SuspendLayout
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DataGridView_Secured)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(514, 406)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(514, 431)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
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
        Me.ToolStripButton_Close.Image = CType(resources.GetObject("ToolStripButton_Close.Image"),System.Drawing.Image)
        Me.ToolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Close.Name = "ToolStripButton_Close"
        Me.ToolStripButton_Close.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripButton_Close.Text = "x_Close"
        '
        'DataGridView_Secured
        '
        Me.DataGridView_Secured.AllowUserToAddRows = false
        Me.DataGridView_Secured.AllowUserToDeleteRows = false
        Me.DataGridView_Secured.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Secured.ContextMenuStrip = Me.ContextMenuStrip_Passwords
        Me.DataGridView_Secured.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_Secured.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_Secured.Name = "DataGridView_Secured"
        Me.DataGridView_Secured.ReadOnly = true
        Me.DataGridView_Secured.Size = New System.Drawing.Size(514, 406)
        Me.DataGridView_Secured.TabIndex = 0
        '
        'ContextMenuStrip_Passwords
        '
        Me.ContextMenuStrip_Passwords.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.ChangeToolStripMenuItem, Me.CopyPasswordToolStripMenuItem})
        Me.ContextMenuStrip_Passwords.Name = "ContextMenuStrip_Passwords"
        Me.ContextMenuStrip_Passwords.Size = New System.Drawing.Size(179, 70)
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Enabled = false
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'ChangeToolStripMenuItem
        '
        Me.ChangeToolStripMenuItem.Enabled = false
        Me.ChangeToolStripMenuItem.Name = "ChangeToolStripMenuItem"
        Me.ChangeToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ChangeToolStripMenuItem.Text = "x_Change Password"
        '
        'CopyPasswordToolStripMenuItem
        '
        Me.CopyPasswordToolStripMenuItem.Enabled = false
        Me.CopyPasswordToolStripMenuItem.Name = "CopyPasswordToolStripMenuItem"
        Me.CopyPasswordToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.CopyPasswordToolStripMenuItem.Text = "x_Copy Password"
        '
        'Timer_Copy
        '
        Me.Timer_Copy.Interval = 30000
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 431)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "frmMenu"
        Me.Text = "frmMenu"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(false)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(false)
        Me.ToolStripContainer1.ResumeLayout(false)
        Me.ToolStripContainer1.PerformLayout
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        CType(Me.DataGridView_Secured,System.ComponentModel.ISupportInitialize).EndInit
        Me.ContextMenuStrip_Passwords.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView_Secured As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip_Passwords As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyPasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer_Copy As System.Windows.Forms.Timer
End Class
