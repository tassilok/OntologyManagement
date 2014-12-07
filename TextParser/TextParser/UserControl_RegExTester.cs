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

        private Color colorPre;
        private Color colorMain;
        private Color colorPost;
        private Color colorRichText;
        private Color colorSeperator;

        public clsOntologyItem OItem_Field
        {
            get { return objOItem_Field; }
            set 
            { 
                objOItem_Field = value;
            }
        }

        private List<clsSelection> objSelections = new List<clsSelection>();
        

        public void SetContentByFileStream(FileStream fs)
        {
            TextReader textReader = new StreamReader(fs);
            richTextBox_Text.Text = textReader.ReadToEnd();
            textReader.Close();
        }

        public void SetContent(string content)
        {
            richTextBox_Text.Text = content;
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
            richTextBox_Text.ReadOnly = false;
            toolStripButton_removeMarked.Enabled = false;
            toolStripButton_RemoveUnmarked.Enabled = false;
            toolStripButton_CopyMarked.Enabled = false;
            toolStripButton_DoLine.Enabled = false;
            toolStripButton_Parse.Enabled = false;

            textBox_RegexPre.BackColor = colorPre;
            textBox_RegExMain.BackColor = colorMain;
            textBox_RegExPost.BackColor = colorPost;
        }

        public void SetContentByFilePath(string path)
        {
            try
            {
                TextReader textReader = new StreamReader(path);
                richTextBox_Text.Text = textReader.ReadToEnd();
                textReader.Close();
            }
            catch (Exception)
            {

                MessageBox.Show(this, "Die Datei konnte nicht geöffnet werden!", "Fehler!", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            
        }

        public UserControl_RegExTester(clsLocalConfig LocalConfig, string seperator = null)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            if (seperator != null) toolStripTextBox_LineSeperator.Text = seperator;

            Initialize();

        }

        public UserControl_RegExTester(clsGlobals globals, string seperator = null)
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(globals);
            if (seperator != null) toolStripTextBox_LineSeperator.Text = seperator;

            Initialize();

        }

        private void Initialize()
        {
            objOItem_Field = objLocalConfig.OItem_object_temporary_regular_expression.Clone();
            objDataWork_FieldParser = new clsDataWork_FieldParser(objLocalConfig);
            objDataWork_RegExFilter = new clsDatawork_RegExFilter(objLocalConfig);

            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);

            colorPre = textBox_RegexPre.BackColor;
            colorMain = textBox_RegExMain.BackColor;
            colorPost = textBox_RegExPost.BackColor;
            colorRichText = richTextBox_Text.BackColor;
            colorSeperator = toolStripTextBox_LineSeperator.BackColor;

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
            toolStripTextBox_LineSeperator.ReadOnly = false;
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
            ConfigureParseAndRegexButtons();
        }

        private void ConfigureParseAndRegexButtons()
        {
            
            bool parse = true;

            textBox_RegexPre.BackColor = colorPre;
            textBox_RegExMain.BackColor = colorMain;
            textBox_RegExPost.BackColor = colorPost;


            if ((textBox_RegexPre.Text != "" || textBox_RegExMain.Text != "" || textBox_RegExPost.Text != "") &&
                richTextBox_Text.Text != "")
            {
                if (textBox_RegexPre.Text != "")
                {
                    try
                    {
                        var regEx = new Regex(textBox_RegexPre.Text);
                    }
                    catch (Exception)
                    {
                        textBox_RegexPre.BackColor = Color.Yellow;
                        parse = false;
                    }
                }

                if (textBox_RegExMain.Text != "")
                {
                    try
                    {
                        var regEx = new Regex(textBox_RegExMain.Text);
                    }
                    catch (Exception)
                    {
                        textBox_RegExMain.BackColor = Color.Yellow;
                        parse = false;
                    }
                }

                if (textBox_RegExPost.Text != "")
                {
                    try
                    {
                        var regEx = new Regex(textBox_RegExPost.Text);
                    }
                    catch (Exception)
                    {
                        textBox_RegExPost.BackColor = Color.Yellow;
                        parse = false;
                    }
                }    
            }
            else
            {
                parse = false;
            }

            toolStripButton_Parse.Enabled = parse;

        }

        private void textBox_RegExMain_TextChanged(object sender, EventArgs e)
        {
            ConfigureParseAndRegexButtons();
        }

        private void textBox_RegExPost_TextChanged(object sender, EventArgs e)
        {
            ConfigureParseAndRegexButtons();
        }

        private void clearMark()
        {
            richTextBox_Text.SelectionStart = 0;
            richTextBox_Text.SelectionLength = richTextBox_Text.TextLength - 1;
            richTextBox_Text.SelectionBackColor = colorRichText;
        }

        private void parseText()
        {
            var boolRegExPre = false;
            var boolRegExMain = false;
            var boolRegExPost = false;

            var objSelectionsPre = new List<clsSelection>();
            var objSelectionsMain = new List<clsSelection>();
            var objSelectionsPost = new List<clsSelection>();

            objSelections.Clear();
            clearMark();

            richTextBox_Text.ReadOnly = true;

            regExFilters = (SortableBindingList<clsRegExFilter>) dataGridView_Filter.DataSource;

            var preEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_pre.GUID && p.Equal == true).ToList();
            var preNotEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_pre.GUID && p.Equal == false).ToList();
            var mainEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_main.GUID && p.Equal == true).ToList();
            var mainNotEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_main.GUID && p.Equal == false).ToList();
            var postEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_posts.GUID && p.Equal == true).ToList();
            var postNotEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_posts.GUID && p.Equal == false).ToList();

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

            if (toolStripTextBox_LineSeperator.Text == "")
            {
                

                if (textBox_RegexPre.Text != "")
                {
                    objRegEx_Pre_Matches = objRegEx_Pre.Matches(richTextBox_Text.Text);
                }

                if (textBox_RegExMain.Text != "")
                {
                    objRegEx_Main_Matches = objRegEx_Main.Matches(richTextBox_Text.Text);
                }

                if (textBox_RegExPost.Text != "")
                {
                    objRegEx_Post_Matches = objRegEx_Post.Matches(richTextBox_Text.Text);
                }



                if (objRegEx_Pre_Matches != null)
                {
                    objSelectionsPre.AddRange(from Match objRegExPreMatch in objRegEx_Pre_Matches
                                              select new clsSelection
                                              {
                                                  SelectionStart = objRegExPreMatch.Index,
                                                  SelectionLength = objRegExPreMatch.Length
                                              });
                }

                if (objRegEx_Main_Matches != null)
                {
                    objSelectionsMain.AddRange(from Match objRegExMainMatch in objRegEx_Main_Matches
                                               select new clsSelection
                                               {
                                                   SelectionStart = objRegExMainMatch.Index,
                                                   SelectionLength = objRegExMainMatch.Length
                                               });
                }

                if (objRegEx_Post_Matches != null)
                {
                    objSelectionsPost.AddRange(from Match objRegExPostMatch in objRegEx_Post_Matches
                                               select new clsSelection
                                               {
                                                   SelectionStart = objRegExPostMatch.Index,
                                                   SelectionLength = objRegExPostMatch.Length
                                               });
                }

                if (objSelectionsPre.Any())
                {
                    for (int i = 0; i < objSelectionsPre.Count; i++)
                    {
                        if (!TextMatchRegex(objSelectionsPre[i].SelectionStart,
                                            objSelectionsPre[i].SelectionStart + objSelectionsPre[i].SelectionLength,
                                            preEqualFilters))
                        {
                            var ixSelectionPrevEnd = i > 0 ? objSelectionsPre[i - 1].SelectionStart +
                            objSelectionsPre[i - 1].SelectionLength : 0;

                            var ixSelectionStart = objSelectionsPre[i].SelectionStart;
                            var ixSelectionEnd = ixSelectionStart + objSelectionsPre[i].SelectionLength;

                            var ixSelectionNextStart = i < objSelectionsPre.Count - 1 ? objSelectionsPre[i + 1].SelectionStart : objSelectionsPre.Last().SelectionStart;

                            var objSelection = new clsSelection();
                            objSelection.SelectionStart = objSelectionsPre[i].SelectionStart;
                            var objSelectionsPost2 = new List<clsSelection>();
                            var objSelectionsMain2 = new List<clsSelection>();

                            if (objSelectionsPost.Any())
                            {
                                objSelectionsPost2 =
                                    objSelectionsPost.Where(
                                        p =>
                                        p.SelectionStart >= ixSelectionEnd &&
                                        p.SelectionStart + p.SelectionLength <= ixSelectionNextStart
                                        && p.SelectionLength > 0).ToList();

                            }

                            if (objSelectionsMain.Any())
                            {
                                if (objSelectionsPost2.Any())
                                {
                                    objSelectionsMain2 = (from objSelectionMain in objSelectionsMain
                                                          from objSelectionPost in objSelectionsPost2
                                                          where
                                                              objSelectionMain.SelectionStart >= ixSelectionEnd &&
                                                              objSelectionMain.SelectionStart + objSelectionMain.SelectionLength <=
                                                              objSelectionPost.SelectionStart && objSelectionMain.SelectionLength >= 0
                                                          select objSelectionMain).ToList();
                                }
                                else
                                {
                                    objSelectionsMain2 = objSelectionsMain.Where(p => p.SelectionStart >= ixSelectionEnd &&
                                                                                      p.SelectionStart <= ixSelectionNextStart &&
                                                                                      p.SelectionLength > 0)
                                                                          .ToList();
                                }
                            }

                            if (checkBox_ContainerField.Checked)
                            {
                                objSelection.SelectionStart = ixSelectionStart;

                                if (objSelectionsPost2.Any())
                                {
                                    objSelection.SelectionLength = objSelectionsPost2.First().SelectionStart +
                                                                   objSelectionsPost2.First().SelectionLength - ixSelectionStart;
                                }
                                else if (objSelectionsMain2.Any())
                                {
                                    objSelection.SelectionLength = objSelectionsMain2.First().SelectionStart +
                                                                   objSelectionsMain2.First().SelectionLength - ixSelectionStart;
                                }
                                else
                                {
                                    objSelection.SelectionLength = ixSelectionNextStart - ixSelectionStart;
                                }


                            }
                            else
                            {
                                objSelection.SelectionStart = ixSelectionEnd;

                                if (objSelectionsMain2.Any())
                                {
                                    objSelection.SelectionStart = objSelectionsMain2.First().SelectionStart;
                                    objSelection.SelectionLength = objSelectionsMain2.First().SelectionLength;
                                }
                                else if (objSelectionsPost2.Any())
                                {
                                    objSelection.SelectionLength = objSelectionsPost2.First().SelectionStart -
                                                                   objSelection.SelectionStart;
                                }
                                else
                                {
                                    objSelection.SelectionLength = ixSelectionNextStart - ixSelectionEnd;
                                }


                            }

                            if (objSelection.SelectionLength > 0)
                            {
                                objSelections.Add(objSelection);
                            }
                        }


                    }


                }
            }
            else
            {
                toolStripTextBox_LineSeperator.BackColor = colorSeperator;
                var ixFind = 0;
                var ixSelStart = 0;
                var ixSelLength = 0;
                var lineBreaks = DoLineBreak();
                if (lineBreaks.Any())
                {
                    
                    while (ixFind > -1)
                    {
                        var ixLineStart = ixFind + ixFind > 0 ? ixFind : 0;
                        
                        var i = 0;
                        while(true)
                        {
                            var ixFindPre = richTextBox_Text.Find(lineBreaks.ToArray(), ixLineStart + i);
                            if (ixFindPre != ixFind)
                            {
                                ixFind = ixFindPre;
                                ixLineStart = ixLineStart + i;
                                break;
                            }
                            i++;
                        }
                        ixSelStart = ixLineStart;
                        var ixEnd = ixFind - ixLineStart;
                        ixSelLength = ixEnd;
                        if (ixFind > ixLineStart)
                        {
                            var text = richTextBox_Text.Text.Substring(ixLineStart, ixFind - ixLineStart);
                            var ixStart = 0;

                            var boolParse = true;

                            if (textBox_RegexPre.Text != "")
                            {
                                
                                objRegEx_Pre_Matches = objRegEx_Pre.Matches(text);
                                if (objRegEx_Pre_Matches.Count > 0)
                                {
                                    var textTest = text.Substring(objRegEx_Pre_Matches[0].Index,
                                                                  objRegEx_Pre_Matches[0].Length);

                                    if (preEqualFilters.Any(p => Regex.Match(textTest, p.Filter).Success))
                                    {
                                        boolParse = false;
                                    }
                                    if (boolParse)
                                    {
                                        if (!toolStripButton_DoLine.Checked)
                                        {
                                            text =
                                                text.Substring(objRegEx_Pre_Matches[0].Index +
                                                objRegEx_Pre_Matches[0].Length);
                                            ixSelStart = ixSelStart + objRegEx_Pre_Matches[0].Index +
                                                          objRegEx_Pre_Matches[0].Length;
                                        }
                                    }

                                }
                                else
                                {
                                    boolParse = false;
                                }
                            }

                            if (boolParse)
                            {
                                if (textBox_RegExPost.Text != "")
                                {
                                    objRegEx_Post_Matches = objRegEx_Post.Matches(text);
                                    if (objRegEx_Post_Matches.Count > 0)
                                    {
                                        var textTest = text.Substring(0, objRegEx_Post_Matches[0].Index);
                                        if (postEqualFilters.Any(p => Regex.Match(textTest, p.Filter).Success))
                                        {
                                            boolParse = false;
                                        }

                                        if (boolParse)
                                        {
                                            if (!toolStripButton_DoLine.Checked)
                                            {
                                                text = text.Substring(0, objRegEx_Post_Matches[0].Index);
                                                ixSelLength = objRegEx_Post_Matches[0].Index - 1;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        boolParse = false;
                                    }
                                }


                                if (boolParse)
                                {
                                    if (textBox_RegExMain.Text != "")
                                    {
                                        objRegEx_Main_Matches = objRegEx_Main.Matches(text);
                                        if (objRegEx_Main_Matches.Count > 0)
                                        {
                                            var textTest = text.Substring(objRegEx_Main_Matches[0].Index, objRegEx_Main_Matches[0].Length);
                                            if (postEqualFilters.Any(p => Regex.Match(textTest, p.Filter).Success))
                                            {
                                                boolParse = false;
                                            }

                                            if (boolParse)
                                            {
                                                if (!toolStripButton_DoLine.Checked)
                                                {
                                                    text = text.Substring(objRegEx_Main_Matches[0].Index, objRegEx_Main_Matches[0].Length);
                                                    ixSelStart = ixSelStart + objRegEx_Main_Matches[0].Index;   
                                                    ixSelLength= objRegEx_Main_Matches[0].Length;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            boolParse = false;
                                        }
                                    }

                                    if (boolParse)
                                    {
                                        objSelections.Add(new clsSelection
                                        {
                                            SelectionStart = ixSelStart,
                                            SelectionLength = ixSelLength
                                        });
                                    }
                                }
                            }
                        }

                        
                        
                    }    
                }
                else
                {
                    toolStripTextBox_LineSeperator.BackColor = Color.Yellow;
                }
                
            }
            
            
            
        }

        private bool TextMatchRegex(int ixStart, int ixEnd, List<clsRegExFilter> regExFilters)
        {
            var text = richTextBox_Text.Text.Substring(ixStart, ixEnd - ixStart);
            if (regExFilters.Any(p => Regex.Match(text, p.Filter).Success))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private int FindNextLineBreak(int ixStart)
        {
            var lineBreak = DoLineBreak();

            if (lineBreak != null)
            {
                return richTextBox_Text.Find(lineBreak.ToArray(), ixStart);
            }

            return -1;
        }

        private int FindPreviousLineBreak(int ixStart)
        {
            var lineBreak = DoLineBreak();

            if (lineBreak != null)
            {
                var find = 0;
                var ixLast = 0;
                while (find != -1 && find < ixStart)
                {
                    find = richTextBox_Text.Find(lineBreak.ToArray(), find > 0 ? find + 2 : 0);
                    if (find != -1)
                    {
                        ixLast = find;
                    }
                }
                return ixLast;
            }

            return -1;
        }
        //private void parseText()
        //{
        //    var boolRegExPre = false;
        //    var boolRegExMain = false;
        //    var boolRegExPost = false;
        //    var ixNextParse = 0;

        //    objSelections.Clear();

        //    richTextBox_Text.ReadOnly = true;
        //    try
        //    {
        //        regExFilters = (SortableBindingList<clsRegExFilter>) dataGridView_Filter.DataSource;
        //        var preEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_pre.GUID && p.Equal == true).ToList();
        //        var preNotEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_pre.GUID && p.Equal == false).ToList();
        //        var mainEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_main.GUID && p.Equal == true).ToList();
        //        var mainNotEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_main.GUID && p.Equal == false).ToList();
        //        var postEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_posts.GUID && p.Equal == true).ToList();
        //        var postNotEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_posts.GUID && p.Equal == false).ToList();

        //        richTextBox_Text.SelectionStart = 0;
        //        richTextBox_Text.SelectionLength = richTextBox_Text.TextLength;
        //        richTextBox_Text.SelectionBackColor = richTextBox_Text.BackColor;

        //        Regex objRegEx_Pre = null;
        //        Regex objRegEx_Main = null;
        //        Regex objRegEx_Post = null;

        //        MatchCollection objRegEx_Pre_Matches = null;
        //        MatchCollection objRegEx_Main_Matches = null;
        //        MatchCollection objRegEx_Post_Matches = null;

        //        if (textBox_RegexPre.Text != "")
        //        {
        //            objRegEx_Pre = new Regex(textBox_RegexPre.Text);
        //        }
                    
        //        if (textBox_RegExMain.Text != "")
        //        {
        //            objRegEx_Main = new Regex(textBox_RegExMain.Text);
        //        }
                    
        //        if (textBox_RegExPost.Text != "")
        //        {
        //            objRegEx_Post = new Regex(textBox_RegExPost.Text);
        //        }

        //        boolRegExPre = true;
        //        if (textBox_RegexPre.Text != "")
        //        {
        //            objRegEx_Pre_Matches = objRegEx_Pre.Matches(richTextBox_Text.Text);
        //        }
        //        else
        //        {
        //            boolRegExMain = true;
        //            if (textBox_RegExMain.Text != "")
        //            {
        //                objRegEx_Main_Matches = objRegEx_Main.Matches(richTextBox_Text.Text);
        //            }

        //            boolRegExPost = true;
        //            if (textBox_RegExPost.Text != "")
        //            {
        //                objRegEx_Post_Matches = objRegEx_Post.Matches(richTextBox_Text.Text);
        //            }

        //        }

                
            
            

            

        //        if (objRegEx_Pre_Matches != null)
        //        {
        //            for (int i = 0; i < objRegEx_Pre_Matches.Count; i++)
        //            {

        //                objSelections.Add(new clsSelection { SelectionStart = 0, SelectionLength = 0 });
        //                var objSelection = objSelections.Last();

        //                if (objRegEx_Pre_Matches[i].Index >= ixNextParse)
        //                {
        //                    var ixStart = objRegEx_Pre_Matches[i].Index + objRegEx_Pre_Matches[i].Length;
        //                    var ixEnd = ixStart;
        //                    if (i < objRegEx_Pre_Matches.Count)
        //                    {
        //                        ixEnd = objRegEx_Pre_Matches[i + 1].Index;
        //                    }
        //                    else
        //                    {
        //                        ixEnd = richTextBox_Text.TextLength - 1;
        //                    }

        //                    //richTextBox_Text.SelectionStart = ixStart;
        //                    //richTextBox_Text.SelectionLength = ixEnd;

        //                    var textPre = richTextBox_Text.Text.Substring(ixStart, ixEnd);
        //                    var offsetPre = GetOffset(textPre);
        //                    if (offsetPre > 0)
        //                    {
        //                        textPre = textPre.Substring(0, offsetPre);
        //                    }

        //                    objSelection.SelectionStart = ixStart;
        //                    objSelection.SelectionLength = offsetPre == 0 ? ixEnd : offsetPre;

        //                    if (!preEqualFilters.Any(p => Regex.Match(textPre, p.Filter).Success))
        //                    {
        //                        var parse = true;
        //                        if (preNotEqualFilters.Any())
        //                        {
        //                            if (!preNotEqualFilters.Any(p => Regex.Match(textPre, p.Filter).Success))
        //                            {
        //                                parse = false;
        //                            }
        //                        }
        //                        if (!parse)
        //                        {
        //                            objSelection.SelectionStart = 0;
        //                            objSelection.SelectionLength = 0;

        //                        }

        //                    }





        //                    if (objRegEx_Post != null)
        //                    {
        //                        if (objSelections.Last().SelectionLength > 0)
        //                        {
        //                            var textPost = richTextBox_Text.Text.Substring(objSelection.SelectionStart,
        //                                                                           objSelection.SelectionLength);
        //                            objRegEx_Post_Matches = objRegEx_Post.Matches(textPost);
        //                            if (objRegEx_Post_Matches.Count > 0)
        //                            {
        //                                textPost = richTextBox_Text.Text.Substring(objRegEx_Post_Matches[0].Index, objRegEx_Post_Matches[0].Length);
        //                                if (!postEqualFilters.Any(p => Regex.Match(textPost, p.Filter).Success))
        //                                {
        //                                    var parse = true;
        //                                    if (preNotEqualFilters.Any())
        //                                    {
        //                                        if (!postNotEqualFilters.Any(p => Regex.Match(textPost, p.Filter).Success))
        //                                        {
        //                                            parse = false;
        //                                        }
        //                                    }
        //                                    if (parse)
        //                                    {
        //                                        objSelection.SelectionLength = objRegEx_Post_Matches[0].Index;
        //                                    }

        //                                }

        //                            }
        //                            else
        //                            {
        //                                objSelection.SelectionStart = 0;
        //                                objSelection.SelectionLength = 0;
        //                            }

        //                        }

                                

        //                    }

        //                    if (objSelection.SelectionLength > 0)
        //                    {
        //                        if (objRegEx_Main != null)
        //                        {
        //                            var textMain = richTextBox_Text.Text.Substring(objSelection.SelectionStart,
        //                                                                        objSelection.SelectionLength);
        //                            objRegEx_Main_Matches = objRegEx_Main.Matches(textMain);
        //                            if (objRegEx_Main_Matches.Count > 0)
        //                            {
        //                                textMain = textMain.Substring(objRegEx_Main_Matches[0].Index,
        //                                                              objRegEx_Main_Matches[0].Length);
        //                                if (!mainEqualFilters.Any(p => Regex.Match(textMain, p.Filter).Success))
        //                                {
        //                                    var parse = true;
        //                                    if (mainNotEqualFilters.Any())
        //                                    {
        //                                        if (!mainNotEqualFilters.Any(p => Regex.Match(textMain, p.Filter).Success))
        //                                        {
        //                                            parse = false;
        //                                        }
        //                                    }
        //                                    if (parse)
        //                                    {
        //                                        objSelection.SelectionStart = richTextBox_Text.SelectionStart +
        //                                                                      objRegEx_Main_Matches[0].Index;
        //                                        objSelection.SelectionLength = objRegEx_Main_Matches[0].Length;
        //                                    }
        //                                }

        //                            }
        //                            else
        //                            {
        //                                richTextBox_Text.SelectionStart = 0;
        //                                richTextBox_Text.SelectionLength = 0;
        //                            }

                                    

        //                        }

        //                    }

        //                    if (objSelection.SelectionLength <= 0)
        //                    {
        //                        objSelections.RemoveAt(objSelections.Count-1);
        //                    }

        //                    if (objSelection.SelectionLength > 0)
        //                    {
        //                        ixNextParse = objSelection.SelectionStart + offsetPre == 0 ? objSelection.SelectionLength : offsetPre;
        //                    }
        //                }

                        
                        
        //            }
                
        //        }    
        //        else if (objRegEx_Post_Matches != null)
        //        {
        //            for (int i = 0; i < objRegEx_Post_Matches.Count; i++)
        //            {
        //                objSelections.Add(new clsSelection { SelectionStart = 0, SelectionLength = 0 });
        //                var objSelection = objSelections.Last();
                        
        //                if (objRegEx_Post_Matches[i].Index >= ixNextParse)
        //                {
                            
        //                    var ixStart = i == 0 ? 0 : objRegEx_Post_Matches[i - 1].Index + objRegEx_Post_Matches[i - 1].Length;
        //                    var ixEnd = objRegEx_Post_Matches[i].Index;

        //                    var textPost = "";
        //                    var offset = 0;
        //                    if (ixStart < ixEnd)
        //                    {
        //                        objSelection.SelectionStart = ixStart;
        //                        objSelection.SelectionLength = ixEnd - ixStart;
        //                        textPost = richTextBox_Text.Text.Substring(objSelection.SelectionStart,
        //                                                                   objSelection.SelectionLength);
        //                        offset = GetOffset(textPost);
        //                        if (offset > 0) objSelection.SelectionLength = offset;

        //                    }

                            

        //                    if (objSelection.SelectionLength > 0)
        //                    {
        //                        if (objRegEx_Main != null)
        //                        {

        //                            objRegEx_Main_Matches = objRegEx_Main.Matches(textPost);
        //                            if (objRegEx_Main_Matches.Count > 0)
        //                            {
        //                                objSelection.SelectionStart = objSelection.SelectionStart +
        //                                                                  objRegEx_Main_Matches[0].Index;
        //                                objSelection.SelectionLength = objRegEx_Main_Matches[0].Length;
        //                            }
        //                            else
        //                            {
        //                                objSelection.SelectionStart = 0;
        //                                objSelection.SelectionLength = 0;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (objRegEx_Post == null)
        //                            {
        //                                objSelection.SelectionStart = 0;
        //                                objSelection.SelectionLength = 0;
        //                            }

        //                        }


        //                    }

        //                    if (objSelection.SelectionLength <= 0)
        //                    {
        //                        objSelections.RemoveAt(objSelections.Count-1);
        //                    }

        //                    if (objSelection.SelectionLength > 0)
        //                    {

        //                        ixNextParse = objSelection.SelectionStart + objSelection.SelectionLength + offset > 0 ? offset - 1 : 0;
        //                    }
        //                }
                        
        //            }
                
        //        }
        //        else if (objRegEx_Main_Matches != null)
        //        {
        //            for (int i = 0; i < objRegEx_Main_Matches.Count; i++)
        //            {
                        

        //                if (objRegEx_Main_Matches[i].Index >= ixNextParse)
        //                {
        //                    objSelections.Add(new clsSelection { SelectionStart = 0, SelectionLength = 0 });

        //                    richTextBox_Text.SelectionStart = objRegEx_Main_Matches[i].Index;
        //                    richTextBox_Text.SelectionLength = objRegEx_Main_Matches[i].Length;

        //                    objSelections.Last().SelectionStart = richTextBox_Text.SelectionStart;
        //                    objSelections.Last().SelectionLength = richTextBox_Text.SelectionLength;

        //                    richTextBox_Text.SelectionBackColor = Color.Yellow;

        //                    if (richTextBox_Text.SelectionLength > 0)
        //                    {
        //                        var offset = 0;
        //                        if (toolStripTextBox_LineSeperator.Text != "")
        //                        {
        //                            var seperatorText = toolStripTextBox_LineSeperator.Text;
        //                            var charList = new List<char>();
        //                            while (seperatorText.Contains("\\n"))
        //                            {
        //                                charList.Add((char)10);
        //                                seperatorText = seperatorText.Remove(seperatorText.IndexOf("\\n"), 2);
        //                            }
        //                            while (seperatorText.Contains("\\r"))
        //                            {
        //                                charList.Add((char)13);
        //                                seperatorText = seperatorText.Remove(seperatorText.IndexOf("\\r"), 2);
        //                            }
        //                            if (charList.Any())
        //                            {
        //                                offset = richTextBox_Text.Find(charList.ToArray(),
        //                                                  richTextBox_Text.SelectionStart + richTextBox_Text.SelectionLength);
        //                            }

                                    
        //                        }

        //                        ixNextParse = richTextBox_Text.SelectionStart + richTextBox_Text.SelectionLength + offset > 0 ? offset - 1 : 0;
        //                    }    
        //                }
                        
        //            }
                    
        //        }
                
            
        //    }
        //    catch (Exception ex)
        //    {
                
        //    }

        //    richTextBox_Text.ReadOnly = false;
        //    toolStripButton_removeMarked.Enabled = true;
        //    toolStripButton_RemoveUnmarked.Enabled = true;
        //    toolStripButton_CopyMarked.Enabled = true;

        //    MarkSelections();
        
        //}

        private void MarkSelections()
        {
            foreach (var objSelection in objSelections)
            {
                richTextBox_Text.SelectionStart = objSelection.SelectionStart;
                richTextBox_Text.SelectionLength = objSelection.SelectionLength;

                richTextBox_Text.SelectionBackColor = Color.Yellow;
            }
        }

        private int GetOffset(string text)
        {
            var offset = 0;
            if (toolStripTextBox_LineSeperator.Text != "")
            {
                var seperatorText = toolStripTextBox_LineSeperator.Text;
                var charList = new List<char>();
                while (seperatorText.Contains("\\n"))
                {
                    charList.Add((char)10);
                    seperatorText = seperatorText.Remove(seperatorText.IndexOf("\\n"), 2);
                }
                while (seperatorText.Contains("\\r"))
                {
                    charList.Add((char)13);
                    seperatorText = seperatorText.Remove(seperatorText.IndexOf("\\r"), 2);
                }
                if (charList.Any())
                {
                    offset = richTextBox_Text.Find(charList.ToArray(),
                                      richTextBox_Text.SelectionStart + richTextBox_Text.SelectionLength);
                }

            }

            return offset;
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


        private List<char> DoLineBreak()
        {
            

            if (toolStripTextBox_LineSeperator.Text != null)
            {
                var seperatorText = toolStripTextBox_LineSeperator.Text;
                var charList = new List<char>();
                while (seperatorText.Contains("\\r"))
                {
                    charList.Add((char)13);
                    seperatorText = seperatorText.Remove(seperatorText.IndexOf("\\r"), 2);
                }
                while (seperatorText.Contains("\\n"))
                {
                    charList.Add((char)10);
                    seperatorText = seperatorText.Remove(seperatorText.IndexOf("\\n"), 2);
                }


                if (charList.Count > 0)
                {
                    if (richTextBox_Text.Find(charList.ToArray()) > 0)
                    {
                        return charList;
                    }
                }

            }

            return null;
        }

        private string DoLineBreakString()
        {
            var lineBreaks = DoLineBreak();
            

            if (lineBreaks.Any())
            {
                var result = string.Join("", lineBreaks);
                return result;
            }
            
            return null;
            
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

        private void button_Parse_Click(object sender, EventArgs e)
        {
            var parse = true;
            if (textBox_RegexPre.Text != "")
            {
                var objOAItem_Pattern = SyncPatternOfField(objLocalConfig.OItem_relationtype_pre,
                                                     textBox_RegexPre.Text,
                                                     true);

                if (objOAItem_Pattern != null)
                {
                    objOAItem_PrePattern = objOAItem_Pattern;
                }
                else
                {
                    parse = false;
                    MessageBox.Show(this, "Der Pre-Regex konnte nicht gespeichert werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_RegexPre.ReadOnly = true;
                    textBox_RegexPre.Text = objOAItem_PrePattern.Val_String;
                    textBox_RegexPre.ReadOnly = false;
                }
            }

            if (textBox_RegExMain.Text != "")
            {
                var objOAItem_Pattern = SyncPatternOfField(objLocalConfig.OItem_relationtype_main,
                                                           textBox_RegExMain.Text,
                                                           true);

                if (objOAItem_Pattern != null)
                {
                    objOAItem_MainPattern = objOAItem_Pattern;
                }
                else
                {
                    parse = false;
                    MessageBox.Show(this, "Der Main-Regex konnte nicht gespeichert werden!", "Fehler", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    textBox_RegExMain.ReadOnly = true;
                    textBox_RegExMain.Text = objOAItem_MainPattern.Val_String;
                    textBox_RegExMain.ReadOnly = false;
                }
            }

            if (textBox_RegExPost.Text != "")
            {
                var objOAItem_Pattern = SyncPatternOfField(objLocalConfig.OItem_relationtype_posts,
                                                     textBox_RegExPost.Text,
                                                     true);

                if (objOAItem_Pattern != null)
                {
                    objOAItem_PostPattern = objOAItem_Pattern;
                }
                else
                {
                    parse = false;
                    MessageBox.Show(this, "Der Post-Regex konnte nicht gespeichert werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_RegExPost.ReadOnly = true;
                    textBox_RegExPost.Text = objOAItem_PostPattern.Val_String;
                    textBox_RegExPost.ReadOnly = false;
                }
            }

            if (parse)
            {
                if ((textBox_RegexPre.Text != "" ||
                 textBox_RegExMain.Text != "" ||
                 textBox_RegExPost.Text != "") &&
                richTextBox_Text.Text != "")
                {
                    parseText();
                    SelectText();
                    toolStripLabel_Found.Text = objSelections.Count.ToString();
                    richTextBox_Text.ReadOnly = false;
                    toolStripButton_removeMarked.Enabled = true;
                    toolStripButton_RemoveUnmarked.Enabled = true;
                    toolStripButton_CopyMarked.Enabled = true;
                }
            }
        }

        private void SelectText()
        {
            foreach (var objSelection in objSelections)
            {
                richTextBox_Text.SelectionStart = objSelection.SelectionStart;
                richTextBox_Text.SelectionLength = objSelection.SelectionLength;

                richTextBox_Text.SelectionBackColor = Color.Yellow;
            }
        }

        private void richTextBox_Text_TextChanged(object sender, EventArgs e)
        {
            richTextBox_Text.Enabled = true;
            ConfigureParseAndRegexButtons();
        }

        private void toolStripTextBox_LineSeperator_TextChanged(object sender, EventArgs e)
        {

            toolStripButton_DoLine.Enabled = false;
            if (toolStripTextBox_LineSeperator.Text != "")
            {
                toolStripButton_DoLine.Enabled = true;

            }
        }

        private void toolStripButton_DoLine_Click(object sender, EventArgs e)
        {
            if (!toolStripButton_DoLine.Checked)
            {
                if (DoLineBreak() != null)
                {
                    toolStripButton_DoLine.Checked = true;
                }
                else
                {
                    MessageBox.Show(this, "Der Text enthält den angegeben Seperator nicht!", "Fehler.",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                toolStripButton_DoLine.Checked = false;
            }

        }

        private void richTextBox_Text_SelectionChanged(object sender, EventArgs e)
        {
            toolStripLabel_Pos.Text = richTextBox_Text.SelectionStart.ToString();
            toolStripLabel_Sel.Text = richTextBox_Text.SelectionStart.ToString() +
                                      " - " + (richTextBox_Text.SelectionStart + richTextBox_Text.SelectionLength)
                                          .ToString();
            toolStripLabel_SelLength.Text = richTextBox_Text.SelectionLength.ToString();
        }
    }
}
