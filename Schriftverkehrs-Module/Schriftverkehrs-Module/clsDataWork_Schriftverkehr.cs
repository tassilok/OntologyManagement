using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using Log_Module;
using Partner_Module;

namespace Schriftverkehrs_Module
{
    public class clsDataWork_Schriftverkehr
    {
        private clsLocalConfig objLocalConfig;
        private clsDBLevel dbLevel_Schriftverkehr;
        private clsDBLevel dbLevel_Schriftverkehr_AttRel;
        private clsDBLevel dbLevel_Schriftverkehr_Rel;
        private clsDBLevel dbLevel_Schriftverkehr_FilterRel;

        public List<clsSchriftverkehr> SchriftverkehrsDaten { get; set; }

        private clsDataWork_LogEntry objDataWork_LogEntry;
        private clsDataWork_Address objDataWork_Address;

        private clsOntologyItem objOItem_Schriftverkehr;

        public clsOntologyItem GetData_Schriftverkehr(string ID_Schriftverkehr = null)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            if (ID_Schriftverkehr != null)
            {
                objOItem_Schriftverkehr = dbLevel_Schriftverkehr_AttRel.GetOItem(ID_Schriftverkehr, objLocalConfig.Globals.Type_Object);

            }
            else
            {
                objOItem_Schriftverkehr = null;
            }
            

            var objOList_Schriftverkehre = new List<clsOntologyItem>();

            if (objOItem_Schriftverkehr == null)
            {
                var objOList_Schriftverkehr = new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = objLocalConfig.OItem_class_schriftverkehr.GUID } };
                objOItem_Result = dbLevel_Schriftverkehr.get_Data_Objects(objOList_Schriftverkehr);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOList_Schriftverkehre = dbLevel_Schriftverkehr.OList_Objects;
                }
            }
            else
            {
                objOList_Schriftverkehre.Add(objOItem_Schriftverkehr);
            }

            SchriftverkehrsDaten = new List<clsSchriftverkehr>();
            

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var objOARel_Schriftverkehr = new List<clsObjectAtt> 
                {
                    new clsObjectAtt 
                    {
                        ID_AttributeType = objLocalConfig.OItem_attributetype_abgeschickt_am.GUID,
                        ID_Class = objLocalConfig.OItem_class_schriftverkehr.GUID,
                        ID_Object = ID_Schriftverkehr
                    },
                    new clsObjectAtt 
                    {
                        ID_AttributeType = objLocalConfig.OItem_attributetype_erhalten_am.GUID,
                        ID_Class = objLocalConfig.OItem_class_schriftverkehr.GUID,
                        ID_Object = ID_Schriftverkehr
                    },
                    new clsObjectAtt 
                    {
                        ID_AttributeType = objLocalConfig.OItem_attributetype_schriftst_ck_datum.GUID,
                        ID_Class = objLocalConfig.OItem_class_schriftverkehr.GUID,
                        ID_Object = ID_Schriftverkehr
                    }
                };

                objOItem_Result = dbLevel_Schriftverkehr_AttRel.get_Data_ObjectAtt(objOARel_Schriftverkehr, boolIDs: false);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var objORel_Schriftverkehr = new List<clsObjectRel>
                    {
                        new clsObjectRel 
                        {
                            ID_Parent_Object = objLocalConfig.OItem_class_schriftverkehr.GUID,
                            ID_Object = ID_Schriftverkehr,
                            ID_RelationType = objLocalConfig.OItem_relationtype_senden_an.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_address.GUID
                        },
                        new clsObjectRel 
                        {
                            ID_Parent_Object = objLocalConfig.OItem_class_schriftverkehr.GUID,
                            ID_Object = ID_Schriftverkehr,
                            ID_RelationType = objLocalConfig.OItem_relationtype_senden_an.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_email_address.GUID
                        },
                        new clsObjectRel 
                        {
                            ID_Parent_Object = objLocalConfig.OItem_class_schriftverkehr.GUID,
                            ID_Object = ID_Schriftverkehr,
                            ID_RelationType = objLocalConfig.OItem_relationtype_senden_an.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_partner.GUID
                        },
                        new clsObjectRel 
                        {
                            ID_Parent_Object = objLocalConfig.OItem_class_schriftverkehr.GUID,
                            ID_Object = ID_Schriftverkehr,
                            ID_RelationType = objLocalConfig.OItem_relationtype_contact.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_partner.GUID
                        },
                        new clsObjectRel 
                        {
                            ID_Parent_Object = objLocalConfig.OItem_class_schriftverkehr.GUID,
                            ID_Object = ID_Schriftverkehr,
                            ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_schriftverkehr.GUID
                        },
                        new clsObjectRel 
                        {
                            ID_Parent_Object = objLocalConfig.OItem_class_schriftverkehr.GUID,
                            ID_Object = ID_Schriftverkehr,
                            ID_RelationType = objLocalConfig.OItem_relationtype_is_of_type.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_schriftverkehrsart.GUID
                        },
                        new clsObjectRel 
                        {
                            ID_Parent_Object = objLocalConfig.OItem_class_schriftverkehr.GUID,
                            ID_Object = ID_Schriftverkehr,
                            ID_RelationType = objLocalConfig.OItem_relationtype_senden_an.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_telefonnummer.GUID
                        },
                        new clsObjectRel 
                        {
                            ID_Parent_Object = objLocalConfig.OItem_class_schriftverkehr.GUID,
                            ID_Object = ID_Schriftverkehr,
                            ID_RelationType = objLocalConfig.OItem_relationtype_senden_an.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_url.GUID
                        },
                        new clsObjectRel
                        {
                            ID_Parent_Object = objLocalConfig.OItem_class_schriftverkehr.GUID,
                            ID_Object = ID_Schriftverkehr,
                            ID_RelationType = objLocalConfig.OItem_relationtype_senden_an.GUID, 
                            ID_Parent_Other = objLocalConfig.OItem_class_adress_zusatz.GUID
                        }
                    };

                    objOItem_Result = dbLevel_Schriftverkehr_Rel.get_Data_ObjectRel(objORel_Schriftverkehr, boolIDs: false);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {

                        

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            SchriftverkehrsDaten = (from objSchriftverkehr in objOList_Schriftverkehre
                                                    join abgeschicktAm in dbLevel_Schriftverkehr_AttRel.OList_ObjectAtt.
                                                        Where(sf => sf.ID_AttributeType == objLocalConfig.OItem_attributetype_abgeschickt_am.GUID).ToList()
                                                        on objSchriftverkehr.GUID equals abgeschicktAm.ID_Object into abgeschickteAm
                                                    from abgeschicktAm in abgeschickteAm.DefaultIfEmpty()
                                                    join erhaltenAm in dbLevel_Schriftverkehr_AttRel.OList_ObjectAtt.
                                                        Where(sf => sf.ID_AttributeType == objLocalConfig.OItem_attributetype_erhalten_am.GUID).ToList()
                                                        on objSchriftverkehr.GUID equals erhaltenAm.ID_Object into erhalteneAm
                                                    from erhaltenAm in erhalteneAm.DefaultIfEmpty()
                                                    join schriftstueckDatum in dbLevel_Schriftverkehr_AttRel.OList_ObjectAtt.
                                                        Where(sf => sf.ID_AttributeType == objLocalConfig.OItem_attributetype_schriftst_ck_datum.GUID).ToList()
                                                        on objSchriftverkehr.GUID equals schriftstueckDatum.ID_Object into schriftstueckDatums
                                                    from schriftstueckDatum in schriftstueckDatums.DefaultIfEmpty()
                                                    join contact in dbLevel_Schriftverkehr_Rel.OList_ObjectRel.
                                                        Where(sf => sf.ID_Parent_Other == objLocalConfig.OItem_class_partner.GUID && sf.ID_RelationType == objLocalConfig.OItem_relationtype_contact.GUID).ToList()
                                                        on objSchriftverkehr.GUID equals contact.ID_Object into contacts
                                                    from contact in contacts.DefaultIfEmpty()
                                                    join partner in dbLevel_Schriftverkehr_Rel.OList_ObjectRel.
                                                        Where(sf => sf.ID_Parent_Other == objLocalConfig.OItem_class_partner.GUID && sf.ID_RelationType == objLocalConfig.OItem_relationtype_senden_an.GUID).ToList()
                                                        on objSchriftverkehr.GUID equals partner.ID_Object into partners
                                                    from partner in partners.DefaultIfEmpty()
                                                    join schriftverkehrRel in dbLevel_Schriftverkehr_Rel.OList_ObjectRel.
                                                        Where(sf => sf.ID_Parent_Other == objLocalConfig.OItem_class_schriftverkehr.GUID).ToList()
                                                        on objSchriftverkehr.GUID equals schriftverkehrRel.ID_Object into schriftverkehrRels
                                                    from schriftverkehrRel in schriftverkehrRels.DefaultIfEmpty()
                                                    join schriftverkehrType in dbLevel_Schriftverkehr_Rel.OList_ObjectRel.
                                                        Where(sf => sf.ID_Parent_Other == objLocalConfig.OItem_class_schriftverkehrsart.GUID).ToList()
                                                        on objSchriftverkehr.GUID equals schriftverkehrType.ID_Object into schriftverkehrTypes
                                                    from schriftverkehrType in schriftverkehrTypes.DefaultIfEmpty()
                                                    join telefonnummer in dbLevel_Schriftverkehr_Rel.OList_ObjectRel.
                                                        Where(sf => sf.ID_Parent_Other == objLocalConfig.OItem_class_telefonnummer.GUID).ToList()
                                                        on objSchriftverkehr.GUID equals telefonnummer.ID_Object into telefonnummern
                                                    from telefonnummer in telefonnummern.DefaultIfEmpty()
                                                    join url in dbLevel_Schriftverkehr_Rel.OList_ObjectRel.
                                                       Where(sf => sf.ID_Parent_Other == objLocalConfig.OItem_class_url.GUID).ToList()
                                                       on objSchriftverkehr.GUID equals url.ID_Object into urls
                                                    from url in urls.DefaultIfEmpty()
                                                    join addressZusatz in dbLevel_Schriftverkehr_Rel.OList_ObjectRel.
                                                       Where(sf => sf.ID_Parent_Other == objLocalConfig.OItem_class_adress_zusatz.GUID).ToList()
                                                       on objSchriftverkehr.GUID equals addressZusatz.ID_Object into addressZusatzs
                                                    from addressZusatz in addressZusatzs.DefaultIfEmpty()
                                                    select new clsSchriftverkehr
                                                    {
                                                        ID_Schriftverkehr = objSchriftverkehr.GUID,
                                                        Name_Schriftverkehr = objSchriftverkehr.Name,
                                                        AbgeschicktAm = abgeschicktAm != null ? abgeschicktAm.Val_Date : null,
                                                        ErhaltenAm = erhaltenAm != null ? erhaltenAm.Val_Date : null,
                                                        SchriftstueckDatum = schriftstueckDatum != null ? schriftstueckDatum.Val_Date : null,
                                                        ID_Contact = contact != null ? contact.ID_Other : null,
                                                        Name_Contact = contact != null ? contact.Name_Other : null,
                                                        ID_Partner = partner != null ? partner.ID_Other : null,
                                                        Name_Partner = partner != null ? partner.Name_Other : null,
                                                        ID_Schriftverkehr_belonging = schriftverkehrRel != null ? schriftverkehrRel.ID_Other : null,
                                                        Name_Schriftverkehr_belonging = schriftverkehrRel != null ? schriftverkehrRel.Name_Other : null,
                                                        ID_Schriftverkehrsart = schriftverkehrType != null ? schriftverkehrType.ID_Other : null,
                                                        Name_Schriftverkehrsart = schriftverkehrType != null ? schriftverkehrType.Name_Other : null,
                                                        ID_Telefonnummer = telefonnummer != null ? telefonnummer.ID_Other : null,
                                                        Name_Telefonnummer = telefonnummer != null ? telefonnummer.Name_Other : null,
                                                        ID_Url = url != null ? url.ID_Other : null,
                                                        Name_Url = url != null ? url.Name_Other : null,
                                                        ID_AddressZusatz = addressZusatz != null ? addressZusatz.ID_Other : null,
                                                        Name_AddressZusatz = addressZusatz != null ? addressZusatz.Name_Other : null
                                                    }).ToList();
                        }
                        
                    }

                    
                }

               

                
            }
            
            
            

            return objOItem_Result;
        }


        public List<string> FilterSchriftVerkehr(clsOntologyItem OItem_Class, clsOntologyItem OItem_Object, clsOntologyItem OItem_RelationType, clsOntologyItem OItem_Direction)
        {
            var objORel_Schriftverkehr = new List<clsObjectRel>();
            var strLIDs = new List<string>();

            if (OItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID)
            {
                objORel_Schriftverkehr = new List<clsObjectRel> { new clsObjectRel {ID_Parent_Object = objLocalConfig.OItem_class_schriftverkehr.GUID,
                    ID_RelationType = OItem_RelationType != null ? OItem_RelationType.GUID : null,
                    ID_Other = OItem_Object != null ? OItem_Object.GUID : null,
                    ID_Parent_Other = OItem_Class != null ? OItem_Class.GUID : null}};

                if (objORel_Schriftverkehr.Any())
                {
                    var objOItem_Result = dbLevel_Schriftverkehr_FilterRel.get_Data_ObjectRel(objORel_Schriftverkehr);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        strLIDs = dbLevel_Schriftverkehr_FilterRel.OList_ObjectRel_ID.Select(fr => fr.ID_Object).ToList();
                    }
                    else
                    {
                        strLIDs = null;
                    }
                }
            }
            else
            {
                objORel_Schriftverkehr = new List<clsObjectRel> { new clsObjectRel {ID_Parent_Other = objLocalConfig.OItem_class_schriftverkehr.GUID,
                    ID_RelationType = OItem_RelationType != null ? OItem_RelationType.GUID : null,
                    ID_Object = OItem_Object != null ? OItem_Object.GUID : null,
                    ID_Parent_Object = OItem_Class != null ? OItem_Class.GUID : null}};

                if (objORel_Schriftverkehr.Any())
                {
                    var objOItem_Result = dbLevel_Schriftverkehr_FilterRel.get_Data_ObjectRel(objORel_Schriftverkehr);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        strLIDs = dbLevel_Schriftverkehr_FilterRel.OList_ObjectRel_ID.Select(fr => fr.ID_Other).ToList();
                    }
                    else
                    {
                        strLIDs = null;
                    }
                }
            }


            


            return strLIDs;
        }


        public clsDataWork_Schriftverkehr(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            dbLevel_Schriftverkehr = new clsDBLevel(objLocalConfig.Globals);
            dbLevel_Schriftverkehr_AttRel = new clsDBLevel(objLocalConfig.Globals);
            dbLevel_Schriftverkehr_Rel = new clsDBLevel(objLocalConfig.Globals);
            dbLevel_Schriftverkehr_FilterRel = new clsDBLevel(objLocalConfig.Globals);

            objDataWork_LogEntry = new clsDataWork_LogEntry(objLocalConfig.Globals);
            objDataWork_Address = new clsDataWork_Address(objLocalConfig.Globals);
            
        }
    }
}
