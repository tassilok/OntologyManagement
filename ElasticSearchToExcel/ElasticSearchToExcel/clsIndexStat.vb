Public Class clsIndexStat
    Private lngNumDocs As Long

    Public Property NumDocs As Long
        Get
            Return lngNumDocs
        End Get
        Set(ByVal value As Long)
            lngNumDocs = value
        End Set
    End Property
End Class
