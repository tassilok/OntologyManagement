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
using Filesystem_Module;
using Security_Module;
using OntologyClasses.BaseClasses;
using System.IO;
using Structure_Module;

namespace File_Analyzer_Module
{
    public partial class frmFileAnaylzer : Form
    {
        private clsLocalConfig objLocalConfig;

        private frm_FilesystemModule objFrm_FileSystemModule;
        private frmAuthenticate objFrmAuthenticate;

        private clsFileWork objFileWork;
        private clsBlobConnection objBlobConnection;

        private clsOntologyItem objOItem_File;

        private List<clsRowFilter> rowFilters = new List<clsRowFilter>();

        private List<clsFileContent> fileContentList;

        public frmFileAnaylzer()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {
            objFileWork = new clsFileWork(objLocalConfig.Globals);
            objBlobConnection = new clsBlobConnection(objLocalConfig.Globals);
            objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, true,
                                                     frmAuthenticate.ERelateMode.User_To_Group);
            objFrmAuthenticate.ShowDialog(this);
            if (objFrmAuthenticate.DialogResult == DialogResult.OK)
            {
                objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User;
                objLocalConfig.OItem_Group = objFrmAuthenticate.OItem_Group;
            }

        }

        private void toolStripButton_OpenFile_Click(object sender, EventArgs e)
        {

            objFrm_FileSystemModule = new frm_FilesystemModule(objLocalConfig.Globals, objLocalConfig.OItem_User);
            objFrm_FileSystemModule.ShowDialog(this);

            if (objFrm_FileSystemModule.DialogResult == DialogResult.OK)
            {
                if (objFrm_FileSystemModule.OList_Files.Count == 1)
                {
                    objOItem_File = objFrm_FileSystemModule.OList_Files.First();

                    fileContentList = new List<clsFileContent>();
                    var objOItem_Result = HandleBlobFile(objOItem_File);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (File.Exists(objOItem_File.Additional1))
                        {

                            objOItem_Result = ReadContent();
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                toolStripLabel_FilePath.Text = objOItem_File.Additional2;
                                rowFilters.Clear();
                                ConfigureGrid();
                            }
                            else
                            {
                                toolStripLabel_Count.Text = "";
                                ClearGrid();
                            }

                        }
                        else
                        {
                            MessageBox.Show(this, "Die Datei konnte nicht geöffnet werden!",
                                            "Zugriffs-Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show(this, "Die Datei konnte nicht geöffnet werden!",
                                        "Zugriffs-Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Bitte nur eine Datei auswählen!",
                                    "Eine Datei!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void ClearGrid()
        {
            dataGridView_FileContent.DataSource = null;
            toolStripLabel_Count.Text = "";
        }

        private clsOntologyItem ReadContent()
        {
            long lngFileLine = 1;
            clsOntologyItem objOItem_Result;
            try
            {
                TextReader objTextReader = new StreamReader(objOItem_File.Additional1);
                var fileLine = "";
                while ((fileLine = objTextReader.ReadLine()) != null)
                {
                    fileContentList.Add(new clsFileContent
                        {
                            IdFile = objOItem_File.GUID,
                            FileLine = fileLine,
                            LineNumber = lngFileLine
                        });
                    lngFileLine++;
                }

                objTextReader.Close();
                objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            }
            catch (Exception)
            {

                objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
            }

            return objOItem_Result;
        }

        private void ConfigureGrid()
        {


            var dataSource = rowFilters.Any()
                                 ? new SortableBindingList<clsFileContent>(
                                       fileContentList.Where(c => c.IsFiltered(rowFilters.First())))
                                 : new SortableBindingList<clsFileContent>(fileContentList);
            dataGridView_FileContent.DataSource = dataSource;
            dataGridView_FileContent.Columns[0].Visible = false;

            toolStripLabel_Count.Text = dataGridView_FileContent.RowCount.ToString();

            if (rowFilters.Any())
            {
                toolStripLabel_Filter.Text = "";
                foreach (var rowFilter in rowFilters)
                {
                    toolStripLabel_Filter.Text += "FileLine ";

                    toolStripLabel_Filter.Text += rowFilter.Connector.ToString() != "None"
                                                      ? rowFilter.Connector.ToString() + " "
                                                      : "";

                    switch (rowFilter.TypeOfFilter)
                    {
                        case FilterType.Contains:
                            toolStripLabel_Filter.Text += "<contains> ";
                            break;
                        case FilterType.ContainsNot:
                            toolStripLabel_Filter.Text += "NOT <contains> ";
                            break;
                        case FilterType.Different:
                            toolStripLabel_Filter.Text += "NOT ";
                            break;
                        case FilterType.Equal:
                            toolStripLabel_Filter.Text += "= ";
                            break;
                        case FilterType.Regex:
                            toolStripLabel_Filter.Text += "<regex> ";
                            break;
                        case FilterType.RegexNot:
                            toolStripLabel_Filter.Text += "NOT <regex> ";
                            break;
                    }

                    toolStripLabel_Filter.Text += rowFilter.Filter.Length > 100
                                                      ? rowFilter.Filter.Substring(0, 99)
                                                      : rowFilter.Filter;


                }
            }
            else
            {
                toolStripLabel_Filter.Text = "-";
            }
        }

        private clsOntologyItem HandleBlobFile(clsOntologyItem objOItem_File)
        {

            objOItem_File.Additional2 = objFileWork.get_Path_FileSystemObject(objOItem_File);
            if (objFileWork.is_File_Blob(objOItem_File))
            {
                var extension = Path.GetExtension(objOItem_File.Name);
                objOItem_File.Additional1 = "%Temp%\\" + objLocalConfig.Globals.NewGUID + extension;
                var objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_File, objOItem_File.Additional1, true);
                return objOItem_Result;
            }
            else
            {
                objOItem_File.Additional1 = objFileWork.get_Path_FileSystemObject(objOItem_File);
                return objLocalConfig.Globals.LState_Success.Clone();
            }
        }

        private void frmFileAnaylzer_Load(object sender, EventArgs e)
        {
            if (objLocalConfig.OItem_User == null || objLocalConfig.OItem_Group == null)
            {
                MessageBox.Show(this, "Sie müssen einen Benutzer und eine Gruppe auswählen! Die Anwendung wird beendet.",
                                "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(-1);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowFilters.Clear();
            ConfigureGrid();
        }

        private void contextMenuStrip_Edit_Opening(object sender, CancelEventArgs e)
        {

            var enable = FileLineColSelected();
            containsToolStripMenuItem.Enabled = enable;
            containsNotToolStripMenuItem.Enabled = enable;
            equalToolStripMenuItem.Enabled = enable;
            differentToolStripMenuItem.Enabled = enable;
            regexToolStripMenuItem.Enabled = enable;
            regexNotToolStripMenuItem.Enabled = enable;


        }

        private bool FileLineColSelected()
        {
            if (dataGridView_FileContent.SelectedCells.Count == 1)
            {
                if (
                    dataGridView_FileContent.Columns[dataGridView_FileContent.SelectedCells[0].ColumnIndex]
                        .DataPropertyName == "FileLine")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private string GetSelectedFileLine()
        {
            if (dataGridView_FileContent.SelectedCells.Count == 1)
            {
                return dataGridView_FileContent.Columns[dataGridView_FileContent.SelectedCells[0].ColumnIndex]
                           .DataPropertyName == "FileLine" ? dataGridView_FileContent.Rows[dataGridView_FileContent.SelectedCells[0].RowIndex].Cells[dataGridView_FileContent.SelectedCells[0].ColumnIndex].Value.ToString() : null;
            }
            else
            {
                return null;
            }
        }

        private void equalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var filter= GetSelectedFileLine();

            if (!string.IsNullOrEmpty(filter))
            {
                rowFilters.Add(new clsRowFilter { CaseSensitive = false, Connector = FilterConnector.None, Filter = filter, TypeOfFilter = FilterType.Equal });
                ConfigureGrid();
            }
            else
            {
                MessageBox.Show(this, "Geben Sie bitte eine Suchzeichenkette ein!", "Eingabe", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        private void containsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var filter = toolStripTextBox_Contains.Text;

            if (!string.IsNullOrEmpty(filter))
            {
                rowFilters.Add(new clsRowFilter { CaseSensitive = false, Connector = FilterConnector.None, Filter = filter.Trim(), TypeOfFilter = FilterType.Contains });
                ConfigureGrid();
            }
            else
            {
                MessageBox.Show(this, "Geben Sie bitte eine Suchzeichenkette ein!", "Eingabe", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        private void differentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var filter = GetSelectedFileLine();

            if (!string.IsNullOrEmpty(filter))
            {
                rowFilters.Add(new clsRowFilter { CaseSensitive = false, Connector = FilterConnector.None, Filter = filter, TypeOfFilter = FilterType.Different });
                ConfigureGrid();
            }
            else
            {
                MessageBox.Show(this, "Geben Sie bitte eine Suchzeichenkette ein!", "Eingabe", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        private void containsNotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var filter = toolStripTextBox_ContainsNot.Text;

            if (!string.IsNullOrEmpty(filter))
            {
                rowFilters.Add(new clsRowFilter { CaseSensitive = false, Connector = FilterConnector.None, Filter = filter.Trim(), TypeOfFilter = FilterType.ContainsNot });
                ConfigureGrid();
            }
            else
            {
                MessageBox.Show(this, "Geben Sie bitte eine Suchzeichenkette ein!", "Eingabe", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        private void regexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var filter = toolStripTextBox_Regex.Text;

            if (!string.IsNullOrEmpty(filter))
            {
                rowFilters.Add(new clsRowFilter { CaseSensitive = false, Connector = FilterConnector.None, Filter = filter.Trim(), TypeOfFilter = FilterType.Regex });
                ConfigureGrid();
            }
            else
            {
                MessageBox.Show(this, "Geben Sie bitte eine Suchzeichenkette ein!", "Eingabe", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        private void regexNotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var filter = toolStripTextBox_RegExNot.Text;

            if (!string.IsNullOrEmpty(filter))
            {
                rowFilters.Add(new clsRowFilter { CaseSensitive = false, Connector = FilterConnector.None, Filter = filter.Trim(), TypeOfFilter = FilterType.RegexNot });
                ConfigureGrid();
            }
            else
            {
                MessageBox.Show(this, "Geben Sie bitte eine Suchzeichenkette ein!", "Eingabe", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }
    }
}
