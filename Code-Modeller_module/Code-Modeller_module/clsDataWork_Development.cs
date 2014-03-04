using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Code_Modeller_module
{
    public class clsDataWork_Development
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_Development;
        private clsDBLevel objDBLevel_DevTree;

        public List<clsOntologyItem> OList_Development { get; set; }
        public List<clsObjectTree> OList_DevTree { get; set; }


        public clsOntologyItem GetData_Development()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var OListS_Development = new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = objLocalConfig.OItem_class_software_development.GUID } };

            objOItem_Result = objDBLevel_Development.get_Data_Objects(OListS_Development);


            return objOItem_Result;
        }

        public clsOntologyItem GetData_DevTree()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            objOItem_Result = objDBLevel_DevTree.get_Data_Objects_Tree(objLocalConfig.OItem_class_software_development,
                objLocalConfig.OItem_class_software_development,
                objLocalConfig.OItem_relationtype_is_subordinated);


            return objOItem_Result;
        }

        public clsDataWork_Development(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_Development = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_DevTree = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
