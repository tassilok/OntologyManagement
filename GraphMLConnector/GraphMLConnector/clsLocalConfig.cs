using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace GraphMLConnector
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "a2b1b74c1a7941b1944511a4c4341520";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;

        //AttributeTypes
        public clsOntologyItem OItem_attributetype_xml_text { get; set; }

        //RelationTypes
        public clsOntologyItem OItem_relationtype_contains { get; set; }
        public clsOntologyItem OItem_relationtype_belonging_sem_item { get; set; }
        public clsOntologyItem OItem_relationtype_export_to { get; set; }
        public clsOntologyItem OItem_relationtype_is_of_type { get; set; }

        //Objects
        public clsOntologyItem OItem_object_color_text { get; set; }
        public clsOntologyItem OItem_object_normal { get; set; }
        public clsOntologyItem OItem_object_graphml___uml_class_node { get; set; }
        public clsOntologyItem OItem_object_graphml___uml_edge { get; set; }
        public clsOntologyItem OItem_object_id_right { get; set; }
        public clsOntologyItem OItem_object_color_fill { get; set; }
        public clsOntologyItem OItem_object_edge_list { get; set; }
        public clsOntologyItem OItem_object_grant_children_of_item { get; set; }
        public clsOntologyItem OItem_object_name_relationtype { get; set; }
        public clsOntologyItem OItem_object_id_left { get; set; }
        public clsOntologyItem OItem_object_graphml___container { get; set; }
        public clsOntologyItem OItem_object_name_node { get; set; }
        public clsOntologyItem OItem_object_id { get; set; }
        public clsOntologyItem OItem_object_attrib_list { get; set; }
        public clsOntologyItem OItem_object_node_list { get; set; }

        //Klasses
        public clsOntologyItem OItem_class_path { get; set; }
        public clsOntologyItem OItem_class_export_mode { get; set; }
        public clsOntologyItem OItem_class_graphitem { get; set; }
        public clsOntologyItem OItem_class_graphs { get; set; }
        
        

  
	
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
		var objOList_attributetype_xml_text = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attributetype_xml_text".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attributetype_xml_text.Any())
            {
                OItem_attributetype_xml_text = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_xml_text.First().ID_Other,
                    Name = objOList_attributetype_xml_text.First().Name_Other,
                    GUID_Parent = objOList_attributetype_xml_text.First().ID_Parent_Other,
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
		var objOList_relationtype_export_to = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_export_to".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_export_to.Any())
            {
                OItem_relationtype_export_to = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_export_to.First().ID_Other,
                    Name = objOList_relationtype_export_to.First().Name_Other,
                    GUID_Parent = objOList_relationtype_export_to.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_is_of_type = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_is_of_type".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_is_of_type.Any())
            {
                OItem_relationtype_is_of_type = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_is_of_type.First().ID_Other,
                    Name = objOList_relationtype_is_of_type.First().Name_Other,
                    GUID_Parent = objOList_relationtype_is_of_type.First().ID_Parent_Other,
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

var objOList_relationtype_belonging_sem_item = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_belonging_sem_item".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_belonging_sem_item.Any())
            {
                OItem_relationtype_belonging_sem_item = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_sem_item.First().ID_Other,
                    Name = objOList_relationtype_belonging_sem_item.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_sem_item.First().ID_Parent_Other,
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

        var objOList_object_name_relationtype = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_name_relationtype".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_name_relationtype.Any())
            {
                OItem_object_name_relationtype = new clsOntologyItem()
                {
                    GUID = objOList_object_name_relationtype.First().ID_Other,
                    Name = objOList_object_name_relationtype.First().Name_Other,
                    GUID_Parent = objOList_object_name_relationtype.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

		var objOList_object_color_text = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_color_text".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_color_text.Any())
            {
                OItem_object_color_text = new clsOntologyItem()
                {
                    GUID = objOList_object_color_text.First().ID_Other,
                    Name = objOList_object_color_text.First().Name_Other,
                    GUID_Parent = objOList_object_color_text.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_object_graphml___uml_edge = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_graphml___uml_edge".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_graphml___uml_edge.Any())
            {
                OItem_object_graphml___uml_edge = new clsOntologyItem()
                {
                    GUID = objOList_object_graphml___uml_edge.First().ID_Other,
                    Name = objOList_object_graphml___uml_edge.First().Name_Other,
                    GUID_Parent = objOList_object_graphml___uml_edge.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_object_edge_list = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_edge_list".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_edge_list.Any())
            {
                OItem_object_edge_list = new clsOntologyItem()
                {
                    GUID = objOList_object_edge_list.First().ID_Other,
                    Name = objOList_object_edge_list.First().Name_Other,
                    GUID_Parent = objOList_object_edge_list.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_object_id_right = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_id_right".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_id_right.Any())
            {
                OItem_object_id_right = new clsOntologyItem()
                {
                    GUID = objOList_object_id_right.First().ID_Other,
                    Name = objOList_object_id_right.First().Name_Other,
                    GUID_Parent = objOList_object_id_right.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_object_color_fill = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_color_fill".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_color_fill.Any())
            {
                OItem_object_color_fill = new clsOntologyItem()
                {
                    GUID = objOList_object_color_fill.First().ID_Other,
                    Name = objOList_object_color_fill.First().Name_Other,
                    GUID_Parent = objOList_object_color_fill.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_object_grant_children_of_item = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_grant_children_of_item".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_grant_children_of_item.Any())
            {
                OItem_object_grant_children_of_item = new clsOntologyItem()
                {
                    GUID = objOList_object_grant_children_of_item.First().ID_Other,
                    Name = objOList_object_grant_children_of_item.First().Name_Other,
                    GUID_Parent = objOList_object_grant_children_of_item.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }


var objOList_object_id_left = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_id_left".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_id_left.Any())
            {
                OItem_object_id_left = new clsOntologyItem()
                {
                    GUID = objOList_object_id_left.First().ID_Other,
                    Name = objOList_object_id_left.First().Name_Other,
                    GUID_Parent = objOList_object_id_left.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_object_normal = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_normal".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_normal.Any())
            {
                OItem_object_normal = new clsOntologyItem()
                {
                    GUID = objOList_object_normal.First().ID_Other,
                    Name = objOList_object_normal.First().Name_Other,
                    GUID_Parent = objOList_object_normal.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_object_graphml___uml_class_node = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_graphml___uml_class_node".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_graphml___uml_class_node.Any())
            {
                OItem_object_graphml___uml_class_node = new clsOntologyItem()
                {
                    GUID = objOList_object_graphml___uml_class_node.First().ID_Other,
                    Name = objOList_object_graphml___uml_class_node.First().Name_Other,
                    GUID_Parent = objOList_object_graphml___uml_class_node.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_object_graphml___container = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_graphml___container".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_graphml___container.Any())
            {
                OItem_object_graphml___container = new clsOntologyItem()
                {
                    GUID = objOList_object_graphml___container.First().ID_Other,
                    Name = objOList_object_graphml___container.First().Name_Other,
                    GUID_Parent = objOList_object_graphml___container.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_object_name_node = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_name_node".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_name_node.Any())
            {
                OItem_object_name_node = new clsOntologyItem()
                {
                    GUID = objOList_object_name_node.First().ID_Other,
                    Name = objOList_object_name_node.First().Name_Other,
                    GUID_Parent = objOList_object_name_node.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_object_id = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_id".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_id.Any())
            {
                OItem_object_id = new clsOntologyItem()
                {
                    GUID = objOList_object_id.First().ID_Other,
                    Name = objOList_object_id.First().Name_Other,
                    GUID_Parent = objOList_object_id.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_object_attrib_list = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_attrib_list".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_attrib_list.Any())
            {
                OItem_object_attrib_list = new clsOntologyItem()
                {
                    GUID = objOList_object_attrib_list.First().ID_Other,
                    Name = objOList_object_attrib_list.First().Name_Other,
                    GUID_Parent = objOList_object_attrib_list.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_object_node_list = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_node_list".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_node_list.Any())
            {
                OItem_object_node_list = new clsOntologyItem()
                {
                    GUID = objOList_object_node_list.First().ID_Other,
                    Name = objOList_object_node_list.First().Name_Other,
                    GUID_Parent = objOList_object_node_list.First().ID_Parent_Other,
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
		var objOList_class_export_mode = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_export_mode".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_export_mode.Any())
            {
                OItem_class_export_mode = new clsOntologyItem()
                {
                    GUID = objOList_class_export_mode.First().ID_Other,
                    Name = objOList_class_export_mode.First().Name_Other,
                    GUID_Parent = objOList_class_export_mode.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_graphs = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_graphs".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_graphs.Any())
            {
                OItem_class_graphs = new clsOntologyItem()
                {
                    GUID = objOList_class_graphs.First().ID_Other,
                    Name = objOList_class_graphs.First().Name_Other,
                    GUID_Parent = objOList_class_graphs.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_graphitem = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_graphitem".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_graphitem.Any())
            {
                OItem_class_graphitem = new clsOntologyItem()
                {
                    GUID = objOList_class_graphitem.First().ID_Other,
                    Name = objOList_class_graphitem.First().Name_Other,
                    GUID_Parent = objOList_class_graphitem.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_path = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_path".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_path.Any())
            {
                OItem_class_path = new clsOntologyItem()
                {
                    GUID = objOList_class_path.First().ID_Other,
                    Name = objOList_class_path.First().Name_Other,
                    GUID_Parent = objOList_class_path.First().ID_Parent_Other,
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