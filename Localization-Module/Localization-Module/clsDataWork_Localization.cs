using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontolog_Module;
using OntologyClasses.BaseClasses;

namespace Localization_Module
{
    public class clsDataWork_Localization
    {
        private clsLocalConfig objLocalConfig;
        private List<clsObjectRel> objOList_Localization;

        private clsDBLevel objDBLevel_LanguagesOfLocalization;
        private clsDBLevel objDBLevel_Languages;
        private clsDBLevel objDBLevel_MessagesOfLocalization;

        public List<clsLocalizationDetail> OList_LocalizationDetail { get; private set; }

        public clsOntologyItem GetData_LocalizationDetail(clsOntologyItem OItem_Ref)
        {
            var objOList_LocalitionsToRef = objOList_Localization.Where(p => p.ID_Other == OItem_Ref.GUID).ToList();
            var objOItem_Result = GetData_LanguagesOfLocalization();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = GetData_MessageOfLocalization();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    OList_LocalizationDetail = (from objLocalization in objOList_LocalitionsToRef
                                                join objMessage in objDBLevel_MessagesOfLocalization.OList_ObjectAtt on objLocalization.ID_Object equals objMessage.ID_Object
                                                join objLanguage in objDBLevel_LanguagesOfLocalization.OList_ObjectRel on objLocalization.ID_Object equals objLanguage.ID_Object
                                                select new clsLocalizationDetail
                                                {
                                                    ID_Localization = objLocalization.ID_Object,
                                                    Name_Localization = objLocalization.Name_Object,
                                                    ID_Parent_Localization = objLocalization.ID_Parent_Object,
                                                    ID_Language = objLanguage.ID_Other,
                                                    Name_Language = objLanguage.Name_Other,
                                                    ID_Attribute_Message = objMessage.ID_Attribute,
                                                    Message = objMessage.Val_String
                                                }).ToList();

                                                                                  

                }
            }

            return objOItem_Result;
        }

        public clsOntologyItem GetData_MessageOfLocalization()
        {
            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objOARel_Localization__Message = new List<clsObjectAtt> { new clsObjectAtt { ID_Class = objLocalConfig.OItem_type_localized_names.GUID,
                                                                                             ID_AttributeType = objLocalConfig.OItem_attribute_message.GUID },
                                                                          new clsObjectAtt { ID_Class = objLocalConfig.OItem_type_localizeddescription.GUID,
                                                                                             ID_AttributeType = objLocalConfig.OItem_attribute_message.GUID } };

            objOItem_Result = objDBLevel_MessagesOfLocalization.get_Data_ObjectAtt(objOARel_Localization__Message, boolIDs:false);

            return objOItem_Result;
        }

        public clsOntologyItem GetData_LanguagesOfLocalization()
        {
            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objOLRel_LocalizationToLanuage = new List<clsObjectRel> { new clsObjectRel { ID_Parent_Object = objLocalConfig.OItem_type_localized_names.GUID,
                                                                                            ID_RelationType = objLocalConfig.OItem_relationtype_iswrittenin.GUID, 
                                                                                            ID_Parent_Other = objLocalConfig.OItem_type_language.GUID },
                                                                          new clsObjectRel { ID_Parent_Object = objLocalConfig.OItem_type_localizeddescription.GUID,
                                                                                             ID_RelationType = objLocalConfig.OItem_relationtype_iswrittenin.GUID,
                                                                                             ID_Parent_Other = objLocalConfig.OItem_type_language.GUID } };

            objOItem_Result = objDBLevel_LanguagesOfLocalization.get_Data_ObjectRel(objOLRel_LocalizationToLanuage, boolIDs: false);


            return objOItem_Result;
        }

        public clsOntologyItem GetData_Languages()
        {
            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objOL_Languages = new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = objLocalConfig.OItem_type_language.GUID } };

            objOItem_Result = objDBLevel_Languages.get_Data_Objects(objOL_Languages);

            return objOItem_Result;
        }

        public clsDataWork_Localization(clsLocalConfig LocalConfig, List<clsObjectRel> OList_Localization)
        {
            objLocalConfig = LocalConfig;
            objOList_Localization = OList_Localization;

            objDBLevel_LanguagesOfLocalization = new clsDBLevel(objLocalConfig.Globals);
            initialize();
        }

        private void initialize()
        {
            objDBLevel_Languages = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_LanguagesOfLocalization = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_MessagesOfLocalization = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
