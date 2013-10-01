using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologyClasses.BaseClasses
{
    public class clsOntologyItem
    {

        private const int cint_LeftRight = 1;
        private const int cint_RightLeft = 2;
        public List<clsOntologyItem> OList_Rel { get; set; }

        public string GUID { get; set; }
        public string GUID_Parent { get; set; }
        public string GUID_Related { get; set; }
        public string GUID_Relation { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public string Additional1 { get; set; }
        public string Additional2 { get; set; }
        public string Type { get; set; }
        public string Filter { get; set; }
        public int? ImageID { get; set; }
        public int? Version { get; set; }
        public long? Level { get; set; }
        public bool? New_Item { get; set; }
        public bool? Deleted { get; set; }
        public bool? Mark { get; set; }
        public bool? ObjectReference { get; set; }
        public int? Direction { get; set; }
        public long? Min { get; set; }
        public long? Max1 { get; set; }
        public long? Max2 { get; set; }
        public long? Val_Long { get; set; }
        public bool? Val_Bool { get; set; }
        public DateTime? Val_Date { get; set; }
        public double? Val_Real { get; set; }
        public string Val_String { get; set; }

        public long? Count { get; set; }

        public int Direction_LeftRight { get { return cint_LeftRight;  } }
        public int Direction_RightLeft { get { return cint_RightLeft; } }

        public string NewGuid { get { return Guid.NewGuid().ToString().Replace("-",""); }}

        public void add_OItem(clsOntologyItem OItem)
        {
            OList_Rel.Add(OItem);
        }

        public clsOntologyItem()
        {
            
        }

        public clsOntologyItem(string GUID_Item, 
                               string Type)
        {
            this.GUID = GUID_Item;
            this.Type = Type;
        }
       

        public clsOntologyItem(string GUID_Item,
                               string Name_Item,
                               string Type)
        {
            this.GUID = GUID_Item;
            this.Name = Name_Item;
            this.Type = Type;
        }
        
        public clsOntologyItem(string GUID_Item,
                               string Name_Item,
                               string GUID_Item_Parent,
                               string Type)
        {
            this.GUID = GUID_Item;
            this.Name = Name_Item;
            this.GUID_Parent = GUID_Item_Parent;
            this.Type = Type;
        }
    
        public clsOntologyItem(string GUID_Item,
                               string Name_Item,
                               string GUID_Relation,
                               string GUID_Related,
                               string Type)
        {
            this.GUID = GUID_Item;
            this.Name = Name_Item;
            this.GUID_Relation = GUID_Relation;
            this.GUID_Related = GUID_Related;
            this.Type = Type;
        }
        

        public clsOntologyItem(string GUID_Item,
                               string GUID_Relation,
                               string GUID_Related,
                               long? Level,
                               string Type)
        {
            this.GUID = GUID_Item;
            this.GUID_Relation = GUID_Relation;
            this.GUID_Related = GUID_Related;
            this.Level = Level;
            this.Type = Type;
        }
        
        
    }
}
