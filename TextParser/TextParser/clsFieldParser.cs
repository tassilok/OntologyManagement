using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using System.IO;
using System.Text.RegularExpressions;
using Filesystem_Module;

namespace TextParser
{
    public class clsFieldParser
    {
        private clsLocalConfig objLocalConfig;
        private List<clsField> ParseFieldList;
        private clsOntologyItem objOItem_TextParser;
        private clsDataWork_FileResources objDataWork_FileResource;
        private clsDataWork_FileResource_Path objDataWork_FileResource_Path;

        private clsDataWork_TextParser objDataWork_TextParser;


        private clsAppDBLevel objAppDBLevel;

        private List<clsOntologyItem> OList_Variables;

        private clsOntologyItem objOItem_Type;

        private int port;
        private string index;
        private string server;
        private List<clsFile> fileList;

        public List<clsOntologyItem> OList_Seperator { get; set; }

        public clsFieldParser(clsLocalConfig LocalConfig, List<clsField> ParseFieldList, clsOntologyItem OItem_TextParser, clsOntologyItem OITem_Type)
        {
            objLocalConfig = LocalConfig;
            objOItem_Type = OITem_Type;
            this.ParseFieldList = ParseFieldList;
            objOItem_TextParser = OItem_TextParser;
            if (Initialize().GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                throw new Exception("Config-Error");
            }
        }

        private clsOntologyItem Initialize()
        {
            
            objDataWork_FileResource = new clsDataWork_FileResources(objLocalConfig.Globals);
            objDataWork_FileResource_Path = new clsDataWork_FileResource_Path(objLocalConfig.Globals);
            objDataWork_TextParser = new clsDataWork_TextParser(objLocalConfig);
            objDataWork_TextParser.GetData_TextParser(objOItem_TextParser);
            var objOItem_Result = objDataWork_TextParser.OItem_Result_TextParser;

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objDataWork_TextParser.CreateRefItems(objOItem_TextParser);
                var objOItem_Index = objDataWork_TextParser.OItem_Index;
                objDataWork_TextParser.GetData_IndexData(objOItem_Index);
                while (objDataWork_TextParser.OItem_Result_Index.GUID == objLocalConfig.Globals.LState_Nothing.GUID){}

                if (objDataWork_TextParser.OItem_Result_Index.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    
                    if (objDataWork_TextParser.OItem_FileResource != null)
                    {
                        port = int.Parse(objDataWork_TextParser.OItem_Port.Name);
                        server = objDataWork_TextParser.OItem_Server.Name;
                        index = "";
                        if (objDataWork_TextParser.OItem_Index != null)
                        {
                            index = objDataWork_TextParser.OItem_Index.Name.ToLower();
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
                                            objAppDBLevel = new clsAppDBLevel(server, port, index.ToLower(),
                                                                              objLocalConfig.Globals.SearchRange,
                                                                              objLocalConfig.Globals.Session);
                                            fileList = objDataWork_FileResource_Path.FileList;
                                            
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

            return objOItem_Result;
        }

        public clsOntologyItem Parse()
        {
            var fileDate_Create = false;
            var fileDate_LastChange = false;
            var docCount = 0;
            long fileLine = 0;
            
            if (OList_Variables != null && OList_Variables.Any())
            {
                foreach (var oItem_Variable in OList_Variables)
                {
                    if (oItem_Variable.GUID == objLocalConfig.OItem_object_user.GUID)
                    {
                        index = index.Replace("@" + oItem_Variable.Name.ToLower() + "@", objLocalConfig.OItem_User.GUID.ToLower());
                    }
                    else if (oItem_Variable.GUID == objLocalConfig.OItem_object_filedate_create.GUID)
                    {
                        fileDate_Create = true;
                    }
                    else if (oItem_Variable.GUID == objLocalConfig.OItem_object_filedate_lastchange.GUID)
                    {
                        fileDate_LastChange = true;
                    }
                }
            }

            foreach (var file in fileList)
            {
                fileLine = 0;
                if (fileDate_Create)
                {
                    index = index.Replace("@" + objLocalConfig.OItem_object_filedate_create.Name.ToLower() + "@", File.GetCreationTime(file.FileName).ToString("yyyyMMdd"));

                }
                if (fileDate_LastChange)
                {
                    index = index.Replace("@" + objLocalConfig.OItem_object_filedate_lastchange.Name.ToLower() + "@", File.GetLastWriteTime(file.FileName).ToString("yyyyMMdd"));
                }

                var dictList = new List<clsAppDocuments>();
                //try
                //{
                    
                    var textReader = new StreamReader(file.FileName);


                    
                    var text = "";
                    var UserFields = ParseFieldList.Where(f => f.IsMeta == false).ToList();
                    while (!textReader.EndOfStream)
                    {
                        var parse = true;
                        var add = false;
                        var addChar = false;
                        var dontAddUser = false;
                        var dictMeta = new Dictionary<string, object>();
                        var dictUser = new Dictionary<string, object>();

                        if (OList_Seperator == null  || ( OList_Seperator.Any() && OList_Seperator.First().Name == "\\r\\n"))
                            text = textReader.ReadLine();
                        else
                        {
                            addChar = true;
                            text = "";

                            StringBuilder line = new StringBuilder();
                            var length = 1;
                            var tester = "";
                            var finished = false;
                            while (!finished && !textReader.EndOfStream)
                            {
                                length = line.Length;
                                char singleChar = (char)textReader.Read();
                                tester += singleChar;
                                if (OList_Seperator.Any(s => tester.EndsWith(s.Name)))
                                {
                                    text = tester.ToString();
                                    finished = true;    
                                }
                                
                                

                            }

                            
                        }

                        
                        var textParse = text;
                        var Id = objLocalConfig.Globals.NewGUID;
                        var ixStart = 0;
                        var fieldNotFound = false;
                        var textParseBase = text;
                        fileLine ++;
                        foreach (var field in ParseFieldList.OrderBy(p => p.IsMeta).ThenBy(p => p.OrderId).ToList())
                        {
                            fieldNotFound = false;
                            var getIxStart = true;
                            if (field.IsMeta)
                            {
                                if (field.ID_MetaField == objLocalConfig.OItem_object_message.GUID)
                                {
                                    dictMeta.Add(field.Name_MetaField, text);
                                }
                                else if (field.ID_MetaField == objLocalConfig.OItem_object_filepath.GUID)
                                {
                                    dictMeta.Add(field.Name_MetaField, file.FileName);
                                }
                                else if (field.ID_MetaField == objLocalConfig.OItem_object_filename.GUID)
                                {
                                    dictMeta.Add(field.Name_Field, Path.GetFileName(file.FileName));
                                }
                                else if (field.ID_MetaField == objLocalConfig.OItem_object_guid.GUID)
                                {
                                    Id = objLocalConfig.Globals.NewGUID;
                                    dictMeta.Add(field.Name_Field, Id);
                                }
                                else if (field.ID_MetaField == objLocalConfig.OItem_object_date.GUID)
                                {
                                    dictMeta.Add(field.Name_Field, DateTime.Now.Date);
                                }
                                else if (field.ID_MetaField == objLocalConfig.OItem_object_datetimestamp.GUID)
                                {
                                    dictMeta.Add(field.Name_Field, DateTime.Now);
                                }
                                else if (field.ID_MetaField == objLocalConfig.OItem_object_filedate__create_.GUID)
                                {
                                    dictMeta.Add(field.Name_Field, File.GetCreationTime(file.FileName).Date);
                                }
                                else if (field.ID_MetaField == objLocalConfig.OItem_object_filedate__last_change_.GUID)
                                {
                                    dictMeta.Add(field.Name_Field, File.GetLastWriteTime(file.FileName).Date);
                                }
                                else if (field.ID_MetaField == objLocalConfig.OItem_object_filedatetime__create_.GUID)
                                {
                                    dictMeta.Add(field.Name_Field, File.GetCreationTime(file.FileName));
                                }
                                else if (field.ID_MetaField ==
                                         objLocalConfig.OItem_object_filedatetime__last_change_.GUID)
                                {
                                    dictMeta.Add(field.Name_Field, File.GetLastWriteTime(file.FileName));
                                }
                                else if (field.ID_MetaField == objLocalConfig.OItem_object_fileline.GUID)
                                {
                                    dictMeta.Add(field.Name_Field, fileLine);
                                }
                            }
                            else
                            {


                                // Regex-Pre
                                if (field.ID_RegExPre != null &&
                                    field.ID_RegExPre != objLocalConfig.OItem_object_empty.GUID)
                                {
                                    var objRegExPre = new Regex(field.RegexPre);

                                    // Regex im Text suchen
                                    var objMatches = objRegExPre.Matches(textParse);
                                    if (objMatches.Count > 0 && objMatches[0].Length > 0)
                                    {

                                        textParse =
                                            textParse.Substring(objMatches[0].Index +
                                                                objMatches[0].Length);

                                        ixStart = ixStart + objMatches[0].Index +
                                                    objMatches[0].Length - 1;

                                        parse = true;
                                    }
                                    else
                                    {
                                        parse = false;
                                    }
                                }
                                else
                                {
                                    parse = true;
                                }

                                if (parse)
                                {
                                    if (field.ID_RegExPost != null &&
                                        field.ID_RegExPost != objLocalConfig.OItem_object_empty.GUID)
                                    {
                                        var objRegExPost = new Regex(field.RegexPost);
                                        var objMatches = objRegExPost.Matches(textParse);

                                        if (objMatches.Count > 0 && objMatches[0].Length > 0)
                                        {
                                            textParse = textParse.Substring(0, objMatches[0].Index);
                                            ixStart += objMatches[0].Index + objMatches[0].Length - 1;
                                            getIxStart = false;
                                        }
                                        else
                                        {
                                            parse = false;
                                        }
                                    }
                                    else
                                    {
                                        parse = true;
                                    }
                                }

                                if (parse)
                                {
                                    if (field.ID_RegExMain != null &&
                                        field.ID_RegExMain != objLocalConfig.OItem_object_empty.GUID)
                                    {
                                        var objRegEx = new Regex(field.Regex);
                                        var objMatches = objRegEx.Matches(textParse);

                                        if (objMatches.Count > 0 && objMatches[0].Length>0)
                                        {
                                            textParse = textParse.Substring(objMatches[0].Index,
                                                                            objMatches[0].Length);
                                            if (getIxStart)
                                                ixStart += objMatches[0].Index + objMatches[0].Length - 1;

                                        }
                                        else
                                        {
                                            parse = false;
                                        }
                                    }
                                }

                                if (parse)
                                {
                                    if (field.ID_DataType == objLocalConfig.OItem_object_string.GUID)
                                    {
                                        dictUser.Add(field.Name_Field, textParse);
                                    }
                                    else if (field.ID_DataType == objLocalConfig.OItem_object_bit.GUID)
                                    {
                                        var value = true;

                                        if (bool.TryParse(textParse, out value))
                                        {
                                            dictUser.Add(field.Name_Field, value);
                                        }
                                        else
                                        {
                                            parse = false;
                                        }
                                    }
                                    else if (field.ID_DataType == objLocalConfig.OItem_object_int.GUID)
                                    {
                                        var value = 0;

                                        if (int.TryParse(textParse, out value))
                                        {
                                            dictUser.Add(field.Name_Field, value);
                                        }
                                        else
                                        {
                                            parse = false;
                                        }
                                    }
                                    else if (field.ID_DataType == objLocalConfig.OItem_object_datetime.GUID)
                                    {
                                        DateTime value;
                                        if (DateTime.TryParse(textParse, out value))
                                        {
                                            dictUser.Add(field.Name_Field, value);
                                        }
                                        else
                                        {
                                            parse = false;
                                        }
                                    }
                                    else if (field.ID_DataType == objLocalConfig.OItem_object_double.GUID)
                                    {
                                        double value;
                                        if (double.TryParse(textParse, out value))
                                        {
                                            dictUser.Add(field.Name_Field, value);
                                        }
                                        else
                                        {
                                            parse = false;
                                        }
                                    }
                                }

                                
                                if (!parse) dontAddUser = true;

                                if (field.RemoveFromSource)
                                {
                                    if (textParseBase.Length > ixStart)
                                        textParseBase = text.Substring(ixStart);
                                    else
                                        textParseBase = text;

                                    if (text.Length - 1 > ixStart + textParse.Length)
                                        textParse = text.Substring(ixStart + textParse.Length);
                                    else
                                        textParse = text;
                                }
                                else
                                {
                                    textParse = textParseBase;
                                }

                         
                                
                            }



                        }

                        if (dictMeta.Any() || (!UserFields.Any() || dictUser.Any()))
                        {
                            //if (dontAddUser) dictUser.Clear();
                            dictUser =  dictUser.Union(dictMeta).ToDictionary(pair => pair.Key, pair => pair.Value);
                            var objDoc = new clsAppDocuments { Id = Id, Dict = dictUser };
                            dictList.Add(objDoc);
                            docCount = docCount + 1;
                            if (docCount == objLocalConfig.Globals.SearchRange)
                            {
                                var objOItem_Result = objAppDBLevel.Save_Documents(dictList, "Doc", index.ToLower());
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                                {
                                    return objOItem_Result;
                                }
                                dictList.Clear();
                            }    
                        }
                        else
                        {
                            textParse = text;
                        }
                        
                        
                    }
                    
                    if (dictList.Count > 0)
                    {
                        var objOItem_Result = objAppDBLevel.Save_Documents(dictList, objOItem_Type != null ? objOItem_Type.Name : objOItem_Type != null ? objOItem_Type.Name : "Doc", index);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                        {
                            return objOItem_Result;
                        }
                    }
                    textReader.Close();
                //}
                //catch (Exception ex)
                //{

                //    return objLocalConfig.Globals.LState_Error.Clone();
                //}
                

                
            }

            return objLocalConfig.Globals.LState_Success.Clone();
        }

       
    }
}
