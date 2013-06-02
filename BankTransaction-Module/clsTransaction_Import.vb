Imports Ontolog_Module
Public Class clsTransaction_Import

    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Import As clsDBLevel

    Private objOItem_BankTransaction As clsOntologyItem
    Private objOAItem_BTR_Info As clsObjectAtt
    Private objOAItem_BTR_Valutadatum As clsObjectAtt
    Private objOAItem_BTR_Zahlungsausgang As clsObjectAtt
    Private objOAItem_BTR_BegZahl As clsObjectAtt
    Private objOAItem_BTR_Betrag As clsObjectAtt
    Private objOAItem_BTR_Buchungstext As clsObjectAtt
    Private objOAItem_BTR_Verwendungszweck As clsObjectAtt
    Private objOItem_Auftragskonto As clsOntologyItem
    Private objOItem_Gegenkonto As clsOntologyItem
    Private objOItem_Currency As clsOntologyItem

    Private objOItem_Konto As clsOntologyItem
    Private objOItem_BLZ As clsOntologyItem

    Public Function save_001_BankTransaciton(ByVal OItem_BankTransaction As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBankTransaction As New List(Of clsOntologyItem)

        objOItem_BankTransaction = OItem_BankTransaction

        objOLBankTransaction.Add(objOItem_BankTransaction)

        objOItem_Result = objDBLevel_Import.save_Objects(objOLBankTransaction)

        Return objOItem_Result
    End Function

    Public Function del_001_BankTransaction(Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBankTransaction As New List(Of clsOntologyItem)

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If

        objOLBankTransaction.Add(objOItem_BankTransaction)

        objOItem_Result = objDBLevel_Import.del_Objects(objOLBankTransaction)

        Return objOItem_Result
    End Function

    Public Function save_002_BankTransaction__Info(ByVal Info As String, Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBTR__Info As New List(Of clsObjectAtt)
        Dim objOLBTR__Info_Search As New List(Of clsObjectAtt)
        Dim objOLBTR__Info_Del As New List(Of clsObjectAtt)
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim strNamed As String

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If


        If Info.Length > 255 Then
            strNamed = Info.Substring(0, 254)
        Else
            strNamed = Info
        End If

        objOLBTR__Info_Search.Add(New clsObjectAtt(Nothing, _
                                                   objOItem_BankTransaction.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_Attribute_Info.GUID, _
                                                   Nothing))

        objOItem_Result_Search = objDBLevel_Import.get_Data_ObjectAtt(objOLBTR__Info_Search, _
                                                                      boolIDs:=False)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Import.OList_ObjectAtt
                          Where obj.Val_String.ToLower() <> Info.ToLower()

            Dim objLExist = From obj In objDBLevel_Import.OList_ObjectAtt
                            Where obj.Val_String.ToLower() = Info.ToLower()

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOLBTR__Info_Del.Add(New clsObjectAtt(objDel.ID_Attribute, Nothing, Nothing, Nothing, Nothing))

                Next

                objOItem_Result_Del = objDBLevel_Import.del_ObjectAtt(objOLBTR__Info_Del)
            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            End If
        Else
            objOItem_Result = objOItem_Result_Search
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOAItem_BTR_Info = New clsObjectAtt(Nothing, _
                                              objOItem_BankTransaction.GUID, _
                                              Nothing, _
                                              objOItem_BankTransaction.GUID_Parent, _
                                              Nothing, _
                                              objLocalConfig.OItem_Attribute_Info.GUID, _
                                              Nothing, _
                                              1, _
                                              strNamed, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              Info, _
                                              objLocalConfig.Globals.DType_String.GUID)

            objOLBTR__Info.Add(objOAItem_BTR_Info)

            objOItem_Result = objDBLevel_Import.save_ObjAtt(objOLBTR__Info)
        End If

        Return objOItem_Result
    End Function

    Public Function del_002_BankTransaction__Info(Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBTR__Info_Del As New List(Of clsObjectAtt)

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If

        objOLBTR__Info_Del.Add(New clsObjectAtt(Nothing, _
                                                objOItem_BankTransaction.GUID, _
                                                Nothing, _
                                                objLocalConfig.OItem_Attribute_Info.GUID, _
                                                Nothing))

        objOItem_Result = objDBLevel_Import.del_ObjectAtt(objOLBTR__Info_Del)


        Return objOItem_Result
    End Function

    Public Function save_003_BankTransaction__Valutadatum(ByVal Valutadatum As Date, Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBTR__Valutadatum As New List(Of clsObjectAtt)
        Dim objOLBTR__Valutadatum_Search As New List(Of clsObjectAtt)
        Dim objOLBTR__Valutadatum_Del As New List(Of clsObjectAtt)
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim strNamed As String

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If


        objOLBTR__Valutadatum_Search.Add(New clsObjectAtt(Nothing, _
                                                   objOItem_BankTransaction.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_Attribute_Valutatag.GUID, _
                                                   Nothing))

        objOItem_Result_Search = objDBLevel_Import.get_Data_ObjectAtt(objOLBTR__Valutadatum_Search, _
                                                                      boolIDs:=False)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Import.OList_ObjectAtt
                          Where Not obj.Val_Date = Valutadatum

            Dim objLExist = From obj In objDBLevel_Import.OList_ObjectAtt
                            Where obj.Val_Date = Valutadatum

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOLBTR__Valutadatum_Del.Add(New clsObjectAtt(objDel.ID_Attribute, Nothing, Nothing, Nothing, Nothing))

                Next

                objOItem_Result_Del = objDBLevel_Import.del_ObjectAtt(objOLBTR__Valutadatum_Del)
            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            End If
        Else
            objOItem_Result = objOItem_Result_Search
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOAItem_BTR_Valutadatum = New clsObjectAtt(Nothing, _
                                              objOItem_BankTransaction.GUID, _
                                              Nothing, _
                                              objOItem_BankTransaction.GUID_Parent, _
                                              Nothing, _
                                              objLocalConfig.OItem_Attribute_Valutatag.GUID, _
                                              Nothing, _
                                              1, _
                                              Valutadatum.ToString, _
                                              Nothing, _
                                              Valutadatum, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              objLocalConfig.Globals.DType_DateTime.GUID)

            objOLBTR__Valutadatum.Add(objOAItem_BTR_Valutadatum)

            objOItem_Result = objDBLevel_Import.save_ObjAtt(objOLBTR__Valutadatum)
        End If

        Return objOItem_Result
    End Function

    Public Function del_003_BankTransaction__Valutadatum(Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBTR__Valutadatum_Del As New List(Of clsObjectAtt)

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If

        objOLBTR__Valutadatum_Del.Add(New clsObjectAtt(Nothing, _
                                                objOItem_BankTransaction.GUID, _
                                                Nothing, _
                                                objLocalConfig.OItem_Attribute_Valutatag.GUID, _
                                                Nothing))

        objOItem_Result = objDBLevel_Import.del_ObjectAtt(objOLBTR__Valutadatum_Del)


        Return objOItem_Result
    End Function

    Public Function save_004_BankTransaction__Zahlungsausgang(ByVal Zahlungsausgang As Boolean, Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBTR__Zahlungsausgang As New List(Of clsObjectAtt)
        Dim objOLBTR__Zahlungsausgang_Search As New List(Of clsObjectAtt)
        Dim objOLBTR__Zahlungsausgang_Del As New List(Of clsObjectAtt)
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim strNamed As String

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If

        If Zahlungsausgang = True Then
            strNamed = "True"
        Else
            strNamed = "False"
        End If


        objOLBTR__Zahlungsausgang_Search.Add(New clsObjectAtt(Nothing, _
                                                   objOItem_BankTransaction.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_Attribute_Zahlungsausgang.GUID, _
                                                   Nothing))

        objOItem_Result_Search = objDBLevel_Import.get_Data_ObjectAtt(objOLBTR__Zahlungsausgang_Search, _
                                                                      boolIDs:=False)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Import.OList_ObjectAtt
                          Where Not obj.Val_Bit = Zahlungsausgang

            Dim objLExist = From obj In objDBLevel_Import.OList_ObjectAtt
                            Where obj.Val_Bit = Zahlungsausgang

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOLBTR__Zahlungsausgang_Del.Add(New clsObjectAtt(objDel.ID_Attribute, Nothing, Nothing, Nothing, Nothing))

                Next

                objOItem_Result_Del = objDBLevel_Import.del_ObjectAtt(objOLBTR__Zahlungsausgang_Del)
            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            End If
        Else
            objOItem_Result = objOItem_Result_Search
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOAItem_BTR_Zahlungsausgang = New clsObjectAtt(Nothing, _
                                              objOItem_BankTransaction.GUID, _
                                              Nothing, _
                                              objOItem_BankTransaction.GUID_Parent, _
                                              Nothing, _
                                              objLocalConfig.OItem_Attribute_Zahlungsausgang.GUID, _
                                              Nothing, _
                                              1, _
                                              Zahlungsausgang.ToString, _
                                              Zahlungsausgang, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              objLocalConfig.Globals.DType_Bool.GUID)

            objOLBTR__Zahlungsausgang.Add(objOAItem_BTR_Zahlungsausgang)

            objOItem_Result = objDBLevel_Import.save_ObjAtt(objOLBTR__Zahlungsausgang)
        End If

        Return objOItem_Result
    End Function

    Public Function del_004_BankTransaction__Zahlungsausgang(Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBTR__Zahlungsausgang_Del As New List(Of clsObjectAtt)

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If

        objOLBTR__Zahlungsausgang_Del.Add(New clsObjectAtt(Nothing, _
                                                objOItem_BankTransaction.GUID, _
                                                Nothing, _
                                                objLocalConfig.OItem_Attribute_Zahlungsausgang.GUID, _
                                                Nothing))

        objOItem_Result = objDBLevel_Import.del_ObjectAtt(objOLBTR__Zahlungsausgang_Del)


        Return objOItem_Result
    End Function

    Public Function save_005_BankTransaction__BegZahl(ByVal BegZahl As String, Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBTR__BegZahl As New List(Of clsObjectAtt)
        Dim objOLBTR__BegZahl_Search As New List(Of clsObjectAtt)
        Dim objOLBTR__BegZahl_Del As New List(Of clsObjectAtt)
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim strNamed As String

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If


        If BegZahl.Length > 255 Then
            strNamed = BegZahl.Substring(0, 254)
        Else
            strNamed = BegZahl
        End If

        objOLBTR__BegZahl_Search.Add(New clsObjectAtt(Nothing, _
                                                   objOItem_BankTransaction.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_Attribute_Beg_nstigter_Zahlungspflichtiger.GUID, _
                                                   Nothing))

        objOItem_Result_Search = objDBLevel_Import.get_Data_ObjectAtt(objOLBTR__BegZahl_Search, _
                                                                      boolIDs:=False)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Import.OList_ObjectAtt
                          Where obj.Val_String.ToLower() <> BegZahl.ToLower()

            Dim objLExist = From obj In objDBLevel_Import.OList_ObjectAtt
                            Where obj.Val_String.ToLower() = BegZahl.ToLower()

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOLBTR__BegZahl_Del.Add(New clsObjectAtt(objDel.ID_Attribute, Nothing, Nothing, Nothing, Nothing))

                Next

                objOItem_Result_Del = objDBLevel_Import.del_ObjectAtt(objOLBTR__BegZahl_Del)
            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            End If
        Else
            objOItem_Result = objOItem_Result_Search
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOAItem_BTR_BegZahl = New clsObjectAtt(Nothing, _
                                              objOItem_BankTransaction.GUID, _
                                              Nothing, _
                                              objOItem_BankTransaction.GUID_Parent, _
                                              Nothing, _
                                              objLocalConfig.OItem_Attribute_Beg_nstigter_Zahlungspflichtiger.GUID, _
                                              Nothing, _
                                              1, _
                                              strNamed, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              BegZahl, _
                                              objLocalConfig.Globals.DType_String.GUID)

            objOLBTR__BegZahl.Add(objOAItem_BTR_BegZahl)

            objOItem_Result = objDBLevel_Import.save_ObjAtt(objOLBTR__BegZahl)
        End If

        Return objOItem_Result
    End Function

    Public Function del_005_BankTransaction__BegZahl(Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBTR__BegZahl_Del As New List(Of clsObjectAtt)

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If

        objOLBTR__BegZahl_Del.Add(New clsObjectAtt(Nothing, _
                                                objOItem_BankTransaction.GUID, _
                                                Nothing, _
                                                objLocalConfig.OItem_Attribute_Beg_nstigter_Zahlungspflichtiger.GUID, _
                                                Nothing))

        objOItem_Result = objDBLevel_Import.del_ObjectAtt(objOLBTR__BegZahl_Del)


        Return objOItem_Result
    End Function

    Public Function save_006_BankTransaction__Betrag(ByVal Betrag As Double, Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBTR__Betrag As New List(Of clsObjectAtt)
        Dim objOLBTR__Betrag_Search As New List(Of clsObjectAtt)
        Dim objOLBTR__Betrag_Del As New List(Of clsObjectAtt)
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem


        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If




        objOLBTR__Betrag_Search.Add(New clsObjectAtt(Nothing, _
                                                   objOItem_BankTransaction.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_Attribute_Betrag.GUID, _
                                                   Nothing))

        objOItem_Result_Search = objDBLevel_Import.get_Data_ObjectAtt(objOLBTR__Betrag_Search, _
                                                                      boolIDs:=False)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Import.OList_ObjectAtt
                          Where obj.Val_Double <> Betrag

            Dim objLExist = From obj In objDBLevel_Import.OList_ObjectAtt
                            Where obj.Val_Double = Betrag

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOLBTR__Betrag_Del.Add(New clsObjectAtt(objDel.ID_Attribute, Nothing, Nothing, Nothing, Nothing))

                Next

                objOItem_Result_Del = objDBLevel_Import.del_ObjectAtt(objOLBTR__Betrag_Del)
            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            End If
        Else
            objOItem_Result = objOItem_Result_Search
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOAItem_BTR_Betrag = New clsObjectAtt(Nothing, _
                                              objOItem_BankTransaction.GUID, _
                                              Nothing, _
                                              objOItem_BankTransaction.GUID_Parent, _
                                              Nothing, _
                                              objLocalConfig.OItem_Attribute_Betrag.GUID, _
                                              Nothing, _
                                              1, _
                                              Betrag.ToString, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              Betrag, _
                                              Nothing, _
                                              objLocalConfig.Globals.DType_Real.GUID)

            objOLBTR__Betrag.Add(objOAItem_BTR_Betrag)

            objOItem_Result = objDBLevel_Import.save_ObjAtt(objOLBTR__Betrag)
        End If

        Return objOItem_Result
    End Function

    Public Function del_006_BankTransaction__Betrag(Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBTR__Betrag_Del As New List(Of clsObjectAtt)

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If

        objOLBTR__Betrag_Del.Add(New clsObjectAtt(Nothing, _
                                                objOItem_BankTransaction.GUID, _
                                                Nothing, _
                                                objLocalConfig.OItem_Attribute_Betrag.GUID, _
                                                Nothing))

        objOItem_Result = objDBLevel_Import.del_ObjectAtt(objOLBTR__Betrag_Del)


        Return objOItem_Result
    End Function

    Public Function save_007_BankTransaction__Buchungstext(ByVal Buchungstext As String, Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBTR__Buchungstext As New List(Of clsObjectAtt)
        Dim objOLBTR__Buchungstext_Search As New List(Of clsObjectAtt)
        Dim objOLBTR__Buchungstext_Del As New List(Of clsObjectAtt)
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim strNamed As String

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If


        If Buchungstext.Length > 255 Then
            strNamed = Buchungstext.Substring(0, 254)
        Else
            strNamed = Buchungstext
        End If

        objOLBTR__Buchungstext_Search.Add(New clsObjectAtt(Nothing, _
                                                   objOItem_BankTransaction.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_Attribute_Buchungstext.GUID, _
                                                   Nothing))

        objOItem_Result_Search = objDBLevel_Import.get_Data_ObjectAtt(objOLBTR__Buchungstext_Search, _
                                                                      boolIDs:=False)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Import.OList_ObjectAtt
                          Where obj.Val_String.ToLower() <> Buchungstext.ToLower()

            Dim objLExist = From obj In objDBLevel_Import.OList_ObjectAtt
                            Where obj.Val_String.ToLower() = Buchungstext.ToLower()

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOLBTR__Buchungstext_Del.Add(New clsObjectAtt(objDel.ID_Attribute, Nothing, Nothing, Nothing, Nothing))

                Next

                objOItem_Result_Del = objDBLevel_Import.del_ObjectAtt(objOLBTR__Buchungstext_Del)
            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            End If
        Else
            objOItem_Result = objOItem_Result_Search
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOAItem_BTR_Buchungstext = New clsObjectAtt(Nothing, _
                                              objOItem_BankTransaction.GUID, _
                                              Nothing, _
                                              objOItem_BankTransaction.GUID_Parent, _
                                              Nothing, _
                                              objLocalConfig.OItem_Attribute_Buchungstext.GUID, _
                                              Nothing, _
                                              1, _
                                              strNamed, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              Buchungstext, _
                                              objLocalConfig.Globals.DType_String.GUID)

            objOLBTR__Buchungstext.Add(objOAItem_BTR_Buchungstext)

            objOItem_Result = objDBLevel_Import.save_ObjAtt(objOLBTR__Buchungstext)
        End If

        Return objOItem_Result
    End Function

    Public Function del_007_BankTransaction__Buchungstext(Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBTR__Buchungstext_Del As New List(Of clsObjectAtt)

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If

        objOLBTR__Buchungstext_Del.Add(New clsObjectAtt(Nothing, _
                                                objOItem_BankTransaction.GUID, _
                                                Nothing, _
                                                objLocalConfig.OItem_Attribute_Buchungstext.GUID, _
                                                Nothing))

        objOItem_Result = objDBLevel_Import.del_ObjectAtt(objOLBTR__Buchungstext_Del)


        Return objOItem_Result
    End Function

    Public Function save_008_BankTransaction__Verwendungszweck(ByVal Verwendungszweck As String, Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBTR__Verwendungszweck As New List(Of clsObjectAtt)
        Dim objOLBTR__Verwendungszweck_Search As New List(Of clsObjectAtt)
        Dim objOLBTR__Verwendungszweck_Del As New List(Of clsObjectAtt)
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim strNamed As String

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If


        If Verwendungszweck.Length > 255 Then
            strNamed = Verwendungszweck.Substring(0, 254)
        Else
            strNamed = Verwendungszweck
        End If

        objOLBTR__Verwendungszweck_Search.Add(New clsObjectAtt(Nothing, _
                                                   objOItem_BankTransaction.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_Attribute_Verwendungszweck.GUID, _
                                                   Nothing))

        objOItem_Result_Search = objDBLevel_Import.get_Data_ObjectAtt(objOLBTR__Verwendungszweck_Search, _
                                                                      boolIDs:=False)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Import.OList_ObjectAtt
                          Where obj.Val_String.ToLower() <> Verwendungszweck.ToLower()

            Dim objLExist = From obj In objDBLevel_Import.OList_ObjectAtt
                            Where obj.Val_String.ToLower() = Verwendungszweck.ToLower()

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOLBTR__Verwendungszweck_Del.Add(New clsObjectAtt(objDel.ID_Attribute, Nothing, Nothing, Nothing, Nothing))

                Next

                objOItem_Result_Del = objDBLevel_Import.del_ObjectAtt(objOLBTR__Verwendungszweck_Del)
            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            End If
        Else
            objOItem_Result = objOItem_Result_Search
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOAItem_BTR_Verwendungszweck = New clsObjectAtt(Nothing, _
                                              objOItem_BankTransaction.GUID, _
                                              Nothing, _
                                              objOItem_BankTransaction.GUID_Parent, _
                                              Nothing, _
                                              objLocalConfig.OItem_Attribute_Verwendungszweck.GUID, _
                                              Nothing, _
                                              1, _
                                              strNamed, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              Verwendungszweck, _
                                              objLocalConfig.Globals.DType_String.GUID)

            objOLBTR__Verwendungszweck.Add(objOAItem_BTR_Verwendungszweck)

            objOItem_Result = objDBLevel_Import.save_ObjAtt(objOLBTR__Verwendungszweck)
        End If

        Return objOItem_Result
    End Function

    Public Function del_008_BankTransaction__Verwendungszweck(Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBTR__Verwendungszweck_Del As New List(Of clsObjectAtt)

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If

        objOLBTR__Verwendungszweck_Del.Add(New clsObjectAtt(Nothing, _
                                                objOItem_BankTransaction.GUID, _
                                                Nothing, _
                                                objLocalConfig.OItem_Attribute_Verwendungszweck.GUID, _
                                                Nothing))

        objOItem_Result = objDBLevel_Import.del_ObjectAtt(objOLBTR__Verwendungszweck_Del)


        Return objOItem_Result
    End Function

    Public Function save_009_BankTransaction_To_Auftragskonto(ByVal OItem_Auftragskonto As clsOntologyItem, Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem

        Dim objOLBTR_To_Auftragskonto As New List(Of clsObjectRel)
        Dim objOLBTR_To_Auftragskonto_Search As New List(Of clsObjectRel)
        Dim objOLBTR_To_Auftragskonto_Del As New List(Of clsObjectRel)

        objOItem_Auftragskonto = OItem_Auftragskonto

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If

        objOLBTR_To_Auftragskonto_Search.Add(New clsObjectRel(objOItem_BankTransaction.GUID, _
                                                              Nothing, _
                                                              Nothing, _
                                                              objLocalConfig.OItem_Type_Kontonummer.GUID, _
                                                              objLocalConfig.OItem_RelationType_Auftragskonto.GUID, _
                                                              objLocalConfig.Globals.Type_Object, _
                                                              Nothing, _
                                                              Nothing))

        objOItem_Result_Search = objDBLevel_Import.get_Data_ObjectRel(objOLBTR_To_Auftragskonto_Search)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Import.OList_ObjectRel_ID
                          Where Not obj.ID_Other = objOItem_Auftragskonto.GUID

            Dim objLExist = From obj In objDBLevel_Import.OList_ObjectRel_ID
                            Where obj.ID_Other = objOItem_Auftragskonto.GUID

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then

                For Each objDel In objLDel
                    objOLBTR_To_Auftragskonto_Del.Add(New clsObjectRel(objDel.ID_Object, _
                                                                       Nothing, _
                                                                       objDel.ID_Other, _
                                                                       Nothing, _
                                                                       objDel.ID_RelationType, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       Nothing))


                Next

                objOItem_Result_Del = objDBLevel_Import.del_ObjectRel(objOLBTR_To_Auftragskonto_Del)
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
            objOLBTR_To_Auftragskonto.Add(New clsObjectRel(objOItem_BankTransaction.GUID, _
                                                           objOItem_BankTransaction.GUID_Parent, _
                                                           objOItem_Auftragskonto.GUID, _
                                                           objOItem_Auftragskonto.GUID_Parent, _
                                                           objLocalConfig.OItem_RelationType_Auftragskonto.GUID, _
                                                           objLocalConfig.Globals.Type_Object, _
                                                           Nothing, _
                                                           1))
            objOItem_Result = objDBLevel_Import.save_ObjRel(objOLBTR_To_Auftragskonto)
        End If

        Return objOItem_Result
    End Function

    Public Function del_009_BankTransaction__Auftragskonto(Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBTR__Auftragskonto_Del As New List(Of clsObjectRel)

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If

        objOLBTR__Auftragskonto_Del.Add(New clsObjectRel(objOItem_BankTransaction.GUID, _
                                                         Nothing, _
                                                         Nothing, _
                                                         objLocalConfig.OItem_Type_Kontonummer.GUID, _
                                                         objLocalConfig.OItem_RelationType_Auftragskonto.GUID, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing))

        objOItem_Result = objDBLevel_Import.del_ObjectRel(objOLBTR__Auftragskonto_Del)


        Return objOItem_Result
    End Function

    Public Function save_010_BankTransaction_To_Gegenkonto(ByVal OItem_Gegenkonto As clsOntologyItem, Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem

        Dim objOLBTR_To_Gegenkonto As New List(Of clsObjectRel)
        Dim objOLBTR_To_Gegenkonto_Search As New List(Of clsObjectRel)
        Dim objOLBTR_To_Gegenkonto_Del As New List(Of clsObjectRel)

        objOItem_Gegenkonto = OItem_Gegenkonto

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If

        objOLBTR_To_Gegenkonto_Search.Add(New clsObjectRel(objOItem_BankTransaction.GUID, _
                                                              Nothing, _
                                                              Nothing, _
                                                              objLocalConfig.OItem_Type_Kontonummer.GUID, _
                                                              objLocalConfig.OItem_RelationType_Gegenkonto.GUID, _
                                                              objLocalConfig.Globals.Type_Object, _
                                                              Nothing, _
                                                              Nothing))

        objOItem_Result_Search = objDBLevel_Import.get_Data_ObjectRel(objOLBTR_To_Gegenkonto_Search)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Import.OList_ObjectRel_ID
                          Where Not obj.ID_Other = objOItem_Gegenkonto.GUID

            Dim objLExist = From obj In objDBLevel_Import.OList_ObjectRel_ID
                            Where obj.ID_Other = objOItem_Gegenkonto.GUID

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then

                For Each objDel In objLDel
                    objOLBTR_To_Gegenkonto_Del.Add(New clsObjectRel(objDel.ID_Object, _
                                                                       Nothing, _
                                                                       objDel.ID_Other, _
                                                                       Nothing, _
                                                                       objDel.ID_RelationType, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       Nothing))


                Next

                objOItem_Result_Del = objDBLevel_Import.del_ObjectRel(objOLBTR_To_Gegenkonto_Del)
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
            objOLBTR_To_Gegenkonto.Add(New clsObjectRel(objOItem_BankTransaction.GUID, _
                                                           objOItem_BankTransaction.GUID_Parent, _
                                                           objOItem_Gegenkonto.GUID, _
                                                           objOItem_Gegenkonto.GUID_Parent, _
                                                           objLocalConfig.OItem_RelationType_Gegenkonto.GUID, _
                                                           objLocalConfig.Globals.Type_Object, _
                                                           Nothing, _
                                                           1))
            objOItem_Result = objDBLevel_Import.save_ObjRel(objOLBTR_To_Gegenkonto)
        End If

        Return objOItem_Result
    End Function

    Public Function del_010_BankTransaction__Gegenkonto(Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBTR__Gegenkonto_Del As New List(Of clsObjectRel)

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If

        objOLBTR__Gegenkonto_Del.Add(New clsObjectRel(objOItem_BankTransaction.GUID, _
                                                         Nothing, _
                                                         Nothing, _
                                                         objLocalConfig.OItem_Type_Kontonummer.GUID, _
                                                         objLocalConfig.OItem_RelationType_Gegenkonto.GUID, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing))

        objOItem_Result = objDBLevel_Import.del_ObjectRel(objOLBTR__Gegenkonto_Del)


        Return objOItem_Result
    End Function

    Public Function save_011_BankTransaction_To_Currency(ByVal OItem_Currency As clsOntologyItem, Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem

        Dim objOLBTR_To_Currency As New List(Of clsObjectRel)
        Dim objOLBTR_To_Currency_Search As New List(Of clsObjectRel)
        Dim objOLBTR_To_Currency_Del As New List(Of clsObjectRel)

        objOItem_Currency = OItem_Currency

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If

        objOLBTR_To_Currency_Search.Add(New clsObjectRel(objOItem_BankTransaction.GUID, _
                                                              Nothing, _
                                                              Nothing, _
                                                              objLocalConfig.OItem_Type_Currencies.GUID, _
                                                              objLocalConfig.OItem_RelationType_belonging.GUID, _
                                                              objLocalConfig.Globals.Type_Object, _
                                                              Nothing, _
                                                              Nothing))

        objOItem_Result_Search = objDBLevel_Import.get_Data_ObjectRel(objOLBTR_To_Currency_Search)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Import.OList_ObjectRel_ID
                          Where Not obj.ID_Other = objOItem_Currency.GUID

            Dim objLExist = From obj In objDBLevel_Import.OList_ObjectRel_ID
                            Where obj.ID_Other = objOItem_Currency.GUID

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then

                For Each objDel In objLDel
                    objOLBTR_To_Currency_Del.Add(New clsObjectRel(objDel.ID_Object, _
                                                                       Nothing, _
                                                                       objDel.ID_Other, _
                                                                       Nothing, _
                                                                       objDel.ID_RelationType, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       Nothing))


                Next

                objOItem_Result_Del = objDBLevel_Import.del_ObjectRel(objOLBTR_To_Currency_Del)
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
            objOLBTR_To_Currency.Add(New clsObjectRel(objOItem_BankTransaction.GUID, _
                                                           objOItem_BankTransaction.GUID_Parent, _
                                                           objOItem_Currency.GUID, _
                                                           objOItem_Currency.GUID_Parent, _
                                                           objLocalConfig.OItem_RelationType_belonging.GUID, _
                                                           objLocalConfig.Globals.Type_Object, _
                                                           Nothing, _
                                                           1))
            objOItem_Result = objDBLevel_Import.save_ObjRel(objOLBTR_To_Currency)
        End If

        Return objOItem_Result
    End Function

    Public Function del_011_BankTransaction__Currency(Optional ByVal OItem_BankTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBTR__Currency_Del As New List(Of clsObjectRel)

        If Not OItem_BankTransaction Is Nothing Then
            objOItem_BankTransaction = OItem_BankTransaction
        End If

        objOLBTR__Currency_Del.Add(New clsObjectRel(objOItem_BankTransaction.GUID, _
                                                         Nothing, _
                                                         Nothing, _
                                                         objLocalConfig.OItem_Type_Currencies.GUID, _
                                                         objLocalConfig.OItem_RelationType_belonging.GUID, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing))

        objOItem_Result = objDBLevel_Import.del_ObjectRel(objOLBTR__Currency_Del)


        Return objOItem_Result
    End Function

    Public Function save_012_Konto(ByVal OItem_Konto As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Objects As New List(Of clsOntologyItem)

        objOItem_Konto = OItem_Konto

        objOList_Objects.Add(objOItem_Konto)

        objOItem_Result = objDBLevel_Import.save_Objects(objOList_Objects)

        Return objOItem_Result
    End Function

    Public Function del_012_Konto(Optional ByVal OItem_Konto As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Objects As New List(Of clsOntologyItem)

        If Not OItem_Konto Is Nothing Then
            objOItem_Konto = OItem_Konto
        End If

        objOList_Objects.Add(objOItem_Konto)

        objOItem_Result = objDBLevel_Import.del_Objects(objOList_Objects)


        Return objOItem_Result
    End Function

    Public Function save_013_BLZ(ByVal OItem_BLZ As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Objects As New List(Of clsOntologyItem)

        objOItem_BLZ = OItem_BLZ

        objOList_Objects.Add(objOItem_BLZ)

        objOItem_Result = objDBLevel_Import.save_Objects(objOList_Objects)

        Return objOItem_Result
    End Function

    Public Function del_013_BLZ(Optional ByVal OItem_BLZ As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Objects As New List(Of clsOntologyItem)

        If Not OItem_BLZ Is Nothing Then
            objOItem_BLZ = OItem_BLZ
        End If

        objOList_Objects.Add(objOItem_BLZ)

        objOItem_Result = objDBLevel_Import.del_Objects(objOList_Objects)


        Return objOItem_Result
    End Function

    Public Function save_014_Konto_To_BLZ(Optional ByVal OItem_Konto As clsOntologyItem = Nothing, Optional ByVal OItem_BLZ As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Delete As clsOntologyItem
        Dim objOList_Konto_To_BLZ As New List(Of clsObjectRel)
        Dim objOList_Konto_To_BLZ_Search As New List(Of clsObjectRel)
        Dim objOList_Konto_To_BLZ_Delete As New List(Of clsObjectRel)

        If Not OItem_Konto Is Nothing Then
            objOItem_Konto = OItem_Konto
        End If

        If Not OItem_BLZ Is Nothing Then
            objOItem_BLZ = OItem_BLZ
        End If

        objOList_Konto_To_BLZ_Search.Add(New clsObjectRel(objOItem_Konto.GUID, _
                                                          Nothing, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Type_Bankleitzahl.GUID, _
                                                          objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                          objLocalConfig.Globals.Type_Object, _
                                                          Nothing, _
                                                          Nothing))

        objOItem_Result_Search = objDBLevel_Import.get_Data_ObjectRel(objOList_Konto_To_BLZ_Search)

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Import.OList_ObjectRel_ID
                          Where Not obj.ID_Other = objOItem_BLZ.GUID

            Dim objLExist = From obj In objDBLevel_Import.OList_ObjectRel_ID
                            Where obj.ID_Other = objOItem_BLZ.GUID

            objOItem_Result = objLocalConfig.Globals.LState_Nothing

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOList_Konto_To_BLZ_Delete.Add(New clsObjectRel(objDel.ID_Object, _
                                                                      Nothing, _
                                                                      objDel.ID_Other, _
                                                                      Nothing, _
                                                                      objDel.ID_RelationType, _
                                                                      objLocalConfig.Globals.Type_Object, _
                                                                      Nothing, _
                                                                      Nothing))


                Next

                objOItem_Result_Delete = objDBLevel_Import.del_ObjectRel(objOList_Konto_To_BLZ_Delete)
                If objOItem_Result_Delete.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    objOItem_Result = objOItem_Result_Delete
                End If


            End If

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            End If
        Else
            objOItem_Result = objOItem_Result_Search
        End If


        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOList_Konto_To_BLZ.Add(New clsObjectRel(objOItem_Konto.GUID, _
                                                       objOItem_Konto.GUID_Parent, _
                                                       objOItem_BLZ.GUID, _
                                                       objOItem_BLZ.GUID_Parent, _
                                                       objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                       objLocalConfig.Globals.Type_Object, _
                                                       Nothing, _
                                                       1))

            objOItem_Result = objDBLevel_Import.save_ObjRel(objOList_Konto_To_BLZ)
        End If

        Return objOItem_Result
    End Function

    Public Function del_014_Konto_To_BLZ(Optional ByVal OItem_Konto As clsOntologyItem = Nothing, Optional ByVal OItem_BLZ As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Konto_To_BLZ As New List(Of clsObjectRel)

        If OItem_Konto Is Nothing Then
            objOItem_Konto = OItem_Konto
        End If

        If OItem_BLZ Is Nothing Then
            objOItem_BLZ = OItem_BLZ
        End If

        objOList_Konto_To_BLZ.Add(New clsObjectRel(objOItem_Konto.GUID, _
                                                   Nothing, _
                                                   objOItem_BLZ.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                   objLocalConfig.Globals.Type_Object, _
                                                   Nothing, _
                                                   Nothing))

        objOItem_Result = objDBLevel_Import.del_ObjectRel(objOList_Konto_To_BLZ)


        Return objOItem_Result
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Import = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
