using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Structure_Module;
using OntologyClasses.BaseClasses;

namespace TextParser
{
    public partial class frmRegexTester : Form
    {

        private UserControl_RegExTester objUserControl_RegExTester;

        private clsLocalConfig objLocalConfig;

        private clsOntologyItem oItem_Field;

        public clsOntologyItem OItem_Field 
        {
            get { return oItem_Field; }
            set
            {
                oItem_Field = value;
            }
        }

        
        public frmRegexTester(clsLocalConfig LocalConfig, clsOntologyItem oItem_Field = null)
        {
            InitializeComponent();

            OItem_Field = oItem_Field;
            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            objUserControl_RegExTester = new UserControl_RegExTester(objLocalConfig);
            objUserControl_RegExTester.Dock = DockStyle.Fill;

            objUserControl_RegExTester.Initialize_Field(OItem_Field);
            toolStripContainer1.ContentPanel.Controls.Add(objUserControl_RegExTester);
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
