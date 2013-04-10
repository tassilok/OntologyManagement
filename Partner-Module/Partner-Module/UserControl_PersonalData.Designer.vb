<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_PersonalData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_PersonalData))
        Me.ImageList_Main = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer_Nachname = New System.Windows.Forms.Timer(Me.components)
        Me.Label_Photo = New System.Windows.Forms.Label()
        Me.Timer_Geburtsdatum = New System.Windows.Forms.Timer(Me.components)
        Me.Button_AddImageNew = New System.Windows.Forms.Button()
        Me.Timer_Vorname = New System.Windows.Forms.Timer(Me.components)
        Me.Button_DelPhoto = New System.Windows.Forms.Button()
        Me.Button_AddImageExisting = New System.Windows.Forms.Button()
        Me.Panel_Foto = New System.Windows.Forms.Panel()
        Me.Button_Del_Todesdatum = New System.Windows.Forms.Button()
        Me.MaskedTextBox_Todesdatum = New System.Windows.Forms.MaskedTextBox()
        Me.Button_Todesdatum = New System.Windows.Forms.Button()
        Me.Label_Todesdatum = New System.Windows.Forms.Label()
        Me.Button_Del_Steuernummer = New System.Windows.Forms.Button()
        Me.Button_Del_INr = New System.Windows.Forms.Button()
        Me.Button_Del_eTin = New System.Windows.Forms.Button()
        Me.Button_Del_Sozialversicherungsnummer = New System.Windows.Forms.Button()
        Me.Button_Del_Geburtsdatum = New System.Windows.Forms.Button()
        Me.Button_Steuernummer = New System.Windows.Forms.Button()
        Me.Button_INr = New System.Windows.Forms.Button()
        Me.Button_eTin = New System.Windows.Forms.Button()
        Me.Button_Sozialversicherungsnummer = New System.Windows.Forms.Button()
        Me.TextBox_Steuernummer = New System.Windows.Forms.TextBox()
        Me.Label_Steuernummer = New System.Windows.Forms.Label()
        Me.TextBox_Identifikationsnummer = New System.Windows.Forms.TextBox()
        Me.Label_Identifikationsnummer = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripProgressBar_Data = New System.Windows.Forms.ToolStripProgressBar()
        Me.TextBox_eTin = New System.Windows.Forms.TextBox()
        Me.Label_eTin = New System.Windows.Forms.Label()
        Me.TextBox_Sozialversicherungsnummer = New System.Windows.Forms.TextBox()
        Me.Label_Sozialversicherungsnummer = New System.Windows.Forms.Label()
        Me.MaskedTextBox_Geburtsdatum = New System.Windows.Forms.MaskedTextBox()
        Me.Button_Geburtsdatum = New System.Windows.Forms.Button()
        Me.Label_Geburtsdatum = New System.Windows.Forms.Label()
        Me.ComboBox_Familienstand = New System.Windows.Forms.ComboBox()
        Me.Label_Familienstand = New System.Windows.Forms.Label()
        Me.TextBox_Nachname = New System.Windows.Forms.TextBox()
        Me.Label_Geschlecht = New System.Windows.Forms.Label()
        Me.Label_Nachname = New System.Windows.Forms.Label()
        Me.ComboBox_Geschlecht = New System.Windows.Forms.ComboBox()
        Me.TextBox_Vorname = New System.Windows.Forms.TextBox()
        Me.Timer_Data = New System.Windows.Forms.Timer(Me.components)
        Me.Label_Vorname = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList_Main
        '
        Me.ImageList_Main.ImageStream = CType(resources.GetObject("ImageList_Main.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_Main.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_Main.Images.SetKeyName(0, "delete.png")
        Me.ImageList_Main.Images.SetKeyName(1, "b_plus.png")
        '
        'Timer_Nachname
        '
        Me.Timer_Nachname.Interval = 300
        '
        'Label_Photo
        '
        Me.Label_Photo.AutoSize = True
        Me.Label_Photo.Location = New System.Drawing.Point(15, 270)
        Me.Label_Photo.Name = "Label_Photo"
        Me.Label_Photo.Size = New System.Drawing.Size(42, 13)
        Me.Label_Photo.TabIndex = 76
        Me.Label_Photo.Text = "x_Foto:"
        '
        'Timer_Geburtsdatum
        '
        Me.Timer_Geburtsdatum.Interval = 300
        '
        'Button_AddImageNew
        '
        Me.Button_AddImageNew.ImageIndex = 1
        Me.Button_AddImageNew.ImageList = Me.ImageList_Main
        Me.Button_AddImageNew.Location = New System.Drawing.Point(288, 270)
        Me.Button_AddImageNew.Name = "Button_AddImageNew"
        Me.Button_AddImageNew.Size = New System.Drawing.Size(29, 23)
        Me.Button_AddImageNew.TabIndex = 75
        Me.Button_AddImageNew.UseVisualStyleBackColor = True
        '
        'Timer_Vorname
        '
        Me.Timer_Vorname.Interval = 300
        '
        'Button_DelPhoto
        '
        Me.Button_DelPhoto.ImageIndex = 0
        Me.Button_DelPhoto.ImageList = Me.ImageList_Main
        Me.Button_DelPhoto.Location = New System.Drawing.Point(323, 270)
        Me.Button_DelPhoto.Name = "Button_DelPhoto"
        Me.Button_DelPhoto.Size = New System.Drawing.Size(29, 23)
        Me.Button_DelPhoto.TabIndex = 74
        Me.Button_DelPhoto.UseVisualStyleBackColor = True
        '
        'Button_AddImageExisting
        '
        Me.Button_AddImageExisting.Location = New System.Drawing.Point(288, 299)
        Me.Button_AddImageExisting.Name = "Button_AddImageExisting"
        Me.Button_AddImageExisting.Size = New System.Drawing.Size(29, 23)
        Me.Button_AddImageExisting.TabIndex = 73
        Me.Button_AddImageExisting.Text = "..."
        Me.Button_AddImageExisting.UseVisualStyleBackColor = True
        '
        'Panel_Foto
        '
        Me.Panel_Foto.Location = New System.Drawing.Point(165, 270)
        Me.Panel_Foto.Name = "Panel_Foto"
        Me.Panel_Foto.Size = New System.Drawing.Size(117, 167)
        Me.Panel_Foto.TabIndex = 72
        '
        'Button_Del_Todesdatum
        '
        Me.Button_Del_Todesdatum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Del_Todesdatum.ImageIndex = 0
        Me.Button_Del_Todesdatum.ImageList = Me.ImageList_Main
        Me.Button_Del_Todesdatum.Location = New System.Drawing.Point(452, 138)
        Me.Button_Del_Todesdatum.Name = "Button_Del_Todesdatum"
        Me.Button_Del_Todesdatum.Size = New System.Drawing.Size(29, 23)
        Me.Button_Del_Todesdatum.TabIndex = 71
        Me.Button_Del_Todesdatum.UseVisualStyleBackColor = True
        '
        'MaskedTextBox_Todesdatum
        '
        Me.MaskedTextBox_Todesdatum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MaskedTextBox_Todesdatum.Location = New System.Drawing.Point(165, 141)
        Me.MaskedTextBox_Todesdatum.Mask = "00/00/0000"
        Me.MaskedTextBox_Todesdatum.Name = "MaskedTextBox_Todesdatum"
        Me.MaskedTextBox_Todesdatum.ReadOnly = True
        Me.MaskedTextBox_Todesdatum.Size = New System.Drawing.Size(251, 20)
        Me.MaskedTextBox_Todesdatum.TabIndex = 70
        Me.MaskedTextBox_Todesdatum.ValidatingType = GetType(Date)
        '
        'Button_Todesdatum
        '
        Me.Button_Todesdatum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Todesdatum.Location = New System.Drawing.Point(422, 138)
        Me.Button_Todesdatum.Name = "Button_Todesdatum"
        Me.Button_Todesdatum.Size = New System.Drawing.Size(29, 23)
        Me.Button_Todesdatum.TabIndex = 69
        Me.Button_Todesdatum.Text = "..."
        Me.Button_Todesdatum.UseVisualStyleBackColor = True
        '
        'Label_Todesdatum
        '
        Me.Label_Todesdatum.AutoSize = True
        Me.Label_Todesdatum.Location = New System.Drawing.Point(12, 144)
        Me.Label_Todesdatum.Name = "Label_Todesdatum"
        Me.Label_Todesdatum.Size = New System.Drawing.Size(80, 13)
        Me.Label_Todesdatum.TabIndex = 68
        Me.Label_Todesdatum.Text = "x_Todesdatum:"
        '
        'Button_Del_Steuernummer
        '
        Me.Button_Del_Steuernummer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Del_Steuernummer.ImageIndex = 0
        Me.Button_Del_Steuernummer.ImageList = Me.ImageList_Main
        Me.Button_Del_Steuernummer.Location = New System.Drawing.Point(452, 241)
        Me.Button_Del_Steuernummer.Name = "Button_Del_Steuernummer"
        Me.Button_Del_Steuernummer.Size = New System.Drawing.Size(29, 23)
        Me.Button_Del_Steuernummer.TabIndex = 67
        Me.Button_Del_Steuernummer.UseVisualStyleBackColor = True
        '
        'Button_Del_INr
        '
        Me.Button_Del_INr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Del_INr.ImageIndex = 0
        Me.Button_Del_INr.ImageList = Me.ImageList_Main
        Me.Button_Del_INr.Location = New System.Drawing.Point(452, 215)
        Me.Button_Del_INr.Name = "Button_Del_INr"
        Me.Button_Del_INr.Size = New System.Drawing.Size(29, 23)
        Me.Button_Del_INr.TabIndex = 66
        Me.Button_Del_INr.UseVisualStyleBackColor = True
        '
        'Button_Del_eTin
        '
        Me.Button_Del_eTin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Del_eTin.ImageIndex = 0
        Me.Button_Del_eTin.ImageList = Me.ImageList_Main
        Me.Button_Del_eTin.Location = New System.Drawing.Point(452, 190)
        Me.Button_Del_eTin.Name = "Button_Del_eTin"
        Me.Button_Del_eTin.Size = New System.Drawing.Size(29, 23)
        Me.Button_Del_eTin.TabIndex = 65
        Me.Button_Del_eTin.UseVisualStyleBackColor = True
        '
        'Button_Del_Sozialversicherungsnummer
        '
        Me.Button_Del_Sozialversicherungsnummer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Del_Sozialversicherungsnummer.ImageIndex = 0
        Me.Button_Del_Sozialversicherungsnummer.ImageList = Me.ImageList_Main
        Me.Button_Del_Sozialversicherungsnummer.Location = New System.Drawing.Point(452, 163)
        Me.Button_Del_Sozialversicherungsnummer.Name = "Button_Del_Sozialversicherungsnummer"
        Me.Button_Del_Sozialversicherungsnummer.Size = New System.Drawing.Size(29, 23)
        Me.Button_Del_Sozialversicherungsnummer.TabIndex = 64
        Me.Button_Del_Sozialversicherungsnummer.UseVisualStyleBackColor = True
        '
        'Button_Del_Geburtsdatum
        '
        Me.Button_Del_Geburtsdatum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Del_Geburtsdatum.ImageIndex = 0
        Me.Button_Del_Geburtsdatum.ImageList = Me.ImageList_Main
        Me.Button_Del_Geburtsdatum.Location = New System.Drawing.Point(452, 112)
        Me.Button_Del_Geburtsdatum.Name = "Button_Del_Geburtsdatum"
        Me.Button_Del_Geburtsdatum.Size = New System.Drawing.Size(29, 23)
        Me.Button_Del_Geburtsdatum.TabIndex = 63
        Me.Button_Del_Geburtsdatum.UseVisualStyleBackColor = True
        '
        'Button_Steuernummer
        '
        Me.Button_Steuernummer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Steuernummer.Location = New System.Drawing.Point(422, 241)
        Me.Button_Steuernummer.Name = "Button_Steuernummer"
        Me.Button_Steuernummer.Size = New System.Drawing.Size(29, 23)
        Me.Button_Steuernummer.TabIndex = 62
        Me.Button_Steuernummer.Text = "..."
        Me.Button_Steuernummer.UseVisualStyleBackColor = True
        '
        'Button_INr
        '
        Me.Button_INr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_INr.Location = New System.Drawing.Point(422, 215)
        Me.Button_INr.Name = "Button_INr"
        Me.Button_INr.Size = New System.Drawing.Size(29, 23)
        Me.Button_INr.TabIndex = 61
        Me.Button_INr.Text = "..."
        Me.Button_INr.UseVisualStyleBackColor = True
        '
        'Button_eTin
        '
        Me.Button_eTin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_eTin.Location = New System.Drawing.Point(422, 190)
        Me.Button_eTin.Name = "Button_eTin"
        Me.Button_eTin.Size = New System.Drawing.Size(29, 23)
        Me.Button_eTin.TabIndex = 60
        Me.Button_eTin.Text = "..."
        Me.Button_eTin.UseVisualStyleBackColor = True
        '
        'Button_Sozialversicherungsnummer
        '
        Me.Button_Sozialversicherungsnummer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Sozialversicherungsnummer.Location = New System.Drawing.Point(422, 163)
        Me.Button_Sozialversicherungsnummer.Name = "Button_Sozialversicherungsnummer"
        Me.Button_Sozialversicherungsnummer.Size = New System.Drawing.Size(29, 23)
        Me.Button_Sozialversicherungsnummer.TabIndex = 59
        Me.Button_Sozialversicherungsnummer.Text = "..."
        Me.Button_Sozialversicherungsnummer.UseVisualStyleBackColor = True
        '
        'TextBox_Steuernummer
        '
        Me.TextBox_Steuernummer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Steuernummer.Location = New System.Drawing.Point(165, 244)
        Me.TextBox_Steuernummer.Name = "TextBox_Steuernummer"
        Me.TextBox_Steuernummer.ReadOnly = True
        Me.TextBox_Steuernummer.Size = New System.Drawing.Size(251, 20)
        Me.TextBox_Steuernummer.TabIndex = 58
        '
        'Label_Steuernummer
        '
        Me.Label_Steuernummer.AutoSize = True
        Me.Label_Steuernummer.Location = New System.Drawing.Point(12, 247)
        Me.Label_Steuernummer.Name = "Label_Steuernummer"
        Me.Label_Steuernummer.Size = New System.Drawing.Size(89, 13)
        Me.Label_Steuernummer.TabIndex = 57
        Me.Label_Steuernummer.Text = "x_Steuernummer:"
        '
        'TextBox_Identifikationsnummer
        '
        Me.TextBox_Identifikationsnummer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Identifikationsnummer.Location = New System.Drawing.Point(165, 218)
        Me.TextBox_Identifikationsnummer.Name = "TextBox_Identifikationsnummer"
        Me.TextBox_Identifikationsnummer.ReadOnly = True
        Me.TextBox_Identifikationsnummer.Size = New System.Drawing.Size(251, 20)
        Me.TextBox_Identifikationsnummer.TabIndex = 56
        '
        'Label_Identifikationsnummer
        '
        Me.Label_Identifikationsnummer.AutoSize = True
        Me.Label_Identifikationsnummer.Location = New System.Drawing.Point(12, 221)
        Me.Label_Identifikationsnummer.Name = "Label_Identifikationsnummer"
        Me.Label_Identifikationsnummer.Size = New System.Drawing.Size(143, 13)
        Me.Label_Identifikationsnummer.TabIndex = 55
        Me.Label_Identifikationsnummer.Text = "x_Identifikationsnummer(INr):"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar_Data})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 441)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(486, 25)
        Me.ToolStrip1.TabIndex = 54
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripProgressBar_Data
        '
        Me.ToolStripProgressBar_Data.Maximum = 10
        Me.ToolStripProgressBar_Data.Name = "ToolStripProgressBar_Data"
        Me.ToolStripProgressBar_Data.Size = New System.Drawing.Size(200, 22)
        Me.ToolStripProgressBar_Data.Step = 1
        '
        'TextBox_eTin
        '
        Me.TextBox_eTin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_eTin.Location = New System.Drawing.Point(165, 193)
        Me.TextBox_eTin.Name = "TextBox_eTin"
        Me.TextBox_eTin.ReadOnly = True
        Me.TextBox_eTin.Size = New System.Drawing.Size(251, 20)
        Me.TextBox_eTin.TabIndex = 53
        '
        'Label_eTin
        '
        Me.Label_eTin.AutoSize = True
        Me.Label_eTin.Location = New System.Drawing.Point(12, 196)
        Me.Label_eTin.Name = "Label_eTin"
        Me.Label_eTin.Size = New System.Drawing.Size(31, 13)
        Me.Label_eTin.TabIndex = 52
        Me.Label_eTin.Text = "eTin:"
        '
        'TextBox_Sozialversicherungsnummer
        '
        Me.TextBox_Sozialversicherungsnummer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Sozialversicherungsnummer.Location = New System.Drawing.Point(165, 166)
        Me.TextBox_Sozialversicherungsnummer.Name = "TextBox_Sozialversicherungsnummer"
        Me.TextBox_Sozialversicherungsnummer.ReadOnly = True
        Me.TextBox_Sozialversicherungsnummer.Size = New System.Drawing.Size(251, 20)
        Me.TextBox_Sozialversicherungsnummer.TabIndex = 51
        '
        'Label_Sozialversicherungsnummer
        '
        Me.Label_Sozialversicherungsnummer.AutoSize = True
        Me.Label_Sozialversicherungsnummer.Location = New System.Drawing.Point(12, 170)
        Me.Label_Sozialversicherungsnummer.Name = "Label_Sozialversicherungsnummer"
        Me.Label_Sozialversicherungsnummer.Size = New System.Drawing.Size(152, 13)
        Me.Label_Sozialversicherungsnummer.TabIndex = 50
        Me.Label_Sozialversicherungsnummer.Text = "x_Sozialversicherungsnummer:"
        '
        'MaskedTextBox_Geburtsdatum
        '
        Me.MaskedTextBox_Geburtsdatum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MaskedTextBox_Geburtsdatum.Location = New System.Drawing.Point(165, 115)
        Me.MaskedTextBox_Geburtsdatum.Mask = "00/00/0000"
        Me.MaskedTextBox_Geburtsdatum.Name = "MaskedTextBox_Geburtsdatum"
        Me.MaskedTextBox_Geburtsdatum.ReadOnly = True
        Me.MaskedTextBox_Geburtsdatum.Size = New System.Drawing.Size(251, 20)
        Me.MaskedTextBox_Geburtsdatum.TabIndex = 49
        Me.MaskedTextBox_Geburtsdatum.ValidatingType = GetType(Date)
        '
        'Button_Geburtsdatum
        '
        Me.Button_Geburtsdatum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Geburtsdatum.Location = New System.Drawing.Point(422, 112)
        Me.Button_Geburtsdatum.Name = "Button_Geburtsdatum"
        Me.Button_Geburtsdatum.Size = New System.Drawing.Size(29, 23)
        Me.Button_Geburtsdatum.TabIndex = 48
        Me.Button_Geburtsdatum.Text = "..."
        Me.Button_Geburtsdatum.UseVisualStyleBackColor = True
        '
        'Label_Geburtsdatum
        '
        Me.Label_Geburtsdatum.AutoSize = True
        Me.Label_Geburtsdatum.Location = New System.Drawing.Point(12, 118)
        Me.Label_Geburtsdatum.Name = "Label_Geburtsdatum"
        Me.Label_Geburtsdatum.Size = New System.Drawing.Size(87, 13)
        Me.Label_Geburtsdatum.TabIndex = 47
        Me.Label_Geburtsdatum.Text = "x_Geburtsdatum:"
        '
        'ComboBox_Familienstand
        '
        Me.ComboBox_Familienstand.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_Familienstand.FormattingEnabled = True
        Me.ComboBox_Familienstand.Location = New System.Drawing.Point(165, 85)
        Me.ComboBox_Familienstand.Name = "ComboBox_Familienstand"
        Me.ComboBox_Familienstand.Size = New System.Drawing.Size(318, 21)
        Me.ComboBox_Familienstand.TabIndex = 46
        '
        'Label_Familienstand
        '
        Me.Label_Familienstand.AutoSize = True
        Me.Label_Familienstand.Location = New System.Drawing.Point(12, 88)
        Me.Label_Familienstand.Name = "Label_Familienstand"
        Me.Label_Familienstand.Size = New System.Drawing.Size(85, 13)
        Me.Label_Familienstand.TabIndex = 45
        Me.Label_Familienstand.Text = "x_Familienstand:"
        '
        'TextBox_Nachname
        '
        Me.TextBox_Nachname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Nachname.Location = New System.Drawing.Point(165, 31)
        Me.TextBox_Nachname.Name = "TextBox_Nachname"
        Me.TextBox_Nachname.Size = New System.Drawing.Size(318, 20)
        Me.TextBox_Nachname.TabIndex = 44
        '
        'Label_Geschlecht
        '
        Me.Label_Geschlecht.AutoSize = True
        Me.Label_Geschlecht.Location = New System.Drawing.Point(12, 61)
        Me.Label_Geschlecht.Name = "Label_Geschlecht"
        Me.Label_Geschlecht.Size = New System.Drawing.Size(75, 13)
        Me.Label_Geschlecht.TabIndex = 42
        Me.Label_Geschlecht.Text = "x_Geschlecht:"
        '
        'Label_Nachname
        '
        Me.Label_Nachname.AutoSize = True
        Me.Label_Nachname.Location = New System.Drawing.Point(12, 34)
        Me.Label_Nachname.Name = "Label_Nachname"
        Me.Label_Nachname.Size = New System.Drawing.Size(73, 13)
        Me.Label_Nachname.TabIndex = 43
        Me.Label_Nachname.Text = "x_Nachname:"
        '
        'ComboBox_Geschlecht
        '
        Me.ComboBox_Geschlecht.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_Geschlecht.FormattingEnabled = True
        Me.ComboBox_Geschlecht.Location = New System.Drawing.Point(165, 58)
        Me.ComboBox_Geschlecht.Name = "ComboBox_Geschlecht"
        Me.ComboBox_Geschlecht.Size = New System.Drawing.Size(318, 21)
        Me.ComboBox_Geschlecht.TabIndex = 41
        '
        'TextBox_Vorname
        '
        Me.TextBox_Vorname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Vorname.Location = New System.Drawing.Point(165, 4)
        Me.TextBox_Vorname.Name = "TextBox_Vorname"
        Me.TextBox_Vorname.Size = New System.Drawing.Size(318, 20)
        Me.TextBox_Vorname.TabIndex = 40
        '
        'Timer_Data
        '
        Me.Timer_Data.Interval = 300
        '
        'Label_Vorname
        '
        Me.Label_Vorname.AutoSize = True
        Me.Label_Vorname.Location = New System.Drawing.Point(12, 7)
        Me.Label_Vorname.Name = "Label_Vorname"
        Me.Label_Vorname.Size = New System.Drawing.Size(63, 13)
        Me.Label_Vorname.TabIndex = 39
        Me.Label_Vorname.Text = "x_Vorname:"
        '
        'UserControl_PersonalData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label_Photo)
        Me.Controls.Add(Me.Button_AddImageNew)
        Me.Controls.Add(Me.Button_DelPhoto)
        Me.Controls.Add(Me.Button_AddImageExisting)
        Me.Controls.Add(Me.Panel_Foto)
        Me.Controls.Add(Me.Button_Del_Todesdatum)
        Me.Controls.Add(Me.MaskedTextBox_Todesdatum)
        Me.Controls.Add(Me.Button_Todesdatum)
        Me.Controls.Add(Me.Label_Todesdatum)
        Me.Controls.Add(Me.Button_Del_Steuernummer)
        Me.Controls.Add(Me.Button_Del_INr)
        Me.Controls.Add(Me.Button_Del_eTin)
        Me.Controls.Add(Me.Button_Del_Sozialversicherungsnummer)
        Me.Controls.Add(Me.Button_Del_Geburtsdatum)
        Me.Controls.Add(Me.Button_Steuernummer)
        Me.Controls.Add(Me.Button_INr)
        Me.Controls.Add(Me.Button_eTin)
        Me.Controls.Add(Me.Button_Sozialversicherungsnummer)
        Me.Controls.Add(Me.TextBox_Steuernummer)
        Me.Controls.Add(Me.Label_Steuernummer)
        Me.Controls.Add(Me.TextBox_Identifikationsnummer)
        Me.Controls.Add(Me.Label_Identifikationsnummer)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TextBox_eTin)
        Me.Controls.Add(Me.Label_eTin)
        Me.Controls.Add(Me.TextBox_Sozialversicherungsnummer)
        Me.Controls.Add(Me.Label_Sozialversicherungsnummer)
        Me.Controls.Add(Me.MaskedTextBox_Geburtsdatum)
        Me.Controls.Add(Me.Button_Geburtsdatum)
        Me.Controls.Add(Me.Label_Geburtsdatum)
        Me.Controls.Add(Me.ComboBox_Familienstand)
        Me.Controls.Add(Me.Label_Familienstand)
        Me.Controls.Add(Me.TextBox_Nachname)
        Me.Controls.Add(Me.Label_Geschlecht)
        Me.Controls.Add(Me.Label_Nachname)
        Me.Controls.Add(Me.ComboBox_Geschlecht)
        Me.Controls.Add(Me.TextBox_Vorname)
        Me.Controls.Add(Me.Label_Vorname)
        Me.Name = "UserControl_PersonalData"
        Me.Size = New System.Drawing.Size(486, 466)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList_Main As System.Windows.Forms.ImageList
    Friend WithEvents Timer_Nachname As System.Windows.Forms.Timer
    Friend WithEvents Label_Photo As System.Windows.Forms.Label
    Friend WithEvents Timer_Geburtsdatum As System.Windows.Forms.Timer
    Friend WithEvents Button_AddImageNew As System.Windows.Forms.Button
    Friend WithEvents Timer_Vorname As System.Windows.Forms.Timer
    Friend WithEvents Button_DelPhoto As System.Windows.Forms.Button
    Friend WithEvents Button_AddImageExisting As System.Windows.Forms.Button
    Friend WithEvents Panel_Foto As System.Windows.Forms.Panel
    Friend WithEvents Button_Del_Todesdatum As System.Windows.Forms.Button
    Friend WithEvents MaskedTextBox_Todesdatum As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Button_Todesdatum As System.Windows.Forms.Button
    Friend WithEvents Label_Todesdatum As System.Windows.Forms.Label
    Friend WithEvents Button_Del_Steuernummer As System.Windows.Forms.Button
    Friend WithEvents Button_Del_INr As System.Windows.Forms.Button
    Friend WithEvents Button_Del_eTin As System.Windows.Forms.Button
    Friend WithEvents Button_Del_Sozialversicherungsnummer As System.Windows.Forms.Button
    Friend WithEvents Button_Del_Geburtsdatum As System.Windows.Forms.Button
    Friend WithEvents Button_Steuernummer As System.Windows.Forms.Button
    Friend WithEvents Button_INr As System.Windows.Forms.Button
    Friend WithEvents Button_eTin As System.Windows.Forms.Button
    Friend WithEvents Button_Sozialversicherungsnummer As System.Windows.Forms.Button
    Friend WithEvents TextBox_Steuernummer As System.Windows.Forms.TextBox
    Friend WithEvents Label_Steuernummer As System.Windows.Forms.Label
    Friend WithEvents TextBox_Identifikationsnummer As System.Windows.Forms.TextBox
    Friend WithEvents Label_Identifikationsnummer As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripProgressBar_Data As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents TextBox_eTin As System.Windows.Forms.TextBox
    Friend WithEvents Label_eTin As System.Windows.Forms.Label
    Friend WithEvents TextBox_Sozialversicherungsnummer As System.Windows.Forms.TextBox
    Friend WithEvents Label_Sozialversicherungsnummer As System.Windows.Forms.Label
    Friend WithEvents MaskedTextBox_Geburtsdatum As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Button_Geburtsdatum As System.Windows.Forms.Button
    Friend WithEvents Label_Geburtsdatum As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Familienstand As System.Windows.Forms.ComboBox
    Friend WithEvents Label_Familienstand As System.Windows.Forms.Label
    Friend WithEvents TextBox_Nachname As System.Windows.Forms.TextBox
    Friend WithEvents Label_Geschlecht As System.Windows.Forms.Label
    Friend WithEvents Label_Nachname As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Geschlecht As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox_Vorname As System.Windows.Forms.TextBox
    Friend WithEvents Timer_Data As System.Windows.Forms.Timer
    Friend WithEvents Label_Vorname As System.Windows.Forms.Label

End Class
