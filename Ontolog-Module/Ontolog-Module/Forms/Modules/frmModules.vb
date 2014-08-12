Imports Structure_Module
Public Class frmModules

    Private objGlobals As clsGlobals

    Private strModule As String

    Private strFilter As String
                    
    Private moduleListGlobal  As List(Of clsModuleForCommandLine)


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
        moduleListGlobal = objGlobals.get_ModuleExecutablesInSearchPath
        If Not moduleListGlobal Is Nothing Then
            If moduleListGlobal.Any() Then
                FillGrid()
                
            Else
                MsgBox("Es konnten keine Module ermittelt werden!", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Es konnten keine Module ermittelt werden!", MsgBoxStyle.Information)
        End If
        

    End Sub

    Private sub FillGrid()
        strFilter = TextBox_Filter.Text

        Dim moduleListSortable As SortableBindingList(Of clsModuleForCommandLine)
        If String.IsNullOrEmpty(strFilter) Then
            
            moduleListSortable =  new SortableBindingList(Of clsModuleForCommandLine)(moduleListGlobal)
        Else 
            moduleListSortable =  new SortableBindingList(Of clsModuleForCommandLine)(moduleListGlobal.Where(Function(modl) modl.ModuleName.ToLower().Contains(strFilter.ToLower())))
        End If
                
               
        DataGridView_Modules.DataSource = moduleListSortable
        DataGridView_Modules.Sort(DataGridView_Modules.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
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

    Private Sub Timer_Filter_Tick( sender As Object,  e As EventArgs) Handles Timer_Filter.Tick
        Timer_Filter.Stop()
        FillGrid()
    End Sub


    Private Sub TextBox_Filter_TextChanged( sender As Object,  e As EventArgs) Handles TextBox_Filter.TextChanged
        Timer_Filter.Stop()
        Timer_Filter.Start()
    End Sub
End Class