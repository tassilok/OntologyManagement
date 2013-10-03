Imports Ontolog_Module
Imports OntologyClasses.BaseClasses
Public Class UserControl_TransactionList

    Private objLocalConfig As clsLocalConfig
    Private objDataWork_BankTransactions As clsDataWork_BankTransactions
    Private objDataWork_Import As clsDataWork_ImportSettings

    Private objOItem_Class_BankTransaction As clsOntologyItem
    Private objTransaction_Import As clsTransaction_Import
    Private boolApply As Boolean = False

    Private objFrm_ObjectEdit As frm_ObjectEdit

    Public Event Close()
    Public Event Apply(ByVal OList_Transaction As List(Of DataRowView))

    Public Property Applyable As Boolean
        Get
            Return boolApply
        End Get
        Set(ByVal value As Boolean)
            boolApply = value
        End Set
    End Property

    Public Sub initialize_BankTransactions(ByVal OItem_Class_BankTransaction As clsOntologyItem, ByVal DataWork_BankTransactions As clsDataWork_BankTransactions)
        DataGridView_Transactions.Enabled = False
        BindingNavigator_Transactions.Enabled = False
        objDataWork_BankTransactions = DataWork_BankTransactions

        objOItem_Class_BankTransaction = OItem_Class_BankTransaction
        Timer_BankTransactions.Stop()
        Me.DataSet_Transactions.dtbl_Banktransactions.Clear()
        If objDataWork_BankTransactions.get_Data_BankTransaction(objOItem_Class_BankTransaction, Me.DataSet_Transactions.dtbl_Banktransactions).GUID = objLocalConfig.Globals.LState_Success.GUID Then


            Timer_BankTransactions.Start()
        Else
            MsgBox("Die Daten konnten nicht ausgelesen werden!", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub ToolStripButton_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Close.Click
        RaiseEvent Close()
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        ToolStripTextBox_Database.Text = objLocalConfig.Globals.Index & "@" & objLocalConfig.Globals.Server
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDataWork_Import = New clsDataWork_ImportSettings(objLocalConfig)
        objTransaction_Import = New clsTransaction_Import(objLocalConfig)
    End Sub

    Private Sub filter_List()
        Dim strFilter As String

        strFilter = ToolStripTextBox_Filter.Text

        Try
            If ToolStripButton_NoPayment.Checked = True Then
                If strFilter <> "" Then
                    strFilter = strFilter & " AND "
                End If
                DtblBanktransactionsBindingSource.Filter = strFilter & "GUID_Payment IS NULL"
            Else
                DtblBanktransactionsBindingSource.Filter = strFilter
            End If
        Catch ex As Exception
            MsgBox("Überprüfen Sie bitte die Filter-Zeichenkette!", MsgBoxStyle.Exclamation)
        End Try
        
    End Sub

    Private Sub Timer_BankTransactions_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_BankTransactions.Tick
        If objDataWork_BankTransactions.OItem_Result_BankTransactions.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            ToolStripProgressBar_Transactions.Value = 50

        ElseIf objDataWork_BankTransactions.OItem_Result_BankTransactions.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Timer_BankTransactions.Stop()
            ToolStripProgressBar_Transactions.Value = 0

            DataGridView_Transactions.Refresh()
            DataGridView_Transactions.Enabled = True
            BindingNavigator_Transactions.Enabled = True
            BindingNavigator_Transactions.Refresh()

            ToolStripButton_NoPayment.Enabled = False
            ToolStripButton_NoPayment.Checked = True
            ToolStripButton_NoPayment.Enabled = True

            filter_List()
        ElseIf objDataWork_BankTransactions.OItem_Result_BankTransactions.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            Timer_BankTransactions.Stop()
            ToolStripProgressBar_Transactions.Value = 0
        End If
    End Sub

    Private Sub ToolStripButton_NoPayment_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton_NoPayment.CheckStateChanged
        filter_List()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        ToolStripTextBox_Filter.Text = ""
        filter_List()
    End Sub

    Private Sub EqualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EqualToolStripMenuItem.Click
        Dim strFilter As String
        Dim strValue As String

        If DataGridView_Transactions.SelectedCells.Count = 1 Then
            strFilter = "[" & DataGridView_Transactions.Columns(DataGridView_Transactions.SelectedCells(0).ColumnIndex).DataPropertyName & "]"
            strValue = DataGridView_Transactions.SelectedCells(0).Value.ToString
            Select Case TypeName(DataGridView_Transactions.SelectedCells(0).Value).ToLower
                Case "string"
                    strValue = strValue.Replace("'", "''")
                    ToolStripTextBox_Filter.Text = strFilter & "='" & strValue & "'"
                Case "double"
                    ToolStripTextBox_Filter.Text = strFilter & "=" & strValue
                Case "long"
                    ToolStripTextBox_Filter.Text = strFilter & "=" & strValue
                Case "boolean"
                    ToolStripTextBox_Filter.Text = strFilter & "=" & strValue
            End Select


            filter_List()
        End If
    End Sub

    Private Sub ContextMenuStrip_BankTransactions_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_BankTransactions.Opening
        EqualToolStripMenuItem.Enabled = False
        NotEqualToolStripMenuItem.Enabled = False
        ContainsToolStripMenuItem.Enabled = False
        approximateToolStripMenuItem.Enabled = False
        ToFilterToolStripMenuItem.Enabled = False
        ToOrderToolStripMenuItem.Enabled = False
        CopyToolStripMenuItem.Enabled = False
        DeleteToolStripMenuItem.Enabled = False
        ArchiveToolStripMenuItem.Enabled = False

        ClearToolStripMenuItem.Enabled = False

        ApplyToolStripMenuItem.Visible = boolApply

        If DataGridView_Transactions.SelectedCells.Count = 1 Then
            EqualToolStripMenuItem.Enabled = True
            NotEqualToolStripMenuItem.Enabled = True
            If TypeName(DataGridView_Transactions.SelectedCells(0).Value).ToLower = "string" Then
                ContainsToolStripMenuItem.Enabled = True
            End If

            If TypeName(DataGridView_Transactions.SelectedCells(0).Value).ToLower = "double" Or _
               TypeName(DataGridView_Transactions.SelectedCells(0).Value).ToLower = "date" Then
                approximateToolStripMenuItem.Enabled = True
            End If

            ToFilterToolStripMenuItem.Enabled = True
            ToOrderToolStripMenuItem.Enabled = True
            CopyToolStripMenuItem.Enabled = True
        End If

        If DataGridView_Transactions.SelectedRows.Count > 0 Then
            DeleteToolStripMenuItem.Enabled = True
            ArchiveToolStripMenuItem.Enabled = True
        End If

        If DtblBanktransactionsBindingSource.Filter <> "" Then
            ClearToolStripMenuItem.Enabled = True
        End If


    End Sub

    Private Sub NotEqualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotEqualToolStripMenuItem.Click
        Dim strFilter As String
        Dim strValue As String

        If DataGridView_Transactions.SelectedCells.Count = 1 Then
            strFilter = "[" & DataGridView_Transactions.Columns(DataGridView_Transactions.SelectedCells(0).ColumnIndex).DataPropertyName & "]"
            strValue = DataGridView_Transactions.SelectedCells(0).Value.ToString
            Select Case TypeName(DataGridView_Transactions.SelectedCells(0).Value).ToLower
                Case "string"
                    strValue = strValue.Replace("'", "''")
                    ToolStripTextBox_Filter.Text = "NOT " & strFilter & "='" & strValue & "'"
                Case "double"
                    ToolStripTextBox_Filter.Text = "NOT " & strFilter & "=" & strValue
                Case "long"
                    ToolStripTextBox_Filter.Text = "NOT " & strFilter & "=" & strValue
                Case "boolean"
                    ToolStripTextBox_Filter.Text = "NOT " & strFilter & "=" & strValue
            End Select


            filter_List()
        End If
    End Sub

    Private Sub ContainsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContainsToolStripMenuItem.Click
        Dim strFilter As String
        Dim strValue As String

        If DataGridView_Transactions.SelectedCells.Count = 1 Then
            strFilter = "[" & DataGridView_Transactions.Columns(DataGridView_Transactions.SelectedCells(0).ColumnIndex).DataPropertyName & "]"
            strValue = DataGridView_Transactions.SelectedCells(0).Value.ToString
            Select Case TypeName(DataGridView_Transactions.SelectedCells(0).Value).ToLower
                Case "string"
                    strValue = strValue.Replace("'", "''")
                    ToolStripTextBox_Filter.Text = strFilter & " LIKE '%" & strValue & "%'"
                    filter_List()
            End Select



        End If
    End Sub

    Private Sub approximateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles approximateToolStripMenuItem.Click

    End Sub

    Private Sub ToFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToFilterToolStripMenuItem.Click
        If DataGridView_Transactions.SelectedCells.Count = 1 Then
            If ToolStripTextBox_Filter.Text <> "" Then
                ToolStripTextBox_Filter.Text = ToolStripTextBox_Filter.Text & " AND "
            End If

            ToolStripTextBox_Filter.Text = ToolStripTextBox_Filter.Text & "[" & DataGridView_Transactions.Columns(DataGridView_Transactions.SelectedCells(0).ColumnIndex).DataPropertyName & "]"
        End If
    End Sub

    Private Sub ToOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToOrderToolStripMenuItem.Click
        If DataGridView_Transactions.SelectedCells.Count = 1 Then
            If ToolStripTextBox_Order.Text <> "" Then
                ToolStripTextBox_Order.Text = ToolStripTextBox_Order.Text & " AND "
            End If

            ToolStripTextBox_Order.Text = ToolStripTextBox_Order.Text & "[" & DataGridView_Transactions.Columns(DataGridView_Transactions.SelectedCells(0).ColumnIndex).DataPropertyName & "]"
        End If
    End Sub

    Private Sub ToolStripTextBox_Order_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ToolStripTextBox_Order.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter, Keys.Return
                order_List()
        End Select
    End Sub

    Private Sub ToolStripTextBox_Order_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripTextBox_Order.Leave
        order_List()
    End Sub

    Private Sub order_List()
        Dim strOrder As String

        strOrder = ToolStripTextBox_Order.Text

        Try
            DtblBanktransactionsBindingSource.Sort = strOrder
        Catch ex As Exception
            MsgBox("Überprüfen Sie bitte die Sortierungs-Zeichenkette!", MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub ToolStripTextBox_Filter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ToolStripTextBox_Filter.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter, Keys.Return
                filter_List()
        End Select
    End Sub

    Private Sub ToolStripTextBox_Filter_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripTextBox_Filter.Leave
        filter_List()
    End Sub

    Private Sub ToolStripButton_Import_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Import.Click
        objDataWork_Import.Import_Transactions(objDataWork_BankTransactions)
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView

        objDGVR_Selected = DataGridView_Transactions.Rows(DataGridView_Transactions.SelectedCells(0).RowIndex)
        objDRV_Selected = objDGVR_Selected.DataBoundItem

        Clipboard.SetDataObject(objDRV_Selected.Item(DataGridView_Transactions.SelectedCells(0).ColumnIndex).ToString)

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOItem_Banktransaction As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim intToDo As Integer
        Dim intDone As Integer


        If MsgBox("Wollen Sie wirklich alle markierten Transaktionen löschen?", MsgBoxStyle.YesNo) Then
            intToDo = DataGridView_Transactions.SelectedRows.Count
            intDone = 0
            For Each objDGVR_Selected In DataGridView_Transactions.SelectedRows
                objDRV_Selected = objDGVR_Selected.DataBoundItem

                objOItem_Banktransaction = New clsOntologyItem(objDRV_Selected.Item("GUID_BankTransaction"), objLocalConfig.Globals.Type_Object)

                objOItem_Result = objTransaction_Import.del_011_BankTransaction__Currency(objOItem_Banktransaction)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Result = objTransaction_Import.del_010_BankTransaction__Gegenkonto(objOItem_Banktransaction)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objOItem_Result = objTransaction_Import.del_009_BankTransaction__Auftragskonto(objOItem_Banktransaction)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objOItem_Result = objTransaction_Import.del_008_BankTransaction__Verwendungszweck(objOItem_Banktransaction)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objOItem_Result = objTransaction_Import.del_007_BankTransaction__Buchungstext(objOItem_Banktransaction)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objOItem_Result = objTransaction_Import.del_006_BankTransaction__Betrag(objOItem_Banktransaction)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        objOItem_Result = objTransaction_Import.del_005_BankTransaction__BegZahl(objOItem_Banktransaction)
                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                            objOItem_Result = objTransaction_Import.del_004_BankTransaction__Zahlungsausgang(objOItem_Banktransaction)
                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                objOItem_Result = objTransaction_Import.del_003_BankTransaction__Valutadatum(objOItem_Banktransaction)
                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                    objOItem_Result = objTransaction_Import.del_002_BankTransaction__Info(objOItem_Banktransaction)
                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                        objOItem_Result = objTransaction_Import.del_001_BankTransaction(objOItem_Banktransaction)
                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                            objDRV_Selected.Delete()
                                                            intDone = intDone + 1
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        End If

        If intToDo - intDone > 0 Then
            MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Transaktionen gelöscht werden!", MsgBoxStyle.Information)
        End If
    End Sub

    
    Private Sub ToolStripMenuItem_Archive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_Archive.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOItem_Banktransaction As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim intToDo As Integer
        Dim intDone As Integer

        If MsgBox("Wollen Sie wirklich alle markierten Transaktionen in die Archiv-Ablage verschieben?", MsgBoxStyle.YesNo) Then
            intToDo = DataGridView_Transactions.SelectedRows.Count
            intDone = 0
            For Each objDGVR_Selected In DataGridView_Transactions.SelectedRows
                objDRV_Selected = objDGVR_Selected.DataBoundItem

                objOItem_Banktransaction = New clsOntologyItem(objDRV_Selected.Item("GUID_BankTransaction"), objDRV_Selected.Item("Name_BankTransaction"), objLocalConfig.OItem_Type_Bank_Transaktionen__Sparkasse____Archiv.GUID, objLocalConfig.Globals.Type_Object)
                objOItem_Result = objTransaction_Import.save_001_BankTransaciton(objOItem_Banktransaction)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objDRV_Selected.Delete()
                    intDone = intDone + 1
                End If

            Next
        End If

        If intToDo - intDone > 0 Then
            MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Transaktionen gelöscht werden!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub ArchiveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArchiveToolStripMenuItem.Click
        If ArchiveToolStripMenuItem.Checked = True Then
            ArchiveToolStripMenuItem.Checked = True
            TransactionsToolStripMenuItem.Checked = False
            initialize_BankTransactions(objLocalConfig.OItem_Type_Bank_Transaktionen__Sparkasse____Archiv, objDataWork_BankTransactions)

        Else
            ArchiveToolStripMenuItem.Checked = False
            TransactionsToolStripMenuItem.Checked = True
            initialize_BankTransactions(objLocalConfig.OItem_Type_Bank_Transaktionen__Sparkasse_, objDataWork_BankTransactions)
        End If
    End Sub

    Private Sub ApplyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApplyToolStripMenuItem.Click
        Dim objOList_Transactions As New List(Of DataRowView)
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView

        objOList_Transactions.Clear()

        For Each objDGVR_Selected In DataGridView_Transactions.SelectedRows
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            objOList_Transactions.Add(objDRV_Selected)


        Next

        RaiseEvent Apply(objOList_Transactions)
    End Sub

    Private Sub DataGridView_Transactions_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_Transactions.RowHeaderMouseDoubleClick
        Dim objDGVR_Selected = DataGridView_Transactions.Rows(e.RowIndex)
        Dim objDRV_Selected As DataRowView = objDGVR_Selected.DataBoundItem
        Dim objOList_BankTransaction = New List(Of clsOntologyItem)
        objOList_BankTransaction.Add(New clsOntologyItem With {.GUID = objDRV_Selected.Item("GUID_BankTransaction"), _
                                                                 .Name = objDRV_Selected.Item("Name_BankTransaction"), _
                                                                 .GUID_Parent = objLocalConfig.OItem_Type_Bank_Transaktionen__Sparkasse_.GUID, _
                                                                 .Type = objLocalConfig.Globals.Type_Object})


        objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, objOList_BankTransaction, 0, objLocalConfig.Globals.Type_Object, Nothing)
        objFrm_ObjectEdit.ShowDialog(Me)

    End Sub
End Class
