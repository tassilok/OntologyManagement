﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontology_Module;
using Security_Module;
using OntologyClasses.BaseClasses;

namespace Appointment_Module
{
    public partial class frmAppointmentModule : Form
    {
        private clsLocalConfig objLocalConfig;
        private frmAuthenticate objFrmAuthenticate;
        private UserControl_Appointments objUserControl_Appointments;

        private SplashScreen_OntologyModule SplashScreen;
        private AboutBox_OntologyItem AboutBox;

        private UserControl_AppointmentData objUserControl_AppointmentData;

        public frmAppointmentModule()
        {
            InitializeComponent();
             Application.DoEvents();
             SplashScreen = new SplashScreen_OntologyModule();
             SplashScreen.Show();
             SplashScreen.Refresh();

            objLocalConfig = new clsLocalConfig(new clsGlobals());
            objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, 
                                                     true, 
                                                     false, 
                                                     frmAuthenticate.ERelateMode.NoRelate,true);

            objFrmAuthenticate.ShowDialog(this);
            if (objFrmAuthenticate.DialogResult == DialogResult.OK)
            {
                objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User;
                initialize();
            }
            else
            {
                objLocalConfig.OItem_User = null;
            }

        }

        private void frmAppointmentModule_Load(object sender, EventArgs e)
        {
            if (SplashScreen != null)
            {
                SplashScreen.Close();
            }
            if (objLocalConfig.OItem_User == null)
            {
                MessageBox.Show("Sie müssen einen User auswählen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void initialize()
        {
            objLocalConfig.DataWork_Appointments = new clsDataWork_Appointments(objLocalConfig);
            objLocalConfig.DataWork_Appointments.GetData();
            objUserControl_Appointments = new UserControl_Appointments(objLocalConfig);
            objUserControl_Appointments.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(objUserControl_Appointments);

            objUserControl_AppointmentData = new UserControl_AppointmentData(objLocalConfig);
            objUserControl_AppointmentData.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(objUserControl_AppointmentData);

            objUserControl_Appointments.selectedNode += objUserControl_Appointments_selectedNode;
        }

        private void objUserControl_Appointments_selectedNode(DataGridViewSelectedRowCollection DGVR_SelectedRows)
        {
            objUserControl_AppointmentData.clear_Controls();
            if (DGVR_SelectedRows != null)
            {
                if (DGVR_SelectedRows.Count == 1)
                {
                    var objAppointment = new clsAppointment() { ID_Appointment = DGVR_SelectedRows[0].Cells["ID_Appointment"].Value.ToString(),
                                                                Name_Appointment = DGVR_SelectedRows[0].Cells["Name_Appointment"].Value.ToString(),
                                                                OItem_User = (clsOntologyItem) DGVR_SelectedRows[0].Cells["OItem_User"].Value,
                                                                ID_Attribute_Start = (DGVR_SelectedRows[0].Cells["ID_Attribute_Start"].Value) != null ? DGVR_SelectedRows[0].Cells["ID_Attribute_Start"].Value.ToString() : null,
                                                                ID_Attribute_Ende = (DGVR_SelectedRows[0].Cells["ID_Attribute_Ende"].Value != null ? DGVR_SelectedRows[0].Cells["ID_Attribute_Ende"].Value.ToString() : null),
                                                                Val_Start = (DateTime?) DGVR_SelectedRows[0].Cells["Val_Start"].Value,
                                                                Val_Ende = (DGVR_SelectedRows[0].Cells["Val_Ende"].Value != null ? (DateTime?) DGVR_SelectedRows[0].Cells["Val_Ende"].Value : null)};

                    objUserControl_AppointmentData.initialize_Appointment(objAppointment);
                    
                }
                
            }
            
            
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox = new AboutBox_OntologyItem();
            AboutBox.ShowDialog(this);
        }

        private void toolStripButton_Contacts_CheckStateChanged(object sender, EventArgs e)
        {
            if (toolStripButton_Contacts.Checked)
            {
                objUserControl_AppointmentData.ToggleVisibilityContacts(true);
                splitContainer1.Panel2Collapsed = false;
            }
            else
            {
                objUserControl_AppointmentData.ToggleVisibilityContacts(false);
                if (!toolStripButton_Resources.Checked)
                {
                    splitContainer1.Panel2Collapsed = true;
                }
            }
        }

        private void toolStripButton_Resources_CheckStateChanged(object sender, EventArgs e)
        {
            if (toolStripButton_Resources.Checked)
            {
                objUserControl_AppointmentData.ToggleVisibilityResources(true);
                splitContainer1.Panel2Collapsed = false;
            }
            else
            {
                objUserControl_AppointmentData.ToggleVisibilityResources(false);
                if (!toolStripButton_Contacts.Checked)
                {
                    splitContainer1.Panel2Collapsed = true;
                }
            }
        }
    }
}
