Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Structure_Module
Public Class UserControl_LogEntries

    Private objLocalConfig As clsLocalConfig

    Private objDataWork_LogEntries As clsDataWork_LogEntries

    Private objOItem_Development As clsOntologyItem

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        Initialize()
    End Sub

    Private Sub Initialize()
        objDataWork_LogEntries = New clsDataWork_LogEntries(objLocalConfig)

    End Sub

    Public Sub Initialize_LogEntries(OItem_Develop As clsOntologyItem)
        objOItem_Development = OItem_Develop
        If Not objOItem_Development Is Nothing Then
            Dim objOItem_Result = objDataWork_LogEntries.GetData(objOItem_Development)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                DataGridView_LogEntries.DataSource = objDataWork_LogEntries.OList_LogEntryList

                DataGridView_LogEntries.Columns(0).Visible = False
                DataGridView_LogEntries.Columns(1).Visible = False
                DataGridView_LogEntries.Columns(2).Visible = False
                DataGridView_LogEntries.Columns(4).Visible = False
                DataGridView_LogEntries.Columns(6).Visible = False
                DataGridView_LogEntries.Columns(8).Visible = False

                DataGridView_LogEntries.Sort(DataGridView_LogEntries.Columns("DateTimeStamp"), System.ComponentModel.ListSortDirection.Descending)
            End If
        Else
            DataGridView_LogEntries.DataSource = Nothing

        End If
        
        ToolStripLabel_Count.Text = DataGridView_LogEntries.RowCount.ToString
    End Sub
End Class
