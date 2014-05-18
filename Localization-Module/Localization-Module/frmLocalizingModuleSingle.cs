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

namespace Localization_Module
{
    public partial class frmLocalizingModuleSingle : Form
    {
        private clsLocalConfig objLocalConfig;

        private clsOntologyItem objOItem_Ref;

        private UserControl_LocalizationDetails objUserControl_LocalizationDetails;

        public frmLocalizingModuleSingle(clsLocalConfig LocalConfig, clsOntologyItem OItem_Ref)
        {
            InitializeComponent();

            objOItem_Ref = OItem_Ref;
            objLocalConfig = LocalConfig;
            Initialize();
        }

        public frmLocalizingModuleSingle(clsGlobals Globals, clsOntologyItem OItem_Ref)
        {
            InitializeComponent();

            objOItem_Ref = OItem_Ref;
            objLocalConfig = new clsLocalConfig(Globals);
            Initialize();
        }

        private void Initialize()
        {
            if (objOItem_Ref != null)
            {
                this.Text = objOItem_Ref.Type + ": " + objOItem_Ref.Name;
            }
            objUserControl_LocalizationDetails = new UserControl_LocalizationDetails(objLocalConfig);
            objUserControl_LocalizationDetails.Dock = DockStyle.Fill;
            toolStripContainer1.ContentPanel.Controls.Add(objUserControl_LocalizationDetails);
            objUserControl_LocalizationDetails.initialize_Tree(objOItem_Ref, objLocalConfig.OItem_StandardLanguage, objLocalConfig.OList_Languages, true);
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
