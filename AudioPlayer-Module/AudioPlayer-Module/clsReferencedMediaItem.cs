using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer_Module
{
    public class clsReferencedMediaItem : clsMultimediaItem
    {
        public string ID_Ref { get; set; }
        public string Name_Ref { get; set; }
        public string ID_Parent_Ref { get; set; }
        public string Name_Parent_Ref { get; set; }
        public string Ontology { get; set; }

        public bool IsFiltered(string filter, bool exact = false, string property = null)
        {
            if (property == null)
            {
                if (exact)
                {
                    if (ID_Item == filter ||
                        Name_Item.ToLower() == filter.ToLower() ||
                        ID_Ref == filter ||
                        Name_Ref.ToLower() == filter.ToLower() ||
                        ID_Parent_Ref == filter ||
                        Name_Parent_Ref .ToLower() == filter.ToLower() ||
                        Ontology.ToLower() == filter.ToLower())
                    {
                        return true;
                    }
                    
                }
                else
                {
                    if (ID_Item == filter ||
                        Name_Item.ToLower().Contains(filter.ToLower()) ||
                        ID_Ref == filter ||
                        Name_Ref.ToLower().Contains(filter.ToLower()) ||
                        ID_Parent_Ref == filter ||
                        Name_Parent_Ref .ToLower().Contains(filter.ToLower()) ||
                        Ontology.ToLower() == filter.ToLower())
                    {
                        return true;
                    }
                }
                
                
            }
            else
            {
                switch (property)
                {
                    case "ID_Item":
                        return ID_Item == filter;
                        
                    case "Name_Item":
                        return exact ? Name_Item.ToLower() == filter.ToLower() : Name_Item.ToLower().Contains(filter.ToLower());
                        

                    case "ID_Ref":
                        return ID_Ref == filter;
                        
                    case "Name_Ref":
                        return exact ? Name_Ref.ToLower() == filter.ToLower() : Name_Ref.ToLower().Contains(filter.ToLower());
                        
                    case "ID_Parent_Ref":
                        return ID_Parent_Ref == filter;
                        

                    case "Name_Parent_Ref":
                        return exact ? Name_Parent_Ref.ToLower() == filter.ToLower() : Name_Parent_Ref.ToLower().Contains(filter.ToLower());
                        

                    case "Ontology":
                        return exact ? Ontology.ToLower() == filter.ToLower() : Ontology.ToLower().Contains(filter.ToLower());
                        
                        
                }
                

            }
            return false;
            
        }
    }
}
