using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontolog_Module;

namespace Version_Module
{
    public partial class frmVersionModule : Form
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_RefTree objDataWork_RefTree;

        private UserControl_RefTree objUserControl_RefTree;

        public frmVersionModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());


        }

        private void initialize()
        {


            objUserControl_RefTree = new UserControl_RefTree(objDataWork_RefTree);
            objUserControl_RefTree.Dock = DockStyle.Fill;
            
            splitContainer1.Panel1.Controls.Add(objUserControl_RefTree);
        }
    }
}
