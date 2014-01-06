Imports OntologyClasses.BaseClasses

Public Class frm_ObjectEdit
    Private objLocalConfig As clsLocalConfig

    Private WithEvents objUserControl_TokenEdit As UserControl_ObjectEdit

    Private objDBLevel As clsDBLevel

    Private objOList_Objects As List(Of clsOntologyItem)
    Private objDGVRS As DataGridViewRowCollection
    Private intRowID As Integer

    Private strType As String
    Private objOItem_Direction As clsOntologyItem

    Private strRowName_ID As String
    Private strRowName_Name As String
    Private strRowName_ID_Parent As String

    Private objOItem_Result As clsOntologyItem

    Private Function OItem_Result() As clsOntologyItem
        Return objOItem_Result
    End Function

    Private Sub activated_Object(intRowId As Integer) Handles objUserControl_TokenEdit.ActivatedItem
        Me.intRowID = intRowId
        RefreshClassPath()
    End Sub

    Private Sub deleted_Object() Handles objUserControl_TokenEdit.deleted_Object
        objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()

        Me.Close()
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig, _
                   ByVal oList_Objects As List(Of clsOntologyItem), _
                   ByVal intRowID As Integer, _
                   ByVal Type As String, _
                   ByVal OItem_Direction As clsOntologyItem, _
                   Optional ByVal RowName_ID As String = Nothing, _
                   Optional ByVal RowName_Name As String = Nothing, _
                   Optional ByVal RowName_ID_Parent As String = Nothing)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        objOList_Objects = oList_Objects
        objDGVRS = Nothing

        strType = Type
        objOItem_Direction = OItem_Direction

        Me.intRowID = intRowID

        strRowName_ID = RowName_ID
        strRowName_Name = RowName_Name
        strRowName_ID_Parent = RowName_ID_Parent

        set_DBConnection()
        initialize()
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig, _
                   ByVal objDataGridViewRowCollection As DataGridViewRowCollection, _
                   ByVal intRowID As Integer, _
                   ByVal Type As String, _
                   ByVal OItem_Direction As clsOntologyItem, _
                   Optional ByVal RowName_ID As String = Nothing, _
                   Optional ByVal RowName_Name As String = Nothing, _
                   Optional ByVal RowName_ID_Parent As String = Nothing)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        strType = Type
        objOItem_Direction = OItem_Direction
        objLocalConfig = LocalConfig
        objDGVRS = objDataGridViewRowCollection
        objOList_Objects = Nothing

        Me.intRowID = intRowID

        strRowName_ID = RowName_ID
        strRowName_Name = RowName_Name
        strRowName_ID_Parent = RowName_ID_Parent

        set_DBConnection()
        initialize()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals, _
                   ByVal oList_Objects As List(Of clsOntologyItem), _
                   ByVal intRowID As Integer, _
                   ByVal Type As String, _
                   ByVal OItem_Direction As clsOntologyItem, _
                   Optional ByVal RowName_ID As String = Nothing, _
                   Optional ByVal RowName_Name As String = Nothing, _
                   Optional ByVal RowName_ID_Parent As String = Nothing)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        objOList_Objects = oList_Objects
        objDGVRS = Nothing

        strType = Type
        objOItem_Direction = OItem_Direction

        Me.intRowID = intRowID

        strRowName_ID = RowName_ID
        strRowName_Name = RowName_Name
        strRowName_ID_Parent = RowName_ID_Parent

        set_DBConnection()
        initialize()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals, _
                   ByVal objDataGridViewRowCollection As DataGridViewRowCollection, _
                   ByVal intRowID As Integer, _
                   ByVal Type As String, _
                   ByVal OItem_Direction As clsOntologyItem, _
                   Optional ByVal RowName_ID As String = Nothing, _
                   Optional ByVal RowName_Name As String = Nothing, _
                   Optional ByVal RowName_ID_Parent As String = Nothing)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        strType = Type
        objOItem_Direction = OItem_Direction
        objLocalConfig = New clsLocalConfig(Globals)
        objDGVRS = objDataGridViewRowCollection
        objOList_Objects = Nothing

        Me.intRowID = intRowID

        strRowName_ID = RowName_ID
        strRowName_Name = RowName_Name
        strRowName_ID_Parent = RowName_ID_Parent

        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        Me.Controls.Clear()
        Me.Controls.Add(objUserControl_TokenEdit)
        objDBLevel = New clsDBLevel(objLocalConfig.Globals)
        RefreshClassPath()
    End Sub

    Private Sub RefreshClassPath()
        Dim strPath = ""
        If Not objOList_Objects Is Nothing Then
            Dim objOItem_Object = objOList_Objects(intRowID)

            strPath = objDBLevel.GetClassPath(objOItem_Object)
        Else
            Dim objDGVR As DataGridViewRow = objDGVRS(intRowID)
            Dim objDRV As DataRowView = objDGVR.DataBoundItem

            Dim objOItem_Object = New clsOntologyItem With {.GUID = objDRV.Item(If(strRowName_ID Is Nothing, "ID_Item", strRowName_ID)), _
                                                            .Name = objDRV.Item(If(strRowName_Name Is Nothing, "Name", strRowName_Name)), _
                                                            .GUID_Parent = objDRV.Item(If(strRowName_ID_Parent Is Nothing, "ID_Parent", strRowName_ID_Parent))}
            strPath = objDBLevel.GetClassPath(objOItem_Object)
        End If

        Me.Text = strPath
    End Sub

    Private Sub set_DBConnection()
        If objOList_Objects Is Nothing Then
            objUserControl_TokenEdit = New UserControl_ObjectEdit(objDGVRS, _
                                                                  strType, _
                                                                  objOItem_Direction, _
                                                                  intRowID, _
                                                                  objLocalConfig.Globals, _
                                                                  strRowName_ID, _
                                                                  strRowName_Name, _
                                                                  strRowName_ID_Parent)
        Else
            objUserControl_TokenEdit = New UserControl_ObjectEdit(objOList_Objects, _
                                                                  strType, _
                                                                  objOItem_Direction, _
                                                                  intRowID, _
                                                                  objLocalConfig.Globals, _
                                                                  strRowName_ID, _
                                                                  strRowName_Name, _
                                                                  strRowName_ID_Parent)
        End If

        objUserControl_TokenEdit.Dock = DockStyle.Fill
    End Sub
End Class