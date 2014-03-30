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

namespace ESMaintenance_Module
{
    public partial class frmESMaintenance : Form
    {
        private UserControl_ElasticSearch objUserControl_ElasticSearch;



        private clsLocalConfig objLocalConfig;

        public frmESMaintenance()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {

            objUserControl_ElasticSearch = new UserControl_ElasticSearch(objLocalConfig);
            objUserControl_ElasticSearch.Dock = DockStyle.Fill;
            toolStripContainer1.ContentPanel.Controls.Add(objUserControl_ElasticSearch);
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }
}
