Imports Structure_Module
Public Class frmMetaData_Image

    Private objLocalConfig As clsLocalConfig

    Private objDataWork_Image As clsDataWork_Images

    Private objOList_ImageMeta As New SortableBindingList(Of clsImage)

    Private Sub ToolStripButton_Close_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objDataWork_Image = New clsDataWork_Images(objLocalConfig)
        objOList_ImageMeta = New SortableBindingList(Of clsImage)(objDataWork_Image.GetData_MetaDataImages())

        DataGridView_MetaData.DataSource = objOList_ImageMeta

        DataGridView_MetaData.Columns(0).Visible = False
        DataGridView_MetaData.Columns(2).Visible = False
        DataGridView_MetaData.Columns(4).Visible = False
        DataGridView_MetaData.Columns(5).Visible = False
        DataGridView_MetaData.Columns(7).Visible = False
        DataGridView_MetaData.Columns(8).Visible = False
        DataGridView_MetaData.Columns(10).Visible = False
        DataGridView_MetaData.Columns(11).Visible = False
    End Sub


End Class
