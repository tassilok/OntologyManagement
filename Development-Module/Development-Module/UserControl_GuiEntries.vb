Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class UserControl_GuiEntries

    Private objLocalConfig As clsLocalConfig

    Private objDataWork_GuiEntries As clsDataWork_GuiEntries

    Private objOItem_Development As clsOntologyItem

    Private objFrm_Name As frm_Name

    Private objTransaction As clsTransaction
    Private objRelationConfig As clsRelationConfig

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        Initialize()
    End Sub

    Private Sub Initialize()
        objDataWork_GuiEntries = New clsDataWork_GuiEntries(objLocalConfig)
        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)

    End Sub

    Public Sub Initialize_GuiEntries(OItem_Development As clsOntologyItem)
        TreeView_GuiEntries.Nodes.Clear()

        objOItem_Development = OItem_Development

        If (Not OItem_Development Is Nothing) Then
            Dim objTreeNode_Root = TreeView_GuiEntries.Nodes.Add(OItem_Development.GUID, OItem_Development.Name, objLocalConfig.ImageID_Root, objLocalConfig.ImageID_Root)

            Dim objOItem_Result = objDataWork_GuiEntries.CreateSubNodes(OItem_Development, objTreeNode_Root)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Die Gui-Elemente konnten nicht ermittelt werden!", MsgBoxStyle.Exclamation)
            End If
        End If

    End Sub

    Private Sub ContextMenuStrip_GuiEntries_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_GuiEntries.Opening
        Dim treeNode = TreeView_GuiEntries.SelectedNode

        NewGuiEntryToolStripMenuItem.Enabled = False
        NewCaptionToolStripMenuItem.Enabled = False
        NewTooltipToolStripMenuItem.Enabled = False

        If Not treeNode Is Nothing Then
            Dim treeNode_Parent = treeNode.Parent

            If treeNode_Parent Is Nothing Then
                NewGuiEntryToolStripMenuItem.Enabled = True
            Else
                If treeNode_Parent.ImageIndex = objLocalConfig.ImageID_GuiItem Then
                    NewCaptionToolStripMenuItem.Enabled = True
                    NewTooltipToolStripMenuItem.Enabled = True
                Else
                    NewGuiEntryToolStripMenuItem.Enabled = True
                    NewCaptionToolStripMenuItem.Enabled = True
                    NewTooltipToolStripMenuItem.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub NewGuiEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewGuiEntryToolStripMenuItem.Click
        Dim treeNode = TreeView_GuiEntries.SelectedNode

        objTransaction.ClearItems()
        If Not treeNode Is Nothing Then
            Dim treeNodeParent = treeNode.Parent

            If treeNodeParent Is Nothing Then
                objFrm_Name = New frm_Name("New Form", objLocalConfig.Globals)
                objFrm_Name.ShowDialog(Me)
                If objFrm_Name.DialogResult = DialogResult.OK Then
                    Dim nameNewForm = objFrm_Name.Value1

                    If objDataWork_GuiEntries.ExistGuiEntry(objOItem_Development, nameNewForm) = False Then
                        Dim objOItem_GuiEntry = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID,
                                                                          .Name = nameNewForm,
                                                                          .GUID_Parent = objLocalConfig.OItem_Class_GUI_Entires.GUID,
                                                                          .Type = objLocalConfig.Globals.Type_Object}

                        Dim objOItem_Result = objTransaction.do_Transaction(objOItem_GuiEntry)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Dim objORel_GuiEntry = objRelationConfig.Rel_ObjectRelation(objOItem_Development, objOItem_GuiEntry, objLocalConfig.Oitem_RelationType_contains)
                            objOItem_Result = objTransaction.do_Transaction(objORel_GuiEntry)

                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                treeNode.Nodes.Add(objOItem_GuiEntry.GUID, objOItem_GuiEntry.Name, objLocalConfig.ImageID_Form, objLocalConfig.ImageID_Form)
                            Else
                                MsgBox("Das Formular konnte nicht erzeugt werden!", MsgBoxStyle.Exclamation)
                                objTransaction.rollback()
                            End If
                        Else
                            MsgBox("Das Formular konnte nicht erzeugt werden!", MsgBoxStyle.Exclamation)
                        End If
                    Else
                        MsgBox("Das Formular existiert bereits!", MsgBoxStyle.Information)
                    End If
                End If
            Else
                If treeNode.ImageIndex = objLocalConfig.ImageID_Form Then
                    Dim objOItem_Form = New clsOntologyItem With {.GUID = treeNode.Name,
                                                                  .Name = treeNode.Text,
                                                                  .GUID_Parent = objLocalConfig.OItem_Class_GUI_Entires.GUID,
                                                                  .Type = objLocalConfig.Globals.Type_Object}

                    objFrm_Name = New frm_Name("New GuiEntry", objLocalConfig.Globals)
                    objFrm_Name.ShowDialog(Me)
                    If objFrm_Name.DialogResult = DialogResult.OK Then
                        Dim nameNewForm = objFrm_Name.Value1

                        If objDataWork_GuiEntries.ExistGuiEntry(objOItem_Form, nameNewForm) = False Then
                            Dim objOItem_GuiEntry = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID,
                                                                              .Name = nameNewForm,
                                                                              .GUID_Parent = objLocalConfig.OItem_Class_GUI_Entires.GUID,
                                                                              .Type = objLocalConfig.Globals.Type_Object}

                            Dim objOItem_Result = objTransaction.do_Transaction(objOItem_GuiEntry)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                Dim objORel_GuiEntry = objRelationConfig.Rel_ObjectRelation(objOItem_Form, objOItem_GuiEntry, objLocalConfig.Oitem_RelationType_contains)
                                objOItem_Result = objTransaction.do_Transaction(objORel_GuiEntry)

                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    treeNode.Nodes.Add(objOItem_GuiEntry.GUID, objOItem_GuiEntry.Name, objLocalConfig.ImageID_GuiItem, objLocalConfig.ImageID_GuiItem)
                                Else
                                    MsgBox("Das Formular konnte nicht erzeugt werden!", MsgBoxStyle.Exclamation)
                                    objTransaction.rollback()
                                End If
                            Else
                                MsgBox("Das Formular konnte nicht erzeugt werden!", MsgBoxStyle.Exclamation)
                            End If
                        Else
                            MsgBox("Das Formular existiert bereits!", MsgBoxStyle.Information)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub NewCaptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewCaptionToolStripMenuItem.Click
        Dim treeNode = TreeView_GuiEntries.SelectedNode

        If Not treeNode Is Nothing Then
            Dim treeNode_Parent = treeNode.Parent
            If Not treeNode_Parent Is Nothing Then
                
                
            End If
            
        End If
    End Sub
End Class
