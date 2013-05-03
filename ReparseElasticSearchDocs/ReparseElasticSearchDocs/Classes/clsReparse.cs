using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using ElasticSearch;
using ElasticSearch.Client;
using ElasticSearch.Client.Config;
using ElasticSearch.Client.Domain;
using Lucene.Net.Search;
using Lucene.Net.Index;
using System.Threading;

namespace ReparseElasticSearchDocs.Classes
{

    class clsReparse
    {
        private clsLocalConfig objLocalConfig;

        private int intPackageLength = 5000;
        private int intPos = 0;

        private Thread objThread1;
        private Thread objThread2;
        private Thread objThread3;
        private Thread objThread4;
        private Thread objThread5;

        public clsReparse(clsLocalConfig LocalConfig)
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

        public void initialize_Reparse()
        {
            while (true)
            {
                objThread1 = new Thread(new ThreadStart(reparse_T1));
                objThread1.Start();
                objThread2 = new Thread(new ThreadStart(reparse_T2));
                objThread2.Start();
                objThread3 = new Thread(new ThreadStart(reparse_T3));
                objThread3.Start();
                objThread4 = new Thread(new ThreadStart(reparse_T4));
                objThread4.Start();
                objThread5 = new Thread(new ThreadStart(reparse_T5));
                objThread5.Start();

                while (objThread1.ThreadState == ThreadState.Running
                       || objThread2.ThreadState == ThreadState.Running
                       || objThread3.ThreadState == ThreadState.Running
                       || objThread4.ThreadState == ThreadState.Running
                       || objThread5.ThreadState == ThreadState.Running)
                {

                }


            }
        }

        public void reparse_T1()
        {
            reparse(0, 5000);
        }

        public void reparse_T2()
        {
            reparse(5001, 10000);
        }

        public void reparse_T3()
        {
            reparse(10001, 15000);
        }

        public void reparse_T4()
        {
            reparse(15001, 20000);
        }

        public void reparse_T5()
        {
            reparse(20001, 25000);
        }

        public void reparse(int intStart, int intLength)
        {
            Dictionary<string, object> objDict_Src = new Dictionary<string, object> { };
            Dictionary<string, object> objDict_Dst = new Dictionary<string, object> { };
            List<BulkObject> objBulkObjects_Src = new List<BulkObject> { };
            List<BulkObject> objBulkObjects_Dst = new List<BulkObject> { };

            ElasticSearchClient objElConnSrc;
            ElasticSearchClient objElConnDst;

            BooleanQuery objBoolQuery = new BooleanQuery();
            SearchResult objSearchResult;
            List<ElasticSearch.Client.Domain.Hits> objHitList = new List<ElasticSearch.Client.Domain.Hits> { };
            string strLine;
            long intCount=0;
            Boolean boolAddVersion;
            string strOrder="";

            objBoolQuery.Add(new TermQuery(new Term(objLocalConfig.Init.VersionField, objLocalConfig.Init.Version.ToString())),BooleanClause.Occur.MUST_NOT);

            foreach(clsOrderField objOrderField in objLocalConfig.Init.OrderFields)
            {
                strOrder += objOrderField.Field;

                if (objOrderField.ASC == true)
                {
                    strOrder += ":asc";
                }
                else
                {
                    strOrder += ":desc";
                }
            }

            try
            {
                objElConnSrc = new ElasticSearchClient(objLocalConfig.BaseConfig.ServerSrc, objLocalConfig.BaseConfig.PortSrc, TransportType.Thrift, false);
                objElConnDst = new ElasticSearchClient(objLocalConfig.BaseConfig.ServerDst, objLocalConfig.BaseConfig.PortDst, TransportType.Thrift, false);
                
                string strID;


                objSearchResult = objElConnSrc.Search(objLocalConfig.BaseConfig.IndexSrc, objLocalConfig.BaseConfig.Type, objBoolQuery.ToString(), strOrder, intStart, intLength);
                objHitList = objSearchResult.GetHits().Hits;
                foreach (ElasticSearch.Client.Domain.Hits objHit in objHitList)
                {

                    strLine = objHit.Source["@message"].ToString();


                    if (strLine != null)
                    {
                        strID = objHit.Id;
                        boolAddVersion = true;
                        objDict_Src = new Dictionary<string, object> { };
                        objDict_Dst = new Dictionary<string, object> { };
                        foreach (var objDictEntry in objHit.Source)
                        {
                            if (objDictEntry.Key == objLocalConfig.Init.VersionField)
                            {
                                objDict_Src.Add(objDictEntry.Key, objLocalConfig.Init.Version);
                                boolAddVersion = false;
                            }
                            else
                            {
                                objDict_Src.Add(objDictEntry.Key, objDictEntry.Value);
                            }
                        }

                        if (boolAddVersion == true)
                        {
                            objDict_Src.Add(objLocalConfig.Init.VersionField, objLocalConfig.Init.Version);
                        }

                        objDict_Dst.Clear();

                        if (objLocalConfig.Meta.LastChange == true)
                        {
                            objDict_Dst.Add("last_change", DateTime.Now);
                        }

                        if (objLocalConfig.Meta.Message == true)
                        {
                            objDict_Dst.Add("message", strLine);
                        }

                        parse_Line(strLine, objDict_Dst);

                        if (objDict_Dst.Count > 0)
                        {
                            objBulkObjects_Dst.Add(new BulkObject(objLocalConfig.BaseConfig.IndexDst, objLocalConfig.BaseConfig.Type, strID, objDict_Dst));
                            objBulkObjects_Src.Add(new BulkObject(objLocalConfig.BaseConfig.IndexSrc, objLocalConfig.BaseConfig.Type, strID, objDict_Src));

                        }

                    }
                }

                
                objElConnDst.Bulk(objBulkObjects_Dst);
                objElConnDst.Refresh(objLocalConfig.BaseConfig.IndexDst);
                objElConnSrc.Bulk(objBulkObjects_Src);
                objElConnSrc.Refresh(objLocalConfig.BaseConfig.IndexSrc);
                objBulkObjects_Dst.Clear();
                objBulkObjects_Src.Clear();

            }
            catch
            {
                
            }

            
            
            
        }

        public void parse_Line(string strLine, Dictionary<string,object> objDict_Dst)
        {
            int intIndex;
            int intLength;
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
                                strLineTmp = strLineTmp.Substring(0,intIndex + intLength);
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
        }
    }
}

