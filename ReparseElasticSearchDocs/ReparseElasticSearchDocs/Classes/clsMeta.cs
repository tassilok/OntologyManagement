using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReparseElasticSearchDocs.Classes
{
    class clsMeta
    {
        private Boolean boolLastChange;
        private Boolean boolMessage;

        public Boolean LastChange
        {
            get { return boolLastChange; }
            set { boolLastChange = value; }
        }

        public Boolean Message
        {
            get { return boolMessage; }
            set { boolMessage = value; }
        }
    }
}
