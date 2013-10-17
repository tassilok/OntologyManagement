Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class clsTransaction_LogEntry
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_LogEntry As clsDBLevel

    Private objTransaction_LogEntry As clsTransaction

    Private objOItem_LogEntry As clsOntologyItem
    Private objOItem_LogState As clsOntologyItem
    Private objOItem_ObjectAttribute_DateTimeStamp As clsObjectAtt
    Private objOItem_ObjectAttribute_Message As clsObjectAtt
    Private objOItem_User As clsOntologyItem
    Private objORItem_LogEntryToUser As clsObjectRel

    Public Function save_001_LogEntry(ByVal OItem_LogEntry As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Logentries As New List(Of clsOntologyItem)

        objOItem_LogEntry = OItem_LogEntry

        objOList_Logentries.Add(objOItem_LogEntry)

        objOItem_Result = objDBLevel_LogEntry.save_Objects(objOList_Logentries)

        Return objOItem_Result
    End Function

    Public Function del_001_LogEntry(Optional ByVal OItem_LogEntry As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_LogEntries As New List(Of clsOntologyItem)

        If Not OItem_LogEntry Is Nothing Then
            objOItem_LogEntry = OItem_LogEntry
        End If

        objOList_LogEntries.Add(objOItem_LogEntry)

        objOItem_Result = objDBLevel_LogEntry.del_Objects(objOList_LogEntries)

        If objOItem_Result.Val_Long = 0 Then
            objOItem_Result = objLocalConfig.Globals.LState_Success
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        Return objOItem_Result
    End Function

    Public Function save_002_LogEntry_To_LogState(ByVal OItem_LogState As clsOntologyItem, Optional ByVal OItem_LogEntry As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_LogEntry_To_LogState As New List(Of clsObjectRel)

        objOItem_LogState = OItem_LogState

        If Not OItem_LogEntry Is Nothing Then
            objOItem_LogEntry = OItem_LogEntry
        End If

        objOList_LogEntry_To_LogState.Add(New clsObjectRel(objOItem_LogEntry.GUID, _
                                                           Nothing, _
                                                           Nothing, _
                                                           Nothing, _
                                                           objOItem_LogState.GUID, _
                                                           Nothing, _
                                                           Nothing, _
                                                           Nothing, _
                                                           objLocalConfig.OItem_RelationType_provides.GUID, _
                                                           Nothing, _
                                                           objLocalConfig.Globals.Type_Object, _
                                                           Nothing, _
                                                           Nothing, _
                                                           Nothing))

        objOItem_Result = objDBLevel_LogEntry.save_ObjRel(objOList_LogEntry_To_LogState)

        Return objOItem_Result
    End Function

    Public Function del_002_LogEntry_To_LogState(Optional ByVal OItem_LogState As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_LogEntry_To_LogState As New List(Of clsObjectRel)

        objOList_LogEntry_To_LogState.Add(New clsObjectRel(objOItem_LogEntry.GUID, _
                                                           Nothing, _
                                                           Nothing, _
                                                           Nothing, _
                                                           objOItem_LogState.GUID, _
                                                           Nothing, _
                                                           Nothing, _
                                                           Nothing, _
                                                           objLocalConfig.OItem_RelationType_provides.GUID, _
                                                           Nothing, _
                                                           objLocalConfig.Globals.Type_Object, _
                                                           Nothing, _
                                                           Nothing, _
                                                           Nothing))

        objOItem_Result = objDBLevel_LogEntry.del_ObjectRel(objOList_LogEntry_To_LogState)


        Return objOItem_Result
    End Function

    Public Function save_003_LogEntry__DateTimeStamp(ByVal dateDateTimeStamp As Date, Optional ByVal OItem_LogEntry As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLObjectAtt As New List(Of clsObjectAtt)

        objOItem_ObjectAttribute_DateTimeStamp = New clsObjectAtt(Nothing, _
                                                                  objOItem_LogEntry.GUID, _
                                                                  objOItem_LogEntry.Name, _
                                                                  objLocalConfig.OItem_Type_LogEntry.GUID, _
                                                                  objLocalConfig.OItem_Type_LogEntry.Name, _
                                                                  objLocalConfig.OItem_Attribute_DateTimeStamp.GUID, _
                                                                  objLocalConfig.OItem_Attribute_DateTimeStamp.Name, _
                                                                  1, _
                                                                  dateDateTimeStamp.ToString, _
                                                                  Nothing, _
                                                                  dateDateTimeStamp, _
                                                                  Nothing, _
                                                                  Nothing, _
                                                                  Nothing, _
                                                                  objLocalConfig.Globals.DType_DateTime.GUID)

        objOLObjectAtt.Add(objOItem_ObjectAttribute_DateTimeStamp)

        objOItem_Result = objDBLevel_LogEntry.save_ObjAtt(objOLObjectAtt)

        Return objOItem_Result
    End Function

    Public Function del_003_LogEntry__DateTimeStamp(Optional ByVal OItem_LogEntry As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLObjectAtt As New List(Of clsObjectAtt)

        If Not OItem_LogEntry Is Nothing Then
            objOItem_LogEntry = OItem_LogEntry
        End If

        objOLObjectAtt.Add(New clsObjectAtt(Nothing, _
                                            objOItem_LogEntry.GUID, _
                                            Nothing, _
                                            objLocalConfig.OItem_Attribute_DateTimeStamp.GUID, _
                                            Nothing))

        objOItem_Result = objDBLevel_LogEntry.del_ObjectAtt(objOLObjectAtt)

        Return objOItem_Result
    End Function

    Public Function save_004_LogEntry__Message(ByVal strMessage As String, Optional ByVal OItem_LogEntry As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLObjectAtt As New List(Of clsObjectAtt)

        If Not OItem_LogEntry Is Nothing Then
            objOItem_LogEntry = OItem_LogEntry
        End If

        objOItem_ObjectAttribute_Message = New clsObjectAtt(Nothing, _
                                                                  objOItem_LogEntry.GUID, _
                                                                  objOItem_LogEntry.Name, _
                                                                  objLocalConfig.OItem_Type_LogEntry.GUID, _
                                                                  objLocalConfig.OItem_Type_LogEntry.Name, _
                                                                  objLocalConfig.OItem_Attribute_Message.GUID, _
                                                                  objLocalConfig.OItem_Attribute_Message.Name, _
                                                                  1, _
                                                                  strMessage, _
                                                                  Nothing, _
                                                                  Nothing, _
                                                                  Nothing, _
                                                                  Nothing, _
                                                                  strMessage, _
                                                                  objLocalConfig.Globals.DType_String.GUID)

        objOItem_Result = objDBLevel_LogEntry.save_ObjAtt(objOLObjectAtt)

        Return objOItem_Result
    End Function

    Public Function del_004_LogEntry__Messages(Optional ByVal OItem_LogEntry As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLObjectAtt As New List(Of clsObjectAtt)

        If Not OItem_LogEntry Is Nothing Then
            objOItem_LogEntry = OItem_LogEntry
        End If

        objOLObjectAtt.Add(New clsObjectAtt(Nothing, _
                                            objOItem_LogEntry.GUID, _
                                            Nothing, _
                                            objLocalConfig.OItem_Attribute_Message.GUID, _
                                            Nothing))

        objOItem_Result = objDBLevel_LogEntry.del_ObjectAtt(objOLObjectAtt)

        Return objOItem_Result
    End Function

    Public Function save_005_LogEntry_To_User(OItem_User As clsOntologyItem, Optional OItem_LogEntry As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_User = OItem_User
        If Not OItem_LogEntry Is Nothing Then
            objOItem_LogEntry = OItem_LogEntry
        End If


        objORItem_LogEntryToUser = New clsObjectRel(objOItem_LogEntry.GUID, _
                                                       objOItem_LogEntry.GUID_Parent, _
                                                       objOItem_User.GUID, _
                                                       objOItem_User.GUID_Parent, _
                                                       objLocalConfig.OItem_RelationType_wasCreatedBy.GUID, _
                                                       objLocalConfig.Globals.Type_Object, _
                                                       Nothing, _
                                                       1)

        objTransaction_LogEntry.ClearItems()
        objOItem_Result = objTransaction_LogEntry.do_Transaction(objORItem_LogEntryToUser, True)

        Return objOItem_Result
    End Function

    Public Function del_005_LogEntry_To_User(Optional OItem_LogEntry As clsOntologyItem = Nothing, Optional OItem_User As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        If Not OItem_LogEntry Is Nothing Then
            objOItem_LogEntry = OItem_LogEntry
        End If

        If Not OItem_User Is Nothing Then
            objOItem_User = OItem_User
        End If


        objORItem_LogEntryToUser = New clsObjectRel(objOItem_LogEntry.GUID, _
                                                       Nothing, _
                                                       objOItem_User.GUID, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_RelationType_wasCreatedBy.GUID, _
                                                       objLocalConfig.Globals.Type_Object, _
                                                       Nothing, _
                                                       Nothing)

        objTransaction_LogEntry.ClearItems()
        objOItem_Result = objTransaction_LogEntry.do_Transaction(objORItem_LogEntryToUser, False, True)

        Return objOItem_Result
    End Function



    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_LogEntry = New clsDBLevel(objLocalConfig.Globals)
        objTransaction_LogEntry = New clsTransaction(objLocalConfig.Globals)
    End Sub
End Class
