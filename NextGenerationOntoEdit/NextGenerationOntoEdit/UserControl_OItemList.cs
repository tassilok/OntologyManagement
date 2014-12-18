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

namespace NextGenerationOntoEdit
{
    public partial class UserControl_OItemList : UserControl
    {
        private clsLocalConfig localConfig;
        public clsOntologyItem BaseItem { get; private set; }
        public SortableBindingList<Dictionary<string, object>> ItemList { get; set; }

        public UserControl_OItemList(clsLocalConfig localConfig)
        {
            InitializeComponent();

            this.localConfig = localConfig;
            Initialize();
        }


        private void Initialize()
        {

        }

        public void Initialize_Items(clsOntologyItem baseItem)
        {
            BaseItem = baseItem;

            if (BaseItem.Type == localConfig.Globals.Type_AttributeType)
            {
            }
            else if (BaseItem.Type == localConfig.Globals.Type_Class)
            {
                GetItemsByClass();
            }
            else if (BaseItem.Type == localConfig.Globals.Type_Object)
            {
            }
            else if (BaseItem.Type == localConfig.Globals.Type_RelationType)
            {
            }
        }

        private void GetItemsByClass()
        {

        }
        
    }
}
