Imports Microsoft.Glee.Drawing

Public  Class clsGraphAttributes
    Public ReadOnly Property ShapeClass As Microsoft.Glee.Drawing.Shape
        Get
            Return Shape.Mdiamond
        End Get
    End Property
    
    Public ReadOnly Property ShapeObject As Microsoft.Glee.Drawing.Shape
        Get
            Return Shape.Box
        End Get
    End Property

    Public ReadOnly Property ShapeAttributeType As Microsoft.Glee.Drawing.Shape
        Get
            Return Shape.Circle
        End Get
    End Property

    Public ReadOnly Property ShapeAttribute As Microsoft.Glee.Drawing.Shape
        Get
            Return Shape.DoubleCircle
        End Get
    End Property

    Public ReadOnly Property ShapeRelationType As Microsoft.Glee.Drawing.Shape
        Get
            Return Shape.Triangle
        End Get
    End Property

    Public ReadOnly Property ColorClass As Microsoft.Glee.Drawing.Color
        Get
            Return Color.MintCream
        End Get
    End Property

    Public ReadOnly Property ColorClassMarked As Microsoft.Glee.Drawing.Color
        Get
            Return Color.Chartreuse
        End Get
    End Property

    Public ReadOnly Property ColorObject As Microsoft.Glee.Drawing.Color
        Get
            Return Color.LightCyan
        End Get
    End Property

    Public ReadOnly Property ColorObjectMarked As Microsoft.Glee.Drawing.Color
        Get
            Return Color.Chartreuse
        End Get
    End Property

    Public ReadOnly Property ColorAttributeType As Microsoft.Glee.Drawing.Color
        Get
            Return Color.Azure
        End Get
    End Property
End Class
