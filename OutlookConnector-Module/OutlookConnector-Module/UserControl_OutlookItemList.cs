using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Structure_Module;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace OutlookConnector_Module
{
    public delegate void SelectedRows ();

    public partial class UserControl_OutlookItemList : UserControl
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_OutlookItems objDataWork_OutlookItems;
        private clsDataWork_OutlookConnector objDataWork_OutlookConnector;
        private List<clsFilter> Filters = new List<clsFilter>();
        private clsAppDBLevel objAppDBLevel;
        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;
        private clsOutlookConnector objOutlookConnector;
        private frm_ObjectEdit objFrmObjectEdit;

        public event SelectedRows selectedRows;

        public void ToogleEnableEdit(bool boolEnable)
        {
            editToolStripMenuItem.Enabled = boolEnable;
        }

        public DataGridViewSelectedRowCollection dataGridViewSelectedRowCollection
        {
            get { return dataGridView_OutlookItems.SelectedRows; }
        }

        public UserControl_OutlookItemList(clsLocalConfig LocalConfig, clsDataWork_OutlookConnector DataWork_OutlookConnector)
        {
            InitializeComponent();
            objDataWork_OutlookConnector = DataWork_OutlookConnector;
            objLocalConfig = LocalConfig;
            Initialize();
        }

        public void RefreshMailItems(List<clsAppDocuments> MailItemsNew)
        {

            var objRefreshList = (from objMailItemNew in MailItemsNew
                                  join objMailItemOld in objDataWork_OutlookItems.MailItems on
                                       new
                                       {
                                           SenderEmail = objMailItemNew.Dict["SenderEmailAddress"] != null ? objMailItemNew.Dict["SenderEmailAddress"].ToString() : null,
                                           SenderName = objMailItemNew.Dict["SenderName"] != null ? objMailItemNew.Dict["SenderName"].ToString() : null,
                                           Subject = objMailItemNew.Dict["Subject"] != null ? objMailItemNew.Dict["Subject"].ToString() : null,
                                           To = objMailItemNew.Dict["To"] != null ? objMailItemNew.Dict["To"].ToString() : null,
                                           CreationDate = objMailItemNew.Dict["CreationDate"] != null ? objMailItemNew.Dict["CreationDate"].ToString() : null
                                       }
                                  equals
                                       new
                                       {
                                           SenderEmail = objMailItemOld.SenderEmail,
                                           SenderName = objMailItemOld.SenderName,
                                           Subject = objMailItemOld.Subject,
                                           To = objMailItemOld.To,
                                           CreationDate = objMailItemOld.CreationDate.ToString()
                                       } into MailItemsOld
                                  from objMailItemOld in MailItemsOld.DefaultIfEmpty()
                                  where objMailItemOld == null
                                  select objMailItemNew).ToList();

            if (objRefreshList.Any())
            {
               var objOItem_Result =  objAppDBLevel.Save_Documents(objRefreshList);
               if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
               {
                   Initialize();
               }
               else
               {
                   MessageBox.Show(this, "Die Mails konnten nicht importiert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }
            
        }

        private void Initialize()
        {
            objAppDBLevel = new clsAppDBLevel(objLocalConfig.Globals, objDataWork_OutlookConnector.Ontology, objLocalConfig.User);
            objDataWork_OutlookItems = new clsDataWork_OutlookItems(objLocalConfig, objDataWork_OutlookConnector);
            objDataWork_OutlookItems.GetData_Documents();
            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
            objOutlookConnector = new clsOutlookConnector(objLocalConfig.Globals);

            dataGridView_OutlookItems.DataSource = null;

            if (objDataWork_OutlookItems.OItem_Result_OutlookItems.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                ConfigureGrid();
            }
            else
            {
                MessageBox.Show(this, "Die notwendigen Daten konnten nicht geladen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            toolStripLabel_Count.Text = dataGridView_OutlookItems.RowCount.ToString();
        }

        private void ConfigureGrid()
        {
            if (Filters.Any())
            {
                var mailItemsFiltered = objDataWork_OutlookItems.MailItems.Where(p => p.Find(Filters));
                dataGridView_OutlookItems.DataSource =  new SortableBindingList<clsMailItem> (mailItemsFiltered);
                toolStripLabel_Filter.Text = String.Join(" OR ", Filters.Select(p => p.key.ToString() + "=" + p.value).ToArray());
            }
            else
            {
                dataGridView_OutlookItems.DataSource = objDataWork_OutlookItems.MailItems;
                toolStripLabel_Filter.Text = "-";
            }
            
            dataGridView_OutlookItems.Columns[0].Visible = false;
            dataGridView_OutlookItems.Columns[9].Visible = false;
            dataGridView_OutlookItems.Columns[10].Visible = false;
        }

        private void contextMenuStrip_OutlookItems_Opening(object sender, CancelEventArgs e)
        {
            filterToolStripMenuItem.Enabled = false;
            outlookToolStripMenuItem.Enabled = false;
            if (dataGridView_OutlookItems.SelectedCells.Count == 1)
            {
                filterToolStripMenuItem.Enabled = true;
            }

            if (dataGridView_OutlookItems.SelectedRows.Count == 1)
            {
                outlookToolStripMenuItem.Enabled = true;
            }
        }

        private void equalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewColumn objdGVC = dataGridView_OutlookItems.Columns[dataGridView_OutlookItems.SelectedCells[0].ColumnIndex];
            Filters.Add(new clsFilter
            {
                key = objdGVC.DataPropertyName,
                value = dataGridView_OutlookItems.SelectedCells[0].Value.ToString(),
                TypeOfFilter = FilterType.equal
            });

            ConfigureGrid();
        }

        public void AddMailItems(List<clsAppDocuments> MailItems)
        {
            var objOItem_Result = objAppDBLevel.Save_Documents(MailItems);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                Initialize(); 
            }
            else
            {
                MessageBox.Show("Die neuen Mails konnten nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripButton_ClearFilter_Click(object sender, EventArgs e)
        {
            Filters.Clear();
            ConfigureGrid();
        }

        private void dataGridView_OutlookItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_OutlookItems.SelectedRows.Count == 1)
            {
                selectedRows();
            }
            
        }

        private void createOntologyItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsMailItem mailItem = (clsMailItem) dataGridView_OutlookItems.SelectedRows[0].DataBoundItem;
            
            objDataWork_OutlookItems.GetData_OutlookItems();
            if (objDataWork_OutlookItems.OItem_Result_OutlookItems.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var objOList_OItem = objDataWork_OutlookItems.OList_OutlookItems.Where(p => p.Name_Object == mailItem.EntryID).ToList();
                if (!objOList_OItem.Any())
                {
                    var objOItem_Mail = new clsOntologyItem
                    {
                        GUID = objLocalConfig.Globals.NewGUID,
                        Name = mailItem.Subject ?? "",
                        GUID_Parent = objLocalConfig.OItem_type_e_mail.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    objTransaction.ClearItems();
                    var objOItem_Result = objTransaction.do_Transaction(objOItem_Mail);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var objORel_Mail__Sended = objRelationConfig.Rel_ObjectAttribute(objOItem_Mail, objLocalConfig.OItem_attribute_sended, mailItem.CreationDate);
                        objOItem_Result = objTransaction.do_Transaction(objORel_Mail__Sended, true);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            

                            if (mailItem.SenderEmail != null)
                            {
                                clsOntologyItem objOItem_EmailAddress;

                                var objOList_EmailAddresses = objDataWork_OutlookItems.GetData_EmailAddress(mailItem.SenderEmail);
                                if (objOList_EmailAddresses == null)
                                {
                                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                                }
                                else
                                {
                                    if (objOList_EmailAddresses.Any())
                                    {
                                        objOItem_EmailAddress = objOList_EmailAddresses.First();


                                    }
                                    else
                                    {
                                        objOItem_EmailAddress = new clsOntologyItem
                                        {
                                            GUID = objLocalConfig.Globals.NewGUID,
                                            Name = mailItem.SenderEmail,
                                            GUID_Parent = objLocalConfig.OItem_type_email_address.GUID,
                                            Type = objLocalConfig.Globals.Type_Object
                                        };

                                        objOItem_Result = objTransaction.do_Transaction(objOItem_EmailAddress);
                                    }

                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        var objORel_Mail_To_Sender = objRelationConfig.Rel_ObjectRelation(objOItem_Mail, objOItem_EmailAddress, objLocalConfig.OItem_relationtype_von);
                                        objOItem_Result = objTransaction.do_Transaction(objORel_Mail_To_Sender);
                                    }
                                }


                            }


                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                if (mailItem.To != null)
                                {
                                    clsOntologyItem objOItem_EmailAddress;

                                    var strToS = mailItem.To.Split(';');
                                    foreach (string strTo in strToS)
                                    {
                                        var objOList_EmailAddresses = objDataWork_OutlookItems.GetData_EmailAddress(strTo);

                                        if (objOList_EmailAddresses.Any())
                                        {
                                            objOItem_EmailAddress = objOList_EmailAddresses.First();


                                        }
                                        else
                                        {
                                            objOItem_EmailAddress = new clsOntologyItem
                                            {
                                                GUID = objLocalConfig.Globals.NewGUID,
                                                Name = mailItem.To,
                                                GUID_Parent = objLocalConfig.OItem_type_email_address.GUID,
                                                Type = objLocalConfig.Globals.Type_Object
                                            };

                                            objOItem_Result = objTransaction.do_Transaction(objOItem_EmailAddress);
                                        }

                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            var objORel_Mail_To_Receiver = objRelationConfig.Rel_ObjectRelation(objOItem_Mail, objOItem_EmailAddress, objLocalConfig.OItem_relationtype_an);
                                            objOItem_Result = objTransaction.do_Transaction(objORel_Mail_To_Receiver);

                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }

                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    var objOutlookItem = new clsOntologyItem
                                    {
                                        GUID = objLocalConfig.Globals.NewGUID,
                                        Name = mailItem.EntryID,
                                        GUID_Parent = objLocalConfig.OItem_type_outlook_item.GUID,
                                        Type = objLocalConfig.Globals.Type_Object
                                    };

                                    objOItem_Result = objTransaction.do_Transaction(objOutlookItem);
                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        var objORel_OutlookItem_To_Mail = objRelationConfig.Rel_ObjectRelation(objOutlookItem, objOItem_Mail, objLocalConfig.OItem_relationtype_is);
                                        objOItem_Result = objTransaction.do_Transaction(objORel_OutlookItem_To_Mail);
                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            mailItem.SemItemPresent = true;
                                            mailItem.ID_OItem = objOItem_Mail.GUID;
                                            mailItem.Name_OItem = objOItem_Mail.Name;
                                            selectedRows();
                                        }
                                        else
                                        {
                                            objTransaction.rollback();
                                            MessageBox.Show("Die Mail konnte nicht erzeugt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }

                                    }
                                    else
                                    {
                                        objTransaction.rollback();
                                        MessageBox.Show("Die Mail konnte nicht erzeugt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    objTransaction.rollback();
                                    MessageBox.Show("Die Mail konnte nicht erzeugt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                objTransaction.rollback();
                                MessageBox.Show("Die Mail konnte nicht erzeugt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                
                            }
                            
                        }
                        else
                        {
                            objTransaction.rollback();
                            MessageBox.Show("Die Mail konnte nicht erzeugt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Die Mail konnte nicht erzeugt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            else
            {
                MessageBox.Show("Die Outlookitems konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow objDGVR = dataGridView_OutlookItems.SelectedRows[0];
            clsMailItem mailItem = (clsMailItem)objDGVR.DataBoundItem;

            var objOItem_Result =  objOutlookConnector.OpenMailItem(mailItem.EntryID);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                MessageBox.Show("Die Mail konnte leider nicht geöffnet werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView_OutlookItems_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow objDGVR = dataGridView_OutlookItems.Rows[e.RowIndex];
            clsMailItem mailItem = (clsMailItem)objDGVR.DataBoundItem;


            var objOList_Objects = new List<clsOntologyItem> 
            { 
                new clsOntologyItem 
                {
                    GUID = mailItem.ID_OItem, 
                    Name = mailItem.Name_OItem,
                    GUID_Parent = objLocalConfig.OItem_type_e_mail.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                }
            };

            objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals, objOList_Objects, 0, objLocalConfig.Globals.Type_Object, null);
            objFrmObjectEdit.ShowDialog(this);
            
        }

        private void toolStripTextBox_contains_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridViewColumn objdGVC = dataGridView_OutlookItems.Columns[dataGridView_OutlookItems.SelectedCells[0].ColumnIndex];
                Filters.Add(new clsFilter 
                    {
                        key = objdGVC.DataPropertyName,
                        value = toolStripTextBox_contains.Text,
                        TypeOfFilter = FilterType.contains
                    });

                ConfigureGrid();
            }
        }

        private void differentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewColumn objdGVC = dataGridView_OutlookItems.Columns[dataGridView_OutlookItems.SelectedCells[0].ColumnIndex];
            Filters.Add(new clsFilter
            {
                key = objdGVC.DataPropertyName,
                value = dataGridView_OutlookItems.SelectedCells[0].Value.ToString(),
                TypeOfFilter = FilterType.different
            });

            ConfigureGrid();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters.Clear();
        }

        private void containsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox_contains.Text != "")
            {
                DataGridViewColumn objdGVC = dataGridView_OutlookItems.Columns[dataGridView_OutlookItems.SelectedCells[0].ColumnIndex];
                Filters.Add(new clsFilter
                {
                    key = objdGVC.DataPropertyName,
                    value = toolStripTextBox_contains.Text,
                    TypeOfFilter = FilterType.contains
                });

                ConfigureGrid();
            }
            else
            {
                MessageBox.Show(this, "Geben Sie bitte eine Suchzeichenkette ein!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
