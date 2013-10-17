Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class UserControl_Password
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_Security As clsDataWork_Security

    Private objSecurityWork As clsSecurityWork
    Private objTransaction_Password As clsTransaction_Password

    Private objFrm_Name As frm_Name
    Private objOntologyModule As frmMain

    Private objTreeNode_Selected As TreeNode

    Public Sub fill_Password(ByVal objTreeNode As TreeNode)
        Timer_Password.Stop()
        objTreeNode_Selected = objTreeNode
        If Not objTreeNode_Selected Is Nothing Then
            objDataWork_Security.fill_passwords(objTreeNode_Selected)
            Timer_Password.Start()
        Else
            BindingSource_Passwords.DataSource = Nothing
            DataGridView_Passwords.DataSource = Nothing
        End If

    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig, ByVal SecurityWork As clsSecurityWork)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        objSecurityWork = SecurityWork
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDataWork_Security = New clsDataWork_Security(objLocalConfig)
        objTransaction_Password = New clsTransaction_Password(objLocalConfig)
    End Sub

    Private Sub Timer_Password_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Password.Tick
        If objDataWork_Security.OItem_Result_Passwords.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Timer_Password.Stop()
            BindingSource_Passwords.DataSource = objDataWork_Security.dtbl_Password
            DataGridView_Passwords.DataSource = BindingSource_Passwords
            DataGridView_Passwords.Columns(0).Visible = False
            DataGridView_Passwords.Columns(1).Visible = False
            DataGridView_Passwords.Columns(2).Visible = False
            DataGridView_Passwords.Columns(3).Visible = False
            DataGridView_Passwords.Columns(5).Visible = False
            ToolStripProgressBar_Passwords.Value = 0
        Else
            ToolStripProgressBar_Passwords.Value = 50
        End If

        ToolStripLabel_Count.Text = DataGridView_Passwords.RowCount
    End Sub

    Private Sub ToolStripTextBox_Filter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripTextBox_Filter.TextChanged
        Timer_Filter.Stop()
        Timer_Filter.Start()

    End Sub

    Private Sub Timer_Filter_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Filter.Tick
        Dim strFilter As String
        Timer_Filter.Stop()

        If ToolStripTextBox_Filter.Text = "" Then
            BindingSource_Passwords.RemoveFilter()
        Else
            strFilter = ToolStripTextBox_Filter.Text
            If objLocalConfig.Globals.is_GUID(strFilter) Then
                strFilter = "ID_Secured='" & strFilter & "'"

            Else
                strFilter = strFilter.Replace("'", "''")
                strFilter = "Name_Secured LIKE '%" & strFilter & "%'"
            End If

            BindingSource_Passwords.Filter = strFilter
        End If
    End Sub

    Private Sub ContextMenuStrip_Passwords_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Passwords.Opening
        ApplyToolStripMenuItem.Enabled = False
        CopyPasswordToolStripMenuItem.Enabled = False
        If DataGridView_Passwords.SelectedRows.Count > 0 Then
            ApplyToolStripMenuItem.Enabled = True
            If DataGridView_Passwords.SelectedRows.Count = 1 Then
                CopyPasswordToolStripMenuItem.Enabled = True
            End If
        End If

        If Not objTreeNode_Selected Is Nothing Then
            NewToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Dim strPassword_Decoded As String
        Dim strPassword_Encoded As String

        Dim objOItem_Password As New clsOntologyItem
        Dim objOItem_Secured As New clsOntologyItem
        Dim objOItem_Selected As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        If Not objTreeNode_Selected Is Nothing Then
            Select Case objTreeNode_Selected.ImageIndex
                Case objLocalConfig.ImageID_Type_Passwords_Closed
                    objOntologyModule = New frmMain(objLocalConfig.Globals)
                    objOntologyModule.Applyable = True
                    objOntologyModule.ShowDialog(Me)
                    If objOntologyModule.DialogResult = DialogResult.OK Then
                        If objOntologyModule.Type_Applied = objLocalConfig.Globals.Type_Object Then
                            If objOntologyModule.OList_Simple.Count = 1 Then
                                objOItem_Selected = objOntologyModule.OList_Simple(0)
                                If objDataWork_Security.isObject_OK(objOItem_Selected) Then
                                    objFrm_Name = New frm_Name("New Password", _
                                               objLocalConfig.Globals, _
                                               isSecured:=True, _
                                               showRepeat:=True)
                                    objFrm_Name.ShowDialog(Me)
                                    If objFrm_Name.DialogResult = DialogResult.OK Then
                                        strPassword_Decoded = objFrm_Name.Value1
                                        strPassword_Encoded = objSecurityWork.encode_Password(strPassword_Decoded)

                                        objOItem_Password = New clsOntologyItem
                                        objOItem_Password.GUID = Guid.NewGuid.ToString.Replace("-", "")
                                        objOItem_Password.Name = strPassword_Encoded
                                        objOItem_Password.GUID_Parent = objTreeNode_Selected.Name
                                        objOItem_Password.Type = objLocalConfig.Globals.Type_Object

                                        objOItem_Result = objTransaction_Password.save_001_Password(objOItem_Password)
                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                            objOItem_Result = objTransaction_Password.save_002_Password_To_User(objLocalConfig.OItem_User)
                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                objOItem_Result = objTransaction_Password.save_003_Rel_To_Password(objOItem_Selected)
                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                    fill_Password(objTreeNode_Selected)
                                                    ToolStripTextBox_Filter.Text = objOItem_Selected.GUID

                                                Else
                                                    objOItem_Result = objTransaction_Password.del_002_Password_To_User
                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                        objTransaction_Password.del_001_Password()
                                                    End If

                                                    MsgBox("Das Passwort kann nicht gespeichert werden!", MsgBoxStyle.Exclamation)

                                                End If
                                            Else
                                                objTransaction_Password.del_001_Password()
                                                MsgBox("Das Passwort kann nicht gespeichert werden!", MsgBoxStyle.Exclamation)
                                            End If
                                        Else
                                            MsgBox("Das Passwort kann nicht gespeichert werden!", MsgBoxStyle.Exclamation)
                                        End If
                                    End If
                                Else
                                    MsgBox("Die Klasse des gewählten Objects ist nicht erlaubt!", MsgBoxStyle.Exclamation)
                                End If
                            Else
                                MsgBox("Bitte nur 1 Objekte auswählen!", MsgBoxStyle.Exclamation)
                            End If
                        Else
                            MsgBox("Bitte nur Objekte auswählen!", MsgBoxStyle.Exclamation)
                        End If
                    End If



            End Select
        End If
    End Sub

    Private Sub CopyPasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyPasswordToolStripMenuItem.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim strPassword_Decode As String

        objDGVR_Selected = DataGridView_Passwords.SelectedRows(0)
        objDRV_Selected = objDGVR_Selected.DataBoundItem

        strPassword_Decode = objSecurityWork.decode_Password(objDRV_Selected.Item("Name_Password"))
        Clipboard.SetDataObject(strPassword_Decode)
        Timer_Remove.Start()
    End Sub

    Private Sub Timer_Remove_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Remove.Tick
        Timer_Remove.Stop()
        Clipboard.Clear()
    End Sub

    Private Sub DataGridView_Passwords_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView_Passwords.KeyDown
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objFrmDecode As frmDecode
        Dim strPassword_Decode As String

        Select Case e.KeyCode
            Case Keys.Space
                If DataGridView_Passwords.SelectedRows.Count = 1 Then
                    objDGVR_Selected = DataGridView_Passwords.SelectedRows(0)
                    objDRV_Selected = objDGVR_Selected.DataBoundItem

                    strPassword_Decode = objSecurityWork.decode_Password(objDRV_Selected.Item("Name_Password"))
                    objFrmDecode = New frmDecode(strPassword_Decode)
                    objFrmDecode.ShowDialog(Me)
                    strPassword_Decode = Nothing
                Else
                    MsgBox("Bitte nur eine Zeile markieren!", MsgBoxStyle.Exclamation)
                End If
            Case Keys.P
                If e.Control = True Then
                    If DataGridView_Passwords.SelectedRows.Count = 1 Then
                        objDGVR_Selected = DataGridView_Passwords.SelectedRows(0)
                        objDRV_Selected = objDGVR_Selected.DataBoundItem

                        strPassword_Decode = objSecurityWork.decode_Password(objDRV_Selected.Item("Name_Password"))
                        Clipboard.SetDataObject(strPassword_Decode)
                        Timer_Remove.Start()
                        strPassword_Decode = Nothing
                    Else
                        MsgBox("Bitte nur eine Zeile markieren!", MsgBoxStyle.Exclamation)
                    End If
                End If
        End Select
    End Sub

    Private Sub DataGridView_Passwords_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView_Passwords.SelectionChanged

        ApplyToolStripMenuItem.Enabled = False
        ChangeToolStripMenuItem.Enabled = False
        If DataGridView_Passwords.SelectedRows.Count = 1 Then
            ApplyToolStripMenuItem.Enabled = True
            ChangeToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub ChangeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeToolStripMenuItem.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim strPassword_Decoded As String
        Dim strPassword_Encoded As String
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Password As clsOntologyItem

        objDGVR_Selected = DataGridView_Passwords.SelectedRows(0)
        objDRV_Selected = objDGVR_Selected.DataBoundItem
        objOItem_Password = New clsOntologyItem
        objOItem_Password.GUID = objDRV_Selected.Item("ID_Password")
        objOItem_Password.Name = objDRV_Selected.Item("Name_Password")
        objOItem_Password.GUID_Parent = objTreeNode_Selected.Name
        objOItem_Password.Type = objLocalConfig.Globals.Type_Object

        objOItem_Password.Name = objSecurityWork.decode_Password(objOItem_Password.Name)

        objFrm_Name = New frm_Name("New Password", _
                                               objLocalConfig.Globals, _
                                               isSecured:=True, _
                                               showRepeat:=True)
        objFrm_Name.ShowDialog(Me)

        objFrm_Name.ShowDialog(Me)
        If objFrm_Name.DialogResult = Windows.Forms.DialogResult.OK Then
            strPassword_Decoded = objFrm_Name.Value1

            strPassword_Encoded = objSecurityWork.encode_Password(strPassword_Decoded)

            objOItem_Password.Name = strPassword_Encoded

            objOItem_Result = objTransaction_Password.save_001_Password(objOItem_Password)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                MsgBox("Das Passwort wurde geändert!", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Das Passwort konnte nicht geändert werden!", MsgBoxStyle.Exclamation)
            End If

            fill_Password(objTreeNode_Selected)
            BindingSource_Passwords.Filter = "ID_Password='" & objOItem_Password.GUID.ToString & "'"

        End If
    End Sub
End Class
