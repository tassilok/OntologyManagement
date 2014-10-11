using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using Version_Module;

namespace Document_Module
{
    public class clsDataWork_Document
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_Documents;
        private clsDBLevel objDBLevel_CreationDate;
        private clsDBLevel objDBLevel_Version;
        private clsDBLevel objDBLevel_Autor;

        public clsOntologyItem OItem_Result_Documents { get; set; }
        public clsOntologyItem OItem_Result_CreationDate { get; set; }
        public clsOntologyItem OItem_Result_Version { get; set; }
        public clsOntologyItem OItem_Result_Autor { get; set; }

        public List<clsDocument> Documents { get; set; }

        public clsDataWork_Versions objDataWork_Versions;

        public clsOntologyItem GetData_Documents()
        {
            GetSubData_001_Documents();

            var objOItem_Result = OItem_Result_Documents;

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                GetSubData_002_CreationDate();
                objOItem_Result = OItem_Result_CreationDate;

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    GetSubData_003_Version();
                    objOItem_Result = OItem_Result_Version;

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        GetSubData_004_Autor();
                        objOItem_Result = OItem_Result_Autor;

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            var versions = (from doc in objDBLevel_Documents.OList_Objects
                                            from version in objDBLevel_Version.OList_ObjectRel
                                            where doc.GUID == version.ID_Object && version.OrderID ==
                                                (from ver in objDBLevel_Version.OList_ObjectRel
                                                 where ver.ID_Object == doc.GUID
                                                 select ver.OrderID).Max()
                                            select new clsDocument
                                            {
                                                ID_Document = doc.GUID,
                                                Name_Document = doc.Name,
                                                ID_Version = version.ID_Other,
                                                Name_Version = version.Name_Other
                                            }).ToList();
                                            
                            var versionsWithData = objDataWork_Versions.GetVersionData(versions.Select(ver => new clsOntologyItem
                            {
                                GUID = ver.ID_Version,
                                Name = ver.Name_Version
                            }).ToList());



                            Documents = (from doc in objDBLevel_Documents.OList_Objects
                                         join creationDate in objDBLevel_CreationDate.OList_ObjectAtt on doc.GUID equals creationDate.ID_Object into creationDates
                                         from creationDate in creationDates.DefaultIfEmpty()
                                         join autor in objDBLevel_Autor.OList_ObjectRel on doc.GUID equals autor.ID_Object into autors
                                         from autor in autors.DefaultIfEmpty()
                                         join version in (from version in versions
                                                join versionData in versionsWithData on version.ID_Version equals versionData.ID_Version
                                                select versionData).ToList() on doc.GUID equals version.ID_Version into versionDatas
                                         from version in versionDatas.DefaultIfEmpty()
                                         select new clsDocument
                                         {
                                             ID_Document = doc.GUID,
                                             Name_Document = doc.Name,
                                             ID_Attribute_CreationDate = creationDate != null ? creationDate.ID_Attribute : null,
                                             CreationDate = creationDate != null ? creationDate.Val_Date : null, 
                                             ID_Autor = autor != null ? autor.ID_Other : null,
                                             Name_Autor = autor != null ? autor.Name_Other : null,
                                             ID_Version = version != null ? version.ID_Version : null,
                                             Name_Version = version != null ? version.Name_Version : null,
                                             ID_Attribute_Major = version != null ? version.ID_Attribute_Major : null,
                                             Major = version != null ? version.Major : null,
                                             ID_Attribute_Minor = version != null ? version.ID_Attribute_Minor : null,
                                             Minor = version != null ? version.Minor : null,
                                             ID_Attribute_Build = version != null ? version.ID_Attribute_Build : null,
                                             Build = version != null ? version.Build : null,
                                             ID_Attribute_Revision = version != null ? version.ID_Attribute_Revision : null,
                                             Revision = version != null ? version.Revision : null


                                         }).ToList();
                        }
                    }

                }
            }

            return objOItem_Result;
        }

        public void GetSubData_001_Documents()
        {
            OItem_Result_Documents = objLocalConfig.Globals.LState_Nothing.Clone();

            var searchDocuments = new List<clsOntologyItem>
            {
                new clsOntologyItem
                {
                    GUID_Parent = objLocalConfig.OItem_class_document.GUID
                }
            };

            var objOItem_Result = objDBLevel_Documents.get_Data_Objects(searchDocuments);

            OItem_Result_Documents = objOItem_Result;

        }

        public void GetSubData_002_CreationDate()
        {
            OItem_Result_CreationDate = objLocalConfig.Globals.LState_Nothing.Clone();

            var searchCreationDate = objDBLevel_Documents.OList_Objects.Select(doc => new clsObjectAtt
            {
                ID_Object = doc.GUID,
                ID_AttributeType = objLocalConfig.OItem_attributetype_datetimestamp__create_.GUID
            }).ToList();

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            if (searchCreationDate.Any())
            {
                objOItem_Result = objDBLevel_CreationDate.get_Data_ObjectAtt(searchCreationDate, boolIDs: false);
            }
            else
            {
                objDBLevel_CreationDate.OList_ObjectAtt.Clear();
            }


            OItem_Result_CreationDate = objOItem_Result;
        }

        public void GetSubData_003_Version()
        {
            OItem_Result_Version = objLocalConfig.Globals.LState_Nothing.Clone();

            var searchVersion = objDBLevel_Documents.OList_Objects.Select(doc => new clsObjectRel
            {
                ID_Object = doc.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_development_version.GUID
            }).ToList();

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            if (searchVersion.Any())
            {
                objOItem_Result = objDBLevel_Version.get_Data_ObjectRel(searchVersion, boolIDs: false);
            }
            else
            {
                objDBLevel_Version.OList_ObjectRel.Clear();
            }

            OItem_Result_Version = objOItem_Result;
        }

        public void GetSubData_004_Autor()
        {
            OItem_Result_Autor = objLocalConfig.Globals.LState_Nothing.Clone();

            var searchAutor = objDBLevel_Documents.OList_Objects.Select(doc =>
                    new clsObjectRel
                    {
                        ID_Object = doc.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_autor.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_partner.GUID
                    }).ToList();

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            if (searchAutor.Any())
            {
                objOItem_Result = objDBLevel_Autor.get_Data_ObjectRel(searchAutor, boolIDs: false);
            }
            else
            {
                objDBLevel_Autor.OList_ObjectRel.Clear();
            }

            OItem_Result_Autor = objOItem_Result;
        }

        public clsDataWork_Document(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_Documents = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_CreationDate = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Version = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Autor = new clsDBLevel(objLocalConfig.Globals);

            OItem_Result_Documents = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_CreationDate = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_Version = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_Autor = objLocalConfig.Globals.LState_Nothing.Clone();

            Documents = new List<clsDocument>();
            objDataWork_Versions = new clsDataWork_Versions(objLocalConfig.Globals);
        }
    }
}
