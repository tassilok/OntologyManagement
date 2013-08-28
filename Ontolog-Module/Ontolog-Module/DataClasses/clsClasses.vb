Public Class clsClasses
    Private objOItem_Class_Root As clsOntologyItem
    Private objOItem_Class_Logstate As clsOntologyItem
    Private objOItem_Class_Directions As clsOntologyItem
    Private objOItem_Class_System As clsOntologyItem
    Private objOItem_Class_Ontologies As clsOntologyItem
    Private objOItem_Class_OntologyItems As clsOntologyItem
    Private objOItem_Class_OntologyRelationRule As clsOntologyItem
    Private objOItem_Class_OntologyJoin As clsOntologyItem
    Private objOItem_Class_Server As clsOntologyItem

    Private objTypes As New clsTypes

    Public ReadOnly Property OItem_Class_Server As clsOntologyItem
        Get
            Return objOItem_Class_Server
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Root As clsOntologyItem
        Get
            Return objOItem_Class_Root
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Directions As clsOntologyItem
        Get
            Return objOItem_Class_Directions
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Logstate As clsOntologyItem
        Get
            Return objOItem_Class_Logstate
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Ontologies As clsOntologyItem
        Get
            Return objOItem_Class_Ontologies
        End Get
    End Property

    Public ReadOnly Property OItem_Class_OntologyItems As clsOntologyItem
        Get
            Return objOItem_Class_OntologyItems
        End Get
    End Property

    Public ReadOnly Property OItem_Class_OntologyJoin As clsOntologyItem
        Get
            Return objOItem_Class_OntologyJoin
        End Get
    End Property

    Public ReadOnly Property OItem_Class_OntologyRelationRule As clsOntologyItem
        Get
            Return objOItem_Class_OntologyRelationRule
        End Get
    End Property

    Public ReadOnly Property OItem_Class_System As clsOntologyItem
        Get
            Return objOItem_Class_System
        End Get
    End Property
    Public Sub New()
        objOItem_Class_Root = New clsOntologyItem("49fdcd27e1054770941d7485dcad08c1", "Root", "dbbfc1a00c2e483684340a7b7a8b4b52")
        objOItem_Class_System = New clsOntologyItem("665dd88b792e4256a27a68ee1e10ece6", "System", objOItem_Class_Root.GUID, objTypes.ClassType)
        objOItem_Class_Logstate = New clsOntologyItem("1d9568afb6da49908f4d907dfdd30749", "Logstate", objOItem_Class_System.GUID, objTypes.ClassType)
        objOItem_Class_Directions = New clsOntologyItem("12de02469d84416faa45980efcb9db9b", "Directions", objOItem_Class_System.GUID, objTypes.ClassType)
        objOItem_Class_Ontologies = New clsOntologyItem("eb411e2ff93d4a5ebbbac0b5d7ec0197", "Ontologies", objOItem_Class_System.GUID, objTypes.ClassType)
        objOItem_Class_OntologyItems = New clsOntologyItem("d3f72a683f6146a48ff381db05997dc8", "Ontology-Items", objOItem_Class_Ontologies.GUID, objTypes.ClassType)
        objOItem_Class_OntologyRelationRule = New clsOntologyItem("925f489dec8d4130a418fcb022a4c731", "Ontology-Relation-Rule", objOItem_Class_Ontologies.GUID, objTypes.ClassType)
        objOItem_Class_OntologyJoin = New clsOntologyItem("aab30dd04faf4386896016218132b110", "Ontology-Join", objOItem_Class_Ontologies.GUID, objTypes.ClassType)
        objOItem_Class_Server = New clsOntologyItem("d7a03a35875142b48e0519fc7a77ee91", "Server", objOItem_Class_System.GUID, objTypes.ClassType)


    End Sub
End Class
