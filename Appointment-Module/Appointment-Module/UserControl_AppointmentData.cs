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
using Media_Viewer_Module;

namespace Appointment_Module
{
    public partial class UserControl_AppointmentData : UserControl
    {
        private clsAppointment objAppointment;
        private clsDataWork_AppointmentDetail objDataWork_AppointmentDetail;
        private clsTransaction_AppointmentDetail objTransaction_AppointmentDetail;
        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_RemoveContacts;

        private UserControl_OItemList objUserControl_Partner;
        private UserControl_Address objUserControl_AddressDetail;
        private UserControl_OItemList objUserControl_Address;
        private UserControl_OItemList objUserControl_Location;
        private UserControl_OItemList objUserControl_Room;

        private UserControl_SingleViewer objUserControl_PDF;
        private UserControl_SingleViewer objUserControl_Image;
        private UserControl_SingleViewer objUserControl_MediaItem;


        public void ToggleVisibilityContacts(bool visible)
        {
            splitContainer1.Panel1Collapsed = !visible;
        }

        public void ToggleVisibilityResources(bool visible)
        {
            splitContainer1.Panel2Collapsed = !visible;
        }

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

            objUserControl_Address.Selection_Changed += objUserControl_Address_Selection_Changed;
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
                    timer_Resources.Start();

                    Configure_TabPages();
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

        void Configure_TabPages()
        {
            if (tabControl_Appointments.SelectedTab.Name == tabPage_Images.Name)
            {
                if (objAppointment != null)
                {
                    var objOItem_Appointment = new clsOntologyItem
                    {
                        GUID = objAppointment.ID_Appointment,
                        Name = objAppointment.Name_Appointment,
                        GUID_Parent = objLocalConfig.OItem_type_appointment.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    objUserControl_Image.initialize_Image(objOItem_Appointment);
                }
                else
                {
                    objUserControl_Image.clear_Media();
                }

            }
            else if (tabControl_Appointments.SelectedTab.Name == tabPage_MediaItems.Name)
            {
                if (objAppointment != null)
                {
                    var objOItem_Appointment = new clsOntologyItem
                    {
                        GUID = objAppointment.ID_Appointment,
                        Name = objAppointment.Name_Appointment,
                        GUID_Parent = objLocalConfig.OItem_type_appointment.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    objUserControl_MediaItem.initialize_MediaItem(objOItem_Appointment);
                }
                else
                {
                    objUserControl_MediaItem.clear_Media();
                }
            }
            else if (tabControl_Appointments.SelectedTab.Name == tabPage_PDF.Name)
            {
                if (objAppointment != null)
                {
                    var objOItem_Appointment = new clsOntologyItem
                    {
                        GUID = objAppointment.ID_Appointment,
                        Name = objAppointment.Name_Appointment,
                        GUID_Parent = objLocalConfig.OItem_type_appointment.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    objUserControl_PDF.initialize_PDF(objOItem_Appointment);
                }
                else
                {
                    objUserControl_PDF.clear_Media();
                }
            }
        }

        void objUserControl_Address_Selection_Changed()
        {
            if (objUserControl_Address.DataGridViewRowCollection_Selected.Count > 0)
            {
                toolStripButton_AddNamedResource.Enabled = true;
            }
        }


        private void initialize()
        {

            objDBLevel_RemoveContacts = new clsDBLevel(objLocalConfig.Globals);

            objUserControl_PDF = new UserControl_SingleViewer(objLocalConfig.Globals, (int)UserControl_SingleViewer.MediaType.PDF, objLocalConfig.OItem_User);
            objUserControl_PDF.Dock = DockStyle.Fill;
            tabPage_PDF.Controls.Add(objUserControl_PDF);

            objUserControl_Image = new UserControl_SingleViewer(objLocalConfig.Globals, (int)UserControl_SingleViewer.MediaType.Image, objLocalConfig.OItem_User);
            objUserControl_Image.Dock = DockStyle.Fill;
            tabPage_Images.Controls.Add(objUserControl_Image);

            objUserControl_MediaItem = new UserControl_SingleViewer(objLocalConfig.Globals, (int)UserControl_SingleViewer.MediaType.MediaItem, objLocalConfig.OItem_User);
            objUserControl_MediaItem.Dock = DockStyle.Fill;
            tabPage_MediaItems.Controls.Add(objUserControl_MediaItem);

            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
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
            objUserControl_Partner.Selection_Changed += objUserControl_Partner_Selection_Changed;

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

        void objUserControl_Partner_Selection_Changed()
        {
            toolStripButton_AddContractee.Enabled = false;
            toolStripButton_AddContractor.Enabled = false;
            toolStripButton_AddWatcher.Enabled = false;

            if (objUserControl_Partner.DataGridViewRowCollection_Selected.Count > 0)
            {
                toolStripButton_AddContractee.Enabled = true;
                toolStripButton_AddContractor.Enabled = true;
                toolStripButton_AddWatcher.Enabled = true;
            }
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

        private void timer_Resources_Tick(object sender, EventArgs e)
        {
            if (objDataWork_AppointmentDetail.OItem_Result_Resources.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                toolStripProgressBar_Resources.Value = 50;
            }
            else if (objDataWork_AppointmentDetail.OItem_Result_Resources.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                toolStripProgressBar_Resources.Value = 0;
                timer_Resources.Stop();
                dataGridView_Resource.DataSource = objDataWork_AppointmentDetail.OList_Resources;
                dataGridView_Resource.Columns[0].Visible = false;
                dataGridView_Resource.Columns[2].Visible = false;

                toolStripButton_AddResource.Enabled = true;
            }
            else
            {
                toolStripProgressBar_Resources.Value = 0;
                timer_Resources.Stop();
                dataGridView_Resource.DataSource = null;
                MessageBox.Show(this, "Die Resourcen konnten nicht ausgelesen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void toolStripButton_AddNamedResource_Click(object sender, EventArgs e)
        {
            if (objAppointment == null) return;

            var classResource = "";

            var intToDo = objUserControl_Address.DataGridViewRowCollection_Selected.Count;
            var intDone = 0;

            DataGridViewSelectedRowCollection dataGridViewRowCollection;
            if (tabControl1.SelectedTab.Name == tabPage_Address.Name)
            {
                dataGridViewRowCollection = objUserControl_Address.DataGridViewRowCollection_Selected;
                classResource = objLocalConfig.OItem_type_address.Name;
            }
            else if (tabControl1.SelectedTab.Name == tabPage_Ort.Name)
            {
                dataGridViewRowCollection = objUserControl_Location.DataGridViewRowCollection_Selected;
                classResource = objLocalConfig.OItem_type_ort.Name;
            }
            else
            {
                dataGridViewRowCollection = objUserControl_Room.DataGridViewRowCollection_Selected;
                classResource = objLocalConfig.OItem_type_raum.Name;
            }

            foreach (DataGridViewRow gridRow in dataGridViewRowCollection)
            {
                DataRowView row = (DataRowView) gridRow.DataBoundItem;
                objTransaction.ClearItems();
                clsOntologyItem namedResource;

                namedResource = new clsOntologyItem
                {
                    GUID = row["ID_Item"].ToString(),
                    Name = row["Name"].ToString(),
                    GUID_Parent = row["ID_Parent"].ToString(),
                    Type = objLocalConfig.Globals.Type_Object
                };
                
                var objOItem_Appointment = new clsOntologyItem
                {
                    GUID = objAppointment.ID_Appointment,
                    Name = objAppointment.Name_Appointment,
                    GUID_Parent = objLocalConfig.OItem_type_appointment.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                var objRel_Appointment_To_Address = objRelationConfig.Rel_ObjectRelation(objOItem_Appointment,
                    namedResource,
                    objLocalConfig.OItem_relationtype_located_at);

                var objOItem_Result = objTransaction.do_Transaction(objRel_Appointment_To_Address, true);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objDataWork_AppointmentDetail.OList_Resources.Add(new clsResource
                    {
                        ID_Resource = namedResource.GUID,
                        Name_Resource = namedResource.Name,
                        ID_Class_Resource = namedResource.GUID_Parent,
                        Name_Class_Resource = classResource
                    });

                    intDone++;


                }

            }

            if (intToDo > intDone)
            {
                MessageBox.Show(this, "Es konnten nur " + intDone + " von " + intToDo + " Objekte der Klasse " + classResource + " hinzugefügt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView_Resource_SelectionChanged(object sender, EventArgs e)
        {
            objUserControl_AddressDetail.Enabled = false;

            if (dataGridView_Resource.SelectedRows.Count==1)
            {
                var dataGridViewRow = (DataGridViewRow)dataGridView_Resource.SelectedRows[0];
                var objResource = (clsResource)dataGridViewRow.DataBoundItem;

                if (objResource.ID_Class_Resource == objLocalConfig.OItem_type_address.GUID)
                {
                    var objOItem_Address = new clsOntologyItem
                    {
                        GUID = objResource.ID_Resource,
                        Name = objResource.Name_Resource,
                        GUID_Parent = objLocalConfig.OItem_type_address.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    objUserControl_AddressDetail.initialize_Address(null, objOItem_Address);
                    objUserControl_AddressDetail.Enabled = true;
                }
                
            }
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl_Appointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            Configure_TabPages();
        }

        private void toolStripButton_AddContractor_Click(object sender, EventArgs e)
        {
            AddContact(objLocalConfig.OItem_relationtype_belonging_contractor);
            
        }

        private void AddContact(clsOntologyItem OItem_RelationType)
        {
            foreach (DataGridViewRow dgvrSelected in objUserControl_Partner.DataGridViewRowCollection_Selected)
            {
                var drvSelected = (DataRowView)dgvrSelected.DataBoundItem;
                var objPartner = new clsOntologyItem
                {
                    GUID = drvSelected["ID_Item"].ToString(),
                    Name = drvSelected["Name"].ToString(),
                    GUID_Parent = drvSelected["ID_Parent"].ToString(),
                    Type = objLocalConfig.Globals.Type_Object
                };

                var objORel_AppointmentToContractor = objRelationConfig.Rel_ObjectRelation(new clsOntologyItem
                {
                    GUID = objAppointment.ID_Appointment,
                    Name = objAppointment.Name_Appointment,
                    GUID_Parent = objLocalConfig.OItem_type_appointment.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                }, objPartner, OItem_RelationType);

                objTransaction.rollback();
                var objOItem_Result = objTransaction.do_Transaction(objORel_AppointmentToContractor);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objDataWork_AppointmentDetail.OList_Contacts.Add(new clsContact
                    {
                        ID_Contact = objPartner.GUID,
                        Name_Contact = objPartner.Name,
                        ID_Class_Contact = OItem_RelationType.GUID,
                        Name_Class_Contact = OItem_RelationType.Name
                    });

                }
                else
                {
                    MessageBox.Show(this, "Die Partner konnten nicht in die Liste der Kontakte eingefügt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            
        }

        private void toolStripButton_AddContractee_Click(object sender, EventArgs e)
        {
            AddContact(objLocalConfig.OItem_relationtype_belonging_contractee);
        }

        private void toolStripButton_AddWatcher_Click(object sender, EventArgs e)
        {
            AddContact(objLocalConfig.OItem_relationtype_belonging_watchers);
        }

        private void dataGridView_Contacts_SelectionChanged(object sender, EventArgs e)
        {
            
            var objOList_SelectedRows = dataGridView_Contacts.SelectedRows.Cast<DataGridViewRow>().ToList().Select(r => (clsContact)r.DataBoundItem).ToList();

            toolStripButton_RemContractor.Enabled = objOList_SelectedRows.Any(r => r.ID_Class_Contact == objLocalConfig.OItem_relationtype_belonging_contractor.GUID);
            toolStripButton_RemContractee.Enabled = objOList_SelectedRows.Any(r => r.ID_Class_Contact == objLocalConfig.OItem_relationtype_belonging_contractee.GUID);
            toolStripButton_RemWatcher.Enabled = objOList_SelectedRows.Any(r => r.ID_Class_Contact == objLocalConfig.OItem_relationtype_belonging_watchers.GUID);

        }

        private void toolStripButton_RemContractor_Click(object sender, EventArgs e)
        {
            DelContacts(objLocalConfig.OItem_relationtype_belonging_contractor);
        }

        private void DelContacts(clsOntologyItem OItem_RelationType)
        {
            var objOList_Contractors = dataGridView_Contacts.SelectedRows.Cast<DataGridViewRow>().ToList().Select(r => (clsContact)r.DataBoundItem).Where(r => r.ID_Class_Contact == OItem_RelationType.GUID).ToList();

            if (objOList_Contractors.Any())
            {
                var objORelAppointment_To_Partner = objOList_Contractors.Select(c => objRelationConfig.Rel_ObjectRelation(new clsOntologyItem
                {
                    GUID = objAppointment.ID_Appointment,
                    Name = objAppointment.Name_Appointment,
                    GUID_Parent = objLocalConfig.OItem_type_appointment.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                }, new clsOntologyItem
                {
                    GUID = c.ID_Contact,
                    Name = c.Name_Contact,
                    GUID_Parent = objLocalConfig.OItem_type_partner.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                }, OItem_RelationType)).ToList();

                var objOItem_Result = objDBLevel_RemoveContacts.del_ObjectRel(objORelAppointment_To_Partner);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                {
                    MessageBox.Show(this, "Die Partner konnten nicht entfernt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                }

                objDataWork_AppointmentDetail.initialize_AppointmentDetail(objAppointment);

                timer_Contacts.Start();
                timer_Resources.Start();

                Configure_TabPages();
            }
        }

        private void toolStripButton_RemContractee_Click(object sender, EventArgs e)
        {
            DelContacts(objLocalConfig.OItem_relationtype_belonging_contractor);
        }

        private void toolStripButton_RemWatcher_Click(object sender, EventArgs e)
        {
            DelContacts(objLocalConfig.OItem_relationtype_belonging_contractor);
        }
    }
}
