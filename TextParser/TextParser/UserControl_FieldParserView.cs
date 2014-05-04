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
using Filesystem_Module;
using System.IO;
using System.Text.RegularExpressions;

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

        private frm_ObjectEdit objFrmObjectEdit;

        private clsAppDBLevel objAppDBLevel;

        private clsDBLevel objDBLevel_Indexes;

        private clsFieldParser objFieldParser;

        private SortableBindingList<clsField> fieldList;

        private DataTable dataTable;


        private int page = 0;
        private int pages = 0;
        private int pos = 0;

        private int port = 0;
        private string server = "";
        private string index = "";
        private List<string> indexes = new List<string>();
        private List<clsOntologyItem> OList_Variables;
        private bool pIndexFill = false;

        public UserControl_FieldParserView(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            
            objLocalConfig = LocalConfig;

            Initialize();
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
                                            
                                            pIndexFill = true;
                                            GetIndexes();
                                            pIndexFill = false;
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
        }

        private void Initialize()
        {
            
            indexes.Clear();

            objDataWork_FieldParser = new clsDataWork_FieldParser(objLocalConfig);

            objDataWork_TextParser = new clsDataWork_TextParser(objLocalConfig);
            objDataWork_FileResource = new clsDataWork_FileResources(objLocalConfig.Globals);
            objDataWork_FileResource_Path = new clsDataWork_FileResource_Path(objLocalConfig.Globals);

            
        }

       
        private void GetFields()
        {
            var objOItem_Result = objDataWork_FieldParser.GetData_FieldsOfFieldParser();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                fieldList = new SortableBindingList<clsField>(objDataWork_FieldParser.FieldList.Where(p => p.ID_FieldParser == objOItem_Parser.GUID).OrderBy(f => f.OrderId).ThenBy(f => f.Name_Field));
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
                    var Docs = objAppDBLevel.GetData_Documents(index, objDataWork_TextParser.OITem_Type != null ? objDataWork_TextParser.OITem_Type.Name : "Doc", true, pos, toolStripTextBox_Query.Text == "" ? null : toolStripTextBox_Query.Text).Select(d => d.Dict).ToList();
                    CreateDataTable();

                    foreach (var doc in Docs)
                    {
                        var row = dataTable.Rows.Add();
                        for(int i = 0;i<fieldList.Count;i++)
                        {
                            if (doc.ContainsKey(fieldList[i].Name_Field))
                                row[fieldList[i].Name_Field] = doc[fieldList[i].Name_Field];
                        }

                    }
                    bindingSource_Items.DataSource = dataTable;
                    dataGridView_IndexView.DataSource = bindingSource_Items;
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
            var fieldList = (SortableBindingList<clsField>) dataGridView_Fields.DataSource;
            if (fieldList.Any())
            {
                
                objFieldParser = new clsFieldParser(objLocalConfig,fieldList.ToList(),objOItem_TextParser, objDataWork_TextParser.OITem_Type);
                objFieldParser.OList_Seperator = objDataWork_TextParser.OList_LineSeperator.Select(s => new clsOntologyItem
                {
                    GUID = s.GUID,
                    Name = s.Name,
                    GUID_Parent = objLocalConfig.OItem_class_text_seperators.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                }).ToList();
                objFieldParser.ParseFiles();
            }
            GetIndexes();
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
            GetPage();
        }

        private void toolStripTextBox_Query_TextChanged(object sender, EventArgs e)
        {
            page = 0;
            pages = 0;
            pos = 0;
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
            if (toolStripComboBox_Indexes.SelectedItem != null)
            {
                
                var index = toolStripComboBox_Indexes.SelectedItem.ToString();
                objDBLevel_Indexes = new clsDBLevel(server,port,index,objLocalConfig.Globals.Index_Rep,objLocalConfig.Globals.SearchRange,objLocalConfig.Globals.Session);
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
            if (dataGridView_Fields.SelectedCells.Count == 1)
            {
                if (dataGridView_Fields.Columns[dataGridView_Fields.SelectedCells[0].ColumnIndex].DataPropertyName ==
                    "Name_Field")
                {
                    editToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void editOItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var field = (clsField) dataGridView_Fields.Rows[dataGridView_Fields.SelectedCells[0].RowIndex].DataBoundItem;
            if (dataGridView_Fields.Columns[dataGridView_Fields.SelectedCells[0].ColumnIndex].DataPropertyName ==
                    "Name_Field")
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

                objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals,objOList,0,objLocalConfig.Globals.Type_Object,null);
                objFrmObjectEdit.ShowDialog(this);
            }
        }
    }
}
