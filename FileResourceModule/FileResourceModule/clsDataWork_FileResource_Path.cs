using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace FileResourceModule
{
    public class clsDataWork_FileResource_Path
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_Attributes;
        private clsDBLevel objDBLevel_Relations;

        public clsOntologyItem OItem_Result_Attributes { get; set; }
        public clsOntologyItem OItem_Result_Relations { get; set; }
        public clsOntologyItem OItem_Result_FileResult { get; set; }

        public List<clsFile> FileList { get; set; }

        public clsObjectAtt objOAItem_Pattern { get; set; }
        public clsObjectAtt objOAItem_SubItems { get; set; }

        public clsObjectRel objORItem_Path { get; set; }

        public void GetData_Attributes(clsOntologyItem OItem_FileResource)
        {
            OItem_Result_Attributes = objLocalConfig.Globals.LState_Nothing.Clone();

            var objORelS_FileResource_Attributes = new List<clsObjectAtt>
                {
                    new clsObjectAtt
                        {
                            ID_AttributeType = objLocalConfig.OItem_attributetype_pattern.GUID,
                            ID_Object = OItem_FileResource.GUID
                        },
                    new clsObjectAtt
                        {
                            ID_AttributeType = objLocalConfig.OItem_attributetype_subitems.GUID,
                            ID_Object = OItem_FileResource.GUID
                        }
                };

            var objOItem_Result = objDBLevel_Attributes.get_Data_ObjectAtt(objORelS_FileResource_Attributes,
                                                                           boolIDs: false);

            objOAItem_Pattern = null;
            objOAItem_SubItems = null;

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var objOA_Pattern =
                    objDBLevel_Attributes.OList_ObjectAtt.Where(
                        oa => oa.ID_AttributeType == objLocalConfig.OItem_attributetype_pattern.GUID).ToList();

                if (objOA_Pattern.Any())
                {
                    objOAItem_Pattern = new clsObjectAtt
                        {
                            ID_Attribute = objOA_Pattern.First().ID_Attribute,
                            ID_AttributeType = objLocalConfig.OItem_attributetype_pattern.GUID,
                            ID_Object = objOA_Pattern.First().ID_Object,
                            ID_Class = objOA_Pattern.First().ID_Class,
                            Val_Named = objOA_Pattern.First().Val_Named,
                            Val_String = objOA_Pattern.First().Val_String
                        };
                }

                var objOA_SubItems =
                    objDBLevel_Attributes.OList_ObjectAtt.Where(
                        oa => oa.ID_AttributeType == objLocalConfig.OItem_attributetype_subitems.GUID).ToList();

                if (objOA_SubItems.Any())
                {
                    objOAItem_SubItems = new clsObjectAtt
                        {
                            ID_Attribute = objOA_SubItems.First().ID_Attribute,
                            ID_AttributeType = objLocalConfig.OItem_attributetype_subitems.GUID,
                            ID_Object = objOA_SubItems.First().ID_Object,
                            ID_Class = objOA_SubItems.First().ID_Class,
                            Val_Named = objOA_SubItems.First().Val_Named,
                            Val_Bit = objOA_SubItems.First().Val_Bit
                        };
                }
            }

            OItem_Result_Attributes = objOItem_Result;
        }

        public void GetData_Relations(clsOntologyItem OItem_FileResource)
        {
            OItem_Result_Relations = objLocalConfig.Globals.LState_Nothing.Clone();
            objORItem_Path = null;

            var objORelS_Relations = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Object = OItem_FileResource.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_path.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_belonging_resource.GUID
                        }
                };

            var objOItem_Result = objDBLevel_Relations.get_Data_ObjectRel(objORelS_Relations, boolIDs: false);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objORItem_Path = new clsObjectRel
                    {
                        ID_Object = objDBLevel_Attributes.OList_ObjectRel.First().ID_Object,
                        ID_Parent_Object = objDBLevel_Attributes.OList_ObjectRel.First().ID_Parent_Object,
                        ID_Other = objDBLevel_Attributes.OList_ObjectRel.First().ID_Other,
                        ID_Parent_Other = objDBLevel_Attributes.OList_ObjectRel.First().ID_Parent_Other,
                        ID_RelationType = objDBLevel_Attributes.OList_ObjectRel.First().ID_RelationType,
                        OrderID = objDBLevel_Attributes.OList_ObjectRel.First().OrderID,
                        Ontology = objDBLevel_Attributes.OList_ObjectRel.First().Ontology
                    };


            }

            OItem_Result_Relations = objOItem_Result;
        }

        public void GetFiles()
        {
            FileList = new List<clsFile>();

            if (objORItem_Path != null)
            {
                var strPath = objORItem_Path.Name_Other;
                strPath = Environment.ExpandEnvironmentVariables(strPath);

                var boolSubItems = false;

                if (objOAItem_SubItems != null)
                {
                    boolSubItems = objOAItem_SubItems.Val_Bit ?? false;
                }

                var strPattern = "";

                if (objOAItem_Pattern != null)
                {
                    strPattern = objOAItem_Pattern.Val_String;
                }

                GetFilesLoc(strPath, boolSubItems, strPattern);

                if (OItem_Result_FileResult.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
                {
                    OItem_Result_FileResult = objLocalConfig.Globals.LState_Success.Clone();
                }

            }
            else
            {
                OItem_Result_FileResult = objLocalConfig.Globals.LState_Relation.Clone();
            }

        }

        public void GetFilesLoc(string strPath, bool boolSubItems, string strPattern)
        {
            OItem_Result_FileResult = objLocalConfig.Globals.LState_Nothing.Clone();

            if (System.IO.Directory.Exists(strPath))
            {
                foreach (var strFile in System.IO.Directory.GetFiles(strPath))
                {
                    var objFile = new clsFile {FileName = strFile};

                    if (strPattern != "")
                    {
                        try
                        {
                            var objRegEx = new System.Text.RegularExpressions.Regex(strPattern);
                            if (objRegEx.Match(strFile).Success)
                            {
                                FileList.Add(objFile);
                            }
                        }
                        catch (Exception)
                        {

                            OItem_Result_FileResult = objLocalConfig.Globals.LState_Error.Clone();
                        }
                    }
                }

                if (OItem_Result_FileResult.GUID == objLocalConfig.Globals.LState_Nothing.GUID && boolSubItems)
                {
                    foreach (var strDirectory in System.IO.Directory.GetDirectories(strPath))
                    {
                        GetFilesLoc(strDirectory,boolSubItems,strPattern);
                    }
                }
            }
            else
            {
                OItem_Result_FileResult = objLocalConfig.Globals.LState_Error.Clone();
            }
        }

        public clsDataWork_FileResource_Path(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        public void Initialize()
        {
            OItem_Result_Attributes = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_Relations = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_FileResult = objLocalConfig.Globals.LState_Nothing.Clone();

            objDBLevel_Attributes = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Relations = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
