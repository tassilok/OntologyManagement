using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontolog_Module;
using Security_Module;

namespace Appointment_Module
{
    public partial class frmAppointmentModule : Form
    {
        private clsLocalConfig objLocalConfig;
        private frmAuthenticate objFrmAuthenticate;

        public frmAppointmentModule()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(new clsGlobals());
            objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, 
                                                     true, 
                                                     false, 
                                                     frmAuthenticate.ERelateMode.NoRelate);

            objFrmAuthenticate.ShowDialog(this);
            if (objFrmAuthenticate.DialogResult == DialogResult.OK)
            {
                objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User;
            }
            else
            {
                objLocalConfig.OItem_User = null;
            }

        }

        private void frmAppointmentModule_Load(object sender, EventArgs e)
        {
            if (objLocalConfig.OItem_User == null)
            {
                MessageBox.Show("Sie müssen einen User auswählen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
