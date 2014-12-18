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
    public partial class Form_EntoEdit : Form
    {
        private clsLocalConfig objLocalConfig;
        private UserControl_TypeTree userControl_TypeTree;
        private UserControl_OItemList userControl_OItemList;

        public Form_EntoEdit()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            objLocalConfig = new clsLocalConfig(new clsGlobals());

            userControl_TypeTree = new UserControl_TypeTree(objLocalConfig.Globals);
            userControl_TypeTree.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(userControl_TypeTree);
            userControl_TypeTree.initialize_Tree();

            userControl_TypeTree.selected_Class += userControl_TypeTree_selected_Class;

            userControl_OItemList = new UserControl_OItemList(objLocalConfig);
            userControl_OItemList.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(userControl_OItemList);
        }

        void userControl_TypeTree_selected_Class(clsOntologyItem OItem_Class)
        {
            
        }
    }
}
