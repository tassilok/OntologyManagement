Imports Ontolog_Module
Public Class clsAmount
    Private strID_Amount As String
    Private strName_Amount As String
    Private strID_Unit As String
    Private strName_Unit As String
    Private strID_Attribute As String
    Private dblVal As Double

    Public Property ID_Amount As String
        Get
            Return strID_Amount
        End Get
        Set(ByVal value As String)
            strID_Amount = value
        End Set
    End Property

    Public Property Name_Amount As String
        Get
            Return strName_Amount
        End Get
        Set(ByVal value As String)
            strName_Amount = value
        End Set
    End Property

    Public Property ID_Unit As String
        Get
            Return strID_Unit
        End Get
        Set(ByVal value As String)
            strID_Unit = value
        End Set
    End Property

    Public Property Name_Unit As String
        Get
            Return strName_Unit
        End Get
        Set(ByVal value As String)
            strName_Unit = value
        End Set
    End Property

    Public Property ID_Attribute_Value As String
        Get
            Return strID_Attribute
        End Get
        Set(ByVal value As String)
            strID_Attribute = value
        End Set
    End Property

    Public Property Val As Double
        Get
            Return dblVal
        End Get
        Set(ByVal value As Double)
            dblVal = value

        End Set
    End Property

    Public Sub New(ByVal ID_Amount As String, ByVal Name_Amount As String, ByVal ID_Unit As String, ByVal Name_Unit As String, ByVal ID_Attribute_Value As String, ByVal dblVal As Double)
        strID_Amount = ID_Amount
        strName_Amount = Name_Amount
        strID_Unit = ID_Unit
        strName_Unit = Name_Unit
        strID_Attribute = ID_Attribute_Value
        Me.dblVal = dblVal
    End Sub
End Class
