﻿Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports System.Reflection
Public Class clsLocalConfig
    Private Const cstrID_Ontology As String = "0c5596776b634fc3a9e63858758c8e57"

    Private objGlobals As clsGlobals

    Private objOItem_DevConfig As New clsOntologyItem

    Private objDBLevel_Config1 As clsDBLevel
    Private objDBLevel_Config2 As clsDBLevel

    Private objDBLevel_FamilienStand As clsDBLevel
    Private objDBLevel_Geschlecht As clsDBLevel

    Private objImport As clsImport

    'Attributes
    Private objOItem_attribute_dbPostfix As New clsOntologyItem
    Private objOItem_Attribute_eTin As New clsOntologyItem
    Private objOItem_Attribute_Geburtsdatum As New clsOntologyItem
    Private objOItem_Attribute_Identifkationsnummer__IdNr_ As New clsOntologyItem
    Private objOItem_Attribute_Nach_Vereinbarung As New clsOntologyItem
    Private objOItem_Attribute_Nachname As New clsOntologyItem
    Private objOItem_Attribute_Postfach As New clsOntologyItem
    Private objOItem_Attribute_Sozialversicherungsnummer As New clsOntologyItem
    Private objOItem_Attribute_Straße As New clsOntologyItem
    Private objOItem_Attribute_Timestamp__from_ As New clsOntologyItem
    Private objOItem_Attribute_Timestamp__To_ As New clsOntologyItem
    Private objOItem_Attribute_Todesdatum As New clsOntologyItem
    Private objOItem_Attribute_Vorname As New clsOntologyItem
    Private objOItem_Attribute_Zusatz As New clsOntologyItem

    'RelationTypes
    Private objOItem_RelationType_belonging As New clsOntologyItem
    Private objOItem_RelationType_belonging_photo As New clsOntologyItem
    Private objOItem_RelationType_belongsTo As New clsOntologyItem
    Private objOItem_RelationType_contact As New clsOntologyItem
    Private objOItem_RelationType_contains As New clsOntologyItem
    Private objOItem_RelationType_Fax As New clsOntologyItem
    Private objOItem_RelationType_has As New clsOntologyItem
    Private objOItem_RelationType_isInState As New clsOntologyItem
    Private objOItem_RelationType_located_in As New clsOntologyItem
    Private objOItem_RelationType_needs As New clsOntologyItem
    Private objOItem_RelationType_offered_by As New clsOntologyItem
    Private objOItem_RelationType_Sitz As New clsOntologyItem
    Private objOItem_RelationType_Tel As New clsOntologyItem

    'Classes
    Private objOItem_Class_Address As New clsOntologyItem
    Private objOItem_Class_Availabilities As New clsOntologyItem
    Private objOItem_Class_Availability_Data As New clsOntologyItem
    Private objOItem_Class_eMail_Address As New clsOntologyItem
    Private objOItem_Class_eTin As New clsOntologyItem
    Private objOItem_Class_Familienstand As New clsOntologyItem
    Private objOItem_Class_Geschlecht As New clsOntologyItem
    Private objOItem_Class_Identifkationsnummer__IdNr_ As New clsOntologyItem
    Private objOItem_Class_Images__Graphic_ As New clsOntologyItem
    Private objOItem_Class_Kommunikationsangaben As New clsOntologyItem
    Private objOItem_Class_Land As New clsOntologyItem
    Private objOItem_Class_Module As New clsOntologyItem
    Private objOItem_Class_nat_rliche_Person As New clsOntologyItem
    Private objOItem_Class_Ort As New clsOntologyItem
    Private objOItem_Class_Partner As New clsOntologyItem
    Private objOItem_Class_Partner_Module As New clsOntologyItem
    Private objOItem_Class_Postleitzahl As New clsOntologyItem
    Private objOItem_Class_Sozialversicherungsnummer As New clsOntologyItem
    Private objOItem_Class_Steuernummer As New clsOntologyItem
    Private objOItem_Class_Telefonnummer As New clsOntologyItem
    Private objOItem_Class_Url As New clsOntologyItem
    Private objOItem_Class_Web_Service As New clsOntologyItem
    Private objOItem_Class_Weekdays As New clsOntologyItem

    'Objects
    Private objOItem_object_partner_management As New clsOntologyItem


    'Attributes
    Public ReadOnly Property OItem_attribute_dbPostfix() As clsOntologyItem
        Get
            Return objOItem_attribute_dbPostfix
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_eTin() As clsOntologyItem
        Get
            Return objOItem_Attribute_eTin
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Geburtsdatum() As clsOntologyItem
        Get
            Return objOItem_Attribute_Geburtsdatum
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Identifkationsnummer__IdNr_() As clsOntologyItem
        Get
            Return objOItem_Attribute_Identifkationsnummer__IdNr_
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Nach_Vereinbarung() As clsOntologyItem
        Get
            Return objOItem_Attribute_Nach_Vereinbarung
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Nachname() As clsOntologyItem
        Get
            Return objOItem_Attribute_Nachname
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Postfach() As clsOntologyItem
        Get
            Return objOItem_Attribute_Postfach
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Sozialversicherungsnummer() As clsOntologyItem
        Get
            Return objOItem_Attribute_Sozialversicherungsnummer
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Straße() As clsOntologyItem
        Get
            Return objOItem_Attribute_Straße
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Timestamp__from_() As clsOntologyItem
        Get
            Return objOItem_Attribute_Timestamp__from_
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Timestamp__To_() As clsOntologyItem
        Get
            Return objOItem_Attribute_Timestamp__To_
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Todesdatum() As clsOntologyItem
        Get
            Return objOItem_Attribute_Todesdatum
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Vorname() As clsOntologyItem
        Get
            Return objOItem_Attribute_Vorname
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Zusatz() As clsOntologyItem
        Get
            Return objOItem_Attribute_Zusatz
        End Get
    End Property


    'RelationTypes
    Public ReadOnly Property OItem_RelationType_belonging() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_photo() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_photo
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belongsTo() As clsOntologyItem
        Get
            Return objOItem_RelationType_belongsTo
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_contact() As clsOntologyItem
        Get
            Return objOItem_RelationType_contact
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_contains() As clsOntologyItem
        Get
            Return objOItem_RelationType_contains
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_Fax() As clsOntologyItem
        Get
            Return objOItem_RelationType_Fax
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_has() As clsOntologyItem
        Get
            Return objOItem_RelationType_has
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_isInState() As clsOntologyItem
        Get
            Return objOItem_RelationType_isInState
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_located_in() As clsOntologyItem
        Get
            Return objOItem_RelationType_located_in
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_needs() As clsOntologyItem
        Get
            Return objOItem_RelationType_needs
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_offered_by() As clsOntologyItem
        Get
            Return objOItem_RelationType_offered_by
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_Sitz() As clsOntologyItem
        Get
            Return objOItem_RelationType_Sitz
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_Tel() As clsOntologyItem
        Get
            Return objOItem_RelationType_Tel
        End Get
    End Property

    'Classes
    Public ReadOnly Property OItem_Class_Address() As clsOntologyItem
        Get
            Return objOItem_Class_Address
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Availabilities() As clsOntologyItem
        Get
            Return objOItem_Class_Availabilities
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Availability_Data() As clsOntologyItem
        Get
            Return objOItem_Class_Availability_Data
        End Get
    End Property

    Public ReadOnly Property OItem_Class_eMail_Address() As clsOntologyItem
        Get
            Return objOItem_Class_eMail_Address
        End Get
    End Property

    Public ReadOnly Property OItem_Class_eTin() As clsOntologyItem
        Get
            Return objOItem_Class_eTin
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Familienstand() As clsOntologyItem
        Get
            Return objOItem_Class_Familienstand
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Geschlecht() As clsOntologyItem
        Get
            Return objOItem_Class_Geschlecht
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Identifkationsnummer__IdNr_() As clsOntologyItem
        Get
            Return objOItem_Class_Identifkationsnummer__IdNr_
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Images__Graphic_() As clsOntologyItem
        Get
            Return objOItem_Class_Images__Graphic_
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Kommunikationsangaben() As clsOntologyItem
        Get
            Return objOItem_Class_Kommunikationsangaben
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Land() As clsOntologyItem
        Get
            Return objOItem_Class_Land
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Module() As clsOntologyItem
        Get
            Return objOItem_Class_Module
        End Get
    End Property

    Public ReadOnly Property OItem_Class_nat_rliche_Person() As clsOntologyItem
        Get
            Return objOItem_Class_nat_rliche_Person
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Ort() As clsOntologyItem
        Get
            Return objOItem_Class_Ort
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Partner() As clsOntologyItem
        Get
            Return objOItem_Class_Partner
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Partner_Module() As clsOntologyItem
        Get
            Return objOItem_Class_Partner_Module
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Postleitzahl() As clsOntologyItem
        Get
            Return objOItem_Class_Postleitzahl
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Sozialversicherungsnummer() As clsOntologyItem
        Get
            Return objOItem_Class_Sozialversicherungsnummer
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Steuernummer() As clsOntologyItem
        Get
            Return objOItem_Class_Steuernummer
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Telefonnummer() As clsOntologyItem
        Get
            Return objOItem_Class_Telefonnummer
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Url() As clsOntologyItem
        Get
            Return objOItem_Class_Url
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Web_Service() As clsOntologyItem
        Get
            Return objOItem_Class_Web_Service
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Weekdays() As clsOntologyItem
        Get
            Return objOItem_Class_Weekdays
        End Get
    End Property

    Public ReadOnly Property OItem_object_partner_management() As clsOntologyItem
        Get
            Return objOItem_object_partner_management
        End Get
    End Property


    Public ReadOnly Property OList_Familienstand As List(Of clsOntologyItem)
        Get
            objDBLevel_FamilienStand.OList_Objects.Sort(Function(LS1 As clsOntologyItem, LS2 As clsOntologyItem) LS1.Name.CompareTo(LS2.Name))
            Return objDBLevel_FamilienStand.OList_Objects
        End Get
    End Property

    Public ReadOnly Property OList_Geschlecht As List(Of clsOntologyItem)
        Get
            objDBLevel_Geschlecht.OList_Objects.Sort(Function(LS1 As clsOntologyItem, LS2 As clsOntologyItem) LS1.Name.CompareTo(LS2.Name))
            Return objDBLevel_Geschlecht.OList_Objects
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
    Private Sub get_ComboData()
        Dim objOL_Familienstand As New List(Of clsOntologyItem)
        Dim objOL_Geschlecht As New List(Of clsOntologyItem)
        Dim objOItem_Result As clsOntologyItem

        objOL_Familienstand.Add(New clsOntologyItem(Nothing, _
                                                    Nothing, _
                                                    objOItem_Class_Familienstand.GUID, _
                                                    objGlobals.Type_Object))

        objOL_Geschlecht.Add(New clsOntologyItem(Nothing, _
                                                 Nothing, _
                                                 objOItem_Class_Geschlecht.GUID, _
                                                 objGlobals.Type_Object))

        objOItem_Result = objDBLevel_FamilienStand.get_Data_Objects(objOL_Familienstand)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            If objDBLevel_FamilienStand.OList_Objects.Count > 0 Then
                objOItem_Result = objDBLevel_Geschlecht.get_Data_Objects(objOL_Geschlecht)
                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    If objDBLevel_Geschlecht.OList_Objects.Count = 0 Then
                        Err.Raise(1, "Config-Error")
                    End If
                Else

                    Err.Raise(1, "Critical-Error")
                End If
            Else
                Err.Raise(1, "Config-Error")
            End If

        Else
            Err.Raise(1, "Critical-Error!")
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
        objDBLevel_FamilienStand = New clsDBLevel(objGlobals)
        objDBLevel_Geschlecht = New clsDBLevel(objGlobals)
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
        Dim objOList_attribute_dbpostfix = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_dbpostfix".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_dbpostfix.Any Then
            objOItem_attribute_dbPostfix = New clsOntologyItem
            objOItem_attribute_dbPostfix.GUID = objOList_attribute_dbpostfix.First().ID_Other
            objOItem_attribute_dbPostfix.Name = objOList_attribute_dbpostfix.First().Name_Other
            objOItem_attribute_dbPostfix.GUID_Parent = objOList_attribute_dbpostfix.First().ID_Parent_Other
            objOItem_attribute_dbPostfix.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_etin = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_etin".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_etin.Count > 0 Then
            objOItem_attribute_etin = New clsOntologyItem
            objOItem_attribute_etin.GUID = objOList_attribute_etin.First().ID_Other
            objOItem_attribute_etin.Name = objOList_attribute_etin.First().Name_Other
            objOItem_attribute_etin.GUID_Parent = objOList_attribute_etin.First().ID_Parent_Other
            objOItem_attribute_etin.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_geburtsdatum = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_geburtsdatum".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_geburtsdatum.Count > 0 Then
            objOItem_attribute_geburtsdatum = New clsOntologyItem
            objOItem_attribute_geburtsdatum.GUID = objOList_attribute_geburtsdatum.First().ID_Other
            objOItem_attribute_geburtsdatum.Name = objOList_attribute_geburtsdatum.First().Name_Other
            objOItem_attribute_geburtsdatum.GUID_Parent = objOList_attribute_geburtsdatum.First().ID_Parent_Other
            objOItem_attribute_geburtsdatum.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_identifkationsnummer__idnr_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_identifkationsnummer__idnr_".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_identifkationsnummer__idnr_.Count > 0 Then
            objOItem_attribute_identifkationsnummer__idnr_ = New clsOntologyItem
            objOItem_attribute_identifkationsnummer__idnr_.GUID = objOList_attribute_identifkationsnummer__idnr_.First().ID_Other
            objOItem_attribute_identifkationsnummer__idnr_.Name = objOList_attribute_identifkationsnummer__idnr_.First().Name_Other
            objOItem_attribute_identifkationsnummer__idnr_.GUID_Parent = objOList_attribute_identifkationsnummer__idnr_.First().ID_Parent_Other
            objOItem_attribute_identifkationsnummer__idnr_.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_nach_vereinbarung = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_nach_vereinbarung".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_nach_vereinbarung.Count > 0 Then
            objOItem_attribute_nach_vereinbarung = New clsOntologyItem
            objOItem_attribute_nach_vereinbarung.GUID = objOList_attribute_nach_vereinbarung.First().ID_Other
            objOItem_attribute_nach_vereinbarung.Name = objOList_attribute_nach_vereinbarung.First().Name_Other
            objOItem_attribute_nach_vereinbarung.GUID_Parent = objOList_attribute_nach_vereinbarung.First().ID_Parent_Other
            objOItem_attribute_nach_vereinbarung.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_nachname = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_nachname".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_nachname.Count > 0 Then
            objOItem_attribute_nachname = New clsOntologyItem
            objOItem_attribute_nachname.GUID = objOList_attribute_nachname.First().ID_Other
            objOItem_attribute_nachname.Name = objOList_attribute_nachname.First().Name_Other
            objOItem_attribute_nachname.GUID_Parent = objOList_attribute_nachname.First().ID_Parent_Other
            objOItem_attribute_nachname.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_postfach = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_postfach".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_postfach.Count > 0 Then
            objOItem_attribute_postfach = New clsOntologyItem
            objOItem_attribute_postfach.GUID = objOList_attribute_postfach.First().ID_Other
            objOItem_attribute_postfach.Name = objOList_attribute_postfach.First().Name_Other
            objOItem_attribute_postfach.GUID_Parent = objOList_attribute_postfach.First().ID_Parent_Other
            objOItem_attribute_postfach.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_sozialversicherungsnummer = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_sozialversicherungsnummer".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_sozialversicherungsnummer.Count > 0 Then
            objOItem_attribute_sozialversicherungsnummer = New clsOntologyItem
            objOItem_attribute_sozialversicherungsnummer.GUID = objOList_attribute_sozialversicherungsnummer.First().ID_Other
            objOItem_attribute_sozialversicherungsnummer.Name = objOList_attribute_sozialversicherungsnummer.First().Name_Other
            objOItem_attribute_sozialversicherungsnummer.GUID_Parent = objOList_attribute_sozialversicherungsnummer.First().ID_Parent_Other
            objOItem_attribute_sozialversicherungsnummer.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_straße = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_straße".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_straße.Count > 0 Then
            objOItem_attribute_straße = New clsOntologyItem
            objOItem_attribute_straße.GUID = objOList_attribute_straße.First().ID_Other
            objOItem_attribute_straße.Name = objOList_attribute_straße.First().Name_Other
            objOItem_attribute_straße.GUID_Parent = objOList_attribute_straße.First().ID_Parent_Other
            objOItem_attribute_straße.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_timestamp__from_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_timestamp__from_".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_timestamp__from_.Count > 0 Then
            objOItem_attribute_timestamp__from_ = New clsOntologyItem
            objOItem_attribute_timestamp__from_.GUID = objOList_attribute_timestamp__from_.First().ID_Other
            objOItem_attribute_timestamp__from_.Name = objOList_attribute_timestamp__from_.First().Name_Other
            objOItem_attribute_timestamp__from_.GUID_Parent = objOList_attribute_timestamp__from_.First().ID_Parent_Other
            objOItem_attribute_timestamp__from_.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_timestamp__to_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_timestamp__to_".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_timestamp__to_.Count > 0 Then
            objOItem_attribute_timestamp__to_ = New clsOntologyItem
            objOItem_attribute_timestamp__to_.GUID = objOList_attribute_timestamp__to_.First().ID_Other
            objOItem_attribute_timestamp__to_.Name = objOList_attribute_timestamp__to_.First().Name_Other
            objOItem_attribute_timestamp__to_.GUID_Parent = objOList_attribute_timestamp__to_.First().ID_Parent_Other
            objOItem_attribute_timestamp__to_.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_todesdatum = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_todesdatum".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_todesdatum.Count > 0 Then
            objOItem_attribute_todesdatum = New clsOntologyItem
            objOItem_attribute_todesdatum.GUID = objOList_attribute_todesdatum.First().ID_Other
            objOItem_attribute_todesdatum.Name = objOList_attribute_todesdatum.First().Name_Other
            objOItem_attribute_todesdatum.GUID_Parent = objOList_attribute_todesdatum.First().ID_Parent_Other
            objOItem_attribute_todesdatum.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_vorname = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_vorname".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_vorname.Count > 0 Then
            objOItem_attribute_vorname = New clsOntologyItem
            objOItem_attribute_vorname.GUID = objOList_attribute_vorname.First().ID_Other
            objOItem_attribute_vorname.Name = objOList_attribute_vorname.First().Name_Other
            objOItem_attribute_vorname.GUID_Parent = objOList_attribute_vorname.First().ID_Parent_Other
            objOItem_attribute_vorname.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_zusatz = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_zusatz".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_zusatz.Count > 0 Then
            objOItem_attribute_zusatz = New clsOntologyItem
            objOItem_attribute_zusatz.GUID = objOList_attribute_zusatz.First().ID_Other
            objOItem_attribute_zusatz.Name = objOList_attribute_zusatz.First().Name_Other
            objOItem_attribute_zusatz.GUID_Parent = objOList_attribute_zusatz.First().ID_Parent_Other
            objOItem_attribute_zusatz.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_RelationTypes()
        Dim objOList_relationtype_belonging = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging.Count > 0 Then
            objOItem_relationtype_belonging = New clsOntologyItem
            objOItem_relationtype_belonging.GUID = objOList_relationtype_belonging.First().ID_Other
            objOItem_relationtype_belonging.Name = objOList_relationtype_belonging.First().Name_Other
            objOItem_relationtype_belonging.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_photo = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_photo".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_photo.Count > 0 Then
            objOItem_relationtype_belonging_photo = New clsOntologyItem
            objOItem_relationtype_belonging_photo.GUID = objOList_relationtype_belonging_photo.First().ID_Other
            objOItem_relationtype_belonging_photo.Name = objOList_relationtype_belonging_photo.First().Name_Other
            objOItem_relationtype_belonging_photo.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belongsto = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belongsto".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belongsto.Count > 0 Then
            objOItem_relationtype_belongsto = New clsOntologyItem
            objOItem_relationtype_belongsto.GUID = objOList_relationtype_belongsto.First().ID_Other
            objOItem_relationtype_belongsto.Name = objOList_relationtype_belongsto.First().Name_Other
            objOItem_relationtype_belongsto.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_contact = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_contact".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()
        If objOList_relationtype_contact.Count > 0 Then
            objOItem_relationtype_contact = New clsOntologyItem
            objOItem_relationtype_contact.GUID = objOList_relationtype_contact.First().ID_Other
            objOItem_relationtype_contact.Name = objOList_relationtype_contact.First().Name_Other
            objOItem_relationtype_contact.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_contains = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_contains".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_contains.Count > 0 Then
            objOItem_relationtype_contains = New clsOntologyItem
            objOItem_relationtype_contains.GUID = objOList_relationtype_contains.First().ID_Other
            objOItem_relationtype_contains.Name = objOList_relationtype_contains.First().Name_Other
            objOItem_relationtype_contains.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_fax = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_fax".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_fax.Count > 0 Then
            objOItem_relationtype_fax = New clsOntologyItem
            objOItem_relationtype_fax.GUID = objOList_relationtype_fax.First().ID_Other
            objOItem_relationtype_fax.Name = objOList_relationtype_fax.First().Name_Other
            objOItem_relationtype_fax.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_has = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_has".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()
        If objOList_relationtype_has.Count > 0 Then
            objOItem_relationtype_has = New clsOntologyItem
            objOItem_relationtype_has.GUID = objOList_relationtype_has.First().ID_Other
            objOItem_relationtype_has.Name = objOList_relationtype_has.First().Name_Other
            objOItem_relationtype_has.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_isinstate = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_isinstate".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_isinstate.Count > 0 Then
            objOItem_relationtype_isinstate = New clsOntologyItem
            objOItem_relationtype_isinstate.GUID = objOList_relationtype_isinstate.First().ID_Other
            objOItem_relationtype_isinstate.Name = objOList_relationtype_isinstate.First().Name_Other
            objOItem_relationtype_isinstate.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_located_in = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_located_in".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_located_in.Count > 0 Then
            objOItem_relationtype_located_in = New clsOntologyItem
            objOItem_relationtype_located_in.GUID = objOList_relationtype_located_in.First().ID_Other
            objOItem_relationtype_located_in.Name = objOList_relationtype_located_in.First().Name_Other
            objOItem_relationtype_located_in.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_needs = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_needs".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_needs.Count > 0 Then
            objOItem_relationtype_needs = New clsOntologyItem
            objOItem_relationtype_needs.GUID = objOList_relationtype_needs.First().ID_Other
            objOItem_relationtype_needs.Name = objOList_relationtype_needs.First().Name_Other
            objOItem_relationtype_needs.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_offered_by = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_offered_by".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_offered_by.Count > 0 Then
            objOItem_relationtype_offered_by = New clsOntologyItem
            objOItem_relationtype_offered_by.GUID = objOList_relationtype_offered_by.First().ID_Other
            objOItem_relationtype_offered_by.Name = objOList_relationtype_offered_by.First().Name_Other
            objOItem_relationtype_offered_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_sitz = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_sitz".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_sitz.Count > 0 Then
            objOItem_relationtype_sitz = New clsOntologyItem
            objOItem_relationtype_sitz.GUID = objOList_relationtype_sitz.First().ID_Other
            objOItem_relationtype_sitz.Name = objOList_relationtype_sitz.First().Name_Other
            objOItem_relationtype_sitz.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_tel = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_tel".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_tel.Count > 0 Then
            objOItem_relationtype_tel = New clsOntologyItem
            objOItem_relationtype_tel.GUID = objOList_relationtype_tel.First().ID_Other
            objOItem_relationtype_tel.Name = objOList_relationtype_tel.First().Name_Other
            objOItem_relationtype_tel.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_Objects()
        Dim objOList_object_partner_management = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "object_partner_management".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_object_partner_management.Count > 0 Then
            objOItem_Class_Address = New clsOntologyItem
            objOItem_Class_Address.GUID = objOList_object_partner_management.First().ID_Other
            objOItem_Class_Address.Name = objOList_object_partner_management.First().Name_Other
            objOItem_Class_Address.GUID_Parent = objOList_object_partner_management.First().ID_Parent_Other
            objOItem_Class_Address.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If
    End Sub

    Private Sub get_Config_Classes()
        Dim objOList_type_address = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_address".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_address.Count > 0 Then
            objOItem_Class_Address = New clsOntologyItem
            objOItem_Class_Address.GUID = objOList_type_address.First().ID_Other
            objOItem_Class_Address.Name = objOList_type_address.First().Name_Other
            objOItem_Class_Address.GUID_Parent = objOList_type_address.First().ID_Parent_Other
            objOItem_Class_Address.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_availabilities = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_availabilities".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_availabilities.Count > 0 Then
            objOItem_Class_Availabilities = New clsOntologyItem
            objOItem_Class_Availabilities.GUID = objOList_type_availabilities.First().ID_Other
            objOItem_Class_Availabilities.Name = objOList_type_availabilities.First().Name_Other
            objOItem_Class_Availabilities.GUID_Parent = objOList_type_availabilities.First().ID_Parent_Other
            objOItem_Class_Availabilities.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_availability_data = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_availability_data".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_availability_data.Count > 0 Then
            objOItem_Class_Availability_Data = New clsOntologyItem
            objOItem_Class_Availability_Data.GUID = objOList_type_availability_data.First().ID_Other
            objOItem_Class_Availability_Data.Name = objOList_type_availability_data.First().Name_Other
            objOItem_Class_Availability_Data.GUID_Parent = objOList_type_availability_data.First().ID_Parent_Other
            objOItem_Class_Availability_Data.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_email_address = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_email_address".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_email_address.Count > 0 Then
            objOItem_Class_eMail_Address = New clsOntologyItem
            objOItem_Class_eMail_Address.GUID = objOList_type_email_address.First().ID_Other
            objOItem_Class_eMail_Address.Name = objOList_type_email_address.First().Name_Other
            objOItem_Class_eMail_Address.GUID_Parent = objOList_type_email_address.First().ID_Parent_Other
            objOItem_Class_eMail_Address.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_etin = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_etin".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_etin.Count > 0 Then
            objOItem_Class_eTin = New clsOntologyItem
            objOItem_Class_eTin.GUID = objOList_type_etin.First().ID_Other
            objOItem_Class_eTin.Name = objOList_type_etin.First().Name_Other
            objOItem_Class_eTin.GUID_Parent = objOList_type_etin.First().ID_Parent_Other
            objOItem_Class_eTin.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_familienstand = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_familienstand".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_familienstand.Count > 0 Then
            objOItem_Class_Familienstand = New clsOntologyItem
            objOItem_Class_Familienstand.GUID = objOList_type_familienstand.First().ID_Other
            objOItem_Class_Familienstand.Name = objOList_type_familienstand.First().Name_Other
            objOItem_Class_Familienstand.GUID_Parent = objOList_type_familienstand.First().ID_Parent_Other
            objOItem_Class_Familienstand.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_geschlecht = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_geschlecht".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_geschlecht.Count > 0 Then
            objOItem_Class_Geschlecht = New clsOntologyItem
            objOItem_Class_Geschlecht.GUID = objOList_type_geschlecht.First().ID_Other
            objOItem_Class_Geschlecht.Name = objOList_type_geschlecht.First().Name_Other
            objOItem_Class_Geschlecht.GUID_Parent = objOList_type_geschlecht.First().ID_Parent_Other
            objOItem_Class_Geschlecht.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_identifkationsnummer__idnr_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_identifkationsnummer__idnr_".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_identifkationsnummer__idnr_.Count > 0 Then
            objOItem_Class_Identifkationsnummer__IdNr_ = New clsOntologyItem
            objOItem_Class_Identifkationsnummer__IdNr_.GUID = objOList_type_identifkationsnummer__idnr_.First().ID_Other
            objOItem_Class_Identifkationsnummer__IdNr_.Name = objOList_type_identifkationsnummer__idnr_.First().Name_Other
            objOItem_Class_Identifkationsnummer__IdNr_.GUID_Parent = objOList_type_identifkationsnummer__idnr_.First().ID_Parent_Other
            objOItem_Class_Identifkationsnummer__IdNr_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_images__graphic_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_images__graphic_".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_images__graphic_.Count > 0 Then
            objOItem_Class_Images__Graphic_ = New clsOntologyItem
            objOItem_Class_Images__Graphic_.GUID = objOList_type_images__graphic_.First().ID_Other
            objOItem_Class_Images__Graphic_.Name = objOList_type_images__graphic_.First().Name_Other
            objOItem_Class_Images__Graphic_.GUID_Parent = objOList_type_images__graphic_.First().ID_Parent_Other
            objOItem_Class_Images__Graphic_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_kommunikationsangaben = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_kommunikationsangaben".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_kommunikationsangaben.Count > 0 Then
            objOItem_Class_Kommunikationsangaben = New clsOntologyItem
            objOItem_Class_Kommunikationsangaben.GUID = objOList_type_kommunikationsangaben.First().ID_Other
            objOItem_Class_Kommunikationsangaben.Name = objOList_type_kommunikationsangaben.First().Name_Other
            objOItem_Class_Kommunikationsangaben.GUID_Parent = objOList_type_kommunikationsangaben.First().ID_Parent_Other
            objOItem_Class_Kommunikationsangaben.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_land = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_land".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_land.Count > 0 Then
            objOItem_Class_Land = New clsOntologyItem
            objOItem_Class_Land.GUID = objOList_type_land.First().ID_Other
            objOItem_Class_Land.Name = objOList_type_land.First().Name_Other
            objOItem_Class_Land.GUID_Parent = objOList_type_land.First().ID_Parent_Other
            objOItem_Class_Land.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_module = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_module".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_module.Count > 0 Then
            objOItem_Class_Module = New clsOntologyItem
            objOItem_Class_Module.GUID = objOList_type_module.First().ID_Other
            objOItem_Class_Module.Name = objOList_type_module.First().Name_Other
            objOItem_Class_Module.GUID_Parent = objOList_type_module.First().ID_Parent_Other
            objOItem_Class_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_nat_rliche_person = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_nat_rliche_person".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_nat_rliche_person.Count > 0 Then
            objOItem_Class_nat_rliche_Person = New clsOntologyItem
            objOItem_Class_nat_rliche_Person.GUID = objOList_type_nat_rliche_person.First().ID_Other
            objOItem_Class_nat_rliche_Person.Name = objOList_type_nat_rliche_person.First().Name_Other
            objOItem_Class_nat_rliche_Person.GUID_Parent = objOList_type_nat_rliche_person.First().ID_Parent_Other
            objOItem_Class_nat_rliche_Person.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_ort = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_ort".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_ort.Count > 0 Then
            objOItem_Class_Ort = New clsOntologyItem
            objOItem_Class_Ort.GUID = objOList_type_ort.First().ID_Other
            objOItem_Class_Ort.Name = objOList_type_ort.First().Name_Other
            objOItem_Class_Ort.GUID_Parent = objOList_type_ort.First().ID_Parent_Other
            objOItem_Class_Ort.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_partner = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_partner".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_partner.Count > 0 Then
            objOItem_Class_Partner = New clsOntologyItem
            objOItem_Class_Partner.GUID = objOList_type_partner.First().ID_Other
            objOItem_Class_Partner.Name = objOList_type_partner.First().Name_Other
            objOItem_Class_Partner.GUID_Parent = objOList_type_partner.First().ID_Parent_Other
            objOItem_Class_Partner.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_partner_module = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_partner_module".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_partner_module.Count > 0 Then
            objOItem_Class_Partner_Module = New clsOntologyItem
            objOItem_Class_Partner_Module.GUID = objOList_type_partner_module.First().ID_Other
            objOItem_Class_Partner_Module.Name = objOList_type_partner_module.First().Name_Other
            objOItem_Class_Partner_Module.GUID_Parent = objOList_type_partner_module.First().ID_Parent_Other
            objOItem_Class_Partner_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_postleitzahl = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_postleitzahl".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_postleitzahl.Count > 0 Then
            objOItem_Class_Postleitzahl = New clsOntologyItem
            objOItem_Class_Postleitzahl.GUID = objOList_type_postleitzahl.First().ID_Other
            objOItem_Class_Postleitzahl.Name = objOList_type_postleitzahl.First().Name_Other
            objOItem_Class_Postleitzahl.GUID_Parent = objOList_type_postleitzahl.First().ID_Parent_Other
            objOItem_Class_Postleitzahl.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_sozialversicherungsnummer = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_sozialversicherungsnummer".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_sozialversicherungsnummer.Count > 0 Then
            objOItem_Class_Sozialversicherungsnummer = New clsOntologyItem
            objOItem_Class_Sozialversicherungsnummer.GUID = objOList_type_sozialversicherungsnummer.First().ID_Other
            objOItem_Class_Sozialversicherungsnummer.Name = objOList_type_sozialversicherungsnummer.First().Name_Other
            objOItem_Class_Sozialversicherungsnummer.GUID_Parent = objOList_type_sozialversicherungsnummer.First().ID_Parent_Other
            objOItem_Class_Sozialversicherungsnummer.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_steuernummer = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_steuernummer".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_steuernummer.Count > 0 Then
            objOItem_Class_Steuernummer = New clsOntologyItem
            objOItem_Class_Steuernummer.GUID = objOList_type_steuernummer.First().ID_Other
            objOItem_Class_Steuernummer.Name = objOList_type_steuernummer.First().Name_Other
            objOItem_Class_Steuernummer.GUID_Parent = objOList_type_steuernummer.First().ID_Parent_Other
            objOItem_Class_Steuernummer.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_telefonnummer = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_telefonnummer".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_telefonnummer.Count > 0 Then
            objOItem_Class_Telefonnummer = New clsOntologyItem
            objOItem_Class_Telefonnummer.GUID = objOList_type_telefonnummer.First().ID_Other
            objOItem_Class_Telefonnummer.Name = objOList_type_telefonnummer.First().Name_Other
            objOItem_Class_Telefonnummer.GUID_Parent = objOList_type_telefonnummer.First().ID_Parent_Other
            objOItem_Class_Telefonnummer.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_url = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_url".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_url.Count > 0 Then
            objOItem_Class_Url = New clsOntologyItem
            objOItem_Class_Url.GUID = objOList_type_url.First().ID_Other
            objOItem_Class_Url.Name = objOList_type_url.First().Name_Other
            objOItem_Class_Url.GUID_Parent = objOList_type_url.First().ID_Parent_Other
            objOItem_Class_Url.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_web_service = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_web_service".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_web_service.Count > 0 Then
            objOItem_Class_Web_Service = New clsOntologyItem
            objOItem_Class_Web_Service.GUID = objOList_type_web_service.First().ID_Other
            objOItem_Class_Web_Service.Name = objOList_type_web_service.First().Name_Other
            objOItem_Class_Web_Service.GUID_Parent = objOList_type_web_service.First().ID_Parent_Other
            objOItem_Class_Web_Service.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_weekdays = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_weekdays".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_weekdays.Count > 0 Then
            objOItem_Class_Weekdays = New clsOntologyItem
            objOItem_Class_Weekdays.GUID = objOList_type_weekdays.First().ID_Other
            objOItem_Class_Weekdays.Name = objOList_type_weekdays.First().Name_Other
            objOItem_Class_Weekdays.GUID_Parent = objOList_type_weekdays.First().ID_Parent_Other
            objOItem_Class_Weekdays.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If


    End Sub
End Class

