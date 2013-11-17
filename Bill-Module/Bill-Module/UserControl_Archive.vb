Imports Structure_Module
Imports OntologyClasses.BaseClasses
Imports Ontology_Module
Public Class UserControl_Archive
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_FinancialTransaction As clsDataWork_Transaction
    Private objDBLevel_FinancialTransactionSave As clsDBLevel
    Private boolArchive As Boolean

    Public Sub New(LocalConfig As clsLocalConfig, Optional showArchive As Boolean = False)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        boolArchive = showArchive
        objLocalConfig = LocalConfig
        objDataWork_FinancialTransaction = New clsDataWork_Transaction(objLocalConfig)
        objDBLevel_FinancialTransactionSave = New clsDBLevel(objLocalConfig.Globals)
        Initialize()
    End Sub

    Private Sub Initialize()
        DataGridView_Transactions.DataSource = Nothing
        objDataWork_FinancialTransaction.get_Data_TransactionDetail(Nothing, If(boolArchive, objLocalConfig.OItem_Class_Financial_Transaction___Archive, objLocalConfig.OItem_Class_Financial_Transaction))
        Timer_Data.Start()
    End Sub

    Private Sub Timer_Data_Tick(sender As Object, e As EventArgs) Handles Timer_Data.Tick
        If objDataWork_FinancialTransaction.OItem_Result_FinancialTransaction.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Timer_Data.Stop()
            ToolStripProgressBar_Load.Value = 0
            DataGridView_Transactions.DataSource = objDataWork_FinancialTransaction.FinancialTransactionList
            DataGridView_Transactions.Columns(0).Visible = False
            DataGridView_Transactions.Columns(2).Visible = False
            DataGridView_Transactions.Columns(4).Visible = False
            DataGridView_Transactions.Columns(6).Visible = False
            DataGridView_Transactions.Columns(8).Visible = False
            DataGridView_Transactions.Columns(10).Visible = False
            DataGridView_Transactions.Columns(12).Visible = False
            DataGridView_Transactions.Columns(14).Visible = False
            DataGridView_Transactions.Columns(16).Visible = False
            DataGridView_Transactions.Columns(18).Visible = False
            DataGridView_Transactions.Columns(20).Visible = False
            DataGridView_Transactions.Columns(22).Visible = False

        ElseIf objDataWork_FinancialTransaction.OItem_Result_FinancialTransaction.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            Timer_Data.Stop()
            ToolStripProgressBar_Load.Value = 0
        Else
            ToolStripProgressBar_Load.Value = 50
        End If
    End Sub

    Private Sub ToolStripButton_Move_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Move.Click
        If MsgBox("Wollen Sie die Elemente wirklich verschieben?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim objOList_TransactionsToMove As List(Of clsOntologyItem) = New List(Of clsOntologyItem)
            Dim objOItem_Class_Transactions = If(boolArchive, objLocalConfig.OItem_Class_Financial_Transaction, objLocalConfig.OItem_Class_Financial_Transaction___Archive)


            For Each objDGVR As DataGridViewRow In DataGridView_Transactions.SelectedRows
                Dim objFinancialTransaction As clsFinancialTransaction = CType(objDGVR.DataBoundItem, clsFinancialTransaction)
                objOList_TransactionsToMove.Add(New clsOntologyItem With {.GUID = objFinancialTransaction.ID_FinancialTransaction, _
                                                                          .Name = objFinancialTransaction.Name_FinancialTransaction, _
                                                                          .GUID_Parent = objOItem_Class_Transactions.GUID, _
                                                                          .Type = objLocalConfig.Globals.Type_Object})

            Next

            Dim objOItem_Result = objDBLevel_FinancialTransactionSave.save_Objects(objOList_TransactionsToMove)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Die Elemente konnten nicht verschoben werden!", MsgBoxStyle.Exclamation)

            End If

            Initialize()
        End If

        
    End Sub

    Private Sub DataGridView_Transactions_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView_Transactions.SelectionChanged
        ToolStripButton_Move.Enabled = False
        If DataGridView_Transactions.SelectedRows.Count > 0 Then
            ToolStripButton_Move.Enabled = True
        End If
    End Sub
End Class
