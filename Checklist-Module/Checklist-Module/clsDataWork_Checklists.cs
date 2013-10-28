using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Checklist_Module
{
    

    class clsDataWork_Checklists
    {
        public clsOntologyItem OItem_Result_Report { get; private set; }
        public clsOntologyItem OItem_Result_WorkingLists { get; private set; }

        public List<clsOntologyItem> OList_WorkingLists { get; private set; }

        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_Report;

        public void GetData_WorkingLists()
        {
            OItem_Result_WorkingLists = objLocalConfig.Globals.LState_Nothing.Clone();
            var objOLRel_WorkingList_To_User = new List<clsObjectRel> {new clsObjectRel {ID_Other = objLocalConfig.User.GUID, 
                                                                    ID_Parent_Object = objLocalConfig.OItem_class_working_lists.GUID, 
                                                                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID}};
            var objOItem_Result = objDBLevel_Report.get_Data_ObjectRel(objOLRel_WorkingList_To_User, boolIDs : false);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_WorkingLists = objDBLevel_Report.OList_ObjectRel.Select(p => new clsOntologyItem
                {
                    GUID = p.ID_Object,
                    Name = p.Name_Object,
                    GUID_Parent = p.ID_Parent_Object,
                    Type = objLocalConfig.Globals.Type_Object
                }).ToList();
                OItem_Result_WorkingLists = objLocalConfig.Globals.LState_Success.Clone();
            }
            else
            {
                OItem_Result_WorkingLists = objLocalConfig.Globals.LState_Error.Clone();
            }

        }



        public void GetData_Report()
        {
            OItem_Result_Report = objLocalConfig.Globals.LState_Nothing.Clone();

        }

        public clsDataWork_Checklists(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_Report = new clsDBLevel(objLocalConfig.Globals);

            OItem_Result_Report = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_WorkingLists = objLocalConfig.Globals.LState_Nothing.Clone();

            
        }
    }
}
