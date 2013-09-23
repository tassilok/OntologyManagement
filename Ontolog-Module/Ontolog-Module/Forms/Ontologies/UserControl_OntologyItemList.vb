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
        ChangeToolStripMenuItem.Enabled = False
        If DataGridView_OItems.SelectedCells.Count =1 Then
            If DataGridView_OItems.Columns(DataGridView_OItems.SelectedCells(0).ColumnIndex).DataPropertyName = "Name_OntologyRelationRule" Then
                ChangeToolStripMenuItem.Enabled = True
            End If
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
End Class
