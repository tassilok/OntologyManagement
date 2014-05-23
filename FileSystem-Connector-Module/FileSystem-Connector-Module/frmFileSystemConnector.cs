using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontology_Module;
using System.IO;
using Filesystem_Module;
using OntologyClasses.BaseClasses;
using Localization_Module;
using Typed_Tagging_Module;
using Media_Viewer_Module;
using Log_Module;

namespace FileSystem_Connector_Module
{
    public partial class frmFileSystemConnector : Form
    {
        private clsLocalConfig objLocalConfig;
        private clsArgumentParsing objArgumentParsing;

        private clsRelationConfig objRelationConfig;
        private clsTransaction objTransaction;

        private clsFileWork objFileWork;
        private clsBlobConnection objBlobConnection;

        private clsOntologyItem objOItem_FileSystemObject;

        private Localization_Module.clsLocalConfig objLocalConfig_Localization;
        private Typed_Tagging_Module.clsLocalConfig objLocalConfig_TypedTagging;
        private Media_Viewer_Module.clsLocalConfig objLocalConfig_MediaViewModule;
        private Log_Module.clsLocalConfig objLocalConfig_LogModule;

        private frmLocalizationModule objFrmLocalizationModule;
        private frmTypedTaggingModule objFrmTypedTaggingModule;
        private frmMediaViewerModule objFrmMediaViewerModule;
        private frmLogModule objFrmLogModule;
    
        private string strPath;

        public frmFileSystemConnector()
        {
            InitializeComponent();

            
            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
            
            
        }

        private void Initialize()
        {
            objLocalConfig_Localization = new Localization_Module.clsLocalConfig(objLocalConfig.Globals);
            objLocalConfig_TypedTagging = new Typed_Tagging_Module.clsLocalConfig(objLocalConfig.Globals);
            objLocalConfig_MediaViewModule = new Media_Viewer_Module.clsLocalConfig(objLocalConfig.Globals);
            objLocalConfig_LogModule = new Log_Module.clsLocalConfig(objLocalConfig_MediaViewModule.Globals);

            objRelationConfig = new clsRelationConfig(objLocalConfig_LogModule.Globals);
            objTransaction = new clsTransaction(objLocalConfig_LogModule.Globals);

            objArgumentParsing = new clsArgumentParsing(objLocalConfig.Globals, Environment.GetCommandLineArgs().ToList());
            if (objArgumentParsing.External != null && objArgumentParsing.External != "")
            {
                if (File.Exists(objArgumentParsing.External))
                {
                    strPath = objArgumentParsing.External;

                    if (strPath.StartsWith("\""))
                    {
                        strPath = strPath.Substring(1);
                    }

                    if (strPath.EndsWith("\""))
                    {
                        strPath = strPath.Substring(0, strPath.Length - 1);
                    }
                    strPath = UNCHelper.LocalToUNC(strPath);
                    objFileWork = new clsFileWork(objLocalConfig.Globals);
                    objBlobConnection = new clsBlobConnection(objFileWork.LocalConfig);
                    TestFileIntegration();



                    ExecuteFunction();
                }
                else
                {
                    MessageBox.Show(this, "The Filesystemobject cannot be found!", "Integration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                }
               
            }
           
        }

        private void TestFileIntegration()
        {
            var objOItem_Identity = objBlobConnection.SearchFileByIdentity(strPath);
            if (objOItem_Identity.GUID_Parent == objFileWork.LocalConfig.OItem_Type_File.GUID)
            {
                objOItem_FileSystemObject = objOItem_Identity;

            }
            else if (objOItem_Identity.GUID == objLocalConfig.Globals.LState_Error.GUID || 
                objOItem_Identity.GUID == objFileWork.LocalConfig.OItem_object_file_has_no_identity.GUID)
            {
                objOItem_FileSystemObject = objFileWork.get_FileSystemObject_By_Path(strPath, true);

                if (objOItem_FileSystemObject.GUID_Parent != objFileWork.LocalConfig.OItem_Type_File.GUID &&
                    objOItem_FileSystemObject.GUID_Parent != objFileWork.LocalConfig.OItem_type_Folder.GUID)
                {
                    MessageBox.Show(this, "The Filesystemobject cannot be referenced!", "Integration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);
                }

            }
            else
            {
                MessageBox.Show(this,"An Error ocured!","Error",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(-1);
            }
        }

        private void ExecuteFunction()
        {
            foreach (var function in objArgumentParsing.FunctionList)
            {
                if (function.GUID_Ontology == objLocalConfig_Localization.Id_Ontology)
                {
                    objFrmLocalizationModule = new frmLocalizationModule(objLocalConfig_Localization, objOItem_FileSystemObject);
                    objFrmLocalizationModule.ShowDialog(this);
                    Environment.Exit(0);
                }
                else if (function.GUID_Ontology == objLocalConfig_TypedTagging.Id_Ontology)
                {
                    objFrmTypedTaggingModule = new frmTypedTaggingModule(objLocalConfig_TypedTagging, objOItem_FileSystemObject);
                    objFrmTypedTaggingModule.ShowDialog(this);
                    Environment.Exit(0);
                }
                else if (function.GUID_Ontology == objLocalConfig_MediaViewModule.Id_Ontology)
                {
                    if (function.GUID_Function != null)
                    {
                        if (function.GUID_Function == objLocalConfig_MediaViewModule.OItem_Type_Images__Graphic_.GUID)
                        {
                            objFrmMediaViewerModule = new frmMediaViewerModule(objLocalConfig_MediaViewModule, objOItem_FileSystemObject, objLocalConfig_MediaViewModule.OItem_Type_Images__Graphic_);
                            objFrmMediaViewerModule.ShowDialog(this);
                            Environment.Exit(-1);
                        }
                        else if (function.GUID_Function == objLocalConfig_MediaViewModule.OItem_Type_Media_Item.GUID)
                        {
                            objFrmMediaViewerModule = new frmMediaViewerModule(objLocalConfig_MediaViewModule, objOItem_FileSystemObject, objLocalConfig_MediaViewModule.OItem_Type_Media_Item);
                            objFrmMediaViewerModule.ShowDialog(this);
                            Environment.Exit(-1);
                        }
                        else if (function.GUID_Function == objLocalConfig_MediaViewModule.OItem_Type_PDF_Documents.GUID)
                        {
                            objFrmMediaViewerModule = new frmMediaViewerModule(objLocalConfig_MediaViewModule, objOItem_FileSystemObject, objLocalConfig_MediaViewModule.OItem_Type_PDF_Documents);
                            objFrmMediaViewerModule.ShowDialog(this);
                            Environment.Exit(-1);
                        }
                        else
                        {
                            MessageBox.Show(this, "The function is not valid!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Environment.Exit(-1);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show(this,"The function is not valid!","Error!",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Environment.Exit(-1);
                    }
                    
                }
                else if (function.GUID_Ontology == objLocalConfig_LogModule.Id_Ontology)
                {
                    objFrmLogModule = new frmLogModule(objLocalConfig_LogModule);
                    objFrmLogModule.ShowDialog(this);
                    if (objFrmLogModule.DialogResult == DialogResult.OK)
                    {
                        objTransaction.ClearItems();
                        if (objFrmLogModule.OList_LogEntries.Any())
                        {
                            var objORel_LogEntry_To_FileSystemObject = objRelationConfig.Rel_ObjectRelation(objFrmLogModule.OList_LogEntries.First(),
                                objOItem_FileSystemObject,
                                objLocalConfig_LogModule.OItem_RelationType_belongsTo);

                            var objOItem_Result = objTransaction.do_Transaction(objORel_LogEntry_To_FileSystemObject);

                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                Environment.Exit(-1);
                            }
                            else
                            {
                                MessageBox.Show(this, "The Logentry cannot be set!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Environment.Exit(-1);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "The Logentry cannot be set!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Environment.Exit(-1);
                        }
                    }

               
                }
               
            }
            
            
        }
    }
}
