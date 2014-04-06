using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace Typed_Tagging_Module
{
    public class clsTabControl
    {
        public string TabName { get; set; }
        public UserControl_Tagging objUserControl_Tagging { get; set; }
        public clsOntologyItem ClassItem { get; set; }
    }
}
