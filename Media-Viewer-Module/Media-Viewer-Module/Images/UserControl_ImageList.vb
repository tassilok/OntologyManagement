Imports Ontology_Module
Imports Filesystem_Module
Imports OntologyClasses.BaseClasses
Imports System.Drawing.Drawing2D
Imports PdfSharp.Drawing

Public Class UserControl_ImageList
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_Images As clsDataWork_Images
    Private dtblT_Images As New DataSet_Images.dtbl_ImagesDataTable
    Private objFileWork As clsFileWork

    Private pdfDocument As PdfSharp.Pdf.PdfDocument

    Private objTransaction_Image As clsTransaction_Image
    Private objTransaction_Images As clsTransaction
    Private objBlobConnection As clsBlobConnection

    Private objDlg_Attribute_Long As dlg_Attribute_Long

    Private objFrmSaveFiles As frmSaveFiles
    Private objFrm_FileSystemManagement As frm_FilesystemModule
    Private objFileBlobSync As clsFileBlobSync

    Private objFrmListEdit As frmMediaModule_ListEdit

    'Private objUserControl_ImageViewer As UserControl_ImageViewer

    Public Property objOItem_Relate As clsOntologyItem

    Public objRelationConfig As clsRelationConfig

    Private objOItem_Ref As clsOntologyItem
    Private boolSelect_First As Boolean

    Public Event selected_Image(ByVal OItem_Image As clsOntologyItem, ByVal OItem_File As clsOntologyItem, ByVal dateCreated As Date)
    Public Event related_Last(OItem_Image As clsOntologyItem)

    Private intYear As Integer
    Private intMonth As Integer
    Private intDay As Integer

    Private saveItems As Boolean

    Private objImage As Bitmap

    Public Property ExportOption As ExportOptions

    Public Function Media_First() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objDGVR_Selected As DataGridViewRow

        BindingSource_Images.Position = 0
        DataGridView_Images.ClearSelection()
        objDGVR_Selected = DataGridView_Images.Rows(BindingSource_Images.Position)
        objDGVR_Selected.Selected = True

        objOItem_Result = objLocalConfig.Globals.LState_Success

        Return objOItem_Result
    End Function

    Public Function Media_Previous() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objDGVR_Selected As DataGridViewRow

        If BindingSource_Images.Position > 0 Then
            BindingSource_Images.Position = BindingSource_Images.Position - 1
            DataGridView_Images.ClearSelection()
            objDGVR_Selected = DataGridView_Images.Rows(BindingSource_Images.Position)
            objDGVR_Selected.Selected = True
            objOItem_Result = objLocalConfig.Globals.LState_Success
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If



        Return objOItem_Result
    End Function

    Public Function Media_Next() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objDGVR_Selected As DataGridViewRow

        If BindingSource_Images.Position < BindingSource_Images.Count - 1 Then
            BindingSource_Images.Position = BindingSource_Images.Position + 1
            DataGridView_Images.ClearSelection()
            objDGVR_Selected = DataGridView_Images.Rows(BindingSource_Images.Position)
            objDGVR_Selected.Selected = True
            objOItem_Result = objLocalConfig.Globals.LState_Success
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If



        Return objOItem_Result
    End Function

    Public Function Media_Last() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objDGVR_Selected As DataGridViewRow

        If Not BindingSource_Images.Position = BindingSource_Images.Count - 1 Then
            BindingSource_Images.Position = BindingSource_Images.Count - 1
            DataGridView_Images.ClearSelection()
            objDGVR_Selected = DataGridView_Images.Rows(BindingSource_Images.Position)
            objDGVR_Selected.Selected = True
            objOItem_Result = objLocalConfig.Globals.LState_Success
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If



        Return objOItem_Result
    End Function


    Public ReadOnly Property isPossible_Previous As Boolean
        Get
            If BindingSource_Images.Position > 0 Then
                Return True
            Else
                Return False

            End If
        End Get
    End Property

    Public ReadOnly Property isPossible_Next As Boolean
        Get
            If BindingSource_Images.Position < BindingSource_Images.Count Then
                Return True
            Else
                Return False

            End If
        End Get
    End Property


    Private Sub initialize()
        'objUserControl_ImageViewer = New UserControl_ImageViewer(objLocalConfig)
        'objUserControl_ImageViewer.Dock = DockStyle.Fill
        'SplitContainer1.Panel2.Controls.Add(objUserControl_ImageViewer)
        objTransaction_Image = New clsTransaction_Image(objLocalConfig)
        objBlobConnection = New clsBlobConnection(objLocalConfig.Globals)
        objFileWork = New clsFileWork(objLocalConfig.Globals)
        objFileBlobSync = New clsFileBlobSync(objLocalConfig.Globals, objLocalConfig.OItem_User)
        objTransaction_Images = New clsTransaction(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
    End Sub

    Public Sub clear_List()
        dtblT_Images.Clear()

        DataGridView_Images.DataSource = Nothing
        BindingSource_Images.DataSource = Nothing

        ToolStripButton_Meta.Enabled = False
        ToolStripButton_Open.Enabled = False
        ToolStripButton_Relate.Enabled = False
        ToolStripButton_Remove.Enabled = False
    End Sub

    Public Sub initialize_Images(ByVal OItem_Ref As clsOntologyItem, Optional ByVal select_First As Boolean = False)
        clear_List()
        objOItem_Ref = OItem_Ref

        saveItems = False
        intYear = 0
        intMonth = 0
        intDay = 0
        If Not BindingSource_Images Is Nothing Then
            BindingSource_Images.RemoveFilter()
        End If
        boolSelect_First = select_First
        If Not objOItem_Ref Is Nothing Then
            Timer_Images.Stop()
            objDataWork_Images.get_Images(objOItem_Ref)

            Timer_Images.Start()
        End If
    End Sub

    Public Sub initialize_Images(intYear As Integer, intMonth As Integer, intDay As Integer, Optional select_First As Boolean = False, Optional saveItems As Boolean = False)
        clear_List()
        Me.intYear = intYear
        Me.intMonth = intMonth
        Me.intDay = intDay

        Me.saveItems = saveItems

        Timer_Filter.Stop()
        Timer_Filter.Start()

    End Sub

    Public Sub initialize_AllImages(Optional ByVal select_First As Boolean = False)
        clear_List()

        boolSelect_First = select_First
        objOItem_Ref = Nothing
        Timer_Images.Stop()
        objDataWork_Images.get_Images(objOItem_Ref)

        Timer_Images.Start()

    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        set_DBConnection()
        initialize()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        set_DBConnection()
        initialize()
    End Sub

    Private Sub set_DBConnection()
        objDataWork_Images = New clsDataWork_Images(objLocalConfig)
        objFileWork = New clsFileWork(objLocalConfig.Globals)
    End Sub

    Private Sub Timer_Images_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Images.Tick
        Dim objDGVR_Selected As DataGridViewRow

        If objDataWork_Images.Loaded = True Then
            Timer_Images.Stop()
            ToolStripProgressBar_Images.Value = 0
            dtblT_Images = objDataWork_Images.dtbl_Images
            BindingSource_Images.DataSource = dtblT_Images
            DataGridView_Images.DataSource = BindingSource_Images
            DataGridView_Images.Columns(1).Visible = False
            DataGridView_Images.Columns(4).Visible = False
            DataGridView_Images.Columns(5).Visible = False

            If boolSelect_First = True Then
                If DataGridView_Images.Rows.Count > 0 Then
                    objDGVR_Selected = DataGridView_Images.Rows(0)
                    objDGVR_Selected.Selected = True
                End If
            End If

            ToolStripLabel_Count.Text = DataGridView_Images.RowCount
            ToolStripButton_Open.Enabled = True

            If DataGridView_Images.RowCount > 0 Then
                ToolStripButton_Relate.Enabled = True
            End If
        Else

            ToolStripProgressBar_Images.Value = 50
        End If
    End Sub

    Private Sub DataGridView_Images_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView_Images.SelectionChanged
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOItem_File As clsOntologyItem
        Dim objOItem_Image As clsOntologyItem
        Dim dateCreated As Date

        ToolStripButton_Remove.Enabled = False

        If DataGridView_Images.SelectedRows.Count > 0 Then
            ToolStripButton_Remove.Enabled = True
        End If

        If DataGridView_Images.SelectedRows.Count = 1 Then
            objDGVR_Selected = DataGridView_Images.SelectedRows(0)
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            objOItem_Image = New clsOntologyItem
            objOItem_Image.GUID = objDRV_Selected.Item("ID_Image")
            objOItem_Image.Name = objDRV_Selected.Item("Name_Image")
            objOItem_Image.GUID_Parent = objLocalConfig.OItem_Type_Images__Graphic_.GUID
            objOItem_Image.Type = objLocalConfig.Globals.Type_Object

            objOItem_File = New clsOntologyItem
            objOItem_File.GUID = objDRV_Selected.Item("ID_File")
            objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
            objOItem_File.Type = objLocalConfig.Globals.Type_Object
            If Not IsDBNull(objDRV_Selected.Item("date_Create")) Then
                dateCreated = objDRV_Selected.Item("Date_Create")
            Else
                dateCreated = Nothing
            End If


            RaiseEvent selected_Image(objOItem_Image, objOItem_File, dateCreated)

            'objUserControl_ImageViewer.initialize_Image(objOItem_Image, objOItem_File, dateCreated)

        End If
    End Sub


    Private Sub ToolStripButton_Open_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Open.Click
        Dim objOItem_File As clsOntologyItem
        Dim objOItem_Image As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim strPath As String
        Dim intToDo As Integer
        Dim intDone As Integer

        If ToolStripButton_Relate.Checked Then
            If DataGridView_Images.SelectedRows.Count = 1 Then

            Else
                MsgBox("Sie können nur jeweils ein Media-Item ersetzen!", MsgBoxStyle.Information)
            End If
        Else
            OpenFileDialog_Images.Multiselect = True
            If OpenFileDialog_Images.ShowDialog(Me) = DialogResult.OK Then
                intToDo = OpenFileDialog_Images.FileNames.Count
                intDone = 0

                For Each strPath In OpenFileDialog_Images.FileNames
                    Try
                        Dim objImage = New Bitmap(strPath)
                        Application.DoEvents()
                        objOItem_File = objBlobConnection.isFilePresent(strPath)
                        If objOItem_File Is Nothing Then
                            objOItem_File = New clsOntologyItem
                            objOItem_File.GUID = objLocalConfig.Globals.NewGUID
                            objOItem_File.Name = IO.Path.GetFileName(strPath)
                            objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
                            objOItem_File.Type = objLocalConfig.Globals.Type_Object

                            objOItem_Result = objTransaction_Images.do_Transaction(objOItem_File)
                        Else
                            objOItem_Result = objLocalConfig.Globals.LState_Success
                        End If


                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objOItem_Result = objBlobConnection.save_File_To_Blob(objOItem_File, strPath)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objOItem_Image = objDataWork_Images.GetImageItemOfFile(objOItem_File, objLocalConfig.OItem_Type_Images__Graphic_)
                                If objOItem_Image Is Nothing Then
                                    objOItem_Image = New clsOntologyItem
                                    objOItem_Image.GUID = objLocalConfig.Globals.NewGUID
                                    objOItem_Image.Name = objOItem_File.Name
                                    objOItem_Image.GUID_Parent = objLocalConfig.OItem_Type_Images__Graphic_.GUID
                                    objOItem_Image.Type = objLocalConfig.Globals.Type_Object

                                    objOItem_Result = objTransaction_Images.do_Transaction(objOItem_Image)
                                Else
                                    objOItem_Result = objLocalConfig.Globals.LState_Success
                                End If

                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    Dim objORel_Image_To_File = objDataWork_Images.Rel_Image_To_File(objOItem_Image, objOItem_File)

                                    objOItem_Result = objTransaction_Images.do_Transaction(objORel_Image_To_File, True)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        objOItem_Image.Level = objDataWork_Images.GetNextOrderIDOFRef(objOItem_Ref)
                                        objOItem_Image.Level = objOItem_Image.Level + 1
                                        Dim objORel_Image_To_Ref = objDataWork_Images.Rel_Image_To_Ref(objOItem_Image, objOItem_Ref, True)

                                        objOItem_Result = objTransaction_Images.do_Transaction(objORel_Image_To_Ref)
                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                            Dim objORel_Image__Taking = objDataWork_Images.Rel_Image__Taking(objOItem_Image, objBlobConnection.FileInfoBlob.LastWriteTime)
                                            objOItem_Result = objTransaction_Images.do_Transaction(objORel_Image__Taking)
                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                intDone = intDone + 1
                                            Else
                                                objTransaction_Images.rollback()
                                            End If

                                        Else
                                            objTransaction_Images.rollback()
                                        End If
                                    End If
                                Else
                                    objTransaction_Images.rollback()

                                End If
                            Else
                                objTransaction_Images.rollback()

                            End If
                        End If
                    Catch ex As Exception

                    End Try



                Next

                If intDone < intToDo Then
                    MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Dateien gespeichert werden!", MsgBoxStyle.Exclamation)
                End If

                initialize_Images(objOItem_Ref)
            End If
        End If
    End Sub

    Private Sub ToolStripButton_Paste_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Paste.Click
        Dim objOItem_Result = SaveImageFromClipboardToTemp()
        Dim objOItem_Image As clsOntologyItem

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objOItem_File = GetFile(objOItem_Result.Additional1)
            If objOItem_File.GUID = objLocalConfig.Globals.LState_Relation.GUID Then
                MsgBox("Bitte markieren Sie nur ein Bild!", MsgBoxStyle.Information)
            ElseIf objOItem_File.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Das Bild konnte nicht gespeichert werden!", MsgBoxStyle.Exclamation)
            Else
                objOItem_Result = objBlobConnection.save_File_To_Blob(objOItem_File, objOItem_Result.Additional1)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Image = GetImage(objOItem_File.Name)
                    If objOItem_Image.GUID = objLocalConfig.Globals.LState_Relation.GUID Then
                        If objOItem_File.New_Item Then
                            objFileWork.del_File(objOItem_File)

                        End If
                        MsgBox("Bitte markieren Sie nur ein Bild!", MsgBoxStyle.Information)
                    ElseIf objOItem_Image.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        If objOItem_File.New_Item Then
                            objFileWork.del_File(objOItem_File)

                        End If
                        MsgBox("Das Bild konnte nicht gespeichert werden!", MsgBoxStyle.Exclamation)
                    Else
                        objOItem_Result = objTransaction_Image.SaveImageToFile(objOItem_Image, objOItem_File, True)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objOItem_Result = objTransaction_Image.SaveImageToRef(objOItem_Image, objOItem_Ref, objOItem_Image.Level, True)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then

                                If objOItem_Image.New_Item Then
                                    objOItem_Result = objTransaction_Image.DelImageToFile(objOItem_Image, True)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        objTransaction_Image.DelImage(objOItem_Image)
                                    End If


                                End If
                                If objOItem_File.New_Item Then
                                    objFileWork.del_File(objOItem_File)

                                End If
                            End If
                        Else
                            If objOItem_Image.New_Item Then
                                objTransaction_Image.DelImage(objOItem_Image)
                            End If
                            If objOItem_File.New_Item Then
                                objFileWork.del_File(objOItem_File)

                            End If
                            MsgBox("Das Bild konnte nicht gespeichert werden!", MsgBoxStyle.Exclamation)
                        End If
                    End If
                Else
                    If objOItem_File.New_Item Then
                        objFileWork.del_File(objOItem_File)

                    End If
                End If

                objOItem_Result = objTransaction_Image.SaveImageToRef(objOItem_Image, objOItem_Ref, objOItem_Image.Level, True)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                    initialize_Images(objOItem_Ref)
                Else

                End If

            End If
        ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Relation.GUID Then

            MsgBox("Die Zwischenablage enthält keine Bilder!", MsgBoxStyle.Information)
        Else
            MsgBox("Beim Speichern des Bildes ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)

        End If
    End Sub

    Private Function GetImage(Optional NameNewImage As String = Nothing) As clsOntologyItem
        Dim objOItem_Image As clsOntologyItem


        If ToolStripButton_Paste.Checked Then
            If DataGridView_Images.SelectedRows.Count = 1 Then
                Dim objDGVR_Selected = DataGridView_Images.SelectedRows(0)
                Dim objDRV_Selected As DataRowView = objDGVR_Selected.DataBoundItem

                objOItem_Image = New clsOntologyItem() With {.GUID = objDRV_Selected.Item("ID_Image"), _
                                                             .Name = objDRV_Selected.Item("Name_Image"), _
                                                             .GUID_Parent = objLocalConfig.OItem_Type_Images__Graphic_.GUID, _
                                                             .Level = objDRV_Selected.Item("OrderID"), _
                                                             .Type = objLocalConfig.Globals.Type_Object}




            Else
                objOItem_Image = objLocalConfig.Globals.LState_Relation
            End If
        Else
            Dim lngOrderID As Long

            lngOrderID = objDataWork_Images.GetNextOrderIDOFRef(objOItem_Ref)
            lngOrderID = lngOrderID + 1

            objOItem_Image = New clsOntologyItem()
            objOItem_Image.GUID = objLocalConfig.Globals.NewGUID
            If Not NameNewImage Is Nothing Then
                objOItem_Image.Name = IO.Path.GetFileName(NameNewImage)
            Else
                objOItem_Image.Name = objOItem_Ref.Name & "." & objLocalConfig.OItem_Token_Extensions_Image.Name
            End If
            objOItem_Image.GUID_Parent = objLocalConfig.OItem_Type_Images__Graphic_.GUID
            objOItem_Image.Type = objLocalConfig.Globals.Type_Object
            objOItem_Image.Level = lngOrderID
            objOItem_Image.New_Item = True

            Dim objOItem_Result = objTransaction_Image.SaveImage(objOItem_Image, True)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                objOItem_Image = objLocalConfig.Globals.LState_Error
            End If



        End If

        Return objOItem_Image
    End Function

    Private Function GetFile(Optional strPath As String = Nothing) As clsOntologyItem
        Dim objOItem_File As clsOntologyItem


        If ToolStripButton_Paste.Checked Then
            If DataGridView_Images.SelectedRows.Count = 1 Then
                Dim objDGVR_Selected = DataGridView_Images.SelectedRows(0)
                Dim objDRV_Selected As DataRowView = objDGVR_Selected.DataBoundItem

                objOItem_File = New clsOntologyItem() With {.GUID = objDRV_Selected.Item("ID_File"), _
                                                             .Name = objDRV_Selected.Item("Name_File"), _
                                                             .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                             .Type = objLocalConfig.Globals.Type_Object}




            Else
                objOItem_File = objLocalConfig.Globals.LState_Relation
            End If
        Else

            objOItem_File = New clsOntologyItem()
            objOItem_File.GUID = objLocalConfig.Globals.NewGUID
            If Not strPath Is Nothing Then
                objOItem_File.Name = IO.Path.GetFileName(strPath)
            Else
                objOItem_File.Name = objOItem_Ref.Name & "." & objLocalConfig.OItem_Token_Extensions_Image.Name
            End If
            objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
            objOItem_File.Type = objLocalConfig.Globals.Type_Object
            objOItem_File.New_Item = True

            Dim objOItem_Result = objFileWork.save_File(objOItem_File)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                objOItem_File = objLocalConfig.Globals.LState_Error
            End If



        End If

        Return objOItem_File
    End Function

    Private Function SaveImageFromClipboardToTemp() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objImage As Bitmap
        Dim strPath As String

        objOItem_Result = New clsOntologyItem() With {.GUID = objLocalConfig.Globals.LState_Success.GUID, _
                                                      .Name = objLocalConfig.Globals.LState_Success.Name, _
                                                      .GUID_Parent = objLocalConfig.Globals.LState_Success.GUID_Parent, _
                                                      .Type = objLocalConfig.Globals.Type_Object}
        If Clipboard.ContainsImage Then
            objImage = Clipboard.GetData(System.Windows.Forms.DataFormats.Bitmap)
            strPath = Environment.ExpandEnvironmentVariables("%temp%")

            strPath = objFileWork.merge_paths(strPath, objLocalConfig.Globals.NewGUID & "." & objLocalConfig.OItem_Token_Extensions_Image.Name)
            Try
                objImage.Save(strPath)

                objOItem_Result.Additional1 = strPath
            Catch ex As Exception
                objOItem_Result = objLocalConfig.Globals.LState_Error
            End Try

        Else
            objOItem_Result = objLocalConfig.Globals.LState_Relation
        End If

        Return objOItem_Result
    End Function

    Private Sub ContextMenuStrip_Relate_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Relate.Opening
        RelateToolStripMenuItem.Enabled = False
        SaveImagesToolStripMenuItem.Enabled = False
        NameToolStripMenuItem.Enabled = False
        DateTimeStampToolStripMenuItem.Enabled = False
        PrintImagesToolStripMenuItem.Enabled = False
        CreatePDFToolStripMenuItem.Enabled = False
        ChangeOrderIDToolStripMenuItem.Enabled = False
        AddToSyncToolStripMenuItem.Enabled = False

        If DataGridView_Images.SelectedRows.Count > 0 Then
            RelateToolStripMenuItem.Enabled = True
            SaveImagesToolStripMenuItem.Enabled = True
            NameToolStripMenuItem.Enabled = True
            DateTimeStampToolStripMenuItem.Enabled = True
            PrintImagesToolStripMenuItem.Enabled = True
            CreatePDFToolStripMenuItem.Enabled = True
            ChangeOrderIDToolStripMenuItem.Enabled = True
            AddToSyncToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub SaveImagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveImagesToolStripMenuItem.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim intToDo As Integer
        Dim intDone As Integer
        Dim intExist As Integer
        Dim dateCreated As DateTime

        If FolderBrowserDialog_Save.ShowDialog = DialogResult.OK Then
            intToDo = DataGridView_Images.SelectedRows.Count
            intDone = 0
            intExist = 0
            For Each objDGVR_Selected In DataGridView_Images.SelectedRows
                objDRV_Selected = objDGVR_Selected.DataBoundItem
                dateCreated = If(IsDBNull(objDRV_Selected.Item("Date_Create")), Now, objDRV_Selected.Item("Date_Create"))
                Dim objOItem_File = New clsOntologyItem With {.GUID = objDRV_Selected.Item("ID_File"), _
                                                              .Name = objDRV_Selected.Item("Name_Image"), _
                                                              .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                              .Type = objLocalConfig.Globals.Type_Object}
                Dim strExtension = IO.Path.GetExtension(objOItem_File.Name)
                Dim strFileName = objOItem_File.Name.Substring(0, objOItem_File.Name.Length - strExtension.Length)

                Dim strPath_Dst = FolderBrowserDialog_Save.SelectedPath & IO.Path.DirectorySeparatorChar + If(DateTimeStampToolStripMenuItem.Checked, dateCreated.ToString("yyyyMMdd_hhmmss"), strFileName) & strExtension
                Dim intPostfix As Integer = 1
                While (IO.File.Exists(strPath_Dst))
                    strPath_Dst = FolderBrowserDialog_Save.SelectedPath & IO.Path.DirectorySeparatorChar + If(DateTimeStampToolStripMenuItem.Checked, dateCreated.ToString("yyyyMMdd_hhmmss"), strFileName) & intPostfix & strExtension
                    intPostfix = intPostfix + 1
                End While

                If Not IO.File.Exists(strPath_Dst) Then
                    If objFileWork.is_File_Blob(objOItem_File) Then
                        Dim objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_File, strPath_Dst, False)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            intDone = intDone + 1
                        ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Relation.GUID Then
                            intExist = intExist + 1
                        End If
                    Else
                        Dim strPath_Src = objFileWork.get_Path_FileSystemObject(objOItem_File, False)
                        If IO.File.Exists(strPath_Src) Then
                            Try
                                IO.File.Copy(strPath_Src, strPath_Dst)
                                intDone = intDone + 1
                            Catch ex As Exception

                            End Try

                        End If
                    End If
                Else
                    intExist = intExist + 1
                End If

            Next

            If intToDo > intDone Then
                MsgBox("Es konnten nur " & intDone & " Dateien gespeichert werden. " & intExist & " Dateien existierten bereits.", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub RelateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RelateToolStripMenuItem.Click
        If DataGridView_Images.SelectedRows.Count > 0 Then
            Dim objOItem_Image As clsOntologyItem = Nothing
            Dim intToDo = DataGridView_Images.SelectedRows.Count
            Dim intDone = 0

            objTransaction_Images.ClearItems()
            For Each objDGVR As DataGridViewRow In DataGridView_Images.SelectedRows
                Dim objDRV As DataRowView = objDGVR.DataBoundItem

                objOItem_Image = New clsOntologyItem With {.GUID = objDRV.Item("ID_Image"), _
                                                                   .Name = objDRV.Item("Name_Image"), _
                                                                   .GUID_Parent = objLocalConfig.OItem_Type_Images__Graphic_.GUID, _
                                                                   .Type = objLocalConfig.Globals.Type_Object}

                Dim objOR_Image_To_Ref = objDataWork_Images.Rel_Image_To_Ref(objOItem_Image, objOItem_Relate)

                Dim objOItem_Result = objTransaction_Images.do_Transaction(objOR_Image_To_Ref, True)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    intDone = intDone + 1
                End If
            Next

            If intDone < intToDo Then
                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Images verknüpft werden!", MsgBoxStyle.Exclamation)
            End If

            RaiseEvent related_Last(objOItem_Image)
        End If
    End Sub

    Private Sub NameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NameToolStripMenuItem.Click
        If NameToolStripMenuItem.Checked Then
            DateTimeStampToolStripMenuItem.Checked = True
            NameToolStripMenuItem.Checked = False
        Else
            DateTimeStampToolStripMenuItem.Checked = False
            NameToolStripMenuItem.Checked = True

        End If
    End Sub

    Private Sub DateTimeStampToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DateTimeStampToolStripMenuItem.Click
        If DateTimeStampToolStripMenuItem.Checked Then
            DateTimeStampToolStripMenuItem.Checked = False
            NameToolStripMenuItem.Checked = True
        Else
            DateTimeStampToolStripMenuItem.Checked = True
            NameToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub Timer_Filter_Tick(sender As Object, e As EventArgs) Handles Timer_Filter.Tick
        If objDataWork_Images.Loaded = True Then
            Timer_Filter.Stop()

            Dim strDateStart = intYear.ToString
            Dim strDateEnd = intYear.ToString
            If intMonth > 0 Then
                strDateStart = intMonth & "." & strDateStart
                strDateEnd = intMonth & "." & strDateEnd
                If intDay > 0 Then
                    strDateStart = intDay & "." & strDateStart
                    Dim dateTest = Date.Parse(strDateStart)
                    strDateStart = dateTest.ToString()
                    dateTest.AddDays(1)
                    strDateEnd = dateTest.ToString

                Else
                    strDateStart = "1." & strDateStart
                    Dim dateTest = Date.Parse(strDateStart)
                    strDateStart = dateTest.ToString()
                    dateTest = dateTest.AddMonths(1).AddDays(-1)
                    strDateEnd = dateTest.ToString
                End If
            Else
                strDateStart = "1.1." & strDateStart
                Dim dateTest = Date.Parse(strDateStart)
                strDateStart = dateTest.ToString()
                dateTest = dateTest.AddYears(1)
                dateTest = dateTest.AddDays(-1)
                strDateEnd = dateTest.ToString
            End If


            dtblT_Images = objDataWork_Images.dtbl_Images
            BindingSource_Images.DataSource = dtblT_Images
            DataGridView_Images.DataSource = BindingSource_Images
            DataGridView_Images.Columns(1).Visible = False
            DataGridView_Images.Columns(4).Visible = False
            DataGridView_Images.Columns(5).Visible = False
            BindingSource_Images.Filter = "Date_Create >= '" & strDateStart & "' AND Date_Create <= '" & strDateEnd & "'"


        End If
    End Sub

    Public Sub Save_Items(boolChrono As Boolean)
        Dim objFileList As New List(Of clsOntologyItem)

        If boolChrono Then
            If FolderBrowserDialog_Save.ShowDialog(Me) = DialogResult.OK Then
                Dim intToDo As Integer
                Dim intDone As Integer

                intDone = 0
                intToDo = DataGridView_Images.RowCount

                For Each objDGVR As DataGridViewRow In DataGridView_Images.Rows
                    Dim objDRV As DataRowView = objDGVR.DataBoundItem
                    If Not IsDBNull(objDRV.Item("Date_Create")) Then
                        Dim dateCreate As DateTime = objDRV.Item("Date_Create")
                        Dim intYear = dateCreate.Year
                        Dim intMonth = dateCreate.Month
                        Dim intDay = dateCreate.Day


                        Dim strFileName = objDRV.Item("Name_File")
                        Dim strExtension = IO.Path.GetExtension(strFileName)
                        strFileName = objDRV.Item("ID_Image") & strExtension

                        Dim strPath = FolderBrowserDialog_Save.SelectedPath

                        strPath = strPath & IO.Path.DirectorySeparatorChar & intYear.ToString & IO.Path.DirectorySeparatorChar & intMonth.ToString("00")

                        If Not strPath = "" Then
                            strPath = strPath & IO.Path.DirectorySeparatorChar & strFileName
                            objFileList.Add(New clsOntologyItem With {.GUID = objDRV.Item("ID_File"),
                                                                        .Name = objDRV.Item("Name_File"),
                                                                        .GUID_Parent = objLocalConfig.OItem_Type_File.GUID,
                                                                        .Additional1 = strPath,
                                                                        .Type = objLocalConfig.Globals.Type_Object})
                        End If



                    End If

                Next

                If objFileList.Any Then
                    objFrmSaveFiles = New frmSaveFiles(objLocalConfig.Globals, objFileList)
                    objFrmSaveFiles.ShowDialog(Me)

                Else
                    MsgBox("Die Dateien konnten nicht ermittelt werden!", MsgBoxStyle.Exclamation)
                End If
            End If
        End If
    End Sub

    Private Sub PrintImagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintImagesToolStripMenuItem.Click

        If PrintDialog_Selection.ShowDialog(Me) = DialogResult.OK Then
            PrintDocument_Image.PrinterSettings = PrintDialog_Selection.PrinterSettings
            For Each objDGVR As DataGridViewRow In DataGridView_Images.SelectedRows
                Dim objDRV As DataRowView = objDGVR.DataBoundItem
                Dim objOItem_File As clsOntologyItem = New clsOntologyItem With {.GUID = objDRV.Item("ID_File"), _
                                                                                 .Name = objDRV.Item("Name_File"), _
                                                                                 .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                                                .Type = objLocalConfig.Globals.Type_Object}

                Dim strPath = "%TEMP%\" & objLocalConfig.Globals.NewGUID & IO.Path.GetExtension(objOItem_File.Name)

                strPath = Environment.ExpandEnvironmentVariables(strPath)

                Dim objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_File, strPath)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objImage = New System.Drawing.Bitmap(strPath)
                    PrintDocument_Image.Print()
                    objImage = Nothing
                Else
                    MsgBox("Die Images konnten nicht gedruckt werden!", MsgBoxStyle.Exclamation)
                End If

            Next
        End If

    End Sub

    Private Sub PrintDocument_Image_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument_Image.PrintPage
        Dim objImageZoom = ResizeImage(objImage, New System.Drawing.Size(e.MarginBounds.Width, e.MarginBounds.Height))


        e.Graphics.DrawImage(objImageZoom, e.MarginBounds.Left, e.MarginBounds.Top)
    End Sub

    Public Shared Function ResizeImage(ByVal image As Image, _
        ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth,
                    percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If
        Dim newImage As Image = New Bitmap(newWidth, newHeight)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function

    Private Sub CreatePDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreatePDFToolStripMenuItem.Click
        pdfDocument = New PdfSharp.Pdf.PdfDocument
        If SaveFileDialog_PDF.ShowDialog(Me) = DialogResult.OK Then
            Dim strPath_PDF = SaveFileDialog_PDF.FileName
            For Each objDGVR As DataGridViewRow In DataGridView_Images.SelectedRows.OfType(Of DataGridViewRow).OrderBy(Function(p) p.Index).ToList()
                Dim objDRV As DataRowView = objDGVR.DataBoundItem
                Dim objOItem_File As clsOntologyItem = New clsOntologyItem With {.GUID = objDRV.Item("ID_File"), _
                                                                                 .Name = objDRV.Item("Name_File"), _
                                                                                 .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                                                .Type = objLocalConfig.Globals.Type_Object}

                Dim strPath = "%TEMP%\" & objLocalConfig.Globals.NewGUID & IO.Path.GetExtension(objOItem_File.Name)

                strPath = Environment.ExpandEnvironmentVariables(strPath)

                Dim objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_File, strPath)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Application.DoEvents()
                    objImage = New System.Drawing.Bitmap(strPath)
                    Dim page As PdfSharp.Pdf.PdfPage = pdfDocument.AddPage
                    Dim graphics As XGraphics = XGraphics.FromPdfPage(page)
                    Dim objImageZoom = ResizeImage(objImage, New System.Drawing.Size(page.Width, page.Height))
                    graphics.DrawImage(objImageZoom, 0, 0)

                    objImage = Nothing
                Else
                    pdfDocument = Nothing
                    MsgBox("Die Images konnten nicht gedruckt werden!", MsgBoxStyle.Exclamation)
                End If

            Next

            If Not pdfDocument Is Nothing Then
                pdfDocument.Save(strPath_PDF)
                MsgBox("Das Pdf-Dokument wurde gespeichert!", MsgBoxStyle.Information)
            End If
        End If
        
    End Sub

    Private Sub IncreasingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IncreasingToolStripMenuItem.Click
        ChangeOrderID(True)
    End Sub

    Private Sub ChangeOrderID(boolIncrease As Boolean)
        If MsgBox("Wollen Sie wirklich die Order-ID ändern?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            objDlg_Attribute_Long = New dlg_Attribute_Long("Order-ID (start)", objLocalConfig.Globals)
            objDlg_Attribute_Long.ShowDialog(Me)
            If objDlg_Attribute_Long.DialogResult = DialogResult.OK Then
                Dim lngOrderIDStart = objDlg_Attribute_Long.Value
                For Each objDGVR As DataGridViewRow In DataGridView_Images.SelectedRows.OfType(Of DataGridViewRow).OrderBy(Function(p) p.Index).ToList()
                    Dim objDRV As DataRowView = objDGVR.DataBoundItem

                    objTransaction_Images.ClearItems()
                    Dim objOItem_MediaItem = New clsOntologyItem With {.GUID = objDRV.Item("ID_Image"), _
                                                                        .Name = objDRV.Item("Name_Image"), _
                                                                        .GUID_Parent = objLocalConfig.OItem_Type_Images__Graphic_.GUID, _
                                                                        .Type = objLocalConfig.Globals.Type_Object}

                    Dim objRelA_OrderID = objRelationConfig.Rel_ObjectRelation(objOItem_MediaItem, objOItem_Ref, objLocalConfig.OItem_RelationType_belongsTo, False, lngOrderIDStart)

                    Dim objOItem_Result = objTransaction_Images.do_Transaction(objRelA_OrderID)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        MsgBox("Die OrderID konnte nicht geändert werden!", MsgBoxStyle.Exclamation)
                        Exit For
                    End If
                    lngOrderIDStart = lngOrderIDStart + If(boolIncrease, 1, -1)
                Next

                initialize_Images(objOItem_Ref)
            End If


        End If
        
    End Sub

    Private Sub ToolStripButton_Remove_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Remove.Click
        Dim intDone As Integer
        Dim intToDo As Integer
        Dim intError As Integer

        intToDo = DataGridView_Images.SelectedRows.Count
        intDone = 0
        intError = 0

        If MsgBox("Wollen Sie wirklich " & intToDo & " Images löschen?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            objTransaction_Image.clear_dellists_image()

            For Each objDGVR_Selected As DataGridViewRow In DataGridView_Images.SelectedRows
                Dim objDRV_Selected As DataRowView = objDGVR_Selected.DataBoundItem

                Dim objOItem_Image = New clsOntologyItem With {.GUID = objDRV_Selected.Item("ID_Image"), _
                                                               .Name = objDRV_Selected.Item("Name_Image"), _
                                                               .GUID_Parent = objLocalConfig.OItem_Type_Images__Graphic_.GUID, _
                                                               .Type = objLocalConfig.Globals.Type_Object}

                Dim objOItem_File = New clsOntologyItem With {.GUID = objDRV_Selected.Item("ID_File"), _
                                                              .Name = objDRV_Selected.Item("Name_File"), _
                                                              .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                              .Type = objLocalConfig.Globals.Type_Object}

                Dim objOItem_Result = objDataWork_Images.HasCriticalRelations(objOItem_Image, objOItem_File)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Result = objBlobConnection.del_Blob(objOItem_File)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objTransaction_Image.add_image_to_dellist(objOItem_Image, objOItem_File)
                    End If

                ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    intError = intError + 1
                End If
            Next

            If objTransaction_Image.olist_del_fileatts.Any And _
                objTransaction_Image.olist_del_files.Any And _
                objTransaction_Image.olist_del_imageatts.Any And _
                objTransaction_Image.olist_del_imagerels.Any And _
                objTransaction_Image.olist_del_images.Any Then

                Dim objOItem_Result = objTransaction_Image.del_ImageList()
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    MsgBox("Leider konnten nicht alle Elemente gelöscht werden!", MsgBoxStyle.Exclamation)

                End If
            End If
            initialize_Images(objOItem_Ref)
        End If
        
    End Sub

    Private Sub AddToSyncToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToSyncToolStripMenuItem.Click
        Dim intToDo = 0
        Dim intDone = 0

        If MsgBox("Wollen Sie wirklich die Dateien für den Sync anmelden?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            objFrm_FileSystemManagement = New frm_FilesystemModule(objLocalConfig.Globals, objLocalConfig.OItem_User)

            objFrm_FileSystemManagement.ShowDialog(Me)
            If objFrm_FileSystemManagement.DialogResult = DialogResult.OK Then
                Dim objOItem_Folder = objFrm_FileSystemManagement.OItem_FileSystemObject

                If Not objOItem_Folder Is Nothing Then
                    If objOItem_Folder.GUID_Parent = objFrm_FileSystemManagement.LocalConfig.OItem_type_Folder.GUID Then
                        intToDo = DataGridView_Images.SelectedRows.Count
                        For Each objDGVR_Selected As DataGridViewRow In DataGridView_Images.SelectedRows
                            Dim objDRV_Selected As DataRowView = objDGVR_Selected.DataBoundItem

                            Dim strExtension = IO.Path.GetExtension(objDRV_Selected.Item("Name_File"))
                            Dim strFileNameWithOutExtension = objDRV_Selected.Item("Name_File").Substring(0, objDRV_Selected.Item("Name_File").Length - strExtension.Length)

                            Dim objOItem_File = New clsOntologyItem With {.GUID = objDRV_Selected.Item("ID_File"), _
                                                                          .Name = objDRV_Selected.Item("Name_File"), _
                                                                          .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                                          .Type = objLocalConfig.Globals.Type_Object}
                            Dim strFileName = ""

                            If ExportOption = ExportOptions.guid Then

                                strFileName = objOItem_File.GUID & strExtension

                            ElseIf ExportOption = ExportOptions.name Then


                                strFileName = strFileNameWithOutExtension & strExtension


                            ElseIf ExportOption = ExportOptions.orderid Then

                                strFileName = Format(objDRV_Selected.Item("OrderID"), "00000") & strExtension

                            End If



                            Dim objOItem_Result = objFileBlobSync.AddFileSync(objOItem_File, objOItem_Folder, strFileName, objFileBlobSync.OItem_Direction_BlobToFile)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                intDone = intDone + 1
                            End If
                        Next

                        If intToDo = intDone Then
                            MsgBox("Alle Dateien wurden für den Sync angemeldet.", MsgBoxStyle.Information)
                        Else
                            MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Dateien zum Sync angemeldet werden!", MsgBoxStyle.Exclamation)
                        End If
                    Else
                        MsgBox("Wählen Sie bitte einen Ordner aus!", MsgBoxStyle.Information)
                    End If
                Else
                    MsgBox("Wählen Sie bitte einen Ordner aus!", MsgBoxStyle.Information)
                End If
            End If
        End If
    End Sub

    Private Sub ToolStripButton_Relate_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Relate.Click


        objFrmListEdit = New frmMediaModule_ListEdit(objLocalConfig, objLocalConfig.OItem_Type_Images__Graphic_, objOItem_Ref)
        objFrmListEdit.ShowDialog(Me)

    End Sub
End Class
