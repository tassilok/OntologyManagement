Imports OntologyClasses.BaseClasses
Imports OntologyClasses.DataClasses

Public Class clsDataWork_Search
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Search1 As clsDBLevel
    Private objDBLevel_Search2 As clsDBLevel
    Private objDBLevel_Search3 As clsDBLevel
    Private objDBLevel_Search4 As clsDBLevel
    Private objDBLevel_Search5 As clsDBLevel
    Private objDBLevel_Search6 As clsDBLevel
    Private objDBLevel_Search7 As clsDBLevel
    Private objDBLevel_Search8 As clsDBLevel

    Private boolAttributeTypes As Boolean
    Private boolRelationTypes As Boolean
    Private boolObjects As Boolean
    Private boolClasses As Boolean
    Private boolObjAtt As Boolean
    Private boolObjRel As Boolean

    Public ItemList As List(Of clsOntologyItem)

    Public Function Search(filter As clsFilter) As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()

        ItemList = New List(Of clsOntologyItem)

        boolAttributeTypes = False
        boolRelationTypes = False
        boolObjects = False
        boolClasses = False
        boolObjAtt = False
        boolObjRel = False

        If filter.KindOfRelation = RelationType.NoRelation Then
            Dim searchItem = New clsOntologyItem With {.GUID = filter.GUID_Left,
                                                         .Name = filter.Name_Left,
                                                         .GUID_Parent = filter.GUID_LeftParent,
                                                         .Name_Parent = filter.Name_LeftParent}
            If Not String.IsNullOrEmpty(filter.GUID_LeftParent) Or Not String.IsNullOrEmpty(filter.Name_LeftParent) Then
                If filter.GUID_LeftParent = objLocalConfig.Globals.DType_Bool.GUID Or _
                    filter.GUID_LeftParent = objLocalConfig.Globals.DType_DateTime.GUID Or _
                    filter.GUID_LeftParent = objLocalConfig.Globals.DType_Int.GUID Or _
                    filter.GUID_LeftParent = objLocalConfig.Globals.DType_Real.GUID Or _
                    filter.GUID_LeftParent = objLocalConfig.Globals.DType_String.GUID Then
                    boolAttributeTypes = True
                Else
                    boolClasses = True
                    boolObjects = True
                End If
            Else
                boolAttributeTypes = True
                boolClasses = True
                boolRelationTypes = True
                boolObjects = True
            End If

            If boolAttributeTypes = False And _
                boolClasses = False And _
                boolObjects = False Then
                boolRelationTypes = True
            End If

            If boolAttributeTypes Then
                Dim searchAttributeTypes As List(Of clsOntologyItem) = New List(Of clsOntologyItem)
                If Not String.IsNullOrEmpty(searchItem.Name_Parent) Then
                    Dim objDataTypes = New clsDataTypes()
                    Dim dataTypes = objDataTypes.DataTypes.Where(Function(dt) dt.Name.ToLower.Contains(searchItem.Name_Parent.ToLower)).ToList()
                    If dataTypes.Any() Then
                        searchAttributeTypes = dataTypes.Select(Function(dt) New clsOntologyItem With {.GUID_Parent = If(Not String.IsNullOrEmpty(searchItem.GUID), searchItem.GUID, dt.GUID),
                                                                                                           .GUID = searchItem.GUID,
                                                                                                           .Name = searchItem.Name,
                                                                                                           .Type = objLocalConfig.Globals.Type_AttributeType})
                        
                    End If
                Else
                    searchAttributeTypes = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID = searchItem.GUID,
                                                                                                         .Name = searchItem.Name,
                                                                                                         .GUID_Parent = searchItem.GUID_Parent,
                                                                                                         .Type = objLocalConfig.Globals.Type_AttributeType}}
                End If

                If searchAttributeTypes.Any() Then
                    objOItem_Result = objDBLevel_Search1.get_Data_AttributeType(searchAttributeTypes)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        ItemList.AddRange(objDBLevel_Search1.OList_AttributeTypes)
                    End If
                End If
                
            End If

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If boolRelationTypes Then
                    Dim searchRelationType = searchItem.Clone()
                    searchRelationType.Type = objLocalConfig.Globals.Type_RelationType
                    objOItem_Result = objDBLevel_Search1.get_Data_RelationTypes(New List(Of clsOntologyItem) From {searchRelationType})

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        ItemList.AddRange(objDBLevel_Search1.OList_RelationTypes)
                    End If
                End If


            End If

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If boolClasses Then
                    Dim boolParent = False
                    Dim boolItems = False
                    Dim parentClasses As List(Of clsOntologyItem) = New List(Of clsOntologyItem)
                    Dim childClasses As List(Of clsOntologyItem) = New List(Of clsOntologyItem)

                    If Not String.IsNullOrEmpty(searchItem.GUID_Parent) Or Not String.IsNullOrEmpty(searchItem.Name_Parent) Then
                        boolParent = True
                        Dim searchClasses = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID = searchItem.GUID_Parent,
                                                                                                          .Name = searchItem.Name_Parent}}
                        objOItem_Result = objDBLevel_Search2.get_Data_Classes(searchClasses)

                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            parentClasses = objDBLevel_Search2.OList_Classes
                        End If

                    End If

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        If Not String.IsNullOrEmpty(searchItem.GUID) Or Not String.IsNullOrEmpty(searchItem.Name) Then
                            boolItems = True
                            Dim searchClasses = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID = searchItem.GUID,
                                                                                                              .Name = searchItem.Name,
                                                                                                              .GUID_Parent = searchItem.GUID_Parent}}

                            objOItem_Result = objDBLevel_Search1.get_Data_Classes(searchClasses)

                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                childClasses = objDBLevel_Search1.OList_Classes
                            End If
                        End If
                    End If

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        If boolItems = False And boolParent = True Then
                            Dim searchClasses = objDBLevel_Search2.OList_Classes.Select(Function(cls) New clsOntologyItem With {.GUID_Parent = cls.GUID}).ToList()

                            If searchClasses.Any() Then
                                objOItem_Result = objDBLevel_Search1.get_Data_Classes(searchClasses)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    childClasses = objDBLevel_Search1.OList_Classes
                                End If
                            End If
                            

                        End If
                    End If

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        If boolItems = True And boolParent = False Then
                            Dim searchClasses = objDBLevel_Search1.OList_Classes.Select(Function(cls) New clsOntologyItem With {.GUID = cls.GUID_Parent}).ToList()

                            If searchClasses.Any() Then
                                objOItem_Result = objDBLevel_Search2.get_Data_Classes(searchClasses)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    parentClasses = objDBLevel_Search2.OList_Classes
                                End If
                            End If


                        End If
                    End If

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        If boolItems = False And boolParent = False Then
                            objOItem_Result = objDBLevel_Search1.get_Data_Classes()
                            childClasses = objDBLevel_Search1.OList_Classes
                            parentClasses = objDBLevel_Search1.OList_Classes
                        End If
                    End If

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        ItemList.AddRange(From objClass In childClasses
                                          Join objParentClass In parentClasses On objClass.GUID_Parent Equals objParentClass.GUID
                                          Select New clsOntologyItem With {.GUID = objClass.GUID,
                                                                           .Name = objClass.Name,
                                                                           .GUID_Parent = objClass.GUID_Parent,
                                                                           .Name_Parent = objParentClass.Name,
                                                                           .Additional1 = objDBLevel_Search3.GetClassPath(objClass),
                                                                           .Type = objLocalConfig.Globals.Type_Class})
                    End If
                End If
            End If

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If boolObjects Then
                    Dim boolParent = False
                    Dim boolItems = False
                    Dim classes As List(Of clsOntologyItem) = New List(Of clsOntologyItem)
                    Dim items As List(Of clsOntologyItem) = New List(Of clsOntologyItem)

                    If Not String.IsNullOrEmpty(searchItem.GUID) Or Not String.IsNullOrEmpty(searchItem.Name) Then
                        boolItems = True
                        Dim searchItems = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID = searchItem.GUID,
                                                                                                          .Name = searchItem.Name,
                                                                                                       .GUID_Parent = searchItem.GUID_Parent}}
                        objOItem_Result = objDBLevel_Search1.get_Data_Objects(searchItems)

                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            items = objDBLevel_Search1.OList_Objects
                        End If

                    End If

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        If Not String.IsNullOrEmpty(searchItem.GUID_Parent) Or Not String.IsNullOrEmpty(searchItem.Name_Parent) Then
                            boolParent = True
                            Dim searchClasses = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID = searchItem.GUID_Parent,
                                                                                                              .Name = searchItem.Name_Parent}}

                            objOItem_Result = objDBLevel_Search2.get_Data_Classes(searchClasses)

                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                classes = objDBLevel_Search2.OList_Classes
                            End If
                        End If
                    End If

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        If boolItems = True And boolParent = False Then
                            Dim searchClasses = items.GroupBy(Function(obj) obj.GUID_Parent).Select(Function(obj) New clsOntologyItem With {.GUID = obj.Key}).ToList()

                            If searchClasses.Any() Then
                                objOItem_Result = objDBLevel_Search2.get_Data_Classes(searchClasses)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    classes = objDBLevel_Search2.OList_Classes
                                End If
                            End If
                        End If
                    End If

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        If boolItems = False And boolParent = True Then
                            Dim searchObjects = classes.Select(Function(cls) New clsOntologyItem With {.GUID_Parent = cls.GUID}).ToList()
                            If searchObjects.Any() Then
                                objOItem_Result = objDBLevel_Search1.get_Data_Objects(searchObjects)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    items = objDBLevel_Search1.OList_Objects
                                End If
                            End If
                        End If
                    End If

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        classes.ForEach(Sub(cls)
                                            cls.Additional1 = objDBLevel_Search3.GetClassPath(cls)
                                        End Sub)

                        ItemList.AddRange(From objObject In items
                                          Join objClass In classes On objObject.GUID_Parent Equals objClass.GUID
                                          Select New clsOntologyItem With {.GUID = objObject.GUID,
                                                                           .Name = objObject.Name,
                                                                           .GUID_Parent = objObject.GUID_Parent,
                                                                           .Name_Parent = objClass.Name,
                                                                           .Additional1 = objClass.Additional1,
                                                                           .Type = objLocalConfig.Globals.Type_Object})
                    End If
                End If
            End If


        ElseIf filter.KindOfRelation = RelationType.LeftRight Then

        ElseIf filter.KindOfRelation = RelationType.RightLeft Then

        End If

        Return objOItem_Result
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objDBLevel_Search1 = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Search2 = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Search3 = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Search4 = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Search5 = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Search6 = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Search7 = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Search8 = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
