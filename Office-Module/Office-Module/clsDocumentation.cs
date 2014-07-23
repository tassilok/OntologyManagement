using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using Filesystem_Module;
using System.IO;
using OntologyClasses.BaseClasses;
using System.Diagnostics;

namespace Office_Module
{
    public class clsDocumentation
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_Documents objDataWork_Documents;
        private clsFileWork objFileWork;
        private clsBlobConnection objBlobConnection;
        private clsWordWork objWordWork;
        private clsOntologyItem objOItem_Document;
        private clsTransaction objTransaction;
        private frmBlobWatcher objFrmBlobWatcher;
        private string strCategory;

        public clsOntologyItem OItem_Bookmark_Last { get; private set; }
        public clsOntologyItem OItem_Document_Last { get; private set; }

        public void Clear_BookmarkDocLast()
        {
            OItem_Bookmark_Last = null;
            OItem_Document_Last = null;
        }

        public clsOntologyItem getBookmarksOfRef(clsOntologyItem OItem_Ref)
        {
            OItem_Bookmark_Last = objDataWork_Documents.getBookmarkOfRef(OItem_Ref);

            return OItem_Bookmark_Last;
        }

        public clsOntologyItem getDocumentOfBookmark(clsOntologyItem OItem_Bookmark)
        {
            OItem_Document_Last = objDataWork_Documents.getDocumentOfBookmark(OItem_Bookmark);

            return OItem_Document_Last;
        }

        public clsDocument GetData_DocumentData(clsOntologyItem OItem_Document)
        {
            return objDataWork_Documents.GetData_DocumentData(OItem_Document);
        }

        public clsOntologyItem has_Document(clsOntologyItem objOItem_Ref)
        {
            

            var OList_Documents = objDataWork_Documents.GetDocumentsByRef(objOItem_Ref);
            if (OList_Documents == null)
            {
                return objLocalConfig.Globals.LState_Error;
                
            }
            else
            {
                if (OList_Documents.Any())
                {
                    var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
                    objOItem_Result.Count = OList_Documents.Count;
                    return objOItem_Result;
                }
                else
                {
                    return objLocalConfig.Globals.LState_Nothing;
                }
            }
            

            
        }

        public List<clsOntologyItem> get_DocumentsOfRef(clsOntologyItem objOItem_Ref)
        {
            return objDataWork_Documents.GetDocumentsByRef(objOItem_Ref);
        }

        public clsOntologyItem activate_Bookmark(clsDocument objDocument, clsOntologyItem OItem_Bookmark)
        {
            clsOntologyItem objOItem_Result;
            var strTitle = "m_" + objLocalConfig.Globals.GUIDFormat1(OItem_Bookmark.GUID);
            strTitle = strTitle.Replace("-","_");

            if (objWordWork.activateBookmark(strTitle, objDocument.ID_File + "." + objLocalConfig.OItem_Token_Extensions_docx.Name))
            {
                objOItem_Result = objLocalConfig.Globals.LState_Success;
            }
            else
            {
                objOItem_Result = objLocalConfig.Globals.LState_Error;
            }

            return objOItem_Result;
        }

        public clsOntologyItem insert_Bookmark(clsOntologyItem OItem_Ref)
        {
            clsOntologyItem objOItem_Result;
            clsOntologyItem objOItem_File;
            clsOntologyItem objOItem_ManagedDoc;

            var strFileName = objWordWork.FileName_Active_Doc;

            if (strFileName.Contains("." + objLocalConfig.OItem_Token_Extensions_docx.Name))
            {
                objOItem_File = new clsOntologyItem();
                objOItem_File.Name = strFileName;
                strFileName = strFileName.Substring(0, strFileName.IndexOf("." + objLocalConfig.OItem_Token_Extensions_docx.Name));
                strFileName = strFileName.Replace("-","");
                if (objLocalConfig.Globals.is_GUID(strFileName))
                {
                    objOItem_File.GUID = strFileName;
                    objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID;
                    objOItem_File.Type = objLocalConfig.Globals.Type_Object;

                    objOItem_ManagedDoc = objDataWork_Documents.GetDocumentByFile(objOItem_File);

                    objOItem_Result = objLocalConfig.Globals.LState_Success;

                    if (objOItem_ManagedDoc != null)
                    {
                        if (objOItem_ManagedDoc.GUID != objLocalConfig.Globals.LState_Error.GUID)
                        {
                            var objOItem_Bookmark = objDataWork_Documents.GetExistantContentObject(objOItem_ManagedDoc,
                                                                                                   objLocalConfig.OItem_Token_ContentType_Bookmark,
                                                                                                   OItem_Ref);
                            if (objOItem_Bookmark.GUID != objLocalConfig.Globals.LState_Error.GUID)
                            {
                                if (objOItem_Bookmark.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
                                {
                                    objOItem_Bookmark = new clsOntologyItem()
                                    {
                                        GUID = objLocalConfig.Globals.NewGUID,
                                        Name = OItem_Ref.Name,
                                        GUID_Parent = objLocalConfig.OItem_Type_ContentObject.GUID
                                    };

                                    objTransaction.ClearItems();

                                    objOItem_Result = objTransaction.do_Transaction(objOItem_Bookmark);
                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        var objORBookmarkToType = new clsObjectRel()
                                        {
                                            ID_Object = objOItem_Bookmark.GUID,
                                            ID_Parent_Object = objOItem_Bookmark.GUID_Parent,
                                            ID_RelationType = objLocalConfig.OItem_RelationType_is_of_Type.GUID,
                                            ID_Other = objLocalConfig.OItem_Token_ContentType_Bookmark.GUID,
                                            ID_Parent_Other = objLocalConfig.OItem_Token_ContentType_Bookmark.GUID_Parent,
                                            OrderID = 1,
                                            Ontology = objLocalConfig.Globals.Type_Object
                                        };

                                        objOItem_Result = objTransaction.do_Transaction(objORBookmarkToType);
                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            var objORBookmarkToMD = new clsObjectRel()
                                            {
                                                ID_Object = objOItem_Bookmark.GUID,
                                                ID_Parent_Object = objOItem_Bookmark.GUID_Parent,
                                                ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Document.GUID,
                                                ID_Other = objOItem_ManagedDoc.GUID,
                                                ID_Parent_Other = objOItem_ManagedDoc.GUID_Parent,
                                                OrderID = 1,
                                                Ontology = objLocalConfig.Globals.Type_Object
                                            };
                                            objOItem_Result = objTransaction.do_Transaction(objORBookmarkToMD);
                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                            {
                                                var objORBookmarkToRef = new clsObjectRel()
                                                {
                                                    ID_Object = objOItem_Bookmark.GUID,
                                                    ID_Parent_Object = objOItem_Bookmark.GUID_Parent,
                                                    ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Sem_Item.GUID,
                                                    ID_Other = OItem_Ref.GUID,
                                                    ID_Parent_Other = OItem_Ref.GUID_Parent,
                                                    OrderID = 1,
                                                    Ontology = OItem_Ref.Type

                                                };

                                                objOItem_Result = objTransaction.do_Transaction(objORBookmarkToRef);
                                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                                                {
                                                    objTransaction.rollback();
                                                }
                                            }
                                            else
                                            {
                                                objTransaction.rollback();
                                            }

                                        }
                                        else
                                        {
                                            objTransaction.rollback();
                                        }
                                    }
                                    


                                }

                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    var strIDDoc = objWordWork.insertBookmark(objOItem_Bookmark.GUID);
                                    if (objOItem_ManagedDoc.GUID == strIDDoc)
                                    {
                                        objOItem_Result = objLocalConfig.Globals.LState_Success;
                                    }
                                    else
                                    {
                                        objOItem_Result = objLocalConfig.Globals.LState_Error;
                                    }

                                }
                            }
                            else
                            {
                                objOItem_Result = objLocalConfig.Globals.LState_Error;
                            }
                        }
                        else
                        {
                            objOItem_Result = objLocalConfig.Globals.LState_Error;
                        }
                    }
                    else
                    {
                        objOItem_Result = objLocalConfig.Globals.LState_Nothing;
                    }
                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Nothing;
                }
            }
            else
            {
                objOItem_Result = objLocalConfig.Globals.LState_Nothing;
            }
            return objOItem_Result;
        }


        public clsDocument CreateDoc(clsOntologyItem OItem_Ref)
        {
            clsDocument objDoc = null;
            var objOItem_Result = objLocalConfig.Globals.LState_Success;

            objOItem_Result = objLocalConfig.DataWork_Documents.TestExistanceDoc(OItem_Ref);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                var objOItem_DocItem = new clsOntologyItem
                {
                    GUID = objLocalConfig.Globals.NewGUID,
                    Name = OItem_Ref.Name,
                    GUID_Parent = objLocalConfig.OItem_Type_Managed_Document.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                objTransaction.ClearItems();
                objOItem_Result = objTransaction.do_Transaction(objOItem_DocItem);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var objORel_Doc_To_Ref = objLocalConfig.DataWork_Documents.Rel_Doc_To_Ref(objOItem_DocItem, OItem_Ref);
                    objOItem_Result = objTransaction.do_Transaction(objORel_Doc_To_Ref, true);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var objORel_Doc_To_WordFileType = objLocalConfig.DataWork_Documents.Rel_Doc_To_WordFileType(objOItem_DocItem);
                        objOItem_Result = objTransaction.do_Transaction(objORel_Doc_To_WordFileType, true);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            var objOItem_File = new clsOntologyItem
                            {
                                GUID = objLocalConfig.Globals.NewGUID,
                                GUID_Parent = objLocalConfig.OItem_Type_File.GUID,
                                Type = objLocalConfig.Globals.Type_Object
                            };

                            objOItem_File.Name = objOItem_File.GUID + "." + objLocalConfig.OItem_Token_Extensions_docx.Name;

                            objOItem_Result = objTransaction.do_Transaction(objOItem_File);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                var objORel_Doc_To_File = objLocalConfig.DataWork_Documents.Rel_Doc_To_File(objOItem_DocItem, objOItem_File);
                                objOItem_Result = objTransaction.do_Transaction(objORel_Doc_To_File, true);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    objDoc = new clsDocument
                                    {
                                        ID_Document = objOItem_DocItem.GUID,
                                        Name_Document = objOItem_DocItem.Name,
                                        ID_DocumentType = objORel_Doc_To_WordFileType.ID_Other,
                                        Name_DocumentType = objORel_Doc_To_WordFileType.Name_Other,
                                        ID_Ref = OItem_Ref.GUID,
                                        ID_Parent_Ref = OItem_Ref.GUID_Parent,
                                        Name_Ref = OItem_Ref.Name,
                                        Ontology_Ref = OItem_Ref.Type,
                                        ID_File = objOItem_File.GUID,
                                        Name_File = objOItem_File.Name
                                    };
                                }
                                else
                                {
                                    objTransaction.rollback();
                                }

                            }
                            else
                            {
                                objTransaction.rollback();
                            }

                        }
                        else
                        {
                            objTransaction.rollback();
                        }

                    }
                    else
                    {
                        objTransaction.rollback();
                    }
                }

            }
            else if (objOItem_Result.GUID != objLocalConfig.Globals.LState_Error.GUID)
            {
                objLocalConfig.DataWork_Documents.GetData();
                while (objLocalConfig.DataWork_Documents.isPresent_Documents().GUID == objLocalConfig.Globals.LState_Nothing.GUID)
                {
                }

                if (objLocalConfig.DataWork_Documents.isPresent_Documents().GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var objDocuments = (from obj in objLocalConfig.DataWork_Documents.OList_Documents
                                        where obj.ID_Ref == OItem_Ref.GUID
                                        select obj).ToList();

                    if (objDocuments.Any())
                    {
                        objDoc = objDocuments.First();
                    }
                }

            }

            return objDoc;
        }

        public clsOntologyItem open_Document(clsOntologyItem OITem_Ref)
        {
            var objOItem_Result = objDataWork_Documents.GetData(OITem_Ref);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var objOItem_Present = objLocalConfig.Globals.LState_Nothing;
                while ( objOItem_Present.GUID == objLocalConfig.Globals.LState_Nothing.GUID ) 
                {
                    objOItem_Present =  objDataWork_Documents.GetData_Documents();
                };

                if (objOItem_Present.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var objDocuments = objDataWork_Documents.OList_Documents;
                    if (objDocuments.Any())
                    {
                        var objDocument = objDocuments.First();
                        objOItem_Result = open_Document(objDocument);
                    }
                    else
                    {
                        objOItem_Result = open_Document(new clsDocument
                        {
                            ID_Ref = OITem_Ref.GUID,
                            Name_Ref = OITem_Ref.Name,
                            ID_Parent_Ref = OITem_Ref.GUID_Parent,
                            Ontology_Ref = OITem_Ref.Type
                        });
                        
                    }


                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Error;    
                    
                }
                
            }
            else
            {
                objOItem_Result = objLocalConfig.Globals.LState_Error;
            }

            return objOItem_Result;
        }

        public clsOntologyItem open_Document(clsDocument objDocument)
        {
            clsOntologyItem objOItem_Result;
            clsOntologyItem objOItem_RefForTemplate = null;
            clsOntologyItem objOItem_Template_File;

            
            objOItem_Result = objLocalConfig.Globals.LState_Error;

            if (objDocument.ID_Document != null)
            {
                var objOItem_Ref = new clsOntologyItem()
                {
                    GUID = objDocument.ID_Ref,
                    Name = objDocument.Name_Ref,
                    GUID_Parent = objDocument.ID_Parent_Ref,
                    Type = objDocument.Ontology_Ref
                };

                if (objOItem_Ref.Type == objLocalConfig.Globals.Type_AttributeType)
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Success;
                    strCategory = objLocalConfig.Globals.Type_AttributeType;
                    // Todo Template for Attribute-Types
                    objOItem_RefForTemplate = null;
                }
                else if (objOItem_Ref.Type == objLocalConfig.Globals.Type_Class)
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Success;
                    strCategory = objLocalConfig.Globals.Type_Class;
                    // Todo Template for Classes
                    objOItem_RefForTemplate = null;
                }
                else if (objOItem_Ref.Type == objLocalConfig.Globals.Type_Object)
                {


                    objOItem_RefForTemplate = objLocalConfig.DataWork_Documents.GetClassOfObject(objOItem_Ref);
                    if (objOItem_RefForTemplate != null)
                    {
                        strCategory = objOItem_RefForTemplate.Name;
                        objOItem_Result = objLocalConfig.Globals.LState_Success;
                    }


                }
                else if (objOItem_Ref.Type == objLocalConfig.Globals.Type_RelationType)
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Success;
                    strCategory = objLocalConfig.Globals.Type_RelationType;
                    // Template for RelationTypes
                    objOItem_RefForTemplate = null;
                }

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOItem_Template_File = objLocalConfig.DataWork_Documents.GetTemplate(objOItem_RefForTemplate);
                    if (objOItem_Template_File != null)
                    {
                        if (objFileWork.is_File_Blob(objOItem_Template_File))
                        {
                            objOItem_Template_File.Mark = true;
                            objOItem_Template_File.Additional1 = "%temp%\\" + objOItem_Template_File.GUID + System.IO.Path.GetExtension(objOItem_Template_File.Name);
                            objOItem_Template_File.Additional1 = Environment.ExpandEnvironmentVariables(objOItem_Template_File.Additional1);

                        }
                        else
                        {
                            objOItem_Template_File.Additional1 = objFileWork.get_Path_FileSystemObject(objOItem_Template_File);
                        }

                    }
                    else
                    {
                        objOItem_Template_File = objLocalConfig.DataWork_Documents.GetStandardTemplate();
                        if (objOItem_Template_File.GUID != null)
                        {
                            if (objFileWork.is_File_Blob(objOItem_Template_File))
                            {
                                objOItem_Template_File.Mark = true;
                                objOItem_Template_File.Additional1 = "%temp%\\" + objOItem_Template_File.GUID + System.IO.Path.GetExtension(objOItem_Template_File.Name);
                                objOItem_Template_File.Additional1 = Environment.ExpandEnvironmentVariables(objOItem_Template_File.Additional1);
                            }
                            else
                            {
                                objOItem_Template_File.Additional1 = objFileWork.get_Path_FileSystemObject(objOItem_Template_File);
                            }

                            objOItem_Result = objLocalConfig.Globals.LState_Success;

                        }
                        else
                        {
                            objOItem_Result = objLocalConfig.Globals.LState_Error;
                        }

                    }


                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (objOItem_Template_File.Mark ?? false)
                        {
                            objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_Template_File, objOItem_Template_File.Additional1, true);
                        }

                    }

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {

                        if (objDocument.ID_File != null)
                        {

                            var objOItem_File_Document = new clsOntologyItem()
                            {
                                GUID = objDocument.ID_File,
                                Name = objDocument.Name_File,
                                GUID_Parent = objLocalConfig.OItem_Type_File.GUID,
                                Type = objLocalConfig.Globals.Type_Object
                            };

                            var strPath = objFileWork.merge_paths(objBlobConnection.Path_BlobWatcher, objOItem_File_Document.Name);
                            var strExtension = Path.GetExtension(strPath);
                            strPath = objFileWork.merge_paths(objBlobConnection.Path_BlobWatcher, objOItem_File_Document.GUID + strExtension);

                            objOItem_File_Document.Additional1 = strPath;

                            objOItem_Result = objFrmBlobWatcher.Initialize_BlobDirWatcher();

                            if (objFileWork.is_File_Blob(objOItem_File_Document))
                            {
                                objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_File_Document, objOItem_File_Document.Additional1);
                            }
                            else
                            {
                                objOItem_Result = objLocalConfig.Globals.LState_Success;
                            }

                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                objOItem_Document = new clsOntologyItem();
                                objOItem_Document.GUID = objDocument.ID_Document;
                                objOItem_Document.Name = objDocument.Name_Document;
                                objOItem_Document.GUID_Parent = objDocument.ID_Parent_Document;


                                objOItem_Document.GUID_Related = objWordWork.openDocument(objOItem_File_Document.Additional1, strCategory, objDocument.Name_Ref, objOItem_Template_File.Additional1);
                                objWordWork.Visible = true;
                                if (objOItem_Document.GUID_Related == null)
                                {
                                    objOItem_Result = objLocalConfig.Globals.LState_Error;
                                }
                                else
                                {
                                    objOItem_Result = objOItem_Document;
                                }


                            }
                        }
                        else
                        {
                            objOItem_Result = objLocalConfig.Globals.LState_Error;
                        }

                    }

                }
            }
            else
            {
                var objOItem_Ref = new clsOntologyItem { GUID = objDocument.ID_Ref,
                                                         Name = objDocument.Name_Ref,
                                                         GUID_Parent = objDocument.ID_Parent_Ref,
                                                         Type = objDocument.Ontology_Ref };
                objDocument = CreateDoc(objOItem_Ref);
                if (objDocument != null)
                {
                    objOItem_Result = open_Document(objDocument);
                }
            }
            
            
            return objOItem_Result;
        }

        

        public clsDocumentation(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            initialize();
        }

        public clsDocumentation(clsGlobals Globals)
        {
            objLocalConfig = new clsLocalConfig(Globals);
            objLocalConfig.DataWork_Documents = new clsDataWork_Documents(objLocalConfig);
            initialize();
        }

        private void initialize()
        {
            objFileWork = new clsFileWork(objLocalConfig.Globals);
            objBlobConnection = new clsBlobConnection(objLocalConfig.Globals);
            objWordWork = new clsWordWork();
            objFrmBlobWatcher = new frmBlobWatcher(objLocalConfig.Globals);
            objDataWork_Documents = new clsDataWork_Documents(objLocalConfig.Globals);
            objTransaction = new clsTransaction(objLocalConfig.Globals);
        }
    }
}

