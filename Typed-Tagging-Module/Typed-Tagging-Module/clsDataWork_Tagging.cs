using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Typed_Tagging_Module
{
    [Flags]
    public enum SemanticFilterType
    {
        None = 0,
        TaggingSource = 1,
        TaggingDest = 2,
        TypedTag = 4
    }
    public class clsDataWork_Tagging
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_SecurityRel;

        private clsDBLevel objDBLevel_TaggingSource;

        private clsDBLevel objDBLevel_Tag;

        private clsDBLevel objDBLevel_Classes;

        private clsDBLevel objDBLevel_SemFilter;

        private clsOntologyItem objOItem_TaggingSource;
        private clsOntologyItem objOItem_TaggingDest;

        private clsRelationConfig objRelationConfig;

        private List<clsOntologyItem> TagFilter;

        public List<clsTypedTag> TypedTags_Sources { get; private set; }
        public List<clsTypedTag> TypedTags_SourcesSemFilter { get; private set; }

        public List<clsTypedTag> TypedTags_Dests { get; private set; }

        public List<clsOntologyItem> ClassTags { get; private set; }

        public List<clsOntologyItem> ClassesInTree { get; private set; }

        public List<clsOntologyItem> ObjectTags { get; private set; }

        public List<clsOntologyItem> AttributeTypeTags { get; private set; }

        public List<clsOntologyItem> RelationTypeTags { get; private set; }

        public List<clsOntologyItem> TagSources { get; private set; }


        public clsOntologyItem OItem_Result_Source { get; private set; }

        private clsOntologyItem objOItem_SFilterClass;
        private clsOntologyItem objOItem_SFilterRelationType;
        private clsOntologyItem objOItem_SFilterObject;
        private clsOntologyItem objOItem_SFilterDirection;

        private SemanticFilterType semanticFilterType;

        public List<clsOntologyItem> Classes  
        {
            get { return objDBLevel_Classes.OList_Classes; }
        }

        public List<clsOntologyItem> ClassTree { get; private set; }

        public List<clsObjectRel> Tags_Of_TypedTags
        {
            get { return objDBLevel_Tag.OList_ObjectRel; }
        }

        public List<clsObjectRel> TagSources_Of_TypedTags
        {
            get { return objDBLevel_TaggingSource.OList_ObjectRel; }
        }


        public void AddTag(clsOntologyItem OItem_Tag, clsOntologyItem OItem_TaggingSource, clsOntologyItem OItem_TaggingDest)
        {
            objDBLevel_TaggingSource.OList_ObjectRel.Add(objRelationConfig.Rel_ObjectRelation(OItem_Tag, OItem_TaggingSource, objLocalConfig.OItem_relationtype_is_tagging,Full:true));
            objDBLevel_Tag.OList_ObjectRel.Add(objRelationConfig.Rel_ObjectRelation(OItem_Tag, OItem_TaggingDest, objLocalConfig.OItem_relationtype_belonging_tag, Full: true));
            objDBLevel_SecurityRel.OList_ObjectRel.Add(objRelationConfig.Rel_ObjectRelation(OItem_Tag, objLocalConfig.OItem_User, objLocalConfig.OItem_relationtype_belongs_to, Full: true));
            objDBLevel_SecurityRel.OList_ObjectRel.Add(objRelationConfig.Rel_ObjectRelation(OItem_Tag, objLocalConfig.OItem_Group, objLocalConfig.OItem_relationtype_belongs_to, Full: true));

        }


        public clsOntologyItem GetTags(List<clsOntologyItem> TagFilter)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            
            this.TagFilter = TagFilter;
            
            objOItem_Result = GetClasses();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = GetSubData_SecurityRel();

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    List<clsObjectRel> objOList_Search_Tag;

                    objOList_Search_Tag = new List<clsObjectRel> 
                { 
                    new clsObjectRel 
                    {
                        ID_Parent_Object = objLocalConfig.OItem_class_typed_tag.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_belonging_tag.GUID
                    }
                };
                    List<clsObjectRel> TagList;
                    
                    objOItem_Result = objDBLevel_Tag.get_Data_ObjectRel(objOList_Search_Tag, boolIDs: false);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (TagFilter == null)
                        {
                            TagList = objDBLevel_Tag.OList_ObjectRel;
                        }
                        else
                        {
                            TagList = (from tag in TagFilter
                                       join searchTag in objDBLevel_Tag.OList_ObjectRel on tag.GUID equals searchTag.ID_Object
                                       select searchTag).ToList();
                        }

                        ClassTags = (from objTag in TagList.
                                     Where(t => t.Ontology == objLocalConfig.Globals.Type_Class).ToList()
                                     group objTag by new { objTag.ID_Other, objTag.Name_Other, objTag.ID_Parent_Other } into objTags
                                     select new clsOntologyItem
                                     {
                                         GUID = objTags.Key.ID_Other,
                                         Name = objTags.Key.Name_Other,
                                         GUID_Parent = objTags.Key.ID_Parent_Other,
                                         Type = objLocalConfig.Globals.Type_Class
                                     }).OrderBy(c => c.Name).ToList();

                        ObjectTags = (from objTag in TagList.
                                      Where(t => t.Ontology == objLocalConfig.Globals.Type_Object).ToList()
                                      group objTag by new { objTag.ID_Other, objTag.Name_Other, objTag.ID_Parent_Other } into objTags
                                      select new clsOntologyItem
                                      {
                                          GUID = objTags.Key.ID_Other,
                                          Name = objTags.Key.Name_Other,
                                          GUID_Parent = objTags.Key.ID_Parent_Other,
                                          Type = objLocalConfig.Globals.Type_Object
                                      }).OrderBy(c => c.GUID_Parent).ThenBy(c => c.Name).ToList();


                        ClassesInTree = (from objTag in ObjectTags
                                            join objClass in objDBLevel_Classes.OList_Classes on objTag.GUID_Parent equals objClass.GUID
                                            group objClass by new { objClass.GUID, objClass.Name, objClass.GUID_Parent } into objClasses
                                            select new clsOntologyItem
                                            {
                                                GUID = objClasses.Key.GUID,
                                                Name = objClasses.Key.Name,
                                                GUID_Parent = objClasses.Key.GUID_Parent,
                                                Type = objLocalConfig.Globals.Type_Class
                                            }).OrderBy(c => c.Name).ToList();

                        CreateClassTree();

                        AttributeTypeTags = (from objTag in TagList.
                                      Where(t => t.Ontology == objLocalConfig.Globals.Type_AttributeType).ToList()
                                             group objTag by new { objTag.ID_Other, objTag.Name_Other, objTag.ID_Parent_Other } into objTags
                                             select new clsOntologyItem
                                             {
                                                 GUID = objTags.Key.ID_Other,
                                                 Name = objTags.Key.Name_Other,
                                                 GUID_Parent = objTags.Key.ID_Parent_Other,
                                                 Type = objLocalConfig.Globals.Type_AttributeType
                                             }).OrderBy(a => a.Name).ToList();

                        RelationTypeTags = (from objTag in TagList.
                                      Where(t => t.Ontology == objLocalConfig.Globals.Type_RelationType).ToList()
                                            group objTag by new { objTag.ID_Other, objTag.Name_Other, objTag.ID_Parent_Other } into objTags
                                            select new clsOntologyItem
                                            {
                                                GUID = objTags.Key.ID_Other,
                                                Name = objTags.Key.Name_Other,
                                                GUID_Parent = objTags.Key.ID_Parent_Other,
                                                Type = objLocalConfig.Globals.Type_RelationType
                                            }).OrderBy(r => r.Name).ToList();
                    }
                }
            }

            

            return objOItem_Result;
        }

        private void CreateClassTree()
        {
            var count = 0;
            ClassTree = new List<clsOntologyItem>();
            ClassTree.AddRange(ClassesInTree);

            while (ClassTree.Count > count)
            {
                count = ClassTree.Count;

                var classesParent = (from objClassPar in Classes
                                     join objClass in ClassTree on objClassPar.GUID equals objClass.GUID_Parent
                                     group objClassPar by new { objClassPar.GUID, objClassPar.Name, objClassPar.GUID_Parent } into objClasses
                                     select new clsOntologyItem
                                     {
                                         GUID = objClasses.Key.GUID,
                                         Name = objClasses.Key.Name,
                                         GUID_Parent = objClasses.Key.GUID_Parent,
                                         Type = objLocalConfig.Globals.Type_Class
                                     }).ToList();

                ClassTree.AddRange(from objClassNew in classesParent
                                   join objClass in ClassTree on objClassNew.GUID equals objClass.GUID into objClasses
                                  from objClass in objClasses.DefaultIfEmpty()
                                  where objClass == null
                                  select objClassNew);
                
                  
            }
        }

        private clsOntologyItem GetClasses()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            objOItem_Result = objDBLevel_Classes.get_Data_Classes();

            return objOItem_Result;
        }

        public clsOntologyItem GetTagsOfTaggingDest(clsOntologyItem OItem_TaggingDest = null)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            objOItem_TaggingDest = OItem_TaggingDest;
            
            TypedTags_Dests = new List<clsTypedTag>();


            var objOList_Search_TaggingDest = new List<clsObjectRel>();

            if (OItem_TaggingDest != null)
            {
                objOList_Search_TaggingDest = new List<clsObjectRel>
                {
                    new clsObjectRel
                    {
                        ID_Other = objOItem_TaggingDest.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_belonging_tag.GUID,
                        ID_Parent_Object = objLocalConfig.OItem_class_typed_tag.GUID
                    }
                };


            }
            else
            {
                objOList_Search_TaggingDest = new List<clsObjectRel>
                {
                    new clsObjectRel
                    {
                        ID_RelationType = objLocalConfig.OItem_relationtype_belonging_tag.GUID,
                        ID_Parent_Object = objLocalConfig.OItem_class_typed_tag.GUID
                    }
                };
            }
            

            objOItem_Result = GetClasses();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = objDBLevel_Tag.get_Data_ObjectRel(objOList_Search_TaggingDest, boolIDs: false);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {

                    if (objDBLevel_Tag.OList_ObjectRel.Any())
                    {
                        List<clsObjectRel> objOList_Search_TaggingSource;
                        if (objDBLevel_Tag.OList_ObjectRel.Count < 500)
                        {
                            objOList_Search_TaggingSource = objDBLevel_Tag.OList_ObjectRel.Select(t => new clsObjectRel
                            {
                                ID_Object = t.ID_Object,
                                ID_RelationType = objLocalConfig.OItem_relationtype_is_tagging.GUID
                            }).ToList();


                        }
                        else
                        {
                            objOList_Search_TaggingSource = new List<clsObjectRel> 
                            {
                                new clsObjectRel 
                                {
                                    ID_Other = objOItem_TaggingSource != null ? objOItem_TaggingSource.GUID : null,
                                    ID_Parent_Other =  objOItem_TaggingSource != null ? objOItem_TaggingSource.GUID_Parent : null, 
                                    ID_RelationType = objLocalConfig.OItem_relationtype_is_tagging.GUID,
                                    ID_Parent_Object = objLocalConfig.OItem_class_typed_tag.GUID 
                                } 
                            };
                        }

                        objOItem_Result = objDBLevel_TaggingSource.get_Data_ObjectRel(objOList_Search_TaggingSource, boolIDs: false);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objOItem_Result = GetSubData_SecurityRel();

                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                var objOList_TaggingSource = (from objUser in objDBLevel_SecurityRel.OList_ObjectRel.Where(u => u.ID_Parent_Other == objLocalConfig.OItem_class_user.GUID).ToList()
                                                              join objGroup in objDBLevel_SecurityRel.OList_ObjectRel.Where(u => u.ID_Parent_Other == objLocalConfig.OItem_class_group.GUID).ToList() on objUser.ID_Object equals objGroup.ID_Object
                                                              join objTaggingSource in objDBLevel_TaggingSource.OList_ObjectRel on objGroup.ID_Object equals objTaggingSource.ID_Object
                                                              select objTaggingSource).ToList();
                                TagSources = objOList_TaggingSource.Where(ts => ts.Ontology == objLocalConfig.Globals.Type_AttributeType).Select(ts => new clsOntologyItem
                                {
                                    GUID = ts.ID_Other,
                                    Name = ts.Name_Other,
                                    Type = objLocalConfig.Globals.Type_AttributeType
                                }).ToList();


                                TagSources.AddRange(objOList_TaggingSource.Where(ts => ts.Ontology == objLocalConfig.Globals.Type_RelationType).Select(ts => new clsOntologyItem
                                {
                                    GUID = ts.ID_Other,
                                    Name = ts.Name_Other,
                                    Type = objLocalConfig.Globals.Type_RelationType
                                }));

                                TagSources.AddRange(objOList_TaggingSource.Where(ts => ts.Ontology == objLocalConfig.Globals.Type_Class).Select(ts => new clsOntologyItem
                                {
                                    GUID = ts.ID_Other,
                                    Name = ts.Name_Other,
                                    GUID_Parent = ts.ID_Parent_Other,
                                    Type = objLocalConfig.Globals.Type_Class
                                }));

                                var objects = objOList_TaggingSource.Where(ts => ts.Ontology == objLocalConfig.Globals.Type_Object).Select(ts => new clsOntologyItem
                                {
                                    GUID = ts.ID_Other,
                                    Name = ts.Name_Other,
                                    GUID_Parent = ts.ID_Parent_Other,
                                    Type = objLocalConfig.Globals.Type_Object
                                }).ToList();

                                TagSources.AddRange(from objObject in objects
                                                    join objClass in Classes on objObject.GUID_Parent equals objClass.GUID
                                                    select new clsOntologyItem
                                                    {
                                                        GUID = objObject.GUID,
                                                        Name = objObject.Name,
                                                        GUID_Parent = objObject.GUID_Parent,
                                                        Name_Parent = objClass.Name,
                                                        Type = objLocalConfig.Globals.Type_Object
                                                    });
                            }
                        }
                    }
                }
            }
            

            return objOItem_Result;
        }

        public clsOntologyItem GetTagsOfTaggingSource(clsOntologyItem OItem_TaggingSource = null)
        {
            OItem_Result_Source = objLocalConfig.Globals.LState_Success.Clone();

            objOItem_TaggingSource = OItem_TaggingSource;

            OItem_Result_Source = GetSubData_SecurityRel();

            TypedTags_Sources = new List<clsTypedTag>();

            var objOList_Search_TaggingSource = new List<clsObjectRel> 
            {
                new clsObjectRel 
                {
                    ID_Other = objOItem_TaggingSource != null ? objOItem_TaggingSource.GUID : null,
                    ID_Parent_Other =  objOItem_TaggingSource != null ? objOItem_TaggingSource.GUID_Parent : null, 
                    ID_RelationType = objLocalConfig.OItem_relationtype_is_tagging.GUID,
                    ID_Parent_Object = objLocalConfig.OItem_class_typed_tag.GUID 
                } 
            };

            OItem_Result_Source = objDBLevel_TaggingSource.get_Data_ObjectRel(objOList_Search_TaggingSource, boolIDs: false);

            if (OItem_Result_Source.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                
                var objOList_TaggingSource = (from objUser in objDBLevel_SecurityRel.OList_ObjectRel.Where(u => u.ID_Parent_Other == objLocalConfig.OItem_class_user.GUID).ToList()
                                                join objGroup in objDBLevel_SecurityRel.OList_ObjectRel.Where(u => u.ID_Parent_Other == objLocalConfig.OItem_class_group.GUID).ToList() on objUser.ID_Object equals objGroup.ID_Object
                                                join objTaggingSource in objDBLevel_TaggingSource.OList_ObjectRel on objGroup.ID_Object equals objTaggingSource.ID_Object
                                                select objTaggingSource).ToList();

                if (objOList_TaggingSource.Any())
                {
                    TagSources = objOList_TaggingSource.Select(ts => new clsOntologyItem
                    {
                        GUID = ts.ID_Other,
                        Name = ts.Name_Other,
                        GUID_Parent = ts.ID_Parent_Other,
                        Type = ts.Ontology
                    }).ToList();

                    List<clsObjectRel> objOList_Search_Tag;


                    if (objOList_TaggingSource.Count > 500)
                    {
                        objOList_Search_Tag = new List<clsObjectRel> 
                        { 
                            new clsObjectRel 
                            {
                                ID_Parent_Object = objLocalConfig.OItem_class_typed_tag.GUID,
                                ID_RelationType = objLocalConfig.OItem_relationtype_belonging_tag.GUID
                            }
                        };
                    }
                    else
                    {
                        objOList_Search_Tag = objOList_TaggingSource.Select(ts => new clsObjectRel
                        {
                            ID_Object = ts.ID_Object,
                            ID_RelationType = objLocalConfig.OItem_relationtype_belonging_tag.GUID
                        }).ToList();
                    }


                    OItem_Result_Source = objDBLevel_Tag.get_Data_ObjectRel(objOList_Search_Tag, boolIDs: false);

                    if (OItem_Result_Source.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        TypedTags_Sources = (from objTaggingSource in objOList_TaggingSource
                                     join objTaggingDest in objDBLevel_Tag.OList_ObjectRel on objTaggingSource.ID_Object equals objTaggingDest.ID_Object
                                     select new clsTypedTag
                                     {
                                         ID_Group = objLocalConfig.OItem_Group.GUID,
                                         Name_Group = objLocalConfig.OItem_Group.Name,
                                         ID_User = objLocalConfig.OItem_User.GUID,
                                         Name_User = objLocalConfig.OItem_User.Name,
                                         ID_TaggingSource = objTaggingSource.ID_Other,
                                         Name_TaggingSource = objTaggingSource.Name_Other,
                                         ID_Parent_TaggingSource = objTaggingSource.ID_Parent_Other,
                                         Name_Parent_TaggingSource = objTaggingSource.Name_Parent_Other,
                                         OrderId_TaggingSource = objTaggingSource.OrderID ?? 0,
                                         ID_TaggingDest = objTaggingDest.ID_Other,
                                         Name_TaggingDest = objTaggingDest.Name_Other,
                                         ID_Parent_TaggingDest = objTaggingDest.ID_Parent_Other,
                                         Name_Parent_TaggingDest = objTaggingDest.Name_Parent_Other,
                                         Type_TaggingDest = objTaggingDest.Ontology,
                                         ID_TypedTag = objTaggingSource.ID_Object,
                                         Name_TypedTag = objTaggingSource.Name_Object
                                     }).ToList();

                    }

                }
                else
                {
                    objDBLevel_Tag.OList_ObjectRel.Clear();
                }
                
            }

            return OItem_Result_Source;
        }

        public List<clsOntologyItem> OList_Tags()
        {
            var objOList_Tags = objDBLevel_Tag.OList_ObjectRel.Select(t =>
                new clsOntologyItem
                {
                    GUID = t.ID_Other,
                    Name = t.Name_Other,
                    GUID_Parent = t.ID_Parent_Other,
                    Type = t.Ontology
                }).ToList();

            return objOList_Tags;
        }

        public clsOntologyItem FilterBySemanticFilter(SemanticFilterType semanticFilterType, clsOntologyItem OItem_Class, clsOntologyItem OItem_RelationType, clsOntologyItem OItem_Direction, clsOntologyItem OItem_Object = null)
        {
            var oItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            this.semanticFilterType = semanticFilterType;

            objOItem_SFilterClass = OItem_Class;
            objOItem_SFilterDirection = OItem_Direction;
            objOItem_SFilterRelationType = OItem_RelationType;
            objOItem_SFilterObject = OItem_Object;

            List<clsObjectRel> search;

            if (objOItem_SFilterDirection.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID)
            {
                search = new List<clsObjectRel> { new clsObjectRel
                        {
                            ID_Other = objOItem_SFilterObject != null ? objOItem_SFilterObject.GUID : null,
                            ID_Parent_Other = objOItem_SFilterObject == null ? objOItem_SFilterClass.GUID : null ,
                            ID_RelationType = objOItem_SFilterRelationType.GUID
                        } };
            }
            else
            {
                search = new List<clsObjectRel> { new clsObjectRel
                        {
                            ID_Object = objOItem_SFilterObject != null ? objOItem_SFilterObject.GUID : null,
                            ID_Parent_Object = objOItem_SFilterObject == null ? objOItem_SFilterClass.GUID : null ,
                            ID_RelationType = objOItem_SFilterRelationType.GUID
                        } };
            }

            oItem_Result = objDBLevel_SemFilter.get_Data_ObjectRel(search, boolIDs: true);
            if (oItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                switch (this.semanticFilterType)
                {
                    case SemanticFilterType.TaggingSource:
                        if (objOItem_SFilterDirection.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID)
                        {
                            TypedTags_SourcesSemFilter = (from objTypedTags in TypedTags_Sources
                                                          join objFilter in objDBLevel_SemFilter.OList_ObjectRel_ID on objTypedTags.ID_TaggingSource equals objFilter.ID_Object
                                                          select objTypedTags).ToList();
                        }
                        else
                        {
                            TypedTags_SourcesSemFilter = (from objTypedTags in TypedTags_Sources
                                                          join objFilter in objDBLevel_SemFilter.OList_ObjectRel_ID on objTypedTags.ID_TaggingSource equals objFilter.ID_Other
                                                          select objTypedTags).ToList();
                        }
                        
                        break;
                    case SemanticFilterType.TaggingDest:
                        if (objOItem_SFilterDirection.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID)
                        {
                            TypedTags_SourcesSemFilter = (from objTypedTags in TypedTags_Sources
                                                          join objFilter in objDBLevel_SemFilter.OList_ObjectRel_ID on objTypedTags.ID_TaggingDest equals objFilter.ID_Object
                                                          select objTypedTags).ToList();
                        }
                        else
                        {
                            TypedTags_SourcesSemFilter = (from objTypedTags in TypedTags_Sources
                                                          join objFilter in objDBLevel_SemFilter.OList_ObjectRel_ID on objTypedTags.ID_TaggingDest equals objFilter.ID_Other
                                                          select objTypedTags).ToList();
                        }
                        break;

                    case SemanticFilterType.TypedTag:
                        if (objOItem_SFilterDirection.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID)
                        {
                            TypedTags_SourcesSemFilter = (from objTypedTags in TypedTags_Sources
                                                          join objFilter in objDBLevel_SemFilter.OList_ObjectRel_ID on objTypedTags.ID_TypedTag equals objFilter.ID_Object
                                                          select objTypedTags).ToList();
                        }
                        else
                        {
                            TypedTags_SourcesSemFilter = (from objTypedTags in TypedTags_Sources
                                                          join objFilter in objDBLevel_SemFilter.OList_ObjectRel_ID on objTypedTags.ID_TypedTag equals objFilter.ID_Other
                                                          select objTypedTags).ToList();
                        }
                        break;
                }
            }
            

            return oItem_Result;
        }

        private clsOntologyItem GetSubData_SecurityRel()
        {

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objOList_Search_Security = new List<clsObjectRel> 
            {
                new clsObjectRel 
                {
                    ID_Parent_Object = objLocalConfig.OItem_class_typed_tag.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_group.GUID 
                },
                new clsObjectRel
                {
                    ID_Parent_Object = objLocalConfig.OItem_class_typed_tag.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_user.GUID 
                }
            };

            objOItem_Result = objDBLevel_SecurityRel.get_Data_ObjectRel(objOList_Search_Security, boolIDs: false);

            return objOItem_Result;
        }

        public clsDataWork_Tagging(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        public clsDataWork_Tagging(clsGlobals Globals, clsOntologyItem OItem_User, clsOntologyItem OItem_Group)
        {
            objLocalConfig = new clsLocalConfig(Globals);
            objLocalConfig.OItem_User = OItem_User;
            objLocalConfig.OItem_Group = OItem_Group;
            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_SecurityRel = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_TaggingSource = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Tag = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Classes = new clsDBLevel(objLocalConfig.Globals);

            objDBLevel_SemFilter = new clsDBLevel(objLocalConfig.Globals);

            OItem_Result_Source = objLocalConfig.Globals.LState_Nothing.Clone();

            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
        }

        
    }
}
