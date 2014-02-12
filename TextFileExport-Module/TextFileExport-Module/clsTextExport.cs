using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using Filesystem_Module;
using System.Text.RegularExpressions;

namespace TextFileExport_Module
{
    public class clsTextExport
    {
        public clsDataWork_TextExport objDataWork_TextExport;
        private clsDataWork_Ontologies objDataWork_Ontologies;
        public clsOntologyItem OItem_TextFileExport { get; private set; }
        private clsLocalConfig objLocalConfig;

        private clsDataWork_Base objDataWork_Base;
        private clsFileWork objFileWork;
        private List<clsOntologyItem> OList_Folders;
        private List<clsObjectRel> OList_OntologyiesOfTextFileParts;
        private List<clsOntologyJoins> OList_OntologyJoinsOfOntologies;
        private clsOntologyItem objOItem_MainObject;
        private List<clsHierarchicalList> OList_HierarchicalList;
        private StringBuilder text;

        public void RegisterHierarchicalList(List<clsObjectTree> OList_Hierarchical, clsOntologyItem OItem_Class_Left, clsOntologyItem OItem_Class_Right, clsOntologyItem OItem_RelationType, clsOntologyItem OItem_Root)
        {

            if (OList_HierarchicalList == null)
            {
                OList_HierarchicalList = new List<clsHierarchicalList>();
                
            }

            OList_HierarchicalList.Add(new clsHierarchicalList
            {
                ID_Class_Left = OItem_Class_Left.GUID,
                Name_Class_Left = OItem_Class_Left.Name,
                ID_Class_Right = OItem_Class_Right.GUID,
                Name_Class_Right = OItem_Class_Right.Name,
                ID_RelationType = OItem_RelationType.GUID,
                Name_RelationType = OItem_RelationType.Name,
                OList_Tree = OList_Hierarchical,
                OItem_Root = OItem_Root
            });

        }

        public void RegisterMainObject(clsOntologyItem OItem_Main)
        {
            objOItem_MainObject = OItem_Main;
        }

        public void TestExport()
        {

            var objOItem_Process = new clsOntologyItem
            {
                GUID = "91038b8bb5ca4f568f522c87958616a3",
                Name = "Wamp Server",
                GUID_Parent = "2c1f5b9721e544ca95d243008011c14d",
                Type = objLocalConfig.Globals.Type_Object
            };

            var objDBLevel_ProcessTree = new clsDBLevel(objLocalConfig.Globals);

            var objOItem_Class_Process = new clsOntologyItem
            {
                GUID = "2c1f5b9721e544ca95d243008011c14d",
                Name = "Process",
                Type = objLocalConfig.Globals.Type_Class
            };

            var objOItem_RelationType_Superordinate = new clsOntologyItem
            {
                GUID = "eb05244b4e494808b81b995f3ee6065a",
                Name = "superordinate",
                Type = objLocalConfig.Globals.Type_RelationType
            };

            var objOItem_TextFile = new clsOntologyItem
            {
                GUID = "ac2932dd9b304891a7cac137420923ec",
                Name = "Processes",
                GUID_Parent = "eaa0d1cfd47e4e56b0e5c722a63a12b6",
                Type = objLocalConfig.Globals.Type_Object
            };


            var objOItem_Result = objDBLevel_ProcessTree.get_Data_Objects_Tree(objOItem_Class_Process, objOItem_Class_Process, objOItem_RelationType_Superordinate);

            objOItem_Result = objDataWork_TextExport.GetData(objOItem_TextFile);

            OList_Folders = objDataWork_TextExport.OList_FoldersOfTextFile.Select(tf => new clsOntologyItem
            {
                GUID = tf.ID_Other,
                Name = tf.Name_Other,
                GUID_Parent = tf.ID_Parent_Other,
                Type = objLocalConfig.Globals.Type_Object,
                Additional1 = objFileWork.get_Path_FileSystemObject(new clsOntologyItem
                {
                    GUID = tf.ID_Other,
                    Name = tf.Name_Other,
                    GUID_Parent = tf.ID_Parent_Other,
                    Type = objLocalConfig.Globals.Type_Object
                })
            }).ToList();

            if (objDataWork_TextExport.OList_Templates.Any())
            {
                text = new StringBuilder(objDataWork_TextExport.OList_Templates.First().Val_String);

                objOItem_Result = GetOntologyItems();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    RegisterHierarchicalList(objDBLevel_ProcessTree.OList_ObjectTree,objOItem_Class_Process, objOItem_Class_Process,objOItem_RelationType_Superordinate, objOItem_Process);
                    RegisterMainObject(objOItem_Process);

                    foreach (var objVar in objDataWork_TextExport.OList_TemplateVars)
                    {
                        if (objVar.Name_Other.StartsWith(objLocalConfig.OItem_object_field.Name + ":"))
                        {
                            var strField = objVar.Name_Other.Substring((objLocalConfig.OItem_object_field.Name + ":").Length);
                            if (strField.ToLower() == "name")
                            {
                                text.Replace("@" + objVar.Name_Other + "@", objOItem_MainObject.Name);

                                
                            }
                        }
                        else if (objVar.Name_Other.StartsWith(objLocalConfig.OItem_object_part.Name + ":"))
                        {
                            

                            var strPart = objVar.Name_Other.Substring((objLocalConfig.OItem_object_part.Name + ":").Length);

                            var oList_TextFileParts = objDataWork_TextExport.OList_TextFileParts.Where(tp => tp.Name_Other == strPart).ToList();

                            if (oList_TextFileParts.Any())
                            {
                                var oList_HierarchicalType = (from objTextFilePart in oList_TextFileParts
                                                              join objTextFilePartType in objDataWork_TextExport.OList_TextFilePart_Type on objTextFilePart.ID_Other equals objTextFilePartType.ID_Object
                                                              where objTextFilePartType.ID_Other == objLocalConfig.OItem_object_hierarchical.GUID
                                                              select objTextFilePart).ToList();

                                List<clsHierarchicalList> OList_HierarchicalSel = null;

                                if (oList_HierarchicalType.Any())
                                {
                                    var oList_OntologyJoin = (from objOntology in OList_OntologyiesOfTextFileParts
                                                              join objTextFilePart in oList_TextFileParts on objOntology.ID_Other equals objTextFilePart.ID_Other
                                                              join objOntologyJoin in OList_OntologyJoinsOfOntologies on objOntology.ID_Object equals objOntologyJoin.ID_Ontology
                                                              select objOntologyJoin).ToList();

                                    OList_HierarchicalSel = (from objOJoin in oList_OntologyJoin
                                                             join objHierarchical in OList_HierarchicalList on
                                                                new { ID_Left = objOJoin.ID_OItem1, ID_Right = objOJoin.ID_OItem2, ID_RelationType = objOJoin.ID_OItem3 } equals
                                                                new { ID_Left = objHierarchical.ID_Class_Left, ID_Right = objHierarchical.ID_Class_Right, ID_RelationType = objHierarchical.ID_RelationType }
                                                             select objHierarchical).ToList();

                                    if (OList_HierarchicalSel.Any())
                                    {
                                        var textPartFile = ReplaceTextPartHierarchical(strPart, OList_HierarchicalSel.First(), OList_HierarchicalSel.First().OItem_Root);
                                        text.Replace("@" + objVar.Name_Other + "@", textPartFile.ToString());
                                    }
                                    else
                                    {

                                    }
                                    
                                }
                                else
                                {
                                    //var textPartFile = ReplaceTextPart(strPart);
                                }



                                
                            }
                            

                            
                        }
                        else if (objVar.Name_Other.StartsWith(objLocalConfig.OItem_object_config.Name + ":"))
                        {
                            var strConfig = objVar.Name_Other.Substring((objLocalConfig.OItem_object_config.Name + ":").Length);
                            text = ReplaceConfig(text,objDataWork_TextExport.OList_Config,objDataWork_TextExport.OList_ConfigValue, strConfig,objVar.Name_Other);
                            
                        }
                    }
                }
            }

            
        }

        private StringBuilder ReplaceTextPartHierarchical(string strPart, clsHierarchicalList OList_Hierarchy, clsOntologyItem OItem_Root, int level = 1)
        {
            StringBuilder textTextPart = null;

            var oList_TextFileParts = objDataWork_TextExport.OList_TextFileParts.Where(tp => tp.Name_Other == strPart).ToList();

            if (oList_TextFileParts.Any())
            {
                var template = (from objTextFilePart in objDataWork_TextExport.OList_TextFilePart_To_Template
                                where objTextFilePart.ID_Object == oList_TextFileParts.First().ID_Other
                                join objTemplate in objDataWork_TextExport.OList_TextFilePart_Templates on objTextFilePart.ID_Other equals objTemplate.ID_Object
                                select objTemplate).ToList();

                if (template.Any())
                {
                    textTextPart = new StringBuilder(template.First().Val_String);

                    var templateVars = (from objTextFilePart in objDataWork_TextExport.OList_TextFilePart_To_Template
                                        where objTextFilePart.ID_Object == oList_TextFileParts.First().ID_Other
                                        join objTemplateVar in objDataWork_TextExport.OList_TextFilePart_TemplateVars on objTextFilePart.ID_Other equals objTemplateVar.ID_Object
                                        select objTemplateVar).ToList();

                    foreach (var objTextPartVar in templateVars)
                    {
                        if (objTextPartVar.Name_Other.StartsWith(objLocalConfig.OItem_object_field.Name + ":"))
                        {
                            var strField = objTextPartVar.Name_Other.Substring((objLocalConfig.OItem_object_field.Name + ":").Length);
                            if (strField.ToLower() == "name")
                            {
                                textTextPart.Replace("@" + objTextPartVar.Name_Other + "@", OItem_Root.Name);


                            }
                        }
                        else if (objTextPartVar.Name_Other.StartsWith(objLocalConfig.OItem_object_part.Name + ":"))
                        {

                            if (oList_TextFileParts.Any())
                            {
                                List<clsHierarchicalList> OList_HierarchicalSel = null;
                                var oList_HierarchicalType = (from objTextFilePart in oList_TextFileParts
                                                              join objTextFilePartType in objDataWork_TextExport.OList_TextFilePart_Type on objTextFilePart.ID_Other equals objTextFilePartType.ID_Object
                                                              where objTextFilePartType.ID_Other == objLocalConfig.OItem_object_hierarchical.GUID
                                                              select objTextFilePart).ToList();

                                if (oList_HierarchicalType.Any())
                                {
                                    var oList_OntologyJoin = (from objOntology in OList_OntologyiesOfTextFileParts
                                                              join objTextFilePart in oList_TextFileParts on objOntology.ID_Other equals objTextFilePart.ID_Other
                                                              join objOntologyJoin in OList_OntologyJoinsOfOntologies on objOntology.ID_Object equals objOntologyJoin.ID_Ontology
                                                              select objOntologyJoin).ToList();

                                    OList_HierarchicalSel = (from objOJoin in oList_OntologyJoin
                                                             join objHierarchical in OList_HierarchicalList on
                                                                new { ID_Left = objOJoin.ID_OItem1, ID_Right = objOJoin.ID_OItem2, ID_RelationType = objOJoin.ID_OItem3 } equals
                                                                new { ID_Left = objHierarchical.ID_Class_Left, ID_Right = objHierarchical.ID_Class_Right, ID_RelationType = objHierarchical.ID_RelationType }
                                                             select objHierarchical).ToList();

                                    if (OList_HierarchicalSel.Any())
                                    {
                                        if (OList_HierarchicalSel.First().ID_Class_Left == OList_Hierarchy.ID_Class_Left &&
                                            OList_HierarchicalSel.First().ID_Class_Right == OList_Hierarchy.ID_Class_Right &&
                                            OList_HierarchicalSel.First().ID_RelationType == OList_Hierarchy.ID_RelationType)
                                        {
                                            var strPartSub = objTextPartVar.Name_Other.Substring((objLocalConfig.OItem_object_part.Name + ":").Length);

                                            var OList_Children = OList_Hierarchy.OList_Tree.Where(t => t.ID_Object_Parent == OItem_Root.GUID).Select(t => new clsOntologyItem
                                            {
                                                GUID = t.ID_Object,
                                                Name = t.Name_Object,
                                                GUID_Parent = t.ID_Parent,
                                                Type = objLocalConfig.Globals.Type_Object
                                            }).ToList();
                                            var textPart = new StringBuilder();
                                            foreach (var oChild in OList_Children)
                                            {
                                                textPart.Append(ReplaceTextPartHierarchical(strPartSub, OList_Hierarchy, oChild, level + 1).ToString());
                                            }

                                            textTextPart.Replace("@" + objTextPartVar.Name_Other + "@", textPart.ToString());

                                            var functiontags = objDataWork_Base.OList_FunctionTags.Where(ft => ft.ID_FunctionTag == objLocalConfig.OItem_object_remove_if_empty.GUID).ToList();

                                            if (OList_Children.Any())
                                            {
                                                textTextPart.Replace(functiontags.First().Name_FunctionTagStart, "");
                                                textTextPart.Replace(functiontags.First().Name_FunctionTagEnd, "");

                                            }
                                            else
                                            {
                                                textTextPart = new StringBuilder(Regex.Replace(textTextPart.ToString(), functiontags.First().Name_FunctionTagStart + ".*" + functiontags.First().Name_FunctionTagEnd, ""));
                                            }
                                        }
                                        else
                                        {

                                        }
                                        
                                    }
                                    else
                                    {

                                    }

                                }
                                else
                                {
                                    //var textPartFile = ReplaceTextPart(strPart);
                                }




                            }

                            

                           


                        }
                        else if (objTextPartVar.Name_Other.StartsWith(objLocalConfig.OItem_object_config.Name + ":"))
                        {
                            var strConfig = objTextPartVar.Name_Other.Substring((objLocalConfig.OItem_object_config.Name + ":").Length);
                            textTextPart = ReplaceConfig(textTextPart, objDataWork_TextExport.OList_TextFilePart_Config, objDataWork_TextExport.OList_TextFilePart_ConfigValue, strConfig, objTextPartVar.Name_Other);

                        }
                        else if (objTextPartVar.Name_Other == objLocalConfig.OItem_object_var_level.Name)
                        {
                            textTextPart.Replace("@" + objLocalConfig.OItem_object_var_level.Name + "@", level.ToString());
                        }
                    }
                }
                
            }
            var functiontags1 = objDataWork_Base.OList_FunctionTags.Where(ft => ft.ID_FunctionTag == objLocalConfig.OItem_object_remove_if_empty.GUID).ToList();
            textTextPart = new StringBuilder(Regex.Replace(textTextPart.ToString(), functiontags1.First().Name_FunctionTagStart + ".*" + functiontags1.First().Name_FunctionTagEnd, ""));

            return textTextPart;
        }

        private StringBuilder ReplaceConfig(StringBuilder text, List<clsObjectRel> OList_Config, List<clsObjectRel> OList_ConfigValue, string strConfig, string strVar)
        {
            
            var strConfigValue = "";
            var oList_Config = (from objConfig in OList_Config.Where(c => c.Name_Other == strConfig).ToList()
                                join objRef in OList_ConfigValue on objConfig.ID_Other equals objRef.ID_Object into objRefs
                                from objRef in objRefs.DefaultIfEmpty()
                                select new
                                {
                                    Config = objConfig,
                                    Ref = objRef
                                }).ToList();

            if (oList_Config.Any())
            {
                if (oList_Config.First().Ref != null)
                {
                    strConfigValue = oList_Config.First().Ref.Name_Other;
                }
                else
                {
                    strConfigValue = oList_Config.First().Config.Name_Other;
                }
            }

            text.Replace("@" + strVar + "@", strConfigValue);

            return text;
        }
        private clsOntologyItem GetOntologyItems()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            objOItem_Result = objDataWork_Ontologies.GetData_BaseData();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_OntologyiesOfTextFileParts = (from objTextFilePart in objDataWork_TextExport.OList_TextFileParts
                                                    join objOntologies in objDataWork_Ontologies.OList_RefsOfOntologies on objTextFilePart.ID_Other equals objOntologies.ID_Other
                                                    select objOntologies).ToList();

                OList_OntologyJoinsOfOntologies = (from objOntologyJoin in objDataWork_Ontologies.OList_OntologyJoins
                                                   join objOntology in OList_OntologyiesOfTextFileParts on objOntologyJoin.ID_Ontology equals objOntology.ID_Object
                                                   select objOntologyJoin).ToList();

            }
            else
            {
                OList_OntologyiesOfTextFileParts = null;
                OList_OntologyJoinsOfOntologies = null;

            }

            return objOItem_Result;
        }

        public clsTextExport(clsLocalConfig LocalConfig, clsOntologyItem OItem_TextFileExport)
        {
            objLocalConfig = LocalConfig;
            this.OItem_TextFileExport = OItem_TextFileExport;
            Initialize();
        }

        private void Initialize()
        {
            objFileWork = new clsFileWork(objLocalConfig.Globals);
            objDataWork_TextExport = new clsDataWork_TextExport(objLocalConfig);
            objDataWork_Ontologies = new clsDataWork_Ontologies(objLocalConfig.Globals);
            objDataWork_Base = new clsDataWork_Base(objLocalConfig);
            if (objDataWork_Base.GetFunctionTags().GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                throw new Exception("Config-Error");
            }

        }
    }
}
