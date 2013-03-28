Imports Ontolog_Module
Public Class clsLocalConfig
    Private cstr_ID_SoftwareDevelopment As String = "1886b9082ead4045b7e59a84705e26a8"
    Private cstr_ID_Class_SoftwareDevelopment As String = "132a845f849f4f6b86847ab3fd068824"
    Private cstr_ID_Class_DevelopmentConfig As String = "c6c9bcb80ac947139417eeec1453026c"
    Private cstr_ID_Class_ConfigItem As String = "13c09f11175c4eefbc8a0fd8e86d557f"
    Private cstr_ID_RelType_needs As String = "fafc1464815f45969737bcbc96bd744a"
    Private cstr_ID_RelType_contains As String = "e971160347db44d8a476fe88290639a4"
    Private cstr_ID_RelType_belongsTo As String = "e07469d9766c443e85266d9c684f944f"

    Private Const cint_ImageID_Root As Integer = 0
    Private Const cint_ImageID_Type_Passwords_Closed As Integer = 1
    Private Const cint_ImageID_Type_Passwords_Opened As Integer = 2
    Private Const cint_ImageID_Related As Integer = 3
    Private Const cint_ImageID_Type_Related_Closed As Integer = 4
    Private Const cint_ImageID_Type_Related_Open As Integer = 5
    Private Const cint_ImageID_Token As Integer = 6

    Private objGlobals As clsGlobals

    Private objOItem_DevConfig As New clsOntologyItem

    Private objDBLevel_Config1 As clsDBLevel
    Private objDBLevel_Config2 As clsDBLevel

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

    'Classes
    Private objOItem_Type_Group As New clsOntologyItem
    Private objOItem_Type_Module As New clsOntologyItem
    Private objOItem_Type_Security_Module As New clsOntologyItem
    Private objOItem_type_User As New clsOntologyItem


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

    Public ReadOnly Property Globals() As clsGlobals
        Get
            Return objGlobals
        End Get
    End Property

    Public Sub New(ByVal Globals As clsGlobals)
        objGlobals = Globals
        set_DBConnection()

        get_Data_DevelopmentConfig()
        get_Config()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Config1 = New clsDBLevel(objGlobals)
        objDBLevel_Config2 = New clsDBLevel(objGlobals)
    End Sub

    Private Sub get_Config()
        get_Config_AttributeTypes()
        get_Config_RelationTypes()
        get_Config_Classes()
        get_Config_Objects()

    End Sub

    Private Sub get_Config_AttributeTypes()
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

        Dim objOList_attribute_master_password = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_master_password" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_master_password.Count > 0 Then
            objOItem_Attribute_Master_Password = New clsOntologyItem
            objOItem_Attribute_Master_Password.GUID = objOList_attribute_master_password(0).ID_Other
            objOItem_Attribute_Master_Password.Name = objOList_attribute_master_password(0).Name_Other
            objOItem_Attribute_Master_Password.GUID_Parent = objOList_attribute_master_password(0).ID_Parent_Other
            objOItem_Attribute_Master_Password.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_RelationTypes()
        Dim objOList_relationtype_belonging_endoding_types = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "relationtype_belonging_endoding_types" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belonging_endoding_types.Count > 0 Then
            objOItem_RelationType_belonging_Endoding_Types = New clsOntologyItem
            objOItem_RelationType_belonging_Endoding_Types.GUID = objOList_relationtype_belonging_endoding_types(0).ID_Other
            objOItem_RelationType_belonging_Endoding_Types.Name = objOList_relationtype_belonging_endoding_types(0).Name_Other
            objOItem_RelationType_belonging_Endoding_Types.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belongsto = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belongsto" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belongsto.Count > 0 Then
            objOItem_RelationType_belongsTo = New clsOntologyItem
            objOItem_RelationType_belongsTo.GUID = objOList_relationtype_belongsto(0).ID_Other
            objOItem_RelationType_belongsTo.Name = objOList_relationtype_belongsto(0).Name_Other
            objOItem_RelationType_belongsTo.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_contains = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_contains" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_contains.Count > 0 Then
            objOItem_RelationType_contains = New clsOntologyItem
            objOItem_RelationType_contains.GUID = objOList_relationtype_contains(0).ID_Other
            objOItem_RelationType_contains.Name = objOList_relationtype_contains(0).Name_Other
            objOItem_RelationType_contains.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_encoded_by = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_encoded_by" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_encoded_by.Count > 0 Then
            objOItem_RelationType_encoded_by = New clsOntologyItem
            objOItem_RelationType_encoded_by.GUID = objOList_relationtype_encoded_by(0).ID_Other
            objOItem_RelationType_encoded_by.Name = objOList_relationtype_encoded_by(0).Name_Other
            objOItem_RelationType_encoded_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_offered_by = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_offered_by" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_offered_by.Count > 0 Then
            objOItem_RelationType_offered_by = New clsOntologyItem
            objOItem_RelationType_offered_by.GUID = objOList_relationtype_offered_by(0).ID_Other
            objOItem_RelationType_offered_by.Name = objOList_relationtype_offered_by(0).Name_Other
            objOItem_RelationType_offered_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_secured_by = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_secured_by" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_secured_by.Count > 0 Then
            objOItem_RelationType_secured_by = New clsOntologyItem
            objOItem_RelationType_secured_by.GUID = objOList_relationtype_secured_by(0).ID_Other
            objOItem_RelationType_secured_by.Name = objOList_relationtype_secured_by(0).Name_Other
            objOItem_RelationType_secured_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_Objects()
        Dim objOList_token_search_template_name_ = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "token_search_template_name_" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_search_template_name_.Count > 0 Then
            objOItem_Token_Search_Template_Name_ = New clsOntologyItem
            objOItem_Token_Search_Template_Name_.GUID = objOList_token_search_template_name_(0).ID_Other
            objOItem_Token_Search_Template_Name_.Name = objOList_token_search_template_name_(0).Name_Other
            objOItem_Token_Search_Template_Name_.GUID_Parent = objOList_token_search_template_name_(0).ID_Parent_Other
            objOItem_Token_Search_Template_Name_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_related_sem_item_ = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_search_template_related_sem_item_" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_search_template_related_sem_item_.Count > 0 Then
            objOItem_Token_Search_Template_Related_Sem_Item_ = New clsOntologyItem
            objOItem_Token_Search_Template_Related_Sem_Item_.GUID = objOList_token_search_template_related_sem_item_(0).ID_Other
            objOItem_Token_Search_Template_Related_Sem_Item_.Name = objOList_token_search_template_related_sem_item_(0).Name_Other
            objOItem_Token_Search_Template_Related_Sem_Item_.GUID_Parent = objOList_token_search_template_related_sem_item_(0).ID_Parent_Other
            objOItem_Token_Search_Template_Related_Sem_Item_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_related_type_ = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_search_template_related_type_" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_search_template_related_type_.Count > 0 Then
            objOItem_Token_Search_Template_Related_Type_ = New clsOntologyItem
            objOItem_Token_Search_Template_Related_Type_.GUID = objOList_token_search_template_related_type_(0).ID_Other
            objOItem_Token_Search_Template_Related_Type_.Name = objOList_token_search_template_related_type_(0).Name_Other
            objOItem_Token_Search_Template_Related_Type_.GUID_Parent = objOList_token_search_template_related_type_(0).ID_Parent_Other
            objOItem_Token_Search_Template_Related_Type_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_Classes()
        Dim objOList_type_group = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "type_group" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_group.Count > 0 Then
            objOItem_Type_Group = New clsOntologyItem
            objOItem_Type_Group.GUID = objOList_type_group(0).ID_Other
            objOItem_Type_Group.Name = objOList_type_group(0).Name_Other
            objOItem_Type_Group.GUID_Parent = objOList_type_group(0).ID_Parent_Other
            objOItem_Type_Group.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_module = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_module" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_module.Count > 0 Then
            objOItem_Type_Module = New clsOntologyItem
            objOItem_Type_Module.GUID = objOList_type_module(0).ID_Other
            objOItem_Type_Module.Name = objOList_type_module(0).Name_Other
            objOItem_Type_Module.GUID_Parent = objOList_type_module(0).ID_Parent_Other
            objOItem_Type_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_security_module = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_security_module" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_security_module.Count > 0 Then
            objOItem_Type_Security_Module = New clsOntologyItem
            objOItem_Type_Security_Module.GUID = objOList_type_security_module(0).ID_Other
            objOItem_Type_Security_Module.Name = objOList_type_security_module(0).Name_Other
            objOItem_Type_Security_Module.GUID_Parent = objOList_type_security_module(0).ID_Parent_Other
            objOItem_Type_Security_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_user = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_user" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_user.Count > 0 Then
            objOItem_type_User = New clsOntologyItem
            objOItem_type_User.GUID = objOList_type_user(0).ID_Other
            objOItem_type_User.Name = objOList_type_user(0).Name_Other
            objOItem_type_User.GUID_Parent = objOList_type_user(0).ID_Parent_Other
            objOItem_type_User.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If


    End Sub
End Class
