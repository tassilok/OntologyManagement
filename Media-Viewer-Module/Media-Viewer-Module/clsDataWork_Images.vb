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

        If Not objOItem_Ref Is Nothing Then
            objThread_Images = New Threading.Thread(AddressOf get_Images_Thread)
            objThread_Images.Start()
        Else
            boolLoaded = True
        End If


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
                                            boolIDs:=True)

        objOL_CreationDate.Add(New clsObjectAtt(Nothing, _
                                                Nothing, _
                                                objLocalConfig.OItem_Type_Images__Graphic_.GUID, _
                                                objLocalConfig.OItem_Attribute_taking.GUID, _
                                                Nothing))

        objDBLevel_CreationDate.get_Data_ObjectAtt(objOL_CreationDate, _
                                                   boolIDs:=False)

        objLImages.Clear()
        objLImages = (From objImg In objDBLevel_Images.OList_ObjectRel
                         Join objFile In objDBLevel_Files.OList_ObjectRel_ID On objFile.ID_Object Equals objImg.ID_Object
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
                                          Nothing)
                Else
                    dtblT_Images.Rows.Add(objImage.OrderID, _
                                          objImage.ID_Item, _
                                          objImage.Name_Item, _
                                          objImage.OACreate.Val_Date, _
                                          objImage.ID_File, _
                                          Nothing)
                End If
            Next
        End If


        boolLoaded = True
    End Sub


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
