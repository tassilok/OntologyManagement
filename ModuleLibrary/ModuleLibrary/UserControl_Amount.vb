Imports Ontolog_Module
Imports OntologyClasses.BaseClasses
Public Class UserControl_Amount
    Private objLocalConfig As clsLocalConfig

    Private objDataWork_Amount As clsDataWork_Amount
    Private objTransaction_Amount As clsTransaction_Amount

    Private objOItem_Amount As clsOntologyItem

    Private strVal As String

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = LocalConfig

        initialize()
    End Sub

    Public Sub initialize_Amount(ByVal OItem_Amount As clsOntologyItem)
        Dim objOItem_Result As clsOntologyItem
        objOItem_Amount = OItem_Amount

        clear_Controls()
        If Not objOItem_Amount Is Nothing Then
            objOItem_Result = objDataWork_Amount.get_Data_Amounts(objOItem_Amount)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objDataWork_Amount.Amount_Atts.Count > 0 Then
                    TextBox_Amount.ReadOnly = True
                    If Not objDataWork_Amount.Amount_Atts(0).Val_Double = Nothing Then
                        TextBox_Amount.Text = objDataWork_Amount.Amount_Atts(0).Val_Double
                    Else
                        TextBox_Amount.Text = ""
                    End If

                    


                End If

                TextBox_Amount.ReadOnly = False

                If objDataWork_Amount.Amount_Rels.Count > 0 Then
                    ComboBox_Unit.Enabled = False
                    If Not objDataWork_Amount.Amount_Rels(0).ID_Other = Nothing Then
                        ComboBox_Unit.SelectedValue = objDataWork_Amount.Amount_Rels(0).ID_Other
                    Else
                        ComboBox_Unit.SelectedItem = Nothing
                    End If



                End If


                ComboBox_Unit.Enabled = True
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

        ComboBox_Unit.Enabled = False
        ComboBox_Unit.DataSource = objDataWork_Amount.get_Data_Units()
        ComboBox_Unit.ValueMember = "GUID"
        ComboBox_Unit.DisplayMember = "Name"
        ComboBox_Unit.Enabled = True

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
        Dim dblAmount As Double
        Timer_Amount.Stop()

        If TextBox_Amount.Text = "" Then
            objOItem_Result = objTransaction_Amount.del_002_Amount__Amount(objOItem_Amount)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Der Wert kann nicht geändert werden!", MsgBoxStyle.Exclamation)
                initialize_Amount(objOItem_Amount)
            End If
        Else
            If Double.TryParse(TextBox_Amount.Text, dblAmount) Then
                objOItem_Result = objTransaction_Amount.save_002_Amount__Amount(dblAmount, objOItem_Amount)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    MsgBox("Der Wert kann nicht geändert werden!", MsgBoxStyle.Exclamation)
                    initialize_Amount(objOItem_Amount)
                End If
            Else
                MsgBox("Der Wert ist nicht numerisch!", MsgBoxStyle.Exclamation)
                initialize_Amount(objOItem_Amount)
            End If
        End If


    End Sub

   
    Private Sub ComboBox_Unit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox_Unit.SelectedIndexChanged
        Dim objOItem_Result As clsOntologyItem
        If ComboBox_Unit.Enabled = True Then
            If ComboBox_Unit.SelectedItem Is Nothing Then
                objOItem_Result = objTransaction_Amount.del_003_Amount_To_Unit(objOItem_Amount)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    MsgBox("Der Wert kann nicht geändert werden!", MsgBoxStyle.Exclamation)
                    initialize_Amount(objOItem_Amount)
                End If
            Else
                objOItem_Result = objTransaction_Amount.save_003_Amount_To_Unit(ComboBox_Unit.SelectedItem, objOItem_Amount)
            End If
        End If
        
    End Sub
End Class
