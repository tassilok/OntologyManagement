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
        private clsRDFExport objRDFExport;

        private frmOntologyConfigurator objFrmOntologyConfigurator;


        public Form_RDFModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {

            objRDFExport = new clsRDFExport(objLocalConfig);


            
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

                    var objOItem_Result = objRDFExport.ExportOntology(objOItem_Ontology, path);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        MessageBox.Show(this, "The Ontology is saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "The Ontology could not be saved!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }

            

        }

        

        
    }
}
