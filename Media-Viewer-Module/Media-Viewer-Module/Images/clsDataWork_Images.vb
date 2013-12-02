Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class clsDataWork_Images
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_Images As clsDBLevel
    Private objDBLevel_Files As clsDBLevel
    Private objDBLevel_CreationDate As clsDBLevel
    Private objDBLevel_ImageObjects_LeftRight As clsDBLevel
    Private objDBLevel_Ref As clsDBLevel

    Private dtblT_Images As New DataSet_Images.dtbl_ImagesDataTable
    Private objThread_Images As Threading.Thread
    Private objOItem_Ref As clsOntologyItem
    Private boolLoaded As Boolean
    Private boolTable As Boolean
    Private objLImages As List(Of clsMultiMediaItem) = New List(Of clsMultiMediaItem)

    Public Property ImageObjectLoaded As Boolean


    Public Function NoObjects(OItem_Image As clsOntologyItem, OItem_NoObjects As clsOntologyItem) As Boolean
        Dim objOList_NOObjects = objDBLevel_ImageObjects_LeftRight.OList_ObjectRel.Where(Function(p) p.ID_Other = OItem_NoObjects.GUID).ToList()
        Dim objOList_ImageObjects = objDBLevel_ImageObjects_LeftRight.OList_ObjectRel.Where(Function(p) p.ID_Other = OItem_Image.GUID Or p.ID_Other = OItem_NoObjects.GUID).ToList()
        Return (From objImages In objOList_ImageObjects.Where(Function(p) p.ID_Other = OItem_Image.GUID)
                Join objNoObject In objOList_ImageObjects.Where(Function(p) p.ID_Other = OItem_NoObjects.GUID) On objImages.ID_Object Equals objNoObject.ID_Object
                Select objImages).Any()

    End Function

    Public Function OList_ImageObjects(Optional OItem_Image As clsOntologyItem = Nothing) As List(Of clsObjectRel)
        Dim objOList_ImageObjects As List(Of clsObjectRel)

        If OItem_Image Is Nothing Then
            objOList_ImageObjects = objDBLevel_ImageObjects_LeftRight.OList_ObjectRel
        Else
            Dim objOList_Image = objDBLevel_ImageObjects_LeftRight.OList_ObjectRel.Where(Function(p) p.ID_Other = OItem_Image.GUID).ToList()
            objOList_ImageObjects = (From objImageObject In objDBLevel_ImageObjects_LeftRight.OList_ObjectRel
                                         Join objImage In objOList_Image On objImage.ID_Object Equals objImageObject.ID_Object
                                         Where Not objImageObject.ID_Parent_Other = objLocalConfig.OItem_Type_Images__Graphic_.GUID
                                         Select objImageObject).ToList
        End If

        Return objOList_ImageObjects
    End Function

    Public Function OList_ImageObjects(OItem_Image As clsOntologyItem, GUID_Class As String) As List(Of clsObjectRel)
        Dim objOList_ImageObjects As List(Of clsObjectRel)
        objOList_ImageObjects = (From objImageObjectOfImage In objDBLevel_ImageObjects_LeftRight.OList_ObjectRel.Where(Function(p) p.ID_Other = OItem_Image.GUID).ToList()
                                Join objImageObject In objDBLevel_ImageObjects_LeftRight.OList_ObjectRel.Where(Function(p) p.ID_Parent_Other = GUID_Class).ToList() On objImageObjectOfImage.ID_Object Equals objImageObject.ID_Object
                                Select objImageObject).ToList()

        Return objOList_ImageObjects
    End Function

    Public Function OList_RefOfImages(GUID_Class As String, Optional OItem_Image As clsOntologyItem = Nothing) As List(Of clsObjectRel)
        Dim objOList_Ref As List(Of clsObjectRel)

        If OItem_Image Is Nothing Then
            objOList_Ref = objDBLevel_Ref.OList_ObjectRel.Where(Function(p) p.ID_Parent_Other = GUID_Class).ToList

        Else
            objOList_Ref = objDBLevel_Ref.OList_ObjectRel.Where(Function(p) p.ID_Object = OItem_Image.GUID And p.ID_Parent_Other = GUID_Class).ToList()
        End If
        Return objOList_Ref
    End Function


    Public ReadOnly Property Loaded As Boolean
        Get
            Return boolLoaded
        End Get
    End Property

    Public ReadOnly Property dtbl_Images As DataSet_Images.dtbl_ImagesDataTable
        Get
            Return dtblT_Images
        End Get
    End Property

    Public ReadOnly Property ItemList As List(Of clsMultiMediaItem)
        Get
            Return objLImages
        End Get
    End Property

    Public Sub get_Images(ByVal OItem_Ref As clsOntologyItem, Optional boolTable As Boolean = True)

        Me.boolTable = boolTable
        objOItem_Ref = OItem_Ref
        dtblT_Images.Clear()
        boolLoaded = False
        Try
            objThread_Images.Abort()
        Catch ex As Exception

        End Try


        objThread_Images = New Threading.Thread(AddressOf get_Images_Thread)
        objThread_Images.Start()

    End Sub

    Public Function get_Image(OItem_Image As clsOntologyItem) As List(Of clsMultiMediaItem)
        Dim objOL_Images_To_Ref As New List(Of clsObjectRel)
        Dim objOL_Images_To_File As New List(Of clsObjectRel)
        Dim objOL_CreationDate As New List(Of clsObjectAtt)
        If Not OItem_Image Is Nothing Then
            objOL_Images_To_File.Add(New clsObjectRel With {.ID_Object = OItem_Image.GUID, _
                                                        .ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID, _
                                                  .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Source.GUID
                                                  })

            objDBLevel_Files.get_Data_ObjectRel(objOL_Images_To_File, _
                                                boolIDs:=False)

            If objDBLevel_Files.OList_ObjectRel.Any Then
                objOL_CreationDate = objDBLevel_Files.OList_ObjectRel.Select(Function(p) New clsObjectAtt With { _
                                                                             .ID_Object = p.ID_Other, _
                                                                             .ID_AttributeType = objLocalConfig.OItem_Type_Images__Graphic_.GUID _
                                                                         }).ToList

                objDBLevel_CreationDate.get_Data_ObjectAtt(objOL_CreationDate, _
                                                           boolIDs:=False)

                objLImages.Clear()
                objLImages = (From objFile In objDBLevel_Files.OList_ObjectRel
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


        Return objLImages
    End Function

    Public Function GetNextOrderIDOFRef(OItem_Ref As clsOntologyItem) As Long
        Dim lngOrderID As Long
        Dim objOItem_Image As clsOntologyItem

        objOItem_Image = New clsOntologyItem
        objOItem_Image.GUID_Parent = objLocalConfig.OItem_Type_Images__Graphic_.GUID
        objOItem_Image.Type = objLocalConfig.Globals.Type_Object

        lngOrderID = objDBLevel_Images.get_Data_Rel_OrderID(objOItem_Image, OItem_Ref, objLocalConfig.OItem_RelationType_belongsTo, False)

        Return lngOrderID
    End Function

    Private Sub get_Images_Thread()
        Dim objOL_Images_To_Ref As New List(Of clsObjectRel)
        Dim objOL_Images_To_File As New List(Of clsObjectRel)
        Dim objOL_CreationDate As New List(Of clsObjectAtt)


        objOL_Images_To_Ref.Add(New clsObjectRel(Nothing, _
                                                 Nothing, _
                                                 objLocalConfig.OItem_Type_Images__Graphic_.GUID, _
                                                 Nothing, _
                                                 If(objOItem_Ref Is Nothing, Nothing, objOItem_Ref.GUID), _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing))

        objDBLevel_Images.get_Data_ObjectRel(objOL_Images_To_Ref, _
                                             boolIDs:=False)


        objOL_Images_To_File.Add(New clsObjectRel(Nothing, _
                                                  Nothing, _
                                                  objLocalConfig.OItem_Type_Images__Graphic_.GUID, _
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

        objDBLevel_Files.get_Data_ObjectRel(objOL_Images_To_File, _
                                            boolIDs:=False)

        objOL_CreationDate.Add(New clsObjectAtt(Nothing, _
                                                Nothing, _
                                                objLocalConfig.OItem_Type_Images__Graphic_.GUID, _
                                                objLocalConfig.OItem_Attribute_taking.GUID, _
                                                Nothing))

        objDBLevel_CreationDate.get_Data_ObjectAtt(objOL_CreationDate, _
                                                   boolIDs:=False)

        objLImages.Clear()
        objLImages = (From objImg In objDBLevel_Images.OList_ObjectRel
                         Join objFile In objDBLevel_Files.OList_ObjectRel On objFile.ID_Object Equals objImg.ID_Object
                         Group Join objDate In objDBLevel_CreationDate.OList_ObjectAtt On objDate.ID_Object Equals objImg.ID_Object Into objDates = Group
                         From objDate In objDates.DefaultIfEmpty
                         Order By objImg.OrderID
                         Select New clsMultiMediaItem(objImg.ID_Object, _
                                                      objImg.Name_Object, _
                                                      objImg.ID_Parent_Object, _
                                                      objFile.ID_Other, _
                                                      objFile.Name_Other, _
                                                      objFile.ID_Parent_Other, _
                                                      objDate, _
                                                      objImg.OrderID)).ToList()

        If boolTable Then
            For Each objImage In objLImages
                If objImage.OACreate Is Nothing Then
                    dtblT_Images.Rows.Add(objImage.OrderID, _
                                          objImage.ID_Item, _
                                          objImage.Name_Item, _
                                          Nothing, _
                                          objImage.ID_File, _
                                          objImage.Name_File)
                Else
                    dtblT_Images.Rows.Add(objImage.OrderID, _
                                          objImage.ID_Item, _
                                          objImage.Name_Item, _
                                          objImage.OACreate.Val_Date, _
                                          objImage.ID_File, _
                                          objImage.Name_File)
                End If
            Next
        End If


        boolLoaded = True
    End Sub

    Public Function GetDataObjectsOfImages() As clsOntologyItem
        Dim objOList_Search_LeftRight = New List(Of clsObjectRel) From {
            New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Type_Image_Objects.GUID, _
                                   .ID_RelationType = objLocalConfig.OItem_RelationType_is.GUID},
            New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Type_Image_Objects.GUID, _
                                   .ID_RelationType = objLocalConfig.OItem_RelationType_located_in.GUID}, _
            New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Type_Image_Objects.GUID, _
                                   .ID_RelationType = objLocalConfig.OItem_RelationType_has.GUID}
        }


        Dim objOItem_Result = objDBLevel_ImageObjects_LeftRight.get_Data_ObjectRel(objOList_Search_LeftRight, _
                                                                                   boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objOList_Refs = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Type_Images__Graphic_.GUID, _
                                                                                        .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                                                        .ID_Parent_Other = objLocalConfig.OItem_Type_Wichtige_Ereignisse.GUID}}

            objOItem_Result = objDBLevel_Ref.get_Data_ObjectRel(objOList_Refs)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

            End If
        End If
        ImageObjectLoaded = True
        Return objOItem_Result
    End Function

    Public Function GetImageItemOfFile(OItem_File As clsOntologyItem, OItem_MediaType As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_MediaItem As clsOntologyItem
        Dim objOList_MediaItemToFile As New List(Of clsObjectRel)

        objOList_MediaItemToFile.Add(New clsObjectRel(Nothing, _
                                                      OItem_MediaType.GUID, _
                                                      OItem_File.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_RelationType_belonging_Source.GUID,
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing))


        objOItem_Result = objDBLevel_Images.get_Data_ObjectRel(objOList_MediaItemToFile, _
                                                                          boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Images.OList_ObjectRel.Any() Then
                objOItem_MediaItem = New clsOntologyItem(objDBLevel_Images.OList_ObjectRel.First().ID_Object, _
                                                         objDBLevel_Images.OList_ObjectRel.First().ID_Other, _
                                                         objDBLevel_Images.OList_ObjectRel.First().ID_Parent_Other, _
                                                         objLocalConfig.Globals.Type_Object)


            Else
                objOItem_MediaItem = Nothing
            End If
        Else
            objOItem_MediaItem = Nothing
        End If

        Return objOItem_MediaItem
    End Function

    Public Function hasImage(OItem_Ref) As clsOntologyItem
        Dim objOL_Images_To_Ref As New List(Of clsObjectRel)

        objOL_Images_To_Ref.Add(New clsObjectRel(Nothing, _
                                                 Nothing, _
                                                 objLocalConfig.OItem_Type_Images__Graphic_.GUID, _
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

        Dim objOItem_Result = objDBLevel_Images.get_Data_ObjectRel(objOL_Images_To_Ref, doCount:=True)


        Return objOItem_Result
    End Function

    Public Function Rel_Image_To_File(OItem_Image As clsOntologyItem, OItem_File As clsOntologyItem) As clsObjectRel
        Dim objOR_Image_To_File = New clsObjectRel With {.ID_Object = OItem_Image.GUID, _
                                                             .ID_Parent_Object = OItem_Image.GUID_Parent, _
                                                             .ID_Other = OItem_File.GUID, _
                                                             .ID_Parent_Other = OItem_File.GUID_Parent, _
                                                             .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Source.GUID, _
                                                             .OrderID = 1, _
                                                             .Ontology = objLocalConfig.Globals.Type_Object}

        Return objOR_Image_To_File
    End Function

    Public Function Rel_Image_To_Ref(OItem_Image As clsOntologyItem, OItem_Ref As clsOntologyItem, Optional boolGetNextOrderID As Boolean = True) As clsObjectRel

        Dim intOrderID = OItem_Image.Level
        If boolGetNextOrderID Then
            intOrderID = objDBLevel_Images.get_Data_Rel_OrderID(New clsOntologyItem With {.GUID_Parent = OItem_Image.GUID_Parent}, OItem_Ref, objLocalConfig.OItem_RelationType_belongsTo, False)
            intOrderID = intOrderID + 1
        End If

        Dim objOR_Image_To_Ref = New clsObjectRel With {.ID_Object = OItem_Image.GUID, _
                                                            .ID_Parent_Object = OItem_Image.GUID_Parent, _
                                                            .ID_Other = OItem_Ref.GUID, _
                                                            .ID_Parent_Other = OItem_Ref.GUID_Parent, _
                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                            .OrderID = intOrderID, _
                                                            .Ontology = OItem_Ref.Type}

        Return objOR_Image_To_Ref
    End Function

    Public Function Rel_Image__Taking(OItem_Image As clsOntologyItem, dateTaking As DateTime) As clsObjectAtt
        Dim objOARel_Image__Taking = New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_taking.GUID, _
                                                            .ID_Object = OItem_Image.GUID, _
                                                            .ID_Class = OItem_Image.GUID_Parent, _
                                                            .ID_DataType = objLocalConfig.Globals.DType_DateTime.GUID, _
                                                            .OrderID = 1, _
                                                            .Val_Named = dateTaking.ToString, _
                                                            .Val_Date = dateTaking}
        Return objOARel_Image__Taking
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Images = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Files = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_CreationDate = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ImageObjects_LeftRight = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Ref = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
