using System.Collections.Generic;
using System.Linq;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using Variable_Value_Module;

namespace ScriptExecutor_Module
{
    public class clsDataWork_CommandLineRun
    {
        private clsLocalConfig objLocalConfig;

        private clsVariableValueWork objVariableValueWork;

        private clsDBLevel objDBLevel_CodeItems;
        private clsDBLevel objDBLevel_VariablesOfCodeItems;

        public clsOntologyItem OItem_CommandLineRun { get; set; }

        private List<clsOntologyItem> OList_CommandLineRun;

        public clsOntologyItem OItem_Result_CodeItems { get; private set; }
        public clsOntologyItem OItem_Result_CodeOfCodeItems { get; private set; }
        public clsOntologyItem OItem_Result_VariablesOfCodeItems { get; private set; }

        public List<clsVariableValue> OList_VariableValues { get; set; }

        public void GetSubData_CodeItems()
        {
            OItem_Result_CodeItems = objLocalConfig.Globals.LState_Nothing;

            var objORel_CodeItems = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Object = OItem_CommandLineRun != null ? OItem_CommandLineRun.GUID : null,
                            ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_code_snipplets.GUID
                        },
                    new clsObjectRel
                        {
                            ID_Object = OItem_CommandLineRun != null ? OItem_CommandLineRun.GUID : null,
                            ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_comand_line.GUID
                        }
                };

            OItem_Result_CodeItems = objDBLevel_CodeItems.get_Data_ObjectRel(objORel_CodeItems, boolIDs: false);

            
        }

        public void GetSubData_CodeOfCodeItems()
        {
            OItem_Result_CodeOfCodeItems = objLocalConfig.Globals.LState_Nothing;
            if (OList_VariableValues.Any())
            {
                var oList_CMDR =
                    OList_VariableValues.Where(
                        vv => vv.Id_Parent_Ref == objLocalConfig.OItem_class_comand_line__run_.GUID)
                                        .Select(vv => new clsOntologyItem
                                            {
                                                GUID = vv.Id_Ref,
                                                Name = vv.Name_Ref,
                                                GUID_Parent = vv.Id_Parent_Ref,
                                                Type = objLocalConfig.Globals.Type_Object
                                            }).ToList();

                if (oList_CMDR.Any())
                {
                    if (OList_CommandLineRun == null)
                    {
                        OList_CommandLineRun = new List<clsOntologyItem>();    
                    }
                    
                    OList_CommandLineRun.AddRange(oList_CMDR);
                }
            }


            
        }

        public void GetSubData_VariablesOfCodeItems()
        {
            OItem_Result_VariablesOfCodeItems = objLocalConfig.Globals.LState_Nothing;

            var objORel_CodeItem_To_Variables =
                objDBLevel_CodeItems.OList_ObjectRel
                                    .Select(ci => new clsObjectRel
                                        {
                                            ID_Object = ci.ID_Other,
                                            ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                                            ID_Parent_Other = objLocalConfig.OItem_class_variable.GUID
                                        }).ToList();

            OItem_Result_VariablesOfCodeItems =
                objDBLevel_VariablesOfCodeItems.get_Data_ObjectRel(objORel_CodeItem_To_Variables, boolIDs: false);
        }

        public clsOntologyItem GetData_CommandLineRun(clsOntologyItem OItem_CommandLineRun = null)
        {
            this.OItem_CommandLineRun = OItem_CommandLineRun;

            if (this.OItem_CommandLineRun != null)
            {
                OList_CommandLineRun = new List<clsOntologyItem> { this.OItem_CommandLineRun };
            }

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            OItem_Result_CodeItems = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_CodeOfCodeItems = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_VariablesOfCodeItems = objLocalConfig.Globals.LState_Nothing;

            GetSubData_CodeItems();
            if (OItem_Result_CodeItems.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                GetSubData_VariablesOfCodeItems();
                if (OItem_CommandLineRun != null)
                {
                    OList_VariableValues = objVariableValueWork.GetVarValueList(objLocalConfig.OItem_relationtype_needs,OItem_CommandLineRun);    
                }
                else
                {
                    OList_VariableValues = objVariableValueWork.GetVarValueList(objLocalConfig.OItem_relationtype_needs);    
                }
                
            }
            else
            {
                objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
            }

            return objOItem_Result;
        }

        private void Initialize()
        {
            objDBLevel_CodeItems = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_VariablesOfCodeItems = new clsDBLevel(objLocalConfig.Globals);

            objVariableValueWork = new clsVariableValueWork(objLocalConfig.Globals);
        }

        public clsDataWork_CommandLineRun(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            Initialize();
        }
    }
}
