Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class clsDataWork_Images
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_Images As clsDBLevel
    Private objDBLevel_Files As clsDBLevel
    Private objDBLevel_CreationDate As clsDBLevel
    Private dtblT_Images As New DataSet_Images.dtbl_ImagesDataTable
    Private objThread_Images As Threading.Thread
    Private objOItem_Ref As clsOntologyItem
    Private boolLoaded As Boolean
    Private boolTable As Boolean
    Private objLImages As List(Of clsMultiMediaItem) = New List(Of clsMultiMediaItem)

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
    End Sub
End Class
