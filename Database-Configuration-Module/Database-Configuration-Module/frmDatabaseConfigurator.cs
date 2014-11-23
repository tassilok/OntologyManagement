using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontology_Module;

namespace DatabaseConfigurationModule
{
    public partial class frmDatabaseConfiguratorModule : Form
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_DatabaseConfiguratorModule objDataWork_DatabaseConfiguratorModule;

        private UserControl_ConfiguratorTree objUserControl_ConfiguratorTree;

        public frmDatabaseConfiguratorModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());
            Initialize();
        }

        private void Initialize()
        {
            objDataWork_DatabaseConfiguratorModule = new clsDataWork_DatabaseConfiguratorModule(objLocalConfig);

            objUserControl_ConfiguratorTree = new UserControl_ConfiguratorTree(objLocalConfig, objDataWork_DatabaseConfiguratorModule);
            objUserControl_ConfiguratorTree.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(objUserControl_ConfiguratorTree);
        }
    }
}
