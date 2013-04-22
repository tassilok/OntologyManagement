Imports Ontolog_Module
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

    Private cstr_ID_SoftwareDevelopment As String = "9b0183f0c7874fe8b5bdfe038ccd4a7c"
    Private cstr_ID_Class_SoftwareDevelopment As String = "132a845f849f4f6b86847ab3fd068824"
    Private cstr_ID_Class_DevelopmentConfig As String = "c6c9bcb80ac947139417eeec1453026c"
    Private cstr_ID_Class_ConfigItem As String = "13c09f11175c4eefbc8a0fd8e86d557f"
    Private cstr_ID_RelType_needs As String = "fafc1464815f45969737bcbc96bd744a"
    Private cstr_ID_RelType_contains As String = "e971160347db44d8a476fe88290639a4"
    Private cstr_ID_RelType_belongsTo As String = "e07469d9766c443e85266d9c684f944f"

    Private objGlobals As clsGlobals

    Private objOItem_DevConfig As New clsOntologyItem
    Private objOItem_BaseConfig As clsOntologyItem
    Private objOItem_Module As clsOntologyItem

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
    Private objOItem_Object_Module_Bill_Module As New clsOntologyItem
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

    Public ReadOnly Property OItem_Object_Module_Bill_Module() As clsOntologyItem
        Get
            Return objOItem_Object_Module_Bill_Module
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

        get_Data_DevelopmentConfig()
        get_Config()
        get_BaseConfig()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Config1 = New clsDBLevel(objGlobals)
        objDBLevel_Config2 = New clsDBLevel(objGlobals)
    End Sub

    Private Sub get_Config()
        get_Config_AttributeTypes()
        get_Config_RelationTypes()
        get_Config_Classes()
        get_Config_Objects()

    End Sub

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

        objDBLevel_Config1.get_Data_ObjectRel(oList_ObjectRel, _
                                              boolIDs:=False)

        If objDBLevel_Config1.OList_ObjectRel_ID.Count > 0 Then
            objOItem_Module = New clsOntologyItem
            objOItem_Module.GUID = objDBLevel_Config1.OList_ObjectRel(0).ID_Object
            objOItem_Module.Name = objDBLevel_Config1.OList_ObjectRel(0).Name_Object
            objOItem_Module.GUID_Parent = objDBLevel_Config1.OList_ObjectRel(0).ID_Parent_Object
            objOItem_Module.Type = objGlobals.Type_Object

            oList_ObjectRel.Clear()
            oList_ObjectRel.Add(New clsObjectRel(Nothing, _
                                                 Nothing, _
                                                 objOItem_Class_Bill_Module.GUID, _
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
                                                       objDBLevel_Config1.OList_ObjectRel(0).ID_Parent_Object, _
                                                       objGlobals.Type_Object)
            Else
                Err.Raise(1, "Config not set")
            End If
        Else
            Err.Raise(1, "Config not set")

        End If
    End Sub

    Private Sub get_Config_AttributeTypes()
        Dim objOList_attribute_percent = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "attribute_percent" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_percent.Count > 0 Then
            objOItem_Attribute_percent = New clsOntologyItem
            objOItem_Attribute_percent.GUID = objOList_attribute_percent(0).ID_Other
            objOItem_Attribute_percent.Name = objOList_attribute_percent(0).Name_Other
            objOItem_Attribute_percent.GUID_Parent = objOList_attribute_percent(0).ID_Parent_Other
            objOItem_Attribute_percent.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If


        Dim objOList_attribute_amount = From obj In objDBLevel_Config2.OList_ObjectRel
                                  Where obj.Name_Object.ToLower = "attribute_amount" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_amount.Count > 0 Then
            objOItem_Attribute_Amount = New clsOntologyItem
            objOItem_Attribute_Amount.GUID = objOList_attribute_amount(0).ID_Other
            objOItem_Attribute_Amount.Name = objOList_attribute_amount(0).Name_Other
            objOItem_Attribute_Amount.GUID_Parent = objOList_attribute_amount(0).ID_Parent_Other
            objOItem_Attribute_Amount.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_beg_nstigter_zahlungspflichtiger = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_beg_nstigter_zahlungspflichtiger" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_beg_nstigter_zahlungspflichtiger.Count > 0 Then
            objOItem_Attribute_Beg_nstigter_Zahlungspflichtiger = New clsOntologyItem
            objOItem_Attribute_Beg_nstigter_Zahlungspflichtiger.GUID = objOList_attribute_beg_nstigter_zahlungspflichtiger(0).ID_Other
            objOItem_Attribute_Beg_nstigter_Zahlungspflichtiger.Name = objOList_attribute_beg_nstigter_zahlungspflichtiger(0).Name_Other
            objOItem_Attribute_Beg_nstigter_Zahlungspflichtiger.GUID_Parent = objOList_attribute_beg_nstigter_zahlungspflichtiger(0).ID_Parent_Other
            objOItem_Attribute_Beg_nstigter_Zahlungspflichtiger.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_betrag = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_betrag" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_betrag.Count > 0 Then
            objOItem_Attribute_Betrag = New clsOntologyItem
            objOItem_Attribute_Betrag.GUID = objOList_attribute_betrag(0).ID_Other
            objOItem_Attribute_Betrag.Name = objOList_attribute_betrag(0).Name_Other
            objOItem_Attribute_Betrag.GUID_Parent = objOList_attribute_betrag(0).ID_Parent_Other
            objOItem_Attribute_Betrag.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_dbpostfix = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_dbpostfix" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_dbpostfix.Count > 0 Then
            objOItem_attribute_dbPostfix = New clsOntologyItem
            objOItem_attribute_dbPostfix.GUID = objOList_attribute_dbpostfix(0).ID_Other
            objOItem_attribute_dbPostfix.Name = objOList_attribute_dbpostfix(0).Name_Other
            objOItem_attribute_dbPostfix.GUID_Parent = objOList_attribute_dbpostfix(0).ID_Parent_Other
            objOItem_attribute_dbPostfix.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_gross = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_gross" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_gross.Count > 0 Then
            objOItem_Attribute_gross = New clsOntologyItem
            objOItem_Attribute_gross.GUID = objOList_attribute_gross(0).ID_Other
            objOItem_Attribute_gross.Name = objOList_attribute_gross(0).Name_Other
            objOItem_Attribute_gross.GUID_Parent = objOList_attribute_gross(0).ID_Parent_Other
            objOItem_Attribute_gross.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_gross__standard_ = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_gross__standard_" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_gross__standard_.Count > 0 Then
            objOItem_Attribute_Gross__Standard_ = New clsOntologyItem
            objOItem_Attribute_Gross__Standard_.GUID = objOList_attribute_gross__standard_(0).ID_Other
            objOItem_Attribute_Gross__Standard_.Name = objOList_attribute_gross__standard_(0).Name_Other
            objOItem_Attribute_Gross__Standard_.GUID_Parent = objOList_attribute_gross__standard_(0).ID_Parent_Other
            objOItem_Attribute_Gross__Standard_.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_menge = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_menge" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_menge.Count > 0 Then
            objOItem_Attribute_Menge = New clsOntologyItem
            objOItem_Attribute_Menge.GUID = objOList_attribute_menge(0).ID_Other
            objOItem_Attribute_Menge.Name = objOList_attribute_menge(0).Name_Other
            objOItem_Attribute_Menge.GUID_Parent = objOList_attribute_menge(0).ID_Parent_Other
            objOItem_Attribute_Menge.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_part____ = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_part____" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_part____.Count > 0 Then
            objOItem_Attribute_part____ = New clsOntologyItem
            objOItem_Attribute_part____.GUID = objOList_attribute_part____(0).ID_Other
            objOItem_Attribute_part____.Name = objOList_attribute_part____(0).Name_Other
            objOItem_Attribute_part____.GUID_Parent = objOList_attribute_part____(0).ID_Parent_Other
            objOItem_Attribute_part____.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_to_pay = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_to_pay" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_to_pay.Count > 0 Then
            objOItem_Attribute_to_Pay = New clsOntologyItem
            objOItem_Attribute_to_Pay.GUID = objOList_attribute_to_pay(0).ID_Other
            objOItem_Attribute_to_Pay.Name = objOList_attribute_to_pay(0).Name_Other
            objOItem_Attribute_to_Pay.GUID_Parent = objOList_attribute_to_pay(0).ID_Parent_Other
            objOItem_Attribute_to_Pay.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_transaction_date = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_transaction_date" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_transaction_date.Count > 0 Then
            objOItem_Attribute_Transaction_Date = New clsOntologyItem
            objOItem_Attribute_Transaction_Date.GUID = objOList_attribute_transaction_date(0).ID_Other
            objOItem_Attribute_Transaction_Date.Name = objOList_attribute_transaction_date(0).Name_Other
            objOItem_Attribute_Transaction_Date.GUID_Parent = objOList_attribute_transaction_date(0).ID_Parent_Other
            objOItem_Attribute_Transaction_Date.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_transaction_id = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_transaction_id" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_transaction_id.Count > 0 Then
            objOItem_Attribute_Transaction_ID = New clsOntologyItem
            objOItem_Attribute_Transaction_ID.GUID = objOList_attribute_transaction_id(0).ID_Other
            objOItem_Attribute_Transaction_ID.Name = objOList_attribute_transaction_id(0).Name_Other
            objOItem_Attribute_Transaction_ID.GUID_Parent = objOList_attribute_transaction_id(0).ID_Parent_Other
            objOItem_Attribute_Transaction_ID.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_valutatag = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_valutatag" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_valutatag.Count > 0 Then
            objOItem_Attribute_Valutatag = New clsOntologyItem
            objOItem_Attribute_Valutatag.GUID = objOList_attribute_valutatag(0).ID_Other
            objOItem_Attribute_Valutatag.Name = objOList_attribute_valutatag(0).Name_Other
            objOItem_Attribute_Valutatag.GUID_Parent = objOList_attribute_valutatag(0).ID_Parent_Other
            objOItem_Attribute_Valutatag.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_zahlungsausgang = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_zahlungsausgang" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_zahlungsausgang.Count > 0 Then
            objOItem_Attribute_Zahlungsausgang = New clsOntologyItem
            objOItem_Attribute_Zahlungsausgang.GUID = objOList_attribute_zahlungsausgang(0).ID_Other
            objOItem_Attribute_Zahlungsausgang.Name = objOList_attribute_zahlungsausgang(0).Name_Other
            objOItem_Attribute_Zahlungsausgang.GUID_Parent = objOList_attribute_zahlungsausgang(0).ID_Parent_Other
            objOItem_Attribute_Zahlungsausgang.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_RelationTypes()
        Dim objOList_relationtype_accountings = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "relationtype_accountings" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_accountings.Count > 0 Then
            objOItem_RelationType_accountings = New clsOntologyItem
            objOItem_RelationType_accountings.GUID = objOList_relationtype_accountings(0).ID_Other
            objOItem_RelationType_accountings.Name = objOList_relationtype_accountings(0).Name_Other
            objOItem_RelationType_accountings.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_amount = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belonging_amount" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belonging_amount.Count > 0 Then
            objOItem_RelationType_belonging_Amount = New clsOntologyItem
            objOItem_RelationType_belonging_Amount.GUID = objOList_relationtype_belonging_amount(0).ID_Other
            objOItem_RelationType_belonging_Amount.Name = objOList_relationtype_belonging_amount(0).Name_Other
            objOItem_RelationType_belonging_Amount.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_contractee = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belonging_contractee" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belonging_contractee.Count > 0 Then
            objOItem_RelationType_belonging_Contractee = New clsOntologyItem
            objOItem_RelationType_belonging_Contractee.GUID = objOList_relationtype_belonging_contractee(0).ID_Other
            objOItem_RelationType_belonging_Contractee.Name = objOList_relationtype_belonging_contractee(0).Name_Other
            objOItem_RelationType_belonging_Contractee.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_contractor = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belonging_contractor" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belonging_contractor.Count > 0 Then
            objOItem_RelationType_belonging_Contractor = New clsOntologyItem
            objOItem_RelationType_belonging_Contractor.GUID = objOList_relationtype_belonging_contractor(0).ID_Other
            objOItem_RelationType_belonging_Contractor.Name = objOList_relationtype_belonging_contractor(0).Name_Other
            objOItem_RelationType_belonging_Contractor.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_currency = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belonging_currency" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belonging_currency.Count > 0 Then
            objOItem_RelationType_belonging_Currency = New clsOntologyItem
            objOItem_RelationType_belonging_Currency.GUID = objOList_relationtype_belonging_currency(0).ID_Other
            objOItem_RelationType_belonging_Currency.Name = objOList_relationtype_belonging_currency(0).Name_Other
            objOItem_RelationType_belonging_Currency.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_payment = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belonging_payment" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belonging_payment.Count > 0 Then
            objOItem_RelationType_belonging_Payment = New clsOntologyItem
            objOItem_RelationType_belonging_Payment.GUID = objOList_relationtype_belonging_payment(0).ID_Other
            objOItem_RelationType_belonging_Payment.Name = objOList_relationtype_belonging_payment(0).Name_Other
            objOItem_RelationType_belonging_Payment.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_sem_item = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belonging_sem_item" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belonging_sem_item.Count > 0 Then
            objOItem_RelationType_belonging_Sem_Item = New clsOntologyItem
            objOItem_RelationType_belonging_Sem_Item.GUID = objOList_relationtype_belonging_sem_item(0).ID_Other
            objOItem_RelationType_belonging_Sem_Item.Name = objOList_relationtype_belonging_sem_item(0).Name_Other
            objOItem_RelationType_belonging_Sem_Item.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belonging_tax_rate = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belonging_tax_rate" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belonging_tax_rate.Count > 0 Then
            objOItem_RelationType_belonging_Tax_Rate = New clsOntologyItem
            objOItem_RelationType_belonging_Tax_Rate.GUID = objOList_relationtype_belonging_tax_rate(0).ID_Other
            objOItem_RelationType_belonging_Tax_Rate.Name = objOList_relationtype_belonging_tax_rate(0).Name_Other
            objOItem_RelationType_belonging_Tax_Rate.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_belongsto = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_belongsto" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_belongsto.Count > 0 Then
            objOItem_RelationType_belongsTo = New clsOntologyItem
            objOItem_RelationType_belongsTo.GUID = objOList_relationtype_belongsto(0).ID_Other
            objOItem_RelationType_belongsTo.Name = objOList_relationtype_belongsto(0).Name_Other
            objOItem_RelationType_belongsTo.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_contains = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_contains" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_contains.Count > 0 Then
            objOItem_RelationType_contains = New clsOntologyItem
            objOItem_RelationType_contains.GUID = objOList_relationtype_contains(0).ID_Other
            objOItem_RelationType_contains.Name = objOList_relationtype_contains(0).Name_Other
            objOItem_RelationType_contains.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_gegenkonto = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_gegenkonto" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_gegenkonto.Count > 0 Then
            objOItem_RelationType_Gegenkonto = New clsOntologyItem
            objOItem_RelationType_Gegenkonto.GUID = objOList_relationtype_gegenkonto(0).ID_Other
            objOItem_RelationType_Gegenkonto.Name = objOList_relationtype_gegenkonto(0).Name_Other
            objOItem_RelationType_Gegenkonto.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_is_of_type = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_is_of_type" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_is_of_type.Count > 0 Then
            objOItem_RelationType_is_of_Type = New clsOntologyItem
            objOItem_RelationType_is_of_Type.GUID = objOList_relationtype_is_of_type(0).ID_Other
            objOItem_RelationType_is_of_Type.Name = objOList_relationtype_is_of_type(0).Name_Other
            objOItem_RelationType_is_of_Type.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_isdescribedby = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_isdescribedby" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_isdescribedby.Count > 0 Then
            objOItem_RelationType_isDescribedBy = New clsOntologyItem
            objOItem_RelationType_isDescribedBy.GUID = objOList_relationtype_isdescribedby(0).ID_Other
            objOItem_RelationType_isDescribedBy.Name = objOList_relationtype_isdescribedby(0).Name_Other
            objOItem_RelationType_isDescribedBy.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_located_in = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_located_in" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_located_in.Count > 0 Then
            objOItem_RelationType_located_in = New clsOntologyItem
            objOItem_RelationType_located_in.GUID = objOList_relationtype_located_in(0).ID_Other
            objOItem_RelationType_located_in.Name = objOList_relationtype_located_in(0).Name_Other
            objOItem_RelationType_located_in.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_offered_by = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_offered_by" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_offered_by.Count > 0 Then
            objOItem_RelationType_offered_by = New clsOntologyItem
            objOItem_RelationType_offered_by.GUID = objOList_relationtype_offered_by(0).ID_Other
            objOItem_RelationType_offered_by.Name = objOList_relationtype_offered_by(0).Name_Other
            objOItem_RelationType_offered_by.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_offers = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_offers" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_offers.Count > 0 Then
            objOItem_RelationType_offers = New clsOntologyItem
            objOItem_RelationType_offers.GUID = objOList_relationtype_offers(0).ID_Other
            objOItem_RelationType_offers.Name = objOList_relationtype_offers(0).Name_Other
            objOItem_RelationType_offers.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_standard = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_standard" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_standard.Count > 0 Then
            objOItem_RelationType_Standard = New clsOntologyItem
            objOItem_RelationType_Standard.GUID = objOList_relationtype_standard(0).ID_Other
            objOItem_RelationType_Standard.Name = objOList_relationtype_standard(0).Name_Other
            objOItem_RelationType_Standard.Type = objGlobals.Type_RelationType
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
        Dim objOList_token_direction_down = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "token_direction_down" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_direction_down.Count > 0 Then
            objOItem_Object_Direction_Down = New clsOntologyItem
            objOItem_Object_Direction_Down.GUID = objOList_token_direction_down(0).ID_Other
            objOItem_Object_Direction_Down.Name = objOList_token_direction_down(0).Name_Other
            objOItem_Object_Direction_Down.GUID_Parent = objOList_token_direction_down(0).ID_Parent_Other
            objOItem_Object_Direction_Down.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_direction_up = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_direction_up" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_direction_up.Count > 0 Then
            objOItem_Object_Direction_Up = New clsOntologyItem
            objOItem_Object_Direction_Up.GUID = objOList_token_direction_up(0).ID_Other
            objOItem_Object_Direction_Up.Name = objOList_token_direction_up(0).Name_Other
            objOItem_Object_Direction_Up.GUID_Parent = objOList_token_direction_up(0).ID_Parent_Other
            objOItem_Object_Direction_Up.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_module_bill_module = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_module_bill_module" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_module_bill_module.Count > 0 Then
            objOItem_Object_Module_Bill_Module = New clsOntologyItem
            objOItem_Object_Module_Bill_Module.GUID = objOList_token_module_bill_module(0).ID_Other
            objOItem_Object_Module_Bill_Module.Name = objOList_token_module_bill_module(0).Name_Other
            objOItem_Object_Module_Bill_Module.GUID_Parent = objOList_token_module_bill_module(0).ID_Parent_Other
            objOItem_Object_Module_Bill_Module.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_amount_ = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_search_template_amount_" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_search_template_amount_.Count > 0 Then
            objOItem_Object_Search_Template_Amount_ = New clsOntologyItem
            objOItem_Object_Search_Template_Amount_.GUID = objOList_token_search_template_amount_(0).ID_Other
            objOItem_Object_Search_Template_Amount_.Name = objOList_token_search_template_amount_(0).Name_Other
            objOItem_Object_Search_Template_Amount_.GUID_Parent = objOList_token_search_template_amount_(0).ID_Parent_Other
            objOItem_Object_Search_Template_Amount_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_contractee_contractor_ = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_search_template_contractee_contractor_" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_search_template_contractee_contractor_.Count > 0 Then
            objOItem_Object_Search_Template_Contractee_Contractor_ = New clsOntologyItem
            objOItem_Object_Search_Template_Contractee_Contractor_.GUID = objOList_token_search_template_contractee_contractor_(0).ID_Other
            objOItem_Object_Search_Template_Contractee_Contractor_.Name = objOList_token_search_template_contractee_contractor_(0).Name_Other
            objOItem_Object_Search_Template_Contractee_Contractor_.GUID_Parent = objOList_token_search_template_contractee_contractor_(0).ID_Parent_Other
            objOItem_Object_Search_Template_Contractee_Contractor_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_name_ = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_search_template_name_" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_search_template_name_.Count > 0 Then
            objOItem_Object_Search_Template_Name_ = New clsOntologyItem
            objOItem_Object_Search_Template_Name_.GUID = objOList_token_search_template_name_(0).ID_Other
            objOItem_Object_Search_Template_Name_.Name = objOList_token_search_template_name_(0).Name_Other
            objOItem_Object_Search_Template_Name_.GUID_Parent = objOList_token_search_template_name_(0).ID_Parent_Other
            objOItem_Object_Search_Template_Name_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_payment_date_ = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_search_template_payment_date_" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_search_template_payment_date_.Count > 0 Then
            objOItem_Object_Search_Template_Payment_Date_ = New clsOntologyItem
            objOItem_Object_Search_Template_Payment_Date_.GUID = objOList_token_search_template_payment_date_(0).ID_Other
            objOItem_Object_Search_Template_Payment_Date_.Name = objOList_token_search_template_payment_date_(0).Name_Other
            objOItem_Object_Search_Template_Payment_Date_.GUID_Parent = objOList_token_search_template_payment_date_(0).ID_Parent_Other
            objOItem_Object_Search_Template_Payment_Date_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_related_sem_item_ = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_search_template_related_sem_item_" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_search_template_related_sem_item_.Count > 0 Then
            objOItem_Object_Search_Template_Related_Sem_Item_ = New clsOntologyItem
            objOItem_Object_Search_Template_Related_Sem_Item_.GUID = objOList_token_search_template_related_sem_item_(0).ID_Other
            objOItem_Object_Search_Template_Related_Sem_Item_.Name = objOList_token_search_template_related_sem_item_(0).Name_Other
            objOItem_Object_Search_Template_Related_Sem_Item_.GUID_Parent = objOList_token_search_template_related_sem_item_(0).ID_Parent_Other
            objOItem_Object_Search_Template_Related_Sem_Item_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_to_pay_ = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_search_template_to_pay_" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_search_template_to_pay_.Count > 0 Then
            objOItem_Object_Search_Template_to_Pay_ = New clsOntologyItem
            objOItem_Object_Search_Template_to_Pay_.GUID = objOList_token_search_template_to_pay_(0).ID_Other
            objOItem_Object_Search_Template_to_Pay_.Name = objOList_token_search_template_to_pay_(0).Name_Other
            objOItem_Object_Search_Template_to_Pay_.GUID_Parent = objOList_token_search_template_to_pay_(0).ID_Parent_Other
            objOItem_Object_Search_Template_to_Pay_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_search_template_transaction_date_ = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_search_template_transaction_date_" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_search_template_transaction_date_.Count > 0 Then
            objOItem_Object_Search_Template_Transaction_Date_ = New clsOntologyItem
            objOItem_Object_Search_Template_Transaction_Date_.GUID = objOList_token_search_template_transaction_date_(0).ID_Other
            objOItem_Object_Search_Template_Transaction_Date_.Name = objOList_token_search_template_transaction_date_(0).Name_Other
            objOItem_Object_Search_Template_Transaction_Date_.GUID_Parent = objOList_token_search_template_transaction_date_(0).ID_Parent_Other
            objOItem_Object_Search_Template_Transaction_Date_.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_token_software_development_bill_module = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "token_software_development_bill_module" And obj.Ontology = objGlobals.Type_Object

        If objOList_token_software_development_bill_module.Count > 0 Then
            objOItem_Object_Software_Development_Bill_Module = New clsOntologyItem
            objOItem_Object_Software_Development_Bill_Module.GUID = objOList_token_software_development_bill_module(0).ID_Other
            objOItem_Object_Software_Development_Bill_Module.Name = objOList_token_software_development_bill_module(0).Name_Other
            objOItem_Object_Software_Development_Bill_Module.GUID_Parent = objOList_token_software_development_bill_module(0).ID_Parent_Other
            objOItem_Object_Software_Development_Bill_Module.Type = objGlobals.Type_Object
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_Classes()
        Dim objOList_type_bank_transaktionen__sparkasse_ = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "type_bank_transaktionen__sparkasse_" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_bank_transaktionen__sparkasse_.Count > 0 Then
            objOItem_Class_Bank_Transaktionen__Sparkasse_ = New clsOntologyItem
            objOItem_Class_Bank_Transaktionen__Sparkasse_.GUID = objOList_type_bank_transaktionen__sparkasse_(0).ID_Other
            objOItem_Class_Bank_Transaktionen__Sparkasse_.Name = objOList_type_bank_transaktionen__sparkasse_(0).Name_Other
            objOItem_Class_Bank_Transaktionen__Sparkasse_.GUID_Parent = objOList_type_bank_transaktionen__sparkasse_(0).ID_Parent_Other
            objOItem_Class_Bank_Transaktionen__Sparkasse_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_bank_transaktionen__sparkasse____archiv = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_bank_transaktionen__sparkasse____archiv" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_bank_transaktionen__sparkasse____archiv.Count > 0 Then
            objOItem_Class_Bank_Transaktionen__Sparkasse____Archiv = New clsOntologyItem
            objOItem_Class_Bank_Transaktionen__Sparkasse____Archiv.GUID = objOList_type_bank_transaktionen__sparkasse____archiv(0).ID_Other
            objOItem_Class_Bank_Transaktionen__Sparkasse____Archiv.Name = objOList_type_bank_transaktionen__sparkasse____archiv(0).Name_Other
            objOItem_Class_Bank_Transaktionen__Sparkasse____Archiv.GUID_Parent = objOList_type_bank_transaktionen__sparkasse____archiv(0).ID_Parent_Other
            objOItem_Class_Bank_Transaktionen__Sparkasse____Archiv.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_bankleitzahl = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_bankleitzahl" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_bankleitzahl.Count > 0 Then
            objOItem_Class_Bankleitzahl = New clsOntologyItem
            objOItem_Class_Bankleitzahl.GUID = objOList_type_bankleitzahl(0).ID_Other
            objOItem_Class_Bankleitzahl.Name = objOList_type_bankleitzahl(0).Name_Other
            objOItem_Class_Bankleitzahl.GUID_Parent = objOList_type_bankleitzahl(0).ID_Parent_Other
            objOItem_Class_Bankleitzahl.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_beleg = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_beleg" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_beleg.Count > 0 Then
            objOItem_Class_Beleg = New clsOntologyItem
            objOItem_Class_Beleg.GUID = objOList_type_beleg(0).ID_Other
            objOItem_Class_Beleg.Name = objOList_type_beleg(0).Name_Other
            objOItem_Class_Beleg.GUID_Parent = objOList_type_beleg(0).ID_Parent_Other
            objOItem_Class_Beleg.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_belegsart = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_belegsart" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_belegsart.Count > 0 Then
            objOItem_Class_Belegsart = New clsOntologyItem
            objOItem_Class_Belegsart.GUID = objOList_type_belegsart(0).ID_Other
            objOItem_Class_Belegsart.Name = objOList_type_belegsart(0).Name_Other
            objOItem_Class_Belegsart.GUID_Parent = objOList_type_belegsart(0).ID_Parent_Other
            objOItem_Class_Belegsart.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_bill_module = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_bill_module" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_bill_module.Count > 0 Then
            objOItem_Class_Bill_Module = New clsOntologyItem
            objOItem_Class_Bill_Module.GUID = objOList_type_bill_module(0).ID_Other
            objOItem_Class_Bill_Module.Name = objOList_type_bill_module(0).Name_Other
            objOItem_Class_Bill_Module.GUID_Parent = objOList_type_bill_module(0).ID_Parent_Other
            objOItem_Class_Bill_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_container__physical_ = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_container__physical_" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_container__physical_.Count > 0 Then
            objOItem_Class_Container__physical_ = New clsOntologyItem
            objOItem_Class_Container__physical_.GUID = objOList_type_container__physical_(0).ID_Other
            objOItem_Class_Container__physical_.Name = objOList_type_container__physical_(0).Name_Other
            objOItem_Class_Container__physical_.GUID_Parent = objOList_type_container__physical_(0).ID_Parent_Other
            objOItem_Class_Container__physical_.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_currencies = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_currencies" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_currencies.Count > 0 Then
            objOItem_Class_Currencies = New clsOntologyItem
            objOItem_Class_Currencies.GUID = objOList_type_currencies(0).ID_Other
            objOItem_Class_Currencies.Name = objOList_type_currencies(0).Name_Other
            objOItem_Class_Currencies.GUID_Parent = objOList_type_currencies(0).ID_Parent_Other
            objOItem_Class_Currencies.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_einheit = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_einheit" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_einheit.Count > 0 Then
            objOItem_Class_Einheit = New clsOntologyItem
            objOItem_Class_Einheit.GUID = objOList_type_einheit(0).ID_Other
            objOItem_Class_Einheit.Name = objOList_type_einheit(0).Name_Other
            objOItem_Class_Einheit.GUID_Parent = objOList_type_einheit(0).ID_Parent_Other
            objOItem_Class_Einheit.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_financial_transaction = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_financial_transaction" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_financial_transaction.Count > 0 Then
            objOItem_Class_Financial_Transaction = New clsOntologyItem
            objOItem_Class_Financial_Transaction.GUID = objOList_type_financial_transaction(0).ID_Other
            objOItem_Class_Financial_Transaction.Name = objOList_type_financial_transaction(0).Name_Other
            objOItem_Class_Financial_Transaction.GUID_Parent = objOList_type_financial_transaction(0).ID_Parent_Other
            objOItem_Class_Financial_Transaction.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_financial_transaction___archive = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_financial_transaction___archive" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_financial_transaction___archive.Count > 0 Then
            objOItem_Class_Financial_Transaction___Archive = New clsOntologyItem
            objOItem_Class_Financial_Transaction___Archive.GUID = objOList_type_financial_transaction___archive(0).ID_Other
            objOItem_Class_Financial_Transaction___Archive.Name = objOList_type_financial_transaction___archive(0).Name_Other
            objOItem_Class_Financial_Transaction___Archive.GUID_Parent = objOList_type_financial_transaction___archive(0).ID_Parent_Other
            objOItem_Class_Financial_Transaction___Archive.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_kontonummer = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_kontonummer" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_kontonummer.Count > 0 Then
            objOItem_Class_Kontonummer = New clsOntologyItem
            objOItem_Class_Kontonummer.GUID = objOList_type_kontonummer(0).ID_Other
            objOItem_Class_Kontonummer.Name = objOList_type_kontonummer(0).Name_Other
            objOItem_Class_Kontonummer.GUID_Parent = objOList_type_kontonummer(0).ID_Parent_Other
            objOItem_Class_Kontonummer.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_language = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_language" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_language.Count > 0 Then
            objOItem_Class_Language = New clsOntologyItem
            objOItem_Class_Language.GUID = objOList_type_language(0).ID_Other
            objOItem_Class_Language.Name = objOList_type_language(0).Name_Other
            objOItem_Class_Language.GUID_Parent = objOList_type_language(0).ID_Parent_Other
            objOItem_Class_Language.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_menge = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_menge" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_menge.Count > 0 Then
            objOItem_Class_Menge = New clsOntologyItem
            objOItem_Class_Menge.GUID = objOList_type_menge(0).ID_Other
            objOItem_Class_Menge.Name = objOList_type_menge(0).Name_Other
            objOItem_Class_Menge.GUID_Parent = objOList_type_menge(0).ID_Parent_Other
            objOItem_Class_Menge.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_module = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_module" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_module.Count > 0 Then
            objOItem_Class_Module = New clsOntologyItem
            objOItem_Class_Module.GUID = objOList_type_module(0).ID_Other
            objOItem_Class_Module.Name = objOList_type_module(0).Name_Other
            objOItem_Class_Module.GUID_Parent = objOList_type_module(0).ID_Parent_Other
            objOItem_Class_Module.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_offset = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_offset" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_offset.Count > 0 Then
            objOItem_Class_Offset = New clsOntologyItem
            objOItem_Class_Offset.GUID = objOList_type_offset(0).ID_Other
            objOItem_Class_Offset.Name = objOList_type_offset(0).Name_Other
            objOItem_Class_Offset.GUID_Parent = objOList_type_offset(0).ID_Parent_Other
            objOItem_Class_Offset.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_partner = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_partner" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_partner.Count > 0 Then
            objOItem_Class_Partner = New clsOntologyItem
            objOItem_Class_Partner.GUID = objOList_type_partner(0).ID_Other
            objOItem_Class_Partner.Name = objOList_type_partner(0).Name_Other
            objOItem_Class_Partner.GUID_Parent = objOList_type_partner(0).ID_Parent_Other
            objOItem_Class_Partner.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_payment = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_payment" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_payment.Count > 0 Then
            objOItem_Class_Payment = New clsOntologyItem
            objOItem_Class_Payment.GUID = objOList_type_payment(0).ID_Other
            objOItem_Class_Payment.Name = objOList_type_payment(0).Name_Other
            objOItem_Class_Payment.GUID_Parent = objOList_type_payment(0).ID_Parent_Other
            objOItem_Class_Payment.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_search_template = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_search_template" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_search_template.Count > 0 Then
            objOItem_Class_Search_Template = New clsOntologyItem
            objOItem_Class_Search_Template.GUID = objOList_type_search_template(0).ID_Other
            objOItem_Class_Search_Template.Name = objOList_type_search_template(0).Name_Other
            objOItem_Class_Search_Template.GUID_Parent = objOList_type_search_template(0).ID_Parent_Other
            objOItem_Class_Search_Template.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_tax_rates = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_tax_rates" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_tax_rates.Count > 0 Then
            objOItem_Class_Tax_Rates = New clsOntologyItem
            objOItem_Class_Tax_Rates.GUID = objOList_type_tax_rates(0).ID_Other
            objOItem_Class_Tax_Rates.Name = objOList_type_tax_rates(0).Name_Other
            objOItem_Class_Tax_Rates.GUID_Parent = objOList_type_tax_rates(0).ID_Parent_Other
            objOItem_Class_Tax_Rates.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If


    End Sub
End Class
