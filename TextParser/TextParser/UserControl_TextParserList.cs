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
using Structure_Module;

namespace TextParser
{

    public partial class UserControl_TextParserList : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private clsDataWork_TextParser objDataWork_TextParser;
        public List<clsOntologyItem> OList_TextParsers { get; set; }

        private clsOntologyItem objOItem_Ref;


        public delegate void SelectedTextParser();
        public event SelectedTextParser selectedTextParser;

        public List<clsOntologyItem> OItem_TextParsers { get; private set; }

        private bool IsPCChanged;

        public UserControl_TextParserList(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            OList_TextParsers = new List<clsOntologyItem>();

            objDataWork_TextParser = new clsDataWork_TextParser(objLocalConfig);
        }

        public void Initailze_TextParsers(clsOntologyItem OItem_Ref)
        {
            objOItem_Ref = OItem_Ref;

            if (OItem_Ref != null)
            {
                OList_TextParsers =
                    objDataWork_TextParser.GetTextParserByRef(objOItem_Ref).Select(p => new clsOntologyItem
                        {
                            GUID = p.ID_Object,
                            Name = p.Name_Object,
                            GUID_Parent = p.ID_Parent_Object,
                            Type = objLocalConfig.Globals.Type_Object
                        }).ToList();

                IsPCChanged = true;
                dataGridView_TextParsers.DataSource = new SortableBindingList<clsOntologyItem> (OList_TextParsers);

                for (int i = 0; i < dataGridView_TextParsers.Columns.Count; i++)
                {
                    if (dataGridView_TextParsers.Columns[i].DataPropertyName != "Name")
                        dataGridView_TextParsers.Columns[i].Visible = false;

                }
                IsPCChanged = false;

            }
            else
            {
                dataGridView_TextParsers.DataSource = null;
            }

            toolStripLabel_Count.Text = dataGridView_TextParsers.RowCount.ToString();
        }

        private void dataGridView_TextParsers_SelectionChanged(object sender, EventArgs e)
        {
            if (!IsPCChanged)
            {
                OList_TextParsers = dataGridView_TextParsers.Rows.OfType<DataGridViewRow>().Select(p => (clsOntologyItem)p.DataBoundItem).ToList();

                selectedTextParser();    
            }
            
        }
    }
}
