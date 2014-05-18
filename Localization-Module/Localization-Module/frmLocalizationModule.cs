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
    public partial class frmLocalizationModule : Form
    {
        private UserControl_LocalizationDetails objUserControl_LocalizationDetails;
        private clsLocalConfig objLocalConfig;

        private frmLocalizingModuleSingle objFrmLocalizingModuleSingle;
        private UserControl_RefTree objUserControl_RefTree;

        private SplashScreen_OntologyModule SplashScreen;
        private AboutBox_OntologyItem AboutBox;

        private clsArgumentParsing objArgumentParsing;

        private clsOntologyItem objOItem_Argument;

        public frmLocalizationModule()
        {
            InitializeComponent();

            Application.DoEvents();
            SplashScreen = new SplashScreen_OntologyModule();
            SplashScreen.Show();
            SplashScreen.Refresh();

            objLocalConfig = new clsLocalConfig(new clsGlobals());
            ParseArguments();
            initialize();
        }

        private void ParseArguments()
        {
            objArgumentParsing = new clsArgumentParsing(objLocalConfig.Globals, Environment.GetCommandLineArgs().ToList());
            if (objArgumentParsing.OList_Items != null && objArgumentParsing.OList_Items.Count == 1)
            {
                objOItem_Argument = objArgumentParsing.OList_Items.First();
            }
        }

        private void initialize()
        {
            objUserControl_RefTree = new UserControl_RefTree(objLocalConfig.Globals);
            objUserControl_RefTree.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(objUserControl_RefTree);

            

            var objOList_Classes = new List<clsOntologyItem> { objLocalConfig.OItem_type_localized_names, objLocalConfig.OItem_type_localizeddescription };
            var objOList_RelationTypes = new List<clsOntologyItem> { objLocalConfig.OItem_relationtype_alternative_for, objLocalConfig.OItem_relationtype_describes };

            objUserControl_RefTree.initialize_Tree(objOList_Classes, objOList_RelationTypes);
            objUserControl_RefTree.ItemsLoaded += objUserControl_RefTree_ItemsLoaded;
            objUserControl_RefTree.selected_Node += objUserControl_RefTree_selected_Node;
            objUserControl_LocalizationDetails = new UserControl_LocalizationDetails(objLocalConfig);
            objUserControl_LocalizationDetails.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(objUserControl_LocalizationDetails);

            if (objOItem_Argument != null)
            {
                objFrmLocalizingModuleSingle = new frmLocalizingModuleSingle(objLocalConfig, objOItem_Argument);
                objFrmLocalizingModuleSingle.ShowDialog(this);

            }
            
        }

        private void objUserControl_RefTree_selected_Node(clsOntologyItem OItem_Selected)
        {
            objUserControl_LocalizationDetails.initialize_Tree(OItem_Selected, boolLocalizedNames:true);
        }

        private void objUserControl_RefTree_ItemsLoaded()
        {
            objUserControl_LocalizationDetails.OList_LocalizationToRef = objUserControl_RefTree.OList_Rels;
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox = new AboutBox_OntologyItem();
            AboutBox.ShowDialog(this);
        }

        private void frmLocalizationModule_Load(object sender, EventArgs e)
        {
            if (SplashScreen != null)
            {
                SplashScreen.Close();
            }
        }


    }
}
