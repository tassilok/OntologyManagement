Imports Ontolog_Module
Public Class clsLogManagement
    Private objLocalConfig As clsLocalConfig
    Private objOItem_LogEntry As clsOntologyItem
    Private objOItem_LogState As clsOntologyItem
    Private objOItem_User As clsOntologyItem

    Private objTransaction_LogEntries As clsTransaction_LogEntry

    Private strMessage As String

    Public ReadOnly Property OItem_LogEntry As clsOntologyItem
        Get
            Return objOItem_LogEntry
        End Get
    End Property

    Public Function log_Entry(ByVal dateTimestamp As Date, ByVal OItem_LogState As clsOntologyItem, ByVal OItem_User As clsOntologyItem, Optional ByVal strMessage As String = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_LogEntry = New clsOntologyItem
        objOItem_LogEntry.GUID = objOItem_LogEntry.NewGUID

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

        objOItem_Result = objTransaction_LogEntries.save_001_LogEntry(objOItem_LogEntry)

        objOItem_LogState = OItem_LogState
        objOItem_User = OItem_User

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOItem_Result = objTransaction_LogEntries.save_002_LogEntry_To_LogState(objOItem_LogState, _
                                                                                      objOItem_LogEntry)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objOItem_Result = objTransaction_LogEntries.save_003_LogEntry__DateTimeStamp(dateTimestamp, _
                                                                                               objOItem_LogEntry)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If Not strMessage = "" And Not strMessage Is Nothing Then
                        objOItem_Result = objTransaction_LogEntries.save_004_LogEntry__Message(strMessage, _
                                                                                               objOItem_LogEntry)
                        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objOItem_Result = objTransaction_LogEntries.del_003_LogEntry__DateTimeStamp()
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objOItem_Result = objTransaction_LogEntries.del_002_LogEntry_To_LogState()
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objTransaction_LogEntries.del_001_LogEntry()
                                End If
                            End If


                            objOItem_LogEntry = Nothing
                        End If
                    End If
                Else
                    objOItem_Result = objTransaction_LogEntries.del_002_LogEntry_To_LogState()
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objTransaction_LogEntries.del_001_LogEntry()
                    End If

                    objOItem_LogEntry = Nothing
                End If
            Else
                objTransaction_LogEntries.del_001_LogEntry()

                objOItem_LogEntry = Nothing
            End If
        Else
            objOItem_LogEntry = Nothing
        End If
        Return objOItem_Result
    End Function

    Public Function del_LogEntry(ByVal OItem_LogEntry As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_Result = objTransaction_LogEntries.del_004_LogEntry__Messages(objOItem_LogEntry)
        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objOItem_Result = objTransaction_LogEntries.del_003_LogEntry__DateTimeStamp()
            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                objOItem_Result = objTransaction_LogEntries.del_002_LogEntry_To_LogState()
                If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    objOItem_Result = objTransaction_LogEntries.del_001_LogEntry()
                    If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID _
                        And Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Relation.GUID Then
                        objOItem_Result = objLocalConfig.Globals.LState_Success
                    Else
                        objOItem_Result = objLocalConfig.Globals.LState_Error
                    End If

                End If
            End If
        End If

        Return objOItem_Result
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objTransaction_LogEntries = New clsTransaction_LogEntry(objLocalConfig)
    End Sub
End Class
