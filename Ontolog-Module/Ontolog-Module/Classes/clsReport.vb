Imports OntologyClasses.BaseClasses

Public Class clsReport

    Private objLocalConfig As clsLocalConfig
    Private objConnection As SqlClient.SqlConnection


    Private objDBLevel_Classes As clsDBLevel
    Private objDBLevel_CalssAtt As clsDBLevel
    Private objDBLevel_AttributeTypes As clsDBLevel
    Private objDBLevel_DataType As clsDBLevel
    Private objDBLevel_Class As clsDBLevel
    Private objDBLevel_ClassRel As clsDBLevel
    Private objDBlevel_ObjAtt As clsDBLevel
    Private objDBLevel_Objects As clsDBLevel
    Private objDBLevel_ObjectRel As clsDBLevel
    Private objDBLevel_RelType As clsDBLevel

    Private objDBLevel_OntologyRules As clsDBLevel
    Private objDBLevel_Ontology As clsDBLevel

    Private strConnection As String

    Public Sub sync_SQLDB()
        sync_SQLDB_Classes()
        sync_SQLDB_Attributes()
        sync_SQLDB_Relations()
    End Sub

    Public Sub sync_SQLDB_Relations(Optional ByVal OList_ClassRel As List(Of clsClassRel) = Nothing, Optional boolOR As Boolean = False, Optional boolInitialize As Boolean = True, Optional boolFinalize As Boolean = True)
        Dim objClassRel As clsClassRel
        Dim objOList_Class_Left As New List(Of clsOntologyItem)
        Dim objOList_Class_Right As New List(Of clsOntologyItem)
        Dim objOList_ObjecRel As New List(Of clsObjectRel)
        Dim objOList_RelTypes As New List(Of clsOntologyItem)
        Dim objOItem_ORel As clsObjectRel
        Dim objTextWriter As IO.TextWriter
        Dim objTextWriter2 As IO.TextWriter
        Dim strPath As String
        Dim strPath2 As String
        Dim strLine As String
        Dim strType As String
        Dim strClass_Left As String
        Dim strClass_Right As String
        Dim strRelationType As String
        Dim i As Integer
        Dim j As Integer

        Dim createA_Table_relT As New DataSet_ReportTableAdapters.create_Table_relTTableAdapter
        Dim createA_Table_relT_Or As New DataSet_ReportTableAdapters.create_Table_relT_ORTableAdapter
        Dim finalizeA_Table_relT As New DataSet_ReportTableAdapters.finalize_Table_relTTableAdapter
        Dim finalizeA_Table_relT_Or As New DataSet_ReportTableAdapters.finalize_Table_relT_ORTableAdapter
        Dim finalizeA_Tables As New DataSet_ReportTableAdapters.finalize_TablesTableAdapter
        Dim initializeA_Table_relT As New DataSet_ReportTableAdapters.initialize_Table_relTTableAdapter
        Dim initializeA_Table_relT_Or As New DataSet_ReportTableAdapters.initialize_Table_relT_ORTableAdapter
        Dim initializeA_Tables As New DataSet_ReportTableAdapters.initialize_TablesTableAdapter

        initializeA_Tables.Connection = New SqlClient.SqlConnection(strConnection)
        finalizeA_Tables.Connection = New SqlClient.SqlConnection(strConnection)
        createA_Table_relT.Connection = New SqlClient.SqlConnection(strConnection)
        createA_Table_relT_Or.Connection = New SqlClient.SqlConnection(strConnection)
        finalizeA_Table_relT.Connection = New SqlClient.SqlConnection(strConnection)
        finalizeA_Table_relT_Or.Connection = New SqlClient.SqlConnection(strConnection)
        initializeA_Table_relT.Connection = New SqlClient.SqlConnection(strConnection)
        initializeA_Table_relT_Or.Connection = New SqlClient.SqlConnection(strConnection)


        If boolInitialize Then
            initializeA_Tables.GetData(objLocalConfig.Globals.Type_ObjectRel)
        End If


        objDBLevel_ClassRel.get_Data_ClassRel(OList_ClassRel, False, False, boolOR)
        
        For Each objClassRel In objDBLevel_ClassRel.OList_ClassRel

            objOList_ObjecRel.Clear()
            objOList_ObjecRel.Add(New clsObjectRel(Nothing, _
                                                   Nothing, _
                                                   objClassRel.ID_Class_Left, _
                                                   Nothing, _
                                                   Nothing, _
                                                   Nothing, _
                                                   objClassRel.ID_Class_Right, _
                                                   Nothing, _
                                                   objClassRel.ID_RelationType, _
                                                   Nothing, _
                                                   objLocalConfig.Globals.Type_Object, _
                                                   Nothing, _
                                                   Nothing, _
                                                   Nothing))




            objDBLevel_ObjectRel.get_Data_ObjectRel(objOList_ObjecRel, False, False)

            strPath = "%Temp%\" & Guid.NewGuid().ToString & ".xml"
            strPath2 = "%Temp%\" & Guid.NewGuid().ToString & ".xml"
            strPath = Environment.ExpandEnvironmentVariables(strPath)
            strPath2 = Environment.ExpandEnvironmentVariables(strPath2)
            strClass_Left = objClassRel.Name_Class_Left
            strClass_Right = objClassRel.Name_Class_Right
            strRelationType = objClassRel.Name_RelationType

            initializeA_Table_relT.GetData(strClass_Left, strClass_Right, strRelationType)
            initializeA_Table_relT_Or.GetData(strClass_Left, strRelationType)

            i = 0
            Dim objORel = objDBLevel_ObjectRel.OList_ObjectRel.OrderBy(Function(p) p.ID_Parent_Other).ToList()
            If objORel.Any Then
                
                While i < objORel.Count
                    objTextWriter = New IO.StreamWriter(strPath, False, System.Text.Encoding.UTF8)
                    objTextWriter2 = New IO.StreamWriter(strPath2, False, System.Text.Encoding.UTF8)
                    strLine = "<?xml version=""1.0"" encoding=""UTF-8""?>"
                    objTextWriter.WriteLine(strLine)
                    objTextWriter2.WriteLine(strLine)
                    strLine = "<root>"
                    objTextWriter.WriteLine(strLine)
                    objTextWriter2.WriteLine(strLine)

                    For j = i To i + 500
                        If j < objORel.Count Then
                            objOItem_ORel = objORel(j)
                            If (strClass_Left <> "" And _
                                strClass_Right <> "" And _
                                strRelationType <> "") And (strRelationType <> objOItem_ORel.Name_RelationType Or _
                                                            strClass_Left <> objOItem_ORel.Name_Parent_Object Or _
                                                            strClass_Right <> objOItem_ORel.Name_Parent_Other) Then

                                strLine = "</root>"
                                objTextWriter.WriteLine(strLine)
                                objTextWriter2.WriteLine(strLine)
                                objTextWriter.Close()
                                objTextWriter2.Close()

                                
                                createA_Table_relT.GetData(objLocalConfig.Globals.Type_ObjectRel, _
                                                           strClass_Left, _
                                                           strClass_Right, _
                                                           strRelationType, _
                                                           strPath, _
                                                           True)


                                createA_Table_relT_Or.GetData(objLocalConfig.Globals.Type_Other, _
                                                           strClass_Left, _
                                                           strRelationType, _
                                                           strPath2, _
                                                           True)


                                objTextWriter = New IO.StreamWriter(strPath, False, System.Text.Encoding.UTF8)
                                objTextWriter2 = New IO.StreamWriter(strPath2, False, System.Text.Encoding.UTF8)
                                strLine = "<?xml version=""1.0"" encoding=""UTF-8""?>"
                                objTextWriter.WriteLine(strLine)
                                objTextWriter2.WriteLine(strLine)
                                strLine = "<root>"
                                objTextWriter.WriteLine(strLine)
                                objTextWriter2.WriteLine(strLine)

                                strClass_Left = objOItem_ORel.Name_Parent_Object
                                strClass_Right = objOItem_ORel.Name_Parent_Other
                                strRelationType = objOItem_ORel.Name_RelationType
                            Else

                                strClass_Left = objOItem_ORel.Name_Parent_Object
                                strClass_Right = objOItem_ORel.Name_Parent_Other
                                strRelationType = objOItem_ORel.Name_RelationType
                            End If


                            strLine = "<tmptbl>"
                            objTextWriter.WriteLine(strLine)
                            objTextWriter2.WriteLine(strLine)

                            strLine = "<GUID_Object_Left>" & objOItem_ORel.ID_Object & "</GUID_Object_Left>"
                            objTextWriter.WriteLine(strLine)
                            objTextWriter2.WriteLine(strLine)
                            strLine = "<GUID_Object_Right>" & objOItem_ORel.ID_Other & "</GUID_Object_Right>"
                            objTextWriter.WriteLine(strLine)
                            strLine = "<GUID_Right>" & objOItem_ORel.ID_Other & "</GUID_Right>"
                            objTextWriter2.WriteLine(strLine)
                            strLine = "<Name_Right><![CDATA[" & objOItem_ORel.Name_Other & "]]></Name_Right>"
                            objTextWriter2.WriteLine(strLine)
                            strLine = "<GUID_RelationType>" & objOItem_ORel.ID_RelationType & "</GUID_RelationType>"
                            objTextWriter.WriteLine(strLine)
                            objTextWriter2.WriteLine(strLine)
                            strLine = "<Name_RelationType>" & objOItem_ORel.Name_RelationType & "</Name_RelationType>"
                            objTextWriter.WriteLine(strLine)
                            objTextWriter2.WriteLine(strLine)
                            strLine = "<OrderID>" & objOItem_ORel.OrderID & "</OrderID>"
                            objTextWriter.WriteLine(strLine)
                            objTextWriter2.WriteLine(strLine)
                            strLine = "<Exist>1</Exist>"
                            objTextWriter.WriteLine(strLine)
                            objTextWriter2.WriteLine(strLine)
                            strLine = "</tmptbl>"
                            objTextWriter.WriteLine(strLine)
                            objTextWriter2.WriteLine(strLine)
                        Else
                            Exit For
                        End If
                    Next
                    strLine = "</root>"
                    objTextWriter.WriteLine(strLine)
                    objTextWriter2.WriteLine(strLine)
                    objTextWriter.Close()
                    objTextWriter2.Close()


                    createA_Table_relT.GetData(objLocalConfig.Globals.Type_ObjectRel, _
                                               strClass_Left, _
                                               strClass_Right, _
                                               strRelationType, _
                                               strPath, _
                                               True)




                    createA_Table_relT_Or.GetData(objLocalConfig.Globals.Type_Other, _
                                               strClass_Left, _
                                               strRelationType, _
                                               strPath2, _
                                               True)

                    i = j
                End While
            Else

                objOList_Class_Left.Clear()
                objOList_Class_Right.Clear()
                objOList_RelTypes.Clear()
                objOList_Class_Left.Add(New clsOntologyItem(objClassRel.ID_Class_Left, objLocalConfig.Globals.Type_Class))
                objOList_Class_Right.Add(New clsOntologyItem(objClassRel.ID_Class_Right, objLocalConfig.Globals.Type_Class))
                objOList_RelTypes.Clear()
                objOList_RelTypes.Add(New clsOntologyItem(objClassRel.ID_RelationType, objLocalConfig.Globals.Type_RelationType))


                objDBLevel_Classes.get_Data_Classes(objOList_Class_Left, False, False)
                objDBLevel_Classes.get_Data_Classes(objOList_Class_Right, False, True)
                objDBLevel_RelType.get_Data_RelationTypes(objOList_RelTypes, False)

                If objDBLevel_Classes.OList_Classes_Left.Count > 0 And _
                    objDBLevel_Classes.OList_Classes_Right.Count > 0 And _
                    objDBLevel_RelType.OList_RelationTypes.Count > 0 Then

                    If Not strClass_Right Is Nothing Then
                        createA_Table_relT.GetData(objLocalConfig.Globals.Type_ObjectRel, _
                                                   strClass_Left, _
                                                   strClass_Right, _
                                                   strRelationType, _
                                                   strPath, _
                                                   False)
                    End If
                    

                    createA_Table_relT_OR.GetData(objLocalConfig.Globals.Type_Other, _
                                                   strClass_Left, _
                                                   strRelationType, _
                                                   strPath2, _
                                                   False)
                End If

            End If
            finalizeA_Table_relT.GetData(strClass_Left, strClass_Right, strRelationType)
            finalizeA_Table_relT_Or.GetData(strClass_Left, strRelationType)
        Next

        If boolFinalize Then
            finalizeA_Tables.GetData(objLocalConfig.Globals.Type_ObjectRel)
        End If

    End Sub

    Public Sub sync_SQLDB_Attributes(Optional ByVal objOItem_Class As clsOntologyItem = Nothing, Optional ByVal objOItem_AttType As clsOntologyItem = Nothing)
        Dim objOItem_Object As clsOntologyItem
        Dim objOItem_AttributeType As clsOntologyItem
        Dim objOItem_ObjAtt As clsObjectAtt
        Dim oList_AttTypes As New List(Of clsOntologyItem)
        Dim oList_AttributeTypes As New List(Of clsOntologyItem)
        Dim oList_ObjAtt As New List(Of clsObjectAtt)
        Dim oListDataTypes As New List(Of clsOntologyItem)
        Dim objTextWriter As IO.TextWriter
        Dim strPath As String
        Dim strLine As String
        Dim strType As String
        Dim strLength As String
        Dim i As Long
        Dim j As Long

        Dim createA_Table_attT As New DataSet_ReportTableAdapters.create_Table_attTTableAdapter
        Dim finalizeA_Table_attT As New DataSet_ReportTableAdapters.finalize_Table_attTTableAdapter
        Dim finalizeA_Tables As New DataSet_ReportTableAdapters.finalize_TablesTableAdapter
        Dim initializeA_Table_attT As New DataSet_ReportTableAdapters.initialize_Table_AttTTableAdapter
        Dim initializeA_Tables As New DataSet_ReportTableAdapters.initialize_TablesTableAdapter

        initializeA_Tables.Connection = New SqlClient.SqlConnection(strConnection)
        finalizeA_Tables.Connection = New SqlClient.SqlConnection(strConnection)
        finalizeA_Table_attT.Connection = New SqlClient.SqlConnection(strConnection)
        createA_Table_attT.Connection = New SqlClient.SqlConnection(strConnection)
        initializeA_Table_attT.Connection = New SqlClient.SqlConnection(strConnection)

        oList_AttTypes.Add(objOItem_AttType)

        initializeA_Tables.GetData(objLocalConfig.Globals.Type_ObjectAtt)

        objDBLevel_AttributeTypes.get_Data_AttributeType(OList_AttTypes, False)

        For Each objOItem_AttributeType In objDBLevel_AttributeTypes.OList_AttributeTypes
            oList_AttributeTypes.Clear()
            oList_AttributeTypes.Add(New clsOntologyItem(objOItem_AttributeType.GUID, objLocalConfig.Globals.Type_AttributeType))
            objDBLevel_CalssAtt.get_Data_ClassAtt(Nothing, oList_AttributeTypes, False, True)

            Select Case objOItem_AttributeType.GUID_Parent
                Case objLocalConfig.Globals.DType_Bool.GUID
                    strType = "Bit"
                    strLength = "0"
                Case objLocalConfig.Globals.DType_DateTime.GUID
                    strType = "DateTime"
                    strLength = "0"
                Case objLocalConfig.Globals.DType_Int.GUID
                    strType = "Bigint"
                    strLength = "0"
                Case objLocalConfig.Globals.DType_Real.GUID
                    strType = "Real"
                    strLength = "0"
                Case objLocalConfig.Globals.DType_String.GUID
                    strType = "NVARCHAR"
                    strLength = "MAX"

            End Select
            oListDataTypes.Clear()

            oListDataTypes.Add(New clsOntologyItem(objOItem_AttributeType.GUID_Parent, objLocalConfig.Globals.Type_DataType))
            objDBLevel_DataType.get_Data_DataTyps(oListDataTypes, False)

            

            strPath = "%Temp%\" & Guid.NewGuid().ToString & ".xml"
            strPath = Environment.ExpandEnvironmentVariables(strPath)

            oList_ObjAtt.Add(New clsObjectAtt(Nothing, Nothing, objOItem_Class.GUID, objOItem_AttributeType.GUID, Nothing))
            objDBlevel_ObjAtt.get_Data_ObjectAtt(oList_ObjAtt, False, False)

            
            i = 0

            If objDBlevel_ObjAtt.OList_ObjectAtt.Count > 0 Then
                initializeA_Table_attT.GetData(objOItem_Class.Name, objOItem_AttributeType.Name)
                While i < objDBlevel_ObjAtt.OList_ObjectAtt.Count
                    objTextWriter = New IO.StreamWriter(strPath, False, System.Text.Encoding.UTF8)
                    strLine = "<?xml version=""1.0"" encoding=""UTF-8""?>"
                    objTextWriter.WriteLine(strLine)
                    strLine = "<root>"
                    objTextWriter.WriteLine(strLine)

                    For j = i To i + 500
                        If j < objDBlevel_ObjAtt.OList_ObjectAtt.Count Then
                            objOItem_ObjAtt = objDBlevel_ObjAtt.OList_ObjectAtt(j)
                            strLine = "<tmptbl>"
                            objTextWriter.WriteLine(strLine)
                            strLine = "<GUID_Attribute>" & objOItem_ObjAtt.ID_Attribute & "</GUID_Attribute>"
                            objTextWriter.WriteLine(strLine)
                            strLine = "<GUID_AttributeType>" & objOItem_ObjAtt.ID_AttributeType & "</GUID_AttributeType>"
                            objTextWriter.WriteLine(strLine)
                            strLine = "<Name_AttributeType><![CDATA[" & objOItem_ObjAtt.Name_AttributeType & "]]></Name_AttributeType>"
                            objTextWriter.WriteLine(strLine)
                            strLine = "<GUID_Object>" & objOItem_ObjAtt.ID_Object & "</GUID_Object>"
                            objTextWriter.WriteLine(strLine)
                            strLine = "<OrderID>" & objOItem_ObjAtt.OrderID & "</OrderID>"
                            objTextWriter.WriteLine(strLine)
                            If strType = "NVARCHAR" Then
                                strLine = "<val><![CDATA[" & Web.HttpUtility.HtmlEncode(objOItem_ObjAtt.val_Named) & "]]></val>"
                            ElseIf strType = "Real" Then
                                strLine = "<val>" & objOItem_ObjAtt.Val_Named.Replace(",", ".") & "</val>"
                            ElseIf strType = "DateTime" Then
                                strLine = "<val>" & objOItem_ObjAtt.Val_Date.Value.ToString("yyyy-MM-dd HH:mm:ss") & "</val>"
                            ElseIf strType = "Bit" Then
                                strLine = "<val>" & If(objOItem_ObjAtt.Val_Bit, 1, 0) & "</val>"
                            Else
                                strLine = "<val>" & objOItem_ObjAtt.Val_Named & "</val>"
                            End If

                            objTextWriter.WriteLine(strLine)
                            strLine = "<Exist>1</Exist>"
                            objTextWriter.WriteLine(strLine)
                            strLine = "</tmptbl>"
                            objTextWriter.WriteLine(strLine)

                        Else
                            Exit For
                        End If
                    Next

                    strLine = "</root>"
                    objTextWriter.WriteLine(strLine)
                    objTextWriter.Close()

                    
                    createA_Table_attT.GetData(objLocalConfig.Globals.Type_AttributeType, objOItem_Class.Name, objOItem_AttributeType.Name, strType, strLength, True, strPath)
                    
                    i = j
                End While
                finalizeA_Table_attT.GetData(objOItem_Class.Name, objOItem_AttributeType.Name)
            Else
                initializeA_Table_attT.GetData(objOItem_Class.Name, objOItem_AttributeType.Name)
                createA_Table_attT.GetData(objLocalConfig.Globals.Type_ObjectAtt, objOItem_Class.Name, objOItem_AttributeType.Name, strType, strLength, False, strPath)
                finalizeA_Table_attT.GetData(objOItem_Class.Name, objOItem_AttributeType.Name)
            End If


        Next


        finalizeA_Tables.GetData(objLocalConfig.Globals.Type_ObjectAtt)

    End Sub

    Public Sub sync_SQLDB_Classes(Optional ByVal OList_Classes As List(Of clsOntologyItem) = Nothing)
        Dim objOItem_Class As clsOntologyItem
        Dim objOItem_Object As clsOntologyItem
        Dim oList_Objects As New List(Of clsOntologyItem)
        Dim objTextWriter As IO.TextWriter
        Dim strPath As String
        Dim strLine As String
        Dim i As Long
        Dim j As Long
        Dim createA_Table_orgT As New DataSet_ReportTableAdapters.create_Table_orgTTableAdapter
        Dim finalizeA_Table_orgT As New DataSet_ReportTableAdapters.finalize_Table_orgTTableAdapter
        Dim finalizeA_Tables As New DataSet_ReportTableAdapters.finalize_TablesTableAdapter
        Dim initializeA_Table_orgT As New DataSet_ReportTableAdapters.initialize_Table_orgTTableAdapter

        finalizeA_Tables.Connection = New SqlClient.SqlConnection(strConnection)
        finalizeA_Table_orgT.Connection = New SqlClient.SqlConnection(strConnection)
        createA_Table_orgT.Connection = New SqlClient.SqlConnection(strConnection)
        initializeA_Table_orgT.Connection = New SqlClient.SqlConnection(strConnection)

        objDBLevel_Classes.get_Data_Classes(OList_Classes, False, False)
        For Each objOItem_Class In objDBLevel_Classes.OList_Classes

            
            oList_Objects.Clear()
            oList_Objects.Add(New clsOntologyItem(Nothing, Nothing, objOItem_Class.GUID, objLocalConfig.Globals.Type_Object))
            objDBLevel_Objects.get_Data_Objects(oList_Objects, False)
            strPath = "%Temp%\" & Guid.NewGuid().ToString & ".xml"
            strPath = Environment.ExpandEnvironmentVariables(strPath)
            i = 0
            If objDBLevel_Objects.OList_Objects.Count > 0 Then
                initializeA_Table_orgT.GetData(objOItem_Class.Name)
                While i < objDBLevel_Objects.OList_Objects.Count

                    objTextWriter = New IO.StreamWriter(strPath, False, System.Text.Encoding.UTF8)
                    strLine = "<?xml version=""1.0"" encoding=""UTF-8""?>"
                    objTextWriter.WriteLine(strLine)
                    strLine = "<root>"
                    objTextWriter.WriteLine(strLine)
                    For j = i To i + 500

                        If j < objDBLevel_Objects.OList_Objects.Count Then
                            objOItem_Object = objDBLevel_Objects.OList_Objects(j)
                            strLine = "<tmptbl>"
                            objTextWriter.WriteLine(strLine)
                            strLine = "<GUID>" & objOItem_Object.GUID & "</GUID>"
                            objTextWriter.WriteLine(strLine)
                            strLine = "<Name><![CDATA[" & objOItem_Object.Name & "]]></Name>"
                            objTextWriter.WriteLine(strLine)
                            strLine = "<GUID_Class>" & objOItem_Object.GUID_Parent & "</GUID_Class>"
                            objTextWriter.WriteLine(strLine)
                            strLine = "<Exist>1</Exist>"
                            objTextWriter.WriteLine(strLine)
                            strLine = "</tmptbl>"
                            objTextWriter.WriteLine(strLine)

                        Else
                            Exit For
                        End If

                    Next

                    strLine = "</root>"
                    objTextWriter.WriteLine(strLine)
                    objTextWriter.Close()

                    
                    createA_Table_orgT.GetData(objLocalConfig.Globals.Type_Class, objOItem_Class.Name, strPath, True)
                    



                    i = j
                End While
                finalizeA_Table_orgT.GetData(objOItem_Class.Name)
            Else
                initializeA_Table_orgT.GetData(objOItem_Class.Name)
                createA_Table_orgT.GetData(objLocalConfig.Globals.Type_Class, objOItem_Class.Name, strPath, False)
                finalizeA_Table_orgT.GetData(objOItem_Class.Name)
            End If


           
        Next

        finalizeA_Tables.GetData(objLocalConfig.Globals.Type_Class)
    End Sub

    Public Sub sync_SQLDB_AttributeTypes()

    End Sub

    Public Sub sync_SQLDB_RelationTypes()

    End Sub

    Public Sub sync_SQLDB_Classes()

    End Sub

    Public Sub New(ByVal Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)

        set_DBConnection()
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()


        strConnection = objLocalConfig.Globals.get_ConnectionStr(objLocalConfig.Globals.Rep_Server, _
                                                                 objLocalConfig.Globals.Rep_Instance, _
                                                                 objLocalConfig.Globals.Rep_Database)
        

        objDBLevel_AttributeTypes = New clsDBLevel(objLocalConfig.Globals)
        objDBlevel_ObjAtt = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Objects = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Classes = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_CalssAtt = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Ontology = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OntologyRules = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_DataType = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Class = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ClassRel = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ObjectRel = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_RelType = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
