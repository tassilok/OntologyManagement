Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class clsDataWork_Menu
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_OItems As clsDBLevel

    Public Function GetOItem(GUID_Item As String, ItemType As String) As clsOntologyItem

        Return objDBLevel_OItems.GetOItem(GUID_Item, ItemType)

    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objDBLevel_OItems = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
