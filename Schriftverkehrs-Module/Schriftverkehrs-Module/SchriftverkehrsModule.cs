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

namespace Schriftverkehrs_Module
{
    public partial class SchriftverkehrsModule : Form
    {
        private clsLocalConfig objLocalConfig;

        private UserControl_Report objUserControl_Report;

        private frmAuthenticate objFrmAuthenticate;

        private bool boolOpen;

        public SchriftverkehrsModule()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig();
            Initialize();
        }

        private void Initialize()
        {
            objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, false, frmAuthenticate.ERelateMode.NoRelate,true);
            objFrmAuthenticate.ShowDialog(this);

            if (objFrmAuthenticate.DialogResult == DialogResult.OK)
            {
                boolOpen = true;
                objLocalConfig.User = objFrmAuthenticate.OItem_User;
                objUserControl_Report = new UserControl_Report(objLocalConfig);
                objUserControl_Report.Dock = DockStyle.Fill;
                toolStripContainer1.ContentPanel.Controls.Add(objUserControl_Report);
            }
            else
            {
                boolOpen = false;
            }

            
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SchriftverkehrsModule_Load(object sender, EventArgs e)
        {
            if (!boolOpen)
            {
                this.Close();
            }
        }
    }
}
