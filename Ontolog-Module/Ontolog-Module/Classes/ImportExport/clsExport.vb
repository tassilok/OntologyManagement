Imports System.IO
Imports System.Xml
Imports OntologyClasses.BaseClasses
Imports OntologyClasses.DataClasses
Imports System.Reflection

<Flags()> _
Public Enum XMLTemplateEnum
    ItemContainer
    ClassAtt
    ClassRel
    ObjectAtt
    ObjectRel
    OntologyItem
End Enum

    Public Class clsExport

        Private objGlobals As clsGlobals

    Private objTextWriter As IO.TextWriter

    Private objVariables As New clsVariables

    Private objDataWork_Ontologies As clsDataWork_Ontologies
    Private objDataWork_OntologyRels As clsDataWork_OntologyRels

        Private objOItem_Ontology As clsOntologyItem

        Private strPathDst As String

    Private Function Open_XMLWriter(strFileName As String) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        Try
            objTextWriter = New IO.StreamWriter(strFileName)

            objOItem_Result = objGlobals.LState_Success.Clone
        Catch ex As Exception
            objOItem_Result = objGlobals.LState_Error.Clone
        End Try

        Return objOItem_Result
    End Function

        Private Function Close_XMLWriter() As clsOntologyItem
            Dim objOItem_Result = objGlobals.LState_Success.Clone

            Try
            objTextWriter.Close()
            Catch ex As Exception

            End Try

            Return objOItem_Result
        End Function

    Public Function Export_Ontology(OItem_Ontology As clsOntologyItem, strPathDst As String, Optional objDict_XMLTemplates As Dictionary(Of XMLTemplateEnum, String) = Nothing, Optional boolOnlyItems As Boolean = False, Optional boolRel As Boolean = False) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem = objDataWork_Ontologies.LocalConfig.Globals.LState_Error.Clone()

        Dim objOList_Classes As List(Of clsOntologyItem) = New List(Of clsOntologyItem)
        Dim objOList_AttributeTypes As List(Of clsOntologyItem) = New List(Of clsOntologyItem)
        Dim objOList_RelationTypes As List(Of clsOntologyItem) = New List(Of clsOntologyItem)

        objOItem_Ontology = OItem_Ontology

        Me.strPathDst = strPathDst

        If objDict_XMLTemplates Is Nothing Then
            objDict_XMLTemplates = New Dictionary(Of XMLTemplateEnum, String)

            Dim objAssembly = [Assembly].GetExecutingAssembly()

            Try
                Dim objXMLStream = objAssembly.GetManifestResourceStream("Ontology_Module.OntologyItemContainer.xml")
                Dim objTextStreamReader = New StreamReader(objXMLStream, True)
                objDict_XMLTemplates(XMLTemplateEnum.ItemContainer) = objTextStreamReader.ReadToEnd()
                objTextStreamReader.Close()

                objXMLStream = objAssembly.GetManifestResourceStream("Ontology_Module.ClassAttItem.xml")
                objTextStreamReader = New StreamReader(objXMLStream, True)
                objDict_XMLTemplates(XMLTemplateEnum.ClassAtt) = objTextStreamReader.ReadToEnd()
                objTextStreamReader.Close()

                objXMLStream = objAssembly.GetManifestResourceStream("Ontology_Module.ClassRelItem.xml")
                objTextStreamReader = New StreamReader(objXMLStream, True)
                objDict_XMLTemplates(XMLTemplateEnum.ClassRel) = objTextStreamReader.ReadToEnd()
                objTextStreamReader.Close()

                objXMLStream = objAssembly.GetManifestResourceStream("Ontology_Module.ObjAttItem.xml")
                objTextStreamReader = New StreamReader(objXMLStream, True)
                objDict_XMLTemplates(XMLTemplateEnum.ObjectAtt) = objTextStreamReader.ReadToEnd()
                objTextStreamReader.Close()

                objXMLStream = objAssembly.GetManifestResourceStream("Ontology_Module.ObjRelItem.xml")
                objTextStreamReader = New StreamReader(objXMLStream, True)
                objDict_XMLTemplates(XMLTemplateEnum.ObjectRel) = objTextStreamReader.ReadToEnd()
                objTextStreamReader.Close()

                objXMLStream = objAssembly.GetManifestResourceStream("Ontology_Module.OntologyItem.xml")
                objTextStreamReader = New StreamReader(objXMLStream, True)
                objDict_XMLTemplates(XMLTemplateEnum.OntologyItem) = objTextStreamReader.ReadToEnd()
                objTextStreamReader.Close()

                objOItem_Result = objGlobals.LState_Success.Clone()
            Catch ex As Exception
                objOItem_Result = objGlobals.LState_Error.Clone()
            End Try

        End If

        If Not objDict_XMLTemplates Is Nothing Then
            objOItem_Result = objDataWork_Ontologies.LocalConfig.Globals.LState_Success
            If Not objDict_XMLTemplates.ContainsKey(XMLTemplateEnum.ItemContainer) Then
                objOItem_Result = objGlobals.LState_Error.Clone()
            End If

            If Not objDict_XMLTemplates.ContainsKey(XMLTemplateEnum.ClassAtt) Then
                objOItem_Result = objGlobals.LState_Error.Clone()
            End If

            If Not objDict_XMLTemplates.ContainsKey(XMLTemplateEnum.ClassRel) Then
                objOItem_Result = objGlobals.LState_Error.Clone()
            End If

            If Not objDict_XMLTemplates.ContainsKey(XMLTemplateEnum.ObjectAtt) Then
                objOItem_Result = objGlobals.LState_Error.Clone()
            End If

            If Not objDict_XMLTemplates.ContainsKey(XMLTemplateEnum.ObjectRel) Then
                objOItem_Result = objGlobals.LState_Error
            End If

            If Not objDict_XMLTemplates.ContainsKey(XMLTemplateEnum.OntologyItem) Then
                objOItem_Result = objGlobals.LState_Error.Clone()
            End If
        End If


        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            objOItem_Result = objDataWork_Ontologies.GetData_BaseData

            If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                If objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_AttributeType).Any Then
                    Dim strFileName = strPathDst & "\" & "AttributeTypes.xml"
                    objOItem_Result = Open_XMLWriter(strFileName)
                    If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                        objOList_AttributeTypes = objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_AttributeType).Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Ref, _
                                                                                                                                                                                                                                                                                         .Name = p.Name_Ref, _
                                                                                                                                                                                                                                                                                         .GUID_Parent = p.ID_Parent_Ref, _
                                                                                                                                                                                                                                                                                         .Type = objGlobals.Type_Object}).ToList()
                        Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
                        objTextWriter.Write(strOutput)

                        For Each objOItem_AttributeType In objOList_AttributeTypes
                            strOutput = objDict_XMLTemplates(XMLTemplateEnum.OntologyItem)
                            strOutput = strOutput.Replace("@" & objVariables.Variable_ID_ITEM.Name & "@", objOItem_AttributeType.GUID)
                            strOutput = strOutput.Replace("@" & objVariables.Variable_ID_PARENT.Name & "@", objOItem_AttributeType.GUID_Parent)
                            strOutput = strOutput.Replace("@" & objVariables.Variable_NAME_ITEM.Name & "@", objOItem_AttributeType.Name)

                            objTextWriter.Write(strOutput)
                        Next

                        strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@") + ("@" & objVariables.Variable_ITEMLIST.Name & "@").Length)
                        objTextWriter.Write(strOutput)
                    End If

                    Close_XMLWriter()
                End If

                If objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_RelationType).Any Then
                    Dim strFileName = strPathDst & "\" & "RelationTypes.xml"
                    objOItem_Result = Open_XMLWriter(strFileName)
                    If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                        objOList_RelationTypes = objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_RelationType).ToList().Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Ref, _
                                                                                                                                                                                                                                                                                         .Name = p.Name_Ref, _
                                                                                                                                                                                                                                                                                         .GUID_Parent = p.ID_Parent_Ref, _
                                                                                                                                                                                                                                                                                         .Type = objGlobals.Type_Object}).ToList()
                        Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
                        objTextWriter.Write(strOutput)

                        For Each objOItem_RelationType In objOList_RelationTypes
                            strOutput = objDict_XMLTemplates(XMLTemplateEnum.OntologyItem)
                            strOutput = strOutput.Replace("@" & objVariables.Variable_ID_ITEM.Name & "@", objOItem_RelationType.GUID)
                            strOutput = strOutput.Replace("@" & objVariables.Variable_ID_PARENT.Name & "@", "")
                            strOutput = strOutput.Replace("@" & objVariables.Variable_NAME_ITEM.Name & "@", objOItem_RelationType.Name)

                            objTextWriter.Write(strOutput)
                        Next

                        strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@") + ("@" & objVariables.Variable_ITEMLIST.Name & "@").Length)
                        objTextWriter.Write(strOutput)
                    End If

                    Close_XMLWriter()
                End If

                If objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_Class).Any Then
                    Dim strFileName = strPathDst & "\" & "Classes.xml"
                    objOItem_Result = Open_XMLWriter(strFileName)
                    If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                        objOList_Classes = objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_Class).Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Ref, _
                                                                                                                                                                                                                                                                                         .Name = p.Name_Ref, _
                                                                                                                                                                                                                                                                                         .GUID_Parent = p.ID_Parent_Ref, _
                                                                                                                                                                                                                                                                                         .Type = objGlobals.Type_Object}).ToList()
                        Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
                        objTextWriter.Write(strOutput)

                        For Each objOItem_Classes In objOList_Classes
                            strOutput = objDict_XMLTemplates(XMLTemplateEnum.OntologyItem)
                            strOutput = strOutput.Replace("@" & objVariables.Variable_ID_ITEM.Name & "@", objOItem_Classes.GUID)
                            strOutput = strOutput.Replace("@" & objVariables.Variable_ID_PARENT.Name & "@", objOItem_Classes.GUID_Parent)
                            strOutput = strOutput.Replace("@" & objVariables.Variable_NAME_ITEM.Name & "@", objOItem_Classes.Name)

                            objTextWriter.Write(strOutput)
                        Next

                        strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@") + ("@" & objVariables.Variable_ITEMLIST.Name & "@").Length)
                        objTextWriter.Write(strOutput)
                    End If

                    Close_XMLWriter()
                End If

                If objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_Object).Any Then
                    Dim strFileName = strPathDst & "\" & "Objects.xml"
                    objOItem_Result = Open_XMLWriter(strFileName)
                    If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                        objOList_Classes.AddRange(objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_Object).GroupBy(Function(p) p.ID_Parent_Ref).Select(Function(p) New clsOntologyItem With {.GUID = p.Key}))
                        Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
                        objTextWriter.Write(strOutput)

                        For Each objOItem_Object In objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_Object).ToList()
                            strOutput = objDict_XMLTemplates(XMLTemplateEnum.OntologyItem)
                            strOutput = strOutput.Replace("@" & objVariables.Variable_ID_ITEM.Name & "@", objOItem_Object.ID_Ref)
                            strOutput = strOutput.Replace("@" & objVariables.Variable_ID_PARENT.Name & "@", objOItem_Object.ID_Parent_Ref)
                            strOutput = strOutput.Replace("@" & objVariables.Variable_NAME_ITEM.Name & "@", objOItem_Object.Name_Ref)

                            objTextWriter.Write(strOutput)
                        Next

                        strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@") + ("@" & objVariables.Variable_ITEMLIST.Name & "@").Length)
                        objTextWriter.Write(strOutput)
                    End If

                    Close_XMLWriter()
                End If

                If boolOnlyItems = True Then
                    If boolRel = True Then
                        objDataWork_OntologyRels.OList_Classes = objOList_Classes
                        objDataWork_OntologyRels.OList_AttributeTypes = objOList_AttributeTypes
                        objDataWork_OntologyRels.OList_RelationTypes = objOList_RelationTypes

                        objDataWork_OntologyRels.GetData_ClassAtt()
                        objOItem_Result = objDataWork_OntologyRels.OItem_Result_ClassAtt
                        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                            objDataWork_OntologyRels.GetData_ClassRel()
                            objOItem_Result = objDataWork_OntologyRels.OItem_Result_ClassRel
                            If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                                objDataWork_OntologyRels.GetData_ObjectAtt()
                                objOItem_Result = objDataWork_OntologyRels.OItem_Result_ObjectAtt
                                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                                    objDataWork_OntologyRels.GetData_ObjectRel()
                                    objOItem_Result = objDataWork_OntologyRels.OItem_Result_ObjectRel
                                    If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                                        If objDataWork_OntologyRels.ClassAtt.Any Then
                                            Dim strFileName = strPathDst & "\" & "ClassAtts.xml"
                                            objOItem_Result = Open_XMLWriter(strFileName)
                                            If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                                                Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
                                                objTextWriter.Write(strOutput)

                                                For Each objOItem_ClassAtt In objDataWork_OntologyRels.ClassAtt
                                                    strOutput = objDict_XMLTemplates(XMLTemplateEnum.ClassAtt)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ID_CLASS.Name & "@", objOItem_ClassAtt.ID_Class)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ID_ATTRIBUTETYPE.Name & "@", objOItem_ClassAtt.ID_AttributeType)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ID_DATATYPE.Name & "@", objOItem_ClassAtt.ID_DataType)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_MIN.Name & "@", objOItem_ClassAtt.Min)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_MAX.Name & "@", objOItem_ClassAtt.Max)

                                                    objTextWriter.Write(strOutput)
                                                Next

                                                strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@") + ("@" & objVariables.Variable_ITEMLIST.Name & "@").Length)
                                                objTextWriter.Write(strOutput)
                                            End If
                                        End If

                                        If objDataWork_OntologyRels.ClassRel.Any Then
                                            Dim strFileName = strPathDst & "\" & "ClassRels.xml"
                                            objOItem_Result = Open_XMLWriter(strFileName)
                                            If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                                                Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
                                                objTextWriter.Write(strOutput)

                                                For Each objOItem_ClassRel In objDataWork_OntologyRels.ClassRel
                                                    strOutput = objDict_XMLTemplates(XMLTemplateEnum.ClassRel)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ID_CLASS_LEFT.Name & "@", objOItem_ClassRel.ID_Class_Left)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ID_CLASS_RIGHT.Name & "@", objOItem_ClassRel.ID_Class_Right)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ID_RELATIONTYPE.Name & "@", objOItem_ClassRel.ID_RelationType)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ONTOLOGY.Name & "@", objOItem_ClassRel.Ontology)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_MIN_FORW.Name & "@", objOItem_ClassRel.Min_Forw)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_MAX_FORW.Name & "@", objOItem_ClassRel.Max_Forw)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_MAX_BACKW.Name & "@", objOItem_ClassRel.Max_Backw)

                                                    objTextWriter.Write(strOutput)
                                                Next

                                                strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@") + ("@" & objVariables.Variable_ITEMLIST.Name & "@").Length)
                                                objTextWriter.Write(strOutput)
                                            End If
                                        End If

                                        If objDataWork_OntologyRels.ObjectAtt.Any Then
                                            Dim strFileName = strPathDst & "\" & "ObjectAtt.xml"
                                            objOItem_Result = Open_XMLWriter(strFileName)
                                            If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                                                Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
                                                objTextWriter.Write(strOutput)

                                                For Each objOItem_ObjectAtt In objDataWork_OntologyRels.ObjectAtt
                                                    strOutput = objDict_XMLTemplates(XMLTemplateEnum.ObjectAtt)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ID_ATTRIBUTE.Name & "@", objOItem_ObjectAtt.ID_Attribute)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ID_ATTRIBUTETYPE.Name & "@", objOItem_ObjectAtt.ID_AttributeType)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ID_DATATYPE.Name & "@", objOItem_ObjectAtt.ID_DataType)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ID_OBJECT.Name & "@", objOItem_ObjectAtt.ID_Object)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ID_CLASS.Name & "@", objOItem_ObjectAtt.ID_Class)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ORDERID.Name & "@", objOItem_ObjectAtt.OrderID)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_VAL_NAMED.Name & "@", objOItem_ObjectAtt.Val_Named)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_VAL_BIT.Name & "@", If(objOItem_ObjectAtt.Val_Bit Is Nothing, "", objOItem_ObjectAtt.Val_Bit))
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_VAL_DATE.Name & "@", If(objOItem_ObjectAtt.Val_Date Is Nothing, "", objOItem_ObjectAtt.Val_Date))
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_VAL_DOUBLE.Name & "@", If(objOItem_ObjectAtt.Val_Double Is Nothing, "", objOItem_ObjectAtt.Val_Double))
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_VAL_LNG.Name & "@", If(objOItem_ObjectAtt.Val_Lng Is Nothing, "", objOItem_ObjectAtt.Val_Lng))
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_VAL_STRING.Name & "@", If(objOItem_ObjectAtt.Val_String Is Nothing, "", objOItem_ObjectAtt.Val_String))

                                                    objTextWriter.Write(strOutput)
                                                Next

                                                strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@") + ("@" & objVariables.Variable_ITEMLIST.Name & "@").Length)
                                                objTextWriter.Write(strOutput)
                                            End If
                                        End If

                                        If objDataWork_OntologyRels.ObjectRel.Any Then
                                            Dim strFileName = strPathDst & "\" & "ObjectRel.xml"
                                            objOItem_Result = Open_XMLWriter(strFileName)
                                            If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                                                Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
                                                objTextWriter.Write(strOutput)

                                                For Each objOItem_ObjectRel In objDataWork_OntologyRels.ObjectRel
                                                    strOutput = objDict_XMLTemplates(XMLTemplateEnum.ObjectRel)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ID_OBJECT.Name & "@", objOItem_ObjectRel.ID_Object)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ID_PARENT_OBJECT.Name & "@", objOItem_ObjectRel.ID_Parent_Object)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ID_OTHER.Name & "@", objOItem_ObjectRel.ID_Other)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ID_PARENT_OTHER.Name & "@", objOItem_ObjectRel.ID_Parent_Other)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ID_RELATIONTYPE.Name & "@", objOItem_ObjectRel.ID_RelationType)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ORDERID.Name & "@", objOItem_ObjectRel.OrderID)
                                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ONTOLOGY.Name & "@", objOItem_ObjectRel.Ontology)
                                                    
                                                    objTextWriter.Write(strOutput)
                                                Next

                                                strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@") + ("@" & objVariables.Variable_ITEMLIST.Name & "@").Length)
                                                objTextWriter.Write(strOutput)
                                            End If
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

        Public Sub New(Globals As clsGlobals)
            objGlobals = Globals
            initialize()
        End Sub

        Private Sub initialize()
        objDataWork_Ontologies = New clsDataWork_Ontologies(objGlobals)
        objDataWork_OntologyRels = New clsDataWork_OntologyRels(objGlobals)
        End Sub
    End Class

