Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class UserControl_ObjectRelation
    Private objLocalConfig As clsLocalConfig

    Private WithEvents objUserControl_Objects As UserControl_OItemList

    Private objOItem_Image As clsOntologyItem

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
        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)

        objUserControl_Objects = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_Objects.Dock = DockStyle.Fill

        SplitContainer1.Panel2.Controls.Add(objUserControl_Objects)
    End Sub
End Class
