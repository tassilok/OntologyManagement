using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace ImageList_Module
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "7ef8f649517f471597f4bbdb8a81f914";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;

        // AttributeTypes 
        public clsOntologyItem OItem_attributetype_is_root { get; set; }

        // Classes
	public clsOntologyItem OItem_class_image_lists { get; set; }
public clsOntologyItem OItem_class_images__image_lists_ { get; set; }
public clsOntologyItem OItem_class_kindofontology { get; set; }

        // RelationTypes
public clsOntologyItem OItem_relationtype_contains { get; set; }
public clsOntologyItem OItem_relationtype_reference_to { get; set; }
public clsOntologyItem OItem_relationtype_belonging_resource { get; set; }

        // Objects
public clsOntologyItem OItem_object_relationtype { get; set; }
public clsOntologyItem OItem_object_opened___itemref { get; set; }
public clsOntologyItem OItem_object_opened { get; set; }
public clsOntologyItem OItem_object_object { get; set; }
public clsOntologyItem OItem_object_closed___itemref { get; set; }
public clsOntologyItem OItem_object_closed { get; set; }
public clsOntologyItem OItem_object_class { get; set; }
public clsOntologyItem OItem_object_attribute { get; set; }


  
	
private void get_Data_DevelopmentConfig()
        {
            var objORL_Ontology_To_OntolgyItems = new List<clsObjectRel> {new clsObjectRel {ID_Object = cstrID_Ontology, 
                                                                                             ID_RelationType = Globals.RelationType_contains.GUID, 
                                                                                             ID_Parent_Other = Globals.Class_OntologyItems.GUID}};

            var objOItem_Result = objDBLevel_Config1.get_Data_ObjectRel(objORL_Ontology_To_OntolgyItems, boolIDs:false);
            if (objOItem_Result.GUID == Globals.LState_Success.GUID)
            {
                if (objDBLevel_Config1.OList_ObjectRel.Any())
                {

                    objORL_Ontology_To_OntolgyItems = new List<clsObjectRel> {new clsObjectRel {ID_Parent_Object = Globals.Class_OntologyItems.GUID, 
                                                                                                         ID_RelationType = Globals.RelationType_belongingAttribute.GUID},
                                                                                  new clsObjectRel {ID_Parent_Object = Globals.Class_OntologyItems.GUID, 
                                                                                                         ID_RelationType = Globals.RelationType_belongingClass.GUID},
                                                                                 new clsObjectRel {ID_Parent_Object = Globals.Class_OntologyItems.GUID, 
                                                                                                         ID_RelationType = Globals.RelationType_belongingObject.GUID},
                                                                                  new clsObjectRel {ID_Parent_Object = Globals.Class_OntologyItems.GUID, 
                                                                                                         ID_RelationType = Globals.RelationType_belongingRelationType.GUID}};

                    objOItem_Result = objDBLevel_Config2.get_Data_ObjectRel(objORL_Ontology_To_OntolgyItems, boolIDs:false);
                    if (objOItem_Result.GUID == Globals.LState_Success.GUID)
                    {
                        if (!objDBLevel_Config2.OList_ObjectRel.Any())
                        {
                            throw new Exception("Config-Error");
                        }
                    }   
                    else
                    {
                        throw new Exception("Config-Error");
                    }
                }
                else
                {
                    throw new Exception("Config-Error");
                }

            }

        }
  
	public clsLocalConfig()
        {
            Globals = new clsGlobals();
            set_DBConnection();
            get_Config();
        }

        public clsLocalConfig(clsGlobals Globals)
        {
            this.Globals = Globals;
            set_DBConnection();
            get_Config();
        }
  
	private void set_DBConnection()
        {
		    objDBLevel_Config1 = new clsDBLevel(Globals);
		    objDBLevel_Config2 = new clsDBLevel(Globals);
			objImport = new clsImport(Globals);
        }
  
	private void get_Config()
        {
            try
            {
                get_Data_DevelopmentConfig();
                get_Config_AttributeTypes();
                get_Config_RelationTypes();
                get_Config_Classes();
                get_Config_Objects();
            }
            catch(Exception ex)
            {
                var objAssembly = Assembly.GetExecutingAssembly();
                AssemblyTitleAttribute[] objCustomAttributes = (AssemblyTitleAttribute[]) objAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                var strTitle = "Unbekannt";
                if (objCustomAttributes.Length == 1) 
                {
                    strTitle = objCustomAttributes.First().Title;
                }
                if (MessageBox.Show(strTitle + ": Die notwendigen Basisdaten konnten nicht geladen werden! Soll versucht werden, sie in der Datenbank " +
                          Globals.Index + "@" + Globals.Server + " zu erzeugen?", "Datenstrukturen",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var objOItem_Result = objImport.ImportTemplates(objAssembly);
                    if (objOItem_Result.GUID != Globals.LState_Error.GUID)
                    {
                        get_Data_DevelopmentConfig();
                        get_Config_AttributeTypes();
                        get_Config_RelationTypes();
                        get_Config_Classes();
                        get_Config_Objects();
                    }
                    else
                    {
                        throw new Exception("Config not importable");
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
  
	private void get_Config_AttributeTypes()
        {
            var objOList_attributetype_is_root = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                  where objOItem.ID_Object == cstrID_Ontology
                                                  join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                  where objRef.Name_Object.ToLower() == "attributetype_is_root".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                  select objRef).ToList();

            if (objOList_attributetype_is_root.Any())
            {
                OItem_attributetype_is_root = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_is_root.First().ID_Other,
                    Name = objOList_attributetype_is_root.First().Name_Other,
                    GUID_Parent = objOList_attributetype_is_root.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }
	}
  
	private void get_Config_RelationTypes()
        {
            var objOList_relationtype_reference_to = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      where objOItem.ID_Object == cstrID_Ontology
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "relationtype_reference_to".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                      select objRef).ToList();

            if (objOList_relationtype_reference_to.Any())
            {
                OItem_relationtype_reference_to = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_reference_to.First().ID_Other,
                    Name = objOList_relationtype_reference_to.First().Name_Other,
                    GUID_Parent = objOList_relationtype_reference_to.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_belonging_resource = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                            where objOItem.ID_Object == cstrID_Ontology
                                                            join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                            where objRef.Name_Object.ToLower() == "relationtype_belonging_resource".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                            select objRef).ToList();

            if (objOList_relationtype_belonging_resource.Any())
            {
                OItem_relationtype_belonging_resource = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_resource.First().ID_Other,
                    Name = objOList_relationtype_belonging_resource.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_resource.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

		var objOList_relationtype_contains = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_contains".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_contains.Any())
            {
                OItem_relationtype_contains = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_contains.First().ID_Other,
                    Name = objOList_relationtype_contains.First().Name_Other,
                    GUID_Parent = objOList_relationtype_contains.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }


	}
  
	private void get_Config_Objects()
        {
            var objOList_object_relationtype = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                where objOItem.ID_Object == cstrID_Ontology
                                                join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                where objRef.Name_Object.ToLower() == "object_relationtype".ToLower() && objRef.Ontology == Globals.Type_Object
                                                select objRef).ToList();

            if (objOList_object_relationtype.Any())
            {
                OItem_object_relationtype = new clsOntologyItem()
                {
                    GUID = objOList_object_relationtype.First().ID_Other,
                    Name = objOList_object_relationtype.First().Name_Other,
                    GUID_Parent = objOList_object_relationtype.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_opened___itemref = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    where objOItem.ID_Object == cstrID_Ontology
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "object_opened___itemref".ToLower() && objRef.Ontology == Globals.Type_Object
                                                    select objRef).ToList();

            if (objOList_object_opened___itemref.Any())
            {
                OItem_object_opened___itemref = new clsOntologyItem()
                {
                    GUID = objOList_object_opened___itemref.First().ID_Other,
                    Name = objOList_object_opened___itemref.First().Name_Other,
                    GUID_Parent = objOList_object_opened___itemref.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_opened = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                          where objOItem.ID_Object == cstrID_Ontology
                                          join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                          where objRef.Name_Object.ToLower() == "object_opened".ToLower() && objRef.Ontology == Globals.Type_Object
                                          select objRef).ToList();

            if (objOList_object_opened.Any())
            {
                OItem_object_opened = new clsOntologyItem()
                {
                    GUID = objOList_object_opened.First().ID_Other,
                    Name = objOList_object_opened.First().Name_Other,
                    GUID_Parent = objOList_object_opened.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_object = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                          where objOItem.ID_Object == cstrID_Ontology
                                          join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                          where objRef.Name_Object.ToLower() == "object_object".ToLower() && objRef.Ontology == Globals.Type_Object
                                          select objRef).ToList();

            if (objOList_object_object.Any())
            {
                OItem_object_object = new clsOntologyItem()
                {
                    GUID = objOList_object_object.First().ID_Other,
                    Name = objOList_object_object.First().Name_Other,
                    GUID_Parent = objOList_object_object.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_closed___itemref = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    where objOItem.ID_Object == cstrID_Ontology
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "object_closed___itemref".ToLower() && objRef.Ontology == Globals.Type_Object
                                                    select objRef).ToList();

            if (objOList_object_closed___itemref.Any())
            {
                OItem_object_closed___itemref = new clsOntologyItem()
                {
                    GUID = objOList_object_closed___itemref.First().ID_Other,
                    Name = objOList_object_closed___itemref.First().Name_Other,
                    GUID_Parent = objOList_object_closed___itemref.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_closed = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                          where objOItem.ID_Object == cstrID_Ontology
                                          join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                          where objRef.Name_Object.ToLower() == "object_closed".ToLower() && objRef.Ontology == Globals.Type_Object
                                          select objRef).ToList();

            if (objOList_object_closed.Any())
            {
                OItem_object_closed = new clsOntologyItem()
                {
                    GUID = objOList_object_closed.First().ID_Other,
                    Name = objOList_object_closed.First().Name_Other,
                    GUID_Parent = objOList_object_closed.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_class = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                         where objOItem.ID_Object == cstrID_Ontology
                                         join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                         where objRef.Name_Object.ToLower() == "object_class".ToLower() && objRef.Ontology == Globals.Type_Object
                                         select objRef).ToList();

            if (objOList_object_class.Any())
            {
                OItem_object_class = new clsOntologyItem()
                {
                    GUID = objOList_object_class.First().ID_Other,
                    Name = objOList_object_class.First().Name_Other,
                    GUID_Parent = objOList_object_class.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_attribute = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                             where objOItem.ID_Object == cstrID_Ontology
                                             join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                             where objRef.Name_Object.ToLower() == "object_attribute".ToLower() && objRef.Ontology == Globals.Type_Object
                                             select objRef).ToList();

            if (objOList_object_attribute.Any())
            {
                OItem_object_attribute = new clsOntologyItem()
                {
                    GUID = objOList_object_attribute.First().ID_Other,
                    Name = objOList_object_attribute.First().Name_Other,
                    GUID_Parent = objOList_object_attribute.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }
	}
  
	private void get_Config_Classes()
        {
            var objOList_class_kindofontology = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                 where objOItem.ID_Object == cstrID_Ontology
                                                 join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                 where objRef.Name_Object.ToLower() == "class_kindofontology".ToLower() && objRef.Ontology == Globals.Type_Class
                                                 select objRef).ToList();

            if (objOList_class_kindofontology.Any())
            {
                OItem_class_kindofontology = new clsOntologyItem()
                {
                    GUID = objOList_class_kindofontology.First().ID_Other,
                    Name = objOList_class_kindofontology.First().Name_Other,
                    GUID_Parent = objOList_class_kindofontology.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

		var objOList_class_image_lists = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_image_lists".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_image_lists.Any())
            {
                OItem_class_image_lists = new clsOntologyItem()
                {
                    GUID = objOList_class_image_lists.First().ID_Other,
                    Name = objOList_class_image_lists.First().Name_Other,
                    GUID_Parent = objOList_class_image_lists.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_images__image_lists_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_images__image_lists_".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_images__image_lists_.Any())
            {
                OItem_class_images__image_lists_ = new clsOntologyItem()
                {
                    GUID = objOList_class_images__image_lists_.First().ID_Other,
                    Name = objOList_class_images__image_lists_.First().Name_Other,
                    GUID_Parent = objOList_class_images__image_lists_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }


	}
    }

}