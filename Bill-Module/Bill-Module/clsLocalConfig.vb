Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports System.Reflection
Public Class clsLocalConfig
    Private Const cint_ImageID_Bill As Integer = 0
    Private Const cint_ImageID_PartialBill As Integer = 1
    Private Const cint_ImageID_Position As Integer = 2
    Private Const cint_ImageID_Unzugeordnet As Integer = 3
    Private Const cint_ImageID_Mandant As Integer = 4
    Private Const cint_ImageID_Ausgaben As Integer = 5
    Private Const cint_ImageID_Einnahmen As Integer = 6
    Private Const cint_ImageID_Root As Integer = 7
    Private Const cint_ImageID_BillSelected As Integer = 8

    Private objImport As clsImport

    Private cstrID_Ontology As String = "733ae7fe72cc495b95004266edcab296"

    Private objGlobals As clsGlobals

    Private objOItem_DevConfig As New clsOntologyItem
    Private objOItem_BaseConfig As clsOntologyItem

    Private objDBLevel_Config1 As clsDBLevel
    Private objDBLevel_Config2 As clsDBLevel

    'Attributes
    Private objOItem_Attribute_Amount As New clsOntologyItem
    Private objOItem_Attribute_Beg_nstigter_Zahlungspflichtiger As New clsOntologyItem
    Private objOItem_Attribute_Betrag As New clsOntologyItem
    Private objOItem_attribute_dbPostfix As New clsOntologyItem
    Private objOItem_Attribute_gross As New clsOntologyItem
    Private objOItem_Attribute_Gross__Standard_ As New clsOntologyItem
    Private objOItem_Attribute_Menge As New clsOntologyItem
    Private objOItem_Attribute_part____ As New clsOntologyItem
    Private objOItem_Attribute_to_Pay As New clsOntologyItem
    Private objOItem_Attribute_Transaction_Date As New clsOntologyItem
    Private objOItem_Attribute_Transaction_ID As New clsOntologyItem
    Private objOItem_Attribute_Valutatag As New clsOntologyItem
    Private objOItem_Attribute_Zahlungsausgang As New clsOntologyItem
    Private objOItem_RelationType_accountings As New clsOntologyItem
    Private objOItem_Attribute_percent As New clsOntologyItem

    'RelationTypes
    Private objOItem_RelationType_belonging_Amount As New clsOntologyItem
    Private objOItem_RelationType_belonging_Contractee As New clsOntologyItem
    Private objOItem_RelationType_belonging_Contractor As New clsOntologyItem
    Private objOItem_RelationType_belonging_Currency As New clsOntologyItem
    Private objOItem_RelationType_belonging_Payment As New clsOntologyItem
    Private objOItem_RelationType_belonging_Sem_Item As New clsOntologyItem
    Private objOItem_RelationType_belonging_Tax_Rate As New clsOntologyItem
    Private objOItem_RelationType_belongsTo As New clsOntologyItem
    Private objOItem_RelationType_contains As New clsOntologyItem
    Private objOItem_RelationType_Gegenkonto As New clsOntologyItem
    Private objOItem_RelationType_is_of_Type As New clsOntologyItem
    Private objOItem_RelationType_isDescribedBy As New clsOntologyItem
    Private objOItem_RelationType_located_in As New clsOntologyItem
    Private objOItem_RelationType_offered_by As New clsOntologyItem
    Private objOItem_RelationType_offers As New clsOntologyItem
    Private objOItem_RelationType_Standard As New clsOntologyItem
    Private objOItem_RelationType_zugeh_rige_Mandanten As New clsOntologyItem

    'Objects
    Private objOItem_Object_Direction_Down As New clsOntologyItem
    Private objOItem_Object_Direction_Up As New clsOntologyItem
    Private objOItem_Module As New clsOntologyItem
    Private objOItem_Object_Search_Template_Amount_ As New clsOntologyItem
    Private objOItem_Object_Search_Template_Contractee_Contractor_ As New clsOntologyItem
    Private objOItem_Object_Search_Template_Name_ As New clsOntologyItem
    Private objOItem_Object_Search_Template_Payment_Date_ As New clsOntologyItem
    Private objOItem_Object_Search_Template_Related_Sem_Item_ As New clsOntologyItem
    Private objOItem_Object_Search_Template_to_Pay_ As New clsOntologyItem
    Private objOItem_Object_Search_Template_Transaction_Date_ As New clsOntologyItem
    Private objOItem_Object_Software_Development_Bill_Module As New clsOntologyItem

    'Classes
    Private objOItem_Class_Bank_Transaktionen__Sparkasse_ As New clsOntologyItem
    Private objOItem_Class_Bank_Transaktionen__Sparkasse____Archiv As New clsOntologyItem
    Private objOItem_Class_Bankleitzahl As New clsOntologyItem
    Private objOItem_Class_Beleg As New clsOntologyItem
    Private objOItem_Class_Belegsart As New clsOntologyItem
    Private objOItem_Class_Bill_Module As New clsOntologyItem
    Private objOItem_Class_Container__physical_ As New clsOntologyItem
    Private objOItem_Class_Currencies As New clsOntologyItem
    Private objOItem_Class_Einheit As New clsOntologyItem
    Private objOItem_Class_Financial_Transaction As New clsOntologyItem
    Private objOItem_Class_Financial_Transaction___Archive As New clsOntologyItem
    Private objOItem_Class_Kontonummer As New clsOntologyItem
    Private objOItem_Class_Language As New clsOntologyItem
    Private objOItem_Class_Menge As New clsOntologyItem
    Private objOItem_Class_Module As New clsOntologyItem
    Private objOItem_Class_Offset As New clsOntologyItem
    Private objOItem_Class_Partner As New clsOntologyItem
    Private objOItem_Class_Payment As New clsOntologyItem
    Private objOItem_Class_Search_Template As New clsOntologyItem
    Private objOItem_Class_Tax_Rates As New clsOntologyItem

    'Attributes
    Public ReadOnly Property OItem_Attribute_Amount() As clsOntologyItem
        Get
            Return objOItem_Attribute_Amount
        End Get
    End Property

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

    Public ReadOnly Property OItem_attribute_dbPostfix() As clsOntologyItem
        Get
            Return objOItem_attribute_dbPostfix
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_gross() As clsOntologyItem
        Get
            Return objOItem_Attribute_gross
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Gross__Standard_() As clsOntologyItem
        Get
            Return objOItem_Attribute_Gross__Standard_
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Menge() As clsOntologyItem
        Get
            Return objOItem_Attribute_Menge
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_part____() As clsOntologyItem
        Get
            Return objOItem_Attribute_part____
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_to_Pay() As clsOntologyItem
        Get
            Return objOItem_Attribute_to_Pay
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Transaction_Date() As clsOntologyItem
        Get
            Return objOItem_Attribute_Transaction_Date
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Transaction_ID() As clsOntologyItem
        Get
            Return objOItem_Attribute_Transaction_ID
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Valutatag() As clsOntologyItem
        Get
            Return objOItem_Attribute_Valutatag
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Zahlungsausgang() As clsOntologyItem
        Get
            Return objOItem_Attribute_Zahlungsausgang
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_percent() As clsOntologyItem
        Get
            Return objOItem_Attribute_percent
        End Get
    End Property


    'RelationTypes
    Public ReadOnly Property OItem_RelationType_accountings() As clsOntologyItem
        Get
            Return objOItem_RelationType_accountings
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Amount() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Amount
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Contractee() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Contractee
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Contractor() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Contractor
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Currency() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Currency
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Payment() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Payment
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Sem_Item() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Sem_Item
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belonging_Tax_Rate() As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging_Tax_Rate
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

    Public ReadOnly Property OItem_RelationType_Gegenkonto() As clsOntologyItem
        Get
            Return objOItem_RelationType_Gegenkonto
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_is_of_Type() As clsOntologyItem
        Get
            Return objOItem_RelationType_is_of_Type
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_isDescribedBy() As clsOntologyItem
        Get
            Return objOItem_RelationType_isDescribedBy
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_located_in() As clsOntologyItem
        Get
            Return objOItem_RelationType_located_in
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

    Public ReadOnly Property OItem_RelationType_Standard() As clsOntologyItem
        Get
            Return objOItem_RelationType_Standard
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_zugeh_rige_Mandanten() As clsOntologyItem
        Get
            Return objOItem_RelationType_zugeh_rige_Mandanten
        End Get
    End Property

    'Objects
    Public ReadOnly Property OItem_Object_Direction_Down() As clsOntologyItem
        Get
            Return objOItem_Object_Direction_Down
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Direction_Up() As clsOntologyItem
        Get
            Return objOItem_Object_Direction_Up
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Search_Template_Amount_() As clsOntologyItem
        Get
            Return objOItem_Object_Search_Template_Amount_
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Search_Template_Contractee_Contractor_() As clsOntologyItem
        Get
            Return objOItem_Object_Search_Template_Contractee_Contractor_
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Search_Template_Name_() As clsOntologyItem
        Get
            Return objOItem_Object_Search_Template_Name_
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Search_Template_Payment_Date_() As clsOntologyItem
        Get
            Return objOItem_Object_Search_Template_Payment_Date_
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Search_Template_Related_Sem_Item_() As clsOntologyItem
        Get
            Return objOItem_Object_Search_Template_Related_Sem_Item_
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Search_Template_to_Pay_() As clsOntologyItem
        Get
            Return objOItem_Object_Search_Template_to_Pay_
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Search_Template_Transaction_Date_() As clsOntologyItem
        Get
            Return objOItem_Object_Search_Template_Transaction_Date_
        End Get
    End Property

    Public ReadOnly Property OItem_Object_Software_Development_Bill_Module() As clsOntologyItem
        Get
            Return objOItem_Object_Software_Development_Bill_Module
        End Get
    End Property

    'Classes
    Public ReadOnly Property OItem_Class_Bank_Transaktionen__Sparkasse_() As clsOntologyItem
        Get
            Return objOItem_Class_Bank_Transaktionen__Sparkasse_
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Bank_Transaktionen__Sparkasse____Archiv() As clsOntologyItem
        Get
            Return objOItem_Class_Bank_Transaktionen__Sparkasse____Archiv
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Bankleitzahl() As clsOntologyItem
        Get
            Return objOItem_Class_Bankleitzahl
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Beleg() As clsOntologyItem
        Get
            Return objOItem_Class_Beleg
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Belegsart() As clsOntologyItem
        Get
            Return objOItem_Class_Belegsart
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Bill_Module() As clsOntologyItem
        Get
            Return objOItem_Class_Bill_Module
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Container__physical_() As clsOntologyItem
        Get
            Return objOItem_Class_Container__physical_
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Currencies() As clsOntologyItem
        Get
            Return objOItem_Class_Currencies
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Einheit() As clsOntologyItem
        Get
            Return objOItem_Class_Einheit
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Financial_Transaction() As clsOntologyItem
        Get
            Return objOItem_Class_Financial_Transaction
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Financial_Transaction___Archive() As clsOntologyItem
        Get
            Return objOItem_Class_Financial_Transaction___Archive
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Kontonummer() As clsOntologyItem
        Get
            Return objOItem_Class_Kontonummer
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Language() As clsOntologyItem
        Get
            Return objOItem_Class_Language
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Menge() As clsOntologyItem
        Get
            Return objOItem_Class_Menge
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Module() As clsOntologyItem
        Get
            Return objOItem_Class_Module
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Offset() As clsOntologyItem
        Get
            Return objOItem_Class_Offset
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Partner() As clsOntologyItem
        Get
            Return objOItem_Class_Partner
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Payment() As clsOntologyItem
        Get
            Return objOItem_Class_Payment
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Search_Template() As clsOntologyItem
        Get
            Return objOItem_Class_Search_Template
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Tax_Rates() As clsOntologyItem
        Get
            Return objOItem_Class_Tax_Rates
        End Get
    End Property


    Public ReadOnly Property ImageID_Bill As Integer
        Get
            Return cint_ImageID_Bill
        End Get
    End Property

    Public ReadOnly Property ImageID_Ausgaben As Integer
        Get
            Return cint_ImageID_Ausgaben
        End Get
    End Property

    Public ReadOnly Property ImageID_BillSelected As Integer
        Get
            Return cint_ImageID_BillSelected
        End Get
    End Property

    Public ReadOnly Property ImageID_Einnahmen As Integer
        Get
            Return cint_ImageID_Einnahmen
        End Get
    End Property

    Public ReadOnly Property ImageID_Mandant As Integer
        Get
            Return cint_ImageID_Mandant
        End Get
    End Property

    Public ReadOnly Property ImageID_PartialBill As Integer
        Get
            Return cint_ImageID_PartialBill
        End Get
    End Property

    Public ReadOnly Property ImageID_Position As Integer
        Get
            Return cint_ImageID_Position
        End Get
    End Property

    Public ReadOnly Property ImageID_Root As Integer
        Get
            Return cint_ImageID_Root
        End Get
    End Property

    Public ReadOnly Property ImageID_Unzugeordnet As Integer
        Get
            Return cint_ImageID_Unzugeordnet
        End Get
    End Property

    Public ReadOnly Property OItem_BaseConfig As clsOntologyItem
        Get
            Return objOItem_BaseConfig
        End Get
    End Property

    Public ReadOnly Property OItem_Module As clsOntologyItem
        Get
            Return objOItem_Module
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

    Private Sub get_BaseConfig()
        Dim oList_ObjectRel As New List(Of clsObjectRel)


        oList_ObjectRel.Clear()
        oList_ObjectRel.Add(New clsObjectRel(Nothing, _
                                                Nothing, _
                                                objOItem_Class_Bill_Module.GUID, _
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

        If objDBLevel_Config1.OList_ObjectRel.Any() Then
            objOItem_BaseConfig = New clsOntologyItem(objDBLevel_Config1.OList_ObjectRel(0).ID_Object, _
                                                    objDBLevel_Config1.OList_ObjectRel(0).Name_Object, _
                                                    objDBLevel_Config1.OList_ObjectRel(0).ID_Parent_Object, _
                                                    objGlobals.Type_Object)
        Else
            Err.Raise(1, "Config not set")
        End If
    End Sub

    Private Sub get_Config_AttributeTypes()
        Dim objOList_attribute_percent = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_percent".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_percent.Any() Then
            objOItem_Attribute_percent = New clsOntologyItem
            objOItem_Attribute_percent.GUID = objOList_attribute_percent.First().ID_Other
            objOItem_Attribute_percent.Name = objOList_attribute_percent.First().Name_Other
            objOItem_Attribute_percent.GUID_Parent = objOList_attribute_percent.First().ID_Parent_Other
            objOItem_Attribute_percent.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If


        Dim objOList_attribute_amount = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_amount".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_amount.Any() Then
            objOItem_Attribute_Amount = New clsOntologyItem
            objOItem_Attribute_Amount.GUID = objOList_attribute_amount.First().ID_Other
            objOItem_Attribute_Amount.Name = objOList_attribute_amount.First().Name_Other
            objOItem_Attribute_Amount.GUID_Parent = objOList_attribute_amount.First().ID_Parent_Other
            objOItem_Attribute_Amount.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_beg_nstigter_zahlungspflichtiger = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_beg_nstigter_zahlungspflichtiger".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_beg_nstigter_zahlungspflichtiger.Any() Then
            objOItem_Attribute_Beg_nstigter_Zahlungspflichtiger = New clsOntologyItem
            objOItem_Attribute_Beg_nstigter_Zahlungspflichtiger.GUID = objOList_attribute_beg_nstigter_zahlungspflichtiger.First().ID_Other
            objOItem_Attribute_Beg_nstigter_Zahlungspflichtiger.Name = objOList_attribute_beg_nstigter_zahlungspflichtiger.First().Name_Other
            objOItem_Attribute_Beg_nstigter_Zahlungspflichtiger.GUID_Parent = objOList_attribute_beg_nstigter_zahlungspflichtiger.First().ID_Parent_Other
            objOItem_Attribute_Beg_nstigter_Zahlungspflichtiger.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_betrag = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_betrag".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_betrag.Any() Then
            objOItem_Attribute_Betrag = New clsOntologyItem
            objOItem_Attribute_Betrag.GUID = objOList_attribute_betrag.First().ID_Other
            objOItem_Attribute_Betrag.Name = objOList_attribute_betrag.First().Name_Other
            objOItem_Attribute_Betrag.GUID_Parent = objOList_attribute_betrag.First().ID_Parent_Other
            objOItem_Attribute_Betrag.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_dbpostfix = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_dbpostfix".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_dbpostfix.Any() Then
            objOItem_attribute_dbPostfix = New clsOntologyItem
            objOItem_attribute_dbPostfix.GUID = objOList_attribute_dbpostfix.First().ID_Other
            objOItem_attribute_dbPostfix.Name = objOList_attribute_dbpostfix.First().Name_Other
            objOItem_attribute_dbPostfix.GUID_Parent = objOList_attribute_dbpostfix.First().ID_Parent_Other
            objOItem_attribute_dbPostfix.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_gross = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_gross".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_gross.Any() Then
            objOItem_Attribute_gross = New clsOntologyItem
            objOItem_Attribute_gross.GUID = objOList_attribute_gross.First().ID_Other
            objOItem_Attribute_gross.Name = objOList_attribute_gross.First().Name_Other
            objOItem_Attribute_gross.GUID_Parent = objOList_attribute_gross.First().ID_Parent_Other
            objOItem_Attribute_gross.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_gross__standard_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_gross__standard_".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_gross__standard_.Any() Then
            objOItem_Attribute_Gross__Standard_ = New clsOntologyItem
            objOItem_Attribute_Gross__Standard_.GUID = objOList_attribute_gross__standard_.First().ID_Other
            objOItem_Attribute_Gross__Standard_.Name = objOList_attribute_gross__standard_.First().Name_Other
            objOItem_Attribute_Gross__Standard_.GUID_Parent = objOList_attribute_gross__standard_.First().ID_Parent_Other
            objOItem_Attribute_Gross__Standard_.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_menge = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_menge".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_menge.Any() Then
            objOItem_Attribute_Menge = New clsOntologyItem
            objOItem_Attribute_Menge.GUID = objOList_attribute_menge.First().ID_Other
            objOItem_Attribute_Menge.Name = objOList_attribute_menge.First().Name_Other
            objOItem_Attribute_Menge.GUID_Parent = objOList_attribute_menge.First().ID_Parent_Other
            objOItem_Attribute_Menge.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_part____ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_part____".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_part____.Any() Then
            objOItem_Attribute_part____ = New clsOntologyItem
            objOItem_Attribute_part____.GUID = objOList_attribute_part____.First().ID_Other
            objOItem_Attribute_part____.Name = objOList_attribute_part____.First().Name_Other
            objOItem_Attribute_part____.GUID_Parent = objOList_attribute_part____.First().ID_Parent_Other
            objOItem_Attribute_part____.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_to_pay = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_to_pay".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_to_pay.Any() Then
            objOItem_Attribute_to_Pay = New clsOntologyItem
            objOItem_Attribute_to_Pay.GUID = objOList_attribute_to_pay.First().ID_Other
            objOItem_Attribute_to_Pay.Name = objOList_attribute_to_pay.First().Name_Other
            objOItem_Attribute_to_Pay.GUID_Parent = objOList_attribute_to_pay.First().ID_Parent_Other
            objOItem_Attribute_to_Pay.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_transaction_date = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_transaction_date".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_transaction_date.Any() Then
            objOItem_Attribute_Transaction_Date = New clsOntologyItem
            objOItem_Attribute_Transaction_Date.GUID = objOList_attribute_transaction_date.First().ID_Other
            objOItem_Attribute_Transaction_Date.Name = objOList_attribute_transaction_date.First().Name_Other
            objOItem_Attribute_Transaction_Date.GUID_Parent = objOList_attribute_transaction_date.First().ID_Parent_Other
            objOItem_Attribute_Transaction_Date.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_transaction_id = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_transaction_id".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_transaction_id.Any() Then
            objOItem_Attribute_Transaction_ID = New clsOntologyItem
            objOItem_Attribute_Transaction_ID.GUID = objOList_attribute_transaction_id.First().ID_Other
            objOItem_Attribute_Transaction_ID.Name = objOList_attribute_transaction_id.First().Name_Other
            objOItem_Attribute_Transaction_ID.GUID_Parent = objOList_attribute_transaction_id.First().ID_Parent_Other
            objOItem_Attribute_Transaction_ID.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_valutatag = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_valutatag".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_valutatag.Any() Then
            objOItem_Attribute_Valutatag = New clsOntologyItem
            objOItem_Attribute_Valutatag.GUID = objOList_attribute_valutatag.First().ID_Other
            objOItem_Attribute_Valutatag.Name = objOList_attribute_valutatag.First().Name_Other
            objOItem_Attribute_Valutatag.GUID_Parent = objOList_attribute_valutatag.First().ID_Parent_Other
            objOItem_Attribute_Valutatag.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_zahlungsausgang = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "attribute_zahlungsausgang".ToLower() And objRef.Ontology = objGlobals.Type_AttributeType
                                           Select objRef).ToList()

        If objOList_attribute_zahlungsausgang.Any() Then
            objOItem_Attribute_Zahlungsausgang = New clsOntologyItem
            objOItem_Attribute_Zahlungsausgang.GUID = objOList_attribute_zahlungsausgang.First().ID_Other
            objOItem_Attribute_Zahlungsausgang.Name = objOList_attribute_zahlungsausgang.First().Name_Other
            objOItem_Attribute_Zahlungsausgang.GUID_Parent = objOList_attribute_zahlungsausgang.First().ID_Parent_Other
            objOItem_Attribute_Zahlungsausgang.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_RelationTypes()
        Dim objOList_relationtype_accountings = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_accountings".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_accountings.Any() Then
            objOItem_RelationType_accountings = New clsOntologyItem
            objOItem_RelationType_accountings.GUID = objOList_relationtype_accountings.First().ID_Other
            objOItem_RelationType_accountings.Name = objOList_relationtype_accountings.First().Name_Other
            objOItem_RelationType_accountings.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_amount = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_amount".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_amount.Any() Then
            objOItem_RelationType_belonging_Amount = New clsOntologyItem
            objOItem_RelationType_belonging_Amount.GUID = objOList_relationtype_belonging_amount.First().ID_Other
            objOItem_RelationType_belonging_Amount.Name = objOList_relationtype_belonging_amount.First().Name_Other
            objOItem_RelationType_belonging_Amount.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_contractee = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_contractee".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_contractee.Any() Then
            objOItem_RelationType_belonging_Contractee = New clsOntologyItem
            objOItem_RelationType_belonging_Contractee.GUID = objOList_relationtype_belonging_contractee.First().ID_Other
            objOItem_RelationType_belonging_Contractee.Name = objOList_relationtype_belonging_contractee.First().Name_Other
            objOItem_RelationType_belonging_Contractee.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_contractor = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_contractor".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_contractor.Any() Then
            objOItem_RelationType_belonging_Contractor = New clsOntologyItem
            objOItem_RelationType_belonging_Contractor.GUID = objOList_relationtype_belonging_contractor.First().ID_Other
            objOItem_RelationType_belonging_Contractor.Name = objOList_relationtype_belonging_contractor.First().Name_Other
            objOItem_RelationType_belonging_Contractor.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_currency = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_currency".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_currency.Any() Then
            objOItem_RelationType_belonging_Currency = New clsOntologyItem
            objOItem_RelationType_belonging_Currency.GUID = objOList_relationtype_belonging_currency.First().ID_Other
            objOItem_RelationType_belonging_Currency.Name = objOList_relationtype_belonging_currency.First().Name_Other
            objOItem_RelationType_belonging_Currency.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_payment = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_payment".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_payment.Any() Then
            objOItem_RelationType_belonging_Payment = New clsOntologyItem
            objOItem_RelationType_belonging_Payment.GUID = objOList_relationtype_belonging_payment.First().ID_Other
            objOItem_RelationType_belonging_Payment.Name = objOList_relationtype_belonging_payment.First().Name_Other
            objOItem_RelationType_belonging_Payment.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_sem_item = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_sem_item".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_sem_item.Any() Then
            objOItem_RelationType_belonging_Sem_Item = New clsOntologyItem
            objOItem_RelationType_belonging_Sem_Item.GUID = objOList_relationtype_belonging_sem_item.First().ID_Other
            objOItem_RelationType_belonging_Sem_Item.Name = objOList_relationtype_belonging_sem_item.First().Name_Other
            objOItem_RelationType_belonging_Sem_Item.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_tax_rate = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belonging_tax_rate".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belonging_tax_rate.Any() Then
            objOItem_RelationType_belonging_Tax_Rate = New clsOntologyItem
            objOItem_RelationType_belonging_Tax_Rate.GUID = objOList_relationtype_belonging_tax_rate.First().ID_Other
            objOItem_RelationType_belonging_Tax_Rate.Name = objOList_relationtype_belonging_tax_rate.First().Name_Other
            objOItem_RelationType_belonging_Tax_Rate.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belongsto = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_belongsto".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_belongsto.Any() Then
            objOItem_RelationType_belongsTo = New clsOntologyItem
            objOItem_RelationType_belongsTo.GUID = objOList_relationtype_belongsto.First().ID_Other
            objOItem_RelationType_belongsTo.Name = objOList_relationtype_belongsto.First().Name_Other
            objOItem_RelationType_belongsTo.Type = objGlobals.Type_RelationType
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

        Dim objOList_relationtype_gegenkonto = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_gegenkonto".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_gegenkonto.Any() Then
            objOItem_RelationType_Gegenkonto = New clsOntologyItem
            objOItem_RelationType_Gegenkonto.GUID = objOList_relationtype_gegenkonto.First().ID_Other
            objOItem_RelationType_Gegenkonto.Name = objOList_relationtype_gegenkonto.First().Name_Other
            objOItem_RelationType_Gegenkonto.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_is_of_type = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_is_of_type".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_is_of_type.Any() Then
            objOItem_RelationType_is_of_Type = New clsOntologyItem
            objOItem_RelationType_is_of_Type.GUID = objOList_relationtype_is_of_type.First().ID_Other
            objOItem_RelationType_is_of_Type.Name = objOList_relationtype_is_of_type.First().Name_Other
            objOItem_RelationType_is_of_Type.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_isdescribedby = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_isdescribedby".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_isdescribedby.Any() Then
            objOItem_RelationType_isDescribedBy = New clsOntologyItem
            objOItem_RelationType_isDescribedBy.GUID = objOList_relationtype_isdescribedby.First().ID_Other
            objOItem_RelationType_isDescribedBy.Name = objOList_relationtype_isdescribedby.First().Name_Other
            objOItem_RelationType_isDescribedBy.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_located_in = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_located_in".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_located_in.Any() Then
            objOItem_RelationType_located_in = New clsOntologyItem
            objOItem_RelationType_located_in.GUID = objOList_relationtype_located_in.First().ID_Other
            objOItem_RelationType_located_in.Name = objOList_relationtype_located_in.First().Name_Other
            objOItem_RelationType_located_in.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_offered_by = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_offered_by".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_offered_by.Any() Then
            objOItem_RelationType_offered_by = New clsOntologyItem
            objOItem_RelationType_offered_by.GUID = objOList_relationtype_offered_by.First().ID_Other
            objOItem_RelationType_offered_by.Name = objOList_relationtype_offered_by.First().Name_Other
            objOItem_RelationType_offered_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_offers = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_offers".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_offers.Any() Then
            objOItem_RelationType_offers = New clsOntologyItem
            objOItem_RelationType_offers.GUID = objOList_relationtype_offers.First().ID_Other
            objOItem_RelationType_offers.Name = objOList_relationtype_offers.First().Name_Other
            objOItem_RelationType_offers.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_standard = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "relationtype_standard".ToLower() And objRef.Ontology = objGlobals.Type_RelationType
                                           Select objRef).ToList()

        If objOList_relationtype_standard.Any() Then
            objOItem_RelationType_Standard = New clsOntologyItem
            objOItem_RelationType_Standard.GUID = objOList_relationtype_standard.First().ID_Other
            objOItem_RelationType_Standard.Name = objOList_relationtype_standard.First().Name_Other
            objOItem_RelationType_Standard.Type = objGlobals.Type_RelationType
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


    End Sub

    Private Sub get_Config_Objects()
        Dim objOList_token_direction_down = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_direction_down".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_token_direction_down.Any() Then
            objOItem_Object_Direction_Down = New clsOntologyItem
            objOItem_Object_Direction_Down.GUID = objOList_token_direction_down.First().ID_Other
            objOItem_Object_Direction_Down.Name = objOList_token_direction_down.First().Name_Other
            objOItem_Object_Direction_Down.GUID_Parent = objOList_token_direction_down.First().ID_Parent_Other
            objOItem_Object_Direction_Down.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_direction_up = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_direction_up".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_token_direction_up.Any() Then
            objOItem_Object_Direction_Up = New clsOntologyItem
            objOItem_Object_Direction_Up.GUID = objOList_token_direction_up.First().ID_Other
            objOItem_Object_Direction_Up.Name = objOList_token_direction_up.First().Name_Other
            objOItem_Object_Direction_Up.GUID_Parent = objOList_token_direction_up.First().ID_Parent_Other
            objOItem_Object_Direction_Up.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_module_bill_module = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_module_bill_module".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_token_module_bill_module.Any() Then
            objOItem_Module = New clsOntologyItem
            objOItem_Module.GUID = objOList_token_module_bill_module.First().ID_Other
            objOItem_Module.Name = objOList_token_module_bill_module.First().Name_Other
            objOItem_Module.GUID_Parent = objOList_token_module_bill_module.First().ID_Parent_Other
            objOItem_Module.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_amount_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_search_template_amount_".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_token_search_template_amount_.Any() Then
            objOItem_Object_Search_Template_Amount_ = New clsOntologyItem
            objOItem_Object_Search_Template_Amount_.GUID = objOList_token_search_template_amount_.First().ID_Other
            objOItem_Object_Search_Template_Amount_.Name = objOList_token_search_template_amount_.First().Name_Other
            objOItem_Object_Search_Template_Amount_.GUID_Parent = objOList_token_search_template_amount_.First().ID_Parent_Other
            objOItem_Object_Search_Template_Amount_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_contractee_contractor_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_search_template_contractee_contractor_".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_token_search_template_contractee_contractor_.Any() Then
            objOItem_Object_Search_Template_Contractee_Contractor_ = New clsOntologyItem
            objOItem_Object_Search_Template_Contractee_Contractor_.GUID = objOList_token_search_template_contractee_contractor_.First().ID_Other
            objOItem_Object_Search_Template_Contractee_Contractor_.Name = objOList_token_search_template_contractee_contractor_.First().Name_Other
            objOItem_Object_Search_Template_Contractee_Contractor_.GUID_Parent = objOList_token_search_template_contractee_contractor_.First().ID_Parent_Other
            objOItem_Object_Search_Template_Contractee_Contractor_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_name_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_search_template_name_".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_token_search_template_name_.Any() Then
            objOItem_Object_Search_Template_Name_ = New clsOntologyItem
            objOItem_Object_Search_Template_Name_.GUID = objOList_token_search_template_name_.First().ID_Other
            objOItem_Object_Search_Template_Name_.Name = objOList_token_search_template_name_.First().Name_Other
            objOItem_Object_Search_Template_Name_.GUID_Parent = objOList_token_search_template_name_.First().ID_Parent_Other
            objOItem_Object_Search_Template_Name_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_payment_date_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_search_template_payment_date_".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_token_search_template_payment_date_.Any() Then
            objOItem_Object_Search_Template_Payment_Date_ = New clsOntologyItem
            objOItem_Object_Search_Template_Payment_Date_.GUID = objOList_token_search_template_payment_date_.First().ID_Other
            objOItem_Object_Search_Template_Payment_Date_.Name = objOList_token_search_template_payment_date_.First().Name_Other
            objOItem_Object_Search_Template_Payment_Date_.GUID_Parent = objOList_token_search_template_payment_date_.First().ID_Parent_Other
            objOItem_Object_Search_Template_Payment_Date_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_related_sem_item_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_search_template_related_sem_item_".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_token_search_template_related_sem_item_.Any() Then
            objOItem_Object_Search_Template_Related_Sem_Item_ = New clsOntologyItem
            objOItem_Object_Search_Template_Related_Sem_Item_.GUID = objOList_token_search_template_related_sem_item_.First().ID_Other
            objOItem_Object_Search_Template_Related_Sem_Item_.Name = objOList_token_search_template_related_sem_item_.First().Name_Other
            objOItem_Object_Search_Template_Related_Sem_Item_.GUID_Parent = objOList_token_search_template_related_sem_item_.First().ID_Parent_Other
            objOItem_Object_Search_Template_Related_Sem_Item_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_to_pay_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_search_template_to_pay_".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_token_search_template_to_pay_.Any() Then
            objOItem_Object_Search_Template_to_Pay_ = New clsOntologyItem
            objOItem_Object_Search_Template_to_Pay_.GUID = objOList_token_search_template_to_pay_.First().ID_Other
            objOItem_Object_Search_Template_to_Pay_.Name = objOList_token_search_template_to_pay_.First().Name_Other
            objOItem_Object_Search_Template_to_Pay_.GUID_Parent = objOList_token_search_template_to_pay_.First().ID_Parent_Other
            objOItem_Object_Search_Template_to_Pay_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_transaction_date_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_search_template_transaction_date_".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_token_search_template_transaction_date_.Any() Then
            objOItem_Object_Search_Template_Transaction_Date_ = New clsOntologyItem
            objOItem_Object_Search_Template_Transaction_Date_.GUID = objOList_token_search_template_transaction_date_.First().ID_Other
            objOItem_Object_Search_Template_Transaction_Date_.Name = objOList_token_search_template_transaction_date_.First().Name_Other
            objOItem_Object_Search_Template_Transaction_Date_.GUID_Parent = objOList_token_search_template_transaction_date_.First().ID_Parent_Other
            objOItem_Object_Search_Template_Transaction_Date_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_software_development_bill_module = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "token_software_development_bill_module".ToLower() And objRef.Ontology = objGlobals.Type_Object
                                           Select objRef).ToList()

        If objOList_token_software_development_bill_module.Any() Then
            objOItem_Object_Software_Development_Bill_Module = New clsOntologyItem
            objOItem_Object_Software_Development_Bill_Module.GUID = objOList_token_software_development_bill_module.First().ID_Other
            objOItem_Object_Software_Development_Bill_Module.Name = objOList_token_software_development_bill_module.First().Name_Other
            objOItem_Object_Software_Development_Bill_Module.GUID_Parent = objOList_token_software_development_bill_module.First().ID_Parent_Other
            objOItem_Object_Software_Development_Bill_Module.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_Classes()
        Dim objOList_type_bank_transaktionen__sparkasse_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_bank_transaktionen__sparkasse_".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_bank_transaktionen__sparkasse_.Any() Then
            objOItem_Class_Bank_Transaktionen__Sparkasse_ = New clsOntologyItem
            objOItem_Class_Bank_Transaktionen__Sparkasse_.GUID = objOList_type_bank_transaktionen__sparkasse_.First().ID_Other
            objOItem_Class_Bank_Transaktionen__Sparkasse_.Name = objOList_type_bank_transaktionen__sparkasse_.First().Name_Other
            objOItem_Class_Bank_Transaktionen__Sparkasse_.GUID_Parent = objOList_type_bank_transaktionen__sparkasse_.First().ID_Parent_Other
            objOItem_Class_Bank_Transaktionen__Sparkasse_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_bank_transaktionen__sparkasse____archiv = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_bank_transaktionen__sparkasse____archiv".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_bank_transaktionen__sparkasse____archiv.Any() Then
            objOItem_Class_Bank_Transaktionen__Sparkasse____Archiv = New clsOntologyItem
            objOItem_Class_Bank_Transaktionen__Sparkasse____Archiv.GUID = objOList_type_bank_transaktionen__sparkasse____archiv.First().ID_Other
            objOItem_Class_Bank_Transaktionen__Sparkasse____Archiv.Name = objOList_type_bank_transaktionen__sparkasse____archiv.First().Name_Other
            objOItem_Class_Bank_Transaktionen__Sparkasse____Archiv.GUID_Parent = objOList_type_bank_transaktionen__sparkasse____archiv.First().ID_Parent_Other
            objOItem_Class_Bank_Transaktionen__Sparkasse____Archiv.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_bankleitzahl = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_bankleitzahl".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_bankleitzahl.Any() Then
            objOItem_Class_Bankleitzahl = New clsOntologyItem
            objOItem_Class_Bankleitzahl.GUID = objOList_type_bankleitzahl.First().ID_Other
            objOItem_Class_Bankleitzahl.Name = objOList_type_bankleitzahl.First().Name_Other
            objOItem_Class_Bankleitzahl.GUID_Parent = objOList_type_bankleitzahl.First().ID_Parent_Other
            objOItem_Class_Bankleitzahl.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_beleg = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_beleg".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_beleg.Any() Then
            objOItem_Class_Beleg = New clsOntologyItem
            objOItem_Class_Beleg.GUID = objOList_type_beleg.First().ID_Other
            objOItem_Class_Beleg.Name = objOList_type_beleg.First().Name_Other
            objOItem_Class_Beleg.GUID_Parent = objOList_type_beleg.First().ID_Parent_Other
            objOItem_Class_Beleg.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_belegsart = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_belegsart".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_belegsart.Any() Then
            objOItem_Class_Belegsart = New clsOntologyItem
            objOItem_Class_Belegsart.GUID = objOList_type_belegsart.First().ID_Other
            objOItem_Class_Belegsart.Name = objOList_type_belegsart.First().Name_Other
            objOItem_Class_Belegsart.GUID_Parent = objOList_type_belegsart.First().ID_Parent_Other
            objOItem_Class_Belegsart.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_bill_module = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_bill_module".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_bill_module.Any() Then
            objOItem_Class_Bill_Module = New clsOntologyItem
            objOItem_Class_Bill_Module.GUID = objOList_type_bill_module.First().ID_Other
            objOItem_Class_Bill_Module.Name = objOList_type_bill_module.First().Name_Other
            objOItem_Class_Bill_Module.GUID_Parent = objOList_type_bill_module.First().ID_Parent_Other
            objOItem_Class_Bill_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_container__physical_ = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_container__physical_".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_container__physical_.Any() Then
            objOItem_Class_Container__physical_ = New clsOntologyItem
            objOItem_Class_Container__physical_.GUID = objOList_type_container__physical_.First().ID_Other
            objOItem_Class_Container__physical_.Name = objOList_type_container__physical_.First().Name_Other
            objOItem_Class_Container__physical_.GUID_Parent = objOList_type_container__physical_.First().ID_Parent_Other
            objOItem_Class_Container__physical_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_currencies = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_currencies".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_currencies.Any() Then
            objOItem_Class_Currencies = New clsOntologyItem
            objOItem_Class_Currencies.GUID = objOList_type_currencies.First().ID_Other
            objOItem_Class_Currencies.Name = objOList_type_currencies.First().Name_Other
            objOItem_Class_Currencies.GUID_Parent = objOList_type_currencies.First().ID_Parent_Other
            objOItem_Class_Currencies.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_einheit = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_einheit".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_einheit.Any() Then
            objOItem_Class_Einheit = New clsOntologyItem
            objOItem_Class_Einheit.GUID = objOList_type_einheit.First().ID_Other
            objOItem_Class_Einheit.Name = objOList_type_einheit.First().Name_Other
            objOItem_Class_Einheit.GUID_Parent = objOList_type_einheit.First().ID_Parent_Other
            objOItem_Class_Einheit.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_financial_transaction = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_financial_transaction".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_financial_transaction.Any() Then
            objOItem_Class_Financial_Transaction = New clsOntologyItem
            objOItem_Class_Financial_Transaction.GUID = objOList_type_financial_transaction.First().ID_Other
            objOItem_Class_Financial_Transaction.Name = objOList_type_financial_transaction.First().Name_Other
            objOItem_Class_Financial_Transaction.GUID_Parent = objOList_type_financial_transaction.First().ID_Parent_Other
            objOItem_Class_Financial_Transaction.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_financial_transaction___archive = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_financial_transaction___archive".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_financial_transaction___archive.Any() Then
            objOItem_Class_Financial_Transaction___Archive = New clsOntologyItem
            objOItem_Class_Financial_Transaction___Archive.GUID = objOList_type_financial_transaction___archive.First().ID_Other
            objOItem_Class_Financial_Transaction___Archive.Name = objOList_type_financial_transaction___archive.First().Name_Other
            objOItem_Class_Financial_Transaction___Archive.GUID_Parent = objOList_type_financial_transaction___archive.First().ID_Parent_Other
            objOItem_Class_Financial_Transaction___Archive.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_kontonummer = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_kontonummer".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_kontonummer.Any() Then
            objOItem_Class_Kontonummer = New clsOntologyItem
            objOItem_Class_Kontonummer.GUID = objOList_type_kontonummer.First().ID_Other
            objOItem_Class_Kontonummer.Name = objOList_type_kontonummer.First().Name_Other
            objOItem_Class_Kontonummer.GUID_Parent = objOList_type_kontonummer.First().ID_Parent_Other
            objOItem_Class_Kontonummer.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_language = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_language".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_language.Any() Then
            objOItem_Class_Language = New clsOntologyItem
            objOItem_Class_Language.GUID = objOList_type_language.First().ID_Other
            objOItem_Class_Language.Name = objOList_type_language.First().Name_Other
            objOItem_Class_Language.GUID_Parent = objOList_type_language.First().ID_Parent_Other
            objOItem_Class_Language.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_menge = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_menge".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_menge.Any() Then
            objOItem_Class_Menge = New clsOntologyItem
            objOItem_Class_Menge.GUID = objOList_type_menge.First().ID_Other
            objOItem_Class_Menge.Name = objOList_type_menge.First().Name_Other
            objOItem_Class_Menge.GUID_Parent = objOList_type_menge.First().ID_Parent_Other
            objOItem_Class_Menge.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_module = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_module".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_module.Any() Then
            objOItem_Class_Module = New clsOntologyItem
            objOItem_Class_Module.GUID = objOList_type_module.First().ID_Other
            objOItem_Class_Module.Name = objOList_type_module.First().Name_Other
            objOItem_Class_Module.GUID_Parent = objOList_type_module.First().ID_Parent_Other
            objOItem_Class_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_offset = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_offset".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_offset.Any() Then
            objOItem_Class_Offset = New clsOntologyItem
            objOItem_Class_Offset.GUID = objOList_type_offset.First().ID_Other
            objOItem_Class_Offset.Name = objOList_type_offset.First().Name_Other
            objOItem_Class_Offset.GUID_Parent = objOList_type_offset.First().ID_Parent_Other
            objOItem_Class_Offset.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_partner = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_partner".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_partner.Any() Then
            objOItem_Class_Partner = New clsOntologyItem
            objOItem_Class_Partner.GUID = objOList_type_partner.First().ID_Other
            objOItem_Class_Partner.Name = objOList_type_partner.First().Name_Other
            objOItem_Class_Partner.GUID_Parent = objOList_type_partner.First().ID_Parent_Other
            objOItem_Class_Partner.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_payment = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_payment".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_payment.Any() Then
            objOItem_Class_Payment = New clsOntologyItem
            objOItem_Class_Payment.GUID = objOList_type_payment.First().ID_Other
            objOItem_Class_Payment.Name = objOList_type_payment.First().Name_Other
            objOItem_Class_Payment.GUID_Parent = objOList_type_payment.First().ID_Parent_Other
            objOItem_Class_Payment.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_search_template = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_search_template".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_search_template.Any() Then
            objOItem_Class_Search_Template = New clsOntologyItem
            objOItem_Class_Search_Template.GUID = objOList_type_search_template.First().ID_Other
            objOItem_Class_Search_Template.Name = objOList_type_search_template.First().Name_Other
            objOItem_Class_Search_Template.GUID_Parent = objOList_type_search_template.First().ID_Parent_Other
            objOItem_Class_Search_Template.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_tax_rates = (From objOItem In objDBLevel_Config1.OList_ObjectRel
                                           Where objOItem.ID_Object = cstrID_Ontology
                                           Join objRef In objDBLevel_Config2.OList_ObjectRel On objOItem.ID_Other Equals objRef.ID_Object
                                           Where objRef.Name_Object.ToLower() = "type_tax_rates".ToLower() And objRef.Ontology = objGlobals.Type_Class
                                           Select objRef).ToList()

        If objOList_type_tax_rates.Any() Then
            objOItem_Class_Tax_Rates = New clsOntologyItem
            objOItem_Class_Tax_Rates.GUID = objOList_type_tax_rates.First().ID_Other
            objOItem_Class_Tax_Rates.Name = objOList_type_tax_rates.First().Name_Other
            objOItem_Class_Tax_Rates.GUID_Parent = objOList_type_tax_rates.First().ID_Parent_Other
            objOItem_Class_Tax_Rates.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If


    End Sub
End Class
