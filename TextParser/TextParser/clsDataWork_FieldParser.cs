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
        private clsDBLevel objDBLevel_UserContentOfField;
        private clsDBLevel objDBLevel_DoAll;
        private clsDBLevel objDBLevel_RegExReplace;
        private clsDBLevel objDBLevel_RegExOfReplace;
        private clsDBLevel objDBLevel_RegExRegEx;
        private clsDBLevel objDBLevel_RegExReplaceWith;
        private clsDBLevel objDBLevel_ContainedFields;

        private clsDBLevel objDBLevel_DocumentItem;
        private clsDBLevel objDBLevel_DocItemToField;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;
      
        private clsLocalConfig objLocalConfig;

        public List<clsReplaceList> ReplaceList { get; set; } 
        public List<clsField> FieldList { get; set; } 

        public clsDataWork_FieldParser(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            Initialize();
        }

        public List<clsDocumentItem> GetDockumentItemsWithFields(clsOntologyItem oItem_TextParser)
        {
            var documentItems = new List<clsDocumentItem>();

            var searchItems = new List<clsObjectRel>
            {
                new clsObjectRel
                {
                    ID_Object = oItem_TextParser.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_documentitem.GUID
                }

            };

            var result = objDBLevel_DocumentItem.get_Data_ObjectRel(searchItems, boolIDs: false);

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var searchFields = objDBLevel_DocumentItem.OList_ObjectRel.Select(docItem => new clsObjectRel
                {
                    ID_Object = docItem.ID_Other,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_field.GUID
                }).ToList();

                result = objDBLevel_DocItemToField.get_Data_ObjectRel(searchFields, boolIDs: false);

                if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    documentItems = (from docItem in objDBLevel_DocumentItem.OList_ObjectRel
                        join fieldItem in objDBLevel_DocItemToField.OList_ObjectRel on docItem.ID_Other equals
                            fieldItem.ID_Object
                        select new clsDocumentItem
                        {
                            ID_DocItem = docItem.ID_Other,
                            Name_DocItem = docItem.Name_Other,
                            ID_Field = fieldItem.ID_Other,
                            Name_Field = fieldItem.Name_Other
                        }).ToList();
                    
                }
                else
                {
                    documentItems = null;
                }
                
            }
            else
            {
                documentItems = null;
            }

            return documentItems;
        }

        public List<clsOntologyItem> GetDocumentItems(clsOntologyItem oItem_TextParser)
        {
            var documentItems = new List<clsOntologyItem>();

            var searchItems = new List<clsObjectRel>
            {
                new clsObjectRel
                {
                    ID_Object = oItem_TextParser.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_documentitem.GUID
                }

            };

            var result = objDBLevel_DocumentItem.get_Data_ObjectRel(searchItems, boolIDs: false);

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                documentItems = objDBLevel_DocumentItem.OList_ObjectRel.Select(docItem => new clsOntologyItem
                {
                    GUID = docItem.ID_Other,
                    Name = docItem.Name_Other,
                    GUID_Parent = docItem.ID_Parent_Other,
                    Type = objLocalConfig.Globals.Type_Object
                }).ToList();
            }
            else
            {
                documentItems = null;
            }

            return documentItems;
        }

        public clsOntologyItem GetDocumentItem(object value, string idDoc, clsOntologyItem oItem_TextParser, clsOntologyItem oItem_Field)
        {

            var name = idDoc;

            var objOItem_DocumentItem = new clsOntologyItem
            {
                Name = name,
                GUID_Parent = objLocalConfig.OItem_class_documentitem.GUID,
                Type = objLocalConfig.Globals.Type_Object
            };

            var searchObjRel = new List<clsObjectRel>
            {
                new clsObjectRel
                {
                    ID_Object = oItem_TextParser.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_documentitem.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID
                }
            };

            var result = objDBLevel_DocumentItem.get_Data_ObjectRel(searchObjRel, boolIDs: false);

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var searchDocItemToField = objDBLevel_DocumentItem.OList_ObjectRel.Where(docItem => docItem.Name_Other == idDoc).Select(docItem => new clsObjectRel
                {
                    ID_Object = docItem.ID_Other,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Other = oItem_Field.GUID
                }).ToList();

                if (searchDocItemToField.Any())
                {
                    result = objDBLevel_DocItemToField.get_Data_ObjectRel(searchDocItemToField, boolIDs: false);
                    if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (objDBLevel_DocItemToField.OList_ObjectRel.Any())
                        {
                            objOItem_DocumentItem = new clsOntologyItem
                            {
                                GUID = objDBLevel_DocItemToField.OList_ObjectRel.First().ID_Object,
                                Name =  objDBLevel_DocItemToField.OList_ObjectRel.First().Name_Object,
                                GUID_Parent = objDBLevel_DocItemToField.OList_ObjectRel.First().ID_Parent_Object,
                                Type = objLocalConfig.Globals.Type_Object
                            };

                            return objOItem_DocumentItem;
                        }
                        else
                        {
                            return CreateDocumentItem(value, idDoc, oItem_TextParser, oItem_Field);
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return CreateDocumentItem(value, idDoc, oItem_TextParser, oItem_Field);
                }

                
            }
            else
            {
                return null;
            }

            



            


        }

        public clsOntologyItem CreateDocumentItem(object value, string idDoc, clsOntologyItem oItem_TextParser, clsOntologyItem oItem_Field)
        {
            var objOItem_DocumentItem = new clsOntologyItem();
            objOItem_DocumentItem.GUID = objLocalConfig.Globals.NewGUID;
            objOItem_DocumentItem.Name = idDoc;
            objOItem_DocumentItem.GUID_Parent = objLocalConfig.OItem_class_documentitem.GUID;
            objOItem_DocumentItem.Type = objLocalConfig.Globals.Type_Object;

            objTransaction.ClearItems();

            var result = objTransaction.do_Transaction(objOItem_DocumentItem);
            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var rel_TextParserToDocumentItem = objRelationConfig.Rel_ObjectRelation(oItem_TextParser,
                    objOItem_DocumentItem, objLocalConfig.OItem_relationtype_contains);

                result = objTransaction.do_Transaction(rel_TextParserToDocumentItem);

                if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    clsObjectAtt rel_ObjectAtt;
                    if (value is bool)
                    {
                        rel_ObjectAtt = objRelationConfig.Rel_ObjectAttribute(objOItem_DocumentItem,
                            objLocalConfig.OItem_attributetype_bitvalue, value);

                    }
                    else if (value is DateTime)
                    {
                        rel_ObjectAtt = objRelationConfig.Rel_ObjectAttribute(objOItem_DocumentItem,
                            objLocalConfig.OItem_attributetype_datetimevalue, value);
                    }
                    else if (value is long)
                    {
                        rel_ObjectAtt = objRelationConfig.Rel_ObjectAttribute(objOItem_DocumentItem,
                            objLocalConfig.OItem_attributetype_longvalue, value);
                    }
                    else if (value is double)
                    {
                        rel_ObjectAtt = objRelationConfig.Rel_ObjectAttribute(objOItem_DocumentItem,
                            objLocalConfig.OItem_attributetype_doublevalue, value);
                    }
                    else if (value is string)
                    {
                        rel_ObjectAtt = objRelationConfig.Rel_ObjectAttribute(objOItem_DocumentItem,
                            objLocalConfig.OItem_attributetype_stringvalue, value);
                    }
                    else
                    {
                        return null;
                    }

                    result = objTransaction.do_Transaction(rel_ObjectAtt);

                    if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var rel_ObjRel = objRelationConfig.Rel_ObjectRelation(objOItem_DocumentItem, oItem_Field,
                            objLocalConfig.OItem_relationtype_belongs_to);

                        result = objTransaction.do_Transaction(rel_ObjRel);
                        if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            return objOItem_DocumentItem;
                        }
                        else
                        {
                            objTransaction.rollback();
                            return null;
                        }
                    }
                    else
                    {
                        objTransaction.rollback();
                        return null;
                    }

                }
                else
                {
                    objTransaction.rollback();
                    return null;
                }
            }
            else
            {
                return null;
            }
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

        private clsOntologyItem GetSubData_RegExReplace()
        {
            var result = objLocalConfig.Globals.LState_Success.Clone();

            objDBLevel_RegExOfReplace.OList_ObjectRel.Clear();
            objDBLevel_RegExRegEx.OList_ObjectAtt.Clear();
            objDBLevel_RegExReplaceWith.OList_ObjectAtt.Clear();
            ReplaceList = new List<clsReplaceList>();

            var searchReplace = new List<clsObjectRel>
            {
                new clsObjectRel
                {
                    ID_Parent_Object = objLocalConfig.OItem_class_field.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_field_replace__textparser_.GUID
                }
            };

            result = objDBLevel_RegExReplace.get_Data_ObjectRel(searchReplace, boolIDs: false);

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var searchText = objDBLevel_RegExReplace.OList_ObjectRel.Select(rep => new clsObjectAtt
                {
                    ID_AttributeType = objLocalConfig.OItem_attributetype_text.GUID,
                    ID_Object = rep.ID_Other
                }).ToList();

                if (searchText.Any())
                {
                    result = objDBLevel_RegExReplaceWith.get_Data_ObjectAtt(searchText, boolIDs: false);
                }
            }

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var searchRegEx = objDBLevel_RegExReplace.OList_ObjectRel.Select(rep => new clsObjectRel
                {
                    ID_Object = rep.ID_Other,
                    ID_RelationType = objLocalConfig.OItem_relationtype_find.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_regular_expressions.GUID
                }).ToList();

                if (searchRegEx.Any())
                {
                    result = objDBLevel_RegExOfReplace.get_Data_ObjectRel(searchRegEx, boolIDs: false);

                }
            }

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var searchRegExRegEx = objDBLevel_RegExOfReplace.OList_ObjectRel.Select(reg => new clsObjectAtt
                {
                    ID_Object = reg.ID_Other,
                    ID_AttributeType = objLocalConfig.OItem_attributetype_regex.GUID
                }).ToList();

                if (searchRegExRegEx.Any())
                {
                    result = objDBLevel_RegExRegEx.get_Data_ObjectAtt(searchRegExRegEx, boolIDs: false);
                }
            }

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var fieldList =
                    objDBLevel_RegExReplace.OList_ObjectRel.GroupBy(field => field.ID_Object)
                        .Select(field => new clsOntologyItem {GUID = field.Key})
                        .ToList();

                fieldList.ForEach(field =>
                {
                    var replaceList = (from objFieldReplace in objDBLevel_RegExReplace.OList_ObjectRel
                        where objFieldReplace.ID_Object == field.GUID
                        join objFieldText in objDBLevel_RegExReplaceWith.OList_ObjectAtt
                            on objFieldReplace.ID_Other equals objFieldText.ID_Object
                            into objFieldTexts
                        from objFieldText in objFieldTexts.DefaultIfEmpty()
                        join objRegExOfReplace in
                            objDBLevel_RegExOfReplace.OList_ObjectRel on
                            objFieldReplace.ID_Other equals objRegExOfReplace.ID_Object
                        join objRegExOfRegEx in objDBLevel_RegExRegEx.OList_ObjectAtt on
                            objRegExOfReplace.ID_Other equals objRegExOfRegEx.ID_Object
                        select new clsRegExReplace()
                        {
                            ID_Field = field.GUID,
                            ID_FieldReplace = objFieldReplace.ID_Other,
                            Name_FieldReplace = objFieldReplace.Name_Other,
                            ID_Attribute_Text =
                                objFieldText != null ? objFieldText.ID_Attribute : null,
                            ReplaceWith =
                                objFieldText != null
                                    ? objFieldText.Val_String ?? ""
                                    : "",
                            ID_RegEx = objRegExOfReplace.ID_Other,
                            ID_Attribute_RegEx = objRegExOfRegEx.ID_Attribute,
                            RegExSearch = objRegExOfRegEx.Val_String
                        }).ToList();

                    ReplaceList.Add(new clsReplaceList
                    {
                        ID_Field = field.GUID,
                        ReplaceList = replaceList
                    });
                });
            }

            

            return result;
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
            List<clsObjectRel> objORel_ContentField = new List<clsObjectRel>();

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

                objORel_ContentField = new List<clsObjectRel>
                        {
                            new clsObjectRel
                                {
                                    ID_Parent_Object = objLocalConfig.OItem_class_field.GUID,
                                    ID_RelationType = objLocalConfig.OItem_relationtype_parsesource.GUID,
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
                                    objOItem_Result = objDBLevel_UserContentOfField.get_Data_ObjectRel(objORel_ContentField, boolIDs: false);
                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        objOItem_Result = objDBLevel_ReplaceWith.get_Data_ObjectRel(objORel_Replacewith, boolIDs: false);

                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            objOItem_Result = GetSubData_RegExReplace();

                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                            {
                                                var searchContainFields = new List<clsObjectRel>
                                                {
                                                    new clsObjectRel
                                                    {
                                                        ID_Parent_Object = objLocalConfig.OItem_class_field.GUID,
                                                        ID_RelationType =
                                                            objLocalConfig.OItem_relationtype_contains.GUID,
                                                        ID_Parent_Other = objLocalConfig.OItem_class_field.GUID
                                                    }
                                                };

                                                objOItem_Result =
                                                    objDBLevel_ContainedFields.get_Data_ObjectRel(searchContainFields,
                                                        boolIDs: false);

                                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                {
                                                    var searchDoAll = objDBLevel_FieldParser_To_Field.OList_ObjectRel.Select(f => new clsObjectAtt
                                                    {
                                                        ID_Object = f.ID_Other,
                                                        ID_AttributeType = objLocalConfig.OItem_attributetype_doall.GUID
                                                    }).ToList();

                                                    objOItem_Result = objDBLevel_DoAll.get_Data_ObjectAtt(searchDoAll,
                                                        boolIDs: false);
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
                                                                     join objReferenceField in objDBLevel_UserContentOfField.OList_ObjectRel on objField.GUID equals objReferenceField.ID_Object into objReferenceFields
                                                                     from objReferenceField in objReferenceFields.DefaultIfEmpty()
                                                                     join objDoAll in objDBLevel_DoAll.OList_ObjectAtt on objField.GUID equals objDoAll.ID_Object into objDoAlls
                                                                     from objDoAll in objDoAlls.DefaultIfEmpty()
                                                                     join objFieldReplace in ReplaceList on objField.GUID equals objFieldReplace.ID_Field into objFieldReplaces
                                                                     from objFieldReplace in objFieldReplaces.DefaultIfEmpty()
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
                                                                         UseLastValid = objUseLastValid != null ? objUseLastValid.Val_Bit != null ? (bool)objUseLastValid.Val_Bit : false : false,
                                                                         ID_ReferenceField = objReferenceField != null ? objReferenceField.ID_Other : null,
                                                                         Name_ReferenceField = objReferenceField != null ? objReferenceField.Name_Other : null,
                                                                         ID_Attribute_DoAll = objDoAll != null ? objDoAll.ID_Attribute : null,
                                                                         DoAll = objDoAll != null ? (bool)objDoAll.Val_Bool : false,
                                                                         ReplaceList = objFieldReplace != null ? objFieldReplace.ReplaceList : null
                                                                     }).ToList();

                                                        if (objDBLevel_ContainedFields.OList_ObjectRel.Any())
                                                        {
                                                            FieldList.ForEach(field =>
                                                            {
                                                                field.FieldListContained =
                                                                    (from objField in
                                                                        objDBLevel_ContainedFields.OList_ObjectRel.OrderBy(orderField => orderField.OrderID).ThenBy(orderField => orderField.Name_Other)
                                                                        where objField.ID_Object == field.ID_Field
                                                                        join objSubField in FieldList on
                                                                            objField.ID_Other equals
                                                                            objSubField.ID_Field
                                                                        select objSubField).ToList();
                                                            });
                                                        }
                                                    }
                                                }
                                                
                                            }

                                            
                                            
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
            objDBLevel_UserContentOfField = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_DoAll = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RegExReplace = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RegExOfReplace = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RegExRegEx = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RegExReplaceWith = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ContainedFields = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_DocumentItem = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_DocItemToField = new clsDBLevel(objLocalConfig.Globals);

            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
        }
    }
}
