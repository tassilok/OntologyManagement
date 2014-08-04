Imports OntologyClasses.BaseClasses
Imports Ontology_Module

Public Class clsDataWork_Menu
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Item As clsDBLevel

    Public Sub New (LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Public Function GetOItem(GUID_Item As String, ItemType As String) As clsOntologyItem
        return objDBLevel_Item.GetOItem(GUID_Item, ItemType)
    End Function

    Private sub Initialize()
        objDBLevel_Item = new clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
