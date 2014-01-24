using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using System.Threading;

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
        private clsDBLevel objDBLevel_Index_To_Rel;
        private clsDBLevel objDBLevel_ServerPort_Rel;

        

        private clsOntologyItem objOItem_TextParser;
        private clsOntologyItem objOItem_EVP;

        public clsOntologyItem OItem_EntryValueParser { get; set; }

        public clsOntologyItem OItem_FieldExtractorParser { get; set; }

        public clsOntologyItem OItem_FileResource { get; set; }

        public clsOntologyItem OItem_Index { get; set; }

        public clsOntologyItem OItem_LineSeperator { get; set; }

        public clsOntologyItem OItem_User { get; set; }

        public clsOntologyItem OItem_Result_Index { get; private set; }

        public List<clsOntologyItem> OList_Variables { get; set; }

        public clsOntologyItem OItem_Port { get; set; }

        public clsOntologyItem OItem_Server { get; set; }

        public clsOntologyItem OITem_Type { get; set; }

        private clsOntologyItem objOItem_Index;

        private Thread thread_Index;


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

            var objOList_FieldExtractorParser = objDBLevel_TextParser_LeftRight.OList_ObjectRel
                                                                            .Where(
                                                                                p =>
                                                                                p.ID_Object == OItem_TextParser.GUID &&
                                                                                p.ID_Parent_Other ==
                                                                                objLocalConfig
                                                                                    .OItem_class_field_extractor_parser.GUID &&
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

            if (objOList_FieldExtractorParser.Any())
            {
                OItem_FieldExtractorParser = objOList_FieldExtractorParser.First();
            }

            var objOList_FileResource = objDBLevel_TextParser_LeftRight.OList_ObjectRel
                                                                            .Where(
                                                                                p =>
                                                                                p.ID_Object == OItem_TextParser.GUID &&
                                                                                p.ID_Parent_Other ==
                                                                                objLocalConfig
                                                                                    .OItem_class_fileresource.GUID &&
                                                                                p.ID_RelationType ==
                                                                                objLocalConfig.OItem_relationtype_belonging_resource
                                                                                              .GUID)
                                                                            .Select(p => new clsOntologyItem
                                                                            {
                                                                                GUID = p.ID_Other,
                                                                                Name = p.Name_Other,
                                                                                GUID_Parent = p.ID_Parent_Other,
                                                                                Type = p.Ontology
                                                                            });

            if (objOList_FileResource.Any())
            {
                OItem_FileResource = objOList_FileResource.First();
            }

            var objOList_Index = objDBLevel_TextParser_LeftRight.OList_ObjectRel
                                                                            .Where(
                                                                                p =>
                                                                                p.ID_Object == OItem_TextParser.GUID &&
                                                                                p.ID_Parent_Other ==
                                                                                objLocalConfig
                                                                                    .OItem_class_indexes__elastic_search_.GUID &&
                                                                                p.ID_RelationType ==
                                                                                objLocalConfig.OItem_relationtype_located_at
                                                                                              .GUID)
                                                                            .Select(p => new clsOntologyItem
                                                                            {
                                                                                GUID = p.ID_Other,
                                                                                Name = p.Name_Other,
                                                                                GUID_Parent = p.ID_Parent_Other,
                                                                                Type = p.Ontology
                                                                            });

            if (objOList_Index.Any())
            {
                OItem_Index = objOList_Index.First();
            }

            var objOList_LineSeperator = objDBLevel_TextParser_LeftRight.OList_ObjectRel
                                                                            .Where(
                                                                                p =>
                                                                                p.ID_Object == OItem_TextParser.GUID &&
                                                                                p.ID_Parent_Other ==
                                                                                objLocalConfig
                                                                                    .OItem_class_text_seperators.GUID &&
                                                                                p.ID_RelationType ==
                                                                                objLocalConfig.OItem_relationtype_line_seperator
                                                                                              .GUID)
                                                                            .Select(p => new clsOntologyItem
                                                                            {
                                                                                GUID = p.ID_Other,
                                                                                Name = p.Name_Other,
                                                                                GUID_Parent = p.ID_Parent_Other,
                                                                                Type = p.Ontology
                                                                            });

            if (objOList_LineSeperator.Any())
            {
                OItem_LineSeperator = objOList_LineSeperator.First();
            }

            var objOList_User = objDBLevel_TextParser_LeftRight.OList_ObjectRel
                                                                            .Where(
                                                                                p =>
                                                                                p.ID_Object == OItem_TextParser.GUID &&
                                                                                p.ID_Parent_Other ==
                                                                                objLocalConfig
                                                                                    .OItem_class_user.GUID &&
                                                                                p.ID_RelationType ==
                                                                                objLocalConfig.OItem_relationtype_belongs_to
                                                                                              .GUID)
                                                                            .Select(p => new clsOntologyItem
                                                                            {
                                                                                GUID = p.ID_Other,
                                                                                Name = p.Name_Other,
                                                                                GUID_Parent = p.ID_Parent_Other,
                                                                                Type = p.Ontology
                                                                            });

            if (objOList_User.Any())
            {
                OItem_User = objOList_User.First();
            }
        }

        public clsOntologyItem GetData_IndexData(clsOntologyItem OItem_Index)
        {
            try
            {
                thread_Index.Abort();
            }
            catch (Exception ex)
            {

            }

            objOItem_Index = OItem_Index;
            OItem_Result_Index = objLocalConfig.Globals.LState_Nothing.Clone();

            var OItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            thread_Index = new Thread(GetDataAsync_IndexData);

            thread_Index.Start();

            return OItem_Result;
        }

        public void GetDataAsync_IndexData()
        {
            OItem_Result_Index = objLocalConfig.Globals.LState_Nothing.Clone();

            var relS_Index_Rel = new List<clsObjectRel> { 
                new clsObjectRel {ID_Object = objOItem_Index.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_server_port.GUID }, 
                new clsObjectRel {ID_Object = objOItem_Index.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID, 
                    ID_Parent_Other = objLocalConfig.OItem_class_variable.GUID } 
            };


            var objOITem_Result = objDBLevel_Index_To_Rel.get_Data_ObjectRel(relS_Index_Rel, boolIDs: false);
            
            if (objOITem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_Variables = objDBLevel_Index_To_Rel.OList_ObjectRel.Where(p => p.ID_Parent_Other == objLocalConfig.OItem_class_variable.GUID).Select(p => new clsOntologyItem
                {
                    GUID = p.ID_Other,
                    Name = p.Name_Other,
                    GUID_Parent = p.ID_Parent_Other,
                    Type = p.Ontology
                }).ToList();



                var relS_ServerPort_Rel = objDBLevel_Index_To_Rel.OList_ObjectRel.Where(p => p.ID_Parent_Other == objLocalConfig.OItem_class_server_port.GUID)
                        .Select(p => new clsObjectRel
                        {
                            ID_Object = p.ID_Other,
                            ID_Parent_Other = objLocalConfig.OItem_class_port.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID
                        }).ToList();
                relS_ServerPort_Rel.AddRange(objDBLevel_Index_To_Rel.OList_ObjectRel.Where(p => p.ID_Parent_Other == objLocalConfig.OItem_class_server_port.GUID)
                        .Select(p => new clsObjectRel
                        {
                            ID_Object = p.ID_Other,
                            ID_Parent_Other = objLocalConfig.OItem_class_server.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID
                        }));

                objOITem_Result = objDBLevel_ServerPort_Rel.get_Data_ObjectRel(relS_ServerPort_Rel, boolIDs: false);

                if (objOITem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var oList_Ports = objDBLevel_ServerPort_Rel.OList_ObjectRel.Where(p => p.ID_Parent_Other == objLocalConfig.OItem_class_port.GUID).Select(p => new clsOntologyItem
                    {
                        GUID = p.ID_Other,
                        Name = p.Name_Other,
                        GUID_Parent = p.ID_Parent_Other,
                        Type = p.Ontology
                    }).ToList();

                    OItem_Port = null;
                    OItem_Server = null;

                    if (oList_Ports.Any())
                    {
                        OItem_Port = oList_Ports.First();
                    }

                    var oList_Servers = objDBLevel_ServerPort_Rel.OList_ObjectRel.Where(p => p.ID_Parent_Other == objLocalConfig.OItem_class_server.GUID).Select(p => new clsOntologyItem
                    {
                        GUID = p.ID_Other,
                        Name = p.Name_Other,
                        GUID_Parent = p.ID_Parent_Other,
                        Type = p.Ontology
                    }).ToList();

                    if (oList_Servers.Any())
                    {
                        OItem_Server = oList_Servers.First();
                    }
                }

                OItem_Result_Index = objOITem_Result;
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

                objOList_TextParsersRelS.AddRange(objDBLevel_TextParser.OList_Objects.Select(p => new clsObjectRel
                {
                    ID_Object = p.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_types__elastic_search_.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belonging.GUID
                }));

                
                objOItem_Result = objDBLevel_TextParser_LeftRight.get_Data_ObjectRel(objOList_TextParsersRelS,
                                                                                     boolIDs: false);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID && OItem_TextParser != null)
                {
                    var objOList_Types = objDBLevel_TextParser_LeftRight.OList_ObjectRel.Where(p => p.ID_Parent_Other == objLocalConfig.OItem_class_types__elastic_search_.GUID &&
                        p.ID_RelationType == objLocalConfig.OItem_relationtype_belonging.GUID).Select(p => new clsOntologyItem {GUID = p.ID_Other, 
                            Name = p.Name_Other, 
                            GUID_Parent = p.ID_Parent_Other, 
                            Type = objLocalConfig.Globals.Type_Object}).ToList();

                    if (objOList_Types.Any())
                    {
                        OITem_Type = objOList_Types.First();
                    }
                    else
                    {
                        OITem_Type = null;
                    }


                }
                    else
                    {
                        OITem_Type = null;
                    }
            }

            OItem_Result_TextParser = objOItem_Result;
        }
        
        public List<clsObjectRel> GetTextParserByRef(clsOntologyItem OItem_Ref)
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
                return objDBLevel_TextParserOfRef.OList_ObjectRel;
            }

            return null;
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

            objDBLevel_Index_To_Rel = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ServerPort_Rel = new clsDBLevel(objLocalConfig.Globals);
            
            objDBLevel_TextParserOfRef = new clsDBLevel(objLocalConfig.Globals);

            OItem_Result_Index = objLocalConfig.Globals.LState_Nothing.Clone();
        }
    }
}
