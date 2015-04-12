﻿using System;
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
using Filesystem_Module;
using System.IO;
using System.Text.RegularExpressions;
using PortListenerForText_Module;
using System.Globalization;
using System.Threading;
using CommandLineRun_Module;
using ClassLibrary_ShellWork;

namespace TextParser
{
    public partial class UserControl_FieldParserView : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private clsOntologyItem objOItem_Parser;
        private clsOntologyItem objOItem_TextParser;

        private clsDataWork_FieldParser objDataWork_FieldParser;
        private clsDataWork_TextParser objDataWork_TextParser;
        private clsDataWork_FileResources objDataWork_FileResource;
        private clsDataWork_FileResource_Path objDataWork_FileResource_Path;

        private clsTransaction_Query objTransactionQuery;

        private clsImport_IndexData objImport_IndexData;

        private frm_ObjectEdit objFrmObjectEdit;

        private frmPattern objFrmPattern;
        private frmCommandLineRun objFrmCommandLineRun;

        private dlg_Attribute_String objDLG_Attribute_String;

        private clsAppDBLevel objAppDBLevel;

        private clsDBLevel objDBLevel_Indexes;

        private frmModules objFrmModules;
        private clsShellWork objShellWork;

        private frmPortListenerForText objFrmPortListenerForText;
        
        private TextWriter textWriter;
        
        private clsFieldParserOfTextParser objFieldParser;

        private SortableBindingList<clsField> fieldList;

        private DataTable dataTable;

        private Thread threadParse;

        private delegate void RefreshThreadInfo(long parsedCount, long savedCount);
        private RefreshThreadInfo refreshThreadInfo;
        private delegate void FinishedThread();
        private FinishedThread finishedThread;

        private delegate void AppliedPattern();

        private AppliedPattern appliedPattern;

        private long lngLineCount;


        private int page = 0;
        private int pages = 0;
        private int pos = 0;

        private int port = 0;
        private string server = "";
        private string index = "";
        private List<string> indexes = new List<string>();
        private List<clsOntologyItem> OList_Variables;
        private bool pIndexFill = false;

        private string pattern = "";

        private string strLastModule;

        public UserControl_FieldParserView(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            
            objLocalConfig = LocalConfig;
            appliedPattern = new AppliedPattern(SetPattern);
            Initialize();
        }

        private void SetPattern()
        {
            toolStripTextBox_Query.Text = pattern;
        }

        private void FillSubParserTree(clsOntologyItem OItem_Result)
        {
            treeView_SubParsers.Nodes.Clear();
            if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var rootParserNode = treeView_SubParsers.Nodes.Add(objOItem_TextParser.GUID, objOItem_TextParser.Name, objLocalConfig.ImageID_RootParser, objLocalConfig.ImageID_RootParser);
                
                objDataWork_TextParser.OList_SubParsers.OrderBy(subParser => subParser.Name).ToList().ForEach(
                    subParser =>
                    {
                        rootParserNode.Nodes.Add(subParser.GUID, subParser.Name, objLocalConfig.ImageID_SubParser,
                            objLocalConfig.ImageID_SubParser);
                    });

                treeView_SubParsers.ExpandAll();
            }
        }

        public void InitializeView(clsOntologyItem OItem_FieldParser, clsOntologyItem OItem_TextParser)
        {
            OList_Variables = new List<clsOntologyItem>();
            var fileList = new List<clsFile>();

            objOItem_Parser = OItem_FieldParser;
            objOItem_TextParser = OItem_TextParser;
            toolStripTextBox_Parser.Text = objOItem_Parser.Name;

            objDataWork_TextParser.GetData_TextParser(objOItem_TextParser);
            page = 0;
            pages = 0;
            var objOItem_Result = objDataWork_TextParser.OItem_Result_TextParser;

            refreshThreadInfo = new RefreshThreadInfo(RefreshThreadInfos);
            finishedThread = new FinishedThread(FinishedThreadWork);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objDataWork_TextParser.CreateRefItems(objOItem_TextParser);
                var objOItem_Index = objDataWork_TextParser.OItem_Index;
                objDataWork_TextParser.GetData_IndexData(objOItem_Index);
                while (objDataWork_TextParser.OItem_Result_Index.GUID == objLocalConfig.Globals.LState_Nothing.GUID) { }

                if (objDataWork_TextParser.OItem_Result_Index.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    index = "";
                    port = int.Parse(objDataWork_TextParser.OItem_Port.Name);
                    server = objDataWork_TextParser.OItem_Server.Name;
                    if (objDataWork_TextParser.OItem_Index != null)
                    {
                        index = objDataWork_TextParser.OItem_Index.Name;

                        
                    }

                    if (objDataWork_TextParser.OList_Variables != null)
                    {
                        OList_Variables = objDataWork_TextParser.OList_Variables;
                    }

                    if (OList_Variables != null && OList_Variables.Any())
                    {
                        var fileDate_Create = false;
                        var fileDate_LastChange = false;
                        foreach (var oItem_Variable in OList_Variables)
                        {
                            if (oItem_Variable.GUID == objLocalConfig.OItem_object_user.GUID)
                            {
                                index = index.Replace("@" + oItem_Variable.Name.ToLower() + "@",
                                                      objLocalConfig.OItem_User.GUID);
                            }
                            else if (oItem_Variable.GUID ==
                                     objLocalConfig.OItem_object_filedate_create.GUID)
                            {
                                fileDate_Create = true;
                            }
                            else if (oItem_Variable.GUID ==
                                     objLocalConfig.OItem_object_filedate_lastchange.GUID)
                            {
                                fileDate_LastChange = true;
                            }
                        }
                    }

                    objAppDBLevel = new clsAppDBLevel(server, port, index,
                                                             objLocalConfig.Globals.SearchRange,
                                                             objLocalConfig.Globals.Session);

                    if (objDataWork_TextParser.OItem_FileResource != null)
                    {
                        

                        if (objDataWork_TextParser.OItem_FileResource != null)
                        {
                            

                           


                            var objOItem_ResourceType =
                                objDataWork_FileResource.GetResourceType(objDataWork_TextParser.OItem_FileResource);

                            if (objOItem_ResourceType.GUID == objDataWork_FileResource.OItem_Class_File.GUID)
                            {
                                objOItem_Result = objLocalConfig.Globals.LState_Relation;

                            }
                            else if (objOItem_ResourceType.GUID == objDataWork_FileResource.OItem_Class_Path.GUID)
                            {
                                objDataWork_FileResource_Path.GetData_Attributes(objDataWork_TextParser.OItem_FileResource);
                                if (objDataWork_FileResource_Path.OItem_Result_Attributes.GUID ==
                                    objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    objDataWork_FileResource_Path.GetData_Relations(objDataWork_TextParser.OItem_FileResource);
                                    if (objDataWork_FileResource_Path.OItem_Result_Relations.GUID ==
                                        objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        objDataWork_FileResource_Path.GetFiles();
                                        if (objDataWork_FileResource_Path.OItem_Result_FileResult.GUID ==
                                            objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            

                                            fileList = objDataWork_FileResource_Path.FileList;
                                            
                                           

                                            if (objLocalConfig.ExOpt_TextParser != null &&
                                                objLocalConfig.ExOpt_Execute &&
                                                objLocalConfig.ExOpt_Override)
                                            {
                                                
                                                while (toolStripComboBox_Indexes.Items.Count > 1)
                                                {
                                                    var strItem = toolStripComboBox_Indexes.Items[1];
                                                    if (!string.IsNullOrEmpty(strItem.ToString()))
                                                    {
                                                        toolStripComboBox_Indexes.SelectedItem = strItem;
                                                        Deleted_Index();
                                                    }
                                                }
                                                    
                                                    
                                                
                                                
                                            }

                                            
                                        }

                                    }
                                }

                            }
                            else if (objOItem_ResourceType.GUID ==
                                     objDataWork_FileResource.OItem_Class_WebConnection.GUID)
                            {
                                objOItem_Result = objLocalConfig.Globals.LState_Relation;
                            }
                            else
                            {
                                objOItem_Result = objLocalConfig.Globals.LState_Error;
                            }
                        }
                        else
                        {
                            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                        }

                        pIndexFill = true;
                        GetIndexes();
                        pIndexFill = false;
                    }
                    else if (objDataWork_TextParser.OITem_SourceField != null)
                    {
                        pIndexFill = true;
                        GetIndexes();
                        pIndexFill = false;
                    }
                    else
                    {
                        pIndexFill = true;
                        GetIndexes();
                        pIndexFill = false;
                        toolStripButton_Parse.Enabled = false;
                        objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
                    }





                }


            }


            GetFields();
            FillSubParserTree(objOItem_Result);
            
            if (objLocalConfig.ExOpt_TextParser != null &&
                                                objLocalConfig.ExOpt_Execute)
            {
                Parse();
            }
        }

        private void FinishedThreadWork()
        {
            toolStripButton_Stop.Enabled = false;
            toolStripButton_Parse.Enabled = true;
            if (objFieldParser.OItem_Result != null && objFieldParser.OItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                MessageBox.Show(this, "Beim Parsen ist ein Fehler aufgetreten: " + objFieldParser.OItem_Result.Additional1 ?? "");
            }
        }

        private void RefreshThreadInfos(long parsedCount, long savedCount)
        {
            toolStripLabel_ParseCount.Text = parsedCount.ToString() + "/" + savedCount.ToString();
            if (toolStripComboBox_Indexes.Items.Count == 0)
            {
                GetIndexes();
            }
        }

        private void Initialize()
        {
            toolStripButton_Stop.Enabled = false;
            indexes.Clear();

            objDataWork_FieldParser = new clsDataWork_FieldParser(objLocalConfig);

            objDataWork_TextParser = new clsDataWork_TextParser(objLocalConfig);
            objDataWork_FileResource = new clsDataWork_FileResources(objLocalConfig.Globals);
            objDataWork_FileResource_Path = new clsDataWork_FileResource_Path(objLocalConfig.Globals);

            objImport_IndexData = new clsImport_IndexData(objLocalConfig);
        }

       
        private void GetFields()
        {
            var objOItem_Result = objDataWork_FieldParser.GetData_FieldsOfFieldParser();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                fieldList = new SortableBindingList<clsField>(objDataWork_FieldParser.FieldList.Where(p => p.ID_FieldParser == objOItem_Parser.GUID).OrderBy(f => f.OrderId).ThenBy(f => f.Name_Field).Select(field => field.Clone()));
                dataGridView_Fields.DataSource = fieldList;
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

        private void GetPage()
        {
            pos = page*objLocalConfig.Globals.SearchRange;
            if (toolStripComboBox_Indexes.SelectedItem != null)
            {
                var index = toolStripComboBox_Indexes.SelectedItem.ToString();

                if (index != "")
                {
                    var Docs = objAppDBLevel.GetData_Documents(index, objDataWork_TextParser.OITem_Type != null ? objDataWork_TextParser.OITem_Type.Name : "Doc", true, pos, toolStripTextBox_Query.Text == "" ? null : toolStripTextBox_Query.Text).ToList();
                    CreateDataTable();

                    foreach (var doc in Docs)
                    {
                        
                        var row = dataTable.Rows.Add();
                        row[objOItem_TextParser.GUID + "_ID"] = doc.Id;
                        for(int i = 0;i<fieldList.Count;i++)
                        {
                            
                            if (doc.Dict.ContainsKey(fieldList[i].Name_Field))
                                row[fieldList[i].Name_Field] = doc.Dict[fieldList[i].Name_Field];
                        }

                    }
                    bindingSource_Items.DataSource = dataTable;
                    dataGridView_IndexView.DataSource = bindingSource_Items;
                    foreach (DataGridViewColumn col in dataGridView_IndexView.Columns)
                    {
                        if (col.DataPropertyName == objOItem_TextParser.GUID + "_ID")
                        {
                            col.Visible = false;
                        }
                        if (col.ValueType == typeof(System.DateTime))
                        {
                            col.DefaultCellStyle.Format = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " +  CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern; 
                        }
                    }
                    pos = objAppDBLevel.LastPos;
                    pages = objAppDBLevel.PageCount;
                    page = objAppDBLevel.CurrPage;

                    if (objAppDBLevel.Total > objLocalConfig.Globals.SearchRange)
                    {
                        toolStripLabel_Count.Text = ((page * objLocalConfig.Globals.SearchRange)+1).ToString() + "-" + ((page+1) * objLocalConfig.Globals.SearchRange).ToString() + "/" + objAppDBLevel.Total.ToString();
                    }
                    else
                    {
                        toolStripLabel_Count.Text = objAppDBLevel.Total.ToString() + "/" +
                                                    objAppDBLevel.Total.ToString();
                    }
                    toolStripLabel_PageCur.Text = (page + 1) .ToString() + "/" + pages.ToString();
                    ConfigureNavigation();
                }    
            }
            
        }

        private void ConfigureNavigation()
        {
            toolStripButton_PageFirst.Enabled = false;
            toolStripButton_PageLast.Enabled = false;
            if (page > 0)
            {
                toolStripButton_PageFirst.Enabled = true;
                
            }

            if (page < pages)
            {
                toolStripButton_PageLast.Enabled = true;
            }

            toolStripButton_PagePrevious.Enabled = toolStripButton_PageFirst.Enabled;
            toolStripButton_PageNext.Enabled = toolStripButton_PageLast.Enabled;
        }

        private void CreateDataTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add(objOItem_TextParser.GUID + "_ID", typeof (string));
            foreach (var field in fieldList.OrderBy(f => f.IsMeta).ThenBy(f => f.OrderId).ToList())
            {
                if (field.ID_DataType == objLocalConfig.OItem_object_bit.GUID)
                {
                    dataTable.Columns.Add(field.Name_Field, typeof (bool));


                }
                else if (field.ID_DataType == objLocalConfig.OItem_object_int.GUID)
                {
                    dataTable.Columns.Add(field.Name_Field, typeof(int));
                }
                else if (field.ID_DataType == objLocalConfig.OItem_object_datetime.GUID)
                {
                    dataTable.Columns.Add(field.Name_Field, typeof(DateTime));
                }
                else if (field.ID_DataType == objLocalConfig.OItem_object_double.GUID)
                {
                    dataTable.Columns.Add(field.Name_Field, typeof(double));
                }
                else if (field.ID_DataType == objLocalConfig.OItem_object_string.GUID)
                {
                    dataTable.Columns.Add(field.Name_Field, typeof(string));
                }
            }
            
            
        }

        private void toolStripButton_Parse_Click(object sender, EventArgs e)
        {
            toolStripButton_Parse.Enabled = false;
            toolStripLabel_ParseCount.Text = "0/0";
            Parse();
        }

        private void Parse(List<clsFile> fileList = null)
        {
            var fieldList = (SortableBindingList<clsField>)dataGridView_Fields.DataSource;
            if (fieldList.Any())
            {

                objFieldParser = new clsFieldParserOfTextParser(objLocalConfig, fieldList.ToList(), objOItem_TextParser, objDataWork_TextParser.OITem_Type, fileList == null);

                if (fileList != null)
                {
                    objFieldParser.fileList = fileList;
                }
                objFieldParser.OList_Seperator = objDataWork_TextParser.OList_LineSeperator.Select(s => new clsOntologyItem
                {
                    GUID = s.GUID,
                    Name = s.Name,
                    GUID_Parent = objLocalConfig.OItem_class_text_seperators.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                }).ToList();
                objFieldParser.parsedLines += objFieldParser_parsedLines;
                objFieldParser.finishedParsing += objFieldParser_finishedParsing;
                try
                {
                    threadParse.Abort();
                }
                catch (Exception ex) { }

                if (objDataWork_TextParser.OITem_SourceField == null)
                {
                    threadParse = new Thread(objFieldParser.ParseFiles);
                    threadParse.Start();
                    toolStripButton_Stop.Enabled = true;    
                }
                else
                {
                    objFieldParser.DataWork_TextParser_Parent = objDataWork_TextParser;
                    threadParse = new Thread(objFieldParser.ParseSourceField);
                    threadParse.Start();
                    toolStripButton_Stop.Enabled = true;    
                }
                
                
            }
            GetIndexes();
        }

        void objFieldParser_finishedParsing()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(finishedThread);
            }
            else
            {
                FinishedThreadWork();
            }
        }

        void objFieldParser_parsedLines(long countParsed, long countSaved)
        {
            if (this.InvokeRequired)
            {
               this.Invoke(refreshThreadInfo, countParsed, countSaved);
            }
            else
            {
                RefreshThreadInfos(countParsed, countSaved);
            }
        }

        private void GetIndexes()
        {
            objDBLevel_Indexes = new clsDBLevel();
            toolStripComboBox_Indexes.ComboBox.DataSource = null;
            var indexList = objDBLevel_Indexes.IndexList(server, port);
            foreach (var oItemVariable in OList_Variables)
            {
                index = index.Replace("@" + oItemVariable.Name + "@", ".*");
            }

            var ixList = indexList.Where(i => IsValidIndex(i, index)).OrderBy(p => p).ToList();
            ixList.Insert(0,"");
            toolStripComboBox_Indexes.ComboBox.DataSource = ixList;
            toolStripComboBox_Indexes.SelectedIndex = 0;
        }


        private bool IsValidIndex(string index, string indexPattern)
        {
            var objRegEx = new Regex(indexPattern.ToLower());
            return objRegEx.Match(index.ToLower()).Success;
        }

        private void toolStripComboBox_Indexes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (!pIndexFill)
            {
                page = 0;
                pages = 0;
                pos = 0;
                
            }
            

        }

        private void toolStripButton_Search_Click(object sender, EventArgs e)
        {
            page = 0;
            pages = 0;
            pos = 0;
            GetPage();
        }

        private void toolStripTextBox_Query_TextChanged(object sender, EventArgs e)
        {
            toolStripButton_SaveQuery.Enabled = !string.IsNullOrEmpty(toolStripTextBox_Query.Text);
        }

        private void toolStripButton_PageNext_Click(object sender, EventArgs e)
        {
            if (page < pages)
            {
                page++;
                GetPage();
            }
        }

        private void toolStripButton_PageFirst_Click(object sender, EventArgs e)
        {
            page = 0;
            GetPage();
        }

        private void toolStripButton_PagePrevious_Click(object sender, EventArgs e)
        {
            if (page > 0)
            {
                page--;
                GetPage();
            }
        }

        private void toolStripButton_PageLast_Click(object sender, EventArgs e)
        {
            if (page < pages)
            {
                page = pages;
                GetPage();
            }
        }

        private void toolStripDropDownButton_IndexWork_DropDownOpening(object sender, EventArgs e)
        {
            toolStripMenuItem_DeleteIndex.Enabled = false;
            if (toolStripComboBox_Indexes.SelectedItem != null) toolStripMenuItem_DeleteIndex.Enabled = true;
        }

        private void toolStripMenuItem_DeleteIndex_Click(object sender, EventArgs e)
        {
            var documentItems = objDataWork_FieldParser.GetDocumentItems(objOItem_TextParser);
            if (!documentItems.Any())
            {
                Deleted_Index();    
            }
            else
            {
                MessageBox.Show(this, "Der Index kann nicht gelöscht werden, weil noch Referenzen existieren. Entfernen Sie diese zuerst!", "Referenzen!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            
        }

        private void Deleted_Index()
        {
            if (!string.IsNullOrEmpty(toolStripComboBox_Indexes.SelectedItem.ToString()))
            {

                var index = toolStripComboBox_Indexes.SelectedItem.ToString();
                objDBLevel_Indexes = new clsDBLevel(server, port, index, objLocalConfig.Globals.Index_Rep, objLocalConfig.Globals.SearchRange, objLocalConfig.Globals.Session);
                var objOItem_Result = objDBLevel_Indexes.DeleteIndex(index);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    GetIndexes();
                }
                else
                {
                    MessageBox.Show(this, "Der Index konnte nicht gelöscht werden!", "Fehler!", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(this, "Der Index konnte nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        private void contextMenuStrip_Fields_Opening(object sender, CancelEventArgs e)
        {
            editToolStripMenuItem.Enabled = false;
            parseTestToolStripMenuItem.Enabled = false;
            if (dataGridView_Fields.SelectedCells.Count == 1)
            {
                if (dataGridView_Fields.Columns[dataGridView_Fields.SelectedCells[0].ColumnIndex].DataPropertyName ==
                    "Name_Field")
                {
                    editToolStripMenuItem.Enabled = true;
                }
            }

            if (dataGridView_Fields.SelectedRows.Count == 1)
            {
                editToolStripMenuItem.Enabled = true;
                parseTestToolStripMenuItem.Enabled = true;
            }
        }

        private void editOItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsField field = null;
            if (dataGridView_Fields.SelectedColumns.Count == 1 && dataGridView_Fields.Columns[dataGridView_Fields.SelectedCells[0].ColumnIndex].DataPropertyName ==
                    "Name_Field")
            {
                field = (clsField)dataGridView_Fields.Rows[dataGridView_Fields.SelectedCells[0].RowIndex].DataBoundItem;    
            }
            else if (dataGridView_Fields.SelectedRows.Count == 1)
            {
                field = (clsField) dataGridView_Fields.SelectedRows[0].DataBoundItem;
            }

            if (field != null)
            {
                var objOList = new List<clsOntologyItem>
                {
                    new clsOntologyItem
                        {
                            GUID = field.ID_Field,
                            Name = field.Name_Field,
                            GUID_Parent = objLocalConfig.OItem_class_field.GUID,
                            Type = objLocalConfig.Globals.Type_Object
                        }
                };

                objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals, objOList, 0, objLocalConfig.Globals.Type_Object, null);
                objFrmObjectEdit.ShowDialog(this);
            }
            
            
        }

        private void toolStripButton_Import_Click(object sender, EventArgs e)
        {
            var objOItem_Result = objImport_IndexData.ImportIndexData(objOItem_TextParser, toolStripTextBox_Query.Text == "" ? null : toolStripTextBox_Query.Text);
        }

        private void dataGridView_IndexView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView_IndexView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }

        private void dataGridView_IndexView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (dataGridView_IndexView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                string text = dataGridView_IndexView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                Refresh_ExternalTextBox(text);   
                
            }
        }

        private void Refresh_ExternalTextBox(string text, bool onlyIfOpened = false)
        {
            
            if (objDLG_Attribute_String == null)
            {
                if (!onlyIfOpened)
                {
                    objDLG_Attribute_String = new dlg_Attribute_String("Cell-Content", objLocalConfig.Globals, text);
                    objDLG_Attribute_String.TextReadonly = true;
                }
                
            }
            else
            {
                objDLG_Attribute_String.Value = text;
            }


            if (objDLG_Attribute_String != null && !objDLG_Attribute_String.Visible)
            {
                objDLG_Attribute_String.Show(this);
            }
        }

        private void contextMenuStrip_Index_Opening(object sender, CancelEventArgs e)
        {
            filterToolStripMenuItem.Enabled = false;
            ModuleMenuToolStripMenuItem.Enabled = false;
            editToolStripMenuItem1.Enabled = false;

            if (dataGridView_IndexView.SelectedCells.Count == 1)
            {
                filterToolStripMenuItem.Enabled = true;
                ModuleMenuToolStripMenuItem.Enabled = true;
            }

            if (dataGridView_IndexView.SelectedRows.Count > 0)
            {
                editToolStripMenuItem1.Enabled = true;
            }
        }

        private void equalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_IndexView.SelectedCells.Count == 1 && dataGridView_IndexView.SelectedCells[0].Value != null)
            {
                var filter = dataGridView_IndexView.Columns[dataGridView_IndexView.SelectedCells[0].ColumnIndex].Name + ":" + dataGridView_IndexView.SelectedCells[0].Value.ToString();
                toolStripTextBox_Query.Text = filter;
                GetPage();
            }
        }

        private void differentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_IndexView.SelectedCells.Count == 1 && dataGridView_IndexView.SelectedCells[0].Value != null)
            {
                var filter = "NOT " +  dataGridView_IndexView.Columns[dataGridView_IndexView.SelectedCells[0].ColumnIndex].Name + ":" + dataGridView_IndexView.SelectedCells[0].Value.ToString();
                toolStripTextBox_Query.Text = filter;
                GetPage();
            }
        }

        private void dataGridView_IndexView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_IndexView.SelectedCells.Count == 1 && dataGridView_IndexView.SelectedCells[0].Value != null)
            {
                var text = dataGridView_IndexView.SelectedCells[0].Value.ToString();
                Refresh_ExternalTextBox(text, true);
            }
        }

        private void toolStripTextBox_Query_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (ModifierKeys.HasFlag(Keys.Alt))
                    {
                        pattern = "";
                        if (objFrmPattern == null)
                        {
                            objFrmPattern = new frmPattern(objLocalConfig, objOItem_TextParser);
                            objFrmPattern.PatternApplied += objFrmPattern_PatternApplied;
                        }
                        objFrmPattern.InitializePatternView(toolStripTextBox_Query.Text);
                        objFrmPattern.Show();
                    }
                    else
                    {
                        GetPage();    
                    }
                    
                    break;
                
            }
        }

        void objFrmPattern_PatternApplied(clsSearchPattern searchPattern)
        {
            pattern = "";
            if (searchPattern != null)
            {
                pattern = searchPattern.Pattern;
            }

            if (InvokeRequired)
            {
                Invoke(appliedPattern);
            }
            else
            {
                SetPattern();
            }
        }

        private void toolStripButton_Listen_CheckStateChanged(object sender, EventArgs e)
        {
            if (toolStripButton_Listen.Checked)
            {
                lngLineCount = 0;
                toolStripButton_Parse.Enabled = false;
                var fieldList = (SortableBindingList<clsField>)dataGridView_Fields.DataSource;
                if (fieldList.Any())
                {

                    objFieldParser = new clsFieldParserOfTextParser(objLocalConfig, fieldList.ToList(), objOItem_TextParser, objDataWork_TextParser.OITem_Type, false);
                    objFieldParser.OList_Seperator = objDataWork_TextParser.OList_LineSeperator.Select(s => new clsOntologyItem
                    {
                        GUID = s.GUID,
                        Name = s.Name,
                        GUID_Parent = objLocalConfig.OItem_class_text_seperators.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    }).ToList();

                    var file = new clsFile();
                    file.FileName = Environment.ExpandEnvironmentVariables("%TEMP%\\" + objLocalConfig.Globals.NewGUID);
                    objFieldParser.fileList = new List<clsFile> { file };

                    if (objFieldParser.fileList.Any())
                    {
                        try
                        {
                            textWriter =
                                new StreamWriter(new FileStream(objFieldParser.fileList.First().FileName,
                                                                FileMode.Create));
                            
                            objFrmPortListenerForText = new frmPortListenerForText(objLocalConfig.Globals);
                            objFrmPortListenerForText.textFromStream += objFrmPortListenerForText_textFromStream;
                            objFrmPortListenerForText.clientClosed += objFrmPortListenerForText_clientClosed;
                            
                            objFrmPortListenerForText.Show();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, "Beim Öffnen der Datei ist ein Fehler aufgetreten!", "Fehler!",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            toolStripButton_Listen.Checked = false;
                        }



                    }
                    else
                    {
                        toolStripButton_Parse.Enabled = true;
                    }

                }
                else
                {
                    toolStripButton_Parse.Enabled = true;
                }
            }
            else
            {
                toolStripButton_Parse.Enabled = true;
            }
            
        }

        void objFrmPortListenerForText_clientClosed()
        {
            try
            {
                textWriter.Close();
            }
            catch (Exception)
            {
                
                
            }
            
            toolStripButton_Listen.Checked = false;
            Parse(objFieldParser.fileList);
        }

        void objFrmPortListenerForText_textFromStream(string line)
        {

            try
            {

                textWriter.Write(line);
                lngLineCount++;
                
                
                

            }
            catch (Exception)
            {


            }
        }

        private void toolStripButton_Listen_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_Stop_Click(object sender, EventArgs e)
        {
            objFieldParser.AbortParseProcess = true;
        }

        private void parseTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsField field = null;
            if (dataGridView_Fields.SelectedRows.Count == 1)
            {
                field = (clsField) dataGridView_Fields.SelectedRows[0].DataBoundItem;
            }

            if (field != null)
            {

            }
        }

        private void toolStripButton_SaveQuery_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(toolStripTextBox_Query.Text) && objOItem_TextParser != null)
            {
                if (objTransactionQuery == null)
                {
                    objTransactionQuery = new clsTransaction_Query(objLocalConfig);
                    
                }
                var result = objTransactionQuery.SaveSearchPattern(objOItem_TextParser, toolStripTextBox_Query.Text);
                if (result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                {
                    MessageBox.Show(this, "Die Query konnte nicht gespeichert werden!", "Fehler!",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
            toolStripButton_SaveQuery.Enabled = false;
        }

        private void toolStripButton_CommandLineRun_Click(object sender, EventArgs e)
        {
            objFrmCommandLineRun = new frmCommandLineRun(objLocalConfig.Globals,objOItem_TextParser, false);
            objFrmCommandLineRun.appliedItem += objFrmCommandLineRun_appliedItem;
            objFrmCommandLineRun.ShowDialog(this);
        }

        void objFrmCommandLineRun_appliedItem()
        {
            var fieldDict =
                objDataWork_FieldParser.FieldList.Where(field => field.ID_FieldParser == objOItem_Parser.GUID).Select(
                    field => new KeyValuePair<string, string>(field.Name_Field, field.ID_Field)).ToList();
            objFrmCommandLineRun.CreateScriptOfTextParserOrReport(fieldDict,dataGridView_IndexView);
        }

        private void OpenModuleByArgumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_Fields.SelectedCells.Count == 1)
            {
                DataGridViewCell cell = dataGridView_IndexView.SelectedCells[0];
                DataGridViewRow dgvRow = dataGridView_IndexView.Rows[cell.RowIndex];
                DataRowView row = (DataRowView) dgvRow.DataBoundItem;
                DataGridViewColumn col = dataGridView_IndexView.Columns[cell.ColumnIndex];

                var fields = fieldList.Where(field => field.Name_Field == col.DataPropertyName);

                if (fields.Any())
                {
                    var docItem = objDataWork_FieldParser.GetDocumentItem(cell.Value, row[objOItem_TextParser.GUID + "_ID"].ToString(),
                        objOItem_TextParser, new clsOntologyItem
                        {
                            GUID = fields.First().ID_Field,
                            Name = fields.First().Name_Field,
                            GUID_Parent = objLocalConfig.OItem_class_field.GUID,
                            Type = objLocalConfig.Globals.Type_Object
                        });

                    if (docItem != null)
                    {
                        if (!OpenLastModuleToolStripMenuItem.Checked || string.IsNullOrEmpty(strLastModule))
                        {
                            objFrmModules = new frmModules(objLocalConfig.Globals, docItem);
                            objFrmModules.ShowDialog(this);

                            if (objFrmModules.DialogResult == DialogResult.OK)
                            {
                                var strModule = objFrmModules.Selected_Module;
                                if (!string.IsNullOrEmpty(strModule))
                                {
                                    if (objShellWork.start_Process(strModule, "Item=" + docItem.GUID + ",Object",
                                                                   System.IO.Path.GetDirectoryName(strModule), false, false))
                                    {
                                        strLastModule = strModule;
                                        OpenLastModuleToolStripMenuItem.ToolTipText = strLastModule;
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, "Das Modul konnte nicht gestartet werden!", "Fehler!",
                                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (objShellWork.start_Process(strLastModule, "Item=" + docItem.GUID + ",Object",
                                                                   System.IO.Path.GetDirectoryName(strLastModule), false, false))
                            {
                                OpenLastModuleToolStripMenuItem.ToolTipText = strLastModule;
                            }
                            else
                            {
                                MessageBox.Show(this, "Das Modul konnte nicht gestartet werden!", "Fehler!",
                                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }

                
                }

                

            }
            
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rows = dataGridView_IndexView.SelectedRows.Cast<DataGridViewRow>().ToList();
            
            var documentItems = objDataWork_FieldParser.GetDocumentItems(objOItem_TextParser);

            if (documentItems != null)
            {
                var ids =
                    (from row in
                        rows.Select(
                            row => ((DataRowView) row.DataBoundItem)[objOItem_TextParser.GUID + "_ID"].ToString())
                            .ToList()
                        join docItem in documentItems on row equals docItem.Name into docItems
                        from docItem in docItems.DefaultIfEmpty()
                        where docItem == null
                        select row).ToList();


                if (ids.Any())
                {
                    if (MessageBox.Show(this, "Wollen Sie die Zeilen wirklich löschen?", "Löschen?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var result = objAppDBLevel.Del_Documents(
                            objDataWork_TextParser.OITem_Type != null ? objDataWork_TextParser.OITem_Type.Name : "Doc",
                            ids);

                        if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            foreach (var row in rows)
                            {
                                dataGridView_IndexView.Rows.Remove(row);
                            }

                            if (rows.Count < dataGridView_IndexView.SelectedRows.Count)
                            {
                                MessageBox.Show(this,
                                    "Es existieren Referenzen zu einigen Dokumenten, die sie löschen wollten!",
                                    "Referenzen!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Die Dokumente konnten nicht entfernt werden!", "Fehler!",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            GetPage();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, "Die Liste enthält keine Elemente. Evtl. existieren noch Referenzen!", "Referenzen!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            else
            {
                MessageBox.Show(this, "Beim Ermitteln der Referenzen ist ein Fehler aufgetreten!", "Fehler!",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void toolStripButton_Referenzen_Click(object sender, EventArgs e)
        {
            var documentItems = objDataWork_FieldParser.GetDockumentItemsWithFields(objOItem_TextParser);

            var rows = (from docItem in documentItems
                from row in dataGridView_IndexView.Rows.Cast<DataGridViewRow>().ToList()
                where ((DataRowView) row.DataBoundItem)[objOItem_TextParser.GUID + "_ID"].ToString() == docItem.Name_DocItem
                select new {row, docItem}).ToList();

            rows.ForEach(row =>
            {
                row.row.Cells[row.docItem.Name_Field].Style.BackColor = Color.Yellow;
            });
        }
    }
}
