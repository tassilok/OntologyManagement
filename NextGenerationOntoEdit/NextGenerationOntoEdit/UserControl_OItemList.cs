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

namespace NextGenerationOntoEdit
{
    public partial class UserControl_OItemList : UserControl
    {
        private clsLocalConfig localConfig;
        public clsOntologyItem BaseItem { get; private set; }
        public DataTable ItemTable { get; set; }
        private List<DataColumn> dataColumns { get; set; }
        private clsDataWork_OntologyItems objDataWork_OntologyItems;

        private ObjectEdit objectEdit;

        public delegate void AddBindingSource();
        private AddBindingSource addBindingSource;
        public delegate void LoadedData();
        private LoadedData loadedData;
        public delegate void StartLoadingData();
        private StartLoadingData startLoadingData;
        public delegate void AddRows();
        private AddRows addRows;
        private int intRowID;

        private List<DataRow> dataRowList;

        public UserControl_OItemList(clsLocalConfig localConfig)
        {
            InitializeComponent();

            this.localConfig = localConfig;
            Initialize();
        }


        private void Initialize()
        {
            objDataWork_OntologyItems = new clsDataWork_OntologyItems(localConfig);
            objDataWork_OntologyItems.loadItems += objDataWork_OntologyItems_loadItems;

            addBindingSource = new AddBindingSource(AddDataSource);
            loadedData = new LoadedData(DataLoadFinished);
            startLoadingData = new StartLoadingData(DataLoadStart);
            addRows = new AddRows(AddRowsToTable);
        }

        private void AddRowsToTable()
        {
            dataRowList.ForEach(row =>
                {
                    ItemTable.Rows.Add(row);
                });

            dataRowList = new List<DataRow>();
        }

        private void DataLoadStart()
        {
            
            toolStripProgressBar_ItemLoad.Value = 50;
            //timer_Refresh.Start();
        }

        private void DataLoadFinished()
        {
            toolStripProgressBar_ItemLoad.Value = 0;
            //timer_Refresh.Stop();
        }

        private void AddDataSource()
        {
            bindingSource_Items.DataSource = ItemTable;
            dataGridView_OItems.DataSource = bindingSource_Items;
            dataGridView_OItems.Columns["GUID"].Visible = false;
            dataGridView_OItems.Columns["GUID_Parent"].Visible = false;
            bindingNavigator_Items.BindingSource = bindingSource_Items;
        }

        void objDataWork_OntologyItems_loadItems(LoadResult loadResult, clsOntologyItem OItem_Result)
        {
            if (loadResult == LoadResult.Items)
            {
                if (OItem_Result.GUID == localConfig.Globals.LState_Success.GUID)
                {
                    dataRowList = new List<DataRow>();
                    ItemTable = new DataTable();
                    var classAttributes = objDataWork_OntologyItems.ClassAttributes;
                    var classRelations = objDataWork_OntologyItems.ClassRelations;
                    var objAtts = objDataWork_OntologyItems.ObjectAttributes;
                    var objRels = objDataWork_OntologyItems.ObjectRelations;
                    var otherRels = objDataWork_OntologyItems.OtherRelations;
                    var objects = objDataWork_OntologyItems.Objects;

                    dataColumns = new List<DataColumn>();
                    dataColumns.Add(new DataColumn("GUID", typeof(string)));
                    dataColumns.Add(new DataColumn("Name", typeof(string)));
                    dataColumns.Add(new DataColumn("GUID_Parent", typeof(string)));

                    classAttributes.ForEach(classAtt =>
                        {
                            var dataColumn = new DataColumn(classAtt.Name_AttributeType, typeof(string));
                            dataColumns.Add(dataColumn);

                        });

                    classRelations.ForEach(classRel =>
                        {
                            dataColumns.Add(new DataColumn(classRel.Name_Class_Right + "_" + classRel.Name_RelationType
                                ,typeof(string)));                      
                        });

                    var otherColRels = otherRels.GroupBy(other => other.Name_RelationType + "_" + other.Ontology).ToList();

                    var colID = 1;
                    otherColRels.ForEach(other =>
                        {
                            var colName = other.Key;
                            var existance = dataColumns.Where(nameItem => nameItem.ColumnName.ToLower() == other.Key.ToLower());

                            while (existance.Any())
                            {
                                colName += "_" + colID.ToString();
                                existance = dataColumns.Where(nameItem => nameItem.ColumnName.ToLower() == other.Key.ToLower());
                            }

                            dataColumns.Add(new DataColumn(colName, typeof(string)));
                        });

                    dataColumns.ForEach(col =>
                        {
                            ItemTable.Columns.Add(col);
                        }
                        );

                    if (this.InvokeRequired)
                    {
                        this.Invoke(addBindingSource);

                    }
                    else
                    {
                        AddDataSource();
                    }

                    var typedObjAtts = (from objAtt in objAtts
                                        join objectItem in objects on objAtt.ID_Object equals objectItem.GUID
                                        join classAtt in classAttributes on new { ID_Class = objAtt.ID_Class, ID_AttributeType = objAtt.ID_AttributeType }
                                            equals new { ID_Class = classAtt.ID_Class, ID_AttributeType = classAtt.ID_AttributeType }
                                        select new { objAtt, classAtt, objectItem }).OrderBy(item => item.objAtt.OrderID).ToList();

                    var relItemsTyped = (from relItem in objRels
                                         join objectItem in objects on relItem.ID_Object equals objectItem.GUID
                                   join classRel in classRelations on relItem.ID_Parent_Other equals classRel.ID_Class_Right
                                   select new { relItem, classRel, objectItem}).OrderBy(item => item.relItem.OrderID).ToList();

                    var otherItems = (from relItem in otherRels
                                      join objectItem in objects on relItem.ID_Object equals objectItem.GUID
                                      select new { relItem, objectItem }).OrderBy(item => item.relItem.OrderID).ToList();


                    objects.ForEach(objectItem =>
                        {
                            var dataRow = ItemTable.NewRow();
                            dataRow["GUID"] = objectItem.GUID;
                            dataRow["Name"] = objectItem.Name;
                            dataRow["GUID_Parent"] = objectItem.GUID_Parent;

                            var atts = typedObjAtts.Where(item => item.objectItem.GUID == objectItem.GUID).ToList();

                            atts.ForEach(att =>
                                {
                                    var columns = dataColumns.Where(col => col.ColumnName == att.classAtt.Name_AttributeType).ToList();
                                    if (columns.Any())
                                    {
                                        if (dataRow[columns.First()] == null)
                                        {
                                            dataRow[columns.First()] = "";
                                        }
                                        dataRow[columns.First()] += att.objAtt.Val_Name + "\n";
                                    }
                                });


                            var rels1 = relItemsTyped.Where(rel => rel.objectItem.GUID == objectItem.GUID).ToList();

                            rels1.ForEach(rel =>
                                {
                                    var columns = dataColumns.Where(col => col.ColumnName == rel.classRel.Name_Class_Right + "_" + rel.classRel.Name_RelationType);
                                    if (columns.Any())
                                    {
                                        if (dataRow[columns.First()] == null)
                                        {
                                            dataRow[columns.First()] = "";
                                        }
                                        dataRow[columns.First()] += rel.relItem.Name_Other + "\n";
                                    }
                                });

                            var rels2 = otherItems.Where(rel => rel.objectItem.GUID == objectItem.GUID).ToList();
                            rels2.ForEach(rel =>
                                {

                                    
                                    for (int i = 0; i < 5; i++)
                                    {
                                        var columns = dataColumns.Where(col => col.ColumnName == rel.relItem.Name_RelationType + "_" + rel.relItem.Ontology + (i>0 ? "_" + i : ""));
                                        if (columns.Any())
                                        {
                                            if (dataRow[columns.First()] == null)
                                            {
                                                dataRow[columns.First()] = "";
                                            }
                                            dataRow[columns.First()] += rel.relItem.Name_Other + "\n";
                                            break;
                                        }
                                    }
                                });

                            dataRowList.Add(dataRow);

                            if ((dataRowList.Count % 1000) == 0)
                            {
                                if (this.InvokeRequired)
                                {
                                    this.Invoke(addRows);
                                }
                                else
                                {
                                    AddRowsToTable();
                                }
                            }
                        });

                    if (dataRowList.Any())
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(addRows);
                        }
                        else
                        {
                            AddRowsToTable();
                        }
                    }

                }

            }

            if (this.InvokeRequired)
            {
                this.Invoke(loadedData);
            }
            else
            {
                DataLoadFinished();
            }
        }

        

        public void Initialize_Items(clsOntologyItem baseItem)
        {
            BaseItem = baseItem;

            if (BaseItem.Type == localConfig.Globals.Type_AttributeType)
            {
            }
            else if (BaseItem.Type == localConfig.Globals.Type_Class)
            {
                DataLoadStart();
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
            objDataWork_OntologyItems.GetData_ClassItems(BaseItem);
        }

        private void toolStripButton_Refresh_Click(object sender, EventArgs e)
        {
            dataGridView_OItems.Refresh();
        }

        private void dataGridView_OItems_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var objectList = dataGridView_OItems.Rows.Cast<DataGridViewRow>().Select(row => (DataRowView)row.DataBoundItem).Select(row => new clsOntologyItem
            {
                GUID = row["GUID"].ToString(),
                Name = row["Name"].ToString(),
                GUID_Parent = row["GUID_Parent"].ToString(),
                Type = localConfig.Globals.Type_Object
            }).ToList();

            objectEdit = new ObjectEdit(localConfig, objectList, e.RowIndex);
            objectEdit.ShowDialog(this);
        }


    }
}

