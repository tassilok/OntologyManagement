using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Security_Module;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace SemToOntMigration
{
    public partial class frmSemToOntMigration : Form
    {
        private clsGlobals objGlobals = new clsGlobals();
        private clsOntologyItem objOItem_User;
        private frmAuthenticate objFrmAuthentication;
        private clsMigrationTimeManagement objMigrationTimeManagement;

        public frmSemToOntMigration()
        {
            InitializeComponent();

            objFrmAuthentication = new frmAuthenticate(objGlobals,true,false,frmAuthenticate.ERelateMode.NoRelate);
            objFrmAuthentication.ShowDialog(this);
            if (objFrmAuthentication.DialogResult == DialogResult.OK)
            {
                objOItem_User = objFrmAuthentication.OItem_User;
                objMigrationTimeManagement = new clsMigrationTimeManagement(objGlobals,objOItem_User);
                objMigrationTimeManagement.Migrate();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
