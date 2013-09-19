Imports Structure_Module
Public Class UserControl_OntologyJoins

    Private objDataWork_Ontologies As clsDataWork_Ontologies
    Private objFrmOntologyModule As frmMain
    Private objFrmAttributeTypeOrRelationType As frmAttributeTypeOrRelationType
    Private objTransaction_Ontologies As clsTransaction_Ontologies

    Public Sub New(DataWork_Ontologies As clsDataWork_Ontologies)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objDataWork_Ontologies = DataWork_Ontologies
        initialize()
        
    End Sub
    Private sub initialize
        objTransaction_Ontologies = new clsTransaction_Ontologies(objDataWork_Ontologies)
    End Sub

    Public Sub initialize_Joins(OItem_Ontology As clsOntologyItem)
        If Not OItem_Ontology Is Nothing Then
            Dim objOList_Joins = New SortableBindingList(Of clsOntologyJoins)((From objJoin In objDataWork_Ontologies.OList_OntologyJoins
                              Where objJoin.ID_Ontology = OItem_Ontology.GUID).ToList())

            DataGridView_Joins.DataSource = objOList_Joins

            DataGridView_Joins.Columns(0).Visible = False
            DataGridView_Joins.Columns(1).Visible = False
            DataGridView_Joins.Columns(2).Visible = False
            DataGridView_Joins.Columns(3).Visible = False
            DataGridView_Joins.Columns(5).Visible = False
            DataGridView_Joins.Columns(7).Visible = False
            DataGridView_Joins.Columns(9).Visible = False
            DataGridView_Joins.Columns(11).Visible = False
            DataGridView_Joins.Columns(13).Visible = False
            DataGridView_Joins.Columns(15).Visible = False
        Else
            DataGridView_Joins.DataSource = Nothing
        End If
        
        ToolStripLabel_Count.Text = DataGridView_Joins.RowCount.ToString
    End Sub

    Private Sub ContextMenuStrip_Items_Opening( sender As Object,  e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Items.Opening
        ChangeToolStripMenuItem.Enabled = False
        if DataGridView_Joins.SelectedCells.Count = 1 Then
            Select Case DataGridView_Joins.Columns(DataGridView_Joins.SelectedCells(0).ColumnIndex).DataPropertyName
                Case "Name_OntolgyRelationRule", "Name_OItem1", "Name_OItem2", "Name_OItem3"
                    ChangeToolStripMenuItem.Enabled = True
                
                    
                    
            End Select
            
        End If
    End Sub

    Private Sub ChangeToolStripMenuItem_Click( sender As Object,  e As EventArgs) Handles ChangeToolStripMenuItem.Click
        if DataGridView_Joins.SelectedCells.Count = 1 Then
           Dim objDGVC_Selected = DataGridView_Joins.SelectedCells(0)    
            Dim objOntologyJoin As clsOntologyJoins = DataGridView_Joins.Rows(objDGVC_Selected.RowIndex).DataBoundItem
            Select Case DataGridView_Joins.Columns(objDGVC_Selected.ColumnIndex).DataPropertyName
                Case "Name_OntolgyRelationRule"
                    objFrmOntologyModule = New frmMain(objDataWork_Ontologies.LocalConfig.Globals,objDataWork_Ontologies.LocalConfig.Globals.Type_Class,objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyRelationRule)
                    objFrmOntologyModule.Applyable = True
                    objFrmOntologyModule.ShowDialog(me)
                    If objFrmOntologyModule.OList_Simple.Count=1 Then
                        If objFrmOntologyModule.OList_Simple.First().Type =objDataWork_Ontologies.LocalConfig.Globals.Type_Class Then
                            Dim objOItem_Class = objFrmOntologyModule.OList_Simple.First()
                            If Not objOntologyJoin.ID_OItem1 = objOItem_Class.GUID then
                                Dim objOItem_Result =  objTransaction_Ontologies.save_JoinToOItem(New clsOntologyItem With 
                                                                                    {.GUID = objOntologyJoin.ID_Join, 
                                                                                     .GUID_Parent = objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyJoin.GUID, 
                                                                                     .Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Object },
                                                                           objOItem_Class, 1)
                                If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then

                                End If
                                
                            End If

                        Else
                            MsgBox("Bitte nur eine Klasse auswählen!",MsgBoxStyle.Exclamation)
                        End If
                    Else
                        MsgBox("Bitte nur eine Klasse auswählen!",MsgBoxStyle.Exclamation)
                    End If
                    
                Case "Name_OItem1"
                    objFrmOntologyModule = New frmMain(objDataWork_Ontologies.LocalConfig.Globals,objDataWork_Ontologies.LocalConfig.Globals.Type_Class)
                    objFrmOntologyModule.Applyable = True
                    objFrmOntologyModule.ShowDialog(me)
                Case "Name_OItem2"
                    If Not objOntologyJoin.ID_OItem3 = Nothing then
                        objFrmOntologyModule = New frmMain(objDataWork_Ontologies.LocalConfig.Globals,objDataWork_Ontologies.LocalConfig.Globals.Type_RelationType)
                        objFrmOntologyModule.Applyable = True
                        objFrmOntologyModule.ShowDialog(me)
                    Else
                        objFrmAttributeTypeOrRelationType = new frmAttributeTypeOrRelationType(objDataWork_Ontologies.LocalConfig.Globals)
                        objFrmAttributeTypeOrRelationType.ShowDialog(me)
                    End If
                Case "Name_OItem3"
                    Dim boolOpen = False
                    If Not objOntologyJoin.ID_OItem2 = Nothing Then
                        If objOntologyJoin.Ontology_OItem2 = objDataWork_Ontologies.LocalConfig.Globals.Type_RelationType Then
                            boolOpen = True
                        End If
                    Else
                        boolOpen = True
                    End If
                    If boolOpen then
                        objFrmOntologyModule = New frmMain(objDataWork_Ontologies.LocalConfig.Globals,objDataWork_Ontologies.LocalConfig.Globals.Type_Class)
                        objFrmOntologyModule.Applyable = True
                        objFrmOntologyModule.ShowDialog(me)
                    Else 
                        MsgBox("Sie können kein drittes Element hinzufügen, da das Zweite ein Attributtyp ist!",MsgBoxStyle.Exclamation)
                    End If
                    
            End Select
        End If
        
    End Sub
End Class
