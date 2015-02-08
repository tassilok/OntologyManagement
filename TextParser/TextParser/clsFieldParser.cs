using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Text.RegularExpressions;

namespace TextParser
{
    public class clsFieldParser
    {
        private clsLocalConfig objLocalConfig;

        private clsDataWork_FieldParser objDataWork_FieldParser;

        private clsOntologyItem objOItem_FieldParser;

        private List<clsField> ParseFieldList;

        private List<clsOntologyItem> objOList_Variables;

        public List<string> FoundFields { get; private set; }

        public clsFieldParser(clsGlobals Globals)
        {
            objLocalConfig = new clsLocalConfig(Globals);

            Initialize();
        }

        private void Initialize()
        {
            objDataWork_FieldParser = new clsDataWork_FieldParser(objLocalConfig);
        }

        public clsOntologyItem Initialize_FieldParser(clsOntologyItem OItem_FieldParser)
        {
            objOItem_FieldParser = OItem_FieldParser;

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();


            objOItem_Result = objDataWork_FieldParser.GetData_FieldsOfFieldParser(OItem_FieldParser);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                ParseFieldList = objDataWork_FieldParser.FieldList;

            }

            return objOItem_Result;
        }

        public string ParseLine(string text, List<clsOntologyItem> OList_Variables)
        {
            var newText = "";

            FoundFields = new List<string>();

            objOList_Variables = OList_Variables;

            foreach (var field in ParseFieldList.Where(p => p.IsInsert).OrderBy(p => p.IsMeta).ThenBy(p => p.OrderId).ToList())
            {
                var getIxStart = true;
                var ixStart_Post = 0;
                var ixEnd_Pre = 0;
                var ixStart_Main = 0;
                var length_Main = 0;
                var parse = false;
                field.LastContent = "";

                var textParse = text;
                if (!string.IsNullOrEmpty(field.ID_ReferenceField))
                {
                    var contentFields = ParseFieldList.Where(fieldRef => fieldRef.ID_Field == field.ID_ReferenceField).ToList();
                    if (contentFields.Any())
                    {
                        textParse = contentFields.First().LastContent;
                    }
                }
                // Regex-Pre
                if (field.ID_RegExPre != null &&
                    field.ID_RegExPre != objLocalConfig.OItem_object_empty.GUID)
                {
                    var objRegExPre = new Regex(field.RegexPre);

                    // Regex im Text suchen
                    var objMatches = objRegExPre.Matches(text);
                    if (objMatches.Count > 0 && objMatches[0].Length > 0)
                    {

                        textParse =
                            textParse.Substring(objMatches[0].Index +
                                                objMatches[0].Length);
                        ixEnd_Pre = objMatches[0].Index + objMatches[0].Length;
                        //ixStart = ixStart + objMatches[0].Index +
                        //            objMatches[0].Length-1;

                        parse = true;
                    }
                    else if (objMatches.Count > 0 && objMatches[0].Length == 0)
                    {
                        ixEnd_Pre = objMatches[0].Index + objMatches[0].Length;
                        parse = true;
                    }
                    else
                    {

                        parse = false;
                    }
                }
                else
                {
                    ixEnd_Pre = -1;
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
                            ixStart_Post = objMatches[0].Index;
                            //ixStart += objMatches[0].Index + objMatches[0].Length-1;
                            getIxStart = false;
                        }
                        else if (objMatches.Count > 0 && objMatches[0].Length == 0)
                        {
                            ixStart_Post = objMatches[0].Index;
                        }
                        else
                        {

                            parse = false;
                        }
                    }
                    else
                    {
                        ixStart_Post = -1;
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

                        if (objMatches.Count > 0 && objMatches[0].Length > 0)
                        {
                            textParse = textParse.Substring(objMatches[0].Index,
                                                            objMatches[0].Length);

                            ixStart_Main = objMatches[0].Index;
                            length_Main = objMatches[0].Length;
                            if (getIxStart)
                            {

                                //ixStart += objMatches[0].Index + objMatches[0].Length - 1;
                            }


                        }
                        else if (objMatches.Count > 0 && objMatches[0].Length == 0)
                        {
                            ixStart_Main = objMatches[0].Index;
                            length_Main = 0;
                        }
                        else
                        {

                            parse = false;
                        }
                    }
                    else
                    {
                        ixStart_Main = -1;
                    }
                }
                
                if (parse || (field.UseLastValid && !string.IsNullOrEmpty(field.LastValid)))
                {
                    string fieldToAdd = "";
                    if (parse)
                    {
                        
                        fieldToAdd = text.Substring(ixEnd_Pre, length_Main);
                        field.LastContent = fieldToAdd;
                        if (field.UseLastValid)
                        {
                            field.LastValid = fieldToAdd;
                        }
                    }
                    else
                    {
                        field.LastContent = "";
                        if (field.UseLastValid)
                        {
                            fieldToAdd = field.LastValid;
                        }
                    }
                    
                    
                    FoundFields.Add(fieldToAdd);
                    var variableList = objOList_Variables != null ? objOList_Variables.Where(v => v.Name == field.Insert).ToList() : null;

                    if (variableList != null && variableList.Any())
                    {
                        var textReplaced = text.Substring(0, ixEnd_Pre);
                        textReplaced += objOList_Variables.First().Additional1;
                        textReplaced += text.Substring(ixEnd_Pre + length_Main);
                        newText = textReplaced;
                    }
                    else
                    {
                        newText = text;
                    }

                }
                else
                {
                    newText = text;
                }
            }

            return newText;
        }
    }
}
