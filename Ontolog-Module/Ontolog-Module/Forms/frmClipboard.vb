Public Class frmClipboard

    Private objLocalConfig As clsLocalConfig
    Private objOntologyClipboard As clsOntologyClipboard
    Private objOItem_Item As clsOntologyItem

    Private Sub initialize()
        Dim objLClipboard As New List(Of clsObjectRel)
        objLClipboard = objOntologyClipboard.getFromClipboard(objOItem_Item)
        DataGridView_Items.DataSource = objLClipboard
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig, ByVal OItem_Item As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        objOItem_Item = OItem_Item
        set_DBConnection()
        initialize()
    End Sub

    Public Function containedByClipboard() As Boolean
        Dim boolResult As Boolean = False
        Dim objOItem_Result As clsOntologyItem

        objOItem_Result = objOntologyClipboard.containedByClipboard(objOItem_Item)
        If objOItem_Result Is Nothing Then
            boolResult = False
        Else

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objOItem_Result.Count > 0 Then
                    boolResult = True
                Else
                    boolResult = False
                End If
            Else
                Err.Raise(1, "Das Clipboard kann nicht geöffnet werden!")
            End If
        End If
        


        Return boolResult
    End Function

    Public Sub New(ByVal Globals As clsGlobals, ByVal OItem_Item As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        objOItem_Item = OItem_Item
        set_DBConnection()
        initialize()
    End Sub

    Private Sub set_DBConnection()
        objOntologyClipboard = New clsOntologyClipboard(objLocalConfig)
    End Sub

End Class