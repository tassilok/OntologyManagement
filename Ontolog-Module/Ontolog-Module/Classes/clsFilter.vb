Imports OntologyClasses.BaseClasses

<Flags>
Public Enum RelationType
    NoRelation = 0
    LeftRight = 1
    RightLeft = 2
End Enum

Public Class clsFilter
    Public Property KindOfRelation As RelationType
    Public Property GUID_Left As String
    Public Property Name_Left As String
    Public Property GUID_LeftParent As String
    Public Property Name_LeftParent As String
    Public Property GUID_Right As String
    Public Property Name_Right As String
    Public Property GUID_RightParent As String
    Public Property Name_RightParent As String
    Public Property GUID_RelationType As String
    Public Property Name_RelationType As String
    Public Property Type As String
    Public Property SaveName As String

End Class
