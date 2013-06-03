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
        private const string cstrFormat_ESDateTime1 = "yyyy-MM-ddTHH:mm:ss.000Z";
        private const string cstrFormat_ESDateTime2 = "yyyy-MM-ddTHH:mm:ss.zzzZ";

        private clsLocalConfig objLocalConfig;
        private clsParser objParser;

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

        List<BulkObject> objBulkObjects_Dst1 = new List<BulkObject> { };
        List<BulkObject> objBulkObjects_Dst2 = new List<BulkObject> { };
        List<BulkObject> objBulkObjects_Dst3 = new List<BulkObject> { };
        List<BulkObject> objBulkObjects_Dst4 = new List<BulkObject> { };
        List<BulkObject> objBulkObjects_Dst5 = new List<BulkObject> { };

        private int intPort1;
        private int intPort2;
        private int intPort3;
        private int intPort4;
        private int intPort5;


        private DateTime[] dateARanges;
        private string strIndex_SRC;
        private string strIndex_DST;

        public clsReparse(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            objParser = new clsParser(objLocalConfig);
            intStart_THR2 = 1 + objLocalConfig.BaseConfig.PackageLength;
            intStart_THR3 = intStart_THR2 + objLocalConfig.BaseConfig.PackageLength;
            intStart_THR4 = intStart_THR3 + objLocalConfig.BaseConfig.PackageLength;
            intStart_THR5 = intStart_THR4 + objLocalConfig.BaseConfig.PackageLength;
        }


        public void initialize_Reparse_NET()
        {
            objElConnDst1 = new ElasticSearchClient(objLocalConfig.BaseConfig.ServerDst, objLocalConfig.BaseConfig.PortDst, TransportType.Thrift, false);
            objElConnDst2 = new ElasticSearchClient(objLocalConfig.BaseConfig.ServerDst, objLocalConfig.BaseConfig.PortDst, TransportType.Thrift, false);
            objElConnDst3 = new ElasticSearchClient(objLocalConfig.BaseConfig.ServerDst, objLocalConfig.BaseConfig.PortDst, TransportType.Thrift, false);
            objElConnDst4 = new ElasticSearchClient(objLocalConfig.BaseConfig.ServerDst, objLocalConfig.BaseConfig.PortDst, TransportType.Thrift, false);
            objElConnDst5 = new ElasticSearchClient(objLocalConfig.BaseConfig.ServerDst, objLocalConfig.BaseConfig.PortDst, TransportType.Thrift, false);

            objBulkObjects_Dst1.Clear();
            objBulkObjects_Dst2.Clear();
            objBulkObjects_Dst3.Clear();
            objBulkObjects_Dst4.Clear();
            objBulkObjects_Dst5.Clear();

            intPort1 = objLocalConfig.Network.Ports[0];
            if (objLocalConfig.Network.Ports.Count > 1)
            {
                intPort2 = objLocalConfig.Network.Ports[1];
                if (objLocalConfig.Network.Ports.Count > 2)
                {
                    intPort3 = objLocalConfig.Network.Ports[2];
                    if (objLocalConfig.Network.Ports.Count > 3)
                    {
                        intPort4 = objLocalConfig.Network.Ports[3];
                        if (objLocalConfig.Network.Ports.Count > 4)
                        {
                            intPort5 = objLocalConfig.Network.Ports[4];
                        }
                    }
                }
            }
        }

        public void initialize_Reparse_ES()
        {
            DateTime dateInterval;

            

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

                set_Index();

                if (strIndex_SRC != "")
                {
                    objThread1 = null;
                    objThread2 = null;
                    objThread3 = null;
                    objThread4 = null;
                    objThread5 = null;

                    if (objLocalConfig.Init.doInterval == true)
                    {
                        getRange();
                    }
                    

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

                    if (objLocalConfig.Init.doInterval)
                    {
                        dateInterval = dateARanges[2];
                        for (int i = 2; i <= objLocalConfig.BaseConfig.ThreadCount; i++)
                        {
                            dateInterval = dateInterval.Add(objLocalConfig.Init.Interval);
                        }

                        Dictionary<string, object> objDictMeta = new Dictionary<string, object> { };
                        objDictMeta.Add("Last", dateInterval.ToString(cstrFormat_ESDateTime1));
                        objDictMeta.Add("index",strIndex_DST);
                        objElConnDst1.Index(objLocalConfig.BaseConfig.IndexDst_Meta,
                                            objLocalConfig.BaseConfig.TypeMeta,
                                            objLocalConfig.BaseConfig.ID_LastEntry,
                                            objDictMeta);
                        objElConnDst1.Refresh(objLocalConfig.BaseConfig.IndexDst_Meta);
                    }

                    if (objLocalConfig.BaseConfig.ExternalRun == true)
                    {
                        break;
                    }
                }
                else
                {
                    Thread.Sleep(TimeSpan.FromSeconds(60));
                }
                
            }
            
        }

        public void reparse_T1()
        {
            reparse_ESSRC(0, objLocalConfig.BaseConfig.PackageLength, 1);
        }

        public void reparse_T2()
        {
            reparse_ESSRC(intStart_THR2, objLocalConfig.BaseConfig.PackageLength, 2);
        }

        public void reparse_T3()
        {
            reparse_ESSRC(intStart_THR3, objLocalConfig.BaseConfig.PackageLength, 3);
        }

        public void reparse_T4()
        {
            reparse_ESSRC(intStart_THR4, objLocalConfig.BaseConfig.PackageLength, 4);
        }

        public void reparse_T5()
        {
            reparse_ESSRC(intStart_THR5, objLocalConfig.BaseConfig.PackageLength, 5);
        }

        public void set_Index()
        {
            int intDocCount1;
            int intDocCount2;
            Boolean boolFound = false;
            string strExclude;

            foreach (string strIndex in objElConnSrc1.GetIndices())
            {
                if (strIndex.Contains(objLocalConfig.BaseConfig.IndexSrc))
                {
                    strIndex_SRC = objLocalConfig.BaseConfig.IndexSrc + strIndex.Replace(objLocalConfig.BaseConfig.IndexSrc, "");
                    if (strIndex_SRC == "")
                    {
                        strIndex_SRC = objLocalConfig.BaseConfig.IndexSrc;
                    }

                    strIndex_DST = objLocalConfig.BaseConfig.IndexDst + strIndex.Replace(objLocalConfig.BaseConfig.IndexSrc, "");
                    if (strIndex_DST == "")
                    {
                        strIndex_DST = objLocalConfig.BaseConfig.IndexDst;
                    }

                    intDocCount1 = getDocCount(strIndex_SRC);
                    if (objLocalConfig.Init.doInterval == true)
                    {
                        intDocCount2 = getDocCount(strIndex_DST);
                    }
                    else
                    {
                        intDocCount2 = getVersionedCount(strIndex_SRC);
                    }

                    if (intDocCount2 < intDocCount1)
                    {
                        strExclude = strIndex.Replace(objLocalConfig.BaseConfig.IndexSrc, "").ToLower();
                        var objLExclude = from obj in objLocalConfig.Init.ExcludePostfixes
                                          where obj.ToLower() == strExclude
                                          select obj;

                        if (objLExclude.Count()==0)
                        {
                            
                            boolFound = true;
                            break;
                            
                        }

                        
                        
                    }
                }

            }

            if (boolFound == false)
            {
                strIndex_SRC = "";
                strIndex_DST = "";
            }

        }

        public int getDocCount(string strIndex)
        {
            int intDocCount;
            ElasticSearch.Client.Admin.ClusterIndexStatus objClusterStatus;
            try
            {
                objClusterStatus = objElConnSrc1.Status(strIndex);
                intDocCount = objClusterStatus.IndexStatus[strIndex].DocStatus.NumDocs;
            }
            catch
            {
                intDocCount = 0;
            }
            

            return intDocCount;
        }

        public int getVersionedCount(string strIndex)
        {
            BooleanQuery objBoolQuery = new BooleanQuery();
            SearchResult objSearchResult;
            string strQuery;
            int intDocCount;

            objBoolQuery.Add(new TermQuery(new Term(objLocalConfig.Init.VersionField, objLocalConfig.Init.Version.ToString())), BooleanClause.Occur.MUST_NOT);
            strQuery = objBoolQuery.ToString();

            objSearchResult = objElConnSrc1.Search(strIndex_SRC, objLocalConfig.BaseConfig.Type, strQuery, 0, 1);
            intDocCount = objSearchResult.GetHits().Hits.Count;

            return intDocCount;
        }

        public void reparse_ESSRC(int intStart, int intLength, int idThread, Boolean boolFlush = false)
        {
            Dictionary<string, object> objDict_Src = new Dictionary<string, object> { };
            Dictionary<string, object> objDict_Dst = new Dictionary<string, object> { };
            List<BulkObject> objBulkObjects_Src = new List<BulkObject> { };
            List<BulkObject> objBulkObjects_Dst = new List<BulkObject> { };

            BooleanQuery objBoolQuery = new BooleanQuery();
            SearchResult objSearchResult;
            List<ElasticSearch.Client.Domain.Hits> objHitList = new List<ElasticSearch.Client.Domain.Hits> { };
            string strLine;
            string strQuery;
            DateTime dateStart=DateTime.Now;
            DateTime dateEnd = DateTime.Now;
            DateTime dateInterval = DateTime.Now;

            long intCount=0;
            string strOrder="";

            if (objLocalConfig.Init.doInterval == true)
            {
                intStart = 0;
                
            }

           

            if (objLocalConfig.Init.doInterval)
            {
                dateStart = dateARanges[0];
                dateEnd = dateARanges[1];
                dateInterval = dateARanges[2];

                for (int i = 2; i <= idThread; i++)
                {
                    dateStart = dateStart.Add(objLocalConfig.Init.Interval);
                    dateInterval = dateInterval.Add(objLocalConfig.Init.Interval);
                }
            }
            

            if (objLocalConfig.Init.doInterval == false)
            {
                objBoolQuery.Add(new TermQuery(new Term(objLocalConfig.Init.VersionField, objLocalConfig.Init.Version.ToString())), BooleanClause.Occur.MUST_NOT);
                strQuery = objBoolQuery.ToString();
            }
            else
            {
                
                if (dateInterval > dateEnd)
                {
                    dateInterval = dateEnd;
                }
                //objBoolQuery.Add(new RangeQuery(new Term(objLocalConfig.Init.IntervalField,dateStart.ToString
                if (objLocalConfig.Init.doInterval)
                {
                    RangeQuery objRangeQuery = new RangeQuery(new Term(objLocalConfig.Init.EntryField, dateStart.ToString(cstrFormat_ESDateTime1)),
                                                new Term(objLocalConfig.Init.EntryField, dateInterval.ToString(cstrFormat_ESDateTime1)), true);
                    strQuery = objRangeQuery.ToString();    
                }
                else
                {
                    RangeQuery objRangeQuery = new RangeQuery(new Term(objLocalConfig.Init.EntryField, dateStart.ToString(cstrFormat_ESDateTime1)),
                                                new Term(objLocalConfig.Init.EntryField, dateEnd.ToString(cstrFormat_ESDateTime1)), true);
                    strQuery = objRangeQuery.ToString();
                }
                
            }

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


            if (dateStart < dateEnd)
            {
                try
                {


                    while (true)
                    {
                        

                        switch (idThread)
                        {
                            case 1:
                                objSearchResult = objElConnSrc1.Search(strIndex_SRC, objLocalConfig.BaseConfig.Type, strQuery, strOrder, intStart, intLength);
                                break;

                            case 2:
                                objSearchResult = objElConnSrc2.Search(strIndex_SRC, objLocalConfig.BaseConfig.Type, strQuery, strOrder, intStart, intLength);
                                break;

                            case 3:
                                objSearchResult = objElConnSrc3.Search(strIndex_SRC, objLocalConfig.BaseConfig.Type, strQuery, strOrder, intStart, intLength);
                                break;

                            case 4:
                                objSearchResult = objElConnSrc4.Search(strIndex_SRC, objLocalConfig.BaseConfig.Type, strQuery, strOrder, intStart, intLength);
                                break;

                            case 5:
                                objSearchResult = objElConnSrc5.Search(strIndex_SRC, objLocalConfig.BaseConfig.Type, strQuery, strOrder, intStart, intLength);
                                break;
                            default:
                                objSearchResult = objElConnSrc1.Search(strIndex_SRC, objLocalConfig.BaseConfig.Type, strQuery, strOrder, intStart, intLength);
                                break;
                        }

                        objHitList = objSearchResult.GetHits().Hits;

                        foreach (ElasticSearch.Client.Domain.Hits objHit in objHitList)
                        {

                            strLine = objHit.Source["@message"].ToString();
                            prepareBulkObjects(strLine, objHit.Id, objHit.Source, objBulkObjects_Src, objBulkObjects_Dst);

                            
                        }
                        if (objBulkObjects_Dst.Count > 0)
                        {
                            switch (idThread)
                            {
                                case 1:
                                    bulkToES(objElConnDst1, objBulkObjects_Dst, strIndex_DST, true);

                                    if (objLocalConfig.Init.doInterval == false)
                                    {
                                        bulkToES(objElConnSrc1, objBulkObjects_Src, strIndex_SRC, true);
                                        
                                    }
                                    if (boolFlush == true)
                                    {
                                        objElConnDst1.Flush(strIndex_DST);
                                        if (objLocalConfig.Init.doInterval == false)
                                        {
                                            objElConnSrc1.Flush(strIndex_SRC);
                                        }

                                    }

                                    
                                    break;
                                case 2:
                                    bulkToES(objElConnDst2, objBulkObjects_Dst, strIndex_DST, true);

                                    if (objLocalConfig.Init.doInterval == false)
                                    {
                                        bulkToES(objElConnSrc2, objBulkObjects_Src, strIndex_SRC, true);
                                    }
                                    if (boolFlush == true)
                                    {
                                        objElConnDst2.Flush(strIndex_DST);
                                        if (objLocalConfig.Init.doInterval == false)
                                        {
                                            objElConnSrc2.Flush(strIndex_SRC);
                                        }

                                    }

                                    
                                    break;
                                case 3:
                                    bulkToES(objElConnDst3, objBulkObjects_Dst, strIndex_DST, true);

                                    if (objLocalConfig.Init.doInterval == false)
                                    {
                                        bulkToES(objElConnSrc3, objBulkObjects_Src, strIndex_SRC, true);
                                    }
                                    if (boolFlush == true)
                                    {
                                        objElConnDst3.Flush(strIndex_DST);
                                        if (objLocalConfig.Init.doInterval == false)
                                        {
                                            objElConnSrc3.Flush(strIndex_SRC);
                                        }

                                    }
                                    
                                    break;
                                case 4:
                                    bulkToES(objElConnDst4, objBulkObjects_Dst, strIndex_DST, true);

                                    if (objLocalConfig.Init.doInterval == false)
                                    {
                                        bulkToES(objElConnSrc4, objBulkObjects_Src, strIndex_SRC, true);
                                    }
                                    if (boolFlush == true)
                                    {
                                        objElConnDst4.Flush(strIndex_DST);
                                        if (objLocalConfig.Init.doInterval == false)
                                        {
                                            objElConnSrc4.Flush(strIndex_SRC);
                                        }

                                    }
                                    
                                    break;
                                case 5:
                                    bulkToES(objElConnDst5, objBulkObjects_Dst, strIndex_DST, true);

                                    if (objLocalConfig.Init.doInterval == false)
                                    {
                                        bulkToES(objElConnSrc5, objBulkObjects_Src, strIndex_SRC, true);
                                    }
                                    if (boolFlush == true)
                                    {
                                        objElConnDst5.Flush(strIndex_DST);
                                        if (objLocalConfig.Init.doInterval == false)
                                        {
                                            objElConnSrc5.Flush(strIndex_SRC);
                                        }

                                    }
                                   
                                    break;
                            }
                            objBulkObjects_Dst.Clear();
                            objBulkObjects_Src.Clear();

                        }
                        else
                        {
                            
                            break;
                        }

                        

                        if (objLocalConfig.Init.doInterval == false)
                        {
                            break;
                        }
                        else
                        {
                            intStart += objLocalConfig.BaseConfig.PackageLength;

                        }
                    }


                }
                catch
                {

                }
            }
            

            
            
            
        }

        public void finalize_Net(int intPort)
        {
            if (intPort == intPort1)
            {
                if (objBulkObjects_Dst1.Count > 0)
                {

                    bulkToES(objElConnDst1, objBulkObjects_Dst1, null);
                    objBulkObjects_Dst1.Clear();
                }
            }
            else if (intPort == intPort2)
            {
                
                if (objBulkObjects_Dst2.Count > 0)
                {

                    bulkToES(objElConnDst2, objBulkObjects_Dst2, null);
                    objBulkObjects_Dst2.Clear();
                }
            }
            else if (intPort == intPort3)
            {
                
                if (objBulkObjects_Dst3.Count > 0)
                {

                    bulkToES(objElConnDst3, objBulkObjects_Dst3, null);
                    objBulkObjects_Dst3.Clear();
                }
            }
            else if (intPort == intPort4)
            {
                
                if (objBulkObjects_Dst4.Count >= 0)
                {

                    bulkToES(objElConnDst4, objBulkObjects_Dst4, null);
                    objBulkObjects_Dst4.Clear();
                }
            }
            else if (intPort == intPort5)
            {
                
                if (objBulkObjects_Dst5.Count >= 0)
                {

                    bulkToES(objElConnDst5, objBulkObjects_Dst5, null);
                    objBulkObjects_Dst5.Clear();
                }
            }
        }

        public void reparse_NET(string strLine, int intPort, Boolean boolFlush = false )
        {

            if (intPort == intPort1)
            {
                prepareBulkObjects(strLine, Guid.NewGuid().ToString().Replace("-", ""), null, null, objBulkObjects_Dst1, true);
                if (objBulkObjects_Dst1.Count >= objLocalConfig.BaseConfig.PackageLength)
                {

                    bulkToES(objElConnDst1, objBulkObjects_Dst1, null);
                    objBulkObjects_Dst1.Clear();
                }
            }
            else if (intPort == intPort2)
            {
                prepareBulkObjects(strLine, Guid.NewGuid().ToString().Replace("-", ""), null, null, objBulkObjects_Dst2, true);
                if (objBulkObjects_Dst2.Count >= objLocalConfig.BaseConfig.PackageLength)
                {

                    bulkToES(objElConnDst2, objBulkObjects_Dst2, null);
                    objBulkObjects_Dst2.Clear();
                }
            }
            else if (intPort == intPort3)
            {
                prepareBulkObjects(strLine, Guid.NewGuid().ToString().Replace("-", ""), null, null, objBulkObjects_Dst3, true);
                if (objBulkObjects_Dst3.Count >= objLocalConfig.BaseConfig.PackageLength)
                {

                    bulkToES(objElConnDst3, objBulkObjects_Dst3, null);
                    objBulkObjects_Dst3.Clear();
                }
            }
            else if (intPort == intPort4)
            {
                prepareBulkObjects(strLine, Guid.NewGuid().ToString().Replace("-", ""), null, null, objBulkObjects_Dst4, true);
                if (objBulkObjects_Dst4.Count >= objLocalConfig.BaseConfig.PackageLength)
                {

                    bulkToES(objElConnDst4, objBulkObjects_Dst4, null);
                    objBulkObjects_Dst4.Clear();
                }
            }
            else if (intPort == intPort5)
            {
                prepareBulkObjects(strLine, Guid.NewGuid().ToString().Replace("-", ""), null, null, objBulkObjects_Dst5, true);
                if (objBulkObjects_Dst5.Count >= objLocalConfig.BaseConfig.PackageLength)
                {

                    bulkToES(objElConnDst5, objBulkObjects_Dst5, null);
                    objBulkObjects_Dst5.Clear();
                }
            }

        }

        private string DSTIndex(Dictionary<string, object> objDict)
        {
            string strIndex;
            string strPostfix = "";

            strIndex = objLocalConfig.BaseConfig.IndexDst;

            if (objLocalConfig.Index.Field != "")
            {
                if (objDict.ContainsKey(objLocalConfig.Index.Field.ToLower()))
                {


                    if (objLocalConfig.Index.Format != "")
                    {
                        strPostfix = string.Format("{0:" + objLocalConfig.Index.Format + "}", objDict[objLocalConfig.Index.Field.ToLower()]);

                    }
                    else
                    {
                        strPostfix = objDict[objLocalConfig.Index.Field].ToString();
                    }
                    strPostfix = objLocalConfig.Index.Seperator + strPostfix;
                }
                
            }

            strIndex += strPostfix;

            return strIndex;
        }

        private Boolean prepareBulkObjects(string strLine, string strID, Dictionary<string, object> objDict_Source, List<BulkObject> objBulkObjects_SRC, List<BulkObject> objBulkObjects_DST,Boolean createIndex = false)
        {
            Boolean boolResult = true;
            Boolean boolAddVersion=true;
            string strIndex;
            Dictionary<string, object> objDict_Dst;
            Dictionary<string, object> objDict_Src = new Dictionary<string, object> { };

            objDict_Dst = objParser.parse_Line(strLine);

            if (objDict_Source != null)
            {
                foreach (var objDictEntry in objDict_Source)
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
            }

            


            if (objLocalConfig.Meta.LastChange == true)
            {
                objDict_Dst.Add("last_change", DateTime.Now);
            }

            if (objLocalConfig.Meta.Message == true)
            {
                objDict_Dst.Add("message", strLine);
            }

            if (createIndex == true)
            {
                strIndex = DSTIndex(objDict_Dst);
            }
            else
            {
                strIndex = strIndex_DST;
            }
            

            if (objDict_Dst.Count > 0)
            {

                objBulkObjects_DST.Add(new BulkObject(strIndex, objLocalConfig.BaseConfig.Type, strID, objDict_Dst));
                if (objDict_Source != null)
                {
                    objBulkObjects_SRC.Add(new BulkObject(strIndex_SRC, objLocalConfig.BaseConfig.Type, strID, objDict_Src));
                }
                

            }



            return boolResult;
        }

        private Boolean bulkToES(ElasticSearchClient objElConn, List<BulkObject> objBulkObjects, string Index, Boolean doRefresh = false)
        {
            ElasticSearch.Client.Domain.OperateResult objOPResult;

            objOPResult =  objElConn.Bulk(objBulkObjects);
            if (doRefresh == true)
            {
                objOPResult = objElConn.Refresh(Index);
            }

            return objOPResult.Success;
        }

        private DateTime[] getRange()
        {
            
            SearchResult objSearchResult;
            List<ElasticSearch.Client.Domain.Hits> objHitList = new List<ElasticSearch.Client.Domain.Hits> { };
            dateARanges = new DateTime[3];
            DateTime dateTmp;


            dateARanges[0] = DateTime.Parse("01.01.1900");

            if (objLocalConfig.Init.doFirst == true)
            {
                dateARanges[0] = objLocalConfig.Init.FirstEntry;
                
            }
            else
            {
                
                
                
                try
                {
                    BooleanQuery objBoolQuery = new BooleanQuery();
                    objBoolQuery.Add(new TermQuery(new Term("index", strIndex_DST)), BooleanClause.Occur.MUST);
                    objSearchResult = objElConnDst1.Search(objLocalConfig.BaseConfig.IndexDst_Meta,
                                            objLocalConfig.BaseConfig.TypeMeta,
                                            objBoolQuery.ToString(),
                                            0, 1);

                    objHitList = objSearchResult.GetHits().Hits;

                    if (objHitList.Count > 0)
                    {
                        foreach (ElasticSearch.Client.Domain.Hits objHit in objHitList)
                        {
                            if (DateTime.TryParse(objHit.Source["Last"].ToString(), out dateTmp))
                            {
                                dateARanges[0] = dateTmp;
                            }
                        }
                    }
                    else
                    {
                        BooleanQuery objBoolQuery1 = new BooleanQuery();
                        objBoolQuery1.Add(new TermQuery(new Term(objLocalConfig.Init.EntryField, "*")), BooleanClause.Occur.MUST);
                        objSearchResult = objElConnSrc1.Search(objLocalConfig.BaseConfig.IndexSrc,
                                            objLocalConfig.BaseConfig.Type,
                                            objBoolQuery1.ToString(),
                                            objLocalConfig.Init.EntryField + ":asc",
                                            0, 1);

                        objHitList = objSearchResult.GetHits().Hits;

                        foreach (ElasticSearch.Client.Domain.Hits objHit in objHitList)
                        {
                            if (DateTime.TryParse(objHit.Source[objLocalConfig.Init.EntryField].ToString(), out dateTmp))
                            {
                                dateARanges[0] = dateTmp;
                            }
                        }

                    }
                    
                }
                catch
                {
                    try
                    {
                        BooleanQuery objBoolQuery = new BooleanQuery();
                        objBoolQuery.Add(new TermQuery(new Term(objLocalConfig.Init.EntryField, "*")), BooleanClause.Occur.MUST);
                        objSearchResult = objElConnSrc1.Search(strIndex_SRC,
                                            objLocalConfig.BaseConfig.Type,
                                            objBoolQuery.ToString(),
                                            objLocalConfig.Init.EntryField + ":asc",
                                            0, 1);

                        objHitList = objSearchResult.GetHits().Hits;

                        foreach (ElasticSearch.Client.Domain.Hits objHit in objHitList)
                        {
                            if (DateTime.TryParse(objHit.Source[objLocalConfig.Init.EntryField].ToString(), out dateTmp))
                            {
                                dateARanges[0] = dateTmp;
                            }
                        }
                    }
                    catch
                    {

                    }
                            
                }
                        
                
            }

            if (objLocalConfig.Init.doLast == true)
            {
                dateARanges[1] = objLocalConfig.Init.LastEntry;
            }
            else
            {
                dateARanges[1] = DateTime.Now;   
            }

            if (objLocalConfig.Init.doInterval)
            {
                dateTmp = dateARanges[0].Add(objLocalConfig.Init.Interval);
                dateARanges[2] = dateTmp;
            }



            return dateARanges;
        }

        
    }

    
}

