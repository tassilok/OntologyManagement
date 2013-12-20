Imports Structure_Module
Imports System.Threading
Public Class frmMetaData_Image

    Private objLocalConfig As clsLocalConfig

    Private objDataWork_Image As clsDataWork_Images

    Private objOList_ImageMeta As New SortableBindingList(Of clsImage)

    Private objThread_Metadata As Thread

    Private boolAbort As Boolean

    Private Sub ToolStripButton_Close_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Private Sub ClearControls()
        ToolStripButton_Abort.Enabled = False
        ToolStripButton_Suspend.Enabled = False
        ToolStripButton_Start.Enabled = False
        DataGridView_MetaData.Enabled = False
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        ClearControls()
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



        If DataGridView_MetaData.RowCount > 0 Then
            ToolStripButton_Start.Enabled = True
        End If
    End Sub

    Private Sub SetMetaData()
        For Each objImage In objOList_ImageMeta
            If boolAbort Then
                Exit For
            End If

            If objImage.ID_Day Is Nothing Or _
                objImage.ID_Month Is Nothing Or _
                objImage.ID_Year Is Nothing Then



            End If
        Next
    End Sub

    Private Sub ToolStripButton_Start_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Start.Click
        objThread_Metadata = New Thread(AddressOf SetMetaData)
        objThread_Metadata.Start()
        Timer_Metadata.Start()

        boolAbort = False

        ToolStripButton_Start.Enabled = False
        ToolStripButton_Suspend.Enabled = True
        ToolStripButton_Abort.Enabled = True

    End Sub
End Class
