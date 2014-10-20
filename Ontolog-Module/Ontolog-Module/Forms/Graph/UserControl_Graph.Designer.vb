<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_Graph
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_Graph))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_GUID = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripTextBox3 = New System.Windows.Forms.ToolStripTextBox()
        Me.GViewer_OGraph = New Microsoft.Glee.GraphViewerGdi.GViewer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_Filter = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripTextBox_Filter = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripButton_Clear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Root = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Ontologies = New System.Windows.Forms.ToolStripButton()
        Me.Timer_Filter = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip_Graph = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddRelationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenModuleByArgumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenLastModuleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ContextMenuStrip_Graph.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.ToolStrip2)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.GViewer_OGraph)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(570, 420)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(570, 470)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_GUID, Me.ToolStripTextBox2, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.ToolStripTextBox3})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(521, 25)
        Me.ToolStrip2.TabIndex = 0
        '
        'ToolStripLabel_GUID
        '
        Me.ToolStripLabel_GUID.Name = "ToolStripLabel_GUID"
        Me.ToolStripLabel_GUID.Size = New System.Drawing.Size(47, 22)
        Me.ToolStripLabel_GUID.Text = "x_GUID:"
        '
        'ToolStripTextBox2
        '
        Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
        Me.ToolStripTextBox2.ReadOnly = True
        Me.ToolStripTextBox2.Size = New System.Drawing.Size(200, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripLabel1.Text = "x_Name:"
        '
        'ToolStripTextBox3
        '
        Me.ToolStripTextBox3.Name = "ToolStripTextBox3"
        Me.ToolStripTextBox3.ReadOnly = True
        Me.ToolStripTextBox3.Size = New System.Drawing.Size(200, 25)
        '
        'GViewer_OGraph
        '
        Me.GViewer_OGraph.AsyncLayout = False
        Me.GViewer_OGraph.AutoScroll = True
        Me.GViewer_OGraph.BackwardEnabled = False
        Me.GViewer_OGraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GViewer_OGraph.ForwardEnabled = False
        Me.GViewer_OGraph.Graph = Nothing
        Me.GViewer_OGraph.Location = New System.Drawing.Point(0, 0)
        Me.GViewer_OGraph.MouseHitDistance = 0.05R
        Me.GViewer_OGraph.Name = "GViewer_OGraph"
        Me.GViewer_OGraph.NavigationVisible = True
        Me.GViewer_OGraph.PanButtonPressed = False
        Me.GViewer_OGraph.SaveButtonVisible = True
        Me.GViewer_OGraph.Size = New System.Drawing.Size(570, 420)
        Me.GViewer_OGraph.TabIndex = 0
        Me.GViewer_OGraph.ZoomF = 1.0R
        Me.GViewer_OGraph.ZoomFraction = 0.5R
        Me.GViewer_OGraph.ZoomWindowThreshold = 0.05R
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_Filter, Me.ToolStripTextBox_Filter, Me.ToolStripButton_Clear, Me.ToolStripButton_Root, Me.ToolStripButton_Ontologies})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(488, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripLabel_Filter
        '
        Me.ToolStripLabel_Filter.Name = "ToolStripLabel_Filter"
        Me.ToolStripLabel_Filter.Size = New System.Drawing.Size(46, 22)
        Me.ToolStripLabel_Filter.Text = "x_Filter:"
        '
        'ToolStripTextBox_Filter
        '
        Me.ToolStripTextBox_Filter.Name = "ToolStripTextBox_Filter"
        Me.ToolStripTextBox_Filter.Size = New System.Drawing.Size(300, 25)
        '
        'ToolStripButton_Clear
        '
        Me.ToolStripButton_Clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Clear.Image = Global.Ontology_Module.My.Resources.Resources.tasto_8_architetto_franc_01
        Me.ToolStripButton_Clear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Clear.Name = "ToolStripButton_Clear"
        Me.ToolStripButton_Clear.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Clear.Text = "ToolStripButton1"
        '
        'ToolStripButton_Root
        '
        Me.ToolStripButton_Root.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Root.Image = CType(resources.GetObject("ToolStripButton_Root.Image"), System.Drawing.Image)
        Me.ToolStripButton_Root.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Root.Name = "ToolStripButton_Root"
        Me.ToolStripButton_Root.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripButton_Root.Text = "Root"
        '
        'ToolStripButton_Ontologies
        '
        Me.ToolStripButton_Ontologies.CheckOnClick = True
        Me.ToolStripButton_Ontologies.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Ontologies.Image = CType(resources.GetObject("ToolStripButton_Ontologies.Image"), System.Drawing.Image)
        Me.ToolStripButton_Ontologies.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Ontologies.Name = "ToolStripButton_Ontologies"
        Me.ToolStripButton_Ontologies.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripButton_Ontologies.Text = "Ontologies"
        '
        'Timer_Filter
        '
        Me.Timer_Filter.Interval = 300
        '
        'ContextMenuStrip_Graph
        '
        Me.ContextMenuStrip_Graph.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddRelationsToolStripMenuItem, Me.OpenModuleByArgumentToolStripMenuItem})
        Me.ContextMenuStrip_Graph.Name = "ContextMenuStrip_Graph"
        Me.ContextMenuStrip_Graph.Size = New System.Drawing.Size(225, 48)
        '
        'AddRelationsToolStripMenuItem
        '
        Me.AddRelationsToolStripMenuItem.Name = "AddRelationsToolStripMenuItem"
        Me.AddRelationsToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.AddRelationsToolStripMenuItem.Text = "Add Relations"
        '
        'OpenModuleByArgumentToolStripMenuItem
        '
        Me.OpenModuleByArgumentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenLastModuleToolStripMenuItem})
        Me.OpenModuleByArgumentToolStripMenuItem.Name = "OpenModuleByArgumentToolStripMenuItem"
        Me.OpenModuleByArgumentToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.OpenModuleByArgumentToolStripMenuItem.Text = "Open Module by argumente"
        '
        'OpenLastModuleToolStripMenuItem
        '
        Me.OpenLastModuleToolStripMenuItem.CheckOnClick = True
        Me.OpenLastModuleToolStripMenuItem.Name = "OpenLastModuleToolStripMenuItem"
        Me.OpenLastModuleToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.OpenLastModuleToolStripMenuItem.Text = "x_Open Last Module"
        '
        'UserControl_Graph
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_Graph"
        Me.Size = New System.Drawing.Size(570, 470)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextMenuStrip_Graph.ResumeLayout(False)
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents GViewer_OGraph As Microsoft.Glee.GraphViewerGdi.GViewer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_Filter As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox_Filter As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel_GUID As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox3 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButton_Clear As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer_Filter As System.Windows.Forms.Timer
    Friend WithEvents ToolStripButton_Root As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Ontologies As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStrip_Graph As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddRelationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenModuleByArgumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenLastModuleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
