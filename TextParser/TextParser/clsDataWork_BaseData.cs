using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace TextParser
{
    class clsDataWork_BaseData
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_Textparser;

        public List<clsOntologyItem> GetData_TextParsersOfUser()
        {
            var objOList_TextParsers = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Other = objLocalConfig.OItem_User.GUID,
                            ID_Parent_Object = objLocalConfig.OItem_class_textparser.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID
                        }
                };

            var objOItem_Result = objDBLevel_Textparser.get_Data_ObjectRel(objOList_TextParsers,
                                                                           boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                return objDBLevel_Textparser.OList_ObjectRel.Select(p => new clsOntologyItem
                    {
                        GUID = p.ID_Object,
                        Name = p.Name_Object,
                        GUID_Parent = p.ID_Parent_Object,
                        Type = objLocalConfig.Globals.Type_Object
                    }).ToList();
            }
            else
            {
                return null;
            }
        }

        public clsDataWork_BaseData(clsLocalConfig localConfig)
        {
            objLocalConfig = localConfig;
            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_Textparser = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
