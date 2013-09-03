using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OntWeb.Classes;

namespace OntWeb.DataClasses
{
    public class Directions
    {
        private OntologyItems OItems = new OntologyItems();
        private OItemTypes itemTypes = new OItemTypes();

        public OntologyItem LeftRight { get; set; }
        public OntologyItem RightLeft { get; set; }

        public Directions()
        {
            LeftRight = new OntologyItem()
            {
                GUID_Item = "cc99d5365d564fd29d4f45b48af33029", 
                Name_Item = "Left-Right", 
                GUID_Parent = (from oItem in OItems.Classes where oItem.Name_Item == "Directions" select oItem).ToList().First().GUID_Item, 
                Type_Item = itemTypes.ObjectType
            };

            LeftRight = new OntologyItem()
            {
                GUID_Item = "061243fc4c134bd5800c2c33b70e99b2",
                Name_Item = "Right-Left",
                GUID_Parent = (from oItem in OItems.Classes where oItem.Name_Item == "Directions" select oItem).ToList().First().GUID_Item,
                Type_Item = itemTypes.ObjectType
            };
        }
    }
}