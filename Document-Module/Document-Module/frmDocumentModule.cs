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

namespace Document_Module
{
    public partial class frmDocumentModule : Form
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_Document objDataWork_Document;
        private UserControl_Documents objUserControl_Documents;

        public frmDocumentModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {
            objDataWork_Document = new clsDataWork_Document(objLocalConfig);
            var objOItem_Result = objDataWork_Document.GetData_Documents();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objUserControl_Documents = new UserControl_Documents(objLocalConfig, objDataWork_Document);
                objUserControl_Documents.Dock = DockStyle.Fill;

                splitContainer1.Panel1.Controls.Add(objUserControl_Documents);
            }
            else
            {
                throw new Exception("Data cannot be determined");
            }
            
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
