Imports Ontolog_Module
Public Class clsTransaction_References

    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_References As clsDBLevel

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_References = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
