Imports OntologyClasses.BaseClasses
Public Class clsMappingWork
    Private objGlobals As clsGlobals
    Private objDBLevel_OntologyMappingItems As clsDBLevel
    Private objDBLevel_OntologyMapping_To_Rel As clsDBLevel
    Private objDBLevel_OntologyMappingItemTree As clsDBLevel
    Private objDBLevel_OntologyMappingItem_To_Rel As clsDBLevel
    Private objDBLevel_OntologyMappingItem_To_Att As clsDBLevel
    Private objDataWork_Ontologies As clsDataWork_Ontologies
    Private objOItem_Mapping As clsOntologyItem
    Private objMappingItems As List(Of clsMappingItem)

    Private objOItem_Result_MappingItems As clsOntologyItem

    Public ReadOnly Property OItem_Result_MappingItems As clsOntologyItem
        Get
            Return objOItem_Result_MappingItems
        End Get
    End Property


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

        

        GetData_MappingItems()
        objOItem_Result = objOItem_Result_MappingItems
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            objOItem_Result = objDBLevel_OntologyMapping_To_Rel.get_Data_ObjectRel(objOList_Mappings_To_Rel,boolIDs := False)    
                   
            If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                objDataWork_Ontologies.GetData_001_OntologyJoinsOfOntologies()
                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    objDataWork_Ontologies.GetData_002_OntologyItemsOfJoins()
                    If objDataWork_Ontologies.OItem_Result_OntologyItemsOfJoins.GUID = objGlobals.LState_Success.GUID Then
                        objDataWork_Ontologies.GetData_RefsOfOntologyItems()
                        If objDataWork_Ontologies.OItem_Result_RefsOfOntologyItems.GUID = objGlobals.LState_Success.GUID Then
                           objOItem_Result = objGlobals.LState_Success

                            
                        Else 
                            objOItem_Result = objGlobals.LState_Error
                        End If
                    Else 
                        objOItem_Result = objGlobals.LState_Error
                    End If
                
                End If
                        


                
            End If
        End If


        Return objOItem_Result
    End Function

    Public Function MapItems(OItem_Mapping As clsOntologyItem) As clsOntologyItem


        Dim objOItem_Result = GetData_Mappings(OItem_Mapping)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            objMappingItems = new List(Of clsMappingItem)
            objMappingItems = (From objMappingItem In objDBLevel_OntologyMappingItems.OList_Objects
                                                      Group Join objNavigation In objDBLevel_OntologyMappingItem_To_Att.OList_ObjectAtt.Where(Function(p) p.ID_AttributeType = objGlobals.AttributeType_Navigation.GUID).ToList() on objNavigation.ID_Object equals objMappingItem.GUID Into objNavigations = Group
                                                      From objNavigation In objNavigations.DefaultIfEmpty()
                                                      Group Join objOrderID In objDBLevel_OntologyMappingItem_To_Att.OList_ObjectAtt.Where(Function(p) p.ID_AttributeType = objGlobals.AttributeType_OrderID.GUID).ToList() on objOrderID.ID_Object equals objMappingItem.GUID Into objOrderIDs = Group
                                                      From objOrderID In objOrderIDs.DefaultIfEmpty()
                                                      Join objDirection In objDBLevel_OntologyMappingItem_To_Rel.OList_ObjectRel.Where(Function(p) p.ID_Parent_Other = objGlobals.Class_Directions.GUID).ToList() on objDirection.ID_Object equals objMappingItem.GUID
                                                      Join objOntologyJoin in objDBLevel_OntologyMappingItem_To_Rel.OList_ObjectRel.Where(Function(p) p.ID_Parent_Other = objGlobals.Class_OntologyJoin.GUID).ToList() on objOntologyJoin.ID_Object equals objMappingItem.GUID
                                                      Select New clsMappingItem With 
                                                             {
                                                                 .ID_MappingItem = objMappingItem.GUID, _
                                                                 .Name_MappingItem = objMappingItem.Name, _
                                                                 .ID_Attribute_Navigation = If(objNavigation Is Nothing,Nothing,objNavigation.ID_Attribute), _
                                                                 .Navigation = If(objNavigation Is Nothing,false,objNavigation.Val_Bit), _
                                                                 .ID_Attribute_OrderID = If(objOrderID Is Nothing,Nothing,objOrderID.ID_Attribute), _
                                                                 .OrderID = If(objOrderID Is Nothing,0,objOrderID.Val_Lng), _
                                                                 .ID_Direction = objDirection.ID_Other, _
                                                                 .Name_Direction = objDirection.Name_Other, _
                                                                 .ID_OntologyJoin = objOntologyJoin.ID_Other, _
                                                                 .Name_OntologyJoin = objOntologyJoin.Name_Other
                                                             }).ToList()    

            Dim list_MappingItem_Src = (From objMapping in objDBLevel_OntologyMapping_To_Rel.OList_ObjectRel.Where(Function(p) p.ID_RelationType = objGlobals.RelationType_Src.GUID).ToList()
                                           Join objMappingItem In objMappingItems on objMappingItem.ID_MappingItem equals objMapping.ID_Other
                                           Select objMappingItem).ToList()

            Dim list_MappingItem_Dst = (From objMapping in objDBLevel_OntologyMapping_To_Rel.OList_ObjectRel.Where(Function(p) p.ID_RelationType = objGlobals.RelationType_Dst.GUID).ToList()
                                           Join objMappingItem In objMappingItems on objMappingItem.ID_MappingItem equals objMapping.ID_Other
                                           Select objMappingItem).ToList()

            If list_MappingItem_Src.Count = 1 And list_MappingItem_Dst.Any()  then

            Else 
                objOItem_Result = objGlobals.LState_Error.Clone()
            End If
                                           
        End If
        
        Return objOItem_Result
    End Function

    Public Sub GetData_MappingItems() 
        Dim objOList_MappingItem_To_Rel = new List(Of clsObjectRel) From
        {
            New clsObjectRel With {.ID_Parent_Object = objGlobals.Class_OntologyMappingItem.GUID, _
                                   .ID_RelationType = objGlobals.RelationType_belongsTo.GUID, _
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

        Dim objOList_Objects = new List(Of clsOntologyItem) From { New clsOntologyItem With {.GUID_Parent=objGlobals.Class_OntologyMappingItem.GUID}}


        objOItem_Result_MappingItems = objGlobals.LState_Nothing.Clone()
        Dim objOItem_Result = objDBLevel_OntologyMappingItems.get_Data_Objects(objOList_Objects)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            objOItem_Result = objDBLevel_OntologyMappingItemTree.get_Data_Objects_Tree(objGlobals.Class_OntologyMappingItem,objGlobals.Class_OntologyMappingItem, objGlobals.RelationType_contains) 
            If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                objOItem_Result = objDBLevel_OntologyMappingItem_To_Rel.get_Data_ObjectRel(objOList_MappingItem_To_Rel,boolIDs := False)    
                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    objOItem_Result = objDBLevel_OntologyMappingItem_To_Att.get_Data_ObjectAtt(objOList_MappingItem_To_Att, boolIDs := False) 
                    If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

                    End If
                End If
            End If    
        End If
        
        

        objOItem_Result_MappingItems = objOItem_Result
        
    End Sub

    Public Sub New(Globals As clsGlobals)
        objGlobals = Globals
        Initialize()
    End Sub

    Private sub Initialize()
        objDBLevel_OntologyMapping_To_Rel = new clsDBLevel(objGlobals)
        objDBLevel_OntologyMappingItemTree = new clsDBLevel(objGlobals)
        objDBLevel_OntologyMappingItem_To_Rel = new clsDBLevel(objGlobals)
        objDBLevel_OntologyMappingItem_To_Att = new clsDBLevel(objGlobals)
        objDBLevel_OntologyMappingItems = new clsDBLevel(objGlobals)

        objDataWork_Ontologies = new clsDataWork_Ontologies(objGlobals)

        objOItem_Result_MappingItems = objGlobals.LState_Nothing.Clone()
    End Sub
End Class
