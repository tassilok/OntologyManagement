Imports Ontolog_Module
Public Class clsDataWork_MediaItem
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_MediaItems As clsDBLevel
    Private objDBLevel_Files As clsDBLevel
    Private objDBLevel_BookMarks As clsDBLevel
    Private objDBLevel_Created As clsDBLevel
    Private objDBLevel_MediaItemsOfFiles As clsDBLevel

    Private dtblT_MediaItems As New DataSet_MediaItems.dtbl_MediaItemsDataTable

    Private boolLoaded As Boolean

    Private objOItem_Ref As clsOntologyItem

    Private objThread_MediaItems As Threading.Thread

    Public ReadOnly Property Loaded As Boolean
        Get
            Return boolLoaded
        End Get
    End Property

    Public ReadOnly Property dtbl_MediaItems As DataSet_MediaItems.dtbl_MediaItemsDataTable
        Get
            Return dtblT_MediaItems
        End Get
    End Property

    Public Function GetMediaItemOfFile(OItem_File As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_MediaItem As clsOntologyItem
        Dim objOList_MediaItemToFile As New List(Of clsObjectRel)

        objOList_MediaItemToFile.Add(New clsObjectRel(Nothing, _
                                                      objLocalConfig.OItem_Type_Media_Item.GUID, _
                                                      OItem_File.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_RelationType_belonging_Source.GUID,
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing))


        objOItem_Result = objDBLevel_MediaItemsOfFiles.get_Data_ObjectRel(objOList_MediaItemToFile, _
                                                                          boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_MediaItemsOfFiles.OList_ObjectRel.Any() Then
                objOItem_MediaItem = New clsOntologyItem(objDBLevel_MediaItemsOfFiles.OList_ObjectRel.First().ID_Object, _
                                                         objDBLevel_MediaItemsOfFiles.OList_ObjectRel.First().ID_Other, _
                                                         objDBLevel_MediaItemsOfFiles.OList_ObjectRel.First().ID_Parent_Other, _
                                                         objLocalConfig.Globals.Type_Object)


            Else
                objOItem_MediaItem = Nothing
            End If
        Else
            objOItem_MediaItem = Nothing
        End If

        Return objOItem_MediaItem
    End Function

    Public Function GetNextOrderIDOFRef(OItem_Ref As clsOntologyItem) As Long
        Dim lngOrderID As Long
        Dim objOItem_MediaItem As clsOntologyItem

        objOItem_MediaItem = New clsOntologyItem
        objOItem_MediaItem.GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID
        objOItem_MediaItem.Type = objLocalConfig.Globals.Type_Object

        lngOrderID = objDBLevel_MediaItems.get_Data_Rel_OrderID(objOItem_MediaItem, OItem_Ref, objLocalConfig.OItem_RelationType_belonging_Source, False)

        Return lngOrderID
    End Function

    Public Sub get_MediaItems(ByVal OItem_Ref As clsOntologyItem)
        objOItem_Ref = OItem_Ref
        dtblT_MediaItems.Clear()
        boolLoaded = False
        Try
            objThread_MediaItems.Abort()
        Catch ex As Exception

        End Try

        If Not objOItem_Ref Is Nothing Then
            objThread_MediaItems = New Threading.Thread(AddressOf get_MediaItems_Thread)
            objThread_MediaItems.Start()
        Else
            boolLoaded = True
        End If
    End Sub

    Private Sub get_MediaItems_Thread()
        Dim objOL_MediaItems_To_Ref As New List(Of clsObjectRel)
        Dim objOL_MediaItems_To_File As New List(Of clsObjectRel)
        Dim objOL_Bookmarks_To_MediaItems As New List(Of clsObjectRel)

        Dim objOL_CreationDate As New List(Of clsObjectAtt)

        Dim objRandom As New Random

        objOL_MediaItems_To_Ref.Add(New clsObjectRel(Nothing, _
                                                 Nothing, _
                                                 objLocalConfig.OItem_Type_Media_Item.GUID, _
                                                 Nothing, _
                                                 objOItem_Ref.GUID, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing))

        objDBLevel_MediaItems.get_Data_ObjectRel(objOL_MediaItems_To_Ref, _
                                                 boolIDs:=False)

        objOL_MediaItems_To_File.Add(New clsObjectRel(Nothing, _
                                                  Nothing, _
                                                  objLocalConfig.OItem_Type_Media_Item.GUID, _
                                                  Nothing, _
                                                  Nothing, _
                                                  Nothing, _
                                                  objLocalConfig.OItem_Type_File.GUID, _
                                                  Nothing, _
                                                  objLocalConfig.OItem_RelationType_belonging_Source.GUID, _
                                                  Nothing, _
                                                  objLocalConfig.Globals.Type_Object, _
                                                  Nothing, _
                                                  Nothing, _
                                                  Nothing))

        objDBLevel_Files.get_Data_ObjectRel(objOL_MediaItems_To_File, _
                                            boolIDs:=False)

        objOL_Bookmarks_To_MediaItems.Add(New clsObjectRel(Nothing, _
                                                           Nothing, _
                                                           objLocalConfig.OItem_Type_Media_Item_Bookmark.GUID, _
                                                           Nothing, _
                                                           Nothing, _
                                                           Nothing, _
                                                           objLocalConfig.OItem_Type_Media_Item.GUID, _
                                                           Nothing, _
                                                           objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                           Nothing, _
                                                           objLocalConfig.Globals.Type_Object, _
                                                           Nothing, _
                                                           Nothing, _
                                                           Nothing))

        objDBLevel_BookMarks.get_Data_ObjectRel(objOL_Bookmarks_To_MediaItems)



        objOL_CreationDate.Add(New clsObjectAtt(Nothing, _
                                                Nothing, _
                                                objLocalConfig.OItem_Type_File.GUID, _
                                                objLocalConfig.OItem_Attribute_Datetimestamp__Create_.GUID, _
                                                Nothing))

        objDBLevel_Created.get_Data_ObjectAtt(objOL_CreationDate)

        Dim objLMediaItems = From objMediaItem In objDBLevel_MediaItems.OList_ObjectRel
                             Join objFile In objDBLevel_Files.OList_ObjectRel On objFile.ID_Object Equals objMediaItem.ID_Object
                             Group Join objAttrib In objDBLevel_Created.OList_ObjectAtt On objAttrib.ID_Object Equals objFile.ID_Other Into objAttribs = Group
                             From objAttrib In objAttribs.DefaultIfEmpty
                             Group Join objBookmark In objDBLevel_BookMarks.OList_ObjectRel_ID On objBookmark.ID_Other Equals objMediaItem.ID_Object Into Count_Bookmarks = Count()
                             Order By objMediaItem.OrderID

        For Each objMediaItem In objLMediaItems
            If objMediaItem.objAttrib Is Nothing Then
                dtblT_MediaItems.Rows.Add(objMediaItem.objMediaItem.OrderID, _
                                          objMediaItem.objMediaItem.ID_Object, _
                                          objMediaItem.objMediaItem.Name_Object, _
                                          Nothing, _
                                          objMediaItem.objFile.ID_Other, _
                                          objMediaItem.objFile.Name_Other, _
                                          objRandom.Next(), _
                                          objMediaItem.Count_Bookmarks)

            Else
                dtblT_MediaItems.Rows.Add(objMediaItem.objMediaItem.OrderID, _
                                          objMediaItem.objMediaItem.ID_Object, _
                                          objMediaItem.objMediaItem.Name_Object, _
                                          objMediaItem.objAttrib.Val_Date, _
                                          objMediaItem.objFile.ID_Other, _
                                          objMediaItem.objFile.Name_Other, _
                                          objRandom.Next(), _
                                          objMediaItem.Count_Bookmarks)
            End If
        Next

        boolLoaded = True
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
        initialize()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)

        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Created = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Files = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_MediaItems = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BookMarks = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_MediaItemsOfFiles = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
