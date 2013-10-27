Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports System.Reflection
Public Class clsLocalConfig
    Private objImport As clsImport

    Private cstrID_Ontology As String = "d5e19fadd515463da05a4812c19bb72a"

    Private objGlobals As clsGlobals

    Private objOItem_DevConfig As New clsOntologyItem

    Private objDBLevel_Config1 As clsDBLevel
    Private objDBLevel_Config2 As clsDBLevel

    'Attributes
    Private objOItem_Attribute_Beg_nstigter_Zahlungspflichtiger As New clsOntologyItem
    Private objOItem_Attribute_Betrag As New clsOntologyItem
    Private objOItem_Attribute_Buchungstext As New clsOntologyItem
    Private objOItem_attribute_dbPostfix As New clsOntologyItem
    Private objOItem_Attribute_First_Line_Col_Header As New clsOntologyItem
    Private objOItem_Attribute_Info As New clsOntologyItem
    Private objOItem_Attribute_Start As New clsOntologyItem
    Private objOItem_Attribute_Valutatag As New clsOntologyItem
    Private objOItem_Attribute_Verwendungszweck As New clsOntologyItem
    Private objOItem_Attribute_Zahlungsausgang As New clsOntologyItem

    'RelationTypes
    Private objOItem_RelationType_Auftragskonto As New clsOntologyItem
    Private objOItem_RelationType_belonging As New clsOntologyItem
    Private objOItem_RelationType_belonging_Banks As New clsOntologyItem
    Private objOItem_RelationType_belongsTo As New clsOntologyItem
    Private objOItem_RelationType_Gegenkonto As New clsOntologyItem
    Private objOItem_RelationType_imports_from As New clsOntologyItem
    Private objOItem_RelationType_Log_of As New clsOntologyItem
    Private objOItem_RelationType_offered_by As New clsOntologyItem
    Private objOItem_RelationType_offers As New clsOntologyItem
    Private objOItem_RelationType_provides As New clsOntologyItem
    Private objOItem_RelationType_was_finished_with As New clsOntologyItem
    Private objOItem_RelationType_works_with As New clsOntologyItem
    Private objOItem_RelationType_zugeh_rige_Mandanten As New clsOntologyItem
    Private objOItem_RelationType_contains As New clsOntologyItem
    Private objOItem_RelationType_is As New clsOntologyItem
    Private objOItem_RelationType_belonging_Type As New clsOntologyItem
    Private objOItem_RelationType_belonging_Token As New clsOntologyItem
    Private objOItem_RelationType_belonging_RelationType As New clsOntologyItem
    Private objOItem_RelationType_belonging_Attribute As New clsOntologyItem


    'Objects
    Private objOItem_Token_Logstate_Config_Error As New clsOntologyItem

    'Classes
    Private objOItem_Type_Alternate_Currency_Name As New clsOntologyItem
    Private objOItem_Type_Bank_Transaction_Module As New clsOntologyItem
    Private objOItem_Type_Bank_Transaktionen__Sparkasse_ As New clsOntologyItem
    Private objOItem_Type_Bank_Transaktionen__Sparkasse____Archiv As New clsOntologyItem
    Private objOItem_Type_Bankleitzahl As New clsOntologyItem
    Private objOItem_Type_Currencies As New clsOntologyItem
    Private objOItem_Type_File As New clsOntologyItem
    Private objOItem_Type_Financial_Transaction___Archive As New clsOntologyItem
    Private objOItem_Type_Import_Settings As New clsOntologyItem
    Private objOItem_Type_Imports As New clsOntologyItem
    Private objOItem_Type_Kontodaten As New clsOntologyItem
    Private objOItem_Type_Kontonummer As New clsOntologyItem
    Private objOItem_Type_LogEntry As New clsOntologyItem
    Private objOItem_Type_Module As New clsOntologyItem
    Private objOItem_Type_Payment As New clsOntologyItem
    Private objOItem_Type_Text_Qualifier As New clsOntologyItem
    Private objOItem_Type_Text_Seperators As New clsOntologyItem
    Private objOItem_Type_Report_Field As New clsOntologyItem
    Private objOItem_Type_Ontology_Join As New clsOntologyItem
    Private objOItem_Type_Ontology_Item As New clsOntologyItem
    Private objOItem_Type_Partner As New clsOntologyItem


    'Attributes
    Public ReadOnly Property OItem_Attribute_Beg_nstigter_Zahlungspflichtiger() As clsOntologyItem
        Get
            Return objOItem_Attribute_Beg_nstigter_Zahlungspflichtiger
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Betrag() As clsOntologyItem
        Get
            Return objOItem_Attribute_Betrag
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Buchungstext() As clsOntologyItem
        Get
            Return objOItem_Attribute_Buchungstext
        End Get
    End Property

    Public ReadOnly Property OItem_attribute_dbPostfix() As clsOntologyItem
        Get
            Return objOItem_attribute_dbPostfix
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_First_Line_Col_Header() As clsOntologyItem
        Get
            Return objOItem_Attribute_First_Line_Col_Header
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Info() As clsOntologyItem
        Get
            Return objOItem_Attribute_Info
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Start() As clsOntologyItem
        Get
            Return objOItem_Attribute_Start
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Valutatag() As clsOntologyItem
        Get
            Return objOItem_Attribute_Valutatag
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Verwendungszweck() As clsOntologyItem
        Get
            Return objOItem_Attribute_Verwendungszweck
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Zahlungsausgang() As clsOntologyItem
        Get
            Return objOItem_Attribute_Zahlungsausgang
        End Get
    End Property

    'RelationTypes
    Public ReadOnly Property OItem_RelationType_Auftragskonto() As clsOntologyItem
        Get
            Return objOItem_RelationType_Auftragskonto
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Banks() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Banks
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belongsTo() As clsOntologyItem
        Get
            Return objOItem_RelationType_belongsTo
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_Gegenkonto() As clsOntologyItem
        Get
            Return objOItem_RelationType_Gegenkonto
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_imports_from() As clsOntologyItem
        Get
            Return objOItem_RelationType_imports_from
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_Log_of() As clsOntologyItem
        Get
            Return objOItem_RelationType_Log_of
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_offered_by() As clsOntologyItem
        Get
            Return objOItem_RelationType_offered_by
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_offers() As clsOntologyItem
        Get
            Return objOItem_RelationType_offers
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_provides() As clsOntologyItem
        Get
            Return objOItem_RelationType_provides
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_was_finished_with() As clsOntologyItem
        Get
            Return objOItem_RelationType_was_finished_with
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_works_with() As clsOntologyItem
        Get
            Return objOItem_RelationType_works_with
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_zugeh_rige_Mandanten() As clsOntologyItem
        Get
            Return objOItem_RelationType_zugeh_rige_Mandanten
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_contains() As clsOntologyItem
        Get
            Return objOItem_RelationType_contains
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_is() As clsOntologyItem
        Get
            Return objOItem_RelationType_is
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Type() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Type
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Token() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Token
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_RelationType() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_RelationType
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Attribute() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Attribute
        End Get
    End Property


    'Objects
    Public ReadOnly Property OItem_Token_Logstate_Config_Error() As clsOntologyItem
        Get
            Return objOItem_Token_Logstate_Config_Error
        End Get
    End Property

    'Classes
    Public ReadOnly Property OItem_Type_Alternate_Currency_Name() As clsOntologyItem
        Get
            Return objOItem_Type_Alternate_Currency_Name
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Bank_Transaction_Module() As clsOntologyItem
        Get
            Return objOItem_Type_Bank_Transaction_Module
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Bank_Transaktionen__Sparkasse_() As clsOntologyItem
        Get
            Return objOItem_Type_Bank_Transaktionen__Sparkasse_
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Bank_Transaktionen__Sparkasse____Archiv() As clsOntologyItem
        Get
            Return objOItem_Type_Bank_Transaktionen__Sparkasse____Archiv
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Bankleitzahl() As clsOntologyItem
        Get
            Return objOItem_Type_Bankleitzahl
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Currencies() As clsOntologyItem
        Get
            Return objOItem_Type_Currencies
        End Get
    End Property

    Public ReadOnly Property OItem_Type_File() As clsOntologyItem
        Get
            Return objOItem_Type_File
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Financial_Transaction___Archive() As clsOntologyItem
        Get
            Return objOItem_Type_Financial_Transaction___Archive
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Import_Settings() As clsOntologyItem
        Get
            Return objOItem_Type_Import_Settings
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Imports() As clsOntologyItem
        Get
            Return objOItem_Type_Imports
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Kontodaten() As clsOntologyItem
        Get
            Return objOItem_Type_Kontodaten
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Kontonummer() As clsOntologyItem
        Get
            Return objOItem_Type_Kontonummer
        End Get
    End Property

    Public ReadOnly Property OItem_Type_LogEntry() As clsOntologyItem
        Get
            Return objOItem_Type_LogEntry
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Module() As clsOntologyItem
        Get
            Return objOItem_Type_Module
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Payment() As clsOntologyItem
        Get
            Return objOItem_Type_Payment
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Text_Qualifier() As clsOntologyItem
        Get
            Return objOItem_Type_Text_Qualifier
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Text_Seperators() As clsOntologyItem
        Get
            Return objOItem_Type_Text_Seperators
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Report_Field() As clsOntologyItem
        Get
            Return objOItem_Type_Report_Field
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Ontology_Join() As clsOntologyItem
        Get
            Return objOItem_Type_Ontology_Join
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Ontology_Item() As clsOntologyItem
        Get
            Return objOItem_Type_Ontology_Item
        End Get
    End Property

    Public ReadOnly Property OItem_Type_Partner() As clsOntologyItem
        Get
            Return objOItem_Type_Partner
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
        Dim objOList_attribute_beg_nstigter_zahlungspflichtiger = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_beg_nstigter_zahlungspflichtiger".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_beg_nstigter_zahlungspflichtiger.Any() Then
            objOItem_attribute_beg_nstigter_zahlungspflichtiger = New clsOntologyItem
            objOItem_attribute_beg_nstigter_zahlungspflichtiger.GUID = objOList_attribute_beg_nstigter_zahlungspflichtiger.First().ID_Other
            objOItem_attribute_beg_nstigter_zahlungspflichtiger.Name = objOList_attribute_beg_nstigter_zahlungspflichtiger.First().Name_Other
            objOItem_attribute_beg_nstigter_zahlungspflichtiger.GUID_Parent = objOList_attribute_beg_nstigter_zahlungspflichtiger.First().ID_Parent_Other
            objOItem_attribute_beg_nstigter_zahlungspflichtiger.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_betrag = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_betrag".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_betrag.Any() Then
            objOItem_attribute_betrag = New clsOntologyItem
            objOItem_attribute_betrag.GUID = objOList_attribute_betrag.First().ID_Other
            objOItem_attribute_betrag.Name = objOList_attribute_betrag.First().Name_Other
            objOItem_attribute_betrag.GUID_Parent = objOList_attribute_betrag.First().ID_Parent_Other
            objOItem_attribute_betrag.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_buchungstext = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_buchungstext".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_buchungstext.Any() Then
            objOItem_attribute_buchungstext = New clsOntologyItem
            objOItem_attribute_buchungstext.GUID = objOList_attribute_buchungstext.First().ID_Other
            objOItem_attribute_buchungstext.Name = objOList_attribute_buchungstext.First().Name_Other
            objOItem_attribute_buchungstext.GUID_Parent = objOList_attribute_buchungstext.First().ID_Parent_Other
            objOItem_attribute_buchungstext.Type = objGlobals.Type_AttributeType
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

        Dim objOList_attribute_first_line_col_header = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_first_line_col_header".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_first_line_col_header.Any() Then
            objOItem_attribute_first_line_col_header = New clsOntologyItem
            objOItem_attribute_first_line_col_header.GUID = objOList_attribute_first_line_col_header.First().ID_Other
            objOItem_attribute_first_line_col_header.Name = objOList_attribute_first_line_col_header.First().Name_Other
            objOItem_attribute_first_line_col_header.GUID_Parent = objOList_attribute_first_line_col_header.First().ID_Parent_Other
            objOItem_attribute_first_line_col_header.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_info = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_info".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_info.Any() Then
            objOItem_attribute_info = New clsOntologyItem
            objOItem_attribute_info.GUID = objOList_attribute_info.First().ID_Other
            objOItem_attribute_info.Name = objOList_attribute_info.First().Name_Other
            objOItem_attribute_info.GUID_Parent = objOList_attribute_info.First().ID_Parent_Other
            objOItem_attribute_info.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_start = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_start".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_start.Any() Then
            objOItem_attribute_start = New clsOntologyItem
            objOItem_attribute_start.GUID = objOList_attribute_start.First().ID_Other
            objOItem_attribute_start.Name = objOList_attribute_start.First().Name_Other
            objOItem_attribute_start.GUID_Parent = objOList_attribute_start.First().ID_Parent_Other
            objOItem_attribute_start.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_valutatag = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_valutatag".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_valutatag.Any() Then
            objOItem_attribute_valutatag = New clsOntologyItem
            objOItem_attribute_valutatag.GUID = objOList_attribute_valutatag.First().ID_Other
            objOItem_attribute_valutatag.Name = objOList_attribute_valutatag.First().Name_Other
            objOItem_attribute_valutatag.GUID_Parent = objOList_attribute_valutatag.First().ID_Parent_Other
            objOItem_attribute_valutatag.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_verwendungszweck = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_verwendungszweck".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_verwendungszweck.Any() Then
            objOItem_attribute_verwendungszweck = New clsOntologyItem
            objOItem_attribute_verwendungszweck.GUID = objOList_attribute_verwendungszweck.First().ID_Other
            objOItem_attribute_verwendungszweck.Name = objOList_attribute_verwendungszweck.First().Name_Other
            objOItem_attribute_verwendungszweck.GUID_Parent = objOList_attribute_verwendungszweck.First().ID_Parent_Other
            objOItem_attribute_verwendungszweck.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_zahlungsausgang = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_zahlungsausgang".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_zahlungsausgang.Any() Then
            objOItem_attribute_zahlungsausgang = New clsOntologyItem
            objOItem_attribute_zahlungsausgang.GUID = objOList_attribute_zahlungsausgang.First().ID_Other
            objOItem_attribute_zahlungsausgang.Name = objOList_attribute_zahlungsausgang.First().Name_Other
            objOItem_attribute_zahlungsausgang.GUID_Parent = objOList_attribute_zahlungsausgang.First().ID_Parent_Other
            objOItem_attribute_zahlungsausgang.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_RelationTypes()
        Dim objOList_relationtype_auftragskonto = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_auftragskonto".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_auftragskonto.Any() Then
            objOItem_relationtype_auftragskonto = New clsOntologyItem
            objOItem_relationtype_auftragskonto.GUID = objOList_relationtype_auftragskonto.First().ID_Other
            objOItem_relationtype_auftragskonto.Name = objOList_relationtype_auftragskonto.First().Name_Other
            objOItem_relationtype_auftragskonto.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging.Any() Then
            objOItem_relationtype_belonging = New clsOntologyItem
            objOItem_relationtype_belonging.GUID = objOList_relationtype_belonging.First().ID_Other
            objOItem_relationtype_belonging.Name = objOList_relationtype_belonging.First().Name_Other
            objOItem_relationtype_belonging.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_banks = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_banks".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_banks.Any() Then
            objOItem_relationtype_belonging_banks = New clsOntologyItem
            objOItem_relationtype_belonging_banks.GUID = objOList_relationtype_belonging_banks.First().ID_Other
            objOItem_relationtype_belonging_banks.Name = objOList_relationtype_belonging_banks.First().Name_Other
            objOItem_relationtype_belonging_banks.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belongsto = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belongsto".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belongsto.Any() Then
            objOItem_relationtype_belongsto = New clsOntologyItem
            objOItem_relationtype_belongsto.GUID = objOList_relationtype_belongsto.First().ID_Other
            objOItem_relationtype_belongsto.Name = objOList_relationtype_belongsto.First().Name_Other
            objOItem_relationtype_belongsto.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_gegenkonto = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_gegenkonto".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_gegenkonto.Any() Then
            objOItem_relationtype_gegenkonto = New clsOntologyItem
            objOItem_relationtype_gegenkonto.GUID = objOList_relationtype_gegenkonto.First().ID_Other
            objOItem_relationtype_gegenkonto.Name = objOList_relationtype_gegenkonto.First().Name_Other
            objOItem_relationtype_gegenkonto.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_imports_from = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_imports_from".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_imports_from.Any() Then
            objOItem_relationtype_imports_from = New clsOntologyItem
            objOItem_relationtype_imports_from.GUID = objOList_relationtype_imports_from.First().ID_Other
            objOItem_relationtype_imports_from.Name = objOList_relationtype_imports_from.First().Name_Other
            objOItem_relationtype_imports_from.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_log_of = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_log_of".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_log_of.Any() Then
            objOItem_relationtype_log_of = New clsOntologyItem
            objOItem_relationtype_log_of.GUID = objOList_relationtype_log_of.First().ID_Other
            objOItem_relationtype_log_of.Name = objOList_relationtype_log_of.First().Name_Other
            objOItem_relationtype_log_of.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_offered_by = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_offered_by".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_offered_by.Any() Then
            objOItem_relationtype_offered_by = New clsOntologyItem
            objOItem_relationtype_offered_by.GUID = objOList_relationtype_offered_by.First().ID_Other
            objOItem_relationtype_offered_by.Name = objOList_relationtype_offered_by.First().Name_Other
            objOItem_relationtype_offered_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_offers = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_offers".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_offers.Any() Then
            objOItem_relationtype_offers = New clsOntologyItem
            objOItem_relationtype_offers.GUID = objOList_relationtype_offers.First().ID_Other
            objOItem_relationtype_offers.Name = objOList_relationtype_offers.First().Name_Other
            objOItem_relationtype_offers.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_provides = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_provides".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_provides.Any() Then
            objOItem_relationtype_provides = New clsOntologyItem
            objOItem_relationtype_provides.GUID = objOList_relationtype_provides.First().ID_Other
            objOItem_relationtype_provides.Name = objOList_relationtype_provides.First().Name_Other
            objOItem_relationtype_provides.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_was_finished_with = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_was_finished_with".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_was_finished_with.Any() Then
            objOItem_relationtype_was_finished_with = New clsOntologyItem
            objOItem_relationtype_was_finished_with.GUID = objOList_relationtype_was_finished_with.First().ID_Other
            objOItem_relationtype_was_finished_with.Name = objOList_relationtype_was_finished_with.First().Name_Other
            objOItem_relationtype_was_finished_with.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_works_with = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_works_with".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_works_with.Any() Then
            objOItem_relationtype_works_with = New clsOntologyItem
            objOItem_relationtype_works_with.GUID = objOList_relationtype_works_with.First().ID_Other
            objOItem_relationtype_works_with.Name = objOList_relationtype_works_with.First().Name_Other
            objOItem_relationtype_works_with.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_zugeh_rige_mandanten = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_zugeh_rige_mandanten".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_zugeh_rige_mandanten.Any() Then
            objOItem_RelationType_zugeh_rige_Mandanten = New clsOntologyItem
            objOItem_RelationType_zugeh_rige_Mandanten.GUID = objOList_relationtype_zugeh_rige_mandanten.First().ID_Other
            objOItem_RelationType_zugeh_rige_Mandanten.Name = objOList_relationtype_zugeh_rige_mandanten.First().Name_Other
            objOItem_RelationType_zugeh_rige_Mandanten.Type = objGlobals.Type_RelationType
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

        Dim objOList_relationtype_is = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_is".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_is.Any() Then
            objOItem_RelationType_is = New clsOntologyItem
            objOItem_RelationType_is.GUID = objOList_relationtype_is.First().ID_Other
            objOItem_RelationType_is.Name = objOList_relationtype_is.First().Name_Other
            objOItem_RelationType_is.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_type = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_type".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_type.Any() Then
            objOItem_RelationType_belonging_Type = New clsOntologyItem
            objOItem_RelationType_belonging_Type.GUID = objOList_relationtype_belonging_type.First().ID_Other
            objOItem_RelationType_belonging_Type.Name = objOList_relationtype_belonging_type.First().Name_Other
            objOItem_RelationType_belonging_Type.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_token = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_token".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_token.Any() Then
            objOItem_RelationType_belonging_Token = New clsOntologyItem
            objOItem_RelationType_belonging_Token.GUID = objOList_relationtype_belonging_token.First().ID_Other
            objOItem_RelationType_belonging_Token.Name = objOList_relationtype_belonging_token.First().Name_Other
            objOItem_RelationType_belonging_Token.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_relationtype = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_relationtype".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_relationtype.Any() Then
            objOItem_RelationType_belonging_RelationType = New clsOntologyItem
            objOItem_RelationType_belonging_RelationType.GUID = objOList_relationtype_belonging_relationtype.First().ID_Other
            objOItem_RelationType_belonging_RelationType.Name = objOList_relationtype_belonging_relationtype.First().Name_Other
            objOItem_RelationType_belonging_RelationType.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_attribute = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_attribute".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_attribute.Any() Then
            objOItem_RelationType_belonging_Attribute = New clsOntologyItem
            objOItem_RelationType_belonging_Attribute.GUID = objOList_relationtype_belonging_attribute.First().ID_Other
            objOItem_RelationType_belonging_Attribute.Name = objOList_relationtype_belonging_attribute.First().Name_Other
            objOItem_RelationType_belonging_Attribute.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

    End Sub

    Private Sub get_Config_Objects()
        Dim objOList_token_logstate_config_error = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_logstate_config_error".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_token_logstate_config_error.Any() Then
            objOItem_token_logstate_config_error = New clsOntologyItem
            objOItem_token_logstate_config_error.GUID = objOList_token_logstate_config_error.First().ID_Other
            objOItem_token_logstate_config_error.Name = objOList_token_logstate_config_error.First().Name_Other
            objOItem_token_logstate_config_error.GUID_Parent = objOList_token_logstate_config_error.First().ID_Parent_Other
            objOItem_token_logstate_config_error.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_Classes()

        Dim objOList_type_partner = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_partner".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_partner.Any() Then
            objOItem_Type_Partner = New clsOntologyItem
            objOItem_Type_Partner.GUID = objOList_type_partner.First().ID_Other
            objOItem_Type_Partner.Name = objOList_type_partner.First().Name_Other
            objOItem_Type_Partner.GUID_Parent = objOList_type_partner.First().ID_Parent_Other
            objOItem_Type_Partner.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_alternate_currency_name = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_alternate_currency_name".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_alternate_currency_name.Any() Then
            objOItem_Type_Alternate_Currency_Name = New clsOntologyItem
            objOItem_Type_Alternate_Currency_Name.GUID = objOList_type_alternate_currency_name.First().ID_Other
            objOItem_Type_Alternate_Currency_Name.Name = objOList_type_alternate_currency_name.First().Name_Other
            objOItem_Type_Alternate_Currency_Name.GUID_Parent = objOList_type_alternate_currency_name.First().ID_Parent_Other
            objOItem_Type_Alternate_Currency_Name.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_bank_transaction_module = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_bank_transaction_module".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_bank_transaction_module.Any() Then
            objOItem_Type_Bank_Transaction_Module = New clsOntologyItem
            objOItem_Type_Bank_Transaction_Module.GUID = objOList_type_bank_transaction_module.First().ID_Other
            objOItem_Type_Bank_Transaction_Module.Name = objOList_type_bank_transaction_module.First().Name_Other
            objOItem_Type_Bank_Transaction_Module.GUID_Parent = objOList_type_bank_transaction_module.First().ID_Parent_Other
            objOItem_Type_Bank_Transaction_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_bank_transaktionen__sparkasse_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_bank_transaktionen__sparkasse_".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_bank_transaktionen__sparkasse_.Any() Then
            objOItem_Type_Bank_Transaktionen__Sparkasse_ = New clsOntologyItem
            objOItem_Type_Bank_Transaktionen__Sparkasse_.GUID = objOList_type_bank_transaktionen__sparkasse_.First().ID_Other
            objOItem_Type_Bank_Transaktionen__Sparkasse_.Name = objOList_type_bank_transaktionen__sparkasse_.First().Name_Other
            objOItem_Type_Bank_Transaktionen__Sparkasse_.GUID_Parent = objOList_type_bank_transaktionen__sparkasse_.First().ID_Parent_Other
            objOItem_Type_Bank_Transaktionen__Sparkasse_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_bank_transaktionen__sparkasse____archiv = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_bank_transaktionen__sparkasse____archiv".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_bank_transaktionen__sparkasse____archiv.Any() Then
            objOItem_Type_Bank_Transaktionen__Sparkasse____Archiv = New clsOntologyItem
            objOItem_Type_Bank_Transaktionen__Sparkasse____Archiv.GUID = objOList_type_bank_transaktionen__sparkasse____archiv.First().ID_Other
            objOItem_Type_Bank_Transaktionen__Sparkasse____Archiv.Name = objOList_type_bank_transaktionen__sparkasse____archiv.First().Name_Other
            objOItem_Type_Bank_Transaktionen__Sparkasse____Archiv.GUID_Parent = objOList_type_bank_transaktionen__sparkasse____archiv.First().ID_Parent_Other
            objOItem_Type_Bank_Transaktionen__Sparkasse____Archiv.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_bankleitzahl = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_bankleitzahl".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_bankleitzahl.Any() Then
            objOItem_Type_Bankleitzahl = New clsOntologyItem
            objOItem_Type_Bankleitzahl.GUID = objOList_type_bankleitzahl.First().ID_Other
            objOItem_Type_Bankleitzahl.Name = objOList_type_bankleitzahl.First().Name_Other
            objOItem_Type_Bankleitzahl.GUID_Parent = objOList_type_bankleitzahl.First().ID_Parent_Other
            objOItem_Type_Bankleitzahl.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_currencies = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_currencies".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_currencies.Any() Then
            objOItem_Type_Currencies = New clsOntologyItem
            objOItem_Type_Currencies.GUID = objOList_type_currencies.First().ID_Other
            objOItem_Type_Currencies.Name = objOList_type_currencies.First().Name_Other
            objOItem_Type_Currencies.GUID_Parent = objOList_type_currencies.First().ID_Parent_Other
            objOItem_Type_Currencies.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_file = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_file".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_file.Any() Then
            objOItem_Type_File = New clsOntologyItem
            objOItem_Type_File.GUID = objOList_type_file.First().ID_Other
            objOItem_Type_File.Name = objOList_type_file.First().Name_Other
            objOItem_Type_File.GUID_Parent = objOList_type_file.First().ID_Parent_Other
            objOItem_Type_File.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_financial_transaction___archive = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_financial_transaction___archive".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_financial_transaction___archive.Any() Then
            objOItem_Type_Financial_Transaction___Archive = New clsOntologyItem
            objOItem_Type_Financial_Transaction___Archive.GUID = objOList_type_financial_transaction___archive.First().ID_Other
            objOItem_Type_Financial_Transaction___Archive.Name = objOList_type_financial_transaction___archive.First().Name_Other
            objOItem_Type_Financial_Transaction___Archive.GUID_Parent = objOList_type_financial_transaction___archive.First().ID_Parent_Other
            objOItem_Type_Financial_Transaction___Archive.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_import_settings = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_import_settings".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_import_settings.Any() Then
            objOItem_Type_Import_Settings = New clsOntologyItem
            objOItem_Type_Import_Settings.GUID = objOList_type_import_settings.First().ID_Other
            objOItem_Type_Import_Settings.Name = objOList_type_import_settings.First().Name_Other
            objOItem_Type_Import_Settings.GUID_Parent = objOList_type_import_settings.First().ID_Parent_Other
            objOItem_Type_Import_Settings.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_imports = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_imports".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_imports.Any() Then
            objOItem_Type_Imports = New clsOntologyItem
            objOItem_Type_Imports.GUID = objOList_type_imports.First().ID_Other
            objOItem_Type_Imports.Name = objOList_type_imports.First().Name_Other
            objOItem_Type_Imports.GUID_Parent = objOList_type_imports.First().ID_Parent_Other
            objOItem_Type_Imports.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_kontodaten = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_kontodaten".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_kontodaten.Any() Then
            objOItem_Type_Kontodaten = New clsOntologyItem
            objOItem_Type_Kontodaten.GUID = objOList_type_kontodaten.First().ID_Other
            objOItem_Type_Kontodaten.Name = objOList_type_kontodaten.First().Name_Other
            objOItem_Type_Kontodaten.GUID_Parent = objOList_type_kontodaten.First().ID_Parent_Other
            objOItem_Type_Kontodaten.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_kontonummer = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_kontonummer".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_kontonummer.Any() Then
            objOItem_Type_Kontonummer = New clsOntologyItem
            objOItem_Type_Kontonummer.GUID = objOList_type_kontonummer.First().ID_Other
            objOItem_Type_Kontonummer.Name = objOList_type_kontonummer.First().Name_Other
            objOItem_Type_Kontonummer.GUID_Parent = objOList_type_kontonummer.First().ID_Parent_Other
            objOItem_Type_Kontonummer.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_logentry = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_logentry".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_logentry.Any() Then
            objOItem_Type_LogEntry = New clsOntologyItem
            objOItem_Type_LogEntry.GUID = objOList_type_logentry.First().ID_Other
            objOItem_Type_LogEntry.Name = objOList_type_logentry.First().Name_Other
            objOItem_Type_LogEntry.GUID_Parent = objOList_type_logentry.First().ID_Parent_Other
            objOItem_Type_LogEntry.Type = objGlobals.Type_Class
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

        Dim objOList_type_payment = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_payment".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_payment.Any() Then
            objOItem_Type_Payment = New clsOntologyItem
            objOItem_Type_Payment.GUID = objOList_type_payment.First().ID_Other
            objOItem_Type_Payment.Name = objOList_type_payment.First().Name_Other
            objOItem_Type_Payment.GUID_Parent = objOList_type_payment.First().ID_Parent_Other
            objOItem_Type_Payment.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_text_qualifier = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_text_qualifier".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_text_qualifier.Any() Then
            objOItem_Type_Text_Qualifier = New clsOntologyItem
            objOItem_Type_Text_Qualifier.GUID = objOList_type_text_qualifier.First().ID_Other
            objOItem_Type_Text_Qualifier.Name = objOList_type_text_qualifier.First().Name_Other
            objOItem_Type_Text_Qualifier.GUID_Parent = objOList_type_text_qualifier.First().ID_Parent_Other
            objOItem_Type_Text_Qualifier.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_text_seperators = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_text_seperators".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_text_seperators.Any() Then
            objOItem_Type_Text_Seperators = New clsOntologyItem
            objOItem_Type_Text_Seperators.GUID = objOList_type_text_seperators.First().ID_Other
            objOItem_Type_Text_Seperators.Name = objOList_type_text_seperators.First().Name_Other
            objOItem_Type_Text_Seperators.GUID_Parent = objOList_type_text_seperators.First().ID_Parent_Other
            objOItem_Type_Text_Seperators.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_report_field = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_report_field".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_report_field.Any() Then
            objOItem_Type_Report_Field = New clsOntologyItem
            objOItem_Type_Report_Field.GUID = objOList_type_report_field.First().ID_Other
            objOItem_Type_Report_Field.Name = objOList_type_report_field.First().Name_Other
            objOItem_Type_Report_Field.GUID_Parent = objOList_type_report_field.First().ID_Parent_Other
            objOItem_Type_Report_Field.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_ontology_join = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_ontology_join".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_ontology_join.Any() Then
            objOItem_Type_Ontology_Join = New clsOntologyItem
            objOItem_Type_Ontology_Join.GUID = objOList_type_ontology_join.First().ID_Other
            objOItem_Type_Ontology_Join.Name = objOList_type_ontology_join.First().Name_Other
            objOItem_Type_Ontology_Join.GUID_Parent = objOList_type_ontology_join.First().ID_Parent_Other
            objOItem_Type_Ontology_Join.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_ontology_item = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_ontology_item".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_ontology_item.Any() Then
            objOItem_Type_Ontology_Item = New clsOntologyItem
            objOItem_Type_Ontology_Item.GUID = objOList_type_ontology_item.First().ID_Other
            objOItem_Type_Ontology_Item.Name = objOList_type_ontology_item.First().Name_Other
            objOItem_Type_Ontology_Item.GUID_Parent = objOList_type_ontology_item.First().ID_Parent_Other
            objOItem_Type_Ontology_Item.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

    End Sub
End Class
