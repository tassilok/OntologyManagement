Imports Ontolog_Module
Public Class clsLocalConfig
    Private cstr_ID_SoftwareDevelopment As String = "105f328b05dc4498abfd6ca06470c19a"
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

    Private objOItem_Attribute_DateTimeStamp As New clsOntologyItem
    Private objOItem_attribute_dbPostfix As New clsOntologyItem
    Private objOItem_Attribute_Message As New clsOntologyItem
    Private objOItem_RelationType_belongsTo As New clsOntologyItem
    Private objOItem_RelationType_provides As New clsOntologyItem
    Private objOItem_RelationType_wasCreatedBy As New clsOntologyItem
    Private objOItem_Type_LogEntry As New clsOntologyItem
    Private objOItem_type_Logstate As New clsOntologyItem
    Private objOItem_type_User As New clsOntologyItem


    Public ReadOnly Property OItem_Attribute_DateTimeStamp() As clsOntologyItem
        Get
            Return objOItem_Attribute_DateTimeStamp
        End Get
    End Property

    Public ReadOnly Property OItem_attribute_dbPostfix() As clsOntologyItem
        Get
            Return objOItem_attribute_dbPostfix
        End Get
    End Property

    Public ReadOnly Property OItem_Attribute_Message() As clsOntologyItem
        Get
            Return objOItem_Attribute_Message
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_belongsTo() As clsOntologyItem
        Get
            Return objOItem_RelationType_belongsTo
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_provides() As clsOntologyItem
        Get
            Return objOItem_RelationType_provides
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType_wasCreatedBy() As clsOntologyItem
        Get
            Return objOItem_RelationType_wasCreatedBy
        End Get
    End Property

    Public ReadOnly Property OItem_Type_LogEntry() As clsOntologyItem
        Get
            Return objOItem_Type_LogEntry
        End Get
    End Property

    Public ReadOnly Property OItem_type_Logstate() As clsOntologyItem
        Get
            Return objOItem_type_Logstate
        End Get
    End Property

    Public ReadOnly Property OItem_type_User() As clsOntologyItem
        Get
            Return objOItem_type_User
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

    Private Sub get_Config_AttributeTypes()
        Dim objOList_attribute_datetimestamp = From obj In objDBLevel_Config2.OList_ObjectRel
                                  Where obj.Name_Object.ToLower = "attribute_datetimestamp" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_datetimestamp.Count > 0 Then
            objOItem_attribute_datetimestamp = New clsOntologyItem
            objOItem_attribute_datetimestamp.GUID = objOList_attribute_datetimestamp(0).ID_Other
            objOItem_attribute_datetimestamp.Name = objOList_attribute_datetimestamp(0).Name_Other
            objOItem_attribute_datetimestamp.GUID_Parent = objOList_attribute_datetimestamp(0).ID_Parent_Other
            objOItem_attribute_datetimestamp.Type = objGlobals.Type_AttributeType
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

        Dim objOList_attribute_message = From obj In objDBLevel_Config2.OList_ObjectRel
                                    Where obj.Name_Object.ToLower = "attribute_message" And obj.Ontology = objGlobals.Type_AttributeType

        If objOList_attribute_message.Count > 0 Then
            objOItem_attribute_message = New clsOntologyItem
            objOItem_attribute_message.GUID = objOList_attribute_message(0).ID_Other
            objOItem_attribute_message.Name = objOList_attribute_message(0).Name_Other
            objOItem_attribute_message.GUID_Parent = objOList_attribute_message(0).ID_Parent_Other
            objOItem_attribute_message.Type = objGlobals.Type_AttributeType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_RelationTypes()
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

        Dim objOList_relationtype_wascreatedby = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "relationtype_wascreatedby" And obj.Ontology = objGlobals.Type_RelationType

        If objOList_relationtype_wascreatedby.Count > 0 Then
            objOItem_relationtype_wascreatedby = New clsOntologyItem
            objOItem_relationtype_wascreatedby.GUID = objOList_relationtype_wascreatedby(0).ID_Other
            objOItem_relationtype_wascreatedby.Name = objOList_relationtype_wascreatedby(0).Name_Other
            objOItem_relationtype_wascreatedby.Type = objGlobals.Type_RelationType
        Else
            Err.Raise(1, "config err")
        End If


    End Sub

    Private Sub get_Config_Objects()

    End Sub

    Private Sub get_Config_Classes()
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

        Dim objOList_type_logstate = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_logstate" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_logstate.Count > 0 Then
            objOItem_type_logstate = New clsOntologyItem
            objOItem_type_logstate.GUID = objOList_type_logstate(0).ID_Other
            objOItem_type_logstate.Name = objOList_type_logstate(0).Name_Other
            objOItem_type_logstate.GUID_Parent = objOList_type_logstate(0).ID_Parent_Other
            objOItem_type_logstate.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If

        Dim objOList_type_user = From obj In objDBLevel_Config2.OList_ObjectRel
                            Where obj.Name_Object.ToLower = "type_user" And obj.Ontology = objGlobals.Type_Class

        If objOList_type_user.Count > 0 Then
            objOItem_type_user = New clsOntologyItem
            objOItem_type_user.GUID = objOList_type_user(0).ID_Other
            objOItem_type_user.Name = objOList_type_user(0).Name_Other
            objOItem_type_user.GUID_Parent = objOList_type_user(0).ID_Parent_Other
            objOItem_type_user.Type = objGlobals.Type_Class
        Else
            Err.Raise(1, "config err")
        End If


    End Sub
End Class
