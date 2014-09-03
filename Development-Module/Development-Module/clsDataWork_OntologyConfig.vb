Imports OntologyClasses.BaseClasses
Imports Ontology_Module
Imports Structure_Module
Public Class clsDataWork_OntologyConfig
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_Ontology As clsDBLevel
    Private objDataWork_Ontology As clsDataWork_Ontologies

    Public Property OItem_Result_OntologyOfDevelopment As clsOntologyItem

    Public Property OItem_Development As clsOntologyItem

    Public Property OItem_Ontology_Main As clsOntologyItem
    Public Property OList_Ontologies() As List(Of clsOntologyItem)



    Public ReadOnly Property DataWork_Ontology As clsDataWork_Ontologies
        Get
            Return objDataWork_Ontology
        End Get
    End Property

    Public Function GetData(OItem_Development As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()
        Me.OItem_Development = OItem_Development

        GetData_OntologyOfDevelopment()
        If OItem_Result_OntologyOfDevelopment.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objDataWork_Ontology.GetData_OntologyRefs()
            If objDataWork_Ontology.OItem_Result_OntologyRels.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objDataWork_Ontology.GetData_003_OntologyItemsOfOntologies()
                If objDataWork_Ontology.OItem_Result_OntologyItemsOfOntologies.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objDataWork_Ontology.GetData_OntologyRelationRulesOfOItems()
                    If objDataWork_Ontology.OItem_OntologyRelationRulesOfOItems.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objDataWork_Ontology.GetData_RefsOfOntologyItems()
                        If objDataWork_Ontology.OItem_Result_RefsOfOntologyItems.GUID = objLocalConfig.Globals.LState_Success.GUID Then


                            Dim objOntologies = objDataWork_Ontology.OList_RefsOfOntologies.OrderBy(Function(o) o.OrderID).Where(Function(p) p.ID_Other = OItem_Development.GUID).Select(Function(o) New clsOntologyItem With {.GUID = o.ID_Object, _
                                                                           .Name = o.Name_Object, _
                                                                           .GUID_Parent = o.ID_Parent_Object,
                                                                           .Type = objLocalConfig.Globals.Type_Object
                                                                                                                                                              }).ToList()


                            If objOntologies.Any() Then
                                OItem_Ontology_Main = objOntologies.First()
                                OList_Ontologies = objOntologies
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

    Public Sub GetData_OntologyOfDevelopment()
        OItem_Result_OntologyOfDevelopment = objLocalConfig.Globals.LState_Nothing
        OList_Ontologies = Nothing
        Dim objOLRel_Ontology_To_Development = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Other = OItem_Development.GUID, _
                                                                                                     .ID_Parent_Object = objLocalConfig.Globals.Class_Ontologies.GUID, _
                                                                                                     .ID_RelationType = objLocalConfig.OItem_RelationType_belongingResource.GUID}}
        Dim objOItem_Result = objDBLevel_Ontology.get_Data_ObjectRel(objOLRel_Ontology_To_Development, _
                                                                     boolIDs:=False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Ontology.OList_ObjectRel.Any() Then
                OList_Ontologies = objDBLevel_Ontology.OList_ObjectRel.Select(Function(ontology) New clsOntologyItem With {.GUID = ontology.ID_Object, _
                                                           .Name = ontology.Name_Object, _
                                                           .GUID_Parent = ontology.ID_Parent_Object, _
                                                           .Type = objLocalConfig.Globals.Type_Object}).ToList()


            End If
        End If

        OItem_Result_OntologyOfDevelopment = objOItem_Result
    End Sub



    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        initialize()
    End Sub

    Private Sub initialize()
        objDBLevel_Ontology = New clsDBLevel(objLocalConfig.Globals)
        objDataWork_Ontology = New clsDataWork_Ontologies(objLocalConfig.Globals)

        OItem_Result_OntologyOfDevelopment = objLocalConfig.Globals.LState_Nothing.Clone()
    End Sub
End Class
