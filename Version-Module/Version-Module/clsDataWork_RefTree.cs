using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontolog_Module;
using OntologyClasses.BaseClasses;

namespace Version_Module
{
    
    class clsDataWork_RefTree
    {
        public clsLocalConfig objLocalConfig;

        private clsOntologyItem objOItem_Result_Versions;
        private clsOntologyItem objOItem_Result_Refs_To_Versions;
        private clsOntologyItem objOItem_Result_Versions__VersionNumbers;

        private clsDBLevel objDBLevel_Versions;
        private clsDBLevel objDBLevel_Refs_To_Versions;
        private clsDBLevel objDBLevel_Version__VersionNumbers;

        public List<clsOntologyItem> OList_Versions { get; private set; }
        public List<clsObjectRel> OList_Ref_To_Version { get; private set; }
        public List<clsObjectAtt> OList_Version__VersionNumbers { get; private set; }

        public clsLocalConfig LocalConfig { get { return objLocalConfig; } }

        public void GetData_Version()
        {
            objOItem_Result_Versions = objLocalConfig.Globals.LState_Nothing;
            var objOList_Versions = new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = objLocalConfig.OItem_type_developmentversion.GUID } };

            var objOItem_Result = objDBLevel_Versions.get_Data_Objects(objOList_Versions);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_Versions = objDBLevel_Versions.OList_Objects;
                objOItem_Result_Versions = objLocalConfig.Globals.LState_Success;
            }
            else
            {
                objOItem_Result_Versions = objLocalConfig.Globals.LState_Error;
            }

        }

        public void GetData_Refs()
        {
            objOItem_Result_Refs_To_Versions = objLocalConfig.Globals.LState_Nothing;

            var objOList_Ref_To_Version = new List<clsObjectRel> { new clsObjectRel { ID_Parent_Other = objLocalConfig.OItem_type_developmentversion.GUID, 
                                                                                      ID_RelationType = objLocalConfig.OItem_relationtype_isinstate.GUID } };

            var objOItem_Result = objDBLevel_Refs_To_Versions.get_Data_ObjectRel(objOList_Ref_To_Version, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {

                objOItem_Result_Refs_To_Versions = objLocalConfig.Globals.LState_Success;
            }
            else
            {
                objOItem_Result_Refs_To_Versions = objLocalConfig.Globals.LState_Error;
            }
            
        }

        public void GetData_VersionNumbers()
        {
            objOItem_Result_Versions__VersionNumbers = objLocalConfig.Globals.LState_Nothing;

            var objOAL_Versions__VersionNumbers = new List<clsObjectAtt> { new clsObjectAtt { ID_AttributeType = objLocalConfig.OItem_attribute_major.GUID, 
                                                                                               ID_Class = objLocalConfig.OItem_type_developmentversion.GUID },
                                                                            new clsObjectAtt { ID_AttributeType = objLocalConfig.OItem_attribute_minor.GUID, 
                                                                                               ID_Class = objLocalConfig.OItem_type_developmentversion.GUID },
                                                                            new clsObjectAtt { ID_AttributeType = objLocalConfig.OItem_attribute_build.GUID, 
                                                                                               ID_Class = objLocalConfig.OItem_type_developmentversion.GUID },
                                                                            new clsObjectAtt { ID_AttributeType = objLocalConfig.OItem_attribute_revision.GUID, 
                                                                                               ID_Class = objLocalConfig.OItem_type_developmentversion.GUID } };

            var objOItem_Result = objDBLevel_Version__VersionNumbers.get_Data_ObjectAtt(objOAL_Versions__VersionNumbers, boolIDs: false);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_Version__VersionNumbers = objDBLevel_Version__VersionNumbers.OList_ObjectAtt;
                objOItem_Result_Versions__VersionNumbers = objOItem_Result;
            }
            else
            {
                objOItem_Result_Versions__VersionNumbers = objLocalConfig.Globals.LState_Error;
            }

        }

        public clsDataWork_RefTree(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            initialize();
        }

        private void initialize()
        {
            objDBLevel_Versions = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Refs_To_Versions = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Version__VersionNumbers = new clsDBLevel(objLocalConfig.Globals);
        }

    }
}


