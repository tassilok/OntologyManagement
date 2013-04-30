using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReparseElasticSearchDocs.Classes
{
    class clsMeta
    {
        private Boolean boolLastChange;

        public Boolean LastChange
        {
            get { return boolLastChange; }
            set { boolLastChange = value; }
        }
    }
}
