using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Drawing.Imaging;
using System.Drawing;

namespace File_Tagging_Module
{
    public class clsJpgMeta
    {
        private clsLocalConfig objLocalConfig;

        public string Path { get; private set; }

        public clsOntologyItem GetTagsOfFile(string path)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            Path = path;

            try
            {
                var image = Image.FromFile(path);
                var gpsInfo = ImageExtensions.GetGpsInfo(image);

            }
            catch (Exception ex)
            {
                objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
            }

            return objOItem_Result;

        }

        

        public clsJpgMeta(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
        }

    }
}
