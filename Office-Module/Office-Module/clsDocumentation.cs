using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;
using Filesystem_Module;

namespace Office_Module
{
    class clsDocumentation
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_Documents objDataWork_Documents;
        private clsFileWork objFileWork;
        private clsBlobConnection objBlobConnection;
        private string strCategory;

        public clsOntologyItem open_Document(clsOntologyItem OItem_Ref)
        {
            clsOntologyItem objOItem_Result;
            clsOntologyItem objOItem_RefForTemplate = null;
            clsOntologyItem objOItem_Template_File;

            objOItem_Result = objLocalConfig.Globals.LState_Error;

            if (OItem_Ref.Type == objLocalConfig.Globals.Type_AttributeType)
            {
                objOItem_Result = objLocalConfig.Globals.LState_Success;
                strCategory = objLocalConfig.Globals.Type_AttributeType;
                // Todo Template for Attribute-Types
                objOItem_RefForTemplate = null;
            }
            else if (OItem_Ref.Type == objLocalConfig.Globals.Type_Class)
            {
                objOItem_Result = objLocalConfig.Globals.LState_Success;
                strCategory = objLocalConfig.Globals.Type_Class;
                // Todo Template for Classes
                objOItem_RefForTemplate = null;
            }
            else if (OItem_Ref.Type == objLocalConfig.Globals.Type_Object)
            {

                objOItem_RefForTemplate = objLocalConfig.DataWork_Documents.GetClassOfObject(OItem_Ref);
                if (objOItem_RefForTemplate != null)
                {
                    strCategory = objOItem_RefForTemplate.Name;
                    objOItem_Result = objLocalConfig.Globals.LState_Success;
                }
                
                
            }
            else if (OItem_Ref.Type == objLocalConfig.Globals.Type_RelationType)
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
                        objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_Template_File, objOItem_Template_File.Additional1);
                    }
                    
                }

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var OList_Document = (from objDoc in objDataWork_Documents.OList_Documents
                                          where objDoc.ID_Ref == OItem_Ref.GUID
                                          select objDoc).ToList();

                    if (OList_Document.Any())
                    {
                        if (OList_Document.First().ID_File != null)
                        {
                            var objOListFile = OList_Document.First();
                            var objOItem_File_Document = new clsOntologyItem()
                            {
                                GUID = objOListFile.ID_File,
                                Name = objOListFile.Name_File,
                                GUID_Parent = objLocalConfig.OItem_Type_File.GUID,
                                Type = objLocalConfig.Globals.Type_Object
                            };

                            if (objFileWork.is_File_Blob(objOItem_File_Document))
                            {

                            }
                            else
                            {

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
        }
    }
}

