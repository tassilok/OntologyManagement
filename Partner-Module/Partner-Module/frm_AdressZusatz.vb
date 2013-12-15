Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class frm_AdressZusatz

    Private objLocalConfig As clsLocalConfig

    Private objDataWork_Address As clsDataWork_Address

    Private objTransaction As clsTransaction
    Private objRelationConfig As clsRelationConfig

    Private objUserControl_ZusatzType As UserControl_OItemList

    Private Sub ToolStripButton_Cancel_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Cancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub ToolStripButton_Ok_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Ok.Click


        If TextBox_Name.Text <> "" Then
            If objUserControl_ZusatzType.DataGridViewRowCollection_Selected.Count = 1 Then
                objDataWork_Address.get_Data_Zusatz()
                If objDataWork_Address.Result_Zusatz.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Dim objLExist = objDataWork_Address.Zusaetze.Where(Function(p) p.Name_AdressZusatz.ToLower() = TextBox_Name.Text.ToLower()).ToList()
                    If Not objLExist.Any Then
                        objTransaction.ClearItems()
                        Dim objOItem_AdressZusatz = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                                              .Name = TextBox_Name.Text, _
                                                                              .GUID_Parent = objLocalConfig.OItem_class_adress_zusatz.GUID, _
                                                                              .Type = objLocalConfig.Globals.Type_Object}

                        Dim objOItem_Result = objTransaction.do_Transaction(objOItem_AdressZusatz)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Dim objDRV_Selected As DataRowView = objUserControl_ZusatzType.DataGridViewRowCollection_Selected(0).DataBoundItem
                            Dim objOItem_Typ = New clsOntologyItem With {.GUID = objDRV_Selected.Item("ID_Item"), _
                                                                         .Name = objDRV_Selected.Item("Name"), _
                                                                         .GUID_Parent = objDRV_Selected.Item("ID_Parent"), _
                                                                         .Type = objLocalConfig.Globals.Type_Object}

                            Dim objORel_AddressZusatz_To_Typ = objRelationConfig.Rel_ObjectRelation(objOItem_AdressZusatz, _
                                                                                                    objOItem_Typ, _
                                                                                                    objLocalConfig.OItem_relationtype_is_of_type)

                            objOItem_Result = objTransaction.do_Transaction(objORel_AddressZusatz_To_Typ, True)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                                Dim objOrel_Addresse_To_Adresszusatz = objRelationConfig.Rel_ObjectRelation(objDataWork_Address.Address, _
                                                                                                            objOItem_AdressZusatz, _
                                                                                                            objLocalConfig.OItem_RelationType_belonging)

                                objOItem_Result = objTransaction.do_Transaction(objOrel_Addresse_To_Adresszusatz, True)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objDataWork_Address.Zusaetze.Add(New clsAdderesszusatz With {.ID_AdressZusatz = objOItem_AdressZusatz.GUID, _
                                                                                             .Name_AdressZusatz = objOItem_AdressZusatz.Name, _
                                                                                             .ID_ZusatzTyp = objOItem_Typ.GUID, _
                                                                                             .Name_ZusatzTyp = objOItem_Typ.Name})

                                    DialogResult = Windows.Forms.DialogResult.OK
                                    Close()
                                Else
                                    MsgBox("Beim Speichern ist ein Fehler aufgetraten.", MsgBoxStyle.Exclamation)
                                End If

                                
                            Else
                                MsgBox("Beim Speichern ist ein Fehler aufgetraten.", MsgBoxStyle.Exclamation)
                            End If
                            

                        Else
                            MsgBox("Beim Speichern ist ein Fehler aufgetraten.", MsgBoxStyle.Exclamation)
                        End If
                        
                    Else
                        MsgBox("Es gibt bereits einen Adresszusatz mit dem eingegebenen Namen!", MsgBoxStyle.Information)
                    End If
                    
                Else
                    MsgBox("Beim Speichern ist ein Fehler aufgetraten.", MsgBoxStyle.Exclamation)
                End If
            Else
                MsgBox("Wählen Sie bitte nur einen Zusatztyp aus!", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Geben Sie bitte einen Namen ein!", MsgBoxStyle.Information)
        End If

        


    End Sub

    Public Sub New(LocalConfig As clsLocalConfig, DataWork_Address As clsDataWork_Address)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objDataWork_Address = DataWork_Address
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objUserControl_ZusatzType = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_ZusatzType.Dock = DockStyle.Fill
        objUserControl_ZusatzType.initialize(objLocalConfig.OItem_class_zusatz_typ)

        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)

        Panel_ZusatzTyp.Controls.Add(objUserControl_ZusatzType)
        objUserControl_ZusatzType.initialize(New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_class_zusatz_typ.GUID, _
                                                                       .Type = objLocalConfig.Globals.Type_Object})

    End Sub
End Class