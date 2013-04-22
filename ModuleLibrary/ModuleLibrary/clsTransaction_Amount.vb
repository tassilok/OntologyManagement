Imports Ontolog_Module
Public Class clsTransaction_Amount
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_Amount As clsDBLevel

    Public Sub save_001_Menge(ByVal dblMenge As Double, ByVal OItem_Unit As clsOntologyItem)

    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Amount = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
