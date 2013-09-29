Public Class clsDataTypes
    Private objOItem_DType_Bool As clsOntologyItem
    Private objOItem_DType_DateTime As clsOntologyItem
    Private objOItem_DType_Int As clsOntologyItem
    Private objOItem_DType_Real As clsOntologyItem
    Private objOItem_DType_String As clsOntologyItem

    Private objTypes As New clsTypes

    Public ReadOnly Property DType_Bool As clsOntologyItem
        Get
            Return objOItem_DType_Bool
        End Get
    End Property

    Public ReadOnly Property DType_DateTime As clsOntologyItem
        Get
            Return objOItem_DType_DateTime
        End Get
    End Property

    Public ReadOnly Property DType_Int As clsOntologyItem
        Get
            Return objOItem_DType_Int
        End Get
    End Property

    Public ReadOnly Property DType_Real As clsOntologyItem
        Get
            Return objOItem_DType_Real
        End Get
    End Property

    Public ReadOnly Property DType_String As clsOntologyItem
        Get
            Return objOItem_DType_String
        End Get
    End Property

    Public Sub New()
        objOItem_DType_Bool = New clsOntologyItem("dd858f27d5e14363a5c33e561e432333", "Bool", objTypes.DataType)
        objOItem_DType_DateTime = New clsOntologyItem("905fda81788f4e3d83293e55ae984b9e", "Datetime", objTypes.DataType)
        objOItem_DType_Int = New clsOntologyItem("3a4f5b7bda754980933efbc33cc51439", "Int", objTypes.DataType)
        objOItem_DType_Real = New clsOntologyItem("a1244d0e187f46ee85742fc334077b7d", "Real", objTypes.DataType)
        objOItem_DType_String = New clsOntologyItem("64530b52d96c4df186fe183f44513450", "String", objTypes.DataType)

    End Sub
End Class
