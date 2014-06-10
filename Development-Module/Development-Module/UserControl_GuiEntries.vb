Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class UserControl_GuiEntries

    Private objLocalConfig As clsLocalConfig

    Private objDataWork_GuiEntries As clsDataWork_GuiEntries

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        Initialize()
    End Sub

    Private Sub Initialize()
        objDataWork_GuiEntries = New clsDataWork_GuiEntries(objLocalConfig)


    End Sub

    Public Sub Initialize_GuiEntries(OItem_Development As clsOntologyItem)
        TreeView_GuiEntries.Nodes.Clear()


        If (Not OItem_Development Is Nothing) Then
            Dim objTreeNode_Root = TreeView_GuiEntries.Nodes.Add(OItem_Development.GUID, OItem_Development.Name, objLocalConfig.ImageID_Root, objLocalConfig.ImageID_Root)

            Dim objOItem_Result = objDataWork_GuiEntries.CreateSubNodes(OItem_Development, objTreeNode_Root)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Die Gui-Elemente konnten nicht ermittelt werden!", MsgBoxStyle.Exclamation)
            End If
        End If

    End Sub
End Class
