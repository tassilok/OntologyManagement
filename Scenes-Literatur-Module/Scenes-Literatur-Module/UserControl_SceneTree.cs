using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontolog_Module;
using Office_Module;

namespace Scenes_Literatur_Module
{
    public delegate void SelectedNode(clsOntologyItem OItem_SelectedNode);
    public delegate void ErrorOccured(clsOntologyItem OItem_Result);

    public partial class UserControl_SceneTree : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private frmMain objFrmOntologyModule;
        private frm_ObjectEdit objFrmObjectEdit;
        private frm_Name objFrmName;

        private TreeNode objTreeNode_Root;


        private clsDocumentation objDocumentumentation;

        public event SelectedNode selectedNode;
        public event ErrorOccured errorOccured;

        public UserControl_SceneTree(clsGlobals Globals)
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(Globals);
            initialize();
        }

        public UserControl_SceneTree()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(new clsGlobals());
            initialize();
        }

        public UserControl_SceneTree(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            initialize();
        }

        public void initialize()
        {
            treeView_SceneTree.Nodes.Clear();
            objTreeNode_Root = treeView_SceneTree.Nodes.Add(objLocalConfig.OItem_type_szene.GUID, objLocalConfig.OItem_type_szene.Name, objLocalConfig.ImageID_Root, objLocalConfig.ImageID_Root);
            addLiteratureNodes();
        }

        private void addLiteratureNodes()
        {

            while (objLocalConfig.DataWork_Scenes.OItem_Result_Literature.GUID == objLocalConfig.Globals.LState_Nothing.GUID ||
                   objLocalConfig.DataWork_Scenes.OItem_Result_Chapter.GUID == objLocalConfig.Globals.LState_Nothing.GUID ||
                   objLocalConfig.DataWork_Scenes.OItem_Result_Scene.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
            }

            if (objLocalConfig.DataWork_Scenes.OItem_Result_Literature.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                foreach (var OItem_Literature in objLocalConfig.DataWork_Scenes.OList_Literature)
                {
                    var objTreeNode_Literatrue =  objTreeNode_Root.Nodes.Add(OItem_Literature.GUID,
                                               OItem_Literature.Name,
                                               objLocalConfig.ImageID_Level1Rel_Close,
                                               objLocalConfig.ImageID_Level1Rel_Open);

                    addChapterNodes(objTreeNode_Literatrue);
                }
            }
            else
            {
                errorOccured(objLocalConfig.Globals.LState_Error);
            }
        }

        private void addChapterNodes(TreeNode objTreeNode_Literature)
        {

            var OList_Chapter = (from objRel in objLocalConfig.DataWork_Scenes.OList_Chapter
                                 where objRel.ID_Object == objTreeNode_Literature.Name
                                 select objRel).ToList();

            foreach (var OItem_Chapter in OList_Chapter)
            {
                var objTreeNode_Scene =  objTreeNode_Literature.Nodes.Add(OItem_Chapter.ID_Other, OItem_Chapter.Name_Other, objLocalConfig.ImageiD_Level2Rel_Close, objLocalConfig.ImageiD_Level2Rel_Open);
                addSceneNodes(objTreeNode_Scene);
            }
        }

        private void addSceneNodes(TreeNode objTreeNode_Chapter)
        {
            var OList_Scenes = (from objRel in objLocalConfig.DataWork_Scenes.OList_Scene
                                where objRel.ID_Object == objTreeNode_Chapter.Name
                                select objRel).ToList();

            foreach (var OItem_Scene in OList_Scenes)
            {
                objTreeNode_Chapter.Nodes.Add(OItem_Scene.ID_Other, OItem_Scene.Name_Other, objLocalConfig.ImageID_Scene, objLocalConfig.ImageID_Scene);
            }
        }

        private void treeView_SceneTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var OItem_Node = new clsOntologyItem() 
            { 
                GUID = e.Node.Name,
                Name = e.Node.Text,
                Type = objLocalConfig.Globals.Type_Object 
            };

            if (e.Node.ImageIndex == objLocalConfig.ImageID_Level1Rel_Close)
            {
                OItem_Node.GUID_Parent = objLocalConfig.OItem_type_eigene_literatur.GUID;
                selectedNode(OItem_Node);
            }
            else if (e.Node.ImageIndex == objLocalConfig.ImageiD_Level2Rel_Close)
            {
                OItem_Node.GUID_Parent = objLocalConfig.OItem_type_kapitel.GUID;
                selectedNode(OItem_Node);
            }
            else if (e.Node.ImageIndex == objLocalConfig.ImageID_Scene)
            {
                OItem_Node.GUID_Parent = objLocalConfig.OItem_type_szene.GUID;
                selectedNode(OItem_Node);
            }

            
        }

        private void contextMenuStrip_Tree_Opening(object sender, CancelEventArgs e)
        {
            TreeNode objTreeNode_Selected;
            clsOntologyItem objOItem_Scene;

            newToolStripMenuItem.Enabled = false;
            winwordToolStripMenuItem.Enabled = false;
            removeToolStripMenuItem.Enabled = false;
            applyToolStripMenuItem.Enabled = false;
            openBelongingDocToolStripMenuItem.Enabled = false;
            insertBookmarkToolStripMenuItem.Enabled = false;
            activateBookmarkToolStripMenuItem.Enabled = false;  

            objTreeNode_Selected = treeView_SceneTree.SelectedNode;

            if (objTreeNode_Selected != null)
            {
                if (objTreeNode_Selected.ImageIndex == objLocalConfig.ImageiD_Level2Rel_Close)
                {
                    newToolStripMenuItem.Enabled = true;
                }

                if (objTreeNode_Selected.ImageIndex == objLocalConfig.ImageID_Scene)
                {
                    objOItem_Scene = new clsOntologyItem()
                    {
                        GUID = objTreeNode_Selected.Name,
                        Name = objTreeNode_Selected.Text,
                        GUID_Parent = objLocalConfig.OItem_type_szene.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    var objOItem_Bookmark = objLocalConfig.DataWork_Scenes.getBookmarkOfRef(objOItem_Scene);
                    if (objOItem_Bookmark != null)
                    {
                        if (objOItem_Bookmark.GUID != objLocalConfig.Globals.LState_Error.GUID)
                        {
                            winwordToolStripMenuItem.Enabled = true;
                            activateBookmarkToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Bookmarks konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                }
            }

        }
    }
}
