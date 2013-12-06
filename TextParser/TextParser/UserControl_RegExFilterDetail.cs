using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace TextParser
{
    public partial class UserControl_RegExFilterDetail : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private clsOntologyItem objOItem_Filter;

        public UserControl_RegExFilterDetail(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            
        }

        public void Initialize_Filter(clsOntologyItem OItem_Filter)
        {
            objOItem_Filter = OItem_Filter;


        }
    }
}
