Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class clsLogManagement
    Private objLocalConfig As clsLocalConfig
    Private objOItem_LogEntry As clsOntologyItem
    Private objOItem_LogState As clsOntologyItem
    Private objOItem_User As clsOntologyItem

    'Private objTransaction_LogEntries As clsTransaction_LogEntry
    Private objDataWork_LogEntry As clsDataWork_LogEntry
    Private objTransaction_LogEntries As clsTransaction
    Private objRelationConfig As clsRelationConfig
    Private objOA_DateTimeStamp As clsObjectAtt

    Public ReadOnly Property OAItem_DateTimeStamp As clsObjectAtt
        Get
            Return objOA_DateTimeStamp
        End Get
    End Property

    Private strMessage As String

    Public ReadOnly Property OItem_LogEntry As clsOntologyItem
        Get
            Return objOItem_LogEntry
        End Get
    End Property

    Public Function log_Entry(ByVal dateTimestamp As Date, ByVal OItem_LogState As clsOntologyItem, ByVal OItem_User As clsOntologyItem, Optional ByVal strMessage As String = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOARel_LogEntry__DateTimeStamp As clsObjectAtt
        Dim objOARel_LogEntry__Message As clsObjectAtt
        Dim objORel_LogEntry_To_LogState As clsObjectRel
        Dim objORel_LogEntry_To_User As clsObjectRel

        objOItem_LogEntry = New clsOntologyItem
        objOItem_LogEntry.GUID = objOItem_LogEntry.NewGuid

        If strMessage = "" Or strMessage Is Nothing Then
            objOItem_LogEntry.Name = dateTimestamp.ToString
        Else
            If strMessage.Length > 200 Then
                objOItem_LogEntry.Name = dateTimestamp.ToString & ": " & strMessage.Substring(0, 200) & "..."
            Else
                objOItem_LogEntry.Name = dateTimestamp.ToString & ": " & strMessage
            End If
        End If

        objOItem_LogEntry.GUID_Parent = objLocalConfig.OItem_Type_LogEntry.GUID
        objOItem_LogEntry.Type = objLocalConfig.Globals.Type_Object
        objOA_DateTimeStamp = Nothing
        'objOItem_Result = objTransaction_LogEntries.save_001_LogEntry(objOItem_LogEntry)

        objOItem_LogState = OItem_LogState
        objOItem_User = OItem_User

        objOItem_Result = objTransaction_LogEntries.do_Transaction(objOItem_LogEntry)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOARel_LogEntry__DateTimeStamp = objRelationConfig.Rel_ObjectAttribute(objOItem_LogEntry, objLocalConfig.OItem_Attribute_DateTimeStamp, dateTimestamp)
            If Not objOARel_LogEntry__DateTimeStamp Is Nothing Then
                objOItem_Result = objTransaction_LogEntries.do_Transaction(objOARel_LogEntry__DateTimeStamp, True)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Dim objOItem_TransactionItem = objTransaction_LogEntries.OItem_Last
                    objOA_DateTimeStamp = New clsObjectAtt With {.ID_Attribute = objOItem_TransactionItem.OItem_ObjectAtt.ID_Attribute, _
                                                                 .ID_AttributeType = objOItem_TransactionItem.OItem_ObjectAtt.ID_AttributeType, _
                                                                 .ID_Class = objOItem_TransactionItem.OItem_ObjectAtt.ID_Class, _
                                                                 .ID_Object = objOItem_TransactionItem.OItem_ObjectAtt.ID_Object, _
                                                                 .ID_DataType = objOItem_TransactionItem.OItem_ObjectAtt.ID_DataType, _
                                                                 .Val_Named = objOItem_TransactionItem.OItem_ObjectAtt.Val_Named, _
                                                                 .Val_Date = objOItem_TransactionItem.OItem_ObjectAtt.Val_Date}

                    objOARel_LogEntry__Message = objDataWork_LogEntry.RelA_LogEntry__Message(objOItem_LogEntry, strMessage)
                    If Not strMessage Is Nothing Then
                        objOARel_LogEntry__Message = objRelationConfig.Rel_ObjectAttribute(objOItem_LogEntry, objLocalConfig.OItem_Attribute_Message, strMessage)
                        If Not objOARel_LogEntry__Message Is Nothing Then
                            objOItem_Result = objTransaction_LogEntries.do_Transaction(objOARel_LogEntry__Message, True)
                        Else
                            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
                        End If
                    End If
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                        objORel_LogEntry_To_LogState = objRelationConfig.Rel_ObjectRelation(objOItem_LogEntry, objOItem_LogState, objLocalConfig.OItem_RelationType_provides)
                        If Not objORel_LogEntry_To_LogState Is Nothing Then
                            objOItem_Result = objTransaction_LogEntries.do_Transaction(objORel_LogEntry_To_LogState, True)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objORel_LogEntry_To_User = objRelationConfig.Rel_ObjectRelation(objOItem_LogEntry, objOItem_User, objLocalConfig.OItem_RelationType_wasCreatedBy)
                                If Not objORel_LogEntry_To_User Is Nothing Then
                                    objOItem_Result = objTransaction_LogEntries.do_Transaction(objORel_LogEntry_To_User, True)
                                    If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        objTransaction_LogEntries.rollback()
                                        objOItem_LogEntry = Nothing
                                    End If
                                Else
                                    objTransaction_LogEntries.rollback()
                                    objOItem_LogEntry = Nothing
                                End If


                            Else
                                objTransaction_LogEntries.rollback()
                                objOItem_LogEntry = Nothing
                            End If
                        Else
                            objTransaction_LogEntries.rollback()
                            objOItem_LogEntry = Nothing
                        End If

                    Else
                        objTransaction_LogEntries.rollback()
                        objOItem_LogEntry = Nothing
                    End If

                Else
                    objTransaction_LogEntries.rollback()
                    objOItem_LogEntry = Nothing
                End If
            Else
                objTransaction_LogEntries.rollback()
                objOItem_LogEntry = Nothing
            End If
            
        End If

        Return objOItem_Result
    End Function

    Public Function del_LogEntry(ByVal OItem_LogEntry As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOARel_LogEntry__DateTimeStamp As clsObjectAtt
        Dim objOARel_LogEntry__Message As clsObjectAtt
        Dim objORel_LogEntry_To_LogState As clsObjectRel
        Dim objORel_LogEntry_To_User As clsObjectRel

        objTransaction_LogEntries.fill_TransactionList(objOItem_LogEntry)

        objOARel_LogEntry__DateTimeStamp = New clsObjectAtt(Nothing, _
                                                            objOItem_LogEntry.GUID, _
                                                            Nothing, _
                                                            objLocalConfig.OItem_Attribute_DateTimeStamp.GUID, _
                                                            Nothing)

        objTransaction_LogEntries.fill_TransactionList(objOARel_LogEntry__DateTimeStamp)

        objOARel_LogEntry__Message = New clsObjectAtt(Nothing, _
                                                      objOItem_LogEntry.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Attribute_Message.GUID, _
                                                      Nothing)

        objTransaction_LogEntries.fill_TransactionList(objOARel_LogEntry__Message)

        objORel_LogEntry_To_LogState = New clsObjectRel(objOItem_LogEntry.GUID, _
                                                        Nothing, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_type_Logstate.GUID, _
                                                        objLocalConfig.OItem_RelationType_provides.GUID, _
                                                        objLocalConfig.Globals.Type_Object, _
                                                        Nothing, _
                                                        Nothing)

        objTransaction_LogEntries.fill_TransactionList(objORel_LogEntry_To_LogState)

        objORel_LogEntry_To_User = New clsObjectRel(objOItem_LogEntry.GUID, _
                                                        Nothing, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_type_User.GUID, _
                                                        objLocalConfig.OItem_RelationType_wasCreatedBy.GUID, _
                                                        objLocalConfig.Globals.Type_Object, _
                                                        Nothing, _
                                                        Nothing)

        objTransaction_LogEntries.fill_TransactionList(objORel_LogEntry_To_User)

        objOItem_Result = objTransaction_LogEntries.rollback

        Return objOItem_Result
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig, DataWork As clsDataWork_LogEntry)
        objLocalConfig = LocalConfig
        objDataWork_LogEntry = DataWork
        set_DBConnection()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)
        objDataWork_LogEntry = New clsDataWork_LogEntry(objLocalConfig)
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        'objTransaction_LogEntries = New clsTransaction_LogEntry(objLocalConfig)
        objTransaction_LogEntries = New clsTransaction(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
    End Sub
End Class
