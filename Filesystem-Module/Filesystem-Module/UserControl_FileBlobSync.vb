Imports Structure_Module
Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class UserControl_FileBlobSync
    Private objLocalConfig As clsLocalConfig

    Private objDataWork_FileBlobSync As clsDataWork_FileBlobSync

    Private BlobSyncItemList As SortableBindingList(Of clsBlobSyncItem)

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objDataWork_FileBlobSync = New clsDataWork_FileBlobSync(objLocalConfig)

        GetData()
    End Sub

    Private Sub GetData()
        DataGridView_Items.DataSource = Nothing
        Dim objOItem_Result = objDataWork_FileBlobSync.GetData_SyncList()
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            BlobSyncItemList = New SortableBindingList(Of clsBlobSyncItem)(objDataWork_FileBlobSync.ItemList)
            DataGridView_Items.DataSource = BlobSyncItemList

        Else
            MsgBox("Die Dateiliste konnte leider nicht ermittelt werden!", MsgBoxStyle.Exclamation)
        End If
        ToolStripLabel_Count.Text = DataGridView_Items.RowCount
    End Sub
End Class
