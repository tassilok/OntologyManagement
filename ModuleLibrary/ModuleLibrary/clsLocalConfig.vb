Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports System.Reflection
Public Class clsLocalConfig
    Private objImport As clsImport

    Private cstrID_Ontology As String = "14b08ac522714e7c87e36701bf744cbc"

    Private objGlobals As clsGlobals

    Private objOItem_DevConfig As New clsOntologyItem

    Private objDBLevel_Config1 As clsDBLevel
    Private objDBLevel_Config2 As clsDBLevel

    Private objOItem_Type_Year As New clsOntologyItem
    Private objOItem_Type_Volumen As New clsOntologyItem
    Private objOItem_Type_Partner As New clsOntologyItem
    Private objOItem_Type_Month As New clsOntologyItem
    Private objOItem_Type_Menge As New clsOntologyItem
    Private objOItem_Type_Fl_che As New clsOntologyItem
    Private objOItem_Type_Einheit As New clsOntologyItem
    Private objOItem_Type_Day As New clsOntologyItem
    Private objOItem_RelationType_z As New clsOntologyItem
    Private objOItem_RelationType_y As New clsOntologyItem
    Private objOItem_RelationType_x As New clsOntologyItem
    Private objOItem_RelationType_is_of_Type As New clsOntologyItem
    Private objOItem_Attribute_Menge As New clsOntologyItem
    Private objOItem_Attribute_ID As New clsOntologyItem
    Private objOItem_attribute_dbPostfix As New clsOntologyItem


    Public ReadOnly Property OItem_Type_Year() As clsOntologyItem
        Get
            Return objOItem_Type_Year
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Volumen() As clsOntologyItem
        Get
            Return objOItem_Type_Volumen
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Partner() As clsOntologyItem
        Get
            Return objOItem_Type_Partner
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Month() As clsOntologyItem
        Get
            Return objOItem_Type_Month
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Menge() As clsOntologyItem
        Get
            Return objOItem_Type_Menge
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Fl_che() As clsOntologyItem
        Get
            Return objOItem_Type_Fl_che
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Einheit() As clsOntologyItem
        Get
            Return objOItem_Type_Einheit
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Day() As clsOntologyItem
        Get
            Return objOItem_Type_Day
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_z() As clsOntologyItem
        Get
            Return objOItem_RelationType_z
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_y() As clsOntologyItem
        Get
            Return objOItem_RelationType_y
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_x() As clsOntologyItem
        Get
            Return objOItem_RelationType_x
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_is_of_Type() As clsOntologyItem
        Get
            Return objOItem_RelationType_is_of_Type
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Menge() As clsOntologyItem
        Get
            Return objOItem_Attribute_Menge
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_ID() As clsOntologyItem
        Get
            Return objOItem_Attribute_ID
        End Get
    End Property

    Public ReadOnly Property OItem_attribute_dbPostfix() As clsOntologyItem
        Get
            Return objOItem_attribute_dbPostfix
        End Get
    End Property



    Private Sub get_Data_DevelopmentConfig()
        Dim objORL_Ontology_To_OntolgyItems = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = cstrID_Ontology, _
                                                                                             .ID_RelationType = objGlobals.RelationType_contains.GUID, _
                                                                                             .ID_Parent_Other = objGlobals.Class_OntologyItems.GUID}}



        Dim objOItem_Result = objDBLevel_Config1.get_Data_ObjectRel(objORL_Ontology_To_OntolgyItems, boolIDs:=False)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            If objDBLevel_Config1.OList_ObjectRel.Any Then

                objORL_Ontology_To_OntolgyItems = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objGlobals.Class_OntologyItems.GUID, _
                                                                                                     .ID_RelationType = objGlobals.RelationType_belongingAttribute.GUID},
                                                                              New clsObjectRel With {.ID_Parent_Object = objGlobals.Class_OntologyItems.GUID, _
                                                                                                     .ID_RelationType = objGlobals.RelationType_belongingClass.GUID},
                                                                             New clsObjectRel With {.ID_Parent_Object = objGlobals.Class_OntologyItems.GUID, _
                                                                                                     .ID_RelationType = objGlobals.RelationType_belongingObject.GUID},
                                                                              New clsObjectRel With {.ID_Parent_Object = objGlobals.Class_OntologyItems.GUID, _
                                                                                                     .ID_RelationType = objGlobals.RelationType_belongingRelationType.GUID}}

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
                Else
                    Err.Raise(1, "Config not importable")
                End If
            Else
                Environment.Exit(0)
            End If

        End Try

    End Sub

    Private Sub get_Config_AttributeTypes()
        Dim objOList_attribute_menge = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_menge".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_menge.Any() Then
            objOItem_attribute_menge = New clsOntologyItem
            objOItem_attribute_menge.GUID = objOList_attribute_menge.First().ID_Other
            objOItem_attribute_menge.Name = objOList_attribute_menge.First().Name_Other
            objOItem_attribute_menge.GUID_Parent = objOList_attribute_menge.First().ID_Parent_Other
            objOItem_attribute_menge.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_id = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_id".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_id.Any() Then
            objOItem_attribute_id = New clsOntologyItem
            objOItem_attribute_id.GUID = objOList_attribute_id.First().ID_Other
            objOItem_attribute_id.Name = objOList_attribute_id.First().Name_Other
            objOItem_attribute_id.GUID_Parent = objOList_attribute_id.First().ID_Parent_Other
            objOItem_attribute_id.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_dbpostfix = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_dbpostfix".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_dbpostfix.Any() Then
            objOItem_attribute_dbpostfix = New clsOntologyItem
            objOItem_attribute_dbpostfix.GUID = objOList_attribute_dbpostfix.First().ID_Other
            objOItem_attribute_dbpostfix.Name = objOList_attribute_dbpostfix.First().Name_Other
            objOItem_attribute_dbpostfix.GUID_Parent = objOList_attribute_dbpostfix.First().ID_Parent_Other
            objOItem_attribute_dbpostfix.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_RelationTypes()
        Dim objOList_relationtype_z = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_z".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_z.Any() Then
            objOItem_relationtype_z = New clsOntologyItem
            objOItem_relationtype_z.GUID = objOList_relationtype_z.First().ID_Other
            objOItem_relationtype_z.Name = objOList_relationtype_z.First().Name_Other
            objOItem_relationtype_z.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_y = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_y".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_y.Any() Then
            objOItem_relationtype_y = New clsOntologyItem
            objOItem_relationtype_y.GUID = objOList_relationtype_y.First().ID_Other
            objOItem_relationtype_y.Name = objOList_relationtype_y.First().Name_Other
            objOItem_relationtype_y.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_x = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_x".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_x.Any() Then
            objOItem_relationtype_x = New clsOntologyItem
            objOItem_relationtype_x.GUID = objOList_relationtype_x.First().ID_Other
            objOItem_relationtype_x.Name = objOList_relationtype_x.First().Name_Other
            objOItem_relationtype_x.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_is_of_type = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_is_of_type".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_is_of_type.Any() Then
            objOItem_relationtype_is_of_type = New clsOntologyItem
            objOItem_relationtype_is_of_type.GUID = objOList_relationtype_is_of_type.First().ID_Other
            objOItem_relationtype_is_of_type.Name = objOList_relationtype_is_of_type.First().Name_Other
            objOItem_relationtype_is_of_type.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_Objects()

    End Sub

    Private Sub get_Config_Classes()
        Dim objOList_type_year = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_year".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_year.Any() Then
            objOItem_type_year = New clsOntologyItem
            objOItem_type_year.GUID = objOList_type_year.First().ID_Other
            objOItem_type_year.Name = objOList_type_year.First().Name_Other
            objOItem_type_year.GUID_Parent = objOList_type_year.First().ID_Parent_Other
            objOItem_type_year.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_volumen = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_volumen".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_volumen.Any() Then
            objOItem_type_volumen = New clsOntologyItem
            objOItem_type_volumen.GUID = objOList_type_volumen.First().ID_Other
            objOItem_type_volumen.Name = objOList_type_volumen.First().Name_Other
            objOItem_type_volumen.GUID_Parent = objOList_type_volumen.First().ID_Parent_Other
            objOItem_type_volumen.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_partner = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_partner".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_partner.Any() Then
            objOItem_type_partner = New clsOntologyItem
            objOItem_type_partner.GUID = objOList_type_partner.First().ID_Other
            objOItem_type_partner.Name = objOList_type_partner.First().Name_Other
            objOItem_type_partner.GUID_Parent = objOList_type_partner.First().ID_Parent_Other
            objOItem_type_partner.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_month = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_month".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_month.Any() Then
            objOItem_type_month = New clsOntologyItem
            objOItem_type_month.GUID = objOList_type_month.First().ID_Other
            objOItem_type_month.Name = objOList_type_month.First().Name_Other
            objOItem_type_month.GUID_Parent = objOList_type_month.First().ID_Parent_Other
            objOItem_type_month.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_menge = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_menge".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_menge.Any() Then
            objOItem_type_menge = New clsOntologyItem
            objOItem_type_menge.GUID = objOList_type_menge.First().ID_Other
            objOItem_type_menge.Name = objOList_type_menge.First().Name_Other
            objOItem_type_menge.GUID_Parent = objOList_type_menge.First().ID_Parent_Other
            objOItem_type_menge.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_fl_che = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_fl_che".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_fl_che.Any() Then
            objOItem_type_fl_che = New clsOntologyItem
            objOItem_type_fl_che.GUID = objOList_type_fl_che.First().ID_Other
            objOItem_type_fl_che.Name = objOList_type_fl_che.First().Name_Other
            objOItem_type_fl_che.GUID_Parent = objOList_type_fl_che.First().ID_Parent_Other
            objOItem_type_fl_che.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_einheit = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_einheit".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_einheit.Any() Then
            objOItem_type_einheit = New clsOntologyItem
            objOItem_type_einheit.GUID = objOList_type_einheit.First().ID_Other
            objOItem_type_einheit.Name = objOList_type_einheit.First().Name_Other
            objOItem_type_einheit.GUID_Parent = objOList_type_einheit.First().ID_Parent_Other
            objOItem_type_einheit.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_day = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_day".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_day.Any() Then
            objOItem_type_day = New clsOntologyItem
            objOItem_type_day.GUID = objOList_type_day.First().ID_Other
            objOItem_type_day.Name = objOList_type_day.First().Name_Other
            objOItem_type_day.GUID_Parent = objOList_type_day.First().ID_Parent_Other
            objOItem_type_day.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If


    End Sub
End Class
