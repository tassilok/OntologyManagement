using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Threading;

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
            SchemaConstraints = 16 
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
            Schema_Constraints = 64
        }

        private Thread threadDatabaseItems;

        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_DatabaseItems;
        private clsDBLevel objDBLevel_Tables;
        private clsDBLevel objDBLevel_Columns;
        private clsDBLevel objDBLevel_Databases;
        private clsDBLevel objDBLevel_Routines;
        private clsDBLevel objDBLevel_Constraints;
        private clsDBLevel objDBLevel_ConstraintTypes;

        private delegate void LoadedSubItems(LoadSubResult loadResult, clsOntologyItem OItem_Result);
        private event LoadedSubItems loadedSubItems;

        public delegate void LoadItems(LoadResult loadResult, clsOntologyItem OItem_Result);
        public event LoadItems loadItems;

        public List<clsObjectRel> SchemaRoutines
        {
            get
            {
                return objDBLevel_Routines.OList_ObjectRel.OrderBy(col => col.Name_Object).ToList();
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
            GetSubData_001_DatabaseItems();
            GetSubData_002_SchemaTables();
            GetSubData_003_SchemaDatabases();
            GetSubData_004_TableColumns();
            GetSubData_005_Routines();
            GetSubData_006_Constraints();
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
            
        }

        public void GetSubData_001_DatabaseItems()
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

        
        private void GetSubData_002_SchemaTables()
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

        private void GetSubData_003_SchemaDatabases()
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

        private void GetSubData_004_TableColumns()
        {
            var searchTableColumns = objDBLevel_Tables.OList_ObjectRel
                .Select(tab => new clsObjectRel
                {
                    ID_Other = tab.ID_Object,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Object = objLocalConfig.OItem_class_db_columns.GUID
                }).ToList();

            var result = objLocalConfig.Globals.LState_Success.Clone();

            if (searchTableColumns.Any())
            {
                result = objDBLevel_Columns.get_Data_ObjectRel(searchTableColumns, boolIDs: false);
            }
            else
            {
                objDBLevel_Columns.OList_ObjectRel.Clear();
            }

            loadedSubItems(LoadSubResult.SchemaTableColumns, result);
        }

        private void GetSubData_005_Routines()
        {
            var searchRoutines = objDBLevel_DatabaseItems.OList_Objects
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
            }
            else
            {
                objDBLevel_Routines.OList_ObjectRel.Clear();
            }

            loadedSubItems(LoadSubResult.SchemaRoutines, result);
        }

        private void GetSubData_006_Constraints()
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
        }
    }
}
