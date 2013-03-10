Imports Ontolog_Module
Public Class frmReportModule
    Private cint_ImageID_Root As Integer = 0
    Private cint_ImageID_Report As Integer = 1

    Private WithEvents objUserControl_Report As UserControl_Report

    Private objLocalConfig As clsLocalConfig

    Private objDataWork As clsDataWork_ReportTree

    Private objTreeNode_Root As TreeNode

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals)

        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        fill_Tree()
        configure_Controls()
    End Sub

    Private Sub set_DBConnection()
        objDataWork = New clsDataWork_ReportTree(objLocalConfig)
        objUserControl_Report = New UserControl_Report(objLocalConfig)
        objUserControl_Report.Dock = DockStyle.Fill
        SplitContainer1.Panel2.Controls.Add(objUserControl_Report)
    End Sub


    Private Sub fill_Tree()
        TreeView_Report.Nodes.Clear()
        objTreeNode_Root = TreeView_Report.Nodes.Add(objLocalConfig.OItem_Class_Reports.GUID.ToString, _
                                                     objLocalConfig.OItem_Class_Reports.Name, _
                                                     cint_ImageID_Root, cint_ImageID_Root)

        objDataWork.get_SubNodes(objTreeNode_Root, cint_ImageID_Report)

    End Sub

    Private Sub configure_Controls()

    End Sub

    Private Sub TreeView_Report_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView_Report.AfterSelect
        Dim objTreeNode As TreeNode
        Dim objOItem_Report As clsOntologyItem

        objTreeNode = TreeView_Report.SelectedNode

        objOItem_Report = Nothing

        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = cint_ImageID_Report Then
                objOItem_Report = New clsOntologyItem
                objOItem_Report.GUID = objTreeNode.Name
                objOItem_Report.Name = objTreeNode.Text
                objOItem_Report.GUID_Parent = objLocalConfig.OItem_Class_Reports.GUID
                objOItem_Report.Type = objLocalConfig.Globals.Type_Object


            End If
        End If

        objUserControl_Report.initialize(objOItem_Report)
    End Sub
End Class
