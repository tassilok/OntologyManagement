<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_Address
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_Address))
        Me.Label_Postfach = New System.Windows.Forms.Label()
        Me.Label_Strasse = New System.Windows.Forms.Label()
        Me.Button_DelPLZOrtLand = New System.Windows.Forms.Button()
        Me.ImageList_UserControl = New System.Windows.Forms.ImageList(Me.components)
        Me.Label_PlzOrtLand = New System.Windows.Forms.Label()
        Me.ToolStripLabel_Partner = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_CountAddresses_lbl = New System.Windows.Forms.ToolStripLabel()
        Me.Button_addPLZOrtLand = New System.Windows.Forms.Button()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Apply = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripProgressBar_Address = New System.Windows.Forms.ToolStripProgressBar()
        Me.TextBox_PLZOrtLand = New System.Windows.Forms.TextBox()
        Me.Label_Zusatz = New System.Windows.Forms.Label()
        Me.TextBox_Strasse = New System.Windows.Forms.TextBox()
        Me.Timer_Address = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Zusatz = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Strasse = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Postfach = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox_Postfach = New System.Windows.Forms.TextBox()
        Me.Button_AddZusatz = New System.Windows.Forms.Button()
        Me.Button_DelZusatz = New System.Windows.Forms.Button()
        Me.DataGridView_Adresszusatz = New System.Windows.Forms.DataGridView()
        Me.Label_Kontakt = New System.Windows.Forms.Label()
        Me.Panel_Kontakt = New System.Windows.Forms.Panel()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView_Adresszusatz, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label_Postfach
        '
        Me.Label_Postfach.AutoSize = True
        Me.Label_Postfach.Location = New System.Drawing.Point(2, 172)
        Me.Label_Postfach.Name = "Label_Postfach"
        Me.Label_Postfach.Size = New System.Drawing.Size(61, 13)
        Me.Label_Postfach.TabIndex = 23
        Me.Label_Postfach.Text = "Postfach_f:"
        '
        'Label_Strasse
        '
        Me.Label_Strasse.AutoSize = True
        Me.Label_Strasse.Location = New System.Drawing.Point(2, 146)
        Me.Label_Strasse.Name = "Label_Strasse"
        Me.Label_Strasse.Size = New System.Drawing.Size(50, 13)
        Me.Label_Strasse.TabIndex = 16
        Me.Label_Strasse.Text = "Straße_f:"
        '
        'Button_DelPLZOrtLand
        '
        Me.Button_DelPLZOrtLand.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_DelPLZOrtLand.ImageIndex = 0
        Me.Button_DelPLZOrtLand.ImageList = Me.ImageList_UserControl
        Me.Button_DelPLZOrtLand.Location = New System.Drawing.Point(509, 229)
        Me.Button_DelPLZOrtLand.Name = "Button_DelPLZOrtLand"
        Me.Button_DelPLZOrtLand.Size = New System.Drawing.Size(27, 23)
        Me.Button_DelPLZOrtLand.TabIndex = 26
        Me.Button_DelPLZOrtLand.UseVisualStyleBackColor = True
        '
        'ImageList_UserControl
        '
        Me.ImageList_UserControl.ImageStream = CType(resources.GetObject("ImageList_UserControl.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_UserControl.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_UserControl.Images.SetKeyName(0, "tasto_8_architetto_franc_01.png")
        Me.ImageList_UserControl.Images.SetKeyName(1, "b_plus.png")
        '
        'Label_PlzOrtLand
        '
        Me.Label_PlzOrtLand.AutoSize = True
        Me.Label_PlzOrtLand.Location = New System.Drawing.Point(2, 200)
        Me.Label_PlzOrtLand.Name = "Label_PlzOrtLand"
        Me.Label_PlzOrtLand.Size = New System.Drawing.Size(87, 13)
        Me.Label_PlzOrtLand.TabIndex = 24
        Me.Label_PlzOrtLand.Text = "PLZ/Ort/Land_f:"
        '
        'ToolStripLabel_Partner
        '
        Me.ToolStripLabel_Partner.Name = "ToolStripLabel_Partner"
        Me.ToolStripLabel_Partner.Size = New System.Drawing.Size(12, 22)
        Me.ToolStripLabel_Partner.Text = "-"
        '
        'ToolStripLabel_CountAddresses_lbl
        '
        Me.ToolStripLabel_CountAddresses_lbl.Name = "ToolStripLabel_CountAddresses_lbl"
        Me.ToolStripLabel_CountAddresses_lbl.Size = New System.Drawing.Size(66, 22)
        Me.ToolStripLabel_CountAddresses_lbl.Text = "x_Adresses:"
        '
        'Button_addPLZOrtLand
        '
        Me.Button_addPLZOrtLand.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_addPLZOrtLand.Enabled = False
        Me.Button_addPLZOrtLand.Location = New System.Drawing.Point(509, 200)
        Me.Button_addPLZOrtLand.Name = "Button_addPLZOrtLand"
        Me.Button_addPLZOrtLand.Size = New System.Drawing.Size(27, 23)
        Me.Button_addPLZOrtLand.TabIndex = 21
        Me.Button_addPLZOrtLand.Text = "..."
        Me.Button_addPLZOrtLand.UseVisualStyleBackColor = True
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Apply, Me.ToolStripSeparator1, Me.ToolStripLabel_CountAddresses_lbl, Me.ToolStripLabel_Partner, Me.ToolStripSeparator2, Me.ToolStripProgressBar_Address})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(540, 25)
        Me.ToolStrip1.TabIndex = 22
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton_Apply
        '
        Me.ToolStripButton_Apply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Apply.Image = CType(resources.GetObject("ToolStripButton_Apply.Image"), System.Drawing.Image)
        Me.ToolStripButton_Apply.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Apply.Name = "ToolStripButton_Apply"
        Me.ToolStripButton_Apply.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripButton_Apply.Text = "x_Apply"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripProgressBar_Address
        '
        Me.ToolStripProgressBar_Address.Name = "ToolStripProgressBar_Address"
        Me.ToolStripProgressBar_Address.Size = New System.Drawing.Size(100, 22)
        '
        'TextBox_PLZOrtLand
        '
        Me.TextBox_PLZOrtLand.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_PLZOrtLand.Location = New System.Drawing.Point(126, 195)
        Me.TextBox_PLZOrtLand.Multiline = True
        Me.TextBox_PLZOrtLand.Name = "TextBox_PLZOrtLand"
        Me.TextBox_PLZOrtLand.ReadOnly = True
        Me.TextBox_PLZOrtLand.Size = New System.Drawing.Size(379, 63)
        Me.TextBox_PLZOrtLand.TabIndex = 20
        '
        'Label_Zusatz
        '
        Me.Label_Zusatz.AutoSize = True
        Me.Label_Zusatz.Location = New System.Drawing.Point(3, 37)
        Me.Label_Zusatz.Name = "Label_Zusatz"
        Me.Label_Zusatz.Size = New System.Drawing.Size(81, 13)
        Me.Label_Zusatz.TabIndex = 18
        Me.Label_Zusatz.Text = "Adresszusatz_f:"
        '
        'TextBox_Strasse
        '
        Me.TextBox_Strasse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Strasse.Location = New System.Drawing.Point(126, 143)
        Me.TextBox_Strasse.Name = "TextBox_Strasse"
        Me.TextBox_Strasse.ReadOnly = True
        Me.TextBox_Strasse.Size = New System.Drawing.Size(377, 20)
        Me.TextBox_Strasse.TabIndex = 17
        '
        'Timer_Address
        '
        Me.Timer_Address.Interval = 300
        '
        'Timer_Zusatz
        '
        Me.Timer_Zusatz.Interval = 300
        '
        'Timer_Strasse
        '
        Me.Timer_Strasse.Interval = 300
        '
        'Timer_Postfach
        '
        '
        'TextBox_Postfach
        '
        Me.TextBox_Postfach.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Postfach.Location = New System.Drawing.Point(126, 169)
        Me.TextBox_Postfach.Name = "TextBox_Postfach"
        Me.TextBox_Postfach.ReadOnly = True
        Me.TextBox_Postfach.Size = New System.Drawing.Size(377, 20)
        Me.TextBox_Postfach.TabIndex = 27
        '
        'Button_AddZusatz
        '
        Me.Button_AddZusatz.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_AddZusatz.Enabled = False
        Me.Button_AddZusatz.ImageIndex = 1
        Me.Button_AddZusatz.ImageList = Me.ImageList_UserControl
        Me.Button_AddZusatz.Location = New System.Drawing.Point(509, 37)
        Me.Button_AddZusatz.Name = "Button_AddZusatz"
        Me.Button_AddZusatz.Size = New System.Drawing.Size(27, 23)
        Me.Button_AddZusatz.TabIndex = 29
        Me.Button_AddZusatz.UseVisualStyleBackColor = True
        '
        'Button_DelZusatz
        '
        Me.Button_DelZusatz.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_DelZusatz.ImageIndex = 0
        Me.Button_DelZusatz.ImageList = Me.ImageList_UserControl
        Me.Button_DelZusatz.Location = New System.Drawing.Point(509, 66)
        Me.Button_DelZusatz.Name = "Button_DelZusatz"
        Me.Button_DelZusatz.Size = New System.Drawing.Size(27, 23)
        Me.Button_DelZusatz.TabIndex = 30
        Me.Button_DelZusatz.UseVisualStyleBackColor = True
        '
        'DataGridView_Adresszusatz
        '
        Me.DataGridView_Adresszusatz.AllowUserToAddRows = False
        Me.DataGridView_Adresszusatz.AllowUserToDeleteRows = False
        Me.DataGridView_Adresszusatz.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView_Adresszusatz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Adresszusatz.Location = New System.Drawing.Point(126, 37)
        Me.DataGridView_Adresszusatz.Name = "DataGridView_Adresszusatz"
        Me.DataGridView_Adresszusatz.ReadOnly = True
        Me.DataGridView_Adresszusatz.Size = New System.Drawing.Size(377, 100)
        Me.DataGridView_Adresszusatz.TabIndex = 31
        '
        'Label_Kontakt
        '
        Me.Label_Kontakt.AutoSize = True
        Me.Label_Kontakt.Location = New System.Drawing.Point(3, 262)
        Me.Label_Kontakt.Name = "Label_Kontakt"
        Me.Label_Kontakt.Size = New System.Drawing.Size(58, 13)
        Me.Label_Kontakt.TabIndex = 32
        Me.Label_Kontakt.Text = "x_Kontakt:"
        '
        'Panel_Kontakt
        '
        Me.Panel_Kontakt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Kontakt.Location = New System.Drawing.Point(126, 262)
        Me.Panel_Kontakt.Name = "Panel_Kontakt"
        Me.Panel_Kontakt.Size = New System.Drawing.Size(379, 165)
        Me.Panel_Kontakt.TabIndex = 33
        '
        'UserControl_Address
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel_Kontakt)
        Me.Controls.Add(Me.Label_Kontakt)
        Me.Controls.Add(Me.DataGridView_Adresszusatz)
        Me.Controls.Add(Me.Button_DelZusatz)
        Me.Controls.Add(Me.Button_AddZusatz)
        Me.Controls.Add(Me.TextBox_Postfach)
        Me.Controls.Add(Me.Label_Postfach)
        Me.Controls.Add(Me.Label_Strasse)
        Me.Controls.Add(Me.Button_DelPLZOrtLand)
        Me.Controls.Add(Me.Label_PlzOrtLand)
        Me.Controls.Add(Me.Button_addPLZOrtLand)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TextBox_PLZOrtLand)
        Me.Controls.Add(Me.Label_Zusatz)
        Me.Controls.Add(Me.TextBox_Strasse)
        Me.Name = "UserControl_Address"
        Me.Size = New System.Drawing.Size(540, 430)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView_Adresszusatz, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label_Postfach As System.Windows.Forms.Label
    Friend WithEvents Label_Strasse As System.Windows.Forms.Label
    Friend WithEvents Button_DelPLZOrtLand As System.Windows.Forms.Button
    Friend WithEvents ImageList_UserControl As System.Windows.Forms.ImageList
    Friend WithEvents Label_PlzOrtLand As System.Windows.Forms.Label
    Friend WithEvents ToolStripLabel_Partner As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_CountAddresses_lbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Button_addPLZOrtLand As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Apply As System.Windows.Forms.ToolStripButton
    Friend WithEvents TextBox_PLZOrtLand As System.Windows.Forms.TextBox
    Friend WithEvents Label_Zusatz As System.Windows.Forms.Label
    Friend WithEvents TextBox_Strasse As System.Windows.Forms.TextBox
    Friend WithEvents Timer_Address As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripProgressBar_Address As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Timer_Zusatz As System.Windows.Forms.Timer
    Friend WithEvents Timer_Strasse As System.Windows.Forms.Timer
    Friend WithEvents Timer_Postfach As System.Windows.Forms.Timer
    Friend WithEvents TextBox_Postfach As System.Windows.Forms.TextBox
    Friend WithEvents Button_AddZusatz As System.Windows.Forms.Button
    Friend WithEvents Button_DelZusatz As System.Windows.Forms.Button
    Friend WithEvents DataGridView_Adresszusatz As System.Windows.Forms.DataGridView
    Friend WithEvents Label_Kontakt As System.Windows.Forms.Label
    Friend WithEvents Panel_Kontakt As System.Windows.Forms.Panel

End Class
