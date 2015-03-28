Imports Ontology_Module
Imports System.Xml
Imports OntologyClasses.BaseClasses
Public Class clsDataWork_CodeGenerator
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_XML As clsDBLevel
    Private objDBLevel_CodeTemplateRel As clsDBLevel
    Private objDBLevel_CodeTemplateAtt As clsDBLevel
    Private objDBLevel_SyntaxHighlight As clsDBLevel
    Private strXML_Declaration As String
    Private strXML_Property As String
    Private strXML_Declaration_List As String
    Private strXML_Property_List As String
    Private strXML_Initialization_Attribute As String
    Private strXML_Initialization_Token As String
    Private strXML_Initialization_Type As String
    Private strXML_Initialization_RelationType As String
    Private strList_Initialization_Attribute As String
    Private strList_Initialization_RelationType As String
    Private strList_Initialization_Object As String
    Private strList_Initialization_Class As String

    Public Property OList_CodeTemplates As New List(Of clsCodeTemplate)

    Public Function GetSyntaxHighlight(ID_ProgramingLanguage As String) As clsOntologyItem
        Return objDBLevel_SyntaxHighlight.OList_ObjectRel.Where(Function(synt) synt.ID_Other = ID_ProgramingLanguage).Select(Function(synt) New clsOntologyItem With
                                                                                                                                                       {
                                                                                                                                                           .GUID = synt.ID_Object,
                                                                                                                                                           .Name = synt.Name_Object,
                                                                                                                                                           .GUID_Parent = synt.ID_Parent_Object,
                                                                                                                                                           .Type = objLocalConfig.Globals.Type_Object
                                                                                                                                                        }).FirstOrDefault()

    End Function

    Public Function Get_CodeTemplates() As clsOntologyItem
        Dim objOList_CodeTemplates As New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Class_Code_Template.GUID, _
                                                                                             .ID_RelationType = objLocalConfig.OItem_relationtype_declaration.GUID, _
                                                                                             .ID_Parent_Other = objLocalConfig.OItem_Class_XML.GUID}, _
                                                                      New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Class_Code_Template.GUID, _
                                                                                             .ID_RelationType = objLocalConfig.OItem_relationtype_document_container.GUID, _
                                                                                             .ID_Parent_Other = objLocalConfig.OItem_Class_XML.GUID}, _
                                                                      New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Class_Code_Template.GUID, _
                                                                                             .ID_RelationType = objLocalConfig.OItem_relationtype_attribute.GUID, _
                                                                                             .ID_Parent_Other = objLocalConfig.OItem_Class_XML.GUID}, _
                                                                      New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Class_Code_Template.GUID, _
                                                                                             .ID_RelationType = objLocalConfig.OItem_relationtype_property.GUID, _
                                                                                             .ID_Parent_Other = objLocalConfig.OItem_Class_XML.GUID}, _
                                                                      New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Class_Code_Template.GUID, _
                                                                                             .ID_RelationType = objLocalConfig.OItem_relationtype_object.GUID, _
                                                                                             .ID_Parent_Other = objLocalConfig.OItem_Class_XML.GUID}, _
                                                                      New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Class_Code_Template.GUID, _
                                                                                             .ID_RelationType = objLocalConfig.OItem_relationtype_class.GUID, _
                                                                                             .ID_Parent_Other = objLocalConfig.OItem_Class_XML.GUID}, _
                                                                      New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Class_Code_Template.GUID, _
                                                                                             .ID_RelationType = objLocalConfig.OItem_relationtype_relationtype.GUID, _
                                                                                             .ID_Parent_Other = objLocalConfig.OItem_Class_XML.GUID}, _
                                                                      New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Class_Code_Template.GUID, _
                                                                                             .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                                                             .ID_Parent_Other = objLocalConfig.OItem_Class_ProgramingLanguage.GUID}}

        Dim objOItem_Result = objDBLevel_CodeTemplateRel.get_Data_ObjectRel(objOList_CodeTemplates, boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_CodeTemplateRel.OList_ObjectRel.Any Then
                Dim searchSyntaxHighlight = New List(Of clsObjectRel) From
                    {
                        New clsObjectRel With
                            {
                                .ID_Parent_Object = objLocalConfig.OItem_class_syntax_highlighting__scintillanet_.GUID,
                                .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID,
                                .ID_Parent_Other = objLocalConfig.OItem_Class_ProgramingLanguage.GUID
                            }
                    }

                objOItem_Result = objDBLevel_SyntaxHighlight.get_Data_ObjectRel(searchSyntaxHighlight, boolIDs:=False)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Dim objOList_CodeTemplate_Standard = New List(Of clsObjectAtt) From {New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Standard.GUID, _
                                                                                                            .ID_Class = objLocalConfig.OItem_Class_Code_Template.GUID}}

                    objOItem_Result = objDBLevel_CodeTemplateAtt.get_Data_ObjectAtt(objOList_CodeTemplate_Standard, boolIDs:=False)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        If objDBLevel_CodeTemplateAtt.OList_ObjectAtt.Any Then
                            Dim objOList_XML_XMLText = (From objXML In objDBLevel_CodeTemplateRel.OList_ObjectRel.Where(Function(p) p.ID_Parent_Other = objLocalConfig.OItem_Class_XML.GUID).ToList()
                                                       Select New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_XML_Text.GUID, _
                                                                                     .ID_Object = objXML.ID_Other}).ToList()

                            objOItem_Result = objDBLevel_XML.get_Data_ObjectAtt(objOList_XML_XMLText, boolIDs:=False)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                If objDBLevel_XML.OList_ObjectAtt.Any Then
                                    Dim objLCodeTemplates = (From objCodeTemplate In objDBLevel_CodeTemplateRel.OList_ObjectRel
                                                             Group By objCodeTemplate.ID_Object, objCodeTemplate.Name_Object, objCodeTemplate.ID_Parent_Object Into Group).ToList()


                                    Dim objLXML = (From objXml In objDBLevel_CodeTemplateRel.OList_ObjectRel.Where(Function(p) p.ID_Parent_Other = objLocalConfig.OItem_Class_XML.GUID) _
                                                  .Select(Function(p) New With {.ID_Object = p.ID_Object, _
                                                                                .ID_RelationType = p.ID_RelationType, _
                                                                                .ID_Other = p.ID_Other, _
                                                                                .Name_Other = p.Name_Other, _
                                                                                .ID_Parent_Other = p.ID_Parent_Other}).ToList()
                                                   Join objXMLText In objDBLevel_XML.OList_ObjectAtt On objXml.ID_Other Equals objXMLText.ID_Object
                                                   Select objXml.ID_Object, _
                                                          objXml.ID_RelationType, _
                                                          objXml.ID_Other, _
                                                          objXml.Name_Other, _
                                                          objXml.ID_Parent_Other, _
                                                          objXMLText.ID_Attribute, _
                                                          objXMLText.Val_String).ToList()

                                    Dim objLStandard = objDBLevel_CodeTemplateAtt.OList_ObjectAtt

                                    Dim objLProgramingLanguage = objDBLevel_CodeTemplateRel.OList_ObjectRel.Where(Function(p) p.ID_Parent_Other = objLocalConfig.OItem_Class_ProgramingLanguage.GUID).ToList()




                                    OList_CodeTemplates = (From objCodeTemplate In objLCodeTemplates
                                                           Join objXML_Declaration In objLXML.Where(Function(p) p.ID_RelationType = objLocalConfig.OItem_relationtype_declaration.GUID).ToList() On objCodeTemplate.ID_Object Equals objXML_Declaration.ID_Object
                                                           Join objXML_DocumentContainer In objLXML.Where(Function(p) p.ID_RelationType = objLocalConfig.OItem_relationtype_document_container.GUID).ToList() On objCodeTemplate.ID_Object Equals objXML_DocumentContainer.ID_Object
                                                           Join objXML_Attribute In objLXML.Where(Function(p) p.ID_RelationType = objLocalConfig.OItem_relationtype_attribute.GUID).ToList() On objCodeTemplate.ID_Object Equals objXML_Attribute.ID_Object
                                                           Join objXML_Property In objLXML.Where(Function(p) p.ID_RelationType = objLocalConfig.OItem_relationtype_property.GUID).ToList() On objCodeTemplate.ID_Object Equals objXML_Property.ID_Object
                                                           Join objXML_Object In objLXML.Where(Function(p) p.ID_RelationType = objLocalConfig.OItem_relationtype_object.GUID).ToList() On objCodeTemplate.ID_Object Equals objXML_Object.ID_Object
                                                           Join objXML_Class In objLXML.Where(Function(p) p.ID_RelationType = objLocalConfig.OItem_relationtype_class.GUID).ToList() On objCodeTemplate.ID_Object Equals objXML_Class.ID_Object
                                                           Join objXML_RelationType In objLXML.Where(Function(p) p.ID_RelationType = objLocalConfig.OItem_relationtype_relationtype.GUID).ToList() On objCodeTemplate.ID_Object Equals objXML_RelationType.ID_Object
                                                           Join objStandard In objLStandard On objCodeTemplate.ID_Object Equals objStandard.ID_Object
                                                           Join objProgramingLanguage In objLProgramingLanguage On objCodeTemplate.ID_Object Equals objProgramingLanguage.ID_Object
                                                           Select New clsCodeTemplate With {.ID_CodeTemplate = objCodeTemplate.ID_Object, _
                                                                                            .Name_CodeTemplate = objCodeTemplate.Name_Object, _
                                                                                            .ID_Attribute_Standard = objStandard.ID_Attribute, _
                                                                                            .Standard = objStandard.Val_Bit, _
                                                                                            .ID_ProgramingLanguage = objProgramingLanguage.ID_Other, _
                                                                                            .Name_ProgramingLanguage = objProgramingLanguage.Name_Other, _
                                                                                            .ID_XML_Attribute = objXML_Attribute.ID_Other, _
                                                                                            .Name_XML_Attribute = objXML_Attribute.Name_Other, _
                                                                                            .ID_Attribute_XML_Attribute = objXML_Attribute.ID_Attribute, _
                                                                                            .XML_Attribute = objXML_Attribute.Val_String, _
                                                                                            .ID_XML_Class = objXML_Class.ID_Other, _
                                                                                            .Name_XML_Class = objXML_Class.Name_Other, _
                                                                                            .ID_Attribute_XML_Class = objXML_Class.ID_Attribute, _
                                                                                            .XML_Class = objXML_Class.Val_String, _
                                                                                            .ID_XML_Declaration = objXML_Declaration.ID_Other, _
                                                                                            .Name_XML_Declaration = objXML_Declaration.Name_Other, _
                                                                                            .ID_Attribute_XML_Declaration = objXML_Declaration.ID_Attribute, _
                                                                                            .XML_Declaration = objXML_Declaration.Val_String, _
                                                                                            .ID_XML_DocumentContainer = objXML_DocumentContainer.ID_Other, _
                                                                                            .Name_XML_DocumentContainer = objXML_DocumentContainer.Name_Other, _
                                                                                            .ID_Attribute_XML_DocumentContainer = objXML_DocumentContainer.ID_Attribute, _
                                                                                            .XML_DocumentContainer = objXML_DocumentContainer.Val_String, _
                                                                                            .ID_XML_Object = objXML_Object.ID_Other, _
                                                                                            .Name_XML_Object = objXML_Object.Name_Other, _
                                                                                            .ID_Attribute_XML_Object = objXML_Object.ID_Attribute, _
                                                                                            .XML_Object = objXML_Object.Val_String, _
                                                                                            .ID_XML_Property = objXML_Property.ID_Other, _
                                                                                            .Name_XML_Property = objXML_Property.Name_Other, _
                                                                                            .ID_Attribute_XML_Property = objXML_Property.ID_Attribute, _
                                                                                            .XML_Property = objXML_Property.Val_String, _
                                                                                            .ID_XML_RelationType = objXML_RelationType.ID_Other, _
                                                                                            .Name_XML_RelationType = objXML_RelationType.Name_Other, _
                                                                                            .ID_Attribute_XML_RelationType = objXML_RelationType.ID_Attribute, _
                                                                                            .XML_RelationType = objXML_RelationType.Val_String}).ToList()


                                Else
                                    objOItem_Result = objLocalConfig.Globals.LState_Error
                                End If
                            End If
                        Else
                            objOItem_Result = objLocalConfig.Globals.LState_Error
                        End If
                    End If
                End If
                
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Error
            End If
        End If

        Return objOItem_Result
    End Function

    'Public Function get_XML(ByVal objOItem_XML As clsOntologyItem, ByVal objOItem_Development As clsOntologyItem) As String
    '    Dim objXMLDocument As XmlDocument
    '    Dim objXMLElement As XmlElement
    '    Dim strXML As String

    '    Dim objLXMLText As New List(Of clsObjectAtt)

    '    objLXMLText.Add(New clsObjectAtt(Nothing, _
    '                                     objOItem_XML.GUID, _
    '                                     Nothing, _
    '                                     objLocalConfig.OItem_Attribute_XML_Text.GUID, _
    '                                     Nothing))

    '    objDBLevel_XML.get_Data_ObjectAtt(objLXMLText, _
    '                                      boolIDs:=False)

    '    strXML = Nothing

    '    If objDBLevel_XML.OList_ObjectAtt.Count > 0 Then
    '        strXML = objDBLevel_XML.OList_ObjectAtt(0).Val_String

    '        objXMLDocument = New Xml.XmlDocument
    '        objXMLDocument.LoadXml(strXML)

    '        objXMLElement = objXMLDocument.GetElementsByTagName("data")(0)

    '        strXML = objXMLElement.InnerText

    '    End If

    '    Return strXML
    'End Function

    Public Function get_XML(strXMLDoc) As String
        Dim objXMLDocument As XmlDocument
        Dim objXMLElement As XmlElement
        Dim strXML As String

        objXMLDocument = New Xml.XmlDocument
        objXMLDocument.LoadXml(strXMLDoc)

        objXMLElement = objXMLDocument.GetElementsByTagName("data")(0)

        strXML = objXMLElement.InnerText

        Return strXML
    End Function

    Public Function get_Code(ByVal objOItem_Development As clsOntologyItem, objOItem_CodeTemplates As clsCodeTemplate, ByVal objDGVR As DataGridViewRowCollection, objDGVSR As DataGridViewSelectedRowCollection) As String
        Dim strXML_Config As String

        Dim objDGVR_Selected As DataGridViewRow

        Dim strCode As String

        strCode = Nothing

        strXML_Config = get_XML(objOItem_CodeTemplates.XML_DocumentContainer)
        If Not strXML_Config Is Nothing Then
            strXML_Declaration = get_XML(objOItem_CodeTemplates.XML_Declaration)
            If Not strXML_Declaration Is Nothing Then
                strXML_Property = get_XML(objOItem_CodeTemplates.XML_Property)
                If Not strXML_Property Is Nothing Then
                    strXML_Initialization_Attribute = get_XML(objOItem_CodeTemplates.XML_Attribute)
                    If Not strXML_Initialization_Attribute Is Nothing Then
                        strXML_Initialization_Token = get_XML(objOItem_CodeTemplates.XML_Object)
                        If Not strXML_Initialization_Token Is Nothing Then
                            strXML_Initialization_Type = get_XML(objOItem_CodeTemplates.XML_Class)
                            If Not strXML_Initialization_Type Is Nothing Then
                                strXML_Initialization_RelationType = get_XML(objOItem_CodeTemplates.XML_RelationType)
                                If Not strXML_Initialization_Type Is Nothing Then
                                    strXML_Config = strXML_Config.Replace("@GUID_Development@", objOItem_Development.GUID)
                                    strXML_Declaration_List = ""
                                    strXML_Property_List = ""
                                    strList_Initialization_Attribute = ""
                                    strList_Initialization_Class = ""
                                    strList_Initialization_Object = ""
                                    strList_Initialization_RelationType = ""

                                    If Not objDGVR Is Nothing Then

                                        For Each objDGVR_Selected In objDGVR
                                            Dim objOItemOfOntology As clsOntologyItemsOfOntologies = objDGVR_Selected.DataBoundItem
                                            get_XML_ConfigItem(objOItemOfOntology)
                                        Next

                                    Else
                                        For Each objDGVR_Selected In objDGVSR
                                            Dim objOItemOfOntology As clsOntologyItemsOfOntologies = objDGVR_Selected.DataBoundItem
                                            get_XML_ConfigItem(objOItemOfOntology)
                                        Next
                                    End If
                                End If

                                strCode = strXML_Config.Replace("@" & objLocalConfig.Oitem_Object_Variable_List_Initialize_ConfigItems_Attributes.Name & "@", strList_Initialization_Attribute)
                                strCode = strCode.Replace("@" & objLocalConfig.Oitem_Object_Variable_List_Initialize_ConfigItems_RelationTypes.Name & "@", strList_Initialization_RelationType)
                                strCode = strCode.Replace("@" & objLocalConfig.Oitem_Object_Variable_List_Initialize_ConfigItems_Object.Name & "@", strList_Initialization_Object)
                                strCode = strCode.Replace("@" & objLocalConfig.Oitem_Object_Variable_List_Initialize_ConfigItems_Types.Name & "@", strList_Initialization_Class)

                                strCode = strCode.Replace("@" & objLocalConfig.Oitem_Object_Variable_List_Declaration_ConfigItems.Name & "@", strXML_Declaration_List)
                                strCode = strCode.Replace("@" & objLocalConfig.Oitem_Object_Variable_List_Properties.Name & "@", strXML_Property_List)


                            End If

                        End If
                    End If

                End If
            End If
        End If

        Return strCode
    End Function

    Private Sub get_XML_ConfigItem(ByVal objOItemOfOntology As clsOntologyItemsOfOntologies)
        strXML_Declaration_List = strXML_Declaration_List & strXML_Declaration.Replace("@" & objLocalConfig.OItem_Token_Variable_Name_ConfigItem.Name & "@", objOItemOfOntology.Name_OntologyItem.ToLower) & vbCrLf
        strXML_Property_List = strXML_Property_List & strXML_Property.Replace("@" & objLocalConfig.OItem_Token_Variable_Name_ConfigItem.Name & "@", objOItemOfOntology.Name_OntologyItem.ToLower) & vbCrLf & vbCrLf

        Select Case objOItemOfOntology.Type_Ref
            Case objLocalConfig.Globals.Type_AttributeType
                strList_Initialization_Attribute = strList_Initialization_Attribute & strXML_Initialization_Attribute.Replace("@" & objLocalConfig.OItem_Token_Variable_Name_ConfigItem.Name & "@", objOItemOfOntology.Name_OntologyItem.ToLower) & vbCrLf & vbCrLf

            Case objLocalConfig.Globals.Type_RelationType
                strList_Initialization_RelationType = strList_Initialization_RelationType & strXML_Initialization_RelationType.Replace("@" & objLocalConfig.OItem_Token_Variable_Name_ConfigItem.Name & "@", objOItemOfOntology.Name_OntologyItem.ToLower) & vbCrLf & vbCrLf

            Case objLocalConfig.Globals.Type_Object
                strList_Initialization_Object = strList_Initialization_Object & strXML_Initialization_Token.Replace("@" & objLocalConfig.OItem_Token_Variable_Name_ConfigItem.Name & "@", objOItemOfOntology.Name_OntologyItem.ToLower) & vbCrLf & vbCrLf

            Case objLocalConfig.Globals.Type_Class
                strList_Initialization_Class = strList_Initialization_Class & strXML_Initialization_Type.Replace("@" & objLocalConfig.OItem_Token_Variable_Name_ConfigItem.Name & "@", objOItemOfOntology.Name_OntologyItem.ToLower) & vbCrLf & vbCrLf

        End Select
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_XML = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_CodeTemplateRel = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_CodeTemplateAtt = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_SyntaxHighlight = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
