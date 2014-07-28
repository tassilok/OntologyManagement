using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GraphMLConnector
{
    public class clsSearchAndReplace
    {
        public string Search { get; set; }
        public string Replace { get; set; }
        public bool IsRegEx { get; set; }
        public bool CaseSensitive { get; set; }

        public string ReplaceString(string input)
        {
            string result;
            if (CaseSensitive)
            {
                result = input.Replace(Search, Replace);
            }
            else if (IsRegEx)
            {
                result = Regex.Replace(input, Search, Replace);
            }
            else
            {
                result = input;

                while (result.Contains(Search))
                {
                    var start = result.ToLower().IndexOf(Search.ToLower());
                    var end = start + Search.Length;

                    result = result.Substring(0, start) + Replace + result.Substring(end);
                }
            }

            return result;
        }
    }
}
