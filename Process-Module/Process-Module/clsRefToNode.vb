Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsRefToNode
    Private objOItem_RefType As clsOntologyItem
    Private objOItem_RelType_Ref As clsOntologyItem
    Private objTreeNode As TreeNode
    Private intImageID As Integer

    Public Property OItem_RefType As clsOntologyItem
        Get
            Return objOItem_RefType
        End Get
        Set(value As clsOntologyItem)
            objOItem_RefType = value
        End Set
    End Property

    Public Property OItem_Rel_RefType As clsOntologyItem
        Get
            Return objOItem_RelType_Ref
        End Get
        Set(value As clsOntologyItem)
            objOItem_RelType_Ref = value
        End Set
    End Property

    Public Property TreeNode_RefType As TreeNode
        Get
            Return objTreeNode
        End Get
        Set(value As TreeNode)
            objTreeNode = value
        End Set
    End Property

    Public Property ImageID As Integer
        Get
            Return intImageID
        End Get
        Set(value As Integer)
            intImageID = value
        End Set
    End Property

    Public Sub New(OItem_RefType As clsOntologyItem, _
                   OItem_RelType_Ref As clsOntologyItem, _
                   TreeNode_RefType As TreeNode, _
                   ImageID As Integer)
        objOItem_RefType = OItem_RefType
        objOItem_RelType_Ref = OItem_RelType_Ref
        objTreeNode = TreeNode_RefType
        intImageID = ImageID
    End Sub


End Class
