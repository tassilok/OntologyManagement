Public Class frmMain
    Private WithEvents objElasticSearchToExcel As New clsElasticSearchToExcel

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
        'test_Apache_Log()
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
End Class
