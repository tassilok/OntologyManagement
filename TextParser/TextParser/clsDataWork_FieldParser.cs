using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace TextParser
{
    public class clsDataWork_FieldParser
    {
        private clsDBLevel objDBLevel_FieldToRegEx;
        private clsDBLevel objDBLevel_RegEx__Pattern;
        
        private clsLocalConfig objLocalConfig;

        public clsDataWork_FieldParser(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            Initialize();
        }

        public clsObjectAtt GetRegexOfField(clsOntologyItem OItem_Field, clsOntologyItem OItem_RelationType)
        {
            clsObjectAtt objOARegEx = null;

            var objORelL_Field_To_RegEx = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Object = OItem_Field.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_regular_expressions.GUID,
                            ID_RelationType = OItem_RelationType.GUID
                        }
                };

            var objOItem_Result = objDBLevel_FieldToRegEx.get_Data_ObjectRel(objORelL_Field_To_RegEx);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var objOARelL_RegEx__Pattern = objDBLevel_FieldToRegEx.OList_ObjectRel_ID.Select(p => new clsObjectAtt
                {
                    ID_AttributeType = objLocalConfig.OItem_attributetype_regex.GUID,
                    ID_Object = p.ID_Other
                }).ToList();

                if (objOARelL_RegEx__Pattern.Any())
                {
                    objOItem_Result = objDBLevel_RegEx__Pattern.get_Data_ObjectAtt(objOARelL_RegEx__Pattern,
                                                                                   boolIDs: false);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (objDBLevel_RegEx__Pattern.OList_ObjectAtt.Any())
                        {
                            objOARegEx = objDBLevel_RegEx__Pattern.OList_ObjectAtt.First();
                        }
                    }

                }
            }

            return objOARegEx;
        }

        public clsOntologyItem GetPatternByPattern(string pattern)
        {
            clsOntologyItem OItem_Pattern = null;

            var objOARel_Pattern = new List<clsObjectAtt>
                {
                    new clsObjectAtt
                        {
                            ID_AttributeType = objLocalConfig.OItem_attributetype_pattern.GUID,
                            ID_Class = objLocalConfig.OItem_class_regular_expressions.GUID
                        }
                };

            var objOItem_Result = objDBLevel_RegEx__Pattern.get_Data_ObjectAtt(objOARel_Pattern, boolIDs: false);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var objOAL_Pattern =
                    objDBLevel_RegEx__Pattern.OList_ObjectAtt.Where(p => p.Val_String == pattern).ToList();
                
                if (objOAL_Pattern.Any())
                {
                    var oList_Pattern = objOAL_Pattern.Select(p => new clsOntologyItem
                        {
                            GUID = p.ID_Object,
                            Name = p.Name_Object,
                            GUID_Parent = p.ID_Class,
                            Type = objLocalConfig.Globals.Type_Object
                        }).ToList();

                    OItem_Pattern = oList_Pattern.First();
                }
            }

            return OItem_Pattern;
        }

        private void Initialize()
        {
            objDBLevel_FieldToRegEx = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RegEx__Pattern = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
