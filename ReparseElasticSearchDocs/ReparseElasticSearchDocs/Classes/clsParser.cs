using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ReparseElasticSearchDocs.Classes
{
    class clsParser
    {

        private clsLocalConfig objLocalConfig;

        public clsParser(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
        }

        public string Replace(string strFieldValue, string strField)
        {
            Regex objRegEx;
            MatchCollection objMatchCol;

            var objLReplace = from obj in objLocalConfig.Replaces
                              where obj.Field == strField
                              select obj;

            foreach (var objReplace in objLReplace)
            {
                objRegEx = new Regex(objReplace.Regex);

                objMatchCol = objRegEx.Matches(strFieldValue);

                foreach (Match objMatch in objMatchCol)
                {
                    if (objMatch.Index > 0)
                    {
                        strFieldValue = strFieldValue.Substring(0, objMatch.Index) + objReplace.Replace + strFieldValue.Substring(objMatch.Index + objMatch.Length);
                    }
                    else
                    {
                        strFieldValue = objReplace.Replace + strFieldValue.Substring(objMatch.Index + objMatch.Length);
                    }

                }

            }
            return strFieldValue;
        }

        public Dictionary<string, object> parse_Line(string strLine)
        {
            int intIndex;
            int intLength;
            Dictionary<string, object> objDict_Dst = new Dictionary<string, object> { };
            clsDataTypes objDataType = new clsDataTypes();
            Regex objRegEx = null;
            Regex objRegEx_Pre = null;
            Regex objRegEx_Post = null;
            Regex objRegEx_Mutate = null;
            Match objMatch = null;
            Boolean boolParse;
            int intPosRemove_Parse;
            int intPosRemove_Line;

            Boolean boolVal;
            DateTime dateVal;
            long lngVal;
            double dblVal;
            string strVal;

            intPosRemove_Parse = 0;


            var objLGroups = from obj in objLocalConfig.Fields
                             orderby obj.GroupID
                             group obj by obj.GroupID into g
                             select new { GroupID = g.Key };

            foreach (var objGroup in objLGroups)
            {
                string strLineTmp = strLine;


                var objLFields = from obj in objLocalConfig.Fields
                                 orderby obj.OrderID
                                 where obj.GroupID == objGroup.GroupID
                                 select obj;
                intPosRemove_Line = 0;
                foreach (var objField in objLFields)
                {
                    boolParse = true;
                    if (objField.RegexPre != "")
                    {
                        objRegEx_Pre = new Regex(objField.RegexPre);
                        objMatch = objRegEx_Pre.Match(strLineTmp);
                        intIndex = objMatch.Index;
                        intLength = objMatch.Length;
                        if (intLength == 0)
                        {
                            boolParse = false;
                        }
                        else
                        {
                            intPosRemove_Parse = intIndex + intLength;
                            strLineTmp = strLineTmp.Substring(intIndex + intLength);
                        }
                    }

                    if (boolParse == true)
                    {
                        if (objField.RegexPost != "")
                        {
                            objRegEx_Post = new Regex(objField.RegexPost);
                            objMatch = objRegEx_Post.Match(strLineTmp);
                            intIndex = objMatch.Index;
                            intLength = objMatch.Length;

                            if (intLength == 0)
                            {
                                boolParse = false;
                            }
                            else
                            {
                                strLineTmp = strLineTmp.Substring(0, intIndex + intLength);
                            }
                        }
                    }

                    if (boolParse == true)
                    {
                        if (objField.Regex != "")
                        {
                            objRegEx = new Regex(objField.Regex);
                            objMatch = objRegEx.Match(strLineTmp);

                            intIndex = objMatch.Index;
                            intLength = objMatch.Length;

                            if (intLength == 0)
                            {
                                boolParse = false;
                            }
                            else
                            {
                                intPosRemove_Parse = intPosRemove_Parse + intIndex + intLength;
                                strLineTmp = strLineTmp.Substring(intIndex, intLength);
                                if (strLineTmp == "")
                                {
                                    boolParse = false;
                                }
                            }
                        }
                    }

                    if (boolParse == true)
                    {
                        strLineTmp = Replace(strLineTmp, objField.Field);

                        var objLMutate = from obj in objLocalConfig.Mutates
                                         where obj.Field == objField.Field
                                         select new
                                         {
                                             DataType = obj.DataType
                                           ,
                                             Exist = obj.Exist
                                           ,
                                             Field = obj.Field
                                         };


                        if (objLMutate.Count() > 0)
                        {
                            foreach (var objMutate in objLMutate)
                            {
                                if (objMutate.Exist == true)
                                {
                                    objDict_Dst.Add(objField.Field, true);
                                }

                                break;
                            }
                        }
                        else
                        {
                            if (objField.DataType == objDataType.DType_Bool)
                            {
                                if (Boolean.TryParse(strLineTmp, out boolVal))
                                    objDict_Dst.Add(objField.Field, boolVal);
                            }
                            else if (objField.DataType == objDataType.DType_Datetime)
                            {
                                if (DateTime.TryParse(strLineTmp, out dateVal))
                                    objDict_Dst.Add(objField.Field, dateVal);
                            }
                            else if (objField.DataType == objDataType.DType_Double)
                            {
                                if (double.TryParse(strLineTmp, out dblVal))
                                    objDict_Dst.Add(objField.Field, dblVal);
                            }
                            else if (objField.DataType == objDataType.DType_Long)
                            {
                                if (long.TryParse(strLineTmp, out lngVal))
                                    objDict_Dst.Add(objField.Field, lngVal);
                            }
                            else if (objField.DataType == objDataType.DType_String)
                            {

                                objDict_Dst.Add(objField.Field, strLineTmp);
                            }
                        }


                        intPosRemove_Line += intPosRemove_Parse;


                    }



                    if (objField.Remove == true)
                    {
                        strLineTmp = strLine.Substring(intPosRemove_Line);

                    }
                    else
                    {
                        strLineTmp = strLine;
                    }
                    intPosRemove_Parse = 0;
                }

                var objLConcate = from objField1 in objDict_Dst
                                  join objConcate in objLocalConfig.Concates on objField1.Key equals objConcate.FieldSrc1
                                  join objField2 in objDict_Dst on objConcate.FieldSrc2 equals objField2.Key
                                  select new { objField1, objConcate, objField2 };

                foreach (var objConcate in objLConcate)
                {
                    strVal = objConcate.objField1.Value + objConcate.objConcate.Seperator + objConcate.objField2.Value;

                    if (objConcate.objConcate.DataType == objDataType.DType_Bool)
                    {
                        if (Boolean.TryParse(strVal, out boolVal))
                            objDict_Dst.Add(objConcate.objConcate.Field, boolVal);
                    }
                    else if (objConcate.objConcate.DataType == objDataType.DType_Datetime)
                    {
                        if (DateTime.TryParse(strVal, out dateVal))
                            objDict_Dst.Add(objConcate.objConcate.Field, dateVal);
                    }
                    else if (objConcate.objConcate.DataType == objDataType.DType_Double)
                    {
                        if (double.TryParse(strVal, out dblVal))
                            objDict_Dst.Add(objConcate.objConcate.Field, dblVal);
                    }
                    else if (objConcate.objConcate.DataType == objDataType.DType_Long)
                    {
                        if (long.TryParse(strVal, out lngVal))
                            objDict_Dst.Add(objConcate.objConcate.Field, lngVal);
                    }
                    else if (objConcate.objConcate.DataType == objDataType.DType_String)
                    {

                        objDict_Dst.Add(objConcate.objConcate.Field, strLineTmp);
                    }



                    break;
                }
            }

            return objDict_Dst;
        }

        public string DictToJson(Dictionary<string, object> objDict)
        {
            string strJson;

            var entries = objDict.Select(d =>
                string.Format("\"{0}\": [{1}]", d.Key, string.Join(",", d.Value)));
            strJson = "{" + string.Join(",", entries) + "}";
            return strJson;
        }
    }
}
