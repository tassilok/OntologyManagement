Public Class frmMain
    Private WithEvents objElasticSearchToExcel As New clsElasticSearchStatistics
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
        frmTurnover = New frmTurnover()
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
End Class
