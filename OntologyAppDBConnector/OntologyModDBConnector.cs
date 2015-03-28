using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using ElasticSearchNestConnector;
using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses;

namespace OntologyAppDBConnector
{
    public class OntologyModDBConnector
    {
        private List<clsOntologyItem> objects1;
 
        public List<clsOntologyItem> Objects1 
        {
            get {
                if (Sort == SortEnum.ASC_Name)
                {
                    return objects1.OrderBy(obj => obj.Name).ToList();
                }
                else if (Sort == SortEnum.DESC_Name)
                {
                    return objects1.OrderByDescending(obj => obj.Name).ToList();
                }
                else
                {
                    return objects1;
                }
            }
            set { objects1 = value; }
        }
        public List<clsOntologyItem> Objects2 { get; set; }
        private List<clsObjectRel> objectRelsId;

        public List<clsObjectRel> ObjectRelsId
        {
            get
            {
                if (Sort == SortEnum.ASC_OrderID)
                {
                    return objectRelsId.OrderBy(objRel => objRel.OrderID).ToList();
                }
                else if (Sort == SortEnum.DESC_OrderID)
                {
                    return objectRelsId.OrderByDescending(objRel => objRel.OrderID).ToList();
                }
                else
                {
                    return objectRelsId;
                }
                
            }
            set { objectRelsId = value; }
        }

        private List<clsObjectRel> objectRels;

        public List<clsObjectRel> ObjectRels
        {
            get
            {
                if (Sort == SortEnum.ASC_OrderID)
                {
                    return objectRels.OrderBy(objRel => objRel.OrderID).ToList();
                }
                else if (Sort == SortEnum.DESC_OrderID)
                {
                    return objectRels.OrderByDescending(objRel => objRel.OrderID).ToList();
                }
                else if (Sort == SortEnum.ASC_Name)
                {
                    return objectRels.OrderBy(objRel => objRel.Name_Other).ToList();
                }
                else if (Sort == SortEnum.DESC_Name)
                {
                    return objectRels.OrderByDescending(objRel => objRel.Name_Other).ToList();
                }
                else
                {
                    return objectRels;
                }
            }
            set { objectRels = value; }
        }
        public List<clsObjectTree> ObjectTree { get; set; }
        public List<clsOntologyItem> Classes1 { get; set; }
        public List<clsOntologyItem> Classes2 { get; set; }
        public List<clsOntologyItem> RelationTypes { get; set; }
        public List<clsOntologyItem> AttributeTypes { get; set; }
        public List<clsClassAtt> ClassRelsId { get; set; }
        public List<clsClassAtt> ClassRels { get; set; }
        public List<clsClassAtt> ClassAttsId { get; set; }
        public List<clsClassAtt> ClassAtts { get; set; }
        public List<clsObjectAtt> ObjAttsId { get; set; }
        public List<clsObjectAtt> ObjAtts { get; set; }
        public List<clsOntologyItem> DataTypes { get; set; }
        public List<clsAttribute> Attributes { get; set; }

        private clsDataTypes dataTypes;
        private clsTypes types;
        private clsLogStates logStates;
        private clsFields fields;
        private clsDirections directions;
        private clsClasses objClasses;
        private clsRelationTypes relationTypes;
        private clsAttributeTypes attributeTypes;

        private string server;
        private string index;
        private string indexRep;
        private int port;
        private int searchRange;
        private string session;

        public int PackageLength { get; set; }
        private SortEnum sortE;

        private clsDBSelector elSelector;
        private clsDBDeletor elDeletor;
        private clsDBUpdater elUpdater;

        public List<clsObjectAtt> SavedObjectAtts { get; private set; }

        public delegate void NamingError();

        public NamingError namingError;

        public SortEnum Sort
        {
            get { return sortE;}
            set
            {
                Sort = value;
                elSelector.Sort = Sort;
            }
        }
        
        public List<string> IndexList(string server, int port)
        {
            
            return elSelector.IndexList(server, port);
            
        }

        public clsOntologyItem DelAttributeTypes(List<clsOntologyItem> attributeTypes)
        {
            return elDeletor.del_AttributeType(attributeTypes);
        }

        public clsOntologyItem DelRelationTypes(List<clsOntologyItem> relationTypes)
        {
            return elDeletor.del_RelationType(relationTypes);
        }

        public clsOntologyItem DelDataTypes(List<clsOntologyItem> dataTypes)
        {
            return elDeletor.del_DataType(dataTypes);
        }

        public clsOntologyItem DelClassAttType(clsOntologyItem classItem, clsOntologyItem attType)
        {
            return elDeletor.del_ClassAttType(classItem, attType);
        }

        public clsOntologyItem DelObjects(List<clsOntologyItem> objects)
        {
            return elDeletor.del_Objects(objects);
        }

        public clsOntologyItem DelClassRel(List<clsClassRel> classRels)
        {
            return elDeletor.del_ClassRel(classRels);
        }

        public clsOntologyItem DelObjectAtts(List<clsObjectAtt> objectAtts)
        {
            return elDeletor.del_ObjectAtt(objectAtts);
        }

        public clsOntologyItem DelObjectRels(List<clsObjectRel> objectRels)
        {
            return elDeletor.del_ObjectRel(objectRels);
        }

        public clsOntologyItem DelClasses(List<clsOntologyItem> classes)
        {
            return elDeletor.del_Class(classes);
        }



        public clsOntologyItem SaveDataTypes(List<clsOntologyItem> dataTypes)
        {
            var result = elUpdater.save_DataTypes(dataTypes);
            return result;
        }

        public clsOntologyItem SaveAttributeTypes(List<clsOntologyItem> attributeTypes)
        {
            
            foreach (var attributeType in attributeTypes)
            {
                var result = elUpdater.save_AttributeType(attributeType);
                if (result.GUID == logStates.LogState_Error.GUID)
                {
                    return logStates.LogState_Error.Clone();
                }
            }

            return logStates.LogState_Success.Clone();
        }


        public clsOntologyItem SaveClassRel(List<clsClassRel> classRels)
        {
            return elUpdater.save_ClassRel(classRels);
        }

        public clsOntologyItem SaveClassAtt(List<clsClassAtt> classAtts)
        {
            return elUpdater.save_ClassAtt(classAtts);
        }

        public clsOntologyItem SaveClass(List<clsOntologyItem> classes)
        {
            foreach (var classItem in classes)
            {
                var result = elUpdater.save_Class(classItem, string.IsNullOrEmpty(classItem.GUID_Parent));
                if (result.GUID == logStates.LogState_Error.GUID)
                {
                    return result;
                }
            }

            return logStates.LogState_Success.Clone();
        }

        public clsOntologyItem SaveObjRel(List<clsObjectRel> objectRels)
        {
            return elUpdater.save_ObjectRel(objectRels);
        }

        public clsOntologyItem SaveObjAtt(List<clsObjectAtt> objectAtts)
        {
            SavedObjectAtts = elUpdater.save_ObjectAtt(objectAtts);
            if (objectAtts.Count - SavedObjectAtts.Count == 0)
            {
                return logStates.LogState_Success.Clone();
            }
            else
            {
                return logStates.LogState_Error.Clone();
            }
        }

        public clsOntologyItem SaveObjects(List<clsOntologyItem> objects)
        {
            var searchRules = objects.GroupBy(obj => obj.GUID_Parent).Select(parentGuid => new clsObjectRel
            {
                ID_Other = parentGuid.Key,
                ID_RelationType = relationTypes.OItem_RelationType_belongingClass.GUID,
                ID_Parent_Object = objClasses.OItem_Class_Ontology_Naming_Rule.GUID
            }).ToList();

            var namingRules = elSelector.get_Data_ObjectRel(searchRules, boolIDs: true);

            var result = logStates.LogState_Error.Clone();

            if (namingRules != null)
            {
                result = logStates.LogState_Success.Clone();

                var searchRegEx = namingRules.Select(nr => new clsObjectAtt
                {
                    ID_Object = nr.ID_Object,
                    ID_AttributeType = attributeTypes.OITem_AttributeType_Regex.GUID
                }).ToList();

                var namingRegex = new List<clsObjectAtt>();

                if (searchRegEx.Any())
                {
                    namingRegex = elSelector.get_Data_ObjectAtt(searchRegEx, boolIDs: false);

                    if (namingRegex == null)
                    {
                        result = logStates.LogState_Error.Clone();
                    }
                }

                if (result.GUID == logStates.LogState_Success.GUID)
                {
                    var testItems = (from obj in objects
                        join namingRule in namingRules on obj.GUID_Parent equals namingRule.ID_Other
                        join regEx in namingRegex on namingRule.ID_Object equals regEx.ID_Object
                        select new {obj, namingRule, regEx}).ToList();

                    var errorItems = testItems.Where(obj =>
                    {
                        var regEx = new Regex(obj.regEx.Val_String);
                        return !regEx.IsMatch(obj.obj.Name);
                    }).ToList();

                    if (!errorItems.Any())
                    {
                        result = elUpdater.save_Objects(objects);
                    }
                    else
                    {
                        if (namingError != null)
                        {
                            namingError();    
                        }
                        
                    }
                }
            }

            return result;
        }

        public clsOntologyItem SaeRelationTypes(List<clsOntologyItem> relationTypes)
        {
            foreach (var relationType in relationTypes)
            {
                var result = elUpdater.save_RelationType(relationType);
                if (result.GUID == logStates.LogState_Error.GUID)
                {
                    return logStates.LogState_Error.Clone();
                }

                
            }

            return logStates.LogState_Success.Clone();
        }

        public clsOntologyItem GetDataRelationTypes(List<clsOntologyItem> relationTypes,
            bool doCount = false)
        {

            var result = logStates.LogState_Success.Clone();
            if (doCount)
            {
                result.Count = elSelector.get_Data_RelationTypesCount(relationTypes);
            }
            else
            {
                RelationTypes = elSelector.get_Data_RelationTypes(relationTypes);
                if (RelationTypes == null)
                {
                    result = logStates.LogState_Error.Clone();
                }
            }

            return result;
        }

        public clsOntologyItem GetDataAttributeType(List<clsOntologyItem> attributeTypes,
            bool doCount = false)
        {
            var result = logStates.LogState_Success.Clone();

            if (doCount)
            {
                result.Count = elSelector.get_Data_AttributeTypeCount(attributeTypes);
            }
            else
            {
                AttributeTypes = elSelector.get_Data_AttributeType(attributeTypes);
                if (AttributeTypes == null)
                {
                    result = logStates.LogState_Error.Clone();
                }
            }

            return result;
        }

        public clsOntologyItem GetDataClassAtts(List<clsOntologyItem> classes,
            List<clsOntologyItem> attributeTypes,
            bool doIds = false,
            bool doCount = false)
        {
            var result = logStates.LogState_Success.Clone();

            if (doCount)
            {
                result.Count = elSelector.get_Data_ClassAttCount(classes, attributeTypes);
            }
            else
            {
                if (doIds)
                {
                    ClassAttsId = elSelector.get_Data_ClassAtt(classes, attributeTypes, boolIDs: doIds);
                }
                else
                {
                    ClassAtts = elSelector.get_Data_ClassAtt(classes, attributeTypes, boolIDs: doIds);
                }
            }

            return result;
        }



        private void InitializeClient()
        {
            PackageLength = searchRange;
            elSelector = new clsDBSelector(server,port,index,indexRep,PackageLength,session);
            elDeletor = new clsDBDeletor(elSelector);
            elUpdater = new clsDBUpdater(elSelector);
        }


    }
}
