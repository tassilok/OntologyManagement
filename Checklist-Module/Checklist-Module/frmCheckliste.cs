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

        private List<clsLogEntry> objOList_LogEntries;

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

            if (!boolLogEntry_Succes)
            {
                var objDataColumn1 = new DataColumn("ID_LogEntry_Success");
                objDataColumn1.DataType= typeof(string);
                objDataTable.Columns.Add(objDataColumn1);

                var objDataColumn2 = new DataColumn("Name_LogEntry_Success");
                objDataColumn2.DataType = typeof(string);
                objDataTable.Columns.Add(objDataColumn2);

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

                var objDataColumn2 = new DataColumn("Name_LogEntry_Error");
                objDataColumn2.DataType = typeof(string);
                objDataTable.Columns.Add(objDataColumn2);

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

                var objDataColumn2 = new DataColumn("Name_LogEntry_Pause");
                objDataColumn2.DataType = typeof(string);
                objDataTable.Columns.Add(objDataColumn2);

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

                    if (objOList_LogEntries_Success.Any())
                    {
                        item["ID_LogEntry_Success"] = objOList_LogEntries_Success.First().ID_LogEntry;
                        item["Name_LogEntry_Success"] = objOList_LogEntries_Success.First().Name_LogEntry;
                        item["DateTimeStamp_Success"] = objOList_LogEntries_Success.First().DateTimeStamp;
                        item["DateTimeStamp_Success_Success_Seq"] = (long)objOList_LogEntries_Success.First().DateTimeStamp.Value.Year * 10000 +
                                                objOList_LogEntries_Success.First().DateTimeStamp.Value.Month * 100 +
                                                objOList_LogEntries_Success.First().DateTimeStamp.Value.Day;
                        item["IsDone"] = true;
                        item["Success_Year"] = objOList_LogEntries_Success.First().DateTimeStamp.Value.Year;
                        item["Success_Month"] = objOList_LogEntries_Success.First().DateTimeStamp.Value.Month;
                        item["Success_Day"] = objOList_LogEntries_Success.First().DateTimeStamp.Value.Day;
                        item["Success_Year"] = objOList_LogEntries_Success.First().DateTimeStamp.Value;
                        item["Succces_Week"] = GetCalendarweek(objOList_LogEntries_Success.First().DateTimeStamp.Value);

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
    }
}
