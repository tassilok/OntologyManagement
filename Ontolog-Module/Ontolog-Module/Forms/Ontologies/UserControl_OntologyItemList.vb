Imports OntologyClasses.BaseClasses
Imports Structure_Module
Public Class UserControl_OntologyItemList

    Private objDataWork_Ontologies As clsDataWork_Ontologies
    Private objFrmMain As frmMain
    Private objTransaction As clsTransaction
    Private objRelationConfig As clsRelationConfig
    Private objOItem_Ontology As clsOntologyItem

    Private objOList_OntologyItems As SortableBindingList(Of clsOntologyItemsOfOntologies)

    Private objFrm_ObjectEdit As frm_ObjectEdit

    Public ReadOnly Property OList_OntologyItems As List(Of clsOntologyItemsOfOntologies)
        Get
            Return objOList_OntologyItems.ToList()
        End Get
    End Property

    Public Event DataLoaded


    Public ReadOnly Property SelectedRows As DataGridViewSelectedRowCollection
        Get
            Return DataGridView_OItems.SelectedRows
        End Get
    End Property

    Public ReadOnly Property Rows As DataGridViewRowCollection
        Get
            Return DataGridView_OItems.Rows
        End Get
    End Property

    Public Sub New(DataWork_Ontologies As clsDataWork_Ontologies)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objDataWork_Ontologies = DataWork_Ontologies

        initialize()
    End Sub

    Public Sub New(Globals As clsGlobals)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objDataWork_Ontologies = New clsDataWork_Ontologies(Globals)
        objDataWork_Ontologies.GetData_001_OntologyJoinsOfOntologies()
        If objDataWork_Ontologies.OItem_Result_OntologyJoinsOfOntologies.GUID= objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
            objDataWork_Ontologies.GetData_002_OntologyItemsOfJoins()
            If objDataWork_Ontologies.OItem_Result_OntologyItemsOfJoins.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID then
                objDataWork_Ontologies.GetData_003_OntologyItemsOfOntologies()
                If objDataWork_Ontologies.OItem_Result_OntologyItemsOfOntologies.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                    objDataWork_Ontologies.GetData_OntologyRelationRulesOfOItems()
                    If objDataWork_Ontologies.OItem_OntologyRelationRulesOfOItems.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                        objDataWork_Ontologies.GetData_RefsOfOntologyItems()
                        initialize()
                    Else 
                        MsgBox("Die Ontology-Items konnten nicht ermittelt werden!",MsgBoxStyle.Critical)
                    End If
                Else 
                    MsgBox("Die Ontology-Items konnten nicht ermittelt werden!",MsgBoxStyle.Critical)
                End If
            Else 
                MsgBox("Die Ontology-Items konnten nicht ermittelt werden!",MsgBoxStyle.Critical)
            End If
        Else 
            MsgBox("Die Ontology-Items konnten nicht ermittelt werden!",MsgBoxStyle.Critical)
        End If
        
        
        
        
    End Sub

    Private Sub initialize()
        objTransaction = New clsTransaction(objDataWork_Ontologies.LocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objDataWork_Ontologies.LocalConfig.Globals)
    End Sub

    Public Sub initialize_List(OItem_Ontology As clsOntologyItem)
        objOItem_Ontology = OItem_Ontology
        If Not OItem_Ontology Is Nothing Then
            objOList_OntologyItems = New SortableBindingList(Of clsOntologyItemsOfOntologies)((From objOntology In objDataWork_Ontologies.OList_RefsOfOntologyItems
                           Where objOntology.ID_Ontology = OItem_Ontology.GUID).ToList())


            DataGridView_OItems.DataSource = objOList_OntologyItems
            DataGridView_OItems.Columns(0).Visible = False
            DataGridView_OItems.Columns(1).Visible = False
            DataGridView_OItems.Columns(3).Visible = False
            DataGridView_OItems.Columns(5).Visible = False
            DataGridView_OItems.Columns(7).Visible = False
            
            
        Else
            DataGridView_OItems.DataSource = Nothing
        End If

        ToolStripLabel_Count.Text = DataGridView_OItems.RowCount
        RaiseEvent DataLoaded
    End Sub

    Private Sub ContextMenuStrip_OItems_Opening( sender As Object,  e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_OItems.Opening
        AddToolStripMenuItem.Enabled = False
        ChangeToolStripMenuItem.Enabled = False
        RemoveToolStripMenuItem.Enabled = False
        If DataGridView_OItems.SelectedCells.Count =1 Then
            If DataGridView_OItems.Columns(DataGridView_OItems.SelectedCells(0).ColumnIndex).DataPropertyName = "Name_OntologyRelationRule" Then
                ChangeToolStripMenuItem.Enabled = True
            End If
        End If

        If DataGridView_OItems.SelectedRows.Count>0 Then
            RemoveToolStripMenuItem.Enabled = True
        End If

        If Not objOItem_Ontology Is Nothing Then
            AddToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub ChangeToolStripMenuItem_Click( sender As Object,  e As EventArgs) Handles ChangeToolStripMenuItem.Click
        
        Dim objDGVC_Selected = DataGridView_OItems.Rows(DataGridView_OItems.SelectedCells(0).RowIndex).Cells("ID_OntologyItem")
        
        Dim objOItem_OntologyItem = new clsOntologyItem With { .GUID = objDGVC_Selected.Value.ToString(), _
                                                          .GUID_Parent = objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyItems.GUID, _
                                                          .Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Object }

        objFrmMain = new frmMain(objDataWork_Ontologies.LocalConfig.Globals, _
                                 objDataWork_Ontologies.LocalConfig.Globals.Type_Class, _
                                 objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyRelationRule)
        objFrmMain.Applyable = True
        objFrmMain.ShowDialog(me)
        If objFrmMain.DialogResult=DialogResult.OK Then
            If objFrmMain.OList_Simple.Count=1 Then
                If objFrmMain.OList_Simple.First().GUID_Parent = objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyRelationRule.GUID Then
                    Dim objOItem_Rule = objFrmMain.OList_Simple.First()
                    Dim objOR_OntologyItem_To_OntologyRule = objDataWork_Ontologies.Rel_OntologyItem_To_OntologyRule(objOItem_OntologyItem,objOItem_Rule)
                    objTransaction.ClearItems()
                    Dim objOItem_Result = objTransaction.do_Transaction(objOR_OntologyItem_To_OntologyRule,True)
                    If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                        objDataWork_Ontologies.GetData_OntologyRelationRulesOfOItems()
                        While objDataWork_Ontologies.OItem_OntologyRelationRulesOfOItems.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Nothing.GUID

                        End While
                        If objDataWork_Ontologies.OItem_OntologyRelationRulesOfOItems.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                            objDataWork_Ontologies.GetData_RefsOfOntologyItems()
                            While objDataWork_Ontologies.OItem_Result_RefsOfOntologyItems.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Nothing.GUID

                            End While
                            If objDataWork_Ontologies.OItem_OntologyRelationRulesOfOItems.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                initialize_List(objOItem_Ontology)
                            Else 
                                MsgBox("Die Regel konnte nicht ausgelesen werden!",MsgBoxStyle.Exclamation)
                            End If
                        Else 
                            MsgBox("Die Regel konnte nicht ausgelesen werden!",MsgBoxStyle.Exclamation)
                        End If
                    Else 
                        MsgBox("Die Regel konnte nicht gesetzt werden!",MsgBoxStyle.Exclamation)
                        objTransaction.rollback()
                    End If
                Else 
                    MsgBox("Bitte nur eine Regel auswählen!",MsgBoxStyle.Information)
                End If
            Else 
                MsgBox("Bitte nur eine Regel auswählen!",MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        objFrmMain = New frmMain(objDataWork_Ontologies.LocalConfig.Globals)
        objFrmMain.Applyable = True
        objFrmMain.ShowDialog(Me)
        If objFrmMain.DialogResult = DialogResult.OK Then
            Dim intToDo = objFrmMain.OList_Simple.Count
            Dim intDone = 0

            For Each objOItem In objFrmMain.OList_Simple
                Dim objOItem_OItem = objDataWork_Ontologies.Get_OntologyItemOfOntology(objOItem_Ontology, objOItem)
                If objOItem_OItem Is Nothing Then
                    objOItem_OItem = New clsOntologyItem With {.GUID = objDataWork_Ontologies.LocalConfig.Globals.NewGUID, _
                                                              .Name = objOItem.Name, _
                                                              .GUID_Parent = objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyItems.GUID, _
                                                              .Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Object}
                    objTransaction.ClearItems()

                    Dim objOItem_Result = objTransaction.do_Transaction(objOItem_OItem)
                    If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                        Dim objRelationType = If(objOItem.Type = objDataWork_Ontologies.LocalConfig.Globals.Type_AttributeType, objDataWork_Ontologies.LocalConfig.Globals.RelationType_belongingAttribute, _
                                                  If(objOItem.Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Class, objDataWork_Ontologies.LocalConfig.Globals.RelationType_belongingClass, _
                                                      If(objOItem.Type = objDataWork_Ontologies.LocalConfig.Globals.Type_RelationType, objDataWork_Ontologies.LocalConfig.Globals.RelationType_belongingRelationType, _
                                                          If(objOItem.Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Object, objDataWork_Ontologies.LocalConfig.Globals.RelationType_belongingObject, Nothing))))

                        If Not objRelationType Is Nothing Then
                            Dim objRel_OntologyItemToRef = objRelationConfig.Rel_ObjectRelation(objOItem_OItem, objOItem, objRelationType)

                            objOItem_Result = objTransaction.do_Transaction(objRel_OntologyItemToRef, True)
                            If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                Dim objORel_OntologyItem_To_Ontology = objRelationConfig.Rel_ObjectRelation(objOItem_Ontology, objOItem_OItem, objDataWork_Ontologies.objLocalConfig.Globals.RelationType_contains)

                                objOItem_Result = objTransaction.do_Transaction(objORel_OntologyItem_To_Ontology)

                                If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                    objDataWork_Ontologies.OList_RefsOfOntologyItems.Add(New clsOntologyItemsOfOntologies With {.ID_Ontology = objOItem_Ontology.GUID, _
                                                                                                                                .ID_OntologyItem = objOItem_OItem.GUID, _
                                                                                                                                .Name_OntologyItem = objOItem_OItem.Name, _
                                                                                                                                .ID_Parent_Ref = objOItem.GUID_Parent, _
                                                                                                                                .ID_Ref = objOItem.GUID, _
                                                                                                                                .Name_Ref = objOItem.Name, _
                                                                                                                                .Type_Ref = objOItem.Type})

                                    initialize_List(objOItem_Ontology)
                                Else
                                    objTransaction.rollback()
                                End If

                            Else
                                objTransaction.rollback()
                            End If
                        Else
                            objTransaction.rollback()
                        End If
                        

                    End If


                Else
                    If objOItem_OItem.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                        intDone += 1
                    End If
                End If

            Next
        End If
    End Sub

    Private Sub DataGridView_OItems_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_OItems.RowHeaderMouseDoubleClick
        Dim objDGVR_Selected As DataGridViewRow
        objDGVR_Selected = DataGridView_OItems.Rows(e.RowIndex)
        Dim objOntologyItemOfOntology As clsOntologyItemsOfOntologies = objDGVR_Selected.DataBoundItem

        Dim objOList_Objects = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID = objOntologyItemOfOntology.ID_OntologyItem, _
                                                                                            .Name = objOntologyItemOfOntology.Name_OntologyItem, _
                                                                                            .GUID_Parent = objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyItems.GUID, _
                                                                                            .Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Object}}


        objFrm_ObjectEdit = New frm_ObjectEdit(objDataWork_Ontologies.LocalConfig.Globals, objOList_Objects, 0, objDataWork_Ontologies.LocalConfig.Globals.Type_Object, Nothing)
        objFrm_ObjectEdit.ShowDialog(Me)
    End Sub
End Class
