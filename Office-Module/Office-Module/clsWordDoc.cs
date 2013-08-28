using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace Office_Module
{
    class clsWordDoc
    {
        public string ID_Doc { get; set; }
        public Document WordDoc { get; set; }
        public string PathDoc { get; set; }

    }
}
