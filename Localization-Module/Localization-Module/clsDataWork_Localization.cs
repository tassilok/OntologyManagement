using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Localization_Module
{
    public class clsDataWork_Localization
    {
        private clsLocalConfig objLocalConfig;
        private List<clsObjectRel> objOList_Localization;

        private clsOntologyItem objOItem_Ref;

        private clsDBLevel objDBLevel_LocalizationToRef;
        private clsDBLevel objDBLevel_LanguagesOfLocalization;
        private clsDBLevel objDBLevel_Languages;
        private clsDBLevel objDBLevel_MessagesOfLocalization;

        public List<clsLocalizationDetail> OList_LocalizationDetail { get; private set; }

        public clsOntologyItem GetData_LocalizationDetail(clsOntologyItem OItem_Ref)
        {
            objOItem_Ref = OItem_Ref;

            var objOItem_Result = GetSubData001_LocalizationToRef();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = GetSubData002_MessageOfLocalization();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOItem_Result = GetSubData003_LanguagesOfLocalization();
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        OList_LocalizationDetail = (from objLocalization in objDBLevel_LocalizationToRef.OList_ObjectRel
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
            }
            

            return objOItem_Result;
        }

        private clsOntologyItem GetSubData001_LocalizationToRef()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objOList_LocalizationsToRef = new List<clsObjectRel> { new clsObjectRel {ID_Other = objOItem_Ref.GUID,
                ID_Parent_Object = objLocalConfig.OItem_type_localizeddescription.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_describes.GUID } };

            objOList_LocalizationsToRef.Add(new clsObjectRel { ID_Other = objOItem_Ref.GUID,
                ID_Parent_Object = objLocalConfig.OItem_type_localized_names.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_describes.GUID } );

            objOItem_Result = objDBLevel_LocalizationToRef.get_Data_ObjectRel(objOList_LocalizationsToRef, boolIDs: false);

            return objOItem_Result;
        }
      
        public clsOntologyItem GetSubData002_MessageOfLocalization()
        {
            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objORList_LocalizationToRef = objDBLevel_LocalizationToRef.OList_ObjectRel.Where(loc => loc.ID_Parent_Object == objLocalConfig.OItem_type_localizeddescription.GUID).ToList();
            if (objORList_LocalizationToRef.Any())
            {
                var objOARel_Localization__Message = objDBLevel_LocalizationToRef.OList_ObjectRel.Select(loc => new clsObjectAtt
                {
                    ID_Object = loc.ID_Object,
                    ID_AttributeType = objLocalConfig.OItem_attribute_message.GUID
                }).ToList();

                objOItem_Result = objDBLevel_MessagesOfLocalization.get_Data_ObjectAtt(objOARel_Localization__Message, boolIDs: false);
            }
            else
            {
                objDBLevel_MessagesOfLocalization.OList_ObjectAtt.Clear();
            }
            

            return objOItem_Result;
        }

        public clsOntologyItem GetSubData003_LanguagesOfLocalization()
        {
            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            if (objDBLevel_LocalizationToRef.OList_ObjectRel.Any())
            {
                var objOLRel_LocalizationToLanguage = objDBLevel_LocalizationToRef.OList_ObjectRel.Select(loc => new clsObjectRel
                {
                    ID_Object = loc.ID_Object,
                    ID_RelationType = objLocalConfig.OItem_relationtype_iswrittenin.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_type_language.GUID
                }).ToList();
               
                objOItem_Result = objDBLevel_LanguagesOfLocalization.get_Data_ObjectRel(objOLRel_LocalizationToLanguage, boolIDs: false);
            }
            else
            {
                objDBLevel_LanguagesOfLocalization.OList_ObjectRel.Clear();
            }
            


            return objOItem_Result;
        }

        public clsOntologyItem GetData_Languages()
        {
            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objOL_Languages = new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = objLocalConfig.OItem_type_language.GUID } };

            objOItem_Result = objDBLevel_Languages.get_Data_Objects(objOL_Languages);

            return objOItem_Result;
        }

        public clsDataWork_Localization(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            objDBLevel_LanguagesOfLocalization = new clsDBLevel(objLocalConfig.Globals);
            initialize();
        }

        private void initialize()
        {
            objDBLevel_Languages = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_LanguagesOfLocalization = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_MessagesOfLocalization = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_LocalizationToRef = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
