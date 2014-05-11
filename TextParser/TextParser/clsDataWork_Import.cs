using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using ElasticSearchConfig_Module;

namespace TextParser
{
    public class clsDataWork_Import
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_TextParser_To_Ontology;
        private clsDBLevel objDBLevel_TextParser_To_FieldToItem;
        private clsDBLevel objDBLevel_FieldToItem_To_Field;
        private clsDBLevel objDBLevel_FieldToItem_To_OItem;
        private clsDBLevel objDBLevel_TextParser_To_FieldExtractor;
        private clsDBLevel objDBLevel_FieldExtractor_To_Field;

        private clsRelationConfig objRelationConfig;

        private clsDataWork_Ontologies objDataWork_Ontologies;

        private clsDataWork_Index objDataWork_Index;

        private clsOntologyItem objOItem_TextParser;

        public clsOntologyItem OItem_Ontology { get; set; }

        public List<clsOntologyJoins> OList_OntologyJoins { get; set; }

        public clsOntologyItem OItem_Index
        {
            get { return objDataWork_Index.OItem_Index; }
        }

        public clsOntologyItem OItem_Server
        {
            get { return objDataWork_Index.OItem_Server; }
        }

        public clsOntologyItem OItem_Port
        {
            get { return objDataWork_Index.OItem_Port; }
        }

        public clsOntologyItem OItem_Type
        {
            get { return objDataWork_Index.OItem_Type; }
        }

        public List<clsObjectRel> OList_FieldToItem
        {
            get { return objDBLevel_TextParser_To_FieldToItem.OList_ObjectRel; }
        }

        public List<clsObjectAtt> Get_Related_Attributes(List<clsOntologyItem> OList_Items, clsOntologyItem OItem_AttributeType, object value)
        {
            var objORel_Attributes = (from objOJoin in OList_OntologyJoins
                                      join objOItem in OList_Items on objOJoin.ID_OItem1 equals objOItem.GUID_Parent
                                      where objOJoin.ID_OItem2 == OItem_AttributeType.GUID
                                      select objRelationConfig.Rel_ObjectAttribute(objOItem, OItem_AttributeType, value,DoStandardValue:true)).ToList();

            return objORel_Attributes;
        }

        public List<clsObjectRel> Get_Related(List<clsOntologyItem> OList_Items)
        {
            var objORel_LeftRight = (from objOJoin in OList_OntologyJoins
                                     join objOItem1 in OList_Items on objOJoin.ID_OItem1 equals objOItem1.GUID_Parent
                                     join objOItem2 in OList_Items on objOJoin.ID_OItem2 equals objOItem2.GUID_Parent
                                     select objRelationConfig.Rel_ObjectRelation(objOItem1, 
                                     objOItem2, 
                                     new clsOntologyItem {GUID = objOJoin.ID_OItem3,
                                     Name = objOJoin.Name_OItem3,
                                     Type = objLocalConfig.Globals.Type_RelationType})).ToList();


            return objORel_LeftRight;

        }

        public clsOntologyItem Get_OItemOfFieldToItem(clsOntologyItem OItem_FiledToItem)
        {

            

            var objOItem_OItem = objDBLevel_FieldToItem_To_OItem.OList_ObjectRel.Where(f => f.ID_Object == OItem_FiledToItem.GUID).Select(fi => new clsOntologyItem
            {
                GUID = fi.ID_Other,
                Name = fi.Name_Other,
                GUID_Parent = fi.ID_Parent_Other,
                Type = fi.Ontology
            }).First();

            var objOList_ORef = objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(oi => oi.ID_OntologyItem == objOItem_OItem.GUID).ToList();

            var objOList_OItem = OList_OntologyJoins.Where(oj => oj.ID_OItem1 == objOList_ORef.First().ID_Ref).ToList();

            if (objOList_OItem.Any())
            {
                return new clsOntologyItem { GUID = objOList_OItem.First().ID_OItem1,
                    Name = objOList_OItem.First().Name_OItem1,
                    GUID_Parent = objOList_OItem.First().ID_ParentOItem1,
                    Type = objOList_OItem.First().Ontology_OItem1,
                    Level = 1};
            }
            else
            {
                objOList_OItem = OList_OntologyJoins.Where(oj => oj.ID_OItem2 == objOList_ORef.First().ID_Ref).ToList();

                if (objOList_OItem.Any())
                {
                    return new clsOntologyItem { GUID = objOList_OItem.First().ID_OItem2,
                        Name = objOList_OItem.First().Name_OItem2,
                        GUID_Parent = objOList_OItem.First().ID_ParentOItem2,
                                                 Type = objOList_OItem.First().Ontology_OItem2,
                                                 Level = 2
                    };
                }
                else
                {
                    objOList_OItem = OList_OntologyJoins.Where(oj => oj.ID_OItem3 == objOList_ORef.First().ID_Ref).ToList();

                    if (objOList_OItem.Any())
                    {
                        return new clsOntologyItem
                        {
                            GUID = objOList_OItem.First().ID_OItem3,
                            Name = objOList_OItem.First().Name_OItem3,
                            GUID_Parent = objOList_OItem.First().ID_ParentOItem3,
                            Type = objOList_OItem.First().Ontology_OItem3,
                            Level = 2
                        };
                    }
                }
            }

            return null;
        }

        public List<clsOntologyItem> Get_FieldsOfFieldToItem(clsOntologyItem OItem_FieldToItem)
        {
            return objDBLevel_FieldToItem_To_Field.OList_ObjectRel.Where(f => f.ID_Object == OItem_FieldToItem.GUID)
                .OrderBy(f => f.OrderID)
                .Select(f => new clsOntologyItem {GUID = f.ID_Other,
                    Name = f.Name_Other,
                    GUID_Parent = f.ID_Parent_Other,
                    Type = objLocalConfig.Globals.Type_Object
                }).ToList();
        }

        public List<clsOntologyJoins> OList_Joins
        {
            get { return objDataWork_Ontologies.OList_OntologyJoins.Where(j => j.ID_Ontology == OItem_Ontology.GUID).ToList(); }
        }

        public List<clsOntologyItem> FieldList { get; private set; }

        public clsOntologyItem GetData(clsOntologyItem OItem_TextParser)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            objOItem_TextParser = OItem_TextParser;

            objOItem_Result = GetSubData001_OntologyOfTextParser();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = GetSubData002_OntologyData();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOItem_Result = GetSubData003_FieldToItemsOfTextParser();
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objOItem_Result = GetSubData004_FieldsOfFieldToItems();

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objOItem_Result = GetSubData005_OItemsOfFieldToItems();

                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                objOItem_Result = GetSubData006_TextParser_To_FieldExtractor();

                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    objOItem_Result = GetSubData007_FieldExtractor_To_Fields();

                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        objOItem_Result = objDataWork_Index.GetIndexData_OfRef(objOItem_TextParser, objLocalConfig.OItem_relationtype_located_at, objLocalConfig.OItem_relationtype_belonging,  objLocalConfig.Globals.Direction_LeftRight);

                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            FieldList = objDBLevel_FieldExtractor_To_Field.OList_ObjectRel.Select(f => new clsOntologyItem
                                            {
                                                GUID = f.ID_Other,
                                                Name = f.Name_Other,
                                                GUID_Parent = objLocalConfig.OItem_class_field.GUID,
                                                Type = objLocalConfig.Globals.Type_Object
                                            }).ToList();
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

        private clsOntologyItem GetSubData001_OntologyOfTextParser()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objORel_TextParser_To_Ontology = new List<clsObjectRel> { new clsObjectRel { ID_Object = objOItem_TextParser.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                ID_Parent_Other = objLocalConfig.Globals.Class_Ontologies.GUID } };

            objOItem_Result = objDBLevel_TextParser_To_Ontology.get_Data_ObjectRel(objORel_TextParser_To_Ontology, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_TextParser_To_Ontology.OList_ObjectRel.Any())
                {
                    OItem_Ontology = objDBLevel_TextParser_To_Ontology.OList_ObjectRel.Select(o => new clsOntologyItem
                    {
                        GUID = o.ID_Other,
                        Name = o.Name_Other,
                        GUID_Parent = o.ID_Parent_Other,
                        Type = objLocalConfig.Globals.Type_Object
                    }).ToList().First();


                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                }
            }

            return objOItem_Result;
        }

        private clsOntologyItem GetSubData002_OntologyData()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            objOItem_Result = objDataWork_Ontologies.GetData_BaseData();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_OntologyJoins = objDataWork_Ontologies.OList_OntologyJoins.Where(o => o.ID_Ontology == OItem_Ontology.GUID).ToList();

            }

            return objOItem_Result;
        }

        private clsOntologyItem GetSubData003_FieldToItemsOfTextParser()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objORel_FieldToItemsOfTextParser = new List<clsObjectRel> {new clsObjectRel {ID_Object = objOItem_TextParser.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_fieldtoitem.GUID } };

            objOItem_Result = objDBLevel_TextParser_To_FieldToItem.get_Data_ObjectRel(objORel_FieldToItemsOfTextParser, boolIDs: false);

            return objOItem_Result;
        }

        private clsOntologyItem GetSubData004_FieldsOfFieldToItems()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objORel_FieltToItems_To_Fields = objDBLevel_TextParser_To_FieldToItem.OList_ObjectRel.Select(f => new clsObjectRel
            {
                ID_Object = f.ID_Other,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_field.GUID
            }).ToList();


            objOItem_Result = objDBLevel_FieldToItem_To_Field.get_Data_ObjectRel(objORel_FieltToItems_To_Fields, boolIDs: false);


            return objOItem_Result;
        }

        private clsOntologyItem GetSubData005_OItemsOfFieldToItems()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objORel_FieldToItems_To_OItems = objDBLevel_TextParser_To_FieldToItem.OList_ObjectRel.Select(o => new clsObjectRel
            {
                ID_Object = o.ID_Other,
                ID_RelationType = objLocalConfig.OItem_relationtype_import_to.GUID,
                ID_Parent_Other = objLocalConfig.Globals.Class_OntologyItems.GUID
            }).ToList();

            objOItem_Result = objDBLevel_FieldToItem_To_OItem.get_Data_ObjectRel(objORel_FieldToItems_To_OItems, boolIDs: false);

            return objOItem_Result;
        }

        private clsOntologyItem GetSubData006_TextParser_To_FieldExtractor()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objORel_TextParser_To_FieldExtractor = new List<clsObjectRel> {new clsObjectRel { ID_Object = objOItem_TextParser.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_todo.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_field_extractor_parser.GUID  } };

            objOItem_Result = objDBLevel_TextParser_To_FieldExtractor.get_Data_ObjectRel(objORel_TextParser_To_FieldExtractor, boolIDs: false);

            return objOItem_Result;
        }

        private clsOntologyItem GetSubData007_FieldExtractor_To_Fields()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objORel_FieldExtractor_To_Fields = objDBLevel_TextParser_To_FieldExtractor.OList_ObjectRel.Select(tp => new clsObjectRel
            {
                ID_Object = tp.ID_Other,
                ID_RelationType = objLocalConfig.OItem_relationtype_entry.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_field.GUID
            }).ToList();


            objOItem_Result = objDBLevel_FieldExtractor_To_Field.get_Data_ObjectRel(objORel_FieldExtractor_To_Fields, boolIDs: false);


            return objOItem_Result;
        }

        public clsDataWork_Import(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDataWork_Ontologies = new clsDataWork_Ontologies(objLocalConfig.Globals);

            objDBLevel_TextParser_To_Ontology = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_TextParser_To_FieldToItem = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_FieldToItem_To_Field = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_FieldToItem_To_OItem = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_TextParser_To_FieldExtractor = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_FieldExtractor_To_Field = new clsDBLevel(objLocalConfig.Globals);
            objDataWork_Index = new clsDataWork_Index(objLocalConfig.Globals);

            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
        }
    }
}
