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

namespace Checklist_Module
{
    public partial class frmChecklistModule : Form
    {
        private clsLocalConfig objLocalConfig;
        private UserControl_RefTree objUserControl_RefTree;
        private frmAuthenticate objAuthenticate;
        private clsDataWork_Checklists objDataWork_Checklists;

        private bool boolOpen;

        public frmChecklistModule()
        {
            InitializeComponent();
            Initialize();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Initialize()
        {
            boolOpen = false;
            objLocalConfig = new clsLocalConfig(new clsGlobals());
            objDataWork_Checklists = new clsDataWork_Checklists(objLocalConfig);
            objAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, false, frmAuthenticate.ERelateMode.NoRelate);
            objAuthenticate.ShowDialog(this);
            if (objAuthenticate.DialogResult == DialogResult.OK)
            {
                boolOpen = true;
                objLocalConfig.User = objAuthenticate.OItem_User;
                objDataWork_Checklists.GetData_WorkingLists();
                if (objDataWork_Checklists.OItem_Result_WorkingLists.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objUserControl_RefTree = new UserControl_RefTree(objLocalConfig.Globals);
                    objUserControl_RefTree.Dock = DockStyle.Fill;
                    splitContainer1.Panel1.Controls.Add(objUserControl_RefTree);
                    var objOList_Refs = new List<clsOntologyItem> { objLocalConfig.OItem_class_working_lists };
                    var objOList_RelationTypes = new List<clsOntologyItem> { objLocalConfig.OItem_relationtype_belonging_resource };
                    objUserControl_RefTree.initialize_Tree(objDataWork_Checklists.OList_WorkingLists, 
                        objDataWork_Checklists.OList_WorkingLists, 
                        objOList_Refs, 
                        objOList_RelationTypes, 
                        null);
                }
                else
                {
                    MessageBox.Show(this, "Die notwendigen Daten konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }
             
            
        }

        private void frmChecklistModule_Load(object sender, EventArgs e)
        {
            if (!boolOpen)
            {
                Environment.Exit(-1);
            }
        }
    }
}
