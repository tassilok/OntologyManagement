Imports Ontolog_Module
Imports Filesystem_Module
Public Class clsDataWork_References
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_ProcessRef As clsDBLevel

    Private objThread_ProcessRef As Threading.Thread

    Private objOItem_Result_References As clsOntologyItem
    Private objDBLevel_References As clsDBLevel

    Private objOItem_ProcessOrLog As clsOntologyItem
    Private objOItem_ProcessReference As clsOntologyItem

    Private objOLRefs As New List(Of clsObjectRel)

    Private objFileWork As clsFileWork

    Public ReadOnly Property OItem_Result_ProcessRef As clsOntologyItem
        Get
            Return objOItem_Result_References
        End Get
    End Property

    Public Sub fill_Ref(TreeNode As TreeNode, OItem_RelationType As clsOntologyItem, Optional OItem_Ref As clsOntologyItem = Nothing, Optional Type As String = Nothing)
        Dim objOItem_File As clsOntologyItem
        Dim objOItem_Folder As clsOntologyItem
        If Not OItem_Ref Is Nothing Then
            Select Case OItem_Ref.GUID
                Case objLocalConfig.OItem_Type_File.GUID
                    Dim objLRefs = From obj In objDBLevel_ProcessRef.OList_ObjectRel
                                   Where obj.ID_Parent_Other = OItem_Ref.GUID _
                                   And obj.ID_RelationType = OItem_RelationType.GUID
                                   Select obj
                                   Order By obj.OrderID, obj.Name_Other

                    For Each objRef In objLRefs
                        objOItem_File = New clsOntologyItem(objRef.ID_Other, _
                                                            objRef.Name_Other, _
                                                            objLocalConfig.OItem_Type_File.GUID, _
                                                            objLocalConfig.Globals.Type_Object)

                        objOItem_File.Name = objFileWork.get_Path_FileSystemObject(objOItem_File, True)

                        TreeNode.Nodes.Add(objOItem_File.GUID, _
                                           objOItem_File.Name, _
                                           objLocalConfig.ImageID_File, _
                                           objLocalConfig.ImageID_File)
                    Next
                Case objLocalConfig.OItem_type_Folder.GUID
                    Dim objLRefs = From obj In objDBLevel_ProcessRef.OList_ObjectRel
                                   Where obj.ID_Parent_Other = OItem_Ref.GUID _
                                   And obj.ID_RelationType = OItem_RelationType.GUID
                                   Select obj
                                   Order By obj.OrderID, obj.Name_Other

                    For Each objRef In objLRefs
                        objOItem_Folder = New clsOntologyItem(objRef.ID_Other, _
                                                            objRef.Name_Other, _
                                                            objLocalConfig.OItem_type_Folder.GUID, _
                                                            objLocalConfig.Globals.Type_Object)

                        objOItem_Folder.Name = objFileWork.get_Path_FileSystemObject(objOItem_Folder, False)

                        TreeNode.Nodes.Add(objOItem_Folder.GUID, _
                                           objOItem_Folder.Name, _
                                           objLocalConfig.ImageID_File, _
                                           objLocalConfig.ImageID_File)
                    Next
                Case Else
                    Dim objLRefs = From obj In objDBLevel_ProcessRef.OList_ObjectRel
                                   Where obj.ID_Parent_Other = OItem_Ref.GUID _
                                   And obj.ID_RelationType = OItem_RelationType.GUID
                                   Select obj
                                   Order By obj.OrderID, obj.Name_Other

                    For Each objRef In objLRefs
                        TreeNode.Nodes.Add(objRef.ID_Other, _
                                           objRef.Name_Other, _
                                           objLocalConfig.ImageID_Application, _
                                           objLocalConfig.ImageID_Application)
                    Next
            End Select

        Else
            If Not Type Is Nothing Then
                Dim objLRefs = From obj In objDBLevel_ProcessRef.OList_ObjectRel
                                   Where obj.ID_RelationType = OItem_RelationType.GUID _
                                   And obj.Ontology = Type
                                   Select obj
                                   Order By obj.OrderID, obj.Name_Other

                For Each objRef In objLRefs
                    TreeNode.Nodes.Add(objRef.ID_Other, _
                                       objRef.Name_Other, _
                                       objLocalConfig.ImageID_Application, _
                                       objLocalConfig.ImageID_Application)
                Next
            Else
                Dim objLRefs = From obj In objDBLevel_ProcessRef.OList_ObjectRel
                                   Where obj.ID_RelationType = OItem_RelationType.GUID
                                   Select obj
                                   Order By obj.OrderID, obj.Name_Other

                For Each objRef In objLRefs
                    TreeNode.Nodes.Add(objRef.ID_Other, _
                                       objRef.Name_Other, _
                                       objLocalConfig.ImageID_Application, _
                                       objLocalConfig.ImageID_Application)
                Next
            End If



        End If

    End Sub

    

    Public Function get_Data(OItem_ProcessOrLog As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_ProcessOrLog = OItem_ProcessOrLog


        If Not objOItem_ProcessOrLog Is Nothing Then
            objOItem_Result_References = objLocalConfig.Globals.LState_Nothing
            objOItem_Result = get_ProcessReference()

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                objThread_ProcessRef = New Threading.Thread(AddressOf get_Data_ProcessReferences)
                objThread_ProcessRef.Start()
            End If
        Else
            objOItem_Result_References = objLocalConfig.Globals.LState_Success
            objOItem_Result = objOItem_Result_References
            objDBLevel_ProcessRef.OList_ObjectRel.Clear()
        End If
        

        Return objOItem_Result
    End Function

    Public Sub get_Data_ProcessReferences()
        Dim objOList_ProcessReferences As New List(Of clsObjectRel)
        objOItem_Result_References = objLocalConfig.Globals.LState_Nothing

        objOList_ProcessReferences.Add(New clsObjectRel(objOItem_ProcessReference.GUID, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing))

        objOItem_Result_References = objDBLevel_ProcessRef.get_Data_ObjectRel(objOList_ProcessReferences, _
                                                                              boolIDs:=False)

    End Sub

    Private Function get_ProcessReference() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_ProcessRef As New List(Of clsObjectRel)

        objOList_ProcessRef.Add(New clsObjectRel(objOItem_ProcessOrLog.GUID, _
                                                 Nothing, _
                                                 Nothing, _
                                                 objLocalConfig.OItem_Type_Process_References.GUID, _
                                                 objLocalConfig.OItem_RelationType_contains.GUID, _
                                                 objLocalConfig.Globals.Type_Object, _
                                                 Nothing, _
                                                 Nothing))

        objOItem_Result = objDBLevel_References.get_Data_ObjectRel(objOList_ProcessRef, _
                                                                   boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_References.OList_ObjectRel.Count > 0 Then
                objOItem_ProcessReference = New clsOntologyItem(objDBLevel_References.OList_ObjectRel(0).ID_Other, _
                                                                objDBLevel_References.OList_ObjectRel(0).Name_Other, _
                                                                objLocalConfig.OItem_Type_Process_References.GUID, _
                                                                objLocalConfig.Globals.Type_Object)


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
        objDBLevel_ProcessRef = New clsDBLevel(objLocalConfig.Globals)

        objDBLevel_References = New clsDBLevel(objLocalConfig.Globals)

        objFileWork = New clsFileWork(objLocalConfig.Globals)
    End Sub
End Class
