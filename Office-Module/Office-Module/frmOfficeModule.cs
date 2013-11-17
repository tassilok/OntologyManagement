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

        private SplashScreen_OntologyModule SplashScreen;
        private AboutBox_OntologyItem AboutBox;

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

            Application.DoEvents();
            SplashScreen = new SplashScreen_OntologyModule();
            SplashScreen.Show();
            SplashScreen.Refresh();

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

            objTreeNode_Root = treeView_Items.Nodes.Add(objLocalConfig.OItem_Module.GUID, objLocalConfig.OItem_Module.Name, objLocalConfig.ImageID_Root, objLocalConfig.ImageID_Root);
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
            var objTreeNode = treeView_Items.SelectedNode;

            if (objTreeNode != null)
            {
                if (objTreeNode.ImageIndex == objLocalConfig.ImageID_Attributes)
                {

                }
                else if (objTreeNode.ImageIndex == objLocalConfig.ImageID_RelationTypes)
                {

                }
                else if (objTreeNode.ImageIndex == objLocalConfig.ImageID_Open ||
                         objTreeNode.ImageIndex == objLocalConfig.ImageID_Open_Images ||
                         objTreeNode.ImageIndex == objLocalConfig.ImageID_Open_Images_SubItems ||
                         objTreeNode.ImageIndex == objLocalConfig.ImageID_Open_Subitems)
                {

                }
                else if (objTreeNode.ImageIndex == objLocalConfig.ImageID_Root)
                {
                    objFrmOntologyModule = new frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class);
                    objFrmOntologyModule.ShowDialog(this);
                    if (objFrmOntologyModule.DialogResult == DialogResult.OK)
                    {
                        if (objFrmOntologyModule.OList_Simple.Count == 1)
                        {
                            var objOItem = objFrmOntologyModule.OList_Simple.First();

                            if (objOItem.Type == objLocalConfig.Globals.Type_AttributeType)
                            {
                                var objTreeNodes = objTreeNode_Attributes.Nodes.Find(objOItem.GUID, false);
                                if (!objTreeNodes.Any())
                                {
                                    var objTreeNodeNew = objTreeNode_Attributes.Nodes.Add(objOItem.GUID,
                                                                                       objOItem.Name,
                                                                                       objLocalConfig.ImageID_Attribute,
                                                                                       objLocalConfig.ImageID_Attribute);
                                    treeView_Items.SelectedNode = objTreeNodeNew;
                                }
                                else
                                {
                                    treeView_Items.SelectedNode = objTreeNodes.First();
                                }
                            }
                            else if (objOItem.Type == objLocalConfig.Globals.Type_Class)
                            {
                                var objTreeNodeNew =GetClassNode(objOItem);

                                if (objTreeNodeNew != null)
                                {
                                    treeView_Items.SelectedNode = objTreeNodeNew;
                                }
                                else
                                {
                                    MessageBox.Show(this, "Die Klasse konnte nicht erzeugt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else if (objOItem.Type == objLocalConfig.Globals.Type_Object)
                            {
                                var objOItem_Class = objLocalConfig.DataWork_Documents.GetClassOfObject(objOItem);
                                var objTreeNodeNew = GetClassNode(objOItem_Class);

                                if (objTreeNodeNew != null)
                                {
                                    var objTreeNodes = objTreeNodeNew.Nodes.Find(objOItem.GUID, false);
                                    if (objTreeNodes.Any())
                                    {
                                        treeView_Items.SelectedNode = objTreeNodes.First();
                                    }
                                    else
                                    {
                                        objTreeNodeNew = objTreeNodeNew.Nodes.Add(objOItem.GUID, objOItem.Name,
                                                                              objLocalConfig.ImageID_Token, objLocalConfig.ImageID_Token);
                                        treeView_Items.SelectedNode = objTreeNodeNew;
                                    }
                                    
                                }
                                else
                                {
                                    MessageBox.Show(this, "Die Klasse des Objekts konnte nicht erzeugt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else if (objOItem.Type == objLocalConfig.Globals.Type_RelationType)
                            {
                                
                                var objTreeNodes = objTreeNode_RelationTypes.Nodes.Find(objOItem.GUID, false);
                                if (!objTreeNodes.Any())
                                {
                                    var objTreeNodeNew = objTreeNode_RelationTypes.Nodes.Add(objOItem.GUID,
                                                                                       objOItem.Name,
                                                                                       objLocalConfig.ImageID_RelationTypes,
                                                                                       objLocalConfig.ImageID_RelationTypes);
                                    treeView_Items.SelectedNode = objTreeNodeNew;
                                }
                                else
                                {
                                    treeView_Items.SelectedNode = objTreeNodes.First();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Bitte nur ein Item auswählen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }

        }

        private TreeNode GetClassNode(clsOntologyItem OItem_Class)
        {
            
            var objTreeNodes = treeView_Items.Nodes.Find(OItem_Class.GUID, true);
            TreeNode objTreeNode = null;
            if (!objTreeNodes.Any())
            {
                objTreeNodes = treeView_Items.Nodes.Find(OItem_Class.GUID_Parent, true);
                if (!objTreeNodes.Any())
                {
                    var objOList_Classes = objLocalConfig.DataWork_Documents.GetClassParents(OItem_Class);
                    if (objOList_Classes != null && objOList_Classes.Any())
                    {
                        while (objTreeNode == null)
                        {
                            var objOList_ClassesLast = objOList_Classes.Join(objOList_Classes, left => left.GUID, right => right.GUID_Parent, (left, right) => left).DefaultIfEmpty().Where(p => p == null).ToList();
                            if (objOList_ClassesLast.Any())
                            {
                                objTreeNodes = treeView_Items.Nodes.Find(objOList_ClassesLast.First().GUID_Parent, true);
                                if (objTreeNodes.Any())
                                {
                                    objTreeNode =  objTreeNodes.First().Nodes.Add(objOList_ClassesLast.First().GUID, objOList_ClassesLast.First().Name,
                                                                   objLocalConfig.ImageID_Close,
                                                                   objLocalConfig.ImageID_Open);
                                }

                                objOList_Classes.Remove(objOList_ClassesLast.First());
                            }
                            else
                            {
                                break;
                            }
                        }

                        


                        
                        

                    }
                    else
                    {
                        objTreeNode = null;
                    }
                }
                else
                {
                    objTreeNode =  objTreeNodes.First().Nodes.Add(OItem_Class.GUID, OItem_Class.Name, objLocalConfig.ImageID_Close, objLocalConfig.ImageID_Open);

                }
            }
            else
            {
                objTreeNode = objTreeNodes.First();
                treeView_Items.SelectedNode = objTreeNodes.First();
            }

            return objTreeNode;
        }

        private void frmOfficeModule_Load(object sender, EventArgs e)
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

