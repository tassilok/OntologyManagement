Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class frmProcessModule
    Private objLocalConfig As clsLocalConfig

    Private WithEvents objUserControl_Process As UserControl_Process

    Private SplashScreen As SplashScreen_OntologyModule
    Private AboutBox As AboutBox_OntologyItem

    Private boolApplyable As Boolean
    Private objOLProcesses As List(Of clsOntologyItem)

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

    Public Sub New(Globals As clsGlobals)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        initialize()
    End Sub

    Private Sub initialize()
        objUserControl_Process = New UserControl_Process(objLocalConfig)
        objUserControl_Process.Dock = DockStyle.Fill

        TabPage_Process.Controls.Add(objUserControl_Process)
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
