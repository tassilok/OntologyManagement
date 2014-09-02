using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace PortListenerForText_Module
{
    public class clsDataWork_PortListener
    {

        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_PortListener;


        public clsOntologyItem Port { get; private set; }


        public clsOntologyItem GetData_Port()
        {
            var searchPort = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Object = objLocalConfig.OItem_object_baseconfig.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_listens_on.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_port.GUID
                        }
                };

            var objOItem_Result = objDBLevel_PortListener.get_Data_ObjectRel(searchPort, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_PortListener.OList_ObjectRel.Any())
                {
                    Port =
                        objDBLevel_PortListener.OList_ObjectRel.OrderBy(port => port.OrderID)
                                               .Select(port => new clsOntologyItem
                                                   {
                                                       GUID = port.ID_Other,
                                                       Name = port.Name_Other,
                                                       GUID_Parent = port.ID_Parent_Other,
                                                       Type = objLocalConfig.Globals.Type_Object
                                                   }).ToList().First();

                    var lngPort = 0;

                    if (int.TryParse(Port.Name, out lngPort))
                    {
                        Port.Val_Long = lngPort;
                    }
                    else
                    {
                        Port = null;
                        objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                    }
                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Nothing.Clone();
                }
            }

            return objOItem_Result;

        }

        public clsDataWork_PortListener(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_PortListener = new clsDBLevel(objLocalConfig.Globals);
        }
    }

}
