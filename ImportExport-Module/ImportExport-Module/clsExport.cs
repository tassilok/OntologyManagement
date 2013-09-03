using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;
using System.Xml;

namespace ImportExport_Module
{
    public class clsExport
    {
        private clsLocalConfig objLocalConfig;

        private XmlWriter objXMLWriter;

        public clsOntologyItem OpenExportFile(clsOntologyItem objOItem_File)
        {
            clsOntologyItem objOItem_Result;

            objOItem_File.Additional1 = "Export.xml";

            objXMLWriter = new XmlTextWriter(objOItem_File.Additional1,System.Text.Encoding.UTF8);

            return objOItem_Result;
        }

        public clsOntologyItem CloseExportFile()
        {
            try
            {
                objXMLWriter.Close();
            }
            finally
            {
                return (objXMLWriter.WriteState = WriteState.Closed)
                           ? objLocalConfig.Globals.LState_Success
                           : objLocalConfig.Globals.LState_Error;
            }
        }
        

        public clsExport(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
        }

        public clsExport(clsGlobals Globals)
        {
            objLocalConfig = new clsLocalConfig(Globals);
        }


    }
}
