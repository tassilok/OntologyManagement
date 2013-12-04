Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Structure_Module
Imports System.Text.RegularExpressions

Public Class UserControl_FileResource_Path

    Private objLocalConfig As clsLocalConfig

    Private objDataWork_FileResource_Path As clsDataWork_FileResource_Path

    Private objOItem_FileResource As clsOntologyItem

    Private objThread_Files As Threading.Thread

    Private objFileList As SortableBindingList(Of clsFile)

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Public Sub Initialize_Path(OItem_FileResource)

        objOItem_FileResource = OItem_FileResource
        Clear()
        If Not objOItem_FileResource Is Nothing Then
            objDataWork_FileResource_Path.GetData_Attributes(objOItem_FileResource)
            If objDataWork_FileResource_Path.OItem_Result_Attributes.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objDataWork_FileResource_Path.GetData_Relations(objOItem_FileResource)
                If objDataWork_FileResource_Path.OItem_Result_Relations.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                    If Not objDataWork_FileResource_Path.objORItem_Path Is Nothing Then
                        TextBox_Path.Text = objDataWork_FileResource_Path.objORItem_Path.Name_Other
                        Button_Search.Enabled = True
                    End If

                    If Not objDataWork_FileResource_Path.objOAItem_SubItems Is Nothing Then
                        CheckBox_SubItems.Enabled = False
                        CheckBox_SubItems.Checked = objDataWork_FileResource_Path.objOAItem_SubItems.Val_Bit

                    End If
                    CheckBox_SubItems.Enabled = True

                    If Not objDataWork_FileResource_Path.objOAItem_Pattern Is Nothing Then
                        TextBox_Pattern.ReadOnly = True
                        TextBox_Pattern.Text = objDataWork_FileResource_Path.objOAItem_Pattern.Val_String

                    End If
                    TextBox_Pattern.ReadOnly = False
                Else
                    MsgBox("Die Daten konnten nicht ermittelt werden!", MsgBoxStyle.Exclamation)
                End If
            Else
                MsgBox("Die Daten konnten nicht ermittelt werden!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub Clear()
        Button_AddPath.Enabled = False
        Button_Search.Enabled = False
        Button_Preview.Enabled = False
        DataGridView_Files.DataSource = Nothing
        TextBox_RegexPre.ReadOnly = True
        TextBox_Pattern.ReadOnly = True
        Button_AddPath.Enabled = True
    End Sub

    Private Sub Initialize()
        objDataWork_FileResource_Path = New clsDataWork_FileResource_Path(objLocalConfig)
    End Sub


    Private Sub Button_Search_Click(sender As Object, e As EventArgs) Handles Button_Search.Click
        Try
            objThread_Files.Abort()
        Catch ex As Exception

        End Try
        Timer_Files.Stop()
        Button_Search.Enabled = False
        objThread_Files = New Threading.Thread(AddressOf GetFiles)
        objThread_Files.Start()
        Timer_Files.Start()
    End Sub

    Private Sub GetFiles()
        objDataWork_FileResource_Path.GetFiles()
    End Sub

    Private Sub Timer_Files_Tick(sender As Object, e As EventArgs) Handles Timer_Files.Tick

        If objDataWork_FileResource_Path.OItem_Result_FileResult.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            ProgressBar_Files.Value = 50
            objFileList = New SortableBindingList(Of clsFile)(objDataWork_FileResource_Path.FileList)
            DataGridView_Files.DataSource = objFileList
        ElseIf objDataWork_FileResource_Path.OItem_Result_FileResult.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            Timer_Files.Stop()
            ProgressBar_Files.Value = 0
            MsgBox("Beim Ermitteln der Dateien ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
            Button_Search.Enabled = True
        ElseIf objDataWork_FileResource_Path.OItem_Result_FileResult.GUID = objLocalConfig.Globals.LState_Relation.GUID Then
            Timer_Files.Stop()
            ProgressBar_Files.Value = 0
            MsgBox("Der Pfad existiert nicht!", MsgBoxStyle.Exclamation)
            Button_Search.Enabled = True
        Else
            Timer_Files.Stop()
            objFileList = New SortableBindingList(Of clsFile)(objDataWork_FileResource_Path.FileList)
            DataGridView_Files.DataSource = objFileList
            ProgressBar_Files.Value = 0
            Button_Search.Enabled = True
        End If
    End Sub


    Private Sub DataGridView_Files_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView_Files.SelectionChanged
        If DataGridView_Files.SelectedRows.Count = 1 Then
            Button_Preview.Enabled = True
            TextBox_RegexPre.ReadOnly = False
        End If
    End Sub

    Private Sub Button_Preview_Click(sender As Object, e As EventArgs) Handles Button_Preview.Click
        Dim objDGVR_Selected As DataGridViewRow = DataGridView_Files.SelectedRows(0)
        Dim objFile As clsFile = objDGVR_Selected.DataBoundItem

        If IO.File.Exists(objFile.FileName) Then
            Dim objTextReader = IO.File.OpenText(objFile.FileName)
            RichTextBox_Preview.Text = objTextReader.ReadToEnd
            objTextReader.Close()

        Else
            MsgBox("Die Datei existiert nicht!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub TextBox_Regex_TextChanged(sender As Object, e As EventArgs) Handles TextBox_RegexPre.TextChanged
        Timer_Regex.Stop()
        Timer_Regex.Start()

    End Sub

    Private Sub Timer_Regex_Tick(sender As Object, e As EventArgs) Handles Timer_Regex.Tick
        Dim boolRegExPre As Boolean = False
        Dim boolRegExMain As Boolean = False
        Dim boolRegExPost As Boolean = False

        Timer_Regex.Stop()
        Try
            RichTextBox_Preview.SelectionStart = 0
            RichTextBox_Preview.SelectionLength = RichTextBox_Preview.TextLength - 1
            RichTextBox_Preview.SelectionBackColor = RichTextBox_Preview.BackColor

            Dim objRegEx_Pre As Regex = Nothing
            Dim objRegEx_Main As Regex = Nothing
            Dim objRegEx_Post As Regex = Nothing

            Dim objRegEx_Pre_Matches As MatchCollection = Nothing
            Dim objRegEx_Main_Matches As MatchCollection = Nothing
            Dim objRegEx_Post_Matches As MatchCollection = Nothing
            If Not TextBox_RegexPre.Text = "" Then
                objRegEx_Pre = New Regex(TextBox_RegexPre.Text)
            End If
            If Not TextBox_RegExMain.Text = "" Then
                objRegEx_Main = New Regex(TextBox_RegExMain.Text)
            End If

            If Not TextBox_RegExPost.Text = "" Then
                objRegEx_Post = New Regex(TextBox_RegExPost.Text)
            End If



            boolRegExPre = True
            If TextBox_RegexPre.Text <> "" Then

                objRegEx_Pre_Matches = objRegEx_Pre.Matches(RichTextBox_Preview.Text)
            Else
                boolRegExMain = True
                If TextBox_RegExMain.Text <> "" Then

                    objRegEx_Main_Matches = objRegEx_Main.Matches(RichTextBox_Preview.Text)

                End If

                boolRegExPost = True
                If TextBox_RegExPost.Text <> "" Then

                    objRegEx_Post_Matches = objRegEx_Post.Matches(RichTextBox_Preview.Text)
                End If
                

                
            End If

            

            

            If Not objRegEx_Pre_Matches Is Nothing Then
                For i = 0 To objRegEx_Pre_Matches.Count - 1

                    RichTextBox_Preview.SelectionStart = 0
                    RichTextBox_Preview.SelectionLength = 0

                    Dim ixStart = objRegEx_Pre_Matches(i).Index + objRegEx_Pre_Matches(i).Length
                    Dim ixEnd = ixStart
                    If i < objRegEx_Pre_Matches.Count Then
                        ixEnd = objRegEx_Pre_Matches(i + 1).Index
                    Else
                        ixEnd = RichTextBox_Preview.TextLength - 1
                    End If
                    RichTextBox_Preview.SelectionStart = ixStart
                    RichTextBox_Preview.SelectionLength = ixEnd - ixStart


                    If Not objRegEx_Post Is Nothing Then


                        If RichTextBox_Preview.SelectionStart > 0 Then
                            objRegEx_Post_Matches = objRegEx_Post.Matches(RichTextBox_Preview.SelectedText)
                            If objRegEx_Post_Matches.Count > 0 Then
                                RichTextBox_Preview.SelectionLength = objRegEx_Post_Matches(0).Index
                            Else
                                RichTextBox_Preview.SelectionStart = 0
                                RichTextBox_Preview.SelectionLength = 0
                            End If
                        End If



                    End If

                    If RichTextBox_Preview.SelectionStart > 0 Then
                        If Not objRegEx_Main Is Nothing Then
                            objRegEx_Main_Matches = objRegEx_Main.Matches(RichTextBox_Preview.SelectedText)
                            If objRegEx_Main_Matches.Count > 0 Then
                                RichTextBox_Preview.SelectionStart = objRegEx_Main_Matches(0).Index
                                RichTextBox_Preview.SelectionLength = objRegEx_Main_Matches(0).Length
                            Else
                                RichTextBox_Preview.SelectionStart = 0
                                RichTextBox_Preview.SelectionLength = 0
                            End If
                        Else
                            If objRegEx_Post Is Nothing Then
                                RichTextBox_Preview.SelectionStart = 0
                                RichTextBox_Preview.SelectionLength = 0
                            End If
                            
                        End If
                    End If

                    If RichTextBox_Preview.SelectionStart > 0 Then
                        RichTextBox_Preview.SelectionBackColor = Color.Yellow
                    End If
                Next

            End If

            
        Catch ex As Exception
            TextBox_RegexPre.BackColor = Color.Yellow
        End Try





    End Sub

    Private Sub TextBox_RegExMain_TextChanged(sender As Object, e As EventArgs) Handles TextBox_RegExMain.TextChanged
        Timer_Regex.Stop()
        Timer_Regex.Start()
    End Sub

    Private Sub TextBox_RegExPost_TextChanged(sender As Object, e As EventArgs) Handles TextBox_RegExPost.TextChanged
        Timer_Regex.Stop()
        Timer_Regex.Start()
    End Sub
End Class
