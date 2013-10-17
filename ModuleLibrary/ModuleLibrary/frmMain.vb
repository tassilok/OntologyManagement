Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class frmMain
    Private objLocalConfig As clsLocalConfig

    Private WithEvents objUserControl_ModuleList As UserControl_OItemList
    Private objUserControl_Amount As UserControl_Amount

    Private Sub selected_ModuleItem() Handles objUserControl_ModuleList.Selection_Changed
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOItem_ModuleItem As clsOntologyItem

        If objUserControl_ModuleList.DataGridViewRowCollection_Selected.Count = 1 Then
            objDGVR_Selected = objUserControl_ModuleList.DataGridViewRowCollection_Selected(0)
            objDRV_Selected = objDGVR_Selected.DataBoundItem
            objOItem_ModuleItem = New clsOntologyItem(objDRV_Selected.Item(objUserControl_ModuleList.RowName_GUID), _
                                                      objDRV_Selected.Item(objUserControl_ModuleList.RowName_Name), _
                                                      objDRV_Selected.Item(objUserControl_ModuleList.RowName_GUIDParent), _
                                                      objLocalConfig.Globals.Type_Object)

            Select Case objOItem_ModuleItem.GUID_Parent
                Case objLocalConfig.OItem_Type_Fl_che.GUID

                Case objLocalConfig.OItem_Type_Menge.GUID
                    objUserControl_Amount.initialize_Amount(objOItem_ModuleItem)
                Case (objLocalConfig.OItem_Type_Volumen.GUID)


            End Select

        End If
    End Sub

    Private Sub fill_Combo_Modules()
        ToolStripComboBox_Modules.ComboBox.Items.Add(objLocalConfig.OItem_Type_Menge)
        ToolStripComboBox_Modules.ComboBox.Items.Add(objLocalConfig.OItem_Type_Volumen)
        ToolStripComboBox_Modules.ComboBox.Items.Add(objLocalConfig.OItem_Type_Fl_che)
        ToolStripComboBox_Modules.ComboBox.ValueMember = "GUID"
        ToolStripComboBox_Modules.ComboBox.DisplayMember = "Name"
        ToolStripComboBox_Modules.ComboBox.Sorted = True
    End Sub

    Private Sub initialize()
        fill_Combo_Modules()

        objUserControl_ModuleList = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_ModuleList.Dock = DockStyle.Fill
        SplitContainer1.Panel1.Controls.Add(objUserControl_ModuleList)

        objUserControl_Amount = New UserControl_Amount(objLocalConfig)
        objUserControl_Amount.Dock = DockStyle.Fill
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = New clsLocalConfig(New clsGlobals)

        initialize()
    End Sub

    Private Sub ToolStripComboBox_Modules_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboBox_Modules.SelectedIndexChanged
        Dim objOItem_Selected As clsOntologyItem

        objOItem_Selected = ToolStripComboBox_Modules.SelectedItem
        objUserControl_ModuleList.initialize(New clsOntologyItem(Nothing, Nothing, objOItem_Selected.GUID, objLocalConfig.Globals.Type_Object))

        Select Case objOItem_Selected.GUID
            Case objLocalConfig.OItem_Type_Menge.GUID
                SplitContainer1.Panel2.Controls.Clear()
                SplitContainer1.Panel2.Controls.Add(objUserControl_Amount)

            Case objLocalConfig.OItem_Type_Fl_che.GUID

            Case objLocalConfig.OItem_Type_Volumen.GUID

        End Select
    End Sub

    
End Class
