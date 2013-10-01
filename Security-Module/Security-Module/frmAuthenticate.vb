Imports Ontolog_Module
Imports OntologyClasses.BaseClasses

Public Class frmAuthenticate

    <FlagsAttribute()> _
    Public Enum ERelateMode As Integer
        NoRelate = 1
        User_To_Group = 2
        Group_To_User = 3
    End Enum

    Private boolUser As Boolean
    Private boolGroup As Boolean
    Private intAuthenticationMode As Integer

    Private objLocalConfig As clsLocalConfig

    Private objOItem_User As clsOntologyItem
    Private objOItem_Group As clsOntologyItem

    Private WithEvents objUserControl_Authenticate As UserControl_Authenticate

    Public ReadOnly Property OItem_User As clsOntologyItem
        Get
            Return objOItem_User
        End Get
    End Property

    Public ReadOnly Property OItem_Group As clsOntologyItem
        Get
            Return objOItem_Group
        End Get
    End Property

    Public Sub applied_SecItem(ByVal OItem_User As clsOntologyItem, ByVal OItem_Group As clsOntologyItem) Handles objUserControl_Authenticate.applied
        Dim intDialogResult As Integer
        objOItem_User = OItem_User
        objOItem_Group = OItem_Group

        intDialogResult = Windows.Forms.DialogResult.None

        Select Case intAuthenticationMode
            Case ERelateMode.Group_To_User, ERelateMode.User_To_Group
                If Not objOItem_Group Is Nothing _
                    And Not objOItem_User Is Nothing Then
                    intDialogResult = Windows.Forms.DialogResult.OK
                End If
            Case ERelateMode.NoRelate
                If boolUser = True Then
                    If Not objOItem_User Is Nothing Then
                        intDialogResult = Windows.Forms.DialogResult.OK
                    End If
                Else
                    If Not objOItem_Group Is Nothing Then
                        intDialogResult = Windows.Forms.DialogResult.OK
                    End If
                End If


        End Select

        If intDialogResult = Windows.Forms.DialogResult.OK Then
            Me.DialogResult = intDialogResult
            Me.Close()
        Else
            MsgBox("Sie haben nicht die richtige Auswahl getroffen!", MsgBoxStyle.Information)
        End If
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig, ByVal boolUser As Boolean, ByVal boolGroup As Boolean, ByVal AuthenticationMode As ERelateMode)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        intAuthenticationMode = AuthenticationMode
        Me.boolGroup = boolGroup
        Me.boolUser = boolUser
        set_DBConnection()
        initialize()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals, ByVal boolUser As Boolean, ByVal boolGroup As Boolean, ByVal AuthenticationMode As ERelateMode)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        intAuthenticationMode = AuthenticationMode
        Me.boolGroup = boolGroup
        Me.boolUser = boolUser
        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()


        objUserControl_Authenticate = New UserControl_Authenticate(objLocalConfig)
        objUserControl_Authenticate.Dock = DockStyle.Fill
        Panel_Authenticate.Controls.Add(objUserControl_Authenticate)
        objUserControl_Authenticate.initialize_Authentication(boolUser, boolGroup, intAuthenticationMode)
    End Sub

    Private Sub set_DBConnection()

    End Sub
End Class