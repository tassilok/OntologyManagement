Public Class frmSearchOutput

    Public Event search(ByVal strSearch As String)
    Public Event initialized()
    Private strSearch As String

    Private Sub Button_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Search.Click
        If TextBox_Search.Text = "" Then
            MsgBox("Sie haben keinen Suchstring eingegeben!", MsgBoxStyle.Information)
        Else
            strSearch = TextBox_Search.Text
            RaiseEvent search(strSearch)
        End If
    End Sub

    
    Private Sub frmSearchOutput_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RaiseEvent initialized()
    End Sub

    Private Sub TextBox_Search_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_Search.TextChanged
        If TextBox_Search.Text = "" And strSearch <> TextBox_Search.Text Then
            strSearch = TextBox_Search.Text
            RaiseEvent initialized()
        End If
    End Sub
End Class