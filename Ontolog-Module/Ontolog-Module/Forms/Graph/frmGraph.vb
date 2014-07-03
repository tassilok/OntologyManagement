Imports OntologyClasses.BaseClasses
Public Class frmGraph

    Private objLocalConfig As clsLocalConfig

    Private objOItem_Item As clsOntologyItem

    Private WithEvents objUserControl_Graph As UserControl_Graph

    Public Event Selected_GraphItem(OItem_GraphItem As clsOntologyItem)
    Public Event Closing_From()

    Public Sub Selected_GraphItemInControl(OItem_GraphItem As clsOntologyItem) Handles objUserControl_Graph.Selected_Item
        RaiseEvent Selected_GraphItem(OItem_GraphItem)
    End Sub

    Private Sub ToolStripButton_Close_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Close.Click
        Me.Hide()
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Public Sub New(Globals As clsGlobals)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)

        Initialize()
    End Sub

    Private Sub Initialize()
        objUserControl_Graph = New UserControl_Graph(objLocalConfig)
        objUserControl_Graph.Dock = DockStyle.Fill
        ToolStripContainer1.ContentPanel.Controls.Add(objUserControl_Graph)
    End Sub

    Public Sub Initialize_Graph(Optional OItem_Item As clsOntologyItem = Nothing)
        objOItem_Item = OItem_Item

        objUserControl_Graph.Initialize_Graph(objOItem_Item)
    End Sub

    Private Sub frmGraph_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        RaiseEvent Closing_From()
    End Sub
End Class