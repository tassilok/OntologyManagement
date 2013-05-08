Public Class UserControl_TransactionList

    Public Event Close()

    Private Sub ToolStripButton_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Close.Click
        RaiseEvent Close()
    End Sub
End Class
