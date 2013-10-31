using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Report_Module;
using OntologyClasses.BaseClasses;
using System.Linq;
using Log_Module;
using System.Globalization;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Checklist_Module
{
    public partial class frmCheckliste : Form
    {
        private clsLocalConfig objLocalConfig;
        private UserControl_Report objUserControl_Report;

        private clsOntologyItem objOItem_Report;
        private clsOntologyItem objOItem_WorkingList;
        private clsOntologyItem objOItem_ReportField;

        private clsDataWork_Checklists objDataWork_Checklists;

        private clsDataWork_LogEntry objDataWork_LogEntry;

        private frmLogDialog objFrmLogDialog;

        private List<clsLogEntry> objOList_LogEntries;

        private clsLogManagement objLogManagement;

        private clsTransaction objTransaction;

        public frmCheckliste(clsLocalConfig LocalConfig, clsOntologyItem OItem_Report, clsOntologyItem OItem_WorkingList, clsOntologyItem OItem_ReportField, clsDataWork_Checklists DataWork_Checklists)
        {
            InitializeComponent();

            objOItem_Report = OItem_Report;
            objOItem_ReportField = OItem_ReportField;
            objOItem_WorkingList = OItem_WorkingList;
            objLocalConfig = LocalConfig;
            objDataWork_Checklists = DataWork_Checklists;
            Initialize();
        }

        private void Initialize()
        {
            objDataWork_LogEntry = new clsDataWork_LogEntry(objLocalConfig.Globals);
            objUserControl_Report = new UserControl_Report(objLocalConfig.Globals);
            objUserControl_Report.initialize(objOItem_Report);
            objUserControl_Report.Dock = DockStyle.Fill;
            objUserControl_Report.DataLoaded += objUserControl_Report_DataLoaded;
            objUserControl_Report.SelectionChanged += objUserControl_Report_SelectionChanged;
            toolStripContainer1.ContentPanel.Controls.Add(objUserControl_Report);
            objOList_LogEntries = objDataWork_LogEntry.get_Data_LogEntries();
            objLogManagement = new clsLogManagement(objLocalConfig.Globals);
            objTransaction = new clsTransaction(objLocalConfig.Globals);
        }

        void objUserControl_Report_SelectionChanged()
        {
            toolStripButton_Success.Enabled = false;
            toolStripButton_Error.Enabled = false;
            toolStripButton_Pause.Enabled = false;

            if (objUserControl_Report.DataGridViewRow_Selected.Count > 0)
            {
                IEnumerable<Boolean> isDones = objUserControl_Report.DataGridViewRow_Selected.Cast<DataGridViewRow>()
                    .Where(p => !DBNull.Value.Equals(p.Cells["IsDone"].Value))
                    .Where(p => (Boolean)p.Cells["IsDone"].Value)
                    .Select(p =>  (Boolean)p.Cells["IsDone"].Value);
                if (!isDones.Any())
                {
                    toolStripButton_Success.Enabled = true;
                }
                
                toolStripButton_Error.Enabled = true;
                toolStripButton_Pause.Enabled = true;
            }
        }

        void objUserControl_Report_DataLoaded()
        {
            var objDataTable = objUserControl_Report.DataTableSelected;

            var boolLogEntry_Succes = false;
            var boolLogEntry_Error = false;
            var boolLogEntry_Pause = false;

            foreach (DataColumn column in objDataTable.Columns)
            {
                if (column.ColumnName.ToLower() == "ID_LogEntry_Success".ToLower())
                {
                    boolLogEntry_Succes = true;
                }

                if (column.ColumnName.ToLower() == "ID_LogEntry_Error".ToLower())
                {
                    boolLogEntry_Error = true;
                }

                if (column.ColumnName.ToLower() == "ID_LogEntry_Pause".ToLower())
                {
                    boolLogEntry_Pause = true;
                }
            }

            var objDataColumnToDo = new DataColumn("ToDo");
            objDataColumnToDo.DataType = typeof(Boolean);
            objDataTable.Columns.Add(objDataColumnToDo);

            var objDataColumnDone = new DataColumn("IsDone");
            objDataColumnDone.DataType = typeof(Boolean);
            objDataTable.Columns.Add(objDataColumnDone);

            var objDataColumnStarted = new DataColumn("Started");
            objDataColumnStarted.DataType = typeof(Boolean);
            objDataTable.Columns.Add(objDataColumnStarted);

            if (!boolLogEntry_Succes)
            {
                var objDataColumn1 = new DataColumn("ID_LogEntry_Success");
                objDataColumn1.DataType= typeof(string);
                objDataTable.Columns.Add(objDataColumn1);
                objUserControl_Report.VisibilityColumn("ID_LogEntry_Success", false);

                var objDataColumn2 = new DataColumn("Name_LogEntry_Success");
                objDataColumn2.DataType = typeof(string);
                objDataTable.Columns.Add(objDataColumn2);
                objUserControl_Report.VisibilityColumn("Name_LogEntry_Success", false);

                var objDataColumn3 = new DataColumn("DateTimeStamp_Success");
                objDataColumn3.DataType = typeof(DateTime);
                objDataTable.Columns.Add(objDataColumn3);

                var objDataColumn5 = new DataColumn("DateTimeStamp_Success_Seq");
                objDataColumn5.DataType = typeof(long);
                objDataTable.Columns.Add(objDataColumn5);

                var objDataColumn6 = new DataColumn("Success_Year");
                objDataColumn6.DataType = typeof(int);
                objDataTable.Columns.Add(objDataColumn6);

                var objDataColumn7 = new DataColumn("Success_Month");
                objDataColumn7.DataType = typeof(int);
                objDataTable.Columns.Add(objDataColumn7);

                var objDataColumn8 = new DataColumn("Success_Day");
                objDataColumn8.DataType = typeof(int);
                objDataTable.Columns.Add(objDataColumn8);

                var objDataColumn9 = new DataColumn("Success_Week");
                objDataColumn9.DataType = typeof(int);
                objDataTable.Columns.Add(objDataColumn9);
            }

            if (!boolLogEntry_Error)
            {
                var objDataColumn1 = new DataColumn("ID_LogEntry_Error");
                objDataColumn1.DataType = typeof(string);
                objDataTable.Columns.Add(objDataColumn1);
                objUserControl_Report.VisibilityColumn("ID_LogEntry_Error", false);

                var objDataColumn2 = new DataColumn("Name_LogEntry_Error");
                objDataColumn2.DataType = typeof(string);
                objDataTable.Columns.Add(objDataColumn2);
                objUserControl_Report.VisibilityColumn("Name_LogEntry_Error", false);

                var objDataColumn3 = new DataColumn("DateTimeStamp_Error");
                objDataColumn3.DataType = typeof(DateTime);
                objDataTable.Columns.Add(objDataColumn3);

                var objDataColumn5 = new DataColumn("DateTimeStamp_Error_Seq");
                objDataColumn5.DataType = typeof(long);
                objDataTable.Columns.Add(objDataColumn5);

                var objDataColumn6 = new DataColumn("Error_Year");
                objDataColumn6.DataType = typeof(int);
                objDataTable.Columns.Add(objDataColumn6);

                var objDataColumn7 = new DataColumn("Error_Month");
                objDataColumn7.DataType = typeof(int);
                objDataTable.Columns.Add(objDataColumn7);

                var objDataColumn8 = new DataColumn("Error_Day");
                objDataColumn8.DataType = typeof(int);
                objDataTable.Columns.Add(objDataColumn8);

                var objDataColumn9 = new DataColumn("Error_Week");
                objDataColumn9.DataType = typeof(int);
                objDataTable.Columns.Add(objDataColumn9);
            }

            if (!boolLogEntry_Pause)
            {
                var objDataColumn1 = new DataColumn("ID_LogEntry_Pause");
                objDataColumn1.DataType = typeof(string);
                objDataTable.Columns.Add(objDataColumn1);
                objUserControl_Report.VisibilityColumn("ID_LogEntry_Pause", false);

                var objDataColumn2 = new DataColumn("Name_LogEntry_Pause");
                objDataColumn2.DataType = typeof(string);
                objDataTable.Columns.Add(objDataColumn2);
                objUserControl_Report.VisibilityColumn("Name_LogEntry_Pause", false);

                var objDataColumn3 = new DataColumn("DateTimeStamp_Pause");
                objDataColumn3.DataType = typeof(DateTime);
                objDataTable.Columns.Add(objDataColumn3);

                var objDataColumn5 = new DataColumn("DateTimeStamp_Pause_Seq");
                objDataColumn5.DataType = typeof(long);
                objDataTable.Columns.Add(objDataColumn5);

                var objDataColumn6 = new DataColumn("Pause_Year");
                objDataColumn6.DataType = typeof(int);
                objDataTable.Columns.Add(objDataColumn6);

                var objDataColumn7 = new DataColumn("Pause_Month");
                objDataColumn7.DataType = typeof(int);
                objDataTable.Columns.Add(objDataColumn7);

                var objDataColumn8 = new DataColumn("Pause_Day");
                objDataColumn8.DataType = typeof(int);
                objDataTable.Columns.Add(objDataColumn8);

                var objDataColumn9 = new DataColumn("Pause_Week");
                objDataColumn9.DataType = typeof(int);
                objDataTable.Columns.Add(objDataColumn9);
            }
            GetDataLogEntries();
        }

        private void GetDataLogEntries()
        {
            var objOList_LogEntries_WorkingList = objDataWork_Checklists.GetData_WorkingListToLogEntry(objOItem_WorkingList);
            var objOList_LogEntries_Show = (from objLogEntry in objOList_LogEntries
                                            join objLogEntryOfWorkingList in objOList_LogEntries_WorkingList on objLogEntry.ID_LogEntry equals objLogEntryOfWorkingList.ID_Other
                                            select objLogEntry).ToList();

            foreach (DataRow item in objUserControl_Report.DataTableSelected.Rows)
            {
                try
                {
                    var objOItem_Ref = new clsOntologyItem { GUID = item[objOItem_ReportField.Name].ToString()};

                    var objOList_LogEntries_To_Ref = objDataWork_Checklists.GetData_LogEntriesToRef(objOItem_Ref);


                    var objOList_LogEntries_Success = ((from objLogEntryOfWorkingList in objOList_LogEntries_Show
                                               join objLogEntryOfRef in objOList_LogEntries_To_Ref on objLogEntryOfWorkingList.ID_LogEntry equals objLogEntryOfRef.ID_Object
                                                select objLogEntryOfWorkingList)
                                                .Where(p => p.ID_LogState == objLocalConfig.OItem_object_success.GUID)).ToList()
                                                .OrderByDescending(p => p.DateTimeStamp)
                                                .ToList();

                    var objOList_LogEntries_Error = ((from objLogEntryOfWorkingList in objOList_LogEntries_Show
                                                        join objLogEntryOfRef in objOList_LogEntries_To_Ref on objLogEntryOfWorkingList.ID_LogEntry equals objLogEntryOfRef.ID_Object
                                                        select objLogEntryOfWorkingList)
                                                .Where(p => p.ID_LogState == objLocalConfig.OItem_object_error.GUID)).ToList()
                                                .OrderByDescending(p => p.DateTimeStamp)
                                                .ToList();

                    var objOList_LogEntries_Pause = ((from objLogEntryOfWorkingList in objOList_LogEntries_Show
                                                        join objLogEntryOfRef in objOList_LogEntries_To_Ref on objLogEntryOfWorkingList.ID_LogEntry equals objLogEntryOfRef.ID_Object
                                                        select objLogEntryOfWorkingList)
                                                .Where(p => p.ID_LogState == objLocalConfig.OItem_object_pause.GUID)).ToList()
                                                .OrderByDescending(p => p.DateTimeStamp)
                                                .ToList();
                    var dateTimeDone = DateTime.Parse("01.01.1900");

                    item["IsDone"] = false;
                    item["ToDo"] = true;
                    item["Started"] = false;
                    if (objOList_LogEntries_Success.Any())
                    {
                        item["ID_LogEntry_Success"] = objOList_LogEntries_Success.First().ID_LogEntry;
                        item["Name_LogEntry_Success"] = objOList_LogEntries_Success.First().Name_LogEntry;
                        item["DateTimeStamp_Success"] = objOList_LogEntries_Success.First().DateTimeStamp;
                        item["DateTimeStamp_Success_Seq"] = (long)objOList_LogEntries_Success.First().DateTimeStamp.Value.Year * 10000 +
                                                objOList_LogEntries_Success.First().DateTimeStamp.Value.Month * 100 +
                                                objOList_LogEntries_Success.First().DateTimeStamp.Value.Day;
                        item["IsDone"] = true;
                        item["ToDo"] = false;
                        dateTimeDone = (DateTime)objOList_LogEntries_Success.First().DateTimeStamp;
                        item["Success_Year"] = objOList_LogEntries_Success.First().DateTimeStamp.Value.Year;
                        item["Success_Month"] = objOList_LogEntries_Success.First().DateTimeStamp.Value.Month;
                        item["Success_Day"] = objOList_LogEntries_Success.First().DateTimeStamp.Value.Day;
                        item["Success_Week"] = GetCalendarweek(objOList_LogEntries_Success.First().DateTimeStamp.Value);
                        item["Started"] = true;
                    }

                    if (objOList_LogEntries_Error.Any())
                    {
                        item["ID_LogEntry_Error"] = objOList_LogEntries_Error.First().ID_LogEntry;
                        item["Name_LogEntry_Error"] = objOList_LogEntries_Error.First().Name_LogEntry;
                        item["DateTimeStamp_Error"] = objOList_LogEntries_Error.First().DateTimeStamp;
                        item["DateTimeStamp_Error_Seq"] = (long)objOList_LogEntries_Error.First().DateTimeStamp.Value.Year * 10000 +
                                                objOList_LogEntries_Error.First().DateTimeStamp.Value.Month * 100 +
                                                objOList_LogEntries_Error.First().DateTimeStamp.Value.Day;
                        if (dateTimeDone < (DateTime)objOList_LogEntries_Error.First().DateTimeStamp)
                        {
                            dateTimeDone = (DateTime)objOList_LogEntries_Error.First().DateTimeStamp;
                            item["IsDone"] = false;
                            item["ToDo"] = true;
                        }
                            
                        item["Error_Year"] = objOList_LogEntries_Error.First().DateTimeStamp.Value.Year;
                        item["Error_Month"] = objOList_LogEntries_Error.First().DateTimeStamp.Value.Month;
                        item["Error_Day"] = objOList_LogEntries_Error.First().DateTimeStamp.Value.Day;
                        item["Error_Week"] = GetCalendarweek(objOList_LogEntries_Error.First().DateTimeStamp.Value);
                        item["Started"] = true;
                    }

                    if (objOList_LogEntries_Pause.Any())
                    {
                        item["ID_LogEntry_Pause"] = objOList_LogEntries_Pause.First().ID_LogEntry;
                        item["Name_LogEntry_Pause"] = objOList_LogEntries_Pause.First().Name_LogEntry;
                        item["DateTimeStamp_Pause"] = objOList_LogEntries_Pause.First().DateTimeStamp;
                        item["DateTimeStamp_Pause_Seq"] = (long)objOList_LogEntries_Pause.First().DateTimeStamp.Value.Year * 10000 +
                                                objOList_LogEntries_Pause.First().DateTimeStamp.Value.Month * 100 +
                                                objOList_LogEntries_Pause.First().DateTimeStamp.Value.Day;

                        if (dateTimeDone < (DateTime)objOList_LogEntries_Pause.First().DateTimeStamp)
                        {
                            dateTimeDone = (DateTime)objOList_LogEntries_Pause.First().DateTimeStamp;
                            item["IsDone"] = false;
                            item["ToDo"] = true;
                        }

                        item["Pause_Year"] = objOList_LogEntries_Pause.First().DateTimeStamp.Value.Year;
                        item["Pause_Month"] = objOList_LogEntries_Pause.First().DateTimeStamp.Value.Month;
                        item["Pause_Day"] = objOList_LogEntries_Pause.First().DateTimeStamp.Value.Day;
                        item["Pause_Week"] = GetCalendarweek(objOList_LogEntries_Pause.First().DateTimeStamp.Value);
                        item["Started"] = true;
                    }

                }
                catch(Exception ex)
                {
                }
                
            }
        }

        /// <summary>
        /// Gets the calendarweek.
        /// </summary>
        /// <param name="datetime">The datetime.</param>
        /// <returns>the calendarweek</returns>
        private static int GetCalendarweek(DateTime datetime)
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            int calendarweek = culture.Calendar.GetWeekOfYear(datetime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return calendarweek;
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton_Success_Click(object sender, EventArgs e)
        {
            CreateLog(objLocalConfig.OItem_object_success);
        }

        private void CreateLog(clsOntologyItem OItem_LogState)
        {
            objFrmLogDialog = new frmLogDialog();
            objFrmLogDialog.ShowDialog(this);
            if (objFrmLogDialog.DialogResult == DialogResult.OK)
            {
                foreach (DataGridViewRow objViewRow in objUserControl_Report.DataGridViewRow_Selected)
                {
                    DataRowView objDataRow = (DataRowView)objViewRow.DataBoundItem;
                    var objOItem_OntologyItem = objDataWork_Checklists.GetOntologyItemByGUID(objDataRow[objOItem_ReportField.Name].ToString());
                    if (objOItem_OntologyItem != null)
                    {
                        var objOItem_Result = objLogManagement.log_Entry(objFrmLogDialog.DateTimeStamp, OItem_LogState, objLocalConfig.User, objFrmLogDialog.Message);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objTransaction.ClearItems();
                            var objOItem_LogEntry = objLogManagement.OItem_LogEntry;
                            var ORel_WorkingList_To_LogEntry = objDataWork_Checklists.Rel_WorkingList_To_LogEntry(objOItem_WorkingList, objOItem_LogEntry);
                            objOItem_Result = objTransaction.do_Transaction(ORel_WorkingList_To_LogEntry);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                var ORel_LogEntry_To_Rel = objDataWork_Checklists.Rel_LogEntry_To_Ref(objOItem_LogEntry, objOItem_OntologyItem);
                                objOItem_Result = objTransaction.do_Transaction(ORel_LogEntry_To_Rel);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    if (OItem_LogState.GUID == objLocalConfig.OItem_object_success.GUID)
                                    {
                                        objDataRow["ID_LogEntry_Success"] = objOItem_LogEntry.GUID;
                                        objDataRow["Name_LogEntry_Success"] = objOItem_LogEntry.Name;
                                        objDataRow["DateTimeStamp_Success"] = objFrmLogDialog.DateTimeStamp;
                                        objDataRow["DateTimeStamp_Success_Seq"] = (long)objFrmLogDialog.DateTimeStamp.Year * 10000 +
                                                                objFrmLogDialog.DateTimeStamp.Month * 100 +
                                                                objFrmLogDialog.DateTimeStamp.Day;
                                        objDataRow["IsDone"] = true;
                                        objDataRow["ToDo"] = false;
                                        objDataRow["Success_Year"] = objFrmLogDialog.DateTimeStamp.Year;
                                        objDataRow["Success_Month"] = objFrmLogDialog.DateTimeStamp.Month;
                                        objDataRow["Success_Day"] = objFrmLogDialog.DateTimeStamp.Day;
                                        objDataRow["Success_Week"] = GetCalendarweek(objFrmLogDialog.DateTimeStamp);
                                    }
                                    else if (OItem_LogState.GUID == objLocalConfig.OItem_object_error.GUID)
                                    {
                                        objDataRow["ID_LogEntry_Error"] = objOItem_LogEntry.GUID;
                                        objDataRow["Name_LogEntry_Error"] = objOItem_LogEntry.Name;
                                        objDataRow["DateTimeStamp_Error"] = objFrmLogDialog.DateTimeStamp;
                                        objDataRow["DateTimeStamp_Error_Seq"] = (long)objFrmLogDialog.DateTimeStamp.Year * 10000 +
                                                                objFrmLogDialog.DateTimeStamp.Month * 100 +
                                                                objFrmLogDialog.DateTimeStamp.Day;
                                        objDataRow["IsDone"] = false;
                                        objDataRow["ToDo"] = true;
                                        objDataRow["Error_Year"] = objFrmLogDialog.DateTimeStamp.Year;
                                        objDataRow["Error_Month"] = objFrmLogDialog.DateTimeStamp.Month;
                                        objDataRow["Error_Day"] = objFrmLogDialog.DateTimeStamp.Day;
                                        objDataRow["Error_Week"] = GetCalendarweek(objFrmLogDialog.DateTimeStamp);
                                    }
                                    else if (OItem_LogState.GUID == objLocalConfig.OItem_object_pause.GUID)
                                    {
                                        objDataRow["ID_LogEntry_Pause"] = objOItem_LogEntry.GUID;
                                        objDataRow["Name_LogEntry_Pause"] = objOItem_LogEntry.Name;
                                        objDataRow["DateTimeStamp_Pause"] = objFrmLogDialog.DateTimeStamp;
                                        objDataRow["DateTimeStamp_Pause_Seq"] = (long)objFrmLogDialog.DateTimeStamp.Year * 10000 +
                                                                objFrmLogDialog.DateTimeStamp.Month * 100 +
                                                                objFrmLogDialog.DateTimeStamp.Day;
                                        objDataRow["IsDone"] = false;
                                        objDataRow["ToDo"] = true;
                                        objDataRow["Pause_Year"] = objFrmLogDialog.DateTimeStamp.Year;
                                        objDataRow["Pause_Month"] = objFrmLogDialog.DateTimeStamp.Month;
                                        objDataRow["Pause_Day"] = objFrmLogDialog.DateTimeStamp.Day;
                                        objDataRow["Pause_Week"] = GetCalendarweek(objFrmLogDialog.DateTimeStamp);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(this, "Der Eintrag konnte nicht geloggt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    objTransaction.rollback();
                                    objLogManagement.del_LogEntry(objOItem_LogEntry);
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Der Eintrag konnte nicht geloggt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                objLogManagement.del_LogEntry(objOItem_LogEntry);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Die Referenz konnte nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void toolStripButton_Pause_Click(object sender, EventArgs e)
        {
            CreateLog(objLocalConfig.OItem_object_pause);
        }

        private void toolStripButton_Error_Click(object sender, EventArgs e)
        {
            CreateLog(objLocalConfig.OItem_object_error);
        }
    }
}
