Imports Structure_Module
Imports OntologyClasses.BaseClasses

Public Class UserControl_FinancialTransactionList

    Private objLocalConfig As clsLocalConfig

    Private objOItem_Class As clsOntologyItem

    Private objDataWork_Transaction As clsDataWork_Transaction

    Private objOList_Transactions As SortableBindingList(Of clsFinancialTransaction)

    Private objOItem_Result_Open As clsOntologyItem

    Public Event GeneralError()

    Public Event SelectedTransaction(OItem_FinancialTransaction As clsOntologyItem)

    Private objOItem_Selected As clsOntologyItem

    Public Sub New(LocalConfig As clsLocalConfig, OItem_Class As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objOItem_Class = OItem_Class
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objDataWork_Transaction = New clsDataWork_Transaction(objLocalConfig)
        
        objDataWork_Transaction.get_Data_TransactionDetail(Nothing, objLocalConfig.OItem_Class_Financial_Transaction)
        objOItem_Result_Open = objDataWork_Transaction.OItem_Result_FinancialTransaction
        While objOItem_Result_Open.GUID = objLocalConfig.Globals.LState_Nothing.GUID
            objOItem_Result_Open = objDataWork_Transaction.OItem_Result_FinancialTransaction
        End While

        If objOItem_Result_Open.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            RaiseEvent GeneralError()
        End If
    End Sub

    Public Sub Initialize_FinanicalTransaction(OItem_Selected As clsOntologyItem, Optional OList_RemoveTransaction As List(Of clsFinancialTransaction) = Nothing)

        objOItem_Selected = OItem_Selected


        Dim objOList_SemItemList = objDataWork_Transaction.GetSubData_SemItems(objOItem_Class)
        Dim sum As Double = 0

        If Not objOList_SemItemList Is Nothing Then
            If OItem_Selected Is Nothing Then
                objOList_Transactions = objDataWork_Transaction.FinancialTransactionList()
            Else
                objOList_Transactions = New SortableBindingList(Of clsFinancialTransaction)( _
                    From objTransaction In objDataWork_Transaction.FinancialTransactionList
                    Join objSemItemRel In objOList_SemItemList. _
                    Where(Function(fi) fi.ID_Other = OItem_Selected.GUID).ToList() On objTransaction.ID_FinancialTransaction Equals objSemItemRel.ID_Object
                    Select objTransaction)
            End If

            If OList_RemoveTransaction Is Nothing Then
                DataGridView_FinancialTransaction.DataSource = objOList_Transactions
            Else
                DataGridView_FinancialTransaction.DataSource = New SortableBindingList(Of clsFinancialTransaction)(From objTrans In objOList_Transactions
                                                               Group Join objRemoTrans In OList_RemoveTransaction On objTrans.ID_FinancialTransaction Equals objRemoTrans.ID_FinancialTransaction Into RemoveTrans = Group
                                                               From objRemoTrans In RemoveTrans.DefaultIfEmpty()
                                                               Where objRemoTrans Is Nothing
                                                               Select objTrans)
            End If

            For Each col As DataGridViewColumn In DataGridView_FinancialTransaction.Columns
                If col.Name.StartsWith("ID_") Then
                    col.Visible = False
                End If
            Next
            Dim oList_Rows = DataGridView_FinancialTransaction.Rows.OfType(Of DataGridViewRow).ToList()
            Dim objOList_Trans As New List(Of clsFinancialTransaction)
            objOList_Trans = oList_Rows.Select(Function(r) CType(r.DataBoundItem, clsFinancialTransaction)).ToList()
            sum = objOList_Trans.Sum(Function(fi) fi.Sum).Value


        Else
            DataGridView_FinancialTransaction.DataSource = Nothing
            MsgBox("Die Daten konnten nicht ermittelt werden!", MsgBoxStyle.Exclamation)
        End If

        ToolStripTextBox_Sum.Text = sum.ToString("N2")
        ToolStripLabel_Count.Text = DataGridView_FinancialTransaction.RowCount

    End Sub

    
    Private Sub DataGridView_FinancialTransaction_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_FinancialTransaction.RowHeaderMouseDoubleClick
        Dim objDGVR As DataGridViewRow = DataGridView_FinancialTransaction.Rows(e.RowIndex)
        Dim objFinancialTransaction As clsFinancialTransaction = objDGVR.DataBoundItem

        RaiseEvent SelectedTransaction(New clsOntologyItem With {.GUID = objFinancialTransaction.ID_FinancialTransaction, _
                                                                 .Name = objFinancialTransaction.Name_FinancialTransaction, _
                                                                 .GUID_Parent = objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                                 .Type = objLocalConfig.Globals.Type_Object})

    End Sub

    Private Sub ContextMenuStrip_Transactions_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Transactions.Opening
        RemoveFromListToolStripMenuItem.Enabled = False
        If DataGridView_FinancialTransaction.SelectedRows.Count > 0 Then
            RemoveFromListToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub RemoveFromListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveFromListToolStripMenuItem.Click
        Dim oList_Rows = DataGridView_FinancialTransaction.SelectedRows.OfType(Of DataGridViewRow).ToList()
        Dim objOList_Transactions As New List(Of clsFinancialTransaction)
        objOList_Transactions = oList_Rows.Select(Function(r) CType(r.DataBoundItem, clsFinancialTransaction)).ToList()
        Initialize_FinanicalTransaction(objOItem_Selected, objOList_Transactions)
    End Sub
End Class
