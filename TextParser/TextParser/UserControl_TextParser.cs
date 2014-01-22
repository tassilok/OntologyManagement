using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using Filesystem_Module;

namespace TextParser
{
    public partial class UserControl_TextParser : UserControl
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_TextParser objDataWork_TextParser;
        private clsOntologyItem objOItem_TextParser;
        private clsDataWork_FileResources objDataWork_FileResources;
        private clsDataWork_FileResource_Path objDataWork_FileResource_Path;

        public UserControl_TextParser(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            objDataWork_TextParser = new clsDataWork_TextParser(objLocalConfig);
            objDataWork_FileResources = new clsDataWork_FileResources(objLocalConfig.Globals);
            objDataWork_FileResource_Path = new clsDataWork_FileResource_Path(objLocalConfig.Globals);


        }

        public void InitializeTextParser(clsOntologyItem OItem_TextParser)
        {
            ClearControls();

            objOItem_TextParser = OItem_TextParser;

            if (OItem_TextParser != null)
            {
                objDataWork_TextParser.GetData_TextParser(objOItem_TextParser);
                if (objDataWork_TextParser.OItem_Result_TextParser.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objDataWork_TextParser.CreateRefItems(objOItem_TextParser);
                    var objTextParser = objDataWork_TextParser.OItem_EntryValueParser ??
                                        objDataWork_TextParser.OItem_FieldExtractorParser;

                    if (objTextParser != null)
                    {
                        textBox_SubParser.Text = objTextParser.Name;
                    }
                    button_SubParser.Enabled = true;

                    if (objDataWork_TextParser.OItem_FileResource != null)
                    {
                        textBox_FileResource.Text = objDataWork_TextParser.OItem_FileResource.Name;
                    }
                    button_FileResource.Enabled = true;

                    if (objDataWork_TextParser.OItem_Index != null)
                    {
                        textBox_Index.Text = objDataWork_TextParser.OItem_Index.Name;
                    }

                    button_Index.Enabled = true;

                    if (objDataWork_TextParser.OItem_LineSeperator != null)
                    {
                        textBox_LineSeperator.Text = objDataWork_TextParser.OItem_LineSeperator.Name;
                    }

                    button_LineSeperator.Enabled = true;

                    if (objDataWork_TextParser.OItem_User != null)
                    {
                        textBox_User.Text = objDataWork_TextParser.OItem_User.Name;
                    }
                }
            }
        }

        private void ClearControls()
        {
            textBox_FileResource.Text = "";
            textBox_FileResourceDetail.Text = "";
            textBox_Index.Text = "";
            textBox_IndexDetails.Text = "";
            textBox_LineSeperator.Text = "";
            textBox_SubParser.Text = "";
            textBox_User.Text = "";

            button_FileResource.Enabled = false;
            button_Index.Enabled = false;
            button_LineSeperator.Enabled = false;
            button_SubParser.Enabled = false;
            button_User.Enabled = false;
        }

        private void textBox_FileResource_TextChanged(object sender, EventArgs e)
        {
            timer_FileResources.Stop();
            if (textBox_FileResource.Text != "")
            {
                if (objDataWork_TextParser.OItem_FileResource != null)
                {
                    var objOItem_Type =
                        objDataWork_FileResources.GetResourceType(objDataWork_TextParser.OItem_FileResource);

                    if (objOItem_Type.GUID == objDataWork_FileResources.OItem_Class_File.GUID)
                    {
                        textBox_FileResourceDetail.Text = "Type - File: Not Implemented";
                    }
                    else if (objOItem_Type.GUID == objDataWork_FileResources.OItem_Class_Path.GUID)
                    {
                        objDataWork_FileResource_Path.GetData_Attributes(objDataWork_TextParser.OItem_FileResource);
                        var objOItem_Result = objDataWork_FileResource_Path.OItem_Result_Attributes;
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            
                            objDataWork_FileResource_Path.GetData_Relations(
                                objDataWork_TextParser.OItem_FileResource);
                            objOItem_Result = objDataWork_FileResource_Path.OItem_Result_Relations;
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                
                                
                                textBox_FileResourceDetail.Text = objDataWork_FileResource_Path.objOAItem_Pattern !=
                                                                    null
                                                                        ? "Pattern: " + objDataWork_FileResource_Path
                                                                            .objOAItem_Pattern.Val_String
                                                                        : "";

                                if (textBox_FileResourceDetail.Text != "")
                                {
                                    textBox_FileResourceDetail.Text += "\r\n";
                                }

                                textBox_FileResourceDetail.Text += "Path: " + objDataWork_FileResource_Path.Path;

                                
                            }
                            else
                            {
                                textBox_FileResourceDetail.Text = "Error";
                            }

                        }
                        else
                        {
                            textBox_FileResourceDetail.Text = "Error";
                        }
                    }
                    else if (objOItem_Type.GUID == objDataWork_FileResources.OItem_Class_WebConnection.GUID)
                    {
                        textBox_FileResourceDetail.Text = "Type - File: Not Implemented";
                    }
                    else
                    {
                        textBox_FileResourceDetail.Text = "Error";
                    }
                }
            }
            
        }

        private void textBox_Index_TextChanged(object sender, EventArgs e)
        {
            timer_Index.Stop();

            if (textBox_Index.Text != "")
            {
                if (objDataWork_TextParser.OItem_Index != null)
                {
                    var objOItem_Result = objDataWork_TextParser.GetData_IndexData(objDataWork_TextParser.OItem_Index);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        timer_Index.Start();
                    }
                    else
                    {
                        MessageBox.Show(this, "Der Index konnte nicht ermittelt werden.", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            
        }

        private void timer_Index_Tick(object sender, EventArgs e)
        {
            if (objDataWork_TextParser.OItem_Result_Index.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                progressBar_Index.Value = 50;
            }
            else if (objDataWork_TextParser.OItem_Result_Index.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                timer_Index.Stop();
                textBox_IndexDetails.Text = "Index: ";
                if (objDataWork_TextParser.OList_Variables.Any())
                {
                    var Name_Index = objDataWork_TextParser.OItem_Index.Name;
                    foreach (var oItem_Variable in objDataWork_TextParser.OList_Variables)
                    {
                        if (oItem_Variable.GUID == objLocalConfig.OItem_object_user.GUID)
                        {
                            Name_Index = Name_Index.Replace("@" + oItem_Variable.Name + "@", objLocalConfig.OItem_User.GUID);
                        }
                    }

                    textBox_IndexDetails.Text += Name_Index;

                }

                textBox_IndexDetails.Text += "\r\n";

                textBox_IndexDetails.Text += "Server: ";
                if (objDataWork_TextParser.OItem_Server != null)
                {
                    textBox_IndexDetails.Text += objDataWork_TextParser.OItem_Server.Name;
                }

                textBox_IndexDetails.Text += "\r\n";

                textBox_IndexDetails.Text += "Port: ";
                if (objDataWork_TextParser.OItem_Port != null)
                {
                    textBox_IndexDetails.Text += objDataWork_TextParser.OItem_Port.Name;
                }

                progressBar_Index.Value = 0;

            }
            else if (objDataWork_TextParser.OItem_Result_Index.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                timer_Index.Stop();
                progressBar_Index.Value = 0;
                MessageBox.Show(this,"Die Index-Details konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void timer_FileResources_Tick(object sender, EventArgs e)
        {

        }
    }
}
