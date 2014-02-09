using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace TextFileExport_Module
{
    public class clsDataWork_TextTemplates
    {
        public clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_Ref_To_TextTemplates;
        private clsDBLevel objDBLevel_TextTemplates;
        private clsDBLevel objDBLevel_TextTemplates_To_Variable;

        public clsOntologyItem OItem_Result_Ref_To_TextTemplates { get; private set; }
        public clsOntologyItem OItem_Result_TextTemplates { get; private set; }
        public clsOntologyItem OItem_Result_Variables { get; private set; }
        
        public List<clsOntologyItem> OList_Objects { get; private set; }
        public clsOntologyItem OItem_Class_Object { get; private set; }
        public clsOntologyItem OItem_RelationType { get; private set; }

        public List<clsObjectRel> OList_Ref_To_TextTemplates
        {
            get { return objDBLevel_Ref_To_TextTemplates.OList_ObjectRel; }
        }

        public List<clsObjectAtt> OList_TextTemplates
        {
            get { return objDBLevel_TextTemplates.OList_ObjectAtt; }
        }

        public List<clsObjectRel> OList_TextTemplates_To_Variables
        {
            get { return objDBLevel_TextTemplates_To_Variable.OList_ObjectRel; }
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
            GetData_001_Ref_To_TextTemplates();
            objOItem_Result = OItem_Result_Ref_To_TextTemplates;
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                GetData_002_TextTemplates();
                objOItem_Result = OItem_Result_TextTemplates;
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    GetData_003_Variables();
                    objOItem_Result = OItem_Result_Variables;
                }
            }
            

            return objOItem_Result;
        }

        public void GetData_001_Ref_To_TextTemplates()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            List<clsObjectRel> objORelS_Ref_To_TextTemplates;

            if (OList_Objects != null && OItem_RelationType != null)
            {
                objORelS_Ref_To_TextTemplates = OList_Objects.Select(o => new clsObjectRel
                {
                    ID_Object = o.GUID,
                    ID_RelationType = OItem_RelationType.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_text_templates.GUID
                }).ToList();
            }
            else
            {
                objORelS_Ref_To_TextTemplates = new List<clsObjectRel> 
                {
                    new clsObjectRel 
                    {
                        ID_Parent_Object = OItem_Class_Object.GUID,
                        ID_RelationType = OItem_RelationType.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_text_templates.GUID
                    }
                };
            }

            objOItem_Result = objDBLevel_Ref_To_TextTemplates.get_Data_ObjectRel(objORelS_Ref_To_TextTemplates, boolIDs: false);

            OItem_Result_Ref_To_TextTemplates = objOItem_Result;
        }

        public void GetData_002_TextTemplates()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            List<clsObjectAtt> objORelS_TextTemplates__TemplateText;

            if (objDBLevel_Ref_To_TextTemplates.OList_ObjectRel.Any())
            {
                objORelS_TextTemplates__TemplateText = objDBLevel_Ref_To_TextTemplates.OList_ObjectRel.Select(tt => new clsObjectAtt
                {
                    ID_AttributeType = objLocalConfig.OItem_attributetype_templatetext.GUID,
                    ID_Object = tt.ID_Other
                }).ToList();

                objOItem_Result = objDBLevel_TextTemplates.get_Data_ObjectAtt(objORelS_TextTemplates__TemplateText, boolIDs: false);

            }
            else
            {
                objDBLevel_TextTemplates.OList_ObjectAtt.Clear();
            }

            


            OItem_Result_TextTemplates = objOItem_Result;
        }

        public void GetData_003_Variables()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            if (objDBLevel_TextTemplates.OList_ObjectAtt.Any())
            {
                var objORelS_TextTemplates_To_Variable = objDBLevel_TextTemplates.OList_ObjectAtt.Select(tt => new clsObjectRel
                {
                    ID_Object = tt.ID_Object,
                    ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_variable.GUID
                }).ToList();

                objOItem_Result = objDBLevel_TextTemplates_To_Variable.get_Data_ObjectRel(objORelS_TextTemplates_To_Variable, boolIDs: false);
            }
            else
            {
                objDBLevel_TextTemplates_To_Variable.OList_ObjectRel.Clear();
            }

            OItem_Result_Variables = objOItem_Result;
        }

        public clsDataWork_TextTemplates(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_Ref_To_TextTemplates = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_TextTemplates = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_TextTemplates_To_Variable = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
