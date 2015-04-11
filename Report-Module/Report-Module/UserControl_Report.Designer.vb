<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_Report
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_Report))
        Me.DataGridView_Reports = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip_Reports = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyPathToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyGUIDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XEditSemItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XTypedTagsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModuleMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenModuleByArgumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenLastModuleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToOntologyClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EqualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DifferentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContainsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox_contains = New System.Windows.Forms.ToolStripTextBox()
        Me.ClearFilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FieldToFilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FieldToSortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoggingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddLogentryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MediaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenMediaItemModuleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenPDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenImageRefToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel_Sort = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripTextBox_Sort = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripDropDownButton_Copy = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_DrillDown = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_OpenLink = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_OpenFile = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_DownloadFile = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_CopyPath = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_OpenImage = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_OpenMedia = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_OpenPDF = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtond_OpenWord_Existing = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_OpenWordMenu = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_CreateGraphML = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_Localized = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_DecodePassword = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_CommandLineRun = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripTextBox_Filter = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.FolderBrowserDialog_Save = New System.Windows.Forms.FolderBrowserDialog()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.BindingNavigator_Reports = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Filter = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_OpenFilter = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_SaveFilter = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_OpenSort = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_SaveSort = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel_Calculation = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripTextBox_Calculation = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSplitButton_Calculation = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripMenuItemCalcAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCalcMult = New System.Windows.Forms.ToolStripMenuItem()
        Me.AVGToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_Sync = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripProgressBar_Synced = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripLabel_ES = New System.Windows.Forms.ToolStripLabel()
        Me.Timer_Password = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Data = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Sync = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileDialog_GraphML = New System.Windows.Forms.SaveFileDialog()
        Me.Timer_Session = New System.Windows.Forms.Timer(Me.components)
        Me.BindingSource_Reports = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataGridView_Reports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip_Reports.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.RightToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        CType(Me.BindingNavigator_Reports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator_Reports.SuspendLayout()
        CType(Me.BindingSource_Reports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView_Reports
        '
        Me.DataGridView_Reports.AllowUserToAddRows = False
        Me.DataGridView_Reports.AllowUserToDeleteRows = False
        Me.DataGridView_Reports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView_Reports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Reports.ContextMenuStrip = Me.ContextMenuStrip_Reports
        Me.DataGridView_Reports.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView_Reports.Name = "DataGridView_Reports"
        Me.DataGridView_Reports.ReadOnly = True
        Me.DataGridView_Reports.Size = New System.Drawing.Size(1213, 440)
        Me.DataGridView_Reports.TabIndex = 1
        '
        'ContextMenuStrip_Reports
        '
        Me.ContextMenuStrip_Reports.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FilesToolStripMenuItem, Me.EditToolStripMenuItem, Me.FilterToolStripMenuItem, Me.LoggingToolStripMenuItem, Me.MediaToolStripMenuItem, Me.ColumnsToolStripMenuItem})
        Me.ContextMenuStrip_Reports.Name = "ContextMenuStrip_Reports"
        Me.ContextMenuStrip_Reports.Size = New System.Drawing.Size(129, 136)
        '
        'FilesToolStripMenuItem
        '
        Me.FilesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.CopyPathToolStripMenuItem})
        Me.FilesToolStripMenuItem.Name = "FilesToolStripMenuItem"
        Me.FilesToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.FilesToolStripMenuItem.Text = "x_Files"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.OpenToolStripMenuItem.Text = "x_Open"
        '
        'CopyPathToolStripMenuItem
        '
        Me.CopyPathToolStripMenuItem.Name = "CopyPathToolStripMenuItem"
        Me.CopyPathToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.CopyPathToolStripMenuItem.Text = "x_Copy Path"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyNameToolStripMenuItem, Me.CopyGUIDToolStripMenuItem, Me.XEditSemItemToolStripMenuItem, Me.XTypedTagsToolStripMenuItem, Me.ModuleMenuToolStripMenuItem, Me.CopyToOntologyClipboardToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.EditToolStripMenuItem.Text = "x_Edit"
        '
        'CopyNameToolStripMenuItem
        '
        Me.CopyNameToolStripMenuItem.Name = "CopyNameToolStripMenuItem"
        Me.CopyNameToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.CopyNameToolStripMenuItem.Text = "x_Copy Name"
        '
        'CopyGUIDToolStripMenuItem
        '
        Me.CopyGUIDToolStripMenuItem.Name = "CopyGUIDToolStripMenuItem"
        Me.CopyGUIDToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.CopyGUIDToolStripMenuItem.Text = "x_Copy GUID"
        '
        'XEditSemItemToolStripMenuItem
        '
        Me.XEditSemItemToolStripMenuItem.Name = "XEditSemItemToolStripMenuItem"
        Me.XEditSemItemToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.XEditSemItemToolStripMenuItem.Text = "x_Edit_SemItem"
        '
        'XTypedTagsToolStripMenuItem
        '
        Me.XTypedTagsToolStripMenuItem.Name = "XTypedTagsToolStripMenuItem"
        Me.XTypedTagsToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.XTypedTagsToolStripMenuItem.Text = "x_Typed Tags"
        '
        'ModuleMenuToolStripMenuItem
        '
        Me.ModuleMenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenModuleByArgumentToolStripMenuItem})
        Me.ModuleMenuToolStripMenuItem.Name = "ModuleMenuToolStripMenuItem"
        Me.ModuleMenuToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.ModuleMenuToolStripMenuItem.Text = "x_Module-Menu"
        '
        'OpenModuleByArgumentToolStripMenuItem
        '
        Me.OpenModuleByArgumentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenLastModuleToolStripMenuItem})
        Me.OpenModuleByArgumentToolStripMenuItem.Name = "OpenModuleByArgumentToolStripMenuItem"
        Me.OpenModuleByArgumentToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.OpenModuleByArgumentToolStripMenuItem.Text = "x_Open Module by Argument"
        '
        'OpenLastModuleToolStripMenuItem
        '
        Me.OpenLastModuleToolStripMenuItem.CheckOnClick = True
        Me.OpenLastModuleToolStripMenuItem.Name = "OpenLastModuleToolStripMenuItem"
        Me.OpenLastModuleToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.OpenLastModuleToolStripMenuItem.Text = "x_Open Last Module"
        '
        'CopyToOntologyClipboardToolStripMenuItem
        '
        Me.CopyToOntologyClipboardToolStripMenuItem.Name = "CopyToOntologyClipboardToolStripMenuItem"
        Me.CopyToOntologyClipboardToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.CopyToOntologyClipboardToolStripMenuItem.Text = "x_Copy to Ontology-Clipboard"
        '
        'FilterToolStripMenuItem
        '
        Me.FilterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EqualToolStripMenuItem, Me.DifferentToolStripMenuItem, Me.ContainsToolStripMenuItem, Me.ClearFilterToolStripMenuItem, Me.FieldToFilterToolStripMenuItem, Me.FieldToSortToolStripMenuItem})
        Me.FilterToolStripMenuItem.Name = "FilterToolStripMenuItem"
        Me.FilterToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.FilterToolStripMenuItem.Text = "x_Filter"
        '
        'EqualToolStripMenuItem
        '
        Me.EqualToolStripMenuItem.Name = "EqualToolStripMenuItem"
        Me.EqualToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EqualToolStripMenuItem.Text = "equal"
        '
        'DifferentToolStripMenuItem
        '
        Me.DifferentToolStripMenuItem.Name = "DifferentToolStripMenuItem"
        Me.DifferentToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DifferentToolStripMenuItem.Text = "different"
        '
        'ContainsToolStripMenuItem
        '
        Me.ContainsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox_contains})
        Me.ContainsToolStripMenuItem.Name = "ContainsToolStripMenuItem"
        Me.ContainsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ContainsToolStripMenuItem.Text = "contains"
        '
        'ToolStripTextBox_contains
        '
        Me.ToolStripTextBox_contains.Name = "ToolStripTextBox_contains"
        Me.ToolStripTextBox_contains.Size = New System.Drawing.Size(100, 23)
        '
        'ClearFilterToolStripMenuItem
        '
        Me.ClearFilterToolStripMenuItem.Name = "ClearFilterToolStripMenuItem"
        Me.ClearFilterToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ClearFilterToolStripMenuItem.Text = "x_clear Filter"
        '
        'FieldToFilterToolStripMenuItem
        '
        Me.FieldToFilterToolStripMenuItem.Name = "FieldToFilterToolStripMenuItem"
        Me.FieldToFilterToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FieldToFilterToolStripMenuItem.Text = "x_Field to Filter"
        '
        'FieldToSortToolStripMenuItem
        '
        Me.FieldToSortToolStripMenuItem.Name = "FieldToSortToolStripMenuItem"
        Me.FieldToSortToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FieldToSortToolStripMenuItem.Text = "x_Field to Sort"
        '
        'LoggingToolStripMenuItem
        '
        Me.LoggingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddLogentryToolStripMenuItem})
        Me.LoggingToolStripMenuItem.Name = "LoggingToolStripMenuItem"
        Me.LoggingToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.LoggingToolStripMenuItem.Text = "x_Logging"
        '
        'AddLogentryToolStripMenuItem
        '
        Me.AddLogentryToolStripMenuItem.Name = "AddLogentryToolStripMenuItem"
        Me.AddLogentryToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.AddLogentryToolStripMenuItem.Text = "x_Add Logentry"
        '
        'MediaToolStripMenuItem
        '
        Me.MediaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenMediaItemModuleToolStripMenuItem, Me.OpenPDFToolStripMenuItem, Me.OpenImageRefToolStripMenuItem})
        Me.MediaToolStripMenuItem.Name = "MediaToolStripMenuItem"
        Me.MediaToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.MediaToolStripMenuItem.Text = "x_Media"
        '
        'OpenMediaItemModuleToolStripMenuItem
        '
        Me.OpenMediaItemModuleToolStripMenuItem.Name = "OpenMediaItemModuleToolStripMenuItem"
        Me.OpenMediaItemModuleToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.OpenMediaItemModuleToolStripMenuItem.Text = "Open MediaItem-Ref"
        '
        'OpenPDFToolStripMenuItem
        '
        Me.OpenPDFToolStripMenuItem.Name = "OpenPDFToolStripMenuItem"
        Me.OpenPDFToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.OpenPDFToolStripMenuItem.Text = "Open PDF-Ref"
        '
        'OpenImageRefToolStripMenuItem
        '
        Me.OpenImageRefToolStripMenuItem.Name = "OpenImageRefToolStripMenuItem"
        Me.OpenImageRefToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.OpenImageRefToolStripMenuItem.Text = "Open Image-Ref"
        '
        'ColumnsToolStripMenuItem
        '
        Me.ColumnsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ColumnToolStripMenuItem})
        Me.ColumnsToolStripMenuItem.Name = "ColumnsToolStripMenuItem"
        Me.ColumnsToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.ColumnsToolStripMenuItem.Text = "x_Hide"
        '
        'ColumnToolStripMenuItem
        '
        Me.ColumnToolStripMenuItem.Name = "ColumnToolStripMenuItem"
        Me.ColumnToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.ColumnToolStripMenuItem.Text = "x_Column"
        '
        'ToolStripLabel_Sort
        '
        Me.ToolStripLabel_Sort.Name = "ToolStripLabel_Sort"
        Me.ToolStripLabel_Sort.Size = New System.Drawing.Size(41, 22)
        Me.ToolStripLabel_Sort.Text = "x_Sort:"
        '
        'ToolStripTextBox_Sort
        '
        Me.ToolStripTextBox_Sort.Name = "ToolStripTextBox_Sort"
        Me.ToolStripTextBox_Sort.Size = New System.Drawing.Size(200, 25)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripSeparator13, Me.ToolStripDropDownButton_Copy, Me.ToolStripSeparator10, Me.ToolStripButton_DrillDown, Me.ToolStripSeparator4, Me.ToolStripButton_OpenLink, Me.ToolStripSeparator2, Me.ToolStripButton_OpenFile, Me.ToolStripButton_DownloadFile, Me.ToolStripButton_CopyPath, Me.ToolStripSeparator1, Me.ToolStripButton_OpenImage, Me.ToolStripButton_OpenMedia, Me.ToolStripButton_OpenPDF, Me.ToolStripSeparator3, Me.ToolStripButtond_OpenWord_Existing, Me.ToolStripButton_OpenWordMenu, Me.ToolStripSeparator7, Me.ToolStripButton_CreateGraphML, Me.ToolStripSeparator8, Me.ToolStripButton_Localized, Me.ToolStripSeparator9, Me.ToolStripButton_DecodePassword, Me.ToolStripSeparator12, Me.ToolStripButton_CommandLineRun})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(32, 458)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ServerToolStripMenuItem, Me.DatabaseToolStripMenuItem, Me.ViewToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.Report_Module.My.Resources.Resources.Procedures1
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(30, 20)
        Me.ToolStripDropDownButton1.Text = "ToolStripDropDownButton1"
        '
        'ServerToolStripMenuItem
        '
        Me.ServerToolStripMenuItem.Name = "ServerToolStripMenuItem"
        Me.ServerToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.ServerToolStripMenuItem.Text = "x_Server"
        '
        'DatabaseToolStripMenuItem
        '
        Me.DatabaseToolStripMenuItem.Name = "DatabaseToolStripMenuItem"
        Me.DatabaseToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.DatabaseToolStripMenuItem.Text = "x_Database"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.ViewToolStripMenuItem.Text = "x_View"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(30, 6)
        '
        'ToolStripDropDownButton_Copy
        '
        Me.ToolStripDropDownButton_Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton_Copy.Image = Global.Report_Module.My.Resources.Resources.CopyHS
        Me.ToolStripDropDownButton_Copy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton_Copy.Name = "ToolStripDropDownButton_Copy"
        Me.ToolStripDropDownButton_Copy.Size = New System.Drawing.Size(30, 20)
        Me.ToolStripDropDownButton_Copy.Text = "ToolStripDropDownButton1"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(30, 6)
        '
        'ToolStripButton_DrillDown
        '
        Me.ToolStripButton_DrillDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_DrillDown.Enabled = False
        Me.ToolStripButton_DrillDown.Image = Global.Report_Module.My.Resources.Resources._112_ArrowCurve_Blue_Right_32x32_72
        Me.ToolStripButton_DrillDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_DrillDown.Name = "ToolStripButton_DrillDown"
        Me.ToolStripButton_DrillDown.Size = New System.Drawing.Size(30, 20)
        Me.ToolStripButton_DrillDown.Text = "ToolStripButton1"
        Me.ToolStripButton_DrillDown.ToolTipText = "Drill Down"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(30, 6)
        '
        'ToolStripButton_OpenLink
        '
        Me.ToolStripButton_OpenLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_OpenLink.Enabled = False
        Me.ToolStripButton_OpenLink.Image = Global.Report_Module.My.Resources.Resources.bb_wrld_
        Me.ToolStripButton_OpenLink.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_OpenLink.Name = "ToolStripButton_OpenLink"
        Me.ToolStripButton_OpenLink.Size = New System.Drawing.Size(30, 20)
        Me.ToolStripButton_OpenLink.Text = "ToolStripButton1"
        Me.ToolStripButton_OpenLink.ToolTipText = "x_OpenLink"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(30, 6)
        '
        'ToolStripButton_OpenFile
        '
        Me.ToolStripButton_OpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_OpenFile.Enabled = False
        Me.ToolStripButton_OpenFile.Image = Global.Report_Module.My.Resources.Resources._1683_Lightbulb_32x32
        Me.ToolStripButton_OpenFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_OpenFile.Name = "ToolStripButton_OpenFile"
        Me.ToolStripButton_OpenFile.Size = New System.Drawing.Size(30, 20)
        Me.ToolStripButton_OpenFile.Text = "ToolStripButton1"
        Me.ToolStripButton_OpenFile.ToolTipText = "Open File"
        '
        'ToolStripButton_DownloadFile
        '
        Me.ToolStripButton_DownloadFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_DownloadFile.Enabled = False
        Me.ToolStripButton_DownloadFile.Image = Global.Report_Module.My.Resources.Resources._010_LowPriority_32x32_72
        Me.ToolStripButton_DownloadFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_DownloadFile.Name = "ToolStripButton_DownloadFile"
        Me.ToolStripButton_DownloadFile.Size = New System.Drawing.Size(30, 20)
        Me.ToolStripButton_DownloadFile.Text = "ToolStripButton3"
        Me.ToolStripButton_DownloadFile.ToolTipText = "Download File"
        '
        'ToolStripButton_CopyPath
        '
        Me.ToolStripButton_CopyPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_CopyPath.Enabled = False
        Me.ToolStripButton_CopyPath.Image = Global.Report_Module.My.Resources.Resources.CopyHS
        Me.ToolStripButton_CopyPath.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_CopyPath.Name = "ToolStripButton_CopyPath"
        Me.ToolStripButton_CopyPath.Size = New System.Drawing.Size(30, 20)
        Me.ToolStripButton_CopyPath.Text = "ToolStripButton2"
        Me.ToolStripButton_CopyPath.ToolTipText = "Copy Path"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(30, 6)
        '
        'ToolStripButton_OpenImage
        '
        Me.ToolStripButton_OpenImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_OpenImage.Enabled = False
        Me.ToolStripButton_OpenImage.Image = Global.Report_Module.My.Resources.Resources.generic_picture
        Me.ToolStripButton_OpenImage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_OpenImage.Name = "ToolStripButton_OpenImage"
        Me.ToolStripButton_OpenImage.Size = New System.Drawing.Size(30, 20)
        Me.ToolStripButton_OpenImage.Text = "ToolStripButton1"
        '
        'ToolStripButton_OpenMedia
        '
        Me.ToolStripButton_OpenMedia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_OpenMedia.Enabled = False
        Me.ToolStripButton_OpenMedia.Image = Global.Report_Module.My.Resources.Resources.AudioCD
        Me.ToolStripButton_OpenMedia.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_OpenMedia.Name = "ToolStripButton_OpenMedia"
        Me.ToolStripButton_OpenMedia.Size = New System.Drawing.Size(30, 20)
        Me.ToolStripButton_OpenMedia.Text = "ToolStripButton2"
        '
        'ToolStripButton_OpenPDF
        '
        Me.ToolStripButton_OpenPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_OpenPDF.Enabled = False
        Me.ToolStripButton_OpenPDF.Image = Global.Report_Module.My.Resources.Resources.pdf_preview
        Me.ToolStripButton_OpenPDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_OpenPDF.Name = "ToolStripButton_OpenPDF"
        Me.ToolStripButton_OpenPDF.Size = New System.Drawing.Size(30, 20)
        Me.ToolStripButton_OpenPDF.Text = "ToolStripButton3"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(30, 6)
        '
        'ToolStripButtond_OpenWord_Existing
        '
        Me.ToolStripButtond_OpenWord_Existing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtond_OpenWord_Existing.Enabled = False
        Me.ToolStripButtond_OpenWord_Existing.Image = Global.Report_Module.My.Resources.Resources.it_word_icon_Open_Doc
        Me.ToolStripButtond_OpenWord_Existing.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtond_OpenWord_Existing.Name = "ToolStripButtond_OpenWord_Existing"
        Me.ToolStripButtond_OpenWord_Existing.Size = New System.Drawing.Size(30, 20)
        Me.ToolStripButtond_OpenWord_Existing.Text = "ToolStripButton1"
        Me.ToolStripButtond_OpenWord_Existing.ToolTipText = "Open belonging Word-File"
        '
        'ToolStripButton_OpenWordMenu
        '
        Me.ToolStripButton_OpenWordMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_OpenWordMenu.Enabled = False
        Me.ToolStripButton_OpenWordMenu.Image = Global.Report_Module.My.Resources.Resources.it_word_icon
        Me.ToolStripButton_OpenWordMenu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_OpenWordMenu.Name = "ToolStripButton_OpenWordMenu"
        Me.ToolStripButton_OpenWordMenu.Size = New System.Drawing.Size(30, 20)
        Me.ToolStripButton_OpenWordMenu.Text = "ToolStripButton1"
        Me.ToolStripButton_OpenWordMenu.ToolTipText = "Open Word-Menu"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(30, 6)
        '
        'ToolStripButton_CreateGraphML
        '
        Me.ToolStripButton_CreateGraphML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_CreateGraphML.Enabled = False
        Me.ToolStripButton_CreateGraphML.Image = Global.Report_Module.My.Resources.Resources.cahiers_de_labo
        Me.ToolStripButton_CreateGraphML.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_CreateGraphML.Name = "ToolStripButton_CreateGraphML"
        Me.ToolStripButton_CreateGraphML.Size = New System.Drawing.Size(30, 20)
        Me.ToolStripButton_CreateGraphML.Text = "ToolStripButton1"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(30, 6)
        '
        'ToolStripButton_Localized
        '
        Me.ToolStripButton_Localized.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Localized.Image = Global.Report_Module.My.Resources.Resources.edit_find_replace
        Me.ToolStripButton_Localized.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Localized.Name = "ToolStripButton_Localized"
        Me.ToolStripButton_Localized.Size = New System.Drawing.Size(30, 20)
        Me.ToolStripButton_Localized.Text = "ToolStripButton1"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(30, 6)
        '
        'ToolStripButton_DecodePassword
        '
        Me.ToolStripButton_DecodePassword.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_DecodePassword.Enabled = False
        Me.ToolStripButton_DecodePassword.Image = Global.Report_Module.My.Resources.Resources.Key
        Me.ToolStripButton_DecodePassword.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_DecodePassword.Name = "ToolStripButton_DecodePassword"
        Me.ToolStripButton_DecodePassword.Size = New System.Drawing.Size(30, 20)
        Me.ToolStripButton_DecodePassword.Text = "ToolStripButton1"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(30, 6)
        '
        'ToolStripButton_CommandLineRun
        '
        Me.ToolStripButton_CommandLineRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_CommandLineRun.Enabled = False
        Me.ToolStripButton_CommandLineRun.Image = Global.Report_Module.My.Resources.Resources.Procedures
        Me.ToolStripButton_CommandLineRun.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_CommandLineRun.Name = "ToolStripButton_CommandLineRun"
        Me.ToolStripButton_CommandLineRun.Size = New System.Drawing.Size(30, 20)
        Me.ToolStripButton_CommandLineRun.Text = "ToolStripButton1"
        '
        'ToolStripTextBox_Filter
        '
        Me.ToolStripTextBox_Filter.Name = "ToolStripTextBox_Filter"
        Me.ToolStripTextBox_Filter.Size = New System.Drawing.Size(250, 25)
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.BindingNavigator_Reports)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DataGridView_Reports)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(1219, 471)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        '
        'ToolStripContainer1.RightToolStripPanel
        '
        Me.ToolStripContainer1.RightToolStripPanel.Controls.Add(Me.ToolStrip1)
        Me.ToolStripContainer1.Size = New System.Drawing.Size(1251, 496)
        Me.ToolStripContainer1.TabIndex = 3
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'BindingNavigator_Reports
        '
        Me.BindingNavigator_Reports.AddNewItem = Nothing
        Me.BindingNavigator_Reports.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator_Reports.DeleteItem = Nothing
        Me.BindingNavigator_Reports.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BindingNavigator_Reports.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.ToolStripButton_Filter, Me.ToolStripButton_OpenFilter, Me.ToolStripTextBox_Filter, Me.ToolStripButton_SaveFilter, Me.ToolStripSeparator11, Me.ToolStripLabel_Sort, Me.ToolStripButton_OpenSort, Me.ToolStripTextBox_Sort, Me.ToolStripButton_SaveSort, Me.ToolStripSeparator6, Me.ToolStripLabel_Calculation, Me.ToolStripTextBox_Calculation, Me.ToolStripSplitButton_Calculation, Me.ToolStripSeparator5, Me.ToolStripButton_Sync, Me.ToolStripProgressBar_Synced, Me.ToolStripLabel_ES})
        Me.BindingNavigator_Reports.Location = New System.Drawing.Point(0, 446)
        Me.BindingNavigator_Reports.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator_Reports.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator_Reports.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator_Reports.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator_Reports.Name = "BindingNavigator_Reports"
        Me.BindingNavigator_Reports.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator_Reports.Size = New System.Drawing.Size(1219, 25)
        Me.BindingNavigator_Reports.TabIndex = 2
        Me.BindingNavigator_Reports.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'ToolStripButton_Filter
        '
        Me.ToolStripButton_Filter.CheckOnClick = True
        Me.ToolStripButton_Filter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Filter.Image = CType(resources.GetObject("ToolStripButton_Filter.Image"), System.Drawing.Image)
        Me.ToolStripButton_Filter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Filter.Name = "ToolStripButton_Filter"
        Me.ToolStripButton_Filter.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripButton_Filter.Text = "x_Filter:"
        '
        'ToolStripButton_OpenFilter
        '
        Me.ToolStripButton_OpenFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_OpenFilter.Image = Global.Report_Module.My.Resources.Resources.gnome_fs_home
        Me.ToolStripButton_OpenFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_OpenFilter.Name = "ToolStripButton_OpenFilter"
        Me.ToolStripButton_OpenFilter.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_OpenFilter.Text = "ToolStripButton1"
        '
        'ToolStripButton_SaveFilter
        '
        Me.ToolStripButton_SaveFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_SaveFilter.Enabled = False
        Me.ToolStripButton_SaveFilter.Image = Global.Report_Module.My.Resources.Resources.saveHS
        Me.ToolStripButton_SaveFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_SaveFilter.Name = "ToolStripButton_SaveFilter"
        Me.ToolStripButton_SaveFilter.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_SaveFilter.Text = "ToolStripButton1"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_OpenSort
        '
        Me.ToolStripButton_OpenSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_OpenSort.Image = Global.Report_Module.My.Resources.Resources.gnome_fs_home
        Me.ToolStripButton_OpenSort.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_OpenSort.Name = "ToolStripButton_OpenSort"
        Me.ToolStripButton_OpenSort.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_OpenSort.Text = "ToolStripButton2"
        '
        'ToolStripButton_SaveSort
        '
        Me.ToolStripButton_SaveSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_SaveSort.Enabled = False
        Me.ToolStripButton_SaveSort.Image = Global.Report_Module.My.Resources.Resources.saveHS
        Me.ToolStripButton_SaveSort.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_SaveSort.Name = "ToolStripButton_SaveSort"
        Me.ToolStripButton_SaveSort.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_SaveSort.Text = "ToolStripButton2"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel_Calculation
        '
        Me.ToolStripLabel_Calculation.Name = "ToolStripLabel_Calculation"
        Me.ToolStripLabel_Calculation.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripLabel_Calculation.Text = "x_Calculation:"
        '
        'ToolStripTextBox_Calculation
        '
        Me.ToolStripTextBox_Calculation.Name = "ToolStripTextBox_Calculation"
        Me.ToolStripTextBox_Calculation.ReadOnly = True
        Me.ToolStripTextBox_Calculation.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripSplitButton_Calculation
        '
        Me.ToolStripSplitButton_Calculation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripSplitButton_Calculation.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemCalcAdd, Me.ToolStripMenuItemCalcMult, Me.AVGToolStripMenuItem})
        Me.ToolStripSplitButton_Calculation.Image = CType(resources.GetObject("ToolStripSplitButton_Calculation.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton_Calculation.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton_Calculation.Name = "ToolStripSplitButton_Calculation"
        Me.ToolStripSplitButton_Calculation.Size = New System.Drawing.Size(28, 22)
        Me.ToolStripSplitButton_Calculation.Text = "-"
        '
        'ToolStripMenuItemCalcAdd
        '
        Me.ToolStripMenuItemCalcAdd.Checked = True
        Me.ToolStripMenuItemCalcAdd.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripMenuItemCalcAdd.Name = "ToolStripMenuItemCalcAdd"
        Me.ToolStripMenuItemCalcAdd.Size = New System.Drawing.Size(97, 22)
        Me.ToolStripMenuItemCalcAdd.Text = "+"
        '
        'ToolStripMenuItemCalcMult
        '
        Me.ToolStripMenuItemCalcMult.Name = "ToolStripMenuItemCalcMult"
        Me.ToolStripMenuItemCalcMult.Size = New System.Drawing.Size(97, 22)
        Me.ToolStripMenuItemCalcMult.Text = "*"
        '
        'AVGToolStripMenuItem
        '
        Me.AVGToolStripMenuItem.Name = "AVGToolStripMenuItem"
        Me.AVGToolStripMenuItem.Size = New System.Drawing.Size(97, 22)
        Me.AVGToolStripMenuItem.Text = "AVG"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_Sync
        '
        Me.ToolStripButton_Sync.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Sync.Image = CType(resources.GetObject("ToolStripButton_Sync.Image"), System.Drawing.Image)
        Me.ToolStripButton_Sync.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Sync.Name = "ToolStripButton_Sync"
        Me.ToolStripButton_Sync.Size = New System.Drawing.Size(49, 22)
        Me.ToolStripButton_Sync.Text = "x_Sync:"
        '
        'ToolStripProgressBar_Synced
        '
        Me.ToolStripProgressBar_Synced.Name = "ToolStripProgressBar_Synced"
        Me.ToolStripProgressBar_Synced.Size = New System.Drawing.Size(100, 22)
        '
        'ToolStripLabel_ES
        '
        Me.ToolStripLabel_ES.Name = "ToolStripLabel_ES"
        Me.ToolStripLabel_ES.Size = New System.Drawing.Size(12, 15)
        Me.ToolStripLabel_ES.Text = "-"
        '
        'Timer_Password
        '
        Me.Timer_Password.Interval = 30000
        '
        'Timer_Data
        '
        Me.Timer_Data.Interval = 300
        '
        'Timer_Sync
        '
        Me.Timer_Sync.Interval = 300
        '
        'SaveFileDialog_GraphML
        '
        Me.SaveFileDialog_GraphML.Filter = "GraphML-Dateien|*.graphml"
        '
        'Timer_Session
        '
        Me.Timer_Session.Interval = 300
        '
        'UserControl_Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_Report"
        Me.Size = New System.Drawing.Size(1251, 496)
        CType(Me.DataGridView_Reports,System.ComponentModel.ISupportInitialize).EndInit
        Me.ContextMenuStrip_Reports.ResumeLayout(false)
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(false)
        Me.ToolStripContainer1.ContentPanel.PerformLayout
        Me.ToolStripContainer1.RightToolStripPanel.ResumeLayout(false)
        Me.ToolStripContainer1.RightToolStripPanel.PerformLayout
        Me.ToolStripContainer1.ResumeLayout(false)
        Me.ToolStripContainer1.PerformLayout
        CType(Me.BindingNavigator_Reports,System.ComponentModel.ISupportInitialize).EndInit
        Me.BindingNavigator_Reports.ResumeLayout(false)
        Me.BindingNavigator_Reports.PerformLayout
        CType(Me.BindingSource_Reports,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents DataGridView_Reports As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip_Reports As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents FilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyPathToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyGUIDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XEditSemItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EqualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DifferentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContainsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripTextBox_contains As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ClearFilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FieldToFilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FieldToSortToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel_Sort As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox_Sort As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_DrillDown As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_OpenLink As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_OpenFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_DownloadFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_CopyPath As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_OpenImage As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_OpenMedia As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_OpenPDF As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_DecodePassword As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripTextBox_Filter As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButton_Filter As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FolderBrowserDialog_Save As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents BindingNavigator_Reports As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer_Password As System.Windows.Forms.Timer
    Friend WithEvents Timer_Data As System.Windows.Forms.Timer
    Friend WithEvents BindingSource_Reports As System.Windows.Forms.BindingSource
    Friend WithEvents Timer_Sync As System.Windows.Forms.Timer
    Friend WithEvents ToolStripProgressBar_Synced As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripLabel_ES As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel_Calculation As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox_Calculation As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSplitButton_Calculation As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripMenuItemCalcAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemCalcMult As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AVGToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LoggingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddLogentryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MediaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenMediaItemModuleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenPDFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenImageRefToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton_Sync As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtond_OpenWord_Existing As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_OpenWordMenu As System.Windows.Forms.ToolStripButton
    Friend WithEvents XTypedTagsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton_CreateGraphML As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveFileDialog_GraphML As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolStripButton_Localized As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton_Copy As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton_SaveFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_SaveSort As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_OpenFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_OpenSort As System.Windows.Forms.ToolStripButton
    Friend WithEvents ModuleMenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenModuleByArgumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenLastModuleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToOntologyClipboardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_CommandLineRun As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer_Session As System.Windows.Forms.Timer
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
