﻿Imports Ontolog_Module
Public Class clsTransactionItem
    Private objOItem_OntologyItem As clsOntologyItem
    Private objOItem_ObjectAtt As clsObjectAtt
    Private objOItem_ObjectRel As clsObjectRel
    Private objOItem_ClassAtt As clsClassAtt
    Private objOItem_ClassRel As clsClassRel
    Private objOItem_Result As clsOntologyItem
    Private boolRemoved As Boolean
    Private strType As String
    Private boolAll As Boolean

    Private objClassTypes As New clsClassTypes

    Public ReadOnly Property savedType As String
        Get
            Return strType
        End Get
    End Property

    Public Property Removed As Boolean
        Get
            Return boolRemoved
        End Get
        Set(value As Boolean)
            boolRemoved = value
        End Set
    End Property

    Public Property OItem_OntologyItem As clsOntologyItem
        Get
            Return objOItem_OntologyItem
        End Get
        Set(value As clsOntologyItem)
            objOItem_OntologyItem = value
            strType = objClassTypes.ClassType_OntologyItem
        End Set
    End Property

    Public Property OItem_ObjectAtt As clsObjectAtt
        Get
            Return objOItem_ObjectAtt
        End Get
        Set(value As clsObjectAtt)
            objOItem_ObjectAtt = value
            strType = objClassTypes.ClassType_ObjectAtt
        End Set
    End Property

    Public Property OItem_ObjectRel As clsObjectRel
        Get
            Return objOItem_ObjectRel
        End Get
        Set(value As clsObjectRel)
            objOItem_ObjectRel = value
            strType = objClassTypes.ClassType_ObjectRel
        End Set
    End Property

    Public Property OItem_ClassAtt As clsClassAtt
        Get
            Return objOItem_ClassAtt
        End Get
        Set(value As clsClassAtt)
            objOItem_ClassAtt = value
            strType = objClassTypes.ClassType_ClassAtt
        End Set
    End Property

    Public Property OItem_ClassRel As clsClassRel
        Get
            Return objOItem_ClassRel
        End Get
        Set(value As clsClassRel)
            objOItem_ClassRel = value
            strType = objClassTypes.ClassType_ClassRel
        End Set
    End Property

    Public Property All As Boolean
        Get
            Return boolAll
        End Get
        Set(value As Boolean)
            boolAll = value
        End Set
    End Property

    Public Property TransactionResult As clsOntologyItem
        Get
            Return objOItem_Result
        End Get
        Set(value As clsOntologyItem)
            objOItem_Result = value
        End Set
    End Property

    Public Sub New()
        boolAll = False

    End Sub
End Class
