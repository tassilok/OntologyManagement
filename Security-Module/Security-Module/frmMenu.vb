imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Structure_Module

Public Class frmMenu

    Private objLocalConfig As clsLocalConfig
    Private objDataWork_Menu As clsDataWork_Menu
    Private objOItem_Ref As clsOntologyItem
    Private objOItem_Class As clsOntologyItem
    Private objSecurityWork As clsSecurityWork
    Private strPassword As String

    Public Sub New(Globals As clsGlobals, OItem_Ref As clsOntologyItem, OItem_User As clsOntologyItem)
        
        ' This call is required by the designer.
        InitializeComponent()
        
        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = new clsLocalConfig(Globals)
        objOItem_Ref = OItem_Ref
        objSecurityWork = new clsSecurityWork(objLocalConfig, Me)
        objSecurityWork.initialize_User(OItem_User)

        Initialize()
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig, OItem_Ref As clsOntologyItem, SecurityWork As clsSecurityWork)
        
        ' This call is required by the designer.
        InitializeComponent()
        
        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = LocalConfig
        objOItem_Ref = OItem_Ref
        objSecurityWork = SecurityWork

        Initialize()
    End Sub

    Private sub Initialize()
        
        objDataWork_Menu = new clsDataWork_Menu(objLocalConfig)

        Me.Text = ""

        If objOItem_Ref.Type.ToLower() = objLocalConfig.Globals.Type_Object.ToLower() Then
            objOItem_Class = objDataWork_Menu.GetOItem(objOItem_Ref.GUID_Parent, objLocalConfig.Globals.Type_Class)    
            If Not objOItem_Class Is Nothing Then
                Me.Text = objOItem_Class.Name & "\"
            End If
        End If

        
        Me.Text = Me.Text & objOItem_Ref.Name
        
        FillGrid()
    End Sub

    Private sub FillGrid()
        Dim objOItem_Result = objDataWork_Menu.GetSecuredItems(objOItem_Ref)

        DataGridView_Secured.DataSource = Nothing
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            DataGridView_Secured.DataSource = New SortableBindingList(Of clsSecuredItem)(objDataWork_Menu.SecuredItems)
            For Each col As DataGridViewColumn In DataGridView_Secured.Columns
                If col.Name = "Password" Or 
                   col.Name = "Name_RelationType" Or
                   col.Name = "Name_User" Then
                    
                    col.Visible = True
                Else 
                    col.Visible = False
                End If
                    
            Next
        Else 
            MsgBox("Die Daten konnten nicht geladen werden! Die Anwendung wird beendet.",MsgBoxStyle.Exclamation)
            Environment.Exit(-1)
        End If
    End Sub

    Private Sub ContextMenuStrip_Passwords_Opening( sender As Object,  e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Passwords.Opening
        NewToolStripMenuItem.Enabled = True
        ChangeToolStripMenuItem.Enabled = False
        CopyPasswordToolStripMenuItem.Enabled = False

        If DataGridView_Secured.SelectedRows.Count = 1 Then
            ChangeToolStripMenuItem.Enabled = True

            Dim dataRow As DataGridViewRow = DataGridView_Secured.SelectedRows(0)
            Dim securedItem As clsSecuredItem = dataRow.DataBoundItem

            If Not securedItem.Name_Password Is Nothing Then
                CopyPasswordToolStripMenuItem.Enabled = True
            End If
            
        End If
    End Sub

    Private Sub CopyPasswordToolStripMenuItem_Click( sender As Object,  e As EventArgs) Handles CopyPasswordToolStripMenuItem.Click
        If DataGridView_Secured.SelectedRows.Count = 1 Then

            Dim dataRow As DataGridViewRow = DataGridView_Secured.SelectedRows(0)
            Dim securedItem As clsSecuredItem = dataRow.DataBoundItem

            If Not securedItem.Name_Password Is Nothing Then
                strPassword = objSecurityWork.decode_Password(securedItem.Name_Password)
                Clipboard.SetDataObject(strPassword)
                Timer_Copy.Start()
            End If
            
        End If
    End Sub

    Private Sub Timer_Copy_Tick( sender As Object,  e As EventArgs) Handles Timer_Copy.Tick
        Timer_Copy.Stop()
        strPassword = ""
        Clipboard.Clear()
    End Sub

    Private Sub frmMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Clipboard.Clear()
    End Sub
End Class