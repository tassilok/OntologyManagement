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

        private clsDBLevel objDBLevel_FieldParser_To_Field;
        private clsDBLevel objDBLevel_Fields;
        private clsDBLevel objDBLevel_Fields_Rel;
        private clsDBLevel objDBLevel_Fields_Att;
        private clsDBLevel objDBLevel_Filter_Att;
        private clsDBLevel objDBLevel_RegEx_Att;
        private clsDBLevel objDBLevel_ReplaceWith;
        
        private clsLocalConfig objLocalConfig;

        public List<clsField> FieldList { get; set; } 

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
                            ID_AttributeType = objLocalConfig.OItem_attributetype_regex.GUID,
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

        public clsOntologyItem GetData_FieldsOfFieldParser(clsOntologyItem OItem_Parser = null)
        {
            var objOFieldList = new List<clsOntologyItem>
                {
                    new clsOntologyItem 
                    {
                        GUID_Parent = objLocalConfig.OItem_class_field.GUID
                    }
                };

            var objOItem_Result = objDBLevel_Fields.get_Data_Objects(objOFieldList);

            List<clsObjectRel> objORel_Fields_Rel = new List<clsObjectRel>();
            List<clsObjectAtt> objORel_Fields_att = new List<clsObjectAtt>();
            List<clsObjectAtt> objORel_Filter_att = new List<clsObjectAtt>();
            List<clsObjectAtt> objORel_RegEx_Att = new List<clsObjectAtt>();
            List<clsObjectRel> objORel_Replacewith = new List<clsObjectRel>();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                
                var objORel_FieldParser_To_Field = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Object = OItem_Parser != null ? OItem_Parser.GUID : null,
                            ID_Parent_Object = OItem_Parser == null ? objLocalConfig.OItem_class_field_extractor_parser.GUID : null,
                            ID_RelationType = objLocalConfig.OItem_relationtype_entry.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_field.GUID
                        }
                };

                objOItem_Result = objDBLevel_FieldParser_To_Field.get_Data_ObjectRel(objORel_FieldParser_To_Field,
                                                                                     boolIDs: false);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    

                    

                    if (OItem_Parser == null || !objDBLevel_FieldParser_To_Field.OList_ObjectRel.Any())
                    {
                        objORel_Fields_att = new List<clsObjectAtt>
                        {
                            new clsObjectAtt
                                {
                                    ID_AttributeType = objLocalConfig.OItem_attributetype_remove_from_source.GUID,
                                    ID_Class = objLocalConfig.OItem_class_field.GUID
                                },
                            new clsObjectAtt
                                {
                                    ID_AttributeType = objLocalConfig.OItem_attributetype_useorderid.GUID,
                                    ID_Class = objLocalConfig.OItem_class_field.GUID
                                },
                            new clsObjectAtt
                                {
                                    ID_AttributeType = objLocalConfig.OItem_attributetype_uselastvalid.GUID,
                                    ID_Class = objLocalConfig.OItem_class_field.GUID
                                }
                        };

                        objORel_Fields_Rel = new List<clsObjectRel>
                        {
                            new clsObjectRel
                                {
                                    ID_Parent_Object = objLocalConfig.OItem_class_field.GUID,
                                    ID_RelationType = objLocalConfig.OItem_relationtype_value_type.GUID,
                                    ID_Parent_Other = objLocalConfig.OItem_class_datatypes.GUID
                                },
                            new clsObjectRel
                                {
                                    ID_Parent_Object = objLocalConfig.OItem_class_field.GUID,
                                    ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                                    ID_Parent_Other = objLocalConfig.OItem_class_field.GUID
                                },
                            new clsObjectRel
                                {
                                    ID_Parent_Object = objLocalConfig.OItem_class_field.GUID,
                                    ID_RelationType = objLocalConfig.OItem_relationtype_is.GUID,
                                    ID_Parent_Other = objLocalConfig.OItem_class_metadata__parser_.GUID
                                },
                            new clsObjectRel
                                {
                                    ID_Parent_Object = objLocalConfig.OItem_class_field.GUID,
                                    ID_RelationType = objLocalConfig.OItem_relationtype_main.GUID,
                                    ID_Parent_Other = objLocalConfig.OItem_class_regex_field_filter.GUID
                                },
                            new clsObjectRel
                                {
                                    ID_Parent_Object = objLocalConfig.OItem_class_field.GUID,
                                    ID_RelationType = objLocalConfig.OItem_relationtype_pre.GUID,
                                    ID_Parent_Other = objLocalConfig.OItem_class_regex_field_filter.GUID
                                },
                            new clsObjectRel
                                {
                                    ID_Parent_Object = objLocalConfig.OItem_class_field.GUID,
                                    ID_RelationType = objLocalConfig.OItem_relationtype_posts.GUID,
                                    ID_Parent_Other = objLocalConfig.OItem_class_regex_field_filter.GUID
                                },
                            new clsObjectRel
                                {
                                    ID_Parent_Object = objLocalConfig.OItem_class_field.GUID,
                                    ID_RelationType = objLocalConfig.OItem_relationtype_main.GUID,
                                    ID_Parent_Other = objLocalConfig.OItem_class_regular_expressions.GUID
                                },
                            new clsObjectRel
                                {
                                    ID_Parent_Object = objLocalConfig.OItem_class_field.GUID,
                                    ID_RelationType = objLocalConfig.OItem_relationtype_pre.GUID,
                                    ID_Parent_Other = objLocalConfig.OItem_class_regular_expressions.GUID
                                },
                            new clsObjectRel
                                {
                                    ID_Parent_Object = objLocalConfig.OItem_class_field.GUID,
                                    ID_RelationType = objLocalConfig.OItem_relationtype_posts.GUID,
                                    ID_Parent_Other = objLocalConfig.OItem_class_regular_expressions.GUID
                                }
                        };

                        objORel_Filter_att = new List<clsObjectAtt>
                        {
                            new clsObjectAtt
                                {
                                    ID_AttributeType = objLocalConfig.OItem_attributetype_equal.GUID,
                                    ID_Class = objLocalConfig.OItem_class_regex_field_filter.GUID
                                },
                            new clsObjectAtt
                                {
                                    ID_AttributeType = objLocalConfig.OItem_attributetype_pattern.GUID,
                                    ID_Class = objLocalConfig.OItem_class_regex_field_filter.GUID
                                }
                        };

                        objORel_RegEx_Att = new List<clsObjectAtt>
                        {
                            new clsObjectAtt
                                {
                                    ID_AttributeType = objLocalConfig.OItem_attributetype_regex.GUID,
                                    ID_Class = objLocalConfig.OItem_class_regular_expressions.GUID
                                }
                        };

                        objORel_Replacewith = new List<clsObjectRel>
                        {
                            new clsObjectRel
                            {
                                ID_Parent_Object = objLocalConfig.OItem_class_field.GUID,
                                ID_RelationType = objLocalConfig.OItem_relationtype_replace_with.GUID
                            }
                        };
                    }
                    else
                    {
                        objORel_Fields_att = objDBLevel_FieldParser_To_Field.OList_ObjectRel.Select(f => new clsObjectAtt
                                {
                                    ID_Object = f.ID_Other,
                                    ID_AttributeType = objLocalConfig.OItem_attributetype_remove_from_source.GUID,
                                    ID_Class = objLocalConfig.OItem_class_field.GUID
                                }).ToList();
                        objORel_Fields_att.AddRange(objDBLevel_FieldParser_To_Field.OList_ObjectRel.Select(f => new clsObjectAtt
                                {
                                    ID_Object = f.ID_Other,
                                    ID_AttributeType = objLocalConfig.OItem_attributetype_useorderid.GUID,
                                    ID_Class = objLocalConfig.OItem_class_field.GUID
                                }));

                        objORel_Fields_Rel = objDBLevel_FieldParser_To_Field.OList_ObjectRel.Select(f => new clsObjectRel
                        {
                            ID_Object = f.ID_Other,
                            ID_RelationType = objLocalConfig.OItem_relationtype_value_type.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_datatypes.GUID
                        }).ToList();


                        objORel_Fields_Rel.AddRange(objDBLevel_FieldParser_To_Field.OList_ObjectRel.Select(f => new clsObjectRel
                        {
                            ID_Object = f.ID_Other,
                            ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_field.GUID
                        }));

                        objORel_Fields_Rel.AddRange(objDBLevel_FieldParser_To_Field.OList_ObjectRel.Select(f => new clsObjectRel
                        {
                            ID_Object = f.ID_Other,
                            ID_RelationType = objLocalConfig.OItem_relationtype_is.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_metadata__parser_.GUID
                        }));

                        objORel_Fields_Rel.AddRange(objDBLevel_FieldParser_To_Field.OList_ObjectRel.Select(f => new clsObjectRel
                        {
                            ID_Object = f.ID_Other,
                            ID_RelationType = objLocalConfig.OItem_relationtype_main.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_regex_field_filter.GUID
                        }));

                        objORel_Fields_Rel.AddRange(objDBLevel_FieldParser_To_Field.OList_ObjectRel.Select(f => new clsObjectRel
                        {
                            ID_Object = f.ID_Other,
                            ID_RelationType = objLocalConfig.OItem_relationtype_pre.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_regex_field_filter.GUID
                        }));

                        objORel_Fields_Rel.AddRange(objDBLevel_FieldParser_To_Field.OList_ObjectRel.Select(f => new clsObjectRel
                        {
                            ID_Object = f.ID_Other,
                            ID_RelationType = objLocalConfig.OItem_relationtype_posts.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_regex_field_filter.GUID
                        }));

                        objORel_Fields_Rel.AddRange(objDBLevel_FieldParser_To_Field.OList_ObjectRel.Select(f => new clsObjectRel
                        {
                            ID_Object = f.ID_Other,
                            ID_RelationType = objLocalConfig.OItem_relationtype_main.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_regular_expressions.GUID
                        }));

                        objORel_Fields_Rel.AddRange(objDBLevel_FieldParser_To_Field.OList_ObjectRel.Select(f => new clsObjectRel
                        {
                            ID_Object = f.ID_Other,
                            ID_RelationType = objLocalConfig.OItem_relationtype_pre.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_regular_expressions.GUID
                        }));

                        objORel_Fields_Rel.AddRange(objDBLevel_FieldParser_To_Field.OList_ObjectRel.Select(f => new clsObjectRel
                        {
                            ID_Object = f.ID_Other,
                            ID_RelationType = objLocalConfig.OItem_relationtype_posts.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_regular_expressions.GUID
                        }));

                        objORel_Filter_att = objDBLevel_FieldParser_To_Field.OList_ObjectRel.Select(f => new clsObjectAtt
                        {
                            ID_Object = f.ID_Other,
                            ID_AttributeType = objLocalConfig.OItem_attributetype_equal.GUID
                        }).ToList();


                        objORel_Replacewith = objDBLevel_FieldParser_To_Field.OList_ObjectRel.Select(f => new clsObjectRel {
                                ID_Object = f.ID_Other,
                                ID_RelationType = objLocalConfig.OItem_relationtype_replace_with.GUID
                            }).ToList();

                        objORel_RegEx_Att = new List<clsObjectAtt>
                        {
                            new clsObjectAtt
                                {
                                    ID_AttributeType = objLocalConfig.OItem_attributetype_regex.GUID,
                                    ID_Class = objLocalConfig.OItem_class_regular_expressions.GUID
                                }
                        };

                }
                
            }

            
            


            
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                

                
                    objOItem_Result = objDBLevel_Fields_Att.get_Data_ObjectAtt(objORel_Fields_att, boolIDs: false);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objOItem_Result = objDBLevel_Fields_Rel.get_Data_ObjectRel(objORel_Fields_Rel, boolIDs: false);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objOItem_Result = objDBLevel_Filter_Att.get_Data_ObjectAtt(objORel_Fields_att, boolIDs: false);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                objOItem_Result = objDBLevel_RegEx_Att.get_Data_ObjectAtt(objORel_RegEx_Att, boolIDs: false);

                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    objOItem_Result = objDBLevel_ReplaceWith.get_Data_ObjectRel(objORel_Replacewith, boolIDs: false);

                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        List<clsRegExField> regExMain = (from objRegExMain in objDBLevel_Fields_Rel.OList_ObjectRel.
                                                                                            Where(
                                                                                                r =>
                                                                                                r.ID_RelationType ==
                                                                                                objLocalConfig
                                                                                                    .OItem_relationtype_main
                                                                                                    .GUID &&
                                                                                                r.ID_Parent_Other ==
                                                                                                objLocalConfig
                                                                                                    .OItem_class_regular_expressions
                                                                                                    .GUID).ToList()
                                                                         join objRegExValMain in objDBLevel_RegEx_Att.OList_ObjectAtt on
                                                                             objRegExMain.ID_Other equals objRegExValMain.ID_Object
                                                                         select new clsRegExField
                                                                         {
                                                                             ID_Field = objRegExMain.ID_Object,
                                                                             ID_RegEx = objRegExMain.ID_Other,
                                                                             ID_Attribute = objRegExValMain.ID_Attribute,
                                                                             RegEx = objRegExValMain.Val_String
                                                                         }).ToList();

                                        List<clsRegExField> regExPre = (from objRegExPre in objDBLevel_Fields_Rel.OList_ObjectRel.
                                                                                                    Where(
                                                                                                        r =>
                                                                                                        r.ID_RelationType ==
                                                                                                        objLocalConfig
                                                                                                            .OItem_relationtype_pre
                                                                                                            .GUID &&
                                                                                                        r.ID_Parent_Other ==
                                                                                                        objLocalConfig
                                                                                                            .OItem_class_regular_expressions
                                                                                                            .GUID).ToList()
                                                                        join objRegExValPre in objDBLevel_RegEx_Att.OList_ObjectAtt on
                                                                            objRegExPre.ID_Other equals objRegExValPre.ID_Object
                                                                        select new clsRegExField
                                                                        {
                                                                            ID_Field = objRegExPre.ID_Object,
                                                                            ID_RegEx = objRegExPre.ID_Other,
                                                                            ID_Attribute = objRegExValPre.ID_Attribute,
                                                                            RegEx = objRegExValPre.Val_String
                                                                        }).ToList();

                                        List<clsRegExField> regExPost = (from objRegExPost in objDBLevel_Fields_Rel.OList_ObjectRel.
                                                                                                    Where(
                                                                                                        r =>
                                                                                                        r.ID_RelationType ==
                                                                                                        objLocalConfig
                                                                                                            .OItem_relationtype_posts
                                                                                                            .GUID &&
                                                                                                        r.ID_Parent_Other ==
                                                                                                        objLocalConfig
                                                                                                            .OItem_class_regular_expressions
                                                                                                            .GUID).ToList()
                                                                         join objRegExValPost in objDBLevel_RegEx_Att.OList_ObjectAtt on
                                                                             objRegExPost.ID_Other equals objRegExValPost.ID_Object
                                                                         select new clsRegExField
                                                                         {
                                                                             ID_Field = objRegExPost.ID_Object,
                                                                             ID_RegEx = objRegExPost.ID_Other,
                                                                             ID_Attribute = objRegExValPost.ID_Attribute,
                                                                             RegEx = objRegExValPost.Val_String
                                                                         }).ToList();

                                        FieldList = (from objField in objDBLevel_Fields.OList_Objects
                                                     join objFieldParser in objDBLevel_FieldParser_To_Field.OList_ObjectRel on
                                                         objField.GUID equals objFieldParser.ID_Other
                                                     join objRemoveFromSource
                                                         in objDBLevel_Fields_Att.OList_ObjectAtt.
                                                                                  Where(
                                                                                      at =>
                                                                                      at.ID_AttributeType ==
                                                                                      objLocalConfig
                                                                                          .OItem_attributetype_remove_from_source
                                                                                          .GUID).ToList()
                                                         on objField.GUID equals objRemoveFromSource.ID_Object
                                                     join objUseOrderId
                                                         in objDBLevel_Fields_Att.OList_ObjectAtt.
                                                                                  Where(
                                                                                      at =>
                                                                                      at.ID_AttributeType ==
                                                                                      objLocalConfig
                                                                                          .OItem_attributetype_useorderid.GUID)
                                                                                 .ToList()
                                                         on objField.GUID equals objUseOrderId.ID_Object
                                                     join objDataType
                                                         in objDBLevel_Fields_Rel.OList_ObjectRel.
                                                                                  Where(
                                                                                      dt =>
                                                                                      dt.ID_RelationType ==
                                                                                      objLocalConfig
                                                                                          .OItem_relationtype_value_type.GUID &&
                                                                                      dt.ID_Parent_Other ==
                                                                                      objLocalConfig.OItem_class_datatypes.GUID)
                                                                                 .ToList()
                                                         on objField.GUID equals objDataType.ID_Object
                                                     join objMeta in objDBLevel_Fields_Rel.OList_ObjectRel.
                                                                                           Where(
                                                                                               m =>
                                                                                               m.ID_RelationType ==
                                                                                               objLocalConfig
                                                                                                   .OItem_relationtype_is.GUID &&
                                                                                               m.ID_Parent_Other ==
                                                                                               objLocalConfig
                                                                                                   .OItem_class_metadata__parser_
                                                                                                   .GUID).ToList()
                                                         on objField.GUID equals objMeta.ID_Object into objMetas
                                                     from objMeta in objMetas.DefaultIfEmpty()
                                                     join objUseLastValid in objDBLevel_Fields_Att.OList_ObjectAtt.
                                                                                            Where(
                                                                                              at =>
                                                                                              at.ID_AttributeType ==
                                                                                              objLocalConfig
                                                                                                  .OItem_attributetype_uselastvalid.GUID)
                                                                                         .ToList() on objField.GUID equals objUseLastValid.ID_Object into UseLastValidItems
                                                     from objUseLastValid in UseLastValidItems.DefaultIfEmpty()
                                                     join objRegExMain in regExMain on objField.GUID equals objRegExMain.ID_Field into objRegExMains
                                                     from objRegExMain in objRegExMains.DefaultIfEmpty()
                                                     join objRegExPre in regExPre on objField.GUID equals objRegExPre.ID_Field into objRegExPres
                                                     from objRegExPre in objRegExPres.DefaultIfEmpty()
                                                     join objRegExPost in regExPost on objField.GUID equals objRegExPost.ID_Field into objRegExPosts
                                                     from objRegExPost in objRegExPosts.DefaultIfEmpty()
                                                     join objReplace in objDBLevel_ReplaceWith.OList_ObjectRel on objField.GUID equals objReplace.ID_Object into objReplaces
                                                     from objReplace in objReplaces.DefaultIfEmpty()
                                                     select new clsField
                                                     {
                                                         ID_FieldParser = objFieldParser.ID_Object,
                                                         Name_FieldParser = objFieldParser.Name_Object,
                                                         ID_Field = objField.GUID,
                                                         Name_Field = objField.Name,
                                                         ID_DataType = objDataType.ID_Other,
                                                         DataType = objDataType.Name_Other,
                                                         ID_Attribute_RemoveFromSource = objRemoveFromSource.ID_Attribute,
                                                         RemoveFromSource = objRemoveFromSource.Val_Bit ?? false,
                                                         ID_Attribute_UseOrderID = objUseOrderId.ID_Attribute,
                                                         UseOrderId = objUseOrderId.Val_Bit ?? false,
                                                         ID_MetaField = objMeta != null ? objMeta.ID_Other : null,
                                                         Name_MetaField = objMeta != null ? objMeta.Name_Other : null,
                                                         IsMeta = objMeta != null,
                                                         ID_RegExPre = objRegExPre != null ? objRegExPre.ID_RegEx : null,
                                                         ID_Attribute_RegExPreVal = objRegExPre != null ? objRegExPre.ID_Attribute : null,
                                                         RegexPre = objRegExPre != null ? objRegExPre.RegEx : null,
                                                         ID_RegExMain = objRegExMain != null ? objRegExMain.ID_RegEx : null,
                                                         ID_Attribute_RegExMainVal = objRegExMain != null ? objRegExMain.ID_Attribute : null,
                                                         Regex = objRegExMain != null ? objRegExMain.RegEx : null,
                                                         ID_RegExPost = objRegExPost != null ? objRegExPost.ID_RegEx : null,
                                                         ID_Attribute_RegExPostVal = objRegExPost != null ? objRegExPost.ID_Attribute : null,
                                                         RegexPost = objRegExPost != null ? objRegExPost.RegEx : null,
                                                         OrderId = objFieldParser.OrderID ?? 0,
                                                         Insert = objReplace != null ? objReplace.Name_Other : null,
                                                         IsInsert = objReplace != null ? true : false,
                                                         ID_Attribute_UseLastValid = objUseLastValid != null ? objUseLastValid.ID_Attribute : null,
                                                         UseLastValid = objUseLastValid != null ? objUseLastValid.Val_Bit != null ? (bool)objUseLastValid.Val_Bit : false : false
                                                     }).ToList();
                                    }
                                }
                                
                            }
                        }
                    }
                }

            }

            return objOItem_Result;
        }

        private void Initialize()
        {
            objDBLevel_FieldToRegEx = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RegEx__Pattern = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_FieldParser_To_Field = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Fields = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Fields_Rel = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Fields_Att = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Filter_Att = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RegEx_Att = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ReplaceWith = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
