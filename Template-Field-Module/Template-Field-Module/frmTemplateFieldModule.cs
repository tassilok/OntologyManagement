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

namespace Template_Field_Module
{
    public partial class frmTemplateFieldModule : Form
    {
        private clsLocalConfig objLocalConfig;

        public frmTemplateFieldModule()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {

        }

        

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
