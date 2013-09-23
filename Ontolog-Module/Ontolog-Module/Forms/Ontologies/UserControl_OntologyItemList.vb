Imports Structure_Module
Public Class UserControl_OntologyItemList

    Private objDataWork_Ontologies As clsDataWork_Ontologies
    Private objFrmMain As frmMain
    Private objTransaction As clsTransaction
    Private objOItem_Ontology As clsOntologyItem

    Public Sub New(DataWork_Ontologies As clsDataWork_Ontologies)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objDataWork_Ontologies = DataWork_Ontologies

        initialize()
    End Sub

    Private Sub initialize()
        objTransaction = new clsTransaction(objDataWork_Ontologies.LocalConfig.Globals)
    End Sub

    Public Sub initialize_List(OItem_Ontology As clsOntologyItem)
        objOItem_Ontology = OItem_Ontology
        If Not OItem_Ontology Is Nothing Then
            Dim objOList = New SortableBindingList(Of clsOntologyItemsOfOntologies)((From objOntology In objDataWork_Ontologies.OList_RefsOfOntologyItems
                           Where objOntology.ID_Ontology = OItem_Ontology.GUID).ToList())


            DataGridView_OItems.DataSource = objOList
            DataGridView_OItems.Columns(0).Visible = False
            DataGridView_OItems.Columns(1).Visible = False
            DataGridView_OItems.Columns(2).Visible = False
            DataGridView_OItems.Columns(3).Visible = True
            DataGridView_OItems.Columns(4).Visible = False
            DataGridView_OItems.Columns(5).Visible = True
            DataGridView_OItems.Columns(6).Visible = False
            DataGridView_OItems.Columns(7).Visible = True
            
        Else
            DataGridView_OItems.DataSource = Nothing
        End If

    End Sub

    Private Sub ContextMenuStrip_OItems_Opening( sender As Object,  e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_OItems.Opening
        AddToolStripMenuItem.Enabled = False
        ChangeToolStripMenuItem.Enabled = False
        If DataGridView_OItems.SelectedCells.Count =1 Then
            If DataGridView_OItems.Columns(DataGridView_OItems.SelectedCells(0).ColumnIndex).DataPropertyName = "Name_OntologyRelationRule" Then
                ChangeToolStripMenuItem.Enabled = True
            End If
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
        If objFrmMain.DialogResult = DialogResult.OK Then
            Dim intToDo = objFrmMain.OList_Simple.Count
            Dim intDone = 0

            For Each objOItem In objFrmMain.OList_Simple
                Dim objOItem_OItem = objDataWork_Ontologies.Get_OntologyItemOfOntology(objOItem_Ontology, objOItem)
                If objOItem_OItem Is Nothing Then
                    objOItem_OItem = New clsOntologyItem With {.GUID = objDataWork_Ontologies.LocalConfig.Globals.NewGUID, _
                                                              .Name = objOItem.Name, _
                                                              .GUID_Parent = objOItem.GUID_Parent, _
                                                              .Type = objOItem.Type}
                    objTransaction.ClearItems()

                    Dim objOItem_Result = objTransaction.do_Transaction(objOItem_OItem)
                    If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                        Dim objRel_OntologyItemToRef = objDataWork_Ontologies.Rel_OntologyItemToRef(objOItem_OItem, objOItem)
                        objOItem_Result = objTransaction.do_Transaction(objRel_OntologyItemToRef, True)
                        If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                            Dim objORel_OntologyItem_To_Ontology = objDataWork_Ontologies.Rel_Ontology_To_OntologyItem(objOItem_Ontology, objOItem_OItem)

                            objOItem_Result = objTransaction.do_Transaction(objORel_OntologyItem_To_Ontology, True)

                            If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                objDataWork_Ontologies.OList_RefsOfOntologyItems.Add(New clsOntologyItemsOfOntologies With {.ID_Ontology = objOItem_Ontology.GUID, _
                                                                                                                            .ID_OntologyItem = objOItem_OItem.GUID, _
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

                    End If


                Else
                    If objOItem_OItem.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                        intDone += 1
                    End If
                End If

            Next
        End If
    End Sub
End Class
