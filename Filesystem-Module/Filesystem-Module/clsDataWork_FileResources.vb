Imports OntologyClasses.BaseClasses
Imports Ontology_Module

Public Class clsDataWork_FileResources
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_ResourceType As clsDBLevel

    Public ReadOnly Property OItem_Class_Path As clsOntologyItem
        Get
            Return objLocalConfig.OItem_Type_Path
        End Get
    End Property

    Public ReadOnly Property OItem_Class_File As clsOntologyItem
        Get
            Return objLocalConfig.OItem_Type_File
        End Get
    End Property

    Public ReadOnly Property OItem_Class_WebConnection As clsOntologyItem
        Get
            Return objLocalConfig.OItem_Type_Web_Connection
        End Get
    End Property
    

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
            Dim objOList_Path = objDBLevel_ResourceType.OList_ObjectRel.Where(Function(p) p.ID_Parent_Other = objLocalConfig.OItem_Type_Path.GUID _
                                                                        And p.ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Resource.GUID).Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Other, _
                                                                                                                                                                                                        .Name = p.Name_Other, _
                                                                                                                                                                                                        .GUID_Parent = p.ID_Parent_Other, _
                                                                                                                                                                                                        .Type = objLocalConfig.Globals.Type_Object}).ToList()

            Dim objOList_File = objDBLevel_ResourceType.OList_ObjectRel.Where(Function(p) p.ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID _
                                                                        And p.ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Resource.GUID).Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Other, _
                                                                                                                                                                                                        .Name = p.Name_Other, _
                                                                                                                                                                                                        .GUID_Parent = p.ID_Parent_Other, _
                                                                                                                                                                                                        .Type = objLocalConfig.Globals.Type_Object}).ToList()

            Dim objOList_WebConnection = objDBLevel_ResourceType.OList_ObjectRel.Where(Function(p) p.ID_Parent_Other = objLocalConfig.OItem_Type_Web_Connection.GUID _
                                                                        And p.ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Resource.GUID).Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Other, _
                                                                                                                                                                                                        .Name = p.Name_Other, _
                                                                                                                                                                                                        .GUID_Parent = p.ID_Parent_Other, _
                                                                                                                                                                                                        .Type = objLocalConfig.Globals.Type_Object}).ToList()

            If (objOList_Path.Any()) Then
                objOItem_Result = objLocalConfig.OItem_Type_Path
            ElseIf (objOList_File.Any()) Then
                objOItem_Result = objLocalConfig.OItem_Type_File
            ElseIf (objOList_WebConnection.Any()) Then
                objOItem_Result = objLocalConfig.OItem_Type_Web_Connection
            Else 
                objOItem_Result = Nothing
            End If
        End If

        Return objOItem_Result
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Public Sub New(Globals As clsGlobals)
        objLocalConfig = new clsLocalConfig(Globals)

        Initialize()
    End Sub

    Private sub Initialize()
        objDBLevel_ResourceType = new clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
