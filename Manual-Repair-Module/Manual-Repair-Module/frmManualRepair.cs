using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using ElasticSearchLogging_Module;

namespace Manual_Repair_Module
{
    public partial class frmManualRepair : Form
    {

        private clsLocalConfig objLocalConfig;
        private clsDataWork_Repair objDataWork_Repair;
        private clsTransaction_Objects objTransaction_Objects;

        public frmManualRepair()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());
            objTransaction_Objects = new clsTransaction_Objects(objLocalConfig.Globals);
            Initialize();
            //Repair_MathematischeKomponenten();
            //Repair_MP3File();
            //Repair_MultipleRelations();
            //RemoveMultipleDataTypes();
            //Move_Versions();
            MoveLogEntries();


        }

        private void MoveLogEntries()
        {
            var dbLevel_LogEntry_Relations = new clsDBLevel(objLocalConfig.Globals);
            var dbLevel_LogEntries = new clsDBLevel(objLocalConfig.Globals);
            var dbLevel_Move = new clsDBLevel(objLocalConfig.Globals);

            var searchLogentries = new List<clsObjectAtt> {
                new clsObjectAtt {
                    ID_AttributeType = "2e5fd016c5744924b724d1b30640243a"
                }};


            var result = dbLevel_LogEntry_Relations.get_Data_ObjectAtt(searchLogentries, boolIDs: false);

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var searchLogentries2 = new List<clsOntologyItem> {
                    new clsOntologyItem
                    {
                        GUID_Parent = "351d45912495450182aba425f5235db9"
                }};

                result = dbLevel_LogEntries.get_Data_Objects(searchLogentries2);

                if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var toMovePre = dbLevel_LogEntry_Relations.OList_ObjectAtt.Where(loge => loge.Val_Datetime < DateTime.Now.AddDays(-90)).ToList();
                    var toMovePre2 = (from att in toMovePre
                                      join loge in dbLevel_LogEntries.OList_Objects on att.ID_Object equals loge.GUID
                                      select loge).ToList();
                    var toMove = (from objLogE in toMovePre2
                                  group objLogE by new { objLogE.GUID, objLogE.Name, objLogE.GUID_Parent } into objLogEs
                                  select new clsOntologyItem
                                  {
                                      GUID = objLogEs.Key.GUID,
                                      Name = objLogEs.Key.Name,
                                      GUID_Parent = objLogEs.Key.GUID_Parent,
                                      Type = objLocalConfig.Globals.Type_Object
                                  }).ToList();

                    var objOItem_Result = objTransaction_Objects.move_Objects(toMove, "2dd8398d4cd14ef391eb30780720e25e");

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                    {
                        MessageBox.Show(this, "Fehler beim Verschieben der Logeinträge!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                


            }
        }

        private void RemoveMultipleDataTypes()
        {
            var dBLevel_DataTypes = new clsDBLevel(objLocalConfig.Globals);

            var objLogging = new clsLogging(objLocalConfig.Globals);

            objLogging.Initialize_Logging(objDataWork_Repair.Log, "multipledatatypes");

            var oItem_Result = dBLevel_DataTypes.get_Data_DataTyps();

            objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
            objLogging.Add_DictEntry("timestamp", DateTime.Now);
            objLogging.Add_DictEntry("step", "search datatypes");
            objLogging.Add_DictEntry("substep", "start");
            objLogging.Finish_Document();

            if (oItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                objLogging.Add_DictEntry("timestamp", DateTime.Now);
                objLogging.Add_DictEntry("step", "search datatypes");
                objLogging.Add_DictEntry("result", "success");
                objLogging.Finish_Document();

                var dataTypeLists = (from objDataType in dBLevel_DataTypes.OList_DataTypes
                                      group objDataType by objDataType.GUID into objDataTypes
                                      select new
                                      {
                                          ID_DataType = objDataTypes.Key,
                                          Count = objDataTypes.Count()
                                      }).Where(dtyp => dtyp.Count > 1)
                                      .Select(dtyp => new clsOntologyItem { GUID = dtyp.ID_DataType }).ToList();

                oItem_Result = dBLevel_DataTypes.del_DataTypes(dataTypeLists);

                objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                objLogging.Add_DictEntry("timestamp", DateTime.Now);
                objLogging.Add_DictEntry("step", "del datatypes");
                objLogging.Add_DictEntry("substep", "start");
                objLogging.Finish_Document();

                if (oItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                    objLogging.Add_DictEntry("timestamp", DateTime.Now);
                    objLogging.Add_DictEntry("step", "del datatypes");
                    objLogging.Add_DictEntry("result", "success");
                    objLogging.Finish_Document();
                }
                else
                {
                    objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                    objLogging.Add_DictEntry("timestamp", DateTime.Now);
                    objLogging.Add_DictEntry("step", "del datatypes");
                    objLogging.Add_DictEntry("result", "error");
                    objLogging.Finish_Document();
                }
            }
            else
            {
                objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                objLogging.Add_DictEntry("timestamp", DateTime.Now);
                objLogging.Add_DictEntry("step", "search datatypes");
                objLogging.Add_DictEntry("result", "error");
                objLogging.Finish_Document();
            }
        }

        private void Initialize()
        {
            objDataWork_Repair = new clsDataWork_Repair(objLocalConfig);
            var result = objDataWork_Repair.GetData_Log();

            if (result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                MessageBox.Show(this, "Das Log-Objekt konnte nicht ermittelt werden", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }

        private void Repair_MultipleRelations()
        {
            var objLogging = new clsLogging(objLocalConfig.Globals);

            objLogging.Initialize_Logging(objDataWork_Repair.Log, "multiplerelations");

            objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
            objLogging.Add_DictEntry("timestamp", DateTime.Now);
            objLogging.Add_DictEntry("step", "search multiple relations");
            objLogging.Add_DictEntry("substep", "start");
            objLogging.Finish_Document();

            var objDBLevel_RelationSearch = new clsDBLevel(objLocalConfig.Globals);
            var objDBLevel_Work = new clsDBLevel(objLocalConfig.Globals);

            var result = objDBLevel_RelationSearch.get_Data_ObjectRel(null, boolIDs: true);

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var multiple = (from objRel in objDBLevel_RelationSearch.OList_ObjectRel_ID
                                group objRel by new { ID_Left = objRel.ID_Object, ID_Right = objRel.ID_Other, ID_RelationType = objRel.ID_RelationType } into objRels
                                select new { Key = objRels.Key, Count = objRels.Count(), GUID = objLocalConfig.Globals.NewGUID })
                                .Where(m => m.Count > 1).ToList();

                objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                objLogging.Add_DictEntry("timestamp", DateTime.Now);
                objLogging.Add_DictEntry("step", "search multiple relations");
                objLogging.Add_DictEntry("count", multiple.Count());
                objLogging.Add_DictEntry("substep", "start");
                objLogging.Finish_Document();

                var relations = (from objRel in objDBLevel_RelationSearch.OList_ObjectRel_ID
                                 join objMult in multiple on new
                                 {
                                     ID_Object = objRel.ID_Object,
                                     ID_Other = objRel.ID_Other,
                                     ID_RelationType = objRel.ID_RelationType
                                 } equals
                                 new
                                 {
                                     ID_Object = objMult.Key.ID_Left,
                                     ID_Other = objMult.Key.ID_Right,
                                     ID_RelationType = objMult.Key.ID_RelationType
                                 }
                                 select new { objRel, objMult.GUID }).OrderBy(m => m.GUID).ToList();

                var relationsSave = new List<clsObjectRel>();
                var relationsDel = new List<clsObjectRel>();
                var guid = "";
                foreach (var relation in relations)
                {
                    if (guid == relation.GUID)
                    {
                        relationsDel.Add(relation.objRel);

                        objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                        objLogging.Add_DictEntry("timestamp", DateTime.Now);
                        objLogging.Add_DictEntry("step", "listadd");
                        objLogging.Add_DictEntry("ontology", relation.objRel.Ontology);
                        objLogging.Add_DictEntry("id_object", relation.objRel.ID_Object);
                        objLogging.Add_DictEntry("id_other", relation.objRel.ID_Other);
                        objLogging.Add_DictEntry("id_relationtype", relation.objRel.ID_RelationType);
                        objLogging.Add_DictEntry("mode", "delete");
                        objLogging.Finish_Document();
                    }
                    else if (guid != relation.GUID)
                    {
                        if (relation.objRel.Ontology == "Object")
                        {
                            if (!string.IsNullOrEmpty(relation.objRel.ID_Object) &&
                                !string.IsNullOrEmpty(relation.objRel.ID_Parent_Object) &&
                                !string.IsNullOrEmpty(relation.objRel.ID_Other) &&
                                !string.IsNullOrEmpty(relation.objRel.ID_Parent_Other) &&
                                !string.IsNullOrEmpty(relation.objRel.ID_RelationType) &&
                                relation.objRel.OrderID != null)
                            {
                                relationsSave.Add(relation.objRel);

                                objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                objLogging.Add_DictEntry("step", "listadd");
                                objLogging.Add_DictEntry("ontology", relation.objRel.Ontology);
                                objLogging.Add_DictEntry("id_object", relation.objRel.ID_Object);
                                objLogging.Add_DictEntry("id_other", relation.objRel.ID_Other);
                                objLogging.Add_DictEntry("id_relationtype", relation.objRel.ID_RelationType);
                                objLogging.Add_DictEntry("mode", "save");
                                objLogging.Finish_Document();
                            }
                            else
                            {
                                relationsDel.Add(relation.objRel);

                                objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                objLogging.Add_DictEntry("step", "listadd");
                                objLogging.Add_DictEntry("ontology", relation.objRel.Ontology);
                                objLogging.Add_DictEntry("id_object", relation.objRel.ID_Object);
                                objLogging.Add_DictEntry("id_other", relation.objRel.ID_Other);
                                objLogging.Add_DictEntry("id_relationtype", relation.objRel.ID_RelationType);
                                objLogging.Add_DictEntry("mode", "delete");
                                objLogging.Finish_Document();
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(relation.objRel.ID_Object) &&
                                !string.IsNullOrEmpty(relation.objRel.ID_Parent_Object) &&
                                !string.IsNullOrEmpty(relation.objRel.ID_Other) &&
                                !string.IsNullOrEmpty(relation.objRel.ID_RelationType) &&
                                relation.objRel.OrderID != null)
                            {
                                relationsSave.Add(relation.objRel);

                                objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                objLogging.Add_DictEntry("step", "listadd");
                                objLogging.Add_DictEntry("ontology", relation.objRel.Ontology);
                                objLogging.Add_DictEntry("id_object", relation.objRel.ID_Object);
                                objLogging.Add_DictEntry("id_other", relation.objRel.ID_Other);
                                objLogging.Add_DictEntry("id_relationtype", relation.objRel.ID_RelationType);
                                objLogging.Add_DictEntry("mode", "save");
                                objLogging.Finish_Document();
                            }
                            else
                            {
                                relationsDel.Add(relation.objRel);

                                objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                objLogging.Add_DictEntry("step", "listadd");
                                objLogging.Add_DictEntry("ontology", relation.objRel.Ontology);
                                objLogging.Add_DictEntry("id_object", relation.objRel.ID_Object);
                                objLogging.Add_DictEntry("id_other", relation.objRel.ID_Other);
                                objLogging.Add_DictEntry("id_relationtype", relation.objRel.ID_RelationType);
                                objLogging.Add_DictEntry("mode", "delete");
                                objLogging.Finish_Document();
                            }
                        }
                        guid = relation.GUID;
                    }
                }

                if (relationsDel.Any())
                {
                    result = objDBLevel_Work.del_ObjectRel(relationsDel);
                    if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                        objLogging.Add_DictEntry("timestamp", DateTime.Now);
                        objLogging.Add_DictEntry("step", "delete relations");
                        objLogging.Add_DictEntry("result", "success");
                        objLogging.Finish_Document();
                    }
                    else
                    {
                        objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                        objLogging.Add_DictEntry("timestamp", DateTime.Now);
                        objLogging.Add_DictEntry("step", "delete relations");
                        objLogging.Add_DictEntry("result", "error");
                        objLogging.Finish_Document();
                    }
                }

            }
            else
            {
                objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                objLogging.Add_DictEntry("timestamp", DateTime.Now);
                objLogging.Add_DictEntry("step", "search multiple relations");
                objLogging.Add_DictEntry("result", "error");
                objLogging.Finish_Document();
            }
        }

        private void Move_Versions()
        {
            

            var objDBLevel_Search1 = new clsDBLevel(objLocalConfig.Globals);
            var objDBLevel_Search2 = new clsDBLevel(objLocalConfig.Globals);
            var objDBLevel_Search3 = new clsDBLevel(objLocalConfig.Globals);
            var objDBLevel_Move = new clsDBLevel(objLocalConfig.Globals);

            var searchClassRels = new List<clsClassRel> { new clsClassRel
            {
                ID_Class_Right = "f30436d62ffc4071af5e3ce708b8c2d9"
            } };

            var objOItem_Result = objDBLevel_Search1.get_Data_ClassRel(searchClassRels, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var searchVersionRels = new List<clsObjectRel> { new clsObjectRel
                {
                    ID_Parent_Other = "f30436d62ffc4071af5e3ce708b8c2d9"
                } };

                objOItem_Result = objDBLevel_Search2.get_Data_ObjectRel(searchVersionRels, boolIDs: false);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var found = (from objRel1 in objDBLevel_Search1.OList_ClassRel
                                 join objRel2 in objDBLevel_Search2.OList_ObjectRel on objRel1.ID_Class_Left equals objRel2.ID_Parent_Object
                                 select new clsOntologyItem
                                 {
                                     GUID = objRel2.ID_Other,
                                     Name = objRel2.Name_Other,
                                     GUID_Parent = objRel2.ID_Parent_Other,
                                     Type = objLocalConfig.Globals.Type_Object
                                 }).ToList();

                    var searchVersions = new List<clsOntologyItem> {
                        new clsOntologyItem
                        {
                            GUID_Parent = "f30436d62ffc4071af5e3ce708b8c2d9"
                        } };

                    objOItem_Result = objDBLevel_Search3.get_Data_Objects(searchVersions);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var move = (from objVer in objDBLevel_Search3.OList_Objects
                                    join objVersionOk in found on objVer.GUID equals objVersionOk.GUID into objVersionsOk
                                    from objVersionOk in objVersionsOk.DefaultIfEmpty()
                                    where objVersionOk == null
                                    select new clsOntologyItem
                                    {
                                        GUID = objVer.GUID,
                                        Name = objVer.Name,
                                        GUID_Parent = objVer.GUID_Parent,
                                        Type = objLocalConfig.Globals.Type_Object
                                    }).ToList();

                        //objOItem_Result = objDBLevel_Move.save_Objects(move);
                        objOItem_Result = objTransaction_Objects.move_Objects(move, "32a3d0fa37444021b200245c9b877418");

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            MessageBox.Show(this, "Die Versionen wurden verschoben.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(this, "Die Versionen konnten nicht verschoben werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                    else
                    {
                        MessageBox.Show(this, "Die Versionen konnten nicht verschoben werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }


                }
                else
                {
                    MessageBox.Show(this, "Die Versionen konnten nicht verschoben werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            


        }

        private void Repair_MP3File()
        {
            var OItem_Class = new clsOntologyItem
            {
                GUID = "0e2285544c7e48e0ba032de51394be4a",
                Name = "mp3-File",
                GUID_Parent = "d84fa125dbce44b091539abeb66ad27f"
            };

            var relationSearch = new List<clsObjectRel> { new clsObjectRel {ID_Parent_Object = OItem_Class.GUID, 
                ID_RelationType = "e07469d9766c443e85266d9c684f944f",
                ID_Parent_Other = "d84fa125dbce44b091539abeb66ad27f" } };

            var objLogging = new clsLogging(objLocalConfig.Globals);

            objLogging.Initialize_Logging(objDataWork_Repair.Log, "mp3tags");

            var objDBLevel_MediaItems = new clsDBLevel(objLocalConfig.Globals);
            var objDBLevel_Files = new clsDBLevel(objLocalConfig.Globals);
            var objDBLevel_Work = new clsDBLevel(objLocalConfig.Globals);

            objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
            objLogging.Add_DictEntry("timestamp", DateTime.Now);
            objLogging.Add_DictEntry("mp3_relations", OItem_Class.GUID);
            objLogging.Add_DictEntry("step", "search mediaitem-relations");
            objLogging.Add_DictEntry("substep", "start");
            objLogging.Finish_Document();

            var result = objDBLevel_MediaItems.get_Data_ObjectRel(relationSearch, boolIDs:false);

            

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                objLogging.Add_DictEntry("timestamp", DateTime.Now);
                objLogging.Add_DictEntry("mp3_relations", OItem_Class.GUID);
                objLogging.Add_DictEntry("step", "search mediaitem-relations");
                objLogging.Add_DictEntry("substep", "end");
                objLogging.Finish_Document();

                objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                objLogging.Add_DictEntry("timestamp", DateTime.Now);
                objLogging.Add_DictEntry("mp3_relations", OItem_Class.GUID);
                objLogging.Add_DictEntry("step", "search files-relations");
                objLogging.Add_DictEntry("substep", "start");
                objLogging.Finish_Document();

                var searchFiles = new List<clsObjectRel> { new clsObjectRel { ID_Parent_Object = "d84fa125dbce44b091539abeb66ad27f",
                    ID_RelationType = "d34d545e9ddf46cebb6f22db1b7bb025",
                    ID_Parent_Other = "6eb4fdd32e254886b288e1bfc2857efb" } };
                    
                result = objDBLevel_Files.get_Data_ObjectRel(searchFiles,boolIDs:false);

                if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {

                    objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                    objLogging.Add_DictEntry("timestamp", DateTime.Now);
                    objLogging.Add_DictEntry("mp3_relations", OItem_Class.GUID);
                    objLogging.Add_DictEntry("step", "search files-relations");
                    objLogging.Add_DictEntry("substep", "end");
                    objLogging.Finish_Document();

                    objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                    objLogging.Add_DictEntry("timestamp", DateTime.Now);
                    objLogging.Add_DictEntry("mp3_relations", OItem_Class.GUID);
                    objLogging.Add_DictEntry("step", "save new relations");
                    objLogging.Add_DictEntry("substep", "start");
                    objLogging.Finish_Document();

                    var fileRelations = (from mediaItem in  objDBLevel_MediaItems.OList_ObjectRel
                                        join file in objDBLevel_Files.OList_ObjectRel on mediaItem.ID_Other equals file.ID_Object
                                        select new clsObjectRel { ID_Object = mediaItem.ID_Object,
                                            ID_Parent_Object = mediaItem.ID_Parent_Object,
                                            ID_RelationType = mediaItem.ID_RelationType,
                                            ID_Other = file.ID_Other,
                                            ID_Parent_Other = file.ID_Parent_Other,
                                            OrderID = mediaItem.OrderID,
                                            Ontology = mediaItem.Ontology }).ToList();

                    if (fileRelations.Any())
                    {
                        result = objDBLevel_Work.save_ObjRel(fileRelations);

                        if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                            objLogging.Add_DictEntry("timestamp", DateTime.Now);
                            objLogging.Add_DictEntry("mp3_relations", OItem_Class.GUID);
                            objLogging.Add_DictEntry("step", "save new relations");
                            objLogging.Add_DictEntry("substep", "end");
                            objLogging.Finish_Document();

                            objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                            objLogging.Add_DictEntry("timestamp", DateTime.Now);
                            objLogging.Add_DictEntry("mp3_relations", OItem_Class.GUID);
                            objLogging.Add_DictEntry("step", "del old relations");
                            objLogging.Add_DictEntry("substep", "start");
                            objLogging.Finish_Document();

                            if (objDBLevel_MediaItems.OList_ObjectRel.Any())
                            {
                                result = objDBLevel_Work.del_ObjectRel(objDBLevel_MediaItems.OList_ObjectRel);
                                if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                    objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                    objLogging.Add_DictEntry("mp3_relations", OItem_Class.GUID);
                                    objLogging.Add_DictEntry("step", "del old relations");
                                    objLogging.Add_DictEntry("substep", "end");
                                    objLogging.Finish_Document();
                                }
                                else
                                {
                                    objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                    objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                    objLogging.Add_DictEntry("mp3_relations", OItem_Class.GUID);
                                    objLogging.Add_DictEntry("result", "error");
                                    objLogging.Finish_Document();
                                }

                            }
                            else
                            {
                                objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                objLogging.Add_DictEntry("mp3_relations", OItem_Class.GUID);
                                objLogging.Add_DictEntry("step", "save new relations");
                                objLogging.Add_DictEntry("substep", "end");
                                objLogging.Add_DictEntry("result", "no file-relations");
                                objLogging.Finish_Document();
                            }
                        }
                        else
                        {
                            objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                            objLogging.Add_DictEntry("timestamp", DateTime.Now);
                            objLogging.Add_DictEntry("mp3_relations", OItem_Class.GUID);
                            objLogging.Add_DictEntry("result", "error");
                            objLogging.Finish_Document();
                        }
                    }
                    else
                    {
                        objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                        objLogging.Add_DictEntry("timestamp", DateTime.Now);
                        objLogging.Add_DictEntry("mp3_relations", OItem_Class.GUID);
                        objLogging.Add_DictEntry("step", "save new relations");
                        objLogging.Add_DictEntry("substep", "end");
                        objLogging.Add_DictEntry("result", "no file-relations");
                        objLogging.Finish_Document();
                    }
                }
                else
                {
                    objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                    objLogging.Add_DictEntry("timestamp", DateTime.Now);
                    objLogging.Add_DictEntry("mp3_relations", OItem_Class.GUID);
                    objLogging.Add_DictEntry("result", "error");
                    objLogging.Finish_Document();
                }

            }
            else
            {
                objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                objLogging.Add_DictEntry("timestamp", DateTime.Now);
                objLogging.Add_DictEntry("mp3_relations", OItem_Class.GUID);
                objLogging.Add_DictEntry("result", "error");
                objLogging.Finish_Document();
            }
        }

        /// <summary>
        ///     Die Klasse enthielt zwei Objekte mit der gleichen ID.
        /// </summary>
        private void Repair_MathematischeKomponenten()
        {
            var OItem_Class = new clsOntologyItem
            {
                GUID = "6ea698d116d74754975673ec3dffb442",
                Name = "Mathematisches Element",
                GUID_Parent = "c2cab57626b34254972addb62067c2be"
            };

            var objectsSearch = new List<clsOntologyItem> { new clsOntologyItem {GUID_Parent = OItem_Class.GUID, 
                Type = objLocalConfig.Globals.Type_Object } };
            var objLogging = new clsLogging(objLocalConfig.Globals);
            objLogging.Initialize_Logging(objDataWork_Repair.Log, "mathekomp");
            

            var objDBLevel = new clsDBLevel(objLocalConfig.Globals);
            var objDBLevel_Attribs = new clsDBLevel(objLocalConfig.Globals);
            var objDBLevel_Relations_LeftRight = new clsDBLevel(objLocalConfig.Globals);
            var objDBLevel_Relations_RightLeft = new clsDBLevel(objLocalConfig.Globals);

            var delAttribs = false;
            var delLeftRight = false;
            var delRightLeft = false;

            objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
            objLogging.Add_DictEntry("timestamp", DateTime.Now);
            objLogging.Add_DictEntry("searchclass_guid", OItem_Class.GUID);
            objLogging.Add_DictEntry("searchclass_name", OItem_Class.Name);
            objLogging.Add_DictEntry("step", "search class");
            objLogging.Add_DictEntry("substep", "start");
            objLogging.Finish_Document();

            var result = objDBLevel.get_Data_Objects(objectsSearch);

            objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
            objLogging.Add_DictEntry("timestamp", DateTime.Now);
            objLogging.Add_DictEntry("searchclass_guid", OItem_Class.GUID);
            objLogging.Add_DictEntry("searchclass_name", OItem_Class.Name);
            objLogging.Add_DictEntry("count_found", objDBLevel.OList_Objects.Count());
            objLogging.Add_DictEntry("step", "search class");
            objLogging.Add_DictEntry("substep", "end");
            objLogging.Finish_Document();

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                
                var GuidGroup = (from objObject in objDBLevel.OList_Objects
                                group objObject by objObject.GUID into objectGroup
                                select new { GUID = objectGroup.Key, Count = objectGroup.Count() }).Where(o => o.Count > 1).ToList();

                var objectItems = (from objObject in objDBLevel.OList_Objects
                                   join objGuidItem in GuidGroup on objObject.GUID equals objGuidItem.GUID
                                   select objObject).ToList();
                foreach (var guidItem in objectItems)
                {
                    objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                    objLogging.Add_DictEntry("timestamp", DateTime.Now);
                    objLogging.Add_DictEntry("guid_item", guidItem.GUID);
                    objLogging.Add_DictEntry("name_item", guidItem.Name);
                    objLogging.Add_DictEntry("guid_class", guidItem.GUID_Parent);
                    objLogging.Add_DictEntry("step", "determine multiple guids");
                    objLogging.Add_DictEntry("substep", "end");
                    objLogging.Finish_Document();    
                }


                if (GuidGroup.Any())
                {
                    var attSearch = GuidGroup.Select(gg => new clsObjectAtt { ID_Object = gg.GUID }).ToList();

                    objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                    objLogging.Add_DictEntry("timestamp", DateTime.Now);
                    objLogging.Add_DictEntry("step", "determine related attributes");
                    objLogging.Add_DictEntry("substep", "start");
                    objLogging.Finish_Document();

                    result = objDBLevel_Attribs.get_Data_ObjectAtt(attSearch, boolIDs: false);

                    if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        foreach (var oAtt in objDBLevel_Attribs.OList_ObjectAtt)
                        {
                            delAttribs = true;
                            objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                            objLogging.Add_DictEntry("timestamp", DateTime.Now);
                            objLogging.Add_DictEntry("object", oAtt.ID_Attribute + ";" + oAtt.ID_AttributeType + ";" + oAtt.ID_Object + ";" + oAtt.ID_DataType + ";" + oAtt.Val_Named);
                            objLogging.Add_DictEntry("objecttype", "object-attribute");
                            objLogging.Add_DictEntry("step", "determine related attributes");
                            objLogging.Add_DictEntry("substep", "log");
                            objLogging.Finish_Document();
                        }
                        objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                        objLogging.Add_DictEntry("timestamp", DateTime.Now);
                        objLogging.Add_DictEntry("step", "determine related attributes");
                        objLogging.Add_DictEntry("substep", "end");
                        objLogging.Finish_Document();


                        var relLRSearch = GuidGroup.Select(gg => new clsObjectRel { ID_Object = gg.GUID }).ToList();

                        objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                        objLogging.Add_DictEntry("timestamp", DateTime.Now);
                        objLogging.Add_DictEntry("step", "determine leftsided-relations");
                        objLogging.Add_DictEntry("substep", "start");
                        objLogging.Finish_Document();

                        result = objDBLevel_Relations_LeftRight.get_Data_ObjectRel(relLRSearch, boolIDs: false);

                        if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            foreach (var oRel in objDBLevel_Relations_LeftRight.OList_ObjectRel)
                            {
                                delLeftRight = true;
                                objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                objLogging.Add_DictEntry("object", oRel.ID_Object + ";" + oRel.ID_Other + ";" + oRel.ID_RelationType + ";" + oRel.OrderID.ToString());
                                objLogging.Add_DictEntry("objecttype", "object-relation-lr");
                                objLogging.Add_DictEntry("step", "determine leftsided-relations");
                                objLogging.Add_DictEntry("substep", "log");
                                objLogging.Finish_Document();
                            }

                            objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                            objLogging.Add_DictEntry("timestamp", DateTime.Now);
                            objLogging.Add_DictEntry("step", "determine leftsided-relations");
                            objLogging.Add_DictEntry("substep", "end");
                            objLogging.Finish_Document();

                            var relRLSearch = GuidGroup.Select(gg => new clsObjectRel { ID_Other = gg.GUID }).ToList();

                            objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                            objLogging.Add_DictEntry("timestamp", DateTime.Now);
                            objLogging.Add_DictEntry("step", "determine rightside-relations");
                            objLogging.Add_DictEntry("substep", "start");
                            objLogging.Finish_Document();

                            result = objDBLevel_Relations_RightLeft.get_Data_ObjectRel(relRLSearch, boolIDs: false);

                            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                foreach (var oRel in objDBLevel_Relations_RightLeft.OList_ObjectRel)
                                {
                                    delRightLeft = true;
                                    objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                    objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                    objLogging.Add_DictEntry("object", oRel.ID_Object + ";" + oRel.ID_Other + ";" + oRel.ID_RelationType + ";" + oRel.OrderID.ToString());
                                    objLogging.Add_DictEntry("objecttype", "object-relation-rl");
                                    objLogging.Add_DictEntry("step", "determine rightside-relations");
                                    objLogging.Add_DictEntry("substep", "log");
                                    objLogging.Finish_Document();
                                }

                                objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                objLogging.Add_DictEntry("step", "determine rightside-relations");
                                objLogging.Add_DictEntry("substep", "end");
                                objLogging.Finish_Document();

                                var objDBLevel_Del = new clsDBLevel(objLocalConfig.Globals);

                                if (delAttribs)
                                {
                                    var attributeDeletes = GuidGroup.Select(gg => new clsObjectAtt { ID_Object = gg.GUID }).ToList();

                                    objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                    objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                    objLogging.Add_DictEntry("step", "delete attributes");
                                    objLogging.Add_DictEntry("substep", "start");
                                    objLogging.Finish_Document();

                                    result = objDBLevel_Del.del_ObjectAtt(attributeDeletes);

                                    objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                    objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                    objLogging.Add_DictEntry("step", "delete attributes");
                                    objLogging.Add_DictEntry("substep", "end");
                                    objLogging.Finish_Document();
                                }

                                if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    if (delLeftRight)
                                    {
                                        var leftRightDeletes = GuidGroup.Select(gg => new clsObjectRel { ID_Object = gg.GUID }).ToList();

                                        objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                        objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                        objLogging.Add_DictEntry("step", "delete left-right");
                                        objLogging.Add_DictEntry("substep", "start");
                                        objLogging.Finish_Document();

                                        result = objDBLevel_Del.del_ObjectRel(leftRightDeletes);

                                        objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                        objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                        objLogging.Add_DictEntry("step", "delete left-right");
                                        objLogging.Add_DictEntry("substep", "end");
                                        objLogging.Finish_Document();
                                    }

                                    if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        if (delRightLeft)
                                        {
                                            var rightLeftDeletes = GuidGroup.Select(gg => new clsObjectRel { ID_Other = gg.GUID }).ToList();

                                            objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                            objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                            objLogging.Add_DictEntry("step", "delete right-left");
                                            objLogging.Add_DictEntry("substep", "start");
                                            objLogging.Finish_Document();

                                            result = objDBLevel_Del.del_ObjectRel(rightLeftDeletes);

                                            objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                            objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                            objLogging.Add_DictEntry("step", "delete right-left");
                                            objLogging.Add_DictEntry("substep", "end");
                                            objLogging.Finish_Document();
                                        }

                                        if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            var objectDeletes = GuidGroup.Select(gg => new clsOntologyItem { GUID = gg.GUID }).ToList();

                                            objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                            objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                            objLogging.Add_DictEntry("step", "delete object");
                                            objLogging.Add_DictEntry("substep", "start");
                                            objLogging.Finish_Document();

                                            result = objDBLevel_Del.del_Objects(objectDeletes);

                                            objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                            objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                            objLogging.Add_DictEntry("step", "delete object");
                                            objLogging.Add_DictEntry("substep", "end");
                                            objLogging.Finish_Document();
                                        }
                                        else
                                        {
                                            objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                            objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                            objLogging.Add_DictEntry("result", "error");
                                            objLogging.Finish_Document();
                                        }
                                    }
                                    else
                                    {
                                        objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                        objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                        objLogging.Add_DictEntry("result", "error");
                                        objLogging.Finish_Document();
                                    }
                                }
                                else
                                {
                                    objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                    objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                    objLogging.Add_DictEntry("result", "error");
                                    objLogging.Finish_Document();
                                }
                            }
                            else
                            {
                                objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                                objLogging.Add_DictEntry("timestamp", DateTime.Now);
                                objLogging.Add_DictEntry("result", "error");
                                objLogging.Finish_Document();
                            }



                        }
                        else
                        {
                            objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                            objLogging.Add_DictEntry("timestamp", DateTime.Now);
                            objLogging.Add_DictEntry("result", "error");
                            objLogging.Finish_Document();
                        }

                    }
                    else
                    {
                        objLogging.Init_Document(objLocalConfig.Globals.NewGUID);
                        objLogging.Add_DictEntry("timestamp", DateTime.Now);
                        objLogging.Add_DictEntry("result", "error");
                        objLogging.Finish_Document();
                    }

                    

                    

                    
                }
                objLogging.Flush_Documents();

                

                
            }


        }
    }
}
