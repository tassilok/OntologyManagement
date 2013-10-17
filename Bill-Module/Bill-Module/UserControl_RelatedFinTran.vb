Imports Ontology_Module
Public Class UserControl_RelatedFinTran

    Private objLocalConfig As clsLocalConfig

    Public Sub clear_Controls()

    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
    End Sub
End Class
