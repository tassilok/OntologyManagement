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
using Security_Module;

namespace Version_Module
{
    public partial class frmVersionModule : Form
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_Versions objDataWorkVersions;

        //private UserControl_RefTree objUserControl_RefTree;
        private Ontology_Module.UserControl_RefTree objUserControl_RefTree;
        private UserControl_VersionDetails objUserControl_Versions;
        private frmAuthenticate objFrmAuthenticate;

        private clsArgumentParsing objArgumentParsing;

        private SplashScreen_OntologyModule SplashScreen;
        private AboutBox_OntologyItem AboutBox;


        private bool boolOpen;

        public frmVersionModule()
        {
            InitializeComponent();

            Application.DoEvents();
            SplashScreen = new SplashScreen_OntologyModule();
            SplashScreen.Show();
            SplashScreen.Refresh();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            initialize();
        }

        private clsOntologyItem ParseArguments()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Nothing.Clone();
            objArgumentParsing = new clsArgumentParsing(objLocalConfig.Globals, Environment.GetCommandLineArgs().ToList());
            if (objArgumentParsing.OList_Items.Any())
            {
                objUserControl_Versions.initialize_Grid(objArgumentParsing.OList_Items.First());
                objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            }

            return objOItem_Result;
        }

        private void initialize()
        {
            boolOpen = false;

            objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, false, frmAuthenticate.ERelateMode.NoRelate,true);
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
                    objUserControl_RefTree = new Ontology_Module.UserControl_RefTree(objLocalConfig.Globals);
                    objUserControl_RefTree.Dock = DockStyle.Fill;
                    var objOList_Rels = new List<clsOntologyItem> { objLocalConfig.OItem_type_developmentversion };
                    var objOList_Rels_LeftRight = new List<clsOntologyItem> { objLocalConfig.OItem_relationtype_belongsto };
                    var objOList_Rels_RightLeft = new List<clsOntologyItem> { objLocalConfig.OItem_relationtype_isinstate };

                    
                    objUserControl_Versions = new UserControl_VersionDetails(objDataWorkVersions) { Dock = DockStyle.Fill };
                    objUserControl_Versions.Dock = DockStyle.Fill;

                    objUserControl_RefTree.selected_Node += objUserControl_RefTree_selectedNode;
                    splitContainer1.Panel1.Controls.Add(objUserControl_RefTree);
                    splitContainer1.Panel2.Controls.Add(objUserControl_Versions);

                    var objOItem_Result = ParseArguments();
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
                    {
                        InitializeTree(objOList_Rels, objOList_Rels_LeftRight, objOList_Rels_RightLeft);
                    }
                    else
                    {
                        splitContainer1.Panel1Collapsed = true;
                    }
                    
                }
                else
                {
                    boolOpen = false;
                }
            }
            
        }

        private void InitializeTree(List<clsOntologyItem> Rels, List<clsOntologyItem> Rels_LeftRight, List<clsOntologyItem> Rels_RightLeft)
        {
            objUserControl_RefTree.initialize_Tree(Rels, Rels_LeftRight, Rels_RightLeft);
        }

        void objUserControl_RefTree_selectedNode(OntologyClasses.BaseClasses.clsOntologyItem OItem_SelectedNode)
        {
            objUserControl_Versions.initialize_Grid(OItem_SelectedNode);
        }

        private void frmVersionModule_Load(object sender, EventArgs e)
        {
            if (SplashScreen != null)
            {
                SplashScreen.Close();
            }
            if (!boolOpen)
            {
                MessageBox.Show(this, "Die notwendigen Daten konnten nicht ermittelt werden!", "Fehler!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
                
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox = new AboutBox_OntologyItem();
            AboutBox.ShowDialog(this);
        }
    }
}
