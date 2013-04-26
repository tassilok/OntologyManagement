Public Class clsStoreStat
    Private dblSize As Double

    Public Property Size As Double
        Get
            Return dblSize

        End Get
        Set(ByVal value As Double)
            dblSize = value
        End Set
    End Property
End Class
