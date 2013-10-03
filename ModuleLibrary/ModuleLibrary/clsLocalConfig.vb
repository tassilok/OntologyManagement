Imports Ontolog_Module
Imports OntologyClasses.BaseClasses
Public Class clsLocalConfig
    Private cstr_ID_SoftwareDevelopment As String = "34fec72096274e368220cfbfc84ec4aa"
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
        Dim objOList_attribute_menge = From obj In objDBLevel_Config2.OList_ObjectRel
                                  Where obj.Name_Object.ToLower = "attribute_menge" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_menge.Count > 0 Then
            objOItem_attribute_menge = New clsOntologyItem
            objOItem_attribute_menge.GUID = objOList_attribute_menge(0).ID_Other
            objOItem_attribute_menge.Name = objOList_attribute_menge(0).Name_Other
            objOItem_attribute_menge.GUID_Parent = objOList_attribute_menge(0).ID_Parent_Other
            objOItem_attribute_menge.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_attribute_id = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_id" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_id.Count > 0 Then
            objOItem_attribute_id = New clsOntologyItem
            objOItem_attribute_id.GUID = objOList_attribute_id(0).ID_Other
            objOItem_attribute_id.Name = objOList_attribute_id(0).Name_Other
            objOItem_attribute_id.GUID_Parent = objOList_attribute_id(0).ID_Parent_Other
            objOItem_attribute_id.Type = objGlobals.Type_AttributeType
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


    End Sub

    Private Sub get_Config_RelationTypes()
        Dim objOList_relationtype_z = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "relationtype_z" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_z.Count > 0 Then
            objOItem_relationtype_z = New clsOntologyItem
            objOItem_relationtype_z.GUID = objOList_relationtype_z(0).ID_Other
            objOItem_relationtype_z.Name = objOList_relationtype_z(0).Name_Other
            objOItem_relationtype_z.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_y = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_y" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_y.Count > 0 Then
            objOItem_relationtype_y = New clsOntologyItem
            objOItem_relationtype_y.GUID = objOList_relationtype_y(0).ID_Other
            objOItem_relationtype_y.Name = objOList_relationtype_y(0).Name_Other
            objOItem_relationtype_y.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_x = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_x" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_x.Count > 0 Then
            objOItem_relationtype_x = New clsOntologyItem
            objOItem_relationtype_x.GUID = objOList_relationtype_x(0).ID_Other
            objOItem_relationtype_x.Name = objOList_relationtype_x(0).Name_Other
            objOItem_relationtype_x.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_relationtype_is_of_type = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_is_of_type" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_is_of_type.Count > 0 Then
            objOItem_relationtype_is_of_type = New clsOntologyItem
            objOItem_relationtype_is_of_type.GUID = objOList_relationtype_is_of_type(0).ID_Other
            objOItem_relationtype_is_of_type.Name = objOList_relationtype_is_of_type(0).Name_Other
            objOItem_relationtype_is_of_type.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_Objects()

    End Sub

    Private Sub get_Config_Classes()
        Dim objOList_type_year = From obj In objDBLevel_Config2.OList_ObjectRel
                          Where obj.Name_Object.ToLower = "type_year" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_year.Count > 0 Then
            objOItem_type_year = New clsOntologyItem
            objOItem_type_year.GUID = objOList_type_year(0).ID_Other
            objOItem_type_year.Name = objOList_type_year(0).Name_Other
            objOItem_type_year.GUID_Parent = objOList_type_year(0).ID_Parent_Other
            objOItem_type_year.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_volumen = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_volumen" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_volumen.Count > 0 Then
            objOItem_type_volumen = New clsOntologyItem
            objOItem_type_volumen.GUID = objOList_type_volumen(0).ID_Other
            objOItem_type_volumen.Name = objOList_type_volumen(0).Name_Other
            objOItem_type_volumen.GUID_Parent = objOList_type_volumen(0).ID_Parent_Other
            objOItem_type_volumen.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_partner = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_partner" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_partner.Count > 0 Then
            objOItem_type_partner = New clsOntologyItem
            objOItem_type_partner.GUID = objOList_type_partner(0).ID_Other
            objOItem_type_partner.Name = objOList_type_partner(0).Name_Other
            objOItem_type_partner.GUID_Parent = objOList_type_partner(0).ID_Parent_Other
            objOItem_type_partner.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_month = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_month" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_month.Count > 0 Then
            objOItem_type_month = New clsOntologyItem
            objOItem_type_month.GUID = objOList_type_month(0).ID_Other
            objOItem_type_month.Name = objOList_type_month(0).Name_Other
            objOItem_type_month.GUID_Parent = objOList_type_month(0).ID_Parent_Other
            objOItem_type_month.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_menge = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_menge" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_menge.Count > 0 Then
            objOItem_type_menge = New clsOntologyItem
            objOItem_type_menge.GUID = objOList_type_menge(0).ID_Other
            objOItem_type_menge.Name = objOList_type_menge(0).Name_Other
            objOItem_type_menge.GUID_Parent = objOList_type_menge(0).ID_Parent_Other
            objOItem_type_menge.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_fl_che = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_fl_che" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_fl_che.Count > 0 Then
            objOItem_type_fl_che = New clsOntologyItem
            objOItem_type_fl_che.GUID = objOList_type_fl_che(0).ID_Other
            objOItem_type_fl_che.Name = objOList_type_fl_che(0).Name_Other
            objOItem_type_fl_che.GUID_Parent = objOList_type_fl_che(0).ID_Parent_Other
            objOItem_type_fl_che.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_einheit = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_einheit" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_einheit.Count > 0 Then
            objOItem_type_einheit = New clsOntologyItem
            objOItem_type_einheit.GUID = objOList_type_einheit(0).ID_Other
            objOItem_type_einheit.Name = objOList_type_einheit(0).Name_Other
            objOItem_type_einheit.GUID_Parent = objOList_type_einheit(0).ID_Parent_Other
            objOItem_type_einheit.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_day = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_day" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_day.Count > 0 Then
            objOItem_type_day = New clsOntologyItem
            objOItem_type_day.GUID = objOList_type_day(0).ID_Other
            objOItem_type_day.Name = objOList_type_day(0).Name_Other
            objOItem_type_day.GUID_Parent = objOList_type_day(0).ID_Parent_Other
            objOItem_type_day.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If


    End Sub
End Class
