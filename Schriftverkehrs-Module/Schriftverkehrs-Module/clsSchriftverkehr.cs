using Schriftverkehrs_Module.ClassAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Schriftverkehrs_Module
{
    public class clsSchriftverkehr
    {
        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = false)]
        public string ID_Schriftverkehr { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = true)]
        [ColumnAttribute(ColumnHeader= "Schriftverkehr", DisplayIx=2)]
        public string Name_Schriftverkehr { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = true)]
        [ColumnAttribute(ColumnHeader = "abgeschickt am", DisplayIx = 4)]
        public DateTime? AbgeschicktAm { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = true)]
        [ColumnAttribute(ColumnHeader = "erhalten am", DisplayIx = 5)]
        public DateTime? ErhaltenAm { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = true)]
        [ColumnAttribute(ColumnHeader = "Datum (Schriftstück)", DisplayIx = 3)]
        public DateTime? SchriftstueckDatum { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = false)]
        public string ID_LogEntry_Last { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = false)]
        public string Name_LogEntry_Last { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = false)]
        public DateTime? LogEntry_DateTime { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = false)]
        public string ID_LogState { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = false)]
        public string Name_LogState { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = false)]
        public string ID_Partner { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = true)]
        [ColumnAttribute(ColumnHeader = "Partner", DisplayIx = 6)]
        public string Name_Partner { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = false)]
        public string ID_Contact { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = true)]
        [ColumnAttribute(ColumnHeader = "Kontakt", DisplayIx = 7)]
        public string Name_Contact { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = false)]
        public string ID_Schriftverkehr_belonging { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = true)]
        [ColumnAttribute(ColumnHeader = "Schriftverkehr (zugehörig)", DisplayIx = 8)]
        public string Name_Schriftverkehr_belonging { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = false)]
        public string ID_Schriftverkehrsart { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = true)]
        [ColumnAttribute(ColumnHeader = "Schriftverkehrstyp", DisplayIx = 2)]
        public string Name_Schriftverkehrsart { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = false)]
        public string Name_Dest { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = false)]
        public string ID_Address { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = true)]
        [ColumnAttribute(ColumnHeader = "Adresse", DisplayIx = 9)]
        public string Name_Address { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = false)]
        public string ID_EmailAddress { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = true)]
        [ColumnAttribute(ColumnHeader = "Email-Adresse", DisplayIx = 10)]
        public string Name_EmailAddress { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = false)]
        public string ID_Telefonnummer { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = true)]
        [ColumnAttribute(ColumnHeader = "Telefonnummer", DisplayIx = 11)]
        public string Name_Telefonnummer { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = false)]
        public string ID_Url { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = true)]
        [ColumnAttribute(ColumnHeader = "Url", DisplayIx = 12)]
        public string Name_Url { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = false)]
        public string ID_AddressZusatz { get; set; }

        [GridAttribute(Show = true)]
        [VisibilityAttribute(Visible = false)]
        [ColumnAttribute(ColumnHeader = "Addresszusatz", DisplayIx = 13)]
        public string Name_AddressZusatz { get; set; }

        [GridAttribute(Show = false)]
        public bool FilterError { get; set; }

        public bool Filter(List<clsFilter> filters, ConnectorTag connectorTag)
        {

            FilterError = false;
            var propertyInfos = typeof(clsSchriftverkehr).GetProperties(BindingFlags.Public | BindingFlags.Static).ToList();
            bool result = true;

            foreach (var filter in filters)
            {
                var properties = propertyInfos.Where(pi => pi.Name.ToLower() == filter.FilterField.ToLower()).ToList();
                if (properties.Any())
                {
                    try
                    {
                        if (filter.TypeOfFilter == FilterType.isEqual)
                        {
                            if (properties.Last().GetValue(this) == filter.FilterValue)
                            {
                                result = connectorTag == ConnectorTag.and ? result : true;
                            }
                            else
                            {
                                result = connectorTag == ConnectorTag.and ? false : result;
                            }
                        }
                        else if (filter.TypeOfFilter == FilterType.isDifferent)
                        {
                            if (properties.Last().GetValue(this) != filter.FilterValue)
                            {
                                result = connectorTag == ConnectorTag.and ? result : true;
                            }
                            else
                            {
                                result = connectorTag == ConnectorTag.and ? false : result;
                            }
                        }
                        else if (filter.TypeOfFilter == FilterType.isNull)
                        {
                            if (properties.Last().GetValue(this) == null)
                            {
                                result = connectorTag == ConnectorTag.and ? result : true;
                            }
                            else
                            {
                                result = connectorTag == ConnectorTag.and ? false : result;
                            }
                        }

                        

                    }
                    catch (Exception ex)
                    {
                        FilterError = true;
                        break;
                    }
                    
                }
                else
                {
                    FilterError = true;
                }
            }

            return result;
        }
    }
}
