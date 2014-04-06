Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class frmMediaModule_ListEdit
    Private WithEvents objUserControl_MediaList As UserControl_OItemList
    Private WithEvents objUserControl_ImageRelation As UserControl_ImageRelation
    Private WithEvents objUserControl_MediaItemRelation As UserControl_MediaItemRelation

    Private objDatawork_Images As clsDataWork_Images
    Private objDataWork_MediaItems As clsDataWork_MediaItem

    Private objLocalConfig As clsLocalConfig

    Private objOItem_MediaType As clsOntologyItem

    Private objOItem_Ref As clsOntologyItem

    Private Sub SelectedRow() Handles objUserControl_MediaList.Selection_Changed
        Dim objOitem_MediaItem As clsOntologyItem = Nothing
        
        If objUserControl_MediaList.DataGridViewRowCollection_Selected.Count = 1 Then

            If objOItem_Ref Is Nothing Then
                objOitem_MediaItem = New clsOntologyItem With {.GUID = objUserControl_MediaList.DataGridViewRowCollection_Selected(0).Cells("ID_Item").Value.ToString, _
                                                       .Name = objUserControl_MediaList.DataGridViewRowCollection_Selected(0).Cells("Name").Value.ToString, _
                                                       .GUID_Parent = objOItem_MediaType.GUID, _
                                                       .Type = objLocalConfig.Globals.Type_Object}
            Else
                objOitem_MediaItem = New clsOntologyItem With {.GUID = objUserControl_MediaList.DataGridViewRowCollection_Selected(0).Cells("ID_Object").Value.ToString, _
                                                       .Name = objUserControl_MediaList.DataGridViewRowCollection_Selected(0).Cells("Name_Object").Value.ToString, _
                                                       .GUID_Parent = objOItem_MediaType.GUID, _
                                                       .Type = objLocalConfig.Globals.Type_Object}
            End If
            

            Select Case objOItem_MediaType.GUID
                Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                    If Not objDatawork_Images.ImageObjectLoaded Then
                        objDatawork_Images.GetDataObjectsOfImages()
                    End If
                    objUserControl_ImageRelation.Initialize_Image(objOitem_MediaItem)

                Case objLocalConfig.OItem_Type_Media_Item.GUID
                    objUserControl_MediaItemRelation.Initialize_MediaItem(objOitem_MediaItem)
            End Select
        End If

        

    End Sub

    Public Sub New(LocalConfig As clsLocalConfig, OItem_MediaType As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        objOItem_MediaType = OItem_MediaType
        objOItem_Ref = Nothing
        Initialize()
    End Sub


    Public Sub New(LocalConfig As clsLocalConfig, OItem_MediaType As clsOntologyItem, OItem_Ref As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        objOItem_MediaType = OItem_MediaType

        objOItem_Ref = OItem_Ref
        Initialize()
    End Sub
    Private Sub Initialize()



        objUserControl_MediaList = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_MediaList.Dock = DockStyle.Fill
        SplitContainer1.Panel1.Controls.Add(objUserControl_MediaList)

        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                objDatawork_Images = New clsDataWork_Images(objLocalConfig)
                objUserControl_ImageRelation = New UserControl_ImageRelation(objLocalConfig, objDatawork_Images)
                objUserControl_ImageRelation.Dock = DockStyle.Fill
                SplitContainer1.Panel2.Controls.Add(objUserControl_ImageRelation)

            Case objLocalConfig.OItem_Type_Media_Item.GUID
                objDataWork_MediaItems = New clsDataWork_MediaItem(objLocalConfig)
                objUserControl_MediaItemRelation = New UserControl_MediaItemRelation(objLocalConfig, objDataWork_MediaItems)
                objUserControl_MediaItemRelation.Dock = DockStyle.Fill
                SplitContainer1.Panel2.Controls.Add(objUserControl_MediaItemRelation)

            Case objLocalConfig.OItem_Type_PDF_Documents.GUID

        End Select
        

        If objOItem_Ref Is Nothing Then
            objUserControl_MediaList.initialize(New clsOntologyItem With {.GUID_Parent = objOItem_MediaType.GUID, .Type = objLocalConfig.Globals.Type_Object})
        Else
            objUserControl_MediaList.initialize(Nothing, _
                                                objOItem_Ref, _
                                                objLocalConfig.Globals.Direction_RightLeft, _
                                                New clsOntologyItem With {.GUID_Parent = objOItem_MediaType.GUID, .Type = objLocalConfig.Globals.Type_Object}, _
                                                objLocalConfig.OItem_RelationType_belongsTo, _
                                                True)
        End If



    End Sub

    Private Sub ToolStripButton_FilterItem_Click(sender As Object, e As EventArgs) Handles ToolStripButton_FilterItem.Click
        Dim objOItem_Result As clsOntologyItem

        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                If Not objDatawork_Images.ImageObjectLoaded Then
                    objOItem_Result = objDatawork_Images.GetDataObjectsOfImages()
                Else
                    objOItem_Result = objLocalConfig.Globals.LState_Success.Clone
                End If

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Dim objOList_ImageObjects = objDatawork_Images.OList_ImageObjects()
                    Dim ImageRows = (From T In objUserControl_MediaList.DataGridviewRows.Cast(Of DataGridViewRow)()).ToList

                    Dim OList_ImagesWithNoObjects = (From objImage In ImageRows
                                                     Join objImageObject In objOList_ImageObjects On objImage.Cells("ID_Item").Value Equals objImageObject.ID_Other
                                                     Select objImage).ToList()

                    For Each objImage In OList_ImagesWithNoObjects
                        For i As Integer = 0 To objUserControl_MediaList.ColumnList.Count - 1
                            If objUserControl_MediaList.ColumnList(i).Visible = True Then
                                objUserControl_MediaList.DataGridviewRows(objImage.Index).Cells(i).Style.BackColor = Color.Green
                            End If

                        Next

                    Next

                Else
                    MsgBox("Die Fotos können nicht gefiltert werden!", MsgBoxStyle.Exclamation)
                End If
            Case objLocalConfig.OItem_Type_Media_Item.GUID

        End Select
        

    End Sub

    Private Sub ToolStripButton_ToNext_Colored_Click(sender As Object, e As EventArgs) Handles ToolStripButton_ToNext_Colored.Click
        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                Dim lngRowIndex = objUserControl_MediaList.SelectedRowIndex
                Dim objOList_ImageObjects = objDatawork_Images.OList_ImageObjects()

                Dim ImageRows = (From T In objUserControl_MediaList.DataGridviewRows.Cast(Of DataGridViewRow)()).ToList()

                Dim OList_ImagesWithNoObjects = (From objImage In ImageRows
                                                    Join objImageObject In objOList_ImageObjects On objImage.Cells("ID_Item").Value Equals objImageObject.ID_Other
                                                    Select objImage).Where(Function(p) p.Index > lngRowIndex).OrderBy(Function(p) p.Index).ToList()

                If OList_ImagesWithNoObjects.Any() Then
                    objUserControl_MediaList.select_Row(OList_ImagesWithNoObjects.First().Index)

                End If

            Case objLocalConfig.OItem_Type_Media_Item.GUID

        End Select
        

    End Sub

    Private Sub ToolStripButton_ToNext_NoColor_Click(sender As Object, e As EventArgs) Handles ToolStripButton_ToNext_NoColor.Click
        Select objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                Dim lngRowIndex = objUserControl_MediaList.SelectedRowIndex
                Dim objOList_ImageObjects = objDatawork_Images.OList_ImageObjects()

                Dim ImageRows = (From T In objUserControl_MediaList.DataGridviewRows.Cast(Of DataGridViewRow)()).ToList()

                Dim OList_ImagesWithNoObjects = (From objImage In ImageRows
                                                    Group Join objImageObject In objOList_ImageObjects On objImage.Cells("ID_Item").Value Equals objImageObject.ID_Other Into objImageObjects = Group
                                                    From objImageObject In objImageObjects.DefaultIfEmpty()
                                                    Where objImageObject Is Nothing
                                                    Select objImage).Where(Function(p) p.Index > lngRowIndex).OrderBy(Function(p) p.Index).ToList()

                If OList_ImagesWithNoObjects.Any() Then
                    objUserControl_MediaList.select_Row(OList_ImagesWithNoObjects.First().Index)

                End If
            Case objLocalConfig.OItem_Type_Media_Item.GUID

        End Select

        
    End Sub
End Class