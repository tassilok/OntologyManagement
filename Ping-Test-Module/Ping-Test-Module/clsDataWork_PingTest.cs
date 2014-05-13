using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace Ping_Test_Module
{
    public class clsDataWork_PingTest
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_ServerOfIpAddresses;
        private clsDBLevel objDBLevel_IPAddress;
        private clsDBLevel objDBLevel_Server;

        public List<clsOntologyItem> OList_IPAddresses { get; set; }

        public List<clsPingTest> PingTestList { get; set; }

        public clsOntologyItem GetData_ServerIPAddresses()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            PingTestList = new List<clsPingTest>();

            objOItem_Result = GetSubData001_IPAddresses();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = GetSubData002_ServerOfIPAddresses();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOItem_Result = GetSubData003_Server();
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        PingTestList = (from objServer in objDBLevel_Server.OList_Objects
                                        join objIPAddressOfServer in objDBLevel_ServerOfIpAddresses.OList_ObjectRel on
                                            objServer.GUID equals objIPAddressOfServer.ID_Other into
                                            objIPAddressesOfServer
                                        from objIPAddressOfServer in objIPAddressesOfServer.DefaultIfEmpty()
                                        select new clsPingTest
                                            {
                                                ID_Server_Related = objServer.GUID,
                                                Name_Server_Related = objServer.Name,
                                                ID_IPAddress = objIPAddressOfServer != null ? objIPAddressOfServer.ID_Object : null,
                                                Name_IPAddress = objIPAddressOfServer != null ? objIPAddressOfServer.Name_Object : null,
                                            }).ToList();

                        var PingTestList2 = (from objIPAddress in objDBLevel_IPAddress.OList_Objects
                                           join objIPAddressOfServer in objDBLevel_ServerOfIpAddresses.OList_ObjectRel
                                               on
                                               objIPAddress.GUID equals objIPAddressOfServer.ID_Object into
                                               objIPAddressesOfServer
                                           from objIPAddressOfServer in objIPAddressesOfServer.DefaultIfEmpty()
                                           select new clsPingTest
                                               {
                                                   ID_Server_Related = objIPAddressOfServer != null ? objIPAddressOfServer.ID_Other : null,
                                                   Name_Server_Related = objIPAddressOfServer != null ? objIPAddressOfServer.Name_Other : null,
                                                   ID_IPAddress = objIPAddress.GUID,
                                                   Name_IPAddress = objIPAddress.Name
                                               }).ToList();

                        PingTestList.AddRange(from objPingTest2 in PingTestList2
                                              join objPingTest1 in PingTestList on new {IPAddress = objPingTest2.ID_IPAddress, Server = objPingTest2.ID_Server_Related} equals
                                              new {IPAddress = objPingTest1.ID_IPAddress, Server = objPingTest1.ID_Server_Related} into objPingTests1
                                              from objPingTest1 in objPingTests1.DefaultIfEmpty()
                                              where objPingTest1 == null
                                              select objPingTest2);
                    }
                }
            }

            return objOItem_Result;
        }
        
        private clsOntologyItem GetSubData001_IPAddresses()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var oList_IPAddressSearch = new List<clsOntologyItem>
                {
                    new clsOntologyItem {GUID_Parent = objLocalConfig.OItem_class_ip_address.GUID}
                };

            objOItem_Result = objDBLevel_IPAddress.get_Data_Objects(oList_IPAddressSearch);

            return objOItem_Result;
        }

        private clsOntologyItem GetSubData002_ServerOfIPAddresses()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objOList_ServerOfIPAddress = objDBLevel_IPAddress.OList_Objects.Select(ip => new clsObjectRel
                {
                    ID_Object = ip.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_additional_for.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_server.GUID
                }).ToList();

            if (objOList_ServerOfIPAddress.Any())
            {
                objOItem_Result = objDBLevel_ServerOfIpAddresses.get_Data_ObjectRel(objOList_ServerOfIPAddress,boolIDs:false);    
            }
            else
            {
                objDBLevel_ServerOfIpAddresses.OList_ObjectRel.Clear();
            }
            

            return objOItem_Result;
        }

        private clsOntologyItem GetSubData003_Server()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objOList_ServerSearch = new List<clsOntologyItem>
                {
                    new clsOntologyItem {GUID_Parent = objLocalConfig.OItem_class_server.GUID}
                };

            objOItem_Result = objDBLevel_Server.get_Data_Objects(objOList_ServerSearch);


            return objOItem_Result;
        }

        public clsDataWork_PingTest(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_ServerOfIpAddresses = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_IPAddress = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Server = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
