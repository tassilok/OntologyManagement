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

namespace NextGenerationOntoEdit
{
    public partial class ObjectEdit : Form
    {
        private clsLocalConfig localCnofig;

        public ObjectEdit(clsLocalConfig localConfig, List<clsOntologyItem> ObjectList, int rowId)
        {
            InitializeComponent();

            this.localCnofig = localConfig;
        }
    }
}
