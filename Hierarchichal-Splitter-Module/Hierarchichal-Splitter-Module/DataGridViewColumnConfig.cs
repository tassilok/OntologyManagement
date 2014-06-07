using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hierarchichal_Splitter_Module
{
    public class DataGridViewColumnConfig
    {
        public DataGridViewColumn Column { get; set; }
        public bool Visible { get; set; }
        public int DisplayOrderId { get; set; }
    }
}
