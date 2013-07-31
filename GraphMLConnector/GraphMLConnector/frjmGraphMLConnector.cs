using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontolog_Module;

namespace GraphMLConnector
{
    public partial class frmGraphMLConnector : Form
    {
        private clsLocalConfig objLocalConfig;

        private clsGraphMLWork objGraphMLWork;

        public frmGraphMLConnector()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            objGraphMLWork = new clsGraphMLWork(objLocalConfig);
            objGraphMLWork.ExportClasses();
        }
    }
}
