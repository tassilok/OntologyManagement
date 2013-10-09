using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontolog_Module;

namespace Version_Module
{
    public partial class frmVersionModule : Form
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_Versions objDataWorkVersions;

        private UserControl_RefTree objUserControl_RefTree;
        private UserControl_VersionDetails objUserControl_Versions;

        private bool boolOpen;

        public frmVersionModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            initialize();
        }

        private void initialize()
        {
            boolOpen = true;
            
            objDataWorkVersions = new clsDataWork_Versions(objLocalConfig);
            objDataWorkVersions.GetData_RefTreeData(false);
            objDataWorkVersions.GetData_VersionDetails(false);
            if (objDataWorkVersions.OItem_Result_Versions.GUID == objLocalConfig.Globals.LState_Success.GUID &&
                objDataWorkVersions.OItem_Result_Versions_To_Refs.GUID == objLocalConfig.Globals.LState_Success.GUID &&
                objDataWorkVersions.OItem_Result_Versions__VersionNumbers.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objUserControl_RefTree = new UserControl_RefTree(objDataWorkVersions) {Dock = DockStyle.Fill};
                objUserControl_Versions = new UserControl_VersionDetails(objDataWorkVersions) {Dock = DockStyle.Fill};

                objUserControl_RefTree.selectedNode += objUserControl_RefTree_selectedNode;
                splitContainer1.Panel1.Controls.Add(objUserControl_RefTree);
                splitContainer1.Panel2.Controls.Add(objUserControl_Versions);
            }
            else
            {
                boolOpen = false;
            }


            
        }

        void objUserControl_RefTree_selectedNode(OntologyClasses.BaseClasses.clsOntologyItem OItem_SelectedNode)
        {
            objUserControl_Versions.initialize_Grid(OItem_SelectedNode);
        }

        private void frmVersionModule_Load(object sender, EventArgs e)
        {
            if (!boolOpen)
            {
                MessageBox.Show(this, "Die notwendigen Daten konnten nicht ermittelt werden!", "Fehler!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
                
        }
    }
}
