using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;


namespace TextFileExport_Module
{
    public class clsDataWork_Config 
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_Ref_To_Value;
        private clsDBLevel objDBLevel_Value_To_belongingSource;


        public clsOntologyItem OItem_Result_Ref_To_Value { get; private set; }
        public clsOntologyItem OItem_Result_Value_To_belongingSource { get; private set; }

        public List<clsOntologyItem> OList_Objects { get; private set; }
        public clsOntologyItem OItem_Class_Object { get; private set; }
        public clsOntologyItem OItem_RelationType { get; private set; }

        public List<clsObjectRel> OList_Ref_To_Value
        {
            get { return objDBLevel_Ref_To_Value.OList_ObjectRel; }
        }

        public List<clsObjectRel> OList_Value_To_Source
        {
            get { return objDBLevel_Value_To_belongingSource.OList_ObjectRel; }
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
            GetData_001_Ref_To_Value();
            objOItem_Result = OItem_Result_Ref_To_Value;
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                GetData_002_Value_To_Source();
                objOItem_Result = OItem_Result_Value_To_belongingSource;
                
            }


            return objOItem_Result;
        }

        public void GetData_001_Ref_To_Value()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            List<clsObjectRel> ORelS_Ref_To_Value;
            if (OList_Objects != null)
            {
                ORelS_Ref_To_Value = OList_Objects.Select(r => new clsObjectRel
                {
                    ID_Object = r.GUID,
                    ID_RelationType = OItem_RelationType.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_value.GUID
                }).ToList();
            }
            else
            {
                ORelS_Ref_To_Value = new List<clsObjectRel> 
                {
                    new clsObjectRel 
                    {
                        ID_Parent_Object = OItem_Class_Object.GUID,
                        ID_RelationType = OItem_RelationType.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_value.GUID
                    }    
                };
            }

            objOItem_Result = objDBLevel_Ref_To_Value.get_Data_ObjectRel(ORelS_Ref_To_Value, boolIDs: false);

            OItem_Result_Ref_To_Value = objOItem_Result;
        }

        public void GetData_002_Value_To_Source()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            if (objDBLevel_Ref_To_Value.OList_ObjectRel.Any())
            {
                var objORelS_Value_To_Source = objDBLevel_Ref_To_Value.OList_ObjectRel.Select(v => new clsObjectRel
                {
                    ID_Object = v.ID_Other,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID
                }).ToList();

                objOItem_Result = objDBLevel_Value_To_belongingSource.get_Data_ObjectRel(objORelS_Value_To_Source, boolIDs: false);
            }
            else
            {
                objDBLevel_Value_To_belongingSource.OList_ObjectRel.Clear();
            }



            OItem_Result_Value_To_belongingSource = objOItem_Result;
        }

        public clsDataWork_Config(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_Ref_To_Value = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Value_To_belongingSource = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
