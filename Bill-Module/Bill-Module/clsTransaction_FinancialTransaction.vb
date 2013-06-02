Imports Ontolog_Module
Public Class clsTransaction_FinancialTransaction
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_FinancialTransaction As clsDBLevel

    Private objOItem_FinancialTransaction As clsOntologyItem
    Private objOItem_FinancialTransaction_Parent As clsOntologyItem

    Private objOAItem_TransactionDate As clsObjectAtt

    Private objLFinTran__TransactionID As New List(Of clsObjectAtt)
    Private objLFinTran__Sum As New List(Of clsObjectAtt)
    Private objOItem_Currency As clsOntologyItem
    Private objLFinTran__Gross As New List(Of clsObjectAtt)
    Private objOItem_TaxRate As clsOntologyItem
    Private objOItem_Partner As clsOntologyItem
    Private objOItem_RelationType_Partner As clsOntologyItem

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

    Public Function save_004_FinnacialTransaction__Sum(ByVal dblSum As Double, Optional ByVal OItem_FinancialTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem

        Dim objLFinancialTransaction_Search As New List(Of clsObjectAtt)
        Dim objLFinancialTransaction_Del As New List(Of clsObjectAtt)

        If Not OItem_FinancialTransaction Is Nothing Then
            objOItem_FinancialTransaction = OItem_FinancialTransaction
        End If

        objLFinancialTransaction_Search.Add(New clsObjectAtt(Nothing, _
                                                             objOItem_FinancialTransaction.GUID, _
                                                             Nothing, _
                                                             objLocalConfig.OItem_Attribute_to_Pay.GUID, _
                                                             Nothing))

        objOItem_Result_Search = objDBLevel_FinancialTransaction.get_Data_ObjectAtt(objLFinancialTransaction_Search, _
                                                                                    boolIDs:=False)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing
        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_FinancialTransaction.OList_ObjectAtt.Count > 0 Then
                Dim objLDel = From obj In objDBLevel_FinancialTransaction.OList_ObjectAtt
                          Where obj.Val_Double <> dblSum

                Dim objLExist = From obj In objDBLevel_FinancialTransaction.OList_ObjectAtt
                                Where obj.Val_Double = dblSum

                If objLDel.Count > 0 Then
                    For Each objDel In objLDel
                        objLFinancialTransaction_Del.Add(New clsObjectAtt(objDel.ID_Attribute, _
                                                                          Nothing, _
                                                                          Nothing, _
                                                                          Nothing, _
                                                                          Nothing))
                    Next

                    objOItem_Result_Del = objDBLevel_FinancialTransaction.del_ObjectAtt(objLFinancialTransaction_Del)
                    If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        objOItem_Result = objLocalConfig.Globals.LState_Error
                    End If
                End If

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
                    If objLExist.Count > 0 Then
                        objOItem_Result = objLocalConfig.Globals.LState_Success
                    End If
                End If
            End If
            


        Else
            objOItem_Result = objOItem_Result_Search
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objLFinTran__Sum.Clear()
            objLFinTran__Sum.Add(New clsObjectAtt(Nothing, _
                                                  objOItem_FinancialTransaction.GUID, _
                                                  Nothing, _
                                                  objOItem_FinancialTransaction.GUID_Parent, _
                                                  Nothing, _
                                                  objLocalConfig.OItem_Attribute_to_Pay.GUID, _
                                                  Nothing, _
                                                  1, _
                                                  dblSum.ToString,
                                                  Nothing, _
                                                  Nothing, _
                                                  Nothing, _
                                                  dblSum, _
                                                  Nothing, _
                                                  objLocalConfig.Globals.DType_Real.GUID))

            objOItem_Result = objDBLevel_FinancialTransaction.save_ObjAtt(objLFinTran__Sum)
        End If

        Return objOItem_Result
    End Function

    Public Function del_004_FinancialTransaction__Sum(Optional ByVal OItem_FinancialTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objLFinTran__Sum.Clear()

        If Not OItem_FinancialTransaction Is Nothing Then
            objOItem_FinancialTransaction = OItem_FinancialTransaction
        End If

        objLFinTran__Sum.Add(New clsObjectAtt(Nothing, _
                                              objOItem_FinancialTransaction.GUID, _
                                              Nothing, _
                                              objLocalConfig.OItem_Attribute_to_Pay.GUID, _
                                              Nothing))
        objOItem_Result = objDBLevel_FinancialTransaction.del_ObjectAtt(objLFinTran__Sum)

        Return objOItem_Result
    End Function

    Public Function save_005_FinancialTransaction_To_Currency(ByVal OItem_Currency As clsOntologyItem, Optional ByVal OItem_FinancialTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objLFinTran_To_Currency_Search As New List(Of clsObjectRel)
        Dim objLFinTran_To_Currency_Del As New List(Of clsObjectRel)
        Dim objLFinTran_To_Currency As New List(Of clsObjectRel)

        objOItem_Currency = OItem_Currency
        If Not OItem_FinancialTransaction Is Nothing Then
            objOItem_FinancialTransaction = OItem_FinancialTransaction
        End If

        objLFinTran_To_Currency_Search.Add(New clsObjectRel(objOItem_FinancialTransaction.GUID, _
                                                            Nothing, _
                                                            objOItem_Currency.GUID, _
                                                            Nothing, _
                                                            objLocalConfig.OItem_RelationType_belonging_Currency.GUID, _
                                                            objLocalConfig.Globals.Type_Object, _
                                                            Nothing, _
                                                            Nothing))

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objOItem_Result_Search = objDBLevel_FinancialTransaction.get_Data_ObjectRel(objLFinTran_To_Currency_Search)

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_FinancialTransaction.OList_ObjectRel_ID
                          Where obj.ID_Other <> objOItem_Currency.GUID

            Dim objLExist = From obj In objDBLevel_FinancialTransaction.OList_ObjectRel_ID
                            Where obj.ID_Other = objOItem_Currency.GUID

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success
            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objLFinTran_To_Currency_Del.Add(New clsObjectRel(objOItem_FinancialTransaction.GUID, _
                                                                     Nothing, _
                                                                     objDel.ID_Other, _
                                                                     Nothing, _
                                                                     objLocalConfig.OItem_RelationType_belonging_Currency.GUID, _
                                                                     objLocalConfig.Globals.Type_Object, _
                                                                     Nothing, _
                                                                     Nothing))

                Next

                objOItem_Result = objDBLevel_FinancialTransaction.del_ObjectRel(objLFinTran_To_Currency_Del)

            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Error
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objLFinTran_To_Currency.Add(New clsObjectRel(objOItem_FinancialTransaction.GUID, _
                                                         Nothing, _
                                                         objOItem_FinancialTransaction.GUID_Parent, _
                                                         Nothing, _
                                                         objOItem_Currency.GUID, _
                                                         Nothing, _
                                                         objOItem_Currency.GUID_Parent, _
                                                         Nothing, _
                                                         objLocalConfig.OItem_RelationType_belonging_Currency.GUID, _
                                                         Nothing, _
                                                         objLocalConfig.Globals.Type_Object, _
                                                         Nothing, _
                                                         Nothing, _
                                                         1))

            objOItem_Result = objDBLevel_FinancialTransaction.save_ObjRel(objLFinTran_To_Currency)

        End If

        Return objOItem_Result
    End Function

    Public Function del_005_FinancialTransaction_To_Currency(Optional ByVal OItem_FinancialTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objLFinancialTransaction_To_Curency As New List(Of clsObjectRel)

        If Not OItem_FinancialTransaction Is Nothing Then
            objOItem_FinancialTransaction = OItem_FinancialTransaction
        End If

        objLFinancialTransaction_To_Curency.Add(New clsObjectRel(objOItem_FinancialTransaction.GUID, _
                                                                 Nothing, _
                                                                 Nothing, _
                                                                 objLocalConfig.OItem_Class_Currencies.GUID, _
                                                                 objLocalConfig.OItem_RelationType_belonging_Currency.GUID, _
                                                                 objLocalConfig.Globals.Type_Object, _
                                                                 Nothing, _
                                                                 Nothing))

        objOItem_Result = objDBLevel_FinancialTransaction.del_ObjectRel(objLFinancialTransaction_To_Curency)


        Return objOItem_Result
    End Function

    Public Function save_006_FinancialTransaction__gross(ByVal boolGross As Boolean, Optional ByVal OItem_FinancialTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem

        Dim objLFinTran__gross_Search As New List(Of clsObjectAtt)
        Dim objLFinTran__gross_Del As New List(Of clsObjectAtt)

        If Not OItem_FinancialTransaction Is Nothing Then
            objOItem_FinancialTransaction = OItem_FinancialTransaction
        End If

        objLFinTran__gross_Search.Add(New clsObjectAtt(Nothing, _
                                                       objOItem_FinancialTransaction.GUID, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Attribute_gross.GUID, _
                                                       Nothing))

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objOItem_Result_Search = objDBLevel_FinancialTransaction.get_Data_ObjectAtt(objLFinTran__gross_Search, _
                                                                                    boolIDs:=False)

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_FinancialTransaction.OList_ObjectAtt
                          Where obj.Val_Bit <> boolGross

            Dim objLExist = From obj In objDBLevel_FinancialTransaction.OList_ObjectAtt
                            Where obj.Val_Bit = boolGross

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objLFinTran__gross_Del.Add(New clsObjectAtt(objDel.ID_Attribute, _
                                                                Nothing, _
                                                                Nothing, _
                                                                Nothing, _
                                                                Nothing))


                Next
                objOItem_Result_Del = objDBLevel_FinancialTransaction.del_ObjectAtt(objLFinTran__gross_Del)
            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objLFinTran__Gross.Add(New clsObjectAtt(Nothing, _
                                                    objOItem_FinancialTransaction.GUID, _
                                                    Nothing, _
                                                    objOItem_FinancialTransaction.GUID_Parent, _
                                                    Nothing, _
                                                    objLocalConfig.OItem_Attribute_gross.GUID, _
                                                    Nothing, _
                                                    1, _
                                                    boolGross, _
                                                    boolGross, _
                                                    Nothing, _
                                                    Nothing, _
                                                    Nothing, _
                                                    Nothing, _
                                                    objLocalConfig.Globals.DType_Bool.GUID))

            objOItem_Result = objDBLevel_FinancialTransaction.save_ObjAtt(objLFinTran__Gross)

        End If

        Return objOItem_Result
    End Function

    Public Function del_006_FinancialTransaction__Gross(Optional ByVal OItem_FinancialTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objLFinTran__Gross As New List(Of clsObjectAtt)

        If Not OItem_FinancialTransaction Is Nothing Then
            objOItem_FinancialTransaction = OItem_FinancialTransaction
        End If

        objLFinTran__Gross.Add(New clsObjectAtt(Nothing, _
                                                objOItem_FinancialTransaction.GUID, _
                                                Nothing, _
                                                objLocalConfig.OItem_Attribute_gross.GUID, _
                                                Nothing))

        objOItem_Result = objDBLevel_FinancialTransaction.del_ObjectAtt(objLFinTran__Gross)


        Return objOItem_Result
    End Function

    Public Function save_007_FinancialTransaction_To_TaxRate(ByVal OItem_TaxRate As clsOntologyItem, Optional ByVal OItem_FinancialTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objLFinTran_To_TaxRate_Search As New List(Of clsObjectRel)
        Dim objLFinTran_To_TaxRate_Del As New List(Of clsObjectRel)
        Dim objLFinTran_To_TaxRate As New List(Of clsObjectRel)

        objOItem_TaxRate = OItem_TaxRate
        If Not OItem_FinancialTransaction Is Nothing Then
            objOItem_FinancialTransaction = OItem_FinancialTransaction
        End If

        objLFinTran_To_TaxRate_Search.Add(New clsObjectRel(objOItem_FinancialTransaction.GUID, _
                                                            Nothing, _
                                                            objOItem_TaxRate.GUID, _
                                                            Nothing, _
                                                            objLocalConfig.OItem_RelationType_belonging_Tax_Rate.GUID, _
                                                            objLocalConfig.Globals.Type_Object, _
                                                            Nothing, _
                                                            Nothing))

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objOItem_Result_Search = objDBLevel_FinancialTransaction.get_Data_ObjectRel(objLFinTran_To_TaxRate_Search)

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_FinancialTransaction.OList_ObjectRel_ID
                          Where obj.ID_Other <> objOItem_TaxRate.GUID

            Dim objLExist = From obj In objDBLevel_FinancialTransaction.OList_ObjectRel_ID
                            Where obj.ID_Other = objOItem_TaxRate.GUID

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success
            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objLFinTran_To_TaxRate_Del.Add(New clsObjectRel(objOItem_FinancialTransaction.GUID, _
                                                                     Nothing, _
                                                                     objDel.ID_Other, _
                                                                     Nothing, _
                                                                     objLocalConfig.OItem_RelationType_belonging_Tax_Rate.GUID, _
                                                                     objLocalConfig.Globals.Type_Object, _
                                                                     Nothing, _
                                                                     Nothing))

                Next

                objOItem_Result = objDBLevel_FinancialTransaction.del_ObjectRel(objLFinTran_To_TaxRate_Del)

            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Error
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objLFinTran_To_TaxRate.Add(New clsObjectRel(objOItem_FinancialTransaction.GUID, _
                                                         Nothing, _
                                                         objOItem_FinancialTransaction.GUID_Parent, _
                                                         Nothing, _
                                                         objOItem_TaxRate.GUID, _
                                                         Nothing, _
                                                         objOItem_TaxRate.GUID_Parent, _
                                                         Nothing, _
                                                         objLocalConfig.OItem_RelationType_belonging_Tax_Rate.GUID, _
                                                         Nothing, _
                                                         objLocalConfig.Globals.Type_Object, _
                                                         Nothing, _
                                                         Nothing, _
                                                         1))

            objOItem_Result = objDBLevel_FinancialTransaction.save_ObjRel(objLFinTran_To_TaxRate)

        End If

        Return objOItem_Result
    End Function

    Public Function del_007_FinancialTransaction_To_TaxRate(Optional ByVal OItem_FinancialTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objLFinancialTransaction_To_Curency As New List(Of clsObjectRel)

        If Not OItem_FinancialTransaction Is Nothing Then
            objOItem_FinancialTransaction = OItem_FinancialTransaction
        End If

        objLFinancialTransaction_To_Curency.Add(New clsObjectRel(objOItem_FinancialTransaction.GUID, _
                                                                 Nothing, _
                                                                 Nothing, _
                                                                 objLocalConfig.OItem_Class_Currencies.GUID, _
                                                                 objLocalConfig.OItem_RelationType_belonging_Tax_Rate.GUID, _
                                                                 objLocalConfig.Globals.Type_Object, _
                                                                 Nothing, _
                                                                 Nothing))

        objOItem_Result = objDBLevel_FinancialTransaction.del_ObjectRel(objLFinancialTransaction_To_Curency)


        Return objOItem_Result
    End Function

    Public Function save_008_FinancialTransaction_To_Partner(ByVal OItem_Partner As clsOntologyItem, ByVal OItem_RelationType As clsOntologyItem, Optional ByVal OItem_FinancialTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem

        Dim objOLFinancialTransaction_To_Partner As New List(Of clsObjectRel)
        Dim objOLFinancialTransaction_To_Partner_Search As New List(Of clsObjectRel)
        Dim objOLFinancialTransaction_To_Partner_Del As New List(Of clsObjectRel)


        objOLFinancialTransaction_To_Partner.Clear()


        If Not OItem_FinancialTransaction Is Nothing Then
            objOItem_FinancialTransaction = OItem_FinancialTransaction
        End If

        objOItem_Partner = OItem_Partner
        objOItem_RelationType_Partner = OItem_RelationType

        objOLFinancialTransaction_To_Partner_Search.Add(New clsObjectRel(objOItem_FinancialTransaction.GUID, _
                                                                         Nothing, _
                                                                         Nothing, _
                                                                         objLocalConfig.OItem_Class_Partner.GUID, _
                                                                         objOItem_RelationType_Partner.GUID, _
                                                                         objLocalConfig.Globals.Type_Object, _
                                                                         Nothing, _
                                                                         Nothing))

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objOItem_Result_Search = objDBLevel_FinancialTransaction.get_Data_ObjectRel(objOLFinancialTransaction_To_Partner_Search)

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_FinancialTransaction.OList_ObjectRel_ID
                          Where obj.ID_Other <> objOItem_Partner.GUID

            Dim objLExist = From obj In objDBLevel_FinancialTransaction.OList_ObjectRel_ID
                            Where obj.ID_Other = objOItem_Partner.GUID


            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOLFinancialTransaction_To_Partner_Del.Add(New clsObjectRel(objOItem_FinancialTransaction.GUID, _
                                                                                  Nothing, _
                                                                                  objDel.ID_Other, _
                                                                                  Nothing, _
                                                                                  objOItem_RelationType_Partner.GUID, _
                                                                                  objLocalConfig.Globals.Type_Object, _
                                                                                  Nothing, _
                                                                                  Nothing))


                Next

                objOItem_Result_Del = objDBLevel_FinancialTransaction.del_ObjectRel(objOLFinancialTransaction_To_Partner_Del)
                If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objLExist.Count > 0 Then
                        objOItem_Result = objLocalConfig.Globals.LState_Success
                    End If
                Else
                    objOItem_Result = objLocalConfig.Globals.LState_Error
                End If
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOLFinancialTransaction_To_Partner.Add(New clsObjectRel(objOItem_FinancialTransaction.GUID, _
                                                                      objOItem_FinancialTransaction.GUID_Parent, _
                                                                      objOItem_Partner.GUID, _
                                                                      objOItem_Partner.GUID_Parent, _
                                                                      objOItem_RelationType_Partner.GUID, _
                                                                      objLocalConfig.Globals.Type_Object, _
                                                                      Nothing, _
                                                                      1))

            objOItem_Result = objDBLevel_FinancialTransaction.save_ObjRel(objOLFinancialTransaction_To_Partner)

        End If

        Return objOItem_Result
    End Function

    Public Function del_008_FinancialTransaction_To_Partner(Optional ByVal OItem_RelationType As clsOntologyItem = Nothing, Optional ByVal OItem_FinancialTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_FinancialTransaction_To_Partner_Del As New List(Of clsObjectRel)

        If Not OItem_RelationType Is Nothing Then
            objOItem_RelationType_Partner = OItem_RelationType
        End If

        If Not OItem_FinancialTransaction Is Nothing Then
            objOItem_FinancialTransaction = OItem_FinancialTransaction
        End If

        objOList_FinancialTransaction_To_Partner_Del.Add(New clsObjectRel(objOItem_FinancialTransaction.GUID, _
                                                                          Nothing, _
                                                                          Nothing, _
                                                                          objLocalConfig.OItem_Class_Partner.GUID, _
                                                                          objOItem_RelationType_Partner.GUID, _
                                                                          objLocalConfig.Globals.Type_Object, _
                                                                          Nothing, _
                                                                          Nothing))

        objOItem_Result = objDBLevel_FinancialTransaction.del_ObjectRel(objOList_FinancialTransaction_To_Partner_Del)

        Return objOItem_Result
    End Function

    Public Function save_009_FinancialTransaction_To_FinancialTransaction(ByVal OItem_FinancialTransaction_Parent As clsOntologyItem, Optional ByVal OItem_FinancialTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOList_FinancialTransaction As New List(Of clsObjectRel)
        Dim objOList_FinancialTransaction_Search As New List(Of clsObjectRel)
        Dim objOList_FinancialTransaction_Del As New List(Of clsObjectRel)

        objOItem_FinancialTransaction_Parent = objOItem_FinancialTransaction_Parent
        If Not OItem_FinancialTransaction Is Nothing Then
            objOItem_FinancialTransaction = OItem_FinancialTransaction
        End If

        objOList_FinancialTransaction_Search.Add(New clsObjectRel(Nothing, _
                                                                  objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                                  objOItem_FinancialTransaction.GUID, _
                                                                  Nothing, _
                                                                  objLocalConfig.OItem_RelationType_contains.GUID, _
                                                                  objLocalConfig.Globals.Type_Object, _
                                                                  Nothing, _
                                                                  Nothing))

        objOItem_Result_Search = objDBLevel_FinancialTransaction.get_Data_ObjectRel(objOList_FinancialTransaction_Search)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_FinancialTransaction.OList_ObjectRel_ID
                          Where Not obj.ID_Object = objOItem_FinancialTransaction_Parent.GUID

            Dim objLExist = From obj In objDBLevel_FinancialTransaction.OList_ObjectRel_ID
                            Where obj.ID_Object = objOItem_FinancialTransaction_Parent.GUID


            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOList_FinancialTransaction_Del.Add(New clsObjectRel(objDel.ID_Object, _
                                                                           Nothing, _
                                                                           objDel.ID_Other, _
                                                                           Nothing, _
                                                                           objLocalConfig.OItem_RelationType_contains.GUID, _
                                                                           objLocalConfig.Globals.Type_Object, _
                                                                           Nothing, _
                                                                           Nothing))

                Next

                objOItem_Result_Del = objDBLevel_FinancialTransaction.del_ObjectRel(objOList_FinancialTransaction_Del)


            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            Else
                objOItem_Result = objOItem_Result_Del
            End If

        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOList_FinancialTransaction.Add(New clsObjectRel(objOItem_FinancialTransaction_Parent.GUID, _
                                                               objOItem_FinancialTransaction_Parent.GUID_Parent, _
                                                               objOItem_FinancialTransaction.GUID, _
                                                               objOItem_FinancialTransaction.GUID_Parent, _
                                                               objLocalConfig.OItem_RelationType_contains.GUID, _
                                                               objLocalConfig.Globals.Type_Object, _
                                                               Nothing, _
                                                               1))

            objOItem_Result = objDBLevel_FinancialTransaction.save_ObjRel(objOList_FinancialTransaction)

        End If

        Return objOItem_Result
    End Function

    Public Function del_009_FinancialTransaction_To_FinancialTransaction(Optional ByVal OItem_FinancialTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_FinancialTransactions_Del As New List(Of clsObjectRel)

        If Not OItem_FinancialTransaction Is Nothing Then
            objOItem_FinancialTransaction = OItem_FinancialTransaction
        End If

        objOList_FinancialTransactions_Del.Add(New clsObjectRel(Nothing, _
                                                                objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                                objOItem_FinancialTransaction.GUID, _
                                                                Nothing, _
                                                                objLocalConfig.OItem_RelationType_contains.GUID, _
                                                                objLocalConfig.Globals.Type_Object, _
                                                                Nothing, _
                                                                Nothing))

        objOItem_Result = objDBLevel_FinancialTransaction.del_ObjectRel(objOList_FinancialTransactions_Del)


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
