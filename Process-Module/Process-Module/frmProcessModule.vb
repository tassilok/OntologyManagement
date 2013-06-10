Imports Ontolog_Module
Public Class frmProcessModule
    Private objLocalConfig As clsLocalConfig

    Private WithEvents objUserControl_Process As UserControl_Process

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals())
        initialize()
    End Sub

    Private Sub initialize()
        objUserControl_Process = New UserControl_Process(objLocalConfig)
        objUserControl_Process.Dock = DockStyle.Fill

        TabPage_Process.Controls.Add(objUserControl_Process)
    End Sub
End Class
