Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Filesystem_Module

Public Class UserControl_SingleViewer

    Private objLocalConfig As clsLocalConfig

    Private objOItem_MediaType As clsOntologyItem

    Private objDataWork_Images As clsDataWork_Images
    Private objDataWork_MediaItems As clsDataWork_MediaItem
    Private objDataWork_PDFs As clsDataWork_PDF

    Private WithEvents objUserControl_ImageViewer As UserControl_ImageViewer
    Private WithEvents objUserControl_MediaPlayer As UserControl_MediaPlayer
    Private WithEvents objUserControl_PDFViewer As UserControl_PDFViewer

    Public Event Media_First()
    Public Event Media_Previous()
    Public Event Media_Next()
    Public Event Media_Last()

    Private intItemID As Integer
    Private boolNavigation As Boolean

    Private objOItem_Ref As clsOntologyItem
    Private objRelationConfig As clsRelationConfig
    Private objTransaction As clsTransaction
    Private objBlobConnection As clsBlobConnection

    <Flags()> _
    Enum MediaType
        Image = 0
        MediaItem = 1
        PDF = 2

    End Enum

    Private Sub stoppedMedia() Handles objUserControl_MediaPlayer.stopped
        If ToolStripButton_Next.Enabled = True Then
            If ToolStripButton_Playlist.Checked = True Then
                If boolNavigation Then
                    configure_Viewer(1)
                    configure_List()
                Else
                    RaiseEvent Media_Next()
                End If

            End If

        End If
    End Sub

    Public Sub set_Count(lngCurr As Long, lngCount As Long)
        ToolStripTextBox_Curr.Text = lngCurr
        ToolStripLabel_Count.Text = lngCount
    End Sub

    Public ReadOnly Property OItem_MediaType As clsOntologyItem
        Get
            Return objOItem_MediaType
        End Get
    End Property

    Public WriteOnly Property isPossible_Previous As Boolean
        Set(ByVal value As Boolean)
            ToolStripButton_First.Enabled = value
            ToolStripButton_Previous.Enabled = value
        End Set
    End Property

    Public WriteOnly Property isPossible_Next As Boolean
        Set(ByVal value As Boolean)
            ToolStripButton_Last.Enabled = value
            ToolStripButton_Next.Enabled = value
        End Set
    End Property

    Public Sub clear_Media()
        If Not objUserControl_ImageViewer Is Nothing Then
            objUserControl_ImageViewer.clear_Image()
        End If
        If Not objUserControl_MediaPlayer Is Nothing Then
            objUserControl_MediaPlayer.clear_Media()
        End If
        If Not objUserControl_PDFViewer Is Nothing Then
            objUserControl_PDFViewer.clear_PDF()
        End If
    End Sub

    Public Sub initialize_PDF(ByVal OItem_PDF As clsOntologyItem, ByVal OItem_File As clsOntologyItem)
        objOItem_Ref = Nothing
        objUserControl_PDFViewer.initialize_PDF(OItem_PDF, OItem_File)
        ToolStripTextBox_Curr.Text = 0
        ToolStripLabel_Count.Text = 0
        boolNavigation = True
        configure_Controls()
    End Sub

    Public Sub initialize_PDF(ByVal objDR_Media As DataRow)
        Dim objOItem_PDF As clsOntologyItem
        Dim objOItem_File As clsOntologyItem

        objOItem_Ref = Nothing

        objOItem_PDF = New clsOntologyItem
        objOItem_PDF.GUID = objDR_Media.Item("ID_PDFDoc")
        objOItem_PDF.Name = objDR_Media.Item("Name_PDFDoc")
        objOItem_PDF.GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID
        objOItem_PDF.Type = objLocalConfig.Globals.Type_Object

        objOItem_File = New clsOntologyItem
        objOItem_File.GUID = objDR_Media.Item("ID_File")
        objOItem_File.Name = objDR_Media.Item("Name_File")
        objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
        objOItem_File.Type = objLocalConfig.Globals.Type_Object

        objUserControl_PDFViewer.initialize_PDF(objOItem_PDF, objOItem_File)
        ToolStripTextBox_Curr.Text = 0
        ToolStripLabel_Count.Text = 0

        boolNavigation = True
        configure_Controls()
    End Sub

    Public Sub initialize_Image(ByVal OItem_Image As clsOntologyItem, ByVal OItem_File As clsOntologyItem, ByVal dateCreated As Date)
        objOItem_Ref = Nothing
        objUserControl_ImageViewer.initialize_Image(OItem_Image, OItem_File, dateCreated)
        ToolStripTextBox_Curr.Text = 0
        ToolStripLabel_Count.Text = 0
        boolNavigation = False
        configure_Controls()
    End Sub

    Public Sub initialize_Image(ByVal OItem_Ref As clsOntologyItem)
        objDataWork_Images.get_Images(OItem_Ref, False)
        While (Not objDataWork_Images.Loaded)
        End While
        objOItem_Ref = OItem_Ref
        intItemID = 0
        boolNavigation = True
        configure_List()
        configure_Viewer()
        configure_Controls()
    End Sub

    Public Sub initialize_MediaItem(ByVal OItem_Ref As clsOntologyItem)
        objOItem_Ref = OItem_Ref
        objDataWork_MediaItems.get_MediaItems(OItem_Ref, False)
        While (Not objDataWork_MediaItems.Loaded)
        End While

        intItemID = 0
        boolNavigation = True
        configure_List()
        configure_Viewer()
        configure_Controls()
    End Sub

    Public Sub initialize_PDF(ByVal OItem_Ref As clsOntologyItem)
        objOItem_Ref = OItem_Ref
        objDataWork_PDFs.get_PDF(OItem_Ref, False)
        While (Not objDataWork_PDFs.Loaded)
        End While

        intItemID = 0
        boolNavigation = True
        configure_List()
        configure_Viewer()
        configure_Controls()
    End Sub

    Private Sub configure_List()

        ToolStripTextBox_Curr.Text = intItemID + 1
        ToolStripLabel_Count.Text = objDataWork_Images.ItemList.Count

        isPossible_Next = False
        isPossible_Previous = False

        If intItemID > 0 Then
            isPossible_Previous = True
        Else
            isPossible_Previous = False
        End If

        If intItemID < objDataWork_Images.ItemList.Count Then
            isPossible_Next = True
        End If
    End Sub
    Private Sub configure_Controls()
        If Not objOItem_Ref Is Nothing Then
            ToolStrip2.Visible = True
            ToolStrip2.Enabled = True
            ToolStripButton_Add.Enabled = True
            ToolStripButton_Remove.Enabled = True
        Else
            ToolStrip2.Visible = False
            ToolStrip2.Enabled = False
            ToolStripButton_Add.Enabled = False
            ToolStripButton_Remove.Enabled = False
        End If
    End Sub
    Private Sub configure_Viewer(Optional IncrItemID As Integer = 0)

        intItemID = intItemID + IncrItemID
        Dim objItem As clsMultiMediaItem = Nothing

        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                If objDataWork_PDFs.ItemList.Any Then
                    objItem = objDataWork_PDFs.ItemList(intItemID)
                End If

            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                If objDataWork_Images.ItemList.Any() Then
                    objItem = objDataWork_Images.ItemList(intItemID)
                End If

            Case objLocalConfig.OItem_Type_Media_Item.GUID
                If objDataWork_MediaItems.ItemList.Any() Then
                    objItem = objDataWork_MediaItems.ItemList(intItemID)
                End If
        End Select

        If Not objItem Is Nothing Then
            Dim objMediaItem As clsOntologyItem = New clsOntologyItem(objItem.ID_Item, _
                                                                  objItem.Name_Item, _
                                                                  objItem.ID_Parent_Item)
            Dim objFile As clsOntologyItem = New clsOntologyItem(objItem.ID_File, _
                                                                 objItem.Name_File, _
                                                                 objItem.ID_Parent_File)
            Dim dateCreated As DateTime

            If Not objItem.OACreate Is Nothing Then
                dateCreated = objItem.OACreate.Val_Date
            Else
                dateCreated = Nothing
            End If

            Select Case objOItem_MediaType.GUID
                Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                    objUserControl_PDFViewer.initialize_PDF(objMediaItem, objFile)
                Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                    objUserControl_ImageViewer.initialize_Image(objMediaItem, objFile, dateCreated)
                Case objLocalConfig.OItem_Type_Media_Item.GUID

                    objUserControl_MediaPlayer.initialize_MediaItem(objMediaItem, objFile, dateCreated)
            End Select
        End If

    End Sub

    Public Sub initialize_Image(ByVal objDR_Media As DataRow)
        Dim objOItem_Image As clsOntologyItem
        Dim objOItem_File As clsOntologyItem
        Dim dateCreated As Date

        objOItem_Image = New clsOntologyItem
        objOItem_Image.GUID = objDR_Media.Item("ID_Image")
        objOItem_Image.Name = objDR_Media.Item("Name_Image")
        objOItem_Image.GUID_Parent = objLocalConfig.OItem_Type_Images__Graphic_.GUID
        objOItem_Image.Type = objLocalConfig.Globals.Type_Object

        objOItem_File = New clsOntologyItem
        objOItem_File.GUID = objDR_Media.Item("ID_File")
        objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
        objOItem_File.Type = objLocalConfig.Globals.Type_Object
        If Not IsDBNull(objDR_Media.Item("date_Create")) Then
            dateCreated = objDR_Media.Item("Date_Create")
        Else
            dateCreated = Nothing
        End If
        objOItem_Ref = Nothing
        objUserControl_ImageViewer.initialize_Image(objOItem_Image, objOItem_File, dateCreated)
        ToolStripTextBox_Curr.Text = 0
        ToolStripLabel_Count.Text = 0
        boolNavigation = False
        configure_Controls()
    End Sub

    Public Sub initialize_MediaItem(ByVal OItem_MediaItem As clsOntologyItem, ByVal OItem_File As clsOntologyItem, ByVal dateCreated As Date)
        objOItem_Ref = Nothing
        objUserControl_MediaPlayer.initialize_MediaItem(OItem_MediaItem, OItem_File, dateCreated)
        ToolStripTextBox_Curr.Text = 0
        ToolStripLabel_Count.Text = 0
        ToolStripButton_Playlist.Enabled = True
        boolNavigation = False
        configure_Controls()
    End Sub

    Public Sub initialize_MediaItem(ByVal objDR_Media As DataRow)
        Dim objOItem_MediaItem As clsOntologyItem
        Dim objOItem_File As clsOntologyItem
        Dim dateCreated As Date

        objOItem_MediaItem = New clsOntologyItem
        objOItem_MediaItem.GUID = objDR_Media.Item("ID_MediaItem")
        objOItem_MediaItem.Name = objDR_Media.Item("Name_MediaItem")
        objOItem_MediaItem.GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID
        objOItem_MediaItem.Type = objLocalConfig.Globals.Type_Object

        objOItem_File = New clsOntologyItem
        objOItem_File.GUID = objDR_Media.Item("ID_File")
        objOItem_File.Name = objDR_Media.Item("Name_File")
        objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
        objOItem_File.Type = objLocalConfig.Globals.Type_Object
        If Not IsDBNull(objDR_Media.Item("created")) Then
            dateCreated = objDR_Media.Item("created")
        Else
            dateCreated = Nothing
        End If
        objOItem_Ref = Nothing
        objUserControl_MediaPlayer.initialize_MediaItem(objOItem_MediaItem, objOItem_File, dateCreated)
        ToolStripTextBox_Curr.Text = 0
        ToolStripLabel_Count.Text = 0
        ToolStripButton_Playlist.Enabled = True
        boolNavigation = False
        configure_Controls()
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig, ByVal OItem_MediaType As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        objOItem_MediaType = OItem_MediaType
        set_DBConnection()
        initialize()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals, ByVal intMediaType As Integer)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        Select Case intMediaType
            Case MediaType.Image
                objOItem_MediaType = objLocalConfig.OItem_Type_Images__Graphic_
            Case MediaType.MediaItem
                objOItem_MediaType = objLocalConfig.OItem_Type_Media_Item
            Case MediaType.PDF
                objOItem_MediaType = objLocalConfig.OItem_Type_PDF_Documents
        End Select

        set_DBConnection()
        initialize()
    End Sub

    Private Sub set_DBConnection()
        objDataWork_Images = New clsDataWork_Images(objLocalConfig)
        objDataWork_MediaItems = New clsDataWork_MediaItem(objLocalConfig)
        objDataWork_PDFs = New clsDataWork_PDF(objLocalConfig)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objBlobConnection = New clsBlobConnection(objLocalConfig.Globals)
    End Sub

    Private Sub initialize()
        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                objUserControl_PDFViewer = New UserControl_PDFViewer(objLocalConfig)
                objUserControl_PDFViewer.Dock = DockStyle.Fill
                ToolStripContainer1.ContentPanel.Controls.Add(objUserControl_PDFViewer)
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                objUserControl_ImageViewer = New UserControl_ImageViewer(objLocalConfig)
                objUserControl_ImageViewer.Dock = DockStyle.Fill
                ToolStripContainer1.ContentPanel.Controls.Add(objUserControl_ImageViewer)
            Case objLocalConfig.OItem_Type_Media_Item.GUID
                objUserControl_MediaPlayer = New UserControl_MediaPlayer(objLocalConfig)
                objUserControl_MediaPlayer.Dock = DockStyle.Fill
                ToolStripContainer1.ContentPanel.Controls.Add(objUserControl_MediaPlayer)
        End Select
    End Sub

    Private Sub ToolStripButton_First_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_First.Click
        RaiseEvent Media_First()
        If boolNavigation Then
            configure_List()
            configure_Viewer()
        End If
    End Sub

    Private Sub ToolStripButton_Previous_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Previous.Click
        RaiseEvent Media_Previous()
        If boolNavigation Then
            configure_List()
            configure_Viewer()
        End If
    End Sub

    Private Sub ToolStripButton_Next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Next.Click
        RaiseEvent Media_Next()
        If boolNavigation Then
            configure_List()
            configure_Viewer()
        End If
    End Sub

    Private Sub ToolStripButton_Last_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Last.Click
        RaiseEvent Media_Last()
        If boolNavigation Then
            configure_List()
            configure_Viewer()
        End If
    End Sub

    Private Sub ToolStripButton_Playlist_CheckStateChanged(sender As Object, e As EventArgs) Handles ToolStripButton_Playlist.CheckStateChanged
        objUserControl_MediaPlayer.Playlist = ToolStripButton_Playlist.Checked
    End Sub

    Private Sub ToolStripButton_Add_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Add.Click
        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                OpenFileDialog_Media.Filter = "PDF-Dateien|*.pdf"
                OpenFileDialog_Media.Multiselect = True
                If OpenFileDialog_Media.ShowDialog(Me) = DialogResult.OK Then
                    AddMedia(OpenFileDialog_Media.FileNames)
                End If

            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                OpenFileDialog_Media.Multiselect = True
                OpenFileDialog_Media.ShowDialog(Me)
                If OpenFileDialog_Media.ShowDialog(Me) = DialogResult.OK Then
                    AddMedia(OpenFileDialog_Media.FileNames)
                End If
            Case objLocalConfig.OItem_Type_Media_Item.GUID
                OpenFileDialog_Media.Multiselect = True
                OpenFileDialog_Media.ShowDialog(Me)
                If OpenFileDialog_Media.ShowDialog(Me) = DialogResult.OK Then
                    AddMedia(OpenFileDialog_Media.FileNames)
                End If
        End Select
    End Sub

    Private Sub AddMedia(strPaths() As String)
        Dim intToDo = strPaths.Count
        Dim objOItem_File As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Media As clsOntologyItem
        Dim intDone = 0

        For Each strPath In strPaths
            objTransaction.ClearItems()
            Try
                If objOItem_MediaType.GUID = objLocalConfig.OItem_Type_Images__Graphic_.GUID Then
                    Dim objImage = New Bitmap(strPath)
                End If

                objOItem_File = objBlobConnection.isFilePresent(strPath)
                If objOItem_File Is Nothing Then
                    objOItem_File = New clsOntologyItem
                    objOItem_File.GUID = objLocalConfig.Globals.NewGUID
                    objOItem_File.Name = IO.Path.GetFileName(strPath)
                    objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
                    objOItem_File.Type = objLocalConfig.Globals.Type_Object

                    objOItem_Result = objTransaction.do_Transaction(objOItem_File)
                Else
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If


                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Result = objBlobConnection.save_File_To_Blob(objOItem_File, strPath)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID 
                        objOItem_Media = objDataWork_Images.GetImageItemOfFile(objOItem_File, objOItem_MediaType)
                        If objOItem_Media Is Nothing Then
                            objOItem_Media = New clsOntologyItem
                            objOItem_Media.GUID = objLocalConfig.Globals.NewGUID
                            objOItem_Media.Name = objOItem_File.Name
                            objOItem_Media.GUID_Parent = objOItem_MediaType.GUID
                            objOItem_Media.Type = objLocalConfig.Globals.Type_Object

                            objOItem_Result = objTransaction.do_Transaction(objOItem_Media)
                        Else
                            objOItem_Result = objLocalConfig.Globals.LState_Success
                        End If
                        
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Dim objORel_Image_To_File = objDataWork_Images.Rel_Image_To_File(objOItem_Media, objOItem_File)

                            objOItem_Result = objTransaction.do_Transaction(objORel_Image_To_File, True)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objOItem_Media.Level = objDataWork_Images.GetNextOrderIDOFRef(objOItem_Ref)
                                objOItem_Media.Level = objOItem_Media.Level + 1
                                Dim objORel_Image_To_Ref = objDataWork_Images.Rel_Image_To_Ref(objOItem_Media, objOItem_Ref, True)

                                objOItem_Result = objTransaction.do_Transaction(objORel_Image_To_Ref)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    Dim objORel_Image__Taking = objDataWork_Images.Rel_Image__Taking(objOItem_Media, objBlobConnection.FileInfoBlob.CreationTime)
                                    objOItem_Result = objTransaction.do_Transaction(objORel_Image__Taking)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        intDone = intDone + 1
                                    Else
                                        objTransaction.rollback()
                                    End If

                                Else
                                    objTransaction.rollback()
                                End If
                            End If
                        Else
                            objTransaction.rollback()

                        End If
                    Else
                        objTransaction.rollback()

                    End If
                End If
            Catch ex As Exception

            End Try



        Next

        If intDone < intToDo Then
            MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Dateien gespeichert werden!", MsgBoxStyle.Exclamation)
        End If

        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                initialize_Image(objOItem_Ref)
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                initialize_PDF(objOItem_Ref)
            Case objLocalConfig.OItem_Type_Media_Item.GUID
                initialize_MediaItem(objOItem_Ref)
        End Select
    End Sub
End Class
