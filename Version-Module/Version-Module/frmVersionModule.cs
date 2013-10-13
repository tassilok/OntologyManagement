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
using OntologyClasses.BaseClasses;
using Security_Module;

namespace Version_Module
{
    public partial class frmVersionModule : Form
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_Versions objDataWorkVersions;

        //private UserControl_RefTree objUserControl_RefTree;
        private Ontolog_Module.UserControl_RefTree objUserControl_RefTree;
        private UserControl_VersionDetails objUserControl_Versions;
        private frmAuthenticate objFrmAuthenticate;

        private bool boolOpen;

        public frmVersionModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            initialize();
        }

        private void initialize()
        {
            boolOpen = false;

            objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, false, frmAuthenticate.ERelateMode.NoRelate);
            objFrmAuthenticate.ShowDialog(this);
            if (objFrmAuthenticate.DialogResult == DialogResult.OK)
            {
                objLocalConfig.objUser = objFrmAuthenticate.OItem_User;
                boolOpen = true;

                objDataWorkVersions = new clsDataWork_Versions(objLocalConfig);
                objDataWorkVersions.GetData_RefTreeData(false);
                objDataWorkVersions.GetData_VersionDetails(false);
                if (objDataWorkVersions.OItem_Result_Versions.GUID == objLocalConfig.Globals.LState_Success.GUID &&
                    objDataWorkVersions.OItem_Result_Versions_To_Refs.GUID == objLocalConfig.Globals.LState_Success.GUID &&
                    objDataWorkVersions.OItem_Result_Versions__VersionNumbers.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    //objUserControl_RefTree = new UserControl_RefTree(objDataWorkVersions) {Dock = DockStyle.Fill};
                    objUserControl_RefTree = new Ontolog_Module.UserControl_RefTree(objLocalConfig.Globals);
                    objUserControl_RefTree.Dock = DockStyle.Fill;
                    var objOList_Rels = new List<clsOntologyItem> { objLocalConfig.OItem_type_developmentversion };
                    var objOList_Rels_LeftRight = new List<clsOntologyItem> { objLocalConfig.OItem_relationtype_belongsto };
                    var objOList_Rels_RightLeft = new List<clsOntologyItem> { objLocalConfig.OItem_relationtype_isinstate };

                    objUserControl_RefTree.initialize_Tree(objOList_Rels, objOList_Rels_LeftRight, objOList_Rels_RightLeft);
                    objUserControl_Versions = new UserControl_VersionDetails(objDataWorkVersions) { Dock = DockStyle.Fill };
                    objUserControl_Versions.Dock = DockStyle.Fill;

                    objUserControl_RefTree.selected_Node += objUserControl_RefTree_selectedNode;
                    splitContainer1.Panel1.Controls.Add(objUserControl_RefTree);
                    splitContainer1.Panel2.Controls.Add(objUserControl_Versions);
                }
                else
                {
                    boolOpen = false;
                }
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
