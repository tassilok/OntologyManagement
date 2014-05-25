using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace RDF_Module
{
    public class clsRDFExport
    {

        private clsDataWork_Ontologies objDataWork_Ontologies;

        private clsDataWork_RDFModule objDataWork_RDFModule;

        public clsOntologyItem ExportOntology(clsOntologyItem OItem_Ontology, string path)
        {
            var objOItem_Result = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.Clone();

            objOItem_Result =  objDataWork_Ontologies.GetData_BaseData();
          

            return objOItem_Result;
        }

        public clsRDFExport(clsDataWork_RDFModule DataWork_RDFModule)
        {
            objDataWork_RDFModule = DataWork_RDFModule;
            Initialize();
        }

        private void Initialize()
        {
            objDataWork_Ontologies = new clsDataWork_Ontologies(objDataWork_Ontologies.LocalConfig.Globals);
        }
    }
}
