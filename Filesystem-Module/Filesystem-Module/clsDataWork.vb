Imports Ontolog_Module
Public Class clsDataWork
    Private objLocalConfig As clsLocalConfig

    Private otblT_Files As New DataSet_FileSystemModule.otbl_FilesDataTable

    Private oList_Object As New List(Of clsOntologyItem)
    Private oList_Other As New List(Of clsOntologyItem)
    Private oList_RelType As New List(Of clsOntologyItem)

    Private objDBLevel_ServerState As clsDBLevel
    Private objDBLevel_ServerType As clsDBLevel
    Private objDBLevel_Drive As clsDBLevel
    Private objDBLevel_Folder As clsDBLevel
    Private objDBLevel_FolderTree As clsDBLevel
    Private objDBLevel_Files As clsDBLevel

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
    End Sub

    Public Sub get_Servers(ByVal objTreeNode As TreeNode, ByVal intID_Server As Integer)
        oList_Object.Add(New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Type_Server.GUID, objLocalConfig.Globals.Type_Object))
        oList_Other.Add(New clsOntologyItem(objLocalConfig.OItem_Token_Active_Server_State.GUID, objLocalConfig.Globals.Type_Object))
        oList_RelType.Add(objLocalConfig.OItem_RelationType_isInState)
        objDBLevel_ServerState.get_Data_ObjectRel(oList_Object, _
                                                  oList_Other, _
                                                  oList_RelType, _
                                                  boolIDs:=False)

        oList_Object.Clear()
        oList_Other.Clear()
        oList_RelType.Clear()
        oList_Other.Add(New clsOntologyItem(objLocalConfig.OItem_Token_Fileserver_Server_Type.GUID, objLocalConfig.Globals.Type_Object))
        objDBLevel_ServerType.get_Data_ObjectRel(oList_Object, _
                                                  oList_Other, _
                                                  oList_RelType)

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

        oList_RelType.Clear()
        oList_RelType.Add(New clsOntologyItem(ID_RelationType, objLocalConfig.Globals.Type_RelationType))
        If ID_RelationType = objLocalConfig.OItem_RelationType_isSubordinated.GUID Then
            oList_Object.Clear()
            oList_Object.Add(New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_type_Folder.GUID, objLocalConfig.Globals.Type_Object))

            oList_Other.Clear()
            oList_Other.Add(New clsOntologyItem(objTreeNode.Name, objLocalConfig.Globals.Type_Object))

           
        Else
            oList_Other.Clear()
            oList_Other.Add(New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_type_Folder.GUID, objLocalConfig.Globals.Type_Object))

            oList_Object.Clear()
            oList_Object.Add(New clsOntologyItem(objTreeNode.Name, objLocalConfig.Globals.Type_Object))
        End If
        

        objDBLevel_Folder.get_Data_ObjectRel(oList_Object, _
                                             oList_Other, _
                                             oList_RelType, _
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
        Dim oList_Others As New List(Of clsOntologyItem)
        Dim oList_RelType As New List(Of clsOntologyItem)
        Dim oList_ObjAtt As New List(Of clsObjectAtt)

        Dim objOItem_Object As New clsOntologyItem

        otblT_Files.Clear()

        
        objOItem_Object.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
        objOItem_Object.Type = objLocalConfig.Globals.Type_Object

       


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
            oList_Others.Add(New clsOntologyItem(objTreeNode.Name, objLocalConfig.Globals.Type_Object))



            If strFilter <> "" Then
                If objLocalConfig.Globals.is_GUID(strFilter) = True Then
                    oList_Objects.Add(New clsOntologyItem(strFilter, Nothing, objLocalConfig.OItem_Type_File.GUID, objLocalConfig.Globals.Type_Object))
                Else
                    oList_Objects.Add(New clsOntologyItem(Nothing, strFilter, objLocalConfig.OItem_Type_File.GUID, objLocalConfig.Globals.Type_Object))
                End If
            Else
                oList_Objects.Add(New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Type_File.GUID, objLocalConfig.Globals.Type_Object))
            End If
            

            

            oList_RelType.Add(objLocalConfig.OItem_RelationType_isSubordinated)

            objDBLevel_Files.get_Data_Objects(oList_Objects)

            objDBLevel_Files.get_Data_ObjectRel(oList_Objects, _
                                                oList_Others, _
                                                oList_RelType, _
                                                boolIDs:=False, _
                                                doJoin_Left:=True)

            If objLocalConfig.Globals.is_GUID(strFilter) = True Then
                oList_ObjAtt.Add(New clsObjectAtt(Nothing, _
                                         strfilter, _
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
            

            objDBLevel_Files.get_Data_ObjectAtt(oList_ObjAtt, _
                                        boolIDs:=False, _
                                        doJoin:=True)

            objOItem_Object.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
            objOItem_Object.Type = objLocalConfig.Globals.Type_Object

            Dim objL = From objFile In objDBLevel_Files.OList_ObjectRel
                   Group Join objBlob In objDBLevel_Files.OList_ObjectAtt_ID On objBlob.ID_Object Equals objFile.ID_Object Into RightTableResult = Group
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

        oList_Object.Clear()
        oList_Object.Add(New clsOntologyItem(Nothing, _
                                             Nothing, _
                                             objLocalConfig.OItem_Type_Drive.GUID, _
                                             objLocalConfig.Globals.Type_Object))

        oList_Other.Clear()
        oList_Other.Add(New clsOntologyItem(objTreeNode.Name, objLocalConfig.Globals.Type_Object))

        oList_RelType.Clear()
        oList_RelType.Add(New clsOntologyItem(objLocalConfig.OItem_RelationType_isSubordinated.GUID, objLocalConfig.Globals.Type_RelationType))

        objDBLevel_Drive.get_Data_ObjectRel(oList_Object, _
                                            oList_Other, _
                                            oList_RelType, _
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
        Dim oList_Folders As New List(Of clsOntologyItem)
        Dim oList_RelType As New List(Of clsOntologyItem)
        Dim oList_Files2 As New List(Of clsOntologyItem)
        Dim oList_Result As New List(Of clsOntologyItem)

        oList_Folders.Add(oItem_Folder)
        oList_RelType.Add(objLocalConfig.OItem_RelationType_isSubordinated)
        oList_Files2.Add(New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Type_File.GUID, objLocalConfig.Globals.Type_Object))

        objDBLevel_Files.get_Data_ObjectRel(oList_Files2, _
                                            oList_Folders, _
                                            oList_RelType, _
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

        Dim oList_Objects As New List(Of clsOntologyItem)
        Dim oList_Others As New List(Of clsOntologyItem)
        Dim oList_RelType As New List(Of clsOntologyItem)
        Dim objOItem_Result As New clsOntologyItem
        Dim boolResult As Boolean

        objOItem_Result.GUID = oItem_NewFolder.GUID
        objOItem_Result.Name = oItem_NewFolder.Name
        objOItem_Result.GUID_Parent = oItem_NewFolder.GUID_Parent

        If oItem_FileSystemItem.GUID_Parent = objLocalConfig.OItem_Type_Server.GUID Then
            oList_Objects.Add(oItem_FileSystemItem)
            oList_Others.Add(oItem_NewFolder)
            oList_RelType.Add(objLocalConfig.OItem_RelationType_Fileshare)
        Else
            oList_Objects.Add(oItem_NewFolder)
            oList_Others.Add(oItem_FileSystemItem)
            oList_RelType.Add(objLocalConfig.OItem_RelationType_isSubordinated)
        End If


        objDBLevel_Folder.get_Data_ObjectRel(oList_Objects, _
                                             oList_Others, _
                                             oList_RelType, _
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

End Class
