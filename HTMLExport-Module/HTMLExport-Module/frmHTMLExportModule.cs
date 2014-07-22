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
using System.IO;

namespace HTMLExport_Module
{
    public partial class frmHTMLExportModule : Form
    {
        private clsLocalConfig objLocalConfig;
        private clsHTMLCreation objHTMLCreation;
        

        public frmHTMLExportModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {
            
            Test();
        }

        private void Test()
        {
            try
            {
                objHTMLCreation = new clsHTMLCreation(objLocalConfig);
                 
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Die Konfiguration konnte nicht geladen werden!", "Config-Fehler!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            var objOItem_Result = objHTMLCreation.Initialize_ExportFolder();
        }
    }
}
