Imports Structure_Module
Imports OntologyClasses.BaseClasses
Public Class frmModules

    Private objGlobals As clsGlobals

    Private strModule As String

    Private strFilter As String
                    
    Private moduleListGlobal As List(Of clsModuleForCommandLine)

    Private objOItem_Ref As clsOntologyItem
    Private objOItem_Class As clsOntologyItem

    Private objDBLevel_ModuleList As clsDBLevel
    Private objDBLevel_ModulesOfClass As clsDBLevel
    Private objTransaction As clsTransaction
    Private objRelationConfig As clsRelationConfig

    Public ReadOnly Property Selected_Module As String
        Get
            Return strModule
        End Get
    End Property

    Private Sub ToolStripButton_Close_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Public Sub New(Globals As clsGlobals, OItem_Ref As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        objOItem_Ref = OItem_Ref
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objGlobals = Globals

        Initialize()
    End Sub

    Private Sub Initialize()

        Dim objOItem_Result = objGlobals.LState_Success.Clone()
        If objGlobals.DbModuleList Is Nothing Then
            objDBLevel_ModuleList = New clsDBLevel(objGlobals)
            objDBLevel_ModulesOfClass = New clsDBLevel(objGlobals)
            Dim searchModules = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objGlobals.Class_Module.GUID,
                                                                                        .ID_Parent_Other = objGlobals.Class_ModuleFunction.GUID,
                                                                                        .ID_RelationType = objGlobals.RelationType_isOfType.GUID,
                                                                                       .OrderID = 1}}

            objOItem_Result = objDBLevel_ModuleList.get_Data_ObjectRel(searchModules, boolIDs:=False)

        End If

        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            If Not objOItem_Ref Is Nothing Then
                objOItem_Class = objDBLevel_ModulesOfClass.GetOItem(objOItem_Ref.GUID_Parent, objGlobals.Type_Class)
                If objOItem_Ref.Type = objGlobals.Type_Object And objDBLevel_ModuleList.OList_ObjectRel.Any() Then
                    Dim searchClasses = objDBLevel_ModuleList.OList_ObjectRel.Select(Function(mods) New clsObjectRel With {.ID_Object = mods.ID_Object,
                                                                                                                   .ID_RelationType = objGlobals.RelationType_belongingClass.GUID,
                                                                                                                   .ID_Other = objOItem_Ref.GUID_Parent}).ToList()

                    objOItem_Result = objDBLevel_ModulesOfClass.get_Data_ObjectRel(searchClasses, boolIDs:=False)
                End If
            Else

                Dim searchClasses = objDBLevel_ModuleList.OList_ObjectRel.Select(Function(mods) New clsObjectRel With {.ID_Object = mods.ID_Object,
                                                                                                                   .ID_RelationType = objGlobals.RelationType_belongingClass.GUID,
                                                                                                                   .ID_Other = StaticValues.OItem_Module.GUID}).ToList()

                objOItem_Result = objDBLevel_ModulesOfClass.get_Data_ObjectRel(searchClasses, boolIDs:=False)
            End If
        End If
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            Dim moduleList = objGlobals.get_ModuleExecutablesInSearchPath.OrderBy(Function(mods) mods.ModuleGuid).ThenByDescending(Function(mods) mods.Major).ThenByDescending(Function(mods) mods.Minor).ThenByDescending(Function(mods) mods.Build).ThenByDescending(Function(mods) mods.Revision).ToList()


            If Not objDBLevel_ModuleList.OList_ObjectRel.Any() Or Not moduleList Is Nothing Then
                moduleListGlobal = New List(Of clsModuleForCommandLine)

                Dim moduleListWithOrder = (From moduleItem In objDBLevel_ModuleList.OList_ObjectRel
                                 Group Join moduleOfClass In objDBLevel_ModulesOfClass.OList_ObjectRel On moduleItem.ID_Object Equals moduleOfClass.ID_Object Into modulesOfClasses = Group
                                 From moduleOfClass In modulesOfClasses.DefaultIfEmpty()
                                 Select moduleItem, moduleOfClass).ToList()
                moduleListWithOrder.ForEach(Sub(modExist)
                                                Dim modules = moduleList.Where(Function(mods) mods.ModuleGuid = modExist.moduleItem.ID_Object)
                                                If modules.Any() Then
                                                    Dim objModule = modules.First().Clone
                                                    objModule.MainModuleFunction = modExist.moduleItem.Name_Other
                                                    objModule.OrderId = If(modExist.moduleOfClass Is Nothing, 0, modExist.moduleOfClass.OrderID)
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

            moduleListSortable = New SortableBindingList(Of clsModuleForCommandLine)(moduleListGlobal.OrderByDescending(Function(modl) modl.OrderId).ThenBy(Function(modl) modl.ModuleName))
        Else
            moduleListSortable = New SortableBindingList(Of clsModuleForCommandLine)(moduleListGlobal.Where(Function(modl) modl.ModuleName.ToLower().Contains(strFilter.ToLower())).OrderByDescending(Function(modl) modl.OrderId).ThenBy(Function(modl) modl.ModuleName))
        End If


        DataGridView_Modules.DataSource = moduleListSortable

        For Each objCol As DataGridViewColumn In DataGridView_Modules.Columns
            If objCol.Name = "ModuleName" Or objCol.Name = "ModulePath" Or objCol.Name = "MainModuleFunction" Or objCol.Name = "Version" Or objCol.Name = "OrderId" Then
                objCol.Visible = True

            Else
                objCol.Visible = False
            End If
        Next

    End Sub

    Private Sub ContextMenuStrip_Modules_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Modules.Opening
        ApplyToolStripMenuItem.Enabled = False
        If DataGridView_Modules.SelectedRows.Count = 1 Then
            ApplyToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub ApplyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApplyToolStripMenuItem.Click
        Dim objModule = CType(DataGridView_Modules.SelectedRows(0).DataBoundItem, clsModuleForCommandLine)
        If Not objModule Is Nothing Then
            objRelationConfig = New clsRelationConfig(objGlobals)
            objTransaction = New clsTransaction(objGlobals)

            If Not objOItem_Class Is Nothing Then


                Dim objOItem_Module = New clsOntologyItem With {.GUID = objModule.ModuleGuid,
                                                                .Name = objModule.ModuleName,
                                                                .GUID_Parent = objGlobals.Class_Module.GUID,
                                                                .Type = objGlobals.Type_Object}
                Dim objRelUsedClass = objRelationConfig.Rel_ObjectRelation(objOItem_Module, objOItem_Class, objGlobals.RelationType_belongingClass, OrderID:=objModule.OrderId + 1)
                objTransaction.ClearItems()
                objTransaction.do_Transaction(objRelUsedClass)
            Else
                Dim objOItem_Module = New clsOntologyItem With {.GUID = objModule.ModuleGuid,
                                                                .Name = objModule.ModuleName,
                                                                .GUID_Parent = objGlobals.Class_Module.GUID,
                                                                .Type = objGlobals.Type_Object}
                Dim objRelUsedClass = objRelationConfig.Rel_ObjectRelation(objOItem_Module, StaticValues.OItem_Module, objGlobals.RelationType_belongingClass, OrderID:=objModule.OrderId + 1)
                objTransaction.ClearItems()
                objTransaction.do_Transaction(objRelUsedClass)
            End If



            strModule = DataGridView_Modules.SelectedRows(0).Cells(2).Value.ToString()
        Else
            strModule = ""
        End If


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