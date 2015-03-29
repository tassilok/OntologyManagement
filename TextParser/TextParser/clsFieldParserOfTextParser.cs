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
    public class clsFieldParserOfTextParser
    {
        public delegate void ParsedLines(long countParsed, long countSaved);
        public event ParsedLines parsedLines;
        public delegate void FinishedParsing();
        public event FinishedParsing finishedParsing;

        private clsLocalConfig objLocalConfig;
        private List<clsField> ParseFieldList;
        private clsOntologyItem objOItem_TextParser;
        private clsDataWork_FileResources objDataWork_FileResource;
        private clsDataWork_FileResource_Path objDataWork_FileResource_Path;

        private clsDataWork_TextParser objDataWork_TextParser;
        public clsDataWork_TextParser DataWork_TextParser_Parent { get; set; }

        private clsAppDBLevel objAppDBLevel;
        private clsAppDBLevel objAppDBLevel_ParentParser;

        private List<clsOntologyItem> OList_Variables;

        private clsOntologyItem objOItem_Type;

        private int port;
        private string index;
        private string server;
        public List<clsFile> fileList { get; set; }

        private Dictionary<string, object> dictMeta;
        private Dictionary<string, object> dictUser;
        private List<clsAppDocuments> dictList;
        private List<clsField> UserFields;
        private clsFileMeta objFileMeta;

        public List<clsOntologyItem> OList_Seperator { get; set; }

        private List<clsObjectRel> oList_ConfigurationItems;

        private long docCount;

        private bool createFileList;

        private string numberSeperator;
        private string numberSeperatorReplace;
        private clsOntologyItem oItem_SourceField;

        public clsOntologyItem OItem_Result { get; private set; }

        private ParseResult parseResult = new ParseResult();

        public bool AbortParseProcess { get; set; }

        public clsFieldParserOfTextParser(clsLocalConfig LocalConfig, List<clsField> ParseFieldList, clsOntologyItem OItem_TextParser, clsOntologyItem OITem_Type, bool CreateFileList = true)
        {
            objLocalConfig = LocalConfig;
            objOItem_Type = OITem_Type;
            this.ParseFieldList = ParseFieldList;
            objOItem_TextParser = OItem_TextParser;
            createFileList = CreateFileList;
            if (Initialize().GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                throw new Exception("Config-Error");
            }
        }

        private void GetNumberSeperator()
        {
            var testTxt = "8.4";
            double testDbl = double.Parse(testTxt);
            if (testDbl == 8.4)
            {
                numberSeperator = ".";
                numberSeperatorReplace = ",";
            }
            else
            {
                numberSeperator = ",";
                numberSeperatorReplace = ".";
            }

        }

        private clsOntologyItem Initialize()
        {
            GetNumberSeperator();
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
                    oList_ConfigurationItems = objDataWork_TextParser.OList_ConfigurationItems;
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

                            if (createFileList)
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
                                objAppDBLevel = new clsAppDBLevel(server, port, index.ToLower(),
                                                                                  objLocalConfig.Globals.SearchRange,
                                                                                  objLocalConfig.Globals.Session);
                            }
                            
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

        public clsOntologyItem ParseLine(string strLine, bool replaceNewLine, long line)
        {
            var objOItem_Result = ParseText(strLine, replaceNewLine, line);

            return objOItem_Result;
        }

        private Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public void ParseSourceField()
        {
            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var fileDate_Create = false;
            var fileDate_LastChange = false;
            docCount = 0;
            long fileLine = 0;
            objFileMeta = new clsFileMeta();
            long parsedDocumentCount = 0;
            long savedDocumentCount = 0;
            bool replaceNewLine = false;

            int pos = -1;
            int parDocCount = 0;
            var parentPort = int.Parse(DataWork_TextParser_Parent.OItem_Port.Name);
            var parentServer = DataWork_TextParser_Parent.OItem_Server.Name;

            objAppDBLevel_ParentParser = new clsAppDBLevel(parentServer,
                parentPort, DataWork_TextParser_Parent.OItem_Index.Name, objLocalConfig.Globals.SearchRange,
                objLocalConfig.Globals.Session);

            var documents = new List<clsAppDocuments>();

            if (OList_Variables != null && OList_Variables.Any())
            {
                foreach (var oItem_Variable in OList_Variables)
                {
                    if (oItem_Variable.GUID == objLocalConfig.OItem_object_user.GUID)
                    {
                        index = index.Replace("@" + oItem_Variable.Name.ToLower() + "@",
                            objLocalConfig.OItem_User.GUID.ToLower());
                    }
                }
            }

            clsObjectRel configurationItem_OneRecordByFile =
                oList_ConfigurationItems.Where(ci => ci.ID_Other == objLocalConfig.OItem_object_one_record_by_file.GUID)
                    .FirstOrDefault();

            oItem_SourceField = DataWork_TextParser_Parent.OITem_SourceField;
            while (parDocCount != 0)
            {
                documents = objAppDBLevel.GetData_Documents(paging: true, lastPos: pos);
                parDocCount = documents.Count;
                if (parDocCount > 0)
                {
                    foreach (var doc in documents)
                    {
                        if (doc.Dict.ContainsKey(oItem_SourceField.Name))
                        {
                            var id = doc.Id;
                            var content = doc.Dict[oItem_SourceField.Name].ToString();
                            dictList = new List<clsAppDocuments>();
                            //try
                            //{

                            var stringStream = GenerateStreamFromString(content);
                            var textReader = new StreamReader(stringStream, true);
                            var text = "";
                            UserFields = ParseFieldList.Where(f => f.IsMeta == false).ToList();
                            while (!textReader.EndOfStream)
                            {
                                fileLine++;
                                dictMeta = new Dictionary<string, object>();
                                dictUser = new Dictionary<string, object>();

                                if (OList_Seperator == null ||
                                    (OList_Seperator.Any() && OList_Seperator.First().Name == "\\r\\n"))
                                {
                                    
                                    text = textReader.ReadLine();
                                }
                                else
                                {
                                    replaceNewLine = true;
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


                                objOItem_Result = ParseText(text, replaceNewLine, fileLine);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {

                                    if (configurationItem_OneRecordByFile == null)
                                    {
                                        if (docCount > 0 && docCount % objLocalConfig.Globals.SearchRange == 0)
                                        {

                                            var count = dictList.Count;

                                            objOItem_Result = objAppDBLevel.Save_Documents(dictList,
                                                objOItem_Type != null
                                                    ? objOItem_Type.Name
                                                    : objOItem_Type != null ? objOItem_Type.Name : "Doc", index.ToLower());
                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                            {
                                                savedDocumentCount += count;
                                                if (parsedLines != null)
                                                {
                                                    parsedLines(parsedDocumentCount, savedDocumentCount);
                                                }


                                            }
                                            else
                                            {
                                                OItem_Result = objOItem_Result;
                                            }
                                            dictList.Clear();
                                        }
                                    }

                                    parsedDocumentCount++;
                                }
                                else
                                {
                                    OItem_Result = objOItem_Result;
                                }


                            }



                            if (dictList.Count > 0)
                            {
                                if (configurationItem_OneRecordByFile != null)
                                {
                                    var firstItem = dictList.First();
                                    for (var i = 1; i < dictList.Count; i++)
                                    {
                                        firstItem.Dict.Keys.ToList().ForEach(key =>
                                        {
                                            if (firstItem.Dict[key] is string)
                                            {
                                                string strVal = firstItem.Dict[key].ToString() ?? "";
                                                strVal += dictList[i].Dict[key].ToString() ?? "";
                                                firstItem.Dict[key] = strVal;
                                            }
                                            else if (firstItem.Dict[key] is double)
                                            {
                                                double dblVal = (double)firstItem.Dict[key];
                                                dblVal += (double)dictList[i].Dict[key];
                                                firstItem.Dict[key] = dblVal;

                                            }
                                            else if (firstItem.Dict[key] is long)
                                            {
                                                long lngVal = (long)firstItem.Dict[key];
                                                lngVal += (long)dictList[i].Dict[key];
                                                firstItem.Dict[key] = lngVal;
                                            }
                                        });

                                    }
                                    dictList = new List<clsAppDocuments> { firstItem };
                                }

                                var count = dictList.Count;
                                objOItem_Result = objAppDBLevel.Save_Documents(dictList,
                                    objOItem_Type != null
                                        ? objOItem_Type.Name
                                        : objOItem_Type != null ? objOItem_Type.Name : "Doc", index);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    if (parsedLines != null)
                                    {
                                        parsedLines(parsedDocumentCount, savedDocumentCount);
                                    }
                                    savedDocumentCount += count;
                                }
                                else
                                {
                                    OItem_Result = objOItem_Result;
                                }
                            }
                            textReader.Close();
                        }
                        if (finishedParsing != null)
                        {
                            finishedParsing();
                        }
                    }
                }
            }
            




            OItem_Result = objOItem_Result;
            if (finishedParsing != null)
            {
                finishedParsing();
            }
        }

        public void ParseFiles()
        {
            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            var fileDate_Create = false;
            var fileDate_LastChange = false;
            docCount = 0;
            long fileLine = 0;
            objFileMeta = new clsFileMeta();
            long parsedDocumentCount = 0;
            long savedDocumentCount = 0;
            bool replaceNewLine = false;
            
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

            clsObjectRel configurationItem_OneRecordByFile =
                oList_ConfigurationItems.Where(ci => ci.ID_Other == objLocalConfig.OItem_object_one_record_by_file.GUID)
                    .FirstOrDefault();

            if (fileList != null)
            {
                foreach (var file in fileList)
                {
                    if (AbortParseProcess)
                    {
                        AbortParseProcess = false;
                        break;
                    }
                    objFileMeta.FilePath = file.FileName;
                    objFileMeta.FileName = Path.GetFileName(file.FileName);
                    objFileMeta.CreateDate = File.GetCreationTime(file.FileName).Date;
                    objFileMeta.LastWriteDate = File.GetLastWriteTime(file.FileName).Date;
                    objFileMeta.CreateDatetime = File.GetCreationTime(file.FileName);
                    objFileMeta.LastWriteTime = File.GetLastWriteTime(file.FileName);

                    ParseFieldList.ForEach(field => field.LastValid = null);

                    fileLine = 0;
                    if (fileDate_Create)
                    {
                        index = index.Replace("@" + objLocalConfig.OItem_object_filedate_create.Name.ToLower() + "@",
                            File.GetCreationTime(file.FileName).ToString("yyyyMMdd"));

                    }
                    if (fileDate_LastChange)
                    {
                        index = index.Replace(
                            "@" + objLocalConfig.OItem_object_filedate_lastchange.Name.ToLower() + "@",
                            File.GetLastWriteTime(file.FileName).ToString("yyyyMMdd"));
                    }

                    dictList = new List<clsAppDocuments>();
                    //try
                    //{

                    var stream = new FileStream(file.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    var textReader = new StreamReader(stream);



                    var text = "";
                    UserFields = ParseFieldList.Where(f => f.IsMeta == false).ToList();
                    while (!textReader.EndOfStream)
                    {
                        fileLine++;
                        dictMeta = new Dictionary<string, object>();
                        dictUser = new Dictionary<string, object>();

                        if (OList_Seperator == null ||
                            (OList_Seperator.Any() && OList_Seperator.First().Name == "\\r\\n"))
                        {
                            
                            text = textReader.ReadLine();
                        }
                        else
                        {
                            replaceNewLine = true;
                            text = "";

                            StringBuilder line = new StringBuilder();
                            var length = 1;
                            var tester = "";
                            var finished = false;
                            while (!finished && !textReader.EndOfStream)
                            {
                                length = line.Length;
                                char singleChar = (char) textReader.Read();
                                tester += singleChar;
                                if (OList_Seperator.Any(s => tester.EndsWith(s.Name)))
                                {
                                    text = tester.ToString();
                                    finished = true;
                                }



                            }


                        }


                        objOItem_Result = ParseText(text, replaceNewLine, fileLine);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {

                            if (configurationItem_OneRecordByFile == null)
                            {
                                if (docCount > 0 && docCount%objLocalConfig.Globals.SearchRange == 0)
                                {

                                    var count = dictList.Count;

                                    objOItem_Result = objAppDBLevel.Save_Documents(dictList,
                                        objOItem_Type != null
                                            ? objOItem_Type.Name
                                            : objOItem_Type != null ? objOItem_Type.Name : "Doc", index.ToLower());
                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        savedDocumentCount += count;
                                        if (parsedLines != null)
                                        {
                                            parsedLines(parsedDocumentCount, savedDocumentCount);
                                        }


                                    }
                                    else
                                    {
                                        OItem_Result = objOItem_Result;
                                    }
                                    dictList.Clear();
                                }
                            }
                         
                            parsedDocumentCount++;
                        }
                        else
                        {
                            OItem_Result = objOItem_Result;
                        }


                    }



                    if (dictList.Count > 0)
                    {
                        if (configurationItem_OneRecordByFile != null)
                        { 
                            var firstItem = dictList.First();
                            for (var i = 1; i < dictList.Count; i++)
                            {
                                var keys1 = dictList[i].Dict.Keys;
                                var keys2 = firstItem.Dict.Keys;

                                var allKeys = keys1.Union(keys2);

                                allKeys.ToList().ForEach(key =>
                                {
                                    if (firstItem.Dict.ContainsKey(key))
                                    {
                                        if (dictList[i].Dict.ContainsKey(key))
                                        {
                                            if (firstItem.Dict[key] is string)
                                            {
                                                string strVal = firstItem.Dict[key].ToString() ?? "";
                                                strVal += dictList[i].Dict[key].ToString() ?? "";
                                                firstItem.Dict[key] = strVal;
                                            }
                                            else if (firstItem.Dict[key] is double)
                                            {
                                                double dblVal = (double)firstItem.Dict[key];
                                                dblVal += (double)dictList[i].Dict[key];
                                                firstItem.Dict[key] = dblVal;

                                            }
                                            else if (firstItem.Dict[key] is long)
                                            {
                                                long lngVal = (long)firstItem.Dict[key];
                                                lngVal += (long)dictList[i].Dict[key];
                                                firstItem.Dict[key] = lngVal;
                                            }
                                            else if (firstItem.Dict[key] is DateTime)
                                            {
                                                firstItem.Dict[key] = dictList[i].Dict[key];
                                            }
                                            else if (firstItem.Dict[key] is bool)
                                            {
                                                firstItem.Dict[key] = dictList[i].Dict[key];
                                            }
                                        }
                                    }
                                    else
                                    {
                                        firstItem.Dict.Add(key, dictList[i].Dict[key]);
                                    }
                                });
                                
                            }
                            dictList = new List<clsAppDocuments> { firstItem };
                        }
                       
                        var count = dictList.Count;
                        objOItem_Result = objAppDBLevel.Save_Documents(dictList,
                            objOItem_Type != null
                                ? objOItem_Type.Name
                                : objOItem_Type != null ? objOItem_Type.Name : "Doc", index);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            if (parsedLines != null)
                            {
                                parsedLines(parsedDocumentCount, savedDocumentCount);
                            }
                            savedDocumentCount += count;
                        }
                        else
                        {
                            OItem_Result = objOItem_Result;
                        }
                    }
                    textReader.Close();
                    stream.Close();
                    //}
                    //catch (Exception ex)
                    //{

                    //    return objLocalConfig.Globals.LState_Error.Clone();
                    //}



                }
                if (finishedParsing != null)
                {
                    finishedParsing();
                }
            }
            else
            {
                objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                objOItem_Result.Additional1 = "Die Liste enthält keine Dateien!";
            }
            

            OItem_Result = objOItem_Result;
            if (finishedParsing != null)
            {
                finishedParsing();
            }
        }

        public clsOntologyItem ParseText(string text, bool replaceNewLine, long fileLine = 0)
        {
            var add = false;
            var dontAddUser = false;
            var textParse = text;
            var Id = objLocalConfig.Globals.NewGUID;
            var ixStart = 0;
            var ixStartLast = 0;
            var fieldNotFound = false;
            var textParseBase = text;
            var addMessageRest = false;

            addMessageRest = false;
            foreach (var field in ParseFieldList.OrderBy(p => p.IsMeta).ThenBy(p => p.OrderId).ToList())
            {
                field.LastContent = "";
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
                        dictMeta.Add(field.Name_MetaField, objFileMeta != null ?  objFileMeta.FilePath : "");
                    }
                    else if (field.ID_MetaField == objLocalConfig.OItem_object_filename.GUID)
                    {
                        dictMeta.Add(field.Name_Field, objFileMeta != null ? objFileMeta.FileName : "");
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
                        dictMeta.Add(field.Name_Field, objFileMeta != null ? objFileMeta.CreateDate : DateTime.Now.Date);
                    }
                    else if (field.ID_MetaField == objLocalConfig.OItem_object_filedate__last_change_.GUID)
                    {
                        dictMeta.Add(field.Name_Field, objFileMeta != null ? objFileMeta.LastWriteDate : DateTime.Now.Date);
                    }
                    else if (field.ID_MetaField == objLocalConfig.OItem_object_filedatetime__create_.GUID)
                    {
                        dictMeta.Add(field.Name_Field, objFileMeta != null ? objFileMeta.CreateDatetime : DateTime.Now);
                    }
                    else if (field.ID_MetaField ==
                             objLocalConfig.OItem_object_filedatetime__last_change_.GUID)
                    {
                        dictMeta.Add(field.Name_Field, objFileMeta != null ? objFileMeta.LastWriteTime : DateTime.Now);
                    }
                    else if (field.ID_MetaField == objLocalConfig.OItem_object_fileline.GUID)
                    {
                        dictMeta.Add(field.Name_Field, fileLine);
                    }
                    else if (field.ID_MetaField == objLocalConfig.OItem_object_messagerest.GUID)
                    {
                        addMessageRest = true;
                    }
                }
                else if (field.IsInsert)
                {
                    dictUser.Add(field.Name_Field, field.Insert);
                }
                else
                {

                    string regexPre = field.ID_RegExPre != null &&
                                   field.ID_RegExPre != objLocalConfig.OItem_object_empty.GUID
                                   ? field.RegexPre : null;
                    string regexPost = field.ID_RegExPost != null &&
                                       field.ID_RegExPost != objLocalConfig.OItem_object_empty.GUID
                        ? field.RegexPost
                        : null;

                    string regexMain = field.ID_RegExMain != null &&
                                       field.ID_RegExMain != objLocalConfig.OItem_object_empty.GUID
                                       ? field.Regex : null;


                    if (!string.IsNullOrEmpty(field.ID_ReferenceField))
                    {
                        var contentFields = ParseFieldList.Where(fieldSource => fieldSource.ID_Field == field.ID_ReferenceField).ToList();
                        if (contentFields.Any())
                        {
                            textParse = contentFields.First().LastContent;
                        }
                    }

                    if (field.FieldListContained != null && field.FieldListContained.Any())
                    {
                        (from objField in ParseFieldList
                         join objContainedList in field.FieldListContained on objField.ID_Field equals objContainedList.ID_Field
                         select new {objField, objContainedList }).ToList().ForEach(fieldChange =>
                         {
                             fieldChange.objContainedList.LastContent = fieldChange.objField.LastContent;
                         });
                    }
                    
                    parseResult.ResultText = textParse;
                    parseResult.Parse(regexPre, regexMain, regexPost, replaceNewLine, field.DoAll, field.ReplaceList, field.FieldListContained);
                    textParse = parseResult.ResultText;

                    if (parseResult.ParseOk)
                    {
                        field.LastContent = textParse;
                        if (field.UseLastValid)
                        {
                            field.LastValid = textParse;
                        }
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
                                dictUser.Add(field.Name_Field, !string.IsNullOrEmpty(textParse));
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
                                parseResult.ParseOk = false;
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
                                parseResult.ParseOk = false;
                            }
                        }
                        else if (field.ID_DataType == objLocalConfig.OItem_object_double.GUID)
                        {
                            textParse = textParse.Replace(numberSeperatorReplace, numberSeperator);
                            double value;
                            if (double.TryParse(textParse, out value))
                            {
                                dictUser.Add(field.Name_Field, value);
                            }
                            else
                            {
                                parseResult.ParseOk = false;
                            }
                        }
                    }
                    else if (field.UseLastValid && !string.IsNullOrEmpty(field.LastValid))
                    {
                        dictUser.Add(field.Name_Field, field.LastValid);
                    }


                    if (!parseResult.ParseOk)
                    {
                        field.LastContent = "";
                        dontAddUser = true;
                    }
                    else
                    {
                        if (field.RemoveFromSource)
                        {
                            ixStart = ixStartLast + (parseResult.IxEndPre > -1 ? parseResult.IxEndPre : 0) + parseResult.IxStartMain + parseResult.LengthMain;
                            if (text.Length > ixStart)
                                textParseBase = text.Substring(ixStart);
                            else
                                textParseBase = text;

                            if (text.Length - 1 > ixStart)
                                textParse = text.Substring(ixStart);
                            else
                                textParse = text;
                            ixStartLast = ixStart;
                        }
                        else
                        {
                            textParse = textParseBase;
                        }    
                    }
                    
                }



            }

            if (addMessageRest)
            {
                dictMeta.Add(objLocalConfig.OItem_object_messagerest.Name, textParse);
            }
            if (dictMeta.Any() || (!UserFields.Any() || dictUser.Any()))
            {
                //if (dontAddUser) dictUser.Clear();
                if (oItem_SourceField != null)
                {
                    dictUser.Add("GUID_Field_Parent", oItem_SourceField.GUID);
                    dictUser.Add("Name_Field_Parent", oItem_SourceField.Name);
                }
                dictUser = dictUser.Union(dictMeta).ToDictionary(pair => pair.Key, pair => pair.Value);
                var objDoc = new clsAppDocuments { Id = Id, Dict = dictUser };
                dictList.Add(objDoc);
                docCount = docCount + 1;
                
            }

            return objLocalConfig.Globals.LState_Success.Clone();
        }

    }
}
