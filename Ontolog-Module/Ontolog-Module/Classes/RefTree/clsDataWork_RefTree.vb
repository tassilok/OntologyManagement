Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports System.Threading



Public Class clsDataWork_RefTree

    Private Const cintImageID_Root As Integer = 0
    Private Const cintImageID_Closed As Integer = 1
    Private Const cintImageID_Opened As Integer = 2
    Private Const cintImageID_AttributeTypes As Integer = 3
    Private Const cintImageID_AttributeType As Integer = 4
    Private Const cintImageID_RelationTypes As Integer = 5
    Private Const cintImageID_RelationType As Integer = 6
    Private Const cintImageID_Object As Integer = 7

    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Ref As clsDBLevel
    Private objDBLevel_RefToItem As clsDBLevel
    Private objDBLevel_Classes As clsDBLevel
    Private objDBLevel_ClassesOfObjects As clsDBLevel
    Private objDBLevel_Objects As clsDBLevel

    Private objOItem_Result_Ref As clsOntologyItem
    Private objOItem_Result_Classes As clsOntologyItem

    Private objThread_Ref As Thread
    Private objThread_Classes As Thread

    Private objOList_ClassesIn As List(Of clsOntologyItem)
    Private objOList_RelationTypes_LeftRight As List(Of clsOntologyItem)
    Private objOList_RelationTypes_RightLeft As List(Of clsOntologyItem)
    Private objOList_Rels As List(Of clsObjectRel)
    Private objOList_Classes As List(Of clsOntologyItem)
    Private objOList_Objects As List(Of clsOntologyItem)
    Private objOList_AttributeTypes As List(Of clsOntologyItem)
    Private objOList_RelationTypes As List(Of clsOntologyItem)
    Public Property OList_FilterRefs As List(Of clsOntologyItem)

    Public ReadOnly Property ImageID_Root As Integer
        Get
            Return cintImageID_Root
        End Get
    End Property

    Public ReadOnly Property ImageID_Closed As Integer
        Get
            Return cintImageID_Closed
        End Get
    End Property

    Public ReadOnly Property ImageID_Opened As Integer
        Get
            Return cintImageID_Opened
        End Get
    End Property

    Public ReadOnly Property ImageID_AttributeTypes As Integer
        Get
            Return cintImageID_AttributeTypes
        End Get
    End Property

    Public ReadOnly Property ImageID_AttributeType As Integer
        Get
            Return cintImageID_AttributeType
        End Get
    End Property

    Public ReadOnly Property ImageID_RelationTypes As Integer
        Get
            Return cintImageID_RelationTypes
        End Get
    End Property

    Public ReadOnly Property ImageID_RelationType As Integer
        Get
            Return cintImageID_RelationType
        End Get
    End Property

    Public ReadOnly Property ImageID_Object As Integer
        Get
            Return cintImageID_Object
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

    Public ReadOnly Property OList_Ref As List(Of clsObjectRel)
        Get
            Return objOList_Rels
        End Get
    End Property

    Public Function HasFinished() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_Result = If(objOItem_Result_Ref.GUID = objLocalConfig.Globals.LState_Success.GUID And _
                             objOItem_Result_Classes.GUID = objLocalConfig.Globals.LState_Success.GUID, objLocalConfig.Globals.LState_Success.Clone, _
                             If(objOItem_Result_Ref.GUID = objLocalConfig.Globals.LState_Error.GUID Or
                                 objOItem_Result_Classes.GUID = objLocalConfig.Globals.LState_Error.GUID, objLocalConfig.Globals.LState_Error, objLocalConfig.Globals.LState_Nothing))

        Return objOItem_Result
    End Function

    Public Function GetObjectOfGUID(strGUID_Object As String) As clsOntologyItem
        Dim objOList_Objects = New List(Of clsOntologyItem)
        Dim objOItem_Object As clsOntologyItem = Nothing

        objOList_Objects.Add(New clsOntologyItem With {.GUID = strGUID_Object})

        Dim objOItem_Result = objDBLevel_Objects.get_Data_Objects(objOList_Objects)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Objects.OList_Objects.Any Then
                objOItem_Object = objDBLevel_Objects.OList_Objects.First()
            End If
        End If

        Return objOItem_Object
    End Function

    Public Function GetClassOfGUID(strGUID_Class As String) As clsOntologyItem
        Dim objOList_Classes = New List(Of clsOntologyItem)
        Dim objOItem_Class As clsOntologyItem = Nothing

        objOList_Classes.Add(New clsOntologyItem With {.GUID = strGUID_Class})

        Dim objOItem_Result = objDBLevel_Objects.get_Data_Classes(objOList_Classes)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Objects.OList_Classes.Any Then
                objOItem_Class = objDBLevel_Objects.OList_Classes.First()
            End If
        End If

        Return objOItem_Class
    End Function

    Public Function GetClassParents(OItem_Class As clsOntologyItem) As List(Of clsOntologyItem)
        Dim objOList_ParentClasses = New List(Of clsOntologyItem)
        Dim intCount As Integer = 0

        objOList_ParentClasses.Add(OItem_Class)

        Do
            intCount = objOList_ParentClasses.Count

            Dim objOList_Parents = (From objClassParent In objDBLevel_Classes.OList_Classes
                                             Join objClass In objOList_ParentClasses On objClassParent.GUID Equals objClass.GUID_Parent
                                             Select objClassParent).ToList()


            objOList_ParentClasses.AddRange(From objClassParent In objOList_Parents
                                            Group Join objClass In objOList_ParentClasses On objClass.GUID Equals objClassParent.GUID Into objClasses = Group
                                            From objClass In objClasses.DefaultIfEmpty()
                                            Where objClass Is Nothing
                                            Select objClassParent)


        Loop Until (objOList_ParentClasses.Count - intCount) = 0

        Return objOList_ParentClasses

    End Function

    Public Function Get_Tree() As clsOntologyItem
        Dim intClassCount As Integer
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone

        If objOItem_Result_Classes.GUID = objLocalConfig.Globals.LState_Success.GUID And
            objOItem_Result_Ref.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOItem_Result = GetClasses()
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                Do
                    intClassCount = objOList_Classes.Count

                    Dim objOList_ClassParents = (From objClass In objOList_Classes
                                               Join objClassParent In objDBLevel_Classes.OList_Classes On objClass.GUID_Parent Equals objClassParent.GUID
                                                Select objClassParent).ToList()
                    objOList_Classes.AddRange(From objClassParent In objOList_ClassParents
                                              Group Join objClass In objOList_Classes On objClass.GUID Equals objClassParent.GUID Into objClassesOld = Group
                                              From objClass In objClassesOld.DefaultIfEmpty()
                                              Where objClass Is Nothing
                                              Select objClassParent)

                Loop Until objOList_Classes.Count - intClassCount = 0
                objOList_Classes.Sort(Function(LS1 As clsOntologyItem, LS2 As clsOntologyItem) LS1.Name.CompareTo(LS2.Name))

                objOList_AttributeTypes = objOList_Rels.Where(Function(p) p.Ontology = objLocalConfig.Globals.Type_AttributeType). _
                                                                               Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Other,
                                                                                                                            .Name = p.Name_Other, _
                                                                                                                            .GUID_Parent = p.ID_Parent_Other, _
                                                                                                                            .Type = p.Ontology}).ToList()

                objOList_AttributeTypes.Sort(Function(LS1 As clsOntologyItem, LS2 As clsOntologyItem) LS1.Name.CompareTo(LS2.Name))

                objOList_Objects = objOList_Rels.Where(Function(p) p.Ontology = objLocalConfig.Globals.Type_Object). _
                                                                               Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Other,
                                                                                                                            .Name = p.Name_Other, _
                                                                                                                            .GUID_Parent = p.ID_Parent_Other, _
                                                                                                                            .Type = p.Ontology}).ToList()
                objOList_Objects.Sort(Function(LS1 As clsOntologyItem, LS2 As clsOntologyItem) LS1.Name.CompareTo(LS2.Name))

                objOList_RelationTypes = objOList_Rels.Where(Function(p) p.Ontology = objLocalConfig.Globals.Type_RelationType). _
                                                                               Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Other,
                                                                                                                            .Name = p.Name_Other, _
                                                                                                                            .GUID_Parent = p.ID_Parent_Other, _
                                                                                                                            .Type = p.Ontology}).ToList()
                objOList_RelationTypes.Sort(Function(LS1 As clsOntologyItem, LS2 As clsOntologyItem) LS1.Name.CompareTo(LS2.Name))
            End If


        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone
        End If



        Return objOItem_Result
    End Function

    Public Function GetClasses() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem = objLocalConfig.Globals.LState_Success.Clone

        If objOItem_Result_Classes.GUID = objLocalConfig.Globals.LState_Success.GUID And
            objOItem_Result_Ref.GUID = objLocalConfig.Globals.LState_Success.GUID Then

            objOList_Classes = objOList_Rels.Where(Function(p) p.Ontology = objLocalConfig.Globals.Type_Class).GroupBy(Function(p) New With {p.ID_Other, p.Name_Other, p.ID_Parent_Other, p.Ontology}). _
                                Select(Function(p) New clsOntologyItem With {.GUID = p.Key.ID_Other, _
                                                                            .Name = p.Key.Name_Other, _
                                                                            .GUID_Parent = p.Key.ID_Parent_Other, _
                                                                            .Type = p.Key.Ontology,
                                                                                .Mark = True}).tolist()

            Dim objOList_ClassesOfObjects = objOList_Rels.Where(Function(p) p.Ontology = objLocalConfig.Globals.Type_Object).GroupBy(Function(p) p.ID_Parent_Other).Select(Function(p) New clsOntologyItem With {.GUID = p.Key, _
                                                                                                                                                                             .Type = objLocalConfig.Globals.Type_Class, _
                                                                                                                                                                                                                                      .Mark = True}). _
                                                                                                                                                                            GroupBy(Function(p) New With {p.GUID, p.Type, p.Mark}).Select(Function(p) New clsOntologyItem With {.GUID = p.Key.GUID, _
                                                                                                                                                                                                                                                                                .Type = p.Key.Type, _
                                                                                                                                                                                                                                                                                .Mark = p.Key.Mark}).ToList()

            objOList_ClassesOfObjects = (From objClassNew In objOList_ClassesOfObjects
                                        Group Join objClassOld In objOList_Classes On objClassNew.GUID Equals objClassOld.GUID Into objCalssesOld = Group
                                        From objClassOld In objCalssesOld.DefaultIfEmpty()
                                        Where objClassOld Is Nothing
                                        Select objClassNew).ToList()

            If objOList_ClassesOfObjects.Any() Then
                objOItem_Result = objDBLevel_ClassesOfObjects.get_Data_Classes(objOList_ClassesOfObjects)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOList_Classes.AddRange(objDBLevel_ClassesOfObjects.OList_Classes.GroupBy(Function(p) New With {p.GUID, p.GUID_Parent, p.Name, p.Type, p.Mark}).Select(Function(p) New clsOntologyItem With {.GUID = p.Key.GUID, _
                                                                                                                                                                                                                    .Name = p.Key.Name, _
                                                                                                                                                                                                                    .GUID_Parent = p.Key.GUID_Parent, _
                                                                                                                                                                                                                    .Type = p.Key.Type, _
                                                                                                                                                                                                                    .Mark = p.Key.Mark}))
                End If
            End If

        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone
        End If

        Return objOItem_Result
    End Function

    Public Sub GetData_Classes()

        objOItem_Result_Classes = objDBLevel_Classes.get_Data_Classes(Nothing)

    End Sub

    Public Function GetData(Optional boolAsynchronous As Boolean = False) As clsOntologyItem

        objOItem_Result_Ref = objLocalConfig.Globals.LState_Success.Clone()
        objOItem_Result_Classes = objLocalConfig.Globals.LState_Success.Clone()

        Try
            objThread_Ref.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_Classes.Abort()
        Catch ex As Exception

        End Try

        objThread_Ref = New Thread(AddressOf GetData_Ref)
        objThread_Classes = New Thread(AddressOf GetData_Classes)

        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()
        If boolAsynchronous Then
            objThread_Ref.Start()
            objThread_Classes.Start()
        Else
            GetData_Ref()
            objOItem_Result = objOItem_Result_Ref
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                GetData_Classes()
                objOItem_Result = objOItem_Result_Classes
            End If
        End If

        Return objOItem_Result
    End Function

    Public Sub GetData_Ref()
        objOItem_Result_Ref = objLocalConfig.Globals.LState_Nothing.Clone()

        Dim objOLRel_ItemToRef As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem


        objOLRel_ItemToRef.AddRange(From objClass In objOList_ClassesIn
                                    From objRelationType In objOList_RelationTypes_LeftRight
                                    Select New clsObjectRel With {.ID_Parent_Object = objClass.GUID, _
                                                                  .ID_RelationType = objRelationType.GUID})

        objOItem_Result = objDBLevel_Ref.get_Data_ObjectRel(objOLRel_ItemToRef, boolIDs:=False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If OList_FilterRefs.Any() Then
                objOList_Rels = (From objRel In objDBLevel_Ref.OList_ObjectRel.Select(Function(p) New clsObjectRel With {.ID_Object = p.ID_Object, _
                                                                                                     .Name_Object = p.Name_Object, _
                                                                                                     .ID_Parent_Object = p.ID_Parent_Object, _
                                                                                                     .Name_Parent_Object = p.Name_Parent_Object, _
                                                                                                     .ID_Other = p.ID_Other, _
                                                                                                     .Name_Other = p.Name_Other, _
                                                                                                     .ID_Parent_Other = p.ID_Parent_Other, _
                                                                                                     .Name_Parent_Other = p.Name_Parent_Other, _
                                                                                                     .ID_RelationType = p.ID_RelationType, _
                                                                                                     .Name_RelationType = p.Name_RelationType, _
                                                                                                     .Ontology = p.Ontology, _
                                                                                                     .OrderID = p.OrderID, _
                                                                                                     .ID_Direction = objLocalConfig.Globals.Direction_LeftRight.GUID
                                                                                                    }).ToList()
                                Join objFilterRel In OList_FilterRefs On objRel.ID_Object Equals objFilterRel.GUID
                                Select objRel).ToList()
            Else
                objOList_Rels = objDBLevel_Ref.OList_ObjectRel.Select(Function(p) New clsObjectRel With {.ID_Object = p.ID_Object, _
                                                                                                     .Name_Object = p.Name_Object, _
                                                                                                     .ID_Parent_Object = p.ID_Parent_Object, _
                                                                                                     .Name_Parent_Object = p.Name_Parent_Object, _
                                                                                                     .ID_Other = p.ID_Other, _
                                                                                                     .Name_Other = p.Name_Other, _
                                                                                                     .ID_Parent_Other = p.ID_Parent_Other, _
                                                                                                     .Name_Parent_Other = p.Name_Parent_Other, _
                                                                                                     .ID_RelationType = p.ID_RelationType, _
                                                                                                     .Name_RelationType = p.Name_RelationType, _
                                                                                                     .Ontology = p.Ontology, _
                                                                                                     .OrderID = p.OrderID, _
                                                                                                     .ID_Direction = objLocalConfig.Globals.Direction_LeftRight.GUID
                                                                                                    }).ToList()
            End If
            


            If Not objOList_RelationTypes_RightLeft Is Nothing Then
                objOLRel_ItemToRef.Clear()
                objOLRel_ItemToRef.AddRange(From objClass In objOList_ClassesIn
                                    From objRelationType In objOList_RelationTypes_RightLeft
                                    Select New clsObjectRel With {.ID_Parent_Other = objClass.GUID, _
                                                                  .ID_RelationType = objRelationType.GUID})


                objOItem_Result = objDBLevel_RefToItem.get_Data_ObjectRel(objOLRel_ItemToRef, boolIDs:=False)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If OList_FilterRefs.Any() Then
                        objOList_Rels.AddRange(From objRel In objDBLevel_RefToItem.OList_ObjectRel.Select(Function(p) New clsObjectRel With {.ID_Object = p.ID_Other, _
                                                                                                                          .Name_Object = p.Name_Other, _
                                                                                                     .ID_Parent_Object = p.ID_Parent_Other, _
                                                                                                     .Name_Parent_Object = p.Name_Parent_Other, _
                                                                                                     .ID_Other = p.ID_Object, _
                                                                                                     .Name_Other = p.Name_Object, _
                                                                                                     .ID_Parent_Other = p.ID_Parent_Object, _
                                                                                                     .Name_Parent_Other = p.Name_Parent_Object, _
                                                                                                     .ID_RelationType = p.ID_RelationType, _
                                                                                                     .Name_RelationType = p.Name_RelationType, _
                                                                                                     .Ontology = p.Ontology, _
                                                                                                     .OrderID = p.OrderID, _
                                                                                                     .ID_Direction = objLocalConfig.Globals.Direction_RightLeft.GUID
                                                                                                    }).ToList()
                                                Join objFilterRel In OList_FilterRefs On objRel.ID_Object Equals objFilterRel.GUID)
                    Else
                        objOList_Rels.AddRange(objDBLevel_RefToItem.OList_ObjectRel.Select(Function(p) New clsObjectRel With {.ID_Object = p.ID_Other, _
                                                                                                                          .Name_Object = p.Name_Other, _
                                                                                                     .ID_Parent_Object = p.ID_Parent_Other, _
                                                                                                     .Name_Parent_Object = p.Name_Parent_Other, _
                                                                                                     .ID_Other = p.ID_Object, _
                                                                                                     .Name_Other = p.Name_Object, _
                                                                                                     .ID_Parent_Other = p.ID_Parent_Object, _
                                                                                                     .Name_Parent_Other = p.Name_Parent_Object, _
                                                                                                     .ID_RelationType = p.ID_RelationType, _
                                                                                                     .Name_RelationType = p.Name_RelationType, _
                                                                                                     .Ontology = p.Ontology, _
                                                                                                     .OrderID = p.OrderID, _
                                                                                                     .ID_Direction = objLocalConfig.Globals.Direction_RightLeft.GUID
                                                                                                    }))
                    End If
                    
                End If
            End If

        End If

        objOItem_Result_Ref = objOItem_Result
    End Sub

    Private Sub initialize()
        objDBLevel_Ref = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_RefToItem = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Classes = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ClassesOfObjects = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Objects = New clsDBLevel(objLocalConfig.Globals)
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig, OList_Refs As List(Of clsOntologyItem), OList_RelationTypesLeftRight As List(Of clsOntologyItem), Optional OList_RelationTypesRightLeft As List(Of clsOntologyItem) = Nothing)
        objLocalConfig = LocalConfig

        objOList_ClassesIn = OList_Refs
        objOList_RelationTypes_LeftRight = OList_RelationTypesLeftRight
        objOList_RelationTypes_RightLeft = OList_RelationTypesRightLeft

        OList_FilterRefs = New List(Of clsOntologyItem)
        initialize()
    End Sub
End Class


