using System;

namespace ElasticSearchNestConnector
{
    public class ElExportAttribute : Attribute
    {
        public bool Exclude { get; set; }
    }
}
