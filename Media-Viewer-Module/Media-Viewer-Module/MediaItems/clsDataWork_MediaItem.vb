Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Typed_Tagging_Module

Public Class clsDataWork_MediaItem
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_MediaItems As clsDBLevel
    Private objDBLevel_Files As clsDBLevel
    Private objDBLevel_BookMarks As clsDBLevel
    Private objDBLevel_Created As clsDBLevel
    Private objDBLevel_MediaItemsOfFiles As clsDBLevel
    Private objDBLevel_MedaiItemObjects_MediaItem As clsDBLevel
    Private objDBLevel_MediaItemObjects_Ranges As clsDBLevel
    Private objDBLevel_MediaItemObjects_Is As clsDBLevel
    Private objDBLevel_MediaItemRange_To_Bookmarks As clsDBLevel
    Private objDBLevel_Range As clsDBLevel
    Private objDBLevel_CreationDate As clsDBLevel

    Private objDataWork_Tagged As clsDataWork_Tagging

    Private dtblT_MediaItems As New DataSet_MediaItems.dtbl_MediaItemsDataTable

    Private boolLoaded As Boolean
    Private boolTable As Boolean

    Private objOItem_Ref As clsOntologyItem

    Private objOItem_MediaItem As clsOntologyItem

    Private objThread_MediaItems As Threading.Thread
    Private objLMediaItems As List(Of clsMultiMediaItem) = New List(Of clsMultiMediaItem)

    Private objRelationConfig As clsRelationConfig

    Public Sub AddMediaItemObject(OItem_MediaItemObject As clsOntologyItem, OItem_MediaItem As clsOntologyItem, OItem_Ref As clsOntologyItem)
        objDBLevel_MedaiItemObjects_MediaItem.OList_ObjectRel.Add(objRelationConfig.Rel_ObjectRelation(OItem_MediaItemObject, _
                                                                                                OItem_MediaItem, _
                                                                                                objLocalConfig.OItem_RelationType_located_in))
        objDBLevel_MediaItemObjects_Is.OList_ObjectRel.Add(objRelationConfig.Rel_ObjectRelation(OItem_MediaItemObject, _
                                                                                                OItem_Ref, _
                                                                                                objLocalConfig.OItem_RelationType_is))

    End Sub

    Public Sub RemoveMediaItemObject(OItem_MediaItemObject As clsOntologyItem, OItem_MediaItem As clsOntologyItem, OItem_Ref As clsOntologyItem)
        Dim objOList_MediItemObjects = objDBLevel_MedaiItemObjects_MediaItem.OList_ObjectRel.Where(Function(mi) mi.ID_Object = OItem_MediaItemObject.GUID And _
                                                                                                       mi.ID_Other = OItem_MediaItem.GUID And _
                                                                                                       mi.ID_RelationType = objLocalConfig.OItem_RelationType_located_in.GUID).ToList()
        If objOList_MediItemObjects.Any Then
            For Each objORel In objOList_MediItemObjects
                objDBLevel_MedaiItemObjects_MediaItem.OList_ObjectRel.Remove(objORel)
            Next



        End If


        objOList_MediItemObjects = objDBLevel_MediaItemObjects_Is.OList_ObjectRel.Where(Function(mi) mi.ID_Object = OItem_MediaItemObject.GUID And _
                                                                                                       mi.ID_Other = OItem_Ref.GUID And _
                                                                                                       mi.ID_RelationType = objLocalConfig.OItem_RelationType_is.GUID).ToList()

        If objOList_MediItemObjects.Any Then
            For Each objORel In objOList_MediItemObjects
                objDBLevel_MediaItemObjects_Is.OList_ObjectRel.Remove(objORel)
            Next



        End If
    End Sub
    

    Public ReadOnly Property Loaded As Boolean
        Get
            Return boolLoaded
        End Get
    End Property

    Public ReadOnly Property ItemList As List(Of clsMultiMediaItem)
        Get
            Return objLMediaItems
        End Get
    End Property

    Public ReadOnly Property dtbl_MediaItems As DataSet_MediaItems.dtbl_MediaItemsDataTable
        Get
            Return dtblT_MediaItems
        End Get
    End Property

    Public Function get_MediaItem(OItem_MediaItem As clsOntologyItem) As List(Of clsMultiMediaItem)
        Dim objOL_MediaItems_To_Ref As New List(Of clsObjectRel)
        Dim objOL_MediaItems_To_File As New List(Of clsObjectRel)
        Dim objOL_CreationDate As New List(Of clsObjectAtt)
        If Not OItem_MediaItem Is Nothing Then
            objOL_MediaItems_To_File.Add(New clsObjectRel With {.ID_Object = OItem_MediaItem.GUID, _
                                                        .ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID, _
                                                  .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Source.GUID
                                                  })

            objDBLevel_Files.get_Data_ObjectRel(objOL_MediaItems_To_File, _
                                                boolIDs:=False)

            If objDBLevel_Files.OList_ObjectRel.Any Then
                objOL_CreationDate = objDBLevel_Files.OList_ObjectRel.Select(Function(p) New clsObjectAtt With { _
                                                                             .ID_Object = p.ID_Other, _
                                                                             .ID_AttributeType = objLocalConfig.OItem_Type_Media_Item.GUID _
                                                                         }).ToList

                objDBLevel_CreationDate.get_Data_ObjectAtt(objOL_CreationDate, _
                                                           boolIDs:=False)

                objLMediaItems.Clear()
                objLMediaItems = (From objFile In objDBLevel_Files.OList_ObjectRel
                                 Group Join objDate In objDBLevel_CreationDate.OList_ObjectAtt On objDate.ID_Object Equals objFile.ID_Other Into objDates = Group
                                 From objDate In objDates.DefaultIfEmpty
                                 Select New clsMultiMediaItem(objFile.ID_Object, _
                                                              objFile.Name_Object, _
                                                              objFile.ID_Parent_Object, _
                                                              objFile.ID_Other, _
                                                              objFile.Name_Other, _
                                                              objFile.ID_Parent_Other, _
                                                              objDate, _
                                                              0)).ToList()
            End If

        End If


        Return objLMediaItems
    End Function

    Public Function GetDataObjectsOfMediaItem(OItem_MediaItem As clsOntologyItem) As clsOntologyItem
        objOItem_MediaItem = OItem_MediaItem

        Dim objOList_Search_LeftRight = New List(Of clsObjectRel) From {
            New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_class_media_item_objects.GUID, _
                                   .ID_RelationType = objLocalConfig.OItem_RelationType_located_in.GUID, _
                                   .ID_Other = objOItem_MediaItem.GUID}}


        Dim objOItem_Result = objDBLevel_MedaiItemObjects_MediaItem.get_Data_ObjectRel(objOList_Search_LeftRight, _
                                                                                   boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

            Dim objOList_Search_Is = objDBLevel_MedaiItemObjects_MediaItem.OList_ObjectRel.Select(Function(mi) New clsObjectRel With {.ID_Object = mi.ID_Object, _
                                                                                                                                      .ID_RelationType = objLocalConfig.OItem_RelationType_is.GUID}).ToList()

            If objOList_Search_Is.Any() Then
                objOItem_Result = objDBLevel_MediaItemObjects_Is.get_Data_ObjectRel(objOList_Search_Is, boolIDs:=False)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Dim objORel_MediaItemRange_To_Bookmarks = objDBLevel_MedaiItemObjects_MediaItem.OList_ObjectRel.Select(Function(mi) New clsObjectRel With {.ID_Object = mi.ID_Object, _
                                                                                                                                                               .ID_Parent_Other = objLocalConfig.OItem_Type_Media_Item_Range.GUID, _
                                                                                                                                                               .ID_RelationType = objLocalConfig.OItem_relationtype_belonging.GUID}).ToList()
                    objOItem_Result = objDBLevel_MediaItemObjects_Ranges.get_Data_ObjectRel(objORel_MediaItemRange_To_Bookmarks, boolIDs:=False)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objORel_MediaItemRange_To_Bookmarks = objDBLevel_MediaItemObjects_Ranges.OList_ObjectRel.Select(Function(ra) New clsObjectRel With {.ID_Object = ra.ID_Other, _
                                                                                                                                                            .ID_Parent_Other = objLocalConfig.OItem_Type_Media_Item_Bookmark.GUID, _
                                                                                                                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_started_with.GUID}).ToList

                        objORel_MediaItemRange_To_Bookmarks.AddRange(objDBLevel_MediaItemObjects_Ranges.OList_ObjectRel.Select(Function(ra) New clsObjectRel With {.ID_Object = ra.ID_Other, _
                                                                                                                                                            .ID_Parent_Other = objLocalConfig.OItem_Type_Media_Item_Bookmark.GUID, _
                                                                                                                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_finished_with.GUID}))

                        If objORel_MediaItemRange_To_Bookmarks.Any Then
                            objOItem_Result = objDBLevel_MediaItemRange_To_Bookmarks.get_Data_ObjectRel(objORel_MediaItemRange_To_Bookmarks, boolIDs:=False)

                        End If
                    End If
                    
                    
                End If
            Else
                objDBLevel_MedaiItemObjects_MediaItem.OList_ObjectRel.Clear()
                objDBLevel_MediaItemObjects_Is.OList_ObjectRel.Clear()
                objDBLevel_MediaItemObjects_Ranges.OList_ObjectRel.Clear()
                objDBLevel_MediaItemRange_To_Bookmarks.OList_ObjectRel.Clear()
            End If
            
            

        End If

        Return objOItem_Result
    End Function

    Public Function OList_MediaItemObjects(OItem_MediaItem As clsOntologyItem) As List(Of clsMediaItemObject)
        Dim objOList_MediaItemObjects = objDBLevel_MediaItemObjects_Is.OList_ObjectRel. _
            Select(Function(mi) New clsMediaItemObject With {.ID_MediaItem = OItem_MediaItem.GUID, _
                                                             .Name_MediaItem = OItem_MediaItem.Name, _
                                                             .ID_MediaItemObject = mi.ID_Object, _
                                                             .Name_MediaItemObject = mi.Name_Object, _
                                                             .ID_Ref = mi.ID_Other, _
                                                             .Name_Ref = mi.Name_Other, _
                                                             .ID_Parent_Ref = mi.ID_Parent_Other, _
                                                             .Type_Ref = mi.Ontology}).ToList()



        Return objOList_MediaItemObjects
    End Function

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

        lngOrderID = objDBLevel_MediaItems.get_Data_Rel_OrderID(objOItem_MediaItem, OItem_Ref, objLocalConfig.OItem_RelationType_belongsTo, False)

        Return lngOrderID
    End Function

    Public Function get_MediaItemsSimple(objTreeNode As TreeNode) As List(Of clsMultiMediaItem)
        Dim objORel_RefToMediaItem = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Other = objTreeNode.Name, _
                                                                                             .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                                                             .ID_Parent_Object = objLocalConfig.OItem_Type_Media_Item.GUID}}

        Dim objList_MediaItems = New List(Of clsMultiMediaItem)

        Dim objOItem_Result = objDBLevel_MediaItems.get_Data_ObjectRel(objORel_RefToMediaItem, boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objOrel_MediaItemToFile = objDBLevel_MediaItems.OList_ObjectRel.Select(Function(p) New clsObjectRel With {.ID_Object = p.ID_Object, _
                                                                                                                          .ID_Parent_Object = p.ID_Parent_Object, _
                                                                                                                          .ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID, _
                                                                                                                          .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Source.GUID}).ToList()
            If objOrel_MediaItemToFile.Any Then
                objOItem_Result = objDBLevel_Files.get_Data_ObjectRel(objOrel_MediaItemToFile, boolIDs:=False)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objList_MediaItems = (From objMediaItem In objDBLevel_MediaItems.OList_ObjectRel
                                          Join objFile In objDBLevel_Files.OList_ObjectRel On objMediaItem.ID_Object Equals objFile.ID_Object
                                          Select New clsMultiMediaItem With {.ID_Item = objMediaItem.ID_Object, _
                                                                             .Name_Item = objMediaItem.Name_Object, _
                                                                             .ID_File = objFile.ID_Other, _
                                                                             .Name_File = objFile.Name_Other, _
                                                                             .OrderID = objMediaItem.OrderID}).ToList()

                End If

            End If

        Else
            objList_MediaItems = Nothing
        End If

        Return objList_MediaItems
    End Function

    Public Sub get_MediaItems(ByVal OItem_Ref As clsOntologyItem, Optional boolTable As Boolean = True)
        objOItem_Ref = OItem_Ref
        dtblT_MediaItems.Clear()
        boolLoaded = False
        Me.boolTable = boolTable
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

    Public Sub get_NamedMediaItems(OItem_Ref As clsOntologyItem, Optional boolTable As Boolean = True)
        objOItem_Ref = OItem_Ref
        dtblT_MediaItems.Clear()
        boolLoaded = False
        Me.boolTable = boolTable
        Try
            objThread_MediaItems.Abort()
        Catch ex As Exception

        End Try

        If Not objOItem_Ref Is Nothing Then
            objThread_MediaItems = New Threading.Thread(AddressOf get_NamedMediaItems_Thread)
            objThread_MediaItems.Start()
        Else
            boolLoaded = True
        End If
    End Sub
    Private Sub get_NamedMediaItems_Thread()
        Dim objOL_MediaItems_To_Ref As New List(Of clsObjectRel)
        Dim objOL_MediaItems_To_File As New List(Of clsObjectRel)
        Dim objOL_Bookmarks_To_MediaItems As New List(Of clsObjectRel)

        Dim objOL_CreationDate As New List(Of clsObjectAtt)

        Dim objRandom As New Random

        Dim objOItem_Result = objDataWork_Tagged.GetTagsOfTaggingSource(New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID, .Type = objLocalConfig.Globals.Type_Object})

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objOL_MediaItems = objDataWork_Tagged.TypedTags.Where(Function(t) t.ID_TaggingDest = objOItem_Ref.GUID).ToList()


            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objOL_MediaItems.Any Then
                    If objDBLevel_MediaItems.OList_ObjectRel.Count < 500 Then
                        objOL_MediaItems_To_File = objOL_MediaItems.Select(Function(mi) New clsObjectRel With {.ID_Other = mi.ID_TaggingSource, _
                                                                                                                                    .ID_Parent_Object = objLocalConfig.OItem_Type_File.GUID, _
                                                                                                                                    .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Source.GUID}).ToList()


                    Else
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
                    End If

                    objOItem_Result = objDBLevel_Files.get_Data_ObjectRel(objOL_MediaItems_To_File, _
                                                    boolIDs:=False)

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        If objDBLevel_Files.OList_ObjectRel.Any Then
                            If objDBLevel_Files.OList_ObjectRel.Count < 500 Then
                                objOL_Bookmarks_To_MediaItems = objOL_MediaItems.Select(Function(mi) New clsObjectRel With {.ID_Object = mi.ID_TaggingSource, _
                                                                                                                                        .ID_Parent_Other = objLocalConfig.OItem_Type_Media_Item_Bookmark.GUID, _
                                                                                                                                        .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID}).ToList()
                            Else
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
                            End If


                            objOItem_Result = objDBLevel_BookMarks.get_Data_ObjectRel(objOL_Bookmarks_To_MediaItems)

                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                                If objDBLevel_Files.OList_ObjectRel.Count < 500 Then
                                    objOL_CreationDate = objDBLevel_Files.OList_ObjectRel.Select(Function(f) New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Datetimestamp__Create_.GUID, _
                                                                                                                                    .ID_Object = f.ID_Other}).ToList()

                                Else
                                    objOL_CreationDate.Add(New clsObjectAtt(Nothing, _
                                                                    Nothing, _
                                                                    objLocalConfig.OItem_Type_File.GUID, _
                                                                    objLocalConfig.OItem_Attribute_Datetimestamp__Create_.GUID, _
                                                                    Nothing))
                                End If



                                objOItem_Result = objDBLevel_Created.get_Data_ObjectAtt(objOL_CreationDate, boolIDs:=False)

                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objLMediaItems = (From objMediaItem In objOL_MediaItems
                                                     Join objFile In objDBLevel_Files.OList_ObjectRel On objFile.ID_Object Equals objMediaItem.ID_TaggingSource
                                                     Group Join objAttrib In objDBLevel_Created.OList_ObjectAtt On objAttrib.ID_Object Equals objFile.ID_Other Into objAttribs = Group
                                                     From objAttrib In objAttribs.DefaultIfEmpty
                                                     Group Join objBookmark In objDBLevel_BookMarks.OList_ObjectRel_ID On objBookmark.ID_Other Equals objMediaItem.ID_TaggingSource Into Count_Bookmarks = Count()
                                                     Where Not objMediaItem.ID_TaggingSource Is Nothing _
                                                        And Not objMediaItem.Name_TaggingSource Is Nothing _
                                                        And Not objFile Is Nothing
                                                     Select New clsMultiMediaItem(objMediaItem.ID_TaggingSource, _
                                                                                  objMediaItem.Name_TaggingSource, _
                                                                                  objLocalConfig.OItem_Type_Media_Item.GUID, _
                                                                                  objFile.ID_Other, _
                                                                                  objFile.Name_Other, _
                                                                                  objFile.ID_Parent_Other, _
                                                                                  If(Not objAttrib Is Nothing, objAttrib, Nothing), _
                                                                                  0, _
                                                                                  Count_Bookmarks)).ToList()

                                    If boolTable Then
                                        For Each objMediaItem In objLMediaItems
                                            If objMediaItem.OACreate Is Nothing Then
                                                dtblT_MediaItems.Rows.Add(objMediaItem.OrderID, _
                                                                          objMediaItem.ID_Item, _
                                                                          objMediaItem.Name_Item, _
                                                                          Nothing, _
                                                                          objMediaItem.ID_File, _
                                                                          objMediaItem.Name_File, _
                                                                          objRandom.Next(), _
                                                                          objMediaItem.CountBookMark)

                                            Else
                                                dtblT_MediaItems.Rows.Add(objMediaItem.OrderID, _
                                                                          objMediaItem.ID_Item, _
                                                                          objMediaItem.Name_Item, _
                                                                          objMediaItem.OACreate.Val_Date, _
                                                                          objMediaItem.ID_File, _
                                                                          objMediaItem.Name_File, _
                                                                          objRandom.Next(), _
                                                                          objMediaItem.CountBookMark)
                                            End If
                                        Next
                                    End If
                                End If

                            End If
                        End If
                        


                    End If
                End If

            End If
        End If
        






        boolLoaded = True
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

        Dim objOItem_Result = objDBLevel_MediaItems.get_Data_ObjectRel(objOL_MediaItems_To_Ref, _
                                                 boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_MediaItems.OList_ObjectRel.Any Then
                If objDBLevel_MediaItems.OList_ObjectRel.Count < 500 Then
                    objOL_MediaItems_To_File = objDBLevel_MediaItems.OList_ObjectRel.Select(Function(mi) New clsObjectRel With {.ID_Object = mi.ID_Object, _
                                                                                                                                .ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID, _
                                                                                                                                .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Source.GUID}).ToList()


                Else
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
                End If

                objOItem_Result = objDBLevel_Files.get_Data_ObjectRel(objOL_MediaItems_To_File, _
                                                boolIDs:=False)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDBLevel_Files.OList_ObjectRel.Any Then
                        If objDBLevel_Files.OList_ObjectRel.Count < 500 Then
                            objOL_Bookmarks_To_MediaItems = objDBLevel_MediaItems.OList_ObjectRel.Select(Function(mi) New clsObjectRel With {.ID_Other = mi.ID_Object, _
                                                                                                                                    .ID_Parent_Object = objLocalConfig.OItem_Type_Media_Item_Bookmark.GUID, _
                                                                                                                                    .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID}).ToList()
                        Else
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
                        End If


                        objOItem_Result = objDBLevel_BookMarks.get_Data_ObjectRel(objOL_Bookmarks_To_MediaItems)

                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                            If objDBLevel_Files.OList_ObjectRel.Count < 500 Then
                                objOL_CreationDate = objDBLevel_Files.OList_ObjectRel.Select(Function(f) New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Datetimestamp__Create_.GUID, _
                                                                                                                                .ID_Object = f.ID_Other}).ToList()

                            Else
                                objOL_CreationDate.Add(New clsObjectAtt(Nothing, _
                                                                Nothing, _
                                                                objLocalConfig.OItem_Type_File.GUID, _
                                                                objLocalConfig.OItem_Attribute_Datetimestamp__Create_.GUID, _
                                                                Nothing))
                            End If



                            objOItem_Result = objDBLevel_Created.get_Data_ObjectAtt(objOL_CreationDate, boolIDs:=False)

                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objLMediaItems = (From objMediaItem In objDBLevel_MediaItems.OList_ObjectRel
                                                 Join objFile In objDBLevel_Files.OList_ObjectRel On objFile.ID_Object Equals objMediaItem.ID_Object
                                                 Group Join objAttrib In objDBLevel_Created.OList_ObjectAtt On objAttrib.ID_Object Equals objFile.ID_Other Into objAttribs = Group
                                                 From objAttrib In objAttribs.DefaultIfEmpty
                                                 Group Join objBookmark In objDBLevel_BookMarks.OList_ObjectRel_ID On objBookmark.ID_Other Equals objMediaItem.ID_Object Into Count_Bookmarks = Count()
                                                 Order By objMediaItem.OrderID
                                                 Where Not objMediaItem.ID_Object Is Nothing _
                                                    And Not objMediaItem.Name_Object Is Nothing _
                                                    And Not objMediaItem.ID_Parent_Object Is Nothing _
                                                    And Not objFile Is Nothing
                                                 Select New clsMultiMediaItem(objMediaItem.ID_Object, _
                                                                              objMediaItem.Name_Object, _
                                                                              objMediaItem.ID_Parent_Object, _
                                                                              objFile.ID_Other, _
                                                                              objFile.Name_Other, _
                                                                              objFile.ID_Parent_Other, _
                                                                              If(Not objAttrib Is Nothing, objAttrib, Nothing), _
                                                                              objMediaItem.OrderID, _
                                                                              Count_Bookmarks)).ToList()

                                If boolTable Then
                                    For Each objMediaItem In objLMediaItems
                                        If objMediaItem.OACreate Is Nothing Then
                                            dtblT_MediaItems.Rows.Add(objMediaItem.OrderID, _
                                                                      objMediaItem.ID_Item, _
                                                                      objMediaItem.Name_Item, _
                                                                      Nothing, _
                                                                      objMediaItem.ID_File, _
                                                                      objMediaItem.Name_File, _
                                                                      objRandom.Next(), _
                                                                      objMediaItem.CountBookMark)

                                        Else
                                            dtblT_MediaItems.Rows.Add(objMediaItem.OrderID, _
                                                                      objMediaItem.ID_Item, _
                                                                      objMediaItem.Name_Item, _
                                                                      objMediaItem.OACreate.Val_Date, _
                                                                      objMediaItem.ID_File, _
                                                                      objMediaItem.Name_File, _
                                                                      objRandom.Next(), _
                                                                      objMediaItem.CountBookMark)
                                        End If
                                    Next
                                End If
                            End If

                        End If
                    End If
                    


                End If
            End If
            
        End If
        

        
        


        boolLoaded = True
    End Sub

    Public Function Rel_MediaItem_To_File(OItem_MediaItem As clsOntologyItem, OItem_File As clsOntologyItem) As clsObjectRel
        Dim objOR_MediaItem_To_File = New clsObjectRel With {.ID_Object = OItem_MediaItem.GUID, _
                                                             .ID_Parent_Object = OItem_MediaItem.GUID_Parent, _
                                                             .ID_Other = OItem_File.GUID, _
                                                             .ID_Parent_Other = OItem_File.GUID_Parent, _
                                                             .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Source.GUID, _
                                                             .OrderID = 1, _
                                                             .Ontology = objLocalConfig.Globals.Type_Object}

        Return objOR_MediaItem_To_File
    End Function

    Public Function Rel_MediaItem_To_Ref(OItem_MediaItem As clsOntologyItem, OItem_Ref As clsOntologyItem, Optional boolGetNextOrderID As Boolean = True) As clsObjectRel

        Dim intOrderID = OItem_MediaItem.Level
        If boolGetNextOrderID Then
            intOrderID = objDBLevel_MediaItems.get_Data_Rel_OrderID(New clsOntologyItem With {.GUID_Parent = OItem_MediaItem.GUID_Parent}, OItem_Ref, objLocalConfig.OItem_RelationType_belongsTo, False)
            intOrderID = intOrderID + 1
        End If

        Dim objOR_MediaItem_To_Ref = New clsObjectRel With {.ID_Object = OItem_MediaItem.GUID, _
                                                            .ID_Parent_Object = OItem_MediaItem.GUID_Parent, _
                                                            .ID_Other = OItem_Ref.GUID, _
                                                            .ID_Parent_Other = OItem_Ref.GUID_Parent, _
                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                            .OrderID = intOrderID, _
                                                            .Ontology = OItem_Ref.Type}

        Return objOR_MediaItem_To_Ref
    End Function

    Public Function hasMediaItem(OItem_Ref) As clsOntologyItem
        Dim objOL_MediaItem_To_Ref As New List(Of clsObjectRel)

        objOL_MediaItem_To_Ref.Add(New clsObjectRel(Nothing, _
                                                 Nothing, _
                                                 objLocalConfig.OItem_Type_Media_Item.GUID, _
                                                 Nothing, _
                                                 OItem_Ref.GUID, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing))

        Dim objOItem_Result = objDBLevel_MediaItems.get_Data_ObjectRel(objOL_MediaItem_To_Ref, doCount:=True)


        Return objOItem_Result
    End Function

    Public Function Rel_Bookmark__Position(OItem_Bookmark As clsOntologyItem, strPosition As String) As clsObjectAtt
        Dim objOA_Bookmark__Position As New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Media_Position.GUID, _
                                                               .ID_Object = OItem_Bookmark.GUID, _
                                                               .ID_Class = OItem_Bookmark.GUID_Parent, _
                                                               .ID_DataType = objLocalConfig.Globals.DType_String.GUID, _
                                                               .OrderID = 1, _
                                                               .Val_Named = strPosition, _
                                                               .Val_String = strPosition}
        Return objOA_Bookmark__Position
    End Function

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
        objDBLevel_MedaiItemObjects_MediaItem = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_MediaItemObjects_Ranges = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_MediaItemRange_To_Bookmarks = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_MediaItemObjects_Is = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_CreationDate = New clsDBLevel(objLocalConfig.Globals)

        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Created = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Files = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_MediaItems = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BookMarks = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_MediaItemsOfFiles = New clsDBLevel(objLocalConfig.Globals)

        objDataWork_Tagged = New clsDataWork_Tagging(objLocalConfig.Globals, objLocalConfig.OItem_User, objLocalConfig.OItem_Group)
    End Sub
End Class
