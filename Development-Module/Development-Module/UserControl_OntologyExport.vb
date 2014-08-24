imports OntologyClasses.BaseClasses
Imports Ontology_Module
Imports Structure_Module
Imports Filesystem_Module
Public Class UserControl_OntologyExport
    Private objLocalConfig As clsLocalConfig
    Private oList_OntologyExports As SortableBindingList(Of clsOntologyExport)
    Private oList_OntologyFiles As SortableBindingList(Of clsOntologyFiles)
    Private objDataWork_Export As clsDataWork_Export
    Private objDataWork_Details As clsDataWork_Details
    Private objDataWork_OntologyConfig As clsDataWork_OntologyConfig
    Private objOItem_Development As clsOntologyItem
    Private objExport As clsExport

    Private objDBLevel_Module As clsDBLevel
    Private objDBLevel_ModuleFunctions As clsDBLevel
    Private objDBLevel_BaseConfig As clsDBLevel
    Private objDBLevel_BaseConfigClasse As clsDBLevel

    Private objTransaction As clsTransaction
    Private objBlobConnection As clsBlobConnection
    Private objFileWork As clsFileWork

    Private objFrm_ObjectEdit As frm_ObjectEdit

    Public Sub New(LocalConfig As clsLocalConfig)
        
        ' This call is required by the designer.
        InitializeComponent()
        
        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = LocalConfig
        initialize()
    End Sub

    Private sub initialize()
        objDataWork_Export = New clsDataWork_Export(objLocalConfig)
        objDataWork_Details = New clsDataWork_Details(objLocalConfig)
        objDataWork_OntologyConfig = New clsDataWork_OntologyConfig(objLocalConfig)
        objExport = New clsExport(objLocalConfig.Globals)
        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objFileWork = New clsFileWork(objLocalConfig.Globals)
        objBlobConnection = New clsBlobConnection(objLocalConfig.Globals)
        objDBLevel_Module = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BaseConfig = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BaseConfigClasse = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ModuleFunctions = New clsDBLevel(objLocalConfig.Globals)

    End Sub

    Public sub initialize_OntologyExport(Optional OItem_Development As clsOntologyItem = Nothing)
        objDataWork_Export.GetData_ORels()
        objOItem_Development = OItem_Development
        Clear()
        Dim objOItem_Result = objDataWork_Export.OItem_Result_ORels
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

            oList_OntologyFiles = New SortableBindingList(Of clsOntologyFiles)
            If OItem_Development Is Nothing Then
                oList_OntologyExports = objDataWork_Export.OList_OntologyExports

            Else
                oList_OntologyExports = New SortableBindingList(Of clsOntologyExport)(objDataWork_Export.OList_OntologyExports.Where(Function(p) p.ID_Development = objOItem_Development.GUID))

            End If

            DataGridView_Exports.DataSource = oList_OntologyExports
            DataGridView_Exports.Columns(0).Visible = False
            DataGridView_Exports.Columns(2).Visible = False
            DataGridView_Exports.Columns(3).Visible = False
            DataGridView_Exports.Columns(4).Visible = False
            DataGridView_Exports.Columns(6).Visible = False

            DataGridView_Files.DataSource = oList_OntologyFiles
            DataGridView_Files.Columns(0).Visible = False
            DataGridView_Files.Columns(2).Visible = False

            DataGridView_Exports.Enabled = True
            DataGridView_Files.Enabled = True

            ConfigureCreateButton()
        Else
            MsgBox("Die Exporte können nicht ermittelt werden!", MsgBoxStyle.Critical)

        End If

    End Sub

    Private Sub ConfigureCreateButton()
        ToolStripButton_CreateFiles.Enabled = False
        If Not objOItem_Development Is Nothing Then
            objDataWork_OntologyConfig.OItem_Development = objOItem_Development
            objDataWork_OntologyConfig.GetData_OntologyOfDevelopment()
            objDataWork_Details.OItem_Development = objOItem_Development
            objDataWork_Details.GetData_Version()
            If objDataWork_Details.OItem_Result_Version.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If Not objDataWork_Details.OItem_Version Is Nothing Then
                    If Not oList_OntologyExports.Any(Function(p) p.ID_DevelopmentVersion = objDataWork_Details.OItem_Version.GUID) Then
                        ToolStripButton_CreateFiles.Enabled = True
                    End If

                Else

                    ToolStripButton_CreateFiles.Enabled = True
                End If

            Else
                MsgBox("Die Version der Softwareentwicklung kann nicht ermittelt werden!", MsgBoxStyle.Exclamation)
            End If
        End If

    End Sub

    Private sub Clear()
        DataGridView_Exports.DataSource = Nothing
        ToolStripButton_CreateFiles.Enabled = False
        ToolStripButton_SaveFiles.Enabled = False
        DataGridView_Exports.Enabled = False
        DataGridView_Files.DataSource = Nothing
        DataGridView_Files.Enabled = False
    End Sub

    Private Sub DataGridView_Exports_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView_Exports.SelectionChanged
        ToolStripButton_SaveFiles.Enabled = False
        If DataGridView_Exports.SelectedRows.Count = 1 Then
            Dim objOntologyExport As clsOntologyExport = DataGridView_Exports.SelectedRows(0).DataBoundItem
            oList_OntologyFiles = New SortableBindingList(Of clsOntologyFiles)(objDataWork_Export.OList_OntologyFiles.Where(Function(p) p.ID_OntologyExport = objOntologyExport.ID_OntologyExport))
            DataGridView_Files.DataSource = oList_OntologyFiles
            DataGridView_Files.Columns(0).Visible = False
            DataGridView_Files.Columns(2).Visible = False
            If DataGridView_Files.Rows.Count > 0 Then

                ToolStripButton_SaveFiles.Enabled = True

            End If
        Else
            DataGridView_Files.DataSource = Nothing
        End If
    End Sub

    Private Sub ToolStripButton_CreateFiles_Click(sender As Object, e As EventArgs) Handles ToolStripButton_CreateFiles.Click

        If objDataWork_OntologyConfig.OItem_Result_OntologyOfDevelopment.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim strGUID = objLocalConfig.Globals.NewGUID
            Dim strPath = "%TEMP%\" & strGUID
            strPath = Environment.ExpandEnvironmentVariables(strPath)

            IO.Directory.CreateDirectory(strPath)
            objExport.Clear()
            Dim objOItem_Result = GetOntologyStructuresOfBaseConfig()
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                objOItem_Result = objExport.Export_Ontology(objDataWork_OntologyConfig.OItem_Ontology, strPath, ModeEnum.AllRelations Or ModeEnum.ClassParents Or ModeEnum.OntologyStructures, Nothing, True)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Dim strFiles = objExport.Files
                    If strFiles.Any Then
                        Dim objOItem_OntologyExport = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                                                .Name = objDataWork_Details.OItem_Version.Name, _
                                                                                .GUID_Parent = objLocalConfig.OItem_type_ontology_export.GUID, _
                                                                                .Type = objLocalConfig.Globals.Type_Object}

                        objTransaction.ClearItems()
                        objOItem_Result = objTransaction.do_Transaction(objOItem_OntologyExport)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Dim objOItem_Files = New List(Of clsOntologyItem)
                            For Each strFile In strFiles
                                objOItem_Files.Add(New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                                              .Name = IO.Path.GetFileName(strFile), _
                                                                              .GUID_Parent = objLocalConfig.OItem_Class_File.GUID, _
                                                                              .Type = objLocalConfig.Globals.Type_Object})
                                objOItem_Result = objTransaction.do_Transaction(objOItem_Files.Last())
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objOItem_Result = objBlobConnection.save_File_To_Blob(objOItem_Files.Last(), strFile)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        Dim objORel_OntologyExport_To_File = objDataWork_Export.Rel_OntologyExport_To_File(objOItem_OntologyExport, objOItem_Files.Last())
                                        objOItem_Result = objTransaction.do_Transaction(objORel_OntologyExport_To_File)
                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                            Exit For

                                        End If
                                    End If

                                End If
                            Next
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                Dim objORel_OntologyExport_To_Ontology = objDataWork_Export.Rel_OntologyExport_To_Ontology(objOItem_OntologyExport, objDataWork_OntologyConfig.OItem_Ontology)
                                objOItem_Result = objTransaction.do_Transaction(objORel_OntologyExport_To_Ontology)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    Dim objORel_OntologyExport_To_Version = objDataWork_Export.Rel_OntologyExport_To_Version(objOItem_OntologyExport, objDataWork_Details.OItem_Version)
                                    objOItem_Result = objTransaction.do_Transaction(objORel_OntologyExport_To_Version)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        initialize_OntologyExport(objOItem_Development)
                                    Else
                                        For Each objOItem_File In objOItem_Files
                                            objOItem_Result = objBlobConnection.del_Blob(objOItem_File)
                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                                Exit For
                                            End If
                                        Next

                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                            objTransaction.rollback()
                                            MsgBox("Beim Speichern ist ein Fehler unterlaufen!", MsgBoxStyle.Exclamation)
                                        End If
                                    End If
                                Else
                                    For Each objOItem_File In objOItem_Files
                                        objOItem_Result = objBlobConnection.del_Blob(objOItem_File)
                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                            Exit For
                                        End If
                                    Next

                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        objTransaction.rollback()
                                        MsgBox("Beim Speichern ist ein Fehler unterlaufen!", MsgBoxStyle.Exclamation)
                                    End If
                                End If
                            Else

                                For Each objOItem_File In objOItem_Files
                                    objOItem_Result = objBlobConnection.del_Blob(objOItem_File)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                        Exit For
                                    End If
                                Next

                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTransaction.rollback()
                                    MsgBox("Beim Speichern ist ein Fehler unterlaufen!", MsgBoxStyle.Exclamation)
                                End If
                            End If

                        Else
                            MsgBox("Beim Speichern ist ein Fehler unterlaufen!", MsgBoxStyle.Exclamation)
                        End If

                    Else
                        MsgBox("Es wurde nichts exportiert!", MsgBoxStyle.Information)
                    End If
                Else
                    MsgBox("Die Ontologie konnte nicht exportiert werden!", MsgBoxStyle.Exclamation)
                End If
            Else
                MsgBox("Beim Exportieren ist ein Fehler unterlaufen!", MsgBoxStyle.Exclamation)
            End If
            

        Else
            MsgBox("Beim Exportieren ist ein Fehler unterlaufen!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Function GetOntologyStructuresOfBaseConfig() As clsOntologyItem
        Dim objORel_Module_To_SoftwareDevelopment = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Other = objOItem_Development.GUID, _
                                                                                                           .ID_RelationType = objLocalConfig.OItem_RelationType_offered_by.GUID, _
                                                                                                           .ID_Parent_Object = objLocalConfig.OItem_Class_Module.GUID}}
        Dim objOItem_Result = objDBLevel_Module.get_Data_ObjectRel(objORel_Module_To_SoftwareDevelopment, boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objORel_BaseConfigClasses = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Class_Module.GUID}}
            If objORel_BaseConfigClasses.Any Then
                objOItem_Result = objDBLevel_BaseConfigClasse.get_Data_Classes(objORel_BaseConfigClasses)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Dim searchModuleFunction = objDBLevel_Module.OList_ObjectRel.Select(Function(mods) New clsObjectRel With {.ID_Object = mods.ID_Object,
                                                                                                                              .ID_RelationType = objLocalConfig.Globals.RelationType_isOfType.GUID,
                                                                                                                              .ID_Parent_Other = objLocalConfig.Globals.Class_ModuleFunction.GUID}).ToList()
                    If searchModuleFunction.Any() Then
                        objOItem_Result = objDBLevel_ModuleFunctions.get_Data_ObjectRel(searchModuleFunction, boolIDs:=False)

                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID And objDBLevel_ModuleFunctions.OList_ObjectRel.Any() Then
                            objExport.OList_Objects.Add(objDBLevel_ModuleFunctions.OList_ObjectRel.Select(Function(mods) New clsOntologyItem With {.GUID = mods.ID_Other,
                                                                                                                                                   .Name = mods.Name_Other,
                                                                                                                                                   .GUID_Parent = mods.ID_Parent_Other}).First())
                        End If
                    End If

                    Dim objORel_BaseConfig_To_Module = (From objModule In objDBLevel_Module.OList_ObjectRel
                                                        From objBaseConfigClass In objDBLevel_BaseConfigClasse.OList_Classes
                                                        Select New clsObjectRel With {.ID_Other = objModule.ID_Object, _
                                                                                      .ID_Parent_Object = objBaseConfigClass.GUID, _
                                                                                      .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID}).ToList

                    If objORel_BaseConfig_To_Module.Any() Then
                        objOItem_Result = objDBLevel_BaseConfig.get_Data_ObjectRel(objORel_BaseConfig_To_Module, boolIDs:=False)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objExport.OList_Classes.AddRange(From objBaseConfig In objDBLevel_BaseConfig.OList_ObjectRel
                                                             Join objBaseConfigClass In objDBLevel_BaseConfigClasse.OList_Classes On objBaseConfig.ID_Parent_Object Equals objBaseConfigClass.GUID
                                                             Select objBaseConfigClass)


                            objExport.OList_Objects.AddRange(objDBLevel_BaseConfig.OList_ObjectRel.Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Object, _
                                                                                                                                                .Name = p.Name_Object, _
                                                                                                                                                .GUID_Parent = p.ID_Parent_Object, _
                                                                                                                                                .Type = objLocalConfig.Globals.Type_Object}))

                        End If
                    End If

                End If
            End If
            
        End If

        Return objOItem_Result
    End Function

    Private Sub ToolStripButton_SaveFiles_Click(sender As Object, e As EventArgs) Handles ToolStripButton_SaveFiles.Click
        If FolderBrowserDialog_FileDest.ShowDialog(Me) = DialogResult.OK Then
            Dim strPath = FolderBrowserDialog_FileDest.SelectedPath
            Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone
            For Each objDGVR As DataGridViewRow In DataGridView_Files.Rows
                Dim objFile As clsOntologyFiles = objDGVR.DataBoundItem
                Dim objOItem_File = New clsOntologyItem With {.GUID = objFile.ID_File, _
                                                              .Name = objFile.Name_File, _
                                                              .GUID_Parent = objLocalConfig.OItem_Class_File.GUID, _
                                                              .Type = objLocalConfig.Globals.Type_Object}

                objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_File, strPath & IO.Path.DirectorySeparatorChar & objOItem_File.Name, True)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    MsgBox("Die Dateien konnten nicht gespeichert werden!", MsgBoxStyle.Exclamation)
                    Exit For
                End If

            Next

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                MsgBox("Die Dateien wurden exportiert!", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub DataGridView_Exports_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_Exports.RowHeaderMouseDoubleClick

        Dim objOntologyExport As clsOntologyExport = DataGridView_Exports.Rows(e.RowIndex).DataBoundItem

        Dim objOList_Objects = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID = objOntologyExport.ID_OntologyExport, _
                                                                                             .Name = objOntologyExport.Name_OntologyExport, _
                                                                                             .GUID_Parent = objLocalConfig.OItem_type_ontology_export.GUID, _
                                                                                             .Type = objLocalConfig.Globals.Type_Object}}

        objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, objOList_Objects, 0, objLocalConfig.Globals.Type_Object, Nothing)
        objFrm_ObjectEdit.ShowDialog(Me)

        If objFrm_ObjectEdit.DialogResult = DialogResult.OK Then

        End If
    End Sub
End Class
