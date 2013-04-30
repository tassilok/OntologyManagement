using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReparseElasticSearchDocs.Classes;

namespace ReparseElasticSearchDocs
{
    public partial class frmMain : Form
    {
        private clsLocalConfig objLocalConfig = new clsLocalConfig();
        private clsReparse objReparse;
        public frmMain()
        {
            InitializeComponent();

            objReparse = new clsReparse(objLocalConfig);
            objReparse.reparse();
        }
    }
}
