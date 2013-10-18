Imports OntologyClasses.DataClasses
Imports OntologyClasses.BaseClasses
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
    Private objOItem_OntologyRelationRulesOfOItems As clsOntologyItem

    Private objDBLevel_Ontologies As clsDBLevel
    Private objDBLevel_OntologyRels As clsDBLevel
    Private objDBLevel_OntologyTree As clsDBLevel
    Private objDBLevel_Classes As clsDBLevel
    Private objDBLevel_ClassesByGuid As clsDBLevel
    Private objDBLevel_OntologyJoin As clsDBLevel
    Private objDBLevel_OntologyJoinsOfOntologies As clsDBLevel
    Private objDBLevel_OntologyItems As clsDBLevel
    Private objDBLevel_OntologyItemsOfJoins As clsDBLevel
    Private objDBLevel_OntologyItemsOfJoinsExplicit As clsDBLevel
    Private objDBLevel_OntologyItemsOfOntologies As clsDBLevel
    Private objDBLevel_RefsOfOntologyItems As clsDBLevel
    Private objDBLevel_OntologyRelationRules As clsDBLevel
    Private objDBLevel_RefOfOntologyItem As clsDBLevel
    Private objDBLevel_Ref As clsDBLevel
    Private objDBLevel_OntologyRelationRulesOfOItems As clsDBLevel

    Dim objOList_ClassTree As New List(Of clsOntologyItem)
    Dim objOList_Classes As New List(Of clsOntologyItem)
    Dim objOList_AttributeTypes As New List(Of clsOntologyItem)
    Dim objOList_RelationTypes As New List(Of clsOntologyItem)
    Dim objOList_Objects As New List(Of clsOntologyItem)
    Dim objOList_Refs As New List(Of clsOntologyItem)
    Dim objOList_Ontologies As New List(Of clsOntologyItem)
    Dim objOList_RefsOfOntology As New List(Of clsOntologyItem)
    Dim objOList_RefsOfOntologyItems As New List(Of clsOntologyItemsOfOntologies)
    Dim objOList_Joins As New List(Of clsOntologyJoins)

    Private objClasses As New clsClasses
    Private objRelationTypes As New clsRelationTypes
    Private objFields As New clsFields

    Public Property OList_OntologyJoins As List(Of clsOntologyJoins)
        Get
            Return objOList_Joins
        End Get
        Set(value As List(Of clsOntologyJoins))
            objOList_Joins = value
        End Set

    End Property

    

    Public ReadOnly Property OList_RefsOfOntologyItems As List(Of clsOntologyItemsOfOntologies)
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

    Public ReadOnly Property OItem_OntologyRelationRulesOfOItems As clsOntologyItem
        Get
            Return objOItem_OntologyRelationRulesOfOItems
        End Get
    End Property

    Public ReadOnly Property OItem_Result_RefsOfOntologyItems As clsOntologyItem
        Get
            Return objOItem_Result_RefsOfOntologyItems
        End Get
    End Property

    Public ReadOnly Property OList_ClassTree As List(Of clsOntologyItem)
        Get
            Return objOList_ClassTree
        End Get
    End Property


    Public function GetData_BaseData() As clsOntologyItem
        Dim objOItem_Result as clsOntologyItem
        GetData_Classes()
        If OItem_Result_Classes.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            GetData_Ontologies()
            If OItem_Result_Ontologies.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                GetData_OntologyRefs()
                If OItem_Result_OntologyRels.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Result = GetData_ClassTree()

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        GetData_OntologyItems()
                        If OItem_Result_OntologyItems.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            GetData_OntologyJoins()
                            If OItem_Result_OntologyJoins.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                GetData_001_OntologyJoinsOfOntologies()
                                If OItem_Result_OntologyJoinsOfOntologies.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    GetData_002_OntologyItemsOfJoins()
                                    If OItem_Result_OntologyItemsOfJoins.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        GetData_003_OntologyItemsOfOntologies()
                                        If OItem_Result_OntologyItemsOfOntologies.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                            GetData_OntologyRelationRulesOfOItems()
                                            If OItem_Result_OntologyRels.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                GetData_RefsOfOntologyItems()
                                                If OItem_OntologyRelationRulesOfOItems.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                    GetData_OntologyTree()
                                                    If OItem_Result_OntologyTree.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                        GetData_OntologyRelationRulesOfJoins()
                                                        If OItem_Result_OntologyRelationRulesOfJoins.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                            objOItem_Result = objLocalConfig.Globals.LState_Success
                                                            
                                                        Else
                                                            objOItem_Result = objLocalConfig.Globals.LState_Error
                                                            
                                                        End If
                                                    
                                                    Else
                                                        objOItem_Result = objLocalConfig.Globals.LState_Error
                                                        
                                                    End If

                                                Else
                                                    objOItem_Result = objLocalConfig.Globals.LState_Error
                                                    
                                                End If
                                            Else 
                                                objOItem_Result = objLocalConfig.Globals.LState_Error
                                                
                                            End If
                                            

                                        Else
                                            objOItem_Result = objLocalConfig.Globals.LState_Error
                                            
                                        End If

                                    Else
                                        objOItem_Result = objLocalConfig.Globals.LState_Error
                                        
                                    End If

                                Else
                                    objOItem_Result = objLocalConfig.Globals.LState_Error
                                    
                                End If

                            Else
                                objOItem_Result = objLocalConfig.Globals.LState_Error
                                
                            End If

                        Else
                            objOItem_Result = objLocalConfig.Globals.LState_Error
                            

                        End If

                    Else
                        
                    End If
                Else
                    objOItem_Result = objLocalConfig.Globals.LState_Error
                    
                End If
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Error
                
            End If

        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
            
        End If

        Return objOItem_Result
    End function


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

    Public Function AddClassToTree(OItem_Class As clsOntologyItem) As clsOntologyItem

        Dim objOItem_Result As clsOntologyItem
        If Not objOList_ClassTree.Any() Then
            objOList_ClassTree.Add(objLocalConfig.Globals.Root) 
        End If

        Dim objOList_Classes = (From obj In objOList_ClassTree
                                Where obj.GUID = OItem_Class.GUID
                                Select obj).ToList

        If objOList_Classes.Any Then
            objOItem_Result = objLocalConfig.Globals.LState_Success
        Else
            Dim objOList_ClassesPar = (From obj In objOList_ClassTree
                                       Where obj.GUID_Parent = OItem_Class.GUID
                                       Select obj).ToList

            If objOList_ClassesPar.Any Then
                objOList_ClassTree.Add(OItem_Class)
                objOItem_Result = objLocalConfig.Globals.LState_Success
            Else
                Dim objOItem_ClassParent = GetClassByGuid(OItem_Class.GUID_Parent)
                If Not objOItem_ClassParent Is Nothing Then
                    objOItem_Result = AddClassToTree(objOItem_ClassParent)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objOList_ClassTree.Add(OItem_Class)
                        objOItem_Result = objLocalConfig.Globals.LState_Success
                    End If
                Else
                    objOItem_Result = objLocalConfig.Globals.LState_Error
                End If

            End If
        End If

        Return objOItem_Result
    End Function

    Public Function GetClassByGuid(GUID_Class As String) As clsOntologyItem
        Dim objOItem_Class As clsOntologyItem

        Dim objOList_Classes = New List(Of clsOntologyItem)
        objOList_Classes.Add(New clsOntologyItem With {.GUID = GUID_Class})

        Dim objOItem_Result = objDBLevel_ClassesByGuid.get_Data_Classes(objOList_Classes)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_ClassesByGuid.OList_Classes.Any Then
                objOItem_Class = objDBLevel_ClassesByGuid.OList_Classes.First
                objOItem_Class.GUID_Related = objLocalConfig.Globals.LState_Success.GUID
            Else
                objOItem_Class = Nothing
            End If
        Else
            objOItem_Class = New clsOntologyItem With {.GUID_Related = objLocalConfig.Globals.LState_Error.GUID}
        End If

        Return objOItem_Class
    End Function

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

    Public Function GetData_OntologyItemOfRef(OItem_Ref As clsOntologyItem) As clsOntologyItem
        Dim objOItem_OItem As New clsOntologyItem
        Dim objORL_OntologyItemOfRef = New List(Of clsObjectRel)
        objORL_OntologyItemOfRef.Add(New clsObjectRel With {.ID_Parent_Object = objLocalConfig.Globals.Class_OntologyItems.GUID, _
                                                             .ID_other = OItem_Ref.GUID})

        Dim objOItem_Result = objDBLevel_RefOfOntologyItem.get_Data_ObjectRel(objORL_OntologyItemOfRef, boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objOList_Refs = (From obj In objDBLevel_RefOfOntologyItem.OList_ObjectRel
                                Where obj.ID_RelationType = objLocalConfig.Globals.RelationType_belongingAttribute.GUID Or _
                                      obj.ID_RelationType = objLocalConfig.Globals.RelationType_belongingClass.GUID Or _
                                      obj.ID_RelationType = objLocalConfig.Globals.RelationType_belongingObject.GUID Or _
                                      obj.ID_RelationType = objLocalConfig.Globals.RelationType_belongingRelationType.GUID).ToList()

            If objOList_Refs.Any Then
                objOItem_OItem.GUID = objOList_Refs.First().ID_Object
                objOItem_OItem.Name = objOList_Refs.First().Name_Object
                objOItem_OItem.GUID_Parent = objOList_Refs.First().ID_Parent_Object
                objOItem_OItem.Type = objOList_Refs.First().Ontology
                objOItem_OItem.GUID_Related = objLocalConfig.Globals.LState_Success.GUID

            Else
                objOItem_OItem.GUID_Related = objLocalConfig.Globals.LState_Nothing.GUID
            End If
        Else
            objOItem_OItem.GUID_Related = objLocalConfig.Globals.LState_Error.GUID
        End If

        Return objOItem_OItem
    End Function

    Public Function GetData_OItemByGuidAndType(GUID_OItem As String, strType As String) As clsOntologyItem
        Dim objOItem_OItem As clsOntologyItem
        Dim objOList_OItem As New List(Of clsOntologyItem)


        Dim objOItem_Search As clsOntologyItem = New clsOntologyItem With {.GUID = GUID_OItem, _
                                                                           .Type = strType}
        Dim objORList_Search As New List(Of clsOntologyItem)

        objORList_Search.Add(objOItem_Search)

        Dim objOItem_Result As clsOntologyItem = objLocalConfig.Globals.LState_Error

        Select Case strType
            Case objLocalConfig.Globals.Type_AttributeType
                objOItem_Result = objDBLevel_Ref.get_Data_AttributeType(objORList_Search)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDBLevel_Ref.OList_AttributeTypes.Any Then
                        objOItem_OItem = objDBLevel_Ref.OList_AttributeTypes.First()
                        objOItem_OItem.GUID_Related = objLocalConfig.Globals.LState_Success.GUID

                    Else
                        objOItem_OItem = New clsOntologyItem
                        objOItem_OItem.GUID_Related = objLocalConfig.Globals.LState_Nothing.GUID
                    End If


                Else
                    objOItem_OItem = New clsOntologyItem
                    objOItem_OItem.GUID_Related = objLocalConfig.Globals.LState_Error.GUID
                End If
            Case objLocalConfig.Globals.Type_Class
                objOItem_Result = objDBLevel_Ref.get_Data_Classes(objORList_Search)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDBLevel_Ref.OList_Classes.Any Then
                        objOItem_OItem = objDBLevel_Ref.OList_Classes.First()
                        objOItem_OItem.GUID_Related = objLocalConfig.Globals.LState_Success.GUID

                    Else
                        objOItem_OItem = New clsOntologyItem
                        objOItem_OItem.GUID_Related = objLocalConfig.Globals.LState_Nothing.GUID
                    End If


                Else
                    objOItem_OItem = New clsOntologyItem
                    objOItem_OItem.GUID_Related = objLocalConfig.Globals.LState_Error.GUID
                End If
            Case objLocalConfig.Globals.Type_Object
                objOItem_Result = objDBLevel_Ref.get_Data_Objects(objORList_Search)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDBLevel_Ref.OList_Objects.Any Then
                        objOItem_OItem = objDBLevel_Ref.OList_Objects.First()
                        objOItem_OItem.GUID_Related = objLocalConfig.Globals.LState_Success.GUID

                    Else
                        objOItem_OItem = New clsOntologyItem
                        objOItem_OItem.GUID_Related = objLocalConfig.Globals.LState_Nothing.GUID
                    End If


                Else
                    objOItem_OItem = New clsOntologyItem
                    objOItem_OItem.GUID_Related = objLocalConfig.Globals.LState_Error.GUID
                End If
            Case objLocalConfig.Globals.Type_RelationType
                objOItem_Result = objDBLevel_Ref.get_Data_RelationTypes(objORList_Search)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDBLevel_Ref.OList_RelationTypes.Any Then
                        objOItem_OItem = objDBLevel_Ref.OList_RelationTypes.First()
                        objOItem_OItem.GUID_Related = objLocalConfig.Globals.LState_Success.GUID

                    Else
                        objOItem_OItem = New clsOntologyItem
                        objOItem_OItem.GUID_Related = objLocalConfig.Globals.LState_Nothing.GUID
                    End If


                Else
                    objOItem_OItem = New clsOntologyItem
                    objOItem_OItem.GUID_Related = objLocalConfig.Globals.LState_Error.GUID
                End If
            Case Else
                objOItem_OItem = New clsOntologyItem
                objOItem_OItem.GUID_Related = objLocalConfig.Globals.LState_Error.GUID
        End Select


        

        Return objOItem_OItem
    End Function

    Public Function Rel_OntologyJoinToOItem(OItem_Join As clsOntologyItem, OItem_OItem As clsOntologyItem, OrderID As Integer) As clsObjectRel
        Dim objORel_OntologyJoinToOitem As New clsObjectRel With {.ID_Object = OItem_Join.GUID, _
                                                                  .ID_Parent_Object = OItem_Join.GUID_Parent, _
                                                                  .ID_Other = OItem_OItem.GUID, _
                                                                  .ID_Parent_Other = OItem_OItem.GUID_Parent, _
                                                                  .OrderID = OrderID, _
                                                                  .ID_RelationType = objLocalConfig.Globals.RelationType_contains.GUID, _
                                                                  .Ontology = objLocalConfig.Globals.Type_Object}



        Return objORel_OntologyJoinToOitem
    End Function

    Public Function Rel_OntologyJoinToRule(OItem_Join As clsOntologyItem, OItem_Rule As clsOntologyItem) As clsObjectRel
        Dim objOR_OntologyJoinToRule = New clsObjectRel With {.ID_Object = OItem_Join.GUID, _
                                                              .ID_Parent_Object = OItem_Join.GUID_Parent, _
                                                              .ID_Other = OItem_Rule.GUID, _
                                                              .ID_Parent_Other = OItem_Rule.GUID_Parent, _
                                                              .OrderID = 1, _
                                                              .ID_RelationType = objLocalConfig.Globals.RelationType_belonging.GUID, _
                                                              .Ontology = objLocalConfig.Globals.Type_Object}

        Return objOR_OntologyJoinToRule
    End Function

    Public Function Rel_OntologyItemToRef(OItem_OItem As clsOntologyItem, OItem_Ref As clsOntologyItem) As clsObjectRel
        Dim GUID_RelationType As String = Nothing
        Dim objORel_OntologyItemToRef As New clsObjectRel
        Select Case OItem_Ref.Type
            Case objLocalConfig.Globals.Type_AttributeType
                GUID_RelationType = objLocalConfig.Globals.RelationType_belongingAttribute.GUID
            Case objLocalConfig.Globals.Type_Class
                GUID_RelationType = objLocalConfig.Globals.RelationType_belongingClass.GUID
            Case objLocalConfig.Globals.Type_RelationType
                GUID_RelationType = objLocalConfig.Globals.RelationType_belongingRelationType.GUID
            Case objLocalConfig.Globals.Type_Object
                GUID_RelationType = objLocalConfig.Globals.RelationType_belongingObject.GUID
        End Select

        If Not GUID_RelationType Is Nothing Then
            With objORel_OntologyItemToRef
                .ID_Object = OItem_OItem.GUID
                .ID_Parent_Object = OItem_OItem.GUID_Parent
                .ID_Other = OItem_Ref.GUID
                .ID_Parent_Other = OItem_Ref.GUID_Parent
                .OrderID = 0
                .Ontology = OItem_Ref.Type
                .ID_RelationType = GUID_RelationType
            End With
        Else
            objORel_OntologyItemToRef = Nothing
        End If
        


        Return objORel_OntologyItemToRef
    End Function

    Public Function Rel_Ontology_To_OntologyItem(OItem_Ontology As clsOntologyItem, OITem_OntologyItem As clsOntologyItem) As clsObjectRel
        Dim objORel_Ontology_To_OntologyItem = New clsObjectRel With {.ID_Object = OItem_Ontology.GUID, _
                                                                      .ID_Parent_Object = OItem_Ontology.GUID_Parent, _
                                                                      .ID_Other = OITem_OntologyItem.GUID, _
                                                                      .ID_Parent_Other = OITem_OntologyItem.GUID_Parent, _
                                                                      .OrderID = 1, _
                                                                      .Ontology = objLocalConfig.Globals.Type_Object, _
                                                                      .ID_RelationType = objLocalConfig.Globals.RelationType_contains.GUID
                                                                     }

        Return objORel_Ontology_To_OntologyItem
    End Function

    Public Function Rel_OntologyToOntologyJoin(OItem_Ontology As clsOntologyItem, OItem_OntologyJoin As clsOntologyItem) As clsObjectRel
        Dim objORel_OntologyToOntologyJoin As New clsObjectRel With {.ID_Object = OItem_Ontology.GUID,
                                                                     .ID_Parent_Object = OItem_Ontology.GUID_Parent,
                                                                     .ID_Other = OItem_OntologyJoin.GUID,
                                                                     .ID_Parent_Other = OItem_OntologyJoin.GUID_Parent,
                                                                     .Ontology = objLocalConfig.Globals.Type_Object,
                                                                     .OrderID = 1,
                                                                     .ID_RelationType = objLocalConfig.Globals.RelationType_contains.GUID
                                                                    }

        Return objORel_OntologyToOntologyJoin
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

    Public Function Get_OntologyItemOfOntology(OItem_Ontology As clsOntologyItem, OItem_Ref As clsOntologyItem) As clsOntologyItem
        Dim objOItem_OntologyItem As clsOntologyItem
        GetData_RefsOfOntologyItems()
        If objOItem_Result_OntologyItemsOfOntologies.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objORel_RefOfOntology = (From obj In OList_RefsOfOntologyItems
                                        Where obj.ID_Ref = OItem_Ref.GUID
                                        Select obj).ToList

            If (objORel_RefOfOntology.Any()) Then
                objOItem_OntologyItem = GetData_OItemByGuidAndType(objORel_RefOfOntology.First().ID_OntologyItem, objLocalConfig.Globals.Type_Object)
                objOItem_OntologyItem.GUID_Related = objLocalConfig.Globals.LState_Success.GUID

            Else
                objOItem_OntologyItem = Nothing
            End If

        Else
            objOItem_OntologyItem = New clsOntologyItem With {.GUID_Related = objLocalConfig.Globals.LState_Error.GUID}
        End If

        Return objOItem_OntologyItem
    End Function

    Public Function GetData_OntologyItemsOfJoinsExplicit(OItem_Ontology As clsOntologyItem, OItem_Left As clsOntologyItem, OItem_Right As clsOntologyItem, OItem_RelationType As clsOntologyItem) As clsOntologyItem
        Dim objOList_OItemsOfJoins = New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem
        Dim boolHierarchy As Boolean

        GetData_001_OntologyJoinsOfOntologies()
        GetData_002_OntologyItemsOfJoins()
        If objOItem_Result_OntologyItemsOfJoins.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            GetData_RefsOfOntologyItems()
            If objOItem_Result_RefsOfOntologyItems.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                Dim objOList_Join = (From objOntologyItems In objDBLevel_OntologyItemsOfJoins.OList_ObjectRel
                                     Join objOntology In objDBLevel_OntologyJoinsOfOntologies.OList_ObjectRel On objOntologyItems.ID_Object Equals objOntology.ID_Other
                                     Where objOntology.ID_Object = OItem_Ontology.GUID
                                       Join objRef In objDBLevel_RefsOfOntologyItems.OList_ObjectRel On objRef.ID_Object Equals objOntologyItems.ID_Other
                                       Where objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingAttribute.GUID Or _
                                             objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingClass.GUID Or _
                                             objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingObject.GUID Or _
                                             objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingRelationType.GUID
                                     Join objOntologies In objDBLevel_OntologyJoinsOfOntologies.OList_ObjectRel_ID On objOntologyItems.ID_Object Equals objOntologies.ID_Other
                                     Group By ID_OntologyJoin = objOntologies.ID_Other, _
                                              ID_Ref = objRef.ID_Other, _
                                              Name_Ref = objRef.Name_Other, _
                                              ID_Parent_Ref = objRef.ID_Parent_Other, _
                                              Ontology = objRef.Ontology Into Group
                                    Select New clsOntologyItem With {.GUID = ID_Ref, _
                                                                     .Name = Name_Ref, _
                                                                     .GUID_Parent = ID_Parent_Ref, _
                                                                     .GUID_Related = ID_OntologyJoin, _
                                                                     .Type = Ontology}).ToList()

                If Not OItem_Left Is Nothing And _
                    Not OItem_Right Is Nothing And _
                    Not OItem_RelationType Is Nothing Then
                    
                    If OItem_Left.GUID = OItem_Right.GUID Then
                        boolHierarchy = True

                    Else 

                        boolHierarchy = False
                        
                    End If

                    Dim objOList_Join2 = (From obj In objOList_Join
                                          Where obj.GUID = OItem_Left.GUID
                                          Select obj).ToList()
                    Dim objOList_Join3 As List(Of clsOntologyItem)

                    

                    If boolHierarchy = false Then
                        objOList_Join3 = (From obj In objOList_Join
                                          Where obj.GUID = OItem_Right.GUID
                                          Select obj).ToList()
                    End If
                    

                    Dim objOList_Join4 = (From obj In objOList_Join
                                          Where obj.GUID = OItem_RelationType.GUID
                                          Select obj).ToList()

                    Dim objOList_Join5 = (From obj1 In objOList_Join2
                                          Join obj2 In If(boolhierarchy,objOList_Join2, objOList_Join3) On obj1.GUID_Related Equals obj2.GUID_Related
                                          Join obj3 In objOList_Join4 On obj1.GUID_Related Equals obj3.GUID_Related
                                          Select obj1).ToList

                    If objOList_Join5.Any Then
                        objOItem_Result = New clsOntologyItem With {.GUID = objOList_Join5.First().GUID_Related, _
                                                                     .GUID_Parent = objLocalConfig.Globals.Class_OntologyJoin.GUID, _
                                                                     .Type = objLocalConfig.Globals.Type_Object}
                    Else
                        objOItem_Result = Nothing
                    End If

                ElseIf Not OItem_Left Is Nothing And _
                    Not OItem_RelationType Is Nothing Then

                    Dim objOList_Join2 = (From obj In objOList_Join
                                          Where obj.GUID = OItem_Left.GUID
                                          Select obj).ToList()


                    Dim objOList_Join3 = (From obj In objOList_Join
                                          Where obj.GUID = OItem_RelationType.GUID
                                          Select obj).ToList()

                    Dim objOList_Join5 = (From obj1 In objOList_Join2
                                          Join obj2 In objOList_Join3 On obj1.GUID_Related Equals obj2.GUID_Related
                                          Select obj1).ToList

                    If objOList_Join5.Any Then
                        objOItem_Result = New clsOntologyItem With {.GUID = objOList_Join5.First().GUID_Related, _
                                                                     .GUID_Parent = objLocalConfig.Globals.Class_OntologyJoin.GUID, _
                                                                     .Type = objLocalConfig.Globals.Type_Object}
                    Else
                        objOItem_Result = Nothing
                    End If
                Else
                    Dim objOList_Join2 = (From obj In objOList_Join
                                          Where obj.GUID = OItem_Left.GUID
                                          Select obj).ToList()

                    Dim objOList_Join3 = (From obj In objOList_Join
                                          Where obj.GUID = OItem_Right.GUID
                                          Select obj).ToList()


                    Dim objOList_Join5 = (From obj1 In objOList_Join2
                                          Join obj2 In objOList_Join3 On obj1.GUID_Related Equals obj2.GUID_Related
                                          Select obj1).ToList

                    If objOList_Join5.Any Then
                        objOItem_Result = New clsOntologyItem With {.GUID = objOList_Join5.First().GUID_Related, _
                                                                     .GUID_Parent = objLocalConfig.Globals.Class_OntologyJoin.GUID, _
                                                                     .Type = objLocalConfig.Globals.Type_Object}
                    Else
                        objOItem_Result = Nothing
                    End If
                End If


            Else
                objOItem_Result = objLocalConfig.Globals.LState_Error
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        Return objOItem_Result
    End Function

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
                                       Join objRef In objDBLevel_RefsOfOntologyItems.OList_ObjectRel On objRef.ID_Object Equals objOntologyItems.ID_Other _
                                       Where objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingAttribute.GUID Or _
                                             objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingClass.GUID Or _
                                             objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingObject.GUID Or _
                                             objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingRelationType.GUID
                                     Group Join objRule In objDBLevel_OntologyRelationRulesOfOItems.OList_ObjectRel On objRef.ID_Object Equals objRule.ID_Object Into objRules = Group _
                                     From objRule In objRules.DefaultIfEmpty() _
                                     Join objOntologies In objDBLevel_OntologyJoinsOfOntologies.OList_ObjectRel_ID On objOntologyItems.ID_Object Equals objOntologies.ID_Other
                                     Group By ID_Ontology = objOntologies.ID_Object, _
                                              ID_Ref = objRef.ID_Other, _
                                              Name_Ref = objRef.Name_Other, _
                                              ID_Parent_Ref = objRef.ID_Parent_Other, _
                                              Ontology = objRef.Ontology, _
                                              ID_OntologyItem = objRef.ID_Object, _
                                              Name_OntologyItem = objRef.Name_Object, _
                                              ID_Rule = If(objRule Is Nothing, Nothing, objRule.ID_Other), _
                                              Name_Rule = If(objRule Is Nothing, Nothing, objRule.Name_Other) Into Group
                                    Select New clsOntologyItemsOfOntologies With {.ID_Ontology = ID_Ontology, _
                                                                     .ID_OntologyItem = ID_OntologyItem, _
                                                                     .Name_OntologyItem = Name_OntologyItem, _
                                                                     .ID_OntologyRelationRule = ID_Rule, _
                                                                     .ID_Parent_Ref = ID_Parent_Ref, _
                                                                     .ID_Ref = ID_Ref, _
                                                                     .Name_OntologyRelationRule = Name_Rule, _
                                                                     .Name_Ref = Name_Ref, _
                                                                     .Type_Ref = Ontology}).ToList()

            Me.objOList_RefsOfOntologyItems = Me.objOList_RefsOfOntologyItems.Concat(From objOntologyItems In objDBLevel_OntologyItemsOfOntologies.OList_ObjectRel
                                       Join objRef In objDBLevel_RefsOfOntologyItems.OList_ObjectRel On objRef.ID_Object Equals objOntologyItems.ID_Other
                                       Group Join objRule In objDBLevel_OntologyRelationRulesOfOItems.OList_ObjectRel On objRef.ID_Object Equals objRule.ID_Object Into objRules = Group _
                                       From objRule In objRules.DefaultIfEmpty()
                                       Where objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingAttribute.GUID Or _
                                             objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingClass.GUID Or _
                                             objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingObject.GUID Or _
                                             objRef.ID_RelationType = objRelationTypes.OItem_RelationType_belongingRelationType.GUID
                                     Group By ID_Ontology = objOntologyItems.ID_Object, _
                                              ID_Ref = objRef.ID_Other, _
                                              Name_Ref = objRef.Name_Other, _
                                              ID_Parent_Ref = objRef.ID_Parent_Other, _
                                              Ontology = objRef.Ontology, _
                                              ID_OntologyItem = objRef.ID_Object, _
                                              Name_OntologyItem = objRef.Name_Object, _
                                              ID_Rule = If(objRule Is Nothing, Nothing, objRule.ID_Other), _
                                              Name_Rule = If(objRule Is Nothing, Nothing, objRule.Name_Other) Into Group
                                    Select New clsOntologyItemsOfOntologies With {.ID_Ontology = ID_Ontology, _
                                                                     .ID_OntologyItem = ID_OntologyItem, _
                                                                     .Name_OntologyItem = Name_OntologyItem, _
                                                                     .ID_OntologyRelationRule = ID_Rule, _
                                                                     .ID_Parent_Ref = ID_Parent_Ref, _
                                                                     .ID_Ref = ID_Ref, _
                                                                     .Name_OntologyRelationRule = Name_Rule, _
                                                                     .Name_Ref = Name_Ref, _
                                                                     .Type_Ref = Ontology}).ToList()

            objOItem_Result_RefsOfOntologyItems = objOItem_Result
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
                                 Where objOItem.OrderID = 1 Or objOItem.OrderID = 4
                                 Select New clsOntologyItem With {.GUID = objRef.ID_Other, _
                                                                  .Name = objRef.Name_Other, _
                                                                  .GUID_Parent = objRef.ID_Parent_Other, _
                                                                  .GUID_Related = objOItem.ID_Object, _
                                                                  .Type = objRef.Ontology, _
                                                                  .Level = objOItem.OrderID}).ToList()

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


            objOList_Joins = New List(Of clsOntologyJoins)((From objJoin In objDBLevel_OntologyJoinsOfOntologies.OList_ObjectRel_ID
                                                                            Join objOItem1 In OList_OItems1.Where(Function(p) p.Level = 1) On objOItem1.GUID_Related Equals objJoin.ID_Other
                                                                            group Join objOItem2 In OList_OItems2 On objOItem2.GUID_Related Equals objJoin.ID_Other Into objOItems2 = Group
                                                                            From objOItem2 In objOItems2
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

            objOList_Joins.AddRange((From objJoin In objDBLevel_OntologyJoinsOfOntologies.OList_ObjectRel_ID
                                                                            Join objOItem1 In OList_OItems1.Where(Function(p) p.Level = 4) On objOItem1.GUID_Related Equals objJoin.ID_Other
                                                                            group Join objOItem2 In OList_OItems1.Where(Function(p) p.Level = 4) On objOItem2.GUID_Related Equals objJoin.ID_Other Into objOItems2 = Group
                                                                            From objOItem2 In objOItems2
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

    Public Sub GetData_OntologyRelationRulesOfOItems()
        objOItem_OntologyRelationRulesOfOItems = objLocalConfig.Globals.LState_Nothing

        Dim objORL_OntologyRelationRulesOfOItems As New List(Of clsObjectRel)

        objORL_OntologyRelationRulesOfOItems.Add(New clsObjectRel With {.ID_Parent_Object = objLocalConfig.Globals.Class_OntologyItems.GUID,
                                                                        .ID_Parent_Other = objLocalConfig.Globals.Class_OntologyRelationRule.GUID,
                                                                        .ID_RelationType = objLocalConfig.Globals.RelationType_contains.GUID})

        objOItem_OntologyRelationRulesOfOItems = objDBLevel_OntologyRelationRulesOfOItems.get_Data_ObjectRel(objORL_OntologyRelationRulesOfOItems, boolIDs:=False)
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

    Public Function Rel_OntologyItem_To_OntologyRule(OItem_OntologyItem As clsOntologyItem, OItem_Rule As clsOntologyItem)
        Dim objOR_OntologyItem_To_OntologyRule = New clsObjectRel With {.ID_Object = OItem_OntologyItem.GUID, _
                                                                         .ID_Parent_Object = OItem_OntologyItem.GUID_Parent, _
                                                                         .ID_Other = OItem_Rule.GUID, _
                                                                         .ID_Parent_Other = OItem_Rule.GUID_Parent, _
                                                                         .OrderID = 1, _
                                                                         .Ontology = objLocalConfig.Globals.Type_Object, _
                                                                         .ID_RelationType = objLocalConfig.Globals.RelationType_contains.GUID}

        Return objOR_OntologyItem_To_OntologyRule
    End Function

    Public Function Rel_Ontology_To_Ontolgy(OItem_OntologyParent As clsOntologyItem, OItem_Ontology As clsOntologyItem)
        Dim objOR_Ontology_To_Ontology = New clsObjectRel With {.ID_Object = OItem_OntologyParent.GUID, _
                                                                .ID_Parent_Object = OItem_OntologyParent.GUID_Parent, _
                                                                .ID_Other = OItem_Ontology.GUID, _
                                                                .ID_Parent_Other = OItem_Ontology.GUID_Parent, _
                                                                .OrderID = 1, _
                                                                .Ontology = objLocalConfig.Globals.Type_Object, _
                                                                .ID_RelationType = objLocalConfig.Globals.RelationType_contains.GUID}

        Return objOR_Ontology_To_Ontology
    End Function

    Public Function Rel_Ontology_To_Ref(OItem_Ref As clsOntologyItem, OItem_Ontology As clsOntologyItem)
        Dim objOR_Ontology_To_Ref = New clsObjectRel With {.ID_Object = OItem_Ontology.GUID, _
                                                           .ID_Parent_Object = OItem_Ontology.GUID_Parent, _
                                                           .ID_Other = OItem_Ref.GUID, _
                                                           .ID_Parent_Other = OItem_Ref.GUID_Parent, _
                                                           .OrderID = 1, _
                                                           .Ontology = OItem_Ref.Type, _
                                                           .ID_RelationType = objLocalConfig.Globals.RelationType_belongingResource.GUID}

        Return objOR_Ontology_To_Ref
    End Function

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
        objOItem_OntologyRelationRulesOfOItems = objLocalConfig.Globals.LState_Nothing

        initialize()
    End Sub

    Public Sub New(Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig_Ontologies(Globals)

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
        objOItem_OntologyRelationRulesOfOItems = objLocalConfig.Globals.LState_Nothing

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
        objDBLevel_OntologyItemsOfJoinsExplicit = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_RefOfOntologyItem = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Ref = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OntologyRelationRulesOfOItems = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ClassesByGuid = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
