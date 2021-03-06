﻿Imports OntologyClasses.BaseClasses

Public Class frmClassEdit
    Private objLocalConfig As clsLocalConfig

    Private WithEvents objUserControl_ClassAttributeType As UserControl_ClassAttributeTypes
    Private WithEvents objUserControl_ClassRel_Forward As UserControl_ClassRel
    Private WithEvents objUserControl_ClassRel_Backward As UserControl_ClassRel
    Private WithEvents objUserControl_ClassRel_OR As UserControl_ClassRel

    Private objFrmGraph As frmGraph

    Private objDBLevel As clsDBLevel

    Private objOItem_Class As clsOntologyItem

    Public ReadOnly Property OItem_Class As clsOntologyItem
        Get
            Return objOItem_Class
        End Get
    End Property

    Public Sub New(ByVal LocalConfig As clsLocalConfig, ByVal oItem_Class As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objOItem_Class = oItem_Class
        objLocalConfig = LocalConfig
        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        objUserControl_ClassAttributeType.Dock = DockStyle.Fill

        SplitContainer1.Panel1.Controls.Add(objUserControl_ClassAttributeType)

        objUserControl_ClassRel_Forward.Dock = DockStyle.Fill

        TabPage_Forward.Controls.Add(objUserControl_ClassRel_Forward)

        objUserControl_ClassRel_Backward.Dock = DockStyle.Fill

        TabPage_Backward.Controls.Add(objUserControl_ClassRel_Backward)

        objUserControl_ClassRel_OR.Dock = DockStyle.Fill

        TabPage_ObjectReferences.Controls.Add(objUserControl_ClassRel_OR)

        ToolStripTextBox_GUID.Text = objOItem_Class.GUID
        ToolStripTextBox_Name.ReadOnly = True
        ToolStripTextBox_Name.Text = objOItem_Class.Name
        ToolStripTextBox_Name.ReadOnly = False


    End Sub

    Private Sub set_DBConnection()
        objUserControl_ClassAttributeType = New UserControl_ClassAttributeTypes(objLocalConfig, objOItem_Class)
        objUserControl_ClassRel_Forward = New UserControl_ClassRel(objLocalConfig, objOItem_Class, objLocalConfig.Globals.Direction_LeftRight, False)
        objUserControl_ClassRel_Backward = New UserControl_ClassRel(objLocalConfig, objOItem_Class, objLocalConfig.Globals.Direction_RightLeft, False)
        objUserControl_ClassRel_OR = New UserControl_ClassRel(objLocalConfig, objOItem_Class, objLocalConfig.Globals.Direction_LeftRight, True)

        objDBLevel = New clsDBLevel(objLocalConfig.Globals)
    End Sub

    Private Sub ToolStripTextBox_Name_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripTextBox_Name.TextChanged
        If ToolStripTextBox_Name.ReadOnly = False Then
            Timer_Name_Changed.Stop()
            Timer_Name_Changed.Start()
        End If
        
        
    End Sub

    Private Sub Timer_Name_Changed_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Name_Changed.Tick
        Timer_Name_Changed.Stop()

        Dim objOItem_Class_Save As New clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        If ToolStripTextBox_Name.Text = "" Then
            MsgBox("Der Name darf nicht leer sein!", MsgBoxStyle.Exclamation)
        Else
            objOItem_Class_Save.GUID = objOItem_Class.GUID
            objOItem_Class_Save.Name = ToolStripTextBox_Name.Text
            objOItem_Class_Save.GUID_Parent = objOItem_Class.GUID_Parent
            objOItem_Class_Save.Type = objOItem_Class_Save.Type

            objOItem_Result = objDBLevel.save_Class(objOItem_Class_Save)
            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                ToolStripTextBox_Name.ReadOnly = True
                ToolStripTextBox_Name.Text = objOItem_Class.Name
                ToolStripTextBox_Name.ReadOnly = False
                MsgBox("Der Name kann nicht geändert werden!", MsgBoxStyle.Exclamation)
            Else
                objOItem_Class.Name = objOItem_Class_Save.Name
                objOItem_Class.GUID_Parent = objOItem_Class_Save.GUID_Parent
            End If
        End If

    End Sub

    Private Sub ToolStripButton_DelClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_DelClass.Click
        Dim oList_Class As New List(Of clsOntologyItem)
        Dim objOItem_Result As clsOntologyItem

        oList_Class.Add(objOItem_Class)
        objOItem_Result = objDBLevel.del_Class(oList_Class)
        Select Case objOItem_Result.GUID
            Case objLocalConfig.Globals.LState_Relation.GUID
                objOItem_Class.deleted = False
                MsgBox("Eine der Klassen hat noch Beziehungen oder Objekte!", MsgBoxStyle.Exclamation)
            Case objLocalConfig.Globals.LState_Error.GUID
                MsgBox("Beim Löschen ist ein Fehler aufgetreten.", MsgBoxStyle.Critical)
                objOItem_Class.deleted = False
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            Case objLocalConfig.Globals.LState_Success.GUID
                If objOItem_Result.Count=0 Then
                    objOItem_Class.deleted = True
                    objOItem_Result = objLocalConfig.Globals.LState_Delete
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                Else 
                    objOItem_Class.deleted = False
                    MsgBox("Eine der Klassen hat noch Beziehungen oder Objekte!", MsgBoxStyle.Exclamation)
                End If
                
        End Select
    End Sub

    Private Sub ToolStripSplitButton_Graph_ButtonClick(sender As Object, e As EventArgs) Handles ToolStripSplitButton_Graph.ButtonClick
        

        objFrmGraph = New frmGraph(objLocalConfig)

        objFrmGraph.Initialize_Lists()
        objFrmGraph.OList_Classes.Add(objOItem_Class)

        If ToolStripMenuItem_ClassAttributes.Checked Then
            objFrmGraph.OList_ClassAtt = objUserControl_ClassAttributeType.OList_ClassAttributes
        End If

        If ClassRelationsforwToolStripMenuItem.Checked Then
            objFrmGraph.OList_Classes.AddRange(From classRel In objUserControl_ClassRel_Forward.OList_ClassRel
                                                Group Join classItem In objFrmGraph.OList_Classes On classRel.ID_Class_Right Equals classItem.GUID Into classItems = Group
                                                From classItem In classItems.DefaultIfEmpty
                                                Where classItem Is Nothing
                                                Select New clsOntologyItem With {.GUID = classRel.ID_Class_Right,
                                                                                 .Name = classRel.Name_Class_Right,
                                                                                 .Type = objLocalConfig.Globals.Type_Class})
                          
            objFrmGraph.OList_ClassRel = objUserControl_ClassRel_Forward.OList_ClassRel
        End If
        If ClassRelationsbackwToolStripMenuItem.Checked Then
            objFrmGraph.OList_Classes.AddRange(From classRel In objUserControl_ClassRel_Backward.OList_ClassRel
                                                Group Join classItem In objFrmGraph.OList_Classes On classRel.ID_Class_Left Equals classItem.GUID Into classItems = Group
                                                From classItem In classItems.DefaultIfEmpty
                                                Where classItem Is Nothing
                                                Select New clsOntologyItem With {.GUID = classRel.ID_Class_Left,
                                                                                 .Name = classRel.Name_Class_Left,
                                                                                 .Type = objLocalConfig.Globals.Type_Class})
            objFrmGraph.OList_ClassRel.AddRange(objUserControl_ClassRel_Backward.OList_ClassRel)
        End If
        If ClassRelationsORToolStripMenuItem.Checked Then
            objFrmGraph.OList_ClassRel.AddRange(objUserControl_ClassRel_OR.OList_ClassRel)
        End If


        objFrmGraph.Initialize_ListGraph()
        objFrmGraph.Show()
    End Sub
End Class