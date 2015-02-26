using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    public class clsField
    {
        public long OrderId { get; set; }
        public string ID_FieldParser { get; set; }
        public string Name_FieldParser { get; set; }
        public string ID_Field { get; set; }
        public string Name_Field { get; set; }
        public string ID_MetaField { get; set; }
        public string Name_MetaField { get; set; }
        public bool IsMeta { get; set; }
        public bool IsInsert { get; set; }
        public string ID_RegExPre { get; set; }
        public string ID_Attribute_RegExPreVal { get; set; }
        public string RegexPre { get; set; }
        public string ID_RegExMain { get; set; }
        public string ID_Attribute_RegExMainVal { get; set; }
        public string Regex { get; set; }
        public string ID_RegExPost { get; set; }
        public string ID_Attribute_RegExPostVal { get; set; }
        public string RegexPost { get; set; }
        public string Insert { get; set; }
        public string ID_DataType { get; set; }
        public string DataType { get; set; }
        public string ID_Attribute_UseOrderID { get; set; }
        public bool UseOrderId { get; set; }
        public string ID_Attribute_RemoveFromSource { get; set; }
        public bool RemoveFromSource { get; set; }
        public string ID_Attribute_UseLastValid { get; set; }
        public bool UseLastValid { get; set; }
        public string LastValid { get; set; }
        public string ID_ReferenceField { get; set; }
        public string Name_ReferenceField { get; set; }
        public string LastContent { get; set; }
        public string ID_Attribute_DoAll { get; set;  }
        public bool DoAll { get; set; }
        public List<clsRegExReplace> ReplaceList { get; set; }
        public List<clsField> FieldListContained { get; set; } 

        public clsField Clone()
        {
            return new clsField
            {
                DataType = DataType,
                Regex = Regex,
                DoAll = DoAll,
                ID_Attribute_DoAll = ID_Attribute_DoAll,
                ID_Attribute_RegExMainVal = ID_Attribute_RegExMainVal,
                ID_Attribute_RegExPostVal = ID_Attribute_RegExPostVal,
                ID_Attribute_RegExPreVal = ID_Attribute_RegExPreVal,
                ID_Attribute_RemoveFromSource = ID_Attribute_RemoveFromSource,
                ID_Attribute_UseLastValid = ID_Attribute_UseLastValid,
                ID_Attribute_UseOrderID = ID_Attribute_UseOrderID,
                ID_DataType = ID_DataType,
                ID_Field = ID_Field,
                ID_FieldParser = ID_FieldParser,
                ID_MetaField = ID_MetaField,
                ID_ReferenceField = ID_ReferenceField,
                ID_RegExMain = ID_RegExMain,
                ID_RegExPost = ID_RegExPost,
                ID_RegExPre = ID_RegExPre,
                Insert = Insert,
                IsInsert = IsInsert,
                IsMeta = IsMeta,
                LastContent = LastContent,
                LastValid = LastValid,
                Name_Field = Name_Field,
                Name_FieldParser = Name_FieldParser,
                Name_MetaField = Name_MetaField,
                Name_ReferenceField = Name_ReferenceField,
                OrderId = OrderId,
                RegexPost = RegexPost,
                RegexPre = RegexPre,
                RemoveFromSource = RemoveFromSource,
                UseLastValid = UseLastValid,
                UseOrderId = UseOrderId,
                ReplaceList = ReplaceList,
                FieldListContained =  FieldListContained
            };
        }
    }
}
