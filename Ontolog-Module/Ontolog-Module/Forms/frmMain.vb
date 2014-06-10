Imports OntologyClasses.BaseClasses

Public Class frmMain
    Private objLocalConfig As clsLocalConfig

    Private WithEvents objUserControl_TypeTree As UserControl_TypeTree
    Private WithEvents objUserControl_OObjectList As UserControl_OItemList
    Private WithEvents objUserControl_ObjectTree As UserControl_ObjectTree
    Private WithEvents objUserControl_ORelationTypeList As UserControl_OItemList
    Private WithEvents objUserControl_OAttributeList As UserControl_OItemList
    Private WithEvents objUserControl_ObjRel As UserControl_ObjectRel
    Private WithEvents objUserControl_ObjAtt As UserControl_ObjectAtt
    Private WithEvents objUserControl_Filter As UserControl_Filter

    Private objFrm_ObjectEdit As frm_ObjectEdit
    Private objFrm_AttributeTypeEdit As frm_AttributeTypeEdit
    Private objFrm_OntologyConfigurator As frmOntologyConfigurator
    Private objFrm_OntologyItem As frmMain

    Private objMappingWork As clsMappingWork

    Private SplashScreen As SplashScreen_OntologyModule
    Private AboutBox As AboutBox_OntologyItem

    Private objOItem As clsOntologyItem

    Private objOItem_Class As clsOntologyItem

    Private objDBLevel_Objects As clsDBLevel
    Private objDBLevel_ObjectRel As clsDBLevel
    Private objDBLevel_Other As clsDBLevel
    Private objDBLevel_Work As clsDBLevel

    Private objReport As clsReport

    Private objOList_ClassRel_LeftRight As New List(Of clsClassRel)
    Private objOList_ClassRel_RightLeft As New List(Of clsClassRel)

    Private objOList_Classes_Right As New List(Of clsOntologyItem)
    Private objOList_RelationTypes_Right As New List(Of clsOntologyItem)
    Private objOList_Classes_Left As New List(Of clsOntologyItem)
    Private objOList_RelationTypes_Left As New List(Of clsOntologyItem)

    Private strType_Entry As String
    Private objOItem_Entry As clsOntologyItem

    Private boolApplyable As Boolean

    Private strType_Applied As String
    Private oList_Applied_Simple As List(Of clsOntologyItem)
    Private oList_Applied_ObjRel As List(Of clsObjectRel)

    Private Sub selected_ObjectNode(OItem_Node As clsOntologyItem) Handles objUserControl_ObjectTree.selected_Node
        If Not OItem_Node Is Nothing Then
            objUserControl_OObjectList.select_Row(OItem_Node)

        End If
    End Sub

    Private Sub Filter_Objects(objFilter As clsFilter) Handles objUserControl_Filter.FilterItems

        Select Case objFilter.KindOfRelation
            Case RelationType.NoRelation
                If Not objFilter.GUID_Left Is Nothing Or Not objFilter.Name_Left Is Nothing Or _
                    Not objFilter.GUID_LeftParent Is Nothing Or Not objFilter.Name_LeftParent Is Nothing Then
                    'objUserControl_OObjectList.initialize(objFilter, True)
                Else
                    MsgBox("Der Filter ist nicht richtig konfiguriert!", MsgBoxStyle.Information)
                End If
            Case RelationType.LeftRight

            Case RelationType.RightLeft

        End Select
    End Sub

    Private Sub added_ObjectNode(OItem_Node As clsOntologyItem) Handles objUserControl_ObjectTree.added_Node
        objUserControl_OObjectList.initialize(objOItem_Class)
    End Sub

    Private Sub objUserControl_ObjRel_related_Items() Handles objUserControl_ObjRel.related_Items
        configureRelationLabel()
    End Sub

    Private Sub configureRelationLabel()
        Configure_ORel()
        ToolStripStatusLabel_RelationDone.Text = If(objUserControl_ObjRel.OItem_Left Is Nothing, "-", objUserControl_ObjRel.OItem_Left.Name)
        ToolStripStatusLabel_RelationDone.Text = ToolStripStatusLabel_RelationDone.Text & If(objUserControl_ObjRel.OItem_RelationType Is Nothing, "-", objUserControl_ObjRel.OItem_RelationType.Name)
        ToolStripStatusLabel_RelationDone.Text = ToolStripStatusLabel_RelationDone.Text & If(objUserControl_ObjRel.OItem_Other Is Nothing, "-", objUserControl_ObjRel.OItem_Other.Name)

    End Sub

    Private Sub selected_Left(ByVal objOItem_Object As clsOntologyItem) Handles objUserControl_ObjRel.selected_Left
        If objOItem_Object Is Nothing Then
            ToolStripStatusLabel_TokenRelLeft.Text = "-"
        Else
            ToolStripStatusLabel_TokenRelLeft.Text = objOItem_Object.Name
        End If

    End Sub

    Private Sub selected_Right(ByVal objOItem_Object As clsOntologyItem) Handles objUserControl_ObjRel.selected_Right
        If objOItem_Object Is Nothing Then
            ToolStripStatusLabel_TokenRelRight.Text = "-"
        Else
            ToolStripStatusLabel_TokenRelRight.Text = objOItem_Object.Name
        End If

    End Sub

    Private Sub selected_RelationType(ByVal objOItem_Object As clsOntologyItem) Handles objUserControl_ObjRel.selected_RelationType
        If objOItem_Object Is Nothing Then
            ToolStripStatusLabel_TokenRelRelation.Text = "-"
        Else
            ToolStripStatusLabel_TokenRelRelation.Text = objOItem_Object.Name
        End If

    End Sub

    Public ReadOnly Property Type_Applied As String
        Get
            Return strType_Applied
        End Get
    End Property

    Public ReadOnly Property OList_Simple As List(Of clsOntologyItem)
        Get
            Return oList_Applied_Simple
        End Get
    End Property

    Public ReadOnly Property OList_ObjectRel As List(Of clsObjectRel)
        Get
            Return oList_Applied_ObjRel
        End Get
    End Property

    Public Property Applyable As Boolean
        Get
            Return boolApplyable
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Private Sub applied_Class() Handles objUserControl_TypeTree.applied_Class
        oList_Applied_Simple = objUserControl_TypeTree.List_Classes
        strType_Applied = objLocalConfig.Globals.Type_Class
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub applied_Objects_Tree() Handles objUserControl_ObjectTree.applied_Objects
        Dim objOList_Objects = objUserControl_ObjectTree.List_Objects
        If boolApplyable = True Then
            oList_Applied_Simple = objOList_Objects
            strType_Applied = objLocalConfig.Globals.Type_Object
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            objUserControl_ObjRel.applied_Object(objOList_Objects)
        End If

    End Sub

    Private Sub applied_ListObjects() Handles objUserControl_OObjectList.applied_Items

        If boolApplyable = True Then
            oList_Applied_Simple = objUserControl_OObjectList.OList_Simple
            strType_Applied = objLocalConfig.Globals.Type_Object
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            oList_Applied_Simple = objUserControl_OObjectList.OList_Simple
            objUserControl_ObjRel.applied_Object(oList_Applied_Simple)
        End If

    End Sub

    Private Sub applied_ListRelTypes() Handles objUserControl_ORelationTypeList.applied_Items
        If boolApplyable = True Then
            oList_Applied_Simple = objUserControl_ORelationTypeList.OList_Simple
            strType_Applied = objLocalConfig.Globals.Type_RelationType
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            oList_Applied_Simple = objUserControl_ORelationTypeList.OList_Simple
            If oList_Applied_Simple.Count = 1 Then
                objUserControl_ObjRel.applied_RelType(oList_Applied_Simple(0))
            End If
        End If

    End Sub

    Private Sub applied_ListAttTypes() Handles objUserControl_OAttributeList.applied_Items
        If boolApplyable = True Then
            oList_Applied_Simple = objUserControl_OAttributeList.OList_Simple
            strType_Applied = objLocalConfig.Globals.Type_AttributeType
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else

        End If

    End Sub


    Private Sub selectedClass(ByVal OItem_Class As clsOntologyItem) Handles objUserControl_TypeTree.selected_Class
        objOItem_Class = OItem_Class
        objUserControl_OObjectList.initialize(New clsOntologyItem(Nothing, Nothing, OItem_Class.GUID, objLocalConfig.Globals.Type_Object))
        get_ClassRel(objOItem_Class)
        initialize_OTree()
    End Sub

    Private Sub initialize_OTree()
        Dim objTreeNode As TreeNode
        Dim objOItem_Class As New clsOntologyItem
        objTreeNode = objUserControl_TypeTree.selected_Node
        If Not objTreeNode Is Nothing Then

            objOItem_Class.GUID = objTreeNode.Name
            objOItem_Class.Name = objTreeNode.Text
            objOItem_Class.Type = objLocalConfig.Globals.Type_Class

            If SplitContainer_Token.Panel2Collapsed = False Then
                objUserControl_ObjectTree.initialize(objOItem_Class)
            End If
        Else
            objUserControl_ObjectTree.clear()
        End If

    End Sub

    Private Sub ObjectList_Selection_Changed() Handles objUserControl_OObjectList.Selection_Changed
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOList_Item As New List(Of clsOntologyItem)


        If objUserControl_OObjectList.DataGridViewRowCollection_Selected.Count = 1 Then
            objDGVR_Selected = objUserControl_OObjectList.DataGridViewRowCollection_Selected(0)
            objDRV_Selected = objDGVR_Selected.DataBoundItem
            If SplitContainer_Token.Panel2Collapsed = False Then
                'objUserControl_TokenTree.find_Node(objDRV_Selected.Item("GUID_Token"))
            End If

            objOItem = New clsOntologyItem(objDRV_Selected.Item("ID_Item"), _
                                           objDRV_Selected.Item("Name"), _
                                           objDRV_Selected.Item("ID_Parent"), _
                                           objLocalConfig.Globals.Type_Object)

            objOList_Item.Add(objOItem)
            'get_ObjectRel(objOItem)
            'get_TokenAttribute(objSemItem_Token)
            If Not objUserControl_ObjRel Is Nothing Then
                objUserControl_ObjRel.initialize_RelList(objOList_Item, _
                                                     objOList_Classes_Left, _
                                                     objOList_RelationTypes_Left, _
                                                     objOList_ClassRel_LeftRight, _
                                                     objOList_Classes_Right, _
                                                     objOList_RelationTypes_Right, _
                                                     objOList_ClassRel_RightLeft)
            End If

            


            If Not objUserControl_ObjAtt Is Nothing Then
                objUserControl_ObjAtt.initialize_RelList(objOItem, _
                                                     Nothing)
            End If
            

            If Not objUserControl_ObjectTree Is Nothing Then
                objUserControl_ObjectTree.select_Node(objOItem.GUID)
            End If


            'If objUserControl_OObjectList.ShowParents Then
            '    Dim objOItem_Class = New clsOntologyItem With {.GUID = objOItem.GUID_Parent}
            '    objUserControl_TypeTree.SelectNode(objOItem_Class)
            'End If
        Else
            'procT_TokenRel_With_Or.Clear()
            'funcT_TokenAttribute_Named_By_GUIDToken.Clear()
        End If
    End Sub

    Private Sub get_ClassRel(ByVal objOItem_Class As clsOntologyItem)

        Dim objOList_ClassRel As New List(Of clsClassRel)
        Dim objDBLevel_LeftRight As New clsDBLevel(objLocalConfig.Globals)
        Dim objDBLevel_RightLeft As New clsDBLevel(objLocalConfig.Globals)


        objOList_ClassRel.Add(New clsClassRel(objOItem_Class.GUID, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))

        objOList_Classes_Left.Clear()
        objOList_Classes_Right.Clear()
        objOList_RelationTypes_Left.Clear()
        objOList_RelationTypes_Right.Clear()

        objDBLevel_LeftRight.get_Data_ClassRel(objOList_ClassRel, True, False)
        objOList_Classes_Right = objDBLevel_LeftRight.OList_Classes
        objOList_RelationTypes_Right = objDBLevel_LeftRight.OList_RelationTypes
        objOList_ClassRel_LeftRight = objDBLevel_LeftRight.OList_ClassRel_ID

        objOList_ClassRel.Clear()
        objOList_ClassRel.Add(New clsClassRel(Nothing, objOItem_Class.GUID, Nothing, Nothing, Nothing, Nothing, Nothing))

        objDBLevel_RightLeft.get_Data_ClassRel(objOList_ClassRel, True, False)
        objOList_Classes_Left = objDBLevel_RightLeft.OList_Classes
        objOList_RelationTypes_Left = objDBLevel_RightLeft.OList_RelationTypes
        objOList_ClassRel_RightLeft = objDBLevel_RightLeft.OList_ClassRel_ID


    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Application.DoEvents()
        SplashScreen = New SplashScreen_OntologyModule()
        SplashScreen.Show()
        SplashScreen.Refresh()

        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = New clsLocalConfig(New clsGlobals)
        strType_Entry = Nothing
        objOItem_Entry = Nothing
        boolApplyable = False
        set_DBConnection()
        initialize()


    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig, Optional ByVal Type_Entry As String = Nothing, Optional ByVal OItem_Entry As clsOntologyItem = Nothing, Optional Caption As String = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = LocalConfig
        strType_Entry = Type_Entry
        Me.objOItem_Entry = OItem_Entry
        If Not Caption = Nothing Then
            Me.Text = Caption
        End If
        boolApplyable = True
        set_DBConnection()

    End Sub

    Public Sub New(ByVal Globals As clsGlobals, Optional ByVal Type_Entry As String = Nothing, Optional ByVal OItem_Entry As clsOntologyItem = Nothing, Optional Caption As String = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = New clsLocalConfig(Globals)
        strType_Entry = Type_Entry
        Me.objOItem_Entry = OItem_Entry
        If Not Caption = Nothing Then
            Me.Text = Caption
        End If
        boolApplyable = True
        set_DBConnection()

    End Sub

    Private Sub initialize()
        

        objUserControl_TypeTree = New UserControl_TypeTree(objLocalConfig)
        objUserControl_TypeTree.Applyable = boolApplyable
        objUserControl_TypeTree.Dock = DockStyle.Fill
        SplitContainer_TypeToken.Panel1.Controls.Clear()
        SplitContainer_TypeToken.Panel1.Controls.Add(objUserControl_TypeTree)


        objUserControl_OObjectList = New UserControl_OItemList(objLocalConfig)
        objUserControl_OObjectList.Applyable = True
        objUserControl_OObjectList.Dock = DockStyle.Fill
        SplitContainer_Token.Panel1.Controls.Clear()
        SplitContainer_Token.Panel1.Controls.Add(objUserControl_OObjectList)

        objUserControl_ObjectTree = New UserControl_ObjectTree(objLocalConfig)
        objUserControl_ObjectTree.Applyable = True
        objUserControl_ObjectTree.Dock = DockStyle.Fill
        SplitContainer_Token.Panel2.Controls.Clear()
        SplitContainer_Token.Panel2.Controls.Add(objUserControl_ObjectTree)

        If Not strType_Entry Is Nothing Then
            Select Case strType_Entry
                Case objLocalConfig.Globals.Type_Class
                    ToolStripButton_TokenType.Checked = True
                    ToolStripButton_AttributesAndRelations.Checked = False
                    ToolStripButton_Types.Checked = True
                    ToolStripButton_Token.Checked = True
                    ToolStripButton_TokenType.Checked = False

                    objUserControl_TypeTree.initialize_Tree(objOItem_Entry)
                Case objLocalConfig.Globals.Type_AttributeType
                    ToolStripButton_TokenType.Checked = False
                    ToolStripButton_AttributesAndRelations.Checked = True
                    ToolStripButton_AttribRel.Checked = True
                    ToolStripButton_TokenRel.Checked = False
                    objUserControl_TypeTree.initialize_Tree()
                Case objLocalConfig.Globals.Type_RelationType
                    ToolStripButton_TokenType.Checked = False
                    ToolStripButton_AttributesAndRelations.Checked = True
                    ToolStripButton_AttribRel.Checked = False
                    ToolStripButton_TokenRel.Checked = True
                    objUserControl_TypeTree.initialize_Tree()
                Case Else
                    objUserControl_TypeTree.initialize_Tree()
            End Select
        Else
            objUserControl_TypeTree.initialize_Tree()
        End If

        configure_Areas()
    End Sub

    Private Sub Configure_ORelationTypeList(objOItem_RelType As clsOntologyItem)
        If objUserControl_ORelationTypeList Is Nothing Then
            objUserControl_ORelationTypeList = New UserControl_OItemList(objLocalConfig)
            objUserControl_ORelationTypeList.Applyable = True
            objUserControl_ORelationTypeList.Dock = DockStyle.Fill
            Panel_RelationTypes.Controls.Clear()
            objUserControl_ORelationTypeList.initialize(objOItem_RelType)
            Panel_RelationTypes.Controls.Add(objUserControl_ORelationTypeList)

        End If
        
    End Sub

    Private Sub Configure_OAttributeList(objOItem_AttType As clsOntologyItem)
        If objUserControl_OAttributeList Is Nothing Then
            objUserControl_OAttributeList = New UserControl_OItemList(objLocalConfig)
            objUserControl_OAttributeList.Applyable = True
            objUserControl_OAttributeList.Dock = DockStyle.Fill
            Panel_Attributes.Controls.Clear()
            objUserControl_OAttributeList.initialize(objOItem_AttType)
            Panel_Attributes.Controls.Add(objUserControl_OAttributeList)
        End If
        
    End Sub

    Private Sub Configure_ORel()
        If objUserControl_ObjRel Is Nothing Then
            objUserControl_ObjRel = New UserControl_ObjectRel(objLocalConfig)
            objUserControl_ObjRel.Dock = DockStyle.Fill
            SplitContainer_TokAttTokRel.Panel2.Controls.Clear()
            SplitContainer_TokAttTokRel.Panel2.Controls.Add(objUserControl_ObjRel)
        End If
        
    End Sub

    Private Sub Configure_ObjAtt()
        If objUserControl_ObjAtt Is Nothing Then
            objUserControl_ObjAtt = New UserControl_ObjectAtt(objLocalConfig)
            objUserControl_ObjAtt.Dock = DockStyle.Fill
            SplitContainer_AttribRel.Panel2.Controls.Clear()
            SplitContainer_AttribRel.Panel2.Controls.Add(objUserControl_ObjAtt)
        End If
        
    End Sub

    Private Sub Configure_Filter()
        If objUserControl_Filter Is Nothing Then
            objUserControl_Filter = New UserControl_Filter(objLocalConfig)
            objUserControl_Filter.Dock = DockStyle.Fill
            SplitContainer_Filter_Body.Panel1.Controls.Clear()
            SplitContainer_Filter_Body.Panel1.Controls.Add(objUserControl_Filter)
        End If
        
    End Sub

    Private Sub configure_Areas()
        Dim objOItem_RelType As New clsOntologyItem(Nothing, Nothing, objLocalConfig.Globals.Type_RelationType)
        Dim objOItem_AttType As New clsOntologyItem(Nothing, Nothing, objLocalConfig.Globals.Type_AttributeType)

        SplitContainer_Filter_Body.Panel1Collapsed = Not ToolStripButton_Filter.Checked


        SplitContainer2.Panel1Collapsed = Not ToolStripButton_TokenType.Checked
        SplitContainer2.Panel2Collapsed = Not ToolStripButton_AttributesAndRelations.Checked


        ToolStripButton_TokenType.Checked = Not SplitContainer2.Panel1Collapsed
        ToolStripButton_AttributesAndRelations.Checked = Not SplitContainer2.Panel2Collapsed

        SplitContainer_TypeToken.Panel1Collapsed = Not ToolStripButton_Types.Checked
        SplitContainer_TypeToken.Panel2Collapsed = Not ToolStripButton_Token.Checked

        ToolStripButton_Types.Checked = Not SplitContainer_TypeToken.Panel1Collapsed
        ToolStripButton_Token.Checked = Not SplitContainer_TypeToken.Panel2Collapsed

        SplitContainer_Token.Panel2Collapsed = Not ToolStripButton_Tokentree.Checked

        SplitContainer_AttribRelTokenRel.Panel1Collapsed = Not ToolStripButton_AttribRel.Checked
        SplitContainer_AttribRelTokenRel.Panel2Collapsed = Not ToolStripButton_TokenRel.Checked

        ToolStripButton_AttribRel.Checked = Not SplitContainer_AttribRelTokenRel.Panel1Collapsed
        ToolStripButton_TokenRel.Checked = Not SplitContainer_AttribRelTokenRel.Panel2Collapsed

        ToolStripStatusLabel_Database.Text = objLocalConfig.Globals.Index & "@" & objLocalConfig.Globals.Server

        If Not SplitContainer_TokAttTokRel.Panel1Collapsed And Not SplitContainer2.Panel2Collapsed Then

            Configure_ORelationTypeList(objOItem_RelType)



        End If

        If Not SplitContainer_AttribRel.Panel1Collapsed And Not SplitContainer2.Panel2Collapsed Then
            Configure_OAttributeList(objOItem_AttType)

        End If

        If Not SplitContainer_TokAttTokRel.Panel2Collapsed And Not SplitContainer2.Panel2Collapsed Then

            Configure_ORel()

        End If


        If Not SplitContainer_AttribRel.Panel2Collapsed And Not SplitContainer2.Panel2Collapsed Then

            Configure_ObjAtt()


        End If

        If Not SplitContainer_Filter_Body.Panel1Collapsed Then


            Configure_Filter()
        End If


        initialize_OTree()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Objects = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ObjectRel = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Other = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Work = New clsDBLevel(objLocalConfig.Globals)
        objReport = New clsReport(objLocalConfig)
    End Sub


    Private Sub ToolStripButton_Types_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton_Types.Click
        configure_Areas()
    End Sub

    Private Sub ToolStripButton_Token_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton_Token.Click
        configure_Areas()
    End Sub


    Private Sub ToolStripButton_Filter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Filter.Click
        configure_Areas()
    End Sub

    Private Sub ToolStripButton_AttributesAndRelations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_AttributesAndRelations.Click
        configure_Areas()
    End Sub

    Private Sub ToolStripButton_AttribRel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_AttribRel.Click
        configure_Areas()
    End Sub

    Private Sub ToolStripButton_TokenRel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_TokenRel.Click
        configure_Areas()
    End Sub

    Private Sub ToolStripButton_Tokentree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Tokentree.Click
        configure_Areas()
    End Sub

    Private Sub SyncToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SyncToolStripMenuItem.Click
        objReport.sync_SQLDB()
    End Sub

    Private Sub ToolStripButton_TokenType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton_TokenType.Click

        configure_Areas()
    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not SplashScreen Is Nothing Then
            SplashScreen.Close()
        End If
        initialize()
    End Sub

    Private Sub OntologyConfiguratorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OntologyConfiguratorToolStripMenuItem.Click
        objFrm_OntologyConfigurator = New frmOntologyConfigurator(objLocalConfig.Globals)
        objFrm_OntologyConfigurator.ShowDialog(Me)
    End Sub

    Private Sub ToolStripStatusLabel_TokenRelLeft_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel_TokenRelLeft.Click
        objUserControl_ObjRel.clear_Left()

        configureRelationLabel()
    End Sub

    Private Sub ToolStripStatusLabel_TokenRelRelation_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel_TokenRelRelation.Click
        objUserControl_ObjRel.clear_RelationType()

        configureRelationLabel()
    End Sub

    Private Sub ToolStripStatusLabel_TokenRelRight_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel_TokenRelRight.Click
        objUserControl_ObjRel.clear_Other()

        configureRelationLabel()
    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        AboutBox = New AboutBox_OntologyItem()
        AboutBox.ShowDialog(Me)
    End Sub

    Private Sub ApplyMappingToolStripMenuItem_Click( sender As Object,  e As EventArgs) Handles ApplyMappingToolStripMenuItem.Click
        objFrm_OntologyItem = New frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class, objLocalConfig.Globals.Class_OntologyMapping)
        objFrm_OntologyItem.Applyable = True
        objFrm_OntologyItem.ShowDialog(Me)
        
        If objFrm_OntologyItem.DialogResult = DialogResult.OK Then
            If objFrm_OntologyItem.Type_Applied = objLocalConfig.Globals.Type_Object Then
                If objFrm_OntologyItem.OList_Simple.Count = 1 Then
                    Dim objOItem_Selected = objFrm_OntologyItem.OList_Simple.First()

                    If objOItem_Selected.GUID_Parent = objLocalConfig.Globals.Class_OntologyMapping.GUID Then
                        objMappingWork = new clsMappingWork(objLocalConfig.Globals)
                        dim objOItem_Result =  objMappingWork.MapItems(objOItem_Selected)
                    Else 
                        MsgBox("Wählen Sie bitte nur ein Mapping-Object aus!",MsgBoxStyle.Information)
                    End If
                Else 
                    MsgBox("Wählen Sie bitte nur ein Mapping-Object aus!",MsgBoxStyle.Information)
                End If
            Else 
                MsgBox("Wählen Sie bitte nur ein Mapping-Object aus!",MsgBoxStyle.Information)
            End If

        End If
            

    End Sub

    Private Sub BackupOntologyGraphToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupOntologyGraphToolStripMenuItem.Click
        Dim objExport As New clsExport(objLocalConfig.Globals)
        If MsgBox("Wollen Sie wirklich den gesamten ontologischen Graphen sichern?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If FolderBrowserDialog_GraphExportImport.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim objOItemResult = objExport.ExportOntologyGraph(FolderBrowserDialog_GraphExportImport.SelectedPath)
                If objOItemResult.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    MsgBox("Die Strukturen wurden erfolgreich exportiert!", MsgBoxStyle.Information)
                Else
                    MsgBox("Die Strukturen konnten nicht erfolgreich exportiert werden!", MsgBoxStyle.Critical)
                End If
            End If

        End If
    End Sub

    Private Sub ImportOntologyStructuresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportOntologyStructuresToolStripMenuItem.Click
        Dim objImport As New clsImport(objLocalConfig.Globals)
        If MsgBox("Wollen Sie wirklich Strukturen importieren?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If FolderBrowserDialog_GraphExportImport.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim objOItemResult = objImport.ImportXMLFiles(FolderBrowserDialog_GraphExportImport.SelectedPath)
                If objOItemResult.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    MsgBox("Die Strukturen wurden erfolgreich importiert!", MsgBoxStyle.Information)
                Else
                    MsgBox("Die Strukturen konnten nicht erfolgreich importiert werden!", MsgBoxStyle.Critical)
                End If
            End If

        End If
    End Sub

    Private Sub RepairRelationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RepairRelationsToolStripMenuItem.Click
        Dim objOItem_Result = objDBLevel_Objects.get_Data_Objects()
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOItem_Result = objDBLevel_ObjectRel.get_Data_ObjectRel(Nothing)



            Dim objRelations = (From objRel In objDBLevel_ObjectRel.OList_ObjectRel_ID
                                Group Join objObject In objDBLevel_Objects.OList_Objects On objRel.ID_Object Equals objObject.GUID Into objObjects = Group
                                From objObject In objObjects.DefaultIfEmpty()
                                Where objObject Is Nothing
                                Group objRel By objRel.ID_Object Into Group
                                Select New clsObjectRel With {.ID_Object = ID_Object}).ToList()

            If (objRelations.Any()) Then
                objOItem_Result = objDBLevel_Work.del_ObjectRel(objRelations)

            End If

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                Dim objORel = objDBLevel_ObjectRel.OList_ObjectRel_ID.Where(Function(ore) ore.Ontology = objLocalConfig.Globals.Type_Object).ToList()

                objRelations = (From objRel In objORel
                                Group Join objObject In objDBLevel_Objects.OList_Objects On objRel.ID_Other Equals objObject.GUID Into objObjects = Group
                                From objObject In objObjects.DefaultIfEmpty()
                                Where objObject Is Nothing
                                Group objRel By objRel.ID_Other Into Group
                                Select New clsObjectRel With {.ID_Other = ID_Other}).ToList()

                If (objRelations.Any()) Then
                    objOItem_Result = objDBLevel_Work.del_ObjectRel(objRelations)


                End If

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                    objOItem_Result = objDBLevel_Other.get_Data_AttributeType()
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objORel = objDBLevel_ObjectRel.OList_ObjectRel_ID.Where(Function(ore) ore.Ontology = objLocalConfig.Globals.Type_AttributeType).ToList()

                        objRelations = (From objRel In objORel
                                Group Join objObject In objDBLevel_Other.OList_AttributeTypes On objRel.ID_Other Equals objObject.GUID Into objObjects = Group
                                From objObject In objObjects.DefaultIfEmpty()
                                Where objObject Is Nothing
                                Group objRel By objRel.ID_Other Into Group
                                Select New clsObjectRel With {.ID_Other = ID_Other}).ToList()

                        If objRelations.Any() Then
                            objOItem_Result = objDBLevel_Work.del_ObjectRel(objRelations)
                            End If
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objOItem_Result = objDBLevel_Other.get_Data_RelationTypes()

                            objORel = objDBLevel_ObjectRel.OList_ObjectRel_ID.Where(Function(ore) ore.Ontology = objLocalConfig.Globals.Type_RelationType).ToList()

                            objRelations = (From objRel In objORel
                                    Group Join objObject In objDBLevel_Other.OList_RelationTypes On objRel.ID_Other Equals objObject.GUID Into objObjects = Group
                                    From objObject In objObjects.DefaultIfEmpty()
                                    Where objObject Is Nothing
                                    Group objRel By objRel.ID_Other Into Group
                                    Select New clsObjectRel With {.ID_Other = ID_Other}).ToList()

                            If objRelations.Any() Then
                                objOItem_Result = objDBLevel_Work.del_ObjectRel(objRelations)
                                End If

                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objOItem_Result = objDBLevel_Other.get_Data_Classes()

                                objORel = objDBLevel_ObjectRel.OList_ObjectRel_ID.Where(Function(ore) ore.Ontology = objLocalConfig.Globals.Type_Class).ToList()

                                objRelations = (From objRel In objORel
                                        Group Join objObject In objDBLevel_Other.OList_Classes On objRel.ID_Other Equals objObject.GUID Into objObjects = Group
                                        From objObject In objObjects.DefaultIfEmpty()
                                        Where objObject Is Nothing
                                        Group objRel By objRel.ID_Other Into Group
                                        Select New clsObjectRel With {.ID_Other = ID_Other}).ToList()

                                If objRelations.Any() Then
                                    objOItem_Result = objDBLevel_Work.del_ObjectRel(objRelations)
                                    End If

                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objOItem_Result = objDBLevel_ObjectRel.get_Data_ObjectAtt(Nothing)

                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                                        Dim objOARelations = (From objOArel In objDBLevel_ObjectRel.OList_ObjectAtt_ID
                                                        Group Join objObject In objDBLevel_Objects.OList_Objects On objOArel.ID_Object Equals objObject.GUID Into objObjects = Group
                                                        From objObject In objObjects.DefaultIfEmpty
                                                        Where objObject Is Nothing
                                                        Group objOArel By objOArel.ID_Attribute Into Group
                                                        Select New clsObjectAtt With {.ID_Attribute = ID_Attribute}).ToList()

                                        If (objOARelations.Any()) Then
                                            objOItem_Result = objDBLevel_Work.del_ObjectAtt(objOARelations)
                                        End If


                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                                            objOItem_Result = objDBLevel_Other.get_Data_AttributeType()

                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                objOARelations = (From objOArel In objDBLevel_ObjectRel.OList_ObjectAtt_ID
                                                              Group Join objAttribute In objDBLevel_Other.OList_AttributeTypes On objOArel.ID_AttributeType Equals objAttribute.GUID Into objAttributes = Group
                                                              From objAttribute In objAttributes.DefaultIfEmpty
                                                              Where objAttribute Is Nothing
                                                              Group objOArel By objOArel.ID_Attribute Into Group
                                                              Select New clsObjectAtt With {.ID_Attribute = ID_Attribute}).ToList()

                                                If objOARelations.Any() Then
                                                    objOItem_Result = objDBLevel_Work.del_ObjectAtt(objOARelations)
                                                End If

                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                    MsgBox("Alle Fehlerhaften Beziehungen wurden gelöscht!", MsgBoxStyle.Information)
                                                    End If
                                            Else

                                                MsgBox("Die Beziehungen konnten nicht ermittelt werden!", MsgBoxStyle.Critical)
                                                End If




                                        Else
                                            MsgBox("Die Beziehungen konnten nicht ermittelt werden!", MsgBoxStyle.Critical)
                                            End If
                                    Else
                                        MsgBox("Die Beziehungen konnten nicht ermittelt werden!", MsgBoxStyle.Critical)
                                        End If



                                Else
                                    MsgBox("Die Beziehungen konnten nicht ermittelt werden!", MsgBoxStyle.Critical)
                                    End If
                            Else
                                MsgBox("Die Beziehungen konnten nicht ermittelt werden!", MsgBoxStyle.Critical)
                                End If
                        Else
                            MsgBox("Die Beziehungen konnten nicht ermittelt werden!", MsgBoxStyle.Critical)
                            End If

                    Else
                        MsgBox("Die Beziehungen konnten nicht ermittelt werden!", MsgBoxStyle.Critical)
                        End If

                Else
                    MsgBox("Die Beziehungen konnten nicht ermittelt werden!", MsgBoxStyle.Critical)
                    End If
            Else
                MsgBox("Die Beziehungen konnten nicht ermittelt werden!", MsgBoxStyle.Critical)
                End If
        Else
            MsgBox("Die Objekte konnten nicht ermittelt werden!", MsgBoxStyle.Critical)
        End If


    End Sub
End Class
