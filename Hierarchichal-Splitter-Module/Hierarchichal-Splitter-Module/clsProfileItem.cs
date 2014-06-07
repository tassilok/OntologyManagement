using Hierarchichal_Splitter_Module.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchichal_Splitter_Module
{
    public class clsProfileItem
    {
        [GridConfigure(Visible=false)]
        public string Id_Item { get; set; }
        
        [GridConfigure(Visible = true)]
        public string Name_Item { get; set; }

        [GridConfigure(Visible = true)]
        public bool NameShorted { get; set; }

        [GridConfigure(Visible = false)]
        public string Id_Parent { get; set; }

        [GridConfigure(Visible = true)]
        public string Name_Parent { get; set; }

        [GridConfigure(Visible = true)]
        public string Type { get; set; }

        [GridConfigure(Visible = false)]
        public string Id_CreateRule { get; set; }

        [GridConfigure(Visible = true)]
        public string Name_CreateRule { get; set; }

        [GridConfigure(Visible = false)]
        public string Id_RelationTypeToSubordinated { get; set; }

        [GridConfigure(Visible = true)]
        public string Name_RelationTypeToSubordinated { get; set; }

        [GridConfigure(Visible = false)]
        public string Id_RelationRule { get; set; }

        [GridConfigure(Visible = true)]
        public string Name_RelationRule { get; set; }

        [GridConfigure(Visible = true)]
        public long OrderId { get; set; }

        [GridConfigure(Visible = true)]
        public bool Imported { get; set; }

        [GridConfigure(Visible = false)]
        public string Id_HierarchicalProfile { get; set; }

        [GridConfigure(Visible = false)]
        public string Name_HierarchicalProfile { get; set; }

        [GridConfigure(Visible = false)]
        public string Id_Ontology { get; set; }

        [GridConfigure(Visible = false)]
        public string Name_Ontology { get; set; }
    }
}
