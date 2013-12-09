Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class UserControl_Address
    Private objLocalConfig As clsLocalConfig

    Private objDataWork_Address As clsDataWork_Address
    Private objTransaction_Address As clsTransaction_Address
    Private objTransaction As clsTransaction
    Private objRelationConfig As clsRelationConfig

    Private objFrm_PLZOrtLand As frmPLZOrtLand
    Private objFrm_Name As frm_Name

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

    Public Sub clear_Controls()
        TextBox_Zusatz.ReadOnly = True
        TextBox_Zusatz.Text = ""
        TextBox_Postfach.ReadOnly = True
        TextBox_Postfach.Text = ""
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

    Public Sub New(Globals As clsGlobals)
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDataWork_Address = New clsDataWork_Address(objLocalConfig)
        objTransaction_Address = New clsTransaction_Address(objLocalConfig)
        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
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
                TextBox_Postfach.Text = objDataWork_Address.Postfach.Val_String

            Else
                TextBox_Postfach.Text = ""
            End If
            TextBox_Postfach.ReadOnly = False
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

    Private Sub TextBox_Zusatz_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox_Zusatz.MouseDoubleClick
        If TextBox_Strasse.ReadOnly = False Then
            objFrm_Name = New frm_Name(objLocalConfig.OItem_Attribute_Straße.Name, objLocalConfig.Globals, Value1:=TextBox_Zusatz.Text)
            objFrm_Name.ShowDialog(Me)

            If objFrm_Name.DialogResult = DialogResult.OK Then
                TextBox_Zusatz.Text = objFrm_Name.Value1
            End If
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

    Private Sub TextBox_Strasse_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox_Strasse.MouseDoubleClick

        If TextBox_Strasse.ReadOnly = False Then
            objFrm_Name = New frm_Name(objLocalConfig.OItem_Attribute_Straße.Name, objLocalConfig.Globals, Value1:=TextBox_Strasse.Text)
            objFrm_Name.ShowDialog(Me)

            If objFrm_Name.DialogResult = DialogResult.OK Then
                TextBox_Strasse.Text = objFrm_Name.Value1
            End If
        End If
        
    End Sub

    Private Sub TextBox_Strasse_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_Strasse.TextChanged
        Timer_Strasse.Stop()
        If TextBox_Strasse.ReadOnly = False Then
            Timer_Strasse.Start()
        End If
    End Sub

    Private Sub Timer_Strasse_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Strasse.Tick
        Dim strStrasse As String
        Timer_Strasse.Stop()

        strStrasse = TextBox_Strasse.Text
        If strStrasse = "" Then
            If Not objDataWork_Address.Strasse Is Nothing Then
                del_Strasse()
            End If
        Else
            If Not objDataWork_Address.Strasse Is Nothing Then
                If strStrasse <> objDataWork_Address.Strasse.Val_String Then
                    save_Strasse(strStrasse)
                End If
            Else
                save_Strasse(strStrasse)
            End If

        End If
    End Sub

    Private Sub del_Strasse()
        Dim objOItem_Result As clsOntologyItem

        objOItem_Result = objTransaction_Address.del_004_Address__Strasse(objDataWork_Address.Address)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            MsgBox("Beim Löschen ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
            clear_Controls()
        End If
    End Sub

    Private Sub save_Strasse(ByVal strStrasse As String)
        Dim objOItem_Result As clsOntologyItem

        objOItem_Result = objTransaction_Address.save_004_Address__Strasse(strStrasse, _
                                                                          objDataWork_Address.Address)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            MsgBox("Beim Speichern ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
            clear_Controls()
        End If
    End Sub

    Private Sub Timer_Postfach_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Postfach.Tick
        Dim strPostfach As String
        Timer_Postfach.Stop()

        strPostfach = TextBox_Postfach.Text
        If strPostfach = "" Then
            If Not objDataWork_Address.Postfach Is Nothing Then
                del_Postfach()
            End If
        Else
            If Not objDataWork_Address.Postfach Is Nothing Then
                If strPostfach <> objDataWork_Address.Postfach.Val_String Then
                    save_Postfach(strPostfach)
                End If
            Else
                save_Postfach(strPostfach)
            End If

        End If
    End Sub

    Private Sub del_Postfach()
        Dim objOItem_Result As clsOntologyItem

        objOItem_Result = objTransaction_Address.del_005_Address__Postfach(objDataWork_Address.Address)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            MsgBox("Beim Löschen ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
            clear_Controls()
        End If
    End Sub

    Private Sub save_Postfach(ByVal strPostfach As String)
        Dim objOItem_Result As clsOntologyItem

        objOItem_Result = objTransaction_Address.save_005_Address__Postfach(strPostfach, _
                                                                          objDataWork_Address.Address)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            MsgBox("Beim Speichern ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
            clear_Controls()
        End If
    End Sub

    Private Sub TextBox_Postfach_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox_Postfach.MouseDoubleClick
        If TextBox_Postfach.ReadOnly = False Then
            objFrm_Name = New frm_Name(objLocalConfig.OItem_Attribute_Straße.Name, objLocalConfig.Globals, Value1:=TextBox_Postfach.Text)
            objFrm_Name.ShowDialog(Me)

            If objFrm_Name.DialogResult = DialogResult.OK Then
                TextBox_Postfach.Text = objFrm_Name.Value1
            End If
        End If
    End Sub

    Private Sub TextBox_Postfach_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_Postfach.TextChanged
        Timer_Postfach.Stop()
        If TextBox_Postfach.ReadOnly = False Then
            Timer_Postfach.Start()
        End If
    End Sub

    Private Sub Button_addPLZOrtLand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_addPLZOrtLand.Click
        Dim objOItem_Ort As clsOntologyItem
        Dim objOItem_PLZ As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objFrm_PLZOrtLand = New frmPLZOrtLand(objLocalConfig, objDataWork_Address)
        objFrm_PLZOrtLand.ShowDialog(Me)
        If objFrm_PLZOrtLand.DialogResult = DialogResult.OK Then
            objOItem_Ort = objFrm_PLZOrtLand.OItem_Ort
            objOItem_PLZ = objFrm_PLZOrtLand.OItem_PLZ
            objTransaction.ClearItems()
            Dim objORel_Address_To_Plz = objRelationConfig.Rel_ObjectRelation(objDataWork_Address.Address, objOItem_PLZ, objLocalConfig.OItem_RelationType_located_in)

            objOItem_Result = objTransaction.do_Transaction(objORel_Address_To_Plz, True)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                Dim objORel_Address_To_Ort = objRelationConfig.Rel_ObjectRelation(objDataWork_Address.Address, objOItem_Ort, objLocalConfig.OItem_RelationType_located_in)
                objOItem_Result = objTransaction.do_Transaction(objORel_Address_To_Ort, True)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    initialize_Address(objOItem_Partner)
                Else
                    MsgBox("Die Ort konnte nicht gespeichert werden!", MsgBoxStyle.Exclamation)
                End If
            Else
                MsgBox("Die Postleitzahl konnte nicht gespeichert werden!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub Button_DelPLZOrtLand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_DelPLZOrtLand.Click
        Dim objOItem_Result_PLZ As clsOntologyItem
        Dim objOItem_Result_Ort As clsOntologyItem
        If MsgBox("Sollen Postleizahl und Ort wirklich gelöscht werden?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            objOItem_Result_Ort = objTransaction_Address.del_007_Address_To_Ort(objDataWork_Address.Address)
            objOItem_Result_PLZ = objTransaction_Address.del_006_Address_To_PLZ(objDataWork_Address.Address)
            If Not objOItem_Result_PLZ.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                MsgBox("Die Postleitzahl konnte nicht gelöscht werden!", MsgBoxStyle.Exclamation)
            Else
                If Not objOItem_Result_Ort.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    MsgBox("Der Ort konnte nicht gelöscht werden!", MsgBoxStyle.Exclamation)
                End If
            End If

            initialize_Address(objOItem_Partner)
        End If
    End Sub
End Class
