using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace TextFileExport_Module
{
    public class clsDataWork_TextExport
    {
        private clsLocalConfig objLocalConfig;

        private clsDataWork_TextTemplates objDataWork_TextTemplates;
        private clsDataWork_Config objDataWork_Config;
        private clsDataWork_TextfileParts objDataWork_TextFileParts;

        private clsDBLevel objDBLevel_TextFiles;
        private clsDBLevel objDBLevel_TextFiles_ExportTo_Folder;

        public clsOntologyItem OItem_TextFile { get; set; }

        public clsOntologyItem OItem_Result_TextFiles { get; private set; }
        public clsOntologyItem OItem_Result_TextParts { get; private set; }

        public List<clsObjectRel> OList_FoldersOfTextFile
        {
            get { return objDBLevel_TextFiles_ExportTo_Folder.OList_ObjectRel; }
        }

        public List<clsObjectAtt> OList_Templates
        {
            get { return objDataWork_TextTemplates.OList_TextTemplates; }
        }

        public List<clsObjectRel> OList_TemplateVars
        {
            get { return objDataWork_TextTemplates.OList_TextTemplates_To_Variables; }
        }

        public List<clsObjectRel> OList_TextFileParts
        {
            get { return objDataWork_TextFileParts.OList_Ref_To_TextFileParts; }
        }

        public List<clsObjectRel> OList_TextFilePart_To_Template
        {
            get { return objDataWork_TextFileParts.OList_TextFilePart_To_Template; }
        }

        public List<clsObjectAtt> OList_TextFilePart_Templates
        {
            get { return objDataWork_TextFileParts.OList_TextTemplates; }
        }

        public List<clsObjectRel> OList_TextFilePart_TemplateVars
        {
            get { return objDataWork_TextFileParts.OList_TemplateVars; }
        }

        public List<clsObjectRel> OList_TextFilePart_Config
        {
            get { return objDataWork_TextFileParts.OList_Config; }
        }

        public List<clsObjectRel> OList_TextFilePart_ConfigValue
        {
            get { return objDataWork_TextFileParts.OList_ConfigValue; }
        }

        public List<clsObjectRel> OList_Config
        {
            get { return objDataWork_Config.OList_Ref_To_Value; }
        }

        public List<clsObjectRel> OList_ConfigValue
        {
            get { return objDataWork_Config.OList_Value_To_Source; }
        }

        public List<clsObjectRel> OList_TextFilePart_Type
        {
            get { return objDataWork_TextFileParts.OList_Type; }
        }


        public clsOntologyItem GetData(clsOntologyItem OItem_TextFile)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            this.OItem_TextFile = OItem_TextFile;

            GetData_001_TextFile();
            objOItem_Result = OItem_Result_TextFiles;
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                GetData_002_TextFileParts();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {

                }
            }

            return objOItem_Result;
        }

        public void GetData_001_TextFile()
        {
            this.OItem_TextFile = OItem_TextFile;
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objOListS_TextFiles = new List<clsOntologyItem> 
            { 
                new clsOntologyItem 
                {
                    GUID = OItem_TextFile != null ? OItem_TextFile.GUID:null,
                    GUID_Parent = objLocalConfig.OItem_class_textfile.GUID
                }
            };

            objOItem_Result = objDBLevel_TextFiles.get_Data_Objects(objOListS_TextFiles);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_TextFiles.OList_Objects.Any())
                {
                    var objOListS_TextFiles_To_Folder = objDBLevel_TextFiles.OList_Objects.Select(tf => new clsObjectRel
                    {
                        ID_Object = tf.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_export_to.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_folder.GUID
                    }).ToList();

                    objOItem_Result = objDBLevel_TextFiles_ExportTo_Folder.get_Data_ObjectRel(objOListS_TextFiles_To_Folder, boolIDs: false);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objOItem_Result =  objDataWork_TextTemplates.GetData(objDBLevel_TextFiles.OList_Objects, objLocalConfig.OItem_relationtype_needs);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objOItem_Result = objDataWork_Config.GetData(objDBLevel_TextFiles.OList_Objects, objLocalConfig.OItem_relationtype_config);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                objOItem_Result = objDataWork_TextFileParts.GetData(objDBLevel_TextFiles.OList_Objects, objLocalConfig.OItem_relationtype_contains);
                            }
                        }
                    }
                }
                else
                {
                    objDBLevel_TextFiles_ExportTo_Folder.OList_ObjectRel.Clear();
                }
                
 
            }



            OItem_Result_TextFiles = objOItem_Result;
        }

        public void GetData_002_TextFileParts()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            OItem_Result_TextParts = objOItem_Result;
        }

        

        public clsDataWork_TextExport(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_TextFiles = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_TextFiles_ExportTo_Folder = new clsDBLevel(objLocalConfig.Globals);
            objDataWork_TextTemplates = new clsDataWork_TextTemplates(objLocalConfig);
            objDataWork_TextTemplates = new clsDataWork_TextTemplates(objLocalConfig);
            objDataWork_Config = new clsDataWork_Config(objLocalConfig);
            objDataWork_Config = new clsDataWork_Config(objLocalConfig);
            objDataWork_TextFileParts = new clsDataWork_TextfileParts(objLocalConfig);
        }
    }
}
