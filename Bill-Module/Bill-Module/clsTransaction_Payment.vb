Imports Ontolog_Module
Imports OntologyClasses.BaseClasses

Public Class clsTransaction_Payment
    Dim objLocalConfig As clsLocalConfig
    Dim objDBLevel_Payment As clsDBLevel

    Dim objOItem_Payment As clsOntologyItem
    Dim objOAItem_Payment__Amount As clsObjectAtt
    Dim objOItem_FinancialTransaction As clsOntologyItem
    Dim objOItem_BankTransaction As clsOntologyItem

    Public Function save_001_Payment(ByVal OItem_Payment As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_Payment As New List(Of clsOntologyItem)

        objOItem_Payment = OItem_Payment

        objOL_Payment.Add(objOItem_Payment)

        objOItem_Result = objDBLevel_Payment.save_Objects(objOL_Payment)

        Return objOItem_Result
    End Function

    Public Function del_001_Payment(Optional ByVal OItem_Payment As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_Payment As New List(Of clsOntologyItem)

        If Not OItem_Payment Is Nothing Then
            objOItem_Payment = OItem_Payment
        End If

        objOL_Payment.Add(objOItem_Payment)

        objOItem_Result = objDBLevel_Payment.del_Objects(objOL_Payment)

        Return objOItem_Result
    End Function

    Public Function save_002_Payment__Amount(ByVal dblAmount As Double, Optional ByVal OItem_Payment As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objOL_Payment__Amount As New List(Of clsObjectAtt)
        Dim objOL_Payment__Amount_Search As New List(Of clsObjectAtt)
        Dim objOL_Payment__Amount_Del As New List(Of clsObjectAtt)

        If Not OItem_Payment Is Nothing Then
            objOItem_Payment = OItem_Payment
        End If

        objOL_Payment__Amount_Search.Add(New clsObjectAtt(Nothing, _
                                                          objOItem_Payment.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Attribute_Amount.GUID, _
                                                          Nothing))

        objOItem_Result_Search = objDBLevel_Payment.get_Data_ObjectAtt(objOL_Payment__Amount_Search, _
                                                                       boolIDs:=False)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Payment.OList_ObjectAtt
                          Where Not obj.Val_Double = dblAmount

            Dim objLExist = From obj In objDBLevel_Payment.OList_ObjectAtt
                            Where obj.Val_Double = dblAmount

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOL_Payment__Amount_Del.Add(New clsObjectAtt(objDel.ID_Attribute, _
                                                                   Nothing, _
                                                                   Nothing, _
                                                                   Nothing, _
                                                                   Nothing))

                Next

                objOItem_Result_Del = objDBLevel_Payment.del_ObjectAtt(objOL_Payment__Amount_Del)

            End If


            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            Else
                objOItem_Result = objOItem_Result_Del
            End If
        Else
            objOItem_Result = objOItem_Result_Search
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOL_Payment__Amount.Add(New clsObjectAtt(objLocalConfig.Globals.NewGUID, _
                                                       objOItem_Payment.GUID, _
                                                       Nothing, _
                                                       objOItem_Payment.GUID_Parent, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Attribute_Amount.GUID, _
                                                       Nothing, _
                                                       1, _
                                                       dblAmount.ToString, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       dblAmount, _
                                                       Nothing, _
                                                       objLocalConfig.Globals.DType_Real.GUID))

            objOItem_Result = objDBLevel_Payment.save_ObjAtt(objOL_Payment__Amount)
        End If

        Return objOItem_Result
    End Function

    Public Function del_002_Payment__Amount(Optional ByVal OItem_Payment As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLPayment__Amount As New List(Of clsObjectAtt)

        If Not OItem_Payment Is Nothing Then
            objOItem_Payment = OItem_Payment
        End If

        objOLPayment__Amount.Add(New clsObjectAtt(Nothing, _
                                                  objOItem_Payment.GUID, _
                                                  Nothing, _
                                                  objLocalConfig.OItem_Attribute_Amount.GUID, _
                                                  Nothing))

        objOItem_Result = objDBLevel_Payment.del_ObjectAtt(objOLPayment__Amount)

        Return objOItem_Result
    End Function

    Public Function save_003_Payment__Part(ByVal dblPart As Double, Optional ByVal OItem_Payment As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objOL_Payment__Part As New List(Of clsObjectAtt)
        Dim objOL_Payment__Part_Search As New List(Of clsObjectAtt)
        Dim objOL_Payment__Part_Del As New List(Of clsObjectAtt)

        If Not OItem_Payment Is Nothing Then
            objOItem_Payment = OItem_Payment
        End If

        objOL_Payment__Part_Search.Add(New clsObjectAtt(Nothing, _
                                                          objOItem_Payment.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Attribute_part____.GUID, _
                                                          Nothing))

        objOItem_Result_Search = objDBLevel_Payment.get_Data_ObjectAtt(objOL_Payment__Part_Search, _
                                                                       boolIDs:=False)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Payment.OList_ObjectAtt
                          Where Not obj.Val_Double = dblPart

            Dim objLExist = From obj In objDBLevel_Payment.OList_ObjectAtt
                            Where obj.Val_Double = dblPart

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOL_Payment__Part_Del.Add(New clsObjectAtt(objDel.ID_Attribute, _
                                                                   Nothing, _
                                                                   Nothing, _
                                                                   Nothing, _
                                                                   Nothing))

                Next

                objOItem_Result_Del = objDBLevel_Payment.del_ObjectAtt(objOL_Payment__Part_Del)

            End If


            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            Else
                objOItem_Result = objOItem_Result_Del
            End If
        Else
            objOItem_Result = objOItem_Result_Search
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOL_Payment__Part.Add(New clsObjectAtt(objLocalConfig.Globals.NewGUID, _
                                                       objOItem_Payment.GUID, _
                                                       Nothing, _
                                                       objOItem_Payment.GUID_Parent, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Attribute_part____.GUID, _
                                                       Nothing, _
                                                       1, _
                                                       dblPart.ToString, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       dblPart, _
                                                       Nothing, _
                                                       objLocalConfig.Globals.DType_Real.GUID))

            objOItem_Result = objDBLevel_Payment.save_ObjAtt(objOL_Payment__Part)
        End If

        Return objOItem_Result
    End Function

    Public Function del_003_Payment__Part(Optional ByVal OItem_Payment As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLPayment__Part As New List(Of clsObjectAtt)

        If Not OItem_Payment Is Nothing Then
            objOItem_Payment = OItem_Payment
        End If

        objOLPayment__Part.Add(New clsObjectAtt(Nothing, _
                                                  objOItem_Payment.GUID, _
                                                  Nothing, _
                                                  objLocalConfig.OItem_Attribute_part____.GUID, _
                                                  Nothing))

        objOItem_Result = objDBLevel_Payment.del_ObjectAtt(objOLPayment__Part)

        Return objOItem_Result
    End Function

    Public Function save_004_Payment__TransactionDate(ByVal dateTransactionDate As Date, Optional ByVal OItem_Payment As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objOL_Payment__TransactionDate As New List(Of clsObjectAtt)
        Dim objOL_Payment__TransactionDate_Search As New List(Of clsObjectAtt)
        Dim objOL_Payment__TransactionDate_Del As New List(Of clsObjectAtt)

        If Not OItem_Payment Is Nothing Then
            objOItem_Payment = OItem_Payment
        End If

        objOL_Payment__TransactionDate_Search.Add(New clsObjectAtt(Nothing, _
                                                          objOItem_Payment.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Attribute_Transaction_Date.GUID, _
                                                          Nothing))

        objOItem_Result_Search = objDBLevel_Payment.get_Data_ObjectAtt(objOL_Payment__TransactionDate_Search, _
                                                                       boolIDs:=False)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Payment.OList_ObjectAtt
                          Where Not obj.Val_Date = dateTransactionDate

            Dim objLExist = From obj In objDBLevel_Payment.OList_ObjectAtt
                            Where obj.Val_Date = dateTransactionDate

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOL_Payment__TransactionDate_Del.Add(New clsObjectAtt(objDel.ID_Attribute, _
                                                                   Nothing, _
                                                                   Nothing, _
                                                                   Nothing, _
                                                                   Nothing))

                Next

                objOItem_Result_Del = objDBLevel_Payment.del_ObjectAtt(objOL_Payment__TransactionDate_Del)

            End If


            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            Else
                objOItem_Result = objOItem_Result_Del
            End If
        Else
            objOItem_Result = objOItem_Result_Search
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOL_Payment__TransactionDate.Add(New clsObjectAtt(objLocalConfig.Globals.NewGUID, _
                                                       objOItem_Payment.GUID, _
                                                       Nothing, _
                                                       objOItem_Payment.GUID_Parent, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Attribute_Transaction_Date.GUID, _
                                                       Nothing, _
                                                       1, _
                                                       dateTransactionDate.ToString, _
                                                       Nothing, _
                                                       dateTransactionDate, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       objLocalConfig.Globals.DType_DateTime.GUID))

            objOItem_Result = objDBLevel_Payment.save_ObjAtt(objOL_Payment__TransactionDate)
        End If

        Return objOItem_Result
    End Function

    Public Function del_004_Payment__TransactionDate(Optional ByVal OItem_Payment As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLPayment__TransactionDate As New List(Of clsObjectAtt)

        If Not OItem_Payment Is Nothing Then
            objOItem_Payment = OItem_Payment
        End If

        objOLPayment__TransactionDate.Add(New clsObjectAtt(Nothing, _
                                                  objOItem_Payment.GUID, _
                                                  Nothing, _
                                                  objLocalConfig.OItem_Attribute_Transaction_Date.GUID, _
                                                  Nothing))

        objOItem_Result = objDBLevel_Payment.del_ObjectAtt(objOLPayment__TransactionDate)

        Return objOItem_Result
    End Function

    Public Function save_005_FinancialTransaction_To_Payment(ByVal OItem_FinancialTransaction As clsOntologyItem, Optional ByVal OItem_Payment As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem

        Dim objOL_FinancialTransaction_To_Payment As New List(Of clsObjectRel)
        Dim objOL_FinancialTransaction_To_Payment_Search As New List(Of clsObjectRel)
        Dim objOL_FinancialTransaction_To_Payment_Del As New List(Of clsObjectRel)

        objOItem_FinancialTransaction = OItem_FinancialTransaction

        If Not OItem_Payment Is Nothing Then
            objOItem_Payment = OItem_Payment
        End If

        objOL_FinancialTransaction_To_Payment_Search.Add(New clsObjectRel(Nothing, _
                                                                          objOItem_FinancialTransaction.GUID_Parent, _
                                                                          objOItem_Payment.GUID, _
                                                                          Nothing, _
                                                                          objLocalConfig.OItem_RelationType_belonging_Payment.GUID, _
                                                                          objLocalConfig.Globals.Type_Object, _
                                                                          Nothing, _
                                                                          Nothing))

        objOItem_Result_Search = objDBLevel_Payment.get_Data_ObjectRel(objOL_FinancialTransaction_To_Payment_Search)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Payment.OList_ObjectRel_ID
                          Where Not obj.ID_Object = objOItem_FinancialTransaction.GUID

            Dim objLExist = From obj In objDBLevel_Payment.OList_ObjectRel_ID
                            Where obj.ID_Object = objOItem_FinancialTransaction.GUID

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOL_FinancialTransaction_To_Payment_Del.Add(New clsObjectRel(objDel.ID_Object, _
                                                                                   Nothing, _
                                                                                   objDel.ID_Other, _
                                                                                   Nothing, _
                                                                                   objLocalConfig.OItem_RelationType_belonging_Payment.GUID, _
                                                                                   objLocalConfig.Globals.Type_Object, _
                                                                                   Nothing, _
                                                                                   Nothing))
                Next

                objOItem_Result_Del = objDBLevel_Payment.del_ObjectRel(objOL_FinancialTransaction_To_Payment_Del)
            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            Else
                objOItem_Result = objOItem_Result_Del
            End If
        Else
            objOItem_Result = objOItem_Result_Search
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOL_FinancialTransaction_To_Payment.Add(New clsObjectRel(objOItem_FinancialTransaction.GUID, _
                                                                       objOItem_FinancialTransaction.GUID_Parent, _
                                                                       objOItem_Payment.GUID, _
                                                                       objOItem_Payment.GUID_Parent, _
                                                                       objLocalConfig.OItem_RelationType_belonging_Payment.GUID, _
                                                                       objLocalConfig.Globals.Type_Object, _
                                                                       Nothing, _
                                                                       1))

            objOItem_Result = objDBLevel_Payment.save_ObjRel(objOL_FinancialTransaction_To_Payment)
        End If

        Return objOItem_Result
    End Function

    Public Function del_005_FinancialTransaction_To_Payment(ByVal GUID_Class_FinancialTransaciton As String, Optional ByVal OItem_Payment As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_FinancialTransaction_To_Payment As New List(Of clsObjectRel)

        If Not OItem_Payment Is Nothing Then
            objOItem_Payment = OItem_Payment
        End If

        objOL_FinancialTransaction_To_Payment.Add(New clsObjectRel(Nothing, _
                                                                   GUID_Class_FinancialTransaciton, _
                                                                   objOItem_Payment.GUID, _
                                                                   Nothing, _
                                                                   objLocalConfig.OItem_RelationType_belonging_Payment.GUID, _
                                                                   objLocalConfig.Globals.Type_Object, _
                                                                   Nothing, _
                                                                   Nothing))

        objOItem_Result = objDBLevel_Payment.del_ObjectRel(objOL_FinancialTransaction_To_Payment)

        Return objOItem_Result
    End Function

    Public Function save_006_BankTransaction_To_Payment(ByVal OItem_BankTransaction As clsOntologyItem, Optional ByVal OItem_Payment As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem

        Dim objOL_BankTransaction_To_Payment As New List(Of clsObjectRel)
        Dim objOL_BankTransaction_To_Payment_Search As New List(Of clsObjectRel)
        Dim objOL_BankTransaction_To_Payment_Del As New List(Of clsObjectRel)

        objOItem_BankTransaction = OItem_BankTransaction

        If Not OItem_Payment Is Nothing Then
            objOItem_Payment = OItem_Payment
        End If

        objOL_BankTransaction_To_Payment_Search.Add(New clsObjectRel(Nothing, _
                                                                          objOItem_BankTransaction.GUID_Parent, _
                                                                          objOItem_Payment.GUID, _
                                                                          Nothing, _
                                                                          objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                                          objLocalConfig.Globals.Type_Object, _
                                                                          Nothing, _
                                                                          Nothing))

        objOItem_Result_Search = objDBLevel_Payment.get_Data_ObjectRel(objOL_BankTransaction_To_Payment_Search)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Payment.OList_ObjectRel_ID
                          Where Not obj.ID_Object = objOItem_BankTransaction.GUID

            Dim objLExist = From obj In objDBLevel_Payment.OList_ObjectRel_ID
                            Where obj.ID_Object = objOItem_BankTransaction.GUID

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOL_BankTransaction_To_Payment_Del.Add(New clsObjectRel(objDel.ID_Object, _
                                                                                   Nothing, _
                                                                                   objDel.ID_Other, _
                                                                                   Nothing, _
                                                                                   objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                                                   objLocalConfig.Globals.Type_Object, _
                                                                                   Nothing, _
                                                                                   Nothing))
                Next

                objOItem_Result_Del = objDBLevel_Payment.del_ObjectRel(objOL_BankTransaction_To_Payment_Del)
            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            Else
                objOItem_Result = objOItem_Result_Del
            End If
        Else
            objOItem_Result = objOItem_Result_Search
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOL_BankTransaction_To_Payment.Add(New clsObjectRel(objOItem_BankTransaction.GUID, _
                                                                       objOItem_BankTransaction.GUID_Parent, _
                                                                       objOItem_Payment.GUID, _
                                                                       objOItem_Payment.GUID_Parent, _
                                                                       objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                                       objLocalConfig.Globals.Type_Object, _
                                                                       Nothing, _
                                                                       1))

            objOItem_Result = objDBLevel_Payment.save_ObjRel(objOL_BankTransaction_To_Payment)
        End If

        Return objOItem_Result
    End Function

    Public Function del_006_BankTransaction_To_Payment(ByVal GUID_Class_BankTransaction As String, Optional ByVal OItem_Payment As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_BankTransaction_To_Payment As New List(Of clsObjectRel)

        If Not OItem_Payment Is Nothing Then
            objOItem_Payment = OItem_Payment
        End If

        objOL_BankTransaction_To_Payment.Add(New clsObjectRel(Nothing, _
                                                                   GUID_Class_BankTransaction, _
                                                                   objOItem_Payment.GUID, _
                                                                   Nothing, _
                                                                   objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                                   objLocalConfig.Globals.Type_Object, _
                                                                   Nothing, _
                                                                   Nothing))

        objOItem_Result = objDBLevel_Payment.del_ObjectRel(objOL_BankTransaction_To_Payment)

        Return objOItem_Result
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Payment = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
