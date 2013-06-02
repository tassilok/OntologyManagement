Imports Ontolog_Module
Imports System.Xml
Public Class clsDataWork_CodeGenerator
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_XML As clsDBLevel
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

    Public Function get_XML(ByVal objOItem_XML As clsOntologyItem, ByVal objOItem_Development As clsOntologyItem) As String
        Dim objXMLDocument As XmlDocument
        Dim objXMLElement As XmlElement
        Dim strXML As String

        Dim objLXMLText As New List(Of clsObjectAtt)

        objLXMLText.Add(New clsObjectAtt(Nothing, _
                                         objOItem_XML.GUID, _
                                         Nothing, _
                                         objLocalConfig.OItem_Attribute_XML_Text.GUID, _
                                         Nothing))

        objDBLevel_XML.get_Data_ObjectAtt(objLXMLText, _
                                          boolIDs:=False)

        strXML = Nothing

        If objDBLevel_XML.OList_ObjectAtt.Count > 0 Then
            strXML = objDBLevel_XML.OList_ObjectAtt(0).Val_String

            objXMLDocument = New Xml.XmlDocument
            objXMLDocument.LoadXml(strXML)

            objXMLElement = objXMLDocument.GetElementsByTagName("data")(0)

            strXML = objXMLElement.InnerText

        End If

        Return strXML
    End Function

    Public Function get_Code(ByVal objOItem_Development As clsOntologyItem, ByVal objDGV As DataGridView) As String
        Dim strXML_Config As String

        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView

        Dim strCode As String

        strCode = Nothing

        strXML_Config = get_XML(objLocalConfig.OItem_Token_XML_clsLocalConfig_ontology_xml, objOItem_Development)
        If Not strXML_Config Is Nothing Then
            strXML_Declaration = get_XML(objLocalConfig.OItem_Token_XML_Declaration_Ontology_Configitems, objOItem_Development)
            If Not strXML_Declaration Is Nothing Then
                strXML_Property = get_XML(objLocalConfig.OItem_Token_XML_Property_Ontology_ConfigItem, objOItem_Development)
                If Not strXML_Property Is Nothing Then
                    strXML_Initialization_Attribute = get_XML(objLocalConfig.OItem_Token_XML_Initilize_Attribute__ConfigItem_Ontology_, objOItem_Development)
                    If Not strXML_Initialization_Attribute Is Nothing Then
                        strXML_Initialization_Token = get_XML(objLocalConfig.OItem_Token_XML_Initialize_Token__ConfigItem_Ontology_, objOItem_Development)
                        If Not strXML_Initialization_Token Is Nothing Then
                            strXML_Initialization_Type = get_XML(objLocalConfig.OItem_Token_XML_Initilize_Type__ConfigItem_Ontology_, objOItem_Development)
                            If Not strXML_Initialization_Type Is Nothing Then
                                strXML_Initialization_RelationType = get_XML(objLocalConfig.OItem_Token_XML_Initialize_RelationType__ConfigItem_Ontology_, objOItem_Development)
                                If Not strXML_Initialization_Type Is Nothing Then
                                    strXML_Config = strXML_Config.Replace("@GUID_Development@", objOItem_Development.GUID)
                                    strXML_Declaration_List = ""
                                    strXML_Property_List = ""
                                    strList_Initialization_Attribute = ""
                                    strList_Initialization_Class = ""
                                    strList_Initialization_Object = ""
                                    strList_Initialization_RelationType = ""

                                    If objDGV.SelectedRows.Count > 0 Then
                                        If objDGV.SelectedRows.Count = 0 Then
                                            For Each objDGVR_Selected In objDGV.Rows
                                                objDRV_Selected = objDGVR_Selected.DataBoundItem
                                                get_XML_ConfigItem(objDRV_Selected)

                                            Next
                                        Else
                                            For Each objDGVR_Selected In objDGV.SelectedRows
                                                objDRV_Selected = objDGVR_Selected.DataBoundItem
                                                get_XML_ConfigItem(objDRV_Selected)
                                            Next
                                        End If
                                        
                                    Else
                                        For Each objDGVR_Selected In objDGV.Rows
                                            objDRV_Selected = objDGVR_Selected.DataBoundItem
                                            get_XML_ConfigItem(objDRV_Selected)
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

    Private Sub get_XML_ConfigItem(ByVal objDRV_ConfigItem As DataRowView)
        strXML_Declaration_List = strXML_Declaration_List & strXML_Declaration.Replace("@" & objLocalConfig.OItem_Token_Variable_Name_ConfigItem.Name & "@", objDRV_ConfigItem.Item("Name_ConfigItem")) & vbCrLf
        strXML_Property_List = strXML_Property_List & strXML_Property.Replace("@" & objLocalConfig.OItem_Token_Variable_Name_ConfigItem.Name & "@", objDRV_ConfigItem.Item("Name_ConfigItem")) & vbCrLf & vbCrLf

        Select Case objDRV_ConfigItem.Item("Ontology")
            Case objLocalConfig.Globals.Type_AttributeType
                strList_Initialization_Attribute = strList_Initialization_Attribute & strXML_Initialization_Attribute.Replace("@" & objLocalConfig.OItem_Token_Variable_Name_ConfigItem.Name & "@", objDRV_ConfigItem.Item("Name_ConfigItem").ToString.ToLower) & vbCrLf & vbCrLf

            Case objLocalConfig.Globals.Type_RelationType
                strList_Initialization_RelationType = strList_Initialization_RelationType & strXML_Initialization_RelationType.Replace("@" & objLocalConfig.OItem_Token_Variable_Name_ConfigItem.Name & "@", objDRV_ConfigItem.Item("Name_ConfigItem").ToString.ToLower) & vbCrLf & vbCrLf

            Case objLocalConfig.Globals.Type_Object
                strList_Initialization_Object = strList_Initialization_Object & strXML_Initialization_Token.Replace("@" & objLocalConfig.OItem_Token_Variable_Name_ConfigItem.Name & "@", objDRV_ConfigItem.Item("Name_ConfigItem").ToString.ToLower) & vbCrLf & vbCrLf

            Case objLocalConfig.Globals.Type_Class
                strList_Initialization_Class = strList_Initialization_Class & strXML_Initialization_Type.Replace("@" & objLocalConfig.OItem_Token_Variable_Name_ConfigItem.Name & "@", objDRV_ConfigItem.Item("Name_ConfigItem").ToString.ToLower) & vbCrLf & vbCrLf

        End Select
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_XML = New clsDBLevel(objLocalConfig.Globals)

    End Sub
End Class
