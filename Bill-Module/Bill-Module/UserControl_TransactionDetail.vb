Imports Ontolog_Module
Imports ModuleLibrary
Imports Partner_Module
Public Class UserControl_TransactionDetail
    Private objLocalConfig As clsLocalConfig

    Private objUserControl_RelatedItems As UserControl_OItemList
    Private objUserControl_RelatedFinTran As UserControl_RelatedFinTran

    Private objDLG_Attribute_DateTime As dlg_Attribute_DateTime
    Private objDLG_Attribute_Double As dlg_Attribute_Double

    Private objOItem_FinancialTransaction As clsOntologyItem


    Private objDataWork_BaseConfig As clsDataWork_BaseConfig
    Private objDataWork_Transaction As clsDataWork_Transaction
    Private objDAtaWork_Payments As clsDataWork_Payments
    Private strAmount As String

    Private objTransaction_FinancialTransaction As clsTransaction_FinancialTransaction
    Private objTransaction_Amount As clsTransaction_Amount
    Private objTransaction_Payment As clsTransaction_Payment

    Private objFrmPartnerModule As frmPartnerModule
    Private objFrmObjectEdit As frm_ObjectEdit

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
        CheckBox_Gross.Enabled = False

        set_Combo_Standard()

    End Sub

    Private Sub set_DBConnection()
        objDataWork_Transaction = New clsDataWork_Transaction(objLocalConfig)
        objDAtaWork_Payments = New clsDataWork_Payments(objLocalConfig)

        objTransaction_FinancialTransaction = New clsTransaction_FinancialTransaction(objLocalConfig)
        objTransaction_Amount = New clsTransaction_Amount(objLocalConfig.Globals)
        objTransaction_Payment = New clsTransaction_Payment(objLocalConfig)
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
                    DataGridView_Payment.Columns(3).Visible = False
                    DataGridView_Payment.Columns(5).Visible = False
                    DataGridView_Payment.Columns(7).Visible = False
                    DataGridView_Payment.Columns(9).Visible = False
                    DataGridView_Payment.Columns(10).Visible = False
                    DataGridView_Payment.Columns(11).Visible = False
                    DataGridView_Payment.Columns(13).Visible = False
                    DataGridView_Payment.Columns(15).Visible = False
                    DataGridView_Payment.Columns(17).Visible = False
                    DataGridView_Payment.Columns(19).Visible = False

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

            dblRest = dblRest - objDAtaWork_Payments.Payments_SumPart

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

    Private Sub TextBox_sum_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox_sum.MouseDoubleClick
        Dim dblSum As Double


        If Double.TryParse(TextBox_sum.Text, dblSum) = False Then
            dblSum = 0
        End If
        objDLG_Attribute_Double = New dlg_Attribute_Double(objLocalConfig.OItem_Attribute_Amount.Name, _
                                                           objLocalConfig.Globals, dblSum)

        objDLG_Attribute_Double.ShowDialog(Me)
        If objDLG_Attribute_Double.DialogResult = DialogResult.OK Then
            dblSum = objDLG_Attribute_Double.Value
            TextBox_sum.Text = dblSum
        End If
    End Sub

    Private Sub TextBox_sum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_sum.TextChanged
        Dim objOItem_Result As clsOntologyItem
        Dim dblSum As Double

        If TextBox_sum.ReadOnly = False Then
            If TextBox_sum.Text = "" Then
                objOItem_Result = objTransaction_FinancialTransaction.del_004_FinancialTransaction__Sum(objOItem_FinancialTransaction)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    MsgBox("Die Summe kann nicht gesetzt werden!", MsgBoxStyle.Exclamation)
                    initialize(objOItem_FinancialTransaction)

                Else
                    objDataWork_Transaction.get_Data_Sum()
                    get_Rest()
                End If
            Else
                If Double.TryParse(TextBox_sum.Text, dblSum) = False Then
                    dblSum = 0
                End If

                objOItem_Result = objTransaction_FinancialTransaction.save_004_FinnacialTransaction__Sum(dblSum, objOItem_FinancialTransaction)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    MsgBox("Die Summe kann nicht gesetzt werden!", MsgBoxStyle.Exclamation)
                    initialize(objOItem_FinancialTransaction)
                Else
                    objDataWork_Transaction.get_Data_Sum()
                    get_Rest()
                End If
            End If
            
        End If
    End Sub

    Private Sub Timer_Sum_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Sum.Tick

    End Sub

    Private Sub ComboBox_currency_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBox_currency.MouseDoubleClick

    End Sub

    Private Sub ComboBox_currency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox_currency.SelectedIndexChanged
        Dim objOItem_Result As clsOntologyItem

        If ComboBox_currency.Enabled = True Then
            objOItem_Result = objTransaction_FinancialTransaction.save_005_FinancialTransaction_To_Currency(ComboBox_currency.SelectedItem, _
                                                                                                        objOItem_FinancialTransaction)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Die Währung konnte nicht geändert werden!", MsgBoxStyle.Exclamation)
                initialize(objOItem_FinancialTransaction)
            End If
        End If

        
    End Sub

    Private Sub ComboBox_currency_TextUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox_currency.TextUpdate

    End Sub

    Private Sub CheckBox_Gross_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_Gross.CheckStateChanged
        Dim objOItem_Result As clsOntologyItem
        If CheckBox_Gross.Enabled = True Then
            objOItem_Result = objTransaction_FinancialTransaction.save_006_FinancialTransaction__gross(CheckBox_Gross.Checked, _
                                                                                                       objOItem_FinancialTransaction)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Brutto/Netto kann nicht geändert werden!", MsgBoxStyle.Exclamation)
                initialize(objOItem_FinancialTransaction)
            End If
        End If
    End Sub

    Private Sub ComboBox_TaxRate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_TaxRate.SelectedIndexChanged
        Dim objOItem_Result As clsOntologyItem

        If ComboBox_TaxRate.Enabled = True Then
            objOItem_Result = objTransaction_FinancialTransaction.save_007_FinancialTransaction_To_TaxRate(ComboBox_TaxRate.SelectedItem, _
                                                                                                           objOItem_FinancialTransaction)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Die Steuerrate kann nicht geändert werden!", MsgBoxStyle.Exclamation)
                initialize(objOItem_FinancialTransaction)
            End If
        End If


    End Sub

    Private Sub save_Amount()
        Dim dblAmount As Double
        Dim objOItem_Unit As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        If Double.TryParse(TextBox_Amount.Text, dblAmount) = True Then
            objOItem_Unit = ComboBox_unit.SelectedItem
            If Not objOItem_Unit Is Nothing Then
                objOItem_Result = objTransaction_Amount.save_001_Amount(dblAmount, objOItem_Unit)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    MsgBox("Die Menge konnte nicht geändert werden!", MsgBoxStyle.Exclamation)
                    initialize(objOItem_FinancialTransaction)
                End If
            End If
        End If
    End Sub

   
    Private Sub TextBox_Amount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_Amount.TextChanged
        Dim dblAmount As Double
        Timer_Menge.Stop()
        If TextBox_Amount.ReadOnly = False Then
            If TextBox_Amount.Text <> strAmount Then
                If Double.TryParse(TextBox_Amount.Text, dblAmount) Then
                    strAmount = TextBox_Amount.Text
                    Timer_Menge.Start()
                Else
                    TextBox_Amount.ReadOnly = True
                    TextBox_Amount.Text = strAmount
                    TextBox_Amount.ReadOnly = False
                End If
            End If
        End If
    End Sub


    Private Sub Timer_Menge_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Menge.Tick
        Timer_Menge.Stop()

        save_Amount()
    End Sub

    Private Sub Button_Contractor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Contractor.Click
        Dim objOItem_Partner As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        objFrmPartnerModule = New frmPartnerModule(objLocalConfig.Globals)
        objFrmPartnerModule.applyable = True
        objFrmPartnerModule.ShowDialog(Me)

        If objFrmPartnerModule.DialogResult = DialogResult.OK Then
            If objFrmPartnerModule.OList_Partner.Count = 1 Then
                objOItem_Partner = objFrmPartnerModule.OList_Partner(0)

                objOItem_Result = objTransaction_FinancialTransaction.save_008_FinancialTransaction_To_Partner(objOItem_Partner, _
                                                                                             objLocalConfig.OItem_RelationType_belonging_Contractor, _
                                                                                             objOItem_FinancialTransaction)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    TextBox_Contractor.Text = objOItem_Partner.Name
                End If
            Else
                MsgBox("Bitte nur einen Partner auswählen!", MsgBoxStyle.Information)
            End If
        End If

    End Sub

    Private Sub Button_Contractee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Contractee.Click
        Dim objOItem_Partner As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        objFrmPartnerModule = New frmPartnerModule(objLocalConfig.Globals)
        objFrmPartnerModule.applyable = True
        objFrmPartnerModule.ShowDialog(Me)
        If objFrmPartnerModule.DialogResult = DialogResult.OK Then
            If objFrmPartnerModule.OList_Partner.Count = 1 Then
                objOItem_Partner = objFrmPartnerModule.OList_Partner(0)

                objOItem_Result = objTransaction_FinancialTransaction.save_008_FinancialTransaction_To_Partner(objOItem_Partner, _
                                                                                             objLocalConfig.OItem_RelationType_belonging_Contractee, _
                                                                                             objOItem_FinancialTransaction)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    TextBox_Contractee.Text = objOItem_Partner.Name
                End If
            Else
                MsgBox("Bitte nur einen Partner auswählen!", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub DataGridView_Payment_RowHeaderMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView_Payment.RowHeaderMouseDoubleClick
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOList_Payment As New List(Of clsOntologyItem)

        objDGVR_Selected = DataGridView_Payment.Rows(e.RowIndex)
        objDRV_Selected = objDGVR_Selected.DataBoundItem

        objOList_Payment.Add(New clsOntologyItem(objDRV_Selected.Item("ID_Payment"), _
                                               objDRV_Selected.Item("Name_Payment"), _
                                               objLocalConfig.OItem_Class_Payment.GUID, _
                                               objLocalConfig.Globals.Type_Object))

        objFrmObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, _
                                              objOList_Payment, _
                                              0, _
                                              objLocalConfig.Globals.Type_Object, _
                                              Nothing)

        objFrmObjectEdit.ShowDialog(Me)
    End Sub

    Private Sub ContextMenuStrip_Payment_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Payment.Opening
        NewPaymentToolStripMenuItem.Enabled = False
        ChangePaymentToolStripMenuItem.Enabled = False
        RemovePaymentToolStripMenuItem1.Enabled = False
        CalculatePercentToolStripMenuItem.Enabled = False
        ApplyBankTransactionToolStripMenuItem.Enabled = False


        If Not objOItem_FinancialTransaction Is Nothing Then
            NewPaymentToolStripMenuItem.Enabled = True
            If DataGridView_Payment.SelectedRows.Count = 1 Then
                RemovePaymentToolStripMenuItem1.Enabled = True
                ChangePaymentToolStripMenuItem.Enabled = True
                CalculatePercentToolStripMenuItem.Enabled = True
            End If
        End If
    End Sub

    Private Sub NewPaymentToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewPaymentToolStripMenuItem.Click
        Dim dblRest As Double
        Dim dateTransactionDate As Date
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Payment As clsOntologyItem



        If Double.TryParse(TextBox_Rest.Text, dblRest) And Date.TryParse(TextBox_Date.Text, dateTransactionDate) Then
            If dblRest > 0 Then
                objOItem_Payment = New clsOntologyItem(objLocalConfig.Globals.NewGUID, _
                                                       dblRest.ToString, _
                                                       objLocalConfig.OItem_Class_Payment.GUID, _
                                                       objLocalConfig.Globals.Type_Object)

                objOItem_Result = objTransaction_Payment.save_001_Payment(objOItem_Payment)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Result = objTransaction_Payment.save_002_Payment__Amount(dblRest)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objOItem_Result = objTransaction_Payment.save_003_Payment__Part(100)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objOItem_Result = objTransaction_Payment.save_004_Payment__TransactionDate(dateTransactionDate)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objOItem_Result = objTransaction_Payment.save_005_FinancialTransaction_To_Payment(objOItem_FinancialTransaction)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    get_Payments()
                                Else
                                    objOItem_Result = objTransaction_Payment.del_004_Payment__TransactionDate
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        objOItem_Result = objTransaction_Payment.del_003_Payment__Part
                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                            objOItem_Result = objTransaction_Payment.del_002_Payment__Amount
                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                objTransaction_Payment.del_001_Payment()
                                            End If
                                        End If
                                    End If

                                End If
                            Else
                                objOItem_Result = objTransaction_Payment.del_003_Payment__Part
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objOItem_Result = objTransaction_Payment.del_002_Payment__Amount
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        objTransaction_Payment.del_001_Payment()
                                    End If
                                End If


                                MsgBox("Die Zahlung konnte nicht erzeugt werden!", MsgBoxStyle.Information)
                            End If
                        Else
                            objOItem_Result = objTransaction_Payment.del_002_Payment__Amount
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objTransaction_Payment.del_001_Payment()
                            End If

                            MsgBox("Die Zahlung konnte nicht erzeugt werden!", MsgBoxStyle.Information)
                        End If
                    Else
                        objTransaction_Payment.del_001_Payment()
                        MsgBox("Die Zahlung konnte nicht erzeugt werden!", MsgBoxStyle.Information)

                    End If
                Else
                    MsgBox("Die Zahlung konnte nicht erzeugt werden!", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Es ist keine Zahlung mehr möglich, weil kein Betrag mehr übrig ist oder kein Transaktionsdatum definiert ist!", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Es konnte nicht ermittelt werden, ob Zahlungen noch möglich sind!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub get_Payments()
        objDAtaWork_Payments.DataTable_Payment.Clear()

        objDAtaWork_Payments.get_Data_Payments(objOItem_FinancialTransaction)
        While (Not objDAtaWork_Payments.OItem_Result_Payment.GUID = objLocalConfig.Globals.LState_Success.GUID)

        End While
        BindingSource_Payments.DataSource = objDAtaWork_Payments.DataTable_Payment
        DataGridView_Payment.DataSource = BindingSource_Payments
        DataGridView_Payment.Columns(0).Visible = False
        DataGridView_Payment.Columns(1).Visible = False
        DataGridView_Payment.Columns(2).Visible = False
        DataGridView_Payment.Columns(3).Visible = False
        DataGridView_Payment.Columns(5).Visible = False
        DataGridView_Payment.Columns(7).Visible = False
        DataGridView_Payment.Columns(9).Visible = False
        DataGridView_Payment.Columns(10).Visible = False
        DataGridView_Payment.Columns(11).Visible = False
        DataGridView_Payment.Columns(13).Visible = False
        DataGridView_Payment.Columns(15).Visible = False
        DataGridView_Payment.Columns(17).Visible = False
        DataGridView_Payment.Columns(19).Visible = False

        get_Rest()
    End Sub

    Private Sub CalculatePercentToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CalculatePercentToolStripMenuItem.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim dblSum As Double
        Dim dblTransaction As Double
        Dim dblPart As Double
        Dim objOItem_Payment As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        If Double.TryParse(TextBox_sum.Text, dblSum) Then
            objDGVR_Selected = DataGridView_Payment.SelectedRows(0)
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            If Not IsDBNull(objDRV_Selected.Item("Val_Amount")) Then
                dblTransaction = objDRV_Selected.Item("Val_Amount")
                dblPart = 100 / dblTransaction * dblSum

                objOItem_Payment = New clsOntologyItem(objDRV_Selected.Item("ID_Payment"), _
                                                       objDRV_Selected.Item("Name_Payment"), _
                                                       objLocalConfig.OItem_Class_Payment.GUID, _
                                                       objLocalConfig.Globals.Type_Object)

                objOItem_Result = objTransaction_Payment.save_003_Payment__Part(dblPart, objOItem_Payment)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    get_Payments()
                Else
                    MsgBox("Der Anteil konnte nicht ermittelt werden!", MsgBoxStyle.Information)
                End If

            Else
                MsgBox("Der Betrag der Transaktion konnte nicht ermittelt werden!", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Der Betrag konnte nicht ermittelt werden!", MsgBoxStyle.Information)
        End If

        


    End Sub

    Private Sub RemovePaymentToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles RemovePaymentToolStripMenuItem1.Click

    End Sub
End Class
