using Ontology_Module;
using OntologyClasses.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Filesystem_Module;

namespace Media_Web_Module
{
    [Flags]
    public enum LoadSubResult
    {
        Extensions = 1,
        MediaFiles = 2,
        RefItems = 4
    }

    [Flags]
    public enum LoadResult
    {
        Extensions = 1,
        MediaFiles = 2,
        RefItems = 4
    }
    public class clsDataWork_MediaWebModule
    {
        private clsLocalConfig objLocalConfig;

        private Thread threadMediaItems;
        private Thread threadFiles;
        private Thread threadRefs;

        public LoadResult LoadedItems { get; private set; }

        private clsDBLevel objDBLevel_Extensions;
        private clsDBLevel objDBLevel_Files;
        private clsDBLevel objDBLevel_Blob;
        private clsDBLevel objDBLevel_RefsL1;
        private clsDBLevel objDBLevel_RefsL2;

        private clsFileWork objFileWork;

        private delegate void LoadedSubItems(LoadSubResult loadResult, clsOntologyItem OItem_Result);
        private event LoadedSubItems loadedSubItems;

        public delegate void LoadItems(LoadResult loadResult, clsOntologyItem OItem_Result);
        public event LoadItems loadItems;

        public List<clsOntologyItem> MediaExtensions { get; private set; }
        public List<clsFileSystemObject> MediaFiles
        {
            get;
            private set;
        }

        public clsLocalConfig LocalConfig 
        {
            get { return objLocalConfig; }
        }

        public void GetBaseData()
        {
            loadedSubItems += clsDataWork_MediaWebModule_loadedSubItems;
            threadMediaItems = new Thread(ThreadGetBaseData);
            threadMediaItems.Start();
        }

        public void GetFiles()
        {
            loadedSubItems += clsDataWork_MediaWebModule_loadedSubItems;
            threadFiles = new Thread(ThreadGetFiles);
            threadFiles.Start();
        }

        public void GetRefs()
        {
            loadedSubItems += clsDataWork_MediaWebModule_loadedSubItems;
            threadRefs = new Thread(ThreadGetRefs);
            threadRefs.Start();
        }

        private void ThreadGetRefs(object obj)
        {
            GetSubData_Refs();
        }

        private void ThreadGetFiles()
        {
            GetSubData_Files();
        }

        void clsDataWork_MediaWebModule_loadedSubItems(LoadSubResult loadResult, clsOntologyItem OItem_Result)
        {
            if (loadItems != null)
            {
                if (loadResult == LoadSubResult.Extensions)
                {
                    MediaExtensions = new List<clsOntologyItem>();
                    if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        MediaExtensions = objDBLevel_Extensions.OList_ObjectRel.Select(ext => new clsOntologyItem
                        {
                            GUID = ext.ID_Other,
                            Name = ext.Name_Other,
                            GUID_Parent = ext.ID_Parent_Other,
                            Type = ext.Ontology
                        }).ToList();
                    }

                    LoadedItems |= LoadResult.Extensions;
                    loadItems(LoadResult.Extensions, OItem_Result);
                }
                else if (loadResult == LoadSubResult.MediaFiles)
                {
                    if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        MediaFiles = new List<clsFileSystemObject>();

                        MediaFiles = (from objFile in objDBLevel_Files.OList_Objects
                                      join objBlob in objDBLevel_Blob.OList_ObjectAtt on objFile.GUID equals objBlob.ID_Object into objBlobs
                                      from objBlob in objBlobs.DefaultIfEmpty()
                                      select new clsFileSystemObject
                                      {
                                          ID_FileSystemObject = objFile.GUID,
                                          Name_FileSystemObject = objFile.Name,
                                          IsBlob = objBlob != null ? (bool)objBlob.Val_Bit : false,
                                          ID_Parent_FileSystemObject = objFile.GUID_Parent,
                                          Name_Parent_FileSystemObject = objFileWork.LocalConfig.OItem_Type_File.Name
                                      }).ToList();

                    }
                    LoadedItems |= LoadResult.MediaFiles;
                    loadItems(LoadResult.MediaFiles, OItem_Result);
                }
                else if (loadResult == LoadSubResult.RefItems)
                {

                    LoadedItems |= LoadResult.RefItems;
                    loadItems(LoadResult.RefItems, OItem_Result);
                }
                
            }
        }

        private void ThreadGetBaseData()
        {
            GetSubData_Extensions();
        }

        private void GetSubData_Extensions()
        {
            var result = objLocalConfig.Globals.LState_Success.Clone();

            var searchExtensions = new List<clsObjectRel> { new clsObjectRel {ID_Object = objLocalConfig.OItem_object_media_files.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_is_of_type.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_extensions.GUID } };

            result = objDBLevel_Extensions.get_Data_ObjectRel(searchExtensions, boolIDs: false);

            loadedSubItems(LoadSubResult.Extensions, result);
        }

        private void GetSubData_Refs()
        {
            var result = objLocalConfig.Globals.LState_Success.Clone();

            var searchExtensions = new List<clsObjectRel> { new clsObjectRel {ID_Parent_Object = objLocalConfig.OItem_class_file.GUID,
            ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID} };

            result = objDBLevel_Extensions.get_Data_ObjectRel(searchExtensions, boolIDs: false);

            loadedSubItems(LoadSubResult.Extensions, result);
        }

        private void GetSubData_Files()
        {
            var result = objLocalConfig.Globals.LState_Success.Clone();

            var searchFiles = objDBLevel_Extensions.OList_ObjectRel.Select(ext => new clsOntologyItem
            {
                Name = "." + ext.Name_Other,
                GUID_Parent = objLocalConfig.OItem_class_file.GUID
            }).ToList();

            result = objDBLevel_Files.get_Data_Objects(searchFiles);

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                List<clsObjectAtt> searchBlob;
                if (objDBLevel_Files.OList_Objects.Count > 1000)
                {
                    searchBlob = new List<clsObjectAtt> { new clsObjectAtt {ID_Class = objLocalConfig.OItem_class_file.GUID,
                        ID_AttributeType = objFileWork.LocalConfig.OItem_Attribute_Blob.GUID } };
                }
                else
                {
                    searchBlob = objDBLevel_Files.OList_Objects.Select ( file => new clsObjectAtt { ID_Object = file.GUID,
                        ID_AttributeType = objFileWork.LocalConfig.OItem_Attribute_Blob.GUID } ).ToList();

                }


                if (searchBlob.Any())
                {
                    result = objDBLevel_Blob.get_Data_ObjectAtt(searchBlob, boolIDs: false);
                }
                else
                {
                    objDBLevel_Blob.OList_ObjectAtt.Clear();
                }
                
            }

            loadedSubItems(LoadSubResult.MediaFiles, result);
        }

        public clsDataWork_MediaWebModule(clsLocalConfig localConfig)
        {
            objLocalConfig = localConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_Extensions = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Files = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Blob = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RefsL1 = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RefsL2 = new clsDBLevel(objLocalConfig.Globals);

            objFileWork = new clsFileWork(objLocalConfig.Globals);
        }

    }
}
