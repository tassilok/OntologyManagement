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

namespace ReparseElasticSearchDocs.Classes
{

    class clsReparse
    {
        private clsLocalConfig objLocalConfig;
        private ElasticSearchClient objElConn;

        private int intPackageLength = 10000;
        private int intPos = 0;

        public clsReparse(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
        }

        private Boolean initializeClient()
        {
            Boolean boolResult = true;

            try
            {
                objElConn = new ElasticSearchClient(objLocalConfig.BaseConfig.Server, objLocalConfig.BaseConfig.Port, TransportType.Thrift, false);    
            }
            catch
            {
                boolResult = false;
            }

            return boolResult;
        }

        public void reparse()
        {
            BooleanQuery objBoolQuery = new BooleanQuery();
            SearchResult objSearchResult;
            List<ElasticSearch.Client.Domain.Hits> objHitList = new List<ElasticSearch.Client.Domain.Hits> { };
            string strLine;
            string strID;
            int intIndex;
            int intLength;
            Regex objRegEx = null;
            Regex objRegEx_Pre = null;
            Regex objRegEx_Post = null;
            Regex objRegEx_Mutate = null;
            Match objMatch = null;
            Boolean boolParse;

            if (initializeClient())
            {

                while (true)
                {
                    objSearchResult = objElConn.Search(objLocalConfig.BaseConfig.Index, objLocalConfig.BaseConfig.Type, "*", intPos, intPackageLength);
                    objHitList = objSearchResult.GetHits().Hits;
                    foreach (ElasticSearch.Client.Domain.Hits objHit in objHitList)
                    {
                        strLine = objHit.Source["@message"].ToString();
                        Dictionary<string, object> objDict = new Dictionary<string, object> { };

                        if (strLine != null)
                        {
                            
                            strID = objHit.Id;
                            if (objLocalConfig.Meta.LastChange == true)
                            {
                                objDict.Add("last_change", DateTime.Now);
                            }

                            var objLGroups = from obj in objLocalConfig.Fields
                                             orderby obj.GroupID
                                             group obj by obj.GroupID into g
                                             select new { GroupID = g.Key };

                            foreach (var objGroup in objLGroups)
                            {
                                boolParse = true;
                                string strLineTmp = strLine;
                                var objLFields = from obj in objLocalConfig.Fields
                                                 orderby obj.OrderID
                                                 where obj.GroupID == objGroup.GroupID
                                                 select obj;

                                foreach (var objField in objLFields)
                                {
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
                                                strLineTmp = strLineTmp.Substring(intIndex + intLength);
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
                                                strLineTmp = strLineTmp.Substring(intIndex, intLength);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (objHitList.Count == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
