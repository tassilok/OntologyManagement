Imports Ontolog_Module
Public Class clsDataWork_Security
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_MasterPassword As clsDBLevel



    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_MasterPassword = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
