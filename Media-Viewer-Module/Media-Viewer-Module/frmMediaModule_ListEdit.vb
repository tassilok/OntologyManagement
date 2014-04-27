Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Typed_Tagging_Module

Public Class frmMediaModule_ListEdit
    Private WithEvents objUserControl_MediaList As UserControl_OItemList
    Private WithEvents objUserControl_TaggingContainer As UserControl_TaggingContainer

    Private WithEvents objUserControl_SingleViewer As UserControl_SingleViewer

    Private objDataWork_Tagging As clsDataWork_Tagging

    Private objMediaItems As clsMediaItems

    Private objLocalConfig As clsLocalConfig

    Private objOItem_MediaType As clsOntologyItem

    Private objOItem_Ref As clsOntologyItem

    Private TypedTags As List(Of clsTypedTag)

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
            
            objUserControl_TaggingContainer.Initialize_Taging(objOitem_MediaItem, True)

            Dim objOItem_MultiMediaItem = objMediaItems.Get_MultiMediaItem(objOitem_MediaItem)

            If Not objOItem_MultiMediaItem Is Nothing Then
                Select Case objOItem_MediaType.GUID
                    Case objLocalConfig.OItem_Type_Images__Graphic_.GUID


                        objUserControl_SingleViewer.initialize_Image(objOitem_MediaItem, New clsOntologyItem With { _
                                                                     .GUID = objOItem_MultiMediaItem.ID_File, _
                                                                     .Name = objOItem_MultiMediaItem.Name_File, _
                                                                     .GUID_Parent = objOItem_MultiMediaItem.ID_Parent_File}, _
                                                                     If(objOItem_MultiMediaItem.OACreate Is Nothing, Now, objOItem_MultiMediaItem.OACreate.Val_Date))
                    Case objLocalConfig.OItem_Type_Media_Item.GUID
                        objUserControl_SingleViewer.initialize_MediaItem(objOitem_MediaItem, New clsOntologyItem With { _
                                                                     .GUID = objOItem_MultiMediaItem.ID_File, _
                                                                     .Name = objOItem_MultiMediaItem.Name_File, _
                                                                     .GUID_Parent = objOItem_MultiMediaItem.ID_Parent_File}, _
                                                                     If(objOItem_MultiMediaItem.OACreate Is Nothing, Now, objOItem_MultiMediaItem.OACreate.Val_Date))
                    Case objLocalConfig.OItem_Type_PDF_Documents.GUID

                        objUserControl_SingleViewer.initialize_PDF(objOitem_MediaItem, New clsOntologyItem With { _
                                                                     .GUID = objOItem_MultiMediaItem.ID_File, _
                                                                     .Name = objOItem_MultiMediaItem.Name_File, _
                                                                     .GUID_Parent = objOItem_MultiMediaItem.ID_Parent_File})

                End Select
            Else
                MsgBox("Leider ist beim Ermitteln der Daten ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
            End If
            
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
        objMediaItems = New clsMediaItems(objLocalConfig)

        objDataWork_Tagging = New clsDataWork_Tagging(objLocalConfig.Globals, objLocalConfig.OItem_User, objLocalConfig.OItem_Group)
        objUserControl_MediaList = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_MediaList.Dock = DockStyle.Fill
        SplitContainer1.Panel1.Controls.Add(objUserControl_MediaList)

        objUserControl_TaggingContainer = New UserControl_TaggingContainer(objLocalConfig.Globals, objLocalConfig.OItem_User, objLocalConfig.OItem_Group)
        objUserControl_TaggingContainer.Dock = DockStyle.Fill
        TabPage_Tagging.Controls.Add(objUserControl_TaggingContainer)

        objUserControl_SingleViewer = New UserControl_SingleViewer(objLocalConfig, objOItem_MediaType)
        objUserControl_SingleViewer.Dock = DockStyle.Fill
        TabPage_Media.Controls.Add(objUserControl_SingleViewer)

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
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone
        
    End Sub

    Private Sub ToolStripButton_FilterItem_Click(sender As Object, e As EventArgs) Handles ToolStripButton_FilterItem.Click
        Dim objOItem_Result = objLocalConfig.Globals.LState_Error.Clone

        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                objOItem_Result = objDataWork_Tagging.GetTagsOfTaggingSource(New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Type_Images__Graphic_.GUID, _
                                                                                                       .Type = objLocalConfig.Globals.Type_Object})
               
                
            Case objLocalConfig.OItem_Type_Media_Item.GUID
                objOItem_Result = objDataWork_Tagging.GetTagsOfTaggingSource(New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID, _
                                                                                                       .Type = objLocalConfig.Globals.Type_Object})
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                objOItem_Result = objDataWork_Tagging.GetTagsOfTaggingSource(New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Type_PDF_Documents.GUID, _
                                                                                                       .Type = objLocalConfig.Globals.Type_Object})
        End Select
        
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            TypedTags = objDataWork_Tagging.TypedTags
            Dim ItemRows = (From T In objUserControl_MediaList.DataGridviewRows.Cast(Of DataGridViewRow)()).ToList

            Dim OList_ItemsWithNoObjects = (From objItem In ItemRows
                                             Join objTag In TypedTags On objItem.Cells(objUserControl_MediaList.RowName_GUID).Value Equals objTag.ID_TaggingSource
                                             Select objItem).ToList()

            For Each objImage In OList_ItemsWithNoObjects
                For i As Integer = 0 To objUserControl_MediaList.ColumnList.Count - 1
                    If objUserControl_MediaList.ColumnList(i).Visible = True Then
                        objUserControl_MediaList.DataGridviewRows(objImage.Index).Cells(i).Style.BackColor = Color.Green
                    End If

                Next

            Next

        Else
            MsgBox("Die Items können nicht gefiltert werden!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub ToolStripButton_ToNext_Colored_Click(sender As Object, e As EventArgs) Handles ToolStripButton_ToNext_Colored.Click
        Dim objOItem_Result = objLocalConfig.Globals.LState_Error.Clone

        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                objOItem_Result = objDataWork_Tagging.GetTagsOfTaggingSource(New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Type_Images__Graphic_.GUID, _
                                                                                                       .Type = objLocalConfig.Globals.Type_Object})


            Case objLocalConfig.OItem_Type_Media_Item.GUID
                objOItem_Result = objDataWork_Tagging.GetTagsOfTaggingSource(New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID, _
                                                                                                       .Type = objLocalConfig.Globals.Type_Object})
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                objOItem_Result = objDataWork_Tagging.GetTagsOfTaggingSource(New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Type_PDF_Documents.GUID, _
                                                                                                       .Type = objLocalConfig.Globals.Type_Object})
        End Select

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim lngRowIndex = objUserControl_MediaList.SelectedRowIndex
            TypedTags = objDataWork_Tagging.TypedTags

            Dim ItemRows = (From T In objUserControl_MediaList.DataGridviewRows.Cast(Of DataGridViewRow)()).ToList()

            Dim OList_ItemsWithNoObjects = (From objItem In ItemRows
                                         Join objTag In TypedTags On objItem.Cells(objUserControl_MediaList.RowName_GUID).Value Equals objTag.ID_TaggingSource
                                         Select objItem).ToList()

            If OList_ItemsWithNoObjects.Any() Then
                objUserControl_MediaList.select_Row(OList_ItemsWithNoObjects.First().Index)

            End If
        Else
            MsgBox("Die Items können nicht gefiltert werden!", MsgBoxStyle.Exclamation)
        End If


    End Sub

    Private Sub ToolStripButton_ToNext_NoColor_Click(sender As Object, e As EventArgs) Handles ToolStripButton_ToNext_NoColor.Click
        Dim objOItem_Result = objLocalConfig.Globals.LState_Error.Clone

        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                objOItem_Result = objDataWork_Tagging.GetTagsOfTaggingSource(New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Type_Images__Graphic_.GUID, _
                                                                                                       .Type = objLocalConfig.Globals.Type_Object})


            Case objLocalConfig.OItem_Type_Media_Item.GUID
                objOItem_Result = objDataWork_Tagging.GetTagsOfTaggingSource(New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID, _
                                                                                                       .Type = objLocalConfig.Globals.Type_Object})
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                objOItem_Result = objDataWork_Tagging.GetTagsOfTaggingSource(New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Type_PDF_Documents.GUID, _
                                                                                                       .Type = objLocalConfig.Globals.Type_Object})
        End Select

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim lngRowIndex = objUserControl_MediaList.SelectedRowIndex
            TypedTags = objDataWork_Tagging.TypedTags

            Dim ItemRows = (From T In objUserControl_MediaList.DataGridviewRows.Cast(Of DataGridViewRow)()).ToList()

            Dim OList_ItemsWithNoObjects = (From objItem In ItemRows
                                         Group Join objTag In TypedTags On objItem.Cells(objUserControl_MediaList.RowName_GUID).Value Equals objTag.ID_TaggingSource Into objTags = Group
                                         From objTag In objTags.DefaultIfEmpty()
                                         Where objTag Is Nothing
                                         Select objItem).ToList()

            If OList_ItemsWithNoObjects.Any() Then
                objUserControl_MediaList.select_Row(OList_ItemsWithNoObjects.First().Index)

            End If
        Else
            MsgBox("Die Items können nicht gefiltert werden!", MsgBoxStyle.Exclamation)
        End If


    End Sub
End Class