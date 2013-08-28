Imports System.Text.RegularExpressions
Imports System.Management

Public Class clsGlobals

    Private objFields As New clsFields

    Private objTypes As New clsTypes

    Private objDataTypes As New clsDataTypes

    Private objClasses As New clsClasses

    Private objRelationTypes As New clsRelationTypes

    Private objAttributeTypes As New clsAttributeTypes

    Private objLogStates As New clsLogStates

    Private objDirections As New clsDirections

    Private objClassTypes As New clsClassTypes
    
    Private strEL_Server As String
    Private strEL_Port As String
    Private strEL_Index As String
    Private strRep_Index As String

    Private strRep_Server As String
    Private strRep_Instance As String
    Private strRep_Database As String

    Private cintSearchRange As Integer = 20000

    

    


    Private strRegEx_GUID As String

    Private objORule_ChildObjects As clsOntologyItem
    Private objORule_LeftOuterJoin As clsOntologyItem
    Private objORule_NameOfTypeParse As clsOntologyItem
    Private objORule_ParentClasses As clsOntologyItem
    Private objORule_RelationBreak As clsOntologyItem
    Private objORule_OnlyItem As clsOntologyItem

    Private objELSearchResult As ElasticSearch.Client.Domain.SearchResult
    Private objELQuery As ElasticSearch.Client.QueryDSL.BoolQuery

    Private dtblT_Config As New DataSet_Config.dtbl_BaseConfigDataTable

    Private GUID_Session As String

    Private strPath_Config As String

    Private objOItem_Server As clsOntologyItem
    Private objOItem_WMI_ProcessorID As clsOntologyItem
    Private objOItem_WMI_BaseBoardSerial As clsOntologyItem

    Private objDBLevel1 As clsDBLevel
    Private objDBLevel2 As clsDBLevel

    Private objTransaction As clsTransaction

    Public ReadOnly Property OItem_Server As clsOntologyItem
        Get
            Return objOItem_Server
        End Get
    End Property

    Public ReadOnly Property ClassType_OntologyItem As String
        Get
            Return objClassTypes.ClassType_OntologyItem

        End Get
    End Property

    Public ReadOnly Property ClassType_ObjectAtt As String
        Get
            Return objClassTypes.ClassType_ObjectAtt
        End Get
    End Property

    Public ReadOnly Property ClassType_ObjectRel As String
        Get
            Return objClassTypes.ClassType_ObjectRel
        End Get
    End Property

    Public ReadOnly Property ClassType_ClassAtt As String
        Get
            Return objClassTypes.ClassType_ClassAtt
        End Get
    End Property

    Public ReadOnly Property ClassType_ClassRel As String
        Get
            Return objClassTypes.ClassType_ObjectRel
        End Get
    End Property

    Public ReadOnly Property NewGUID As String
        Get
            Return Guid.NewGuid.ToString.Replace("-", "")
        End Get
    End Property

    Public ReadOnly Property Class_Ontologies As clsOntologyItem
        Get
            Return objClasses.OItem_Class_Ontologies
        End Get
    End Property

    Public ReadOnly Property Class_OntologyItems As clsOntologyItem
        Get
            Return objClasses.OItem_Class_OntologyItems
        End Get
    End Property

    Public ReadOnly Property Class_OntologyRelationRule As clsOntologyItem
        Get
            Return objClasses.OItem_Class_OntologyRelationRule
        End Get
    End Property

    Public ReadOnly Property Class_OntologyJoin As clsOntologyItem
        Get
            Return objClasses.OItem_Class_OntologyJoin
        End Get
    End Property

    
    Public Function get_ConnectionStr(ByVal strServer As String, ByVal strInstance As String, ByVal strDatabase As String) As String
        Dim strConn As String
        strConn = "Data Source=" & strServer
        If strInstance <> "" Then
            strConn = strConn & "\" & strInstance
        End If
        strConn = strConn & ";Initial Catalog=" & strDatabase & ";Integrated Security=True"

        Return strConn
    End Function

    Public ReadOnly Property RelationType_contains As clsOntologyItem
        Get
            Return objRelationTypes.OItem_RelationType_Contains
        End Get
    End Property

    Public ReadOnly Property RelationType_belongingAttribute As clsOntologyItem
        Get
            Return objRelationTypes.OItem_RelationType_belongingAttribute
        End Get
    End Property

    Public ReadOnly Property RelationType_belongingClass As clsOntologyItem
        Get
            Return objRelationTypes.OItem_RelationType_belongingClass
        End Get
    End Property

    Public ReadOnly Property RelationType_belongingObject As clsOntologyItem
        Get
            Return objRelationTypes.OItem_RelationType_belongingObject
        End Get
    End Property

    Public ReadOnly Property RelationType_belongingRelationType As clsOntologyItem
        Get
            Return objRelationTypes.OItem_RelationType_belongingRelationType
        End Get
    End Property

    Public ReadOnly Property RelationType_belonging As clsOntologyItem
        Get
            Return objRelationTypes.OItem_RelationType_belonging
        End Get
    End Property

    Public ReadOnly Property Rep_Server As String
        Get
            Return strRep_Server
        End Get
    End Property
    Public ReadOnly Property Rep_Instance As String
        Get
            Return strRep_Instance
        End Get
    End Property
    Public ReadOnly Property Rep_Database As String
        Get
            Return strRep_Database
        End Get
    End Property
    Public ReadOnly Property Session As String
        Get
            Return GUID_Session
        End Get
    End Property
    Public ReadOnly Property Port As String
        Get
            Return strEL_Port
        End Get
    End Property

    Public ReadOnly Property SearchRange As Integer
        Get
            Return cintSearchRange
        End Get
    End Property

    Public ReadOnly Property Server
        Get
            Return strEL_Server
        End Get
    End Property

    Public ReadOnly Property Index
        Get
            Return strEL_Index
        End Get
    End Property

    Public ReadOnly Property Index_Rep
        Get
            Return strRep_Index
        End Get
    End Property

    Public ReadOnly Property Type_AttributeType As String
        Get
            Return objTypes.AttributeType
        End Get
    End Property

    Public ReadOnly Property Type_Class As String
        Get
            Return objTypes.ClassType
        End Get
    End Property

    Public ReadOnly Property Type_DataType As String
        Get
            Return objTypes.DataType
        End Get
    End Property

    Public ReadOnly Property Type_Object As String
        Get
            Return objTypes.ObjectType
        End Get
    End Property

    Public ReadOnly Property Type_ObjectAtt As String
        Get
            Return objTypes.ObjectAtt
        End Get
    End Property

    Public ReadOnly Property Type_ObjectRel As String
        Get
            Return objTypes.ObjectRel
        End Get
    End Property

    Public ReadOnly Property Type_Other As String
        Get
            Return objTypes.Other
        End Get
    End Property

    Public ReadOnly Property Type_Other_AttType As String
        Get
            Return objTypes.Other_AttType
        End Get
    End Property

    Public ReadOnly Property Type_Other_Classes As String
        Get
            Return objTypes.Other_Classes
        End Get
    End Property

    Public ReadOnly Property Type_Other_RelType As String
        Get
            Return objTypes.Other_RelType
        End Get
    End Property

    Public ReadOnly Property Type_RelationType As String
        Get
            Return objTypes.RelationType
        End Get
    End Property


    Public ReadOnly Property Type_ClassRel As String
        Get
            Return objTypes.ClassRel
        End Get
    End Property

    Public ReadOnly Property Type_ClassAtt As String
        Get
            Return objTypes.ClassAtt
        End Get
    End Property


    'Fields
    Public ReadOnly Property Field_ID_Object As String
        Get
            Return objFields.ID_Object
        End Get
    End Property

    Public ReadOnly Property Field_ID_Item As String
        Get
            Return objFields.ID_Item
        End Get
    End Property

    Public ReadOnly Property Field_ID_Class_Left As String
        Get
            Return objFields.ID_Class_Left
        End Get
    End Property

    Public ReadOnly Property Field_ID_Class_Right As String
        Get
            Return objFields.ID_Class_Right
        End Get
    End Property

    Public ReadOnly Property Field_Max_forw As String
        Get
            Return objFields.Max_Forw
        End Get
    End Property

    Public ReadOnly Property Field_Min_forw As String
        Get
            Return objFields.Min_Forw
        End Get
    End Property

    Public ReadOnly Property Field_Min As String
        Get
            Return objFields.Min
        End Get
    End Property

    Public ReadOnly Property Field_Max As String
        Get
            Return objFields.Max
        End Get
    End Property

    Public ReadOnly Property Field_Max_backw As String
        Get
            Return objFields.Max_Backw
        End Get
    End Property

    Public ReadOnly Property Field_ID_AttributeType As String
        Get
            Return objFields.ID_AttributeType
        End Get
    End Property

    Public ReadOnly Property Field_ID_Class As String
        Get
            Return objFields.ID_Class
        End Get
    End Property

    Public ReadOnly Property Field_ID_DataType As String
        Get
            Return objFields.ID_DataType
        End Get
    End Property

    Public ReadOnly Property Field_Ontology As String
        Get
            Return objFields.Ontology
        End Get
    End Property

    Public ReadOnly Property Field_ID_Parent As String
        Get
            Return objFields.ID_Parent
        End Get
    End Property

    Public ReadOnly Property Field_ID_Parent_Object As String
        Get
            Return objFields.ID_Parent_Object
        End Get
    End Property

    Public ReadOnly Property Field_ID_Parent_Other As String
        Get
            Return objFields.ID_Parent_Other
        End Get
    End Property

    Public ReadOnly Property Field_ID_RelationType As String
        Get
            Return objFields.ID_RelationType
        End Get
    End Property

    Public ReadOnly Property Field_ID_Other As String
        Get
            Return objFields.ID_Other
        End Get
    End Property

    Public ReadOnly Property Field_Name_AttributeType As String
        Get
            Return objFields.Name_AttributeType
        End Get
    End Property

    Public ReadOnly Property Field_Name_Object As String
        Get
            Return objFields.Name_Object
        End Get
    End Property

    Public ReadOnly Property Field_Name_Other As String
        Get
            Return objFields.Name_Other
        End Get
    End Property

    Public ReadOnly Property Field_Name_Item As String
        Get
            Return objFields.Name_Item
        End Get
    End Property

    Public ReadOnly Property Field_Name_RelationType As String
        Get
            Return objFields.Name_RelationType
        End Get
    End Property

    Public ReadOnly Property Field_OrderID As String
        Get
            Return objFields.OrderID
        End Get
    End Property

    Public ReadOnly Property Field_Val_Bool As String
        Get
            Return objFields.Val_Bool
        End Get
    End Property

    Public ReadOnly Property Field_Val_Datetime As String
        Get
            Return objFields.Val_Datetime
        End Get
    End Property

    Public ReadOnly Property Field_Val_Int As String
        Get
            Return objFields.Val_Int
        End Get
    End Property

    Public ReadOnly Property Field_Val_Real As String
        Get
            Return objFields.Val_Real
        End Get
    End Property

    Public ReadOnly Property Field_Val_String As String
        Get
            Return objFields.Val_String
        End Get
    End Property

    Public ReadOnly Property Field_Val_Name As String
        Get
            Return objFields.Val_Name
        End Get
    End Property

    Public ReadOnly Property Field_ID_Attribute As String
        Get
            Return objFields.ID_Attribute
        End Get
    End Property

    Public ReadOnly Property Root As clsOntologyItem
        Get
            Return objClasses.OItem_Class_Root
        End Get
    End Property

    Public ReadOnly Property DType_Bool As clsOntologyItem
        Get
            Return objDataTypes.DType_Bool
        End Get
    End Property

    Public ReadOnly Property DType_DateTime As clsOntologyItem
        Get
            Return objDataTypes.DType_DateTime
        End Get
    End Property

    Public ReadOnly Property DType_Int As clsOntologyItem
        Get
            Return objDataTypes.DType_Int
        End Get
    End Property

    Public ReadOnly Property DType_Real As clsOntologyItem
        Get
            Return objDataTypes.DType_Real
        End Get
    End Property

    Public ReadOnly Property DType_String As clsOntologyItem
        Get
            Return objDataTypes.DType_String
        End Get
    End Property

    Public ReadOnly Property LState_Delete As clsOntologyItem
        Get
            Return objLogStates.LogState_Delete
        End Get
    End Property

    Public ReadOnly Property LState_Error As clsOntologyItem
        Get
            Return objLogStates.LogState_Error
        End Get
    End Property

    Public ReadOnly Property LState_Exists As clsOntologyItem
        Get
            Return objLogStates.LogState_Exists
        End Get
    End Property

    Public ReadOnly Property LState_Insert As clsOntologyItem
        Get
            Return objLogStates.LogState_Insert
        End Get
    End Property

    Public ReadOnly Property LState_Nothing As clsOntologyItem
        Get
            Return objLogStates.LogState_Nothing
        End Get
    End Property

    Public ReadOnly Property LState_Relation As clsOntologyItem
        Get
            Return objLogStates.LogState_Relation
        End Get
    End Property

    Public ReadOnly Property LState_Success As clsOntologyItem
        Get
            Return objLogStates.LogState_Success
        End Get
    End Property

    Public ReadOnly Property LState_Update As clsOntologyItem
        Get
            Return objLogStates.LogState_Update
        End Get
    End Property

    Public ReadOnly Property Direction_LeftRight As clsOntologyItem
        Get
            Return objDirections.Direction_LeftRight
        End Get
    End Property

    Public ReadOnly Property Direction_RightLeft As clsOntologyItem
        Get
            Return objDirections.Direction_RightLeft
        End Get
    End Property




    



    Private Sub set_OntologyRelationRules()
        objORule_ChildObjects = New clsOntologyItem("5f39c4ce080d4f36b432f83d2892c841", "Child-Token", objClasses.OItem_Class_OntologyRelationRule.GUID, objTypes.DataType)
        objORule_LeftOuterJoin = New clsOntologyItem("efddfb8176004f6a9d30cf579110771a", "Left Outer Join", objClasses.OItem_Class_OntologyRelationRule.GUID, objTypes.DataType)
        objORule_LeftOuterJoin = New clsOntologyItem("00b22e07be8e433097558c30c46d76e4", "Inner Join", objClasses.OItem_Class_OntologyRelationRule.GUID, objTypes.DataType)
        objORule_NameOfTypeParse = New clsOntologyItem("32ccb41b0321465ea94cc5de402c3209", "Name of Type Parse", objClasses.OItem_Class_OntologyRelationRule.GUID, objTypes.DataType)
        objORule_ParentClasses = New clsOntologyItem("8ff036f7efd64e9fb3bb29c91692ce8b", "Parent-Types", objClasses.OItem_Class_OntologyRelationRule.GUID, objTypes.DataType)
        objORule_OnlyItem = New clsOntologyItem("16fdf6615bdb4c55bfecd3e55df416fe", "Only Item", objClasses.OItem_Class_OntologyRelationRule.GUID, objTypes.DataType)
        objORule_RelationBreak = New clsOntologyItem("cbe4408df1734971bfed25a3b7891f88", "Relation-Break", objClasses.OItem_Class_OntologyRelationRule.GUID, objTypes.DataType)
    End Sub

    Public Function is_GUID(ByVal strText As String) As Boolean
        Dim objRegExp As New Regex(strRegEx_GUID)
        If objRegExp.IsMatch(strText) And Not strText = "00000000000000000000000000000000" Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub get_ConfigData()
        Dim objDRs_ConfigItem() As DataRow
        dtblT_Config.ReadXml(strPath_Config & "Config\Config_ont.xml")
        If dtblT_Config.Rows.Count > 0 Then
            objDRs_ConfigItem = dtblT_Config.Select("ConfigItem_Name='Index'")
            If objDRs_ConfigItem.Count > 0 Then
                strEL_Index = objDRs_ConfigItem(0).Item("ConfigItem_Value")
            Else
                Err.Raise(1, "Config")
            End If

            objDRs_ConfigItem = dtblT_Config.Select("ConfigItem_Name='Server'")
            If objDRs_ConfigItem.Count > 0 Then
                strEL_Server = objDRs_ConfigItem(0).Item("ConfigItem_Value")
            Else
                Err.Raise(1, "Config")
            End If

            objDRs_ConfigItem = dtblT_Config.Select("ConfigItem_Name='Port'")
            If objDRs_ConfigItem.Count > 0 Then
                strEL_Port = objDRs_ConfigItem(0).Item("ConfigItem_Value")
            Else
                Err.Raise(1, "Config")
            End If

            objDRs_ConfigItem = dtblT_Config.Select("ConfigItem_Name='server_report'")
            If objDRs_ConfigItem.Count > 0 Then
                strRep_Server = objDRs_ConfigItem(0).Item("ConfigItem_Value")
            Else
                Err.Raise(1, "Config")
            End If

            objDRs_ConfigItem = dtblT_Config.Select("ConfigItem_Name='server_instance'")
            If objDRs_ConfigItem.Count > 0 Then
                strRep_Instance = objDRs_ConfigItem(0).Item("ConfigItem_Value")
            Else
                Err.Raise(1, "Config")
            End If

            objDRs_ConfigItem = dtblT_Config.Select("ConfigItem_Name='database'")
            If objDRs_ConfigItem.Count > 0 Then
                strRep_Database = objDRs_ConfigItem(0).Item("ConfigItem_Value")
            Else
                Err.Raise(1, "Config")
            End If

            objDRs_ConfigItem = dtblT_Config.Select("ConfigItem_Name='ReportIndex'")
            If objDRs_ConfigItem.Count > 0 Then
                strRep_Index = objDRs_ConfigItem(0).Item("ConfigItem_Value")
            Else
                Err.Raise(1, "Config")
            End If

        Else
            Err.Raise(1, "Config")
        End If
    End Sub

    
    Public Sub New()
        strPath_Config = ""
        strRegEx_GUID = "[A-Za-z0-9]{8}[A-Za-z0-9]{4}[A-Za-z0-9]{4}[A-Za-z0-9]{4}[A-Za-z0-9]{12}"
        


        
        initialize()

    End Sub

    Private Sub initialize()
        set_Session()
        get_ConfigData()
        set_OntologyRelationRules()

        objDBLevel1 = New clsDBLevel(Server, Port, Index, Index_Rep, SearchRange, Session)
        objDBLevel2 = New clsDBLevel(Server, Port, Index, Index_Rep, SearchRange, Session)

        objTransaction = New clsTransaction(Server, Port, Index, Index_Rep, SearchRange, Session)

        set_Computer()
    End Sub

    Public Sub New(strPath_Config As String)
        Me.strPath_Config = strPath_Config
        If Not Me.strPath_Config.EndsWith(IO.Path.DirectorySeparatorChar) Then
            Me.strPath_Config = Me.strPath_Config & IO.Path.DirectorySeparatorChar
        End If
        strRegEx_GUID = "[A-Za-z0-9]{8}[A-Za-z0-9]{4}[A-Za-z0-9]{4}[A-Za-z0-9]{4}[A-Za-z0-9]{12}"



    End Sub

    Private Sub set_Session()
        GUID_Session = Guid.NewGuid.ToString.Replace("-", "")
    End Sub

    Private Sub set_Computer()
        Dim objWMI As ManagementObjectSearcher
        Dim objWMIManagementObject As ManagementObject
        Dim strProcessorID As String
        Dim strBaseBoardSerial As String
        Dim objOItem_Result As clsOntologyItem

        Dim objOAItem_ProcessorID As clsObjectAtt
        Dim objOAItem_BaseBoardSerial As clsObjectAtt

        strProcessorID = ""
        objWMI = New ManagementObjectSearcher("Select ProcessorID FROM Win32_Processor")
        For Each objWMIManagementObject In objWMI.Get
            strProcessorID = objWMIManagementObject("ProcessorID").ToString
            Exit For
        Next

        strBaseBoardSerial = ""
        objWMI = New ManagementObjectSearcher("SELECT SerialNumber FROM Win32_Baseboard")
        For Each objWMIManagementObject In objWMI.Get
            strBaseBoardSerial = objWMIManagementObject("SerialNumber").ToString
            Exit For
        Next

        objOItem_Server = get_Computer_ByWMI(strProcessorID, strBaseBoardSerial)

        If objOItem_Server Is Nothing Then
            objOItem_Server = New clsOntologyItem
            objOItem_Server.GUID = NewGUID()
            objOItem_Server.Name = Environment.MachineName
            objOItem_Server.GUID_Parent = objClasses.OItem_Class_Server.GUID
            objOItem_Server.Type = Type_Object



            objOItem_Result = objTransaction.do_Transaction(objOItem_Server)

            If objOItem_Result.GUID = objLogStates.LogState_Success.GUID Then
                objOAItem_BaseBoardSerial = New clsObjectAtt() With {.ID_AttributeType = objAttributeTypes.OITem_AttributeType_WMI_BaseBoardSerial.GUID, _
                                                                       .ID_Object = objOItem_Server.GUID, _
                                                                       .ID_Class = objOItem_Server.GUID_Parent, _
                                                                       .ID_DataType = objDataTypes.DType_String.GUID, _
                                                                       .OrderID = 1, _
                                                                       .Val_String = strBaseBoardSerial, _
                                                                       .val_Named = strBaseBoardSerial}

                objOItem_Result = objTransaction.do_Transaction(objOAItem_BaseBoardSerial)

                If objOItem_Result.GUID = objLogStates.LogState_Success.GUID Then
                    objOAItem_ProcessorID = New clsObjectAtt() With {.ID_AttributeType = objAttributeTypes.OItem_AttributeType_WMI_ProcessorID.GUID, _
                                                                       .ID_Object = objOItem_Server.GUID, _
                                                                       .ID_Class = objOItem_Server.GUID_Parent, _
                                                                       .ID_DataType = objDataTypes.DType_String.GUID, _
                                                                       .OrderID = 1, _
                                                                       .Val_String = strProcessorID, _
                                                                       .val_Named = strProcessorID}

                    objOItem_Result = objTransaction.do_Transaction(objOAItem_ProcessorID)
                    If objOItem_Result.GUID = objLogStates.LogState_Error.GUID Then
                        objTransaction.rollback()
                        Err.Raise(1, "Config")
                    End If
                Else
                    objTransaction.rollback()
                    Err.Raise(1, "Config")
                End If
            Else
                Err.Raise(1, "Config")
            End If
        End If

    End Sub

    Public Function get_Computer_ByWMI(strProcessorID As String, strBaseBoardSerial As String) As clsOntologyItem
        Dim objOAL_ProcessorID = New List(Of clsObjectAtt)
        Dim objOAL_BaseBoardSerial = New List(Of clsObjectAtt)
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Computer As clsOntologyItem = Nothing

        objOAL_ProcessorID.Add(New clsObjectAtt() With {.ID_Class = objClasses.OItem_Class_Server.GUID, _
                                                         .ID_AttributeType = objAttributeTypes.OItem_AttributeType_WMI_ProcessorID.GUID, _
                                                         .Val_String = strProcessorID})


        objOItem_Result = objDBLevel1.get_Data_ObjectAtt(objOAL_ProcessorID, boolIDs:=False)

        If objOItem_Result.GUID = objLogStates.LogState_Success.GUID Then
            objOAL_BaseBoardSerial.Add(New clsObjectAtt() With {.ID_Class = objClasses.OItem_Class_Server.GUID, _
                                                                .ID_AttributeType = objAttributeTypes.OITem_AttributeType_WMI_BaseBoardSerial.GUID, _
                                                                .Val_String = strBaseBoardSerial})

            objOItem_Result = objDBLevel2.get_Data_ObjectAtt(objOAL_BaseBoardSerial)

            Dim objOList_Server = (From objServer In objDBLevel1.OList_ObjectAtt
                                   Join objServer2 In objDBLevel2.OList_ObjectAtt_ID On objServer.ID_Object Equals objServer2.ID_Object
                                   Select New clsOntologyItem(objServer.ID_Object, objServer.Name_Object, objServer.ID_Class, objTypes.ObjectType)).ToList()

            If objOList_Server.Any Then
                objOItem_Computer = objOList_Server.First()
            Else
                objOItem_Computer = Nothing
            End If
        Else
            Err.Raise(1, "Config")
        End If

        Return objOItem_Computer
    End Function

End Class


