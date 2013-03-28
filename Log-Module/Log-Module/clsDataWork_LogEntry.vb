Imports Ontolog_Module
Public Class clsDataWork_LogEntry
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_TimeStamp As clsDBLevel
    Private objDBLevel_Message As clsDBLevel
    Private objDBLevel_LogState_Combo As clsDBLevel
    Private objDBLevel_LogState As clsDBLevel
    Private objDBLevel_User_Combo As clsDBLevel
    Private objDBLevel_User As clsDBLevel

    Private objUserControl_Relations As UserControl_OItemList

    Private objOItem_Result_LogStates_Combo As clsOntologyItem
    Private objOItem_Result_Users_Combo As clsOntologyItem
    Private objOItem_Result_LogState As clsOntologyItem

    Private objThread_LogStates_Combo As Threading.Thread
    Private objThread_Users_Combo As Threading.Thread
    Private objThread_LogState As Threading.Thread

    Private objOItem_LogEntry As clsOntologyItem
    Private objOItem_LogState As clsOntologyItem

    Public ReadOnly Property OItem_Result_LogState As clsOntologyItem
        Get
            Return objOItem_Result_LogState
        End Get
    End Property

    Public ReadOnly Property OItem_Result_LogStates_Combo As clsOntologyItem
        Get
            Return objOItem_Result_LogStates_Combo
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Users_Combo As clsOntologyItem
        Get
            Return objOItem_Result_Users_Combo
        End Get
    End Property

    Public ReadOnly Property OItem_LogState As clsOntologyItem
        Get
            Return objOItem_LogState
        End Get
    End Property

    Public ReadOnly Property OList_LogStates As List(Of clsOntologyItem)
        Get
            Return objDBLevel_LogState_Combo.OList_Objects
        End Get
    End Property

    Public ReadOnly Property OList_Users As List(Of clsOntologyItem)
        Get
            Return objDBLevel_User_Combo.OList_Objects
        End Get
    End Property

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Private Sub get_Data_LogState_Combo()
        Dim objOList_LogStates As New List(Of clsOntologyItem)

        objOList_LogStates.Add(New clsOntologyItem(Nothing, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_type_Logstate.GUID, _
                                                   objLocalConfig.Globals.Type_Object))

        objOItem_Result_LogStates_Combo = objDBLevel_LogState_Combo.get_Data_Objects(objOList_LogStates)

    End Sub

    Private Sub get_Data_User_Combo()
        Dim objOList_Users As New List(Of clsOntologyItem)

        objOList_Users.Add(New clsOntologyItem(Nothing, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_type_User.GUID, _
                                                   objLocalConfig.Globals.Type_Object))

        objOItem_Result_Users_Combo = objDBLevel_LogState_Combo.get_Data_Objects(objOList_Users)

    End Sub

    Public Sub get_Data_Combo()


        objThread_LogStates_Combo = New Threading.Thread(AddressOf get_Data_LogState_Combo)
        objThread_Users_Combo = New Threading.Thread(AddressOf get_Data_User_Combo)

        objOItem_Result_LogStates_Combo = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Users_Combo = objLocalConfig.Globals.LState_Nothing

        objThread_LogStates_Combo.Start()
        objThread_Users_Combo.Start()

    End Sub



    Public Sub get_Data_LogState(ByVal OItem_LogEntry As clsOntologyItem)
        objOItem_LogEntry = OItem_LogEntry

        objThread_LogState = New Threading.Thread(AddressOf get_Data_LogState_Loc)
        objThread_LogState.Start()


    End Sub

    Private Sub get_Data_LogState_Loc()
        Dim objOList_ObjectRel As New List(Of clsObjectRel)

        objOList_ObjectRel.Add(New clsObjectRel(objOItem_LogEntry.GUID, _
                                                Nothing, _
                                                Nothing, _
                                                objLocalConfig.OItem_type_Logstate.GUID, _
                                                objLocalConfig.OItem_RelationType_provides.GUID, _
                                                objLocalConfig.Globals.Type_Object, _
                                                Nothing, _
                                                Nothing))

        objOItem_Result_LogState = objDBLevel_LogState.get_Data_ObjectRel(objOList_ObjectRel, _
                                                                          boolIDs:=False)

        If objDBLevel_LogState.OList_ObjectRel.Count > 0 Then
            objOItem_LogState = New clsOntologyItem
            objOItem_LogState.GUID = objDBLevel_LogState.OList_ObjectRel(0).ID_Other
            objOItem_LogState.Name = objDBLevel_LogState.OList_ObjectRel(0).Name_Other
            objOItem_LogState.GUID_Parent = objLocalConfig.OItem_type_Logstate.GUID
            objOItem_LogState.Type = objLocalConfig.Globals.Type_Object
        Else
            objOItem_LogState = Nothing
        End If
        

    End Sub

    Private Sub set_DBConnection()
        objDBLevel_LogState = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_LogState_Combo = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Message = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_TimeStamp = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_User = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_User_Combo = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
