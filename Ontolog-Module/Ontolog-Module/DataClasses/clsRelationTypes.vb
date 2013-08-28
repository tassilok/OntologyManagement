Public Class clsRelationTypes
    Private objOItem_RelationType_Contains As clsOntologyItem
    Private objOItem_RelationType_belongingAttribute As clsOntologyItem
    Private objOItem_RelationType_belongingRelationType As clsOntologyItem
    Private objOItem_RelationType_belongingClass As clsOntologyItem
    Private objOItem_RelationType_belongingObject As clsOntologyItem
    Private objOItem_RelationType_belonging As clsOntologyItem

    Private objTypes As New clsTypes

    Public ReadOnly Property OItem_RelationType_Contains As clsOntologyItem
        Get
            Return objOItem_RelationType_Contains
        End Get
    End Property
    Public ReadOnly Property OItem_RelationType_belongingAttribute As clsOntologyItem
        Get
            Return objOItem_RelationType_belongingAttribute
        End Get
    End Property
    Public ReadOnly Property OItem_RelationType_belongingRelationType As clsOntologyItem
        Get
            Return objOItem_RelationType_belongingRelationType
        End Get
    End Property
    Public ReadOnly Property OItem_RelationType_belongingClass As clsOntologyItem
        Get
            Return objOItem_RelationType_belongingClass
        End Get
    End Property
    Public ReadOnly Property OItem_RelationType_belongingObject As clsOntologyItem
        Get
            Return objOItem_RelationType_belongingObject
        End Get
    End Property
    Public ReadOnly Property OItem_RelationType_belonging As clsOntologyItem
        Get
            Return objOItem_RelationType_belonging

        End Get
    End Property


    Public Sub New()
        objOItem_RelationType_Contains = New clsOntologyItem("e971160347db44d8a476fe88290639a4", "contains", objTypes.RelationType)
        objOItem_RelationType_belongingAttribute = New clsOntologyItem("81bbd380e35648a1a4b7fdbaebe7273c", "belonging Attribute", objTypes.RelationType)
        objOItem_RelationType_belongingClass = New clsOntologyItem("f2b54f82ada5460eafe5551d55629f14", "belonging Class", objTypes.RelationType)
        objOItem_RelationType_belongingRelationType = New clsOntologyItem("4417582dbd6347fbab18770a611917fe", "belonging RelationType", objTypes.RelationType)
        objOItem_RelationType_belongingObject = New clsOntologyItem("f68a9438fb8b418d8e0bd9aefc9ecdf3", "belonging Object", objTypes.RelationType)
        objOItem_RelationType_belonging = New clsOntologyItem("796712399c8f493cb5e749700f9543f4", "belonging", objTypes.RelationType)
    End Sub
End Class
