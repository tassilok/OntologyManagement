using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Structure_Module;

namespace TextParser
{
    public partial class frmFieldParser : Form
    {
        private clsLocalConfig objLocalConfig;

        private SortableBindingList<clsSearchItem> searchItems = new SortableBindingList<clsSearchItem>();
        private SortableBindingList<Dictionary<string, object>> foundItems = new SortableBindingList<Dictionary<string,object>>();

        public frmFieldParser(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
        }

        private void Initialize()
        {
            dataGridView_SearchParams.DataSource = searchItems;
            dataGridView_SearchParams.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridView_Found.DataSource = foundItems;
            dataGridView_SearchParams.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
        }

        private void button_Search_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_Found_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dataGridView_SearchParams_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button_GetFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog_Source.ShowDialog(this) == DialogResult.OK)
            {
                textBox_File.Text = openFileDialog_Source.FileName;
                GetContentOfFile();
                foundItems.Clear();
            }
        }

        private void GetContentOfFile()
        {
            if (File.Exists(textBox_File.Text))
            {
                try
                {
                    TextReader textStream = File.OpenText(textBox_File.Text);
                    textBox_Content.Text = textStream.ReadToEnd();
                    textStream.Close();
                    tabControl1.SelectedTab = tabPage_Content;
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "The File cannot be opened!", "File-Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                }

            }
            else
            {
                MessageBox.Show(this, "The File doesen't exist!", "File-Error", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
            }
        }

        private void button_Search_Click_1(object sender, EventArgs e)
        {

        }
    }
}
