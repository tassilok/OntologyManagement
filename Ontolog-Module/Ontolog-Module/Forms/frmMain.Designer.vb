<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel_DatabaseLBL = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_Database = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_TokenAttLBL = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_TokenAtt_Attribute = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_TokenAttSeperator = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_TokenAtt_Token = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_RelationLBL = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_TokenRelLeft = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_Seperator1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_TokenRelRelation = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_Seperator2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_TokenRelRight = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_RelationDoneLBL = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_RelationDone = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer_Filter_Body = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer_TypeToken = New System.Windows.Forms.SplitContainer()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.SplitContainer_Token = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer_AttribRelTokenRel = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer_AttribRel = New System.Windows.Forms.SplitContainer()
        Me.Panel_Attributes = New System.Windows.Forms.Panel()
        Me.Label_AttributesLBL = New System.Windows.Forms.Label()
        Me.SplitContainer_TokAttTokRel = New System.Windows.Forms.SplitContainer()
        Me.Panel_RelationTypes = New System.Windows.Forms.Panel()
        Me.Label_RelationTypes = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_TokenType = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Types = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Token = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Tokentree = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_AttributesAndRelations = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_AttribRel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_TokenRel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Filter = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_ModuleView = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SyncToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OntologyConfiguratorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ApplyMappingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HilfeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip_TokAtt = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyValToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RelateToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip_TokRel = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetOrderIDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetRelationTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModuleEditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripComboBox_ModuleEdit = New System.Windows.Forms.ToolStripComboBox()
        Me.ModuleMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripComboBox_ModuleMenu = New System.Windows.Forms.ToolStripComboBox()
        Me.CopyValToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EqualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DifferentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContainsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox_TokRelContains = New System.Windows.Forms.ToolStripTextBox()
        Me.GreaterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LessThanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearFilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RelateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer_TokenAttribute = New System.Windows.Forms.Timer(Me.components)
        Me.BindingSource_TokenRel = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSource_TokenAtt = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.LeftToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer_Filter_Body, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_Filter_Body.Panel2.SuspendLayout()
        Me.SplitContainer_Filter_Body.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer_TypeToken, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_TypeToken.Panel1.SuspendLayout()
        Me.SplitContainer_TypeToken.Panel2.SuspendLayout()
        Me.SplitContainer_TypeToken.SuspendLayout()
        CType(Me.SplitContainer_Token, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_Token.SuspendLayout()
        CType(Me.SplitContainer_AttribRelTokenRel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_AttribRelTokenRel.Panel1.SuspendLayout()
        Me.SplitContainer_AttribRelTokenRel.Panel2.SuspendLayout()
        Me.SplitContainer_AttribRelTokenRel.SuspendLayout()
        CType(Me.SplitContainer_AttribRel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_AttribRel.Panel1.SuspendLayout()
        Me.SplitContainer_AttribRel.SuspendLayout()
        CType(Me.SplitContainer_TokAttTokRel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_TokAttTokRel.Panel1.SuspendLayout()
        Me.SplitContainer_TokAttTokRel.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ContextMenuStrip_TokAtt.SuspendLayout()
        Me.ContextMenuStrip_TokRel.SuspendLayout()
        CType(Me.BindingSource_TokenRel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource_TokenAtt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.StatusStrip1)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.SplitContainer_Filter_Body)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(1377, 554)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        '
        'ToolStripContainer1.LeftToolStripPanel
        '
        Me.ToolStripContainer1.LeftToolStripPanel.Controls.Add(Me.ToolStrip1)
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(1401, 602)
        Me.ToolStripContainer1.TabIndex = 2
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.MenuStrip1)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel_DatabaseLBL, Me.ToolStripStatusLabel_Database, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel_TokenAttLBL, Me.ToolStripStatusLabel_TokenAtt_Attribute, Me.ToolStripStatusLabel_TokenAttSeperator, Me.ToolStripStatusLabel_TokenAtt_Token, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel_RelationLBL, Me.ToolStripStatusLabel_TokenRelLeft, Me.ToolStripStatusLabel_Seperator1, Me.ToolStripStatusLabel_TokenRelRelation, Me.ToolStripStatusLabel_Seperator2, Me.ToolStripStatusLabel_TokenRelRight, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel_RelationDoneLBL, Me.ToolStripStatusLabel_RelationDone})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1401, 24)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel_DatabaseLBL
        '
        Me.ToolStripStatusLabel_DatabaseLBL.Name = "ToolStripStatusLabel_DatabaseLBL"
        Me.ToolStripStatusLabel_DatabaseLBL.Size = New System.Drawing.Size(58, 19)
        Me.ToolStripStatusLabel_DatabaseLBL.Text = "Database:"
        '
        'ToolStripStatusLabel_Database
        '
        Me.ToolStripStatusLabel_Database.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel_Database.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.ToolStripStatusLabel_Database.Name = "ToolStripStatusLabel_Database"
        Me.ToolStripStatusLabel_Database.Size = New System.Drawing.Size(16, 19)
        Me.ToolStripStatusLabel_Database.Text = "-"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(10, 19)
        Me.ToolStripStatusLabel3.Text = "|"
        '
        'ToolStripStatusLabel_TokenAttLBL
        '
        Me.ToolStripStatusLabel_TokenAttLBL.Name = "ToolStripStatusLabel_TokenAttLBL"
        Me.ToolStripStatusLabel_TokenAttLBL.Size = New System.Drawing.Size(95, 19)
        Me.ToolStripStatusLabel_TokenAttLBL.Text = "Token-Attribute:"
        '
        'ToolStripStatusLabel_TokenAtt_Attribute
        '
        Me.ToolStripStatusLabel_TokenAtt_Attribute.Name = "ToolStripStatusLabel_TokenAtt_Attribute"
        Me.ToolStripStatusLabel_TokenAtt_Attribute.Size = New System.Drawing.Size(12, 19)
        Me.ToolStripStatusLabel_TokenAtt_Attribute.Text = "-"
        '
        'ToolStripStatusLabel_TokenAttSeperator
        '
        Me.ToolStripStatusLabel_TokenAttSeperator.Name = "ToolStripStatusLabel_TokenAttSeperator"
        Me.ToolStripStatusLabel_TokenAttSeperator.Size = New System.Drawing.Size(12, 19)
        Me.ToolStripStatusLabel_TokenAttSeperator.Text = "/"
        '
        'ToolStripStatusLabel_TokenAtt_Token
        '
        Me.ToolStripStatusLabel_TokenAtt_Token.Name = "ToolStripStatusLabel_TokenAtt_Token"
        Me.ToolStripStatusLabel_TokenAtt_Token.Size = New System.Drawing.Size(12, 19)
        Me.ToolStripStatusLabel_TokenAtt_Token.Text = "-"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(10, 19)
        Me.ToolStripStatusLabel4.Text = "|"
        '
        'ToolStripStatusLabel_RelationLBL
        '
        Me.ToolStripStatusLabel_RelationLBL.Name = "ToolStripStatusLabel_RelationLBL"
        Me.ToolStripStatusLabel_RelationLBL.Size = New System.Drawing.Size(53, 19)
        Me.ToolStripStatusLabel_RelationLBL.Text = "Relation:"
        '
        'ToolStripStatusLabel_TokenRelLeft
        '
        Me.ToolStripStatusLabel_TokenRelLeft.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel_TokenRelLeft.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.ToolStripStatusLabel_TokenRelLeft.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripStatusLabel_TokenRelLeft.Name = "ToolStripStatusLabel_TokenRelLeft"
        Me.ToolStripStatusLabel_TokenRelLeft.Size = New System.Drawing.Size(16, 19)
        Me.ToolStripStatusLabel_TokenRelLeft.Text = "-"
        '
        'ToolStripStatusLabel_Seperator1
        '
        Me.ToolStripStatusLabel_Seperator1.Name = "ToolStripStatusLabel_Seperator1"
        Me.ToolStripStatusLabel_Seperator1.Size = New System.Drawing.Size(12, 19)
        Me.ToolStripStatusLabel_Seperator1.Text = "/"
        '
        'ToolStripStatusLabel_TokenRelRelation
        '
        Me.ToolStripStatusLabel_TokenRelRelation.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel_TokenRelRelation.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.ToolStripStatusLabel_TokenRelRelation.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripStatusLabel_TokenRelRelation.Name = "ToolStripStatusLabel_TokenRelRelation"
        Me.ToolStripStatusLabel_TokenRelRelation.Size = New System.Drawing.Size(16, 19)
        Me.ToolStripStatusLabel_TokenRelRelation.Text = "-"
        '
        'ToolStripStatusLabel_Seperator2
        '
        Me.ToolStripStatusLabel_Seperator2.Name = "ToolStripStatusLabel_Seperator2"
        Me.ToolStripStatusLabel_Seperator2.Size = New System.Drawing.Size(12, 19)
        Me.ToolStripStatusLabel_Seperator2.Text = "/"
        '
        'ToolStripStatusLabel_TokenRelRight
        '
        Me.ToolStripStatusLabel_TokenRelRight.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel_TokenRelRight.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.ToolStripStatusLabel_TokenRelRight.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripStatusLabel_TokenRelRight.Name = "ToolStripStatusLabel_TokenRelRight"
        Me.ToolStripStatusLabel_TokenRelRight.Size = New System.Drawing.Size(16, 19)
        Me.ToolStripStatusLabel_TokenRelRight.Text = "-"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(10, 19)
        Me.ToolStripStatusLabel2.Text = "|"
        '
        'ToolStripStatusLabel_RelationDoneLBL
        '
        Me.ToolStripStatusLabel_RelationDoneLBL.Name = "ToolStripStatusLabel_RelationDoneLBL"
        Me.ToolStripStatusLabel_RelationDoneLBL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripStatusLabel_RelationDoneLBL.Size = New System.Drawing.Size(92, 19)
        Me.ToolStripStatusLabel_RelationDoneLBL.Text = "Relation (Done):"
        '
        'ToolStripStatusLabel_RelationDone
        '
        Me.ToolStripStatusLabel_RelationDone.Name = "ToolStripStatusLabel_RelationDone"
        Me.ToolStripStatusLabel_RelationDone.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripStatusLabel_RelationDone.Size = New System.Drawing.Size(12, 19)
        Me.ToolStripStatusLabel_RelationDone.Text = "-"
        '
        'SplitContainer_Filter_Body
        '
        Me.SplitContainer_Filter_Body.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer_Filter_Body.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_Filter_Body.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_Filter_Body.Name = "SplitContainer_Filter_Body"
        Me.SplitContainer_Filter_Body.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer_Filter_Body.Panel2
        '
        Me.SplitContainer_Filter_Body.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer_Filter_Body.Size = New System.Drawing.Size(1377, 554)
        Me.SplitContainer_Filter_Body.SplitterDistance = 112
        Me.SplitContainer_Filter_Body.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer_TypeToken)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer_AttribRelTokenRel)
        Me.SplitContainer2.Size = New System.Drawing.Size(1377, 438)
        Me.SplitContainer2.SplitterDistance = 662
        Me.SplitContainer2.TabIndex = 0
        '
        'SplitContainer_TypeToken
        '
        Me.SplitContainer_TypeToken.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer_TypeToken.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_TypeToken.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_TypeToken.Name = "SplitContainer_TypeToken"
        '
        'SplitContainer_TypeToken.Panel1
        '
        Me.SplitContainer_TypeToken.Panel1.Controls.Add(Me.ToolStrip2)
        '
        'SplitContainer_TypeToken.Panel2
        '
        Me.SplitContainer_TypeToken.Panel2.Controls.Add(Me.SplitContainer_Token)
        Me.SplitContainer_TypeToken.Size = New System.Drawing.Size(662, 438)
        Me.SplitContainer_TypeToken.SplitterDistance = 185
        Me.SplitContainer_TypeToken.TabIndex = 0
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 409)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(181, 25)
        Me.ToolStrip2.TabIndex = 0
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'SplitContainer_Token
        '
        Me.SplitContainer_Token.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer_Token.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_Token.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_Token.Name = "SplitContainer_Token"
        Me.SplitContainer_Token.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.SplitContainer_Token.Size = New System.Drawing.Size(473, 438)
        Me.SplitContainer_Token.SplitterDistance = 304
        Me.SplitContainer_Token.TabIndex = 0
        '
        'SplitContainer_AttribRelTokenRel
        '
        Me.SplitContainer_AttribRelTokenRel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer_AttribRelTokenRel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_AttribRelTokenRel.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_AttribRelTokenRel.Name = "SplitContainer_AttribRelTokenRel"
        '
        'SplitContainer_AttribRelTokenRel.Panel1
        '
        Me.SplitContainer_AttribRelTokenRel.Panel1.Controls.Add(Me.SplitContainer_AttribRel)
        '
        'SplitContainer_AttribRelTokenRel.Panel2
        '
        Me.SplitContainer_AttribRelTokenRel.Panel2.Controls.Add(Me.SplitContainer_TokAttTokRel)
        Me.SplitContainer_AttribRelTokenRel.Size = New System.Drawing.Size(711, 438)
        Me.SplitContainer_AttribRelTokenRel.SplitterDistance = 333
        Me.SplitContainer_AttribRelTokenRel.TabIndex = 0
        '
        'SplitContainer_AttribRel
        '
        Me.SplitContainer_AttribRel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer_AttribRel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_AttribRel.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_AttribRel.Name = "SplitContainer_AttribRel"
        Me.SplitContainer_AttribRel.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer_AttribRel.Panel1
        '
        Me.SplitContainer_AttribRel.Panel1.Controls.Add(Me.Panel_Attributes)
        Me.SplitContainer_AttribRel.Panel1.Controls.Add(Me.Label_AttributesLBL)
        Me.SplitContainer_AttribRel.Size = New System.Drawing.Size(333, 438)
        Me.SplitContainer_AttribRel.SplitterDistance = 222
        Me.SplitContainer_AttribRel.TabIndex = 0
        '
        'Panel_Attributes
        '
        Me.Panel_Attributes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Attributes.Location = New System.Drawing.Point(4, 21)
        Me.Panel_Attributes.Name = "Panel_Attributes"
        Me.Panel_Attributes.Size = New System.Drawing.Size(322, 194)
        Me.Panel_Attributes.TabIndex = 1
        '
        'Label_AttributesLBL
        '
        Me.Label_AttributesLBL.AutoSize = True
        Me.Label_AttributesLBL.Location = New System.Drawing.Point(4, 4)
        Me.Label_AttributesLBL.Name = "Label_AttributesLBL"
        Me.Label_AttributesLBL.Size = New System.Drawing.Size(54, 13)
        Me.Label_AttributesLBL.TabIndex = 0
        Me.Label_AttributesLBL.Text = "Attributes:"
        '
        'SplitContainer_TokAttTokRel
        '
        Me.SplitContainer_TokAttTokRel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer_TokAttTokRel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_TokAttTokRel.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_TokAttTokRel.Name = "SplitContainer_TokAttTokRel"
        Me.SplitContainer_TokAttTokRel.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer_TokAttTokRel.Panel1
        '
        Me.SplitContainer_TokAttTokRel.Panel1.Controls.Add(Me.Panel_RelationTypes)
        Me.SplitContainer_TokAttTokRel.Panel1.Controls.Add(Me.Label_RelationTypes)
        Me.SplitContainer_TokAttTokRel.Size = New System.Drawing.Size(374, 438)
        Me.SplitContainer_TokAttTokRel.SplitterDistance = 223
        Me.SplitContainer_TokAttTokRel.TabIndex = 0
        '
        'Panel_RelationTypes
        '
        Me.Panel_RelationTypes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_RelationTypes.Location = New System.Drawing.Point(3, 21)
        Me.Panel_RelationTypes.Name = "Panel_RelationTypes"
        Me.Panel_RelationTypes.Size = New System.Drawing.Size(364, 194)
        Me.Panel_RelationTypes.TabIndex = 3
        '
        'Label_RelationTypes
        '
        Me.Label_RelationTypes.AutoSize = True
        Me.Label_RelationTypes.Location = New System.Drawing.Point(3, 4)
        Me.Label_RelationTypes.Name = "Label_RelationTypes"
        Me.Label_RelationTypes.Size = New System.Drawing.Size(78, 13)
        Me.Label_RelationTypes.TabIndex = 2
        Me.Label_RelationTypes.Text = "RelationTypes:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_TokenType, Me.ToolStripButton_Types, Me.ToolStripButton_Token, Me.ToolStripButton_Tokentree, Me.ToolStripButton_AttributesAndRelations, Me.ToolStripButton_AttribRel, Me.ToolStripButton_TokenRel, Me.ToolStripButton_Filter, Me.ToolStripSeparator1, Me.ToolStripButton_ModuleView})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(24, 223)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripButton_TokenType
        '
        Me.ToolStripButton_TokenType.Checked = True
        Me.ToolStripButton_TokenType.CheckOnClick = True
        Me.ToolStripButton_TokenType.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripButton_TokenType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_TokenType.Image = CType(resources.GetObject("ToolStripButton_TokenType.Image"), System.Drawing.Image)
        Me.ToolStripButton_TokenType.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_TokenType.Name = "ToolStripButton_TokenType"
        Me.ToolStripButton_TokenType.Size = New System.Drawing.Size(22, 20)
        Me.ToolStripButton_TokenType.Text = "ToolStripButton1"
        '
        'ToolStripButton_Types
        '
        Me.ToolStripButton_Types.Checked = True
        Me.ToolStripButton_Types.CheckOnClick = True
        Me.ToolStripButton_Types.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripButton_Types.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Types.Image = Global.Ontology_Module.My.Resources.Resources.Types_Closed
        Me.ToolStripButton_Types.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Types.Name = "ToolStripButton_Types"
        Me.ToolStripButton_Types.Size = New System.Drawing.Size(22, 20)
        Me.ToolStripButton_Types.Text = "ToolStripButton1"
        Me.ToolStripButton_Types.ToolTipText = "Toggle Typetree"
        '
        'ToolStripButton_Token
        '
        Me.ToolStripButton_Token.Checked = True
        Me.ToolStripButton_Token.CheckOnClick = True
        Me.ToolStripButton_Token.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripButton_Token.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Token.Image = Global.Ontology_Module.My.Resources.Resources.Vogelschwarm
        Me.ToolStripButton_Token.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Token.Name = "ToolStripButton_Token"
        Me.ToolStripButton_Token.Size = New System.Drawing.Size(22, 20)
        Me.ToolStripButton_Token.Text = "ToolStripButton2"
        Me.ToolStripButton_Token.ToolTipText = "Toggle Tokenlist"
        '
        'ToolStripButton_Tokentree
        '
        Me.ToolStripButton_Tokentree.CheckOnClick = True
        Me.ToolStripButton_Tokentree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Tokentree.Image = Global.Ontology_Module.My.Resources.Resources.XSDSchema_SequenceIcon
        Me.ToolStripButton_Tokentree.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Tokentree.Name = "ToolStripButton_Tokentree"
        Me.ToolStripButton_Tokentree.Size = New System.Drawing.Size(22, 20)
        Me.ToolStripButton_Tokentree.Text = "x_Tokentree"
        '
        'ToolStripButton_AttributesAndRelations
        '
        Me.ToolStripButton_AttributesAndRelations.CheckOnClick = True
        Me.ToolStripButton_AttributesAndRelations.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_AttributesAndRelations.Image = Global.Ontology_Module.My.Resources.Resources.NavForward
        Me.ToolStripButton_AttributesAndRelations.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_AttributesAndRelations.Name = "ToolStripButton_AttributesAndRelations"
        Me.ToolStripButton_AttributesAndRelations.Size = New System.Drawing.Size(22, 20)
        Me.ToolStripButton_AttributesAndRelations.Text = "ToolStripButton1"
        '
        'ToolStripButton_AttribRel
        '
        Me.ToolStripButton_AttribRel.Checked = True
        Me.ToolStripButton_AttribRel.CheckOnClick = True
        Me.ToolStripButton_AttribRel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripButton_AttribRel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_AttribRel.Image = Global.Ontology_Module.My.Resources.Resources.Attributes_bamboo_danny_allen_r
        Me.ToolStripButton_AttribRel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_AttribRel.Name = "ToolStripButton_AttribRel"
        Me.ToolStripButton_AttribRel.Size = New System.Drawing.Size(22, 20)
        Me.ToolStripButton_AttribRel.Text = "ToolStripButton3"
        Me.ToolStripButton_AttribRel.ToolTipText = "Toggle Attributes and Relations"
        '
        'ToolStripButton_TokenRel
        '
        Me.ToolStripButton_TokenRel.Checked = True
        Me.ToolStripButton_TokenRel.CheckOnClick = True
        Me.ToolStripButton_TokenRel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripButton_TokenRel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_TokenRel.Image = Global.Ontology_Module.My.Resources.Resources.RelationTypes_gpride_jean_victor_balin_
        Me.ToolStripButton_TokenRel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_TokenRel.Name = "ToolStripButton_TokenRel"
        Me.ToolStripButton_TokenRel.Size = New System.Drawing.Size(22, 20)
        Me.ToolStripButton_TokenRel.Text = "ToolStripButton4"
        Me.ToolStripButton_TokenRel.ToolTipText = "Toggle Token-Relations"
        '
        'ToolStripButton_Filter
        '
        Me.ToolStripButton_Filter.CheckOnClick = True
        Me.ToolStripButton_Filter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Filter.Image = Global.Ontology_Module.My.Resources.Resources.Procedures
        Me.ToolStripButton_Filter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Filter.Name = "ToolStripButton_Filter"
        Me.ToolStripButton_Filter.Size = New System.Drawing.Size(22, 20)
        Me.ToolStripButton_Filter.Text = "ToolStripButton1"
        Me.ToolStripButton_Filter.ToolTipText = "Toggle Filter"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(22, 6)
        '
        'ToolStripButton_ModuleView
        '
        Me.ToolStripButton_ModuleView.CheckOnClick = True
        Me.ToolStripButton_ModuleView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_ModuleView.Image = CType(resources.GetObject("ToolStripButton_ModuleView.Image"), System.Drawing.Image)
        Me.ToolStripButton_ModuleView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_ModuleView.Name = "ToolStripButton_ModuleView"
        Me.ToolStripButton_ModuleView.Size = New System.Drawing.Size(22, 19)
        Me.ToolStripButton_ModuleView.Text = "M"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolsToolStripMenuItem, Me.HilfeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1401, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReportsToolStripMenuItem, Me.OntologyConfiguratorToolStripMenuItem, Me.ApplyMappingToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.ToolsToolStripMenuItem.Text = "&Extras"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SyncToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ReportsToolStripMenuItem.Text = "x_Reports"
        '
        'SyncToolStripMenuItem
        '
        Me.SyncToolStripMenuItem.Name = "SyncToolStripMenuItem"
        Me.SyncToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.SyncToolStripMenuItem.Text = "x_Sync"
        '
        'OntologyConfiguratorToolStripMenuItem
        '
        Me.OntologyConfiguratorToolStripMenuItem.Name = "OntologyConfiguratorToolStripMenuItem"
        Me.OntologyConfiguratorToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.OntologyConfiguratorToolStripMenuItem.Text = "x_Ontology-Configurator"
        '
        'ApplyMappingToolStripMenuItem
        '
        Me.ApplyMappingToolStripMenuItem.Name = "ApplyMappingToolStripMenuItem"
        Me.ApplyMappingToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ApplyMappingToolStripMenuItem.Text = "x_Apply Mapping"
        '
        'HilfeToolStripMenuItem
        '
        Me.HilfeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InfoToolStripMenuItem})
        Me.HilfeToolStripMenuItem.Name = "HilfeToolStripMenuItem"
        Me.HilfeToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HilfeToolStripMenuItem.Text = "&Hilfe"
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(95, 22)
        Me.InfoToolStripMenuItem.Text = "&Info"
        '
        'ContextMenuStrip_TokAtt
        '
        Me.ContextMenuStrip_TokAtt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem1, Me.RelateToolStripMenuItem1, Me.DeleteToolStripMenuItem1})
        Me.ContextMenuStrip_TokAtt.Name = "ContextMenuStrip_TokAtt"
        Me.ContextMenuStrip_TokAtt.Size = New System.Drawing.Size(107, 70)
        '
        'EditToolStripMenuItem1
        '
        Me.EditToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyValToolStripMenuItem})
        Me.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1"
        Me.EditToolStripMenuItem1.Size = New System.Drawing.Size(106, 22)
        Me.EditToolStripMenuItem1.Text = "Edit"
        '
        'CopyValToolStripMenuItem
        '
        Me.CopyValToolStripMenuItem.Name = "CopyValToolStripMenuItem"
        Me.CopyValToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.CopyValToolStripMenuItem.Text = "Copy Val"
        '
        'RelateToolStripMenuItem1
        '
        Me.RelateToolStripMenuItem1.Name = "RelateToolStripMenuItem1"
        Me.RelateToolStripMenuItem1.Size = New System.Drawing.Size(106, 22)
        Me.RelateToolStripMenuItem1.Text = "relate"
        '
        'DeleteToolStripMenuItem1
        '
        Me.DeleteToolStripMenuItem1.Name = "DeleteToolStripMenuItem1"
        Me.DeleteToolStripMenuItem1.Size = New System.Drawing.Size(106, 22)
        Me.DeleteToolStripMenuItem1.Text = "delete"
        '
        'ContextMenuStrip_TokRel
        '
        Me.ContextMenuStrip_TokRel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.FilterToolStripMenuItem, Me.RelateToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip_TokRel.Name = "ContextMenuStrip_TokRel"
        Me.ContextMenuStrip_TokRel.Size = New System.Drawing.Size(107, 92)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetOrderIDToolStripMenuItem, Me.SetRelationTypeToolStripMenuItem, Me.ModuleEditToolStripMenuItem, Me.ModuleMenuToolStripMenuItem, Me.CopyValToolStripMenuItem1})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'SetOrderIDToolStripMenuItem
        '
        Me.SetOrderIDToolStripMenuItem.Name = "SetOrderIDToolStripMenuItem"
        Me.SetOrderIDToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.SetOrderIDToolStripMenuItem.Text = "Set OrderID"
        '
        'SetRelationTypeToolStripMenuItem
        '
        Me.SetRelationTypeToolStripMenuItem.Name = "SetRelationTypeToolStripMenuItem"
        Me.SetRelationTypeToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.SetRelationTypeToolStripMenuItem.Text = "Set RelationType"
        '
        'ModuleEditToolStripMenuItem
        '
        Me.ModuleEditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox_ModuleEdit})
        Me.ModuleEditToolStripMenuItem.Name = "ModuleEditToolStripMenuItem"
        Me.ModuleEditToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ModuleEditToolStripMenuItem.Text = "x_Module-Edit"
        '
        'ToolStripComboBox_ModuleEdit
        '
        Me.ToolStripComboBox_ModuleEdit.Name = "ToolStripComboBox_ModuleEdit"
        Me.ToolStripComboBox_ModuleEdit.Size = New System.Drawing.Size(121, 23)
        '
        'ModuleMenuToolStripMenuItem
        '
        Me.ModuleMenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox_ModuleMenu})
        Me.ModuleMenuToolStripMenuItem.Name = "ModuleMenuToolStripMenuItem"
        Me.ModuleMenuToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ModuleMenuToolStripMenuItem.Text = "x_Module-Menu"
        '
        'ToolStripComboBox_ModuleMenu
        '
        Me.ToolStripComboBox_ModuleMenu.Name = "ToolStripComboBox_ModuleMenu"
        Me.ToolStripComboBox_ModuleMenu.Size = New System.Drawing.Size(250, 23)
        '
        'CopyValToolStripMenuItem1
        '
        Me.CopyValToolStripMenuItem1.Name = "CopyValToolStripMenuItem1"
        Me.CopyValToolStripMenuItem1.Size = New System.Drawing.Size(162, 22)
        Me.CopyValToolStripMenuItem1.Text = "x_Copy Val"
        '
        'FilterToolStripMenuItem
        '
        Me.FilterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EqualToolStripMenuItem, Me.DifferentToolStripMenuItem, Me.ContainsToolStripMenuItem, Me.GreaterToolStripMenuItem, Me.LessThanToolStripMenuItem, Me.ClearFilterToolStripMenuItem})
        Me.FilterToolStripMenuItem.Name = "FilterToolStripMenuItem"
        Me.FilterToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.FilterToolStripMenuItem.Text = "Filter"
        '
        'EqualToolStripMenuItem
        '
        Me.EqualToolStripMenuItem.Name = "EqualToolStripMenuItem"
        Me.EqualToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.EqualToolStripMenuItem.Text = "Equal"
        '
        'DifferentToolStripMenuItem
        '
        Me.DifferentToolStripMenuItem.Name = "DifferentToolStripMenuItem"
        Me.DifferentToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.DifferentToolStripMenuItem.Text = "Different"
        '
        'ContainsToolStripMenuItem
        '
        Me.ContainsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox_TokRelContains})
        Me.ContainsToolStripMenuItem.Name = "ContainsToolStripMenuItem"
        Me.ContainsToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.ContainsToolStripMenuItem.Text = "Contains"
        '
        'ToolStripTextBox_TokRelContains
        '
        Me.ToolStripTextBox_TokRelContains.Name = "ToolStripTextBox_TokRelContains"
        Me.ToolStripTextBox_TokRelContains.Size = New System.Drawing.Size(100, 23)
        '
        'GreaterToolStripMenuItem
        '
        Me.GreaterToolStripMenuItem.Name = "GreaterToolStripMenuItem"
        Me.GreaterToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.GreaterToolStripMenuItem.Text = "Greater >"
        '
        'LessThanToolStripMenuItem
        '
        Me.LessThanToolStripMenuItem.Name = "LessThanToolStripMenuItem"
        Me.LessThanToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.LessThanToolStripMenuItem.Text = "Less than <"
        '
        'ClearFilterToolStripMenuItem
        '
        Me.ClearFilterToolStripMenuItem.Name = "ClearFilterToolStripMenuItem"
        Me.ClearFilterToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.ClearFilterToolStripMenuItem.Text = "Clear Filter"
        '
        'RelateToolStripMenuItem
        '
        Me.RelateToolStripMenuItem.Name = "RelateToolStripMenuItem"
        Me.RelateToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.RelateToolStripMenuItem.Text = "Relate"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.DeleteToolStripMenuItem.Text = "delete"
        '
        'Timer_TokenAttribute
        '
        Me.Timer_TokenAttribute.Interval = 300
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1401, 602)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "x_Ontology_Module"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.LeftToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.LeftToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer_Filter_Body.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer_Filter_Body, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_Filter_Body.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(false)
        Me.SplitContainer2.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer2,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer2.ResumeLayout(false)
        Me.SplitContainer_TypeToken.Panel1.ResumeLayout(false)
        Me.SplitContainer_TypeToken.Panel1.PerformLayout
        Me.SplitContainer_TypeToken.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer_TypeToken,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer_TypeToken.ResumeLayout(false)
        CType(Me.SplitContainer_Token,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer_Token.ResumeLayout(false)
        Me.SplitContainer_AttribRelTokenRel.Panel1.ResumeLayout(false)
        Me.SplitContainer_AttribRelTokenRel.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer_AttribRelTokenRel,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer_AttribRelTokenRel.ResumeLayout(false)
        Me.SplitContainer_AttribRel.Panel1.ResumeLayout(false)
        Me.SplitContainer_AttribRel.Panel1.PerformLayout
        CType(Me.SplitContainer_AttribRel,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer_AttribRel.ResumeLayout(false)
        Me.SplitContainer_TokAttTokRel.Panel1.ResumeLayout(false)
        Me.SplitContainer_TokAttTokRel.Panel1.PerformLayout
        CType(Me.SplitContainer_TokAttTokRel,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer_TokAttTokRel.ResumeLayout(false)
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.MenuStrip1.ResumeLayout(false)
        Me.MenuStrip1.PerformLayout
        Me.ContextMenuStrip_TokAtt.ResumeLayout(false)
        Me.ContextMenuStrip_TokRel.ResumeLayout(false)
        CType(Me.BindingSource_TokenRel,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.BindingSource_TokenAtt,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel_DatabaseLBL As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_Database As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_TokenAttLBL As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_TokenAtt_Attribute As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_TokenAttSeperator As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_TokenAtt_Token As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_RelationLBL As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_TokenRelLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_Seperator1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_TokenRelRelation As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_Seperator2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_TokenRelRight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_RelationDoneLBL As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_RelationDone As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainer_Filter_Body As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer_TypeToken As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents SplitContainer_Token As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer_AttribRelTokenRel As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer_AttribRel As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel_Attributes As System.Windows.Forms.Panel
    Friend WithEvents Label_AttributesLBL As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip_TokAtt As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyValToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RelateToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer_TokAttTokRel As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel_RelationTypes As System.Windows.Forms.Panel
    Friend WithEvents Label_RelationTypes As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip_TokRel As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetOrderIDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetRelationTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModuleEditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripComboBox_ModuleEdit As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ModuleMenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripComboBox_ModuleMenu As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents CopyValToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EqualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DifferentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContainsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripTextBox_TokRelContains As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents GreaterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LessThanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearFilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RelateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Types As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Token As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Tokentree As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_AttribRel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_TokenRel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Filter As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_ModuleView As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BindingSource_TokenRel As System.Windows.Forms.BindingSource
    Friend WithEvents Timer_TokenAttribute As System.Windows.Forms.Timer
    Friend WithEvents BindingSource_TokenAtt As System.Windows.Forms.BindingSource
    Friend WithEvents ToolStripButton_AttributesAndRelations As System.Windows.Forms.ToolStripButton
    Friend WithEvents SyncToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton_TokenType As System.Windows.Forms.ToolStripButton
    Friend WithEvents OntologyConfiguratorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HilfeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ApplyMappingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
