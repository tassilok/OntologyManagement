Imports OntologyClasses.BaseClasses
Imports System.Reflection

Public Class clsLocalConfig
    Private objGlobals As clsGlobals

    Private objOItem_DevConfig As New clsOntologyItem

    Private objDBLevel_Config1 As clsDBLevel
    Private objDBLevel_Config2 As clsDBLevel

    Private objImport As clsImport

    Private cstrID_Ontology As String = "eab045554fce4fb981dc2b127dc32d4b"

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
    Private objOItem_Module As New clsOntologyItem

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

    Public ReadOnly Property OItem_Module() As clsOntologyItem
        Get
            Return objOItem_Module
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
        Try
            get_Data_DevelopmentConfig()
            get_Config_AttributeTypes()
            get_Config_RelationTypes()
            get_Config_Classes()
            get_Config_Objects()
            get_BaseConfig()
        Catch ex As Exception
            Dim objAssembly = [Assembly].GetExecutingAssembly()
            Dim objCustomAttributes() As AssemblyTitleAttribute = objAssembly.GetCustomAttributes(GetType(AssemblyTitleAttribute), False)
            Dim strTitle = "Unbekannt"
            If objCustomAttributes.Length = 1 Then
                strTitle = objCustomAttributes.First().Title
            End If
            If MsgBox(strTitle & ": Die notwendigen Basisdaten konnten nicht geladen werden! Soll versucht werden, sie in der Datenbank " & _
                      objGlobals.Index & "@" & objGlobals.Server & " zu erzeugen?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim objOItem_Result = objImport.ImportTemplates(objAssembly)
                If Not objOItem_Result.GUID = objGlobals.LState_Error.GUID Then
                    get_Data_DevelopmentConfig()
                    get_Config_AttributeTypes()
                    get_Config_RelationTypes()
                    get_Config_Classes()
                    get_Config_Objects()
                    get_BaseConfig()
                Else
                    Err.Raise(1, "Config not importable")
                End If
            Else
                Environment.Exit(0)
            End If

        End Try
        
    End Sub

    Private Sub get_BaseConfig()
        Dim oList_ObjectRel As New List(Of clsObjectRel)

        
        oList_ObjectRel.Clear()
        oList_ObjectRel.Add(New clsObjectRel(Nothing, _
                                                Nothing, _
                                                objOItem_Class_Sem_Manager.GUID, _
                                                Nothing, _
                                                objOItem_Module.GUID, _
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
        
    End Sub

    Private Sub get_Data_DevelopmentConfig()
        Dim objORL_Ontology_To_OntolgyItems = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = cstrID_Ontology, _
                                                                                             .ID_RelationType = objGlobals.RelationType_contains.GUID, _
                                                                                             .ID_Parent_Other = objGlobals.Class_OntologyItems.GUID}}



        Dim objOItem_Result = objDBLevel_Config1.get_Data_ObjectRel(objORL_Ontology_To_OntolgyItems, boolIDs:=False)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            If objDBLevel_Config1.OList_ObjectRel.Any Then

                objORL_Ontology_To_OntolgyItems = objDBLevel_Config1.OList_ObjectRel.Select(Function(oi) New clsObjectRel With {.ID_Object = oi.ID_Other,
                                                                                                                                .ID_RelationType = objGlobals.RelationType_belongingAttribute.GUID}).ToList()
                objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(Function(oi) New clsObjectRel With {.ID_Object = oi.ID_Other,
                                                                                                                                .ID_RelationType = objGlobals.RelationType_belongingClass.GUID}))
                objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(Function(oi) New clsObjectRel With {.ID_Object = oi.ID_Other,
                                                                                                                                .ID_RelationType = objGlobals.RelationType_belongingObject.GUID}))
                objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(Function(oi) New clsObjectRel With {.ID_Object = oi.ID_Other,
                                                                                                                                .ID_RelationType = objGlobals.RelationType_belongingRelationType.GUID}))
                'objORL_Ontology_To_OntolgyItems = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objGlobals.Class_OntologyItems.GUID, _
                '                                                                                     .ID_RelationType = objGlobals.RelationType_belongingAttribute.GUID},
                '                                                              New clsObjectRel With {.ID_Parent_Object = objGlobals.Class_OntologyItems.GUID, _
                '                                                                                     .ID_RelationType = objGlobals.RelationType_belongingClass.GUID},
                '                                                             New clsObjectRel With {.ID_Parent_Object = objGlobals.Class_OntologyItems.GUID, _
                '                                                                                     .ID_RelationType = objGlobals.RelationType_belongingObject.GUID},
                '                                                              New clsObjectRel With {.ID_Parent_Object = objGlobals.Class_OntologyItems.GUID, _
                '                                                                                     .ID_RelationType = objGlobals.RelationType_belongingRelationType.GUID}}

                objOItem_Result = objDBLevel_Config2.get_Data_ObjectRel(objORL_Ontology_To_OntolgyItems, boolIDs:=False)
                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    If Not objDBLevel_Config2.OList_ObjectRel.Any Then
                        Err.Raise(1, "Config-Error")
                    End If
                Else
                    Err.Raise(1, "Config-Error")
                End If

            Else
                Err.Raise(1, "Config-Error")
            End If

        End If

    End Sub


    Private Sub get_Config_AttributeTypes()
        Dim objOList_attribute_attribute = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_attribute".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_attribute.Count > 0 Then
            objOItem_Attribute_Attribute = New clsOntologyItem
            objOItem_Attribute_Attribute.GUID = objOList_attribute_attribute.First().ID_Other
            objOItem_Attribute_Attribute.Name = objOList_attribute_attribute.First().Name_Other
            objOItem_Attribute_Attribute.GUID_Parent = objOList_attribute_attribute.First().ID_Parent_Other
            objOItem_Attribute_Attribute.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_baseboardserial = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_baseboardserial".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_baseboardserial.Count > 0 Then
            objOItem_Attribute_BaseboardSerial = New clsOntologyItem
            objOItem_Attribute_BaseboardSerial.GUID = objOList_attribute_baseboardserial.First().ID_Other
            objOItem_Attribute_BaseboardSerial.Name = objOList_attribute_baseboardserial.First().Name_Other
            objOItem_Attribute_BaseboardSerial.GUID_Parent = objOList_attribute_baseboardserial.First().ID_Parent_Other
            objOItem_Attribute_BaseboardSerial.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_dbpostfix = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_dbpostfix".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_dbpostfix.Count > 0 Then
            objOItem_attribute_dbPostfix = New clsOntologyItem
            objOItem_attribute_dbPostfix.GUID = objOList_attribute_dbpostfix.First().ID_Other
            objOItem_attribute_dbPostfix.Name = objOList_attribute_dbpostfix.First().Name_Other
            objOItem_attribute_dbPostfix.GUID_Parent = objOList_attribute_dbpostfix.First().ID_Parent_Other
            objOItem_attribute_dbPostfix.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_processorid = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_processorid".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_processorid.Count > 0 Then
            objOItem_Attribute_ProcessorID = New clsOntologyItem
            objOItem_Attribute_ProcessorID.GUID = objOList_attribute_processorid.First().ID_Other
            objOItem_Attribute_ProcessorID.Name = objOList_attribute_processorid.First().Name_Other
            objOItem_Attribute_ProcessorID.GUID_Parent = objOList_attribute_processorid.First().ID_Parent_Other
            objOItem_Attribute_ProcessorID.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_relationtype = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_relationtype".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_relationtype.Count > 0 Then
            objOItem_Attribute_RelationType = New clsOntologyItem
            objOItem_Attribute_RelationType.GUID = objOList_attribute_relationtype.First().ID_Other
            objOItem_Attribute_RelationType.Name = objOList_attribute_relationtype.First().Name_Other
            objOItem_Attribute_RelationType.GUID_Parent = objOList_attribute_relationtype.First().ID_Parent_Other
            objOItem_Attribute_RelationType.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_token = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_token".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_token.Count > 0 Then
            objOItem_Attribute_Object = New clsOntologyItem
            objOItem_Attribute_Object.GUID = objOList_attribute_token.First().ID_Other
            objOItem_Attribute_Object.Name = objOList_attribute_token.First().Name_Other
            objOItem_Attribute_Object.GUID_Parent = objOList_attribute_token.First().ID_Parent_Other
            objOItem_Attribute_Object.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_type = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_type".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_type.Count > 0 Then
            objOItem_Attribute_Type = New clsOntologyItem
            objOItem_Attribute_Type.GUID = objOList_attribute_type.First().ID_Other
            objOItem_Attribute_Type.Name = objOList_attribute_type.First().Name_Other
            objOItem_Attribute_Type.GUID_Parent = objOList_attribute_type.First().ID_Parent_Other
            objOItem_Attribute_Type.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_RelationTypes()
        Dim objOList_relationtype_belonging_attribute = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_attribute".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_attribute.Count > 0 Then
            objOItem_RelationType_belonging_Attribute = New clsOntologyItem
            objOItem_RelationType_belonging_Attribute.GUID = objOList_relationtype_belonging_attribute.First().ID_Other
            objOItem_RelationType_belonging_Attribute.Name = objOList_relationtype_belonging_attribute.First().Name_Other
            objOItem_RelationType_belonging_Attribute.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
            End If

        Dim objOList_relationtype_belonging_token = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_token".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_token.Count > 0 Then
            objOItem_RelationType_belonging_Object = New clsOntologyItem
            objOItem_RelationType_belonging_Object.GUID = objOList_relationtype_belonging_token.First().ID_Other
            objOItem_RelationType_belonging_Object.Name = objOList_relationtype_belonging_token.First().Name_Other
            objOItem_RelationType_belonging_Object.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
            End If

        Dim objOList_relationtype_belonging_type = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_type".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_type.Count > 0 Then
            objOItem_RelationType_belonging_Type = New clsOntologyItem
            objOItem_RelationType_belonging_Type.GUID = objOList_relationtype_belonging_type.First().ID_Other
            objOItem_RelationType_belonging_Type.Name = objOList_relationtype_belonging_type.First().Name_Other
            objOItem_RelationType_belonging_Type.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
            End If

        Dim objOList_relationtype_belongsto = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belongsto".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belongsto.Count > 0 Then
            objOItem_RelationType_belongsTo = New clsOntologyItem
            objOItem_RelationType_belongsTo.GUID = objOList_relationtype_belongsto.First().ID_Other
            objOItem_RelationType_belongsTo.Name = objOList_relationtype_belongsto.First().Name_Other
            objOItem_RelationType_belongsTo.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
            End If

        Dim objOList_relationtype_is_on = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_is_on".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_is_on.Count > 0 Then
            objOItem_RelationType_is_on = New clsOntologyItem
            objOItem_RelationType_is_on.GUID = objOList_relationtype_is_on.First().ID_Other
            objOItem_RelationType_is_on.Name = objOList_relationtype_is_on.First().Name_Other
            objOItem_RelationType_is_on.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
            End If

        Dim objOList_relationtype_isinstate = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_isinstate".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_isinstate.Count > 0 Then
            objOItem_RelationType_isInState = New clsOntologyItem
            objOItem_RelationType_isInState.GUID = objOList_relationtype_isinstate.First().ID_Other
            objOItem_RelationType_isInState.Name = objOList_relationtype_isinstate.First().Name_Other
            objOItem_RelationType_isInState.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
            End If

        Dim objOList_relationtype_offered_by = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_offered_by".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_offered_by.Count > 0 Then
            objOItem_RelationType_offered_by = New clsOntologyItem
            objOItem_RelationType_offered_by.GUID = objOList_relationtype_offered_by.First().ID_Other
            objOItem_RelationType_offered_by.Name = objOList_relationtype_offered_by.First().Name_Other
            objOItem_RelationType_offered_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
            End If

        Dim objOList_relationtype_offers_for = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_offers_for".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_offers_for.Count > 0 Then
            objOItem_RelationType_offers_for = New clsOntologyItem
            objOItem_RelationType_offers_for.GUID = objOList_relationtype_offers_for.First().ID_Other
            objOItem_RelationType_offers_for.Name = objOList_relationtype_offers_for.First().Name_Other
            objOItem_RelationType_offers_for.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
            End If

        Dim objOList_relationtype_relationtype = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_relationtype".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_relationtype.Count > 0 Then
            objOItem_RelationType_RelationType = New clsOntologyItem
            objOItem_RelationType_RelationType.GUID = objOList_relationtype_relationtype.First().ID_Other
            objOItem_RelationType_RelationType.Name = objOList_relationtype_relationtype.First().Name_Other
            objOItem_RelationType_RelationType.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
            End If

        Dim objOList_relationtype_sourceslocatedin = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_sourceslocatedin".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_sourceslocatedin.Count > 0 Then
            objOItem_RelationType_SourcesLocatedIn = New clsOntologyItem
            objOItem_RelationType_SourcesLocatedIn.GUID = objOList_relationtype_sourceslocatedin.First().ID_Other
            objOItem_RelationType_SourcesLocatedIn.Name = objOList_relationtype_sourceslocatedin.First().Name_Other
            objOItem_RelationType_SourcesLocatedIn.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
            End If

        Dim objOList_relationtype_superordinate = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_superordinate".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_superordinate.Count > 0 Then
            objOItem_RelationType_superordinate = New clsOntologyItem
            objOItem_RelationType_superordinate.GUID = objOList_relationtype_superordinate.First().ID_Other
            objOItem_RelationType_superordinate.Name = objOList_relationtype_superordinate.First().Name_Other
            objOItem_RelationType_superordinate.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
            End If


    End Sub

    Private Sub get_Config_Objects()
        Dim objOList_Object_Sem_Manager = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "object_sem_manager".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_Object_Sem_Manager.Count > 0 Then
            objOItem_Module = New clsOntologyItem
            objOItem_Module.GUID = objOList_Object_Sem_Manager.First().ID_Other
            objOItem_Module.Name = objOList_Object_Sem_Manager.First().Name_Other
            objOItem_Module.GUID_Parent = objOList_Object_Sem_Manager.First().ID_Parent_Other
            objOItem_Module.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Object_filter_integration_level = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_filter_integration_level".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_Object_filter_integration_level.Count > 0 Then
            objOItem_Object_Filter_Integration_Level = New clsOntologyItem
            objOItem_Object_Filter_Integration_Level.GUID = objOList_Object_filter_integration_level.First().ID_Other
            objOItem_Object_Filter_Integration_Level.Name = objOList_Object_filter_integration_level.First().Name_Other
            objOItem_Object_Filter_Integration_Level.GUID_Parent = objOList_Object_filter_integration_level.First().ID_Parent_Other
            objOItem_Object_Filter_Integration_Level.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Object_full_integration_level = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_full_integration_level".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_Object_full_integration_level.Count > 0 Then
            objOItem_Object_Full_Integration_Level = New clsOntologyItem
            objOItem_Object_Full_Integration_Level.GUID = objOList_Object_full_integration_level.First().ID_Other
            objOItem_Object_Full_Integration_Level.Name = objOList_Object_full_integration_level.First().Name_Other
            objOItem_Object_Full_Integration_Level.GUID_Parent = objOList_Object_full_integration_level.First().ID_Parent_Other
            objOItem_Object_Full_Integration_Level.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Object_information_integration_level = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_information_integration_level".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_Object_information_integration_level.Count > 0 Then
            objOItem_Object_Information_Integration_Level = New clsOntologyItem
            objOItem_Object_Information_Integration_Level.GUID = objOList_Object_information_integration_level.First().ID_Other
            objOItem_Object_Information_Integration_Level.Name = objOList_Object_information_integration_level.First().Name_Other
            objOItem_Object_Information_Integration_Level.GUID_Parent = objOList_Object_information_integration_level.First().ID_Parent_Other
            objOItem_Object_Information_Integration_Level.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Object_integration_level_menu = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_integration_level_menu".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()
        If objOList_Object_integration_level_menu.Count > 0 Then
            objOItem_Object_Integration_Level_Menu = New clsOntologyItem
            objOItem_Object_Integration_Level_Menu.GUID = objOList_Object_integration_level_menu.First().ID_Other
            objOItem_Object_Integration_Level_Menu.Name = objOList_Object_integration_level_menu.First().Name_Other
            objOItem_Object_Integration_Level_Menu.GUID_Parent = objOList_Object_integration_level_menu.First().ID_Parent_Other
            objOItem_Object_Integration_Level_Menu.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Object_type_integration_level = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_type_integration_level".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_Object_type_integration_level.Count > 0 Then
            objOItem_Object_Class_Integration_Level = New clsOntologyItem
            objOItem_Object_Class_Integration_Level.GUID = objOList_Object_type_integration_level.First().ID_Other
            objOItem_Object_Class_Integration_Level.Name = objOList_Object_type_integration_level.First().Name_Other
            objOItem_Object_Class_Integration_Level.GUID_Parent = objOList_Object_type_integration_level.First().ID_Parent_Other
            objOItem_Object_Class_Integration_Level.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_Classes()
        Dim objOList_Class_developmentversion = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_developmentversion".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_Class_developmentversion.Count > 0 Then
            objOItem_Class_DevelopmentVersion = New clsOntologyItem
            objOItem_Class_DevelopmentVersion.GUID = objOList_Class_developmentversion.First().ID_Other
            objOItem_Class_DevelopmentVersion.Name = objOList_Class_developmentversion.First().Name_Other
            objOItem_Class_DevelopmentVersion.GUID_Parent = objOList_Class_developmentversion.First().ID_Parent_Other
            objOItem_Class_DevelopmentVersion.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_direction = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_direction".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_Class_direction.Count > 0 Then
            objOItem_Class_Direction = New clsOntologyItem
            objOItem_Class_Direction.GUID = objOList_Class_direction.First().ID_Other
            objOItem_Class_Direction.Name = objOList_Class_direction.First().Name_Other
            objOItem_Class_Direction.GUID_Parent = objOList_Class_direction.First().ID_Parent_Other
            objOItem_Class_Direction.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        
        Dim objOList_Class_filesystem_management = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_filesystem_management".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_Class_filesystem_management.Count > 0 Then
            objOItem_Class_Filesystem_Management = New clsOntologyItem
            objOItem_Class_Filesystem_Management.GUID = objOList_Class_filesystem_management.First().ID_Other
            objOItem_Class_Filesystem_Management.Name = objOList_Class_filesystem_management.First().Name_Other
            objOItem_Class_Filesystem_Management.GUID_Parent = objOList_Class_filesystem_management.First().ID_Parent_Other
            objOItem_Class_Filesystem_Management.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_folder = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_folder".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_Class_folder.Count > 0 Then
            objOItem_Class_Folder = New clsOntologyItem
            objOItem_Class_Folder.GUID = objOList_Class_folder.First().ID_Other
            objOItem_Class_Folder.Name = objOList_Class_folder.First().Name_Other
            objOItem_Class_Folder.GUID_Parent = objOList_Class_folder.First().ID_Parent_Other
            objOItem_Class_Folder.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_integration_level = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_integration_level".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_Class_integration_level.Count > 0 Then
            objOItem_Class_Integration_Level = New clsOntologyItem
            objOItem_Class_Integration_Level.GUID = objOList_Class_integration_level.First().ID_Other
            objOItem_Class_Integration_Level.Name = objOList_Class_integration_level.First().Name_Other
            objOItem_Class_Integration_Level.GUID_Parent = objOList_Class_integration_level.First().ID_Parent_Other
            objOItem_Class_Integration_Level.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_logstate = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_logstate".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_Class_logstate.Count > 0 Then
            objOItem_Class_Logstate = New clsOntologyItem
            objOItem_Class_Logstate.GUID = objOList_Class_logstate.First().ID_Other
            objOItem_Class_Logstate.Name = objOList_Class_logstate.First().Name_Other
            objOItem_Class_Logstate.GUID_Parent = objOList_Class_logstate.First().ID_Parent_Other
            objOItem_Class_Logstate.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_module = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_module".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_Class_module.Count > 0 Then
            objOItem_Class_Module = New clsOntologyItem
            objOItem_Class_Module.GUID = objOList_Class_module.First().ID_Other
            objOItem_Class_Module.Name = objOList_Class_module.First().Name_Other
            objOItem_Class_Module.GUID_Parent = objOList_Class_module.First().ID_Parent_Other
            objOItem_Class_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_module_activator = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_module_activator".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_Class_module_activator.Count > 0 Then
            objOItem_Class_Module_Activator = New clsOntologyItem
            objOItem_Class_Module_Activator.GUID = objOList_Class_module_activator.First().ID_Other
            objOItem_Class_Module_Activator.Name = objOList_Class_module_activator.First().Name_Other
            objOItem_Class_Module_Activator.GUID_Parent = objOList_Class_module_activator.First().ID_Parent_Other
            objOItem_Class_Module_Activator.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_module_management = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_module_management".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_Class_module_management.Count > 0 Then
            objOItem_Class_Module_Management = New clsOntologyItem
            objOItem_Class_Module_Management.GUID = objOList_Class_module_management.First().ID_Other
            objOItem_Class_Module_Management.Name = objOList_Class_module_management.First().Name_Other
            objOItem_Class_Module_Management.GUID_Parent = objOList_Class_module_management.First().ID_Parent_Other
            objOItem_Class_Module_Management.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_sem_manager = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_sem_manager".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_Class_sem_manager.Count > 0 Then
            objOItem_Class_Sem_Manager = New clsOntologyItem
            objOItem_Class_Sem_Manager.GUID = objOList_Class_sem_manager.First().ID_Other
            objOItem_Class_Sem_Manager.Name = objOList_Class_sem_manager.First().Name_Other
            objOItem_Class_Sem_Manager.GUID_Parent = objOList_Class_sem_manager.First().ID_Parent_Other
            objOItem_Class_Sem_Manager.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_server = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_server".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_Class_server.Count > 0 Then
            objOItem_Class_Server = New clsOntologyItem
            objOItem_Class_Server.GUID = objOList_Class_server.First().ID_Other
            objOItem_Class_Server.Name = objOList_Class_server.First().Name_Other
            objOItem_Class_Server.GUID_Parent = objOList_Class_server.First().ID_Parent_Other
            objOItem_Class_Server.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_softwaredevelopment = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_softwaredevelopment".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_Class_softwaredevelopment.Count > 0 Then
            objOItem_Class_SoftwareDevelopment = New clsOntologyItem
            objOItem_Class_SoftwareDevelopment.GUID = objOList_Class_softwaredevelopment.First().ID_Other
            objOItem_Class_SoftwareDevelopment.Name = objOList_Class_softwaredevelopment.First().Name_Other
            objOItem_Class_SoftwareDevelopment.GUID_Parent = objOList_Class_softwaredevelopment.First().ID_Parent_Other
            objOItem_Class_SoftwareDevelopment.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Class_system = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_system".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_Class_system.Count > 0 Then
            objOItem_Class_System = New clsOntologyItem
            objOItem_Class_System.GUID = objOList_Class_system.First().ID_Other
            objOItem_Class_System.Name = objOList_Class_system.First().Name_Other
            objOItem_Class_System.GUID_Parent = objOList_Class_system.First().ID_Parent_Other
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
        objImport = New clsImport(objGlobals)
    End Sub


    
End Class
