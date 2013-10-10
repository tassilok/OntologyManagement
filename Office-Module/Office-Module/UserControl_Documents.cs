using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontolog_Module;
using Filesystem_Module;
using System.IO;
using OntologyClasses.BaseClasses;

namespace Office_Module
{
    public partial class UserControl_Documents : UserControl
    {
        private clsLocalConfig objLocalConfig;
        private clsOntologyItem objOItem_Ref;
        private clsBlobConnection objBlobConnection;
        private clsFileWork objFileWork;
        private clsDocumentation objDocumentation;
        private clsTransaction objTransaction_Documents;
        
        public UserControl_Documents(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            InitializeComponent();
            initialize();
            ConfigureControls();
           
        }

        private void initialize()
        {
            objBlobConnection = new clsBlobConnection(objLocalConfig.Globals);
            objFileWork = new clsFileWork(objLocalConfig.Globals);
            objDocumentation = new clsDocumentation(objLocalConfig.Globals);
        }

        public void Initialize_Documents(clsDataWork_Documents objDataWork_Documents, clsOntologyItem OItem_Ref)
        {
            objLocalConfig.DataWork_Documents = objDataWork_Documents;

            objOItem_Ref = OItem_Ref;

            if (objOItem_Ref != null)
            {

                dataGridView_Documents.DataSource = new SortableBindingList<clsDocument>((from obj in objLocalConfig.DataWork_Documents.OList_Documents
                                                                                         where obj.ID_Ref == objOItem_Ref.GUID
                                                                                         select obj).ToList());
            }
            else
            {
                dataGridView_Documents.DataSource = null;
            }

            dataGridView_Documents.Columns[0].Visible = false;
            dataGridView_Documents.Columns[1].Visible = false;
            dataGridView_Documents.Columns[2].Visible = false;
            dataGridView_Documents.Columns[3].Visible = false;
            dataGridView_Documents.Columns[4].Visible = true;
            dataGridView_Documents.Columns[5].Visible = false;
            dataGridView_Documents.Columns[6].Visible = false;
            dataGridView_Documents.Columns[7].Visible = false;
            dataGridView_Documents.Columns[8].Visible = false;
            dataGridView_Documents.Columns[9].Visible = false;
            dataGridView_Documents.Columns[10].Visible = false;
            dataGridView_Documents.Columns[11].Visible = false;
            dataGridView_Documents.Columns[12].Visible = false;
            dataGridView_Documents.Columns[13].Visible = false;
            dataGridView_Documents.Columns[14].Visible = false;

            ConfigureControls();
        }

        private void ConfigureControls()
        {
            button_Delete.Enabled = false;
            button_Open.Enabled = false;

            if (objOItem_Ref != null && dataGridView_Documents.Rows.Count == 0)
            {
                button_Open.Enabled = true;
            }
            else
            {
                if (dataGridView_Documents.SelectedRows.Count > 0)
                {
                    button_Delete.Enabled = true;

                    if (dataGridView_Documents.SelectedRows.Count == 1)
                    {
                        button_Open.Enabled = true;
                    }
                }
            }
        }

        private void dataGridView_Documents_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ConfigureControls();
        }

        private void dataGridView_Documents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ConfigureControls();
        }

        private void button_Open_Click(object sender, EventArgs e)
        {

            if (dataGridView_Documents.Rows.Count > 0)
            {
                var objDGVR = dataGridView_Documents.SelectedRows[0];
                var objOList_Document = (from objDoc in objLocalConfig.DataWork_Documents.OList_Documents
                                         where objDoc.ID_Document == objDGVR.Cells["ID_Document"].Value.ToString()
                                         select objDoc).ToList();

                if (objOList_Document.Any())
                {
                    var objOItem_Document_Opened = objDocumentation.open_Document(objOList_Document.First());

                    if (objOItem_Document_Opened.GUID == objLocalConfig.Globals.LState_Error.GUID)
                    {
                        MessageBox.Show("Das Dokument konnte nicht geöffnet werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Das Dokument konnte nicht geöffnet werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                objOItem_Ref = objLocalConfig.DataWork_Documents.GetOntologyItem_Object(objOItem_Ref.GUID);

                if (objOItem_Ref.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
                {
                    MessageBox.Show("Das Dokument konnte nicht geöffnet werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (objOItem_Ref.GUID == objLocalConfig.Globals.LState_Error.GUID)
                {
                    MessageBox.Show("Das Dokument konnte nicht geöffnet werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    var objOItem_Document_Opened = objDocumentation.open_Document(new clsDocument
                    {
                        ID_Ref = objOItem_Ref.GUID,
                        Name_Ref = objOItem_Ref.Name,
                        ID_Parent_Ref = objOItem_Ref.GUID_Parent,
                        Ontology_Ref = objOItem_Ref.Type
                    });

                    if (objOItem_Document_Opened.GUID == objLocalConfig.Globals.LState_Error.GUID)
                    {
                        MessageBox.Show("Das Dokument konnte nicht geöffnet werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                
            }

            Initialize_Documents(objLocalConfig.DataWork_Documents, objOItem_Ref);
            
        }

        
    }
}
