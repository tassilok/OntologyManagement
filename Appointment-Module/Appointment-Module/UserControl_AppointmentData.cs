using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Partner_Module;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Appointment_Module
{
    public partial class UserControl_AppointmentData : UserControl
    {
        private clsAppointment objAppointment;
        private clsDataWork_AppointmentDetail objDataWork_AppointmentDetail;
        private clsTransaction_AppointmentDetail objTransaction_AppointmentDetail;
        private clsLocalConfig objLocalConfig;

        private UserControl_OItemList objUserControl_Partner;
        private UserControl_Address objUserControl_AddressDetail;
        private UserControl_OItemList objUserControl_Address;
        private UserControl_OItemList objUserControl_Location;
        private UserControl_OItemList objUserControl_Room;


        public UserControl_AppointmentData(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            
            initialize();
        }

        public void initialize_Appointment(clsAppointment Appointment)
        {
            clear_Controls();
            objAppointment = Appointment;


            if (objAppointment != null)
            {
                comboBox_User.SelectedValue = objAppointment.OItem_User.GUID;
                comboBox_User.Enabled = true;
                var OItem_Result = objLocalConfig.Globals.LState_Success;
                if (objAppointment.Val_Ende == null)
                {
                    OItem_Result =  objTransaction_AppointmentDetail.SaveEnde(new clsOntologyItem() { GUID = objAppointment.ID_Appointment, 
                                                                                                          Name = objAppointment.Name_Appointment, 
                                                                                                          GUID_Parent = objLocalConfig.OItem_type_appointment.GUID 
                                                                                                        }, 
                                                                                                        objAppointment.Val_Start, 
                                                                                                        true);
                    if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objAppointment.Val_Ende = objAppointment.Val_Start;
                    }
                }
                if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objUserControl_Address.Enabled = true;
                    objUserControl_Location.Enabled = true;
                    objUserControl_Partner.Enabled = true;
                    objUserControl_Room.Enabled = true;

                    dataGridView_Contacts.DataSource = objDataWork_AppointmentDetail.OList_Contacts;
                    dateTimePicker_Start.Value = (DateTime)objAppointment.Val_Start;
                    dateTimePicker_Start.Enabled = true;
                    dateTimePicker_Ende.Value = (DateTime)objAppointment.Val_Ende;
                    dateTimePicker_Ende.Enabled = true;
                    objDataWork_AppointmentDetail.initialize_AppointmentDetail(objAppointment);
                    timer_Contacts.Start();
                }
                else
                {
                    clear_Controls();
                    MessageBox.Show("Die Daten des Termins konnten nicht ermittelt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                clear_Controls();
            }
            
        }


        private void initialize()
        {
            objDataWork_AppointmentDetail = new clsDataWork_AppointmentDetail(objLocalConfig);
            objUserControl_Address = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_Address.initialize(new clsOntologyItem()
            {
                GUID_Parent = objLocalConfig.OItem_type_address.GUID,
                Type = objLocalConfig.Globals.Type_Object
            });
            objUserControl_Address.Dock = DockStyle.Fill;
            tabPage_Address.Controls.Add(objUserControl_Address);

            objUserControl_Location = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_Location.initialize(new clsOntologyItem()
            {
                GUID_Parent = objLocalConfig.OItem_type_ort.GUID,
                Type = objLocalConfig.Globals.Type_Object
            });
            objUserControl_Location.Dock = DockStyle.Fill;
            tabPage_Ort.Controls.Add(objUserControl_Location);

            objUserControl_Room = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_Room.initialize(new clsOntologyItem()
            {
                GUID_Parent = objLocalConfig.OItem_type_raum.GUID,
                Type = objLocalConfig.Globals.Type_Object
            });
            objUserControl_Room.Dock = DockStyle.Fill;
            tabPage_Raum.Controls.Add(objUserControl_Room);

            objUserControl_Partner = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_Partner.initialize(new clsOntologyItem()
            {
                GUID_Parent = objLocalConfig.OItem_type_partner.GUID,
                Type = objLocalConfig.Globals.Type_Object
            });
            objUserControl_Partner.Dock = DockStyle.Fill;
            splitContainer_Contacts.Panel2.Controls.Add(objUserControl_Partner);

            objUserControl_AddressDetail = new UserControl_Address(objLocalConfig.Globals);
            objUserControl_AddressDetail.Dock = DockStyle.Fill;
            splitContainer_Resource.Panel2.Controls.Add(objUserControl_AddressDetail);

            
            comboBox_User.Enabled = false;
            comboBox_User.DataSource = objDataWork_AppointmentDetail.OList_Users;
            comboBox_User.ValueMember = "GUID";
            comboBox_User.DisplayMember = "Name";
            comboBox_User.Enabled = true;

            objTransaction_AppointmentDetail = new clsTransaction_AppointmentDetail(objLocalConfig);

            clear_Controls();   
        }

        public void clear_Controls()
        {
            timer_Contacts.Stop();

            comboBox_User.Enabled = false;
            dateTimePicker_Start.Enabled = false;
            dateTimePicker_Ende.Enabled = false;
            toolStripButton_AddContractee.Enabled = false;
            toolStripButton_AddContractor.Enabled = false;
            toolStripButton_AddNamedResource.Enabled = false;
            toolStripButton_AddResource.Enabled = false;
            toolStripButton_AddWatcher.Enabled = false;
            toolStripButton_RemContractee.Enabled = false;
            toolStripButton_RemContractor.Enabled = false;
            toolStripButton_RemResource.Enabled = false;
            toolStripButton_RemWatcher.Enabled = false;

            objUserControl_Address.Enabled = false;
            objUserControl_AddressDetail.Enabled = false;
            objUserControl_AddressDetail.clear_Controls();
            objUserControl_Location.Enabled = false;
            objUserControl_Partner.Enabled = false;
            objUserControl_Room.Enabled = false;

            toolStripProgressBar_Contacts.Value = 0;
        }

        private void timer_Contacts_Tick(object sender, EventArgs e)
        {
            if (objDataWork_AppointmentDetail.OItem_Result_Contractees.GUID == objLocalConfig.Globals.LState_Nothing.GUID ||
                objDataWork_AppointmentDetail.OItem_Result_Contractors.GUID == objLocalConfig.Globals.LState_Nothing.GUID ||
                objDataWork_AppointmentDetail.OItem_Result_Watchers.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                var ValueContractee = 0;
                var ValueContrator = 0;
                var ValueWatcher = 0;

                if (objDataWork_AppointmentDetail.OItem_Result_Contractees.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    dataGridView_Contacts.DataSource = objDataWork_AppointmentDetail.OList_Contacts;
                    dataGridView_Contacts.Columns[0].Visible = false;
                    dataGridView_Contacts.Columns[2].Visible = false;
                    ValueContractee = 3;
                }

                if (objDataWork_AppointmentDetail.OItem_Result_Contractors.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    dataGridView_Contacts.DataSource = objDataWork_AppointmentDetail.OList_Contacts;
                    dataGridView_Contacts.Columns[0].Visible = false;
                    dataGridView_Contacts.Columns[2].Visible = false;
                    ValueContrator = 3;
                }

                if (objDataWork_AppointmentDetail.OItem_Result_Watchers.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    dataGridView_Contacts.DataSource = objDataWork_AppointmentDetail.OList_Contacts;
                    dataGridView_Contacts.Columns[0].Visible = false;
                    dataGridView_Contacts.Columns[2].Visible = false;
                    ValueWatcher = 3;
                }

                toolStripProgressBar_Contacts.Value = ValueContractee + ValueContrator + ValueWatcher + 1;


            }
            else if (objDataWork_AppointmentDetail.OItem_Result_Contractees.GUID == objLocalConfig.Globals.LState_Error.GUID ||
                     objDataWork_AppointmentDetail.OItem_Result_Contractors.GUID == objLocalConfig.Globals.LState_Error.GUID ||
                     objDataWork_AppointmentDetail.OItem_Result_Watchers.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                clear_Controls();
                MessageBox.Show("Die Daten des Termins konnten nicht ermittelt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                if (objDataWork_AppointmentDetail.OItem_Result_Contractees.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    dataGridView_Contacts.DataSource = objDataWork_AppointmentDetail.OList_Contacts;
                    dataGridView_Contacts.Columns[0].Visible = false;
                    dataGridView_Contacts.Columns[2].Visible = false;

                }

                if (objDataWork_AppointmentDetail.OItem_Result_Contractors.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    dataGridView_Contacts.DataSource = objDataWork_AppointmentDetail.OList_Contacts;
                    dataGridView_Contacts.Columns[0].Visible = false;
                    dataGridView_Contacts.Columns[2].Visible = false;

                }

                if (objDataWork_AppointmentDetail.OItem_Result_Watchers.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    dataGridView_Contacts.DataSource = objDataWork_AppointmentDetail.OList_Contacts;
                    dataGridView_Contacts.Columns[0].Visible = false;
                    dataGridView_Contacts.Columns[2].Visible = false;

                }

                toolStripProgressBar_Contacts.Value = 0;
            }
        }

        private void dateTimePicker_Start_ValueChanged(object sender, EventArgs e)
        {
            SaveStart();
            
            
            
        }

        private void SaveStart(DateTime? dateTime_Set = null)
        {
            if (dateTimePicker_Start.Enabled)
            {
                var boolChange = true;
                var boolEndToStart = false;
                if (dateTime_Set == null)
                {
                    dateTime_Set = dateTimePicker_Start.Value;
                }
                if (dateTime_Set > dateTimePicker_Ende.Value)
                {
                    if (MessageBox.Show("Der Startdatum würde das Enddatum auf einen späteren Zeitpunkt setzen. Soll dies geschehen?", "Werte", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        boolChange = false;
                        boolEndToStart = true;
                    }
                }

                if (boolChange)
                {
                    var objOItem_Appointment = new clsOntologyItem()
                    {
                        GUID = objAppointment.ID_Appointment,
                        Name = objAppointment.Name_Appointment,
                        GUID_Parent = objLocalConfig.OItem_type_appointment.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    var objOItem_Result = objTransaction_AppointmentDetail.SaveStart(objOItem_Appointment, dateTime_Set);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (boolEndToStart)
                        {
                            SaveEnde(dateTime_Set);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Das Startdatum konnte nicht gesetzt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dateTimePicker_Start.Enabled = false;
                        dateTimePicker_Start.Value = (DateTime)objAppointment.Val_Start;
                        dateTimePicker_Start.Enabled = true;
                    }


                }
            }
        }

        private void SaveEnde(DateTime? dateTime_Set = null)
        {
            if (dateTimePicker_Ende.Enabled)
            {
                var boolChange = true;
                var boolStartToEnd = false;
                if (dateTime_Set == null)
                {
                    dateTime_Set = dateTimePicker_Ende.Value;
                }
                if (dateTime_Set < dateTimePicker_Start.Value)
                {
                    if (MessageBox.Show("Der Enddatum würde das Startdatum auf einen früheren Zeitpunkt setzen. Soll dies geschehen?", "Werte", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        boolChange = false;
                        boolStartToEnd = true;
                    }
                }

                if (boolChange)
                {
                    var objOItem_Appointment = new clsOntologyItem()
                    {
                        GUID = objAppointment.ID_Appointment,
                        Name = objAppointment.Name_Appointment,
                        GUID_Parent = objLocalConfig.OItem_type_appointment.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    var objOItem_Result = objTransaction_AppointmentDetail.SaveEnde(objOItem_Appointment, dateTime_Set);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (boolStartToEnd)
                        {
                            SaveStart(dateTime_Set);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Das Enddatum konnte nicht gesetzt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dateTimePicker_Ende.Enabled = false;
                        dateTimePicker_Ende.Value = (DateTime)objAppointment.Val_Ende;
                        dateTimePicker_Ende.Enabled = true;
                    }


                }
            }
        }

        private void dateTimePicker_Ende_ValueChanged(object sender, EventArgs e)
        {
            SaveEnde();
        }
    }
}
