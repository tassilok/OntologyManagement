Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class clsDataWork_LogEntry
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_TimeStamp As clsDBLevel
    Private objDBLevel_Message As clsDBLevel
    Private objDBLevel_LogState_Combo As clsDBLevel
    Private objDBLevel_LogState As clsDBLevel
    Private objDBLevel_User_Combo As clsDBLevel
    Private objDBLevel_User As clsDBLevel
    Private objDBLevel_LogEntryOfRef As clsDBLevel
    Private objDBLevel_OItem As clsDBLevel

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

    Private objOItem_RefDirection As clsOntologyItem

    Private boolList As Boolean

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

    Public Sub New(Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)
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



    Public function get_Data_LogEntry(ByVal OItem_LogEntry As clsOntologyItem, Optional boolAsynchronous As Boolean = true) As clsOntologyItem
        Dim objOItem_Result as clsOntologyItem = objLocalConfig.Globals.LState_Success

        objOItem_LogEntry = OItem_LogEntry
        boolList = False
        objOItem_Result_LogState = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_DateTimeStamp = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Message = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_User = objLocalConfig.Globals.LState_Nothing
        
        If Not objOItem_LogEntry Is Nothing Then
            If boolAsynchronous Then
                objThread_LogState = New Threading.Thread(AddressOf get_Data_LogState)
                objThread_LogState.Start()
                objThread_User = New Threading.Thread(AddressOf get_Data_User)
                objThread_User.Start()
                objThread_DateTimeStamp = New Threading.Thread(AddressOf get_Data_DateTimeStamp)
                objThread_DateTimeStamp.Start()
                objThread_Message = New Threading.Thread(AddressOf get_Data_Message)
                objThread_Message.Start()
            Else 
                objOItem_Result = objLocalConfig.Globals.LState_Error
                get_Data_LogState()
                If objOItem_Result_LogState.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    get_Data_DateTimeStamp()
                    If objOItem_Result_DateTimeStamp.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        get_Data_User()
                        If objOItem_Result_User.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            get_Data_Message()
                            If objOItem_Result_Message.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objOItem_Result = objLocalConfig.Globals.LState_Success
                            End If
                        End If
                    
                    End If
                End If
            
            


            End If    
        End If
        
        

        Return objOItem_Result
    End Function

    Public Function get_Data_LogEntries() As List(Of clsLogEntry)
        boolList = True
        Dim objOList_Logentry = New List(Of clsLogEntry)
        get_Data_LogState()
        If objOItem_Result_LogState.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            get_Data_DateTimeStamp()
            If objOItem_Result_DateTimeStamp.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                get_Data_Message()
                If objOItem_Result_Message.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    get_Data_User()
                    If objOItem_Result_User.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objOList_Logentry = (From objDateTimeStamp In objDBLevel_TimeStamp.OList_ObjectAtt
                                         Group Join objMessage In objDBLevel_Message.OList_ObjectAtt On objDateTimeStamp.ID_Object Equals objMessage.ID_Object Into objMessages = Group
                                         From objMessage In objMessages.DefaultIfEmpty()
                                         Join objLogState In objDBLevel_LogState.OList_ObjectRel On objDateTimeStamp.ID_Object Equals objLogState.ID_Object
                                         Join objUser In objDBLevel_User.OList_ObjectRel On objDateTimeStamp.ID_Object Equals objUser.ID_Object
                                         Select New clsLogEntry With {.ID_LogEntry = objDateTimeStamp.ID_Object, _
                                                                      .Name_LogEntry = objDateTimeStamp.Name_Object, _
                                                                      .ID_Attribute_DateTimeStamp = objDateTimeStamp.ID_Attribute, _
                                                                      .DateTimeStamp = objDateTimeStamp.Val_Date, _
                                                                      .ID_Attribute_Message = If(objMessage Is Nothing, Nothing, objMessage.ID_Attribute), _
                                                                      .Message = If(objMessage Is Nothing, Nothing, objMessage.Val_String), _
                                                                      .ID_LogState = objLogState.ID_Other, _
                                                                      .Name_LogState = objLogState.Name_Other, _
                                                                      .ID_User = objUser.ID_Other, _
                                                                      .Name_User = objUser.Name_Other}).ToList()


                        objDBLevel_TimeStamp = Nothing
                        objDBLevel_TimeStamp = New clsDBLevel(objLocalConfig.Globals)
                        objDBLevel_Message = Nothing
                        objDBLevel_Message = New clsDBLevel(objLocalConfig.Globals)
                        objDBLevel_LogState = Nothing
                        objDBLevel_LogState = New clsDBLevel(objLocalConfig.Globals)
                        objDBLevel_User = Nothing
                        objDBLevel_User = New clsDBLevel(objLocalConfig.Globals)
                        GC.Collect()
                    Else
                        objOList_Logentry = Nothing
                    End If
                Else
                    objOList_Logentry = Nothing
                End If
            Else
                objOList_Logentry = Nothing
            End If
        Else
            objOList_Logentry = Nothing
        End If

        Return objOList_Logentry
    End Function

    Public Function get_Data_LogEntryOfRef(OItem_Ref As clsOntologyItem, Optional OItem_RelationType As clsOntologyItem = Nothing) As List(Of clsLogEntry)
        Dim OList_LogEntry = New List(Of clsLogEntry)

        Dim objOList_Logentries = New List(Of clsObjectRel)
        boolList = True
        If OItem_RelationType Is Nothing Then
            objOList_Logentries.Add(New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Type_LogEntry.GUID,
                                                       .ID_Other = OItem_Ref.GUID,
                                                       .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID})
            objOItem_RefDirection = objLocalConfig.Globals.Direction_LeftRight.Clone()
        Else
            objOList_Logentries.Add(New clsObjectRel With {.ID_Object = OItem_Ref.GUID,
                                                                   .ID_Parent_Other = objLocalConfig.OItem_Type_LogEntry.GUID,
                                                                   .ID_RelationType = OItem_RelationType.GUID})
            objOItem_RefDirection = objLocalConfig.Globals.Direction_RightLeft.Clone()
        End If
        
        Dim objOItem_Result = objDBLevel_LogEntryOfRef.get_Data_ObjectRel(objOList_Logentries, boolIDs:=False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
           

           
            Dim objOList_Logentry = New List(Of clsLogEntry)
            get_Data_LogState()

            If objOItem_Result_LogState.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                get_Data_DateTimeStamp()
                If objOItem_Result_DateTimeStamp.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    get_Data_Message()
                    If objOItem_Result_Message.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        get_Data_User()
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            OList_LogEntry = (From objLogentries In objDBLevel_LogEntryOfRef.OList_ObjectRel
                                             Join objDateTimeStamp In objDBLevel_TimeStamp.OList_ObjectAtt On If(OItem_RelationType Is Nothing, objLogentries.ID_Object, objLogentries.ID_Other) Equals objDateTimeStamp.ID_Object
                                             Group Join objMessage In objDBLevel_Message.OList_ObjectAtt On If(OItem_RelationType Is Nothing, objLogentries.ID_Object, objLogentries.ID_Other) Equals objMessage.ID_Object Into objMessages = Group
                                             From objMessage In objMessages.DefaultIfEmpty()
                                             Join objLogState In objDBLevel_LogState.OList_ObjectRel On If(OItem_RelationType Is Nothing, objLogentries.ID_Object, objLogentries.ID_Other) Equals objLogState.ID_Object
                                             Join objUser In objDBLevel_User.OList_ObjectRel On If(OItem_RelationType Is Nothing, objLogentries.ID_Object, objLogentries.ID_Other) Equals objUser.ID_Object
                                             Select New clsLogEntry With {.ID_LogEntry = If(OItem_RelationType Is Nothing, objLogentries.ID_Object, objLogentries.ID_Other), _
                                                                          .Name_LogEntry = If(OItem_RelationType Is Nothing, objLogentries.Name_Object, objLogentries.Name_Other), _
                                                                          .ID_Attribute_DateTimeStamp = objDateTimeStamp.ID_Attribute, _
                                                                          .DateTimeStamp = objDateTimeStamp.Val_Date, _
                                                                          .ID_Attribute_Message = If(objMessage Is Nothing, Nothing, objMessage.ID_Attribute), _
                                                                          .Message = If(objMessage Is Nothing, Nothing, objMessage.Val_String), _
                                                                          .ID_LogState = objLogState.ID_Other, _
                                                                          .Name_LogState = objLogState.Name_Other, _
                                                                          .ID_User = objUser.ID_Other, _
                                                                          .Name_User = objUser.Name_Other}).ToList()

                        Else
                            objOList_Logentry = Nothing
                        End If
                    Else
                        objOList_Logentry = Nothing
                    End If
                Else
                    objOList_Logentry = Nothing
                End If
            Else
                objOList_Logentry = Nothing
            End If
        Else
            OList_LogEntry = Nothing
        End If

        Return OList_LogEntry
    End Function
    Private Sub get_Data_User()
        Dim objOList_ObjectRel As New List(Of clsObjectRel)
        If boolList = False Then
            objOList_ObjectRel.Add(New clsObjectRel(objOItem_LogEntry.GUID, _
                                                Nothing, _
                                                Nothing, _
                                                objLocalConfig.OItem_type_User.GUID, _
                                                objLocalConfig.OItem_RelationType_wasCreatedBy.GUID, _
                                                objLocalConfig.Globals.Type_Object, _
                                                Nothing, _
                                                Nothing))
        Else
            If objDBLevel_LogEntryOfRef.OList_ObjectRel.Any() And objDBLevel_LogEntryOfRef.OList_ObjectRel.Count < 500 Then

                objOList_ObjectRel = objDBLevel_LogEntryOfRef.OList_ObjectRel.Select(Function(loge) New clsObjectRel With {
                                                                                     .ID_Object = If(objOItem_RefDirection.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID, loge.ID_Object, loge.ID_Other),
                                                                                     .ID_RelationType = objLocalConfig.OItem_RelationType_wasCreatedBy.GUID,
                                                                                     .ID_Parent_Other = objLocalConfig.OItem_type_User.GUID}).ToList

            Else
                objOList_ObjectRel.Add(New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Type_LogEntry.GUID, _
                                                          .ID_Parent_Other = objLocalConfig.OItem_type_User.GUID, _
                                                          .ID_RelationType = objLocalConfig.OItem_RelationType_wasCreatedBy.GUID})
            End If
            
        End If
        

        objDBLevel_User.get_Data_ObjectRel(objOList_ObjectRel, _
                                           boolIDs:=False)

        If boolList = False Then
            If objDBLevel_User.OList_ObjectRel.Count > 0 Then

                objOItem_User = New clsOntologyItem
                objOItem_User.GUID = objDBLevel_User.OList_ObjectRel(0).ID_Other
                objOItem_User.Name = objDBLevel_User.OList_ObjectRel(0).Name_Other
                objOItem_User.GUID_Parent = objLocalConfig.OItem_type_User.GUID
                objOItem_User.Type = objLocalConfig.Globals.Type_Object
            Else
                objOItem_User = Nothing
            End If
        Else
            objOItem_User = Nothing
        End If

        objOItem_Result_User = objLocalConfig.Globals.LState_Success
    End Sub

    Private Sub get_Data_DateTimeStamp()
        Dim objOList_DateTimeStamp As New List(Of clsObjectAtt)

        If boolList = False Then
            objOList_DateTimeStamp.Add(New clsObjectAtt(Nothing, _
                                                    objOItem_LogEntry.GUID, _
                                                    Nothing, _
                                                    objLocalConfig.OItem_Attribute_DateTimeStamp.GUID, _
                                                    Nothing))
        Else
            If objDBLevel_LogEntryOfRef.OList_ObjectRel.Any() And objDBLevel_LogEntryOfRef.OList_ObjectRel.Count < 500 Then

                objOList_DateTimeStamp = objDBLevel_LogEntryOfRef.OList_ObjectRel.Select(Function(loge) New clsObjectAtt With {
                                                                                     .ID_Object = If(objOItem_RefDirection.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID, loge.ID_Object, loge.ID_Other),
                                                                                     .ID_AttributeType = objLocalConfig.OItem_Attribute_DateTimeStamp.GUID}).ToList

            Else
                objOList_DateTimeStamp.Add(New clsObjectAtt With {.ID_Class = objLocalConfig.OItem_Type_LogEntry.GUID, _
                                                              .ID_AttributeType = objLocalConfig.OItem_Attribute_DateTimeStamp.GUID})
            End If
            
        End If
        

        objDBLevel_TimeStamp.get_Data_ObjectAtt(objOList_DateTimeStamp, _
                                                boolIDs:=False)

        If boolList = False Then
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
        Else
            objOItem_DateTimeStamp = Nothing
        End If
        
        objOItem_Result_DateTimeStamp = objLocalConfig.Globals.LState_Success
    End Sub

    Private Sub get_Data_Message()
        Dim objOList_Message As New List(Of clsObjectAtt)

        If boolList = False Then
            objOList_Message.Add(New clsObjectAtt(Nothing, _
                                                    objOItem_LogEntry.GUID, _
                                                    Nothing, _
                                                    objLocalConfig.OItem_Attribute_Message.GUID, _
                                                    Nothing))
        Else
            If objDBLevel_LogEntryOfRef.OList_ObjectRel.Any() And objDBLevel_LogEntryOfRef.OList_ObjectRel.Count < 500 Then

                objOList_Message = objDBLevel_LogEntryOfRef.OList_ObjectRel.Select(Function(loge) New clsObjectAtt With {
                                                                                     .ID_Object = If(objOItem_RefDirection.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID, loge.ID_Object, loge.ID_Other),
                                                                                     .ID_AttributeType = objLocalConfig.OItem_Attribute_Message.GUID}).ToList

            Else
                objOList_Message.Add(New clsObjectAtt With {.ID_Class = objLocalConfig.OItem_Type_LogEntry.GUID, _
                                                        .ID_AttributeType = objLocalConfig.OItem_Attribute_Message.GUID})
            End If
            
        End If
        

        objDBLevel_Message.get_Data_ObjectAtt(objOList_Message, _
                                                boolIDs:=False)

        If boolList = False Then
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
        Else
            objOItem_Message = Nothing
        End If
        
        objOItem_Result_Message = objLocalConfig.Globals.LState_Success
    End Sub

    Private Sub get_Data_LogState()
        Dim objOList_ObjectRel As New List(Of clsObjectRel)

        If boolList = False Then
            objOList_ObjectRel.Add(New clsObjectRel(objOItem_LogEntry.GUID, _
                                                Nothing, _
                                                Nothing, _
                                                objLocalConfig.OItem_type_Logstate.GUID, _
                                                objLocalConfig.OItem_RelationType_provides.GUID, _
                                                objLocalConfig.Globals.Type_Object, _
                                                Nothing, _
                                                Nothing))
        Else
            If objDBLevel_LogEntryOfRef.OList_ObjectRel.Any() And objDBLevel_LogEntryOfRef.OList_ObjectRel.Count < 500 Then

                objOList_ObjectRel = objDBLevel_LogEntryOfRef.OList_ObjectRel.Select(Function(loge) New clsObjectRel With {
                                                                                     .ID_Object = If(objOItem_RefDirection.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID, loge.ID_Object, loge.ID_Other),
                                                                                     .ID_RelationType = objLocalConfig.OItem_RelationType_provides.GUID,
                                                                                     .ID_Parent_Other = objLocalConfig.OItem_type_Logstate.GUID}).ToList
            
            Else
                objOList_ObjectRel.Add(New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Type_LogEntry.GUID, _
                                                      .ID_Parent_Other = objLocalConfig.OItem_type_Logstate.GUID, _
                                                      .ID_RelationType = objLocalConfig.OItem_RelationType_provides.GUID})
            End If
            
        End If
        

        objOItem_Result_LogState = objDBLevel_LogState.get_Data_ObjectRel(objOList_ObjectRel, _
                                                                          boolIDs:=False)

        If boolList = False Then
            If objDBLevel_LogState.OList_ObjectRel.Count > 0 Then
                objOItem_LogState = New clsOntologyItem
                objOItem_LogState.GUID = objDBLevel_LogState.OList_ObjectRel(0).ID_Other
                objOItem_LogState.Name = objDBLevel_LogState.OList_ObjectRel(0).Name_Other
                objOItem_LogState.GUID_Parent = objLocalConfig.OItem_type_Logstate.GUID
                objOItem_LogState.Type = objLocalConfig.Globals.Type_Object
            Else
                objOItem_LogState = Nothing
            End If
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

    public Function GetOItem(GUID_Item As String, Type_Item As String) As clsOntologyItem
        Return objDBLevel_OItem.GetOItem(GUID_Item, Type_Item)
    End Function

    Private Sub set_DBConnection()
        objDBLevel_LogState = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_LogState_Combo = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Message = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_TimeStamp = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_User = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_User_Combo = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_LogEntryOfRef = new clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OItem = new clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
