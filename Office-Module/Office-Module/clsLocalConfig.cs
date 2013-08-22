using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;

namespace Office_Module
{
    public class clsLocalConfig
    {
        private const string cstr_ID_SoftwareDevelopment = "9ad11085f76c4d1fbbb3136276a89852";
        private const string cstr_ID_Class_SoftwareDevelopment = "132a845f849f4f6b86847ab3fd068824";
        private const string cstr_ID_Class_DevelopmentConfig = "c6c9bcb80ac947139417eeec1453026c";
        private const string cstr_ID_Class_ConfigItem = "13c09f11175c4eefbc8a0fd8e86d557f";
        private const string cstr_ID_RelType_needs = "fafc1464815f45969737bcbc96bd744a";
        private const string cstr_ID_RelType_contains = "e971160347db44d8a476fe88290639a4";
        private const string cstr_ID_RelType_belongsTo = "e07469d9766c443e85266d9c684f944f";

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;

        public int ImageID_Root
        {
            get { return 0; }
        }

        public int ImageID_Close
        {
            get { return 1; }
        }

        public int ImageID_SubItems
        {
            get { return 2; }
        }

        public int ImageID_Images
        {
            get { return 3; }
        }
    
        public int ImageID_Close_Images_SubItems
        {
            get { return 4; }
        }
    
        public int ImageID_Open
        {
            get { return 5; }
        }
    
        public int ImageID_Open_Subitems
        {
            get { return 6; }
        }

        public int ImageID_Open_Images
        {
            get { return 7; }
        }

        public int ImageID_Open_Images_SubItems
        {
            get { return 8; }
        }
    
        public int ImageID_Attributes
        {
            get { return 9; }
        }
    
        public int ImageID_RelationTypes
        {
            get { return 10; }
        }

        public int ImageID_Token
        {
            get { return 11; }
        }
    
        public int ImageID_Attribute
        {
            get { return 12; }
        }
    
        public int ImageID_RelationType
        {
            get { return 13; }
        }
    
	
        // Classes
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

        // Objects
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

        // RelationTypes
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

        // Attributes
        public clsOntologyItem OItem_Attribute_SubDirectory_Templates { get; set; }
        public clsOntologyItem OItem_Attribute_Seperator { get; set; }
        public clsOntologyItem OItem_Attribute_Path { get; set; }
        public clsOntologyItem OItem_attribute_dbPostfix { get; set; }
        public clsOntologyItem OItem_Attribute_DateTimeStamp__Change_ { get; set; }

        private void get_Data_DevelopmentConfig()
        {
            List<clsObjectRel> oList_ObjectRel = new List<clsObjectRel> ();
            List<clsOntologyItem> oList_ConfigItems = new List<clsOntologyItem> ();

            List<clsOntologyItem> oList_RelType_contains = new List<clsOntologyItem> ();
            List<clsOntologyItem> oList_RelType_belongsTo = new List<clsOntologyItem> ();

            List<clsOntologyItem> oList_ConfigItem = new List<clsOntologyItem>();

            oList_ObjectRel.Add(new clsObjectRel(cstr_ID_SoftwareDevelopment,
                                            null,
                                            null,
                                            null,
                                            null,
                                            null,
                                            cstr_ID_Class_DevelopmentConfig,
                                            null,
                                            cstr_ID_RelType_needs,
                                            null,
                                            Globals.Type_Object,
                                            null,
                                            null,
                                            null));

            objDBLevel_Config1.get_Data_ObjectRel(oList_ObjectRel);

            if (objDBLevel_Config1.OList_ObjectRel_ID.Count > 0)
            {

            
                objOItem_DevConfig.GUID = objDBLevel_Config1.OList_ObjectRel_ID[0].ID_Other;
                objOItem_DevConfig.Name = objDBLevel_Config1.OList_ObjectRel_ID[0].Name_Other;
                objOItem_DevConfig.GUID_Parent = objDBLevel_Config1.OList_ObjectRel_ID[0].ID_Parent_Other;
                objOItem_DevConfig.Type = objDBLevel_Config1.OList_ObjectRel_ID[0].Ontology;

                oList_ObjectRel.Clear();
                oList_ObjectRel.Add(new clsObjectRel(objOItem_DevConfig.GUID,
                                                     null,
                                                     null,
                                                     null,
                                                     null,
                                                     null,
                                                     cstr_ID_Class_ConfigItem,
                                                     null,
                                                     cstr_ID_RelType_contains,
                                                     null,
                                                     Globals.Type_Object,
                                                     null,
                                                     null,
                                                     null));

                objDBLevel_Config1.get_Data_ObjectRel(oList_ObjectRel,
                                              false,
                                              false,
                                              false,
                                              Globals.Direction_LeftRight.Name,
                                              true);
                oList_ObjectRel.Clear();
                if (objDBLevel_Config1.OList_ObjectRel.Count > 0)
                {
                    foreach (var objOItem_ObjecRel in objDBLevel_Config1.OList_ObjectRel)
                    {
                        oList_ConfigItems.Add(new clsOntologyItem(objOItem_ObjecRel.ID_Other,
                                                                  Globals.Type_Object));

                        oList_ObjectRel.Add(new clsObjectRel(objOItem_ObjecRel.ID_Other,
                                                             null,
                                                             null,
                                                             null,
                                                             null,
                                                             null,
                                                             null,
                                                             null,
                                                             cstr_ID_RelType_belongsTo,
                                                             null,
                                                             null,
                                                             Globals.Direction_LeftRight.GUID,
                                                             Globals.Direction_LeftRight.Name,
                                                             null));
                    }
                    



                

                    objDBLevel_Config2.get_Data_ObjectRel(oList_ObjectRel,
                                                             false,
                                                             false,
                                                             false,
                                                             Globals.Direction_LeftRight.Name,
                                                             false);
                }
                else
                {
                    throw new Exception("Config not set!");
                }
            }
            else
            {
                throw new Exception("Config not set!");
            }

        }

        private void set_DBConnection()
        {
		    objDBLevel_Config1 = new clsDBLevel(Globals);
		    objDBLevel_Config2 = new clsDBLevel(Globals);
        }
  
	    private void get_Config()
        {
            get_Data_DevelopmentConfig();
            get_Config_AttributeTypes();
		    get_Config_RelationTypes();
		    get_Config_Classes();
            get_Config_Objects();
        }

        private void get_Config_AttributeTypes()
        {
            var objOList_AttributeType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                          where (obj.Name_Object.ToLower() == "attribute_subdirectory_templates") &&
                                                (obj.Ontology == Globals.Type_AttributeType)
                                          select obj).ToList();

            if (objOList_AttributeType.Any())
            {
                OItem_Attribute_SubDirectory_Templates = new clsOntologyItem();
                OItem_Attribute_SubDirectory_Templates.GUID = objOList_AttributeType[0].ID_Other;
                OItem_Attribute_SubDirectory_Templates.Name = objOList_AttributeType[0].Name_Other;
                OItem_Attribute_SubDirectory_Templates.GUID_Parent = objOList_AttributeType[0].ID_Parent_Other;
                OItem_Attribute_SubDirectory_Templates.Type = Globals.Type_AttributeType;
            }   
            else
            {
                throw new Exception("config err");
            }

            objOList_AttributeType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                          where (obj.Name_Object.ToLower() == "attribute_seperator") &&
                                                (obj.Ontology == Globals.Type_AttributeType)
                                          select obj).ToList();

            if (objOList_AttributeType.Any())
            {
                OItem_Attribute_Seperator = new clsOntologyItem();
                OItem_Attribute_Seperator.GUID = objOList_AttributeType[0].ID_Other;
                OItem_Attribute_Seperator.Name = objOList_AttributeType[0].Name_Other;
                OItem_Attribute_Seperator.GUID_Parent = objOList_AttributeType[0].ID_Parent_Other;
                OItem_Attribute_Seperator.Type = Globals.Type_AttributeType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_AttributeType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                      where (obj.Name_Object.ToLower() == "attribute_path") &&
                                            (obj.Ontology == Globals.Type_AttributeType)
                                      select obj).ToList();

            if (objOList_AttributeType.Any())
            {
                OItem_Attribute_Path = new clsOntologyItem();
                OItem_Attribute_Path.GUID = objOList_AttributeType[0].ID_Other;
                OItem_Attribute_Path.Name = objOList_AttributeType[0].Name_Other;
                OItem_Attribute_Path.GUID_Parent = objOList_AttributeType[0].ID_Parent_Other;
                OItem_Attribute_Path.Type = Globals.Type_AttributeType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_AttributeType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                      where (obj.Name_Object.ToLower() == "attribute_dbpostfix") &&
                                            (obj.Ontology == Globals.Type_AttributeType)
                                      select obj).ToList();

            if (objOList_AttributeType.Any())
            {
                OItem_attribute_dbPostfix = new clsOntologyItem();
                OItem_attribute_dbPostfix.GUID = objOList_AttributeType[0].ID_Other;
                OItem_attribute_dbPostfix.Name = objOList_AttributeType[0].Name_Other;
                OItem_attribute_dbPostfix.GUID_Parent = objOList_AttributeType[0].ID_Parent_Other;
                OItem_attribute_dbPostfix.Type = Globals.Type_AttributeType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_AttributeType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                      where (obj.Name_Object.ToLower() == "attribute_datetimestamp__change_") &&
                                            (obj.Ontology == Globals.Type_AttributeType)
                                      select obj).ToList();

            if (objOList_AttributeType.Any())
            {
                OItem_Attribute_DateTimeStamp__Change_ = new clsOntologyItem();
                OItem_Attribute_DateTimeStamp__Change_.GUID = objOList_AttributeType[0].ID_Other;
                OItem_Attribute_DateTimeStamp__Change_.Name = objOList_AttributeType[0].Name_Other;
                OItem_Attribute_DateTimeStamp__Change_.GUID_Parent = objOList_AttributeType[0].ID_Parent_Other;
                OItem_Attribute_DateTimeStamp__Change_.Type = Globals.Type_AttributeType;
            }
            else
            {
                throw new Exception("config err");
            }
        }

        private void get_Config_RelationTypes()
        {
            var objOList_RelationType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                          where (obj.Name_Object.ToLower() == "relationtype_used_for") &&
                                            (obj.Ontology == Globals.Type_RelationType)
                                          select obj).ToList();

            if (objOList_RelationType.Any())
            {
                OItem_RelationType_used_for = new clsOntologyItem();
                OItem_RelationType_used_for.GUID = objOList_RelationType[0].ID_Other;
                OItem_RelationType_used_for.Name = objOList_RelationType[0].Name_Other;
                OItem_RelationType_used_for.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_RelationType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                         where (obj.Name_Object.ToLower() == "relationtype_standard") &&
                                           (obj.Ontology == Globals.Type_RelationType)
                                         select obj).ToList();

            if (objOList_RelationType.Any())
            {
                OItem_RelationType_Standard = new clsOntologyItem();
                OItem_RelationType_Standard.GUID = objOList_RelationType[0].ID_Other;
                OItem_RelationType_Standard.Name = objOList_RelationType[0].Name_Other;
                OItem_RelationType_Standard.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_RelationType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                     where (obj.Name_Object.ToLower() == "relationtype_sourceslocatedin") &&
                                           (obj.Ontology == Globals.Type_RelationType)
                                         select obj).ToList();
            
            if (objOList_RelationType.Any())
            {
                OItem_RelationType_SourcesLocatedIn = new clsOntologyItem();
                OItem_RelationType_SourcesLocatedIn.GUID = objOList_RelationType[0].ID_Other;
                OItem_RelationType_SourcesLocatedIn.Name = objOList_RelationType[0].Name_Other;
                OItem_RelationType_SourcesLocatedIn.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_RelationType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                     where (obj.Name_Object.ToLower() == "relationtype_relationtype") &&
                                           (obj.Ontology == Globals.Type_RelationType)
                                     select obj).ToList();

            if (objOList_RelationType.Any())
            {
                OItem_RelationType_RelationType = new clsOntologyItem();
                OItem_RelationType_RelationType.GUID = objOList_RelationType[0].ID_Other;
                OItem_RelationType_RelationType.Name = objOList_RelationType[0].Name_Other;
                OItem_RelationType_RelationType.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_RelationType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                     where (obj.Name_Object.ToLower() == "relationtype_offered_by") &&
                                           (obj.Ontology == Globals.Type_RelationType)
                                     select obj).ToList();

            if (objOList_RelationType.Any())
            {
                OItem_RelationType_offered_by = new clsOntologyItem();
                OItem_RelationType_offered_by.GUID = objOList_RelationType[0].ID_Other;
                OItem_RelationType_offered_by.Name = objOList_RelationType[0].Name_Other;
                OItem_RelationType_offered_by.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_RelationType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                     where (obj.Name_Object.ToLower() == "relationtype_issubordinated") &&
                                           (obj.Ontology == Globals.Type_RelationType)
                                     select obj).ToList();

            if (objOList_RelationType.Any())
            {
                OItem_RelationType_isSubordinated = new clsOntologyItem();
                OItem_RelationType_isSubordinated.GUID = objOList_RelationType[0].ID_Other;
                OItem_RelationType_isSubordinated.Name = objOList_RelationType[0].Name_Other;
                OItem_RelationType_isSubordinated.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_RelationType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                     where (obj.Name_Object.ToLower() == "relationtype_isdescribedby") &&
                                           (obj.Ontology == Globals.Type_RelationType)
                                     select obj).ToList();

            if (objOList_RelationType.Any())
            {
                OItem_RelationType_isDescribedBy = new clsOntologyItem();
                OItem_RelationType_isDescribedBy.GUID = objOList_RelationType[0].ID_Other;
                OItem_RelationType_isDescribedBy.Name = objOList_RelationType[0].Name_Other;
                OItem_RelationType_isDescribedBy.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_RelationType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                     where (obj.Name_Object.ToLower() == "relationtype_is_of_type") &&
                                           (obj.Ontology == Globals.Type_RelationType)
                                     select obj).ToList();

            if (objOList_RelationType.Any())
            {
                OItem_RelationType_is_of_Type = new clsOntologyItem();
                OItem_RelationType_is_of_Type.GUID = objOList_RelationType[0].ID_Other;
                OItem_RelationType_is_of_Type.Name = objOList_RelationType[0].Name_Other;
                OItem_RelationType_is_of_Type.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_RelationType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                     where (obj.Name_Object.ToLower() == "relationtype_is") &&
                                           (obj.Ontology == Globals.Type_RelationType)
                                     select obj).ToList();

            if (objOList_RelationType.Any())
            {
                OItem_RelationType_is = new clsOntologyItem();
                OItem_RelationType_is.GUID = objOList_RelationType[0].ID_Other;
                OItem_RelationType_is.Name = objOList_RelationType[0].Name_Other;
                OItem_RelationType_is.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_RelationType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                     where (obj.Name_Object.ToLower() == "relationtype_filtered_by") &&
                                           (obj.Ontology == Globals.Type_RelationType)
                                     select obj).ToList();

            if (objOList_RelationType.Any())
            {
                OItem_RelationType_filtered_by = new clsOntologyItem();
                OItem_RelationType_filtered_by.GUID = objOList_RelationType[0].ID_Other;
                OItem_RelationType_filtered_by.Name = objOList_RelationType[0].Name_Other;
                OItem_RelationType_filtered_by.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_RelationType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                     where (obj.Name_Object.ToLower() == "relationtype_contains") &&
                                           (obj.Ontology == Globals.Type_RelationType)
                                     select obj).ToList();

            if (objOList_RelationType.Any())
            {
                OItem_RelationType_contains = new clsOntologyItem();
                OItem_RelationType_contains.GUID = objOList_RelationType[0].ID_Other;
                OItem_RelationType_contains.Name = objOList_RelationType[0].Name_Other;
                OItem_RelationType_contains.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_RelationType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                     where (obj.Name_Object.ToLower() == "relationtype_contains") &&
                                           (obj.Ontology == Globals.Type_RelationType)
                                     select obj).ToList();

            if (objOList_RelationType.Any())
            {
                OItem_RelationType_contains = new clsOntologyItem();
                OItem_RelationType_contains.GUID = objOList_RelationType[0].ID_Other;
                OItem_RelationType_contains.Name = objOList_RelationType[0].Name_Other;
                OItem_RelationType_contains.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_RelationType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                     where (obj.Name_Object.ToLower() == "relationtype_belongsto") &&
                                           (obj.Ontology == Globals.Type_RelationType)
                                     select obj).ToList();

            if (objOList_RelationType.Any())
            {
                OItem_RelationType_belongsTo = new clsOntologyItem();
                OItem_RelationType_belongsTo.GUID = objOList_RelationType[0].ID_Other;
                OItem_RelationType_belongsTo.Name = objOList_RelationType[0].Name_Other;
                OItem_RelationType_belongsTo.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_RelationType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                     where (obj.Name_Object.ToLower() == "relationtype_belonging_type") &&
                                           (obj.Ontology == Globals.Type_RelationType)
                                     select obj).ToList();

            if (objOList_RelationType.Any())
            {
                OItem_RelationType_belonging_Type = new clsOntologyItem();
                OItem_RelationType_belonging_Type.GUID = objOList_RelationType[0].ID_Other;
                OItem_RelationType_belonging_Type.Name = objOList_RelationType[0].Name_Other;
                OItem_RelationType_belonging_Type.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_RelationType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                     where (obj.Name_Object.ToLower() == "relationtype_belonging_sem_item") &&
                                           (obj.Ontology == Globals.Type_RelationType)
                                     select obj).ToList();

            if (objOList_RelationType.Any())
            {
                OItem_RelationType_belonging_Sem_Item = new clsOntologyItem();
                OItem_RelationType_belonging_Sem_Item.GUID = objOList_RelationType[0].ID_Other;
                OItem_RelationType_belonging_Sem_Item.Name = objOList_RelationType[0].Name_Other;
                OItem_RelationType_belonging_Sem_Item.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_RelationType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                     where (obj.Name_Object.ToLower() == "relationtype_belonging_document") &&
                                           (obj.Ontology == Globals.Type_RelationType)
                                     select obj).ToList();

            if (objOList_RelationType.Any())
            {
                OItem_RelationType_belonging_Document = new clsOntologyItem();
                OItem_RelationType_belonging_Document.GUID = objOList_RelationType[0].ID_Other;
                OItem_RelationType_belonging_Document.Name = objOList_RelationType[0].Name_Other;
                OItem_RelationType_belonging_Document.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_RelationType = (from obj in objDBLevel_Config2.OList_ObjectRel
                                     where (obj.Name_Object.ToLower() == "relationtype_belonging_attribute") &&
                                           (obj.Ontology == Globals.Type_RelationType)
                                     select obj).ToList();

            if (objOList_RelationType.Any())
            {
                OItem_RelationType_belonging_Attribute  = new clsOntologyItem();
                OItem_RelationType_belonging_Attribute.GUID = objOList_RelationType[0].ID_Other;
                OItem_RelationType_belonging_Attribute.Name = objOList_RelationType[0].Name_Other;
                OItem_RelationType_belonging_Attribute.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("config err");
            }
        }

        private void get_Config_Objects()
        {
            var objOList_Object = (from obj in objDBLevel_Config2.OList_ObjectRel
                                   where (obj.Name_Object.ToLower() == "token_module_office_manager") &&
                                         (obj.Ontology == Globals.Type_Object)
                                   select obj).ToList();

            if (objOList_Object.Any())
            {
                OItem_Token_Module_Office_Manager = new clsOntologyItem();
                OItem_Token_Module_Office_Manager.GUID = objOList_Object[0].ID_Other;
                OItem_Token_Module_Office_Manager.Name = objOList_Object[0].Name_Other;
                OItem_Token_Module_Office_Manager.GUID_Parent = objOList_Object[0].ID_Parent_Other;
                OItem_Token_Module_Office_Manager.Type = Globals.Type_Object;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Object = (from obj in objDBLevel_Config2.OList_ObjectRel
                               where (obj.Name_Object.ToLower() == "token_extensions_dotx") &&
                                     (obj.Ontology == Globals.Type_Object)
                               select obj).ToList();

            if (objOList_Object.Any())
            {
                OItem_Token_Extensions_dotx = new clsOntologyItem();
                OItem_Token_Extensions_dotx.GUID = objOList_Object[0].ID_Other;
                OItem_Token_Extensions_dotx.Name = objOList_Object[0].Name_Other;
                OItem_Token_Extensions_dotx.GUID_Parent = objOList_Object[0].ID_Parent_Other;
                OItem_Token_Extensions_dotx.Type = Globals.Type_Object;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Object = (from obj in objDBLevel_Config2.OList_ObjectRel
                               where (obj.Name_Object.ToLower() == "token_extensions_docx") &&
                                     (obj.Ontology == Globals.Type_Object)
                               select obj).ToList();

            if (objOList_Object.Any())
            {
                OItem_Token_Extensions_docx = new clsOntologyItem();
                OItem_Token_Extensions_docx.GUID = objOList_Object[0].ID_Other;
                OItem_Token_Extensions_docx.Name = objOList_Object[0].Name_Other;
                OItem_Token_Extensions_docx.GUID_Parent = objOList_Object[0].ID_Parent_Other;
                OItem_Token_Extensions_docx.Type = Globals.Type_Object;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Object = (from obj in objDBLevel_Config2.OList_ObjectRel
                               where (obj.Name_Object.ToLower() == "token_document_type__managed__winword_2007_template") &&
                                     (obj.Ontology == Globals.Type_Object)
                               select obj).ToList();

            if (objOList_Object.Any())
            {
                OItem_Token_Document_Type__managed__Winword_2007_Template = new clsOntologyItem();
                OItem_Token_Document_Type__managed__Winword_2007_Template.GUID = objOList_Object[0].ID_Other;
                OItem_Token_Document_Type__managed__Winword_2007_Template.Name = objOList_Object[0].Name_Other;
                OItem_Token_Document_Type__managed__Winword_2007_Template.GUID_Parent = objOList_Object[0].ID_Parent_Other;
                OItem_Token_Document_Type__managed__Winword_2007_Template.Type = Globals.Type_Object;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Object = (from obj in objDBLevel_Config2.OList_ObjectRel
                               where (obj.Name_Object.ToLower() == "token_document_type__managed__winword_2007_document") &&
                                     (obj.Ontology == Globals.Type_Object)
                               select obj).ToList();

            if (objOList_Object.Any())
            {
                OItem_Token_Document_Type__managed__Winword_2007_Document = new clsOntologyItem();
                OItem_Token_Document_Type__managed__Winword_2007_Document.GUID = objOList_Object[0].ID_Other;
                OItem_Token_Document_Type__managed__Winword_2007_Document.Name = objOList_Object[0].Name_Other;
                OItem_Token_Document_Type__managed__Winword_2007_Document.GUID_Parent = objOList_Object[0].ID_Parent_Other;
                OItem_Token_Document_Type__managed__Winword_2007_Document.Type = Globals.Type_Object;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Object = (from obj in objDBLevel_Config2.OList_ObjectRel
                               where (obj.Name_Object.ToLower() == "token_contenttype_templatefield") &&
                                     (obj.Ontology == Globals.Type_Object)
                               select obj).ToList();

            if (objOList_Object.Any())
            {
                OItem_Token_ContentType_Templatefield = new clsOntologyItem();
                OItem_Token_ContentType_Templatefield.GUID = objOList_Object[0].ID_Other;
                OItem_Token_ContentType_Templatefield.Name = objOList_Object[0].Name_Other;
                OItem_Token_ContentType_Templatefield.GUID_Parent = objOList_Object[0].ID_Parent_Other;
                OItem_Token_ContentType_Templatefield.Type = Globals.Type_Object;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Object = (from obj in objDBLevel_Config2.OList_ObjectRel
                               where (obj.Name_Object.ToLower() == "token_contenttype_name") &&
                                     (obj.Ontology == Globals.Type_Object)
                               select obj).ToList();

            if (objOList_Object.Any())
            {
                OItem_Token_ContentType_Name = new clsOntologyItem();
                OItem_Token_ContentType_Name.GUID = objOList_Object[0].ID_Other;
                OItem_Token_ContentType_Name.Name = objOList_Object[0].Name_Other;
                OItem_Token_ContentType_Name.GUID_Parent = objOList_Object[0].ID_Parent_Other;
                OItem_Token_ContentType_Name.Type = Globals.Type_Object;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Object = (from obj in objDBLevel_Config2.OList_ObjectRel
                               where (obj.Name_Object.ToLower() == "token_contenttype_link") &&
                                     (obj.Ontology == Globals.Type_Object)
                               select obj).ToList();

            if (objOList_Object.Any())
            {
                OItem_Token_ContentType_Link = new clsOntologyItem();
                OItem_Token_ContentType_Link.GUID = objOList_Object[0].ID_Other;
                OItem_Token_ContentType_Link.Name = objOList_Object[0].Name_Other;
                OItem_Token_ContentType_Link.GUID_Parent = objOList_Object[0].ID_Parent_Other;
                OItem_Token_ContentType_Link.Type = Globals.Type_Object;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Object = (from obj in objDBLevel_Config2.OList_ObjectRel
                               where (obj.Name_Object.ToLower() == "token_contenttype_guid") &&
                                     (obj.Ontology == Globals.Type_Object)
                               select obj).ToList();

            if (objOList_Object.Any())
            {
                OItem_Token_ContentType_GUID = new clsOntologyItem();
                OItem_Token_ContentType_GUID.GUID = objOList_Object[0].ID_Other;
                OItem_Token_ContentType_GUID.Name = objOList_Object[0].Name_Other;
                OItem_Token_ContentType_GUID.GUID_Parent = objOList_Object[0].ID_Parent_Other;
                OItem_Token_ContentType_GUID.Type = Globals.Type_Object;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Object = (from obj in objDBLevel_Config2.OList_ObjectRel
                               where (obj.Name_Object.ToLower() == "token_contenttype_documentlink") &&
                                     (obj.Ontology == Globals.Type_Object)
                               select obj).ToList();

            if (objOList_Object.Any())
            {
                OItem_Token_ContentType_DocumentLink = new clsOntologyItem();
                OItem_Token_ContentType_DocumentLink.GUID = objOList_Object[0].ID_Other;
                OItem_Token_ContentType_DocumentLink.Name = objOList_Object[0].Name_Other;
                OItem_Token_ContentType_DocumentLink.GUID_Parent = objOList_Object[0].ID_Parent_Other;
                OItem_Token_ContentType_DocumentLink.Type = Globals.Type_Object;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Object = (from obj in objDBLevel_Config2.OList_ObjectRel
                               where (obj.Name_Object.ToLower() == "token_contenttype_content") &&
                                     (obj.Ontology == Globals.Type_Object)
                               select obj).ToList();

            if (objOList_Object.Any())
            {
                OItem_Token_ContentType_Content = new clsOntologyItem();
                OItem_Token_ContentType_Content.GUID = objOList_Object[0].ID_Other;
                OItem_Token_ContentType_Content.Name = objOList_Object[0].Name_Other;
                OItem_Token_ContentType_Content.GUID_Parent = objOList_Object[0].ID_Parent_Other;
                OItem_Token_ContentType_Content.Type = Globals.Type_Object;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Object = (from obj in objDBLevel_Config2.OList_ObjectRel
                               where (obj.Name_Object.ToLower() == "token_contenttype_bookmark") &&
                                     (obj.Ontology == Globals.Type_Object)
                               select obj).ToList();

            if (objOList_Object.Any())
            {
                OItem_Token_ContentType_Bookmark = new clsOntologyItem();
                OItem_Token_ContentType_Bookmark.GUID = objOList_Object[0].ID_Other;
                OItem_Token_ContentType_Bookmark.Name = objOList_Object[0].Name_Other;
                OItem_Token_ContentType_Bookmark.GUID_Parent = objOList_Object[0].ID_Parent_Other;
                OItem_Token_ContentType_Bookmark.Type = Globals.Type_Object;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Object = (from obj in objDBLevel_Config2.OList_ObjectRel
                               where (obj.Name_Object.ToLower() == "token_contenttype_batitemlist") &&
                                     (obj.Ontology == Globals.Type_Object)
                               select obj).ToList();

            if (objOList_Object.Any())
            {
                OItem_Token_ContentType_BatItemList = new clsOntologyItem();
                OItem_Token_ContentType_BatItemList.GUID = objOList_Object[0].ID_Other;
                OItem_Token_ContentType_BatItemList.Name = objOList_Object[0].Name_Other;
                OItem_Token_ContentType_BatItemList.GUID_Parent = objOList_Object[0].ID_Parent_Other;
                OItem_Token_ContentType_BatItemList.Type = Globals.Type_Object;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Object = (from obj in objDBLevel_Config2.OList_ObjectRel
                               where (obj.Name_Object.ToLower() == "token_contentformat_mm_yyyy") &&
                                     (obj.Ontology == Globals.Type_Object)
                               select obj).ToList();

            if (objOList_Object.Any())
            {
                OItem_Token_Contentformat_MM_yyyy = new clsOntologyItem();
                OItem_Token_Contentformat_MM_yyyy.GUID = objOList_Object[0].ID_Other;
                OItem_Token_Contentformat_MM_yyyy.Name = objOList_Object[0].Name_Other;
                OItem_Token_Contentformat_MM_yyyy.GUID_Parent = objOList_Object[0].ID_Parent_Other;
                OItem_Token_Contentformat_MM_yyyy.Type = Globals.Type_Object;
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Object = (from obj in objDBLevel_Config2.OList_ObjectRel
                               where (obj.Name_Object.ToLower() == "token_contentformat_dd_mm_yyyy") &&
                                     (obj.Ontology == Globals.Type_Object)
                               select obj).ToList();

            if (objOList_Object.Any())
            {
                OItem_Token_Contentformat_dd_MM_yyyy = new clsOntologyItem();
                OItem_Token_Contentformat_dd_MM_yyyy.GUID = objOList_Object[0].ID_Other;
                OItem_Token_Contentformat_dd_MM_yyyy.Name = objOList_Object[0].Name_Other;
                OItem_Token_Contentformat_dd_MM_yyyy.GUID_Parent = objOList_Object[0].ID_Parent_Other;
                OItem_Token_Contentformat_dd_MM_yyyy.Type = Globals.Type_Object;
            }
            else
            {
                throw new Exception("config err");
            }
        }

        private void get_Config_Classes()
        {
            var objOList_Class = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_word_templates") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_Class.Any())
            {
                OItem_Type_Word_Templates = new clsOntologyItem()
                {
                    GUID = objOList_Class[0].ID_Other,
                    Name = objOList_Class[0].Name_Other,
                    GUID_Parent = objOList_Class[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Class = (from obj in objDBLevel_Config2.OList_ObjectRel
                              where (obj.Name_Object.ToLower() == "type_word_management") &&
                                    (obj.Ontology == Globals.Type_Class)
                              select obj).ToList();

            if (objOList_Class.Any())
            {
                OItem_Type_Word_Management = new clsOntologyItem()
                {
                    GUID = objOList_Class[0].ID_Other,
                    Name = objOList_Class[0].Name_Other,
                    GUID_Parent = objOList_Class[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Class = (from obj in objDBLevel_Config2.OList_ObjectRel
                              where (obj.Name_Object.ToLower() == "type_templatefield") &&
                                    (obj.Ontology == Globals.Type_Class)
                              select obj).ToList();

            if (objOList_Class.Any())
            {
                OItem_Type_Templatefield = new clsOntologyItem()
                {
                    GUID = objOList_Class[0].ID_Other,
                    Name = objOList_Class[0].Name_Other,
                    GUID_Parent = objOList_Class[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Class = (from obj in objDBLevel_Config2.OList_ObjectRel
                              where (obj.Name_Object.ToLower() == "type_office_module") &&
                                    (obj.Ontology == Globals.Type_Class)
                              select obj).ToList();

            if (objOList_Class.Any())
            {
                OItem_Type_Office_Module = new clsOntologyItem()
                {
                    GUID = objOList_Class[0].ID_Other,
                    Name = objOList_Class[0].Name_Other,
                    GUID_Parent = objOList_Class[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Class = (from obj in objDBLevel_Config2.OList_ObjectRel
                              where (obj.Name_Object.ToLower() == "type_module") &&
                                    (obj.Ontology == Globals.Type_Class)
                              select obj).ToList();

            if (objOList_Class.Any())
            {
                OItem_Type_Module = new clsOntologyItem()
                {
                    GUID = objOList_Class[0].ID_Other,
                    Name = objOList_Class[0].Name_Other,
                    GUID_Parent = objOList_Class[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Class = (from obj in objDBLevel_Config2.OList_ObjectRel
                              where (obj.Name_Object.ToLower() == "type_managed_document") &&
                                    (obj.Ontology == Globals.Type_Class)
                              select obj).ToList();

            if (objOList_Class.Any())
            {
                OItem_Type_Managed_Document = new clsOntologyItem()
                {
                    GUID = objOList_Class[0].ID_Other,
                    Name = objOList_Class[0].Name_Other,
                    GUID_Parent = objOList_Class[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Class = (from obj in objDBLevel_Config2.OList_ObjectRel
                              where (obj.Name_Object.ToLower() == "type_folder") &&
                                    (obj.Ontology == Globals.Type_Class)
                              select obj).ToList();

            if (objOList_Class.Any())
            {
                OItem_type_Folder = new clsOntologyItem()
                {
                    GUID = objOList_Class[0].ID_Other,
                    Name = objOList_Class[0].Name_Other,
                    GUID_Parent = objOList_Class[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Class = (from obj in objDBLevel_Config2.OList_ObjectRel
                              where (obj.Name_Object.ToLower() == "type_file") &&
                                    (obj.Ontology == Globals.Type_Class)
                              select obj).ToList();

            if (objOList_Class.Any())
            {
                OItem_Type_File = new clsOntologyItem()
                {
                    GUID = objOList_Class[0].ID_Other,
                    Name = objOList_Class[0].Name_Other,
                    GUID_Parent = objOList_Class[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Class = (from obj in objDBLevel_Config2.OList_ObjectRel
                              where (obj.Name_Object.ToLower() == "type_extensions") &&
                                    (obj.Ontology == Globals.Type_Class)
                              select obj).ToList();

            if (objOList_Class.Any())
            {
                OItem_Type_Extensions = new clsOntologyItem()
                {
                    GUID = objOList_Class[0].ID_Other,
                    Name = objOList_Class[0].Name_Other,
                    GUID_Parent = objOList_Class[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Class = (from obj in objDBLevel_Config2.OList_ObjectRel
                              where (obj.Name_Object.ToLower() == "type_document_type__managed_") &&
                                    (obj.Ontology == Globals.Type_Class)
                              select obj).ToList();

            if (objOList_Class.Any())
            {
                OItem_Type_Document_Type__managed_ = new clsOntologyItem()
                {
                    GUID = objOList_Class[0].ID_Other,
                    Name = objOList_Class[0].Name_Other,
                    GUID_Parent = objOList_Class[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Class = (from obj in objDBLevel_Config2.OList_ObjectRel
                              where (obj.Name_Object.ToLower() == "type_contenttype") &&
                                    (obj.Ontology == Globals.Type_Class)
                              select obj).ToList();

            if (objOList_Class.Any())
            {
                OItem_Type_ContentType = new clsOntologyItem()
                {
                    GUID = objOList_Class[0].ID_Other,
                    Name = objOList_Class[0].Name_Other,
                    GUID_Parent = objOList_Class[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Class = (from obj in objDBLevel_Config2.OList_ObjectRel
                              where (obj.Name_Object.ToLower() == "type_contentobject") &&
                                    (obj.Ontology == Globals.Type_Class)
                              select obj).ToList();

            if (objOList_Class.Any())
            {
                OItem_Type_ContentObject = new clsOntologyItem()
                {
                    GUID = objOList_Class[0].ID_Other,
                    Name = objOList_Class[0].Name_Other,
                    GUID_Parent = objOList_Class[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            objOList_Class = (from obj in objDBLevel_Config2.OList_ObjectRel
                              where (obj.Name_Object.ToLower() == "type_contentformat") &&
                                    (obj.Ontology == Globals.Type_Class)
                              select obj).ToList();

            if (objOList_Class.Any())
            {
                OItem_Type_Contentformat = new clsOntologyItem()
                {
                    GUID = objOList_Class[0].ID_Other,
                    Name = objOList_Class[0].Name_Other,
                    GUID_Parent = objOList_Class[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }
        }

        public clsLocalConfig()
        {
            Globals = new clsGlobals();
            set_DBConnection();
            get_Config();
        }
	
    }

}
