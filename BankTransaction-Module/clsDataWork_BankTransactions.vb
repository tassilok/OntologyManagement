Imports Ontolog_Module
Imports Filesystem_Module
Public Class clsDataWork_BankTransactions

    Private objDBLevel_ImportSettings_Att_ColHeader As clsDBLevel
    Private objDBLevel_ImportSettings_Att_Start As clsDBLevel
    Private objDBLevel_ImportSettings_Rel_Files As clsDBLevel
    Private objDBLevel_ImportSettings_Rel_TextQualifier As clsDBLevel
    Private objDBLevel_ImportSettings_Rel_TextSeperator As clsDBLevel
    Private objDBLevel_ImportSettings_Rel_ImportLog As clsDBLevel
    Private objDBLevel_ImportSettings_Rel_IS_To_BankClass As clsDBLevel
    Private objDBLevel_ImportSettings_Rel_Bank As clsDBLevel
    Private objDBLevel_ImportSettings_Rel_Partner As clsDBLevel

    Private objFileWork As clsFileWork

    Private objOItem_Partner As clsOntologyItem

    Private objOItem_ImportSetting As clsOntologyItem

    Private objLocalConfig As clsLocalConfig

    Public ReadOnly Property FirstColHeader As Boolean
        Get
            Dim boolFirstColHeader As Boolean


            Dim objLHeader = From obj In objDBLevel_ImportSettings_Att_ColHeader.OList_ObjectAtt
                             Where obj.ID_Object = objOItem_ImportSetting.GUID
                             Where obj.ID_AttributeType = objLocalConfig.OItem_Attribute_First_Line_Col_Header.GUID
                             Select obj.Val_Bit

            If objLHeader.Count > 0 Then
                boolFirstColHeader = objLHeader(0)
            Else
                boolFirstColHeader = False
            End If

            Return boolFirstColHeader
        End Get
    End Property

    Public ReadOnly Property LastImport As Date
        Get
            Dim dateLastImport As Date

        
            Dim objLLastImport = From objImport In objDBLevel_ImportSettings_Rel_ImportLog.OList_ObjectRel
                                 Where objImport.ID_Other = objOItem_ImportSetting.GUID
                                 Where objImport.ID_Parent_Object = objLocalConfig.OItem_Type_Imports.GUID
                                 Join objStart In objDBLevel_ImportSettings_Att_ColHeader.OList_ObjectAtt On objImport.ID_Object Equals objStart.ID_Object
                                 Where objStart.ID_AttributeType = objLocalConfig.OItem_Attribute_Start.GUID
                                 Order By objStart.Val_Date Descending



            If objLLastImport.Count > 0 Then
                dateLastImport = objLLastImport(0).objStart.Val_Date
            Else
                dateLastImport = Nothing
            End If

            Return dateLastImport
        End Get
    End Property

    Public ReadOnly Property OItem_File As clsOntologyItem
        Get
            Dim objOItem_File As New clsOntologyItem



            Dim objLFile = From obj In objDBLevel_ImportSettings_Rel_Files.OList_ObjectRel Where obj.ID_Object = objOItem_ImportSetting.GUID
                           Where obj.ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID
                           Order By obj.OrderID
                           Select ID_Other = obj.ID_Other, Name_Other = obj.Name_Other, ID_Parent_Other = obj.ID_Parent_Other

            If objLFile.Count > 0 Then
                objOItem_File.GUID = objLFile(0).ID_Other
                objOItem_File.Name = objLFile(0).Name_Other
                objOItem_File.GUID_Parent = objLFile(0).ID_Parent_Other
                objOItem_File.Type = objLocalConfig.Globals.Type_Object

                objOItem_File.Additional1 = objFileWork.get_Path_FileSystemObject(objOItem_File, False)

            Else
                objOItem_File = Nothing
            End If

            Return objOItem_File
        End Get
    End Property

    Public ReadOnly Property OItem_TextQualifier As clsOntologyItem
        Get
            Dim objOItem_TextQualifier As clsOntologyItem

            Dim objLQualifier = From obj In objDBLevel_ImportSettings_Rel_TextQualifier.OList_ObjectRel
                                Where obj.ID_Object = objOItem_ImportSetting.GUID
                                Select ID_Other = obj.ID_Other, Name_Other = obj.Name_Other, ID_Parent_Other = obj.ID_Parent_Other

            If objLQualifier.Count > 0 Then
                objOItem_TextQualifier = New clsOntologyItem(objLQualifier(0).ID_Other, _
                                                             objLQualifier(0).Name_Other, _
                                                             objLQualifier(0).ID_Parent_Other, _
                                                             objLocalConfig.Globals.Type_Object)


            Else
                objOItem_TextQualifier = Nothing
            End If

            Return objOItem_TextQualifier
        End Get
    End Property

    Public ReadOnly Property OItem_TextSeperator As clsOntologyItem
        Get
            Dim objOItem_TextSeperator As clsOntologyItem

            Dim objLSeperator = From obj In objDBLevel_ImportSettings_Rel_TextSeperator.OList_ObjectRel
                                Where obj.ID_Object = objOItem_ImportSetting.GUID
                                Select ID_Other = obj.ID_Other, Name_Other = obj.Name_Other, ID_Parent_Other = obj.ID_Parent_Other

            If objLSeperator.Count > 0 Then
                objOItem_TextSeperator = New clsOntologyItem(objLSeperator(0).ID_Other, _
                                                             objLSeperator(0).Name_Other, _
                                                             objLSeperator(0).ID_Parent_Other, _
                                                             objLocalConfig.Globals.Type_Object)


            Else
                objOItem_TextSeperator = Nothing
            End If

            Return objOItem_TextSeperator
        End Get
    End Property

    Public Function get_ImportSettings() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_ImportSettings_Rel As New List(Of clsObjectRel)
        Dim objOL_ImportSettings_Att As New List(Of clsObjectAtt)

        objOL_ImportSettings_Att.Add(New clsObjectAtt(Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                      objLocalConfig.OItem_Attribute_First_Line_Col_Header.GUID, _
                                                      Nothing))

        objOL_ImportSettings_Att.Add(New clsObjectAtt(Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Type_Imports.GUID, _
                                                      objLocalConfig.OItem_Attribute_Start.GUID, _
                                                      Nothing))


        objOItem_Result = objDBLevel_ImportSettings_Att_ColHeader.get_Data_ObjectAtt(objOL_ImportSettings_Att, _
                                                                           boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOL_ImportSettings_Rel.Add(New clsObjectRel(Nothing, _
                                                          objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Type_File.GUID, _
                                                          objLocalConfig.OItem_RelationType_imports_from.GUID, _
                                                          objLocalConfig.Globals.Type_Object, _
                                                          Nothing, _
                                                          Nothing))
            objOItem_Result = objDBLevel_ImportSettings_Rel_Files.get_Data_ObjectRel(objOL_ImportSettings_Rel, _
                                                                                     boolIDs:=False)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objOL_ImportSettings_Rel.Clear()
                objOL_ImportSettings_Rel.Add(New clsObjectRel(Nothing, _
                                                              objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                              Nothing, _
                                                              objLocalConfig.OItem_Type_Text_Qualifier.GUID, _
                                                              objLocalConfig.OItem_RelationType_works_with.GUID, _
                                                              objLocalConfig.Globals.Type_Object, _
                                                              Nothing, _
                                                              Nothing))

                objOItem_Result = objDBLevel_ImportSettings_Rel_TextQualifier.get_Data_ObjectRel(objOL_ImportSettings_Rel, _
                                                                                             boolIDs:=False)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOL_ImportSettings_Rel.Clear()

                    objOL_ImportSettings_Rel.Add(New clsObjectRel(Nothing, _
                                                          objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Type_Text_Seperators.GUID, _
                                                          objLocalConfig.OItem_RelationType_works_with.GUID, _
                                                          objLocalConfig.Globals.Type_Object, _
                                                          Nothing, _
                                                          Nothing))

                    objOItem_Result = objDBLevel_ImportSettings_Rel_TextSeperator.get_Data_ObjectRel(objOL_ImportSettings_Rel, _
                                                                                                     boolIDs:=False)

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objOL_ImportSettings_Rel.Clear()

                        objOL_ImportSettings_Rel.Add(New clsObjectRel(Nothing, _
                                                          objLocalConfig.OItem_Type_Imports.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                          objLocalConfig.OItem_RelationType_Log_of.GUID, _
                                                          objLocalConfig.Globals.Type_Object, _
                                                          Nothing, _
                                                          Nothing))

                        objOItem_Result = objDBLevel_ImportSettings_Rel_ImportLog.get_Data_ObjectRel(objOL_ImportSettings_Rel, _
                                                                                                     boolIDs:=False)

                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objOL_ImportSettings_Rel.Clear()

                            objOL_ImportSettings_Rel.Add(New clsObjectRel(Nothing, _
                                                          objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                          Nothing, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_RelationType_belonging_Banks.GUID, _
                                                          objLocalConfig.Globals.Type_Class, _
                                                          Nothing, _
                                                          Nothing))

                            objOItem_Result = objDBLevel_ImportSettings_Rel_IS_To_BankClass.get_Data_ObjectRel(objOL_ImportSettings_Rel, _
                                                                                                         boolIDs:=False)

                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objOL_ImportSettings_Rel.Clear()

                                objOL_ImportSettings_Rel.Add(New clsObjectRel(Nothing, _
                                                          objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Type_Bankleitzahl.GUID, _
                                                          objLocalConfig.OItem_RelationType_belonging.GUID, _
                                                          objLocalConfig.Globals.Type_Object, _
                                                          Nothing, _
                                                          Nothing))

                                objOItem_Result = objDBLevel_ImportSettings_Rel_Bank.get_Data_ObjectRel(objOL_ImportSettings_Rel, _
                                                                                                         boolIDs:=False)

                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objOL_ImportSettings_Rel.Clear()

                                    objOL_ImportSettings_Rel.Add(New clsObjectRel(Nothing, _
                                                      objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                      objOItem_Partner.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_RelationType_zugeh_rige_Mandanten.GUID, _
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing))

                                    objOItem_Result = objDBLevel_ImportSettings_Rel_Partner.get_Data_ObjectRel(objOL_ImportSettings_Rel, _
                                                                           boolIDs:=False)

                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                                        If objDBLevel_ImportSettings_Rel_Partner.OList_ObjectRel.Count > 0 Then
                                            objOItem_ImportSetting = New clsOntologyItem(objDBLevel_ImportSettings_Rel_Partner.OList_ObjectRel(0).ID_Object, _
                                                                                         objDBLevel_ImportSettings_Rel_Partner.OList_ObjectRel(0).Name_Object, _
                                                                                        objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                                                        objLocalConfig.Globals.Type_Object)
                                        Else
                                            objOItem_Result = objLocalConfig.Globals.LState_Error
                                        End If
                                        
                                        
                                    End If

                                End If
                            End If
                        End If
                    End If
                End If
            End If

        End If


        Return objOItem_Result
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig, ByVal OItem_Partner As clsOntologyItem)
        objLocalConfig = LocalConfig

        objOItem_Partner = OItem_Partner

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_ImportSettings_Att_ColHeader = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ImportSettings_Att_Start = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ImportSettings_Rel_Files = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ImportSettings_Rel_TextQualifier = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ImportSettings_Rel_TextSeperator = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ImportSettings_Rel_ImportLog = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ImportSettings_Rel_IS_To_BankClass = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ImportSettings_Rel_Partner = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ImportSettings_Rel_Bank = New clsDBLevel(objLocalConfig.Globals)

        objFileWork = New clsFileWork(objLocalConfig.Globals)
    End Sub
End Class




