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

namespace RDF_Module
{
    public partial class Form_RDFModule : Form
    {

        private clsLocalConfig objLocalConfig;
        private clsDataWork_RDFModule objDataWork_RDFModule;

        public Form_RDFModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {
            objDataWork_RDFModule = new clsDataWork_RDFModule(objLocalConfig);

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
    }
}
