<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_BillTree
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_BillTree))
        Me.ToolStripContainer2 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripComboBox_SearchTemplates = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripTextBox_Search = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripButton_SemItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Filter = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_CountLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Count = New System.Windows.Forms.ToolStripLabel()
        Me.TreeView_Transactions = New System.Windows.Forms.TreeView()
        Me.ImageList_main = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStripContainer2.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer2.ContentPanel.SuspendLayout()
        Me.ToolStripContainer2.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer2.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer2
        '
        '
        'ToolStripContainer2.BottomToolStripPanel
        '
        Me.ToolStripContainer2.BottomToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'ToolStripContainer2.ContentPanel
        '
        Me.ToolStripContainer2.ContentPanel.Controls.Add(Me.TreeView_Transactions)
        Me.ToolStripContainer2.ContentPanel.Size = New System.Drawing.Size(609, 413)
        Me.ToolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer2.Name = "ToolStripContainer2"
        Me.ToolStripContainer2.Size = New System.Drawing.Size(609, 463)
        Me.ToolStripContainer2.TabIndex = 1
        Me.ToolStripContainer2.Text = "ToolStripContainer2"
        '
        'ToolStripContainer2.TopToolStripPanel
        '
        Me.ToolStripContainer2.TopToolStripPanel.Controls.Add(Me.ToolStrip2)
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox_SearchTemplates, Me.ToolStripTextBox_Search, Me.ToolStripButton_SemItem, Me.ToolStripButton_Filter})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(405, 25)
        Me.ToolStrip2.TabIndex = 0
        '
        'ToolStripComboBox_SearchTemplates
        '
        Me.ToolStripComboBox_SearchTemplates.Name = "ToolStripComboBox_SearchTemplates"
        Me.ToolStripComboBox_SearchTemplates.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripTextBox_Search
        '
        Me.ToolStripTextBox_Search.Name = "ToolStripTextBox_Search"
        Me.ToolStripTextBox_Search.Size = New System.Drawing.Size(200, 25)
        '
        'ToolStripButton_SemItem
        '
        Me.ToolStripButton_SemItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_SemItem.Image = CType(resources.GetObject("ToolStripButton_SemItem.Image"), System.Drawing.Image)
        Me.ToolStripButton_SemItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_SemItem.Name = "ToolStripButton_SemItem"
        Me.ToolStripButton_SemItem.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_SemItem.Text = "..."
        '
        'ToolStripButton_Filter
        '
        Me.ToolStripButton_Filter.Checked = True
        Me.ToolStripButton_Filter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripButton_Filter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Filter.Image = CType(resources.GetObject("ToolStripButton_Filter.Image"), System.Drawing.Image)
        Me.ToolStripButton_Filter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Filter.Name = "ToolStripButton_Filter"
        Me.ToolStripButton_Filter.Size = New System.Drawing.Size(47, 22)
        Me.ToolStripButton_Filter.Text = "x_Filter"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_CountLBL, Me.ToolStripLabel_Count})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(75, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripLabel_CountLBL
        '
        Me.ToolStripLabel_CountLBL.Name = "ToolStripLabel_CountLBL"
        Me.ToolStripLabel_CountLBL.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripLabel_CountLBL.Text = "x_Count:"
        '
        'ToolStripLabel_Count
        '
        Me.ToolStripLabel_Count.Name = "ToolStripLabel_Count"
        Me.ToolStripLabel_Count.Size = New System.Drawing.Size(13, 22)
        Me.ToolStripLabel_Count.Text = "0"
        '
        'TreeView_Transactions
        '
        Me.TreeView_Transactions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView_Transactions.ImageIndex = 0
        Me.TreeView_Transactions.ImageList = Me.ImageList_main
        Me.TreeView_Transactions.Location = New System.Drawing.Point(0, 0)
        Me.TreeView_Transactions.Name = "TreeView_Transactions"
        Me.TreeView_Transactions.SelectedImageIndex = 8
        Me.TreeView_Transactions.Size = New System.Drawing.Size(609, 413)
        Me.TreeView_Transactions.TabIndex = 1
        '
        'ImageList_main
        '
        Me.ImageList_main.ImageStream = CType(resources.GetObject("ImageList_main.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_main.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_main.Images.SetKeyName(0, "calcolatrice_architetto__01.png")
        Me.ImageList_main.Images.SetKeyName(1, "simple_calculator_01.png")
        Me.ImageList_main.Images.SetKeyName(2, "cross_hand_drawn_linda_k_02.png")
        Me.ImageList_main.Images.SetKeyName(3, "smiley114.png")
        Me.ImageList_main.Images.SetKeyName(4, "people_juliane_krug_04c.png")
        Me.ImageList_main.Images.SetKeyName(5, "arrow-left-red_benji_par_01.png")
        Me.ImageList_main.Images.SetKeyName(6, "arrow-right-green_benji__01.png")
        Me.ImageList_main.Images.SetKeyName(7, "bb_home_.png")
        Me.ImageList_main.Images.SetKeyName(8, "calcolatrice_architetto__01 Selected.png")
        '
        'UserControl_BillTree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer2)
        Me.Name = "UserControl_BillTree"
        Me.Size = New System.Drawing.Size(609, 463)
        Me.ToolStripContainer2.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer2.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer2.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer2.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer2.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer2.ResumeLayout(False)
        Me.ToolStripContainer2.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer2 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripComboBox_SearchTemplates As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripTextBox_Search As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButton_SemItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Filter As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_CountLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Count As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TreeView_Transactions As System.Windows.Forms.TreeView
    Friend WithEvents ImageList_main As System.Windows.Forms.ImageList

End Class
