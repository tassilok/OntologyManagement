Imports Ontolog_Module
Imports Filesystem_Module
Imports OntologyClasses.BaseClasses

Public Class clsTransaction_PDF
    Private objLocalConfig As clsLocalConfig

    Private objTransaction As clsTransaction

    Private objFileWork As clsFileWork
    Private objBlobConnection As clsBlobConnection
    Private objDBLevel As clsDBLevel

    Private objOItem_PDF As clsOntologyItem
    Private objOItem_File As clsOntologyItem
    Private objOItem_Ref As clsOntologyItem
    Private strPath_Source As String
    Private boolNewID As Boolean
    Private lngOrderID As Long

    Public Function save_PDF(OItem_PDF As clsOntologyItem, OItem_File As clsOntologyItem, strPath As String, OItem_Ref As clsOntologyItem, Optional NewID As Boolean = True) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_PDF = OItem_PDF
        objOItem_File = OItem_File
        strPath_Source = strPath

        objTransaction.ClearItems()
        objOItem_Result = objTransaction.do_Transaction(objOItem_PDF)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOItem_Result = objFileWork.save_File(objOItem_File)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objOItem_Result = save_Blob(objOItem_File, strPath_Source)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Result = save_PDFToFile(objOItem_PDF, objOItem_File)

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objOItem_Result = save_PDFToRef(objOItem_PDF, OItem_Ref, True, NewID)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                            objFileWork.del_File(objOItem_File)
                        End If
                    Else
                        objFileWork.del_File(objOItem_File)
                    End If
                Else
                    objFileWork.del_File(objOItem_File)
                End If
            End If
        Else

            objTransaction.rollback()
        End If

        Return objOItem_Result
    End Function

    Public Function save_Blob(OItem_File As clsOntologyItem, Path As String, Optional ClearTransactions As Boolean = True)
        Dim objOItem_Result As clsOntologyItem

        If ClearTransactions Then
            objTransaction.ClearItems()
        End If

        objOItem_File = OItem_File
        strPath_Source = Path

        objOItem_Result = objBlobConnection.save_File_To_Blob(objOItem_File, strPath_Source)

        Return objOItem_Result
    End Function

    Public Function save_PDFToFile(OItem_PDF As clsOntologyItem, OItem_File As clsOntologyItem, Optional ClearTransactions As Boolean = True)
        Dim objOItem_Result As clsOntologyItem
        Dim objOR_PDFToFile As clsObjectRel
        objOItem_PDF = OItem_PDF
        objOItem_File = OItem_File

        If ClearTransactions Then
            objTransaction.ClearItems()
        End If

        objOItem_PDF = OItem_PDF
        objOItem_File = OItem_File


        objOR_PDFToFile = New clsObjectRel(objOItem_PDF.GUID, _
                                           objOItem_PDF.GUID_Parent, _
                                           objOItem_File.GUID, _
                                           objOItem_File.GUID_Parent, _
                                           objLocalConfig.OItem_RelationType_belonging_Source.GUID, _
                                           objLocalConfig.Globals.Type_Object, _
                                           Nothing, _
                                           1)

        objOItem_Result = objTransaction.do_Transaction(objOR_PDFToFile, True)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objTransaction.rollback()
        End If

        Return objOItem_Result
    End Function

    Public Function save_PDFToRef(OItem_PDF As clsOntologyItem, OItem_Ref As clsOntologyItem, Optional ClearTransactions As Boolean = True, Optional NewID As Boolean = True)
        Dim objOItem_Result As clsOntologyItem
        Dim objOR_PDFToRef As clsObjectRel

        objOItem_PDF = OItem_PDF
        objOItem_Ref = OItem_Ref
        boolNewID = NewID

        If ClearTransactions Then
            objTransaction.ClearItems()
        End If

        If boolNewID Then
            lngOrderID = objDBLevel.get_Data_Rel_OrderID(objOItem_PDF, objOItem_Ref, objLocalConfig.OItem_RelationType_belongsTo, False)
            lngOrderID = lngOrderID + 1
        Else
            lngOrderID = objOItem_File.Val_Long
        End If



        objOR_PDFToRef = New clsObjectRel(objOItem_PDF.GUID, _
                                          objOItem_PDF.GUID_Parent, _
                                          objOItem_Ref.GUID, _
                                          objOItem_Ref.GUID_Parent, _
                                          objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                          objOItem_Ref.Type, _
                                          Nothing, _
                                          lngOrderID)

        objOItem_Result = objTransaction.do_Transaction(objOR_PDFToRef)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objTransaction.rollback()
        End If

        Return objOItem_Result
    End Function

    Public Function update_PDF(OItem_PDF As clsOntologyItem)
        Dim objOItem_Result As clsOntologyItem

        objOItem_PDF = OItem_PDF

        objTransaction.ClearItems()

        objOItem_Result = objTransaction.do_Transaction(objOItem_PDF)

        Return objOItem_Ref
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        initialize()
    End Sub


    Private Sub initialize()
        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objFileWork = New clsFileWork(objLocalConfig.Globals)
        objBlobConnection = New clsBlobConnection(objLocalConfig.Globals)
        objDBLevel = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
