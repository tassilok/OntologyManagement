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
using ScintillaNET;

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

        ParseResult parseResult = new ParseResult(true);

        private ParseLogWindow parseLogWindow;

        public clsOntologyItem OItem_Field
        {
            get { return objOItem_Field; }
            set 
            { 
                objOItem_Field = value;
            }
        }

        private List<clsSelection> objSelections = new List<clsSelection>();
        private int selectionPosition;

        public void SetContentByFileStream(FileStream fs)
        {
            TextReader textReader = new StreamReader(fs);
            scintilla_Text.Text = textReader.ReadToEnd();
            textReader.Close();
        }

        public void SetContent(string content)
        {
            scintilla_Text.Text = content;
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
                scintilla_Text.Text = textReader.ReadToEnd();
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
            scintilla_Text.Styles[0].BackColor = scintilla_Text.BackColor;
            scintilla_Text.Styles[0].ForeColor = scintilla_Text.ForeColor;
            scintilla_Text.Styles[0].Font = new Font(scintilla_Text.Font, FontStyle.Regular);
            scintilla_Text.Styles[1].BackColor = Color.Yellow;
            scintilla_Text.Styles[1].ForeColor = Color.Black;
            scintilla_Text.Styles[1].Font = new Font(scintilla_Text.Font, FontStyle.Bold);

            objOItem_Field = objLocalConfig.OItem_object_temporary_regular_expression.Clone();
            objDataWork_FieldParser = new clsDataWork_FieldParser(objLocalConfig);
            objDataWork_RegExFilter = new clsDatawork_RegExFilter(objLocalConfig);

            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);

            colorPre = textBox_RegexPre.BackColor;
            colorMain = textBox_RegExMain.BackColor;
            colorPost = textBox_RegExPost.BackColor;
            colorRichText = scintilla_Text.BackColor;
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
                scintilla_Text.Text != "")
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
            scintilla_Text.BackColor = scintilla_Text.Styles[0].BackColor;
            scintilla_Text.ForeColor = scintilla_Text.Styles[0].ForeColor;
            scintilla_Text.Font = scintilla_Text.Styles[0].Font;

        }

        private void parseText()
        {

            objSelections.Clear();
            clearMark();

            regExFilters = (SortableBindingList<clsRegExFilter>) dataGridView_Filter.DataSource;

            var preEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_pre.GUID && p.Equal == true).ToList();
            var preNotEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_pre.GUID && p.Equal == false).ToList();
            var mainEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_main.GUID && p.Equal == true).ToList();
            var mainNotEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_main.GUID && p.Equal == false).ToList();
            var postEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_posts.GUID && p.Equal == true).ToList();
            var postNotEqualFilters = regExFilters.Where(p => p.ID_Regex_RelationType == objLocalConfig.OItem_relationtype_posts.GUID && p.Equal == false).ToList();

            string regexPre = !string.IsNullOrEmpty(textBox_RegexPre.Text) ? textBox_RegexPre.Text : null;
            string regexMain = !string.IsNullOrEmpty(textBox_RegExMain.Text) ? textBox_RegExMain.Text : null;
            string regexPost = !string.IsNullOrEmpty(textBox_RegExPost.Text) ? textBox_RegExPost.Text : null;

            if (regexMain != null)
            {
                scintilla_Text.CurrentPos = 0;

                if (!string.IsNullOrEmpty(toolStripTextBox_LineSeperator.Text))
                {
                    var range = scintilla_Text.FindReplace.FindNext(toolStripTextBox_LineSeperator.Text);

                    while (range != null && range.Length > 0)
                    {
                        var selection = GetSelections(scintilla_Text.GetRange(scintilla_Text.Caret.Position, range.Start), regexPre, regexMain, regexPost);
                        if (selection != null && selection.SelectionLength > 0)
                        {
                            objSelections.Add(selection);
                        }
                        scintilla_Text.Caret.Position = range.End;
                        range = scintilla_Text.FindReplace.FindNext(toolStripTextBox_LineSeperator.Text);
                        if (range.Start < scintilla_Text.CurrentPos)
                        {
                            break;
                        }


                    }
                }
                else
                {
                    foreach (Line line in scintilla_Text.Lines)
                    {

                        var selection = GetSelections(line.Range, regexPre, regexMain, regexPost);
                        if (selection != null)
                        {
                            objSelections.Add(selection);
                        }
                        
                    }
                }
                
                
            }
            
            
            
            
        }

        public clsSelection GetSelections(Range textRange, string regexPre, string regexMain, string regexPost)
        {

            if (!string.IsNullOrEmpty(regexMain))
            {
                parseResult.ResultText = textRange.Text;
                parseResult.Parse(regexPre, regexMain, regexPost);
                if (parseLogWindow != null && parseLogWindow.Visible)
                {
                    parseLogWindow.AddLines(parseResult.LogResult);
                }
                if (parseResult.ParseOk)
                {
                    //var range = scintilla_Text.FindReplace.Find(textRange,parseResult.ResultText,SearchFlags.Posix);
                    if (!string.IsNullOrEmpty( parseResult.ResultText))
                    {
                        var range = new Range(textRange.Start + parseResult.IxEndPre, textRange.End, scintilla_Text);
                        var rangeFind = scintilla_Text.FindReplace.Find(range, parseResult.ResultText, SearchFlags.Posix);
                        return new clsSelection { Range = rangeFind, SelectionStart = range.Start, SelectionLength = range.Length };
                    }
                    
                }
            }

            return null;

        }

        private bool TextMatchRegex(int ixStart, int ixEnd, List<clsRegExFilter> regExFilters)
        {
            var text = scintilla_Text.Text.Substring(ixStart, ixEnd - ixStart);
            if (regExFilters.Any(p => Regex.Match(text, p.Filter).Success))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        private void button_RemoveUnmarked_Click(object sender, EventArgs e)
        {
            var objList_Marked = objSelections.OrderBy(p => p.SelectionStart).ToList();
            
            
            var strToKeep = "";

            for (int i = 0; i < objList_Marked.Count; i++)
            {

                scintilla_Text.Selection.Start = objList_Marked[i].SelectionStart;
                scintilla_Text.Selection.Length = objList_Marked[i].SelectionLength;

                strToKeep += scintilla_Text.Selection.Text + "\r\n";
            }
            scintilla_Text.Text = strToKeep;
            objSelections.Clear();
        }


        private List<char> DoLineBreak()
        {
            

            //if (toolStripTextBox_LineSeperator.Text != null)
            //{
            //    var seperatorText = toolStripTextBox_LineSeperator.Text;
            //    var charList = new List<char>();
            //    while (seperatorText.Contains("\\r"))
            //    {
            //        charList.Add((char)13);
            //        seperatorText = seperatorText.Remove(seperatorText.IndexOf("\\r"), 2);
            //    }
            //    while (seperatorText.Contains("\\n"))
            //    {
            //        charList.Add((char)10);
            //        seperatorText = seperatorText.Remove(seperatorText.IndexOf("\\n"), 2);
            //    }


            //    if (charList.Count > 0)
            //    {
            //        if (scintilla_Text.Find(charList.ToArray()) > 0)
            //        {
            //            return charList;
            //        }
            //    }

            //}

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
                scintilla_Text.Selection.Start = objList_Marked[i].SelectionStart;
                scintilla_Text.Selection.Length = objList_Marked[i].SelectionLength;
                
                scintilla_Text.Selection.Text = "";

            }
            objSelections.Clear();
        }

        private void button_CopyMarked_Click(object sender, EventArgs e)
        {
            var objList_Marked = objSelections.OrderBy(p => p.SelectionStart).ToList();
            
            var strToCopy = "";
            for (int i = 0; i < objList_Marked.Count; i++)
            {
                scintilla_Text.Selection.Start = objList_Marked[i].SelectionStart;
                scintilla_Text.Selection.Length = objList_Marked[i].SelectionLength;
                strToCopy += scintilla_Text.Selection.Text + "\r\n";
            }
            System.Windows.Forms.Clipboard.SetDataObject(strToCopy);
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
            toolStripButton_Previous.Enabled = false;
            toolStripButton_Next.Enabled = false;
            selectionPosition = 0;
            try
            {
                parseLogWindow.Close();
            }
            catch (Exception)
            {
                
            }
            parseLogWindow = new ParseLogWindow();


            parseLogWindow.Show();

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
                scintilla_Text.Text != "")
                {
                    parseText();
                    SelectText();
                    toolStripLabel_Found.Text = objSelections.Count.ToString();
                    toolStripButton_removeMarked.Enabled = true;
                    toolStripButton_RemoveUnmarked.Enabled = true;
                    toolStripButton_CopyMarked.Enabled = true;
                    ConfigurePositionButtons();     
                }
            }
        }

        private void ConfigurePositionButtons()
        {
            toolStripButton_Previous.Enabled = false;
            toolStripButton_Next.Enabled = false;

            if (objSelections.Any())
            {
                if (selectionPosition < objSelections.Count() - 1)
                {
                    toolStripButton_Next.Enabled = true;
                }

                if (selectionPosition > 0)
                {
                    toolStripButton_Previous.Enabled = true;
                }
            }
        }

        private void SelectText()
        {
            foreach (var objSelection in objSelections)
            {
                objSelection.Range.SetStyle(1);


            }
        }

        private void scintilla_Text_TextChanged(object sender, EventArgs e)
        {
            scintilla_Text.Enabled = true;
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

        private void scintilla_Text_TextChanged_1(object sender, EventArgs e)
        {

            ToggleParseButton();

        }

        private void ToggleParseButton()
        {
            toolStripButton_Parse.Enabled = true;
            try
            {
                if (string.IsNullOrEmpty(textBox_RegExMain.Text))
                {
                    toolStripButton_Parse.Enabled = false;
                }

                var regexMain = new Regex(textBox_RegExMain.Text);

                if (!string.IsNullOrEmpty(textBox_RegexPre.Text))
                {
                    var regexPre = new Regex(textBox_RegexPre.Text);
                }

                if (!string.IsNullOrEmpty(textBox_RegExPost.Text))
                {
                    var regexPost = new Regex(textBox_RegExPost.Text);
                }

                toolStripButton_Parse.Enabled = true;
            }
            catch (Exception)
            {
                toolStripButton_Parse.Enabled = false;

            }
        }

        private void toolStripButton_Previous_Click(object sender, EventArgs e)
        {
            selectionPosition --;
            scintilla_Text.GoTo.Position(objSelections[selectionPosition].Range.Start);
            ToggleParseButton();
        }

        private void toolStripButton_Next_Click(object sender, EventArgs e)
        {
            selectionPosition++;
            scintilla_Text.GoTo.Position(objSelections[selectionPosition].Range.Start);
            ToggleParseButton();
        }

        
    }
}
