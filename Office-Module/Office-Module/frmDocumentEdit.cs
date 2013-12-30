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

namespace Office_Module
{
    public partial class frmDocumentEdit : Form
    {
        private clsLocalConfig objLocalConfig;

        private clsDataWork_Documents objDataWork_Documents;

        private clsOntologyItem objOItem_Ref;

        private UserControl_Documents objUserControl_Documents;

        public frmDocumentEdit(clsGlobals objGlobals, clsOntologyItem OItem_Ref)
        {
            InitializeComponent();

            objOItem_Ref = OItem_Ref;

            objLocalConfig = new clsLocalConfig(objGlobals);

            Initialize();
        }

        private void Initialize()
        {
            objDataWork_Documents = new clsDataWork_Documents(objLocalConfig);

            var objOItem_Result = objDataWork_Documents.GetData(objOItem_Ref); 

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = objDataWork_Documents.GetData_Documents();
                while (objOItem_Result.GUID == objLocalConfig.Globals.LState_Nothing.GUID) 
                {
                    objOItem_Result = objDataWork_Documents.GetData_Documents();   
                }

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objUserControl_Documents = new UserControl_Documents(objLocalConfig.Globals);
                    objUserControl_Documents.Dock = DockStyle.Fill;
                    toolStripContainer1.ContentPanel.Controls.Add(objUserControl_Documents);
                    objUserControl_Documents.Initialize_Documents(objDataWork_Documents, objOItem_Ref);
                }
                else
                {
                    MessageBox.Show(this, "Die Dokumente konnten nicht ermittelt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
            else
            {
                MessageBox.Show(this,"Die Dokumente konnten nicht ermittelt werden!","Fehler",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            
        }
    }
}
