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

namespace Typed_Tagging_Module
{
    public partial class frmTypedTaggingSingle : Form
    {
        private UserControl_TaggingContainer objUserControl_TypedTagging;

        private clsLocalConfig objLocalConfig;

        private clsOntologyItem objOItem_TaggingSource;

        public frmTypedTaggingSingle(clsGlobals Globals, clsOntologyItem OItem_User, clsOntologyItem OItem_Group, clsOntologyItem OItem_TaggingSource)
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(Globals);

            objLocalConfig.OItem_User = OItem_User;
            objLocalConfig.OItem_Group = OItem_Group;
            objOItem_TaggingSource = OItem_TaggingSource;

            Initialize();
        }

        private void Initialize()
        {
            objUserControl_TypedTagging = new UserControl_TaggingContainer(objLocalConfig);
            objUserControl_TypedTagging.Dock = DockStyle.Fill;
            toolStripContainer1.ContentPanel.Controls.Add(objUserControl_TypedTagging);

            objUserControl_TypedTagging.Initialize_Taging(objOItem_TaggingSource);
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
