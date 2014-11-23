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

namespace CommandLineRun_Module
{
    public partial class frmCodeSnippletEditor : Form
    {
        private clsLocalConfig objLocalConfig;

        public frmCodeSnippletEditor(clsGlobals Globals)
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(Globals);
        }
    }
}
