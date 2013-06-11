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

namespace ElasticSearchToXML
{
    public partial class frmMain : Form
    {
        private readonly clsGlobals objGlobals;
        private clsDBLevel objDbLevel;

        public frmMain()
        {
            InitializeComponent();
            objGlobals = new clsGlobals();
            set_DBConnection();
        }

        private void set_DBConnection()
        {
            objDbLevel = new clsDBLevel(objGlobals);
        }
    }
}
