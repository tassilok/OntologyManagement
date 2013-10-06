using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Structure_Module;
using Ontolog_Module;
using OntologyClasses.BaseClasses;

namespace Appointment_Module
{
    public delegate void SelectedNode(DataGridViewSelectedRowCollection DGVR_SelectedRows);

    public partial class UserControl_Appointments : UserControl
    {
        private clsLocalConfig objLocalConfig;
        private SortableBindingList<clsAppointment> OList_Appointments;
        private frm_Name objFrmName;
        private clsTransaction_AppointmentDetail objTransaction_AppointmentDetail;
        public SelectedNode selectedNode;

        public UserControl_Appointments(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            initialize();
        }

        private void initialize()
        {
            objTransaction_AppointmentDetail = new clsTransaction_AppointmentDetail(objLocalConfig);
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

                    dataGridView_Apointments.DataSource = new SortableBindingList<clsAppointment>(OList_Appointments.Where(Filter => Filter.Val_Filter > DateTime.Now.Date).ToList());
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

        private void ContextMenuStrip_Appointment_Opening(object sender, CancelEventArgs e)
        {
            RemoveToolStripMenuItem.Enabled = false;
            if (dataGridView_Apointments.SelectedRows.Count > 0)
            {
                RemoveToolStripMenuItem.Enabled = true;
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objFrmName = new frm_Name("Neuer Termin", objLocalConfig.Globals);
            objFrmName.ShowDialog(this);
            if (objFrmName.DialogResult == DialogResult.OK)
            {
                if (objFrmName.Value1.Length > 0)
                {
                    var OItem_Appointment = new clsOntologyItem()
                    {
                        GUID = objLocalConfig.Globals.NewGUID,
                        Name = objFrmName.Value1,
                        GUID_Parent = objLocalConfig.OItem_type_appointment.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    var valStart = DateTime.Now;

                    var OItem_Result = objTransaction_AppointmentDetail.SaveFullAppointment(OItem_Appointment, valStart, valStart, objLocalConfig.OItem_User);
                    if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        OList_Appointments.Add(new clsAppointment()
                        {
                            ID_Appointment = OItem_Appointment.GUID,
                            Name_Appointment = OItem_Appointment.Name,
                            OItem_User = objLocalConfig.OItem_User,
                            Val_Start = valStart,
                            Val_Ende = valStart,
                            Val_Filter = valStart
                        });

                        configure_DataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Der Termin konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Geben Sie bitte eine Bezeichnung für den Termin ein!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView_Apointments.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Sollen die Termine wirklich gelöscht werden?", "Löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var intTodo = dataGridView_Apointments.SelectedRows.Count;
                    var intDone = 0;
                    foreach (DataGridViewRow objDGVR_Selected in dataGridView_Apointments.SelectedRows)
                    {
                        var OItem_Appointment = new clsOntologyItem()
                        {
                            GUID = objDGVR_Selected.Cells["ID_Appointment"].Value.ToString(),
                            Name = objDGVR_Selected.Cells["Name_Appointment"].Value.ToString(),
                            GUID_Parent = objLocalConfig.OItem_type_appointment.GUID,
                            Type = objLocalConfig.Globals.Type_Object
                        };

                        var OItem_Result = objTransaction_AppointmentDetail.DelFullAppointment(OItem_Appointment);
                        if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            intDone++;
                        }
                        
                    }

                    if (intDone < intTodo)
                    {
                        MessageBox.Show("Es konnten nur " + intDone.ToString() + " Termine von " + intTodo.ToString() + " gelöscht werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    configure_DataGridView();
                }
            }
        }
    }
}
