Imports Ontolog_Module
Imports Media_Viewer_Module
Public Class UserControl_PersonalData
    Private objLocalConfig As clsLocalConfig
    Private objUserControl_ImageViewer As UserControl_ImageViewer

    Private boolPC_Vorname As Boolean

    Private Sub initialize()
        ComboBox_Familienstand.DataSource = objLocalConfig.OList_Familienstand
        ComboBox_Familienstand.ValueMember = "GUID"
        ComboBox_Familienstand.DisplayMember = "Name"


        ComboBox_Geschlecht.DataSource = objLocalConfig.OList_Geschlecht
        ComboBox_Geschlecht.ValueMember = "GUID"
        ComboBox_Geschlecht.DisplayMember = "Name"

        objUserControl_ImageViewer = New UserControl_ImageViewer(objLocalConfig.Globals)
        objUserControl_ImageViewer.Dock = DockStyle.Fill
        Panel_Foto.Controls.Add(objUserControl_ImageViewer)
    End Sub


    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        initialize()
    End Sub

    Private Sub Timer_Vorname_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Vorname.Tick

    End Sub

    Private Sub TextBox_Vorname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_Vorname.TextChanged
        If boolPC_Vorname = False Then
            Timer_Vorname.Start()
        End If
    End Sub
End Class
