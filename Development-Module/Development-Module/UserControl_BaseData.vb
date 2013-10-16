Imports Ontolog_Module
Imports OntologyClasses.BaseClasses
Imports Version_Module
Imports Filesystem_Module
Public Class UserControl_BaseData

    Private objLocalConfig As clsLocalConfig
    Private objDataWork_BaseData As clsDataWork_BaseData
    Private objOItem_Dev As clsOntologyItem
    Private WithEvents objUserControl_Languages As UserControl_OItemList
    Private objDataWork_Details As clsDataWork_Details
    Private objTransaction As clsTransaction
    Private objFrm_VersionEdit As frmVersionEdit
    Private objFrm_OntologyModule As frmMain
    Private objFrm_FileSystemModule As frm_FilesystemModule
    Private objFileWork As clsFileWork

    Public Sub New(LocalConfig As clsLocalConfig, DataWork_BaseData As clsDataWork_BaseData)
        
        ' This call is required by the designer.
        InitializeComponent()
        
        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = LocalConfig
        objDataWork_BaseData = DataWork_BaseData
        Initialize()
    End Sub

    Private sub Initialize()
        
        objTransaction = new clsTransaction(objLocalConfig.Globals)
        objFileWork = new clsFileWork(objLocalConfig.Globals)
        objUserControl_Languages = new UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_Languages.Dock = DockStyle.Fill
        Panel_Languages.Controls.Add(objUserControl_Languages)
        objDataWork_Details = new clsDataWork_Details(objLocalConfig)
        clear_Controls()
        Configure_StateCombo()
    End Sub

    Public sub Initialize_BaseData(OItem_Dev As clsOntologyItem)
        objOItem_Dev = OItem_Dev
        If Not objOItem_Dev Is Nothing Then
            if objDataWork_Details.GetData(objOItem_Dev).GUID = objLocalConfig.Globals.LState_Success.GUID Then
                Label_Development.Text = objOItem_Dev.Name

                If not objDataWork_Details.OItem_State Is Nothing Then
                    ComboBox_State.SelectedValue = objDataWork_Details.OItem_State.GUID
                    ComboBox_State.Enabled = True
                Else 
                    ComboBox_State.Enabled = True
                    If Not ComboBox_State.SelectedValue = objLocalConfig.Oitem_Object_LogState_Active.GUID Then
                        ComboBox_State.SelectedValue = objLocalConfig.Oitem_Object_LogState_Active.GUID
                    Else 
                        Save_State()
                    End If
                    
                End If

                TextBox_Creator.Text = If(Not objDataWork_Details.OItem_Creator is Nothing, objDataWork_Details.OItem_Creator.Name, "")
                Button_Creator.Enabled = True
                
                TextBox_Version.Text = if(Not objDataWork_Details.OItem_Version Is Nothing,objDataWork_Details.OItem_Version.Name,"")
                Button_Version.Enabled = True

                TextBox_FolderSourceCode.Text = if(Not objDataWork_Details.OItem_Folder Is Nothing,objDataWork_Details.OItem_Folder.Additional1,"")
                Button_FolderSourceCode.Enabled = True

                TextBox_PLanguage.Text = if(Not objDataWork_Details.OItem_PLanguage Is Nothing,objDataWork_Details.OItem_PLanguage.Name,"")
                Button_PLanguage.Enabled = True

                TextBox_LanguageStandard.Text = if(Not objDataWork_Details.OItem_StandardLanguage Is Nothing,objDataWork_Details.OItem_StandardLanguage.Name,"")
                Button_LanguageStandard.Enabled = True

                Dim objOItem_Language = new clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Class_Language.GUID, _
                                                                  .Type = objLocalConfig.Globals.Type_Object}
                objUserControl_Languages.initialize(Nothing, _
                                                 objOItem_Dev, _
                                             objLocalConfig.Globals.Direction_LeftRight, _
                                             objOItem_Language, _
                                             objLocalConfig.Oitem_RelationType_additional,False)

                objUserControl_Languages.Enabled=True
            Else 
                MsgBox("Die Basisdaten konnten nicht geladen werden!",MsgBoxStyle.Exclamation)
            End If
        Else 
            clear_Controls()
        End If
    End Sub

    Private sub Save_State()
        objTransaction.ClearItems()

        Dim objOList_States As List(Of clsOntologyItem) = ComboBox_State.DataSource
        Dim objOItem_State = objOList_States.Where(Function(p) p.GUID = ComboBox_State.SelectedValue).First()

        Dim objRel_Dev_To_Status = objDataWork_Details.Rel_Dev_To_Status(objOItem_Dev, objOItem_State)
        objTransaction.ClearItems()
        Dim objOItem_Result = objTransaction.do_Transaction(objRel_Dev_To_Status,True)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objDataWork_Details.OItem_State = objOItem_State.Clone()
        else
            MsgBox("Der Status konnte nicht geändert werden!",MsgBoxStyle.Exclamation)
            ComboBox_State.Enabled = False
            If Not objDataWork_Details.OItem_State Is Nothing Then
                ComboBox_State.SelectedValue = objDataWork_Details.OItem_State.GUID
            Else 
                ComboBox_State.SelectedValue = objLocalConfig.Oitem_Object_LogState_Active.GUID
            End If
            
        End If
    End Sub

    Private sub Save_Version()
        objFrm_VersionEdit = new frmVersionEdit(objOItem_Dev, objLocalConfig.Globals, objLocalConfig.OItem_User)       
        objFrm_VersionEdit.ShowDialog(Me)
        If objFrm_VersionEdit.DialogResult=DialogResult.OK Then
            If objFrm_VersionEdit.OItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If Not objFrm_VersionEdit.OItem_Version Is Nothing Then
                    objDataWork_Details.OItem_Version = objFrm_VersionEdit.OItem_Version.Clone()
                    TextBox_Version.Text = objDataWork_Details.OItem_Version.Name
                End If
            End If
        End If
    End Sub

    Private sub Save_Creator()
        objFrm_OntologyModule = new frmMain(objLocalConfig.Globals,objLocalConfig.Globals.Type_Class,objLocalConfig.OItem_Class_User)
        objFrm_OntologyModule.ShowDialog(Me)

        If objFrm_OntologyModule.DialogResult=DialogResult.OK Then
            If objFrm_OntologyModule.Type_Applied = objLocalConfig.Globals.Type_Object Then
                If objFrm_OntologyModule.OList_Simple.Count=1 Then
                    Dim objOItem_User = objFrm_OntologyModule.OList_Simple.First()
                    If objOItem_User.GUID_Parent = objLocalConfig.OItem_Class_User.GUID Then
                        Dim objORel_Dev_To_Creator = objDataWork_Details.Rel_Dev_To_Creator(objOItem_Dev, objOItem_User)
                        objTransaction.ClearItems()
                        Dim objOItem_Result = objTransaction.do_Transaction(objORel_Dev_To_Creator,True)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            TextBox_Creator.Text = objOItem_User.Name
                            objDataWork_Details.OItem_Creator = objOItem_User.Clone()
                        Else 
                            MsgBox("Der User konnte nicht verknüpft werden!",MsgBoxStyle.Exclamation)
                        End If
                    Else 
                        MsgBox("Bitte nur einen User auswählen!",MsgBoxStyle.Information)
                    End If
                Else 
                    MsgBox("Bitte nur einen User auswählen!",MsgBoxStyle.Information)
                End If
            Else 
                MsgBox("Bitte nur einen User auswählen!",MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Public sub Save_PLanguage()
        objFrm_OntologyModule = new frmMain(objLocalConfig.Globals,objLocalConfig.Globals.Type_Class,objLocalConfig.OItem_Class_ProgramingLanguage)
        objFrm_OntologyModule.ShowDialog(Me)

        If objFrm_OntologyModule.DialogResult=DialogResult.OK Then
            If objFrm_OntologyModule.Type_Applied = objLocalConfig.Globals.Type_Object Then
                If objFrm_OntologyModule.OList_Simple.Count=1 Then
                    Dim objOItem_PLanguage = objFrm_OntologyModule.OList_Simple.First()
                    If objOItem_PLanguage.GUID_Parent = objLocalConfig.OItem_Class_ProgramingLanguage.GUID Then
                        Dim objORel_Dev_To_PLanguage = objDataWork_Details.Rel_Dev_To_PLanguage(objOItem_Dev, objOItem_PLanguage)
                        objTransaction.ClearItems()
                        Dim objOItem_Result = objTransaction.do_Transaction(objORel_Dev_To_PLanguage,True)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            TextBox_PLanguage.Text = objOItem_PLanguage.Name
                            objDataWork_Details.OItem_PLanguage= objOItem_PLanguage.Clone()
                        Else 
                            MsgBox("Der User konnte nicht verknüpft werden!",MsgBoxStyle.Exclamation)
                        End If
                    Else 
                        MsgBox("Bitte nur einen User auswählen!",MsgBoxStyle.Information)
                    End If
                Else 
                    MsgBox("Bitte nur einen User auswählen!",MsgBoxStyle.Information)
                End If
            Else 
                MsgBox("Bitte nur einen User auswählen!",MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private sub clear_Controls()
        Label_Development.Text = "-"
        ComboBox_State.Enabled=False
        TextBox_Creator.Text = ""
        Button_Creator.Enabled = False
        Button_FolderSourceCode.Enabled = False
        TextBox_FolderSourceCode.Text = ""
        Button_LanguageStandard.Enabled = false
        TextBox_LanguageStandard.Text = ""
        Button_PLanguage.Enabled = false
        TextBox_PLanguage.Text = ""
        Button_Version.Enabled = False
        TextBox_Version.Text = ""
        objUserControl_Languages.clear_Relation()
        objUserControl_Languages.Enabled=False
    End Sub

    Private sub Configure_StateCombo()
        ComboBox_State.DataSource = objDataWork_BaseData.OList_StateCombo
        ComboBox_State.ValueMember = "GUID"
        ComboBox_State.DisplayMember = "Name"
    End Sub

    Private Sub ComboBox_State_SelectedIndexChanged( sender As Object,  e As EventArgs) Handles ComboBox_State.SelectedIndexChanged
        If ComboBox_State.Enabled Then
            Save_State()
        End If
        
    End Sub

    Private Sub Button_Version_Click( sender As Object,  e As EventArgs) Handles Button_Version.Click
        Save_Version()
    End Sub

    Private Sub Button_Creator_Click( sender As Object,  e As EventArgs) Handles Button_Creator.Click
        Save_Creator()
    End Sub

    Private Sub Button_PLanguage_Click( sender As Object,  e As EventArgs) Handles Button_PLanguage.Click
        Save_PLanguage()
    End Sub

    Private Sub Button_FolderSourceCode_Click( sender As Object,  e As EventArgs) Handles Button_FolderSourceCode.Click
        Save_Folder()
    End Sub

    Private sub Save_Folder()
        objFrm_FileSystemModule = new frm_FilesystemModule(objLocalConfig.Globals)
        objFrm_FileSystemModule.ShowDialog(me)
        If objFrm_FileSystemModule.DialogResult=DialogResult.OK Then
            If Not objFrm_FileSystemModule.OItem_FileSystemObject Is Nothing Then
                Dim objFolder = objFrm_FileSystemModule.OItem_FileSystemObject
                If objFolder.GUID_Parent = objLocalConfig.OItem_Class_Folder.GUID Then
                    Dim objORel_Dev_To_Folder = objDataWork_Details.Rel_Dev_To_Folder(objOItem_Dev, objFolder)
                    objTransaction.ClearItems()
                    Dim objOItem_Result = objTransaction.do_Transaction(objORel_Dev_To_Folder,True)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objFolder.Additional1 = objFileWork.get_Path_FileSystemObject(objFolder)
                        objDataWork_Details.OItem_Folder = objFolder
                        TextBox_FolderSourceCode.Text = objfolder.Additional1
                    Else 
                        MsgBox("Der Ordner konnte nicht verknüpft werden!",MsgBoxStyle.Exclamation)
                    End If

                Else 
                    MsgBox("Bitte nur einen Ordner auswählen!",MsgBoxStyle.Information)
                End If
            Else 
                MsgBox("Bitte nur einen Ordner auswählen!",MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private sub Save_StdLanguage()
        objFrm_OntologyModule = new frmMain(objLocalConfig.Globals,objLocalConfig.Globals.Type_Class,objLocalConfig.OItem_Class_Language)
        objFrm_OntologyModule.ShowDialog(Me)

        If objFrm_OntologyModule.DialogResult=DialogResult.OK Then
            If objFrm_OntologyModule.Type_Applied = objLocalConfig.Globals.Type_Object Then
                If objFrm_OntologyModule.OList_Simple.Count=1 Then
                    Dim objOItem_StandardLanguage = objFrm_OntologyModule.OList_Simple.First()
                    If objOItem_StandardLanguage.GUID_Parent = objLocalConfig.OItem_Class_Language.GUID Then
                        Dim objORel_Dev_To_StandardLanguage = objDataWork_Details.Rel_Dev_To_StandardLanguage(objOItem_Dev, objOItem_StandardLanguage)
                        objTransaction.ClearItems()
                        Dim objOItem_Result = objTransaction.do_Transaction(objORel_Dev_To_StandardLanguage,True)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            TextBox_LanguageStandard.Text = objOItem_StandardLanguage.Name
                            objDataWork_Details.OItem_StandardLanguage= objOItem_StandardLanguage.Clone()
                        Else 
                            MsgBox("Die Sprache konnte nicht verknüpft werden!",MsgBoxStyle.Exclamation)
                        End If
                    Else 
                        MsgBox("Bitte nur eine Sprache auswählen!",MsgBoxStyle.Information)
                    End If
                Else 
                    MsgBox("Bitte nur eine Sprache auswählen!",MsgBoxStyle.Information)
                End If
            Else 
                MsgBox("Bitte nur eine Sprache auswählen!",MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub Button_LanguageStandard_Click( sender As Object,  e As EventArgs) Handles Button_LanguageStandard.Click
        Save_StdLanguage()
    End Sub
End Class
