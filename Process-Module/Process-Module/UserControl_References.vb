Imports Ontolog_Module
Imports Filesystem_Module
Public Class UserControl_References
    Private objLocalConfig As clsLocalConfig

    Private objOItem_Process As clsOntologyItem
    Private objOItem_ProcessLog As clsOntologyItem

    Private objFrm_FilesystemModule As frm_FilesystemModule
    Private objFrm_ObjectEdit As frm_ObjectEdit
    Private objFileWork As clsFileWork
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

    Private Sub set_DBConnection()
        objDataWork_References_Process = New clsDataWork_References(objLocalConfig)
        objDataWork_References_ProcessLog = New clsDataWork_References(objLocalConfig)
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
            If boolApplications = False Then
                objDataWork_References_Process.fill_Ref(objTreeNode_Applications, objLocalConfig.OItem_RelationType_needs, objLocalConfig.OItem_Type_Application)
                boolApplications = True
            End If

            If boolBats = False Then
                objDataWork_References_Process.fill_Ref(objTreeNode_Bats, objLocalConfig.OItem_RelationType_belonging_Sem_Item, Nothing, objLocalConfig.Globals.Type_Object)
                boolBats = True
            End If

            If boolClasses = False Then
                objDataWork_References_Process.fill_Ref(objTreeNode_Classes, objLocalConfig.OItem_RelationType_belonging_Sem_Item, Nothing, objLocalConfig.Globals.Type_Class)
                boolClasses = True
            End If

            If boolDocuments = False Then

                boolDocuments = True
            End If

            If boolFiles = False Then
                objDataWork_References_Process.fill_Ref(objTreeNode_Files, objLocalConfig.OItem_RelationType_needs, objLocalConfig.OItem_Type_File)
                boolFiles = True
            End If

            If boolFolders = False Then
                objDataWork_References_Process.fill_Ref(objTreeNode_Folders, objLocalConfig.OItem_RelationType_needs, objLocalConfig.OItem_type_Folder)
                boolFolders = True
            End If

            If boolGroups = False Then
                objDataWork_References_Process.fill_Ref(objTreeNode_Groups, objLocalConfig.OItem_RelationType_needs_authority, objLocalConfig.OItem_Type_Group)
                boolGroups = True
            End If

            If boolManuals = False Then
                objDataWork_References_Process.fill_Ref(objTreeNode_Manuals, objLocalConfig.OItem_RelationType_needs, objLocalConfig.OItem_Type_Manual)
                boolManuals = True
            End If

            If boolMaterials = False Then

                boolMaterials = True
            End If

            If boolMedias = False Then
                objDataWork_References_Process.fill_Ref(objTreeNode_Medias, objLocalConfig.OItem_RelationType_needs, objLocalConfig.OItem_Type_Media)
                boolMedias = True
            End If

            ToolStripProgressBar_Refs.Value = 50
        ElseIf objOItem_Result_Proc_References.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then

        Else

        End If
    End Sub
End Class
