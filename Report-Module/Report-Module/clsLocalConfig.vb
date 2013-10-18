﻿Imports Ontology_Module
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
    Private objOItem_Ontology As clsOntologyItem
    Private objOList_Ontologyitems As List(Of clsOntologyItemsOfOntologies)
    Private objDataWork_Ontologies As clsDataWork_Ontologies

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
        Dim objAVisible = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Attribute_visible".ToLower()).ToList()

        If objAVisible.Any() Then
            objOItem_Attribute_ASC = New clsOntologyItem
            objOItem_Attribute_ASC.GUID = objAVisible.First().ID_Ref
            objOItem_Attribute_ASC.Name = objAVisible.First().Name_Ref
            objOItem_Attribute_ASC.GUID_Parent = objAVisible.First().ID_Parent_Ref
            objOItem_Attribute_ASC.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objARH = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Attribute_Row_Header".ToLower()).ToList()

        If objARH.Any() Then
            objOItem_Attribute_Row_Header = New clsOntologyItem
            objOItem_Attribute_Row_Header.GUID = objARH.First().ID_Ref
            objOItem_Attribute_Row_Header.Name = objARH.First().Name_Ref
            objOItem_Attribute_Row_Header.GUID_Parent = objARH.First().ID_Parent_Ref
            objOItem_Attribute_Row_Header.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objXMLText = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Attribute_XML_Text".ToLower()).ToList()

        If objXMLText.Any() Then
            objOItem_Attribute_XML_Text = New clsOntologyItem
            objOItem_Attribute_XML_Text.GUID = objXMLText.First().ID_Ref
            objOItem_Attribute_XML_Text.Name = objXMLText.First().Name_Ref
            objOItem_Attribute_XML_Text.GUID_Parent = objXMLText.First().ID_Parent_Ref
            objOItem_Attribute_XML_Text.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objValue = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Attribute_Value".ToLower()).ToList()

        If objValue.Any() Then
            objOItem_Attribute_Value = New clsOntologyItem
            objOItem_Attribute_Value.GUID = objValue.First().ID_Ref
            objOItem_Attribute_Value.Name = objValue.First().Name_Ref
            objOItem_Attribute_Value.GUID_Parent = objValue.First().ID_Parent_Ref
            objOItem_Attribute_Value.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIsNull = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Attribute_is_Null".ToLower()).ToList()

        If objIsNull.Any() Then
            objOItem_Attribute_is_Null = New clsOntologyItem
            objOItem_Attribute_is_Null.GUID = objIsNull.First().ID_Ref
            objOItem_Attribute_is_Null.Name = objIsNull.First().Name_Ref
            objOItem_Attribute_is_Null.GUID_Parent = objIsNull.First().ID_Parent_Ref
            objOItem_Attribute_is_Null.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objStandard = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Attribute_Standard".ToLower()).ToList()

        If objStandard.Any() Then
            objOItem_Attribute_Standard = New clsOntologyItem
            objOItem_Attribute_Standard.GUID = objStandard.First().ID_Ref
            objOItem_Attribute_Standard.Name = objStandard.First().Name_Ref
            objOItem_Attribute_Standard.GUID_Parent = objStandard.First().ID_Parent_Ref
            objOItem_Attribute_Standard.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objASC = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Attribute_ASC".ToLower()).ToList()

        If objASC.Any() Then
            objOItem_Attribute_ASC = New clsOntologyItem
            objOItem_Attribute_ASC.GUID = objASC.First().ID_Ref
            objOItem_Attribute_ASC.Name = objASC.First().Name_Ref
            objOItem_Attribute_ASC.GUID_Parent = objASC.First().ID_Parent_Ref
            objOItem_Attribute_ASC.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objInvisible = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Attribute_invisible".ToLower()).ToList()

        If objInvisible.Any() Then
            objOItem_Attribute_invisible = New clsOntologyItem
            objOItem_Attribute_invisible.GUID = objInvisible.First().ID_Ref
            objOItem_Attribute_invisible.Name = objInvisible.First().Name_Ref
            objOItem_Attribute_invisible.GUID_Parent = objInvisible.First().ID_Parent_Ref
            objOItem_Attribute_invisible.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If
    End Sub

    Private Sub get_Config_RelationTypes()


        Dim objTBLCfg = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "RelationType_Table_Config".ToLower()).ToList()

        If objTBLCfg.Any() Then
            objOItem_RelationType_Table_Config = New clsOntologyItem
            objOItem_RelationType_Table_Config.GUID = objTBLCfg.First().ID_Ref
            objOItem_RelationType_Table_Config.Name = objTBLCfg.First().Name_Ref
            objOItem_RelationType_Table_Config.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRowCfg = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "RelationType_Row_Config".ToLower()).ToList()

        If objRowCfg.Any() Then
            objOItem_RelationType_Row_Config = New clsOntologyItem
            objOItem_RelationType_Row_Config.GUID = objRowCfg.First().ID_Ref
            objOItem_RelationType_Row_Config.Name = objRowCfg.First().Name_Ref
            objOItem_RelationType_Row_Config.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objClCfg = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "RelationType_Cell_Config".ToLower()).ToList()

        If objClCfg.Any() Then
            objOItem_RelationType_Cell_Config = New clsOntologyItem
            objOItem_RelationType_Cell_Config.GUID = objClCfg.First().ID_Ref
            objOItem_RelationType_Cell_Config.Name = objClCfg.First().Name_Ref
            objOItem_RelationType_Cell_Config.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objConBy = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "RelationType_connected_by".ToLower()).ToList()

        If objConBy.Any() Then
            objOItem_RelationType_connected_by = New clsOntologyItem
            objOItem_RelationType_connected_by.GUID = objConBy.First().ID_Ref
            objOItem_RelationType_connected_by.Name = objConBy.First().Name_Ref
            objOItem_RelationType_connected_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objTypFld = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "RelationType_Type_Field".ToLower()).ToList()

        If objTypFld.Any() Then
            objOItem_RelationType_Type_Field = New clsOntologyItem
            objOItem_RelationType_Type_Field.GUID = objTypFld.First().ID_Ref
            objOItem_RelationType_Type_Field.Name = objTypFld.First().Name_Ref
            objOItem_RelationType_Type_Field.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFmtBy = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "RelationType_Formatted_by".ToLower()).ToList()

        If objFmtBy.Any() Then
            objOItem_RelationType_Formatted_by = New clsOntologyItem
            objOItem_RelationType_Formatted_by.GUID = objFmtBy.First().ID_Ref
            objOItem_RelationType_Formatted_by.Name = objFmtBy.First().Name_Ref
            objOItem_RelationType_Formatted_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBT = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "RelationType_belongsTo".ToLower()).ToList()

        If objBT.Any() Then
            objOItem_RelationType_belongsTo = New clsOntologyItem
            objOItem_RelationType_belongsTo.GUID = objBT.First().ID_Ref
            objOItem_RelationType_belongsTo.Name = objBT.First().Name_Ref
            objOItem_RelationType_belongsTo.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCT = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "RelationType_contains".ToLower()).ToList()

        If objCT.Any() Then
            objOItem_RelationType_contains = New clsOntologyItem
            objOItem_RelationType_contains.GUID = objCT.First().ID_Ref
            objOItem_RelationType_contains.Name = objCT.First().Name_Ref
            objOItem_RelationType_contains.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIS = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "RelationType_is".ToLower()).ToList()

        If objIS.Any() Then
            objOItem_RelationType_is = New clsOntologyItem
            objOItem_RelationType_is.GUID = objIS.First().ID_Ref
            objOItem_RelationType_is.Name = objIS.First().Name_Ref
            objOItem_RelationType_is.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLI = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "RelationType_located_in".ToLower()).ToList()

        If objLI.Any() Then
            objOItem_RelationType_located_in = New clsOntologyItem
            objOItem_RelationType_located_in.GUID = objLI.First().ID_Ref
            objOItem_RelationType_located_in.Name = objLI.First().Name_Ref
            objOItem_RelationType_located_in.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIoT = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "RelationType_is_of_Type".ToLower()).ToList()

        If objIoT.Any() Then
            objOItem_RelationType_is_of_Type = New clsOntologyItem
            objOItem_RelationType_is_of_Type.GUID = objIoT.First().ID_Ref
            objOItem_RelationType_is_of_Type.Name = objIoT.First().Name_Ref
            objOItem_RelationType_is_of_Type.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLDS = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "RelationType_leads".ToLower()).ToList()

        If objLDS.Any() Then
            objOItem_RelationType_leads = New clsOntologyItem
            objOItem_RelationType_leads.GUID = objLDS.First().ID_Ref
            objOItem_RelationType_leads.Name = objLDS.First().Name_Ref
            objOItem_RelationType_leads.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBS = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "RelationType_belonging_Source".ToLower()).ToList()

        If objBS.Any() Then
            objOItem_RelationType_belonging_Source = New clsOntologyItem
            objOItem_RelationType_belonging_Source.GUID = objBS.First().ID_Ref
            objOItem_RelationType_belonging_Source.Name = objBS.First().Name_Ref
            objOItem_RelationType_belonging_Source.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBRS = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "RelationType_belonging_Resources".ToLower()).ToList()

        If objBRS.Any() Then
            objOItem_RelationType_belonging_Resources = New clsOntologyItem
            objOItem_RelationType_belonging_Resources.GUID = objBRS.First().ID_Ref
            objOItem_RelationType_belonging_Resources.Name = objBRS.First().Name_Ref
            objOItem_RelationType_belonging_Resources.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBel = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "RelationType_belonging".ToLower()).ToList()

        If objBel.Any() Then
            objOItem_RelationType_belonging = New clsOntologyItem
            objOItem_RelationType_belonging.GUID = objBel.First().ID_Ref
            objOItem_RelationType_belonging.Name = objBel.First().Name_Ref
            objOItem_RelationType_belonging.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If
    End Sub

    Private Sub get_Config_Classes()



        Dim objDTMS = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_DataTypes__Ms_SQL_".ToLower()).ToList

        If objDTMS.Any() Then
            objOItem_Class_DataTypes__Ms_SQL_ = New clsOntologyItem
            objOItem_Class_DataTypes__Ms_SQL_.GUID = objDTMS.First().ID_Ref
            objOItem_Class_DataTypes__Ms_SQL_.Name = objDTMS.First().Name_Ref
            objOItem_Class_DataTypes__Ms_SQL_.GUID_Parent = objDTMS.First().ID_Parent_Ref
            objOItem_Class_DataTypes__Ms_SQL_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objU = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "type_User".ToLower()).ToList

        If objU.Any() Then
            objOItem_Class_User = New clsOntologyItem
            objOItem_Class_User.GUID = objU.First().ID_Ref
            objOItem_Class_User.Name = objU.First().Name_Ref
            objOItem_Class_User.GUID_Parent = objU.First().ID_Parent_Ref
            objOItem_Class_User.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objVar = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Variable".ToLower()).ToList

        If objVar.Any() Then
            objOItem_Class_Variable = New clsOntologyItem
            objOItem_Class_Variable.GUID = objVar.First().ID_Ref
            objOItem_Class_Variable.Name = objVar.First().Name_Ref
            objOItem_Class_Variable.GUID_Parent = objVar.First().ID_Parent_Ref
            objOItem_Class_Variable.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objXML = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_XML".ToLower()).ToList

        If objXML.Any() Then
            objOItem_Class_XML = New clsOntologyItem
            objOItem_Class_XML.GUID = objXML.First().ID_Ref
            objOItem_Class_XML.Name = objXML.First().Name_Ref
            objOItem_Class_XML.GUID_Parent = objXML.First().ID_Parent_Ref
            objOItem_Class_XML.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objXMLC = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_XML_Config".ToLower()).ToList

        If objXMLC.Any() Then
            objOItem_Class_XML_Config = New clsOntologyItem
            objOItem_Class_XML_Config.GUID = objXMLC.First().ID_Ref
            objOItem_Class_XML_Config.Name = objXMLC.First().Name_Ref
            objOItem_Class_XML_Config.GUID_Parent = objXMLC.First().ID_Parent_Ref
            objOItem_Class_XML_Config.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPath = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Path".ToLower()).ToList

        If objPath.Any() Then
            objOItem_Class_Path = New clsOntologyItem
            objOItem_Class_Path.GUID = objPath.First().ID_Ref
            objOItem_Class_Path.Name = objPath.First().Name_Ref
            objOItem_Class_Path.GUID_Parent = objPath.First().ID_Parent_Ref
            objOItem_Class_Path.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objUrl = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Url".ToLower()).ToList

        If objUrl.Any() Then
            objOItem_Class_Url = New clsOntologyItem
            objOItem_Class_Url.GUID = objUrl.First().ID_Ref
            objOItem_Class_Url.Name = objUrl.First().Name_Ref
            objOItem_Class_Url.GUID_Parent = objUrl.First().ID_Parent_Ref
            objOItem_Class_Url.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPWD = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Password".ToLower()).ToList

        If objPWD.Any() Then
            objOItem_Class_Password = New clsOntologyItem
            objOItem_Class_Password.GUID = objPWD.First().ID_Ref
            objOItem_Class_Password.Name = objPWD.First().Name_Ref
            objOItem_Class_Password.GUID_Parent = objPWD.First().ID_Parent_Ref
            objOItem_Class_Password.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRF = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Report_Filter".ToLower()).ToList

        If objRF.Any() Then
            objOItem_Class_Report_Filter = New clsOntologyItem
            objOItem_Class_Report_Filter.GUID = objRF.First().ID_Ref
            objOItem_Class_Report_Filter.Name = objRF.First().Name_Ref
            objOItem_Class_Report_Filter.GUID_Parent = objRF.First().ID_Parent_Ref
            objOItem_Class_Report_Filter.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCO = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Comparison_Operators".ToLower()).ToList

        If objCO.Any() Then
            objOItem_Class_Comparison_Operators = New clsOntologyItem
            objOItem_Class_Comparison_Operators.GUID = objCO.First().ID_Ref
            objOItem_Class_Comparison_Operators.Name = objCO.First().Name_Ref
            objOItem_Class_Comparison_Operators.GUID_Parent = objCO.First().ID_Parent_Ref
            objOItem_Class_Comparison_Operators.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLO = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Logical_Operators".ToLower()).ToList

        If objLO.Any() Then
            objOItem_Class_Logical_Operators = New clsOntologyItem
            objOItem_Class_Logical_Operators.GUID = objLO.First().ID_Ref
            objOItem_Class_Logical_Operators.Name = objLO.First().Name_Ref
            objOItem_Class_Logical_Operators.GUID_Parent = objLO.First().ID_Parent_Ref
            objOItem_Class_Logical_Operators.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRepSort = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Report_Sort".ToLower()).ToList

        If objRepSort.Any() Then
            objOItem_Class_Report_Sort = New clsOntologyItem
            objOItem_Class_Report_Sort.GUID = objRepSort.First().ID_Ref
            objOItem_Class_Report_Sort.Name = objRepSort.First().Name_Ref
            objOItem_Class_Report_Sort.GUID_Parent = objRepSort.First().ID_Parent_Ref
            objOItem_Class_Report_Sort.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFF = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Field_Format".ToLower()).ToList

        If objFF.Any() Then
            objOItem_Class_Field_Format = New clsOntologyItem
            objOItem_Class_Field_Format.GUID = objFF.First().ID_Ref
            objOItem_Class_Field_Format.Name = objFF.First().Name_Ref
            objOItem_Class_Field_Format.GUID_Parent = objFF.First().ID_Parent_Ref
            objOItem_Class_Field_Format.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDB = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Database".ToLower()).ToList

        If objDB.Any() Then
            objOItem_Class_Database = New clsOntologyItem
            objOItem_Class_Database.GUID = objDB.First().ID_Ref
            objOItem_Class_Database.Name = objDB.First().Name_Ref
            objOItem_Class_Database.GUID_Parent = objDB.First().ID_Parent_Ref
            objOItem_Class_Database.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBoS = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Database_on_Server".ToLower()).ToList

        If objDBoS.Any() Then
            objOItem_Class_Database_on_Server = New clsOntologyItem
            objOItem_Class_Database_on_Server.GUID = objDBoS.First().ID_Ref
            objOItem_Class_Database_on_Server.Name = objDBoS.First().Name_Ref
            objOItem_Class_Database_on_Server.GUID_Parent = objDBoS.First().ID_Parent_Ref
            objOItem_Class_Database_on_Server.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If


        Dim objServ = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Server".ToLower()).ToList

        If objServ.Any() Then
            objOItem_Class_Server = New clsOntologyItem
            objOItem_Class_Server.GUID = objServ.First().ID_Ref
            objOItem_Class_Server.Name = objServ.First().Name_Ref
            objOItem_Class_Server.GUID_Parent = objServ.First().ID_Parent_Ref
            objOItem_Class_Server.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBP = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_DB_Procedure".ToLower()).ToList

        If objDBP.Any() Then
            objOItem_Class_DB_Procedure = New clsOntologyItem
            objOItem_Class_DB_Procedure.GUID = objDBP.First().ID_Ref
            objOItem_Class_DB_Procedure.Name = objDBP.First().Name_Ref
            objOItem_Class_DB_Procedure.GUID_Parent = objDBP.First().ID_Parent_Ref
            objOItem_Class_DB_Procedure.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBV = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_DB_Views".ToLower()).ToList

        If objDBV.Any() Then
            objOItem_Class_DB_Views = New clsOntologyItem
            objOItem_Class_DB_Views.GUID = objDBV.First().ID_Ref
            objOItem_Class_DB_Views.Name = objDBV.First().Name_Ref
            objOItem_Class_DB_Views.GUID_Parent = objDBV.First().ID_Parent_Ref
            objOItem_Class_DB_Views.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRep = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Reports".ToLower()).ToList

        If objRep.Any() Then
            objOItem_Class_Reports = New clsOntologyItem
            objOItem_Class_Reports.GUID = objRep.First().ID_Ref
            objOItem_Class_Reports.Name = objRep.First().Name_Ref
            objOItem_Class_Reports.GUID_Parent = objRep.First().ID_Parent_Ref
            objOItem_Class_Reports.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRepT = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Report_Type".ToLower()).ToList

        If objRepT.Any() Then
            objOItem_Class_Report_Type = New clsOntologyItem
            objOItem_Class_Report_Type.GUID = objRepT.First().ID_Ref
            objOItem_Class_Report_Type.Name = objRepT.First().Name_Ref
            objOItem_Class_Report_Type.GUID_Parent = objRepT.First().ID_Parent_Ref
            objOItem_Class_Report_Type.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRepF = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Report_Field".ToLower()).ToList

        If objRepF.Any() Then
            objOItem_Class_Report_Field = New clsOntologyItem
            objOItem_Class_Report_Field.GUID = objRepF.First().ID_Ref
            objOItem_Class_Report_Field.Name = objRepF.First().Name_Ref
            objOItem_Class_Report_Field.GUID_Parent = objRepF.First().ID_Parent_Ref
            objOItem_Class_Report_Field.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFieldT = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Field_Type".ToLower()).ToList

        If objFieldT.Any() Then
            objOItem_Class_Field_Type = New clsOntologyItem
            objOItem_Class_Field_Type.GUID = objFieldT.First().ID_Ref
            objOItem_Class_Field_Type.Name = objFieldT.First().Name_Ref
            objOItem_Class_Field_Type.GUID_Parent = objFieldT.First().ID_Parent_Ref
            objOItem_Class_Field_Type.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBC = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_DB_Columns".ToLower()).ToList

        If objDBC.Any() Then
            objOItem_Class_DB_Columns = New clsOntologyItem
            objOItem_Class_DB_Columns.GUID = objDBC.First().ID_Ref
            objOItem_Class_DB_Columns.Name = objDBC.First().Name_Ref
            objOItem_Class_DB_Columns.GUID_Parent = objDBC.First().ID_Parent_Ref
            objOItem_Class_DB_Columns.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFile = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_File".ToLower()).ToList

        If objFile.Any() Then
            objOItem_Class_File = New clsOntologyItem
            objOItem_Class_File.GUID = objFile.First().ID_Ref
            objOItem_Class_File.Name = objFile.First().Name_Ref
            objOItem_Class_File.GUID_Parent = objFile.First().ID_Parent_Ref
            objOItem_Class_File.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIES = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Indexes__Elastic_Search_".ToLower()).ToList

        If objIES.Any() Then
            objOItem_Class_Indexes__Elastic_Search_ = New clsOntologyItem
            objOItem_Class_Indexes__Elastic_Search_.GUID = objIES.First().ID_Ref
            objOItem_Class_Indexes__Elastic_Search_.Name = objIES.First().Name_Ref
            objOItem_Class_Indexes__Elastic_Search_.GUID_Parent = objIES.First().ID_Parent_Ref
            objOItem_Class_Indexes__Elastic_Search_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSERVP = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Server_Port".ToLower()).ToList

        If objSERVP.Any() Then
            objOItem_Class_Server_Port = New clsOntologyItem
            objOItem_Class_Server_Port.GUID = objSERVP.First().ID_Ref
            objOItem_Class_Server_Port.Name = objSERVP.First().Name_Ref
            objOItem_Class_Server_Port.GUID_Parent = objSERVP.First().ID_Parent_Ref
            objOItem_Class_Server_Port.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPORT = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Port".ToLower()).ToList

        If objPORT.Any() Then
            objOItem_Class_Port = New clsOntologyItem
            objOItem_Class_Port.GUID = objPORT.First().ID_Ref
            objOItem_Class_Port.Name = objPORT.First().Name_Ref
            objOItem_Class_Port.GUID_Parent = objPORT.First().ID_Parent_Ref
            objOItem_Class_Port.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOJ = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Ontology_Join".ToLower()).ToList

        If objOJ.Any() Then
            objOItem_Class_Ontology_Join = New clsOntologyItem
            objOItem_Class_Ontology_Join.GUID = objOJ.First().ID_Ref
            objOItem_Class_Ontology_Join.Name = objOJ.First().Name_Ref
            objOItem_Class_Ontology_Join.GUID_Parent = objOJ.First().ID_Parent_Ref
            objOItem_Class_Ontology_Join.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOI = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Type_Ontology_Item".ToLower()).ToList

        If objOI.Any() Then
            objOItem_Class_Ontology_Item = New clsOntologyItem
            objOItem_Class_Ontology_Item.GUID = objOI.First().ID_Ref
            objOItem_Class_Ontology_Item.Name = objOI.First().Name_Ref
            objOItem_Class_Ontology_Item.GUID_Parent = objOI.First().ID_Parent_Ref
            objOItem_Class_Ontology_Item.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If
    End Sub

    Private Sub get_Config_Objects()


        Dim objDT = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Field_Type_DateTime".ToLower()).ToList()

        If objDT.Any() Then
            objOItem_Object_Field_Type_DateTime = New clsOntologyItem
            objOItem_Object_Field_Type_DateTime.GUID = objDT.First().ID_Ref
            objOItem_Object_Field_Type_DateTime.Name = objDT.First().Name_Ref
            objOItem_Object_Field_Type_DateTime.GUID_Parent = objDT.First().ID_Parent_Ref
            objOItem_Object_Field_Type_DateTime.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRep = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Variable_REPORT".ToLower()).ToList()

        If objRep.Any() Then
            objOItem_Object_Variable_REPORT = New clsOntologyItem
            objOItem_Object_Variable_REPORT.GUID = objRep.First().ID_Ref
            objOItem_Object_Variable_REPORT.Name = objRep.First().Name_Ref
            objOItem_Object_Variable_REPORT.GUID_Parent = objRep.First().ID_Parent_Ref
            objOItem_Object_Variable_REPORT.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRep20 = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Variable_REPORT_20".ToLower()).ToList()

        If objRep20.Any() Then
            objOItem_Object_Variable_REPORT_20 = New clsOntologyItem
            objOItem_Object_Variable_REPORT_20.GUID = objRep20.First().ID_Ref
            objOItem_Object_Variable_REPORT_20.Name = objRep20.First().Name_Ref
            objOItem_Object_Variable_REPORT_20.GUID_Parent = objRep20.First().ID_Parent_Ref
            objOItem_Object_Variable_REPORT_20.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRowC = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Variable_ROWCOUNT".ToLower()).ToList()

        If objRowC.Any() Then
            objOItem_Object_Variable_ROWCOUNT = New clsOntologyItem
            objOItem_Object_Variable_ROWCOUNT.GUID = objRowC.First().ID_Ref
            objOItem_Object_Variable_ROWCOUNT.Name = objRowC.First().Name_Ref
            objOItem_Object_Variable_ROWCOUNT.GUID_Parent = objRowC.First().ID_Parent_Ref
            objOItem_Object_Variable_ROWCOUNT.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objAuth = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Variable_AUTHOR".ToLower()).ToList()

        If objAuth.Any() Then
            objOItem_Object_Variable_AUTHOR = New clsOntologyItem
            objOItem_Object_Variable_AUTHOR.GUID = objAuth.First().ID_Ref
            objOItem_Object_Variable_AUTHOR.Name = objAuth.First().Name_Ref
            objOItem_Object_Variable_AUTHOR.GUID_Parent = objAuth.First().ID_Parent_Ref
            objOItem_Object_Variable_AUTHOR.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objColC = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Variable_COLCOUNT".ToLower()).ToList()

        If objColC.Any() Then
            objOItem_Object_Variable_COLCOUNT = New clsOntologyItem
            objOItem_Object_Variable_COLCOUNT.GUID = objColC.First().ID_Ref
            objOItem_Object_Variable_COLCOUNT.Name = objColC.First().Name_Ref
            objOItem_Object_Variable_COLCOUNT.GUID_Parent = objColC.First().ID_Parent_Ref
            objOItem_Object_Variable_COLCOUNT.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDTTZ = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Variable_DATETIME_TZ".ToLower()).ToList()

        If objDTTZ.Any() Then
            objOItem_Object_Variable_DATETIME_TZ = New clsOntologyItem
            objOItem_Object_Variable_DATETIME_TZ.GUID = objDTTZ.First().ID_Ref
            objOItem_Object_Variable_DATETIME_TZ.Name = objDTTZ.First().Name_Ref
            objOItem_Object_Variable_DATETIME_TZ.GUID_Parent = objDTTZ.First().ID_Parent_Ref
            objOItem_Object_Variable_DATETIME_TZ.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objID = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Variable_id".ToLower()).ToList()

        If objID.Any() Then
            objOItem_Object_Variable_id = New clsOntologyItem
            objOItem_Object_Variable_id.GUID = objID.First().ID_Ref
            objOItem_Object_Variable_id.Name = objID.First().Name_Ref
            objOItem_Object_Variable_id.GUID_Parent = objID.First().ID_Parent_Ref
            objOItem_Object_Variable_id.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objROWN = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Variable_ROW_NAME".ToLower()).ToList()

        If objROWN.Any() Then
            objOItem_Object_Variable_ROW_NAME = New clsOntologyItem
            objOItem_Object_Variable_ROW_NAME.GUID = objROWN.First().ID_Ref
            objOItem_Object_Variable_ROW_NAME.Name = objROWN.First().Name_Ref
            objOItem_Object_Variable_ROW_NAME.GUID_Parent = objROWN.First().ID_Parent_Ref
            objOItem_Object_Variable_ROW_NAME.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objROWL = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Variable_ROW_LIST".ToLower()).ToList()

        If objROWL.Any() Then
            objOItem_Object_Variable_ROW_LIST = New clsOntologyItem
            objOItem_Object_Variable_ROW_LIST.GUID = objROWL.First().ID_Ref
            objOItem_Object_Variable_ROW_LIST.Name = objROWL.First().Name_Ref
            objOItem_Object_Variable_ROW_LIST.GUID_Parent = objROWL.First().ID_Parent_Ref
            objOItem_Object_Variable_ROW_LIST.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCELLV = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Variable_CELL_VALUE".ToLower()).ToList()

        If objCELLV.Any() Then
            objOItem_Object_Variable_CELL_VALUE = New clsOntologyItem
            objOItem_Object_Variable_CELL_VALUE.GUID = objCELLV.First().ID_Ref
            objOItem_Object_Variable_CELL_VALUE.Name = objCELLV.First().Name_Ref
            objOItem_Object_Variable_CELL_VALUE.GUID_Parent = objCELLV.First().ID_Parent_Ref
            objOItem_Object_Variable_CELL_VALUE.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCELLN = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Variable_CELL_NAME".ToLower()).ToList()

        If objCELLN.Any() Then
            objOItem_Object_Variable_CELL_NAME = New clsOntologyItem
            objOItem_Object_Variable_CELL_NAME.GUID = objCELLN.First().ID_Ref
            objOItem_Object_Variable_CELL_NAME.Name = objCELLN.First().Name_Ref
            objOItem_Object_Variable_CELL_NAME.GUID_Parent = objCELLN.First().ID_Parent_Ref
            objOItem_Object_Variable_CELL_NAME.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCELLL = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Variable_CELL_LIST".ToLower()).ToList()

        If objCELLL.Any() Then
            objOItem_Object_Variable_CELL_LIST = New clsOntologyItem
            objOItem_Object_Variable_CELL_LIST.GUID = objCELLL.First().ID_Ref
            objOItem_Object_Variable_CELL_LIST.Name = objCELLL.First().Name_Ref
            objOItem_Object_Variable_CELL_LIST.GUID_Parent = objCELLL.First().ID_Parent_Ref
            objOItem_Object_Variable_CELL_LIST.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRTV = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Report_Type_View".ToLower()).ToList()

        If objRTV.Any() Then
            objOItem_Object_Report_Type_View = New clsOntologyItem
            objOItem_Object_Report_Type_View.GUID = objRTV.First().ID_Ref
            objOItem_Object_Report_Type_View.Name = objRTV.First().Name_Ref
            objOItem_Object_Report_Type_View.GUID_Parent = objRTV.First().ID_Parent_Ref
            objOItem_Object_Report_Type_View.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRTTR = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Report_Type_Token_Report".ToLower()).ToList()

        If objRTTR.Any() Then
            objOItem_Object_Report_Type_Token_Report = New clsOntologyItem
            objOItem_Object_Report_Type_Token_Report.GUID = objRTTR.First().ID_Ref
            objOItem_Object_Report_Type_Token_Report.Name = objRTTR.First().Name_Ref
            objOItem_Object_Report_Type_Token_Report.GUID_Parent = objRTTR.First().ID_Parent_Ref
            objOItem_Object_Report_Type_Token_Report.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFTT = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Field_Type_Text".ToLower()).ToList()

        If objFTT.Any() Then
            objOItem_Object_Field_Type_Text = New clsOntologyItem
            objOItem_Object_Field_Type_Text.GUID = objFTT.First().ID_Ref
            objOItem_Object_Field_Type_Text.Name = objFTT.First().Name_Ref
            objOItem_Object_Field_Type_Text.GUID_Parent = objFTT.First().ID_Parent_Ref
            objOItem_Object_Field_Type_Text.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFTG = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Field_Type_GUID".ToLower()).ToList()

        If objFTG.Any() Then
            objOItem_Object_Field_Type_GUID = New clsOntologyItem
            objOItem_Object_Field_Type_GUID.GUID = objFTG.First().ID_Ref
            objOItem_Object_Field_Type_GUID.Name = objFTG.First().Name_Ref
            objOItem_Object_Field_Type_GUID.GUID_Parent = objFTG.First().ID_Parent_Ref
            objOItem_Object_Field_Type_GUID.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFTZ = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Field_Type_Zahl".ToLower()).ToList()

        If objFTZ.Any() Then
            objOItem_Object_Field_Type_Zahl = New clsOntologyItem
            objOItem_Object_Field_Type_Zahl.GUID = objFTZ.First().ID_Ref
            objOItem_Object_Field_Type_Zahl.Name = objFTZ.First().Name_Ref
            objOItem_Object_Field_Type_Zahl.GUID_Parent = objFTZ.First().ID_Parent_Ref
            objOItem_Object_Field_Type_Zahl.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If



        Dim objESV = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Report_Type_ElasticView".ToLower()).ToList()

        If objESV.Any() Then
            objOItem_Object_Report_Type_ElasticView = New clsOntologyItem
            objOItem_Object_Report_Type_ElasticView.GUID = objESV.First().ID_Ref
            objOItem_Object_Report_Type_ElasticView.Name = objESV.First().Name_Ref
            objOItem_Object_Report_Type_ElasticView.GUID_Parent = objESV.First().ID_Parent_Ref
            objOItem_Object_Report_Type_ElasticView.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objROJ = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Ontology_Relation_Rule_Right_Outer_Join".ToLower()).ToList()

        If objROJ.Any() Then
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.GUID = objROJ.First().ID_Ref
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.Name = objROJ.First().Name_Ref
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.GUID_Parent = objROJ.First().ID_Parent_Ref
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRELB = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Ontology_Relation_Rule_Relation_Break".ToLower()).ToList()

        If objRELB.Any() Then
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.GUID = objRELB.First().ID_Ref
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.Name = objRELB.First().Name_Ref
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.GUID_Parent = objRELB.First().ID_Parent_Ref
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRPT = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Ontology_Relation_Rule_Parent_Types".ToLower()).ToList()

        If objRPT.Any() Then
            objOItem_Object_Ontology_Relation_Rule_Parent_Types = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Parent_Types.GUID = objRPT.First().ID_Ref
            objOItem_Object_Ontology_Relation_Rule_Parent_Types.Name = objRPT.First().Name_Ref
            objOItem_Object_Ontology_Relation_Rule_Parent_Types.GUID_Parent = objRPT.First().ID_Parent_Ref
            objOItem_Object_Ontology_Relation_Rule_Parent_Types.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objROI = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Ontology_Relation_Rule_Only_Item".ToLower()).ToList()

        If objROI.Any() Then
            objOItem_Object_Ontology_Relation_Rule_Only_Item = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Only_Item.GUID = objROI.First().ID_Ref
            objOItem_Object_Ontology_Relation_Rule_Only_Item.Name = objROI.First().Name_Ref
            objOItem_Object_Ontology_Relation_Rule_Only_Item.GUID_Parent = objROI.First().ID_Parent_Ref
            objOItem_Object_Ontology_Relation_Rule_Only_Item.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


        Dim objNoTP = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Ontology_Relation_Rule_Name_of_Type_Parse".ToLower()).ToList()

        If objNoTP.Any() Then
            objOItem_Object_Ontology_Relation_Rule_Name_of_Type_Parse = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Name_of_Type_Parse.GUID = objNoTP.First().ID_Ref
            objOItem_Object_Ontology_Relation_Rule_Name_of_Type_Parse.Name = objNoTP.First().Name_Ref
            objOItem_Object_Ontology_Relation_Rule_Name_of_Type_Parse.GUID_Parent = objNoTP.First().ID_Parent_Ref
            objOItem_Object_Ontology_Relation_Rule_Name_of_Type_Parse.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


        Dim objLOJ = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Ontology_Relation_Rule_Left_Outer_Join".ToLower()).ToList()

        If objLOJ.Any() Then
            objOItem_Object_Ontology_Relation_Rule_Left_Outer_Join = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Left_Outer_Join.GUID = objLOJ.First().ID_Ref
            objOItem_Object_Ontology_Relation_Rule_Left_Outer_Join.Name = objLOJ.First().Name_Ref
            objOItem_Object_Ontology_Relation_Rule_Left_Outer_Join.GUID_Parent = objLOJ.First().ID_Parent_Ref
            objOItem_Object_Ontology_Relation_Rule_Left_Outer_Join.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIJ = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Ontology_Relation_Rule_Inner_Join".ToLower()).ToList()

        If objIJ.Any() Then
            objOItem_Object_Ontology_Relation_Rule_Inner_Join = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Inner_Join.GUID = objIJ.First().ID_Ref
            objOItem_Object_Ontology_Relation_Rule_Inner_Join.Name = objIJ.First().Name_Ref
            objOItem_Object_Ontology_Relation_Rule_Inner_Join.GUID_Parent = objIJ.First().ID_Parent_Ref
            objOItem_Object_Ontology_Relation_Rule_Inner_Join.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


        Dim objCT = objOList_Ontologyitems.Where(Function(p) p.Name_OntologyItem.ToLower() = "Token_Ontology_Relation_Rule_Child_Token".ToLower()).ToList()

        If objCT.Any() Then
            objOItem_Object_Ontology_Relation_Rule_Child_Token = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Child_Token.GUID = objCT.First().ID_Ref
            objOItem_Object_Ontology_Relation_Rule_Child_Token.Name = objCT.First().Name_Ref
            objOItem_Object_Ontology_Relation_Rule_Child_Token.GUID_Parent = objCT.First().ID_Parent_Ref
            objOItem_Object_Ontology_Relation_Rule_Child_Token.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If
    End Sub

    Private sub get_Data_DevelopmentConfig()
         objDataWork_Ontologies.GetData_003_OntologyItemsOfOntologies()
            If objDataWork_Ontologies.OItem_Result_OntologyItemsOfOntologies.GUID = objGlobals.LState_Success.GUID Then
                objDataWork_Ontologies.GetData_RefsOfOntologyItems()
                If objDataWork_Ontologies.OItem_Result_RefsOfOntologyItems.GUID = objGlobals.LState_Success.GUID Then
                    objDataWork_Ontologies.GetData_OntologyRefs()
                    If objDataWork_Ontologies.OItem_Result_OntologyRels.GUID = objGlobals.LState_Success.GUID Then
                        Dim objOntologies = objDataWork_Ontologies.OList_RefsOfOntologies.Where(Function(p) p.ID_Other = cstr_ID_SoftwareDevelopment).ToList()

                    
                    

                        If objOntologies.Any() Then
                            objOItem_Ontology = New clsOntologyItem With {.GUID = objOntologies.First().ID_Object, _
                                                                          .Name = objOntologies.First().Name_Object, _
                                                                          .GUID_Parent = objGlobals.Class_Ontologies.GUID, _
                                                                          .Type = objGlobals.Type_Object}

                            objOList_Ontologyitems = objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID).ToList()
                        Else 
                            Err.Raise(1, "Config not set!")
                        end if
                    Else 
                        Err.Raise(1, "Config not set!")
                    End If
                Else 
                    Err.Raise(1, "Config not set!")
                end if
            Else 
                Err.Raise(1, "Config not set!")
            end if

    End Sub
    'Private Sub get_Data_DevelopmentConfig()
    '    Dim objOItem_ObjecRel As clsObjectRel
    '    Dim oList_ObjectRel As New List(Of clsObjectRel)
    '    Dim oList_ConfigItems As New List(Of clsOntologyItem)

    '    Dim oList_RelType_contains As New List(Of clsOntologyItem)
    '    Dim oList_RelType_belongsTo As New List(Of clsOntologyItem)

    '    Dim oList_ConfigItem As New List(Of clsOntologyItem)


    '    oList_ObjectRel.Add(New clsObjectRel(cstr_ID_SoftwareDevelopment, _
    '                                        Nothing, _
    '                                        Nothing, _
    '                                        Nothing, _
    '                                        Nothing, _
    '                                        Nothing, _
    '                                        cstr_ID_Class_DevelopmentConfig, _
    '                                        Nothing, _
    '                                        cstr_ID_RelType_needs, _
    '                                        Nothing, _
    '                                        objGlobals.Type_Object, _
    '                                        Nothing, _
    '                                        Nothing, _
    '                                        Nothing))

    '    objDBLevel_Config1.get_Data_ObjectRel(oList_ObjectRel)

    '    If objDBLevel_Config1.OList_ObjectRel_ID.Any() Then
    '        objOItem_DevConfig.GUID = objDBLevel_Config1.OList_ObjectRel_ID.First().ID_Ref
    '        objOItem_DevConfig.Name = objDBLevel_Config1.OList_ObjectRel_ID.First().Name_Ref
    '        objOItem_DevConfig.GUID_Parent = objDBLevel_Config1.OList_ObjectRel_ID.First().ID_Parent_Ref
    '        objOItem_DevConfig.Type = objDBLevel_Config1.OList_ObjectRel_ID(0).Ontology

    '        oList_ObjectRel.Clear()
    '        oList_ObjectRel.Add(New clsObjectRel(objOItem_DevConfig.GUID, _
    '                                             Nothing, _
    '                                             Nothing, _
    '                                             Nothing, _
    '                                             Nothing, _
    '                                             Nothing, _
    '                                             cstr_ID_Class_ConfigItem, _
    '                                             Nothing, _
    '                                             cstr_ID_RelType_contains, _
    '                                             Nothing, _
    '                                             objGlobals.Type_Object, _
    '                                             Nothing, _
    '                                             Nothing, _
    '                                             Nothing))

    '        objDBLevel_Config1.get_Data_ObjectRel(oList_ObjectRel, _
    '                                      False, _
    '                                      False, _
    '                                      False, _
    '                                      objGlobals.Direction_LeftRight.Name, _
    '                                      True)
    '        oList_ObjectRel.Clear()
    '        If objDBLevel_Config1.OList_ObjectRel.Any() Then
    '            For Each objOItem_ObjecRel In objDBLevel_Config1.OList_ObjectRel
    '                oList_ConfigItems.Add(New clsOntologyItem(objOItem_ObjecRel.ID_Other, _
    '                                                          objGlobals.Type_Object))

    '                oList_ObjectRel.Add(New clsObjectRel(objOItem_ObjecRel.ID_Other, _
    '                                                     Nothing, _
    '                                                     Nothing, _
    '                                                     Nothing, _
    '                                                     Nothing, _
    '                                                     Nothing, _
    '                                                     Nothing, _
    '                                                     Nothing, _
    '                                                     cstr_ID_RelType_belongsTo, _
    '                                                     Nothing, _
    '                                                     Nothing, _
    '                                                     objGlobals.Direction_LeftRight.GUID, _
    '                                                     objGlobals.Direction_LeftRight.Name, _
    '                                                     Nothing))



    '            Next

    '            objDBLevel_Config2.get_Data_ObjectRel(oList_ObjectRel, _
    '                                                     False, _
    '                                                     False, _
    '                                                     False, _
    '                                                     objGlobals.Direction_LeftRight.Name, _
    '                                                     False)
    '        Else
    '            Err.Raise(1, "Config not set!")
    '        End If

    '    Else
    '        Err.Raise(1, "Config not set!")
    '    End If

    'End Sub

    Private Sub set_DBConnection()
        objDataWork_Ontologies = New clsDataWork_Ontologies(objGlobals)
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
