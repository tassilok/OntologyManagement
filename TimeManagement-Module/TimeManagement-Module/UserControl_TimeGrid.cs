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

namespace TimeManagement_Module
{
    

    public partial class UserControl_TimeGrid : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private clsDataWork_TimeManagement objDataWork_TimeManagement;

        private frmTimeManagementEdit objFrmTimeManagementEdit;

        private frm_ObjectEdit objFrmObjectEdit;
        private frmMain objFrmMain;

        public delegate void SelectedTimeItem();
        public event SelectedTimeItem selectedTimeItem;

        private clsOntologyItem objOItem_Ref;

        private bool pcChange;

        public UserControl_TimeGrid(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDataWork_TimeManagement = new clsDataWork_TimeManagement(objLocalConfig);
            objDataWork_TimeManagement.OItem_Ref = objOItem_Ref;
            objDataWork_TimeManagement.GetData_TimeManagement();

            if (objDataWork_TimeManagement.OItem_Result_TimeManagement.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                pcChange = true;
                bindingSource_TimeManagement.DataSource = objDataWork_TimeManagement.Tbl_TimeManagement;
                DataGridView_LogManagement.DataSource = bindingSource_TimeManagement;
                DataGridView_LogManagement.Columns[0].Visible = false;
                DataGridView_LogManagement.Columns[1].Visible = true;
                DataGridView_LogManagement.Columns[1].HeaderText = "Name";
                DataGridView_LogManagement.Columns[2].Visible = false;
                DataGridView_LogManagement.Columns[3].Visible = true;
                DataGridView_LogManagement.Columns[3].HeaderText = "Typ";
                DataGridView_LogManagement.Columns[4].Visible = false;
                DataGridView_LogManagement.Columns[5].Visible = true;
                DataGridView_LogManagement.Columns[6].Visible = true;
                DataGridView_LogManagement.Columns[6].HeaderText = "Wochentag (S)";
                DataGridView_LogManagement.Columns[7].Visible = false;
                DataGridView_LogManagement.Columns[8].Visible = true;
                DataGridView_LogManagement.Columns[9].Visible = true;
                DataGridView_LogManagement.Columns[9].HeaderText = "Wochentag (E)";
                DataGridView_LogManagement.Columns[10].Visible = true;
                DataGridView_LogManagement.Columns[10].HeaderText = "Hours";
                DataGridView_LogManagement.Columns[10].DefaultCellStyle.Format = "N2";
                DataGridView_LogManagement.Columns[11].Visible = true;
                DataGridView_LogManagement.Columns[11].HeaderText = "Minutes";
                DataGridView_LogManagement.Columns[11].DefaultCellStyle.Format = "N2";
                DataGridView_LogManagement.Columns[12].Visible = true;
                DataGridView_LogManagement.Columns[12].HeaderText = "Hours (Week)";
                DataGridView_LogManagement.Columns[12].DefaultCellStyle.Format = "N2";
                DataGridView_LogManagement.Columns[13].Visible = true;
                DataGridView_LogManagement.Columns[13].HeaderText = "Minutes (Week)";
                DataGridView_LogManagement.Columns[13].DefaultCellStyle.Format = "N2";
                DataGridView_LogManagement.Columns[14].Visible = true;
                DataGridView_LogManagement.Columns[14].HeaderText = "Hours (ToDo)";
                DataGridView_LogManagement.Columns[14].DefaultCellStyle.Format = "N2";
                DataGridView_LogManagement.Columns[15].Visible = true;
                DataGridView_LogManagement.Columns[15].HeaderText = "Minutes (ToDo)";
                DataGridView_LogManagement.Columns[15].DefaultCellStyle.Format = "N2";
                DataGridView_LogManagement.Columns[16].Visible = true;
                DataGridView_LogManagement.Columns[16].HeaderText = "Hours (ToDo/Week)";
                DataGridView_LogManagement.Columns[16].DefaultCellStyle.Format = "N2";
                DataGridView_LogManagement.Columns[17].Visible = true;
                DataGridView_LogManagement.Columns[17].HeaderText = "Minutes (ToDo/Week)";
                DataGridView_LogManagement.Columns[17].DefaultCellStyle.Format = "N2";
                DataGridView_LogManagement.Columns[18].Visible = true;
                DataGridView_LogManagement.Columns[18].HeaderText = "End (ToDo)";
                //DataGridView_LogManagement.Columns[18].DefaultCellStyle.Format = "N2";
                DataGridView_LogManagement.Columns[19].Visible = true;
                DataGridView_LogManagement.Columns[20].Visible = true;
                DataGridView_LogManagement.Columns[21].Visible = true;
                DataGridView_LogManagement.Columns[22].Visible = true;
                DataGridView_LogManagement.Columns[23].Visible = true;
                DataGridView_LogManagement.Columns[24].Visible = true;
                DataGridView_LogManagement.Columns[25].Visible = true;
                DataGridView_LogManagement.Columns[26].Visible = true;


                FilterView();
                SortView();

                pcChange = false;
            }
            else
            {
                MessageBox.Show(this, "Die Zeiten konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }

        private void FilterView()
        {
            var strFilter = "";
            if (toolStripTextBox_Filter.Text == "")
            {
                if (ToolStripDropDownButton_Range.Text == TodayToolStripMenuItem.Text)
                {
                    strFilter = "Year_Start=" + DateTime.Now.Year.ToString() + " AND Month_Start=" + DateTime.Now.Month.ToString() + " AND Day_Start=" + DateTime.Now.Day.ToString();
                    toolStripTextBox_Filter.Text = strFilter;
                    FilterView();
                }
                else if (ToolStripDropDownButton_Range.Text == YesterdayToolStripMenuItem.Text)
                {
                    strFilter = "Year_Start=" + DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)).Year + " AND Month_Start=" + DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)).Month + " AND Day_Start=" + DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)).Day;
                    toolStripTextBox_Filter.Text = strFilter;
                    FilterView();
                }
                else if (ToolStripDropDownButton_Range.Text == XThisWeekToolStripMenuItem.Text)
                {
                    var today = DateTime.Today;
                    var dayDiff = today.DayOfWeek - DayOfWeek.Monday;
                    var monday = today.AddDays(-dayDiff);
                    strFilter = "DateTimeStamp_Start_Seq>=" + (monday.Year * 10000 + monday.Month * 100 + monday.Day);
                    toolStripTextBox_Filter.Text = strFilter;
                    FilterView();
                }
                else if (ToolStripDropDownButton_Range.Text == LastTwoWeeksToolStripMenuItem.Text)
                {
                    var today = DateTime.Today;
                    var dayDiff = (today.Subtract(new TimeSpan(7, 0, 0, 0))).DayOfWeek - DayOfWeek.Monday;
                    var monday = (today.Subtract(new TimeSpan(7, 0, 0, 0))).AddDays(-dayDiff);
                    strFilter = "DateTimeStamp_Start_Seq>=" + (monday.Year * 10000 + monday.Month * 100 + monday.Day);
                    toolStripTextBox_Filter.Text = strFilter;
                    FilterView();
                }
                else if (ToolStripDropDownButton_Range.Text == XThisMonthToolStripMenuItem.Text)
                {
                    strFilter = "DateTimeStamp_Start_Seq>=" + (DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + 1);
                    toolStripTextBox_Filter.Text = strFilter;
                    FilterView();
                }
                else if (ToolStripDropDownButton_Range.Text == AllToolStripMenuItem.Text)
                {
                    toolStripTextBox_Filter.Text = "";
                    bindingSource_TimeManagement.RemoveFilter();
                }
            }
            else
            {
                strFilter = toolStripTextBox_Filter.Text;
                try
                {
                    bindingSource_TimeManagement.Filter = strFilter;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Der Filter ist ungültig!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bindingSource_TimeManagement.RemoveFilter();
                }
                

            }
        }

        private void SortView()
        {
            var strSort ="";
            if (toolStripTextBox_Sort.Text =="")
            {
                strSort = "Ende desc";
                toolStripTextBox_Sort.Text = strSort;
                SortView();
            }
            else
            {
                strSort = toolStripTextBox_Sort.Text;
                try
                {
                    bindingSource_TimeManagement.Sort = strSort;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Die Angabe der Sortierung ist fehlerhaft!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        
            
            
        }

        private void DataGridView_LogManagement_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DataGridView_LogManagement.Columns[e.ColumnIndex].DataPropertyName == "ToDo_Hours_Week" || 
                DataGridView_LogManagement.Columns[e.ColumnIndex].DataPropertyName == "ToDo_Minutes_Week" ||
                DataGridView_LogManagement.Columns[e.ColumnIndex].DataPropertyName == "ToDo_Hours_Day" ||
                DataGridView_LogManagement.Columns[e.ColumnIndex].DataPropertyName == "ToDo_Minutes_Day")
            {
                double dblValue = 0;

                if ( double.TryParse(e.Value.ToString(),out dblValue ))
                {
                    if (dblValue > 0)
                    {
                        DataGridView_LogManagement.Rows[e.RowIndex].Cells[DataGridView_LogManagement.Columns[e.ColumnIndex].DataPropertyName].Style.BackColor = Color.Yellow;
                        DataGridView_LogManagement.Rows[e.RowIndex].Cells[DataGridView_LogManagement.Columns[e.ColumnIndex].DataPropertyName].Style.ForeColor = Color.Black;
                    }
                    
                }
                
            }
        
            
        
        }

        private void ContextMenuStrip_TimeManagement_Opening(object sender, CancelEventArgs e)
        {
            EditToolStripMenuItem.Enabled = false;

            if (DataGridView_LogManagement.SelectedRows.Count == 1)
            {
                EditToolStripMenuItem.Enabled = true;
            }
            
        
        
            if (DataGridView_LogManagement.SelectedCells.Count==1)
            {
                if (DataGridView_LogManagement.SelectedCells[0].OwningColumn.DataPropertyName == "Name_Log_Management" ||
                    DataGridView_LogManagement.SelectedCells[0].OwningColumn.DataPropertyName == "Name_LogState_TimeManagement"  ||
                    DataGridView_LogManagement.SelectedCells[0].OwningColumn.DataPropertyName == "Start" ||
                    DataGridView_LogManagement.SelectedCells[0].OwningColumn.DataPropertyName == "Ende")
                {
                    EditToolStripMenuItem.Enabled = true;
                }
            }
            
        
        }

        private void ConfigureCalculation(ToolStripMenuItem menuItem = null)
        {
            if (menuItem != null)
            {
                ToolStripDropDownButton_Calc.Text = menuItem.Text;
            }
            else
            {
                ToolStripDropDownButton_Calc.Text = ToolStripMenuItem_CalcAdd.Text;
            }
            
            Calculate();
        }

        private void Calculate()
        {
            double calcTest;
            double calculation = 0;
            var first = true;

            if (DataGridView_LogManagement.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in DataGridView_LogManagement.SelectedCells)
                {
                    if (!Double.TryParse(cell.Value.ToString(), out calcTest))
                    {
                        ToolStripTextBox_Calculation.Text = "";
                        return;
                    }
                    else
                    {
                        try
                        {
                            if (ToolStripDropDownButton_Calc.Text == ToolStripMenuItem_Calc_Mult.Text)
                            {
                                if (first)
                                {
                                    calculation = calcTest;
                                    first = false;
                                }
                                else
                                {
                                    calculation = calculation * calcTest;
                                }

                            }
                            else if (ToolStripDropDownButton_Calc.Text == ToolStripMenuItem_CalcAdd.Text ||
                                     ToolStripDropDownButton_Calc.Text == ToolStripMenuItem_AVG.Text)
                            {
                                calculation = calculation + calcTest;
                            }
                        }
                        catch (Exception ex)
                        {
                            ToolStripTextBox_Calculation.Text = "";
                            return;
                        }
                    }
                }

                if (ToolStripDropDownButton_Calc.Text == ToolStripMenuItem_AVG.Text)
                {
                    calculation = calculation / DataGridView_LogManagement.SelectedCells.Count;
                }
                ToolStripTextBox_Calculation.Text = calculation.ToString();
            }
            else
            {
                ToolStripTextBox_Calculation.Text = "";
            }
        }

        private void DataGridView_LogManagement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Calculate();
        }

        private void ToolStripMenuItem_AVG_Click(object sender, EventArgs e)
        {
            ConfigureCalculation(ToolStripMenuItem_AVG);
        }

        private void ToolStripMenuItem_Calc_Mult_Click(object sender, EventArgs e)
        {
            ConfigureCalculation(ToolStripMenuItem_Calc_Mult);
        }

        private void ToolStripMenuItem_CalcAdd_Click(object sender, EventArgs e)
        {
            ConfigureCalculation(ToolStripMenuItem_CalcAdd);
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objFrmTimeManagementEdit = new frmTimeManagementEdit(null, objLocalConfig);
            objFrmTimeManagementEdit.ShowDialog(this);
            if (objFrmTimeManagementEdit.DialogResult == DialogResult.OK)
            {
                Initialize();
                ConfigureCalculation();
            }
            
        }

        private void DataGridView_LogManagement_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow objDGVR = DataGridView_LogManagement.Rows[e.RowIndex];
            DataRowView objDRV = (DataRowView)objDGVR.DataBoundItem;

            var objOList_Objects = new List<clsOntologyItem>
                {
                    new clsOntologyItem
                        {
                            GUID = objDRV["ID_TimeManagement"].ToString(),
                            Name = objDRV["Name_TimeManagement"].ToString(),
                            GUID_Parent = objLocalConfig.OItem_class_timemanagement.GUID,
                            Type =  objLocalConfig.Globals.Type_Object
                        }
                };

            objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals,objOList_Objects,0,objLocalConfig.Globals.Type_Object,null);
            objFrmObjectEdit.ShowDialog(this);

        }

        private void DataGridView_LogManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Initialize();    
            }
        }

        private void TodayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox_Filter.Text = "";
            ToolStripDropDownButton_Range.Text = TodayToolStripMenuItem.Text;
            FilterView();
        }

        private void YesterdayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox_Filter.Text = "";
            ToolStripDropDownButton_Range.Text = YesterdayToolStripMenuItem.Text;
            FilterView();
        }

        private void XThisWeekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox_Filter.Text = "";
            ToolStripDropDownButton_Range.Text = XThisWeekToolStripMenuItem.Text;
            FilterView();
        }

        private void LastTwoWeeksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox_Filter.Text = "";
            ToolStripDropDownButton_Range.Text = LastTwoWeeksToolStripMenuItem.Text;
            FilterView();
        }

        private void XThisMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox_Filter.Text = "";
            ToolStripDropDownButton_Range.Text = XThisMonthToolStripMenuItem.Text;
            FilterView();
        }

        private void AllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox_Filter.Text = "";
            ToolStripDropDownButton_Range.Text = AllToolStripMenuItem.Text;
            FilterView();
        }

        private void toolStripTextBox_Filter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FilterView();
            }
        }

        private void DataGridView_LogManagement_SelectionChanged(object sender, EventArgs e)
        {
            if (!pcChange) selectedTimeItem();
        }

        private void toolStripButton_AddRef_Click(object sender, EventArgs e)
        {
            objFrmMain = new frmMain(objLocalConfig.Globals);
            objFrmMain.ShowDialog(this);
            if (objFrmMain.DialogResult == DialogResult.OK)
            {
                if (objFrmMain.OList_Simple.Count == 1)
                {
                    objOItem_Ref = objFrmMain.OList_Simple.First();
                    toolStripTextBox_Ref.Text = objOItem_Ref.Name;
                    Initialize();
                }
                else
                {
                    MessageBox.Show(this, "Bitte nur ein Item auswählen!", "Nur ein Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void toolStripButton_RemoveFilterRef_Click(object sender, EventArgs e)
        {
            objOItem_Ref = null;
            toolStripTextBox_Ref.Text = "";
            Initialize();
        }

    }
}
