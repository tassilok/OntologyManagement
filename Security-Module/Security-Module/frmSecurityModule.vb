Imports Ontolog_Module
Imports OntologyClasses.BaseClasses

Public Class frmSecurityModule
    Private objLocalConfig As clsLocalConfig

    Private objFrmAuthenticate As frmAuthenticate
    Private WithEvents objUserControl_PasswordTree As UserControl_PasswordTree
    Private objUserControl_Password As UserControl_Password

    Private objSecurityWork As clsSecurityWork
    Private boolOpen As Boolean

    Private Sub selected_Node(ByVal TreeNode_Selected As TreeNode) Handles objUserControl_PasswordTree.selected_Node
        objUserControl_Password.fill_Password(TreeNode_Selected)
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals)
        set_DBConnection()
        initialize()
    End Sub

    Private Sub set_DBConnection()
        objSecurityWork = New clsSecurityWork(objLocalConfig, Me)
    End Sub

    Private Sub initialize()
        Dim objOItem_Result As clsOntologyItem
        boolOpen = False
        objUserControl_PasswordTree = New UserControl_PasswordTree(objLocalConfig)
        objUserControl_PasswordTree.Dock = DockStyle.Fill
        SplitContainer1.Panel1.Controls.Add(objUserControl_PasswordTree)

        objUserControl_Password = New UserControl_Password(objLocalConfig, objSecurityWork)
        objUserControl_Password.Dock = DockStyle.Fill
        SplitContainer1.Panel2.Controls.Add(objUserControl_Password)

        objFrmAuthenticate = New frmAuthenticate(objLocalConfig, True, False, frmAuthenticate.ERelateMode.NoRelate)
        objFrmAuthenticate.ShowDialog(Me)
        If objFrmAuthenticate.DialogResult = Windows.Forms.DialogResult.OK Then
            objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User
            objOItem_Result = objSecurityWork.initialize_User(objLocalConfig.OItem_User)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                boolOpen = True
            ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Geben Sie das Passwort bitte nochmals ein! (noch 2 Versuche)", MsgBoxStyle.Information)
                objOItem_Result = objSecurityWork.initialize_User(objLocalConfig.OItem_User)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    boolOpen = True
                ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    MsgBox("Geben Sie das Passwort bitte nochmals ein! (noch 1 Versuch)", MsgBoxStyle.Information)
                    objOItem_Result = objSecurityWork.initialize_User(objLocalConfig.OItem_User)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        boolOpen = True
                    Else
                        MsgBox("Sie haben das Passwort dreimal falsch eingegeben! Die Anwendung wird geschlossen. (noch 1 Versuche)", MsgBoxStyle.Information)
                    End If

                End If

            End If

        End If
    End Sub

    Private Sub refresh_PasswordTree()
        objUserControl_PasswordTree.initialize()


    End Sub

    Private Sub frmSecurityModule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If boolOpen = False Then
            Me.Close()
        Else
            refresh_PasswordTree()

        End If
    End Sub

    Private Sub ToolStripButton_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub
End Class
