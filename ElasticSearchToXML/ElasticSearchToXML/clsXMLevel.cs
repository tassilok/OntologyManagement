using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontolog_Module;
using System.Xml;
using System.IO;

namespace ElasticSearchToXML
{
    class clsXMLevel
    {
        private clsGlobals objGlobals;
        private clsDBLevel objDbLevel;
        private XmlWriter objXmlWriter;

        public void Initialize_XML(Stream objStream)
        {
            objXmlWriter = new XmlTextWriter(objStream,System.Text.Encoding.UTF8);
        }


        public void Finalize_XML()
        {
            objXmlWriter.Close();
        }

        public clsXMLevel(clsGlobals globals)
        {
            objGlobals = globals;
            set_DBConnection();
        }

        private void set_DBConnection()
        {
            objDbLevel = new clsDBLevel(objGlobals);
        }

        clsOntologyItem get_Data_AttributeType(List<clsOntologyItem> oListAttType = null
                                              ,Boolean boolTable = false
                                              ,Boolean doCount = false)
        {
            clsOntologyItem objResult;

            objResult =  objDbLevel.get_Data_AttributeType(oListAttType
                                              , boolTable
                                              , doCount);

            

            return objResult;
        }
        
    }
}
