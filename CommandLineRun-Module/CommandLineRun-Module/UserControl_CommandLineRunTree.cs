using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandLineRun_Module
{
    public partial class UserControl_CommandLineRunTree : UserControl
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_CommandLineRun objDataWork_CommandLineRun;

        public delegate void SelectedNode(TreeNode selectedNode);

        public event SelectedNode selectedNode;

        public UserControl_CommandLineRunTree(clsLocalConfig LocalConfig, clsDataWork_CommandLineRun DataWork_CommandLineRun)
        {
            objLocalConfig = LocalConfig;
            objDataWork_CommandLineRun = DataWork_CommandLineRun;
            InitializeComponent();

            
        }

        public void InitializeTree()
        {
            treeView_CMDLR.Nodes.Clear();
            var treeNode_Root =
                                                treeView_CMDLR.Nodes.Add(objLocalConfig.Globals.Root.GUID,
                                                                         objLocalConfig.Globals.Root.Name);

            objDataWork_CommandLineRun.FillSubNodes(treeNode_Root);
        }

        private void treeView_CMDLR_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedNode(e.Node);
        }
    }
}
