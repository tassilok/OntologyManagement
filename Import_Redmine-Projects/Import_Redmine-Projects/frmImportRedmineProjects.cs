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

namespace Import_Redmine_Projects
{
    public partial class frmImportRedmineProjects : Form
    {
        private clsLocalConfig objLocalConfig;

        private frmAuthenticate objFrmAuthenticate;
        private clsDataWork_BaseConfig objDataWork_BaseConfig;
        private frm_ObjectEdit frmObjectEdit;
        private clsRedmineToOntology objRedmineToOntology;


        public frmImportRedmineProjects()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(new clsGlobals());
            Initialize();
        }

        private void Initialize()
        {
            objDataWork_BaseConfig = new clsDataWork_BaseConfig(objLocalConfig);
            
            objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals,true,true,frmAuthenticate.ERelateMode.User_To_Group);
            objFrmAuthenticate.ShowDialog(this);
            if (objFrmAuthenticate.DialogResult == DialogResult.OK)
            {
                
                objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User;
                objLocalConfig.OItem_Group = objFrmAuthenticate.OItem_Group;

                var objOItem_Result = objDataWork_BaseConfig.GetData_BaseConfig(objLocalConfig.OItem_User,
                                                                                objLocalConfig.OItem_Group);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    
                }
                else
                {
                    var dialogResult = MessageBox.Show(this, "Die Basiskonfiguration konnte nicht ermittelt werden! Soll sie geöffnet werden!",
                                                       "Fehler!", MessageBoxButtons.YesNoCancel,
                                                       MessageBoxIcon.Exclamation);

                    if (dialogResult == DialogResult.Yes)
                    {
                        var oList_Objects = new List<clsOntologyItem> {objLocalConfig.OItem_BaseConfig};
                        frmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals,oList_Objects,0,objLocalConfig.Globals.Type_Object,null);
                        frmObjectEdit.ShowDialog(this);

                        Initialize();
                    }
                    else
                    {
                        Environment.Exit(-1);
                    }
                }


            }
        }

        private void frmImportRedmineProjects_Load(object sender, EventArgs e)
        {
            if (objLocalConfig.OItem_Group == null || objLocalConfig.OItem_User == null) Environment.Exit(-1);
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton__Click(object sender, EventArgs e)
        {
            objRedmineToOntology = new clsRedmineToOntology(objLocalConfig, objDataWork_BaseConfig);
            var objOItem_Result = objRedmineToOntology.SyncProjectsFromRedmineToOntology();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                MessageBox.Show(this, "Die Projects wurden gesynct!", "Erfolg!",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "Die Projects konnten nicht gesynct werden!", "Fehler!",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
