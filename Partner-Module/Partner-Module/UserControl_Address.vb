Imports Ontolog_Module
Public Class UserControl_Address
    Private objLocalConfig As clsLocalConfig

    Private objDataWork_Address As clsDataWork_Address
    Private objTransaction_Address As clsTransaction_Address

    Private objOItem_Partner As clsOntologyItem

    Public Sub initialize_Address(ByVal OItem_Partner As clsOntologyItem)
        objOItem_Partner = OItem_Partner


        If objOItem_Partner Is Nothing Then
            clear_Controls()
        Else
            objDataWork_Address.get_Data_Address(objOItem_Partner)
            Timer_Address.Start()
        End If
    End Sub

    Private Sub clear_Controls()
        TextBox_Zusatz.ReadOnly = True
        TextBox_Zusatz.Text = ""
        MaskedTextBox_Postfach.ReadOnly = True
        MaskedTextBox_Postfach.Text = ""
        TextBox_PLZOrtLand.Text = ""
        TextBox_Strasse.ReadOnly = True
        TextBox_Strasse.Text = ""
        Button_addPLZOrtLand.Enabled = False
        Button_DelPLZOrtLand.Enabled = False
        ToolStripButton_Apply.Enabled = False
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDataWork_Address = New clsDataWork_Address(objLocalConfig)
        objTransaction_Address = New clsTransaction_Address(objLocalConfig)
    End Sub

    Private Sub Timer_Address_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Address.Tick
        Dim boolStop As Boolean = True

        If Not objDataWork_Address.Address Is Nothing Then
            If objDataWork_Address.Result_Strasse.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objDataWork_Address.Strasse Is Nothing Then
                    TextBox_Strasse.Text = ""
                Else
                    TextBox_Strasse.Text = objDataWork_Address.Strasse.Val_String
                End If

                TextBox_Strasse.ReadOnly = False
            ElseIf objDataWork_Address.Result_Strasse.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                clear_Controls()
            ElseIf objDataWork_Address.Result_Strasse.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
                boolStop = False
            End If
        End If


        If objDataWork_Address.Result_Zusatz.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDataWork_Address.Zusatz Is Nothing Then
                TextBox_Zusatz.Text = ""
            Else
                TextBox_Zusatz.Text = objDataWork_Address.Zusatz.Val_String
            End If

            TextBox_Zusatz.ReadOnly = False
        ElseIf objDataWork_Address.Result_Zusatz.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            clear_Controls()
        ElseIf objDataWork_Address.Result_Zusatz.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            boolStop = False
        End If

        If objDataWork_Address.Result_PLZOrtLand.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            
            TextBox_PLZOrtLand.Text = objDataWork_Address.PLZOrtLand
            Button_addPLZOrtLand.Enabled = True
            Button_DelPLZOrtLand.Enabled = True

        ElseIf objDataWork_Address.Result_PLZOrtLand.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            clear_Controls()
        ElseIf objDataWork_Address.Result_PLZOrtLand.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            boolStop = False
        End If

        If objDataWork_Address.Result_Postfach.GUID = objLocalConfig.Globals.LState_Success.GUID Then

            If Not objDataWork_Address.Postfach Is Nothing Then
                MaskedTextBox_Postfach.Text = objDataWork_Address.Postfach.Val_String

            Else
                MaskedTextBox_Postfach.Text = ""
            End If
            MaskedTextBox_Postfach.ReadOnly = False
        ElseIf objDataWork_Address.Result_PLZOrtLand.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            clear_Controls()
        ElseIf objDataWork_Address.Result_PLZOrtLand.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            boolStop = False
        End If

        If boolStop = True Then
            Timer_Address.Stop()
            ToolStripProgressBar_Address.Value = 0
        Else
            ToolStripProgressBar_Address.Value = 50
        End If
    End Sub

    Private Sub TextBox_Zusatz_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_Zusatz.TextChanged
        Timer_Zusatz.Stop()
        If TextBox_Zusatz.ReadOnly = False Then
            Timer_Zusatz.Start()
        End If
    End Sub

    Private Sub Timer_Zusatz_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Zusatz.Tick
        Dim strZusatz As String
        Timer_Zusatz.Stop()

        strZusatz = TextBox_Zusatz.Text
        If strZusatz = "" Then
            If Not objDataWork_Address.Zusatz Is Nothing Then
                del_Zusatz()
            End If
        Else
            If Not objDataWork_Address.Zusatz Is Nothing Then
                If strZusatz <> objDataWork_Address.Zusatz.Val_String Then
                    save_Zusatz(strZusatz)
                End If
            Else
                save_Zusatz(strZusatz)
            End If
            
        End If
    End Sub

    Private Sub del_Zusatz()
        Dim objOItem_Result As clsOntologyItem

        objOItem_Result = objTransaction_Address.del_003_Address__Zusatz(objDataWork_Address.Address)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            MsgBox("Beim Löschen ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
            clear_Controls()
        End If
    End Sub

    Private Sub save_Zusatz(ByVal strZusatz As String)
        Dim objOItem_Result As clsOntologyItem

        objOItem_Result = objTransaction_Address.save_003_Address__Zusatz(strZusatz, _
                                                                          objDataWork_Address.Address)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            MsgBox("Beim Speichern ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
            clear_Controls()
        End If
    End Sub
End Class
