using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookConnector_Module
{
    public class clsMailItem
    {
        public string ID_MailItem { get; set; }
        public string EntryID { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public string To { get; set; }
        public DateTime CreationDate { get; set; }
        public string Subject { get; set; }
        public string Folder { get; set; }
        public Boolean SemItemPresent { get; set; }

    }
}
