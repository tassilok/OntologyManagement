using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Typed_Tagging_Module
{
    public class clsDataWork_Tagging
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_SecurityRel;

        private clsDBLevel objDBLevel_TaggingSource;

        private clsDBLevel objDBLevel_Tag;

        private clsOntologyItem objOItem_TaggingSource;


        private clsRelationConfig objRelationConfig;

        public List<clsTypedTag> TypedTags { get; set; }



        public void AddTag(clsOntologyItem OItem_Tag, clsOntologyItem OItem_TaggingSource, clsOntologyItem OItem_TaggingDest)
        {
            objDBLevel_TaggingSource.OList_ObjectRel.Add(objRelationConfig.Rel_ObjectRelation(OItem_Tag, OItem_TaggingSource, objLocalConfig.OItem_relationtype_is_tagging));
            objDBLevel_Tag.OList_ObjectRel.Add(objRelationConfig.Rel_ObjectRelation(OItem_Tag,OItem_TaggingDest, objLocalConfig.OItem_relationtype_belonging_tag));
            objDBLevel_SecurityRel.OList_ObjectRel.Add(objRelationConfig.Rel_ObjectRelation(OItem_Tag, objLocalConfig.OItem_User, objLocalConfig.OItem_relationtype_belongs_to));
            objDBLevel_SecurityRel.OList_ObjectRel.Add(objRelationConfig.Rel_ObjectRelation(OItem_Tag, objLocalConfig.OItem_Group, objLocalConfig.OItem_relationtype_belongs_to));

        }

        public clsOntologyItem GetTagsOfTaggingSource(clsOntologyItem OItem_TaggingSource)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            objOItem_TaggingSource = OItem_TaggingSource;

            objOItem_Result = GetSubData_SecurityRel();

            TypedTags = new List<clsTypedTag>();

            var objOList_Search_TaggingSource = new List<clsObjectRel> 
            {
                new clsObjectRel 
                {
                    ID_Other = objOItem_TaggingSource.GUID,
                    ID_Parent_Other =  objOItem_TaggingSource.GUID_Parent, 
                    ID_RelationType = objLocalConfig.OItem_relationtype_is_tagging.GUID,
                    ID_Parent_Object = objLocalConfig.OItem_class_typed_tag.GUID 
                } 
            };

            objOItem_Result = objDBLevel_TaggingSource.get_Data_ObjectRel(objOList_Search_TaggingSource, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                
                var objOList_TaggingSource = (from objUser in objDBLevel_SecurityRel.OList_ObjectRel.Where(u => u.ID_Parent_Other == objLocalConfig.OItem_class_user.GUID).ToList()
                                                join objGroup in objDBLevel_SecurityRel.OList_ObjectRel.Where(u => u.ID_Parent_Other == objLocalConfig.OItem_class_group.GUID).ToList() on objUser.ID_Object equals objGroup.ID_Object
                                                join objTaggingSource in objDBLevel_TaggingSource.OList_ObjectRel on objGroup.ID_Object equals objTaggingSource.ID_Object
                                                select objTaggingSource).ToList();

                if (objOList_TaggingSource.Any())
                {
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
                    

                    objOItem_Result = objDBLevel_Tag.get_Data_ObjectRel(objOList_Search_Tag, boolIDs: false);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        TypedTags = (from objTaggingSource in objOList_TaggingSource
                                     join objTaggingDest in objDBLevel_Tag.OList_ObjectRel on objTaggingSource.ID_Object equals objTaggingDest.ID_Object
                                     select new clsTypedTag
                                     {
                                         ID_Group = objLocalConfig.OItem_Group.GUID,
                                         Name_Group = objLocalConfig.OItem_Group.Name,
                                         ID_User = objLocalConfig.OItem_User.GUID,
                                         Name_user = objLocalConfig.OItem_User.Name,
                                         ID_TaggingSource = objTaggingSource.ID_Other,
                                         Name_TaggingSource = objTaggingSource.Name_Other,
                                         ID_TaggingDest = objTaggingDest.ID_Other,
                                         Name_TaggingDest = objTaggingDest.Name_Other,
                                         ID_Parent_TaggingDest = objTaggingDest.ID_Parent_Other,
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

            return objOItem_Result;
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
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
        }
    }
}
