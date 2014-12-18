using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using System.Threading;
using OntologyClasses.BaseClasses;

namespace NextGenerationOntoEdit
{
    public enum LoadResult
    {
        ClassAttributes = 0,
        ClassRelations = 1,
        ObjectAttributes = 2,
        ObjectRelations = 4,
        Objects = 8,
        Items = 1024
    }
    public class clsDataWork_OntologyItems
    {
        private clsLocalConfig localConfig;

        private clsDBLevel dbLevel_Objects;
        private clsDBLevel dbLevel_ClassAttributes;
        private clsDBLevel dbLevel_ClassRelations;
        private clsDBLevel dbLevel_ObjectAtt;
        private clsDBLevel dbLevel_ObjectRel;
        private clsDBLevel dbLevel_OtherRel;

        public List<clsClassAtt> ClassAttributes
        {
            get
            {
                return dbLevel_ClassAttributes.OList_ClassAtt;
            }
        }

        public List<clsClassRel> ClassRelations
        {
            get
            {
                return dbLevel_ClassRelations.OList_ClassRel;
            }
        }

        public List<clsObjectAtt> ObjectAttributes
        {
            get
            {
                return dbLevel_ObjectAtt.OList_ObjectAtt;
            }
        }

        public List<clsObjectRel> ObjectRelations
        {
            get
            {
                return dbLevel_ObjectRel.OList_ObjectRel;
            }
        }

        public List<clsObjectRel> OtherRelations
        {
            get
            {
                return dbLevel_OtherRel.OList_ObjectRel;
            }
        }

        public List<clsOntologyItem> Objects
        {
            get
            {
                return dbLevel_Objects.OList_Objects;
            }
        }

        public clsOntologyItem OItem_Result_ClassAtt { get; private set; }
        public clsOntologyItem OItem_Result_ClassRel { get; private set; }
        public clsOntologyItem OItem_Result_ObjectAtt { get; private set; }
        public clsOntologyItem OItem_Result_ObjectRel { get; private set; }
        public clsOntologyItem OItem_Result_Objects { get; private set; }

        public clsOntologyItem ClassItem { get; private set; }

        private Thread threadItemData_Class;

        private delegate void LoadedSubItems(LoadResult loadResult, clsOntologyItem OItem_Result);
        private event LoadedSubItems loadedSubItems;

        public delegate void LoadItems(LoadResult loadResult, clsOntologyItem OItem_Result);
        public event LoadItems loadItems;

        public clsDataWork_OntologyItems(clsLocalConfig localConfig)
        {
            this.localConfig = localConfig;

            Initialize();
        }

        public clsOntologyItem GetData_ClassItems(clsOntologyItem classItem)
        {
            ClassItem = classItem;

            OItem_Result_ClassAtt = null;
            OItem_Result_ClassRel = null;
            OItem_Result_ObjectAtt = null;
            OItem_Result_ObjectRel = null;

            var result = localConfig.Globals.LState_Success.Clone();

            loadedSubItems +=clsDataWork_OntologyItems_loadedSubItems;

            try
            {
            }
            catch (Exception ex)
            {
                threadItemData_Class.Abort();
            }

            threadItemData_Class = new Thread(GetThreadData_Class);
            threadItemData_Class.Start();

            return result;
        }

        private void GetThreadData_Class()
        {
            GetSubData_001_ClassAtt();
            GetSubData_002_ClassRelations();
            GetSubData_003_ObjectAtt();
            GetSubData_004_ObjectRel();
            GetSubData_005_Objects();
        }

        void clsDataWork_OntologyItems_loadedSubItems(LoadResult loadResult, clsOntologyItem OItem_Result)
        {
            if (loadResult == LoadResult.ClassAttributes)
            {
                OItem_Result_ClassAtt = OItem_Result;
            }

            if (loadResult == LoadResult.ClassRelations)
            {
                OItem_Result_ClassRel = OItem_Result;
            }

            if (loadResult == LoadResult.ObjectAttributes)
            {
                OItem_Result_ObjectAtt = OItem_Result;
            }

            if (loadResult == LoadResult.ObjectRelations)
            {
                OItem_Result_ObjectRel = OItem_Result;
            }

            if (loadResult == LoadResult.Objects)
            {
                OItem_Result_Objects = OItem_Result;
            }


            if (OItem_Result_ClassAtt != null
                && OItem_Result_ClassRel != null
                && OItem_Result_ObjectAtt != null
                && OItem_Result_ObjectRel != null
                && OItem_Result_Objects != null)
            {
                if (OItem_Result_ClassAtt.GUID == localConfig.Globals.LState_Error.GUID
                    || OItem_Result_ClassRel.GUID == localConfig.Globals.LState_Error.GUID
                    || OItem_Result_ObjectAtt.GUID == localConfig.Globals.LState_Error.GUID
                    || OItem_Result_ObjectRel.GUID == localConfig.Globals.LState_Error.GUID
                    || OItem_Result_Objects.GUID == localConfig.Globals.LState_Error.GUID)
                {
                    loadItems(LoadResult.Items, localConfig.Globals.LState_Error.Clone());
                }
                else
                {
                    loadItems(LoadResult.Items, localConfig.Globals.LState_Success.Clone());
                }
            }
        }

        public void GetSubData_001_ClassAtt()
        {
            var result = dbLevel_ClassAttributes.get_Data_ClassAtt(new List<clsOntologyItem> { ClassItem }, boolIDs: false);

            loadedSubItems(LoadResult.ClassAttributes, result);
        }

        public void GetSubData_002_ClassRelations()
        {
            var searchClassRel = new List<clsClassRel> { new clsClassRel { ID_Class_Left = ClassItem.GUID } };

            var result = dbLevel_ClassRelations.get_Data_ClassRel(searchClassRel, boolIDs: false);

            loadedSubItems(LoadResult.ClassRelations, result);
        }

        public void GetSubData_003_ObjectAtt()
        {
            var searchObjectAtt = new List<clsObjectAtt> { new clsObjectAtt { ID_Class = ClassItem.GUID } };

            var result = dbLevel_ObjectAtt.get_Data_ObjectAtt(searchObjectAtt, boolIDs: false);

            loadedSubItems(LoadResult.ObjectAttributes, result);
        }

        public void GetSubData_004_ObjectRel()
        {
            var searchObjectRel = new List<clsObjectRel> { new clsObjectRel { ID_Parent_Object = ClassItem.GUID, Ontology = localConfig.Globals.Type_Object } };

            var result = dbLevel_ObjectRel.get_Data_ObjectRel(searchObjectRel, boolIDs: false);

            searchObjectRel = new List<clsObjectRel> { new clsObjectRel { ID_Parent_Object = ClassItem.GUID, Ontology = localConfig.Globals.Type_AttributeType },
                new clsObjectRel { ID_Parent_Object = ClassItem.GUID, Ontology = localConfig.Globals.Type_RelationType },
                new clsObjectRel { ID_Parent_Object = ClassItem.GUID, Ontology = localConfig.Globals.Type_Class } };

            result = dbLevel_OtherRel.get_Data_ObjectRel(searchObjectRel, boolIDs: false);

            loadedSubItems(LoadResult.ObjectRelations, result);
        }

        public void GetSubData_005_Objects()
        {
            var searchObjects = new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = ClassItem.GUID } };

            var result = dbLevel_Objects.get_Data_Objects(searchObjects);

            loadedSubItems(LoadResult.Objects, result);
        }

        private void Initialize()
        {
            dbLevel_ClassAttributes = new clsDBLevel(localConfig.Globals);
            dbLevel_ClassRelations = new clsDBLevel(localConfig.Globals);
            dbLevel_ObjectAtt = new clsDBLevel(localConfig.Globals);
            dbLevel_ObjectRel = new clsDBLevel(localConfig.Globals);
            dbLevel_Objects = new clsDBLevel(localConfig.Globals);
            dbLevel_OtherRel = new clsDBLevel(localConfig.Globals);
        }
    }
}
