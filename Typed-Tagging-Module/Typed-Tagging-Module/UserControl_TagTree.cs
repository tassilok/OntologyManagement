using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;

namespace Typed_Tagging_Module
{
    public partial class UserControl_TagTree : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private clsDataWork_Tagging objDataWork_Tagging;

        private clsOntologyItem objOItem_Result_Tag;

        private TreeNode objTreeNode_Root;
        private TreeNode objTreeNode_AttributeType;
        private TreeNode objTreeNode_RelationType;

        private int taggedNodeCount;

        public delegate void SelectedNode(clsOntologyItem OItem_Selected);

        public event SelectedNode Selected_Node;

        public UserControl_TagTree(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDataWork_Tagging = new clsDataWork_Tagging(objLocalConfig);

            objOItem_Result_Tag = objDataWork_Tagging.GetTags();

            if (objOItem_Result_Tag.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                treeView_Tags.Nodes.Clear();
                MessageBox.Show(this, "Die Tags konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                CreateTreeStructure();
            }

            
        }

        private void CreateTreeStructure()
        {
            treeView_Tags.Nodes.Clear();

            objTreeNode_Root = treeView_Tags.Nodes.Add(
                objLocalConfig.Globals.Type_Class, 
                objLocalConfig.Globals.Type_Class, 
                objLocalConfig.ImageID_Root, 
                objLocalConfig.ImageID_Root);

            objTreeNode_AttributeType = treeView_Tags.Nodes.Add(
                objLocalConfig.Globals.Type_AttributeType,
                objLocalConfig.Globals.Type_AttributeType,
                objLocalConfig.ImageID_AttributTypes,
                objLocalConfig.ImageID_AttributTypes);

            objTreeNode_RelationType = treeView_Tags.Nodes.Add(
                objLocalConfig.Globals.Type_RelationType,
                objLocalConfig.Globals.Type_RelationType,
                objLocalConfig.ImageID_RelationTypes,
                objLocalConfig.ImageID_RelationTypes
                );
            taggedNodeCount = 0;
            CreateClassStructure(objTreeNode_Root);
            CreateObjectNodes();
            toolStripLabel_Count.Text = taggedNodeCount.ToString();
        }

        private void CreateObjectNodes()
        {
            var GUID_Class = "";

            TreeNode objTreeNode;

            var objectCount = objDataWork_Tagging.ObjectTags.Count();

            TreeNode objTreeNodeClass = null;
            foreach (var oItem in objDataWork_Tagging.ObjectTags)
            {
                var tagCount = objDataWork_Tagging.Tags_Of_TypedTags.Where(t => t.ID_Other == oItem.GUID).ToList().Count;

                double percent = 100.0 / objectCount * tagCount;

                if (oItem.GUID_Parent != GUID_Class)
                {
                    GUID_Class = oItem.GUID_Parent;
                    var treeNodes = treeView_Tags.Nodes.Find(GUID_Class, true);

                    if (treeNodes.Any())
                    {
                        objTreeNodeClass = treeNodes.First();
                    }
                    else
                    {
                        objTreeNodeClass = null;
                    }
                }

                if (objTreeNodeClass != null)
                {
                    var objectNodes = objTreeNodeClass.Nodes.Find(oItem.GUID, false);
                    if (!objectNodes.Any())
                    {
                        objTreeNode = objTreeNodeClass.Nodes.Add(oItem.GUID, oItem.Name, objLocalConfig.ImageID_Token, objLocalConfig.ImageID_Token);
                        //if (percent > 20)
                        //{
                        //    var font = new Font(treeView_Tags.Font.FontFamily, treeView_Tags.Font.Size + (int)(percent / 20));
                        //}
                        taggedNodeCount++;
                    }
                }
            }
        }

        private void CreateClassStructure(TreeNode objTreeNode_Parent)
        {
            var objClasses = new List<clsOntologyItem>();
            if (objTreeNode_Parent.Name == objLocalConfig.Globals.Type_Class)
            {
                objClasses = objDataWork_Tagging.ClassTree.Where(c => c.GUID_Parent == objLocalConfig.Globals.Root.GUID).ToList();

            }
            else
            {
                objClasses = objDataWork_Tagging.ClassTree.Where(c => c.GUID_Parent == objTreeNode_Parent.Name).ToList();
            }

            foreach (var objClass in objClasses)
            {
                var objTreeNode = objTreeNode_Parent.Nodes.Add(objClass.GUID, objClass.Name, objLocalConfig.ImageID_Closed, objLocalConfig.ImageID_Opened);
                
                var objClassTags = objDataWork_Tagging.ClassTags.Where(c => c.GUID == objClass.GUID).ToList();

                if (objClassTags.Any())
                {
                    taggedNodeCount++;
                    objTreeNode.ImageIndex = objLocalConfig.ImageID_Closed_with_items;
                    objTreeNode.SelectedImageIndex = objLocalConfig.ImageID_Opened_with_items;
                }
                CreateClassStructure(objTreeNode);
            }
        }

        private void treeView_Tags_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageIndex == objLocalConfig.ImageID_AttributTypes ||
                e.Node.ImageIndex == objLocalConfig.ImageID_RelationTypes ||
                e.Node.ImageIndex == objLocalConfig.ImageID_Root ||
                e.Node.ImageIndex == objLocalConfig.ImageID_Closed)
            {
                Selected_Node(null);
            }
            else
            {
                var objTags = objDataWork_Tagging.Tags_Of_TypedTags.Where(t => t.ID_Other == e.Node.Name).ToList();

                if (objTags.Any())
                {
                    Selected_Node(new clsOntologyItem
                    {
                        GUID = objTags.First().ID_Other,
                        Name = objTags.First().Name_Other,
                        GUID_Parent = objTags.First().ID_Parent_Other,
                        Type = objTags.First().Ontology
                    });
                }
            }
        }
    }
}
