Public Class clsOntologyItemsOfOntologies
    Private strID_Ontology As String
    Private strID_OntologyItem As String
    Private strID_Ref As String
    Private strName_Ref As String
    Private strID_Parent_Ref As String
    Private strType_Ref As String
    Private strID_OntologyRelationRule As String
    Private strName_OntologyRelationRule As String


    Public Property ID_Ontology As String
        get
            Return strID_Ontology
        End Get
        Set(value As String)
            strID_Ontology = value
        End Set
    End Property

    Public Property ID_OntologyItem As String
        get
            Return strID_OntologyItem
        End Get
        Set(value As String)
            strID_OntologyItem = value
        End Set
    End Property

    Public Property ID_Ref As String
        get
            Return strID_Ref
        End Get
        Set(value As String)
            strID_Ref = value
        End Set
    End Property

    Public Property Name_Ref As String
        get
            Return strName_Ref
        End Get
        Set(value As String)
            strName_Ref = value
        End Set
    End Property


    Public Property ID_Parent_Ref As String
        get
            Return strID_Parent_Ref
        End Get
        Set(value As String)
            strID_Parent_Ref = value
        End Set
    End Property

    Public Property Type_Ref As String
        get
            Return strType_Ref
        End Get
        Set(value As String)
            strType_Ref = value
        End Set
    End Property

    Public Property ID_OntologyRelationRule As String
        get
            Return strID_OntologyRelationRule
        End Get
        Set(value As String)
            strID_OntologyRelationRule = value
        End Set
    End Property

    Public Property Name_OntologyRelationRule As String
        get
            Return strName_OntologyRelationRule
        End Get
        Set(value As String)
            strName_OntologyRelationRule = value
        End Set
    End Property
End Class
