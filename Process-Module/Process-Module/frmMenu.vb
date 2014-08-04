Imports OntologyClasses.BaseClasses
Imports Ontology_Module
Public Class frmMenu

    Private objLocalConfig As clsLocalConfig

    Private objOItem_Item As clsOntologyItem

    Private objRelationConfig As clsRelationConfig
    Private objTransaction As clsTransaction

    Private WithEvents objUserControl_Process As UserControl_Process
    Private WithEvents objUserControl_OItemList As UserControl_OItemList

    Private objDataWork_Menu As clsDataWork_Menu

    Private objOItem_SelectedProcess As clsOntologyItem

    Private sub selectedProcess(optional objOItem_Process As clsOntologyItem = Nothing) Handles  objUserControl_Process.selectedProcess
        objOItem_SelectedProcess = objOItem_Process
        ToolStripButton_AddProcess.Enabled = False
        If Not objOItem_Process Is Nothing Then
            Dim rows = objUserControl_OItemList.DataGridviewRows.Cast(of DataGridViewRow).Select(Function(dgvr) CType(dgvr.DataBoundItem,DataRowView)).Where(Function(row) row.Item("ID_Object") = objOItem_Process.GUID).ToList()
            If Not rows.Any() Then
                ToolStripButton_AddProcess.Enabled = True
            End If
        End If
    End Sub

    Private Sub ToolStripButton_Close_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Private sub SelectedRow() Handles  objUserControl_OItemList.Selection_Changed
        ToolStripButton_RemoveProcess.Enabled = False
        If objUserControl_OItemList.DataGridViewRowCollection_Selected.Count = 1 Then
            Dim dgvr = objUserControl_OItemList.DataGridViewRowCollection_Selected(0)
            Dim row As DataRowView = dgvr.DataBoundItem

            Dim objOItem_ProcessRel = new clsOntologyItem With {.GUID = row.Item("ID_Object"),
                                                                .Name = row.Item("Name_Object"),
                                                                .GUID_Parent = row.Item("ID_Parent_Object"),
                                                                .Type = objLocalConfig.Globals.Type_Object
                                                               }

            objUserControl_Process.MarkProcess(objOItem_ProcessRel)

            ToolStripButton_RemoveProcess.Enabled = True
        End If
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig, OItem_Item As clsOntologyItem)
        
        ' This call is required by the designer.
        InitializeComponent()
        
        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = LocalConfig
        objOItem_Item = OItem_Item

        Initialize()
    End Sub

    Private sub Initialize()
        objTransaction = new clsTransaction(objLocalConfig.Globals)
        objRelationConfig = new clsRelationConfig(objLocalConfig.Globals)

        objDataWork_Menu = new clsDataWork_Menu(objLocalConfig)

        objUserControl_Process = new UserControl_Process(objLocalConfig)
        objUserControl_Process.AddOther()

        objUserControl_Process.Dock = DockStyle.Fill

        ToolStripContainer2.ContentPanel.Controls.Add(objUserControl_Process)

        objUserControl_OItemList = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_OItemList.Dock = DockStyle.Fill
        objUserControl_OItemList.VisibilityToolStrip = False
        SplitContainer1.Panel1.Controls.Add(objUserControl_OItemList)

        Select Case objOItem_Item.Type
            Case objLocalConfig.Globals.Type_AttributeType.ToLower()
                objOItem_Item.Type = objLocalConfig.Globals.Type_AttributeType
            Case objLocalConfig.Globals.Type_RelationType.ToLower()
                objOItem_Item.Type = objLocalConfig.Globals.Type_RelationType
            Case objLocalConfig.Globals.Type_Object.ToLower()
                objOItem_Item.Type = objLocalConfig.Globals.Type_Object
            Case objLocalConfig.Globals.Type_Class.ToLower()
                objOItem_Item.Type = objLocalConfig.Globals.Type_Class
        End Select

        If objOItem_Item.Type = objLocalConfig.Globals.Type_Object.ToLower() Then
            dim objOItem_Class = objDataWork_Menu.GetOItem(objOItem_Item.GUID_Parent, objLocalConfig.Globals.Type_Class)
            If Not objOItem_Class Is Nothing Then
                Me.Text = objOItem_Class.Name & "\"
            End If
        End If

        Me.Text = me.Text & objOItem_Item.Name

        objUserControl_OItemList.initialize(Nothing, objOItem_Item, objLocalConfig.Globals.Direction_RightLeft, nothing, objLocalConfig.OItem_relationtype_todo_for )
        ClearButtons()
    End Sub

    Private sub ClearButtons()
        ToolStripButton_AddProcess.Enabled = False
        ToolStripButton_RemoveProcess.Enabled = False
    End Sub

    Private Sub ToolStripButton_AddProcess_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_AddProcess.Click
        If not objOItem_SelectedProcess Is nothing Then
            Dim relSave = objRelationConfig.Rel_ObjectRelation(objOItem_SelectedProcess, objOItem_Item, objLocalConfig.OItem_relationtype_todo_for)       
            Dim objOItem_Result = objTransaction.do_Transaction(relSave)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objUserControl_OItemList.initialize(Nothing, objOItem_Item, objLocalConfig.Globals.Direction_RightLeft, nothing, objLocalConfig.OItem_relationtype_todo_for )
                ClearButtons()
            Else 
                MsgBox("Der Prozess konnte nicht verknüpft werden!", MsgBoxStyle.Exclamation)
            End If
        End If
        
    End Sub

    Private Sub ToolStripButton_RemoveProcess_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_RemoveProcess.Click
        Dim dgvrSelected = objUserControl_OItemList.DataGridViewRowCollection_Selected(0)
        Dim drvSelected As DataRowView = dgvrSelected.DataBoundItem
        Dim objORel_ToDelete = New clsObjectRel With {.ID_Object = drvSelected.Item("ID_Object"),
                                                                                       .ID_Other = drvSelected.Item("ID_Other"),
                                                                                       .ID_RelationType = drvSelected.Item("ID_RelationType") }
        Dim objOItem_Result = objTransaction.do_Transaction(objORel_ToDelete)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objUserControl_OItemList.initialize(Nothing, objOItem_Item, objLocalConfig.Globals.Direction_RightLeft, nothing, objLocalConfig.OItem_relationtype_todo_for )
            ClearButtons()    
        Else 
            MsgBox("Der Prozess konnte nicht entfernt werden!",MsgBoxStyle.Exclamation)
        End If
        
        
            
        
    End Sub
End Class