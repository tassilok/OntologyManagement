Public Class clsIndexStat
    Private intNumDocs As Integer

    Public Property NumDocs As Integer
        Get
            Return intNumDocs
        End Get
        Set(ByVal value As Integer)
            intNumDocs = value
        End Set
    End Property
End Class
