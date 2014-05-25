Imports Structure_Module
Imports OntologyClasses.BaseClasses

Public Class frmOntologyItemList
    Private objLocalConfig As clsLocalConfig

    Private OItemList As List(Of clsOntologyItem)
    Private GridList As SortableBindingList(Of clsOntologyItem)

    Public Event PressedOK()

    Public ReadOnly Property ItemListVisible As SortableBindingList(Of clsOntologyItem)
        Get
            Return GridList
        End Get
    End Property


    Public Sub RemoveItem(GUID As String)
        Dim objOList_ToRemove = GridList.Where(Function(o) o.GUID = GUID).ToList

        objOList_ToRemove.ForEach(Function(o) GridList.Remove(o))

        ToolStripLabel_Count.Text = DataGridView_Items.RowCount.ToString()
    End Sub

    Public Sub New(OList_OntologyItems As List(Of clsOntologyItem), Globals As clsGlobals, Optional VisibleColumns As List(Of String) = Nothing, Optional title As String = Nothing)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)

        OItemList = OList_OntologyItems

        If Not title Is Nothing Then
            Me.Text = title
        End If

        GridList = New SortableBindingList(Of clsOntologyItem)(OList_OntologyItems)
        DataGridView_Items.DataSource = GridList

        Dim objDGVCols = DataGridView_Items.Columns.Cast(Of DataGridViewColumn).ToList()

        Dim objDGVCols_Vis = (From objCol In objDGVCols
                              Join objVisCol In VisibleColumns On objCol.DataPropertyName Equals objVisCol
                              Select objCol).ToList()

        Dim objDGVCols_Invis = (From objCol In objDGVCols
                                Group Join objViscol In VisibleColumns On objCol.DataPropertyName Equals objViscol Into objVisCols = Group
                                From objVisCol In objVisCols.DefaultIfEmpty()
                                Where objVisCol Is Nothing
                                Select objCol).ToList()

        objDGVCols_Vis.ForEach(Sub(c) c.Visible = True)
        objDGVCols_Invis.ForEach(Sub(c) c.Visible = False)

        ToolStripLabel_Count.Text = DataGridView_Items.RowCount.ToString
    End Sub


    Private Sub ToolStripButton_OK_Click(sender As Object, e As EventArgs) Handles ToolStripButton_OK.Click
        ToolStripButton_OK.Enabled = False
        RaiseEvent PressedOK()
    End Sub

    Private Sub ContextMenuStrip_ItemList_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_ItemList.Opening
        RemoveToolStripMenuItem.Enabled = False
        If DataGridView_Items.SelectedRows.Count > 0 Then
            RemoveToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Dim objOList_ToRemove = New List(Of clsOntologyItem)

        For Each objDGVR As DataGridViewRow In DataGridView_Items.SelectedRows
            Dim objOItem As clsOntologyItem = objDGVR.DataBoundItem

            objOList_ToRemove.Add(objOItem)
        Next

        objOList_ToRemove.ForEach(Sub(tr) GridList.Remove(tr))

        ToolStripLabel_Count.Text = DataGridView_Items.RowCount.ToString()
    End Sub
End Class