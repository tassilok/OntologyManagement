Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports System.Reflection
Public Class clsLocalConfig

    Private Const cint_ImageID_Root As Integer = 0
    Private Const cint_ImageID_Dev_Open As Integer = 1
    Private Const cint_ImageID_Dev_Closed As Integer = 2

    Private objImport As clsImport

    Private cstrID_Ontology As String = "d453931eab534a3eb0dcb3498e35c841"

    Private objGlobals As clsGlobals

    Private objOItem_DevConfig As New clsOntologyItem
    Private objOItem_BaseConfig As New clsOntologyItem

    Private objDBLevel_Config1 As clsDBLevel
    Private objDBLevel_Config2 As clsDBLevel

    'Attributes
    Private objOItem_Attribute_DateTimeStamp As New clsOntologyItem
    Private objOItem_Attribute_Message As New clsOntologyItem
    Private objOItem_Attribute_Major As New clsOntologyItem
    Private objOItem_Attribute_Minor As New clsOntologyItem
    Private objOItem_Attribute_Build As New clsOntologyItem
    Private objOItem_Attribute_Revision As New clsOntologyItem
    Private objOItem_Attribute_XML_Text As New clsOntologyItem
    Private objOItem_Attribute_caption As New clsOntologyItem
    Private objOItem_Attribute_ImageID As New clsOntologyItem
    Private objOItem_Attribute_Grant As New clsOntologyItem
    Private objOItem_attributetype_standard As New clsOntologyItem

    'RelationTypes
    Private objOItem_relationtype_subpath_versionfile As clsOntologyItem
    Private objOItem_RelationType_belongsTo As New clsOntologyItem
    Private objOItem_RelationType_offered_by As New clsOntologyItem
    Private objOItem_RelationType_isInState As New clsOntologyItem
    Private objOItem_RelationType_isSubordinated As New clsOntologyItem
    Private objOItem_RelationType_wasDevelopedBy As New clsOntologyItem
    Private objOitem_RelationType_wasCreatedBy As New clsOntologyItem
    Private objOitem_RelationType_isWrittenIn As New clsOntologyItem
    Private objOitem_RelationType_Standard As New clsOntologyItem
    Private objOitem_RelationType_SourcesLocatedIn As New clsOntologyItem
    Private objOitem_RelationType_Possible As New clsOntologyItem
    Private objOitem_RelationType_Request As New clsOntologyItem
    Private objOitem_RelationType_provides As New clsOntologyItem
    Private objOitem_RelationType_Happened As New clsOntologyItem
    Private objOitem_RelationType_offers As New clsOntologyItem
    Private objOitem_RelationType_additional As New clsOntologyItem
    Private objOitem_RelationType_isDescribedBy As New clsOntologyItem
    Private objOitem_RelationType_needs As New clsOntologyItem
    Private objOitem_RelationType_contains As New clsOntologyItem
    Private objOitem_RelationType_works_off As New clsOntologyItem
    Private objOitem_RelationType_directed_by As New clsOntologyItem
    Private objOitem_RelationType_describes As New clsOntologyItem
    Private objOitem_RelationType_alternative_for As New clsOntologyItem
    Private objOitem_RelationType_export_to As New clsOntologyItem
    Private objOitem_RelationType_is_of_Type As New clsOntologyItem
    Private objOitem_RelationType_located_in As New clsOntologyItem
    Private objOitem_RelationType_is_defined_by As New clsOntologyItem
    Private objOitem_RelationType_User_Message As New clsOntologyItem
    Private objOitem_RelationType_Input_Message As New clsOntologyItem
    Private objOitem_RelationType_Error_Message As New clsOntologyItem
    Private objOitem_RelationType_superordinate As New clsOntologyItem
    Private objOitem_RelationType_invoking_Actor As New clsOntologyItem
    Private objOitem_RelationType_invoked_Actor As New clsOntologyItem
    Private objOitem_RelationType_access_by As New clsOntologyItem
    Private objOitem_RelationType_belonging_Paramter As New clsOntologyItem
    Private objOitem_RelationType_is_instance_of As New clsOntologyItem
    Private objOitem_RelationType_ignore As New clsOntologyItem
    Private objOitem_RelationType_handles As New clsOntologyItem
    Private objOitem_RelationType_initializing As New clsOntologyItem
    Private objOitem_RelationType_belongingResource As New clsOntologyItem
    Private objOItem_relationtype_property As clsOntologyItem
    Private objOItem_relationtype_declaration As clsOntologyItem
    Private objOItem_relationtype_relationtype As clsOntologyItem
    Private objOItem_relationtype_object As clsOntologyItem
    Private objOItem_relationtype_document_container As clsOntologyItem
    Private objOItem_relationtype_class As clsOntologyItem
    Private objOItem_relationtype_attribute As clsOntologyItem
    Private objOItem_relationtype_project_file As clsOntologyItem

    'Classes
    Private objOItem_class_path As clsOntologyItem
    Private objOItem_class_software_project As clsOntologyItem
    Private objOItem_Class_SoftwareDevelopment As New clsOntologyItem
    Private objOItem_Class_DevelopmentVersion As New clsOntologyItem
    Private objOItem_Class_LogState As New clsOntologyItem
    Private objOItem_Class_User As New clsOntologyItem
    Private objOItem_Class_ProgramingLanguage As New clsOntologyItem
    Private objOItem_Class_Folder As New clsOntologyItem
    Private objOItem_Class_Language As New clsOntologyItem
    Private objOItem_Class_LogEntry As New clsOntologyItem
    Private objOItem_Class_LocalizedDescription As New clsOntologyItem
    Private objOItem_Class_DevelopmentConfig As New clsOntologyItem
    Private objOItem_Class_DevelopmentConfigItem As New clsOntologyItem
    Private objOItem_Class_Development_Structure As New clsOntologyItem
    Private objOItem_Class_Process As New clsOntologyItem
    Private objOItem_Class_Parameter_Dev_Structure As New clsOntologyItem
    Private objOItem_Class_Directions As New clsOntologyItem
    Private objOItem_Class_Localized_Names As New clsOntologyItem
    Private objOItem_Class_DBSchema_Of_Application As New clsOntologyItem
    Private objOItem_Class_DB_Schema_Type As New clsOntologyItem
    Private objOItem_Class_File As New clsOntologyItem
    Private objOItem_Class_Database_on_Server As New clsOntologyItem
    Private objOItem_Class_Database As New clsOntologyItem
    Private objOItem_Class_Server As New clsOntologyItem
    Private objOItem_Class_GUI_Entires As New clsOntologyItem
    Private objOItem_Class_GUI_Caption As New clsOntologyItem
    Private objOItem_Class_ToolTip_Messages As New clsOntologyItem
    Private objOItem_Class_Messages As New clsOntologyItem
    Private objOItem_Class_Localized_Message As New clsOntologyItem
    Private objOItem_Class_Dev_Structure_Invoke As New clsOntologyItem
    Private objOItem_Class_Structure_Type_with_Aspects As New clsOntologyItem
    Private objOItem_Class_Structure_Type As New clsOntologyItem
    Private objOItem_Class_Structure_Validity As New clsOntologyItem
    Private objOItem_Class_Objects As New clsOntologyItem
    Private objOItem_Class_Dev_Structure__Process_Type_to_Process_ As New clsOntologyItem
    Private objOItem_Class_Dev_Structure As New clsOntologyItem
    Private objOItem_Class_Scene As New clsOntologyItem
    Private objOItem_Class_Module As New clsOntologyItem
    Private objOItem_Class_Development_Libraries As New clsOntologyItem
    Private objOItem_Class_Image_Video_Management As New clsOntologyItem
    Private objOItem_Class_Sem_Items_to_expot_with_Children As New clsOntologyItem
    Private objOItem_Class_Export_Mode As New clsOntologyItem
    Private objOItem_Class_Database_Schema As New clsOntologyItem
    Private objOItem_Class_Development_Module As New clsOntologyItem
    Private objOItem_type_ontology_export As New clsOntologyItem
    Private objOItem_class_code_templates As clsOntologyItem
    Private objOItem_class_xml As clsOntologyItem
    Private objOItem_class_syntax_highlighting__scintillanet_ As clsOntologyItem

    'Objects
    Private objOItem_object_version As clsOntologyItem
    Private objOItem_object_visual_studio_version_parser As clsOntologyItem
    Private objOitem_Object_LogState_Active As New clsOntologyItem
    Private objOitem_Object_LogState_Inactive As New clsOntologyItem
    Private objOitem_Object_LogState_Open As New clsOntologyItem
    Private objOitem_Object_LogState_Changed As New clsOntologyItem
    Private objOitem_Object_LogState_Obsolete As New clsOntologyItem
    Private objOitem_Object_LogState_Information As New clsOntologyItem
    Private objOitem_Object_LogState_Request As New clsOntologyItem
    Private objOitem_Object_LogState_VersionChanged As New clsOntologyItem
    Private objOitem_Object_LogState_Create As New clsOntologyItem
    Private objOitem_Object_LogState_ConfigItemAdded As New clsOntologyItem
    Private objOitem_Object_clsLocalConfig_xml_XML As New clsOntologyItem
    Private objOitem_Object_Declaration_Configitems_XML As New clsOntologyItem
    Private objOitem_Object_Initialize_RelationType__ConfigItem__XML As New clsOntologyItem
    Private objOitem_Object_Initialize_Object__ConfigItem__XML As New clsOntologyItem
    Private objOitem_Object_Initilize_Attribute__ConfigItem__XML As New clsOntologyItem
    Private objOitem_Object_Initilize_Type__ConfigItem__XML As New clsOntologyItem
    Private objOitem_Object_Property_ConfigItem_XML As New clsOntologyItem
    Private objOitem_Object_Directions_IN As New clsOntologyItem
    Private objOitem_Object_Directions_OUT As New clsOntologyItem
    Private objOitem_Object_PossibleStates_DevelopmentStandard As New clsOntologyItem
    Private objOitem_Object_Variable_List_Properties As New clsOntologyItem
    Private objOitem_Object_Variable_List_Initialize_ConfigItems_Types As New clsOntologyItem
    Private objOitem_Object_Variable_List_Initialize_ConfigItems_Object As New clsOntologyItem
    Private objOitem_Object_Variable_List_Initialize_ConfigItems_RelationTypes As New clsOntologyItem
    Private objOitem_Object_Variable_List_Initialize_ConfigItems_Attributes As New clsOntologyItem
    Private objOitem_Object_Variable_List_Declaration_ConfigItems As New clsOntologyItem
    Private objOitem_Object_Dev_Structure_Schleife As New clsOntologyItem
    Private objOitem_Object_Dev_Structure_Return As New clsOntologyItem
    Private objOitem_Object_Dev_Structure_Database As New clsOntologyItem
    Private objOitem_Object_Module_Development_Management As New clsOntologyItem
    Private objOitem_Object_Export_Mode_Grant_Children_of_Item__Object_of_Type_ As New clsOntologyItem
    Private objOitem_Object_Export_Mode_Deny_Only_Children__Object_of_Type_ As New clsOntologyItem
    Private objOitem_Object_Export_Mode_Deny_Item_with_Children__Type___Object_ As New clsOntologyItem
    Private objOitem_Object_Export_Mode_Normal As New clsOntologyItem
    Private objOitem_Object_DB_Schema_Type_User As New clsOntologyItem
    Private objOitem_Object_DB_Schema_Type_Module As New clsOntologyItem
    Private objOitem_Object_DB_Schema_Type_Config As New clsOntologyItem
    Private objOItem_Token_XML_clsLocalConfig_ontology_xml As New clsOntologyItem
    Private objOItem_Token_XML_Initilize_Type__ConfigItem_Ontology_ As New clsOntologyItem
    Private objOItem_Token_XML_Initilize_Attribute__ConfigItem_Ontology_ As New clsOntologyItem
    Private objOItem_Token_XML_Initialize_Token__ConfigItem_Ontology_ As New clsOntologyItem
    Private objOItem_Token_XML_Initialize_RelationType__ConfigItem_Ontology_ As New clsOntologyItem
    Private objOItem_Token_XML_Property_Ontology_ConfigItem As New clsOntologyItem
    Private objOItem_Token_XML_Declaration_Ontology_Configitems As New clsOntologyItem
    Private objOItem_Token_Variable_Name_ConfigItem As New clsOntologyItem
    Private objOItem_object_vb_net As clsOntologyItem
    Private objOItem_object_c_ As clsOntologyItem

    Private objOItem_Module As New clsOntologyItem

    'Attributes
    Public ReadOnly Property OItem_Attribute_Build As clsOntologyItem
        Get
            Return objOItem_Attribute_Build
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_caption As clsOntologyItem
        Get
            Return objOItem_Attribute_caption
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_DateTimeStamp As clsOntologyItem
        Get
            Return objOItem_Attribute_DateTimeStamp
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Grant As clsOntologyItem
        Get
            Return objOItem_Attribute_Grant
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_ImageID As clsOntologyItem
        Get
            Return objOItem_Attribute_ImageID
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Major As clsOntologyItem
        Get
            Return objOItem_Attribute_Major
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Message As clsOntologyItem
        Get
            Return objOItem_Attribute_Message
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Minor As clsOntologyItem
        Get
            Return objOItem_Attribute_Minor
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Revision As clsOntologyItem
        Get
            Return objOItem_Attribute_Revision
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_XML_Text As clsOntologyItem
        Get
            Return objOItem_Attribute_XML_Text
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Standard As clsOntologyItem
        Get
            Return objOItem_attributetype_standard
        End Get
    End Property

    'RelationTypes
    Public ReadOnly Property OItem_relationtype_subpath_versionfile As clsOntologyItem
        Get
            Return objOItem_relationtype_subpath_versionfile
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_project_file As clsOntologyItem
        Get
            Return objOItem_relationtype_project_file
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_access_by As clsOntologyItem
        Get
            Return objOitem_RelationType_access_by
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_additional As clsOntologyItem
        Get
            Return objOitem_RelationType_additional
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_alternative_for As clsOntologyItem
        Get
            Return objOitem_RelationType_alternative_for
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_belonging_Paramter As clsOntologyItem
        Get
            Return objOitem_RelationType_belonging_Paramter
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belongsTo As clsOntologyItem
        Get
            Return objOItem_RelationType_belongsTo
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belongingResource As clsOntologyItem
        Get
            Return objOitem_RelationType_belongingResource
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_contains As clsOntologyItem
        Get
            Return objOitem_RelationType_contains
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_describes As clsOntologyItem
        Get
            Return objOitem_RelationType_describes
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_directed_by As clsOntologyItem
        Get
            Return objOitem_RelationType_directed_by
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_Error_Message As clsOntologyItem
        Get
            Return objOitem_RelationType_Error_Message
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_export_to As clsOntologyItem
        Get
            Return objOitem_RelationType_export_to
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_handles As clsOntologyItem
        Get
            Return objOitem_RelationType_handles
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_Happened As clsOntologyItem
        Get
            Return objOitem_RelationType_Happened
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_ignore As clsOntologyItem
        Get
            Return objOitem_RelationType_ignore
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_initializing As clsOntologyItem
        Get
            Return objOitem_RelationType_initializing
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_Input_Message As clsOntologyItem
        Get
            Return objOitem_RelationType_Input_Message
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_invoked_Actor As clsOntologyItem
        Get
            Return objOitem_RelationType_invoked_Actor
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_invoking_Actor As clsOntologyItem
        Get
            Return objOitem_RelationType_invoking_Actor
        End Get
    End Property


    Public ReadOnly Property Oitem_RelationType_is_defined_by As clsOntologyItem
        Get
            Return objOitem_RelationType_is_defined_by
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_is_instance_of As clsOntologyItem
        Get
            Return objOitem_RelationType_is_instance_of
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_is_of_Type As clsOntologyItem
        Get
            Return objOitem_RelationType_is_of_Type
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_isDescribedBy As clsOntologyItem
        Get
            Return objOitem_RelationType_isDescribedBy
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_isInState As clsOntologyItem
        Get
            Return objOItem_RelationType_isInState
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_isSubordinated As clsOntologyItem
        Get
            Return objOItem_RelationType_isSubordinated
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_isWrittenIn As clsOntologyItem
        Get
            Return objOitem_RelationType_isWrittenIn
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_located_in As clsOntologyItem
        Get
            Return objOitem_RelationType_located_in
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_needs As clsOntologyItem
        Get
            Return objOitem_RelationType_needs
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_offered_by As clsOntologyItem
        Get
            Return objOItem_RelationType_offered_by
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_offers As clsOntologyItem
        Get
            Return objOitem_RelationType_offers
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_Possible As clsOntologyItem
        Get
            Return objOitem_RelationType_Possible
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_provides As clsOntologyItem
        Get
            Return objOitem_RelationType_provides
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_Request As clsOntologyItem
        Get
            Return objOitem_RelationType_Request
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_SourcesLocatedIn As clsOntologyItem
        Get
            Return objOitem_RelationType_SourcesLocatedIn
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_Standard As clsOntologyItem
        Get
            Return objOitem_RelationType_Standard
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_superordinate As clsOntologyItem
        Get
            Return objOitem_RelationType_superordinate
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_User_Message As clsOntologyItem
        Get
            Return objOitem_RelationType_User_Message
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_wasCreatedBy As clsOntologyItem
        Get
            Return objOitem_RelationType_wasCreatedBy
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_wasDevelopedBy As clsOntologyItem
        Get
            Return objOItem_RelationType_wasDevelopedBy
        End Get
    End Property

    Public ReadOnly Property Oitem_RelationType_works_off As clsOntologyItem
        Get
            Return objOitem_RelationType_works_off
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_attribute As clsOntologyItem
        Get
            Return objOItem_relationtype_attribute
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_document_container As clsOntologyItem
        Get
            Return objOItem_relationtype_document_container
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_property As clsOntologyItem
        Get
            Return objOItem_relationtype_property
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_class As clsOntologyItem
        Get
            Return objOItem_relationtype_class
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_object As clsOntologyItem
        Get
            Return objOItem_relationtype_object
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_relationtype As clsOntologyItem
        Get
            Return objOItem_relationtype_relationtype
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_declaration As clsOntologyItem
        Get
            Return objOItem_relationtype_declaration
        End Get
    End Property

    'Classes
    Public ReadOnly Property OItem_class_path As clsOntologyItem
        Get
            Return objOItem_class_path
        End Get
    End Property

    Public ReadOnly Property OItem_class_software_project As clsOntologyItem
        Get
            Return objOItem_class_software_project
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Database As clsOntologyItem
        Get
            Return objOItem_Class_Database
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Database_on_Server As clsOntologyItem
        Get
            Return objOItem_Class_Database_on_Server
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Database_Schema As clsOntologyItem
        Get
            Return objOItem_Class_Database_Schema
        End Get
    End Property

    Public ReadOnly Property OItem_Class_DB_Schema_Type As clsOntologyItem
        Get
            Return objOItem_Class_DB_Schema_Type
        End Get
    End Property

    Public ReadOnly Property OItem_Class_DBSchema_Of_Application As clsOntologyItem
        Get
            Return objOItem_Class_DBSchema_Of_Application
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Dev_Structure As clsOntologyItem
        Get
            Return objOItem_Class_Dev_Structure
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Dev_Structure__Process_Type_to_Process_ As clsOntologyItem
        Get
            Return objOItem_Class_Dev_Structure__Process_Type_to_Process_
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Dev_Structure_Invoke As clsOntologyItem
        Get
            Return objOItem_Class_Dev_Structure_Invoke
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Development_Libraries As clsOntologyItem
        Get
            Return objOItem_Class_Development_Libraries
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Development_Module As clsOntologyItem
        Get
            Return objOItem_Class_Development_Module
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Development_Structure As clsOntologyItem
        Get
            Return objOItem_Class_Development_Structure
        End Get
    End Property

    Public ReadOnly Property OItem_Class_DevelopmentConfig As clsOntologyItem
        Get
            Return objOItem_Class_DevelopmentConfig
        End Get
    End Property

    Public ReadOnly Property OItem_Class_DevelopmentConfigItem As clsOntologyItem
        Get
            Return objOItem_Class_DevelopmentConfigItem
        End Get
    End Property

    Public ReadOnly Property OItem_Class_DevelopmentVersion As clsOntologyItem
        Get
            Return objOItem_Class_DevelopmentVersion
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Directions As clsOntologyItem
        Get
            Return objOItem_Class_Directions
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Export_Mode As clsOntologyItem
        Get
            Return objOItem_Class_Export_Mode
        End Get
    End Property

    Public ReadOnly Property OItem_Class_File As clsOntologyItem
        Get
            Return objOItem_Class_File
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Folder As clsOntologyItem
        Get
            Return objOItem_Class_Folder
        End Get
    End Property

    Public ReadOnly Property OItem_Class_GUI_Caption As clsOntologyItem
        Get
            Return objOItem_Class_GUI_Caption
        End Get
    End Property

    Public ReadOnly Property OItem_Class_GUI_Entires As clsOntologyItem
        Get
            Return objOItem_Class_GUI_Entires
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Image_Video_Management As clsOntologyItem
        Get
            Return objOItem_Class_Image_Video_Management
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Language As clsOntologyItem
        Get
            Return objOItem_Class_Language
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Localized_Message As clsOntologyItem
        Get
            Return objOItem_Class_Localized_Message
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Localized_Names As clsOntologyItem
        Get
            Return objOItem_Class_Localized_Names
        End Get
    End Property

    Public ReadOnly Property OItem_Class_LocalizedDescription As clsOntologyItem
        Get
            Return objOItem_Class_LocalizedDescription
        End Get
    End Property

    Public ReadOnly Property OItem_Class_LogEntry As clsOntologyItem
        Get
            Return objOItem_Class_LogEntry
        End Get
    End Property

    Public ReadOnly Property OItem_Class_LogState As clsOntologyItem
        Get
            Return objOItem_Class_LogState
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Messages As clsOntologyItem
        Get
            Return objOItem_Class_Messages
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Module As clsOntologyItem
        Get
            Return objOItem_Class_Module
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Objects As clsOntologyItem
        Get
            Return objOItem_Class_Objects
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Parameter_Dev_Structure As clsOntologyItem
        Get
            Return objOItem_Class_Parameter_Dev_Structure
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Process As clsOntologyItem
        Get
            Return objOItem_Class_Process
        End Get
    End Property

    Public ReadOnly Property OItem_Class_ProgramingLanguage As clsOntologyItem
        Get
            Return objOItem_Class_ProgramingLanguage
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Scene As clsOntologyItem
        Get
            Return objOItem_Class_Scene
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Sem_Items_to_expot_with_Children As clsOntologyItem
        Get
            Return objOItem_Class_Sem_Items_to_expot_with_Children
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Server As clsOntologyItem
        Get
            Return objOItem_Class_Server
        End Get
    End Property

    Public ReadOnly Property OItem_Class_SoftwareDevelopment As clsOntologyItem
        Get
            Return objOItem_Class_SoftwareDevelopment
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Structure_Type As clsOntologyItem
        Get
            Return objOItem_Class_Structure_Type
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Structure_Type_with_Aspects As clsOntologyItem
        Get
            Return objOItem_Class_Structure_Type_with_Aspects
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Structure_Validity As clsOntologyItem
        Get
            Return objOItem_Class_Structure_Validity
        End Get
    End Property

    Public ReadOnly Property OItem_Class_ToolTip_Messages As clsOntologyItem
        Get
            Return objOItem_Class_ToolTip_Messages
        End Get
    End Property

    Public ReadOnly Property OItem_Class_User As clsOntologyItem
        Get
            Return objOItem_Class_User
        End Get
    End Property

    Public ReadOnly Property OItem_type_ontology_export() As clsOntologyItem
        Get
            Return objOItem_type_ontology_export
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Code_Template As clsOntologyItem
        Get
            Return objOItem_class_code_templates
        End Get
    End Property

    Public ReadOnly Property OItem_Class_XML As clsOntologyItem
        Get
            Return objOItem_class_xml
        End Get
    End Property

    Public ReadOnly Property OItem_class_syntax_highlighting__scintillanet_ As clsOntologyItem
        Get
            Return objOItem_class_syntax_highlighting__scintillanet_
        End Get
    End Property


    'Objects
    Public ReadOnly Property OItem_object_version As clsOntologyItem
        Get
            Return objOItem_object_version
        End Get
    End Property

    Public ReadOnly Property OItem_object_visual_studio_version_parser As clsOntologyItem
        Get
            Return objOItem_object_visual_studio_version_parser
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_clsLocalConfig_xml_XML As clsOntologyItem
        Get
            Return objOitem_Object_clsLocalConfig_xml_XML
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_DB_Schema_Type_Config As clsOntologyItem
        Get
            Return objOitem_Object_DB_Schema_Type_Config
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_DB_Schema_Type_Module As clsOntologyItem
        Get
            Return objOitem_Object_DB_Schema_Type_Module
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_DB_Schema_Type_User As clsOntologyItem
        Get
            Return objOitem_Object_DB_Schema_Type_User
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Declaration_Configitems_XML As clsOntologyItem
        Get
            Return objOitem_Object_Declaration_Configitems_XML
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Dev_Structure_Database As clsOntologyItem
        Get
            Return objOitem_Object_Dev_Structure_Database
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Dev_Structure_Return As clsOntologyItem
        Get
            Return objOitem_Object_Dev_Structure_Return
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Dev_Structure_Schleife As clsOntologyItem
        Get
            Return objOitem_Object_Dev_Structure_Schleife
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Directions_IN As clsOntologyItem
        Get
            Return objOitem_Object_Directions_IN
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Directions_OUT As clsOntologyItem
        Get
            Return objOitem_Object_Directions_OUT
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Export_Mode_Deny_Item_with_Children__Type___Object_ As clsOntologyItem
        Get
            Return objOitem_Object_Export_Mode_Deny_Item_with_Children__Type___Object_
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Export_Mode_Deny_Only_Children__Object_of_Type_ As clsOntologyItem
        Get
            Return objOitem_Object_Export_Mode_Deny_Only_Children__Object_of_Type_
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Export_Mode_Grant_Children_of_Item__Object_of_Type_ As clsOntologyItem
        Get
            Return objOitem_Object_Export_Mode_Grant_Children_of_Item__Object_of_Type_
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Export_Mode_Normal As clsOntologyItem
        Get
            Return objOitem_Object_Export_Mode_Normal
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Initialize_Object__ConfigItem__XML As clsOntologyItem
        Get
            Return objOitem_Object_Initialize_Object__ConfigItem__XML
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Initialize_RelationType__ConfigItem__XML As clsOntologyItem
        Get
            Return objOitem_Object_Initialize_RelationType__ConfigItem__XML
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Initilize_Attribute__ConfigItem__XML As clsOntologyItem
        Get
            Return objOitem_Object_Initilize_Attribute__ConfigItem__XML
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Initilize_Type__ConfigItem__XML As clsOntologyItem
        Get
            Return objOitem_Object_Initilize_Type__ConfigItem__XML
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_LogState_Active As clsOntologyItem
        Get
            Return objOitem_Object_LogState_Active
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_LogState_Changed As clsOntologyItem
        Get
            Return objOitem_Object_LogState_Changed
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_LogState_ConfigItemAdded As clsOntologyItem
        Get
            Return objOitem_Object_LogState_ConfigItemAdded
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_LogState_Create As clsOntologyItem
        Get
            Return objOitem_Object_LogState_Create
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_LogState_Inactive As clsOntologyItem
        Get
            Return objOitem_Object_LogState_Inactive
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_LogState_Information As clsOntologyItem
        Get
            Return objOitem_Object_LogState_Information
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_LogState_Obsolete As clsOntologyItem
        Get
            Return objOitem_Object_LogState_Obsolete
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_LogState_Open As clsOntologyItem
        Get
            Return objOitem_Object_LogState_Open
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_LogState_Request As clsOntologyItem
        Get
            Return objOitem_Object_LogState_Request
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_LogState_VersionChanged As clsOntologyItem
        Get
            Return objOitem_Object_LogState_VersionChanged
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Module_Development_Management As clsOntologyItem
        Get
            Return objOitem_Object_Module_Development_Management
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_PossibleStates_DevelopmentStandard As clsOntologyItem
        Get
            Return objOitem_Object_PossibleStates_DevelopmentStandard
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Property_ConfigItem_XML As clsOntologyItem
        Get
            Return objOitem_Object_Property_ConfigItem_XML
        End Get
    End Property

    Public ReadOnly Property OItem_Object_VB_Net As clsOntologyItem
        Get
            Return objOItem_object_vb_net
        End Get
    End Property

    Public ReadOnly Property OItem_Object_C_ As clsOntologyItem
        Get
            Return objOItem_object_c_
        End Get
    End Property




    Public Property OItem_User As clsOntologyItem


    Public ReadOnly Property Oitem_Object_Variable_List_Declaration_ConfigItems As clsOntologyItem
        Get
            Return objOitem_Object_Variable_List_Declaration_ConfigItems
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Variable_List_Initialize_ConfigItems_Attributes As clsOntologyItem
        Get
            Return objOitem_Object_Variable_List_Initialize_ConfigItems_Attributes
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Variable_List_Initialize_ConfigItems_Object As clsOntologyItem
        Get
            Return objOitem_Object_Variable_List_Initialize_ConfigItems_Object
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Variable_List_Initialize_ConfigItems_RelationTypes As clsOntologyItem
        Get
            Return objOitem_Object_Variable_List_Initialize_ConfigItems_RelationTypes
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Variable_List_Initialize_ConfigItems_Types As clsOntologyItem
        Get
            Return objOitem_Object_Variable_List_Initialize_ConfigItems_Types
        End Get
    End Property

    Public ReadOnly Property Oitem_Object_Variable_List_Properties As clsOntologyItem
        Get
            Return objOitem_Object_Variable_List_Properties
        End Get
    End Property

    Public ReadOnly Property OItem_Token_XML_clsLocalConfig_ontology_xml() As clsOntologyItem
        Get
            Return objOItem_Token_XML_clsLocalConfig_ontology_xml
        End Get
    End Property

    Public ReadOnly Property OItem_Token_XML_Initilize_Type__ConfigItem_Ontology_() As clsOntologyItem
        Get
            Return objOItem_Token_XML_Initilize_Type__ConfigItem_Ontology_
        End Get
    End Property

    Public ReadOnly Property OItem_Token_XML_Initilize_Attribute__ConfigItem_Ontology_() As clsOntologyItem
        Get
            Return objOItem_Token_XML_Initilize_Attribute__ConfigItem_Ontology_
        End Get
    End Property

    Public ReadOnly Property OItem_Token_XML_Initialize_Token__ConfigItem_Ontology_() As clsOntologyItem
        Get
            Return objOItem_Token_XML_Initialize_Token__ConfigItem_Ontology_
        End Get
    End Property

    Public ReadOnly Property OItem_Token_XML_Initialize_RelationType__ConfigItem_Ontology_() As clsOntologyItem
        Get
            Return objOItem_Token_XML_Initialize_RelationType__ConfigItem_Ontology_
        End Get
    End Property

    Public ReadOnly Property OItem_Token_XML_Property_Ontology_ConfigItem() As clsOntologyItem
        Get
            Return objOItem_Token_XML_Property_Ontology_ConfigItem
        End Get
    End Property

    Public ReadOnly Property OItem_Token_XML_Declaration_Ontology_Configitems() As clsOntologyItem
        Get
            Return objOItem_Token_XML_Declaration_Ontology_Configitems
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Variable_Name_ConfigItem() As clsOntologyItem
        Get
            Return objOItem_Token_Variable_Name_ConfigItem
        End Get
    End Property

    Public ReadOnly Property OItem_Module() As clsOntologyItem
        Get
            Return objOItem_Module
        End Get
    End Property


    Public ReadOnly Property ImageID_Root As Integer
        Get
            Return cint_ImageID_Root
        End Get
    End Property

    Public ReadOnly Property ImageID_Folder_Closed As Integer
        Get
            Return cint_ImageID_Dev_Closed
        End Get
    End Property

    Public ReadOnly Property ImageID_Folder_Opened As Integer
        Get
            Return cint_ImageID_Dev_Open
        End Get
    End Property

    Public ReadOnly Property ImageID_Form As Integer
        Get
            Return 1
        End Get
    End Property

    Public ReadOnly Property ImageID_GuiItem As Integer
        Get
            Return 2
        End Get
    End Property

    Public ReadOnly Property ImageID_Caption As Integer
        Get
            Return 3
        End Get
    End Property

    Public ReadOnly Property ImageID_ToolTip As Integer
        Get
            Return 4
        End Get
    End Property

    Public ReadOnly Property IdOntology As String
        Get
            Return cstrID_Ontology
        End Get
    End Property

    Private Sub get_Config_AttributeTypes()
        Dim objOList_Attribute_Standard = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attributetype_standard".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_Attribute_Standard.Count > 0 Then
            objOItem_attributetype_standard = New clsOntologyItem
            objOItem_attributetype_standard.GUID = objOList_Attribute_Standard(0).ID_Other
            objOItem_attributetype_standard.Name = objOList_Attribute_Standard(0).Name_Other
            objOItem_attributetype_standard.GUID_Parent = objOList_Attribute_Standard(0).ID_Parent_Other
            objOItem_attributetype_standard.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objADs = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_DateTimeStamp".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objADs.Count > 0 Then
            objOItem_Attribute_DateTimeStamp = New clsOntologyItem
            objOItem_Attribute_DateTimeStamp.GUID = objADs(0).ID_Other
            objOItem_Attribute_DateTimeStamp.Name = objADs(0).Name_Other
            objOItem_Attribute_DateTimeStamp.GUID_Parent = objADs(0).ID_Parent_Other
            objOItem_Attribute_DateTimeStamp.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objMSG = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_Message".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objMSG.Count > 0 Then
            objOItem_Attribute_Message = New clsOntologyItem
            objOItem_Attribute_Message.GUID = objMSG(0).ID_Other
            objOItem_Attribute_Message.Name = objMSG(0).Name_Other
            objOItem_Attribute_Message.GUID_Parent = objMSG(0).ID_Parent_Other
            objOItem_Attribute_Message.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objMAJ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_Major".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objMAJ.Count > 0 Then
            objOItem_Attribute_Message = New clsOntologyItem
            objOItem_Attribute_Message.GUID = objMAJ(0).ID_Other
            objOItem_Attribute_Message.Name = objMAJ(0).Name_Other
            objOItem_Attribute_Message.GUID_Parent = objMAJ(0).ID_Parent_Other
            objOItem_Attribute_Message.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objMIN = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_Minor".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objMIN.Count > 0 Then
            objOItem_Attribute_Minor = New clsOntologyItem
            objOItem_Attribute_Minor.GUID = objMIN(0).ID_Other
            objOItem_Attribute_Minor.Name = objMIN(0).Name_Other
            objOItem_Attribute_Minor.GUID_Parent = objMIN(0).ID_Parent_Other
            objOItem_Attribute_Minor.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBUILD = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_Build".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objBUILD.Count > 0 Then
            objOItem_Attribute_Build = New clsOntologyItem
            objOItem_Attribute_Build.GUID = objBUILD(0).ID_Other
            objOItem_Attribute_Build.Name = objBUILD(0).Name_Other
            objOItem_Attribute_Build.GUID_Parent = objBUILD(0).ID_Parent_Other
            objOItem_Attribute_Build.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRev = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_Revision".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objRev.Count > 0 Then
            objOItem_Attribute_Revision = New clsOntologyItem
            objOItem_Attribute_Revision.GUID = objRev(0).ID_Other
            objOItem_Attribute_Revision.Name = objRev(0).Name_Other
            objOItem_Attribute_Revision.GUID_Parent = objRev(0).ID_Parent_Other
            objOItem_Attribute_Revision.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objXMLT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_XML_Text".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objXMLT.Count > 0 Then
            objOItem_Attribute_XML_Text = New clsOntologyItem
            objOItem_Attribute_XML_Text.GUID = objXMLT(0).ID_Other
            objOItem_Attribute_XML_Text.Name = objXMLT(0).Name_Other
            objOItem_Attribute_XML_Text.GUID_Parent = objXMLT(0).ID_Parent_Other
            objOItem_Attribute_XML_Text.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCAPT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_caption".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objCAPT.Count > 0 Then
            objOItem_Attribute_caption = New clsOntologyItem
            objOItem_Attribute_caption.GUID = objCAPT(0).ID_Other
            objOItem_Attribute_caption.Name = objCAPT(0).Name_Other
            objOItem_Attribute_caption.GUID_Parent = objCAPT(0).ID_Parent_Other
            objOItem_Attribute_caption.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIMGID = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_ImageID".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objIMGID.Count > 0 Then
            objOItem_Attribute_ImageID = New clsOntologyItem
            objOItem_Attribute_ImageID.GUID = objIMGID(0).ID_Other
            objOItem_Attribute_ImageID.Name = objIMGID(0).Name_Other
            objOItem_Attribute_ImageID.GUID_Parent = objIMGID(0).ID_Parent_Other
            objOItem_Attribute_ImageID.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objGRNT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_Grant".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objGRNT.Count > 0 Then
            objOItem_Attribute_Grant = New clsOntologyItem
            objOItem_Attribute_Grant.GUID = objGRNT(0).ID_Other
            objOItem_Attribute_Grant.Name = objGRNT(0).Name_Other
            objOItem_Attribute_Grant.GUID_Parent = objGRNT(0).ID_Parent_Other
            objOItem_Attribute_Grant.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

    End Sub

    Private Sub get_Config_Classes()
        Dim objOList_class_syntax_highlighting__scintillanet_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_syntax_highlighting__scintillanet_".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_syntax_highlighting__scintillanet_.Count > 0 Then
            objOItem_class_syntax_highlighting__scintillanet_ = New clsOntologyItem
            objOItem_class_syntax_highlighting__scintillanet_.GUID = objOList_class_syntax_highlighting__scintillanet_.First().ID_Other
            objOItem_class_syntax_highlighting__scintillanet_.Name = objOList_class_syntax_highlighting__scintillanet_.First().Name_Other
            objOItem_class_syntax_highlighting__scintillanet_.GUID_Parent = objOList_class_syntax_highlighting__scintillanet_.First().ID_Parent_Other
            objOItem_class_syntax_highlighting__scintillanet_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_class_path = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_path".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_path.Count > 0 Then
            objOItem_class_path = New clsOntologyItem
            objOItem_class_path.GUID = objOList_class_path.First().ID_Other
            objOItem_class_path.Name = objOList_class_path.First().Name_Other
            objOItem_class_path.GUID_Parent = objOList_class_path.First().ID_Parent_Other
            objOItem_class_path.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_class_software_project = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_software_project".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_software_project.Count > 0 Then
            objOItem_class_software_project = New clsOntologyItem
            objOItem_class_software_project.GUID = objOList_class_software_project.First().ID_Other
            objOItem_class_software_project.Name = objOList_class_software_project.First().Name_Other
            objOItem_class_software_project.GUID_Parent = objOList_class_software_project.First().ID_Parent_Other
            objOItem_class_software_project.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_class_xml = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_xml".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_xml.Count > 0 Then
            objOItem_class_xml = New clsOntologyItem
            objOItem_class_xml.GUID = objOList_class_xml(0).ID_Other
            objOItem_class_xml.Name = objOList_class_xml(0).Name_Other
            objOItem_class_xml.GUID_Parent = objOList_class_xml(0).ID_Parent_Other
            objOItem_class_xml.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_class_Code_Templates = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_code_templates".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_Code_Templates.Count > 0 Then
            objOItem_class_code_templates = New clsOntologyItem
            objOItem_class_code_templates.GUID = objOList_class_Code_Templates(0).ID_Other
            objOItem_class_code_templates.Name = objOList_class_Code_Templates(0).Name_Other
            objOItem_class_code_templates.GUID_Parent = objOList_class_Code_Templates(0).ID_Parent_Other
            objOItem_class_code_templates.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_ontology_export = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_ontology_export".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_ontology_export.Count > 0 Then
            objOItem_type_ontology_export = New clsOntologyItem
            objOItem_type_ontology_export.GUID = objOList_type_ontology_export(0).ID_Other
            objOItem_type_ontology_export.Name = objOList_type_ontology_export(0).Name_Other
            objOItem_type_ontology_export.GUID_Parent = objOList_type_ontology_export(0).ID_Parent_Other
            objOItem_type_ontology_export.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSD = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_SoftwareDevelopment".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objSD.Count > 0 Then
            objOItem_Class_SoftwareDevelopment = New clsOntologyItem
            objOItem_Class_SoftwareDevelopment.GUID = objSD(0).ID_Other
            objOItem_Class_SoftwareDevelopment.Name = objSD(0).Name_Other
            objOItem_Class_SoftwareDevelopment.GUID_Parent = objSD(0).ID_Parent_Other
            objOItem_Class_SoftwareDevelopment.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDV = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_DevelopmentVersion".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDV.Count > 0 Then
            objOItem_Class_DevelopmentVersion = New clsOntologyItem
            objOItem_Class_DevelopmentVersion.GUID = objDV(0).ID_Other
            objOItem_Class_DevelopmentVersion.Name = objDV(0).Name_Other
            objOItem_Class_DevelopmentVersion.GUID_Parent = objDV(0).ID_Parent_Other
            objOItem_Class_DevelopmentVersion.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLS = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_Logstate".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objLS.Count > 0 Then
            objOItem_Class_LogState = New clsOntologyItem
            objOItem_Class_LogState.GUID = objLS(0).ID_Other
            objOItem_Class_LogState.Name = objLS(0).Name_Other
            objOItem_Class_LogState.GUID_Parent = objLS(0).ID_Parent_Other
            objOItem_Class_LogState.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objUSR = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_User".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objUSR.Count > 0 Then
            objOItem_Class_User = New clsOntologyItem
            objOItem_Class_User.GUID = objUSR(0).ID_Other
            objOItem_Class_User.Name = objUSR(0).Name_Other
            objOItem_Class_User.GUID_Parent = objUSR(0).ID_Parent_Other
            objOItem_Class_User.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPL = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_ProgramingLanguage".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objPL.Count > 0 Then
            objOItem_Class_ProgramingLanguage = New clsOntologyItem
            objOItem_Class_ProgramingLanguage.GUID = objPL(0).ID_Other
            objOItem_Class_ProgramingLanguage.Name = objPL(0).Name_Other
            objOItem_Class_ProgramingLanguage.GUID_Parent = objPL(0).ID_Parent_Other
            objOItem_Class_ProgramingLanguage.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFLDR = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_Folder".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objFLDR.Count > 0 Then
            objOItem_Class_Folder = New clsOntologyItem
            objOItem_Class_Folder.GUID = objFLDR(0).ID_Other
            objOItem_Class_Folder.Name = objFLDR(0).Name_Other
            objOItem_Class_Folder.GUID_Parent = objFLDR(0).ID_Parent_Other
            objOItem_Class_Folder.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLNG = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Language".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objLNG.Count > 0 Then
            objOItem_Class_Language = New clsOntologyItem
            objOItem_Class_Language.GUID = objLNG(0).ID_Other
            objOItem_Class_Language.Name = objLNG(0).Name_Other
            objOItem_Class_Language.GUID_Parent = objLNG(0).ID_Parent_Other
            objOItem_Class_Language.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGE = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_LogEntry".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objLOGE.Count > 0 Then
            objOItem_Class_LogEntry = New clsOntologyItem
            objOItem_Class_LogEntry.GUID = objLOGE(0).ID_Other
            objOItem_Class_LogEntry.Name = objLOGE(0).Name_Other
            objOItem_Class_LogEntry.GUID_Parent = objLOGE(0).ID_Parent_Other
            objOItem_Class_LogEntry.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOCD = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_LocalizedDescription".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objLOCD.Count > 0 Then
            objOItem_Class_LocalizedDescription = New clsOntologyItem
            objOItem_Class_LocalizedDescription.GUID = objLOCD(0).ID_Other
            objOItem_Class_LocalizedDescription.Name = objLOCD(0).Name_Other
            objOItem_Class_LocalizedDescription.GUID_Parent = objLOCD(0).ID_Parent_Other
            objOItem_Class_LocalizedDescription.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDEVC = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_DevelopmentConfig".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDEVC.Count > 0 Then
            objOItem_Class_DevelopmentConfig = New clsOntologyItem
            objOItem_Class_DevelopmentConfig.GUID = objDEVC(0).ID_Other
            objOItem_Class_DevelopmentConfig.Name = objDEVC(0).Name_Other
            objOItem_Class_DevelopmentConfig.GUID_Parent = objDEVC(0).ID_Parent_Other
            objOItem_Class_DevelopmentConfig.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDEVCI = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_DevelopmentConfigItem".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDEVCI.Count > 0 Then
            objOItem_Class_DevelopmentConfigItem = New clsOntologyItem
            objOItem_Class_DevelopmentConfigItem.GUID = objDEVCI(0).ID_Other
            objOItem_Class_DevelopmentConfigItem.Name = objDEVCI(0).Name_Other
            objOItem_Class_DevelopmentConfigItem.GUID_Parent = objDEVCI(0).ID_Parent_Other
            objOItem_Class_DevelopmentConfigItem.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDEVSTR = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Development_Structure".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDEVSTR.Count > 0 Then
            objOItem_Class_Development_Structure = New clsOntologyItem
            objOItem_Class_Development_Structure.GUID = objDEVSTR(0).ID_Other
            objOItem_Class_Development_Structure.Name = objDEVSTR(0).Name_Other
            objOItem_Class_Development_Structure.GUID_Parent = objDEVSTR(0).ID_Parent_Other
            objOItem_Class_Development_Structure.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPARDEVSTR = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Parameter_Dev_Structure".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objPARDEVSTR.Count > 0 Then
            objOItem_Class_Parameter_Dev_Structure = New clsOntologyItem
            objOItem_Class_Parameter_Dev_Structure.GUID = objPARDEVSTR(0).ID_Other
            objOItem_Class_Parameter_Dev_Structure.Name = objPARDEVSTR(0).Name_Other
            objOItem_Class_Parameter_Dev_Structure.GUID_Parent = objPARDEVSTR(0).ID_Parent_Other
            objOItem_Class_Parameter_Dev_Structure.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPROC = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Process".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objPROC.Count > 0 Then
            objOItem_Class_Process = New clsOntologyItem
            objOItem_Class_Process.GUID = objPROC(0).ID_Other
            objOItem_Class_Process.Name = objPROC(0).Name_Other
            objOItem_Class_Process.GUID_Parent = objPROC(0).ID_Parent_Other
            objOItem_Class_Process.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDIR = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Directions".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDIR.Count > 0 Then
            objOItem_Class_Directions = New clsOntologyItem
            objOItem_Class_Directions.GUID = objDIR(0).ID_Other
            objOItem_Class_Directions.Name = objDIR(0).Name_Other
            objOItem_Class_Directions.GUID_Parent = objDIR(0).ID_Parent_Other
            objOItem_Class_Directions.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOCN = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Localized_Names".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objLOCN.Count > 0 Then
            objOItem_Class_Localized_Names = New clsOntologyItem
            objOItem_Class_Localized_Names.GUID = objLOCN(0).ID_Other
            objOItem_Class_Localized_Names.Name = objLOCN(0).Name_Other
            objOItem_Class_Localized_Names.GUID_Parent = objLOCN(0).ID_Parent_Other
            objOItem_Class_Localized_Names.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBSOA = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_DBSchema_Of_Application".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDBSOA.Count > 0 Then
            objOItem_Class_DBSchema_Of_Application = New clsOntologyItem
            objOItem_Class_DBSchema_Of_Application.GUID = objDBSOA(0).ID_Other
            objOItem_Class_DBSchema_Of_Application.Name = objDBSOA(0).Name_Other
            objOItem_Class_DBSchema_Of_Application.GUID_Parent = objDBSOA(0).ID_Parent_Other
            objOItem_Class_DBSchema_Of_Application.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBST = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_DB_Schema_Type".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDBST.Count > 0 Then
            objOItem_Class_DB_Schema_Type = New clsOntologyItem
            objOItem_Class_DB_Schema_Type.GUID = objDBST(0).ID_Other
            objOItem_Class_DB_Schema_Type.Name = objDBST(0).Name_Other
            objOItem_Class_DB_Schema_Type.GUID_Parent = objDBST(0).ID_Parent_Other
            objOItem_Class_DB_Schema_Type.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFILE = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_File".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objFILE.Count > 0 Then
            objOItem_Class_File = New clsOntologyItem
            objOItem_Class_File.GUID = objFILE(0).ID_Other
            objOItem_Class_File.Name = objFILE(0).Name_Other
            objOItem_Class_File.GUID_Parent = objFILE(0).ID_Parent_Other
            objOItem_Class_File.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBOS = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Database_on_Server".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDBOS.Count > 0 Then
            objOItem_Class_Database_on_Server = New clsOntologyItem
            objOItem_Class_Database_on_Server.GUID = objDBOS(0).ID_Other
            objOItem_Class_Database_on_Server.Name = objDBOS(0).Name_Other
            objOItem_Class_Database_on_Server.GUID_Parent = objDBOS(0).ID_Parent_Other
            objOItem_Class_Database_on_Server.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDB = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Database".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDB.Count > 0 Then
            objOItem_Class_Database = New clsOntologyItem
            objOItem_Class_Database.GUID = objDB(0).ID_Other
            objOItem_Class_Database.Name = objDB(0).Name_Other
            objOItem_Class_Database.GUID_Parent = objDB(0).ID_Parent_Other
            objOItem_Class_Database.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSRV = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Server".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objSRV.Count > 0 Then
            objOItem_Class_Server = New clsOntologyItem
            objOItem_Class_Server.GUID = objSRV(0).ID_Other
            objOItem_Class_Server.Name = objSRV(0).Name_Other
            objOItem_Class_Server.GUID_Parent = objSRV(0).ID_Parent_Other
            objOItem_Class_Server.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objGUIC = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_GUI_Caption".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objGUIC.Count > 0 Then
            objOItem_Class_GUI_Caption = New clsOntologyItem
            objOItem_Class_GUI_Caption.GUID = objGUIC(0).ID_Other
            objOItem_Class_GUI_Caption.Name = objGUIC(0).Name_Other
            objOItem_Class_GUI_Caption.GUID_Parent = objGUIC(0).ID_Parent_Other
            objOItem_Class_GUI_Caption.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objGUIE = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_GUI_Entires".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objGUIE.Count > 0 Then
            objOItem_Class_GUI_Entires = New clsOntologyItem
            objOItem_Class_GUI_Entires.GUID = objGUIE(0).ID_Other
            objOItem_Class_GUI_Entires.Name = objGUIE(0).Name_Other
            objOItem_Class_GUI_Entires.GUID_Parent = objGUIE(0).ID_Parent_Other
            objOItem_Class_GUI_Entires.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objTTM = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_ToolTip_Messages".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objTTM.Count > 0 Then
            objOItem_Class_ToolTip_Messages = New clsOntologyItem
            objOItem_Class_ToolTip_Messages.GUID = objTTM(0).ID_Other
            objOItem_Class_ToolTip_Messages.Name = objTTM(0).Name_Other
            objOItem_Class_ToolTip_Messages.GUID_Parent = objTTM(0).ID_Parent_Other
            objOItem_Class_ToolTip_Messages.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOCM = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Localized_Message".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objLOCM.Count > 0 Then
            objOItem_Class_Localized_Message = New clsOntologyItem
            objOItem_Class_Localized_Message.GUID = objLOCM(0).ID_Other
            objOItem_Class_Localized_Message.Name = objLOCM(0).Name_Other
            objOItem_Class_Localized_Message.GUID_Parent = objLOCM(0).ID_Parent_Other
            objOItem_Class_Localized_Message.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSTWA = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Structure_Type_with_Aspects".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objSTWA.Count > 0 Then
            objOItem_Class_Structure_Type_with_Aspects = New clsOntologyItem
            objOItem_Class_Structure_Type_with_Aspects.GUID = objSTWA(0).ID_Other
            objOItem_Class_Structure_Type_with_Aspects.Name = objSTWA(0).Name_Other
            objOItem_Class_Structure_Type_with_Aspects.GUID_Parent = objSTWA(0).ID_Parent_Other
            objOItem_Class_Structure_Type_with_Aspects.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objMSG = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Messages".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objMSG.Count > 0 Then
            objOItem_Class_Messages = New clsOntologyItem
            objOItem_Class_Messages.GUID = objMSG(0).ID_Other
            objOItem_Class_Messages.Name = objMSG(0).Name_Other
            objOItem_Class_Messages.GUID_Parent = objMSG(0).ID_Parent_Other
            objOItem_Class_Messages.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDSI = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Dev_Structure_Invoke".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDSI.Count > 0 Then
            objOItem_Class_Dev_Structure_Invoke = New clsOntologyItem
            objOItem_Class_Dev_Structure_Invoke.GUID = objDSI(0).ID_Other
            objOItem_Class_Dev_Structure_Invoke.Name = objDSI(0).Name_Other
            objOItem_Class_Dev_Structure_Invoke.GUID_Parent = objDSI(0).ID_Parent_Other
            objOItem_Class_Dev_Structure_Invoke.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objST = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Structure_Type".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objST.Count > 0 Then
            objOItem_Class_Structure_Type = New clsOntologyItem
            objOItem_Class_Structure_Type.GUID = objST(0).ID_Other
            objOItem_Class_Structure_Type.Name = objST(0).Name_Other
            objOItem_Class_Structure_Type.GUID_Parent = objST(0).ID_Parent_Other
            objOItem_Class_Structure_Type.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSTV = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Structure_Validity".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objSTV.Count > 0 Then
            objOItem_Class_Structure_Validity = New clsOntologyItem
            objOItem_Class_Structure_Validity.GUID = objSTV(0).ID_Other
            objOItem_Class_Structure_Validity.Name = objSTV(0).Name_Other
            objOItem_Class_Structure_Validity.GUID_Parent = objSTV(0).ID_Parent_Other
            objOItem_Class_Structure_Validity.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOBJ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Objects".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOBJ.Count > 0 Then
            objOItem_Class_Objects = New clsOntologyItem
            objOItem_Class_Objects.GUID = objOBJ(0).ID_Other
            objOItem_Class_Objects.Name = objOBJ(0).Name_Other
            objOItem_Class_Objects.GUID_Parent = objOBJ(0).ID_Parent_Other
            objOItem_Class_Objects.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDSPTTP = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Dev_Structure__Process_Type_to_Process_".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDSPTTP.Count > 0 Then
            objOItem_Class_Dev_Structure__Process_Type_to_Process_ = New clsOntologyItem
            objOItem_Class_Dev_Structure__Process_Type_to_Process_.GUID = objDSPTTP(0).ID_Other
            objOItem_Class_Dev_Structure__Process_Type_to_Process_.Name = objDSPTTP(0).Name_Other
            objOItem_Class_Dev_Structure__Process_Type_to_Process_.GUID_Parent = objDSPTTP(0).ID_Parent_Other
            objOItem_Class_Dev_Structure__Process_Type_to_Process_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDEVS = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Dev_Structure".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDEVS.Count > 0 Then
            objOItem_Class_Dev_Structure = New clsOntologyItem
            objOItem_Class_Dev_Structure.GUID = objDEVS(0).ID_Other
            objOItem_Class_Dev_Structure.Name = objDEVS(0).Name_Other
            objOItem_Class_Dev_Structure.GUID_Parent = objDEVS(0).ID_Parent_Other
            objOItem_Class_Dev_Structure.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSCENE = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Scene".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objSCENE.Count > 0 Then
            objOItem_Class_Scene = New clsOntologyItem
            objOItem_Class_Scene.GUID = objSCENE(0).ID_Other
            objOItem_Class_Scene.Name = objSCENE(0).Name_Other
            objOItem_Class_Scene.GUID_Parent = objSCENE(0).ID_Parent_Other
            objOItem_Class_Scene.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objMOD = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Module".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objMOD.Count > 0 Then
            objOItem_Class_Module = New clsOntologyItem
            objOItem_Class_Module.GUID = objMOD(0).ID_Other
            objOItem_Class_Module.Name = objMOD(0).Name_Other
            objOItem_Class_Module.GUID_Parent = objMOD(0).ID_Parent_Other
            objOItem_Class_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDL = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Development_Libraries".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDL.Count > 0 Then
            objOItem_Class_Development_Libraries = New clsOntologyItem
            objOItem_Class_Development_Libraries.GUID = objDL(0).ID_Other
            objOItem_Class_Development_Libraries.Name = objDL(0).Name_Other
            objOItem_Class_Development_Libraries.GUID_Parent = objDL(0).ID_Parent_Other
            objOItem_Class_Development_Libraries.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIVM = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Image_Video_Management".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objIVM.Count > 0 Then
            objOItem_Class_Image_Video_Management = New clsOntologyItem
            objOItem_Class_Image_Video_Management.GUID = objIVM(0).ID_Other
            objOItem_Class_Image_Video_Management.Name = objIVM(0).Name_Other
            objOItem_Class_Image_Video_Management.GUID_Parent = objIVM(0).ID_Parent_Other
            objOItem_Class_Image_Video_Management.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSITEWC = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Sem_Items_to_expot_with_Children".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objSITEWC.Count > 0 Then
            objOItem_Class_Sem_Items_to_expot_with_Children = New clsOntologyItem
            objOItem_Class_Sem_Items_to_expot_with_Children.GUID = objSITEWC(0).ID_Other
            objOItem_Class_Sem_Items_to_expot_with_Children.Name = objSITEWC(0).Name_Other
            objOItem_Class_Sem_Items_to_expot_with_Children.GUID_Parent = objSITEWC(0).ID_Parent_Other
            objOItem_Class_Sem_Items_to_expot_with_Children.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objEM = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Export_Mode".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objEM.Count > 0 Then
            objOItem_Class_Export_Mode = New clsOntologyItem
            objOItem_Class_Export_Mode.GUID = objEM(0).ID_Other
            objOItem_Class_Export_Mode.Name = objEM(0).Name_Other
            objOItem_Class_Export_Mode.GUID_Parent = objEM(0).ID_Parent_Other
            objOItem_Class_Export_Mode.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDSCH = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Database_Schema".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDSCH.Count > 0 Then
            objOItem_Class_Database_Schema = New clsOntologyItem
            objOItem_Class_Database_Schema.GUID = objDSCH(0).ID_Other
            objOItem_Class_Database_Schema.Name = objDSCH(0).Name_Other
            objOItem_Class_Database_Schema.GUID_Parent = objDSCH(0).ID_Parent_Other
            objOItem_Class_Database_Schema.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDEVM = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Development_Module".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDEVM.Count > 0 Then
            objOItem_Class_Development_Module = New clsOntologyItem
            objOItem_Class_Development_Module.GUID = objDEVM(0).ID_Other
            objOItem_Class_Development_Module.Name = objDEVM(0).Name_Other
            objOItem_Class_Development_Module.GUID_Parent = objDEVM(0).ID_Parent_Other
            objOItem_Class_Development_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

    End Sub

    Private Sub get_Config_RelationTypes()
        Dim objOList_relationtype_subpath_versionfile = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_subpath_versionfile".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_subpath_versionfile.Count > 0 Then
            objOItem_relationtype_subpath_versionfile = New clsOntologyItem
            objOItem_relationtype_subpath_versionfile.GUID = objOList_relationtype_subpath_versionfile.First().ID_Other
            objOItem_relationtype_subpath_versionfile.Name = objOList_relationtype_subpath_versionfile.First().Name_Other
            objOItem_relationtype_subpath_versionfile.GUID_Parent = objOList_relationtype_subpath_versionfile.First().ID_Parent_Other
            objOItem_relationtype_subpath_versionfile.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_project_file = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_project_file".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_project_file.Count > 0 Then
            objOItem_relationtype_project_file = New clsOntologyItem
            objOItem_relationtype_project_file.GUID = objOList_relationtype_project_file.First().ID_Other
            objOItem_relationtype_project_file.Name = objOList_relationtype_project_file.First().Name_Other
            objOItem_relationtype_project_file.GUID_Parent = objOList_relationtype_project_file.First().ID_Parent_Other
            objOItem_relationtype_project_file.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_property = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_property".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_property.Count > 0 Then
            objOItem_relationtype_property = New clsOntologyItem
            objOItem_relationtype_property.GUID = objOList_relationtype_property(0).ID_Other
            objOItem_relationtype_property.Name = objOList_relationtype_property(0).Name_Other
            objOItem_relationtype_property.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_declaration = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_declaration".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_declaration.Count > 0 Then
            objOItem_relationtype_declaration = New clsOntologyItem
            objOItem_relationtype_declaration.GUID = objOList_relationtype_declaration(0).ID_Other
            objOItem_relationtype_declaration.Name = objOList_relationtype_declaration(0).Name_Other
            objOItem_relationtype_declaration.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_relationtype = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_relationtype".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_relationtype.Count > 0 Then
            objOItem_relationtype_relationtype = New clsOntologyItem
            objOItem_relationtype_relationtype.GUID = objOList_relationtype_relationtype(0).ID_Other
            objOItem_relationtype_relationtype.Name = objOList_relationtype_relationtype(0).Name_Other
            objOItem_relationtype_relationtype.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_object = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_object".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_object.Count > 0 Then
            objOItem_relationtype_object = New clsOntologyItem
            objOItem_relationtype_object.GUID = objOList_relationtype_object(0).ID_Other
            objOItem_relationtype_object.Name = objOList_relationtype_object(0).Name_Other
            objOItem_relationtype_object.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_document_container = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_document_container".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_document_container.Count > 0 Then
            objOItem_relationtype_document_container = New clsOntologyItem
            objOItem_relationtype_document_container.GUID = objOList_relationtype_document_container(0).ID_Other
            objOItem_relationtype_document_container.Name = objOList_relationtype_document_container(0).Name_Other
            objOItem_relationtype_document_container.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_class = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_class".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_class.Count > 0 Then
            objOItem_relationtype_class = New clsOntologyItem
            objOItem_relationtype_class.GUID = objOList_relationtype_class(0).ID_Other
            objOItem_relationtype_class.Name = objOList_relationtype_class(0).Name_Other
            objOItem_relationtype_class.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_attribute = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_attribute".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_attribute.Count > 0 Then
            objOItem_relationtype_attribute = New clsOntologyItem
            objOItem_relationtype_attribute.GUID = objOList_relationtype_attribute(0).ID_Other
            objOItem_relationtype_attribute.Name = objOList_relationtype_attribute(0).Name_Other
            objOItem_relationtype_attribute.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBelongingResource = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_belonging_Resource".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objBelongingResource.Count > 0 Then
            objOitem_RelationType_belongingResource = New clsOntologyItem
            objOitem_RelationType_belongingResource.GUID = objBelongingResource(0).ID_Other
            objOitem_RelationType_belongingResource.Name = objBelongingResource(0).Name_Other
            objOitem_RelationType_belongingResource.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIIS = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_isInState".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objIIS.Count > 0 Then
            objOItem_RelationType_isInState = New clsOntologyItem
            objOItem_RelationType_isInState.GUID = objIIS(0).ID_Other
            objOItem_RelationType_isInState.Name = objIIS(0).Name_Other
            objOItem_RelationType_isInState.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objISSUB = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_isSubordinated".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objISSUB.Count > 0 Then
            objOItem_RelationType_isSubordinated = New clsOntologyItem
            objOItem_RelationType_isSubordinated.GUID = objISSUB(0).ID_Other
            objOItem_RelationType_isSubordinated.Name = objISSUB(0).Name_Other
            objOItem_RelationType_isSubordinated.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objWDB = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_wasDevelopedBy".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objWDB.Count > 0 Then
            objOItem_RelationType_wasDevelopedBy = New clsOntologyItem
            objOItem_RelationType_wasDevelopedBy.GUID = objWDB(0).ID_Other
            objOItem_RelationType_wasDevelopedBy.Name = objWDB(0).Name_Other
            objOItem_RelationType_wasDevelopedBy.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objWCB = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_wasCreatedBy".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objWCB.Count > 0 Then
            objOitem_RelationType_wasCreatedBy = New clsOntologyItem
            objOitem_RelationType_wasCreatedBy.GUID = objWCB(0).ID_Other
            objOitem_RelationType_wasCreatedBy.Name = objWCB(0).Name_Other
            objOitem_RelationType_wasCreatedBy.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIWI = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_isWrittenIn".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objIWI.Count > 0 Then
            objOitem_RelationType_isWrittenIn = New clsOntologyItem
            objOitem_RelationType_isWrittenIn.GUID = objIWI(0).ID_Other
            objOitem_RelationType_isWrittenIn.Name = objIWI(0).Name_Other
            objOitem_RelationType_isWrittenIn.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSTD = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_Standard".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objSTD.Count > 0 Then
            objOitem_RelationType_Standard = New clsOntologyItem
            objOitem_RelationType_Standard.GUID = objSTD(0).ID_Other
            objOitem_RelationType_Standard.Name = objSTD(0).Name_Other
            objOitem_RelationType_Standard.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSLI = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_SourcesLocatedIn".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objSLI.Count > 0 Then
            objOitem_RelationType_SourcesLocatedIn = New clsOntologyItem
            objOitem_RelationType_SourcesLocatedIn.GUID = objSLI(0).ID_Other
            objOitem_RelationType_SourcesLocatedIn.Name = objSLI(0).Name_Other
            objOitem_RelationType_SourcesLocatedIn.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPOSS = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_Possible".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objPOSS.Count > 0 Then
            objOitem_RelationType_Possible = New clsOntologyItem
            objOitem_RelationType_Possible.GUID = objPOSS(0).ID_Other
            objOitem_RelationType_Possible.Name = objPOSS(0).Name_Other
            objOitem_RelationType_Possible.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objREQ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_Request".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objREQ.Count > 0 Then
            objOitem_RelationType_Request = New clsOntologyItem
            objOitem_RelationType_Request.GUID = objREQ(0).ID_Other
            objOitem_RelationType_Request.Name = objREQ(0).Name_Other
            objOitem_RelationType_Request.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objHAP = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_Happened".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objHAP.Count > 0 Then
            objOitem_RelationType_Happened = New clsOntologyItem
            objOitem_RelationType_Happened.GUID = objHAP(0).ID_Other
            objOitem_RelationType_Happened.Name = objHAP(0).Name_Other
            objOitem_RelationType_Happened.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPROV = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_provides".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objPROV.Count > 0 Then
            objOitem_RelationType_provides = New clsOntologyItem
            objOitem_RelationType_provides.GUID = objPROV(0).ID_Other
            objOitem_RelationType_provides.Name = objPROV(0).Name_Other
            objOitem_RelationType_provides.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBEL = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_belongsTo".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objBEL.Count > 0 Then
            objOItem_RelationType_belongsTo = New clsOntologyItem
            objOItem_RelationType_belongsTo.GUID = objBEL(0).ID_Other
            objOItem_RelationType_belongsTo.Name = objBEL(0).Name_Other
            objOItem_RelationType_belongsTo.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOFF = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_offers".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOFF.Count > 0 Then
            objOitem_RelationType_offers = New clsOntologyItem
            objOitem_RelationType_offers.GUID = objOFF(0).ID_Other
            objOitem_RelationType_offers.Name = objOFF(0).Name_Other
            objOitem_RelationType_offers.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objADD = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_additional".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objADD.Count > 0 Then
            objOitem_RelationType_additional = New clsOntologyItem
            objOitem_RelationType_additional.GUID = objADD(0).ID_Other
            objOitem_RelationType_additional.Name = objADD(0).Name_Other
            objOitem_RelationType_additional.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If


        Dim objISDESCBY = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_isDescribedBy".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objISDESCBY.Count > 0 Then
            objOitem_RelationType_isDescribedBy = New clsOntologyItem
            objOitem_RelationType_isDescribedBy.GUID = objISDESCBY(0).ID_Other
            objOitem_RelationType_isDescribedBy.Name = objISDESCBY(0).Name_Other
            objOitem_RelationType_isDescribedBy.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objNEED = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_needs".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objNEED.Count > 0 Then
            objOitem_RelationType_needs = New clsOntologyItem
            objOitem_RelationType_needs.GUID = objNEED(0).ID_Other
            objOitem_RelationType_needs.Name = objNEED(0).Name_Other
            objOitem_RelationType_needs.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCONT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_contains".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objCONT.Count > 0 Then
            objOitem_RelationType_contains = New clsOntologyItem
            objOitem_RelationType_contains.GUID = objCONT(0).ID_Other
            objOitem_RelationType_contains.Name = objCONT(0).Name_Other
            objOitem_RelationType_contains.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objWOKOFF = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_works_off".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objWOKOFF.Count > 0 Then
            objOitem_RelationType_works_off = New clsOntologyItem
            objOitem_RelationType_works_off.GUID = objWOKOFF(0).ID_Other
            objOitem_RelationType_works_off.Name = objWOKOFF(0).Name_Other
            objOitem_RelationType_works_off.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDIRBY = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_directed_by".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objDIRBY.Count > 0 Then
            objOitem_RelationType_directed_by = New clsOntologyItem
            objOitem_RelationType_directed_by.GUID = objDIRBY(0).ID_Other
            objOitem_RelationType_directed_by.Name = objDIRBY(0).Name_Other
            objOitem_RelationType_directed_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDESC = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_describes".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objDESC.Count > 0 Then
            objOitem_RelationType_describes = New clsOntologyItem
            objOitem_RelationType_describes.GUID = objDESC(0).ID_Other
            objOitem_RelationType_describes.Name = objDESC(0).Name_Other
            objOitem_RelationType_describes.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objALTF = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_alternative_for".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objALTF.Count > 0 Then
            objOitem_RelationType_alternative_for = New clsOntologyItem
            objOitem_RelationType_alternative_for.GUID = objALTF(0).ID_Other
            objOitem_RelationType_alternative_for.Name = objALTF(0).Name_Other
            objOitem_RelationType_alternative_for.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objEXTO = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_export_to".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objEXTO.Count > 0 Then
            objOitem_RelationType_export_to = New clsOntologyItem
            objOitem_RelationType_export_to.GUID = objEXTO(0).ID_Other
            objOitem_RelationType_export_to.Name = objEXTO(0).Name_Other
            objOitem_RelationType_export_to.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objISOFT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_is_of_Type".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objISOFT.Count > 0 Then
            objOitem_RelationType_is_of_Type = New clsOntologyItem
            objOitem_RelationType_is_of_Type.GUID = objISOFT(0).ID_Other
            objOitem_RelationType_is_of_Type.Name = objISOFT(0).Name_Other
            objOitem_RelationType_is_of_Type.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLI = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_located_in".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objLI.Count > 0 Then
            objOitem_RelationType_located_in = New clsOntologyItem
            objOitem_RelationType_located_in.GUID = objLI(0).ID_Other
            objOitem_RelationType_located_in.Name = objLI(0).Name_Other
            objOitem_RelationType_located_in.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objISDB = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_is_defined_by".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objISDB.Count > 0 Then
            objOitem_RelationType_is_defined_by = New clsOntologyItem
            objOitem_RelationType_is_defined_by.GUID = objISDB(0).ID_Other
            objOitem_RelationType_is_defined_by.Name = objISDB(0).Name_Other
            objOitem_RelationType_is_defined_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objUM = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_User_Message".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objUM.Count > 0 Then
            objOitem_RelationType_User_Message = New clsOntologyItem
            objOitem_RelationType_User_Message.GUID = objUM(0).ID_Other
            objOitem_RelationType_User_Message.Name = objUM(0).Name_Other
            objOitem_RelationType_User_Message.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIM = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_Input_Message".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objIM.Count > 0 Then
            objOitem_RelationType_Input_Message = New clsOntologyItem
            objOitem_RelationType_Input_Message.GUID = objIM(0).ID_Other
            objOitem_RelationType_Input_Message.Name = objIM(0).Name_Other
            objOitem_RelationType_Input_Message.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objERM = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_Error_Message".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objERM.Count > 0 Then
            objOitem_RelationType_Error_Message = New clsOntologyItem
            objOitem_RelationType_Error_Message.GUID = objERM(0).ID_Other
            objOitem_RelationType_Error_Message.Name = objERM(0).Name_Other
            objOitem_RelationType_Error_Message.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSUBO = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_superordinate".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objSUBO.Count > 0 Then
            objOitem_RelationType_superordinate = New clsOntologyItem
            objOitem_RelationType_superordinate.GUID = objSUBO(0).ID_Other
            objOitem_RelationType_superordinate.Name = objSUBO(0).Name_Other
            objOitem_RelationType_superordinate.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIVAC = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_invoking_Actor".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objIVAC.Count > 0 Then
            objOitem_RelationType_invoking_Actor = New clsOntologyItem
            objOitem_RelationType_invoking_Actor.GUID = objIVAC(0).ID_Other
            objOitem_RelationType_invoking_Actor.Name = objIVAC(0).Name_Other
            objOitem_RelationType_invoking_Actor.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIVACT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_invoked_Actor".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objIVACT.Count > 0 Then
            objOitem_RelationType_invoked_Actor = New clsOntologyItem
            objOitem_RelationType_invoked_Actor.GUID = objIVACT(0).ID_Other
            objOitem_RelationType_invoked_Actor.Name = objIVACT(0).Name_Other
            objOitem_RelationType_invoked_Actor.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objACB = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_access_by".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objACB.Count > 0 Then
            objOitem_RelationType_access_by = New clsOntologyItem
            objOitem_RelationType_access_by.GUID = objACB(0).ID_Other
            objOitem_RelationType_access_by.Name = objACB(0).Name_Other
            objOitem_RelationType_access_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBELP = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_belonging_Paramter".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objBELP.Count > 0 Then
            objOitem_RelationType_belonging_Paramter = New clsOntologyItem
            objOitem_RelationType_belonging_Paramter.GUID = objBELP(0).ID_Other
            objOitem_RelationType_belonging_Paramter.Name = objBELP(0).Name_Other
            objOitem_RelationType_belonging_Paramter.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIIO = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_is_instance_of".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objIIO.Count > 0 Then
            objOitem_RelationType_is_instance_of = New clsOntologyItem
            objOitem_RelationType_is_instance_of.GUID = objIIO(0).ID_Other
            objOitem_RelationType_is_instance_of.Name = objIIO(0).Name_Other
            objOitem_RelationType_is_instance_of.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIGN = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_ignore".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objIGN.Count > 0 Then
            objOitem_RelationType_ignore = New clsOntologyItem
            objOitem_RelationType_ignore.GUID = objIGN(0).ID_Other
            objOitem_RelationType_ignore.Name = objIGN(0).Name_Other
            objOitem_RelationType_ignore.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objHAND = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_handles".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objHAND.Count > 0 Then
            objOitem_RelationType_handles = New clsOntologyItem
            objOitem_RelationType_handles.GUID = objHAND(0).ID_Other
            objOitem_RelationType_handles.Name = objHAND(0).Name_Other
            objOitem_RelationType_handles.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objINT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_initializing".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objINT.Count > 0 Then
            objOitem_RelationType_initializing = New clsOntologyItem
            objOitem_RelationType_initializing.GUID = objINT(0).ID_Other
            objOitem_RelationType_initializing.Name = objINT(0).Name_Other
            objOitem_RelationType_initializing.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOFFB = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_offered_by".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOFFB.Count > 0 Then
            objOItem_RelationType_offered_by = New clsOntologyItem
            objOItem_RelationType_offered_by.GUID = objOFFB(0).ID_Other
            objOItem_RelationType_offered_by.Name = objOFFB(0).Name_Other
            objOItem_RelationType_offered_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

    End Sub

    Private Sub get_Config_Objects()
        Dim objOList_object_version = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "object_version".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_object_version.Count > 0 Then
            objOItem_object_version = New clsOntologyItem
            objOItem_object_version.GUID = objOList_object_version.First().ID_Other
            objOItem_object_version.Name = objOList_object_version.First().Name_Other
            objOItem_object_version.GUID_Parent = objOList_object_version.First().ID_Parent_Other
            objOItem_object_version.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_object_visual_studio_version_parser = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "object_visual_studio_version_parser".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_object_visual_studio_version_parser.Count > 0 Then
            objOItem_object_visual_studio_version_parser = New clsOntologyItem
            objOItem_object_visual_studio_version_parser.GUID = objOList_object_visual_studio_version_parser.First().ID_Other
            objOItem_object_visual_studio_version_parser.Name = objOList_object_visual_studio_version_parser.First().Name_Other
            objOItem_object_visual_studio_version_parser.GUID_Parent = objOList_object_visual_studio_version_parser.First().ID_Parent_Other
            objOItem_object_visual_studio_version_parser.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_VB_Net = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "object_vb_net".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_VB_Net.Count > 0 Then
            objOItem_object_vb_net = New clsOntologyItem
            objOItem_object_vb_net.GUID = objOList_VB_Net(0).ID_Other
            objOItem_object_vb_net.Name = objOList_VB_Net(0).Name_Other
            objOItem_object_vb_net.GUID_Parent = objOList_VB_Net(0).ID_Parent_Other
            objOItem_object_vb_net.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_C_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "object_c_".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_C_.Count > 0 Then
            objOItem_object_c_ = New clsOntologyItem
            objOItem_object_c_.GUID = objOList_C_(0).ID_Other
            objOItem_object_c_.Name = objOList_C_(0).Name_Other
            objOItem_object_c_.GUID_Parent = objOList_C_(0).ID_Parent_Other
            objOItem_object_c_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_Module = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "development_management".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_Module.Count > 0 Then
            objOItem_Module = New clsOntologyItem
            objOItem_Module.GUID = objOList_Module(0).ID_Other
            objOItem_Module.Name = objOList_Module(0).Name_Other
            objOItem_Module.GUID_Parent = objOList_Module(0).ID_Parent_Other
            objOItem_Module.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSA = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_LogState_Active".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objLOGSA.Count > 0 Then
            objOitem_Object_LogState_Active = New clsOntologyItem
            objOitem_Object_LogState_Active.GUID = objLOGSA(0).ID_Other
            objOitem_Object_LogState_Active.Name = objLOGSA(0).Name_Other
            objOitem_Object_LogState_Active.GUID_Parent = objLOGSA(0).ID_Parent_Other
            objOitem_Object_LogState_Active.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSI = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_LogState_Inactive".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objLOGSI.Count > 0 Then
            objOitem_Object_LogState_Inactive = New clsOntologyItem
            objOitem_Object_LogState_Inactive.GUID = objLOGSI(0).ID_Other
            objOitem_Object_LogState_Inactive.Name = objLOGSI(0).Name_Other
            objOitem_Object_LogState_Inactive.GUID_Parent = objLOGSI(0).ID_Parent_Other
            objOitem_Object_LogState_Inactive.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSOP = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_LogState_Open".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objLOGSOP.Count > 0 Then
            objOitem_Object_LogState_Open = New clsOntologyItem
            objOitem_Object_LogState_Open.GUID = objLOGSOP(0).ID_Other
            objOitem_Object_LogState_Open.Name = objLOGSOP(0).Name_Other
            objOitem_Object_LogState_Open.GUID_Parent = objLOGSOP(0).ID_Parent_Other
            objOitem_Object_LogState_Open.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSCH = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_LogState_Changed".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objLOGSCH.Count > 0 Then
            objOitem_Object_LogState_Changed = New clsOntologyItem
            objOitem_Object_LogState_Changed.GUID = objLOGSCH(0).ID_Other
            objOitem_Object_LogState_Changed.Name = objLOGSCH(0).Name_Other
            objOitem_Object_LogState_Changed.GUID_Parent = objLOGSCH(0).ID_Parent_Other
            objOitem_Object_LogState_Changed.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSOBS = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_LogState_Obsolete".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objLOGSOBS.Count > 0 Then
            objOitem_Object_LogState_Obsolete = New clsOntologyItem
            objOitem_Object_LogState_Obsolete.GUID = objLOGSOBS(0).ID_Other
            objOitem_Object_LogState_Obsolete.Name = objLOGSOBS(0).Name_Other
            objOitem_Object_LogState_Obsolete.GUID_Parent = objLOGSOBS(0).ID_Parent_Other
            objOitem_Object_LogState_Obsolete.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSINF = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_LogState_Information".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objLOGSINF.Count > 0 Then
            objOitem_Object_LogState_Information = New clsOntologyItem
            objOitem_Object_LogState_Information.GUID = objLOGSINF(0).ID_Other
            objOitem_Object_LogState_Information.Name = objLOGSINF(0).Name_Other
            objOitem_Object_LogState_Information.GUID_Parent = objLOGSINF(0).ID_Parent_Other
            objOitem_Object_LogState_Information.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSREQ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_LogState_Request".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objLOGSREQ.Count > 0 Then
            objOitem_Object_LogState_Request = New clsOntologyItem
            objOitem_Object_LogState_Request.GUID = objLOGSREQ(0).ID_Other
            objOitem_Object_LogState_Request.Name = objLOGSREQ(0).Name_Other
            objOitem_Object_LogState_Request.GUID_Parent = objLOGSREQ(0).ID_Parent_Other
            objOitem_Object_LogState_Request.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSVC = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_LogState_VersionChanged".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objLOGSVC.Count > 0 Then
            objOitem_Object_LogState_VersionChanged = New clsOntologyItem
            objOitem_Object_LogState_VersionChanged.GUID = objLOGSVC(0).ID_Other
            objOitem_Object_LogState_VersionChanged.Name = objLOGSVC(0).Name_Other
            objOitem_Object_LogState_VersionChanged.GUID_Parent = objLOGSVC(0).ID_Parent_Other
            objOitem_Object_LogState_VersionChanged.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSC = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_LogState_Create".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objLOGSC.Count > 0 Then
            objOitem_Object_LogState_Create = New clsOntologyItem
            objOitem_Object_LogState_Create.GUID = objLOGSC(0).ID_Other
            objOitem_Object_LogState_Create.Name = objLOGSC(0).Name_Other
            objOitem_Object_LogState_Create.GUID_Parent = objLOGSC(0).ID_Parent_Other
            objOitem_Object_LogState_Create.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPSDS = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_PossibleStates_DevelopmentStandard".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objPSDS.Count > 0 Then
            objOitem_Object_PossibleStates_DevelopmentStandard = New clsOntologyItem
            objOitem_Object_PossibleStates_DevelopmentStandard.GUID = objPSDS(0).ID_Other
            objOitem_Object_PossibleStates_DevelopmentStandard.Name = objPSDS(0).Name_Other
            objOitem_Object_PossibleStates_DevelopmentStandard.GUID_Parent = objPSDS(0).ID_Parent_Other
            objOitem_Object_PossibleStates_DevelopmentStandard.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSCIA = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_LogState_ConfigItemAdded".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objLOGSCIA.Count > 0 Then
            objOitem_Object_LogState_ConfigItemAdded = New clsOntologyItem
            objOitem_Object_LogState_ConfigItemAdded.GUID = objLOGSCIA(0).ID_Other
            objOitem_Object_LogState_ConfigItemAdded.Name = objLOGSCIA(0).Name_Other
            objOitem_Object_LogState_ConfigItemAdded.GUID_Parent = objLOGSCIA(0).ID_Parent_Other
            objOitem_Object_LogState_ConfigItemAdded.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCLSLXMLXML = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_clsLocalConfig_xml_XML".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objCLSLXMLXML.Count > 0 Then
            objOitem_Object_clsLocalConfig_xml_XML = New clsOntologyItem
            objOitem_Object_clsLocalConfig_xml_XML.GUID = objCLSLXMLXML(0).ID_Other
            objOitem_Object_clsLocalConfig_xml_XML.Name = objCLSLXMLXML(0).Name_Other
            objOitem_Object_clsLocalConfig_xml_XML.GUID_Parent = objCLSLXMLXML(0).ID_Parent_Other
            objOitem_Object_clsLocalConfig_xml_XML.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDECCX = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Declaration_Configitems_XML".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objDECCX.Count > 0 Then
            objOitem_Object_Declaration_Configitems_XML = New clsOntologyItem
            objOitem_Object_Declaration_Configitems_XML.GUID = objDECCX(0).ID_Other
            objOitem_Object_Declaration_Configitems_XML.Name = objDECCX(0).Name_Other
            objOitem_Object_Declaration_Configitems_XML.GUID_Parent = objDECCX(0).ID_Parent_Other
            objOitem_Object_Declaration_Configitems_XML.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIRCX = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Initialize_RelationType__ConfigItem__XML".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objIRCX.Count > 0 Then
            objOitem_Object_Initialize_RelationType__ConfigItem__XML = New clsOntologyItem
            objOitem_Object_Initialize_RelationType__ConfigItem__XML.GUID = objIRCX(0).ID_Other
            objOitem_Object_Initialize_RelationType__ConfigItem__XML.Name = objIRCX(0).Name_Other
            objOitem_Object_Initialize_RelationType__ConfigItem__XML.GUID_Parent = objIRCX(0).ID_Parent_Other
            objOitem_Object_Initialize_RelationType__ConfigItem__XML.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objITCIX = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Initialize_Token__ConfigItem__XML".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objITCIX.Count > 0 Then
            objOitem_Object_Initialize_Object__ConfigItem__XML = New clsOntologyItem
            objOitem_Object_Initialize_Object__ConfigItem__XML.GUID = objITCIX(0).ID_Other
            objOitem_Object_Initialize_Object__ConfigItem__XML.Name = objITCIX(0).Name_Other
            objOitem_Object_Initialize_Object__ConfigItem__XML.GUID_Parent = objITCIX(0).ID_Parent_Other
            objOitem_Object_Initialize_Object__ConfigItem__XML.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIACX = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Initilize_Attribute__ConfigItem__XML".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objIACX.Count > 0 Then
            objOitem_Object_Initilize_Attribute__ConfigItem__XML = New clsOntologyItem
            objOitem_Object_Initilize_Attribute__ConfigItem__XML.GUID = objIACX(0).ID_Other
            objOitem_Object_Initilize_Attribute__ConfigItem__XML.Name = objIACX(0).Name_Other
            objOitem_Object_Initilize_Attribute__ConfigItem__XML.GUID_Parent = objIACX(0).ID_Parent_Other
            objOitem_Object_Initilize_Attribute__ConfigItem__XML.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objITCX = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Initilize_Type__ConfigItem__XML".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objITCX.Count > 0 Then
            objOitem_Object_Initilize_Type__ConfigItem__XML = New clsOntologyItem
            objOitem_Object_Initilize_Type__ConfigItem__XML.GUID = objITCX(0).ID_Other
            objOitem_Object_Initilize_Type__ConfigItem__XML.Name = objITCX(0).Name_Other
            objOitem_Object_Initilize_Type__ConfigItem__XML.GUID_Parent = objITCX(0).ID_Parent_Other
            objOitem_Object_Initilize_Type__ConfigItem__XML.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPCX = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Property_ConfigItem_XML".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objPCX.Count > 0 Then
            objOitem_Object_Property_ConfigItem_XML = New clsOntologyItem
            objOitem_Object_Property_ConfigItem_XML.GUID = objPCX(0).ID_Other
            objOitem_Object_Property_ConfigItem_XML.Name = objPCX(0).Name_Other
            objOitem_Object_Property_ConfigItem_XML.GUID_Parent = objPCX(0).ID_Parent_Other
            objOitem_Object_Property_ConfigItem_XML.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDI = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Directions_IN".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objDI.Count > 0 Then
            objOitem_Object_Directions_IN = New clsOntologyItem
            objOitem_Object_Directions_IN.GUID = objDI(0).ID_Other
            objOitem_Object_Directions_IN.Name = objDI(0).Name_Other
            objOitem_Object_Directions_IN.GUID_Parent = objDI(0).ID_Parent_Other
            objOitem_Object_Directions_IN.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDO = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Directions_OUT".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objDO.Count > 0 Then
            objOitem_Object_Directions_OUT = New clsOntologyItem
            objOitem_Object_Directions_OUT.GUID = objDO(0).ID_Other
            objOitem_Object_Directions_OUT.Name = objDO(0).Name_Other
            objOitem_Object_Directions_OUT.GUID_Parent = objDO(0).ID_Parent_Other
            objOitem_Object_Directions_OUT.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objVLP = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_List_Properties".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objVLP.Count > 0 Then
            objOitem_Object_Variable_List_Properties = New clsOntologyItem
            objOitem_Object_Variable_List_Properties.GUID = objVLP(0).ID_Other
            objOitem_Object_Variable_List_Properties.Name = objVLP(0).Name_Other
            objOitem_Object_Variable_List_Properties.GUID_Parent = objVLP(0).ID_Parent_Other
            objOitem_Object_Variable_List_Properties.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objVLICT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_List_Initialize_ConfigItems_Types".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objVLICT.Count > 0 Then
            objOitem_Object_Variable_List_Initialize_ConfigItems_Types = New clsOntologyItem
            objOitem_Object_Variable_List_Initialize_ConfigItems_Types.GUID = objVLICT(0).ID_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_Types.Name = objVLICT(0).Name_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_Types.GUID_Parent = objVLICT(0).ID_Parent_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_Types.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objVLICTOK = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_List_Initialize_ConfigItems_Token".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objVLICTOK.Count > 0 Then
            objOitem_Object_Variable_List_Initialize_ConfigItems_Object = New clsOntologyItem
            objOitem_Object_Variable_List_Initialize_ConfigItems_Object.GUID = objVLICTOK(0).ID_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_Object.Name = objVLICTOK(0).Name_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_Object.GUID_Parent = objVLICTOK(0).ID_Parent_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_Object.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objVLICIR = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_List_Initialize_ConfigItems_RelationTypes".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objVLICIR.Count > 0 Then
            objOitem_Object_Variable_List_Initialize_ConfigItems_RelationTypes = New clsOntologyItem
            objOitem_Object_Variable_List_Initialize_ConfigItems_RelationTypes.GUID = objVLICIR(0).ID_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_RelationTypes.Name = objVLICIR(0).Name_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_RelationTypes.GUID_Parent = objVLICIR(0).ID_Parent_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_RelationTypes.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objVLICIA = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_List_Initialize_ConfigItems_Attributes".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objVLICIA.Count > 0 Then
            objOitem_Object_Variable_List_Initialize_ConfigItems_Attributes = New clsOntologyItem
            objOitem_Object_Variable_List_Initialize_ConfigItems_Attributes.GUID = objVLICIA(0).ID_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_Attributes.Name = objVLICIA(0).Name_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_Attributes.GUID_Parent = objVLICIA(0).ID_Parent_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_Attributes.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objVLDCI = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_List_Declaration_ConfigItems".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objVLDCI.Count > 0 Then
            objOitem_Object_Variable_List_Declaration_ConfigItems = New clsOntologyItem
            objOitem_Object_Variable_List_Declaration_ConfigItems.GUID = objVLDCI(0).ID_Other
            objOitem_Object_Variable_List_Declaration_ConfigItems.Name = objVLDCI(0).Name_Other
            objOitem_Object_Variable_List_Declaration_ConfigItems.GUID_Parent = objVLDCI(0).ID_Parent_Other
            objOitem_Object_Variable_List_Declaration_ConfigItems.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDEVSS = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Dev_Structure_Schleife".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objDEVSS.Count > 0 Then
            objOitem_Object_Dev_Structure_Schleife = New clsOntologyItem
            objOitem_Object_Dev_Structure_Schleife.GUID = objDEVSS(0).ID_Other
            objOitem_Object_Dev_Structure_Schleife.Name = objDEVSS(0).Name_Other
            objOitem_Object_Dev_Structure_Schleife.GUID_Parent = objDEVSS(0).ID_Parent_Other
            objOitem_Object_Dev_Structure_Schleife.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDEVR = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Dev_Structure_Return".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objDEVR.Count > 0 Then
            objOitem_Object_Dev_Structure_Return = New clsOntologyItem
            objOitem_Object_Dev_Structure_Return.GUID = objDEVR(0).ID_Other
            objOitem_Object_Dev_Structure_Return.Name = objDEVR(0).Name_Other
            objOitem_Object_Dev_Structure_Return.GUID_Parent = objDEVR(0).ID_Parent_Other
            objOitem_Object_Dev_Structure_Return.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDEVD = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Dev_Structure_Database".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objDEVD.Count > 0 Then
            objOitem_Object_Dev_Structure_Database = New clsOntologyItem
            objOitem_Object_Dev_Structure_Database.GUID = objDEVD(0).ID_Other
            objOitem_Object_Dev_Structure_Database.Name = objDEVD(0).Name_Other
            objOitem_Object_Dev_Structure_Database.GUID_Parent = objDEVD(0).ID_Parent_Other
            objOitem_Object_Dev_Structure_Database.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objMODDEVM = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Module_Development_Management".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objMODDEVM.Count > 0 Then
            objOitem_Object_Module_Development_Management = New clsOntologyItem
            objOitem_Object_Module_Development_Management.GUID = objMODDEVM(0).ID_Other
            objOitem_Object_Module_Development_Management.Name = objMODDEVM(0).Name_Other
            objOitem_Object_Module_Development_Management.GUID_Parent = objMODDEVM(0).ID_Parent_Other
            objOitem_Object_Module_Development_Management.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objMGCOITOT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Export_Mode_Grant_Children_of_Item__Token_of_Type_".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objMGCOITOT.Count > 0 Then
            objOitem_Object_Export_Mode_Grant_Children_of_Item__Object_of_Type_ = New clsOntologyItem
            objOitem_Object_Export_Mode_Grant_Children_of_Item__Object_of_Type_.GUID = objMGCOITOT(0).ID_Other
            objOitem_Object_Export_Mode_Grant_Children_of_Item__Object_of_Type_.Name = objMGCOITOT(0).Name_Other
            objOitem_Object_Export_Mode_Grant_Children_of_Item__Object_of_Type_.GUID_Parent = objMGCOITOT(0).ID_Parent_Other
            objOitem_Object_Export_Mode_Grant_Children_of_Item__Object_of_Type_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objEMGCOITOT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Export_Mode_Deny_Only_Children__Token_of_Type_".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objEMGCOITOT.Count > 0 Then
            objOitem_Object_Export_Mode_Deny_Only_Children__Object_of_Type_ = New clsOntologyItem
            objOitem_Object_Export_Mode_Deny_Only_Children__Object_of_Type_.GUID = objEMGCOITOT(0).ID_Other
            objOitem_Object_Export_Mode_Deny_Only_Children__Object_of_Type_.Name = objEMGCOITOT(0).Name_Other
            objOitem_Object_Export_Mode_Deny_Only_Children__Object_of_Type_.GUID_Parent = objEMGCOITOT(0).ID_Parent_Other
            objOitem_Object_Export_Mode_Deny_Only_Children__Object_of_Type_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objEMDIWCHTT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Export_Mode_Deny_Item_with_Children__Type___Token_".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objEMDIWCHTT.Count > 0 Then
            objOitem_Object_Export_Mode_Deny_Item_with_Children__Type___Object_ = New clsOntologyItem
            objOitem_Object_Export_Mode_Deny_Item_with_Children__Type___Object_.GUID = objEMDIWCHTT(0).ID_Other
            objOitem_Object_Export_Mode_Deny_Item_with_Children__Type___Object_.Name = objEMDIWCHTT(0).Name_Other
            objOitem_Object_Export_Mode_Deny_Item_with_Children__Type___Object_.GUID_Parent = objEMDIWCHTT(0).ID_Parent_Other
            objOitem_Object_Export_Mode_Deny_Item_with_Children__Type___Object_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objEMN = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Export_Mode_Normal".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objEMN.Count > 0 Then
            objOitem_Object_Export_Mode_Normal = New clsOntologyItem
            objOitem_Object_Export_Mode_Normal.GUID = objEMN(0).ID_Other
            objOitem_Object_Export_Mode_Normal.Name = objEMN(0).Name_Other
            objOitem_Object_Export_Mode_Normal.GUID_Parent = objEMN(0).ID_Parent_Other
            objOitem_Object_Export_Mode_Normal.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objXMLCLSLCOX = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_XML_clsLocalConfig_ontology_xml".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objXMLCLSLCOX.Count > 0 Then
            objOItem_Token_XML_clsLocalConfig_ontology_xml = New clsOntologyItem
            objOItem_Token_XML_clsLocalConfig_ontology_xml.GUID = objXMLCLSLCOX(0).ID_Other
            objOItem_Token_XML_clsLocalConfig_ontology_xml.Name = objXMLCLSLCOX(0).Name_Other
            objOItem_Token_XML_clsLocalConfig_ontology_xml.GUID_Parent = objXMLCLSLCOX(0).ID_Parent_Other
            objOItem_Token_XML_clsLocalConfig_ontology_xml.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objToken_XML_Declaration_Ontology_Configitems = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_XML_Declaration_Ontology_Configitems".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objToken_XML_Declaration_Ontology_Configitems.Count > 0 Then
            objOItem_Token_XML_Declaration_Ontology_Configitems = New clsOntologyItem
            objOItem_Token_XML_Declaration_Ontology_Configitems.GUID = objToken_XML_Declaration_Ontology_Configitems(0).ID_Other
            objOItem_Token_XML_Declaration_Ontology_Configitems.Name = objToken_XML_Declaration_Ontology_Configitems(0).Name_Other
            objOItem_Token_XML_Declaration_Ontology_Configitems.GUID_Parent = objToken_XML_Declaration_Ontology_Configitems(0).ID_Parent_Other
            objOItem_Token_XML_Declaration_Ontology_Configitems.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objToken_XML_Initialize_RelationType__ConfigItem_Ontology_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_XML_Initialize_RelationType__ConfigItem_Ontology_".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objToken_XML_Declaration_Ontology_Configitems.Count > 0 Then
            objOItem_Token_XML_Initialize_RelationType__ConfigItem_Ontology_ = New clsOntologyItem
            objOItem_Token_XML_Initialize_RelationType__ConfigItem_Ontology_.GUID = objToken_XML_Initialize_RelationType__ConfigItem_Ontology_(0).ID_Other
            objOItem_Token_XML_Initialize_RelationType__ConfigItem_Ontology_.Name = objToken_XML_Initialize_RelationType__ConfigItem_Ontology_(0).Name_Other
            objOItem_Token_XML_Initialize_RelationType__ConfigItem_Ontology_.GUID_Parent = objToken_XML_Initialize_RelationType__ConfigItem_Ontology_(0).ID_Parent_Other
            objOItem_Token_XML_Initialize_RelationType__ConfigItem_Ontology_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objToken_XML_Initialize_Token__ConfigItem_Ontology_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_XML_Initialize_Token__ConfigItem_Ontology_".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objToken_XML_Initialize_Token__ConfigItem_Ontology_.Count > 0 Then
            objOItem_Token_XML_Initialize_Token__ConfigItem_Ontology_ = New clsOntologyItem
            objOItem_Token_XML_Initialize_Token__ConfigItem_Ontology_.GUID = objToken_XML_Initialize_Token__ConfigItem_Ontology_(0).ID_Other
            objOItem_Token_XML_Initialize_Token__ConfigItem_Ontology_.Name = objToken_XML_Initialize_Token__ConfigItem_Ontology_(0).Name_Other
            objOItem_Token_XML_Initialize_Token__ConfigItem_Ontology_.GUID_Parent = objToken_XML_Initialize_Token__ConfigItem_Ontology_(0).ID_Parent_Other
            objOItem_Token_XML_Initialize_Token__ConfigItem_Ontology_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objToken_XML_Initilize_Attribute__ConfigItem_Ontology_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_XML_Initilize_Attribute__ConfigItem_Ontology_".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objToken_XML_Initilize_Attribute__ConfigItem_Ontology_.Count > 0 Then
            objOItem_Token_XML_Initilize_Attribute__ConfigItem_Ontology_ = New clsOntologyItem
            objOItem_Token_XML_Initilize_Attribute__ConfigItem_Ontology_.GUID = objToken_XML_Initilize_Attribute__ConfigItem_Ontology_(0).ID_Other
            objOItem_Token_XML_Initilize_Attribute__ConfigItem_Ontology_.Name = objToken_XML_Initilize_Attribute__ConfigItem_Ontology_(0).Name_Other
            objOItem_Token_XML_Initilize_Attribute__ConfigItem_Ontology_.GUID_Parent = objToken_XML_Initilize_Attribute__ConfigItem_Ontology_(0).ID_Parent_Other
            objOItem_Token_XML_Initilize_Attribute__ConfigItem_Ontology_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objToken_XML_Initilize_Type__ConfigItem_Ontology_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_XML_Initilize_Type__ConfigItem_Ontology_".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objToken_XML_Initilize_Type__ConfigItem_Ontology_.Count > 0 Then
            objOItem_Token_XML_Initilize_Type__ConfigItem_Ontology_ = New clsOntologyItem
            objOItem_Token_XML_Initilize_Type__ConfigItem_Ontology_.GUID = objToken_XML_Initilize_Type__ConfigItem_Ontology_(0).ID_Other
            objOItem_Token_XML_Initilize_Type__ConfigItem_Ontology_.Name = objToken_XML_Initilize_Type__ConfigItem_Ontology_(0).Name_Other
            objOItem_Token_XML_Initilize_Type__ConfigItem_Ontology_.GUID_Parent = objToken_XML_Initilize_Type__ConfigItem_Ontology_(0).ID_Parent_Other
            objOItem_Token_XML_Initilize_Type__ConfigItem_Ontology_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objToken_XML_Property_Ontology_ConfigItem = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_XML_Property_Ontology_ConfigItem".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objToken_XML_Property_Ontology_ConfigItem.Count > 0 Then
            objOItem_Token_XML_Property_Ontology_ConfigItem = New clsOntologyItem
            objOItem_Token_XML_Property_Ontology_ConfigItem.GUID = objToken_XML_Property_Ontology_ConfigItem(0).ID_Other
            objOItem_Token_XML_Property_Ontology_ConfigItem.Name = objToken_XML_Property_Ontology_ConfigItem(0).Name_Other
            objOItem_Token_XML_Property_Ontology_ConfigItem.GUID_Parent = objToken_XML_Property_Ontology_ConfigItem(0).ID_Parent_Other
            objOItem_Token_XML_Property_Ontology_ConfigItem.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objToken_Variable_Name_ConfigItem = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_Name_ConfigItem".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objToken_Variable_Name_ConfigItem.Count > 0 Then
            objOItem_Token_Variable_Name_ConfigItem = New clsOntologyItem
            objOItem_Token_Variable_Name_ConfigItem.GUID = objToken_Variable_Name_ConfigItem(0).ID_Other
            objOItem_Token_Variable_Name_ConfigItem.Name = objToken_Variable_Name_ConfigItem(0).Name_Other
            objOItem_Token_Variable_Name_ConfigItem.GUID_Parent = objToken_Variable_Name_ConfigItem(0).ID_Parent_Other
            objOItem_Token_Variable_Name_ConfigItem.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If
    End Sub

    Public ReadOnly Property OItem_BaseConfig As clsOntologyItem
        Get
            Return objOItem_BaseConfig
        End Get
    End Property

    Private Sub get_BaseConfig()
        Dim oList_ObjectRel As New List(Of clsObjectRel)


        oList_ObjectRel.Clear()
        oList_ObjectRel.Add(New clsObjectRel(Nothing, _
                                                Nothing, _
                                                objOItem_Class_Development_Module.GUID, _
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

    Public ReadOnly Property Globals As clsGlobals
        Get
            Return objGlobals
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

    Private Sub set_DBConnection()
        objDBLevel_Config1 = New clsDBLevel(objGlobals)
        objDBLevel_Config2 = New clsDBLevel(objGlobals)
        objImport = New clsImport(objGlobals)
    End Sub

    Public Sub New(ByVal Globals As clsGlobals)
        objGlobals = Globals

        set_DBConnection()

        initialize()
    End Sub

    Private Sub initialize()

        get_Config()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
