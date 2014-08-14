﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace CommandLineRun_Module
{
    public class clsDataWork_CommandLineRun
    {
        private clsLocalConfig objLocalConfig;


        
        private clsDBLevel objDBLevel_CommandLineRun;
        private clsDBLevel objDBLevel_CommandLine;
        private clsDBLevel objDBLevel_CommandLineRunTree;
        private clsDBLevel objDBLevel_CodeSnipplets;
        private clsDBLevel objDBLevel_Code;
        private clsDBLevel objDBLevel_Variables;
        private clsDBLevel objDBLevel_Values;
        private clsDBLevel objDBLevel_ValueVars;
        private clsDBLevel objDBLevel_ValueBelongingSource;
        private clsDBLevel objDBLevel_Relations;
        private clsDBLevel objDBlevel_CmdlrTreeParam;
        private clsDBLevel objDBlevel_OItem;

        public clsOntologyItem OItem_Result_CommandLineRun { get; private set; }
        public clsOntologyItem OItem_Result_CommandLineRunHierarchy { get; private set; }
        public clsOntologyItem OItem_Result_CommandLine { get; private set; }
        public clsOntologyItem OItem_Result_Variables { get; private set; }
        public clsOntologyItem OItem_Result_CodeSnipplets { get; private set; }
        public clsOntologyItem OItem_Result_Values { get; private set; }
        public clsOntologyItem OItem_Result_ValueVars { get; private set; }
        public clsOntologyItem OItem_Result_ValueBelongingSource { get; private set; }
        public clsOntologyItem OItem_Result_Codes { get; private set; }

        private clsOntologyItem OItem_Result_Filter;

        public clsOntologyItem OItem_CommandLineRun_Entry { get; set; }

        public List<clsCode> Codes { get; private set; }

        public clsOntologyItem OItem_Class { get; set; }
        public clsOntologyItem OItem_Direction { get; set; }
        public clsOntologyItem OItem_RelationType { get; set; }
        public clsOntologyItem OItem_Object { get; set; }

        public int RootNodeCount { get; private set; }

        private List<clsOntologyItem> filterList = new List<clsOntologyItem>();

        public clsOntologyItem GetOItem(string GUID_Item, string Type_Item)
        {
            return objDBlevel_OItem.GetOItem(GUID_Item, Type_Item);
        }

        public clsOntologyItem GetData_CommandLineRun()
        {
            CreateFilterListCMDLRs();
            var objOItem_Result = OItem_Result_Filter;

            if (objOItem_Result.GUID != objLocalConfig.Globals.LState_Error.GUID)
            {
                GetSubData_001_CommandLineRun();
                objOItem_Result = OItem_Result_CommandLineRun;

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    GetSubData_002_CommandLineRunTree();
                    objOItem_Result = OItem_Result_CommandLineRunHierarchy;

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        GetSubData_003_CommandLine();
                        objOItem_Result = OItem_Result_CommandLine;

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            GetSubData_004_CodeSnipplets();
                            objOItem_Result = OItem_Result_CodeSnipplets;

                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                GetSubData_005_Variables();
                                objOItem_Result = OItem_Result_Variables;

                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    GetSubData_006_Values();
                                    objOItem_Result = OItem_Result_Values;

                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        GetSubData_007_ValueVars();
                                        objOItem_Result = OItem_Result_ValueVars;

                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            GetSubData_008_ValueBelongingSources();
                                            objOItem_Result = OItem_Result_ValueBelongingSource;
                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                            {
                                                GetSubData_009_Codes();
                                                objOItem_Result = OItem_Result_Codes;

                                            }
                                        }

                                    }

                                }

                            }

                        }
                    }


                }
            }
            

            return objOItem_Result;
        }

        public void GetSubData_001_CommandLineRun()
        {
            OItem_Result_CommandLineRun = objLocalConfig.Globals.LState_Nothing.Clone();

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchRuns = new List<clsOntologyItem>
                {
                    new clsOntologyItem {GUID_Parent = objLocalConfig.OItem_class_comand_line__run_.GUID}
                };

            objOItem_Result = objDBLevel_CommandLineRun.get_Data_Objects(searchRuns);

            OItem_Result_CommandLineRun = objOItem_Result;
        }

        public void GetSubData_002_CommandLineRunTree()
        {
            OItem_Result_CommandLineRunHierarchy = objLocalConfig.Globals.LState_Nothing.Clone();

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchRels = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Parent_Object = objLocalConfig.OItem_class_comand_line__run_.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_comand_line__run_.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID
                        }
                };

            objOItem_Result =
                objDBLevel_CommandLineRunTree.get_Data_ObjectRel(searchRels, boolIDs:false);


            OItem_Result_CommandLineRunHierarchy = objOItem_Result;
                
        }

        private List<clsObjectRel> GetSubNodes(clsObjectRel parentNode)
        {
            var subNodes =
                objDBLevel_CommandLineRunTree.OList_ObjectRel.Where(
                    clrt => clrt.ID_Object == parentNode.ID_Other).ToList();

            return subNodes;
        }

        public void GetSubData_003_CommandLine()
        {
            OItem_Result_CommandLine = objLocalConfig.Globals.LState_Nothing.Clone();

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

           
            var searchCommands = objDBLevel_CommandLineRun.OList_Objects.Select(cmdr => new clsObjectRel
                {
                    ID_Object = cmdr.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_comand_line.GUID
                }).ToList();

            var commandLineRunTree = (from objClr in objDBLevel_CommandLineRun.OList_Objects
                                      join objClrt in objDBLevel_CommandLineRunTree.OList_ObjectRel on objClr.GUID
                                          equals objClrt.ID_Object
                                      select objClrt).ToList();

            var relatedTreeItems = new List<clsObjectRel>();
            var itemCount = 0; 
            while (commandLineRunTree.Count != itemCount)
            {
                itemCount = commandLineRunTree.Count;
                commandLineRunTree.ForEach(clrt => relatedTreeItems.AddRange(GetSubNodes(clrt)));
    
            }
            
            searchCommands.AddRange(from objNewItem in commandLineRunTree
                                    join objOldItem in searchCommands on objNewItem.ID_Object equals objOldItem.ID_Object into objOldItems
                                    from objOldItem in objOldItems.DefaultIfEmpty()
                                    where objOldItem == null
                                    select new clsObjectRel
                                        {
                                            ID_Object = objNewItem.Name_Object,
                                            ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                                            ID_Parent_Other = objLocalConfig.OItem_class_comand_line.GUID
                                        });


            if (searchCommands.Any())
            {
                objOItem_Result = objDBLevel_CommandLine.get_Data_ObjectRel(searchCommands, boolIDs: false);    
                
            }
            else
            {
                objDBLevel_CommandLine.OList_ObjectRel.Clear();
            }
            

            OItem_Result_CommandLine = objOItem_Result;
        }

        public void GetSubData_004_CodeSnipplets()
        {
            OItem_Result_CodeSnipplets = objLocalConfig.Globals.LState_Nothing.Clone();

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchSnipplets = objDBLevel_CommandLineRun.OList_Objects.Select(cmdr => new clsObjectRel
            {
                ID_Object = cmdr.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_code_snipplets.GUID
            }).ToList();

            var commandLineRunTree = (from objClr in objDBLevel_CommandLineRun.OList_Objects
                                      join objClrt in objDBLevel_CommandLineRunTree.OList_ObjectRel on objClr.GUID
                                          equals objClrt.ID_Object
                                      select objClrt).ToList();

            var relatedTreeItems = new List<clsObjectRel>();
            var itemCount = 0;
            while (commandLineRunTree.Count != itemCount)
            {
                itemCount = commandLineRunTree.Count;
                commandLineRunTree.ForEach(clrt => relatedTreeItems.AddRange(GetSubNodes(clrt)));

            }

            searchSnipplets.AddRange(from objNewItem in commandLineRunTree
                                     join objOldItem in searchSnipplets on objNewItem.ID_Object equals objOldItem.ID_Object into objOldItems
                                    from objOldItem in objOldItems.DefaultIfEmpty()
                                    where objOldItem == null
                                    select new clsObjectRel
                                    {
                                        ID_Object = objNewItem.Name_Object,
                                        ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                                        ID_Parent_Other = objLocalConfig.OItem_class_code_snipplets.GUID
                                    });


            if (searchSnipplets.Any())
            {
                objOItem_Result = objDBLevel_CodeSnipplets.get_Data_ObjectRel(searchSnipplets, boolIDs: false);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var searchCode = objDBLevel_CodeSnipplets.OList_ObjectRel.Select(codes => new clsObjectAtt
                        {
                            ID_Object = codes.ID_Other,
                            ID_AttributeType = objLocalConfig.OItem_attributetype_code.GUID
                        }).ToList();

                    objOItem_Result = objDBLevel_Code.get_Data_ObjectAtt(searchCode, boolIDs: false);
                }
            }
            else
            {
                objDBLevel_CodeSnipplets.OList_ObjectRel.Clear();
            }

            OItem_Result_CodeSnipplets = objOItem_Result;

        }

        public void GetSubData_005_Variables()
        {
            OItem_Result_Variables = objLocalConfig.Globals.LState_Nothing.Clone();

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchCommandVars = objDBLevel_CommandLine.OList_ObjectRel.Select(cmdr => new clsObjectRel
            {
                ID_Object = cmdr.ID_Other,
                ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_variable.GUID
            }).ToList();


            
            searchCommandVars.AddRange(from objCodeSnips in objDBLevel_CodeSnipplets.OList_ObjectRel
                                       join search in searchCommandVars on objCodeSnips.ID_Object equals search.ID_Object into searches
                                       from search in searches.DefaultIfEmpty()
                                       where search == null
                                       select new clsObjectRel
                                           {
                                               ID_Object = objCodeSnips.ID_Other,
                                               ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                                               ID_Parent_Other = objLocalConfig.OItem_class_variable.GUID
                                           });

            if (searchCommandVars.Any())
            {
                objOItem_Result = objDBLevel_Variables.get_Data_ObjectRel(searchCommandVars, boolIDs: false);
            }
            else
            {
                objDBLevel_Variables.OList_ObjectRel.Clear();
            }


            OItem_Result_Variables = objOItem_Result;
        }

        public void GetSubData_006_Values()
        {
            OItem_Result_Values = objLocalConfig.Globals.LState_Nothing.Clone();

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchValues = objDBLevel_CommandLineRun.OList_Objects.Select(cmdr => new clsObjectRel
            {
                ID_Object = cmdr.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_needs.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_value.GUID
            }).ToList();

            var commandLineRunTree = (from objClr in objDBLevel_CommandLineRun.OList_Objects
                                      join objClrt in objDBLevel_CommandLineRunTree.OList_ObjectRel on objClr.GUID
                                          equals objClrt.ID_Object
                                      select objClrt).ToList();

            var relatedTreeItems = new List<clsObjectRel>();
            var itemCount = 0;
            while (commandLineRunTree.Count != itemCount)
            {
                itemCount = commandLineRunTree.Count;
                commandLineRunTree.ForEach(clrt => relatedTreeItems.AddRange(GetSubNodes(clrt)));

            }

            searchValues.AddRange(from objNewItem in commandLineRunTree
                                  join objOldItem in searchValues on objNewItem.ID_Object equals objOldItem.ID_Object into objOldItems
                                     from objOldItem in objOldItems.DefaultIfEmpty()
                                     where objOldItem == null
                                     select new clsObjectRel
                                     {
                                         ID_Object = objNewItem.Name_Object,
                                         ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                                         ID_Parent_Other = objLocalConfig.OItem_class_code_snipplets.GUID
                                     });


            if (searchValues.Any())
            {
                objOItem_Result = objDBLevel_Values.get_Data_ObjectRel(searchValues, boolIDs: false);
            
            }
            else
            {
                objDBLevel_Values.OList_ObjectRel.Clear();
            }

            OItem_Result_Values = objOItem_Result;
        }

        public void GetSubData_007_ValueVars()
        {
            OItem_Result_ValueVars = objLocalConfig.Globals.LState_Nothing.Clone();

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchValueVars = objDBLevel_Values.OList_ObjectRel.Select(val => new clsObjectRel
                {
                    ID_Object = val.ID_Other,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_variable.GUID
                }).ToList();

            if (searchValueVars.Any())
            {
                objOItem_Result = objDBLevel_ValueVars.get_Data_ObjectRel(searchValueVars, boolIDs: false);
            }
            else
            {
                objDBLevel_ValueVars.OList_ObjectRel.Clear();
            }

            OItem_Result_ValueVars = objOItem_Result;
        }

        public void GetSubData_008_ValueBelongingSources()
        {
            OItem_Result_ValueBelongingSource = objLocalConfig.Globals.LState_Nothing.Clone();

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchValueBelongingSources = objDBLevel_Values.OList_ObjectRel.Select(val => new clsObjectRel
            {
                ID_Object = val.ID_Other,
                ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID
            }).ToList();

            if (searchValueBelongingSources.Any())
            {
                objOItem_Result = objDBLevel_ValueBelongingSource.get_Data_ObjectRel(searchValueBelongingSources, boolIDs: false);
            }
            else
            {
                objDBLevel_ValueBelongingSource.OList_ObjectRel.Clear();
            }

            OItem_Result_ValueBelongingSource = objOItem_Result;
        }


        private clsOntologyItem CreateFilterListCMDLRs()
        {
            filterList = new List<clsOntologyItem>();

            OItem_Result_Filter = objLocalConfig.Globals.LState_Nothing.Clone();

            if (OItem_Object != null && OItem_Object.GUID_Parent == objLocalConfig.OItem_class_comand_line__run_.GUID)
            {
                OItem_Result_Filter =
                    objDBlevel_CmdlrTreeParam.get_Data_Objects_Tree(objLocalConfig.OItem_class_comand_line__run_,
                                                                    objLocalConfig.OItem_class_comand_line__run_,
                                                                    objLocalConfig.OItem_relationtype_contains);

                if (OItem_Result_Filter.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var objOItem_Object = OItem_Object.Clone();
                    var newItems = new List<clsOntologyItem>();
                    filterList.Add(objOItem_Object);    

                    var count = filterList.Count - 1;

                    while (count != filterList.Count)
                    {
                        count = filterList.Count;
                        if (!newItems.Any())
                        {
                            var cmdlrs =
                                objDBlevel_CmdlrTreeParam.OList_ObjectTree.Where(
                                    treenode => treenode.ID_Object == objOItem_Object.GUID).ToList();

                            if (cmdlrs.Count > 0)
                            {
                                newItems = cmdlrs.Select(cmdrl => new clsOntologyItem
                                {
                                    GUID = cmdrl.ID_Object_Parent,
                                    Name = cmdrl.Name_Object_Parent,
                                    GUID_Parent = objLocalConfig.OItem_class_comand_line__run_.GUID,
                                    Type = objLocalConfig.Globals.Type_Object
                                }).ToList();
                                filterList.AddRange(newItems);
                            }    
                        }
                        else
                        {
                            newItems.ForEach(cmdrl1 =>
                                {
                                    var cmdlrs =
                                        objDBlevel_CmdlrTreeParam.OList_ObjectTree.Where(
                                        treenode => treenode.ID_Object == cmdrl1.GUID).ToList();

                                    if (cmdlrs.Count > 0)
                                    {
                                        newItems = cmdlrs.Select(cmdrl => new clsOntologyItem
                                        {
                                            GUID = cmdrl.ID_Object_Parent,
                                            Name = cmdrl.Name_Object_Parent,
                                            GUID_Parent = objLocalConfig.OItem_class_comand_line__run_.GUID,
                                            Type = objLocalConfig.Globals.Type_Object
                                        }).ToList();
                                        filterList.AddRange(newItems);
                                    }
                                });
                        }
                        
                        
                    }
                    
                }
                
            }
            else
            {
                if ((OItem_Class != null || OItem_RelationType != null || OItem_Object != null) && OItem_Direction != null)
                {
                    AddFilter(OItem_Direction);
                }
                else if ((OItem_Class != null || OItem_RelationType != null || OItem_Object != null) &&
                         OItem_Direction == null)
                {
                    OItem_Result_Filter = AddFilter(objLocalConfig.Globals.Direction_LeftRight.Clone());
                    if (OItem_Result_Filter.GUID != objLocalConfig.Globals.LState_Error.GUID)
                    {
                        OItem_Result_Filter = AddFilter(objLocalConfig.Globals.Direction_RightLeft.Clone());
                    }

                }    
            }
            
            
            
            return OItem_Result_Filter;
        }

        private clsOntologyItem AddFilter(clsOntologyItem OItem_Direction)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Nothing.Clone();
            if (OItem_Class != null || OItem_RelationType != null || OItem_Object != null)
            {
                if (OItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID)
                {
                    var searchRelations = new List<clsObjectRel>
                        {
                            new clsObjectRel
                                {
                                    ID_Other = OItem_Object != null ? OItem_Object.GUID : null,
                                    ID_Parent_Other = OItem_Class != null ? OItem_Class.GUID : null,
                                    ID_RelationType = OItem_RelationType != null ? OItem_RelationType.GUID : null,
                                    ID_Parent_Object = objLocalConfig.OItem_class_comand_line__run_.GUID
                                }
                        };


                    objOItem_Result = objDBLevel_Relations.get_Data_ObjectRel(searchRelations, boolIDs: false);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {

                        filterList.AddRange(objDBLevel_Relations.OList_ObjectRel.Select(rel => new clsOntologyItem
                            {
                                GUID = rel.ID_Object,
                                Name = rel.Name_Object,
                                GUID_Parent = rel.ID_Parent_Object,
                                Type = objLocalConfig.Globals.Type_Object
                            }));
                    }
                    else
                    {
                        filterList.Clear();
                    }

                }
                else
                {
                    var searchRelations = new List<clsObjectRel>
                        {
                            new clsObjectRel
                                {
                                    ID_Object = OItem_Object != null ? OItem_Object.GUID : null,
                                    ID_Parent_Object = OItem_Class != null ? OItem_Class.GUID : null,
                                    ID_RelationType = OItem_RelationType != null ? OItem_RelationType.GUID : null,
                                    ID_Parent_Other = objLocalConfig.OItem_class_comand_line__run_.GUID
                                }
                        };


                    objOItem_Result = objDBLevel_Relations.get_Data_ObjectRel(searchRelations, boolIDs: false);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        filterList.AddRange(objDBLevel_Relations.OList_ObjectRel.Select(rel => new clsOntologyItem
                            {
                                GUID = rel.ID_Other,
                                Name = rel.Name_Other,
                                GUID_Parent = rel.ID_Parent_Other,
                                Type = objLocalConfig.Globals.Type_Object
                            }));
                    }
                    else
                    {
                        filterList.Clear();
                    }

                }
            }

            return objOItem_Result;
        }

        public void GetSubData_009_Codes()
        {
            OItem_Result_Codes = objLocalConfig.Globals.LState_Nothing.Clone();
            Codes = new List<clsCode>();
            var variables = new List<clsObjectRel>();

            List<clsOntologyItem> cmdrls;
            
            if (OItem_Result_Filter.GUID != objLocalConfig.Globals.LState_Error.GUID)
            {
                if (OItem_Result_Filter.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    cmdrls = (from objCmdrls in objDBLevel_CommandLineRun.OList_Objects
                              join objFilter in filterList on objCmdrls.GUID equals objFilter.GUID
                              select objCmdrls).ToList();

                }
                else
                {
                    cmdrls = objDBLevel_CommandLineRun.OList_Objects;
                }
                
                cmdrls.ForEach(cmlr =>
                {
                    var commandLines =
                        objDBLevel_CommandLine.OList_ObjectRel.Where(cmd => cmd.ID_Object == cmlr.GUID).OrderBy(cmd => cmd.OrderID).ToList();

                    variables.AddRange(from commandLine in commandLines
                                     join var in objDBLevel_Variables.OList_ObjectRel on commandLine.ID_Other equals
                                         var.ID_Object
                                     select var);

                    Codes.AddRange(commandLines.Select(
                        cmd =>
                        new clsCode
                            {
                                ID_CommandLineRun = cmd.ID_Object,
                                ID_CodeItem = cmd.ID_Other,
                                Code = cmd.Name_Other
                            }));


                    var codeSnipplets =
                        (from codeSnipplet in
                             objDBLevel_CodeSnipplets.OList_ObjectRel.Where(codes => codes.ID_Object == cmlr.GUID).OrderBy(codes => codes.OrderID)
                                                     .ToList()
                         join code in objDBLevel_Code.OList_ObjectAtt on codeSnipplet.ID_Other equals code.ID_Object
                         select code).ToList();

                    variables.AddRange(from codes in codeSnipplets
                                       join var in objDBLevel_Variables.OList_ObjectRel on codes.ID_Object equals
                                           var.ID_Object
                                       join variable in variables on var.ID_Other equals variable.ID_Other into variables2
                                       from variable in variables2.DefaultIfEmpty()
                                       where variable == null
                                       select var);

                    Codes.AddRange(codeSnipplets.Select(cmd =>
                            new clsCode
                            {
                                ID_CommandLineRun = cmd.ID_Object,
                                ID_CodeItem = cmd.ID_Object,
                                Code = cmd.Val_String
                            }));

                });

            Codes.ForEach(code =>
                {
                    code.CodeParsed = code.Code;
                    
                    var variablesCode = variables.Where(var => var.ID_Object == code.ID_CodeItem).ToList();
                    var commandLineRunVals =
                        objDBLevel_Values.OList_ObjectRel.Where(val => val.ID_Object == code.ID_CommandLineRun).ToList();
                    var variableValues = (from codeValue in commandLineRunVals
                                          join valVar in objDBLevel_ValueVars.OList_ObjectRel on codeValue.ID_Other equals  valVar.ID_Object
                                          join valBelongingSource in objDBLevel_ValueBelongingSource.OList_ObjectRel on
                                              valVar.ID_Object equals valBelongingSource.ID_Object into
                                              valBelongingSources
                                          from valBelongingSource in valBelongingSources.DefaultIfEmpty()
                                          join variable in variablesCode on valVar.ID_Other equals variable.ID_Other
                                          select new {valVar, valBelongingSource, variable}).ToList();

                    variableValues.ForEach(varVal => code.CodeParsed = code.CodeParsed.Replace("@" + varVal.valVar.Name_Other + "@",varVal.valBelongingSource != null ? varVal.valBelongingSource.Name_Other : varVal.valVar.Name_Object));
                });
                OItem_Result_Codes = objLocalConfig.Globals.LState_Success.Clone();
            }
            else
            {
                OItem_Result_Codes = objLocalConfig.Globals.LState_Error.Clone();
            }
            

            
        }

        public List<clsObjectRel> GetSubCmdlrs(clsOntologyItem OItem_Cmdlr)
        {
            var subCmdlrs =
                objDBLevel_CommandLineRunTree.OList_ObjectRel.Where(cmdlr => cmdlr.ID_Object == OItem_Cmdlr.GUID).OrderBy(cmdlr=> cmdlr.OrderID)
                                             .ToList();

            var subCmdrls_deeper = new List<clsObjectRel>();
            subCmdlrs.ForEach(
                cmdrls => subCmdrls_deeper.AddRange(GetSubCmdlrs(new clsOntologyItem 
                {
                    GUID = cmdrls.ID_Other,
                    Name = cmdrls.Name_Other
                })));

            subCmdlrs.AddRange(subCmdrls_deeper);

            return subCmdlrs;
        }

        public clsOntologyItem FillSubNodes(TreeNode treeNodeParent)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            if (treeNodeParent.Name == objLocalConfig.Globals.Root.GUID)
            {
                List<clsOntologyItem> cmdrls;
                if (OItem_Result_Filter.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    cmdrls = (from cmdrl in objDBLevel_CommandLineRun.OList_Objects
                              join objFilter in filterList on cmdrl.GUID equals  objFilter.GUID
                              join cmdrlTree in objDBLevel_CommandLineRunTree.OList_ObjectRel on cmdrl.GUID equals
                                  cmdrlTree.ID_Other into cmdrlsTree
                              from cmdrlTree in cmdrlsTree.DefaultIfEmpty()
                              where cmdrlTree == null
                              select cmdrl).OrderBy(cmdrl => cmdrl.Name).ToList();    
                }
                else
                {
                    cmdrls = (from cmdrl in objDBLevel_CommandLineRun.OList_Objects
                              join cmdrlTree in objDBLevel_CommandLineRunTree.OList_ObjectRel on cmdrl.GUID equals
                                  cmdrlTree.ID_Other into cmdrlsTree
                              from cmdrlTree in cmdrlsTree.DefaultIfEmpty()
                              where cmdrlTree == null
                              select cmdrl).OrderBy(cmdrl => cmdrl.Name).ToList();    
                }

                RootNodeCount = 0;
                RootNodeCount += cmdrls.Count;
                cmdrls.ForEach(cmdrl =>
                    {
                        var treeNode = treeNodeParent.Nodes.Add(cmdrl.GUID, cmdrl.Name);
                        FillSubNodes(treeNode);
                    });
            }
            else
            {
                var cmdrls =
                    objDBLevel_CommandLineRunTree.OList_ObjectRel.Where(tree => tree.ID_Object == treeNodeParent.Name)
                                                 .OrderBy(cmdrl => cmdrl.OrderID).ThenBy(cmdrl => cmdrl.Name_Other).ToList();

                RootNodeCount += cmdrls.Count;
                cmdrls.ForEach(cmdrl =>
                {
                    var treeNode = treeNodeParent.Nodes.Add(cmdrl.ID_Other, cmdrl.Name_Other);
                    FillSubNodes(treeNode);
                });
            }

            return objOItem_Result;
        }

        public clsDataWork_CommandLineRun(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_CommandLineRun = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_CommandLineRunTree = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_CommandLine = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Variables = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_CodeSnipplets = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Code = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Values = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ValueVars = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ValueBelongingSource = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Relations = new clsDBLevel(objLocalConfig.Globals);
            objDBlevel_CmdlrTreeParam = new clsDBLevel(objLocalConfig.Globals);
            objDBlevel_OItem = new clsDBLevel(objLocalConfig.Globals);

            OItem_CommandLineRun_Entry = null;
            OItem_Result_CommandLineRun = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_CommandLineRunHierarchy = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_CommandLine = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_CodeSnipplets = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_Variables = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_Values = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_ValueVars = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_ValueBelongingSource = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_Codes = objLocalConfig.Globals.LState_Nothing.Clone();
        }
    }
}
