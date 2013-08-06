using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontolog_Module;
using System.IO;
using System.Web;

namespace GraphMLConnector
{
    class clsGraphMLWork
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

        public clsGraphMLWork(clsLocalConfig localConfig)
        {
            objLocalConfig = localConfig;

            set_DBConnection();
            initialize();
        }

        public clsOntologyItem GetItemLists()
        {
            OList_Classes = (from objClass in OList_ExportItems
                                where objClass.Type == objLocalConfig.Globals.Type_Class
                                select objClass).ToList();

            OList_AttributeTypes = (from objAttType in OList_ExportItems
                                       where objAttType.Type == objLocalConfig.Globals.Type_AttributeType
                                       select objAttType).ToList();

            OList_Objects = (from objObject in OList_ExportItems
                                       where objObject.Type == objLocalConfig.Globals.Type_Object
                                       select objObject).ToList();

            OList_RelationTypes = (from objRelType in OList_ExportItems
                                       where objRelType.Type == objLocalConfig.Globals.Type_RelationType
                                       select objRelType).ToList();


            var objOItem_Result = objDBLevel1.get_Data_Classes(null, false, false, null, false);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var oList_ClassesOfObjects = from objClass in objDBLevel1.OList_Classes
                                             join objObject in OList_Objects on objClass.GUID equals objObject.GUID_Parent
                                             join objClassExist in OList_Classes on objClass.GUID equals objClassExist.GUID into objClassesExists
                                             from objClassExist in objClassesExists.DefaultIfEmpty()
                                             where objClassExist == null
                                             select objClass;
                
                foreach (var oItem_Class in oList_ClassesOfObjects)
                {
                    OList_Classes.Add(oItem_Class);
                }

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
                                           select new clsClassRel() {ID_Class_Left = objClassRel.ID_Class_Left, 
                                                       ID_Class_Right = objClassRel.ID_Class_Right, 
                                                       ID_RelationType = objClassRel.ID_RelationType, 
                                                       Min_Forw = objClassRel.Min_Forw, 
                                                       Max_Forw = objClassRel.Max_Forw, 
                                                       Max_Backw = objClassRel.Max_Backw,
                                                       Name_Class_Left = objClass_Left.Name,
                                                       Name_Class_Right = objClass_Right.Name}).ToList();
                

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
                                              select new clsClassAtt(){ID_AttributeType = objAttType.GUID,
                                                          Name_AttributeType = objAttType.Name,
                                                          Name_DataType = objDataType.Name,
                                                          ID_Class = objClass.GUID,
                                                          ID_DataType = objDataType.GUID,
                                                          Min = objClassAtt.Min,
                                                          Max = objClassAtt.Max}).ToList();


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
                                                       select objOAtt).ToList();
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

            

            return objOItem_Result;

        }


        public clsOntologyItem ExportItems()
        {
            var objOItem_Result = new clsOntologyItem();
            string NodeXML;
            string EdgeXML;
            
            TextWriter objTextWriter = new StreamWriter("test.graphml");
            objTextWriter.WriteLine(objXMLTemplateWork.UML_Container.Substring(0, objXMLTemplateWork.UML_Container.IndexOf("@" + objLocalConfig.OItem_Object_NODE_LIST.Name + "@") - 1));

            foreach (var oItem_Class in OList_Classes)
            {
                NodeXML = objXMLTemplateWork.UML_ClassNode;
                NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_Object_ID.Name + "@", oItem_Class.GUID);
                NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_Object_NAME_NODE.Name + "@", HttpUtility.HtmlEncode(oItem_Class.Name));
               
                var ClassAtt = "";
                foreach (var oItem_ClassAtt in OList_ClassAtt)
                {
                    if (ClassAtt != "")
                    {
                        ClassAtt += "\n";
                    }
                    ClassAtt += HttpUtility.HtmlEncode(oItem_ClassAtt.Name_AttributeType + ": " + oItem_ClassAtt.Name_DataType);
                }
                NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_Object_ATTRIB_LIST.Name + "@", ClassAtt);

                objTextWriter.WriteLine(NodeXML);
            }

            foreach (var oItem_ClassRel in OList_ClassRel)
            {
                EdgeXML = objXMLTemplateWork.UML_Edge;
                EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_Object_ID.Name + "@",
                                          oItem_ClassRel.ID_Class_Left + oItem_ClassRel.ID_Class_Right +
                                          oItem_ClassRel.ID_RelationType);
                EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_Object_ID_LEFT.Name + "@",
                                          oItem_ClassRel.ID_Class_Left);
                EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_Object_ID_RIGHT.Name + "@",
                                          oItem_ClassRel.ID_Class_Right);
                EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_Object_NAME_RELATIONTYPE.Name + "@",
                                          HttpUtility.HtmlEncode(oItem_ClassRel.Name_RelationType));

                objTextWriter.WriteLine(EdgeXML);
            }

            objTextWriter.WriteLine(objXMLTemplateWork.UML_Container.Substring(objXMLTemplateWork.UML_Container.IndexOf("@" + objLocalConfig.OItem_Object_EDGE_LIST.Name + "@") + ("@" + objLocalConfig.OItem_Object_EDGE_LIST.Name + "@").Length));
            objTextWriter.Close();

            return objOItem_Result;
        }
        private void set_DBConnection()
        {
            objDBLevel1 = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel2 = new clsDBLevel(objLocalConfig.Globals);
        }

        public clsOntologyItem ExportClasses(bool doClasses, bool doObjects, bool doClassRel, bool doObjectRels)
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
                    objTextWriter.WriteLine(objXMLTemplateWork.UML_Container.Substring(0,objXMLTemplateWork.UML_Container.IndexOf("@" + objLocalConfig.OItem_Object_NODE_LIST.Name + "@")-1));
                    foreach (var objClass in objDBLevel2.OList_Classes)
                    {
                        NodeXML = objXMLTemplateWork.UML_ClassNode;
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_Object_ID.Name + "@", objClass.GUID);
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_Object_NAME_NODE.Name + "@", HttpUtility.HtmlEncode(objClass.Name));
                        NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_Object_ATTRIB_LIST.Name + "@", "");
                        objTextWriter.WriteLine(NodeXML);

                    }

                    if (doClassRel)
                    {
                        foreach (var objClassRel in objDBLevel1.OList_ClassRel)
                        {
                            EdgeXML = objXMLTemplateWork.UML_Edge;
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_Object_ID.Name + "@",
                                                      objClassRel.ID_Class_Left + objClassRel.ID_Class_Right +
                                                      objClassRel.ID_RelationType);
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_Object_ID_LEFT.Name + "@",
                                                      objClassRel.ID_Class_Left);
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_Object_ID_RIGHT.Name + "@",
                                                      objClassRel.ID_Class_Right);
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_Object_NAME_RELATIONTYPE.Name + "@",
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
                            NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_Object_ID.Name + "@", objObject.GUID);
                            NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_Object_NAME_NODE.Name + "@", HttpUtility.HtmlEncode(objObject.Name));
                            NodeXML = NodeXML.Replace("@" + objLocalConfig.OItem_Object_ATTRIB_LIST.Name + "@", "");
                            objTextWriter.WriteLine(NodeXML);

                        }
                    }
                    
                   

                    
                }


                if (doObjectRels)
                {
                    objOItem_Result = objDBLevel1.get_Data_ObjectRel(null,false,false);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        foreach (var objObjRel in objDBLevel1.OList_ObjectRel_ID)
                        {
                            EdgeXML = objXMLTemplateWork.UML_Edge;
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_Object_ID.Name + "@",
                                                      objObjRel.ID_Object + objObjRel.ID_Other +
                                                      objObjRel.ID_RelationType);
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_Object_ID_LEFT.Name + "@",
                                                      objObjRel.ID_Object);
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_Object_ID_RIGHT.Name + "@",
                                                      objObjRel.ID_Other);
                            EdgeXML = EdgeXML.Replace("@" + objLocalConfig.OItem_Object_NAME_RELATIONTYPE.Name + "@",
                                                      "");

                            objTextWriter.WriteLine(EdgeXML);
                        }    
                    }
                }
                
            }
            objTextWriter.WriteLine(objXMLTemplateWork.UML_Container.Substring(objXMLTemplateWork.UML_Container.IndexOf("@" + objLocalConfig.OItem_Object_EDGE_LIST.Name + "@") + ("@" + objLocalConfig.OItem_Object_EDGE_LIST.Name + "@").Length));
            objTextWriter.Close();
            return objOItem_Result;
        }

        private void initialize()
        {
            objXMLTemplateWork = new clsXMLTemplateWork(objLocalConfig);
            OList_ClassAtt = new List<clsClassAtt>();
            OList_ClassRel = new List<clsClassRel>();
            OList_ExportItems = new List<clsOntologyItem>();
            OList_OAtts = new List<clsObjectAtt>();
            OList_ORels = new List<clsObjectRel>();
            OList_EModes = new List<clsExportModes>();
        }

    }
}
