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
        private clsDBLevel objDBLevel_CodeOfCodeItems;
        private clsDBLevel objDBLevel_CodeSnippets;
        private clsDBLevel objDBLevel_VariablesOfCode;

        private List<clsOntologyItem> OList_CommandLineRun;
        private List<clsObjectRel> OList_CodeItemsOfCMDLR;
        private List<clsOntologyItem> OList_CodeOfCMDLR;
        private List<clsOntologyItem> OList_CodeParsed;

        public clsOntologyItem OItem_Result_CodeItems { get; private set; }
        public clsOntologyItem OItem_Result_CodeParsed { get; private set; }
        public clsOntologyItem OItem_Result_VariablesOfCode { get; private set; }
        public clsOntologyItem OItem_Result_CodeOfCodeItems { get; private set; }
        public clsOntologyItem OItem_Result_VariablesOfCodeItems { get; private set; }

        public List<clsVariableValue> OList_VariableValues { get; set; }

        private void GetSubData_CodeItems(clsOntologyItem OItem_CommandLineRun)
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

            if (OList_CodeItemsOfCMDLR == null)
            {
                OList_CodeItemsOfCMDLR = new List<clsObjectRel>();
            }
            OList_CodeItemsOfCMDLR.AddRange(objDBLevel_CodeItems.OList_ObjectRel);

            OItem_Result_CodeItems = objDBLevel_CodeItems.get_Data_ObjectRel(objORel_CodeItems, boolIDs: false);

            
        }


        private void GetSubData_CodeOfCodeItems()
        {
            OItem_Result_CodeOfCodeItems = objLocalConfig.Globals.LState_Nothing;

            var objORel_CodeOfCodeItems = OList_CommandLineRun.Select(cr => new clsObjectRel
                {
                    ID_Object = cr.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_comand_line.GUID
                }).ToList();

            objORel_CodeOfCodeItems.AddRange(OList_CommandLineRun.Select(cr => new clsObjectRel
                {
                    ID_Object = cr.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_code_snipplets.GUID
                }));

            var objOItem_Result = objDBLevel_CodeOfCodeItems.get_Data_ObjectRel(objORel_CodeOfCodeItems, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {

                OList_CodeOfCMDLR =
                    objDBLevel_CodeOfCodeItems.OList_ObjectRel.Where(c => c.ID_Parent_Other == objLocalConfig.OItem_class_comand_line.GUID).Select(c =>
                                                                                                      new clsOntologyItem
                                                                                                          {
                                                                                                              GUID = c.ID_Object,
                                                                                                              Name =c.Name_Object,
                                                                                                              GUID_Parent = c.ID_Parent_Object,
                                                                                                              Additional1 = c.Name_Other,
                                                                                                              GUID_Related = c.ID_Other
                                                                                                          }).ToList();

                var objOARel_CodeOfCodeSnippets =
                    objDBLevel_CodeOfCodeItems.OList_ObjectRel.Where(
                        c => c.ID_Parent_Other == objLocalConfig.OItem_class_code_snipplets.GUID)
                                              .Select(cr => new clsObjectAtt
                                                  {
                                                      ID_Object = cr.ID_Other,
                                                      ID_AttributeType = objLocalConfig.OItem_attributetype_code.GUID
                                                  }).ToList();

                objOItem_Result = objDBLevel_CodeSnippets.get_Data_ObjectAtt(objOARel_CodeOfCodeSnippets, boolIDs: false);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    OList_CodeOfCMDLR.AddRange(from objCMDLR in objDBLevel_CodeOfCodeItems.OList_ObjectRel
                                                 join objCode in objDBLevel_CodeSnippets.OList_ObjectAtt on
                                                     objCMDLR.ID_Other equals objCode.ID_Object
                                                 select new clsOntologyItem
                                                     {
                                                         GUID = objCMDLR.ID_Object,
                                                         Name = objCMDLR.Name_Object,
                                                         GUID_Parent = objCMDLR.ID_Parent_Object,
                                                         Additional1 = objCode.Val_String,
                                                         GUID_Related = objCode.ID_Object
                                                     });
                    OItem_Result_CodeOfCodeItems = objOItem_Result;
                }
                else
                {
                    OItem_Result_CodeOfCodeItems = objOItem_Result;
                }
            }
            else
            {
                OItem_Result_CodeOfCodeItems = objOItem_Result;
            }
        }

        public void GetSubData_VariablesOfCode()
        {
            OItem_Result_VariablesOfCode = objLocalConfig.Globals.LState_Nothing.Clone();

            var objORel_VarOfCode = OList_CodeOfCMDLR.Select(c => new clsObjectRel
                {
                    ID_Object = c.GUID_Related,
                    ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_variable.GUID
                }).ToList();

            OItem_Result_VariablesOfCode = objDBLevel_VariablesOfCode.get_Data_ObjectRel(objORel_VarOfCode,
                                                                                         boolIDs: false);
        }

        public void GetSubData_CodeParsed()
        {
            OItem_Result_CodeParsed = objLocalConfig.Globals.LState_Nothing.Clone();

            foreach (var objCode in OList_CodeOfCMDLR)
            {
                var objOList_Vars =
                    objDBLevel_VariablesOfCode.OList_ObjectRel.Where(v => v.ID_Object == objCode.GUID_Related && v.ID_Other != objLocalConfig.OItem_object_command.GUID).ToList();

                var objOList_VarVals = OList_VariableValues.Where(vv => vv.Id_ValueRef == objCode.GUID).ToList();

                var objOList_Value = (from objVar in objOList_Vars
                                      join objVarVal in objOList_VarVals on objVar.ID_Other equals objVarVal.Id_Variable
                                      select objVarVal).ToList();

                foreach (var objVarVal in objOList_Value)
                {
                    objCode.Additional1 = objCode.Additional1.Replace("@" + objVarVal.Name_Variable + "@", objVarVal.Value);
                }
                
            }

            foreach (var objCode in OList_CodeOfCMDLR)
            {
                var objOList_Vars =
                    objDBLevel_VariablesOfCode.OList_ObjectRel.Where(v => v.ID_Object == objCode.GUID_Related && v.ID_Other == objLocalConfig.OItem_object_command.GUID).ToList();

                var objOList_VarVals = OList_VariableValues.Where(vv => vv.Id_ValueRef == objCode.GUID).ToList();

                var objOList_Value = (from objVar in objOList_Vars
                                      join objVarVal in objOList_VarVals on objVar.ID_Other equals objVarVal.Id_Variable
                                      select objVarVal).ToList();

                if (objOList_Value.Any())
                {
                    var objOList_Code = OList_CodeOfCMDLR.Where(c => c.GUID == objOList_Value[0].Id_Ref).ToList();
                    if (objOList_Code.Any())
                    {
                        objCode.Additional1 = objCode.Additional1.Replace("@" + objLocalConfig.OItem_object_command.Name + "@",
                                                    objOList_Code.First().Additional1);
                    }
                    else
                    {
                        objCode.Additional1 = objCode.Additional1.Replace("@" + objLocalConfig.OItem_object_command.Name + "@",
                                                    objOList_Value.First().Value);
                    }
                }
            }
            OItem_Result_CodeParsed = objLocalConfig.Globals.LState_Success.Clone();
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

        public clsOntologyItem GetData_CommandLineRun(clsOntologyItem OItem_CommandLineRun)
        {

            if (OList_CommandLineRun == null)
            {
                OList_CommandLineRun = new List<clsOntologyItem>();
            }

            if (OItem_CommandLineRun != null)
            {
                OList_CommandLineRun.Add(OItem_CommandLineRun);    
            }
            

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            OItem_Result_CodeItems = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_CodeOfCodeItems = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_VariablesOfCodeItems = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_CodeParsed = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_VariablesOfCode = objLocalConfig.Globals.LState_Nothing;

            objOItem_Result = GetSubItems(OItem_CommandLineRun);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                GetSubData_CodeOfCodeItems();
                if (OItem_Result_CodeOfCodeItems.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    GetSubData_VariablesOfCode();
                    if (OItem_Result_VariablesOfCode.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        GetSubData_CodeParsed();
                        objOItem_Result = OItem_Result_CodeParsed;    
                    }
                    else
                    {
                        objOItem_Result = OItem_Result_VariablesOfCode;
                    }
                    
                }
                else
                {
                    objOItem_Result = OItem_Result_CodeOfCodeItems;
                }
            }

            return objOItem_Result;
        }

        private clsOntologyItem GetSubItems(clsOntologyItem OItem_CMDLR)
        {
            

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            GetSubData_CodeItems(OItem_CMDLR);

            if (OItem_Result_CodeItems.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                
                GetSubData_VariablesOfCodeItems();
                
                if (OList_VariableValues == null)
                {
                    OList_VariableValues = new List<clsVariableValue>();
                }
                OList_VariableValues.AddRange(objVariableValueWork.GetVarValueList(objLocalConfig.OItem_relationtype_needs, OItem_CMDLR));
                
                if (OItem_Result_VariablesOfCodeItems.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOItem_Result = GetCommandLineRunOfVariables();

                }
                else
                {
                    objOItem_Result = OItem_Result_VariablesOfCodeItems;
                }
                
            }
            else
            {
                objOItem_Result = OItem_Result_CodeItems.Clone();
            }

            return objOItem_Result;
        }

        private clsOntologyItem GetCommandLineRunOfVariables()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var oList_CMDLROfVarVal =
                OList_VariableValues.Where(vv => vv.Id_Parent_Ref == objLocalConfig.OItem_class_comand_line__run_.GUID);

            var oList_CMDLRONew = (from objCmdrlOfVarVal in oList_CMDLROfVarVal
                                   join objCmdrl in OList_CommandLineRun on objCmdrlOfVarVal.Id_Ref equals objCmdrl.GUID
                                       into objCmdrls
                                   from objCmdrl in objCmdrls.DefaultIfEmpty()
                                   where objCmdrl == null
                                   select objCmdrlOfVarVal).ToList();

            foreach (var objOItem_VarValue in oList_CMDLRONew.Select(vv => new clsOntologyItem
            {
                GUID = vv.Id_Ref,
                Name = vv.Name_Ref,
                GUID_Parent = vv.Id_Parent_Ref,
                Type = objLocalConfig.Globals.Type_Object
            }).ToList())
            {
                objOItem_Result = GetData_CommandLineRun(objOItem_VarValue);
                
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var objOList_VarValuesTmp = new List<clsVariableValue>(OList_VariableValues);
                    GetCommandLineRunOfVariables();

                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                    break;
                }
                
            }

            return objOItem_Result;
        }

        private void Initialize()
        {
            objDBLevel_CodeItems = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_VariablesOfCodeItems = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_CodeOfCodeItems = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_CodeSnippets = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_VariablesOfCode = new clsDBLevel(objLocalConfig.Globals);

            objVariableValueWork = new clsVariableValueWork(objLocalConfig.Globals);
        }

        public clsDataWork_CommandLineRun(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            Initialize();
        }
    }
}
