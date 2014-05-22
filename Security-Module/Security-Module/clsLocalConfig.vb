Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports System.Reflection

Public Class clsLocalConfig
    Private cstrID_Ontology As String = "628efc33b2214d89857ba3e8904a937b"

    Private Const cint_ImageID_Root As Integer = 0
    Private Const cint_ImageID_Type_Passwords_Closed As Integer = 1
    Private Const cint_ImageID_Type_Passwords_Opened As Integer = 2
    Private Const cint_ImageID_Related As Integer = 3
    Private Const cint_ImageID_Type_Related_Closed As Integer = 4
    Private Const cint_ImageID_Type_Related_Open As Integer = 5
    Private Const cint_ImageID_Token As Integer = 6

    Private objImport As clsImport

    Private objGlobals As clsGlobals

    Private objOItem_DevConfig As New clsOntologyItem
    Private objOItem_BaseConfig As New clsOntologyItem
    Private objOItem_User As clsOntologyItem

    Private objDBLevel_Config1 As clsDBLevel
    Private objDBLevel_Config2 As clsDBLevel

    Private objModuleForSession As clsOntologyItem

    'Attributes
    Private objOItem_attribute_dbPostfix As New clsOntologyItem
    Private objOItem_Attribute_Master_Password As New clsOntologyItem


    'RelationTypes
    Private objOItem_RelationType_belonging_Endoding_Types As New clsOntologyItem
    Private objOItem_RelationType_belongsTo As New clsOntologyItem
    Private objOItem_RelationType_contains As New clsOntologyItem
    Private objOItem_RelationType_encoded_by As New clsOntologyItem
    Private objOItem_RelationType_offered_by As New clsOntologyItem
    Private objOItem_RelationType_secured_by As New clsOntologyItem

    'Objects
    Private objOItem_Token_Search_Template_Name_ As New clsOntologyItem
    Private objOItem_Token_Search_Template_Related_Sem_Item_ As New clsOntologyItem
    Private objOItem_Token_Search_Template_Related_Type_ As New clsOntologyItem
    Private objOItem_Module As New clsOntologyItem

    'Classes
    Private objOItem_Type_Group As New clsOntologyItem
    Private objOItem_Type_Module As New clsOntologyItem
    Private objOItem_Type_Security_Module As New clsOntologyItem
    Private objOItem_type_User As New clsOntologyItem
    Private objOItem_class_security_session As clsOntologyItem
    Private objOItem_class_server As clsOntologyItem


    Public ReadOnly Property ImageID_Related As Integer
        Get
            Return cint_ImageID_Related
        End Get
    End Property

    Public ReadOnly Property ImageID_Root As Integer
        Get
            Return cint_ImageID_Root
        End Get
    End Property

    Public ReadOnly Property ImageID_Token As Integer
        Get
            Return cint_ImageID_Token
        End Get
    End Property

    Public ReadOnly Property ImageID_Type_Passwords_Closed As Integer
        Get
            Return cint_ImageID_Type_Passwords_Closed
        End Get
    End Property

    Public ReadOnly Property ImageID_Type_Passwords_Opened As Integer
        Get
            Return cint_ImageID_Type_Passwords_Opened
        End Get
    End Property

    Public ReadOnly Property ImageID_Type_Related_Closed As Integer
        Get
            Return cint_ImageID_Type_Related_Closed
        End Get
    End Property

    Public ReadOnly Property ImageID_Type_Related_Open As Integer
        Get
            Return cint_ImageID_Type_Related_Open
        End Get
    End Property

    Public ReadOnly Property OItem_class_server As clsOntologyItem
        Get
            Return objOItem_class_server
        End Get
    End Property


    Public Property OItem_ModuleForSession As clsOntologyItem
        Get
            Return objModuleForSession
        End Get
        Set(value As clsOntologyItem)
            objModuleForSession = value
        End Set
    End Property

    'Attributes
    Public ReadOnly Property OItem_attribute_dbPostfix() As clsOntologyItem
        Get
            Return objOItem_attribute_dbPostfix
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Master_Password() As clsOntologyItem
        Get
            Return objOItem_Attribute_Master_Password
        End Get
    End Property

    'RelationTypes
    Public ReadOnly Property OItem_RelationType_belonging_Endoding_Types() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Endoding_Types
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belongsTo() As clsOntologyItem
        Get
            Return objOItem_RelationType_belongsTo
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_contains() As clsOntologyItem
        Get
            Return objOItem_RelationType_contains
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_encoded_by() As clsOntologyItem
        Get
            Return objOItem_RelationType_encoded_by
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_offered_by() As clsOntologyItem
        Get
            Return objOItem_RelationType_offered_by
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_secured_by() As clsOntologyItem
        Get
            Return objOItem_RelationType_secured_by
        End Get
    End Property


    'Objects
    Public ReadOnly Property OItem_Token_Search_Template_Name_() As clsOntologyItem
        Get
            Return objOItem_Token_Search_Template_Name_
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Search_Template_Related_Sem_Item_() As clsOntologyItem
        Get
            Return objOItem_Token_Search_Template_Related_Sem_Item_
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Search_Template_Related_Type_() As clsOntologyItem
        Get
            Return objOItem_Token_Search_Template_Related_Type_
        End Get
    End Property

    Public ReadOnly Property OItem_Module() As clsOntologyItem
        Get
            Return objOItem_Module
        End Get
    End Property


    'Classes
    Public ReadOnly Property OItem_Type_Group() As clsOntologyItem
        Get
            Return objOItem_Type_Group
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Module() As clsOntologyItem
        Get
            Return objOItem_Type_Module
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Security_Module() As clsOntologyItem
        Get
            Return objOItem_Type_Security_Module
        End Get
    End Property

    Public ReadOnly Property OItem_type_User() As clsOntologyItem
        Get
            Return objOItem_type_User
        End Get
    End Property

    Public ReadOnly Property OItem_class_security_session As clsOntologyItem
        Get
            Return objOItem_class_security_session
        End Get
    End Property

    Public ReadOnly Property OItem_BaseConfig As clsOntologyItem
        Get
            Return objOItem_BaseConfig
        End Get
    End Property

    Public Property OItem_User As clsOntologyItem
        Get
            Return objOItem_User
        End Get
        Set(ByVal value As clsOntologyItem)
            objOItem_User = value
        End Set
    End Property


    Private Sub get_BaseConfig()
        Dim oList_ObjectRel As New List(Of clsObjectRel)


        oList_ObjectRel.Clear()
        oList_ObjectRel.Add(New clsObjectRel(Nothing, _
                                                Nothing, _
                                                objOItem_Type_Security_Module.GUID, _
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

        If objDBLevel_Config1.OList_ObjectRel.Any() Then
            objOItem_BaseConfig = New clsOntologyItem(objDBLevel_Config1.OList_ObjectRel(0).ID_Object, _
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

    Public ReadOnly Property Globals() As clsGlobals
        Get
            Return objGlobals
        End Get
    End Property

    Public Sub New(ByVal Globals As clsGlobals)
        objGlobals = Globals
        set_DBConnection()


        get_Config()
        get_BaseConfig()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Config1 = New clsDBLevel(objGlobals)
        objDBLevel_Config2 = New clsDBLevel(objGlobals)
        objImport = New clsImport(objGlobals)
    End Sub

    Private Sub get_Config()
        Try
            get_Data_DevelopmentConfig()
            get_Config_AttributeTypes()
            get_Config_RelationTypes()
            get_Config_Classes()
            get_Config_Objects()
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

    Private Sub get_Config_AttributeTypes()

        Dim objOList_attribute_dbpostfix = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_dbpostfix".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_dbpostfix.Any() Then
            objOItem_attribute_dbPostfix = New clsOntologyItem
            objOItem_attribute_dbPostfix.GUID = objOList_attribute_dbpostfix.First().ID_Other
            objOItem_attribute_dbPostfix.Name = objOList_attribute_dbpostfix.First().Name_Other
            objOItem_attribute_dbPostfix.GUID_Parent = objOList_attribute_dbpostfix.First().ID_Parent_Other
            objOItem_attribute_dbPostfix.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_master_password = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_master_password".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_master_password.Any() Then
            objOItem_Attribute_Master_Password = New clsOntologyItem
            objOItem_Attribute_Master_Password.GUID = objOList_attribute_master_password.First().ID_Other
            objOItem_Attribute_Master_Password.Name = objOList_attribute_master_password.First().Name_Other
            objOItem_Attribute_Master_Password.GUID_Parent = objOList_attribute_master_password.First().ID_Parent_Other
            objOItem_Attribute_Master_Password.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_RelationTypes()
        Dim objOList_relationtype_belonging_endoding_types = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_endoding_types".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_endoding_types.Any() Then
            objOItem_RelationType_belonging_Endoding_Types = New clsOntologyItem
            objOItem_RelationType_belonging_Endoding_Types.GUID = objOList_relationtype_belonging_endoding_types.First().ID_Other
            objOItem_RelationType_belonging_Endoding_Types.Name = objOList_relationtype_belonging_endoding_types.First().Name_Other
            objOItem_RelationType_belonging_Endoding_Types.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belongsto = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belongsto".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belongsto.Any() Then
            objOItem_RelationType_belongsTo = New clsOntologyItem
            objOItem_RelationType_belongsTo.GUID = objOList_relationtype_belongsto.First().ID_Other
            objOItem_RelationType_belongsTo.Name = objOList_relationtype_belongsto.First().Name_Other
            objOItem_RelationType_belongsTo.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_contains = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_contains".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_contains.Any() Then
            objOItem_RelationType_contains = New clsOntologyItem
            objOItem_RelationType_contains.GUID = objOList_relationtype_contains.First().ID_Other
            objOItem_RelationType_contains.Name = objOList_relationtype_contains.First().Name_Other
            objOItem_RelationType_contains.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_encoded_by = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_encoded_by".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_encoded_by.Any() Then
            objOItem_RelationType_encoded_by = New clsOntologyItem
            objOItem_RelationType_encoded_by.GUID = objOList_relationtype_encoded_by.First().ID_Other
            objOItem_RelationType_encoded_by.Name = objOList_relationtype_encoded_by.First().Name_Other
            objOItem_RelationType_encoded_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_offered_by = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_offered_by".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_offered_by.Any() Then
            objOItem_RelationType_offered_by = New clsOntologyItem
            objOItem_RelationType_offered_by.GUID = objOList_relationtype_offered_by.First().ID_Other
            objOItem_RelationType_offered_by.Name = objOList_relationtype_offered_by.First().Name_Other
            objOItem_RelationType_offered_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_secured_by = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_secured_by".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_secured_by.Any() Then
            objOItem_RelationType_secured_by = New clsOntologyItem
            objOItem_RelationType_secured_by.GUID = objOList_relationtype_secured_by.First().ID_Other
            objOItem_RelationType_secured_by.Name = objOList_relationtype_secured_by.First().Name_Other
            objOItem_RelationType_secured_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_Objects()

        Dim objOList_Module = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "object_security_module".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_Module.Any() Then
            objOItem_Module = New clsOntologyItem
            objOItem_Module.GUID = objOList_Module.First().ID_Other
            objOItem_Module.Name = objOList_Module.First().Name_Other
            objOItem_Module.GUID_Parent = objOList_Module.First().ID_Parent_Other
            objOItem_Module.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_name_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_search_template_name_".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_token_search_template_name_.Any() Then
            objOItem_Token_Search_Template_Name_ = New clsOntologyItem
            objOItem_Token_Search_Template_Name_.GUID = objOList_token_search_template_name_.First().ID_Other
            objOItem_Token_Search_Template_Name_.Name = objOList_token_search_template_name_.First().Name_Other
            objOItem_Token_Search_Template_Name_.GUID_Parent = objOList_token_search_template_name_.First().ID_Parent_Other
            objOItem_Token_Search_Template_Name_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_related_sem_item_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_search_template_related_sem_item_".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_token_search_template_related_sem_item_.Any() Then
            objOItem_Token_Search_Template_Related_Sem_Item_ = New clsOntologyItem
            objOItem_Token_Search_Template_Related_Sem_Item_.GUID = objOList_token_search_template_related_sem_item_.First().ID_Other
            objOItem_Token_Search_Template_Related_Sem_Item_.Name = objOList_token_search_template_related_sem_item_.First().Name_Other
            objOItem_Token_Search_Template_Related_Sem_Item_.GUID_Parent = objOList_token_search_template_related_sem_item_.First().ID_Parent_Other
            objOItem_Token_Search_Template_Related_Sem_Item_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_related_type_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_search_template_related_type_".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_token_search_template_related_type_.Any() Then
            objOItem_Token_Search_Template_Related_Type_ = New clsOntologyItem
            objOItem_Token_Search_Template_Related_Type_.GUID = objOList_token_search_template_related_type_.First().ID_Other
            objOItem_Token_Search_Template_Related_Type_.Name = objOList_token_search_template_related_type_.First().Name_Other
            objOItem_Token_Search_Template_Related_Type_.GUID_Parent = objOList_token_search_template_related_type_.First().ID_Parent_Other
            objOItem_Token_Search_Template_Related_Type_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_Classes()
        Dim objOList_class_server = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_server".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_server.Count > 0 Then
            objOItem_class_server = New clsOntologyItem
            objOItem_class_server.GUID = objOList_class_server.First().ID_Other
            objOItem_class_server.Name = objOList_class_server.First().Name_Other
            objOItem_class_server.GUID_Parent = objOList_class_server.First().ID_Parent_Other
            objOItem_class_server.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_class_security_session = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_security_session".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_security_session.Count > 0 Then
            objOItem_class_security_session = New clsOntologyItem
            objOItem_class_security_session.GUID = objOList_class_security_session.First().ID_Other
            objOItem_class_security_session.Name = objOList_class_security_session.First().Name_Other
            objOItem_class_security_session.GUID_Parent = objOList_class_security_session.First().ID_Parent_Other
            objOItem_class_security_session.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_group = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_group".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_group.Any() Then
            objOItem_Type_Group = New clsOntologyItem
            objOItem_Type_Group.GUID = objOList_type_group.First().ID_Other
            objOItem_Type_Group.Name = objOList_type_group.First().Name_Other
            objOItem_Type_Group.GUID_Parent = objOList_type_group.First().ID_Parent_Other
            objOItem_Type_Group.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_module = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_module".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_module.Any() Then
            objOItem_Type_Module = New clsOntologyItem
            objOItem_Type_Module.GUID = objOList_type_module.First().ID_Other
            objOItem_Type_Module.Name = objOList_type_module.First().Name_Other
            objOItem_Type_Module.GUID_Parent = objOList_type_module.First().ID_Parent_Other
            objOItem_Type_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_security_module = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_security_module".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_security_module.Any() Then
            objOItem_Type_Security_Module = New clsOntologyItem
            objOItem_Type_Security_Module.GUID = objOList_type_security_module.First().ID_Other
            objOItem_Type_Security_Module.Name = objOList_type_security_module.First().Name_Other
            objOItem_Type_Security_Module.GUID_Parent = objOList_type_security_module.First().ID_Parent_Other
            objOItem_Type_Security_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_user = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_user".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_user.Any() Then
            objOItem_type_User = New clsOntologyItem
            objOItem_type_User.GUID = objOList_type_user.First().ID_Other
            objOItem_type_User.Name = objOList_type_user.First().Name_Other
            objOItem_type_User.GUID_Parent = objOList_type_user.First().ID_Parent_Other
            objOItem_type_User.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If


    End Sub
End Class
