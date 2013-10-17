using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using Log_Module;

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

        public clsDataWork_Versions DataWork_Versions { get; private set; }

        public dlg_Attribute_String objDlgAttribute_String;

        public clsOntologyItem OItem_LogState { get; set; }

        public clsOntologyItem OItem_LogEntry { get; set; }

        private clsOntologyItem objOItem_Ref;

        private clsLogManagement objLogManagement;

        private frmMain objFrmMain;

        public clsOntologyItem objVersion { get; private set; }
   
        public clsOntologyItem save_Version(bool boolDescribe, long major, long minor, long build, long revision)
        {
            objFrmMain = new frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class, objLocalConfig.OItem_type_logstate);
            objFrmMain.ShowDialog(objParWindow);

            clsOntologyItem objOItem_LogState = null;
            var objOItem_Result = objLocalConfig.Globals.LState_Nothing.Clone();
            var strDescription = "";

            if (objFrmMain.DialogResult == DialogResult.OK)
            {
                if (objFrmMain.Type_Applied == objLocalConfig.Globals.Type_Object)
                {
                    if (objFrmMain.OList_Simple.Count == 1)
                    {
                        if (objFrmMain.OList_Simple.First().GUID_Parent == objLocalConfig.OItem_type_logstate.GUID)
                        {
                            objOItem_LogState = objFrmMain.OList_Simple.First();
                            objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
                            if (boolDescribe)
                            {
                                objDlgAttribute_String = new dlg_Attribute_String("Description",objLocalConfig.Globals);
                                objDlgAttribute_String.ShowDialog(objParWindow);
                                if (objDlgAttribute_String.DialogResult == DialogResult.OK)
                                {
                                    strDescription = objDlgAttribute_String.Value;
                                }
                                else
                                {
                                    MessageBox.Show(objParWindow, "Bitte eine Beschreibung eingeben!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    objOItem_Result = objLocalConfig.Globals.LState_Error;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(objParWindow, "Bitte nur einen Logstate auswählen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            objOItem_Result = objLocalConfig.Globals.LState_Error;
                        }
                    }
                    else
                    {
                        MessageBox.Show(objParWindow, "Bitte nur einen Logstate auswählen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        objOItem_Result = objLocalConfig.Globals.LState_Error;
                    }
                }
                else
                {
                    MessageBox.Show(objParWindow, "Bitte nur einen Logstate auswählen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    objOItem_Result = objLocalConfig.Globals.LState_Error;
                }

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {

                       
                        objTransaction.ClearItems();
                            
                        objVersion = new clsOntologyItem
                        {
                            GUID = objLocalConfig.Globals.NewGUID,
                            Name = major + "." + minor + "." + build + "." + revision,
                            GUID_Parent = objLocalConfig.OItem_type_developmentversion.GUID,
                            Type = objLocalConfig.Globals.Type_Object
                        };

                        objOItem_Result = objTransaction.do_Transaction(objVersion);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            var objOAVersion__Major = DataWork_Versions.Rel_Version__Major(objVersion, major);
                            objOItem_Result = objTransaction.do_Transaction(objOAVersion__Major, true);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                var objOAVersion__Minor = DataWork_Versions.Rel_Version__Minor(objVersion, minor);
                                objOItem_Result = objTransaction.do_Transaction(objOAVersion__Minor, true);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    var objOAVersion__Build = DataWork_Versions.Rel_Version__Build(objVersion, build);
                                    objOItem_Result = objTransaction.do_Transaction(objOAVersion__Build, true);
                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        var objOAVersion__Revision = DataWork_Versions.Rel_Version__Revision(objVersion, revision);
                                        objOItem_Result = objTransaction.do_Transaction(objOAVersion__Revision, true);
                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            var Rel_Version_To_Ref = DataWork_Versions.Rel_Version_To_Ref(objVersion, objOItem_Ref, objLocalConfig.OItem_relationtype_isinstate);
                                            objOItem_Result = objTransaction.do_Transaction(Rel_Version_To_Ref, true);
                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                            {
                                                objOItem_Result = objLogManagement.log_Entry(DateTime.Now, objOItem_LogState, objLocalConfig.objUser, strDescription);
                                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                {
                                                    OItem_LogEntry = objLogManagement.OItem_LogEntry;

                                                    var Rel_LogEntry_To_Version = DataWork_Versions.Rel_LogEntry_To_Version(OItem_LogEntry, objVersion);
                                                    objOItem_Result = objTransaction.do_Transaction(Rel_LogEntry_To_Version, true);
                                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                    {
                                                        Major = major;
                                                        Minor = minor;
                                                        Build = build;
                                                        Revision = revision;
                                                    }
                                                }
                                                else
                                                {
                                                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
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
                
            }

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                MessageBox.Show(objParWindow, "Die Version konnte nicht gespeichert werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return objOItem_Result;
        }

        public clsOntologyItem get_VersionData()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            DataWork_Versions.GetData_Ref_To_Version();
            if (DataWork_Versions.OItem_Result_Versions_To_Refs.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                DataWork_Versions.GetData_VersionNumbers();
                if (DataWork_Versions.OItem_Result_Versions__VersionNumbers.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objVersions = DataWork_Versions.GetVersions(objOItem_Ref);
                    if (objVersions.Any())
                    {
                        objVersion = new clsOntologyItem
                            {
                                GUID = objVersions.First().ID_Version,
                                Name = objVersions.First().Name_Version,
                                GUID_Parent = objLocalConfig.OItem_type_developmentversion.GUID,
                                Type = objLocalConfig.Globals.Type_Object
                            };
                        Major = objVersions.First().Major ?? 0;
                        Minor = objVersions.First().Minor ?? 0;
                        Build = objVersions.First().Build ?? 0;
                        Revision = objVersions.First().Revision ?? 0;
                    }
                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                }
                

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
            DataWork_Versions = new clsDataWork_Versions(objLocalConfig);
            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objLogManagement = new clsLogManagement(objLocalConfig.Globals);
        }

    }
}
