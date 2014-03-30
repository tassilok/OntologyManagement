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
using System.Web.Script.Serialization;
using OntologyClasses.BaseClasses;

namespace ESMaintenance_Module
{
    public partial class UserControl_ElasticSearch : UserControl
    {
        private clsLocalConfig objLocalConfig;
        private clsDBLevel objDBLevel_Indexes;

        private clsAppDBLevel objAppDBLevel;

        private DataTable dataTable;

        private int page = 0;
        private int pages = 0;
        private int pos = 0;

        public UserControl_ElasticSearch(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            GetIndexes();

        }

        private void GetIndexes()
        {
            objDBLevel_Indexes = new clsDBLevel();
            toolStripComboBox_Indexes.ComboBox.DataSource = null;
            var indexList = objDBLevel_Indexes.IndexList(objLocalConfig.Globals.Server, int.Parse(objLocalConfig.Globals.Port));
            
            var ixList = indexList.OrderBy(ix => ix).ToList();
            ixList.Insert(0, "");
            toolStripComboBox_Indexes.ComboBox.DataSource = ixList;
            toolStripComboBox_Indexes.SelectedIndex = 0;
        }

        private void GetPage()
        {
            
            pos = page * objLocalConfig.Globals.SearchRange;
            if (toolStripComboBox_Indexes.SelectedItem != null && toolStripTextBox_Type.Text != "")
            {
                var index = toolStripComboBox_Indexes.SelectedItem.ToString();
                objAppDBLevel = new clsAppDBLevel(objLocalConfig.Globals.Server, 
                                                  int.Parse(objLocalConfig.Globals.Port), 
                                                  index, 
                                                  objLocalConfig.Globals.SearchRange, 
                                                  objLocalConfig.Globals.Session);
                if (index != "")
                {
                    var Docs = objAppDBLevel.GetData_Documents(index, toolStripTextBox_Type.Text, true, pos, toolStripTextBox_Query.Text == "" ? null : toolStripTextBox_Query.Text);
                    CreateDataTable();

                    
                    foreach (var doc in Docs)
                    {
                        var row = dataTable.Rows.Add();
                        foreach (var key in doc.Dict.Keys)
                        {
                            if (!dataTable.Columns.Contains(key))
                            {
                                var item = doc.Dict[key];

                                dataTable.Columns.Add(key, item.GetType());
                            }
                            row[key] = doc.Dict[key];
                        }
                        if (!dataTable.Columns.Contains("id"))
                        {
                            dataTable.Columns.Add("id", doc.Id.GetType());

                        }
                        row["id"] = doc.Id;
                        

                        
                    //    var row = dataTable.Rows.Add();
                    //    for (int i = 0; i < fieldList.Count; i++)
                    //    {
                    //        if (doc.ContainsKey(fieldList[i].Name_Field))
                    //            row[fieldList[i].Name_Field] = doc[fieldList[i].Name_Field];
                    //    }

                    }
                    bindingSource_Items.DataSource = dataTable;
                    dataGridView_IndexView.DataSource = bindingSource_Items;
                    pos = objAppDBLevel.LastPos;
                    pages = objAppDBLevel.PageCount;
                    page = objAppDBLevel.CurrPage;

                    if (objAppDBLevel.Total > objLocalConfig.Globals.SearchRange)
                    {
                        toolStripLabel_Count.Text = ((page * objLocalConfig.Globals.SearchRange) + 1).ToString() + "-" + ((page + 1) * objLocalConfig.Globals.SearchRange).ToString() + "/" + objAppDBLevel.Total.ToString();
                    }
                    else
                    {
                        toolStripLabel_Count.Text = objAppDBLevel.Total.ToString() + "/" +
                                                    objAppDBLevel.Total.ToString();
                    }
                    toolStripLabel_PageCur.Text = (page + 1).ToString() + "/" + pages.ToString();
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
            //foreach (var field in fieldList.OrderBy(f => f.IsMeta).ThenBy(f => f.OrderId).ToList())
            //{
            //    if (field.ID_DataType == objLocalConfig.OItem_object_bit.GUID)
            //    {
            //        dataTable.Columns.Add(field.Name_Field, typeof(bool));


            //    }
            //    else if (field.ID_DataType == objLocalConfig.OItem_object_int.GUID)
            //    {
            //        dataTable.Columns.Add(field.Name_Field, typeof(int));
            //    }
            //    else if (field.ID_DataType == objLocalConfig.OItem_object_datetime.GUID)
            //    {
            //        dataTable.Columns.Add(field.Name_Field, typeof(DateTime));
            //    }
            //    else if (field.ID_DataType == objLocalConfig.OItem_object_double.GUID)
            //    {
            //        dataTable.Columns.Add(field.Name_Field, typeof(double));
            //    }
            //    else if (field.ID_DataType == objLocalConfig.OItem_object_string.GUID)
            //    {
            //        dataTable.Columns.Add(field.Name_Field, typeof(string));
            //    }
            //}


        }

        private void toolStripButton_Search_Click(object sender, EventArgs e)
        {
            CreateDataTable();
            GetPage();
        }

        private void toolStripComboBox_Indexes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTypes();

        }


        private void GetTypes()
        {
            
            
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

        private void toolStripButton_PageNext_Click(object sender, EventArgs e)
        {
            if (page < pages)
            {
                page++;
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

        private void saveToJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var jss = new JavaScriptSerializer();
            //var index = toolStripComboBox_Indexes.SelectedItem.ToString();
            //objAppDBLevel = new clsAppDBLevel(objLocalConfig.Globals.Server,
            //                                      int.Parse(objLocalConfig.Globals.Port),
            //                                      index,
            //                                      100,
            //                                      objLocalConfig.Globals.Session);
            //pos = 0;
            //var count = 0;
            //do
            //{
            //    List<clsAppDocuments> Docs = objAppDBLevel.GetData_Documents(index, toolStripComboBox_Types.Text, true, pos, toolStripTextBox_Query.Text == "" ? null : toolStripTextBox_Query.Text).Select(d => d.Dict).ToList();
                
            //    var json = jss.Serialize(Docs);

            //    count = 100 - Docs.Count;
            //    pos = pos + Docs.Count;

            //} while (count == 0);

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
