Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Structure_Module


Public Class UserControl_ObjectRelationMediaItem

    Private objLocalConfig As clsLocalConfig

    Private objDataWork_MediaItem As clsDataWork_MediaItem

    Private objOItem_MediaItem As clsOntologyItem

    Private objOList_MediaItemObjects As SortableBindingList(Of clsMediaItemObject)

    Private WithEvents objUserControl_Ref As UserControl_OItemList

    Private objFrm_ObjectEdit As frm_ObjectEdit

    Private objOItem_Class As clsOntologyItem

    Private objTransaction As clsTransaction
    Private objRelationConfig As clsRelationConfig

    Private Sub SelectedRef() Handles objUserControl_Ref.Selection_Changed
        ToolStripButton_ToList.Enabled = False
        If objUserControl_Ref.DataGridViewRowCollection_Selected.Count > 0 Then
            ToolStripButton_ToList.Enabled = True
        End If
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)

        If objUserControl_Ref Is Nothing Then
            objUserControl_Ref = New UserControl_OItemList(objLocalConfig.Globals)
            objUserControl_Ref.Dock = DockStyle.Fill
            SplitContainer1.Panel2.Controls.Add(objUserControl_Ref)
        End If

    End Sub

    Public Sub Initialize_MediaItemObject(OItem_MediaItem As clsOntologyItem, dataWork_MediaItem As clsDataWork_MediaItem, OItem_Class As clsOntologyItem)
        objDataWork_MediaItem = dataWork_MediaItem

        objOItem_Class = OItem_Class

        objOItem_MediaItem = OItem_MediaItem

        RefreshList()

        If (objUserControl_Ref.DataGridviewRows.Count = 0) Then
            objUserControl_Ref.initialize(New clsOntologyItem With {.GUID_Parent = objOItem_Class.GUID, .Type = objLocalConfig.Globals.Type_Object})
        End If

    End Sub


    Private Sub RefreshList()
        objOList_MediaItemObjects = New SortableBindingList(Of clsMediaItemObject)(objDataWork_MediaItem.OList_MediaItemObjects(objOItem_MediaItem). _
                                                                                Where(Function(ol) ol.ID_Parent_Ref = objOItem_Class.GUID))

        DataGridView_RelatedOfImage.DataSource = objOList_MediaItemObjects
        For Each objCol As DataGridViewColumn In DataGridView_RelatedOfImage.Columns
            If Not objCol.DataPropertyName = "Name_Ref" Then
                objCol.Visible = False
            End If
        Next


    End Sub

    Private Sub DataGridView_RelatedOfImage_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView_RelatedOfImage.SelectionChanged
        ToolStripButton_FromList.Enabled = False
        If DataGridView_RelatedOfImage.SelectedRows.Count > 0 Then
            ToolStripButton_FromList.Enabled = True
        End If
    End Sub

    Private Sub ToolStripButton_FromList_Click(sender As Object, e As EventArgs) Handles ToolStripButton_FromList.Click

    End Sub

    Private Sub ToolStripButton_ToList_Click(sender As Object, e As EventArgs) Handles ToolStripButton_ToList.Click
        If objDataWork_MediaItem.GetDataObjectsOfMediaItem(objOItem_MediaItem).GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objOList_MediaItemObjects = objDataWork_MediaItem.OList_MediaItemObjects(objOItem_MediaItem)
            objTransaction.ClearItems()
            Dim intToDo = objUserControl_Ref.DataGridViewRowCollection_Selected.Count
            Dim intDone = 0
            For Each objDataRow As DataGridViewRow In objUserControl_Ref.DataGridViewRowCollection_Selected
                Dim objDRV As DataRowView = objDataRow.DataBoundItem

                If Not objOList_MediaItemObjects.Any(Function(p) p.ID_Ref = objDRV.Item("ID_Item")) Then
                    Dim objOItem_MediaItemObject = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                                         .Name = objDRV.Item("Name"), _
                                                                         .GUID_Parent = objLocalConfig.OItem_class_media_item_objects.GUID, _
                                                                         .Type = objLocalConfig.Globals.Type_Object}
                    Dim objOItem_Result = objTransaction.do_Transaction(objOItem_MediaItemObject)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        Dim objORel_MediaItemObject_To_Image = objRelationConfig.Rel_ObjectRelation(objOItem_MediaItemObject, _
                                                                                                objOItem_MediaItem, _
                                                                                                objLocalConfig.OItem_RelationType_located_in)
                        objOItem_Result = objTransaction.do_Transaction(objORel_MediaItemObject_To_Image)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Dim objOItem_Object = New clsOntologyItem With {.GUID = objDRV.Item("ID_Item"), _
                                                                            .Name = objDRV.Item("Name"), _
                                                                            .GUID_Parent = objDRV.Item("ID_Parent"), _
                                                                            .Type = objLocalConfig.Globals.Type_Object}

                            Dim objORel_MediaItemObject_To_Object = objRelationConfig.Rel_ObjectRelation(objOItem_MediaItemObject, _
                                                                                                     objOItem_Object, _
                                                                                                     objLocalConfig.OItem_RelationType_is)

                            objOItem_Result = objTransaction.do_Transaction(objORel_MediaItemObject_To_Object)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objORel_MediaItemObject_To_Object.Name_Other = objOItem_Object.Name
                                objDataWork_MediaItem.AddMediaItemObject(objOItem_MediaItem, objOItem_MediaItemObject, objOItem_Object)
                                intDone = intDone + 1
                            Else
                                objTransaction.rollback()
                            End If
                        Else
                            objTransaction.rollback()
                        End If
                    End If
                End If
            Next
            If intDone < intToDo Then
                MsgBox("Es konnten leider nur " & intDone & " von " & intToDo & " Objekte verknüpft werden!", MsgBoxStyle.Exclamation)

            End If

            RefreshList()

        Else
            MsgBox("Beim Ermitteln der vorhandenen Image-Objekte ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)

        End If
    End Sub

    Private Sub DataGridView_RelatedOfImage_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_RelatedOfImage.RowHeaderMouseDoubleClick
        Dim objMediaItemObject As clsMediaItemObject = DataGridView_RelatedOfImage.Rows(e.RowIndex).DataBoundItem

        Dim objOList_Objects = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID = objMediaItemObject.ID_MediaItemObject, _
                                                                                             .Name = objMediaItemObject.Name_MediaItemObject, _
                                                                                             .GUID_Parent = objLocalConfig.OItem_class_media_item_objects.GUID, _
                                                                                             .Type = objLocalConfig.Globals.Type_Object}}

        objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, objOList_Objects, 0, objLocalConfig.Globals.Type_Object, Nothing)
        objFrm_ObjectEdit.ShowDialog(Me)

        RefreshList()
    End Sub
End Class
