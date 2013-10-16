Imports Log_Module
Imports Ontolog_Module
Imports OntologyClasses.BaseClasses
Imports Structure_Module

Public Class clsDataWork_LogEntries

    Private objLocalConfig As clsLocalConfig
    Private objDataWork_LogEntry As clsDataWork_LogEntry

    Private objOItem_Development As clsOntologyItem

    Private OList_LogEntries As List(Of Dictionary(Of String, Object))
    Public OList_LogEntryList As SortableBindingList(Of clsLogEntry)

    Public Function GetData(OItem_Dev As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone

        objOItem_Development = OItem_Dev

        OList_LogEntryList = New SortableBindingList(Of clsLogEntry)(objDataWork_LogEntry.get_Data_LogEntryOfRef(objOItem_Development, objLocalConfig.Oitem_RelationType_Happened))

        Return objOItem_Result
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        objDataWork_LogEntry = New clsDataWork_LogEntry(objLocalConfig.Globals)
    End Sub
End Class
