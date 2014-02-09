using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace TextFileExport_Module
{
    public class clsDataWork_Base
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_FunctionTags;

        public List<clsFunctionTags> OList_FunctionTags { get; private set; }

        public clsOntologyItem GetFunctionTags()
        {
            OList_FunctionTags = new List<clsFunctionTags>();
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objORelS_FunctionTags = new List<clsObjectRel> {new clsObjectRel {ID_Parent_Object = objLocalConfig.OItem_class_functiontags__textfile_.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_functiontags__textfile_.GUID} };

            objOItem_Result = objDBLevel_FunctionTags.get_Data_ObjectRel(objORelS_FunctionTags, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var objFunctionTag_Remove = new clsFunctionTags
                {
                    ID_FunctionTag = objLocalConfig.OItem_object_remove_if_empty.GUID,
                    Name_FunctionTag = objLocalConfig.OItem_object_remove_if_empty.GUID
                };
                var objOList_Remove = objDBLevel_FunctionTags.OList_ObjectRel.Where(f => f.ID_Object == objLocalConfig.OItem_object_remove_if_empty.GUID).ToList();
                
                if (objOList_Remove.Count==2)
                {
                    foreach (var oRemove in objOList_Remove)
	                {
		                if (oRemove.OrderID == 1)
                        {
                            objFunctionTag_Remove.ID_FunctionTagStart = oRemove.ID_Other;
                            objFunctionTag_Remove.Name_FunctionTagStart = oRemove.Name_Other;
                            
                        }
                        else
                        {
                            objFunctionTag_Remove.ID_FunctionTagEnd = oRemove.ID_Other;
                            objFunctionTag_Remove.Name_FunctionTagEnd = oRemove.Name_Other;
                        }
	                }

                    OList_FunctionTags.Add(objFunctionTag_Remove);
                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                }
            }

            return objOItem_Result;
        }

        public clsDataWork_Base(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_FunctionTags = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
