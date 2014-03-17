Imports OntologyClasses.BaseClasses

Public Class UserControl_Filter

    Private objLocalConfig As clsLocalConfig

    Private objFilter As clsFilter

    Public Event FilterItems(objFilter As clsFilter)

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

    End Sub

    Private Sub Button_Filter_Click(sender As Object, e As EventArgs) Handles Button_Filter.Click
        objFilter = New clsFilter
        objFilter.Type = objLocalConfig.Globals.Type_Object

        If RadioButton_NoRel.Checked Then
            objFilter.KindOfRelation = RelationType.NoRelation
        ElseIf RadioButton_LeftRight.Checked Then
            objFilter.KindOfRelation = RelationType.LeftRight
        Else
            objFilter.KindOfRelation = RelationType.RightLeft
        End If

        If Not TextBox_NameToken.Text = "" Then

            If objLocalConfig.Globals.is_GUID(TextBox_NameToken.Text) Then
                objFilter.GUID_Left = TextBox_NameToken.Text
            Else
                objFilter.Name_Left = TextBox_NameToken.Text
            End If
        End If

        If Not TextBox_NameType.Text = "" Then

            If objLocalConfig.Globals.is_GUID(TextBox_NameType.Text) Then
                objFilter.GUID_LeftParent = TextBox_NameType.Text
            Else
                objFilter.Name_LeftParent = TextBox_NameType.Text
            End If
        End If

        If Not TextBox_NameTokenOther.Text = "" Then
            If objLocalConfig.Globals.is_GUID(TextBox_NameTokenOther.Text) Then
                objFilter.GUID_Right = TextBox_NameTokenOther.Text
            Else
                objFilter.Name_Right = TextBox_NameTokenOther.Text
            End If
        End If

        If Not TextBox_NameTypeOther.Text = "" Then
            If objLocalConfig.Globals.is_GUID(TextBox_NameTypeOther.Text) Then
                objFilter.GUID_RightParent = TextBox_NameTypeOther.Text
            Else
                objFilter.Name_RightParent = TextBox_NameTypeOther.Text
            End If
        End If

        If Not TextBox_RelationType.Text = "" Then

            If objLocalConfig.Globals.is_GUID(TextBox_RelationType.Text) Then
                objFilter.GUID_RelationType = TextBox_RelationType.Text
            Else
                objFilter.Name_RelationType = TextBox_RelationType.Text
            End If
        End If

        RaiseEvent FilterItems(objFilter)
    End Sub
End Class
