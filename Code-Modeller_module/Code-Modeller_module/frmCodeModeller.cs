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

namespace Code_Modeller_module
{
    public partial class frmCodeModeller : Form
    {
        private clsLocalConfig objLocalConfig;

        private UserControl_CodeModell objUserControl_CodeMdell;

        private clsDataWork_Development objDataWork_Development;

        private clsOntologyItem objOItem_Result;

        private frmAuthenticate objFrmAuthenticate;

        public frmCodeModeller()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {

            objDataWork_Development = new clsDataWork_Development(objLocalConfig);
            objOItem_Result = objDataWork_Development.GetData_Development();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = objDataWork_Development.GetData_Development();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, true, frmAuthenticate.ERelateMode.User_To_Group, true);
                    objFrmAuthenticate.ShowDialog(this);
                    if (objFrmAuthenticate.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User;
                        objLocalConfig.OItem_Group = objFrmAuthenticate.OItem_Group;
                        objUserControl_CodeMdell = new UserControl_CodeModell(objLocalConfig);
                        objUserControl_CodeMdell.Dock = DockStyle.Fill;
                        splitContainer1.Panel2.Controls.Add(objUserControl_CodeMdell);

                        FillTree();
                    }
                }
            }
            
        }

        private void FillTree()
        {
            var objOList_Developments = (from objDev in objDataWork_Development.OList_Development
                                         join objDevTree in objDataWork_Development.OList_DevTree on objDev.GUID equals objDevTree.ID_Object into objDevTrees
                                         from objDevTree in objDevTrees.DefaultIfEmpty()
                                         where objDevTree == null
                                         select objDev);

        }


        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCodeModeller_Load(object sender, EventArgs e)
        {
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                MessageBox.Show(this, "Beim Ermitteln der Daten ist ein Fehler aufgetreten!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                if (objLocalConfig.OItem_User == null || objLocalConfig.OItem_Group == null)
                {
                    this.Close();
                }
            }
        }
    }
}
