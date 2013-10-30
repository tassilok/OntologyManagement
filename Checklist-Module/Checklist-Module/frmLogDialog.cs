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

namespace Checklist_Module
{
    public partial class frmLogDialog : Form
    {
        private UserControl_Attribute_DateTime objUserControl_Attribute_DateTime;
        private UserControl_Attribute_String objUserControl_Attribute_String;

        public DateTime DateTimeStamp { get; private set; }
        public string Message { get; private set; }

        public frmLogDialog()
        {
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
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
    }
}
