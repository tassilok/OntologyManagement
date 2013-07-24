using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OntWeb.Classes
{
    public class OntologyItem
    {
        public int DirectionLeftRight 
        {
            get
            {
                return 1;
            }
        
        }

        public int DirectionRightLeft { get { return 2; }} 
        public List<OntologyItem> OList_Rel { get; set; }
        public String GUID_Item { get; set; }
        public String GUID_Parent { get; set; }
        public String GUID_Related { get; set; }
        public String GUID_Relation { get; set; }
        public String Name_Item { get; set; }
        public String Caption { get; set; }
        public String Additional1 { get; set; }
        public String Additional2 { get; set; }
        public String Type_Item { get; set; }
        public String Filter { get; set; }
        public String ImageID { get; set; }
        public int Version { get; set; }
        public int Level { get; set; }
        public Boolean New { get; set; }
        public Boolean Del { get; set; }
        public Boolean Mark { get; set; }
        public Boolean ObjectReference { get; set; }
        public int Direction { get; set; }
        public long Min { get; set; }
        public long Max { get; set; }
        public long Max2 { get; set; }
        public long Val_Long { get; set; }
        public Boolean Val_Bool { get; set; }
        public DateTime Val_DateTime { get; set; }
        public Double Val_Double { get; set; }
        public String Val_String { get; set; }

        public long Count { get; set; }

        public void AddOItem(OntologyItem OItem)
        {
            OList_Rel.Add(OItem);
        }

        public OntologyItem()
        {
            
        }

        public OntologyItem(string GUID_Item,string Type_Item)
        {
            this.GUID_Item = GUID_Item;
            this.Type_Item = Type_Item;
        }

        public OntologyItem(string GUID_Item, string Name_Item, string Type_Item)
        {
            this.GUID_Item = GUID_Item;
            this.Name_Item = Name_Item;
            this.Type_Item = Type_Item;

        }

        public OntologyItem(string GUID_Item, string Name_Item, string GUID_Parent, string Type_Item)
        {
            this.GUID_Item = GUID_Item;
            this.Name_Item = Name_Item;
            this.GUID_Parent = GUID_Parent;
            this.Type_Item = Type_Item;

        }
    }
}