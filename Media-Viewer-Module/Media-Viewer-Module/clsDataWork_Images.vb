Imports Ontolog_Module
Public Class clsDataWork_Images
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_Images As clsDBLevel
    Private objDBLevel_Files As clsDBLevel
    Private objDBLevel_CreationDate As clsDBLevel
    Private dtblT_Images As New DataSet_Images.dtbl_ImagesDataTable
    Private objThread_Images As Threading.Thread
    Private objOItem_Ref As clsOntologyItem
    Private boolLoaded As Boolean

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

    Public Sub get_Images(ByVal OItem_Ref As clsOntologyItem)

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

        Dim objLImages = From objImg In objDBLevel_Images.OList_ObjectRel
                         Join objFile In objDBLevel_Files.OList_ObjectRel_ID On objFile.ID_Object Equals objImg.ID_Object
                         Group Join objDate In objDBLevel_CreationDate.OList_ObjectAtt On objDate.ID_Object Equals objImg.ID_Object Into objDates = Group
                         From objDate In objDates.DefaultIfEmpty
                         Order By objImg.OrderID

        For Each objImage In objLImages
            If objImage.objDate Is Nothing Then
                dtblT_Images.Rows.Add(objImage.objImg.OrderID, _
                                      objImage.objImg.ID_Object, _
                                      objImage.objImg.Name_Object, _
                                      Nothing, _
                                      objImage.objFile.ID_Other, _
                                      Nothing)
            Else
                dtblT_Images.Rows.Add(objImage.objImg.OrderID, _
                                      objImage.objImg.ID_Object, _
                                      objImage.objImg.Name_Object, _
                                      objImage.objDate.Val_Date, _
                                      objImage.objFile.ID_Other, _
                                      Nothing)
            End If
        Next

        boolLoaded = True
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Images = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Files = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_CreationDate = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
