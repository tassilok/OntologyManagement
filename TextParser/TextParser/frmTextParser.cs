using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Structure_Module;
using System.Text.RegularExpressions;

namespace TextParser
{
    
    public partial class frmTextParser : Form
    {
        private SortableBindingList<clsSearchItem> searchItems = new SortableBindingList<clsSearchItem>();
        private SortableBindingList<clsFoundItem> foundItems = new SortableBindingList<clsFoundItem>(); 
        public frmTextParser()
        {
            InitializeComponent();

            dataGridView_SearchParams.DataSource = searchItems;
            dataGridView_SearchParams.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridView_Found.DataSource = foundItems;
            dataGridView_SearchParams.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
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

        private void button_Search_Click(object sender, EventArgs e)
        {
            foundItems.Clear();

            if (dataGridView_SearchParams.RowCount > 0 && textBox_Content.Text != "")
            {
                
                foreach (DataGridViewRow dataGridViewRow in dataGridView_SearchParams.Rows)
                {
                    var searchItem = (clsSearchItem) dataGridViewRow.DataBoundItem;

                    if (searchItem != null)
                    {
                        var strEntry = "";
                        var foundEntries = new List<FoundMatchEntry>();
                        var regexEntry = searchItem.EntryRegexPre ?? searchItem.EntryRegex ?? searchItem.EntryRegexPost;
                        var regexValue = searchItem.ValueRegexPre ?? searchItem.ValueRegex ?? searchItem.ValueRegexPost;

                        var matchColEntries = Regex.Matches(textBox_Content.Text, regexEntry);
                        var matchColValues = Regex.Matches(textBox_Content.Text, regexValue);

                        if (matchColEntries.Count > 0)
                        {
                            var doParse = false;
                            for (int i = 0; i < matchColEntries.Count; i++)
                            {
                                doParse = true;
                                strEntry = textBox_Content.Text.Substring(matchColEntries[i].Index+matchColEntries[i].Length);
                                if (strEntry.Contains('\n'))
                                {
                                    strEntry = strEntry.Substring(0, strEntry.IndexOf('\n'));
                                }
                                
                                if (searchItem.EntryRegexPost != null)
                                {
                                    var matchPost = Regex.Match(strEntry, searchItem.EntryRegexPost);
                                    if (matchPost.Success)
                                    {
                                        strEntry = strEntry.Substring(0, matchPost.Index);
                                    }
                                    else
                                    {
                                        doParse = false;
                                    }

                                    
                                }
                                if (doParse)
                                {
                                    if (strEntry != "" && searchItem.EntryRegex != null)
                                    {
                                        var matchEntry = Regex.Match(strEntry, searchItem.EntryRegex);
                                        if (matchEntry.Success)
                                        {
                                            strEntry = strEntry.Substring(matchEntry.Index, matchEntry.Length);
                                        }
                                        else
                                        {
                                            doParse = false;
                                        }
                                    }
                                    if (doParse)
                                    {
                                        
                                        foundEntries.Add(new FoundMatchEntry {Ix =  i, Entry = strEntry});
                                        
                                    }
                                    
                                }
                                
                            }
                            
                            for (int i = 0; i < foundEntries.Count; i++)
                            {
                                strEntry = foundEntries[i].Entry;
                                var ixEntry = matchColEntries[foundEntries[i].Ix].Index;
                                var ixNextEntry = 0;
                                var ixPreviousEntry = 0;
                                if (i < foundEntries.Count - 1)
                                {
                                    ixNextEntry = matchColEntries[foundEntries[i+1].Ix].Index;
                                }
                                else
                                {
                                    ixNextEntry = textBox_Content.Text.Length - 1;
                                }

                                if (i > 0)
                                {
                                    ixPreviousEntry = matchColEntries[foundEntries[i-1].Ix].Index;
                                }
                                var ixStartValue = 0;
                                var ixEndValue = 0;
                                if (searchItem.ValueFirst)
                                {

                                    ixStartValue = ixPreviousEntry;
                                    ixEndValue = ixEntry;

                                }
                                else
                                {
                                    ixStartValue = ixEntry;
                                    ixEndValue = ixNextEntry;
                                }

                                if (matchColValues.Count > 0)
                                {
                                    foreach (Match matchColValue in matchColValues)
                                    {
                                        doParse = true;
                                        if (matchColValue.Index >= ixStartValue && matchColValue.Index < ixEndValue)
                                        {
                                            var strValue = textBox_Content.Text.Substring(matchColValue.Index + matchColValue.Length);
                                            if (strValue.Contains('\n'))
                                            {
                                                strValue = strValue.Substring(0, strValue.IndexOf('\n'));
                                            }

                                            if (searchItem.ValueRegexPost != null)
                                            {
                                                var matchPost = Regex.Match(strValue, searchItem.ValueRegexPost);
                                                if (matchPost.Success)
                                                {
                                                    strValue = strValue.Substring(0, matchPost.Index);
                                                }
                                                else
                                                {
                                                    doParse = false;
                                                }


                                            }
                                            if (doParse)
                                            {
                                                if (strValue != "" && searchItem.ValueRegex != null)
                                                {
                                                    var matchValue = Regex.Match(strValue, searchItem.ValueRegex);
                                                    if (matchValue.Success)
                                                    {
                                                        strValue = strValue.Substring(matchValue.Index, matchValue.Length);
                                                    }
                                                }

                                                var isOk = false;
                                                if (searchItem.ValueDataType == "String")
                                                {
                                                    isOk = true;
                                                }
                                                else if (searchItem.ValueDataType == "Long")
                                                {
                                                    long test;
                                                    if (long.TryParse(strValue, out test))
                                                    {
                                                        isOk = true;
                                                    }
                                                }
                                                else if (searchItem.ValueDataType == "Double")
                                                {
                                                    double test;
                                                    if (double.TryParse(strValue, out test))
                                                    {
                                                        isOk = true;
                                                    }
                                                }
                                                else if (searchItem.ValueDataType == "DateTime")
                                                {
                                                    DateTime test;
                                                    if (DateTime.TryParse(strValue, out test))
                                                    {
                                                        isOk = true;
                                                    }
                                                }
                                                foundItems.Add(new clsFoundItem { FileName = textBox_File.Text, EntryName = searchItem.EntryName, Entry = strEntry, DataType = searchItem.ValueDataType, Value = strValue, IsOk = isOk });
                                            }


                                        }
                                    }
                                }
                               
                            }
                            

                        }
                        else
                        {
                            MessageBox.Show(this, "No Entries found", "Parse-Error", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                        }
                    }
                    
                    
                }
            }
            else
            {
                MessageBox.Show(this, "No Search-Params defined", "Definition-error", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
            }
        }

        private void dataGridView_SearchParams_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                if (e.Control)
                {
                    Clipboard.SetDataObject(dataGridView_SearchParams.GetClipboardContent());   
                }
            }
            
        }

        private void dataGridView_Found_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                if (e.Control)
                {
                    Clipboard.SetDataObject(dataGridView_Found.GetClipboardContent());
                }
            }
        }
    }

    public class FoundMatchEntry
    {
        public int Ix { get; set; }
        public string Entry { get; set; }
    }
}
