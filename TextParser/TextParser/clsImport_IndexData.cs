using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using ElasticSearchLogging_Module;

namespace TextParser
{
    public class clsImport_IndexData
    {
        private clsLocalConfig objLocalConfig;

        private clsDataWork_Import objDataWork_Import;


        private clsLogging objLogging;

        private clsAppDBLevel objAppDBLevel_Index;

        private clsDBLevel objDBLevel1;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        private clsOntologyItem objOItem_TextParser;


        public clsImport_IndexData(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        public clsOntologyItem ImportIndexData(clsOntologyItem OItem_TextParser, string query = null)
        {
            var importDateTime = DateTime.Now;
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            objOItem_TextParser = OItem_TextParser;

            objOItem_Result = objDataWork_Import.GetData(objOItem_TextParser);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                int port;
                if (int.TryParse(objDataWork_Import.OItem_Port.Name, out port))
                {
                    objAppDBLevel_Index = new clsAppDBLevel(objDataWork_Import.OItem_Server.Name, port, objDataWork_Import.OItem_Index.Name, objLocalConfig.Globals.SearchRange, objLocalConfig.Globals.Session);
                    
                    var objDocuments = objAppDBLevel_Index.GetData_Documents(objDataWork_Import.OItem_Index.Name, objDataWork_Import.OItem_Type.Name,strQuery:query);

                    var objORel_FieldsToItems = objDataWork_Import.OList_FieldToItem.OrderBy(fi => fi.OrderID).ToList();

                    var todo = objDocuments.Count;
                    var done = 0;
                    var doneInsert = false;
                    

                    foreach (var objDoc in objDocuments)
                    {

                        objLocalConfig.objLogging.Init_Document(objDoc.Id);
                        objLocalConfig.objLogging.Add_DictEntry("timestamp_log", importDateTime);
                        objLocalConfig.objLogging.Add_DictEntry("timestamp", DateTime.Now);

                        objLocalConfig.objLogging.Add_DictEntry("index", objDataWork_Import.OItem_Index.Name + "@" + objDataWork_Import.OItem_Server.Name);
                        objLocalConfig.objLogging.Add_DictEntry("docid", objDoc.Id);

                        var objOList_Fields = new List<clsOntologyItem>();

                        if (doneInsert)
                        {
                            done++;
                        }
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                        {
                            objLocalConfig.objLogging.Add_DictEntry("error", "document");
                            break;
                        }

                        doneInsert = false;
                        objTransaction.ClearItems();
                        var fieldCount = -1;
                        foreach (var objFieldToItem in objORel_FieldsToItems)
                        {
                            fieldCount++;
                            objLocalConfig.objLogging.Add_DictEntry("fieldtoitem_id_" + fieldCount, objFieldToItem.ID_Other);
                            objLocalConfig.objLogging.Add_DictEntry("fieldtoitem_name_" + fieldCount, objFieldToItem.Name_Other);

                            var objOItem_FieldToItem = new clsOntologyItem
                            {
                                GUID = objFieldToItem.ID_Other,
                                Name = objFieldToItem.Name_Other,
                                GUID_Parent = objFieldToItem.ID_Parent_Other,
                                Type = objLocalConfig.Globals.Type_Object
                            };

                            var objFields = objDataWork_Import.Get_FieldsOfFieldToItem(objOItem_FieldToItem).ToList();

                            var objOItem_Of_FieldToItem = objDataWork_Import.Get_OItemOfFieldToItem(objOItem_FieldToItem);

                            var strName = "";

                            foreach (var objOItem_Field in objFields)
                            {
                                if (objDoc.Dict.ContainsKey(objOItem_Field.Name))
                                {
                                    if (objDoc.Dict[objOItem_Field.Name].ToString() != null)
                                    {
                                        strName += objDoc.Dict[objOItem_Field.Name].ToString();
                                    }
                                    else
                                    {
                                        strName += "unknown";
                                    }
                                    
                                }
                                else
                                {
                                    strName += "unknown";
                                }
                                
                            }


                            if (objOItem_Of_FieldToItem.Type == objLocalConfig.Globals.Type_Class)
                            {
                                var objOSearch_Items = new List<clsOntologyItem> { new clsOntologyItem
                                {
                                    Name = strName,
                                    GUID_Parent = objOItem_Of_FieldToItem.GUID,
                                    Type = objLocalConfig.Globals.Type_Object
                                } };

                                objOItem_Result = objDBLevel1.get_Data_Objects(objOSearch_Items);

                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    var countItems = objDBLevel1.OList_Objects.Where(o => o.Name == strName).Count();
                                    if (countItems == 0)
                                    {
                                        doneInsert = true;
                                        var objOItem_Object = new clsOntologyItem
                                        {
                                            GUID = objLocalConfig.Globals.NewGUID,
                                            Name = strName,
                                            GUID_Parent = objOItem_Of_FieldToItem.GUID,
                                            Type = objLocalConfig.Globals.Type_Object
                                        };

                                        objLocalConfig.objLogging.Add_DictEntry("object_id_" + fieldCount, objOItem_Object.GUID);
                                        objLocalConfig.objLogging.Add_DictEntry("object_name_" + fieldCount, objOItem_Object.Name);
                                        objLocalConfig.objLogging.Add_DictEntry("object_id_parent_" + fieldCount, objOItem_Object.GUID_Parent);
                                        objLocalConfig.objLogging.Add_DictEntry("object_operation_" + fieldCount, "insert");

                                        objOList_Fields.Add(objOItem_Object);

                                        objOItem_Result = objTransaction.do_Transaction(objOItem_Object);
                                    }
                                    else
                                    {
                                        objOList_Fields.Add(new clsOntologyItem
                                        {
                                            GUID = objDBLevel1.OList_Objects.First().GUID,
                                            Name = objDBLevel1.OList_Objects.First().Name,
                                            GUID_Parent = objDBLevel1.OList_Objects.First().GUID_Parent,
                                            Type = objDBLevel1.OList_Objects.First().Type
                                        });

                                        objLocalConfig.objLogging.Add_DictEntry("object_id_" + fieldCount, objDBLevel1.OList_Objects.First().GUID);
                                        objLocalConfig.objLogging.Add_DictEntry("object_name_" + fieldCount, objDBLevel1.OList_Objects.First().Name);
                                        objLocalConfig.objLogging.Add_DictEntry("object_id_parent_" + fieldCount, objDBLevel1.OList_Objects.First().GUID_Parent);
                                        objLocalConfig.objLogging.Add_DictEntry("object_operation_" + fieldCount, "exist");
                                    }

                                }
                                


                                

                            }
                            else if (objOItem_Of_FieldToItem.Type == objLocalConfig.Globals.Type_AttributeType)
                            {
                                var objRel_Attributes = objDataWork_Import.Get_Related_Attributes(objOList_Fields,
                                    objOItem_Of_FieldToItem,
                                    objDoc.Dict.ContainsKey(objFields.First().Name) ? objDoc.Dict[objFields.First().Name] : null );

                                objLocalConfig.objLogging.Add_DictEntry("attribute_" + fieldCount, objOItem_Of_FieldToItem.Name);
                                foreach (var objORel in objRel_Attributes)
                                {
                                    objOItem_Result = objTransaction.do_Transaction(objORel, true);
                                    
                                    
                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                                    {
                                        objLocalConfig.objLogging.Add_DictEntry("error", "Attribute");
                                        break;
                                    }
                                }
                            }

                        }

                        var objORel_Objects = objDataWork_Import.Get_Related(objOList_Fields);
                        objLocalConfig.objLogging.Add_DictEntry("relations_" + fieldCount, objORel_Objects.Count);
                        if (objORel_Objects.Any())
                        {
                            
                            foreach (var objORel in objORel_Objects)
                            {
                                objOItem_Result = objTransaction.do_Transaction(objORel, true);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                                {
                                    objLocalConfig.objLogging.Add_DictEntry("error", "Relation");
                                    break;
                                }
                            }
                        }

                        objLocalConfig.objLogging.Finish_Document();

                        
                    }

                    objLocalConfig.objLogging.Flush_Documents();
                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                }

                
            }
            

            

            return objOItem_Result;
        }

        private void Initialize()
        {
            objDataWork_Import = new clsDataWork_Import(objLocalConfig);

            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);

            objDBLevel1 = new clsDBLevel(objLocalConfig.Globals);

            objLogging = new clsLogging(objLocalConfig.Globals);
        }

    }
}
