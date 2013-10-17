Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class UserControl_LogEntry
    Private objLocalConfig As clsLocalConfig

    Private objOItem_LogEntry As clsOntologyItem

    Private objUserControl_Relations As UserControl_OItemList

    Private objDataWork_LogEntry As clsDataWork_LogEntry
    Private objTransaction_LogEntry As clsTransaction_LogEntry

    Private objOItem_LogState_Standard As clsOntologyItem

    Private boolEnable As Boolean

    Public Sub initialize_LogEntry(ByVal OItem_LogEntry As clsOntologyItem)
        objOItem_LogEntry = OItem_LogEntry

        clear_LogEntry()



        If Not objOItem_LogEntry Is Nothing Then
            TextBox_Caption.Text = objOItem_LogEntry.Name
            TextBox_Caption.ReadOnly = False
            objDataWork_LogEntry.get_Data_LogEntry(objOItem_LogEntry)
            Timer_Data.Start()
        Else
            clear_LogEntry()
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
        objTransaction_LogEntry = New clsTransaction_LogEntry(objLocalConfig)
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
                objDataWork_LogEntry.OList_LogStates.Sort(Function(LS1 As clsOntologyItem, LS2 As clsOntologyItem) LS1.Name.CompareTo(LS2.Name))
                ComboBox_Logstate.DataSource = objDataWork_LogEntry.OList_LogStates
                ComboBox_Logstate.ValueMember = "GUID"
                ComboBox_Logstate.DisplayMember = "Name"

                objDataWork_LogEntry.OList_Users.Sort(Function(U1 As clsOntologyItem, U2 As clsOntologyItem) U1.Name.CompareTo(U2.Name))
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
        Dim boolStop As Boolean
        Dim objOItem_Result As clsOntologyItem

        boolStop = True

        objOItem_Result = objLocalConfig.Globals.LState_Success

        If objDataWork_LogEntry.OItem_Result_LogState.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If Not objDataWork_LogEntry.OItem_LogState Is Nothing Then
                ComboBox_Logstate.SelectedValue = objDataWork_LogEntry.OItem_LogState.GUID
            Else
                If Not objOItem_LogState_Standard Is Nothing Then
                    objOItem_Result = objTransaction_LogEntry.save_002_LogEntry_To_LogState(objOItem_LogState_Standard, objOItem_LogEntry)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objDataWork_LogEntry.OItem_LogState = New clsOntologyItem(objOItem_LogState_Standard.GUID, _
                                                                                  objOItem_LogState_Standard.Name, _
                                                                                  objOItem_LogState_Standard.GUID_Parent, _
                                                                                  objLocalConfig.Globals.Type_Object)
                        ComboBox_Logstate.SelectedValue = objDataWork_LogEntry.OItem_LogState.GUID

                    Else
                        MsgBox("Der Logstate konnte nicht mit dem Logentry verknüpft werden!", MsgBoxStyle.Exclamation)
                        boolStop = True
                    End If
                End If
            End If
            ComboBox_Logstate.Enabled = True
        Else
            boolStop = False
        End If


        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDataWork_LogEntry.OItem_Result_User.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If Not objDataWork_LogEntry.OItem_User Is Nothing Then
                    ComboBox_User.SelectedValue = objDataWork_LogEntry.OItem_User.GUID
                Else
                    objOItem_Result = objTransaction_LogEntry.save_005_LogEntry_To_User(objLocalConfig.OItem_User, objOItem_LogEntry)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objDataWork_LogEntry.OItem_User = New clsOntologyItem(objLocalConfig.OItem_User.GUID, _
                                                                                  objLocalConfig.OItem_User.Name, _
                                                                                  objLocalConfig.OItem_User.GUID_Parent, _
                                                                                  objLocalConfig.Globals.Type_Object)
                        ComboBox_User.SelectedValue = objDataWork_LogEntry.OItem_User.GUID

                    Else
                        MsgBox("Der User konnte nicht mit dem Logentry verknüpft werden!", MsgBoxStyle.Exclamation)
                        boolStop = True
                    End If
                End If
                ComboBox_User.Enabled = True
            Else
                boolStop = False
            End If
        End If


        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDataWork_LogEntry.OItem_Result_DateTimeStamp.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If Not objDataWork_LogEntry.OItem_DateTimeStamp Is Nothing Then
                    DateTimePicker_DateTimeStamp.Value = objDataWork_LogEntry.OItem_DateTimeStamp.Val_Date
                End If
                DateTimePicker_DateTimeStamp.Enabled = True
            Else
                boolStop = False
            End If

            If objDataWork_LogEntry.OItem_Result_Message.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If Not objDataWork_LogEntry.OItem_Message Is Nothing Then
                    TextBox_Message.Text = objDataWork_LogEntry.OItem_Message.Val_String
                End If
                TextBox_Message.ReadOnly = False
            Else
                boolStop = False
            End If
        Else
            clear_LogEntry()
        End If


        If boolStop = True Then

            Timer_Data.Stop()
            ToolStripProgressBar_Data.Value = 0
        Else
            ToolStripProgressBar_Data.Value = 50
        End If
    End Sub


    Private Sub ContextMenuStrip_LogState_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_LogState.Opening
        StandardLogstateToolStripMenuItem.Enabled = False
        OpenObjectEditLogstateToolStripMenuItem.Enabled = False
        If Not ComboBox_Logstate.SelectedItem Is Nothing Then
            StandardLogstateToolStripMenuItem.Enabled = True
            OpenObjectEditLogstateToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub ContextMenuStrip_User_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_User.Opening

        OpenObjectEditUserToolStripMenuItem.Enabled = False
        If Not ComboBox_User.SelectedItem Is Nothing Then
            OpenObjectEditUserToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub StandardLogstateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StandardLogstateToolStripMenuItem.Click
        objOItem_LogState_Standard = Nothing
        If Not ComboBox_Logstate.SelectedItem Is Nothing Then
            objOItem_LogState_Standard = ComboBox_Logstate.SelectedItem
        End If
        ConfigureStandardControls()
    End Sub

    Private Sub ConfigureStandardControls()
        If Not objOItem_LogState_Standard Is Nothing Then
            ToolStripLabel_LogState.Text = objOItem_LogState_Standard.Name
        Else
            ToolStripLabel_LogState.Text = "-"
        End If


        ToolStripLabel_User.Text = objLocalConfig.OItem_User.Name
    End Sub


End Class
