using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace TextParser
{
    public class clsDatawork_RegExFilter
    {
        private clsLocalConfig objLocalConfig;
        private clsDBLevel objDBLevel_FilterOfField;
        private clsDBLevel objDBLevel_FilterRel;
        private clsOntologyItem objOItem_Field;
        private clsOntologyItem objOItem_Filter;

        public List<clsRegExFilter> GetData_FiltersOfField(clsOntologyItem OItem_Field)
        {
            
            objOItem_Field = OItem_Field;

            var objORel_FilterOfField_Search = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Object = objOItem_Field.GUID,
                            ID_Parent_Object = objLocalConfig.OItem_class_field.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_regex_field_filter.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_pre.GUID
                        },
                    new clsObjectRel
                        {
                            ID_Object = objOItem_Field.GUID,
                            ID_Parent_Object = objLocalConfig.OItem_class_field.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_regex_field_filter.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_main.GUID
                        },
                    new clsObjectRel
                        {
                            ID_Object = objOItem_Field.GUID,
                            ID_Parent_Object = objLocalConfig.OItem_class_field.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_regex_field_filter.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_posts.GUID
                        }
                };

            var objOItem_Result = objDBLevel_FilterOfField.get_Data_ObjectRel(objORel_FilterOfField_Search,
                                                                              boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var regexFilters =
                    objDBLevel_FilterOfField.OList_ObjectRel.Select(p => GetData_FilterRel(new clsOntologyItem
                        {
                            GUID = p.ID_Other,
                            Name = p.Name_Other,
                            GUID_Parent = p.ID_Parent_Other,
                            Type = objLocalConfig.Globals.Type_Object
                        })).ToList();
                return regexFilters;
            }
            else
            {
                return null;
            }
        }


        public clsRegExFilter GetData_FilterRel(clsOntologyItem OItem_Filter)
        {
            objOItem_Filter = OItem_Filter;
            clsRegExFilter objRegExFilter = null;
            var rel_FilterRel_Search = Rel_FilterRel_Search(objOItem_Filter);
            var objOItem_Result = objDBLevel_FilterRel.get_Data_ObjectAtt(rel_FilterRel_Search, boolIDs:false);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objRegExFilter = new clsRegExFilter
                    {
                        ID_Filter = objOItem_Filter.GUID,
                        Name_Filter = objOItem_Filter.Name
                    };
                if (objDBLevel_FilterRel.OList_ObjectAtt.Any())
                {
                    var objLEqual = objDBLevel_FilterRel.OList_ObjectAtt.Where(
                            p => p.ID_AttributeType == objLocalConfig.OItem_attributetype_equal.GUID).ToList();

                    if (objLEqual.Any())
                    {
                        objRegExFilter.ID_Attribute_Equal = objLEqual.First().ID_Attribute;
                        objRegExFilter.Equal = objLEqual.First().Val_Bit;
                    }
                    var objLPattern = objDBLevel_FilterRel.OList_ObjectAtt.Where(
                        p => p.ID_AttributeType == objLocalConfig.OItem_attributetype_pattern.GUID).ToList();

                    if (objLPattern.Any())
                    {
                        objRegExFilter.ID_Attribute_Pattern = objLPattern.First().ID_Attribute;
                        objRegExFilter.Filter = objLPattern.First().Val_String;
                    }

                }
            }

            return objRegExFilter;
        }

        private List<clsObjectAtt> Rel_FilterRel_Search(clsOntologyItem OItem_Filter)
        {
            var rel_FilterRel_Search = new List<clsObjectAtt>
                {
                    new clsObjectAtt
                        {
                            ID_AttributeType = objLocalConfig.OItem_attributetype_pattern.GUID,
                            ID_Object = objOItem_Filter != null ? objOItem_Filter.GUID : null
                        }, 
                    new clsObjectAtt
                        {
                            ID_AttributeType =  objLocalConfig.OItem_attributetype_equal.GUID, 
                            ID_Object = objOItem_Filter != null ? objOItem_Filter.GUID : null
                        }
                };

            return rel_FilterRel_Search;
        }

        public clsDatawork_RegExFilter(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_FilterRel = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_FilterOfField = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
