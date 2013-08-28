Imports Ontolog_Module
Public Class clsDataWork
    Private objLocalConfig As clsLocalConfig

    Private otblT_Files As New DataSet_FileSystemModule.otbl_FilesDataTable

    Private oList_ObjRel As New List(Of clsObjectRel)

    Private objDBLevel_ServerState As clsDBLevel
    Private objDBLevel_ServerType As clsDBLevel
    Private objDBLevel_Drive As clsDBLevel
    Private objDBLevel_Folder As clsDBLevel
    Private objDBLevel_FolderTree As clsDBLevel
    Private objDBLevel_Files As clsDBLevel
    Private objDBLevel_Hash As clsDBLevel

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()

    End Sub

    Private Sub set_DBConnection()
        objDBLevel_ServerState = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ServerType = New clsDBLevel(objLocalConfig.Globals)

        objDBLevel_Drive = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Folder = New clsDBLevel(objLocalConfig.Globals)

        objDBLevel_FolderTree = New clsDBLevel(objLocalConfig.Globals)

        objDBLevel_Files = New clsDBLevel(objLocalConfig.Globals)

        objDBLevel_Hash = New clsDBLevel(objLocalConfig.Globals)
    End Sub

    Public Sub get_Servers(ByVal objTreeNode As TreeNode, ByVal intID_Server As Integer)
        Dim oList_ObjRel As New List(Of clsObjectRel)

        oList_ObjRel.Add(New clsObjectRel(Nothing, _
                                          Nothing, _
                                          objLocalConfig.OItem_Type_Server.GUID, _
                                          Nothing, _
                                          objLocalConfig.OItem_Token_Active_Server_State.GUID, _
                                          Nothing, _
                                          objLocalConfig.OItem_Type_Server_State.GUID, _
                                          Nothing, _
                                          objLocalConfig.OItem_RelationType_isInState.GUID, _
                                          Nothing, _
                                          objLocalConfig.Globals.Type_Object, _
                                          Nothing, _
                                          Nothing, _
                                          Nothing))


        objDBLevel_ServerState.get_Data_ObjectRel(oList_ObjRel, _
                                                  boolIDs:=False)

        oList_ObjRel.Clear()

        oList_ObjRel.Add(New clsObjectRel(Nothing, _
                                          Nothing, _
                                          objLocalConfig.OItem_Type_Server.GUID, _
                                          Nothing, _
                                          objLocalConfig.OItem_Token_Fileserver_Server_Type.GUID, _
                                          Nothing, _
                                          objLocalConfig.OItem_Type_Server_Type.GUID, _
                                          Nothing, _
                                          objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                          Nothing, _
                                          objLocalConfig.Globals.Type_Object, _
                                          Nothing, _
                                          Nothing, _
                                          Nothing))

        objDBLevel_ServerType.get_Data_ObjectRel(oList_ObjRel)

        Dim objServerList = From objState In objDBLevel_ServerState.OList_ObjectRel
                            Join objType In objDBLevel_ServerType.OList_ObjectRel_ID On objState.ID_Object Equals objType.ID_Object

        For Each objServer In objServerList
            objTreeNode.Nodes.Add(objServer.objState.ID_Object, _
                                  objServer.objState.Name_Object,
                                  intID_Server, _
                                  intID_Server)
        Next
    End Sub

    Public Sub get_Folders(ByVal objTreeNode As TreeNode, _
                           ByVal intImageID_Folder_Closed As Integer, _
                           ByVal intImageID_Folder_Opened As Integer, _
                           ByVal ID_RelationType As String)

        Dim objTreeNode_Folder As TreeNode
        Dim objOItem_ObjRel As clsObjectRel

        oList_ObjRel.Clear()
        If ID_RelationType = objLocalConfig.OItem_RelationType_isSubordinated.GUID Then
           
            oList_ObjRel.Add(New clsObjectRel(Nothing, _
                                              Nothing, _
                                              objLocalConfig.OItem_type_Folder.GUID, _
                                              Nothing, _
                                              objTreeNode.Name, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              ID_RelationType, _
                                              Nothing, _
                                              objLocalConfig.Globals.Type_Object, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing))
           
        Else
            
            oList_ObjRel.Add(New clsObjectRel(objTreeNode.Name, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              objLocalConfig.OItem_type_Folder.GUID, _
                                              Nothing, _
                                              ID_RelationType, _
                                              Nothing, _
                                              objLocalConfig.Globals.Type_Object, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing))
        End If
        

        objDBLevel_Folder.get_Data_ObjectRel(oList_ObjRel, _
                                             boolIDs:=False)

        objDBLevel_FolderTree.get_Data_Objects_Tree(objLocalConfig.OItem_type_Folder, _
                                                    objLocalConfig.OItem_type_Folder, _
                                                    objLocalConfig.OItem_RelationType_isSubordinated)

        For Each objOItem_ObjRel In objDBLevel_Folder.OList_ObjectRel

            If ID_RelationType = objLocalConfig.OItem_RelationType_isSubordinated.GUID Then
                objTreeNode_Folder = objTreeNode.Nodes.Add(objOItem_ObjRel.ID_Object, _
                                                       objOItem_ObjRel.Name_Object, _
                                                       intImageID_Folder_Closed, _
                                                       intImageID_Folder_Opened)
            Else
                objTreeNode_Folder = objTreeNode.Nodes.Add(objOItem_ObjRel.ID_Other, _
                                                       objOItem_ObjRel.Name_Other, _
                                                       intImageID_Folder_Closed, _
                                                       intImageID_Folder_Opened)
            End If
            
            get_SubFolders(objTreeNode_Folder, _
                           intImageID_Folder_Closed, _
                           intImageID_Folder_Opened)


        Next
    End Sub

    Public Function get_Files(Optional ByVal objTreeNode As TreeNode = Nothing, Optional ByVal strFilter As String = "") As DataSet_FileSystemModule.otbl_FilesDataTable
        Dim oList_Objects As New List(Of clsOntologyItem)
        Dim oList_ObjRel As New List(Of clsObjectRel)
        Dim oList_ObjAtt As New List(Of clsObjectAtt)

        Dim objOItem_Object As New clsOntologyItem

        otblT_Files.Clear()

        
        objOItem_Object.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
        objOItem_Object.Type = objLocalConfig.Globals.Type_Object

       
        oList_ObjRel.Clear()

        If objTreeNode Is Nothing Then

            oList_Objects.Clear()



            If strFilter <> "" Then
                If objLocalConfig.Globals.is_GUID(strFilter) = True Then
                    oList_Objects.Add(New clsOntologyItem(strFilter, Nothing, objLocalConfig.OItem_Type_File.GUID, objLocalConfig.Globals.Type_Object))
                Else
                    oList_Objects.Add(New clsOntologyItem(Nothing, strFilter, objLocalConfig.OItem_Type_File.GUID, objLocalConfig.Globals.Type_Object))
                End If
            Else
                oList_Objects.Add(New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Type_File.GUID, objLocalConfig.Globals.Type_Object))
            End If

            objDBLevel_Files.get_Data_Objects(oList_Objects)

            oList_ObjAtt.Add(New clsObjectAtt(Nothing, _
                                         Nothing, _
                                         Nothing, _
                                         objOItem_Object.GUID_Parent, _
                                         Nothing, _
                                         objLocalConfig.OItem_Attribute_Blob.GUID, _
                                         Nothing, _
                                         Nothing, _
                                         Nothing, _
                                         True, _
                                         Nothing, _
                                         Nothing, _
                                         Nothing, _
                                         Nothing, _
                                         Nothing))

            objDBLevel_Files.get_Data_ObjectAtt(oList_ObjAtt, _
                                        boolIDs:=False, _
                                        doJoin:=True)

            Dim objL = From objFile In objDBLevel_Files.OList_Objects
                   Group Join objBlob In objDBLevel_Files.OList_ObjectAtt On objBlob.ID_Object Equals objFile.GUID Into RightTableResult = Group
                   From objBlobs In RightTableResult.DefaultIfEmpty
                   Select ID_File = objFile.GUID, _
                          Name_File = objFile.Name, _
                          objBlobs

            For Each objFile In objL
                If objFile.objBlobs Is Nothing Then
                    otblT_Files.Rows.Add(objFile.ID_File, _
                                         objFile.Name_File, _
                                         False)
                Else
                    If objFile.objBlobs.Val_Bit = False Then
                        otblT_Files.Rows.Add(objFile.ID_File, _
                                         objFile.Name_File, _
                                         False, _
                                         objLocalConfig.OItem_Type_File.GUID)
                    Else
                        otblT_Files.Rows.Add(objFile.ID_File, _
                                         objFile.Name_File, _
                                         True, _
                                         objLocalConfig.OItem_Type_File.GUID)
                    End If
                End If

            Next
        Else

            If strFilter <> "" Then
                If objLocalConfig.Globals.is_GUID(strFilter) = True Then
                    oList_ObjRel.Add(New clsObjectRel(strFilter, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objTreeNode.Name, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_RelationType_isSubordinated.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing))


                Else
                    oList_ObjRel.Add(New clsObjectRel(Nothing, _
                                                      strFilter, _
                                                      objLocalConfig.OItem_Type_File.GUID, _
                                                      Nothing, _
                                                      objTreeNode.Name, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_RelationType_isSubordinated.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing))

                End If
            Else
                oList_ObjRel.Add(New clsObjectRel(Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Type_File.GUID, _
                                                      Nothing, _
                                                      objTreeNode.Name, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_RelationType_isSubordinated.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing))
            End If



            objDBLevel_Files.get_Data_ObjectRel(oList_ObjRel, _
                                                boolIDs:=False)

            If strFilter <> "" Then
                If objLocalConfig.Globals.is_GUID(strFilter) = True Then
                    oList_ObjAtt.Add(New clsObjectAtt(Nothing, _
                                             strFilter, _
                                             Nothing, _
                                             objOItem_Object.GUID_Parent, _
                                             Nothing, _
                                             objLocalConfig.OItem_Attribute_Blob.GUID, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             True, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing))
                Else
                    oList_ObjAtt.Add(New clsObjectAtt(Nothing, _
                                             Nothing, _
                                             strFilter, _
                                             objOItem_Object.GUID_Parent, _
                                             Nothing, _
                                             objLocalConfig.OItem_Attribute_Blob.GUID, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             True, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing))

                End If
            Else
                oList_ObjAtt.Add(New clsObjectAtt(Nothing, _
                                                             Nothing, _
                                                             Nothing, _
                                                             objOItem_Object.GUID_Parent, _
                                                             Nothing, _
                                                             objLocalConfig.OItem_Attribute_Blob.GUID, _
                                                             Nothing, _
                                                             Nothing, _
                                                             Nothing, _
                                                             True, _
                                                             Nothing, _
                                                             Nothing, _
                                                             Nothing, _
                                                             Nothing, _
                                                             Nothing))

            End If
            


            objDBLevel_Files.get_Data_ObjectAtt(oList_ObjAtt, _
                                        boolIDs:=False, _
                                        doJoin:=True)

            objOItem_Object.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
            objOItem_Object.Type = objLocalConfig.Globals.Type_Object

            Dim objL = From objFile In objDBLevel_Files.OList_ObjectRel
                   Group Join objBlob In objDBLevel_Files.OList_ObjectAtt On objBlob.ID_Object Equals objFile.ID_Object Into RightTableResult = Group
                   From objBlobs In RightTableResult.DefaultIfEmpty
                   Select ID_File = objFile.ID_Object, _
                          Name_File = objFile.Name_Object, _
                          objBlobs

            For Each objFile In objL
                If objFile.objBlobs Is Nothing Then
                    otblT_Files.Rows.Add(objFile.ID_File, _
                                         objFile.Name_File, _
                                         False, _
                                         objLocalConfig.OItem_Type_File.GUID)
                Else
                    If objFile.objBlobs.Val_Bit = False Then
                        otblT_Files.Rows.Add(objFile.ID_File, _
                                         objFile.Name_File, _
                                         False, _
                                         objLocalConfig.OItem_Type_File.GUID)
                    Else
                        otblT_Files.Rows.Add(objFile.ID_File, _
                                         objFile.Name_File, _
                                         True, _
                                         objLocalConfig.OItem_Type_File.GUID)
                    End If
                End If

            Next
        End If







        Return otblT_Files

    End Function

    Private Sub get_SubFolders(ByVal objTreeNode As TreeNode, _
                               ByVal intImageID_Folder_Closed As Integer, _
                               ByVal intImageID_Folder_Opened As Integer)

        Dim objTreeNode_Sub As TreeNode

        Dim objL = From obj In objDBLevel_FolderTree.OList_ObjectTree
                   Where obj.ID_Object = objTreeNode.Name
                   Group By obj.ID_Object_Parent, obj.Name_Object_Parent Into Group

        For Each obj In objL

            objTreeNode_Sub = objTreeNode.Nodes.Add(obj.ID_Object_Parent, _
                                                obj.Name_Object_Parent, _
                                                intImageID_Folder_Closed, _
                                                intImageID_Folder_Opened)

            get_SubFolders(objTreeNode_Sub, _
                           intImageID_Folder_Closed, _
                           intImageID_Folder_Opened)


        Next

    End Sub

    Public Sub get_Drvies(ByVal objTreeNode As TreeNode, _
                          ByVal intImageID_Drive As Integer, _
                          ByVal intImageID_Folder_Closed As Integer, _
                          ByVal intImageID_Folder_Opened As Integer)

        Dim objOItem_ObjRel As clsObjectRel
        Dim objTreeNode_Drive As TreeNode

        oList_ObjRel.Clear()

        oList_ObjRel.Add(New clsObjectRel(Nothing, _
                                          Nothing, _
                                          objLocalConfig.OItem_Type_Drive.GUID, _
                                          Nothing, _
                                          objTreeNode.Name, _
                                          Nothing, _
                                          Nothing, _
                                          Nothing, _
                                          objLocalConfig.OItem_RelationType_isSubordinated.GUID, _
                                          Nothing, _
                                          objLocalConfig.Globals.Type_Object, _
                                          Nothing, _
                                          Nothing, _
                                          Nothing))

        objDBLevel_Drive.get_Data_ObjectRel(oList_ObjRel, _
                                            boolIDs:=False)

        For Each objOItem_ObjRel In objDBLevel_Drive.OList_ObjectRel
            objTreeNode_Drive = objTreeNode.Nodes.Add(objOItem_ObjRel.ID_Object, _
                                  objOItem_ObjRel.Name_Object, _
                                  intImageID_Drive, _
                                  intImageID_Drive)

            get_Folders(objTreeNode_Drive, _
                        intImageID_Folder_Closed, _
                        intImageID_Folder_Opened, _
                        objLocalConfig.OItem_RelationType_isSubordinated.GUID)

        Next
    End Sub

    Public Function File_NotExist(ByVal oItem_Folder As clsOntologyItem, ByVal oList_Files As List(Of clsOntologyItem)) As List(Of clsOntologyItem)

        Dim oList_ObjRel As New List(Of clsObjectRel)
        Dim oList_Result As New List(Of clsOntologyItem)

        
        oList_ObjRel.Add(New clsObjectRel(Nothing, _
                                          Nothing, _
                                          objLocalConfig.OItem_Type_File.GUID, _
                                          Nothing, _
                                          oItem_Folder.GUID, _
                                          oItem_Folder.Name, _
                                          oItem_Folder.GUID_Parent, _
                                          Nothing, _
                                          objLocalConfig.OItem_RelationType_isSubordinated.GUID, _
                                          Nothing, _
                                          objLocalConfig.Globals.Type_Object, _
                                          Nothing, _
                                          Nothing, _
                                          Nothing))


        objDBLevel_Files.get_Data_ObjectRel(oList_ObjRel, _
                                            boolIDs:=False)

        Dim objL = From objFile In oList_Files
                   Group Join objRef In objDBLevel_Files.OList_ObjectRel On objRef.Name_Object.ToLower Equals objFile.Name.ToLower Into FilesRight = Group
                   From objFilesTest In FilesRight.DefaultIfEmpty
                   Where objFilesTest Is Nothing


        For Each objFile In objL
            oList_Result.Add(New clsOntologyItem(Guid.NewGuid.ToString.Replace("-", ""), objFile.objFile.Name, objLocalConfig.OItem_Type_File.GUID, objLocalConfig.Globals.Type_Object))
        Next

        Return oList_Result
    End Function

    Public Function Folder_NotExist(ByVal oItem_FileSystemItem As clsOntologyItem, _
                                    ByVal oItem_NewFolder As clsOntologyItem) As clsOntologyItem

        Dim oList_ObjRel As New List(Of clsObjectRel)
        
        Dim objOItem_Result As New clsOntologyItem
        Dim boolResult As Boolean

        objOItem_Result.GUID = oItem_NewFolder.GUID
        objOItem_Result.Name = oItem_NewFolder.Name
        objOItem_Result.GUID_Parent = oItem_NewFolder.GUID_Parent

        If oItem_FileSystemItem.GUID_Parent = objLocalConfig.OItem_Type_Server.GUID Then
            oList_ObjRel.Add(New clsObjectRel(oItem_FileSystemItem.GUID, _
                                              oItem_FileSystemItem.Name, _
                                              oItem_FileSystemItem.GUID_Parent, _
                                              Nothing, _
                                              oItem_NewFolder.GUID, _
                                              oItem_NewFolder.Name, _
                                              oItem_NewFolder.GUID_Parent, _
                                              Nothing, _
                                              objLocalConfig.OItem_RelationType_Fileshare.GUID, _
                                              Nothing, _
                                              objLocalConfig.Globals.Type_Object, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing))

        Else

            oList_ObjRel.Add(New clsObjectRel(oItem_NewFolder.GUID, _
                                              oItem_NewFolder.Name, _
                                              oItem_NewFolder.GUID_Parent, _
                                              Nothing, _
                                              oItem_FileSystemItem.GUID, _
                                              oItem_FileSystemItem.Name, _
                                              oItem_FileSystemItem.GUID_Parent, _
                                              Nothing, _
                                              objLocalConfig.OItem_RelationType_isSubordinated.GUID, _
                                              Nothing, _
                                              objLocalConfig.Globals.Type_Object, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing))

            
        End If


        objDBLevel_Folder.get_Data_ObjectRel(oList_ObjRel, _
                                             boolIDs:=False)


        If oItem_FileSystemItem.GUID_Parent = objLocalConfig.OItem_Type_Server.GUID Then
            Dim OList = From objRel In objDBLevel_Folder.OList_ObjectRel
                        Where objRel.Name_Other.ToLower.Contains(oItem_NewFolder.Name)

            If OList.Count = 0 Then
                boolResult = True
            Else
                objOItem_Result.GUID = OList(0).ID_Other
                objOItem_Result.Name = OList(0).Name_Other
                boolResult = False
            End If
        Else
            Dim OList = From objRel In objDBLevel_Folder.OList_ObjectRel
                        Where objRel.Name_Object.ToLower.Contains(oItem_NewFolder.Name)

            If OList.Count = 0 Then
                boolResult = True
            Else
                objOItem_Result.GUID = OList(0).ID_Object
                objOItem_Result.Name = OList(0).Name_Object
                boolResult = False
            End If
        End If





        Return objOItem_Result
    End Function

    Public Function search_Hash(ByVal strHash As String) As clsOntologyItem
        Dim oItem_Result As clsOntologyItem
        Dim oList_ObjAtt As New List(Of clsObjectAtt)

        oList_ObjAtt.Add(New clsObjectAtt(Nothing, _
                                          Nothing, _
                                          Nothing, _
                                          Nothing, _
                                          Nothing, _
                                          objLocalConfig.OItem_Attribute_Hash.GUID, _
                                          Nothing, _
                                          Nothing, _
                                          Nothing, _
                                          Nothing, _
                                          Nothing, _
                                          Nothing, _
                                          Nothing, _
                                          strHash, _
                                          Nothing))

        objDBLevel_Hash.get_Data_ObjectAtt(oList_ObjAtt, _
                                           boolIDs:=False)

        If objDBLevel_Hash.OList_ObjectAtt.Count > 0 Then
            oItem_Result = New clsOntologyItem(objDBLevel_Hash.OList_ObjectAtt(0).ID_Object, _
                                               objDBLevel_Hash.OList_ObjectAtt(0).Name_Object, _
                                               objLocalConfig.OItem_Type_File.GUID, _
                                               objLocalConfig.Globals.Type_Object)

        Else
            oItem_Result = Nothing
        End If


        Return oItem_Result
    End Function

    Public Function get_FileByGUID(strGUID As String) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_File As clsOntologyItem
        Dim objOList_File As New List(Of clsOntologyItem)

        objOList_File.Add(New clsOntologyItem(strGUID, objLocalConfig.Globals.Type_Object))

        objOItem_Result = objDBLevel_Files.get_Data_Objects(objOList_File)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Files.OList_Objects.Any Then
                objOItem_File = objDBLevel_Files.OList_Objects.First()
            Else
                objOItem_File = Nothing
            End If

        Else
            objOItem_File = Nothing
        End If

        Return objOItem_File
    End Function

    Public Function get_FilesOfServer(OItem_Server As clsOntologyItem) As List(Of clsOntologyItem)
        Dim objOLR_RegisteredFiles As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_Files As New List(Of clsOntologyItem)

        objOLR_RegisteredFiles.Add(New clsObjectRel() With {.ID_Object = objLocalConfig.Globals.OItem_Server.GUID, _
                                                            .ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID, _
                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_is_checkout_by.GUID})

        objOItem_Result = objDBLevel_Files.get_Data_ObjectRel(objOLR_RegisteredFiles, _
                                                              boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOL_Files = (From objFile In objDBLevel_Files.OList_ObjectRel
                           Select New clsOntologyItem() With {.GUID = objFile.ID_Other, _
                                                               .Name = objFile.Name_Other, _
                                                               .GUID_Parent = objFile.ID_Parent_Other, _
                                                               .Type = objLocalConfig.Globals.Type_Object}).ToList()

        Else

            objOL_Files = Nothing
        End If

        Return objOL_Files
    End Function

    


End Class
