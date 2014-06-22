using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace File_Tagging_Module
{
    [Flags]     
    public enum ID3Version
    {
        ID3V10 = 10,
        ID3V11 = 11
    }
    public class clsMP3Meta
    {
        private clsLocalConfig objLocalConfig;

        public string Path { get; private set; }
        public bool mTagAvailable { get; set; }
        public ID3Version mTagVersion { get; set; }
        public string mArtist { get; set; }
        public string mTitle { get; set; }
        public string mAlbum { get; set; }
        public string mYear { get; set; }
        public string mComment { get; set; }
        public byte mGenre { get; set; }
        public string mGenreName { get; set; }
        public byte mTrack { get; set; }

        public clsOntologyItem GetTagsOfFile(string path)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            this.Path = path;

            return objOItem_Result;
        }

        public clsMP3Meta(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
        }
    }
}
