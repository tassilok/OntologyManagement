Imports OntologyClasses.BaseClasses

Public Class frmOntologyConfigurator

    Private objLocalConfig As clsLocalConfig_Ontologies
    Private objDataWork_Ontologies As clsDataWork_Ontologies

    Private WithEvents objUserControl_OntologyRefTree As UserControl_OntologyRefTree
    Private WithEvents objUserControl_OntologyTree As UserControl_OntologyTree
    Private objUserControl_OntologyItemList As UserControl_OntologyItemList
    Private objUserControl_OntologyJoins As UserControl_OntologyJoins

    Private objOItem_Open As clsOntologyItem

    Private objOItem_Ontology As clsOntologyItem

    Public ReadOnly Property OItem_Ontology As clsOntologyItem
        Get
            Return objOItem_Ontology
        End Get
    End Property

    Public ReadOnly Property OList_Ontologies As List(Of clsOntologyJoins)
        Get
            Return objDataWork_Ontologies.OList_OntologyJoins
        End Get
    End Property

   
    Private boolApplyable As Boolean


    Public Property Applyable As Boolean
        Get
            Return boolApplyable
        End Get
        Set(value As Boolean)
            boolApplyable = value
            objUserControl_OntologyTree.Applyable = value
        End Set
    End Property

    Private Sub applied_Node(OItem_Ontology As clsOntologyItem) Handles objUserControl_OntologyTree.applied_Ontology
        DialogResult = Windows.Forms.DialogResult.OK
        objOItem_Ontology = OItem_Ontology
        Me.Close()
    End Sub

    Private Sub selected_Node(OItem_Ref As clsOntologyItem) Handles objUserControl_OntologyRefTree.selected_Node
        objUserControl_OntologyTree.initialize_Ontology(OItem_Ref)
    End Sub

    Private Sub selected_Ontology(OItem_OntologyItem As clsOntologyItem) Handles objUserControl_OntologyTree.selected_Ontology
        objUserControl_OntologyItemList.initialize_List(New List(Of clsOntologyItem) From {OItem_OntologyItem}, OItem_OntologyItem)
        objUserControl_OntologyJoins.initialize_Joins(OItem_OntologyItem)
    End Sub

    Private Sub ToolStripButton_Close_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Public Sub New(Globals As clsGlobals)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig_Ontologies(Globals)
        initialize()


    End Sub

    Private Sub initialize()


        objOItem_Open = objLocalConfig.Globals.LState_Success

        objDataWork_Ontologies = New clsDataWork_Ontologies(objLocalConfig)

        If objDataWork_Ontologies.GetData_BaseData().GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objUserControl_OntologyRefTree = New UserControl_OntologyRefTree(objDataWork_Ontologies)
                                                            objUserControl_OntologyRefTree.Dock = DockStyle.Fill
                                                            SplitContainer1.Panel1.Controls.Add(objUserControl_OntologyRefTree)

                                                            objUserControl_OntologyTree = New UserControl_OntologyTree(objDataWork_Ontologies)
                                                            objUserControl_OntologyTree.Dock = DockStyle.Fill
                                                            SplitContainer2.Panel1.Controls.Add(objUserControl_OntologyTree)

                                                            objUserControl_OntologyItemList = New UserControl_OntologyItemList(objDataWork_Ontologies)
                                                            objUserControl_OntologyItemList.Dock = DockStyle.Fill
                                                            TabPage_OntologyItems.Controls.Add(objUserControl_OntologyItemList)

                                                            objUserControl_OntologyJoins = New UserControl_OntologyJoins(objDataWork_Ontologies)
                                                            objUserControl_OntologyJoins.Dock = DockStyle.Fill
                                                            TabPage_OntologyJoins.Controls.Add(objUserControl_OntologyJoins)
        Else 
            MsgBox("Die Ontologien konnten nicht ermittelt werden!", MsgBoxStyle.Exclamation)
        End If

        objDataWork_Ontologies.GetData_OntologyRefs()
        objDataWork_Ontologies.GetData_ClassTree()
    End Sub

    Private Sub frmOntologyConfigurator_Load(sender As Object, e As EventArgs) Handles Me.Load
        If objOItem_Open.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            Me.Close()
        End If
    End Sub
End Class