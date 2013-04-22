﻿Imports Ontolog_Module
Public Class UserControl_TransactionDetail
    Private objLocalConfig As clsLocalConfig

    Private objUserControl_RelatedItems As UserControl_OItemList
    Private objUserControl_RelatedFinTran As UserControl_RelatedFinTran

    Private objDLG_Attribute_DateTime As dlg_Attribute_DateTime

    Private objOItem_FinancialTransaction As clsOntologyItem

    Private objDataWork_BaseConfig As clsDataWork_BaseConfig
    Private objDataWork_Transaction As clsDataWork_Transaction
    Private objDAtaWork_Payments As clsDataWork_Payments

    Private objTransaction_FinancialTransaction As clsTransaction_FinancialTransaction

    Public Sub New(ByVal LocalConfig As clsLocalConfig, ByVal DataWork_BaseConfig As clsDataWork_BaseConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        objDataWork_BaseConfig = DataWork_BaseConfig

        set_DBConnection()

        initialize_loc()
    End Sub

    Private Sub initialize_loc()
        objUserControl_RelatedItems = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_RelatedItems.Dock = DockStyle.Fill
        Panel_SemItems.Controls.Add(objUserControl_RelatedItems)

        objUserControl_RelatedFinTran = New UserControl_RelatedFinTran(objLocalConfig)
        objUserControl_RelatedFinTran.Dock = DockStyle.Fill
        Panel_Offset.Controls.Add(objUserControl_RelatedFinTran)

        ComboBox_currency.DataSource = objDataWork_BaseConfig.OL_Currencies_Combo
        ComboBox_currency.ValueMember = "GUID"
        ComboBox_currency.DisplayMember = "Name"
        ComboBox_TaxRate.DataSource = objDataWork_BaseConfig.OL_TaxRates_Combo
        ComboBox_TaxRate.ValueMember = "GUID"
        ComboBox_TaxRate.DisplayMember = "Name"
        ComboBox_unit.DataSource = objDataWork_BaseConfig.OL_Units_Combo
        ComboBox_unit.ValueMember = "GUID"
        ComboBox_unit.DisplayMember = "Name"
    End Sub

    Public Sub initialize(ByVal OItem_FinancialTransaction As clsOntologyItem)
        objOItem_FinancialTransaction = OItem_FinancialTransaction
        clear_Controls()
        If Not objOItem_FinancialTransaction Is Nothing Then
            objDataWork_Transaction.get_Data_TransactionDetail(objOItem_FinancialTransaction)
            objDAtaWork_Payments.get_Data_Payments(objOItem_FinancialTransaction)
            objUserControl_RelatedItems.initialize(Nothing, _
                                                   objOItem_FinancialTransaction, _
                                                   objLocalConfig.Globals.Direction_LeftRight, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_RelationType_belonging_Sem_Item, _
                                                   True)
            Timer_Data.Start()
        End If
    End Sub

    Private Sub set_Combo_Standard()
        ComboBox_currency.SelectedValue = objDataWork_BaseConfig.OL_Currency(0).ID_Other
        ComboBox_TaxRate.SelectedValue = objDataWork_BaseConfig.OL_TaxRate(0).ID_Other
        ComboBox_unit.SelectedValue = objDataWork_BaseConfig.OL_AmountUnit(0).ID_Other
    End Sub

    Private Sub clear_Controls()
        Button_Contractee.Enabled = False
        Button_Contractor.Enabled = False
        Button_Date.Enabled = False

        objUserControl_RelatedFinTran.clear_Controls()
        objUserControl_RelatedItems.clear_Relation()

        objUserControl_RelatedFinTran.Enabled = False
        objUserControl_RelatedItems.Enabled = False

        DataGridView_Payment.DataSource = Nothing
        TextBox_Amount.ReadOnly = True
        TextBox_Amount.Text = ""
        TextBox_Contractee.Text = ""
        TextBox_Contractor.Text = ""
        TextBox_Date.ReadOnly = True
        TextBox_Date.Text = ""
        TextBox_Rest.Text = ""
        TextBox_sum.ReadOnly = True
        TextBox_sum.Text = ""
        TextBox_TransactionID.ReadOnly = True
        TextBox_TransactionID.Text = ""

        ComboBox_currency.Enabled = False
        ComboBox_TaxRate.Enabled = False
        ComboBox_unit.Enabled = False

        ContextMenuStrip_Payment.Enabled = False

        set_Combo_Standard()

    End Sub

    Private Sub set_DBConnection()
        objDataWork_Transaction = New clsDataWork_Transaction(objLocalConfig)
        objDAtaWork_Payments = New clsDataWork_Payments(objLocalConfig)

        objTransaction_FinancialTransaction = New clsTransaction_FinancialTransaction(objLocalConfig)
    End Sub

    Private Sub Timer_Data_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Data.Tick
        Dim boolStop = True
        Dim objOItem_Result As clsOntologyItem

        objOItem_Result = objDataWork_Transaction.OItem_Result_Contractee

        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objDataWork_Transaction.Contractee.Count > 0 Then

                    TextBox_Contractee.Text = objDataWork_Transaction.Contractee(0).Name_Other

                Else
                    TextBox_Contractee.Text = ""

                End If
                Button_Contractee.Enabled = True
            End If
        Else
            boolStop = False
        End If

        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then

            objOItem_Result = objDataWork_Transaction.OItem_Result_Contractor

            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDataWork_Transaction.Contractor.Count > 0 Then

                        TextBox_Contractor.Text = objDataWork_Transaction.Contractor(0).Name_Other

                    Else
                        TextBox_Contractor.Text = ""

                    End If

                    Button_Contractor.Enabled = True
                End If
            Else
                boolStop = False
            End If



        End If

        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then

            objOItem_Result = objDataWork_Transaction.OItem_Result_Currency

            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDataWork_Transaction.Currency.Count > 0 Then

                        ComboBox_currency.SelectedValue = objDataWork_Transaction.Currency(0).ID_Other

                    Else
                        ComboBox_currency.SelectedItem = Nothing

                    End If

                    ComboBox_currency.Enabled = True
                End If
            Else
                boolStop = False
            End If



        End If

        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then

            objOItem_Result = objDataWork_Transaction.OItem_Result_Gross

            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDataWork_Transaction.Gross.Count > 0 Then


                        CheckBox_Gross.Checked = objDataWork_Transaction.Gross(0).Val_Bit
                    

                Else
                        CheckBox_Gross.Checked = False

                End If

                    CheckBox_Gross.Enabled = True
                End If
            Else
                boolStop = False
            End If



        End If

        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then

            objOItem_Result = objDataWork_Transaction.OItem_Result_Menge

            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDataWork_Transaction.Menge_Value.Count > 0 Then


                        TextBox_Amount.Text = objDataWork_Transaction.Menge_Value(0).Val_Double


                    Else
                        TextBox_Amount.Text = ""

                    End If

                    If objDataWork_Transaction.Menge_Unit.Count > 0 Then
                        ComboBox_unit.SelectedValue = objDataWork_Transaction.Menge_Unit(0).ID_Other
                    Else
                        ComboBox_unit.SelectedItem = Nothing
                    End If

                    TextBox_Amount.ReadOnly = False
                    ComboBox_unit.Enabled = True
                End If
            Else
                boolStop = False
            End If



        End If

        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then

            objOItem_Result = objDataWork_Transaction.OItem_Result_Sum

            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDataWork_Transaction.Sum.Count > 0 Then


                        TextBox_sum.Text = objDataWork_Transaction.Sum(0).Val_Double


                    Else
                        TextBox_sum.Text = ""

                    End If
                    get_Rest()
                    TextBox_sum.ReadOnly = False
                End If
            Else
                boolStop = False
            End If



        End If

        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then

            objOItem_Result = objDataWork_Transaction.OItem_Result_Taxrate

            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDataWork_Transaction.Taxrate.Count > 0 Then


                        ComboBox_TaxRate.SelectedValue = objDataWork_Transaction.Taxrate(0).ID_Other


                    Else
                        ComboBox_TaxRate.SelectedItem = Nothing

                    End If

                    ComboBox_TaxRate.Enabled = True
                End If
            Else
                boolStop = False
            End If



        End If

        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then

            objOItem_Result = objDataWork_Transaction.OItem_Result_TransactionDate

            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDataWork_Transaction.TransactionDate.Count > 0 Then


                        TextBox_Date.Text = objDataWork_Transaction.TransactionDate(0).Val_Date


                    Else
                        TextBox_Date.Text = ""

                    End If

                    Button_Date.Enabled = True
                End If
            Else
                boolStop = False
            End If



        End If

        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then

            objOItem_Result = objDataWork_Transaction.OItem_Result_TransactionID

            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDataWork_Transaction.TransactionID.Count > 0 Then


                        TextBox_TransactionID.Text = objDataWork_Transaction.TransactionID(0).Val_String


                    Else
                        TextBox_TransactionID.Text = ""

                    End If

                    TextBox_TransactionID.ReadOnly = False
                End If
            Else
                boolStop = False
            End If



        End If

        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objOItem_Result = objDAtaWork_Payments.OItem_Result_Payment
            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    BindingSource_Payments.DataSource = objDAtaWork_Payments.DataTable_Payment
                    DataGridView_Payment.DataSource = BindingSource_Payments
                    DataGridView_Payment.Columns(0).Visible = False
                    DataGridView_Payment.Columns(1).Visible = False
                    DataGridView_Payment.Columns(2).Visible = False
                    DataGridView_Payment.Columns(4).Visible = False
                    DataGridView_Payment.Columns(6).Visible = False
                    DataGridView_Payment.Columns(8).Visible = False
                    DataGridView_Payment.Columns(10).Visible = False
                    DataGridView_Payment.Columns(12).Visible = False
                    DataGridView_Payment.Columns(14).Visible = False
                    DataGridView_Payment.Columns(16).Visible = False
                    DataGridView_Payment.Columns(18).Visible = False

                    get_Rest()
                End If
            Else
                boolStop = False
            End If

            ContextMenuStrip_Payment.Enabled = True
        End If

        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            If boolStop = False Then
                ToolStripProgressBar_Detail.Value = 50
            Else
                Timer_Data.Stop()
                ToolStripProgressBar_Detail.Value = 0


            End If
        Else
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
                Timer_Data.Stop()
                MsgBox("Die Daten können nicht ausgelesen werden!", MsgBoxStyle.Exclamation)

            End If
        End If
    End Sub

    Private Sub get_Rest()
        Dim dblRest As Double
        TextBox_Rest.Text = ""
        If objDAtaWork_Payments.OItem_Result_Payment.GUID = objLocalConfig.Globals.LState_Success.GUID And _
            objDataWork_Transaction.OItem_Result_Sum.GUID = objLocalConfig.Globals.LState_Success.GUID Then

            If objDataWork_Transaction.Sum.Count > 0 Then
                dblRest = objDataWork_Transaction.Sum(0).Val_Double
            Else
                dblRest = 0
            End If

            dblRest = dblRest - objDAtaWork_Payments.Payments_Sum

            TextBox_Rest.Text = dblRest
        End If
    End Sub

    Private Sub Button_Date_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Date.Click
        Dim objOL_TransactionDate As List(Of clsObjectAtt)
        Dim objOItem_Result As clsOntologyItem
        Dim dateVal As Date

        objOL_TransactionDate = objDataWork_Transaction.TransactionDate

        If Not objOL_TransactionDate Is Nothing Then
            If objOL_TransactionDate.Count > 0 Then
                dateVal = objOL_TransactionDate(0).Val_Date
            Else
                dateVal = Now
            End If
        Else
            dateVal = Now
        End If

        objDLG_Attribute_DateTime = New dlg_Attribute_DateTime("Attribute", _
                                                               objLocalConfig.Globals, _
                                                               dateVal)
        objDLG_Attribute_DateTime.ShowDialog(Me)
        If objDLG_Attribute_DateTime.DialogResult = DialogResult.OK Then
            dateVal = objDLG_Attribute_DateTime.Value

            objOItem_Result = objTransaction_FinancialTransaction.save_002_FinancialTransaction__TransactionDate(dateVal, _
                                                                                                                 objOItem_FinancialTransaction)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                TextBox_Date.Text = dateVal
            Else
                MsgBox("Beim Speichern des Datums ist ein Fehler unterlaufen!", MsgBoxStyle.Exclamation)
                initialize(objOItem_FinancialTransaction)
            End If
        End If
    End Sub

    Private Sub TextBox_TransactionID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_TransactionID.TextChanged
        Timer_TransactionID.Stop()
        If TextBox_TransactionID.ReadOnly = False Then
            Timer_TransactionID.Start()
        End If

    End Sub

    Private Sub Timer_TransactionID_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_TransactionID.Tick
        Dim strTransactionID As String
        Dim objOItem_Result As clsOntologyItem
        Timer_TransactionID.Stop()

        If TextBox_TransactionID.Text = "" Then
            strTransactionID = ""

            objOItem_Result = objTransaction_FinancialTransaction.del_003_FinancialTransaction__TransactionID(objOItem_FinancialTransaction)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Das Transaktionsdatum kann nicht geändert werden!", MsgBoxStyle.Exclamation)
                initialize(objOItem_FinancialTransaction)
            End If
        Else
            strTransactionID = TextBox_TransactionID.Text

            objOItem_Result = objTransaction_FinancialTransaction.save_003_FinancialTransaction__TransactionID(strTransactionID, objOItem_FinancialTransaction)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Das Transaktionsdatum kann nicht geändert werden!", MsgBoxStyle.Exclamation)
                initialize(objOItem_FinancialTransaction)
            End If

        End If
    End Sub
End Class
