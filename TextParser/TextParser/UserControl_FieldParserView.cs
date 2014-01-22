using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using Structure_Module;
using Filesystem_Module;
using System.IO;

namespace TextParser
{
    public partial class UserControl_FieldParserView : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private clsOntologyItem objOItem_Parser;
        private clsOntologyItem objOItem_TextParser;

        private clsDataWork_FieldParser objDataWork_FieldParser;
        private clsDataWork_TextParser objDataWork_TextParser;
        private clsDataWork_FileResources objDataWork_FileResource;
        private clsDataWork_FileResource_Path objDataWork_FileResource_Path;

        private clsAppDBLevel objAppDBLevel;

        private clsFieldParser objFieldParser;

        private int page = 0;
        private int pages = 0;
        private int pos = 0;

        private int port = 0;
        private string server = "";
        private List<string> indexes = new List<string>();

        public UserControl_FieldParserView(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            
            objLocalConfig = LocalConfig;

            Initialize();
        }

        public void InitializeView(clsOntologyItem OItem_FieldParser, clsOntologyItem OItem_TextParser)
        {
            objOItem_Parser = OItem_FieldParser;
            objOItem_TextParser = OItem_TextParser;
            toolStripTextBox_Parser.Text = objOItem_Parser.Name;



            GetFields();
        }

        private void Initialize()
        {
            
            var OList_Variables=new List<clsOntologyItem>();
            var fileList = new List<clsFile>();

            indexes.Clear();

            objDataWork_FieldParser = new clsDataWork_FieldParser(objLocalConfig);

            objDataWork_TextParser = new clsDataWork_TextParser(objLocalConfig);
            objDataWork_FileResource = new clsDataWork_FileResources(objLocalConfig.Globals);
            objDataWork_FileResource_Path = new clsDataWork_FileResource_Path(objLocalConfig.Globals);

            objDataWork_TextParser.GetData_TextParser(objOItem_TextParser);
            var objOItem_Result = objDataWork_TextParser.OItem_Result_TextParser;

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objDataWork_TextParser.CreateRefItems(objOItem_TextParser);
                var objOItem_Index = objDataWork_TextParser.OItem_Index;
                objDataWork_TextParser.GetData_IndexData(objOItem_Index);
                while (objDataWork_TextParser.OItem_Result_Index.GUID == objLocalConfig.Globals.LState_Nothing.GUID) { }

                if (objDataWork_TextParser.OItem_Result_Index.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {

                    if (objDataWork_TextParser.OItem_FileResource != null)
                    {
                        var index = "";
                        port = int.Parse(objDataWork_TextParser.OItem_Port.Name);
                        server = objDataWork_TextParser.OItem_Server.Name;
                        if (objDataWork_TextParser.OItem_Index != null)
                        {
                            index = objDataWork_TextParser.OItem_Index.Name;
                        }

                        if (objDataWork_TextParser.OList_Variables != null)
                        {
                            OList_Variables = objDataWork_TextParser.OList_Variables;
                        }

                        if (objDataWork_TextParser.OItem_FileResource != null)
                        {
                            var objOItem_ResourceType =
                                objDataWork_FileResource.GetResourceType(objDataWork_TextParser.OItem_FileResource);

                            if (objOItem_ResourceType.GUID == objDataWork_FileResource.OItem_Class_File.GUID)
                            {
                                objOItem_Result = objLocalConfig.Globals.LState_Relation;

                            }
                            else if (objOItem_ResourceType.GUID == objDataWork_FileResource.OItem_Class_Path.GUID)
                            {
                                objDataWork_FileResource_Path.GetData_Attributes(objDataWork_TextParser.OItem_FileResource);
                                if (objDataWork_FileResource_Path.OItem_Result_Attributes.GUID ==
                                    objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    objDataWork_FileResource_Path.GetData_Relations(objDataWork_TextParser.OItem_FileResource);
                                    if (objDataWork_FileResource_Path.OItem_Result_Relations.GUID ==
                                        objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        objDataWork_FileResource_Path.GetFiles();
                                        if (objDataWork_FileResource_Path.OItem_Result_FileResult.GUID ==
                                            objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            var fileDate_Create = false;
                                            var fileDate_LastChange = false;
                                            
                                            fileList = objDataWork_FileResource_Path.FileList;
                                            if (OList_Variables != null && OList_Variables.Any())
                                            {
                                                foreach (var oItem_Variable in OList_Variables)
                                                {
                                                    if (oItem_Variable.GUID == objLocalConfig.OItem_object_user.GUID)
                                                    {
                                                        index = index.Replace("@" + oItem_Variable.Name + "@",
                                                                              objLocalConfig.OItem_User.Name);
                                                    }
                                                    else if (oItem_Variable.GUID ==
                                                             objLocalConfig.OItem_object_filedate_create.GUID)
                                                    {
                                                        fileDate_Create = true;
                                                    }
                                                    else if (oItem_Variable.GUID ==
                                                             objLocalConfig.OItem_object_filedate_lastchange.GUID)
                                                    {
                                                        fileDate_LastChange = true;
                                                    }
                                                }
                                            }

                                            
                                            objAppDBLevel = new clsAppDBLevel(server, port, index,
                                                                              objLocalConfig.Globals.SearchRange,
                                                                              objLocalConfig.Globals.Session);

                                            
                                        }
                                    
                                    }
                                }

                            }
                            else if (objOItem_ResourceType.GUID ==
                                     objDataWork_FileResource.OItem_Class_WebConnection.GUID)
                            {
                                objOItem_Result = objLocalConfig.Globals.LState_Relation;
                            }
                            else
                            {
                                objOItem_Result = objLocalConfig.Globals.LState_Error;
                            }
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





                }


            }
        }

        private void GetFields()
        {
            var objOItem_Result = objDataWork_FieldParser.GetData_FieldsOfFieldParser();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var FieldList = new SortableBindingList<clsField>(objDataWork_FieldParser.FieldList.Where(p => p.ID_FieldParser == objOItem_Parser.GUID).OrderBy(f => f.OrderId).ThenBy(f => f.Name_Field));
                dataGridView_Fields.DataSource = FieldList;
                foreach (DataGridViewColumn column in dataGridView_Fields.Columns)
                {
                    if (column.Name == "ID_FieldParser" ||
                        column.Name == "ID_Field" ||
                        column.Name == "ID_RegExPre" ||
                        column.Name == "ID_Attribute_RegExPreVal" ||
                        column.Name == "ID_RegExMain" ||
                        column.Name == "ID_Attribute_RegExMainVal" ||
                        column.Name == "ID_RegExPost" ||
                        column.Name == "ID_Attribute_RegExPostVal" ||
                        column.Name == "ID_DataType" ||
                        column.Name == "ID_Attribute_UseOrderID" ||
                        column.Name == "ID_Attribute_RemoveFromSource" ||
                        column.Name == "ID_MetaField" ||
                        column.Name == "Name_MetaField")
                    {
                        column.Visible = false;
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Fehler beim Ermitteln der Daten!", "Fehler!", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }

        }

        private void GetPage()
        {
             
        }

        private void toolStripButton_Parse_Click(object sender, EventArgs e)
        {
            var fieldList = (SortableBindingList<clsField>) dataGridView_Fields.DataSource;
            if (fieldList.Any())
            {
                objFieldParser = new clsFieldParser(objLocalConfig,fieldList.ToList(),objOItem_TextParser);
                objFieldParser.Parse();
            }
        }

    }
}
