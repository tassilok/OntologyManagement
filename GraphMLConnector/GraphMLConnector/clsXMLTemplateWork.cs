using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using System.Xml;
using OntologyClasses.BaseClasses;

namespace GraphMLConnector
{
    class clsXMLTemplateWork
    {
        private clsLocalConfig objLocalConfig;
        private clsDBLevel objDBLevel;

        public string UML_Container { get; set; }
        public string UML_ClassNode { get; set; }
        public string UML_Edge { get; set; }

        public clsXMLTemplateWork(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            set_DBConnection();
            initialize();

        }

        private void initialize()
        {
            UML_Container = GetXMLContent(objLocalConfig.OItem_object_graphml___container);
            UML_Edge = GetXMLContent(objLocalConfig.OItem_object_graphml___uml_edge);
            UML_ClassNode = GetXMLContent(objLocalConfig.OItem_object_graphml___uml_class_node);
        }

        private string GetXMLContent(clsOntologyItem OItem_XMLItem)
        {
            clsOntologyItem objOItem_Result;
            List<clsObjectAtt> OList_XMLAtt = new List<clsObjectAtt>();
            XmlDocument objXMLDoc = new XmlDocument();
            XmlNodeList objXMLData;
            string Result;

            OList_XMLAtt.Add(new clsObjectAtt(null,
                                              OItem_XMLItem.GUID,
                                              null,
                                              objLocalConfig.OItem_attributetype_xml_text.GUID,
                                              null));


            objOItem_Result = objDBLevel.get_Data_ObjectAtt(OList_XMLAtt,
                                                            boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel.OList_ObjectAtt.Any())
                {
                    Result = objDBLevel.OList_ObjectAtt.First().Val_String;
                    try
                    {
                        objXMLDoc.LoadXml(Result);
                        objXMLData = objXMLDoc.GetElementsByTagName("data");
                        if (objXMLData.Count > 0)
                        {
                            Result = objXMLData[0].InnerText;
                        }
                        else
                        {
                            Result = null;
                        }
                    }
                    catch (Exception)
                    {
                        Result = null;
                    }
                }
                else
                {
                    Result = null;
                }
            }
            else
            {
                Result = null;
            }

            return Result;
        }

        private void set_DBConnection()
        {
            objDBLevel = new clsDBLevel(objLocalConfig.Globals);
        }

    }
}
