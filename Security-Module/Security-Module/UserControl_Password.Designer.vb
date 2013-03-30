<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_Password
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
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_CountLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Count = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripProgressBar_Passwords = New System.Windows.Forms.ToolStripProgressBar()
        Me.DataGridView_Passwords = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip_Passwords = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyPasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApplyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_FilterLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripTextBox_Filter = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingSource_Passwords = New System.Windows.Forms.BindingSource(Me.components)
        Me.Timer_Password = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Filter = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Remove = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.DataGridView_Passwords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip_Passwords.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.BindingSource_Passwords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.ToolStrip2)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DataGridView_Passwords)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(548, 406)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(548, 456)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_CountLBL, Me.ToolStripLabel_Count, Me.ToolStripSeparator1, Me.ToolStripProgressBar_Passwords})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(183, 25)
        Me.ToolStrip2.TabIndex = 0
        '
        'ToolStripLabel_CountLBL
        '
        Me.ToolStripLabel_CountLBL.Name = "ToolStripLabel_CountLBL"
        Me.ToolStripLabel_CountLBL.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripLabel_CountLBL.Text = "x_Count:"
        '
        'ToolStripLabel_Count
        '
        Me.ToolStripLabel_Count.Name = "ToolStripLabel_Count"
        Me.ToolStripLabel_Count.Size = New System.Drawing.Size(13, 22)
        Me.ToolStripLabel_Count.Text = "0"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripProgressBar_Passwords
        '
        Me.ToolStripProgressBar_Passwords.Name = "ToolStripProgressBar_Passwords"
        Me.ToolStripProgressBar_Passwords.Size = New System.Drawing.Size(100, 22)
        '
        'DataGridView_Passwords
        '
        Me.DataGridView_Passwords.AllowUserToAddRows = False
        Me.DataGridView_Passwords.AllowUserToDeleteRows = False
        Me.DataGridView_Passwords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Passwords.ContextMenuStrip = Me.ContextMenuStrip_Passwords
        Me.DataGridView_Passwords.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_Passwords.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_Passwords.Name = "DataGridView_Passwords"
        Me.DataGridView_Passwords.ReadOnly = True
        Me.DataGridView_Passwords.Size = New System.Drawing.Size(548, 406)
        Me.DataGridView_Passwords.TabIndex = 0
        '
        'ContextMenuStrip_Passwords
        '
        Me.ContextMenuStrip_Passwords.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.ChangeToolStripMenuItem, Me.CopyPasswordToolStripMenuItem, Me.ApplyToolStripMenuItem})
        Me.ContextMenuStrip_Passwords.Name = "ContextMenuStrip_Passwords"
        Me.ContextMenuStrip_Passwords.Size = New System.Drawing.Size(161, 114)
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Enabled = False
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'ChangeToolStripMenuItem
        '
        Me.ChangeToolStripMenuItem.Enabled = False
        Me.ChangeToolStripMenuItem.Name = "ChangeToolStripMenuItem"
        Me.ChangeToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ChangeToolStripMenuItem.Text = "x_Change"
        '
        'CopyPasswordToolStripMenuItem
        '
        Me.CopyPasswordToolStripMenuItem.Enabled = False
        Me.CopyPasswordToolStripMenuItem.Name = "CopyPasswordToolStripMenuItem"
        Me.CopyPasswordToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.CopyPasswordToolStripMenuItem.Text = "x_Copy Password"
        '
        'ApplyToolStripMenuItem
        '
        Me.ApplyToolStripMenuItem.Enabled = False
        Me.ApplyToolStripMenuItem.Name = "ApplyToolStripMenuItem"
        Me.ApplyToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ApplyToolStripMenuItem.Text = "Apply"
        Me.ApplyToolStripMenuItem.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_FilterLBL, Me.ToolStripTextBox_Filter})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(259, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripLabel_FilterLBL
        '
        Me.ToolStripLabel_FilterLBL.Name = "ToolStripLabel_FilterLBL"
        Me.ToolStripLabel_FilterLBL.Size = New System.Drawing.Size(47, 22)
        Me.ToolStripLabel_FilterLBL.Text = "x_Filter:"
        '
        'ToolStripTextBox_Filter
        '
        Me.ToolStripTextBox_Filter.Name = "ToolStripTextBox_Filter"
        Me.ToolStripTextBox_Filter.Size = New System.Drawing.Size(200, 25)
        '
        'Timer_Password
        '
        Me.Timer_Password.Interval = 300
        '
        'Timer_Filter
        '
        Me.Timer_Filter.Interval = 300
        '
        'Timer_Remove
        '
        Me.Timer_Remove.Interval = 30000
        '
        'UserControl_Password
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_Password"
        Me.Size = New System.Drawing.Size(548, 456)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.DataGridView_Passwords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip_Passwords.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.BindingSource_Passwords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_CountLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Count As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DataGridView_Passwords As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_FilterLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox_Filter As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingSource_Passwords As System.Windows.Forms.BindingSource
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripProgressBar_Passwords As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Timer_Password As System.Windows.Forms.Timer
    Friend WithEvents Timer_Filter As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip_Passwords As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyPasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ApplyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer_Remove As System.Windows.Forms.Timer

End Class
