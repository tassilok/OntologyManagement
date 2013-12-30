using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontology_Module;
using OntologyClasses.DataClasses;

namespace EsMaintenance
{
    public partial class frmEsMaintenance : Form
    {
        private clsGlobals objGlobals;
        private clsEsMaintenance objEsMaintenance;

        public frmEsMaintenance()
        {
            InitializeComponent();

            objGlobals = new clsGlobals();
            objEsMaintenance = new clsEsMaintenance(objGlobals);
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton_Search_Click(object sender, EventArgs e)
        {
            if (listView_ItemTypes.SelectedItems.Count == 1)
            {
                var strQuery = (toolStripTextBox_Query.Text == "" ? "*" : toolStripTextBox_Query.Text);
                toolStripTextBox_Query.Text = strQuery;
                var objListViewItem = listView_ItemTypes.SelectedItems[0];
                if (objListViewItem.Text == objGlobals.Type_AttributeType)
                {
                    if (objEsMaintenance.GetDataAttributeType(strQuery).GUID == objGlobals.LState_Success.GUID)
                    {
                        dataGridView_Found.DataSource = objEsMaintenance.OList_AttributeType;
                        foreach (DataGridViewColumn objColumn in dataGridView_Found.Columns)
                        {
                            if (objColumn.DataPropertyName == "GUID" ||
                                objColumn.DataPropertyName == "Name" ||
                                objColumn.DataPropertyName == "GUID_Parent")
                            {
                                objColumn.Visible = true;
                            }
                            else
                            {
                                objColumn.Visible = false;
                            }
                            
                        }
                    }
                    else
                    {
                        dataGridView_Found.DataSource = null;
                    }
                }
                else if (objListViewItem.Text == objGlobals.Type_RelationType)
                {
                    if (objEsMaintenance.GetDataRelationType(strQuery).GUID == objGlobals.LState_Success.GUID)
                    {
                        dataGridView_Found.DataSource = objEsMaintenance.OList_RelationType;
                        
                        foreach (DataGridViewColumn objColumn in dataGridView_Found.Columns)
                        {
                            if (objColumn.DataPropertyName == "GUID" ||
                                objColumn.DataPropertyName == "Name")
                            {
                                objColumn.Visible = true;
                            }
                            else
                            {
                                objColumn.Visible = false;
                            }

                        }
                    }
                    else
                    {
                        dataGridView_Found.DataSource = null;
                    }
                }
                else if (objListViewItem.Text == objGlobals.Type_Class)
                {
                    if (objEsMaintenance.GetDataClasses(strQuery).GUID == objGlobals.LState_Success.GUID)
                    {
                        dataGridView_Found.DataSource = objEsMaintenance.OList_Class;
                        foreach (DataGridViewColumn objColumn in dataGridView_Found.Columns)
                        {
                            if (objColumn.DataPropertyName == "GUID" ||
                                objColumn.DataPropertyName == "Name" ||
                                objColumn.DataPropertyName == "GUID_Parent")
                            {
                                objColumn.Visible = true;
                            }
                            else
                            {
                                objColumn.Visible = false;
                            }

                        }
                    }
                    else
                    {
                        dataGridView_Found.DataSource = null;
                    }
                }
                else if (objListViewItem.Text == objGlobals.Type_Object)
                {
                    if (objEsMaintenance.GetDataObjects(strQuery).GUID == objGlobals.LState_Success.GUID)
                    {
                        dataGridView_Found.DataSource = objEsMaintenance.OList_Object;
                        foreach (DataGridViewColumn objColumn in dataGridView_Found.Columns)
                        {
                            if (objColumn.DataPropertyName == "GUID" ||
                                objColumn.DataPropertyName == "Name" ||
                                objColumn.DataPropertyName == "GUID_Parent")
                            {
                                objColumn.Visible = true;
                            }
                            else
                            {
                                objColumn.Visible = false;
                            }

                        }
                    }
                    else
                    {
                        dataGridView_Found.DataSource = null;
                    }
                }
                else if (objListViewItem.Text == objGlobals.Type_ObjectAtt)
                {
                    if (objEsMaintenance.GetDataObjectAtt(strQuery).GUID == objGlobals.LState_Success.GUID)
                    {
                        dataGridView_Found.DataSource = objEsMaintenance.OList_ObjectAttribute;
                        foreach (DataGridViewColumn objColumn in dataGridView_Found.Columns)
                        {
                            if (objColumn.DataPropertyName == objGlobals.Field_ID_Attribute ||
                                objColumn.DataPropertyName == objGlobals.Field_ID_AttributeType ||
                                objColumn.DataPropertyName == objGlobals.Field_ID_Class ||
                                objColumn.DataPropertyName == objGlobals.Field_ID_Object ||
                                objColumn.DataPropertyName == objGlobals.Field_OrderID ||
                                objColumn.DataPropertyName == objGlobals.Field_ID_DataType ||
                                objColumn.DataPropertyName == "Val_Bit" ||
                                objColumn.DataPropertyName == "Val_Date" ||
                                objColumn.DataPropertyName == "Val_lng" ||
                                objColumn.DataPropertyName == "val_Named" ||
                                objColumn.DataPropertyName == "Val_Double" ||
                                objColumn.DataPropertyName == objGlobals.Field_Val_String)
                            {
                                objColumn.Visible = true;
                            }
                            else
                            {
                                objColumn.Visible = false;
                            }

                        }
                    }
                    else
                    {
                        dataGridView_Found.DataSource = null;
                    }

                }
                else if (objListViewItem.Text == objGlobals.Type_ObjectRel)
                {
                    if (strQuery.ToLower() == "OrderID is string".ToLower())
                    {
                        if (objEsMaintenance.GetDataObjectRelOrderIDString().GUID == objGlobals.LState_Success.GUID)
                        {
                            dataGridView_Found.DataSource = objEsMaintenance.OList_ObjectRel;
                            foreach (DataGridViewColumn objColumn in dataGridView_Found.Columns)
                            {
                                if (objColumn.DataPropertyName == objGlobals.Field_ID_Object ||
                                    objColumn.DataPropertyName == objGlobals.Field_ID_Parent_Object ||
                                    objColumn.DataPropertyName == objGlobals.Field_ID_Other ||
                                    objColumn.DataPropertyName == objGlobals.Field_ID_Parent_Other ||
                                    objColumn.DataPropertyName == objGlobals.Field_OrderID ||
                                    objColumn.DataPropertyName == objGlobals.Field_Ontology ||
                                    objColumn.DataPropertyName == objGlobals.Field_ID_RelationType)
                                {
                                    objColumn.Visible = true;
                                }
                                else
                                {
                                    objColumn.Visible = false;
                                }

                            }
                        }
                        else
                        {
                            dataGridView_Found.DataSource = null;
                        }
                    }
                    else
                    {
                        if (objEsMaintenance.GetDataObjectRel(strQuery).GUID == objGlobals.LState_Success.GUID)
                        {
                            dataGridView_Found.DataSource = objEsMaintenance.OList_ObjectRel;
                            foreach (DataGridViewColumn objColumn in dataGridView_Found.Columns)
                            {
                                if (objColumn.DataPropertyName == objGlobals.Field_ID_Object ||
                                    objColumn.DataPropertyName == objGlobals.Field_ID_Parent_Object ||
                                    objColumn.DataPropertyName == objGlobals.Field_ID_Other ||
                                    objColumn.DataPropertyName == objGlobals.Field_ID_Parent_Other ||
                                    objColumn.DataPropertyName == objGlobals.Field_OrderID ||
                                    objColumn.DataPropertyName == objGlobals.Field_Ontology ||
                                    objColumn.DataPropertyName == objGlobals.Field_ID_RelationType)
                                {
                                    objColumn.Visible = true;
                                }
                                else
                                {
                                    objColumn.Visible = false;
                                }

                            }
                        }
                        else
                        {
                            dataGridView_Found.DataSource = null;
                        }
                    }
                    

                }
                else if (objListViewItem.Text == objGlobals.Type_ClassRel)
                {
                    if (objEsMaintenance.GetDataClassRel(strQuery).GUID == objGlobals.LState_Success.GUID)
                    {
                        dataGridView_Found.DataSource = objEsMaintenance.OList_ClassRel;
                        foreach (DataGridViewColumn objColumn in dataGridView_Found.Columns)
                        {
                            if (objColumn.DataPropertyName == "Name_Class_Left" ||
                                objColumn.DataPropertyName == "Name_Class_Right" ||
                                objColumn.DataPropertyName == "Name_RelationType")
                            {
                                objColumn.Visible = false;
                            }
                            else
                            {
                                objColumn.Visible = true;
                            }

                        }
                    }
                    else
                    {
                        dataGridView_Found.DataSource = null;
                    }
                }
                else if (objListViewItem.Text == objGlobals.Type_ClassAtt)
                {
                    if (objEsMaintenance.GetDataClassAtt(strQuery).GUID == objGlobals.LState_Success.GUID)
                    {
                        dataGridView_Found.DataSource = objEsMaintenance.OList_ClassAtt;
                        foreach (DataGridViewColumn objColumn in dataGridView_Found.Columns)
                        {
                            if (objColumn.DataPropertyName == "Name_Class" ||
                                objColumn.DataPropertyName == "Name_AttributeType" ||
                                objColumn.DataPropertyName == "Name_DataType")
                            {
                                objColumn.Visible = false;
                            }
                            else
                            {
                                objColumn.Visible = true;
                            }

                        }
                    }
                    else
                    {
                        dataGridView_Found.DataSource = null;
                    }
                }
                toolStripLabel_Count.Text = dataGridView_Found.RowCount.ToString();
                
            }
            

            

        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            var objDictList = new List<Dictionary<string, object>>();
            var objFields = new clsFields();
            string strFieldName;
           
            foreach (DataGridViewRow objDGVR in dataGridView_Found.Rows)
            {
                var objDict = new Dictionary<string, object>();
                foreach (DataGridViewColumn objColumn in dataGridView_Found.Columns)
                {
                    if (objColumn.Visible)
                    {
                        strFieldName = objColumn.DataPropertyName;
                        
                                
                        strFieldName = (strFieldName == "Val_Bit" ? objFields.Val_Bool : strFieldName);
                        strFieldName = (strFieldName == "Val_Date" ? objFields.Val_Datetime : strFieldName);
                        strFieldName = (strFieldName == "Val_lng" ? objFields.Val_Int : strFieldName);
                        strFieldName = (strFieldName == "val_Named" ? objFields.Val_Name : strFieldName);
                        strFieldName = (strFieldName == "Val_Double" ? objFields.Val_Real : strFieldName);

                        strFieldName = (strFieldName == "GUID" ? objFields.ID_Item : strFieldName);
                        strFieldName = (strFieldName == "GUID_Parent" ? objFields.ID_Class : strFieldName);
                        strFieldName = (strFieldName == "Name" ? objFields.Name_Item : strFieldName);

                        objDict.Add(strFieldName, objDGVR.Cells[objColumn.DataPropertyName].Value);
                        
                    }
                }
                objDictList.Add(objDict);
            }

            if (objDictList.Count > 0)
            {
                var objListViewItem = listView_ItemTypes.SelectedItems[0];
                if (objListViewItem.Text == objGlobals.Type_AttributeType)
                {

                    
                }
                else if (objListViewItem.Text == objGlobals.Type_Class)
                {
                    
                }
                else if (objListViewItem.Text == objGlobals.Type_Object)
                {
                    var OItem_Result = objEsMaintenance.SaveObject(objDictList);
                    if (OItem_Result.GUID == objGlobals.LState_Success.GUID)
                    {
                        MessageBox.Show("Die Elemente wurden gespeichert!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (OItem_Result.GUID == objGlobals.LState_Nothing.GUID)
                    {
                        MessageBox.Show("Keine Elemente wurden gespeichert!", "Unbekannt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Fehler beim Speichern!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }        
                }
                else if (objListViewItem.Text == objGlobals.Type_RelationType)
                {
                    
                }
                else if (objListViewItem.Text == objGlobals.Type_ClassAtt)
                {
                    
                }
                else if (objListViewItem.Text == objGlobals.Type_ClassRel)
                {
                    var OItem_Result = objEsMaintenance.SaveClassRel(objDictList);
                    if (OItem_Result.GUID == objGlobals.LState_Success.GUID)
                    {
                        MessageBox.Show("Die Elemente wurden gespeichert!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (OItem_Result.GUID == objGlobals.LState_Nothing.GUID)
                    {
                        MessageBox.Show("Keine Elemente wurden gespeichert!", "Unbekannt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Fehler beim Speichern!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }        
                }
                else if (objListViewItem.Text == objGlobals.Type_ObjectAtt)
                {
                    var OItem_Result = objEsMaintenance.SaveObjectAtt(objDictList);
                    if (OItem_Result.GUID == objGlobals.LState_Success.GUID)
                    {
                        MessageBox.Show("Die Elemente wurden gespeichert!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (OItem_Result.GUID == objGlobals.LState_Nothing.GUID)
                    {
                        MessageBox.Show("Keine Elemente wurden gespeichert!", "Unbekannt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Fehler beim Speichern!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }    
                }
                else if (objListViewItem.Text == objGlobals.Type_ObjectRel)
                {
                    var OItem_Result = objEsMaintenance.SaveObjectRel(objDictList);
                    if (OItem_Result.GUID == objGlobals.LState_Success.GUID)
                    {
                        MessageBox.Show("Die Elemente wurden gespeichert!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (OItem_Result.GUID == objGlobals.LState_Nothing.GUID)
                    {
                        MessageBox.Show("Keine Elemente wurden gespeichert!", "Unbekannt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Fehler beim Speichern!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }    
                }
                
            }
        }

        private void contextMenuStrip_Items_Opening(object sender, CancelEventArgs e)
        {
            delToolStripMenuItem.Enabled = false;

            if (dataGridView_Found.SelectedRows.Count > 0)
            {
                delToolStripMenuItem.Enabled = true;
            }
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var objListViewItem = listView_ItemTypes.SelectedItems[0];
            var objDictList = new List<Dictionary<string, string>>();
            var objFields = new clsFields();
            if (objListViewItem.Text == objGlobals.Type_AttributeType)
            {
                
                foreach (DataGridViewRow objDGVR in dataGridView_Found.SelectedRows)
                {
                    var objDict = new Dictionary<string, string>();
                    objDict.Add(objFields.ID_Item, objDGVR.Cells[objFields.ID_Item].Value.ToString());

                    objDictList.Add(objDict);
                }
            }
            else if (objListViewItem.Text == objGlobals.Type_Class)
            {
                foreach (DataGridViewRow objDGVR in dataGridView_Found.SelectedRows)
                {
                    var objDict = new Dictionary<string, string>();
                    objDict.Add(objFields.ID_Item, objDGVR.Cells["GUID"].Value.ToString());

                    objDictList.Add(objDict);

                }

                var objOItem_Result = objEsMaintenance.DelClass(objDictList);
                if (objOItem_Result.Count < objDictList.Count)
                {
                    MessageBox.Show("Es konnten nur " + objOItem_Result.Count.ToString() + " von " + objDictList.Count.ToString() + " Items gelöscht werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (objListViewItem.Text == objGlobals.Type_Object)
            {
                foreach (DataGridViewRow objDGVR in dataGridView_Found.SelectedRows)
                {
                }
            }
            else if (objListViewItem.Text == objGlobals.Type_RelationType)
            {
                foreach (DataGridViewRow objDGVR in dataGridView_Found.SelectedRows)
                {
                }
            }
            else if (objListViewItem.Text == objGlobals.Type_ClassAtt)
            {
                foreach (DataGridViewRow objDGVR in dataGridView_Found.SelectedRows)
                {
                }
            }
            else if (objListViewItem.Text == objGlobals.Type_ClassRel)
            {
                foreach (DataGridViewRow objDGVR in dataGridView_Found.SelectedRows)
                {
                }
            }
            else if (objListViewItem.Text == objGlobals.Type_ObjectAtt)
            {
                foreach (DataGridViewRow objDGVR in dataGridView_Found.SelectedRows)
                {
                    var objDict = new Dictionary<string, string>();
                    objDict.Add(objFields.ID_Attribute, objDGVR.Cells[objFields.ID_Attribute].Value.ToString());

                    objDictList.Add(objDict);

                }

                var objOItem_Result = objEsMaintenance.DelObjectAtt(objDictList);
                if (objOItem_Result.Count < objDictList.Count)
                {
                    MessageBox.Show("Es konnten nur " + objOItem_Result.Count.ToString() + " von " + objDictList.Count.ToString() + " Items gelöscht werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (objListViewItem.Text == objGlobals.Type_ObjectRel)
            {
                foreach (DataGridViewRow objDGVR in dataGridView_Found.SelectedRows)
                {
                    var objDict = new Dictionary<string, string>();
                    objDict.Add(objFields.ID_Object, objDGVR.Cells[objFields.ID_Object].Value.ToString());
                    objDict.Add(objFields.ID_Other, objDGVR.Cells[objFields.ID_Other].Value.ToString());
                    objDict.Add(objFields.ID_RelationType, objDGVR.Cells[objFields.ID_RelationType].Value.ToString());

                    objDictList.Add(objDict);


                }

                var objOItem_Result = objEsMaintenance.DelObjectRel(objDictList);
                if (objOItem_Result.Count < objDictList.Count)
                {
                    MessageBox.Show("Es konnten nur " + objOItem_Result.Count.ToString() + " von " + objDictList.Count.ToString() + " Items gelöscht werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
