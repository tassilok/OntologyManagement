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
using Security_Module;

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

        private Media_Viewer_Module.clsLocalConfig objLocalConfig_MediaViewerModule;

        private frmAuthenticate objFrmAuthenticate;
        private frmLocalizingModuleSingle objFrmLocalizationModuleSingle;
        private frmTypedTaggingSingle objFrmTypedTaggingSingle;
        private frmSingleViewEmbedded objFrmSingleViewEmbedded;
        private frmLogModule objFrmLogModule;

        private UserControl_CreateSendTo objUserControl_CreateSendTo;
    
        private string strPath;

        public frmFileSystemConnector()
        {
            InitializeComponent();

            
            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
            
            
        }

        private void Initialize()
        {

            if (objLocalConfig.User == null || objLocalConfig.Group == null)
            {
                objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, true, frmAuthenticate.ERelateMode.User_To_Group, true);
                objFrmAuthenticate.ShowDialog(this);
                if (objFrmAuthenticate.DialogResult == DialogResult.OK)
                {
                    objLocalConfig.User = objFrmAuthenticate.OItem_User;
                    objLocalConfig.Group = objFrmAuthenticate.OItem_Group;

                    
                }
             
            }

            if (objLocalConfig.User != null && objLocalConfig.Group != null)
            {
                objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
                objTransaction = new clsTransaction(objLocalConfig.Globals);

                objFileWork = new clsFileWork(objLocalConfig.Globals);
                objBlobConnection = new clsBlobConnection(objFileWork.LocalConfig);

                

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

                        TestFileIntegration();


                        ExecuteFunction();
                    }
                    else
                    {
                        MessageBox.Show(this, "The Filesystemobject cannot be found!", "Integration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(-1);
                    }

                }
                else
                {
                    objLocalConfig_MediaViewerModule = new Media_Viewer_Module.clsLocalConfig(objLocalConfig.Globals);
                    objLocalConfig_MediaViewerModule.OItem_User = objLocalConfig.User;
                    objUserControl_CreateSendTo = new UserControl_CreateSendTo(objLocalConfig, objLocalConfig_MediaViewerModule);
                    objUserControl_CreateSendTo.Dock = DockStyle.Fill;
                    toolStripContainer1.ContentPanel.Controls.Add(objUserControl_CreateSendTo);
                }
            }
            else
            {
                Environment.Exit(-1);
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
                if (function.GUID_DestOntology == null)
                {
                    if (function.GUID_Function == objLocalConfig.OItem_object_localizing_manager.GUID)
                    {
                        objFrmLocalizationModuleSingle = new frmLocalizingModuleSingle(objLocalConfig.Globals,
                                                                                       objOItem_FileSystemObject);
                        objFrmLocalizationModuleSingle.ShowDialog(this);
                        Environment.Exit(0);
                    }
                    else if (function.GUID_Function == objLocalConfig.OItem_object_typed_tagging_module.GUID)
                    {
                        objFrmTypedTaggingSingle = new frmTypedTaggingSingle(objLocalConfig.Globals, objLocalConfig.User,
                                                                             objLocalConfig.Group,
                                                                             objOItem_FileSystemObject);
                        objFrmTypedTaggingSingle.ShowDialog(this);
                        Environment.Exit(0);
                    }
                    else if (function.GUID_Function == objLocalConfig.OItem_object_log_manager.GUID)
                    {
                        objFrmLogModule = new frmLogModule(objLocalConfig.Globals, objLocalConfig.User);
                        objFrmLogModule.ShowDialog(this);
                        if (objFrmLogModule.DialogResult == DialogResult.OK)
                        {
                            objTransaction.ClearItems();
                            if (objFrmLogModule.OList_LogEntries.Any())
                            {
                                var objORel_LogEntry_To_FileSystemObject =
                                    objRelationConfig.Rel_ObjectRelation(objFrmLogModule.OList_LogEntries.First(),
                                                                         objOItem_FileSystemObject,
                                                                         objLocalConfig.Globals.RelationType_belongsTo);

                                var objOItem_Result = objTransaction.do_Transaction(objORel_LogEntry_To_FileSystemObject);

                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    MessageBox.Show(this, "The Logentry cannot be set!", "Error!", MessageBoxButtons.OK,
                                                    MessageBoxIcon.Exclamation);
                                    Environment.Exit(-1);
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "The Logentry cannot be set!", "Error!", MessageBoxButtons.OK,
                                                MessageBoxIcon.Exclamation);
                                Environment.Exit(-1);
                            }
                        }
                    }
                }
                else
                {
                    if (function.GUID_DestOntology == objLocalConfig.OItem_object_mediaviewer_module.GUID)
                    {
                        objLocalConfig_MediaViewerModule = new Media_Viewer_Module.clsLocalConfig(objLocalConfig.Globals);
                        objLocalConfig_MediaViewerModule.OItem_User = objLocalConfig.User;
                        if (function.GUID_Function != null)
                        {
                            if (function.GUID_Function == objLocalConfig_MediaViewerModule.OItem_Type_Images__Graphic_.GUID)
                            {
                                objFrmSingleViewEmbedded = new frmSingleViewEmbedded(objLocalConfig_MediaViewerModule, objLocalConfig_MediaViewerModule.OItem_Type_Images__Graphic_);
                                objFrmSingleViewEmbedded.InitializeViewer(objOItem_FileSystemObject);
                                objFrmSingleViewEmbedded.ShowDialog(this);
                                Environment.Exit(-1);
                            }
                            else if (function.GUID_Function == objLocalConfig_MediaViewerModule.OItem_Type_Media_Item.GUID)
                            {
                                objFrmSingleViewEmbedded = new frmSingleViewEmbedded(objLocalConfig_MediaViewerModule, objLocalConfig_MediaViewerModule.OItem_Type_Media_Item);
                                objFrmSingleViewEmbedded.InitializeViewer(objOItem_FileSystemObject);
                                objFrmSingleViewEmbedded.ShowDialog(this);
                                Environment.Exit(-1);
                            }
                            else if (function.GUID_Function == objLocalConfig_MediaViewerModule.OItem_Type_PDF_Documents.GUID)
                            {
                                objFrmSingleViewEmbedded = new frmSingleViewEmbedded(objLocalConfig_MediaViewerModule, objLocalConfig_MediaViewerModule.OItem_Type_PDF_Documents);
                                objFrmSingleViewEmbedded.InitializeViewer(objOItem_FileSystemObject);
                                objFrmSingleViewEmbedded.ShowDialog(this);
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
                    else
                    {
                        Environment.Exit(0);
                    }

               
                }
               
            }
            
            
        }
    }
}
