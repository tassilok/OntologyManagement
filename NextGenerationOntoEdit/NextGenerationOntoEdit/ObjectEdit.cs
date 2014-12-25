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

namespace NextGenerationOntoEdit
{
    public partial class ObjectEdit : Form
    {
        private clsLocalConfig localConfig;

        private clsDBLevel dbLevel_Class;

        public List<clsOntologyItem> ObjectList { get; private set; }
        public int RowId { get; private set; }

        public ObjectEdit(clsLocalConfig localConfig, List<clsOntologyItem> ObjectList, int rowId)
        {
            InitializeComponent();

            this.localConfig = localConfig;

            Initialize();
        }

        private void Initialize()
        {
            dbLevel_Class = new clsDBLevel(localConfig.Globals);
            SetHeaderText();
        }

        private void SetHeaderText()
        {
            var objectItem = ObjectList[RowId];
            var objOItem_Class = dbLevel_Class.GetOItem(objectItem.GUID_Parent, localConfig.Globals.Type_Class);
            this.Text = "";
            if (objOItem_Class != null)
            {
                this.Text = objOItem_Class.Name + " \\ "; 
            }

            this.Text += objectItem.Name;
        }
    }
}
