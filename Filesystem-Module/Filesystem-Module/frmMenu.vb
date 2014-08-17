Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Structure_Module

Public Class frmMenu
    Private objLocalConfig As clsLocalConfig

    Private objDataWork_Menu As clsDataWork_Menu

    Private objBlobConnection As clsBlobConnection

    Private objOItem_Ref As clsOntologyItem

    Public Sub New(LocalConfig As clsLocalConfig, OItem_Ref As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        objOItem_Ref = OItem_Ref

        Initialize()
    End Sub

    Private Sub Initialize()
        objDataWork_Menu = New clsDataWork_Menu(objLocalConfig)
        objBlobConnection = New clsBlobConnection(objLocalConfig)

        Me.Text = ""

        If objOItem_Ref.Type = objLocalConfig.Globals.Type_Object Then
            Dim objOItem_Class = objDataWork_Menu.GetOItem(objOItem_Ref.GUID_Parent, objLocalConfig.Globals.Type_Class)

            If Not objOItem_Class Is Nothing Then
                Me.Text = objOItem_Class.Name & " / "
            End If

        End If

        Me.Text = Me.Text & objOItem_Ref.Name

        FillDataGrid()
    End Sub

    Private Sub FillDataGrid()
        objDataWork_Menu.GetData_References(objOItem_Ref)

        DataGridView_FileSystemItems.DataSource = New SortableBindingList(Of clsRelatedFileSystemObject)(objDataWork_Menu.FileRelationList)

        For Each col As DataGridViewColumn In DataGridView_FileSystemItems.Columns
            If col.Name = "Name_FileSystemObject" Or _
                col.Name = "Name_Parent_FileSystemObject" Or _
                col.Name = "OrderID" Or _
                col.Name = "Name_RelationType" Or _
                col.Name = "Path_FileSystemObject" Or _
                col.Name = "IsBlob" Then

                col.Visible = True
            Else
                col.Visible = False
            End If
        Next
    End Sub

    Private Sub ContextMenuStrip_FileSystemObjects_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_FileSystemObjects.Opening
        DownloadToolStripMenuItem.Enabled = False
        StartToolStripMenuItem.Enabled = False

        If DataGridView_FileSystemItems.SelectedRows.Count > 0 Then
            Dim rows = DataGridView_FileSystemItems.SelectedRows.Cast(Of DataGridViewRow).Select(Function(fso) CType(fso.DataBoundItem, clsRelatedFileSystemObject)).ToList()

            If rows.Count > 0 And rows.All(Function(fso) fso.ID_Parent_FileSystemObject = objLocalConfig.OItem_Type_File.GUID) Then
                DownloadToolStripMenuItem.Enabled = True
                StartToolStripMenuItem.Enabled = True
            End If
        End If
    End Sub

    Private Sub DownloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadToolStripMenuItem.Click
        Dim intToDo As Integer
        Dim intDone As Integer
        If DataGridView_FileSystemItems.SelectedRows.Count > 0 Then
            Dim rows = DataGridView_FileSystemItems.SelectedRows.Cast(Of DataGridViewRow).Select(Function(fso) CType(fso.DataBoundItem, clsRelatedFileSystemObject)).ToList()

            If rows.Count > 0 And rows.All(Function(fso) fso.ID_Parent_FileSystemObject = objLocalConfig.OItem_Type_File.GUID) Then
                If FolderBrowserDialog_Download.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    intToDo = rows.Count

                    Dim strPath = FolderBrowserDialog_Download.SelectedPath

                    For Each file In rows
                        Dim strExtension = IO.Path.GetExtension(file.Name_FileSystemObject)
                        Dim strFileWithoutExtension = file.Name_FileSystemObject.Substring(0, file.Name_FileSystemObject.Length - strExtension.Length)

                        Dim strPathDest = strPath & IO.Path.DirectorySeparatorChar & file.Name_FileSystemObject

                        Dim intNameOffset = 1
                        While IO.File.Exists(strPathDest)
                            strPathDest = strPath & IO.Path.DirectorySeparatorChar & strFileWithoutExtension & intNameOffset & strExtension
                            intNameOffset = intNameOffset + 1
                        End While

                        If file.IsBlob Then
                            Dim objOItem_File = New clsOntologyItem With {.GUID = file.ID_FileSystemObject,
                                                                          .Name = file.Name_FileSystemObject,
                                                                          .GUID_Parent = file.ID_Parent_FileSystemObject,
                                                                          .Type = objLocalConfig.Globals.Type_Object}
                            Dim objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_File, strPathDest, True)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                intDone = intDone + 1
                            End If
                        Else
                            Try
                                If Not strPath.ToLower() = strPathDest.ToLower() Then
                                    IO.File.Copy(strPath, strPathDest, True)
                                End If

                                intDone = intDone + 1

                            Catch ex As Exception

                            End Try
                        End If
                    Next
                End If
            End If
        End If

        If intDone = intToDo Then
            MsgBox("Alle Dateien wurden gespeichert!", MsgBoxStyle.Information)
        Else
            MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Dateien gespeichert werden!", MsgBoxStyle.Exclamation)
        End If
    End Sub

   
End Class