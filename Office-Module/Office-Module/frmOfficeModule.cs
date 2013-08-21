using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontolog_Module;

namespace Office_Module
{
    public partial class frmOfficeModule : Form
    {
        public bool Applyable { get; set; }

        private Office_Module.clsLocalConfig objLocalConfig;
        private clsDocumentation objDocumentation;
        
        //private UserControl_Documents objUserControl_Documents;
        //private UserControl_Bookmarks objUserControl_Bookmarks;

        private frmMain objFrmOntologyModule;

        private clsDataWork_Documents objDatawork_Documents;

        private TreeNode objTreeNode_Root;
        private TreeNode objTreeNode_Documents;
        private TreeNode objTreeNode_ContentItems;
        private TreeNode objTreeNode_RelationTypes;
        private TreeNode objTreeNode_Attributes;

        private bool boolPChange_Tree;

        public frmOfficeModule()
        {
            InitializeComponent();
            objLocalConfig = new Office_Module.clsLocalConfig();
            Initialize();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Initialize()
        {
            objDatawork_Documents = new clsDataWork_Documents(objLocalConfig);

            string[] strArguments;
            strArguments = Environment.GetCommandLineArgs();

            if (strArguments.Any())
            { 
            }

            //objUserControl_Bookmarks = new UserControl_Bookmarks(objLocalConfig);
            //objUserControl_Bookmarks.Dock = DockStyle.Fill;
            //splitContainer2.Panel2.Controls.Add(objUserControl_Bookmarks);
            //objUserControl_Documents = new UserControl_Documents(objLocalConfig);
            //objUserControl_Documents.Dock = DockStyle.Fill;
            //splitContainer2.Panel1.Controls.Add(objUserControl_Documents);

            fill_Tree();
        }

        private void fill_Tree()
        {
            boolPChange_Tree = true;
            treeView_Items.Nodes.Clear();

            objTreeNode_Root = treeView_Items.Nodes.Add(objLocalConfig.OItem_Token_Module_Office_Manager.GUID, objLocalConfig.OItem_Token_Module_Office_Manager.Name, objLocalConfig.ImageID_Root, objLocalConfig.ImageID_Root);
            objTreeNode_Documents = objTreeNode_Root.Nodes.Add(objLocalConfig.OItem_Type_Managed_Document.GUID, objLocalConfig.OItem_Type_Managed_Document.Name, objLocalConfig.ImageID_Root, objLocalConfig.ImageID_Root);
            objTreeNode_ContentItems = objTreeNode_Root.Nodes.Add(objLocalConfig.OItem_Type_ContentObject.GUID, objLocalConfig.OItem_Type_ContentObject.Name, objLocalConfig.ImageID_Root, objLocalConfig.ImageID_Root);

            objTreeNode_Attributes = objTreeNode_Documents.Nodes.Add(objLocalConfig.Globals.Type_AttributeType, objLocalConfig.Globals.Type_AttributeType, objLocalConfig.ImageID_Attributes, objLocalConfig.ImageID_Attributes);
            objTreeNode_RelationTypes = objTreeNode_Documents.Nodes.Add(objLocalConfig.Globals.Type_RelationType, objLocalConfig.Globals.Type_RelationType, objLocalConfig.ImageID_RelationTypes, objLocalConfig.ImageID_RelationTypes);

            objDatawork_Documents.GetData();
            while (objDatawork_Documents.isPresent_OItems().GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
            }

            if (objDatawork_Documents.isPresent_OItems().GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                

            }
            else
            {
                MessageBox.Show("Die Dokumente konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
