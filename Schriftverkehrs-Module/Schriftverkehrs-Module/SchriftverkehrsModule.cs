using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schriftverkehrs_Module
{
    public partial class SchriftverkehrsModule : Form
    {
        private clsLocalConfig objLocalConfig;

        private UserControl_Report objUserControl_Report;

        public SchriftverkehrsModule()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig();
            Initialize();
        }

        private void Initialize()
        {
            objUserControl_Report = new UserControl_Report(objLocalConfig);
            objUserControl_Report.Dock = DockStyle.Fill;
            toolStripContainer1.ContentPanel.Controls.Add(objUserControl_Report);
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
