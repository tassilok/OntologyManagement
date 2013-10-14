using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;
using System.Xml;
using OntologyClasses.BaseClasses;
using Filesystem_Module;

namespace ImportExport_Module
{
    public class clsExport
    {
        private clsLocalConfig objLocalConfig;
        private clsFileWork objFileWork;

        private XmlWriter objXMLWriter;

        public clsOntologyItem OpenExportFile(clsOntologyItem objOItem_File)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            objOItem_File.Additional1 = objFileWork.get_Path_FileSystemObject(objOItem_File);

            try
            {
                objXMLWriter = new XmlTextWriter(objOItem_File.Additional1, System.Text.Encoding.UTF8);
            }
            catch (Exception)
            {

                objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
            }
            

            return objOItem_Result;
        }

        public clsOntologyItem CloseExportFile()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            try
            {
                objXMLWriter.Close();
            }
            catch(Exception ex)
            {
                
            }

            return objXMLWriter.WriteState == WriteState.Closed ? objLocalConfig.Globals.LState_Success.Clone() : objLocalConfig.Globals.LState_Error.Clone();
        }
        

        public clsExport(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            initialize();
        }

        public clsExport(clsGlobals Globals)
        {
            objLocalConfig = new clsLocalConfig(Globals);
            initialize();
        }

        private void initialize()
        {
            objFileWork = new clsFileWork(objLocalConfig.Globals);
        }

    }
}
