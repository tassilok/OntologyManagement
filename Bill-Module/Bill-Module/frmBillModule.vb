Imports Ontolog_Module
Public Class frmBillModule
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_BaseConfig As clsDataWork_BaseConfig
    Private objUserControl_BillTree As UserControl_BillTree
    Private objOItem_Open As clsOntologyItem

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals)

        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        objOItem_Open = objDataWork_BaseConfig.get_Data_BaseConfig()
        If objOItem_Open.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objUserControl_BillTree = New UserControl_BillTree(objLocalConfig, objDataWork_BaseConfig)
            objUserControl_BillTree.Dock = DockStyle.Fill
            SplitContainer1.Panel1.Controls.Add(objUserControl_BillTree)

        End If
    End Sub

    Private Sub set_DBConnection()
        objDataWork_BaseConfig = New clsDataWork_BaseConfig(objLocalConfig)
    End Sub

    Private Sub ToolStripButton_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Private Sub frmBillModule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If objOItem_Open.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            MsgBox("Die Konfiguration konnte nicht geladen werden!", MsgBoxStyle.Exclamation)
            Me.Close()
        End If
    End Sub
End Class
