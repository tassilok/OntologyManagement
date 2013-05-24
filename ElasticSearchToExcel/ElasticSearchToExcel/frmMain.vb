Public Class frmMain
    Private objConfig As New clsConfig
    Private WithEvents objElasticSearchToExcel As clsElasticSearchStatistics
    Private objFrmDeleteIndex As frmDeleteIndex
    Private frmTurnover As frmTurnover

    Private Sub counted_Search(ByVal lngCount) Handles objElasticSearchToExcel.counted_Search
        Label_Count.Text = lngCount
        If lngCount > 0 Then
            Button_Query.Enabled = True
        End If
    End Sub
    Private Sub test_Apache_Log()
        Dim strQuery As String

        strQuery = "File:*Prod01*"

        objElasticSearchToExcel.QueryToExcel(strQuery, True)
        objElasticSearchToExcel.QueryToExcel(strQuery, False)
    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        initialize()
    End Sub

    Private Sub initialize()
        objElasticSearchToExcel = New clsElasticSearchStatistics(objConfig)
        'temp_OP()
    End Sub

    Private Sub temp_OP()
        Dim strID As String
        Dim objDict As New Dictionary(Of String, Object)

        strID = "518a3241119e4e4fa5aa6c82113cb46e"

        objDict.Add("Last", "2013-04-03T23:59:59.000Z")

        objElasticSearchToExcel.change_By_Id(strID, objDict, "explido_access_tst_meta", "explido_Meta")
    End Sub

    Private Sub Button_Count_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Count.Click
        Dim strQuery As String

        Button_Query.Enabled = False
        strQuery = TextBox_Query.Text

        If strQuery <> "" Then
            objElasticSearchToExcel.QueryToExcel(strQuery, True)
        Else
            MsgBox("Bitte einen Suchstring eingeben!", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub Button_Query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Query.Click
        Dim strQuery As String

        Button_Query.Enabled = False
        strQuery = TextBox_Query.Text

        If strQuery <> "" Then
            objElasticSearchToExcel.QueryToExcel(strQuery, False)
        End If
    End Sub

    Private Sub ToolStripButton_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Private Sub TurnoverMeasureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TurnoverMeasureToolStripMenuItem.Click
        frmTurnover = New frmTurnover(objConfig)
        frmTurnover.ShowDialog(Me)
    End Sub

    Private Sub TestDeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestDeleteToolStripMenuItem.Click
        Dim strKey As String
        Dim strValue As String
        Dim objDict As New Dictionary(Of String, Object)

        strKey = InputBox("Get the Key", "Key")
        strValue = InputBox("Get the Value", "Key")

        If strKey <> "" And strValue <> "" Then
            objDict.Add(strKey, strValue)
            objElasticSearchToExcel.del_By_Query(objDict, True)
        End If
    End Sub

    Private Sub TestDeleterangeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestDeleterangeToolStripMenuItem.Click
        Dim strField As String
        Dim strStart As String
        Dim strEnd As String
        Dim dateStart As Date
        Dim dateEnd As Date

        strField = InputBox("Which field?")
        strStart = InputBox("Range-Start", DefaultResponse:=Now.ToString)
        strEnd = InputBox("Range-End", DefaultResponse:=Now.ToString)

        If strField <> "" Then
            If Date.TryParse(strStart, dateStart) Then
                If Date.TryParse(strEnd, dateEnd) Then
                    objElasticSearchToExcel.del_By_DateRange(strField, dateStart, dateEnd)
                Else
                    MsgBox("Bitte gültige Werte eingeben!", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Bitte gültige Werte eingeben!", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Bitte gültige Werte eingeben!", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub DeleteIndexToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteIndexToolStripMenuItem.Click
        objFrmDeleteIndex = New frmDeleteIndex(objConfig)
        objFrmDeleteIndex.ShowDialog(Me)
    End Sub
End Class
