using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace ScriptingModule
{
    public class clsDataWork_Scripting
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_LuaFunctions;

        public List<clsOntologyItem> OList_Functions { get; private set; }

        public clsDataWork_Scripting(clsLocalConfig localConfig)
        {
            objLocalConfig = localConfig;

            Initialize();
        }

        public clsOntologyItem GetData()
        {
            var result = objLocalConfig.Globals.LState_Success.Clone();

            var searchFunctions = new List<clsObjectRel> { new clsObjectRel {ID_Object = objLocalConfig.OItem_object_baseconfig.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_offers.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_lua_functions__scripting_module_.GUID}};

            result = objDBLevel_LuaFunctions.get_Data_ObjectRel(searchFunctions, boolIDs: false);

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_Functions = objDBLevel_LuaFunctions.OList_ObjectRel.Select(luaf => new clsOntologyItem
                {
                    GUID = luaf.ID_Other,
                    Name = luaf.Name_Other,
                    GUID_Parent = luaf.ID_Parent_Other,
                    Type = objLocalConfig.Globals.Type_Object
                }).ToList();

            }
            else
            {
                OList_Functions = null;
            }

            return result;
        }

        private void Initialize()
        {
            objDBLevel_LuaFunctions = new clsDBLevel(objLocalConfig.Globals);
        }

    }
}
