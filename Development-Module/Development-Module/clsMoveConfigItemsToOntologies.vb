Imports Ontolog_Module
Imports OntologyClasses.BaseClasses
Public Class clsMoveConfigItemsToOntologies
    
    Private objDataWork_OntologyConfig As clsDataWork_OntologyConfig
    Private objDataWork_Ontologies As clsDataWork_Ontologies
    Private objLocalConfig As clsLocalConfig
    Private objTransaction As clsTransaction    

    Public Function CopyOntologyItems(OItem_Development As clsOntologyItem) As clsOntologyItem
        objDataWork_OntologyConfig.get_ConfigItems(OItem_Development)
        Dim dtblT_OntologyItems = objDataWork_OntologyConfig.dtbl_OntologyItems
        Dim objOItem_Ontology As clsOntologyItem = Nothing
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()

        objDataWork_Ontologies.GetData_003_OntologyItemsOfOntologies()
        If objDataWork_Ontologies.OItem_Result_OntologyItemsOfOntologies.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objDataWork_Ontologies.GetData_RefsOfOntologyItems()
            If objDataWork_Ontologies.OItem_Result_RefsOfOntologyItems.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objDataWork_Ontologies.GetData_OntologyRefs()
                If objDataWork_Ontologies.OItem_Result_OntologyRels.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    
                    Dim objOntologies = objDataWork_Ontologies.OList_RefsOfOntologies.Where(Function(p) p.ID_Other = OItem_Development.GUID).ToList()

                    objTransaction.ClearItems()
                    

                    If objOntologies.Any() Then
                        objOItem_Ontology = New clsOntologyItem With {.GUID = objOntologies.First().ID_Object, _
                                                                      .Name = objOntologies.First().Name_Object, _
                                                                      .GUID_Parent = objLocalConfig.Globals.Class_Ontologies.GUID, _
                                                                      .Type = objLocalConfig.Globals.Type_Object}

                    Else
                        objOItem_Ontology = new clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                                      .Name = OItem_Development.Name, _
                                                                      .GUID_Parent = objLocalConfig.Globals.Class_Ontologies.GUID, _
                                                                      .Type = objLocalConfig.Globals.Type_Object, _
                                                                      .New_Item = True}

                        objOItem_Result = objTransaction.do_Transaction(objOItem_Ontology)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Dim objORel_Ontology_To_Ref = objDataWork_Ontologies.Rel_Ontology_To_Ref(OItem_Development, objOItem_Ontology)
                            objOItem_Result = objTransaction.do_Transaction(objORel_Ontology_To_Ref)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                objTransaction.rollback()
                            End If
                        End If
                    End If
                    
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        Dim objOntologyItems = (from objOntology In objOntologies 
                                            Join objOntologyItem In objDataWork_Ontologies.OList_RefsOfOntologyItems on objOntology.ID_Object equals objOntologyItem.ID_Ontology
                                            Where objOntology.ID_Other = OItem_Development.GUID).ToList()
                    
                        For Each row As DataRow  In dtblT_OntologyItems.Rows

                            Dim objOItem_ConfigItem = new clsOntologyItem With {.GUID = row.Item("ID_ConfigItem").ToString(), _
                                                                                .Name = row.Item("Name_ConfigItem").ToString(), _
                                                                                .GUID_Parent = objLocalConfig.OItem_Class_DevelopmentConfigItem.GUID, _
                                                                                .Type = objLocalConfig.Globals.Type_Object}
            
                            Dim objOItem_OntologyItem = new clsOntologyItem With{.GUID = row.Item("ID_OntologyItem").ToString(), _
                                                                                    .Name = row.Item("Name_OntologyItem").ToString(), _
                                                                                    .Type = row.Item("Ontology").ToString()}
                    
                            If Not objOntologyItems.Where(Function(p) p.objOntologyItem.ID_Ref = objOItem_OntologyItem.GUID).Any() Then
                                objOItem_OntologyItem = objDataWork_OntologyConfig.GetOntologyItemByGUIDAndType(objOItem_OntologyItem.GUID, objOItem_OntologyItem.Type)
                                Dim objOItem_OntologyItemForOntology = new clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                                                                 .Name = objOItem_ConfigItem.Name, _
                                                                                                 .GUID_Parent = objLocalConfig.Globals.Class_OntologyItems.GUID, _
                                                                                                 .Type = objLocalConfig.Globals.Type_Object}

                                objOItem_Result = objTransaction.do_Transaction(objOItem_OntologyItemForOntology)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    Dim objORel_OntologyItem_To_Ref = objDataWork_Ontologies.Rel_OntologyItemToRef(objOItem_OntologyItemForOntology,objOItem_OntologyItem)
                                    objOItem_Result = objTransaction.do_Transaction(objORel_OntologyItem_To_Ref,True)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        Dim objORel_Ontology_To_OItem = objDataWork_Ontologies.Rel_Ontology_To_OntologyItem(objOItem_Ontology,objOItem_OntologyItemForOntology)
                                        objOItem_Result = objTransaction.do_Transaction(objORel_Ontology_To_OItem)
                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                            objTransaction.rollback()
                                            Exit For
                                        End If
                                    Else 
                                        objTransaction.rollback()
                                        Exit For
                                    End If
                                Else 
                                    objTransaction.rollback()
                                    Exit For
                                End If
                            End If
                        Next
                    End If

                    
                End If
                
            End If
        End If
        


        Return objoiteM_Result
    End Function

    Public Sub New(LocalConfig As clsLocalConfig, DataWork_OntologyConfig As clsDataWork_OntologyConfig)
        objDataWork_OntologyConfig = DataWork_OntologyConfig
        
        objLocalConfig = LocalConfig
        objDataWork_Ontologies = New clsDataWork_Ontologies(objLocalConfig.Globals)
        objDataWork_OntologyConfig = DataWork_OntologyConfig

        objTransaction = new clsTransaction(objLocalConfig.Globals)
    End Sub
End Class
