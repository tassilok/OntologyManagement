Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsTransaction_Process
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Process As clsDBLevel

    Private objOItem_Process As clsOntologyItem
    Private objOItem_Process_Parent As clsOntologyItem

    Private objOA_Process__Public As clsObjectAtt

    Public Function save_001_Process(OItem_Process As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        Dim objOL_Process As New List(Of clsOntologyItem)

        objOItem_Process = OItem_Process

        objOL_Process.Add(objOItem_Process)

        objOItem_Result = objDBLevel_Process.save_Objects(objOL_Process)


        Return objOItem_Result
    End Function

    Public Function del_001_Process(Optional OItem_Process As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_Process As New List(Of clsOntologyItem)

        If Not OItem_Process Is Nothing Then
            objOItem_Process = OItem_Process
        End If

        objOL_Process.Add(objOItem_Process)

        objOItem_Result = objDBLevel_Process.del_Objects(objOL_Process)

        Return objOItem_Result
    End Function

    Public Function save_002_Process__Public(isPublic As Boolean, Optional OItem_Process As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem

        Dim objOL_Process__Public As New List(Of clsObjectAtt)
        Dim objOL_Process__Public_Search As New List(Of clsObjectAtt)
        Dim objOL_Process__Public_Del As New List(Of clsObjectAtt)

        If Not OItem_Process Is Nothing Then
            objOItem_Process = OItem_Process
        End If


        objOL_Process__Public_Search.Add(New clsObjectAtt(Nothing, _
                                                          objOItem_Process.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Attribute_Public.GUID, _
                                                          Nothing))

        objOItem_Result_Search = objDBLevel_Process.get_Data_ObjectAtt(objOL_Process__Public_Search, _
                                                                       boolIDs:=False)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Process.OList_ObjectAtt
                          Where Not obj.Val_Bit = isPublic

            Dim objLExist = From obj In objDBLevel_Process.OList_ObjectAtt
                            Where obj.Val_Bit = isPublic

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOL_Process__Public_Del.Add(New clsObjectAtt(objDel.ID_Attribute, _
                                                                   Nothing, _
                                                                   Nothing, _
                                                                   Nothing, _
                                                                   Nothing))

                Next

                objOItem_Result_Del = objDBLevel_Process.del_ObjectAtt(objOL_Process__Public_Del)


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
            objOA_Process__Public = New clsObjectAtt(objLocalConfig.Globals.NewGUID, _
                                                     objOItem_Process.GUID, _
                                                     Nothing, _
                                                     objOItem_Process.GUID_Parent, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_Attribute_Public.GUID, _
                                                     Nothing, _
                                                     1, _
                                                     isPublic, _
                                                     isPublic, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.DType_Bool.GUID)

            objOL_Process__Public.Add(objOA_Process__Public)

            objOItem_Result = objDBLevel_Process.save_ObjAtt(objOL_Process__Public)
        End If

        Return objOItem_Result
    End Function

    Public Function del_002_Process__Public(Optional OItem_Process As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_Process__Public As New List(Of clsObjectAtt)

        If Not OItem_Process Is Nothing Then
            objOItem_Process = OItem_Process
        End If

        objOL_Process__Public.Add(New clsObjectAtt(Nothing, _
                                                   objOItem_Process.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_Attribute_Public.GUID, _
                                                   Nothing))

        objOItem_Result = objDBLevel_Process.del_ObjectAtt(objOL_Process__Public)

        Return objOItem_Result
    End Function

    Public Function save_003_ParentProcess_To_Process(OItem_Process_Parent As clsOntologyItem, lngOrderID As Long, Optional OItem_Process As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        Dim objOL_Process_To_Parent As New List(Of clsObjectRel)


        objOItem_Process_Parent = OItem_Process_Parent

        If Not OItem_Process Is Nothing Then
            objOItem_Process = OItem_Process
        End If

        objOL_Process_To_Parent.Add(New clsObjectRel(objOItem_Process_Parent.GUID, _
                                                     objOItem_Process_Parent.GUID_Parent, _
                                                     objOItem_Process.GUID, _
                                                     objOItem_Process.GUID_Parent, _
                                                     objLocalConfig.OItem_RelationType_superordinate.GUID, _
                                                     objLocalConfig.Globals.Type_Object, _
                                                     Nothing, _
                                                     lngOrderID))
        objOItem_Result = objDBLevel_Process.save_ObjRel(objOL_Process_To_Parent)

        Return objOItem_Result
    End Function

    Public Function del_003_ParentProcess_To_Process(Optional OItem_Process_Parent As clsOntologyItem = Nothing, Optional OItem_Process As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Process_To_Parent As New List(Of clsObjectRel)


        If Not OItem_Process Is Nothing Then
            objOItem_Process = OItem_Process
        End If

        If Not OItem_Process_Parent Is Nothing Then
            objOItem_Process_Parent = OItem_Process_Parent
        End If


        objOList_Process_To_Parent.Add(New clsObjectRel(objOItem_Process_Parent.GUID, _
                                                        Nothing, _
                                                        objOItem_Process.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_RelationType_superordinate.GUID, _
                                                        objLocalConfig.Globals.Type_Object, _
                                                        Nothing, _
                                                        Nothing))

        objOItem_Result = objDBLevel_Process.get_Data_ObjectRel(objOList_Process_To_Parent)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Process.OList_ObjectRel_ID.Count > 0 Then
                objOItem_Result.Level = objDBLevel_Process.OList_ObjectRel_ID(0).OrderID
                objOItem_Result = objDBLevel_Process.del_ObjectRel(objOList_Process_To_Parent)
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Error
            End If
        End If



        Return objOItem_Result
    End Function


    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Process = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
