Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsTransaction_ImportSettings
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Import As clsDBLevel

    Private objOItem_ImportLog As clsOntologyItem
    Private objOAItem_Start As clsObjectAtt
    Private objOItem_ImportSetting As clsOntologyItem

    Public Function save_001_ImportLog(ByVal OItem_ImporLog As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_ImportLog As New List(Of clsOntologyItem)

        objOItem_ImportLog = OItem_ImporLog

        objOL_ImportLog.Add(objOItem_ImportLog)

        objOItem_Result = objDBLevel_Import.save_Objects(objOL_ImportLog)

        Return objOItem_Result
    End Function

    Public Function del_001_ImportLog(Optional ByVal OItem_ImportLog As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_ImportLog As New List(Of clsOntologyItem)

        If Not OItem_ImportLog Is Nothing Then
            objOItem_ImportLog = OItem_ImportLog
        End If

        objOL_ImportLog.Add(objOItem_ImportLog)

        objOItem_Result = objDBLevel_Import.del_Objects(objOL_ImportLog)

        Return objOItem_Result
    End Function

    Public Function save_002_ImportLog__Start(ByVal dateStart As Date, Optional ByVal OItem_ImportLog As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem

        Dim objOL_Start As New List(Of clsObjectAtt)
        Dim objOL_Start_Search As New List(Of clsObjectAtt)
        Dim objOL_Start_Del As New List(Of clsObjectAtt)

        If Not OItem_ImportLog Is Nothing Then
            objOItem_ImportLog = OItem_ImportLog
        End If

        objOAItem_Start = New clsObjectAtt(Nothing, _
                                           objOItem_ImportLog.GUID, _
                                           Nothing, _
                                           objOItem_ImportLog.GUID_Parent, _
                                           Nothing, _
                                           objLocalConfig.OItem_Attribute_Start.GUID, _
                                           Nothing, _
                                           1, _
                                           dateStart.ToString, _
                                           Nothing, _
                                           dateStart, _
                                           Nothing, _
                                           Nothing, _
                                           Nothing, _
                                           objLocalConfig.Globals.DType_DateTime.GUID)

        objOL_Start_Search.Add(New clsObjectAtt(Nothing, _
                                              objOItem_ImportLog.GUID, _
                                              Nothing, _
                                              objLocalConfig.OItem_Attribute_Start.GUID, _
                                              Nothing))

        objOItem_Result_Search = objDBLevel_Import.get_Data_ObjectAtt(objOL_Start_Search, _
                                                               boolIDs:=False)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Import.OList_ObjectAtt
                          Where Not obj.Val_Date = dateStart

            Dim objLExit = From obj In objDBLevel_Import.OList_ObjectAtt
                           Where obj.Val_Date = dateStart


            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOL_Start_Del.Add(New clsObjectAtt(objDel.ID_Attribute, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing))


                Next

                objOItem_Result_Del = objDBLevel_Import.del_ObjectAtt(objOL_Start_Del)
            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExit.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Error
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOL_Start.Add(objOAItem_Start)
            objOItem_Result = objDBLevel_Import.save_ObjAtt(objOL_Start)
        End If

        Return objOItem_Result
    End Function

    Public Function del_002_ImportLog__Start(Optional ByVal OItem_ImportLog As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_Start As New List(Of clsObjectAtt)

        If Not OItem_ImportLog Is Nothing Then
            objOItem_ImportLog = OItem_ImportLog
        End If

        objOL_Start.Add(New clsObjectAtt(Nothing, _
                                         objOItem_ImportLog.GUID, _
                                         Nothing, _
                                         objLocalConfig.OItem_Attribute_Start.GUID, _
                                         Nothing))

        objOItem_Result = objDBLevel_Import.del_ObjectAtt(objOL_Start)

        Return objOItem_Result
    End Function

    Public Function save_003_ImportLog_To_ImportSetting(ByVal OItem_ImportSetting As clsOntologyItem, Optional ByVal OItem_ImportLog As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem

        Dim objOL_ImportLog_To_ImportSetting As New List(Of clsObjectRel)
        Dim objOL_ImportLog_To_ImportSetting_Search As New List(Of clsObjectRel)
        Dim objOL_ImportLog_To_ImportSetting_Del As New List(Of clsObjectRel)

        objOItem_ImportSetting = OItem_ImportSetting

        If Not OItem_ImportLog Is Nothing Then
            objOItem_ImportLog = OItem_ImportLog
        End If

        objOL_ImportLog_To_ImportSetting_Search.Add(New clsObjectRel(objOItem_ImportLog.GUID, _
                                                                     Nothing, _
                                                                     Nothing, _
                                                                     objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                                     objLocalConfig.OItem_RelationType_Log_of.GUID, _
                                                                     objLocalConfig.Globals.Type_Object, _
                                                                     Nothing, _
                                                                     Nothing))

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objOItem_Result_Search = objDBLevel_Import.get_Data_ObjectRel(objOL_ImportLog_To_ImportSetting_Search)
        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Import.OList_ObjectRel_ID
                          Where Not obj.ID_Other = objOItem_ImportSetting.GUID

            Dim objLExist = From obj In objDBLevel_Import.OList_ObjectRel_ID
                            Where obj.ID_Other = objOItem_ImportSetting.GUID

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOL_ImportLog_To_ImportSetting_Del.Add(New clsObjectRel(objDel.ID_Object, _
                                                                              Nothing, _
                                                                              objDel.ID_Other, _
                                                                              Nothing, _
                                                                              objDel.ID_RelationType, _
                                                                              objLocalConfig.Globals.Type_Object, _
                                                                              Nothing, _
                                                                              Nothing))



                Next

                objOItem_Result_Del = objDBLevel_Import.del_ObjectRel(objOL_ImportLog_To_ImportSetting_Del)

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
            objOL_ImportLog_To_ImportSetting.Add(New clsObjectRel(objOItem_ImportLog.GUID, _
                                                                  objOItem_ImportLog.GUID_Parent, _
                                                                  objOItem_ImportSetting.GUID, _
                                                                  objOItem_ImportSetting.GUID_Parent, _
                                                                  objLocalConfig.OItem_RelationType_Log_of.GUID, _
                                                                  objLocalConfig.Globals.Type_Object, _
                                                                  Nothing, _
                                                                  1))

            objOItem_Result = objDBLevel_Import.save_ObjRel(objOL_ImportLog_To_ImportSetting)
        End If

        Return objOItem_Result
    End Function

    Public Function del_003__ImportLog_To_ImportSetting(Optional ByVal OItem_ImportLog As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_ImportLog_To_ImportSetting As New List(Of clsObjectRel)

        If Not OItem_ImportLog Is Nothing Then
            objOItem_ImportLog = OItem_ImportLog
        End If


        objOL_ImportLog_To_ImportSetting.Add(New clsObjectRel(objOItem_ImportLog.GUID, _
                                                              Nothing, _
                                                              Nothing, _
                                                              objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                              objLocalConfig.OItem_RelationType_Log_of.GUID, _
                                                              objLocalConfig.Globals.Type_Object, _
                                                              Nothing, _
                                                              Nothing))

        objOItem_Result = objDBLevel_Import.del_ObjectRel(objOL_ImportLog_To_ImportSetting)

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
