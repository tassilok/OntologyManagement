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

        private clsDBLevel objDBLevel1;
        private clsDBLevel objDBLevel2;

        public clsGraphMLWork(clsLocalConfig localConfig)
        {
            objLocalConfig = localConfig;

            set_DBConnection();
            initialize();
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
                            objTextWriter.WriteLine(NodeXML);

                        }
                    }
                    
                   

                    
                }


                if (doObjectRels)
                {
                    objOItem_Result = objDBLevel1.get_Data_ObjectRel(null);
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
        }

    }
}
