using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace OutlookConnector_Module
{
    public class clsDataWork_OutlookConnector
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_Ontology;
        

        public clsOntologyItem Ontology { get; private set; }

        

        

        public clsDataWork_OutlookConnector(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void GetData_Ontology()
        {
            var objOList_Ontology = new List<clsOntologyItem> { new clsOntologyItem { GUID = objLocalConfig.ID_Ontology } };

            var objOItem_Result = objDBLevel_Ontology.get_Data_Objects(objOList_Ontology);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Ontology.OList_Objects.Any())
                {
                    Ontology = objDBLevel_Ontology.OList_Objects.First();
                }
                else
                {
                    throw new Exception("Die notwendigen Daten konnten nicht ermittelt werden!");
                    Environment.Exit(-1);
                }
            }
            else
            {
                throw new Exception("Die notwendigen Daten konnten nicht ermittelt werden!");
                Environment.Exit(-1);
            }
        }

        

        private void Initialize()
        {
            objDBLevel_Ontology = new clsDBLevel(objLocalConfig.Globals);
            GetData_Ontology();
        }
    }

}
