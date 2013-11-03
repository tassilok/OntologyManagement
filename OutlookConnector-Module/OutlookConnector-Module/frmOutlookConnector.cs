using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using Security_Module;

namespace OutlookConnector_Module
{
    public partial class frmOutlookConnector : Form
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_OutlookConnector objDataWork;

        private frmAuthenticate objFrmAuthenticate;
        private UserControl_OutlookItemList objUserControl_OutlookItemList;

        public frmOutlookConnector()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());
            Initialize();
        }

        private void Initialize()
        {
            objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals,true,false,frmAuthenticate.ERelateMode.NoRelate);
            objFrmAuthenticate.ShowDialog(this);
            if (objFrmAuthenticate.DialogResult== System.Windows.Forms.DialogResult.OK)
            {
                objLocalConfig.User = objFrmAuthenticate.OItem_User;
                objDataWork = new clsDataWork_OutlookConnector(objLocalConfig);

                objUserControl_OutlookItemList = new UserControl_OutlookItemList(objLocalConfig, objDataWork);
                objUserControl_OutlookItemList.Dock = DockStyle.Fill;
                splitContainer1.Panel1.Controls.Add(objUserControl_OutlookItemList);
                //SaveOldItemsToIndex();
            }
            else
            {
                Environment.Exit(0);
            }

            
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}



