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

        private int intStart_THR2;
        private int intStart_THR3;
        private int intStart_THR4;
        private int intStart_THR5;

        private Thread objThread1;
        private Thread objThread2;
        private Thread objThread3;
        private Thread objThread4;
        private Thread objThread5;

        private ElasticSearchClient objElConnSrc1;
        private ElasticSearchClient objElConnDst1;
        private ElasticSearchClient objElConnSrc2;
        private ElasticSearchClient objElConnDst2;
        private ElasticSearchClient objElConnSrc3;
        private ElasticSearchClient objElConnDst3;
        private ElasticSearchClient objElConnSrc4;
        private ElasticSearchClient objElConnDst4;
        private ElasticSearchClient objElConnSrc5;
        private ElasticSearchClient objElConnDst5;

        public clsReparse(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            intStart_THR2 = 1 + objLocalConfig.BaseConfig.PackageLength;
            intStart_THR3 = intStart_THR2 + objLocalConfig.BaseConfig.PackageLength;
            intStart_THR4 = intStart_THR3 + objLocalConfig.BaseConfig.PackageLength;
            intStart_THR5 = intStart_THR4 + objLocalConfig.BaseConfig.PackageLength;
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
            objElConnSrc1 = new ElasticSearchClient(objLocalConfig.BaseConfig.ServerSrc, objLocalConfig.BaseConfig.PortSrc, TransportType.Thrift, false);
            objElConnDst1 = new ElasticSearchClient(objLocalConfig.BaseConfig.ServerDst, objLocalConfig.BaseConfig.PortDst, TransportType.Thrift, false);
            objElConnSrc2 = new ElasticSearchClient(objLocalConfig.BaseConfig.ServerSrc, objLocalConfig.BaseConfig.PortSrc, TransportType.Thrift, false);
            objElConnDst2 = new ElasticSearchClient(objLocalConfig.BaseConfig.ServerDst, objLocalConfig.BaseConfig.PortDst, TransportType.Thrift, false);
            objElConnSrc3 = new ElasticSearchClient(objLocalConfig.BaseConfig.ServerSrc, objLocalConfig.BaseConfig.PortSrc, TransportType.Thrift, false);
            objElConnDst3 = new ElasticSearchClient(objLocalConfig.BaseConfig.ServerDst, objLocalConfig.BaseConfig.PortDst, TransportType.Thrift, false);
            objElConnSrc4 = new ElasticSearchClient(objLocalConfig.BaseConfig.ServerSrc, objLocalConfig.BaseConfig.PortSrc, TransportType.Thrift, false);
            objElConnDst4 = new ElasticSearchClient(objLocalConfig.BaseConfig.ServerDst, objLocalConfig.BaseConfig.PortDst, TransportType.Thrift, false);
            objElConnSrc5 = new ElasticSearchClient(objLocalConfig.BaseConfig.ServerSrc, objLocalConfig.BaseConfig.PortSrc, TransportType.Thrift, false);
            objElConnDst5 = new ElasticSearchClient(objLocalConfig.BaseConfig.ServerDst, objLocalConfig.BaseConfig.PortDst, TransportType.Thrift, false);

            while (true)
            {


                
                objThread1 = null;
                objThread2 = null;
                objThread3 = null;
                objThread4 = null;
                objThread5 = null;

                objThread1 = new Thread(new ThreadStart(reparse_T1));
                objThread2 = new Thread(new ThreadStart(reparse_T2));
                objThread3 = new Thread(new ThreadStart(reparse_T3));
                objThread4 = new Thread(new ThreadStart(reparse_T4));
                objThread5 = new Thread(new ThreadStart(reparse_T5));
                objThread1.Start();
                if (objLocalConfig.BaseConfig.ThreadCount > 1)
                {
                   
                    objThread2.Start();
                }
                if (objLocalConfig.BaseConfig.ThreadCount > 2)
                {
                    
                    objThread3.Start();
                }
                if (objLocalConfig.BaseConfig.ThreadCount > 3)
                {
                    
                    objThread4.Start();
                }
                if (objLocalConfig.BaseConfig.ThreadCount > 4)
                {
                    
                    objThread5.Start();
                }
                
                while ((objThread1.ThreadState != ThreadState.Unstarted && objThread1.ThreadState != ThreadState.Stopped)
                    || (objThread2.ThreadState != ThreadState.Unstarted && objThread2.ThreadState != ThreadState.Stopped)
                    || (objThread3.ThreadState != ThreadState.Unstarted && objThread3.ThreadState != ThreadState.Stopped)
                    || (objThread4.ThreadState != ThreadState.Unstarted && objThread4.ThreadState != ThreadState.Stopped)
                    || (objThread5.ThreadState != ThreadState.Unstarted && objThread5.ThreadState != ThreadState.Stopped))
                {

                }

                if (objLocalConfig.BaseConfig.ExternalRun == true)
                {
                    break;
                }
            }
            
        }

        public void reparse_T1()
        {
            reparse(0, objLocalConfig.BaseConfig.PackageLength,1);
        }

        public void reparse_T2()
        {
            reparse(intStart_THR2, objLocalConfig.BaseConfig.PackageLength, 2);
        }

        public void reparse_T3()
        {
            reparse(intStart_THR3, objLocalConfig.BaseConfig.PackageLength, 3);
        }

        public void reparse_T4()
        {
            reparse(intStart_THR4, objLocalConfig.BaseConfig.PackageLength, 4);
        }

        public void reparse_T5()
        {
            reparse(intStart_THR5, objLocalConfig.BaseConfig.PackageLength, 5);
        }

        public void reparse(int intStart, int intLength, int idThread, Boolean boolFlush = false)
        {
            Dictionary<string, object> objDict_Src = new Dictionary<string, object> { };
            Dictionary<string, object> objDict_Dst = new Dictionary<string, object> { };
            List<BulkObject> objBulkObjects_Src = new List<BulkObject> { };
            List<BulkObject> objBulkObjects_Dst = new List<BulkObject> { };

            

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
                
                
                string strID;

                switch (idThread)
                {
                    case 1:
                        objSearchResult = objElConnSrc1.Search(objLocalConfig.BaseConfig.IndexSrc, objLocalConfig.BaseConfig.Type, objBoolQuery.ToString(), strOrder, intStart, intLength);
                        break;

                    case 2:
                        objSearchResult = objElConnSrc2.Search(objLocalConfig.BaseConfig.IndexSrc, objLocalConfig.BaseConfig.Type, objBoolQuery.ToString(), strOrder, intStart, intLength);
                        break;

                    case 3:
                        objSearchResult = objElConnSrc3.Search(objLocalConfig.BaseConfig.IndexSrc, objLocalConfig.BaseConfig.Type, objBoolQuery.ToString(), strOrder, intStart, intLength);
                        break;

                    case 4:
                        objSearchResult = objElConnSrc4.Search(objLocalConfig.BaseConfig.IndexSrc, objLocalConfig.BaseConfig.Type, objBoolQuery.ToString(), strOrder, intStart, intLength);
                        break;
                    default:
                        objSearchResult = objElConnSrc1.Search(objLocalConfig.BaseConfig.IndexSrc, objLocalConfig.BaseConfig.Type, objBoolQuery.ToString(), strOrder, intStart, intLength);
                        break;
                }
                
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
                switch (idThread)
                {
                    case 1:
                        objElConnDst1.Bulk(objBulkObjects_Dst);
                        objElConnDst1.Refresh(objLocalConfig.BaseConfig.IndexDst);
                        objElConnSrc1.Bulk(objBulkObjects_Src);
                        objElConnSrc1.Refresh(objLocalConfig.BaseConfig.IndexSrc);
                        if (boolFlush == true)
                        {
                            objElConnDst1.Flush(objLocalConfig.BaseConfig.IndexDst);
                            objElConnSrc1.Flush(objLocalConfig.BaseConfig.IndexSrc);
                        }
                        break;
                    case 2:
                        objElConnDst2.Bulk(objBulkObjects_Dst);
                        objElConnDst2.Refresh(objLocalConfig.BaseConfig.IndexDst);
                        objElConnSrc2.Bulk(objBulkObjects_Src);
                        objElConnSrc2.Refresh(objLocalConfig.BaseConfig.IndexSrc);
                        if (boolFlush == true)
                        {
                            objElConnDst2.Flush(objLocalConfig.BaseConfig.IndexDst);
                            objElConnSrc2.Flush(objLocalConfig.BaseConfig.IndexSrc);
                        }
                        break;
                    case 3:
                        objElConnDst3.Bulk(objBulkObjects_Dst);
                        objElConnDst3.Refresh(objLocalConfig.BaseConfig.IndexDst);
                        objElConnSrc3.Bulk(objBulkObjects_Src);
                        objElConnSrc3.Refresh(objLocalConfig.BaseConfig.IndexSrc);
                        if (boolFlush == true)
                        {
                            objElConnDst3.Flush(objLocalConfig.BaseConfig.IndexDst);
                            objElConnSrc3.Flush(objLocalConfig.BaseConfig.IndexSrc);
                        }
                        break;
                    case 4:
                        objElConnDst4.Bulk(objBulkObjects_Dst);
                        objElConnDst4.Refresh(objLocalConfig.BaseConfig.IndexDst);
                        objElConnSrc4.Bulk(objBulkObjects_Src);
                        objElConnSrc4.Refresh(objLocalConfig.BaseConfig.IndexSrc);
                        if (boolFlush == true)
                        {
                            objElConnDst4.Flush(objLocalConfig.BaseConfig.IndexDst);
                            objElConnSrc4.Flush(objLocalConfig.BaseConfig.IndexSrc);
                        }
                        break;
                    case 5:
                        objElConnDst5.Bulk(objBulkObjects_Dst);
                        objElConnDst5.Refresh(objLocalConfig.BaseConfig.IndexDst);
                        objElConnSrc5.Bulk(objBulkObjects_Src);
                        objElConnSrc5.Refresh(objLocalConfig.BaseConfig.IndexSrc);
                        if (boolFlush == true)
                        {
                            objElConnDst5.Flush(objLocalConfig.BaseConfig.IndexDst);
                            objElConnSrc5.Flush(objLocalConfig.BaseConfig.IndexSrc);
                        }
                        break;
                }
                

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

