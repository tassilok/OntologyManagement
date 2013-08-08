Imports Ontolog_Module
Imports Security_Module
Public Class frmLogModule
    Private objLocalConfig As clsLocalConfig
    Private WithEvents objUserControl_LogEntryList As UserControl_OItemList
    Private objUserControl_LogEntry As UserControl_LogEntry
    Private objFrmAuthenticate As frmAuthenticate
    Private boolOpen As Boolean

    Private Sub selected_LogEntry() Handles objUserControl_LogEntryList.Selection_Changed
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOItem_LogEntry As clsOntologyItem

        If objUserControl_LogEntryList.DataGridViewRowCollection_Selected.Count = 1 Then
            objDGVR_Selected = objUserControl_LogEntryList.DataGridViewRowCollection_Selected(0)
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            objOItem_LogEntry = New clsOntologyItem
            objOItem_LogEntry.GUID = objDRV_Selected.Item("ID_Item")
            objOItem_LogEntry.Name = objDRV_Selected.Item("Name")
            objOItem_LogEntry.GUID_Parent = objLocalConfig.OItem_Type_LogEntry.GUID
            objOItem_LogEntry.Type = objLocalConfig.Globals.Type_Object

            objUserControl_LogEntry.initialize_LogEntry(objOItem_LogEntry)
        End If
    End Sub

    Private Sub ToolStripButton_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals)
        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        objUserControl_LogEntryList = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_LogEntryList.Dock = DockStyle.Fill
        SplitContainer1.Panel1.Controls.Add(objUserControl_LogEntryList)

        objUserControl_LogEntryList.initialize(New clsOntologyItem(Nothing, _
                                                                   Nothing, _
                                                                   objLocalConfig.OItem_Type_LogEntry.GUID, _
                                                                   objLocalConfig.Globals.Type_Object))

        objUserControl_LogEntry = New UserControl_LogEntry(objLocalConfig)
        objUserControl_LogEntry.Dock = DockStyle.Fill
        SplitContainer1.Panel2.Controls.Add(objUserControl_LogEntry)

        objFrmAuthenticate = New frmAuthenticate(objLocalConfig.Globals, True, False, frmAuthenticate.ERelateMode.NoRelate)
        objFrmAuthenticate.ShowDialog(Me)
        boolOpen = False
        If objFrmAuthenticate.DialogResult = Windows.Forms.DialogResult.OK Then
            objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User
            boolOpen = True

        End If
    End Sub

    Private Sub set_DBConnection()

    End Sub

    Private Sub frmLogModule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If boolOpen = False Then
            Me.Close()
        End If
        ToolStripTextBox_Database.Text = objLocalConfig.Globals.Index & "@" & objLocalConfig.Globals.Server
    End Sub
End Class
