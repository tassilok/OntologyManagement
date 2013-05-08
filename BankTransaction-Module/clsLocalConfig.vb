﻿Imports Ontolog_Module
Public Class clsLocalConfig
    Private cstr_ID_SoftwareDevelopment As String = "ecb262a919674ee8964fca531b3253cf"
    Private cstr_ID_Class_SoftwareDevelopment As String = "132a845f849f4f6b86847ab3fd068824"
    Private cstr_ID_Class_DevelopmentConfig As String = "c6c9bcb80ac947139417eeec1453026c"
    Private cstr_ID_Class_ConfigItem As String = "13c09f11175c4eefbc8a0fd8e86d557f"
    Private cstr_ID_RelType_needs As String = "fafc1464815f45969737bcbc96bd744a"
    Private cstr_ID_RelType_contains As String = "e971160347db44d8a476fe88290639a4"
    Private cstr_ID_RelType_belongsTo As String = "e07469d9766c443e85266d9c684f944f"

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

        get_Config()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Config1 = New clsDBLevel(objGlobals)
        objDBLevel_Config2 = New clsDBLevel(objGlobals)
    End Sub

    Private Sub get_Config()

        get_Data_DevelopmentConfig()

        get_Config_AttributeTypes()
        get_Config_RelationTypes()
        get_Config_Classes()
        get_Config_Objects()

    End Sub

    Private Sub get_Config_AttributeTypes()
        Dim objOList_attribute_beg_nstigter_zahlungspflichtiger = From obj In objDBLevel_Config2.OList_ObjectRel
                                  Where obj.Name_Object.ToLower = "attribute_beg_nstigter_zahlungspflichtiger" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_beg_nstigter_zahlungspflichtiger.Count > 0 Then
            objOItem_attribute_beg_nstigter_zahlungspflichtiger = New clsOntologyItem
            objOItem_attribute_beg_nstigter_zahlungspflichtiger.GUID = objOList_attribute_beg_nstigter_zahlungspflichtiger(0).ID_Other
            objOItem_attribute_beg_nstigter_zahlungspflichtiger.Name = objOList_attribute_beg_nstigter_zahlungspflichtiger(0).Name_Other
            objOItem_attribute_beg_nstigter_zahlungspflichtiger.GUID_Parent = objOList_attribute_beg_nstigter_zahlungspflichtiger(0).ID_Parent_Other
            objOItem_attribute_beg_nstigter_zahlungspflichtiger.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_betrag = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_betrag" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_betrag.Count > 0 Then
            objOItem_attribute_betrag = New clsOntologyItem
            objOItem_attribute_betrag.GUID = objOList_attribute_betrag(0).ID_Other
            objOItem_attribute_betrag.Name = objOList_attribute_betrag(0).Name_Other
            objOItem_attribute_betrag.GUID_Parent = objOList_attribute_betrag(0).ID_Parent_Other
            objOItem_attribute_betrag.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_buchungstext = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_buchungstext" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_buchungstext.Count > 0 Then
            objOItem_attribute_buchungstext = New clsOntologyItem
            objOItem_attribute_buchungstext.GUID = objOList_attribute_buchungstext(0).ID_Other
            objOItem_attribute_buchungstext.Name = objOList_attribute_buchungstext(0).Name_Other
            objOItem_attribute_buchungstext.GUID_Parent = objOList_attribute_buchungstext(0).ID_Parent_Other
            objOItem_attribute_buchungstext.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_dbpostfix = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_dbpostfix" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_dbpostfix.Count > 0 Then
            objOItem_attribute_dbpostfix = New clsOntologyItem
            objOItem_attribute_dbpostfix.GUID = objOList_attribute_dbpostfix(0).ID_Other
            objOItem_attribute_dbpostfix.Name = objOList_attribute_dbpostfix(0).Name_Other
            objOItem_attribute_dbpostfix.GUID_Parent = objOList_attribute_dbpostfix(0).ID_Parent_Other
            objOItem_attribute_dbpostfix.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_first_line_col_header = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_first_line_col_header" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_first_line_col_header.Count > 0 Then
            objOItem_attribute_first_line_col_header = New clsOntologyItem
            objOItem_attribute_first_line_col_header.GUID = objOList_attribute_first_line_col_header(0).ID_Other
            objOItem_attribute_first_line_col_header.Name = objOList_attribute_first_line_col_header(0).Name_Other
            objOItem_attribute_first_line_col_header.GUID_Parent = objOList_attribute_first_line_col_header(0).ID_Parent_Other
            objOItem_attribute_first_line_col_header.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_info = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_info" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_info.Count > 0 Then
            objOItem_attribute_info = New clsOntologyItem
            objOItem_attribute_info.GUID = objOList_attribute_info(0).ID_Other
            objOItem_attribute_info.Name = objOList_attribute_info(0).Name_Other
            objOItem_attribute_info.GUID_Parent = objOList_attribute_info(0).ID_Parent_Other
            objOItem_attribute_info.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_start = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_start" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_start.Count > 0 Then
            objOItem_attribute_start = New clsOntologyItem
            objOItem_attribute_start.GUID = objOList_attribute_start(0).ID_Other
            objOItem_attribute_start.Name = objOList_attribute_start(0).Name_Other
            objOItem_attribute_start.GUID_Parent = objOList_attribute_start(0).ID_Parent_Other
            objOItem_attribute_start.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_valutatag = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_valutatag" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_valutatag.Count > 0 Then
            objOItem_attribute_valutatag = New clsOntologyItem
            objOItem_attribute_valutatag.GUID = objOList_attribute_valutatag(0).ID_Other
            objOItem_attribute_valutatag.Name = objOList_attribute_valutatag(0).Name_Other
            objOItem_attribute_valutatag.GUID_Parent = objOList_attribute_valutatag(0).ID_Parent_Other
            objOItem_attribute_valutatag.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_verwendungszweck = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_verwendungszweck" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_verwendungszweck.Count > 0 Then
            objOItem_attribute_verwendungszweck = New clsOntologyItem
            objOItem_attribute_verwendungszweck.GUID = objOList_attribute_verwendungszweck(0).ID_Other
            objOItem_attribute_verwendungszweck.Name = objOList_attribute_verwendungszweck(0).Name_Other
            objOItem_attribute_verwendungszweck.GUID_Parent = objOList_attribute_verwendungszweck(0).ID_Parent_Other
            objOItem_attribute_verwendungszweck.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_zahlungsausgang = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_zahlungsausgang" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_zahlungsausgang.Count > 0 Then
            objOItem_attribute_zahlungsausgang = New clsOntologyItem
            objOItem_attribute_zahlungsausgang.GUID = objOList_attribute_zahlungsausgang(0).ID_Other
            objOItem_attribute_zahlungsausgang.Name = objOList_attribute_zahlungsausgang(0).Name_Other
            objOItem_attribute_zahlungsausgang.GUID_Parent = objOList_attribute_zahlungsausgang(0).ID_Parent_Other
            objOItem_attribute_zahlungsausgang.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_RelationTypes()
        Dim objOList_relationtype_auftragskonto = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "relationtype_auftragskonto" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_auftragskonto.Count > 0 Then
            objOItem_relationtype_auftragskonto = New clsOntologyItem
            objOItem_relationtype_auftragskonto.GUID = objOList_relationtype_auftragskonto(0).ID_Other
            objOItem_relationtype_auftragskonto.Name = objOList_relationtype_auftragskonto(0).Name_Other
            objOItem_relationtype_auftragskonto.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belonging" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belonging.Count > 0 Then
            objOItem_relationtype_belonging = New clsOntologyItem
            objOItem_relationtype_belonging.GUID = objOList_relationtype_belonging(0).ID_Other
            objOItem_relationtype_belonging.Name = objOList_relationtype_belonging(0).Name_Other
            objOItem_relationtype_belonging.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_banks = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belonging_banks" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belonging_banks.Count > 0 Then
            objOItem_relationtype_belonging_banks = New clsOntologyItem
            objOItem_relationtype_belonging_banks.GUID = objOList_relationtype_belonging_banks(0).ID_Other
            objOItem_relationtype_belonging_banks.Name = objOList_relationtype_belonging_banks(0).Name_Other
            objOItem_relationtype_belonging_banks.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belongsto = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belongsto" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belongsto.Count > 0 Then
            objOItem_relationtype_belongsto = New clsOntologyItem
            objOItem_relationtype_belongsto.GUID = objOList_relationtype_belongsto(0).ID_Other
            objOItem_relationtype_belongsto.Name = objOList_relationtype_belongsto(0).Name_Other
            objOItem_relationtype_belongsto.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_gegenkonto = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_gegenkonto" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_gegenkonto.Count > 0 Then
            objOItem_relationtype_gegenkonto = New clsOntologyItem
            objOItem_relationtype_gegenkonto.GUID = objOList_relationtype_gegenkonto(0).ID_Other
            objOItem_relationtype_gegenkonto.Name = objOList_relationtype_gegenkonto(0).Name_Other
            objOItem_relationtype_gegenkonto.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_imports_from = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_imports_from" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_imports_from.Count > 0 Then
            objOItem_relationtype_imports_from = New clsOntologyItem
            objOItem_relationtype_imports_from.GUID = objOList_relationtype_imports_from(0).ID_Other
            objOItem_relationtype_imports_from.Name = objOList_relationtype_imports_from(0).Name_Other
            objOItem_relationtype_imports_from.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_log_of = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_log_of" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_log_of.Count > 0 Then
            objOItem_relationtype_log_of = New clsOntologyItem
            objOItem_relationtype_log_of.GUID = objOList_relationtype_log_of(0).ID_Other
            objOItem_relationtype_log_of.Name = objOList_relationtype_log_of(0).Name_Other
            objOItem_relationtype_log_of.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_offered_by = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_offered_by" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_offered_by.Count > 0 Then
            objOItem_relationtype_offered_by = New clsOntologyItem
            objOItem_relationtype_offered_by.GUID = objOList_relationtype_offered_by(0).ID_Other
            objOItem_relationtype_offered_by.Name = objOList_relationtype_offered_by(0).Name_Other
            objOItem_relationtype_offered_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_offers = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_offers" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_offers.Count > 0 Then
            objOItem_relationtype_offers = New clsOntologyItem
            objOItem_relationtype_offers.GUID = objOList_relationtype_offers(0).ID_Other
            objOItem_relationtype_offers.Name = objOList_relationtype_offers(0).Name_Other
            objOItem_relationtype_offers.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_provides = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_provides" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_provides.Count > 0 Then
            objOItem_relationtype_provides = New clsOntologyItem
            objOItem_relationtype_provides.GUID = objOList_relationtype_provides(0).ID_Other
            objOItem_relationtype_provides.Name = objOList_relationtype_provides(0).Name_Other
            objOItem_relationtype_provides.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_was_finished_with = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_was_finished_with" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_was_finished_with.Count > 0 Then
            objOItem_relationtype_was_finished_with = New clsOntologyItem
            objOItem_relationtype_was_finished_with.GUID = objOList_relationtype_was_finished_with(0).ID_Other
            objOItem_relationtype_was_finished_with.Name = objOList_relationtype_was_finished_with(0).Name_Other
            objOItem_relationtype_was_finished_with.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_works_with = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_works_with" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_works_with.Count > 0 Then
            objOItem_relationtype_works_with = New clsOntologyItem
            objOItem_relationtype_works_with.GUID = objOList_relationtype_works_with(0).ID_Other
            objOItem_relationtype_works_with.Name = objOList_relationtype_works_with(0).Name_Other
            objOItem_relationtype_works_with.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_zugeh_rige_mandanten = From obj In objDBLevel_Config2.OList_ObjectRel
                    Where obj.Name_Object.ToLower = "relationtype_zugeh_rige_mandanten" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_zugeh_rige_mandanten.Count > 0 Then
            objOItem_RelationType_zugeh_rige_Mandanten = New clsOntologyItem
            objOItem_RelationType_zugeh_rige_Mandanten.GUID = objOList_relationtype_zugeh_rige_mandanten(0).ID_Other
            objOItem_RelationType_zugeh_rige_Mandanten.Name = objOList_relationtype_zugeh_rige_mandanten(0).Name_Other
            objOItem_RelationType_zugeh_rige_Mandanten.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

    End Sub

    Private Sub get_Config_Objects()
        Dim objOList_token_logstate_config_error = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "token_logstate_config_error" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_logstate_config_error.Count > 0 Then
            objOItem_token_logstate_config_error = New clsOntologyItem
            objOItem_token_logstate_config_error.GUID = objOList_token_logstate_config_error(0).ID_Other
            objOItem_token_logstate_config_error.Name = objOList_token_logstate_config_error(0).Name_Other
            objOItem_token_logstate_config_error.GUID_Parent = objOList_token_logstate_config_error(0).ID_Parent_Other
            objOItem_token_logstate_config_error.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_Classes()
        Dim objOList_type_alternate_currency_name = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "type_alternate_currency_name" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_alternate_currency_name.Count > 0 Then
            objOItem_type_alternate_currency_name = New clsOntologyItem
            objOItem_type_alternate_currency_name.GUID = objOList_type_alternate_currency_name(0).ID_Other
            objOItem_type_alternate_currency_name.Name = objOList_type_alternate_currency_name(0).Name_Other
            objOItem_type_alternate_currency_name.GUID_Parent = objOList_type_alternate_currency_name(0).ID_Parent_Other
            objOItem_type_alternate_currency_name.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_bank_transaction_module = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_bank_transaction_module" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_bank_transaction_module.Count > 0 Then
            objOItem_type_bank_transaction_module = New clsOntologyItem
            objOItem_type_bank_transaction_module.GUID = objOList_type_bank_transaction_module(0).ID_Other
            objOItem_type_bank_transaction_module.Name = objOList_type_bank_transaction_module(0).Name_Other
            objOItem_type_bank_transaction_module.GUID_Parent = objOList_type_bank_transaction_module(0).ID_Parent_Other
            objOItem_type_bank_transaction_module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_bank_transaktionen__sparkasse_ = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_bank_transaktionen__sparkasse_" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_bank_transaktionen__sparkasse_.Count > 0 Then
            objOItem_type_bank_transaktionen__sparkasse_ = New clsOntologyItem
            objOItem_type_bank_transaktionen__sparkasse_.GUID = objOList_type_bank_transaktionen__sparkasse_(0).ID_Other
            objOItem_type_bank_transaktionen__sparkasse_.Name = objOList_type_bank_transaktionen__sparkasse_(0).Name_Other
            objOItem_type_bank_transaktionen__sparkasse_.GUID_Parent = objOList_type_bank_transaktionen__sparkasse_(0).ID_Parent_Other
            objOItem_type_bank_transaktionen__sparkasse_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_bank_transaktionen__sparkasse____archiv = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_bank_transaktionen__sparkasse____archiv" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_bank_transaktionen__sparkasse____archiv.Count > 0 Then
            objOItem_type_bank_transaktionen__sparkasse____archiv = New clsOntologyItem
            objOItem_type_bank_transaktionen__sparkasse____archiv.GUID = objOList_type_bank_transaktionen__sparkasse____archiv(0).ID_Other
            objOItem_type_bank_transaktionen__sparkasse____archiv.Name = objOList_type_bank_transaktionen__sparkasse____archiv(0).Name_Other
            objOItem_type_bank_transaktionen__sparkasse____archiv.GUID_Parent = objOList_type_bank_transaktionen__sparkasse____archiv(0).ID_Parent_Other
            objOItem_type_bank_transaktionen__sparkasse____archiv.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_bankleitzahl = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_bankleitzahl" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_bankleitzahl.Count > 0 Then
            objOItem_type_bankleitzahl = New clsOntologyItem
            objOItem_type_bankleitzahl.GUID = objOList_type_bankleitzahl(0).ID_Other
            objOItem_type_bankleitzahl.Name = objOList_type_bankleitzahl(0).Name_Other
            objOItem_type_bankleitzahl.GUID_Parent = objOList_type_bankleitzahl(0).ID_Parent_Other
            objOItem_type_bankleitzahl.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_currencies = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_currencies" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_currencies.Count > 0 Then
            objOItem_type_currencies = New clsOntologyItem
            objOItem_type_currencies.GUID = objOList_type_currencies(0).ID_Other
            objOItem_type_currencies.Name = objOList_type_currencies(0).Name_Other
            objOItem_type_currencies.GUID_Parent = objOList_type_currencies(0).ID_Parent_Other
            objOItem_type_currencies.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_file = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_file" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_file.Count > 0 Then
            objOItem_type_file = New clsOntologyItem
            objOItem_type_file.GUID = objOList_type_file(0).ID_Other
            objOItem_type_file.Name = objOList_type_file(0).Name_Other
            objOItem_type_file.GUID_Parent = objOList_type_file(0).ID_Parent_Other
            objOItem_type_file.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_financial_transaction___archive = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_financial_transaction___archive" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_financial_transaction___archive.Count > 0 Then
            objOItem_type_financial_transaction___archive = New clsOntologyItem
            objOItem_type_financial_transaction___archive.GUID = objOList_type_financial_transaction___archive(0).ID_Other
            objOItem_type_financial_transaction___archive.Name = objOList_type_financial_transaction___archive(0).Name_Other
            objOItem_type_financial_transaction___archive.GUID_Parent = objOList_type_financial_transaction___archive(0).ID_Parent_Other
            objOItem_type_financial_transaction___archive.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_import_settings = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_import_settings" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_import_settings.Count > 0 Then
            objOItem_type_import_settings = New clsOntologyItem
            objOItem_type_import_settings.GUID = objOList_type_import_settings(0).ID_Other
            objOItem_type_import_settings.Name = objOList_type_import_settings(0).Name_Other
            objOItem_type_import_settings.GUID_Parent = objOList_type_import_settings(0).ID_Parent_Other
            objOItem_type_import_settings.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_imports = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_imports" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_imports.Count > 0 Then
            objOItem_type_imports = New clsOntologyItem
            objOItem_type_imports.GUID = objOList_type_imports(0).ID_Other
            objOItem_type_imports.Name = objOList_type_imports(0).Name_Other
            objOItem_type_imports.GUID_Parent = objOList_type_imports(0).ID_Parent_Other
            objOItem_type_imports.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_kontodaten = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_kontodaten" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_kontodaten.Count > 0 Then
            objOItem_type_kontodaten = New clsOntologyItem
            objOItem_type_kontodaten.GUID = objOList_type_kontodaten(0).ID_Other
            objOItem_type_kontodaten.Name = objOList_type_kontodaten(0).Name_Other
            objOItem_type_kontodaten.GUID_Parent = objOList_type_kontodaten(0).ID_Parent_Other
            objOItem_type_kontodaten.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_kontonummer = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_kontonummer" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_kontonummer.Count > 0 Then
            objOItem_type_kontonummer = New clsOntologyItem
            objOItem_type_kontonummer.GUID = objOList_type_kontonummer(0).ID_Other
            objOItem_type_kontonummer.Name = objOList_type_kontonummer(0).Name_Other
            objOItem_type_kontonummer.GUID_Parent = objOList_type_kontonummer(0).ID_Parent_Other
            objOItem_type_kontonummer.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_logentry = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_logentry" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_logentry.Count > 0 Then
            objOItem_type_logentry = New clsOntologyItem
            objOItem_type_logentry.GUID = objOList_type_logentry(0).ID_Other
            objOItem_type_logentry.Name = objOList_type_logentry(0).Name_Other
            objOItem_type_logentry.GUID_Parent = objOList_type_logentry(0).ID_Parent_Other
            objOItem_type_logentry.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_module = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_module" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_module.Count > 0 Then
            objOItem_type_module = New clsOntologyItem
            objOItem_type_module.GUID = objOList_type_module(0).ID_Other
            objOItem_type_module.Name = objOList_type_module(0).Name_Other
            objOItem_type_module.GUID_Parent = objOList_type_module(0).ID_Parent_Other
            objOItem_type_module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_payment = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_payment" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_payment.Count > 0 Then
            objOItem_type_payment = New clsOntologyItem
            objOItem_type_payment.GUID = objOList_type_payment(0).ID_Other
            objOItem_type_payment.Name = objOList_type_payment(0).Name_Other
            objOItem_type_payment.GUID_Parent = objOList_type_payment(0).ID_Parent_Other
            objOItem_type_payment.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_text_qualifier = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_text_qualifier" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_text_qualifier.Count > 0 Then
            objOItem_type_text_qualifier = New clsOntologyItem
            objOItem_type_text_qualifier.GUID = objOList_type_text_qualifier(0).ID_Other
            objOItem_type_text_qualifier.Name = objOList_type_text_qualifier(0).Name_Other
            objOItem_type_text_qualifier.GUID_Parent = objOList_type_text_qualifier(0).ID_Parent_Other
            objOItem_type_text_qualifier.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_text_seperators = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_text_seperators" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_text_seperators.Count > 0 Then
            objOItem_type_text_seperators = New clsOntologyItem
            objOItem_type_text_seperators.GUID = objOList_type_text_seperators(0).ID_Other
            objOItem_type_text_seperators.Name = objOList_type_text_seperators(0).Name_Other
            objOItem_type_text_seperators.GUID_Parent = objOList_type_text_seperators(0).ID_Parent_Other
            objOItem_type_text_seperators.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If


    End Sub
End Class
