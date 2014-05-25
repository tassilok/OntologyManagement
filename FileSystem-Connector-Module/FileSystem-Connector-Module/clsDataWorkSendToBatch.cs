using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Xml;

namespace FileSystem_Connector_Module
{
    public class clsDataWorkSendToBatch
    {
        public clsLocalConfig objLocalConfig;

        public clsDBLevel objDBLevel_XMLTemplate_To_XMLText;

        public string BatchString { get; private set; }


        public clsOntologyItem GetData_XMLTemplate_To_XMLText()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objORel_XMLTemplate_To_XMLText = new List<clsObjectAtt> { new clsObjectAtt {ID_Object = objLocalConfig.OItem_object_sendto_batch.GUID,
                ID_AttributeType = objLocalConfig.OItem_attributetype_xml_text.GUID } };

            objOItem_Result = objDBLevel_XMLTemplate_To_XMLText.get_Data_ObjectAtt(objORel_XMLTemplate_To_XMLText, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_XMLTemplate_To_XMLText.OList_ObjectAtt.Any())
                {
                    var strXML = objDBLevel_XMLTemplate_To_XMLText.OList_ObjectAtt.Select(xml => xml.Val_String).First();
                    var objXML = new XmlDocument();
                    objXML.LoadXml(strXML);

                    var objXMLElements = objXML.GetElementsByTagName("data");
                    if (objXMLElements.Count == 1)
                    {
                        var objXMLElement = objXMLElements[0];
                        BatchString = objXMLElement.InnerText;
                        objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
                    }
                    else
                    {
                        objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                    }
                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                }
            }

            return objOItem_Result;
        }

        public clsDataWorkSendToBatch(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_XMLTemplate_To_XMLText = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
