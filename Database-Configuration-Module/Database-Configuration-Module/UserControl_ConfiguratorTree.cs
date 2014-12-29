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

namespace DatabaseConfigurationModule
{
    public partial class UserControl_ConfiguratorTree : UserControl
    {

        private clsLocalConfig objLocalConfig;

        private clsDataWork_DatabaseConfiguratorModule objDataWork_DatabaseConfigurationModule;

        private TreeNode treeNode_Root;

        public delegate void SelectedNode(clsOntologyItem OItem_Selected);
        public event SelectedNode selectedNode;

        public delegate void AddSchemaNode();
        private AddSchemaNode addSchemaNode;
        public delegate void AddSchemaTableNode();
        private AddSchemaTableNode addSchemaTableNode;
        public delegate void AddSchemaViewNode();
        private AddSchemaViewNode addSchemaViewNode;
        public delegate void AddSchemaDatabaseNode();
        private AddSchemaDatabaseNode addSchemaDatabaseNode;
        public delegate void AddSchemaTableColumnsNode();
        private AddSchemaTableColumnsNode addSchemaTableColumnsNode;
        public delegate void AddSchemaRoutinesNode();
        private AddSchemaRoutinesNode addSchemaRoutinesNode;
        public delegate void ConfigurePrimaryKeys();
        private ConfigurePrimaryKeys configurePrimaryKeys;
        public delegate void AddDBOnServerNode();
        private AddDBOnServerNode addDBOnServerNode;
        public delegate void AddServerNode();
        private AddServerNode addServerNode;
        public delegate void AddServerDatabaseNode();
        private AddServerDatabaseNode addServerDatabaseNode;

        private frm_ObjectEdit objFrmObjectEdit;

        private bool boolSchemaAdded;

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

            addSchemaNode = new AddSchemaNode(FillProjectNodes);
            addSchemaTableNode = new AddSchemaTableNode(AddTreeNode_SchemaTable);
            addSchemaViewNode = new AddSchemaViewNode(AddTreeNode_SchemaView);
            addSchemaDatabaseNode = new AddSchemaDatabaseNode(AddTreeNode_SchemaDatabase);
            addSchemaTableColumnsNode = new AddSchemaTableColumnsNode(AddTreeNode_SchemaColumns);
            addSchemaRoutinesNode = new AddSchemaRoutinesNode(AddTreeNode_SchemaRoutines);
            configurePrimaryKeys = new ConfigurePrimaryKeys(ConfigurePrimaryKeysNodes);
            addDBOnServerNode = new AddDBOnServerNode(AddTreeNode_DBOnServer);
            addServerNode = new AddServerNode(AddTreeNode_Server);
            addServerDatabaseNode = new AddServerDatabaseNode(AddTreeNode_ServerDatabase);

            FillTree();


        }

        private void AddTreeNode_ServerDatabase()
        {
            var serverDatabases = objDataWork_DatabaseConfigurationModule.ServerDatabases;
            serverDatabases.ForEach(sdb =>
                {
                    var dbOnSeverNodes = treeView_Configurator.Nodes.Find(sdb.ID_Object, true);
                    if (dbOnSeverNodes.Any())
                    {
                        dbOnSeverNodes.First().Nodes.Add(sdb.ID_Other, sdb.Name_Other, objLocalConfig.ImageID_Database, objLocalConfig.ImageID_Database);
                    }
                });
            
        }

        private void AddTreeNode_Server()
        {
            var servers = objDataWork_DatabaseConfigurationModule.Servers;
            servers.ForEach(server =>
            {
                var dbOnSeverNodes = treeView_Configurator.Nodes.Find(server.ID_Object, true);
                if (dbOnSeverNodes.Any())
                {
                    dbOnSeverNodes.First().Nodes.Add(server.ID_Other, server.Name_Other, objLocalConfig.ImageID_Server, objLocalConfig.ImageID_Server);
                }
            });
        }

        private void AddTreeNode_DBOnServer()
        {
            var databaseOnServer = objDataWork_DatabaseConfigurationModule.DatabaseOnServer;
            databaseOnServer.ForEach(dbOnServer =>
            {
                var projectNodes = treeView_Configurator.Nodes.Find(dbOnServer.ID_Object, true);
                if (projectNodes.Any())
                {
                    var dbOnServersNode = projectNodes.First().Nodes.Find(objLocalConfig.OItem_class_database_on_server.GUID, false);

                    TreeNode parentNode;
                    if (dbOnServersNode.Count() == 0)
                    {
                        parentNode = projectNodes.First().Nodes.Add(objLocalConfig.OItem_class_database_on_server.GUID, objLocalConfig.OItem_class_database_on_server.Name, objLocalConfig.ImageID_DatabaseConnections, objLocalConfig.ImageID_DatabaseConnections);

                    }
                    else
                    {
                        parentNode = dbOnServersNode.First();
                    }
                    parentNode.Nodes.Add(dbOnServer.ID_Other, dbOnServer.Name_Other, objLocalConfig.ImageID_DatabaseConnection, objLocalConfig.ImageID_DatabaseConnection);
                }
            });
        }

        private void AddTreeNode_SchemaView()
        {
            while (!boolSchemaAdded) ;
            var treeNodeList = new List<TreeNode>();
            TreeNode treeNode_SchemaViews = null;
            objDataWork_DatabaseConfigurationModule.SchemaViews.OrderBy(View => View.ID_Other).ThenBy(view => view.Name_Object).ToList().ForEach(view =>
                {
                    if (treeNode_SchemaViews == null || view.ID_Other != treeNode_SchemaViews.Name)
                    {
                        var treeNodes = treeView_Configurator.Nodes.Find(view.ID_Other, true);
                        foreach (TreeNode treeNode in treeNodes)
                        {
                            var treeNodeViews = treeNode.Nodes.Find(objLocalConfig.OItem_class_db_views.GUID, false);
                            if (treeNodeViews.Count() == 0)
                            {
                                treeNode_SchemaViews = treeNode.Nodes.Add(objLocalConfig.OItem_class_db_views.GUID, objLocalConfig.OItem_class_db_views.Name, objLocalConfig.ImageID_Views, objLocalConfig.ImageID_Views);
                            }
                            else
                            {
                                treeNode_SchemaViews = treeNodeViews[0];
                            }
                            if (!treeNodeList.Any(par => par == treeNode_SchemaViews))
                            {
                                treeNodeList.Add(treeNode_SchemaViews);
                            }
                            
                            treeNode_SchemaViews.Nodes.Add(view.ID_Object, view.Name_Object, objLocalConfig.ImageID_View, objLocalConfig.ImageID_View);
                        }
                    }
                    else
                    {
                        treeNode_SchemaViews.Nodes.Add(view.ID_Object, view.Name_Object, objLocalConfig.ImageID_View, objLocalConfig.ImageID_View);
                    }
                });

            treeNodeList.ForEach(views =>
                {
                    views.Text += " (" + views.Nodes.Count.ToString() + ")";
                });
        }

        private void ConfigurePrimaryKeysNodes()
        {
            objDataWork_DatabaseConfigurationModule.ColumnConstraints.Where(constr => constr.ID_ConstraintType == objLocalConfig.OItem_object_primary_key.GUID).ToList().ForEach
                (constr =>
                    {
                        var treeNodes = treeView_Configurator.Nodes.Find(constr.ID_Column, true);

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
            var treeNodeList_Parent = new List<TreeNode>();

            (from routine in objDataWork_DatabaseConfigurationModule.SchemaRoutines
                 join type in objDataWork_DatabaseConfigurationModule.RoutinesToType on routine.ID_Object equals type.ID_Object into types
                 from type in types.DefaultIfEmpty()
                 select new {routine, type}).ToList().OrderBy(routine => routine.type != null ? routine.type.Name_Other : routine.routine.Name_Object).ThenBy(routine => routine.routine.Name_Object).ToList().ForEach
                (routine =>
                    {
                        var treeNodes = treeView_Configurator.Nodes.Find(routine.routine.ID_Other, true);

                        if (treeNodes.Any())
                        {
                            var treeNodesParent = treeNodes.First().Nodes.Find(objLocalConfig.OItem_class_db_routines.GUID, false);
                            if (treeNodesParent.Any())
                            {
                                if (!treeNodeList_Parent.Any(par => par == treeNodesParent[0]))
                                {
                                    treeNodeList_Parent.Add(treeNodesParent.First());
                                }
                                
                                treeNodesParent.First().Nodes.Add(routine.routine.ID_Object, routine.routine.Name_Object + (routine.type != null ? " (" + routine.type.Name_Other + ")" : ""), objLocalConfig.ImageID_Routine, objLocalConfig.ImageID_Routine);
                            }
                        }
                    }
                );

            treeNodeList_Parent.ForEach(parent =>
                {
                    parent.Text += " (" + parent.Nodes.Count.ToString() + ")";
                });


        }

        private void AddTreeNode_SchemaColumns()
        {
            objDataWork_DatabaseConfigurationModule.SchemaTableColumns.ForEach
                (col =>
                    {
                        var treeNodes = treeView_Configurator.Nodes.Find(col.ID_Other, true);

                        if (treeNodes.Any())
                        {
                            var fieldType = objDataWork_DatabaseConfigurationModule.GetColumnFieldType(col.ID_Object);
                            var colAtts = objDataWork_DatabaseConfigurationModule.GetColumnAtt(col.ID_Object);
                            var colAtts_Dimensions = colAtts.Where(dim => dim.ID_AttributeType == objLocalConfig.OItem_attributetype_dimensions.GUID).ToList();
                            var colAtt_Nullable = colAtts.Where(nul => nul.ID_AttributeType == objLocalConfig.OItem_attributetype_nullable.GUID).ToList().FirstOrDefault();
                            var colAtt_Unicode = colAtts.Where(nul => nul.ID_AttributeType == objLocalConfig.OItem_attributetype_unicode.GUID).ToList().FirstOrDefault();
                            var colAtt_Variable = colAtts.Where(nul => nul.ID_AttributeType == objLocalConfig.OItem_attributetype_variable.GUID).ToList().FirstOrDefault();
                            
                            var treeNode = treeNodes.First().FirstNode.Nodes.Add(col.ID_Object, col.Name_Object, objLocalConfig.ImageID_Column, objLocalConfig.ImageID_Column);
                            if (fieldType != null)
                            {
                                treeNode.Text += " [" + fieldType.Name ;

                                treeNode.Text += colAtt_Unicode != null ? " / Unicode" : "";

                                treeNode.Text += colAtt_Variable != null ? " / Variable" : "";

                                treeNode.Text += "]";
                            }

                            var dimension = "";
                            if (colAtts_Dimensions.Any())
                            {
                                

                                colAtts_Dimensions.ForEach(dim =>
                                    {
                                        if (!string.IsNullOrEmpty(dimension))
                                        {
                                            dimension += ", ";
                                        }

                                        dimension += dim.Val_Lng.ToString();
                                    });

                                dimension = " (" + dimension + ")";
                            }

                            treeNode.Text += dimension;

                            treeNode.Text += " (" + (colAtt_Nullable != null ? colAtt_Nullable.Val_Bit != null ? ((bool)colAtt_Nullable.Val_Bit ? "Nullable" : "Not Nullable") : "Not Nullable" : "Not Nullable") + ")";

                            

                        }

                        
                    }

                );
        }

        private void AddTreeNode_SchemaDatabase()
        {
            var treeNodeList_Database = new List<TreeNode>();
            objDataWork_DatabaseConfigurationModule.SchemaDatabases.ForEach
                (db =>
                    {
                        var treeNodes = treeNode_Root.Nodes.Find(db.ID_Other, true);
                        if (treeNodes.Any())
                        {
                            var treeNodesParent = treeNodes.First().Nodes.Find(objLocalConfig.OItem_class_database.GUID, false);
                            if (treeNodesParent.Any())
                            {
                                if (!treeNodeList_Database.Any(dbold => dbold == treeNodesParent[0]))
                                {
                                    treeNodeList_Database.Add(treeNodesParent[0]);
                                }
                                
                                treeNodesParent.First().Nodes.Add(db.ID_Object, db.Name_Object, objLocalConfig.ImageID_Database, objLocalConfig.ImageID_Database);
                            }
                            
                        }
                    }
                );


            treeNodeList_Database.ForEach(treen =>
                {
                    treen.Text += " (" + treen.Nodes.Count.ToString() + ")";
                });
            
            
        }

        private void AddTreeNode_SchemaTable()
        {
            while (!boolSchemaAdded) ;
            var treeNodeList_Parent = new List<TreeNode>();

            objDataWork_DatabaseConfigurationModule.SchemaTables.ForEach
                (tab =>
                    {
                        var treeNodes = treeNode_Root.Nodes.Find(tab.ID_Other, true);
                        if (treeNodes.Any())
                        {
                            var tableParents = treeNodes.First().Nodes.Find(objLocalConfig.OItem_class_db_tables.GUID, false);
                            if (tableParents.Any())
                            {
                                if (!treeNodeList_Parent.Any(par => par == tableParents.First()))
                                {
                                    treeNodeList_Parent.Add(tableParents.First());
                                }
                                
                                var treeNode = tableParents.First().Nodes.Add(tab.ID_Object, tab.Name_Object, objLocalConfig.ImageID_Table, objLocalConfig.ImageID_Table);
                                treeNode.Nodes.Add(objLocalConfig.OItem_class_db_columns.GUID, objLocalConfig.OItem_class_db_columns.Name, objLocalConfig.ImageID_Columns, objLocalConfig.ImageID_Columns);
                                treeNode.Nodes.Add(objLocalConfig.OItem_class_db_triggers.GUID, objLocalConfig.OItem_class_db_triggers.Name, objLocalConfig.ImageID_Triggers, objLocalConfig.ImageID_Triggers);
                            }
                        }
                    }

                );

            treeNodeList_Parent.ForEach(parent =>
                {
                    parent.Text += " (" + parent.Nodes.Count.ToString() + ")";
                });
        }

        private void AddTreeNode_Schema(TreeNode treeNodeProj)
        {
            (from proj in objDataWork_DatabaseConfigurationModule.ProjectsToSchema.Where(proj => proj.ID_Object == treeNodeProj.Name).ToList()
             join schema in objDataWork_DatabaseConfigurationModule.Schemas on proj.ID_Other equals schema.GUID
             select schema).ToList().ForEach(schema =>
                 {
                     var treeNode = treeNodeProj.Nodes.Add(schema.GUID, schema.Name, objLocalConfig.ImageID_DatabaseSchema, objLocalConfig.ImageID_DatabaseSchema);
                     treeNode.Nodes.Add(objLocalConfig.OItem_class_database.GUID, objLocalConfig.OItem_class_database.Name, objLocalConfig.ImageID_Database, objLocalConfig.ImageID_Database);
                     treeNode.Nodes.Add(objLocalConfig.OItem_class_db_tables.GUID, objLocalConfig.OItem_class_db_tables.Name, objLocalConfig.ImageID_Tables, objLocalConfig.ImageID_Tables);
                     treeNode.Nodes.Add(objLocalConfig.OItem_class_db_views.GUID, objLocalConfig.OItem_class_db_views.Name, objLocalConfig.ImageID_Views, objLocalConfig.ImageID_Views);
                     treeNode.Nodes.Add(objLocalConfig.OItem_class_db_routines.GUID, objLocalConfig.OItem_class_db_routines.Name, objLocalConfig.ImageID_Routines, objLocalConfig.ImageID_Routines);
                     
                 });
            
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
                            FillProjectNodes();
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
            if (loadItems == clsDataWork_DatabaseConfiguratorModule.LoadResult.Schema_Views)
            {
                if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(addSchemaViewNode);
                    }
                    else
                    {
                        AddTreeNode_SchemaView();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Die Views konnten nicht geladen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (loadItems == clsDataWork_DatabaseConfiguratorModule.LoadResult.DatabaseOnServer)
            {
                if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(addDBOnServerNode);
                    }
                    else
                    {
                        AddTreeNode_DBOnServer();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Die Datenbank-Verbindungen konnten nicht geladen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (loadItems == clsDataWork_DatabaseConfiguratorModule.LoadResult.Server)
            {
                if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(addServerNode);
                    }
                    else
                    {
                        AddTreeNode_Server();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Die Server konnten nicht geladen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (loadItems == clsDataWork_DatabaseConfiguratorModule.LoadResult.ServerDatabases)
            {
                if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(addServerDatabaseNode);
                    }
                    else
                    {
                        AddTreeNode_ServerDatabase();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Die Server-Datenbanken konnten nicht geladen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FillTree()
        {
            treeView_Configurator.Nodes.Clear();

            treeNode_Root = treeView_Configurator.Nodes.Add(objLocalConfig.OItem_object_database_configurator_module.GUID, objLocalConfig.OItem_object_database_configurator_module.Name, objLocalConfig.ImageID_Root, objLocalConfig.ImageID_Root);
            
            
        }

        private void FillProjectNodes()
        {
            boolSchemaAdded = false;
            var treeNodes = objDataWork_DatabaseConfigurationModule.CreateProjectSubNodes();
            
            treeNode_Root.Nodes.AddRange(treeNodes.ToArray());

            treeNodes.ForEach(treeNode =>
                {
                    AddTreeNode_Schema(treeNode);              
                });
            boolSchemaAdded = true;
        }

        private void treeView_Configurator_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var objOList_Objects = new List<clsOntologyItem>();
            if (e.Node.ImageIndex == objLocalConfig.ImageID_Column 
                || e.Node.ImageIndex == objLocalConfig.ImageID_ForeignKey
                || e.Node.ImageIndex == objLocalConfig.ImageID_PrimaryKey)
            {
                int rowID = 0;
                for (var i = 0; i < e.Node.Parent.Nodes.Count; i++)
                {
                    objOList_Objects.Add(new clsOntologyItem { GUID = e.Node.Parent.Nodes[i].Name, Name = e.Node.Parent.Nodes[i].Text, GUID_Parent = objLocalConfig.OItem_class_db_columns.GUID });
                    if (e.Node.Name == e.Node.Parent.Nodes[i].Name)
                    {
                        rowID = i;
                    }
                }
                
                objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals, objOList_Objects, rowID, objLocalConfig.Globals.Type_Object, null);
                objFrmObjectEdit.ShowDialog(this);
            }
            else if (e.Node.ImageIndex == objLocalConfig.ImageID_Database)
            {
                int rowID = 0;
                for (var i = 0; i < e.Node.Parent.Nodes.Count; i++)
                {
                    objOList_Objects.Add(new clsOntologyItem { GUID = e.Node.Parent.Nodes[i].Name, Name = e.Node.Parent.Nodes[i].Text, GUID_Parent = objLocalConfig.OItem_class_database.GUID });
                    if (e.Node.Name == e.Node.Parent.Nodes[i].Name)
                    {
                        rowID = i;
                    }
                }
                
                objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals, objOList_Objects, rowID, objLocalConfig.Globals.Type_Object, null);
                objFrmObjectEdit.ShowDialog(this);
            }
            else if (e.Node.ImageIndex == objLocalConfig.ImageID_DatabaseProject)
            {
                int rowID = 0;
                for (var i = 0; i < e.Node.Parent.Nodes.Count; i++)
                {
                    objOList_Objects.Add(new clsOntologyItem { GUID = e.Node.Parent.Nodes[i].Name, Name = e.Node.Parent.Nodes[i].Text, GUID_Parent = objLocalConfig.OItem_class_database_project.GUID });
                    if (e.Node.Name == e.Node.Parent.Nodes[i].Name)
                    {
                        rowID = i;
                    }
                }
                
                objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals, objOList_Objects, rowID, objLocalConfig.Globals.Type_Object, null);
                objFrmObjectEdit.ShowDialog(this);
            }
            else if (e.Node.ImageIndex == objLocalConfig.ImageID_DatabaseSchema)
            {
                int rowID = 0;
                for (var i = 0; i < e.Node.Parent.Nodes.Count; i++)
                {
                    objOList_Objects.Add(new clsOntologyItem { GUID = e.Node.Parent.Nodes[i].Name, Name = e.Node.Parent.Nodes[i].Text, GUID_Parent = objLocalConfig.OItem_class_database_schema.GUID });
                    if (e.Node.Name == e.Node.Parent.Nodes[i].Name)
                    {
                        rowID = i;
                    }
                }
                
                objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals, objOList_Objects, rowID, objLocalConfig.Globals.Type_Object, null);
                objFrmObjectEdit.ShowDialog(this);
            }
            else if (e.Node.ImageIndex == objLocalConfig.ImageID_Routine)
            {
                int rowID = 0;
                for (var i = 0; i < e.Node.Parent.Nodes.Count; i++)
                {
                    objOList_Objects.Add(new clsOntologyItem { GUID = e.Node.Parent.Nodes[i].Name, Name = e.Node.Parent.Nodes[i].Text, GUID_Parent = objLocalConfig.OItem_class_db_routines.GUID });
                    if (e.Node.Name == e.Node.Parent.Nodes[i].Name)
                    {
                        rowID = i;
                    }
                }
                objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals, objOList_Objects, rowID, objLocalConfig.Globals.Type_Object, null);
                objFrmObjectEdit.ShowDialog(this);
            }
            else if (e.Node.ImageIndex == objLocalConfig.ImageID_Table)
            {
                int rowID = 0;
                for (var i = 0; i < e.Node.Parent.Nodes.Count; i++)
                {
                    objOList_Objects.Add(new clsOntologyItem { GUID = e.Node.Parent.Nodes[i].Name, Name = e.Node.Parent.Nodes[i].Text, GUID_Parent = objLocalConfig.OItem_class_db_tables.GUID });
                    if (e.Node.Name == e.Node.Parent.Nodes[i].Name)
                    {
                        rowID = i;
                    }
                }
                
                objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals, objOList_Objects, rowID, objLocalConfig.Globals.Type_Object, null);
                objFrmObjectEdit.ShowDialog(this);
            }
            else if (e.Node.ImageIndex == objLocalConfig.ImageID_Trigger)
            {
                int rowID = 0;
                for (var i = 0; i < e.Node.Parent.Nodes.Count; i++)
                {
                    objOList_Objects.Add(new clsOntologyItem { GUID = e.Node.Parent.Nodes[i].Name, Name = e.Node.Parent.Nodes[i].Text, GUID_Parent = objLocalConfig.OItem_class_db_triggers.GUID });
                    if (e.Node.Name == e.Node.Parent.Nodes[i].Name)
                    {
                        rowID = i;
                    }
                }
                
                objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals, objOList_Objects, rowID, objLocalConfig.Globals.Type_Object, null);
                objFrmObjectEdit.ShowDialog(this);
            }
            else if (e.Node.ImageIndex == objLocalConfig.ImageID_View)
            {
                int rowID = 0;
                for (var i = 0; i < e.Node.Parent.Nodes.Count; i++)
                {
                    objOList_Objects.Add(new clsOntologyItem { GUID = e.Node.Parent.Nodes[i].Name, Name = e.Node.Parent.Nodes[i].Text, GUID_Parent = objLocalConfig.OItem_class_db_views.GUID });
                    if (e.Node.Name == e.Node.Parent.Nodes[i].Name)
                    {
                        rowID = i;
                    }
                }

                objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals, objOList_Objects, rowID, objLocalConfig.Globals.Type_Object, null);
                objFrmObjectEdit.ShowDialog(this);
            }
        }

        private void contextMenuStrip_Nodes_Opening(object sender, CancelEventArgs e)
        {
            var selectedNode = treeView_Configurator.SelectedNode;

            resolveDependenciesToolStripMenuItem.Enabled = false;

            if (selectedNode != null)
            {
                if (selectedNode.ImageIndex == objLocalConfig.ImageID_Views)
                {
                    resolveDependenciesToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void resolveDependenciesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void treeView_Configurator_AfterSelect(object sender, TreeViewEventArgs e)
        {
            clsOntologyItem objOItem_Selected = null;
            if (e.Node != null && selectedNode != null)
            {
                var imageToClasses = objLocalConfig.OList_ImageToClass.Where(item => item.ImageID == e.Node.ImageIndex).ToList();

                if (imageToClasses.Any())
                {
                    objOItem_Selected = new clsOntologyItem
                    {
                        GUID = e.Node.Name,
                        Name = e.Node.Text,
                        GUID_Parent = imageToClasses.First().GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };
                }
                
                selectedNode(objOItem_Selected);
                
            }
            
        }

    }
}
