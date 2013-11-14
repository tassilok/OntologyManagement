using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    class clsField
    {
        public string Name { get; set; }
        public string RegexPre { get; set; }
        public string Regex { get; set; }
        public string RegexPost { get; set; }
        public string DataType { get; set; }
        public int PostFound { get; set; }
    }
}
