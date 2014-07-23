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

        private clsDBLevel objDBLevel_ItemType;

        private clsDataWork_Documents objDataWork_Documents;

        private clsOntologyItem objOItem_Ref;

        private UserControl_Documents objUserControl_Documents;

        public frmDocumentEdit(clsGlobals objGlobals, clsOntologyItem OItem_Ref)
        {
            InitializeComponent();

            objOItem_Ref = OItem_Ref;

            objLocalConfig = new clsLocalConfig(objGlobals);
            objDBLevel_ItemType = new clsDBLevel(objLocalConfig.Globals);

            Initialize();
        }

        public void Initialize(clsOntologyItem OItem_Ref = null)
        {
            if (OItem_Ref != null)
            {
                objOItem_Ref = OItem_Ref;
                
            }

            if (objOItem_Ref.Type == objLocalConfig.Globals.Type_Object)
            {
                var oItem_Class = objDBLevel_ItemType.GetOItem(objOItem_Ref.GUID_Parent, objLocalConfig.Globals.Type_Class);
                this.Text = oItem_Class.Name + "\\" + objOItem_Ref.Name;
            }
            else
            {
                this.Text = objOItem_Ref.Name;
            }

            if (objDataWork_Documents == null)
            {
                objDataWork_Documents = new clsDataWork_Documents(objLocalConfig);
            }
            
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
                    if (objUserControl_Documents == null)
                    {
                        objUserControl_Documents = new UserControl_Documents(objLocalConfig.Globals);
                        objUserControl_Documents.Dock = DockStyle.Fill;
                        toolStripContainer1.ContentPanel.Controls.Add(objUserControl_Documents);
                    }
                    
                    
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
