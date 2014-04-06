Imports OntologyClasses.BaseClasses
Imports Ontology_Module

Public Class UserControl_MediaItemRelation

    Private objLocalConfig As clsLocalConfig
    Private objOItem_MediaItem As clsOntologyItem
    Private objDataWork_MediaItem As clsDataWork_MediaItem
    Private objUserControl_MediaPlayer As UserControl_MediaPlayer
    Private objFrmOntologyEditor As frmMain
    Private objDBLevel_OItems As clsDBLevel
    Private objControlList As New List(Of clsControlItem)

    Public Sub New(LocalConfig As clsLocalConfig, dataWork_Meditem As clsDataWork_MediaItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objDataWork_MediaItem = dataWork_Meditem
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objDataWork_MediaItem = New clsDataWork_MediaItem(objLocalConfig)

        objUserControl_MediaPlayer = New UserControl_MediaPlayer(objLocalConfig)
        objUserControl_MediaPlayer.Dock = DockStyle.Fill
        TabPage_First_MediaItem.Controls.Add(objUserControl_MediaPlayer)
        objDBLevel_OItems = New clsDBLevel(objLocalConfig.Globals)

    End Sub

    Public Sub Initialize_MediaItem(OItem_MediaItem As clsOntologyItem)
        Dim objOItem_Result = objDataWork_MediaItem.GetDataObjectsOfMediaItem(OItem_MediaItem)

        objOItem_MediaItem = OItem_MediaItem
        Dim objOList_MediaItemObjects = objDataWork_MediaItem.OList_MediaItemObjects(OItem_MediaItem)

        Dim tabPages As New List(Of TabPage)
        For i As Integer = 1 To TabControl_Relations.TabPages.Count - 1

            tabPages.Add(TabControl_Relations.TabPages(i))
        Next

        Dim objOList_MediaItems = objDataWork_MediaItem.get_MediaItem(objOItem_MediaItem)
        If objOList_MediaItems.Any Then

            objUserControl_MediaPlayer.initialize_MediaItem(objOItem_MediaItem, _
                                                            New clsOntologyItem With {.GUID = objOList_MediaItems.First().ID_File, _
                                                                                      .Name = objOList_MediaItems.First().Name_File, _
                                                                                      .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                                                      .Type = objLocalConfig.Globals.Type_Object}, _
                                                            If(objOList_MediaItems.First().OACreate Is Nothing, Now, objOList_MediaItems.First().OACreate.Val_Date), _
                                                            doOpen:=False)
        End If

        tabPages.ForEach(Sub(tp) Clear_TabPage(tp))
        objControlList.Clear()

        Dim objOList_Classes = (From objClass In objOList_MediaItemObjects
                                Where objClass.Type_Ref = objLocalConfig.Globals.Type_Object
                                Group By objClass.ID_Parent_Ref Into Group
                                Select objDBLevel_OItems.GetOItem(ID_Parent_Ref, objLocalConfig.Globals.Type_Class)).ToList()

        objOList_Classes.ForEach(Sub(c) Configure_TabPage(c))
    End Sub

    Private Sub Clear_TabPage(tabPage As TabPage)
        Dim controls = objControlList.Where(Function(ci) ci.TabName = tabPage.Text)
        If controls.Any Then
            controls.First().UserControl_Ref = Nothing
        End If
        tabPage.Controls.Clear()
        TabControl_Relations.TabPages.Remove(tabPage)
        tabPage = Nothing
    End Sub

    Private Sub Configure_TabPage(objOItem_Class As clsOntologyItem)



        Dim objTabPage_New = New TabPage(objOItem_Class.Name)
        Dim objUserControl = New UserControl_ObjectRelationMediaItem(objLocalConfig)
        objUserControl.Dock = DockStyle.Fill
        objTabPage_New.Controls.Add(objUserControl)

        objControlList.Add(New clsControlItem With {.TabName = objOItem_Class.Name, _
                                                    .ClassItem = objOItem_Class, _
                                                    .UserControl_Ref = objUserControl})

        TabControl_Relations.TabPages.Add(objTabPage_New)

    End Sub

    Private Sub ToolStripButton_AddTab_Click(sender As Object, e As EventArgs) Handles ToolStripButton_AddTab.Click
        objFrmOntologyEditor = New frmMain(objLocalConfig.Globals)
        objFrmOntologyEditor.ShowDialog(Me)

        If objFrmOntologyEditor.DialogResult = DialogResult.OK Then
            If objFrmOntologyEditor.Type_Applied = objLocalConfig.Globals.Type_Class Then
                Dim objOList_Classes = objFrmOntologyEditor.OList_Simple
                If objOList_Classes.Count = 1 Then
                    Dim objOItem_Class = objOList_Classes.First()

                    Dim lTabExist = objControlList.Where(Function(cl) cl.TabName = objOItem_Class.Name).ToList()
                    If Not lTabExist.Any() Then
                        Configure_TabPage(objOItem_Class)

                    Else
                        MsgBox("Es existiert bereits ein Tab dieser Klasse!", MsgBoxStyle.Information)
                    End If

                    

                Else
                    MsgBox("Bitte nur eine Klasse auswählen!", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Bitte nur eine Klasse auswählen!", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub Configure_TabPages()


        If Not TabControl_Relations.SelectedTab.Equals(TabPage_First_MediaItem) Then
            Dim selControls = objControlList.Where(Function(cl) cl.TabName = TabControl_Relations.SelectedTab.Text).ToList()
            If selControls.Any() Then
                selControls.First().UserControl_Ref.Initialize_MediaItemObject(objOItem_MediaItem, objDataWork_MediaItem, selControls.First().ClassItem)
            End If
        End If
    End Sub

    Private Sub TabControl_Relations_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl_Relations.SelectedIndexChanged
        Configure_TabPages()
    End Sub
End Class
