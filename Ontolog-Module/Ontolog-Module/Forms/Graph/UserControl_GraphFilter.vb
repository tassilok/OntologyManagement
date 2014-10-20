Public Class UserControl_GraphFilter

    Private objLocalConfig As clsLocalConfig

    Private objFrm_Main As frmMain

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
    End Sub
End Class
