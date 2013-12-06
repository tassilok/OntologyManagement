Imports OntologyClasses.BaseClasses

Public Class UserControl_ObjectAtt

    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_ObjAtt As clsDBLevel

    Private objOItem_Object As clsOntologyItem
    Private objOItem_AttributeType As clsOntologyItem

    Private objThread As Threading.Thread
    Private boolDataDone As Boolean

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Public Sub initialize_RelList(ByVal OItem_Object As clsOntologyItem, _
                                  ByVal OItem_AttributeType As clsOntologyItem)

        objOItem_Object = OItem_Object
        objOItem_AttributeType = OItem_AttributeType

        BindingSource_ObjectAtt.DataSource = Nothing
        DataGridView_ObjectAtt.DataSource = Nothing

        Try
            objThread.Abort()
        Catch ex As Exception

        End Try

        boolDataDone = False

        objThread = New Threading.Thread(AddressOf get_Data)

        Timer_ObjectAtt.Stop()
        Timer_ObjectAtt.Start()
        objThread.Start()
    End Sub

    Private Sub get_Data()
        Dim oList_ObjAtt As New List(Of clsObjectAtt)

        If Not objOItem_AttributeType Is Nothing Then
            oList_ObjAtt.Add(New clsObjectAtt(Nothing, objOItem_Object.GUID, Nothing, objOItem_AttributeType.GUID, Nothing))
        Else
            oList_ObjAtt.Add(New clsObjectAtt(Nothing, objOItem_Object.GUID, Nothing, Nothing, Nothing))
        End If

        objDBLevel_ObjAtt.get_Data_ObjectAtt(oList_ObjAtt, True, _
                                             False)
        boolDataDone = True
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_ObjAtt = New clsDBLevel(objLocalConfig.Globals)
    End Sub

    Private Sub Timer_ObjectAtt_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_ObjectAtt.Tick
        If boolDataDone = True Then
            Timer_ObjectAtt.Stop()
            BindingSource_ObjectAtt.DataSource = objDBLevel_ObjAtt.tbl_ObjectAttribute
            DataGridView_ObjectAtt.DataSource = BindingSource_ObjectAtt

            DataGridView_ObjectAtt.Columns(0).Visible = False
            DataGridView_ObjectAtt.Columns(1).Visible = False
            DataGridView_ObjectAtt.Columns(2).Visible = False
            DataGridView_ObjectAtt.Columns(3).Visible = False
            DataGridView_ObjectAtt.Columns(5).Visible = False
            DataGridView_ObjectAtt.Columns(6).Visible = False
            DataGridView_ObjectAtt.Columns(9).Visible = False
            DataGridView_ObjectAtt.Columns(10).Visible = False
            DataGridView_ObjectAtt.Columns(11).Visible = False
            DataGridView_ObjectAtt.Columns(12).Visible = False
            DataGridView_ObjectAtt.Columns(13).Visible = False
            DataGridView_ObjectAtt.Columns(14).Visible = False
            DataGridView_ObjectAtt.Columns(15).Visible = False


            ToolStripProgressBar_ObjectAtt.Value = 0
        Else
            ToolStripProgressBar_ObjectAtt.Value = 50
        End If
    End Sub

    Private Sub ContextMenuStrip_Items_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Items.Opening
        CopyValueToolStripMenuItem.Enabled = False
        DeleteToolStripMenuItem.Enabled = False
        If DataGridView_ObjectAtt.SelectedRows.Count = 1 Then
            CopyValueToolStripMenuItem.Enabled = True
        End If

        if DataGridView_ObjectAtt.SelectedRows.Count > 0 Then
            DeleteToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub CopyValueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyValueToolStripMenuItem.Click
        Dim objDGVR_Selected = If(DataGridView_ObjectAtt.SelectedRows.Count = 1, DataGridView_ObjectAtt.SelectedRows(0), Nothing)

        If Not objDGVR_Selected Is Nothing Then
            Dim objDRV_Selected As DataRowView = objDGVR_Selected.DataBoundItem

            Select Case objDRV_Selected.Item("ID_DataType")
                Case objLocalConfig.Globals.DType_Bool.GUID
                    Clipboard.SetDataObject(objDRV_Selected.Item(objLocalConfig.Globals.Field_Val_Bool))
                Case objLocalConfig.Globals.DType_DateTime.GUID
                    Clipboard.SetDataObject(objDRV_Selected.Item(objLocalConfig.Globals.Field_Val_Datetime))
                Case objLocalConfig.Globals.DType_Int.GUID
                    Clipboard.SetDataObject(objDRV_Selected.Item(objLocalConfig.Globals.Field_Val_Int))
                Case objLocalConfig.Globals.DType_Real.GUID
                    Clipboard.SetDataObject(objDRV_Selected.Item(objLocalConfig.Globals.Field_Val_Real))
                Case objLocalConfig.Globals.DType_String.GUID
                    Clipboard.SetDataObject(objDRV_Selected.Item(objLocalConfig.Globals.Field_Val_String))
            End Select
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click( sender As Object,  e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If MsgBox("Wollen Sie wirklich die ausgewählten Attribute löschen!",MsgBoxStyle.YesNo)=MsgBoxResult.Yes Then
            Dim objOAL_Attributes As List(Of clsObjectAtt) = (From objDGVR_Selected As DataGridViewRow In DataGridView_ObjectAtt.SelectedRows Select objDRV_Selected = objDGVR_Selected.DataBoundItem Select New clsObjectAtt With {.ID_Attribute = DirectCast(objDRV_Selected, DataRowView).Item("ID_ObjectAttribute")}).ToList()

            Dim objOItem_Result = objDBLevel_ObjAtt.del_ObjectAtt(objOAL_Attributes)

            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                MsgBox("Es konnten nur " & objOItem_Result.Min & " von " & objOItem_Result.Count & " Attribute gelöscht werden!",MsgBoxStyle.Exclamation)
            End If    
            initialize_RelList(objOItem_Object, objOItem_AttributeType)
        End If
        
    End Sub
End Class
