Imports Ontology_Module
Imports Filesystem_Module
Imports OntologyClasses.BaseClasses

Public Class UserControl_ImageList
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_Images As clsDataWork_Images
    Private dtblT_Images As New DataSet_Images.dtbl_ImagesDataTable
    Private objFileWork As clsFileWork

    Private objTransaction_Image As clsTransaction_Image
    Private objBlobConnection As clsBlobConnection

    'Private objUserControl_ImageViewer As UserControl_ImageViewer

    Private objOItem_Ref As clsOntologyItem
    Private boolSelect_First As Boolean

    Public Event selected_Image(ByVal OItem_Image As clsOntologyItem, ByVal OItem_File As clsOntologyItem, ByVal dateCreated As Date)

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

        boolSelect_First = select_First
        If Not objOItem_Ref Is Nothing Then
            Timer_Images.Stop()
            objDataWork_Images.get_Images(objOItem_Ref)

            Timer_Images.Start()
        End If
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
End Class
