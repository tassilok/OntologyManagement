Imports Ontolog_Module
Public Class frmLogModule
    Private objLocalConfig As clsLocalConfig
    Private objUserControl_LogEntryList As UserControl_OItemList
    Private objUserControl_LogEntry As UserControl_LogEntry

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
    End Sub

    Private Sub set_DBConnection()

    End Sub
End Class
