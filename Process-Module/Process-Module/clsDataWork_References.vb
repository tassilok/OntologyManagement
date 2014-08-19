Imports Ontology_Module
Imports Filesystem_Module
Imports OntologyClasses.BaseClasses

Public Class clsDataWork_References
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_OItem As clsDBLevel
    Private objDBLevel_ProcessRef As clsDBLevel

    Private objThread_ProcessRef As Threading.Thread

    Private objOItem_Result_References As clsOntologyItem
    Private objDBLevel_References As clsDBLevel

    Private objOItem_ProcessOrLog As clsOntologyItem
    Private objOItem_ProcessReference As clsOntologyItem

    Private objOLRefs As New List(Of clsObjectRel)

    Private objFileWork As clsFileWork

    Private objLRefTypes As New List(Of clsRefToNode)

    Public ReadOnly Property OItem_ProcessRef As clsOntologyItem
        Get
            Return objOItem_ProcessReference
        End Get
    End Property

    Public ReadOnly Property LRefTypes As List(Of clsRefToNode)
        Get
            Return objLRefTypes
        End Get
    End Property

    Public ReadOnly Property OItem_Result_ProcessRef As clsOntologyItem
        Get
            Return objOItem_Result_References
        End Get
    End Property

    Public ReadOnly Property OList_References As List(Of clsObjectRel)
        Get
            Return objDBLevel_ProcessRef.OList_ObjectRel
        End Get
    End Property

    Public Function GetOitem(GUID_Item As String, Type_Item As string) As clsOntologyItem
        Return objDBLevel_OItem.GetOItem(GUID_Item, Type_Item)
    End Function

   Public Sub fill_Ref(OItem_RelationType As clsOntologyItem, Optional OItem_Ref As clsOntologyItem = Nothing, Optional Type As String = Nothing)
        Dim objOItem_File As clsOntologyItem
        Dim objOItem_Folder As clsOntologyItem
        Dim objOItem_Ref As clsOntologyItem
        Dim objTreeNode As TreeNode
        Dim objTreeNodes() As TreeNode
        Dim intImageID As Integer
        If Not OItem_Ref Is Nothing Then
            Select Case OItem_Ref.GUID
                Case objLocalConfig.OItem_Type_File.GUID
                    Dim objLRefs = From obj In objDBLevel_ProcessRef.OList_ObjectRel
                                   Where obj.ID_Parent_Other = OItem_Ref.GUID _
                                   And obj.ID_RelationType = OItem_RelationType.GUID
                                   Select obj
                                   Order By obj.OrderID, obj.Name_Other

                    Dim objLRefT = From obj In objLRefTypes
                                  Where obj.OItem_RefType.GUID = objLocalConfig.OItem_Type_File.GUID _
                                  And obj.OItem_Rel_RefType.GUID = objLocalConfig.OItem_RelationType_needs.GUID

                    If objLRefT.Count > 0 Then
                        objTreeNode = objLRefT(0).TreeNode_RefType
                        intImageID = objLRefT(0).ImageID

                        For Each objRef In objLRefs

                            objOItem_File = New clsOntologyItem(objRef.ID_Other, _
                                                                objRef.Name_Other, _
                                                                objLocalConfig.OItem_Type_File.GUID, _
                                                                objLocalConfig.Globals.Type_Object)

                            objOItem_File.Name = objFileWork.get_Path_FileSystemObject(objOItem_File, True)



                            objTreeNode.Nodes.Add(objOItem_File.GUID, _
                                               objOItem_File.Name, _
                                               intImageID, _
                                               intImageID)
                        Next
                    End If

                    
                Case objLocalConfig.OItem_type_Folder.GUID
                    Dim objLRefs = From obj In objDBLevel_ProcessRef.OList_ObjectRel
                                   Where obj.ID_Parent_Other = OItem_Ref.GUID _
                                   And obj.ID_RelationType = OItem_RelationType.GUID
                                   Select obj
                                   Order By obj.OrderID, obj.Name_Other

                    Dim objLRefT = From obj In objLRefTypes
                                  Where obj.OItem_RefType.GUID = objLocalConfig.OItem_type_Folder.GUID _
                                  And obj.OItem_Rel_RefType.GUID = objLocalConfig.OItem_RelationType_needs.GUID

                    If objLRefT.Count > 0 Then
                        objTreeNode = objLRefT(0).TreeNode_RefType
                        intImageID = objLRefT(0).ImageID

                        For Each objRef In objLRefs
                            objOItem_Folder = New clsOntologyItem(objRef.ID_Other, _
                                                                objRef.Name_Other, _
                                                                objLocalConfig.OItem_type_Folder.GUID, _
                                                                objLocalConfig.Globals.Type_Object)

                            objOItem_Folder.Name = objFileWork.get_Path_FileSystemObject(objOItem_Folder, False)

                            objTreeNode.Nodes.Add(objOItem_Folder.GUID, _
                                               objOItem_Folder.Name, _
                                               intImageID, _
                                               intImageID)
                        Next
                    End If

                    
                Case Else
                    Dim objLRefs = From obj In objDBLevel_ProcessRef.OList_ObjectRel
                                   Where obj.ID_Parent_Other = OItem_Ref.GUID _
                                   And obj.ID_RelationType = OItem_RelationType.GUID
                                   Select obj
                                   Order By obj.OrderID, obj.Name_Other

                    Dim objLRefT = From obj In objLRefTypes
                                  Where obj.OItem_RefType.GUID = OItem_Ref.GUID _
                                  And obj.OItem_Rel_RefType.GUID = OItem_RelationType.GUID

                    If objLRefT.Count > 0 Then
                        objTreeNode = objLRefT(0).TreeNode_RefType
                        intImageID = objLRefT(0).ImageID
                        For Each objRef In objLRefs
                            If Not IsDBNull(objRef.ID_Parent_Other) Then
                                objOItem_Ref = New clsOntologyItem(objRef.ID_Other, _
                                                               objRef.Name_Other, _
                                                               objRef.ID_Parent_Other, _
                                                               objRef.Ontology)
                            Else
                                objOItem_Ref = New clsOntologyItem(objRef.ID_Other, _
                                                               objRef.Name_Other, _
                                                               Nothing, _
                                                               objRef.Ontology)
                            End If


                            objTreeNode.Nodes.Add(objRef.ID_Other, _
                                               objRef.Name_Other, _
                                               intImageID, _
                                               intImageID)
                        Next
                    End If

                    
            End Select

        Else
            If Not Type Is Nothing Then
                Dim objLRefs = From obj In objDBLevel_ProcessRef.OList_ObjectRel
                                   Where obj.ID_RelationType = OItem_RelationType.GUID _
                                   And obj.Ontology = Type
                                   Select obj
                                   Order By obj.OrderID, obj.Name_Other

                
                
                    For Each objRef In objLRefs

                    If objRef.ID_Parent_Other Is Nothing Then
                        Dim objLRefT = From obj In objLRefTypes
                                  Where obj.OItem_RefType.GUID Is objLocalConfig.OItem_Type_Process.GUID _
                                  And obj.OItem_Rel_RefType.GUID = objRef.ID_RelationType
                        objTreeNode = objLRefT(0).TreeNode_RefType
                        intImageID = objLRefT(0).ImageID
                    Else
                        Dim objLRefT = From obj In objLRefTypes
                                  Where obj.OItem_RefType.GUID = objRef.ID_Parent_Other _
                                  And obj.OItem_Rel_RefType.GUID = objRef.ID_RelationType
                        objTreeNode = objLRefT(0).TreeNode_RefType
                        intImageID = objLRefT(0).ImageID
                    End If
                    

                        If Not IsDBNull(objRef.ID_Parent_Other) Then
                            objOItem_Ref = New clsOntologyItem(objRef.ID_Other, _
                                                           objRef.Name_Other, _
                                                           objRef.ID_Parent_Other, _
                                                           Type)
                        Else
                            objOItem_Ref = New clsOntologyItem(objRef.ID_Other, _
                                                           objRef.Name_Other, _
                                                           Nothing, _
                                                           Type)
                        End If



                        objTreeNode.Nodes.Add(objRef.ID_Other, _
                                           objRef.Name_Other, _
                                           intImageID, _
                                           intImageID)
                    Next


                Else
                    Dim objLRefs = From obj In objDBLevel_ProcessRef.OList_ObjectRel
                                       Where obj.ID_RelationType = OItem_RelationType.GUID
                                       Select obj
                                       Order By obj.OrderID, obj.Name_Other



                    
                    
                For Each objRef In objLRefs
                    If objRef.ID_Parent_Other Is Nothing Then
                        Dim objLRefT = From obj In objLRefTypes
                                  Where obj.OItem_RefType.GUID Is objLocalConfig.OItem_Type_Process.GUID _
                                  And obj.OItem_Rel_RefType.GUID = objRef.ID_RelationType

                        objTreeNode = objLRefT(0).TreeNode_RefType
                        intImageID = objLRefT(0).ImageID
                    Else
                        Dim objLRefT = From obj In objLRefTypes
                                  Where obj.OItem_RefType.GUID = objRef.ID_Parent_Other _
                                  And obj.OItem_Rel_RefType.GUID = objRef.ID_RelationType
                        If objLRefT.Count > 0 Then
                            objTreeNode = objLRefT(0).TreeNode_RefType
                            intImageID = objLRefT(0).ImageID
                        Else
                            Dim objLRefT1 = From obj In objLRefTypes
                                  Where obj.OItem_RefType.GUID = objLocalConfig.OItem_Type_Process.GUID _
                                  And obj.OItem_Rel_RefType.GUID = objRef.ID_RelationType

                            If objLRefT1.Count > 0 Then
                                objTreeNode = objLRefT1(0).TreeNode_RefType
                                intImageID = objLRefT1(0).ImageID
                            End If
                        End If
                        
                    End If
                    
                    If Not IsDBNull(objRef.ID_Parent_Other) Then
                    
                        objOItem_Ref = New clsOntologyItem(objRef.ID_Other, _
                                                       objRef.Name_Other, _
                                                       objRef.ID_Parent_Other, _
                                                       objRef.Ontology)
                    Else
                        objOItem_Ref = New clsOntologyItem(objRef.ID_Other, _
                                                       objRef.Name_Other, _
                                                       Nothing, _
                                                       objRef.Ontology)
                    End If

                    objTreeNodes = objTreeNode.Nodes.Find(objRef.ID_Other, False)
                    If objTreeNodes.Count = 0 Then
                        objTreeNode.Nodes.Add(objRef.ID_Other, _
                                   objRef.Name_Other, _
                                   intImageID, _
                                   intImageID)
                    End If



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
                If Not objOItem_ProcessReference Is Nothing Then
                    objThread_ProcessRef = New Threading.Thread(AddressOf get_Data_ProcessReferences)
                    objThread_ProcessRef.Start()
                Else
                    objDBLevel_ProcessRef.OList_ObjectRel.Clear()
                    objOItem_Result_References = objLocalConfig.Globals.LState_Success
                End If
                
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
                objOItem_ProcessReference = Nothing
                objOItem_Result = objLocalConfig.Globals.LState_Success
            End If
        End If



        Return objOItem_Result
    End Function

    Public Sub add_Ref(OItem_Type_Ref As clsOntologyItem, _
                       OItem_RelType_Ref As clsOntologyItem, _
                       TreeNode_Ref As TreeNode, _
                       ImageID As Integer)

        objLRefTypes.Add(New clsRefToNode(OItem_Type_Ref, _
                                          OItem_RelType_Ref, _
                                          TreeNode_Ref, _
                                          ImageID))


    End Sub

    Public Sub clear_Refs()
        objLRefTypes.Clear()
    End Sub

    Public Sub clear_ProcessReferences()
        objDBLevel_ProcessRef.OList_ObjectRel.Clear()
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        objLRefTypes.Clear()

    End Sub

    Private Sub set_DBConnection()
        objDBLevel_ProcessRef = New clsDBLevel(objLocalConfig.Globals)

        objDBLevel_References = New clsDBLevel(objLocalConfig.Globals)

        objDBLevel_OItem = new clsDBLevel(objLocalConfig.Globals)

        objFileWork = New clsFileWork(objLocalConfig.Globals)
    End Sub
End Class
