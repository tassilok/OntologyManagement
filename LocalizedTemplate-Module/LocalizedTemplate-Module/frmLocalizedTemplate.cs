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

namespace LocalizedTemplate_Module
{
    public partial class frmLocalizedTemplate : Form
    {

        private clsLocalConfig localConfig;

        

        public frmLocalizedTemplate()
        {
            InitializeComponent();
            localConfig = new clsLocalConfig(new clsGlobals());
            TestAutoCorrection();
        }

        private void TestAutoCorrection()
        {
            frmAutoCorrection objFrmAutoCorrection;
            objFrmAutoCorrection = new frmAutoCorrection(localConfig);
            objFrmAutoCorrection.ValueToSearch = "a";
            objFrmAutoCorrection.selectedCorrectorItem += objFrmAutoCorrection_selectedCorrectorItem;
            objFrmAutoCorrection.Show();
            

        }

        void objFrmAutoCorrection_selectedCorrectorItem(frmAutoCorrection frmAutoCorrection, clsOntologyItem oItem_Selected)
        {
            frmAutoCorrection.Hide();
            MessageBox.Show(this, oItem_Selected.Name, "Value", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
