Imports ElasticSearchNestConnector
Imports OntologyClasses.DataClasses
Imports OntologyClasses.BaseClasses


Public Class clsAppDBLevel
    Private objAppElSelector As clsUserAppDBSelector
    Private objAppElDeletor As clsUserAppDBDeletor
    Private objAppElUpdater As clsUserAppDBUpdater

    Private strServer As String
    Private strIndex As String
    Private intPort As Integer
    Private intSearchRange As Integer
    Private strSession As String
    Private objOItem_User As clsOntologyItem
    Private objOItem_Ontology As clsOntologyItem

    Private objLogStates As New clsLogStates

    Public Property PackageLength As Integer
        Get
            Return intSearchRange
        End Get
        Set(ByVal value As Integer)
            intSearchRange = value
        End Set
    End Property

    Public ReadOnly Property PageCount As Integer
        Get
            Return objAppElSelector.PageCount
        End Get
    End Property

    Public ReadOnly Property CurrPage As Integer
        Get
            Return objAppElSelector.CurPage
        End Get
    End Property

    Public ReadOnly Property LastPos As Integer
        Get
            Return objAppElSelector.LastPos
        End Get
    End Property

    Public ReadOnly Property Total As integer
        Get
            Return objAppElSelector.Total
        End Get
    End Property

    Public Property Paging As Boolean
        get
            Return objAppElSelector.Paging
        End Get
        Set(value As Boolean)
            objAppElSelector.Paging = value
        End Set
    End Property


    Private Sub initialize_Client()
        
        objAppElDeletor = New clsUserAppDBDeletor(objAppElSelector)
        objAppElUpdater = New clsUserAppDBUpdater(objAppElSelector)
    End Sub

    Public Sub New(ByVal Globals As clsGlobals, OItem_Ontology As clsOntologyItem, OItem_User As clsOntologyItem)

        strServer = Globals.Server
        intPort = Globals.Port
        intSearchRange = Globals.SearchRange
        strSession = Globals.Session
        objOItem_User = OItem_User
        objOItem_Ontology = OItem_Ontology

        objAppElSelector = New clsUserAppDBSelector(strServer, intPort, objOItem_Ontology.GUID, objOItem_User.GUID, intSearchRange, strSession)

        objOItem_Ontology = OItem_Ontology
        objOItem_User = OItem_User

        initialize_Client()

    End Sub

    Public Sub New(strServer As String, intPort As Integer, OItem_Ontology As clsOntologyItem, OItem_User As clsOntologyItem, intSearchRange As Integer, strSession As String)

        Me.strServer = strServer
        Me.intPort = intPort
        Me.intSearchRange = intSearchRange
        Me.objOItem_User = OItem_User
        Me.objOItem_Ontology = OItem_Ontology
        Me.strSession = strSession

        objAppElSelector = New clsUserAppDBSelector(strServer, intPort, objOItem_Ontology.GUID, objOItem_User.GUID, intSearchRange, strSession)

        objOItem_Ontology = OItem_Ontology
        objOItem_User = OItem_User

        initialize_Client()
    End Sub

    Public Sub New (strServer As String, intPort As Integer, strIndex As string, intSearchRange As Integer, strSession As String)

        Me.strServer = strServer
        Me.intPort = intPort
        Me.intSearchRange = intSearchRange
        Me.strIndex = strIndex
        Me.strSession = strSession

        objAppElSelector = New clsUserAppDBSelector(strServer, intPort, Me.strIndex, intSearchRange, strSession)

        initialize_Client()
    End Sub

    Public Function Copy_Index(strIndexSrc As String, strIndexDst As String) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem = objLogStates.LogState_Success.Clone()

        Dim objDocuments = objAppElSelector.GetData_Documents(strIndexSrc)

        For Each strType In objAppElSelector.GetData_Types(strIndexSrc)
            objOItem_Result = objAppElUpdater.SaveDoc(objDocuments, strType)
            If objOItem_Result.GUID = objLogStates.LogState_Error.GUID Then
                Exit For
            End If
        Next


        Return objOItem_Result
    End Function

    Public Function Save_Documents(Documents As List(Of clsAppDocuments), Optional strType As String = Nothing, Optional strIndex As String = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        If strIndex <> "" Then
            objAppElSelector.Index = strIndex
        End If

        Do
            Dim objDocumentsPart = Documents.Take(intSearchRange).ToList()
            objOItem_Result = objAppElUpdater.SaveDoc(objDocumentsPart, strType)
            If objOItem_Result.GUID = objLogStates.LogState_Error.GUID Then
                Exit Do
            End If
            Documents.RemoveRange(0, If(Documents.Count >= intSearchRange, intSearchRange - 1, Documents.Count))
        Loop Until Documents.Count = 0

        Return objOItem_Result
    End Function

    Public Function Save_DocType(strType As String) As clsOntologyItem
        Dim objOItem_Result = objAppElUpdater.SaveDocType(strType)

        Return objOItem_Result
    End Function

    Public Function Del_Documents(strType As String, idList As List(Of String)) As clsOntologyItem
        Dim objOItem_Result = objAppElDeletor.DeleteItemsById(strIndex, strType, idList)

        Return objOItem_Result
    End Function

    Public Function GetData_Documents(Optional strIndex As String = Nothing, Optional strType As String = Nothing, Optional paging As Boolean = false, Optional lastPos  As Integer = 0, optional strQuery As String = Nothing) As List(Of clsAppDocuments)
        Dim objDocuments = objAppElSelector.GetData_Documents(strIndex,strType,paging,lastPos,strQuery)

        Return objDocuments
    End Function

End Class
