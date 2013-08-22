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
            clsOntologyItem objOItem_Result;
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
                objOItem_Result = objDatawork_Documents.GetData_OItems();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOItem_Result = objDatawork_Documents.GetData_Classes();
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        createTreeStrucuture(objTreeNode_Documents);
                        addObjects();
                    }
                    else
                    {
                        MessageBox.Show("Die Dokumente konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Die Dokumente konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Die Dokumente konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void addObjects()
        {
            TreeNode[] objTreeNodes;
            var objObjects = (from obj in objDatawork_Documents.OList_OItems
                              where obj.Type == objLocalConfig.Globals.Type_Object
                              orderby obj.GUID_Parent, obj.Name
                              select new clsOntologyItem
                              {
                                  GUID = obj.GUID,
                                  Name = obj.Name,
                                  GUID_Parent = obj.GUID_Parent
                              }).ToList();

            foreach (var objObject in objObjects)
            {
                objTreeNodes = objTreeNode_Documents.Nodes.Find(objObject.GUID_Parent, true);
                if (objTreeNodes.Any())
                {
                    objTreeNodes[0].Nodes.Add(objObject.GUID,
                                              objObject.Name,
                                              objLocalConfig.ImageID_Token,
                                              objLocalConfig.ImageID_Token);
                }
            }
        }

        private void createTreeStrucuture(TreeNode objTreeNode)
        {
            var objSubNodes = new List<clsOntologyItem>();
            TreeNode objSubTreeNode;
            if (objTreeNode.Name != objTreeNode_Documents.Name)
            {
                objSubNodes = (from obj in objDatawork_Documents.OList_Classes
                               where obj.GUID_Parent == objTreeNode.Name
                               orderby obj.Name
                               select new clsOntologyItem
                               {
                                   GUID = obj.GUID,
                                   Name = obj.Name,
                                   Type = obj.Type
                               }).ToList();
            }
            else
            {
                objSubNodes = (from obj in objDatawork_Documents.OList_Classes
                               where obj.GUID_Parent == null
                               orderby obj.Name
                               select new clsOntologyItem
                               {
                                   GUID = obj.GUID,
                                   Name = obj.Name,
                                   Type = obj.Type
                               }).ToList();
            }


            foreach (var objSubNode in objSubNodes)
            {
                
                objSubTreeNode = objTreeNode.Nodes.Add(objSubNode.GUID,
                                            objSubNode.Name,
                                            objLocalConfig.ImageID_Close,
                                            objLocalConfig.ImageID_Open);
                

                createTreeStrucuture(objSubTreeNode);
            }
        }
    }
}

