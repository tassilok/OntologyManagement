using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using System.IO;
using System.Web;
using System.IO;
using ClassLibrary_ShellWork;
using OntologyClasses.BaseClasses;

namespace GraphMLConnector
{
    public class clsGraphMLWork
    {
        private clsLocalConfig objLocalConfig;
        private clsXMLTemplateWork objXMLTemplateWork;

        public List<clsClassRel> OList_ClassRel { get; set; }
        public List<clsClassAtt> OList_ClassAtt { get; set; }
        public List<clsOntologyItem> OList_ExportItems { get; set; }
        public List<clsOntologyItem> OList_Classes { get; set; }
        public List<clsOntologyItem> OList_Objects { get; set; }
        public List<clsOntologyItem> OList_AttributeTypes { get; set; }
        public List<clsOntologyItem> OList_RelationTypes { get; set; }
        public List<clsObjectRel> OList_ORels { get; set; }
        public List<clsObjectAtt> OList_OAtts { get; set; }

        public List<clsExportModes> OList_EModes { get; set; }

        private clsDBLevel objDBLevel1;
        private clsDBLevel objDBLevel2;

        private clsShellWork objShellWork = new clsShellWork();

        public clsGraphMLWork(clsLocalConfig localConfig)
        {
            objLocalConfig = localConfig;

            set_DBConnection();
            initialize();
        }

        public clsGraphMLWork(clsGlobals Globals)
        {
            objLocalConfig = new clsLocalConfig(Globals);

            set_DBConnection();
            initialize();
        }

        public void ClearLists()
        {
            OList_AttributeTypes.Clear();
            OList_ClassAtt.Clear();
            OList_ClassRel.Clear();
            OList_Classes.Clear();
            OList_EModes.Clear();
            OList_ExportItems.Clear();
            OList_OAtts.Clear();
            OList_ORels.Clear();
            OList_Objects.Clear();
            OList_RelationTypes.Clear();
        }


        public clsOntologyItem GetItemLists(List<clsOntologyItemsOfOntologies> OList_OntologyItems)
        {
            OList_AttributeTypes = OList_OntologyItems.Where(p => p.Type_Ref == objLocalConfig.Globals.Type_AttributeType).Select(p => new clsOntologyItem
            {
                GUID = p.ID_Ref,
                Name = p.Name_Ref,
                GUID_Parent = p.ID_Parent_Ref,
                Type = objLocalConfig.Globals.Type_AttributeType
            }).ToList();

            OList_RelationTypes = OList_OntologyItems.Where(p => p.Type_Ref == objLocalConfig.Globals.Type_RelationType).Select(p => new clsOntologyItem
            {
                GUID = p.ID_Ref,
                Name = p.Name_Ref,
                GUID_Parent = p.ID_Parent_Ref,
                Type = objLocalConfig.Globals.Type_RelationType
            }).ToList();

            OList_Classes = OList_OntologyItems.Where(p => p.Type_Ref == objLocalConfig.Globals.Type_Class).Select(p => new clsOntologyItem
            {
                GUID = p.ID_Ref,
                Name = p.Name_Ref,
                GUID_Parent = p.ID_Parent_Ref,
                Type = objLocalConfig.Globals.Type_Class
            }).ToList();

            OList_Objects = OList_OntologyItems.Where(p => p.Type_Ref == objLocalConfig.Globals.Type_Object).Select(p => new clsOntologyItem
            {
                GUID = p.ID_Ref,
                Name = p.Name_Ref,
                GUID_Parent = p.ID_Parent_Ref,
                Type = objLocalConfig.Globals.Type_Object
            }).ToList();


            var objOItem_Result = objDBLevel1.get_Data_Classes(null, false, false, null, false);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var oList_ClassesOfObjects = (from objClass in objDBLevel1.OList_Classes
                                              join objObject in OList_Objects on objClass.GUID equals objObject.GUID_Parent
                                              group objClass by objClass.GUID into g
                                              select new { GUID = g.Key, Classes = g }).ToList();

                OList_Classes = OList_Classes.Concat((from objClass in oList_ClassesOfObjects
                                                      join objClassExist in OList_Classes on objClass.GUID equals
                                                          objClassExist.GUID into objClassesExist
                                                      from objClassExist in objClassesExist.DefaultIfEmpty()
                                                      where objClassExist == null
                                                      select
                                                          new clsOntologyItem(GUID_Item: objClass.GUID,
                                                                              Name_Item: objClass.Classes.First().Name,
                                                                              GUID_Item_Parent: objClass.Classes.First().GUID_Parent,
                                                                              Type: objLocalConfig.Globals.Type_Class))
                                                         .ToList()).ToList();

                //var oList_ClassesWithChildren = (from objClass in OList_Classes
                //                                 join objExportMode in OList_EModes on objClass.GUID equals
                //                                     objExportMode.ID_Item
                //                                 where
                //                                     objExportMode.ID_ExportMode ==
                //                                     objLocalConfig.OItem_object_grant_children_of_item.GUID
                //                                 select
                //                                     new clsOntologyItem
                //                                     {
                //                                         GUID = objClass.GUID,
                //                                         Type = objLocalConfig.Globals.Type_Object
                //                                     }).ToList();

                var oList_ClassesWithChildren = (from objClass in OList_Classes
                                                 join objOItem in OList_OntologyItems on objClass.GUID equals objOItem.ID_Ref
                                                 where objOItem.ID_OntologyRelationRule == objLocalConfig.OItem_object_child_token.GUID
                                                 select new clsOntologyItem
                                                 {
                                                     GUID_Parent = objClass.GUID,
                                                     Type = objLocalConfig.Globals.Type_Object
                                                 }).ToList();

                objOItem_Result = objLocalConfig.Globals.LState_Success;
                if (oList_ClassesWithChildren.Any())
                {
                    objOItem_Result = objDBLevel1.get_Data_Objects(oList_ClassesWithChildren);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        OList_Objects = OList_Objects.Concat(objDBLevel1.OList_Objects).ToList();
                    }


                }

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOItem_Result = objDBLevel1.get_Data_ClassRel(null, true);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        OList_ClassRel = (from objClass_Left in OList_Classes
                                          join objClassRel in objDBLevel1.OList_ClassRel_ID on objClass_Left.GUID equals
                                              objClassRel.ID_Class_Left
                                          join objClass_Right in OList_Classes on objClassRel.ID_Class_Right equals
                                               objClass_Right.GUID
                                          join objRelType in OList_RelationTypes on objClassRel.ID_RelationType equals
                                              objRelType.GUID
                                          select new clsClassRel()
                                          {
                                              ID_Class_Left = objClassRel.ID_Class_Left,
                                              ID_Class_Right = objClassRel.ID_Class_Right,
                                              ID_RelationType = objClassRel.ID_RelationType,
                                              Name_RelationType = objRelType.Name,
                                              Min_Forw = objClassRel.Min_Forw,
                                              Max_Forw = objClassRel.Max_Forw,
                                              Max_Backw = objClassRel.Max_Backw,
                                              Name_Class_Left = objClass_Left.Name,
                                              Name_Class_Right = objClass_Right.Name
                                          }).ToList();


                        var oList_ClassAtt = new List<clsClassAtt>();
                        oList_ClassAtt.Add(new clsClassAtt(null, null, null, null, null));


                        objOItem_Result = objDBLevel1.get_Data_ClassAtt(null, null, false, true, false);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objOItem_Result = objDBLevel2.get_Data_DataTyps(null, false, false);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                OList_ClassAtt = (from objClass in OList_Classes
                                                  join objClassAtt in objDBLevel1.OList_ClassAtt_ID on objClass.GUID equals
                                                      objClassAtt.ID_Class
                                                  join objAttType in OList_AttributeTypes on objClassAtt.ID_AttributeType equals
                                                      objAttType.GUID
                                                  join objDataType in objDBLevel2.OList_DataTypes on objAttType.GUID_Parent equals objDataType.GUID
                                                  select new clsClassAtt()
                                                  {
                                                      ID_AttributeType = objAttType.GUID,
                                                      Name_AttributeType = objAttType.Name,
                                                      Name_DataType = objDataType.Name,
                                                      ID_Class = objClass.GUID,
                                                      ID_DataType = objDataType.GUID,
                                                      Min = objClassAtt.Min,
                                                      Max = objClassAtt.Max
                                                  }).ToList();


                                if (OList_Objects.Any())
                                {
                                    objOItem_Result = objDBLevel1.get_Data_ObjectRel(null, false, true, false, null, true, false);

                                }
                                else
                                {
                                    objOItem_Result = objLocalConfig.Globals.LState_Nothing;
                                }

                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        OList_ORels = (from objObjectLeft in OList_Objects
                                                       join objORel in objDBLevel1.OList_ObjectRel_ID on objObjectLeft.GUID equals
                                                           objORel.ID_Object
                                                       join objObjectRight in OList_Objects on objORel.ID_Other equals
                                                           objObjectRight.GUID
                                                       select objORel).ToList();
                                    }
                                    else
                                    {
                                        OList_ORels.Clear();
                                    }


                                    if (OList_AttributeTypes.Any())
                                    {
                                        objOItem_Result = objDBLevel1.get_Data_ObjectAtt(null, false, true, false, false);
                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {


                                            OList_OAtts = (from objObject in OList_Objects
                                                           join objOAtt in objDBLevel1.OList_ObjectAtt_ID on objObject.GUID equals
                                                               objOAtt.ID_Object
                                                           join objAttType in OList_AttributeTypes on objOAtt.ID_AttributeType equals objAttType.GUID
                                                           select new clsObjectAtt() { ID_Object = objOAtt.ID_Object, Val_Named = objOAtt.Val_Named, Name_AttributeType = objAttType.Name }).ToList();
                                        }
                                    }
                                    else
                                    {
                                        OList_OAtts.Clear();
                                    }


                                }
                                else if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
                                {
                                    objOItem_Result = objLocalConfig.Globals.LState_Success;
                                }
                            }

                        }
                    }
                }

            }



            return objOItem_Result;

        }


        public clsOntologyItem ExportItems(string path, 
            bool doClasses = true, 
            bool doClassRel = true, 
            bool doClassAtt = true,
            bool doObjects = true, 
            bool doObjAtt = true, 
            bool doObjRel = true,
            bool doRelationTypes = true,
            bool doAttributeTypes = true)
        {
            var objOItem_Result = new clsOntologyItem();
            string NodeXML;
            string EdgeXML;

            try
            {
                if (!Directory.Exists(path.Substring(0,path.Length - Path.GetFileName(path).Length)))
                {
                    Directory.CreateDirectory(path.Substring(0,path.Length - Path.GetFileName(path).Length));
                }

                if (File.Exists(path))
                {
                    File.Delete(path);
                }

            
                TextWriter objTextWriter = new StreamWriter(path);
                objTextWriter.WriteLine(objXMLTemplateWork.UML_Container.Substring(0, objXMLTemplateWork.UML_Container.IndexOf("@" + objLocalConfig.OItem_object_node_list.Name + "@") - 1));

                if (doClasses)
                {
                    foreach (var oItem_Class in OList_Classes)
                    {
                        NodeXML = objXMLTemplateWork.UML_ClassNode;
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_id.Name + "@", oItem_Class.GUID);
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_name_node.Name + "@", HttpUtility.HtmlEncode(oItem_Class.Name));
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_color_fill.Name + "@", "#003300");
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_color_text.Name + "@", "#ffffff");

                        var ClassAtt = "";
                        var OList_ClassAtts = from objOClass in OList_ClassAtt
                                              where objOClass.ID_Class == oItem_Class.GUID
                                              select new { Caption = objOClass.Name_AttributeType + ": " + objOClass.Name_DataType };

                        if (doClassAtt)
                        {
                            foreach (var oItem_ClassAtt in OList_ClassAtts)
                            {
                                if (ClassAtt != "")
                                {
                                    ClassAtt += "\n";
                                }
                                ClassAtt += HttpUtility.HtmlEncode(oItem_ClassAtt.Caption);
                            }
                            NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_attrib_list.Name + "@", ClassAtt);
                        }
                        else
                        {
                            NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_attrib_list.Name + "@", "");
                        }
                        

                        objTextWriter.WriteLine(NodeXML);
                    }
                }


                if (doClasses && doClassRel)
                {
                    foreach (var oItem_ClassRel in OList_ClassRel)
                    {
                        EdgeXML = objXMLTemplateWork.UML_Edge;
                        EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_id.Name + "@",
                                                  oItem_ClassRel.ID_Class_Left + oItem_ClassRel.ID_Class_Right +
                                                  oItem_ClassRel.ID_RelationType);
                        EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_id_left.Name + "@",
                                                  oItem_ClassRel.ID_Class_Left);
                        EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_id_right.Name + "@",
                                                  oItem_ClassRel.ID_Class_Right);
                        EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_name_relationtype.Name + "@",
                                                  HttpUtility.HtmlEncode(oItem_ClassRel.Name_RelationType));

                        objTextWriter.WriteLine(EdgeXML);
                    }
                }


                if (doObjects)
                {
                    foreach (var oItem_Object in OList_Objects)
                    {
                        NodeXML = objXMLTemplateWork.UML_ClassNode;
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_id.Name + "@", oItem_Object.GUID);
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_name_node.Name + "@", HttpUtility.HtmlEncode(oItem_Object.Name));
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_color_fill.Name + "@", "#ffcc00");
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_color_text.Name + "@", "#000000");

                        var ObjAtt = "";

                        var OList_ObjAtts = from objOAtt in OList_OAtts
                                            where objOAtt.ID_Object == oItem_Object.GUID
                                            select
                                                new
                                                {
                                                    Caption =
                                            objOAtt.Name_AttributeType + ": " +
                                            (objOAtt.Val_Named.Length > 20
                                                 ? objOAtt.Val_Named.Substring(0, 20)
                                                 : objOAtt.Val_Named)
                                                };
                        if (doObjAtt)
                        {
                            foreach (var objOAtt in OList_ObjAtts)
                            {
                                if (ObjAtt != "")
                                {
                                    ObjAtt += "\n";
                                }
                                ObjAtt += HttpUtility.HtmlEncode(objOAtt.Caption);
                            }
                            NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_attrib_list.Name + "@", ObjAtt);
                        }
                        else
                        {
                            NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_attrib_list.Name + "@", "");
                        }
                        

                        objTextWriter.WriteLine(NodeXML);

                        if (doClasses)
                        {
                            EdgeXML = objXMLTemplateWork.UML_Edge;
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_id.Name + "@",
                                                      oItem_Object.GUID + oItem_Object.GUID_Parent);
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_id_left.Name + "@",
                                                      oItem_Object.GUID_Parent);
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_id_right.Name + "@",
                                                      oItem_Object.GUID);
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_name_relationtype.Name + "@",
                                                      HttpUtility.HtmlEncode("Instance"));

                            objTextWriter.WriteLine(EdgeXML);
                        }
                        
                    }
                }


                if (doRelationTypes)
                {
                    var objRelNodes = (from objRelType in OList_RelationTypes
                                       join objORel in OList_ORels on objRelType.GUID equals objORel.ID_Other
                                       select objRelType).ToList();

                    foreach (var oItem_Rel in objRelNodes)
                    {
                        NodeXML = objXMLTemplateWork.UML_ClassNode;
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_id.Name + "@", oItem_Rel.GUID);
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_name_node.Name + "@", HttpUtility.HtmlEncode(oItem_Rel.Name));
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_color_fill.Name + "@", "#ffcc00");
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_color_text.Name + "@", "#000000");
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_attrib_list.Name + "@", "");
                        objTextWriter.WriteLine(NodeXML);
                    }
                }

                if (doAttributeTypes)
                {
                    var objAttNodes = (from objAttType in OList_AttributeTypes
                                       join objORel in OList_ORels on objAttType.GUID equals objORel.ID_Other
                                       select objAttType).ToList();

                    foreach (var oItem_Rel in objAttNodes)
                    {
                        NodeXML = objXMLTemplateWork.UML_ClassNode;
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_id.Name + "@", oItem_Rel.GUID);
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_name_node.Name + "@", HttpUtility.HtmlEncode(oItem_Rel.Name));
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_color_fill.Name + "@", "#ffcc00");
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_color_text.Name + "@", "#000000");
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_attrib_list.Name + "@", "");
                        objTextWriter.WriteLine(NodeXML);
                    }
                }


                if (doClasses && doObjRel)
                {
                    var objClassNodes = (from objClass in OList_Classes
                                         join objORel in OList_ORels on objClass.GUID equals objORel.ID_Other
                                         select objClass).ToList();

                    foreach (var oItem_Rel in objClassNodes)
                    {
                        NodeXML = objXMLTemplateWork.UML_ClassNode;
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_id.Name + "@", oItem_Rel.GUID);
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_name_node.Name + "@", HttpUtility.HtmlEncode(oItem_Rel.Name));
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_color_fill.Name + "@", "#ffcc00");
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_color_text.Name + "@", "#000000");
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_attrib_list.Name + "@", "");
                        objTextWriter.WriteLine(NodeXML);
                    }
                }

                if (doObjRel)
                {
                    foreach (var oItem_ORel in OList_ORels)
                    {
                        EdgeXML = objXMLTemplateWork.UML_Edge;
                        EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_id.Name + "@",
                                                  oItem_ORel.ID_Object + oItem_ORel.ID_Other +
                                                  oItem_ORel.ID_RelationType);
                        EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_id_left.Name + "@",
                                                  oItem_ORel.ID_Object);
                        EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_id_right.Name + "@",
                                                  oItem_ORel.ID_Other);
                        EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_name_relationtype.Name + "@",
                                                  HttpUtility.HtmlEncode(oItem_ORel.Name_RelationType));

                        objTextWriter.WriteLine(EdgeXML);
                    }
                }
                





                objTextWriter.WriteLine(objXMLTemplateWork.UML_Container.Substring(objXMLTemplateWork.UML_Container.IndexOf("@" + objLocalConfig.OItem_object_edge_list.Name + "@") + ("@" + objLocalConfig.OItem_object_edge_list.Name + "@").Length));
                objTextWriter.Close();

                //if (File.Exists(path))
                //{
                //    if (
                //        !objShellWork.start_Process(path, "", path.Substring(0, path.Length - Path.GetFileName(path).Length),
                //                                    false, false))
                //    {
                //        objOItem_Result = objLocalConfig.Globals.LState_Error;
                //    }

                //}

                return objLocalConfig.Globals.LState_Success.Clone();
            }
            catch (Exception e)
            {
                return objLocalConfig.Globals.LState_Error.Clone();
            }
            
        }
        private void set_DBConnection()
        {
            objDBLevel1 = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel2 = new clsDBLevel(objLocalConfig.Globals);
        }

        public clsOntologyItem ExportClasses(bool doClasses, bool doObjects, bool doClassRel, bool doObjectRels, string Path)
        {
            clsOntologyItem objOItem_Result;
            TextWriter objTextWriter = new StreamWriter("test.graphml");
            string NodeXML;
            string EdgeXML;

            objOItem_Result = objDBLevel1.get_Data_ClassRel(boolIDs:false,OList_ClassRel:null);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = objDBLevel2.get_Data_Classes();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objTextWriter.WriteLine(objXMLTemplateWork.UML_Container.Substring(0,objXMLTemplateWork.UML_Container.IndexOf("@" + objLocalConfig.OItem_object_node_list.Name + "@")-1));
                    foreach (var objClass in objDBLevel2.OList_Classes)
                    {
                        NodeXML = objXMLTemplateWork.UML_ClassNode;
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_id.Name + "@", objClass.GUID);
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_name_node.Name + "@", HttpUtility.HtmlEncode(objClass.Name));
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_attrib_list.Name + "@", "");
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_color_fill.Name + "@", "#00ff00");
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_color_text.Name + "@", "#ffffff");
                        objTextWriter.WriteLine(NodeXML);

                    }

                    if (doClassRel)
                    {
                        foreach (var objClassRel in objDBLevel1.OList_ClassRel)
                        {
                            EdgeXML = objXMLTemplateWork.UML_Edge;
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_id.Name + "@",
                                                      objClassRel.ID_Class_Left + objClassRel.ID_Class_Right +
                                                      objClassRel.ID_RelationType);
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_id_left.Name + "@",
                                                      objClassRel.ID_Class_Left);
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_id_right.Name + "@",
                                                      objClassRel.ID_Class_Right);
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_name_relationtype.Name + "@",
                                                      HttpUtility.HtmlEncode(objClassRel.Name_RelationType));

                            objTextWriter.WriteLine(EdgeXML);
                        }    
                    }
                    
                }

                if (doObjects)
                {
                    objOItem_Result = objDBLevel2.get_Data_Objects();
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        foreach (var objObject in objDBLevel2.OList_Objects)
                        {
                            NodeXML = objXMLTemplateWork.UML_ClassNode;
                            NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_id.Name + "@", objObject.GUID);
                            NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_name_node.Name + "@", HttpUtility.HtmlEncode(objObject.Name));
                            NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_attrib_list.Name + "@", "");
                            NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_color_fill.Name + "@", "#ffcc00");
                            NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_object_color_text.Name + "@", "#000000");
                            objTextWriter.WriteLine(NodeXML);

                        }
                    }
                    
                   

                    
                }


                if (doObjectRels)
                {
                    objOItem_Result = objDBLevel1.get_Data_ObjectRel(null,false,false);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        foreach (var objObjRel in objDBLevel1.OList_ObjectRel)
                        {
                            EdgeXML = objXMLTemplateWork.UML_Edge;
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_id.Name + "@",
                                                      objObjRel.ID_Object + objObjRel.ID_Other +
                                                      objObjRel.ID_RelationType);
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_id_left.Name + "@",
                                                      objObjRel.ID_Object);
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_id_right.Name + "@",
                                                      objObjRel.ID_Other);
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_object_name_relationtype.Name + "@",
                                                      objObjRel.Name_RelationType);

                            objTextWriter.WriteLine(EdgeXML);
                        }    
                    }
                }
                
            }
            objTextWriter.WriteLine(objXMLTemplateWork.UML_Container.Substring(objXMLTemplateWork.UML_Container.IndexOf("@" + objLocalConfig.OItem_object_edge_list.Name + "@") + ("@" + objLocalConfig.OItem_object_edge_list.Name + "@").Length));
            objTextWriter.Close();
            return objOItem_Result;
        }

        private void initialize()
        {
            objXMLTemplateWork = new clsXMLTemplateWork(objLocalConfig);
            OList_AttributeTypes = new List<clsOntologyItem>();
            OList_ClassAtt = new List<clsClassAtt>();
            OList_ClassRel = new List<clsClassRel>();
            OList_ExportItems = new List<clsOntologyItem>();
            OList_OAtts = new List<clsObjectAtt>();
            OList_ORels = new List<clsObjectRel>();
            OList_EModes = new List<clsExportModes>();
            OList_Classes = new List<clsOntologyItem>();
            OList_EModes = new List<clsExportModes>();
            OList_Objects = new List<clsOntologyItem>();
            OList_RelationTypes = new List<clsOntologyItem>();
        }

    }
}
