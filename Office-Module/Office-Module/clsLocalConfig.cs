using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;

namespace Office_Module
{
    class clsLocalConfig
    {
        private const string cstr_ID_SoftwareDevelopment = "9ad11085f76c4d1fbbb3136276a89852";
        private const string cstr_ID_Class_SoftwareDevelopment = "132a845f849f4f6b86847ab3fd068824";
        private const string cstr_ID_Class_DevelopmentConfig = "c6c9bcb80ac947139417eeec1453026c";
        private const string cstr_ID_Class_ConfigItem = "13c09f11175c4eefbc8a0fd8e86d557f";
        private const string cstr_ID_RelType_needs = "fafc1464815f45969737bcbc96bd744a";
        private const string cstr_ID_RelType_contains = "e971160347db44d8a476fe88290639a4";
        private const string cstr_ID_RelType_belongsTo = "e07469d9766c443e85266d9c684f944f";

        private clsGlobals objGlobals;

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;
	
	    public clsOntologyItem OItem_Type_Word_Templates { get; set; }
        public clsOntologyItem OItem_Type_Word_Management { get; set; }
        public clsOntologyItem OItem_Type_Templatefield { get; set; }
        public clsOntologyItem OItem_Type_Office_Module { get; set; }
        public clsOntologyItem OItem_Type_Module { get; set; }
        public clsOntologyItem OItem_Type_Managed_Document { get; set; }
        public clsOntologyItem OItem_type_Folder { get; set; }
        public clsOntologyItem OItem_Type_File { get; set; }
        public clsOntologyItem OItem_Type_Extensions { get; set; }
        public clsOntologyItem OItem_Type_Document_Type__managed_ { get; set; }
        public clsOntologyItem OItem_Type_ContentType { get; set; }
        public clsOntologyItem OItem_Type_ContentObject { get; set; }
        public clsOntologyItem OItem_Type_Contentformat { get; set; }
        public clsOntologyItem OItem_Token_Module_Office_Manager { get; set; }
        public clsOntologyItem OItem_Token_Extensions_dotx { get; set; }
        public clsOntologyItem OItem_Token_Extensions_docx { get; set; }
        public clsOntologyItem OItem_Token_Document_Type__managed__Winword_2007_Template { get; set; }
        public clsOntologyItem OItem_Token_Document_Type__managed__Winword_2007_Document { get; set; }
        public clsOntologyItem OItem_Token_ContentType_Templatefield { get; set; }
        public clsOntologyItem OItem_Token_ContentType_Name { get; set; }
        public clsOntologyItem OItem_Token_ContentType_Link { get; set; }
        public clsOntologyItem OItem_Token_ContentType_GUID { get; set; }
        public clsOntologyItem OItem_Token_ContentType_DocumentLink { get; set; }
        public clsOntologyItem OItem_Token_ContentType_Content { get; set; }
        public clsOntologyItem OItem_Token_ContentType_Bookmark { get; set; }
        public clsOntologyItem OItem_Token_ContentType_BatItemList { get; set; }
        public clsOntologyItem OItem_Token_Contentformat_MM_yyyy { get; set; }
        public clsOntologyItem OItem_Token_Contentformat_dd_MM_yyyy { get; set; }
        public clsOntologyItem OItem_RelationType_used_for { get; set; }
        public clsOntologyItem OItem_RelationType_Standard { get; set; }
        public clsOntologyItem OItem_RelationType_SourcesLocatedIn { get; set; }
        public clsOntologyItem OItem_RelationType_RelationType { get; set; }
        public clsOntologyItem OItem_RelationType_offered_by { get; set; }
        public clsOntologyItem OItem_RelationType_isSubordinated { get; set; }
        public clsOntologyItem OItem_RelationType_isDescribedBy { get; set; }
        public clsOntologyItem OItem_RelationType_is_of_Type { get; set; }
        public clsOntologyItem OItem_RelationType_is { get; set; }
        public clsOntologyItem OItem_RelationType_filtered_by { get; set; }
        public clsOntologyItem OItem_RelationType_contains { get; set; }
        public clsOntologyItem OItem_RelationType_belongsTo { get; set; }
        public clsOntologyItem OItem_RelationType_belonging_Type { get; set; }
        public clsOntologyItem OItem_RelationType_belonging_Sem_Item { get; set; }
        public clsOntologyItem OItem_RelationType_belonging_Document { get; set; }
        public clsOntologyItem OItem_RelationType_belonging_Attribute { get; set; }
        public clsOntologyItem OItem_Attribute_SubDirectory_Templates { get; set; }
        public clsOntologyItem OItem_Attribute_Seperator { get; set; }
        public clsOntologyItem OItem_Attribute_Path { get; set; }
        public clsOntologyItem OItem_attribute_dbPostfix { get; set; }
        public clsOntologyItem OItem_Attribute_DateTimeStamp__Change_ { get; set; }
    }
}
