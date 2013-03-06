Imports Ontolog_Module
Public Class clsBlobConnection
    Private objLocalConfig As clsLocalConfig

    Public Sub New()
        objLocalConfig = New clsLocalConfig(New clsGlobals)
    End Sub

    Public Sub New(ByVal Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
    End Sub
End Class
