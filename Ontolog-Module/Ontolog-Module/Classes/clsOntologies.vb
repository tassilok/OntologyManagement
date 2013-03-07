Public Class clsOntologies
    Private objLocalConfig As clsLocalConfig

    Private objOList As New List(Of clsOntologyItem)

    Private objDBLevel As clsDBLevel
    Private objDBLevel_Attributes As clsDBLevel
    Private objDBLevel_RelTypes As clsDBLevel
    Private objDBLevel_Classes As clsDBLevel
    Private objDBLevel_Objects As clsDBLevel

    Public ReadOnly Property OList As List(Of clsOntologyItem)
        Get
            Return objOList
        End Get
    End Property

    Public Function get_Ontologies(ByVal OItem_Ontology As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Ontologies As New List(Of clsOntologyItem)
        Dim objOList_ObjRel As New List(Of clsObjectRel)
        Dim objOList_ObjRel2 As New List(Of clsObjectRel)
        Dim objOList_ObjRel3 As New List(Of clsObjectRel)
        Dim objOList_ObjRel4 As New List(Of clsObjectRel)


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


        objOList_Ontologies.Add(OItem_Ontology)

        Dim oList = From obj In objDBLevel.OList_ObjectRel_ID
                    Group By obj.ID_Other Into Group

        For Each ListItem In oList
            objOList_Ontologies.Add(New clsOntologyItem(ListItem.ID_Other, objLocalConfig.Globals.Type_Object))

        Next
        objOList_ObjRel.Clear()
        For Each ListItem In oList
            objOList_ObjRel.Add(New clsObjectRel(ListItem.ID_Other, _
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


        Next



        objDBLevel.get_Data_ObjectRel(objOList_ObjRel, False, False)

        objOList_ObjRel.Clear()
        objOList_ObjRel2.Clear()
        objOList_ObjRel3.Clear()
        objOList_ObjRel4.Clear()
        For Each ListItem In objDBLevel.OList_Objects
            objOList_ObjRel.Add(New clsObjectRel(ListItem.GUID, _
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

            objOList_ObjRel2.Add(New clsObjectRel(ListItem.GUID, _
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

            objOList_ObjRel3.Add(New clsObjectRel(ListItem.GUID, _
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

            objOList_ObjRel4.Add(New clsObjectRel(ListItem.GUID, _
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

        Next

        

        objDBLevel_Attributes.get_Data_ObjectRel(objOList_ObjRel, False, False)

        objDBLevel_Classes.get_Data_ObjectRel(objOList_ObjRel3, False, False)

        objDBLevel_Objects.get_Data_ObjectRel(objOList_ObjRel4, False, False)

        objDBLevel_RelTypes.get_Data_ObjectRel(objOList_ObjRel2, False, False)


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
        objDBLevel = New clsDBLevel(objLocalConfig)
        objDBLevel_Attributes = New clsDBLevel(objLocalConfig)
        objDBLevel_RelTypes = New clsDBLevel(objLocalConfig)
        objDBLevel_Classes = New clsDBLevel(objLocalConfig)
        objDBLevel_Objects = New clsDBLevel(objLocalConfig)
    End Sub
End Class
