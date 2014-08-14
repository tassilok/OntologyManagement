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
using Ontology_Module;
using ClassLibrary_ShellWork;

namespace CommandLineRun_Module
{
    public partial class UserControl_CommandLineRunTree : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private clsOntologyItem objOItem_Ref;

        private frm_ObjectEdit objFrmObjectEdit;

        private frmModules objFrmModules;
        private frmAdvancedFilter objFrmAdvancedFilter;

        private clsDataWork_CommandLineRun objDataWork_CommandLineRun;
        private clsShellWork objShellWork;

        public delegate void SelectedNode(TreeNode selectedNode);

        private string strLastModule;

        public event SelectedNode selectedNode;

        private Color nodeBackColor;
        private Color nodeForeColor;
        private Color nodeBackColor_marked = System.Drawing.Color.Yellow;

        private bool searchIsRunning;

        private TreeNode treeNode_Root;

        public UserControl_CommandLineRunTree(clsLocalConfig LocalConfig, clsDataWork_CommandLineRun DataWork_CommandLineRun)
        {
            objLocalConfig = LocalConfig;
            objDataWork_CommandLineRun = DataWork_CommandLineRun;
            InitializeComponent();

            Intialize();
        }

        private void Intialize()
        {
            objShellWork = new clsShellWork();
        }

        public void InitializeTree()
        {
            treeView_CMDLR.Nodes.Clear();
            treeNode_Root =
                                                treeView_CMDLR.Nodes.Add(objLocalConfig.Globals.Root.GUID,
                                                                         objLocalConfig.Globals.Root.Name);

            nodeBackColor = treeNode_Root.BackColor;
            nodeForeColor = treeNode_Root.ForeColor;

            objDataWork_CommandLineRun.FillSubNodes(treeNode_Root);

            if (objDataWork_CommandLineRun.OItem_Object != null && objDataWork_CommandLineRun.OItem_Object.GUID_Parent == objLocalConfig.OItem_class_comand_line__run_.GUID)
            {
                var nodes = treeView_CMDLR.Nodes.Find(objDataWork_CommandLineRun.OItem_Object.GUID, true);

                if (nodes.Any())
                {
                    treeView_CMDLR.SelectedNode = nodes.First();

                   
                }

            }

            treeNode_Root.Expand();

            toolStripLabel_Count.Text = objDataWork_CommandLineRun.RootNodeCount.ToString();
        }

        private void treeView_CMDLR_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowCMDLR_Data(e.Node);
            
        }

        private void ShowCMDLR_Data(TreeNode node)
        {
            if (!searchIsRunning)
            {
                selectedNode(node);
            }
        }

        private void toolStripTextBox_Mark_TextChanged(object sender, EventArgs e)
        {
            timer_Mark.Stop();
            timer_Mark.Start();
        }

        private void timer_Mark_Tick(object sender, EventArgs e)
        {
            timer_Mark.Stop();
            searchIsRunning = true;
            UnmarkNodes();
            treeView_CMDLR.CollapseAll();
            treeNode_Root.Expand();
            if (!string.IsNullOrEmpty(toolStripTextBox_Mark.Text))
            {
                SearchNode(toolStripTextBox_Mark.Text, objLocalConfig.Globals.is_GUID(toolStripTextBox_Mark.Text));    
            }
            
            
            searchIsRunning = false;
            if (treeView_CMDLR.SelectedNode != null)
            {

                ShowCMDLR_Data(treeView_CMDLR.SelectedNode);
            }
            else
            {
                
                treeView_CMDLR.SelectedNode = treeNode_Root;
            }
        }

        private void UnmarkNodes(TreeNode parentNode = null)
        {
            if (parentNode == null)
            {
                foreach (TreeNode subNode in treeView_CMDLR.Nodes)
                {
                    subNode.BackColor = nodeBackColor;

                    UnmarkNodes(subNode);
                }
            }
            else
            {
                foreach (TreeNode subNode in parentNode.Nodes)
                {
                    subNode.BackColor = nodeBackColor;

                    UnmarkNodes(subNode);
                }
            }
        }

        private void SearchNode(string search, bool isGuid, TreeNode parentNode = null)
        {
            
            if (parentNode == null)
            {
                
                foreach (TreeNode subNode in treeView_CMDLR.Nodes)
                {
                    if (isGuid)
                    {
                        if (subNode.Name == search)
                        {
                            subNode.BackColor = nodeBackColor_marked;
                            
                            var parentNodeTmp = subNode.Parent;
                            while (parentNodeTmp != null)
                            {
                                parentNodeTmp.Expand();
                                parentNodeTmp = parentNodeTmp.Parent;
                            }

                            
                        }
                    }
                    else
                    {
                        if (subNode.Text.ToLower().Contains(search.ToLower()))
                        {
                            subNode.BackColor = nodeBackColor_marked;
                            
                            var parentNodeTmp = subNode.Parent;
                            while (parentNodeTmp != null)
                            {
                                parentNodeTmp.Expand();
                                parentNodeTmp = parentNodeTmp.Parent;
                            }

                        }
                    }

                    SearchNode(search, isGuid, subNode);

                }
            }
            else
            {
                foreach (TreeNode subNode in parentNode.Nodes)
                {
                    if (isGuid)
                    {
                        if (subNode.Name == search)
                        {
                            subNode.BackColor = nodeBackColor_marked;
                            
                            var parentNodeTmp = subNode.Parent;
                            while (parentNodeTmp != null)
                            {
                                parentNodeTmp.Expand();
                                parentNodeTmp = parentNodeTmp.Parent;
                            }
                            
                            
                        }
                    }
                    else
                    {
                        if (subNode.Text.ToLower().Contains(search.ToLower()))
                        {
                            subNode.BackColor = nodeBackColor_marked;
                            
                            var parentNodeTmp = subNode.Parent;
                            while (parentNodeTmp != null)
                            {
                                parentNodeTmp.Expand();
                                parentNodeTmp = parentNodeTmp.Parent;
                            }
                            
                            
                        }
                    }

                    SearchNode(search, isGuid, subNode);

                }
            }
        }

        private void treeView_CMDLR_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name != objLocalConfig.Globals.Root.GUID)
            {
                var objOList_NodeItems = new List<clsOntologyItem>
                    {
                        new clsOntologyItem
                            {
                                GUID = e.Node.Name,
                                Name = e.Node.Text,
                                GUID_Parent = objLocalConfig.OItem_class_comand_line__run_.GUID,
                                Type = objLocalConfig.Globals.Type_Object
                            }
                    };

                objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals,objOList_NodeItems, 0, objLocalConfig.Globals.Type_Object, null);
                objFrmObjectEdit.ShowDialog(this);
            }
        }

        private void contextMenuStrip_CMDLR_Opening(object sender, CancelEventArgs e)
        {
            var node = treeView_CMDLR.SelectedNode;
            ModuleMenuToolStripMenuItem.Enabled = false;
            if (node != null && node.Name != objLocalConfig.Globals.Root.GUID)
            {
                ModuleMenuToolStripMenuItem.Enabled = true;   
            }
        }

        private void OpenModuleByArgumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView_CMDLR.SelectedNode;
            if (node != null && node.Name != objLocalConfig.Globals.Root.GUID)
            {
                var objOItem_CMDLR = new clsOntologyItem
                    {
                        GUID = node.Name,
                        Name = node.Text,
                        GUID_Parent = objLocalConfig.OItem_class_comand_line__run_.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                if (!OpenLastModuleToolStripMenuItem.Checked || string.IsNullOrEmpty(strLastModule))
                {
                    objFrmModules = new frmModules(objLocalConfig.Globals);
                    objFrmModules.ShowDialog(this);

                    if (objFrmModules.DialogResult == DialogResult.OK)
                    {
                        var strModule = objFrmModules.Selected_Module;
                        if (!string.IsNullOrEmpty(strModule))
                        {
                            if (objShellWork.start_Process(strModule, "Item=" + objOItem_CMDLR.GUID + ",Object",
                                                           System.IO.Path.GetDirectoryName(strModule), false, false))
                            {
                                strLastModule = strModule;
                                OpenLastModuleToolStripMenuItem.ToolTipText = strLastModule;
                            }
                            else
                            {
                                MessageBox.Show(this, "Das Modul konnte nicht gestartet werden!", "Fehler!",
                                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }    

                }
                else
                {
                    if (objShellWork.start_Process(strLastModule, "Item=" + objOItem_CMDLR.GUID + ",Object",
                                                           System.IO.Path.GetDirectoryName(strLastModule), false, false))
                    {
                        OpenLastModuleToolStripMenuItem.ToolTipText = strLastModule;
                    }
                    else
                    {
                        MessageBox.Show(this, "Das Modul konnte nicht gestartet werden!", "Fehler!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                
            }
        }

        private void toolStripButton_AddSemFilter_Click(object sender, EventArgs e)
        {
            objFrmAdvancedFilter = new frmAdvancedFilter(objLocalConfig.Globals, objLocalConfig.OItem_class_comand_line__run_);
            objFrmAdvancedFilter.ShowDialog(this);

            if (objFrmAdvancedFilter.DialogResult == DialogResult.OK)
            {
                objDataWork_CommandLineRun.OItem_Class = objFrmAdvancedFilter.OItem_Class;
                objDataWork_CommandLineRun.OItem_Direction = objFrmAdvancedFilter.OItem_Direction;
                objDataWork_CommandLineRun.OItem_RelationType = objFrmAdvancedFilter.OItem_RelationType;
                objDataWork_CommandLineRun.OItem_Object = objFrmAdvancedFilter.OItem_Object;

                

                objDataWork_CommandLineRun.GetData_CommandLineRun();
                InitializeTree();

            }

            var strSemFilter = "";

            if (objDataWork_CommandLineRun.OItem_Direction != null)
            {
                strSemFilter = objDataWork_CommandLineRun.OItem_Direction.GUID ==
                               objLocalConfig.Globals.Direction_LeftRight.GUID
                                   ? "o >"
                                   : "o <";

                strSemFilter += " | cl: " + (objDataWork_CommandLineRun.OItem_Class != null
                                    ? objDataWork_CommandLineRun.OItem_Class.Name
                                    : "");

                strSemFilter += " | rel: " + (objDataWork_CommandLineRun.OItem_RelationType != null
                                    ? objDataWork_CommandLineRun.OItem_RelationType.Name
                                    : "");

                strSemFilter += " | obj: " + (objDataWork_CommandLineRun.OItem_Object != null
                                    ? objDataWork_CommandLineRun.OItem_Object.Name
                                    : "");


            }

            toolStripTextBox_SemFilter.Text = strSemFilter;
        }

    }
}
