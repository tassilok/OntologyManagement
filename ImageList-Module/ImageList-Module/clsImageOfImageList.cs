using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageList_Module
{
    public class clsImageOfImageList
    {
        public string ID_Image { get; set; }
        public string Name_Image { get; set; }
        public string ID_Attribute_IsRoot { get; set; }
        public bool IsRoot { get; set; }
        public string ID_KindOfOntology { get; set; }
        public string Name_KindOfOntology { get; set; }
        public Image ImageData { get; set; }
        public string ID_Ref { get; set; }
        public string Name_Ref { get; set; }
        public string ID_Parent_Ref { get; set; }
        public string Type_Ref { get; set; }
        public long ImageID { get; set; }
    }
}
