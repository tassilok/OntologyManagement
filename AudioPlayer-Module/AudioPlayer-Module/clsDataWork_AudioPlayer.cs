using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace AudioPlayer_Module
{
    public class clsDataWork_AudioPlayer
    {
        private clsLocalConfig objLocalConfig;

        private List<clsOntologyItem> OList_MediaItems;

        public List<clsReferencedMediaItem> OList_MultimediaItemsRef { get; set; }

        public clsMultimediaItem MultiMediaItem_Current { get; set; }

        public List<clsMultimediaItem> OList_MultiMediaItems { get; set; }

        private clsDBLevel objDBLevel_MediaItems;
        private clsDBLevel objDBLevel_FilesOfMediaItems;
        private clsDBLevel objDBLevel_Created;
        private clsDBLevel objDBLevel_DataTypes;
        private clsDBLevel objDBLevel_RelationTypes;
        private clsDBLevel objDBLevel_Classes;
        private clsDBLevel objDBLevel_RefItems;

        public clsOntologyItem GetData_MediaItemsAndRefs()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            

            OList_MultiMediaItems = new List<clsMultimediaItem>();

            objOItem_Result = GetSubData_001_MediaItemsOfRef();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
             
             
                        OList_MultimediaItemsRef = (from objMultimediaItem in objDBLevel_MediaItems.OList_ObjectRel
                                                    join objClass in objDBLevel_Classes.OList_Classes on objMultimediaItem.ID_Parent_Other equals objClass.GUID into objClasses
                                                    from objClass in objClasses.DefaultIfEmpty()
                                                    join objDataType in objDBLevel_DataTypes.OList_DataTypes on objMultimediaItem.ID_Parent_Other equals objDataType.GUID into objDataTypes
                                                    from objDataType in objDataTypes.DefaultIfEmpty()
                                                     select new clsReferencedMediaItem { ID_Item = objMultimediaItem.ID_Object,
                                                         Name_Item = objMultimediaItem.Name_Object,
                                                         ID_Parent_Item = objMultimediaItem.ID_Parent_Object,
                                                         OrderID = objMultimediaItem.OrderID,
                                                         CountBookmark = 0,
                                                     ID_Ref = objMultimediaItem.ID_Other,
                                                     Name_Ref = objMultimediaItem.Name_Other,
                                                     ID_Parent_Ref = objMultimediaItem.ID_Parent_Other,
                                                     Name_Parent_Ref = objClass != null ? objClass.Name : objDataType != null ? objDataType.Name : null,
                                                     Ontology = objMultimediaItem.Ontology}).ToList();

             
            }

            return objOItem_Result;
        }

        public clsOntologyItem GetData_MediaItem(List<clsOntologyItem> OList_MediaItems)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            this.OList_MediaItems = OList_MediaItems;

            objOItem_Result = GetSubData_002_FilesOfMediaItems();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = GetSubData_003_CreatedAttribute();

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    OList_MultiMediaItems = (from objMediaItem in OList_MediaItems
                                             join objFile in objDBLevel_FilesOfMediaItems.OList_ObjectRel.Where(f => f.Name_Other.ToLower().EndsWith(objLocalConfig.OItem_object_aiff.Name.ToLower()) ||
                                                                                                                     f.Name_Other.ToLower().EndsWith(objLocalConfig.OItem_object_mp3.Name.ToLower()) ||
                                                                                                                     f.Name_Other.ToLower().EndsWith(objLocalConfig.OItem_object_wav.Name.ToLower())).ToList() on objMediaItem.GUID equals objFile.ID_Object
                                             join objCreated in objDBLevel_Created.OList_ObjectAtt on objFile.ID_Other equals objCreated.ID_Object into objCreatedList
                                             from objCreated in objCreatedList.DefaultIfEmpty()
                                             select new clsMultimediaItem
                                             {
                                                 ID_Item = objMediaItem.GUID,
                                                 Name_Item = objMediaItem.Name,
                                                 ID_Parent_Item = objMediaItem.GUID_Parent,
                                                 ID_File = objFile.ID_Other,
                                                 Name_File = objFile.Name_Other,
                                                 ID_Parent_File = objFile.ID_Parent_Other,
                                                 OACreate = objCreated,
                                                 OrderID = 0,
                                                 CountBookmark = 0
                                             }).ToList();
                }
            }
            
            return objOItem_Result;
        }

        public List<clsOntologyItem> GetMediaItemsRelated(List<clsOntologyItem> OList_Ref)
        {
            var searchMediaItems = OList_Ref.Select(mi => new clsObjectRel
            {
                ID_Object = mi.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_media_item.GUID
            }).ToList();

            var olist_MediaItems = new List<clsOntologyItem>();

            var objOItem_Result = objDBLevel_RefItems.get_Data_ObjectRel(searchMediaItems, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                olist_MediaItems.AddRange(objDBLevel_RefItems.OList_ObjectRel.Select(refitem => new clsOntologyItem
                {
                    GUID = refitem.ID_Other,
                    Name = refitem.Name_Other,
                    GUID_Parent = refitem.ID_Parent_Other,
                    Type = objLocalConfig.Globals.Type_Object
                }));

                searchMediaItems = OList_Ref.Select(mi => new clsObjectRel
                {
                    ID_Parent_Object = objLocalConfig.OItem_class_media_item.GUID,
                    ID_Other = mi.GUID
                }).ToList();

                objOItem_Result = objDBLevel_RefItems.get_Data_ObjectRel(searchMediaItems, boolIDs: false);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    olist_MediaItems.AddRange(objDBLevel_RefItems.OList_ObjectRel.Select(refitem => new clsOntologyItem
                    {
                        GUID = refitem.ID_Object,
                        Name = refitem.Name_Object,
                        GUID_Parent = refitem.ID_Parent_Object,
                        Type = objLocalConfig.Globals.Type_Object
                    }));
                }
                else
                {
                    olist_MediaItems = null;
                }

            }
            else
            {
                olist_MediaItems = null;
            }

            return olist_MediaItems;
        }

        private clsOntologyItem GetSubData_001_MediaItemsOfRef()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objORel_MediaItemsOfRef = new List<clsObjectRel> { new clsObjectRel { ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                ID_Parent_Object = objLocalConfig.OItem_class_media_item.GUID } };

            objOItem_Result = objDBLevel_MediaItems.get_Data_ObjectRel(objORel_MediaItemsOfRef, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = objDBLevel_Classes.get_Data_Classes();

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOItem_Result = objDBLevel_DataTypes.get_Data_DataTyps();

                    
                }
            }
            
            return objOItem_Result;
        }

        private clsOntologyItem GetSubData_002_FilesOfMediaItems()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            List<clsObjectRel> objORel_MediaItems_To_Files;

            if (OList_MediaItems != null)
            {
                objORel_MediaItems_To_Files = OList_MediaItems.Select(mi => new clsObjectRel { ID_Object = mi.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID,
                    ID_Parent_Other = objLocalConfig.objLocalConfig_File.OItem_Type_File.GUID }).ToList();

                
            }
            else
            {
                objORel_MediaItems_To_Files = objDBLevel_MediaItems.OList_ObjectRel.Select(mi => new clsObjectRel {
                    ID_Object = mi.ID_Object,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID,
                    ID_Parent_Other = objLocalConfig.objLocalConfig_File.OItem_Type_File.GUID
                } ).ToList();



            }

            if (objORel_MediaItems_To_Files.Any())
            {
                objOItem_Result = objDBLevel_FilesOfMediaItems.get_Data_ObjectRel(objORel_MediaItems_To_Files, boolIDs: false);
            }
            else
            {
                objDBLevel_FilesOfMediaItems.OList_ObjectRel.Clear();
            }
            
            return objOItem_Result;
        }

        private clsOntologyItem GetSubData_003_CreatedAttribute()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();


            var objORel_File_To_Attribute = objDBLevel_FilesOfMediaItems.OList_ObjectRel.Select(f => new clsObjectAtt
            {
                ID_Object = f.ID_Other,
                ID_AttributeType = objLocalConfig.objLocalConfig_File.OItem_Attribute_Datetimestamp__Create_.GUID
            }).ToList();

            if (objORel_File_To_Attribute.Any())
            {
                objOItem_Result = objDBLevel_Created.get_Data_ObjectAtt(objORel_File_To_Attribute, boolIDs: false);

            }
            else
            {
                objDBLevel_Created.OList_ObjectAtt.Clear();
            }
            

            return objOItem_Result;
        }

        public clsDataWork_AudioPlayer(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_FilesOfMediaItems = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_MediaItems = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Created = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_DataTypes = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Classes = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RelationTypes = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RefItems = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
