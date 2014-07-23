using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.IO;
using Filesystem_Module;
using System.Web;

namespace HTMLExport_Module
{
    public class clsHTMLCreation
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_HTMLExport objDataWork_XMLExport;

        private clsBlobConnection objBlobConnection;

        private clsFileWork objFileWork;

        private clsXML objXML;

        private TextWriter objTextWriter;

        public clsOntologyItem OItem_Attribute_Border
        {
            get { return objLocalConfig.OItem_token_tag_attributes_border; }
        }

        public clsOntologyItem OItem_Attribute_SRC
        {
            get { return objLocalConfig.OItem_token_tag_attributes_src; }
        }

        public clsOntologyItem OItem_Attribute_WIDHT
        {
            get { return objLocalConfig.OItem_object_width; }
        }

        public clsOntologyItem OItem_Attribute_HEIGHT
        {
            get { return objLocalConfig.OItem_object_height; }
        }

        public clsOntologyItem OItem_DocType_Bold
        {
            get { return objLocalConfig.OItem_token_document_tag_type_bold; }
        }

        public clsOntologyItem OItem_DocType_Head
        {
            get { return objLocalConfig.OItem_token_html_tag_type_html_head_init_final; }
        }

        public clsOntologyItem OItem_DocType_DocumentInit
        {
            get { return objLocalConfig.OItem_token_html_tag_type_document_init_final; }
        }

        public clsOntologyItem OItem_DocType_Body
        {
            get { return objLocalConfig.OItem_token_document_tag_type_content; }
        }

        public clsOntologyItem OItem_DocType_Title
        {
            get { return objLocalConfig.OItem_token_document_tag_type_title; }
        }

        public clsOntologyItem OItem_DocType_Content
        {
            get { return objLocalConfig.OItem_token_document_tag_type_content; }
        }

        public clsOntologyItem OItem_DocType_Paragraph
        {
            get { return objLocalConfig.OItem_token_document_tag_type_paragraph; }
        }

        public clsOntologyItem OItem_DocType_Images
        {
            get { return objLocalConfig.OItem_token_document_tag_type_images; }
        }

        public clsOntologyItem OItem_DocType_Table
        {
            get { return objLocalConfig.OItem_token_document_tag_type_table; }
        }

        public clsOntologyItem OItem_DocType_TableRow
        {
            get { return objLocalConfig.OItem_token_document_tag_type_table_row; }
        }

        public clsOntologyItem OItem_DocType_TableCol
        {
            get { return objLocalConfig.OItem_token_document_tag_type_table_col; }
        }

        public clsOntologyItem OItem_DocType_PDFsMedia
        {
            get { return objLocalConfig.OItem_object_pdfs_media; }
        }


        private Dictionary<string, string> attributes;

        public void Add_Attribute(string strAttrib, string strValue)
        {
            if (attributes == null)
            {
                Initialize_Attributes();
            }

            attributes.Add(strAttrib, strValue);
        }

        public void Del_Attribute(string strAttrib)
        {
            if (attributes != null)
            {
                attributes.Remove(strAttrib);
            }
        }

        public void Initialize_Attributes()
        {
            attributes = new Dictionary<string, string>();
        }


        public string Get_HTML_Intro()
        {
            var oAItem_HTMLIntro = objXML.get_XML(objLocalConfig.OItem_token_xml_html_intro);

            if (oAItem_HTMLIntro != null)
            {
                return oAItem_HTMLIntro.Val_String;
            }
            else
            {
                return null;
            }
        }

        public string Get_HTML_Tag(clsOntologyItem OItem_DocumentType, bool boolFinalize)
        {
            var strHTMLHead = "";
            var strHTMLEndInit = "";
            var strHTMLEnd = "";

            var strStart = objDataWork_XMLExport.GetStart;

            if (strStart != null)
            {
                strHTMLHead = strStart;
                if (boolFinalize)
                {
                    strHTMLEndInit = objDataWork_XMLExport.GetEndInit;
                    if (strHTMLEndInit != null)
                    {
                        strHTMLHead += strHTMLEndInit;
                    }
                    else
                    {
                        strHTMLHead = null;
                    }
                }

                if (strHTMLHead != null)
                {
                    var objOItem_Tag = objDataWork_XMLExport.GetHtmlTag(OItem_DocumentType);

                    if (objOItem_Tag != null)
                    {
                        strHTMLHead += objOItem_Tag.Name;

                        if (!boolFinalize)
                        {
                            if (attributes != null)
                            {
                                strHTMLHead = attributes.Aggregate(strHTMLHead, (current, attribute) => current + (" " + attribute.Key + "=" + "\"" + attribute.Value + "\""));
                                attributes.Clear();
                            }
                            
                        }

                        strHTMLEnd = objDataWork_XMLExport.GetEnd;

                        if (strHTMLEnd != null)
                        {
                            strHTMLHead += strHTMLEnd;
                        }
                        else
                        {
                            strHTMLHead = null;
                        }
                    }
                    else
                    {
                        strHTMLHead = null;
                    }
                }
            }
            else
            {
                strHTMLHead = null;
            }

            return strHTMLHead;
        }

        public string Get_HTML_Heading(int intLevel, bool boolFinalize)
        {
            var strHTMLHeading = "";
            var strHTMLEndInit = "";
            var strHTMLEnd = "";

            var strStart = objDataWork_XMLExport.GetStart;

            if (strStart != null)
            {
                strHTMLHeading = strStart;
                if (boolFinalize)
                {
                    strHTMLEndInit = objDataWork_XMLExport.GetEndInit;
                    if (strHTMLEndInit != null)
                    {
                        strHTMLHeading += strHTMLEndInit;
                    }
                    else
                    {
                        strHTMLHeading = null;
                    }
                }

                if (strHTMLHeading != null)
                {
                    var objOItem_Tag = objDataWork_XMLExport.GetHtmlTag(objLocalConfig.OItem_token_html_tag_type_heading, intLevel);

                    if (objOItem_Tag != null)
                    {
                        strHTMLHeading += objOItem_Tag.Name;

                        if (!boolFinalize)
                        {
                            if (attributes != null)
                            {
                                strHTMLHeading = attributes.Aggregate(strHTMLHeading, (current, attribute) => current + (" " + attribute.Key + "=" + "\"" + attribute.Value + "\""));
                            }
                        }

                        strHTMLEnd = objDataWork_XMLExport.GetEnd;

                        if (strHTMLEnd != null)
                        {
                            strHTMLHeading += strHTMLEnd;
                        }
                        else
                        {
                            strHTMLHeading = null;
                        }
                    }
                    else
                    {
                        strHTMLHeading = null;
                    }
                }
            }
            else
            {
                strHTMLHeading = null;
            }

            return strHTMLHeading;
        }

        public clsOntologyItem Initialize_ExportFolder()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Nothing.Clone();

            if (!Directory.Exists(objDataWork_XMLExport.OItem_Folder.Additional1))
            {
                try
                {
                    Directory.CreateDirectory(objDataWork_XMLExport.OItem_Folder.Additional1);
                }
                catch (Exception ex)
                {

                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                }
            }

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                objDataWork_XMLExport.OItem_Folder.Additional2 = objDataWork_XMLExport.OItem_Folder.Additional1 +
                                                                 (!objDataWork_XMLExport.OItem_Folder.Additional1
                                                                                        .EndsWith("\\")
                                                                      ? "\\"
                                                                      : "") + "Resources";
                if (!Directory.Exists(objDataWork_XMLExport.OItem_Folder.Additional2))
                {
                    try
                    {
                        Directory.CreateDirectory(objDataWork_XMLExport.OItem_Folder.Additional2);
                    }
                    catch (Exception)
                    {
                        objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();

                    }
                }
            }

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            }

            return objOItem_Result;
        }

        public clsOntologyItem Open_TextWriter(string fileName)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            if (objDataWork_XMLExport.OItem_Folder != null && string.IsNullOrEmpty(objDataWork_XMLExport.OItem_Folder.Additional1))
            {
                objOItem_Result = Initialize_ExportFolder();
            }

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                try
                {
                    var strPath = objFileWork.merge_paths(objDataWork_XMLExport.OItem_Folder.Additional1, fileName);
                    strPath = strPath + ".html";
                    objTextWriter = new StreamWriter(strPath,false,System.Text.Encoding.UTF8);
                    objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
                }
                catch (Exception)
                {

                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                }
            }

            return objOItem_Result;
        }

        public clsOntologyItem Close_TextWriter()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            try
            {
                objTextWriter.Close();
            }
            catch (Exception)
            {
                
                
            }

            return objOItem_Result;
        }

        public clsOntologyItem Write_Line(string strLine)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            try
            {
                objTextWriter.WriteLine(strLine);
                objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            }
            catch (Exception)
            {

                objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
            }

            return objOItem_Result;
        }

        public string Encode_HTML(string strInput)
        {
            strInput = HttpUtility.HtmlEncode(strInput);

            return strInput;
        }

        public clsOntologyItem Export_File(clsOntologyItem OItem_File)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var strExtension = "";

            if (objFileWork.is_File_Blob(OItem_File))
            {
                if (string.IsNullOrEmpty(objDataWork_XMLExport.OItem_Folder.Additional2))
                {
                    objOItem_Result = objDataWork_XMLExport.GetSubData_Folder();

                }

                if (!string.IsNullOrEmpty(objDataWork_XMLExport.OItem_Folder.Additional2))
                {
                    if (OItem_File.Name.LastIndexOf(".") > 0)
                    {
                        strExtension = OItem_File.Name.Substring(OItem_File.Name.LastIndexOf("."));

                        OItem_File.Additional1 = "./Resources/" + OItem_File.GUID + strExtension;
                        OItem_File.Additional2 = objFileWork.merge_paths(objDataWork_XMLExport.OItem_Folder.Additional2, OItem_File.GUID + strExtension);
                        if (File.Exists(OItem_File.Additional2))
                        {
                            try
                            {
                                File.Delete(OItem_File.Additional2);
                            }
                            catch (Exception ex)
                            {
                                objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                            }
                            
                        }

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objOItem_Result = objBlobConnection.save_Blob_To_File(OItem_File, OItem_File.Additional2);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                objOItem_Result.Additional1 = OItem_File.Additional1;
                            }
                        }
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

            return objOItem_Result;
        }

        public clsHTMLCreation(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            
            Initialize();
        }

        public clsHTMLCreation(clsGlobals Globals)
        {
            objLocalConfig = new clsLocalConfig(Globals);

            Initialize();
        }

        private void Initialize()
        {
            objFileWork = new clsFileWork(objLocalConfig.Globals);

            objBlobConnection = new clsBlobConnection(objLocalConfig.Globals);

            objDataWork_XMLExport = new clsDataWork_HTMLExport(objLocalConfig);

            objXML = new clsXML(objLocalConfig);

            var objOItem_Result = objDataWork_XMLExport.GetBaseData();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                throw new Exception("Config-Error");
            }
        }
    }
}
