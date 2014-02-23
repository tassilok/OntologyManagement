using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using Security_Module;

namespace Scenes_Literatur_Module
{
    public partial class frmScenesLiteraturModule : Form
    {
        private clsLocalConfig objLocalConfig;

        private UserControl_SceneTree objUserControl_SceneTree;
        private UserControl_SceneDetail objUserControl_SceneDetail;

        private frmAuthenticate objFrmAuthenticate;

        private SplashScreen_OntologyModule SplashScreen;
        private AboutBox_OntologyItem AboutBox;

        public frmScenesLiteraturModule()
        {
            InitializeComponent();

            Application.DoEvents();
            SplashScreen = new SplashScreen_OntologyModule();
            SplashScreen.Show();
            SplashScreen.Refresh();

            objLocalConfig = new clsLocalConfig();
            initialize();
        }

        private void initialize()
        {
            if (objLocalConfig.OItem_User == null)
            {
                objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, false, frmAuthenticate.ERelateMode.NoRelate, true);
                objFrmAuthenticate.ShowDialog(this);
                if (objFrmAuthenticate.DialogResult == DialogResult.OK)
                {
                    objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User;
                }
            }

            if (objLocalConfig.OItem_User != null)
            {
                objLocalConfig.DataWork_Scenes = new clsDataWork_Scenes(objLocalConfig);
                objUserControl_SceneTree = new UserControl_SceneTree(objLocalConfig);
                objUserControl_SceneTree.Dock = DockStyle.Fill;
                splitContainer1.Panel1.Controls.Add(objUserControl_SceneTree);
                objUserControl_SceneTree.selectedNode += objUserControl_SceneTree_selectedNode;

                objUserControl_SceneDetail = new UserControl_SceneDetail(objLocalConfig);
                objUserControl_SceneDetail.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Add(objUserControl_SceneDetail);
            }
            else
            {
                Environment.Exit(0);
            }
            

        }

        void objUserControl_SceneTree_selectedNode(clsOntologyItem OItem_SelectedNode)
        {
            if (OItem_SelectedNode.GUID_Parent != objLocalConfig.OItem_type_szene.GUID)
            {
                OItem_SelectedNode = null;
            }

            objUserControl_SceneDetail.InitializeScene(OItem_SelectedNode);
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScenesLiteraturModule_Load(object sender, EventArgs e)
        {
            if (SplashScreen != null)
            {
                SplashScreen.Close();
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox = new AboutBox_OntologyItem();
            AboutBox.ShowDialog(this);
        }
    }
}
