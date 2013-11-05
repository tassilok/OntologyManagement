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


        public Boolean Find(List<KeyValuePair<string, string>> Filters)
        {
            var boolFound = false;
            foreach (var filter in Filters)
            {
                if (filter.Key.ToLower() == "id_mailitem")
                {
                    if (ID_MailItem.ToLower() == filter.Value.ToLower())
                    {
                        boolFound = true;
                        break;
                    }
                }

                if (filter.Key.ToLower() == "entryid")
                {
                    if (EntryID.ToLower() == filter.Value.ToLower())
                    {
                        boolFound = true;
                        break;
                    }
                }

                if (filter.Key.ToLower() == "senderemail")
                {
                    if (SenderEmail != null)
                    {
                        if (SenderEmail.ToLower() == filter.Value.ToLower())
                        {
                            boolFound = true;
                            break;
                        }
                    }
                    
                }

                if (filter.Key.ToLower() == "sendername")
                {
                    if (SenderName != null)
                    {
                        if (SenderName.ToLower() == filter.Value.ToLower())
                        {
                            boolFound = true;
                            break;
                        }
                    }
                }

                if (filter.Key.ToLower() == "to")
                {
                    if (To != null)
                    {
                        if (To.ToLower() == filter.Value.ToLower())
                        {
                            boolFound = true;
                            break;
                        }
                    }
                }

                if (filter.Key.ToLower() == "creationdate")
                {
                    if (CreationDate != null)
                    {
                        DateTime dateValue;
                        if (DateTime.TryParse(filter.Value, out dateValue))
                        {
                            if (CreationDate == dateValue)
                            {
                                boolFound = true;
                                break;
                            }
                        }
                    }
                    
                }

                if (filter.Key.ToLower() == "subject")
                {
                    if (Subject != null)
                    {
                        if (Subject.ToLower() == filter.Value.ToLower())
                        {
                            boolFound = true;
                            break;
                        }
                    }
                }

                if (filter.Key.ToLower() == "folder")
                {
                    if (Folder != null)
                    {
                        if (Folder.ToLower() == filter.Value.ToLower())
                        {
                            boolFound = true;
                            break;
                        }
                    }
                }

                if (filter.Key.ToLower() == "semitempresent")
                {
                    if (SemItemPresent != null)
                    {
                        bool boolValue;
                        if (bool.TryParse(filter.Value, out boolValue))
                        {
                            if (SemItemPresent == boolValue)
                            {
                                boolFound = true;
                                break;
                            }
                        }
                    }

                }
            }
            
            return boolFound;
        }
    }
}
