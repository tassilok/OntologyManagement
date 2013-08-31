using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scenes_Literatur_Module
{
    public partial class frmScenesLiteraturModule : Form
    {
        private clsLocalConfig objLocalConfig;

        private UserControl_SceneTree objUserControl_SceneTree;
        private UserControl_SceneDetail objUserControl_SceneDetail;

        public frmScenesLiteraturModule()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig();
            initialize();
        }

        private void initialize()
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

        void objUserControl_SceneTree_selectedNode(Ontolog_Module.clsOntologyItem OItem_SelectedNode)
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
    }
}
