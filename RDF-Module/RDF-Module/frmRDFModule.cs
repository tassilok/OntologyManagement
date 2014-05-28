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
using System.IO;

namespace RDF_Module
{
    public partial class Form_RDFModule : Form
    {

        private clsLocalConfig objLocalConfig;
        private clsDataWork_RDFModule objDataWork_RDFModule;
        private clsExport objExport;

        private frmOntologyConfigurator objFrmOntologyConfigurator;

        private TextWriter textWriter;

        public Form_RDFModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {
            objDataWork_RDFModule = new clsDataWork_RDFModule(objLocalConfig);
            objExport = new clsExport(objLocalConfig.Globals);

            var oItem_Result = objDataWork_RDFModule.GetData_Base();
            if (oItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                oItem_Result = objDataWork_RDFModule.GetData_XML();

                
            }

            if (oItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                throw new Exception("Config-Error");
            }

            
        }


        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton_Export_Ontology_Click(object sender, EventArgs e)
        {
            if (saveFileDialog_Ontology.ShowDialog() == DialogResult.OK)
            {
                var path = saveFileDialog_Ontology.FileName;

                objFrmOntologyConfigurator = new frmOntologyConfigurator(objLocalConfig.Globals);
                objFrmOntologyConfigurator.Applyable = true;
                objFrmOntologyConfigurator.ShowDialog(this);
                if (objFrmOntologyConfigurator.DialogResult == DialogResult.OK)
                {
                    var objOItem_Ontology = objFrmOntologyConfigurator.OItem_Ontology;

                    var objOItem_Result = objExport.Generate_OntologyItems(objOItem_Ontology, Ontology_Module.ModeEnum.AllRelations | Ontology_Module.ModeEnum.ClassParents | Ontology_Module.ModeEnum.OntologyStructures);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        SaveOntology(path, objOItem_Ontology);
                    }
                    else
                    {
                        MessageBox.Show(this, "The Ontology could not be saved!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }

            

        }

        private void SaveOntology(string path, clsOntologyItem OItem_Ontology)
        {
            var strContainer = objDataWork_RDFModule.OAItem_rdf_container_doc.Val_Named;
            
            strContainer = strContainer.Replace("@" + objLocalConfig.OItem_token_variable_url_ontology.Name + "@", objDataWork_RDFModule.OItem_Url.Name);
            strContainer = strContainer.Replace("@" + objLocalConfig.OItem_token_variable_name_ontology.Name + "@", OItem_Ontology.GUID);

            textWriter = new StreamWriter(path, false, Encoding.Unicode);

            textWriter.WriteLine(strContainer.Substring(0,strContainer.IndexOf("@" + objLocalConfig.OItem_token_variable_list_annotationproperties.Name + "@")));

            objExport.OList_AttributeTypes.ForEach(at => textWriter.WriteLine(GetRdfAttributeType(at)));
            objExport.OList_RelationTypes.ForEach(rt => textWriter.WriteLine(GetRdfRelationType(rt)));
            objExport.OList_Classes.ForEach(cl => WriteRdfClass(cl));
            
            textWriter.Close();
        }

        private string GetRdfAttributeType(clsOntologyItem OItem_AttributeType)
        {
            var rdfResult = "";

            rdfResult = objDataWork_RDFModule.OAItem_rdf_attribute.Val_Named;

            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_guid_attribute.Name + "@", OItem_AttributeType.GUID);
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_name_attribute.Name + "@", OItem_AttributeType.Name);
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_name_datatype.Name + "@", OItem_AttributeType.Name_Parent);

            return rdfResult;
        }

        private string GetRdfRelationType(clsOntologyItem OItem_RelationType)
        {
            var rdfResult = "";

            rdfResult = objDataWork_RDFModule.OAItem_rdf_relationtype.Val_Named;

            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_guid_relationtype.Name + "@", OItem_RelationType.GUID);
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_name_relationtype.Name + "@", OItem_RelationType.Name);

            return rdfResult;
        }

        private void WriteRdfClass(clsOntologyItem OItem_Class)
        {
            var rdfResult = "";

            rdfResult = objDataWork_RDFModule.OAItem_rdf_class.Val_Named;

            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_guid_type.Name + "@", OItem_Class.GUID);
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_name_type.Name + "@", OItem_Class.Name);

            rdfResult = rdfResult.Substring(0, rdfResult.IndexOf("@" + objLocalConfig.OItem_token_variable_list_type_relations.Name + "@"));

            textWriter.WriteLine(rdfResult);
            objExport.OList_ClassRel.Where(clr => clr.ID_Class_Left == OItem_Class.GUID).ToList().ForEach(clr => textWriter.WriteLine(GetRdfClassRel(clr)));

            rdfResult = objDataWork_RDFModule.OAItem_rdf_class.Val_Named;

            rdfResult = rdfResult.Substring(rdfResult.IndexOf("@" + objLocalConfig.OItem_token_variable_list_type_relations.Name + "@") +  ("@" + objLocalConfig.OItem_token_variable_list_type_relations.Name + "@").Length);

            textWriter.WriteLine(rdfResult);

            
        }

        private string GetRdfClassRel(clsClassRel OItem_ClassRel)
        {
            var rdfResult = "";

            rdfResult = objDataWork_RDFModule.OAItem_rdf_class_to_class.Val_Named;

            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_guid_relationtype.Name + "@", OItem_ClassRel.ID_RelationType );
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_guid_type_right.Name + "@", OItem_ClassRel.ID_Class_Right);
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_min.Name + "@", OItem_ClassRel.Min_Forw.ToString());
            rdfResult = rdfResult.Replace("@" + objLocalConfig.OItem_token_variable_max.Name + "@", OItem_ClassRel.Max_Forw.ToString());

            return rdfResult;
        }
    }
}
