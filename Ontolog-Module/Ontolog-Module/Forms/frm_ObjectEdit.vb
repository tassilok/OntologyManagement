Imports OntologyClasses.BaseClasses

Public Class frm_ObjectEdit
    Private objLocalConfig As clsLocalConfig

    Private objUserControl_TokenEdit As UserControl_ObjectEdit

    Private objOList_Objects As List(Of clsOntologyItem)
    Private objDGVRS As DataGridViewRowCollection
    Private intRowID As Integer

    Private strType As String
    Private objOItem_Direction As clsOntologyItem

    Private strRowName_ID As String
    Private strRowName_Name As String
    Private strRowName_ID_Parent As String

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