using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using Structure_Module;

namespace Grid_Module
{
    public partial class frmGridModule : Form
    {
        private frmMain objFrmOntologyManager;

        private clsLocalConfig objLocalConfig;

        private clsDataWork_Grid objDataWork_Grid;

        private clsOntologyItem objOItem_BaseClass;

        public frmGridModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {
            objDataWork_Grid = new clsDataWork_Grid(objLocalConfig);
        }

        private void toolStripButton_AddClass_Click(object sender, EventArgs e)
        {
            objFrmOntologyManager = new frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class);
            objFrmOntologyManager.ShowDialog(this);

            if (objFrmOntologyManager.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (objFrmOntologyManager.OList_Simple.Count == 1 && objFrmOntologyManager.OList_Simple.First().Type == objLocalConfig.Globals.Type_Class)
                {
                    objOItem_BaseClass = objFrmOntologyManager.OList_Simple.First();

                    var objOItem_Result = objDataWork_Grid.GetData_ObjectsOfClass(objOItem_BaseClass);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var dataTable = new DataTable();
                        var col1 = dataTable.Columns.Add("GUID", System.Type.GetType("System.String"));
                        var col2 = dataTable.Columns.Add("Name", System.Type.GetType("System.String"));
                        var col3 = dataTable.Columns.Add("GUID_Parent", System.Type.GetType("System.String"));

                        var objectArray = objDataWork_Grid.ObjectsOfClass.Select(objects => new { GUID = objects.GUID, Name = objects.Name, objects.GUID_Parent }).ToArray();
                      
                        dataTable.Rows.Add(objectArray);

                        bindingSource_Grid.DataSource = dataTable;
                    }
                }
                else
                {
                    MessageBox.Show(this, "Wählen Sie bitte nur eine Klasse aus!", "Eine Klasse!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
    }
}
