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
using Filesystem_Module;

namespace TestForm
{
    public partial class UserControl_MediaFiles : UserControl
    {
        private clsDataWork_MediaWebModule objDataWork_MediaWebModule;

        private delegate void LoadedExtensions();

        private LoadedExtensions loadedExtensions;

        private delegate void LoadedFiles();
        private LoadedFiles loadedFiles;

        public UserControl_MediaFiles(clsDataWork_MediaWebModule objDataWork_MediaWebModule)
        {
            InitializeComponent();
            this.objDataWork_MediaWebModule = objDataWork_MediaWebModule;

            Initialize();
        }

        private void Initialize()
        {
            loadedExtensions = new LoadedExtensions(ResultOfExtensionLoad);
            loadedFiles = new LoadedFiles(ResultOfFileLoad);
            objDataWork_MediaWebModule.loadItems += objDataWork_MediaWebModule_loadItems;
            if (!objDataWork_MediaWebModule.LoadedItems.HasFlag(LoadResult.Extensions))
            {
                objDataWork_MediaWebModule.GetBaseData();
            }
            else
            {
                objDataWork_MediaWebModule.GetFiles();
            }
        }

        private void ResultOfExtensionLoad()
        {
            LoadFiles();
        }

        private void ResultOfFileLoad()
        {
            dataGridView_Files.DataSource = new SortableBindingList<clsFileSystemObject>(objDataWork_MediaWebModule.MediaFiles);
            
        }

        private void LoadFiles()
        {
            objDataWork_MediaWebModule.GetFiles();
        }

        void objDataWork_MediaWebModule_loadItems(LoadResult loadResult, OntologyClasses.BaseClasses.clsOntologyItem OItem_Result)
        {
            if (loadResult == LoadResult.Extensions)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(loadedExtensions);
                }
                else
                {
                    ResultOfExtensionLoad();
                }
            }
            else if (loadResult == LoadResult.MediaFiles)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(loadedFiles);
                }
                else
                {
                    ResultOfFileLoad();
                }
            }
        }
    }
}
