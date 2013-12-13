using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace TextParser
{
    public delegate void AppliedFilter();

    public partial class UserControl_RegExFilterDetail : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private clsDatawork_RegExFilter objDataWork_RegExFilter;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        private clsOntologyItem objOItem_Filter;
        private clsOntologyItem objOItem_RelationType;
        private clsOntologyItem objOItem_Empty;

        public clsRegExFilter RegExFilter { get; set; }

        public event AppliedFilter appliedFilter;

        public UserControl_RegExFilterDetail(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            objOItem_Empty = new clsOntologyItem
                {
                    GUID = objLocalConfig.Globals.NewGUID,
                    Name = ""
                };
            objDataWork_RegExFilter = new clsDatawork_RegExFilter(objLocalConfig);
            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);

            comboBox_Relation.Items.Add(objLocalConfig.OItem_relationtype_pre);
            comboBox_Relation.Items.Add(objLocalConfig.OItem_relationtype_main);
            comboBox_Relation.Items.Add(objLocalConfig.OItem_relationtype_posts);
            comboBox_Relation.Items.Add(objOItem_Empty);

            comboBox_Relation.DisplayMember = "Name";
            comboBox_Relation.ValueMember = "GUID";
        }

        private void ClearControls()
        {
            textBox_Name.ReadOnly = true;
            textBox_Name.Text = "";
            textBox_Pattern.ReadOnly = true;
            textBox_Pattern.Text = "";
            checkBox_Equal.Enabled = false;
            comboBox_Relation.Enabled = false;
            comboBox_Relation.SelectedValue = objOItem_Empty.GUID;
            toolStripButton_Apply.Enabled = false;
            RegExFilter = null;

        }

        public void Initialize_Filter(clsOntologyItem OItem_Filter, clsOntologyItem OItem_RelationType = null)
        {
            objOItem_Filter = OItem_Filter;
            objOItem_RelationType = OItem_RelationType;
            ClearControls();
            
            if (objOItem_Filter != null)
            {
                RegExFilter = objDataWork_RegExFilter.GetData_FilterRel(objOItem_Filter);
                if (RegExFilter != null)
                {
                    textBox_Name.Text = objOItem_Filter.Name;
                    textBox_Name.ReadOnly = false;
                    var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
                    if (RegExFilter.ID_Attribute_Equal == null || RegExFilter.Equal == null)
                    {
                        var objOARel_Filter_Equal = objRelationConfig.Rel_ObjectAttribute(objOItem_Filter,
                                                                                          objLocalConfig
                                                                                              .OItem_attributetype_equal,
                                                                                          false);
                        objTransaction.ClearItems();
                        objOItem_Result = objTransaction.do_Transaction(objOARel_Filter_Equal, true);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            RegExFilter.ID_Attribute_Equal = objTransaction.OItem_Last.OItem_ObjectAtt.ID_Attribute;
                        }
                    }

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        checkBox_Equal.Checked = RegExFilter.Equal ?? false;
                        checkBox_Equal.Enabled = true;

                        if (RegExFilter.ID_Attribute_Pattern != null && RegExFilter.Filter != null)
                        {
                            textBox_Pattern.Text = RegExFilter.Filter;
                        }

                        textBox_Pattern.ReadOnly = false;

                        if (objOItem_RelationType != null)
                        {
                            comboBox_Relation.SelectedValue = objOItem_RelationType.GUID;
                        }

                        comboBox_Relation.Enabled = true;

                    }
                    else
                    {
                        MessageBox.Show(this, "Der Filter konnte nicht ermittelt werden", "Fehler!", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    }


                }
                else
                {
                    MessageBox.Show(this, "Der Filter konnte nicht ermittelt werden", "Fehler!", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                

            }
            
            Configure_Apply();
        }

        private void Configure_Apply()
        {
            var objOItem_Selected = (clsOntologyItem) comboBox_Relation.SelectedItem;
            if (RegExFilter != null && RegExFilter.ID_Attribute_Equal != null &&
                RegExFilter.ID_Attribute_Pattern != null && objOItem_Selected != null && 
                objOItem_Selected.GUID != objOItem_Empty.GUID)
            {
                toolStripButton_Apply.Enabled = true;
            }
            else
            {
                toolStripButton_Apply.Enabled = false;
            }
        }

        private void textBox_Name_TextChanged(object sender, EventArgs e)
        {
            timer_Name.Stop();
            if (!textBox_Name.ReadOnly)
            {
                timer_Name.Start();
            }
        }

        private void textBox_Pattern_TextChanged(object sender, EventArgs e)
        {
            timer_Pattern.Stop();
            if (!textBox_Pattern.ReadOnly)
            {
                timer_Pattern.Start();
            }
        }

        private void checkBox_Equal_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Equal.Enabled) Save_Equal();
            Configure_Apply();
        }

        private void timer_Pattern_Tick(object sender, EventArgs e)
        {
            timer_Pattern.Stop();
            Save_Pattern();
            Configure_Apply();
        }

        private void Save_Pattern()
        {
            if (RegExFilter != null)
            {
                if (textBox_Pattern.Text == "")
                {
                    if (RegExFilter.ID_Attribute_Pattern != null)
                    {
                        var objOA_Pattern = new clsObjectAtt {ID_Attribute = RegExFilter.ID_Attribute_Equal};
                        objTransaction.ClearItems();
                        var objOItem_Result = objTransaction.do_Transaction(objOA_Pattern, false, true);

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            RegExFilter.ID_Attribute_Pattern = null;
                            RegExFilter.Filter = null;
                        }
                        else
                        {
                            MessageBox.Show(this, "Der Filter kann nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                            textBox_Pattern.ReadOnly = true;
                            textBox_Pattern.Text = "";
                        }
                    }
                }
                else
                {
                    var objOA_Pattern = objRelationConfig.Rel_ObjectAttribute(objOItem_Filter,
                                                                              objLocalConfig.OItem_attributetype_pattern,
                                                                              "");
                    if (RegExFilter.ID_Attribute_Pattern != null)
                    {
                        objOA_Pattern.ID_Attribute = RegExFilter.ID_Attribute_Pattern;
                        objOA_Pattern.Val_String = textBox_Pattern.Text;
                        objOA_Pattern.Val_Named = textBox_Pattern.Text.Length <= 255
                                                      ? textBox_Pattern.Text
                                                      : textBox_Pattern.Text.Substring(0, 254);
                    }
                    else
                    {
                        objOA_Pattern.Val_String = textBox_Pattern.Text;
                        objOA_Pattern.Val_Named = textBox_Pattern.Text.Length <= 255
                                                      ? textBox_Pattern.Text
                                                      : textBox_Pattern.Text.Substring(0, 254);
                    }

                    objTransaction.ClearItems();
                    var objOItem_Result = objTransaction.do_Transaction(objOA_Pattern, true);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        RegExFilter.ID_Attribute_Pattern = objTransaction.OItem_Last.OItem_ObjectAtt.ID_Attribute;
                        RegExFilter.Filter = objOA_Pattern.Val_String;
                    }
                    else
                    {
                        MessageBox.Show(this, "Der Filter kann nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);

                        textBox_Pattern.ReadOnly = true;
                        textBox_Pattern.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Der Filter kann nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                textBox_Pattern.ReadOnly = true;
                textBox_Pattern.Text = "";
            }


        }

        private void timer_Name_Tick(object sender, EventArgs e)
        {
            timer_Name.Stop();
            Save_Name();
            Configure_Apply();
        }

        private void Save_Equal()
        {
            if (RegExFilter != null)
            {
                if (checkBox_Equal.Checked != RegExFilter.Equal)
                {
                    var objOA_Equal = objRelationConfig.Rel_ObjectAttribute(objOItem_Filter,
                                                                            objLocalConfig.OItem_attributetype_equal,
                                                                            checkBox_Equal.Checked,
                                                                            ID_Attribute: RegExFilter.ID_Attribute_Equal);

                    objTransaction.ClearItems();
                    var objOItem_Result = objTransaction.do_Transaction(objOA_Equal);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                    {
                        MessageBox.Show(this, "Equal kann nicht gesetzt werden!", "Fehler",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        checkBox_Equal.Enabled = false;
                        checkBox_Equal.Checked = RegExFilter.Equal ?? false;
                    }
                }
            }
        }

        private void Save_Name()
        {
            if (RegExFilter != null)
            {
                if (textBox_Name.Text == "")
                {
                    MessageBox.Show(this, "Sie müssen einen Namen für den Filter vergeben!", "Eingabefehler",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_Name.ReadOnly = true;
                    textBox_Name.Text = objOItem_Filter.Name;
                    textBox_Name.ReadOnly = false;
                }
                else
                {
                    if (textBox_Name.Text != RegExFilter.Name_Filter)
                    {
                        var objOItem_Filter_Save = objOItem_Filter.Clone();
                        objOItem_Filter_Save.Name = textBox_Name.Text;
                        objTransaction.ClearItems();
                        var objOItem_Result = objTransaction.do_Transaction(objOItem_Filter_Save);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            RegExFilter.Name_Filter = objOItem_Filter_Save.Name;
                        }
                        else
                        {
                            MessageBox.Show(this, "Der Name konnte nicht gespeichert werden!", "Fehler",
                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox_Name.ReadOnly = true;
                            textBox_Name.Text = RegExFilter.Name_Filter;
                            textBox_Name.ReadOnly = false;
                        }    
                    }
                    
                }
            }
        }

        private void comboBox_Relation_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedRelationType = (clsOntologyItem)comboBox_Relation.SelectedItem;
            if (selectedRelationType.GUID != objOItem_Empty.GUID)
            {
                RegExFilter.ID_Regex_RelationType = selectedRelationType.GUID;
                RegExFilter.Name_Regex_RelationType = selectedRelationType.Name;
            }
            else
            {
                RegExFilter.ID_Regex_RelationType = null;
                RegExFilter.Name_Regex_RelationType = null;
            }
            Configure_Apply();
        }

        private void toolStripButton_Apply_Click(object sender, EventArgs e)
        {
            if (RegExFilter != null)
            {
                appliedFilter();
            }
        }
    }
}
