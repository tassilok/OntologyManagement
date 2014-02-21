using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace File_Analyzer_Module
{
    public class clsFileContent
    {
        private long lngLineNumber;

        public string IdFile { get; set; }
        public long LineNumber
        {
            get
            {
                return lngLineNumber;
            }
            set { lngLineNumber = value; }
        }
        public string FileLine { get; set; }


        public bool IsFiltered(clsRowFilter rowFilter)
        {
            switch (rowFilter.TypeOfFilter)
            {
                case FilterType.Contains:
                    if (rowFilter.CaseSensitive)
                    {
                        if (FileLine.Contains(rowFilter.Filter)) return true;

                        return false;
                    }
                    else
                    {
                        if (FileLine.ToLower().Contains(rowFilter.Filter.ToLower())) return true;

                        return false;
                    }
                    break;
                case FilterType.ContainsNot:
                    if (rowFilter.CaseSensitive)
                    {
                        if (!FileLine.Contains(rowFilter.Filter)) return true;

                        return false;
                    }
                    else
                    {
                        if (!FileLine.ToLower().Contains(rowFilter.Filter.ToLower())) return true;

                        return false;
                    }
                    break;
                case FilterType.Equal:
                    if (rowFilter.CaseSensitive)
                    {
                        if (FileLine == rowFilter.Filter) return true;

                        return false;
                    }
                    else
                    {
                        if (FileLine.ToLower() == rowFilter.Filter.ToLower()) return true;

                        return false;
                    }
                    break;
                case FilterType.Different:
                    if (rowFilter.CaseSensitive)
                    {
                        if (FileLine != rowFilter.Filter) return true;

                        return false;
                    }
                    else
                    {
                        if (FileLine.ToLower() != rowFilter.Filter.ToLower()) return true;

                        return false;
                    }
                    break;
                case FilterType.Regex:
                    if (Regex.Match(FileLine, rowFilter.Filter).Success) return true;

                    return false;
                    break;
                case FilterType.RegexNot:
                    if (!Regex.Match(FileLine, rowFilter.Filter).Success) return true;

                    return false;
                    break;
                default:
                    return false;
            }
        }
        
    }
}
