Imports Ontolog_Module
Public Class clsTransaction_PersonalData

    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_PersonalData As clsDBLevel


    Private objOItem_PersonalData As clsOntologyItem
    Private objOItem_Partner As clsOntologyItem

    Private objOLPersData_Vorname As New List(Of clsObjectAtt)
    Private objOLPersData_Nachname As New List(Of clsObjectAtt)
    Private objOLPersData_Geburtsdatum As New List(Of clsObjectAtt)
    Private objOLPersData_Todesdatum As New List(Of clsObjectAtt)
    Private objOItem_Familienstand As clsOntologyItem
    Private objOItem_Geschlecht As clsOntologyItem
    Private objOItem_Sozialversicherungsnummer As clsOntologyItem
    Private objOItem_eTin As clsOntologyItem
    Private objOItem_Identifikationsnummer As clsOntologyItem
    Private objOItem_Steuernummer As clsOntologyItem

    Public Function save_001_PersonalData(ByVal OItem_PersonalData As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLIst_PersonalData As New List(Of clsOntologyItem)

        objOItem_PersonalData = OItem_PersonalData

        objOLIst_PersonalData.Add(objOItem_PersonalData)

        objOItem_Result = objDBLevel_PersonalData.save_Objects(objOLIst_PersonalData)

        Return objOItem_Result
    End Function

    Public Function del_001_PersonalData(Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLIst_PersonalData As New List(Of clsOntologyItem)

        objOItem_PersonalData = OItem_PersonalData

        objOLIst_PersonalData.Add(objOItem_PersonalData)

        objOItem_Result = objDBLevel_PersonalData.del_Objects(objOLIst_PersonalData)

        Return objOItem_Result
    End Function

    Public Function save_002_PersonalData_To_Partner(ByVal OItem_Partner As clsOntologyItem, Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem

        Dim objLInsert_PersonalData_To_Partner As New List(Of clsObjectRel)
        Dim objLSearch_PersonalData_To_Partner As New List(Of clsObjectRel)
        Dim objLDel_PersonalData_To_Partner As New List(Of clsObjectRel)

        objOItem_Partner = OItem_Partner

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objLSearch_PersonalData_To_Partner.Add(New clsObjectRel(Nothing, _
                                                                objLocalConfig.OItem_Class_nat_rliche_Person.GUID, _
                                                                objOItem_Partner.GUID, _
                                                                Nothing, _
                                                                objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                                objLocalConfig.Globals.Type_Object, _
                                                                Nothing, _
                                                                Nothing))


        objOItem_Result_Search = objDBLevel_PersonalData.get_Data_ObjectRel(objLSearch_PersonalData_To_Partner)
        objOItem_Result = objLocalConfig.Globals.LState_Nothing
        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_PersonalData.OList_ObjectRel_ID.Count > 0 Then
                Dim objLDel = From objDel In objDBLevel_PersonalData.OList_ObjectRel_ID
                              Where objDel.ID_Object <> objOItem_PersonalData.GUID

                If objLDel.Count > 0 Then
                    For Each objDel In objLDel
                        objLDel_PersonalData_To_Partner.Add(objDel)
                    Next

                    objOItem_Result_Del = objDBLevel_PersonalData.del_ObjectRel(objLDel_PersonalData_To_Partner)
                    If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        objOItem_Result = objLocalConfig.Globals.LState_Error

                    End If
                End If

                Dim objLExist = From objDel In objDBLevel_PersonalData.OList_ObjectRel_ID
                                Where objDel.ID_Object = objOItem_PersonalData.GUID

                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objLInsert_PersonalData_To_Partner.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                    objOItem_PersonalData.GUID_Parent, _
                                                                    objOItem_Partner.GUID, _
                                                                    objOItem_Partner.GUID_Parent, _
                                                                    objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                                    objLocalConfig.Globals.Type_Object, _
                                                                    Nothing, _
                                                                    1))

            objOItem_Result = objDBLevel_PersonalData.save_ObjRel(objLInsert_PersonalData_To_Partner)
        End If

        Return objOItem_Result
    End Function

    Public Function del_002_PersonalData_To_Partner(Optional ByVal OItem_Partner As clsOntologyItem = Nothing, Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        Dim objLDel_PersonalData_To_Partner As New List(Of clsObjectRel)

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        If Not OItem_Partner Is Nothing Then
            objOItem_Partner = OItem_Partner
        End If

        objLDel_PersonalData_To_Partner.Add(New clsObjectRel(Nothing, _
                                                             objLocalConfig.OItem_Class_nat_rliche_Person.GUID, _
                                                             objOItem_Partner.GUID, _
                                                             Nothing, _
                                                             objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                             objLocalConfig.Globals.Type_Object, _
                                                             Nothing, _
                                                             Nothing))
        objOItem_Result = objDBLevel_PersonalData.del_ObjectRel(objLDel_PersonalData_To_Partner)

        Return objOItem_Result
    End Function

    Public Function save_003_PersonalData__Vorname(ByVal strVorname As String, Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objL_PersonalData__Vorname_Search As New List(Of clsObjectAtt)
        Dim objL_PersonalData__Vorname_Del As New List(Of clsObjectAtt)

        objOLPersData_Vorname.Clear()

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objL_PersonalData__Vorname_Search.Add(New clsObjectAtt(Nothing, _
                                                            objOItem_PersonalData.GUID, _
                                                            Nothing, _
                                                            objLocalConfig.OItem_Attribute_Vorname.GUID, _
                                                            Nothing))
        
        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objOItem_Result_Search = objDBLevel_PersonalData.get_Data_ObjectAtt(objL_PersonalData__Vorname_Search, _
                                                                            boolIDs:=False)


        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_PersonalData.OList_ObjectAtt
                          Where obj.Val_String <> strVorname

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success
            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objL_PersonalData__Vorname_Del.Add(New clsObjectAtt(objDel.ID_Attribute, _
                                                                         Nothing, _
                                                                         Nothing, _
                                                                         Nothing, _
                                                                         Nothing))

                Next
                objOItem_Result_Del = objDBLevel_PersonalData.del_ObjectAtt(objL_PersonalData__Vorname_Del)

            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                objOItem_Result = objOItem_Result_Del
            Else
                Dim objLExist = From obj In objDBLevel_PersonalData.OList_ObjectAtt
                                Where obj.Val_String = strVorname

                If objLExist.Count > 0 Then

                    objOLPersData_Vorname.Add(objLExist(0))
                    objOItem_Result = objLocalConfig.Globals.LState_Success

                End If
            End If

        Else
            objOItem_Result = objOItem_Result_Search
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOLPersData_Vorname.Add(New clsObjectAtt(Nothing, _
                                                       objOItem_PersonalData.GUID, _
                                                       Nothing, _
                                                       objOItem_PersonalData.GUID_Parent, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Attribute_Vorname.GUID, _
                                                       Nothing, _
                                                       1, _
                                                       strVorname, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       strVorname, _
                                                       objLocalConfig.Globals.DType_String.GUID))

            objOItem_Result = objDBLevel_PersonalData.save_ObjAtt(objOLPersData_Vorname)

        End If

        Return objOItem_Result
    End Function

    Public Function del_003_PersonalData__Vorname(Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOitem_Result As clsOntologyItem

        Dim objOLPersonalData__Vorname As New List(Of clsObjectAtt)

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objOLPersonalData__Vorname.Add(New clsObjectAtt(Nothing, _
                                                        objOItem_PersonalData.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Attribute_Vorname.GUID, _
                                                        Nothing))

        objOitem_Result = objDBLevel_PersonalData.del_ObjectAtt(objOLPersonalData__Vorname)

        Return objOitem_Result
    End Function

    Public Function save_004_PersonalData__Nachname(ByVal strNachname As String, Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem

        Dim objOLPersonalData__Nachname_Search As New List(Of clsObjectAtt)
        Dim objOLPersonalData__Nachname_Del As New List(Of clsObjectAtt)

        objOLPersData_Nachname.Clear()

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If


        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objOLPersonalData__Nachname_Search.Add(New clsObjectAtt(Nothing, _
                                                            objOItem_PersonalData.GUID, _
                                                            Nothing, _
                                                            objLocalConfig.OItem_Attribute_Nachname.GUID, _
                                                            Nothing))

        objOItem_Result_Search = objDBLevel_PersonalData.get_Data_ObjectAtt(objOLPersonalData__Nachname_Search, _
                                                                            boolIDs:=False)


        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_PersonalData.OList_ObjectAtt
                          Where obj.Val_String <> strNachname

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success
            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOLPersonalData__Nachname_Del.Add(New clsObjectAtt(objDel.ID_Attribute, _
                                                                         Nothing, _
                                                                         Nothing, _
                                                                         Nothing, _
                                                                         Nothing))

                Next
                objOItem_Result_Del = objDBLevel_PersonalData.del_ObjectAtt(objOLPersonalData__Nachname_Del)

            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                objOItem_Result = objOItem_Result_Del
            Else
                
                Dim objLExist = From obj In objDBLevel_PersonalData.OList_ObjectAtt
                                Where obj.Val_String = strNachname

                If objLExist.Count > 0 Then

                    objOLPersData_Nachname.Add(objLExist(0))
                    objOItem_Result = objLocalConfig.Globals.LState_Success

                End If
            End If

        Else
            objOItem_Result = objOItem_Result_Search
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOLPersData_Nachname.Add(New clsObjectAtt(Nothing, _
                                                       objOItem_PersonalData.GUID, _
                                                       Nothing, _
                                                       objOItem_PersonalData.GUID_Parent, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Attribute_Nachname.GUID, _
                                                       Nothing, _
                                                       1, _
                                                       strNachname, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       strNachname, _
                                                       objLocalConfig.Globals.DType_String.GUID))

            objOItem_Result = objDBLevel_PersonalData.save_ObjAtt(objOLPersData_Nachname)

        End If

        Return objOItem_Result
    End Function

    Public Function del_004_PersonalData__Nachname(Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOitem_Result As clsOntologyItem

        Dim objOLPersonalData__Nachname As New List(Of clsObjectAtt)

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objOLPersonalData__Nachname.Add(New clsObjectAtt(Nothing, _
                                                        objOItem_PersonalData.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Attribute_Nachname.GUID, _
                                                        Nothing))

        objOitem_Result = objDBLevel_PersonalData.del_ObjectAtt(objOLPersonalData__Nachname)

        Return objOitem_Result
    End Function

    Public Function save_005_PersonalData_To_Familienstand(ByVal OItem_Familienstand As clsOntologyItem, Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objLPersonalData_To_Familienstand_Search As New List(Of clsObjectRel)
        Dim objLPersonalData_To_Familienstand_Del As New List(Of clsObjectRel)
        Dim objLPersonalData_To_Familienstand As New List(Of clsObjectRel)

        objOItem_Familienstand = OItem_Familienstand

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objLPersonalData_To_Familienstand_Search.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                      Nothing, _
                                                                      Nothing, _
                                                                      objLocalConfig.OItem_Class_Familienstand.GUID, _
                                                                      objLocalConfig.OItem_RelationType_isInState.GUID, _
                                                                      objLocalConfig.Globals.Type_Object, _
                                                                      Nothing, _
                                                                      Nothing))


        objOItem_Result = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Search = objDBLevel_PersonalData.get_Data_ObjectRel(objLPersonalData_To_Familienstand_Search)

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_PersonalData.OList_ObjectRel_ID
                          Where Not obj.ID_Other = objOItem_Familienstand.GUID

            Dim objLExist = From obj In objDBLevel_PersonalData.OList_ObjectRel_ID
                            Where obj.ID_Other = objOItem_Familienstand.GUID

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objLPersonalData_To_Familienstand_Del.Add(New clsObjectRel(objDel.ID_Object, _
                                                                               Nothing, _
                                                                               objDel.ID_Other, _
                                                                               Nothing, _
                                                                               objLocalConfig.OItem_RelationType_isInState.GUID, _
                                                                               objLocalConfig.Globals.Type_Object, _
                                                                               Nothing, _
                                                                               Nothing))
                Next

                objOItem_Result_Del = objDBLevel_PersonalData.del_ObjectRel(objLPersonalData_To_Familienstand_Del)


            End If

            If Not objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
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
            objLPersonalData_To_Familienstand.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                   objOItem_PersonalData.GUID_Parent, _
                                                                   objOItem_Familienstand.GUID, _
                                                                   objOItem_Familienstand.GUID_Parent, _
                                                                   objLocalConfig.OItem_RelationType_isInState.GUID, _
                                                                   objLocalConfig.Globals.Type_Object, _
                                                                   Nothing, _
                                                                   1))

            objOItem_Result = objDBLevel_PersonalData.save_ObjRel(objLPersonalData_To_Familienstand)
        End If

        Return objOItem_Result
    End Function

    Public Function del_005_PersonalData_To_Familienstand(Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objL_PersonalData_To_Familienstand As New List(Of clsObjectRel)


        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objL_PersonalData_To_Familienstand.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                Nothing, _
                                                                Nothing, _
                                                                objLocalConfig.OItem_Class_Familienstand.GUID, _
                                                                objLocalConfig.OItem_RelationType_isInState.GUID, _
                                                                objLocalConfig.Globals.Type_Object, _
                                                                Nothing, _
                                                                Nothing))

        objOItem_Result = objDBLevel_PersonalData.del_ObjectRel(objL_PersonalData_To_Familienstand)

        Return objOItem_Result
    End Function

    Public Function save_006_PersonalData_To_Geschlecht(ByVal OItem_Geschlecht As clsOntologyItem, Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objLPersonalData_To_Geschlecht_Search As New List(Of clsObjectRel)
        Dim objLPersonalData_To_Geschlecht_Del As New List(Of clsObjectRel)
        Dim objLPersonalData_To_Geschlecht As New List(Of clsObjectRel)

        objOItem_Geschlecht = OItem_Geschlecht

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objLPersonalData_To_Geschlecht_Search.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                      Nothing, _
                                                                      Nothing, _
                                                                      objLocalConfig.OItem_Class_Geschlecht.GUID, _
                                                                      objLocalConfig.OItem_RelationType_belonging.GUID, _
                                                                      objLocalConfig.Globals.Type_Object, _
                                                                      Nothing, _
                                                                      Nothing))


        objOItem_Result = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Search = objDBLevel_PersonalData.get_Data_ObjectRel(objLPersonalData_To_Geschlecht_Search)

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_PersonalData.OList_ObjectRel_ID
                          Where Not obj.ID_Other = objOItem_Geschlecht.GUID

            Dim objLExist = From obj In objDBLevel_PersonalData.OList_ObjectRel_ID
                            Where obj.ID_Other = objOItem_Geschlecht.GUID

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objLPersonalData_To_Geschlecht_Del.Add(New clsObjectRel(objDel.ID_Object, _
                                                                               Nothing, _
                                                                               objDel.ID_Other, _
                                                                               Nothing, _
                                                                               objLocalConfig.OItem_RelationType_belonging.GUID, _
                                                                               objLocalConfig.Globals.Type_Object, _
                                                                               Nothing, _
                                                                               Nothing))
                Next

                objOItem_Result_Del = objDBLevel_PersonalData.del_ObjectRel(objLPersonalData_To_Geschlecht_Del)


            End If

            If Not objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
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
            objLPersonalData_To_Geschlecht.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                   objOItem_PersonalData.GUID_Parent, _
                                                                   objOItem_Geschlecht.GUID, _
                                                                   objOItem_Geschlecht.GUID_Parent, _
                                                                   objLocalConfig.OItem_RelationType_belonging.GUID, _
                                                                   objLocalConfig.Globals.Type_Object, _
                                                                   Nothing, _
                                                                   1))

            objOItem_Result = objDBLevel_PersonalData.save_ObjRel(objLPersonalData_To_Geschlecht)
        End If

        Return objOItem_Result
    End Function

    Public Function del_006_PersonalData_To_Geschlecht(Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objL_PersonalData_To_Geschlecht As New List(Of clsObjectRel)


        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objL_PersonalData_To_Geschlecht.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                Nothing, _
                                                                Nothing, _
                                                                objLocalConfig.OItem_Class_Geschlecht.GUID, _
                                                                objLocalConfig.OItem_RelationType_belonging.GUID, _
                                                                objLocalConfig.Globals.Type_Object, _
                                                                Nothing, _
                                                                Nothing))

        objOItem_Result = objDBLevel_PersonalData.del_ObjectRel(objL_PersonalData_To_Geschlecht)

        Return objOItem_Result


        Return objOItem_Result
    End Function

    Public Function save_007_PersonalData__Geburtsdatum(ByVal dateGeburtsdatum As Date, Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objL_PersonalData__Geburtsdatum_Search As New List(Of clsObjectAtt)
        Dim objL_PersonalData__Geburtsdatum_Del As New List(Of clsObjectAtt)

        objOLPersData_Geburtsdatum.Clear()

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objL_PersonalData__Geburtsdatum_Search.Add(New clsObjectAtt(Nothing, _
                                                            objOItem_PersonalData.GUID, _
                                                            Nothing, _
                                                            objLocalConfig.OItem_Attribute_Geburtsdatum.GUID, _
                                                            Nothing))

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objOItem_Result_Search = objDBLevel_PersonalData.get_Data_ObjectAtt(objL_PersonalData__Geburtsdatum_Search, _
                                                                            boolIDs:=False)


        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_PersonalData.OList_ObjectAtt
                          Where obj.Val_Date <> dateGeburtsdatum

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success
            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objL_PersonalData__Geburtsdatum_Del.Add(New clsObjectAtt(objDel.ID_Attribute, _
                                                                         Nothing, _
                                                                         Nothing, _
                                                                         Nothing, _
                                                                         Nothing))

                Next
                objOItem_Result_Del = objDBLevel_PersonalData.del_ObjectAtt(objL_PersonalData__Geburtsdatum_Del)

            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                objOItem_Result = objOItem_Result_Del
            Else
                Dim objLExist = From obj In objDBLevel_PersonalData.OList_ObjectAtt
                                Where obj.Val_Date = dateGeburtsdatum

                If objLExist.Count > 0 Then

                    objOLPersData_Geburtsdatum.Add(objLExist(0))
                    objOItem_Result = objLocalConfig.Globals.LState_Success

                End If
            End If

        Else
            objOItem_Result = objOItem_Result_Search
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOLPersData_Geburtsdatum.Add(New clsObjectAtt(Nothing, _
                                                       objOItem_PersonalData.GUID, _
                                                       Nothing, _
                                                       objOItem_PersonalData.GUID_Parent, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Attribute_Geburtsdatum.GUID, _
                                                       Nothing, _
                                                       1, _
                                                       dateGeburtsdatum.ToString, _
                                                       Nothing, _
                                                       dateGeburtsdatum, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       objLocalConfig.Globals.DType_DateTime.GUID))

            objOItem_Result = objDBLevel_PersonalData.save_ObjAtt(objOLPersData_Geburtsdatum)

        End If

        Return objOItem_Result
    End Function

    Public Function del_007_PersonalData__Geburtsdatum(Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOitem_Result As clsOntologyItem

        Dim objOLPersonalData__Geburtsdatum As New List(Of clsObjectAtt)

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objOLPersonalData__Geburtsdatum.Add(New clsObjectAtt(Nothing, _
                                                        objOItem_PersonalData.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Attribute_Geburtsdatum.GUID, _
                                                        Nothing))

        objOitem_Result = objDBLevel_PersonalData.del_ObjectAtt(objOLPersonalData__Geburtsdatum)

        Return objOitem_Result
    End Function

    Public Function save_008_PersonalData__Todesdatum(ByVal dateTodesdatum As Date, Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objL_PersonalData__Todesdatum_Search As New List(Of clsObjectAtt)
        Dim objL_PersonalData__Todesdatum_Del As New List(Of clsObjectAtt)

        objOLPersData_Todesdatum.Clear()

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objL_PersonalData__Todesdatum_Search.Add(New clsObjectAtt(Nothing, _
                                                            objOItem_PersonalData.GUID, _
                                                            Nothing, _
                                                            objLocalConfig.OItem_Attribute_Todesdatum.GUID, _
                                                            Nothing))

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objOItem_Result_Search = objDBLevel_PersonalData.get_Data_ObjectAtt(objL_PersonalData__Todesdatum_Search, _
                                                                            boolIDs:=False)


        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_PersonalData.OList_ObjectAtt
                          Where obj.Val_Date <> dateTodesdatum

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success
            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objL_PersonalData__Todesdatum_Del.Add(New clsObjectAtt(objDel.ID_Attribute, _
                                                                         Nothing, _
                                                                         Nothing, _
                                                                         Nothing, _
                                                                         Nothing))

                Next
                objOItem_Result_Del = objDBLevel_PersonalData.del_ObjectAtt(objL_PersonalData__Todesdatum_Del)

            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                objOItem_Result = objOItem_Result_Del
            Else
                Dim objLExist = From obj In objDBLevel_PersonalData.OList_ObjectAtt
                                Where obj.Val_Date = dateTodesdatum

                If objLExist.Count > 0 Then

                    objOLPersData_Todesdatum.Add(objLExist(0))
                    objOItem_Result = objLocalConfig.Globals.LState_Success

                End If
            End If

        Else
            objOItem_Result = objOItem_Result_Search
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOLPersData_Todesdatum.Add(New clsObjectAtt(Nothing, _
                                                       objOItem_PersonalData.GUID, _
                                                       Nothing, _
                                                       objOItem_PersonalData.GUID_Parent, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Attribute_Todesdatum.GUID, _
                                                       Nothing, _
                                                       1, _
                                                       dateTodesdatum.ToString, _
                                                       Nothing, _
                                                       dateTodesdatum, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       objLocalConfig.Globals.DType_DateTime.GUID))

            objOItem_Result = objDBLevel_PersonalData.save_ObjAtt(objOLPersData_Todesdatum)

        End If

        Return objOItem_Result
    End Function

    Public Function del_008_PersonalData__Todesdatum(Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOitem_Result As clsOntologyItem

        Dim objOLPersonalData__Todesdatum As New List(Of clsObjectAtt)

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objOLPersonalData__Todesdatum.Add(New clsObjectAtt(Nothing, _
                                                        objOItem_PersonalData.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Attribute_Todesdatum.GUID, _
                                                        Nothing))

        objOitem_Result = objDBLevel_PersonalData.del_ObjectAtt(objOLPersonalData__Todesdatum)

        Return objOitem_Result
    End Function

    Public Function save_009_PersonalData_To_Sozialversicherungsnummer(ByVal OItem_Sozialversicherungsnummer As clsOntologyItem, Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objLPersonalData_To_Sozialversicherungsnummer_Search As New List(Of clsObjectRel)
        Dim objLPersonalData_To_Sozialversicherungsnummer_Del As New List(Of clsObjectRel)
        Dim objLPersonalData_To_Sozialversicherungsnummer As New List(Of clsObjectRel)

        objOItem_Sozialversicherungsnummer = OItem_Sozialversicherungsnummer

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objLPersonalData_To_Sozialversicherungsnummer_Search.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                      Nothing, _
                                                                      Nothing, _
                                                                      objLocalConfig.OItem_Class_Sozialversicherungsnummer.GUID, _
                                                                      objLocalConfig.OItem_RelationType_has.GUID, _
                                                                      objLocalConfig.Globals.Type_Object, _
                                                                      Nothing, _
                                                                      Nothing))


        objOItem_Result = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Search = objDBLevel_PersonalData.get_Data_ObjectRel(objLPersonalData_To_Sozialversicherungsnummer_Search)

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_PersonalData.OList_ObjectRel_ID
                          Where Not obj.ID_Other = objOItem_Sozialversicherungsnummer.GUID

            Dim objLExist = From obj In objDBLevel_PersonalData.OList_ObjectRel_ID
                            Where obj.ID_Other = objOItem_Sozialversicherungsnummer.GUID

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objLPersonalData_To_Sozialversicherungsnummer_Del.Add(New clsObjectRel(objDel.ID_Object, _
                                                                               Nothing, _
                                                                               objDel.ID_Other, _
                                                                               Nothing, _
                                                                               objLocalConfig.OItem_RelationType_has.GUID, _
                                                                               objLocalConfig.Globals.Type_Object, _
                                                                               Nothing, _
                                                                               Nothing))
                Next

                objOItem_Result_Del = objDBLevel_PersonalData.del_ObjectRel(objLPersonalData_To_Sozialversicherungsnummer_Del)


            End If

            If Not objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
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
            objLPersonalData_To_Sozialversicherungsnummer.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                   objOItem_PersonalData.GUID_Parent, _
                                                                   objOItem_Sozialversicherungsnummer.GUID, _
                                                                   objOItem_Sozialversicherungsnummer.GUID_Parent, _
                                                                   objLocalConfig.OItem_RelationType_has.GUID, _
                                                                   objLocalConfig.Globals.Type_Object, _
                                                                   Nothing, _
                                                                   1))

            objOItem_Result = objDBLevel_PersonalData.save_ObjRel(objLPersonalData_To_Sozialversicherungsnummer)
        End If

        Return objOItem_Result
    End Function

    Public Function del_009_PersonalData_To_Sozialversicherungsnummer(Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objL_PersonalData_To_Sozialversicherungsnummer As New List(Of clsObjectRel)


        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objL_PersonalData_To_Sozialversicherungsnummer.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                Nothing, _
                                                                Nothing, _
                                                                objLocalConfig.OItem_Class_Sozialversicherungsnummer.GUID, _
                                                                objLocalConfig.OItem_RelationType_has.GUID, _
                                                                objLocalConfig.Globals.Type_Object, _
                                                                Nothing, _
                                                                Nothing))

        objOItem_Result = objDBLevel_PersonalData.del_ObjectRel(objL_PersonalData_To_Sozialversicherungsnummer)

        Return objOItem_Result
    End Function

    Public Function save_010_PersonalData_To_eTin(ByVal OItem_eTin As clsOntologyItem, Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objLPersonalData_To_eTin_Search As New List(Of clsObjectRel)
        Dim objLPersonalData_To_eTin_Del As New List(Of clsObjectRel)
        Dim objLPersonalData_To_eTin As New List(Of clsObjectRel)

        objOItem_eTin = OItem_eTin

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objLPersonalData_To_eTin_Search.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                      Nothing, _
                                                                      Nothing, _
                                                                      objLocalConfig.OItem_Class_eTin.GUID, _
                                                                      objLocalConfig.OItem_RelationType_has.GUID, _
                                                                      objLocalConfig.Globals.Type_Object, _
                                                                      Nothing, _
                                                                      Nothing))


        objOItem_Result = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Search = objDBLevel_PersonalData.get_Data_ObjectRel(objLPersonalData_To_eTin_Search)

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_PersonalData.OList_ObjectRel_ID
                          Where Not obj.ID_Other = objOItem_eTin.GUID

            Dim objLExist = From obj In objDBLevel_PersonalData.OList_ObjectRel_ID
                            Where obj.ID_Other = objOItem_eTin.GUID

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objLPersonalData_To_eTin_Del.Add(New clsObjectRel(objDel.ID_Object, _
                                                                               Nothing, _
                                                                               objDel.ID_Other, _
                                                                               Nothing, _
                                                                               objLocalConfig.OItem_RelationType_has.GUID, _
                                                                               objLocalConfig.Globals.Type_Object, _
                                                                               Nothing, _
                                                                               Nothing))
                Next

                objOItem_Result_Del = objDBLevel_PersonalData.del_ObjectRel(objLPersonalData_To_eTin_Del)


            End If

            If Not objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
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
            objLPersonalData_To_eTin.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                   objOItem_PersonalData.GUID_Parent, _
                                                                   objOItem_eTin.GUID, _
                                                                   objOItem_eTin.GUID_Parent, _
                                                                   objLocalConfig.OItem_RelationType_has.GUID, _
                                                                   objLocalConfig.Globals.Type_Object, _
                                                                   Nothing, _
                                                                   1))

            objOItem_Result = objDBLevel_PersonalData.save_ObjRel(objLPersonalData_To_eTin)
        End If

        Return objOItem_Result
    End Function

    Public Function del_010_PersonalData_To_eTin(Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objL_PersonalData_To_eTin As New List(Of clsObjectRel)


        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objL_PersonalData_To_eTin.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                Nothing, _
                                                                Nothing, _
                                                                objLocalConfig.OItem_Class_eTin.GUID, _
                                                                objLocalConfig.OItem_RelationType_has.GUID, _
                                                                objLocalConfig.Globals.Type_Object, _
                                                                Nothing, _
                                                                Nothing))

        objOItem_Result = objDBLevel_PersonalData.del_ObjectRel(objL_PersonalData_To_eTin)

        Return objOItem_Result
    End Function

    Public Function save_011_PersonalData_To_Identifikationsnummer(ByVal OItem_Identifikationsnummer As clsOntologyItem, Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objLPersonalData_To_Identifikationsnummer_Search As New List(Of clsObjectRel)
        Dim objLPersonalData_To_Identifikationsnummer_Del As New List(Of clsObjectRel)
        Dim objLPersonalData_To_Identifikationsnummer As New List(Of clsObjectRel)

        objOItem_Identifikationsnummer = OItem_Identifikationsnummer

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objLPersonalData_To_Identifikationsnummer_Search.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                      Nothing, _
                                                                      Nothing, _
                                                                      objLocalConfig.OItem_Class_Identifkationsnummer__IdNr_.GUID, _
                                                                      objLocalConfig.OItem_RelationType_has.GUID, _
                                                                      objLocalConfig.Globals.Type_Object, _
                                                                      Nothing, _
                                                                      Nothing))


        objOItem_Result = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Search = objDBLevel_PersonalData.get_Data_ObjectRel(objLPersonalData_To_Identifikationsnummer_Search)

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_PersonalData.OList_ObjectRel_ID
                          Where Not obj.ID_Other = objOItem_Identifikationsnummer.GUID

            Dim objLExist = From obj In objDBLevel_PersonalData.OList_ObjectRel_ID
                            Where obj.ID_Other = objOItem_Identifikationsnummer.GUID

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objLPersonalData_To_Identifikationsnummer_Del.Add(New clsObjectRel(objDel.ID_Object, _
                                                                               Nothing, _
                                                                               objDel.ID_Other, _
                                                                               Nothing, _
                                                                               objLocalConfig.OItem_RelationType_has.GUID, _
                                                                               objLocalConfig.Globals.Type_Object, _
                                                                               Nothing, _
                                                                               Nothing))
                Next

                objOItem_Result_Del = objDBLevel_PersonalData.del_ObjectRel(objLPersonalData_To_Identifikationsnummer_Del)


            End If

            If Not objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
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
            objLPersonalData_To_Identifikationsnummer.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                   objOItem_PersonalData.GUID_Parent, _
                                                                   objOItem_Identifikationsnummer.GUID, _
                                                                   objOItem_Identifikationsnummer.GUID_Parent, _
                                                                   objLocalConfig.OItem_RelationType_has.GUID, _
                                                                   objLocalConfig.Globals.Type_Object, _
                                                                   Nothing, _
                                                                   1))

            objOItem_Result = objDBLevel_PersonalData.save_ObjRel(objLPersonalData_To_Identifikationsnummer)
        End If

        Return objOItem_Result
    End Function

    Public Function del_011_PersonalData_To_Identifikationsnummer(Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objL_PersonalData_To_Identifikationsnummer As New List(Of clsObjectRel)


        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objL_PersonalData_To_Identifikationsnummer.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                Nothing, _
                                                                Nothing, _
                                                                objLocalConfig.OItem_Class_Identifkationsnummer__IdNr_.GUID, _
                                                                objLocalConfig.OItem_RelationType_has.GUID, _
                                                                objLocalConfig.Globals.Type_Object, _
                                                                Nothing, _
                                                                Nothing))

        objOItem_Result = objDBLevel_PersonalData.del_ObjectRel(objL_PersonalData_To_Identifikationsnummer)

        Return objOItem_Result
    End Function

    Public Function save_012_PersonalData_To_Steuernummer(ByVal OItem_Steuernummer As clsOntologyItem, Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objLPersonalData_To_Steuernummer_Search As New List(Of clsObjectRel)
        Dim objLPersonalData_To_Steuernummer_Del As New List(Of clsObjectRel)
        Dim objLPersonalData_To_Steuernummer As New List(Of clsObjectRel)

        objOItem_Steuernummer = OItem_Steuernummer

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objLPersonalData_To_Steuernummer_Search.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                      Nothing, _
                                                                      Nothing, _
                                                                      objLocalConfig.OItem_Class_Steuernummer.GUID, _
                                                                      objLocalConfig.OItem_RelationType_has.GUID, _
                                                                      objLocalConfig.Globals.Type_Object, _
                                                                      Nothing, _
                                                                      Nothing))


        objOItem_Result = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Search = objDBLevel_PersonalData.get_Data_ObjectRel(objLPersonalData_To_Steuernummer_Search)

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_PersonalData.OList_ObjectRel_ID
                          Where Not obj.ID_Other = objOItem_Steuernummer.GUID

            Dim objLExist = From obj In objDBLevel_PersonalData.OList_ObjectRel_ID
                            Where obj.ID_Other = objOItem_Steuernummer.GUID

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objLPersonalData_To_Steuernummer_Del.Add(New clsObjectRel(objDel.ID_Object, _
                                                                               Nothing, _
                                                                               objDel.ID_Other, _
                                                                               Nothing, _
                                                                               objLocalConfig.OItem_RelationType_has.GUID, _
                                                                               objLocalConfig.Globals.Type_Object, _
                                                                               Nothing, _
                                                                               Nothing))
                Next

                objOItem_Result_Del = objDBLevel_PersonalData.del_ObjectRel(objLPersonalData_To_Steuernummer_Del)


            End If

            If Not objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
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
            objLPersonalData_To_Steuernummer.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                   objOItem_PersonalData.GUID_Parent, _
                                                                   objOItem_Steuernummer.GUID, _
                                                                   objOItem_Steuernummer.GUID_Parent, _
                                                                   objLocalConfig.OItem_RelationType_has.GUID, _
                                                                   objLocalConfig.Globals.Type_Object, _
                                                                   Nothing, _
                                                                   1))

            objOItem_Result = objDBLevel_PersonalData.save_ObjRel(objLPersonalData_To_Steuernummer)
        End If

        Return objOItem_Result
    End Function

    Public Function del_012_PersonalData_To_Steuernummer(Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objL_PersonalData_To_Steuernummer As New List(Of clsObjectRel)


        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        objL_PersonalData_To_Steuernummer.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                Nothing, _
                                                                Nothing, _
                                                                objLocalConfig.OItem_Class_Steuernummer.GUID, _
                                                                objLocalConfig.OItem_RelationType_has.GUID, _
                                                                objLocalConfig.Globals.Type_Object, _
                                                                Nothing, _
                                                                Nothing))

        objOItem_Result = objDBLevel_PersonalData.del_ObjectRel(objL_PersonalData_To_Steuernummer)

        Return objOItem_Result
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_PersonalData = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
