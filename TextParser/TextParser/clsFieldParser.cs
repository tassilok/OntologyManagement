using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    public class clsFieldParser
    {
        private clsLocalConfig objLocalConfig;
        private List<clsField> ParseFieldList;

        public clsFieldParser(clsLocalConfig LocalConfig, List<clsField> ParseFieldList)
        {
            objLocalConfig = LocalConfig;
            this.ParseFieldList = ParseFieldList;
        }
    }
}
