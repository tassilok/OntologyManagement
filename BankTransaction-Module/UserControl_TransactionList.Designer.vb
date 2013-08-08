<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_TransactionList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_TransactionList))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.BindingNavigator_Transactions = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.DtblBanktransactionsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_Transactions = New BankTransaction_Module.DataSet_Transactions()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripProgressBar_Transactions = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripLabel_Filter = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripTextBox_Filter = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel_OrderLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripTextBox_Order = New System.Windows.Forms.ToolStripTextBox()
        Me.DataGridView_Transactions = New System.Windows.Forms.DataGridView()
        Me.GUIDBankTransactionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Name_BankTransaction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUID_Type_BankTransaction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDAttributeBegZahlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BegZahlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDAttributeBuchungstextDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuchungsTextDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDAttributeInfoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InfoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDAttributeZahlungsausgangDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ZahlungsausgangDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GUIDAufragskontoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KontonummerAuftragskontoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUIDBLZAuftragskontoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BankleitzahlAuftragskontoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUIDPaymentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUIDGegenkontoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KontonummerGegenkontoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUIDBLZGegenkontoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BankleitzahlGegenkontoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUIDCurrencyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CurrencyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUIDAltCurrDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CurrencyAlternateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDAttributeValutaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValutatagDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDAttributeVerwendungszweckDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VerwendungszweckDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUIDAttributeBetragDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BetragDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip_BankTransactions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EqualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotEqualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.approximateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox_approximate = New System.Windows.Forms.ToolStripTextBox()
        Me.ContainsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToFilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Archive = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApplyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Import = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel_LastImportLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_LastImport = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_NoPayment = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSplitButton_Folder = New System.Windows.Forms.ToolStripSplitButton()
        Me.TransactionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArchiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer_BankTransactions = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripLabel_Database = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox_Database = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        CType(Me.BindingNavigator_Transactions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator_Transactions.SuspendLayout()
        CType(Me.DtblBanktransactionsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_Transactions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.DataGridView_Transactions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip_BankTransactions.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.BindingNavigator_Transactions)
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.ToolStrip2)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DataGridView_Transactions)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(1021, 381)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(1021, 431)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'BindingNavigator_Transactions
        '
        Me.BindingNavigator_Transactions.AddNewItem = Nothing
        Me.BindingNavigator_Transactions.BindingSource = Me.DtblBanktransactionsBindingSource
        Me.BindingNavigator_Transactions.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator_Transactions.DeleteItem = Nothing
        Me.BindingNavigator_Transactions.Dock = System.Windows.Forms.DockStyle.None
        Me.BindingNavigator_Transactions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.ToolStripSeparator3, Me.ToolStripButton_Close})
        Me.BindingNavigator_Transactions.Location = New System.Drawing.Point(3, 0)
        Me.BindingNavigator_Transactions.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator_Transactions.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator_Transactions.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator_Transactions.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator_Transactions.Name = "BindingNavigator_Transactions"
        Me.BindingNavigator_Transactions.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator_Transactions.Size = New System.Drawing.Size(268, 25)
        Me.BindingNavigator_Transactions.TabIndex = 0
        '
        'DtblBanktransactionsBindingSource
        '
        Me.DtblBanktransactionsBindingSource.DataMember = "dtbl_Banktransactions"
        Me.DtblBanktransactionsBindingSource.DataSource = Me.DataSet_Transactions
        '
        'DataSet_Transactions
        '
        Me.DataSet_Transactions.DataSetName = "DataSet_Transactions"
        Me.DataSet_Transactions.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(44, 22)
        Me.BindingNavigatorCountItem.Text = "von {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Die Gesamtanzahl der Elemente."
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Erste verschieben"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Vorherige verschieben"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Aktuelle Position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Nächste verschieben"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Letzte verschieben"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar_Transactions, Me.ToolStripLabel_Filter, Me.ToolStripTextBox_Filter, Me.ToolStripLabel_OrderLBL, Me.ToolStripTextBox_Order, Me.ToolStripSeparator4, Me.ToolStripLabel_Database, Me.ToolStripTextBox_Database})
        Me.ToolStrip2.Location = New System.Drawing.Point(271, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(750, 25)
        Me.ToolStrip2.TabIndex = 1
        '
        'ToolStripProgressBar_Transactions
        '
        Me.ToolStripProgressBar_Transactions.Name = "ToolStripProgressBar_Transactions"
        Me.ToolStripProgressBar_Transactions.Size = New System.Drawing.Size(100, 22)
        '
        'ToolStripLabel_Filter
        '
        Me.ToolStripLabel_Filter.Name = "ToolStripLabel_Filter"
        Me.ToolStripLabel_Filter.Size = New System.Drawing.Size(46, 22)
        Me.ToolStripLabel_Filter.Text = "x_Filter:"
        '
        'ToolStripTextBox_Filter
        '
        Me.ToolStripTextBox_Filter.Name = "ToolStripTextBox_Filter"
        Me.ToolStripTextBox_Filter.Size = New System.Drawing.Size(200, 25)
        '
        'ToolStripLabel_OrderLBL
        '
        Me.ToolStripLabel_OrderLBL.Name = "ToolStripLabel_OrderLBL"
        Me.ToolStripLabel_OrderLBL.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripLabel_OrderLBL.Text = "x_Order:"
        '
        'ToolStripTextBox_Order
        '
        Me.ToolStripTextBox_Order.Name = "ToolStripTextBox_Order"
        Me.ToolStripTextBox_Order.Size = New System.Drawing.Size(200, 25)
        '
        'DataGridView_Transactions
        '
        Me.DataGridView_Transactions.AllowUserToAddRows = False
        Me.DataGridView_Transactions.AllowUserToDeleteRows = False
        Me.DataGridView_Transactions.AutoGenerateColumns = False
        Me.DataGridView_Transactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Transactions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GUIDBankTransactionDataGridViewTextBoxColumn, Me.Name_BankTransaction, Me.GUID_Type_BankTransaction, Me.IDAttributeBegZahlDataGridViewTextBoxColumn, Me.BegZahlDataGridViewTextBoxColumn, Me.IDAttributeBuchungstextDataGridViewTextBoxColumn, Me.BuchungsTextDataGridViewTextBoxColumn, Me.IDAttributeInfoDataGridViewTextBoxColumn, Me.InfoDataGridViewTextBoxColumn, Me.IDAttributeZahlungsausgangDataGridViewTextBoxColumn, Me.ZahlungsausgangDataGridViewCheckBoxColumn, Me.GUIDAufragskontoDataGridViewTextBoxColumn, Me.KontonummerAuftragskontoDataGridViewTextBoxColumn, Me.GUIDBLZAuftragskontoDataGridViewTextBoxColumn, Me.BankleitzahlAuftragskontoDataGridViewTextBoxColumn, Me.GUIDPaymentDataGridViewTextBoxColumn, Me.PaymentDataGridViewTextBoxColumn, Me.GUIDGegenkontoDataGridViewTextBoxColumn, Me.KontonummerGegenkontoDataGridViewTextBoxColumn, Me.GUIDBLZGegenkontoDataGridViewTextBoxColumn, Me.BankleitzahlGegenkontoDataGridViewTextBoxColumn, Me.GUIDCurrencyDataGridViewTextBoxColumn, Me.CurrencyDataGridViewTextBoxColumn, Me.GUIDAltCurrDataGridViewTextBoxColumn, Me.CurrencyAlternateDataGridViewTextBoxColumn, Me.IDAttributeValutaDataGridViewTextBoxColumn, Me.ValutatagDataGridViewTextBoxColumn, Me.IDAttributeVerwendungszweckDataGridViewTextBoxColumn, Me.VerwendungszweckDataGridViewTextBoxColumn, Me.GUIDAttributeBetragDataGridViewTextBoxColumn, Me.BetragDataGridViewTextBoxColumn})
        Me.DataGridView_Transactions.ContextMenuStrip = Me.ContextMenuStrip_BankTransactions
        Me.DataGridView_Transactions.DataSource = Me.DtblBanktransactionsBindingSource
        Me.DataGridView_Transactions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_Transactions.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_Transactions.Name = "DataGridView_Transactions"
        Me.DataGridView_Transactions.ReadOnly = True
        Me.DataGridView_Transactions.Size = New System.Drawing.Size(1021, 381)
        Me.DataGridView_Transactions.TabIndex = 0
        '
        'GUIDBankTransactionDataGridViewTextBoxColumn
        '
        Me.GUIDBankTransactionDataGridViewTextBoxColumn.DataPropertyName = "GUID_BankTransaction"
        Me.GUIDBankTransactionDataGridViewTextBoxColumn.HeaderText = "GUID_BankTransaction"
        Me.GUIDBankTransactionDataGridViewTextBoxColumn.Name = "GUIDBankTransactionDataGridViewTextBoxColumn"
        Me.GUIDBankTransactionDataGridViewTextBoxColumn.ReadOnly = True
        Me.GUIDBankTransactionDataGridViewTextBoxColumn.Visible = False
        '
        'Name_BankTransaction
        '
        Me.Name_BankTransaction.DataPropertyName = "DataColumn1"
        Me.Name_BankTransaction.HeaderText = "Name_BankTransactions"
        Me.Name_BankTransaction.Name = "Name_BankTransaction"
        Me.Name_BankTransaction.ReadOnly = True
        Me.Name_BankTransaction.Visible = False
        '
        'GUID_Type_BankTransaction
        '
        Me.GUID_Type_BankTransaction.DataPropertyName = "GUID_Type_BankTransaction"
        Me.GUID_Type_BankTransaction.HeaderText = "GUID_Type_BankTransaction"
        Me.GUID_Type_BankTransaction.Name = "GUID_Type_BankTransaction"
        Me.GUID_Type_BankTransaction.ReadOnly = True
        Me.GUID_Type_BankTransaction.Visible = False
        '
        'IDAttributeBegZahlDataGridViewTextBoxColumn
        '
        Me.IDAttributeBegZahlDataGridViewTextBoxColumn.DataPropertyName = "ID_Attribute_BegZahl"
        Me.IDAttributeBegZahlDataGridViewTextBoxColumn.HeaderText = "ID_Attribute_BegZahl"
        Me.IDAttributeBegZahlDataGridViewTextBoxColumn.Name = "IDAttributeBegZahlDataGridViewTextBoxColumn"
        Me.IDAttributeBegZahlDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDAttributeBegZahlDataGridViewTextBoxColumn.Visible = False
        '
        'BegZahlDataGridViewTextBoxColumn
        '
        Me.BegZahlDataGridViewTextBoxColumn.DataPropertyName = "BegZahl"
        Me.BegZahlDataGridViewTextBoxColumn.HeaderText = "BegZahl"
        Me.BegZahlDataGridViewTextBoxColumn.Name = "BegZahlDataGridViewTextBoxColumn"
        Me.BegZahlDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IDAttributeBuchungstextDataGridViewTextBoxColumn
        '
        Me.IDAttributeBuchungstextDataGridViewTextBoxColumn.DataPropertyName = "ID_Attribute_Buchungstext"
        Me.IDAttributeBuchungstextDataGridViewTextBoxColumn.HeaderText = "ID_Attribute_Buchungstext"
        Me.IDAttributeBuchungstextDataGridViewTextBoxColumn.Name = "IDAttributeBuchungstextDataGridViewTextBoxColumn"
        Me.IDAttributeBuchungstextDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDAttributeBuchungstextDataGridViewTextBoxColumn.Visible = False
        '
        'BuchungsTextDataGridViewTextBoxColumn
        '
        Me.BuchungsTextDataGridViewTextBoxColumn.DataPropertyName = "BuchungsText"
        Me.BuchungsTextDataGridViewTextBoxColumn.HeaderText = "BuchungsText"
        Me.BuchungsTextDataGridViewTextBoxColumn.Name = "BuchungsTextDataGridViewTextBoxColumn"
        Me.BuchungsTextDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IDAttributeInfoDataGridViewTextBoxColumn
        '
        Me.IDAttributeInfoDataGridViewTextBoxColumn.DataPropertyName = "ID_Attribute_Info"
        Me.IDAttributeInfoDataGridViewTextBoxColumn.HeaderText = "ID_Attribute_Info"
        Me.IDAttributeInfoDataGridViewTextBoxColumn.Name = "IDAttributeInfoDataGridViewTextBoxColumn"
        Me.IDAttributeInfoDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDAttributeInfoDataGridViewTextBoxColumn.Visible = False
        '
        'InfoDataGridViewTextBoxColumn
        '
        Me.InfoDataGridViewTextBoxColumn.DataPropertyName = "Info"
        Me.InfoDataGridViewTextBoxColumn.HeaderText = "Info"
        Me.InfoDataGridViewTextBoxColumn.Name = "InfoDataGridViewTextBoxColumn"
        Me.InfoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IDAttributeZahlungsausgangDataGridViewTextBoxColumn
        '
        Me.IDAttributeZahlungsausgangDataGridViewTextBoxColumn.DataPropertyName = "ID_Attribute_Zahlungsausgang"
        Me.IDAttributeZahlungsausgangDataGridViewTextBoxColumn.HeaderText = "ID_Attribute_Zahlungsausgang"
        Me.IDAttributeZahlungsausgangDataGridViewTextBoxColumn.Name = "IDAttributeZahlungsausgangDataGridViewTextBoxColumn"
        Me.IDAttributeZahlungsausgangDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDAttributeZahlungsausgangDataGridViewTextBoxColumn.Visible = False
        '
        'ZahlungsausgangDataGridViewCheckBoxColumn
        '
        Me.ZahlungsausgangDataGridViewCheckBoxColumn.DataPropertyName = "Zahlungsausgang"
        Me.ZahlungsausgangDataGridViewCheckBoxColumn.HeaderText = "Zahlungsausgang"
        Me.ZahlungsausgangDataGridViewCheckBoxColumn.Name = "ZahlungsausgangDataGridViewCheckBoxColumn"
        Me.ZahlungsausgangDataGridViewCheckBoxColumn.ReadOnly = True
        '
        'GUIDAufragskontoDataGridViewTextBoxColumn
        '
        Me.GUIDAufragskontoDataGridViewTextBoxColumn.DataPropertyName = "GUID_Aufragskonto"
        Me.GUIDAufragskontoDataGridViewTextBoxColumn.HeaderText = "GUID_Aufragskonto"
        Me.GUIDAufragskontoDataGridViewTextBoxColumn.Name = "GUIDAufragskontoDataGridViewTextBoxColumn"
        Me.GUIDAufragskontoDataGridViewTextBoxColumn.ReadOnly = True
        Me.GUIDAufragskontoDataGridViewTextBoxColumn.Visible = False
        '
        'KontonummerAuftragskontoDataGridViewTextBoxColumn
        '
        Me.KontonummerAuftragskontoDataGridViewTextBoxColumn.DataPropertyName = "Kontonummer_Auftragskonto"
        Me.KontonummerAuftragskontoDataGridViewTextBoxColumn.HeaderText = "Kontonummer_Auftragskonto"
        Me.KontonummerAuftragskontoDataGridViewTextBoxColumn.Name = "KontonummerAuftragskontoDataGridViewTextBoxColumn"
        Me.KontonummerAuftragskontoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GUIDBLZAuftragskontoDataGridViewTextBoxColumn
        '
        Me.GUIDBLZAuftragskontoDataGridViewTextBoxColumn.DataPropertyName = "GUID_BLZ_Auftragskonto"
        Me.GUIDBLZAuftragskontoDataGridViewTextBoxColumn.HeaderText = "GUID_BLZ_Auftragskonto"
        Me.GUIDBLZAuftragskontoDataGridViewTextBoxColumn.Name = "GUIDBLZAuftragskontoDataGridViewTextBoxColumn"
        Me.GUIDBLZAuftragskontoDataGridViewTextBoxColumn.ReadOnly = True
        Me.GUIDBLZAuftragskontoDataGridViewTextBoxColumn.Visible = False
        '
        'BankleitzahlAuftragskontoDataGridViewTextBoxColumn
        '
        Me.BankleitzahlAuftragskontoDataGridViewTextBoxColumn.DataPropertyName = "Bankleitzahl_Auftragskonto"
        Me.BankleitzahlAuftragskontoDataGridViewTextBoxColumn.HeaderText = "Bankleitzahl_Auftragskonto"
        Me.BankleitzahlAuftragskontoDataGridViewTextBoxColumn.Name = "BankleitzahlAuftragskontoDataGridViewTextBoxColumn"
        Me.BankleitzahlAuftragskontoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GUIDPaymentDataGridViewTextBoxColumn
        '
        Me.GUIDPaymentDataGridViewTextBoxColumn.DataPropertyName = "GUID_Payment"
        Me.GUIDPaymentDataGridViewTextBoxColumn.HeaderText = "GUID_Payment"
        Me.GUIDPaymentDataGridViewTextBoxColumn.Name = "GUIDPaymentDataGridViewTextBoxColumn"
        Me.GUIDPaymentDataGridViewTextBoxColumn.ReadOnly = True
        Me.GUIDPaymentDataGridViewTextBoxColumn.Visible = False
        '
        'PaymentDataGridViewTextBoxColumn
        '
        Me.PaymentDataGridViewTextBoxColumn.DataPropertyName = "Payment"
        Me.PaymentDataGridViewTextBoxColumn.HeaderText = "Payment"
        Me.PaymentDataGridViewTextBoxColumn.Name = "PaymentDataGridViewTextBoxColumn"
        Me.PaymentDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GUIDGegenkontoDataGridViewTextBoxColumn
        '
        Me.GUIDGegenkontoDataGridViewTextBoxColumn.DataPropertyName = "GUID_Gegenkonto"
        Me.GUIDGegenkontoDataGridViewTextBoxColumn.HeaderText = "GUID_Gegenkonto"
        Me.GUIDGegenkontoDataGridViewTextBoxColumn.Name = "GUIDGegenkontoDataGridViewTextBoxColumn"
        Me.GUIDGegenkontoDataGridViewTextBoxColumn.ReadOnly = True
        Me.GUIDGegenkontoDataGridViewTextBoxColumn.Visible = False
        '
        'KontonummerGegenkontoDataGridViewTextBoxColumn
        '
        Me.KontonummerGegenkontoDataGridViewTextBoxColumn.DataPropertyName = "Kontonummer_Gegenkonto"
        Me.KontonummerGegenkontoDataGridViewTextBoxColumn.HeaderText = "Kontonummer_Gegenkonto"
        Me.KontonummerGegenkontoDataGridViewTextBoxColumn.Name = "KontonummerGegenkontoDataGridViewTextBoxColumn"
        Me.KontonummerGegenkontoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GUIDBLZGegenkontoDataGridViewTextBoxColumn
        '
        Me.GUIDBLZGegenkontoDataGridViewTextBoxColumn.DataPropertyName = "GUID_BLZ_Gegenkonto"
        Me.GUIDBLZGegenkontoDataGridViewTextBoxColumn.HeaderText = "GUID_BLZ_Gegenkonto"
        Me.GUIDBLZGegenkontoDataGridViewTextBoxColumn.Name = "GUIDBLZGegenkontoDataGridViewTextBoxColumn"
        Me.GUIDBLZGegenkontoDataGridViewTextBoxColumn.ReadOnly = True
        Me.GUIDBLZGegenkontoDataGridViewTextBoxColumn.Visible = False
        '
        'BankleitzahlGegenkontoDataGridViewTextBoxColumn
        '
        Me.BankleitzahlGegenkontoDataGridViewTextBoxColumn.DataPropertyName = "Bankleitzahl_Gegenkonto"
        Me.BankleitzahlGegenkontoDataGridViewTextBoxColumn.HeaderText = "Bankleitzahl_Gegenkonto"
        Me.BankleitzahlGegenkontoDataGridViewTextBoxColumn.Name = "BankleitzahlGegenkontoDataGridViewTextBoxColumn"
        Me.BankleitzahlGegenkontoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GUIDCurrencyDataGridViewTextBoxColumn
        '
        Me.GUIDCurrencyDataGridViewTextBoxColumn.DataPropertyName = "GUID_Currency"
        Me.GUIDCurrencyDataGridViewTextBoxColumn.HeaderText = "GUID_Currency"
        Me.GUIDCurrencyDataGridViewTextBoxColumn.Name = "GUIDCurrencyDataGridViewTextBoxColumn"
        Me.GUIDCurrencyDataGridViewTextBoxColumn.ReadOnly = True
        Me.GUIDCurrencyDataGridViewTextBoxColumn.Visible = False
        '
        'CurrencyDataGridViewTextBoxColumn
        '
        Me.CurrencyDataGridViewTextBoxColumn.DataPropertyName = "Currency"
        Me.CurrencyDataGridViewTextBoxColumn.HeaderText = "Currency"
        Me.CurrencyDataGridViewTextBoxColumn.Name = "CurrencyDataGridViewTextBoxColumn"
        Me.CurrencyDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GUIDAltCurrDataGridViewTextBoxColumn
        '
        Me.GUIDAltCurrDataGridViewTextBoxColumn.DataPropertyName = "GUID_AltCurr"
        Me.GUIDAltCurrDataGridViewTextBoxColumn.HeaderText = "GUID_AltCurr"
        Me.GUIDAltCurrDataGridViewTextBoxColumn.Name = "GUIDAltCurrDataGridViewTextBoxColumn"
        Me.GUIDAltCurrDataGridViewTextBoxColumn.ReadOnly = True
        Me.GUIDAltCurrDataGridViewTextBoxColumn.Visible = False
        '
        'CurrencyAlternateDataGridViewTextBoxColumn
        '
        Me.CurrencyAlternateDataGridViewTextBoxColumn.DataPropertyName = "Currency_Alternate"
        Me.CurrencyAlternateDataGridViewTextBoxColumn.HeaderText = "Currency_Alternate"
        Me.CurrencyAlternateDataGridViewTextBoxColumn.Name = "CurrencyAlternateDataGridViewTextBoxColumn"
        Me.CurrencyAlternateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IDAttributeValutaDataGridViewTextBoxColumn
        '
        Me.IDAttributeValutaDataGridViewTextBoxColumn.DataPropertyName = "ID_Attribute_Valuta"
        Me.IDAttributeValutaDataGridViewTextBoxColumn.HeaderText = "ID_Attribute_Valuta"
        Me.IDAttributeValutaDataGridViewTextBoxColumn.Name = "IDAttributeValutaDataGridViewTextBoxColumn"
        Me.IDAttributeValutaDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDAttributeValutaDataGridViewTextBoxColumn.Visible = False
        '
        'ValutatagDataGridViewTextBoxColumn
        '
        Me.ValutatagDataGridViewTextBoxColumn.DataPropertyName = "Valutatag"
        Me.ValutatagDataGridViewTextBoxColumn.HeaderText = "Valutatag"
        Me.ValutatagDataGridViewTextBoxColumn.Name = "ValutatagDataGridViewTextBoxColumn"
        Me.ValutatagDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IDAttributeVerwendungszweckDataGridViewTextBoxColumn
        '
        Me.IDAttributeVerwendungszweckDataGridViewTextBoxColumn.DataPropertyName = "ID_Attribute_Verwendungszweck"
        Me.IDAttributeVerwendungszweckDataGridViewTextBoxColumn.HeaderText = "ID_Attribute_Verwendungszweck"
        Me.IDAttributeVerwendungszweckDataGridViewTextBoxColumn.Name = "IDAttributeVerwendungszweckDataGridViewTextBoxColumn"
        Me.IDAttributeVerwendungszweckDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDAttributeVerwendungszweckDataGridViewTextBoxColumn.Visible = False
        '
        'VerwendungszweckDataGridViewTextBoxColumn
        '
        Me.VerwendungszweckDataGridViewTextBoxColumn.DataPropertyName = "Verwendungszweck"
        Me.VerwendungszweckDataGridViewTextBoxColumn.HeaderText = "Verwendungszweck"
        Me.VerwendungszweckDataGridViewTextBoxColumn.Name = "VerwendungszweckDataGridViewTextBoxColumn"
        Me.VerwendungszweckDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GUIDAttributeBetragDataGridViewTextBoxColumn
        '
        Me.GUIDAttributeBetragDataGridViewTextBoxColumn.DataPropertyName = "GUID_Attribute_Betrag"
        Me.GUIDAttributeBetragDataGridViewTextBoxColumn.HeaderText = "GUID_Attribute_Betrag"
        Me.GUIDAttributeBetragDataGridViewTextBoxColumn.Name = "GUIDAttributeBetragDataGridViewTextBoxColumn"
        Me.GUIDAttributeBetragDataGridViewTextBoxColumn.ReadOnly = True
        Me.GUIDAttributeBetragDataGridViewTextBoxColumn.Visible = False
        '
        'BetragDataGridViewTextBoxColumn
        '
        Me.BetragDataGridViewTextBoxColumn.DataPropertyName = "Betrag"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.BetragDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.BetragDataGridViewTextBoxColumn.HeaderText = "Betrag"
        Me.BetragDataGridViewTextBoxColumn.Name = "BetragDataGridViewTextBoxColumn"
        Me.BetragDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ContextMenuStrip_BankTransactions
        '
        Me.ContextMenuStrip_BankTransactions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FilterToolStripMenuItem, Me.EditToolStripMenuItem, Me.ApplyToolStripMenuItem})
        Me.ContextMenuStrip_BankTransactions.Name = "ContextMenuStrip_BankTransactions"
        Me.ContextMenuStrip_BankTransactions.Size = New System.Drawing.Size(116, 70)
        '
        'FilterToolStripMenuItem
        '
        Me.FilterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EqualToolStripMenuItem, Me.NotEqualToolStripMenuItem, Me.approximateToolStripMenuItem, Me.ContainsToolStripMenuItem, Me.ClearToolStripMenuItem, Me.ToFilterToolStripMenuItem, Me.ToOrderToolStripMenuItem})
        Me.FilterToolStripMenuItem.Name = "FilterToolStripMenuItem"
        Me.FilterToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.FilterToolStripMenuItem.Text = "x_Filter"
        '
        'EqualToolStripMenuItem
        '
        Me.EqualToolStripMenuItem.Name = "EqualToolStripMenuItem"
        Me.EqualToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.EqualToolStripMenuItem.Text = "x_equal"
        '
        'NotEqualToolStripMenuItem
        '
        Me.NotEqualToolStripMenuItem.Name = "NotEqualToolStripMenuItem"
        Me.NotEqualToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.NotEqualToolStripMenuItem.Text = "x_not equal"
        '
        'approximateToolStripMenuItem
        '
        Me.approximateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox_approximate})
        Me.approximateToolStripMenuItem.Name = "approximateToolStripMenuItem"
        Me.approximateToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.approximateToolStripMenuItem.Text = "x_approximate"
        '
        'ToolStripTextBox_approximate
        '
        Me.ToolStripTextBox_approximate.Name = "ToolStripTextBox_approximate"
        Me.ToolStripTextBox_approximate.Size = New System.Drawing.Size(100, 23)
        '
        'ContainsToolStripMenuItem
        '
        Me.ContainsToolStripMenuItem.Name = "ContainsToolStripMenuItem"
        Me.ContainsToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ContainsToolStripMenuItem.Text = "x_Contains"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Image = Global.BankTransaction_Module.My.Resources.Resources.delete
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'ToFilterToolStripMenuItem
        '
        Me.ToFilterToolStripMenuItem.Name = "ToFilterToolStripMenuItem"
        Me.ToFilterToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ToFilterToolStripMenuItem.Text = "To Filter"
        '
        'ToOrderToolStripMenuItem
        '
        Me.ToOrderToolStripMenuItem.Name = "ToOrderToolStripMenuItem"
        Me.ToOrderToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ToOrderToolStripMenuItem.Text = "To Order"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem_Archive})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.EditToolStripMenuItem.Text = "x_Edit"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.CopyToolStripMenuItem.Text = "x_Copy"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.DeleteToolStripMenuItem.Text = "x_Delete"
        '
        'ToolStripMenuItem_Archive
        '
        Me.ToolStripMenuItem_Archive.Name = "ToolStripMenuItem_Archive"
        Me.ToolStripMenuItem_Archive.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripMenuItem_Archive.Text = "x_Archive"
        '
        'ApplyToolStripMenuItem
        '
        Me.ApplyToolStripMenuItem.Name = "ApplyToolStripMenuItem"
        Me.ApplyToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.ApplyToolStripMenuItem.Text = "x_Apply"
        Me.ApplyToolStripMenuItem.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Import, Me.ToolStripLabel_LastImportLBL, Me.ToolStripLabel_LastImport, Me.ToolStripSeparator1, Me.ToolStripButton_NoPayment, Me.ToolStripSeparator2, Me.ToolStripSplitButton_Folder})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(326, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripButton_Import
        '
        Me.ToolStripButton_Import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Import.Image = CType(resources.GetObject("ToolStripButton_Import.Image"), System.Drawing.Image)
        Me.ToolStripButton_Import.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Import.Name = "ToolStripButton_Import"
        Me.ToolStripButton_Import.Size = New System.Drawing.Size(57, 22)
        Me.ToolStripButton_Import.Text = "x_Import"
        '
        'ToolStripLabel_LastImportLBL
        '
        Me.ToolStripLabel_LastImportLBL.Name = "ToolStripLabel_LastImportLBL"
        Me.ToolStripLabel_LastImportLBL.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripLabel_LastImportLBL.Text = "x_Last Import:"
        '
        'ToolStripLabel_LastImport
        '
        Me.ToolStripLabel_LastImport.Name = "ToolStripLabel_LastImport"
        Me.ToolStripLabel_LastImport.Size = New System.Drawing.Size(12, 22)
        Me.ToolStripLabel_LastImport.Text = "-"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_NoPayment
        '
        Me.ToolStripButton_NoPayment.Checked = True
        Me.ToolStripButton_NoPayment.CheckOnClick = True
        Me.ToolStripButton_NoPayment.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripButton_NoPayment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_NoPayment.Image = CType(resources.GetObject("ToolStripButton_NoPayment.Image"), System.Drawing.Image)
        Me.ToolStripButton_NoPayment.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_NoPayment.Name = "ToolStripButton_NoPayment"
        Me.ToolStripButton_NoPayment.Size = New System.Drawing.Size(87, 22)
        Me.ToolStripButton_NoPayment.Text = "x_No Payment"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSplitButton_Folder
        '
        Me.ToolStripSplitButton_Folder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripSplitButton_Folder.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TransactionsToolStripMenuItem, Me.ArchiveToolStripMenuItem})
        Me.ToolStripSplitButton_Folder.Image = CType(resources.GetObject("ToolStripSplitButton_Folder.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton_Folder.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton_Folder.Name = "ToolStripSplitButton_Folder"
        Me.ToolStripSplitButton_Folder.Size = New System.Drawing.Size(66, 22)
        Me.ToolStripSplitButton_Folder.Text = "x_Folder"
        '
        'TransactionsToolStripMenuItem
        '
        Me.TransactionsToolStripMenuItem.Checked = True
        Me.TransactionsToolStripMenuItem.CheckOnClick = True
        Me.TransactionsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TransactionsToolStripMenuItem.Name = "TransactionsToolStripMenuItem"
        Me.TransactionsToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.TransactionsToolStripMenuItem.Text = "x_Transactions"
        '
        'ArchiveToolStripMenuItem
        '
        Me.ArchiveToolStripMenuItem.CheckOnClick = True
        Me.ArchiveToolStripMenuItem.Name = "ArchiveToolStripMenuItem"
        Me.ArchiveToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.ArchiveToolStripMenuItem.Text = "x_Archive"
        '
        'Timer_BankTransactions
        '
        Me.Timer_BankTransactions.Interval = 300
        '
        'ToolStripLabel_Database
        '
        Me.ToolStripLabel_Database.Name = "ToolStripLabel_Database"
        Me.ToolStripLabel_Database.Size = New System.Drawing.Size(68, 22)
        Me.ToolStripLabel_Database.Text = "x_Database:"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox_Database
        '
        Me.ToolStripTextBox_Database.Name = "ToolStripTextBox_Database"
        Me.ToolStripTextBox_Database.ReadOnly = True
        Me.ToolStripTextBox_Database.Size = New System.Drawing.Size(200, 23)
        '
        'UserControl_TransactionList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_TransactionList"
        Me.Size = New System.Drawing.Size(1021, 431)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        CType(Me.BindingNavigator_Transactions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator_Transactions.ResumeLayout(False)
        Me.BindingNavigator_Transactions.PerformLayout()
        CType(Me.DtblBanktransactionsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_Transactions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.DataGridView_Transactions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip_BankTransactions.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents BindingNavigator_Transactions As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Import As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel_LastImportLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_LastImport As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_NoPayment As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSplitButton_Folder As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents TransactionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArchiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridView_Transactions As System.Windows.Forms.DataGridView
    Friend WithEvents DtblBanktransactionsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet_Transactions As BankTransaction_Module.DataSet_Transactions
    Friend WithEvents Timer_BankTransactions As System.Windows.Forms.Timer
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripProgressBar_Transactions As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripLabel_Filter As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox_Filter As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel_OrderLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox_Order As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ContextMenuStrip_BankTransactions As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents FilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EqualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotEqualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents approximateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripTextBox_approximate As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ContainsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Archive As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ApplyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToFilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GUIDBankTransactionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Name_BankTransaction As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUID_Type_BankTransaction As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDAttributeBegZahlDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BegZahlDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDAttributeBuchungstextDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuchungsTextDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDAttributeInfoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InfoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDAttributeZahlungsausgangDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ZahlungsausgangDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents GUIDAufragskontoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KontonummerAuftragskontoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUIDBLZAuftragskontoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BankleitzahlAuftragskontoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUIDPaymentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUIDGegenkontoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KontonummerGegenkontoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUIDBLZGegenkontoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BankleitzahlGegenkontoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUIDCurrencyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrencyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUIDAltCurrDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrencyAlternateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDAttributeValutaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValutatagDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDAttributeVerwendungszweckDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerwendungszweckDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUIDAttributeBetragDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BetragDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel_Database As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox_Database As System.Windows.Forms.ToolStripTextBox

End Class
