using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontolog_Module;
using OntologyClasses.BaseClasses;
using System.Threading;
using Log_Module;

namespace Version_Module
{
    
    public class clsDataWork_Versions
    {
        private clsLocalConfig objLocalConfig;
        private Log_Module.clsLocalConfig objLocalConfig_LogModule;
        private clsDataWork_LogEntry objDataWork_LogEntry;

        public clsOntologyItem OItem_Result_Versions { get; private set; }
        public clsOntologyItem OItem_Result_Versions_To_Refs { get; private set; }
        public clsOntologyItem OItem_Result_Versions__VersionNumbers { get; private set; }

        private clsDBLevel objDBLevel_Versions;
        private clsDBLevel objDBLevel_Refs_To_Versions;
        private clsDBLevel objDBLevel_Versions_To_Refs;
        private clsDBLevel objDBLevel_Version__VersionNumbers;
        private clsDBLevel objDBLevel_ClassesOfObjects;
        private clsDBLevel objDBLevel_Classes;
        private clsDBLevel objDBLevel_VersionsRef;

        public List<clsOntologyItem> OList_Versions { get; private set; }
        public List<clsObjectAtt> OList_Version__VersionNumbers { get; private set; }
        public List<clsObjectRel> OList_Versions_To_Refs { get; private set; }
        public List<clsObjectRel> OList_Refs_Versions_To_Classes { get; private set; }
        public List<clsObjectRel> OList_Refs_Versions_To_Objects { get; private set; }
        public List<clsObjectRel> OList_Refs_Versions_To_AttributeTypes { get; private set; }
        public List<clsObjectRel> OList_Refs_Versions_To_RelationTypes { get; private set; }

        public List<clsLogEntry> OList_Logentries { get; private set; }

        private List<clsOntologyItem> OList_Classes;
        private List<clsOntologyItem> OList_AttributeTypes;
        private List<clsOntologyItem> OList_RelationTypes;
        private List<clsOntologyItem> OList_Objects;

        private Thread objThread_Versions;
        private Thread objThread_Ref_To_Version;
        private Thread objThread_Version__VersionNumbers;

        public clsLocalConfig LocalConfig { get { return objLocalConfig; } }

        public TreeNode TreeNode_Root { get; private set; }
        public TreeNode TreeNode_AttributeTypes { get; private set; }
        public TreeNode TreeNode_RelationTypes { get; private set; }

        public void GetData_Version()
        {
            OItem_Result_Versions = objLocalConfig.Globals.LState_Nothing;
            var objOList_Versions = new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = objLocalConfig.OItem_type_developmentversion.GUID } };

            var objOItem_Result = objDBLevel_Versions.get_Data_Objects(objOList_Versions);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_Versions = objDBLevel_Versions.OList_Objects;
                OItem_Result_Versions = objLocalConfig.Globals.LState_Success;
            }
            else
            {
                OItem_Result_Versions = objLocalConfig.Globals.LState_Error;
            }

        }

        

        public void GetData_Ref_To_Version()
        {
            OItem_Result_Versions_To_Refs = objLocalConfig.Globals.LState_Nothing;

            var objOList_Ref_To_Version = new List<clsObjectRel> { new clsObjectRel { ID_Parent_Other = objLocalConfig.OItem_type_developmentversion.GUID, 
                                                                                      ID_RelationType = objLocalConfig.OItem_relationtype_isinstate.GUID } };
            objDBLevel_Refs_To_Versions.Sort = clsDBLevel.SortEnum.DESC_OrderID;

            var objOItem_Result = objDBLevel_Refs_To_Versions.get_Data_ObjectRel(objOList_Ref_To_Version, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var objOList_Versions_To_Refs = new List<clsObjectRel>
                    {
                        new clsObjectRel
                            {
                                ID_Parent_Object = objLocalConfig.OItem_type_developmentversion.GUID,
                                ID_RelationType = objLocalConfig.OItem_relationtype_belongsto.GUID
                            }
                    };

                objOItem_Result = objDBLevel_Versions_To_Refs.get_Data_ObjectRel(objOList_Versions_To_Refs,
                                                                                 boolIDs: false);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    OList_Versions_To_Refs = objDBLevel_Refs_To_Versions.OList_ObjectRel.Select(p => new clsObjectRel
                        {
                            ID_Object = p.ID_Other,
                            Name_Object =  p.Name_Other,
                            ID_Parent_Object = p.ID_Parent_Other,
                            ID_Other = p.ID_Object,
                            Name_Other = p.Name_Object,
                            ID_Parent_Other = p.ID_Parent_Object,
                            ID_RelationType = p.ID_RelationType,
                            OrderID = p.OrderID,
                            Ontology = p.Ontology,
                            ID_Direction = objLocalConfig.Globals.Direction_RightLeft.GUID
                        }).ToList();

                    OList_Versions_To_Refs.AddRange(
                        objDBLevel_Versions_To_Refs.OList_ObjectRel.Select(p => new clsObjectRel
                            {
                                ID_Object = p.ID_Object,
                                Name_Object = p.Name_Object,
                                ID_Parent_Object = p.ID_Parent_Object,
                                ID_Other = p.ID_Other,
                                Name_Other = p.Name_Other,
                                ID_Parent_Other = p.ID_Parent_Other,
                                ID_RelationType = p.ID_RelationType,
                                OrderID = p.OrderID,
                                Ontology = p.Ontology,
                                ID_Direction = objLocalConfig.Globals.Direction_LeftRight.GUID
                            }).ToList());
                    OItem_Result_Versions_To_Refs = objLocalConfig.Globals.LState_Success;

                }
                else
                {
                    OItem_Result_Versions_To_Refs = objLocalConfig.Globals.LState_Error;
                }
                
            }
            else
            {
                OItem_Result_Versions_To_Refs = objLocalConfig.Globals.LState_Error;
            }
            
        }

        public void GetData_VersionNumbers()
        {
            OItem_Result_Versions__VersionNumbers = objLocalConfig.Globals.LState_Nothing;

            var objOAL_Versions__VersionNumbers = new List<clsObjectAtt> { new clsObjectAtt { ID_AttributeType = objLocalConfig.OItem_attribute_major.GUID, 
                                                                                               ID_Class = objLocalConfig.OItem_type_developmentversion.GUID },
                                                                            new clsObjectAtt { ID_AttributeType = objLocalConfig.OItem_attribute_minor.GUID, 
                                                                                               ID_Class = objLocalConfig.OItem_type_developmentversion.GUID },
                                                                            new clsObjectAtt { ID_AttributeType = objLocalConfig.OItem_attribute_build.GUID, 
                                                                                               ID_Class = objLocalConfig.OItem_type_developmentversion.GUID },
                                                                            new clsObjectAtt { ID_AttributeType = objLocalConfig.OItem_attribute_revision.GUID, 
                                                                                               ID_Class = objLocalConfig.OItem_type_developmentversion.GUID } };

            var objOItem_Result = objDBLevel_Version__VersionNumbers.get_Data_ObjectAtt(objOAL_Versions__VersionNumbers, boolIDs: false);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_Version__VersionNumbers = objDBLevel_Version__VersionNumbers.OList_ObjectAtt;
                OItem_Result_Versions__VersionNumbers = objOItem_Result;
            }
            else
            {
                OItem_Result_Versions__VersionNumbers = objLocalConfig.Globals.LState_Error;
            }

        }

        public clsDataWork_Versions(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            initialize();
        }

        public clsOntologyItem GetData_VersionDetails(bool boolAsynchronous=true)
        {

            var objOItem_Result = objLocalConfig.Globals.LState_Success;
            OItem_Result_Versions__VersionNumbers = objLocalConfig.Globals.LState_Nothing;

            
            try
            {
                objThread_Version__VersionNumbers.Abort();
            }
            catch (Exception)
            {
                
                
            }

            if (boolAsynchronous)
            {
                objThread_Version__VersionNumbers = new Thread(GetData_Version);
                objThread_Versions = new Thread(GetData_Version);    
            }
            else
            {
                objOItem_Result = objLocalConfig.Globals.LState_Error;
                if (OItem_Result_Versions_To_Refs.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    GetData_VersionNumbers();
                    if (OItem_Result_Versions__VersionNumbers.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objOItem_Result = objLocalConfig.Globals.LState_Success;
                    }
                }
            }

            return objOItem_Result;
        }

        public clsOntologyItem GetData_LogEntries(clsOntologyItem OItem_Ref)
        {


            var objOItem_Result = objLocalConfig.Globals.LState_Success;
            if (OItem_Result_Versions_To_Refs.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_Logentries = objDataWork_LogEntry.get_Data_LogEntryOfRef(OItem_Ref);
                if (OList_Logentries == null)
                    objOItem_Result = objLocalConfig.Globals.LState_Error;

            }
            return objOItem_Result;
        }

        public List<clsVersion> GetVersions(clsOntologyItem OItem_Ref)
        {
            List<clsVersion> objVersions = null;

            if (OItem_Result_Versions_To_Refs.GUID == objLocalConfig.Globals.LState_Success.GUID &&
                OItem_Result_Versions__VersionNumbers.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var objVersionsOfRef = OList_Versions_To_Refs.Where(p => p.ID_Other == OItem_Ref.GUID).ToList();

                var objLogentriesOfVersions =
                    objVersionsOfRef.Select(
                        p =>
                        new
                            {
                                ID_Version = p.ID_Object,
                                LogEntries =
                            objDataWork_LogEntry.get_Data_LogEntryOfRef(new clsOntologyItem
                                {
                                    GUID = p.ID_Object,
                                    Name = p.Name_Object,
                                    GUID_Parent = p.ID_Parent_Object,
                                    Type = p.Ontology
                                })
                            }).ToList();

                objVersions = (from objVersion in objVersionsOfRef
                                   join objLogentry in objLogentriesOfVersions on objVersion.ID_Object equals
                                       objLogentry.ID_Version
                                   join objVersionMajor in
                                       OList_Version__VersionNumbers.Where(
                                           p => p.ID_AttributeType == objLocalConfig.OItem_attribute_major.GUID) on
                                       objVersion.ID_Object equals objVersionMajor.ID_Object
                                   join objVersionMinor in
                                       OList_Version__VersionNumbers.Where(
                                           p => p.ID_AttributeType == objLocalConfig.OItem_attribute_minor.GUID) on
                                       objVersion.ID_Object equals objVersionMinor.ID_Object
                                   join objVersionBuild in
                                       OList_Version__VersionNumbers.Where(
                                           p => p.ID_AttributeType == objLocalConfig.OItem_attribute_build.GUID) on
                                       objVersion.ID_Object equals objVersionBuild.ID_Object
                                   join objVersionRevision in
                                       OList_Version__VersionNumbers.Where(
                                           p => p.ID_AttributeType == objLocalConfig.OItem_attribute_revision.GUID) on
                                       objVersion.ID_Object equals objVersionRevision.ID_Object
                                   select new clsVersion
                                       {
                                           ID_Attribute_Major = objVersionMajor.ID_Attribute,
                                           Major = objVersionMajor.Val_Lng,
                                           ID_Attribute_Minor = objVersionMinor.ID_Attribute,
                                           Minor = objVersionMinor.Val_Lng,
                                           ID_Attribute_Build = objVersionBuild.ID_Attribute,
                                           Build = objVersionBuild.Val_Lng,
                                           ID_Attribute_Revision = objVersionRevision.ID_Attribute,
                                           Revision = objVersionRevision.Val_Lng,
                                           ID_Attribute_DateTimeStamp = objLogentry != null ? objLogentry.LogEntries.Any() ? objLogentry.LogEntries.First().ID_Attribute_DateTimeStamp : null : null,
                                           DateTimeStamp = objLogentry != null ? objLogentry.LogEntries.Any() ? objLogentry.LogEntries.First().DateTimeStamp : null : null,
                                           ID_Attribute_Message = objLogentry != null ? objLogentry.LogEntries.Any() ? objLogentry.LogEntries.First().ID_Attribute_Message : null : null,
                                           Message = objLogentry != null ? objLogentry.LogEntries.Any() ? objLogentry.LogEntries.First().Message : null : null,
                                           ID_Logentry = objLogentry != null ? objLogentry.LogEntries.Any() ? objLogentry.LogEntries.First().ID_LogEntry : null : null,
                                           Name_Logentry = objLogentry != null ? objLogentry.LogEntries.Any() ? objLogentry.LogEntries.First().Name_LogEntry : null : null,
                                           ID_Logstate = objLogentry != null ? objLogentry.LogEntries.Any() ? objLogentry.LogEntries.First().ID_LogState : null : null,
                                           Name_Logstate = objLogentry != null ? objLogentry.LogEntries.Any() ? objLogentry.LogEntries.First().Name_LogState : null : null,
                                           ID_User = objLogentry != null ? objLogentry.LogEntries.Any() ? objLogentry.LogEntries.First().ID_User : null : null,
                                           Name_User = objLogentry != null ? objLogentry.LogEntries.Any() ? objLogentry.LogEntries.First().Name_User : null : null,
                                           ID_Version =  objVersion.ID_Object, 
                                           Name_Version = objVersion.Name_Object,
                                           OrderID = objVersion.OrderID
                                       }).OrderByDescending(p => p.OrderID).ToList();
                

            }

            return objVersions;
        }

        public void GetData_RefTreeData(bool boolAsynchronous=true)
        {
          
   

            try
            {
                objThread_Ref_To_Version.Abort();
            }
            catch (Exception)
            {


            }

            OItem_Result_Versions_To_Refs = objLocalConfig.Globals.LState_Nothing;

            if (boolAsynchronous)
            {
            
                objThread_Ref_To_Version = new Thread(GetData_Ref_To_Version);    
                objThread_Ref_To_Version.Start();


            }
            else
            {
                GetData_Version();
                GetData_Ref_To_Version();

               
            }

            


        }

        public clsOntologyItem GetData_RefTree()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Error;
            if (OItem_Result_Versions_To_Refs != null)
            {
                if (OItem_Result_Versions_To_Refs.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    OList_Refs_Versions_To_AttributeTypes =
                        OList_Versions_To_Refs.Where(p => p.Ontology == objLocalConfig.Globals.Type_AttributeType).ToList();
                    OList_Refs_Versions_To_Classes =
                        OList_Versions_To_Refs.Where(p => p.Ontology == objLocalConfig.Globals.Type_Class).ToList();
                    OList_Refs_Versions_To_Objects =
                        OList_Versions_To_Refs.Where(p => p.Ontology == objLocalConfig.Globals.Type_Object).ToList().ToList();
                    OList_Refs_Versions_To_RelationTypes =
                        OList_Versions_To_Refs.Where(p => p.Ontology == objLocalConfig.Globals.Type_RelationType).ToList();
                    
                    TreeNode_Root = new TreeNode
                        {
                            Name = objLocalConfig.OItem_type_developmentversion.GUID,
                            Text = objLocalConfig.OItem_type_developmentversion.Name,
                            ImageIndex = objLocalConfig.ImageID_Root,
                            SelectedImageIndex = objLocalConfig.ImageID_Root
                        };

                    if (OList_Refs_Versions_To_AttributeTypes.Any())
                    {
                        TreeNode_AttributeTypes = new TreeNode
                            {
                                Name = objLocalConfig.Globals.Type_AttributeType,
                                Text = objLocalConfig.Globals.Type_AttributeType,
                                ImageIndex = objLocalConfig.ImageID_AttributeTypes,
                                SelectedImageIndex = objLocalConfig.ImageID_AttributeTypes
                            };
                    }

                    if (OList_Refs_Versions_To_RelationTypes.Any())
                    {
                        TreeNode_RelationTypes = new TreeNode
                            {
                                Name = objLocalConfig.Globals.Type_RelationType,
                                Text = objLocalConfig.Globals.Type_RelationType,
                                ImageIndex = objLocalConfig.ImageID_RelationTypes,
                                SelectedImageIndex = objLocalConfig.ImageID_RelationTypes
                            };
                    }


                    OList_AttributeTypes = OList_Refs_Versions_To_AttributeTypes.GroupBy(p => new { p.ID_Other, p.Name_Other, p.ID_Parent_Other, p.Ontology }).Select(p => new clsOntologyItem
                    {
                        GUID = p.Key.ID_Other,
                        Name = p.Key.Name_Other,
                        GUID_Parent = p.Key.ID_Parent_Other,
                        Type = p.Key.Ontology
                    }).OrderBy(p => p.Name).ToList();

                    OList_RelationTypes = OList_Refs_Versions_To_RelationTypes.GroupBy(p => new { p.ID_Other, p.Name_Other, p.ID_Parent_Other, p.Ontology }).Select(p => new clsOntologyItem
                    {
                        GUID = p.Key.ID_Other,
                        Name = p.Key.Name_Other,
                        GUID_Parent = p.Key.ID_Parent_Other,
                        Type = p.Key.Ontology
                    }).OrderBy(p => p.Name).ToList();

                    OList_Classes = OList_Refs_Versions_To_Classes.GroupBy(p => new { p.ID_Other, p.Name_Other, p.ID_Parent_Other, p.Ontology }).Select(p => new clsOntologyItem
                        {
                            GUID = p.Key.ID_Other,
                            Name = p.Key.Name_Other,
                            GUID_Parent = p.Key.ID_Parent_Other,
                            Type = p.Key.Ontology
                        }).OrderBy(p => p.Name).ToList();

                    OList_Objects = OList_Refs_Versions_To_Objects.GroupBy(p => new {p.ID_Other, p.Name_Other, p.ID_Parent_Other, p.Ontology}).ToList().Select(p => new clsOntologyItem
                        {
                            GUID = p.Key.ID_Other,
                            Name = p.Key.Name_Other,
                            GUID_Parent = p.Key.ID_Parent_Other,
                            Type = p.Key.Ontology
                        }).OrderBy(p => p.Name).ToList();


                    objOItem_Result =  GetObjectsAndClassesOfObjects();

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objOItem_Result = GetParentClasses();    
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            AddSubNodes(TreeNode_Root);
                        }
                    }



                    

                }
            }

            return objOItem_Result;
        }

        private void AddSubNodes(TreeNode objTreeNode_Parent)
        {
            string GUID_Parent;
            if (objTreeNode_Parent.Name == objLocalConfig.OItem_type_developmentversion.GUID)
            {
                GUID_Parent = null;
                
            }
            else
            {
                GUID_Parent = objTreeNode_Parent.Name;
                

            }

            

            foreach (var OItem_Class in OList_Classes.Where(p => p.GUID_Parent == GUID_Parent || p.GUID_Parent == (GUID_Parent ?? "")).ToList())
            {
                var objTreeNode_Child = objTreeNode_Parent.Nodes.Add(OItem_Class.GUID,
                                                                     OItem_Class.Name,
                                                                     objLocalConfig.ImageID_Closed,
                                                                     objLocalConfig.ImageID_Opened);
                AddSubNodes(objTreeNode_Child);
            }    
            var objOList_Objects = OList_Objects.Where(p => p.GUID_Parent == objTreeNode_Parent.Name).ToList();
            foreach (var objOItem_Object in objOList_Objects)
            {
                objTreeNode_Parent.Nodes.Add(objOItem_Object.GUID, objOItem_Object.Name, objLocalConfig.ImageID_Object,
                                             objLocalConfig.ImageID_Object);
            }
            
        }

        private clsOntologyItem GetObjectsAndClassesOfObjects()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success;
            var objOClasses = OList_Objects.GroupBy(p => p.GUID_Parent).Select(p => new clsOntologyItem {GUID = p.Key}).ToList();
            objOItem_Result = objDBLevel_ClassesOfObjects.get_Data_Classes(objOClasses);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_Classes.AddRange(from objClass in objDBLevel_ClassesOfObjects.OList_Classes
                                       join objClassOld in OList_Classes on objClass.GUID equals objClassOld.GUID into
                                           objClasses
                                       from objClassOld in objClasses.DefaultIfEmpty()
                                       where objClassOld == null
                                       select new clsOntologyItem
                                           {
                                               GUID = objClass.GUID,
                                               Name = objClass.Name,
                                               GUID_Parent = objClass.GUID_Parent,
                                               Type = objClass.Type
                                           });
            }


            return objOItem_Result;
        }

        private clsOntologyItem GetParentClasses()
        {

            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success;
            var intCount = 0;
            do
            {
                intCount = OList_Classes.Count;
                var objOList_ParentClasses = OList_Classes.GroupBy(p => p.GUID_Parent).Select(p => new clsOntologyItem {GUID = p.Key}).ToList();
                if (objOList_ParentClasses.Any())
                {
                    objOItem_Result = objDBLevel_Classes.get_Data_Classes(objOList_ParentClasses);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        OList_Classes.AddRange(from objClass in objDBLevel_Classes.OList_Classes
                                               join objClassOld in OList_Classes on objClass.GUID equals
                                                   objClassOld.GUID into
                                                   objClasses
                                               from objClassOld in objClasses.DefaultIfEmpty()
                                               where objClassOld == null
                                               select new clsOntologyItem
                                                   {
                                                       GUID = objClass.GUID,
                                                       Name = objClass.Name,
                                                       GUID_Parent = objClass.GUID_Parent,
                                                       Type = objClass.Type
                                                   });

                    }
                    else
                    {
                        objOItem_Result = objLocalConfig.Globals.LState_Error;
                        break;  

                    }
                }

                intCount = OList_Classes.Count - intCount;

            } while (intCount>0);

            return objOItem_Result;
        }

        public clsObjectAtt Rel_Version__Major(clsOntologyItem objOItem_Version, long lngMajor)
        {
            var objOAVersion__Major = new clsObjectAtt
            {
                ID_AttributeType = objLocalConfig.OItem_attribute_major.GUID,
                ID_Class = objOItem_Version.GUID_Parent,
                ID_Object = objOItem_Version.GUID,
                ID_DataType = objLocalConfig.Globals.DType_Int.GUID,
                OrderID = 1,
                Val_Named = lngMajor.ToString(),
                Val_Lng = lngMajor
            };

            return objOAVersion__Major;
        }

        public clsObjectAtt Rel_Version__Minor(clsOntologyItem objOItem_Version, long lngMinor)
        {
            var objOAVersion__Minor = new clsObjectAtt
            {
                ID_AttributeType = objLocalConfig.OItem_attribute_minor.GUID,
                ID_Class = objOItem_Version.GUID_Parent,
                ID_Object = objOItem_Version.GUID,
                ID_DataType = objLocalConfig.Globals.DType_Int.GUID,
                OrderID = 1,
                Val_Named = lngMinor.ToString(),
                Val_Lng = lngMinor
            };

            return objOAVersion__Minor;
        }

        public clsObjectAtt Rel_Version__Build(clsOntologyItem objOItem_Version, long lngBuild)
        {
            var objOAVersion__Build = new clsObjectAtt
            {
                ID_AttributeType = objLocalConfig.OItem_attribute_build.GUID,
                ID_Class = objOItem_Version.GUID_Parent,
                ID_Object = objOItem_Version.GUID,
                ID_DataType = objLocalConfig.Globals.DType_Int.GUID,
                OrderID = 1,
                Val_Named = lngBuild.ToString(),
                Val_Lng = lngBuild
            };

            return objOAVersion__Build;
        }

        public clsObjectAtt Rel_Version__Revision(clsOntologyItem objOItem_Version, long lngRevision)
        {
            var objOAVersion__Revision = new clsObjectAtt
            {
                ID_AttributeType = objLocalConfig.OItem_attribute_revision.GUID,
                ID_Class = objOItem_Version.GUID_Parent,
                ID_Object = objOItem_Version.GUID,
                ID_DataType = objLocalConfig.Globals.DType_Int.GUID,
                OrderID = 1,
                Val_Named = lngRevision.ToString(),
                Val_Lng = lngRevision
            };

            return objOAVersion__Revision;
        }

        public clsObjectRel Rel_Version_To_Ref(clsOntologyItem objOItem_Version, clsOntologyItem objOItem_Ref, clsOntologyItem objOItem_RelationType)
        {
            clsObjectRel objORel_Version_To_Ref;

            if (objOItem_Ref.Direction == objOItem_Ref.Direction_LeftRight)
            {
                var lngOrderID = objDBLevel_VersionsRef.get_Data_Rel_OrderID(new clsOntologyItem {GUID_Parent = objLocalConfig.OItem_type_developmentversion.GUID},
                                                                             objOItem_Ref,
                                                                             objOItem_RelationType);

                objORel_Version_To_Ref = new clsObjectRel
                {
                    ID_Object = objOItem_Version.GUID,
                    ID_Parent_Object = objOItem_Version.GUID_Parent,
                    ID_RelationType = objOItem_RelationType.GUID,
                    ID_Other = objOItem_Ref.GUID,
                    ID_Parent_Other = objOItem_Ref.GUID_Parent,
                    Ontology = objOItem_Ref.Type,
                    OrderID = lngOrderID
                };
            }
            else
            {
                var lngOrderID = objDBLevel_VersionsRef.get_Data_Rel_OrderID(objOItem_Ref,
                                                                             new clsOntologyItem { GUID_Parent = objLocalConfig.OItem_type_developmentversion.GUID },
                                                                             objOItem_RelationType,false);

                objORel_Version_To_Ref = new clsObjectRel
                {
                    ID_Object = objOItem_Ref.GUID,
                    ID_Parent_Object = objOItem_Ref.GUID_Parent,
                    ID_RelationType = objOItem_RelationType.GUID,
                    ID_Other = objOItem_Version.GUID,
                    ID_Parent_Other = objOItem_Version.GUID_Parent,
                    Ontology = objOItem_Ref.Type,
                    OrderID = lngOrderID + 1
                };
            }

            return objORel_Version_To_Ref;
        }

        public clsObjectRel Rel_LogEntry_To_Version(clsOntologyItem OItem_LogEntry, clsOntologyItem OItem_Version)
        {
            var objORel_LogEntry_To_Version = new clsObjectRel
            {
                ID_Object = OItem_LogEntry.GUID,
                ID_Parent_Object = OItem_LogEntry.GUID_Parent,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongsto.GUID,
                ID_Other = OItem_Version.GUID,
                ID_Parent_Other = OItem_Version.GUID_Parent,
                Ontology = objLocalConfig.Globals.Type_Object,
                OrderID = 1
            };

            return objORel_LogEntry_To_Version;
        }

        private void initialize()
        {
            objDBLevel_Versions = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Refs_To_Versions = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Versions_To_Refs = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Version__VersionNumbers = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ClassesOfObjects = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Classes = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_VersionsRef = new clsDBLevel(objLocalConfig.Globals);

            objLocalConfig_LogModule = new Log_Module.clsLocalConfig(objLocalConfig.Globals);

            objDataWork_LogEntry = new clsDataWork_LogEntry(objLocalConfig_LogModule);

            OItem_Result_Versions = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_Versions_To_Refs = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_Versions__VersionNumbers = objLocalConfig.Globals.LState_Nothing;
        }

    }
}


