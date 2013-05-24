Public Class frmDeleteIndex
    Private objLocalConfig As clsConfig
    Private objES_Statistics As clsElasticSearchStatistics

    Public Sub New(ByVal LocalConfig As clsConfig)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        objLocalConfig = LocalConfig
        initialize()
    End Sub

    Private Sub initialize()
        objES_Statistics = New clsElasticSearchStatistics(objLocalConfig)
        getIndexes()
    End Sub

    Private Sub getIndexes()
        Dim strIndex As String

        ListView_Indexes.Items.Clear()

        For Each strIndex In objES_Statistics.indexes()
            ListView_Indexes.Items.Add(strIndex, strIndex, 0)
        Next
    End Sub

    Private Sub ToolStripButton_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Delete.Click
        Dim strLIndexes As New List(Of String)
        Dim objListViewItem As ListViewItem
        Dim intNotDeleted As Integer

        For Each objListViewItem In ListView_Indexes.Items
            If objListViewItem.Checked = True Then
                strLIndexes.Add(objListViewItem.Text)
            End If
        Next

        If strLIndexes.Count = 0 Then
            MsgBox("You haven't choosen an Index!", MsgBoxStyle.Information)
        Else
            intNotDeleted = objES_Statistics.delete_Index(strLIndexes)
            If intNotDeleted > 0 Then
                MsgBox(intNotDeleted & " Indexes couldn't be delted!", MsgBoxStyle.Information)
            End If
            getIndexes()
        End If
    End Sub
End Class