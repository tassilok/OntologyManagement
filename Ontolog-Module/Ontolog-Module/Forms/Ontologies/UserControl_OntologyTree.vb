Public Class UserControl_OntologyTree
    Private objFrmName As frm_Name

    Private objTransaction_Ontologies As clsTransaction
    Private objDataWork_Ontologies As clsDataWork_Ontologies
    Private objOItem_Ref As clsOntologyItem

    Private objTreeNode_Root As TreeNode



    Public Event selected_Ontology(OItem_Ontology As clsOntologyItem)

    Public Sub New(DataWork_Ontologies As clsDataWork_Ontologies)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objDataWork_Ontologies = DataWork_Ontologies
        initialize()
    End Sub

    Private Sub initialize()
        objTransaction_Ontologies = New clsTransaction(objDataWork_Ontologies.LocalConfig.Globals)
    End Sub

    Public Sub initialize_Ontology(OItem_Ref As clsOntologyItem)
        objOItem_Ref = OItem_Ref

        TreeView_Ontologies.Nodes.Clear()
        objTreeNode_Root = TreeView_Ontologies.Nodes.Add(objDataWork_Ontologies.LocalConfig.Globals.Class_Ontologies.GUID, _
                                                         objDataWork_Ontologies.LocalConfig.Globals.Class_Ontologies.Name, _
                                                         objDataWork_Ontologies.LocalConfig.ImageID_Root, _
                                                         objDataWork_Ontologies.LocalConfig.ImageID_Root)
        fillTree()

    End Sub

    Private Sub fillTree(Optional TreeNode_Parent As TreeNode = Nothing)
        Dim objOList_Nodes As List(Of clsOntologyItem)
        If TreeNode_Parent Is Nothing Then
            If objOItem_Ref Is Nothing Then
                objOList_Nodes = (From objParent In objDataWork_Ontologies.OList_Ontologies
                                 Group Join objChildren In objDataWork_Ontologies.OList_OntologyTree On objChildren.ID_Object_Parent Equals objParent.GUID Into objChilds = Group
                                 From objChildren In objChilds.DefaultIfEmpty
                                 Where objChildren Is Nothing
                                 Select objParent).ToList()


            Else
                objOList_Nodes = (From objOntology In objDataWork_Ontologies.OList_RefsOfOntologies
                                  Where objOntology.ID_Other = objOItem_Ref.GUID
                                  Select New clsOntologyItem With {.GUID = objOntology.ID_Object, _
                                                                   .Name = objOntology.Name_Object, _
                                                                   .GUID_Parent = objOntology.ID_Parent_Object, _
                                                                   .Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Object}).ToList()

            End If
        Else
            objOList_Nodes = (From objOntology In objDataWork_Ontologies.OList_OntologyTree
                              Where objOntology.ID_Object = TreeNode_Parent.Name
                              Select New clsOntologyItem With {.GUID = objOntology.ID_Object_Parent, _
                                                               .Name = objOntology.Name_Object_Parent, _
                                                               .GUID_Parent = objDataWork_Ontologies.LocalConfig.Globals.Class_Ontologies.GUID, _
                                                               .Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Object}).ToList()
        End If

        For Each OItem_Ont As clsOntologyItem In objOList_Nodes

            If TreeNode_Parent Is Nothing Then
                Dim objTreeNode_Child = objTreeNode_Root.Nodes.Add(OItem_Ont.GUID, _
                                                              OItem_Ont.Name, _
                                                              objDataWork_Ontologies.LocalConfig.ImageID_OntologyClose, _
                                                              objDataWork_Ontologies.LocalConfig.ImageID_OntologyOpen)
            Else
                Dim objTreeNode_Child = TreeNode_Parent.Nodes.Add(OItem_Ont.GUID, _
                                                              OItem_Ont.Name, _
                                                              objDataWork_Ontologies.LocalConfig.ImageID_OntologyClose, _
                                                              objDataWork_Ontologies.LocalConfig.ImageID_OntologyOpen)
            End If


        Next
    End Sub


    Private Sub TreeView_Ontologies_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView_Ontologies.AfterSelect
        Dim objOItem_Ontology As clsOntologyItem = Nothing

        Dim objTreeNode = e.Node

        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = objDataWork_Ontologies.LocalConfig.ImageID_OntologyClose Then
                objOItem_Ontology = New clsOntologyItem
                objOItem_Ontology.GUID = objTreeNode.Name
                objOItem_Ontology.Name = objTreeNode.Text
                objOItem_Ontology.GUID_Parent = objDataWork_Ontologies.LocalConfig.Globals.Class_Ontologies.GUID
                objOItem_Ontology.Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Object
            End If
        End If

        RaiseEvent selected_Ontology(objOItem_Ontology)
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Dim objTreeNode As TreeNode
        Dim boolAdd As Boolean

        objTreeNode = TreeView_Ontologies.SelectedNode

        If Not objTreeNode Is Nothing Then
            objFrmName = New frm_Name("New Ontology", objDataWork_Ontologies.LocalConfig.Globals)
            objFrmName.ShowDialog(Me)
            If objFrmName.DialogResult = DialogResult.OK Then
                Dim strNameOntology = objFrmName.Value1
                If Not strNameOntology = "" Then
                    boolAdd = True
                    For Each objTreeNode_Sub As TreeNode In objTreeNode.Nodes
                        If objTreeNode_Sub.Text.ToLower = strNameOntology Then
                            boolAdd = False
                            Exit For
                        End If
                    Next

                    If boolAdd = True Then
                        Dim objOItem_Ontology = New clsOntologyItem With {.GUID = objDataWork_Ontologies.LocalConfig.Globals.NewGUID, _
                                                                          .Name = strNameOntology, _
                                                                          .GUID_Parent = objDataWork_Ontologies.LocalConfig.Globals.Class_Ontologies.GUID, _
                                                                          .Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Object}

                        objTransaction_Ontologies.ClearItems()
                        Dim objOItem_Result = objTransaction_Ontologies.do_Transaction(objOItem_Ontology)

                        If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                            If Not objTreeNode_Root.Name = objTreeNode.Name Then
                                Dim objOItem_OntologyParent = New clsOntologyItem With {.GUID = objTreeNode.Name, _
                                                                                        .Name = objTreeNode.Text, _
                                                                                        .GUID_Parent = objDataWork_Ontologies.LocalConfig.Globals.Class_Ontologies.GUID, _
                                                                                        .Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Object}

                                Dim objOR_Ontology_To_Ontology = objDataWork_Ontologies.Rel_Ontology_To_Ontolgy(objOItem_OntologyParent, objOItem_Ontology)

                                objOItem_Result = objTransaction_Ontologies.do_Transaction(objOR_Ontology_To_Ontology)
                                If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                    objDataWork_Ontologies.GetData_Ontologies()
                                    objDataWork_Ontologies.GetData_OntologyRefs()
                                    fillTree()
                                    

                                Else
                                    MsgBox("Die Ontologie konnte nicht gespeichert werden!", MsgBoxStyle.Exclamation)
                                    objTransaction_Ontologies.rollback()
                                End If
                                
                            End If
                            Dim objOR_Ontology_To_Ref = objDataWork_Ontologies.Rel_Ontology_To_Ref(objOItem_Ref, objOItem_Ontology)

                            objOItem_Result = objTransaction_Ontologies.do_Transaction(objOR_Ontology_To_Ref)
                            If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                objDataWork_Ontologies.GetData_Ontologies()
                                objDataWork_Ontologies.GetData_OntologyRefs()
                                fillTree()
                            Else
                                MsgBox("Die Ontologie konnte nicht gespeichert werden!", MsgBoxStyle.Exclamation)
                                objTransaction_Ontologies.rollback()
                            End If

                        Else
                            MsgBox("Die Ontologie konnte nicht gespeichert werden!", MsgBoxStyle.Exclamation)
                        End If

                    Else
                        MsgBox("Es existiert bereits eine Ontologie mit diesem Namen!", MsgBoxStyle.Exclamation)
                    End If
                Else
                    MsgBox("Geben Sie bitte einen gültigen Namen ein!", MsgBoxStyle.Exclamation)

                End If
            End If
        End If

        
    End Sub
End Class
