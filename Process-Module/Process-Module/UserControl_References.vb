Imports Ontolog_Module
Imports Filesystem_Module
Public Class UserControl_References
    Private objLocalConfig As clsLocalConfig

    Private objOItem_Process As clsOntologyItem
    Private objOItem_ProcessLog As clsOntologyItem

    Private objFrm_FilesystemModule As frm_FilesystemModule
    Private objFrm_ObjectEdit As frm_ObjectEdit
    Private objFileWork As clsFileWork
    Private objFrmMain As frmMain
    Private objTransaction_References As clsTransaction_References
    Private objDataWork_References_Process As clsDataWork_References
    Private objDataWork_References_ProcessLog As clsDataWork_References

    Private objTreeNode_Refs As TreeNode
    Private objTreeNode_Classes As TreeNode
    Private objTreeNode_Bats As TreeNode
    Private objTreeNode_Attributes As TreeNode
    Private objTreeNode_RelationTypes As TreeNode
    Private objTreeNode_Manuals As TreeNode
    Private objTreeNode_NeedsPar As TreeNode
    Private objTreeNode_NeedsChildPar As TreeNode
    Private objTreeNode_Variables As TreeNode
    Private objTreeNode_Responsibilities As TreeNode
    Private objTreeNode_Groups As TreeNode
    Private objTreeNode_Users As TreeNode
    Private objTreeNode_Documents As TreeNode
    Private objTreeNode_Files As TreeNode
    Private objTreeNode_Folders As TreeNode
    Private objTreeNode_Roles As TreeNode
    Private objTreeNode_Applications As TreeNode
    Private objTreeNode_Medias As TreeNode
    Private objTreeNode_Belongings As TreeNode
    Private objTreeNode_Utils As TreeNode
    Private objTreeNode_Materials As TreeNode

    Private boolRefs As Boolean
    Private boolClasses As Boolean
    Private boolBats As Boolean
    Private boolAttributes As Boolean
    Private boolRelationTypes As Boolean
    Private boolManuals As Boolean
    Private boolNeedsPar As Boolean
    Private boolNeedsChildPar As Boolean
    Private boolVariables As Boolean
    Private boolResponsibilities As Boolean
    Private boolGroups As Boolean
    Private boolUsers As Boolean
    Private boolDocuments As Boolean
    Private boolFiles As Boolean
    Private boolFolders As Boolean
    Private boolRoles As Boolean
    Private boolApplications As Boolean
    Private boolMedias As Boolean
    Private boolBelongings As Boolean
    Private boolUtils As Boolean
    Private boolMaterials As Boolean

    Private objFrmOntologyModule As frmMain



    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        set_DBConnection()

    End Sub

    Private Sub fill_Refs()
        objDataWork_References_Process.clear_Refs()
        objDataWork_References_ProcessLog.clear_Refs()

        objDataWork_References_Process.add_Ref(objLocalConfig.OItem_Type_Things_References, objLocalConfig.OItem_RelationType_belonging_Material, objTreeNode_Utils, objLocalConfig.ImageID_Util)
        objDataWork_References_Process.add_Ref(objLocalConfig.OItem_Type_Variable, objLocalConfig.OItem_RelationType_needs, objTreeNode_Variables, objLocalConfig.ImageID_Variable)
        objDataWork_References_Process.add_Ref(objLocalConfig.OItem_type_User, objLocalConfig.OItem_RelationType_needs_authority, objTreeNode_Users, objLocalConfig.ImageID_User)
        objDataWork_References_Process.add_Ref(objLocalConfig.OItem_Type_responsibility, objLocalConfig.OItem_RelationType_needs_authority, objTreeNode_Responsibilities, objLocalConfig.ImageID_Responsibility)
        objDataWork_References_Process.add_Ref(objLocalConfig.OItem_Type_Group, objLocalConfig.OItem_RelationType_needs_authority, objTreeNode_Groups, objLocalConfig.ImageID_Group)
        objDataWork_References_Process.add_Ref(objLocalConfig.OItem_Type_Manual, objLocalConfig.OItem_RelationType_needs, objTreeNode_Manuals, objLocalConfig.ImageID_Manual)
        objDataWork_References_Process.add_Ref(objLocalConfig.OItem_Type_Role, objLocalConfig.OItem_RelationType_needs_authority, objTreeNode_Roles, objLocalConfig.ImageID_Role)
        objDataWork_References_Process.add_Ref(objLocalConfig.OItem_type_Folder, objLocalConfig.OItem_RelationType_needs, objTreeNode_Folders, objLocalConfig.ImageID_Folder)
        objDataWork_References_Process.add_Ref(objLocalConfig.OItem_Type_Application, objLocalConfig.OItem_RelationType_needs, objTreeNode_Applications, objLocalConfig.ImageID_Application)
        objDataWork_References_Process.add_Ref(objLocalConfig.OItem_Type_Media, objLocalConfig.OItem_RelationType_needs, objTreeNode_Medias, objLocalConfig.ImageID_Media)
        objDataWork_References_Process.add_Ref(objLocalConfig.OItem_Type_Things_References, objLocalConfig.OItem_RelationType_belonging_Util, objTreeNode_Utils, objLocalConfig.ImageID_Util)
        objDataWork_References_Process.add_Ref(objLocalConfig.OItem_Type_File, objLocalConfig.OItem_RelationType_needs, objTreeNode_Files, objLocalConfig.ImageID_File)
        objDataWork_References_Process.add_Ref(objLocalConfig.OItem_Type_Process, objLocalConfig.OItem_RelationType_needs_Child, objTreeNode_NeedsChildPar, objLocalConfig.ImageID_NeedsChild)
        objDataWork_References_Process.add_Ref(objLocalConfig.OItem_Type_Process, objLocalConfig.OItem_RelationType_needed_Documentation, objTreeNode_Documents, objLocalConfig.ImageID_Document)
        objDataWork_References_Process.add_Ref(objLocalConfig.OItem_Type_Process, objLocalConfig.OItem_RelationType_belonging_Sem_Item, objTreeNode_Refs, objLocalConfig.ImageID_Belonging)
        objDataWork_References_Process.add_Ref(objLocalConfig.OItem_Type_Process, objLocalConfig.OItem_RelationType_needs, objTreeNode_NeedsPar, objLocalConfig.ImageID_Needs)

        objDataWork_References_ProcessLog.add_Ref(objLocalConfig.OItem_Type_Things_References, objLocalConfig.OItem_RelationType_belonging_Material, objTreeNode_Utils, objLocalConfig.ImageID_Util)
        objDataWork_References_ProcessLog.add_Ref(objLocalConfig.OItem_Type_Variable, objLocalConfig.OItem_RelationType_needs, objTreeNode_Variables, objLocalConfig.ImageID_Variable)
        objDataWork_References_ProcessLog.add_Ref(objLocalConfig.OItem_type_User, objLocalConfig.OItem_RelationType_needs_authority, objTreeNode_Users, objLocalConfig.ImageID_User)
        objDataWork_References_ProcessLog.add_Ref(objLocalConfig.OItem_Type_responsibility, objLocalConfig.OItem_RelationType_needs_authority, objTreeNode_Responsibilities, objLocalConfig.ImageID_Responsibility)
        objDataWork_References_ProcessLog.add_Ref(objLocalConfig.OItem_Type_Group, objLocalConfig.OItem_RelationType_needs_authority, objTreeNode_Groups, objLocalConfig.ImageID_Group)
        objDataWork_References_ProcessLog.add_Ref(objLocalConfig.OItem_Type_Manual, objLocalConfig.OItem_RelationType_needs, objTreeNode_Manuals, objLocalConfig.ImageID_Manual)
        objDataWork_References_ProcessLog.add_Ref(objLocalConfig.OItem_Type_Role, objLocalConfig.OItem_RelationType_needs_authority, objTreeNode_Roles, objLocalConfig.ImageID_Role)
        objDataWork_References_ProcessLog.add_Ref(objLocalConfig.OItem_type_Folder, objLocalConfig.OItem_RelationType_needs, objTreeNode_Folders, objLocalConfig.ImageID_Folder)
        objDataWork_References_ProcessLog.add_Ref(objLocalConfig.OItem_Type_Application, objLocalConfig.OItem_RelationType_needs, objTreeNode_Applications, objLocalConfig.ImageID_Application)
        objDataWork_References_ProcessLog.add_Ref(objLocalConfig.OItem_Type_Media, objLocalConfig.OItem_RelationType_needs, objTreeNode_Medias, objLocalConfig.ImageID_Media)
        objDataWork_References_ProcessLog.add_Ref(objLocalConfig.OItem_Type_Things_References, objLocalConfig.OItem_RelationType_belonging_Util, objTreeNode_Utils, objLocalConfig.ImageID_Util)
        objDataWork_References_ProcessLog.add_Ref(objLocalConfig.OItem_Type_File, objLocalConfig.OItem_RelationType_needs, objTreeNode_Files, objLocalConfig.ImageID_File)
        objDataWork_References_ProcessLog.add_Ref(objLocalConfig.OItem_Type_Process, objLocalConfig.OItem_RelationType_needs_Child, objTreeNode_NeedsChildPar, objLocalConfig.ImageID_NeedsChild)
        objDataWork_References_ProcessLog.add_Ref(objLocalConfig.OItem_Type_Process, objLocalConfig.OItem_RelationType_needed_Documentation, objTreeNode_Documents, objLocalConfig.ImageID_Document)
        objDataWork_References_ProcessLog.add_Ref(objLocalConfig.OItem_Type_Process, objLocalConfig.OItem_RelationType_belonging_Sem_Item, objTreeNode_Refs, objLocalConfig.ImageID_Belonging)
        objDataWork_References_ProcessLog.add_Ref(objLocalConfig.OItem_Type_Process, objLocalConfig.OItem_RelationType_needs, objTreeNode_NeedsPar, objLocalConfig.ImageID_Needs)
    End Sub

    Private Sub set_DBConnection()
        objDataWork_References_Process = New clsDataWork_References(objLocalConfig)
        objDataWork_References_ProcessLog = New clsDataWork_References(objLocalConfig)
        objTransaction_References = New clsTransaction_References(objLocalConfig)
    End Sub


    Public Sub clear_Nodes()
        TreeView_Refs.Nodes.Clear()
    End Sub

    Public Sub fill_Tree_Ref_Process(ByVal OItem_Process As clsOntologyItem, Optional ByVal OItem_ProcessLog As clsOntologyItem = Nothing)
        objOItem_Process = OItem_Process
        objOItem_ProcessLog = OItem_ProcessLog
        If objOItem_ProcessLog Is Nothing Then
            LogItemToolStripMenuItem.Visible = False
        Else
            LogItemToolStripMenuItem.Visible = True
        End If
        TreeView_Refs.Nodes.Clear()

        objTreeNode_Refs = TreeView_Refs.Nodes.Add(objLocalConfig.OItem_RelationType_belonging_Sem_Item.GUID.ToString, objLocalConfig.OItem_RelationType_belonging_Sem_Item.Name, objLocalConfig.ImageID_Refs, objLocalConfig.ImageID_Refs)
        objTreeNode_NeedsPar = TreeView_Refs.Nodes.Add(objLocalConfig.OItem_RelationType_needs.GUID.ToString, objLocalConfig.OItem_RelationType_needs.Name, objLocalConfig.ImageID_NeedsPar, objLocalConfig.ImageID_NeedsPar)
        objTreeNode_NeedsChildPar = TreeView_Refs.Nodes.Add(objLocalConfig.OItem_RelationType_needs_Child.ToString, objLocalConfig.OItem_RelationType_needs_Child.Name, objLocalConfig.ImageID_NeedsChildPar, objLocalConfig.ImageID_NeedsChildPar)
        objTreeNode_Files = TreeView_Refs.Nodes.Add(objLocalConfig.OItem_Type_File.GUID.ToString, objLocalConfig.OItem_Type_File.Name, objLocalConfig.ImageID_Files, objLocalConfig.ImageID_Files)
        objTreeNode_Folders = TreeView_Refs.Nodes.Add(objLocalConfig.OItem_type_Folder.GUID.ToString, objLocalConfig.OItem_type_Folder.Name, objLocalConfig.ImageID_Folders, objLocalConfig.ImageID_Folders)
        objTreeNode_Applications = TreeView_Refs.Nodes.Add(objLocalConfig.OItem_Type_Application.GUID.ToString, objLocalConfig.OItem_Type_Application.Name, objLocalConfig.ImageID_Applications, objLocalConfig.ImageID_Applications)
        objTreeNode_Medias = TreeView_Refs.Nodes.Add(objLocalConfig.OItem_Type_Media.GUID.ToString, objLocalConfig.OItem_Type_Media.Name, objLocalConfig.ImageID_Medias, objLocalConfig.ImageID_Medias)
        objTreeNode_Responsibilities = TreeView_Refs.Nodes.Add(objLocalConfig.OItem_Type_responsibility.GUID.ToString, objLocalConfig.OItem_Type_responsibility.Name, objLocalConfig.ImageID_Responsibilities, objLocalConfig.ImageID_Responsibilities)
        objTreeNode_Roles = TreeView_Refs.Nodes.Add(objLocalConfig.OItem_Type_Role.GUID.ToString, objLocalConfig.OItem_Type_Role.Name, objLocalConfig.ImageID_Roles, objLocalConfig.ImageID_Roles)
        objTreeNode_Users = TreeView_Refs.Nodes.Add(objLocalConfig.OItem_type_User.GUID.ToString, objLocalConfig.OItem_type_User.Name, objLocalConfig.ImageID_Users, objLocalConfig.ImageID_Users)
        objTreeNode_Groups = TreeView_Refs.Nodes.Add(objLocalConfig.OItem_Type_Group.GUID.ToString, objLocalConfig.OItem_Type_Group.Name, objLocalConfig.ImageID_Groups, objLocalConfig.ImageID_Groups)
        objTreeNode_Variables = TreeView_Refs.Nodes.Add(objLocalConfig.OItem_Type_Variable.GUID.ToString, objLocalConfig.OItem_Type_Variable.Name, objLocalConfig.ImageID_Variables, objLocalConfig.ImageID_Variables)
        objTreeNode_Documents = TreeView_Refs.Nodes.Add(objLocalConfig.OItem_RelationType_needed_Documentation.GUID.ToString, objLocalConfig.OItem_RelationType_needed_Documentation.Name, objLocalConfig.ImageID_Documents, objLocalConfig.ImageID_Documents)
        objTreeNode_Manuals = TreeView_Refs.Nodes.Add(objLocalConfig.OItem_Type_Manual.GUID.ToString, objLocalConfig.OItem_Type_Manual.Name, objLocalConfig.ImageID_Manuals, objLocalConfig.ImageID_Manuals)
        objTreeNode_Utils = TreeView_Refs.Nodes.Add(objLocalConfig.OItem_RelationType_belonging_Util.GUID.ToString, objLocalConfig.OItem_RelationType_belonging_Util.Name, objLocalConfig.ImageID_Utils, objLocalConfig.ImageID_Utils)
        objTreeNode_Materials = TreeView_Refs.Nodes.Add(objLocalConfig.OItem_RelationType_belonging_Material.GUID.ToString, objLocalConfig.OItem_RelationType_belonging_Material.Name, objLocalConfig.ImageID_Materials, objLocalConfig.ImageID_Materials)


        fill_Refs()

        boolApplications = False
        boolAttributes = False
        boolBats = False
        boolBelongings = False
        boolClasses = False
        boolDocuments = False
        boolFiles = False
        boolFolders = False
        boolGroups = False
        boolMaterials = False
        boolManuals = False
        boolNeedsChildPar = False
        boolNeedsPar = False
        boolRefs = False
        boolRelationTypes = False
        boolResponsibilities = False
        boolRoles = False
        boolUsers = False
        boolUtils = False
        boolVariables = False


        objDataWork_References_Process.clear_ProcessReferences()
        objDataWork_References_Process.get_Data(objOItem_Process)
        If Not objOItem_ProcessLog Is Nothing Then
            objDataWork_References_ProcessLog.get_Data(objOItem_ProcessLog)
        End If
        Timer_References.Start()
    End Sub

    Private Sub get_ProcessRefs()
        Dim objOItem_Result As clsOntologyItem
        objOItem_Result = objDataWork_References_Process.get_Data(objOItem_Process)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If Not objOItem_ProcessLog Is Nothing Then
                objOItem_Result = objDataWork_References_ProcessLog.get_Data(objOItem_ProcessLog)

            End If
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                Err.Raise(1, "Reference-Error")
            End If
        Else

            Err.Raise(1, "Reference-Error")
        End If
    End Sub

    Private Sub Timer_References_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_References.Tick
        Dim objOItem_Result_Proc_References As clsOntologyItem
        Dim objOItem_Result_Log_References As clsOntologyItem

        objOItem_Result_Proc_References = objDataWork_References_Process.OItem_Result_ProcessRef
        objOItem_Result_Log_References = objDataWork_References_ProcessLog.OItem_Result_ProcessRef

        If objOItem_Result_Proc_References.GUID = objLocalConfig.Globals.LState_Success.GUID Then

            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_needs, objLocalConfig.OItem_Type_Application)
            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_belonging_Sem_Item, Nothing, objLocalConfig.Globals.Type_Object)
            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_belonging_Sem_Item, Nothing, objLocalConfig.Globals.Type_Class)
            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_belonging_Sem_Item, Nothing, objLocalConfig.Globals.Type_AttributeType)
            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_belonging_Sem_Item, Nothing, objLocalConfig.Globals.Type_RelationType)
            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_needed_Documentation)
            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_needs, objLocalConfig.OItem_Type_File)
            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_needs, objLocalConfig.OItem_type_Folder)
            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_needs_authority, objLocalConfig.OItem_Type_Group)
            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_needs, objLocalConfig.OItem_Type_Manual)
            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_belonging_Util, objLocalConfig.OItem_Type_Things_References)
            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_needs, objLocalConfig.OItem_Type_Media)
            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_needs_Child, Nothing, objLocalConfig.Globals.Type_Class)
            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_needs)
            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_needs_authority, objLocalConfig.OItem_Type_responsibility)
            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_needs_authority, objLocalConfig.OItem_Type_Role)
            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_needs_authority, objLocalConfig.OItem_type_User)
            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_belonging_Util, objLocalConfig.OItem_Type_Things_References)
            objDataWork_References_Process.fill_Ref(objLocalConfig.OItem_RelationType_needs, objLocalConfig.OItem_Type_Variable)

            TreeView_Refs.ExpandAll()

            Timer_References.Stop()
            ToolStripProgressBar_Refs.Value = 0
        ElseIf objOItem_Result_Proc_References.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            ToolStripProgressBar_Refs.Value = 50
        Else
            Timer_References.Stop()
            ToolStripProgressBar_Refs.Value = 0
            MsgBox("Beim Ermitteln der Referenzen ist ein Fehler aufgetreten.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub ContextMenuStrip_References_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_References.Opening
        Dim objTreeNode As TreeNode
        NewToolStripMenuItem.Enabled = False
        RemoveToolStripMenuItem.Enabled = False
        ProcessItemToolStripMenuItem.Enabled = False
        LogItemToolStripMenuItem.Enabled = False
        CopyNameToolStripMenuItem.Enabled = False
        CopyGUIDToolStripMenuItem.Enabled = False

        objTreeNode = TreeView_Refs.SelectedNode
        If objTreeNode.ImageIndex >= objLocalConfig.ImageID_Refs And objTreeNode.ImageIndex <= objLocalConfig.ImageID_Materials Then
            NewToolStripMenuItem.Enabled = True
            ProcessItemToolStripMenuItem.Enabled = True
            If Not objOItem_ProcessLog Is Nothing Then
                LogItemToolStripMenuItem.Enabled = True
            End If
        ElseIf (objTreeNode.ImageIndex >= objLocalConfig.ImageID_Ref And objTreeNode.ImageIndex <= objLocalConfig.ImageID_Material) Or (objTreeNode.ImageIndex >= objLocalConfig.ImageID_Log_Ref And objTreeNode.ImageIndex <= objLocalConfig.ImageID_Log_Material) Then
            RemoveToolStripMenuItem.Enabled = True
            CopyNameToolStripMenuItem.Enabled = True
            CopyGUIDToolStripMenuItem.Enabled = True
        End If

        
    End Sub

    Private Sub CopyNameToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyNameToolStripMenuItem.Click
        Dim objTreeNode As TreeNode

        objTreeNode = TreeView_Refs.SelectedNode
        If Not objTreeNode Is Nothing Then
            Clipboard.SetDataObject(objTreeNode.Text)
        End If
    End Sub

    Private Sub CopyGUIDToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyGUIDToolStripMenuItem.Click
        Dim objTreeNode As TreeNode

        objTreeNode = TreeView_Refs.SelectedNode
        If Not objTreeNode Is Nothing Then
            Clipboard.SetDataObject(objTreeNode.Name)
        End If
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
        Dim objTreeNode As TreeNode
        Dim objOItem_ProcessRef As clsOntologyItem
        Dim objOItem_Reference As clsOntologyItem
        Dim objOItem_RelationType As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objTreeNode = TreeView_Refs.SelectedNode

        If Not objTreeNode Is Nothing Then
            
            objOItem_Reference = New clsOntologyItem
            objOItem_Reference.GUID = objTreeNode.Name
            objOItem_Reference.Name = objTreeNode.Text

            

            objOItem_ProcessRef = get_ProcessReferenceByTreeNode()
            If Not objOItem_ProcessRef Is Nothing Then
                If objTreeNode.ImageIndex >= objLocalConfig.ImageID_Ref And objTreeNode.ImageIndex <= objLocalConfig.ImageID_Material Then
                    

                    Dim objLTypes = From obj In objDataWork_References_Process.OList_References
                                    Where obj.ID_Other = objOItem_Reference.GUID

                    If objLTypes.Count > 0 Then

                        
                        objOItem_Reference.Type = objLTypes(0).Ontology

                        objOItem_RelationType = New clsOntologyItem
                        objOItem_RelationType.GUID = objLTypes(0).ID_RelationType

                        objOItem_Result = objTransaction_References.del_003_ProcessReference_To_Reference(objOItem_Reference, _
                                                                                                          objOItem_RelationType, _
                                                                                                          objOItem_ProcessRef)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objTreeNode.Remove()
                        Else

                            MsgBox("Die Referenz konnte nicht gelöscht werden!", MsgBoxStyle.Information)
                        End If
                    Else
                        MsgBox("Die Referenz konnte nicht gelöscht werden!", MsgBoxStyle.Information)
                    End If
                ElseIf objTreeNode.ImageIndex >= objLocalConfig.ImageID_Log_Ref And objTreeNode.ImageIndex <= objLocalConfig.ImageID_Log_Material Then
                    Dim objLTypes = From obj In objDataWork_References_ProcessLog.OList_References
                                    Where obj.ID_Other = objOItem_Reference.GUID

                    If objLTypes.Count > 0 Then
                        
                        objOItem_Reference.Type = objLTypes(0).Ontology

                        objOItem_RelationType = New clsOntologyItem
                        objOItem_RelationType.GUID = objLTypes(0).ID_RelationType

                        objOItem_Result = objTransaction_References.del_003_ProcessReference_To_Reference(objOItem_Reference, _
                                                                                                          objOItem_RelationType, _
                                                                                                          objOItem_ProcessRef)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objTreeNode.Remove()
                        Else

                            MsgBox("Die Referenz konnte nicht gelöscht werden!", MsgBoxStyle.Information)
                        End If
                    Else
                        MsgBox("Die Referenz konnte nicht gelöscht werden!", MsgBoxStyle.Information)
                    End If
                End If


            End If


        End If
    End Sub
    Private Function get_ProcessReference(OItem_ProcessOrLog As clsOntologyItem) As clsOntologyItem
        Dim objOItem_ProcessRef As clsOntologyItem = Nothing
        Dim objOItem_Result As clsOntologyItem

        If OItem_ProcessOrLog.GUID_Parent = objLocalConfig.OItem_Type_Process.GUID Then
            objOItem_ProcessRef = objDataWork_References_Process.OItem_ProcessRef

        Else
            objOItem_ProcessRef = objDataWork_References_ProcessLog.OItem_ProcessRef
        End If

        If objOItem_ProcessRef Is Nothing Then
            objOItem_ProcessRef = New clsOntologyItem(objLocalConfig.Globals.NewGUID, _
                                                      objOItem_Process.Name, _
                                                      objLocalConfig.OItem_Type_Process_References.GUID, _
                                                      objLocalConfig.Globals.Type_Object)

            objOItem_Result = objTransaction_References.save_001_ProcessReference(objOItem_ProcessRef)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objOItem_Result = objTransaction_References.save_002_ProcessOrLog_To_ProcessReference(OItem_ProcessOrLog, _
                                                                                                      objOItem_ProcessRef)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then


                    objTransaction_References.del_001_ProcessReference()
                    objOItem_ProcessRef = Nothing
                End If
            End If
        Else
            objOItem_ProcessRef = objDataWork_References_Process.OItem_ProcessRef
        End If

        Return objOItem_ProcessRef
    End Function
    Private Function get_ProcessReferenceByTreeNode() As clsOntologyItem
        Dim objTreeNode As TreeNode
        Dim objOItem_ProcessRef As clsOntologyItem = Nothing
        Dim objOItem_Result As clsOntologyItem

        objTreeNode = TreeView_Refs.SelectedNode

        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex >= objLocalConfig.ImageID_Ref And objTreeNode.ImageIndex <= objLocalConfig.ImageID_Material Then
                objOItem_ProcessRef = objDataWork_References_Process.OItem_ProcessRef
                If objOItem_ProcessRef Is Nothing Then
                    objOItem_ProcessRef = New clsOntologyItem(objLocalConfig.Globals.NewGUID, _
                                                              objOItem_Process.Name, _
                                                              objLocalConfig.OItem_Type_Process_References.GUID, _
                                                              objLocalConfig.Globals.Type_Object)

                    objOItem_Result = objTransaction_References.save_001_ProcessReference(objOItem_ProcessRef)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objOItem_Result = objTransaction_References.save_002_ProcessOrLog_To_ProcessReference(objOItem_Process, _
                                                                                                              objOItem_ProcessRef)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then


                            objTransaction_References.del_001_ProcessReference()
                            objOItem_ProcessRef = Nothing
                        End If
                    End If
                Else
                    objOItem_ProcessRef = objDataWork_References_Process.OItem_ProcessRef
                End If
            ElseIf objTreeNode.ImageIndex >= objLocalConfig.ImageID_Log_Ref Then
                objOItem_ProcessRef = objDataWork_References_ProcessLog.OItem_ProcessRef
                If objOItem_ProcessRef Is Nothing Then
                    objOItem_ProcessRef = New clsOntologyItem(objLocalConfig.Globals.NewGUID, _
                                                              objOItem_Process.Name, _
                                                              objLocalConfig.OItem_Type_Process_References.GUID, _
                                                              objLocalConfig.Globals.Type_Object)

                    objOItem_Result = objTransaction_References.save_001_ProcessReference(objOItem_ProcessRef)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objOItem_Result = objTransaction_References.save_002_ProcessOrLog_To_ProcessReference(objOItem_ProcessLog, _
                                                                                                              objOItem_ProcessRef)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then

                            objTransaction_References.del_001_ProcessReference()
                            objOItem_ProcessRef = Nothing
                        End If
                    End If
                Else
                    objOItem_ProcessRef = objDataWork_References_Process.OItem_ProcessRef
                End If
            End If
        End If

        Return objOItem_ProcessRef
    End Function

    Private Sub ProcessItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcessItemToolStripMenuItem.Click
        Dim objTreeNode As TreeNode
        Dim objOItem_ProcessReference As clsOntologyItem
        Dim objOList_Objects As List(Of clsOntologyItem)
        Dim objOItem_Result As clsOntologyItem
        Dim intToDo As Integer
        Dim intDone As Integer
        Dim intImageID As Integer

        objTreeNode = TreeView_Refs.SelectedNode

        If Not objTreeNode Is Nothing Then
            objOItem_ProcessReference = get_ProcessReference(objOItem_Process)
            If Not objOItem_ProcessReference Is Nothing Then
                Select Case objTreeNode.ImageIndex
                    Case objLocalConfig.ImageID_Applications
                        intImageID = objLocalConfig.ImageID_Application
                        objOList_Objects = getObjectItemList(objLocalConfig.OItem_Type_Application)
                        If Not objOList_Objects Is Nothing Then
                            Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                            intDone = 0
                            intToDo = objOList_Objects.Count
                            For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                    intDone = intDone + 1
                                End If
                            Next

                            If intDone < intToDo Then
                                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " " & objLocalConfig.OItem_Type_Application.Name & " referenziert werden!", MsgBoxStyle.Information)
                            End If
                        End If
                        
                    Case objLocalConfig.ImageID_Attributes
                        intImageID = objLocalConfig.ImageID_Attribute
                        objOList_Objects = getItemList(objLocalConfig.Globals.Type_AttributeType)
                        If Not objOList_Objects Is Nothing Then
                            Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                            intDone = 0
                            intToDo = objOList_Objects.Count
                            For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                    intDone = intDone + 1
                                End If
                            Next

                            If intDone < intToDo Then
                                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Elemente referenziert werden!", MsgBoxStyle.Information)
                            End If
                        End If
                        
                    Case objLocalConfig.ImageID_Classes
                        intImageID = objLocalConfig.ImageID_Class
                        objOList_Objects = getItemList()
                        If Not objOList_Objects Is Nothing Then
                            Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                            intDone = 0
                            intToDo = objOList_Objects.Count
                            For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                    intDone = intDone + 1
                                End If
                            Next

                            If intDone < intToDo Then
                                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Elemente referenziert werden!", MsgBoxStyle.Information)
                            End If
                        End If
                    Case objLocalConfig.ImageID_Documents
                        intImageID = objLocalConfig.ImageID_Document
                        objOList_Objects = getItemList()
                        If Not objOList_Objects Is Nothing Then
                            Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                            intDone = 0
                            intToDo = objOList_Objects.Count
                            For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                    intDone = intDone + 1
                                End If
                            Next

                            If intDone < intToDo Then
                                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Elemente referenziert werden!", MsgBoxStyle.Information)
                            End If
                        End If
                    Case objLocalConfig.ImageID_Files
                        intImageID = objLocalConfig.ImageID_File
                        objFrm_FilesystemModule = New frm_FilesystemModule(objLocalConfig.Globals)
                        objFrm_FilesystemModule.ShowDialog(Me)
                        If objFrm_FilesystemModule.DialogResult = DialogResult.OK Then


                            If objFrm_FilesystemModule.OItem_Class_Applied.GUID = objLocalConfig.OItem_Type_File.GUID Then
                                objOList_Objects = objFrm_FilesystemModule.OList_Files
                                Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                                intDone = 0
                                intToDo = objOList_Objects.Count
                                For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                    objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)

                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                        intDone = intDone + 1
                                    End If
                                Next

                                If intDone < intToDo Then
                                    MsgBox("Es konnten nur " & intDone & " von " & intToDo & " " & objLocalConfig.OItem_Type_Application.Name & " referenziert werden!", MsgBoxStyle.Information)
                                End If
                            Else
                                MsgBox("Bitte nur Dateien auswählen!", MsgBoxStyle.Information)
                            End If
                        End If
                        
                    Case objLocalConfig.ImageID_Folders
                        intImageID = objLocalConfig.ImageID_Folder
                        objFrm_FilesystemModule = New frm_FilesystemModule(objLocalConfig.Globals)
                        objFrm_FilesystemModule.ShowDialog(Me)
                        If objFrm_FilesystemModule.DialogResult = DialogResult.OK Then


                            If objFrm_FilesystemModule.OItem_Class_Applied.GUID = objLocalConfig.OItem_type_Folder.GUID Then

                                objOList_Objects = New List(Of clsOntologyItem)
                                objOList_Objects.Add(objFrm_FilesystemModule.OItem_FileSystemObject)
                                Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                                intDone = 0
                                intToDo = objOList_Objects.Count
                                For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                    objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)

                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                        intDone = intDone + 1
                                    End If
                                Next

                                If intDone < intToDo Then
                                    MsgBox("Es konnten nur " & intDone & " von " & intToDo & " " & objLocalConfig.OItem_Type_Application.Name & " referenziert werden!", MsgBoxStyle.Information)
                                End If
                            Else
                                MsgBox("Bitte nur Dateien auswählen!", MsgBoxStyle.Information)
                            End If
                        End If
                    Case objLocalConfig.ImageID_Groups
                        intImageID = objLocalConfig.ImageID_Group
                        objOList_Objects = getObjectItemList(objLocalConfig.OItem_Type_Group)
                        If Not objOList_Objects Is Nothing Then
                            Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                            intDone = 0
                            intToDo = objOList_Objects.Count
                            For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                    intDone = intDone + 1
                                End If
                            Next

                            If intDone < intToDo Then
                                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " " & objLocalConfig.OItem_Type_Group.Name & " referenziert werden!", MsgBoxStyle.Information)
                            End If
                        End If
                    Case objLocalConfig.ImageID_Manuals
                        intImageID = objLocalConfig.ImageID_Manual
                        objOList_Objects = getObjectItemList(objLocalConfig.OItem_Type_Manual)
                        If Not objOList_Objects Is Nothing Then
                            Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                            intDone = 0
                            intToDo = objOList_Objects.Count
                            For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                    intDone = intDone + 1
                                End If
                            Next

                            If intDone < intToDo Then
                                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " " & objLocalConfig.OItem_Type_Group.Name & " referenziert werden!", MsgBoxStyle.Information)
                            End If
                        End If
                    Case objLocalConfig.ImageID_Materials
                        intImageID = objLocalConfig.ImageID_Material
                        objOList_Objects = getObjectItemList(objLocalConfig.OItem_Type_Things_References)
                        If Not objOList_Objects Is Nothing Then
                            Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                            intDone = 0
                            intToDo = objOList_Objects.Count
                            For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                    intDone = intDone + 1
                                End If
                            Next

                            If intDone < intToDo Then
                                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " " & objLocalConfig.OItem_Type_Things_References.Name & " referenziert werden!", MsgBoxStyle.Information)
                            End If
                        End If
                    Case objLocalConfig.ImageID_Medias
                        intImageID = objLocalConfig.ImageID_Media
                        objOList_Objects = getObjectItemList(objLocalConfig.OItem_Type_Media)
                        If Not objOList_Objects Is Nothing Then
                            Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                            intDone = 0
                            intToDo = objOList_Objects.Count
                            For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                    intDone = intDone + 1
                                End If
                            Next

                            If intDone < intToDo Then
                                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " " & objLocalConfig.OItem_Type_Media.Name & " referenziert werden!", MsgBoxStyle.Information)
                            End If
                        End If
                    Case objLocalConfig.ImageID_NeedsPar
                        intImageID = objLocalConfig.ImageID_Needs
                        objOList_Objects = getItemList()
                        If Not objOList_Objects Is Nothing Then
                            Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                            intDone = 0
                            intToDo = objOList_Objects.Count
                            For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                    intDone = intDone + 1
                                End If
                            Next

                            If intDone < intToDo Then
                                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Elemente referenziert werden!", MsgBoxStyle.Information)
                            End If
                        End If
                    Case objLocalConfig.ImageID_NeedsChildPar
                        intImageID = objLocalConfig.ImageID_NeedsChild
                        objOList_Objects = getItemList(objLocalConfig.Globals.Type_Class)
                        If Not objOList_Objects Is Nothing Then
                            Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                            intDone = 0
                            intToDo = objOList_Objects.Count
                            For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                    intDone = intDone + 1
                                End If
                            Next

                            If intDone < intToDo Then
                                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Elemente referenziert werden!", MsgBoxStyle.Information)
                            End If
                        End If
                    Case objLocalConfig.ImageID_Objects
                        intImageID = objLocalConfig.ImageID_Object
                        objOList_Objects = getItemList(objLocalConfig.Globals.Type_Object)
                        If Not objOList_Objects Is Nothing Then
                            Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                            intDone = 0
                            intToDo = objOList_Objects.Count
                            For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                    intDone = intDone + 1
                                End If
                            Next

                            If intDone < intToDo Then
                                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Elemente referenziert werden!", MsgBoxStyle.Information)
                            End If
                        End If
            
                    Case objLocalConfig.ImageID_RelationTypes
                        intImageID = objLocalConfig.ImageID_RelationType
                        objOList_Objects = getItemList(objLocalConfig.Globals.Type_RelationType)
                        If Not objOList_Objects Is Nothing Then
                            Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                            intDone = 0
                            intToDo = objOList_Objects.Count
                            For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                    intDone = intDone + 1
                                End If
                            Next

                            If intDone < intToDo Then
                                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Elemente referenziert werden!", MsgBoxStyle.Information)
                            End If
                        End If
                    Case objLocalConfig.ImageID_Responsibilities
                        intImageID = objLocalConfig.ImageID_Responsibility
                        objOList_Objects = getObjectItemList(objLocalConfig.OItem_Type_responsibility)
                        If Not objOList_Objects Is Nothing Then
                            Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                            intDone = 0
                            intToDo = objOList_Objects.Count
                            For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                    intDone = intDone + 1
                                End If
                            Next

                            If intDone < intToDo Then
                                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " " & objLocalConfig.OItem_Type_responsibility.Name & " referenziert werden!", MsgBoxStyle.Information)
                            End If
                        End If
                    Case objLocalConfig.ImageID_Roles
                        intImageID = objLocalConfig.ImageID_Role
                        objOList_Objects = getObjectItemList(objLocalConfig.OItem_Type_Role)
                        If Not objOList_Objects Is Nothing Then
                            Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                            intDone = 0
                            intToDo = objOList_Objects.Count
                            For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                    intDone = intDone + 1
                                End If
                            Next

                            If intDone < intToDo Then
                                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " " & objLocalConfig.OItem_Type_Role.Name & " referenziert werden!", MsgBoxStyle.Information)
                            End If
                        End If
                    Case objLocalConfig.ImageID_Users
                        intImageID = objLocalConfig.ImageID_User
                        objOList_Objects = getObjectItemList(objLocalConfig.OItem_type_User)
                        If Not objOList_Objects Is Nothing Then
                            Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                            intDone = 0
                            intToDo = objOList_Objects.Count
                            For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                    intDone = intDone + 1
                                End If
                            Next

                            If intDone < intToDo Then
                                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " " & objLocalConfig.OItem_type_User.Name & " referenziert werden!", MsgBoxStyle.Information)
                            End If
                        End If
                    Case objLocalConfig.ImageID_Utils
                        intImageID = objLocalConfig.ImageID_Util
                        objOList_Objects = getObjectItemList(objLocalConfig.OItem_Type_Things_References)
                        If Not objOList_Objects Is Nothing Then
                            Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                            intDone = 0
                            intToDo = objOList_Objects.Count
                            For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                    intDone = intDone + 1
                                End If
                            Next

                            If intDone < intToDo Then
                                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " " & objLocalConfig.OItem_Type_Things_References.Name & " referenziert werden!", MsgBoxStyle.Information)
                            End If
                        End If
                    Case objLocalConfig.ImageID_Variables
                        intImageID = objLocalConfig.ImageID_Variable
                        objOList_Objects = getObjectItemList(objLocalConfig.OItem_Type_Variable)
                        If Not objOList_Objects Is Nothing Then
                            Dim objLRef = From obj In objDataWork_References_Process.LRefTypes
                                      Where obj.ImageID = intImageID

                            intDone = 0
                            intToDo = objOList_Objects.Count
                            For Each objOItem_Object As clsOntologyItem In objOList_Objects
                                objOItem_Result = objTransaction_References.save_003_ProcessReference_To_Reference(objOItem_Object, objLRef(0).OItem_Rel_RefType, objOItem_ProcessReference)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTreeNode.Nodes.Add(objOItem_Object.GUID, _
                                                              objOItem_Object.Name, _
                                                              intImageID, _
                                                              intImageID)
                                    intDone = intDone + 1
                                End If
                            Next

                            If intDone < intToDo Then
                                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " " & objLocalConfig.OItem_Type_Variable.Name & " referenziert werden!", MsgBoxStyle.Information)
                            End If
                        End If
                End Select
            Else
                MsgBox("Die Prozessreferenz kann nicht erstellt werden!", MsgBoxStyle.Exclamation)
            End If
            
        End If
    End Sub

    Private Function getItemList(Optional Type_Selected As String = Nothing) As List(Of clsOntologyItem)
        Dim objOList_Objects As List(Of clsOntologyItem) = Nothing

        
        objFrmMain = New frmMain(objLocalConfig.Globals)



        objFrmMain.ShowDialog(Me)
        If objFrmMain.DialogResult = DialogResult.OK Then
            If Type_Selected Is Nothing Then
                If objFrmMain.OList_Simple.Count > 0 Then
                    objOList_Objects = objFrmMain.OList_Simple

                End If
            Else
                If objFrmMain.Type_Applied = Type_Selected Then
                    If objFrmMain.OList_Simple.Count > 0 Then
                        objOList_Objects = objFrmMain.OList_Simple

                    End If
                Else
                    MsgBox("Wählen Sie bitte Items des Types " & Type_Selected)
                End If
            End If
            
        End If

        Return objOList_Objects
    End Function

    Private Function getObjectItemList(OItem_Class_Objects As clsOntologyItem) As List(Of clsOntologyItem)
        Dim objOList_Objects As List(Of clsOntologyItem) = Nothing

        objFrmMain = New frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class, OItem_Class_Objects)
        objFrmMain.ShowDialog(Me)
        If objFrmMain.DialogResult = DialogResult.OK Then
            If objFrmMain.Type_Applied = objLocalConfig.Globals.Type_Object Then
                If objFrmMain.OList_Simple.Count > 0 Then
                    Dim objLNotCorrect = From obj In objFrmMain.OList_Simple
                                         Where Not obj.GUID_Parent = OItem_Class_Objects.GUID

                    If objLNotCorrect.Count = 0 Then
                        objOList_Objects = objFrmMain.OList_Simple
                    Else
                        MsgBox("Wählen Sie bitte Objekte der Klasse " & OItem_Class_Objects.Name)
                    End If
                End If
            Else
                MsgBox("Wählen Sie bitte Objekte der Klasse " & OItem_Class_Objects.Name)
            End If
        End If

        Return objOList_Objects
    End Function

    Private Sub TreeView_Refs_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TreeView_Refs.MouseDoubleClick
        Dim objTreeNode_Sel As TreeNode
        Dim objOItem_ProcessReference As clsOntologyItem = Nothing
        Dim objOList_ProcessReferences As New List(Of clsOntologyItem)

        objTreeNode_Sel = TreeView_Refs.SelectedNode

        If Not objTreeNode_Sel Is Nothing Then
            If objTreeNode_Sel.ImageIndex >= objLocalConfig.ImageID_Refs And objTreeNode_Sel.ImageIndex <= objLocalConfig.ImageID_Materials Then
                If My.Computer.Keyboard.CtrlKeyDown = False Then
                    objOItem_ProcessReference = get_ProcessReference(objOItem_Process)
                Else
                    If Not objOItem_ProcessLog Is Nothing Then
                        objOItem_ProcessReference = get_ProcessReference(objOItem_ProcessLog)
                    Else
                        MsgBox("Es existiert noch keine Prozess-Referenz!", MsgBoxStyle.Information)
                    End If

                End If
                If Not objOItem_ProcessReference Is Nothing Then
                    objOList_ProcessReferences.Add(objOItem_ProcessReference)
                    objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, objOList_ProcessReferences, 0, objLocalConfig.Globals.Type_Object, Nothing)
                    objFrm_ObjectEdit.ShowDialog(Me)
                Else
                    MsgBox("Es konnte nicht ermittelt werden, ob Prozessreferenzen existieren!", MsgBoxStyle.Information)
                End If


            Else

            End If
        End If
    End Sub
End Class
