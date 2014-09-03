Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class clsLocalizeGui
    Private localConfig As IGuiLocalization

    Private objDBLevel_GuiItems_L1 As clsDBLevel
    Private objDBLevel_GuiItems_L2 As clsDBLevel
    Private objDBLevel_GuiCaption As clsDBLevel
    Private objDBLevel_ToolTips As clsDBLevel
    Private objDBLevel_Messages As clsDBLevel
    Private objDBLevel_LocalizedMessages As clsDBLevel
    Private objDBLevel_Languages As clsDBLevel
    Private objDBLevel_LanguageShort As clsDBLevel
    Private objDBLevel_Caption As clsDBLevel
    Private objDBLevel_Message As clsDBLevel

    Public Sub New(localConfig As IGuiLocalization)
        Me.localConfig = localConfig

        Initialize()
    End Sub

    Public Function GetGuiCaption(NameForm As String, NameGuiEntry As String, languageShort As String) As String
        Dim caption = ""
        Dim objForms = objDBLevel_GuiItems_L1.OList_ObjectRel.Where(Function(form) form.Name_Other.ToLower() = NameForm.ToLower()).ToList()

        Dim objGuiEntries = New List(Of clsObjectRel)()

        If (Not NameGuiEntry = NameForm) Then
            objGuiEntries = (From objForm In objForms
                             Join objGuiEntry In objDBLevel_GuiItems_L2.OList_ObjectRel On objForm.ID_Other Equals objGuiEntry.ID_Object
                             Where objGuiEntry.Name_Other.ToLower() = NameGuiEntry.ToLower()
                             Select objGuiEntry).ToList()

        Else
            objGuiEntries = objForms
        End If

        Dim objGuiCaptions = (From objGuiEntry In objGuiEntries
                              Join objGuiCaption In objDBLevel_GuiCaption.OList_ObjectRel On objGuiEntry.ID_Other Equals objGuiCaption.ID_Object
                              Join objLanguage In objDBLevel_Languages.OList_ObjectRel On objGuiCaption.ID_Other Equals objLanguage.ID_Object
                              Join objShort In objDBLevel_LanguageShort.OList_ObjectAtt On objLanguage.ID_Other Equals objShort.ID_Object
                              Where objShort.Val_String.ToLower() = languageShort.ToLower()
                              Select objGuiCaption.Name_Other).ToList()

        If objGuiCaptions.Any() Then
            caption = objGuiCaptions.First()
        End If

        Return caption
    End Function

    Public Function GetToolTip(NameForm As String, NameGuiEntry As String, languageShort As String) As String
        Dim toolTip = ""

        Return toolTip
    End Function

    Public Function GetUserMessageCaption(NameForm As String, NameGuiEntry As String, languageShort As String) As String
        Dim caption = ""

        Return caption
    End Function

    Public Function GetInputMessageCaption(NameForm As String, NameGuiEntry As String, languageShort As String) As String
        Dim caption = ""

        Return caption
    End Function

    Public Function GetErrorMessageCaption(NameForm As String, NameGuiEntry As String, languageShort As String) As String
        Dim caption = ""

        Return caption
    End Function

    Private Sub Initialize()
        objDBLevel_GuiItems_L1 = New clsDBLevel(localConfig.Globals)
        objDBLevel_GuiItems_L2 = New clsDBLevel(localConfig.Globals)
        objDBLevel_GuiCaption = New clsDBLevel(localConfig.Globals)
        objDBLevel_ToolTips = New clsDBLevel(localConfig.Globals)
        objDBLevel_Messages = New clsDBLevel(localConfig.Globals)
        objDBLevel_LocalizedMessages = New clsDBLevel(localConfig.Globals)
        objDBLevel_Languages = New clsDBLevel(localConfig.Globals)
        objDBLevel_LanguageShort = New clsDBLevel(localConfig.Globals)
        objDBLevel_Caption = New clsDBLevel(localConfig.Globals)
        objDBLevel_Message = New clsDBLevel(localConfig.Globals)

        If GetData_001_GuiEntries().GUID = localConfig.Globals.LState_Success.GUID Then
            If GetData_002_GuiCaptions().GUID = localConfig.Globals.LState_Success.GUID Then
                If GetData_003_ToolTipMessages().GUID = localConfig.Globals.LState_Success.GUID Then
                    If GetData_004_Messages().GUID = localConfig.Globals.LState_Success.GUID Then
                        If GetData_005_LocalizedMessage().GUID = localConfig.Globals.LState_Success.GUID Then
                            If GetData_006_Languages().GUID = localConfig.Globals.LState_Success.GUID Then
                                If GetData_007_LanguageShort().GUID = localConfig.Globals.LState_Success.GUID Then
                                    If GetData_008_CaptionMessage().GUID = localConfig.Globals.LState_Success.GUID Then

                                    Else
                                        Err.Raise(1, "Data-Error!")
                                    End If
                                Else
                                    Err.Raise(1, "Data-Error!")
                                End If
                            Else
                                Err.Raise(1, "Data-Error!")
                            End If
                        Else
                            Err.Raise(1, "Data-Error!")
                        End If
                    Else
                        Err.Raise(1, "Data-Error!")
                    End If
                Else
                    Err.Raise(1, "Data-Error!")
                End If
            Else
                Err.Raise(1, "Data-Error!")
            End If
        Else
            Err.Raise(1, "Data-Error!")
        End If
    End Sub

    Private Function GetData_001_GuiEntries() As clsOntologyItem
        Dim searchGuiEntriesL1 = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = localConfig.ID_Development,
                                                                                         .ID_RelationType = localConfig.OItem_relationtype_contains.GUID,
                                                                                         .ID_Parent_Other = localConfig.OItem_type_gui_entires.GUID}}

        Dim objOItem_Result = objDBLevel_GuiItems_L1.get_Data_ObjectRel(searchGuiEntriesL1, boolIDs:=False)

        If objOItem_Result.GUID = localConfig.Globals.LState_Success.GUID Then
            Dim searchGuiEntriesL2 = objDBLevel_GuiItems_L1.OList_ObjectRel.Select(Function(guie) New clsObjectRel With {.ID_Object = guie.ID_Other,
                                                                                                                         .ID_RelationType = localConfig.OItem_relationtype_contains.GUID,
                                                                                                                         .ID_Parent_Other = localConfig.OItem_type_gui_entires.GUID}).ToList()

            If searchGuiEntriesL2.Any() Then
                objOItem_Result = objDBLevel_GuiItems_L2.get_Data_ObjectRel(searchGuiEntriesL2, boolIDs:=False)
            End If
        End If

        Return objOItem_Result
    End Function

    Private Function GetData_002_GuiCaptions() As clsOntologyItem
        Dim searchGuiCaptions = objDBLevel_GuiItems_L1.OList_ObjectRel.Select(Function(guie) New clsObjectRel With {.ID_Object = guie.ID_Other,
                                                                                                                    .ID_RelationType = localConfig.OItem_relationtype_is_defined_by.GUID,
                                                                                                                    .ID_Parent_Other = localConfig.OItem_type_gui_caption.GUID}).ToList()

        searchGuiCaptions.AddRange(objDBLevel_GuiItems_L2.OList_ObjectRel.Select(Function(guie) New clsObjectRel With {.ID_Object = guie.ID_Other,
                                                                                                                       .ID_RelationType = localConfig.OItem_relationtype_is_defined_by.GUID,
                                                                                                                       .ID_Parent_Other = localConfig.OItem_type_gui_caption.GUID}))

        Dim objOItem_Result = localConfig.Globals.LState_Success.Clone()

        If searchGuiCaptions.Any() Then
            objOItem_Result = objDBLevel_GuiCaption.get_Data_ObjectRel(searchGuiCaptions, boolIDs:=False)
        End If

        Return objOItem_Result
    End Function

    Private Function GetData_003_ToolTipMessages() As clsOntologyItem
        Dim searchToolTips = objDBLevel_GuiItems_L1.OList_ObjectRel.Select(Function(guie) New clsObjectRel With {.ID_Object = guie.ID_Other,
                                                                                                                 .ID_RelationType = localConfig.OItem_relationtype_is_defined_by.GUID,
                                                                                                                 .ID_Parent_Other = localConfig.OItem_type_tooltip_messages.GUID}).ToList()

        searchToolTips.AddRange(objDBLevel_GuiItems_L2.OList_ObjectRel.Select(Function(guie) New clsObjectRel With {.ID_Object = guie.ID_Other,
                                                                                                                 .ID_RelationType = localConfig.OItem_relationtype_is_defined_by.GUID,
                                                                                                                 .ID_Parent_Other = localConfig.OItem_type_tooltip_messages.GUID}))

        Dim objOItem_Result = localConfig.Globals.LState_Success.Clone()

        If searchToolTips.Any() Then
            objOItem_Result = objDBLevel_ToolTips.get_Data_ObjectRel(searchToolTips, boolIDs:=False)
        End If

        Return objOItem_Result
    End Function

    Private Function GetData_004_Messages() As clsOntologyItem
        Dim searchMessages = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = localConfig.ID_Development,
                                                                                     .ID_RelationType = localConfig.OItem_relationtype_user_message.GUID,
                                                                                     .ID_Parent_Other = localConfig.OItem_class_messages.GUID},
                                                             New clsObjectRel With {.ID_Object = localConfig.ID_Development,
                                                                                     .ID_RelationType = localConfig.OItem_relationtype_inputmessage.GUID,
                                                                                     .ID_Parent_Other = localConfig.OItem_class_messages.GUID},
                                                             New clsObjectRel With {.ID_Object = localConfig.ID_Development,
                                                                                     .ID_RelationType = localConfig.OItem_relationtype_errormessage.GUID,
                                                                                     .ID_Parent_Other = localConfig.OItem_class_messages.GUID}}

        Dim objOItem_Result = objDBLevel_Messages.get_Data_ObjectRel(searchMessages, boolIDs:=False)

        Return objOItem_Result
    End Function

    Private Function GetData_005_LocalizedMessage() As clsOntologyItem
        Dim searchLocalizedMessages = objDBLevel_Messages.OList_ObjectRel.Select(Function(msg) New clsObjectRel With {.ID_Object = msg.ID_Other,
                                                                                                                      .ID_RelationType = localConfig.OItem_relationtype_belongsto.GUID,
                                                                                                                      .ID_Parent_Other = localConfig.OItem_class_localized_message.GUID}).ToList()

        Dim objOItem_Result = localConfig.Globals.LState_Success.Clone()

        If searchLocalizedMessages.Any() Then
            objOItem_Result = objDBLevel_LocalizedMessages.get_Data_ObjectRel(searchLocalizedMessages, boolIDs:=False)
        End If

        Return objOItem_Result
    End Function

    Private Function GetData_006_Languages() As clsOntologyItem
        Dim searchLanguages = objDBLevel_GuiItems_L1.OList_ObjectRel.Select(Function(guie) New clsObjectRel With {.ID_Object = guie.ID_Other,
                                                                                                                  .ID_RelationType = localConfig.OItem_relationtype_iswrittenin.GUID,
                                                                                                                  .ID_Parent_Other = localConfig.OItem_type_language.GUID}).ToList()

        searchLanguages.AddRange(objDBLevel_GuiItems_L2.OList_ObjectRel.Select(Function(guie) New clsObjectRel With {.ID_Object = guie.ID_Other,
                                                                                                                  .ID_RelationType = localConfig.OItem_relationtype_iswrittenin.GUID,
                                                                                                                  .ID_Parent_Other = localConfig.OItem_type_language.GUID}))

        searchLanguages.AddRange(objDBLevel_LocalizedMessages.OList_ObjectRel.Select(Function(lmsg) New clsObjectRel With {.ID_Object = lmsg.ID_Other,
                                                                                                                           .ID_RelationType = localConfig.OItem_relationtype_iswrittenin.GUID,
                                                                                                                           .ID_Parent_Other = localConfig.OItem_type_language.GUID}))

        Dim objOItem_Result = localConfig.Globals.LState_Success.Clone()

        If searchLanguages.Any() Then
            objOItem_Result = objDBLevel_Languages.get_Data_ObjectRel(searchLanguages, boolIDs:=False)
        End If

        Return objOItem_Result
    End Function

    Private Function GetData_007_LanguageShort() As clsOntologyItem
        Dim searchLanguageShort = objDBLevel_Languages.OList_ObjectRel.Select(Function(lang) New clsObjectAtt With {.ID_Object = lang.ID_Other,
                                                                                                                    .ID_AttributeType = localConfig.OItem_attributetype_short.GUID}).ToList()

        Dim objOItem_Result = localConfig.Globals.LState_Success.Clone()

        If searchLanguageShort.Any() Then
            objOItem_Result = objDBLevel_LanguageShort.get_Data_ObjectAtt(searchLanguageShort, boolIDs:=False)

        End If

        Return objOItem_Result
    End Function

    Private Function GetData_008_CaptionMessage() As clsOntologyItem
        Dim searchCaption = objDBLevel_LocalizedMessages.OList_ObjectRel.Select(Function(lmsg) New clsObjectAtt With {.ID_Object = lmsg.ID_Other,
                                                                                                                      .ID_AttributeType = localConfig.OItem_attribute_caption.GUID}).ToList()

        Dim objOItem_Result = localConfig.Globals.LState_Success.Clone()

        If searchCaption.Any() Then
            objOItem_Result = objDBLevel_Caption.get_Data_ObjectAtt(searchCaption, boolIDs:=False)

        End If

        If objOItem_Result.GUID = localConfig.Globals.LState_Success.GUID Then
            Dim searchMessage = objDBLevel_LocalizedMessages.OList_ObjectRel.Select(Function(lmsg) New clsObjectAtt With {.ID_Object = lmsg.ID_Other,
                                                                                                                          .ID_AttributeType = localConfig.OItem_attributetype_message.GUID}).ToList()

            If searchMessage.Any() Then
                objOItem_Result = objDBLevel_Message.get_Data_ObjectAtt(searchMessage, boolIDs:=False)
            End If
        End If

        Return objOItem_Result
    End Function
End Class
