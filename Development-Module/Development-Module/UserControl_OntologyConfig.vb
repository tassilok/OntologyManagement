Imports  OntologyClasses.BaseClasses
imports Ontology_Module
Imports Structure_Module

Public Class UserControl_OntologyConfig
    Private objLocalConfig As clsLocalConfig

    Private objOItem_Development As clsOntologyItem

    Private WithEvents objUserControl_OntologyItems As UserControl_OntologyItemList
    Private objDataWork_OntologyConfig As clsDataWork_OntologyConfig

    Private objFrmOntologyModule As frmMain

    Private objFrmCodeGenerator As frmCodeGenerator

    Private objTransaction As clsTransaction

    Private objTransaction_Version As clsTransaction_Version

    Private sub LoadedData() Handles objUserControl_OntologyItems.DataLoaded
        If objUserControl_OntologyItems.Rows.Count > 0 Then
            ToolStripButton_View.Enabled = True
        End If
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)
        
        ' This call is required by the designer.
        InitializeComponent()
        
        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = LocalConfig

        initialize()
    End Sub

    public sub initialize_OntologyConfig(OItem_Development As clsOntologyItem)
        objOItem_Development = OItem_Development

        If Not objOItem_Development Is Nothing Then
            objTransaction_Version = New clsTransaction_Version(objLocalConfig, Me, objOItem_Development)
            Dim objOItem_Result = objDataWork_OntologyConfig.GetData(objOItem_Development)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objUserControl_OntologyItems.initialize_List(objDataWork_OntologyConfig.OItem_Ontology)
                ToolStripButton_Add.Enabled = True
            Else
                MsgBox("Die Ontology-Items konnten nicht geladen werden!", MsgBoxStyle.Exclamation)
            End If
        Else
            ClearControls()
        End If
        
    End Sub

    Private sub ClearControls()
        ToolStripButton_Add.Enabled = False
        ToolStripButton_Remove.Enabled = False
        ToolStripButton_View.Enabled = False
    
    End Sub

    Private sub initialize()
        
        objDataWork_OntologyConfig = new clsDataWork_OntologyConfig(objLocalConfig)
        objUserControl_OntologyItems = new UserControl_OntologyItemList(objDataWork_OntologyConfig.DataWork_Ontology)
        objUserControl_OntologyItems.Dock = DockStyle.Fill
        ToolStripContainer1.ContentPanel.Controls.Add(objUserControl_OntologyItems)
        objTransaction = New clsTransaction(objLocalConfig.Globals)

    End Sub

    Private Sub ToolStripButton_View_Click(sender As Object, e As EventArgs) Handles ToolStripButton_View.Click
        If objUserControl_OntologyItems.SelectedRows.Count > 0 Then
            objFrmCodeGenerator = New frmCodeGenerator(objLocalConfig, objUserControl_OntologyItems.SelectedRows, objOItem_Development)
        Else
            objFrmCodeGenerator = New frmCodeGenerator(objLocalConfig, objUserControl_OntologyItems.Rows, objOItem_Development)
        End If


        objFrmCodeGenerator.ShowDialog(Me)
    End Sub

    Private Sub MigrateOConfig()
        Dim objDataWork_OntologyConfigOld = New clsDataWork_OntologyConfig_bak(objLocalConfig)
        objDataWork_OntologyConfigOld.get_ConfigItems(objOItem_Development)
        Dim objMoveConfigItemsToOntologies As New clsMoveConfigItemsToOntologies(objLocalConfig, objDataWork_OntologyConfigOld)
        Dim objOItem_Result = objMoveConfigItemsToOntologies.CopyOntologyItems(objOItem_Development)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            initialize_OntologyConfig(objOItem_Development)
        Else
            MsgBox("Die Ontology konnte nicht erzeugt werden!")
        End If
    End Sub

    Private Sub ToolStripButton_Add_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_Add.Click
        objFrmOntologyModule = New frmMain(objLocalConfig.Globals)
        objFrmOntologyModule.ShowDialog(Me)


        Dim intToDo As Integer
        Dim intDone As Integer

        If objFrmOntologyModule.DialogResult = DialogResult.OK Then
            Dim objOItem_Ontology = objDataWork_OntologyConfig.OItem_Ontology
            intToDo = objFrmOntologyModule.OList_Simple.Count
            intDone = 0
            For Each objOItem_Item In objFrmOntologyModule.OList_Simple
                If Not objDataWork_OntologyConfig.DataWork_Ontology.GetData_OntologiesOfRef(objOItem_Item).Any(Function (p) p.GUID = objOItem_Ontology.GUID) Then
                    Dim objOItem_OntologyItem = new clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                                          .Name = objOItem_Item.Type & "_" & objLocalConfig.Globals.GetConfigName1(objOItem_Item.Name), _
                                                                          .GUID_Parent = objLocalConfig.Globals.Class_OntologyItems.GUID, _
                                                                          .Type = objLocalConfig.Globals.Type_Object}
                    objTransaction.ClearItems()

                    Dim objOItem_Result = objTransaction.do_Transaction(objOItem_OntologyItem)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        Dim objORel_OntologyItem_To_Ref = objDataWork_OntologyConfig.DataWork_Ontology.Rel_OntologyItemToRef(objOItem_OntologyItem,objOItem_Item)
                        objOItem_Result = objTransaction.do_Transaction(objORel_OntologyItem_To_Ref)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Dim objORel_Ontology_To_OntologyItem = objDataWork_OntologyConfig.DataWork_Ontology.Rel_Ontology_To_OntologyItem(objOItem_Ontology, objOItem_OntologyItem)
                            objOItem_Result = objTransaction.do_Transaction(objORel_Ontology_To_OntologyItem)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                intDone = intDone + 1
                            Else 
                                objTransaction.rollback()
                            End If
                        Else 
                            objTransaction.rollback()
                        End If

                    End If
                Else 
                    intDone = intDone + 1
                End If
            Next

            If intDone < intToDo Then
                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Items verknüpft werden!",MsgBoxStyle.Exclamation)
            End If

            If intDone > 0 Then
                objTransaction_Version.SaveVersion()
            End If

            initialize_OntologyConfig(objOItem_Development)
        End If
    End Sub

    Private Sub ToolStripButton_Migrate_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Migrate.Click
        MigrateOConfig()
    End Sub
End Class
