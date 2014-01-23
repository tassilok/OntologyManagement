using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextParser;
using OntologyClasses.BaseClasses;
using Structure_Module;
using System.IO;

namespace FileResourceModule
{
    public partial class UserControl_FileResource_Path : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private clsDataWork_FileResource_Path objDatawork_FileResource_Path;
        private UserControl_RegExTester objUserControl_RegExTester;

        private clsOntologyItem objOItem_FileResource;
        private clsOntologyItem objOItem_Result_Filecount;

        private long lngLineCount = 0;
        private SortableBindingList<clsFile> objFileList;

        private System.Threading.Thread objThread_Files;
        private System.Threading.Thread objThread_LineCount;


        public UserControl_FileResource_Path(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;

            Initialize();
        }

        public void Initialize_Path(clsOntologyItem OItem_FileResource)
        {
            objOItem_FileResource = OItem_FileResource;

            Clear();

            if (objOItem_FileResource != null)
            {
                objDatawork_FileResource_Path.GetData_Attributes(objOItem_FileResource);
                if (objDatawork_FileResource_Path.OItem_Result_Attributes.GUID ==
                    objLocalConfig.Globals.LState_Success.GUID)
                {
                    objDatawork_FileResource_Path.GetData_Relations(objOItem_FileResource);
                    if (objDatawork_FileResource_Path.OItem_Result_Relations.GUID ==
                        objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (objDatawork_FileResource_Path.objORItem_Path != null)
                        {
                            TextBox_Path.Text = objDatawork_FileResource_Path.objORItem_Path.Name_Other;
                            Button_Search.Enabled = true;
                        }
                        
                        if (objDatawork_FileResource_Path.objOAItem_SubItems != null)
                        {
                            CheckBox_SubItems.Enabled = false;
                            CheckBox_SubItems.Checked = objDatawork_FileResource_Path.objOAItem_SubItems.Val_Bit ?? false;
                        }

                        CheckBox_SubItems.Enabled = true;

                        if (objDatawork_FileResource_Path.objOAItem_Pattern != null)
                        {
                            TextBox_Pattern.ReadOnly = true;
                            TextBox_Pattern.Text = objDatawork_FileResource_Path.objOAItem_Pattern.Val_String;
                        }

                        TextBox_Pattern.ReadOnly = false;
                    }
                    else
                    {
                        MessageBox.Show(this, "Die Daten konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    }
                
                }
                else
                {
                    MessageBox.Show(this, "Die Daten konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);


                }
            }
        }

        private void Clear()
        {
            Button_AddPath.Enabled = false;
            Button_Search.Enabled = false;

            DataGridView_Files.DataSource = null;
            ToolStripButton_Open.Enabled = false;
            TextBox_Pattern.ReadOnly = true;
            Button_AddPath.Enabled = true;
        }

        private void Initialize()
        {
            objDatawork_FileResource_Path = new clsDataWork_FileResource_Path(objLocalConfig);
            objUserControl_RegExTester = new UserControl_RegExTester(objLocalConfig.Globals);
            objUserControl_RegExTester.Initialize_Field();
            objUserControl_RegExTester.Dock = DockStyle.Fill;
            ToolStripContainer1.ContentPanel.Controls.Add(objUserControl_RegExTester);
        }

        private void Button_Search_Click(object sender, EventArgs e)
        {
            try
            {
                objThread_Files.Abort();
            }
            catch (Exception)
            {
                
            }

            Timer_Files.Stop();
            Timer_LineCount.Stop();

            Button_Search.Enabled = false;
            objThread_Files = new Thread(GetFiles);
            objThread_Files.Start();
            Timer_Files.Start();
        }

        private void GetFiles()
        {
            objDatawork_FileResource_Path.GetFiles();
        }

        private void Timer_Files_Tick(object sender, EventArgs e)
        {
            Timer_LineCount.Stop();
            if (objDatawork_FileResource_Path.OItem_Result_FileResult.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                ProgressBar_Files.Value = 50;
                objFileList = new SortableBindingList<clsFile>(objDatawork_FileResource_Path.FileList);
                DataGridView_Files.DataSource = objFileList;
            }
            else if (objDatawork_FileResource_Path.OItem_Result_FileResult.GUID ==
                     objLocalConfig.Globals.LState_Error.GUID)
            {
                Timer_Files.Stop();
                ProgressBar_Files.Value = 0;
                MessageBox.Show(this, "Beim Ermitteln der Daten ist ein Fehler aufgetreten!", "Fehler!",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (objDatawork_FileResource_Path.OItem_Result_FileResult.GUID ==
                     objLocalConfig.Globals.LState_Relation.GUID)
            {
                Timer_Files.Stop();
                ProgressBar_Files.Value = 0;
                MessageBox.Show(this, "Der Pfad existiert nicht!", "Fehler!",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Button_Search.Enabled = true;
            }
            else
            {
                Timer_Files.Stop();
                objFileList = new SortableBindingList<clsFile>(objDatawork_FileResource_Path.FileList);
                DataGridView_Files.DataSource = objFileList;
                ProgressBar_Files.Value = 0;
                Button_Search.Enabled = true;

                ToolStripLabel_Count.Text = DataGridView_Files.RowCount.ToString();

                ToolStripProgressBar_LineCount.Value = 0;

                
                try
                {
                    objThread_LineCount.Abort();
                }
                catch (Exception)
                {
                    
                    
                }

                objOItem_Result_Filecount = objLocalConfig.Globals.LState_Nothing.Clone();

                lngLineCount = 0;

                objThread_LineCount = new Thread(GetLineCount);
                objThread_LineCount.Start();

                Timer_LineCount.Start();
            }
        }

        private void DataGridView_Files_SelectionChanged(object sender, EventArgs e)
        {
            ToolStripButton_Open.Enabled = false;
            if (DataGridView_Files.SelectedRows.Count == 1)
            {
                ToolStripButton_Open.Enabled = true;
            }
        }

        private void ToolStripButton_Open_Click(object sender, EventArgs e)
        {
            var objDGVR_Selected = (DataGridViewRow) DataGridView_Files.SelectedRows[0];
            var objFile = (clsFile) objDGVR_Selected.DataBoundItem;

            if (System.IO.File.Exists(objFile.FileName))
            {
                objUserControl_RegExTester.SetContentByFilePath(objFile.FileName);
            }
            else
            {
                MessageBox.Show(this, "Die Datei existiert nicht!", "Dateifehler!",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GetLineCount()
        {
            foreach (DataGridViewRow dgvrSel in DataGridView_Files.Rows)
            {
                var objFile = (clsFile) dgvrSel.DataBoundItem;

                try
                {
                    lngLineCount = lngLineCount + File.ReadAllLines(objFile.FileName).Length;
                }
                catch (Exception)
                {
                    objOItem_Result_Filecount = objLocalConfig.Globals.LState_Error.Clone();
                    break;

                }
            }
            if (objOItem_Result_Filecount.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                objOItem_Result_Filecount = objLocalConfig.Globals.LState_Success.Clone();
            }
        }

        private void Timer_LineCount_Tick(object sender, EventArgs e)
        {
            if (objOItem_Result_Filecount.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                ToolStripProgressBar_LineCount.Value = 50;
            }
            else
            {
                ToolStripLabel_LineCount.Text = lngLineCount.ToString();

                ToolStripProgressBar_LineCount.Value = 0;

                Timer_LineCount.Stop();
            }
        }


    }

}
