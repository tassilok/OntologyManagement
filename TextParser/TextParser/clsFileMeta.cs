using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    public class clsFileMeta
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastWriteDate { get; set; }
        public DateTime CreateDatetime { get; set; }
        public DateTime LastWriteTime { get; set; }
    }
}
