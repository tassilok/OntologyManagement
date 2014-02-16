Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Structure_Module
Public Class UserControl_Address
    Private objLocalConfig As clsLocalConfig

    Private objDataWork_Address As clsDataWork_Address
    Private objTransaction_Address As clsTransaction_Address
    Private objTransaction As clsTransaction
    Private objRelationConfig As clsRelationConfig

    Private objFrm_PLZOrtLand As frmPLZOrtLand
    Private objFrm_Name As frm_Name

    Private objFrm_ObjectEdit As frm_ObjectEdit

    Private objUserControl_Contact As UserControl_OItemList

    Private objFrmAddressZusatz As frm_AdressZusatz

    Private objOItem_Partner As clsOntologyItem

    Private objOList_Zusaetze As SortableBindingList(Of clsAdderesszusatz)

    Public Sub initialize_Address(ByVal OItem_Partner As clsOntologyItem)
        objOItem_Partner = OItem_Partner


        If objOItem_Partner Is Nothing Then
            clear_Controls()
        Else
            objDataWork_Address.get_Data_Address(objOItem_Partner)
            Timer_Address.Start()
        End If
    End Sub

    Public Sub initialize_Address(ByVal OItem_Partner As clsOntologyItem, OItem_Address As clsOntologyItem)
        objOItem_Partner = OItem_Address

        objDataWork_Address.get_Data_Address(objOItem_Partner, OItem_Address)
        Timer_Address.Start()
    End Sub

    Public Sub clear_Controls()
        Button_AddZusatz.Enabled = False
        Button_DelZusatz.Enabled = False
        DataGridView_Adresszusatz.Enabled = False
        DataGridView_Adresszusatz.DataSource = Nothing
        TextBox_Postfach.ReadOnly = True
        TextBox_Postfach.Text = ""
        TextBox_PLZOrtLand.Text = ""
        TextBox_Strasse.ReadOnly = True
        TextBox_Strasse.Text = ""
        Button_addPLZOrtLand.Enabled = False
        Button_DelPLZOrtLand.Enabled = False
        ToolStripButton_Apply.Enabled = False
        objUserControl_Contact.clear_Relation()
        objUserControl_Contact.Enabled = False

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

        objUserControl_Contact = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_Contact.Dock = DockStyle.Fill
        Panel_Kontakt.Controls.Add(objUserControl_Contact)
    End Sub

    Private Sub Timer_Address_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Address.Tick
        Dim boolStop As Boolean = True

        If Not objDataWork_Address.Address Is Nothing Then
            objUserControl_Contact.initialize(Nothing, _
                                              objDataWork_Address.Address, _
                                              objLocalConfig.Globals.Direction_LeftRight, _
                                              New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Class_Partner.GUID, .Type = objLocalConfig.Globals.Type_Object}, _
                                              objLocalConfig.OItem_RelationType_belonging)
            objUserControl_Contact.Enabled = True
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
            objOList_Zusaetze = New SortableBindingList(Of clsAdderesszusatz)(objDataWork_Address.Zusaetze)

            DataGridView_Adresszusatz.DataSource = objOList_Zusaetze
            DataGridView_Adresszusatz.Columns(0).Visible = False
            DataGridView_Adresszusatz.Columns(2).Visible = False
            DataGridView_Adresszusatz.Enabled = True

            DataGridView_Adresszusatz.Enabled = True
            Button_AddZusatz.Enabled = True
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

    Private Sub TextBox_Zusatz_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        'If TextBox_Strasse.ReadOnly = False Then
        '    objFrm_Name = New frm_Name(objLocalConfig.OItem_Attribute_Straße.Name, objLocalConfig.Globals, Value1:=TextBox_Zusatz.Text)
        '    objFrm_Name.ShowDialog(Me)

        '    If objFrm_Name.DialogResult = DialogResult.OK Then
        '        TextBox_Zusatz.Text = objFrm_Name.Value1
        '    End If
        'End If
    End Sub

    'Private Sub TextBox_Zusatz_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Timer_Zusatz.Stop()
    '    If TextBox_Zusatz.ReadOnly = False Then
    '        Timer_Zusatz.Start()
    '    End If
    'End Sub

    'Private Sub Timer_Zusatz_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Zusatz.Tick
    '    Dim strZusatz As String
    '    Timer_Zusatz.Stop()

    '    strZusatz = TextBox_Zusatz.Text
    '    If strZusatz = "" Then
    '        If Not objDataWork_Address.Zusatz Is Nothing Then
    '            del_Zusatz()
    '        End If
    '    Else
    '        If Not objDataWork_Address.Zusatz Is Nothing Then
    '            If strZusatz <> objDataWork_Address.Zusatz.Val_String Then
    '                save_Zusatz(strZusatz)
    '            End If
    '        Else
    '            save_Zusatz(strZusatz)
    '        End If

    '    End If
    'End Sub

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

    Private Sub DataGridView_Adresszusatz_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView_Adresszusatz.SelectionChanged
        Button_DelZusatz.Enabled = False
        If DataGridView_Adresszusatz.SelectedRows.Count > 0 Then
            Button_DelZusatz.Enabled = True
        End If
    End Sub

    Private Sub Button_DelZusatz_Click(sender As Object, e As EventArgs) Handles Button_DelZusatz.Click

        objTransaction.ClearItems()
        For Each objDGVR_Selected As DataGridViewRow In DataGridView_Adresszusatz.SelectedRows
            Dim objAddressZusatz = CType(objDGVR_Selected.DataBoundItem, clsAdderesszusatz)

            Dim objORel_AddressZusatz_To_Type = New clsObjectRel With {.ID_Object = objAddressZusatz.ID_AdressZusatz, _
                                                              .ID_Other = objAddressZusatz.ID_ZusatzTyp, _
                                                              .ID_RelationType = objLocalConfig.OItem_relationtype_is_of_type.GUID}

            Dim objOItem_Result = objTransaction.do_Transaction(objORel_AddressZusatz_To_Type, False, True)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                Dim objORel_Address_To_Zusatz = New clsObjectRel With {.ID_Object = objDataWork_Address.Address.GUID, _
                                                              .ID_Other = objAddressZusatz.ID_AdressZusatz, _
                                                              .ID_RelationType = objLocalConfig.OItem_RelationType_belonging.GUID}

            Else
                MsgBox("Nicht alle Adresszusätze konnten gelöscht werden!", MsgBoxStyle.Exclamation)
                Exit For
            End If
            

        Next

        
    End Sub

    Private Sub Button_AddZusatz_Click(sender As Object, e As EventArgs) Handles Button_AddZusatz.Click
        objFrmAddressZusatz = New frm_AdressZusatz(objLocalConfig, objDataWork_Address)
        objFrmAddressZusatz.ShowDialog(Me)
        If objFrmAddressZusatz.DialogResult = DialogResult.OK Then
            GetZusaetze()
        End If
    End Sub

    Private Sub DataGridView_Adresszusatz_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_Adresszusatz.RowHeaderMouseDoubleClick
        Dim objDGVR_Selected = DataGridView_Adresszusatz.Rows(e.RowIndex)
        Dim objAddrssZusatz As clsAdderesszusatz = objDGVR_Selected.DataBoundItem

        Dim objOList_Objects = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID = objAddrssZusatz.ID_AdressZusatz, _
                                                                                             .Name = objAddrssZusatz.Name_AdressZusatz, _
                                                                                             .GUID_Parent = objLocalConfig.OItem_class_adress_zusatz.GUID, _
                                                                                             .Type = objLocalConfig.Globals.Type_Object}}

        objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, objOList_Objects, 0, objLocalConfig.Globals.Type_Object, Nothing)
        objFrm_ObjectEdit.ShowDialog(Me)
        objDataWork_Address.get_Data_Zusatz()
        If objDataWork_Address.Result_Zusatz.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOList_Zusaetze = New SortableBindingList(Of clsAdderesszusatz)(objDataWork_Address.Zusaetze)

            DataGridView_Adresszusatz.DataSource = objOList_Zusaetze
            DataGridView_Adresszusatz.Columns(0).Visible = False
            DataGridView_Adresszusatz.Columns(2).Visible = False
            DataGridView_Adresszusatz.Enabled = True

        ElseIf objDataWork_Address.Result_Zusatz.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            clear_Controls()
            MsgBox("Die Zusätze können nicht ermittelt werden!", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub GetZusaetze()
        objOList_Zusaetze = New SortableBindingList(Of clsAdderesszusatz)(objDataWork_Address.Zusaetze)

        DataGridView_Adresszusatz.DataSource = objOList_Zusaetze
        DataGridView_Adresszusatz.Columns(0).Visible = False
        DataGridView_Adresszusatz.Columns(2).Visible = False
        DataGridView_Adresszusatz.Enabled = True

        DataGridView_Adresszusatz.Enabled = True
        Button_AddZusatz.Enabled = True
    End Sub
End Class
