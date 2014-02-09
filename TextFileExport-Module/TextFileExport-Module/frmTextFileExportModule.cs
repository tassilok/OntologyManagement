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

namespace TextFileExport_Module
{
    public partial class frmTextFileExportModule : Form
    {

        private clsLocalConfig objLocalConfig;

        

        public frmTextFileExportModule()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(new clsGlobals());

            TestExport();
        }

        private void TestExport()
        {
            var objOItem_TextFileExport = new clsOntologyItem
            {
                GUID = "ac2932dd9b304891a7cac137420923ec",
                Name = "Processes",
                GUID_Parent = "eaa0d1cfd47e4e56b0e5c722a63a12b6",
                Type = objLocalConfig.Globals.Type_Object
            };
            var objTextExport = new clsTextExport(objLocalConfig,objOItem_TextFileExport);
            objTextExport.TestExport();
        }
    }
}
