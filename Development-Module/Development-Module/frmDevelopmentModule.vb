Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Security_Module
Public Class frmDevelopmentModule
    Private objLocalConfig As clsLocalConfig

    Private objDataWork_BaseData As clsDataWork_BaseData

    Private WithEvents objUserControl_DevTree As UserControl_DevelopmentTree
    Private WithEvents objUserControl_BaseData As UserControl_BaseData
    Private WithEvents objUserControl_LogEntries As UserControl_LogEntries

    Private objUserControl_OntologyConfig As UserControl_OntologyConfig
    Private objFrm_Authenticate As frmAuthenticate

    Private objOItem_Development As clsOntologyItem

    Private SplashScreen As SplashScreen_OntologyModule
    Private AboutBox As AboutBox_OntologyItem

    Private boolOpen As Boolean = false

    Private Sub selected_DevNode() Handles objUserControl_DevTree.selected_Node
        objOItem_Development = objUserControl_DevTree.OItem_Development
        configure_TabPages()
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()
        Application.DoEvents()
        SplashScreen = New SplashScreen_OntologyModule()
        SplashScreen.Show()
        SplashScreen.Refresh()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals)
        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()

        objFrm_Authenticate = new frmAuthenticate(objLocalConfig.Globals,True,False, frmAuthenticate.ERelateMode.NoRelate)
        objFrm_Authenticate.ShowDialog(Me)
        If objFrm_Authenticate.DialogResult=DialogResult.OK Then
            objLocalConfig.OItem_User = objFrm_Authenticate.OItem_User
            boolOpen = True
            objDataWork_BaseData = new clsDataWork_BaseData(objLocalConfig)

            objUserControl_DevTree = New UserControl_DevelopmentTree(objLocalConfig)
            objUserControl_DevTree.Dock = DockStyle.Fill
            SplitContainer1.Panel1.Controls.Add(objUserControl_DevTree)

            objUserControl_OntologyConfig = New UserControl_OntologyConfig(objLocalConfig)
            objUserControl_OntologyConfig.Dock = DockStyle.Fill
            TabPage_OntologyConfig.Controls.Add(objUserControl_OntologyConfig)

            objUserControl_BaseData = new UserControl_BaseData(objLocalConfig,objDataWork_BaseData)
            objUserControl_BaseData.Dock = DockStyle.Fill
            TabPage_BaseData.Controls.Add(objUserControl_BaseData)

            objUserControl_LogEntries = New UserControl_LogEntries(objLocalConfig)
            objUserControl_LogEntries.Dock = DockStyle.Fill
            TabPage_Logentries.Controls.Add(objUserControl_LogEntries)

            configure_TabPages()
        End If
        
    End Sub


    Private Sub configure_TabPages()
        Select Case TabControl1.SelectedTab.Name
            Case TabPage_BaseData.Name
                objUserControl_BaseData.Initialize_BaseData(objOItem_Development)
            Case TabPage_Logentries.Name
                objUserControl_LogEntries.Initialize_LogEntries(objOItem_Development)
            Case TabPage_OntologyConfig.Name
                objUserControl_OntologyConfig.initialize(objOItem_Development)
        End Select
    End Sub

    Private Sub set_DBConnection()

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        configure_TabPages()
    End Sub

    Private Sub frmDevelopmentModule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not SplashScreen Is Nothing Then
            SplashScreen.Close()
        End If

        If boolOpen = False Then
            Me.Close()
        End If
    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        AboutBox = New AboutBox_OntologyItem
        AboutBox.ShowDialog(Me)
    End Sub
End Class
