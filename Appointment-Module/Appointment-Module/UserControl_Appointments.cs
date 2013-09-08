using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Structure_Module;

namespace Appointment_Module
{
    public delegate void SelectedNode(DataGridViewSelectedRowCollection DGVR_SelectedRows);

    public partial class UserControl_Appointments : UserControl
    {
        clsLocalConfig objLocalConfig;
        SortableBindingList<clsAppointment> OList_Appointments;
        public SelectedNode selectedNode;

        public UserControl_Appointments(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            initialize();
        }

        private void initialize()
        {
            OList_Appointments = objLocalConfig.DataWork_Appointments.GetAppointments();
            while (OList_Appointments.First().OItem_Result.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                
                OList_Appointments = objLocalConfig.DataWork_Appointments.GetAppointments();
            }
            if (OList_Appointments.First().OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                configure_DataGridView();
            }
            else
            {
                MessageBox.Show("Die Termine konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void configure_DataGridView()
        {


            if (OList_Appointments != null)
            {
                if (toolStripButton_Active.Checked)
                {
                    dataGridView_Apointments.DataSource = new SortableBindingList<clsAppointment>(OList_Appointments.Where(Filter => Filter.Val_Filter > DateTime.Now).ToList());
                    dataGridView_Apointments.Sort(dataGridView_Apointments.Columns["Val_Start"], ListSortDirection.Ascending);

                }
                else
                {
                    dataGridView_Apointments.DataSource = OList_Appointments;
                    dataGridView_Apointments.Sort(dataGridView_Apointments.Columns["Val_Start"], ListSortDirection.Ascending);
                }

                dataGridView_Apointments.Columns[0].Visible = false;
                dataGridView_Apointments.Columns[2].Visible = false;
                dataGridView_Apointments.Columns[3].Visible = false;
                dataGridView_Apointments.Columns[6].Visible = false;
                dataGridView_Apointments.Columns[7].Visible = false;
                dataGridView_Apointments.Columns[8].Visible = false;
                
            }

            toolStripLabel_Count.Text = dataGridView_Apointments.RowCount.ToString();
        }

        private void toolStripButton_Active_CheckStateChanged(object sender, EventArgs e)
        {
            configure_DataGridView();
        }

        private void dataGridView_Apointments_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_Apointments.SelectedRows.Count > 0)
            {
                selectedNode(dataGridView_Apointments.SelectedRows);
            }
            else
            {
                selectedNode(null);
            }
        }
    }
}
