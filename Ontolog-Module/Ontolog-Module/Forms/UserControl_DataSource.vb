Public Class UserControl_DataSource

    Public Sub New(Globals As clsGlobals)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Label_DataSource.Text = Globals.Index & "@" & Globals.Server
    End Sub
End Class
