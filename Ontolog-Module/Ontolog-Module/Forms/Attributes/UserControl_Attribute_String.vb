Public Class UserControl_Attribute_String

    Public Event TextChanged()

    Public Property Value As String
        Get
            Return TextBox_Val.Text
        End Get
        Set(ByVal value As String)
            TextBox_Val.Text = value
        End Set
    End Property


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub TextBox_Val_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Val.TextChanged
        RaiseEvent TextChanged()
    End Sub
End Class
