using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Analyzer_Module
{
    [Flags]
    public enum FilterType
    {
        Contains = 1,
        ContainsNot = 2,
        Equal = 4,
        Different = 8,
        Regex = 16,
        RegexNot = 32
    }

    [Flags]
    public enum FilterConnector
    {
        And = 1,
        Or = 2,
        None = 4
    }

    public class clsRowFilter
    {
        public string Filter { get; set; }
        public FilterType TypeOfFilter { get; set; }
        public FilterConnector Connector { get; set; }
        public bool CaseSensitive { get; set; }
    }
}
