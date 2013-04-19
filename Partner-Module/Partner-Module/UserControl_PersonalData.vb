Imports Ontolog_Module
Imports Media_Viewer_Module
Public Class UserControl_PersonalData
    Private objLocalConfig As clsLocalConfig
    Private WithEvents objUserControl_ImageList As UserControl_ImageList
    Private WithEvents objUserControl_SingleViewer As UserControl_SingleViewer
    Private objDataWork_PersonalData As clsDataWork_PersonalData

    Private objTransaction_PersonalData As clsTransaction_PersonalData

    Private objOItem_Partner As clsOntologyItem
    Private objOItem_PersonalData As clsOntologyItem

    Private objOItem_Sozialversicherungsnummer As clsOntologyItem
    Private objOItem_eTin As clsOntologyItem
    Private objOItem_iNr As clsOntologyItem
    Private objOItem_SteuerNr As clsOntologyItem

    Private Sub image_MoveFirst() Handles objUserControl_SingleViewer.Media_First
        objUserControl_ImageList.Media_First()
    End Sub

    Private Sub image_MovePrevious() Handles objUserControl_SingleViewer.Media_Previous
        objUserControl_ImageList.Media_Previous()
    End Sub

    Private Sub image_MoveNext() Handles objUserControl_SingleViewer.Media_Next
        objUserControl_ImageList.Media_Next()
    End Sub

    Private Sub image_MoveLast() Handles objUserControl_SingleViewer.Media_Last
        objUserControl_ImageList.Media_Previous()
    End Sub

    Private Sub selected_Image(ByVal OItem_Image As clsOntologyItem, ByVal OItem_File As clsOntologyItem, ByVal dateCreated As Date) Handles objUserControl_ImageList.selected_Image
        objUserControl_SingleViewer.initialize_Image(OItem_Image, OItem_File, dateCreated)
        objUserControl_SingleViewer.isPossible_Next = objUserControl_ImageList.isPossible_Next
        objUserControl_SingleViewer.isPossible_Previous = objUserControl_ImageList.isPossible_Previous
    End Sub

    Public Sub initialize_PersonalData(ByVal OItem_Partner As clsOntologyItem)
        Dim objOItem_Result As clsOntologyItem
        objOItem_Partner = OItem_Partner
        objOItem_PersonalData = Nothing
        objUserControl_SingleViewer.clear_Media()
        objUserControl_ImageList.clear_List()

        If Not objOItem_Partner Is Nothing Then
            objOItem_Result = objDataWork_PersonalData.get_Data_personal(objOItem_Partner)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objOItem_PersonalData = objDataWork_PersonalData.OItem_PersonalData
                Timer_Data.Start()

                objUserControl_ImageList.initialize_Images(objDataWork_PersonalData.OItem_PersonalData, True)
                objUserControl_ImageList.Enabled = True
                objUserControl_SingleViewer.Enabled = True
            Else

                MsgBox("Beim Ermitteln der Daten ist ein Fehler unterlaufen!", MsgBoxStyle.Exclamation)
                clear_Controls()
            End If
        Else
            clear_Controls()
        End If

    End Sub

    Private Sub clear_Controls()
        TextBox_eTin.ReadOnly = True
        TextBox_Identifikationsnummer.ReadOnly = True
        TextBox_Nachname.ReadOnly = True
        TextBox_Sozialversicherungsnummer.ReadOnly = True
        TextBox_Steuernummer.ReadOnly = True
        TextBox_Vorname.ReadOnly = True

        ComboBox_Familienstand.Enabled = False
        ComboBox_Geschlecht.Enabled = False

        objUserControl_ImageList.Enabled = False
        objUserControl_SingleViewer.Enabled = False

        Button_Del_eTin.Enabled = False
        Button_Del_Geburtsdatum.Enabled = False
        Button_Del_INr.Enabled = False
        Button_Del_Sozialversicherungsnummer.Enabled = False
        Button_Del_Steuernummer.Enabled = False
        Button_Del_Todesdatum.Enabled = False

        Button_eTin.Enabled = False
        Button_Geburtsdatum.Enabled = False
        Button_INr.Enabled = False
        Button_Sozialversicherungsnummer.Enabled = False
        Button_Todesdatum.Enabled = False
        Button_Steuernummer.Enabled = False

        TextBox_Vorname.Text = ""
        TextBox_Nachname.Text = ""
        MaskedTextBox_Geburtsdatum.Text = ""
        MaskedTextBox_Todesdatum.Text = ""
        TextBox_Sozialversicherungsnummer.Text = ""
        TextBox_Steuernummer.Text = ""
        TextBox_Identifikationsnummer.Text = ""


        ComboBox_Familienstand.SelectedItem = Nothing
        ComboBox_Geschlecht.SelectedItem = Nothing

        
    End Sub

    Private Sub initialize()

        ComboBox_Familienstand.Enabled = False
        ComboBox_Familienstand.DataSource = objLocalConfig.OList_Familienstand
        ComboBox_Familienstand.ValueMember = "GUID"
        ComboBox_Familienstand.DisplayMember = "Name"
        ComboBox_Familienstand.SelectedItem = Nothing

        ComboBox_Geschlecht.Enabled = False
        ComboBox_Geschlecht.DataSource = objLocalConfig.OList_Geschlecht
        ComboBox_Geschlecht.ValueMember = "GUID"
        ComboBox_Geschlecht.DisplayMember = "Name"
        ComboBox_Geschlecht.SelectedItem = Nothing

        objUserControl_ImageList = New UserControl_ImageList(objLocalConfig.Globals)
        objUserControl_ImageList.Dock = DockStyle.Fill
        Panel_ImageList.Controls.Add(objUserControl_ImageList)

        objUserControl_SingleViewer = New UserControl_SingleViewer(objLocalConfig.Globals, objLocalConfig.OItem_Class_Images__Graphic_)
        objUserControl_SingleViewer.Dock = DockStyle.Fill
        Panel_ImageView.Controls.Add(objUserControl_SingleViewer)

        objDataWork_PersonalData = New clsDataWork_PersonalData(objLocalConfig)

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
        objTransaction_PersonalData = New clsTransaction_PersonalData(objLocalConfig)
    End Sub

    Private Sub Timer_Vorname_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Vorname.Tick
        Dim objOItem_Result As clsOntologyItem

        Timer_Vorname.Stop()

        If Not objOItem_PersonalData Is Nothing Then
            If Not TextBox_Vorname.Text = "" Then

            Else
                objOItem_Result = objTransaction_PersonalData.del_003_PersonalData__Vorname(objOItem_PersonalData)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    MsgBox("Der Vorname kann nicht geändert werden!", MsgBoxStyle.Exclamation)
                    initialize_PersonalData(objOItem_Partner)
                End If
            End If
        End If
        
    End Sub

    Private Sub TextBox_Vorname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_Vorname.TextChanged
        If TextBox_Vorname.ReadOnly = False Then
            Timer_Vorname.Start()
        End If
    End Sub

    Private Sub Timer_Data_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Data.Tick
        Dim boolStop As Boolean = True


        If objDataWork_PersonalData.OItem_Result_Data_Ref.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLGeschlecht = From obj In objDataWork_PersonalData.OList_Ref
                                 Where obj.ID_Parent_Other = objLocalConfig.OItem_Class_Geschlecht.GUID


            If objLGeschlecht.Count > 0 Then
                ComboBox_Geschlecht.Enabled = False
                ComboBox_Geschlecht.SelectedValue = objLGeschlecht(0).ID_Other
                ComboBox_Geschlecht.Enabled = True
            End If

            Dim objLFamilienstand = From obj In objDataWork_PersonalData.OList_Ref
                                    Where obj.ID_Parent_Other = objLocalConfig.OItem_Class_Familienstand.GUID

            If objLFamilienstand.Count > 0 Then
                ComboBox_Familienstand.Enabled = False
                ComboBox_Familienstand.SelectedValue = objLFamilienstand(0).ID_Other
                ComboBox_Familienstand.Enabled = True
            End If

            Dim objLSozialversicherungsnummer = From obj In objDataWork_PersonalData.OList_Ref
                                                Where obj.ID_Parent_Other = objLocalConfig.OItem_Class_Sozialversicherungsnummer.GUID

            If objLSozialversicherungsnummer.Count > 0 Then
                objOItem_Sozialversicherungsnummer = New clsOntologyItem(objLSozialversicherungsnummer(0).ID_Other, _
                                                                         objLSozialversicherungsnummer(0).Name_Other, _
                                                                         objLSozialversicherungsnummer(0).ID_Parent_Other, _
                                                                         objLocalConfig.Globals.Type_Object)

                TextBox_Sozialversicherungsnummer.Text = objOItem_Sozialversicherungsnummer.Name
            Else
                objOItem_Sozialversicherungsnummer = Nothing
                TextBox_Sozialversicherungsnummer.Text = ""
            End If

            Button_Sozialversicherungsnummer.Enabled = True
            Button_Del_Sozialversicherungsnummer.Enabled = True


            Dim objLeTin = From obj In objDataWork_PersonalData.OList_Ref
                                                Where obj.ID_Parent_Other = objLocalConfig.OItem_Class_eTin.GUID

            If objLeTin.Count > 0 Then
                objOItem_eTin = New clsOntologyItem(objLeTin(0).ID_Other, _
                                                                         objLeTin(0).Name_Other, _
                                                                         objLeTin(0).ID_Parent_Other, _
                                                                         objLocalConfig.Globals.Type_Object)

                TextBox_eTin.Text = objOItem_eTin.Name
            Else
                objOItem_eTin = Nothing
                TextBox_eTin.Text = ""
            End If

            Button_eTin.Enabled = True
            Button_Del_eTin.Enabled = True

            Dim objLiNr = From obj In objDataWork_PersonalData.OList_Ref
                                                Where obj.ID_Parent_Other = objLocalConfig.OItem_Class_Identifkationsnummer__IdNr_.GUID

            If objLiNr.Count > 0 Then
                objOItem_iNr = New clsOntologyItem(objLiNr(0).ID_Other, _
                                                                         objLiNr(0).Name_Other, _
                                                                         objLiNr(0).ID_Parent_Other, _
                                                                         objLocalConfig.Globals.Type_Object)

                TextBox_Identifikationsnummer.Text = objOItem_iNr.Name
            Else
                objOItem_iNr = Nothing
                TextBox_Identifikationsnummer.Text = ""
            End If

            Button_INr.Enabled = True
            Button_Del_INr.Enabled = True

            Dim objLStNr = From obj In objDataWork_PersonalData.OList_Ref
                                                Where obj.ID_Parent_Other = objLocalConfig.OItem_Class_Steuernummer.GUID

            If objLStNr.Count > 0 Then
                objOItem_SteuerNr = New clsOntologyItem(objLStNr(0).ID_Other, _
                                                                         objLStNr(0).Name_Other, _
                                                                         objLStNr(0).ID_Parent_Other, _
                                                                         objLocalConfig.Globals.Type_Object)

                TextBox_Steuernummer.Text = objOItem_SteuerNr.Name
            Else
                objOItem_SteuerNr = Nothing
                TextBox_Identifikationsnummer.Text = ""
            End If

            Button_Steuernummer.Enabled = True
            Button_Del_Steuernummer.Enabled = True
        Else

            boolStop = False
        End If


        If objDataWork_PersonalData.OItem_Result_Data_Att.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLVorname = From obj In objDataWork_PersonalData.OList_Att
                              Where obj.ID_AttributeType = objLocalConfig.OItem_Attribute_Vorname.GUID

            If objLVorname.Count > 0 Then
                TextBox_Vorname.ReadOnly = True
                TextBox_Vorname.Text = objLVorname(0).Val_String
                TextBox_Vorname.ReadOnly = False
            Else
                TextBox_Vorname.ReadOnly = True
                TextBox_Vorname.Text = ""
                TextBox_Vorname.ReadOnly = False
            End If

            Dim objLNachname = From obj In objDataWork_PersonalData.OList_Att
                              Where obj.ID_AttributeType = objLocalConfig.OItem_Attribute_Nachname.GUID

            If objLNachname.Count > 0 Then
                TextBox_Nachname.ReadOnly = True
                TextBox_Nachname.Text = objLNachname(0).Val_String
                TextBox_Nachname.ReadOnly = False
            Else
                TextBox_Nachname.ReadOnly = True
                TextBox_Nachname.Text = ""
                TextBox_Nachname.ReadOnly = False
            End If

            Dim objLGeburtsdatum = From obj In objDataWork_PersonalData.OList_Att
                              Where obj.ID_AttributeType = objLocalConfig.OItem_Attribute_Geburtsdatum.GUID

            If objLGeburtsdatum.Count > 0 Then
                MaskedTextBox_Geburtsdatum.ReadOnly = True
                MaskedTextBox_Geburtsdatum.Text = objLGeburtsdatum(0).Val_Date
                MaskedTextBox_Geburtsdatum.ReadOnly = False
            Else
                MaskedTextBox_Geburtsdatum.ReadOnly = True
                MaskedTextBox_Geburtsdatum.Text = ""
                MaskedTextBox_Geburtsdatum.ReadOnly = False
            End If

            Button_Del_Geburtsdatum.Enabled = True
            Button_Geburtsdatum.Enabled = True

            Dim objLTodesdatum = From obj In objDataWork_PersonalData.OList_Att
                              Where obj.ID_AttributeType = objLocalConfig.OItem_Attribute_Todesdatum.GUID

            If objLTodesdatum.Count > 0 Then
                MaskedTextBox_Todesdatum.ReadOnly = True
                MaskedTextBox_Todesdatum.Text = objLTodesdatum(0).Val_Date
                MaskedTextBox_Todesdatum.ReadOnly = False
            Else
                MaskedTextBox_Todesdatum.ReadOnly = True
                MaskedTextBox_Todesdatum.Text = ""
                MaskedTextBox_Todesdatum.ReadOnly = False
            End If

            Button_Del_Todesdatum.Enabled = True
            Button_Todesdatum.Enabled = True

        Else
            boolStop = False
        End If
        If boolStop = True Then
            Timer_Data.Stop()
            ToolStripProgressBar_Data.Value = 0
        Else
            ToolStripProgressBar_Data.Value = 50
        End If
    End Sub

    
    Private Sub Timer_Nachname_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Nachname.Tick
        Dim objOItem_Result As clsOntologyItem

        Timer_Nachname.Stop()

        If Not objOItem_PersonalData Is Nothing Then
            If Not TextBox_Nachname.Text = "" Then

            Else
                objOItem_Result = objTransaction_PersonalData.del_004_PersonalData__Nachname(objOItem_PersonalData)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    MsgBox("Der Nachname kann nicht geändert werden!", MsgBoxStyle.Exclamation)
                    initialize_PersonalData(objOItem_Partner)
                End If
            End If
        End If
    End Sub

    Private Sub TextBox_Nachname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_Nachname.TextChanged
        Timer_Nachname.Stop()
        If TextBox_Nachname.ReadOnly = False Then
            Timer_Nachname.Start()
        End If
    End Sub
End Class
