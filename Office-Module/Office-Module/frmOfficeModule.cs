using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontolog_Module;
using OntologyClasses.BaseClasses;

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
        private UserControl_Documents objUserControl_Documents;


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
            objLocalConfig.DataWork_Documents = new clsDataWork_Documents(objLocalConfig);
            objUserControl_Documents = new UserControl_Documents(objLocalConfig);
            objUserControl_Documents.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(objUserControl_Documents);

            string[] strArguments;
            strArguments = Environment.GetCommandLineArgs();

            if (strArguments.Any())
            { 
            }

            
            fill_Tree();
        }

        private void fill_Tree()
        {
            clsOntologyItem objOItem_Result;
            boolPChange_Tree = true;
            treeView_Items.Nodes.Clear();

            boolPChange_Tree = true;

            objTreeNode_Root = treeView_Items.Nodes.Add(objLocalConfig.OItem_Token_Module_Office_Manager.GUID, objLocalConfig.OItem_Token_Module_Office_Manager.Name, objLocalConfig.ImageID_Root, objLocalConfig.ImageID_Root);
            objTreeNode_Documents = objTreeNode_Root.Nodes.Add(objLocalConfig.OItem_Type_Managed_Document.GUID, objLocalConfig.OItem_Type_Managed_Document.Name, objLocalConfig.ImageID_Root, objLocalConfig.ImageID_Root);
            objTreeNode_ContentItems = objTreeNode_Root.Nodes.Add(objLocalConfig.OItem_Type_ContentObject.GUID, objLocalConfig.OItem_Type_ContentObject.Name, objLocalConfig.ImageID_Root, objLocalConfig.ImageID_Root);

            objTreeNode_Attributes = objTreeNode_Documents.Nodes.Add(objLocalConfig.Globals.Type_AttributeType, objLocalConfig.Globals.Type_AttributeType, objLocalConfig.ImageID_Attributes, objLocalConfig.ImageID_Attributes);
            objTreeNode_RelationTypes = objTreeNode_Documents.Nodes.Add(objLocalConfig.Globals.Type_RelationType, objLocalConfig.Globals.Type_RelationType, objLocalConfig.ImageID_RelationTypes, objLocalConfig.ImageID_RelationTypes);

            objLocalConfig.DataWork_Documents.GetData();
            while (objLocalConfig.DataWork_Documents.isPresent_Documents().GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
            }

            if (objLocalConfig.DataWork_Documents.isPresent_Documents().GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = objLocalConfig.DataWork_Documents.GetData_Documents();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOItem_Result = objLocalConfig.DataWork_Documents.GetData_Classes();
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
            boolPChange_Tree = false;
        }

        private void addObjects()
        {
            TreeNode[] objTreeNodes;
            var objObjects = (from obj in objLocalConfig.DataWork_Documents.OList_Documents
                              where obj.Ontology_Ref == objLocalConfig.Globals.Type_Object
                              select new clsOntologyItem
                              {
                                  GUID = obj.ID_Ref,
                                  Name = obj.Name_Ref,
                                  GUID_Parent = obj.ID_Parent_Ref
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
                objSubNodes = (from obj in objLocalConfig.DataWork_Documents.OList_Classes
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
                objSubNodes = (from obj in objLocalConfig.DataWork_Documents.OList_Classes
                               where obj.GUID_Parent == null || obj.GUID_Parent == ""
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

        private void treeView_Items_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            if (boolPChange_Tree == false)
            {
                if (e.Node.ImageIndex == objLocalConfig.ImageID_Close ||
                    e.Node.ImageIndex == objLocalConfig.ImageID_Attribute ||
                    e.Node.ImageIndex == objLocalConfig.ImageID_RelationType ||
                    e.Node.ImageIndex == objLocalConfig.ImageID_Token)
                {
                    var objOItem_Ref = new clsOntologyItem { 
                                                             GUID = e.Node.Name,
                                                             Name = e.Node.Text
                                                           };
                    objUserControl_Documents.Initialize_Documents(objLocalConfig.DataWork_Documents, objOItem_Ref);
                }
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

