using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Grid_Module
{
    public class clsDataWork_Grid
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_Objects;

        public List<clsOntologyItem> ObjectsOfClass { get { return objDBLevel_Objects.OList_Objects; } }

        public clsOntologyItem GetData_ObjectsOfClass(clsOntologyItem OITem_Class)
        {

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            ObjectsOfClass.Clear();

            objOItem_Result = objDBLevel_Objects.get_Data_Objects(new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = OITem_Class.GUID, Type = objLocalConfig.Globals.Type_Object } });

            return objOItem_Result;
        }

        public clsDataWork_Grid(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_Objects = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
