using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace TextFileExport_Module
{
    public class clsDataWork_TextfileParts
    {
        private clsLocalConfig objLocalConfig;

        private clsDataWork_TextTemplates objDataWork_TextTemplates;
        private clsDataWork_Config objDataWork_Config;

        private clsDBLevel objDBLevel_Ref_To_TextFileParts;
        private clsDBLevel objDBLevel_Type;

        public List<clsOntologyItem> OList_Objects { get; private set; }
        public clsOntologyItem OItem_Class_Object { get; private set; }
        public clsOntologyItem OItem_RelationType { get; private set; }

        public clsOntologyItem OItem_Result_Ref_To_TextFileParts { get; private set; }
        public clsOntologyItem OItem_Result_Hierarchical { get; private set; }

        public List<clsObjectRel> OList_Ref_To_TextFileParts
        {
            get { return objDBLevel_Ref_To_TextFileParts.OList_ObjectRel; }
        }
        
        public List<clsObjectAtt> OList_TextTemplates
        {
            get { return objDataWork_TextTemplates.OList_TextTemplates; }
        }

        public List<clsObjectRel> OList_TemplateVars
        {
            get { return objDataWork_TextTemplates.OList_TextTemplates_To_Variables; }
        }

        public List<clsObjectRel> OList_Config
        {
            get { return objDataWork_Config.OList_Ref_To_Value; }
        }

        public List<clsObjectRel> OList_ConfigValue
        {
            get { return objDataWork_Config.OList_Value_To_Source; }
        }

        public List<clsObjectRel> OList_Type
        {
            get { return objDBLevel_Type.OList_ObjectRel; }
        }

        public List<clsObjectRel> OList_TextFilePart_To_Template
        {
            get { return objDataWork_TextTemplates.OList_Ref_To_TextTemplates; }
        }

        
        public clsOntologyItem GetData(List<clsOntologyItem> OList_Objects, clsOntologyItem OItem_RelationType)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            this.OList_Objects = OList_Objects;
            this.OItem_RelationType = OItem_RelationType;

            objOItem_Result = GetDataInitialize();

            return objOItem_Result;
        }

        public clsOntologyItem GetData(clsOntologyItem OItem_Class_Object, clsOntologyItem OItem_RelationType)
        {
            this.OItem_Class_Object = OItem_Class_Object;
            this.OItem_RelationType = OItem_RelationType;

            var objOItem_Result = GetDataInitialize();

            return objOItem_Result;
        }

        private clsOntologyItem GetDataInitialize()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            GetData_001_Ref_To_TextFileParts();
            objOItem_Result = OItem_Result_Ref_To_TextFileParts;
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Ref_To_TextFileParts.OList_ObjectRel.Any())
                {
                    var objOList_Objects = objDBLevel_Ref_To_TextFileParts.OList_ObjectRel.Select(tp => new clsOntologyItem
                    {
                        GUID = tp.ID_Other,
                        Name = tp.Name_Other,
                        GUID_Parent = tp.ID_Parent_Other,
                        Type = objLocalConfig.Globals.Type_Object
                    }).ToList();

                    objOItem_Result = objDataWork_TextTemplates.GetData(objOList_Objects, objLocalConfig.OItem_relationtype_needs);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objOItem_Result = objDataWork_Config.GetData(objOList_Objects, objLocalConfig.OItem_relationtype_config);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            GetData_002_Hierarchical();
                            objOItem_Result = OItem_Result_Hierarchical;
                        }
                    }
                }
                

            }


            return objOItem_Result;
        }

        private void GetData_001_Ref_To_TextFileParts()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            List<clsObjectRel> objORelS_Ref_To_TextFileParts;

            if (OList_Objects != null && OItem_RelationType != null)
            {
                objORelS_Ref_To_TextFileParts = OList_Objects.Select(o => new clsObjectRel
                {
                    ID_Object = o.GUID,
                    ID_RelationType = OItem_RelationType.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_textfile_parts.GUID
                }).ToList();
            }
            else
            {
                objORelS_Ref_To_TextFileParts = new List<clsObjectRel> 
                {
                    new clsObjectRel 
                    {
                        ID_Parent_Object = OItem_Class_Object.GUID,
                        ID_RelationType = OItem_RelationType.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_textfile_parts.GUID
                    }
                };
            }

            objOItem_Result = objDBLevel_Ref_To_TextFileParts.get_Data_ObjectRel(objORelS_Ref_To_TextFileParts, boolIDs: false);

            OItem_Result_Ref_To_TextFileParts = objOItem_Result;
        }

        public void GetData_002_Hierarchical()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            if (objDBLevel_Ref_To_TextFileParts.OList_ObjectRel.Any())
            {
                var objORelS_Type = objDBLevel_Ref_To_TextFileParts.OList_ObjectRel.Select(tfp => new clsObjectRel {ID_Object = tfp.ID_Other,
                    ID_RelationType = objLocalConfig.OItem_relationtype_is_of_type.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_filepart_type.GUID} ).ToList();

                objOItem_Result = objDBLevel_Type.get_Data_ObjectRel(objORelS_Type, boolIDs: false);

            }
            else
            {
                objDBLevel_Type.OList_ObjectRel.Clear();
            }

            OItem_Result_Hierarchical = objOItem_Result;
        }

        public clsDataWork_TextfileParts(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_Ref_To_TextFileParts = new clsDBLevel(objLocalConfig.Globals);
            objDataWork_TextTemplates = new clsDataWork_TextTemplates(objLocalConfig);
            objDataWork_Config = new clsDataWork_Config(objLocalConfig);
            objDBLevel_Type = new clsDBLevel(objLocalConfig.Globals);

        }
    }
}
