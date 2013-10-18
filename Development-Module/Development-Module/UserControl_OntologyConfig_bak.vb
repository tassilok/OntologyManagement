Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class UserControl_OntologyConfig_bak
    Private dtblT_OntologyItems As New DataSet_Development.dtbl_OntologyItemsDataTable

    Private objLocalConfig As clsLocalConfig
    Private objFrmOntologyModule As frmMain
    Private objFrmCodeGenerator As frmCodeGenerator
    Private objDataWork_OntologyConfig As clsDataWork_OntologyConfig_bak
    Private objTransaction_OntologyConfig As clsTransaction_OntologyConfig
    Private objOItem_Development As clsOntologyItem

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Public Sub initialize(ByVal OItem_Development As clsOntologyItem)
        objOItem_Development = OItem_Development

        ToolStripButton_Add.Enabled = False
        ToolStripButton_Remove.Enabled = False
        ToolStripButton_View.Enabled = False

        If Not objOItem_Development Is Nothing Then
            objDataWork_OntologyConfig.get_ConfigItems(objOItem_Development)

            dtblT_OntologyItems = objDataWork_OntologyConfig.dtbl_OntologyItems

            ToolStripButton_Add.Enabled = True
        Else
            dtblT_OntologyItems.Clear()
        End If

        BindingSource_ConfigItems.DataSource = dtblT_OntologyItems
        DataGridView_ConfigItems.DataSource = BindingSource_ConfigItems

        DataGridView_ConfigItems.Columns(0).Visible = False
        DataGridView_ConfigItems.Columns(2).Visible = False
        DataGridView_ConfigItems.Columns(5).Visible = False

        ToolStripLabel_Count.Text = DataGridView_ConfigItems.RowCount
        If DataGridView_ConfigItems.RowCount > 0 Then
            ToolStripButton_View.Enabled = True
        Else
            ToolStripButton_View.Enabled = False
        End If
    End Sub

    Private Sub set_DBConnection()
        objDataWork_OntologyConfig = New clsDataWork_OntologyConfig_bak(objLocalConfig)
        objTransaction_OntologyConfig = New clsTransaction_OntologyConfig(objLocalConfig)
    End Sub

    Private Sub DataGridView_ConfigItems_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView_ConfigItems.SelectionChanged
        If DataGridView_ConfigItems.SelectedRows.Count > 0 Then
            ToolStripButton_Remove.Enabled = True
        Else
            ToolStripButton_Remove.Enabled = False
        End If
    End Sub

    Private Sub ToolStripButton_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_View.Click
        'objFrmCodeGenerator = New frmCodeGenerator(objLocalConfig, , objOItem_Development)
        objFrmCodeGenerator.ShowDialog(Me)

    End Sub

    Private Sub ToolStripButton_Add_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Add.Click
        objFrmOntologyModule = New frmMain(objLocalConfig.Globals)
        objFrmOntologyModule.ShowDialog(Me)


        Dim intToDo As Integer
        Dim intDone As Integer

        If objFrmOntologyModule.DialogResult = DialogResult.OK Then
            intToDo = objFrmOntologyModule.OList_Simple.Count
            intDone = 0
            For Each objOItem_Item In objFrmOntologyModule.OList_Simple
                Dim objOItem_OntologyItem = objDataWork_OntologyConfig.get_ConfigItem(objDataWork_OntologyConfig.OItem_Config, objOItem_Item)
                If Not objOItem_OntologyItem.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    If Not objOItem_OntologyItem.GUID = objLocalConfig.Globals.LState_Relation.GUID Then
                        If objOItem_OntologyItem.new_Item Then
                            Dim objOItem_Result = objTransaction_OntologyConfig.save_ConfigItem(objOItem_OntologyItem, True)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objOItem_Result = objTransaction_OntologyConfig.save_ConfigItemToRef(objOItem_OntologyItem, objOItem_Item, True)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objOItem_Result = objTransaction_OntologyConfig.save_ConfigToConfigItem(objDataWork_OntologyConfig.OItem_Config, objOItem_OntologyItem, True)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                        objOItem_Result = objTransaction_OntologyConfig.save_ConfigItemToRef(objOItem_OntologyItem, objOItem_Item, True)
                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                            intDone = intDone + 1
                                        Else

                                            objTransaction_OntologyConfig.del_ConfigItem(objOItem_OntologyItem, True)
                                        End If

                                    End If
                                Else
                                    objTransaction_OntologyConfig.del_ConfigItem(objOItem_OntologyItem, True)
                                End If

                            End If
                        Else
                            Dim objOItem_Result = objTransaction_OntologyConfig.save_ConfigToConfigItem(objDataWork_OntologyConfig.OItem_Config, objOItem_OntologyItem, True)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                intDone = intDone + 1
                            End If
                        End If
                    Else
                        intDone = intDone + 1
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub ToolStripButton_Migrate_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_Migrate.Click
        Dim objMoveConfigItemsToOntologies As New clsMoveConfigItemsToOntologies(objLocalConfig,objDataWork_OntologyConfig)
        Dim objOItem_Result = objMoveConfigItemsToOntologies.CopyOntologyItems(objOItem_Development)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            MsgBox("Die Ontology konnte nicht erzeugt werden!")
        End If
    End Sub
End Class
