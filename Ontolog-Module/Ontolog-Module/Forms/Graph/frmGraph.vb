Imports OntologyClasses.BaseClasses
Public Class frmGraph

    Public Property OList_AttributeTypes As List(Of clsOntologyItem)
        Get
            Return objUserControl_Graph.OList_AttributeTypes
        End Get
        Set(value As List(Of clsOntologyItem))
            objUserControl_Graph.OList_AttributeTypes = value
        End Set
    End Property

    Public Property OList_RelationTypes As List(Of clsOntologyItem)
        Get
            Return objUserControl_Graph.OList_RelationTypes
        End Get
        Set(value As List(Of clsOntologyItem))
            objUserControl_Graph.OList_RelationTypes = value
        End Set
    End Property

    Public Property OList_Objects As List(Of clsOntologyItem)
        Get
            Return objUserControl_Graph.OList_Objects
        End Get
        Set(value As List(Of clsOntologyItem))
            objUserControl_Graph.OList_Objects = value
        End Set
    End Property

    Public Property OList_Classes As List(Of clsOntologyItem)
        Get
            Return objUserControl_Graph.OList_Classes
        End Get
        Set(value As List(Of clsOntologyItem))
            objUserControl_Graph.OList_Classes = value
        End Set
    End Property

    Public Property OList_ClassAtt As List(Of clsClassAtt)
        Get
            Return objUserControl_Graph.OList_ClassAtt
        End Get
        Set(value As List(Of clsClassAtt))
            objUserControl_Graph.OList_ClassAtt = value
        End Set
    End Property

    Public Property OList_ClassRel As List(Of clsClassRel)
        Get
            Return objUserControl_Graph.OList_ClassRel
        End Get
        Set(value As List(Of clsClassRel))
            objUserControl_Graph.OList_ClassRel = value
        End Set
    End Property

    Public Property OList_ObjectAtt As List(Of clsObjectAtt)
        Get
            Return objUserControl_Graph.OList_ObjectAtt
        End Get
        Set(value As List(Of clsObjectAtt))
            objUserControl_Graph.OList_ObjectAtt = value
        End Set
    End Property

    Public Property OList_ObjectRel As List(Of clsObjectRel)
        Get
            Return objUserControl_Graph.OList_ObjectRel
        End Get
        Set(value As List(Of clsObjectRel))
            objUserControl_Graph.OList_ObjectRel = value
        End Set
    End Property

    Public Property EdgeList As List(Of clsObjectRel)
        Get
            Return objUserControl_Graph.EdgeList
        End Get
        Set(value As List(Of clsObjectRel))
            objUserControl_Graph.EdgeList = value
        End Set
    End Property


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

    Public Sub Initialize_Lists()
        objUserControl_Graph.Initialize_Lists()
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

    Public Sub Initialize_Graph()
        objUserControl_Graph.Initialize_Graph()
    End Sub

    Private Sub frmGraph_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        RaiseEvent Closing_From()
    End Sub
End Class