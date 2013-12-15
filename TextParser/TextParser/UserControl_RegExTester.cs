using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Structure_Module;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using System.Text.RegularExpressions;
using System.IO;

namespace TextParser
{
    public partial class UserControl_RegExTester : UserControl
    {
        private SortableBindingList<clsRegExFilter> regExFilters;

        private clsLocalConfig objLocalConfig;

        private clsDataWork_FieldParser objDataWork_FieldParser;
        private clsDatawork_RegExFilter objDataWork_RegExFilter;

        private frmRegExFilter objFrmRegExFilter;
        private frmMain objFrmOntologyEditor;

        private clsOntologyItem objOItem_Field;
        private clsObjectAtt objOAItem_PrePattern;
        private clsObjectAtt objOAItem_MainPattern;
        private clsObjectAtt objOAItem_PostPattern;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        private List<clsSelection> objSelections = new List<clsSelection>();

        public void SetContentByFileStream(FileStream fs)
        {
            TextReader textReader = new StreamReader(fs);
            richTextBox_Text.Text = textReader.ReadToEnd();
            textReader.Close();
            parseText();
        }

        public void SetContent(string content)
        {
            richTextBox_Text.Text = content;
            parseText();
        }


        public void ClearControls()
        {
            textBox_Field.Text = "";
            button_AddField.Enabled = false;
            textBox_RegExMain.ReadOnly = true;
            textBox_RegExMain.Text = "";
            button_AdRegexMain.Enabled = false;
            textBox_RegExPost.ReadOnly = true;
            textBox_RegExPost.Text = "";
            button_AddRegExPost.Enabled = false;
            textBox_RegexPre.ReadOnly = true;
            textBox_RegexPre.Text = "";
            button_AddRegexPre.Enabled = false;
            dataGridView_Filter.Enabled = false;
            dataGridView_Filter.DataSource = null;
            richTextBox_Text.ReadOnly = true;
            button_RemoveMarked.Enabled = false;
            button_RemoveUnmarked.Enabled = false;
            button_CopyMarked.Enabled = false;
        }

        public void SetContentByFilePath(string path)
        {
            try
            {
                TextReader textReader = new StreamReader(path);
                richTextBox_Text.Text = textReader.ReadToEnd();
                textReader.Close();
                parseText();
            }
            catch (Exception)
            {

                MessageBox.Show(this, "Die Datei konnte nicht geöffnet werden!", "Fehler!", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            
        }

        public UserControl_RegExTester(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            Initialize();
        }

        public UserControl_RegExTester(clsGlobals globals)
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(globals);
            Initialize();
        }

        private void Initialize()
        {
            objOItem_Field = objLocalConfig.OItem_object_temporary_regular_expression.Clone();
            objDataWork_FieldParser = new clsDataWork_FieldParser(objLocalConfig);
            objDataWork_RegExFilter = new clsDatawork_RegExFilter(objLocalConfig);

            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);

            ClearControls();
        }

        private void FillFilterGrid()
        {
            regExFilters = null;
            if (objOItem_Field != null)
            {
                regExFilters = new SortableBindingList<clsRegExFilter>(objDataWork_RegExFilter.GetData_FiltersOfField(objOItem_Field));
                dataGridView_Filter.DataSource = regExFilters;
                dataGridView_Filter.Columns[0].Visible = false;
                dataGridView_Filter.Columns[2].Visible = false;
                dataGridView_Filter.Columns[4].Visible = false;
                dataGridView_Filter.Columns[5].Visible = false;
                dataGridView_Filter.Columns[6].Visible = false;

            }
            else
            {
                dataGridView_Filter.DataSource = null;

            }
            
        }

        public void Initialize_Field(clsOntologyItem OItem_Field = null)
        {
            ClearControls();
            if (OItem_Field != null)
            {
                objOItem_Field = OItem_Field;
            }

            textBox_Field.Text = objOItem_Field.Name;

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            objOAItem_PrePattern = SyncPatternOfField(objLocalConfig.OItem_relationtype_pre, "", false);

            if (objOAItem_PrePattern != null)
            {
                objOAItem_MainPattern = SyncPatternOfField(objLocalConfig.OItem_relationtype_main, "", false);

                if (objOAItem_MainPattern != null)
                {
                    objOAItem_PostPattern = SyncPatternOfField(objLocalConfig.OItem_relationtype_posts, "", false);

                    objOItem_Result = objOAItem_PostPattern != null ? objLocalConfig.Globals.LState_Success.Clone() : objLocalConfig.Globals.LState_Error.Clone();
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

            
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                throw new Exception("Daten konnten nicht geladen werden!");
            }
            else
            {
                
                textBox_RegexPre.Text = objOAItem_PrePattern.Val_String;
                textBox_RegExMain.Text = objOAItem_MainPattern.Val_String;
                textBox_RegExPost.Text = objOAItem_PostPattern.Val_String;

                button_AddField.Enabled = true;
                textBox_RegExMain.ReadOnly = false;
                button_AdRegexMain.Enabled = true;
                textBox_RegExPost.ReadOnly = false;
                button_AddRegExPost.Enabled = true;
                textBox_RegexPre.ReadOnly = false;
                button_AddRegexPre.Enabled = true;
                dataGridView_Filter.Enabled = true;
                
            }

            FillFilterGrid();
        }

        private clsObjectAtt SyncPatternOfField(clsOntologyItem OItem_RelationType, string pattern, bool boolChange)
        {
            clsObjectAtt objOAPattern = null;

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            objOAPattern = objDataWork_FieldParser.GetRegexOfField(objOItem_Field,
                                                                           OItem_RelationType);

            if (objOAPattern == null)
            {
                objOItem_Result = SavePatternOfField(OItem_RelationType,
                    pattern);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOAPattern = objDataWork_FieldParser.GetRegexOfField(objOItem_Field,
                                                                           OItem_RelationType);
                }
            }
            else
            {
                if (boolChange && objOAPattern.Val_String != pattern)
                {
                    objTransaction.ClearItems();
                    objOItem_Result = SavePatternOfField(OItem_RelationType, pattern);

                }
            }



            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID) return null;

            return objOAPattern;
        }

        private clsOntologyItem SavePatternOfField(clsOntologyItem OItem_RelationType, string pattern)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Nothing.Clone();
            if (objOItem_Field != null)
            {
                var objOItem_Pattern = objDataWork_FieldParser.GetPatternByPattern(pattern);

                if (objOItem_Pattern == null)
                {
                   objOItem_Pattern = new clsOntologyItem
                    {
                        GUID = objLocalConfig.Globals.NewGUID,
                        Name = pattern.Length == 0 ? "empty" : pattern.Length > 255 ? pattern.Substring(0, 254) : pattern,
                        GUID_Parent = objLocalConfig.OItem_class_regular_expressions.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    objOItem_Result = objTransaction.do_Transaction(objOItem_Pattern);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var objOAR_Reg = objRelationConfig.Rel_ObjectAttribute(objOItem_Pattern,
                                                                               objLocalConfig
                                                                                   .OItem_attributetype_regex,
                                                                               pattern);
                        objOItem_Result = objTransaction.do_Transaction(objOAR_Reg, true);

                    }
                }

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID || 
                    objOItem_Result.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
                {
                    var objORel_Field_To_Pattern = objRelationConfig.Rel_ObjectRelation(objOItem_Field, objOItem_Pattern,
                                                                                OItem_RelationType);

                    objOItem_Result = objTransaction.do_Transaction(objORel_Field_To_Pattern, true);
                }

                

            }

            return objOItem_Result;

        }

        private void richTextBox_Text_TextChanged(object sender, EventArgs e)
        {
            timer_RegExParse.Stop();

            if (richTextBox_Text.ReadOnly) return;

            timer_RegExParse.Start();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objFrmRegExFilter = new frmRegExFilter(objLocalConfig);
            objFrmRegExFilter.ShowDialog(this);
            if (objFrmRegExFilter.DialogResult == DialogResult.OK)
            {
                var regExFilter = objFrmRegExFilter.RegExFilter;

                if (objOItem_Field != null)
                {
                    var objOItem_Filter = new clsOntologyItem
                    {
                        GUID = regExFilter.ID_Filter,
                        Name = regExFilter.Name_Filter,
                        GUID_Parent = objLocalConfig.OItem_class_regex_field_filter.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    var objRelationType = new clsOntologyItem 
                    {
                        GUID = regExFilter.ID_Regex_RelationType,
                        Name = regExFilter.Name_Regex_RelationType,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    var objField_To_Filter = objRelationConfig.Rel_ObjectRelation(objOItem_Field, objOItem_Filter, objRelationType);
                    objTransaction.ClearItems();
                    var objOItem_Result = objTransaction.do_Transaction(objField_To_Filter);

                    FillFilterGrid();
                }
            }
        }

        private void contextMenuStrip_Filter_Opening(object sender, CancelEventArgs e)
        {
            removeToolStripMenuItem.Enabled = (dataGridView_Filter.SelectedRows.Count > 0);
        }

        private void textBox_RegexPre_TextChanged(object sender, EventArgs e)
        {
            timer_RegExPre.Stop();
            timer_RegExParse.Stop();
            timer_RegExParse.Start();

            if (textBox_RegexPre.ReadOnly) return;
            
            timer_RegExPre.Start();
        }

        private void textBox_RegExMain_TextChanged(object sender, EventArgs e)
        {
            timer_RegExMain.Stop();
            timer_RegExParse.Stop();
            timer_RegExParse.Start();

            if (textBox_RegExMain.ReadOnly) return;

            timer_RegExMain.Start();
        }

        private void textBox_RegExPost_TextChanged(object sender, EventArgs e)
        {
            timer_RegExPost.Stop();
            timer_RegExParse.Stop();
            timer_RegExParse.Start();

            if (textBox_RegExPost.ReadOnly) return;

            timer_RegExPost.Start();
        }

        private void timer_RegExPre_Tick(object sender, EventArgs e)
        {
            timer_RegExPre.Stop();
            var objOAItem_Pattern = SyncPatternOfField(objLocalConfig.OItem_relationtype_pre,
                                                     textBox_RegexPre.Text,
                                                     true);

            if (objOAItem_Pattern != null)
            {
                objOAItem_PrePattern = objOAItem_Pattern;
            }
            else
            {
                MessageBox.Show(this, "Der Regex konnte nicht gespeichert werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox_RegexPre.ReadOnly = true;
                textBox_RegexPre.Text = objOAItem_PrePattern.Val_String;
                textBox_RegexPre.ReadOnly = false;
            }

        }

        private void timer_RegExMain_Tick(object sender, EventArgs e)
        {
            timer_RegExMain.Stop();

            var objOAItem_Pattern = SyncPatternOfField(objLocalConfig.OItem_relationtype_main,
                                                     textBox_RegExMain.Text,
                                                     true);

            if (objOAItem_Pattern != null)
            {
                objOAItem_MainPattern = objOAItem_Pattern;
            }
            else
            {
                MessageBox.Show(this, "Der Regex konnte nicht gespeichert werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox_RegExMain.ReadOnly = true;
                textBox_RegExMain.Text = objOAItem_MainPattern.Val_String;
                textBox_RegExMain.ReadOnly = false;
            }
        }

        private void timer_RegExPost_Tick(object sender, EventArgs e)
        {
            timer_RegExPost.Stop();

            var objOAItem_Pattern = SyncPatternOfField(objLocalConfig.OItem_relationtype_posts,
                                                     textBox_RegExPost.Text,
                                                     true);

            if (objOAItem_Pattern != null)
            {
                objOAItem_PostPattern = objOAItem_Pattern;
            }
            else
            {
                MessageBox.Show(this, "Der Regex konnte nicht gespeichert werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox_RegExPost.ReadOnly = true;
                textBox_RegExPost.Text = objOAItem_PostPattern.Val_String;
                textBox_RegExPost.ReadOnly = false;
            }
        }

        private void timer_RegExParse_Tick(object sender, EventArgs e)
        {
            timer_RegExParse.Stop();

            if ((textBox_RegexPre.Text != "" ||
                 textBox_RegExMain.Text != "" ||
                 textBox_RegExPost.Text != "") &&
                richTextBox_Text.Text != "")
            {
                parseText();
            }
            
        }

        private void parseText()
        {
            var boolRegExPre = false;
            var boolRegExMain = false;
            var boolRegExPost = false;

            objSelections.Clear();

            richTextBox_Text.ReadOnly = true;
            try
            {
                regExFilters = (SortableBindingList<clsRegExFilter>) dataGridView_Filter.DataSource;
                var preEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_pre.GUID && p.Equal == true).ToList();
                var preNotEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_pre.GUID && p.Equal == false).ToList();
                var mainEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_main.GUID && p.Equal == true).ToList();
                var mainNotEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_main.GUID && p.Equal == false).ToList();
                var postEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_posts.GUID && p.Equal == true).ToList();
                var postNotEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_posts.GUID && p.Equal == false).ToList();

                richTextBox_Text.SelectionStart = 0;
                richTextBox_Text.SelectionLength = richTextBox_Text.TextLength;
                richTextBox_Text.SelectionBackColor = richTextBox_Text.BackColor;

                Regex objRegEx_Pre = null;
                Regex objRegEx_Main = null;
                Regex objRegEx_Post = null;

                MatchCollection objRegEx_Pre_Matches = null;
                MatchCollection objRegEx_Main_Matches = null;
                MatchCollection objRegEx_Post_Matches = null;

                if (textBox_RegexPre.Text != "")
                {
                    objRegEx_Pre = new Regex(textBox_RegexPre.Text);
                }
                    
                if (textBox_RegExMain.Text != "")
                {
                    objRegEx_Main = new Regex(textBox_RegExMain.Text);
                }
                    
                if (textBox_RegExPost.Text != "")
                {
                    objRegEx_Post = new Regex(textBox_RegExPost.Text);
                }

                boolRegExPre = true;
                if (textBox_RegexPre.Text != "")
                {
                    objRegEx_Pre_Matches = objRegEx_Pre.Matches(richTextBox_Text.Text);
                }
                else
                {
                    boolRegExMain = true;
                    if (textBox_RegExMain.Text != "")
                    {
                        objRegEx_Main_Matches = objRegEx_Main.Matches(richTextBox_Text.Text);
                    }

                    boolRegExPost = true;
                    if (textBox_RegExPost.Text != "")
                    {
                        objRegEx_Post_Matches = objRegEx_Post.Matches(richTextBox_Text.Text);
                    }

                }

                
            
            

            

                if (objRegEx_Pre_Matches != null)
                {
                    for (int i = 0; i < objRegEx_Pre_Matches.Count - 1; i++)
                    {
                        richTextBox_Text.SelectionStart = 0;
                        richTextBox_Text.SelectionLength = 0;
                        
                        var text = richTextBox_Text.Text.Substring(objRegEx_Pre_Matches[i].Index,objRegEx_Pre_Matches[i].Length);
                        if (!preEqualFilters.Any(p => Regex.Match(text, p.Filter).Success))
                        {
                            var parse = true;
                            if (preNotEqualFilters.Any())
                            {
                                if (!preNotEqualFilters.Any(p => Regex.Match(text, p.Filter).Success))
                                {
                                    parse = false;
                                }
                            }
                            if (parse)
                            {
                                var ixStart = objRegEx_Pre_Matches[i].Index + objRegEx_Pre_Matches[i].Length;
                                var ixEnd = ixStart;
                                if (i < objRegEx_Pre_Matches.Count)
                                {
                                    ixEnd = objRegEx_Pre_Matches[i + 1].Index;
                                }
                                else
                                {
                                    ixEnd = richTextBox_Text.TextLength - 1;
                                }

                                richTextBox_Text.SelectionStart = ixStart;
                                richTextBox_Text.SelectionLength = ixEnd;    
                            }
                            
                        }

                        

                        
                        
                        if (objRegEx_Post != null)
                        {
                            if (richTextBox_Text.SelectionLength > 0)
                            {
                                
                                objRegEx_Post_Matches = objRegEx_Post.Matches(richTextBox_Text.SelectedText);
                                if (objRegEx_Post_Matches.Count > 0)
                                {
                                    var text1 = richTextBox_Text.Text.Substring(objRegEx_Post_Matches[0].Index, objRegEx_Post_Matches[0].Length);
                                    if (!postEqualFilters.Any(p => Regex.Match(text, p.Filter).Success))
                                    {
                                        var parse = true;
                                        if (preNotEqualFilters.Any())
                                        {
                                            if (!postNotEqualFilters.Any(p => Regex.Match(text, p.Filter).Success))
                                            {
                                                parse = false;
                                            }
                                        }
                                        if (parse)
                                        {
                                            richTextBox_Text.SelectionLength = objRegEx_Post_Matches[0].Index;
                                        }
                                        
                                    }
                                    
                                }
                                else
                                {
                                    richTextBox_Text.SelectionStart = 0;
                                    richTextBox_Text.SelectionLength = 0;
                                }

                            }
                            
                        }

                        if (richTextBox_Text.SelectionLength > 0)
                        {
                            if (objRegEx_Main != null)
                            {
                                objRegEx_Main_Matches = objRegEx_Main.Matches(richTextBox_Text.SelectedText);
                                if (objRegEx_Main_Matches.Count > 0)
                                {
                                    var text1 = richTextBox_Text.Text.Substring(objRegEx_Main_Matches[0].Index, objRegEx_Main_Matches[0].Length);
                                    if (!mainEqualFilters.Any(p => Regex.Match(text, p.Filter).Success))
                                    {
                                        var parse = true;
                                        if (mainNotEqualFilters.Any())
                                        {
                                            if (!mainNotEqualFilters.Any(p => Regex.Match(text, p.Filter).Success))
                                            {
                                                parse = false;
                                            }
                                        }
                                        if (parse)
                                        {
                                            richTextBox_Text.SelectionStart = richTextBox_Text.SelectionStart +
                                                                          objRegEx_Main_Matches[0].Index;
                                            richTextBox_Text.SelectionLength = objRegEx_Main_Matches[0].Length;
                                        }
                                    }
                                    
                                }
                                else
                                {
                                    richTextBox_Text.SelectionStart = 0;
                                    richTextBox_Text.SelectionLength = 0;
                                }

                            }
                            
                        }
                        
                        if (richTextBox_Text.SelectionLength > 0)
                        {
                            objSelections.Add(new clsSelection
                            {
                                SelectionStart = richTextBox_Text.SelectionStart,
                                SelectionLength = richTextBox_Text.SelectionLength
                            });

                            richTextBox_Text.SelectionBackColor = Color.Yellow;
                        }
                        
                    }
                
                }    
                else if (objRegEx_Post_Matches != null)
                {
                    for (int i = 0; i < objRegEx_Post_Matches.Count; i++)
                    {
                        richTextBox_Text.SelectionStart = 0;
                        richTextBox_Text.SelectionLength = 0;

                        var ixStart = i == 0 ? 0 : objRegEx_Post_Matches[i - 1].Index + objRegEx_Post_Matches[i - 1].Length;
                        var ixEnd = objRegEx_Post_Matches[i].Index;

                        if (ixStart < ixEnd)
                        {
                            richTextBox_Text.SelectionStart = ixStart;
                            richTextBox_Text.SelectionLength = ixEnd - ixStart;
                        }
                    
                        if (richTextBox_Text.SelectionLength > 0)
                        {
                            if (objRegEx_Main != null)
                            {
                                objRegEx_Main_Matches = objRegEx_Main.Matches(richTextBox_Text.SelectedText);
                                if (objRegEx_Main_Matches.Count > 0)
                                {
                                    richTextBox_Text.SelectionStart = richTextBox_Text.SelectionStart +
                                                                      objRegEx_Main_Matches[0].Index;
                                    richTextBox_Text.SelectionLength = objRegEx_Main_Matches[0].Length;
                                }
                                else
                                {
                                    richTextBox_Text.SelectionStart = 0;
                                    richTextBox_Text.SelectionLength = 0;
                                }
                            }
                            else
                            {
                                if (objRegEx_Post == null)
                                {
                                    richTextBox_Text.SelectionStart = 0;
                                    richTextBox_Text.SelectionLength = 0;
                                }
                            
                            }


                        }
                    
                        if (richTextBox_Text.SelectionLength > 0)
                        {
                            objSelections.Add(new clsSelection
                            {
                                SelectionStart = richTextBox_Text.SelectionStart,
                                SelectionLength = richTextBox_Text.SelectionLength
                            });
                            richTextBox_Text.SelectionBackColor = Color.Yellow;
                        }
                    }
                
                }
                else if (objRegEx_Main_Matches != null)
                {
                    for (int i = 0; i < objRegEx_Main_Matches.Count; i++)
                    {
                        richTextBox_Text.SelectionStart = objRegEx_Main_Matches[i].Index;
                        richTextBox_Text.SelectionLength = objRegEx_Main_Matches[i].Length;

                        objSelections.Add(new clsSelection
                        {
                            SelectionStart = richTextBox_Text.SelectionStart,
                            SelectionLength = richTextBox_Text.SelectionLength
                        });
                        richTextBox_Text.SelectionBackColor = Color.Yellow;
                    }
                    
                }
                
            
            }
            catch (Exception ex)
            {
                
            }

            richTextBox_Text.ReadOnly = false;
            button_RemoveMarked.Enabled = true;
            button_RemoveUnmarked.Enabled = true;
            button_CopyMarked.Enabled = true;
        
        }

        

        private void button_RemoveUnmarked_Click(object sender, EventArgs e)
        {
            var objList_Marked = objSelections.OrderBy(p => p.SelectionStart).ToList();
            var strToKeep = "";
            for (int i = 0; i < objList_Marked.Count; i++)
            {
                richTextBox_Text.SelectionStart = objList_Marked[i].SelectionStart;
                richTextBox_Text.SelectionLength = objList_Marked[i].SelectionLength;
                strToKeep += richTextBox_Text.SelectedText + "\r\n";
            }
            richTextBox_Text.Text = strToKeep;
            objSelections.Clear();
        }

        private void button_RemoveMarked_Click(object sender, EventArgs e)
        {
            var objList_Marked = objSelections.OrderByDescending(p => p.SelectionStart).ToList();
            for (int i = 0; i < objList_Marked.Count; i++)
            {
                richTextBox_Text.SelectionStart = objList_Marked[i].SelectionStart;
                richTextBox_Text.SelectionLength = objList_Marked[i].SelectionLength;
                richTextBox_Text.SelectedText = "";

            }
            objSelections.Clear();
        }

        private void button_CopyMarked_Click(object sender, EventArgs e)
        {
            var objList_Marked = objSelections.OrderBy(p => p.SelectionStart).ToList();
            var strToCopy = "";
            for (int i = 0; i < objList_Marked.Count; i++)
            {
                richTextBox_Text.SelectionStart = objList_Marked[i].SelectionStart;
                richTextBox_Text.SelectionLength = objList_Marked[i].SelectionLength;
                strToCopy += richTextBox_Text.SelectedText + "\r\n";
            }
            Clipboard.SetDataObject(strToCopy);
        }

        private void button_AddField_Click(object sender, EventArgs e)
        {
            objFrmOntologyEditor = new frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class, objLocalConfig.OItem_class_field);
            objFrmOntologyEditor.ShowDialog(this);
            if (objFrmOntologyEditor.DialogResult == DialogResult.OK)
            {
                if (objFrmOntologyEditor.Type_Applied == objLocalConfig.Globals.Type_Object)
                {
                    if (objFrmOntologyEditor.OList_Simple.Count == 1)
                    {
                        if (objFrmOntologyEditor.OList_Simple.First().GUID_Parent == objLocalConfig.OItem_class_field.GUID)
                        {
                            objOItem_Field = objFrmOntologyEditor.OList_Simple.First();
                            Initialize_Field(objOItem_Field);
                        }
                        else
                        {
                            MessageBox.Show(this, "Bitte nur ein Feld auswählen!", "Bitte wählen!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Bitte nur ein Feld auswählen!", "Bitte wählen!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show(this, "Bitte nur ein Feld auswählen!", "Bitte wählen!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
