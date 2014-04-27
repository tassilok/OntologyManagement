using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using Structure_Module;

namespace Mathematische_Textaufgaben_Analyzer
{
    public partial class UserControl_MathmatischeTextaufgabe : UserControl
    {
        private clsDataWork_MathematischeTextaufgabe objDataWork_MathematischeTextaufgabe;

        private clsOntologyItem objOItem_Sachaufgabe;

        private clsLocalConfig objLocalConfig;

        public UserControl_MathmatischeTextaufgabe(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDataWork_MathematischeTextaufgabe = new clsDataWork_MathematischeTextaufgabe(objLocalConfig);
        }

        public void Initialize_MathematischeTextaufgabe(clsOntologyItem OItem_Sachaufgabe = null)
        {
            objOItem_Sachaufgabe = OItem_Sachaufgabe;
            ClearControls();

            var objOItem_Result = objDataWork_MathematischeTextaufgabe.GetData_Sachaufgabe(OItem_Sachaufgabe);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                dataGridView_Sachaufgaben.DataSource = new SortableBindingList<clsSachaufgabe>( objDataWork_MathematischeTextaufgabe.Sachaufgaben );
                foreach (DataGridViewColumn col in dataGridView_Sachaufgaben.Columns)
                {
                    if (col.Name == "Description")
                    {
                        col.Visible = true;
                    }
                    else
                    {
                        col.Visible = false;
                    }
                }

                toolStripLabel_CountSachaufgaben.Text = dataGridView_Sachaufgaben.RowCount.ToString();
            }
            else
            {
                MessageBox.Show(this, "Die Sachaufgabe(n) konnte(n) nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ClearControls()
        {
            toolStripButton_CreateOntology.Enabled = false;
            dataGridView_Sachaufgaben.DataSource = null;
        }

        private void dataGridView_Sachaufgaben_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_Sachaufgaben.SelectedRows.Count == 1)
            {
                var objSachaufgabe = (clsSachaufgabe)dataGridView_Sachaufgaben.SelectedRows[0].DataBoundItem;
                objOItem_Sachaufgabe = new clsOntologyItem
                {
                    GUID = objSachaufgabe.ID_Sachaufgabe,
                    Name = objSachaufgabe.Name_Sachaufgabe,
                    GUID_Parent = objLocalConfig.OItem_class_sachaufgabe.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                textBox_Sachaufgabe_Selected.Text = objSachaufgabe.Description;
            }
            else
            {
                objOItem_Sachaufgabe = null;
                textBox_Sachaufgabe_Selected.Text = "";
            }

            Configure_Tabs();
        }

        private void Configure_Tabs()
        {
            if (tabControl1.SelectedTab.Name == tabPage_MathematischeElemente.Name)
            {
                if (objOItem_Sachaufgabe != null)
                {
                    dataGridView_Elements.DataSource = new SortableBindingList<clsSachaufgabenelement> ( objDataWork_MathematischeTextaufgabe.SachaufgabenElemente.Where(se => se.ID_Sachaufgabe == objOItem_Sachaufgabe.GUID));
                    foreach (DataGridViewColumn col in dataGridView_Elements.Columns)
                    {
                        if (col.Name == "Name_Element" ||
                            col.Name == "Menge" ||
                            col.Name == "Name_Unit")
                        {
                            col.Visible = true;
                        }
                        else
                        {
                            col.Visible = false;
                        }
                    }
                }
                else
                {
                    dataGridView_Elements.DataSource = null;
                    toolStripLabel_CountElements.Text = "0";
                    
                }
            }
            else if (tabControl1.SelectedTab.Name == tabPage_Terme.Name)
            {
                if (objOItem_Sachaufgabe != null)
                {
                    dataGridView_Terms.DataSource = new SortableBindingList<clsTerm>(objDataWork_MathematischeTextaufgabe.Terms.Where(t => t.ID_Sachaufgabe == objOItem_Sachaufgabe.GUID));

                    foreach (DataGridViewColumn col in dataGridView_Terms.Columns)
                    {
                        if (col.Name == "Term" ||
                            col.Name == "Ergebnis")
                        {
                            col.Visible = true;
                        }
                        else
                        {
                            col.Visible = false;
                        }
                    }
                }
                else
                {
                    dataGridView_Terms.DataSource = null;
                    toolStripLabel_CountTerms.Text = "0";
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Configure_Tabs();
        }
    }
}
