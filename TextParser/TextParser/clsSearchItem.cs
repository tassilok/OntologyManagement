using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    class clsSearchItem
    {
        public bool ValueFirst { get; set; }

        public string EntryName { get; set; }
        public string EntryRegexPre { get; set; }
        public string EntryRegex { get; set; }
        public string EntryRegexPost { get; set; }
        public string EntryDataType { get; set; }
        public int EntryPostFound { get; set; }

        public string ValueName { get; set; }
        public string ValueRegexPre { get; set; }
        public string ValueRegex { get; set; }
        public string ValueRegexPost { get; set; }
        public string ValueDataType { get; set; }
        public int ValuePostFound { get; set; }
    }
}
