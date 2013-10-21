Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsDataWork_OntologyRels
    Public objLocalConfig As clsLocalConfig_Ontologies

    Private objDBLevel_ClassAtt As clsDBLevel
    Private objDBLevel_ClassRel As clsDBLevel
    Private objDBLevel_ObjAtt As clsDBLevel
    Private objDBLevel_ObjRel As clsDBLevel
    Private objDBLevel_ClassParents As clsDBLevel
    Private objDBLevel_Objects As clsDBLevel
    Private objDBLeveL_ClassesOfObjects As clsDBLevel

    Private objOItem_Result_ClassAtt As clsOntologyItem
    Private objOItem_Result_ClassRel As clsOntologyItem
    Private objOItem_Result_ObjAtt As clsOntologyItem
    Private objOItem_Result_ObjRel As clsOntologyItem

    Private objOList_Classes As List(Of clsOntologyItem)
    Private objOList_AttributeTypes As List(Of clsOntologyItem)
    Private objOList_RelationTypes As List(Of clsOntologyItem)
    Private objOList_Objects As List(Of clsOntologyItem)

    Private objOList_ClassAtt As List(Of clsClassAtt)
    Private objOList_ClassRel As List(Of clsClassRel)
    Private objOList_ObjectAtt As List(Of clsObjectAtt)
    Private objOList_ObjectRel As List(Of clsObjectRel)

    

    Public ReadOnly Property OItem_Result_ClassAtt As clsOntologyItem
        Get
            Return objOItem_Result_ClassAtt
        End Get
    End Property

    Public ReadOnly Property OItem_Result_ClassRel As clsOntologyItem
        Get
            Return objOItem_Result_ClassRel
        End Get
    End Property

    Public ReadOnly Property OItem_Result_ObjectAtt As clsOntologyItem
        Get
            Return objOItem_Result_ObjAtt
        End Get
    End Property

    Public ReadOnly Property OItem_Result_ObjectRel As clsOntologyItem
        Get
            Return objOItem_Result_ObjRel
        End Get
    End Property

    Public Property OList_Classes As List(Of clsOntologyItem)
        Get
            Return objOList_Classes
        End Get
        Set(value As List(Of clsOntologyItem))
            objOList_Classes = value
        End Set
    End Property

    Public Property OList_AttributeTypes As List(Of clsOntologyItem)
        Get
            Return objOList_AttributeTypes
        End Get
        Set(value As List(Of clsOntologyItem))
            objOList_AttributeTypes = value
        End Set
    End Property

    Public Property OList_RelationTypes As List(Of clsOntologyItem)
        Get
            Return objOList_RelationTypes
        End Get
        Set(value As List(Of clsOntologyItem))
            objOList_RelationTypes = value
        End Set
    End Property

    Public Property OList_Objects As List(Of clsOntologyItem)
        get
            Return objOList_Objects
        End Get
        Set(value As List(Of clsOntologyItem))
            objOList_Objects = value
        End Set
    End Property

    Public ReadOnly Property ClassAtt As List(Of clsClassAtt)
        Get
            Return objOList_ClassAtt

        End Get
    End Property

    Public ReadOnly Property ClassRel As List(Of clsClassRel)
        Get
            Return objOList_ClassRel
        End Get
    End Property

    Public ReadOnly Property ObjectAtt As List(Of clsObjectAtt)
        Get
            Return objOList_ObjectAtt
        End Get
    End Property

    Public ReadOnly Property ObjectRel As List(Of clsObjectRel)
        Get
            Return objOList_ObjectRel
        End Get
    End Property

    Public Sub GetData_ClassAtt()
        objOItem_Result_ClassAtt = objLocalConfig.Globals.LState_Nothing

        Dim objOItem_Result = objDBLevel_ClassAtt.get_Data_ClassAtt(boolIDs:=False)
        If objOList_Classes.Any Then
            objOList_ClassAtt = (From objClassAtt In objDBLevel_ClassAtt.OList_ClassAtt
                    Join objClass In objOList_Classes On objClassAtt.ID_Class Equals objClass.GUID
                    Select objClassAtt).ToList
        Else
            objOList_ClassAtt = objDBLevel_ClassAtt.OList_ClassAtt
        End If

        objOItem_Result_ClassAtt = objOItem_Result
    End Sub

    Public Sub GetData_ClassRel()
        objOItem_Result_ClassRel = objLocalConfig.Globals.LState_Nothing

        Dim objOItem_Result = objDBLevel_ClassRel.get_Data_ClassRel(Nothing, boolIDs:=False)

        If objOList_Classes.Any Then
            objOList_ClassRel = (From objClassRel In objDBLevel_ClassRel.OList_ClassRel
                    Join objClass In objOList_Classes On objClassRel.ID_Class_Left Equals objClass.GUID
                    Select objClassRel).ToList
        Else
            objOList_ClassRel = objDBLevel_ClassAtt.OList_ClassRel
        End If

        objOItem_Result_ClassRel = objOItem_Result
    End Sub

    Public Sub GetData_ObjectAtt()
        objOItem_Result_ObjAtt = objLocalConfig.Globals.LState_Nothing

        Dim objOItem_Result = objLocalConfig.Globals.LState_Success

        If objOList_Classes.Any Or objOList_AttributeTypes.Any Then
            Dim objOList_ObjectAttSearch = (From objClasses In objOList_Classes
                                  From objAttributeType In objOList_AttributeTypes
                                  Select New clsObjectAtt With {.ID_AttributeType = objAttributeType.GUID, _
                                                                .ID_Class = objClasses.GUID}).ToList

            objOItem_Result = objDBLevel_ObjAtt.get_Data_ObjectAtt(objOList_ObjectAttSearch, boolIDs:=False)
            
        Else
            objOItem_Result = objDBLevel_ObjAtt.get_Data_ObjectAtt(Nothing, boolIDs:=False)
        End If
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOList_ObjectAtt = objDBLevel_ObjAtt.OList_ObjectAtt
        End If

        objOItem_Result_ObjAtt = objOItem_Result
    End Sub

    Public Sub GetData_ObjectRel()
        objOItem_Result_ObjRel = objLocalConfig.Globals.LState_Nothing

        Dim objOItem_Result = objLocalConfig.Globals.LState_Success

        If objOList_Classes.Any Or objOList_RelationTypes.Any Then
            Dim objOList_ObjectRelSearch = (From objClass In objOList_Classes
                                            From objRelationType In objOList_RelationTypes
                                            Select New clsObjectRel With {.ID_Parent_Object = objClass.GUID, _
                                                                          .ID_RelationType = objRelationType.GUID}).ToList()

            objOItem_Result = objDBLevel_ObjRel.get_Data_ObjectRel(objOList_ObjectRelSearch, boolIDs:=False)
        Else
            objOItem_Result = objDBLevel_ObjRel.get_Data_ObjectRel(Nothing, boolIDs:=False)
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOList_ObjectRel = objDBLevel_ObjRel.OList_ObjectRel
        End If

        objOItem_Result_ObjRel = objOItem_Result
    End Sub

    Public Function GetData_ObjectsOfClasses(OList_ObjectSearch As List(Of clsOntologyItem)) As List(Of clsOntologyItem)
        Dim OList_Objects = new List(Of clsOntologyItem)
        Dim objOItem_Result = objDBLevel_Objects.get_Data_Objects(OList_ObjectSearch)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            OList_Objects = objDBLevel_Objects.OList_Objects
        Else 
            objOList_Objects = Nothing
        End If

        Return OList_Objects
    End Function

    Public Function GetData_ClassesOfObjects(OList_Classes As List(Of clsOntologyItem)) As List(Of clsOntologyItem)
        Dim objOList_Classes = New List(Of clsOntologyItem)

        Dim objOItem_Result = objDBLeveL_ClassesOfObjects.get_Data_Classes(OList_Classes)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOList_Classes = objDBLeveL_ClassesOfObjects.OList_Classes
        Else 
            objOList_Classes = Nothing
        End If

        Return objOList_Classes
    End Function

    Public Sub New(LocalConfig As clsLocalConfig_Ontologies)
        objLocalConfig = LocalConfig

        initialize()
    End Sub

    Public Sub New(Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig_Ontologies(Globals)

        initialize()
    End Sub

    Private Sub initialize()
        objDBLevel_ClassAtt = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ClassRel = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ObjAtt = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ObjRel = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ClassParents = new clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Objects = new clsDBLevel(objLocalConfig.Globals)
        objDBLeveL_ClassesOfObjects = new clsDBLevel(objLocalConfig.Globals)

        objOItem_Result_ClassAtt = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_ClassRel = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_ObjAtt = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_ObjRel = objLocalConfig.Globals.LState_Nothing

    End Sub


End Class
