﻿Imports OntologyClasses.BaseClasses

Public Class clsOntologyWork
    Private objLocalConfig As clsLocalConfig

    Private objOList As New List(Of clsOntologyItem)
    Private objOList_Join As New List(Of clsObjectRel)

    Private objDBLevel As clsDBLevel
    Private objDBLevel_Joins As clsDBLevel
    Private objDBLevel_OItems As clsDBLevel
    Private objDBLevel_Joins_OItems As clsDBLevel
    Private objDBLevel_ORule As clsDBLevel
    Private objDBLevel_Attributes As clsDBLevel
    Private objDBLevel_RelTypes As clsDBLevel
    Private objDBLevel_Classes As clsDBLevel
    Private objDBLevel_Objects As clsDBLevel
    Private objDBLevel_OntologyOfRef As clsDBLevel

    Public ReadOnly Property OList As List(Of clsOntologyItem)
        Get
            Return objOList
        End Get
    End Property

    Public ReadOnly Property OList_JOin As List(Of clsObjectRel)
        Get
            Return objOList_Join
        End Get
    End Property

    Public Function Get_OntologyOfRef(OItem_Ref As clsOntologyItem) As List(Of clsOntologyItem)
        Dim objORelS_OntologOfRef = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Other = OItem_Ref.GUID,
                                                                                             .ID_RelationType = objLocalConfig.Globals.RelationType_belongingResource.GUID,
                                                                                             .ID_Parent_Object = objLocalConfig.Globals.Class_Ontologies.GUID}}

        Dim objOItem_Result = objDBLevel_OntologyOfRef.get_Data_ObjectRel(objORelS_OntologOfRef, boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Return objDBLevel_OntologyOfRef.OList_ObjectRel.Select(Function(o) New clsOntologyItem With {.GUID = o.ID_Object, _
                                                                                                         .Name = o.Name_Object, _
                                                                                                         .GUID_Parent = o.ID_Parent_Object, _
                                                                                                         .Type = objLocalConfig.Globals.Type_Object}).ToList()

        Else
            Return Nothing
        End If

    End Function

    Public Function get_OntologyJoins(ByVal OItem_Ontology As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Ont_Ont As New List(Of clsObjectRel)
        Dim objOList_Ont_Joins As New List(Of clsObjectRel)
        Dim objOList_Joins_Ont As New List(Of clsObjectRel)
        Dim objOList_Joins_Rule As New List(Of clsObjectRel)
        Dim objOList_Ont_AttTypes As New List(Of clsObjectRel)
        Dim objOList_Ont_RelTypes As New List(Of clsObjectRel)
        Dim objOList_Ont_Classes As New List(Of clsObjectRel)
        Dim objOList_Ont_Objects As New List(Of clsObjectRel)
        Dim objOList_Ontologies As New List(Of clsOntologyItem)
        Dim objORel_Join As clsObjectRel

        objOList_Join.Clear()

        objOList_Ont_AttTypes.Add(New clsObjectRel with { 
                                                          .ID_Parent_Object = objLocalConfig.Globals.Class_OntologyItems.GUID, _
                                                          .ID_RelationType = objLocalConfig.Globals.RelationType_belongingAttribute.GUID, _
                                                          .Ontology = objLocalConfig.Globals.Type_AttributeType
                                                         })

        objDBLevel_Attributes.get_Data_ObjectRel(objOList_Ont_AttTypes, _
                                                 boolIDs:=False)

        objOList_Ont_RelTypes.Add(New clsObjectRel With { 
                                                          .ID_Parent_Object = objLocalConfig.Globals.Class_OntologyItems.GUID, _
                                                          .ID_RelationType = objLocalConfig.Globals.RelationType_belongingRelationType.GUID, _
                                                          .Ontology = objLocalConfig.Globals.Type_RelationType
                                                        })

        objDBLevel_RelTypes.get_Data_ObjectRel(objOList_Ont_RelTypes, _
                                                 boolIDs:=False)

        objOList_Ont_Classes.Add(New clsObjectRel With {
                                                        .ID_Parent_Object = objLocalConfig.Globals.Class_OntologyItems.GUID, _
                                                        .ID_RelationType = objLocalConfig.Globals.RelationType_belongingClass.GUID, _
                                                       .Ontology = objLocalConfig.Globals.Type_Class
                                                       })

        objDBLevel_Classes.get_Data_ObjectRel(objOList_Ont_Classes, _
                                                 boolIDs:=False)

        objOList_Ont_Objects.Add(New clsObjectRel With {
                                                        .ID_Parent_Object = objLocalConfig.Globals.Class_OntologyItems.GUID, _
                                                        .ID_RelationType = objLocalConfig.Globals.RelationType_belongingObject.GUID, _
                                                        .Ontology = objLocalConfig.Globals.Type_Object
                                                       })

        objDBLevel_Objects.get_Data_ObjectRel(objOList_Ont_Objects, _
                                                 boolIDs:=False)

        objOItem_Result = objLocalConfig.Globals.LState_Error

        If objDBLevel_Attributes.OList_ObjectRel.Count > 0 Or _
            objDBLevel_RelTypes.OList_ObjectRel.Count > 0 Or _
            objDBLevel_Classes.OList_ObjectRel.Count > 0 Or _
            objDBLevel_Objects.OList_ObjectRel.Count > 0 Then
            objOList_Ont_Ont.Add(New clsObjectRel With {.ID_Object = OItem_Ontology.GUID, _
                                                        .ID_Parent_Object = OItem_Ontology.GUID_Parent, _
                                                        .ID_Parent_Other = objLocalConfig.Globals.Class_Ontologies.GUID, _
                                                        .ID_RelationType = objLocalConfig.Globals.RelationType_contains.GUID, _
                                                        .Ontology = objLocalConfig.Globals.Type_Object
                                                       })

            objDBLevel_OItems.get_Data_ObjectRel(objOList_Ont_Ont)

            If objDBLevel_OItems.OList_ObjectRel_ID.Count > 0 Then
                objOList_Ont_Joins.Add(New clsObjectRel With { 
                                                               .ID_Parent_Object = objLocalConfig.Globals.Class_Ontologies.GUID, _
                                                               .ID_Parent_Other = objLocalConfig.Globals.Class_OntologyJoin.GUID, _
                                                               .ID_RelationType = objLocalConfig.Globals.RelationType_contains.GUID, _
                                                               .Ontology = objLocalConfig.Globals.Type_Object
                                                             })


                objDBLevel_Joins.get_Data_ObjectRel(objOList_Ont_Joins)

                If objDBLevel_Joins.OList_ObjectRel_ID.Count > 0 Then
                    objOList_Joins_Rule.Add(New clsObjectRel  With {
                                                                    .ID_Parent_Object = objLocalConfig.Globals.Class_OntologyJoin.GUID, _
                                                                    .ID_Parent_Other = objLocalConfig.Globals.Class_OntologyRelationRule.GUID, _
                                                                    .ID_RelationType = objLocalConfig.Globals.RelationType_belonging.GUID, _
                                                                    .Ontology = objLocalConfig.Globals.Type_Object
                                                                   })

                    objDBLevel_ORule.get_Data_ObjectRel(objOList_Joins_Rule)

                    If objDBLevel_ORule.OList_ObjectRel_ID.Count > 0 Then
                        Dim objLJoins = (From objJoin In objDBLevel_Joins.OList_ObjectRel_ID
                                        Join objItem In objDBLevel_OItems.OList_ObjectRel_ID On objItem.ID_Other Equals objJoin.ID_Object).ToList()

                        For Each objJoin In objLJoins
                            objOList_Joins_Ont.Clear()

                            objOList_Joins_Ont.Add(New clsObjectRel With { 
                                                                           .ID_Object = objJoin.objJoin.ID_Other, _
                                                                           .ID_Parent_Other = objLocalConfig.Globals.Class_OntologyItems.GUID, _
                                                                           .ID_RelationType = objLocalConfig.Globals.RelationType_contains.GUID, _
                                                                           .Ontology =  objLocalConfig.Globals.Type_Object
                                                                         })

                            objDBLevel_Joins_OItems.get_Data_ObjectRel(objOList_Joins_Ont)

                            If objDBLevel_Joins_OItems.OList_ObjectRel_ID.Count > 0 Then
                                Dim objL = (From objOJoin In objDBLevel_Joins_OItems.OList_ObjectRel_ID
                                           Group Join objAttTyp In objDBLevel_Attributes.OList_ObjectRel On objOJoin.ID_Other Equals objAttTyp.ID_Object Into RightAtt = Group
                                           From objAttTyp In RightAtt.DefaultIfEmpty
                                           Group Join objRelTyp In objDBLevel_RelTypes.OList_ObjectRel On objOJoin.ID_Other Equals objRelTyp.ID_Object Into RightRel = Group
                                           From objRelTyp In RightRel.DefaultIfEmpty
                                           Group Join objClass In objDBLevel_Classes.OList_ObjectRel On objOJoin.ID_Other Equals objClass.ID_Object Into RightClass = Group
                                           From objClass In RightClass.DefaultIfEmpty
                                           Group Join objObj In objDBLevel_Objects.OList_ObjectRel On objOJoin.ID_Other Equals objObj.ID_Object Into RightObject = Group
                                           From objObj In RightObject.DefaultIfEmpty
                                           Order By objOJoin.OrderID).ToList()


                                If objL.Count > 0 Then
                                    If objL.Count = 2 Then
                                        If objL(0).objOJoin.OrderID = 1 Then
                                            Dim objClass = objL(0)
                                            Dim objRelOrAtt = objL(1)
                                            If objRelOrAtt.objRelTyp Is Nothing Then
                                                objOList_Join.Add(New clsObjectRel With {
                                                                               .ID_Parent_Object = objClass.objClass.ID_Other, _
                                                                               .Name_Parent_Object = objClass.objClass.Name_Other, _
                                                                               .ID_Other = objRelOrAtt.objAttTyp.ID_Other, _
                                                                               .Name_Other = objRelOrAtt.objAttTyp.Name_Other, _
                                                                               .Ontology = objLocalConfig.Globals.Type_ClassAtt
                                                                               })
                                            Else
                                                If objClass.objObj Is Nothing Then
                                                    objOList_Join.Add(New clsObjectRel With {
                                                                               .ID_Parent_Object = objClass.objClass.ID_Other, _
                                                                               .Name_Parent_Object = objClass.objClass.Name_Other, _
                                                                               .ID_RelationType = objRelOrAtt.objRelTyp.ID_Other, _
                                                                               .Name_RelationType = objRelOrAtt.objRelTyp.Name_Other, _
                                                                               .Ontology = objLocalConfig.Globals.Type_ClassRel
                                                                                            })
                                                Else
                                                    If objClass.objObj.OrderID = 4 Then
                                                        objOList_Join.Add(New clsObjectRel With {
                                                                               .ID_Parent_Object = objClass.objClass.ID_Other, _
                                                                               .Name_Parent_Object = objClass.objClass.Name_Other, _
                                                                               .ID_Parent_Other = objClass.objClass.ID_Other, _
                                                                               .Name_Parent_Other = objClass.objClass.Name_Other, _
                                                                               .ID_RelationType = objRelOrAtt.objRelTyp.ID_Other, _
                                                                               .Name_RelationType = objRelOrAtt.objRelTyp.Name_Other, _
                                                                               .Ontology = objLocalConfig.Globals.Type_ClassRel
                                                                                                })
                                                    End If
                                                
                                                End If
                                            
                                            End If
                                        Else 
                                            Dim objClass_Left = objL(1)
                                            Dim objClass_Right = objL(1)
                                            Dim objRelType = objL(0)
                                            objOList_Join.Add(New clsObjectRel With {
                                                                           .ID_Parent_Object =  objClass_Left.objClass.ID_Other, _
                                                                           .Name_Parent_Object = objClass_Left.objClass.Name_Other, _
                                                                           .ID_Parent_Other = objClass_Right.objClass.ID_Other, _
                                                                           .Name_Parent_Other = objClass_Right.objClass.Name_Other, _
                                                                           .ID_RelationType = objRelType.objRelTyp.ID_Other, _
                                                                           .Name_RelationType = objRelType.objRelTyp.Name_Other, _
                                                                           .Ontology = objLocalConfig.Globals.Type_ClassRel
                                                                                })
                                        End If
                                        
                                        

                                        
                                        


                                    ElseIf objL.Count = 3 Then
                                        Dim objClass_Left = objL(0)
                                        Dim objClass_Right = objL(1)
                                        Dim objRelType = objL(2)

                                        objOList_Join.Add(New clsObjectRel With {
                                                                           .ID_Parent_Object =  objClass_Left.objClass.ID_Other, _
                                                                           .Name_Parent_Object = objClass_Left.objClass.Name_Other, _
                                                                           .ID_Parent_Other = objClass_Right.objClass.ID_Other, _
                                                                           .Name_Parent_Other = objClass_Right.objClass.Name_Other, _
                                                                           .ID_RelationType = objRelType.objRelTyp.ID_Other, _
                                                                           .Name_RelationType = objRelType.objRelTyp.Name_Other, _
                                                                           .Ontology = objLocalConfig.Globals.Type_ClassRel
                                                                                })

                                    End If
                                End If

                            End If
                        Next


                    End If

                End If

            End If
        End If


        If objOList_Join.Count > 0 Then
            objOItem_Result = objLocalConfig.Globals.LState_Success
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Nothing
        End If

        Return objOItem_Result
    End Function
    Public Function get_Ontologies(ByVal OItem_Ontology As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Ontologies As New List(Of clsOntologyItem)
        Dim objOList_ObjRel As New List(Of clsObjectRel)
        Dim objOList_ObjRel2 As New List(Of clsObjectRel)
        Dim objOList_ObjRel3 As New List(Of clsObjectRel)
        Dim objOList_ObjRel4 As New List(Of clsObjectRel)
        Dim objORel_Item As clsObjectRel
        Dim i As Integer

        objOList_ObjRel.Add(New clsObjectRel(OItem_Ontology.GUID, _
                                             Nothing, _
                                             OItem_Ontology.GUID_Parent, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             objLocalConfig.Globals.Class_Ontologies.GUID, _
                                             Nothing, _
                                             objLocalConfig.Globals.RelationType_contains.GUID, _
                                             Nothing, _
                                             objLocalConfig.Globals.Type_Object, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing))


        objDBLevel.get_Data_ObjectRel(objOList_ObjRel, False, True)

        If objDBLevel.OList_ObjectRel_ID.Count > 0 Then
            objOList_Ontologies.Add(OItem_Ontology)

            objOList_Ontologies = objOList_Ontologies.Concat((From obj In objDBLevel.OList_ObjectRel_ID
                        Group By obj.ID_Other Into Group
                        Select New clsOntologyItem(ID_Other, objLocalConfig.Globals.Type_Object)).ToList())

            objOList_ObjRel.Clear()
            objOList_ObjRel = (From objOItem In objOList_Ontologies
                               Select New clsObjectRel(objOItem.GUID, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.Class_OntologyItems.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.RelationType_contains.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.Type_Object, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing))

            objDBLevel.get_Data_ObjectRel(objOList_ObjRel, False)

            objOList_ObjRel.Clear()
            objOList_ObjRel2.Clear()
            objOList_ObjRel3.Clear()
            objOList_ObjRel4.Clear()

            objOList_ObjRel = (From objOrel In objDBLevel.OList_ObjectRel_ID
                               Select New clsObjectRel(objOrel.ID_Other, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.RelationType_belongingAttribute.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.Type_AttributeType, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing))

            objOList_ObjRel2 = (From objOrel In objDBLevel.OList_ObjectRel_ID
                               Select New clsObjectRel(objOrel.ID_Other, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.RelationType_belongingRelationType.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.Type_RelationType, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing))

            objOList_ObjRel3 = (From objOrel In objDBLevel.OList_ObjectRel_ID
                               Select New clsObjectRel(objOrel.ID_Other, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.RelationType_belongingClass.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.Type_Class, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing))

            objOList_ObjRel4 = (From objOrel In objDBLevel.OList_ObjectRel_ID
                               Select New clsObjectRel(objOrel.ID_Other, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.RelationType_belongingObject.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.Type_Object, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing))

            
            objDBLevel_Attributes.get_Data_ObjectRel(objOList_ObjRel, False, False)

            objDBLevel_Classes.get_Data_ObjectRel(objOList_ObjRel3, False, False)

            objDBLevel_Objects.get_Data_ObjectRel(objOList_ObjRel4, False, False)

            objDBLevel_RelTypes.get_Data_ObjectRel(objOList_ObjRel2, False, False)

            
            objOItem_Result = objLocalConfig.Globals.LState_Nothing

            If objDBLevel_Attributes.OList_ObjectRel.Count > 0 Then
                objOItem_Result = objLocalConfig.Globals.LState_Success
            End If

            objOList = (From objOItem In objDBLevel_Attributes.OList_ObjectRel
                        Select New clsOntologyItem(objOItem.ID_Other, _
                             objOItem.Name_Other, _
                             objOItem.ID_Parent_Other, _
                             objOItem.Ontology)).ToList()

            If objDBLevel_Classes.OList_ObjectRel.Count > 0 Then
                objOItem_Result = objLocalConfig.Globals.LState_Success
            End If

            objOList = objOList.Concat((From objOItem In objDBLevel_Classes.OList_ObjectRel
                        Select New clsOntologyItem(objOItem.ID_Other, _
                             objOItem.Name_Other, _
                             objOItem.ID_Parent_Other, _
                             objOItem.Ontology)).ToList())


            If objDBLevel_Objects.OList_ObjectRel.Count > 0 Then
                objOItem_Result = objLocalConfig.Globals.LState_Success
            End If

            objOList = objOList.Concat((From objOItem In objDBLevel_Objects.OList_ObjectRel
                        Select New clsOntologyItem(objOItem.ID_Other, _
                             objOItem.Name_Other, _
                             objOItem.ID_Parent_Other, _
                             objOItem.Ontology)).ToList())

            
            If objDBLevel_RelTypes.OList_ObjectRel.Count > 0 Then
                objOItem_Result = objLocalConfig.Globals.LState_Success
            End If

            objOList = objOList.Concat((From objOItem In objDBLevel_RelTypes.OList_ObjectRel
                        Select New clsOntologyItem(objOItem.ID_Other, _
                             objOItem.Name_Other, _
                             objOItem.ID_Parent_Other, _
                             objOItem.Ontology)).ToList())

        Else
            objOItem_Result = objLocalConfig.Globals.LState_Nothing
        End If




        Return objOItem_Result
    End Function

    Public Sub New(ByVal Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)

        set_DBConnection()
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Attributes = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_RelTypes = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Classes = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Objects = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Joins = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OItems = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ORule = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Joins_OItems = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OntologyOfRef = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
