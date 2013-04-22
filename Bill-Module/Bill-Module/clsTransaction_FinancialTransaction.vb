Imports Ontolog_Module
Public Class clsTransaction_FinancialTransaction
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_FinancialTransaction As clsDBLevel

    Private objOItem_FinancialTransaction As clsOntologyItem

    Private objOAItem_TransactionDate As clsObjectAtt

    Private objLFinTran__TransactionID As New List(Of clsObjectAtt)

    Public Function save_001_FinancialTransaction(ByVal OItem_FinancialTransaction As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objLTransactions As New List(Of clsOntologyItem)

        objOItem_FinancialTransaction = OItem_FinancialTransaction

        objLTransactions.Add(OItem_FinancialTransaction)

        objOItem_Result = objDBLevel_FinancialTransaction.save_Objects(objLTransactions)

        Return objOItem_Result
    End Function

    Public Function del_001_FinancialTransaction(Optional ByVal OItem_FinancialTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objLTransactions As New List(Of clsOntologyItem)

        If Not OItem_FinancialTransaction Is Nothing Then
            objOItem_FinancialTransaction = OItem_FinancialTransaction
        End If

        objLTransactions.Add(OItem_FinancialTransaction)

        objOItem_Result = objDBLevel_FinancialTransaction.del_Objects(objLTransactions)

        Return objOItem_Result
    End Function

    Public Function save_002_FinancialTransaction__TransactionDate(ByVal dateTransactionDate As Date, Optional ByVal OItem_FinancialTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_del As clsOntologyItem
        Dim objOL_TransactionDate As New List(Of clsObjectAtt)
        Dim objOL_TransactionDate_Search As New List(Of clsObjectAtt)
        Dim objOL_TransactionDate_Del As New List(Of clsObjectAtt)

        If Not OItem_FinancialTransaction Is Nothing Then
            objOItem_FinancialTransaction = OItem_FinancialTransaction
        End If

        objOAItem_TransactionDate = New clsObjectAtt(Nothing, _
                                                     objOItem_FinancialTransaction.GUID, _
                                                     Nothing, _
                                                     objOItem_FinancialTransaction.GUID_Parent, _
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
                                                     objLocalConfig.Globals.DType_DateTime.GUID)

        objOL_TransactionDate.Add(objOAItem_TransactionDate)

        objOL_TransactionDate_Search.Add(New clsObjectAtt(Nothing, _
                                                          objOItem_FinancialTransaction.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Attribute_Transaction_Date.GUID, _
                                                          Nothing))

        objOItem_Result = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_del = objDBLevel_FinancialTransaction.get_Data_ObjectAtt(objOL_TransactionDate_Search)

        If objOItem_Result_del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLTransactionDate_Exist = From obj In objDBLevel_FinancialTransaction.OList_ObjectAtt_ID
                                      Where obj.Val_Date = objOAItem_TransactionDate.Val_Date

            Dim objLTransactionDate_Del = From obj In objDBLevel_FinancialTransaction.OList_ObjectAtt_ID
                                      Where obj.Val_Date <> objOAItem_TransactionDate.Val_Date

            If objLTransactionDate_Exist.Count > 0 Then
                objOItem_Result = objLocalConfig.Globals.LState_Success
            Else
                If objLTransactionDate_Del.Count > 0 Then
                    objOL_TransactionDate_Del.Add(New clsObjectAtt(Nothing, _
                                                                   objOItem_FinancialTransaction.GUID, _
                                                                   Nothing, _
                                                                   objLocalConfig.OItem_Attribute_Transaction_Date.GUID, _
                                                                   Nothing))
                    objOItem_Result_del = objDBLevel_FinancialTransaction.del_ObjectAtt(objOL_TransactionDate_Del)
                    If objOItem_Result_del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        objOItem_Result = objLocalConfig.Globals.LState_Error
                    End If
                End If

                
            End If
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOItem_Result = objDBLevel_FinancialTransaction.save_ObjAtt(objOL_TransactionDate)
        End If

        Return objOItem_Result
    End Function

    Public Function del_002_FinancialTransaction__TransactionDate(Optional ByVal OItem_FinancialTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLA_FinancialTransaction__TransactionDate As New List(Of clsObjectAtt)

        If Not OItem_FinancialTransaction Is Nothing Then
            objOItem_FinancialTransaction = OItem_FinancialTransaction
        End If

        objOLA_FinancialTransaction__TransactionDate.Add(New clsObjectAtt(Nothing, _
                                                                          objOItem_FinancialTransaction.GUID, _
                                                                          Nothing, _
                                                                          objLocalConfig.OItem_Attribute_Transaction_Date.GUID, _
                                                                          Nothing))

        objOItem_Result = objDBLevel_FinancialTransaction.del_ObjectAtt(objOLA_FinancialTransaction__TransactionDate)

        Return objOItem_Result
    End Function

    Public Function save_003_FinancialTransaction__TransactionID(ByVal TransactionID As String, Optional ByVal OItem_FinancialTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objLFinTran__TransactionID_Search As New List(Of clsObjectAtt)
        Dim objLFinTran__TransactionID_Del As New List(Of clsObjectAtt)


        If Not OItem_FinancialTransaction Is Nothing Then
            objOItem_FinancialTransaction = OItem_FinancialTransaction
        End If

        objLFinTran__TransactionID.Clear()

        objLFinTran__TransactionID_Search.Add(New clsObjectAtt(Nothing, _
                                                               objOItem_FinancialTransaction.GUID, _
                                                               Nothing, _
                                                               objLocalConfig.OItem_Attribute_Transaction_ID.GUID, _
                                                               Nothing))

        objOItem_Result_Search = objDBLevel_FinancialTransaction.get_Data_ObjectAtt(objLFinTran__TransactionID_Search, _
                                                                                    boolIDs:=False)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_FinancialTransaction.OList_ObjectAtt
                          Where obj.Val_String.ToLower <> TransactionID


            Dim objLExist = From obj In objDBLevel_FinancialTransaction.OList_ObjectAtt
                            Where obj.Val_String = TransactionID


            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objLFinTran__TransactionID_Del.Add(objDel)
                Next

                objOItem_Result_Del = objDBLevel_FinancialTransaction.del_ObjectAtt(objLFinTran__TransactionID_Del)
                If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    objOItem_Result = objLocalConfig.Globals.LState_Error
                    
                End If

            End If
            
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            End If

            
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objLFinTran__TransactionID.Add(New clsObjectAtt(Nothing, _
                                                            objOItem_FinancialTransaction.GUID, _
                                                            Nothing, _
                                                            objOItem_FinancialTransaction.GUID_Parent, _
                                                            Nothing, _
                                                            objLocalConfig.OItem_Attribute_Transaction_ID.GUID, _
                                                            Nothing, _
                                                            1, _
                                                            TransactionID, _
                                                            Nothing, _
                                                            Nothing, _
                                                            Nothing, _
                                                            Nothing, _
                                                            TransactionID, _
                                                            objLocalConfig.Globals.DType_String.GUID))

            objOItem_Result = objDBLevel_FinancialTransaction.save_ObjAtt(objLFinTran__TransactionID)
        End If

        Return objOItem_Result
    End Function

    Public Function del_003_FinancialTransaction__TransactionID(Optional ByVal OItem_FinancialTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objLFinTran__TransactionID As New List(Of clsObjectAtt)

        If Not OItem_FinancialTransaction Is Nothing Then
            objOItem_FinancialTransaction = OItem_FinancialTransaction
        End If

        objLFinTran__TransactionID.Add(New clsObjectAtt(Nothing, _
                                                        objOItem_FinancialTransaction.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Attribute_Transaction_ID.GUID, _
                                                        Nothing))

        objOItem_Result = objDBLevel_FinancialTransaction.del_ObjectAtt(objLFinTran__TransactionID)

        Return objOItem_Result
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_FinancialTransaction = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
