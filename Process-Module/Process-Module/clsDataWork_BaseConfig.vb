Imports Ontolog_Module
Public Class clsDataWork_BaseConfig
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_BaseConfig As clsDBLevel

    Public Sub get_SupportedLanguages()

    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_BaseConfig = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
