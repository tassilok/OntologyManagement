using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Structure_Module;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using Report_Module;
using System.Reflection;
using Schriftverkehrs_Module.ClassAttributes;

namespace Schriftverkehrs_Module
{
    public class DataSourceConnector
    {
        private clsGlobals objGlobals = new clsGlobals();

        public DataGridView dataGridView { get; private set; }

        public List<clsFilter> Filters { get; set; }
        public List<string> FilterIDs { get; set; }
        public bool FilterWithIds { get; set; }

        public ConnectorTag FilterConnector { get; set; }

        public clsOntologyItem Initialize_Report(List<clsSchriftverkehr> reportList)
        {
            var bindingSource = new SortableBindingList<clsSchriftverkehr>(reportList.Where(rl => rl.Filter(Filters, FilterConnector )));
            if (!bindingSource.Any(er => er.FilterError))
            {
                if (FilterWithIds)
                {
                    bindingSource = new SortableBindingList<clsSchriftverkehr> (from report in bindingSource
                                     join filterId in FilterIDs on report.ID_Schriftverkehr equals filterId
                                     select report);
                }
                dataGridView.DataSource = bindingSource;

                return objGlobals.LState_Success.Clone();
            }
            else
            {
                bindingSource = new SortableBindingList<clsSchriftverkehr>(reportList);
                if (FilterWithIds)
                {
                    bindingSource = new SortableBindingList<clsSchriftverkehr> (from report in bindingSource
                                     join filterId in FilterIDs on report.ID_Schriftverkehr equals filterId
                                     select report);
                }
                dataGridView.DataSource = bindingSource;

                return objGlobals.LState_Error.Clone();
            }
    
        }

        public clsOntologyItem Configure_Report(List<clsReportField> reportFields = null)
        {
            if (reportFields != null)
            {
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    var reportFieldsFound = reportFields.Where(rf => rf.Name_Col.ToLower() == column.DataPropertyName);
                    if (reportFieldsFound.Any())
                    {
                        column.Visible = reportFieldsFound.First().Visible;
                        column.HeaderText = reportFieldsFound.First().Name_RepField;
                        column.DisplayIndex = reportFieldsFound.First().OrderID;
                        if (reportFieldsFound.First().Name_FieldFormat != null)
                        {
                            column.DefaultCellStyle.Format = reportFieldsFound.First().Name_FieldFormat;
                        }

                    }
                }
            }
            else
            {
                var propertyInfos = typeof(clsSchriftverkehr).GetProperties().ToList();

                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    foreach(PropertyInfo propertyInfo in propertyInfos)
                    {
                        if (propertyInfo.Name == column.DataPropertyName)
                        {
                            var visibilityAttribute = propertyInfo.GetCustomAttribute<VisibilityAttribute>();
                            if (visibilityAttribute != null)
                            {
                                column.Visible = visibilityAttribute.Visible;
                            }
                            else
                            {
                                column.Visible = false;
                            }

                            var columnAttribute = propertyInfo.GetCustomAttribute<ColumnAttribute>();
                            if (columnAttribute != null)
                            {

                                column.HeaderText = columnAttribute.ColumnHeader != null ? columnAttribute.ColumnHeader : column.HeaderText;
                                column.DisplayIndex = columnAttribute.DisplayIx;
                                column.DefaultCellStyle.Format = columnAttribute.Format != null ? columnAttribute.Format : column.DefaultCellStyle.Format;

                            }
                        }
                        
                        
                    }
                }
            }
            

            return objGlobals.LState_Success.Clone();
        }

        public DataSourceConnector(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
            Filters = new List<clsFilter>();
            FilterIDs = new List<string>();
        }

    }
}
