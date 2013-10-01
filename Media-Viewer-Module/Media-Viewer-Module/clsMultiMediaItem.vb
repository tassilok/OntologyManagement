Imports Ontolog_Module
Imports OntologyClasses.BaseClasses

Public Class clsMultiMediaItem
    Private strID_Item As String
    Private strName_Item As String
    Private strID_Parent_Item As String

    Private strID_File As String
    Private strName_File As String
    Private strID_Parent_File As String

    Private objOACreate As clsObjectAtt

    Private intOrderID As Nullable(Of Long)

    Private intCountBookmark As Nullable(Of Long)

    Public Property CountBookMark As Integer
        Get
            Return intCountBookmark
        End Get
        Set(value As Integer)
            intCountBookmark = value
        End Set
    End Property

    Public Property OACreate As clsObjectAtt
        Get
            Return objOACreate
        End Get
        Set(value As clsObjectAtt)
            objOACreate = value
        End Set
    End Property

    Public Property OrderID As Integer
        Get
            Return intOrderID
        End Get
        Set(value As Integer)
            intOrderID = value
        End Set
    End Property

    Public Property ID_Item As String
        Get
            Return strID_Item
        End Get
        Set(value As String)
            strID_Item = value
        End Set
    End Property

    Public Property Name_Item As String
        Get
            Return strName_Item
        End Get
        Set(value As String)
            strName_Item = value
        End Set
    End Property

    Public Property ID_Parent_Item As String
        Get
            Return strID_Parent_Item
        End Get
        Set(value As String)
            strID_Parent_Item = value
        End Set
    End Property

    Public Property ID_File As String
        Get
            Return strID_File
        End Get
        Set(value As String)
            strID_File = value
        End Set
    End Property

    Public Property Name_File As String
        Get
            Return strName_File
        End Get
        Set(value As String)
            strName_File = value
        End Set
    End Property

    Public Property ID_Parent_File As String
        Get
            Return strID_Parent_File
        End Get
        Set(value As String)
            strID_Parent_File = value
        End Set
    End Property


    Public Sub New(strID_Item As String, _
                   strName_Item As String, _
                   strID_Parent_Item As String, _
                   strID_File As String, _
                   strName_File As String, _
                   strID_Parent_File As String, _
                   objOACreated As clsObjectAtt, _
                   intOrderID As Integer)

        Me.strID_Item = strID_Item
        Me.strName_Item = strName_Item
        Me.strID_Parent_Item = strID_Parent_Item

        Me.strID_File = strID_File
        Me.strName_File = strName_File
        Me.strID_Parent_File = strID_Parent_File

        Me.objOACreate = objOACreated

        Me.intOrderID = intOrderID
    End Sub

    Public Sub New(strID_Item As String, _
                   strName_Item As String, _
                   strID_Parent_Item As String, _
                   strID_File As String, _
                   strName_File As String, _
                   strID_Parent_File As String, _
                   objOACreated As clsObjectAtt, _
                   intOrderID As Integer, _
                   intCountBookmark As Integer)

        Me.strID_Item = strID_Item
        Me.strName_Item = strName_Item
        Me.strID_Parent_Item = strID_Parent_Item

        Me.strID_File = strID_File
        Me.strName_File = strName_File
        Me.strID_Parent_File = strID_Parent_File

        Me.objOACreate = objOACreated

        Me.intOrderID = intOrderID
        Me.intCountBookmark = intCountBookmark
    End Sub
End Class
