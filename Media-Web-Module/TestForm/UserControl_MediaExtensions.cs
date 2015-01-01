using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Media_Web_Module;
using Structure_Module;
using OntologyClasses.BaseClasses;

namespace TestForm
{
    public partial class UserControl_MediaExtensions : UserControl
    {
        private clsDataWork_MediaWebModule objDataWork_MediaWebModule;

        private delegate void BindToGrid();

        private BindToGrid bindToGrid;

        public UserControl_MediaExtensions(clsDataWork_MediaWebModule objDataWork_MediaWebModule)
        {
            InitializeComponent();

            this.objDataWork_MediaWebModule = objDataWork_MediaWebModule;
            Initialize();
        }

        private void Initialize()
        {
            objDataWork_MediaWebModule.loadItems += objDataWork_MediaWebModule_loadItems;

            objDataWork_MediaWebModule.GetBaseData();

            bindToGrid = new BindToGrid(RefreshGrid);
        }

        private void RefreshGrid()
        {
            dataGridView_Extensions.DataSource = new SortableBindingList<clsOntologyItem>(objDataWork_MediaWebModule.MediaExtensions);
            foreach (DataGridViewColumn col in dataGridView_Extensions.Columns)
            {
                if (col.DataPropertyName == "Name")
                {
                    col.Visible = true;
                }
                else
                {
                    col.Visible = false;
                }
            }
        }

        void objDataWork_MediaWebModule_loadItems(LoadResult loadResult, OntologyClasses.BaseClasses.clsOntologyItem OItem_Result)
        {
            if (loadResult == LoadResult.Extensions)
            {
                if (OItem_Result.GUID == objDataWork_MediaWebModule.LocalConfig.Globals.LState_Success.GUID)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(bindToGrid);
                    }
                    else
                    {
                        RefreshGrid();
                    }
                }
                
            }
        }
    }
}
