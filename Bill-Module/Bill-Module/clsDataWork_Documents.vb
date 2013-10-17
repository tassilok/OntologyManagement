Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsDataWork_Documents
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_FinancialTransactions_To_Document As clsDBLevel
    Private objDBLevel_Document_To_Belegsart As clsDBLevel
    Private objDBLevel_Document_To_Container As clsDBLevel
    Private objDBLevel_Belegsart As clsDBLevel

    Private objOItem_Result_Refs As clsOntologyItem

    Private objThread_Refs As Threading.Thread

    Private objOItem_FinancialTransaction As clsOntologyItem

    Private objOLDocuments As New List(Of clsDocument)

    Public ReadOnly Property Documents As List(Of clsDocument)
        Get
            Dim objOItem_Document As New clsOntologyItem
            Dim objOItem_Belegsart As New clsOntologyItem
            Dim objOItem_Container As New clsOntologyItem

            Dim objLDocuments = From Document In objDBLevel_FinancialTransactions_To_Document.OList_ObjectRel
                                Where Document.ID_Object = objOItem_FinancialTransaction.GUID
                                Group Join Belegsart In objDBLevel_Document_To_Belegsart.OList_ObjectRel On Document.ID_Other Equals Belegsart.ID_Object Into Belegsarten = Group
                                From Belegsart In Belegsarten.DefaultIfEmpty
                                Group Join Container In objDBLevel_Document_To_Container.OList_ObjectRel On Document.ID_Other Equals Container.ID_Object Into Containers = Group
                                From Container In Containers.DefaultIfEmpty

            objOLDocuments.Clear()
            For Each objDocument In objLDocuments
                objOItem_Document.GUID = objDocument.Document.ID_Other
                objOItem_Document.Name = objDocument.Document.Name_Other
                objOItem_Document.GUID_Parent = objDocument.Document.ID_Parent_Other
                objOItem_Document.Type = objLocalConfig.Globals.Type_Object

                If Not objDocument.Belegsart Is Nothing Then
                    objOItem_Belegsart.GUID = objDocument.Belegsart.ID_Other
                    objOItem_Belegsart.Name = objDocument.Belegsart.Name_Other
                    objOItem_Belegsart.GUID_Parent = objDocument.Belegsart.ID_Parent_Other
                    objOItem_Belegsart.Type = objLocalConfig.Globals.Type_Object
                Else
                    objOItem_Belegsart = Nothing
                End If
                
                If Not objDocument.Container Is Nothing Then
                    objOItem_Container.GUID = objDocument.Container.ID_Other
                    objOItem_Container.Name = objDocument.Container.Name_Other
                    objOItem_Container.GUID_Parent = objDocument.Container.ID_Parent_Other
                    objOItem_Container.Type = objLocalConfig.Globals.Type_Object
                Else
                    objOItem_Container = Nothing
                End If

                objOLDocuments.Add(New clsDocument(objOItem_Document, _
                                                   objOItem_Belegsart, _
                                                   objOItem_Container))

            Next

            Return objOLDocuments
        End Get
    End Property

    Public ReadOnly Property DocumentsOnly As List(Of clsObjectRel)
        Get
            Return objDBLevel_FinancialTransactions_To_Document.OList_ObjectRel
        End Get
    End Property
    
    Public ReadOnly Property OItem_Result_Refs As clsOntologyItem
        Get
            Return objOItem_Result_Refs
        End Get
    End Property

    Public Function get_Data_Belegsarten_Combo() As List(Of clsOntologyItem)

        Dim objOL_Belegsart As New List(Of clsOntologyItem)
        Dim objOItem_Result As clsOntologyItem

        objOL_Belegsart.Add(New clsOntologyItem(Nothing, _
                                                Nothing, _
                                                objLocalConfig.OItem_Class_Belegsart.GUID, _
                                                objLocalConfig.Globals.Type_Object))


        objOItem_Result = objDBLevel_Belegsart.get_Data_Objects(objOL_Belegsart)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objDBLevel_Belegsart.OList_Objects.Sort(Function(LS1 As clsOntologyItem, LS2 As clsOntologyItem) LS1.Name.CompareTo(LS2.Name))
            Return objDBLevel_Belegsart.OList_Objects
        Else
            Return Nothing
        End If
    End Function

    Public Sub get_Data(ByVal OItem_FinancialTransaction As clsOntologyItem)

        objOItem_FinancialTransaction = OItem_FinancialTransaction

        objOItem_Result_Refs = objLocalConfig.Globals.LState_Nothing

        Try
            objThread_Refs.Abort()
        Catch ex As Exception

        End Try

        objThread_Refs = New Threading.Thread(AddressOf get_Data_Refs)
        objThread_Refs.Start()


    End Sub

    Public Function get_Data_Document(ByVal OItem_FinancialTransaction As clsOntologyItem) As clsOntologyItem
        Dim objOLFinancialTransaction As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem

        objOLFinancialTransaction.Add(New clsObjectRel(OItem_FinancialTransaction.GUID, _
                                                       Nothing, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Class_Beleg.GUID, _
                                                       objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                       objLocalConfig.Globals.Type_Object, _
                                                       Nothing, _
                                                       Nothing))

        objOItem_Result = objDBLevel_FinancialTransactions_To_Document.get_Data_ObjectRel(objOLFinancialTransaction, _
                                                                  boolIDs:=False)

        Return objOItem_Result
    End Function

    Private Sub get_Data_Refs()
        Dim objOLFinancialTransaction As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem

        objOItem_Result = get_Data_Document(objOItem_FinancialTransaction)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOLFinancialTransaction.Clear()
            objOLFinancialTransaction.Add(New clsObjectRel(Nothing, _
                                                           objLocalConfig.OItem_Class_Beleg.GUID, _
                                                           Nothing, _
                                                           objLocalConfig.OItem_Class_Belegsart.GUID, _
                                                           objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                                           objLocalConfig.Globals.Type_Object, _
                                                           Nothing, _
                                                           Nothing))

            objOItem_Result = objDBLevel_Document_To_Belegsart.get_Data_ObjectRel(objOLFinancialTransaction, _
                                                                                       boolIDs:=False)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objOLFinancialTransaction.Clear()
                objOLFinancialTransaction.Add(New clsObjectRel(Nothing, _
                                                               objLocalConfig.OItem_Class_Beleg.GUID, _
                                                               Nothing, _
                                                               objLocalConfig.OItem_Class_Container__physical_.GUID, _
                                                               objLocalConfig.OItem_RelationType_located_in.GUID, _
                                                               objLocalConfig.Globals.Type_Object, _
                                                               Nothing, _
                                                               Nothing))

                objOItem_Result = objDBLevel_Document_To_Container.get_Data_ObjectRel(objOLFinancialTransaction, _
                                                                                           boolIDs:=False)

            End If

        End If

        objOItem_Result_Refs = objOItem_Result
    End Sub

    Public Function Rel_FinancialTransaction_To_Document(OItem_FinancialTransaction As clsOntologyItem, OItem_Document As clsOntologyItem) As clsObjectRel
        Dim objOR_FinancialTransaction_To_Document = New clsObjectRel With {.ID_Object = OItem_FinancialTransaction.GUID, _
                                                                            .ID_Parent_Object = OItem_FinancialTransaction.GUID_Parent, _
                                                                            .ID_Other = OItem_Document.GUID, _
                                                                            .ID_Parent_Other = OItem_Document.GUID_Parent, _
                                                                            .OrderID = 1, _
                                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                                            .Ontology = objLocalConfig.Globals.Type_Object}

        Return objOR_FinancialTransaction_To_Document
    End Function

    Public Function Rel_Document_To_Container(OItem_Document As clsOntologyItem, OItem_Container As clsOntologyItem) As clsObjectRel
        Dim objOR_Document_To_Container = New clsObjectRel With {.ID_Object = OItem_Document.GUID, _
                                                                            .ID_Parent_Object = OItem_Document.GUID_Parent, _
                                                                            .ID_Other = OItem_Container.GUID, _
                                                                            .ID_Parent_Other = OItem_Container.GUID_Parent, _
                                                                            .OrderID = 1, _
                                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_located_in.GUID, _
                                                                            .Ontology = objLocalConfig.Globals.Type_Object}

        Return objOR_Document_To_Container
    End Function

    Public Function Rel_Document_To_Belegsart(OItem_Document As clsOntologyItem, OItem_Belegsart As clsOntologyItem) As clsObjectRel
        Dim objOR_Document_To_Belegsart = New clsObjectRel With {.ID_Object = OItem_Document.GUID, _
                                                                            .ID_Parent_Object = OItem_Document.GUID_Parent, _
                                                                            .ID_Other = OItem_Belegsart.GUID, _
                                                                            .ID_Parent_Other = OItem_Belegsart.GUID_Parent, _
                                                                            .OrderID = 1, _
                                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                                                            .Ontology = objLocalConfig.Globals.Type_Object}

        Return objOR_Document_To_Belegsart
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Document_To_Belegsart = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Document_To_Container = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_FinancialTransactions_To_Document = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Belegsart = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
