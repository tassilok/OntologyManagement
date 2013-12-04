Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports System.Text.RegularExpressions

Public Class clsDataWork_FileResource_Path
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Attributes As clsDBLevel
    Private objDBLevel_Relations As clsDBLevel

    Private objOItem_Result_Attributes As clsOntologyItem
    Private objOItem_Result_Relations As clsOntologyItem
    Private objOItem_Result_FileResult As clsOntologyItem

    Public Property FileList As List(Of clsFile)

    Public Property objOAItem_Pattern As clsObjectAtt
    Public Property objOAItem_SubItems As clsObjectAtt

    Public Property objORItem_Path As clsObjectRel

    Public ReadOnly Property OItem_Result_FileResult As clsOntologyItem
        Get
            Return objOItem_Result_FileResult
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Attributes As clsOntologyItem
        Get
            Return objOItem_Result_Attributes
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Relations As clsOntologyItem
        Get
            Return objOItem_Result_Relations
        End Get
    End Property

    Public Sub GetData_Attributes(OItem_FileResource As clsOntologyItem)
        objOItem_Result_Attributes = objLocalConfig.Globals.LState_Nothing.Clone
        Dim objORelS_FileResource_Attributes = New List(Of clsObjectAtt) From {New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Pattern.GUID, _
                                                                                                       .ID_Object = OItem_FileResource.GUID}, _
                                                                               New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_SubItems.GUID, _
                                                                                                      .ID_Object = OItem_FileResource.GUID}}

        Dim objOItem_Result = objDBLevel_Attributes.get_Data_ObjectAtt(objORelS_FileResource_Attributes, _
                                                                       boolIDs:=False)

        objOAItem_Pattern = Nothing
        objOAItem_SubItems = Nothing

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objOA_Pattern = objDBLevel_Attributes.OList_ObjectAtt.Where(Function(p) p.ID_AttributeType = objLocalConfig.OItem_Attribute_Pattern.GUID).ToList()

            If objOA_Pattern.Any() Then
                objOAItem_Pattern = New clsObjectAtt With {.ID_Attribute = objOA_Pattern.First().ID_Attribute, _
                                                           .ID_AttributeType = objLocalConfig.OItem_Attribute_Pattern.GUID, _
                                                           .ID_Object = objOA_Pattern.First().ID_Object, _
                                                           .ID_Class = objOA_Pattern.First().ID_Class, _
                                                           .Val_Named = objOA_Pattern.First().Val_Named, _
                                                           .Val_String = objOA_Pattern.First().Val_String}

            End If

            Dim objOA_SubItems = objDBLevel_Attributes.OList_ObjectAtt.Where(Function(p) p.ID_AttributeType = objLocalConfig.OItem_Attribute_SubItems.GUID).ToList()

            If objOA_SubItems.Any() Then
                objOAItem_SubItems = New clsObjectAtt With {.ID_Attribute = objOA_SubItems.First().ID_Attribute, _
                                                           .ID_AttributeType = objLocalConfig.OItem_Attribute_SubItems.GUID, _
                                                           .ID_Object = objOA_SubItems.First().ID_Object, _
                                                           .ID_Class = objOA_SubItems.First().ID_Class, _
                                                           .Val_Named = objOA_SubItems.First().Val_Named, _
                                                           .Val_Bit = objOA_SubItems.First().Val_Bit}

            End If

        End If
        objOItem_Result_Attributes = objOItem_Result
    End Sub

    Public Sub GetData_Relations(OItem_FileResource As clsOntologyItem)
        objOItem_Result_Relations = objLocalConfig.Globals.LState_Nothing.Clone
        objORItem_Path = Nothing

        Dim objORelS_Relations = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = OItem_FileResource.GUID, _
                                                                                         .ID_Parent_Other = objLocalConfig.OItem_Type_Path.GUID, _
                                                                                         .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Resource.GUID}}

        Dim objOItem_Result = objDBLevel_Relations.get_Data_ObjectRel(objORelS_Relations, boolIDs:=False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Relations.OList_ObjectRel.Any Then
                objORItem_Path = New clsObjectRel With {.ID_Object = objDBLevel_Relations.OList_ObjectRel.First().ID_Object, _
                                                        .ID_Parent_Object = objDBLevel_Relations.OList_ObjectRel.First().ID_Parent_Object, _
                                                        .ID_Other = objDBLevel_Relations.OList_ObjectRel.First().ID_Other, _
                                                        .Name_Other = objDBLevel_Relations.OList_ObjectRel.First().Name_Other, _
                                                        .ID_Parent_Other = objDBLevel_Relations.OList_ObjectRel.First().ID_Parent_Other, _
                                                        .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Resource.GUID, _
                                                        .OrderID = objDBLevel_Relations.OList_ObjectRel.First().OrderID, _
                                                        .Ontology = objDBLevel_Relations.OList_ObjectRel.First().Ontology}

            End If
        End If

        objOItem_Result_Relations = objOItem_Result
    End Sub

    Public Sub GetFiles()
        FileList = New List(Of clsFile)

        If Not objORItem_Path Is Nothing Then
            Dim strPath = objORItem_Path.Name_Other
            strPath = Environment.ExpandEnvironmentVariables(strPath)

            Dim boolSubItems As Boolean

            If Not objOAItem_SubItems Is Nothing Then
                boolSubItems = objOAItem_SubItems.Val_Bit
            End If

            Dim strPattern As String = ""

            If Not objOAItem_Pattern Is Nothing Then
                strPattern = objOAItem_Pattern.Val_String
            End If

            GetFilesLoc(strPath, boolSubItems, strPattern)

            If objOItem_Result_FileResult.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
                objOItem_Result_FileResult = objLocalConfig.Globals.LState_Success.Clone
            End If
        Else
            objOItem_Result_FileResult = objLocalConfig.Globals.LState_Relation.Clone
        End If

    End Sub

    Private Sub GetFilesLoc(strPath As String, boolSubItems As Boolean, strPattern As String)
        objOItem_Result_FileResult = objLocalConfig.Globals.LState_Nothing.Clone
        If IO.Directory.Exists(strPath) Then

            For Each strFile In IO.Directory.GetFiles(strPath)
                Dim objFile As New clsFile With {.FileName = strFile}

                If strPattern <> "" Then
                    Try
                        Dim objRegEx As New Regex(strPattern)
                        If objRegEx.Match(strFile).Success Then

                            FileList.Add(objFile)
                        End If
                    Catch ex As Exception
                        objOItem_Result_FileResult = objLocalConfig.Globals.LState_Error.Clone
                    End Try

                Else
                    FileList.Add(objFile)
                End If
            Next

            If objOItem_Result_FileResult.GUID = objLocalConfig.Globals.LState_Nothing.GUID And boolSubItems Then
                For Each strDirectory In IO.Directory.GetDirectories(strPath)
                    GetFilesLoc(strDirectory, boolSubItems, strPattern)
                Next
            End If
        Else
            objOItem_Result_FileResult = objLocalConfig.Globals.LState_Error.Clone
        End If
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objOItem_Result_Attributes = objLocalConfig.Globals.LState_Nothing.Clone
        objOItem_Result_Relations = objLocalConfig.Globals.LState_Nothing.Clone
        objOItem_Result_FileResult = objLocalConfig.Globals.LState_Nothing.Clone

        objDBLevel_Attributes = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Relations = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
