Imports Ontolog_Module
Imports OntologyClasses.BaseClasses
Public Class clsLocalConfig

    Private Const cint_ImageID_Root As Integer = 0
    Private Const cint_ImageID_Dev_Open As Integer = 1
    Private Const cint_ImageID_Dev_Closed As Integer = 2

    Private cstr_ID_SoftwareDevelopment As String = "04816070c3d045708e279732f48d1c6d"
    Private cstr_ID_Class_SoftwareDevelopment As String = "132a845f849f4f6b86847ab3fd068824"
    Private cstr_ID_Class_DevelopmentConfig As String = "c6c9bcb80ac947139417eeec1453026c"
    Private cstr_ID_Class_ConfigItem As String = "13c09f11175c4eefbc8a0fd8e86d557f"
    Private cstr_ID_RelType_needs As String = "fafc1464815f45969737bcbc96bd744a"
    Private cstr_ID_RelType_contains As String = "e971160347db44d8a476fe88290639a4"
    Private cstr_ID_RelType_belongsTo As String = "e07469d9766c443e85266d9c684f944f"

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

    'RelationTypes
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

    'Classes
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

    'Objects
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

    'RelationTypes
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

    'Classes
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

    'Objects
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


    Private Sub get_Config_AttributeTypes()
        Dim objADs = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_DateTimeStamp" And obj.Ontology = objGlobals.Type_AttributeType

        If objADs.Count > 0 Then
            objOItem_Attribute_DateTimeStamp = New clsOntologyItem
            objOItem_Attribute_DateTimeStamp.GUID = objADs(0).ID_Other
            objOItem_Attribute_DateTimeStamp.Name = objADs(0).Name_Other
            objOItem_Attribute_DateTimeStamp.GUID_Parent = objADs(0).ID_Parent_Other
            objOItem_Attribute_DateTimeStamp.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objMSG = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_Message" And obj.Ontology = objGlobals.Type_AttributeType

        If objMSG.Count > 0 Then
            objOItem_Attribute_Message = New clsOntologyItem
            objOItem_Attribute_Message.GUID = objMSG(0).ID_Other
            objOItem_Attribute_Message.Name = objMSG(0).Name_Other
            objOItem_Attribute_Message.GUID_Parent = objMSG(0).ID_Parent_Other
            objOItem_Attribute_Message.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objMAJ = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_Major" And obj.Ontology = objGlobals.Type_AttributeType

        If objMAJ.Count > 0 Then
            objOItem_Attribute_Message = New clsOntologyItem
            objOItem_Attribute_Message.GUID = objMAJ(0).ID_Other
            objOItem_Attribute_Message.Name = objMAJ(0).Name_Other
            objOItem_Attribute_Message.GUID_Parent = objMAJ(0).ID_Parent_Other
            objOItem_Attribute_Message.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objMIN = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_Minor" And obj.Ontology = objGlobals.Type_AttributeType

        If objMIN.Count > 0 Then
            objOItem_Attribute_Minor = New clsOntologyItem
            objOItem_Attribute_Minor.GUID = objMIN(0).ID_Other
            objOItem_Attribute_Minor.Name = objMIN(0).Name_Other
            objOItem_Attribute_Minor.GUID_Parent = objMIN(0).ID_Parent_Other
            objOItem_Attribute_Minor.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBUILD = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_Build" And obj.Ontology = objGlobals.Type_AttributeType

        If objBUILD.Count > 0 Then
            objOItem_Attribute_Build = New clsOntologyItem
            objOItem_Attribute_Build.GUID = objBUILD(0).ID_Other
            objOItem_Attribute_Build.Name = objBUILD(0).Name_Other
            objOItem_Attribute_Build.GUID_Parent = objBUILD(0).ID_Parent_Other
            objOItem_Attribute_Build.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRev = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_Revision" And obj.Ontology = objGlobals.Type_AttributeType

        If objRev.Count > 0 Then
            objOItem_Attribute_Revision = New clsOntologyItem
            objOItem_Attribute_Revision.GUID = objRev(0).ID_Other
            objOItem_Attribute_Revision.Name = objRev(0).Name_Other
            objOItem_Attribute_Revision.GUID_Parent = objRev(0).ID_Parent_Other
            objOItem_Attribute_Revision.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objXMLT = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_XML_Text" And obj.Ontology = objGlobals.Type_AttributeType

        If objXMLT.Count > 0 Then
            objOItem_Attribute_XML_Text = New clsOntologyItem
            objOItem_Attribute_XML_Text.GUID = objXMLT(0).ID_Other
            objOItem_Attribute_XML_Text.Name = objXMLT(0).Name_Other
            objOItem_Attribute_XML_Text.GUID_Parent = objXMLT(0).ID_Parent_Other
            objOItem_Attribute_XML_Text.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCAPT = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_caption" And obj.Ontology = objGlobals.Type_AttributeType

        If objCAPT.Count > 0 Then
            objOItem_Attribute_caption = New clsOntologyItem
            objOItem_Attribute_caption.GUID = objCAPT(0).ID_Other
            objOItem_Attribute_caption.Name = objCAPT(0).Name_Other
            objOItem_Attribute_caption.GUID_Parent = objCAPT(0).ID_Parent_Other
            objOItem_Attribute_caption.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIMGID = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_ImageID" And obj.Ontology = objGlobals.Type_AttributeType

        If objIMGID.Count > 0 Then
            objOItem_Attribute_ImageID = New clsOntologyItem
            objOItem_Attribute_ImageID.GUID = objIMGID(0).ID_Other
            objOItem_Attribute_ImageID.Name = objIMGID(0).Name_Other
            objOItem_Attribute_ImageID.GUID_Parent = objIMGID(0).ID_Parent_Other
            objOItem_Attribute_ImageID.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objGRNT = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_Grant" And obj.Ontology = objGlobals.Type_AttributeType

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



        Dim objSD = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "type_SoftwareDevelopment" And obj.Ontology = objGlobals.Type_Class

        If objSD.Count > 0 Then
            objOItem_Class_SoftwareDevelopment = New clsOntologyItem
            objOItem_Class_SoftwareDevelopment.GUID = objSD(0).ID_Other
            objOItem_Class_SoftwareDevelopment.Name = objSD(0).Name_Other
            objOItem_Class_SoftwareDevelopment.GUID_Parent = objSD(0).ID_Parent_Other
            objOItem_Class_SoftwareDevelopment.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDV = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "type_DevelopmentVersion" And obj.Ontology = objGlobals.Type_Class

        If objDV.Count > 0 Then
            objOItem_Class_DevelopmentVersion = New clsOntologyItem
            objOItem_Class_DevelopmentVersion.GUID = objDV(0).ID_Other
            objOItem_Class_DevelopmentVersion.Name = objDV(0).Name_Other
            objOItem_Class_DevelopmentVersion.GUID_Parent = objDV(0).ID_Parent_Other
            objOItem_Class_DevelopmentVersion.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLS = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "type_Logstate" And obj.Ontology = objGlobals.Type_Class

        If objLS.Count > 0 Then
            objOItem_Class_LogState = New clsOntologyItem
            objOItem_Class_LogState.GUID = objLS(0).ID_Other
            objOItem_Class_LogState.Name = objLS(0).Name_Other
            objOItem_Class_LogState.GUID_Parent = objLS(0).ID_Parent_Other
            objOItem_Class_LogState.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objUSR = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "type_User" And obj.Ontology = objGlobals.Type_Class

        If objUSR.Count > 0 Then
            objOItem_Class_User = New clsOntologyItem
            objOItem_Class_User.GUID = objUSR(0).ID_Other
            objOItem_Class_User.Name = objUSR(0).Name_Other
            objOItem_Class_User.GUID_Parent = objUSR(0).ID_Parent_Other
            objOItem_Class_User.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPL = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "type_ProgramingLanguage" And obj.Ontology = objGlobals.Type_Class

        If objPL.Count > 0 Then
            objOItem_Class_ProgramingLanguage = New clsOntologyItem
            objOItem_Class_ProgramingLanguage.GUID = objPL(0).ID_Other
            objOItem_Class_ProgramingLanguage.Name = objPL(0).Name_Other
            objOItem_Class_ProgramingLanguage.GUID_Parent = objPL(0).ID_Parent_Other
            objOItem_Class_ProgramingLanguage.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFLDR = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "type_Folder" And obj.Ontology = objGlobals.Type_Class

        If objFLDR.Count > 0 Then
            objOItem_Class_Folder = New clsOntologyItem
            objOItem_Class_Folder.GUID = objFLDR(0).ID_Other
            objOItem_Class_Folder.Name = objFLDR(0).Name_Other
            objOItem_Class_Folder.GUID_Parent = objFLDR(0).ID_Parent_Other
            objOItem_Class_Folder.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLNG = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Language" And obj.Ontology = objGlobals.Type_Class

        If objLNG.Count > 0 Then
            objOItem_Class_Language = New clsOntologyItem
            objOItem_Class_Language.GUID = objLNG(0).ID_Other
            objOItem_Class_Language.Name = objLNG(0).Name_Other
            objOItem_Class_Language.GUID_Parent = objLNG(0).ID_Parent_Other
            objOItem_Class_Language.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGE = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_LogEntry" And obj.Ontology = objGlobals.Type_Class

        If objLOGE.Count > 0 Then
            objOItem_Class_LogEntry = New clsOntologyItem
            objOItem_Class_LogEntry.GUID = objLOGE(0).ID_Other
            objOItem_Class_LogEntry.Name = objLOGE(0).Name_Other
            objOItem_Class_LogEntry.GUID_Parent = objLOGE(0).ID_Parent_Other
            objOItem_Class_LogEntry.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOCD = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "type_LocalizedDescription" And obj.Ontology = objGlobals.Type_Class

        If objLOCD.Count > 0 Then
            objOItem_Class_LocalizedDescription = New clsOntologyItem
            objOItem_Class_LocalizedDescription.GUID = objLOCD(0).ID_Other
            objOItem_Class_LocalizedDescription.Name = objLOCD(0).Name_Other
            objOItem_Class_LocalizedDescription.GUID_Parent = objLOCD(0).ID_Parent_Other
            objOItem_Class_LocalizedDescription.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDEVC = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_DevelopmentConfig" And obj.Ontology = objGlobals.Type_Class

        If objDEVC.Count > 0 Then
            objOItem_Class_DevelopmentConfig = New clsOntologyItem
            objOItem_Class_DevelopmentConfig.GUID = objDEVC(0).ID_Other
            objOItem_Class_DevelopmentConfig.Name = objDEVC(0).Name_Other
            objOItem_Class_DevelopmentConfig.GUID_Parent = objDEVC(0).ID_Parent_Other
            objOItem_Class_DevelopmentConfig.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDEVCI = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_DevelopmentConfigItem" And obj.Ontology = objGlobals.Type_Class

        If objDEVCI.Count > 0 Then
            objOItem_Class_DevelopmentConfigItem = New clsOntologyItem
            objOItem_Class_DevelopmentConfigItem.GUID = objDEVCI(0).ID_Other
            objOItem_Class_DevelopmentConfigItem.Name = objDEVCI(0).Name_Other
            objOItem_Class_DevelopmentConfigItem.GUID_Parent = objDEVCI(0).ID_Parent_Other
            objOItem_Class_DevelopmentConfigItem.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDEVSTR = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Development_Structure" And obj.Ontology = objGlobals.Type_Class

        If objDEVSTR.Count > 0 Then
            objOItem_Class_Development_Structure = New clsOntologyItem
            objOItem_Class_Development_Structure.GUID = objDEVSTR(0).ID_Other
            objOItem_Class_Development_Structure.Name = objDEVSTR(0).Name_Other
            objOItem_Class_Development_Structure.GUID_Parent = objDEVSTR(0).ID_Parent_Other
            objOItem_Class_Development_Structure.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPARDEVSTR = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Parameter_Dev_Structure" And obj.Ontology = objGlobals.Type_Class

        If objPARDEVSTR.Count > 0 Then
            objOItem_Class_Parameter_Dev_Structure = New clsOntologyItem
            objOItem_Class_Parameter_Dev_Structure.GUID = objPARDEVSTR(0).ID_Other
            objOItem_Class_Parameter_Dev_Structure.Name = objPARDEVSTR(0).Name_Other
            objOItem_Class_Parameter_Dev_Structure.GUID_Parent = objPARDEVSTR(0).ID_Parent_Other
            objOItem_Class_Parameter_Dev_Structure.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPROC = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Process" And obj.Ontology = objGlobals.Type_Class

        If objPROC.Count > 0 Then
            objOItem_Class_Process = New clsOntologyItem
            objOItem_Class_Process.GUID = objPROC(0).ID_Other
            objOItem_Class_Process.Name = objPROC(0).Name_Other
            objOItem_Class_Process.GUID_Parent = objPROC(0).ID_Parent_Other
            objOItem_Class_Process.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDIR = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Directions" And obj.Ontology = objGlobals.Type_Class

        If objDIR.Count > 0 Then
            objOItem_Class_Directions = New clsOntologyItem
            objOItem_Class_Directions.GUID = objDIR(0).ID_Other
            objOItem_Class_Directions.Name = objDIR(0).Name_Other
            objOItem_Class_Directions.GUID_Parent = objDIR(0).ID_Parent_Other
            objOItem_Class_Directions.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOCN = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Localized_Names" And obj.Ontology = objGlobals.Type_Class

        If objLOCN.Count > 0 Then
            objOItem_Class_Localized_Names = New clsOntologyItem
            objOItem_Class_Localized_Names.GUID = objLOCN(0).ID_Other
            objOItem_Class_Localized_Names.Name = objLOCN(0).Name_Other
            objOItem_Class_Localized_Names.GUID_Parent = objLOCN(0).ID_Parent_Other
            objOItem_Class_Localized_Names.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBSOA = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_DBSchema_Of_Application" And obj.Ontology = objGlobals.Type_Class

        If objDBSOA.Count > 0 Then
            objOItem_Class_DBSchema_Of_Application = New clsOntologyItem
            objOItem_Class_DBSchema_Of_Application.GUID = objDBSOA(0).ID_Other
            objOItem_Class_DBSchema_Of_Application.Name = objDBSOA(0).Name_Other
            objOItem_Class_DBSchema_Of_Application.GUID_Parent = objDBSOA(0).ID_Parent_Other
            objOItem_Class_DBSchema_Of_Application.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBST = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_DB_Schema_Type" And obj.Ontology = objGlobals.Type_Class

        If objDBST.Count > 0 Then
            objOItem_Class_DB_Schema_Type = New clsOntologyItem
            objOItem_Class_DB_Schema_Type.GUID = objDBST(0).ID_Other
            objOItem_Class_DB_Schema_Type.Name = objDBST(0).Name_Other
            objOItem_Class_DB_Schema_Type.GUID_Parent = objDBST(0).ID_Parent_Other
            objOItem_Class_DB_Schema_Type.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFILE = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_File" And obj.Ontology = objGlobals.Type_Class

        If objFILE.Count > 0 Then
            objOItem_Class_File = New clsOntologyItem
            objOItem_Class_File.GUID = objFILE(0).ID_Other
            objOItem_Class_File.Name = objFILE(0).Name_Other
            objOItem_Class_File.GUID_Parent = objFILE(0).ID_Parent_Other
            objOItem_Class_File.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBOS = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Database_on_Server" And obj.Ontology = objGlobals.Type_Class

        If objDBOS.Count > 0 Then
            objOItem_Class_Database_on_Server = New clsOntologyItem
            objOItem_Class_Database_on_Server.GUID = objDBOS(0).ID_Other
            objOItem_Class_Database_on_Server.Name = objDBOS(0).Name_Other
            objOItem_Class_Database_on_Server.GUID_Parent = objDBOS(0).ID_Parent_Other
            objOItem_Class_Database_on_Server.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDB = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Database" And obj.Ontology = objGlobals.Type_Class

        If objDB.Count > 0 Then
            objOItem_Class_Database = New clsOntologyItem
            objOItem_Class_Database.GUID = objDB(0).ID_Other
            objOItem_Class_Database.Name = objDB(0).Name_Other
            objOItem_Class_Database.GUID_Parent = objDB(0).ID_Parent_Other
            objOItem_Class_Database.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSRV = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Server" And obj.Ontology = objGlobals.Type_Class

        If objSRV.Count > 0 Then
            objOItem_Class_Server = New clsOntologyItem
            objOItem_Class_Server.GUID = objSRV(0).ID_Other
            objOItem_Class_Server.Name = objSRV(0).Name_Other
            objOItem_Class_Server.GUID_Parent = objSRV(0).ID_Parent_Other
            objOItem_Class_Server.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objGUIC = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_GUI_Caption" And obj.Ontology = objGlobals.Type_Class

        If objGUIC.Count > 0 Then
            objOItem_Class_GUI_Caption = New clsOntologyItem
            objOItem_Class_GUI_Caption.GUID = objGUIC(0).ID_Other
            objOItem_Class_GUI_Caption.Name = objGUIC(0).Name_Other
            objOItem_Class_GUI_Caption.GUID_Parent = objGUIC(0).ID_Parent_Other
            objOItem_Class_GUI_Caption.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objGUIE = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_GUI_Entires" And obj.Ontology = objGlobals.Type_Class

        If objGUIE.Count > 0 Then
            objOItem_Class_GUI_Entires = New clsOntologyItem
            objOItem_Class_GUI_Entires.GUID = objGUIE(0).ID_Other
            objOItem_Class_GUI_Entires.Name = objGUIE(0).Name_Other
            objOItem_Class_GUI_Entires.GUID_Parent = objGUIE(0).ID_Parent_Other
            objOItem_Class_GUI_Entires.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objTTM = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_ToolTip_Messages" And obj.Ontology = objGlobals.Type_Class

        If objTTM.Count > 0 Then
            objOItem_Class_ToolTip_Messages = New clsOntologyItem
            objOItem_Class_ToolTip_Messages.GUID = objTTM(0).ID_Other
            objOItem_Class_ToolTip_Messages.Name = objTTM(0).Name_Other
            objOItem_Class_ToolTip_Messages.GUID_Parent = objTTM(0).ID_Parent_Other
            objOItem_Class_ToolTip_Messages.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOCM = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Localized_Message" And obj.Ontology = objGlobals.Type_Class

        If objLOCM.Count > 0 Then
            objOItem_Class_Localized_Message = New clsOntologyItem
            objOItem_Class_Localized_Message.GUID = objLOCM(0).ID_Other
            objOItem_Class_Localized_Message.Name = objLOCM(0).Name_Other
            objOItem_Class_Localized_Message.GUID_Parent = objLOCM(0).ID_Parent_Other
            objOItem_Class_Localized_Message.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSTWA = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Structure_Type_with_Aspects" And obj.Ontology = objGlobals.Type_Class

        If objSTWA.Count > 0 Then
            objOItem_Class_Structure_Type_with_Aspects = New clsOntologyItem
            objOItem_Class_Structure_Type_with_Aspects.GUID = objSTWA(0).ID_Other
            objOItem_Class_Structure_Type_with_Aspects.Name = objSTWA(0).Name_Other
            objOItem_Class_Structure_Type_with_Aspects.GUID_Parent = objSTWA(0).ID_Parent_Other
            objOItem_Class_Structure_Type_with_Aspects.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objMSG = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Messages" And obj.Ontology = objGlobals.Type_Class

        If objMSG.Count > 0 Then
            objOItem_Class_Messages = New clsOntologyItem
            objOItem_Class_Messages.GUID = objMSG(0).ID_Other
            objOItem_Class_Messages.Name = objMSG(0).Name_Other
            objOItem_Class_Messages.GUID_Parent = objMSG(0).ID_Parent_Other
            objOItem_Class_Messages.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDSI = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Dev_Structure_Invoke" And obj.Ontology = objGlobals.Type_Class

        If objDSI.Count > 0 Then
            objOItem_Class_Dev_Structure_Invoke = New clsOntologyItem
            objOItem_Class_Dev_Structure_Invoke.GUID = objDSI(0).ID_Other
            objOItem_Class_Dev_Structure_Invoke.Name = objDSI(0).Name_Other
            objOItem_Class_Dev_Structure_Invoke.GUID_Parent = objDSI(0).ID_Parent_Other
            objOItem_Class_Dev_Structure_Invoke.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objST = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Structure_Type" And obj.Ontology = objGlobals.Type_Class

        If objST.Count > 0 Then
            objOItem_Class_Structure_Type = New clsOntologyItem
            objOItem_Class_Structure_Type.GUID = objST(0).ID_Other
            objOItem_Class_Structure_Type.Name = objST(0).Name_Other
            objOItem_Class_Structure_Type.GUID_Parent = objST(0).ID_Parent_Other
            objOItem_Class_Structure_Type.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSTV = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Structure_Validity" And obj.Ontology = objGlobals.Type_Class

        If objSTV.Count > 0 Then
            objOItem_Class_Structure_Validity = New clsOntologyItem
            objOItem_Class_Structure_Validity.GUID = objSTV(0).ID_Other
            objOItem_Class_Structure_Validity.Name = objSTV(0).Name_Other
            objOItem_Class_Structure_Validity.GUID_Parent = objSTV(0).ID_Parent_Other
            objOItem_Class_Structure_Validity.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOBJ = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Objects" And obj.Ontology = objGlobals.Type_Class

        If objOBJ.Count > 0 Then
            objOItem_Class_Objects = New clsOntologyItem
            objOItem_Class_Objects.GUID = objOBJ(0).ID_Other
            objOItem_Class_Objects.Name = objOBJ(0).Name_Other
            objOItem_Class_Objects.GUID_Parent = objOBJ(0).ID_Parent_Other
            objOItem_Class_Objects.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDSPTTP = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Dev_Structure__Process_Type_to_Process_" And obj.Ontology = objGlobals.Type_Class

        If objDSPTTP.Count > 0 Then
            objOItem_Class_Dev_Structure__Process_Type_to_Process_ = New clsOntologyItem
            objOItem_Class_Dev_Structure__Process_Type_to_Process_.GUID = objDSPTTP(0).ID_Other
            objOItem_Class_Dev_Structure__Process_Type_to_Process_.Name = objDSPTTP(0).Name_Other
            objOItem_Class_Dev_Structure__Process_Type_to_Process_.GUID_Parent = objDSPTTP(0).ID_Parent_Other
            objOItem_Class_Dev_Structure__Process_Type_to_Process_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDEVS = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Dev_Structure" And obj.Ontology = objGlobals.Type_Class

        If objDEVS.Count > 0 Then
            objOItem_Class_Dev_Structure = New clsOntologyItem
            objOItem_Class_Dev_Structure.GUID = objDEVS(0).ID_Other
            objOItem_Class_Dev_Structure.Name = objDEVS(0).Name_Other
            objOItem_Class_Dev_Structure.GUID_Parent = objDEVS(0).ID_Parent_Other
            objOItem_Class_Dev_Structure.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSCENE = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Scene" And obj.Ontology = objGlobals.Type_Class

        If objSCENE.Count > 0 Then
            objOItem_Class_Scene = New clsOntologyItem
            objOItem_Class_Scene.GUID = objSCENE(0).ID_Other
            objOItem_Class_Scene.Name = objSCENE(0).Name_Other
            objOItem_Class_Scene.GUID_Parent = objSCENE(0).ID_Parent_Other
            objOItem_Class_Scene.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objMOD = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Module" And obj.Ontology = objGlobals.Type_Class

        If objMOD.Count > 0 Then
            objOItem_Class_Module = New clsOntologyItem
            objOItem_Class_Module.GUID = objMOD(0).ID_Other
            objOItem_Class_Module.Name = objMOD(0).Name_Other
            objOItem_Class_Module.GUID_Parent = objMOD(0).ID_Parent_Other
            objOItem_Class_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDL = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Development_Libraries" And obj.Ontology = objGlobals.Type_Class

        If objDL.Count > 0 Then
            objOItem_Class_Development_Libraries = New clsOntologyItem
            objOItem_Class_Development_Libraries.GUID = objDL(0).ID_Other
            objOItem_Class_Development_Libraries.Name = objDL(0).Name_Other
            objOItem_Class_Development_Libraries.GUID_Parent = objDL(0).ID_Parent_Other
            objOItem_Class_Development_Libraries.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIVM = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Image_Video_Management" And obj.Ontology = objGlobals.Type_Class

        If objIVM.Count > 0 Then
            objOItem_Class_Image_Video_Management = New clsOntologyItem
            objOItem_Class_Image_Video_Management.GUID = objIVM(0).ID_Other
            objOItem_Class_Image_Video_Management.Name = objIVM(0).Name_Other
            objOItem_Class_Image_Video_Management.GUID_Parent = objIVM(0).ID_Parent_Other
            objOItem_Class_Image_Video_Management.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSITEWC = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Sem_Items_to_expot_with_Children" And obj.Ontology = objGlobals.Type_Class

        If objSITEWC.Count > 0 Then
            objOItem_Class_Sem_Items_to_expot_with_Children = New clsOntologyItem
            objOItem_Class_Sem_Items_to_expot_with_Children.GUID = objSITEWC(0).ID_Other
            objOItem_Class_Sem_Items_to_expot_with_Children.Name = objSITEWC(0).Name_Other
            objOItem_Class_Sem_Items_to_expot_with_Children.GUID_Parent = objSITEWC(0).ID_Parent_Other
            objOItem_Class_Sem_Items_to_expot_with_Children.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objEM = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Export_Mode" And obj.Ontology = objGlobals.Type_Class

        If objEM.Count > 0 Then
            objOItem_Class_Export_Mode = New clsOntologyItem
            objOItem_Class_Export_Mode.GUID = objEM(0).ID_Other
            objOItem_Class_Export_Mode.Name = objEM(0).Name_Other
            objOItem_Class_Export_Mode.GUID_Parent = objEM(0).ID_Parent_Other
            objOItem_Class_Export_Mode.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDSCH = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Database_Schema" And obj.Ontology = objGlobals.Type_Class

        If objDSCH.Count > 0 Then
            objOItem_Class_Database_Schema = New clsOntologyItem
            objOItem_Class_Database_Schema.GUID = objDSCH(0).ID_Other
            objOItem_Class_Database_Schema.Name = objDSCH(0).Name_Other
            objOItem_Class_Database_Schema.GUID_Parent = objDSCH(0).ID_Parent_Other
            objOItem_Class_Database_Schema.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDEVM = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Development_Module" And obj.Ontology = objGlobals.Type_Class

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


        Dim objIIS = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_isInState" And obj.Ontology = objGlobals.Type_RelationType

        If objIIS.Count > 0 Then
            objOItem_RelationType_isInState = New clsOntologyItem
            objOItem_RelationType_isInState.GUID = objIIS(0).ID_Other
            objOItem_RelationType_isInState.Name = objIIS(0).Name_Other
            objOItem_RelationType_isInState.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objISSUB = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_isSubordinated" And obj.Ontology = objGlobals.Type_RelationType

        If objISSUB.Count > 0 Then
            objOItem_RelationType_isSubordinated = New clsOntologyItem
            objOItem_RelationType_isSubordinated.GUID = objISSUB(0).ID_Other
            objOItem_RelationType_isSubordinated.Name = objISSUB(0).Name_Other
            objOItem_RelationType_isSubordinated.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objWDB = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "relationtype_wasDevelopedBy" And obj.Ontology = objGlobals.Type_RelationType

        If objWDB.Count > 0 Then
            objOItem_RelationType_wasDevelopedBy = New clsOntologyItem
            objOItem_RelationType_wasDevelopedBy.GUID = objWDB(0).ID_Other
            objOItem_RelationType_wasDevelopedBy.Name = objWDB(0).Name_Other
            objOItem_RelationType_wasDevelopedBy.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objWCB = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_wasCreatedBy" And obj.Ontology = objGlobals.Type_RelationType

        If objWCB.Count > 0 Then
            objOitem_RelationType_wasCreatedBy = New clsOntologyItem
            objOitem_RelationType_wasCreatedBy.GUID = objWCB(0).ID_Other
            objOitem_RelationType_wasCreatedBy.Name = objWCB(0).Name_Other
            objOitem_RelationType_wasCreatedBy.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIWI = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_isWrittenIn" And obj.Ontology = objGlobals.Type_RelationType

        If objIWI.Count > 0 Then
            objOitem_RelationType_isWrittenIn = New clsOntologyItem
            objOitem_RelationType_isWrittenIn.GUID = objIWI(0).ID_Other
            objOitem_RelationType_isWrittenIn.Name = objIWI(0).Name_Other
            objOitem_RelationType_isWrittenIn.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSTD = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_Standard" And obj.Ontology = objGlobals.Type_RelationType

        If objSTD.Count > 0 Then
            objOitem_RelationType_Standard = New clsOntologyItem
            objOitem_RelationType_Standard.GUID = objSTD(0).ID_Other
            objOitem_RelationType_Standard.Name = objSTD(0).Name_Other
            objOitem_RelationType_Standard.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSLI = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_SourcesLocatedIn" And obj.Ontology = objGlobals.Type_RelationType

        If objSLI.Count > 0 Then
            objOitem_RelationType_SourcesLocatedIn = New clsOntologyItem
            objOitem_RelationType_SourcesLocatedIn.GUID = objSLI(0).ID_Other
            objOitem_RelationType_SourcesLocatedIn.Name = objSLI(0).Name_Other
            objOitem_RelationType_SourcesLocatedIn.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPOSS = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_Possible" And obj.Ontology = objGlobals.Type_RelationType

        If objPOSS.Count > 0 Then
            objOitem_RelationType_Possible = New clsOntologyItem
            objOitem_RelationType_Possible.GUID = objPOSS(0).ID_Other
            objOitem_RelationType_Possible.Name = objPOSS(0).Name_Other
            objOitem_RelationType_Possible.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objREQ = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_Request" And obj.Ontology = objGlobals.Type_RelationType

        If objREQ.Count > 0 Then
            objOitem_RelationType_Request = New clsOntologyItem
            objOitem_RelationType_Request.GUID = objREQ(0).ID_Other
            objOitem_RelationType_Request.Name = objREQ(0).Name_Other
            objOitem_RelationType_Request.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objHAP = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_Happened" And obj.Ontology = objGlobals.Type_RelationType

        If objHAP.Count > 0 Then
            objOitem_RelationType_Happened = New clsOntologyItem
            objOitem_RelationType_Happened.GUID = objHAP(0).ID_Other
            objOitem_RelationType_Happened.Name = objHAP(0).Name_Other
            objOitem_RelationType_Happened.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPROV = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_provides" And obj.Ontology = objGlobals.Type_RelationType

        If objPROV.Count > 0 Then
            objOitem_RelationType_provides = New clsOntologyItem
            objOitem_RelationType_provides.GUID = objPROV(0).ID_Other
            objOitem_RelationType_provides.Name = objPROV(0).Name_Other
            objOitem_RelationType_provides.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBEL = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_belongsTo" And obj.Ontology = objGlobals.Type_RelationType

        If objBEL.Count > 0 Then
            objOItem_RelationType_belongsTo = New clsOntologyItem
            objOItem_RelationType_belongsTo.GUID = objBEL(0).ID_Other
            objOItem_RelationType_belongsTo.Name = objBEL(0).Name_Other
            objOItem_RelationType_belongsTo.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOFF = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_offers" And obj.Ontology = objGlobals.Type_RelationType

        If objOFF.Count > 0 Then
            objOitem_RelationType_offers = New clsOntologyItem
            objOitem_RelationType_offers.GUID = objOFF(0).ID_Other
            objOitem_RelationType_offers.Name = objOFF(0).Name_Other
            objOitem_RelationType_offers.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objADD = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_additional" And obj.Ontology = objGlobals.Type_RelationType

        If objADD.Count > 0 Then
            objOitem_RelationType_additional = New clsOntologyItem
            objOitem_RelationType_additional.GUID = objADD(0).ID_Other
            objOitem_RelationType_additional.Name = objADD(0).Name_Other
            objOitem_RelationType_additional.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If


        Dim objISDESCBY = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_isDescribedBy" And obj.Ontology = objGlobals.Type_RelationType

        If objISDESCBY.Count > 0 Then
            objOitem_RelationType_isDescribedBy = New clsOntologyItem
            objOitem_RelationType_isDescribedBy.GUID = objISDESCBY(0).ID_Other
            objOitem_RelationType_isDescribedBy.Name = objISDESCBY(0).Name_Other
            objOitem_RelationType_isDescribedBy.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objNEED = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_needs" And obj.Ontology = objGlobals.Type_RelationType

        If objNEED.Count > 0 Then
            objOitem_RelationType_needs = New clsOntologyItem
            objOitem_RelationType_needs.GUID = objNEED(0).ID_Other
            objOitem_RelationType_needs.Name = objNEED(0).Name_Other
            objOitem_RelationType_needs.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCONT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_contains" And obj.Ontology = objGlobals.Type_RelationType

        If objCONT.Count > 0 Then
            objOitem_RelationType_contains = New clsOntologyItem
            objOitem_RelationType_contains.GUID = objCONT(0).ID_Other
            objOitem_RelationType_contains.Name = objCONT(0).Name_Other
            objOitem_RelationType_contains.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objWOKOFF = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_works_off" And obj.Ontology = objGlobals.Type_RelationType

        If objWOKOFF.Count > 0 Then
            objOitem_RelationType_works_off = New clsOntologyItem
            objOitem_RelationType_works_off.GUID = objWOKOFF(0).ID_Other
            objOitem_RelationType_works_off.Name = objWOKOFF(0).Name_Other
            objOitem_RelationType_works_off.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDIRBY = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_directed_by" And obj.Ontology = objGlobals.Type_RelationType

        If objDIRBY.Count > 0 Then
            objOitem_RelationType_directed_by = New clsOntologyItem
            objOitem_RelationType_directed_by.GUID = objDIRBY(0).ID_Other
            objOitem_RelationType_directed_by.Name = objDIRBY(0).Name_Other
            objOitem_RelationType_directed_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDESC = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_describes" And obj.Ontology = objGlobals.Type_RelationType

        If objDESC.Count > 0 Then
            objOitem_RelationType_describes = New clsOntologyItem
            objOitem_RelationType_describes.GUID = objDESC(0).ID_Other
            objOitem_RelationType_describes.Name = objDESC(0).Name_Other
            objOitem_RelationType_describes.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objALTF = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_alternative_for" And obj.Ontology = objGlobals.Type_RelationType

        If objALTF.Count > 0 Then
            objOitem_RelationType_alternative_for = New clsOntologyItem
            objOitem_RelationType_alternative_for.GUID = objALTF(0).ID_Other
            objOitem_RelationType_alternative_for.Name = objALTF(0).Name_Other
            objOitem_RelationType_alternative_for.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objEXTO = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_export_to" And obj.Ontology = objGlobals.Type_RelationType

        If objEXTO.Count > 0 Then
            objOitem_RelationType_export_to = New clsOntologyItem
            objOitem_RelationType_export_to.GUID = objEXTO(0).ID_Other
            objOitem_RelationType_export_to.Name = objEXTO(0).Name_Other
            objOitem_RelationType_export_to.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objISOFT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_is_of_Type" And obj.Ontology = objGlobals.Type_RelationType

        If objISOFT.Count > 0 Then
            objOitem_RelationType_is_of_Type = New clsOntologyItem
            objOitem_RelationType_is_of_Type.GUID = objISOFT(0).ID_Other
            objOitem_RelationType_is_of_Type.Name = objISOFT(0).Name_Other
            objOitem_RelationType_is_of_Type.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLI = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_located_in" And obj.Ontology = objGlobals.Type_RelationType

        If objLI.Count > 0 Then
            objOitem_RelationType_located_in = New clsOntologyItem
            objOitem_RelationType_located_in.GUID = objLI(0).ID_Other
            objOitem_RelationType_located_in.Name = objLI(0).Name_Other
            objOitem_RelationType_located_in.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objISDB = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_is_defined_by" And obj.Ontology = objGlobals.Type_RelationType

        If objISDB.Count > 0 Then
            objOitem_RelationType_is_defined_by = New clsOntologyItem
            objOitem_RelationType_is_defined_by.GUID = objISDB(0).ID_Other
            objOitem_RelationType_is_defined_by.Name = objISDB(0).Name_Other
            objOitem_RelationType_is_defined_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objUM = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_User_Message" And obj.Ontology = objGlobals.Type_RelationType

        If objUM.Count > 0 Then
            objOitem_RelationType_User_Message = New clsOntologyItem
            objOitem_RelationType_User_Message.GUID = objUM(0).ID_Other
            objOitem_RelationType_User_Message.Name = objUM(0).Name_Other
            objOitem_RelationType_User_Message.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIM = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_Input_Message" And obj.Ontology = objGlobals.Type_RelationType

        If objIM.Count > 0 Then
            objOitem_RelationType_Input_Message = New clsOntologyItem
            objOitem_RelationType_Input_Message.GUID = objIM(0).ID_Other
            objOitem_RelationType_Input_Message.Name = objIM(0).Name_Other
            objOitem_RelationType_Input_Message.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objERM = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_Error_Message" And obj.Ontology = objGlobals.Type_RelationType

        If objERM.Count > 0 Then
            objOitem_RelationType_Error_Message = New clsOntologyItem
            objOitem_RelationType_Error_Message.GUID = objERM(0).ID_Other
            objOitem_RelationType_Error_Message.Name = objERM(0).Name_Other
            objOitem_RelationType_Error_Message.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSUBO = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_superordinate" And obj.Ontology = objGlobals.Type_RelationType

        If objSUBO.Count > 0 Then
            objOitem_RelationType_superordinate = New clsOntologyItem
            objOitem_RelationType_superordinate.GUID = objSUBO(0).ID_Other
            objOitem_RelationType_superordinate.Name = objSUBO(0).Name_Other
            objOitem_RelationType_superordinate.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIVAC = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_invoking_Actor" And obj.Ontology = objGlobals.Type_RelationType

        If objIVAC.Count > 0 Then
            objOitem_RelationType_invoking_Actor = New clsOntologyItem
            objOitem_RelationType_invoking_Actor.GUID = objIVAC(0).ID_Other
            objOitem_RelationType_invoking_Actor.Name = objIVAC(0).Name_Other
            objOitem_RelationType_invoking_Actor.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIVACT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_invoked_Actor" And obj.Ontology = objGlobals.Type_RelationType

        If objIVACT.Count > 0 Then
            objOitem_RelationType_invoked_Actor = New clsOntologyItem
            objOitem_RelationType_invoked_Actor.GUID = objIVACT(0).ID_Other
            objOitem_RelationType_invoked_Actor.Name = objIVACT(0).Name_Other
            objOitem_RelationType_invoked_Actor.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objACB = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_access_by" And obj.Ontology = objGlobals.Type_RelationType

        If objACB.Count > 0 Then
            objOitem_RelationType_access_by = New clsOntologyItem
            objOitem_RelationType_access_by.GUID = objACB(0).ID_Other
            objOitem_RelationType_access_by.Name = objACB(0).Name_Other
            objOitem_RelationType_access_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBELP = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_belonging_Paramter" And obj.Ontology = objGlobals.Type_RelationType

        If objBELP.Count > 0 Then
            objOitem_RelationType_belonging_Paramter = New clsOntologyItem
            objOitem_RelationType_belonging_Paramter.GUID = objBELP(0).ID_Other
            objOitem_RelationType_belonging_Paramter.Name = objBELP(0).Name_Other
            objOitem_RelationType_belonging_Paramter.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIIO = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_is_instance_of" And obj.Ontology = objGlobals.Type_RelationType

        If objIIO.Count > 0 Then
            objOitem_RelationType_is_instance_of = New clsOntologyItem
            objOitem_RelationType_is_instance_of.GUID = objIIO(0).ID_Other
            objOitem_RelationType_is_instance_of.Name = objIIO(0).Name_Other
            objOitem_RelationType_is_instance_of.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIGN = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_ignore" And obj.Ontology = objGlobals.Type_RelationType

        If objIGN.Count > 0 Then
            objOitem_RelationType_ignore = New clsOntologyItem
            objOitem_RelationType_ignore.GUID = objIGN(0).ID_Other
            objOitem_RelationType_ignore.Name = objIGN(0).Name_Other
            objOitem_RelationType_ignore.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objHAND = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_handles" And obj.Ontology = objGlobals.Type_RelationType

        If objHAND.Count > 0 Then
            objOitem_RelationType_handles = New clsOntologyItem
            objOitem_RelationType_handles.GUID = objHAND(0).ID_Other
            objOitem_RelationType_handles.Name = objHAND(0).Name_Other
            objOitem_RelationType_handles.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objINT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_initializing" And obj.Ontology = objGlobals.Type_RelationType

        If objINT.Count > 0 Then
            objOitem_RelationType_initializing = New clsOntologyItem
            objOitem_RelationType_initializing.GUID = objINT(0).ID_Other
            objOitem_RelationType_initializing.Name = objINT(0).Name_Other
            objOitem_RelationType_initializing.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOFFB = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_offered_by" And obj.Ontology = objGlobals.Type_RelationType

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


        Dim objLOGSA = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "token_LogState_Active" And obj.Ontology = objGlobals.Type_Object

        If objLOGSA.Count > 0 Then
            objOitem_Object_LogState_Active = New clsOntologyItem
            objOitem_Object_LogState_Active.GUID = objLOGSA(0).ID_Other
            objOitem_Object_LogState_Active.Name = objLOGSA(0).Name_Other
            objOitem_Object_LogState_Active.GUID_Parent = objLOGSA(0).ID_Parent_Other
            objOitem_Object_LogState_Active.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSI = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "token_LogState_Inactive" And obj.Ontology = objGlobals.Type_Object

        If objLOGSI.Count > 0 Then
            objOitem_Object_LogState_Inactive = New clsOntologyItem
            objOitem_Object_LogState_Inactive.GUID = objLOGSI(0).ID_Other
            objOitem_Object_LogState_Inactive.Name = objLOGSI(0).Name_Other
            objOitem_Object_LogState_Inactive.GUID_Parent = objLOGSI(0).ID_Parent_Other
            objOitem_Object_LogState_Inactive.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSOP = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_LogState_Open" And obj.Ontology = objGlobals.Type_Object

        If objLOGSOP.Count > 0 Then
            objOitem_Object_LogState_Open = New clsOntologyItem
            objOitem_Object_LogState_Open.GUID = objLOGSOP(0).ID_Other
            objOitem_Object_LogState_Open.Name = objLOGSOP(0).Name_Other
            objOitem_Object_LogState_Open.GUID_Parent = objLOGSOP(0).ID_Parent_Other
            objOitem_Object_LogState_Open.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSCH = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_LogState_Changed" And obj.Ontology = objGlobals.Type_Object

        If objLOGSCH.Count > 0 Then
            objOitem_Object_LogState_Changed = New clsOntologyItem
            objOitem_Object_LogState_Changed.GUID = objLOGSCH(0).ID_Other
            objOitem_Object_LogState_Changed.Name = objLOGSCH(0).Name_Other
            objOitem_Object_LogState_Changed.GUID_Parent = objLOGSCH(0).ID_Parent_Other
            objOitem_Object_LogState_Changed.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSOBS = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_LogState_Obsolete" And obj.Ontology = objGlobals.Type_Object

        If objLOGSOBS.Count > 0 Then
            objOitem_Object_LogState_Obsolete = New clsOntologyItem
            objOitem_Object_LogState_Obsolete.GUID = objLOGSOBS(0).ID_Other
            objOitem_Object_LogState_Obsolete.Name = objLOGSOBS(0).Name_Other
            objOitem_Object_LogState_Obsolete.GUID_Parent = objLOGSOBS(0).ID_Parent_Other
            objOitem_Object_LogState_Obsolete.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSINF = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_LogState_Information" And obj.Ontology = objGlobals.Type_Object

        If objLOGSINF.Count > 0 Then
            objOitem_Object_LogState_Information = New clsOntologyItem
            objOitem_Object_LogState_Information.GUID = objLOGSINF(0).ID_Other
            objOitem_Object_LogState_Information.Name = objLOGSINF(0).Name_Other
            objOitem_Object_LogState_Information.GUID_Parent = objLOGSINF(0).ID_Parent_Other
            objOitem_Object_LogState_Information.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSREQ = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_LogState_Request" And obj.Ontology = objGlobals.Type_Object

        If objLOGSREQ.Count > 0 Then
            objOitem_Object_LogState_Request = New clsOntologyItem
            objOitem_Object_LogState_Request.GUID = objLOGSREQ(0).ID_Other
            objOitem_Object_LogState_Request.Name = objLOGSREQ(0).Name_Other
            objOitem_Object_LogState_Request.GUID_Parent = objLOGSREQ(0).ID_Parent_Other
            objOitem_Object_LogState_Request.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSVC = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_LogState_VersionChanged" And obj.Ontology = objGlobals.Type_Object

        If objLOGSVC.Count > 0 Then
            objOitem_Object_LogState_VersionChanged = New clsOntologyItem
            objOitem_Object_LogState_VersionChanged.GUID = objLOGSVC(0).ID_Other
            objOitem_Object_LogState_VersionChanged.Name = objLOGSVC(0).Name_Other
            objOitem_Object_LogState_VersionChanged.GUID_Parent = objLOGSVC(0).ID_Parent_Other
            objOitem_Object_LogState_VersionChanged.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSC = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_LogState_Create" And obj.Ontology = objGlobals.Type_Object

        If objLOGSC.Count > 0 Then
            objOitem_Object_LogState_Create = New clsOntologyItem
            objOitem_Object_LogState_Create.GUID = objLOGSC(0).ID_Other
            objOitem_Object_LogState_Create.Name = objLOGSC(0).Name_Other
            objOitem_Object_LogState_Create.GUID_Parent = objLOGSC(0).ID_Parent_Other
            objOitem_Object_LogState_Create.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPSDS = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_PossibleStates_DevelopmentStandard" And obj.Ontology = objGlobals.Type_Object

        If objPSDS.Count > 0 Then
            objOitem_Object_PossibleStates_DevelopmentStandard = New clsOntologyItem
            objOitem_Object_PossibleStates_DevelopmentStandard.GUID = objPSDS(0).ID_Other
            objOitem_Object_PossibleStates_DevelopmentStandard.Name = objPSDS(0).Name_Other
            objOitem_Object_PossibleStates_DevelopmentStandard.GUID_Parent = objPSDS(0).ID_Parent_Other
            objOitem_Object_PossibleStates_DevelopmentStandard.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLOGSCIA = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_LogState_ConfigItemAdded" And obj.Ontology = objGlobals.Type_Object

        If objLOGSCIA.Count > 0 Then
            objOitem_Object_LogState_ConfigItemAdded = New clsOntologyItem
            objOitem_Object_LogState_ConfigItemAdded.GUID = objLOGSCIA(0).ID_Other
            objOitem_Object_LogState_ConfigItemAdded.Name = objLOGSCIA(0).Name_Other
            objOitem_Object_LogState_ConfigItemAdded.GUID_Parent = objLOGSCIA(0).ID_Parent_Other
            objOitem_Object_LogState_ConfigItemAdded.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCLSLXMLXML = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_clsLocalConfig_xml_XML" And obj.Ontology = objGlobals.Type_Object

        If objCLSLXMLXML.Count > 0 Then
            objOitem_Object_clsLocalConfig_xml_XML = New clsOntologyItem
            objOitem_Object_clsLocalConfig_xml_XML.GUID = objCLSLXMLXML(0).ID_Other
            objOitem_Object_clsLocalConfig_xml_XML.Name = objCLSLXMLXML(0).Name_Other
            objOitem_Object_clsLocalConfig_xml_XML.GUID_Parent = objCLSLXMLXML(0).ID_Parent_Other
            objOitem_Object_clsLocalConfig_xml_XML.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDECCX = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Declaration_Configitems_XML" And obj.Ontology = objGlobals.Type_Object

        If objDECCX.Count > 0 Then
            objOitem_Object_Declaration_Configitems_XML = New clsOntologyItem
            objOitem_Object_Declaration_Configitems_XML.GUID = objDECCX(0).ID_Other
            objOitem_Object_Declaration_Configitems_XML.Name = objDECCX(0).Name_Other
            objOitem_Object_Declaration_Configitems_XML.GUID_Parent = objDECCX(0).ID_Parent_Other
            objOitem_Object_Declaration_Configitems_XML.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIRCX = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Initialize_RelationType__ConfigItem__XML" And obj.Ontology = objGlobals.Type_Object

        If objIRCX.Count > 0 Then
            objOitem_Object_Initialize_RelationType__ConfigItem__XML = New clsOntologyItem
            objOitem_Object_Initialize_RelationType__ConfigItem__XML.GUID = objIRCX(0).ID_Other
            objOitem_Object_Initialize_RelationType__ConfigItem__XML.Name = objIRCX(0).Name_Other
            objOitem_Object_Initialize_RelationType__ConfigItem__XML.GUID_Parent = objIRCX(0).ID_Parent_Other
            objOitem_Object_Initialize_RelationType__ConfigItem__XML.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objITCIX = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Initialize_Token__ConfigItem__XML" And obj.Ontology = objGlobals.Type_Object

        If objITCIX.Count > 0 Then
            objOitem_Object_Initialize_Object__ConfigItem__XML = New clsOntologyItem
            objOitem_Object_Initialize_Object__ConfigItem__XML.GUID = objITCIX(0).ID_Other
            objOitem_Object_Initialize_Object__ConfigItem__XML.Name = objITCIX(0).Name_Other
            objOitem_Object_Initialize_Object__ConfigItem__XML.GUID_Parent = objITCIX(0).ID_Parent_Other
            objOitem_Object_Initialize_Object__ConfigItem__XML.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIACX = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Initilize_Attribute__ConfigItem__XML" And obj.Ontology = objGlobals.Type_Object

        If objIACX.Count > 0 Then
            objOitem_Object_Initilize_Attribute__ConfigItem__XML = New clsOntologyItem
            objOitem_Object_Initilize_Attribute__ConfigItem__XML.GUID = objIACX(0).ID_Other
            objOitem_Object_Initilize_Attribute__ConfigItem__XML.Name = objIACX(0).Name_Other
            objOitem_Object_Initilize_Attribute__ConfigItem__XML.GUID_Parent = objIACX(0).ID_Parent_Other
            objOitem_Object_Initilize_Attribute__ConfigItem__XML.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objITCX = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Initilize_Type__ConfigItem__XML" And obj.Ontology = objGlobals.Type_Object

        If objITCX.Count > 0 Then
            objOitem_Object_Initilize_Type__ConfigItem__XML = New clsOntologyItem
            objOitem_Object_Initilize_Type__ConfigItem__XML.GUID = objITCX(0).ID_Other
            objOitem_Object_Initilize_Type__ConfigItem__XML.Name = objITCX(0).Name_Other
            objOitem_Object_Initilize_Type__ConfigItem__XML.GUID_Parent = objITCX(0).ID_Parent_Other
            objOitem_Object_Initilize_Type__ConfigItem__XML.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPCX = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Property_ConfigItem_XML" And obj.Ontology = objGlobals.Type_Object

        If objPCX.Count > 0 Then
            objOitem_Object_Property_ConfigItem_XML = New clsOntologyItem
            objOitem_Object_Property_ConfigItem_XML.GUID = objPCX(0).ID_Other
            objOitem_Object_Property_ConfigItem_XML.Name = objPCX(0).Name_Other
            objOitem_Object_Property_ConfigItem_XML.GUID_Parent = objPCX(0).ID_Parent_Other
            objOitem_Object_Property_ConfigItem_XML.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDI = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Directions_IN" And obj.Ontology = objGlobals.Type_Object

        If objDI.Count > 0 Then
            objOitem_Object_Directions_IN = New clsOntologyItem
            objOitem_Object_Directions_IN.GUID = objDI(0).ID_Other
            objOitem_Object_Directions_IN.Name = objDI(0).Name_Other
            objOitem_Object_Directions_IN.GUID_Parent = objDI(0).ID_Parent_Other
            objOitem_Object_Directions_IN.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDO = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Directions_OUT" And obj.Ontology = objGlobals.Type_Object

        If objDO.Count > 0 Then
            objOitem_Object_Directions_OUT = New clsOntologyItem
            objOitem_Object_Directions_OUT.GUID = objDO(0).ID_Other
            objOitem_Object_Directions_OUT.Name = objDO(0).Name_Other
            objOitem_Object_Directions_OUT.GUID_Parent = objDO(0).ID_Parent_Other
            objOitem_Object_Directions_OUT.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBSTU = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_DB_Schema_Type_User" And obj.Ontology = objGlobals.Type_Object

        If objDBSTU.Count > 0 Then
            objOitem_Object_DB_Schema_Type_User = New clsOntologyItem
            objOitem_Object_DB_Schema_Type_User.GUID = objDBSTU(0).ID_Other
            objOitem_Object_DB_Schema_Type_User.Name = objDBSTU(0).Name_Other
            objOitem_Object_DB_Schema_Type_User.GUID_Parent = objDBSTU(0).ID_Parent_Other
            objOitem_Object_DB_Schema_Type_User.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBSTM = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_DB_Schema_Type_Module" And obj.Ontology = objGlobals.Type_Object

        If objDBSTM.Count > 0 Then
            objOitem_Object_DB_Schema_Type_Module = New clsOntologyItem
            objOitem_Object_DB_Schema_Type_Module.GUID = objDBSTM(0).ID_Other
            objOitem_Object_DB_Schema_Type_Module.Name = objDBSTM(0).Name_Other
            objOitem_Object_DB_Schema_Type_Module.GUID_Parent = objDBSTM(0).ID_Parent_Other
            objOitem_Object_DB_Schema_Type_Module.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBSTC = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_DB_Schema_Type_Config" And obj.Ontology = objGlobals.Type_Object

        If objDBSTC.Count > 0 Then
            objOitem_Object_DB_Schema_Type_Config = New clsOntologyItem
            objOitem_Object_DB_Schema_Type_Config.GUID = objDBSTC(0).ID_Other
            objOitem_Object_DB_Schema_Type_Config.Name = objDBSTC(0).Name_Other
            objOitem_Object_DB_Schema_Type_Config.GUID_Parent = objDBSTC(0).ID_Parent_Other
            objOitem_Object_DB_Schema_Type_Config.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objVLP = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_List_Properties" And obj.Ontology = objGlobals.Type_Object

        If objVLP.Count > 0 Then
            objOitem_Object_Variable_List_Properties = New clsOntologyItem
            objOitem_Object_Variable_List_Properties.GUID = objVLP(0).ID_Other
            objOitem_Object_Variable_List_Properties.Name = objVLP(0).Name_Other
            objOitem_Object_Variable_List_Properties.GUID_Parent = objVLP(0).ID_Parent_Other
            objOitem_Object_Variable_List_Properties.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objVLICT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_List_Initialize_ConfigItems_Types" And obj.Ontology = objGlobals.Type_Object

        If objVLICT.Count > 0 Then
            objOitem_Object_Variable_List_Initialize_ConfigItems_Types = New clsOntologyItem
            objOitem_Object_Variable_List_Initialize_ConfigItems_Types.GUID = objVLICT(0).ID_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_Types.Name = objVLICT(0).Name_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_Types.GUID_Parent = objVLICT(0).ID_Parent_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_Types.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objVLICTOK = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_List_Initialize_ConfigItems_Token" And obj.Ontology = objGlobals.Type_Object

        If objVLICTOK.Count > 0 Then
            objOitem_Object_Variable_List_Initialize_ConfigItems_Object = New clsOntologyItem
            objOitem_Object_Variable_List_Initialize_ConfigItems_Object.GUID = objVLICTOK(0).ID_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_Object.Name = objVLICTOK(0).Name_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_Object.GUID_Parent = objVLICTOK(0).ID_Parent_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_Object.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objVLICIR = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_List_Initialize_ConfigItems_RelationTypes" And obj.Ontology = objGlobals.Type_Object

        If objVLICIR.Count > 0 Then
            objOitem_Object_Variable_List_Initialize_ConfigItems_RelationTypes = New clsOntologyItem
            objOitem_Object_Variable_List_Initialize_ConfigItems_RelationTypes.GUID = objVLICIR(0).ID_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_RelationTypes.Name = objVLICIR(0).Name_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_RelationTypes.GUID_Parent = objVLICIR(0).ID_Parent_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_RelationTypes.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objVLICIA = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_List_Initialize_ConfigItems_Attributes" And obj.Ontology = objGlobals.Type_Object

        If objVLICIA.Count > 0 Then
            objOitem_Object_Variable_List_Initialize_ConfigItems_Attributes = New clsOntologyItem
            objOitem_Object_Variable_List_Initialize_ConfigItems_Attributes.GUID = objVLICIA(0).ID_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_Attributes.Name = objVLICIA(0).Name_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_Attributes.GUID_Parent = objVLICIA(0).ID_Parent_Other
            objOitem_Object_Variable_List_Initialize_ConfigItems_Attributes.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objVLDCI = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_List_Declaration_ConfigItems" And obj.Ontology = objGlobals.Type_Object

        If objVLDCI.Count > 0 Then
            objOitem_Object_Variable_List_Declaration_ConfigItems = New clsOntologyItem
            objOitem_Object_Variable_List_Declaration_ConfigItems.GUID = objVLDCI(0).ID_Other
            objOitem_Object_Variable_List_Declaration_ConfigItems.Name = objVLDCI(0).Name_Other
            objOitem_Object_Variable_List_Declaration_ConfigItems.GUID_Parent = objVLDCI(0).ID_Parent_Other
            objOitem_Object_Variable_List_Declaration_ConfigItems.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDEVSS = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Dev_Structure_Schleife" And obj.Ontology = objGlobals.Type_Object

        If objDEVSS.Count > 0 Then
            objOitem_Object_Dev_Structure_Schleife = New clsOntologyItem
            objOitem_Object_Dev_Structure_Schleife.GUID = objDEVSS(0).ID_Other
            objOitem_Object_Dev_Structure_Schleife.Name = objDEVSS(0).Name_Other
            objOitem_Object_Dev_Structure_Schleife.GUID_Parent = objDEVSS(0).ID_Parent_Other
            objOitem_Object_Dev_Structure_Schleife.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDEVR = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Dev_Structure_Return" And obj.Ontology = objGlobals.Type_Object

        If objDEVR.Count > 0 Then
            objOitem_Object_Dev_Structure_Return = New clsOntologyItem
            objOitem_Object_Dev_Structure_Return.GUID = objDEVR(0).ID_Other
            objOitem_Object_Dev_Structure_Return.Name = objDEVR(0).Name_Other
            objOitem_Object_Dev_Structure_Return.GUID_Parent = objDEVR(0).ID_Parent_Other
            objOitem_Object_Dev_Structure_Return.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDEVD = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Dev_Structure_Database" And obj.Ontology = objGlobals.Type_Object

        If objDEVD.Count > 0 Then
            objOitem_Object_Dev_Structure_Database = New clsOntologyItem
            objOitem_Object_Dev_Structure_Database.GUID = objDEVD(0).ID_Other
            objOitem_Object_Dev_Structure_Database.Name = objDEVD(0).Name_Other
            objOitem_Object_Dev_Structure_Database.GUID_Parent = objDEVD(0).ID_Parent_Other
            objOitem_Object_Dev_Structure_Database.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objMODDEVM = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Module_Development_Management" And obj.Ontology = objGlobals.Type_Object

        If objMODDEVM.Count > 0 Then
            objOitem_Object_Module_Development_Management = New clsOntologyItem
            objOitem_Object_Module_Development_Management.GUID = objMODDEVM(0).ID_Other
            objOitem_Object_Module_Development_Management.Name = objMODDEVM(0).Name_Other
            objOitem_Object_Module_Development_Management.GUID_Parent = objMODDEVM(0).ID_Parent_Other
            objOitem_Object_Module_Development_Management.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objMGCOITOT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Export_Mode_Grant_Children_of_Item__Token_of_Type_" And obj.Ontology = objGlobals.Type_Object

        If objMGCOITOT.Count > 0 Then
            objOitem_Object_Export_Mode_Grant_Children_of_Item__Object_of_Type_ = New clsOntologyItem
            objOitem_Object_Export_Mode_Grant_Children_of_Item__Object_of_Type_.GUID = objMGCOITOT(0).ID_Other
            objOitem_Object_Export_Mode_Grant_Children_of_Item__Object_of_Type_.Name = objMGCOITOT(0).Name_Other
            objOitem_Object_Export_Mode_Grant_Children_of_Item__Object_of_Type_.GUID_Parent = objMGCOITOT(0).ID_Parent_Other
            objOitem_Object_Export_Mode_Grant_Children_of_Item__Object_of_Type_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objEMGCOITOT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Export_Mode_Deny_Only_Children__Token_of_Type_" And obj.Ontology = objGlobals.Type_Object

        If objEMGCOITOT.Count > 0 Then
            objOitem_Object_Export_Mode_Deny_Only_Children__Object_of_Type_ = New clsOntologyItem
            objOitem_Object_Export_Mode_Deny_Only_Children__Object_of_Type_.GUID = objEMGCOITOT(0).ID_Other
            objOitem_Object_Export_Mode_Deny_Only_Children__Object_of_Type_.Name = objEMGCOITOT(0).Name_Other
            objOitem_Object_Export_Mode_Deny_Only_Children__Object_of_Type_.GUID_Parent = objEMGCOITOT(0).ID_Parent_Other
            objOitem_Object_Export_Mode_Deny_Only_Children__Object_of_Type_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objEMDIWCHTT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Export_Mode_Deny_Item_with_Children__Type___Token_" And obj.Ontology = objGlobals.Type_Object

        If objEMDIWCHTT.Count > 0 Then
            objOitem_Object_Export_Mode_Deny_Item_with_Children__Type___Object_ = New clsOntologyItem
            objOitem_Object_Export_Mode_Deny_Item_with_Children__Type___Object_.GUID = objEMDIWCHTT(0).ID_Other
            objOitem_Object_Export_Mode_Deny_Item_with_Children__Type___Object_.Name = objEMDIWCHTT(0).Name_Other
            objOitem_Object_Export_Mode_Deny_Item_with_Children__Type___Object_.GUID_Parent = objEMDIWCHTT(0).ID_Parent_Other
            objOitem_Object_Export_Mode_Deny_Item_with_Children__Type___Object_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objEMN = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Export_Mode_Normal" And obj.Ontology = objGlobals.Type_Object

        If objEMN.Count > 0 Then
            objOitem_Object_Export_Mode_Normal = New clsOntologyItem
            objOitem_Object_Export_Mode_Normal.GUID = objEMN(0).ID_Other
            objOitem_Object_Export_Mode_Normal.Name = objEMN(0).Name_Other
            objOitem_Object_Export_Mode_Normal.GUID_Parent = objEMN(0).ID_Parent_Other
            objOitem_Object_Export_Mode_Normal.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objXMLCLSLCOX = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_XML_clsLocalConfig_ontology_xml" And obj.Ontology = objGlobals.Type_Object

        If objXMLCLSLCOX.Count > 0 Then
            objOItem_Token_XML_clsLocalConfig_ontology_xml = New clsOntologyItem
            objOItem_Token_XML_clsLocalConfig_ontology_xml.GUID = objXMLCLSLCOX(0).ID_Other
            objOItem_Token_XML_clsLocalConfig_ontology_xml.Name = objXMLCLSLCOX(0).Name_Other
            objOItem_Token_XML_clsLocalConfig_ontology_xml.GUID_Parent = objXMLCLSLCOX(0).ID_Parent_Other
            objOItem_Token_XML_clsLocalConfig_ontology_xml.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objToken_XML_Declaration_Ontology_Configitems = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_XML_Declaration_Ontology_Configitems" And obj.Ontology = objGlobals.Type_Object

        If objToken_XML_Declaration_Ontology_Configitems.Count > 0 Then
            objOItem_Token_XML_Declaration_Ontology_Configitems = New clsOntologyItem
            objOItem_Token_XML_Declaration_Ontology_Configitems.GUID = objToken_XML_Declaration_Ontology_Configitems(0).ID_Other
            objOItem_Token_XML_Declaration_Ontology_Configitems.Name = objToken_XML_Declaration_Ontology_Configitems(0).Name_Other
            objOItem_Token_XML_Declaration_Ontology_Configitems.GUID_Parent = objToken_XML_Declaration_Ontology_Configitems(0).ID_Parent_Other
            objOItem_Token_XML_Declaration_Ontology_Configitems.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objToken_XML_Initialize_RelationType__ConfigItem_Ontology_ = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_XML_Initialize_RelationType__ConfigItem_Ontology_" And obj.Ontology = objGlobals.Type_Object

        If objToken_XML_Declaration_Ontology_Configitems.Count > 0 Then
            objOItem_Token_XML_Initialize_RelationType__ConfigItem_Ontology_ = New clsOntologyItem
            objOItem_Token_XML_Initialize_RelationType__ConfigItem_Ontology_.GUID = objToken_XML_Initialize_RelationType__ConfigItem_Ontology_(0).ID_Other
            objOItem_Token_XML_Initialize_RelationType__ConfigItem_Ontology_.Name = objToken_XML_Initialize_RelationType__ConfigItem_Ontology_(0).Name_Other
            objOItem_Token_XML_Initialize_RelationType__ConfigItem_Ontology_.GUID_Parent = objToken_XML_Initialize_RelationType__ConfigItem_Ontology_(0).ID_Parent_Other
            objOItem_Token_XML_Initialize_RelationType__ConfigItem_Ontology_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objToken_XML_Initialize_Token__ConfigItem_Ontology_ = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_XML_Initialize_Token__ConfigItem_Ontology_" And obj.Ontology = objGlobals.Type_Object

        If objToken_XML_Initialize_Token__ConfigItem_Ontology_.Count > 0 Then
            objOItem_Token_XML_Initialize_Token__ConfigItem_Ontology_ = New clsOntologyItem
            objOItem_Token_XML_Initialize_Token__ConfigItem_Ontology_.GUID = objToken_XML_Initialize_Token__ConfigItem_Ontology_(0).ID_Other
            objOItem_Token_XML_Initialize_Token__ConfigItem_Ontology_.Name = objToken_XML_Initialize_Token__ConfigItem_Ontology_(0).Name_Other
            objOItem_Token_XML_Initialize_Token__ConfigItem_Ontology_.GUID_Parent = objToken_XML_Initialize_Token__ConfigItem_Ontology_(0).ID_Parent_Other
            objOItem_Token_XML_Initialize_Token__ConfigItem_Ontology_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objToken_XML_Initilize_Attribute__ConfigItem_Ontology_ = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_XML_Initilize_Attribute__ConfigItem_Ontology_" And obj.Ontology = objGlobals.Type_Object

        If objToken_XML_Initilize_Attribute__ConfigItem_Ontology_.Count > 0 Then
            objOItem_Token_XML_Initilize_Attribute__ConfigItem_Ontology_ = New clsOntologyItem
            objOItem_Token_XML_Initilize_Attribute__ConfigItem_Ontology_.GUID = objToken_XML_Initilize_Attribute__ConfigItem_Ontology_(0).ID_Other
            objOItem_Token_XML_Initilize_Attribute__ConfigItem_Ontology_.Name = objToken_XML_Initilize_Attribute__ConfigItem_Ontology_(0).Name_Other
            objOItem_Token_XML_Initilize_Attribute__ConfigItem_Ontology_.GUID_Parent = objToken_XML_Initilize_Attribute__ConfigItem_Ontology_(0).ID_Parent_Other
            objOItem_Token_XML_Initilize_Attribute__ConfigItem_Ontology_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objToken_XML_Initilize_Type__ConfigItem_Ontology_ = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_XML_Initilize_Type__ConfigItem_Ontology_" And obj.Ontology = objGlobals.Type_Object

        If objToken_XML_Initilize_Type__ConfigItem_Ontology_.Count > 0 Then
            objOItem_Token_XML_Initilize_Type__ConfigItem_Ontology_ = New clsOntologyItem
            objOItem_Token_XML_Initilize_Type__ConfigItem_Ontology_.GUID = objToken_XML_Initilize_Type__ConfigItem_Ontology_(0).ID_Other
            objOItem_Token_XML_Initilize_Type__ConfigItem_Ontology_.Name = objToken_XML_Initilize_Type__ConfigItem_Ontology_(0).Name_Other
            objOItem_Token_XML_Initilize_Type__ConfigItem_Ontology_.GUID_Parent = objToken_XML_Initilize_Type__ConfigItem_Ontology_(0).ID_Parent_Other
            objOItem_Token_XML_Initilize_Type__ConfigItem_Ontology_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objToken_XML_Property_Ontology_ConfigItem = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_XML_Property_Ontology_ConfigItem" And obj.Ontology = objGlobals.Type_Object

        If objToken_XML_Property_Ontology_ConfigItem.Count > 0 Then
            objOItem_Token_XML_Property_Ontology_ConfigItem = New clsOntologyItem
            objOItem_Token_XML_Property_Ontology_ConfigItem.GUID = objToken_XML_Property_Ontology_ConfigItem(0).ID_Other
            objOItem_Token_XML_Property_Ontology_ConfigItem.Name = objToken_XML_Property_Ontology_ConfigItem(0).Name_Other
            objOItem_Token_XML_Property_Ontology_ConfigItem.GUID_Parent = objToken_XML_Property_Ontology_ConfigItem(0).ID_Parent_Other
            objOItem_Token_XML_Property_Ontology_ConfigItem.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objToken_Variable_Name_ConfigItem = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_Name_ConfigItem" And obj.Ontology = objGlobals.Type_Object

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

        objDBLevel_Config1.get_Data_ObjectRel(oList_ObjectRel)

        If objDBLevel_Config1.OList_ObjectRel_ID.Count > 0 Then
            oList_ObjectRel.Clear()
            oList_ObjectRel.Add(New clsObjectRel(Nothing, _
                                                 Nothing, _
                                                 objOItem_Class_Development_Module.GUID, _
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
                objOItem_BaseConfig = New clsOntologyItem(objDBLevel_Config1.OList_ObjectRel(0).ID_Object, _
                                                       objDBLevel_Config1.OList_ObjectRel(0).Name_Object, _
                                                       objDBLevel_Config1.OList_ObjectRel(0).ID_Parent_Object)
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

    Public ReadOnly Property Globals As clsGlobals
        Get
            Return objGlobals
        End Get
    End Property

    Private Sub get_Config()
        get_Config_AttributeTypes()
        get_Config_RelationTypes()
        get_Config_Classes()
        get_Config_Objects()

        get_BaseConfig()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Config1 = New clsDBLevel(objGlobals)
        objDBLevel_Config2 = New clsDBLevel(objGlobals)
    End Sub

    Public Sub New(ByVal Globals As clsGlobals)
        objGlobals = Globals

        set_DBConnection()

        initialize()
    End Sub

    Private Sub initialize()
        get_Data_DevelopmentConfig()
        get_Config()
    End Sub

End Class
