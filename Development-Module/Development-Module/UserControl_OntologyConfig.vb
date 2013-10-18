Imports  OntologyClasses.BaseClasses
imports Ontology_Module
Imports Structure_Module

Public Class UserControl_OntologyConfig
    Private objLocalConfig As clsLocalConfig

    Private objOItem_Development As clsOntologyItem

    Private WithEvents objUserControl_OntologyItems As UserControl_OntologyItemList
    Private objDataWork_OntologyConfig As clsDataWork_OntologyConfig

    Private objFrmCodeGenerator As frmCodeGenerator


    Private sub LoadedData() Handles objUserControl_OntologyItems.DataLoaded
        If objUserControl_OntologyItems.Rows.Count > 0 Then
            ToolStripButton_View.Enabled = True
        End If
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)
        
        ' This call is required by the designer.
        InitializeComponent()
        
        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = LocalConfig

        initialize()
    End Sub

    public sub initialize_OntologyConfig(OItem_Development As clsOntologyItem)
        objOItem_Development = OItem_Development

        If Not objOItem_Development Is Nothing Then
            Dim objOItem_Result =  objDataWork_OntologyConfig.GetData(objOItem_Development)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objUserControl_OntologyItems.initialize_List(objDataWork_OntologyConfig.OItem_Ontology)

            Else 
                MsgBox("Die Ontology-Items konnten nicht geladen werden!",MsgBoxStyle.Exclamation)
            End If
        Else 
            ClearControls()
        End If
        
    End Sub

    Private sub ClearControls()
        ToolStripButton_Add.Enabled = False
        ToolStripButton_Remove.Enabled = False
        ToolStripButton_View.Enabled = False
    
    End Sub

    Private sub initialize()
        
        objDataWork_OntologyConfig = new clsDataWork_OntologyConfig(objLocalConfig)
        objUserControl_OntologyItems = new UserControl_OntologyItemList(objDataWork_OntologyConfig.DataWork_Ontology)
        objUserControl_OntologyItems.Dock = DockStyle.Fill
        ToolStripContainer1.ContentPanel.Controls.Add(objUserControl_OntologyItems)
    End Sub

    Private Sub ToolStripButton_View_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_View.Click
        objFrmCodeGenerator = New frmCodeGenerator(objLocalConfig, objUserControl_OntologyItems.Rows, objOItem_Development)
        objFrmCodeGenerator.ShowDialog(Me)
    End Sub

    Private Sub ToolStripButton_Migrate_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_Migrate.Click
        Dim objDataWork_OntologyConfigOld = new clsDataWork_OntologyConfig_bak(objLocalConfig)
        objDataWork_OntologyConfigOld.get_ConfigItems(objOItem_Development)
        Dim objMoveConfigItemsToOntologies As New clsMoveConfigItemsToOntologies(objLocalConfig,objDataWork_OntologyConfigOld)
        Dim objOItem_Result = objMoveConfigItemsToOntologies.CopyOntologyItems(objOItem_Development)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            initialize_OntologyConfig(objOItem_Development)
        Else 
            MsgBox("Die Ontology konnte nicht erzeugt werden!")
        End If
    End Sub
End Class
