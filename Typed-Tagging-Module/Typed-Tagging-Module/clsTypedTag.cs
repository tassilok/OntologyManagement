using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typed_Tagging_Module
{
    public class clsTypedTag
    {
        public string ID_TaggingSource { get; set; }
        public string Name_TaggingSource { get; set; }
        public string ID_Parent_TaggingSource { get; set; }
        public string Name_Parent_TaggingSource { get; set; }
        public long OrderId_TaggingSource { get; set; }
        public string ID_TypedTag { get; set; }
        public string Name_TypedTag { get; set; }
        public string ID_TaggingDest { get; set; }
        public string Name_TaggingDest { get; set; }
        public string ID_Parent_TaggingDest { get; set; }
        public string Name_Parent_TaggingDest { get; set; }
        public string Type_TaggingDest { get; set; }
        public string ID_User { get; set; }
        public string Name_User { get; set; }
        public string ID_Group { get; set; }
        public string Name_Group { get; set; }

        public bool Filter(List<clsFilter> filter = null)
        {
            var filtered = true;

            if (filter != null && filter.Any())
            {
                filtered = true;
                filter.ForEach(fi =>
                {
                    if (fi.RowFilterType == FilterType.Equal)
                    {
                        if (fi.Column == "ID_TaggingSource")
                        {
                            if (fi.Value == ID_TaggingSource)
                            {
                                filtered = filtered == true ? true : filtered;
                            }
                            else
                            {
                                filtered = false;
                            }

                        }
                        else if (fi.Column == "ID_TaggingDest")
                        {
                            if (fi.Value == ID_TaggingDest)
                            {
                                filtered = filtered == true ? true : filtered;
                            }
                            else
                            {
                                filtered = false;
                            }
                        }
                        else if (fi.Column == "ID_Parent_TaggingSource")
                        {
                            if (fi.Value == ID_Parent_TaggingSource)
                            {
                                filtered = filtered == true ? true : filtered;
                            }
                            else
                            {
                                filtered = false;
                            }
                        }
                        else if (fi.Column == "ID_Parent_TaggingDest")
                        {
                            if (fi.Value == ID_Parent_TaggingDest)
                            {
                                filtered = filtered == true ? true : filtered;
                            }
                            else
                            {
                                filtered = false;
                            }
                        }

                    }
                    else if (fi.RowFilterType == FilterType.Different)
                    {
                        if (fi.Column == "ID_TaggingSource")
                        {
                            if (fi.Value != ID_TaggingSource)
                            {
                                filtered = filtered == true ? true : filtered;
                            }
                            else
                            {
                                filtered = false;
                            }

                        }
                        else if (fi.Column == "ID_TaggingDest")
                        {
                            if (fi.Value != ID_TaggingDest)
                            {
                                filtered = filtered == true ? true : filtered;
                            }
                            else
                            {
                                filtered = false;
                            }
                        }
                        else if (fi.Column == "ID_Parent_TaggingSource")
                        {
                            if (fi.Value != ID_Parent_TaggingSource)
                            {
                                filtered = filtered == true ? true : filtered;
                            }
                            else
                            {
                                filtered = false;
                            }
                        }
                        else if (fi.Column == "ID_Parent_TaggingDest")
                        {
                            if (fi.Value != ID_Parent_TaggingDest)
                            {
                                filtered = filtered == true ? true : filtered;
                            }
                            else
                            {
                                filtered = false;
                            }
                        }
                    }
                    else if (fi.RowFilterType == FilterType.Contains)
                    {
                        if (fi.Column == "Name_TaggingSource")
                        {
                            if (Name_TaggingSource.ToLower().Contains(fi.Value))
                            {
                                filtered = filtered == true ? true : filtered;
                            }
                            else
                            {
                                filtered = false;
                            }

                        }
                        else if (fi.Column == "Name_TaggingDest")
                        {
                            if (Name_TaggingDest.Contains(fi.Value))
                            {
                                filtered = filtered == true ? true : filtered;
                            }
                            else
                            {
                                filtered = false;
                            }
                        }
                        else if (fi.Column == "Name_Parent_TaggingSource")
                        {
                            if (Name_Parent_TaggingSource.ToLower().Contains(fi.Value))
                            {
                                filtered = filtered == true ? true : filtered;
                            }
                            else
                            {
                                filtered = false;
                            }

                        }
                        else if (fi.Column == "Name_Parent_TaggingDest")
                        {
                            if (Name_Parent_TaggingDest.Contains(fi.Value))
                            {
                                filtered = filtered == true ? true : filtered;
                            }
                            else
                            {
                                filtered = false;
                            }
                        }
                    }
                });
            }

            return filtered;
        }
    }
}
