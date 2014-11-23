using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseConfigurationModule
{
    public partial class UserControl_ConfiguratorTree : UserControl
    {

        private clsLocalConfig objLocalConfig;

        private clsDataWork_DatabaseConfiguratorModule objDataWork_DatabaseConfigurationModule;

        private TreeNode treeNode_Root;
        private TreeNode treeNode_DatabaseSchemas;

        public delegate void AddSchemaNode();
        private AddSchemaNode addSchemaNode;
        public delegate void AddSchemaTableNode();
        private AddSchemaTableNode addSchemaTableNode;
        public delegate void AddSchemaDatabaseNode();
        private AddSchemaDatabaseNode addSchemaDatabaseNode;
        public delegate void AddSchemaTableColumnsNode();
        private AddSchemaTableColumnsNode addSchemaTableColumnsNode;
        public delegate void AddSchemaRoutinesNode();
        private AddSchemaRoutinesNode addSchemaRoutinesNode;
        public delegate void ConfigurePrimaryKeys();
        private ConfigurePrimaryKeys configurePrimaryKeys;

        public UserControl_ConfiguratorTree(clsLocalConfig LocalConfig, clsDataWork_DatabaseConfiguratorModule DataWork_DatabaseConfiguratorModule = null)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;

            objDataWork_DatabaseConfigurationModule = DataWork_DatabaseConfiguratorModule;

            Initialize();
        }

        private void Initialize()
        {

            if (objDataWork_DatabaseConfigurationModule == null)
            {
                objDataWork_DatabaseConfigurationModule = new clsDataWork_DatabaseConfiguratorModule(objLocalConfig);
            }
            objDataWork_DatabaseConfigurationModule.loadItems += objDataWork_DatabaseConfigurationModule_loadedItems;
            objDataWork_DatabaseConfigurationModule.GetData();

            addSchemaNode = new AddSchemaNode(AddTreeNode_Schema);
            addSchemaTableNode = new AddSchemaTableNode(AddTreeNode_SchemaTable);
            addSchemaDatabaseNode = new AddSchemaDatabaseNode(AddTreeNode_SchemaDatabase);
            addSchemaTableColumnsNode = new AddSchemaTableColumnsNode(AddTreeNode_SchemaColumns);
            addSchemaRoutinesNode = new AddSchemaRoutinesNode(AddTreeNode_SchemaRoutines);
            configurePrimaryKeys = new ConfigurePrimaryKeys(ConfigurePrimaryKeysNodes);
            FillTree();


        }

        private void ConfigurePrimaryKeysNodes()
        {
            objDataWork_DatabaseConfigurationModule.ColumnConstraints.Where(constr => constr.ID_ConstraintType == objLocalConfig.OItem_object_primary_key.GUID).ToList().ForEach
                (constr =>
                    {
                        var treeNodes = treeNode_DatabaseSchemas.Nodes.Find(constr.ID_Column, true);

                        if (treeNodes.Any())
                        {
                            treeNodes.First().ImageIndex = objLocalConfig.ImageID_PrimaryKey;
                            treeNodes.First().SelectedImageIndex = objLocalConfig.ImageID_PrimaryKey;
                        }
                    }
                );
        }

        private void AddTreeNode_SchemaRoutines()
        {
            objDataWork_DatabaseConfigurationModule.SchemaRoutines.ForEach
                (routine =>
                    {
                        var treeNodes = treeNode_DatabaseSchemas.Nodes.Find(routine.ID_Other, true);

                        if (treeNodes.Any())
                        {
                            treeNodes.First().Nodes[2].Nodes.Add(routine.ID_Object, routine.Name_Object, objLocalConfig.ImageID_Routine, objLocalConfig.ImageID_Routine);
                        }
                    }
                );
        }

        private void AddTreeNode_SchemaColumns()
        {
            objDataWork_DatabaseConfigurationModule.SchemaTableColumns.ForEach
                (col =>
                    {
                        var treeNodes = treeNode_DatabaseSchemas.Nodes.Find(col.ID_Other, true);

                        if (treeNodes.Any())
                        {
                            treeNodes.First().FirstNode.Nodes.Add(col.ID_Object, col.Name_Object, objLocalConfig.ImageID_Column, objLocalConfig.ImageID_Column);
                        }
                    }

                );
        }

        private void AddTreeNode_SchemaDatabase()
        {
            objDataWork_DatabaseConfigurationModule.SchemaDatabases.ForEach
                (db =>
                    {
                        var treeNodes = treeNode_DatabaseSchemas.Nodes.Find(db.ID_Other, false);
                        if (treeNodes.Any())
                        {
                            var treeNodesParent = treeNodes.First().Nodes.Find(objLocalConfig.OItem_class_database.GUID, false);
                            if (treeNodesParent.Any())
                            {
                                treeNodesParent.First().Nodes.Add(db.ID_Object, db.Name_Object, objLocalConfig.ImageID_Databas, objLocalConfig.ImageID_Databas);
                            }
                            
                        }
                    }
                );
        }

        private void AddTreeNode_SchemaTable()
        {
            objDataWork_DatabaseConfigurationModule.SchemaTables.ForEach
                (tab =>
                    {
                        var treeNodes = treeNode_DatabaseSchemas.Nodes.Find(tab.ID_Other, false);
                        if (treeNodes.Any())
                        {
                            var tableParents = treeNodes.First().Nodes.Find(objLocalConfig.OItem_class_db_tables.GUID, false);
                            if (tableParents.Any())
                            {
                                var treeNode = tableParents.First().Nodes.Add(tab.ID_Object, tab.Name_Object, objLocalConfig.ImageID_Table, objLocalConfig.ImageID_Table);
                                treeNode.Nodes.Add(objLocalConfig.OItem_class_db_columns.GUID, objLocalConfig.OItem_class_db_columns.Name, objLocalConfig.ImageID_Columns, objLocalConfig.ImageID_Columns);
                                treeNode.Nodes.Add(objLocalConfig.OItem_class_db_triggers.GUID, objLocalConfig.OItem_class_db_triggers.Name, objLocalConfig.ImageID_Triggers, objLocalConfig.ImageID_Triggers);
                            }
                        }
                    }

                );
        }

        private void AddTreeNode_Schema()
        {
            objDataWork_DatabaseConfigurationModule.Schemas.ForEach
                (sch =>
                    {
                        var treeNode = treeNode_DatabaseSchemas.Nodes.Add(sch.GUID, sch.Name, objLocalConfig.ImageID_DatabaseSchema, objLocalConfig.ImageID_DatabaseSchema);
                        treeNode.Nodes.Add(objLocalConfig.OItem_class_database.GUID, objLocalConfig.OItem_class_database.Name, objLocalConfig.ImageID_Databas, objLocalConfig.ImageID_Databas);
                        treeNode.Nodes.Add(objLocalConfig.OItem_class_db_tables.GUID, objLocalConfig.OItem_class_db_tables.Name, objLocalConfig.ImageID_Tables,objLocalConfig.ImageID_Tables);
                        treeNode.Nodes.Add(objLocalConfig.OItem_class_db_routines.GUID, objLocalConfig.OItem_class_db_routines.Name, objLocalConfig.ImageID_Routines, objLocalConfig.ImageID_Routines);
                    }

                );
        }

        void objDataWork_DatabaseConfigurationModule_loadedItems(clsDataWork_DatabaseConfiguratorModule.LoadResult loadItems, OntologyClasses.BaseClasses.clsOntologyItem OItem_Result)
        {
            if (loadItems == clsDataWork_DatabaseConfiguratorModule.LoadResult.DatabaseItems)
            {
                if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(addSchemaNode);
                        }
                        else
                        {
                            AddTreeNode_Schema();
                        }

                            
                 
                }
                else
                {
                    MessageBox.Show(this, "Die Schemas konnten nicht geladen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (loadItems == clsDataWork_DatabaseConfiguratorModule.LoadResult.Schema_Tables)
            {
                if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(addSchemaTableNode);
                    }
                    else
                    {
                        AddTreeNode_SchemaTable();
                    }

                }
                else
                {
                    MessageBox.Show(this, "Die Tabellen konnten nicht geladen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (loadItems == clsDataWork_DatabaseConfiguratorModule.LoadResult.Schema_Databases)
            {
                if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(addSchemaDatabaseNode);
                    }
                    else
                    {
                        AddTreeNode_SchemaDatabase();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Die Datenbanken konnten nicht geladen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (loadItems == clsDataWork_DatabaseConfiguratorModule.LoadResult.Schema_TableColumns)
            {
                if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(addSchemaTableColumnsNode);
                    }
                    else
                    {
                        AddTreeNode_SchemaColumns();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Die Columns konnten nicht geladen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (loadItems == clsDataWork_DatabaseConfiguratorModule.LoadResult.Schema_Routines)
            {
                if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(addSchemaRoutinesNode);
                    }
                    else
                    {
                        AddTreeNode_SchemaRoutines();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Die Routinen konnten nicht geladen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (loadItems == clsDataWork_DatabaseConfiguratorModule.LoadResult.Schema_Constraints)
            {
                if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(configurePrimaryKeys);
                    }
                    else
                    {
                        ConfigurePrimaryKeysNodes();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Die Constraints konnten nicht geladen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FillTree()
        {
            treeView_Configurator.Nodes.Clear();

            treeNode_Root = treeView_Configurator.Nodes.Add(objLocalConfig.OItem_object_database_configurator_module.GUID, objLocalConfig.OItem_object_database_configurator_module.Name, objLocalConfig.ImageID_Root, objLocalConfig.ImageID_Root);
            treeNode_DatabaseSchemas = treeNode_Root.Nodes.Add(objLocalConfig.OItem_class_database_schema.GUID, objLocalConfig.OItem_class_database_schema.Name, objLocalConfig.ImageID_DatabaseSchemas, objLocalConfig.ImageID_DatabaseSchemas);
            

        }

    }
}
