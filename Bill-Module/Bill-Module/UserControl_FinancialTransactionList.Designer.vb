<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_FinancialTransactionList
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.DataGridView_FinancialTransaction = New System.Windows.Forms.DataGridView()
        Me.ToolStripLabel_Sum = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripTextBox_Sum = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel_CountLbl = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Count = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ContextMenuStrip_Transactions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveFromListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView_FinancialTransaction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip_Transactions.SuspendLayout()
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DataGridView_FinancialTransaction)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(746, 375)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(746, 425)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_CountLbl, Me.ToolStripLabel_Count, Me.ToolStripSeparator1, Me.ToolStripLabel_Sum, Me.ToolStripTextBox_Sum})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(280, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'DataGridView_FinancialTransaction
        '
        Me.DataGridView_FinancialTransaction.AllowUserToAddRows = False
        Me.DataGridView_FinancialTransaction.AllowUserToDeleteRows = False
        Me.DataGridView_FinancialTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_FinancialTransaction.ContextMenuStrip = Me.ContextMenuStrip_Transactions
        Me.DataGridView_FinancialTransaction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_FinancialTransaction.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_FinancialTransaction.Name = "DataGridView_FinancialTransaction"
        Me.DataGridView_FinancialTransaction.ReadOnly = True
        Me.DataGridView_FinancialTransaction.Size = New System.Drawing.Size(746, 375)
        Me.DataGridView_FinancialTransaction.TabIndex = 0
        '
        'ToolStripLabel_Sum
        '
        Me.ToolStripLabel_Sum.Name = "ToolStripLabel_Sum"
        Me.ToolStripLabel_Sum.Size = New System.Drawing.Size(44, 22)
        Me.ToolStripLabel_Sum.Text = "x_Sum:"
        '
        'ToolStripTextBox_Sum
        '
        Me.ToolStripTextBox_Sum.Name = "ToolStripTextBox_Sum"
        Me.ToolStripTextBox_Sum.ReadOnly = True
        Me.ToolStripTextBox_Sum.Size = New System.Drawing.Size(150, 25)
        '
        'ToolStripLabel_CountLbl
        '
        Me.ToolStripLabel_CountLbl.Name = "ToolStripLabel_CountLbl"
        Me.ToolStripLabel_CountLbl.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripLabel_CountLbl.Text = "x_Count:"
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
        'ContextMenuStrip_Transactions
        '
        Me.ContextMenuStrip_Transactions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveFromListToolStripMenuItem})
        Me.ContextMenuStrip_Transactions.Name = "ContextMenuStrip_Transactions"
        Me.ContextMenuStrip_Transactions.Size = New System.Drawing.Size(178, 48)
        '
        'RemoveFromListToolStripMenuItem
        '
        Me.RemoveFromListToolStripMenuItem.Name = "RemoveFromListToolStripMenuItem"
        Me.RemoveFromListToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.RemoveFromListToolStripMenuItem.Text = "x_Remove from List"
        '
        'UserControl_FinancialTransactionList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_FinancialTransactionList"
        Me.Size = New System.Drawing.Size(746, 425)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView_FinancialTransaction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip_Transactions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents DataGridView_FinancialTransaction As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripLabel_Sum As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox_Sum As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel_CountLbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Count As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ContextMenuStrip_Transactions As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RemoveFromListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
