using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;

namespace ImportExport_Module
{
    public class clsLocalConfig
    {
        public clsGlobals Globals { get; set; }

        public clsLocalConfig(clsGlobals Globals)
        {
            this.Globals = Globals;
        }
    }
}
