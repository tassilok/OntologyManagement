using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace Document_Module
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "7fb9fa7910d0400995dd7e1e972f788e";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;

        // Attributetypes
        public clsOntologyItem OItem_attributetype_datetimestamp__create_ { get; set; }

        // Classes
	public clsOntologyItem OItem_class_development_version { get; set; }
public clsOntologyItem OItem_class_document { get; set; }
public clsOntologyItem OItem_class_bookmark__document_ { get; set; }
public clsOntologyItem OItem_class_container__physical_ { get; set; }
public clsOntologyItem OItem_class_file { get; set; }
public clsOntologyItem OItem_class_partner { get; set; }

        // RelationType
public clsOntologyItem OItem_relationtype_belonging_source { get; set; }
public clsOntologyItem OItem_relationtype_contains { get; set; }
public clsOntologyItem OItem_relationtype_belonging_copy { get; set; }
public clsOntologyItem OItem_relationtype_autor { get; set; }

  
	
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

                    objORL_Ontology_To_OntolgyItems = objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel {ID_Object = oi.ID_Other,
                                                                                                                                ID_RelationType = Globals.RelationType_belongingAttribute.GUID}).ToList();

                    objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel {ID_Object = oi.ID_Other,
                                                                                                                                    ID_RelationType = Globals.RelationType_belongingClass.GUID}));
                    objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel {ID_Object = oi.ID_Other,
                                                                                                                                    ID_RelationType = Globals.RelationType_belongingObject.GUID}));
                    objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel
                    {
                        ID_Object = oi.ID_Other,
                        ID_RelationType = Globals.RelationType_belongingRelationType.GUID
                    }));

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
            var objOList_attributetype_datetimestamp__create_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                                 where objOItem.ID_Object == cstrID_Ontology
                                                                 join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                                 where objRef.Name_Object.ToLower() == "attributetype_datetimestamp__create_".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                                 select objRef).ToList();

            if (objOList_attributetype_datetimestamp__create_.Any())
            {
                OItem_attributetype_datetimestamp__create_ = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_datetimestamp__create_.First().ID_Other,
                    Name = objOList_attributetype_datetimestamp__create_.First().Name_Other,
                    GUID_Parent = objOList_attributetype_datetimestamp__create_.First().ID_Parent_Other,
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
        var objOList_relationtype_autor = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_autor".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

        if (objOList_relationtype_autor.Any())
        {
            OItem_relationtype_autor = new clsOntologyItem()
            {
                GUID = objOList_relationtype_autor.First().ID_Other,
                Name = objOList_relationtype_autor.First().Name_Other,
                GUID_Parent = objOList_relationtype_autor.First().ID_Parent_Other,
                Type = Globals.Type_RelationType
            };
        }
        else
        {
            throw new Exception("config err");
        }


        var objOList_relationtype_belonging_copy = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    where objOItem.ID_Object == cstrID_Ontology
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "relationtype_belonging_copy".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                    select objRef).ToList();

        if (objOList_relationtype_belonging_copy.Any())
        {
            OItem_relationtype_belonging_copy = new clsOntologyItem()
            {
                GUID = objOList_relationtype_belonging_copy.First().ID_Other,
                Name = objOList_relationtype_belonging_copy.First().Name_Other,
                GUID_Parent = objOList_relationtype_belonging_copy.First().ID_Parent_Other,
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

        var objOList_relationtype_belonging_source = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      where objOItem.ID_Object == cstrID_Ontology
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "relationtype_belonging_source".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                      select objRef).ToList();

        if (objOList_relationtype_belonging_source.Any())
        {
            OItem_relationtype_belonging_source = new clsOntologyItem()
            {
                GUID = objOList_relationtype_belonging_source.First().ID_Other,
                Name = objOList_relationtype_belonging_source.First().Name_Other,
                GUID_Parent = objOList_relationtype_belonging_source.First().ID_Parent_Other,
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
		
	}
  
	private void get_Config_Classes()
        {
            var objOList_class_partner = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                          where objOItem.ID_Object == cstrID_Ontology
                                          join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                          where objRef.Name_Object.ToLower() == "class_partner".ToLower() && objRef.Ontology == Globals.Type_Class
                                          select objRef).ToList();

            if (objOList_class_partner.Any())
            {
                OItem_class_partner = new clsOntologyItem()
                {
                    GUID = objOList_class_partner.First().ID_Other,
                    Name = objOList_class_partner.First().Name_Other,
                    GUID_Parent = objOList_class_partner.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_file = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                       where objOItem.ID_Object == cstrID_Ontology
                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                       where objRef.Name_Object.ToLower() == "class_file".ToLower() && objRef.Ontology == Globals.Type_Class
                                       select objRef).ToList();

            if (objOList_class_file.Any())
            {
                OItem_class_file = new clsOntologyItem()
                {
                    GUID = objOList_class_file.First().ID_Other,
                    Name = objOList_class_file.First().Name_Other,
                    GUID_Parent = objOList_class_file.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_container__physical_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                       where objOItem.ID_Object == cstrID_Ontology
                                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                       where objRef.Name_Object.ToLower() == "class_container__physical_".ToLower() && objRef.Ontology == Globals.Type_Class
                                                       select objRef).ToList();

            if (objOList_class_container__physical_.Any())
            {
                OItem_class_container__physical_ = new clsOntologyItem()
                {
                    GUID = objOList_class_container__physical_.First().ID_Other,
                    Name = objOList_class_container__physical_.First().Name_Other,
                    GUID_Parent = objOList_class_container__physical_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_bookmark__document_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      where objOItem.ID_Object == cstrID_Ontology
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "class_bookmark__document_".ToLower() && objRef.Ontology == Globals.Type_Class
                                                      select objRef).ToList();

            if (objOList_class_bookmark__document_.Any())
            {
                OItem_class_bookmark__document_ = new clsOntologyItem()
                {
                    GUID = objOList_class_bookmark__document_.First().ID_Other,
                    Name = objOList_class_bookmark__document_.First().Name_Other,
                    GUID_Parent = objOList_class_bookmark__document_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

		var objOList_class_development_version = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_development_version".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_development_version.Any())
            {
                OItem_class_development_version = new clsOntologyItem()
                {
                    GUID = objOList_class_development_version.First().ID_Other,
                    Name = objOList_class_development_version.First().Name_Other,
                    GUID_Parent = objOList_class_development_version.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_document = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_document".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_document.Any())
            {
                OItem_class_document = new clsOntologyItem()
                {
                    GUID = objOList_class_document.First().ID_Other,
                    Name = objOList_class_document.First().Name_Other,
                    GUID_Parent = objOList_class_document.First().ID_Parent_Other,
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