Public Class frmConfig
    Dim strMessage As String
    Dim dtblConfig As DataSet_Config.dtbl_BaseConfigDataTable
    Dim strPathConfig As String

    Public Sub New(dtblConfig As DataSet_Config.dtbl_BaseConfigDataTable, strPathConfig As String, Optional message As String = "-")

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        strMessage = message
        ToolStripLabel_Message.Text = strMessage

        Me.strPathConfig = strPathConfig

        Me.dtblConfig = dtblConfig

        DtblBaseConfigBindingSource.DataSource = Me.dtblConfig
        DataGridView_Config.DataSource = DtblBaseConfigBindingSource

        DataGridView_Config.Columns(0).ReadOnly = True
    End Sub

    Private Sub ToolStripButton_Close_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Close.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ToolStripButton_Save_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Save.Click
        If Not IO.File.Exists(strPathConfig) Then
            strPathConfig = Application.StartupPath & IO.Path.DirectorySeparatorChar & strPathConfig
        End If
        dtblConfig.WriteXml(strPathConfig)
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class