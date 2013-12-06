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

namespace TextParser
{
    public partial class UserControl_RegExTester : UserControl
    {
        private SortableBindingList<clsRegExFilter> regExFilters;

        private clsLocalConfig objLocalConfig;

        private clsDataWork_FieldParser objDataWork_FieldParser;

        private frmRegExFilter objFrmRegExFilter;

        private clsOntologyItem objOItem_Field;
        private clsObjectAtt objOAItem_PrePattern;
        private clsObjectAtt objOAItem_MainPattern;
        private clsObjectAtt objOAItem_PostPattern;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        public UserControl_RegExTester(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            objOItem_Field = objLocalConfig.OItem_object_temporary_regular_expression.Clone();
            objDataWork_FieldParser = new clsDataWork_FieldParser(objLocalConfig);

            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
        }

        public void Initialize_Field(clsOntologyItem OItem_Field = null)
        {
            if (OItem_Field != null)
            {
                objOItem_Field = OItem_Field;
            }

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            objOAItem_PrePattern = objDataWork_FieldParser.GetRegexOfField(objOItem_Field,
                                                                           objLocalConfig.OItem_relationtype_pre);

            if (objOAItem_PrePattern == null)
            {
                objOItem_Result = SavePatternOfField(objLocalConfig.OItem_relationtype_pre,
                    ".*");
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOAItem_PrePattern = objDataWork_FieldParser.GetRegexOfField(objOItem_Field,
                                                                           objLocalConfig.OItem_relationtype_pre);
                }
            }

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOAItem_MainPattern = objDataWork_FieldParser.GetRegexOfField(objOItem_Field,
                                                                            objLocalConfig.OItem_relationtype_main);

                if (objOAItem_MainPattern == null)
                {
                    objOItem_Result = SavePatternOfField(objLocalConfig.OItem_relationtype_main,
                        ".*");
                }
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOAItem_PostPattern = objDataWork_FieldParser.GetRegexOfField(objOItem_Field,
                                                                                objLocalConfig.OItem_relationtype_posts);    
                }
                
            }

            
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                throw new Exception("Daten konnten nicht geladen werden!");
            }
            else
            {
                textBox_RegexPre.ReadOnly = true;
                textBox_RegexPre.Text = objOAItem_PrePattern.Val_String;
                textBox_RegexPre.ReadOnly = false;

                textBox_RegExMain.ReadOnly = true;
                textBox_RegExMain.Text = objOAItem_MainPattern.Val_String;
                textBox_RegExMain.ReadOnly = false;

                textBox_RegExPost.ReadOnly = true;
                textBox_RegExPost.Text = objOAItem_PostPattern.Val_String;
                textBox_RegExPost.ReadOnly = false;
            }
        }

        private clsOntologyItem SavePatternOfField(clsOntologyItem OItem_RelationType, string pattern)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
            if (objOItem_Field != null)
            {
                var objOItem_Pattern = objDataWork_FieldParser.GetPatternByPattern(pattern);

                if (objOItem_Pattern == null)
                {
                   objOItem_Pattern = new clsOntologyItem
                    {
                        GUID = objLocalConfig.Globals.NewGUID,
                        Name = pattern.Length > 255 ? pattern.Substring(0, 254) : pattern,
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

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
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
            textBox_RegexPre.ReadOnly = true;
            textBox_RegExMain.ReadOnly = true;
            textBox_RegExPost.ReadOnly = true;

            if (richTextBox_Text.TextLength>0)
            {
                textBox_RegexPre.ReadOnly = false;
                textBox_RegExMain.ReadOnly = false;
                textBox_RegExPost.ReadOnly = false;
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objFrmRegExFilter = new frmRegExFilter(objLocalConfig);
            objFrmRegExFilter.ShowDialog(this);
            if (objFrmRegExFilter.DialogResult == DialogResult.OK)
            {
                
            }
        }

        private void contextMenuStrip_Filter_Opening(object sender, CancelEventArgs e)
        {
            removeToolStripMenuItem.Enabled = (dataGridView_Filter.SelectedRows.Count > 0);
        }

        private void textBox_RegexPre_TextChanged(object sender, EventArgs e)
        {
            timer_RegExPre.Stop();
            timer_RegExPre.Start();
        }

        private void textBox_RegExMain_TextChanged(object sender, EventArgs e)
        {
            timer_RegExMain.Stop();
            timer_RegExMain.Start();
        }

        private void textBox_RegExPost_TextChanged(object sender, EventArgs e)
        {
            timer_RegExPost.Stop();
            timer_RegExPost.Start();
        }

        private void timer_RegExPre_Tick(object sender, EventArgs e)
        {

        }
    }
}
