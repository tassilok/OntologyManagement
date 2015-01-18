using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace LocalizedTemplate_Module
{
    public class clsDataWork_AutoCorrection
    {
        private clsLocalConfig localConfig;

        private clsDBLevel dbLevel_AutoCorrector_Base;
        private clsDBLevel dbLevel_AutoCorrector_IsClass;
        private clsDBLevel dbLevel_AutoCorrector_Ref1;
        private clsDBLevel dbLevel_AutoCorrector_Ref2;

        public clsOntologyItem AutoCorrector { get; set; }
        public clsObjectAtt HasRefClass { get; private set; }
        public bool IsRefClass
        {
            get { return HasRefClass != null ? true : (bool)HasRefClass.Val_Bool; }
        }
        public clsOntologyItem ClassRef { get; private set; }
        public List<clsOntologyItem> AutoCorrectorList { get; private set; }

        private void GetData_BaseConfig()
        {
            var searchBase = new List<clsObjectRel> { new clsObjectRel {ID_Object = localConfig.OItem_object_baseconfig.GUID,
                ID_RelationType = localConfig.OItem_relationtype_standard.GUID,
                ID_Parent_Other = localConfig.OItem_class_autocorrection.GUID}};

            var result = dbLevel_AutoCorrector_Base.get_Data_ObjectRel(searchBase, boolIDs: false);

            if (result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                AutoCorrector = dbLevel_AutoCorrector_Base.OList_ObjectRel.Select(ac => new clsOntologyItem
                {
                    GUID = ac.ID_Other,
                    Name = ac.Name_Other,
                    GUID_Parent = ac.ID_Parent_Other,
                    Type = ac.Ontology
                }).FirstOrDefault();

                if (AutoCorrector == null)
                {
                    throw new Exception("Die Konfiguration ist nicht korrekt. Bitte setzen sie den Standard-Autokorrektor!");
                }
            }
            else
            {
                AutoCorrector = null;
                throw new Exception("Die Autokorrektur konnte nicht konfiguriert werden!");
            }

            
        }

        public clsOntologyItem GetData_AutoCorrectionList()
        {
            var result = localConfig.Globals.LState_Error.Clone();
            if (AutoCorrector != null)
            {
                var searchIsClass = new List<clsObjectAtt> { new clsObjectAtt { ID_Object = AutoCorrector.GUID,
                    ID_AttributeType = localConfig.OItem_attributetype_hasclassreference.GUID}};

                result = dbLevel_AutoCorrector_IsClass.get_Data_ObjectAtt(searchIsClass, boolIDs: false);

                if (result.GUID == localConfig.Globals.LState_Success.GUID)
                {
                    HasRefClass = dbLevel_AutoCorrector_IsClass.OList_ObjectAtt.FirstOrDefault();
                }
                else
                {
                    result = localConfig.Globals.LState_Error.Clone();
                    
                }
            }

            if (AutoCorrector != null)
            {
                var searchCorrectorList = new List<clsObjectRel> { new clsObjectRel { ID_Object = AutoCorrector.GUID,
                    ID_RelationType = localConfig.OItem_relationtype_contains.GUID}};

                result = dbLevel_AutoCorrector_Ref1.get_Data_ObjectRel(searchCorrectorList, boolIDs: false);

                if (result.GUID == localConfig.Globals.LState_Success.GUID)
                {
                    if (IsRefClass)
                    {

                        if (dbLevel_AutoCorrector_Ref1.OList_ObjectRel.Count == 1 && dbLevel_AutoCorrector_Ref1.OList_ObjectRel.First().Ontology == localConfig.Globals.Type_Class)
                        {
                            ClassRef = dbLevel_AutoCorrector_Ref1.OList_ObjectRel.Select(refClass => new clsOntologyItem
                            {
                                GUID = refClass.ID_Other,
                                Name = refClass.Name_Other,
                                GUID_Parent = refClass.ID_Parent_Other,
                                Type = refClass.Ontology
                            }).FirstOrDefault();

                            var searchCorrectorObjects = new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = ClassRef.GUID } };
                            result = dbLevel_AutoCorrector_Ref2.get_Data_Objects(searchCorrectorObjects);
                            if (result.GUID == localConfig.Globals.LState_Success.GUID)
                            {
                                AutoCorrectorList = dbLevel_AutoCorrector_Ref2.OList_Objects.OrderBy(refItem => refItem.Name).ToList();
                            }
                            else
                            {
                                result = localConfig.Globals.LState_Error.Clone();
                            }



                        }
                        else
                        {
                            result = localConfig.Globals.LState_Error.Clone();
                        }

                    }
                    else
                    {
                        AutoCorrectorList = dbLevel_AutoCorrector_Ref1.OList_ObjectRel.OrderBy(refItem => refItem.Name_Other).Select(refItem => new clsOntologyItem
                        {
                            GUID = refItem.ID_Other,
                            Name = refItem.Name_Other,
                            GUID_Parent = refItem.ID_Parent_Other,
                            Type = refItem.Ontology
                        }).ToList();
                    }
                }
                else
                {
                    result = localConfig.Globals.LState_Error.Clone();
                }
            }

            return result;
        }

        public clsDataWork_AutoCorrection(clsLocalConfig localConfig)
        {
            this.localConfig = localConfig;
            Initialize();
        }

        private void Initialize()
        {
            dbLevel_AutoCorrector_Base = new clsDBLevel(localConfig.Globals);
            dbLevel_AutoCorrector_Ref1 = new clsDBLevel(localConfig.Globals);
            dbLevel_AutoCorrector_Ref2 = new clsDBLevel(localConfig.Globals);
            dbLevel_AutoCorrector_IsClass = new clsDBLevel(localConfig.Globals);

            GetData_BaseConfig();
        }
    }
}
