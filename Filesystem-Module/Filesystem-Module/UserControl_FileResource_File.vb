Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports TextParser

Public Class UserControl_FileResource_File

    Private objLocalConfig As clsLocalConfig

    Private objOItem_FileResource As clsOntologyItem

    Private WithEvents objUserControl_Files As UserControl_OItemList
    Private WithEvents objUserControl_RegExTester As UserControl_RegExTester

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        Initialize()
    End Sub

    Private Sub Initialize()
        objUserControl_Files = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_Files.Dock = DockStyle.Fill
        SplitContainer1.Panel1.Controls.Add(objUserControl_Files)

        objUserControl_RegExTester = New UserControl_RegExTester(objLocalConfig.Globals)
        objUserControl_RegExTester.Dock = DockStyle.Fill
        SplitContainer1.Panel2.Controls.Add(objUserControl_RegExTester)
    End Sub

    Public Sub Initialize_File(OItem_FileResource As clsOntologyItem)
        objOItem_FileResource = OItem_FileResource
        If Not objOItem_FileResource Is Nothing Then
            Dim objOItem_File = New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                          .Type = objLocalConfig.Globals.Type_Object}

            objUserControl_Files.initialize(Nothing, _
                                            objOItem_FileResource, _
                                            objLocalConfig.Globals.Direction_LeftRight, _
                                            objOItem_File, _
                                            objLocalConfig.OItem_RelationType_belonging_Resource)

        Else
            objUserControl_Files.clear_Relation()
        End If
    End Sub
End Class
