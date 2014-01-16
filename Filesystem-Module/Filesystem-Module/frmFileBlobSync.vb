Imports Ontology_Module
Public Class frmFileBlobSync

    Private objUserControl_FileBlobSync As UserControl_FileBlobSync

    Private objLocalConfig As clsLocalConfig

    Private Sub ToolStripButton_Close_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Public Sub New(Globals As clsGlobals)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)

        Initialize()
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objUserControl_FileBlobSync = New UserControl_FileBlobSync(objLocalConfig)
        objUserControl_FileBlobSync.Dock = DockStyle.Fill
        ToolStripContainer1.ContentPanel.Controls.Add(objUserControl_FileBlobSync)
    End Sub
End Class