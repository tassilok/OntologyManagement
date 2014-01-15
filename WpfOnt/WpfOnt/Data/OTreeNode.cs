using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOnt.Data
{
    public class OTreeNode
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<OTreeNode> Nodes { get; set; }

        public OTreeNode()
        {
            Nodes = new List<OTreeNode>();
        }
    }
}
