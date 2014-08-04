Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Security_Module
Public Class frmProcessModule
    Private objLocalConfig As clsLocalConfig

    Private WithEvents objUserControl_Process As UserControl_Process

    Private objFrmAuthenticate As frmAuthenticate

    Private objFrmMenu As frmMenu

    Private SplashScreen As SplashScreen_OntologyModule
    Private AboutBox As AboutBox_OntologyItem

    Private boolApplyable As Boolean
    Private objOLProcesses As List(Of clsOntologyItem)

    Private objArgumentParsing As clsArgumentParsing

    Public ReadOnly Property OListProcesses As List(Of clsOntologyItem)
        Get
            Return objOLProcesses
        End Get
    End Property

    Private Sub appliedProcesses(OListProcesses As List(Of clsOntologyItem)) Handles objUserControl_Process.appliedProcess
        objOLProcesses = OListProcesses
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Public Property applyable As Boolean
        Get
            Return boolApplyable
        End Get
        Set(value As Boolean)
            boolApplyable = value
            objUserControl_Process.applyable = value
        End Set
    End Property

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        Application.DoEvents()
        SplashScreen = New SplashScreen_OntologyModule()
        SplashScreen.Show()
        SplashScreen.Refresh()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals())
        initialize()
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        initialize()
    End Sub

    Public Sub New(Globals As clsGlobals, OItem_User As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        objLocalConfig.OItem_User = OItem_User
        initialize()
    End Sub

    Private Sub initialize()
        If objLocalConfig.OItem_User Is Nothing Then
            objFrmAuthenticate = New frmAuthenticate(objLocalConfig.Globals, True, False, frmAuthenticate.ERelateMode.NoRelate, True)
            objFrmAuthenticate.ShowDialog(Me)
            If objFrmAuthenticate.DialogResult = Windows.Forms.DialogResult.OK Then
                objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User

            End If
        End If

        If Not objLocalConfig.OItem_User Is Nothing Then
            
            ParseArguments()
            objUserControl_Process = New UserControl_Process(objLocalConfig)
            objUserControl_Process.Dock = DockStyle.Fill

            TabPage_Process.Controls.Add(objUserControl_Process)
        Else
            Environment.Exit(0)
        End If
        
    End Sub

    Private sub ParseArguments()
        objArgumentParsing = new clsArgumentParsing(objLocalConfig.Globals,Environment.GetCommandLineArgs().ToList())
        If objArgumentParsing.OList_Items.Count = 1 Then
            objFrmMenu = new frmMenu(objLocalConfig, objArgumentParsing.OList_Items.First())
            objFrmMenu.ShowDialog(Me)
            Environment.Exit(0)
        End If
    End Sub

    Private Sub frmProcessModule_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not SplashScreen Is Nothing Then
            SplashScreen.Close()
        End If
    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        AboutBox = New AboutBox_OntologyItem()
        AboutBox.ShowDialog(Me)
    End Sub
End Class
