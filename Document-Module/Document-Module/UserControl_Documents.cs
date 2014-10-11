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

namespace Document_Module
{
    public partial class UserControl_Documents : UserControl
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_Document objDataWork_Document;

        public UserControl_Documents(clsLocalConfig LocalConfig, clsDataWork_Document DataWork_Documents)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            objDataWork_Document = DataWork_Documents;

            Initialize();
        }

        private void Initialize()
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            bindingSource_Documents.DataSource = new SortableBindingList<clsDocument>(objDataWork_Document.Documents);
            dataGridView_Documents.DataSource = bindingSource_Documents;

            bindingNavigator_Documents.BindingSource = bindingSource_Documents;

            foreach (DataGridViewColumn col in dataGridView_Documents.Columns)
            {
                if (col.DataPropertyName == "ID_Document" ||
                    col.DataPropertyName == "ID_Attribute_CreationDate" ||
                    col.DataPropertyName == "ID_Version" ||
                    col.DataPropertyName == "ID_Attribute_Major" ||
                    col.DataPropertyName == "ID_Attribute_Minor" ||
                    col.DataPropertyName == "ID_Attribute_Build" ||
                    col.DataPropertyName == "ID_Attribute_Revision" ||
                    col.DataPropertyName == "ID_Autor")
                {
                    col.Visible = false;
                }
                else
                {
                    col.Visible = true;
                }
            }
        }
    }
}
