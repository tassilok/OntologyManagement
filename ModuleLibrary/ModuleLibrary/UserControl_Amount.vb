Imports Ontolog_Module
Public Class UserControl_Amount
    Private objLocalConfig As clsLocalConfig

    Private objDataWork_Amount As clsDataWork_Amount
    Private objTransaction_Amount As clsTransaction_Amount

    Private objOItem_Amount As clsOntologyItem
    Private objLAmount As New List(Of clsAmount)

    Private strVal As String

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = LocalConfig

        initialize()
    End Sub

    Public Sub initialize_Amount(ByVal OItem_Amount As clsOntologyItem)
        objOItem_Amount = OItem_Amount

        clear_Controls()
        If Not objOItem_Amount Is Nothing Then
            objLAmount = objDataWork_Amount.get_Amounts(objOItem_Amount)
            If Not objLAmount Is Nothing Then
                If objLAmount.Count > 0 Then
                    TextBox_Amount.ReadOnly = True
                    If Not objLAmount(0).Val = Nothing Then
                        TextBox_Amount.Text = objLAmount(0).Val
                    Else
                        TextBox_Amount.Text = ""
                    End If

                    TextBox_Amount.ReadOnly = False

                    ComboBox_Unit.Enabled = False
                    If Not objLAmount(0).ID_Unit = Nothing Then
                        ComboBox_Unit.SelectedValue = objLAmount(0).ID_Unit
                    Else
                        ComboBox_Unit.SelectedItem = Nothing
                    End If

                    ComboBox_Unit.Enabled = True
                Else
                    TextBox_Amount.ReadOnly = False
                    ComboBox_Unit.Enabled = True
                End If

            Else
                MsgBox("Beim Auslesen der Menge ist ein Fehler unterlaufen!", MsgBoxStyle.Exclamation)
            End If


        End If
    End Sub

    Private Sub clear_Controls()
        TextBox_Amount.ReadOnly = True
        TextBox_Amount.Text = ""
        ComboBox_Unit.Enabled = False
        ComboBox_Unit.SelectedItem = Nothing
    End Sub

    Private Sub initialize()
        objDataWork_Amount = New clsDataWork_Amount(objLocalConfig)
        objTransaction_Amount = New clsTransaction_Amount(objLocalConfig)

        ComboBox_Unit.DataSource = objDataWork_Amount.get_Data_Units()
        ComboBox_Unit.ValueMember = "GUID"
        ComboBox_Unit.DisplayMember = "Name"

        clear_Controls()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = New clsLocalConfig(Globals)

        initialize()
    End Sub

    Private Sub TextBox_Amount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_Amount.TextChanged
        Dim dblVal As Double
        Timer_Amount.Stop()
        If TextBox_Amount.ReadOnly = False Then
            If TextBox_Amount.Text <> strVal Then
                If Double.TryParse(TextBox_Amount.Text, dblVal) = False Then
                    MsgBox("Bitte nur Numerische Werte eingeben!", MsgBoxStyle.Information)
                    TextBox_Amount.ReadOnly = True
                    TextBox_Amount.Text = strVal
                    TextBox_Amount.ReadOnly = False
                Else
                    strVal = TextBox_Amount.Text
                    Timer_Amount.Start()
                End If
            End If

        End If
    End Sub

    Private Sub Timer_Amount_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Amount.Tick
        Dim objOItem_Result As clsOntologyItem
        Timer_Amount.Stop()
        If TextBox_Amount.Text = "" Then
            objOItem_Result = objTransaction_Amount.del_003_Amount_To_Unit(objOItem_Amount)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Else
                MsgBox("Der Wert kann nicht geändert werden!", MsgBoxStyle.Exclamation)
            End If
        Else

        End If
    End Sub
End Class
