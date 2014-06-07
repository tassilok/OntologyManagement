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
using OntologyClasses.BaseClasses;
using Structure_Module;
using Hierarchichal_Splitter_Module.Attributes;

namespace Hierarchichal_Splitter_Module
{
    public partial class frmHierarchicalSplitter : Form
    {

        private clsLocalConfig objLocalConfig;

        private clsDataWork_HierarchicalSplitter objDataWork_HierarchicalSplitter;

        private frmMain objFrmOntologyModule;

        private clsOntologyItem objOItem_RelationType;
        private clsOntologyItem objOItem_RelRule;
        private clsOntologyItem objOItem_CreateRule;
        private clsOntologyItem objOItem_HierarchicalProfile;
        private clsOntologyItem objOItem_Splitter;

        private clsDBLevel objDBLevel_Integration;
        private clsDBLevel objDBLevel_Relations;

        private SortableBindingList<clsProfileItem> ItemList;

        private List<clsOntologyItem> objectList;
        private List<clsOntologyItem> createList;
        private List<clsObjectRel> objectRelationList;

        private clsRelationConfig objRelationConfig;

        public frmHierarchicalSplitter()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(new clsGlobals());
            Initialize();
        }

        private void Initialize()
        {
            objDataWork_HierarchicalSplitter = new clsDataWork_HierarchicalSplitter(objLocalConfig);

            objDBLevel_Integration = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Relations = new clsDBLevel(objLocalConfig.Globals);

            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);

            Configure_Controls();

            comboBox_ItemCreationRule.Items.Add(objLocalConfig.OItem_object_create_new_item);
            comboBox_ItemCreationRule.Items.Add(objLocalConfig.OItem_object_take_existing_item);
            comboBox_ItemCreationRule.ValueMember = "GUID";
            comboBox_ItemCreationRule.DisplayMember = "Name";

            comboBox_RelationCreationRule.Items.Add(objLocalConfig.OItem_object_no_other_relations_of_this_type);
            comboBox_RelationCreationRule.ValueMember = "GUID";
            comboBox_RelationCreationRule.DisplayMember = "Name";
        }

        private void Configure_Controls()
        {
            toolStripButton_ClearList.Enabled = false;
            toolStripButton_Integrate.Enabled = false;
            toolStripButton_CreateList.Enabled = false;

            if (toolStripTextBox_Path.Text.Any() 
                && toolStripTextBox_Splitter.Text.Any()
                && comboBox_ItemCreationRule.Text.Any())
            {
                toolStripButton_CreateList.Enabled = true;
            }

            if (dataGridView_Items.RowCount > 0)
            {
                toolStripButton_ClearList.Enabled = false;
                toolStripButton_Integrate.Enabled = true;
            }
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_GetRelationType_Click(object sender, EventArgs e)
        {
            objFrmOntologyModule = new frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_RelationType);
            objFrmOntologyModule.ShowDialog(this);
            if (objFrmOntologyModule.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (objFrmOntologyModule.OList_Simple.Count == 1)
                {
                    if (objFrmOntologyModule.OList_Simple.First().Type == objLocalConfig.Globals.Type_RelationType)
                    {
                        objOItem_RelationType = objFrmOntologyModule.OList_Simple.First().Clone();
                        textBox_RelationType.Text = objOItem_RelationType.Name;
                    }
                    else
                    {
                        MessageBox.Show(this, "Bitte wählen Sie nur einen Beziehungstyp aus!", "Beziehungstype", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Bitte wählen Sie nur einen Beziehungstyp aus!", "Beziehungstype", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void comboBox_ItemCreationRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            objOItem_CreateRule = (clsOntologyItem)comboBox_ItemCreationRule.SelectedItem;
            Configure_Controls();
        }

        private void comboBox_RelationCreationRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            objOItem_RelRule = (clsOntologyItem)comboBox_RelationCreationRule.SelectedItem;
            Configure_Controls();
        }

        private void toolStripTextBox_Splitter_TextChanged(object sender, EventArgs e)
        {
            Configure_Controls();
        }

        private void toolStripButton_CreateList_Click(object sender, EventArgs e)
        {
            var textToSplit = toolStripTextBox_Path.Text;
            var splitter = toolStripTextBox_Splitter.Text;
            var doRegEx = toolStripButton_Regex.Checked;

            List<string> splittedText;

            splittedText = textToSplit.Split(splitter.ToCharArray()).ToList();

            var orderID = 1;
            var itemList = splittedText.Select(st => new clsProfileItem
            {
                Name_Item = st.Length > 255 ? st.Substring(0,254) : st,
                NameShorted = st.Length > 255 ? true : false,
                Id_CreateRule = ((clsOntologyItem) comboBox_ItemCreationRule.SelectedItem).GUID,
                Name_CreateRule = ((clsOntologyItem) comboBox_ItemCreationRule.SelectedItem).Name,
                Id_RelationRule = comboBox_RelationCreationRule.SelectedItem != null ? ((clsOntologyItem) comboBox_RelationCreationRule.SelectedItem).GUID : null,
                Name_RelationRule = comboBox_RelationCreationRule.SelectedItem != null ? ((clsOntologyItem)comboBox_RelationCreationRule.SelectedItem).Name : null,
                Id_RelationTypeToSubordinated = objOItem_RelationType != null ? objOItem_RelationType.GUID : null,
                Name_RelationTypeToSubordinated = objOItem_RelationType != null ? objOItem_RelationType.Name : null,
                OrderId = orderID++
            }).ToList();

            
            if (objDataWork_HierarchicalSplitter.ProfileItems.Any())
            {
                ItemList = new SortableBindingList<clsProfileItem> (from objProfileItem in objDataWork_HierarchicalSplitter.ProfileItems
                            join objItem in itemList on objProfileItem.OrderId equals objItem.OrderId into objItems
                            from objItem in objItems.DefaultIfEmpty()
                            select new clsProfileItem
                            {
                                Id_CreateRule = objProfileItem.Id_CreateRule,
                                Id_HierarchicalProfile = objProfileItem.Id_HierarchicalProfile,
                                Id_Ontology = objProfileItem.Id_Ontology,
                                Id_Parent = objProfileItem.Id_Parent,
                                Id_RelationRule = objProfileItem.Id_RelationRule,
                                Id_RelationTypeToSubordinated = objItem.Id_RelationTypeToSubordinated,
                                Imported = false,
                                Name_CreateRule = objProfileItem.Name_CreateRule,
                                Name_HierarchicalProfile = objProfileItem.Name_HierarchicalProfile,
                                Name_Item = objItem != null ? objItem.Name_Item : null,
                                Name_Ontology = objProfileItem.Name_Ontology,
                                Name_Parent = objProfileItem.Name_Parent,
                                Name_RelationRule = objProfileItem.Name_RelationRule,
                                Name_RelationTypeToSubordinated = objItem.Name_RelationTypeToSubordinated,
                                NameShorted = objItem != null ? objItem.NameShorted : false,
                                OrderId = objProfileItem.OrderId,
                                Type = objProfileItem.Type
                            });
            }
            else
            {
                ItemList = new SortableBindingList<clsProfileItem>( itemList);
            }

            Configure_DataGrids();
        }

        private void toolStripButton_AddProfile_Click(object sender, EventArgs e)
        {

            if (dataGridView_Items.RowCount > 0)
            {
                if (MessageBox.Show(this, "Wollen Sie wirklich ein Profil auswählen? Ihre Änderungen gehen verloren!", "Änderungen verwerfen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    GetProfile();
                }
            }
            else
            {
                GetProfile();
            }
            
        }

        private void GetProfile()
        {
            objFrmOntologyModule = new frmMain(objLocalConfig.Globals,
                objLocalConfig.Globals.Type_Class,
                new clsOntologyItem
                {
                    GUID = objLocalConfig.OItem_class_hierarchical_profiles.GUID,
                    Type = objLocalConfig.Globals.Type_Class
                }, objLocalConfig.OItem_class_hierarchical_profiles.Name);

            objFrmOntologyModule.ShowDialog(this);

            if (objFrmOntologyModule.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (objFrmOntologyModule.OList_Simple.Count == 1)
                {
                    if (objFrmOntologyModule.OList_Simple.First().GUID_Parent == objLocalConfig.OItem_class_hierarchical_profiles.GUID)
                    {
                        objOItem_HierarchicalProfile = objFrmOntologyModule.OList_Simple.First().Clone();
                        var objOItem_Result = objDataWork_HierarchicalSplitter.GetData_HierarchicalProfile(objOItem_HierarchicalProfile);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objOItem_RelationType = objDataWork_HierarchicalSplitter.OItem_RelationType;
                            if (objOItem_RelationType != null)
                            {
                                textBox_RelationType.Text = objOItem_RelationType.Name;
                            }

                            objOItem_Splitter = objDataWork_HierarchicalSplitter.OItem_Seperator;

                            if (objOItem_Splitter != null)
                            {
                                toolStripTextBox_Splitter.ReadOnly = true;
                                toolStripTextBox_Splitter.Text = objOItem_Splitter.Name;
                                toolStripTextBox_Splitter.ReadOnly = false;
                            }
                            if (objDataWork_HierarchicalSplitter.OItem_RelationRule != null)
                            {
                                foreach (clsOntologyItem item in comboBox_RelationCreationRule.Items)
                                {
                                    if (item.GUID == objDataWork_HierarchicalSplitter.OItem_RelationRule.GUID)
                                    {
                                        comboBox_RelationCreationRule.SelectedItem = item;
                                        break;
                                    }
                                }
                                
                            }

                            if (objDataWork_HierarchicalSplitter.OItem_CreationRule != null)
                            {
                                foreach (clsOntologyItem item in comboBox_ItemCreationRule.Items)
                                {
                                    if (item.GUID == objDataWork_HierarchicalSplitter.OItem_CreationRule.GUID)
                                    {
                                        comboBox_ItemCreationRule.SelectedItem = item;
                                        break;
                                    }
                                }
                                
                            }
                            ItemList = new SortableBindingList<clsProfileItem>(objDataWork_HierarchicalSplitter.ProfileItems);

                            CreateRelationList();

                            Configure_DataGrids();
                            toolStripTextBox_Profile.Text = objOItem_HierarchicalProfile.Name;
                        }
                        else
                        {
                            MessageBox.Show(this, "Beim Ermitteln der Profil-Daten ist ein Fehler unterlaufen!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                    else
                    {
                        MessageBox.Show(this, "Wählen Sie bitte ein hierarchisches Profil.", "Profil wählen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Wählen Sie bitte ein hierarchisches Profil.", "Profil wählen", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void Configure_DataGrids()
        {
            dataGridView_Items.DataSource = ItemList;

            var typeItem = typeof(clsProfileItem);
            foreach (var propertyInfo in typeItem.GetProperties())
            {
                GridConfigureAttribute gridConfigureAttribute = null;
                foreach (var customAttribute in propertyInfo.GetCustomAttributes(true))
                {
                    if (customAttribute is GridConfigureAttribute)
                    {
                        gridConfigureAttribute = (GridConfigureAttribute)customAttribute;
                        break;
                    }
                }

                if (gridConfigureAttribute != null)
                {
                    var columns = dataGridView_Items.Columns.Cast<DataGridViewColumn>().Where(col => col.DataPropertyName == propertyInfo.Name).ToList();

                    if (columns.Any())
                    {
                        dataGridView_Items.Columns[columns.First().DataPropertyName].Visible = gridConfigureAttribute.Visible;
                    }
                }
            }

            dataGridView_Relations.DataSource = new SortableBindingList<ClassRelation>(objDataWork_HierarchicalSplitter.RelationItems);

            List<DataGridViewColumnConfig> dgvCols = new List<DataGridViewColumnConfig>();

            foreach (DataGridViewColumn column  in dataGridView_Relations.Columns)
            {
                column.Visible = false;
                
                var columnConfig = new DataGridViewColumnConfig {Column = column, 
                    Visible = false,
                    DisplayOrderId = 0 };
                dgvCols.Add(columnConfig);


                if (column.DataPropertyName == "Name_Class_Left")
                {
                    columnConfig.Visible = true;
                    columnConfig.DisplayOrderId = 0;
                    
                }

                if (column.DataPropertyName == "Name_Class_Right")
                {
                    columnConfig.Visible = true;
                    columnConfig.DisplayOrderId = 2;
                }

                if (column.DataPropertyName == "Name_RelationType")
                {
                    columnConfig.Visible = true;
                    columnConfig.DisplayOrderId = 1;
                }

                if (column.DataPropertyName.ToLower() == "min_forw")
                {
                    columnConfig.Visible = true;
                    columnConfig.DisplayOrderId = 3;
                }

                if (column.DataPropertyName.ToLower() == "max_forw")
                {
                    columnConfig.Visible = true;
                    columnConfig.DisplayOrderId = 4;
                }

                if (column.DataPropertyName.ToLower() == "max_backw")
                {
                    columnConfig.Visible = true;
                    columnConfig.DisplayOrderId = 5;
                }

                if (column.DataPropertyName.ToLower() == "exists")
                {
                    columnConfig.Visible = true;
                    columnConfig.DisplayOrderId = 6;
                }
                
            }

            foreach (var column in dgvCols.OrderBy(c => c.DisplayOrderId).ToList())
            {
                column.Column.Visible = column.Visible;
                if (column.Column.Visible)
                {
                    column.Column.DisplayIndex = column.DisplayOrderId;
                }
            }
            
        }

        private void toolStripTextBox_Splitter_Leave(object sender, EventArgs e)
        {
            Configure_Controls();

        }

        private void toolStripTextBox_Path_TextChanged(object sender, EventArgs e)
        {
            Configure_Controls();
        }

        private void toolStripButton_Integrate_Click(object sender, EventArgs e)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            objectList = new List<clsOntologyItem>();
            createList = new List<clsOntologyItem>();
            objectRelationList = new List<clsObjectRel>();
            foreach (var item in ItemList)
            {
                
                if (item.Type == objLocalConfig.Globals.Type_Object)
                {
                    if (item.Id_CreateRule == objLocalConfig.OItem_object_create_new_item.GUID)
                    {
                        var oItem = new clsOntologyItem
                        {
                            GUID = objLocalConfig.Globals.NewGUID,
                            Name = item.Name_Item,
                            GUID_Parent = item.Id_Parent,
                            Type = objLocalConfig.Globals.Type_Object
                        };


                        objOItem_Result = AddRelationItem(oItem);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            createList.Add(oItem);
                            objectList.Add(oItem);
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                    else
                    {
                        if (item.Id_Parent != null && item.Name_Item != null)
                        {
                            var searchObjects = new List<clsOntologyItem> {new clsOntologyItem {Name = item.Name_Item,
                                GUID_Parent = item.Id_Parent } };

                            objOItem_Result = objDBLevel_Integration.get_Data_Objects(searchObjects);

                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                var objects = objDBLevel_Integration.OList_Objects.Where(o => o.Name == item.Name_Item).ToList();
                                if (objects.Any())
                                {
                                    var oItem = objects.First().Clone();
                                    objOItem_Result = AddRelationItem(oItem);
                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        objectList.Add(oItem);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                    
                                }
                                else
                                {
                                    var oItem = new clsOntologyItem
                                    {
                                        GUID = objLocalConfig.Globals.NewGUID,
                                        Name = item.Name_Item,
                                        GUID_Parent = item.Id_Parent,
                                        Type = objLocalConfig.Globals.Type_Object
                                    };
                                    objOItem_Result = AddRelationItem(oItem);
                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        createList.Add(oItem);
                                        objectList.Add(oItem);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                    
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                            break;
                        }
                    }
                    
                }
                else
                {

                }
            }

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (createList.Any())
                {
                    objOItem_Result = objDBLevel_Integration.save_Objects(createList);
                }
                
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var createClassRelations = objDataWork_HierarchicalSplitter.RelationItems.Where(ri => !ri.Exists).Select(ri => new clsClassRel
                    {
                        ID_Class_Left = ri.ID_Class_Left,
                        ID_Class_Right = ri.ID_Class_Right,
                        ID_RelationType = ri.ID_RelationType,
                        Ontology = ri.Ontology,
                        Min_Forw = ri.Min_Forw,
                        Max_Forw = ri.Max_Forw,
                        Max_Backw = ri.Max_Backw
                    }).ToList();

                    if (createClassRelations.Any())
                    {
                        objOItem_Result = objDBLevel_Integration.save_ClassRel(createClassRelations);
                    }

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objOItem_Result = objDBLevel_Integration.get_Data_ObjectRel(objectRelationList);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            var createRelations = (from objRel in objectRelationList
                                                   join objIndexedRel in objDBLevel_Integration.OList_ObjectRel_ID
                                                       on new { ID_Object = objRel.ID_Object, ID_Other = objRel.ID_Other, ID_RelationType = objRel.ID_RelationType }
                                                       equals new { ID_Object = objIndexedRel.ID_Object, ID_Other = objIndexedRel.ID_Other, ID_RelationType = objIndexedRel.ID_RelationType } into objIndexedRels
                                                   from objIndexedRel in objIndexedRels.DefaultIfEmpty()
                                                   where objIndexedRel == null
                                                   select objRel).ToList();
                            if (createRelations.Any())
                            {
                                objOItem_Result = objDBLevel_Integration.save_ObjRel(createRelations);

                            }

                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                ItemList.ToList().ForEach(i => i.Imported = true);

                                dataGridView_Items.Refresh();
                            }
                            else
                            {
                                MessageBox.Show(this, "Die Beziehungen konnten aufgrund von Fehlern in der Tabelle nicht hergestellt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }

                        }
                        else
                        {
                            MessageBox.Show(this, "Die Beziehungen konnten aufgrund von Fehlern in der Tabelle nicht hergestellt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Die Beziehungen konnten aufgrund von Fehlern in der Tabelle nicht hergestellt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    

                }
                else
                {
                    MessageBox.Show(this, "Die Beziehungen konnten aufgrund von Fehlern in der Tabelle nicht hergestellt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                

            }
            else
            {
                MessageBox.Show(this, "Die Beziehungen konnten aufgrund von Fehlern in der Tabelle nicht hergestellt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private clsOntologyItem CreateRelationList()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            objDataWork_HierarchicalSplitter.RelationItems = new List<ClassRelation>();
            var relationItems = new List<clsClassRel>();
            for (var i = 0; i < objDataWork_HierarchicalSplitter.ProfileItems.Count - 1;i++ )
            {
                relationItems.Add(new clsClassRel
                {
                    ID_Class_Left = objDataWork_HierarchicalSplitter.ProfileItems[i].Id_Parent,
                    Name_Class_Left = objDataWork_HierarchicalSplitter.ProfileItems[i].Name_Parent,
                    ID_RelationType = objOItem_RelationType.GUID,
                    Name_RelationType = objOItem_RelationType.Name,
                    ID_Class_Right = objDataWork_HierarchicalSplitter.ProfileItems[i + 1].Id_Parent,
                    Name_Class_Right = objDataWork_HierarchicalSplitter.ProfileItems[i + 1].Name_Parent,
                    Min_Forw = 0,
                    Max_Forw = -1,
                    Max_Backw = -1,
                    Ontology = objLocalConfig.Globals.Type_Class
                });
            }

            objOItem_Result = objDBLevel_Relations.get_Data_ClassRel(relationItems,true);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objDataWork_HierarchicalSplitter.RelationItems = (from objRel in relationItems
                                                                  join objRelIndexed in objDBLevel_Relations.OList_ClassRel_ID on new
                                                                  {
                                                                      ID_Class_Left = objRel.ID_Class_Left,
                                                                      ID_Class_Right = objRel.ID_Class_Right,
                                                                      ID_RelationType = objRel.ID_RelationType
                                                                  } equals new
                                                                  {
                                                                      ID_Class_Left = objRelIndexed.ID_Class_Left,
                                                                      ID_Class_Right = objRelIndexed.ID_Class_Right,
                                                                      ID_RelationType = objRelIndexed.ID_RelationType
                                                                  } into objRelsIndexed
                                                                  from objRelIndexed in objRelsIndexed.DefaultIfEmpty()
                                                                  select new ClassRelation
                                                                  {
                                                                      ID_Class_Left = objRel.ID_Class_Left,
                                                                      Name_Class_Left = objRel.Name_Class_Left,
                                                                      ID_Class_Right = objRel.ID_Class_Right,
                                                                      Name_Class_Right = objRel.Name_Class_Right,
                                                                      ID_RelationType = objRel.ID_RelationType,
                                                                      Name_RelationType = objRel.Name_RelationType,
                                                                      Min_Forw = objRelIndexed != null ? objRelIndexed.Min_Forw : objRel.Min_Forw,
                                                                      Max_Forw = objRelIndexed != null ? objRelIndexed.Max_Forw : objRel.Max_Forw,
                                                                      Max_Backw = objRelIndexed != null ? objRelIndexed.Max_Backw : objRel.Max_Backw,
                                                                      Ontology = objRel.Ontology,
                                                                      Exists = objRelIndexed != null
                                                                  }).ToList();
            }

            return objOItem_Result;
        }

        private clsOntologyItem AddRelationItem(clsOntologyItem oItem)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            if (objectList.Any())
            {
                var objectParent = objectList.Last();

                objectRelationList.Add(objRelationConfig.Rel_ObjectRelation(objectParent, oItem,objOItem_RelationType));

            }

            return objOItem_Result;
        }
    }
}
