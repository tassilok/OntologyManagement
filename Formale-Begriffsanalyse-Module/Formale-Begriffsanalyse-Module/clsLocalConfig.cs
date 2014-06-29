using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace Formale_Begriffsanalyse_Module
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "6286eb04e75c4d1485bd0828618e72f5";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;

        // Classes
        public clsOntologyItem OItem_class_mengen { get; set; }
        public clsOntologyItem OItem_class_mengentyp { get; set; }
        public clsOntologyItem OItem_class_mengen_element { get; set; }
        public clsOntologyItem OItem_class_bin_re_relation__typ_ { get; set; }

        // RelationTypes
        public clsOntologyItem OItem_relationtype_contains { get; set; }
        public clsOntologyItem OItem_relationtype_is_of_type { get; set; }
        



        private void get_Data_DevelopmentConfig()
        {
            var objORL_Ontology_To_OntolgyItems = new List<clsObjectRel> {new clsObjectRel {ID_Object = cstrID_Ontology, 
                                                                                             ID_RelationType = Globals.RelationType_contains.GUID, 
                                                                                             ID_Parent_Other = Globals.Class_OntologyItems.GUID}};

            var objOItem_Result = objDBLevel_Config1.get_Data_ObjectRel(objORL_Ontology_To_OntolgyItems, boolIDs: false);
            if (objOItem_Result.GUID == Globals.LState_Success.GUID)
            {
                if (objDBLevel_Config1.OList_ObjectRel.Any())
                {

                    objORL_Ontology_To_OntolgyItems = objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel
                    {
                        ID_Object = oi.ID_Other,
                        ID_RelationType = Globals.RelationType_belongingAttribute.GUID
                    }).ToList();

                    objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel
                    {
                        ID_Object = oi.ID_Other,
                        ID_RelationType = Globals.RelationType_belongingClass.GUID
                    }));
                    objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel
                    {
                        ID_Object = oi.ID_Other,
                        ID_RelationType = Globals.RelationType_belongingObject.GUID
                    }));
                    objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel
                    {
                        ID_Object = oi.ID_Other,
                        ID_RelationType = Globals.RelationType_belongingRelationType.GUID
                    }));

                    objOItem_Result = objDBLevel_Config2.get_Data_ObjectRel(objORL_Ontology_To_OntolgyItems, boolIDs: false);
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
            catch (Exception ex)
            {
                var objAssembly = Assembly.GetExecutingAssembly();
                AssemblyTitleAttribute[] objCustomAttributes = (AssemblyTitleAttribute[])objAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                var strTitle = "Unbekannt";
                if (objCustomAttributes.Length == 1)
                {
                    strTitle = objCustomAttributes.First().Title;
                }
                if (MessageBox.Show(strTitle + ": Die notwendigen Basisdaten konnten nicht geladen werden! Soll versucht werden, sie in der Datenbank " +
                          Globals.Index + "@" + Globals.Server + " zu erzeugen?", "Datenstrukturen", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

        }

        private void get_Config_RelationTypes()
        {
            var objOList_class_bin_re_relation__typ_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                        where objOItem.ID_Object == cstrID_Ontology
                                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                        where objRef.Name_Object.ToLower() == "class_bin_re_relation__typ_".ToLower() && objRef.Ontology == Globals.Type_Class
                                                        select objRef).ToList();

            if (objOList_class_bin_re_relation__typ_.Any())
            {
                OItem_class_bin_re_relation__typ_ = new clsOntologyItem()
                {
                    GUID = objOList_class_bin_re_relation__typ_.First().ID_Other,
                    Name = objOList_class_bin_re_relation__typ_.First().Name_Other,
                    GUID_Parent = objOList_class_bin_re_relation__typ_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
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


        }

        private void get_Config_Objects()
        {

        }

        private void get_Config_Classes()
        {
            var objOList_class_mengen = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                         where objOItem.ID_Object == cstrID_Ontology
                                         join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                         where objRef.Name_Object.ToLower() == "class_mengen".ToLower() && objRef.Ontology == Globals.Type_Class
                                         select objRef).ToList();

            if (objOList_class_mengen.Any())
            {
                OItem_class_mengen = new clsOntologyItem()
                {
                    GUID = objOList_class_mengen.First().ID_Other,
                    Name = objOList_class_mengen.First().Name_Other,
                    GUID_Parent = objOList_class_mengen.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_mengentyp = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                            where objOItem.ID_Object == cstrID_Ontology
                                            join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "class_mengentyp".ToLower() && objRef.Ontology == Globals.Type_Class
                                            select objRef).ToList();

            if (objOList_class_mengentyp.Any())
            {
                OItem_class_mengentyp = new clsOntologyItem()
                {
                    GUID = objOList_class_mengentyp.First().ID_Other,
                    Name = objOList_class_mengentyp.First().Name_Other,
                    GUID_Parent = objOList_class_mengentyp.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_mengen_element = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                 where objOItem.ID_Object == cstrID_Ontology
                                                 join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                 where objRef.Name_Object.ToLower() == "class_mengen_element".ToLower() && objRef.Ontology == Globals.Type_Class
                                                 select objRef).ToList();

            if (objOList_class_mengen_element.Any())
            {
                OItem_class_mengen_element = new clsOntologyItem()
                {
                    GUID = objOList_class_mengen_element.First().ID_Other,
                    Name = objOList_class_mengen_element.First().Name_Other,
                    GUID_Parent = objOList_class_mengen_element.First().ID_Parent_Other,
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
