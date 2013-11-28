using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Change_Module
{
    public partial class UserControl_History : UserControl
    {
        private clsLocalConfig objLocalConfig;
        private clsOntologyItem objOItem_Selected;
        private clsDataWork_History objDataWork_History;

        public UserControl_History(clsLocalConfig LocalConfig )
        {
            objLocalConfig = LocalConfig;

            InitializeComponent();

            toggleEnable(false);

        }

        public void initialize(clsOntologyItem OItem_Selected)
        {
            
            objDataWork_History = new clsDataWork_History(objLocalConfig);

            objOItem_Selected = OItem_Selected;

            refreshItems();
            
        }

        public void refreshItems()
        {
            clsOntologyItem objOItem_Result;
            toolStripProgressBar_History.Value = 0;
            timer_History.Stop();

            toggleEnable(false);

            objOItem_Result = objDataWork_History.GetData(objOItem_Selected);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                timer_History.Start();
            }
            else
            {
                MessageBox.Show("Die Historie kann nicht ermittelt werden!", "Historie", MessageBoxButtons.OK);
            }
        }

        private void timer_History_Tick(object sender, EventArgs e)
        {
            if (objDataWork_History.HasFinished().GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                bindingSource_History.DataSource = objDataWork_History.ChngView_LogEntriesOfProcessLog;
                dataGridView_History.DataSource = bindingSource_History;
                toggleEnable(true);
                toolStripProgressBar_History.Value = 0;
                timer_History.Stop();

                dataGridView_History.Columns[0].Visible = false;
                dataGridView_History.Columns[1].Visible = false;
                dataGridView_History.Columns[2].Visible = false;
                dataGridView_History.Columns[4].Visible = false;
                dataGridView_History.Columns[6].Visible = false;
                bindingSource_History.Sort = "DateTimeStamp";
            }
            else if (objDataWork_History.HasFinished().GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                MessageBox.Show("Die Historie kann nicht ermittelt werden!", "Historie", MessageBoxButtons.OK);
                toolStripProgressBar_History.Value = 0;
            }
            else
            {
                toolStripProgressBar_History.Value = 50;
            }

        }

        private void toggleEnable(Boolean boolEnable)
        {
            
            dataGridView_History.Enabled = boolEnable;
            bindingNavigator_History.Enabled = boolEnable;
            bindingSource_History.Sort="";
            if (!boolEnable)
            {
                
                bindingSource_History.DataSource = null;
                dataGridView_History.DataSource = null;
            }
        }


    }
}
