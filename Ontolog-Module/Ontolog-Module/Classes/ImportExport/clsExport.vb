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

    Public Property OList_Objects As New List(Of clsOntologyItem)
    Public Property OList_Classes As New List(Of clsOntologyItem)
    Public Property OList_AttributeTypes As New List(Of clsOntologyItem)
    Public Property OList_RelationTypes As New List(Of clsOntologyItem)

    Public Property OList_ClassAtt As List(Of clsClassAtt)
        Get
            Return objDataWork_OntologyRels.ClassAtt
        End Get
        Set(value As List(Of clsClassAtt))
            objDataWork_OntologyRels.ClassAtt = value
        End Set
    End Property

    Public Property OList_ClassRel As List(Of clsClassRel)
        Get
            Return objDataWork_OntologyRels.ClassRel
        End Get
        Set(value As List(Of clsClassRel))
            objDataWork_OntologyRels.ClassRel = value
        End Set
    End Property

    Public Property OList_ObjectAtt As List(Of clsObjectAtt)
        Get
            Return objDataWork_OntologyRels.ObjectAtt
        End Get
        Set(value As List(Of clsObjectAtt))
            objDataWork_OntologyRels.ObjectAtt = value
        End Set
    End Property

    Public Property OList_ObjectRel As List(Of clsObjectRel)
        Get
            Return objDataWork_OntologyRels.ObjectRel
        End Get
        Set(value As List(Of clsObjectRel))
            objDataWork_OntologyRels.ObjectRel = value
        End Set
    End Property

    Private objOList_ClassesExtended As New List(Of clsOntologyItemsOfOntologies)
    Private objOList_ClassesWithChildren As New List(Of clsOntologyItem)

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

    Private Function Export_OntologyStructures(OItem_Ontology As clsOntologyItem, strPathDst As String, objDict_XMLTemplates As Dictionary(Of XMLTemplateEnum, String)) As clsOntologyItem
        Dim objOItem_Result = objGlobals.LState_Success.Clone

        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            If objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID).Any Then
                OList_Objects.Add(OItem_Ontology)
                OList_Classes.Add(objGlobals.Class_Ontologies)
                OList_Classes.Add(objGlobals.Class_OntologyItems)
                OList_Classes.Add(objGlobals.Class_OntologyJoin)
                OList_Classes.Add(objGlobals.Class_OntologyRelationRule)

                OList_RelationTypes.Add(objGlobals.RelationType_contains)
                OList_RelationTypes.Add(objGlobals.RelationType_belonging)
                OList_RelationTypes.Add(objGlobals.RelationType_isOfType)
                OList_RelationTypes.Add(objGlobals.RelationType_belongingAttribute)
                OList_RelationTypes.Add(objGlobals.RelationType_belongingClass)
                OList_RelationTypes.Add(objGlobals.RelationType_belongingObject)
                OList_RelationTypes.Add(objGlobals.RelationType_belongingRelationType)
                OList_RelationTypes.Add(objGlobals.RelationType_belongingAttribute)

                Dim objOList_OItems_AttributeTypes = objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_AttributeType).ToList
                For Each objOItem_AttributeType In objOList_OItems_AttributeTypes
                    OList_Objects.Add(New clsOntologyItem With {.GUID = objOItem_AttributeType.ID_OntologyItem, _
                                                                   .Name = objOItem_AttributeType.Name_OntologyItem, _
                                                                   .GUID_Parent = objGlobals.Class_OntologyItems.GUID, _
                                                                   .Type = objGlobals.Type_Object})

                Next

                Dim objOList_OItems_RelationTypes = objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_RelationType).ToList

                For Each objOItem_RelationType In objOList_OItems_RelationTypes
                    OList_Objects.Add(New clsOntologyItem With {.GUID = objOItem_RelationType.ID_OntologyItem, _
                                                                   .Name = objOItem_RelationType.Name_OntologyItem, _
                                                                   .GUID_Parent = objGlobals.Class_OntologyItems.GUID, _
                                                                   .Type = objGlobals.Type_Object})

                Next

                Dim objOList_OItems_Classes = objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_Class).ToList

                For Each objOItem_Class In objOList_OItems_Classes
                    OList_Objects.Add(New clsOntologyItem With {.GUID = objOItem_Class.ID_OntologyItem, _
                                                                   .Name = objOItem_Class.Name_OntologyItem, _
                                                                   .GUID_Parent = objGlobals.Class_OntologyItems.GUID, _
                                                                   .Type = objGlobals.Type_Object})

                Next

                Dim objOList_OItems_Objects = objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_Object).ToList

                For Each objOItem_Object In objOList_OItems_Objects
                    OList_Objects.Add(New clsOntologyItem With {.GUID = objOItem_Object.ID_OntologyItem, _
                                                                   .Name = objOItem_Object.Name_OntologyItem, _
                                                                   .GUID_Parent = objGlobals.Class_OntologyItems.GUID, _
                                                                   .Type = objGlobals.Type_Object})

                Next

                For Each objOntologyJoin In objDataWork_Ontologies.OList_JoinsOfOntologies.Where(Function(p) p.ID_Object = objOItem_Ontology.GUID).ToList
                    OList_Objects.Add(New clsOntologyItem With {.GUID = objOntologyJoin.ID_Other, _
                                                                   .Name = objOntologyJoin.Name_Other, _
                                                                   .GUID_Parent = objOntologyJoin.ID_Parent_Other, _
                                                                   .Type = objGlobals.Type_Object})

                Next
            End If
        End If

        Return objOItem_Result
    End Function

    Public Sub Clear()
        OList_Objects.Clear()
        OList_AttributeTypes.Clear()
        OList_Classes.Clear()
        OList_RelationTypes.Clear()
        objOList_ClassesExtended.Clear()
        objOList_ClassesWithChildren.Clear()
    End Sub

    Public Function Export_Ontology(OItem_Ontology As clsOntologyItem, strPathDst As String, mode As ModeEnum, Optional objDict_XMLTemplates As Dictionary(Of XMLTemplateEnum, String) = Nothing, Optional boolOntology As Boolean = False) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem = objDataWork_Ontologies.LocalConfig.Globals.LState_Error.Clone()


        objOItem_Ontology = OItem_Ontology

        Me.strPathDst = strPathDst
        strFiles = New List(Of String)
        If objDict_XMLTemplates Is Nothing Then
            objDict_XMLTemplates = New Dictionary(Of XMLTemplateEnum, String)

            Dim objAssembly = [Assembly].GetExecutingAssembly()

            Try
                Dim objXMLStream = objAssembly.GetManifestResourceStream("Ontology_Module.OntologyItemContainerTemplate.xml")
                Dim objTextStreamReader = New StreamReader(objXMLStream, True)
                objDict_XMLTemplates(XMLTemplateEnum.ItemContainer) = objTextStreamReader.ReadToEnd()
                objTextStreamReader.Close()

                objXMLStream = objAssembly.GetManifestResourceStream("Ontology_Module.ClassAttItemTemplate.xml")
                objTextStreamReader = New StreamReader(objXMLStream, True)
                objDict_XMLTemplates(XMLTemplateEnum.ClassAtt) = objTextStreamReader.ReadToEnd()
                objTextStreamReader.Close()

                objXMLStream = objAssembly.GetManifestResourceStream("Ontology_Module.ClassRelItemTemplate.xml")
                objTextStreamReader = New StreamReader(objXMLStream, True)
                objDict_XMLTemplates(XMLTemplateEnum.ClassRel) = objTextStreamReader.ReadToEnd()
                objTextStreamReader.Close()

                objXMLStream = objAssembly.GetManifestResourceStream("Ontology_Module.ObjAttItemTemplate.xml")
                objTextStreamReader = New StreamReader(objXMLStream, True)
                objDict_XMLTemplates(XMLTemplateEnum.ObjectAtt) = objTextStreamReader.ReadToEnd()
                objTextStreamReader.Close()

                objXMLStream = objAssembly.GetManifestResourceStream("Ontology_Module.ObjRelItemTemplate.xml")
                objTextStreamReader = New StreamReader(objXMLStream, True)
                objDict_XMLTemplates(XMLTemplateEnum.ObjectRel) = objTextStreamReader.ReadToEnd()
                objTextStreamReader.Close()

                objXMLStream = objAssembly.GetManifestResourceStream("Ontology_Module.OntologyItemTemplate.xml")
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

                If mode.HasFlag(ModeEnum.OntologyStructures) Then
                    objOItem_Result = Export_OntologyStructures(OItem_Ontology, strPathDst, objDict_XMLTemplates)
                End If

                If objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_AttributeType).Any Then
                    OList_AttributeTypes.AddRange(objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_AttributeType).Where(Function(p) Not p.ID_Parent_Ref Is Nothing).Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Ref, _
                                                                                                                                                                                                                                                                                         .Name = p.Name_Ref, _
                                                                                                                                                                                                                                                                                         .GUID_Parent = p.ID_Parent_Ref, _
                                                                                                                                                                                                                                                                                         .Type = objGlobals.Type_Object}))


                End If

                If objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_RelationType).Any Then
                    OList_RelationTypes.AddRange(objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_RelationType).ToList().Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Ref, .Name = p.Name_Ref, _
                                                                                                                                                                                                                                                                                        .GUID_Parent = p.ID_Parent_Ref, _
                                                                                                                                                                                                                                                                                        .Type = objGlobals.Type_Object}))


                End If

                If mode.HasFlag(ModeEnum.AllRelations) Or mode.HasFlag(ModeEnum.OntologyJoins) Or mode.HasFlag(ModeEnum.OntologyItems) Then
                    objOList_ClassesExtended = objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(Function(p) p.ID_Ontology = objOItem_Ontology.GUID And p.Type_Ref = objDataWork_Ontologies.LocalConfig.Globals.Type_Class).ToList()
                    objOList_ClassesWithChildren = objOList_ClassesExtended.Where(Function(p) p.ID_OntologyRelationRule = objOntologyRules.Rule_ChildToken.GUID).GroupBy(Function(p) New With {p.ID_Ref, p.Name_Ref, p.ID_Parent_Ref, p.ID_OntologyRelationRule}).Select(Function(p) New clsOntologyItem With {.GUID_Parent = p.Key.ID_Ref}).ToList()
                    If objOList_ClassesWithChildren.Any() Then
                        OList_Objects.AddRange(objDataWork_OntologyRels.GetData_ObjectsOfClasses(objOList_ClassesWithChildren))
                    End If

                End If


                If OList_Objects.Any Then

                    OList_Classes.AddRange(From objClass In objDataWork_OntologyRels.GetData_ClassesOfObjects(OList_Objects.GroupBy(Function(p) p.GUID_Parent).Select(Function(p) New clsOntologyItem With {.GUID = p.Key}).ToList())
                                                  Group Join objClassExist In OList_Classes On objClass.GUID Equals objClassExist.GUID Into objClassesExist = Group
                                                  From objClassExist In objClassesExist.DefaultIfEmpty()
                                                  Where objClassExist Is Nothing
                                                  Select objClass)

                    'OList_Objects.AddRange(From objObject In OList_Objects
                    '                       Group By objObject.GUID, objObject.Name, objObject.GUID_Parent Into Group
                    '                       Select New clsOntologyItem With {.GUID = GUID, _
                    '                                                        .Name = Name, _
                    '                                                        .GUID_Parent = GUID_Parent, _
                    '                                                        .Type = objGlobals.Type_Object})


                End If
                OList_Classes.AddRange((From objClassNew In objOList_ClassesExtended
                                               Group Join objClass In OList_Classes On objClass.GUID Equals objClassNew.ID_Ref Into objClasses = Group
                                               From objClassOld In objClasses.DefaultIfEmpty()
                                               Where objClassOld Is Nothing
                                               Select New clsOntologyItem With {.GUID = objClassNew.ID_Ref, _
                                                                                .Name = objClassNew.Name_Ref, _
                                                                                .GUID_Parent = objClassNew.ID_Parent_Ref, _
                                                                                .Type = objClassNew.Type_Ref}))
                If OList_Classes.Any Then

                    If mode.HasFlag(ModeEnum.ClassParents) Then
                        Dim intClassCount = 0
                        Do
                            intClassCount = OList_Classes.Count
                            OList_Classes.AddRange(From objClassParent In objDataWork_Ontologies.OList_AllCalsses _
                                                      Join objClassSub In OList_Classes On objClassParent.GUID Equals objClassSub.GUID_Parent _
                                                      Group Join objClassOld In OList_Classes On objClassParent.GUID Equals objClassOld.GUID Into objClassesOld = Group
                                                      From objClassOld In objClassesOld.DefaultIfEmpty()
                                                      Where objClassOld Is Nothing
                                                      Select objClassParent)



                        Loop Until OList_Classes.Count - intClassCount = 0
                    End If
                    OList_Classes = (From objClass In OList_Classes
                                            Group By objClass.GUID, objClass.Name, objClass.GUID_Parent Into Group
                                            Select New clsOntologyItem With {.GUID = GUID, _
                                                .Name = Name, _
                                                .GUID_Parent = GUID_Parent, _
                                                .Type = objGlobals.Type_Object}).ToList()


                End If

                objOItem_Result = export_OntologyRels(strPathDst, mode, objDict_XMLTemplates)

                objOItem_Result = If(objOItem_Result.GUID = objGlobals.LState_Nothing.GUID, objGlobals.LState_Success.Clone(), objOItem_Result)

                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    objOItem_Result = Export_AttributeTypes(objDict_XMLTemplates)
                End If

                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    objOItem_Result = Export_Objects(objDict_XMLTemplates)
                End If

                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    objOItem_Result = Export_RelationTypes(objDict_XMLTemplates)
                End If

                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    objOItem_Result = Export_Classes(objDict_XMLTemplates)
                End If

                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    objOItem_Result = Export_ClassAtt(objDict_XMLTemplates)
                End If

                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    objOItem_Result = Export_ClassRel(objDict_XMLTemplates)
                End If

                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    objOItem_Result = Export_ObjectAtt(objDict_XMLTemplates)
                End If

                If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
                    objOItem_Result = Export_ObjectRel(objDict_XMLTemplates)
                End If
            End If


        End If


        Return objOItem_Result
    End Function
    Private Function Export_Objects(objDict_XMLTemplates As Dictionary(Of XMLTemplateEnum, String)) As clsOntologyItem
        Dim strFileName = strPathDst & "\" & "Objects.xml"
        strFiles.Add(strFileName)
        Dim objOItem_Result = Open_XMLWriter(strFileName)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then


            Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
            strOutput = strOutput.Replace("@" & objVariables.Variable_ITEMTYPE.Name & "@", objGlobals.Type_Object)
            objTextWriter.Write(strOutput)


            For Each objOItem_Object In OList_Objects
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

        Return objOItem_Result
    End Function

    Private Function Export_AttributeTypes(objDict_XMLTemplates As Dictionary(Of XMLTemplateEnum, String)) As clsOntologyItem
        Dim strFileName = strPathDst & "\" & "AttributeTypes.xml"
        strFiles.Add(strFileName)
        Dim objOItem_Result = Open_XMLWriter(strFileName)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
            strOutput = strOutput.Replace("@" & objVariables.Variable_ITEMTYPE.Name & "@", objGlobals.Type_AttributeType)
            objTextWriter.Write(strOutput)

            For Each objOItem_AttributeType In OList_AttributeTypes
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

        Return objOItem_Result
    End Function

    Private Function Export_RelationTypes(objDict_XMLTemplates As Dictionary(Of XMLTemplateEnum, String)) As clsOntologyItem
        Dim strFileName = strPathDst & "\" & "RelationTypes.xml"
        strFiles.Add(strFileName)
        Dim objOItem_Result = Open_XMLWriter(strFileName)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
            strOutput = strOutput.Replace("@" & objVariables.Variable_ITEMTYPE.Name & "@", objGlobals.Type_RelationType)
            objTextWriter.Write(strOutput)

            For Each objOItem_RelationType In OList_RelationTypes
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

        Return objOItem_Result
    End Function

    Private Function Export_Classes(objDict_XMLTemplates As Dictionary(Of XMLTemplateEnum, String)) As clsOntologyItem
        Dim strFileName = strPathDst & "\" & "Classes.xml"
        strFiles.Add(strFileName)
        Dim objOItem_Result = Open_XMLWriter(strFileName)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
            strOutput = strOutput.Replace("@" & objVariables.Variable_ITEMTYPE.Name & "@", objGlobals.Type_Class)
            objTextWriter.Write(strOutput)



            For Each objOItem_Classes In OList_Classes
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

        Return objOItem_Result
    End Function

    Private Function Export_ClassAtt(objDict_XMLTemplates As Dictionary(Of XMLTemplateEnum, String)) As clsOntologyItem
        Dim strFileName = strPathDst & "\" & "ClassAtts.xml"
        strFiles.Add(strFileName)
        Dim objOItem_Result = Open_XMLWriter(strFileName)
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
        Return objOItem_Result
    End Function

    Private Function Export_ClassRel(objDict_XMLTemplates As Dictionary(Of XMLTemplateEnum, String)) As clsOntologyItem
        Dim strFileName = strPathDst & "\" & "ClassRels.xml"
        strFiles.Add(strFileName)
        Dim objOItem_Result = Open_XMLWriter(strFileName)
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

        Return objOItem_Result
    End Function

    Private Function Export_ObjectAtt(objDict_XMLTemplates As Dictionary(Of XMLTemplateEnum, String)) As clsOntologyItem
        Dim strFileName = strPathDst & "\" & "ObjectAtt.xml"
        strFiles.Add(strFileName)
        Dim objOItem_Result = Open_XMLWriter(strFileName)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
            strOutput = strOutput.Replace("@" & objVariables.Variable_ITEMTYPE.Name & "@", objGlobals.Type_ObjectAtt)
            objTextWriter.Write(strOutput)

            Dim objOList_OAtt = (From objObjAtt In objDataWork_OntologyRels.ObjectAtt
                                    Join objObject In OList_Objects On objObjAtt.ID_Object Equals objObject.GUID
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

        Return objOItem_Result
    End Function

    Private Function Export_ObjectRel(objDict_XMLTemplates As Dictionary(Of XMLTemplateEnum, String)) As clsOntologyItem
        Dim strFileName = strPathDst & "\" & "ObjectRel.xml"
        strFiles.Add(strFileName)
        Dim objOItem_Result = Open_XMLWriter(strFileName)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            Dim strOutput = objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).Substring(0, objDict_XMLTemplates(XMLTemplateEnum.ItemContainer).IndexOf("@" & objVariables.Variable_ITEMLIST.Name & "@"))
            strOutput = strOutput.Replace("@" & objVariables.Variable_ITEMTYPE.Name & "@", objGlobals.Type_ObjectRel)
            objTextWriter.Write(strOutput)

            Dim objOList_ORel = (From objObjRel In objDataWork_OntologyRels.ObjectRel
                                    Join objObject In OList_Objects On objObjRel.ID_Object Equals objObject.GUID
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

        Return objOItem_Result
    End Function

    Private Function export_OntologyRels(strPathDst As String, mode As ModeEnum, objDict_XMLTemplates As Dictionary(Of XMLTemplateEnum, String)) As clsOntologyItem
        Dim objOItem_Result = objGlobals.LState_Nothing
        If mode.HasFlag(ModeEnum.AllRelations) = True Then

            objDataWork_OntologyRels.OList_Classes = OList_Classes
            objDataWork_OntologyRels.OList_AttributeTypes = OList_AttributeTypes
            objDataWork_OntologyRels.OList_RelationTypes = OList_RelationTypes

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


                            'OList_Objects.AddRange(From objObject In (From objObjRel In objDataWork_OntologyRels.ObjectRel
                            '                        Join objObject In OList_Objects On objObjRel.ID_Object Equals objObject.GUID
                            '                        Where objObjRel.Ontology = objGlobals.Type_Object
                            '                        Group Join objObjectOld In OList_Objects On objObjectOld.GUID Equals objObjRel.ID_Other Into objObjects = Group
                            '                        From objObjectOld In objObjects.DefaultIfEmpty()
                            '                        Where objObjectOld Is Nothing
                            '                        Select objObjRel).ToList()
                            '                     Group By objObject.ID_Other, objObject.Name_Other, objObject.ID_Parent_Other Into Group
                            '                     Select New clsOntologyItem With {.GUID = ID_Other, _
                            '                                                      .Name = Name_Other, _
                            '                                                      .GUID_Parent = ID_Parent_Other, _
                            '                                                      .Type = objGlobals.Type_Object})

                            OList_Objects.AddRange(From objObject In (From objObjRel In OList_ObjectRel
                                                    Join objObject In OList_Objects On objObjRel.ID_Object Equals objObject.GUID
                                                    Where objObjRel.Ontology = objGlobals.Type_Object
                                                    Group Join objObjectOld In OList_Objects On objObjectOld.GUID Equals objObjRel.ID_Other Into objObjects = Group
                                                    From objObjectOld In objObjects.DefaultIfEmpty()
                                                    Where objObjectOld Is Nothing
                                                    Select objObjRel).ToList()
                                                 Group By objObject.ID_Other, objObject.Name_Other, objObject.ID_Parent_Other Into Group
                                                 Select New clsOntologyItem With {.GUID = ID_Other, _
                                                                                  .Name = Name_Other, _
                                                                                  .GUID_Parent = ID_Parent_Other, _
                                                                                  .Type = objGlobals.Type_Object})

                            OList_Classes.AddRange(From objClass In objDataWork_OntologyRels.GetData_ClassesOfObjects(OList_Objects.GroupBy(Function(p) p.GUID_Parent).Select(Function(p) New clsOntologyItem With {.GUID = p.Key}).ToList())
                                                  Group Join objClassExist In OList_Classes On objClass.GUID Equals objClassExist.GUID Into objClassesExist = Group
                                                  From objClassExist In objClassesExist.DefaultIfEmpty()
                                                  Where objClassExist Is Nothing
                                                  Select objClass)

                            OList_Classes.AddRange(From objObject In (From objObjRel In objDataWork_OntologyRels.ObjectRel
                                                    Join objObject In OList_Objects On objObjRel.ID_Object Equals objObject.GUID
                                                    Where objObjRel.Ontology = objGlobals.Type_Class
                                                    Group Join objObjectOld In OList_Classes On objObjectOld.GUID Equals objObjRel.ID_Other Into objObjects = Group
                                                    From objObjectOld In objObjects.DefaultIfEmpty()
                                                    Where objObjectOld Is Nothing
                                                    Select objObjRel).ToList()
                                                 Group By objObject.ID_Other, objObject.Name_Other, objObject.ID_Parent_Other Into Group
                                                 Select New clsOntologyItem With {.GUID = ID_Other, _
                                                                                  .Name = Name_Other, _
                                                                                  .GUID_Parent = ID_Parent_Other, _
                                                                                  .Type = objGlobals.Type_Object})

                            OList_Classes.AddRange(From objClassParent In objDataWork_Ontologies.OList_AllCalsses _
                                                      Join objClassSub In OList_Classes On objClassParent.GUID Equals objClassSub.GUID_Parent _
                                                      Group Join objClassOld In OList_Classes On objClassParent.GUID Equals objClassOld.GUID Into objClassesOld = Group
                                                      From objClassOld In objClassesOld.DefaultIfEmpty()
                                                      Where objClassOld Is Nothing
                                                      Select objClassParent)

                            OList_RelationTypes.AddRange(From objObject In (From objObjRel In objDataWork_OntologyRels.ObjectRel
                                                    Join objObject In OList_Objects On objObjRel.ID_Object Equals objObject.GUID
                                                    Where objObjRel.Ontology = objGlobals.Type_RelationType
                                                    Group Join objObjectOld In OList_RelationTypes On objObjectOld.GUID Equals objObjRel.ID_Other Into objObjects = Group
                                                    From objObjectOld In objObjects.DefaultIfEmpty()
                                                    Where objObjectOld Is Nothing
                                                    Select objObjRel).ToList()
                                                 Group By objObject.ID_Other, objObject.Name_Other, objObject.ID_Parent_Other Into Group
                                                 Select New clsOntologyItem With {.GUID = ID_Other, _
                                                                                  .Name = Name_Other, _
                                                                                  .GUID_Parent = ID_Parent_Other, _
                                                                                  .Type = objGlobals.Type_Object})

                            OList_AttributeTypes.AddRange(From objObject In (From objObjRel In objDataWork_OntologyRels.ObjectRel
                                                    Join objObject In OList_Objects On objObjRel.ID_Object Equals objObject.GUID
                                                    Where objObjRel.Ontology = objGlobals.Type_AttributeType
                                                    Group Join objObjectOld In OList_AttributeTypes On objObjectOld.GUID Equals objObjRel.ID_Other Into objObjects = Group
                                                    From objObjectOld In objObjects.DefaultIfEmpty()
                                                    Where objObjectOld Is Nothing
                                                    Select objObjRel).ToList()
                                                 Group By objObject.ID_Other, objObject.Name_Other, objObject.ID_Parent_Other Into Group
                                                 Select New clsOntologyItem With {.GUID = ID_Other, _
                                                                                  .Name = Name_Other, _
                                                                                  .GUID_Parent = ID_Parent_Other, _
                                                                                  .Type = objGlobals.Type_Object})
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

