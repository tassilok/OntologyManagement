using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Threading;
using System.Windows.Forms;

namespace DatabaseConfigurationModule
{
    public class clsDataWork_DatabaseConfiguratorModule
    {
        public enum LoadSubResult
        {
            DatabaseItems = 0,
            SchemaTables = 1,
            SchemaDatabases = 2,
            SchemaTableColumns = 4,
            SchemaRoutines = 8,
            SchemaConstraints = 16,
            DatabaseProjects = 32,
            SchemaViews = 64,
            RefToProject = 128,
            DatabaseOnServer = 256,
            Server = 512,
            ServerDatabases = 1024
        }
        public enum LoadResult
        {
            DatabaseItems = 0,
            Schema_Tables = 1,
            Schema_Views = 2,
            Schema_Routines = 4,
            Schema_Trigger = 8,
            Schema_Databases = 16,
            Schema_TableColumns = 32,
            Schema_Constraints = 64,
            DatabaseProjects = 128,
            RefToProject = 256,
            DatabaseOnServer = 512,
            Server = 1024,
            ServerDatabases = 2048
        }

        private Thread threadDatabaseItems;

        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_ProjectToSecItems;
        private clsDBLevel objDBLevel_RefToProjects;
        private clsDBLevel objDBLevel_DatabaseProjects;
        private clsDBLevel objDBLevel_DbProjHierarchy;
        private clsDBLevel objDBLevel_DbProjToSchema;
        private clsDBLevel objDBLevel_DatabaseItems;
        private clsDBLevel objDBLevel_Tables;
        private clsDBLevel objDBLevel_Views;
        private clsDBLevel objDBLevel_Columns;
        private clsDBLevel objDBLevel_Databases;
        private clsDBLevel objDBLevel_Routines;
        private clsDBLevel objDBLevel_RoutineType;
        private clsDBLevel objDBLevel_RoutineToType;
        private clsDBLevel objDBLevel_Constraints;
        private clsDBLevel objDBLevel_ConstraintTypes;
        private clsDBLevel objDBlevel_ColumnAtts;
        private clsDBLevel objDBLevel_ColumnsToFieldTypes;
        private clsDBLevel objDBLevel_FieldTypes;
        private clsDBLevel objDBLevel_DatabaseOnServer;
        private clsDBLevel objDBLevel_Server;
        private clsDBLevel objDBLevel_ServerDatabases;

        private clsDBLevel objDBLevel_CodeSnipplets;

        private List<clsOntologyItem> OList_FilterProjects;

        private delegate void LoadedSubItems(LoadSubResult loadResult, clsOntologyItem OItem_Result);
        private event LoadedSubItems loadedSubItems;

        public delegate void LoadItems(LoadResult loadResult, clsOntologyItem OItem_Result);
        public event LoadItems loadItems;

        public List<clsOntologyItem> SchemaProjects
        {
            get
            {
                return (from objProjRel in objDBLevel_DatabaseProjects.OList_Objects
                        join objProjFilter in OList_FilterProjects on objProjRel.GUID equals objProjFilter.GUID
                        select objProjRel).ToList();
                
                
            }
        }

        public List<clsObjectRel> ProjectsToSchema
        {
            get
            {
                var projRel = (from objProjRel in objDBLevel_DbProjToSchema.OList_ObjectRel
                               join objProjFilter in OList_FilterProjects on objProjRel.ID_Object equals objProjFilter.GUID
                               select objProjRel).ToList();
                return projRel;
                
            }
        }

        public List<clsObjectRel> SchemaRoutines
        {
            get
            {
                return objDBLevel_Routines.OList_ObjectRel.OrderBy(col => col.Name_Object).ToList();
            }
        }

        public List<clsOntologyItem> RoutineTypes
        {
            get
            {
                return objDBLevel_RoutineToType.OList_Objects;
            }
        }

        public List<clsObjectRel> RoutinesToType
        {
            get
            {
                return objDBLevel_RoutineToType.OList_ObjectRel;
            }
        }

        public List<clsObjectRel> SchemaTableColumns
        {
            get
            {
                return objDBLevel_Columns.OList_ObjectRel.OrderBy(col => col.OrderID).ToList();
            }
        }

        public List<clsObjectRel> SchemaTables
        {
            get
            {

                return objDBLevel_Tables.OList_ObjectRel.OrderBy(tab => tab.Name_Object).ToList();
            }
        }

        public List<clsObjectRel> SchemaViews
        {
            get
            {
                return objDBLevel_Views.OList_ObjectRel;
            }
        }

        public List<clsOntologyItem> Schemas
        {
            get
            {
                return objDBLevel_DatabaseItems.OList_Objects.Where(dbi => dbi.GUID_Parent == objLocalConfig.OItem_class_database_schema.GUID).OrderBy(sch => sch.Name).ToList();
            }
        }

        public List<clsObjectRel> SchemaDatabases
        {
            get
            {
                return objDBLevel_Databases.OList_ObjectRel;
            }
        }

        public List<clsObjectRel> DatabaseOnServer
        {
            get
            {
                return objDBLevel_DatabaseOnServer.OList_ObjectRel;
            }
        }

        public List<clsObjectRel> Servers
        {
            get
            {
                return objDBLevel_Server.OList_ObjectRel;
            }
        }

        public List<clsObjectRel> ServerDatabases
        {
            get
            {
                return objDBLevel_ServerDatabases.OList_ObjectRel;
            }
        }

        public List<clsConstraint> ColumnConstraints { get; private set; }

        public clsOntologyItem GetData()
        {
            var result = objLocalConfig.Globals.LState_Success.Clone();
            loadedSubItems += clsDataWork_DatabaseConfiguratorModule_loadedSubItems;
            threadDatabaseItems = new Thread(GetDataThread);
            threadDatabaseItems.Start();

            return result;
        }

        private void GetDataThread()
        {
            GetSubData_000_RefRelToProjects();
            GetSubData_001_DatabaseProjects();
            GetSubData_002_DatabaseItems();
            GetSubData_003_SchemaTables();
            GetSubData_004_SchemaDatabases();
            GetSubData_005_TableColumns();
            GetSubData_006_Routines();
            GetSubData_007_Constraints();
            GetSubData_008_SchemaViews();
            GetSubData_009_DatabaseOnServer();
            GetSubData_010_Server();
            GetSubData_011_ServerDatabases();
        }

        public clsOntologyItem GetCodeSnippletOfDBItem(clsOntologyItem OItem_DBItem)
        {

            var searchCodeSnipplet = new List<clsObjectRel> { new clsObjectRel { ID_Object = OItem_DBItem.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_creation_template.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_code_snipplets.GUID }};

            var result = objDBLevel_CodeSnipplets.get_Data_ObjectRel(searchCodeSnipplet, boolIDs: false).Clone();

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_CodeSnipplets.OList_ObjectRel.Any())
                {
                    result.add_OItem(objDBLevel_CodeSnipplets.OList_ObjectRel.Select(rel => new clsOntologyItem {GUID = rel.ID_Other,
                        Name = rel.Name_Other,
                        GUID_Parent = rel.ID_Parent_Other,
                        Type = rel.Ontology }).ToList().First());
                }
            }
            
            return result;
        }

        public clsOntologyItem GetColumnFieldType(string GUID_Col)
        {
            return objDBLevel_ColumnsToFieldTypes.OList_ObjectRel.Where(fieldType => fieldType.ID_Object == GUID_Col).Select(fieldType => new clsOntologyItem {GUID = fieldType.ID_Other, 
                Name = fieldType.Name_Other,
                GUID_Parent = fieldType.ID_Parent_Other,
                Type = fieldType.Ontology }).FirstOrDefault();
        }

        public List<clsObjectAtt> GetColumnAtt(string GUID_Col)
        {
            return objDBlevel_ColumnAtts.OList_ObjectAtt.Where(att => att.ID_Object == GUID_Col).OrderBy(att => att.OrderID).ToList();
        }

        void clsDataWork_DatabaseConfiguratorModule_loadedSubItems(clsDataWork_DatabaseConfiguratorModule.LoadSubResult loadResult, clsOntologyItem OItem_Result)
        {
            if (loadResult == LoadSubResult.DatabaseItems)
            {

                loadItems(LoadResult.DatabaseItems, OItem_Result);
                
            }

            if (loadResult == LoadSubResult.SchemaTables)
            {
                loadItems(LoadResult.Schema_Tables, OItem_Result);
            }

            if (loadResult == LoadSubResult.SchemaDatabases)
            {
                loadItems(LoadResult.Schema_Databases, OItem_Result);
            }

            if (loadResult == LoadSubResult.SchemaTableColumns)
            {
                loadItems(LoadResult.Schema_TableColumns, OItem_Result);
            }

            if (loadResult == LoadSubResult.SchemaRoutines)
            {
                loadItems(LoadResult.Schema_Routines, OItem_Result);
            }

            if (loadResult == LoadSubResult.SchemaConstraints)
            {
                loadItems(LoadResult.Schema_Constraints, OItem_Result);
            }

            if (loadResult == LoadSubResult.DatabaseProjects)
            {
                loadItems(LoadResult.DatabaseProjects, OItem_Result);
            }

            if (loadResult == LoadSubResult.SchemaViews)
            {
                loadItems(LoadResult.Schema_Views, OItem_Result);
            }

            if (loadResult == LoadSubResult.RefToProject)
            {
                loadItems(LoadResult.RefToProject, OItem_Result);
            }

            if (loadResult == LoadSubResult.DatabaseOnServer)
            {
                loadItems(LoadResult.DatabaseOnServer, OItem_Result);
            }

            if (loadResult == LoadSubResult.Server)
            {
                loadItems(LoadResult.Server, OItem_Result);
            }

            if (loadResult == LoadSubResult.ServerDatabases)
            {
                loadItems(LoadResult.ServerDatabases, OItem_Result);
            }
            
        }

        public List<TreeNode> CreateProjectSubNodes(TreeNode treeNode_Parent = null)
        {
            var treeNodes = new List<TreeNode>();
            if (treeNode_Parent == null)
            {
                var rootProjects = (from objProjParent in objDBLevel_DatabaseProjects.OList_Objects
                                    join objProjFilter in OList_FilterProjects on objProjParent.GUID equals objProjFilter.GUID
                                    join objProjParentNull in objDBLevel_DbProjHierarchy.OList_ObjectRel on objProjParent.GUID equals objProjParentNull.ID_Other into projParNulls
                                    from objProjParentNull in projParNulls.DefaultIfEmpty()
                                    where objProjParentNull == null
                                    select objProjParent).ToList();

                rootProjects.OrderBy(proj => proj.Name).ToList().ForEach(root =>
                {

                    treeNodes.Add(new TreeNode { Name = root.GUID, Text = root.Name, ImageIndex = objLocalConfig.ImageID_DatabaseProject, SelectedImageIndex = objLocalConfig.ImageID_DatabaseProject });

                });
            }
            else
            {
                var subNodes = objDBLevel_DatabaseProjects.OList_ObjectRel.Where(nodes => nodes.ID_Object == treeNode_Parent.Name).ToList();

                subNodes.OrderBy(proj => proj.Name_Other).ToList().ForEach(node =>
                {

                    treeNodes.Add( treeNode_Parent.Nodes.Add(node.ID_Other, node.Name_Other, objLocalConfig.ImageID_DatabaseProject, objLocalConfig.ImageID_DatabaseProject));
                });
            }
            


            return treeNodes;
        }

        public void GetSubData_000_RefRelToProjects()
        {
            var searchProjToRef_LeftRight = new List<clsObjectRel>();
            var searchProjToRef_RightLeft = new List<clsObjectRel>();
            var searchProjToSec = new List<clsObjectRel>();

            var result = objLocalConfig.Globals.LState_Success.Clone();

            if (objLocalConfig.OList_SessionItems != null)
            {
                searchProjToRef_LeftRight = objLocalConfig.OList_SessionItems.Select(si => new clsObjectRel
                {
                    ID_Object = si.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_database_project.GUID
                }).ToList();

                searchProjToRef_RightLeft = objLocalConfig.OList_SessionItems.Select(si => new clsObjectRel
                {
                    ID_Other = si.GUID,
                    ID_Parent_Object = objLocalConfig.OItem_class_database_project.GUID
                }).ToList();
              
            }
            else if (objLocalConfig.OItem_Ref != null)
            {
                searchProjToRef_LeftRight = new List<clsObjectRel> { new clsObjectRel { ID_Object = objLocalConfig.OItem_Ref.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_database_project.GUID}};

                searchProjToRef_RightLeft = new List<clsObjectRel> { new clsObjectRel { ID_Object = objLocalConfig.OItem_Ref.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_database_project.GUID}};

            }

            searchProjToSec = new List<clsObjectRel> 
            { 
                new clsObjectRel
                {
                    ID_Parent_Object = objLocalConfig.OItem_class_database_project.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Other = objLocalConfig.OItem_Group.GUID
                },
                new clsObjectRel
                {
                    ID_Parent_Object = objLocalConfig.OItem_class_database_project.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Other = objLocalConfig.OItem_User.GUID
                }
            };

            result = objDBLevel_RefToProjects.get_Data_ObjectRel(searchProjToSec, boolIDs: false);

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_FilterProjects = objDBLevel_RefToProjects.OList_ObjectRel.GroupBy(proj => new { GUID = proj.ID_Object, Name = proj.Name_Object, GUID_Parent = proj.ID_Parent_Object })
                    .Select(proj => new clsOntologyItem { GUID = proj.Key.GUID, Name = proj.Key.Name, GUID_Parent = proj.Key.GUID_Parent }).ToList();

            }

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID && (objLocalConfig.OList_SessionItems != null || objLocalConfig.OItem_Ref != null))
            {
                var oList_Filter = new List<clsOntologyItem>();
                result = objDBLevel_RefToProjects.get_Data_ObjectRel(searchProjToRef_LeftRight, boolIDs: false);
                if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    oList_Filter = objDBLevel_RefToProjects.OList_ObjectRel.GroupBy(proj => new { GUID = proj.ID_Other, Name = proj.Name_Other, GUID_Parent = proj.ID_Parent_Other })
                        .Select(proj => new clsOntologyItem { GUID = proj.Key.GUID, Name = proj.Key.Name, GUID_Parent = proj.Key.GUID_Parent }).ToList();

                    result = objDBLevel_RefToProjects.get_Data_ObjectRel(searchProjToRef_RightLeft, boolIDs: false);
                    if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        oList_Filter.AddRange(objDBLevel_RefToProjects.OList_ObjectRel.GroupBy(proj => new { GUID = proj.ID_Object, Name = proj.Name_Object, GUID_Parent = proj.ID_Parent_Object })
                           .Select(proj => new clsOntologyItem { GUID = proj.Key.GUID, Name = proj.Key.Name, GUID_Parent = proj.Key.GUID_Parent }));

                        OList_FilterProjects = (from proj1 in OList_FilterProjects
                                                join proj2 in oList_Filter on proj1.GUID equals proj2.GUID
                                                select proj1).ToList();
                    }
                }
            }
            

            loadedSubItems(LoadSubResult.RefToProject, result);
        }

        public void GetSubData_001_DatabaseProjects()
        {
            var searchProjects = new List<clsOntologyItem>
            {
                new clsOntologyItem
                {
                    GUID_Parent = objLocalConfig.OItem_class_database_project.GUID
                }
            };

            var result = objDBLevel_DatabaseProjects.get_Data_Objects(searchProjects);

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var searchDatabaseProjects = new List<clsObjectRel>
                {
                    new clsObjectRel 
                    { 
                        ID_Parent_Object = objLocalConfig.OItem_class_database_project.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_database_project.GUID
                    }
                };

                result = objDBLevel_DbProjHierarchy.get_Data_ObjectRel(searchDatabaseProjects, boolIDs: false);

                if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (objDBLevel_DatabaseProjects.OList_Objects.Any())
                    {
                        var searchDbProjToSchema = objDBLevel_DatabaseProjects.OList_Objects.Select(dbproj => new clsObjectRel
                        {
                            ID_Object = dbproj.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_database_schema.GUID
                        }).ToList();

                        result = objDBLevel_DbProjToSchema.get_Data_ObjectRel(searchDbProjToSchema, boolIDs: false);

                    }

                }
            }

            

            loadedSubItems(LoadSubResult.DatabaseProjects, result);
        }
        public void GetSubData_002_DatabaseItems()
        {
            var searchDatabaseItems = new List<clsOntologyItem> 
            { 
                new clsOntologyItem
                {
                    GUID_Parent = objLocalConfig.OItem_class_db_tables.GUID
                },
                new clsOntologyItem
                {
                    GUID_Parent = objLocalConfig.OItem_class_db_views.GUID
                },
                new clsOntologyItem
                {
                    GUID_Parent = objLocalConfig.OItem_class_db_synonyms.GUID
                },
                new clsOntologyItem
                {
                    GUID_Parent = objLocalConfig.OItem_class_db_triggers.GUID
                },
                new clsOntologyItem
                {
                    GUID_Parent = objLocalConfig.OItem_class_db_routines.GUID
                },
                new clsOntologyItem
                {
                    GUID_Parent = objLocalConfig.OItem_class_database.GUID
                },
                new clsOntologyItem
                {
                    GUID_Parent = objLocalConfig.OItem_class_database_schema.GUID
                },
                new clsOntologyItem
                {
                    GUID_Parent = objLocalConfig.OItem_class_db_columns.GUID
                },
                new clsOntologyItem
                {
                    GUID_Parent = objLocalConfig.OItem_class_datatypes__ms_sql_.GUID
                },
                new clsOntologyItem
                {
                    GUID_Parent = objLocalConfig.OItem_class_db_constraint.GUID
                }
            };

            var result = objDBLevel_DatabaseItems.get_Data_Objects(searchDatabaseItems);

            loadedSubItems(LoadSubResult.DatabaseItems, result);
        }

        
        private void GetSubData_003_SchemaTables()
        {
            var searchTablesOfSchemas = objDBLevel_DatabaseItems.OList_Objects.Where(di => di.GUID_Parent == objLocalConfig.OItem_class_database_schema.GUID)
                        .Select(di => new clsObjectRel
                        {
                            ID_Other = di.GUID,
                            ID_RelationType = objLocalConfig.Globals.RelationType_belongsTo.GUID,
                            ID_Parent_Object = objLocalConfig.OItem_class_db_tables.GUID
                        }).ToList();

            var result = objLocalConfig.Globals.LState_Success.Clone();

            if (searchTablesOfSchemas.Any())
            {
                result = objDBLevel_Tables.get_Data_ObjectRel(searchTablesOfSchemas, boolIDs: false);
            }
            else
            {
                objDBLevel_Tables.OList_ObjectRel.Clear();
            }


            loadedSubItems(LoadSubResult.SchemaTables, result);
        }

        private void GetSubData_004_SchemaDatabases()
        {
            var searchSchemaDatabases = objDBLevel_DatabaseItems.OList_Objects.Where(sch => sch.GUID_Parent == objLocalConfig.OItem_class_database.GUID)
                .Select(db => new clsObjectRel
                {
                    ID_Object = db.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_is_of_type.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_database_schema.GUID
                }).ToList();

            var result = objLocalConfig.Globals.LState_Success.Clone();
            if (searchSchemaDatabases.Any())
            {
                result = objDBLevel_Databases.get_Data_ObjectRel(searchSchemaDatabases, boolIDs: false);
            }
            else
            {
                objDBLevel_Databases.OList_ObjectRel.Clear();
            }

            loadedSubItems(LoadSubResult.SchemaDatabases, result);
        }

        private void GetSubData_005_TableColumns()
        {
            var searchTableColumns = objDBLevel_Tables.OList_ObjectRel
                .Select(tab => new clsObjectRel
                {
                    ID_Other = tab.ID_Object,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Object = objLocalConfig.OItem_class_db_columns.GUID
                }).ToList();

            var result = GetSubData_005_001_FieldTypes();

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (searchTableColumns.Any())
                {
                    result = objDBLevel_Columns.get_Data_ObjectRel(searchTableColumns, boolIDs: false);

                    if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var searchColumnAtt = objDBLevel_Columns.OList_ObjectRel.Select(col => new clsObjectAtt
                        {
                            ID_Object = col.ID_Object
                        }).ToList();

                        if (searchColumnAtt.Any())
                        {
                            result = objDBlevel_ColumnAtts.get_Data_ObjectAtt(searchColumnAtt, boolIDs: false);
                        }
                        else
                        {
                            objDBlevel_ColumnAtts.OList_ObjectAtt.Clear();
                        }

                        if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            var searchFieldTypes = objDBLevel_Columns.OList_ObjectRel.Select(col => new clsObjectRel
                            {
                                ID_Object = col.ID_Object,
                                ID_RelationType = objLocalConfig.OItem_relationtype_is_of_type.GUID,
                                ID_Parent_Other = objLocalConfig.OItem_class_field_type.GUID
                            }).ToList();

                            result = objDBLevel_ColumnsToFieldTypes.get_Data_ObjectRel(searchFieldTypes, boolIDs: false);
                        }
                    }
                }
                else
                {
                    objDBLevel_Columns.OList_ObjectRel.Clear();
                }
            }
            
            loadedSubItems(LoadSubResult.SchemaTableColumns, result);
        }

        private clsOntologyItem GetSubData_005_001_FieldTypes()
        {
            var result = objLocalConfig.Globals.LState_Success.Clone();

            if (!objDBLevel_FieldTypes.OList_Objects.Any())
            {
                var searchFieldTypes = new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = objLocalConfig.OItem_class_field_type.GUID } };

                result = objDBLevel_FieldTypes.get_Data_Objects(searchFieldTypes);
            }

            

            return result;
        }

        private void GetSubData_006_Routines()
        {
            var searchRoutines = objDBLevel_DatabaseItems.OList_Objects.Where(dbi => dbi.GUID_Parent == objLocalConfig.OItem_class_database_schema.GUID)
                .Select(dbi => new clsObjectRel
                {
                    ID_Other = dbi.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Object = objLocalConfig.OItem_class_db_routines.GUID
                }).ToList();

            var result = objLocalConfig.Globals.LState_Success.Clone();

            if (searchRoutines.Any())
            {
                result = objDBLevel_Routines.get_Data_ObjectRel(searchRoutines, boolIDs: false);
                if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var searchRoutineTypes = new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = objLocalConfig.OItem_class_routine_type.GUID } };
                    result = objDBLevel_RoutineType.get_Data_Objects(searchRoutineTypes);
                    if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var searchRoutineToType = objDBLevel_DatabaseItems.OList_Objects.Where(dbi => dbi.GUID_Parent == objLocalConfig.OItem_class_db_routines.GUID).Select(routine => new clsObjectRel
                        {
                            ID_Object = routine.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_is_of_type.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_routine_type.GUID
                        }).ToList();

                        if (searchRoutineTypes.Any())
                        {
                            result = objDBLevel_RoutineToType.get_Data_ObjectRel(searchRoutineToType, boolIDs: false);
                        }
                        else
                        {
                            objDBLevel_RoutineToType.OList_ObjectRel.Clear();
                        }
                    }
                }
            }
            else
            {
                objDBLevel_Routines.OList_ObjectRel.Clear();
            }

            loadedSubItems(LoadSubResult.SchemaRoutines, result);
        }

        private void GetSubData_007_Constraints()
        {
            ColumnConstraints = new List<clsConstraint>();
            var searchConstraints = objDBLevel_Columns.OList_ObjectRel
                .Select(col => new clsObjectRel
                {
                    ID_Other = col.ID_Object,
                    ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                    ID_Parent_Object = objLocalConfig.OItem_class_db_constraint.GUID
                }).ToList();

            var result = objLocalConfig.Globals.LState_Success.Clone();
            if (searchConstraints.Any())
            {
                result = objDBLevel_Constraints.get_Data_ObjectRel(searchConstraints, boolIDs: false);
                if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var searchConstraintType = objDBLevel_Constraints.OList_ObjectRel
                        .Select(constr => new clsObjectRel
                        {
                            ID_Object = constr.ID_Object,
                            ID_RelationType = objLocalConfig.OItem_relationtype_is_of_type.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_db_constaint__type_.GUID
                        }).ToList();

                    if (searchConstraintType.Any())
                    {
                        result = objDBLevel_ConstraintTypes.get_Data_ObjectRel(searchConstraintType, boolIDs: false);

                        if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            ColumnConstraints = (from objConstr in objDBLevel_Constraints.OList_ObjectRel
                                                 join objConstrType in objDBLevel_ConstraintTypes.OList_ObjectRel on objConstr.ID_Object equals objConstrType.ID_Object
                                                 select new clsConstraint
                                                 {
                                                     ID_Column = objConstr.ID_Other,
                                                     Name_Column = objConstr.Name_Other,
                                                     ID_Constraint = objConstr.ID_Object,
                                                     Name_Constraint = objConstr.Name_Object,
                                                     ID_ConstraintType = objConstrType.ID_Other,
                                                     Name_ConstraintType = objConstrType.Name_Other
                                                 }).ToList();
                        }
                    }
                    else
                    {
                        objDBLevel_Constraints.OList_ObjectRel.Clear();
                        objDBLevel_ConstraintTypes.OList_ObjectRel.Clear();
                    }
                }
            }
            else
            {
                objDBLevel_Constraints.OList_ObjectRel.Clear();
                objDBLevel_ConstraintTypes.OList_ObjectRel.Clear();
            }

            loadedSubItems(LoadSubResult.SchemaConstraints, result);
        }

        public void GetSubData_008_SchemaViews()
        {
            var searchSchemaViews = objDBLevel_DatabaseItems.OList_Objects.Where(schema => schema.GUID_Parent == objLocalConfig.OItem_class_database_schema.GUID)
                .Select(schema => new clsObjectRel
                {
                    ID_Other = schema.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Object = objLocalConfig.OItem_class_db_views.GUID
                }).ToList();

            var result = objLocalConfig.Globals.LState_Success.Clone();
            if (searchSchemaViews.Any())
            {
                result = objDBLevel_Views.get_Data_ObjectRel(searchSchemaViews, boolIDs: false);
            }
            else
            {
                objDBLevel_Views.OList_ObjectRel.Clear();
            }

            loadedSubItems(LoadSubResult.SchemaViews, result);
        }


        private void GetSubData_009_DatabaseOnServer()
        {
            var searchDatabaseOnServers = objDBLevel_DatabaseProjects.OList_Objects.Select(prj => new clsObjectRel
            {
                ID_Object = prj.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_database_on_server.GUID
            }).ToList();

            var result = objLocalConfig.Globals.LState_Success.Clone();
            if (searchDatabaseOnServers.Any())
            {
                result = objDBLevel_DatabaseOnServer.get_Data_ObjectRel(searchDatabaseOnServers, boolIDs: false);
            }
            else
            {
                objDBLevel_DatabaseOnServer.OList_ObjectRel.Clear();
            }

            loadedSubItems(LoadSubResult.DatabaseOnServer, result);
        }

        private void GetSubData_010_Server()
        {
            var searchServers = objDBLevel_DatabaseOnServer.OList_ObjectRel.Select(dbOnServer => new clsObjectRel
            {
                ID_Object = dbOnServer.ID_Other,
                ID_RelationType = objLocalConfig.OItem_relationtype_located_in.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_server.GUID
            }).ToList();

            var result = objLocalConfig.Globals.LState_Success.Clone();
            if (searchServers.Any())
            {
                result = objDBLevel_Server.get_Data_ObjectRel(searchServers, boolIDs: false);
            }
            else
            {
                objDBLevel_Server.OList_ObjectRel.Clear();
            }

            loadedSubItems(LoadSubResult.Server, result);
        }

        private void GetSubData_011_ServerDatabases()
        {
            var searchServerDatabases = objDBLevel_DatabaseOnServer.OList_ObjectRel.Select(dbOnServer => new clsObjectRel
            {
                ID_Object = dbOnServer.ID_Other,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_database.GUID
            }).ToList();

            var result = objLocalConfig.Globals.LState_Success.Clone();
            if (searchServerDatabases.Any())
            {
                result = objDBLevel_ServerDatabases.get_Data_ObjectRel(searchServerDatabases, boolIDs: false);
            }
            else
            {
                objDBLevel_ServerDatabases.OList_ObjectRel.Clear();
            }

            loadedSubItems(LoadSubResult.ServerDatabases, result);
        }
        
        public clsDataWork_DatabaseConfiguratorModule(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();

        }


        private void Initialize()
        {

            objDBLevel_DatabaseItems = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Tables = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Columns = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Databases = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Routines = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Constraints = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ConstraintTypes = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_DatabaseProjects = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_DbProjToSchema = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_DbProjHierarchy = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RoutineType = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RoutineToType = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Views = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RefToProjects = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ProjectToSecItems = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ColumnsToFieldTypes = new clsDBLevel(objLocalConfig.Globals);
            objDBlevel_ColumnAtts = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_FieldTypes = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_DatabaseOnServer = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Server = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ServerDatabases = new clsDBLevel(objLocalConfig.Globals);

            objDBLevel_CodeSnipplets = new clsDBLevel(objLocalConfig.Globals);

        }
    }
}
