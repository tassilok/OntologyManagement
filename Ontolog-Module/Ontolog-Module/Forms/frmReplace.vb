Imports OntologyClasses.BaseClasses

Public Class frmReplace
    Private objLocalConfig As clsLocalConfig

    Private itemList As List(Of clsOntologyItem)

    Private objDBLevel_Save As clsDBLevel

    Private WithEvents objUserControl_Replace As UserControl_Replace
    
    Private sub Replaced Handles objUserControl_Replace.Replaced
        Dim objItemList_NotOk = objUserControl_Replace.ItemList.Where(Function(i) i.Additional1 Is Nothing Or i.Additional1 = "" Or i.Additional1.Length>255 ).ToList()
        
        If not objItemList_NotOk.Any() Then
            ToolStripButton_Ok.Enabled = True
        Else 
            ToolStripButton_Ok.Enabled = False
        End If
    End Sub

    Private sub Initialize()
        objDBLevel_Save = New clsDBLevel(objLocalConfig.Globals)
        objUserControl_Replace = new UserControl_Replace(itemList)
        objUserControl_Replace.Dock = DockStyle.Fill
        ToolStripContainer1.ContentPanel.Controls.Add(objUserControl_Replace)
    End Sub
    Private Sub ToolStripButton_Close_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig, ItemList As List(Of clsOntologyItem))
        ' This call is required by the designer.
        InitializeComponent()
        objLocalConfig = LocalConfig

        Me.itemList = ItemList
        Initialize()
    End Sub

    Public Sub New(Globals As clsGlobals, ItemList As List(Of clsOntologyItem))
        ' This call is required by the designer.
        InitializeComponent()
        objLocalConfig = new clsLocalConfig(Globals)
        Me.itemList = ItemList
        Initialize()
    End Sub

    Private Sub ToolStripButton_Ok_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_Ok.Click
        If objUserControl_Replace.ItemList.Any() Then
            Dim objObjects = objUserControl_Replace.ItemList.Select(Function(o) New clsOntologyItem With {.GUID = o.GUID, _
                                                                                                          .Name = o.Additional1, _
                                                                                                          .GUID_Parent = o.GUID_Parent, _
                                                                                                          .Type = objLocalConfig.Globals.Type_Object}).ToList()
            Dim objOItem_Result = objDBLevel_Save.save_Objects(objObjects)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Die Items konnten nicht geändert werden!", MsgBoxStyle.Exclamation)
            Else 
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If    
        Else 
            MsgBox("Die Itemliste ist leer!", MsgBoxStyle.Exclamation)
        End If
        
    End Sub
End Class