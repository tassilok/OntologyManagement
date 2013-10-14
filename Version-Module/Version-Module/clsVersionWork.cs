using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontolog_Module;
using OntologyClasses.BaseClasses;

namespace Version_Module
{
    public class clsVersionWork
    {
        public long Major { get; set; }
        public long Minor { get; set; }
        public long Build { get; set; }
        public long Revision { get; set; }

        private List<clsVersion> objVersions;

        private IWin32Window objParWindow;

        private clsLocalConfig objLocalConfig;

        private clsTransaction objTransaction;

        private clsDataWork_Versions objDataWork_Versions;

        public dlg_Attribute_String objDlgAttribute_String;

        public clsOntologyItem OItem_LogState { get; set; }

        public clsOntologyItem OItem_LogEntry { get; set; }

        private clsOntologyItem objOItem_Ref;
   
        public clsOntologyItem save_Version(bool boolDescribe)
        {
            var objOItem_Result = get_VersionData();

            var boolSave = false;

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objVersions.Any())
                {
                    var objVersion = objVersions.First();

                    if (objVersion.Major != Major ||
                        objVersion.Minor != Minor ||
                        objVersion.Build != Build ||
                        objVersion.Revision != Revision)
                    {
                        boolSave = true;
                    }
                }
                else
                {
                    boolSave = true;
                }

                if (boolSave)
                {
                    objTransaction.ClearItems();
                    if (!objVersions.Any())
                    {
                        var objVersion = new clsOntologyItem
                        {
                            GUID = objLocalConfig.Globals.NewGUID,
                            Name = Major + "." + Minor + "." + Build + "." + Revision,
                            GUID_Parent = objLocalConfig.OItem_type_developmentversion.GUID,
                            Type = objLocalConfig.Globals.Type_Object
                        };

                        objOItem_Result = objTransaction.do_Transaction(objVersion);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            var objOAVersion__Major = objDataWork_Versions.Rel_Version__Major(objVersion, Major);
                            objOItem_Result = objTransaction.do_Transaction(objOAVersion__Major);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                var objOAVersion__Minor = objDataWork_Versions.Rel_Version__Minor(objVersion, Minor);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    var objOAVersion__Build = objDataWork_Versions.Rel_Version__Build(objVersion, Build);
                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        var objOAVersion__Revision = objDataWork_Versions.Rel_Version__Revision(objVersion, Revision);
                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            var Rel_Version_To_Ref = objDataWork_Versions.Rel_Version_To_Ref(objVersion,objOItem_Ref,
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
                }
                else
                {
                    var objVersion = new clsOntologyItem {GUID = objVersions.First().ID_Version,
                                                          Name = objVersions.First().Name_Version,
                                                          GUID_Parent = objLocalConfig.OItem_type_developmentversion.GUID,
                                                          Type = objLocalConfig.Globals.Type_Object};

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (objVersions.First().Major != Major)
                        {
                            var objOAVersion__Major = objDataWork_Versions.Rel_Version__Major(objVersion, Major);
                            objOItem_Result = objTransaction.do_Transaction(objOAVersion__Major);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                            {
                                objTransaction.rollback();
                            }   
                        }
                        
                    }

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (objVersions.First().Minor != Minor)
                        {
                            var objOAVersion__Minor = objDataWork_Versions.Rel_Version__Minor(objVersion, Minor);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                            {
                                objTransaction.rollback();
                            }
                        }

                        
                    }
                    
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (objVersions.First().Build != Build)
                        {
                            var objOAVersion__Build = objDataWork_Versions.Rel_Version__Build(objVersion, Build);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                            {
                                objTransaction.rollback();
                            }
                        }

                        
                    }

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (objVersions.First().Revision != Revision)
                        {
                            var objOAVersion__Revision = objDataWork_Versions.Rel_Version__Revision(objVersion, Revision);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                            {
                                objTransaction.rollback();
                            }
                        }
                        
                    }
                    
                    
                }
            }
            
            return objOItem_Result;
        }

        public clsOntologyItem get_VersionData()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            objDataWork_Versions.GetData_Ref_To_Version();
            if (objDataWork_Versions.OItem_Result_Versions_To_Refs.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objVersions = objDataWork_Versions.GetVersions(objOItem_Ref);

            }
            else
            {
                objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
            }

            return objOItem_Result;

        }

        public string getMessage()
        {
            string strResult = "";
            objDlgAttribute_String = new dlg_Attribute_String(objLocalConfig.OItem_type_logstate.Name, objLocalConfig.Globals);
            objDlgAttribute_String.ShowDialog(objParWindow);

            if (objDlgAttribute_String.DialogResult == DialogResult.OK)
            {
                strResult = objDlgAttribute_String.Value;
            }
            else
            {
                MessageBox.Show(objParWindow, "Geben Sie bitte eine Beschreibung ein!", "Beschreibung", MessageBoxButtons.OK, MessageBoxIcon.Information);
                strResult = getMessage();
            }

            return strResult;
        }

        public clsVersionWork(clsLocalConfig LocalConfig, IWin32Window ParWindow, clsOntologyItem OItem_Ref)
        {

            objParWindow = ParWindow;
            objOItem_Ref = OItem_Ref;
            objLocalConfig = LocalConfig;

            initialize();

        }

        public clsVersionWork(clsGlobals Globals, IWin32Window ParWindow, clsOntologyItem OItem_User, clsOntologyItem OItem_Ref)
        {

            objParWindow = ParWindow;
            objOItem_Ref = OItem_Ref;
            objLocalConfig = new clsLocalConfig(Globals);

            initialize();

        }

        public void initialize()
        {
            objDataWork_Versions = new clsDataWork_Versions(objLocalConfig);
            objTransaction = new clsTransaction(objLocalConfig.Globals);
        }

    }
}
