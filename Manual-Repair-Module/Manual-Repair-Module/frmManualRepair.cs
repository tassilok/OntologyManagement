﻿using System;
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

        public frmManualRepair()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());
            Initialize();
            Repair_MathematischeKomponenten();
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