Imports OntologyClasses.BaseClasses
Imports Ontology_Module
Imports System.Threading

Public Class clsDataWork_LogHistory
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Ref As clsDBLevel
    Private objDBLevel_DateTimeStamp As clsDBLevel
    Private objDBLevel_Message As clsDBLevel
    Private objDBLevel_LogState As clsDBLevel
    Private objDBLevel_User As clsDBLevel


    Private logRelations As List(Of clsLogRelation)
    Private logEntries As List(Of clsOntologyItem)
    Private logEntriesRef_LeftRight As List(Of clsObjectRel)
    Private logEntriesRef_RightLeft As List(Of clsObjectRel)
    Public Property LogEntryList As List(Of clsLogEntry)

    Private objOItem_Result_DateTimeStamp As clsOntologyItem
    Private objOItem_Result_Message As clsOntologyItem
    Private objOItem_Result_LogState As clsOntologyItem
    Private objOItem_Result_User As clsOntologyItem
    Private objOItem_Result_Data As clsOntologyItem

    Private objThread As Thread

    Public ReadOnly Property  OItem_Result_Data() As clsOntologyItem
        Get
            Return objOItem_Result_Data
        End Get
    End Property

    Public Function GetData_History(logRelations As List(Of clsLogRelation)) As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()
        Me.logRelations = logRelations
        objOItem_Result_Data = objLocalConfig.Globals.LState_Nothing.Clone()

        Try
            objThread.Abort()
        Catch ex As Exception

        End Try

        objThread = new Thread(AddressOf GetSubData_All)
        objThread.Start()

        Return objOItem_Result
    End Function

    Public Sub GetSubData_All()
        

        objOItem_Result_Data = objLocalConfig.Globals.LState_Nothing.Clone()
        Dim objOItem_Result As clsOntologyItem

        Dim searchRel = Me.logRelations.Where(Function(rel) rel.OItem_Direction.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID).Select(Function(rel) New clsObjectRel With {
                                                                                                                                                .ID_Object = rel.OItem_Ref.GUID,
                                                                                                                                                .ID_Parent_Other = objLocalConfig.OItem_Type_LogEntry.GUID,
                                                                                                                                                .ID_RelationType = rel.OItem_RelationType.GUID }).ToList()
        If searchRel.Any() Then
            objOItem_Result = objDBLevel_Ref.get_Data_ObjectRel(searchRel, boolIDs := False)    
        
        Else 
            objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()
            objDBLevel_Ref.OList_ObjectRel.Clear()
        End If
        

        objDBLevel_DateTimeStamp.OList_ObjectAtt.Clear()
        objDBLevel_Message.OList_ObjectAtt.Clear()

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            logEntriesRef_LeftRight = new List(Of clsObjectRel)()
            logEntriesRef_RightLeft = new List(Of clsObjectRel)()
            logEntries = new List(Of clsOntologyItem)()

            logEntriesRef_LeftRight = objDBLevel_Ref.OList_ObjectRel.Select(Function(rel) New clsObjectRel With {.ID_Object = rel.ID_Object,
                                                                                                       .Name_Object = rel.Name_Object,
                                                                                                       .ID_Parent_Object = rel.ID_Parent_Object,
                                                                                                       .Name_Parent_Object = rel.Name_Parent_Object,
                                                                                                       .ID_Other = rel.ID_Other,
                                                                                                       .ID_Parent_Other = rel.ID_Parent_Other,
                                                                                                       .Name_Parent_Other = rel.Name_Parent_Other,
                                                                                                       .ID_RelationType = rel.ID_RelationType,
                                                                                                       .Name_RelationType = rel.Name_RelationType,
                                                                                                       .OrderID = rel.OrderID,
                                                                                                       .Ontology = rel.Ontology,
                                                                                                       .ID_Direction = objLocalConfig.Globals.Direction_LeftRight.GUID}).ToList()

                                                       
                                                   
            
            searchRel = Me.logRelations.Where(Function(rel) rel.OItem_Direction.GUID = objLocalConfig.Globals.Direction_RightLeft.GUID).Select(Function(rel) New clsObjectRel With {
                                                                                                                                                .ID_Other = rel.OItem_Ref.GUID,
                                                                                                                                                .ID_Parent_Object = objLocalConfig.OItem_Type_LogEntry.GUID,
                                                                                                                                                .ID_RelationType = rel.OItem_RelationType.GUID }).ToList()    

            If searchRel.Any() Then
                objOItem_Result = objDBLevel_Ref.get_Data_ObjectRel(searchRel, boolIDs := False)
            Else 
                objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()
                objDBLevel_Ref.OList_ObjectRel.Clear()
            End If
            

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                logEntriesRef_RightLeft = objDBLevel_Ref.OList_ObjectRel.Select(Function(rel) New clsObjectRel With {.ID_Object = rel.ID_Object,
                                                                                                       .Name_Object = rel.Name_Object,
                                                                                                       .ID_Parent_Object = rel.ID_Parent_Object,
                                                                                                       .Name_Parent_Object = rel.Name_Parent_Object,
                                                                                                       .ID_Other = rel.ID_Other,
                                                                                                       .ID_Parent_Other = rel.ID_Parent_Other,
                                                                                                       .Name_Parent_Other = rel.Name_Parent_Other,
                                                                                                       .ID_RelationType = rel.ID_RelationType,
                                                                                                       .Name_RelationType = rel.Name_RelationType,
                                                                                                       .OrderID = rel.OrderID,
                                                                                                       .Ontology = rel.Ontology,
                                                                                                       .ID_Direction = objLocalConfig.Globals.Direction_RightLeft.GUID }).ToList()
                logEntries = (From objRefLeftRight In logEntriesRef_LeftRight
                                                 Join objRefRightLeft in logEntriesRef_RightLeft On objRefLeftRight.ID_Other Equals objRefRightLeft.ID_Object
                                                 Select New clsOntologyItem With 
                                                        {
                                                            .GUID = objRefLeftRight.ID_Other,
                                                            .Name = objRefLeftRight.Name_Other,
                                                            .GUID_Parent = objRefLeftRight.ID_Parent_Other,
                                                            .Type = objLocalConfig.Globals.Type_Object
                                                        }).ToList()

                GetSubData_DateTimeStamp()
                objOItem_Result = objOItem_Result_DateTimeStamp

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    GetSubData_Message()
                    objOItem_Result = objOItem_Result_Message

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        GetSubData_LogState()
                        objOItem_Result = objOItem_Result_LogState

                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            GetSubData_User()
                            objOItem_Result = objOItem_Result_User

                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                LogEntryList = (From objLogEntry in logEntries
                                                Join objDateTimeStamp in objDBLevel_DateTimeStamp.OList_ObjectAtt on objLogEntry.GUID Equals objDateTimeStamp.ID_Object
                                                Group Join objMessage In objDBLevel_Message.OList_ObjectAtt on objLogEntry.GUID Equals objMessage.ID_Object Into objMessages = Group
                                                From objMessage In objMessages.DefaultIfEmpty()
                                                Join objLogState In objDBLevel_LogState.OList_ObjectRel on objLogEntry.GUID Equals objLogState.ID_Object
                                                Join objUser In objDBLevel_User.OList_ObjectRel on objLogEntry.GUID Equals objUser.ID_Object
                                                Select New clsLogEntry With 
                                                       {
                                                           .ID_LogEntry = objLogEntry.GUID,
                                                           .Name_LogEntry = objLogEntry.Name,
                                                           .ID_Attribute_DateTimeStamp = objDateTimeStamp.ID_Attribute,
                                                           .DateTimeStamp = objDateTimeStamp.Val_Date,
                                                           .ID_Attribute_Message = If (objMessage Is Nothing, Nothing, objMessage.ID_Attribute),
                                                           .Message = If (objMessage Is Nothing, Nothing, objMessage.Val_String),
                                                           .ID_LogState = objLogState.ID_Other,
                                                           .Name_LogState = objLogState.Name_Other,
                                                           .ID_User = objUser.ID_Other,
                                                           .Name_User = objUser.Name_Other
                                                       }).ToList()
                            End If
                        End If
                    End If
                End If
            End If
        End If

        objOItem_Result_Data = objOItem_Result
    End Sub

    Private Sub GetSubData_DateTimeStamp() 

        objOItem_Result_DateTimeStamp = objLocalConfig.Globals.LState_Nothing.Clone()
        
        If logEntries.Any() Then
            Dim searchDateTimeStamp = logEntries.Select(Function(log) New clsObjectAtt With {.ID_Object = log.GUID,
                                                                                             .ID_AttributeType = objLocalConfig.OItem_Attribute_DateTimeStamp.GUID }).ToList()

            objOItem_Result_DateTimeStamp = objDBLevel_DateTimeStamp.get_Data_ObjectAtt(searchDateTimeStamp, boolIDs := False)

        End If

        
    End Sub

    Private Sub GetSubData_Message() 
        objOItem_Result_Message = objLocalConfig.Globals.LState_Nothing.Clone()
        
        If logEntries.Any() Then
            Dim searchDateMessage = logEntries.Select(Function(log) New clsObjectAtt With {.ID_Object = log.GUID,
                                                                                             .ID_AttributeType = objLocalConfig.OItem_Attribute_Message.GUID }).ToList()

            objOItem_Result_Message = objDBLevel_Message.get_Data_ObjectAtt(searchDateMessage, boolIDs := False)

        End If

        
    End Sub

    Private Sub GetSubData_LogState()
        
        objOItem_Result_LogState = objLocalConfig.Globals.LState_Nothing.Clone()

        If logEntries.Any() Then
            Dim searchLogStates = logEntries.Select(Function(log) New clsObjectRel With {.ID_Object = log.GUID,
                                                                                         .ID_Parent_Other = objLocalConfig.OItem_type_Logstate.GUID,
                                                                                         .ID_RelationType = objLocalConfig.OItem_RelationType_provides.GUID }).ToList()

            objOItem_Result_LogState = objDBLevel_LogState.get_Data_ObjectRel(searchLogStates, boolIDs := False)
        End If

        
    End Sub

    Private Sub GetSubData_User() 
        objOItem_Result_User = objLocalConfig.Globals.LState_Nothing.Clone()

        If logEntries.Any() Then
            Dim searchLogUsers = logEntries.Select(Function(log) New clsObjectRel With {.ID_Object = log.GUID,
                                                                                         .ID_Parent_Other = objLocalConfig.OItem_type_User.GUID,
                                                                                         .ID_RelationType = objLocalConfig.OItem_RelationType_wasCreatedBy.GUID }).ToList()

            objOItem_Result_User = objDBLevel_User.get_Data_ObjectRel(searchLogUsers, boolIDs := False)
        End If

        
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objDBLevel_Ref = new clsDBLevel(objLocalConfig.Globals)
        objDBLevel_DateTimeStamp = new clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Message = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_LogState = new clsDBLevel(objLocalConfig.Globals)
        objDBLevel_User = new clsDBLevel(objLocalConfig.Globals)

        objOItem_Result_Data = objLocalConfig.Globals.LState_Nothing.Clone()
    End Sub
End Class
