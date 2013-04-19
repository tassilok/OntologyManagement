Imports Ontolog_Module
Public Class clsTransaction_PersonalData

    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_PersonalData As clsDBLevel


    Private objOItem_PersonalData As clsOntologyItem
    Private objOItem_Partner As clsOntologyItem

    Private objOLPersData_Vorname As New List(Of clsObjectAtt)
    Private objOLPersData_Nachname As New List(Of clsObjectAtt)

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

        objOLPersData_Vorname.Clear()

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If

        
        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objOItem_Result_Search = objDBLevel_PersonalData.get_Data_ObjectAtt(objOLPersData_Vorname, _
                                                                            boolIDs:=False)


        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_PersonalData.OList_ObjectAtt
                          Where obj.Val_String <> strVorname

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success
            If objLDel.Count > 0 Then
                objOItem_Result_Del = objDBLevel_PersonalData.del_ObjectAtt(objLDel)

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

        objOLPersData_Nachname.Clear()

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If


        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objOItem_Result_Search = objDBLevel_PersonalData.get_Data_ObjectAtt(objOLPersData_Nachname, _
                                                                            boolIDs:=False)


        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_PersonalData.OList_ObjectAtt
                          Where obj.Val_String <> strNachname

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success
            If objLDel.Count > 0 Then
                objOItem_Result_Del = objDBLevel_PersonalData.del_ObjectAtt(objLDel)

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

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_PersonalData = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
