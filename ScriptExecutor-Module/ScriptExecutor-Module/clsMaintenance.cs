using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace ScriptExecutor_Module
{
    public class clsMaintenance
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_belongingValue;
        private clsDBLevel objDBLevel_Write;

        private clsRelationConfig objRelationConfig;

        public clsOntologyItem Migrate_belongingValue_To_belongingSource()
        {
            var objORel_belongingValue = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Parent_Object = objLocalConfig.OItem_class_value.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_belonging_value.GUID
                        }
                };

            var objOItem_Result = objDBLevel_belongingValue.get_Data_ObjectRel(objORel_belongingValue);

            if (objDBLevel_belongingValue.OList_ObjectRel_ID.Any())
            {
                var objOrel_Migrate =
                    objDBLevel_belongingValue.OList_ObjectRel_ID.Select(o => objRelationConfig.Rel_ObjectRelation(
                        new clsOntologyItem
                            {
                                GUID = o.ID_Object,
                                GUID_Parent = o.ID_Parent_Object,
                                Type = objLocalConfig.Globals.Type_Object
                            },
                        new clsOntologyItem
                            {
                                GUID = o.ID_Other,
                                GUID_Parent = o.ID_Parent_Other,
                                Type = o.Ontology
                            },
                        objLocalConfig.OItem_relationtype_belonging_source)).ToList();


                objOItem_Result = objDBLevel_Write.save_ObjRel(objOrel_Migrate);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var objOrel_Del =
                        objDBLevel_belongingValue.OList_ObjectRel_ID.Select(o => objRelationConfig.Rel_ObjectRelation(
                            new clsOntologyItem
                            {
                                GUID = o.ID_Object,
                                GUID_Parent = o.ID_Parent_Object,
                                Type = objLocalConfig.Globals.Type_Object
                            },
                            new clsOntologyItem
                            {
                                GUID = o.ID_Other,
                                GUID_Parent = o.ID_Parent_Other,
                                Type = o.Ontology
                            },
                            objLocalConfig.OItem_relationtype_belonging_value)).ToList();

                    objOItem_Result = objDBLevel_Write.del_ObjectRel(objOrel_Del);
                }
                
            }

            

            return objOItem_Result;
        }

        public clsMaintenance(clsLocalConfig localConfig)
        {
            objLocalConfig = localConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_belongingValue = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Write = new clsDBLevel(objLocalConfig.Globals);

            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
        }
    }
}
