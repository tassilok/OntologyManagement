Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Version_Module
Imports Filesystem_Module
Imports Localization_Module
Imports TextParser

Public Class UserControl_BaseData

    Private objLocalConfig As clsLocalConfig
    Private objDataWork_BaseData As clsDataWork_BaseData
    Private objOItem_Dev As clsOntologyItem
    Private WithEvents objUserControl_Languages As UserControl_OItemList
    Private WithEvents objUserControl_Localization As UserControl_LocalizationDetails
    Private objDataWork_Details As clsDataWork_Details
    Private objTransaction As clsTransaction

    Private objFrm_OntologyModule As frmMain
    Private objFrm_FileSystemModule As frm_FilesystemModule
    Private objFileWork As clsFileWork
    Private objRelationConfig As clsRelationConfig

    Private objTransaction_Version As clsTransaction_Version

    Public ReadOnly Property SaveVersionFile As Boolean
        Get
            Dim boolSaveVersion = False
            If Not objDataWork_Details.OItem_PLanguage Is Nothing Then
                If objDataWork_Details.OItem_PLanguage.GUID = objLocalConfig.OItem_Object_C_.GUID Or
                    objDataWork_Details.OItem_PLanguage.GUID = objLocalConfig.OItem_Object_VB_Net.GUID Then
                    boolSaveVersion = True
                End If
            End If

            Return boolSaveVersion
        End Get
    End Property

    Public Sub New(LocalConfig As clsLocalConfig, DataWork_BaseData As clsDataWork_BaseData)
        
        ' This call is required by the designer.
        InitializeComponent()
        
        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = LocalConfig
        objDataWork_BaseData = DataWork_BaseData
        Initialize()
    End Sub

    Private sub Initialize()
        
        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
        objFileWork = new clsFileWork(objLocalConfig.Globals)
        objUserControl_Languages = new UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_Languages.Dock = DockStyle.Fill
        objUserControl_Localization = New UserControl_LocalizationDetails(objLocalConfig.Globals)
        objUserControl_Localization.Dock = DockStyle.Fill
        SplitContainer1.Panel2.Controls.Add(objUserControl_Localization)
        Panel_Languages.Controls.Add(objUserControl_Languages)
        objDataWork_Details = New clsDataWork_Details(objLocalConfig)

        clear_Controls()
        Configure_StateCombo()
    End Sub

    Public sub Initialize_BaseData(OItem_Dev As clsOntologyItem)
        objOItem_Dev = OItem_Dev
        objTransaction_Version = New clsTransaction_Version(objLocalConfig, Me, objOItem_Dev, objDataWork_Details)
        clear_Controls()
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

                TextBox_ProjectFile.Text = If(Not objDataWork_Details.OItem_File Is Nothing, objDataWork_Details.OItem_File.Additional1, "")
                Button_ProjectFile.Enabled = True

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

                objUserControl_Languages.Enabled = True

                objUserControl_Localization.initialize_Tree(objOItem_Dev, objDataWork_Details.OItem_StandardLanguage, objDataWork_Details.OList_Languages, False)
                objUserControl_Localization.Enabled = True
            Else 
                MsgBox("Die Basisdaten konnten nicht geladen werden!",MsgBoxStyle.Exclamation)
            End If 

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
        Button_ProjectFile.Enabled = False
        TextBox_ProjectFile.Text = ""
        TextBox_FolderSourceCode.Text = ""
        Button_LanguageStandard.Enabled = false
        TextBox_LanguageStandard.Text = ""
        Button_PLanguage.Enabled = false
        TextBox_PLanguage.Text = ""
        Button_Version.Enabled = False
        TextBox_Version.Text = ""
        objUserControl_Languages.clear_Relation()
        objUserControl_Languages.Enabled = False
        objUserControl_Localization.clear_Tree()
        objUserControl_Localization.Enabled = False
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

    Private Sub Button_Version_Click(sender As Object, e As EventArgs) Handles Button_Version.Click
        
        Dim boolSaveVersionFile = False

        If objDataWork_Details.OItem_PLanguage.GUID = objLocalConfig.OItem_Object_C_.GUID Or
            objDataWork_Details.OItem_PLanguage.GUID = objLocalConfig.OItem_Object_VB_Net.GUID Then
            boolSaveVersionFile = True
        End If
        Dim objOItem_Result = objTransaction_Version.SaveVersion(boolSaveVersionFile)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            TextBox_Version.Text = objDataWork_Details.OItem_Version.Name
        End If




    End Sub

    Private Sub TestVersion()

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

    Private Sub Save_Folder()
        If objFrm_FileSystemModule Is Nothing Then
            objFrm_FileSystemModule = New frm_FilesystemModule(objLocalConfig.Globals)
        End If

        objFrm_FileSystemModule.ShowDialog(Me)
        If objFrm_FileSystemModule.DialogResult = DialogResult.OK Then
            If Not objFrm_FileSystemModule.OItem_FileSystemObject Is Nothing Then
                Dim objFolder = objFrm_FileSystemModule.OItem_FileSystemObject
                If objFolder.GUID_Parent = objLocalConfig.OItem_Class_Folder.GUID Then
                    Dim objORel_Dev_To_Folder = objRelationConfig.Rel_ObjectRelation(objOItem_Dev, objFolder, objLocalConfig.Oitem_RelationType_SourcesLocatedIn)
                    objTransaction.ClearItems()
                    Dim objOItem_Result = objTransaction.do_Transaction(objORel_Dev_To_Folder, True)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objFolder.Additional1 = objFileWork.get_Path_FileSystemObject(objFolder)
                        objDataWork_Details.OItem_Folder = objFolder
                        TextBox_FolderSourceCode.Text = objFolder.Additional1
                    Else
                        MsgBox("Der Ordner konnte nicht verknüpft werden!", MsgBoxStyle.Exclamation)
                    End If

                Else
                    MsgBox("Bitte nur einen Ordner auswählen!", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Bitte nur einen Ordner auswählen!", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub Save_File()
        If Not objDataWork_Details.OItem_Folder Is Nothing Then
            If objFrm_FileSystemModule Is Nothing Then
                objFrm_FileSystemModule = New frm_FilesystemModule(objLocalConfig.Globals)
            End If
            objFrm_FileSystemModule.ClearFiles()
            objFrm_FileSystemModule.ActivateNode(objDataWork_Details.OItem_Folder.GUID)
            objFrm_FileSystemModule.ShowDialog(Me)
            If objFrm_FileSystemModule.DialogResult = DialogResult.OK Then
                If Not objFrm_FileSystemModule.OList_Files Is Nothing Then
                    If objFrm_FileSystemModule.OList_Files.Count = 1 Then
                        Dim objFile = objFrm_FileSystemModule.OList_Files.First()

                        Dim objORel_Dev_To_File = objRelationConfig.Rel_ObjectRelation(objOItem_Dev, objFile, objLocalConfig.OItem_relationtype_project_file)

                        objTransaction.ClearItems()
                        Dim objOItem_Result = objTransaction.do_Transaction(objORel_Dev_To_File, True)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objFile.Additional1 = objFileWork.get_Path_FileSystemObject(objFile)
                            objDataWork_Details.OItem_File = objFile
                            TextBox_ProjectFile.Text = objFile.Additional1
                        Else
                            MsgBox("Die Datei konnte nicht verknüpft werden!", MsgBoxStyle.Exclamation)
                        End If


                    Else
                        MsgBox("Bitte nur eine Datei auswählen!", MsgBoxStyle.Information)
                    End If

                Else
                    MsgBox("Bitte nur eine Datei auswählen!", MsgBoxStyle.Information)
                End If
            End If
        Else
            MsgBox("Wählen Sie bitte vorher eine Datei aus!", MsgBoxStyle.Information)
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
                            objDataWork_Details.OItem_StandardLanguage = objOItem_StandardLanguage.Clone()
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

    Private Sub Button_ProjectFile_Click(sender As Object, e As EventArgs) Handles Button_ProjectFile.Click
        Save_File()
    End Sub
End Class
