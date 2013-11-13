using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace LiteraturQuellen_Module
{
    class clsDataWork_VideoQuelle
    {
        private clsLocalConfig objLocalConfig;
        private clsOntologyItem objVideoQuelle;
        public clsOntologyItem OItem_Result_VideoQuelle { get; private set; }

        public clsOntologyItem OItem_Video { get; set; }

        public clsOntologyItem OItem_InternetQuelle { get; set; }

        public clsOntologyItem OItem_Ausstrahlung { get; set; }

        public clsObjectAtt OAItem_AusstrahlungsDatum { get; set; }

        public clsOntologyItem OItem_Partner { get; set; }

        public clsOntologyItem OItem_Sendung { get; set; }

        public clsOntologyItem OItem_Sender { get; set; }

        public clsDataWork_VideoQuelle(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            Initialize();
        }

        public void GetData(clsOntologyItem OItem_VideoQuelle)
        {

            objVideoQuelle = OItem_VideoQuelle;

            OItem_InternetQuelle = null;
            OItem_Video = null;
            OItem_Ausstrahlung = null;
            OAItem_AusstrahlungsDatum = null;
            OItem_Partner = null;
            OItem_Sendung = null;
            OItem_Sender = null;


            if (objVideoQuelle != null)
            {
                
                
                var objVideoQuelle_To_Rel = new List<clsObjectRel> { 
                    new clsObjectRel { ID_Object = objVideoQuelle.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_broadcasted_by.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_type_ausstrahlung.GUID },
                    new clsObjectRel { ID_Object = objVideoQuelle.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_belonging.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_type_video.GUID },
                    new clsObjectRel { ID_Object = objVideoQuelle.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_from.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_type_internet_quellenangabe.GUID },
                    new clsObjectRel { ID_Object = objVideoQuelle.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_part.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_type_media_item_range.GUID } };

                var objDBLevel_VideoQuelle_To_Rel = new clsDBLevel(objLocalConfig.Globals);

                var objOItem_Result = objDBLevel_VideoQuelle_To_Rel.get_Data_ObjectRel(objVideoQuelle_To_Rel, boolIDs:false);
                OItem_Result_VideoQuelle = objOItem_Result;
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (objDBLevel_VideoQuelle_To_Rel.OList_ObjectRel.Any())
                    {
                        var objVideos = objDBLevel_VideoQuelle_To_Rel.OList_ObjectRel.Where(p => p.ID_Parent_Other == objLocalConfig.OItem_type_video.GUID).Select(q => new clsOntologyItem
                        {
                            GUID = q.ID_Other,
                            Name = q.Name_Other,
                            GUID_Parent = q.ID_Parent_Other
                        }).ToList();

                        if (objVideos.Any())
                        {
                            OItem_Video = objVideos.First();

                        }

                        var objInternetQuellen = objDBLevel_VideoQuelle_To_Rel.OList_ObjectRel.Where(p => p.ID_Parent_Other == objLocalConfig.OItem_type_internet_quellenangabe.GUID).Select(q => new clsOntologyItem
                        {
                            GUID = q.ID_Other,
                            Name = q.Name_Other,
                            GUID_Parent = q.ID_Parent_Other
                        }).ToList();

                        if (objInternetQuellen.Any())
                        {
                            OItem_InternetQuelle = objInternetQuellen.First();
                        }

                        var objAusstrahlungen = objDBLevel_VideoQuelle_To_Rel.OList_ObjectRel.Where(p => p.ID_Parent_Other == objLocalConfig.OItem_type_ausstrahlung.GUID).Select(q => new clsOntologyItem
                        {
                            GUID = q.ID_Other,
                            Name = q.Name_Other,
                            GUID_Parent = q.ID_Parent_Other
                        }).ToList();

                        if (objAusstrahlungen.Any())
                        {

                            OItem_Ausstrahlung = objAusstrahlungen.First();
                            var objAusstahlungen_To_Rel = new List<clsObjectRel> {new clsObjectRel
                            {
                                ID_Object = OItem_Ausstrahlung.GUID,
                                ID_Parent_Other = objLocalConfig.OItem_type_partner.GUID,
                                ID_RelationType = objLocalConfig.OItem_relationtype_autor.GUID
                            },
                            new clsObjectRel
                            {
                                ID_Object = OItem_Ausstrahlung.GUID,
                                ID_Parent_Other = objLocalConfig.OItem_class_sendung.GUID,
                                ID_RelationType = objLocalConfig.OItem_relationtype_broadcasted_in.GUID
                            },
                            new clsObjectRel
                            {
                                ID_Object = OItem_Ausstrahlung.GUID,
                                ID_Parent_Other = objLocalConfig.OItem_class_video_sender.GUID,
                                ID_RelationType = objLocalConfig.OItem_relationtype_broadcasted_by.GUID
                            }};

                            var objAusstrahlung_To_Att = new List<clsObjectAtt> { new clsObjectAtt
                            {
                                ID_AttributeType = objLocalConfig.OItem_attribute_datetimestamp.GUID,
                                ID_Object = OItem_Ausstrahlung.GUID
                            } };


                            if (objAusstahlungen_To_Rel.Any())
                            {
                                var objDBLevel_Ausstrahlung_To_Rel = new clsDBLevel(objLocalConfig.Globals);

                                objOItem_Result = objDBLevel_Ausstrahlung_To_Rel.get_Data_ObjectRel(objAusstahlungen_To_Rel, boolIDs: false);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    var objOList_Partner = objDBLevel_Ausstrahlung_To_Rel.OList_ObjectRel.Where(p => p.ID_Parent_Other == objLocalConfig.OItem_type_partner.GUID).Select(p => new clsOntologyItem
                                    {
                                        GUID = p.ID_Other,
                                        Name = p.Name_Other,
                                        GUID_Parent = p.ID_Parent_Other
                                    }).ToList();

                                    if (objOList_Partner.Any())
                                    {
                                        OItem_Partner = objOList_Partner.First();
                                    }

                                    var objOList_Sendung = objDBLevel_Ausstrahlung_To_Rel.OList_ObjectRel.Where(p => p.ID_Parent_Other == objLocalConfig.OItem_class_sendung.GUID).Select(p => new clsOntologyItem
                                    {
                                        GUID = p.ID_Other,
                                        Name = p.Name_Other,
                                        GUID_Parent = p.ID_Parent_Other
                                    }).ToList();

                                    if (objOList_Sendung.Any())
                                    {
                                        OItem_Sendung = objOList_Sendung.First();

                                    }

                                    var objOList_Sender = objDBLevel_Ausstrahlung_To_Rel.OList_ObjectRel.Where(p => p.ID_Parent_Other == objLocalConfig.OItem_class_video_sender.GUID).Select(p => new clsOntologyItem
                                    {
                                        GUID = p.ID_Other,
                                        Name = p.Name_Other,
                                        GUID_Parent = p.ID_Parent_Other
                                    }).ToList();

                                    if (objOList_Sender.Any())
                                    {
                                        OItem_Sender = objOList_Sender.First();
                                    }


                                }
                                else
                                {
                                    OItem_Result_VideoQuelle = objOItem_Result;
                                }
                            }

                            if (objAusstrahlung_To_Att.Any())
                            {
                                var objDBLevel_Ausstrahlungen_To_Att = new clsDBLevel(objLocalConfig.Globals);

                                objOItem_Result = objDBLevel_Ausstrahlungen_To_Att.get_Data_ObjectAtt(objAusstrahlung_To_Att, boolIDs: false);

                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    if (objDBLevel_Ausstrahlungen_To_Att.OList_ObjectAtt.Any())
                                    {
                                        OAItem_AusstrahlungsDatum = objDBLevel_Ausstrahlungen_To_Att.OList_ObjectAtt.First();

                                    }
                                }
                                else
                                {
                                    OItem_Result_VideoQuelle = objOItem_Result;
                                }
                            }

                        }
                    }
                }
                else
                {
                    OItem_Result_VideoQuelle = objOItem_Result;
                }

                
             
            }
            
            
        }

        

        private void Initialize()
        {
            OItem_Result_VideoQuelle = objLocalConfig.Globals.LState_Nothing.Clone();
        }
    }
}
