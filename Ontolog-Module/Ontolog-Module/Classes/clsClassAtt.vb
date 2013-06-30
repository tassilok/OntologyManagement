Public Class clsClassAtt
    Private strID_AttributeType As String
    Private strID_Class As String
    Private strID_DataType As String
    Private lngMin As Nullable(Of Long)
    Private lngMax As Nullable(Of Long)

    Public Property ID_AttributeType As String
        Get
            Return strID_AttributeType
        End Get
        Set(ByVal value As String)
            strID_AttributeType = value
        End Set
    End Property

    Public Property ID_Class As String
        Get
            Return strID_Class
        End Get
        Set(ByVal value As String)
            strID_Class = value
        End Set
    End Property

    Public Property ID_DataType As String
        Get
            Return strID_DataType
        End Get
        Set(ByVal value As String)
            strID_DataType = value
        End Set
    End Property

    Public Property Min As Nullable(Of Long)
        Get
            Return lngMin
        End Get
        Set(ByVal value As Nullable(Of Long))
            lngMin = value
        End Set
    End Property

    Public Property Max As Nullable(Of Long)
        Get
            Return lngMax
        End Get
        Set(ByVal value As Nullable(Of Long))
            lngMax = value
        End Set
    End Property


    Public Sub New(ByVal ID_AttributeType As String, ByVal ID_DataType As String, ByVal ID_Class As String, ByVal Min As Nullable(Of Long), ByVal Max As Nullable(Of Long))
        strID_AttributeType = ID_AttributeType
        strID_DataType = ID_DataType
        strID_Class = ID_Class
        lngMin = Min
        lngMax = Max
    End Sub

    Public Sub New()

    End Sub
End Class
