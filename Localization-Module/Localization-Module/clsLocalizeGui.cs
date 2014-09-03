using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace Localization_Module
{
    public class clsLocalizeGui
    {
        
        private IGuiLocalization localConfig;

        private clsDBLevel objDBLevel_GuiItems_L1;
        private clsDBLevel objDBLevel_GuiItems_L2;
        private clsDBLevel objDBLevel_GuiCaption;
        private clsDBLevel objDBLevel_ToolTips;
        private clsDBLevel objDBLevel_Messages;
        private clsDBLevel objDBLevel_LocalizedMessages;
        private clsDBLevel objDBLevel_Languages;
        private clsDBLevel objDBLevel_LanguageShort;
        private clsDBLevel objDBLevel_Caption;
        private clsDBLevel objDBLevel_Message;

        public clsLocalizeGui(IGuiLocalization localConfig)
        {
            this.localConfig = localConfig;

            Initialize();
        }

        public string GetGuiCaption(string NameForm, string NameGuiEntry, string languageShort)
        {
            var caption = "";
            var objForms =
                objDBLevel_GuiItems_L1.OList_ObjectRel.Where(form => form.Name_Other.ToLower() == NameForm.ToLower())
                                      .ToList();

            var objGuiEntries = new List<clsObjectRel>();

            if (NameGuiEntry != NameForm)
            {
                objGuiEntries = (from objForm in objForms
                                     join objGuiEntry in objDBLevel_GuiItems_L2.OList_ObjectRel on objForm.ID_Other
                                         equals objGuiEntry.ID_Object
                                     where objGuiEntry.Name_Other.ToLower() == NameGuiEntry.ToLower()
                                     select objGuiEntry).ToList();

                
            }
            else
            {
                objGuiEntries = objForms;
            }

            var objGuiCaptions = (from objGuiEntry in objGuiEntries
                                  join objGuiCaption in objDBLevel_GuiCaption.OList_ObjectRel on objGuiEntry.ID_Other
                                      equals objGuiCaption.ID_Object
                                  join objLanguage in objDBLevel_Languages.OList_ObjectRel on objGuiCaption.ID_Other
                                      equals objLanguage.ID_Object
                                  join objShort in objDBLevel_LanguageShort.OList_ObjectAtt on objLanguage.ID_Other
                                      equals objShort.ID_Object
                                  where objShort.Val_String.ToLower() == languageShort.ToLower()
                                  select objGuiCaption.Name_Other).ToList();

            if (objGuiCaptions.Any())
            {
                caption = objGuiCaptions.First();
            }

            return caption;
        }

        public string GetToolTip(string NameForm, string NameGuiEntry, string languageShort)
        {
            var toolTip = "";

            return toolTip;
        }

        public string GetUserMessageCaption(string NemeFrom, string NameMessage, string lanugageShort)
        {
            var caption = "";

            return caption;
        }

        public string GetInputMessageCaption(string NemeFrom, string NameMessage, string lanugageShort)
        {
            var caption = "";

            return caption;
        }

        public string GetErrorMessageCaption(string NemeFrom, string NameMessage, string lanugageShort)
        {
            var caption = "";

            return caption;
        }

        public string GetUserMessage(string NemeFrom, string NameMessage, string lanugageShort)
        {
            var message = "";

            return message;
        }

        public string GetInputMessage(string NemeFrom, string NameMessage, string lanugageShort)
        {
            var message = "";

            return message;
        }

        public string GetErrorMessage(string NemeFrom, string NameMessage, string lanugageShort)
        {
            var message = "";

            return message;
        }

        private void Initialize()
        {
            objDBLevel_GuiItems_L1 = new clsDBLevel(localConfig.Globals);
            objDBLevel_GuiItems_L2 = new clsDBLevel(localConfig.Globals);
            objDBLevel_GuiCaption = new clsDBLevel(localConfig.Globals);
            objDBLevel_ToolTips = new clsDBLevel(localConfig.Globals);
            objDBLevel_Messages = new clsDBLevel(localConfig.Globals);
            objDBLevel_LocalizedMessages = new clsDBLevel(localConfig.Globals);
            objDBLevel_Languages = new clsDBLevel(localConfig.Globals);
            objDBLevel_LanguageShort = new clsDBLevel(localConfig.Globals);
            objDBLevel_Caption = new clsDBLevel(localConfig.Globals);
            objDBLevel_Message = new clsDBLevel(localConfig.Globals);

            if (GetData_001_GuiEntries().GUID == localConfig.Globals.LState_Success.GUID)
            {
                if (GetData_002_GuiCaptions().GUID == localConfig.Globals.LState_Success.GUID)
                {
                    if (GetData_003_ToolTipMessages().GUID == localConfig.Globals.LState_Success.GUID)
                    {
                        if (GetData_004_Messages().GUID == localConfig.Globals.LState_Success.GUID)
                        {
                            if (GetData_005_LocalizedMessage().GUID == localConfig.Globals.LState_Success.GUID)
                            {
                                if (GetData_006_Languages().GUID == localConfig.Globals.LState_Success.GUID)
                                {
                                    if (GetData_007_LanguageShort().GUID == localConfig.Globals.LState_Success.GUID)
                                    {
                                        if (GetData_008_CaptionMessage().GUID == localConfig.Globals.LState_Success.GUID)
                                        {

                                        }
                                        else
                                        {
                                            throw new Exception("Data-Error!");
                                        } 
                                    }
                                    else
                                    {
                                        throw new Exception("Data-Error!");
                                    } 
                                }
                                else
                                {
                                    throw new Exception("Data-Error!");
                                } 
                            }
                            else
                            {
                                throw new Exception("Data-Error!");
                            } 
                        }
                        else
                        {
                            throw new Exception("Data-Error!");
                        }   
                    }
                    else
                    {
                        throw new Exception("Data-Error!");
                    }
                }
                else
                {
                    throw new Exception("Data-Error!");
                }
            }
            else
            {
                throw new Exception("Data-Error!");
            }


        }

        private clsOntologyItem GetData_001_GuiEntries()
        {

            var searchGuiEntriesL1 = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Object = localConfig.Id_Development,
                            ID_RelationType = localConfig.OItem_relationtype_contains.GUID,
                            ID_Parent_Other = localConfig.OItem_type_gui_entires.GUID
                        }
                };

            var objOItem_Result = objDBLevel_GuiItems_L1.get_Data_ObjectRel(searchGuiEntriesL1, boolIDs: false);

            if (objOItem_Result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                var searchGuiEntriesL2 = objDBLevel_GuiItems_L1.OList_ObjectRel.Select(guie => new clsObjectRel
                    {
                        ID_Object = guie.ID_Other,
                        ID_RelationType = localConfig.OItem_relationtype_contains.GUID,
                        ID_Parent_Other = localConfig.OItem_type_gui_entires.GUID
                    }).ToList();

                if (searchGuiEntriesL2.Any())
                {
                    objOItem_Result = objDBLevel_GuiItems_L2.get_Data_ObjectRel(searchGuiEntriesL2, boolIDs: false);    
                }
                


            }

            return objOItem_Result;
        }

        private clsOntologyItem GetData_002_GuiCaptions()
        {
            var searchGuiCaptions = objDBLevel_GuiItems_L1.OList_ObjectRel.Select(guie => new clsObjectRel
                {
                    ID_Object = guie.ID_Other,
                    ID_RelationType = localConfig.OItem_relationtype_is_defined_by.GUID,
                    ID_Parent_Other = localConfig.OItem_type_gui_caption.GUID
                }).ToList();

            searchGuiCaptions.AddRange(objDBLevel_GuiItems_L2.OList_ObjectRel.Select(guie => new clsObjectRel
                {
                    ID_Object = guie.ID_Other,
                    ID_RelationType = localConfig.OItem_relationtype_is_defined_by.GUID,
                    ID_Parent_Other = localConfig.OItem_type_gui_caption.GUID
                }));

            var objOItem_Result = localConfig.Globals.LState_Success.Clone();
            if (searchGuiCaptions.Any())
            {
                objOItem_Result = objDBLevel_GuiCaption.get_Data_ObjectRel(searchGuiCaptions, boolIDs: false);    
            }
            

            return objOItem_Result;
        }

        private clsOntologyItem GetData_003_ToolTipMessages()
        {
            var searchToolTips = objDBLevel_GuiItems_L1.OList_ObjectRel.Select(guie => new clsObjectRel
            {
                ID_Object = guie.ID_Other,
                ID_RelationType = localConfig.OItem_relationtype_is_defined_by.GUID,
                ID_Parent_Other = localConfig.OItem_type_tooltip_messages.GUID
            }).ToList();

            searchToolTips.AddRange(objDBLevel_GuiItems_L2.OList_ObjectRel.Select(guie => new clsObjectRel
                {
                    ID_Object = guie.ID_Other,
                    ID_RelationType = localConfig.OItem_relationtype_is_defined_by.GUID,
                    ID_Parent_Other = localConfig.OItem_type_tooltip_messages.GUID
                }));

            var objOItem_Result = localConfig.Globals.LState_Success.Clone();
            if (searchToolTips.Any())
            {
                objOItem_Result = objDBLevel_ToolTips.get_Data_ObjectRel(searchToolTips, boolIDs: false);    
            }
            

            return objOItem_Result;
        }

        private clsOntologyItem GetData_004_Messages()
        {
            var searchMessages = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Object = localConfig.Id_Development,
                            ID_RelationType = localConfig.OItem_relationtype_user_message.GUID,
                            ID_Parent_Other = localConfig.OItem_class_messages.GUID
                        },
                    new clsObjectRel
                        {
                            ID_Object = localConfig.Id_Development,
                            ID_RelationType = localConfig.OItem_relationtype_inputmessage.GUID,
                            ID_Parent_Other = localConfig.OItem_class_messages.GUID
                        },
                    new clsObjectRel
                        {
                            ID_Object = localConfig.Id_Development,
                            ID_RelationType = localConfig.OItem_relationtype_errormessage.GUID,
                            ID_Parent_Other = localConfig.OItem_class_messages.GUID
                        }
                };

            var objOItem_Result = objDBLevel_Messages.get_Data_ObjectRel(searchMessages, boolIDs: false);

            return objOItem_Result;
        }

        private clsOntologyItem GetData_005_LocalizedMessage()
        {
            var searchLocalizedMessages = objDBLevel_Messages.OList_ObjectRel.Select(msg => new clsObjectRel
                {
                    ID_Object = msg.ID_Other,
                    ID_RelationType = localConfig.OItem_relationtype_belongsto.GUID,
                    ID_Parent_Other = localConfig.OItem_class_localized_message.GUID
                }).ToList();

            var objOItem_Result = localConfig.Globals.LState_Success.Clone();
            if (searchLocalizedMessages.Any())
            {
                objOItem_Result = objDBLevel_LocalizedMessages.get_Data_ObjectRel(searchLocalizedMessages,
                                                                                      boolIDs: false);    
            }
            

            return objOItem_Result;
        }

        private clsOntologyItem GetData_006_Languages()
        {
            var searchLanguages = objDBLevel_GuiCaption.OList_ObjectRel.Select(guie => new clsObjectRel
                {
                    ID_Object = guie.ID_Other,
                    ID_RelationType = localConfig.OItem_relationtype_iswrittenin.GUID,
                    ID_Parent_Other = localConfig.OItem_type_language.GUID
                }).ToList();

            searchLanguages.AddRange(objDBLevel_ToolTips.OList_ObjectRel.Select(toolt => new clsObjectRel
                {
                    ID_Object = toolt.ID_Other,
                    ID_RelationType = localConfig.OItem_relationtype_iswrittenin.GUID,
                    ID_Parent_Other = localConfig.OItem_type_language.GUID
                }));

            searchLanguages.AddRange(objDBLevel_LocalizedMessages.OList_ObjectRel.Select(lmsg => new clsObjectRel
            {
                ID_Object = lmsg.ID_Other,
                ID_RelationType = localConfig.OItem_relationtype_iswrittenin.GUID,
                ID_Parent_Other = localConfig.OItem_type_language.GUID
            }));

            var objOItem_Result = localConfig.Globals.LState_Success.Clone();

            if (searchLanguages.Any())
            {
                objOItem_Result = objDBLevel_Languages.get_Data_ObjectRel(searchLanguages,boolIDs:false);
            }

            return objOItem_Result;
        }

        private clsOntologyItem GetData_007_LanguageShort()
        {
            var searchLanguageShort = objDBLevel_Languages.OList_ObjectRel.Select(lang => new clsObjectAtt
                {
                    ID_Object = lang.ID_Other,
                    ID_AttributeType = localConfig.OItem_attributetype_short.GUID
                }).ToList();

            var objOItem_Result = localConfig.Globals.LState_Success.Clone();

            if (searchLanguageShort.Any())
            {
                objOItem_Result = objDBLevel_LanguageShort.get_Data_ObjectAtt(searchLanguageShort, boolIDs: false);

            }

            return objOItem_Result;
        }

        private clsOntologyItem GetData_008_CaptionMessage()
        {
            var searchCaption = objDBLevel_LocalizedMessages.OList_ObjectRel.Select(lmsg => new clsObjectAtt
                {
                    ID_Object = lmsg.ID_Other,
                    ID_AttributeType = localConfig.OItem_attribute_caption.GUID
                }).ToList();

            var objOItem_Result = localConfig.Globals.LState_Success.Clone();

            if (searchCaption.Any())
            {
                objOItem_Result = objDBLevel_Caption.get_Data_ObjectAtt(searchCaption, boolIDs: false);

            }

            if (objOItem_Result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                var searchMessage = objDBLevel_LocalizedMessages.OList_ObjectRel.Select(lmsg => new clsObjectAtt
                    {
                        ID_Object = lmsg.ID_Other,
                        ID_AttributeType = localConfig.OItem_attributetype_message.GUID
                    }).ToList();

                if (searchCaption.Any())
                {
                    objOItem_Result = objDBLevel_Message.get_Data_ObjectAtt(searchMessage, boolIDs: false);

                }
            }

            return objOItem_Result;
        }
    }
}
