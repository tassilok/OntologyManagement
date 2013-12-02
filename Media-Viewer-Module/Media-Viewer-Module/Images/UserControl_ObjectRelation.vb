Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Structure_Module

Public Class UserControl_ObjectRelation
    Private objLocalConfig As clsLocalConfig

    Private WithEvents objUserControl_Objects As UserControl_OItemList


    Private objDataWork_Images As clsDataWork_Images

    Private objOItem_Image As clsOntologyItem
    Private objOItem_Class_Object As clsOntologyItem
    Private objOItem_NoObject As clsOntologyItem

    Private objTransaction As clsTransaction
    Private objRelationConfig As clsRelationConfig


    Private Sub selectedObjects() Handles objUserControl_Objects.Selection_Changed
        ToolStripButton_FromList.Enabled = False
        If objUserControl_Objects.DataGridViewRowCollection_Selected.Count > 0 Then
            ToolStripButton_ToList.Enabled = True
        End If
    End Sub

    Public Sub Clear()
        ToolStripButton_ToList.Enabled = False
        ToolStripButton_FromList.Enabled = False
        ToolStripButton_NoObjects.Enabled = False

        objUserControl_Objects.clear_Relation()
        objUserControl_Objects.Enabled = False
        DataGridView_RelatedOfImage.Enabled = False
        DataGridView_RelatedOfImage.DataSource = Nothing
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig, DataWork_Images As clsDataWork_Images)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        objDataWork_Images = DataWork_Images
        Initialize()
    End Sub

    Public Sub Initialize_Objects(OItem_Image As clsOntologyItem, OItem_Class_Object As clsOntologyItem, OItem_NoObjects As clsOntologyItem)

        Clear()
        objOItem_Image = OItem_Image
        objOItem_Class_Object = OItem_Class_Object
        objOItem_NoObject = OItem_NoObjects
        If Not objOItem_Image Is Nothing Then

            Dim objOList_ImageObjects = New SortableBindingList(Of clsObjectRel)(objDataWork_Images.OList_ImageObjects(objOItem_Image).Where(Function(p) p.ID_Parent_Other = OItem_Class_Object.GUID).Select(Function(p) New clsObjectRel With _
                                                                                                                                                                            {.ID_Object = p.ID_Object, _
                                                                                                                                                                             .ID_Parent_Object = p.ID_Parent_Object, _
                                                                                                                                                                             .ID_Other = p.ID_Other, _
                                                                                                                                                                             .Name_Other = p.Name_Other, _
                                                                                                                                                                             .ID_Parent_Other = p.ID_Other, _
                                                                                                                                                                             .ID_RelationType = p.ID_RelationType, _
                                                                                                                                                                             .Ontology = p.Ontology, _
                                                                                                                                                                             .OrderID = p.OrderID}))

            objUserControl_Objects.initialize(New clsOntologyItem With {.GUID_Parent = OItem_Class_Object.GUID, .Type = objLocalConfig.Globals.Type_Object})
            objUserControl_Objects.Enabled = True


            If objOList_ImageObjects.Any Then
                DataGridView_RelatedOfImage.DataSource = objOList_ImageObjects
                DataGridView_RelatedOfImage.Columns(0).Visible = False
                DataGridView_RelatedOfImage.Columns(1).Visible = False
                DataGridView_RelatedOfImage.Columns(2).Visible = False
                DataGridView_RelatedOfImage.Columns(3).Visible = False
                DataGridView_RelatedOfImage.Columns(4).Visible = False
                DataGridView_RelatedOfImage.Columns(5).Visible = True
                DataGridView_RelatedOfImage.Columns(6).Visible = False
                DataGridView_RelatedOfImage.Columns(7).Visible = False
                DataGridView_RelatedOfImage.Columns(8).Visible = False
                DataGridView_RelatedOfImage.Columns(9).Visible = False
                DataGridView_RelatedOfImage.Columns(10).Visible = False
                DataGridView_RelatedOfImage.Columns(11).Visible = False
                DataGridView_RelatedOfImage.Columns(12).Visible = False
                DataGridView_RelatedOfImage.Columns(13).Visible = False
                DataGridView_RelatedOfImage.Columns(14).Visible = False
                

                DataGridView_RelatedOfImage.Enabled = True


                
            Else
                Dim objOList_NoObjects = objDataWork_Images.OList_ImageObjects(objOItem_Image).Where(Function(p) p.ID_Other = OItem_NoObjects.GUID).ToList

                If objOList_NoObjects.Any Then
                    ToolStripButton_NoObjects.Checked = True

                Else
                    ToolStripButton_NoObjects.Checked = False
                End If

                ToolStripButton_NoObjects.Enabled = True
            End If



        End If
    End Sub

    Private Sub Initialize()
        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)

        objUserControl_Objects = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_Objects.Dock = DockStyle.Fill

        SplitContainer1.Panel2.Controls.Add(objUserControl_Objects)
    End Sub


    Private Sub DataGridView_RelatedOfImage_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView_RelatedOfImage.SelectionChanged
        ToolStripButton_ToList.Enabled = False
        If DataGridView_RelatedOfImage.SelectedRows.Count > 0 And ToolStripButton_NoObjects.Checked = False Then
            ToolStripButton_FromList.Enabled = True

        End If
    End Sub

    Private Sub ToolStripButton_FromList_Click(sender As Object, e As EventArgs) Handles ToolStripButton_FromList.Click
        'Dim ImageRows = (From T In DataGridView_RelatedOfImage.SelectedRows.Cast(Of DataGridViewRow)()).ToList

        objTransaction.ClearItems()
        Dim intToDo As Integer = DataGridView_RelatedOfImage.SelectedRows.Count
        Dim intDone As Integer = 0

        For Each objDataRow As DataGridViewRow In DataGridView_RelatedOfImage.SelectedRows
            Dim objORel As clsObjectRel = objDataRow.DataBoundItem
            Dim objORel_Del = New clsObjectRel With {.ID_Object = objORel.ID_Object, _
                                                     .ID_Other = objORel.ID_Other, _
                                                     .ID_RelationType = objORel.ID_RelationType}

            Dim objOItem_Result = objTransaction.do_Transaction(objORel_Del, False, True)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objDataWork_Images.OList_ImageObjects.Remove(objORel)
                intDone = intDone + 1
            End If


        Next

        If intDone < intToDo Then
            MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Image-Objekte gelöscht werden!", MsgBoxStyle.Information)
        End If
        Initialize_Objects(objOItem_Image, objOItem_Class_Object, objOItem_NoObject)
    End Sub

    Private Sub ToolStripButton_ToList_Click(sender As Object, e As EventArgs) Handles ToolStripButton_ToList.Click
        If objDataWork_Images.GetDataObjectsOfImages().GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objOList_ImageObjects = objDataWork_Images.OList_ImageObjects(objOItem_Image)
            objTransaction.ClearItems()
            Dim intToDo = objUserControl_Objects.DataGridViewRowCollection_Selected.Count
            Dim intDone = 0
            For Each objDataRow As DataGridViewRow In objUserControl_Objects.DataGridViewRowCollection_Selected
                Dim objDRV As DataRowView = objDataRow.DataBoundItem

                If Not objOList_ImageObjects.Any(Function(p) p.ID_Other = objDRV.Item("ID_Item")) Then
                    Dim objOItem_ImageObject = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                                         .Name = objDRV.Item("Name"), _
                                                                         .GUID_Parent = objLocalConfig.OItem_Type_Image_Objects.GUID, _
                                                                         .Type = objLocalConfig.Globals.Type_Object}
                    Dim objOItem_Result = objTransaction.do_Transaction(objOItem_ImageObject)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        Dim objORel_ImageObject_To_Image = objRelationConfig.Rel_ObjectRelation(objOItem_ImageObject, _
                                                                                                objOItem_Image, _
                                                                                                objLocalConfig.OItem_RelationType_located_in)
                        objOItem_Result = objTransaction.do_Transaction(objORel_ImageObject_To_Image)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Dim objOItem_Object = New clsOntologyItem With {.GUID = objDRV.Item("ID_Item"), _
                                                                            .Name = objDRV.Item("Name"), _
                                                                            .GUID_Parent = objDRV.Item("ID_Parent"), _
                                                                            .Type = objLocalConfig.Globals.Type_Object}

                            Dim objORel_ImageObject_To_Object = objRelationConfig.Rel_ObjectRelation(objOItem_ImageObject, _
                                                                                                     objOItem_Object, _
                                                                                                     objLocalConfig.OItem_RelationType_is)

                            objOItem_Result = objTransaction.do_Transaction(objORel_ImageObject_To_Object)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objORel_ImageObject_To_Object.Name_Other = objOItem_Object.Name
                                objDataWork_Images.OList_ImageObjects.Add(objORel_ImageObject_To_Object)
                                objDataWork_Images.OList_ImageObjects.Add(objORel_ImageObject_To_Image)
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

            Initialize_Objects(objOItem_Image, objOItem_Class_Object, objOItem_NoObject)

        Else
            MsgBox("Beim Ermitteln der vorhandenen Image-Objekte ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)

        End If

        
    End Sub

    Private Sub ToolStripButton_NoObjects_Click(sender As Object, e As EventArgs) Handles ToolStripButton_NoObjects.Click
        objTransaction.ClearItems()
        If objDataWork_Images.GetDataObjectsOfImages().GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If ToolStripButton_NoObjects.Checked Then
                Dim objOList_ImageObjects = objDataWork_Images.OList_ImageObjects(objOItem_Image)
                If objOList_ImageObjects.Any Then
                    Dim objORel_ImageObject_To_NoObject = New clsObjectRel With {.ID_Object = objOList_ImageObjects.First().ID_Object, _
                                                                                 .ID_Other = objOItem_NoObject.GUID, _
                                                                                 .ID_RelationType = objLocalConfig.OItem_RelationType_has.GUID}

                    Dim objOItem_Result = objTransaction.do_Transaction(objORel_ImageObject_To_NoObject, False, True)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        Dim objORel_ImageObject_To_Image = New clsObjectRel With {.ID_Object = objOList_ImageObjects.First().ID_Object, _
                                                                                  .ID_Other = objOItem_Image.GUID, _
                                                                                  .ID_RelationType = objLocalConfig.OItem_RelationType_located_in.GUID}

                        objOItem_Result = objTransaction.do_Transaction(objORel_ImageObject_To_Image, False, True)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            ToolStripButton_NoObjects.Enabled = False
                            ToolStripButton_NoObjects.Checked = False
                            ToolStripButton_NoObjects.Enabled = True
                        Else
                            objTransaction.rollback()
                        End If
                    End If

                End If

            Else

                If Not objDataWork_Images.NoObjects(objOItem_Image, objOItem_NoObject) Then
                    Dim objOItem_ImageObject = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                                         .Name = objOItem_Image.Name, _
                                                                         .GUID_Parent = objLocalConfig.OItem_Type_Image_Objects.GUID, _
                                                                         .Type = objLocalConfig.Globals.Type_Object}

                    Dim objOItem_Result = objTransaction.do_Transaction(objOItem_ImageObject)
                    If (objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID) Then
                        Dim objORel_ImageObject_To_Image = objRelationConfig.Rel_ObjectRelation(objOItem_ImageObject, _
                                                                                                    objOItem_Image, _
                                                                                                    objLocalConfig.OItem_RelationType_located_in)
                        objOItem_Result = objTransaction.do_Transaction(objORel_ImageObject_To_Image)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Dim objORel_ImageObject_To_NoImage = objRelationConfig.Rel_ObjectRelation(objOItem_ImageObject, _
                                                                                                      objOItem_NoObject, _
                                                                                                      objLocalConfig.OItem_RelationType_has)
                            objOItem_Result = objTransaction.do_Transaction(objORel_ImageObject_To_NoImage)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                ToolStripButton_NoObjects.Enabled = False
                                ToolStripButton_NoObjects.Checked = True
                                ToolStripButton_NoObjects.Enabled = True

                                objDataWork_Images.OList_ImageObjects.Add(objORel_ImageObject_To_Image)
                                objDataWork_Images.OList_ImageObjects.Add(objORel_ImageObject_To_NoImage)

                                Initialize_Objects(objOItem_Image, objOItem_Class_Object, objOItem_NoObject)
                            Else
                                objTransaction.rollback()
                            End If

                        Else
                            objTransaction.rollback()
                        End If
                    End If
                Else
                    ToolStripButton_NoObjects.Enabled = False
                    ToolStripButton_NoObjects.Checked = True
                    ToolStripButton_NoObjects.Enabled = False
                End If
            End If
        End If

    End Sub
End Class
