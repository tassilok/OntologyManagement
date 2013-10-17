Imports OntologyClasses.BaseClasses
Imports Structure_Module
Public Class UserControl_OntologyJoins

    Private objDataWork_Ontologies As clsDataWork_Ontologies
    Private objFrmOntologyModule As frmMain
    Private objFrmJoinSelector As frmJoinSelector
    Private objFrmAttributeTypeOrRelationType As frmAttributeTypeOrRelationType
    Private objFrmObjectEdit As frm_ObjectEdit
    Private objTransaction_Ontologies As clsTransaction
    Private objTransaction_Ontology As clsTransaction_Ontologies

    Private objOItem_Ontology As clsOntologyItem

    Public Sub New(DataWork_Ontologies As clsDataWork_Ontologies)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objDataWork_Ontologies = DataWork_Ontologies
        initialize()
        
    End Sub
    Private sub initialize
        objTransaction_Ontologies = New clsTransaction(objDataWork_Ontologies.LocalConfig.Globals)
        objTransaction_Ontology = New clsTransaction_Ontologies(objDataWork_Ontologies)
    End Sub

    Public Sub initialize_Joins(OItem_Ontology As clsOntologyItem)
        objOItem_Ontology = OItem_Ontology
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
                    If objFrmOntologyModule.DialogResult=DialogResult.OK Then
                        If objFrmOntologyModule.OList_Simple.Count=1 Then
                        If objFrmOntologyModule.OList_Simple.First().Type =objDataWork_Ontologies.LocalConfig.Globals.Type_Object Then
                            If objFrmOntologyModule.OList_Simple.First().GUID_Parent = objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyRelationRule.GUID Then
                                Dim objOItem_Rule = objFrmOntologyModule.OList_Simple.First()
                                Dim objOItem_Join = New clsOntologyItem With {.GUID = objOntologyJoin.ID_Join, _
                                                                              .GUID_Parent = objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyJoin.GUID, _
                                                                              .Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Object}

                                objOItem_Join = objDataWork_Ontologies.GetData_OItemByGuidAndType(objOntologyJoin.ID_Join, objDataWork_Ontologies.LocalConfig.Globals.Type_Object)
                                If Not objOItem_Join Is Nothing Then
                                    If objOItem_Join.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                        Dim objOR_JoinToRule = objDataWork_Ontologies.Rel_OntologyJoinToRule(objOItem_Join, objOItem_Rule)
                                        objTransaction_Ontologies.ClearItems()
                                        Dim objOItem_Result = objTransaction_Ontologies.do_Transaction(objOR_JoinToRule, True)
                                        If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                            Dim objUpd = (From objJoin In objDataWork_Ontologies.OList_OntologyJoins
                                                         Select New clsOntologyJoins With {.ID_Join = objJoin.ID_Join, _
                                                                                           .ID_OItem1 = objJoin.ID_OItem1, _
                                                                                           .ID_OItem2 = objJoin.ID_OItem2, _
                                                                                           .ID_OItem3 = objJoin.ID_OItem3, _
                                                                                           .ID_Ontology = objJoin.ID_Ontology, _
                                                                                           .ID_OntologyRelationRule = If (objjoin.ID_Join = objoitem_join.GUID, objOItem_Rule.GUID, objJoin.ID_OntologyRelationRule), _
                                                                                           .ID_ParentOItem1 = objJoin.ID_ParentOItem1, _
                                                                                           .ID_ParentOItem2 = objJoin.ID_ParentOItem2, _
                                                                                           .ID_ParentOItem3 = objjoin.ID_ParentOItem3, _
                                                                                           .Name_Join = objJoin.Name_Join, _
                                                                                           .Name_OItem1 = objJoin.Name_OItem1, _
                                                                                           .Name_OItem2 = objJoin.Name_OItem2, _
                                                                                           .Name_OItem3 = objJoin.Name_OItem3, _
                                                                                           .Name_OntolgyRelationRule = If (objjoin.ID_Join = objoitem_join.GUID, objOItem_Rule.Name, objJoin.Name_OntolgyRelationRule), _
                                                                                           .Ontology_OItem1 = objJoin.Ontology_OItem1, _
                                                                                           .Ontology_OItem2 = objJoin.Ontology_OItem2, _
                                                                                           .Ontology_OItem3 = objJoin.Ontology_OItem3 }).tolist()
                                            objDataWork_Ontologies.OList_OntologyJoins = objUpd
                                                         
                                                         
                                            initialize_Joins(objOItem_Ontology)
                                        Else
                                            objTransaction_Ontologies.rollback()
                                            MsgBox("Die Regel konnte nicht hinzugefügt werden!", MsgBoxStyle.Exclamation)
                                        End If
                                    Else
                                        MsgBox("Die Regel konnte nicht hinzugefügt werden!", MsgBoxStyle.Exclamation)
                                    End If
                                Else
                                    MsgBox("Die Regel konnte nicht hinzugefügt werden!", MsgBoxStyle.Exclamation)
                                End If


                            Else
                                MsgBox("Bitte nur eine Regel auswählen!", MsgBoxStyle.Exclamation)
                            End If

                        Else
                            MsgBox("Bitte nur eine Regel auswählen!", MsgBoxStyle.Exclamation)
                        End If
                    Else
                        MsgBox("Bitte nur eine Regel auswählen!", MsgBoxStyle.Exclamation)
                    End If
                    End If
                    

                Case "Name_OItem1"
                    objFrmOntologyModule = New frmMain(objDataWork_Ontologies.LocalConfig.Globals, objDataWork_Ontologies.LocalConfig.Globals.Type_Class)
                    objFrmOntologyModule.Applyable = True
                    objFrmOntologyModule.ShowDialog(Me)
                Case "Name_OItem2"
                    If Not objOntologyJoin.ID_OItem3 = Nothing Then
                        objFrmOntologyModule = New frmMain(objDataWork_Ontologies.LocalConfig.Globals, objDataWork_Ontologies.LocalConfig.Globals.Type_RelationType)
                        objFrmOntologyModule.Applyable = True
                        objFrmOntologyModule.ShowDialog(Me)
                    Else
                        objFrmAttributeTypeOrRelationType = New frmAttributeTypeOrRelationType(objDataWork_Ontologies.LocalConfig.Globals)
                        objFrmAttributeTypeOrRelationType.ShowDialog(Me)
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
                    If boolOpen Then
                        objFrmOntologyModule = New frmMain(objDataWork_Ontologies.LocalConfig.Globals, objDataWork_Ontologies.LocalConfig.Globals.Type_Class)
                        objFrmOntologyModule.Applyable = True
                        objFrmOntologyModule.ShowDialog(Me)
                    Else
                        MsgBox("Sie können kein drittes Element hinzufügen, da das Zweite ein Attributtyp ist!", MsgBoxStyle.Exclamation)
                    End If

            End Select
        End If

    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Dim objOItem_OItemRight As clsOntologyItem
        Dim objOItem_OItemLeft As clsOntologyItem
        Dim objOItem_OItemRelationType As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        If Not objOItem_Ontology Is Nothing Then
            objFrmJoinSelector = New frmJoinSelector(objDataWork_Ontologies)
            objFrmJoinSelector.ShowDialog(Me)
            If objFrmJoinSelector.DialogResult = DialogResult.OK Then
               
                Dim objOItem_Join = objDataWork_Ontologies.GetData_OntologyItemsOfJoinsExplicit(objOItem_Ontology, objFrmJoinSelector.OItem_Left, objFrmJoinSelector.OItem_Right, objFrmJoinSelector.OItem_RelationType)

                If objOItem_Join Is Nothing Then
                    objOItem_Join = New clsOntologyItem With {.GUID = objDataWork_Ontologies.LocalConfig.Globals.NewGUID, _
                                                              .Name = objOItem_Ontology.Name, _
                                                              .GUID_Parent = objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyJoin.GUID, _
                                                              .Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Object}

                    objTransaction_Ontologies.ClearItems()
                    objOItem_Result = objTransaction_Ontologies.do_Transaction(objOItem_Join)
                    If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                        objOItem_OItemLeft = objDataWork_Ontologies.Get_OntologyItemOfOntology(objOItem_Ontology, objFrmJoinSelector.OItem_Left)
                        If objOItem_OItemLeft Is Nothing Then
                            objOItem_OItemLeft = New clsOntologyItem With {.GUID = objDataWork_Ontologies.LocalConfig.Globals.NewGUID, _
                                                                       .Name = objFrmJoinSelector.OItem_Left.Name, _
                                                                       .GUID_Parent = objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyItems.GUID, _
                                                                       .Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Object}

                            objOItem_Result = objTransaction_Ontologies.do_Transaction(objOItem_OItemLeft)
                            If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                Dim objORel_OItemToRef = objDataWork_Ontologies.Rel_OntologyItemToRef(objOItem_OItemLeft, objFrmJoinSelector.OItem_Left)
                                objOItem_Result = objTransaction_Ontologies.do_Transaction(objORel_OItemToRef, True)

                            End If
                        Else
                            If objOItem_OItemLeft.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                objOItem_Result = objDataWork_Ontologies.LocalConfig.Globals.LState_Success
                            Else
                                objOItem_Result = objDataWork_Ontologies.LocalConfig.Globals.LState_Error
                            End If
                        End If
                        
                        If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                            Dim boolHierarchy = False
                            If Not objFrmJoinSelector.OItem_Right Is Nothing Then 
                                If objFrmJoinSelector.OItem_Left.GUID = objFrmJoinSelector.OItem_Right.GUID Then
                                    boolHierarchy = True
                                End If 
                                
                            End If
                            Dim objORel_OntologyJoinToOItemLeft = objDataWork_Ontologies.Rel_OntologyJoinToOItem(objOItem_Join, objOItem_OItemLeft, If(boolHierarchy,4,1))
                            objOItem_Result = objTransaction_Ontologies.do_Transaction(objORel_OntologyJoinToOItemLeft)
                            If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                If Not objFrmJoinSelector.OItem_Right Is Nothing And Not boolHierarchy Then
                                    objOItem_OItemRight = objDataWork_Ontologies.Get_OntologyItemOfOntology(objOItem_Ontology, objFrmJoinSelector.OItem_Right)
                                    If objOItem_OItemRight Is Nothing Then
                                        objOItem_OItemRight = New clsOntologyItem With {.GUID = objDataWork_Ontologies.LocalConfig.Globals.NewGUID, _
                                                                       .Name = objFrmJoinSelector.OItem_Right.Name, _
                                                                       .GUID_Parent = objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyItems.GUID, _
                                                                       .Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Object}

                                        objOItem_Result = objTransaction_Ontologies.do_Transaction(objOItem_OItemRight)
                                        If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                            Dim objORel_OItemToRef = objDataWork_Ontologies.Rel_OntologyItemToRef(objOItem_OItemRight, objFrmJoinSelector.OItem_Right)
                                            objOItem_Result = objTransaction_Ontologies.do_Transaction(objORel_OItemToRef, True)

                                            
                                        End If
                                    Else
                                        If objOItem_OItemRight.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                            objOItem_Result = objDataWork_Ontologies.LocalConfig.Globals.LState_Success
                                        Else
                                            objOItem_Result = objDataWork_Ontologies.LocalConfig.Globals.LState_Error
                                        End If
                                    End If
                                    
                                    If Not objFrmJoinSelector.OItem_Right Is Nothing Then
                                        Dim objORel_OntologyJoinToOItemRight = objDataWork_Ontologies.Rel_OntologyJoinToOItem(objOItem_Join, objOItem_OItemRight, 2)
                                        objOItem_Result = objTransaction_Ontologies.do_Transaction(objORel_OntologyJoinToOItemRight)
                                    End If
                                Else
                                    objOItem_OItemRight = Nothing
                                    objOItem_Result = objDataWork_Ontologies.LocalConfig.Globals.LState_Success
                                End If

                                

                                If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                    
                                    If Not objFrmJoinSelector.OItem_RelationType Is Nothing Then
                                        objOItem_OItemRelationType = objDataWork_Ontologies.Get_OntologyItemOfOntology(objOItem_Ontology, objFrmJoinSelector.OItem_RelationType)
                                        If objOItem_OItemRelationType Is Nothing Then
                                            objOItem_OItemRelationType = New clsOntologyItem With {.GUID = objDataWork_Ontologies.LocalConfig.Globals.NewGUID, _
                                                                   .Name = objFrmJoinSelector.OItem_RelationType.Name, _
                                                                   .GUID_Parent = objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyItems.GUID, _
                                                                   .Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Object}


                                            objOItem_Result = objTransaction_Ontologies.do_Transaction(objOItem_OItemRelationType)
                                            If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                                Dim objORel_OItemToRef = objDataWork_Ontologies.Rel_OntologyItemToRef(objOItem_OItemRelationType, objFrmJoinSelector.OItem_RelationType)
                                                objOItem_Result = objTransaction_Ontologies.do_Transaction(objORel_OItemToRef, True)

                                            End If
                                        Else
                                            If objOItem_OItemRelationType.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                                objOItem_Result = objDataWork_Ontologies.LocalConfig.Globals.LState_Success
                                            Else
                                                objOItem_Result = objDataWork_Ontologies.LocalConfig.Globals.LState_Error
                                            End If
                                        End If


                                        If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                            Dim objORel_OntologyJoinToOItemRelationType = objDataWork_Ontologies.Rel_OntologyJoinToOItem(objOItem_Join, objOItem_OItemRelationType, 3)
                                            objOItem_Result = objTransaction_Ontologies.do_Transaction(objORel_OntologyJoinToOItemRelationType)


                                        Else

                                            objTransaction_Ontologies.rollback()
                                            MsgBox("Der Join konnte nicht gespeichert werden!", MsgBoxStyle.Exclamation)
                                        End If
                                    Else
                                        objOItem_OItemRelationType = Nothing
                                        objOItem_Result = objDataWork_Ontologies.LocalConfig.Globals.LState_Success
                                    End If
                                    If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then

                                        Dim objORel_OntologyToOntologyJoin = objDataWork_Ontologies.Rel_OntologyToOntologyJoin(objOItem_Ontology, objOItem_Join)
                                        objOItem_Result = objTransaction_Ontologies.do_Transaction(objORel_OntologyToOntologyJoin)
                                        If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                            objDataWork_Ontologies.OList_OntologyJoins.Add(New clsOntologyJoins With {.ID_Join = objOItem_Join.GUID, _
                                                                                                                      .Name_Join = objOItem_Join.Name, _
                                                                                                                      .ID_OItem1 = objOItem_OItemLeft.GUID, _
                                                                                                                      .Name_OItem1 = objOItem_OItemLeft.Name, _
                                                                                                                      .ID_ParentOItem1 = objOItem_OItemLeft.GUID_Parent, _
                                                                                                                      .Ontology_OItem1 = objOItem_OItemLeft.Type, _
                                                                                                                      .ID_OItem2 = If(objOItem_OItemRight Is Nothing, If(boolHierarchy,objOItem_OItemLeft.GUID,nothing), objOItem_OItemRight.GUID), _
                                                                                                                      .Name_OItem2 = If(objOItem_OItemRight Is Nothing, If(boolHierarchy,objOItem_OItemLeft.Name,nothing), objOItem_OItemRight.Name), _
                                                                                                                      .ID_ParentOItem2 = If(objOItem_OItemRight Is Nothing, If(boolHierarchy,objOItem_OItemLeft.GUID_Parent,nothing), objOItem_OItemRight.GUID_Parent), _
                                                                                                                      .Ontology_OItem2 = If(objOItem_OItemRight Is Nothing, If(boolHierarchy,objOItem_OItemLeft.Type,nothing), objOItem_OItemRight.Type), _
                                                                                                                      .ID_OItem3 = If(objOItem_OItemRelationType Is Nothing, Nothing, objOItem_OItemRelationType.GUID), _
                                                                                                                      .Name_OItem3 = If(objOItem_OItemRelationType Is Nothing, Nothing, objOItem_OItemRelationType.Name), _
                                                                                                                      .Ontology_OItem3 = If(objOItem_OItemRelationType Is Nothing, Nothing, objOItem_OItemRelationType.Type), _
                                                                                                                      .ID_Ontology = objOItem_Ontology.GUID})


                                            initialize_Joins(objOItem_Ontology)
                                        Else
                                            objTransaction_Ontologies.rollback()
                                            MsgBox("Der Join konnte nicht gespeichert werden!", MsgBoxStyle.Exclamation)
                                        End If
                                    End If





                                Else
                                    objTransaction_Ontologies.rollback()
                                    MsgBox("Der Join konnte nicht gespeichert werden!", MsgBoxStyle.Exclamation)
                                End If
                            Else
                                objTransaction_Ontologies.rollback()
                                MsgBox("Der Join konnte nicht gespeichert werden!", MsgBoxStyle.Exclamation)
                            End If


                        Else
                            objTransaction_Ontologies.rollback()
                            MsgBox("Es konnte nicht ermittelt werden, ob bereits ein Join exisitert!", MsgBoxStyle.Exclamation)
                        End If
                    Else
                        MsgBox("Es konnte nicht ermittelt werden, ob bereits ein Join exisitert!", MsgBoxStyle.Exclamation)
                    End If




                ElseIf objOItem_Join.GUID_Parent = objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyJoin.GUID Then

                Else
                    MsgBox("Es konnte nicht ermittelt werden, ob bereits ein Join exisitert!", MsgBoxStyle.Exclamation)
                End If

            End If
        End If

    End Sub


    Private Sub DataGridView_Joins_RowHeaderMouseDoubleClick( sender As Object,  e As DataGridViewCellMouseEventArgs) Handles DataGridView_Joins.RowHeaderMouseDoubleClick
        Dim objDGVR_Selected = DataGridView_Joins.Rows(e.RowIndex)
        Dim objJoin As clsOntologyJoins = objDGVR_Selected.DataBoundItem

        Dim objOItem_Join = New clsOntologyItem With {.GUID = objJoin.ID_Join, _
                                                      .Name = objJoin.Name_Join, _
                                                      .GUID_Parent = objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyJoin.GUID, _
                                                      .Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Object}

        Dim objOList_Joins = New List(Of clsOntologyItem) From {objOItem_Join}
        objFrmObjectEdit = New frm_ObjectEdit(objDataWork_Ontologies.LocalConfig.Globals, objOList_Joins, 0, objDataWork_Ontologies.LocalConfig.Globals.Type_Object, Nothing)
        objFrmObjectEdit.ShowDialog(Me)

    End Sub
End Class
