using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using System.Xml;

namespace RDF_Module
{
    public class clsDataWork_RDFModule
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_XMLText;
        private clsDBLevel objDBLevel_Url;

        public clsObjectAtt OAItem_rdf_attribute { get; set; }
        public clsObjectAtt OAItem_rdf_class { get; set; }
        public clsObjectAtt OAItem_rdf_container_doc { get; set; }
        public clsObjectAtt OAItem_rdf_relationtype { get; set; }
        public clsObjectAtt OAItem_rdf_object { get; set; }
        public clsObjectAtt OAItem_rdf_class_to_class { get; set; }
        public clsObjectAtt OAItem_rdf_object_attribute { get; set; }
        public clsObjectAtt OAItem_rdf_object_to_object { get; set; }

        public clsOntologyItem OItem_Url { get; set; }

        public clsOntologyItem GetData_Base()
        {
            var oItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objORel_Url = new List<clsObjectRel> { new clsObjectRel {ID_Object = objLocalConfig.OItem_object_base_config.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_ontologies_located_at.GUID,
                ID_Parent_Other = objLocalConfig.OItem_type_url.GUID } };

            oItem_Result = objDBLevel_Url.get_Data_ObjectRel(objORel_Url, boolIDs: false);

            if (oItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Url.OList_ObjectRel.Any())
                {
                    OItem_Url = objDBLevel_Url.OList_ObjectRel.Select(u => new clsOntologyItem
                    {
                        GUID = u.ID_Other,
                        Name = u.Name_Other,
                        GUID_Parent = u.ID_Parent_Other,
                        Type = u.Ontology
                    }).First();
                }
                else
                {
                    oItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                }
            }

            return oItem_Result;
        }

        public clsOntologyItem GetData_XML()
        {
            var oItem_Result = objLocalConfig.Globals.LState_Success.Clone();


            OAItem_rdf_attribute  = GetXMLOfTemplate(objLocalConfig.OItem_token_xml_rdf__attribute);
            if (OAItem_rdf_attribute != null)
            {
                OAItem_rdf_class = GetXMLOfTemplate(objLocalConfig.OItem_token_xml_rdf__attribute);
            }
            else
            {
                oItem_Result = objLocalConfig.Globals.LState_Error.Clone();
            }

            if (OAItem_rdf_class != null)
            {
                OAItem_rdf_container_doc = GetXMLOfTemplate(objLocalConfig.OItem_token_xml_rdf__container_doc);
            }
            else
            {
                oItem_Result = objLocalConfig.Globals.LState_Error.Clone();
            }

            if (OAItem_rdf_container_doc != null)
            {
                OAItem_rdf_relationtype = GetXMLOfTemplate(objLocalConfig.OItem_token_xml_rdf__relationtype);
            }
            else
            {
                oItem_Result = objLocalConfig.Globals.LState_Error.Clone();
            }

            if (OAItem_rdf_relationtype != null)
            {
                OAItem_rdf_object = GetXMLOfTemplate(objLocalConfig.OItem_token_xml_rdf__token);
            }
            else
            {
                oItem_Result = objLocalConfig.Globals.LState_Error.Clone();
            }

            if (OAItem_rdf_object != null)
            {
                OAItem_rdf_class = GetXMLOfTemplate(objLocalConfig.OItem_token_xml_rdf__class);
            }

            if (OAItem_rdf_class != null)
            {
                OAItem_rdf_object_attribute = GetXMLOfTemplate(objLocalConfig.OItem_token_xml_rdf__token_attribute);
            }

            if (OAItem_rdf_object_attribute != null)
            {
                OAItem_rdf_class_to_class = GetXMLOfTemplate(objLocalConfig.OItem_token_xml_rdf__type_type);
            }

            if (OAItem_rdf_class_to_class != null)
            {
                OAItem_rdf_object_to_object = GetXMLOfTemplate(objLocalConfig.OItem_token_xml_rdf__token_token);
            }

            if (OAItem_rdf_object_to_object == null)
            {
                oItem_Result = objLocalConfig.Globals.LState_Error.Clone();
            }


            return oItem_Result;
        }

        private clsObjectAtt GetXMLOfTemplate(clsOntologyItem OItem_Template)
        {
            var oItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objORel_TemplateToXML_Text = new List<clsObjectAtt> { new clsObjectAtt { ID_Object = OItem_Template.GUID,
                ID_AttributeType = objLocalConfig.OItem_attribute_xml_text.GUID } };

            oItem_Result = objDBLevel_XMLText.get_Data_ObjectAtt(objORel_TemplateToXML_Text, boolIDs: true);

            if (oItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_XMLText.OList_ObjectAtt_ID.Any())
                {
                    var objOAItem = objDBLevel_XMLText.OList_ObjectAtt_ID.Select(oa => new clsObjectAtt
                    {
                        ID_Attribute = oa.ID_Attribute,
                        ID_AttributeType = oa.ID_AttributeType,
                        ID_Object = oa.ID_Object,
                        ID_Class = oa.ID_Class,
                        ID_DataType = oa.ID_DataType,
                        OrderID = oa.OrderID,
                        Val_Named = oa.Val_Named,
                        Val_String = oa.Val_String
                    }).First();

                    var objXML = new XmlDocument();
                    objXML.LoadXml(objDBLevel_XMLText.OList_ObjectAtt_ID.First().Val_String);
                    var objXMLElements = objXML.GetElementsByTagName("data");
                    if (objXMLElements.Count == 1)
                    {
                        var objXMLElement = objXMLElements[0];
                        objOAItem.Val_Named = objXMLElement.InnerText;
                        objOAItem.Val_Named = objOAItem.Val_Named.Replace("@" + objLocalConfig.OItem_token_variable_url_ontology.Name + "@", OItem_Url.Name);
                        return objOAItem;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
                
            }

            return null;
        }

        public clsDataWork_RDFModule(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_XMLText = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Url = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
