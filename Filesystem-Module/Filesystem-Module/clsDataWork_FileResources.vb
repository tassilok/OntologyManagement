Imports OntologyClasses.BaseClasses
Imports Ontology_Module

Public Class clsDataWork_FileResources
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_ResourceType As clsDBLevel

    Public Function GetResourceType(OItem_Resource As clsOntologyItem) As clsOntologyItem
        Dim objOList_ResourceType = new List(Of clsObjectRel) From { New clsObjectRel With {.ID_Object = OItem_Resource.GUID,
                                                                                            .ID_Parent_Other = objLocalConfig.OItem_Type_Path.GUID,
                                                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Resource.GUID},
                                                                    New clsObjectRel With {.ID_Object = OItem_Resource.GUID,
                                                                                           .ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID,
                                                                                           .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Resource.GUID},
                                                                    New clsObjectRel With {.ID_Object = OItem_Resource.GUID,
                                                                                           .ID_Parent_Other = objLocalConfig.OItem_Type_Web_Connection.GUID,
                                                                                           .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Resource.GUID}}
        Dim objOItem_Result = objDBLevel_ResourceType.get_Data_ObjectRel(objOList_ResourceType, boolIDs := False)

        If (objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID) then
            
        End If

        Return objOItem_Result
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private sub Initialize()
        objDBLevel_ResourceType = new clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
