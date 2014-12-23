Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports System.Reflection

Public Class clsLocalConfig
    Private objImport As clsImport

    Private cstrID_Ontology As String = "ca8bccf7e9974a929604d283a55636bf"

    Private objGlobals As clsGlobals

    Private objOItem_DevConfig As New clsOntologyItem
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
    Private objOItem_attributetype_nextline As clsOntologyItem

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
    Private objOItem_relationtype_table_tags As clsOntologyItem
    Private objOItem_relationtype_row_tags As clsOntologyItem
    Private objOItem_relationtype_header_tags As clsOntologyItem
    Private objOItem_relationtype_cell_tags As clsOntologyItem
    Private objOItem_relationtype_bold_tags As clsOntologyItem
    Private objOItem_relationtype_value_type As clsOntologyItem

    'Token
    Private objOItem_object_baseconfig As clsOntologyItem
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
    Private objOItem_object_commandlinerun_module As clsOntologyItem
    Private objOItem_object_string As clsOntologyItem
    Private objOItem_object_int As clsOntologyItem
    Private objOItem_object_double As clsOntologyItem
    Private objOItem_object_datetime As clsOntologyItem
    Private objOItem_object_bit As clsOntologyItem


    'Types
    Private objOItem_class_clipboardfilter_tags As clsOntologyItem
    Private objOItem_class_clipboardfilter As clsOntologyItem
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
    Private objOItem_class_types__elastic_search_ As clsOntologyItem
    Private objOItem_class_field As clsOntologyItem
    Private objOItem_class_datatypes As clsOntologyItem

    Private objOItem_User As clsOntologyItem
    Private objOItem_Group As clsOntologyItem

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

    Public Property Group As clsOntologyItem
        Get
            Return objOItem_Group
        End Get
        Set(value As clsOntologyItem)
            objOItem_Group = value
        End Set
    End Property
    
    'Attributes
    Public ReadOnly Property OItem_attributetype_nextline As clsOntologyItem
        Get
            Return objOItem_attributetype_nextline
        End Get
    End Property

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
    Public ReadOnly Property OItem_relationtype_table_tags As clsOntologyItem
        Get
            Return objOItem_relationtype_table_tags
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_row_tags As clsOntologyItem
        Get
            Return objOItem_relationtype_row_tags
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_header_tags As clsOntologyItem
        Get
            Return objOItem_relationtype_header_tags
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_cell_tags As clsOntologyItem
        Get
            Return objOItem_relationtype_cell_tags
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_bold_tags As clsOntologyItem
        Get
            Return objOItem_relationtype_bold_tags
        End Get
    End Property

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

    Public ReadOnly Property OItem_object_commandlinerun_module As clsOntologyItem
        Get
            Return objOItem_object_commandlinerun_module
        End Get
    End Property

    Public ReadOnly Property OItem_relationtype_value_type As clsOntologyItem
        Get
            Return objOItem_relationtype_value_type
        End Get
    End Property


    'Token
    Public ReadOnly Property OItem_object_baseconfig As clsOntologyItem
        Get
            Return objOItem_object_baseconfig
        End Get
    End Property

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

    Public ReadOnly Property OItem_object_string As clsOntologyItem
        Get
            Return objOItem_object_string
        End Get
    End Property

    Public ReadOnly Property OItem_object_int As clsOntologyItem
        Get
            Return objOItem_object_int
        End Get
    End Property

    Public ReadOnly Property OItem_object_double As clsOntologyItem
        Get
            Return objOItem_object_double
        End Get
    End Property

    Public ReadOnly Property OItem_object_datetime As clsOntologyItem
        Get
            Return objOItem_object_datetime
        End Get
    End Property

    Public ReadOnly Property OItem_object_bit As clsOntologyItem
        Get
            Return objOItem_object_bit
        End Get
    End Property


    'Types
    Public ReadOnly Property OItem_class_clipboardfilter_tags As clsOntologyItem
        Get
            Return objOItem_class_clipboardfilter_tags
        End Get
    End Property

    Public ReadOnly Property OItem_class_clipboardfilter As clsOntologyItem
        Get
            Return objOItem_class_clipboardfilter
        End Get
    End Property

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

    Public ReadOnly Property OItem_class_types__elastic_search_ As clsOntologyItem
        Get
            Return objOItem_class_types__elastic_search_
        End Get
    End Property

    Public ReadOnly Property OItem_class_field As clsOntologyItem
        Get
            Return objOItem_class_field
        End Get
    End Property

    Public ReadOnly Property OItem_class_datatypes As clsOntologyItem
        Get
            Return objOItem_class_datatypes
        End Get
    End Property


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
                Else
                    Err.Raise(1, "Config not importable")
                End If
            Else
                Environment.Exit(0)
            End If

        End Try
    End Sub

    Private Sub get_Config_AttributeTypes()
        Dim objOList_attributetype_nextline = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attributetype_nextline".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attributetype_nextline.Count > 0 Then
            objOItem_attributetype_nextline = New clsOntologyItem
            objOItem_attributetype_nextline.GUID = objOList_attributetype_nextline.First().ID_Other
            objOItem_attributetype_nextline.Name = objOList_attributetype_nextline.First().Name_Other
            objOItem_attributetype_nextline.GUID_Parent = objOList_attributetype_nextline.First().ID_Parent_Other
            objOItem_attributetype_nextline.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objAVisible = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_visible".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objAVisible.Any() Then
            objOItem_Attribute_ASC = New clsOntologyItem
            objOItem_Attribute_ASC.GUID = objAVisible.First().ID_Other
            objOItem_Attribute_ASC.Name = objAVisible.First().Name_Other
            objOItem_Attribute_ASC.GUID_Parent = objAVisible.First().ID_Parent_Other
            objOItem_Attribute_ASC.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objARH = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_Row_Header".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objARH.Any() Then
            objOItem_Attribute_Row_Header = New clsOntologyItem
            objOItem_Attribute_Row_Header.GUID = objARH.First().ID_Other
            objOItem_Attribute_Row_Header.Name = objARH.First().Name_Other
            objOItem_Attribute_Row_Header.GUID_Parent = objARH.First().ID_Parent_Other
            objOItem_Attribute_Row_Header.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objXMLText = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_XML_Text".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objXMLText.Any() Then
            objOItem_Attribute_XML_Text = New clsOntologyItem
            objOItem_Attribute_XML_Text.GUID = objXMLText.First().ID_Other
            objOItem_Attribute_XML_Text.Name = objXMLText.First().Name_Other
            objOItem_Attribute_XML_Text.GUID_Parent = objXMLText.First().ID_Parent_Other
            objOItem_Attribute_XML_Text.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objValue = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_Value".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objValue.Any() Then
            objOItem_Attribute_Value = New clsOntologyItem
            objOItem_Attribute_Value.GUID = objValue.First().ID_Other
            objOItem_Attribute_Value.Name = objValue.First().Name_Other
            objOItem_Attribute_Value.GUID_Parent = objValue.First().ID_Parent_Other
            objOItem_Attribute_Value.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIsNull = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_is_Null".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objIsNull.Any() Then
            objOItem_Attribute_is_Null = New clsOntologyItem
            objOItem_Attribute_is_Null.GUID = objIsNull.First().ID_Other
            objOItem_Attribute_is_Null.Name = objIsNull.First().Name_Other
            objOItem_Attribute_is_Null.GUID_Parent = objIsNull.First().ID_Parent_Other
            objOItem_Attribute_is_Null.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objStandard = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_Standard".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objStandard.Any() Then
            objOItem_Attribute_Standard = New clsOntologyItem
            objOItem_Attribute_Standard.GUID = objStandard.First().ID_Other
            objOItem_Attribute_Standard.Name = objStandard.First().Name_Other
            objOItem_Attribute_Standard.GUID_Parent = objStandard.First().ID_Parent_Other
            objOItem_Attribute_Standard.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objASC = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_ASC".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()
        If objASC.Any() Then
            objOItem_Attribute_ASC = New clsOntologyItem
            objOItem_Attribute_ASC.GUID = objASC.First().ID_Other
            objOItem_Attribute_ASC.Name = objASC.First().Name_Other
            objOItem_Attribute_ASC.GUID_Parent = objASC.First().ID_Parent_Other
            objOItem_Attribute_ASC.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objInvisible = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Attribute_invisible".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objInvisible.Any() Then
            objOItem_Attribute_invisible = New clsOntologyItem
            objOItem_Attribute_invisible.GUID = objInvisible.First().ID_Other
            objOItem_Attribute_invisible.Name = objInvisible.First().Name_Other
            objOItem_Attribute_invisible.GUID_Parent = objInvisible.First().ID_Parent_Other
            objOItem_Attribute_invisible.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If
    End Sub

    Private Sub get_Config_RelationTypes()
        Dim objOList_relationtype_value_type = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_value_type".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_value_type.Count > 0 Then
            objOItem_relationtype_value_type = New clsOntologyItem
            objOItem_relationtype_value_type.GUID = objOList_relationtype_value_type.First().ID_Other
            objOItem_relationtype_value_type.Name = objOList_relationtype_value_type.First().Name_Other
            objOItem_relationtype_value_type.GUID_Parent = objOList_relationtype_value_type.First().ID_Parent_Other
            objOItem_relationtype_value_type.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_table_tags = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_table_tags".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_table_tags.Count > 0 Then
            objOItem_relationtype_table_tags = New clsOntologyItem
            objOItem_relationtype_table_tags.GUID = objOList_relationtype_table_tags.First().ID_Other
            objOItem_relationtype_table_tags.Name = objOList_relationtype_table_tags.First().Name_Other
            objOItem_relationtype_table_tags.GUID_Parent = objOList_relationtype_table_tags.First().ID_Parent_Other
            objOItem_relationtype_table_tags.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_row_tags = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                                   Where objOItem.ID_Object = cstrID_Ontology
                                                   Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                                   Where objRef.Name_Object.ToLower() = "relationtype_row_tags".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                                   Select objRef).ToList()

        If objOList_relationtype_row_tags.Count > 0 Then
            objOItem_relationtype_row_tags = New clsOntologyItem
            objOItem_relationtype_row_tags.GUID = objOList_relationtype_row_tags.First().ID_Other
            objOItem_relationtype_row_tags.Name = objOList_relationtype_row_tags.First().Name_Other
            objOItem_relationtype_row_tags.GUID_Parent = objOList_relationtype_row_tags.First().ID_Parent_Other
            objOItem_relationtype_row_tags.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_header_tags = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                                   Where objOItem.ID_Object = cstrID_Ontology
                                                   Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                                   Where objRef.Name_Object.ToLower() = "relationtype_header_tags".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                                   Select objRef).ToList()

        If objOList_relationtype_header_tags.Count > 0 Then
            objOItem_relationtype_header_tags = New clsOntologyItem
            objOItem_relationtype_header_tags.GUID = objOList_relationtype_header_tags.First().ID_Other
            objOItem_relationtype_header_tags.Name = objOList_relationtype_header_tags.First().Name_Other
            objOItem_relationtype_header_tags.GUID_Parent = objOList_relationtype_header_tags.First().ID_Parent_Other
            objOItem_relationtype_header_tags.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_cell_tags = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                                   Where objOItem.ID_Object = cstrID_Ontology
                                                   Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                                   Where objRef.Name_Object.ToLower() = "relationtype_cell_tags".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                                   Select objRef).ToList()

        If objOList_relationtype_cell_tags.Count > 0 Then
            objOItem_relationtype_cell_tags = New clsOntologyItem
            objOItem_relationtype_cell_tags.GUID = objOList_relationtype_cell_tags.First().ID_Other
            objOItem_relationtype_cell_tags.Name = objOList_relationtype_cell_tags.First().Name_Other
            objOItem_relationtype_cell_tags.GUID_Parent = objOList_relationtype_cell_tags.First().ID_Parent_Other
            objOItem_relationtype_cell_tags.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_bold_tags = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                                   Where objOItem.ID_Object = cstrID_Ontology
                                                   Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                                   Where objRef.Name_Object.ToLower() = "relationtype_bold_tags".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                                   Select objRef).ToList()

        If objOList_relationtype_bold_tags.Count > 0 Then
            objOItem_relationtype_bold_tags = New clsOntologyItem
            objOItem_relationtype_bold_tags.GUID = objOList_relationtype_bold_tags.First().ID_Other
            objOItem_relationtype_bold_tags.Name = objOList_relationtype_bold_tags.First().Name_Other
            objOItem_relationtype_bold_tags.GUID_Parent = objOList_relationtype_bold_tags.First().ID_Parent_Other
            objOItem_relationtype_bold_tags.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objTBLCfg = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_Table_Config".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objTBLCfg.Any() Then
            objOItem_RelationType_Table_Config = New clsOntologyItem
            objOItem_RelationType_Table_Config.GUID = objTBLCfg.First().ID_Other
            objOItem_RelationType_Table_Config.Name = objTBLCfg.First().Name_Other
            objOItem_RelationType_Table_Config.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRowCfg = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_Row_Config".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objRowCfg.Any() Then
            objOItem_RelationType_Row_Config = New clsOntologyItem
            objOItem_RelationType_Row_Config.GUID = objRowCfg.First().ID_Other
            objOItem_RelationType_Row_Config.Name = objRowCfg.First().Name_Other
            objOItem_RelationType_Row_Config.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objClCfg = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_Cell_Config".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objClCfg.Any() Then
            objOItem_RelationType_Cell_Config = New clsOntologyItem
            objOItem_RelationType_Cell_Config.GUID = objClCfg.First().ID_Other
            objOItem_RelationType_Cell_Config.Name = objClCfg.First().Name_Other
            objOItem_RelationType_Cell_Config.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objConBy = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_connected_by".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objConBy.Any() Then
            objOItem_RelationType_connected_by = New clsOntologyItem
            objOItem_RelationType_connected_by.GUID = objConBy.First().ID_Other
            objOItem_RelationType_connected_by.Name = objConBy.First().Name_Other
            objOItem_RelationType_connected_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objTypFld = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_Type_Field".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objTypFld.Any() Then
            objOItem_RelationType_Type_Field = New clsOntologyItem
            objOItem_RelationType_Type_Field.GUID = objTypFld.First().ID_Other
            objOItem_RelationType_Type_Field.Name = objTypFld.First().Name_Other
            objOItem_RelationType_Type_Field.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFmtBy = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_Formatted_by".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objFmtBy.Any() Then
            objOItem_RelationType_Formatted_by = New clsOntologyItem
            objOItem_RelationType_Formatted_by.GUID = objFmtBy.First().ID_Other
            objOItem_RelationType_Formatted_by.Name = objFmtBy.First().Name_Other
            objOItem_RelationType_Formatted_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_belongsTo".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objBT.Any() Then
            objOItem_RelationType_belongsTo = New clsOntologyItem
            objOItem_RelationType_belongsTo.GUID = objBT.First().ID_Other
            objOItem_RelationType_belongsTo.Name = objBT.First().Name_Other
            objOItem_RelationType_belongsTo.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_contains".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objCT.Any() Then
            objOItem_RelationType_contains = New clsOntologyItem
            objOItem_RelationType_contains.GUID = objCT.First().ID_Other
            objOItem_RelationType_contains.Name = objCT.First().Name_Other
            objOItem_RelationType_contains.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIS = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_is".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objIS.Any() Then
            objOItem_RelationType_is = New clsOntologyItem
            objOItem_RelationType_is.GUID = objIS.First().ID_Other
            objOItem_RelationType_is.Name = objIS.First().Name_Other
            objOItem_RelationType_is.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLI = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_located_in".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objLI.Any() Then
            objOItem_RelationType_located_in = New clsOntologyItem
            objOItem_RelationType_located_in.GUID = objLI.First().ID_Other
            objOItem_RelationType_located_in.Name = objLI.First().Name_Other
            objOItem_RelationType_located_in.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIoT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_is_of_Type".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objIoT.Any() Then
            objOItem_RelationType_is_of_Type = New clsOntologyItem
            objOItem_RelationType_is_of_Type.GUID = objIoT.First().ID_Other
            objOItem_RelationType_is_of_Type.Name = objIoT.First().Name_Other
            objOItem_RelationType_is_of_Type.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLDS = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_leads".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objLDS.Any() Then
            objOItem_RelationType_leads = New clsOntologyItem
            objOItem_RelationType_leads.GUID = objLDS.First().ID_Other
            objOItem_RelationType_leads.Name = objLDS.First().Name_Other
            objOItem_RelationType_leads.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBS = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_belonging_Source".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objBS.Any() Then
            objOItem_RelationType_belonging_Source = New clsOntologyItem
            objOItem_RelationType_belonging_Source.GUID = objBS.First().ID_Other
            objOItem_RelationType_belonging_Source.Name = objBS.First().Name_Other
            objOItem_RelationType_belonging_Source.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBRS = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_belonging_Resources".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objBRS.Any() Then
            objOItem_RelationType_belonging_Resources = New clsOntologyItem
            objOItem_RelationType_belonging_Resources.GUID = objBRS.First().ID_Other
            objOItem_RelationType_belonging_Resources.Name = objBRS.First().Name_Other
            objOItem_RelationType_belonging_Resources.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objBel = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "RelationType_belonging".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objBel.Any() Then
            objOItem_RelationType_belonging = New clsOntologyItem
            objOItem_RelationType_belonging.GUID = objBel.First().ID_Other
            objOItem_RelationType_belonging.Name = objBel.First().Name_Other
            objOItem_RelationType_belonging.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If
    End Sub

    Private Sub get_Config_Classes()
        Dim objOList_class_datatypes = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_datatypes".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_datatypes.Count > 0 Then
            objOItem_class_datatypes = New clsOntologyItem
            objOItem_class_datatypes.GUID = objOList_class_datatypes.First().ID_Other
            objOItem_class_datatypes.Name = objOList_class_datatypes.First().Name_Other
            objOItem_class_datatypes.GUID_Parent = objOList_class_datatypes.First().ID_Parent_Other
            objOItem_class_datatypes.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_class_field = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_field".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_field.Count > 0 Then
            objOItem_class_field = New clsOntologyItem
            objOItem_class_field.GUID = objOList_class_field.First().ID_Other
            objOItem_class_field.Name = objOList_class_field.First().Name_Other
            objOItem_class_field.GUID_Parent = objOList_class_field.First().ID_Parent_Other
            objOItem_class_field.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_class_types__elastic_search_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_types__elastic_search_".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_types__elastic_search_.Count > 0 Then
            objOItem_class_types__elastic_search_ = New clsOntologyItem
            objOItem_class_types__elastic_search_.GUID = objOList_class_types__elastic_search_.First().ID_Other
            objOItem_class_types__elastic_search_.Name = objOList_class_types__elastic_search_.First().Name_Other
            objOItem_class_types__elastic_search_.GUID_Parent = objOList_class_types__elastic_search_.First().ID_Parent_Other
            objOItem_class_types__elastic_search_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_class_clipboardfilter_tags = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_clipboardfilter_tags".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_clipboardfilter_tags.Count > 0 Then
            objOItem_class_clipboardfilter_tags = New clsOntologyItem
            objOItem_class_clipboardfilter_tags.GUID = objOList_class_clipboardfilter_tags.First().ID_Other
            objOItem_class_clipboardfilter_tags.Name = objOList_class_clipboardfilter_tags.First().Name_Other
            objOItem_class_clipboardfilter_tags.GUID_Parent = objOList_class_clipboardfilter_tags.First().ID_Parent_Other
            objOItem_class_clipboardfilter_tags.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_class_clipboardfilter = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "class_clipboardfilter".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_class_clipboardfilter.Count > 0 Then
            objOItem_class_clipboardfilter = New clsOntologyItem
            objOItem_class_clipboardfilter.GUID = objOList_class_clipboardfilter.First().ID_Other
            objOItem_class_clipboardfilter.Name = objOList_class_clipboardfilter.First().Name_Other
            objOItem_class_clipboardfilter.GUID_Parent = objOList_class_clipboardfilter.First().ID_Parent_Other
            objOItem_class_clipboardfilter.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If


        Dim objDTMS = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_DataTypes__Ms_SQL_".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDTMS.Any() Then
            objOItem_Class_DataTypes__Ms_SQL_ = New clsOntologyItem
            objOItem_Class_DataTypes__Ms_SQL_.GUID = objDTMS.First().ID_Other
            objOItem_Class_DataTypes__Ms_SQL_.Name = objDTMS.First().Name_Other
            objOItem_Class_DataTypes__Ms_SQL_.GUID_Parent = objDTMS.First().ID_Parent_Other
            objOItem_Class_DataTypes__Ms_SQL_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objU = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_User".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objU.Any() Then
            objOItem_Class_User = New clsOntologyItem
            objOItem_Class_User.GUID = objU.First().ID_Other
            objOItem_Class_User.Name = objU.First().Name_Other
            objOItem_Class_User.GUID_Parent = objU.First().ID_Parent_Other
            objOItem_Class_User.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objVar = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Variable".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objVar.Any() Then
            objOItem_Class_Variable = New clsOntologyItem
            objOItem_Class_Variable.GUID = objVar.First().ID_Other
            objOItem_Class_Variable.Name = objVar.First().Name_Other
            objOItem_Class_Variable.GUID_Parent = objVar.First().ID_Parent_Other
            objOItem_Class_Variable.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objXML = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_XML".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objXML.Any() Then
            objOItem_Class_XML = New clsOntologyItem
            objOItem_Class_XML.GUID = objXML.First().ID_Other
            objOItem_Class_XML.Name = objXML.First().Name_Other
            objOItem_Class_XML.GUID_Parent = objXML.First().ID_Parent_Other
            objOItem_Class_XML.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objXMLC = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_XML_Config".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objXMLC.Any() Then
            objOItem_Class_XML_Config = New clsOntologyItem
            objOItem_Class_XML_Config.GUID = objXMLC.First().ID_Other
            objOItem_Class_XML_Config.Name = objXMLC.First().Name_Other
            objOItem_Class_XML_Config.GUID_Parent = objXMLC.First().ID_Parent_Other
            objOItem_Class_XML_Config.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPath = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Path".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objPath.Any() Then
            objOItem_Class_Path = New clsOntologyItem
            objOItem_Class_Path.GUID = objPath.First().ID_Other
            objOItem_Class_Path.Name = objPath.First().Name_Other
            objOItem_Class_Path.GUID_Parent = objPath.First().ID_Parent_Other
            objOItem_Class_Path.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objUrl = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Url".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objUrl.Any() Then
            objOItem_Class_Url = New clsOntologyItem
            objOItem_Class_Url.GUID = objUrl.First().ID_Other
            objOItem_Class_Url.Name = objUrl.First().Name_Other
            objOItem_Class_Url.GUID_Parent = objUrl.First().ID_Parent_Other
            objOItem_Class_Url.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPWD = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Password".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objPWD.Any() Then
            objOItem_Class_Password = New clsOntologyItem
            objOItem_Class_Password.GUID = objPWD.First().ID_Other
            objOItem_Class_Password.Name = objPWD.First().Name_Other
            objOItem_Class_Password.GUID_Parent = objPWD.First().ID_Parent_Other
            objOItem_Class_Password.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRF = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Report_Filter".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objRF.Any() Then
            objOItem_Class_Report_Filter = New clsOntologyItem
            objOItem_Class_Report_Filter.GUID = objRF.First().ID_Other
            objOItem_Class_Report_Filter.Name = objRF.First().Name_Other
            objOItem_Class_Report_Filter.GUID_Parent = objRF.First().ID_Parent_Other
            objOItem_Class_Report_Filter.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCO = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Comparison_Operators".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objCO.Any() Then
            objOItem_Class_Comparison_Operators = New clsOntologyItem
            objOItem_Class_Comparison_Operators.GUID = objCO.First().ID_Other
            objOItem_Class_Comparison_Operators.Name = objCO.First().Name_Other
            objOItem_Class_Comparison_Operators.GUID_Parent = objCO.First().ID_Parent_Other
            objOItem_Class_Comparison_Operators.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objLO = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Logical_Operators".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objLO.Any() Then
            objOItem_Class_Logical_Operators = New clsOntologyItem
            objOItem_Class_Logical_Operators.GUID = objLO.First().ID_Other
            objOItem_Class_Logical_Operators.Name = objLO.First().Name_Other
            objOItem_Class_Logical_Operators.GUID_Parent = objLO.First().ID_Parent_Other
            objOItem_Class_Logical_Operators.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRepSort = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Report_Sort".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objRepSort.Any() Then
            objOItem_Class_Report_Sort = New clsOntologyItem
            objOItem_Class_Report_Sort.GUID = objRepSort.First().ID_Other
            objOItem_Class_Report_Sort.Name = objRepSort.First().Name_Other
            objOItem_Class_Report_Sort.GUID_Parent = objRepSort.First().ID_Parent_Other
            objOItem_Class_Report_Sort.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFF = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Field_Format".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objFF.Any() Then
            objOItem_Class_Field_Format = New clsOntologyItem
            objOItem_Class_Field_Format.GUID = objFF.First().ID_Other
            objOItem_Class_Field_Format.Name = objFF.First().Name_Other
            objOItem_Class_Field_Format.GUID_Parent = objFF.First().ID_Parent_Other
            objOItem_Class_Field_Format.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDB = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Database".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDB.Any() Then
            objOItem_Class_Database = New clsOntologyItem
            objOItem_Class_Database.GUID = objDB.First().ID_Other
            objOItem_Class_Database.Name = objDB.First().Name_Other
            objOItem_Class_Database.GUID_Parent = objDB.First().ID_Parent_Other
            objOItem_Class_Database.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBoS = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Database_on_Server".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDBoS.Any() Then
            objOItem_Class_Database_on_Server = New clsOntologyItem
            objOItem_Class_Database_on_Server.GUID = objDBoS.First().ID_Other
            objOItem_Class_Database_on_Server.Name = objDBoS.First().Name_Other
            objOItem_Class_Database_on_Server.GUID_Parent = objDBoS.First().ID_Parent_Other
            objOItem_Class_Database_on_Server.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If


        Dim objServ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Server".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objServ.Any() Then
            objOItem_Class_Server = New clsOntologyItem
            objOItem_Class_Server.GUID = objServ.First().ID_Other
            objOItem_Class_Server.Name = objServ.First().Name_Other
            objOItem_Class_Server.GUID_Parent = objServ.First().ID_Parent_Other
            objOItem_Class_Server.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBP = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_DB_Procedure".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDBP.Any() Then
            objOItem_Class_DB_Procedure = New clsOntologyItem
            objOItem_Class_DB_Procedure.GUID = objDBP.First().ID_Other
            objOItem_Class_DB_Procedure.Name = objDBP.First().Name_Other
            objOItem_Class_DB_Procedure.GUID_Parent = objDBP.First().ID_Parent_Other
            objOItem_Class_DB_Procedure.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBV = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_DB_Views".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDBV.Any() Then
            objOItem_Class_DB_Views = New clsOntologyItem
            objOItem_Class_DB_Views.GUID = objDBV.First().ID_Other
            objOItem_Class_DB_Views.Name = objDBV.First().Name_Other
            objOItem_Class_DB_Views.GUID_Parent = objDBV.First().ID_Parent_Other
            objOItem_Class_DB_Views.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRep = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Reports".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objRep.Any() Then
            objOItem_Class_Reports = New clsOntologyItem
            objOItem_Class_Reports.GUID = objRep.First().ID_Other
            objOItem_Class_Reports.Name = objRep.First().Name_Other
            objOItem_Class_Reports.GUID_Parent = objRep.First().ID_Parent_Other
            objOItem_Class_Reports.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRepT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Report_Type".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objRepT.Any() Then
            objOItem_Class_Report_Type = New clsOntologyItem
            objOItem_Class_Report_Type.GUID = objRepT.First().ID_Other
            objOItem_Class_Report_Type.Name = objRepT.First().Name_Other
            objOItem_Class_Report_Type.GUID_Parent = objRepT.First().ID_Parent_Other
            objOItem_Class_Report_Type.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRepF = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Report_Field".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objRepF.Any() Then
            objOItem_Class_Report_Field = New clsOntologyItem
            objOItem_Class_Report_Field.GUID = objRepF.First().ID_Other
            objOItem_Class_Report_Field.Name = objRepF.First().Name_Other
            objOItem_Class_Report_Field.GUID_Parent = objRepF.First().ID_Parent_Other
            objOItem_Class_Report_Field.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFieldT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Field_Type".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objFieldT.Any() Then
            objOItem_Class_Field_Type = New clsOntologyItem
            objOItem_Class_Field_Type.GUID = objFieldT.First().ID_Other
            objOItem_Class_Field_Type.Name = objFieldT.First().Name_Other
            objOItem_Class_Field_Type.GUID_Parent = objFieldT.First().ID_Parent_Other
            objOItem_Class_Field_Type.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDBC = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_DB_Columns".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objDBC.Any() Then
            objOItem_Class_DB_Columns = New clsOntologyItem
            objOItem_Class_DB_Columns.GUID = objDBC.First().ID_Other
            objOItem_Class_DB_Columns.Name = objDBC.First().Name_Other
            objOItem_Class_DB_Columns.GUID_Parent = objDBC.First().ID_Parent_Other
            objOItem_Class_DB_Columns.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFile = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_File".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objFile.Any() Then
            objOItem_Class_File = New clsOntologyItem
            objOItem_Class_File.GUID = objFile.First().ID_Other
            objOItem_Class_File.Name = objFile.First().Name_Other
            objOItem_Class_File.GUID_Parent = objFile.First().ID_Parent_Other
            objOItem_Class_File.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIES = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Indexes__Elastic_Search_".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objIES.Any() Then
            objOItem_Class_Indexes__Elastic_Search_ = New clsOntologyItem
            objOItem_Class_Indexes__Elastic_Search_.GUID = objIES.First().ID_Other
            objOItem_Class_Indexes__Elastic_Search_.Name = objIES.First().Name_Other
            objOItem_Class_Indexes__Elastic_Search_.GUID_Parent = objIES.First().ID_Parent_Other
            objOItem_Class_Indexes__Elastic_Search_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objSERVP = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Server_Port".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objSERVP.Any() Then
            objOItem_Class_Server_Port = New clsOntologyItem
            objOItem_Class_Server_Port.GUID = objSERVP.First().ID_Other
            objOItem_Class_Server_Port.Name = objSERVP.First().Name_Other
            objOItem_Class_Server_Port.GUID_Parent = objSERVP.First().ID_Parent_Other
            objOItem_Class_Server_Port.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objPORT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Port".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objPORT.Any() Then
            objOItem_Class_Port = New clsOntologyItem
            objOItem_Class_Port.GUID = objPORT.First().ID_Other
            objOItem_Class_Port.Name = objPORT.First().Name_Other
            objOItem_Class_Port.GUID_Parent = objPORT.First().ID_Parent_Other
            objOItem_Class_Port.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOJ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Ontology_Join".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOJ.Any() Then
            objOItem_Class_Ontology_Join = New clsOntologyItem
            objOItem_Class_Ontology_Join.GUID = objOJ.First().ID_Other
            objOItem_Class_Ontology_Join.Name = objOJ.First().Name_Other
            objOItem_Class_Ontology_Join.GUID_Parent = objOJ.First().ID_Parent_Other
            objOItem_Class_Ontology_Join.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOI = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Type_Ontology_Item".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOI.Any() Then
            objOItem_Class_Ontology_Item = New clsOntologyItem
            objOItem_Class_Ontology_Item.GUID = objOI.First().ID_Other
            objOItem_Class_Ontology_Item.Name = objOI.First().Name_Other
            objOItem_Class_Ontology_Item.GUID_Parent = objOI.First().ID_Parent_Other
            objOItem_Class_Ontology_Item.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If
    End Sub

    Private Sub get_Config_Objects()
        Dim objOList_object_string = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "object_string".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_object_string.Count > 0 Then
            objOItem_object_string = New clsOntologyItem
            objOItem_object_string.GUID = objOList_object_string.First().ID_Other
            objOItem_object_string.Name = objOList_object_string.First().Name_Other
            objOItem_object_string.GUID_Parent = objOList_object_string.First().ID_Parent_Other
            objOItem_object_string.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_object_int = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                                   Where objOItem.ID_Object = cstrID_Ontology
                                                   Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                                   Where objRef.Name_Object.ToLower() = "object_int".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                                   Select objRef).ToList()

        If objOList_object_int.Count > 0 Then
            objOItem_object_int = New clsOntologyItem
            objOItem_object_int.GUID = objOList_object_int.First().ID_Other
            objOItem_object_int.Name = objOList_object_int.First().Name_Other
            objOItem_object_int.GUID_Parent = objOList_object_int.First().ID_Parent_Other
            objOItem_object_int.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_object_double = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                                   Where objOItem.ID_Object = cstrID_Ontology
                                                   Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                                   Where objRef.Name_Object.ToLower() = "object_double".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                                   Select objRef).ToList()

        If objOList_object_double.Count > 0 Then
            objOItem_object_double = New clsOntologyItem
            objOItem_object_double.GUID = objOList_object_double.First().ID_Other
            objOItem_object_double.Name = objOList_object_double.First().Name_Other
            objOItem_object_double.GUID_Parent = objOList_object_double.First().ID_Parent_Other
            objOItem_object_double.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_object_datetime = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                                   Where objOItem.ID_Object = cstrID_Ontology
                                                   Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                                   Where objRef.Name_Object.ToLower() = "object_datetime".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                                   Select objRef).ToList()

        If objOList_object_datetime.Count > 0 Then
            objOItem_object_datetime = New clsOntologyItem
            objOItem_object_datetime.GUID = objOList_object_datetime.First().ID_Other
            objOItem_object_datetime.Name = objOList_object_datetime.First().Name_Other
            objOItem_object_datetime.GUID_Parent = objOList_object_datetime.First().ID_Parent_Other
            objOItem_object_datetime.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_object_bit = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                                   Where objOItem.ID_Object = cstrID_Ontology
                                                   Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                                   Where objRef.Name_Object.ToLower() = "object_bit".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                                   Select objRef).ToList()

        If objOList_object_bit.Count > 0 Then
            objOItem_object_bit = New clsOntologyItem
            objOItem_object_bit.GUID = objOList_object_bit.First().ID_Other
            objOItem_object_bit.Name = objOList_object_bit.First().Name_Other
            objOItem_object_bit.GUID_Parent = objOList_object_bit.First().ID_Parent_Other
            objOItem_object_bit.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_object_commandlinerun_module = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                       Where objRef.Name_Object.ToLower() = "object_commandlinerun_module".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_object_commandlinerun_module.Count > 0 Then
            objOItem_object_commandlinerun_module = New clsOntologyItem
            objOItem_object_commandlinerun_module.GUID = objOList_object_commandlinerun_module.First().ID_Other
            objOItem_object_commandlinerun_module.Name = objOList_object_commandlinerun_module.First().Name_Other
            objOItem_object_commandlinerun_module.GUID_Parent = objOList_object_commandlinerun_module.First().ID_Parent_Other
            objOItem_object_commandlinerun_module.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_object_baseconfig = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "object_baseconfig".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_object_baseconfig.Count > 0 Then
            objOItem_object_baseconfig = New clsOntologyItem
            objOItem_object_baseconfig.GUID = objOList_object_baseconfig.First().ID_Other
            objOItem_object_baseconfig.Name = objOList_object_baseconfig.First().Name_Other
            objOItem_object_baseconfig.GUID_Parent = objOList_object_baseconfig.First().ID_Parent_Other
            objOItem_object_baseconfig.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Field_Type_DateTime".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objDT.Any() Then
            objOItem_Object_Field_Type_DateTime = New clsOntologyItem
            objOItem_Object_Field_Type_DateTime.GUID = objDT.First().ID_Other
            objOItem_Object_Field_Type_DateTime.Name = objDT.First().Name_Other
            objOItem_Object_Field_Type_DateTime.GUID_Parent = objDT.First().ID_Parent_Other
            objOItem_Object_Field_Type_DateTime.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRep = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_REPORT".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objRep.Any() Then
            objOItem_Object_Variable_REPORT = New clsOntologyItem
            objOItem_Object_Variable_REPORT.GUID = objRep.First().ID_Other
            objOItem_Object_Variable_REPORT.Name = objRep.First().Name_Other
            objOItem_Object_Variable_REPORT.GUID_Parent = objRep.First().ID_Parent_Other
            objOItem_Object_Variable_REPORT.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRep20 = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_REPORT_20".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objRep20.Any() Then
            objOItem_Object_Variable_REPORT_20 = New clsOntologyItem
            objOItem_Object_Variable_REPORT_20.GUID = objRep20.First().ID_Other
            objOItem_Object_Variable_REPORT_20.Name = objRep20.First().Name_Other
            objOItem_Object_Variable_REPORT_20.GUID_Parent = objRep20.First().ID_Parent_Other
            objOItem_Object_Variable_REPORT_20.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRowC = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_ROWCOUNT".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objRowC.Any() Then
            objOItem_Object_Variable_ROWCOUNT = New clsOntologyItem
            objOItem_Object_Variable_ROWCOUNT.GUID = objRowC.First().ID_Other
            objOItem_Object_Variable_ROWCOUNT.Name = objRowC.First().Name_Other
            objOItem_Object_Variable_ROWCOUNT.GUID_Parent = objRowC.First().ID_Parent_Other
            objOItem_Object_Variable_ROWCOUNT.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objAuth = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_AUTHOR".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objAuth.Any() Then
            objOItem_Object_Variable_AUTHOR = New clsOntologyItem
            objOItem_Object_Variable_AUTHOR.GUID = objAuth.First().ID_Other
            objOItem_Object_Variable_AUTHOR.Name = objAuth.First().Name_Other
            objOItem_Object_Variable_AUTHOR.GUID_Parent = objAuth.First().ID_Parent_Other
            objOItem_Object_Variable_AUTHOR.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objColC = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_COLCOUNT".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objColC.Any() Then
            objOItem_Object_Variable_COLCOUNT = New clsOntologyItem
            objOItem_Object_Variable_COLCOUNT.GUID = objColC.First().ID_Other
            objOItem_Object_Variable_COLCOUNT.Name = objColC.First().Name_Other
            objOItem_Object_Variable_COLCOUNT.GUID_Parent = objColC.First().ID_Parent_Other
            objOItem_Object_Variable_COLCOUNT.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objDTTZ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_DATETIME_TZ".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objDTTZ.Any() Then
            objOItem_Object_Variable_DATETIME_TZ = New clsOntologyItem
            objOItem_Object_Variable_DATETIME_TZ.GUID = objDTTZ.First().ID_Other
            objOItem_Object_Variable_DATETIME_TZ.Name = objDTTZ.First().Name_Other
            objOItem_Object_Variable_DATETIME_TZ.GUID_Parent = objDTTZ.First().ID_Parent_Other
            objOItem_Object_Variable_DATETIME_TZ.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objID = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_id".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objID.Any() Then
            objOItem_Object_Variable_id = New clsOntologyItem
            objOItem_Object_Variable_id.GUID = objID.First().ID_Other
            objOItem_Object_Variable_id.Name = objID.First().Name_Other
            objOItem_Object_Variable_id.GUID_Parent = objID.First().ID_Parent_Other
            objOItem_Object_Variable_id.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objROWN = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_ROW_NAME".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objROWN.Any() Then
            objOItem_Object_Variable_ROW_NAME = New clsOntologyItem
            objOItem_Object_Variable_ROW_NAME.GUID = objROWN.First().ID_Other
            objOItem_Object_Variable_ROW_NAME.Name = objROWN.First().Name_Other
            objOItem_Object_Variable_ROW_NAME.GUID_Parent = objROWN.First().ID_Parent_Other
            objOItem_Object_Variable_ROW_NAME.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objROWL = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_ROW_LIST".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objROWL.Any() Then
            objOItem_Object_Variable_ROW_LIST = New clsOntologyItem
            objOItem_Object_Variable_ROW_LIST.GUID = objROWL.First().ID_Other
            objOItem_Object_Variable_ROW_LIST.Name = objROWL.First().Name_Other
            objOItem_Object_Variable_ROW_LIST.GUID_Parent = objROWL.First().ID_Parent_Other
            objOItem_Object_Variable_ROW_LIST.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCELLV = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_CELL_VALUE".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objCELLV.Any() Then
            objOItem_Object_Variable_CELL_VALUE = New clsOntologyItem
            objOItem_Object_Variable_CELL_VALUE.GUID = objCELLV.First().ID_Other
            objOItem_Object_Variable_CELL_VALUE.Name = objCELLV.First().Name_Other
            objOItem_Object_Variable_CELL_VALUE.GUID_Parent = objCELLV.First().ID_Parent_Other
            objOItem_Object_Variable_CELL_VALUE.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCELLN = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_CELL_NAME".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objCELLN.Any() Then
            objOItem_Object_Variable_CELL_NAME = New clsOntologyItem
            objOItem_Object_Variable_CELL_NAME.GUID = objCELLN.First().ID_Other
            objOItem_Object_Variable_CELL_NAME.Name = objCELLN.First().Name_Other
            objOItem_Object_Variable_CELL_NAME.GUID_Parent = objCELLN.First().ID_Parent_Other
            objOItem_Object_Variable_CELL_NAME.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objCELLL = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Variable_CELL_LIST".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objCELLL.Any() Then
            objOItem_Object_Variable_CELL_LIST = New clsOntologyItem
            objOItem_Object_Variable_CELL_LIST.GUID = objCELLL.First().ID_Other
            objOItem_Object_Variable_CELL_LIST.Name = objCELLL.First().Name_Other
            objOItem_Object_Variable_CELL_LIST.GUID_Parent = objCELLL.First().ID_Parent_Other
            objOItem_Object_Variable_CELL_LIST.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRTV = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Report_Type_View".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objRTV.Any() Then
            objOItem_Object_Report_Type_View = New clsOntologyItem
            objOItem_Object_Report_Type_View.GUID = objRTV.First().ID_Other
            objOItem_Object_Report_Type_View.Name = objRTV.First().Name_Other
            objOItem_Object_Report_Type_View.GUID_Parent = objRTV.First().ID_Parent_Other
            objOItem_Object_Report_Type_View.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRTTR = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Report_Type_Token_Report".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objRTTR.Any() Then
            objOItem_Object_Report_Type_Token_Report = New clsOntologyItem
            objOItem_Object_Report_Type_Token_Report.GUID = objRTTR.First().ID_Other
            objOItem_Object_Report_Type_Token_Report.Name = objRTTR.First().Name_Other
            objOItem_Object_Report_Type_Token_Report.GUID_Parent = objRTTR.First().ID_Parent_Other
            objOItem_Object_Report_Type_Token_Report.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFTT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Field_Type_Text".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objFTT.Any() Then
            objOItem_Object_Field_Type_Text = New clsOntologyItem
            objOItem_Object_Field_Type_Text.GUID = objFTT.First().ID_Other
            objOItem_Object_Field_Type_Text.Name = objFTT.First().Name_Other
            objOItem_Object_Field_Type_Text.GUID_Parent = objFTT.First().ID_Parent_Other
            objOItem_Object_Field_Type_Text.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFTG = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Field_Type_GUID".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objFTG.Any() Then
            objOItem_Object_Field_Type_GUID = New clsOntologyItem
            objOItem_Object_Field_Type_GUID.GUID = objFTG.First().ID_Other
            objOItem_Object_Field_Type_GUID.Name = objFTG.First().Name_Other
            objOItem_Object_Field_Type_GUID.GUID_Parent = objFTG.First().ID_Parent_Other
            objOItem_Object_Field_Type_GUID.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objFTZ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Field_Type_Zahl".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objFTZ.Any() Then
            objOItem_Object_Field_Type_Zahl = New clsOntologyItem
            objOItem_Object_Field_Type_Zahl.GUID = objFTZ.First().ID_Other
            objOItem_Object_Field_Type_Zahl.Name = objFTZ.First().Name_Other
            objOItem_Object_Field_Type_Zahl.GUID_Parent = objFTZ.First().ID_Parent_Other
            objOItem_Object_Field_Type_Zahl.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If



        Dim objESV = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Report_Type_ElasticView".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objESV.Any() Then
            objOItem_Object_Report_Type_ElasticView = New clsOntologyItem
            objOItem_Object_Report_Type_ElasticView.GUID = objESV.First().ID_Other
            objOItem_Object_Report_Type_ElasticView.Name = objESV.First().Name_Other
            objOItem_Object_Report_Type_ElasticView.GUID_Parent = objESV.First().ID_Parent_Other
            objOItem_Object_Report_Type_ElasticView.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objROJ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Ontology_Relation_Rule_Right_Outer_Join".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objROJ.Any() Then
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.GUID = objROJ.First().ID_Other
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.Name = objROJ.First().Name_Other
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.GUID_Parent = objROJ.First().ID_Parent_Other
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRELB = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Ontology_Relation_Rule_Relation_Break".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objRELB.Any() Then
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.GUID = objRELB.First().ID_Other
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.Name = objRELB.First().Name_Other
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.GUID_Parent = objRELB.First().ID_Parent_Other
            objOItem_Object_Ontology_Relation_Rule_Right_Outer_Join.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objRPT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Ontology_Relation_Rule_Parent_Types".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objRPT.Any() Then
            objOItem_Object_Ontology_Relation_Rule_Parent_Types = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Parent_Types.GUID = objRPT.First().ID_Other
            objOItem_Object_Ontology_Relation_Rule_Parent_Types.Name = objRPT.First().Name_Other
            objOItem_Object_Ontology_Relation_Rule_Parent_Types.GUID_Parent = objRPT.First().ID_Parent_Other
            objOItem_Object_Ontology_Relation_Rule_Parent_Types.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objROI = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Ontology_Relation_Rule_Only_Item".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objROI.Any() Then
            objOItem_Object_Ontology_Relation_Rule_Only_Item = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Only_Item.GUID = objROI.First().ID_Other
            objOItem_Object_Ontology_Relation_Rule_Only_Item.Name = objROI.First().Name_Other
            objOItem_Object_Ontology_Relation_Rule_Only_Item.GUID_Parent = objROI.First().ID_Parent_Other
            objOItem_Object_Ontology_Relation_Rule_Only_Item.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


        Dim objNoTP = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Ontology_Relation_Rule_Name_of_Type_Parse".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objNoTP.Any() Then
            objOItem_Object_Ontology_Relation_Rule_Name_of_Type_Parse = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Name_of_Type_Parse.GUID = objNoTP.First().ID_Other
            objOItem_Object_Ontology_Relation_Rule_Name_of_Type_Parse.Name = objNoTP.First().Name_Other
            objOItem_Object_Ontology_Relation_Rule_Name_of_Type_Parse.GUID_Parent = objNoTP.First().ID_Parent_Other
            objOItem_Object_Ontology_Relation_Rule_Name_of_Type_Parse.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


        Dim objLOJ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Ontology_Relation_Rule_Left_Outer_Join".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objLOJ.Any() Then
            objOItem_Object_Ontology_Relation_Rule_Left_Outer_Join = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Left_Outer_Join.GUID = objLOJ.First().ID_Other
            objOItem_Object_Ontology_Relation_Rule_Left_Outer_Join.Name = objLOJ.First().Name_Other
            objOItem_Object_Ontology_Relation_Rule_Left_Outer_Join.GUID_Parent = objLOJ.First().ID_Parent_Other
            objOItem_Object_Ontology_Relation_Rule_Left_Outer_Join.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objIJ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Ontology_Relation_Rule_Inner_Join".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objIJ.Any() Then
            objOItem_Object_Ontology_Relation_Rule_Inner_Join = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Inner_Join.GUID = objIJ.First().ID_Other
            objOItem_Object_Ontology_Relation_Rule_Inner_Join.Name = objIJ.First().Name_Other
            objOItem_Object_Ontology_Relation_Rule_Inner_Join.GUID_Parent = objIJ.First().ID_Parent_Other
            objOItem_Object_Ontology_Relation_Rule_Inner_Join.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


        Dim objCT = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "Token_Ontology_Relation_Rule_Child_Token".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objCT.Any() Then
            objOItem_Object_Ontology_Relation_Rule_Child_Token = New clsOntologyItem
            objOItem_Object_Ontology_Relation_Rule_Child_Token.GUID = objCT.First().ID_Other
            objOItem_Object_Ontology_Relation_Rule_Child_Token.Name = objCT.First().Name_Other
            objOItem_Object_Ontology_Relation_Rule_Child_Token.GUID_Parent = objCT.First().ID_Parent_Other
            objOItem_Object_Ontology_Relation_Rule_Child_Token.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
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
    '        objOItem_DevConfig.GUID = objDBLevel_Config1.OList_ObjectRel_ID.First().ID_Other
    '        objOItem_DevConfig.Name = objDBLevel_Config1.OList_ObjectRel_ID.First().Name_Other
    '        objOItem_DevConfig.GUID_Parent = objDBLevel_Config1.OList_ObjectRel_ID.First().ID_Parent_Other
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
End Class
