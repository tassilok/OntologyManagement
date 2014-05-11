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

namespace ElasticSearchLogging_Module
{
    public partial class frmElasticSearchLogging : Form
    {
        private clsLocalConfig objLocalConfig;

        private UserControl_RefTree objUserControl_RefTree;
        private UserControl_OItemList objUserControl_OItemList;

        public frmElasticSearchLogging()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {
            objUserControl_RefTree = new UserControl_RefTree(objLocalConfig.Globals);
            objUserControl_RefTree.Dock = DockStyle.Fill;
            objUserControl_RefTree.selected_Node += objUserControl_RefTree_selected_Node;
            splitContainer1.Panel1.Controls.Add(objUserControl_RefTree);

            var oList_ReferenceClasses = new List<clsOntologyItem> { objLocalConfig.OItem_class_log__elasticsearch_ };
            var oList_RelationTypes = new List<clsOntologyItem> { objLocalConfig.OItem_relationtype_belongs_to };

            objUserControl_OItemList = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_OItemList.Dock = DockStyle.Fill;
            splitContainer2.Panel1.Controls.Add(objUserControl_OItemList);

            objUserControl_RefTree.initialize_Tree(oList_ReferenceClasses, oList_RelationTypes);
        }

        void objUserControl_RefTree_selected_Node(clsOntologyItem OItem_Selected)
        {
            if (OItem_Selected != null)
            {
                if (OItem_Selected.GUID != objLocalConfig.Globals.Root.GUID)
                {
                    
                }
            }
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
