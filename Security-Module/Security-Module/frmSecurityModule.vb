Imports Ontolog_Module
Public Class frmSecurityModule
    Private objLocalConfig As clsLocalConfig

    Private objFrmAuthenticate As frmAuthenticate
    Private objSecurityWork As clsSecurityWork
    Private boolOpen As Boolean

    Private objOItem_MasterUser As clsOntologyItem

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
        objFrmAuthenticate = New frmAuthenticate(objLocalConfig, True, False, frmAuthenticate.ERelateMode.NoRelate)
        objFrmAuthenticate.ShowDialog(Me)
        If objFrmAuthenticate.DialogResult = Windows.Forms.DialogResult.OK Then
            objOItem_MasterUser = objFrmAuthenticate.OItem_User
            objOItem_Result = objSecurityWork.initialize_User(objOItem_MasterUser)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                boolOpen = True
            ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Geben Sie das Passwort bitte nochmals ein! (noch 2 Versuche)", MsgBoxStyle.Information)
                objOItem_Result = objSecurityWork.initialize_User(objOItem_MasterUser)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    boolOpen = True
                ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    MsgBox("Geben Sie das Passwort bitte nochmals ein! (noch 1 Versuch)", MsgBoxStyle.Information)
                    objOItem_Result = objSecurityWork.initialize_User(objOItem_MasterUser)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        boolOpen = True
                    Else
                        MsgBox("Sie haben das Passwort dreimal falsch eingegeben! Die Anwendung wird geschlossen. (noch 1 Versuche)", MsgBoxStyle.Information)
                    End If

                End If

            End If

        End If
    End Sub

    Private Sub frmSecurityModule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        If boolOpen = False Then
            Me.Close()
        End If
    End Sub
End Class
