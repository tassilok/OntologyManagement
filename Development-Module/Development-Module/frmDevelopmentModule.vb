Imports Ontolog_Module
Imports OntologyClasses.BaseClasses
Public Class frmDevelopmentModule
    Private objLocalConfig As clsLocalConfig

    Private WithEvents objUserControl_DevTree As UserControl_DevelopmentTree

    Private objUserControl_OntologyConfig As UserControl_OntologyConfig

    Private objOItem_Development As clsOntologyItem

    Private Sub selected_DevNode() Handles objUserControl_DevTree.selected_Node
        objOItem_Development = objUserControl_DevTree.OItem_Development
        configure_TabPages()
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals)
        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        objUserControl_DevTree = New UserControl_DevelopmentTree(objLocalConfig)
        objUserControl_DevTree.Dock = DockStyle.Fill
        SplitContainer1.Panel1.Controls.Add(objUserControl_DevTree)

        objUserControl_OntologyConfig = New UserControl_OntologyConfig(objLocalConfig)
        objUserControl_OntologyConfig.Dock = DockStyle.Fill
        TabPage_OntologyConfig.Controls.Add(objUserControl_OntologyConfig)
    End Sub


    Private Sub configure_TabPages()
        Select Case TabControl1.SelectedTab.Name
            Case TabPage_BaseData.Name
            Case TabPage_Logentries.Name
            Case TabPage_OntologyConfig.Name
                objUserControl_OntologyConfig.initialize(objOItem_Development)
        End Select
    End Sub

    Private Sub set_DBConnection()

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        configure_TabPages()
    End Sub
End Class
