using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using Media_Viewer_Module;

namespace ImageList_Module
{

    public class clsDataWork_Images
    {
        private clsLocalConfig objLocalConfig;
        private clsOntologyItem objOItem_ImageList;

        private clsDBLevel objDBLevel_Images;
        private clsDBLevel objDBLevel_IsRoot;
        private clsDBLevel objDBLevel_KindOfOntologies;
        private clsDBLevel objDBLevel_Ref;

        public clsOntologyItem objOItem_Result_IsRoot { get; set; }
        public clsOntologyItem objOItem_Result_KindOfOntology { get; set; }
        public clsOntologyItem objOItem_Result_Images { get; set; }
        public clsOntologyItem objOItem_Result_ImageData { get; set; }
        public clsOntologyItem objOItem_Result_Ref { get; set; }

        private Media_Viewer_Module.clsDataWork_Images objDataWork_ImageData;
        private clsMediaItems objMediaItems;

        public List<clsImageOfImageList> ImageList { get; set; }

        public clsOntologyItem GetData_ImagesOfImageList(clsOntologyItem OItem_ImageList)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            objOItem_ImageList = OItem_ImageList;

            objOItem_Result_IsRoot = objLocalConfig.Globals.LState_Nothing.Clone();
            objOItem_Result_KindOfOntology = objLocalConfig.Globals.LState_Nothing.Clone();
            objOItem_Result_Images = objLocalConfig.Globals.LState_Nothing.Clone();
            objOItem_Result_ImageData = objLocalConfig.Globals.LState_Nothing.Clone();

            GetSubData_Images();
            objOItem_Result = objOItem_Result_Images;
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                GetSubData_IsRoot();
                objOItem_Result = objOItem_Result_IsRoot;

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    GetSubData_KindOfOntologies();
                    objOItem_Result = objOItem_Result_KindOfOntology;

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        GetSubData_Reference();
                        objOItem_Result = objOItem_Result_Ref;

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            ImageList = (from objImage in objDBLevel_Images.OList_ObjectRel
                                         join objIsRoot in objDBLevel_IsRoot.OList_ObjectAtt on objImage.ID_Other equals objIsRoot.ID_Object into objIsRoots
                                         from objIsRoot in objIsRoots.DefaultIfEmpty()
                                         join objKindOfOntologies in objDBLevel_KindOfOntologies.OList_ObjectRel on objImage.ID_Other equals objKindOfOntologies.ID_Object into objKindsOfOntologies
                                         from objKindOfOntologies in objKindsOfOntologies.DefaultIfEmpty()
                                         join objRef in objDBLevel_Ref.OList_ObjectRel on objImage.ID_Other equals objRef.ID_Object into objRefs
                                         from objRef in objRefs.DefaultIfEmpty()
                                         select new clsImageOfImageList
                                         {
                                             ID_Image = objImage.ID_Other,
                                             Name_Image = objImage.Name_Other,
                                             ID_Attribute_IsRoot = objIsRoot != null ? objIsRoot.ID_Attribute : null,
                                             IsRoot = objIsRoot != null ? (bool)objIsRoot.Val_Bit : false,
                                             ID_KindOfOntology = objKindOfOntologies != null ? objKindOfOntologies.ID_Other : null,
                                             Name_KindOfOntology = objKindOfOntologies != null ? objKindOfOntologies.Name_Other : null,
                                             ID_Ref = objRef != null ? objRef.ID_Other : null,
                                             Name_Ref = objRef != null ? objRef.Name_Other : null,
                                             ID_Parent_Ref = objRef != null ? objRef.ID_Parent_Other : null,
                                             Type_Ref = objRef != null ? objRef.Ontology : null,
                                             ImageID = (long)objImage.OrderID
                                         }).ToList();

                            GetSubData_ImageData();

                            objOItem_Result_Images = objOItem_Result_ImageData;
                        }
                    }
                    

                   
                }
                
            }


            return objOItem_Result;
        }

        public void GetSubData_IsRoot()
        {
            objOItem_Result_IsRoot = objLocalConfig.Globals.LState_Nothing.Clone();

            if (objDBLevel_Images.OList_ObjectRel.Any())
            {
                List<clsObjectAtt> OARel_IsRoot;
                if (objDBLevel_Images.OList_ObjectRel.Count < 500)
                {
                    OARel_IsRoot = objDBLevel_Images.OList_ObjectRel.Select(i => new clsObjectAtt
                    {
                        ID_AttributeType = objLocalConfig.OItem_attributetype_is_root.GUID,
                        ID_Object = i.ID_Other
                    }).ToList();
                }
                else
                {
                    OARel_IsRoot = new List<clsObjectAtt> { new clsObjectAtt {ID_AttributeType = objLocalConfig.OItem_attributetype_is_root.GUID,
                        ID_Class = objLocalConfig.OItem_class_images__image_lists_.GUID}};
                }

                objOItem_Result_IsRoot = objDBLevel_IsRoot.get_Data_ObjectAtt(OARel_IsRoot, boolIDs: false);

            }
            else
            {
                objOItem_Result_IsRoot = objLocalConfig.Globals.LState_Success.Clone();
            }
        }

        public void GetSubData_KindOfOntologies()
        {
            objOItem_Result_KindOfOntology = objLocalConfig.Globals.LState_Nothing.Clone();

            if (objDBLevel_Images.OList_ObjectRel.Any())
            {
                List<clsObjectRel> ORel_KindOfOntology;
                if (objDBLevel_Images.OList_ObjectRel.Count < 500)
                {
                    ORel_KindOfOntology = objDBLevel_Images.OList_ObjectRel.Select(i => new clsObjectRel
                    {
                        ID_Object = i.ID_Other,
                        ID_RelationType = objLocalConfig.OItem_relationtype_reference_to.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_kindofontology.GUID
                    }).ToList();
                }
                else
                {
                    ORel_KindOfOntology = new List<clsObjectRel> { new clsObjectRel 
                    {
                        ID_Parent_Object = objLocalConfig.OItem_class_images__image_lists_.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_reference_to.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_kindofontology.GUID
                    }};
                }

                objOItem_Result_KindOfOntology = objDBLevel_KindOfOntologies.get_Data_ObjectRel(ORel_KindOfOntology, boolIDs: false);

            }
            else
            {
                objOItem_Result_KindOfOntology = objLocalConfig.Globals.LState_Success.Clone();
            }
        }

        public void GetSubData_Reference()
        {
            objOItem_Result_Ref = objLocalConfig.Globals.LState_Nothing.Clone();

            if (objDBLevel_Images.OList_ObjectRel.Any())
            {
                List<clsObjectRel> ORel_Ref;
                if (objDBLevel_Images.OList_ObjectRel.Count < 500)
                {
                    ORel_Ref = objDBLevel_Images.OList_ObjectRel.Select(i => new clsObjectRel
                    {
                        ID_Object = i.ID_Other,
                        ID_RelationType = objLocalConfig.OItem_relationtype_belonging_resource.GUID
                    }).ToList();
                }
                else
                {
                    ORel_Ref = new List<clsObjectRel> { new clsObjectRel 
                    {
                        ID_Parent_Object = objLocalConfig.OItem_class_images__image_lists_.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_belonging_resource.GUID
                    }};
                }

                objOItem_Result_Ref = objDBLevel_Ref.get_Data_ObjectRel(ORel_Ref, boolIDs: false);

            }
            else
            {
                objOItem_Result_Ref = objLocalConfig.Globals.LState_Success.Clone();
            }
        }

        public void GetSubData_Images()
        {
            objOItem_Result_Images = objLocalConfig.Globals.LState_Nothing.Clone();

            var objORel_Images = new List<clsObjectRel> { new clsObjectRel {ID_Object = objOItem_ImageList.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_images__image_lists_.GUID } };

            objOItem_Result_Images = objDBLevel_Images.get_Data_ObjectRel(objORel_Images, boolIDs: false);

        }


        public void GetSubData_ImageData()
        {
            objOItem_Result_ImageData = objLocalConfig.Globals.LState_Nothing.Clone();

            foreach (var image in ImageList)
            {
                objDataWork_ImageData.get_Images(new clsOntologyItem
                {
                    GUID = image.ID_Image,
                    Name = image.Name_Image,
                    GUID_Parent = objLocalConfig.OItem_class_images__image_lists_.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                }, false);

                while (!objDataWork_ImageData.Loaded) ;

                var objImageDatas = objDataWork_ImageData.ItemList;

                var objOItem_Result = GetSubData_ImageFile(image, objImageDatas);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                {
                    objOItem_Result_ImageData = objOItem_Result;
                    break;
                }
            }

            if (objOItem_Result_ImageData.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                objOItem_Result_ImageData = objLocalConfig.Globals.LState_Success.Clone();
            }
        }

        public clsOntologyItem GetSubData_ImageFile(clsImageOfImageList objImage, List<clsMultiMediaItem> mediaItems)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            if (mediaItems.Any())
            {
                objImage.ImageData = objMediaItems.Get_ImageFile(new clsOntologyItem
                {
                    GUID = mediaItems.First().ID_File,
                    Name = mediaItems.First().Name_File,
                    GUID_Parent = mediaItems.First().ID_Parent_File,
                    Type = objLocalConfig.Globals.Type_Object
                });


            }

            return objOItem_Result;
        }

        public clsDataWork_Images(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_Images = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_IsRoot = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_KindOfOntologies = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Ref = new clsDBLevel(objLocalConfig.Globals);

            objDataWork_ImageData = new Media_Viewer_Module.clsDataWork_Images(objLocalConfig.Globals);
            objMediaItems = new clsMediaItems(objLocalConfig.Globals);
        }

    }
}
