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
using Structure_Module;

namespace TextParser
{
    public partial class UserControl_FieldParserView : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private clsOntologyItem objOItem_Parser;
        private clsOntologyItem objOItem_TextParser;

        private clsDataWork_FieldParser objDataWork_FieldParser;

        private clsFieldParser objFieldParser;

        private int page = 0;
        private int pages = 0;
        private int pos = 0;

        public UserControl_FieldParserView(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            
            objLocalConfig = LocalConfig;

            Initialize();
        }

        public void InitializeView(clsOntologyItem OItem_FieldParser, clsOntologyItem OItem_TextParser)
        {
            objOItem_Parser = OItem_FieldParser;
            objOItem_TextParser = OItem_TextParser;
            toolStripTextBox_Parser.Text = objOItem_Parser.Name;
            GetPage();
        }

        private void Initialize()
        {
            objDataWork_FieldParser = new clsDataWork_FieldParser(objLocalConfig);

            
        }

        private void GetPage()
        {
            var objOItem_Result = objDataWork_FieldParser.GetData_FieldsOfFieldParser();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var FieldList = new SortableBindingList<clsField>(objDataWork_FieldParser.FieldList.Where(p => p.ID_FieldParser == objOItem_Parser.GUID).OrderBy(f => f.OrderId).ThenBy(f => f.Name_Field));
                dataGridView_Fields.DataSource = FieldList;
                foreach (DataGridViewColumn column in dataGridView_Fields.Columns)
                {
                    if (column.Name == "ID_FieldParser" ||
                        column.Name == "ID_Field" ||
                        column.Name == "ID_RegExPre" ||
                        column.Name == "ID_Attribute_RegExPreVal" ||
                        column.Name == "ID_RegExMain" ||
                        column.Name == "ID_Attribute_RegExMainVal" ||
                        column.Name == "ID_RegExPost" ||
                        column.Name == "ID_Attribute_RegExPostVal" ||
                        column.Name == "ID_DataType" ||
                        column.Name == "ID_Attribute_UseOrderID" ||
                        column.Name == "ID_Attribute_RemoveFromSource" ||
                        column.Name == "ID_MetaField" ||
                        column.Name == "Name_MetaField")
                    {
                        column.Visible = false;
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Fehler beim Ermitteln der Daten!", "Fehler!", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }

        }

        private void toolStripButton_Parse_Click(object sender, EventArgs e)
        {
            var fieldList = (SortableBindingList<clsField>) dataGridView_Fields.DataSource;
            if (fieldList.Any())
            {
                objFieldParser = new clsFieldParser(objLocalConfig,fieldList.ToList(),objOItem_TextParser);

            }
        }

    }
}
