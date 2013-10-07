Imports Ontolog_Module
Imports OntologyClasses.BaseClasses
Imports Security_Module
Public Class frmReportModule
    Private cint_ImageID_Root As Integer = 0
    Private cint_ImageID_Report As Integer = 1

    Private objFrm_ObjectEdit As frm_ObjectEdit
    Private WithEvents objUserControl_Report As UserControl_Report

    Private objFrm_Authenticate As frmAuthenticate

    Private objLocalConfig As clsLocalConfig

    Private objDataWork As clsDataWork_ReportTree
    Private objDataWork_ReportFields As clsDataWork_ReportFields
    Private objDataWork_Report As clsDataWork_Report

    Private objTreeNode_Root As TreeNode

    Private boolOpen As Boolean

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals)

        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        
        Dim objOItem_Result = SetUser()
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            fill_Tree()
            configure_Controls()
            boolOpen = True
        ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            boolOpen = False
            MsgBox("Beim Ermitteln des Benutzers ist ein Fehler aufgetreten. Die Anwendung wird geschlossen!", MsgBoxStyle.Exclamation)
        End If
            
        
    End Sub

    Private Function SetUser() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objFrm_Authenticate = New frmAuthenticate(objLocalConfig.Globals, True, False, frmAuthenticate.ERelateMode.NoRelate)
        objFrm_Authenticate.ShowDialog(Me)
        If objFrm_Authenticate.DialogResult = Windows.Forms.DialogResult.OK Then
            If Not objFrm_Authenticate.OItem_User Is Nothing Then
                objLocalConfig.User = objFrm_Authenticate.OItem_User
                objOItem_Result = objLocalConfig.Globals.LState_Success
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Error
            End If
            
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Nothing
        End If


        Return objOItem_Result
    End Function

    Private Sub set_DBConnection()
        objDataWork = New clsDataWork_ReportTree(objLocalConfig)
        objUserControl_Report = New UserControl_Report(objLocalConfig)
        objUserControl_Report.Dock = DockStyle.Fill
        SplitContainer1.Panel2.Controls.Add(objUserControl_Report)
        objDataWork_ReportFields = new clsDataWork_ReportFields(objLocalConfig)
        objDataWork_Report = new clsDataWork_Report(objLocalConfig)
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

    Private Sub TreeView_Report_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TreeView_Report.MouseDoubleClick
        Dim objTreeNode = TreeView_Report.SelectedNode

        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = cint_ImageID_Report Then
                Dim objOList_Reports As New List(Of clsOntologyItem)

                objOList_Reports.Add(New clsOntologyItem With {.GUID = objTreeNode.Name, _
                                                               .Name = objTreeNode.Text, _
                                                               .GUID_Parent = objLocalConfig.OItem_Class_Reports.GUID, _
                                                               .Type = objLocalConfig.Globals.Type_Object})
                objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, objOList_Reports, 0, objLocalConfig.Globals.Type_Object, Nothing)
                objFrm_ObjectEdit.ShowDialog(Me)
            End If
            
        End If



    End Sub

    Private Sub frmReportModule_Load(sender As Object, e As EventArgs) Handles Me.Load
        If boolOpen = False Then
            Me.Close()
        End If
    End Sub

    Private Sub ContextMenuStrip_Reports_Opening( sender As Object,  e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Reports.Opening
        Dim objTreeNode = TreeView_Report.SelectedNode

        GetColumnsToolStripMenuItem.Enabled = False

        If Not objTreeNode is Nothing And objTreeNode.ImageIndex = cint_ImageID_Report Then
            GetColumnsToolStripMenuItem.Enabled = True    
        End If
    End Sub

    Private Sub GetColumnsToolStripMenuItem_Click( sender As Object,  e As EventArgs) Handles GetColumnsToolStripMenuItem.Click
        Dim objTreeNode = TreeView_Report.SelectedNode
        If Not objTreeNode Is Nothing And objTreeNode.ImageIndex = cint_ImageID_Report Then
            Dim objOItem_Report= New clsOntologyItem With {.GUID = objTreeNode.Name, _
                                                           .Name = objTreeNode.Text, _
                                                           .GUID_Parent = objLocalConfig.OItem_Class_Reports.GUID, _
                                                           .Type = objLocalConfig.Globals.Type_Object }
            objDataWork_Report.initialize_Report(objOItem_Report)
            while Not objDataWork_Report.finished_Data_Report

            End While

            If Not objDataWork_Report.Report Is nothing Then
                Dim objOItem_Result = objDataWork_ReportFields.get_ColumnsOfReportMSSQL(objDataWork_Report.Report)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objOItem_Result.Max1 = objOItem_Result.Count Then
                        MsgBox("Die Columns wurden ermittelt!",MsgBoxStyle.Information)
                    Else 
                        MsgBox("Es konnten nur " & objOItem_Result.Count & " von " & objOItem_Result.Max1 & " Columns ermittelt werden!",MsgBoxStyle.Exclamation)
                    End If
                    
                Else 
                    MsgBox("Die Columns konnten nicht ermittelt werden!",MsgBoxStyle.Exclamation)
                End If
            End If
        End If
        
        
    End Sub
End Class
