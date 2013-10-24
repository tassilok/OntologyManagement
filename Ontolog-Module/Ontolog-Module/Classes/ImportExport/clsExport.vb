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

<Flags()> _
Public Enum ModeEnum
    NoRelations = 1
    OntologyItems = 2
    OntologyJoins = 4
    ClassParents = 8
    AllRelations = 16
    OntologyStructures = 32
End Enum

    Public Class clsExport

    Private objGlobals As clsGlobals

    Private objRules As New clsOntologyRelationRules

    Private objTextWriter As IO.TextWriter

    Private objVariables As New clsVariables
    Private objOntologyRules As New clsOntologyRelationRules

    Private objDataWork_Ontologies As clsDataWork_Ontologies
    Private objDataWork_OntologyRels As clsDataWork_OntologyRels

        Private objOItem_Ontology As clsOntologyItem

    Private objOList_Objects as New List(Of clsOntologyItem)
        private objOList_Classes as New List(Of clsOntologyItem)
        private objOList_AttributeTypes as New List(Of clsOntologyItem)
        private objOList_RelationTypes as New List(Of clsOntologyItem) 

    private objOList_ClassesExtended as New List(Of clsOntologyItemsOfOntologies)
        private objOList_ClassesWithChildren as New List(Of clsOntologyItem)

    Private strPathDst As String

    Private strFiles As List(Of String) = New List(Of String)


    Public ReadOnly Property Files As List(Of String)
        Get
            Return strFiles
        End Get
    End Property

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

    private Function Export_OntologyStructures(OItem_Ontology As clsOntologyItem, strPathDst As String, objDict_XMLTemplates As Dictionary(Of XMLTemplateEnum, String)) As clsOntologyItem
        Dim objOItem_Result = objGlobals.LState_Success.Clone

        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            If objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_AttributeType).Any Then
                objOList_Objects.Add(OItem_Ontology)
                objOList_Classes.Add(objGlobals.Class_Ontologies)
                objOList_Classes.Add(objGlobals.Class_OntologyItems)
                objOList_Classes.Add(objGlobals.Class_OntologyJoin)
                objOList_Classes.Add(objGlobals.Class_OntologyRelationRule)

                objOList_RelationTypes.Add(objGlobals.RelationType_contains)
                objOList_RelationTypes.Add(objGlobals.RelationType_belonging)
                objOList_RelationTypes.Add(objGlobals.RelationType_isOfType)

                Dim objOList_OItems_AttributeTypes = objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_AttributeType).ToList
                For Each objOItem_AttributeType In objOList_OItems_AttributeTypes
                    objOList_Objects.Add(New clsOntologyItem With {.GUID = objOItem_AttributeType.ID_OntologyItem, _
                                                                   .Name = objOItem_AttributeType.Name_OntologyItem, _
                                                                   .GUID_Parent = objGlobals.Class_OntologyItems.GUID, _
                                                                   .Type = objGlobals.Type_Object})

                Next

                Dim objOList_OItems_RelationTypes = objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_RelationType).ToList

                For Each objOItem_RelationType In objOList_OItems_RelationTypes
                    objOList_Objects.Add(New clsOntologyItem With {.GUID = objOItem_RelationType.ID_OntologyItem, _
                                                                   .Name = objOItem_RelationType.Name_OntologyItem, _
                                                                   .GUID_Parent = objGlobals.Class_OntologyItems.GUID, _
                                                                   .Type = objGlobals.Type_Object})

                Next

                Dim objOList_OItems_Classes = objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_Class).ToList

                For Each objOItem_Class In objOList_OItems_Classes
                    objOList_Objects.Add(New clsOntologyItem With {.GUID = objOItem_Class.ID_OntologyItem, _
                                                                   .Name = objOItem_Class.Name_OntologyItem, _
                                                                   .GUID_Parent = objGlobals.Class_OntologyItems.GUID, _
                                                                   .Type = objGlobals.Type_Object})

                Next

                Dim objOList_OItems_Objects = objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_Object).ToList

                For Each objOItem_Object In objOList_OItems_Objects
                    objOList_Objects.Add(New clsOntologyItem With {.GUID = objOItem_Object.ID_OntologyItem, _
                                                                   .Name = objOItem_Object.Name_OntologyItem, _
                                                                   .GUID_Parent = objGlobals.Class_OntologyItems.GUID, _
                                                                   .Type = objGlobals.Type_Object})

                Next

                For Each objOntologyJoin In objDataWork_Ontologies.OList_JoinsOfOntologies.Where(Function(p) p.ID_Object = objOItem_Ontology.GUID).ToList
                    objOList_Objects.Add(New clsOntologyItem With {.GUID = objOntologyJoin.ID_Other, _
                                                                   .Name = objOntologyJoin.Name_Other, _
                                                                   .GUID_Parent = objOntologyJoin.ID_Parent_Other, _
                                                                   .Type = objGlobals.Type_Object})

                Next
            End If
        End If

        Return objOItem_Result
    End Function

    Public Function Export_Ontology(OItem_Ontology As clsOntologyItem, strPathDst As String, mode As ModeEnum, Optional objDict_XMLTemplates As Dictionary(Of XMLTemplateEnum, String) = Nothing, Optional boolOntology As Boolean = False) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem = objDataWork_Ontologies.LocalConfig.Globals.LState_Error.Clone()

        objOList_Objects.Clear()
        objOList_AttributeTypes.Clear()
        objOList_Classes.Clear()
        objOList_RelationTypes.Clear()
        objOList_ClassesExtended.Clear()
        objOList_ClassesWithChildren.Clear()


        objOItem_Ontology = OItem_Ontology

        Me.strPathDst = strPathDst
        strFiles = New List(Of String)
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

                if mode.HasFlag(ModeEnum.OntologyStructures) Then
                    objOItem_Result = Export_OntologyStructures(OItem_Ontology,strPathDst,objDict_XMLTemplates)
                End If

                If objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_AttributeType).Any Then
                    Dim strFileName = strPathDst & "\" & "AttributeTypes.xml"
                    strFiles.Add(strFileName)
                    objOItem_Result = Open_XMLWriter(strFileName)
                    If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                        objOList_AttributeTypes.AddRange(objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_AttributeType).Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Ref, _
                                                                                                                                                                                                                                                                                         .Name = p.Name_Ref, _
                                                                                                                                                                                                                                                                                         .GUID_Parent = p.ID_Parent_Ref, _
                                                                                                                                                                                                                                                                                         .Type = objGlobals.Type_Object}))
                        Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
                        strOutput = strOutput.Replace("@" & objVariables.Variable_ITEMTYPE.Name & "@", objGlobals.Type_AttributeType)
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
                    strFiles.Add(strFileName)
                    objOItem_Result = Open_XMLWriter(strFileName)
                    If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                        objOList_RelationTypes.AddRange(objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_RelationType).ToList().Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Ref, .Name = p.Name_Ref, _
                                                                                                                                                                                                                                                                                         .GUID_Parent = p.ID_Parent_Ref, _
                                                                                                                                                                                                                                                                                         .Type = objGlobals.Type_Object}))
                        Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
                        strOutput = strOutput.Replace("@" & objVariables.Variable_ITEMTYPE.Name & "@", objGlobals.Type_RelationType)
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

                If mode.HasFlag(ModeEnum.AllRelations) Or mode.HasFlag(ModeEnum.OntologyJoins) Or mode.HasFlag(ModeEnum.OntologyItems) Then
                    objOList_ClassesExtended = objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_Class).ToList()
                    objOList_ClassesWithChildren = objOList_ClassesExtended.Where(Function(p) p.ID_OntologyRelationRule = objOntologyRules.Rule_ChildToken.GUID).GroupBy(Function(p) New With {p.ID_Ref, p.Name_Ref, p.ID_Parent_Ref, p.ID_OntologyRelationRule}).Select(Function(p) New clsOntologyItem With {.GUID_Parent = p.Key.ID_Ref}).ToList()
                    If objOList_ClassesWithChildren.Any() Then
                        objOList_Objects.AddRange(objDataWork_OntologyRels.GetData_ObjectsOfClasses(objOList_ClassesWithChildren))
                    End If

                End If


                If objOList_Objects.Any Then
                    Dim strFileName = strPathDst & "\" & "Objects.xml"
                    strFiles.Add(strFileName)
                    objOItem_Result = Open_XMLWriter(strFileName)
                    If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                        objOList_Classes.AddRange(From objClass In objDataWork_OntologyRels.GetData_ClassesOfObjects(objOList_Objects.GroupBy(Function(p) p.GUID_Parent).Select(Function(p) New clsOntologyItem With {.GUID = p.Key}).ToList())
                                                  group Join objClassExist In objOList_Classes on objClass.GUID equals objClassExist.GUID Into objClassesExist = Group
                                                  From objClassExist In objClassesExist.DefaultIfEmpty()
                                                  Where objClassExist Is Nothing
                                                  Select objClass)

                        Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
                        strOutput = strOutput.Replace("@" & objVariables.Variable_ITEMTYPE.Name & "@", objGlobals.Type_Object)
                        objTextWriter.Write(strOutput)

                        objOList_Objects = (From objObject in objOList_Objects
                                            Group By objObject.GUID, objObject.Name, objObject.GUID_Parent Into Group
                                            Select New clsOntologyItem With { .GUID = GUID, _
                                                                             .Name = Name, _
                                                                             .GUID_Parent = GUID_Parent, _
                                                                             .Type = objGlobals.Type_Object}).ToList()
                        For Each objOItem_Object In objOList_Objects
                            strOutput = objDict_XMLTemplates(XMLTemplateEnum.OntologyItem)
                            strOutput = strOutput.Replace("@" & objVariables.Variable_ID_ITEM.Name & "@", objOItem_Object.GUID)
                            strOutput = strOutput.Replace("@" & objVariables.Variable_ID_PARENT.Name & "@", objOItem_Object.GUID_Parent)
                            strOutput = strOutput.Replace("@" & objVariables.Variable_NAME_ITEM.Name & "@", objOItem_Object.Name)

                            objTextWriter.Write(strOutput)
                        Next

                        strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@") + ("@" & objVariables.Variable_ITEMLIST.Name & "@").Length)
                        objTextWriter.Write(strOutput)
                    End If

                    Close_XMLWriter()
                End If
                objOList_Classes.AddRange((From objClassNew In objOList_ClassesExtended
                                               Group Join objClass In objOList_Classes On objClass.GUID Equals objClassNew.ID_Ref Into objClasses = Group
                                               From objClassOld In objClasses.DefaultIfEmpty()
                                               Where objClassOld Is Nothing
                                               Select New clsOntologyItem With {.GUID = objClassNew.ID_Ref, _
                                                                                .Name = objClassNew.Name_Ref, _
                                                                                .GUID_Parent = objClassNew.ID_Parent_Ref, _
                                                                                .Type = objClassNew.Type_Ref}))
                If objOList_Classes.Any Then

                    If mode.HasFlag(ModeEnum.ClassParents) Then
                        Dim intClassCount = 0
                        Do
                            intClassCount = objOList_Classes.Count
                            objOList_Classes.AddRange(From objClassParent In objDataWork_Ontologies.OList_AllCalsses _
                                                      Join objClassSub In objOList_Classes On objClassParent.GUID Equals objClassSub.GUID_Parent _
                                                      Group Join objClassOld In objOList_Classes On objClassParent.GUID Equals objClassOld.GUID Into objClassesOld = Group
                                                      From objClassOld In objClassesOld.DefaultIfEmpty()
                                                      Where objClassOld Is Nothing
                                                      Select objClassParent)



                        Loop Until objOList_Classes.Count - intClassCount = 0
                    End If
                    Dim strFileName = strPathDst & "\" & "Classes.xml"
                    strFiles.Add(strFileName)
                    objOItem_Result = Open_XMLWriter(strFileName)
                    If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

                        Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
                        strOutput = strOutput.Replace("@" & objVariables.Variable_ITEMTYPE.Name & "@", objGlobals.Type_Class)
                        objTextWriter.Write(strOutput)
                        objOList_Classes = (from objClass in objOList_Classes
                                            Group By objClass.GUID, objClass.Name, objClass.GUID_Parent Into group
                                            Select New clsOntologyItem With {.GUID = GUID, _
                                                .Name = Name, _
                                                .GUID_Parent = GUID_Parent, _
                                                .Type = objGlobals.Type_Object}).ToList()
                            

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

                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    objOItem_Result = export_OntologyRels(strPathDst,mode,objDict_XMLTemplates)
                End If

                objOItem_Result = If(objOItem_Result.GUID = objGlobals.LState_Nothing.GUID,objGlobals.LState_Success.Clone(),objOItem_Result)
                    

            End If


        End If

        
        Return objOItem_Result
    End Function

    Private Function export_OntologyRels(strPathDst As String, mode As ModeEnum, objDict_XMLTemplates As Dictionary(Of XMLTemplateEnum, String))
        Dim objOItem_Result = objGlobals.LState_Nothing
        If mode.HasFlag(ModeEnum.AllRelations) = True Then

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
                                strFiles.Add(strFileName)
                                objOItem_Result = Open_XMLWriter(strFileName)
                                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                                    Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ITEMTYPE.Name & "@", objGlobals.Type_ClassAtt)
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

                                Close_XMLWriter()
                            End If

                            If objDataWork_OntologyRels.ClassRel.Any Then
                                Dim strFileName = strPathDst & "\" & "ClassRels.xml"
                                strFiles.Add(strFileName)
                                objOItem_Result = Open_XMLWriter(strFileName)
                                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                                    Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ITEMTYPE.Name & "@", objGlobals.Type_ClassRel)
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

                                Close_XMLWriter()
                            End If

                            If objDataWork_OntologyRels.ObjectAtt.Any Then
                                Dim strFileName = strPathDst & "\" & "ObjectAtt.xml"
                                strFiles.Add(strFileName)
                                objOItem_Result = Open_XMLWriter(strFileName)
                                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                                    Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ITEMTYPE.Name & "@", objGlobals.Type_ObjectAtt)
                                    objTextWriter.Write(strOutput)

                                    Dim objOList_OAtt = (From objObjAtt In objDataWork_OntologyRels.ObjectAtt
                                                            Join objObject In objOList_Objects On objObjAtt.ID_Object Equals objObject.GUID
                                                            Select objObjAtt).ToList()

                                    For Each objOItem_ObjectAtt In objOList_OAtt

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

                                Close_XMLWriter()
                            End If

                            If objDataWork_OntologyRels.ObjectRel.Any Then
                                Dim strFileName = strPathDst & "\" & "ObjectRel.xml"
                                strFiles.Add(strFileName)
                                objOItem_Result = Open_XMLWriter(strFileName)
                                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                                    Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
                                    strOutput = strOutput.Replace("@" & objVariables.Variable_ITEMTYPE.Name & "@", objGlobals.Type_ObjectRel)
                                    objTextWriter.Write(strOutput)

                                    Dim objOList_ORel = (From objObjRel In objDataWork_OntologyRels.ObjectRel
                                                            Join objObject In objOList_Objects On objObjRel.ID_Object Equals objObject.GUID
                                                            Select objObjRel).ToList()

                                    For Each objOItem_ObjectRel In objOList_ORel
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

                                Close_XMLWriter()
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

