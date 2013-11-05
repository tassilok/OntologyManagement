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
using OntologyClasses.BaseClasses;
using Security_Module;

namespace TimeManagement_Module
{
    public partial class frmTimeManagementModule : Form
    {
        private clsLocalConfig objLocalConfig;
        private frmAuthenticate objFrmAuthenticate;

        private UserControl_TimeGrid objUserControl_TimeGrid;

        public frmTimeManagementModule()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(new clsGlobals());
            Initialize();
        }

        private void Initialize()
        {
            objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, false, frmAuthenticate.ERelateMode.NoRelate);
            objFrmAuthenticate.ShowDialog(this);
            if (objFrmAuthenticate.DialogResult == DialogResult.OK)
            {
                objLocalConfig.User = objFrmAuthenticate.OItem_User;

                objUserControl_TimeGrid = new UserControl_TimeGrid(objLocalConfig);
                objUserControl_TimeGrid.Dock = DockStyle.Fill;
                toolStripContainer1.ContentPanel.Controls.Add(objUserControl_TimeGrid);
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
