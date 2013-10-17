Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsDocument
    Private objOItem_Document As clsOntologyItem
    Private objOItem_Belegsart As clsOntologyItem
    Private objOItem_Container As clsOntologyItem

    Public Property Document As clsOntologyItem
        Get
            Return objOItem_Document
        End Get
        Set(ByVal value As clsOntologyItem)
            objOItem_Document = value
        End Set
    End Property

    Public Property Belegsart As clsOntologyItem
        Get
            Return objOItem_Belegsart
        End Get
        Set(ByVal value As clsOntologyItem)
            objOItem_Belegsart = value
        End Set
    End Property

    Public Property Container As clsOntologyItem
        Get
            Return objOItem_Container
        End Get
        Set(ByVal value As clsOntologyItem)
            objOItem_Container = value
        End Set
    End Property

    Public Sub New(ByVal OItem_Document As clsOntologyItem, ByVal OItem_Belegsart As clsOntologyItem, ByVal OItem_Container As clsOntologyItem)
        objOItem_Document = OItem_Document
        objOItem_Belegsart = OItem_Belegsart
        objOItem_Container = OItem_Container
    End Sub
End Class
