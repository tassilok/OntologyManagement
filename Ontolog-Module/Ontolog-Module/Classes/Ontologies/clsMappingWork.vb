Imports OntologyClasses.BaseClasses
Public Class clsMappingWork
    Private objGlobals As clsGlobals
    Private objDBLevel_OntologyMapping_To_Rel As clsDBLevel
    Private objDBLevel_OntologyMappingItemTree As clsDBLevel
    Private objDBLevel_OntologyMappingItem_To_Rel As clsDBLevel
    Private objDBLevel_OntologyMappingItem_To_Att As clsDBLevel
    Private objDataWork_Ontologies As clsDataWork_Ontologies
    Private objOItem_Mapping As clsOntologyItem

    Public function GetData_Mappings(OItem_Mapping As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        Dim objOList_Mappings_To_Rel = new List(Of clsObjectRel) From
        {   
            New clsObjectRel With {.ID_Object = OItem_Mapping.GUID, _
                                   .ID_RelationType = objGlobals.RelationType_Apply.GUID, _
                                   .ID_Parent_Other = objGlobals.Class_MappingRule.GUID}, _
            New clsObjectRel With {.ID_Object = OItem_Mapping.GUID, _
                                   .ID_RelationType = objGlobals.RelationType_Src.GUID, _
                                   .ID_Parent_Other = objGlobals.Class_OntologyMappingItem.GUID}, _
            New clsObjectRel With {.ID_Object = OItem_Mapping.GUID, _
                                   .ID_RelationType = objGlobals.RelationType_Dst.GUID, _
                                   .ID_Parent_Other = objGlobals.Class_OntologyMappingItem.GUID}
        }

        Dim objOList_MappingItem_To_Rel = new List(Of clsObjectRel) From
        {
            New clsObjectRel With {.ID_Parent_Object = objGlobals.Class_OntologyMappingItem.GUID, _
                                   .ID_RelationType = objGlobals.RelationType_contains.GUID, _
                                   .ID_Parent_Other = objGlobals.Class_OntologyJoin.GUID}, _
            New clsObjectRel With {.ID_Parent_Object = objGlobals.Class_OntologyMappingItem.GUID, _
                                   .ID_RelationType = objGlobals.RelationType_belonging.GUID, _
                                   .ID_Parent_Other = objGlobals.Class_Directions.GUID}
        }

        Dim objOList_MappingItem_To_Att = new List(Of clsObjectAtt) From 
        {
            New clsObjectAtt With {.ID_Class = objGlobals.Class_OntologyMappingItem.GUID, _
                                   .ID_AttributeType = objGlobals.AttributeType_Navigation.GUID }, _
            New clsObjectAtt With {.ID_Class = objGlobals.Class_OntologyMappingItem.GUID, _
                                   .ID_AttributeType = objGlobals.AttributeType_OrderID.GUID }
        }

        objOItem_Result = objDBLevel_OntologyMappingItemTree.get_Data_Objects_Tree(objGlobals.Class_OntologyMappingItem,objGlobals.Class_OntologyMappingItem, objGlobals.RelationType_contains)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            objOItem_Result = objDBLevel_OntologyMapping_To_Rel.get_Data_ObjectRel(objOList_Mappings_To_Rel,boolIDs := False)    
            If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                objOItem_Result = objDBLevel_OntologyMappingItem_To_Rel.get_Data_ObjectRel(objOList_MappingItem_To_Rel,boolIDs := False)
                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    objOItem_Result = objDBLevel_OntologyMappingItem_To_Att.get_Data_ObjectAtt(objOList_MappingItem_To_Att, boolIDs := False) 
                    If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                        objDataWork_Ontologies.GetData_001_OntologyJoinsOfOntologies()
                        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                            objDataWork_Ontologies.GetData_002_OntologyItemsOfJoins()
                            If objDataWork_Ontologies.OItem_Result_OntologyItemsOfJoins.GUID = objGlobals.LState_Success.GUID Then
                                objDataWork_Ontologies.GetData_RefsOfOntologyItems()
                                If objDataWork_Ontologies.OItem_Result_RefsOfOntologyItems.GUID = objGlobals.LState_Success.GUID Then
                                    Dim objList_MappingItems_SRC = (From objMapping In objDBLevel_OntologyMapping_To_Rel.OList_ObjectRel
                                                               Where objMapping.ID_RelationType = objGlobals.RelationType_Src.GUID
                                                               Join objMappingItem In objDBLevel_OntologyMappingItemTree.OList_ObjectTree on objMappingItem.ID_Object equals objMapping.ID_Object).ToList()
                                                               
                                    For Each anonymous In objList_MappingItems_SRC
                                        
                                    Next
                                Else 
                                    objOItem_Result = objGlobals.LState_Error
                                End If
                            Else 
                                objOItem_Result = objGlobals.LState_Error
                            End If
                        End If
                        

                    End If
                End If
                


                
            End If
        End If


        Return objOItem_Result
    End Function

    Public Sub New(Globals As clsGlobals)
        objGlobals = Globals
        Initialize()
    End Sub

    Private sub Initialize()
        objDBLevel_OntologyMapping_To_Rel = new clsDBLevel(objGlobals)
        objDBLevel_OntologyMappingItemTree = new clsDBLevel(objGlobals)
        objDBLevel_OntologyMappingItem_To_Rel = new clsDBLevel(objGlobals)
        objDBLevel_OntologyMappingItem_To_Att = new clsDBLevel(objGlobals)

        objDataWork_Ontologies = new clsDataWork_Ontologies(objGlobals)
    End Sub
End Class
