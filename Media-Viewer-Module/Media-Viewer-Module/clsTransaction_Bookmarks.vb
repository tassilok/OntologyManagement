Imports Ontolog_Module

Public Class clsTransaction_Bookmarks
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Bookmarks As clsDBLevel


    Private objOItem_Bookmark As clsOntologyItem
    Private objOAItem_Position As clsObjectAtt
    Private objOItem_LogEntry As clsOntologyItem
    Private objOItem_MediaItem As clsOntologyItem

    Public ReadOnly Property OItem_LogEntry As clsOntologyItem
        Get
            Return objOItem_LogEntry
        End Get
    End Property

    Public Function save_001_Bookmark(ByVal OItem_Bookmark As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBookmarks As New List(Of clsOntologyItem)

        objOItem_Bookmark = OItem_Bookmark

        objOLBookmarks.Add(objOItem_Bookmark)

        objOItem_Result = objDBLevel_Bookmarks.save_Objects(objOLBookmarks)

        Return objOItem_Result
    End Function

    Public Function del_001_Bookmark(Optional ByVal OItem_Bookmark As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBookmarks As New List(Of clsOntologyItem)
        Dim strIDs() As String

        If Not OItem_Bookmark Is Nothing Then
            objOItem_Bookmark = OItem_Bookmark
        End If

        objOLBookmarks.Add(objOItem_Bookmark)

        strIDs = objDBLevel_Bookmarks.del_Objects(objOLBookmarks)

        If strIDs.Count = 1 Then
            objOItem_Result = objLocalConfig.Globals.LState_Success
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If
        
        Return objOItem_Result
    End Function

    Public Function save_002_BookMark__Position(ByVal strPosition As String, Optional ByVal OItem_Bookmark As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOAItem_Position_Search As clsObjectAtt
        Dim objOLItem_Position As New List(Of clsObjectAtt)
        Dim objOL_Position_Del As New List(Of clsObjectAtt)

        If Not OItem_Bookmark Is Nothing Then
            objOItem_Bookmark = OItem_Bookmark
        End If

        objOAItem_Position = New clsObjectAtt(Nothing, _
                                              objOItem_Bookmark.GUID, _
                                              Nothing, _
                                              objOItem_Bookmark.GUID_Parent, _
                                              Nothing, _
                                              objLocalConfig.OItem_Attribute_Media_Position.GUID, _
                                              Nothing, _
                                              1, _
                                              strPosition, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              strPosition, _
                                              objLocalConfig.Globals.DType_String.GUID)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objOAItem_Position_Search = New clsObjectAtt(Nothing, _
                                                     objOItem_Bookmark.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_Attribute_Media_Position.GUID, _
                                                     Nothing)

        objOLItem_Position.Add(objOAItem_Position_Search)

        objDBLevel_Bookmarks.get_Data_ObjectAtt(objOLItem_Position, _
                                                boolIDs:=False)

        For Each objOAItem_Position_Search In objDBLevel_Bookmarks.OList_ObjectAtt
            If objOAItem_Position_Search.Val_String = objOAItem_Position.Val_String Then
                objOItem_Result = objLocalConfig.Globals.LState_Success
            Else
                objOL_Position_Del.Clear()
                objOL_Position_Del.Add(objOAItem_Position_Search)
                objOItem_Result = objDBLevel_Bookmarks.del_ObjectAtt(objOL_Position_Del)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    Exit For
                End If
            End If
        Next

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOLItem_Position.Clear()
            objOLItem_Position.Add(objOAItem_Position)
            objOItem_Result = objDBLevel_Bookmarks.save_ObjAtt(objOLItem_Position)
        End If

        Return objOItem_Result
    End Function

    Public Function del_002_BookMark__Position(Optional ByVal OItem_Bookmark As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOAItem_Position_Search As clsObjectAtt
        Dim objOL_Position_Del As New List(Of clsObjectAtt)

        If Not OItem_Bookmark Is Nothing Then
            objOItem_Bookmark = OItem_Bookmark
        End If

        objOAItem_Position_Search = New clsObjectAtt(Nothing, _
                                                     objOItem_Bookmark.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_Attribute_Media_Position.GUID, _
                                                     Nothing)

        objOL_Position_Del.Add(objOAItem_Position_Search)

        objOItem_Result = objDBLevel_Bookmarks.del_ObjectAtt(objOL_Position_Del)

        Return objOItem_Result
    End Function

    Public Function save_003_BookMark_To_LogEntry(ByVal OItem_LogEntry As clsOntologyItem, Optional ByVal OItem_Bookmark As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objORel_BookMark_To_Logentry As New clsObjectRel
        Dim objOLBookMark_To_LogEntry As New List(Of clsObjectRel)
        Dim objOLBookMark_To_LogEntry_Search As New List(Of clsObjectRel)
        Dim objOLBookMark_To_LogEntry_Del As New List(Of clsObjectRel)

        objOItem_LogEntry = OItem_LogEntry

        If Not OItem_Bookmark Is Nothing Then
            objOItem_Bookmark = OItem_Bookmark
        End If

        objOLBookMark_To_LogEntry.Add(New clsObjectRel(objOItem_Bookmark.GUID, _
                                                       objOItem_Bookmark.GUID_Parent, _
                                                       objOItem_LogEntry.GUID, _
                                                       objOItem_LogEntry.GUID_Parent, _
                                                       objLocalConfig.OItem_RelationType_belonging_Done.GUID, _
                                                       objLocalConfig.Globals.Type_Object, _
                                                       Nothing, _
                                                       1))

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objOLBookMark_To_LogEntry_Search.Add(New clsObjectRel(objOItem_Bookmark.GUID, _
                                                              Nothing, _
                                                              Nothing, _
                                                              objLocalConfig.OItem_Type_LogEntry.GUID, _
                                                              objLocalConfig.OItem_RelationType_belonging_Done.GUID, _
                                                              objLocalConfig.Globals.Type_Object, _
                                                              Nothing, _
                                                              Nothing))

        objDBLevel_Bookmarks.get_Data_ObjectRel(objOLBookMark_To_LogEntry_Search)

        For Each objORel_BookMark_To_Logentry In objDBLevel_Bookmarks.OList_ObjectRel_ID
            If objORel_BookMark_To_Logentry.ID_Other = objOItem_Bookmark.GUID Then
                objOItem_Result = objLocalConfig.Globals.LState_Success
            Else
                objOLBookMark_To_LogEntry_Del.Add(objORel_BookMark_To_Logentry)
                objOItem_Result = objDBLevel_Bookmarks.del_ObjectRel(objOLBookMark_To_LogEntry_Del)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    Exit For
                End If
            End If
        Next

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOItem_Result = objDBLevel_Bookmarks.save_ObjRel(objOLBookMark_To_LogEntry)
        End If

        Return objOItem_Result
    End Function

    Public Function del_003_BookMark_To_LogEntry(Optional ByVal OItem_Bookmark As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBookMark_To_LogEntry As New List(Of clsObjectRel)

        If Not OItem_Bookmark Is Nothing Then
            objOItem_Bookmark = OItem_Bookmark
        End If

        objOLBookMark_To_LogEntry.Add(New clsObjectRel(objOItem_Bookmark.GUID, _
                                                       Nothing, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Type_LogEntry.GUID, _
                                                       objLocalConfig.OItem_RelationType_belonging_Done.GUID, _
                                                       objLocalConfig.Globals.Type_Object, _
                                                       Nothing, _
                                                       Nothing))

        objOItem_Result = objDBLevel_Bookmarks.del_ObjectRel(objOLBookMark_To_LogEntry)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOItem_Result = objLocalConfig.Globals.LState_Success
        End If

        Return objOItem_Result
    End Function

    Public Function save_004_BookMark_To_MediaItem(ByVal OItem_MediaItem As clsOntologyItem, Optional ByVal OItem_BookMark As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBookMark_To_MediaItem As New List(Of clsObjectRel)

        objOItem_MediaItem = OItem_MediaItem
        If Not OItem_BookMark Is Nothing Then
            objOItem_Bookmark = OItem_BookMark
        End If

        objOLBookMark_To_MediaItem.Add(New clsObjectRel(objOItem_Bookmark.GUID, _
                                                        objOItem_Bookmark.GUID_Parent, _
                                                        objOItem_MediaItem.GUID, _
                                                        objOItem_MediaItem.GUID_Parent, _
                                                        objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                        objLocalConfig.Globals.Type_Object, _
                                                        Nothing, _
                                                        1))

        objOItem_Result = objDBLevel_Bookmarks.save_ObjRel(objOLBookMark_To_MediaItem)

        Return objOItem_Result
    End Function

    Public Function del_004_BookMark_To_MediaItem(Optional ByVal OItem_MediaItem As clsOntologyItem = Nothing, Optional ByVal OItem_BookMark As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLBookMark_To_MediaItem As New List(Of clsObjectRel)

        If Not OItem_BookMark Is Nothing Then
            objOItem_Bookmark = OItem_BookMark
        End If

        If Not OItem_MediaItem Is Nothing Then
            objOItem_MediaItem = OItem_MediaItem
        End If

        objOLBookMark_To_MediaItem.Add(New clsObjectRel(objOItem_Bookmark.GUID, _
                                                        Nothing, _
                                                        objOItem_MediaItem.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                        objLocalConfig.Globals.Type_Object, _
                                                        Nothing, _
                                                        Nothing))

        objOItem_Result = objDBLevel_Bookmarks.del_ObjectRel(objOLBookMark_To_MediaItem)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOItem_Result = objLocalConfig.Globals.LState_Success
        End If

        Return objOItem_Result
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Bookmarks = New clsDBLevel(objLocalConfig.Globals)

    End Sub
End Class
