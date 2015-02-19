using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace TextParser
{
    public class ParseResult
    {
        public string ResultText { get; set; }
        public bool ParseOk { get; set; }
        public int IxEndPre { get; private set; }
        public int IxStartMain { get; private set; }
        public int LengthMain { get; private set; }

        private bool doLogEvent;

        public List<string> LogResult; 
        
        public ParseResult(bool doLogEvent = false)
        {
            this.doLogEvent = doLogEvent;
            LogResult = new List<string>();
        }

        public void Parse(string regexPre, string regexMain, string regexPost, bool replaceNewLine, bool doAll)
        {
            ParseOk = true;
            int ixStart_Post;
            bool getIxStart = true;
            string logText ="";

            if (replaceNewLine)
            {
                ResultText = ResultText.Replace(System.Environment.NewLine, "");    
            }
            
            // Regex-Pre
            // Regex-Pre
            if (doLogEvent)
            {
                logText = ResultText;
                LogResult.Clear();
                LogResult.Add("--------------------------------------------------------");
                LogResult.Add("--------------------------------------------------------");
                LogResult.Add(DateTime.Now.ToString("O") + "\t<PreMatch Start>\t" + regexPre ?? "");
                LogResult.Add(DateTime.Now.ToString("O") + "\t<PreMatch Start>\tSUCCESS\t" + logText);
            }

            if (!string.IsNullOrEmpty(regexPre))
            {
                var objRegExPre = new Regex(regexPre);

                // Regex im Text suchen
                var objMatches = objRegExPre.Matches(ResultText);
                if (objMatches.Count > 0 && objMatches[0].Length > 0)
                {

                    ResultText =
                        ResultText.Substring(objMatches[0].Index +
                                            objMatches[0].Length);
                    IxEndPre = objMatches[0].Index + objMatches[0].Length;
                    //ixStart = ixStart + objMatches[0].Index +
                    //            objMatches[0].Length-1;

                    ParseOk = true;
                }
                else if (objMatches.Count > 0 && objMatches[0].Length == 0)
                {
                    IxEndPre = objMatches[0].Index + objMatches[0].Length;
                    
                    ParseOk = true;
                }
                else
                {
             
                    ParseOk = false;
                }
            }
            else
            {
             
                IxEndPre = -1;
                ParseOk = true;
            }

            if (doLogEvent)
            {
                if (logText != ResultText)
                {
                    logText = logText.Replace(ResultText, "");
                    LogResult.Add(DateTime.Now.ToString("O") + "\t<PreMatch END>\t" + (ParseOk ? "SUCCESS" : "NOSUC") + "\t" + logText);
                }
                else
                {
                    LogResult.Add(DateTime.Now.ToString("O") + "\t<PreMatch END>\t" + (ParseOk ? "SUCCESS" : "NOSUC"));
                }
                
                
            }

            if (doLogEvent)
            {
                LogResult.Add("--------------------------------------------------------");
                LogResult.Add("--------------------------------------------------------");
                LogResult.Add(DateTime.Now.ToString("O") + "\t<PostMatch Start>\t" + regexPost ?? "");
                LogResult.Add(DateTime.Now.ToString("O") + "\t<PostMatch Start>\tSUCCESS\t");
            }

            if (ParseOk)
            {
                if (!string.IsNullOrEmpty(regexPost))
                {
                    var objRegExPost = new Regex(regexPost);
                    var objMatches = objRegExPost.Matches(ResultText);

                    if (!doAll)
                    {
                        if (objMatches.Count > 0 && objMatches[0].Length > 0)
                        {
                            ResultText = ResultText.Substring(0, objMatches[0].Index);
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

                            ParseOk = false;
                        }    
                    }
                    else
                    {
                        if (objMatches.Count > 0 && objMatches[objMatches.Count-1].Length > 0)
                        {
                            ResultText = ResultText.Substring(0, objMatches[objMatches.Count - 1].Index);
                            ixStart_Post = objMatches[objMatches.Count - 1].Index;
                            //ixStart += objMatches[0].Index + objMatches[0].Length-1;
                            getIxStart = false;
                        }
                        else if (objMatches.Count > 0 && objMatches[objMatches.Count - 1].Length == 0)
                        {
                            ixStart_Post = objMatches[objMatches.Count - 1].Index;
                        }
                        else
                        {

                            ParseOk = false;
                        }    
                    }
                    

                    
                }
                else
                {
                    ixStart_Post = -1;
                    ParseOk = true;
                }
            }

            if (doLogEvent)
            {
                if (logText != ResultText )
                {
                    LogResult.Add(DateTime.Now.ToString("O") + "\t<PostMatch END>\t" + (ParseOk ? "SUCCESS" : "NOSUC") + (!string.IsNullOrEmpty(ResultText) ? logText.Replace(ResultText, ""): logText));
                }
                else
                {
                    LogResult.Add(DateTime.Now.ToString("O") + "\t<PostMatch END>\t" + (ParseOk ? "SUCCESS" : "NOSUC"));

                }
                
            }

            if (doLogEvent)
            {
                LogResult.Add("--------------------------------------------------------");
                LogResult.Add("--------------------------------------------------------");
                LogResult.Add(DateTime.Now.ToString("O") + "\t<MainMatch Start>\t" + regexMain ?? "");
                LogResult.Add(DateTime.Now.ToString("O") + "\t<MainMatch Start>\tSUCCESS\t");
            }

            if (ParseOk)
            {
                if (!string.IsNullOrEmpty(regexMain))
                {
                    var objRegEx = new Regex(regexMain);
                    var objMatches = objRegEx.Matches(ResultText);

                    if (objMatches.Count > 0 && objMatches[0].Length > 0)
                    {
                        ResultText = ResultText.Substring(objMatches[0].Index,
                                                        objMatches[0].Length);

                        IxStartMain = objMatches[0].Index;
                        LengthMain = objMatches[0].Length;
                        if (getIxStart)
                        {

                            //ixStart += objMatches[0].Index + objMatches[0].Length - 1;
                        }


                    }
                    else if (objMatches.Count > 0 && objMatches[0].Length == 0)
                    {
                        IxStartMain = objMatches[0].Index;
                        LengthMain = 0;
                    }
                    else
                    {

                        ParseOk = false;
                    }
                }
                else
                {
                    IxStartMain = -1;
                }
            }

            if (doLogEvent)
            {
                if (logText != ResultText)
                {
                    LogResult.Add(DateTime.Now.ToString("O") + "\t<MainMatch END>\t" + (ParseOk ? "SUCCESS" : "NOSUC") +
                                  (!string.IsNullOrEmpty(ResultText) ? logText.Replace(ResultText, "") : logText));
                    LogResult.Add("--------------------------------------------------------");
                    LogResult.Add("--------------------------------------------------------");
                }
                else
                {
                    LogResult.Add(DateTime.Now.ToString("O") + "\t<MainMatch END>\t" + (ParseOk ? "SUCCESS" : "NOSUC"));
                    LogResult.Add("--------------------------------------------------------");
                    LogResult.Add("--------------------------------------------------------");
                }

            }
        }
    }
}
