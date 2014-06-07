using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Hierarchichal_Splitter_Module
{
    public class clsDataWork_HierarchicalSplitter
    {
        private clsLocalConfig objLocalConfig;

        private clsDataWork_Ontologies objDataWork_Ontologies;

        private clsDBLevel objDBLevel_RulesAndSeperator;
        private clsDBLevel objDBLevel_RelationType;
        private clsDBLevel objDBLevel_Ontology;
        private clsDBLevel objDBLevel_Ref;

        public clsOntologyItem OItem_Profile { get; set; }
        public clsOntologyItem OItem_Ontology { get; set; }
        public clsOntologyItem OItem_RelationType { get; set; }
        public clsOntologyItem OItem_RelationRule { get; set; }
        public clsOntologyItem OItem_CreationRule { get; set; }
        public clsOntologyItem OItem_Seperator { get; set; }

        public List<clsProfileItem> ProfileItems { get; set; }
        public List<ClassRelation> RelationItems { get; set; }

        private clsOntologyItem OItem_Result_RulesAndSeperator;
        private clsOntologyItem OItem_Result_RelationType;
        private clsOntologyItem OItem_Result_Ontology;

        public clsOntologyItem GetData_HierarchicalProfile(clsOntologyItem OItem_Profile)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            this.OItem_Profile = OItem_Profile;

            GetSubData_RulesAndSeperator();
            objOItem_Result = OItem_Result_RulesAndSeperator;
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                GetSubData_RelationType();
                objOItem_Result = OItem_Result_RelationType;
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    GetSubData_Ontology();
                    objOItem_Result = OItem_Result_Ontology;

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (OItem_Ontology != null)
                        {
                            

                            var OList_OItems = objDataWork_Ontologies.GetData_OntologyItemsOfOntologyWithOutJoins(OItem_Ontology);
                            if (OList_OItems != null)
                            {
                                ProfileItems = OList_OItems.Select(pi => new clsProfileItem {
                                    Id_HierarchicalProfile = OItem_Profile.GUID,
                                    Name_HierarchicalProfile = OItem_Profile.GUID,
                                    Id_Ontology = OItem_Ontology.GUID,
                                    Name_Ontology = OItem_Ontology.Name,
                                    Id_Parent = pi.ID_Ref,
                                    Name_Parent = pi.Name_Ref,
                                    Type = pi.Type_Ref == objLocalConfig.Globals.Type_Class ? objLocalConfig.Globals.Type_Object :
                                        pi.Type_Ref == objLocalConfig.Globals.Type_AttributeType ? objLocalConfig.Globals.Type_ObjectAtt : pi.Type_Ref,
                                    Id_RelationRule = OItem_RelationRule != null ? OItem_RelationRule.GUID : null,
                                    Name_RelationRule = OItem_RelationRule != null ? OItem_RelationRule.Name : null,
                                    Id_CreateRule = OItem_CreationRule != null ? OItem_CreationRule.GUID : null,
                                    Name_CreateRule = OItem_CreationRule != null ? OItem_CreationRule.Name : null,
                                    OrderId = pi.OrderID != null ? (long) pi.OrderID : 0 }).OrderBy(pi => pi.OrderId).ToList();
                                    
                            }
                            else
                            {
                                ProfileItems = null;
                            }
                        }
                        else
                        {
                            ProfileItems = null;
                        }
                        
                    }

                }
            }



            return objOItem_Result;
        }

        
        private string GetNameOfOntologyitem(string ID_Parent_Ref, string Ontology_Ref)
        {
            var OItem = objDBLevel_Ref.GetOItem(ID_Parent_Ref,
                                        Ontology_Ref == objLocalConfig.Globals.Type_AttributeType ? objLocalConfig.Globals.Type_DataType :
                                        Ontology_Ref == objLocalConfig.Globals.Type_Object ? objLocalConfig.Globals.Type_Class :
                                        Ontology_Ref == objLocalConfig.Globals.Type_Class ? objLocalConfig.Globals.Type_Class : null);

            if (OItem != null)
            {
                return OItem.Name;
            }
            else
            {
                return null;
            }
        }

        private void GetSubData_RulesAndSeperator()
        {
            OItem_Result_RulesAndSeperator = objLocalConfig.Globals.LState_Nothing.Clone();

            var search_ProfileToRulesAndSeperator = new List<clsObjectRel> { new clsObjectRel {ID_Object = OItem_Profile.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_ontology_relation_rule.GUID },
                new clsObjectRel {ID_Object = OItem_Profile.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_seperator.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_text_seperators.GUID },
                new clsObjectRel {ID_Object = OItem_Profile.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_ontologyitem_creation_rules.GUID } };

            OItem_Seperator = null;
            OItem_RelationRule = null;
            OItem_CreationRule = null;

            var OItem_Result = objDBLevel_RulesAndSeperator.get_Data_ObjectRel(search_ProfileToRulesAndSeperator, boolIDs: false);

            if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var oList_Seperators = objDBLevel_RulesAndSeperator.OList_ObjectRel.Where(r => r.ID_Parent_Other == objLocalConfig.OItem_class_text_seperators.GUID).Select(sep => new clsOntologyItem { GUID = sep.ID_Other,
                    Name = sep.Name_Other,
                    GUID_Parent = sep.ID_Parent_Other,
                    Type = sep.Ontology }).ToList();

                var oList_RelRule = objDBLevel_RulesAndSeperator.OList_ObjectRel.Where(r => r.ID_Parent_Other == objLocalConfig.OItem_class_ontology_relation_rule.GUID).Select(sep => new clsOntologyItem { GUID = sep.ID_Other,
                    Name = sep.Name_Other,
                    GUID_Parent = sep.ID_Parent_Other,
                    Type = sep.Ontology }).ToList();

                var oList_CreateRule = objDBLevel_RulesAndSeperator.OList_ObjectRel.Where(r => r.ID_Parent_Other == objLocalConfig.OItem_class_ontologyitem_creation_rules.GUID).Select(sep => new clsOntologyItem { GUID = sep.ID_Other,
                    Name = sep.Name_Other,
                    GUID_Parent = sep.ID_Parent_Other,
                    Type = sep.Ontology }).ToList();

                if (oList_Seperators.Any())
                {
                    OItem_Seperator = oList_Seperators.First();
                }

                if (oList_RelRule.Any())
                {
                    OItem_RelationRule = oList_RelRule.First();
                }

                if (oList_CreateRule.Any())
                {
                    OItem_CreationRule = oList_CreateRule.First();
                }
            }

            OItem_Result_RulesAndSeperator = OItem_Result;
        }

        private void GetSubData_RelationType()
        {
            OItem_Result_RelationType = objLocalConfig.Globals.LState_Nothing.Clone();

            var search_ProfileToRelationType = new List<clsObjectRel> { new clsObjectRel {ID_Object = OItem_Profile.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belonging_relationtype.GUID,
                Ontology = objLocalConfig.Globals.Type_RelationType } };



            var OItem_Result = objDBLevel_RelationType.get_Data_ObjectRel(search_ProfileToRelationType, boolIDs: false);

            OItem_RelationType = null;

            if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_RelationType.OList_ObjectRel.Any())
                {
                    OItem_RelationType = objDBLevel_RelationType.OList_ObjectRel.Select(r => new clsOntologyItem {GUID = r.ID_Other,
                        Name = r.Name_Other,
                        Type = r.Ontology}).First();
                }
                
            }

            OItem_Result_RelationType = OItem_Result;
        }

        private void GetSubData_Ontology()
        {
            OItem_Result_Ontology = objLocalConfig.Globals.LState_Nothing.Clone();

            var search_OntologyOfProfile = new List<clsObjectRel> { new clsObjectRel { ID_Parent_Object = objLocalConfig.Globals.Class_Ontologies.GUID,
                ID_RelationType = objLocalConfig.Globals.RelationType_belongingResource.GUID,
                ID_Other = OItem_Profile.GUID } };

            OItem_Ontology = null;
            var OItem_Result = objDBLevel_Ontology.get_Data_ObjectRel(search_OntologyOfProfile, boolIDs: false);
            if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Ontology.OList_ObjectRel.Any())
                {
                                OItem_Ontology = objDBLevel_Ontology.OList_ObjectRel.Select(o => new clsOntologyItem { GUID = o.ID_Object,
                                    Name = o.Name_Object,
                                    GUID_Parent = o.ID_Parent_Object,
                                    Type = objLocalConfig.Globals.Type_Object}).First();
                }
                
            }
            

            OItem_Result_Ontology = OItem_Result;
        }

        public clsDataWork_HierarchicalSplitter(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            ProfileItems = new List<clsProfileItem>();

            

            Initialize();
        }

        private void Initialize()
        {
            OItem_Result_RulesAndSeperator = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_RelationType = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_Ontology = objLocalConfig.Globals.LState_Nothing.Clone();

            objDBLevel_RulesAndSeperator = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RelationType = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Ontology = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Ref = new clsDBLevel(objLocalConfig.Globals);

            objDataWork_Ontologies = new clsDataWork_Ontologies(objLocalConfig.Globals);
        }
    }
}
