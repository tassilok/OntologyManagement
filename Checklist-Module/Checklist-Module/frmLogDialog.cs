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
using Hierarchichal_Splitter_Module;

namespace Checklist_Module
{
    public partial class frmLogDialog : Form
    {
        private UserControl_Attribute_DateTime objUserControl_Attribute_DateTime;
        private UserControl_Attribute_String objUserControl_Attribute_String;

        private frmMain objFrm_OntologyModule;
        private frmHierarchicalSplitter objFrm_HierarchicalSpliter;

        private clsLocalConfig objLocalConfig;

        public DateTime DateTimeStamp { get; private set; }
        public string Message { get; private set; }

        public clsOntologyItem OItem_Related { get; private set; }

        public frmLogDialog(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            OItem_Related = null;
            toolStripSplitButton_ItemGetter.Text = toolStripMenuItem_OntologyItem.Text;

            objUserControl_Attribute_DateTime = new UserControl_Attribute_DateTime();
            objUserControl_Attribute_DateTime.Dock = DockStyle.Fill;
            panel_DateTime.Controls.Add(objUserControl_Attribute_DateTime);
            objUserControl_Attribute_DateTime.Value = DateTime.Now;

            objUserControl_Attribute_String = new UserControl_Attribute_String();
            objUserControl_Attribute_String.Dock = DockStyle.Fill;
            panel_String.Controls.Add(objUserControl_Attribute_String);

        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void toolStripButton_OK_Click(object sender, EventArgs e)
        {
            DateTimeStamp = objUserControl_Attribute_DateTime.Value;
            Message = objUserControl_Attribute_String.Value;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void toolStripSplitButton_ItemGetter_ButtonClick(object sender, EventArgs e)
        {
            GetOItem();
        }

        private void GetOItem()
        {
            if (toolStripSplitButton_ItemGetter.Text == toolStripMenuItem_OntologyItem.Text)
            {
                objFrm_OntologyModule = new frmMain(objLocalConfig.Globals);
                objFrm_OntologyModule.ShowDialog(this);

                if (objFrm_OntologyModule.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    if (objFrm_OntologyModule.OList_Simple.Count == 1)
                    {
                        OItem_Related = objFrm_OntologyModule.OList_Simple.First().Clone();
                        toolStripTextBox_OntologyItem.Text = OItem_Related.Type + ": " + OItem_Related.Name;
                        toolStripButton_Clear.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show(this, "Wählen Sie bitte nur ein Ontology-Item aus!", "1 Item!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (toolStripSplitButton_ItemGetter.Text == toolStripMenuItem_HierarchicalOItem.Text)
            {
                objFrm_HierarchicalSpliter = new frmHierarchicalSplitter(objLocalConfig.Globals);
                objFrm_HierarchicalSpliter.ShowDialog(this);
                if (objFrm_HierarchicalSpliter.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    OItem_Related = objFrm_HierarchicalSpliter.OItem_Selected;
                    toolStripTextBox_OntologyItem.Text = OItem_Related.Type + OItem_Related.Name;
                    objUserControl_Attribute_String.Value = objUserControl_Attribute_String.Value + OItem_Related.Additional1;
                }
            }
        }

        private void toolStripButton_Clear_Click(object sender, EventArgs e)
        {
            OItem_Related = null;
            toolStripTextBox_OntologyItem.Text = "";
        }

        private void toolStripMenuItem_OntologyItem_Click(object sender, EventArgs e)
        {
            toolStripSplitButton_ItemGetter.Text = toolStripMenuItem_OntologyItem.Text;
            GetOItem();
        }

        private void toolStripMenuItem_HierarchicalOItem_Click(object sender, EventArgs e)
        {
            toolStripSplitButton_ItemGetter.Text = toolStripMenuItem_HierarchicalOItem.Text;
            GetOItem();
        }
    }
}
