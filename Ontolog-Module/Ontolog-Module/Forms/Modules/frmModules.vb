Imports Structure_Module
Imports OntologyClasses.BaseClasses
Public Class frmModules

    Private objGlobals As clsGlobals

    Private strModule As String

    Private strFilter As String
                    
    Private moduleListGlobal As List(Of clsModuleForCommandLine)

    Private objDBLevel_ModuleList As clsDBLevel


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
        Dim objOItem_Result = objGlobals.LState_Success.Clone()
        If objGlobals.DbModuleList Is Nothing Then
            objDBLevel_ModuleList = New clsDBLevel(objGlobals)
            Dim searchModules = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objGlobals.Class_Module.GUID,
                                                                                        .ID_Parent_Other = objGlobals.Class_ModuleFunction.GUID,
                                                                                        .ID_RelationType = objGlobals.RelationType_isOfType.GUID,
                                                                                       .OrderID = 1}}

            objOItem_Result = objDBLevel_ModuleList.get_Data_ObjectRel(searchModules, boolIDs:=False)

        End If

        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            Dim moduleList = objGlobals.get_ModuleExecutablesInSearchPath.OrderBy(Function(mods) mods.ModuleGuid).ThenByDescending(Function(mods) mods.Major).ThenByDescending(Function(mods) mods.Minor).ThenByDescending(Function(mods) mods.Build).ThenByDescending(Function(mods) mods.Revision).ToList()

            
            If Not objDBLevel_ModuleList.OList_ObjectRel.Any() Or Not moduleList Is Nothing Then
                moduleListGlobal = New List(Of clsModuleForCommandLine)
                objDBLevel_ModuleList.OList_ObjectRel.ForEach(Sub(modExist)
                                                                  Dim modules = moduleList.Where(Function(mods) mods.ModuleGuid = modExist.ID_Object)
                                                                  If modules.Any() Then
                                                                      Dim objModule = modules.First().Clone
                                                                      objModule.MainModuleFunction = modExist.Name_Other
                                                                      moduleListGlobal.Add(objModule)
                                                                  End If
                                                              End Sub)

                If moduleListGlobal.Any() Then
                    FillGrid()

                Else
                    MsgBox("Es konnten keine Module ermittelt werden!", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Es konnten keine Module ermittelt werden!", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Beim Ermitteln der Module ist ein Fehler aufgetreten!", MsgBoxStyle.Information)
        End If



    End Sub

    Private Sub FillGrid()
        strFilter = TextBox_Filter.Text

        Dim moduleListSortable As SortableBindingList(Of clsModuleForCommandLine)
        If String.IsNullOrEmpty(strFilter) Then

            moduleListSortable = New SortableBindingList(Of clsModuleForCommandLine)(moduleListGlobal)
        Else
            moduleListSortable = New SortableBindingList(Of clsModuleForCommandLine)(moduleListGlobal.Where(Function(modl) modl.ModuleName.ToLower().Contains(strFilter.ToLower())))
        End If


        DataGridView_Modules.DataSource = moduleListSortable

        For Each objCol As DataGridViewColumn In DataGridView_Modules.Columns
            If objCol.Name = "ModuleName" Or objCol.Name = "ModulePath" Or objCol.Name = "MainModuleFunction" Or objCol.Name = "Version" Then
                objCol.Visible = True

            Else
                objCol.Visible = False
            End If
        Next
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

    Private Sub Timer_Filter_Tick(sender As Object, e As EventArgs) Handles Timer_Filter.Tick
        Timer_Filter.Stop()
        FillGrid()
    End Sub


    Private Sub TextBox_Filter_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Filter.TextChanged
        Timer_Filter.Stop()
        Timer_Filter.Start()
    End Sub
End Class