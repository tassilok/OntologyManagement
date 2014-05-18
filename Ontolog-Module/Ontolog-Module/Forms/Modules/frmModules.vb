Imports Structure_Module
Public Class frmModules

    Private objGlobals As clsGlobals

    Private strModule As String

    Public ReadOnly Property Selected_Module As String
        Get
            Return strModule
        End Get
    End Property

    Private Sub ToolStripButton_Close_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Public Sub New(Globals As clsGlobals)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objGlobals = Globals

        Initialize()
    End Sub

    Private Sub Initialize()
        Dim moduleList = objGlobals.get_ModuleExecutablesInSearchPath
        If Not moduleList Is Nothing Then
            If moduleList.Any() Then
                Dim moduleListSortable = New SortableBindingList(Of clsModuleForCommandLine)(moduleList)

                DataGridView_Modules.DataSource = moduleListSortable
                DataGridView_Modules.Sort(DataGridView_Modules.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Else
                MsgBox("Es konnten keine Module ermittelt werden!", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Es konnten keine Module ermittelt werden!", MsgBoxStyle.Information)
        End If
        

    End Sub

    Private Sub ContextMenuStrip_Modules_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Modules.Opening
        ApplyToolStripMenuItem.Enabled = False
        If DataGridView_Modules.SelectedRows.Count = 1 Then
            ApplyToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub ApplyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApplyToolStripMenuItem.Click
        strModule = DataGridView_Modules.SelectedRows(0).Cells(1).Value.ToString()
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class