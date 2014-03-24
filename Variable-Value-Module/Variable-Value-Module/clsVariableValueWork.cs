using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Variable_Value_Module
{
    public class clsVariableValueWork
    {
        private clsDataWork_VariableValue objDataWork_VariableValue;

        private clsLocalConfig objLocalConfig;

        public List<clsVariableValue> GetVarValueList(clsOntologyItem OItem_RelationType, clsOntologyItem OItem_Ref)
        {
            objDataWork_VariableValue.OItem_RelationType = OItem_RelationType;
            var objOItem_Result = objDataWork_VariableValue.GetData_VariableValue();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                return objDataWork_VariableValue.VariableValueList.Where(vv => vv.Id_ValueRef == OItem_Ref.GUID).ToList();
            }
            else
            {
                return null;
            }
        }

        public List<clsVariableValue> GetVarValueList(clsOntologyItem OItem_RelationType)
        {
            objDataWork_VariableValue.OItem_RelationType = OItem_RelationType;
            var objOItem_Result = objDataWork_VariableValue.GetData_VariableValue();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                return objDataWork_VariableValue.VariableValueList.ToList();
            }
            else
            {
                return null;
            }
        }

        public clsVariableValueWork(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();

        }

        public clsVariableValueWork(clsGlobals Globals)
        {
            objLocalConfig = new clsLocalConfig(Globals);

            Initialize();
        }

        private void Initialize()
        {
            objDataWork_VariableValue = new clsDataWork_VariableValue(objLocalConfig);
        }
    }
}
