using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses;
using System.IO;
using System.Web;

namespace RDF_Module
{
    public class clsRDFExport
    {

        public clsOntologyItem OItem_Ontology { get; private set; }

        private clsDataWork_Ontologies objDataWork_Ontologies;

        private clsDataWork_RDFModule objDataWork_RDFModule;

        private clsLocalConfig objLocalConfig;

        private TextWriter textWriter;

        private clsExport objExport;

        private clsDataTypes objDataTypes = new clsDataTypes();

        public clsOntologyItem ExportOntology(clsOntologyItem OItem_Ontology, string path)
        {
            this.OItem_Ontology = OItem_Ontology;
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            objOItem_Result = objExport.Generate_OntologyItems(OItem_Ontology, Ontology_Module.ModeEnum.AllRelations | Ontology_Module.ModeEnum.ClassParents | Ontology_Module.ModeEnum.OntologyStructures);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {

                var strContainer = objDataWork_RDFModule.OAItem_rdf_container_doc.Val_Named;

                strContainer = strContainer.Replace("@" + objLocalConfig.OItem_token_variable_url_ontology.Name + "@", objDataWork_RDFModule.OItem_Url.Name);
                strContainer = strContainer.Replace("@" + objLocalConfig.OItem_token_variable_name_ontology.Name + "@", "o_" + OItem_Ontology.GUID);

                try
                {
                    textWriter = new StreamWriter(path, false, Encoding.Unicode);

                    textWriter.WriteLine(strContainer.Substring(0, strContainer.IndexOf("@" + objLocalConfig.OItem_token_variable_list_annotationproperties.Name + "@")));

                    objExport.OList_AttributeTypes.ForEach(at => textWriter.WriteLine(GetRdfAttributeType(at)));
                    objExport.OList_RelationTypes.ForEach(rt => textWriter.WriteLine(GetRdfRelationType(rt)));
                    objExport.OList_Classes.ForEach(cl => WriteRdfClass(cl));
                    objExport.OList_Objects.ForEach(o => WriteRdfObjects(o));

                    textWriter.WriteLine(strContainer.Substring(strContainer.IndexOf("@" + objLocalConfig.OItem_token_variable_list_individuals.Name + "@") + ("@" + objLocalConfig.OItem_token_variable_list_individuals.Name + "@").Length));
                    textWriter.Close();
                }
                catch (Exception ex)
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                    objOItem_Result.Additional1 = ex.Message;
                }
            }
            
            
          

            return objOItem_Result;
        }

        private string GetRdfAttributeType(clsOntologyItem OItem_AttributeType)
        {
            var rdfResult = "";

            rdfResult = objDataWork_RDFModule.OAItem_rdf_attribute.Val_Named;

            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_guid_attribute.Name + "@", "at_" + OItem_AttributeType.GUID);
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_name_attribute.Name + "@", HttpUtility.HtmlEncode(OItem_AttributeType.Name));

            var dataType = objDataTypes.DataTypes.Where(dt => dt.GUID == OItem_AttributeType.GUID_Parent).ToList().First();
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_name_datatype.Name + "@", dataType.Name);

            return rdfResult;
        }

        private string GetRdfRelationType(clsOntologyItem OItem_RelationType)
        {
            var rdfResult = "";

            rdfResult = objDataWork_RDFModule.OAItem_rdf_relationtype.Val_Named;

            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_guid_relationtype.Name + "@", "rel_" + OItem_RelationType.GUID);
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_name_relationtype.Name + "@", HttpUtility.HtmlEncode(OItem_RelationType.Name));

            return rdfResult;
        }

        private void WriteRdfClass(clsOntologyItem OItem_Class)
        {
            var rdfResult = "";

            rdfResult = objDataWork_RDFModule.OAItem_rdf_class.Val_Named;

            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_guid_type.Name + "@", "cl_" + OItem_Class.GUID);
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_name_type.Name + "@", HttpUtility.HtmlEncode( OItem_Class.Name));

            rdfResult = rdfResult.Substring(0, rdfResult.IndexOf("@" + objLocalConfig.OItem_token_variable_list_type_relations.Name + "@"));

            textWriter.WriteLine(rdfResult);
            objExport.OList_ClassRel.Where(clr => clr.ID_Class_Left == OItem_Class.GUID).ToList().ForEach(clr => textWriter.WriteLine(GetRdfClassRel(clr)));

            rdfResult = objDataWork_RDFModule.OAItem_rdf_class.Val_Named;

            rdfResult = rdfResult.Substring(rdfResult.IndexOf("@" + objLocalConfig.OItem_token_variable_list_type_relations.Name + "@") + ("@" + objLocalConfig.OItem_token_variable_list_type_relations.Name + "@").Length);

            textWriter.WriteLine(rdfResult);


        }

        private clsOntologyItem WriteRdfObjects(clsOntologyItem OItem_Object)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            var rdfResult = objDataWork_RDFModule.OAItem_rdf_object.Val_Named;

            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_guid_token.Name + "@", "o_" + OItem_Object.GUID);
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_name_token.Name + "@", HttpUtility.HtmlEncode(OItem_Object.Name));
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_guid_type.Name + "@", "cl_" + OItem_Object.GUID_Parent);

            textWriter.WriteLine(rdfResult.Substring(0,rdfResult.IndexOf("@" + objLocalConfig.OItem_token_variable_list_token_attribute.Name + "@")));

            var oList_OAtt = objExport.OList_ObjectAtt.Where(oa => oa.ID_Object == OItem_Object.GUID).ToList();

            foreach (var oAtt in oList_OAtt)
            {
                objOItem_Result = WriteRdfObjectAttribute(oAtt);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                {
                    break;
                }
            }

            var oList_ORel = objExport.OList_ObjectRel.Where(or => or.ID_Object == OItem_Object.GUID).ToList();

            foreach (var oRel in oList_ORel)
	        {
		        objOItem_Result = WriteRdfObjectRel(oRel);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                {
                    break;
                }
	        }

            textWriter.WriteLine(rdfResult.Substring(rdfResult.IndexOf("@" + objLocalConfig.OItem_token_variable_list_token_token.Name + "@") + ("@" + objLocalConfig.OItem_token_variable_list_token_token.Name + "@").Length));

            return objOItem_Result;
        }

        private clsOntologyItem WriteRdfObjectRel(clsObjectRel OItem_Orel)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            var rdfResult = objDataWork_RDFModule.OAItem_rdf_object_to_object.Val_Named;

            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_name_ontology.Name + "@", "o_" + OItem_Ontology.GUID);
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_guid_relationtype.Name + "@", "rel_" + OItem_Orel.ID_RelationType);
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_guid_token.Name + "@", OItem_Orel.ID_Other);

            textWriter.WriteLine(rdfResult);

            return objOItem_Result;
        }

        private clsOntologyItem WriteRdfObjectAttribute(clsObjectAtt OItem_OAtt)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            var rdfResult = objDataWork_RDFModule.OAItem_rdf_object_attribute.Val_Named;

            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_name_ontology.Name + "@", "o_" + OItem_Ontology.GUID);
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_guid_attribute.Name + "@", "at_" + OItem_OAtt.ID_AttributeType);
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_val_attribute.Name + "@", HttpUtility.HtmlEncode(OItem_OAtt.Val_Named));

            textWriter.WriteLine(rdfResult);

            return objOItem_Result;
        }

        private string GetRdfClassRel(clsClassRel OItem_ClassRel)
        {
            var rdfResult = "";

            rdfResult = objDataWork_RDFModule.OAItem_rdf_class_to_class.Val_Named;

            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_guid_relationtype.Name + "@", "rel_" + OItem_ClassRel.ID_RelationType);
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_guid_type_right.Name + "@", "cl_" + OItem_ClassRel.ID_Class_Right);
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_min.Name + "@", OItem_ClassRel.Min_Forw.ToString());
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_max.Name + "@", OItem_ClassRel.Max_Forw.ToString());

            return rdfResult;
        }

        public clsRDFExport(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            objDataWork_RDFModule = new clsDataWork_RDFModule(objLocalConfig);
            Initialize();
        }

        private void Initialize()
        {
            objDataWork_Ontologies = new clsDataWork_Ontologies(objLocalConfig.Globals);
            objExport = new clsExport(objLocalConfig.Globals);
            var objOItem_Result = objDataWork_RDFModule.GetData_Base();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = objDataWork_RDFModule.GetData_XML();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                {
                    throw new Exception("Config-Error");
                }
            }
            else
            {
                throw new Exception("Config-Error");
            }
        }
    }
}
