Public Class clsLocalConfig_Ontologies
    Private Const cint_ImageID_Root As Integer = 0
    Private Const cint_ImageID_Close As Integer = 1
    Private Const cint_ImageID_Close_SubItems As Integer = 2
    Private Const cint_ImageID_Close_Images As Integer = 3
    Private Const cint_ImageID_Close_Images_SubItems As Integer = 4
    Private Const cint_ImageID_Open As Integer = 5
    Private Const cint_ImageID_Open_SubItems As Integer = 6
    Private Const cint_ImageID_Open_Images As Integer = 7
    Private Const cint_ImageID_Open_Images_SubItems As Integer = 8
    Private Const cint_ImageID_Attributes As Integer = 9
    Private Const cint_ImageID_RelationTypes As Integer = 10
    Private Const cint_ImageID_Token As Integer = 11
    Private Const cint_ImageID_Attribute As Integer = 12
    Private Const cint_ImageID_RelationType As Integer = 13
    Private Const cint_ImageID_Token_Named As Integer = 14
    Private Const cint_ImageID_Close_RelateChoose As Integer = 15
    Private Const cint_ImageID_Open_RelateChoose As Integer = 16

    Private Const cint_ImageID_OntologyClose As Integer = 1
    Private Const cint_ImageID_OntologyOpen As Integer = 2

    Private objGlobals As clsGlobals

    Public ReadOnly Property Globals As clsGlobals
        Get
            Return objGlobals
        End Get
    End Property

    Public ReadOnly Property ImageID_Root As Integer
        Get
            Return cint_ImageID_Root
        End Get
    End Property

    Public ReadOnly Property ImageID_Close As Integer
        Get
            Return cint_ImageID_Close
        End Get
    End Property

    Public ReadOnly Property ImageID_Close_SubItems As Integer
        Get
            Return cint_ImageID_Close_SubItems
        End Get
    End Property

    Public ReadOnly Property ImageID_Close_Images As Integer
        Get
            Return cint_ImageID_Close_Images
        End Get
    End Property

    Public ReadOnly Property ImageID_Close_Images_SubItems As Integer
        Get
            Return cint_ImageID_Close_Images_SubItems
        End Get
    End Property

    Public ReadOnly Property ImageID_Open As Integer
        Get
            Return cint_ImageID_Open
        End Get
    End Property

    Public ReadOnly Property ImageID_Open_SubItems As Integer
        Get
            Return cint_ImageID_Open_SubItems
        End Get
    End Property

    Public ReadOnly Property ImageID_Open_Images As Integer
        Get
            Return cint_ImageID_Open_Images
        End Get
    End Property

    Public ReadOnly Property ImageID_Open_Images_SubItems As Integer
        Get
            Return cint_ImageID_Open_Images_SubItems
        End Get
    End Property

    Public ReadOnly Property ImageID_Attributes As Integer
        Get
            Return cint_ImageID_Attributes
        End Get
    End Property

    Public ReadOnly Property ImageID_RelationTypes As Integer
        Get
            Return cint_ImageID_RelationTypes
        End Get
    End Property

    Public ReadOnly Property ImageID_Token As Integer
        Get
            Return cint_ImageID_Token
        End Get
    End Property

    Public ReadOnly Property ImageID_Attribute As Integer
        Get
            Return cint_ImageID_Attribute
        End Get
    End Property

    Public ReadOnly Property ImageID_RelationType As Integer
        Get
            Return cint_ImageID_RelationType
        End Get
    End Property

    Public ReadOnly Property ImageID_Token_Named As Integer
        Get
            Return cint_ImageID_Token_Named
        End Get
    End Property

    Public ReadOnly Property ImageID_Close_RelateChoose As Integer
        Get
            Return cint_ImageID_Close_RelateChoose
        End Get
    End Property

    Public ReadOnly Property ImageID_Open_RelateChoose As Integer
        Get
            Return cint_ImageID_Open_RelateChoose
        End Get
    End Property

    Public ReadOnly Property ImageID_OntologyClose As Integer
        Get
            Return cint_ImageID_OntologyClose
        End Get
    End Property

    Public ReadOnly Property ImageID_OntologyOpen As Integer
        Get
            Return cint_ImageID_OntologyOpen
        End Get
    End Property

    Public Sub New(Globals As clsGlobals)
        objGlobals = Globals
    End Sub
End Class
