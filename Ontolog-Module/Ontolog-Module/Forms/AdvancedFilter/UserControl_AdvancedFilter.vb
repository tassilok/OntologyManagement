Imports OntologyClasses.BaseClasses
Public Class UserControl_AdvancedFilter
    Private objLocalConfig As clsLocalConfig

    Private objOItem_Object As clsOntologyItem
    Private objOItem_Class As clsOntologyItem
    Private objOItem_RelationType As clsOntologyItem

    Private objFrm_OntologyModule As frmMain

    Public Event AddItems
    Public Event Applyable
    Public Event NotApplyable

    Public ReadOnly Property NullRelation As Boolean
        Get
            Return ToolStripButton_Null.Checked
        End Get
    End Property

    Public Property OItem_Class() As clsOntologyItem
        get
            Return objOItem_Class
        End Get
        Set(value As clsOntologyItem)
            objOItem_Class = value
            ToolStripButton_AddRelations.Enabled = False
        End Set
    End Property

    Public Property OItem_RelationType As clsOntologyItem
        get
            Return objOItem_RelationType
        End Get
        Set(value As clsOntologyItem)
            objOItem_RelationType = value
            ToolStripButton_AddRelations.Enabled = True
            Configure_Controls()
        End Set
    End Property

    Public ReadOnly Property OItem_Object As clsOntologyItem
        Get
            Return objOItem_Object
        End Get
    End Property

    Public sub EnableAdd()
        ToolStripButton_AddRelations.Enabled = True
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)
        
        ' This call is required by the designer.
        InitializeComponent()
        
        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = LocalConfig
        Initialize()
    End Sub

    Public Sub New(Globals As clsGlobals)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = New clsLocalConfig(Globals)
        Initialize()
    End Sub

    Public sub Initialize_Relation(OItem_Class As clsOntologyItem, OItem_RelationType As clsOntologyItem)
        RaiseEvent NotApplyable
        objOItem_Class = OItem_Class
        objOItem_RelationType = OItem_RelationType
        objOItem_Object = Nothing

        CleanControls()

        Configure_Controls()
        
    End Sub

    Private sub Initialize()
        CleanControls()
    End Sub

    Public sub Configure_Controls()
        objOItem_Object = Nothing
        
        TextBox_Objects.Text = ""
        Button_RemoveObject.Enabled = False

        If Not objOItem_Class Is Nothing Then
            TextBox_Class.Text = objOItem_Class.Name    
            Button_RemoveClass.Enabled = True
        Else 
            TextBox_Class.Text = ""
            Button_RemoveClass.Enabled = False
        End If
        
        If Not objOItem_RelationType Is Nothing Then
            TextBox_RelationType.Text = objOItem_RelationType.Name
            Button_RemoveRelationType.Enabled = True
        Else 
            TextBox_RelationType.Text = ""
            Button_RemoveRelationType.Enabled = False
        End If
        
         If MsgBox("Wollen Sie ein Objekt der Klasse auswählen?",MessageBoxButtons.YesNo,"Objekt auswählen?") = MsgBoxResult.Yes Then
            objFrm_OntologyModule = new frmMain(objLocalConfig,objLocalConfig.Globals.Type_Class,objOItem_Class)
            objFrm_OntologyModule.ShowDialog(Me)
            If objFrm_OntologyModule.DialogResult = DialogResult.OK Then
                If objFrm_OntologyModule.Type_Applied = objLocalConfig.Globals.Type_Object Then
                    If objFrm_OntologyModule.OList_Simple.Count = 1 Then
                        objOItem_Object = objFrm_OntologyModule.OList_Simple(0)
                        If Not objOItem_Object.GUID_Parent = objOItem_Class.GUID Then
                            MsgBox("Wählen Sie bitte ein Object vom Typ " & objOItem_Class.Name & " auswählen!",MsgBoxStyle.Information) 
                            objOItem_Object = Nothing
                        Else 
                            TextBox_Objects.Text = objOItem_Object.Name
                        End If
                    Else 
                        MsgBox("Wählen Sie bitte ein Object vom Typ " & objOItem_Class.Name & " auswählen!",MsgBoxStyle.Information) 
                    End If
                Else 
                    MsgBox("Wählen Sie bitte ein Object vom Typ " & objOItem_Class.Name & " auswählen!",MsgBoxStyle.Information) 
                End If
            End If
        End If
        If Not objOItem_Class Is Nothing And Not objOItem_RelationType Is Nothing Then
            RaiseEvent  Applyable
        End If
    End Sub

    Private sub CleanControls()
        ToolStripButton_AddRelations.Enabled = False
        TextBox_Class.Text = ""
        TextBox_Objects.Text = ""
        TextBox_RelationType.Text = ""
        Button_RemoveClass.Enabled = False
        Button_RemoveObject.Enabled = False
        Button_RemoveRelationType.Enabled = False
    End Sub

    Private Sub ToolStripButton_AddRelations_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_AddRelations.Click
        RaiseEvent AddItems
    End Sub
End Class
