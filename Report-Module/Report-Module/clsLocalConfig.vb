Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsLocalConfig
    Private cstr_ID_SoftwareDevelopment As String = "f40e5133f87642c7ab40c8c602f8884c"
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
    Private objOItem_Attribute_Standard As New clsOntologyItem
    Private objOItem_Attribute_ASC As New clsOntologyItem
    Private objOItem_Attribute_invisible As New clsOntologyItem
    Private objOItem_Attribute_Value As New clsOntologyItem
    Private objOItem_Attribute_is_Null As New clsOntologyItem
    Private objOItem_Attribute_XML_Text As New clsOntologyItem
    Private objOItem_Attribute_Row_Header As New clsOntologyItem
    Private objOItem_Attribute_visible As New clsOntologyItem


    'RelationTypes
    Private objOItem_RelationType_belongsTo As New clsOntologyItem
    Private objOItem_RelationType_contains As New clsOntologyItem
    Private objOItem_RelationType_is As New clsOntologyItem
    Private objOItem_RelationType_located_in As New clsOntologyItem
    Private objOItem_RelationType_is_of_Type As New clsOntologyItem
    Private objOItem_RelationType_leads As New clsOntologyItem
    Private objOItem_RelationType_Formatted_by As New clsOntologyItem
    Private objOItem_RelationType_Type_Field As New clsOntologyItem
    Private objOItem_RelationType_connected_by As New clsOntologyItem
    Private objOItem_RelationType_Table_Config As New clsOntologyItem
    Private objOItem_RelationType_Row_Config As New clsOntologyItem
    Private objOItem_RelationType_Cell_Config As New clsOntologyItem
    Private objOItem_RelationType_belonging_Resources As New clsOntologyItem
    Private objOItem_RelationType_belonging_Source As New clsOntologyItem
    Private objOItem_RelationType_belonging As New clsOntologyItem

    
    'Token
    Private objOItem_Object_Report_Type_View As New clsOntologyItem
    Private objOItem_Object_Report_Type_Token_Report As New clsOntologyItem
    Private objOItem_Object_Field_Type_Text As New clsOntologyItem
    Private objOItem_Object_Field_Type_GUID As New clsOntologyItem
    Private objOItem_Object_Field_Type_Zahl As New clsOntologyItem
    Private objOItem_Object_Variable_ROW_NAME As New clsOntologyItem
    Private objOItem_Object_Variable_ROW_LIST As New clsOntologyItem
    Private objOItem_Object_Variable_CELL_VALUE As New clsOntologyItem
    Private objOItem_Object_Variable_CELL_NAME As New clsOntologyItem
    Private objOItem_Object_Variable_CELL_LIST As New clsOntologyItem
    Private objOItem_Object_Variable_id As New clsOntologyItem
    Private objOItem_Object_Variable_REPORT_20 As New clsOntologyItem
    Private objOItem_Object_Variable_REPORT As New clsOntologyItem
    Private objOItem_Object_Variable_ROWCOUNT As New clsOntologyItem
    Private objOItem_Object_Variable_AUTHOR As New clsOntologyItem
    Private objOItem_Object_Variable_COLCOUNT As New clsOntologyItem
    Private objOItem_Object_Variable_DATETIME_TZ As New clsOntologyItem
    Private objOItem_Object_Field_Type_DateTime As New clsOntologyItem
    Private objOItem_Object_Report_Type_ElasticView As New clsOntologyItem
    Private objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join As New clsOntologyItem
    Private objOItem_Object_Ontology_Relation_Rule_Relation_Break As New clsOntologyItem
    Private objOItem_Object_Ontology_Relation_Rule_Parent_Types As New clsOntologyItem
    Private objOItem_Object_Ontology_Relation_Rule_Only_Item As New clsOntologyItem
    Private objOItem_Object_Ontology_Relation_Rule_Name_of_Type_Parse As New clsOntologyItem
    Private objOItem_Object_Ontology_Relation_Rule_Left_Outer_Join As New clsOntologyItem
    Private objOItem_Object_Ontology_Relation_Rule_Inner_Join As New clsOntologyItem
    Private objOItem_Object_Ontology_Relation_Rule_Child_Token As New clsOntologyItem

    'Types
    Private objOItem_Class_Database As New clsOntologyItem
    Private objOItem_Class_Database_on_Server As New clsOntologyItem
    Private objOItem_Class_DB_Procedure As New clsOntologyItem
    Private objOItem_Class_DB_Views As New clsOntologyItem
    Private objOItem_Class_Reports As New clsOntologyItem
    Private objOItem_Class_Server As New clsOntologyItem
    Private objOItem_Class_Report_Type As New clsOntologyItem
    Private objOItem_Class_Report_Field As New clsOntologyItem
    Private objOItem_Class_Field_Type As New clsOntologyItem
    Private objOItem_Class_DB_Columns As New clsOntologyItem
    Private objOItem_Class_File As New clsOntologyItem
    Private objOItem_Class_Field_Format As New clsOntologyItem
    Private objOItem_Class_Report_Sort As New clsOntologyItem
    Private objOItem_Class_Comparison_Operators As New clsOntologyItem
    Private objOItem_Class_Logical_Operators As New clsOntologyItem
    Private objOItem_Class_Report_Filter As New clsOntologyItem
    Private objOItem_Class_Password As New clsOntologyItem
    Private objOItem_Class_Url As New clsOntologyItem
    Private objOItem_Class_Path As New clsOntologyItem
    Private objOItem_Class_XML_Config As New clsOntologyItem
    Private objOItem_Class_Variable As New clsOntologyItem
    Private objOItem_Class_XML As New clsOntologyItem
    Private objOItem_Class_User As New clsOntologyItem
    Private objOItem_Class_DataTypes__Ms_SQL_ As New clsOntologyItem
    Private objOItem_Class_Indexes__Elastic_Search_ As New clsOntologyItem
    Private objOItem_Class_Server_Port As New clsOntologyItem
    Private objOItem_Class_Port As New clsOntologyItem
    Private objOItem_Class_Ontology_Join As New clsOntologyItem
    Private objOItem_Class_Ontology_Item As New clsOntologyItem

    Private objOItem_User As clsOntologyItem

    Private strFilter As String
    Private intFilter As Integer
    Private strSort As String

    Public Property Filter As String
        Get
            Return strFilter
        End Get
        Set(ByVal value As String)
            strFilter = value
        End Set
    End Property

    Public Property Filter_Type As Integer
        Get
            Return intFilter
        End Get
        Set(ByVal value As Integer)
            intFilter = value
        End Set
    End Property

    Public Property Sort As String
        Get
            Return strSort
        End Get
        Set(ByVal value As String)
            strSort = value
        End Set
    End Property

    Public Property User As clsOntologyItem
        Get
            Return objOItem_User
        End Get
        Set(value As clsOntologyItem)
            objOItem_User = value
        End Set
    End Property
    
    'Attributes
    Public ReadOnly Property OItem_Attribute_ASC() As clsOntologyItem
        Get
            Return objOItem_Attribute_ASC
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_invisible() As clsOntologyItem
        Get
            Return objOItem_Attribute_invisible
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Row_Header() As clsOntologyItem
        Get
            Return objOItem_Attribute_Row_Header
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Standard() As clsOntologyItem
        Get
            Return objOItem_Attribute_Standard
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Value() As clsOntologyItem
        Get
            Return objOItem_Attribute_Value
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_visible() As clsOntologyItem
        Get
            Return objOItem_Attribute_visible
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_XML_Text() As clsOntologyItem
        Get
            Return objOItem_Attribute_XML_Text
        End Get
    End Property


    'RelationTypes
    Public ReadOnly Property OItem_RelationType_belongsTo() As clsOntologyItem
        Get
            Return objOItem_RelationType_belongsTo
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_Cell_Config() As clsOntologyItem
        Get
            Return objOItem_RelationType_Cell_Config
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_connected_by() As clsOntologyItem
        Get
            Return objOItem_RelationType_connected_by
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_contains() As clsOntologyItem
        Get
            Return objOItem_RelationType_contains
        End Get
    End Property
    Public ReadOnly Property OItem_RelationType_Formatted_by() As clsOntologyItem
        Get
            Return objOItem_RelationType_Formatted_by
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_is() As clsOntologyItem
        Get
            Return objOItem_RelationType_is
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_is_of_Type() As clsOntologyItem
        Get
            Return objOItem_RelationType_is_of_Type
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_leads() As clsOntologyItem
        Get
            Return objOItem_RelationType_leads
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_located_in() As clsOntologyItem
        Get
            Return objOItem_RelationType_located_in
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_Row_Config() As clsOntologyItem
        Get
            Return objOItem_RelationType_Row_Config
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_Table_Config() As clsOntologyItem
        Get
            Return objOItem_RelationType_Table_Config
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_Type_Field() As clsOntologyItem
        Get
            Return objOItem_RelationType_Type_Field
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Source() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Source
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Resources() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Resources
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging
        End Get
    End Property


    'Token
    Public ReadOnly Property OItem_Object_Field_Type_DateTime() As clsOntologyItem
        Get
            Return objOItem_Object_Field_Type_DateTime
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Field_Type_Text() As clsOntologyItem
        Get
            Return objOItem_Object_Field_Type_Text
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Field_Type_GUID() As clsOntologyItem
        Get
            Return objOItem_Object_Field_Type_GUID
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Field_Type_Zahl() As clsOntologyItem
        Get
            Return objOItem_Object_Field_Type_Zahl
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Report_Type_Token_Report() As clsOntologyItem
        Get
            Return objOItem_Object_Report_Type_Token_Report
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Report_Type_View() As clsOntologyItem
        Get
            Return objOItem_Object_Report_Type_View
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Variable_AUTHOR() As clsOntologyItem
        Get
            Return objOItem_Object_Variable_AUTHOR
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Variable_CELL_LIST() As clsOntologyItem
        Get
            Return objOItem_Object_Variable_CELL_LIST
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Variable_CELL_NAME() As clsOntologyItem
        Get
            Return objOItem_Object_Variable_CELL_NAME
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Variable_CELL_VALUE() As clsOntologyItem
        Get
            Return objOItem_Object_Variable_CELL_VALUE
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Variable_COLCOUNT() As clsOntologyItem
        Get
            Return objOItem_Object_Variable_COLCOUNT
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Variable_DATETIME_TZ() As clsOntologyItem
        Get
            Return objOItem_Object_Variable_DATETIME_TZ
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Variable_id() As clsOntologyItem
        Get
            Return objOItem_Object_Variable_id
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Variable_REPORT() As clsOntologyItem
        Get
            Return objOItem_Object_Variable_REPORT
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Variable_REPORT_20() As clsOntologyItem
        Get
            Return objOItem_Object_Variable_REPORT_20
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Variable_ROW_LIST() As clsOntologyItem
        Get
            Return objOItem_Object_Variable_ROW_LIST
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Variable_ROW_NAME() As clsOntologyItem
        Get
            Return objOItem_Object_Variable_ROW_NAME
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Variable_ROWCOUNT() As clsOntologyItem
        Get
            Return objOItem_Object_Variable_ROWCOUNT
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Report_Type_ElasticView() As clsOntologyItem
        Get
            Return objOItem_Object_Report_Type_ElasticView
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Ontology_Relation_Rule_Right_Outer_Join() As clsOntologyItem
        Get
            Return objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join
        End Get
    End Property

    Public ReadOnly Property OItem_Token_Ontology_Relation_Rule_Relation_Break() As clsOntologyItem
        Get
            Return objOItem_Object_Ontology_Relation_Rule_Relation_Break
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Ontology_Relation_Rule_Parent_Types() As clsOntologyItem
        Get
            Return objOItem_Object_Ontology_Relation_Rule_Parent_Types
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Ontology_Relation_Rule_Only_Item() As clsOntologyItem
        Get
            Return objOItem_Object_Ontology_Relation_Rule_Only_Item
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Ontology_Relation_Rule_Name_of_Type_Parse() As clsOntologyItem
        Get
            Return objOItem_Object_Ontology_Relation_Rule_Name_of_Type_Parse
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Ontology_Relation_Rule_Left_Outer_Join() As clsOntologyItem
        Get
            Return objOItem_Object_Ontology_Relation_Rule_Left_Outer_Join
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Ontology_Relation_Rule_Inner_Join() As clsOntologyItem
        Get
            Return objOItem_Object_Ontology_Relation_Rule_Inner_Join
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Ontology_Relation_Rule_Child_Token() As clsOntologyItem
        Get
            Return objOItem_Object_Ontology_Relation_Rule_Child_Token
        End Get
    End Property


    'Types
    Public ReadOnly Property OItem_Class_Comparison_Operators() As clsOntologyItem
        Get
            Return objOItem_Class_Comparison_Operators
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Database() As clsOntologyItem
        Get
            Return objOItem_Class_Database
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Database_on_Server() As clsOntologyItem
        Get
            Return objOItem_Class_Database_on_Server
        End Get
    End Property

    Public ReadOnly Property OItem_Class_DataTypes__Ms_SQL_() As clsOntologyItem
        Get
            Return objOItem_Class_DataTypes__Ms_SQL_
        End Get
    End Property

    Public ReadOnly Property OItem_Class_DB_Columns() As clsOntologyItem
        Get
            Return objOItem_Class_DB_Columns
        End Get
    End Property

    Public ReadOnly Property OItem_Class_DB_Procedure() As clsOntologyItem
        Get
            Return objOItem_Class_DB_Procedure
        End Get
    End Property

    Public ReadOnly Property OItem_Class_DB_Views() As clsOntologyItem
        Get
            Return objOItem_Class_DB_Views
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Field_Format() As clsOntologyItem
        Get
            Return objOItem_Class_Field_Format
        End Get
    End Property
    Public ReadOnly Property OItem_Class_Field_Type() As clsOntologyItem
        Get
            Return objOItem_Class_Field_Type
        End Get
    End Property

    Public ReadOnly Property OItem_Class_File() As clsOntologyItem
        Get
            Return objOItem_Class_File
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Logical_Operators() As clsOntologyItem
        Get
            Return objOItem_Class_Logical_Operators
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Password() As clsOntologyItem
        Get
            Return objOItem_Class_Password
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Path() As clsOntologyItem
        Get
            Return objOItem_Class_Path
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Report_Field() As clsOntologyItem
        Get
            Return objOItem_Class_Report_Field
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Report_Filter() As clsOntologyItem
        Get
            Return objOItem_Class_Report_Filter
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Report_Sort() As clsOntologyItem
        Get
            Return objOItem_Class_Report_Sort
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Report_Type() As clsOntologyItem
        Get
            Return objOItem_Class_Report_Type
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Reports() As clsOntologyItem
        Get
            Return objOItem_Class_Reports
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Server() As clsOntologyItem
        Get
            Return objOItem_Class_Server
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Url() As clsOntologyItem
        Get
            Return objOItem_Class_Url
        End Get
    End Property

    Public ReadOnly Property OItem_Class_User() As clsOntologyItem
        Get
            Return objOItem_Class_User
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Variable() As clsOntologyItem
        Get
            Return objOItem_Class_Variable
        End Get
    End Property

    Public ReadOnly Property OItem_Class_XML() As clsOntologyItem
        Get
            Return objOItem_Class_XML
        End Get
    End Property

    Public ReadOnly Property OItem_Class_XML_Config() As clsOntologyItem
        Get
            Return objOItem_Class_XML_Config
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Port() As clsOntologyItem
        Get
            Return objOItem_Class_Port
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Server_Port() As clsOntologyItem
        Get
            Return objOItem_Class_Server_Port
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Indexes__Elastic_Search_() As clsOntologyItem
        Get
            Return objOItem_Class_Indexes__Elastic_Search_
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Ontology_Join() As clsOntologyItem
        Get
            Return objOItem_Class_Ontology_Join
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Ontology_Item() As clsOntologyItem
        Get
            Return objOItem_Class_Ontology_Item
        End Get
    End Property


    Public ReadOnly Property OItem_BaseConfig As clsOntologyItem
        Get
            Return objOItem_BaseConfig
        End Get
    End Property

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

    End Sub

    Private Sub get_Config_AttributeTypes()
        Dim objAVisible = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_visible" And obj.Ontology = objGlobals.Type_AttributeType

        If objAVisible.Count > 0 Then
            objOItem_Attribute_ASC = New clsOntologyItem
            objOItem_Attribute_ASC.GUID = objAVisible(0).ID_Other
            objOItem_Attribute_ASC.Name = objAVisible(0).Name_Other
            objOItem_Attribute_ASC.GUID_Parent = objAVisible(0).ID_Parent_Other
            objOItem_Attribute_ASC.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objARH = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_Row_Header" And obj.Ontology = objGlobals.Type_AttributeType

        If objARH.Count > 0 Then
            objOItem_Attribute_Row_Header = New clsOntologyItem
            objOItem_Attribute_Row_Header.GUID = objARH(0).ID_Other
            objOItem_Attribute_Row_Header.Name = objARH(0).Name_Other
            objOItem_Attribute_Row_Header.GUID_Parent = objARH(0).ID_Parent_Other
            objOItem_Attribute_Row_Header.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objXMLText = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_XML_Text" And obj.Ontology = objGlobals.Type_AttributeType

        If objXMLText.Count > 0 Then
            objOItem_Attribute_XML_Text = New clsOntologyItem
            objOItem_Attribute_XML_Text.GUID = objXMLText(0).ID_Other
            objOItem_Attribute_XML_Text.Name = objXMLText(0).Name_Other
            objOItem_Attribute_XML_Text.GUID_Parent = objXMLText(0).ID_Parent_Other
            objOItem_Attribute_XML_Text.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objValue = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_Value" And obj.Ontology = objGlobals.Type_AttributeType

        If objValue.Count > 0 Then
            objOItem_Attribute_Value = New clsOntologyItem
            objOItem_Attribute_Value.GUID = objValue(0).ID_Other
            objOItem_Attribute_Value.Name = objValue(0).Name_Other
            objOItem_Attribute_Value.GUID_Parent = objValue(0).ID_Parent_Other
            objOItem_Attribute_Value.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIsNull = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_is_Null" And obj.Ontology = objGlobals.Type_AttributeType

        If objIsNull.Count > 0 Then
            objOItem_Attribute_is_Null = New clsOntologyItem
            objOItem_Attribute_is_Null.GUID = objIsNull(0).ID_Other
            objOItem_Attribute_is_Null.Name = objIsNull(0).Name_Other
            objOItem_Attribute_is_Null.GUID_Parent = objIsNull(0).ID_Parent_Other
            objOItem_Attribute_is_Null.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objStandard = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_Standard" And obj.Ontology = objGlobals.Type_AttributeType

        If objStandard.Count > 0 Then
            objOItem_Attribute_Standard = New clsOntologyItem
            objOItem_Attribute_Standard.GUID = objStandard(0).ID_Other
            objOItem_Attribute_Standard.Name = objStandard(0).Name_Other
            objOItem_Attribute_Standard.GUID_Parent = objStandard(0).ID_Parent_Other
            objOItem_Attribute_Standard.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objASC = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_ASC" And obj.Ontology = objGlobals.Type_AttributeType

        If objASC.Count > 0 Then
            objOItem_Attribute_ASC = New clsOntologyItem
            objOItem_Attribute_ASC.GUID = objASC(0).ID_Other
            objOItem_Attribute_ASC.Name = objASC(0).Name_Other
            objOItem_Attribute_ASC.GUID_Parent = objASC(0).ID_Parent_Other
            objOItem_Attribute_ASC.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objInvisible = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object = "Attribute_invisible" And obj.Ontology = objGlobals.Type_AttributeType

        If objInvisible.Count > 0 Then
            objOItem_Attribute_invisible = New clsOntologyItem
            objOItem_Attribute_invisible.GUID = objInvisible(0).ID_Other
            objOItem_Attribute_invisible.Name = objInvisible(0).Name_Other
            objOItem_Attribute_invisible.GUID_Parent = objInvisible(0).ID_Parent_Other
            objOItem_Attribute_invisible.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If
    End Sub

    Private Sub get_Config_RelationTypes()


        Dim objTBLCfg = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_Table_Config" And obj.Ontology = objGlobals.Type_RelationType

        If objTBLCfg.Count > 0 Then
            objOItem_RelationType_Table_Config = New clsOntologyItem
            objOItem_RelationType_Table_Config.GUID = objTBLCfg(0).ID_Other
            objOItem_RelationType_Table_Config.Name = objTBLCfg(0).Name_Other
            objOItem_RelationType_Table_Config.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRowCfg = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_Row_Config" And obj.Ontology = objGlobals.Type_RelationType

        If objRowCfg.Count > 0 Then
            objOItem_RelationType_Row_Config = New clsOntologyItem
            objOItem_RelationType_Row_Config.GUID = objRowCfg(0).ID_Other
            objOItem_RelationType_Row_Config.Name = objRowCfg(0).Name_Other
            objOItem_RelationType_Row_Config.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objClCfg = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_Cell_Config" And obj.Ontology = objGlobals.Type_RelationType

        If objClCfg.Count > 0 Then
            objOItem_RelationType_Cell_Config = New clsOntologyItem
            objOItem_RelationType_Cell_Config.GUID = objClCfg(0).ID_Other
            objOItem_RelationType_Cell_Config.Name = objClCfg(0).Name_Other
            objOItem_RelationType_Cell_Config.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objConBy = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_connected_by" And obj.Ontology = objGlobals.Type_RelationType

        If objConBy.Count > 0 Then
            objOItem_RelationType_connected_by = New clsOntologyItem
            objOItem_RelationType_connected_by.GUID = objConBy(0).ID_Other
            objOItem_RelationType_connected_by.Name = objConBy(0).Name_Other
            objOItem_RelationType_connected_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objTypFld = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_Type_Field" And obj.Ontology = objGlobals.Type_RelationType

        If objTypFld.Count > 0 Then
            objOItem_RelationType_Type_Field = New clsOntologyItem
            objOItem_RelationType_Type_Field.GUID = objTypFld(0).ID_Other
            objOItem_RelationType_Type_Field.Name = objTypFld(0).Name_Other
            objOItem_RelationType_Type_Field.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFmtBy = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_Formatted_by" And obj.Ontology = objGlobals.Type_RelationType

        If objFmtBy.Count > 0 Then
            objOItem_RelationType_Formatted_by = New clsOntologyItem
            objOItem_RelationType_Formatted_by.GUID = objFmtBy(0).ID_Other
            objOItem_RelationType_Formatted_by.Name = objFmtBy(0).Name_Other
            objOItem_RelationType_Formatted_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_belongsTo" And obj.Ontology = objGlobals.Type_RelationType

        If objBT.Count > 0 Then
            objOItem_RelationType_belongsTo = New clsOntologyItem
            objOItem_RelationType_belongsTo.GUID = objBT(0).ID_Other
            objOItem_RelationType_belongsTo.Name = objBT(0).Name_Other
            objOItem_RelationType_belongsTo.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_contains" And obj.Ontology = objGlobals.Type_RelationType

        If objCT.Count > 0 Then
            objOItem_RelationType_contains = New clsOntologyItem
            objOItem_RelationType_contains.GUID = objCT(0).ID_Other
            objOItem_RelationType_contains.Name = objCT(0).Name_Other
            objOItem_RelationType_contains.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIS = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_is" And obj.Ontology = objGlobals.Type_RelationType

        If objIS.Count > 0 Then
            objOItem_RelationType_is = New clsOntologyItem
            objOItem_RelationType_is.GUID = objIS(0).ID_Other
            objOItem_RelationType_is.Name = objIS(0).Name_Other
            objOItem_RelationType_is.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLI = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_located_in" And obj.Ontology = objGlobals.Type_RelationType

        If objLI.Count > 0 Then
            objOItem_RelationType_located_in = New clsOntologyItem
            objOItem_RelationType_located_in.GUID = objLI(0).ID_Other
            objOItem_RelationType_located_in.Name = objLI(0).Name_Other
            objOItem_RelationType_located_in.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIoT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_is_of_Type" And obj.Ontology = objGlobals.Type_RelationType

        If objIoT.Count > 0 Then
            objOItem_RelationType_is_of_Type = New clsOntologyItem
            objOItem_RelationType_is_of_Type.GUID = objIoT(0).ID_Other
            objOItem_RelationType_is_of_Type.Name = objIoT(0).Name_Other
            objOItem_RelationType_is_of_Type.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLDS = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_leads" And obj.Ontology = objGlobals.Type_RelationType

        If objLDS.Count > 0 Then
            objOItem_RelationType_leads = New clsOntologyItem
            objOItem_RelationType_leads.GUID = objLDS(0).ID_Other
            objOItem_RelationType_leads.Name = objLDS(0).Name_Other
            objOItem_RelationType_leads.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBS = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_belonging_Source" And obj.Ontology = objGlobals.Type_RelationType

        If objBS.Count > 0 Then
            objOItem_RelationType_belonging_Source = New clsOntologyItem
            objOItem_RelationType_belonging_Source.GUID = objBS(0).ID_Other
            objOItem_RelationType_belonging_Source.Name = objBS(0).Name_Other
            objOItem_RelationType_belonging_Source.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBRS = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_belonging_Resources" And obj.Ontology = objGlobals.Type_RelationType

        If objBRS.Count > 0 Then
            objOItem_RelationType_belonging_Resources = New clsOntologyItem
            objOItem_RelationType_belonging_Resources.GUID = objBRS(0).ID_Other
            objOItem_RelationType_belonging_Resources.Name = objBRS(0).Name_Other
            objOItem_RelationType_belonging_Resources.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBel = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "RelationType_belonging" And obj.Ontology = objGlobals.Type_RelationType

        If objBel.Count > 0 Then
            objOItem_RelationType_belonging = New clsOntologyItem
            objOItem_RelationType_belonging.GUID = objBel(0).ID_Other
            objOItem_RelationType_belonging.Name = objBel(0).Name_Other
            objOItem_RelationType_belonging.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If
    End Sub

    Private Sub get_Config_Classes()



        Dim objDTMS = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_DataTypes__Ms_SQL_" And obj.Ontology = objGlobals.Type_Class

        If objDTMS.Count > 0 Then
            objOItem_Class_DataTypes__Ms_SQL_ = New clsOntologyItem
            objOItem_Class_DataTypes__Ms_SQL_.GUID = objDTMS(0).ID_Other
            objOItem_Class_DataTypes__Ms_SQL_.Name = objDTMS(0).Name_Other
            objOItem_Class_DataTypes__Ms_SQL_.GUID_Parent = objDTMS(0).ID_Parent_Other
            objOItem_Class_DataTypes__Ms_SQL_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objU = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "type_User" And obj.Ontology = objGlobals.Type_Class

        If objU.Count > 0 Then
            objOItem_Class_User = New clsOntologyItem
            objOItem_Class_User.GUID = objU(0).ID_Other
            objOItem_Class_User.Name = objU(0).Name_Other
            objOItem_Class_User.GUID_Parent = objU(0).ID_Parent_Other
            objOItem_Class_User.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objVar = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Variable" And obj.Ontology = objGlobals.Type_Class

        If objVar.Count > 0 Then
            objOItem_Class_Variable = New clsOntologyItem
            objOItem_Class_Variable.GUID = objVar(0).ID_Other
            objOItem_Class_Variable.Name = objVar(0).Name_Other
            objOItem_Class_Variable.GUID_Parent = objVar(0).ID_Parent_Other
            objOItem_Class_Variable.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objXML = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_XML" And obj.Ontology = objGlobals.Type_Class

        If objXML.Count > 0 Then
            objOItem_Class_XML = New clsOntologyItem
            objOItem_Class_XML.GUID = objXML(0).ID_Other
            objOItem_Class_XML.Name = objXML(0).Name_Other
            objOItem_Class_XML.GUID_Parent = objXML(0).ID_Parent_Other
            objOItem_Class_XML.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objXMLC = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_XML_Config" And obj.Ontology = objGlobals.Type_Class

        If objXMLC.Count > 0 Then
            objOItem_Class_XML_Config = New clsOntologyItem
            objOItem_Class_XML_Config.GUID = objXMLC(0).ID_Other
            objOItem_Class_XML_Config.Name = objXMLC(0).Name_Other
            objOItem_Class_XML_Config.GUID_Parent = objXMLC(0).ID_Parent_Other
            objOItem_Class_XML_Config.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPath = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Path" And obj.Ontology = objGlobals.Type_Class

        If objPath.Count > 0 Then
            objOItem_Class_Path = New clsOntologyItem
            objOItem_Class_Path.GUID = objPath(0).ID_Other
            objOItem_Class_Path.Name = objPath(0).Name_Other
            objOItem_Class_Path.GUID_Parent = objPath(0).ID_Parent_Other
            objOItem_Class_Path.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objUrl = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Url" And obj.Ontology = objGlobals.Type_Class

        If objUrl.Count > 0 Then
            objOItem_Class_Url = New clsOntologyItem
            objOItem_Class_Url.GUID = objUrl(0).ID_Other
            objOItem_Class_Url.Name = objUrl(0).Name_Other
            objOItem_Class_Url.GUID_Parent = objUrl(0).ID_Parent_Other
            objOItem_Class_Url.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPWD = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Password" And obj.Ontology = objGlobals.Type_Class

        If objPWD.Count > 0 Then
            objOItem_Class_Password = New clsOntologyItem
            objOItem_Class_Password.GUID = objPWD(0).ID_Other
            objOItem_Class_Password.Name = objPWD(0).Name_Other
            objOItem_Class_Password.GUID_Parent = objPWD(0).ID_Parent_Other
            objOItem_Class_Password.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRF = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Report_Filter" And obj.Ontology = objGlobals.Type_Class

        If objRF.Count > 0 Then
            objOItem_Class_Report_Filter = New clsOntologyItem
            objOItem_Class_Report_Filter.GUID = objRF(0).ID_Other
            objOItem_Class_Report_Filter.Name = objRF(0).Name_Other
            objOItem_Class_Report_Filter.GUID_Parent = objRF(0).ID_Parent_Other
            objOItem_Class_Report_Filter.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCO = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Comparison_Operators" And obj.Ontology = objGlobals.Type_Class

        If objCO.Count > 0 Then
            objOItem_Class_Comparison_Operators = New clsOntologyItem
            objOItem_Class_Comparison_Operators.GUID = objCO(0).ID_Other
            objOItem_Class_Comparison_Operators.Name = objCO(0).Name_Other
            objOItem_Class_Comparison_Operators.GUID_Parent = objCO(0).ID_Parent_Other
            objOItem_Class_Comparison_Operators.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLO = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Logical_Operators" And obj.Ontology = objGlobals.Type_Class

        If objLO.Count > 0 Then
            objOItem_Class_Logical_Operators = New clsOntologyItem
            objOItem_Class_Logical_Operators.GUID = objLO(0).ID_Other
            objOItem_Class_Logical_Operators.Name = objLO(0).Name_Other
            objOItem_Class_Logical_Operators.GUID_Parent = objLO(0).ID_Parent_Other
            objOItem_Class_Logical_Operators.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRepSort = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Report_Sort" And obj.Ontology = objGlobals.Type_Class

        If objRepSort.Count > 0 Then
            objOItem_Class_Report_Sort = New clsOntologyItem
            objOItem_Class_Report_Sort.GUID = objRepSort(0).ID_Other
            objOItem_Class_Report_Sort.Name = objRepSort(0).Name_Other
            objOItem_Class_Report_Sort.GUID_Parent = objRepSort(0).ID_Parent_Other
            objOItem_Class_Report_Sort.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFF = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Field_Format" And obj.Ontology = objGlobals.Type_Class

        If objFF.Count > 0 Then
            objOItem_Class_Field_Format = New clsOntologyItem
            objOItem_Class_Field_Format.GUID = objFF(0).ID_Other
            objOItem_Class_Field_Format.Name = objFF(0).Name_Other
            objOItem_Class_Field_Format.GUID_Parent = objFF(0).ID_Parent_Other
            objOItem_Class_Field_Format.Type = objGlobals.Type_Class
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

        Dim objDBoS = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Database_on_Server" And obj.Ontology = objGlobals.Type_Class

        If objDBoS.Count > 0 Then
            objOItem_Class_Database_on_Server = New clsOntologyItem
            objOItem_Class_Database_on_Server.GUID = objDBoS(0).ID_Other
            objOItem_Class_Database_on_Server.Name = objDBoS(0).Name_Other
            objOItem_Class_Database_on_Server.GUID_Parent = objDBoS(0).ID_Parent_Other
            objOItem_Class_Database_on_Server.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If


        Dim objServ = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Server" And obj.Ontology = objGlobals.Type_Class

        If objServ.Count > 0 Then
            objOItem_Class_Server = New clsOntologyItem
            objOItem_Class_Server.GUID = objServ(0).ID_Other
            objOItem_Class_Server.Name = objServ(0).Name_Other
            objOItem_Class_Server.GUID_Parent = objServ(0).ID_Parent_Other
            objOItem_Class_Server.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBP = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_DB_Procedure" And obj.Ontology = objGlobals.Type_Class

        If objDBP.Count > 0 Then
            objOItem_Class_DB_Procedure = New clsOntologyItem
            objOItem_Class_DB_Procedure.GUID = objDBP(0).ID_Other
            objOItem_Class_DB_Procedure.Name = objDBP(0).Name_Other
            objOItem_Class_DB_Procedure.GUID_Parent = objDBP(0).ID_Parent_Other
            objOItem_Class_DB_Procedure.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBV = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_DB_Views" And obj.Ontology = objGlobals.Type_Class

        If objDBV.Count > 0 Then
            objOItem_Class_DB_Views = New clsOntologyItem
            objOItem_Class_DB_Views.GUID = objDBV(0).ID_Other
            objOItem_Class_DB_Views.Name = objDBV(0).Name_Other
            objOItem_Class_DB_Views.GUID_Parent = objDBV(0).ID_Parent_Other
            objOItem_Class_DB_Views.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRep = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Reports" And obj.Ontology = objGlobals.Type_Class

        If objRep.Count > 0 Then
            objOItem_Class_Reports = New clsOntologyItem
            objOItem_Class_Reports.GUID = objRep(0).ID_Other
            objOItem_Class_Reports.Name = objRep(0).Name_Other
            objOItem_Class_Reports.GUID_Parent = objRep(0).ID_Parent_Other
            objOItem_Class_Reports.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRepT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Report_Type" And obj.Ontology = objGlobals.Type_Class

        If objRepT.Count > 0 Then
            objOItem_Class_Report_Type = New clsOntologyItem
            objOItem_Class_Report_Type.GUID = objRepT(0).ID_Other
            objOItem_Class_Report_Type.Name = objRepT(0).Name_Other
            objOItem_Class_Report_Type.GUID_Parent = objRepT(0).ID_Parent_Other
            objOItem_Class_Report_Type.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRepF = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Report_Field" And obj.Ontology = objGlobals.Type_Class

        If objRepF.Count > 0 Then
            objOItem_Class_Report_Field = New clsOntologyItem
            objOItem_Class_Report_Field.GUID = objRepF(0).ID_Other
            objOItem_Class_Report_Field.Name = objRepF(0).Name_Other
            objOItem_Class_Report_Field.GUID_Parent = objRepF(0).ID_Parent_Other
            objOItem_Class_Report_Field.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFieldT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Field_Type" And obj.Ontology = objGlobals.Type_Class

        If objFieldT.Count > 0 Then
            objOItem_Class_Field_Type = New clsOntologyItem
            objOItem_Class_Field_Type.GUID = objFieldT(0).ID_Other
            objOItem_Class_Field_Type.Name = objFieldT(0).Name_Other
            objOItem_Class_Field_Type.GUID_Parent = objFieldT(0).ID_Parent_Other
            objOItem_Class_Field_Type.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBC = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_DB_Columns" And obj.Ontology = objGlobals.Type_Class

        If objDBC.Count > 0 Then
            objOItem_Class_DB_Columns = New clsOntologyItem
            objOItem_Class_DB_Columns.GUID = objDBC(0).ID_Other
            objOItem_Class_DB_Columns.Name = objDBC(0).Name_Other
            objOItem_Class_DB_Columns.GUID_Parent = objDBC(0).ID_Parent_Other
            objOItem_Class_DB_Columns.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFile = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_File" And obj.Ontology = objGlobals.Type_Class

        If objFile.Count > 0 Then
            objOItem_Class_File = New clsOntologyItem
            objOItem_Class_File.GUID = objFile(0).ID_Other
            objOItem_Class_File.Name = objFile(0).Name_Other
            objOItem_Class_File.GUID_Parent = objFile(0).ID_Parent_Other
            objOItem_Class_File.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIES = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Indexes__Elastic_Search_" And obj.Ontology = objGlobals.Type_Class

        If objIES.Count > 0 Then
            objOItem_Class_Indexes__Elastic_Search_ = New clsOntologyItem
            objOItem_Class_Indexes__Elastic_Search_.GUID = objIES(0).ID_Other
            objOItem_Class_Indexes__Elastic_Search_.Name = objIES(0).Name_Other
            objOItem_Class_Indexes__Elastic_Search_.GUID_Parent = objIES(0).ID_Parent_Other
            objOItem_Class_Indexes__Elastic_Search_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSERVP = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Server_Port" And obj.Ontology = objGlobals.Type_Class

        If objSERVP.Count > 0 Then
            objOItem_Class_Server_Port = New clsOntologyItem
            objOItem_Class_Server_Port.GUID = objSERVP(0).ID_Other
            objOItem_Class_Server_Port.Name = objSERVP(0).Name_Other
            objOItem_Class_Server_Port.GUID_Parent = objSERVP(0).ID_Parent_Other
            objOItem_Class_Server_Port.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPORT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Port" And obj.Ontology = objGlobals.Type_Class

        If objPORT.Count > 0 Then
            objOItem_Class_Port = New clsOntologyItem
            objOItem_Class_Port.GUID = objPORT(0).ID_Other
            objOItem_Class_Port.Name = objPORT(0).Name_Other
            objOItem_Class_Port.GUID_Parent = objPORT(0).ID_Parent_Other
            objOItem_Class_Port.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOJ = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Ontology_Join" And obj.Ontology = objGlobals.Type_Class

        If objOJ.Count > 0 Then
            objOItem_Class_Ontology_Join = New clsOntologyItem
            objOItem_Class_Ontology_Join.GUID = objOJ(0).ID_Other
            objOItem_Class_Ontology_Join.Name = objOJ(0).Name_Other
            objOItem_Class_Ontology_Join.GUID_Parent = objOJ(0).ID_Parent_Other
            objOItem_Class_Ontology_Join.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOI = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Type_Ontology_Item" And obj.Ontology = objGlobals.Type_Class

        If objOI.Count > 0 Then
            objOItem_Class_Ontology_Item = New clsOntologyItem
            objOItem_Class_Ontology_Item.GUID = objOI(0).ID_Other
            objOItem_Class_Ontology_Item.Name = objOI(0).Name_Other
            objOItem_Class_Ontology_Item.GUID_Parent = objOI(0).ID_Parent_Other
            objOItem_Class_Ontology_Item.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If
    End Sub

    Private Sub get_Config_Objects()


        Dim objDT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Field_Type_DateTime" And obj.Ontology = objGlobals.Type_Object

        If objDT.Count > 0 Then
            objOItem_Object_Field_Type_DateTime = New clsOntologyItem
            objOItem_Object_Field_Type_DateTime.GUID = objDT(0).ID_Other
            objOItem_Object_Field_Type_DateTime.Name = objDT(0).Name_Other
            objOItem_Object_Field_Type_DateTime.GUID_Parent = objDT(0).ID_Parent_Other
            objOItem_Object_Field_Type_DateTime.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRep = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_REPORT" And obj.Ontology = objGlobals.Type_Object

        If objRep.Count > 0 Then
            objOItem_Object_Variable_REPORT = New clsOntologyItem
            objOItem_Object_Variable_REPORT.GUID = objRep(0).ID_Other
            objOItem_Object_Variable_REPORT.Name = objRep(0).Name_Other
            objOItem_Object_Variable_REPORT.GUID_Parent = objRep(0).ID_Parent_Other
            objOItem_Object_Variable_REPORT.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRep20 = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_REPORT_20" And obj.Ontology = objGlobals.Type_Object

        If objRep20.Count > 0 Then
            objOItem_Object_Variable_REPORT_20 = New clsOntologyItem
            objOItem_Object_Variable_REPORT_20.GUID = objRep20(0).ID_Other
            objOItem_Object_Variable_REPORT_20.Name = objRep20(0).Name_Other
            objOItem_Object_Variable_REPORT_20.GUID_Parent = objRep20(0).ID_Parent_Other
            objOItem_Object_Variable_REPORT_20.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRowC = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_ROWCOUNT" And obj.Ontology = objGlobals.Type_Object

        If objRowC.Count > 0 Then
            objOItem_Object_Variable_ROWCOUNT = New clsOntologyItem
            objOItem_Object_Variable_ROWCOUNT.GUID = objRowC(0).ID_Other
            objOItem_Object_Variable_ROWCOUNT.Name = objRowC(0).Name_Other
            objOItem_Object_Variable_ROWCOUNT.GUID_Parent = objRowC(0).ID_Parent_Other
            objOItem_Object_Variable_ROWCOUNT.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objAuth = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_AUTHOR" And obj.Ontology = objGlobals.Type_Object

        If objAuth.Count > 0 Then
            objOItem_Object_Variable_AUTHOR = New clsOntologyItem
            objOItem_Object_Variable_AUTHOR.GUID = objAuth(0).ID_Other
            objOItem_Object_Variable_AUTHOR.Name = objAuth(0).Name_Other
            objOItem_Object_Variable_AUTHOR.GUID_Parent = objAuth(0).ID_Parent_Other
            objOItem_Object_Variable_AUTHOR.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objColC = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_COLCOUNT" And obj.Ontology = objGlobals.Type_Object

        If objColC.Count > 0 Then
            objOItem_Object_Variable_COLCOUNT = New clsOntologyItem
            objOItem_Object_Variable_COLCOUNT.GUID = objColC(0).ID_Other
            objOItem_Object_Variable_COLCOUNT.Name = objColC(0).Name_Other
            objOItem_Object_Variable_COLCOUNT.GUID_Parent = objColC(0).ID_Parent_Other
            objOItem_Object_Variable_COLCOUNT.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDTTZ = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_DATETIME_TZ" And obj.Ontology = objGlobals.Type_Object

        If objDTTZ.Count > 0 Then
            objOItem_Object_Variable_DATETIME_TZ = New clsOntologyItem
            objOItem_Object_Variable_DATETIME_TZ.GUID = objDTTZ(0).ID_Other
            objOItem_Object_Variable_DATETIME_TZ.Name = objDTTZ(0).Name_Other
            objOItem_Object_Variable_DATETIME_TZ.GUID_Parent = objDTTZ(0).ID_Parent_Other
            objOItem_Object_Variable_DATETIME_TZ.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objID = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_id" And obj.Ontology = objGlobals.Type_Object

        If objID.Count > 0 Then
            objOItem_Object_Variable_id = New clsOntologyItem
            objOItem_Object_Variable_id.GUID = objID(0).ID_Other
            objOItem_Object_Variable_id.Name = objID(0).Name_Other
            objOItem_Object_Variable_id.GUID_Parent = objID(0).ID_Parent_Other
            objOItem_Object_Variable_id.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objROWN = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_ROW_NAME" And obj.Ontology = objGlobals.Type_Object

        If objROWN.Count > 0 Then
            objOItem_Object_Variable_ROW_NAME = New clsOntologyItem
            objOItem_Object_Variable_ROW_NAME.GUID = objROWN(0).ID_Other
            objOItem_Object_Variable_ROW_NAME.Name = objROWN(0).Name_Other
            objOItem_Object_Variable_ROW_NAME.GUID_Parent = objROWN(0).ID_Parent_Other
            objOItem_Object_Variable_ROW_NAME.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objROWL = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_ROW_LIST" And obj.Ontology = objGlobals.Type_Object

        If objROWL.Count > 0 Then
            objOItem_Object_Variable_ROW_LIST = New clsOntologyItem
            objOItem_Object_Variable_ROW_LIST.GUID = objROWL(0).ID_Other
            objOItem_Object_Variable_ROW_LIST.Name = objROWL(0).Name_Other
            objOItem_Object_Variable_ROW_LIST.GUID_Parent = objROWL(0).ID_Parent_Other
            objOItem_Object_Variable_ROW_LIST.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCELLV = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_CELL_VALUE" And obj.Ontology = objGlobals.Type_Object

        If objCELLV.Count > 0 Then
            objOItem_Object_Variable_CELL_VALUE = New clsOntologyItem
            objOItem_Object_Variable_CELL_VALUE.GUID = objCELLV(0).ID_Other
            objOItem_Object_Variable_CELL_VALUE.Name = objCELLV(0).Name_Other
            objOItem_Object_Variable_CELL_VALUE.GUID_Parent = objCELLV(0).ID_Parent_Other
            objOItem_Object_Variable_CELL_VALUE.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCELLN = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_CELL_NAME" And obj.Ontology = objGlobals.Type_Object

        If objCELLN.Count > 0 Then
            objOItem_Object_Variable_CELL_NAME = New clsOntologyItem
            objOItem_Object_Variable_CELL_NAME.GUID = objCELLN(0).ID_Other
            objOItem_Object_Variable_CELL_NAME.Name = objCELLN(0).Name_Other
            objOItem_Object_Variable_CELL_NAME.GUID_Parent = objCELLN(0).ID_Parent_Other
            objOItem_Object_Variable_CELL_NAME.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCELLL = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Variable_CELL_LIST" And obj.Ontology = objGlobals.Type_Object

        If objCELLL.Count > 0 Then
            objOItem_Object_Variable_CELL_LIST = New clsOntologyItem
            objOItem_Object_Variable_CELL_LIST.GUID = objCELLL(0).ID_Other
            objOItem_Object_Variable_CELL_LIST.Name = objCELLL(0).Name_Other
            objOItem_Object_Variable_CELL_LIST.GUID_Parent = objCELLL(0).ID_Parent_Other
            objOItem_Object_Variable_CELL_LIST.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRTV = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Report_Type_View" And obj.Ontology = objGlobals.Type_Object

        If objRTV.Count > 0 Then
            objOItem_Object_Report_Type_View = New clsOntologyItem
            objOItem_Object_Report_Type_View.GUID = objRTV(0).ID_Other
            objOItem_Object_Report_Type_View.Name = objRTV(0).Name_Other
            objOItem_Object_Report_Type_View.GUID_Parent = objRTV(0).ID_Parent_Other
            objOItem_Object_Report_Type_View.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRTTR = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Report_Type_Token_Report" And obj.Ontology = objGlobals.Type_Object

        If objRTTR.Count > 0 Then
            objOItem_Object_Report_Type_Token_Report = New clsOntologyItem
            objOItem_Object_Report_Type_Token_Report.GUID = objRTTR(0).ID_Other
            objOItem_Object_Report_Type_Token_Report.Name = objRTTR(0).Name_Other
            objOItem_Object_Report_Type_Token_Report.GUID_Parent = objRTTR(0).ID_Parent_Other
            objOItem_Object_Report_Type_Token_Report.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFTT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Field_Type_Text" And obj.Ontology = objGlobals.Type_Object

        If objFTT.Count > 0 Then
            objOItem_Object_Field_Type_Text = New clsOntologyItem
            objOItem_Object_Field_Type_Text.GUID = objFTT(0).ID_Other
            objOItem_Object_Field_Type_Text.Name = objFTT(0).Name_Other
            objOItem_Object_Field_Type_Text.GUID_Parent = objFTT(0).ID_Parent_Other
            objOItem_Object_Field_Type_Text.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFTG = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Field_Type_GUID" And obj.Ontology = objGlobals.Type_Object

        If objFTG.Count > 0 Then
            objOItem_Object_Field_Type_GUID = New clsOntologyItem
            objOItem_Object_Field_Type_GUID.GUID = objFTG(0).ID_Other
            objOItem_Object_Field_Type_GUID.Name = objFTG(0).Name_Other
            objOItem_Object_Field_Type_GUID.GUID_Parent = objFTG(0).ID_Parent_Other
            objOItem_Object_Field_Type_GUID.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFTZ = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Field_Type_Zahl" And obj.Ontology = objGlobals.Type_Object

        If objFTZ.Count > 0 Then
            objOItem_Object_Field_Type_Zahl = New clsOntologyItem
            objOItem_Object_Field_Type_Zahl.GUID = objFTZ(0).ID_Other
            objOItem_Object_Field_Type_Zahl.Name = objFTZ(0).Name_Other
            objOItem_Object_Field_Type_Zahl.GUID_Parent = objFTZ(0).ID_Parent_Other
            objOItem_Object_Field_Type_Zahl.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If



        Dim objESV = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Report_Type_ElasticView" And obj.Ontology = objGlobals.Type_Object

        If objESV.Count > 0 Then
            objOItem_Object_Report_Type_ElasticView = New clsOntologyItem
            objOItem_Object_Report_Type_ElasticView.GUID = objESV(0).ID_Other
            objOItem_Object_Report_Type_ElasticView.Name = objESV(0).Name_Other
            objOItem_Object_Report_Type_ElasticView.GUID_Parent = objESV(0).ID_Parent_Other
            objOItem_Object_Report_Type_ElasticView.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objROJ = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Ontology_Relation_Rule_Right_Outer_Join" And obj.Ontology = objGlobals.Type_Object

        If objROJ.Count > 0 Then
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.GUID = objROJ(0).ID_Other
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.Name = objROJ(0).Name_Other
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.GUID_Parent = objROJ(0).ID_Parent_Other
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRELB = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Ontology_Relation_Rule_Relation_Break" And obj.Ontology = objGlobals.Type_Object

        If objRELB.Count > 0 Then
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.GUID = objRELB(0).ID_Other
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.Name = objRELB(0).Name_Other
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.GUID_Parent = objRELB(0).ID_Parent_Other
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRPT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Ontology_Relation_Rule_Parent_Types" And obj.Ontology = objGlobals.Type_Object

        If objRPT.Count > 0 Then
            objOItem_Object_Ontology_Relation_Rule_Parent_Types = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Parent_Types.GUID = objRPT(0).ID_Other
            objOItem_Object_Ontology_Relation_Rule_Parent_Types.Name = objRPT(0).Name_Other
            objOItem_Object_Ontology_Relation_Rule_Parent_Types.GUID_Parent = objRPT(0).ID_Parent_Other
            objOItem_Object_Ontology_Relation_Rule_Parent_Types.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objROI = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Ontology_Relation_Rule_Only_Item" And obj.Ontology = objGlobals.Type_Object

        If objROI.Count > 0 Then
            objOItem_Object_Ontology_Relation_Rule_Only_Item = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Only_Item.GUID = objROI(0).ID_Other
            objOItem_Object_Ontology_Relation_Rule_Only_Item.Name = objROI(0).Name_Other
            objOItem_Object_Ontology_Relation_Rule_Only_Item.GUID_Parent = objROI(0).ID_Parent_Other
            objOItem_Object_Ontology_Relation_Rule_Only_Item.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


        Dim objNoTP = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Ontology_Relation_Rule_Name_of_Type_Parse" And obj.Ontology = objGlobals.Type_Object

        If objNoTP.Count > 0 Then
            objOItem_Object_Ontology_Relation_Rule_Name_of_Type_Parse = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Name_of_Type_Parse.GUID = objNoTP(0).ID_Other
            objOItem_Object_Ontology_Relation_Rule_Name_of_Type_Parse.Name = objNoTP(0).Name_Other
            objOItem_Object_Ontology_Relation_Rule_Name_of_Type_Parse.GUID_Parent = objNoTP(0).ID_Parent_Other
            objOItem_Object_Ontology_Relation_Rule_Name_of_Type_Parse.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


        Dim objLOJ = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Ontology_Relation_Rule_Left_Outer_Join" And obj.Ontology = objGlobals.Type_Object

        If objLOJ.Count > 0 Then
            objOItem_Object_Ontology_Relation_Rule_Left_Outer_Join = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Left_Outer_Join.GUID = objLOJ(0).ID_Other
            objOItem_Object_Ontology_Relation_Rule_Left_Outer_Join.Name = objLOJ(0).Name_Other
            objOItem_Object_Ontology_Relation_Rule_Left_Outer_Join.GUID_Parent = objLOJ(0).ID_Parent_Other
            objOItem_Object_Ontology_Relation_Rule_Left_Outer_Join.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIJ = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Ontology_Relation_Rule_Inner_Join" And obj.Ontology = objGlobals.Type_Object

        If objIJ.Count > 0 Then
            objOItem_Object_Ontology_Relation_Rule_Inner_Join = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Inner_Join.GUID = objIJ(0).ID_Other
            objOItem_Object_Ontology_Relation_Rule_Inner_Join.Name = objIJ(0).Name_Other
            objOItem_Object_Ontology_Relation_Rule_Inner_Join.GUID_Parent = objIJ(0).ID_Parent_Other
            objOItem_Object_Ontology_Relation_Rule_Inner_Join.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


        Dim objCT = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object = "Token_Ontology_Relation_Rule_Child_Token" And obj.Ontology = objGlobals.Type_Object

        If objCT.Count > 0 Then
            objOItem_Object_Ontology_Relation_Rule_Child_Token = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Child_Token.GUID = objCT(0).ID_Other
            objOItem_Object_Ontology_Relation_Rule_Child_Token.Name = objCT(0).Name_Other
            objOItem_Object_Ontology_Relation_Rule_Child_Token.GUID_Parent = objCT(0).ID_Parent_Other
            objOItem_Object_Ontology_Relation_Rule_Child_Token.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
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
