using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Xml;

namespace HTMLExport_Module
{
    public class clsXML
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_XMLText;

        public clsXML(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_XMLText = new clsDBLevel(objLocalConfig.Globals);
        }

        public clsObjectAtt get_XML(clsOntologyItem oItem_XML)
        {
            var objXML = new XmlDocument();
            clsObjectAtt objOAtt = null;

            var searchXMLText = new List<clsObjectAtt>
                {
                    new clsObjectAtt
                        {
                            ID_AttributeType = objLocalConfig.OItem_attribute_xml_text.GUID,
                            ID_Object = oItem_XML.GUID
                        }
                };

            var objOItem_Result = objDBLevel_XMLText.get_Data_ObjectAtt(searchXMLText, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOAtt = objDBLevel_XMLText.OList_ObjectAtt.FirstOrDefault();
                if (objOAtt != null)
                {
                    objXML.LoadXml(objOAtt.Val_String);
                    var objXMLNodeList = objXML.GetElementsByTagName("data");
                    if (objXMLNodeList.Count > 0)
                    {
                        objOAtt.Val_String = objXMLNodeList[0].InnerText;
                    }
                    else
                    {
                        objOAtt = null;
                    }
                }
            }

            return objOAtt;
        }

        
    }
}
