Imports OntologyClasses.BaseClasses
Imports Ontology_Module
Imports Structure_Module
Public Class clsDataWork_OntologyConfig
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_Ontology As clsDBLevel
    Private objDataWork_Ontology As clsDataWork_Ontologies

    Private objOItem_Result_OntologyOfDevelopment As clsOntologyItem

    Private objOItem_Development As clsOntologyItem

    public Property OItem_Ontology() As clsOntologyItem

    Public ReadOnly Property DataWork_Ontology As clsDataWork_Ontologies
        Get
            Return objDataWork_Ontology
        End Get
    End Property

    Public Function GetData(OItem_Development As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()
        objOItem_Development = OItem_Development

        GetData_OntologyOfDevelopment()
        If objOItem_Result_OntologyOfDevelopment.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objDataWork_Ontology.GetData_OntologyRefs()    
            If objDataWork_Ontology.OItem_Result_OntologyRels.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objDataWork_Ontology.GetData_003_OntologyItemsOfOntologies()
                If objDataWork_Ontology.OItem_Result_OntologyItemsOfOntologies.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objDataWork_Ontology.GetData_OntologyRelationRulesOfOItems()
                    If objDataWork_Ontology.OItem_OntologyRelationRulesOfOItems.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objDataWork_Ontology.GetData_RefsOfOntologyItems()
                        If objDataWork_Ontology.OItem_Result_RefsOfOntologyItems.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    
                        
                            Dim objOntologies = objDataWork_Ontology.OList_RefsOfOntologies.Where(Function(p) p.ID_Other = OItem_Development.GUID).ToList()
                            If objOntologies.Any() Then
                                OItem_Ontology = New clsOntologyItem With {.GUID = objOntologies.First().ID_Object, _
                                                                           .Name = objOntologies.First().Name_Object, _
                                                                           .GUID_Parent = objOntologies.First().ID_Parent_Object,
                                                                           .Type = objLocalConfig.Globals.Type_Object}
                            Else 
                                objOItem_Result = objLocalConfig.Globals.LState_Nothing().Clone()
                            End If
                        
                        
                        
                        
                        
                        Else 
                            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
                        End If
                    Else 
                        objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
                    End If
                
                Else 
                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
                End If
            Else 
                objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
            End If
        End If
        
        

        Return objOItem_Result
    End Function

    Private Sub GetData_OntologyOfDevelopment()
        objOItem_Result_OntologyOfDevelopment = objLocalConfig.Globals.LState_Nothing
        OItem_Ontology = Nothing
        Dim objOLRel_Ontology_To_Development = new List(Of clsObjectRel) from {New clsObjectRel With {.ID_Other = objOItem_Development.GUID, _
                                                                                                     .ID_Parent_Other = objLocalConfig.Globals.Class_Ontologies.GUID, _
                                                                                                     .ID_RelationType = objLocalConfig.OItem_RelationType_belongingResource.GUID} }
        Dim objOItem_Result = objDBLevel_Ontology.get_Data_ObjectRel(objOLRel_Ontology_To_Development, _
                                                                     boolIDs := false)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Ontology.OList_ObjectRel.Any() Then
                OItem_Ontology = new clsOntologyItem With {.GUID = objDBLevel_Ontology.OList_ObjectRel.First().ID_Object, _
                                                           .Name = objDBLevel_Ontology.OList_ObjectRel.First().Name_Object, _
                                                           .GUID_Parent = objDBLevel_Ontology.OList_ObjectRel.First().ID_Parent_Object, _
                                                           .Type = objLocalConfig.Globals.Type_Object }


            End If       
        End If

        objOItem_Result_OntologyOfDevelopment = objOItem_Result
    End Sub



    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        initialize()
    End Sub

    Private sub initialize()
        objDBLevel_Ontology = new clsDBLevel(objLocalConfig.Globals)
        objDataWork_Ontology = new clsDataWork_Ontologies(objLocalConfig.Globals)

        objOItem_Result_OntologyOfDevelopment = objLocalConfig.Globals.LState_Nothing.Clone()
    End Sub
End Class
