using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace ClipBoardListener_Url_Connector
{
    public class clsDataWork_UrlListener
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_Url;
        private clsDBLevel objDBLevel_Ref_To_Url;


        public clsOntologyItem GetUrlByName(String Name_Url)
        {
            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchUrl = new List<clsOntologyItem> {new clsOntologyItem {GUID_Parent = objLocalConfig.OItem_class_url.GUID,
                Name = Name_Url } };

            objOItem_Result = objDBLevel_Url.get_Data_Objects(searchUrl);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Url.OList_Objects.Any(u => u.Name == Name_Url))
                {
                    objOItem_Result = objDBLevel_Url.OList_Objects.Select(u => u).ToList().First();
                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Nothing.Clone();
                }
            }

            return objOItem_Result;
        }

        public clsOntologyItem IsUrlRelated(clsOntologyItem OItem_Left, clsOntologyItem OItem_Right, clsOntologyItem OItem_RelationType)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchRel = new List<clsObjectRel> { new clsObjectRel {ID_Object = OItem_Left.GUID,
                ID_RelationType = OItem_RelationType.GUID,
                ID_Other = OItem_Right.GUID } };

            objOItem_Result = objDBLevel_Ref_To_Url.get_Data_ObjectRel(searchRel);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Ref_To_Url.OList_ObjectRel_ID.Any())
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
                    objOItem_Result.Val_Long = objDBLevel_Ref_To_Url.OList_ObjectRel_ID.First().OrderID;
                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Nothing.Clone();
                }
            }

            return objOItem_Result;
        }

        public clsDataWork_UrlListener(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialze();
        }

        private void Initialze()
        {
            objDBLevel_Ref_To_Url = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Url = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
