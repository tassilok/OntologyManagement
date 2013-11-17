Public Class frmArchive
    Private objLocalConfig As clsLocalConfig

    Private objUserControl_Transactions As UserControl_Archive
    Private objUserControl_Archive As UserControl_Archive

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objUserControl_Transactions = New UserControl_Archive(objLocalConfig, False)
        objUserControl_Transactions.Dock = DockStyle.Fill

        SplitContainer1.Panel1.Controls.Add(objUserControl_Transactions)

        objUserControl_Archive = New UserControl_Archive(objLocalConfig, True)
        objUserControl_Archive.Dock = DockStyle.Fill

        SplitContainer1.Panel2.Controls.Add(objUserControl_Archive)
    End Sub

    Private Sub ToolStripButton_Close_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub
End Class