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
using Ontolog_Module;

namespace Version_Module
{

    public delegate void SelectedNode(clsOntologyItem OItem_SelectedNode);

    public partial class UserControl_RefTree : UserControl
    {
        public event SelectedNode selectedNode;

        private clsDataWork_Versions objDataWorkVersions;

        private frm_ObjectEdit objFrm_ObjectEdit;

        public UserControl_RefTree(clsDataWork_Versions dataWorkVersions)
        {
            InitializeComponent();
            objDataWorkVersions = dataWorkVersions;
            var objOItem_Result = objDataWorkVersions.GetData_RefTree();

            if (objOItem_Result.GUID == objDataWorkVersions.LocalConfig.Globals.LState_Success.GUID)
            {
                if (objDataWorkVersions.TreeNode_Root != null)
                    treeView_Ref.Nodes.Add(objDataWorkVersions.TreeNode_Root);


                if (objDataWorkVersions.TreeNode_AttributeTypes != null)
                    treeView_Ref.Nodes.Add(objDataWorkVersions.TreeNode_AttributeTypes);

                if (objDataWorkVersions.TreeNode_RelationTypes != null)
                    treeView_Ref.Nodes.Add(objDataWorkVersions.TreeNode_RelationTypes);
            }
            else
            {
                MessageBox.Show(this, "Der Referenz-Baum konnte nicht ermittelt werden!", "Fehler!",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void treeView_Ref_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var objTreeNode = treeView_Ref.SelectedNode;
            var typeItem = "";

            if (objTreeNode != null)
            {
                if (objTreeNode.ImageIndex == objDataWorkVersions.LocalConfig.ImageID_AttributeType ||
                    objTreeNode.ImageIndex == objDataWorkVersions.LocalConfig.ImageID_RelationType ||
                    objTreeNode.ImageIndex == objDataWorkVersions.LocalConfig.ImageID_Closed ||
                    objTreeNode.ImageIndex == objDataWorkVersions.LocalConfig.ImageID_Object)
                {
                    typeItem = objTreeNode.ImageIndex == objDataWorkVersions.LocalConfig.ImageID_AttributeType
                                   ? objDataWorkVersions.LocalConfig.Globals.Type_AttributeType
                                   : objTreeNode.ImageIndex == objDataWorkVersions.LocalConfig.ImageID_RelationType
                                         ? objDataWorkVersions.LocalConfig.Globals.Type_RelationType
                                         : objTreeNode.ImageIndex == objDataWorkVersions.LocalConfig.ImageID_Closed
                                               ? objDataWorkVersions.LocalConfig.Globals.Type_Class
                                               : objTreeNode.ImageIndex == objDataWorkVersions.LocalConfig.ImageID_Object
                                                     ? objDataWorkVersions.LocalConfig.Globals.Type_Object
                                                     : "";

                    var objOItem_Selected = new clsOntologyItem
                        {
                            GUID = objTreeNode.Name,
                            Name = objTreeNode.Text,
                            Type = typeItem
                        };

                    selectedNode(objOItem_Selected);
                }
                
            }
        }

        private void treeView_Ref_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var objTreeNode = treeView_Ref.SelectedNode;

            if (objTreeNode == null) return;
            if (objTreeNode.ImageIndex == objDataWorkVersions.LocalConfig.ImageID_Object)
            {
                var objOList_Object = new List<clsOntologyItem>
                    {
                        new clsOntologyItem
                            {
                                GUID = objTreeNode.Name,
                                Name = objTreeNode.Text,
                                GUID_Parent = objTreeNode.Parent.Name,
                                Type = objDataWorkVersions.LocalConfig.Globals.Type_Object
                            }
                    };

                objFrm_ObjectEdit = new frm_ObjectEdit(objDataWorkVersions.LocalConfig.Globals, objOList_Object,0,objDataWorkVersions.LocalConfig.Globals.Type_Object,null);
                objFrm_ObjectEdit.ShowDialog(this);

            }
        }
    }
}
