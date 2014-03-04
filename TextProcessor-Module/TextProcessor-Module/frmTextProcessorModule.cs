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
using Security_Module;

namespace TextProcessor_Module
{
    public partial class frmTextProcessorModule : Form
    {

        private UserControl_OItemList objUserControl_Texte;
        private UserControl_TextProcessor objUserControl_TextProcessor;
        private frmAuthenticate objFrmAuthenticate;

        private clsLocalConfig objLocalConfig;

        public frmTextProcessorModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {
            objUserControl_Texte = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_Texte.initialize(new clsOntologyItem
            {
                GUID_Parent = objLocalConfig.OItem_class_texte__ontologisch_.GUID,
                Type = objLocalConfig.Globals.Type_Object
            });
            objUserControl_Texte.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(objUserControl_Texte);
            objUserControl_Texte.Selection_Changed += objUserControl_Texte_Selection_Changed;

            objUserControl_TextProcessor = new UserControl_TextProcessor(objLocalConfig);
            objUserControl_TextProcessor.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(objUserControl_TextProcessor);

            objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, true, frmAuthenticate.ERelateMode.User_To_Group, true);
            objFrmAuthenticate.ShowDialog(this);
            if (objFrmAuthenticate.DialogResult == DialogResult.OK)
            {
                objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User;
                objLocalConfig.OItem_Group = objFrmAuthenticate.OItem_Group;
            }
        }

        void objUserControl_Texte_Selection_Changed()
        {
            if (objUserControl_Texte.DataGridViewRowCollection_Selected.Count == 1)
            {

            }
        }


        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTextProcessorModule_Load(object sender, EventArgs e)
        {
            if (objLocalConfig.OItem_User == null || objLocalConfig.OItem_Group == null)
            {
                Environment.Exit(-1);
            }
        }

        private void frmTextProcessorModule_KeyDown(object sender, KeyEventArgs e)
        {
            objUserControl_TextProcessor.LastKeyDown = e;
        }

        private void frmTextProcessorModule_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
