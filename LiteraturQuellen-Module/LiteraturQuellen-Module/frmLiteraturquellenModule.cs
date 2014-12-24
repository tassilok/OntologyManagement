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
using OntologyClasses.BaseClasses;
using Security_Module;

namespace LiteraturQuellen_Module
{
    public partial class frmLiteraturquellenModule : Form
    {
        private clsLocalConfig objLocalConfig;

        private UserControl_LiteraturQuelle objUserControl_LiteraturQuelle;
        private UserControl_InternetQuelle objUserControl_InternetQuelle;
        private UserControl_Buchquelle objUserControl_BuchQuelle;
        private UserControl_VideoQuelle objUserControl_VideoQuelle;
        private UserControl_EmailQuelle objUserControl_EmailQuelle;
        private frmAuthenticate objFrmAuthenticate;

        private clsArgumentParsing objArgumentParsing;

        private clsDBLevel objDBLevel_OItems;

        public List<clsLiteraturQuelle> OList_LiteraturQuellen;

        public bool Applyable { get; set; }

        public frmLiteraturquellenModule()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(new clsGlobals());
            Applyable = false;
            Initialize();
        }

        public frmLiteraturquellenModule(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            Applyable = true;
            Initialize();
        }

        private void ParseArguments()
        {
            var objArgumentParsing = new clsArgumentParsing(objLocalConfig.Globals, Environment.GetCommandLineArgs().ToList());

            if (!string.IsNullOrEmpty( objArgumentParsing.Session ))
            {
                var objOItem_Session = objDBLevel_OItems.GetOItem(objArgumentParsing.Session, objLocalConfig.Globals.Type_Object).Clone();

                if (objOItem_Session != null)
                {
                    objLocalConfig.OItem_Session = objOItem_Session;
                    var objSession = new clsSession(objLocalConfig.Globals);
                    objLocalConfig.OItem_RefItems = objSession.GetItems(objLocalConfig.OItem_Session, true);
                }
                
            }
            else if (objArgumentParsing.OList_Items.Any())
            {
                objLocalConfig.OItem_RefItems = new List<clsOntologyItem> { objArgumentParsing.OList_Items.First() };
            }

            if (objLocalConfig.OItem_RefItems != null)
            {
                if (objLocalConfig.OItem_RefItems.Count == 1)
                {
                    this.Text = "";
                    var objOItem = objLocalConfig.OItem_RefItems.First();
                    if (objOItem.Type == objLocalConfig.Globals.Type_Object)
                    {
                        var objClassItem = objDBLevel_OItems.GetOItem(objOItem.GUID_Parent, objLocalConfig.Globals.Type_Class);
                        if (objClassItem != null)
                        {
                            this.Text = objClassItem.Name;
                        }
                    }

                    if (!string.IsNullOrEmpty(this.Text))
                    {
                        this.Text += " \\ ";
                    }

                    this.Text += objOItem.Name;

                }
                else
                {
                    this.Text = "Multiple reference-items";
                }
            }
        }

        private void Initialize()
        {
            objDBLevel_OItems = new clsDBLevel(objLocalConfig.Globals);
            ParseArguments();
            if (objLocalConfig.User == null)
            {
                objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, true, frmAuthenticate.ERelateMode.User_To_Group,true);
                objFrmAuthenticate.ShowDialog(this);
                if (objFrmAuthenticate.DialogResult == System.Windows.Forms.DialogResult.OK)
                {

                    objLocalConfig.User = objFrmAuthenticate.OItem_User;
                    objLocalConfig.Group = objFrmAuthenticate.OItem_Group;
                }

            }
            
            if (objLocalConfig.User != null)
            {
                objUserControl_LiteraturQuelle = new UserControl_LiteraturQuelle(objLocalConfig);
                objUserControl_LiteraturQuelle.selectedQuelle += objUserControl_LiteraturQuelle_selectedQuelle;
                objUserControl_LiteraturQuelle.appliedQuelle += objUserControl_LiteraturQuelle_appliedQuelle;
                objUserControl_LiteraturQuelle.Applyable = Applyable;
                objUserControl_LiteraturQuelle.Dock = DockStyle.Fill;

                

                splitContainer1.Panel1.Controls.Add(objUserControl_LiteraturQuelle);
            }
            else
            {
                Environment.Exit(0);
            }

            
        }

        void objUserControl_LiteraturQuelle_appliedQuelle()
        {
            OList_LiteraturQuellen = objUserControl_LiteraturQuelle.OList_LiteraturQuellen;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        void objUserControl_LiteraturQuelle_selectedQuelle(clsLiteraturQuelle objLiteraturQuelle)
        {
            splitContainer1.Panel2.Controls.Clear();
            if (objLiteraturQuelle.ID_Class_Quelle == objLocalConfig.OItem_type_buch_quellenangabe.GUID)
            {
                if (objUserControl_BuchQuelle == null)
                {
                    objUserControl_BuchQuelle = new UserControl_Buchquelle(objLocalConfig);
                    objUserControl_BuchQuelle.Dock = DockStyle.Fill;
                    
                }

                splitContainer1.Panel2.Controls.Add(objUserControl_BuchQuelle);
                
                
                objUserControl_BuchQuelle.Initialize_BuchQuelle(new clsOntologyItem
                {
                    GUID = objLiteraturQuelle.ID_Quelle,
                    Name = objLiteraturQuelle.Name_Quelle,
                    GUID_Parent = objLiteraturQuelle.ID_Class_Quelle,
                    Type = objLocalConfig.Globals.Type_Object
                });

            }
            else if (objLiteraturQuelle.ID_Class_Quelle == objLocalConfig.OItem_type_email_quelle.GUID)
            {
                if (objUserControl_EmailQuelle == null)
                {
                    objUserControl_EmailQuelle = new UserControl_EmailQuelle(objLocalConfig);
                    objUserControl_EmailQuelle.Dock = DockStyle.Fill;
                    
                }

                splitContainer1.Panel2.Controls.Add(objUserControl_EmailQuelle);

                objUserControl_EmailQuelle.Initialize_Quelle(new clsOntologyItem
                {
                    GUID = objLiteraturQuelle.ID_Quelle,
                    Name = objLiteraturQuelle.Name_Quelle,
                    GUID_Parent = objLiteraturQuelle.ID_Class_Quelle,
                    Type = objLocalConfig.Globals.Type_Object
                },
                new clsOntologyItem
                {
                    GUID = objLiteraturQuelle.ID_LiteraturQuelle,
                    Name = objLiteraturQuelle.Name_LiteraturQuelle,
                    GUID_Parent = objLocalConfig.OItem_type_literarische_quelle.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                });
            }
            else if (objLiteraturQuelle.ID_Class_Quelle == objLocalConfig.OItem_type_internet_quellenangabe.GUID)
            {
                if (objUserControl_InternetQuelle == null)
                {
                    objUserControl_InternetQuelle = new UserControl_InternetQuelle(objLocalConfig);
                    objUserControl_InternetQuelle.Dock = DockStyle.Fill;
                }



                splitContainer1.Panel2.Controls.Add(objUserControl_InternetQuelle);
                objUserControl_InternetQuelle.Initialize_InternetQuelle(new clsOntologyItem
                {
                    GUID = objLiteraturQuelle.ID_Quelle,
                    Name = objLiteraturQuelle.Name_Quelle,
                    GUID_Parent = objLiteraturQuelle.ID_Class_Quelle,
                    Type = objLocalConfig.Globals.Type_Object
                });
            }
            else if (objLiteraturQuelle.ID_Class_Quelle == objLocalConfig.OItem_type_video_quelle.GUID)
            {
                if (objUserControl_VideoQuelle == null)
                {
                    objUserControl_VideoQuelle = new UserControl_VideoQuelle(objLocalConfig);
                    objUserControl_VideoQuelle.Dock = DockStyle.Fill;
                }



                splitContainer1.Panel2.Controls.Add(objUserControl_VideoQuelle);
                objUserControl_VideoQuelle.Initialize_VideoQuelle(new clsOntologyItem
                {
                    GUID = objLiteraturQuelle.ID_Quelle,
                    Name = objLiteraturQuelle.Name_Quelle,
                    GUID_Parent = objLiteraturQuelle.ID_Class_Quelle,
                    Type = objLocalConfig.Globals.Type_Object
                });
            }
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
