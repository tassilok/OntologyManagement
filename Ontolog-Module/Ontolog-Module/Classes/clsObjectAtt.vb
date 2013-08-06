Public Class clsObjectAtt
    Private strID_Attribute As String
    Private strID_AttributeType As String
    Private strName_AttributeType As String
    Private strID_Object As String
    Private strName_Object As String
    Private strID_Class As String
    Private strName_Class As String
    Private strVal_Named As String
    Private strID_DataType As String
    Private strName_DataType As String
    Private boolVal As Nullable(Of Boolean)
    Private lngVal As Nullable(Of Long)
    Private dblVal As Nullable(Of Double)
    Private dateVal As Nullable(Of Date)
    Private strVal As String
    Private lngOrderID As Nullable(Of Long)

    Public Property ID_DataType As String
        Get
            Return strID_DataType
        End Get
        Set(ByVal value As String)
            strID_DataType = value
        End Set
    End Property
    Public Property ID_Attribute As String
        Get
            Return strID_Attribute
        End Get
        Set(ByVal value As String)
            strID_Attribute = value
        End Set
    End Property

    Public Property ID_AttributeType As String
        Get
            Return strID_AttributeType
        End Get
        Set(ByVal value As String)
            strID_AttributeType = value
        End Set
    End Property

    Public Property Name_AttributeType As String
        Get
            Return strName_AttributeType
        End Get
        Set(ByVal value As String)
            strName_AttributeType = value
        End Set
    End Property

    Public Property ID_Object As String
        Get
            Return strID_Object
        End Get
        Set(ByVal value As String)
            strID_Object = value
        End Set
    End Property

    Public Property Name_Object As String
        Get
            Return strName_Object
        End Get
        Set(ByVal value As String)
            strName_Object = value
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

    Public Property Name_Class As String
        Get
            Return strName_Class
        End Get
        Set(ByVal value As String)
            strName_Class = value
        End Set
    End Property

    Public Property OrderID As Nullable(Of Long)
        Get
            Return lngOrderID
        End Get
        Set(ByVal value As Nullable(Of Long))
            lngOrderID = value
        End Set
    End Property

    Public Property val_Named As String
        Get
            Return strVal_Named
        End Get
        Set(ByVal value As String)
            strVal_Named = value
        End Set
    End Property

    Public Property Val_Bit As Nullable(Of Boolean)
        Get
            Return boolVal
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            boolVal = value
        End Set
    End Property

    Public Property Val_lng As Nullable(Of Long)
        Get
            Return lngVal
        End Get
        Set(ByVal value As Nullable(Of Long))
            lngVal = value
        End Set
    End Property

    Public Property Val_Date As Nullable(Of Date)
        Get
            Return dateVal
        End Get
        Set(ByVal value As Nullable(Of Date))
            dateVal = value
        End Set
    End Property

    Public Property Val_Double As Nullable(Of Double)
        Get
            Return dblVal
        End Get
        Set(ByVal value As Nullable(Of Double))
            dblVal = value
        End Set
    End Property

    Public Property Val_String As String
        Get
            Return strVal
        End Get
        Set(ByVal value As String)
            strVal = value
        End Set
    End Property

    Public Property Name_DataType As String
        Get
            Return strName_DataType
        End Get
        Set(value As String)
            strName_DataType = value
        End Set
    End Property

    Public Sub New(ByVal ID_Attribute As String, ByVal ID_Object As String, ByVal ID_Class As String, ByVal ID_AttributeType As String, ByVal OrderID As Nullable(Of Long))
        strID_Attribute = ID_Attribute
        strID_AttributeType = ID_AttributeType
        strID_Object = ID_Object
        strID_Class = ID_Class
        lngOrderID = OrderID
    End Sub

    Public Sub New(ByVal ID_Attribute As String, ByVal ID_Object As String, ByVal Name_Object As String, ByVal ID_Class As String, ByVal Name_Class As String, ByVal ID_AttributeType As String, ByVal Name_AttributeType As String, ByVal OrderID As Nullable(Of Long), ByVal val_Named As String, ByVal val_Bit As Nullable(Of Boolean), ByVal val_Datetime As Nullable(Of DateTime), ByVal val_Int As Nullable(Of Long), ByVal val_Real As Nullable(Of Double), ByVal val_String As String, ByVal ID_DataType As String)
        strID_Attribute = ID_Attribute
        strID_AttributeType = ID_AttributeType
        strName_AttributeType = Name_AttributeType
        strID_Object = ID_Object
        strName_Object = Name_Object
        strID_Class = ID_Class
        strName_Class = Name_Class
        lngOrderID = OrderID



        strVal_Named = val_Named
        boolVal = val_Bit
        lngVal = val_Int
        dblVal = val_Real
        dateVal = val_Datetime
        strVal = val_String
        strID_DataType = ID_DataType
    End Sub

    Public Sub New(ByVal ID_Attribute As String, ByVal ID_Object As String, ByVal Name_Object As String, ByVal ID_Class As String, ByVal Name_Class As String, ByVal ID_AttributeType As String, ByVal Name_AttributeType As String, ByVal OrderID As Nullable(Of Long), ByVal val_Named As String, ByVal val_Bit As Nullable(Of Boolean), ByVal val_Datetime As Nullable(Of DateTime), ByVal val_Int As Nullable(Of Long), ByVal val_Real As Nullable(Of Double), ByVal val_String As String, ByVal ID_DataType As String, Name_DataType As String)
        strID_Attribute = ID_Attribute
        strID_AttributeType = ID_AttributeType
        strName_AttributeType = Name_AttributeType
        strID_Object = ID_Object
        strName_Object = Name_Object
        strID_Class = ID_Class
        strName_Class = Name_Class
        lngOrderID = OrderID



        strVal_Named = val_Named
        boolVal = val_Bit
        lngVal = val_Int
        dblVal = val_Real
        dateVal = val_Datetime
        strVal = val_String
        strID_DataType = ID_DataType
        strName_DataType = Name_DataType
    End Sub

    Public Sub New()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
