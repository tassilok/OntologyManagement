Imports Ontolog_Module
Imports ClassLibrary_ShellWork
Public Class clsFileWork

    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Blob As clsDBLevel
    Private objDBLevel_FSO As clsDBLevel
    Private objDBLevel_Folder As clsDBLevel
    Private objDBLevel_Server As clsDBLevel
    Private objDBLevel_Drive As clsDBLevel

    Private objOItem_Drive As clsOntologyItem
    Private objOItem_Server As clsOntologyItem
    Private objOItem_Share As clsOntologyItem

    Private objShellWork As clsShellWork

    Private boolBlob As Boolean
    Private strSeperator As String

    Public Function is_File_Blob(ByVal objOItem_File As clsOntologyItem) As Boolean
        Dim boolResult As Boolean
        Dim objLBlob As New List(Of clsObjectAtt)

        objLBlob.Add(New clsObjectAtt(Nothing, _
                                      objOItem_File.GUID, _
                                      Nothing, _
                                      objLocalConfig.OItem_Attribute_Blob.GUID, _
                                      Nothing))

        objDBLevel_Blob.get_Data_ObjectAtt(objLBlob, _
                                           boolIDs:=False)

        If objDBLevel_Blob.OList_ObjectAtt.Count > 0 Then
            boolResult = objDBLevel_Blob.OList_ObjectAtt(0).Val_Bit
        Else
            boolResult = False
        End If

        Return boolResult
    End Function

    Public Function get_Path_FileSystemObject(ByVal objOItem_FileSystemObject As clsOntologyItem, Optional ByVal boolBlobPath As Boolean = True) As String
        Dim strPath As String = ""

        Dim oList_ObjRel As New List(Of clsObjectRel)
        Dim oList_ObjAtt As New List(Of clsObjectAtt)

        Dim objOitem_Folder As New clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        strSeperator = IO.Path.DirectorySeparatorChar
        boolBlob = False
        objOItem_Share = New clsOntologyItem
        Select Case objOItem_FileSystemObject.GUID_Parent
            Case objLocalConfig.OItem_Type_Server.GUID
                strPath = strSeperator & strSeperator & objOItem_FileSystemObject.Name
                objOItem_Server = objOItem_FileSystemObject

            Case objLocalConfig.OItem_Type_Drive.GUID
                oList_ObjRel.Clear()
                oList_ObjRel.Add(New clsObjectRel(objOItem_FileSystemObject.GUID, _
                                                  Nothing, _
                                                  Nothing, _
                                                  Nothing, _
                                                  Nothing, _
                                                  Nothing, _
                                                  objLocalConfig.OItem_Type_Server.GUID, _
                                                  Nothing, _
                                                  objLocalConfig.OItem_RelationType_isSubordinated.GUID, _
                                                  Nothing, _
                                                  objLocalConfig.Globals.Type_Object, _
                                                  Nothing, _
                                                  Nothing, _
                                                  Nothing))


                objDBLevel_FSO.get_Data_ObjectRel(oList_ObjRel, _
                                                  False, _
                                                  False)

                If objDBLevel_FSO.OList_ObjectRel.Count > 0 Then
                    objOItem_Server = New clsOntologyItem
                    objOItem_Server.GUID = objDBLevel_FSO.OList_ObjectRel(0).ID_Other
                    objOItem_Server.Name = objDBLevel_FSO.OList_ObjectRel(0).Name_Other
                    objOItem_Server.GUID_Parent = objDBLevel_FSO.OList_ObjectRel(0).ID_Parent_Other
                    objOItem_Server.Type = objLocalConfig.Globals.Type_Object
                Else
                    strPath = objOItem_FileSystemObject.Name & ":"
                    objOItem_Server = Nothing
                End If

            Case objLocalConfig.OItem_type_Folder.GUID
                strPath = objOItem_FileSystemObject.Name
                objOItem_Share.GUID = objOItem_FileSystemObject.GUID
                objDBLevel_Folder.get_Data_Objects_Tree(objLocalConfig.OItem_type_Folder, _
                                                     objLocalConfig.OItem_type_Folder, _
                                                     objLocalConfig.OItem_RelationType_isSubordinated)

                Dim objRel = From obj In objDBLevel_Folder.OList_ObjectTree
                             Where obj.ID_Object_Parent = objOItem_FileSystemObject.GUID

                If objRel.Count > 0 Then

                    strPath = objRel(0).Name_Object & strSeperator & strPath
                    objOitem_Folder.GUID = objRel(0).ID_Object

                    While objOitem_Folder.GUID <> ""
                        objOItem_Share.GUID = objOitem_Folder.GUID
                        objOitem_Folder = get_PathPart(objOitem_Folder.GUID)
                        If objOitem_Folder.Name <> "" Then
                            strPath = objOitem_Folder.Name & strSeperator & strPath
                        End If
                    End While
                End If

                If objOItem_Share.GUID <> "" Then
                    oList_ObjRel.Clear()
                    oList_ObjRel.Add(New clsObjectRel(Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Type_Server.GUID, _
                                                      Nothing, _
                                                      objOItem_Share.GUID, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_RelationType_Fileshare.GUID, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing))



                    objDBLevel_Server.get_Data_ObjectRel(oList_ObjRel, _
                                                         False, _
                                                         False)

                    If objDBLevel_Server.OList_ObjectRel.Count > 0 Then
                        objOItem_Server = New clsOntologyItem
                        objOItem_Server.GUID = objDBLevel_Server.OList_ObjectRel(0).ID_Object
                        objOItem_Server.Name = objDBLevel_Server.OList_ObjectRel(0).Name_Object
                        objOItem_Server.GUID_Parent = objLocalConfig.OItem_Type_Server.GUID
                        objOItem_Server.Type = objLocalConfig.Globals.Type_Object

                        strPath = strSeperator & strSeperator & objOItem_Server.Name & strSeperator & strPath
                    Else
                        oList_ObjRel.Clear()
                        oList_ObjRel.Add(New clsObjectRel(objOItem_Share.GUID, _
                                                          Nothing, _
                                                          Nothing, _
                                                          Nothing, _
                                                          Nothing, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Type_Drive.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_RelationType_isSubordinated.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.Globals.Type_Object, _
                                                          Nothing, _
                                                          Nothing, _
                                                          Nothing))




                        objDBLevel_Drive.get_Data_ObjectRel(oList_ObjRel, _
                                                         False, _
                                                         False)

                        If objDBLevel_Drive.OList_ObjectRel.Count > 0 Then
                            objOItem_Drive = New clsOntologyItem
                            objOItem_Drive.GUID = objDBLevel_Drive.OList_ObjectRel(0).ID_Other
                            objOItem_Drive.Name = objDBLevel_Drive.OList_ObjectRel(0).Name_Other
                            objOItem_Drive.GUID_Parent = objLocalConfig.OItem_Type_Drive.GUID
                            objOItem_Drive.Type = objLocalConfig.Globals.Type_Object

                            If objOItem_Drive.Name.Contains(":") Then
                                strPath = objOItem_Drive.Name & strSeperator & strPath
                            Else
                                strPath = objOItem_Drive.Name & ":" & strSeperator & strPath
                            End If

                        End If
                    End If
                End If

            Case objLocalConfig.OItem_Type_File.GUID
                boolBlob = False
                If boolBlobPath = True Then
                    oList_ObjAtt.Add(New clsObjectAtt(Nothing, _
                                                      objOItem_FileSystemObject.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Attribute_Blob.GUID, _
                                                      Nothing))

                    objOItem_Result = objDBLevel_Blob.get_Data_ObjectAtt(oList_ObjAtt, _
                                                       doCount:=True)

                    If objOItem_Result.Count > 0 Then
                        strPath = objLocalConfig.Globals.Index & "@" & objLocalConfig.Globals.Server & ":" & objOItem_FileSystemObject.GUID
                        boolBlob = True
                    End If
                End If

                If boolBlob = False Then
                    oList_ObjRel.Clear()
                    oList_ObjRel.Add(New clsObjectRel(objOItem_FileSystemObject.GUID, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_type_Folder.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_RelationType_isSubordinated.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing))





                    objDBLevel_Folder.get_Data_ObjectRel(oList_ObjRel, _
                                                         False, _
                                                         False)
                    strPath = objOItem_FileSystemObject.Name
                    If objDBLevel_Folder.OList_ObjectRel_ID.Count > 0 Then
                        strPath = objDBLevel_Folder.OList_ObjectRel(0).Name_Other & strSeperator & strPath
                        objDBLevel_Folder.get_Data_Objects_Tree(objLocalConfig.OItem_type_Folder, _
                                                         objLocalConfig.OItem_type_Folder, _
                                                         objLocalConfig.OItem_RelationType_isSubordinated)

                        Dim objRel = From obj In objDBLevel_Folder.OList_ObjectTree
                                     Join objChild In objDBLevel_Folder.OList_ObjectRel_ID On objChild.ID_Other Equals obj.ID_Object_Parent

                        If objRel.Count > 0 Then

                            strPath = objRel(0).obj.Name_Object & strSeperator & strPath
                            objOitem_Folder.GUID = objRel(0).obj.ID_Object

                            While objOitem_Folder.GUID <> ""
                                objOItem_Share.GUID = objOitem_Folder.GUID
                                objOitem_Folder = get_PathPart(objOitem_Folder.GUID)
                                If objOitem_Folder.Name <> "" Then
                                    strPath = objOitem_Folder.Name & strSeperator & strPath
                                End If
                            End While
                        End If

                        If objOItem_Share.GUID <> "" Then
                            oList_ObjRel.Clear()
                            oList_ObjRel.Add(New clsObjectRel(Nothing, _
                                             Nothing, _
                                             objLocalConfig.OItem_Type_Server.GUID, _
                                             Nothing, _
                                             objOItem_Share.GUID, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             objLocalConfig.OItem_RelationType_Fileshare.GUID, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing))

                            objDBLevel_Server.get_Data_ObjectRel(oList_ObjRel, _
                                                                 False, _
                                                                 False)

                            If objDBLevel_Server.OList_ObjectRel.Count > 0 Then
                                objOItem_Server = New clsOntologyItem
                                objOItem_Server.GUID = objDBLevel_Server.OList_ObjectRel(0).ID_Object
                                objOItem_Server.Name = objDBLevel_Server.OList_ObjectRel(0).Name_Object
                                objOItem_Server.GUID_Parent = objLocalConfig.OItem_Type_Server.GUID
                                objOItem_Server.Type = objLocalConfig.Globals.Type_Object

                                strPath = strSeperator & strSeperator & objOItem_Server.Name & IO.Path.DirectorySeparatorChar & strPath
                            Else
                                oList_ObjRel.Clear()
                                oList_ObjRel.Add(New clsObjectRel(objOItem_Share.GUID, _
                                                                  Nothing, _
                                                                  Nothing, _
                                                                  Nothing, _
                                                                  Nothing, _
                                                                  Nothing, _
                                                                  objLocalConfig.OItem_Type_Drive.GUID, _
                                                                  Nothing, _
                                                                  objLocalConfig.OItem_RelationType_isSubordinated.GUID, _
                                                                  Nothing, _
                                                                  objLocalConfig.Globals.Type_Object, _
                                                                  Nothing, _
                                                                  Nothing, _
                                                                  Nothing))

                                objDBLevel_Drive.get_Data_ObjectRel(oList_ObjRel, _
                                                                 False, _
                                                                 False)

                                If objDBLevel_Drive.OList_ObjectRel.Count > 0 Then
                                    objOItem_Drive = New clsOntologyItem
                                    objOItem_Drive.GUID = objDBLevel_Drive.OList_ObjectRel(0).ID_Other
                                    objOItem_Drive.Name = objDBLevel_Drive.OList_ObjectRel(0).Name_Other
                                    objOItem_Drive.GUID_Parent = objLocalConfig.OItem_Type_Drive.GUID
                                    objOItem_Drive.Type = objLocalConfig.Globals.Type_Object

                                    strPath = objOItem_Drive.Name & ":\" & strPath
                                End If
                            End If
                        End If

                    End If
                End If



        End Select

        Return strPath
    End Function

    Private Function get_PathPart(ByVal strID_Folder As String) As clsOntologyItem
        Dim objRel = From obj In objDBLevel_Folder.OList_ObjectTree
                                    Where (obj.ID_Object_Parent = strID_Folder)

        Dim objOItem_PathPart As New clsOntologyItem

        If objRel.Count > 0 Then
            objOItem_PathPart.Name = objRel(0).Name_Object
            objOItem_PathPart.GUID = objRel(0).ID_Object
        End If

        Return objOItem_PathPart
    End Function

    Public Function merge_paths(ByVal strPath1 As String, ByVal strPath2 As String) As String
        Dim strPath As String


        If strPath1.EndsWith(IO.Path.PathSeparator) Then
            If strPath2.StartsWith(IO.Path.PathSeparator) Then
                strPath = strPath1 & strPath2.Substring(1)
            Else
                strPath = strPath1 & strPath2
            End If
        Else
            If strPath2.StartsWith(IO.Path.PathSeparator) Then
                strPath = strPath1 & strPath2
            Else
                strPath = strPath1 & IO.Path.PathSeparator & strPath2
            End If
        End If

        Return strPath
    End Function

    Public Sub New(ByVal Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)

        set_DBConnection()
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()

    End Sub

    Private Sub set_DBConnection()
        objShellWork = New clsShellWork()
        objDBLevel_FSO = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Folder = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Server = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Drive = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Blob = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
