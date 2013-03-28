Imports Ontolog_Module
Public Class UserControl_LogEntry
    Private objLocalConfig As clsLocalConfig

    Private objOItem_LogEntry As clsOntologyItem

    Private objUserControl_Relations As UserControl_OItemList

    Private objDataWork_LogEntry As clsDataWork_LogEntry

    Private boolEnable As Boolean

    Public Sub initialize_LogEntry(ByVal OItem_LogEntry As clsOntologyItem)
        objOItem_LogEntry = OItem_LogEntry

        clear_LogEntry()

        If objOItem_LogEntry Is Nothing Then
            objDataWork_LogEntry.get_Data_LogState(objOItem_LogEntry)
        Else
            objDataWork_LogEntry.c()
        End If

    End Sub

    Private Sub get_Data()


    End Sub

    Private Sub clear_LogEntry()
        TextBox_Caption.ReadOnly = True
        TextBox_Caption.Clear()
        TextBox_Message.ReadOnly = True
        TextBox_Message.Clear()
        DateTimePicker_DateTimeStamp.Enabled = False
        DateTimePicker_DateTimeStamp.Value = Now
        ComboBox_Logstate.Enabled = False
        ComboBox_Logstate.SelectedItem = Nothing
        ComboBox_User.Enabled = False
        ComboBox_User.SelectedItem = Nothing
        objUserControl_Relations.Enabled = False
        objUserControl_Relations.clear_Relation()
        Button_FromTimestamp.Enabled = False

    End Sub

    Private Sub initialize()
        objUserControl_Relations = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_Relations.Dock = DockStyle.Fill
        Panel_Relations.Controls.Add(objUserControl_Relations)

        objDataWork_LogEntry.get_Data_Combo()

        boolEnable = True

        While objDataWork_LogEntry.OItem_Result_LogStates_Combo.GUID = objLocalConfig.Globals.LState_Nothing.GUID

        End While
        If objDataWork_LogEntry.OItem_Result_LogStates_Combo.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            While objDataWork_LogEntry.OItem_Result_Users_Combo.GUID = objLocalConfig.Globals.LState_Nothing.GUID

            End While
            If objDataWork_LogEntry.OItem_Result_Users_Combo.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                ComboBox_Logstate.DataSource = objDataWork_LogEntry.OList_LogStates
                ComboBox_Logstate.ValueMember = "GUID"
                ComboBox_Logstate.DisplayMember = "Name"

                ComboBox_User.DataSource = objDataWork_LogEntry.OList_Users
                ComboBox_User.ValueMember = "GUID"
                ComboBox_User.DisplayMember = "Name"
            Else
                boolEnable = False
            End If
        Else
            boolEnable = False
        End If

        

        clear_LogEntry()
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        set_DBConnection()
        initialize()
    End Sub

    Private Sub set_DBConnection()
        objDataWork_LogEntry = New clsDataWork_LogEntry(objLocalConfig)
    End Sub

    Private Sub Timer_Data_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Data.Tick

    End Sub
End Class
