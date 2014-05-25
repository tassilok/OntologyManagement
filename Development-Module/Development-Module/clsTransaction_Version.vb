Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Version_Module

Public Class clsTransaction_Version
    Private objOList_VersionedDevs As List(Of clsOntologyItem)

    Private objLocalConfig As clsLocalConfig

    Private objTransaction As clsTransaction
    Private objRelationConfig As clsRelationConfig
    Private objDataWork_Details As clsDataWork_Details

    Private objFrmPar As Windows.Forms.IWin32Window
    Private objFrm_VersionEdit As frmVersionEdit

    Private objOItem_Dev As clsOntologyItem

    Private WithEvents objFrmOntologyItemList As frmOntologyItemList


    Private Sub PressedOkItemListForVersioning() Handles objFrmOntologyItemList.PressedOK

        Dim objOItem_LogEntry_Par = Save_Version(objOItem_Dev)
        objFrmOntologyItemList.RemoveItem(objOItem_Dev.GUID)
        objOList_VersionedDevs = objFrmOntologyItemList.ItemListVisible.Select(Function(i) New clsOntologyItem With {.GUID = i.GUID,
                                                                                                                     .Name = i.Name,
                                                                                                                     .GUID_Parent = i.GUID_Parent,
                                                                                                                     .Type = i.Type}).ToList()
        For Each objOItem_Dev_Dependend In objOList_VersionedDevs
            Save_Version(objOItem_Dev_Dependend, objOItem_LogEntry_Par, True)
            objFrmOntologyItemList.RemoveItem(objOItem_Dev_Dependend.GUID)
        Next

        objFrmOntologyItemList.Close()

    End Sub

    Public Function SaveVersion() As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()
        objOList_VersionedDevs = New List(Of clsOntologyItem)

        GetDependendHierarchy(objOItem_Dev)
        Dim objVisColList = New List(Of String) From {"Name"}
        objFrmOntologyItemList = New frmOntologyItemList(objOList_VersionedDevs, objLocalConfig.Globals, objVisColList, "Zu versionierende Softwareentwicklungen")
        objFrmOntologyItemList.Show()

        Return objOItem_Result
    End Function


    Private Sub GetDependendHierarchy(OItem_Dev As clsOntologyItem)
        If Not objOList_VersionedDevs.Any(Function(d) d.GUID = OItem_Dev.GUID) Then
            objOList_VersionedDevs.Add(OItem_Dev)
            Dim objOList_DependendDevs = objDataWork_Details.GetData_DependentDevelopments(OItem_Dev)
            For Each objDev In objOList_DependendDevs
                GetDependendHierarchy(objDev)
            Next
        End If
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig, FrmPar As Windows.Forms.IWin32Window, OItem_Dev As clsOntologyItem, Optional DataWork_Details As clsDataWork_Details = Nothing)

        objLocalConfig = LocalConfig
        objFrmPar = FrmPar
        objOItem_Dev = OItem_Dev
        Initialize()
    End Sub

    Private Sub Initialize()
        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
        If objDataWork_Details Is Nothing Then
            objDataWork_Details = New clsDataWork_Details(objLocalConfig)
        End If

    End Sub

    Private Function Save_Version(OItem_Development As clsOntologyItem, Optional OItem_LogEntry_Parent As clsOntologyItem = Nothing, Optional isDependend As Boolean = False) As clsOntologyItem
        Dim objOItem_LogEntry As clsOntologyItem = Nothing
        Dim objOItem_Result As clsOntologyItem

        If objFrm_VersionEdit Is Nothing Then
            objFrm_VersionEdit = New frmVersionEdit(objLocalConfig.Globals, objLocalConfig.OItem_User)
        End If
        objFrm_VersionEdit.Initialize_VersionEdit(OItem_Development)
        objFrm_VersionEdit.ShowDialog(objFrmPar)
        If objFrm_VersionEdit.DialogResult = DialogResult.OK Then
            If objFrm_VersionEdit.OItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If Not objFrm_VersionEdit.OItem_Version Is Nothing Then
                    objOItem_LogEntry = objFrm_VersionEdit.OItem_LogEntry
                    If Not objOItem_LogEntry Is Nothing Then
                        objTransaction.ClearItems()
                        Dim objORel_Dev_LogEntry = objDataWork_Details.Rel_Dev_LogEntry(objOItem_Dev, objOItem_LogEntry)
                        objOItem_Result = objTransaction.do_Transaction(objORel_Dev_LogEntry)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            If Not isDependend Then
                                objDataWork_Details.OItem_Version = objFrm_VersionEdit.OItem_Version.Clone()
                            End If


                            If Not OItem_LogEntry_Parent Is Nothing Then
                                Dim objORel_LogEntry_To_LogEntry = objRelationConfig.Rel_ObjectRelation(objOItem_LogEntry, OItem_LogEntry_Parent, objLocalConfig.OItem_RelationType_belongsTo)
                                objOItem_Result = objTransaction.do_Transaction(objORel_LogEntry_To_LogEntry)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                    MsgBox("Die Abhängige Versionsänderung konnte nicht protokolliert werden!", MsgBoxStyle.Exclamation)
                                End If
                            End If
                        Else
                            MsgBox("Die Version konnte nicht verknüpft werden!", MsgBoxStyle.Exclamation)
                        End If

                    Else
                        MsgBox("Die Version konnte nicht verknüpft werden!", MsgBoxStyle.Exclamation)
                    End If

                End If
            End If



        End If

        Return objOItem_LogEntry
    End Function
End Class
