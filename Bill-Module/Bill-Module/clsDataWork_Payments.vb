Imports Ontolog_Module
Public Class clsDataWork_Payments
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Payments As clsDBLevel
    Private objDBLevel_Payments_Amount As clsDBLevel
    Private objDBLevel_Payments_TransactionDate As clsDBLevel
    Private objDBLevel_Payments_Part As clsDBLevel
    Private objDBLevel_Payments_Transaction_Sparkasse As clsDBLevel
    Private objDBLevel_BankTransaction_GegenKonto As clsDBLevel
    Private objDBLevel_GegenKonto_Bank As clsDBLevel
    Private objDBLevel_BankTransaction_Valutadatum As clsDBLevel
    Private objDBLevel_BankTransaction_BegZahl As clsDBLevel
    Private objDBLevel_BankTransaction_Betrag As clsDBLevel

    Private objOItem_Result_Payments As clsOntologyItem

    Private objThread_Payments As Threading.Thread

    Private dtblT_Payments As New DataSet_BillModule.dtbl_PaymentsDataTable

    Private objOItem_Transaction As clsOntologyItem

    Public ReadOnly Property DataTable_Payment As DataSet_BillModule.dtbl_PaymentsDataTable
        Get
            Return dtblT_Payments
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Payment As clsOntologyItem
        Get
            Return objOItem_Result_Payments
        End Get
    End Property

    Public Sub get_Data_Payments(ByVal OItem_Transaction As clsOntologyItem)
        objOItem_Transaction = OItem_Transaction

        objOItem_Result_Payments = objLocalConfig.Globals.LState_Nothing

        dtblT_Payments.Clear()

        Try
            objThread_Payments.Abort()
        Catch ex As Exception

        End Try

        objThread_Payments = New Threading.Thread(AddressOf get_Data_Payments)
        objThread_Payments.Start()


    End Sub


    Private Sub get_Data_Payments_Thread()
        Dim objOLTransaction_To_Payments As New List(Of clsObjectRel)
        Dim objOLPayment__Amount As New List(Of clsObjectAtt)
        Dim objOLPayment__TransactionDate As New List(Of clsObjectAtt)
        Dim objOLPayment__Part As New List(Of clsObjectAtt)
        Dim objOLBankTransaction_To_Payment As New List(Of clsObjectRel)
        Dim objOLBankTransaction__Valutadatum As New List(Of clsObjectAtt)
        Dim objOLBankTransaction__BegZahl As New List(Of clsObjectAtt)
        Dim objOLBankTransaction__Betrag As New List(Of clsObjectAtt)
        Dim objOLBankTransaction_To_Konto As New List(Of clsObjectRel)
        Dim objOLBankKonto_To_Bank As New List(Of clsObjectRel)
    
        objOLTransaction_To_Payments.Add(New clsObjectRel(Nothing, _
                                                          objLocalConfig.OItem_Class_Payment.GUID, _
                                                          objOItem_Transaction.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_RelationType_belonging_Payment.GUID, _
                                                          objLocalConfig.Globals.Type_Object, _
                                                          Nothing, _
                                                          Nothing))

        objDBLevel_Payments.get_Data_ObjectRel(objOLTransaction_To_Payments)

        objOLPayment__Amount.Add(New clsObjectAtt(Nothing, _
                                                  Nothing, _
                                                  objLocalConfig.OItem_Class_Payment.GUID, _
                                                  objLocalConfig.OItem_Attribute_Amount.GUID, _
                                                  Nothing))

        objDBLevel_Payments_Amount.get_Data_ObjectAtt(objOLPayment__Amount, _
                                                      boolIDs:=False)

        objOLPayment__TransactionDate.Add(New clsObjectAtt(Nothing, _
                                                           Nothing, _
                                                           objLocalConfig.OItem_Class_Payment.GUID, _
                                                           objLocalConfig.OItem_Attribute_Transaction_Date.GUID, _
                                                           Nothing))

        objDBLevel_Payments_TransactionDate.get_Data_ObjectAtt(objOLPayment__TransactionDate, _
                                                               boolIDs:=False)

        objOLPayment__Part.Add(New clsObjectAtt(Nothing, _
                                                Nothing, _
                                                objLocalConfig.OItem_Class_Payment.GUID, _
                                                objLocalConfig.OItem_Attribute_part____.GUID, _
                                                Nothing))

        objDBLevel_Payments_Part.get_Data_ObjectAtt(objOLPayment__Part, _
                                                    boolIDs:=False)


        objOLBankTransaction_To_Payment.Add(New clsObjectRel(Nothing, _
                                                             objLocalConfig.OItem_Class_Bank_Transaktionen__Sparkasse_.GUID, _
                                                             Nothing, _
                                                             objLocalConfig.OItem_Class_Payment.GUID, _
                                                             objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                             objLocalConfig.Globals.Type_Object, _
                                                             Nothing, _
                                                             Nothing))

        objDBLevel_Payments_Transaction_Sparkasse.get_Data_ObjectRel(objOLBankTransaction_To_Payment, _
                                                                     boolIDs:=False)


        objOLBankTransaction__Valutadatum.Add(New clsObjectAtt(Nothing, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Class_Bank_Transaktionen__Sparkasse_.GUID, _
                                                       objLocalConfig.OItem_Attribute_Valutatag.GUID, _
                                                       Nothing))
        objDBLevel_BankTransaction_Valutadatum.get_Data_ObjectAtt(objOLBankTransaction__Valutadatum, _
                                                           boolIDs:=False)


        objOLBankTransaction__BegZahl.Add(New clsObjectAtt(Nothing, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_Class_Bank_Transaktionen__Sparkasse_.GUID, _
                                                   objLocalConfig.OItem_Attribute_Beg_nstigter_Zahlungspflichtiger.GUID, _
                                                   Nothing))

        objDBLevel_BankTransaction_Betrag.get_Data_ObjectAtt(objOLBankTransaction__BegZahl, _
                                                       boolIDs:=False)

        objOLBankTransaction__Betrag.Add(New clsObjectAtt(Nothing, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Class_Bank_Transaktionen__Sparkasse_.GUID, _
                                                          objLocalConfig.OItem_Attribute_Betrag.GUID, _
                                                          Nothing))

        objDBLevel_BankTransaction_Betrag.get_Data_ObjectAtt(objOLBankTransaction__Betrag, _
                                                             boolIDs:=False)

        objOLBankTransaction_To_Konto.Add(New clsObjectRel(Nothing, _
                                                           objLocalConfig.OItem_Class_Bank_Transaktionen__Sparkasse_.GUID, _
                                                           Nothing, _
                                                           objLocalConfig.OItem_Class_Kontonummer.GUID, _
                                                           objLocalConfig.OItem_RelationType_Gegenkonto.GUID, _
                                                           objLocalConfig.Globals.Type_Object, _
                                                           Nothing, _
                                                           Nothing))

        objDBLevel_BankTransaction_GegenKonto.get_Data_ObjectRel(objOLBankTransaction_To_Konto, _
                                                                 boolIDs:=False)

        objOLBankKonto_To_Bank.Add(New clsObjectRel(Nothing, _
                                                    objLocalConfig.OItem_Class_Kontonummer.GUID, _
                                                    Nothing, _
                                                    objLocalConfig.OItem_Class_Bankleitzahl.GUID, _
                                                    objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                    objLocalConfig.Globals.Type_Object, _
                                                    Nothing, _
                                                    Nothing))

        objDBLevel_GegenKonto_Bank.get_Data_ObjectRel(objOLBankKonto_To_Bank, _
                                                      boolIDs:=False)


        Dim objLPaymentPre = From objPayment In objDBLevel_Payments.OList_ObjectRel_ID
                          Join objAmount In objDBLevel_Payments_Amount.OList_ObjectAtt On objPayment.ID_Object Equals objAmount.ID_Object
                          Join objTransactionDate In objDBLevel_Payments_TransactionDate.OList_ObjectAtt On objPayment.ID_Object Equals objTransactionDate.ID_Object
                          Join objPart In objDBLevel_Payments_Part.OList_ObjectAtt On objPayment.ID_Object Equals objPart.ID_Object
                          Select ID_Transaction = objPayment.ID_Other, _
                                 ID_Payment = objPayment.ID_Object, _
                                 ID_Attribute_Amount = objAmount.ID_Attribute, _
                                 Val_Amount = objAmount.Val_Double, _
                                 ID_Attribute_TransactionDate = objTransactionDate.ID_Attribute, _
                                 Val_TransactionDate = objTransactionDate.Val_Date, _
                                 ID_Attribute_Part = objPart.ID_Attribute, _
                                 Val_Part = objPart.Val_Double

        Dim objLBankKonto = From objBankKonto In objDBLevel_Payments_Transaction_Sparkasse.OList_ObjectRel
                            Join objValuta In objDBLevel_BankTransaction_Valutadatum.OList_ObjectAtt On objValuta.ID_Object Equals objBankKonto.ID_Other
                            Join objBegZah In objDBLevel_BankTransaction_BegZahl.OList_ObjectAtt On objBegZah.ID_Object Equals objBankKonto.ID_Other
                            Join objBetrag In objDBLevel_BankTransaction_Betrag.OList_ObjectAtt On objBetrag.ID_Object Equals objBankKonto.ID_Other
                            Join objGegenKonto In objDBLevel_BankTransaction_GegenKonto.OList_ObjectRel On objGegenKonto.ID_Object Equals objBankKonto.ID_Other
                            Join objGegenBank In objDBLevel_GegenKonto_Bank.OList_ObjectRel On objGegenBank.ID_Object Equals objGegenKonto.ID_Other
                            Select ID_Payment = objBankKonto.ID_Object, _
                                   ID_BankTransaction = objBankKonto.ID_Other, _
                                   Name_BankTransaction = objBankKonto.Name_Other, _
                                   ID_Attribute_Valutadatum = objValuta.ID_Attribute, _
                                   Val_Valutadatum = objValuta.Val_Date, _
                                   ID_Attribute_BegZahl = objBegZah.ID_Attribute, _
                                   Val_BegZahl = objBegZah.Val_String, _
                                   ID_Attribute_Betrag = objBetrag.ID_Attribute, _
                                   Val_Betrag = objBetrag.Val_Double, _
                                   ID_Gegenkonto = objGegenKonto.ID_Other, _
                                   Name_Gegenkonto = objGegenKonto.Name_Other, _
                                   ID_Bank = objGegenBank.ID_Other, _
                                   Name_Bank = objGegenBank.Name_Other
        

        Dim objLPayment = From objPayment In objLPaymentPre
                          Join objBankKonto In objLBankKonto On objPayment.ID_Payment Equals objBankKonto.ID_Payment

        For Each objPayment In objLPayment
            dtblT_Payments.Rows.Add(objPayment.objPayment.ID_Transaction, _
                                    objPayment.objPayment.ID_Payment, _
                                    objPayment.objPayment.ID_Attribute_Amount, _
                                    objPayment.objPayment.Val_Amount, _
                                    objPayment.objPayment.ID_Attribute_TransactionDate, _
                                    objPayment.objPayment.Val_TransactionDate, _
                                    objPayment.objPayment.ID_Attribute_Part, _
                                    objPayment.objPayment.Val_Part, _
                                    objPayment.objBankKonto.ID_BankTransaction, _
                                    objPayment.objBankKonto.Name_BankTransaction, _
                                    objPayment.objBankKonto.ID_Attribute_Valutadatum, _
                                    objPayment.objBankKonto.Val_Valutadatum, _
                                    objPayment.objBankKonto.ID_Attribute_BegZahl, _
                                    objPayment.objBankKonto.Val_BegZahl, _
                                    objPayment.objBankKonto.ID_Attribute_Betrag, _
                                    objPayment.objBankKonto.Val_Betrag, _
                                    objPayment.objBankKonto.ID_Gegenkonto, _
                                    objPayment.objBankKonto.Name_Gegenkonto, _
                                    objPayment.objBankKonto.ID_Bank, _
                                    objPayment.objBankKonto.Name_Bank)

        Next

        objOItem_Result_Payments = objLocalConfig.Globals.LState_Success
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Payments = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Payments_Amount = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Payments_TransactionDate = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Payments_Part = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Payments_Transaction_Sparkasse = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BankTransaction_GegenKonto = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_GegenKonto_Bank = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BankTransaction_Valutadatum = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BankTransaction_BegZahl = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BankTransaction_Betrag = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
