Imports OntologyClasses.BaseClasses

Public Class clsLocalConfig
    Private objGlobals As clsGlobals

    Private objOItem_DevConfig As New clsOntologyItem

    Private objDBLevel_Config1 As clsDBLevel
    Private objDBLevel_Config2 As clsDBLevel

    Private Const cstr_ID_SoftwareDevelopment As String = "bb96e526e6d7419fadf8fe4fbc12038d"
    Private Const cstr_ID_Class_SoftwareDevelopment As String = "132a845f849f4f6b86847ab3fd068824"
    Private Const cstr_ID_Class_DevelopmentConfig As String = "c6c9bcb80ac947139417eeec1453026c"
    Private Const cstr_ID_Class_ConfigItem As String = "13c09f11175c4eefbc8a0fd8e86d557f"
    Private Const cstr_ID_RelType_needs As String = "fafc1464815f45969737bcbc96bd744a"
    Private Const cstr_ID_RelType_contains As String = "e971160347db44d8a476fe88290639a4"
    Private Const cstr_ID_RelType_belongsTo As String = "e07469d9766c443e85266d9c684f944f"

    'Attributes
    Private objOItem_Attribute_Attribute As New clsOntologyItem
    Private objOItem_Attribute_BaseboardSerial As New clsOntologyItem
    Private objOItem_attribute_dbPostfix As New clsOntologyItem
    Private objOItem_Attribute_ProcessorID As New clsOntologyItem
    Private objOItem_Attribute_RelationType As New clsOntologyItem
    Private objOItem_Attribute_Object As New clsOntologyItem
    Private objOItem_Attribute_Type As New clsOntologyItem

    'RelationTypes
    Private objOItem_RelationType_belonging_Attribute As New clsOntologyItem
    Private objOItem_RelationType_belonging_Object As New clsOntologyItem
    Private objOItem_RelationType_belonging_Type As New clsOntologyItem
    Private objOItem_RelationType_belongsTo As New clsOntologyItem
    Private objOItem_RelationType_is_on As New clsOntologyItem
    Private objOItem_RelationType_isInState As New clsOntologyItem
    Private objOItem_RelationType_offered_by As New clsOntologyItem
    Private objOItem_RelationType_offers_for As New clsOntologyItem
    Private objOItem_RelationType_RelationType As New clsOntologyItem
    Private objOItem_RelationType_SourcesLocatedIn As New clsOntologyItem
    Private objOItem_RelationType_superordinate As New clsOntologyItem

    'Objects
    Private objOItem_Object_Filter_Integration_Level As New clsOntologyItem
    Private objOItem_Object_Full_Integration_Level As New clsOntologyItem
    Private objOItem_Object_Information_Integration_Level As New clsOntologyItem
    Private objOItem_Object_Integration_Level_Menu As New clsOntologyItem
    Private objOItem_Object_Class_Integration_Level As New clsOntologyItem

    'Classes
    Private objOItem_Class_DevelopmentVersion As New clsOntologyItem
    Private objOItem_Class_Direction As New clsOntologyItem
    Private objOItem_Class_Filesystem_Management As New clsOntologyItem
    Private objOItem_Class_Folder As New clsOntologyItem
    Private objOItem_Class_Integration_Level As New clsOntologyItem
    Private objOItem_Class_Logstate As New clsOntologyItem
    Private objOItem_Class_Module As New clsOntologyItem
    Private objOItem_Class_Module_Activator As New clsOntologyItem
    Private objOItem_Class_Module_Management As New clsOntologyItem
    Private objOItem_Class_Sem_Manager As New clsOntologyItem
    Private objOItem_Class_Server As New clsOntologyItem
    Private objOItem_Class_SoftwareDevelopment As New clsOntologyItem
    Private objOItem_Class_System As New clsOntologyItem

    Private objOItem_Module As clsOntologyItem
    Private objOItem_Baseconfig As clsOntologyItem

    'Attributes
    Public ReadOnly Property OItem_Attribute_Attribute() As clsOntologyItem
        Get
            Return objOItem_Attribute_Attribute
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_BaseboardSerial() As clsOntologyItem
        Get
            Return objOItem_Attribute_BaseboardSerial
        End Get
    End Property

    Public ReadOnly Property OItem_attribute_dbPostfix() As clsOntologyItem
        Get
            Return objOItem_attribute_dbPostfix
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_ProcessorID() As clsOntologyItem
        Get
            Return objOItem_Attribute_ProcessorID
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_RelationType() As clsOntologyItem
        Get
            Return objOItem_Attribute_RelationType
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Object() As clsOntologyItem
        Get
            Return objOItem_Attribute_Object
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Type() As clsOntologyItem
        Get
            Return objOItem_Attribute_Type
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Attribute() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Attribute
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Object() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Object
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Type() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Type
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belongsTo() As clsOntologyItem
        Get
            Return objOItem_RelationType_belongsTo
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_is_on() As clsOntologyItem
        Get
            Return objOItem_RelationType_is_on
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_isInState() As clsOntologyItem
        Get
            Return objOItem_RelationType_isInState
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_offered_by() As clsOntologyItem
        Get
            Return objOItem_RelationType_offered_by
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_offers_for() As clsOntologyItem
        Get
            Return objOItem_RelationType_offers_for
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_RelationType() As clsOntologyItem
        Get
            Return objOItem_RelationType_RelationType
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_SourcesLocatedIn() As clsOntologyItem
        Get
            Return objOItem_RelationType_SourcesLocatedIn
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_superordinate() As clsOntologyItem
        Get
            Return objOItem_RelationType_superordinate
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Filter_Integration_Level() As clsOntologyItem
        Get
            Return objOItem_Object_Filter_Integration_Level
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Full_Integration_Level() As clsOntologyItem
        Get
            Return objOItem_Object_Full_Integration_Level
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Information_Integration_Level() As clsOntologyItem
        Get
            Return objOItem_Object_Information_Integration_Level
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Integration_Level_Menu() As clsOntologyItem
        Get
            Return objOItem_Object_Integration_Level_Menu
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Class_Integration_Level() As clsOntologyItem
        Get
            Return objOItem_Object_Class_Integration_Level
        End Get
    End Property

    Public ReadOnly Property OItem_Class_DevelopmentVersion() As clsOntologyItem
        Get
            Return objOItem_Class_DevelopmentVersion
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Direction() As clsOntologyItem
        Get
            Return objOItem_Class_Direction
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Filesystem_Management() As clsOntologyItem
        Get
            Return objOItem_Class_Filesystem_Management
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Folder() As clsOntologyItem
        Get
            Return objOItem_Class_Folder
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Integration_Level() As clsOntologyItem
        Get
            Return objOItem_Class_Integration_Level
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Logstate() As clsOntologyItem
        Get
            Return objOItem_Class_Logstate
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Module() As clsOntologyItem
        Get
            Return objOItem_Class_Module
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Module_Activator() As clsOntologyItem
        Get
            Return objOItem_Class_Module_Activator
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Module_Management() As clsOntologyItem
        Get
            Return objOItem_Class_Module_Management
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Sem_Manager() As clsOntologyItem
        Get
            Return objOItem_Class_Sem_Manager
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Server() As clsOntologyItem
        Get
            Return objOItem_Class_Server
        End Get
    End Property

    Public ReadOnly Property OItem_Class_SoftwareDevelopment() As clsOntologyItem
        Get
            Return objOItem_Class_SoftwareDevelopment
        End Get
    End Property

    Public ReadOnly Property OItem_Class_System() As clsOntologyItem
        Get
            Return objOItem_Class_System
        End Get
    End Property

    Public ReadOnly Property OItem_BaseConfig As clsOntologyItem
        Get
            Return objOItem_Baseconfig
        End Get
    End Property

    Private Sub get_Config()
        get_Data_DevelopmentConfig()
        get_Config_AttributeTypes()
        get_Config_RelationTypes()
        get_Config_Classes()
        get_Config_Objects()
        get_BaseConfig()
    End Sub

    Private Sub get_BaseConfig()
        Dim oList_ObjectRel As New List(Of clsObjectRel)

        oList_ObjectRel.Add(New clsObjectRel(Nothing, _
                                             Nothing, _
                                             objOItem_Class_Module.GUID, _
                                             Nothing, _
                                             cstr_ID_SoftwareDevelopment, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             objOItem_RelationType_offered_by.GUID, _
                                             Nothing, _
                                             objGlobals.Type_Object, _
                                             objGlobals.Direction_RightLeft.GUID, _
                                             Nothing, _
                                             Nothing))

        objDBLevel_Config1.get_Data_ObjectRel(oList_ObjectRel, _
                                              boolIDs:=False)

        If objDBLevel_Config1.OList_ObjectRel_ID.Count > 0 Then
            objOItem_Module = New clsOntologyItem
            objOItem_Module.GUID = objDBLevel_Config1.OList_ObjectRel(0).ID_Object
            objOItem_Module.Name = objDBLevel_Config1.OList_ObjectRel(0).Name_Object
            objOItem_Module.GUID_Parent = objDBLevel_Config1.OList_ObjectRel(0).ID_Parent_Object
            objOItem_Module.Type = objGlobals.Type_Object

            oList_ObjectRel.Clear()
            oList_ObjectRel.Add(New clsObjectRel(Nothing, _
                                                 Nothing, _
                                                 objOItem_Class_Sem_Manager.GUID, _
                                                 Nothing, _
                                                 objDBLevel_Config1.OList_ObjectRel_ID(0).ID_Object, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 objOItem_RelationType_belongsTo.GUID, _
                                                 Nothing, _
                                                 objGlobals.Type_Object, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing))

            objDBLevel_Config1.get_Data_ObjectRel(oList_ObjectRel, _
                                                  boolIDs:=False)

            If objDBLevel_Config1.OList_ObjectRel.Count > 0 Then
                objOItem_Baseconfig = New clsOntologyItem(objDBLevel_Config1.OList_ObjectRel(0).ID_Object, _
                                                       objDBLevel_Config1.OList_ObjectRel(0).Name_Object, _
                                                       objDBLevel_Config1.OList_ObjectRel(0).ID_Parent_Object, _
                                                       objGlobals.Type_Object)
            Else
                Err.Raise(1, "Config not set")
            End If
        Else
            Err.Raise(1, "Config not set")

        End If
    End Sub

    Private Sub get_Data_DevelopmentConfig()
        Dim objOItem_ObjecRel As clsObjectRel
        Dim oList_ObjectRel As New List(Of clsObjectRel)
        Dim oList_ConfigItems As New List(Of clsOntologyItem)

        Dim oList_RelType_contains As New List(Of clsOntologyItem)
        Dim oList_RelType_belongsTo As New List(Of clsOntologyItem)

        Dim oList_ConfigItem As New List(Of clsOntologyItem)


        oList_ObjectRel.Add(New clsObjectRel(cstr_ID_SoftwareDevelopment, _
                                            Nothing, _
                                            Nothing, _
                                            Nothing, _
                                            Nothing, _
                                            Nothing, _
                                            cstr_ID_Class_DevelopmentConfig, _
                                            Nothing, _
                                            cstr_ID_RelType_needs, _
                                            Nothing, _
                                            objGlobals.Type_Object, _
                                            Nothing, _
                                            Nothing, _
                                            Nothing))

        objDBLevel_Config1.get_Data_ObjectRel(oList_ObjectRel)

        If objDBLevel_Config1.OList_ObjectRel_ID.Count > 0 Then
            objOItem_DevConfig.GUID = objDBLevel_Config1.OList_ObjectRel_ID(0).ID_Other
            objOItem_DevConfig.Name = objDBLevel_Config1.OList_ObjectRel_ID(0).Name_Other
            objOItem_DevConfig.GUID_Parent = objDBLevel_Config1.OList_ObjectRel_ID(0).ID_Parent_Other
            objOItem_DevConfig.Type = objDBLevel_Config1.OList_ObjectRel_ID(0).Ontology

            oList_ObjectRel.Clear()
            oList_ObjectRel.Add(New clsObjectRel(objOItem_DevConfig.GUID, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 cstr_ID_Class_ConfigItem, _
                                                 Nothing, _
                                                 cstr_ID_RelType_contains, _
                                                 Nothing, _
                                                 objGlobals.Type_Object, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing))

            objDBLevel_Config1.get_Data_ObjectRel(oList_ObjectRel, _
                                          False, _
                                          False, _
                                          False, _
                                          objGlobals.Direction_LeftRight.Name, _
                                          True)
            oList_ObjectRel.Clear()
            If objDBLevel_Config1.OList_ObjectRel.Count > 0 Then
                For Each objOItem_ObjecRel In objDBLevel_Config1.OList_ObjectRel
                    oList_ConfigItems.Add(New clsOntologyItem(objOItem_ObjecRel.ID_Other, _
                                                              objGlobals.Type_Object))

                    oList_ObjectRel.Add(New clsObjectRel(objOItem_ObjecRel.ID_Other, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         cstr_ID_RelType_belongsTo, _
                                                         Nothing, _
                                                         Nothing, _
                                                         objGlobals.Direction_LeftRight.GUID, _
                                                         objGlobals.Direction_LeftRight.Name, _
                                                         Nothing))



                Next

                objDBLevel_Config2.get_Data_ObjectRel(oList_ObjectRel, _
                                                         False, _
                                                         False, _
                                                         False, _
                                                         objGlobals.Direction_LeftRight.Name, _
                                                         False)
            Else
                Err.Raise(1, "Config not set!")
            End If

        Else
            Err.Raise(1, "Config not set!")
        End If

    End Sub


    Private Sub get_Config_AttributeTypes()
        Dim objOList_attribute_attribute = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "attribute_attribute" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_attribute.Count > 0 Then
            objOItem_Attribute_Attribute = New clsOntologyItem
            objOItem_Attribute_Attribute.GUID = objOList_attribute_attribute(0).ID_Other
            objOItem_Attribute_Attribute.Name = objOList_attribute_attribute(0).Name_Other
            objOItem_Attribute_Attribute.GUID_Parent = objOList_attribute_attribute(0).ID_Parent_Other
            objOItem_Attribute_Attribute.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_baseboardserial = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_baseboardserial" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_baseboardserial.Count > 0 Then
            objOItem_Attribute_BaseboardSerial = New clsOntologyItem
            objOItem_Attribute_BaseboardSerial.GUID = objOList_attribute_baseboardserial(0).ID_Other
            objOItem_Attribute_BaseboardSerial.Name = objOList_attribute_baseboardserial(0).Name_Other
            objOItem_Attribute_BaseboardSerial.GUID_Parent = objOList_attribute_baseboardserial(0).ID_Parent_Other
            objOItem_Attribute_BaseboardSerial.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_dbpostfix = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_dbpostfix" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_dbpostfix.Count > 0 Then
            objOItem_attribute_dbPostfix = New clsOntologyItem
            objOItem_attribute_dbPostfix.GUID = objOList_attribute_dbpostfix(0).ID_Other
            objOItem_attribute_dbPostfix.Name = objOList_attribute_dbpostfix(0).Name_Other
            objOItem_attribute_dbPostfix.GUID_Parent = objOList_attribute_dbpostfix(0).ID_Parent_Other
            objOItem_attribute_dbPostfix.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_processorid = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_processorid" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_processorid.Count > 0 Then
            objOItem_Attribute_ProcessorID = New clsOntologyItem
            objOItem_Attribute_ProcessorID.GUID = objOList_attribute_processorid(0).ID_Other
            objOItem_Attribute_ProcessorID.Name = objOList_attribute_processorid(0).Name_Other
            objOItem_Attribute_ProcessorID.GUID_Parent = objOList_attribute_processorid(0).ID_Parent_Other
            objOItem_Attribute_ProcessorID.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_relationtype = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_relationtype" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_relationtype.Count > 0 Then
            objOItem_Attribute_RelationType = New clsOntologyItem
            objOItem_Attribute_RelationType.GUID = objOList_attribute_relationtype(0).ID_Other
            objOItem_Attribute_RelationType.Name = objOList_attribute_relationtype(0).Name_Other
            objOItem_Attribute_RelationType.GUID_Parent = objOList_attribute_relationtype(0).ID_Parent_Other
            objOItem_Attribute_RelationType.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_token = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_token" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_token.Count > 0 Then
            objOItem_Attribute_Object = New clsOntologyItem
            objOItem_Attribute_Object.GUID = objOList_attribute_token(0).ID_Other
            objOItem_Attribute_Object.Name = objOList_attribute_token(0).Name_Other
            objOItem_Attribute_Object.GUID_Parent = objOList_attribute_token(0).ID_Parent_Other
            objOItem_Attribute_Object.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_type = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_type" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_type.Count > 0 Then
            objOItem_Attribute_Type = New clsOntologyItem
            objOItem_Attribute_Type.GUID = objOList_attribute_type(0).ID_Other
            objOItem_Attribute_Type.Name = objOList_attribute_type(0).Name_Other
            objOItem_Attribute_Type.GUID_Parent = objOList_attribute_type(0).ID_Parent_Other
            objOItem_Attribute_Type.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_RelationTypes()
        Dim objOList_relationtype_belonging_attribute = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "relationtype_belonging_attribute" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belonging_attribute.Count > 0 Then
            objOItem_relationtype_belonging_attribute = New clsOntologyItem
            objOItem_relationtype_belonging_attribute.GUID = objOList_relationtype_belonging_attribute(0).ID_Other
            objOItem_relationtype_belonging_attribute.Name = objOList_relationtype_belonging_attribute(0).Name_Other
            objOItem_relationtype_belonging_attribute.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_token = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belonging_token" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belonging_token.Count > 0 Then
            objOItem_RelationType_belonging_Object = New clsOntologyItem
            objOItem_RelationType_belonging_Object.GUID = objOList_relationtype_belonging_token(0).ID_Other
            objOItem_RelationType_belonging_Object.Name = objOList_relationtype_belonging_token(0).Name_Other
            objOItem_RelationType_belonging_Object.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_type = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belonging_type" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belonging_type.Count > 0 Then
            objOItem_relationtype_belonging_type = New clsOntologyItem
            objOItem_relationtype_belonging_type.GUID = objOList_relationtype_belonging_type(0).ID_Other
            objOItem_relationtype_belonging_type.Name = objOList_relationtype_belonging_type(0).Name_Other
            objOItem_relationtype_belonging_type.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belongsto = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belongsto" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belongsto.Count > 0 Then
            objOItem_relationtype_belongsto = New clsOntologyItem
            objOItem_relationtype_belongsto.GUID = objOList_relationtype_belongsto(0).ID_Other
            objOItem_relationtype_belongsto.Name = objOList_relationtype_belongsto(0).Name_Other
            objOItem_relationtype_belongsto.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_is_on = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_is_on" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_is_on.Count > 0 Then
            objOItem_relationtype_is_on = New clsOntologyItem
            objOItem_relationtype_is_on.GUID = objOList_relationtype_is_on(0).ID_Other
            objOItem_relationtype_is_on.Name = objOList_relationtype_is_on(0).Name_Other
            objOItem_relationtype_is_on.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_isinstate = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_isinstate" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_isinstate.Count > 0 Then
            objOItem_relationtype_isinstate = New clsOntologyItem
            objOItem_relationtype_isinstate.GUID = objOList_relationtype_isinstate(0).ID_Other
            objOItem_relationtype_isinstate.Name = objOList_relationtype_isinstate(0).Name_Other
            objOItem_relationtype_isinstate.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_offered_by = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_offered_by" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_offered_by.Count > 0 Then
            objOItem_relationtype_offered_by = New clsOntologyItem
            objOItem_relationtype_offered_by.GUID = objOList_relationtype_offered_by(0).ID_Other
            objOItem_relationtype_offered_by.Name = objOList_relationtype_offered_by(0).Name_Other
            objOItem_relationtype_offered_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_offers_for = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_offers_for" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_offers_for.Count > 0 Then
            objOItem_relationtype_offers_for = New clsOntologyItem
            objOItem_relationtype_offers_for.GUID = objOList_relationtype_offers_for(0).ID_Other
            objOItem_relationtype_offers_for.Name = objOList_relationtype_offers_for(0).Name_Other
            objOItem_relationtype_offers_for.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_relationtype = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_relationtype" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_relationtype.Count > 0 Then
            objOItem_relationtype_relationtype = New clsOntologyItem
            objOItem_relationtype_relationtype.GUID = objOList_relationtype_relationtype(0).ID_Other
            objOItem_relationtype_relationtype.Name = objOList_relationtype_relationtype(0).Name_Other
            objOItem_relationtype_relationtype.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_sourceslocatedin = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_sourceslocatedin" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_sourceslocatedin.Count > 0 Then
            objOItem_relationtype_sourceslocatedin = New clsOntologyItem
            objOItem_relationtype_sourceslocatedin.GUID = objOList_relationtype_sourceslocatedin(0).ID_Other
            objOItem_relationtype_sourceslocatedin.Name = objOList_relationtype_sourceslocatedin(0).Name_Other
            objOItem_relationtype_sourceslocatedin.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_superordinate = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_superordinate" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_superordinate.Count > 0 Then
            objOItem_relationtype_superordinate = New clsOntologyItem
            objOItem_relationtype_superordinate.GUID = objOList_relationtype_superordinate(0).ID_Other
            objOItem_relationtype_superordinate.Name = objOList_relationtype_superordinate(0).Name_Other
            objOItem_relationtype_superordinate.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_Objects()
        Dim objOList_Object_filter_integration_level = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "token_filter_integration_level" And obj.Ontology = objGlobals.Type_Object

        If objOList_Object_filter_integration_level.Count > 0 Then
            objOItem_Object_Filter_Integration_Level = New clsOntologyItem
            objOItem_Object_Filter_Integration_Level.GUID = objOList_Object_filter_integration_level(0).ID_Other
            objOItem_Object_Filter_Integration_Level.Name = objOList_Object_filter_integration_level(0).Name_Other
            objOItem_Object_Filter_Integration_Level.GUID_Parent = objOList_Object_filter_integration_level(0).ID_Parent_Other
            objOItem_Object_Filter_Integration_Level.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Object_full_integration_level = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_full_integration_level" And obj.Ontology = objGlobals.Type_Object

        If objOList_Object_full_integration_level.Count > 0 Then
            objOItem_Object_Full_Integration_Level = New clsOntologyItem
            objOItem_Object_Full_Integration_Level.GUID = objOList_Object_full_integration_level(0).ID_Other
            objOItem_Object_Full_Integration_Level.Name = objOList_Object_full_integration_level(0).Name_Other
            objOItem_Object_Full_Integration_Level.GUID_Parent = objOList_Object_full_integration_level(0).ID_Parent_Other
            objOItem_Object_Full_Integration_Level.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Object_information_integration_level = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_information_integration_level" And obj.Ontology = objGlobals.Type_Object

        If objOList_Object_information_integration_level.Count > 0 Then
            objOItem_Object_Information_Integration_Level = New clsOntologyItem
            objOItem_Object_Information_Integration_Level.GUID = objOList_Object_information_integration_level(0).ID_Other
            objOItem_Object_Information_Integration_Level.Name = objOList_Object_information_integration_level(0).Name_Other
            objOItem_Object_Information_Integration_Level.GUID_Parent = objOList_Object_information_integration_level(0).ID_Parent_Other
            objOItem_Object_Information_Integration_Level.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Object_integration_level_menu = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_integration_level_menu" And obj.Ontology = objGlobals.Type_Object

        If objOList_Object_integration_level_menu.Count > 0 Then
            objOItem_Object_Integration_Level_Menu = New clsOntologyItem
            objOItem_Object_Integration_Level_Menu.GUID = objOList_Object_integration_level_menu(0).ID_Other
            objOItem_Object_Integration_Level_Menu.Name = objOList_Object_integration_level_menu(0).Name_Other
            objOItem_Object_Integration_Level_Menu.GUID_Parent = objOList_Object_integration_level_menu(0).ID_Parent_Other
            objOItem_Object_Integration_Level_Menu.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Object_type_integration_level = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_type_integration_level" And obj.Ontology = objGlobals.Type_Object

        If objOList_Object_type_integration_level.Count > 0 Then
            objOItem_Object_Class_Integration_Level = New clsOntologyItem
            objOItem_Object_Class_Integration_Level.GUID = objOList_Object_type_integration_level(0).ID_Other
            objOItem_Object_Class_Integration_Level.Name = objOList_Object_type_integration_level(0).Name_Other
            objOItem_Object_Class_Integration_Level.GUID_Parent = objOList_Object_type_integration_level(0).ID_Parent_Other
            objOItem_Object_Class_Integration_Level.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_Classes()
        Dim objOList_Class_developmentversion = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "type_developmentversion" And obj.Ontology = objGlobals.Type_Class

        If objOList_Class_developmentversion.Count > 0 Then
            objOItem_Class_DevelopmentVersion = New clsOntologyItem
            objOItem_Class_DevelopmentVersion.GUID = objOList_Class_developmentversion(0).ID_Other
            objOItem_Class_DevelopmentVersion.Name = objOList_Class_developmentversion(0).Name_Other
            objOItem_Class_DevelopmentVersion.GUID_Parent = objOList_Class_developmentversion(0).ID_Parent_Other
            objOItem_Class_DevelopmentVersion.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_direction = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_direction" And obj.Ontology = objGlobals.Type_Class

        If objOList_Class_direction.Count > 0 Then
            objOItem_Class_Direction = New clsOntologyItem
            objOItem_Class_Direction.GUID = objOList_Class_direction(0).ID_Other
            objOItem_Class_Direction.Name = objOList_Class_direction(0).Name_Other
            objOItem_Class_Direction.GUID_Parent = objOList_Class_direction(0).ID_Parent_Other
            objOItem_Class_Direction.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_filesystem_management = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_filesystem_management" And obj.Ontology = objGlobals.Type_Class

        If objOList_Class_filesystem_management.Count > 0 Then
            objOItem_Class_Filesystem_Management = New clsOntologyItem
            objOItem_Class_Filesystem_Management.GUID = objOList_Class_filesystem_management(0).ID_Other
            objOItem_Class_Filesystem_Management.Name = objOList_Class_filesystem_management(0).Name_Other
            objOItem_Class_Filesystem_Management.GUID_Parent = objOList_Class_filesystem_management(0).ID_Parent_Other
            objOItem_Class_Filesystem_Management.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_folder = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_folder" And obj.Ontology = objGlobals.Type_Class

        If objOList_Class_folder.Count > 0 Then
            objOItem_Class_Folder = New clsOntologyItem
            objOItem_Class_Folder.GUID = objOList_Class_folder(0).ID_Other
            objOItem_Class_Folder.Name = objOList_Class_folder(0).Name_Other
            objOItem_Class_Folder.GUID_Parent = objOList_Class_folder(0).ID_Parent_Other
            objOItem_Class_Folder.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_integration_level = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_integration_level" And obj.Ontology = objGlobals.Type_Class

        If objOList_Class_integration_level.Count > 0 Then
            objOItem_Class_Integration_Level = New clsOntologyItem
            objOItem_Class_Integration_Level.GUID = objOList_Class_integration_level(0).ID_Other
            objOItem_Class_Integration_Level.Name = objOList_Class_integration_level(0).Name_Other
            objOItem_Class_Integration_Level.GUID_Parent = objOList_Class_integration_level(0).ID_Parent_Other
            objOItem_Class_Integration_Level.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_logstate = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_logstate" And obj.Ontology = objGlobals.Type_Class

        If objOList_Class_logstate.Count > 0 Then
            objOItem_Class_Logstate = New clsOntologyItem
            objOItem_Class_Logstate.GUID = objOList_Class_logstate(0).ID_Other
            objOItem_Class_Logstate.Name = objOList_Class_logstate(0).Name_Other
            objOItem_Class_Logstate.GUID_Parent = objOList_Class_logstate(0).ID_Parent_Other
            objOItem_Class_Logstate.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_module = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_module" And obj.Ontology = objGlobals.Type_Class

        If objOList_Class_module.Count > 0 Then
            objOItem_Class_Module = New clsOntologyItem
            objOItem_Class_Module.GUID = objOList_Class_module(0).ID_Other
            objOItem_Class_Module.Name = objOList_Class_module(0).Name_Other
            objOItem_Class_Module.GUID_Parent = objOList_Class_module(0).ID_Parent_Other
            objOItem_Class_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_module_activator = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_module_activator" And obj.Ontology = objGlobals.Type_Class

        If objOList_Class_module_activator.Count > 0 Then
            objOItem_Class_Module_Activator = New clsOntologyItem
            objOItem_Class_Module_Activator.GUID = objOList_Class_module_activator(0).ID_Other
            objOItem_Class_Module_Activator.Name = objOList_Class_module_activator(0).Name_Other
            objOItem_Class_Module_Activator.GUID_Parent = objOList_Class_module_activator(0).ID_Parent_Other
            objOItem_Class_Module_Activator.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_module_management = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_module_management" And obj.Ontology = objGlobals.Type_Class

        If objOList_Class_module_management.Count > 0 Then
            objOItem_Class_Module_Management = New clsOntologyItem
            objOItem_Class_Module_Management.GUID = objOList_Class_module_management(0).ID_Other
            objOItem_Class_Module_Management.Name = objOList_Class_module_management(0).Name_Other
            objOItem_Class_Module_Management.GUID_Parent = objOList_Class_module_management(0).ID_Parent_Other
            objOItem_Class_Module_Management.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_sem_manager = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_sem_manager" And obj.Ontology = objGlobals.Type_Class

        If objOList_Class_sem_manager.Count > 0 Then
            objOItem_Class_Sem_Manager = New clsOntologyItem
            objOItem_Class_Sem_Manager.GUID = objOList_Class_sem_manager(0).ID_Other
            objOItem_Class_Sem_Manager.Name = objOList_Class_sem_manager(0).Name_Other
            objOItem_Class_Sem_Manager.GUID_Parent = objOList_Class_sem_manager(0).ID_Parent_Other
            objOItem_Class_Sem_Manager.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_server = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_server" And obj.Ontology = objGlobals.Type_Class

        If objOList_Class_server.Count > 0 Then
            objOItem_Class_Server = New clsOntologyItem
            objOItem_Class_Server.GUID = objOList_Class_server(0).ID_Other
            objOItem_Class_Server.Name = objOList_Class_server(0).Name_Other
            objOItem_Class_Server.GUID_Parent = objOList_Class_server(0).ID_Parent_Other
            objOItem_Class_Server.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_softwaredevelopment = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_softwaredevelopment" And obj.Ontology = objGlobals.Type_Class

        If objOList_Class_softwaredevelopment.Count > 0 Then
            objOItem_Class_SoftwareDevelopment = New clsOntologyItem
            objOItem_Class_SoftwareDevelopment.GUID = objOList_Class_softwaredevelopment(0).ID_Other
            objOItem_Class_SoftwareDevelopment.Name = objOList_Class_softwaredevelopment(0).Name_Other
            objOItem_Class_SoftwareDevelopment.GUID_Parent = objOList_Class_softwaredevelopment(0).ID_Parent_Other
            objOItem_Class_SoftwareDevelopment.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_system = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_system" And obj.Ontology = objGlobals.Type_Class

        If objOList_Class_system.Count > 0 Then
            objOItem_Class_System = New clsOntologyItem
            objOItem_Class_System.GUID = objOList_Class_system(0).ID_Other
            objOItem_Class_System.Name = objOList_Class_system(0).Name_Other
            objOItem_Class_System.GUID_Parent = objOList_Class_system(0).ID_Parent_Other
            objOItem_Class_System.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If


    End Sub


    Public ReadOnly Property Globals As clsGlobals
        Get
            Return objGlobals
        End Get
    End Property

    Public Sub New(ByVal Globals As clsGlobals)
        objGlobals = Globals
        set_DBConnection()

        get_Config()

    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Config1 = New clsDBLevel(objGlobals)
        objDBLevel_Config2 = New clsDBLevel(objGlobals)
    End Sub


    
End Class
