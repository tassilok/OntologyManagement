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
                End If

            End If
        End If
        Button_Start.Enabled = True
    End Sub

    Private Sub Timer_Durance_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Durance.Tick
        Label_Durance.Text = (Now - dateStart).ToString

    End Sub
End Class