﻿using System;
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


        public Boolean Find(List<clsFilter> Filters)
        {
            var boolFound = false;
            foreach (var filter in Filters)
            {
                if (filter.key.ToString().ToLower() == "id_mailitem")
                {
                    if (filter.TypeOfFilter == FilterType.contains)
                    {
                        if (ID_MailItem.ToString().ToLower() == filter.value.ToString().ToLower())
                        {
                            boolFound = true;
                            break;
                        }
                    }
                    else if (filter.TypeOfFilter == FilterType.different)
                    {
                        if (ID_MailItem.ToString().ToLower() != filter.value.ToString().ToLower())
                        {
                            boolFound = true;
                            break;
                        }
                    }
                    else if (filter.TypeOfFilter == FilterType.contains)
                    {
                        if (ID_MailItem.ToString().ToLower().Contains(filter.value.ToString().ToLower()))
                        {
                            boolFound = true;
                            break;
                        }
                    }
                    
                }

                if (filter.key.ToString().ToLower() == "entryid")
                {
                    if (filter.TypeOfFilter == FilterType.equal)
                    {
                        if (EntryID.ToString().ToLower() == filter.value.ToString().ToLower())
                        {
                            boolFound = true;
                            break;
                        }
                    }
                    else if (filter.TypeOfFilter == FilterType.different)
                    {
                        if (EntryID.ToString().ToLower() != filter.value.ToString().ToLower())
                        {
                            boolFound = true;
                            break;
                        }
                    }
                    else if (filter.TypeOfFilter == FilterType.contains)
                    {
                        if (EntryID.ToString().ToLower().Contains(filter.value.ToString().ToLower()))
                        {
                            boolFound = true;
                            break;
                        }
                    }
                    
                }

                if (filter.key.ToString().ToLower() == "senderemail")
                {
                    if (SenderEmail != null)
                    {
                        if (filter.TypeOfFilter == FilterType.equal)
                        {
                            if (SenderEmail.ToString().ToLower() == filter.value.ToString().ToLower())
                            {
                                boolFound = true;
                                break;
                            }
                        }
                        else if (filter.TypeOfFilter == FilterType.different)
                        {
                            if (SenderEmail.ToString().ToLower() != filter.value.ToString().ToLower())
                            {
                                boolFound = true;
                                break;
                            }
                        }
                        else if (filter.TypeOfFilter == FilterType.contains)
                        {
                            if (SenderEmail.ToString().ToLower().Contains(filter.value.ToString().ToLower()))
                            {
                                boolFound = true;
                                break;
                            }
                        }
                        
                    }
                    
                }

                if (filter.key.ToString().ToLower() == "sendername")
                {
                    if (SenderName != null)
                    {
                        if (filter.TypeOfFilter == FilterType.equal)
                        {
                            if (SenderName.ToString().ToLower() == filter.value.ToString().ToLower())
                            {
                                boolFound = true;
                                break;
                            }
                        }
                        else if (filter.TypeOfFilter == FilterType.different)
                        {
                            if (SenderName.ToString().ToLower() != filter.value.ToString().ToLower())
                            {
                                boolFound = true;
                                break;
                            }
                        }
                        else if (filter.TypeOfFilter == FilterType.contains)
                        {
                            if (SenderName.ToString().ToLower().Contains(filter.value.ToString().ToLower()))
                            {
                                boolFound = true;
                                break;
                            }
                        }
                        
                    }
                }

                if (filter.key.ToString().ToLower() == "to")
                {
                    if (To != null)
                    {
                        if (filter.TypeOfFilter == FilterType.equal)
                        {
                            if (To.ToString().ToLower() == filter.value.ToString().ToLower())
                            {
                                boolFound = true;
                                break;
                            }
                        }
                        else if (filter.TypeOfFilter == FilterType.different)
                        {
                            if (To.ToString().ToLower() != filter.value.ToString().ToLower())
                            {
                                boolFound = true;
                                break;
                            }
                        }
                        else if (filter.TypeOfFilter == FilterType.contains)
                        {
                            if (To.ToString().ToLower().Contains(filter.value.ToString().ToLower()))
                            {
                                boolFound = true;
                                break;
                            }
                        }
                        
                    }
                }

                if (filter.key.ToString().ToLower() == "creationdate")
                {
                    if (filter.value is DateTime)
                    {
                        var datevalue = (DateTime)filter.value;
                        if (CreationDate != null)
                        {
                            if (filter.TypeOfFilter == FilterType.equal)
                            {
                                if (CreationDate == datevalue)
                                {
                                    boolFound = true;
                                    break;
                                }
                            }
                            else if (filter.TypeOfFilter == FilterType.different)
                            {
                                if (CreationDate != datevalue)
                                {
                                    boolFound = true;
                                    break;
                                }
                            }
                            
                        }
                    }
                    
                    
                }

                if (filter.key.ToString().ToLower() == "subject")
                {
                    if (Subject != null)
                    {
                        if (filter.TypeOfFilter == FilterType.equal)
                        {
                            if (Subject.ToString().ToLower() == filter.value.ToString().ToLower())
                            {
                                boolFound = true;
                                break;
                            }
                        }
                        else if (filter.TypeOfFilter == FilterType.different)
                        {
                            if (Subject.ToString().ToLower() != filter.value.ToString().ToLower())
                            {
                                boolFound = true;
                                break;
                            }
                        }
                        else if (filter.TypeOfFilter == FilterType.contains)
                        {
                            if (Subject.ToString().ToLower().Contains(filter.value.ToString().ToLower()))
                            {
                                boolFound = true;
                                break;
                            }
                        }
                        
                    }
                }

                if (filter.key.ToString().ToLower() == "folder")
                {
                    if (Folder != null)
                    {
                        if (filter.TypeOfFilter == FilterType.equal)
                        {
                            if (Folder.ToString().ToLower() == filter.value.ToString().ToLower())
                            {
                                boolFound = true;
                                break;
                            }
                        }
                        else if (filter.TypeOfFilter == FilterType.different)
                        {
                            if (Folder.ToString().ToLower() != filter.value.ToString().ToLower())
                            {
                                boolFound = true;
                                break;
                            }
                        }
                        else if (filter.TypeOfFilter == FilterType.contains)
                        {
                            if (Folder.ToString().ToLower().Contains(filter.value.ToString().ToLower()))
                            {
                                boolFound = true;
                                break;
                            }
                        }
                        
                    }
                }

                if (filter.key.ToString().ToLower() == "semitempresent")
                {
                    if (filter.value is bool)
                    {
                        var boolvalue = (bool)filter.value;
                        if (SemItemPresent != null)
                        {
                            if (filter.TypeOfFilter == FilterType.equal)
                            {
                                if (SemItemPresent == boolvalue)
                                {
                                    boolFound = true;
                                    break;
                                }
                            }
                            else if (filter.TypeOfFilter == FilterType.different)
                            {
                                if (SemItemPresent != boolvalue)
                                {
                                    boolFound = true;
                                    break;
                                }
                            }
                            
                            
                        }
                    }
                    

                }
            }
            
            return boolFound;
        }
    }
}
