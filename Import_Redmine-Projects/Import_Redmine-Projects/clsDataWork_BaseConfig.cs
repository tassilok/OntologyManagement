using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace Import_Redmine_Projects
{
    
    public class clsDataWork_BaseConfig
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_BaseConfigRel1;
        private clsDBLevel objDBLevel_BaseConfigRel2;

        private clsDBLevel objDBLevel_IndexRel;
        private clsDBLevel objDBLevel_ServerPortRel;

        public string Index { get; private set; }
        public string Server { get; private set; }
        public int Port { get; private set; }

        public clsOntologyItem GetData_BaseConfig(clsOntologyItem OItem_User, clsOntologyItem OItem_Group)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objORelS_Ref = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Parent_Object = objLocalConfig.OItem_class_import_redmine_projects.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                            ID_Other = OItem_Group.GUID
                        },
                    new clsObjectRel
                        {
                            ID_Parent_Object = objLocalConfig.OItem_class_import_redmine_projects.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                            ID_Other = OItem_User.GUID
                        }
                };

            objOItem_Result = objDBLevel_BaseConfigRel1.get_Data_ObjectRel(objORelS_Ref, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID && objDBLevel_BaseConfigRel1.OList_ObjectRel.Any())
            {
                objORelS_Ref =
                    (from objBaseConfigUser in
                         objDBLevel_BaseConfigRel1.OList_ObjectRel.Where(
                             b => b.ID_Parent_Other == OItem_User.GUID_Parent).ToList()
                     join objBaseConfigGroup in
                         objDBLevel_BaseConfigRel1.OList_ObjectRel.Where(
                             b => b.ID_Parent_Other == OItem_Group.GUID_Parent).ToList() on objBaseConfigUser.ID_Object
                         equals objBaseConfigGroup.ID_Object
                     select new clsObjectRel
                         {
                             ID_Object = objBaseConfigUser.ID_Object,
                             ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                             ID_Parent_Other = objLocalConfig.OItem_class_indexes__elastic_search_.GUID
                         }).ToList();

                objOItem_Result = objDBLevel_BaseConfigRel2.get_Data_ObjectRel(objORelS_Ref, boolIDs: false);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID && objDBLevel_BaseConfigRel2.OList_ObjectRel.Any())
                {
                    objOItem_Result =
                        GetData_Index(objDBLevel_BaseConfigRel2.OList_ObjectRel.Select(i => new clsOntologyItem
                            {
                                GUID = i.ID_Other,
                                Name = i.Name_Other,
                                GUID_Parent = i.ID_Parent_Other,
                                Type = objLocalConfig.Globals.Type_Object
                            }).ToList().First());
                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                }
            }
            else
            {
                objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
            }
            

            return objOItem_Result;
        }

        public clsOntologyItem GetData_Index(clsOntologyItem OItem_Index)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objORelS_IndexRel = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Object = OItem_Index.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_server_port.GUID
                        }
                };

            objOItem_Result = objDBLevel_IndexRel.get_Data_ObjectRel(objORelS_IndexRel, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID && objDBLevel_IndexRel.OList_ObjectRel.Any())
            {
                var objOrelS_ServerPortRel = objDBLevel_IndexRel.OList_ObjectRel.Select(i => new clsObjectRel
                    {
                        ID_Object = i.ID_Other,
                        ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_port.GUID
                    }).ToList();

                objOrelS_ServerPortRel.AddRange(objDBLevel_IndexRel.OList_ObjectRel.Select(i => new clsObjectRel
                    {
                        ID_Object = i.ID_Other,
                        ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_server.GUID
                    }));

                objOItem_Result = objDBLevel_ServerPortRel.get_Data_ObjectRel(objOrelS_ServerPortRel, boolIDs: false);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID &&
                    objDBLevel_ServerPortRel.OList_ObjectRel.Count == 2)
                {
                    

                    var objOList_Server =
                        objDBLevel_ServerPortRel.OList_ObjectRel.Where(
                            sp => sp.ID_Parent_Other == objLocalConfig.OItem_class_server.GUID).
                                                 Select(sp => new clsOntologyItem
                                                     {
                                                         GUID = sp.ID_Other,
                                                         Name = sp.Name_Other,
                                                         GUID_Parent = sp.ID_Parent_Other,
                                                         Type = objLocalConfig.Globals.Type_Object
                                                     }).ToList();

                    var objOList_Port =
                        objDBLevel_ServerPortRel.OList_ObjectRel.Where(
                            sp => sp.ID_Parent_Other == objLocalConfig.OItem_class_port.GUID).
                                                 Select(sp => new clsOntologyItem
                                                 {
                                                     GUID = sp.ID_Other,
                                                     Name = sp.Name_Other,
                                                     GUID_Parent = sp.ID_Parent_Other,
                                                     Type = objLocalConfig.Globals.Type_Object
                                                 }).ToList();

                    if (objOList_Port.Any() && objOList_Server.Any())
                    {
                        var port = 0;
                        if (int.TryParse(objOList_Port.First().Name, out port))
                        {
                            Index = objDBLevel_IndexRel.OList_ObjectRel.First().Name_Object;
                            Port = port;
                            Server = objOList_Server.First().Name;
                        }
                        else
                        {
                            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                        }
                    }
                    else
                    {
                        objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                    }
                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                }
            }
            else
            {
                objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
            }

            return objOItem_Result;
        }


        public clsDataWork_BaseConfig(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_BaseConfigRel1 = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_BaseConfigRel2 = new clsDBLevel(objLocalConfig.Globals);

            objDBLevel_IndexRel = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ServerPortRel = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
