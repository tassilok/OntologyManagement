Public Class frmTurnover

    Private intID As Integer
    Private objELStatistics As New clsElasticSearchStatistics()
    Private dateStart As Date

    Private Sub initialize()
        intID = 1
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        initialize()

    End Sub

    Private Sub Button_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Start.Click
        
        start_Measure()
    End Sub

    Private Sub start_Measure()
        Dim lngMs As Long
        Dim objDR_Turnover As DataRow
        Dim objDRs_Turnover As DataRow

        If Not ComboBox_Unit.SelectedItem Is Nothing Then
            Select Case ComboBox_Unit.Text
                Case "min"
                    lngMs = NumericUpDown_Interval.Value * 60 * 1000
                Case "hour"
                    lngMs = NumericUpDown_Interval.Value * 60 * 60 * 1000
                Case Else
                    lngMs = 0
            End Select

            If lngMs > 0 Then
                If objELStatistics.get_EL_State() = True Then
                    Timer_Measure.Interval = lngMs
                    objDR_Turnover = DataSet_Measure.Turnover.NewRow()
                    intID = objDR_Turnover("ID")
                    dateStart = Now
                    objDR_Turnover("Start") = dateStart
                    objDR_Turnover("Volume_Start") = objELStatistics.IndexStat.NumDocs
                    objDR_Turnover("Size_Start_Byte") = objELStatistics.StoreStat.Size

                    DataSet_Measure.Turnover.Rows.Add(objDR_Turnover)
                    Button_Start.Enabled = False
                    ToolStripButton_Open.Enabled = False
                    Timer_Measure.Start()
                    Timer_Durance.Start()
                Else
                    MsgBox("State of Cluster can not be retrieved!", MsgBoxStyle.Information)
                End If


            Else
                MsgBox("No valid interval", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Choose a time-unit, please!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Timer_Measure_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Measure.Tick
        Dim objDRs_Line() As DataRow
        Dim lngSec As Long
        Dim lngMs As Long
        Timer_Measure.Stop()
        Timer_Durance.Stop()

        If intID > 0 Then
            objDRs_Line = DataSet_Measure.Turnover.Select("ID=" & intID)
            If objDRs_Line.Count > 0 Then
                If objELStatistics.get_EL_State() = True Then
                    objDRs_Line(0)("End") = Now
                    objDRs_Line(0)("Volume_End") = objELStatistics.IndexStat.NumDocs
                    objDRs_Line(0)("Size_End_Byte") = objELStatistics.StoreStat.Size
                    lngSec = DateDiff(DateInterval.Second, objDRs_Line(0)("Start"), objDRs_Line(0)("End"))
                    lngMs = DateDiff(DateInterval.Second, objDRs_Line(0)("Start"), objDRs_Line(0)("End")) * 1000
                    objDRs_Line(0)("Durance_Sec") = lngSec
                    objDRs_Line(0)("Durance_Ms") = lngMs
                    objDRs_Line(0)("Volume_Per_Sec") = (objDRs_Line(0)("Volume_End") - objDRs_Line(0)("Volume_Start")) / objDRs_Line(0)("Durance_Sec")
                    objDRs_Line(0)("Size_Per_Volume") = objDRs_Line(0)("Size_End_Byte") / objDRs_Line(0)("Volume_End")
                    DataGridView_Turnover.Refresh()
                    ToolStripButton_Open.Enabled = True
                    If CheckBox_AutoSave.Checked = True Then
                        Try
                            DataSet_Measure.Turnover.WriteXml(TextBox_AutoSaveFile.Text)
                        Catch ex As Exception
                            MsgBox("The File cannot be saved!", MsgBoxStyle.Exclamation)
                        End Try
                    End If
                    If CheckBox_Restart.Checked = True Then
                        start_Measure()
                    End If
                End If

            End If
        End If
        Button_Start.Enabled = True
    End Sub

    Private Sub Timer_Durance_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Durance.Tick
        Label_Durance.Text = (Now - dateStart).ToString

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim strFile As String
        If SaveFileDialog_Measure.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            strFile = SaveFileDialog_Measure.FileName
            DataSet_Measure.Turnover.WriteXml(strFile)
        End If

    End Sub

    Private Sub ToolStripButton_Open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Open.Click
        Dim strFile As String
        If OpenFileDialog_Measure.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            strFile = OpenFileDialog_Measure.FileName
            Try
                DataSet_Measure.ReadXml(strFile)
            Catch ex As Exception
                MsgBox("The file cannot be found!", MsgBoxStyle.Information)
            End Try


        End If
    End Sub


    Private Sub Button_AutoSaveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_AutoSaveFile.Click
        If SaveFileDialog_Measure.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            TextBox_AutoSaveFile.Text = SaveFileDialog_Measure.FileName
        End If
    End Sub

    Private Sub TextBox_AutoSaveFile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_AutoSaveFile.TextChanged
        If IO.File.Exists(TextBox_AutoSaveFile.Text) Then
            CheckBox_AutoSave.Checked = True
        Else
            MsgBox("The file cannot be found!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub CheckBox_AutoSave_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox_AutoSave.CheckedChanged
        
    End Sub

    Private Sub CheckBox_AutoSave_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox_AutoSave.CheckStateChanged
        If CheckBox_AutoSave.Checked = True Then
            If TextBox_AutoSaveFile.Text = "" Then
                MsgBox("No Filename defined!", MsgBoxStyle.Information)
                CheckBox_AutoSave.Checked = False
            End If
        End If
    End Sub
End Class