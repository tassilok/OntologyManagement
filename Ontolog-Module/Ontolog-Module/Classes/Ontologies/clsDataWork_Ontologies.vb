Imports Structure_Module
Public Class clsDataWork_Ontologies
    Public objLocalConfig As clsLocalConfig_Ontologies

    Private objOItem_Result_Ontologies As clsOntologyItem
    Private objOItem_Result_OntolyRef As clsOntologyItem
    Private objOItem_Result_Classes As clsOntologyItem
    Private objOItem_Result_OntologyTree As clsOntologyItem
    Private objOItem_Result_OntologyJoins As clsOntologyItem
    Private objOItem_Result_OntologyJoinsOfOntologies As clsOntologyItem
    Private objOItem_Result_OntologyItems As clsOntologyItem
    Private objOItem_Result_OntologyItemsOfJoins As clsOntologyItem
    Private objOItem_Result_OntologyItemsOfOntologies As clsOntologyItem
    Private objOItem_Result_RefsOfOntologyItems As clsOntologyItem
    Private objOItem_Result_OntologyRelationRulesOfJoins As clsOntologyItem

    Private objDBLevel_Ontologies As clsDBLevel
    Private objDBLevel_OntologyRels As clsDBLevel
    Private objDBLevel_OntologyTree As clsDBLevel
    Private objDBLevel_Classes As clsDBLevel
    Private objDBLevel_OntologyJoin As clsDBLevel
    Private objDBLevel_OntologyJoinsOfOntologies As clsDBLevel
    Private objDBLevel_OntologyItems As clsDBLevel
    Private objDBLevel_OntologyItemsOfJoins As clsDBLevel
    Private objDBLevel_OntologyItemsOfOntologies As clsDBLevel
    Private objDBLevel_RefsOfOntologyItems As clsDBLevel
    Private objDBLevel_OntologyRelationRules As clsDBLevel

    Dim objOList_ClassTree As New List(Of clsOntologyItem)
    Dim objOList_Classes As New List(Of clsOntologyItem)
    Dim objOList_AttributeTypes As New List(Of clsOntologyItem)
    Dim objOList_RelationTypes As New List(Of clsOntologyItem)
    Dim objOList_Objects As New List(Of clsOntologyItem)
    Dim objOList_Refs As New List(Of clsOntologyItem)
    Dim objOList_Ontologies As New List(Of clsOntologyItem)
    Dim objOList_RefsOfOntology As New List(Of clsOntologyItem)
    Dim objOList_RefsOfOntologyItems As New List(Of clsOntologyItem)
    Dim objOList_Joins As New SortableBindingList(Of clsOntologyJoins)

    Private objClasses As New clsClasses
    Private objRelationTypes As New clsRelationTypes
    Private objFields As New clsFields

    Public ReadOnly Property OList_OntologyJoins As SortableBindingList(Of clsOntologyJoins)
        Get
            Return objOList_Joins
        End Get
    End Property

    Public ReadOnly Property OList_RefsOfOntologyItems As List(Of clsOntologyItem)
        Get
            Return objOList_RefsOfOntologyItems
        End Get
    End Property

    Public ReadOnly Property OList_RefsOfOntology As List(Of clsOntologyItem)
        Get
            Return objOList_RefsOfOntology
        End Get
    End Property

    Public ReadOnly Property OList_Ontologies As List(Of clsOntologyItem)
        Get
            Return objOList_Ontologies
        End Get
    End Property

    Public ReadOnly Property OList_OntologyTree As List(Of clsObjectTree)
        Get
            Return objDBLevel_OntologyTree.OList_ObjectTree
        End Get
    End Property

    Public ReadOnly Property OList_Joins As List(Of clsOntologyItem)
        Get
            Return objDBLevel_OntologyJoin.OList_Objects
        End Get
    End Property

    Public ReadOnly Property OList_JoinsOfOntologies As List(Of clsObjectRel)
        Get
            Return objDBLevel_OntologyJoinsOfOntologies.OList_ObjectRel_ID
        End Get
    End Property

    Public ReadOnly Property OList_Refs As List(Of clsOntologyItem)
        Get
            Return objOList_Refs
        End Get
    End Property

    Public ReadOnly Property OList_RefsOfOntologies As List(Of clsObjectRel)
        Get
            Return objDBLevel_OntologyRels.OList_ObjectRel
        End Get
    End Property

    Public ReadOnly Property OList_Classes As List(Of clsOntologyItem)
        Get
            Return objOList_Classes
        End Get
    End Property

    Public ReadOnly Property OList_AttributeTypes As List(Of clsOntologyItem)
        Get
            Return objOList_AttributeTypes
        End Get
    End Property

    Public ReadOnly Property OList_RelationTypes As List(Of clsOntologyItem)
        Get
            Return objOList_RelationTypes
        End Get
    End Property

    Public ReadOnly Property OList_Objects As List(Of clsOntologyItem)
        Get
            Return objOList_Objects
        End Get
    End Property

    Public ReadOnly Property LocalConfig As clsLocalConfig_Ontologies
        Get
            Return objLocalConfig
        End Get
    End Property

    Public ReadOnly Property OItem_Result_OntologyJoinsOfOntologies As clsOntologyItem
        Get
            Return objOItem_Result_OntologyJoinsOfOntologies
        End Get
    End Property

    Public ReadOnly Property OItem_Result_OntologyRelationRulesOfJoins As clsOntologyItem
        Get
            Return objOItem_Result_OntologyRelationRulesOfJoins
        End Get
    End Property

    Public ReadOnly Property OItem_Result_OntologyTree As clsOntologyItem
        Get
            Return objOItem_Result_OntologyTree
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Ontologies As clsOntologyItem
        Get
            Return objOItem_Result_Ontologies
        End Get
    End Property

    Public ReadOnly Property OItem_Result_OntologyRels As clsOntologyItem
        Get
            Return objOItem_Result_OntolyRef
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Classes As clsOntologyItem
        Get
            Return objOItem_Result_Classes
        End Get
    End Property

    Public ReadOnly Property OItem_Result_OntologyItems As clsOntologyItem
        Get
            Return objOItem_Result_OntologyItems
        End Get
    End Property

    Public ReadOnly Property OItem_Result_OntologyJoins As clsOntologyItem
        Get
            Return objOItem_Result_OntologyJoins
        End Get
    End Property

    Public ReadOnly Property OItem_Result_OntologyItemsOfOntologies As clsOntologyItem
        Get
            Return objOItem_Result_OntologyItemsOfOntologies
        End Get
    End Property

    Public ReadOnly Property OItem_Result_OntologyItemsOfJoins As clsOntologyItem
        Get
            Return objOItem_Result_OntologyItemsOfJoins
        End Get
    End Property

    Public ReadOnly Property OList_ClassTree As List(Of clsOntologyItem)
        Get
            Return objOList_ClassTree
        End Get
    End Property


    Public Sub GetData_Ontologies()
        Dim OList_Ontologies As New List(Of clsOntologyItem)
        Dim objOItem_Result As clsOntologyItem

        objOItem_Result_Ontologies = objLocalConfig.Globals.LState_Nothing

        OList_Ontologies.Add(New clsOntologyItem() With {.GUID_Parent = objClasses.OItem_Class_Ontologies.GUID})

        objOItem_Result = objDBLevel_Ontologies.get_Data_Objects(OList_Ontologies)

        objOList_Ontologies.Clear()

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOList_Ontologies = objDBLevel_Ontologies.OList_Objects
        End If

        objOItem_Result_Ontologies = objOItem_Result
    End Sub

    Public Sub GetData_OntologyTree()


        objOItem_Result_OntologyTree = objLocalConfig.Globals.LState_Nothing


        objOItem_Result_OntologyTree = objDBLevel_OntologyTree.get_Data_Objects_Tree(objClasses.OItem_Class_Ontologies, _
                                                                            objClasses.OItem_Class_Ontologies, _
                                                                            objRelationTypes.OItem_RelationType_Contains)

    End Sub

    Public Sub GetData_OntologyRefs()
        Dim OList_OntologyRefs As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem

        objOItem_Result_OntolyRef = objLocalConfig.Globals.LState_Nothing

        OList_OntologyRefs.Add(New clsObjectRel() With {.ID_Parent_Object = objClasses.OItem_Class_Ontologies.GUID, _
                                                        .ID_RelationType = objRelationTypes.OItem_RelationType_belongingResource.GUID})



        objOItem_Result = objDBLevel_OntologyRels.get_Data_ObjectRel(OList_OntologyRefs, boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOList_RefsOfOntology = (From obj In objDBLevel_OntologyRels.OList_ObjectRel
                                       Select New clsOntologyItem With {.GUID = obj.ID_Other, _
                                                                        .Name = obj.Name_Other, _
                                                                        .GUID_Parent = obj.ID_Parent_Other, _
                                                                        .Type = obj.Ontology}).ToList()

            objOList_AttributeTypes = (From obj In (From obj In objDBLevel_OntologyRels.OList_ObjectRel
                                       Where obj.ID_Parent_Other = objLocalConfig.Globals.Type_AttributeType).ToList()
                                      Group By obj.ID_Other, _
                                               obj.Name_Other Into Group
                                      Select New clsOntologyItem() With {.GUID = ID_Other, _
                                                                         .Name = Name_Other, _
                                                                         .Type = objLocalConfig.Globals.Type_AttributeType}).ToList()

            objOList_RelationTypes = (From obj In (From obj In objDBLevel_OntologyRels.OList_ObjectRel
                                       Where obj.Ontology = objLocalConfig.Globals.Type_RelationType).ToList()
                                      Group By obj.ID_Other, _
                                               obj.Name_Other Into Group
                                      Select New clsOntologyItem() With {.GUID = ID_Other, _
                                                                         .Name = Name_Other, _
                                                                         .Type = objLocalConfig.Globals.Type_AttributeType}).ToList()

            objOList_Classes = (From obj In (From obj In objDBLevel_OntologyRels.OList_ObjectRel
                                       Where obj.Ontology = objLocalConfig.Globals.Type_Class).ToList()
                                      Group By obj.ID_Other, _
                                               obj.Name_Other, _
                                               obj.ID_Parent_Other Into Group
                                      Select New clsOntologyItem() With {.GUID = ID_Other, _
                                                                         .Name = Name_Other, _
                                                                         .GUID_Parent = ID_Parent_Other, _
                                                                         .Type = objLocalConfig.Globals.Type_AttributeType}).ToList()

            objOList_Objects = (From obj In (From obj In objDBLevel_OntologyRels.OList_ObjectRel
                                       Where obj.Ontology = objLocalConfig.Globals.Type_Object).ToList()
                                      Group By obj.ID_Other, _
                                               obj.Name_Other, _
                                               obj.ID_Parent_Other Into Group
                                      Select New clsOntologyItem() With {.GUID = ID_Other, _
                                                                         .Name = Name_Other, _
                                                                         .GUID_Parent = ID_Parent_Other, _
                                                                         .Type = objLocalConfig.Globals.Type_AttributeType}).ToList()
        End If

        objOItem_Result_OntolyRef = objOItem_Result
    End Sub

    Public Sub GetData_Classes()

        objOItem_Result_Classes = objLocalConfig.Globals.LState_Nothing

        objOItem_Result_Classes = objDBLevel_Classes.get_Data_Classes()

    End Sub

    Public Function GetData_ClassTree() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOList_ClassTree.Clear()

        If objOItem_Result_OntolyRef.GUID = objLocalConfig.Globals.LState_Success.GUID And objOItem_Result_Classes.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOList_ClassTree = (From obj In objDBLevel_OntologyRels.OList_ObjectRel
                                Where obj.Ontology = objLocalConfig.Globals.Type_Class
                                Order By obj.Name_Other
                                Select New clsOntologyItem() With {.GUID = obj.ID_Other, _
                                                                   .Name = obj.Name_Other, _
                                                                   .GUID_Parent = obj.ID_Parent_Other, _
                                                                   .Type = objLocalConfig.Globals.Type_Class}).ToList()

            objOList_ClassTree = objOList_ClassTree.Concat(From obj In objDBLevel_OntologyRels.OList_ObjectRel
                                                     Where obj.Ontology = objLocalConfig.Globals.Type_Object
                                                     Group By obj.ID_Parent_Other Into Group
                                                     Join objClass In objDBLevel_Classes.OList_Classes On ID_Parent_Other Equals objClass.GUID
                                                     Order By objClass.Name
                                                     Select New clsOntologyItem() With {.GUID = objClass.GUID, _
                                                                                        .Name = objClass.Name, _
                                                                                        .GUID_Parent = objClass.GUID_Parent, _
                                                                                        .Type = objLocalConfig.Globals.Type_Class}).ToList()


            Dim lngCount As Long
            Do
                Dim objOList_ClassParents = From objClass In (From objClass In objOList_ClassTree
                                         Join objParentClass In objDBLevel_Classes.OList_Classes On objClass.GUID_Parent Equals objParentClass.GUID
                                         Group Join objClass2 In objOList_ClassTree On objParentClass.GUID Equals objClass2.GUID Into objClasses = Group
                                         From objClass2 In objClasses.DefaultIfEmpty
                                         Where objClass2 Is Nothing
                                         Select New clsOntologyItem() With {.GUID = objParentClass.GUID, _
                                                                            .Name = objParentClass.Name, _
                                                                            .GUID_Parent = objParentClass.GUID_Parent, _
                                                                            .Type = objLocalConfig.Globals.Type_Class}).ToList
                                         Group By objClass.GUID, objClass.Name, objClass.GUID_Parent, objClass.Type Into Group
                                         Order By Name
                                         Select New clsOntologyItem() With {.GUID = GUID, _
                                                                            .Name = Name, _
                                                                            .GUID_Parent = GUID_Parent, _
                                                                            .Type = Type}

                lngCount = objOList_ClassParents.Count
                If lngCount > 0 Then
                    objOList_ClassTree = objOList_ClassTree.Concat(objOList_ClassParents).ToList()
                End If
            Loop Until lngCount = 0

            objOItem_Result = objLocalConfig.Globals.LState_Success

        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        Return objOItem_Result
    End Function

    Public Sub GetData_OntologyItems()
        objOItem_Result_OntologyItems = objLocalConfig.Globals.LState_Nothing
        Dim objOList_OntologyItems = New List(Of clsOntologyItem)

        objOList_OntologyItems.Add(New clsOntologyItem() With {.GUID_Parent = objClasses.OItem_Class_OntologyItems.GUID})

        objOItem_Result_OntologyItems = objDBLevel_OntologyItems.get_Data_Objects(objOList_OntologyItems)

    End Sub

    Public Sub GetData_OntologyJoins()
        objOItem_Result_OntologyJoins = objLocalConfig.Globals.LState_Nothing
        Dim objOList_OntJoins = New List(Of clsOntologyItem)

        objOList_OntJoins.Add(New clsOntologyItem() With {.GUID_Parent = objClasses.OItem_Class_OntologyJoin.GUID})

        objOItem_Result_OntologyJoins = objDBLevel_OntologyJoin.get_Data_Objects(objOList_OntJoins)

    End Sub

    Public Sub GetData_002_OntologyItemsOfJoins()
        objOItem_Result_OntologyItemsOfJoins = objLocalConfig.Globals.LState_Nothing
        Dim objOList_OItemsOfJoins = New List(Of clsObjectRel)

        objOList_OItemsOfJoins.Add(New clsObjectRel() With {.ID_Parent_Object = objClasses.OItem_Class_OntologyJoin.GUID, _
                                                            .ID_Parent_Other = objClasses.OItem_Class_OntologyItems.GUID, _
                                                            .ID_RelationType = objRelationTypes.OItem_RelationType_Contains.GUID})
        objOItem_Result_OntologyItemsOfJoins = objDBLevel_OntologyItemsOfJoins.get_Data_ObjectRel(objOList_OItemsOfJoins, boolIDs:=False)

    End Sub

    Public Sub GetData_003_OntologyItemsOfOntologies()
        objOItem_Result_OntologyItemsOfOntologies = objLocalConfig.Globals.LState_Nothing
        Dim objOList_OIemsOfOntologies = New List(Of clsObjectRel)

        objOList_OIemsOfOntologies.Add(New clsObjectRel() With {.ID_Parent_Object = objClasses.OItem_Class_Ontologies.GUID, _
                                                                .ID_Parent_Other = objClasses.OItem_Class_OntologyItems.GUID, _
                                                                .ID_RelationType = objRelationTypes.OItem_RelationType_Contains.GUID})

        objOItem_Result_OntologyItemsOfOntologies = objDBLevel_OntologyItemsOfOntologies.get_Data_ObjectRel(objOList_OIemsOfOntologies, boolIDs:=False)


    End Sub

    Public Sub GetData_RefsOfOntologyItems()
        Dim objOItem_Result As clsOntologyItem
        objOItem_Result_RefsOfOntologyItems = objLocalConfig.Globals.LState_Nothing
        Dim objOList_RefsOfOntologyItems = New List(Of clsObjectRel)

        objOList_RefsOfOntologyItems.Add(New clsObjectRel() With {.ID_Parent_Object = objClasses.OItem_Class_OntologyItems.GUID})

        objOItem_Result = objDBLevel_RefsOfOntologyItems.get_Data_ObjectRel(objOList_RefsOfOntologyItems, boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOList_Refs = (From obj In objDBLevel_RefsOfOntologyItems.OList_ObjectRel
                            Where obj.ID_RelationType = objRelationTypes.OItem_RelationType_belongingAttribute.GUID And _
                                  obj.Ontology = objLocalConfig.Globals.Type_AttributeType
                            Group By obj.ID_Other, obj.Name_Other Into Group
                            Select New clsOntologyItem() With {.GUID = ID_Other, _
                                                               .Name = Name_Other, _
                                                               .Type = objLocalConfig.Globals.Type_AttributeType}).ToList()

            objOList_Refs = objOList_Refs.Concat(From obj In objDBLevel_RefsOfOntologyItems.OList_ObjectRel
                            Where obj.ID_RelationType = objRelationTypes.OItem_RelationType_belongingRelationType.GUID And _
                                  obj.Ontology = objLocalConfig.Globals.Type_RelationType
                            Group By obj.ID_Other, obj.Name_Other Into Group
                            Select New clsOntologyItem() With {.GUID = ID_Other, _
                                                               .Name = Name_Other, _
                                                               .Type = objLocalConfig.Globals.Type_RelationType}).tolist()

            objOList_Refs = objOList_Refs.Concat(From obj In objDBLevel_RefsOfOntologyItems.OList_ObjectRel
                            Where obj.ID_RelationType = objRelationTypes.OItem_RelationType_belongingClass.GUID And _
                                  obj.Ontology = objLocalConfig.Globals.Type_Class
                            Group By obj.ID_Other, obj.Name_Other, obj.ID_Parent_Other Into Group
                            Select New clsOntologyItem() With {.GUID = ID_Other, _
                                                               .Name = Name_Other, _
                                                               .GUID_Parent = ID_Parent_Other, _
                                                               .Type = objLocalConfig.Globals.Type_Class}).tolist()

            objOList_Refs = objOList_Refs.Concat(From obj In objDBLevel_RefsOfOntologyItems.OList_ObjectRel
                            Where obj.ID_RelationType = objRelationTypes.OItem_RelationType_belongingObject.GUID And _
                                  obj.Ontology = objLocalConfig.Globals.Type_Object
                            Group By obj.ID_Other, obj.Name_Other, obj.ID_Parent_Other Into Group
                            Select New clsOntologyItem() With {.GUID = ID_Other, _
                                                               .Name = Name_Other, _
                                                               .GUID_Parent = ID_Parent_Other, _
                                                               .Type = objLocalConfig.Globals.Type_Object}).tolist()

            Me.objOList_RefsOfOntologyItems = (From objOntologyItems In objDBLevel_OntologyItemsOfJoins.OList_ObjectRel
                                       Join objRef In objDBLevel_RefsOfOntologyItems.OList_ObjectRel On objRef.ID_Object Equals objOntologyItems.ID_Other
                                       Where objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingAttribute.GUID Or _
                                             objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingClass.GUID Or _
                                             objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingObject.GUID Or _
                                             objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingRelationType.GUID
                                     Join objOntologies In objDBLevel_OntologyJoinsOfOntologies.OList_ObjectRel_ID On objOntologyItems.ID_Object Equals objOntologies.ID_Other
                                     Group By ID_Ontology = objOntologies.ID_Object, _
                                              ID_Ref = objRef.ID_Other, _
                                              Name_Ref = objRef.Name_Other, _
                                              ID_Parent_Ref = objRef.ID_Parent_Other, _
                                              Ontology = objRef.Ontology Into Group
                                    Select New clsOntologyItem With {.GUID = ID_Ref, _
                                                                     .Name = Name_Ref, _
                                                                     .GUID_Parent = ID_Parent_Ref, _
                                                                     .GUID_Related = ID_Ontology, _
                                                                     .Type = Ontology}).ToList()

            Me.objOList_RefsOfOntologyItems = Me.objOList_RefsOfOntologyItems.Concat(From objOntologyItems In objDBLevel_OntologyItemsOfOntologies.OList_ObjectRel
                                       Join objRef In objDBLevel_RefsOfOntologyItems.OList_ObjectRel On objRef.ID_Object Equals objOntologyItems.ID_Other
                                       Where objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingAttribute.GUID Or _
                                             objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingClass.GUID Or _
                                             objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingObject.GUID Or _
                                             objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingRelationType.GUID
                                     Group By ID_Ontology = objOntologyItems.ID_Object, _
                                              ID_Ref = objRef.ID_Other, _
                                              Name_Ref = objRef.Name_Other, _
                                              ID_Parent_Ref = objRef.ID_Parent_Other, _
                                              Ontology = objRef.Ontology Into Group
                                    Select New clsOntologyItem With {.GUID = ID_Ref, _
                                                                     .Name = Name_Ref, _
                                                                     .GUID_Parent = ID_Parent_Ref, _
                                                                     .GUID_Related = ID_Ontology, _
                                                                     .Type = Ontology}).ToList()
        Else
            objOItem_Result_RefsOfOntologyItems = objOItem_Result
        End If

    End Sub

    Public Sub GetData_OntologyRelationRulesOfJoins()
        objOItem_Result_OntologyRelationRulesOfJoins = objLocalConfig.Globals.LState_Nothing
        Dim objOList_ORR = New List(Of clsObjectRel) 

        objOList_ORR.Add(New clsObjectRel With {.ID_Parent_Object = objLocalConfig.Globals.Class_OntologyJoin.GUID, _
                                                                            .ID_Parent_Other = objLocalConfig.Globals.Class_OntologyRelationRule.GUID})

        Dim objOItem_Result = objDBLevel_OntologyRelationRules.get_Data_ObjectRel(objOList_ORR, boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim OList_OItems1 = (From objOItem In objDBLevel_OntologyItemsOfJoins.OList_ObjectRel
                                 Join objRef In objDBLevel_RefsOfOntologyItems.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                 Where objOItem.OrderID = 1
                                 Select New clsOntologyItem With {.GUID = objRef.ID_Other, _
                                                                  .Name = objRef.Name_Other, _
                                                                  .GUID_Parent = objRef.ID_Parent_Other, _
                                                                  .GUID_Related = objOItem.ID_Object, _
                                                                  .Type = objRef.Ontology}).ToList()

            Dim OList_OItems2 = (From objOItem In objDBLevel_OntologyItemsOfJoins.OList_ObjectRel
                                 Join objRef In objDBLevel_RefsOfOntologyItems.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                 Where objOItem.OrderID = 2
                                 Select New clsOntologyItem With {.GUID = objRef.ID_Other, _
                                                                  .Name = objRef.Name_Other, _
                                                                  .GUID_Parent = objRef.ID_Parent_Other, _
                                                                  .GUID_Related = objOItem.ID_Object, _
                                                                  .Type = objRef.Ontology}).ToList()

            Dim OList_OItems3 = (From objOItem In objDBLevel_OntologyItemsOfJoins.OList_ObjectRel
                                 Join objRef In objDBLevel_RefsOfOntologyItems.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                 Where objOItem.OrderID = 3
                                 Select New clsOntologyItem With {.GUID = objRef.ID_Other, _
                                                                  .Name = objRef.Name_Other, _
                                                                  .GUID_Parent = objRef.ID_Parent_Other, _
                                                                  .GUID_Related = objOItem.ID_Object, _
                                                                  .Type = objRef.Ontology}).ToList()


            objOList_Joins = New SortableBindingList(Of clsOntologyJoins)((From objJoin In objDBLevel_OntologyJoinsOfOntologies.OList_ObjectRel_ID
                                                                            Join objOItem1 In OList_OItems1 On objOItem1.GUID_Related Equals objJoin.ID_Other
                                                                            Join objOItem2 In OList_OItems2 On objOItem2.GUID_Related Equals objJoin.ID_Other
                                                                            Group Join objOItem3 In OList_OItems3 On objOItem3.GUID_Related Equals objJoin.ID_Other Into objOItems3 = Group
                                                                            From objOItem3 In objOItems3.DefaultIfEmpty()
                                                                            Group Join objOntologRelationRule In objDBLevel_OntologyRelationRules.OList_ObjectRel On objOntologRelationRule.ID_Object Equals objJoin.ID_Other Into objRules = Group
                                                                            From objOntologyRelationRule In objRules.DefaultIfEmpty()
                                                                            Select New clsOntologyJoins With {.ID_Ontology = objJoin.ID_Object, _
                                                                                                              .ID_Join = objJoin.ID_Other, _
                                                                                                              .Name_Join = objJoin.Name_Other, _
                                                                                                              .ID_OItem1 = objOItem1.GUID, _
                                                                                                              .Name_OItem1 = objOItem1.Name, _
                                                                                                              .ID_ParentOItem1 = objOItem1.GUID_Parent, _
                                                                                                              .Ontology_OItem1 = objOItem1.Type, _
                                                                                                              .ID_OItem2 = objOItem2.GUID, _
                                                                                                              .Name_OItem2 = objOItem2.Name, _
                                                                                                              .ID_ParentOItem2 = objOItem2.GUID_Parent, _
                                                                                                              .Ontology_OItem2 = objOItem2.Type, _
                                                                                                              .ID_OItem3 = GetFieldOfObject(objOItem3, "GUID"), _
                                                                                                              .Name_OItem3 = GetFieldOfObject(objOItem3, "Name"), _
                                                                                                              .ID_ParentOItem3 = GetFieldOfObject(objOItem3, "GUID_Parent"), _
                                                                                                              .Ontology_OItem3 = GetFieldOfObject(objOItem3, "Type"), _
                                                                                                              .ID_OntologyRelationRule = GetFieldOfObjectRel(objOntologyRelationRule, objFields.ID_Other), _
                                                                                                              .Name_OntolgyRelationRule = GetFieldOfObjectRel(objOntologyRelationRule, objFields.Name_Other)}).ToList())

        End If
        objOItem_Result_OntologyRelationRulesOfJoins = objOItem_Result
    End Sub

    Public Function GetFieldOfObject(OItem_Item As clsOntologyItem, strField As String) As String
        Select Case strField
            Case "GUID"
                If OItem_Item Is Nothing Then
                    Return Nothing
                Else
                    Return OItem_Item.GUID
                End If
            Case "Name"
                If OItem_Item Is Nothing Then
                    Return Nothing
                Else
                    Return OItem_Item.Name
                End If
            Case "GUID_Parent"
                If OItem_Item Is Nothing Then
                    Return Nothing
                Else
                    Return OItem_Item.GUID_Parent
                End If
            Case "Type"
                If OItem_Item Is Nothing Then
                    Return Nothing
                Else
                    Return OItem_Item.Type
                End If
        End Select
    End Function

    Public Function GetFieldOfObjectRel(OItem_Item As clsObjectRel, strField As String) As String
        Select Case strField
            Case objFields.ID_Other
                If OItem_Item Is Nothing Then
                    Return Nothing
                Else
                    Return OItem_Item.ID_Other
                End If
            Case objFields.Name_Other
                If OItem_Item Is Nothing Then
                    Return Nothing
                Else
                    Return OItem_Item.Name_Other
                End If
        End Select
    End Function

    Public Sub GetData_001_OntologyJoinsOfOntologies()
        objOItem_Result_OntologyJoinsOfOntologies = objLocalConfig.Globals.LState_Nothing
        Dim objOList_OntologyJoinsOfOntologies = New List(Of clsObjectRel)

        objOList_OntologyJoinsOfOntologies.Add(New clsObjectRel() With {.ID_Parent_Object = objClasses.OItem_Class_Ontologies.GUID, _
                                                                        .ID_Parent_Other = objClasses.OItem_Class_OntologyJoin.GUID, _
                                                                        .ID_RelationType = objRelationTypes.OItem_RelationType_Contains.GUID})

        objOItem_Result_OntologyJoinsOfOntologies = objDBLevel_OntologyJoinsOfOntologies.get_Data_ObjectRel(objOList_OntologyJoinsOfOntologies)

    End Sub

    Public Sub New(LocalConfig As clsLocalConfig_Ontologies)
        objLocalConfig = LocalConfig

        objOItem_Result_Ontologies = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_OntolyRef = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_OntologyJoins = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Classes = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_OntologyItems = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_OntologyItemsOfJoins = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_OntologyItemsOfOntologies = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_RefsOfOntologyItems = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_OntologyJoinsOfOntologies = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_OntologyTree = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_OntologyRelationRulesOfJoins = objLocalConfig.Globals.LState_Nothing

        initialize()
    End Sub

    Private Sub initialize()
        objDBLevel_Ontologies = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OntologyRels = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Classes = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OntologyJoin = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OntologyItems = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OntologyItemsOfJoins = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OntologyItemsOfOntologies = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_RefsOfOntologyItems = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OntologyJoinsOfOntologies = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OntologyTree = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OntologyRelationRules = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
