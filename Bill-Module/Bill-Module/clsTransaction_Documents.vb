Imports Ontolog_Module
Public Class clsTransaction_Documents
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_Document As clsDBLevel

    Private objOItem_Document As clsOntologyItem
    Private objOItem_FinancialTransaction As clsOntologyItem
    Private objOItem_Belegsart As clsOntologyItem
    Private objOItem_Container As clsOntologyItem

    Public Function save_001_Document(ByVal OItem_Document As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_Document As New List(Of clsOntologyItem)

        objOItem_Document = OItem_Document

        objOL_Document.Add(objOItem_Document)

        objOItem_Result = objDBLevel_Document.save_Objects(objOL_Document)

        Return objOItem_Result
    End Function

    Public Function del_001_Document(Optional ByVal OItem_Document As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_Document As New List(Of clsOntologyItem)

        If Not OItem_Document Is Nothing Then
            objOItem_Document = OItem_Document
        End If

        objOL_Document.Add(objOItem_Document)

        objOItem_Result = objDBLevel_Document.del_Objects(objOL_Document)

        Return objOItem_Result
    End Function

    Public Function save_002_FinancialTransaction_To_Document(ByVal OItem_FinancialTransaction As clsOntologyItem, Optional ByVal OItem_Document As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_FinancialTransaction_To_Document As New List(Of clsObjectRel)

        objOItem_FinancialTransaction = OItem_FinancialTransaction

        If Not OItem_Document Is Nothing Then
            objOItem_Document = OItem_Document
        End If

        objOL_FinancialTransaction_To_Document.Add(New clsObjectRel(objOItem_FinancialTransaction.GUID, _
                                                                    objOItem_FinancialTransaction.GUID_Parent, _
                                                                    objOItem_Document.GUID, _
                                                                    objOItem_Document.GUID_Parent, _
                                                                    objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                                    objLocalConfig.Globals.Type_Object, _
                                                                    Nothing, _
                                                                    1))

        objOItem_Result = objDBLevel_Document.save_ObjRel(objOL_FinancialTransaction_To_Document)



        Return objOItem_Result
    End Function

    Public Function del_002_FinancialTransaction_To_Document(Optional ByVal OItem_Document As clsOntologyItem = Nothing, Optional ByVal OItem_FinancialTransaction As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_FinancialTransaction_To_Document As New List(Of clsObjectRel)

        If Not OItem_Document Is Nothing Then
            objOItem_Document = OItem_Document
        End If

        If Not OItem_FinancialTransaction Is Nothing Then
            objOItem_FinancialTransaction = OItem_FinancialTransaction
        End If

        objOL_FinancialTransaction_To_Document.Add(New clsObjectRel(objOItem_FinancialTransaction.GUID, _
                                                                    Nothing, _
                                                                    objOItem_Document.GUID, _
                                                                    Nothing, _
                                                                    objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                                    objLocalConfig.Globals.Type_Object, _
                                                                    Nothing, _
                                                                    Nothing))

        objOItem_Result = objDBLevel_Document.del_ObjectRel(objOL_FinancialTransaction_To_Document)


        Return objOItem_Result
    End Function

    Public Function save_003_Document_To_Belegsart(ByVal OItem_Belegsart As clsOntologyItem, Optional ByVal OItem_Document As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem

        Dim objOL_Document_To_Belegsart As New List(Of clsObjectRel)
        Dim objOL_Document_To_Belegsart_Search As New List(Of clsObjectRel)
        Dim objOL_Document_To_Belegsart_Del As New List(Of clsObjectRel)

        objOItem_Belegsart = OItem_Belegsart

        If Not OItem_Document Is Nothing Then
            objOItem_Document = OItem_Document
        End If

        objOL_Document_To_Belegsart_Search.Add(New clsObjectRel(objOItem_Document.GUID, _
                                                                Nothing, _
                                                                Nothing, _
                                                                objLocalConfig.OItem_Class_Belegsart.GUID, _
                                                                objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                                                objLocalConfig.Globals.Type_Object, _
                                                                Nothing, _
                                                                Nothing))

        objOItem_Result = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Search = objDBLevel_Document.get_Data_ObjectRel(objOL_Document_To_Belegsart_Search)

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Document.OList_ObjectRel_ID
                          Where obj.ID_Other <> objOItem_Belegsart.GUID

            Dim objExist = From obj In objDBLevel_Document.OList_ObjectRel_ID
                           Where obj.ID_Other = objOItem_Belegsart.GUID

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOL_Document_To_Belegsart_Del.Add(New clsObjectRel(objDel.ID_Object, _
                                                                         Nothing, _
                                                                         objDel.ID_Other, _
                                                                         Nothing, _
                                                                         objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                                                         objLocalConfig.Globals.Type_Object, _
                                                                         Nothing, _
                                                                         Nothing))

                Next

                objOItem_Result_Del = objDBLevel_Document.del_ObjectRel(objOL_Document_To_Belegsart_Del)
                If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    objOItem_Result = objLocalConfig.Globals.LState_Error
                End If

                If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objExist.Count > 0 Then
                        objOItem_Result = objLocalConfig.Globals.LState_Success
                    End If
                End If
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOL_Document_To_Belegsart.Add(New clsObjectRel(objOItem_Document.GUID, _
                                                             objOItem_Document.GUID_Parent, _
                                                             objOItem_Belegsart.GUID, _
                                                             objOItem_Belegsart.GUID_Parent, _
                                                             objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                                             objLocalConfig.Globals.Type_Object, _
                                                             Nothing, _
                                                             1))

            objOItem_Result = objDBLevel_Document.save_ObjRel(objOL_Document_To_Belegsart)
        End If

        Return objOItem_Result
    End Function

    Public Function del_003_Document_To_Belegsart(Optional ByVal OItem_Document As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_Document_To_Belegsart As New List(Of clsObjectRel)

        If Not OItem_Document Is Nothing Then
            objOItem_Document = OItem_Document
        End If

        objOL_Document_To_Belegsart.Add(New clsObjectRel(objOItem_Document.GUID, _
                                                         Nothing, _
                                                         Nothing, _
                                                         objLocalConfig.OItem_Class_Belegsart.GUID, _
                                                         objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                                         objLocalConfig.Globals.Type_Object, _
                                                         Nothing, _
                                                         Nothing))

        objOItem_Result = objDBLevel_Document.del_ObjectRel(objOL_Document_To_Belegsart)

        Return objOItem_Result
    End Function

    Public Function save_004_Document_To_Container(ByVal OItem_Container As clsOntologyItem, Optional ByVal OItem_Document As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem

        Dim objOL_Document_To_Container As New List(Of clsObjectRel)
        Dim objOL_Document_To_Container_Search As New List(Of clsObjectRel)
        Dim objOL_Document_To_Container_Del As New List(Of clsObjectRel)

        objOItem_Container = OItem_Container

        If Not OItem_Document Is Nothing Then
            objOItem_Document = OItem_Document
        End If

        objOL_Document_To_Container_Search.Add(New clsObjectRel(objOItem_Document.GUID, _
                                                                Nothing, _
                                                                Nothing, _
                                                                objLocalConfig.OItem_Class_Container__physical_.GUID, _
                                                                objLocalConfig.OItem_RelationType_located_in.GUID, _
                                                                objLocalConfig.Globals.Type_Object, _
                                                                Nothing, _
                                                                Nothing))

        objOItem_Result = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Search = objDBLevel_Document.get_Data_ObjectRel(objOL_Document_To_Container_Search)

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Document.OList_ObjectRel_ID
                          Where obj.ID_Other <> objOItem_Container.GUID

            Dim objExist = From obj In objDBLevel_Document.OList_ObjectRel_ID
                           Where obj.ID_Other = objOItem_Container.GUID

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOL_Document_To_Container_Del.Add(New clsObjectRel(objDel.ID_Object, _
                                                                         Nothing, _
                                                                         objDel.ID_Other, _
                                                                         Nothing, _
                                                                         objLocalConfig.OItem_RelationType_located_in.GUID, _
                                                                         objLocalConfig.Globals.Type_Object, _
                                                                         Nothing, _
                                                                         Nothing))

                Next

                objOItem_Result_Del = objDBLevel_Document.del_ObjectRel(objOL_Document_To_Container_Del)
                If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    objOItem_Result = objLocalConfig.Globals.LState_Error
                End If

                If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objExist.Count > 0 Then
                        objOItem_Result = objLocalConfig.Globals.LState_Success
                    End If
                End If
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOL_Document_To_Container.Add(New clsObjectRel(objOItem_Document.GUID, _
                                                             objOItem_Document.GUID_Parent, _
                                                             objOItem_Container.GUID, _
                                                             objOItem_Container.GUID_Parent, _
                                                             objLocalConfig.OItem_RelationType_located_in.GUID, _
                                                             objLocalConfig.Globals.Type_Object, _
                                                             Nothing, _
                                                             1))

            objOItem_Result = objDBLevel_Document.save_ObjRel(objOL_Document_To_Container)
        End If

        Return objOItem_Result
    End Function

    Public Function del_004_Document_To_Container(Optional ByVal OItem_Document As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_Document_To_Container As New List(Of clsObjectRel)

        If Not OItem_Document Is Nothing Then
            objOItem_Document = OItem_Document
        End If

        objOL_Document_To_Container.Add(New clsObjectRel(objOItem_Document.GUID, _
                                                         Nothing, _
                                                         Nothing, _
                                                         objLocalConfig.OItem_Class_Container__physical_.GUID, _
                                                         objLocalConfig.OItem_RelationType_located_in.GUID, _
                                                         objLocalConfig.Globals.Type_Object, _
                                                         Nothing, _
                                                         Nothing))

        objOItem_Result = objDBLevel_Document.del_ObjectRel(objOL_Document_To_Container)

        Return objOItem_Result
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Document = New clsDBLevel(objLocalConfig.Globals)

    End Sub
End Class
