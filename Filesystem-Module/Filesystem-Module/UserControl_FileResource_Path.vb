Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Structure_Module

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

        ElseIf objDataWork_FileResource_Path.OItem_Result_FileResult.GUID = objLocalConfig.Globals.LState_Relation.GUID Then
            Timer_Files.Stop()
            ProgressBar_Files.Value = 0
            MsgBox("Der Pfad existiert nicht!", MsgBoxStyle.Exclamation)
        Else
            Timer_Files.Stop()
            objFileList = New SortableBindingList(Of clsFile)(objDataWork_FileResource_Path.FileList)
            DataGridView_Files.DataSource = objFileList
            ProgressBar_Files.Value = 0
        End If
    End Sub
End Class
