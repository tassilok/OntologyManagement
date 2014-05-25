using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using Structure_Module;
using System.IO;

namespace FileSystem_Connector_Module
{
    public partial class UserControl_CreateSendTo : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private clsDataWorkSendToBatch objDataWorkSendToBatch;

        private Media_Viewer_Module.clsLocalConfig objLocalConfig_MediaViewerItem;
        
        private SortableBindingList<clsOntologyItem> FunctionList;

        private string batchName;

        public UserControl_CreateSendTo(clsLocalConfig LocalConfig, Media_Viewer_Module.clsLocalConfig LocalConfig_MediaViewerItem)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            objLocalConfig_MediaViewerItem = LocalConfig_MediaViewerItem;

            Initialize();
        }

        private void Initialize()
        {
            Clear_Controls();
            objDataWorkSendToBatch = new clsDataWorkSendToBatch(objLocalConfig);
            var objOItem_Result = objDataWorkSendToBatch.GetData_XMLTemplate_To_XMLText();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                comboBox_Modules.Items.Add(objLocalConfig.OItem_object_localizing_manager);
                comboBox_Modules.Items.Add(objLocalConfig.OItem_object_log_manager);
                comboBox_Modules.Items.Add(objLocalConfig.OItem_object_mediaviewer_module);
                comboBox_Modules.Items.Add(objLocalConfig.OItem_object_typed_tagging_module);

                comboBox_Modules.ValueMember = "GUID";
                comboBox_Modules.DisplayMember = "Name";

                comboBox_Modules.Enabled = true;
                dataGridView_Functions.Enabled = true;
            }
            else
            {
                throw new Exception("XML-Config is not correct!");
            }
            


        }

        private void Clear_Controls()
        {
            comboBox_Modules.Enabled = false;
            button_Create.Enabled = false;
            dataGridView_Functions.Enabled = false;
        }

        private void comboBox_Modules_SelectedIndexChanged(object sender, EventArgs e)
        {
            var OItem_Module = (clsOntologyItem)comboBox_Modules.SelectedItem;

            FunctionList = new SortableBindingList<clsOntologyItem>();

            if (OItem_Module != null)
            {
                if (OItem_Module.GUID == objLocalConfig.OItem_object_mediaviewer_module.GUID)
                {
                    FunctionList.Add(objLocalConfig_MediaViewerItem.OItem_Type_Images__Graphic_);
                    FunctionList.Add(objLocalConfig_MediaViewerItem.OItem_Type_Media_Item);
                    FunctionList.Add(objLocalConfig_MediaViewerItem.OItem_Type_PDF_Documents);

                }
            }

            dataGridView_Functions.DataSource = FunctionList;
            foreach (DataGridViewColumn col in dataGridView_Functions.Columns)
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

            Configure_Creation();
            
        }


        private void Configure_Creation()
        {
            button_Create.Enabled = false;
            var OItem_Module = (clsOntologyItem)comboBox_Modules.SelectedItem;
            var boolCreation = false;

            batchName = "";

            var strContent = objDataWorkSendToBatch.BatchString.Replace("@" + objLocalConfig.OItem_object_module_dir.Name + "@", Path.GetDirectoryName(Application.ExecutablePath));
            strContent = strContent.Replace("@" + objLocalConfig.OItem_object_executable.Name + "@", Path.GetFileName(Application.ExecutablePath));

            if (OItem_Module != null)
            {
                if (OItem_Module.GUID == objLocalConfig.OItem_object_log_manager.GUID)
                {
                    boolCreation = true;
                    strContent = strContent.Replace("@" + objLocalConfig.OItem_object_function.Name + "@", OItem_Module.GUID);
                    batchName = OItem_Module.Name + ".cmd";
                    
                }
                else if (OItem_Module.GUID == objLocalConfig.OItem_object_localizing_manager.GUID)
                {
                    boolCreation = true;
                    strContent = strContent.Replace("@" + objLocalConfig.OItem_object_function.Name + "@", OItem_Module.GUID);
                    batchName = OItem_Module.Name + ".cmd";
                }
                else if (OItem_Module.GUID == objLocalConfig.OItem_object_mediaviewer_module.GUID)
                {
                    if (dataGridView_Functions.SelectedRows.Count == 1)
                    {
                        var objOItem_Function = (clsOntologyItem)dataGridView_Functions.SelectedRows[0].DataBoundItem;
                        boolCreation = true;
                        strContent = strContent.Replace("@" + objLocalConfig.OItem_object_function.Name + "@", OItem_Module.GUID + ":" + objOItem_Function.GUID);
                        batchName = OItem_Module.Name + "_" + objOItem_Function.Name + ".cmd";
                    }
                    
                }
                else if (OItem_Module.GUID == objLocalConfig.OItem_object_typed_tagging_module.GUID)
                {
                    boolCreation = true;
                    strContent = strContent.Replace("@" + objLocalConfig.OItem_object_function.Name + "@", OItem_Module.GUID);
                    batchName = OItem_Module.Name + ".cmd";
                }

                if (boolCreation)
                {
                    textBox_Content.Text = strContent;
                    button_Create.Enabled = true;
                }
            }
        }

        private void dataGridView_Functions_SelectionChanged(object sender, EventArgs e)
        {
            Configure_Creation();
        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.SendTo);
            path = path + Path.DirectorySeparatorChar + batchName;

            TextWriter textWriter = new StreamWriter(path, false, Encoding.ASCII);

            textWriter.Write(textBox_Content.Text);

            textWriter.Close();

            MessageBox.Show(this, "The Content was written to File!", "Written", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
