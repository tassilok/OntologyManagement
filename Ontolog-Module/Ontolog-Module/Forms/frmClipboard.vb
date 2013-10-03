Imports OntologyClasses.BaseClasses

Public Class frmClipboard

    Private objLocalConfig As clsLocalConfig
    Private objOntologyClipboard As clsOntologyClipboard
    Private objOItem_Item As clsOntologyItem

    Public Function selectedRows() As DataGridViewSelectedRowCollection
        Return DataGridView_Items.SelectedRows
    End Function

    Private Sub initialize()
        Dim objLClipboard As New List(Of clsObjectRel)
        objLClipboard = objOntologyClipboard.getFromClipboard(objOItem_Item)
        DataGridView_Items.DataSource = objLClipboard
        DataGridView_Items.Columns(0).Visible = False
        DataGridView_Items.Columns(1).Visible = False
        DataGridView_Items.Columns(2).Visible = False
        DataGridView_Items.Columns(3).Visible = False
        DataGridView_Items.Columns(4).Visible = False
        DataGridView_Items.Columns(5).Visible = True
        DataGridView_Items.Columns(6).Visible = False
        DataGridView_Items.Columns(7).Visible = True
        DataGridView_Items.Columns(8).Visible = False
        DataGridView_Items.Columns(9).Visible = False
        DataGridView_Items.Columns(10).Visible = False
        DataGridView_Items.Columns(11).Visible = False
        DataGridView_Items.Columns(12).Visible = False
        DataGridView_Items.Columns(13).Visible = False

        DataGridView_Items.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        If DataGridView_Items.Rows.Count > 0 Then
            Button_Clear.Enabled = True
        End If

    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig, ByVal OItem_Item As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        objOItem_Item = OItem_Item
        set_DBConnection()
        initialize()
    End Sub

    Public Function containedByClipboard() As Boolean
        Dim boolResult As Boolean = False
        Dim objOItem_Result As clsOntologyItem

        objOItem_Result = objOntologyClipboard.containedByClipboard(objOItem_Item)
        If objOItem_Result Is Nothing Then
            boolResult = False
        Else

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objOItem_Result.Count > 0 Then
                    boolResult = True
                Else
                    boolResult = False
                End If
            Else
                Err.Raise(1, "Das Clipboard kann nicht geöffnet werden!")
            End If
        End If
        


        Return boolResult
    End Function

    Public Sub New(ByVal Globals As clsGlobals, ByVal OItem_Item As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        objOItem_Item = OItem_Item
        set_DBConnection()
        initialize()
    End Sub

    Private Sub set_DBConnection()
        objOntologyClipboard = New clsOntologyClipboard(objLocalConfig)
    End Sub

    Private Sub Button_Apply_Click(sender As Object, e As EventArgs) Handles Button_Apply.Click

        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub

    Private Sub DataGridView_Items_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView_Items.SelectionChanged
        Button_Apply.Enabled = False

        If DataGridView_Items.SelectedRows.Count > 0 Then
            Button_Apply.Enabled = True
        End If
    End Sub

    Private Sub Button_Clear_Click(sender As Object, e As EventArgs) Handles Button_Clear.Click
        Dim objOItem_Result = objOntologyClipboard.clear_Clipboard(objOItem_Item)
    End Sub
End Class