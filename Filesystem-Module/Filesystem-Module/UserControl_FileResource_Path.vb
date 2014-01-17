Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Structure_Module
Imports TextParser
Imports System.Threading


Public Class UserControl_FileResource_Path

    Private objLocalConfig As clsLocalConfig

    Private objDataWork_FileResource_Path As clsDataWork_FileResource_Path
    Private objUserControl_RegExTester As UserControl_RegExTester

    Private objOItem_FileResource As clsOntologyItem

    Private objThread_Files As Threading.Thread
    Private objThread_LineCount As Threading.Thread

    Private lngLineCount As Long = 0 

    Private objFileList As SortableBindingList(Of clsFile)

    Private objOItem_Result_FileCount As clsOntologyItem

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
        
        DataGridView_Files.DataSource = Nothing
        ToolStripButton_Open.Enabled = False
        TextBox_Pattern.ReadOnly = True
        Button_AddPath.Enabled = True
    End Sub

    Private Sub Initialize()
        objDataWork_FileResource_Path = New clsDataWork_FileResource_Path(objLocalConfig)
        objUserControl_RegExTester = new UserControl_RegExTester(objLocalConfig.Globals)
        objUserControl_RegExTester.Initialize_Field()
        objUserControl_RegExTester.Dock = DockStyle.Fill
        ToolStripContainer1.ContentPanel.Controls.Add(objUserControl_RegExTester)
    End Sub


    Private Sub Button_Search_Click(sender As Object, e As EventArgs) Handles Button_Search.Click
        Try
            objThread_Files.Abort()
        Catch ex As Exception

        End Try
        Timer_Files.Stop()
        Timer_LineCount.Stop()
        Button_Search.Enabled = False
        objThread_Files = New Thread(AddressOf GetFiles)
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

            ToolStripLabel_Count.Text = DataGridView_Files.RowCount

            ToolStripProgressBar_LineCount.Value = 0
            
            
            Try
                objThread_Files.Abort()
            Catch ex As Exception

            End Try
            objOItem_Result_FileCount = objLocalConfig.Globals.LState_Nothing.Clone()
            lngLineCount = 0
            objThread_LineCount = new Thread(AddressOf GetLineCount)
            objThread_LineCount.Start()

            Timer_LineCount.Start()
        End If
    End Sub


    Private Sub DataGridView_Files_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView_Files.SelectionChanged
        ToolStripButton_Open.Enabled = False
        If DataGridView_Files.SelectedRows.Count = 1 Then
            ToolStripButton_Open.Enabled = True
        End If
    End Sub

    
    Private Sub ToolStripButton_Open_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_Open.Click
        Dim objDGVR_Selected As DataGridViewRow = DataGridView_Files.SelectedRows(0)
        Dim objFile As clsFile = objDGVR_Selected.DataBoundItem

        If IO.File.Exists(objFile.FileName) Then
            objUserControl_RegExTester.SetContentByFilePath(objFile.FileName)
        Else
            MsgBox("Die Datei existiert nicht!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    
    Private sub GetLineCount()
        
        For Each objDGVR As DataGridViewRow In DataGridView_Files.Rows
            Dim objFile As clsFile = objDGVR.DataBoundItem

            Try
                lngLineCount = lngLineCount + IO.File.ReadAllLines(objFile.FileName).Length

            Catch ex As Exception
                objOItem_Result_FileCount = objLocalConfig.Globals.LState_Error.Clone()
                Exit For
            End Try
        Next
        If objOItem_Result_FileCount.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOItem_Result_FileCount = objLocalConfig.Globals.LState_Success.Clone()
        End If
    End Sub

    

    Private Sub Timer_LineCount_Tick( sender As Object,  e As EventArgs) Handles Timer_LineCount.Tick
        If objOItem_Result_FileCount.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            ToolStripProgressBar_LineCount.Value = 50
        Else 
            ToolStripLabel_LineCount.Text =  lngLineCount
            ToolStripProgressBar_LineCount.Value = 0

            Timer_LineCount.Stop()
        End If
    End Sub
End Class
