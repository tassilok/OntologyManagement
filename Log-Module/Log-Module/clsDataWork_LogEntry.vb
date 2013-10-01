Imports Ontolog_Module
Imports OntologyClasses.BaseClasses

Public Class clsDataWork_LogEntry
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_TimeStamp As clsDBLevel
    Private objDBLevel_Message As clsDBLevel
    Private objDBLevel_LogState_Combo As clsDBLevel
    Private objDBLevel_LogState As clsDBLevel
    Private objDBLevel_User_Combo As clsDBLevel
    Private objDBLevel_User As clsDBLevel

    Private objUserControl_Relations As UserControl_OItemList

    Private objOItem_Result_LogStates_Combo As clsOntologyItem
    Private objOItem_Result_Users_Combo As clsOntologyItem
    Private objOItem_Result_LogState As clsOntologyItem
    Private objOItem_Result_User As clsOntologyItem
    Private objOItem_Result_DateTimeStamp As clsOntologyItem
    Private objOItem_Result_Message As clsOntologyItem

    Private objThread_LogStates_Combo As Threading.Thread
    Private objThread_Users_Combo As Threading.Thread
    Private objThread_LogState As Threading.Thread
    Private objThread_DateTimeStamp As Threading.Thread
    Private objThread_Message As Threading.Thread
    Private objThread_User As Threading.Thread

    Private objOItem_LogEntry As clsOntologyItem
    Private objOItem_LogState As clsOntologyItem
    Private objOItem_User As clsOntologyItem
    Private objOItem_DateTimeStamp As clsObjectAtt
    Private objOItem_Message As clsObjectAtt

    Public ReadOnly Property OItem_Result_LogState As clsOntologyItem
        Get
            Return objOItem_Result_LogState
        End Get
    End Property

    Public ReadOnly Property OItem_Result_User As clsOntologyItem
        Get
            Return objOItem_Result_User
        End Get
    End Property


    Public ReadOnly Property OItem_Result_DateTimeStamp As clsOntologyItem
        Get
            Return objOItem_Result_DateTimeStamp
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Message As clsOntologyItem
        Get
            Return objOItem_Result_Message
        End Get
    End Property

    Public ReadOnly Property OItem_Result_LogStates_Combo As clsOntologyItem
        Get
            Return objOItem_Result_LogStates_Combo
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Users_Combo As clsOntologyItem
        Get
            Return objOItem_Result_Users_Combo
        End Get
    End Property

    Public Property OItem_User As clsOntologyItem
        Get
            Return objOItem_User
        End Get
        Set(value As clsOntologyItem)
            objOItem_User = value
        End Set
    End Property



    Public Property OItem_LogState As clsOntologyItem
        Get
            Return objOItem_LogState

        End Get
        Set(value As clsOntologyItem)
            objOItem_LogState = value
        End Set
    End Property



    Public ReadOnly Property OItem_DateTimeStamp As clsObjectAtt
        Get
            Return objOItem_DateTimeStamp
        End Get
    End Property

    Public ReadOnly Property OItem_Message As clsObjectAtt
        Get
            Return objOItem_Message
        End Get
    End Property

    Public ReadOnly Property OList_LogStates As List(Of clsOntologyItem)
        Get
            Return objDBLevel_LogState_Combo.OList_Objects
        End Get
    End Property

    Public ReadOnly Property OList_Users As List(Of clsOntologyItem)
        Get
            Return objDBLevel_User_Combo.OList_Objects
        End Get
    End Property

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Private Sub get_Data_LogState_Combo()
        Dim objOList_LogStates As New List(Of clsOntologyItem)

        objOList_LogStates.Add(New clsOntologyItem(Nothing, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_type_Logstate.GUID, _
                                                   objLocalConfig.Globals.Type_Object))

        objOItem_Result_LogStates_Combo = objDBLevel_LogState_Combo.get_Data_Objects(objOList_LogStates)

    End Sub

    Private Sub get_Data_User_Combo()
        Dim objOList_Users As New List(Of clsOntologyItem)

        objOList_Users.Add(New clsOntologyItem(Nothing, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_type_User.GUID, _
                                                   objLocalConfig.Globals.Type_Object))

        objOItem_Result_Users_Combo = objDBLevel_User_Combo.get_Data_Objects(objOList_Users)

    End Sub

    Public Sub get_Data_Combo()


        objThread_LogStates_Combo = New Threading.Thread(AddressOf get_Data_LogState_Combo)
        objThread_Users_Combo = New Threading.Thread(AddressOf get_Data_User_Combo)

        objOItem_Result_LogStates_Combo = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Users_Combo = objLocalConfig.Globals.LState_Nothing

        objThread_LogStates_Combo.Start()
        objThread_Users_Combo.Start()

    End Sub



    Public Sub get_Data_LogEntry(ByVal OItem_LogEntry As clsOntologyItem)
        objOItem_LogEntry = OItem_LogEntry

        objOItem_Result_LogState = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_DateTimeStamp = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Message = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_User = objLocalConfig.Globals.LState_Nothing

        objThread_LogState = New Threading.Thread(AddressOf get_Data_LogState)
        objThread_LogState.Start()
        objThread_User = New Threading.Thread(AddressOf get_Data_User)
        objThread_User.Start()
        objThread_DateTimeStamp = New Threading.Thread(AddressOf get_Data_DateTimeStamp)
        objThread_DateTimeStamp.Start()
        objThread_Message = New Threading.Thread(AddressOf get_Data_Message)
        objThread_Message.Start()


    End Sub

    Private Sub get_Data_User()
        Dim objOList_ObjectRel As New List(Of clsObjectRel)
        objOList_ObjectRel.Add(New clsObjectRel(objOItem_LogEntry.GUID, _
                                                Nothing, _
                                                Nothing, _
                                                objLocalConfig.OItem_type_User.GUID, _
                                                objLocalConfig.OItem_RelationType_wasCreatedBy.GUID, _
                                                objLocalConfig.Globals.Type_Object, _
                                                Nothing, _
                                                Nothing))

        objDBLevel_User.get_Data_ObjectRel(objOList_ObjectRel, _
                                           boolIDs:=False)

        If objDBLevel_User.OList_ObjectRel.Count > 0 Then
            objOItem_User = New clsOntologyItem
            objOItem_User.GUID = objDBLevel_User.OList_ObjectRel(0).ID_Other
            objOItem_User.Name = objDBLevel_User.OList_ObjectRel(0).Name_Other
            objOItem_User.GUID_Parent = objLocalConfig.OItem_type_User.GUID
            objOItem_User.Type = objLocalConfig.Globals.Type_Object
        Else
            objOItem_User = Nothing
        End If

        objOItem_Result_User = objLocalConfig.Globals.LState_Success
    End Sub

    Private Sub get_Data_DateTimeStamp()
        Dim objOList_DateTimeStamp As New List(Of clsObjectAtt)

        objOList_DateTimeStamp.Add(New clsObjectAtt(Nothing, _
                                                    objOItem_LogEntry.GUID, _
                                                    Nothing, _
                                                    objLocalConfig.OItem_Attribute_DateTimeStamp.GUID, _
                                                    Nothing))

        objDBLevel_TimeStamp.get_Data_ObjectAtt(objOList_DateTimeStamp, _
                                                boolIDs:=False)

        If objDBLevel_TimeStamp.OList_ObjectAtt.Count > 0 Then
            objOItem_DateTimeStamp = New clsObjectAtt(objDBLevel_TimeStamp.OList_ObjectAtt(0).ID_Attribute, _
                                                      objDBLevel_TimeStamp.OList_ObjectAtt(0).ID_Object, _
                                                      objDBLevel_TimeStamp.OList_ObjectAtt(0).Name_Object, _
                                                      objDBLevel_TimeStamp.OList_ObjectAtt(0).ID_Class, _
                                                      objDBLevel_TimeStamp.OList_ObjectAtt(0).Name_Class, _
                                                      objDBLevel_TimeStamp.OList_ObjectAtt(0).ID_AttributeType, _
                                                      objDBLevel_TimeStamp.OList_ObjectAtt(0).Name_AttributeType, _
                                                      objDBLevel_TimeStamp.OList_ObjectAtt(0).OrderID, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objDBLevel_TimeStamp.OList_ObjectAtt(0).Val_Date, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.Globals.DType_DateTime.GUID)


        Else
            objOItem_DateTimeStamp = Nothing
        End If
        objOItem_Result_DateTimeStamp = objLocalConfig.Globals.LState_Success
    End Sub

    Private Sub get_Data_Message()
        Dim objOList_Message As New List(Of clsObjectAtt)

        objOList_Message.Add(New clsObjectAtt(Nothing, _
                                                    objOItem_LogEntry.GUID, _
                                                    Nothing, _
                                                    objLocalConfig.OItem_Attribute_Message.GUID, _
                                                    Nothing))

        objDBLevel_Message.get_Data_ObjectAtt(objOList_Message, _
                                                boolIDs:=False)

        If objDBLevel_Message.OList_ObjectAtt.Count > 0 Then
            objOItem_Message = New clsObjectAtt(objDBLevel_Message.OList_ObjectAtt(0).ID_Attribute, _
                                                      objDBLevel_Message.OList_ObjectAtt(0).ID_Object, _
                                                      objDBLevel_Message.OList_ObjectAtt(0).Name_Object, _
                                                      objDBLevel_Message.OList_ObjectAtt(0).ID_Class, _
                                                      objDBLevel_Message.OList_ObjectAtt(0).Name_Class, _
                                                      objDBLevel_Message.OList_ObjectAtt(0).ID_AttributeType, _
                                                      objDBLevel_Message.OList_ObjectAtt(0).Name_AttributeType, _
                                                      objDBLevel_Message.OList_ObjectAtt(0).OrderID, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objDBLevel_Message.OList_ObjectAtt(0).Val_String, _
                                                      objLocalConfig.Globals.DType_String.GUID)


        Else
            objOItem_Message = Nothing
        End If
        objOItem_Result_Message = objLocalConfig.Globals.LState_Success
    End Sub

    Private Sub get_Data_LogState()
        Dim objOList_ObjectRel As New List(Of clsObjectRel)

        objOList_ObjectRel.Add(New clsObjectRel(objOItem_LogEntry.GUID, _
                                                Nothing, _
                                                Nothing, _
                                                objLocalConfig.OItem_type_Logstate.GUID, _
                                                objLocalConfig.OItem_RelationType_provides.GUID, _
                                                objLocalConfig.Globals.Type_Object, _
                                                Nothing, _
                                                Nothing))

        objOItem_Result_LogState = objDBLevel_LogState.get_Data_ObjectRel(objOList_ObjectRel, _
                                                                          boolIDs:=False)

        If objDBLevel_LogState.OList_ObjectRel.Count > 0 Then
            objOItem_LogState = New clsOntologyItem
            objOItem_LogState.GUID = objDBLevel_LogState.OList_ObjectRel(0).ID_Other
            objOItem_LogState.Name = objDBLevel_LogState.OList_ObjectRel(0).Name_Other
            objOItem_LogState.GUID_Parent = objLocalConfig.OItem_type_Logstate.GUID
            objOItem_LogState.Type = objLocalConfig.Globals.Type_Object
        Else
            objOItem_LogState = Nothing
        End If

        objOItem_Result_LogState = objLocalConfig.Globals.LState_Success
    End Sub

    Public Function Rel_LogEntry_To_LogState(OItem_LogEntry As clsOntologyItem, OItem_LogState As clsOntologyItem)
        Dim objORel_LogEntry_To_LogState As clsObjectRel

        objORel_LogEntry_To_LogState = New clsObjectRel(OItem_LogEntry.GUID, _
                                                        OItem_LogEntry.GUID_Parent, _
                                                        OItem_LogState.GUID, _
                                                        OItem_LogState.GUID_Parent, _
                                                        objLocalConfig.OItem_RelationType_provides.GUID, _
                                                        objLocalConfig.Globals.Type_Object, _
                                                        Nothing, _
                                                        1)



        Return objORel_LogEntry_To_LogState
    End Function

    Public Function Rel_LogEntry_To_User(OItem_LogEntry As clsOntologyItem, OItem_User As clsOntologyItem)
        Dim objORel_LogEntry_To_User As clsObjectRel

        objORel_LogEntry_To_User = New clsObjectRel(OItem_LogEntry.GUID, _
                                                        OItem_LogEntry.GUID_Parent, _
                                                        OItem_User.GUID, _
                                                        OItem_User.GUID_Parent, _
                                                        objLocalConfig.OItem_RelationType_wasCreatedBy.GUID, _
                                                        objLocalConfig.Globals.Type_Object, _
                                                        Nothing, _
                                                        1)



        Return objORel_LogEntry_To_User
    End Function

    Public Function RelA_LogEntry__DateTimeStamp(OItem_LogEntry As clsOntologyItem, DateTimeStamp As DateTime)
        Dim objOARel_LogEntry__DateTimeStamp As clsObjectAtt

        objOARel_LogEntry__DateTimeStamp = New clsObjectAtt(objLocalConfig.Globals.NewGUID, _
                                                            OItem_LogEntry.GUID, _
                                                            Nothing, _
                                                            OItem_LogEntry.GUID_Parent, _
                                                            Nothing, _
                                                            objLocalConfig.OItem_Attribute_DateTimeStamp.GUID, _
                                                            Nothing, _
                                                            1, _
                                                            DateTimeStamp.ToString, _
                                                            Nothing, _
                                                            DateTimeStamp, _
                                                            Nothing, _
                                                            Nothing, _
                                                            Nothing, _
                                                            objLocalConfig.Globals.DType_DateTime.GUID)


        Return objOARel_LogEntry__DateTimeStamp
    End Function

    Public Function RelA_LogEntry__Message(OItem_LogEntry As clsOntologyItem, strMessage As String)
        Dim objOARel_LogEntry__Message As clsObjectAtt

        objOARel_LogEntry__Message = New clsObjectAtt(objLocalConfig.Globals.NewGUID, _
                                                      OItem_LogEntry.GUID, _
                                                      Nothing, _
                                                      OItem_LogEntry.GUID_Parent, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Attribute_Message.GUID, _
                                                      Nothing, _
                                                      1, _
                                                      strMessage, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      strMessage, _
                                                      objLocalConfig.Globals.DType_String.GUID)


        Return objOARel_LogEntry__Message
    End Function

    Private Sub set_DBConnection()
        objDBLevel_LogState = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_LogState_Combo = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Message = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_TimeStamp = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_User = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_User_Combo = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
