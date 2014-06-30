Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Version_Module
Imports TextParser

Public Class clsTransaction_Version
    Private objOList_VersionedDevs As List(Of clsOntologyItem)
    Private objOList_VersionErr As List(Of clsOntologyItem)

    Private objLocalConfig As clsLocalConfig

    Private objTransaction As clsTransaction
    Private objRelationConfig As clsRelationConfig
    Private objDataWork_Details As clsDataWork_Details

    Private objFrmPar As Windows.Forms.IWin32Window
    Private objFrm_VersionEdit As frmVersionEdit

    Private objOItem_Dev As clsOntologyItem

    Private WithEvents objFrmOntologyItemList As frmOntologyItemList

    Private objFieldParser As clsFieldParser

    Public Property OItem_Version_Last As clsOntologyItem

    Private boolSaveVersionFile As Boolean

    Private Sub PressedOkItemListForVersioning() Handles objFrmOntologyItemList.PressedOK

        Dim objOItem_LogEntry_Par = Save_Version(objOItem_Dev)
        objFrmOntologyItemList.RemoveItem(objOItem_Dev.GUID)
        objOList_VersionedDevs = objFrmOntologyItemList.ItemListVisible.Select(Function(i) New clsOntologyItem With {.GUID = i.GUID,
                                                                                                                     .Name = i.Name,
                                                                                                                     .GUID_Parent = i.GUID_Parent,
                                                                                                                     .Type = i.Type}).ToList()
        If boolSaveVersionFile Then
            SaveVersionFile(objOItem_Dev)
        End If

        

        For Each objOItem_Dev_Dependend In objOList_VersionedDevs
            Save_Version(objOItem_Dev_Dependend, objOItem_LogEntry_Par, True)
            If boolSaveVersionFile Then
                SaveVersionFile(objOItem_Dev_Dependend)
            End If
            objFrmOntologyItemList.RemoveItem(objOItem_Dev_Dependend.GUID)
            

        Next

        objFrmOntologyItemList.Close()
        If objOList_VersionErr.Any() Then
            Dim objVisColList = New List(Of String) From {"Name"}
            objFrmOntologyItemList = New frmOntologyItemList(objOList_VersionErr, objLocalConfig.Globals, objVisColList, "Errors while saven version to Assembly-File")
            objFrmOntologyItemList.ShowDialog()
        End If
    End Sub

    Public Function GetPhysicalVersion(objOItem_Dev As clsOntologyItem) As String
        Dim objOItem_Result = objDataWork_Details.GetData_VersionFilePath(objOItem_Dev)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Try
                Dim objTextStream = IO.File.OpenText(objOItem_Result.Additional1)

                If Not objTextStream Is Nothing Then

                    While Not objTextStream.EndOfStream
                        Dim textLine = objTextStream.ReadLine

                        Dim textLineWrite = objFieldParser.ParseLine(textLine, Nothing)

                    End While



                    objTextStream.Close()

                    If objFieldParser.FoundFields.Any() Then
                        Return objFieldParser.FoundFields.First()
                    Else
                        Return Nothing
                    End If

                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Return Nothing
            End Try
        Else
            Return Nothing
        End If
    End Function

    Public Function SaveVersionFile(objOItem_Dev As clsOntologyItem) As clsOntologyItem

        Dim objOItem_Result = objDataWork_Details.GetData_VersionFilePath(objOItem_Dev)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID And Not OItem_Version_Last Is Nothing Then

            Try
                Dim objTextStream = IO.File.OpenText(objOItem_Result.Additional1)
                Dim strPath = "%TEMP%\" & objLocalConfig.Globals.NewGUID
                Dim strPathBak = "%TEMP%\" & objLocalConfig.Globals.NewGUID
                strPath = Environment.ExpandEnvironmentVariables(strPath)
                strPathBak = Environment.ExpandEnvironmentVariables(strPathBak)
                Dim objTextStreamWrite As IO.TextWriter = New IO.StreamWriter(strPath)

                Dim objOList_Variables = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID = objLocalConfig.OItem_object_version.GUID,
                                                  .Name = objLocalConfig.OItem_object_version.Name,
                                                  .GUID_Parent = objLocalConfig.OItem_object_version.GUID_Parent,
                                                  .Type = objLocalConfig.Globals.Type_Object,
                                                  .Additional1 = OItem_Version_Last.Name}}

                If Not objTextStream Is Nothing And Not objTextStreamWrite Is Nothing Then

                    Dim boolChanged = False

                    While Not objTextStream.EndOfStream
                        Dim textLine = objTextStream.ReadLine

                        Dim textLineWrite = objFieldParser.ParseLine(textLine, objOList_Variables)

                        If Not textLine.Equals(textLineWrite) Then
                            boolChanged = True
                        End If


                        objTextStreamWrite.WriteLine(textLineWrite)
                    End While

                    objTextStream.Close()
                    objTextStreamWrite.Close()

                    If boolChanged Then
                        IO.File.Move(objOItem_Result.Additional1, strPathBak)
                        IO.File.Copy(strPath, objOItem_Result.Additional1)
                    Else
                        objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
                        objOList_VersionErr.Add(objOItem_Dev)
                    End If




                    IO.File.Delete(strPath)
                    IO.File.Delete(strPathBak)

                Else
                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
                    objOList_VersionErr.Add(objOItem_Dev)
                End If
            Catch ex As Exception
                objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
                objOList_VersionErr.Add(objOItem_Dev)
            End Try


        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
            objOList_VersionErr.Add(objOItem_Dev)
        End If

        Return objOItem_Result
    End Function

    Public Function SaveVersion(boolSaveVersionFile As Boolean) As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()
        Me.boolSaveVersionFile = boolSaveVersionFile
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
        objOList_VersionedDevs.Sort(Function(ver1, ver2) ver1.Name.CompareTo(ver2.Name))

    End Sub

    Public Sub New(LocalConfig As clsLocalConfig, FrmPar As Windows.Forms.IWin32Window, OItem_Dev As clsOntologyItem, Optional DataWork_Details As clsDataWork_Details = Nothing)


        objLocalConfig = LocalConfig
        objDataWork_Details = DataWork_Details
        objFrmPar = FrmPar
        objOItem_Dev = OItem_Dev
        Initialize()
    End Sub

    Private Sub Initialize()
        objFieldParser = New clsFieldParser(objLocalConfig.Globals)

        Dim objOItem_Result = objFieldParser.Initialize_FieldParser(objLocalConfig.OItem_object_visual_studio_version_parser)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOList_VersionErr = New List(Of clsOntologyItem)
            objTransaction = New clsTransaction(objLocalConfig.Globals)
            objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
            If objDataWork_Details Is Nothing Then
                objDataWork_Details = New clsDataWork_Details(objLocalConfig)
            End If
        Else
            Err.Raise(1, , "No defined fieldparser!")
        End If
        

    End Sub

    Private Function Save_Version(OItem_Development As clsOntologyItem, Optional OItem_LogEntry_Parent As clsOntologyItem = Nothing, Optional isDependend As Boolean = False) As clsOntologyItem
        Dim objOItem_LogEntry As clsOntologyItem = Nothing
        Dim objOItem_Result As clsOntologyItem
        OItem_Version_Last = Nothing
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
                                OItem_Version_Last = objFrm_VersionEdit.OItem_Version.Clone()
                            End If


                            If Not OItem_LogEntry_Parent Is Nothing Then
                                Dim objORel_LogEntry_To_LogEntry = objRelationConfig.Rel_ObjectRelation(objOItem_LogEntry, OItem_LogEntry_Parent, objLocalConfig.OItem_RelationType_belongsTo)
                                objOItem_Result = objTransaction.do_Transaction(objORel_LogEntry_To_LogEntry)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                    OItem_Version_Last = Nothing
                                    MsgBox("Die Abhängige Versionsänderung konnte nicht protokolliert werden!", MsgBoxStyle.Exclamation)

                                Else
                                    OItem_Version_Last = objFrm_VersionEdit.OItem_Version.Clone()
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
