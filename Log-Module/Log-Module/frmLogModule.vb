﻿Imports Ontology_Module
Imports Security_Module
Imports OntologyClasses.BaseClasses

Public Class frmLogModule
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_Save As clsDBLevel
    Private WithEvents objUserControl_LogEntryList As UserControl_OItemList
    Private objUserControl_LogEntry As UserControl_LogEntry
    Private objFrmAuthenticate As frmAuthenticate
    Private objOList_LogEntries_Applied As List(Of clsOntologyItem)
    Private objOItem_Ref As clsOntologyItem
    Private objOItem_ClassOfRef As clsOntologyItem
    
    Private objArgumentParsing As clsArgumentParsing

    Private objRelationConfig As clsRelationConfig

    Private SplashScreen As SplashScreen_OntologyModule
    Private AboutBox As AboutBox_OntologyItem

    Private boolOpen As Boolean
    Private boolApplyable As Boolean

    Public ReadOnly Property OList_LogEntries As List(Of clsOntologyItem)
        Get
            Return objOList_LogEntries_Applied
        End Get
    End Property

    Private sub AddedObjects(OList_Objects As List(Of clsOntologyItem)) Handles objUserControl_LogEntryList.addedSimpleItems
        If Not objOItem_Ref Is Nothing Then
            If objOItem_Ref.Type.ToLower() = objLocalConfig.Globals.Type_Object.ToLower() Then
                If OList_Objects.All(Function(loge) loge.GUID_Parent = objLocalConfig.OItem_Type_LogEntry.GUID) Then
                objOItem_Ref.Type = objLocalConfig.Globals.Type_Object
                Dim oList_SaveRel  = OList_Objects.Select(function(loge) objRelationConfig.Rel_ObjectRelation(loge,objOItem_Ref,objLocalConfig.OItem_RelationType_belongsTo)).ToList()

                If oList_SaveRel.Any() Then
                    Dim objOItem_Result = objDBLevel_Save.save_ObjRel(oList_SaveRel)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        MsgBox("Die Logeinträge konnten nicht mit der Referenz verknüpft werden!", MsgBoxStyle.Exclamation)
                    End If
                End If
            End If
            End If
            
        End If
    End Sub

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

    Private Sub applied_LogEntry() Handles objUserControl_LogEntryList.applied_Items
        Dim boolApply As Boolean

        objOList_LogEntries_Applied = New List(Of clsOntologyItem)

        boolApply = True
        For Each objDGVR As DataGridViewRow In objUserControl_LogEntryList.DataGridViewRowCollection_Selected
            Dim objDRV_Selected As DataRowView = objDGVR.DataBoundItem
            If Not objDRV_Selected.Item("ID_Parent") = objLocalConfig.OItem_Type_LogEntry.GUID Then
                boolApply = False
                Exit For
            Else
                objOList_LogEntries_Applied.Add(New clsOntologyItem With {.GUID = objDRV_Selected.Item("ID_Item"), _
                                                                          .Name = objDRV_Selected.Item("Name"), _
                                                                          .GUID_Parent = objDRV_Selected.Item("ID_Parent"), _
                                                                          .Type = objLocalConfig.Globals.Type_Object})

            End If
        Next

        If boolApply Then
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            objOList_LogEntries_Applied = Nothing
        End If

    End Sub

    Private Sub ToolStripButton_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Public Sub New(Globals As clsGlobals, OItem_User As clsOntologyItem)
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        Application.DoEvents()
        SplashScreen = New SplashScreen_OntologyModule()
        SplashScreen.Show()
        SplashScreen.Refresh()
        boolApplyable = True

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        objLocalConfig.OItem_User = OItem_User
        set_DBConnection()
        initialize()
    End Sub

    Public Sub New()
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        Application.DoEvents()
        SplashScreen = New SplashScreen_OntologyModule()
        SplashScreen.Show()
        SplashScreen.Refresh()
        boolApplyable = False
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals)
        set_DBConnection()
        initialize()

    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        Application.DoEvents()
        SplashScreen = New SplashScreen_OntologyModule()
        SplashScreen.Show()
        SplashScreen.Refresh()
        boolApplyable = True
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        set_DBConnection()
        initialize()

    End Sub

    Private Sub initialize()

        objDBLevel_Save = new clsDBLevel(objLocalConfig.Globals)
        objRelationConfig = new clsRelationConfig(objLocalConfig.Globals)
        objArgumentParsing = new clsArgumentParsing(objLocalConfig.Globals,Environment.GetCommandLineArgs().ToList())

        objUserControl_LogEntryList = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_LogEntryList.Applyable = boolApplyable
        objUserControl_LogEntryList.Dock = DockStyle.Fill
        SplitContainer1.Panel1.Controls.Add(objUserControl_LogEntryList)

        objUserControl_LogEntryList.initialize(New clsOntologyItem(Nothing, _
                                                                   Nothing, _
                                                                   objLocalConfig.OItem_Type_LogEntry.GUID, _
                                                                   objLocalConfig.Globals.Type_Object))

        If objArgumentParsing.OList_Items.Count = 1 Then
            If objArgumentParsing.OList_Items.First().Type.ToLower() = objLocalConfig.Globals.Type_Object.ToLower() Then
                objOItem_Ref = objArgumentParsing.OList_Items.First()
                Dim objDataWork_LogEntry = new clsDataWork_LogEntry(objLocalConfig)
                objOItem_ClassOfRef = objDataWork_LogEntry.GetOItem(objOItem_Ref.GUID_Parent, objLocalConfig.Globals.Type_Class)

                objUserControl_LogEntryList.Initialize_AdvancedFilter(objOItem_ClassOfRef, objOItem_Ref,objLocalConfig.OItem_RelationType_belongsTo, objLocalConfig.Globals.Direction_LeftRight)

            End If
        End If

        objUserControl_LogEntry = New UserControl_LogEntry(objLocalConfig)
        objUserControl_LogEntry.Dock = DockStyle.Fill
        SplitContainer1.Panel2.Controls.Add(objUserControl_LogEntry)

        If objLocalConfig.OItem_User Is Nothing Then
            objFrmAuthenticate = New frmAuthenticate(objLocalConfig.Globals, True, False, frmAuthenticate.ERelateMode.NoRelate, True)
            objFrmAuthenticate.ShowDialog(Me)
            boolOpen = False
            If objFrmAuthenticate.DialogResult = Windows.Forms.DialogResult.OK Then
                objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User
                boolOpen = True

            End If
        Else
            boolOpen = True
        End If
        
    End Sub

    Private Sub set_DBConnection()

    End Sub

    Private Sub frmLogModule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not SplashScreen Is Nothing Then
            SplashScreen.Close()
        End If
        If boolOpen = False Then
            Me.Close()
        Else
            ToolStripTextBox_Database.Text = objLocalConfig.Globals.Index & "@" & objLocalConfig.Globals.Server
        End If

    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        AboutBox = New AboutBox_OntologyItem()
        AboutBox.ShowDialog(Me)
    End Sub
End Class
