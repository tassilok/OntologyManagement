<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_TransactionDetail
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripProgressBar_Detail = New System.Windows.Forms.ToolStripProgressBar()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel_SemItems = New System.Windows.Forms.Panel()
        Me.Label_SemItems = New System.Windows.Forms.Label()
        Me.Panel_Offset = New System.Windows.Forms.Panel()
        Me.Label_Offset = New System.Windows.Forms.Label()
        Me.Label_TransactionID = New System.Windows.Forms.Label()
        Me.TextBox_TransactionID = New System.Windows.Forms.TextBox()
        Me.Button_Date = New System.Windows.Forms.Button()
        Me.Button_Contractee = New System.Windows.Forms.Button()
        Me.Button_Contractor = New System.Windows.Forms.Button()
        Me.TextBox_Date = New System.Windows.Forms.TextBox()
        Me.Label_Rest = New System.Windows.Forms.Label()
        Me.TextBox_Rest = New System.Windows.Forms.TextBox()
        Me.ComboBox_TaxRate = New System.Windows.Forms.ComboBox()
        Me.Timer_Data = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Menge = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Sum = New System.Windows.Forms.Timer(Me.components)
        Me.BindingSource_Payments = New System.Windows.Forms.BindingSource(Me.components)
        Me.Timer_TransactionID = New System.Windows.Forms.Timer(Me.components)
        Me.Label_TaxRate = New System.Windows.Forms.Label()
        Me.Label_Contractor = New System.Windows.Forms.Label()
        Me.Label_Contractee = New System.Windows.Forms.Label()
        Me.NewPaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip_Payment = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ChangePaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemovePaymentToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalculatePercentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApplyBankTransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBox_Contractor = New System.Windows.Forms.TextBox()
        Me.TextBox_Contractee = New System.Windows.Forms.TextBox()
        Me.Label_amount = New System.Windows.Forms.Label()
        Me.ComboBox_unit = New System.Windows.Forms.ComboBox()
        Me.TextBox_Amount = New System.Windows.Forms.TextBox()
        Me.CheckBox_Gross = New System.Windows.Forms.CheckBox()
        Me.ComboBox_currency = New System.Windows.Forms.ComboBox()
        Me.TextBox_sum = New System.Windows.Forms.TextBox()
        Me.Label_Sum = New System.Windows.Forms.Label()
        Me.Label_Payments = New System.Windows.Forms.Label()
        Me.DataGridView_Payment = New System.Windows.Forms.DataGridView()
        Me.Label_TransactionDate = New System.Windows.Forms.Label()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.BindingSource_Payments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip_Payment.SuspendLayout()
        CType(Me.DataGridView_Payment, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(492, 548)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(492, 573)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        Me.ToolStripContainer1.TopToolStripPanelVisible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar_Detail})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(193, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripProgressBar_Detail
        '
        Me.ToolStripProgressBar_Detail.Name = "ToolStripProgressBar_Detail"
        Me.ToolStripProgressBar_Detail.Size = New System.Drawing.Size(150, 22)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(18, 289)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel_SemItems)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label_SemItems)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel_Offset)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label_Offset)
        Me.SplitContainer1.Size = New System.Drawing.Size(461, 238)
        Me.SplitContainer1.SplitterDistance = 119
        Me.SplitContainer1.TabIndex = 55
        '
        'Panel_SemItems
        '
        Me.Panel_SemItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_SemItems.Location = New System.Drawing.Point(116, 4)
        Me.Panel_SemItems.Name = "Panel_SemItems"
        Me.Panel_SemItems.Size = New System.Drawing.Size(338, 109)
        Me.Panel_SemItems.TabIndex = 19
        '
        'Label_SemItems
        '
        Me.Label_SemItems.AutoSize = True
        Me.Label_SemItems.Location = New System.Drawing.Point(3, 4)
        Me.Label_SemItems.Name = "Label_SemItems"
        Me.Label_SemItems.Size = New System.Drawing.Size(81, 13)
        Me.Label_SemItems.TabIndex = 18
        Me.Label_SemItems.Text = "x_related Items:"
        '
        'Panel_Offset
        '
        Me.Panel_Offset.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Offset.Location = New System.Drawing.Point(116, 3)
        Me.Panel_Offset.Name = "Panel_Offset"
        Me.Panel_Offset.Size = New System.Drawing.Size(338, 106)
        Me.Panel_Offset.TabIndex = 29
        '
        'Label_Offset
        '
        Me.Label_Offset.AutoSize = True
        Me.Label_Offset.Location = New System.Drawing.Point(3, 3)
        Me.Label_Offset.Name = "Label_Offset"
        Me.Label_Offset.Size = New System.Drawing.Size(49, 13)
        Me.Label_Offset.TabIndex = 28
        Me.Label_Offset.Text = "x_Offset:"
        '
        'Label_TransactionID
        '
        Me.Label_TransactionID.AutoSize = True
        Me.Label_TransactionID.Location = New System.Drawing.Point(12, 46)
        Me.Label_TransactionID.Name = "Label_TransactionID"
        Me.Label_TransactionID.Size = New System.Drawing.Size(91, 13)
        Me.Label_TransactionID.TabIndex = 54
        Me.Label_TransactionID.Text = "x_Transaction-ID:"
        '
        'TextBox_TransactionID
        '
        Me.TextBox_TransactionID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_TransactionID.Location = New System.Drawing.Point(133, 46)
        Me.TextBox_TransactionID.Name = "TextBox_TransactionID"
        Me.TextBox_TransactionID.ReadOnly = True
        Me.TextBox_TransactionID.Size = New System.Drawing.Size(347, 20)
        Me.TextBox_TransactionID.TabIndex = 53
        '
        'Button_Date
        '
        Me.Button_Date.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Date.Enabled = False
        Me.Button_Date.Location = New System.Drawing.Point(452, 17)
        Me.Button_Date.Name = "Button_Date"
        Me.Button_Date.Size = New System.Drawing.Size(28, 23)
        Me.Button_Date.TabIndex = 50
        Me.Button_Date.Text = "..."
        Me.Button_Date.UseVisualStyleBackColor = True
        '
        'Button_Contractee
        '
        Me.Button_Contractee.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Contractee.Enabled = False
        Me.Button_Contractee.Location = New System.Drawing.Point(451, 252)
        Me.Button_Contractee.Name = "Button_Contractee"
        Me.Button_Contractee.Size = New System.Drawing.Size(28, 23)
        Me.Button_Contractee.TabIndex = 51
        Me.Button_Contractee.Text = "..."
        Me.Button_Contractee.UseVisualStyleBackColor = True
        '
        'Button_Contractor
        '
        Me.Button_Contractor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Contractor.Enabled = False
        Me.Button_Contractor.Location = New System.Drawing.Point(451, 225)
        Me.Button_Contractor.Name = "Button_Contractor"
        Me.Button_Contractor.Size = New System.Drawing.Size(28, 23)
        Me.Button_Contractor.TabIndex = 52
        Me.Button_Contractor.Text = "..."
        Me.Button_Contractor.UseVisualStyleBackColor = True
        '
        'TextBox_Date
        '
        Me.TextBox_Date.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Date.Location = New System.Drawing.Point(133, 19)
        Me.TextBox_Date.Name = "TextBox_Date"
        Me.TextBox_Date.ReadOnly = True
        Me.TextBox_Date.Size = New System.Drawing.Size(312, 20)
        Me.TextBox_Date.TabIndex = 31
        '
        'Label_Rest
        '
        Me.Label_Rest.AutoSize = True
        Me.Label_Rest.Location = New System.Drawing.Point(15, 176)
        Me.Label_Rest.Name = "Label_Rest"
        Me.Label_Rest.Size = New System.Drawing.Size(73, 13)
        Me.Label_Rest.TabIndex = 48
        Me.Label_Rest.Text = "x_Restbetrag:"
        '
        'TextBox_Rest
        '
        Me.TextBox_Rest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Rest.Location = New System.Drawing.Point(133, 173)
        Me.TextBox_Rest.Name = "TextBox_Rest"
        Me.TextBox_Rest.ReadOnly = True
        Me.TextBox_Rest.Size = New System.Drawing.Size(95, 20)
        Me.TextBox_Rest.TabIndex = 47
        Me.TextBox_Rest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ComboBox_TaxRate
        '
        Me.ComboBox_TaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_TaxRate.Enabled = False
        Me.ComboBox_TaxRate.FormattingEnabled = True
        Me.ComboBox_TaxRate.Location = New System.Drawing.Point(415, 145)
        Me.ComboBox_TaxRate.Name = "ComboBox_TaxRate"
        Me.ComboBox_TaxRate.Size = New System.Drawing.Size(65, 21)
        Me.ComboBox_TaxRate.TabIndex = 46
        '
        'Timer_Data
        '
        Me.Timer_Data.Interval = 300
        '
        'Timer_Menge
        '
        Me.Timer_Menge.Interval = 300
        '
        'Timer_Sum
        '
        Me.Timer_Sum.Interval = 300
        '
        'Timer_TransactionID
        '
        Me.Timer_TransactionID.Interval = 300
        '
        'Label_TaxRate
        '
        Me.Label_TaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_TaxRate.AutoSize = True
        Me.Label_TaxRate.Location = New System.Drawing.Point(338, 148)
        Me.Label_TaxRate.Name = "Label_TaxRate"
        Me.Label_TaxRate.Size = New System.Drawing.Size(71, 13)
        Me.Label_TaxRate.TabIndex = 45
        Me.Label_TaxRate.Text = "x_Steuersatz:"
        '
        'Label_Contractor
        '
        Me.Label_Contractor.AutoSize = True
        Me.Label_Contractor.Location = New System.Drawing.Point(15, 257)
        Me.Label_Contractor.Name = "Label_Contractor"
        Me.Label_Contractor.Size = New System.Drawing.Size(95, 13)
        Me.Label_Contractor.TabIndex = 44
        Me.Label_Contractor.Text = "x_Vertragsnehmer:"
        '
        'Label_Contractee
        '
        Me.Label_Contractee.AutoSize = True
        Me.Label_Contractee.Location = New System.Drawing.Point(15, 230)
        Me.Label_Contractee.Name = "Label_Contractee"
        Me.Label_Contractee.Size = New System.Drawing.Size(87, 13)
        Me.Label_Contractee.TabIndex = 41
        Me.Label_Contractee.Text = "x_Vertragsgeber:"
        '
        'NewPaymentToolStripMenuItem
        '
        Me.NewPaymentToolStripMenuItem.Enabled = False
        Me.NewPaymentToolStripMenuItem.Name = "NewPaymentToolStripMenuItem"
        Me.NewPaymentToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.NewPaymentToolStripMenuItem.Text = "x_New"
        '
        'ContextMenuStrip_Payment
        '
        Me.ContextMenuStrip_Payment.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewPaymentToolStripMenuItem, Me.ChangePaymentToolStripMenuItem, Me.RemovePaymentToolStripMenuItem1, Me.CalculatePercentToolStripMenuItem, Me.ApplyBankTransactionToolStripMenuItem})
        Me.ContextMenuStrip_Payment.Name = "ContextMenuStrip_Payment"
        Me.ContextMenuStrip_Payment.Size = New System.Drawing.Size(200, 114)
        '
        'ChangePaymentToolStripMenuItem
        '
        Me.ChangePaymentToolStripMenuItem.Enabled = False
        Me.ChangePaymentToolStripMenuItem.Name = "ChangePaymentToolStripMenuItem"
        Me.ChangePaymentToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ChangePaymentToolStripMenuItem.Text = "x_Change"
        '
        'RemovePaymentToolStripMenuItem1
        '
        Me.RemovePaymentToolStripMenuItem1.Enabled = False
        Me.RemovePaymentToolStripMenuItem1.Name = "RemovePaymentToolStripMenuItem1"
        Me.RemovePaymentToolStripMenuItem1.Size = New System.Drawing.Size(199, 22)
        Me.RemovePaymentToolStripMenuItem1.Text = "x_Remove"
        '
        'CalculatePercentToolStripMenuItem
        '
        Me.CalculatePercentToolStripMenuItem.Enabled = False
        Me.CalculatePercentToolStripMenuItem.Name = "CalculatePercentToolStripMenuItem"
        Me.CalculatePercentToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.CalculatePercentToolStripMenuItem.Text = "x_Calculate Percent"
        '
        'ApplyBankTransactionToolStripMenuItem
        '
        Me.ApplyBankTransactionToolStripMenuItem.Enabled = False
        Me.ApplyBankTransactionToolStripMenuItem.Name = "ApplyBankTransactionToolStripMenuItem"
        Me.ApplyBankTransactionToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ApplyBankTransactionToolStripMenuItem.Text = "x_Apply Bank-Transaction"
        '
        'TextBox_Contractor
        '
        Me.TextBox_Contractor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Contractor.Location = New System.Drawing.Point(133, 227)
        Me.TextBox_Contractor.Name = "TextBox_Contractor"
        Me.TextBox_Contractor.ReadOnly = True
        Me.TextBox_Contractor.Size = New System.Drawing.Size(312, 20)
        Me.TextBox_Contractor.TabIndex = 43
        '
        'TextBox_Contractee
        '
        Me.TextBox_Contractee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Contractee.Location = New System.Drawing.Point(133, 254)
        Me.TextBox_Contractee.Name = "TextBox_Contractee"
        Me.TextBox_Contractee.ReadOnly = True
        Me.TextBox_Contractee.Size = New System.Drawing.Size(312, 20)
        Me.TextBox_Contractee.TabIndex = 42
        '
        'Label_amount
        '
        Me.Label_amount.AutoSize = True
        Me.Label_amount.Location = New System.Drawing.Point(15, 203)
        Me.Label_amount.Name = "Label_amount"
        Me.Label_amount.Size = New System.Drawing.Size(54, 13)
        Me.Label_amount.TabIndex = 38
        Me.Label_amount.Text = "x_Menge:"
        '
        'ComboBox_unit
        '
        Me.ComboBox_unit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_unit.Enabled = False
        Me.ComboBox_unit.FormattingEnabled = True
        Me.ComboBox_unit.Location = New System.Drawing.Point(415, 200)
        Me.ComboBox_unit.Name = "ComboBox_unit"
        Me.ComboBox_unit.Size = New System.Drawing.Size(65, 21)
        Me.ComboBox_unit.TabIndex = 40
        '
        'TextBox_Amount
        '
        Me.TextBox_Amount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Amount.Location = New System.Drawing.Point(133, 200)
        Me.TextBox_Amount.Name = "TextBox_Amount"
        Me.TextBox_Amount.ReadOnly = True
        Me.TextBox_Amount.Size = New System.Drawing.Size(276, 20)
        Me.TextBox_Amount.TabIndex = 39
        Me.TextBox_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CheckBox_Gross
        '
        Me.CheckBox_Gross.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_Gross.AutoSize = True
        Me.CheckBox_Gross.Enabled = False
        Me.CheckBox_Gross.Location = New System.Drawing.Point(268, 147)
        Me.CheckBox_Gross.Name = "CheckBox_Gross"
        Me.CheckBox_Gross.Size = New System.Drawing.Size(65, 17)
        Me.CheckBox_Gross.TabIndex = 37
        Me.CheckBox_Gross.Text = "x_Brutto"
        Me.CheckBox_Gross.UseVisualStyleBackColor = True
        '
        'ComboBox_currency
        '
        Me.ComboBox_currency.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_currency.Enabled = False
        Me.ComboBox_currency.FormattingEnabled = True
        Me.ComboBox_currency.Location = New System.Drawing.Point(232, 145)
        Me.ComboBox_currency.Name = "ComboBox_currency"
        Me.ComboBox_currency.Size = New System.Drawing.Size(30, 21)
        Me.ComboBox_currency.TabIndex = 36
        '
        'TextBox_sum
        '
        Me.TextBox_sum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_sum.Location = New System.Drawing.Point(133, 146)
        Me.TextBox_sum.Name = "TextBox_sum"
        Me.TextBox_sum.ReadOnly = True
        Me.TextBox_sum.Size = New System.Drawing.Size(95, 20)
        Me.TextBox_sum.TabIndex = 35
        Me.TextBox_sum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label_Sum
        '
        Me.Label_Sum.AutoSize = True
        Me.Label_Sum.Location = New System.Drawing.Point(15, 148)
        Me.Label_Sum.Name = "Label_Sum"
        Me.Label_Sum.Size = New System.Drawing.Size(52, 13)
        Me.Label_Sum.TabIndex = 34
        Me.Label_Sum.Text = "x_Betrag:"
        '
        'Label_Payments
        '
        Me.Label_Payments.AutoSize = True
        Me.Label_Payments.Location = New System.Drawing.Point(15, 74)
        Me.Label_Payments.Name = "Label_Payments"
        Me.Label_Payments.Size = New System.Drawing.Size(72, 13)
        Me.Label_Payments.TabIndex = 33
        Me.Label_Payments.Text = "x_Zahlungen:"
        '
        'DataGridView_Payment
        '
        Me.DataGridView_Payment.AllowUserToAddRows = False
        Me.DataGridView_Payment.AllowUserToDeleteRows = False
        Me.DataGridView_Payment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView_Payment.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView_Payment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Payment.ContextMenuStrip = Me.ContextMenuStrip_Payment
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView_Payment.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView_Payment.Location = New System.Drawing.Point(133, 74)
        Me.DataGridView_Payment.Name = "DataGridView_Payment"
        Me.DataGridView_Payment.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView_Payment.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView_Payment.Size = New System.Drawing.Size(347, 68)
        Me.DataGridView_Payment.TabIndex = 32
        '
        'Label_TransactionDate
        '
        Me.Label_TransactionDate.AutoSize = True
        Me.Label_TransactionDate.Location = New System.Drawing.Point(15, 19)
        Me.Label_TransactionDate.Name = "Label_TransactionDate"
        Me.Label_TransactionDate.Size = New System.Drawing.Size(105, 13)
        Me.Label_TransactionDate.TabIndex = 30
        Me.Label_TransactionDate.Text = "x_Rechnungsdatum:"
        '
        'UserControl_TransactionDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Label_TransactionID)
        Me.Controls.Add(Me.TextBox_TransactionID)
        Me.Controls.Add(Me.Button_Date)
        Me.Controls.Add(Me.Button_Contractee)
        Me.Controls.Add(Me.Button_Contractor)
        Me.Controls.Add(Me.TextBox_Date)
        Me.Controls.Add(Me.Label_Rest)
        Me.Controls.Add(Me.TextBox_Rest)
        Me.Controls.Add(Me.ComboBox_TaxRate)
        Me.Controls.Add(Me.Label_TaxRate)
        Me.Controls.Add(Me.Label_Contractor)
        Me.Controls.Add(Me.Label_Contractee)
        Me.Controls.Add(Me.TextBox_Contractor)
        Me.Controls.Add(Me.TextBox_Contractee)
        Me.Controls.Add(Me.Label_amount)
        Me.Controls.Add(Me.ComboBox_unit)
        Me.Controls.Add(Me.TextBox_Amount)
        Me.Controls.Add(Me.CheckBox_Gross)
        Me.Controls.Add(Me.ComboBox_currency)
        Me.Controls.Add(Me.TextBox_sum)
        Me.Controls.Add(Me.Label_Sum)
        Me.Controls.Add(Me.Label_Payments)
        Me.Controls.Add(Me.DataGridView_Payment)
        Me.Controls.Add(Me.Label_TransactionDate)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_TransactionDetail"
        Me.Size = New System.Drawing.Size(492, 573)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.BindingSource_Payments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip_Payment.ResumeLayout(False)
        CType(Me.DataGridView_Payment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripProgressBar_Detail As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel_SemItems As System.Windows.Forms.Panel
    Friend WithEvents Label_SemItems As System.Windows.Forms.Label
    Friend WithEvents Panel_Offset As System.Windows.Forms.Panel
    Friend WithEvents Label_Offset As System.Windows.Forms.Label
    Friend WithEvents Label_TransactionID As System.Windows.Forms.Label
    Friend WithEvents TextBox_TransactionID As System.Windows.Forms.TextBox
    Friend WithEvents Button_Date As System.Windows.Forms.Button
    Friend WithEvents Button_Contractee As System.Windows.Forms.Button
    Friend WithEvents Button_Contractor As System.Windows.Forms.Button
    Friend WithEvents TextBox_Date As System.Windows.Forms.TextBox
    Friend WithEvents Label_Rest As System.Windows.Forms.Label
    Friend WithEvents TextBox_Rest As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox_TaxRate As System.Windows.Forms.ComboBox
    Friend WithEvents Timer_Data As System.Windows.Forms.Timer
    Friend WithEvents Timer_Menge As System.Windows.Forms.Timer
    Friend WithEvents Timer_Sum As System.Windows.Forms.Timer
    Friend WithEvents BindingSource_Payments As System.Windows.Forms.BindingSource
    Friend WithEvents Timer_TransactionID As System.Windows.Forms.Timer
    Friend WithEvents Label_TaxRate As System.Windows.Forms.Label
    Friend WithEvents Label_Contractor As System.Windows.Forms.Label
    Friend WithEvents Label_Contractee As System.Windows.Forms.Label
    Friend WithEvents NewPaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip_Payment As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ChangePaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemovePaymentToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CalculatePercentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ApplyBankTransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBox_Contractor As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Contractee As System.Windows.Forms.TextBox
    Friend WithEvents Label_amount As System.Windows.Forms.Label
    Friend WithEvents ComboBox_unit As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox_Amount As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox_Gross As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox_currency As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox_sum As System.Windows.Forms.TextBox
    Friend WithEvents Label_Sum As System.Windows.Forms.Label
    Friend WithEvents Label_Payments As System.Windows.Forms.Label
    Friend WithEvents DataGridView_Payment As System.Windows.Forms.DataGridView
    Friend WithEvents Label_TransactionDate As System.Windows.Forms.Label

End Class
