Imports Structure_Module
Imports OntologyClasses.BaseClasses

Public Class frmOntologyItemList
    Private objLocalConfig As clsLocalConfig

    Private OItemList As List(Of clsOntologyItem)

    Public Sub New(OList_OntologyItems As List(Of clsOntologyItem), Globals As clsGlobals)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)

        OItemList = OList_OntologyItems

        DataGridView_Items.DataSource = New SortableBindingList(Of clsOntologyItem)(OList_OntologyItems)
    End Sub
End Class