Imports Ontolog_Module
Imports System.Security
Public Class clsBlobConnection
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Blobs As clsDBLevel
    Private objDataWork As clsDataWork

    Private objTransaction_Files As clsTransaction_Files

    Private objStream_Read As IO.Stream
    Private byteFile() As Byte
    Private strHash_File As String
    Private strPath_Blob As String
    Private boolBlobActive As Boolean

    Public ReadOnly Property Path_Blob As String
        Get
            Return strPath_Blob
        End Get
    End Property
    Public ReadOnly Property BlobActive As Boolean
        Get
            Return boolBlobActive
        End Get
    End Property

    Private Sub get_BlobPath()
        Dim objLPath As New List(Of clsObjectRel)

        objLPath.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                      Nothing, _
                                      Nothing, _
                                      Nothing, _
                                      Nothing, _
                                      Nothing, _
                                      objLocalConfig.OItem_Type_Path.GUID, _
                                      Nothing, _
                                      objLocalConfig.OItem_RelationType_belonging_source.GUID, _
                                      Nothing, _
                                      objLocalConfig.Globals.Type_Object, _
                                      Nothing, _
                                      Nothing, _
                                      Nothing))

        objDBLevel_Blobs.get_Data_ObjectRel(objLPath, _
                                            boolIDs:=False)

        If objDBLevel_Blobs.OList_ObjectRel.Count > 0 Then
            strPath_Blob = objDBLevel_Blobs.OList_ObjectRel(0).Name_Other
            boolBlobActive = True
        Else
            boolBlobActive = False
        End If


    End Sub

    Public Function compute_Hashes() As clsOntologyItem
        Dim objOLFiles As New List(Of clsOntologyItem)
        Dim objOList_ObjAtt As New List(Of clsObjectAtt)
        Dim objOList_ObjAtt_Del As New List(Of clsObjectAtt)
        Dim objOItem_File As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim strPath As String
        Dim strHash As String
        Dim lngToDo As Long
        Dim lngDone As Long
        Dim intCount As Integer

        objOLFiles.Add(New clsOntologyItem(Nothing, _
                                           Nothing, _
                                           objLocalConfig.OItem_Type_File.GUID, _
                                           objLocalConfig.Globals.Type_Object))

        objDBLevel_Blobs.get_Data_Objects(objOLFiles)

        lngToDo = objDBLevel_Blobs.OList_Objects.Count
        lngDone = 0
        intCount = 0

        objOItem_Result = objLocalConfig.Globals.LState_Success

        For Each objOItem_File In objDBLevel_Blobs.OList_Objects
            strPath = strPath_Blob & IO.Path.DirectorySeparatorChar & objOItem_File.GUID

            If IO.File.Exists(strPath) Then
                strHash = get_Hash_Of_File(strPath)



                objOList_ObjAtt.Add(New clsObjectAtt(Nothing, _
                                                     objOItem_File.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_Type_File.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_Attribute_Hash.GUID, _
                                                     Nothing, _
                                                     Nothing, _
                                                     strHash, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     strHash, _
                                                     objLocalConfig.Globals.DType_String.GUID))

                objOList_ObjAtt_Del.Add(New clsObjectAtt(Nothing, _
                                                     objOItem_File.GUID, _
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
                                                     Nothing, _
                                                     objLocalConfig.Globals.DType_String.GUID))


                If intCount = 10000 Then
                    objOItem_Result = objDBLevel_Blobs.del_ObjectAtt(objOList_ObjAtt_Del)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objDBLevel_Blobs.save_ObjAtt(objOList_ObjAtt)
                        lngDone = lngDone + objOList_ObjAtt.Count
                        objOList_ObjAtt.Clear()
                        objOList_ObjAtt_Del.Clear()
                        intCount = 0
                    Else
                        Exit For
                    End If
                    
                End If
                intCount = intCount + 1
            End If


        Next

        If objOList_ObjAtt.Count > 0 Then
            objOItem_Result = objDBLevel_Blobs.del_ObjectAtt(objOList_ObjAtt_del)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objDBLevel_Blobs.save_ObjAtt(objOList_ObjAtt)
                lngDone = lngDone + objOList_ObjAtt.Count
            End If
            

        End If

        objOItem_Result.Val_Long = lngToDo - lngDone

        Return objOItem_Result
    End Function

    Public Function save_File_To_Blob(ByVal objOItem_File As clsOntologyItem, ByVal strPath_File As String) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objStream_Read As IO.Stream
        Dim objStream_Write As IO.Stream
        Dim objFileInfo As IO.FileInfo
        Dim strHash As String
        Dim strPath_File_DST As String
        Dim strPath_File_TMP As String
        Dim strPath_File_Del As String
        objOItem_Result = objLocalConfig.Globals.LState_Success

        If boolBlobActive = True Then
            strHash = get_Hash_Of_File(strPath_File)
            objOItem_Result = get_File_Of_Hash(strHash)
            If objOItem_Result Is Nothing Then
                strPath_File_DST = strPath_Blob & IO.Path.DirectorySeparatorChar & objOItem_File.GUID
                If IO.File.Exists(strPath_File_DST) Then
                    strPath_File_TMP = strPath_File_DST & ".tmp"
                    strPath_File_Del = strPath_File_DST & ".del"

                    Try
                        objFileInfo = New IO.FileInfo(strPath_File)

                        IO.File.Move(strPath_File_DST, strPath_File_Del)
                        objStream_Read = New IO.FileStream(strPath_File, IO.FileMode.Open)
                        objStream_Write = New IO.FileStream(strPath_File_TMP, IO.FileMode.Create)
                        objStream_Read.CopyTo(objStream_Write)
                        IO.File.Move(strPath_File_TMP, strPath_File_DST)

                        objOItem_Result = objTransaction_Files.save_003_File__CreationDate(objFileInfo.CreationTime, objOItem_File)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objOItem_Result = objTransaction_Files.save_004_File__Blob(True, objOItem_File)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                IO.File.Delete(strPath_File_Del)
                            Else

                                IO.File.Delete(strPath_File_DST)
                                IO.File.Move(strPath_File_Del, strPath_File_DST)

                            End If
                        Else
                            IO.File.Delete(strPath_File_DST)
                            IO.File.Move(strPath_File_Del, strPath_File_DST)
                        End If
                    Catch ex As Exception
                        objOItem_Result = objLocalConfig.Globals.LState_Error
                    End Try
                Else
                    strPath_File_TMP = ""
                    objOItem_Result = objLocalConfig.Globals.LState_Success

                    Try
                        objFileInfo = New IO.FileInfo(strPath_File)
                        objStream_Read = New IO.FileStream(strPath_File, IO.FileMode.Open)
                        objStream_Write = New IO.FileStream(strPath_File_DST, IO.FileMode.Create)
                        objStream_Read.CopyTo(objStream_Write)

                        objOItem_Result = objTransaction_Files.save_003_File__CreationDate(objFileInfo.CreationTime, objOItem_File)
                        objOItem_Result = objTransaction_Files.save_004_File__Blob(True, objOItem_File)


                    Catch ex As Exception
                        objOItem_Result = objLocalConfig.Globals.LState_Error
                    End Try
                End If

            End If
            


        Else

            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If



        Return objOItem_Result
    End Function
    Public Function get_BlobSTream(ByVal objOItem_File As clsOntologyItem) As IO.Stream
        Dim objOItem_Result As clsOntologyItem

        Dim strPath_File_SRC As String
        objOItem_Result = objLocalConfig.Globals.LState_Error

        If boolBlobActive = True Then
            strPath_File_SRC = strPath_Blob & IO.Path.DirectorySeparatorChar & objOItem_File.GUID

            Try
                objStream_Read = New IO.FileStream(strPath_File_SRC, IO.FileMode.Open)


            Catch ex As Exception
                objStream_Read = Nothing
            End Try
        Else
            objStream_Read = Nothing
        End If


        Return objStream_Read
    End Function

    Public Sub close_BlobStream()
        Try
            objStream_Read.Close()
        Catch ex As Exception

        End Try

    End Sub

    Public Function save_Blob_To_File(ByVal objOItem_File As clsOntologyItem, ByVal strPath_File As String) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objStream_Read As IO.Stream
        Dim objStream_Write As IO.Stream
        Dim strPath_File_SRC As String
        objOItem_Result = objLocalConfig.Globals.LState_Error

        If boolBlobActive = True Then
            strPath_File_SRC = strPath_Blob & IO.Path.DirectorySeparatorChar & objOItem_File.GUID

            If IO.File.Exists(strPath_File) Then
                objOItem_Result = objLocalConfig.Globals.LState_Relation
            Else
                Try
                    objStream_Write = New IO.FileStream(strPath_File, IO.FileMode.CreateNew)
                    objStream_Read = New IO.FileStream(strPath_File_SRC, IO.FileMode.Open)
                    objStream_Read.CopyTo(objStream_Write)
                    objStream_Write.Flush()
                    objStream_Write.Close()
                    objStream_Read.Close()
                    objOItem_Result = objLocalConfig.Globals.LState_Success

                Catch ex As Exception
                    objOItem_Result = objLocalConfig.Globals.LState_Error
                End Try
                
            End If
            
        End If

        Return objOItem_Result
    End Function

    Private Function get_File_Of_Hash(ByVal strHash As String) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLObjectAtt As New List(Of clsObjectAtt)

        objOLObjectAtt.Add(New clsObjectAtt(Nothing, _
                                            Nothing, _
                                            Nothing, _
                                            objLocalConfig.OItem_Type_File.GUID, _
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
                                            objLocalConfig.Globals.DType_String.Name))

        objDBLevel_Blobs.get_Data_ObjectAtt(objOLObjectAtt)

        If objDBLevel_Blobs.OList_ObjectAtt_ID.Count > 0 Then
            objOItem_Result = New clsOntologyItem
            objOItem_Result.GUID = objDBLevel_Blobs.OList_ObjectAtt_ID(0).ID_Object
            objOItem_Result.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
            objOItem_Result.Type = objLocalConfig.Globals.Type_Object
        Else
            objOItem_Result = Nothing
        End If


        Return objOItem_Result
    End Function

    Private Function get_Hash_Of_File(ByVal strPath As String) As String
        Dim objOItem_Result As clsOntologyItem
        Dim objFileStream As New IO.FileStream(strPath, IO.FileMode.Open, IO.FileAccess.Read)
        Dim objMD5 As System.Security.Cryptography.MD5 = New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim byteMD5() As Byte
        Dim strHash As String
        Dim l As Long

        objOItem_Result = objLocalConfig.Globals.LState_Success

        objMD5 = New Security.Cryptography.MD5CryptoServiceProvider
        byteMD5 = objMD5.ComputeHash(objFileStream)
        objFileStream.Close()

        strHash = BitConverter.ToString(byteMD5).Replace("-", "")

        Return strHash
    End Function

    Private Function get_Hash_Of_DBFile(ByVal objOItem_File As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLObjectAtt As New List(Of clsObjectAtt)

        objOLObjectAtt.Add(New clsObjectAtt(Nothing, _
                                            objOItem_File.GUID, _
                                            objLocalConfig.OItem_Attribute_Hash.GUID, _
                                            Nothing, _
                                            Nothing))

        objDBLevel_Blobs.get_Data_ObjectAtt(objOLObjectAtt, _
                                            boolIDs:=False)

        If objDBLevel_Blobs.OList_ObjectAtt.Count > 0 Then
            objOItem_Result = objLocalConfig.Globals.LState_Success
            objOItem_Result.Additional1 = objDBLevel_Blobs.OList_ObjectAtt(0).Val_String
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Nothing
        End If

        Return objOItem_Result
    End Function

    Public Function compare_Files(ByVal strFilePath_SRC As String, ByVal strFilePath_DST As String) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim strHash_SRC As String
        Dim strHash_DST As String

        strHash_SRC = get_Hash_Of_File(strFilePath_SRC)

        strHash_DST = get_Hash_Of_File(strFilePath_DST)

        If strHash_SRC <> strHash_DST Then
            objOItem_Result = objLocalConfig.Globals.LState_Update
            objOItem_Result.Additional1 = strHash_SRC
            objOItem_Result.Additional2 = strHash_DST
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Success
            objOItem_Result.Additional1 = strHash_SRC
            objOItem_Result.Additional2 = strHash_DST
        End If

        Return objOItem_Result
    End Function

    Public Sub New()
        objLocalConfig = New clsLocalConfig(New clsGlobals)

        set_DBConnection()
        initialize()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)

        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        get_BlobPath()
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
        initialize()
    End Sub

    Private Sub set_DBConnection()
        objDataWork = New clsDataWork(objLocalConfig)
        objDBLevel_Blobs = New clsDBLevel(objLocalConfig.Globals)
        objTransaction_Files = New clsTransaction_Files(objLocalConfig)
    End Sub
End Class
