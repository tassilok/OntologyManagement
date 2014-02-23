using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Variable_Value_Module
{
    public class clsDataWork_VariableValue
    {
        private clsDBLevel objDBLevel_Value_To_Variable;
        private clsDBLevel objDBLevel_Value_To_belongingSource;
        private clsDBLevel objDBLevel_Ref_To_Value;

        private clsLocalConfig objLocalConfig;

        public clsOntologyItem OItem_Result_Value_To_Variable { get; private set; }
        public clsOntologyItem OItem_Result_Value_To_belongingSource { get; private set; }
        public clsOntologyItem OItem_Result_Ref_To_Value { get; private set; }

        public List<clsVariableValue> VariableValueList { get; set; }


        public clsOntologyItem OItem_RelationType { get; set; }

        public clsOntologyItem GetData_VariableValue()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            GetData_VariableToValue();
            if (OItem_Result_Value_To_Variable.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                GetData_ValueToBelongingSource();
                if (OItem_Result_Value_To_belongingSource.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    GetData_RefToValue();
                    if (OItem_Result_Ref_To_Value.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        VariableValueList = (from objVariable in objDBLevel_Value_To_Variable.OList_ObjectRel
                                             join objValue in objDBLevel_Value_To_belongingSource.OList_ObjectRel on objVariable.ID_Object equals objValue.ID_Object into objValues
                                             from objValue in objValues.DefaultIfEmpty()
                                             join objRef in objDBLevel_Ref_To_Value.OList_ObjectRel on objVariable.ID_Object equals objRef.ID_Other
                                             select new clsVariableValue
                                             {
                                                 Id_Ref = objValue != null ? objValue.ID_Other : null,
                                                 Name_Ref = objValue != null ? objValue.Name_Other : null,
                                                 Id_Parent_Ref = objValue != null ? objValue.ID_Parent_Other : null,
                                                 Type_Ref = objValue != null ? objValue.Ontology : null,
                                                 Id_Variable = objVariable.ID_Other,
                                                 Name_Variable = objVariable.Name_Other,
                                                 Id_Value = objValue.ID_Object,
                                                 Name_Value = objValue.Name_Object,
                                                 Id_ValueRef = objRef.ID_Object,
                                                 Name_ValueRef = objRef.Name_Object,
                                                 Value = objValue != null ? objValue.Name_Other : objVariable.Name_Object
                                             }).ToList();
                    }
                    else
                    {
                        objOItem_Result = OItem_Result_Ref_To_Value;
                    }
                    
                                             
                }
                else
                {
                    objOItem_Result = OItem_Result_Value_To_belongingSource;
                }
            }
            else
            {
                objOItem_Result = OItem_Result_Value_To_Variable;
            }

            return objOItem_Result;
        }

        public void GetData_VariableToValue()
        {
            OItem_Result_Value_To_Variable = objLocalConfig.Globals.LState_Nothing.Clone();

            var objORel_ValueToVariable = new List<clsObjectRel> 
            { 
                new clsObjectRel 
                {
                    ID_Parent_Other = objLocalConfig.OItem_class_variable.GUID,
                    ID_Parent_Object = objLocalConfig.OItem_class_value.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID 
                }
            };

            OItem_Result_Value_To_Variable = objDBLevel_Value_To_Variable.get_Data_ObjectRel(objORel_ValueToVariable, boolIDs: false);

        }

        public void GetData_ValueToBelongingSource()
        {
            OItem_Result_Value_To_belongingSource = objLocalConfig.Globals.LState_Nothing.Clone();

            var objORel_ValueToBelongingSource = new List<clsObjectRel>
            {
                new clsObjectRel
                {
                    ID_Parent_Object = objLocalConfig.OItem_class_value.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID
                }
            };

            OItem_Result_Value_To_belongingSource = objDBLevel_Value_To_belongingSource.get_Data_ObjectRel(objORel_ValueToBelongingSource, boolIDs: false);

        }

        public void GetData_RefToValue()
        {
            OItem_Result_Ref_To_Value = objLocalConfig.Globals.LState_Nothing.Clone();

            var objORel_RefToValue = new List<clsObjectRel>
            {
                new clsObjectRel
                {
                    ID_Parent_Other = objLocalConfig.OItem_class_value.GUID,
                    ID_RelationType = OItem_RelationType.GUID
                }
            };

            OItem_Result_Ref_To_Value = objDBLevel_Ref_To_Value.get_Data_ObjectRel(objORel_RefToValue, boolIDs: false);
        }


        public clsDataWork_VariableValue(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_Value_To_belongingSource = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Value_To_Variable = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Ref_To_Value = new clsDBLevel(objLocalConfig.Globals);

            OItem_RelationType = objLocalConfig.OItem_relationtype_replace_with;
        }
    }
}
