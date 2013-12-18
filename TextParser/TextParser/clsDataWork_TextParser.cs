using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace TextParser
{
    class clsDataWork_TextParser
    {
        private clsLocalConfig objLocalConfig;

        public clsOntologyItem OItem_Result_TextParser { get; set; }
        public clsOntologyItem OItem_Result_TextParsers_leftRight { get; set; }

        private clsDBLevel objDBLevel_TextParser;
       private clsDBLevel objDBLevel_TextParser_LeftRight;
        private clsDBLevel objDBLevel_TextParserOfRef;

        

        private clsOntologyItem objOItem_TextParser;
        private clsOntologyItem objOItem_EVP;

        public clsOntologyItem OItem_EntryValueParser { get; set; }

        public clsOntologyItem OItem_FieldExtractorParser { get; set; }

        public clsOntologyItem OItem_FileResource { get; set; }

        public clsOntologyItem OItem_Index { get; set; }

        public clsOntologyItem OItem_LineSeperator { get; set; }

        public clsOntologyItem OItem_User { get; set; }


        public void CreateRefItems(clsOntologyItem OItem_TextParser)
        {
            var objOList_EntryValueParsers = objDBLevel_TextParser_LeftRight.OList_ObjectRel
                                                                            .Where(
                                                                                p =>
                                                                                p.ID_Object == OItem_TextParser.GUID &&
                                                                                p.ID_Parent_Other ==
                                                                                objLocalConfig
                                                                                    .OItem_class_entry_value_parser.GUID &&
                                                                                p.ID_RelationType ==
                                                                                objLocalConfig.OItem_relationtype_todo
                                                                                              .GUID)
                                                                            .Select(p => new clsOntologyItem
                                                                                {
                                                                                    GUID = p.ID_Other,
                                                                                    Name = p.Name_Other,
                                                                                    GUID_Parent = p.ID_Parent_Other,
                                                                                    Type = p.Ontology
                                                                                });

            if (objOList_EntryValueParsers.Any())
            {
                OItem_EntryValueParser = objOList_EntryValueParsers.First();
            }


        }

        public void GetData_TextParser(clsOntologyItem OItem_TextParser = null)
        {
            objOItem_TextParser = OItem_TextParser;

            var objOList_TextParsers = new List<clsOntologyItem>
                {
                    new clsOntologyItem
                        {
                            GUID = objOItem_TextParser != null ? objOItem_TextParser.GUID: null,
                            GUID_Parent = objLocalConfig.OItem_class_textparser.GUID
                        }
                };

            var objOItem_Result = objDBLevel_TextParser.get_Data_Objects(objOList_TextParsers);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                List<clsObjectRel> objOList_TextParsersRelS = new List<clsObjectRel>();
                objOList_TextParsersRelS.AddRange(objDBLevel_TextParser.OList_Objects.Select(p => new clsObjectRel
                    {
                        ID_Object = p.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_entry_value_parser.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_todo.GUID
                    }));
                
                objOList_TextParsersRelS.AddRange(objDBLevel_TextParser.OList_Objects.Select(p => new clsObjectRel
                    {
                        ID_Object = p.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_field_extractor_parser.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_todo.GUID
                    }));
                objOList_TextParsersRelS.AddRange(objDBLevel_TextParser.OList_Objects.Select(p => new clsObjectRel
                    {
                        ID_Object = p.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_fileresource.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_belonging_resource.GUID
                    }));
                objOList_TextParsersRelS.AddRange(objDBLevel_TextParser.OList_Objects.Select(p => new clsObjectRel
                    {
                        ID_Object = p.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_indexes__elastic_search_.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_located_at.GUID
                    }));
                objOList_TextParsersRelS.AddRange(objDBLevel_TextParser.OList_Objects.Select(p => new clsObjectRel
                    {
                        ID_Object = p.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_text_seperators.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_line_seperator.GUID
                    }));

                objOList_TextParsersRelS.AddRange(objDBLevel_TextParser.OList_Objects.Select(p => new clsObjectRel
                    {
                        ID_Object = p.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_user.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID
                    }));

                
                objOItem_Result = objDBLevel_TextParser_LeftRight.get_Data_ObjectRel(objOList_TextParsersRelS,
                                                                                     boolIDs: false);

            }

            OItem_Result_TextParser = objOItem_Result;
        }
        
        public clsOntologyItem GetTextParserByRef(clsOntologyItem OItem_Ref)
        {
            clsOntologyItem objOItem_TextParser = null;

            var objORel_TextParserOfRef = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Other = OItem_Ref.GUID,
                            ID_Parent_Object = objLocalConfig.OItem_class_textparser.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_belonging_resource.GUID
                        }
                };

            var objOItem_Result = objDBLevel_TextParserOfRef.get_Data_ObjectRel(objORel_TextParserOfRef, boolIDs: false);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var objOList_TextParsers = objDBLevel_TextParserOfRef.OList_ObjectRel.Select(p => new clsOntologyItem
                    {
                        GUID = p.ID_Object,
                        Name = p.Name_Object,
                        GUID_Parent = p.ID_Parent_Object,
                        Type = objLocalConfig.Globals.Type_Object
                    });

                if (objOList_TextParsers.Any())
                {
                    objOItem_TextParser = objOList_TextParsers.First();
                }
            }

            return objOItem_TextParser;
        }

        
        public void GetData_EVP(clsOntologyItem OItem_EVP = null)
        {
            objOItem_EVP = OItem_EVP;
        }

        public void GetData_EVP_Attributes()
        {
            
        }

        public void GetData_EVP_LeftRight()
        {
            
        }

        

        public clsDataWork_TextParser(clsLocalConfig localConfig)
        {
            objLocalConfig = localConfig;
            Initialize();
        }

        private void Initialize()
        {
            OItem_Result_TextParser = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_TextParsers_leftRight = objLocalConfig.Globals.LState_Nothing;
            
            objDBLevel_TextParser = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_TextParser_LeftRight = new clsDBLevel(objLocalConfig.Globals);
            
            objDBLevel_TextParserOfRef = new clsDBLevel(objLocalConfig.Globals);
            
        }
    }
}
