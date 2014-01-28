Imports Structure_Module
Imports System.Threading
Imports OntologyClasses.BaseClasses
Imports Ontology_Module
Imports Filesystem_Module
Public Class frmMetaData_Image

    Private objLocalConfig As clsLocalConfig

    Private objDataWork_Image As clsDataWork_Images

    Private objOList_ImageMeta As New SortableBindingList(Of clsImage)

    Private objBlobConnector As clsBlobConnection

    Private objThread_Metadata As Thread

    Private objTransaction As clsTransaction
    Private objRelationConfig As clsRelationConfig

    Private boolAbort As Boolean

    Private Sub ToolStripButton_Close_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Private Sub ClearControls()
        ToolStripButton_Abort.Enabled = False
        ToolStripButton_Suspend.Enabled = False
        ToolStripButton_Start.Enabled = False
        DataGridView_MetaData.Enabled = False
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        ClearControls()
        objBlobConnector = New clsBlobConnection(objLocalConfig.Globals)
        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)

        objDataWork_Image = New clsDataWork_Images(objLocalConfig)
        objOList_ImageMeta = New SortableBindingList(Of clsImage)(objDataWork_Image.GetData_MetaDataImages())

        DataGridView_MetaData.DataSource = objOList_ImageMeta

        DataGridView_MetaData.Columns(0).Visible = False
        DataGridView_MetaData.Columns(2).Visible = False
        DataGridView_MetaData.Columns(4).Visible = False
        DataGridView_MetaData.Columns(5).Visible = False
        DataGridView_MetaData.Columns(7).Visible = False
        DataGridView_MetaData.Columns(8).Visible = False
        DataGridView_MetaData.Columns(10).Visible = False
        DataGridView_MetaData.Columns(11).Visible = False
        DataGridView_MetaData.Columns(12).Visible = False
        DataGridView_MetaData.Columns(13).Visible = False


        DataGridView_MetaData.Enabled = True
        If DataGridView_MetaData.RowCount > 0 Then
            ToolStripButton_Start.Enabled = True
        End If
    End Sub

    Private Sub SetMetaData()
        Dim strPath = "%TEMP%\"
        strPath = Environment.ExpandEnvironmentVariables(strPath)

        Dim objOList_Years = objDataWork_Image.RelatedDates.Where(Function(p) p.GUID_Parent = objLocalConfig.OItem_Type_Year.GUID).ToList()
        Dim objOList_Months = objDataWork_Image.RelatedDates.Where(Function(p) p.GUID_Parent = objLocalConfig.OItem_Type_Month.GUID).ToList()
        Dim objOList_Days = objDataWork_Image.RelatedDates.Where(Function(p) p.GUID_Parent = objLocalConfig.OItem_Type_Day.GUID).ToList()



        For Each objDGVR As DataGridViewRow In If(DataGridView_MetaData.SelectedRows.Count = 0, DataGridView_MetaData.Rows, DataGridView_MetaData.SelectedRows)
            Dim objImage As clsImage = objDGVR.DataBoundItem
            If boolAbort Then
            Exit For
            End If
            Dim objOItem_File = New clsOntologyItem With {.GUID = objImage.ID_File, _
                                                          .Name = objImage.Name_File, _
                                                          .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                          .Type = objLocalConfig.Globals.Type_Object}
            Dim strPathTmp = strPath
            strPathTmp = strPathTmp & objLocalConfig.Globals.NewGUID & IO.Path.GetExtension(objOItem_File.Name)

            Dim objOItem_Result = objBlobConnector.save_Blob_To_File(objOItem_File, strPathTmp)
            Dim dateCreate As Date
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                Try
                    Dim objImageBmp = New Bitmap(strPathTmp)
                    Dim byteValue() As Byte
                    Dim strValue As String
                    Dim strDates() As String
                    For Each objPropertyItem As Drawing.Imaging.PropertyItem In objImageBmp.PropertyItems
                        If objPropertyItem.Id = 306 Or objPropertyItem.Id = 9003 Or objPropertyItem.Id = 36867 Then
                            byteValue = objPropertyItem.Value
                            strValue = ""
                            For i As Integer = 0 To byteValue.Length - 1
                                strValue = strValue & Chr(byteValue(i))
                            Next
                            strDates = strValue.Split(" ")
                            If strDates.Count = 2 Then
                                strDates(0) = strDates(0).Replace(":", ".")
                                strValue = strDates(0) & " " & strDates(1)
                            End If
                            If Date.TryParse(strValue, dateCreate) = False Then
                                dateCreate = Nothing
                            End If
                            Exit For
                        End If
                    Next

                    If dateCreate = Nothing Then
                        dateCreate = IO.File.GetLastWriteTime(strPathTmp)
                    End If

                    If objImage.Taking <> dateCreate Then
                        Dim objORel_File__Creation = objRelationConfig.Rel_ObjectAttribute(objOItem_File, objLocalConfig.OItem_Attribute_Datetimestamp__Create_, dateCreate)
                        objTransaction.ClearItems()
                        objOItem_Result = objTransaction.do_Transaction(objORel_File__Creation, True)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Dim objOItem_Image = New clsOntologyItem With {.GUID = objImage.ID_Image, _
                                                                           .Name = objImage.Name_Image, _
                                                                           .GUID_Parent = objLocalConfig.OItem_Type_Images__Graphic_.GUID, _
                                                                           .Type = objLocalConfig.Globals.Type_Object}

                            Dim objORel_Image__Taking = objRelationConfig.Rel_ObjectAttribute(objOItem_Image, objLocalConfig.OItem_Attribute_taking, dateCreate)
                            objOItem_Result = objTransaction.do_Transaction(objORel_Image__Taking, True)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                Dim yearCreate = dateCreate.Year
                                Dim dayCreate = dateCreate.Day
                                Dim monthCreate = dateCreate.Month
                                Dim objOList_Year = objOList_Years.Where(Function(p) p.Name = yearCreate.ToString()).ToList
                                Dim objOList_Month = objOList_Months.Where(Function(p) p.Name = monthCreate.ToString()).ToList
                                Dim objOList_Day = objOList_Days.Where(Function(p) p.Name = dayCreate.ToString()).ToList

                                If Not objOList_Year.Any Then
                                    Dim objOItem_Year = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                                                  .Name = yearCreate.ToString, _
                                                                                  .GUID_Parent = objLocalConfig.OItem_Type_Year.GUID, _
                                                                                  .Type = objLocalConfig.Globals.Type_Object}

                                    objOItem_Result = objTransaction.do_Transaction(objOItem_Year)
                                    objOList_Year.Add(objOItem_Year)
                                End If

                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    Dim objORel_Image_To_Year = objRelationConfig.Rel_ObjectRelation(objOItem_Image, objOList_Year.First(), objLocalConfig.OItem_RelationType_taking_at)
                                    objOItem_Result = objTransaction.do_Transaction(objORel_Image_To_Year, True)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        If Not objOList_Month.Any Then
                                            Dim objOItem_Month = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                                                          .Name = monthCreate.ToString, _
                                                                                          .GUID_Parent = objLocalConfig.OItem_Type_Month.GUID, _
                                                                                          .Type = objLocalConfig.Globals.Type_Object}

                                            objOItem_Result = objTransaction.do_Transaction(objOItem_Month)
                                            objOList_Month.Add(objOItem_Month)
                                        End If

                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                            Dim objORel_Image_To_Month = objRelationConfig.Rel_ObjectRelation(objOItem_Image, objOList_Month.First(), objLocalConfig.OItem_RelationType_taking_at)
                                            objOItem_Result = objTransaction.do_Transaction(objORel_Image_To_Month, True)
                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                If Not objOList_Day.Any Then
                                                    Dim objOItem_Day = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                                                                  .Name = dayCreate.ToString, _
                                                                                                  .GUID_Parent = objLocalConfig.OItem_Type_Day.GUID, _
                                                                                                  .Type = objLocalConfig.Globals.Type_Object}

                                                    objOItem_Result = objTransaction.do_Transaction(objOItem_Day)
                                                    objOList_Day.Add(objOItem_Day)
                                                End If

                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                    Dim objORel_Image_To_Day = objRelationConfig.Rel_ObjectRelation(objOItem_Image, objOList_Day.First(), objLocalConfig.OItem_RelationType_taking_at)
                                                    objOItem_Result = objTransaction.do_Transaction(objORel_Image_To_Day, True)
                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                        objImage.Taking = dateCreate
                                                        objImage.ID_Year = objOList_Year.First().GUID
                                                        objImage.Name_Year = objOList_Year.First().Name
                                                        objImage.ID_Month = objOList_Month.First().GUID
                                                        objImage.Name_Month = objOList_Month.First().Name
                                                        objImage.ID_Day = objOList_Day.First().GUID
                                                        objImage.Name_Day = objOList_Day.First().Name
                                                        objImage.MetaChanged = True
                                                        objImage.MetaSuccess = True
                                                        objImage.MetaError = False
                                                    Else
                                                        objTransaction.rollback()
                                                        objImage.MetaSuccess = False
                                                        objImage.MetaError = True
                                                        objImage.MetaChanged = False
                                                    End If
                                                Else
                                                    objTransaction.rollback()
                                                    objImage.MetaSuccess = False
                                                    objImage.MetaError = True
                                                    objImage.MetaChanged = False
                                                End If
                                            Else
                                                objTransaction.rollback()
                                                objImage.MetaSuccess = False
                                                objImage.MetaError = True
                                                objImage.MetaChanged = False
                                            End If
                                        Else
                                            objTransaction.rollback()
                                            objImage.MetaSuccess = False
                                            objImage.MetaError = True
                                            objImage.MetaChanged = False
                                        End If
                                    Else
                                        objTransaction.rollback()
                                        objImage.MetaSuccess = False
                                        objImage.MetaError = True
                                        objImage.MetaChanged = False
                                    End If
                                Else
                                    objTransaction.rollback()
                                    objImage.MetaSuccess = False
                                    objImage.MetaError = True
                                    objImage.MetaChanged = False
                                End If

                            Else
                                objTransaction.rollback()
                                objImage.MetaSuccess = False
                                objImage.MetaError = True
                                objImage.MetaChanged = False
                            End If
                        Else
                            objImage.MetaSuccess = False
                            objImage.MetaError = True
                            objImage.MetaChanged = False
                        End If
                    Else
                        objImage.MetaSuccess = True
                        objImage.MetaError = False
                        objImage.MetaChanged = False
                    End If
                Catch ex As Exception
                    objImage.MetaSuccess = False
                    objImage.MetaError = True
                    objImage.MetaChanged = False
                End Try

            Else
                objImage.MetaSuccess = False
                objImage.MetaError = True
                objImage.MetaChanged = False
            End If

        Next
    End Sub

    Private Sub ToolStripButton_Start_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Start.Click
        objThread_Metadata = New Thread(AddressOf SetMetaData)
        objThread_Metadata.Start()
        Timer_Metadata.Start()

        boolAbort = False

        ToolStripButton_Start.Enabled = False
        ToolStripButton_Suspend.Enabled = True
        ToolStripButton_Abort.Enabled = True

    End Sub

    Private Sub Timer_Metadata_Tick(sender As Object, e As EventArgs) Handles Timer_Metadata.Tick
        If objThread_Metadata.IsAlive Then
            DataGridView_MetaData.Refresh()

        Else
            Timer_Metadata.Stop()
        End If
    End Sub
End Class
