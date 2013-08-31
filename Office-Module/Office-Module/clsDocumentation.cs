using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;
using Filesystem_Module;
using System.IO;

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
        private frmBlobWatcher objFrmBlobWatcher;
        private string strCategory;

        public clsOntologyItem open_Document(clsDocument objDocument)
        {
            clsOntologyItem objOItem_Result;
            clsOntologyItem objOItem_RefForTemplate = null;
            clsOntologyItem objOItem_Template_File;

            
            objOItem_Result = objLocalConfig.Globals.LState_Error;

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
                        objOItem_Template_File.Additional1 = "%temp%\\" + objOItem_Template_File.Name;
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
                            objOItem_Template_File.Additional1 = "%temp%\\" + objOItem_Template_File.Name;
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
                    if (objOItem_Template_File.Mark)
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
                            objOItem_Result = objLocalConfig.Globals.LState_Error;
                        }

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objOItem_Document = new clsOntologyItem();
                            objOItem_Document.GUID = objDocument.ID_Document;
                            objOItem_Document.Name = objDocument.Name_Document;
                            objOItem_Document.GUID_Parent = objDocument.ID_Parent_Document;


                            objOItem_Document.GUID_Related = objWordWork.openDocument(objOItem_File_Document.Additional1, strCategory, objDocument.Name_Ref, objOItem_Template_File.Additional1);
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
        }
    }
}

