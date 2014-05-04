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
using OntologyClasses.BaseClasses;
using Ontology_Module;
using Typed_Tagging_Module;

namespace LiteraturQuellen_Module
{
    public delegate void SelectedQuelle(clsLiteraturQuelle objLiteraturQuelle);
    public delegate void AppliedQuelle();

    public partial class UserControl_LiteraturQuelle : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private frmTypedTaggingSingle objFrmTypedTaggingSingle;

        private clsDataWork_LiteraturQuelle objDataWork_LiteraturQuelle;
        private SortableBindingList<clsLiteraturQuelle> OList_LiteraturList;

        private frm_ObjectEdit objFrm_ObjectEdit;
        private frmQuellen objFrmQuellen;

        public event SelectedQuelle selectedQuelle;
        public event AppliedQuelle appliedQuelle;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        public List<clsLiteraturQuelle> OList_LiteraturQuellen { get; private set; }

        private clsOntologyItem objOItem_Filter;

        private bool boolApplyable;

        public bool Applyable 
        {
            get { return boolApplyable; }
            set 
            { 
                boolApplyable = value;
                applyToolStripMenuItem.Enabled = boolApplyable;
            } 
        }

        public UserControl_LiteraturQuelle(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            applyToolStripMenuItem.Enabled = boolApplyable;
            Initialize();
        }

        private void Initialize()
        {
            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
            checkMenuitem(literaturquelleToolStripMenuItem.Text);
            FillDataGridView();
        }

        private void FillDataGridView(string GUID_LiteraturQuelle = null)
        {
            dataGridView_LiteraturQuellen.DataSource = null;
            objDataWork_LiteraturQuelle = new clsDataWork_LiteraturQuelle(objLocalConfig);
            objDataWork_LiteraturQuelle.GetData_LiteraturQuellen();
            List<clsOntologyItem> objOList_LiteraturQuellen = new List<clsOntologyItem>();

            if (objOItem_Filter != null && objOItem_Filter.GUID_Parent != objLocalConfig.OItem_type_literarische_quelle.GUID)
            {
                objOList_LiteraturQuellen = objDataWork_LiteraturQuelle.getFilterQuellen(objOItem_Filter);
            }

            if (objOList_LiteraturQuellen != null)
            {
                if (objDataWork_LiteraturQuelle.OItem_Result_LiteraturQuellen.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    
                    if (objOItem_Filter != null && objOItem_Filter.GUID_Parent != objLocalConfig.OItem_type_literarische_quelle.GUID)
                    {
                        var oList_LiteraturList = new SortableBindingList<clsLiteraturQuelle>((from objLiteraturQuellen in objDataWork_LiteraturQuelle.OList_LiteraturQuellen
                                                                                               join literaturQuelleFilter in objOList_LiteraturQuellen on objLiteraturQuellen.ID_LiteraturQuelle equals literaturQuelleFilter.GUID
                                                                                               select objLiteraturQuellen));

                        dataGridView_LiteraturQuellen.DataSource = oList_LiteraturList;
                    }
                    else if (objOItem_Filter != null && objOItem_Filter.GUID_Parent == objLocalConfig.OItem_type_literarische_quelle.GUID)
                    {
                        dataGridView_LiteraturQuellen.DataSource = new SortableBindingList<clsLiteraturQuelle>(objDataWork_LiteraturQuelle.OList_LiteraturQuellen.Where(lq => lq.Name_LiteraturQuelle.ToLower().Contains(objOItem_Filter.Name.ToLower())));
                    }
                    else
                    {
                        if (GUID_LiteraturQuelle == null)
                        {
                            dataGridView_LiteraturQuellen.DataSource = objDataWork_LiteraturQuelle.OList_LiteraturQuellen;
                        }
                        else
                        {
                            dataGridView_LiteraturQuellen.DataSource = new SortableBindingList<clsLiteraturQuelle>( objDataWork_LiteraturQuelle.OList_LiteraturQuellen.Where(lq => lq.ID_LiteraturQuelle == GUID_LiteraturQuelle));
                        }
                        
                    }
                    
                    

                    
                    dataGridView_LiteraturQuellen.Columns[0].Visible = false;
                    dataGridView_LiteraturQuellen.Columns[2].Visible = false;
                    dataGridView_LiteraturQuellen.Columns[4].Visible = false;

                    toolStripLabel_Count.Text = dataGridView_LiteraturQuellen.RowCount.ToString();
                }
                else
                {
                    MessageBox.Show(this, "Die Literaturliste konnte nicht initialisiert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                }
            }
            else
            {
                MessageBox.Show(this, "Die Literaturliste konnte nicht initialisiert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
            

            
        }

        private void dataGridView_LiteraturQuellen_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_LiteraturQuellen.SelectedRows.Count == 1)
            {
                DataGridViewRow objDGVR = dataGridView_LiteraturQuellen.SelectedRows[0];
                clsLiteraturQuelle objLiteraturQuelle = (clsLiteraturQuelle) objDGVR.DataBoundItem;

                selectedQuelle(objLiteraturQuelle);
            }
        }

        private void dataGridView_LiteraturQuellen_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow objDGVR = dataGridView_LiteraturQuellen.Rows[e.RowIndex];
            clsLiteraturQuelle objLiteraturQuelle = (clsLiteraturQuelle) objDGVR.DataBoundItem;

            var OList_Objects = new List<clsOntologyItem> {new clsOntologyItem {GUID = objLiteraturQuelle.ID_Quelle,
                                                                            Name = objLiteraturQuelle.Name_Quelle,
                                                                            GUID_Parent = objLiteraturQuelle.ID_Class_Quelle}};

            objFrm_ObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals, OList_Objects, 0, objLocalConfig.Globals.Type_Object, null);
            objFrm_ObjectEdit.ShowDialog(this);

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objFrmQuellen = new frmQuellen(objLocalConfig);
            objFrmQuellen.ShowDialog(this);
            if (objFrmQuellen.DialogResult == DialogResult.OK)
            {
                var objOItem_LiterarischeQuelle = new clsOntologyItem
                {
                    GUID = objLocalConfig.Globals.NewGUID,
                    Name = objFrmQuellen.Name_Quelle,
                    GUID_Parent = objLocalConfig.OItem_type_literarische_quelle.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                var objOItem_QuellType = objFrmQuellen.OItem_QuellType;

                objTransaction.ClearItems();
                var objOItem_Result = objTransaction.do_Transaction(objOItem_LiterarischeQuelle);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var objOItem_Quelle = new clsOntologyItem
                    {
                        GUID = objLocalConfig.Globals.NewGUID,
                        Name = objOItem_LiterarischeQuelle.Name,
                        GUID_Parent = objOItem_QuellType.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    objOItem_Result = objTransaction.do_Transaction(objOItem_Quelle);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var objORel_Quelle_To_LiterarischeQuelle = objRelationConfig.Rel_ObjectRelation(objOItem_Quelle, objOItem_LiterarischeQuelle, objLocalConfig.OItem_relationtype_issubordinated);
                        objOItem_Result = objTransaction.do_Transaction(objORel_Quelle_To_LiterarischeQuelle, true);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            FillDataGridView();
                            
                        }
                        else
                        {
                            objTransaction.rollback();
                            MessageBox.Show(this, "Die Quelle konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        objTransaction.rollback();
                        MessageBox.Show(this, "Die Quelle konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Die Quelle konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                FillDataGridView(objOItem_LiterarischeQuelle.GUID);
            }

            
        }

        private void contextMenuStrip_Quellen_Opening(object sender, CancelEventArgs e)
        {
            applyToolStripMenuItem.Enabled = false;
            typedTaggingToolStripMenuItem.Enabled = false;
            if (dataGridView_LiteraturQuellen.SelectedRows.Count > 0)
            {
                applyToolStripMenuItem.Enabled = true;
                if (dataGridView_LiteraturQuellen.SelectedRows.Count == 1)
                {
                    typedTaggingToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void applyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OList_LiteraturQuellen = new List<clsLiteraturQuelle>();
            foreach (DataGridViewRow objDGVR_Selected in dataGridView_LiteraturQuellen.SelectedRows)
            {
                OList_LiteraturQuellen.Add((clsLiteraturQuelle)objDGVR_Selected.DataBoundItem);
                
            }
            appliedQuelle();

        }

        private void toolStripMenuItem_Literatur_Click(object sender, EventArgs e)
        {
            checkMenuitem(sender.ToString());
        }

        private void checkMenuitem(string menuItemName)
        {
            literaturquelleToolStripMenuItem.Checked = literaturquelleToolStripMenuItem.Text == menuItemName ? true : false;
            toolStripMenuItem_Literatur.Checked = toolStripMenuItem_Literatur.Text == menuItemName ? true : false;
            seiteToolStripMenuItem.Checked = seiteToolStripMenuItem.Text == menuItemName ? true : false;
            urlToolStripMenuItem.Checked = urlToolStripMenuItem.Text == menuItemName ? true : false;
            mediaItemToolStripMenuItem.Checked = mediaItemToolStripMenuItem.Text == menuItemName ? true : false;
            videoToolStripMenuItem.Checked = videoToolStripMenuItem.Text == menuItemName ? true : false;
            imageToolStripMenuItem.Checked = imageToolStripMenuItem.Text == menuItemName ? true : false;
            emailToolStripMenuItem.Checked = emailToolStripMenuItem.Text == menuItemName ? true : false;
            zeitschriftenausgabeToolStripMenuItem.Checked = zeitschriftenausgabeToolStripMenuItem.Text == menuItemName ? true : false;
            zeitschriftToolStripMenuItem.Checked = zeitschriftToolStripMenuItem.Text == menuItemName ? true : false;

            toolStripSplitButton_FilterTyp.Text = menuItemName;

            toolStripButton_AddFilter.Enabled = !seiteToolStripMenuItem.Checked;
        }

        private void seiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkMenuitem(sender.ToString());
        }

        private void urlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkMenuitem(sender.ToString());
        }

        private void mediaItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkMenuitem(sender.ToString());
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkMenuitem(sender.ToString());
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkMenuitem(sender.ToString());
        }

        private void zeitschriftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkMenuitem(sender.ToString());
        }

        private void zeitschriftenausgabeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkMenuitem(sender.ToString());
        }

        private void toolStripTextBox_Filter_TextChanged(object sender, EventArgs e)
        {
            timer_Filter.Stop();
            if (!toolStripTextBox_Filter.ReadOnly)
            {
                timer_Filter.Start();
            }
            
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkMenuitem(sender.ToString());
        }

        private void timer_Filter_Tick(object sender, EventArgs e)
        {
            timer_Filter.Stop();
            objOItem_Filter = new clsOntologyItem();


            if (toolStripTextBox_Filter.Text == "")
            {
                objOItem_Filter = null;
            }
            else
            {
                if (literaturquelleToolStripMenuItem.Checked)
                {
                    objOItem_Filter.Name = toolStripTextBox_Filter.Text;
                    objOItem_Filter.GUID_Parent = objLocalConfig.OItem_type_literarische_quelle.GUID;
                }
                else if (toolStripMenuItem_Literatur.Checked)
                {
                    objOItem_Filter.Name = toolStripTextBox_Filter.Text;
                    objOItem_Filter.GUID_Parent = objLocalConfig.OItem_type_literatur.GUID;
                }
                else if (seiteToolStripMenuItem.Checked)
                {
                    objOItem_Filter.Name = toolStripTextBox_Filter.Text;
                    objOItem_Filter.GUID_Parent = objLocalConfig.OItem_attribute_seite.GUID;
                }
                else if (urlToolStripMenuItem.Checked)
                {
                    objOItem_Filter.Name = toolStripTextBox_Filter.Text;
                    objOItem_Filter.GUID_Parent = objLocalConfig.OItem_type_url.GUID;
                }
                else if (mediaItemToolStripMenuItem.Checked)
                {
                    objOItem_Filter.Name = toolStripTextBox_Filter.Text;
                    objOItem_Filter.GUID_Parent = objLocalConfig.OItem_class_media_item.GUID;
                }
                else if (videoToolStripMenuItem.Checked)
                {
                    objOItem_Filter.Name = toolStripTextBox_Filter.Text;
                    objOItem_Filter.GUID_Parent = objLocalConfig.OItem_type_video.GUID;
                }
                else if (imageToolStripMenuItem.Checked)
                {
                    objOItem_Filter.Name = toolStripTextBox_Filter.Text;
                    objOItem_Filter.GUID_Parent = objLocalConfig.OItem_class_images__graphic_.GUID;
                }
                else if (emailToolStripMenuItem.Checked)
                {
                    objOItem_Filter.Name = toolStripTextBox_Filter.Text;
                    objOItem_Filter.GUID_Parent = objLocalConfig.OItem_class_e_mail.GUID;
                }
                else if (zeitschriftenausgabeToolStripMenuItem.Checked)
                {
                    objOItem_Filter.Name = toolStripTextBox_Filter.Text;
                    objOItem_Filter.GUID_Parent = objLocalConfig.OItem_type_zeitschriftenausgabe.GUID;
                }
                else if (zeitschriftToolStripMenuItem.Checked)
                {
                    objOItem_Filter.Name = toolStripTextBox_Filter.Text;
                    objOItem_Filter.GUID_Parent = objLocalConfig.OItem_class_zeitschrift.GUID;
                }
                else
                {
                    objOItem_Filter = null;
                }

                
            }

            
            FillDataGridView();
            
            

        }

        private void literaturquelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkMenuitem(sender.ToString());
        }

        private void typedTaggingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var objLiteraturQuelle = (clsLiteraturQuelle)dataGridView_LiteraturQuellen.SelectedRows[0].DataBoundItem;

            objFrmTypedTaggingSingle = new frmTypedTaggingSingle(objLocalConfig.Globals, objLocalConfig.User, objLocalConfig.Group,
                new clsOntologyItem
                {
                    GUID = objLiteraturQuelle.ID_LiteraturQuelle,
                    Name = objLiteraturQuelle.Name_LiteraturQuelle,
                    GUID_Parent = objLocalConfig.OItem_type_literarische_quelle.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                });
            objFrmTypedTaggingSingle.Show();
        }

        
    }
}
