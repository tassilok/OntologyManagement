Imports Ontolog_Module
Public Class clsTransaction_Bookmarks
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Bookmarks As clsDBLevel

    Private objOItem_Bookmark As clsOntologyItem

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


    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Bookmarks = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
